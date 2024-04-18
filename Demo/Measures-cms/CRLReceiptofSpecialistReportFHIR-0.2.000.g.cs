﻿using System;
using System.Linq;
using System.Collections.Generic;
using Hl7.Cql.Runtime;
using Hl7.Cql.Primitives;
using Hl7.Cql.Abstractions;
using Hl7.Cql.ValueSets;
using Hl7.Cql.Iso8601;
using Hl7.Fhir.Model;
using Range = Hl7.Fhir.Model.Range;
using Task = Hl7.Fhir.Model.Task;
[System.CodeDom.Compiler.GeneratedCode(".NET Code Generation", "2.0.0.0")]
[CqlLibrary("CRLReceiptofSpecialistReportFHIR", "0.2.000")]
public class CRLReceiptofSpecialistReportFHIR_0_2_000
{


    internal CqlContext context;

    #region Cached values

    internal Lazy<CqlValueSet> __Consultant_Report;
    internal Lazy<CqlValueSet> __Office_Visit;
    internal Lazy<CqlValueSet> __Ophthalmological_Services;
    internal Lazy<CqlValueSet> __Preventive_Care_Services___Established_Office_Visit__18_and_Up;
    internal Lazy<CqlValueSet> __Preventive_Care_Services__Initial_Office_Visit__0_to_17;
    internal Lazy<CqlValueSet> __Preventive_Care_Services_Initial_Office_Visit__18_and_Up;
    internal Lazy<CqlValueSet> __Preventive_Care__Established_Office_Visit__0_to_17;
    internal Lazy<CqlValueSet> __Referral;
    internal Lazy<CqlInterval<CqlDateTime>> __Measurement_Period;
    internal Lazy<Patient> __Patient;
    internal Lazy<bool?> __Has_Encounter_during_Measurement_Period;
    internal Lazy<Tuples.Tuple_BQRHOWGHNMjBJPPZJZXVMjCPK> __First_Referral_during_First_10_Months_of_Measurement_Period;
    internal Lazy<bool?> __Initial_Population;
    internal Lazy<bool?> __Denominator;
    internal Lazy<Tuples.Tuple_DMgHTLENEHBHWJISQgKZGZVMB> __SDE_Ethnicity;
    internal Lazy<IEnumerable<Tuples.Tuple_GDKRbfOIHhLGieQSVDEMIaDPX>> __SDE_Payer;
    internal Lazy<Tuples.Tuple_DMgHTLENEHBHWJISQgKZGZVMB> __SDE_Race;
    internal Lazy<CqlCode> __SDE_Sex;
    internal Lazy<bool?> __Referring_Clinician_Receives_Consultant_Report_to_Close_Referral_Loop;
    internal Lazy<bool?> __Numerator;

