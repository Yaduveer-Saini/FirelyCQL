using System.Collections.Generic;
using System;
using System.IO;
using System.Linq;
using Hl7.Cql.Compiler;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CoreTests;

[TestClass]
public class LibrarySetTests
{
    public static DirectoryInfo CmsDirectory { get; } = GetCmsDirectory();

    private static DirectoryInfo GetCmsDirectory()
    {
        var solutionDirectory = GetSolutionDirectory();
        var dir = new DirectoryInfo(Path.Combine(solutionDirectory.FullName, "LibrarySets", "CMS", "Elm"));
        return dir;
    }


    [TestMethod]
    public void LoadLibraryAndDependencies_ReturnsLibraryAndDependencies_WhenGivenDirectoryAndLibraryName()
    {
        LibrarySet librarySet = new();
        var libraries = librarySet.LoadLibraryAndDependencies(CmsDirectory, "DischargedonAntithromboticTherapyFHIR");
        Assert.IsTrue(libraries.Count == 6, "Expected 6 libraries to load for DischargedonAntithromboticTherapyFHIR");
        Assert.IsTrue(librarySet.Cast<object>().Count() == 6, "Expected 6 libraries to load for DischargedonAntithromboticTherapyFHIR");
    }


    [TestMethod]
    public void Test()
    {
        LibrarySet librarySet = new();
        var libraries = librarySet.LoadLibraryAndDependencies(CmsDirectory, "CumulativeMedicationDuration");
        var f = new LibrarySetExpressionBuilderFactory(NullLoggerFactory.Instance);
        var defs = f.LibrarySetExpressionBuilder.ProcessLibrarySet(librarySet);
    }

    private static DirectoryInfo GetSolutionDirectory() =>
        new DirectoryInfo(Directory.GetCurrentDirectory())
            .Enumerate(d => d.Parent)
            .TakeWhile(d => d is not null)
            .LastOrDefault(d => d.EnumerateFiles("*.sln", SearchOption.TopDirectoryOnly).Any())
        ?? throw new InvalidOperationException("Could not find an ancestor directory containing a solution file.");
}


file static class Helper
{
    public static IEnumerable<T> Enumerate<T>(
        this T seed, 
        Func<T, T> getNext)
    {
        var current = seed;
        while (true)
        {
            yield return current;
            current = getNext(current);
        }
    }
}