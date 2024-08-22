using Hl7.Fhir.Model;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using System.Linq;
using Hl7.Cql.Compiler;
using Hl7.Cql.CodeGeneration.NET;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;

namespace CoreTests
{
    [TestClass]
    public class LibraryExpressionBuilderTests
    {
        private static ILoggerFactory LoggerFactory { get; } =
            Microsoft.Extensions.Logging.LoggerFactory
                .Create(logging => logging.AddDebug());

        private static readonly CqlCompilerFactory Factory = new(LoggerFactory);

        [TestMethod]
        public void AggregateQueries_1_0_0()
        {
            var elm = new FileInfo(@"Input\ELM\Test\Aggregates-1.0.0.json");
            var elmPackage = Hl7.Cql.Elm.Library.LoadFromJson(elm);
            var definitions = Factory.LibraryExpressionBuilder.ProcessLibrary(elmPackage);
            Assert.IsNotNull(definitions);
            Assert.IsTrue(definitions.Libraries.Any());
        }

        [TestMethod]
        public void FHIRConversionTest_1_0_0()
        {
            var elm = new FileInfo(@"Input\ELM\HL7\FHIRConversionTest.json");
            var elmPackage = Hl7.Cql.Elm.Library.LoadFromJson(elm);
            var definitions = Factory.LibraryExpressionBuilder.ProcessLibrary(elmPackage);
            Assert.IsNotNull(definitions);
            Assert.IsTrue(definitions.Libraries.Any());
        }

        [TestMethod]
        public void QueriesTest_1_0_0()
        {
            var elm = new FileInfo(@"Input\ELM\Test\QueriesTest-1.0.0.json");
            var elmPackage = Hl7.Cql.Elm.Library.LoadFromJson(elm);
            var definitions = Factory.LibraryExpressionBuilder.ProcessLibrary(elmPackage);
            Assert.IsNotNull(definitions);
            Assert.IsTrue(definitions.Libraries.Any());
        }

        // https://github.com/FirelyTeam/firely-cql-sdk/issues/129
        [TestMethod]
        public void Medication_Request_Example_Test()
        {
            FileInfo[] files =
            [
                new(@"Input\ELM\Test\Medication_Request_Example.json"),
                new(@"Input\ELM\Libs\FHIRHelpers-4.0.1.json")
            ];
            var librarySet = new LibrarySet();
            librarySet.LoadLibraries(files);

            var fdt = new FhirDateTime(2023, 12, 11, 9, 41, 30, TimeSpan.FromHours(-5));
            var fdts = fdt.ToString();
            var fs = new FhirDateTime(fdts);
            Assert.AreEqual(fdt, fs);

            var definitions = Factory.LibrarySetExpressionBuilder.ProcessLibrarySet(librarySet);
            Assert.IsNotNull(definitions);
            Assert.IsTrue(definitions.Libraries.Any());
        }

        [TestMethod]
        public void Get_Property_Uses_TypeResolver()
        {
            var property = ExpressionBuilder.GetProperty(typeof(MeasureReport.PopulationComponent), "id", Factory.TypeManager.Resolver)!;
            Assert.AreEqual(typeof(Element), property.DeclaringType);
            Assert.AreEqual(nameof(Element.ElementId), property.Name);
        }

        [TestMethod]
        [Ignore("Currently failing")]
        public void SupplementalDataElements()
        {
            var fh = Hl7.Cql.Elm.Library.LoadFromJson(new FileInfo(@"Input\ELM\Libs\FHIRHelpers-4.3.000.json"));
            var lib = Hl7.Cql.Elm.Library.LoadFromJson(new FileInfo(@"Input\ELM\Libs\SupplementalDataElements.json"));
            var ls = new LibrarySet("", fh, lib);
            var cs = ls.ToCSharp();
            var assemblies = ls.Compile();
        }

    }
}