    #endregion
    public CRLReceiptofSpecialistReportFHIR_0_2_000(CqlContext context)
    {
        this.context = context ?? throw new ArgumentNullException("context");

        FHIRHelpers_4_3_000 = new FHIRHelpers_4_3_000(context);
        SupplementalDataElements_3_4_000 = new SupplementalDataElements_3_4_000(context);
        QICoreCommon_2_0_000 = new QICoreCommon_2_0_000(context);

        __Consultant_Report = new Lazy<CqlValueSet>(this.Consultant_Report_Value);
        __Office_Visit = new Lazy<CqlValueSet>(this.Office_Visit_Value);
        __Ophthalmological_Services = new Lazy<CqlValueSet>(this.Ophthalmological_Services_Value);
        __Preventive_Care_Services___Established_Office_Visit__18_and_Up = new Lazy<CqlValueSet>(this.Preventive_Care_Services___Established_Office_Visit__18_and_Up_Value);
        __Preventive_Care_Services__Initial_Office_Visit__0_to_17 = new Lazy<CqlValueSet>(this.Preventive_Care_Services__Initial_Office_Visit__0_to_17_Value);
        __Preventive_Care_Services_Initial_Office_Visit__18_and_Up = new Lazy<CqlValueSet>(this.Preventive_Care_Services_Initial_Office_Visit__18_and_Up_Value);
        __Preventive_Care__Established_Office_Visit__0_to_17 = new Lazy<CqlValueSet>(this.Preventive_Care__Established_Office_Visit__0_to_17_Value);
        __Referral = new Lazy<CqlValueSet>(this.Referral_Value);
        __Measurement_Period = new Lazy<CqlInterval<CqlDateTime>>(this.Measurement_Period_Value);
        __Patient = new Lazy<Patient>(this.Patient_Value);
        __Has_Encounter_during_Measurement_Period = new Lazy<bool?>(this.Has_Encounter_during_Measurement_Period_Value);
        __First_Referral_during_First_10_Months_of_Measurement_Period = new Lazy<Tuples.Tuple_BQRHOWGHNMjBJPPZJZXVMjCPK>(this.First_Referral_during_First_10_Months_of_Measurement_Period_Value);
        __Initial_Population = new Lazy<bool?>(this.Initial_Population_Value);
        __Denominator = new Lazy<bool?>(this.Denominator_Value);
        __SDE_Ethnicity = new Lazy<Tuples.Tuple_DMgHTLENEHBHWJISQgKZGZVMB>(this.SDE_Ethnicity_Value);
        __SDE_Payer = new Lazy<IEnumerable<Tuples.Tuple_GDKRbfOIHhLGieQSVDEMIaDPX>>(this.SDE_Payer_Value);
        __SDE_Race = new Lazy<Tuples.Tuple_DMgHTLENEHBHWJISQgKZGZVMB>(this.SDE_Race_Value);
        __SDE_Sex = new Lazy<CqlCode>(this.SDE_Sex_Value);
        __Referring_Clinician_Receives_Consultant_Report_to_Close_Referral_Loop = new Lazy<bool?>(this.Referring_Clinician_Receives_Consultant_Report_to_Close_Referral_Loop_Value);
        __Numerator = new Lazy<bool?>(this.Numerator_Value);
    }
    #region Dependencies

    public FHIRHelpers_4_3_000 FHIRHelpers_4_3_000 { get; }
    public SupplementalDataElements_3_4_000 SupplementalDataElements_3_4_000 { get; }
    public QICoreCommon_2_0_000 QICoreCommon_2_0_000 { get; }

    #endregion

	private CqlValueSet Consultant_Report_Value() => 
		new CqlValueSet("http://cts.nlm.nih.gov/fhir/ValueSet/2.16.840.1.113883.3.464.1003.121.12.1006", null);

    [CqlDeclaration("Consultant Report")]
    [CqlValueSet("http://cts.nlm.nih.gov/fhir/ValueSet/2.16.840.1.113883.3.464.1003.121.12.1006")]
	public CqlValueSet Consultant_Report() => 
		__Consultant_Report.Value;

	private CqlValueSet Office_Visit_Value() => 
		new CqlValueSet("http://cts.nlm.nih.gov/fhir/ValueSet/2.16.840.1.113883.3.464.1003.101.12.1001", null);

    [CqlDeclaration("Office Visit")]
    [CqlValueSet("http://cts.nlm.nih.gov/fhir/ValueSet/2.16.840.1.113883.3.464.1003.101.12.1001")]
	public CqlValueSet Office_Visit() => 
		__Office_Visit.Value;

	private CqlValueSet Ophthalmological_Services_Value() => 
		new CqlValueSet("http://cts.nlm.nih.gov/fhir/ValueSet/2.16.840.1.113883.3.526.3.1285", null);

    [CqlDeclaration("Ophthalmological Services")]
    [CqlValueSet("http://cts.nlm.nih.gov/fhir/ValueSet/2.16.840.1.113883.3.526.3.1285")]
	public CqlValueSet Ophthalmological_Services() => 
		__Ophthalmological_Services.Value;

