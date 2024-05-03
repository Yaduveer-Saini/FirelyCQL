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
[CqlLibrary("NCQAHealthPlanEnrollment", "1.0.0")]
public class NCQAHealthPlanEnrollment_1_0_0
{


    internal CqlContext context;

    #region Cached values


    #endregion
    public NCQAHealthPlanEnrollment_1_0_0(CqlContext context)
    {
        this.context = context ?? throw new ArgumentNullException("context");

        NCQACQLBase_1_0_0 = new NCQACQLBase_1_0_0(context);
        FHIRHelpers_4_0_001 = new FHIRHelpers_4_0_001(context);
        NCQATerminology_1_0_0 = new NCQATerminology_1_0_0(context);
        NCQAFHIRBase_1_0_0 = new NCQAFHIRBase_1_0_0(context);

    }
    #region Dependencies

    public NCQACQLBase_1_0_0 NCQACQLBase_1_0_0 { get; }
    public FHIRHelpers_4_0_001 FHIRHelpers_4_0_001 { get; }
    public NCQATerminology_1_0_0 NCQATerminology_1_0_0 { get; }
    public NCQAFHIRBase_1_0_0 NCQAFHIRBase_1_0_0 { get; }

    #endregion

    [CqlDeclaration("CoverageIntervals")]
	public IEnumerable<CqlInterval<CqlDate>> CoverageIntervals(IEnumerable<Coverage> Coverage, CqlInterval<CqlDate> participationPeriod)
	{
		CqlInterval<CqlDate> a_(Coverage C)
		{
			var c_ = NCQAFHIRBase_1_0_0.Normalize_Interval((C?.Period as object));
			var d_ = context.Operators.Start(c_);
			var e_ = context.Operators.DateFrom(d_);
			var g_ = context.Operators.End(c_);
			var h_ = context.Operators.DateFrom(g_);
			var i_ = context.Operators.Interval(e_, h_, true, true);
			var j_ = context.Operators.Start(participationPeriod);
			var k_ = context.Operators.End(participationPeriod);
			var l_ = context.Operators.Interval(j_, k_, true, true);
			var m_ = context.Operators.IntervalIntersect<CqlDate>(i_, l_);

			return m_;
		};
		var b_ = context.Operators.Select<Coverage, CqlInterval<CqlDate>>(Coverage, a_);

		return b_;
	}

    [CqlDeclaration("Collapsed Coverage Intervals")]
	public IEnumerable<CqlInterval<CqlDate>> Collapsed_Coverage_Intervals(IEnumerable<CqlInterval<CqlDate>> Intervals)
	{
		var a_ = NCQACQLBase_1_0_0.Collapse_Date_Interval_Workaround(Intervals);

		return a_;
	}

    [CqlDeclaration("Collapsed Coverage Adjacent Intervals")]
	public IEnumerable<CqlInterval<CqlDate>> Collapsed_Coverage_Adjacent_Intervals(IEnumerable<CqlInterval<CqlDate>> Intervals)
	{
		var a_ = context.Operators.CrossJoin<CqlInterval<CqlDate>, CqlInterval<CqlDate>>(Intervals, Intervals);
		Tuple_BaNHUZXcQBUKLNgEDWdDHjYV b_(ValueTuple<CqlInterval<CqlDate>,CqlInterval<CqlDate>> _valueTuple)
		{
			var h_ = new Tuple_BaNHUZXcQBUKLNgEDWdDHjYV
			{
				Coverage1 = _valueTuple.Item1,
				Coverage2 = _valueTuple.Item2,
			};

			return h_;
		};
		var c_ = context.Operators.Select<ValueTuple<CqlInterval<CqlDate>,CqlInterval<CqlDate>>, Tuple_BaNHUZXcQBUKLNgEDWdDHjYV>(a_, b_);
		bool? d_(Tuple_BaNHUZXcQBUKLNgEDWdDHjYV tuple_banhuzxcqbuklngedwddhjyv)
		{
			var i_ = context.Operators.End(tuple_banhuzxcqbuklngedwddhjyv.Coverage1);
			var j_ = context.Operators.Start(tuple_banhuzxcqbuklngedwddhjyv.Coverage2);
			var k_ = context.Operators.Quantity(1m, "day");
			var l_ = context.Operators.Subtract(j_, k_);
			var o_ = context.Operators.Add(j_, k_);
			var p_ = context.Operators.Interval(l_, o_, true, true);
			var q_ = context.Operators.In<CqlDate>(i_, p_, null);
			var s_ = context.Operators.Not((bool?)(j_ is null));
			var t_ = context.Operators.And(q_, s_);

			return t_;
		};
		var e_ = context.Operators.Where<Tuple_BaNHUZXcQBUKLNgEDWdDHjYV>(c_, d_);
		CqlInterval<CqlDate> f_(Tuple_BaNHUZXcQBUKLNgEDWdDHjYV tuple_banhuzxcqbuklngedwddhjyv)
		{
			var u_ = context.Operators.Start(tuple_banhuzxcqbuklngedwddhjyv.Coverage1);
			var v_ = context.Operators.End(tuple_banhuzxcqbuklngedwddhjyv.Coverage2);
			var w_ = context.Operators.Interval(u_, v_, true, true);

			return w_;
		};
		var g_ = context.Operators.Select<Tuple_BaNHUZXcQBUKLNgEDWdDHjYV, CqlInterval<CqlDate>>(e_, f_);

		return g_;
	}

