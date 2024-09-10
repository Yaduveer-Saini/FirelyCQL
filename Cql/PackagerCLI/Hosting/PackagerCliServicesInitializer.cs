﻿/*
 * Copyright (c) 2024, NCQA and contributors
 * See the file CONTRIBUTORS for details.
 *
 * This file is licensed under the BSD 3-Clause license
 * available at https://raw.githubusercontent.com/FirelyTeam/firely-cql-sdk/main/LICENSE
 */

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Hl7.Cql.Packaging.Hosting;

namespace Hl7.Cql.Packager.Hosting;

internal static class PackagerCliServicesInitializer
{
    internal static PackagerCliServices GetPackagerCliServices(
        this IServiceProvider serviceProvider) =>
        new PackagerCliServices(serviceProvider);

    internal static IServiceCollection AddPackagerCliServices(
        this IServiceCollection services)
    {
        services.AddCqlPackagingServices();

        services.TryAddScoped<PackagerCliProgram>();
        services.TryAddSingleton<OptionsConsoleDumper>();

        // services.TryAddScoped<TestSingleton>();
        // services.TryAddScoped<TestScoped>();
        return services;
    }
}

internal class TestSingleton : IDisposable
{
    private readonly TestScoped _testScoped;

    public TestSingleton(TestScoped testScoped)
    {
        _testScoped = testScoped;
        ;
    }

    public void Dispose()
    {
        ;
    }
}

internal class TestScoped : IDisposable
{
    public TestScoped()
    {
        ;
    }

    public void Dispose()
    {
        ;
    }
}