	private CqlValueSet Preventive_Care_Services___Established_Office_Visit__18_and_Up_Value() => 
		new CqlValueSet("http://cts.nlm.nih.gov/fhir/ValueSet/2.16.840.1.113883.3.464.1003.101.12.1025", null);

    [CqlDeclaration("Preventive Care Services - Established Office Visit, 18 and Up")]
    [CqlValueSet("http://cts.nlm.nih.gov/fhir/ValueSet/2.16.840.1.113883.3.464.1003.101.12.1025")]
	public CqlValueSet Preventive_Care_Services___Established_Office_Visit__18_and_Up() => 
		__Preventive_Care_Services___Established_Office_Visit__18_and_Up.Value;

	private CqlValueSet Preventive_Care_Services__Initial_Office_Visit__0_to_17_Value() => 
		new CqlValueSet("http://cts.nlm.nih.gov/fhir/ValueSet/2.16.840.1.113883.3.464.1003.101.12.1022", null);

    [CqlDeclaration("Preventive Care Services, Initial Office Visit, 0 to 17")]
    [CqlValueSet("http://cts.nlm.nih.gov/fhir/ValueSet/2.16.840.1.113883.3.464.1003.101.12.1022")]
	public CqlValueSet Preventive_Care_Services__Initial_Office_Visit__0_to_17() => 
		__Preventive_Care_Services__Initial_Office_Visit__0_to_17.Value;

	private CqlValueSet Preventive_Care_Services_Initial_Office_Visit__18_and_Up_Value() => 
		new CqlValueSet("http://cts.nlm.nih.gov/fhir/ValueSet/2.16.840.1.113883.3.464.1003.101.12.1023", null);

    [CqlDeclaration("Preventive Care Services-Initial Office Visit, 18 and Up")]
    [CqlValueSet("http://cts.nlm.nih.gov/fhir/ValueSet/2.16.840.1.113883.3.464.1003.101.12.1023")]
	public CqlValueSet Preventive_Care_Services_Initial_Office_Visit__18_and_Up() => 
		__Preventive_Care_Services_Initial_Office_Visit__18_and_Up.Value;

	private CqlValueSet Preventive_Care__Established_Office_Visit__0_to_17_Value() => 
		new CqlValueSet("http://cts.nlm.nih.gov/fhir/ValueSet/2.16.840.1.113883.3.464.1003.101.12.1024", null);

    [CqlDeclaration("Preventive Care, Established Office Visit, 0 to 17")]
    [CqlValueSet("http://cts.nlm.nih.gov/fhir/ValueSet/2.16.840.1.113883.3.464.1003.101.12.1024")]
	public CqlValueSet Preventive_Care__Established_Office_Visit__0_to_17() => 
		__Preventive_Care__Established_Office_Visit__0_to_17.Value;

	private CqlValueSet Referral_Value() => 
		new CqlValueSet("http://cts.nlm.nih.gov/fhir/ValueSet/2.16.840.1.113883.3.464.1003.101.12.1046", null);

    [CqlDeclaration("Referral")]
    [CqlValueSet("http://cts.nlm.nih.gov/fhir/ValueSet/2.16.840.1.113883.3.464.1003.101.12.1046")]
	public CqlValueSet Referral() => 
		__Referral.Value;

	private CqlInterval<CqlDateTime> Measurement_Period_Value()
	{
		var a_ = context.Operators.DateTime((int?)2025, (int?)1, (int?)1, (int?)0, (int?)0, (int?)0, (int?)0, default);
		var b_ = context.Operators.DateTime((int?)2026, (int?)1, (int?)1, (int?)0, (int?)0, (int?)0, (int?)0, default);
		var c_ = context.Operators.Interval(a_, b_, true, false);
		var d_ = context.ResolveParameter("CRLReceiptofSpecialistReportFHIR-0.2.000", "Measurement Period", c_);

		return (CqlInterval<CqlDateTime>)d_;
	}

    [CqlDeclaration("Measurement Period")]
	public CqlInterval<CqlDateTime> Measurement_Period() => 
		__Measurement_Period.Value;