    [CqlDeclaration("Collapsed Final Coverage Intervals")]
	public IEnumerable<CqlInterval<CqlDate>> Collapsed_Final_Coverage_Intervals(IEnumerable<CqlInterval<CqlDate>> collapsedI, IEnumerable<CqlInterval<CqlDate>> adjacentI)
	{
		var a_ = this.Collapsed_Coverage_Intervals(collapsedI);
		var b_ = this.Collapsed_Coverage_Adjacent_Intervals(adjacentI);
		var c_ = context.Operators.ListUnion<CqlInterval<CqlDate>>(a_, b_);
		var d_ = NCQACQLBase_1_0_0.Collapse_Date_Interval_Workaround(c_);

		return d_;
	}

    [CqlDeclaration("All Coverage Info")]
	public IEnumerable<Tuple_CBVceKWDGQcVXVifMgKSFFCNV> All_Coverage_Info(IEnumerable<Coverage> Coverage, CqlInterval<CqlDate> participationPeriod)
	{
		Tuple_CBVceKWDGQcVXVifMgKSFFCNV a_(Coverage C)
		{
			var c_ = this.CoverageIntervals(Coverage, participationPeriod);
			var e_ = this.Collapsed_Coverage_Intervals(c_);
			var g_ = this.Collapsed_Coverage_Intervals(c_);
			var h_ = this.Collapsed_Coverage_Adjacent_Intervals(g_);
			var j_ = this.Collapsed_Coverage_Intervals(c_);
			var l_ = this.Collapsed_Coverage_Intervals(c_);
			var m_ = this.Collapsed_Coverage_Adjacent_Intervals(l_);
			var n_ = this.Collapsed_Final_Coverage_Intervals(j_, m_);
			var o_ = new Tuple_CBVceKWDGQcVXVifMgKSFFCNV
			{
				IntervalInfo = c_,
				Collapsed = e_,
				Adjacent = h_,
				CollapsedFinal = n_,
			};

			return o_;
		};
		var b_ = context.Operators.Select<Coverage, Tuple_CBVceKWDGQcVXVifMgKSFFCNV>(Coverage, a_);

		return b_;
	}

    [CqlDeclaration("Health Plan Coverage Resources")]
	public IEnumerable<Coverage> Health_Plan_Coverage_Resources(IEnumerable<Coverage> Coverage)
	{
		bool? a_(Coverage C)
		{
			bool? e_(Coding cTypeCoding)
			{
				var h_ = FHIRHelpers_4_0_001.ToCode(cTypeCoding);
				var i_ = NCQATerminology_1_0_0.managed_care_policy();
				var j_ = context.Operators.Equivalent(h_, i_);
				var l_ = NCQATerminology_1_0_0.retiree_health_program();
				var m_ = context.Operators.Equivalent(h_, l_);
				var n_ = context.Operators.Or(j_, m_);
				var p_ = NCQATerminology_1_0_0.subsidized_health_program();
				var q_ = context.Operators.Equivalent(h_, p_);
				var r_ = context.Operators.Or(n_, q_);

				return r_;
			};
			var f_ = context.Operators.Where<Coding>((IEnumerable<Coding>)C?.Type?.Coding, e_);
			var g_ = context.Operators.Exists<Coding>(f_);

			return g_;
		};
		var b_ = context.Operators.Where<Coverage>(Coverage, a_);
		bool? c_(Coverage HPCoverageResource)
		{
			var s_ = context.Operators.Not((bool?)(HPCoverageResource is null));

			return s_;
		};
		var d_ = context.Operators.Where<Coverage>(b_, c_);

		return d_;
	}

