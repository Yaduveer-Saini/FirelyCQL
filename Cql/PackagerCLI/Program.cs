﻿#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member

using System.Globalization;
using Hl7.Cql.Abstractions;
using Hl7.Cql.CodeGeneration.NET;
using Hl7.Cql.Compiler;
using Hl7.Cql.Conversion;
using Hl7.Cql.Fhir;
using Hl7.Cql.Packaging;
using Hl7.Cql.Packaging.ResourceWriters;
using Hl7.Fhir.Introspection;
using Hl7.Fhir.Model;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Serilog;

namespace Hl7.Cql.Packager;

public class Program
{
    public static int Main(string[] args)
    {
        if (args.Length == 0 ||
            new[] { "-?", "-h", "-help" }.Any(s => args.Contains(s, StringComparer.InvariantCultureIgnoreCase)))
        {
            ShowHelp();
            return -1;
        }

        var hostBuilder = Host.CreateDefaultBuilder()
            .ConfigureAppConfiguration((context, config) => ConfigureAppConfiguration(config, args))
            .ConfigureLogging((context, logging) => ConfigureLogging(logging))
            .ConfigureServices((context, services) => ConfigureServices(context, services));

        return Run(hostBuilder);
    }

    private static IDictionary<string, string> BuildSwitchMappings()
    {
        const string PackageSection = PackagerOptions.ConfigSection + ":";
        const string CSharpResourceWriterSection = CSharpResourceWriterOptions.ConfigSection + ":";
        const string FhirResourceWriterSection = FhirResourceWriterOptions.ConfigSection + ":";

        return new SortedDictionary<string, string>
        {
            // @formatter:off
            [PackagerOptions.ArgNameElmDirectory]             = PackageSection + nameof(PackagerOptions.ElmDirectory),
            [PackagerOptions.ArgNameCqlDirectory]             = PackageSection + nameof(PackagerOptions.CqlDirectory),
            [PackagerOptions.ArgNameDebug]                    = PackageSection + nameof(PackagerOptions.Debug),
            [PackagerOptions.ArgNameForce]                    = PackageSection + nameof(PackagerOptions.Force),
            [PackagerOptions.ArgNameCanonicalRootUrl]         = PackageSection + nameof(PackagerOptions.CanonicalRootUrl),

            [CSharpResourceWriterOptions.ArgNameOutDirectory] = CSharpResourceWriterSection + nameof(CSharpResourceWriterOptions.OutDirectory),

            [FhirResourceWriterOptions.ArgNameOutDirectory]   = FhirResourceWriterSection + nameof(FhirResourceWriterOptions.OutDirectory),
            // @formatter:on
        };
    }

    private const string Usage =
        """
        Packager CLI Usage:
        
            -?|-h|-help                                Show this help
                                                       
            --elm                  <directory>         Library root directory
            --cql                  <directory>         CQL root directory
            [--fhir]               <file|directory>    Resource location, either file name or directory
            [--cs]                 <file|directory>    C# output location, either file name or directory
            [--d]                  <true|false>        Produce as a debug assembly
            [--f]                  <true|false>        Force an overwrite even if the output file already exists
            [--canonical-root-url] <url>               The root url used for the resource canonical.
                                                       If omitted a '#' will be used.
            [--fhir-override-date] <ISO8601-date-time> The UTC date to override in the generated FHIR resource libraries.
                                                       (example: 2000-12-31T23:59:59.99Z)
                                                       If omitted the current date time will be used.
        """;


    private static void ConfigureAppConfiguration(IConfigurationBuilder config, string[] args)
    {
        IDictionary<string, string> switchMappings = BuildSwitchMappings();
        config.AddCommandLine(args, switchMappings);
    }

    private static void ConfigureLogging(ILoggingBuilder logging)
    {
        logging.AddFilter(level => level >= LogLevel.Trace);
        logging.AddConsole(console =>
        {
            console.LogToStandardErrorThreshold = LogLevel.Error;
        });
        var logFile = Path.Combine(".", "build.txt");
        Log.Logger = new LoggerConfiguration()
            .Enrich.FromLogContext()
            .WriteTo
            .File(logFile, formatProvider: CultureInfo.InvariantCulture)
            .CreateLogger();
        logging.AddSerilog();
    }

    private static void ConfigureServices(HostBuilderContext context, IServiceCollection services)
    {
        services.AddPackagerServices(context.Configuration);
        services.AddResourcePackager(context.Configuration);

        // REVIEW: Move these into a separate method
        services.TryAddSingleton(ModelInfo.ModelInspector);
        services.TryAddKeyedSingleton<TypeResolver>("Fhir", FhirTypeResolver.Default);
        services.TryAddKeyedSingleton<TypeConverter>("Fhir", FhirTypeConverter.Default);
        services.TryAddSingleton<OperatorBinding, PackagerCqlOperatorBinding>();
        services.TryAddSingleton<TypeManager, PackagerTypeManager>();
        services.TryAddSingleton<LibraryPackagerService>();
        services.TryAddSingleton<OptionsConsoleDumper>();
        services.TryAddSingleton<AssemblyCompiler, PackagerAssemblyCompiler>();
        services.TryAddSingleton<LibraryDefinitionsBuilder>();
        services.Add(ServiceDescriptor.Singleton(typeof(Factory<>), typeof(ServiceProviderFactory<>)));

    }

    private static int Run(IHostBuilder hostBuilder)
    {
        using var host = CreateHost(hostBuilder);
        if (host is null)
        {
            ShowHelp();
            return -1;
        }

        using var mainScope = host.Services.CreateScope();
        var packageService = mainScope.ServiceProvider.GetRequiredService<PackagerService>();
        return packageService.Run();
    }

    private static IHost? CreateHost(IHostBuilder hostBuilder)
    {
        try
        {
            return hostBuilder.Build();
        }
        catch (OptionsValidationException e) when (e.OptionsType == typeof(PackagerOptions))
        {
            foreach (var failure in e.Failures)
            {
                Console.Error.WriteLine(failure);
            }

            ShowHelp();
            return null;
        }
    }

    private static void ShowHelp()
    {
        Console.WriteLine(Usage);
    }
}

// REVIEW: Move these classes into a separate files

file class ServiceProviderFactory<T> : Factory<T>
{
    private readonly IServiceProvider _sp;

    public ServiceProviderFactory(IServiceProvider sp) => _sp = sp;

    public override T Create() => ActivatorUtilities.CreateInstance<T>(_sp);
}

file class PackagerAssemblyCompiler : AssemblyCompiler
{
    public PackagerAssemblyCompiler(
        LibraryDefinitionsBuilder libraryDefinitionsBuilder,
        [FromKeyedServices("Fhir")] TypeResolver typeResolver, 
        TypeManager typeManager, 
        OperatorBinding operatorBinding) : base(libraryDefinitionsBuilder,typeResolver, typeManager, operatorBinding)
    {
    }
}

file class PackagerTypeManager : TypeManager
{
    public PackagerTypeManager([FromKeyedServices("Fhir")] TypeResolver resolver) : base(resolver)
    {
    }
}

file class PackagerCqlOperatorBinding : CqlOperatorsBinding
{
    public PackagerCqlOperatorBinding(
        [FromKeyedServices("Fhir")] TypeResolver typeResolver,
        [FromKeyedServices("Fhir")] TypeConverter? typeConverter = null) : base(typeResolver, typeConverter)
    {
    }
}