﻿/*
 * Copyright (c) 2024, NCQA and contributors
 * See the file CONTRIBUTORS for details.
 *
 * This file is licensed under the BSD 3-Clause license
 * available at https://raw.githubusercontent.com/FirelyTeam/firely-cql-sdk/main/LICENSE
 */

using Hl7.Cql.Packaging;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Hl7.Cql.Packager;

internal class PackagerCliProgram(
    ILogger<PackagerCliProgram> logger,
    OptionsConsoleDumper optionsConsoleDumper,
    CqlToResourcePackagingPipeline cqlToResourcePackagingPipeline,
    IHostApplicationLifetime hostLifetime)
{
    public int Run()
    {
        try
        {
            optionsConsoleDumper.DumpToConsole();
            cqlToResourcePackagingPipeline.ProcessCqlToResources();
            return 0;
        }
        catch (Exception e)
        {
            logger.LogError(e, "An error occurred while running the packager");
            Console.Error.WriteLine(
                "An error occurred while running PackagerCLI. Consult the build.log file for more detail.");
            return -1;
        }
        finally
        {
            hostLifetime.StopApplication();
        }
    }
}



/*internal class ProgramCqlPackagerFactory(
    ILoggerFactory loggerFactory,
    IHostApplicationLifetime hostLifetime,
    IOptions<CqlToResourcePackagingOptions> cqlToResourcePackagingOptions,
    IOptions<CSharpCodeWriterOptions> cSharpCodeWriterOptions,
    IOptions<FhirResourceWriterOptions> fhirResourceWriterOptions,
    IOptions<AssemblyDataWriterOptions> assemblyDataWriterOptions)
    : CqlPackagerFactory(loggerFactory,
                         cacheSize: 0,
                         cqlToResourcePackagingOptions: cqlToResourcePackagingOptions.Value,
                         cSharpCodeWriterOptions: cSharpCodeWriterOptions.Value,
                         fhirResourceWriterOptions: fhirResourceWriterOptions.Value,
                         assemblyDataWriterOptions: assemblyDataWriterOptions.Value,
                         cancellationToken: hostLifetime.ApplicationStopping);*/