	private Patient Patient_Value()
	{
		var a_ = context.Operators.RetrieveByValueSet<Patient>(null, null);
		var b_ = context.Operators.SingleOrNull<Patient>(a_);

		return b_;
	}

    [CqlDeclaration("Patient")]
	public Patient Patient() => 
		__Patient.Value;

	private bool? Has_Encounter_during_Measurement_Period_Value()
	{
		var a_ = this.Office_Visit();
		var b_ = context.Operators.RetrieveByValueSet<Encounter>(a_, null);
		var c_ = this.Ophthalmological_Services();
		var d_ = context.Operators.RetrieveByValueSet<Encounter>(c_, null);
		var e_ = context.Operators.ListUnion<Encounter>(b_, d_);
		var f_ = this.Preventive_Care_Services___Established_Office_Visit__18_and_Up();
		var g_ = context.Operators.RetrieveByValueSet<Encounter>(f_, null);
		var h_ = this.Preventive_Care_Services__Initial_Office_Visit__0_to_17();
		var i_ = context.Operators.RetrieveByValueSet<Encounter>(h_, null);
		var j_ = context.Operators.ListUnion<Encounter>(g_, i_);
		var k_ = context.Operators.ListUnion<Encounter>(e_, j_);
		var l_ = this.Preventive_Care_Services_Initial_Office_Visit__18_and_Up();
		var m_ = context.Operators.RetrieveByValueSet<Encounter>(l_, null);
		var n_ = this.Preventive_Care__Established_Office_Visit__0_to_17();
		var o_ = context.Operators.RetrieveByValueSet<Encounter>(n_, null);
		var p_ = context.Operators.ListUnion<Encounter>(m_, o_);
		var q_ = context.Operators.ListUnion<Encounter>(k_, p_);
		bool? r_(Encounter Encounter)
		{
			var u_ = context.Operators.Convert<Code<Encounter.EncounterStatus>>(Encounter?.StatusElement?.Value);
			var v_ = context.Operators.Equal(u_, (string)"finished");
			var w_ = this.Measurement_Period();
			var x_ = FHIRHelpers_4_3_000.ToInterval(Encounter?.Period);
			var y_ = context.Operators.IntervalIncludesInterval<CqlDateTime>(w_, x_, "day");
			var z_ = context.Operators.And(v_, y_);

			return z_;
		};
		var s_ = context.Operators.WhereOrNull<Encounter>(q_, r_);
		var t_ = context.Operators.ExistsInList<Encounter>(s_);

		return t_;
	}

    [CqlDeclaration("Has Encounter during Measurement Period")]
	public bool? Has_Encounter_during_Measurement_Period() => 
		__Has_Encounter_during_Measurement_Period.Value;

