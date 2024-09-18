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
public static partial class CumulativeMedicationDurationFHIR4_1_0_000ServiceCollectionExtensions
{
    public static IServiceCollection AddCumulativeMedicationDurationFHIR4_1_0_000(this IServiceCollection services)
    {
        services.TryAddSingleton<CumulativeMedicationDurationFHIR4_1_0_000>();
        services.AddFHIRHelpers_4_0_001();
        return services;
    }
}

[System.CodeDom.Compiler.GeneratedCode(".NET Code Generation", "2.0.3.0")]
[CqlLibrary("CumulativeMedicationDurationFHIR4", "1.0.000")]
public partial class CumulativeMedicationDurationFHIR4_1_0_000(
    FHIRHelpers_4_0_001 fhirHelpers_4_0_001)
{

    [CqlDeclaration("AC")]
	public  CqlCode AC(CqlContext context) => 
		new CqlCode("AC", "http://terminology.hl7.org/CodeSystem/v3-TimingEvent", default, default);

    [CqlDeclaration("ACD")]
	public  CqlCode ACD(CqlContext context) => 
		new CqlCode("ACD", "http://terminology.hl7.org/CodeSystem/v3-TimingEvent", default, default);

    [CqlDeclaration("ACM")]
	public  CqlCode ACM(CqlContext context) => 
		new CqlCode("ACM", "http://terminology.hl7.org/CodeSystem/v3-TimingEvent", default, default);

    [CqlDeclaration("ACV")]
	public  CqlCode ACV(CqlContext context) => 
		new CqlCode("ACV", "http://terminology.hl7.org/CodeSystem/v3-TimingEvent", default, default);

    [CqlDeclaration("AFT")]
	public  CqlCode AFT(CqlContext context) => 
		new CqlCode("AFT", "http://hl7.org/fhir/event-timing", default, default);

    [CqlDeclaration("AFT.early")]
	public  CqlCode AFT_early(CqlContext context) => 
		new CqlCode("AFT.early", "http://hl7.org/fhir/event-timing", default, default);

    [CqlDeclaration("AFT.late")]
	public  CqlCode AFT_late(CqlContext context) => 
		new CqlCode("AFT.late", "http://hl7.org/fhir/event-timing", default, default);

    [CqlDeclaration("C")]
	public  CqlCode C(CqlContext context) => 
		new CqlCode("C", "http://terminology.hl7.org/CodeSystem/v3-TimingEvent", default, default);

    [CqlDeclaration("CD")]
	public  CqlCode CD(CqlContext context) => 
		new CqlCode("CD", "http://terminology.hl7.org/CodeSystem/v3-TimingEvent", default, default);

    [CqlDeclaration("CM")]
	public  CqlCode CM(CqlContext context) => 
		new CqlCode("CM", "http://terminology.hl7.org/CodeSystem/v3-TimingEvent", default, default);

    [CqlDeclaration("CV")]
	public  CqlCode CV(CqlContext context) => 
		new CqlCode("CV", "http://terminology.hl7.org/CodeSystem/v3-TimingEvent", default, default);

    [CqlDeclaration("EVE")]
	public  CqlCode EVE(CqlContext context) => 
		new CqlCode("EVE", "http://hl7.org/fhir/event-timing", default, default);

    [CqlDeclaration("EVE.early")]
	public  CqlCode EVE_early(CqlContext context) => 
		new CqlCode("EVE.early", "http://hl7.org/fhir/event-timing", default, default);

    [CqlDeclaration("EVE.late")]
	public  CqlCode EVE_late(CqlContext context) => 
		new CqlCode("EVE.late", "http://hl7.org/fhir/event-timing", default, default);

    [CqlDeclaration("HS")]
	public  CqlCode HS(CqlContext context) => 
		new CqlCode("HS", "http://terminology.hl7.org/CodeSystem/v3-TimingEvent", default, default);

    [CqlDeclaration("MORN")]
	public  CqlCode MORN(CqlContext context) => 
		new CqlCode("MORN", "http://hl7.org/fhir/event-timing", default, default);

    [CqlDeclaration("MORN.early")]
	public  CqlCode MORN_early(CqlContext context) => 
		new CqlCode("MORN.early", "http://hl7.org/fhir/event-timing", default, default);

    [CqlDeclaration("MORN.late")]
	public  CqlCode MORN_late(CqlContext context) => 
		new CqlCode("MORN.late", "http://hl7.org/fhir/event-timing", default, default);

    [CqlDeclaration("NIGHT")]
	public  CqlCode NIGHT(CqlContext context) => 
		new CqlCode("NIGHT", "http://hl7.org/fhir/event-timing", default, default);

    [CqlDeclaration("NOON")]
	public  CqlCode NOON(CqlContext context) => 
		new CqlCode("NOON", "http://hl7.org/fhir/event-timing", default, default);

    [CqlDeclaration("PC")]
	public  CqlCode PC(CqlContext context) => 
		new CqlCode("PC", "http://terminology.hl7.org/CodeSystem/v3-TimingEvent", default, default);

    [CqlDeclaration("PCD")]
	public  CqlCode PCD(CqlContext context) => 
		new CqlCode("PCD", "http://terminology.hl7.org/CodeSystem/v3-TimingEvent", default, default);

    [CqlDeclaration("PCM")]
	public  CqlCode PCM(CqlContext context) => 
		new CqlCode("PCM", "http://terminology.hl7.org/CodeSystem/v3-TimingEvent", default, default);

    [CqlDeclaration("PCV")]
	public  CqlCode PCV(CqlContext context) => 
		new CqlCode("PCV", "http://terminology.hl7.org/CodeSystem/v3-TimingEvent", default, default);

    [CqlDeclaration("PHS")]
	public  CqlCode PHS(CqlContext context) => 
		new CqlCode("PHS", "http://hl7.org/fhir/event-timing", default, default);

    [CqlDeclaration("WAKE")]
	public  CqlCode WAKE(CqlContext context) => 
		new CqlCode("WAKE", "http://terminology.hl7.org/CodeSystem/v3-TimingEvent", default, default);

    [CqlDeclaration("V3TimingEvent")]
	public  CqlCode[] V3TimingEvent(CqlContext context)
	{
		CqlCode[] a_ = [
			new CqlCode("AC", "http://terminology.hl7.org/CodeSystem/v3-TimingEvent", default, default),
			new CqlCode("ACD", "http://terminology.hl7.org/CodeSystem/v3-TimingEvent", default, default),
			new CqlCode("ACM", "http://terminology.hl7.org/CodeSystem/v3-TimingEvent", default, default),
			new CqlCode("ACV", "http://terminology.hl7.org/CodeSystem/v3-TimingEvent", default, default),
			new CqlCode("C", "http://terminology.hl7.org/CodeSystem/v3-TimingEvent", default, default),
			new CqlCode("CD", "http://terminology.hl7.org/CodeSystem/v3-TimingEvent", default, default),
			new CqlCode("CM", "http://terminology.hl7.org/CodeSystem/v3-TimingEvent", default, default),
			new CqlCode("CV", "http://terminology.hl7.org/CodeSystem/v3-TimingEvent", default, default),
			new CqlCode("HS", "http://terminology.hl7.org/CodeSystem/v3-TimingEvent", default, default),
			new CqlCode("PC", "http://terminology.hl7.org/CodeSystem/v3-TimingEvent", default, default),
			new CqlCode("PCD", "http://terminology.hl7.org/CodeSystem/v3-TimingEvent", default, default),
			new CqlCode("PCM", "http://terminology.hl7.org/CodeSystem/v3-TimingEvent", default, default),
			new CqlCode("PCV", "http://terminology.hl7.org/CodeSystem/v3-TimingEvent", default, default),
			new CqlCode("WAKE", "http://terminology.hl7.org/CodeSystem/v3-TimingEvent", default, default),
		];

		return a_;
	}

    [CqlDeclaration("EventTiming")]
	public  CqlCode[] EventTiming(CqlContext context)
	{
		CqlCode[] a_ = [
			new CqlCode("AFT", "http://hl7.org/fhir/event-timing", default, default),
			new CqlCode("AFT.early", "http://hl7.org/fhir/event-timing", default, default),
			new CqlCode("AFT.late", "http://hl7.org/fhir/event-timing", default, default),
			new CqlCode("EVE", "http://hl7.org/fhir/event-timing", default, default),
			new CqlCode("EVE.early", "http://hl7.org/fhir/event-timing", default, default),
			new CqlCode("EVE.late", "http://hl7.org/fhir/event-timing", default, default),
			new CqlCode("MORN", "http://hl7.org/fhir/event-timing", default, default),
			new CqlCode("MORN.early", "http://hl7.org/fhir/event-timing", default, default),
			new CqlCode("MORN.late", "http://hl7.org/fhir/event-timing", default, default),
			new CqlCode("NIGHT", "http://hl7.org/fhir/event-timing", default, default),
			new CqlCode("NOON", "http://hl7.org/fhir/event-timing", default, default),
			new CqlCode("PHS", "http://hl7.org/fhir/event-timing", default, default),
		];

		return a_;
	}

    [CqlDeclaration("ErrorLevel")]
	public  string ErrorLevel(CqlContext context)
	{
		object a_ = context.ResolveParameter("CumulativeMedicationDurationFHIR4-1.0.000", "ErrorLevel", "Warning");

		return (string)a_;
	}

    [CqlDeclaration("Patient")]
	public  Patient Patient(CqlContext context)
	{
		IEnumerable<Patient> a_ = context.Operators.RetrieveByValueSet<Patient>(default, default);
		Patient b_ = context.Operators.SingletonFrom<Patient>(a_);

		return b_;
	}

    [CqlDeclaration("ToDaily")]
	public  decimal? ToDaily(CqlContext context, int? frequency, CqlQuantity period)
	{
		decimal? a_()
		{
			bool b_()
			{
				string w_ = period?.unit;
				bool? x_ = context.Operators.Equal(w_, "h");

				return x_ ?? false;
			};
			bool c_()
			{
				string y_ = period?.unit;
				bool? z_ = context.Operators.Equal(y_, "min");

				return z_ ?? false;
			};
			bool d_()
			{
				string aa_ = period?.unit;
				bool? ab_ = context.Operators.Equal(aa_, "s");

				return ab_ ?? false;
			};
			bool e_()
			{
				string ac_ = period?.unit;
				bool? ad_ = context.Operators.Equal(ac_, "d");

				return ad_ ?? false;
			};
			bool f_()
			{
				string ae_ = period?.unit;
				bool? af_ = context.Operators.Equal(ae_, "wk");

				return af_ ?? false;
			};
			bool g_()
			{
				string ag_ = period?.unit;
				bool? ah_ = context.Operators.Equal(ag_, "mo");

				return ah_ ?? false;
			};
			bool h_()
			{
				string ai_ = period?.unit;
				bool? aj_ = context.Operators.Equal(ai_, "a");

				return aj_ ?? false;
			};
			bool i_()
			{
				string ak_ = period?.unit;
				bool? al_ = context.Operators.Equal(ak_, "hour");

				return al_ ?? false;
			};
			bool j_()
			{
				string am_ = period?.unit;
				bool? an_ = context.Operators.Equal(am_, "minute");

				return an_ ?? false;
			};
			bool k_()
			{
				string ao_ = period?.unit;
				bool? ap_ = context.Operators.Equal(ao_, "second");

				return ap_ ?? false;
			};
			bool l_()
			{
				string aq_ = period?.unit;
				bool? ar_ = context.Operators.Equal(aq_, "day");

				return ar_ ?? false;
			};
			bool m_()
			{
				string as_ = period?.unit;
				bool? at_ = context.Operators.Equal(as_, "week");

				return at_ ?? false;
			};
			bool n_()
			{
				string au_ = period?.unit;
				bool? av_ = context.Operators.Equal(au_, "month");

				return av_ ?? false;
			};
			bool o_()
			{
				string aw_ = period?.unit;
				bool? ax_ = context.Operators.Equal(aw_, "year");

				return ax_ ?? false;
			};
			bool p_()
			{
				string ay_ = period?.unit;
				bool? az_ = context.Operators.Equal(ay_, "hours");

				return az_ ?? false;
			};
			bool q_()
			{
				string ba_ = period?.unit;
				bool? bb_ = context.Operators.Equal(ba_, "minutes");

				return bb_ ?? false;
			};
			bool r_()
			{
				string bc_ = period?.unit;
				bool? bd_ = context.Operators.Equal(bc_, "seconds");

				return bd_ ?? false;
			};
			bool s_()
			{
				string be_ = period?.unit;
				bool? bf_ = context.Operators.Equal(be_, "days");

				return bf_ ?? false;
			};
			bool t_()
			{
				string bg_ = period?.unit;
				bool? bh_ = context.Operators.Equal(bg_, "weeks");

				return bh_ ?? false;
			};
			bool u_()
			{
				string bi_ = period?.unit;
				bool? bj_ = context.Operators.Equal(bi_, "months");

				return bj_ ?? false;
			};
			bool v_()
			{
				string bk_ = period?.unit;
				bool? bl_ = context.Operators.Equal(bk_, "years");

				return bl_ ?? false;
			};
			if (b_())
			{
				decimal? bm_ = context.Operators.ConvertIntegerToDecimal(frequency);
				decimal? bn_ = period?.value;
				decimal? bo_ = context.Operators.Divide(24.0m, bn_);
				decimal? bp_ = context.Operators.Multiply(bm_, bo_);

				return bp_;
			}
			else if (c_())
			{
				decimal? bq_ = context.Operators.ConvertIntegerToDecimal(frequency);
				decimal? br_ = period?.value;
				decimal? bs_ = context.Operators.Divide(24.0m, br_);
				decimal? bt_ = context.Operators.Multiply(bq_, bs_);
				decimal? bu_ = context.Operators.ConvertIntegerToDecimal(60);
				decimal? bv_ = context.Operators.Multiply(bt_, bu_);

				return bv_;
			}
			else if (d_())
			{
				decimal? bw_ = context.Operators.ConvertIntegerToDecimal(frequency);
				decimal? bx_ = period?.value;
				decimal? by_ = context.Operators.Divide(24.0m, bx_);
				decimal? bz_ = context.Operators.Multiply(bw_, by_);
				decimal? ca_ = context.Operators.ConvertIntegerToDecimal(60);
				decimal? cb_ = context.Operators.Multiply(bz_, ca_);
				decimal? cd_ = context.Operators.Multiply(cb_, ca_);

				return cd_;
			}
			else if (e_())
			{
				decimal? ce_ = context.Operators.ConvertIntegerToDecimal(frequency);
				decimal? cf_ = period?.value;
				decimal? cg_ = context.Operators.Divide(24.0m, cf_);
				decimal? ch_ = context.Operators.Multiply(ce_, cg_);
				decimal? ci_ = context.Operators.ConvertIntegerToDecimal(24);
				decimal? cj_ = context.Operators.Divide(ch_, ci_);

				return cj_;
			}
			else if (f_())
			{
				decimal? ck_ = context.Operators.ConvertIntegerToDecimal(frequency);
				decimal? cl_ = period?.value;
				decimal? cm_ = context.Operators.Divide(24.0m, cl_);
				decimal? cn_ = context.Operators.Multiply(ck_, cm_);
				int? co_ = context.Operators.Multiply(24, 7);
				decimal? cp_ = context.Operators.ConvertIntegerToDecimal(co_);
				decimal? cq_ = context.Operators.Divide(cn_, cp_);

				return cq_;
			}
			else if (g_())
			{
				decimal? cr_ = context.Operators.ConvertIntegerToDecimal(frequency);
				decimal? cs_ = period?.value;
				decimal? ct_ = context.Operators.Divide(24.0m, cs_);
				decimal? cu_ = context.Operators.Multiply(cr_, ct_);
				int? cv_ = context.Operators.Multiply(24, 30);
				decimal? cw_ = context.Operators.ConvertIntegerToDecimal(cv_);
				decimal? cx_ = context.Operators.Divide(cu_, cw_);

				return cx_;
			}
			else if (h_())
			{
				decimal? cy_ = context.Operators.ConvertIntegerToDecimal(frequency);
				decimal? cz_ = period?.value;
				decimal? da_ = context.Operators.Divide(24.0m, cz_);
				decimal? db_ = context.Operators.Multiply(cy_, da_);
				int? dc_ = context.Operators.Multiply(24, 365);
				decimal? dd_ = context.Operators.ConvertIntegerToDecimal(dc_);
				decimal? de_ = context.Operators.Divide(db_, dd_);

				return de_;
			}
			else if (i_())
			{
				decimal? df_ = context.Operators.ConvertIntegerToDecimal(frequency);
				decimal? dg_ = period?.value;
				decimal? dh_ = context.Operators.Divide(24.0m, dg_);
				decimal? di_ = context.Operators.Multiply(df_, dh_);

				return di_;
			}
			else if (j_())
			{
				decimal? dj_ = context.Operators.ConvertIntegerToDecimal(frequency);
				decimal? dk_ = period?.value;
				decimal? dl_ = context.Operators.Divide(24.0m, dk_);
				decimal? dm_ = context.Operators.Multiply(dj_, dl_);
				decimal? dn_ = context.Operators.ConvertIntegerToDecimal(60);
				decimal? do_ = context.Operators.Multiply(dm_, dn_);

				return do_;
			}
			else if (k_())
			{
				decimal? dp_ = context.Operators.ConvertIntegerToDecimal(frequency);
				decimal? dq_ = period?.value;
				decimal? dr_ = context.Operators.Divide(24.0m, dq_);
				decimal? ds_ = context.Operators.Multiply(dp_, dr_);
				decimal? dt_ = context.Operators.ConvertIntegerToDecimal(60);
				decimal? du_ = context.Operators.Multiply(ds_, dt_);
				decimal? dw_ = context.Operators.Multiply(du_, dt_);

				return dw_;
			}
			else if (l_())
			{
				decimal? dx_ = context.Operators.ConvertIntegerToDecimal(frequency);
				decimal? dy_ = period?.value;
				decimal? dz_ = context.Operators.Divide(24.0m, dy_);
				decimal? ea_ = context.Operators.Multiply(dx_, dz_);
				decimal? eb_ = context.Operators.ConvertIntegerToDecimal(24);
				decimal? ec_ = context.Operators.Divide(ea_, eb_);

				return ec_;
			}
			else if (m_())
			{
				decimal? ed_ = context.Operators.ConvertIntegerToDecimal(frequency);
				decimal? ee_ = period?.value;
				decimal? ef_ = context.Operators.Divide(24.0m, ee_);
				decimal? eg_ = context.Operators.Multiply(ed_, ef_);
				int? eh_ = context.Operators.Multiply(24, 7);
				decimal? ei_ = context.Operators.ConvertIntegerToDecimal(eh_);
				decimal? ej_ = context.Operators.Divide(eg_, ei_);

				return ej_;
			}
			else if (n_())
			{
				decimal? ek_ = context.Operators.ConvertIntegerToDecimal(frequency);
				decimal? el_ = period?.value;
				decimal? em_ = context.Operators.Divide(24.0m, el_);
				decimal? en_ = context.Operators.Multiply(ek_, em_);
				int? eo_ = context.Operators.Multiply(24, 30);
				decimal? ep_ = context.Operators.ConvertIntegerToDecimal(eo_);
				decimal? eq_ = context.Operators.Divide(en_, ep_);

				return eq_;
			}
			else if (o_())
			{
				decimal? er_ = context.Operators.ConvertIntegerToDecimal(frequency);
				decimal? es_ = period?.value;
				decimal? et_ = context.Operators.Divide(24.0m, es_);
				decimal? eu_ = context.Operators.Multiply(er_, et_);
				int? ev_ = context.Operators.Multiply(24, 365);
				decimal? ew_ = context.Operators.ConvertIntegerToDecimal(ev_);
				decimal? ex_ = context.Operators.Divide(eu_, ew_);

				return ex_;
			}
			else if (p_())
			{
				decimal? ey_ = context.Operators.ConvertIntegerToDecimal(frequency);
				decimal? ez_ = period?.value;
				decimal? fa_ = context.Operators.Divide(24.0m, ez_);
				decimal? fb_ = context.Operators.Multiply(ey_, fa_);

				return fb_;
			}
			else if (q_())
			{
				decimal? fc_ = context.Operators.ConvertIntegerToDecimal(frequency);
				decimal? fd_ = period?.value;
				decimal? fe_ = context.Operators.Divide(24.0m, fd_);
				decimal? ff_ = context.Operators.Multiply(fc_, fe_);
				decimal? fg_ = context.Operators.ConvertIntegerToDecimal(60);
				decimal? fh_ = context.Operators.Multiply(ff_, fg_);

				return fh_;
			}
			else if (r_())
			{
				decimal? fi_ = context.Operators.ConvertIntegerToDecimal(frequency);
				decimal? fj_ = period?.value;
				decimal? fk_ = context.Operators.Divide(24.0m, fj_);
				decimal? fl_ = context.Operators.Multiply(fi_, fk_);
				decimal? fm_ = context.Operators.ConvertIntegerToDecimal(60);
				decimal? fn_ = context.Operators.Multiply(fl_, fm_);
				decimal? fp_ = context.Operators.Multiply(fn_, fm_);

				return fp_;
			}
			else if (s_())
			{
				decimal? fq_ = context.Operators.ConvertIntegerToDecimal(frequency);
				decimal? fr_ = period?.value;
				decimal? fs_ = context.Operators.Divide(24.0m, fr_);
				decimal? ft_ = context.Operators.Multiply(fq_, fs_);
				decimal? fu_ = context.Operators.ConvertIntegerToDecimal(24);
				decimal? fv_ = context.Operators.Divide(ft_, fu_);

				return fv_;
			}
			else if (t_())
			{
				decimal? fw_ = context.Operators.ConvertIntegerToDecimal(frequency);
				decimal? fx_ = period?.value;
				decimal? fy_ = context.Operators.Divide(24.0m, fx_);
				decimal? fz_ = context.Operators.Multiply(fw_, fy_);
				int? ga_ = context.Operators.Multiply(24, 7);
				decimal? gb_ = context.Operators.ConvertIntegerToDecimal(ga_);
				decimal? gc_ = context.Operators.Divide(fz_, gb_);

				return gc_;
			}
			else if (u_())
			{
				decimal? gd_ = context.Operators.ConvertIntegerToDecimal(frequency);
				decimal? ge_ = period?.value;
				decimal? gf_ = context.Operators.Divide(24.0m, ge_);
				decimal? gg_ = context.Operators.Multiply(gd_, gf_);
				int? gh_ = context.Operators.Multiply(24, 30);
				decimal? gi_ = context.Operators.ConvertIntegerToDecimal(gh_);
				decimal? gj_ = context.Operators.Divide(gg_, gi_);

				return gj_;
			}
			else if (v_())
			{
				decimal? gk_ = context.Operators.ConvertIntegerToDecimal(frequency);
				decimal? gl_ = period?.value;
				decimal? gm_ = context.Operators.Divide(24.0m, gl_);
				decimal? gn_ = context.Operators.Multiply(gk_, gm_);
				int? go_ = context.Operators.Multiply(24, 365);
				decimal? gp_ = context.Operators.ConvertIntegerToDecimal(go_);
				decimal? gq_ = context.Operators.Divide(gn_, gp_);

				return gq_;
			}
			else
			{
				string gr_ = this.ErrorLevel(context);
				string gs_ = period?.unit;
				string gt_ = context.Operators.Concatenate("Unknown unit ", gs_ ?? "");
				object gu_ = context.Operators.Message<object>(null, "CMDLogic.ToDaily.UnknownUnit", gr_, gt_);

				return gu_ as decimal?;
			}
		};

		return a_();
	}

    [CqlDeclaration("ToDaily")]
	public  decimal? ToDaily(CqlContext context, CqlCode frequency)
	{
		decimal? a_()
		{
			bool b_()
			{
				CqlCode c_ = this.C(context);
				bool? d_ = context.Operators.Equal(frequency, c_);

				return d_ ?? false;
			};
			if (b_())
			{
				return 3.0m;
			}
			else
			{
				string e_ = this.ErrorLevel(context);
				string f_ = frequency?.code;
				string g_ = context.Operators.Concatenate("Unknown frequency code ", f_ ?? "");
				object h_ = context.Operators.Message<object>(null, "CMDLogic.ToDaily.UnknownFrequencyCode", e_, g_);

				return h_ as decimal?;
			}
		};

		return a_();
	}

    [CqlDeclaration("MedicationRequestPeriod")]
	public  CqlInterval<CqlDateTime> MedicationRequestPeriod(CqlContext context, MedicationRequest Request)
	{
		MedicationRequest[] a_ = [
			Request,
		];
		CqlInterval<CqlDateTime> b_(MedicationRequest R)
		{
			CqlInterval<CqlDateTime> e_()
			{
				bool f_()
				{
					List<Dosage> g_ = R?.DosageInstruction;
					Dosage h_ = context.Operators.SingletonFrom<Dosage>((IEnumerable<Dosage>)g_);
					Timing i_ = h_?.Timing;
					Timing.RepeatComponent j_ = i_?.Repeat;
					DataType k_ = j_?.Bounds;
					CqlInterval<CqlDateTime> l_ = fhirHelpers_4_0_001.ToInterval(context, k_ as Period);
					CqlDateTime m_ = context.Operators.End(l_);
					Dosage o_ = context.Operators.SingletonFrom<Dosage>((IEnumerable<Dosage>)g_);
					Timing p_ = o_?.Timing;
					Timing.RepeatComponent q_ = p_?.Repeat;
					DataType r_ = q_?.Bounds;
					CqlInterval<CqlDateTime> s_ = fhirHelpers_4_0_001.ToInterval(context, r_ as Period);
					CqlDateTime t_ = context.Operators.End(s_);
					CqlDateTime u_ = context.Operators.MaxValue<CqlDateTime>();
					bool? v_ = context.Operators.Equal(t_, u_);
					bool? w_ = context.Operators.Or((bool?)(m_ is null), v_);
					bool? x_ = context.Operators.Not(w_);

					return x_ ?? false;
				};
				if (f_())
				{
					List<Dosage> y_ = R?.DosageInstruction;
					Dosage z_ = context.Operators.SingletonFrom<Dosage>((IEnumerable<Dosage>)y_);
					Timing aa_ = z_?.Timing;
					Timing.RepeatComponent ab_ = aa_?.Repeat;
					DataType ac_ = ab_?.Bounds;
					CqlInterval<CqlDateTime> ad_ = fhirHelpers_4_0_001.ToInterval(context, ac_ as Period);
					CqlDateTime ae_ = context.Operators.Start(ad_);
					MedicationRequest.DispenseRequestComponent af_ = R?.DispenseRequest;
					Period ag_ = af_?.ValidityPeriod;
					CqlInterval<CqlDateTime> ah_ = fhirHelpers_4_0_001.ToInterval(context, ag_);
					CqlDateTime ai_ = context.Operators.Start(ah_);
					FhirDateTime aj_ = R?.AuthoredOnElement;
					CqlDateTime ak_ = fhirHelpers_4_0_001.ToDateTime(context, aj_);
					Dosage am_ = context.Operators.SingletonFrom<Dosage>((IEnumerable<Dosage>)y_);
					Timing an_ = am_?.Timing;
					Timing.RepeatComponent ao_ = an_?.Repeat;
					DataType ap_ = ao_?.Bounds;
					CqlInterval<CqlDateTime> aq_ = fhirHelpers_4_0_001.ToInterval(context, ap_ as Period);
					CqlDateTime ar_ = context.Operators.End(aq_);
					CqlInterval<CqlDateTime> as_ = context.Operators.Interval((ae_ ?? ai_) ?? ak_, ar_, true, true);

					return as_;
				}
				else
				{
					List<Dosage> at_ = R?.DosageInstruction;
					Dosage au_ = context.Operators.SingletonFrom<Dosage>((IEnumerable<Dosage>)at_);
					Timing av_ = au_?.Timing;
					Timing.RepeatComponent aw_ = av_?.Repeat;
					DataType ax_ = aw_?.Bounds;
					CqlInterval<CqlDateTime> ay_ = fhirHelpers_4_0_001.ToInterval(context, ax_ as Period);
					CqlDateTime az_ = context.Operators.Start(ay_);
					MedicationRequest.DispenseRequestComponent ba_ = R?.DispenseRequest;
					Period bb_ = ba_?.ValidityPeriod;
					CqlInterval<CqlDateTime> bc_ = fhirHelpers_4_0_001.ToInterval(context, bb_);
					CqlDateTime bd_ = context.Operators.Start(bc_);
					FhirDateTime be_ = R?.AuthoredOnElement;
					CqlDateTime bf_ = fhirHelpers_4_0_001.ToDateTime(context, be_);
					Dosage bh_ = context.Operators.SingletonFrom<Dosage>((IEnumerable<Dosage>)at_);
					Timing bi_ = bh_?.Timing;
					Timing.RepeatComponent bj_ = bi_?.Repeat;
					DataType bk_ = bj_?.Bounds;
					CqlInterval<CqlDateTime> bl_ = fhirHelpers_4_0_001.ToInterval(context, bk_ as Period);
					CqlDateTime bm_ = context.Operators.Start(bl_);
					Period bo_ = ba_?.ValidityPeriod;
					CqlInterval<CqlDateTime> bp_ = fhirHelpers_4_0_001.ToInterval(context, bo_);
					CqlDateTime bq_ = context.Operators.Start(bp_);
					CqlDateTime bs_ = fhirHelpers_4_0_001.ToDateTime(context, be_);
					Duration bu_ = ba_?.ExpectedSupplyDuration;
					CqlQuantity bv_ = fhirHelpers_4_0_001.ToQuantity(context, bu_);
					Quantity bx_ = ba_?.Quantity;
					CqlQuantity by_ = fhirHelpers_4_0_001.ToQuantity(context, bx_);
					Dosage ca_ = context.Operators.SingletonFrom<Dosage>((IEnumerable<Dosage>)at_);
					List<Dosage.DoseAndRateComponent> cb_ = ca_?.DoseAndRate;
					Dosage.DoseAndRateComponent cc_ = context.Operators.SingletonFrom<Dosage.DoseAndRateComponent>((IEnumerable<Dosage.DoseAndRateComponent>)cb_);
					DataType cd_ = cc_?.Dose;
					CqlInterval<CqlQuantity> ce_ = fhirHelpers_4_0_001.ToInterval(context, cd_ as Range);
					CqlQuantity cf_ = context.Operators.End(ce_);
					Dosage ch_ = context.Operators.SingletonFrom<Dosage>((IEnumerable<Dosage>)at_);
					List<Dosage.DoseAndRateComponent> ci_ = ch_?.DoseAndRate;
					Dosage.DoseAndRateComponent cj_ = context.Operators.SingletonFrom<Dosage.DoseAndRateComponent>((IEnumerable<Dosage.DoseAndRateComponent>)ci_);
					DataType ck_ = cj_?.Dose;
					CqlQuantity cl_ = fhirHelpers_4_0_001.ToQuantity(context, ck_ as Quantity);
					Dosage cn_ = context.Operators.SingletonFrom<Dosage>((IEnumerable<Dosage>)at_);
					Timing co_ = cn_?.Timing;
					Timing.RepeatComponent cp_ = co_?.Repeat;
					PositiveInt cq_ = cp_?.FrequencyMaxElement;
					Integer cr_ = context.Operators.Convert<Integer>(cq_);
					Dosage ct_ = context.Operators.SingletonFrom<Dosage>((IEnumerable<Dosage>)at_);
					Timing cu_ = ct_?.Timing;
					Timing.RepeatComponent cv_ = cu_?.Repeat;
					PositiveInt cw_ = cv_?.FrequencyElement;
					Integer cx_ = context.Operators.Convert<Integer>(cw_);
					int? cy_ = fhirHelpers_4_0_001.ToInteger(context, cr_ ?? cx_);
					Dosage da_ = context.Operators.SingletonFrom<Dosage>((IEnumerable<Dosage>)at_);
					Timing db_ = da_?.Timing;
					Timing.RepeatComponent dc_ = db_?.Repeat;
					FhirDecimal dd_ = dc_?.PeriodElement;
					decimal? de_ = fhirHelpers_4_0_001.ToDecimal(context, dd_);
					Dosage dg_ = context.Operators.SingletonFrom<Dosage>((IEnumerable<Dosage>)at_);
					Timing dh_ = dg_?.Timing;
					Timing.RepeatComponent di_ = dh_?.Repeat;
					Code<Timing.UnitsOfTime> dj_ = di_?.PeriodUnitElement;
					Timing.UnitsOfTime? dk_ = dj_?.Value;
					string dl_ = context.Operators.Convert<string>(dk_);
					decimal? dm_ = this.ToDaily(context, cy_, new CqlQuantity(de_, dl_));
					Dosage do_ = context.Operators.SingletonFrom<Dosage>((IEnumerable<Dosage>)at_);
					Timing dp_ = do_?.Timing;
					Timing.RepeatComponent dq_ = dp_?.Repeat;
					List<Time> dr_ = dq_?.TimeOfDayElement;
					int? ds_ = context.Operators.Count<Time>((IEnumerable<Time>)dr_);
					decimal? dt_ = context.Operators.ConvertIntegerToDecimal(ds_);
					CqlQuantity du_ = context.Operators.ConvertDecimalToQuantity((dm_ ?? dt_) ?? 1.0m);
					CqlQuantity dv_ = context.Operators.Multiply(cf_ ?? cl_, du_);
					CqlQuantity dw_ = context.Operators.Divide(by_, dv_);
					UnsignedInt dy_ = ba_?.NumberOfRepeatsAllowedElement;
					Integer dz_ = context.Operators.Convert<Integer>(dy_);
					int? ea_ = fhirHelpers_4_0_001.ToInteger(context, dz_);
					int? eb_ = context.Operators.Add(1, ea_ ?? 0);
					CqlQuantity ec_ = context.Operators.ConvertIntegerToQuantity(eb_);
					CqlQuantity ed_ = context.Operators.Multiply(bv_ ?? dw_, ec_);
					CqlDateTime ee_ = context.Operators.Add((bm_ ?? bq_) ?? bs_, ed_);
					CqlInterval<CqlDateTime> ef_ = context.Operators.Interval((az_ ?? bd_) ?? bf_, ee_, true, true);

					return ef_;
				}
			};

			return e_();
		};
		IEnumerable<CqlInterval<CqlDateTime>> c_ = context.Operators.Select<MedicationRequest, CqlInterval<CqlDateTime>>((IEnumerable<MedicationRequest>)a_, b_);
		CqlInterval<CqlDateTime> d_ = context.Operators.SingletonFrom<CqlInterval<CqlDateTime>>(c_);

		return d_;
	}

    [CqlDeclaration("MedicationDispensePeriod")]
	public  CqlInterval<CqlDateTime> MedicationDispensePeriod(CqlContext context, MedicationDispense Dispense)
	{
		MedicationDispense[] a_ = [
			Dispense,
		];
		CqlInterval<CqlDateTime> b_(MedicationDispense D)
		{
			FhirDateTime e_ = D?.WhenHandedOverElement;
			FhirDateTime f_ = D?.WhenPreparedElement;
			CqlDateTime g_ = fhirHelpers_4_0_001.ToDateTime(context, e_ ?? f_);
			CqlDateTime j_ = fhirHelpers_4_0_001.ToDateTime(context, e_ ?? f_);
			Quantity k_ = D?.DaysSupply;
			CqlQuantity l_ = fhirHelpers_4_0_001.ToQuantity(context, k_);
			Quantity m_ = D?.Quantity;
			CqlQuantity n_ = fhirHelpers_4_0_001.ToQuantity(context, m_);
			List<Dosage> o_ = D?.DosageInstruction;
			Dosage p_ = context.Operators.SingletonFrom<Dosage>((IEnumerable<Dosage>)o_);
			List<Dosage.DoseAndRateComponent> q_ = p_?.DoseAndRate;
			Dosage.DoseAndRateComponent r_ = context.Operators.SingletonFrom<Dosage.DoseAndRateComponent>((IEnumerable<Dosage.DoseAndRateComponent>)q_);
			DataType s_ = r_?.Dose;
			CqlInterval<CqlQuantity> t_ = fhirHelpers_4_0_001.ToInterval(context, s_ as Range);
			CqlQuantity u_ = context.Operators.End(t_);
			Dosage w_ = context.Operators.SingletonFrom<Dosage>((IEnumerable<Dosage>)o_);
			List<Dosage.DoseAndRateComponent> x_ = w_?.DoseAndRate;
			Dosage.DoseAndRateComponent y_ = context.Operators.SingletonFrom<Dosage.DoseAndRateComponent>((IEnumerable<Dosage.DoseAndRateComponent>)x_);
			DataType z_ = y_?.Dose;
			CqlQuantity aa_ = fhirHelpers_4_0_001.ToQuantity(context, z_ as Quantity);
			Dosage ac_ = context.Operators.SingletonFrom<Dosage>((IEnumerable<Dosage>)o_);
			Timing ad_ = ac_?.Timing;
			Timing.RepeatComponent ae_ = ad_?.Repeat;
			PositiveInt af_ = ae_?.FrequencyMaxElement;
			Integer ag_ = context.Operators.Convert<Integer>(af_);
			Dosage ai_ = context.Operators.SingletonFrom<Dosage>((IEnumerable<Dosage>)o_);
			Timing aj_ = ai_?.Timing;
			Timing.RepeatComponent ak_ = aj_?.Repeat;
			PositiveInt al_ = ak_?.FrequencyElement;
			Integer am_ = context.Operators.Convert<Integer>(al_);
			int? an_ = fhirHelpers_4_0_001.ToInteger(context, ag_ ?? am_);
			Dosage ap_ = context.Operators.SingletonFrom<Dosage>((IEnumerable<Dosage>)o_);
			Timing aq_ = ap_?.Timing;
			Timing.RepeatComponent ar_ = aq_?.Repeat;
			FhirDecimal as_ = ar_?.PeriodElement;
			decimal? at_ = fhirHelpers_4_0_001.ToDecimal(context, as_);
			Dosage av_ = context.Operators.SingletonFrom<Dosage>((IEnumerable<Dosage>)o_);
			Timing aw_ = av_?.Timing;
			Timing.RepeatComponent ax_ = aw_?.Repeat;
			Code<Timing.UnitsOfTime> ay_ = ax_?.PeriodUnitElement;
			Timing.UnitsOfTime? az_ = ay_?.Value;
			string ba_ = context.Operators.Convert<string>(az_);
			decimal? bb_ = this.ToDaily(context, an_, new CqlQuantity(at_, ba_));
			Dosage bd_ = context.Operators.SingletonFrom<Dosage>((IEnumerable<Dosage>)o_);
			Timing be_ = bd_?.Timing;
			Timing.RepeatComponent bf_ = be_?.Repeat;
			List<Time> bg_ = bf_?.TimeOfDayElement;
			int? bh_ = context.Operators.Count<Time>((IEnumerable<Time>)bg_);
			decimal? bi_ = context.Operators.ConvertIntegerToDecimal(bh_);
			CqlQuantity bj_ = context.Operators.ConvertDecimalToQuantity((bb_ ?? bi_) ?? 1.0m);
			CqlQuantity bk_ = context.Operators.Multiply(u_ ?? aa_, bj_);
			CqlQuantity bl_ = context.Operators.Divide(n_, bk_);
			CqlDateTime bm_ = context.Operators.Add(j_, l_ ?? bl_);
			CqlInterval<CqlDateTime> bn_ = context.Operators.Interval(g_, bm_, true, true);

			return bn_;
		};
		IEnumerable<CqlInterval<CqlDateTime>> c_ = context.Operators.Select<MedicationDispense, CqlInterval<CqlDateTime>>((IEnumerable<MedicationDispense>)a_, b_);
		CqlInterval<CqlDateTime> d_ = context.Operators.SingletonFrom<CqlInterval<CqlDateTime>>(c_);

		return d_;
	}

    [CqlDeclaration("TherapeuticDuration")]
	public  CqlQuantity TherapeuticDuration(CqlContext context, CqlConcept medication)
	{
		CqlQuantity a_ = context.Operators.Quantity(14m, "days");

		return a_;
	}

    [CqlDeclaration("MedicationAdministrationPeriod")]
	public  CqlInterval<CqlDateTime> MedicationAdministrationPeriod(CqlContext context, MedicationAdministration Administration)
	{
		MedicationAdministration[] a_ = [
			Administration,
		];
		CqlInterval<CqlDateTime> b_(MedicationAdministration M)
		{
			CqlInterval<CqlDateTime> e_()
			{
				bool f_()
				{
					DataType g_ = Administration?.Effective;
					CqlInterval<CqlDateTime> h_ = fhirHelpers_4_0_001.ToInterval(context, g_ as Period);
					CqlDateTime i_ = context.Operators.Start(h_);
					bool? j_ = context.Operators.Not((bool?)(i_ is null));
					DataType k_ = Administration?.Medication;
					CqlConcept l_ = fhirHelpers_4_0_001.ToConcept(context, k_ as CodeableConcept);
					CqlQuantity m_ = this.TherapeuticDuration(context, l_);
					bool? n_ = context.Operators.Not((bool?)(m_ is null));
					bool? o_ = context.Operators.And(j_, n_);

					return o_ ?? false;
				};
				if (f_())
				{
					DataType p_ = Administration?.Effective;
					CqlInterval<CqlDateTime> q_ = fhirHelpers_4_0_001.ToInterval(context, p_ as Period);
					CqlDateTime r_ = context.Operators.Start(q_);
					CqlInterval<CqlDateTime> t_ = fhirHelpers_4_0_001.ToInterval(context, p_ as Period);
					CqlDateTime u_ = context.Operators.Start(t_);
					DataType v_ = Administration?.Medication;
					CqlConcept w_ = fhirHelpers_4_0_001.ToConcept(context, v_ as CodeableConcept);
					CqlQuantity x_ = this.TherapeuticDuration(context, w_);
					CqlDateTime y_ = context.Operators.Add(u_, x_);
					CqlInterval<CqlDateTime> z_ = context.Operators.Interval(r_, y_, true, true);

					return z_;
				}
				else
				{
					return null as CqlInterval<CqlDateTime>;
				}
			};

			return e_();
		};
		IEnumerable<CqlInterval<CqlDateTime>> c_ = context.Operators.Select<MedicationAdministration, CqlInterval<CqlDateTime>>((IEnumerable<MedicationAdministration>)a_, b_);
		CqlInterval<CqlDateTime> d_ = context.Operators.SingletonFrom<CqlInterval<CqlDateTime>>(c_);

		return d_;
	}

    [CqlDeclaration("CumulativeDuration")]
	public  int? CumulativeDuration(CqlContext context, IEnumerable<CqlInterval<CqlDateTime>> Intervals)
	{
		IEnumerable<CqlInterval<CqlDateTime>> a_ = context.Operators.Collapse(Intervals, "day");
		int? b_(CqlInterval<CqlDateTime> X)
		{
			CqlDateTime e_ = context.Operators.Start(X);
			CqlDateTime f_ = context.Operators.End(X);
			int? g_ = context.Operators.DifferenceBetween(e_, f_, "day");

			return g_;
		};
		IEnumerable<int?> c_ = context.Operators.Select<CqlInterval<CqlDateTime>, int?>(a_, b_);
		int? d_ = context.Operators.Sum(c_);

		return d_;
	}

    [CqlDeclaration("RolloutIntervals")]
	public  IEnumerable<CqlInterval<CqlDateTime>> RolloutIntervals(CqlContext context, IEnumerable<CqlInterval<CqlDateTime>> intervals)
	{
		IEnumerable<CqlInterval<CqlDateTime>> a_(IEnumerable<CqlInterval<CqlDateTime>> R, CqlInterval<CqlDateTime> I)
		{
			CqlInterval<CqlDateTime>[] c_ = [
				I,
			];
			CqlInterval<CqlDateTime> d_(CqlInterval<CqlDateTime> X)
			{
				CqlInterval<CqlDateTime> i_ = context.Operators.Last<CqlInterval<CqlDateTime>>(R);
				CqlDateTime j_ = context.Operators.End(i_);
				CqlQuantity k_ = context.Operators.Quantity(1m, "day");
				CqlDateTime l_ = context.Operators.Add(j_, k_);
				CqlDateTime m_ = context.Operators.Start(X);
				CqlDateTime[] n_ = [
					l_,
					m_,
				];
				CqlDateTime o_ = context.Operators.Max<CqlDateTime>(n_ as IEnumerable<CqlDateTime>);
				CqlDateTime q_ = context.Operators.End(i_);
				CqlDateTime s_ = context.Operators.Add(q_, k_);
				CqlDateTime[] u_ = [
					s_,
					m_,
				];
				CqlDateTime v_ = context.Operators.Max<CqlDateTime>(u_ as IEnumerable<CqlDateTime>);
				CqlDateTime x_ = context.Operators.End(X);
				int? y_ = context.Operators.DurationBetween(m_, x_, "day");
				decimal? z_ = context.Operators.ConvertIntegerToDecimal(y_ ?? 0);
				CqlDateTime aa_ = context.Operators.Add(v_, new CqlQuantity(z_, "day"));
				CqlInterval<CqlDateTime> ab_ = context.Operators.Interval(o_, aa_, true, true);

				return ab_;
			};
			IEnumerable<CqlInterval<CqlDateTime>> e_ = context.Operators.Select<CqlInterval<CqlDateTime>, CqlInterval<CqlDateTime>>((IEnumerable<CqlInterval<CqlDateTime>>)c_, d_);
			CqlInterval<CqlDateTime> f_ = context.Operators.SingletonFrom<CqlInterval<CqlDateTime>>(e_);
			CqlInterval<CqlDateTime>[] g_ = [
				f_,
			];
			IEnumerable<CqlInterval<CqlDateTime>> h_ = context.Operators.Union<CqlInterval<CqlDateTime>>(R, g_ as IEnumerable<CqlInterval<CqlDateTime>>);

			return h_;
		};
		IEnumerable<CqlInterval<CqlDateTime>> b_ = context.Operators.Aggregate<CqlInterval<CqlDateTime>, IEnumerable<CqlInterval<CqlDateTime>>>(intervals, a_, null as IEnumerable<CqlInterval<CqlDateTime>>);

		return b_;
	}

    [CqlDeclaration("MedicationPeriod")]
	public  CqlInterval<CqlDateTime> MedicationPeriod(CqlContext context, object medication)
	{
		CqlInterval<CqlDateTime> a_()
		{
			if (medication is MedicationRequest)
			{
				CqlInterval<CqlDateTime> b_ = this.MedicationRequestPeriod(context, medication as MedicationRequest);

				return b_;
			}
			else if (medication is MedicationDispense)
			{
				CqlInterval<CqlDateTime> c_ = this.MedicationDispensePeriod(context, medication as MedicationDispense);

				return c_;
			}
			else if (medication is MedicationAdministration)
			{
				CqlInterval<CqlDateTime> d_ = this.MedicationAdministrationPeriod(context, medication as MedicationAdministration);

				return d_;
			}
			else
			{
				return null as CqlInterval<CqlDateTime>;
			}
		};

		return a_();
	}

    [CqlDeclaration("CumulativeMedicationDuration")]
	public  int? CumulativeMedicationDuration(CqlContext context, IEnumerable<object> Medications)
	{
		bool? a_(object M)
		{
			bool l_ = M is MedicationRequest;

			return l_ as bool?;
		};
		IEnumerable<object> b_ = context.Operators.Where<object>(Medications, a_);
		CqlInterval<CqlDateTime> c_(object M)
		{
			CqlInterval<CqlDateTime> m_ = this.MedicationPeriod(context, M);

			return m_;
		};
		IEnumerable<CqlInterval<CqlDateTime>> d_ = context.Operators.Select<object, CqlInterval<CqlDateTime>>(b_, c_);
		bool? e_(object M)
		{
			bool n_ = M is MedicationDispense;
			bool o_ = M is MedicationAdministration;
			bool? p_ = context.Operators.Or(n_ as bool?, o_ as bool?);

			return p_;
		};
		IEnumerable<object> f_ = context.Operators.Where<object>(Medications, e_);
		CqlInterval<CqlDateTime> g_(object M)
		{
			CqlInterval<CqlDateTime> q_ = this.MedicationPeriod(context, M);

			return q_;
		};
		IEnumerable<CqlInterval<CqlDateTime>> h_ = context.Operators.Select<object, CqlInterval<CqlDateTime>>(f_, g_);
		IEnumerable<CqlInterval<CqlDateTime>> i_ = this.RolloutIntervals(context, h_);
		IEnumerable<CqlInterval<CqlDateTime>> j_ = context.Operators.Union<CqlInterval<CqlDateTime>>(d_, i_);
		int? k_ = this.CumulativeDuration(context, j_);

		return k_;
	}

}