    [CqlDeclaration("Anchor Date Criteria")]
	public bool? Anchor_Date_Criteria(IEnumerable<Coverage> Coverage, CqlDate AnchorDate, CqlInterval<CqlDate> participationPeriod)
	{
		bool? a_()
		{
			bool b_()
			{
				var c_ = context.Operators.In<CqlDate>(AnchorDate, participationPeriod, null);
				var d_ = context.Operators.Not(c_);

				return (d_ ?? false);
			};
			if ((context.Operators.In<CqlDate>(AnchorDate, participationPeriod, null) ?? false))
			{
				var e_ = this.All_Coverage_Info(Coverage, participationPeriod);
				bool? f_(Tuple_CBVceKWDGQcVXVifMgKSFFCNV @this)
				{
					var n_ = context.Operators.Not((bool?)(@this?.CollapsedFinal is null));

					return n_;
				};
				var g_ = context.Operators.Where<Tuple_CBVceKWDGQcVXVifMgKSFFCNV>(e_, f_);
				IEnumerable<CqlInterval<CqlDate>> h_(Tuple_CBVceKWDGQcVXVifMgKSFFCNV @this) => 
					@this?.CollapsedFinal;
				var i_ = context.Operators.Select<Tuple_CBVceKWDGQcVXVifMgKSFFCNV, IEnumerable<CqlInterval<CqlDate>>>(g_, h_);
				var j_ = context.Operators.Flatten<CqlInterval<CqlDate>>(i_);
				bool? k_(CqlInterval<CqlDate> FinalInterval)
				{
					var o_ = context.Operators.In<CqlDate>(AnchorDate, FinalInterval, null);

					return o_;
				};
				var l_ = context.Operators.Where<CqlInterval<CqlDate>>(j_, k_);
				var m_ = context.Operators.Exists<CqlInterval<CqlDate>>(l_);

				return m_;
			}
			else if (b_())
			{
				bool? p_(Coverage @this)
				{
					var w_ = context.Operators.Not((bool?)(@this?.Period is null));

					return w_;
				};
				var q_ = context.Operators.Where<Coverage>(Coverage, p_);
				Period r_(Coverage @this) => 
					@this?.Period;
				var s_ = context.Operators.Select<Coverage, Period>(q_, r_);
				bool? t_(Period Cperiod)
				{
					var x_ = NCQAFHIRBase_1_0_0.Normalize_Interval((Cperiod as object));
					var y_ = context.Operators.Start(x_);
					var z_ = context.Operators.DateFrom(y_);
					var ab_ = context.Operators.End(x_);
					var ac_ = context.Operators.DateFrom(ab_);
					var ad_ = context.Operators.Interval(z_, ac_, true, true);
					var ae_ = context.Operators.In<CqlDate>(AnchorDate, ad_, null);

					return ae_;
				};
				var u_ = context.Operators.Where<Period>(s_, t_);
				var v_ = context.Operators.Exists<Period>(u_);

				return v_;
			}
			else if ((AnchorDate is null))
			{
				return true;
			}
			else
			{
				return false;
			};
		};

		return a_();
	}

