﻿using System;
using Tuples;
using System.Linq;
using System.Collections.Generic;
using Hl7.Cql.Runtime;
using Hl7.Cql.Primitives;
using Hl7.Cql.Abstractions;
using Hl7.Cql.ValueSets;
using Hl7.Cql.Iso8601;
using System.Reflection;
using Hl7.Fhir.Model;
using Range = Hl7.Fhir.Model.Range;
using Task = Hl7.Fhir.Model.Task;
[System.CodeDom.Compiler.GeneratedCode(".NET Code Generation", "2.0.0.0")]
[CqlLibrary("ParametersExample", "0.0.1")]
public class ParametersExample_0_0_1
{


    internal CqlContext context;

    #region Cached values

    internal Lazy<CqlValueSet> __Marital_Status;
    internal Lazy<int?> __AgeThreshold;
    internal Lazy<Patient> __Patient;
    internal Lazy<CqlDate> __CurrentDate;
    internal Lazy<Patient> __Patient_Filter;
    internal Lazy<Date> __Patient_Birthdate;
    internal Lazy<int?> __Patient_Age_in_Years;
    internal Lazy<bool?> __Patient_Older_Than_AgeThreshold;

    #endregion
    public ParametersExample_0_0_1(CqlContext context)
    {
        this.context = context ?? throw new ArgumentNullException("context");

        FHIRHelpers_4_3_000 = new FHIRHelpers_4_3_000(context);

        __Marital_Status = new Lazy<CqlValueSet>(this.Marital_Status_Value);
        __AgeThreshold = new Lazy<int?>(this.AgeThreshold_Value);
        __Patient = new Lazy<Patient>(this.Patient_Value);
        __CurrentDate = new Lazy<CqlDate>(this.CurrentDate_Value);
        __Patient_Filter = new Lazy<Patient>(this.Patient_Filter_Value);
        __Patient_Birthdate = new Lazy<Date>(this.Patient_Birthdate_Value);
        __Patient_Age_in_Years = new Lazy<int?>(this.Patient_Age_in_Years_Value);
        __Patient_Older_Than_AgeThreshold = new Lazy<bool?>(this.Patient_Older_Than_AgeThreshold_Value);
    }
    #region Dependencies

    public FHIRHelpers_4_3_000 FHIRHelpers_4_3_000 { get; }

    #endregion

	private CqlValueSet Marital_Status_Value() => 
		new CqlValueSet("http://hl7.org/fhir/ValueSet/marital-status", null);

    [CqlDeclaration("Marital Status")]
    [CqlValueSet("http://hl7.org/fhir/ValueSet/marital-status")]
	public CqlValueSet Marital_Status() => 
		__Marital_Status.Value;

	private int? AgeThreshold_Value()
	{
		var a_ = context.ResolveParameter("ParametersExample-0.0.1", "AgeThreshold", 30);

		return (int?)a_;
	}

    [CqlDeclaration("AgeThreshold")]
	public int? AgeThreshold() => 
		__AgeThreshold.Value;

	private Patient Patient_Value()
	{
		var a_ = context.Operators.RetrieveByValueSet<Patient>(null, null);
		var b_ = context.Operators.SingletonFrom<Patient>(a_);

		return b_;
	}

    [CqlDeclaration("Patient")]
	public Patient Patient() => 
		__Patient.Value;

	private CqlDate CurrentDate_Value()
	{
		var a_ = context.Operators.Today();

		return a_;
	}

    [CqlDeclaration("CurrentDate")]
	public CqlDate CurrentDate() => 
		__CurrentDate.Value;

	private Patient Patient_Filter_Value()
	{
		var a_ = this.Patient();
		var b_ = new Patient[]
		{
			a_,
		};
		bool? c_(Patient P)
		{
			var f_ = P?.GenderElement;
			var g_ = FHIRHelpers_4_3_000.ToString(f_);
			var h_ = context.Operators.Equal(g_, "male");
			var i_ = P?.ActiveElement;
			var j_ = FHIRHelpers_4_3_000.ToBoolean(i_);
			var k_ = context.Operators.IsTrue(j_);
			var l_ = context.Operators.And(h_, k_);
			var m_ = P?.Deceased;
			var n_ = FHIRHelpers_4_3_000.ToBoolean((m_ as FhirBoolean));
			var o_ = context.Operators.Not(n_);
			var p_ = context.Operators.And(l_, o_);
			var q_ = P?.MaritalStatus;
			var r_ = FHIRHelpers_4_3_000.ToConcept(q_);
			var s_ = this.Marital_Status();
			var t_ = context.Operators.ConceptInValueSet(r_, s_);
			var u_ = context.Operators.And(p_, t_);

			return u_;
		};
		var d_ = context.Operators.Where<Patient>((IEnumerable<Patient>)b_, c_);
		var e_ = context.Operators.SingletonFrom<Patient>(d_);

		return e_;
	}

    [CqlDeclaration("Patient Filter")]
	public Patient Patient_Filter() => 
		__Patient_Filter.Value;

	private Date Patient_Birthdate_Value()
	{
		var a_ = this.Patient_Filter();

		return a_?.BirthDateElement;
	}

    [CqlDeclaration("Patient Birthdate")]
	public Date Patient_Birthdate() => 
		__Patient_Birthdate.Value;

	private int? Patient_Age_in_Years_Value()
	{
		var a_ = this.Patient_Birthdate();
		var b_ = FHIRHelpers_4_3_000.ToDate(a_);
		var c_ = this.CurrentDate();
		var d_ = context.Operators.DurationBetween(b_, c_, "year");

		return d_;
	}

    [CqlDeclaration("Patient Age in Years")]
	public int? Patient_Age_in_Years() => 
		__Patient_Age_in_Years.Value;

	private bool? Patient_Older_Than_AgeThreshold_Value()
	{
		var a_ = this.Patient_Age_in_Years();
		var b_ = this.AgeThreshold();
		var c_ = context.Operators.Greater(a_, b_);

		return c_;
	}

    [CqlDeclaration("Patient Older Than AgeThreshold")]
	public bool? Patient_Older_Than_AgeThreshold() => 
		__Patient_Older_Than_AgeThreshold.Value;

}