	private Tuples.Tuple_BQRHOWGHNMjBJPPZJZXVMjCPK First_Referral_during_First_10_Months_of_Measurement_Period_Value()
	{
		var a_ = this.Referral();
		var b_ = context.Operators.RetrieveByValueSet<ServiceRequest>(a_, null);
		bool? c_(ServiceRequest ReferralOrder)
		{
			var j_ = context.Operators.Convert<Code<RequestStatus>>(ReferralOrder?.StatusElement?.Value);
			var k_ = context.Operators.Convert<string>(j_);
			var l_ = new string[]
			{
				(string)"active",
				(string)"completed",
			};
			var m_ = context.Operators.InList<string>(k_, (l_ as IEnumerable<string>));
			var n_ = context.Operators.Convert<Code<RequestIntent>>(ReferralOrder?.IntentElement?.Value);
			var o_ = context.Operators.Equal(n_, (string)"order");
			var p_ = context.Operators.And(m_, o_);
			var q_ = context.Operators.Convert<CqlDateTime>(ReferralOrder?.AuthoredOnElement);
			var r_ = this.Measurement_Period();
			var s_ = context.Operators.Start(r_);
			var u_ = context.Operators.Start(r_);
			var v_ = context.Operators.ComponentFrom(u_, "year");
			var w_ = context.Operators.Date(v_, (int?)10, (int?)31);
			var x_ = context.Operators.ConvertDateToDateTime(w_);
			var y_ = context.Operators.Interval(s_, x_, true, true);
			var z_ = context.Operators.ElementInInterval<CqlDateTime>(q_, y_, "day");
			var aa_ = context.Operators.And(p_, z_);

			return aa_;
		};
		var d_ = context.Operators.WhereOrNull<ServiceRequest>(b_, c_);
		Tuples.Tuple_BQRHOWGHNMjBJPPZJZXVMjCPK e_(ServiceRequest ReferralOrder)
		{
			var ab_ = context.Operators.Convert<CqlDateTime>(ReferralOrder?.AuthoredOnElement);
			var ac_ = new Tuples.Tuple_BQRHOWGHNMjBJPPZJZXVMjCPK
			{
				ID = ReferralOrder?.IdElement?.Value,
				AuthorDate = ab_,
			};

			return ac_;
		};
		var f_ = context.Operators.SelectOrNull<ServiceRequest, Tuples.Tuple_BQRHOWGHNMjBJPPZJZXVMjCPK>(d_, e_);
		object g_(Tuples.Tuple_BQRHOWGHNMjBJPPZJZXVMjCPK @this) => 
			@this?.AuthorDate;
		var h_ = context.Operators.ListSortBy<Tuples.Tuple_BQRHOWGHNMjBJPPZJZXVMjCPK>(f_, g_, System.ComponentModel.ListSortDirection.Ascending);
		var i_ = context.Operators.FirstOfList<Tuples.Tuple_BQRHOWGHNMjBJPPZJZXVMjCPK>(h_);

		return i_;
	}

    [CqlDeclaration("First Referral during First 10 Months of Measurement Period")]
	public Tuples.Tuple_BQRHOWGHNMjBJPPZJZXVMjCPK First_Referral_during_First_10_Months_of_Measurement_Period() => 
		__First_Referral_during_First_10_Months_of_Measurement_Period.Value;

	private bool? Initial_Population_Value()
	{
		var a_ = this.Has_Encounter_during_Measurement_Period();
		var b_ = this.First_Referral_during_First_10_Months_of_Measurement_Period();
		var c_ = context.Operators.Not((bool?)(b_ is null));
		var d_ = context.Operators.And(a_, c_);

		return d_;
	}

    [CqlDeclaration("Initial Population")]
	public bool? Initial_Population() => 
		__Initial_Population.Value;

	private bool? Denominator_Value()
	{
		var a_ = this.Initial_Population();

		return a_;
	}

    [CqlDeclaration("Denominator")]
	public bool? Denominator() => 
		__Denominator.Value;

	private Tuples.Tuple_DMgHTLENEHBHWJISQgKZGZVMB SDE_Ethnicity_Value()
	{
		var a_ = SupplementalDataElements_3_4_000.SDE_Ethnicity();

		return a_;
	}

    [CqlDeclaration("SDE Ethnicity")]
	public Tuples.Tuple_DMgHTLENEHBHWJISQgKZGZVMB SDE_Ethnicity() => 
		__SDE_Ethnicity.Value;

	private IEnumerable<Tuples.Tuple_GDKRbfOIHhLGieQSVDEMIaDPX> SDE_Payer_Value()
	{
		var a_ = SupplementalDataElements_3_4_000.SDE_Payer();

		return a_;
	}

    [CqlDeclaration("SDE Payer")]
	public IEnumerable<Tuples.Tuple_GDKRbfOIHhLGieQSVDEMIaDPX> SDE_Payer() => 
		__SDE_Payer.Value;

	private Tuples.Tuple_DMgHTLENEHBHWJISQgKZGZVMB SDE_Race_Value()
	{
		var a_ = SupplementalDataElements_3_4_000.SDE_Race();

		return a_;
	}