    [CqlDeclaration("Health Plan Enrollment Criteria")]
	public bool? Health_Plan_Enrollment_Criteria(IEnumerable<Coverage> Coverage, CqlDate AnchorDate, CqlInterval<CqlDate> participationPeriod, int? AllowedGapDays)
	{
		var a_ = this.Health_Plan_Coverage_Resources(Coverage);
		var b_ = this.All_Coverage_Info(a_, participationPeriod);
		bool? c_(Tuple_CBVceKWDGQcVXVifMgKSFFCNV @this)
		{
			var m_ = context.Operators.Not((bool?)(@this?.CollapsedFinal is null));

			return m_;
		};
		var d_ = context.Operators.Where<Tuple_CBVceKWDGQcVXVifMgKSFFCNV>(b_, c_);
		IEnumerable<CqlInterval<CqlDate>> e_(Tuple_CBVceKWDGQcVXVifMgKSFFCNV @this) => 
			@this?.CollapsedFinal;
		var f_ = context.Operators.Select<Tuple_CBVceKWDGQcVXVifMgKSFFCNV, IEnumerable<CqlInterval<CqlDate>>>(d_, e_);
		var g_ = context.Operators.Flatten<CqlInterval<CqlDate>>(f_);
		var h_ = NCQACQLBase_1_0_0.Date_Interval_Gaps_Relative_to_Base_Interval_Stats(participationPeriod, g_);
		var i_ = new Tuple_EKheTMICVWAQgjLNCMeFLGUGF[]
		{
			h_,
		};
		bool? j_(Tuple_EKheTMICVWAQgjLNCMeFLGUGF GapsInEnrollment)
		{
			var n_ = context.Operators.LessOrEqual(GapsInEnrollment?.Interval_Count, 1);
			var o_ = context.Operators.LessOrEqual(GapsInEnrollment?.Total_Days_In_Longest_Interval, AllowedGapDays);
			var p_ = context.Operators.And(n_, o_);
			var q_ = this.Anchor_Date_Criteria(Coverage, AnchorDate, participationPeriod);
			var r_ = context.Operators.And(p_, q_);

			return r_;
		};
		var k_ = context.Operators.Select<Tuple_EKheTMICVWAQgjLNCMeFLGUGF, bool?>((IEnumerable<Tuple_EKheTMICVWAQgjLNCMeFLGUGF>)i_, j_);
		var l_ = context.Operators.SingletonFrom<bool?>(k_);

		return l_;
	}

    [CqlDeclaration("Pharmacy Benefit Coverage Resources")]
	public IEnumerable<Coverage> Pharmacy_Benefit_Coverage_Resources(IEnumerable<Coverage> Coverage)
	{
		bool? a_(Coverage C)
		{
			bool? e_(Coding cTypeCoding)
			{
				var h_ = FHIRHelpers_4_0_001.ToCode(cTypeCoding);
				var i_ = NCQATerminology_1_0_0.drug_policy();
				var j_ = context.Operators.Equivalent(h_, i_);

				return j_;
			};
			var f_ = context.Operators.Where<Coding>((IEnumerable<Coding>)C?.Type?.Coding, e_);
			var g_ = context.Operators.Exists<Coding>(f_);

			return g_;
		};
		var b_ = context.Operators.Where<Coverage>(Coverage, a_);
		bool? c_(Coverage pharmacyCoverageResource)
		{
			var k_ = context.Operators.Not((bool?)(pharmacyCoverageResource is null));

			return k_;
		};
		var d_ = context.Operators.Where<Coverage>(b_, c_);

		return d_;
	}

    [CqlDeclaration("Pharmacy Benefit Enrollment Criteria")]
	public bool? Pharmacy_Benefit_Enrollment_Criteria(IEnumerable<Coverage> PharmCoverage, CqlDate AnchorDate, CqlInterval<CqlDate> participationPeriod, int? AllowedGapDays)
	{
		var a_ = this.Pharmacy_Benefit_Coverage_Resources(PharmCoverage);
		var b_ = this.All_Coverage_Info(a_, participationPeriod);
		bool? c_(Tuple_CBVceKWDGQcVXVifMgKSFFCNV @this)
		{
			var m_ = context.Operators.Not((bool?)(@this?.CollapsedFinal is null));

			return m_;
		};
		var d_ = context.Operators.Where<Tuple_CBVceKWDGQcVXVifMgKSFFCNV>(b_, c_);
		IEnumerable<CqlInterval<CqlDate>> e_(Tuple_CBVceKWDGQcVXVifMgKSFFCNV @this) => 
			@this?.CollapsedFinal;
		var f_ = context.Operators.Select<Tuple_CBVceKWDGQcVXVifMgKSFFCNV, IEnumerable<CqlInterval<CqlDate>>>(d_, e_);
		var g_ = context.Operators.Flatten<CqlInterval<CqlDate>>(f_);
		var h_ = NCQACQLBase_1_0_0.Date_Interval_Gaps_Relative_to_Base_Interval_Stats(participationPeriod, g_);
		var i_ = new Tuple_EKheTMICVWAQgjLNCMeFLGUGF[]
		{
			h_,
		};
		bool? j_(Tuple_EKheTMICVWAQgjLNCMeFLGUGF GapsInEnrollment)
		{
			var n_ = context.Operators.LessOrEqual(GapsInEnrollment?.Interval_Count, 1);
			var o_ = context.Operators.LessOrEqual(GapsInEnrollment?.Total_Days_In_Longest_Interval, AllowedGapDays);
			var p_ = context.Operators.And(n_, o_);
			var q_ = this.Anchor_Date_Criteria(PharmCoverage, AnchorDate, participationPeriod);
			var r_ = context.Operators.And(p_, q_);

			return r_;
		};
		var k_ = context.Operators.Select<Tuple_EKheTMICVWAQgjLNCMeFLGUGF, bool?>((IEnumerable<Tuple_EKheTMICVWAQgjLNCMeFLGUGF>)i_, j_);
		var l_ = context.Operators.SingletonFrom<bool?>(k_);

		return l_;
	}

