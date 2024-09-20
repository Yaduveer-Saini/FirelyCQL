﻿using System;
using System.Linq;
using System.Collections.Generic;
using Hl7.Cql.Runtime;
using Hl7.Cql.Primitives;
using Hl7.Cql.Abstractions;
using Hl7.Cql.ValueSets;
using Hl7.Cql.Iso8601;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Hl7.Fhir.Model;
using Range = Hl7.Fhir.Model.Range;
using Task = Hl7.Fhir.Model.Task;

#pragma warning disable CS9113 // Parameter is unread.

[System.CodeDom.Compiler.GeneratedCode(".NET Code Generation", "2.0.3.0")]
public static partial class TestRetrieve_1_0_1ServiceCollectionExtensions
{
    public static IServiceCollection AddTestRetrieve_1_0_1(this IServiceCollection services)
    {
        services.TryAddSingleton<TestRetrieve_1_0_1>(sp =>
        {
            System.IO.File.AppendAllLines("C:\\temp\\library.txt", ["TestRetrieve_1_0_1"]);
            return ActivatorUtilities.CreateInstance<TestRetrieve_1_0_1>(sp);
        });
        services.AddFHIRHelpers_4_0_1();
        services.AddTestRetrieveInclude_1_0_1();
        return services;
    }
}

partial class TestRetrieve_1_0_1 : ICqlLibrary
{
    public static void AddLibraryService(IServiceCollection services) =>
        services.AddTestRetrieve_1_0_1();
}

[System.CodeDom.Compiler.GeneratedCode(".NET Code Generation", "2.0.3.0")]
[CqlLibrary("TestRetrieve", "1.0.1")]
public partial class TestRetrieve_1_0_1(
    FHIRHelpers_4_0_1 fhirHelpers_4_0_1,
    TestRetrieveInclude_1_0_1 testRetrieveInclude_1_0_1)
{

    [CqlDeclaration("HIV")]
    [CqlValueSet("2.16.840.1.113883.3.464.1003.120.12.1003")]
	public CqlValueSet HIV(CqlContext context) => 
		new CqlValueSet("2.16.840.1.113883.3.464.1003.120.12.1003", default);

    [CqlDeclaration("Syphilis")]
    [CqlValueSet("2.16.840.1.113883.3.464.1003.112.12.1002")]
	public CqlValueSet Syphilis(CqlContext context) => 
		new CqlValueSet("2.16.840.1.113883.3.464.1003.112.12.1002", default);

    [CqlDeclaration("Complications of Pregnancy, Childbirth and the Puerperium")]
    [CqlValueSet("2.16.840.1.113883.3.464.1003.111.12.1012")]
	public CqlValueSet Complications_of_Pregnancy__Childbirth_and_the_Puerperium(CqlContext context) => 
		new CqlValueSet("2.16.840.1.113883.3.464.1003.111.12.1012", default);

    [CqlDeclaration("Pregnancy Test")]
    [CqlValueSet("2.16.840.1.113883.3.464.1003.111.12.1011")]
	public CqlValueSet Pregnancy_Test(CqlContext context) => 
		new CqlValueSet("2.16.840.1.113883.3.464.1003.111.12.1011", default);

    [CqlDeclaration("Pap Test")]
    [CqlValueSet("2.16.840.1.113883.3.464.1003.108.12.1017")]
	public CqlValueSet Pap_Test(CqlContext context) => 
		new CqlValueSet("2.16.840.1.113883.3.464.1003.108.12.1017", default);

    [CqlDeclaration("Lab Tests During Pregnancy")]
    [CqlValueSet("2.16.840.1.113883.3.464.1003.111.12.1007")]
	public CqlValueSet Lab_Tests_During_Pregnancy(CqlContext context) => 
		new CqlValueSet("2.16.840.1.113883.3.464.1003.111.12.1007", default);

    [CqlDeclaration("Lab Tests for Sexually Transmitted Infections")]
    [CqlValueSet("2.16.840.1.113883.3.464.1003.110.12.1051")]
	public CqlValueSet Lab_Tests_for_Sexually_Transmitted_Infections(CqlContext context) => 
		new CqlValueSet("2.16.840.1.113883.3.464.1003.110.12.1051", default);

    [CqlDeclaration("Chlamydia Screening")]
    [CqlValueSet("2.16.840.1.113883.3.464.1003.110.12.1052")]
	public CqlValueSet Chlamydia_Screening(CqlContext context) => 
		new CqlValueSet("2.16.840.1.113883.3.464.1003.110.12.1052", default);

    [CqlDeclaration("Palliative Care Assessment")]
    [CqlValueSet("https://www.ncqa.org/fhir/valueset/2.16.840.1.113883.3.464.1004.2225")]
	public CqlValueSet Palliative_Care_Assessment(CqlContext context) => 
		new CqlValueSet("https://www.ncqa.org/fhir/valueset/2.16.840.1.113883.3.464.1004.2225", default);

    [CqlDeclaration("Palliative Care Encounter")]
    [CqlValueSet("https://www.ncqa.org/fhir/valueset/2.16.840.1.113883.3.464.1004.1450")]
	public CqlValueSet Palliative_Care_Encounter(CqlContext context) => 
		new CqlValueSet("https://www.ncqa.org/fhir/valueset/2.16.840.1.113883.3.464.1004.1450", default);

    [CqlDeclaration("Palliative Care Intervention")]
    [CqlValueSet("https://www.ncqa.org/fhir/valueset/2.16.840.1.113883.3.464.1004.2224")]
	public CqlValueSet Palliative_Care_Intervention(CqlContext context) => 
		new CqlValueSet("https://www.ncqa.org/fhir/valueset/2.16.840.1.113883.3.464.1004.2224", default);

    [CqlDeclaration("Encounter for palliative care")]
	public CqlCode Encounter_for_palliative_care(CqlContext context) => 
		new CqlCode("Z51.5", "http://hl7.org/fhir/sid/icd-10-cm", default, default);

    [CqlDeclaration("ICD-10")]
	public CqlCode[] ICD_10(CqlContext context)
	{
		CqlCode[] a_ = [
			new CqlCode("Z51.5", "http://hl7.org/fhir/sid/icd-10-cm", default, default),
		];

		return a_;
	}

    [CqlDeclaration("MeasurementPeriod")]
	public object MeasurementPeriod(CqlContext context)
	{
		CqlDateTime a_ = context.Operators.DateTime(2013, 1, 1, 0, 0, 0, 0, default);
		CqlDateTime b_ = context.Operators.DateTime(2014, 1, 1, 0, 0, 0, 0, default);
		CqlInterval<CqlDateTime> c_ = context.Operators.Interval(a_, b_, true, false);
		object d_ = context.ResolveParameter("TestRetrieve-1.0.1", "MeasurementPeriod", c_);

		return d_;
	}

    [CqlDeclaration("Patient")]
	public Patient Patient(CqlContext context)
	{
		IEnumerable<Patient> a_ = context.Operators.RetrieveByValueSet<Patient>(default, default);
		Patient b_ = context.Operators.SingletonFrom<Patient>(a_);

		return b_;
	}

}