    [CqlDeclaration("SDE Race")]
	public Tuples.Tuple_DMgHTLENEHBHWJISQgKZGZVMB SDE_Race() => 
		__SDE_Race.Value;

	private CqlCode SDE_Sex_Value()
	{
		var a_ = SupplementalDataElements_3_4_000.SDE_Sex();

		return a_;
	}

    [CqlDeclaration("SDE Sex")]
	public CqlCode SDE_Sex() => 
		__SDE_Sex.Value;

    [CqlDeclaration("TaskGetRequestID")]
	public IEnumerable<string> TaskGetRequestID(Task task)
	{
		string a_(ResourceReference Task)
		{
			var c_ = QICoreCommon_2_0_000.GetId(Task?.ReferenceElement?.Value);

			return c_;
		};
		var b_ = context.Operators.SelectOrNull<ResourceReference, string>((task?.BasedOn as IEnumerable<ResourceReference>), a_);

		return b_;
	}

	private bool? Referring_Clinician_Receives_Consultant_Report_to_Close_Referral_Loop_Value()
	{
		var a_ = this.Consultant_Report();
		var b_ = context.Operators.RetrieveByValueSet<Task>(a_, null);
		IEnumerable<Task> c_(Task ConsultantReportObtained)
		{
			var f_ = this.First_Referral_during_First_10_Months_of_Measurement_Period();
			var g_ = new Tuples.Tuple_BQRHOWGHNMjBJPPZJZXVMjCPK[]
			{
				f_,
			};
			bool? h_(Tuples.Tuple_BQRHOWGHNMjBJPPZJZXVMjCPK FirstReferral)
			{
				var l_ = this.TaskGetRequestID(ConsultantReportObtained);
				var m_ = context.Operators.InList<string>(FirstReferral?.ID, l_);
				var n_ = FHIRHelpers_4_3_000.ToInterval(ConsultantReportObtained?.ExecutionPeriod);
				var o_ = context.Operators.End(n_);
				var p_ = context.Operators.After(o_, FirstReferral?.AuthorDate, null);
				var q_ = context.Operators.And(m_, p_);
				var r_ = context.Operators.Convert<Code<Task.TaskStatus>>(ConsultantReportObtained?.StatusElement?.Value);
				var s_ = context.Operators.Equal(r_, (string)"completed");
				var t_ = context.Operators.And(q_, s_);
				var v_ = context.Operators.End(n_);
				var w_ = this.Measurement_Period();
				var x_ = context.Operators.ElementInInterval<CqlDateTime>(v_, w_, "day");
				var y_ = context.Operators.And(t_, x_);

				return y_;
			};
			var i_ = context.Operators.WhereOrNull<Tuples.Tuple_BQRHOWGHNMjBJPPZJZXVMjCPK>(g_, h_);
			Task j_(Tuples.Tuple_BQRHOWGHNMjBJPPZJZXVMjCPK FirstReferral) => 
				ConsultantReportObtained;
			var k_ = context.Operators.SelectOrNull<Tuples.Tuple_BQRHOWGHNMjBJPPZJZXVMjCPK, Task>(i_, j_);

			return k_;
		};
		var d_ = context.Operators.SelectManyOrNull<Task, Task>(b_, c_);
		var e_ = context.Operators.ExistsInList<Task>(d_);

		return e_;
	}

    [CqlDeclaration("Referring Clinician Receives Consultant Report to Close Referral Loop")]
	public bool? Referring_Clinician_Receives_Consultant_Report_to_Close_Referral_Loop() => 
		__Referring_Clinician_Receives_Consultant_Report_to_Close_Referral_Loop.Value;

	private bool? Numerator_Value()
	{
		var a_ = this.Referring_Clinician_Receives_Consultant_Report_to_Close_Referral_Loop();

		return a_;
	}

    [CqlDeclaration("Numerator")]
	public bool? Numerator() => 
		__Numerator.Value;

}