    [CqlDeclaration("Mental Health Benefit Coverage Resources")]
	public IEnumerable<Coverage> Mental_Health_Benefit_Coverage_Resources(IEnumerable<Coverage> Coverage)
	{
		bool? a_(Coverage C)
		{
			bool? e_(Coding cTypeCoding)
			{
				var h_ = FHIRHelpers_4_0_001.ToCode(cTypeCoding);
				var i_ = NCQATerminology_1_0_0.mental_health_policy();
				var j_ = context.Operators.Equivalent(h_, i_);

				return j_;
			};
			var f_ = context.Operators.Where<Coding>((IEnumerable<Coding>)C?.Type?.Coding, e_);
			var g_ = context.Operators.Exists<Coding>(f_);

			return g_;
		};
		var b_ = context.Operators.Where<Coverage>(Coverage, a_);
		bool? c_(Coverage mentalHealthCoverageResource)
		{
			var k_ = context.Operators.Not((bool?)(mentalHealthCoverageResource is null));

			return k_;
		};
		var d_ = context.Operators.Where<Coverage>(b_, c_);

		return d_;
	}

    [CqlDeclaration("Mental Health Benefit Enrollment Criteria")]
	public bool? Mental_Health_Benefit_Enrollment_Criteria(IEnumerable<Coverage> MHCoverage, CqlDate AnchorDate, CqlInterval<CqlDate> participationPeriod, int? AllowedGapDays)
	{
		var a_ = this.Mental_Health_Benefit_Coverage_Resources(MHCoverage);
		var b_ = this.All_Coverage_Info(a_, participationPeriod);
		bool? c_(Tuple_CBVceKWDGQcVXVifMgKSFFCNV @this)
		{
			var m_ = context.Operators.Not((bool?)(@this?.CollapsedFinal is null));

			return m_;
		};
		var d_ = context.Operators.Where<Tuple_CBVceKWDGQcVXVifMgKSFFCNV>(b_, c_);
		IEnumerable<CqlInterval<CqlDate>> e_(Tuple_CBVceKWDGQcVXVifMgKSFFCNV @this) => 
			@this?.CollapsedFinal;
		var f_ = context.Operators.Select<Tuple_CBVceKWDGQcVXVifMgKSFFCNV, IEnumerable<CqlInterval<CqlDate>>>(d_, e_);
		var g_ = context.Operators.Flatten<CqlInterval<CqlDate>>(f_);
		var h_ = NCQACQLBase_1_0_0.Date_Interval_Gaps_Relative_to_Base_Interval_Stats(participationPeriod, g_);
		var i_ = new Tuple_EKheTMICVWAQgjLNCMeFLGUGF[]
		{
			h_,
		};
		bool? j_(Tuple_EKheTMICVWAQgjLNCMeFLGUGF GapsInEnrollment)
		{
			var n_ = context.Operators.LessOrEqual(GapsInEnrollment?.Interval_Count, 1);
			var o_ = context.Operators.LessOrEqual(GapsInEnrollment?.Total_Days_In_Longest_Interval, AllowedGapDays);
			var p_ = context.Operators.And(n_, o_);
			var q_ = this.Anchor_Date_Criteria(MHCoverage, AnchorDate, participationPeriod);
			var r_ = context.Operators.And(p_, q_);

			return r_;
		};
		var k_ = context.Operators.Select<Tuple_EKheTMICVWAQgjLNCMeFLGUGF, bool?>((IEnumerable<Tuple_EKheTMICVWAQgjLNCMeFLGUGF>)i_, j_);
		var l_ = context.Operators.SingletonFrom<bool?>(k_);

		return l_;
	}

}
