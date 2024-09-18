﻿using System;
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

#pragma warning disable CS9113 // Parameter is unread.

[System.CodeDom.Compiler.GeneratedCode(".NET Code Generation", "2.0.3.0")]
[CqlLibrary("FHIRHelpers", "4.0.001")]
public class FHIRHelpers_4_0_001
{

    [CqlDeclaration("Patient")]
	public  Patient Patient(CqlContext context)
	{
		IEnumerable<Patient> a_ = context.Operators.RetrieveByValueSet<Patient>(default, default);
		Patient b_ = context.Operators.SingletonFrom<Patient>(a_);

		return b_;
	}

    [CqlDeclaration("ToInterval")]
	public  CqlInterval<CqlDateTime> ToInterval(CqlContext context, Period period)
	{
		CqlInterval<CqlDateTime> a_()
		{
			if (period is null)
			{
				return null as CqlInterval<CqlDateTime>;
			}
			else
			{
				FhirDateTime b_ = period?.StartElement;
				CqlDateTime c_ = context.Operators.Convert<CqlDateTime>(b_);
				FhirDateTime d_ = period?.EndElement;
				CqlDateTime e_ = context.Operators.Convert<CqlDateTime>(d_);
				CqlInterval<CqlDateTime> f_ = context.Operators.Interval(c_, e_, true, true);

				return f_;
			}
		};

		return a_();
	}

    [CqlDeclaration("ToInterval")]
	public  CqlInterval<CqlQuantity> ToInterval(CqlContext context, Range range)
	{
		CqlInterval<CqlQuantity> a_()
		{
			if (range is null)
			{
				return null as CqlInterval<CqlQuantity>;
			}
			else
			{
				Quantity b_ = range?.Low;
				CqlQuantity c_ = this.ToQuantity(context, b_);
				Quantity d_ = range?.High;
				CqlQuantity e_ = this.ToQuantity(context, d_);
				CqlInterval<CqlQuantity> f_ = context.Operators.Interval(c_, e_, true, true);

				return f_;
			}
		};

		return a_();
	}

    [CqlDeclaration("ToQuantity")]
	public  CqlQuantity ToQuantity(CqlContext context, Quantity quantity)
	{
		CqlQuantity a_()
		{
			if (quantity is null)
			{
				return default;
			}
			else
			{
				FhirDecimal b_ = quantity?.ValueElement;
				decimal? c_ = b_?.Value;
				FhirString d_ = quantity?.UnitElement;
				string e_ = d_?.Value;

				return new CqlQuantity(c_, e_);
			}
		};

		return a_();
	}

    [CqlDeclaration("ToRatio")]
	public  CqlRatio ToRatio(CqlContext context, Ratio ratio)
	{
		CqlRatio a_()
		{
			if (ratio is null)
			{
				return default;
			}
			else
			{
				Quantity b_ = ratio?.Numerator;
				CqlQuantity c_ = this.ToQuantity(context, b_);
				Quantity d_ = ratio?.Denominator;
				CqlQuantity e_ = this.ToQuantity(context, d_);

				return new CqlRatio(c_, e_);
			}
		};

		return a_();
	}

    [CqlDeclaration("ToCode")]
	public  CqlCode ToCode(CqlContext context, Coding coding)
	{
		CqlCode a_()
		{
			if (coding is null)
			{
				return default;
			}
			else
			{
				Code b_ = coding?.CodeElement;
				string c_ = b_?.Value;
				FhirUri d_ = coding?.SystemElement;
				string e_ = d_?.Value;
				FhirString f_ = coding?.VersionElement;
				string g_ = f_?.Value;
				FhirString h_ = coding?.DisplayElement;
				string i_ = h_?.Value;

				return new CqlCode(c_, e_, g_, i_);
			}
		};

		return a_();
	}

    [CqlDeclaration("ToConcept")]
	public  CqlConcept ToConcept(CqlContext context, CodeableConcept concept)
	{
		CqlConcept a_()
		{
			if (concept is null)
			{
				return default;
			}
			else
			{
				List<Coding> b_ = concept?.Coding;
				CqlCode c_(Coding C)
				{
					CqlCode g_ = this.ToCode(context, C);

					return g_;
				};
				IEnumerable<CqlCode> d_ = context.Operators.Select<Coding, CqlCode>((IEnumerable<Coding>)b_, c_);
				FhirString e_ = concept?.TextElement;
				string f_ = e_?.Value;

				return new CqlConcept(d_, f_);
			}
		};

		return a_();
	}

    [CqlDeclaration("ToString")]
	public  string ToString(CqlContext context, Code<Account.AccountStatus> value)
	{
		Account.AccountStatus? a_ = value?.Value;
		string b_ = context.Operators.Convert<string>(a_);

		return b_;
	}

    [CqlDeclaration("ToString")]
	public  string ToString(CqlContext context, Code<ActionCardinalityBehavior> value)
	{
		ActionCardinalityBehavior? a_ = value?.Value;
		string b_ = context.Operators.Convert<string>(a_);

		return b_;
	}

    [CqlDeclaration("ToString")]
	public  string ToString(CqlContext context, Code<ActionConditionKind> value)
	{
		ActionConditionKind? a_ = value?.Value;
		string b_ = context.Operators.Convert<string>(a_);

		return b_;
	}

    [CqlDeclaration("ToString")]
	public  string ToString(CqlContext context, Code<ActionGroupingBehavior> value)
	{
		ActionGroupingBehavior? a_ = value?.Value;
		string b_ = context.Operators.Convert<string>(a_);

		return b_;
	}

    [CqlDeclaration("ToString")]
	public  string ToString(CqlContext context, Code<ActionParticipantType> value)
	{
		ActionParticipantType? a_ = value?.Value;
		string b_ = context.Operators.Convert<string>(a_);

		return b_;
	}

    [CqlDeclaration("ToString")]
	public  string ToString(CqlContext context, Code<ActionPrecheckBehavior> value)
	{
		ActionPrecheckBehavior? a_ = value?.Value;
		string b_ = context.Operators.Convert<string>(a_);

		return b_;
	}

    [CqlDeclaration("ToString")]
	public  string ToString(CqlContext context, Code<ActionRelationshipType> value)
	{
		ActionRelationshipType? a_ = value?.Value;
		string b_ = context.Operators.Convert<string>(a_);

		return b_;
	}

    [CqlDeclaration("ToString")]
	public  string ToString(CqlContext context, Code<ActionRequiredBehavior> value)
	{
		ActionRequiredBehavior? a_ = value?.Value;
		string b_ = context.Operators.Convert<string>(a_);

		return b_;
	}

    [CqlDeclaration("ToString")]
	public  string ToString(CqlContext context, Code<ActionSelectionBehavior> value)
	{
		ActionSelectionBehavior? a_ = value?.Value;
		string b_ = context.Operators.Convert<string>(a_);

		return b_;
	}

    [CqlDeclaration("ToString")]
	public  string ToString(CqlContext context, Code<ActivityDefinition.RequestResourceType> value)
	{
		ActivityDefinition.RequestResourceType? a_ = value?.Value;
		string b_ = context.Operators.Convert<string>(a_);

		return b_;
	}

    [CqlDeclaration("ToString")]
	public  string ToString(CqlContext context, Code<Address.AddressType> value)
	{
		Address.AddressType? a_ = value?.Value;
		string b_ = context.Operators.Convert<string>(a_);

		return b_;
	}

    [CqlDeclaration("ToString")]
	public  string ToString(CqlContext context, Code<Address.AddressUse> value)
	{
		Address.AddressUse? a_ = value?.Value;
		string b_ = context.Operators.Convert<string>(a_);

		return b_;
	}

    [CqlDeclaration("ToString")]
	public  string ToString(CqlContext context, Code<AdministrativeGender> value)
	{
		AdministrativeGender? a_ = value?.Value;
		string b_ = context.Operators.Convert<string>(a_);

		return b_;
	}

    [CqlDeclaration("ToString")]
	public  string ToString(CqlContext context, Code<AdverseEvent.AdverseEventActuality> value)
	{
		AdverseEvent.AdverseEventActuality? a_ = value?.Value;
		string b_ = context.Operators.Convert<string>(a_);

		return b_;
	}

    [CqlDeclaration("ToString")]
	public  string ToString(CqlContext context, Code<ElementDefinition.AggregationMode> value)
	{
		ElementDefinition.AggregationMode? a_ = value?.Value;
		string b_ = context.Operators.Convert<string>(a_);

		return b_;
	}

    [CqlDeclaration("ToString")]
	public  string ToString(CqlContext context, Code<AllergyIntolerance.AllergyIntoleranceCategory> value)
	{
		AllergyIntolerance.AllergyIntoleranceCategory? a_ = value?.Value;
		string b_ = context.Operators.Convert<string>(a_);

		return b_;
	}

    [CqlDeclaration("ToString")]
	public  string ToString(CqlContext context, Code<AllergyIntolerance.AllergyIntoleranceCriticality> value)
	{
		AllergyIntolerance.AllergyIntoleranceCriticality? a_ = value?.Value;
		string b_ = context.Operators.Convert<string>(a_);

		return b_;
	}

    [CqlDeclaration("ToString")]
	public  string ToString(CqlContext context, Code<AllergyIntolerance.AllergyIntoleranceSeverity> value)
	{
		AllergyIntolerance.AllergyIntoleranceSeverity? a_ = value?.Value;
		string b_ = context.Operators.Convert<string>(a_);

		return b_;
	}

    [CqlDeclaration("ToString")]
	public  string ToString(CqlContext context, Code<AllergyIntolerance.AllergyIntoleranceType> value)
	{
		AllergyIntolerance.AllergyIntoleranceType? a_ = value?.Value;
		string b_ = context.Operators.Convert<string>(a_);

		return b_;
	}

    [CqlDeclaration("ToString")]
	public  string ToString(CqlContext context, Code<Appointment.AppointmentStatus> value)
	{
		Appointment.AppointmentStatus? a_ = value?.Value;
		string b_ = context.Operators.Convert<string>(a_);

		return b_;
	}

    [CqlDeclaration("ToString")]
	public  string ToString(CqlContext context, Code<TestScript.AssertionDirectionType> value)
	{
		TestScript.AssertionDirectionType? a_ = value?.Value;
		string b_ = context.Operators.Convert<string>(a_);

		return b_;
	}

    [CqlDeclaration("ToString")]
	public  string ToString(CqlContext context, Code<TestScript.AssertionOperatorType> value)
	{
		TestScript.AssertionOperatorType? a_ = value?.Value;
		string b_ = context.Operators.Convert<string>(a_);

		return b_;
	}

    [CqlDeclaration("ToString")]
	public  string ToString(CqlContext context, Code<TestScript.AssertionResponseTypes> value)
	{
		TestScript.AssertionResponseTypes? a_ = value?.Value;
		string b_ = context.Operators.Convert<string>(a_);

		return b_;
	}

    [CqlDeclaration("ToString")]
	public  string ToString(CqlContext context, Code<AuditEvent.AuditEventAction> value)
	{
		AuditEvent.AuditEventAction? a_ = value?.Value;
		string b_ = context.Operators.Convert<string>(a_);

		return b_;
	}

    [CqlDeclaration("ToString")]
	public  string ToString(CqlContext context, Code<AuditEvent.AuditEventAgentNetworkType> value)
	{
		AuditEvent.AuditEventAgentNetworkType? a_ = value?.Value;
		string b_ = context.Operators.Convert<string>(a_);

		return b_;
	}

    [CqlDeclaration("ToString")]
	public  string ToString(CqlContext context, Code<AuditEvent.AuditEventOutcome> value)
	{
		AuditEvent.AuditEventOutcome? a_ = value?.Value;
		string b_ = context.Operators.Convert<string>(a_);

		return b_;
	}

    [CqlDeclaration("ToString")]
	public  string ToString(CqlContext context, Code<BindingStrength> value)
	{
		BindingStrength? a_ = value?.Value;
		string b_ = context.Operators.Convert<string>(a_);

		return b_;
	}

    [CqlDeclaration("ToString")]
	public  string ToString(CqlContext context, Code<BiologicallyDerivedProduct.BiologicallyDerivedProductCategory> value)
	{
		BiologicallyDerivedProduct.BiologicallyDerivedProductCategory? a_ = value?.Value;
		string b_ = context.Operators.Convert<string>(a_);

		return b_;
	}

    [CqlDeclaration("ToString")]
	public  string ToString(CqlContext context, Code<BiologicallyDerivedProduct.BiologicallyDerivedProductStatus> value)
	{
		BiologicallyDerivedProduct.BiologicallyDerivedProductStatus? a_ = value?.Value;
		string b_ = context.Operators.Convert<string>(a_);

		return b_;
	}

    [CqlDeclaration("ToString")]
	public  string ToString(CqlContext context, Code<BiologicallyDerivedProduct.BiologicallyDerivedProductStorageScale> value)
	{
		BiologicallyDerivedProduct.BiologicallyDerivedProductStorageScale? a_ = value?.Value;
		string b_ = context.Operators.Convert<string>(a_);

		return b_;
	}

    [CqlDeclaration("ToString")]
	public  string ToString(CqlContext context, Code<Bundle.BundleType> value)
	{
		Bundle.BundleType? a_ = value?.Value;
		string b_ = context.Operators.Convert<string>(a_);

		return b_;
	}

    [CqlDeclaration("ToString")]
	public  string ToString(CqlContext context, Code<CapabilityStatementKind> value)
	{
		CapabilityStatementKind? a_ = value?.Value;
		string b_ = context.Operators.Convert<string>(a_);

		return b_;
	}

    [CqlDeclaration("ToString")]
	public  string ToString(CqlContext context, Code<CarePlan.CarePlanActivityKind> value)
	{
		CarePlan.CarePlanActivityKind? a_ = value?.Value;
		string b_ = context.Operators.Convert<string>(a_);

		return b_;
	}

    [CqlDeclaration("ToString")]
	public  string ToString(CqlContext context, Code<CarePlan.CarePlanActivityStatus> value)
	{
		CarePlan.CarePlanActivityStatus? a_ = value?.Value;
		string b_ = context.Operators.Convert<string>(a_);

		return b_;
	}

    [CqlDeclaration("ToString")]
	public  string ToString(CqlContext context, Code<CarePlan.CarePlanIntent> value)
	{
		CarePlan.CarePlanIntent? a_ = value?.Value;
		string b_ = context.Operators.Convert<string>(a_);

		return b_;
	}

    [CqlDeclaration("ToString")]
	public  string ToString(CqlContext context, Code<RequestStatus> value)
	{
		RequestStatus? a_ = value?.Value;
		string b_ = context.Operators.Convert<string>(a_);

		return b_;
	}

    [CqlDeclaration("ToString")]
	public  string ToString(CqlContext context, Code<CareTeam.CareTeamStatus> value)
	{
		CareTeam.CareTeamStatus? a_ = value?.Value;
		string b_ = context.Operators.Convert<string>(a_);

		return b_;
	}

    [CqlDeclaration("ToString")]
	public  string ToString(CqlContext context, Code<CatalogEntry.CatalogEntryRelationType> value)
	{
		CatalogEntry.CatalogEntryRelationType? a_ = value?.Value;
		string b_ = context.Operators.Convert<string>(a_);

		return b_;
	}

    [CqlDeclaration("ToString")]
	public  string ToString(CqlContext context, Code<InvoicePriceComponentType> value)
	{
		InvoicePriceComponentType? a_ = value?.Value;
		string b_ = context.Operators.Convert<string>(a_);

		return b_;
	}

    [CqlDeclaration("ToString")]
	public  string ToString(CqlContext context, Code<ChargeItem.ChargeItemStatus> value)
	{
		ChargeItem.ChargeItemStatus? a_ = value?.Value;
		string b_ = context.Operators.Convert<string>(a_);

		return b_;
	}

    [CqlDeclaration("ToString")]
	public  string ToString(CqlContext context, Code<FinancialResourceStatusCodes> value)
	{
		FinancialResourceStatusCodes? a_ = value?.Value;
		string b_ = context.Operators.Convert<string>(a_);

		return b_;
	}

    [CqlDeclaration("ToString")]
	public  string ToString(CqlContext context, Code<ClinicalImpression.ClinicalImpressionStatus> value)
	{
		ClinicalImpression.ClinicalImpressionStatus? a_ = value?.Value;
		string b_ = context.Operators.Convert<string>(a_);

		return b_;
	}

    [CqlDeclaration("ToString")]
	public  string ToString(CqlContext context, Code<TerminologyCapabilities.CodeSearchSupport> value)
	{
		TerminologyCapabilities.CodeSearchSupport? a_ = value?.Value;
		string b_ = context.Operators.Convert<string>(a_);

		return b_;
	}

    [CqlDeclaration("ToString")]
	public  string ToString(CqlContext context, Code<CodeSystemContentMode> value)
	{
		CodeSystemContentMode? a_ = value?.Value;
		string b_ = context.Operators.Convert<string>(a_);

		return b_;
	}

    [CqlDeclaration("ToString")]
	public  string ToString(CqlContext context, Code<CodeSystem.CodeSystemHierarchyMeaning> value)
	{
		CodeSystem.CodeSystemHierarchyMeaning? a_ = value?.Value;
		string b_ = context.Operators.Convert<string>(a_);

		return b_;
	}

    [CqlDeclaration("ToString")]
	public  string ToString(CqlContext context, Code<RequestPriority> value)
	{
		RequestPriority? a_ = value?.Value;
		string b_ = context.Operators.Convert<string>(a_);

		return b_;
	}

    [CqlDeclaration("ToString")]
	public  string ToString(CqlContext context, Code<EventStatus> value)
	{
		EventStatus? a_ = value?.Value;
		string b_ = context.Operators.Convert<string>(a_);

		return b_;
	}

    [CqlDeclaration("ToString")]
	public  string ToString(CqlContext context, Code<CompartmentType> value)
	{
		CompartmentType? a_ = value?.Value;
		string b_ = context.Operators.Convert<string>(a_);

		return b_;
	}

    [CqlDeclaration("ToString")]
	public  string ToString(CqlContext context, Code<Composition.CompositionAttestationMode> value)
	{
		Composition.CompositionAttestationMode? a_ = value?.Value;
		string b_ = context.Operators.Convert<string>(a_);

		return b_;
	}

    [CqlDeclaration("ToString")]
	public  string ToString(CqlContext context, Code<CompositionStatus> value)
	{
		CompositionStatus? a_ = value?.Value;
		string b_ = context.Operators.Convert<string>(a_);

		return b_;
	}

    [CqlDeclaration("ToString")]
	public  string ToString(CqlContext context, Code<ConceptMapEquivalence> value)
	{
		ConceptMapEquivalence? a_ = value?.Value;
		string b_ = context.Operators.Convert<string>(a_);

		return b_;
	}

    [CqlDeclaration("ToString")]
	public  string ToString(CqlContext context, Code<ConceptMap.ConceptMapGroupUnmappedMode> value)
	{
		ConceptMap.ConceptMapGroupUnmappedMode? a_ = value?.Value;
		string b_ = context.Operators.Convert<string>(a_);

		return b_;
	}

    [CqlDeclaration("ToString")]
	public  string ToString(CqlContext context, Code<CapabilityStatement.ConditionalDeleteStatus> value)
	{
		CapabilityStatement.ConditionalDeleteStatus? a_ = value?.Value;
		string b_ = context.Operators.Convert<string>(a_);

		return b_;
	}

    [CqlDeclaration("ToString")]
	public  string ToString(CqlContext context, Code<CapabilityStatement.ConditionalReadStatus> value)
	{
		CapabilityStatement.ConditionalReadStatus? a_ = value?.Value;
		string b_ = context.Operators.Convert<string>(a_);

		return b_;
	}

    [CqlDeclaration("ToString")]
	public  string ToString(CqlContext context, Code<Consent.ConsentDataMeaning> value)
	{
		Consent.ConsentDataMeaning? a_ = value?.Value;
		string b_ = context.Operators.Convert<string>(a_);

		return b_;
	}

    [CqlDeclaration("ToString")]
	public  string ToString(CqlContext context, Code<Consent.ConsentProvisionType> value)
	{
		Consent.ConsentProvisionType? a_ = value?.Value;
		string b_ = context.Operators.Convert<string>(a_);

		return b_;
	}

    [CqlDeclaration("ToString")]
	public  string ToString(CqlContext context, Code<Consent.ConsentState> value)
	{
		Consent.ConsentState? a_ = value?.Value;
		string b_ = context.Operators.Convert<string>(a_);

		return b_;
	}

    [CqlDeclaration("ToString")]
	public  string ToString(CqlContext context, Code<ConstraintSeverity> value)
	{
		ConstraintSeverity? a_ = value?.Value;
		string b_ = context.Operators.Convert<string>(a_);

		return b_;
	}

    [CqlDeclaration("ToString")]
	public  string ToString(CqlContext context, Code<ContactPoint.ContactPointSystem> value)
	{
		ContactPoint.ContactPointSystem? a_ = value?.Value;
		string b_ = context.Operators.Convert<string>(a_);

		return b_;
	}

    [CqlDeclaration("ToString")]
	public  string ToString(CqlContext context, Code<ContactPoint.ContactPointUse> value)
	{
		ContactPoint.ContactPointUse? a_ = value?.Value;
		string b_ = context.Operators.Convert<string>(a_);

		return b_;
	}

    [CqlDeclaration("ToString")]
	public  string ToString(CqlContext context, Code<Contract.ContractResourcePublicationStatusCodes> value)
	{
		Contract.ContractResourcePublicationStatusCodes? a_ = value?.Value;
		string b_ = context.Operators.Convert<string>(a_);

		return b_;
	}

    [CqlDeclaration("ToString")]
	public  string ToString(CqlContext context, Code<Contract.ContractResourceStatusCodes> value)
	{
		Contract.ContractResourceStatusCodes? a_ = value?.Value;
		string b_ = context.Operators.Convert<string>(a_);

		return b_;
	}

    [CqlDeclaration("ToString")]
	public  string ToString(CqlContext context, Code<Contributor.ContributorType> value)
	{
		Contributor.ContributorType? a_ = value?.Value;
		string b_ = context.Operators.Convert<string>(a_);

		return b_;
	}

    [CqlDeclaration("ToString")]
	public  string ToString(CqlContext context, Code<Money.Currencies> value)
	{
		Money.Currencies? a_ = value?.Value;
		string b_ = context.Operators.Convert<string>(a_);

		return b_;
	}

    [CqlDeclaration("ToString")]
	public  string ToString(CqlContext context, Code<DaysOfWeek> value)
	{
		DaysOfWeek? a_ = value?.Value;
		string b_ = context.Operators.Convert<string>(a_);

		return b_;
	}

    [CqlDeclaration("ToString")]
	public  string ToString(CqlContext context, Code<DetectedIssue.DetectedIssueSeverity> value)
	{
		DetectedIssue.DetectedIssueSeverity? a_ = value?.Value;
		string b_ = context.Operators.Convert<string>(a_);

		return b_;
	}

    [CqlDeclaration("ToString")]
	public  string ToString(CqlContext context, Code<ObservationStatus> value)
	{
		ObservationStatus? a_ = value?.Value;
		string b_ = context.Operators.Convert<string>(a_);

		return b_;
	}

    [CqlDeclaration("ToString")]
	public  string ToString(CqlContext context, Code<DeviceMetric.DeviceMetricCalibrationState> value)
	{
		DeviceMetric.DeviceMetricCalibrationState? a_ = value?.Value;
		string b_ = context.Operators.Convert<string>(a_);

		return b_;
	}

    [CqlDeclaration("ToString")]
	public  string ToString(CqlContext context, Code<DeviceMetric.DeviceMetricCalibrationType> value)
	{
		DeviceMetric.DeviceMetricCalibrationType? a_ = value?.Value;
		string b_ = context.Operators.Convert<string>(a_);

		return b_;
	}

    [CqlDeclaration("ToString")]
	public  string ToString(CqlContext context, Code<DeviceMetric.DeviceMetricCategory> value)
	{
		DeviceMetric.DeviceMetricCategory? a_ = value?.Value;
		string b_ = context.Operators.Convert<string>(a_);

		return b_;
	}

    [CqlDeclaration("ToString")]
	public  string ToString(CqlContext context, Code<DeviceMetric.DeviceMetricColor> value)
	{
		DeviceMetric.DeviceMetricColor? a_ = value?.Value;
		string b_ = context.Operators.Convert<string>(a_);

		return b_;
	}

    [CqlDeclaration("ToString")]
	public  string ToString(CqlContext context, Code<DeviceMetric.DeviceMetricOperationalStatus> value)
	{
		DeviceMetric.DeviceMetricOperationalStatus? a_ = value?.Value;
		string b_ = context.Operators.Convert<string>(a_);

		return b_;
	}

    [CqlDeclaration("ToString")]
	public  string ToString(CqlContext context, Code<DeviceNameType> value)
	{
		DeviceNameType? a_ = value?.Value;
		string b_ = context.Operators.Convert<string>(a_);

		return b_;
	}

    [CqlDeclaration("ToString")]
	public  string ToString(CqlContext context, Code<DeviceUseStatement.DeviceUseStatementStatus> value)
	{
		DeviceUseStatement.DeviceUseStatementStatus? a_ = value?.Value;
		string b_ = context.Operators.Convert<string>(a_);

		return b_;
	}

    [CqlDeclaration("ToString")]
	public  string ToString(CqlContext context, Code<DiagnosticReport.DiagnosticReportStatus> value)
	{
		DiagnosticReport.DiagnosticReportStatus? a_ = value?.Value;
		string b_ = context.Operators.Convert<string>(a_);

		return b_;
	}

    [CqlDeclaration("ToString")]
	public  string ToString(CqlContext context, Code<ElementDefinition.DiscriminatorType> value)
	{
		ElementDefinition.DiscriminatorType? a_ = value?.Value;
		string b_ = context.Operators.Convert<string>(a_);

		return b_;
	}

    [CqlDeclaration("ToString")]
	public  string ToString(CqlContext context, Code<Composition.V3ConfidentialityClassification> value)
	{
		Composition.V3ConfidentialityClassification? a_ = value?.Value;
		string b_ = context.Operators.Convert<string>(a_);

		return b_;
	}

    [CqlDeclaration("ToString")]
	public  string ToString(CqlContext context, Code<CapabilityStatement.DocumentMode> value)
	{
		CapabilityStatement.DocumentMode? a_ = value?.Value;
		string b_ = context.Operators.Convert<string>(a_);

		return b_;
	}

    [CqlDeclaration("ToString")]
	public  string ToString(CqlContext context, Code<DocumentReferenceStatus> value)
	{
		DocumentReferenceStatus? a_ = value?.Value;
		string b_ = context.Operators.Convert<string>(a_);

		return b_;
	}

    [CqlDeclaration("ToString")]
	public  string ToString(CqlContext context, Code<DocumentRelationshipType> value)
	{
		DocumentRelationshipType? a_ = value?.Value;
		string b_ = context.Operators.Convert<string>(a_);

		return b_;
	}

    [CqlDeclaration("ToString")]
	public  string ToString(CqlContext context, Code<CoverageEligibilityRequest.EligibilityRequestPurpose> value)
	{
		CoverageEligibilityRequest.EligibilityRequestPurpose? a_ = value?.Value;
		string b_ = context.Operators.Convert<string>(a_);

		return b_;
	}

    [CqlDeclaration("ToString")]
	public  string ToString(CqlContext context, Code<CoverageEligibilityResponse.EligibilityResponsePurpose> value)
	{
		CoverageEligibilityResponse.EligibilityResponsePurpose? a_ = value?.Value;
		string b_ = context.Operators.Convert<string>(a_);

		return b_;
	}

    [CqlDeclaration("ToString")]
	public  string ToString(CqlContext context, Code<Questionnaire.EnableWhenBehavior> value)
	{
		Questionnaire.EnableWhenBehavior? a_ = value?.Value;
		string b_ = context.Operators.Convert<string>(a_);

		return b_;
	}

    [CqlDeclaration("ToString")]
	public  string ToString(CqlContext context, Code<Encounter.EncounterLocationStatus> value)
	{
		Encounter.EncounterLocationStatus? a_ = value?.Value;
		string b_ = context.Operators.Convert<string>(a_);

		return b_;
	}

    [CqlDeclaration("ToString")]
	public  string ToString(CqlContext context, Code<Encounter.EncounterStatus> value)
	{
		Encounter.EncounterStatus? a_ = value?.Value;
		string b_ = context.Operators.Convert<string>(a_);

		return b_;
	}

    [CqlDeclaration("ToString")]
	public  string ToString(CqlContext context, Code<Endpoint.EndpointStatus> value)
	{
		Endpoint.EndpointStatus? a_ = value?.Value;
		string b_ = context.Operators.Convert<string>(a_);

		return b_;
	}

    [CqlDeclaration("ToString")]
	public  string ToString(CqlContext context, Code<EpisodeOfCare.EpisodeOfCareStatus> value)
	{
		EpisodeOfCare.EpisodeOfCareStatus? a_ = value?.Value;
		string b_ = context.Operators.Convert<string>(a_);

		return b_;
	}

    [CqlDeclaration("ToString")]
	public  string ToString(CqlContext context, Code<CapabilityStatement.EventCapabilityMode> value)
	{
		CapabilityStatement.EventCapabilityMode? a_ = value?.Value;
		string b_ = context.Operators.Convert<string>(a_);

		return b_;
	}

    [CqlDeclaration("ToString")]
	public  string ToString(CqlContext context, Code<Timing.EventTiming> value)
	{
		Timing.EventTiming? a_ = value?.Value;
		string b_ = context.Operators.Convert<string>(a_);

		return b_;
	}

    [CqlDeclaration("ToString")]
	public  string ToString(CqlContext context, Code<VariableTypeCode> value)
	{
		VariableTypeCode? a_ = value?.Value;
		string b_ = context.Operators.Convert<string>(a_);

		return b_;
	}

    [CqlDeclaration("ToString")]
	public  string ToString(CqlContext context, Code<ExampleScenario.ExampleScenarioActorType> value)
	{
		ExampleScenario.ExampleScenarioActorType? a_ = value?.Value;
		string b_ = context.Operators.Convert<string>(a_);

		return b_;
	}

    [CqlDeclaration("ToString")]
	public  string ToString(CqlContext context, Code<ExplanationOfBenefit.ExplanationOfBenefitStatus> value)
	{
		ExplanationOfBenefit.ExplanationOfBenefitStatus? a_ = value?.Value;
		string b_ = context.Operators.Convert<string>(a_);

		return b_;
	}

    [CqlDeclaration("ToString")]
	public  string ToString(CqlContext context, Code<EffectEvidenceSynthesis.ExposureStateCode> value)
	{
		EffectEvidenceSynthesis.ExposureStateCode? a_ = value?.Value;
		string b_ = context.Operators.Convert<string>(a_);

		return b_;
	}

    [CqlDeclaration("ToString")]
	public  string ToString(CqlContext context, Code<StructureDefinition.ExtensionContextType> value)
	{
		StructureDefinition.ExtensionContextType? a_ = value?.Value;
		string b_ = context.Operators.Convert<string>(a_);

		return b_;
	}

    [CqlDeclaration("ToString")]
	public  string ToString(CqlContext context, Code<FHIRAllTypes> value)
	{
		FHIRAllTypes? a_ = value?.Value;
		string b_ = context.Operators.Convert<string>(a_);

		return b_;
	}

    [CqlDeclaration("ToString")]
	public  string ToString(CqlContext context, Code<FHIRDefinedType> value)
	{
		FHIRDefinedType? a_ = value?.Value;
		string b_ = context.Operators.Convert<string>(a_);

		return b_;
	}

    [CqlDeclaration("ToString")]
	public  string ToString(CqlContext context, Code<Device.FHIRDeviceStatus> value)
	{
		Device.FHIRDeviceStatus? a_ = value?.Value;
		string b_ = context.Operators.Convert<string>(a_);

		return b_;
	}

    [CqlDeclaration("ToString")]
	public  string ToString(CqlContext context, Code<ResourceType> value)
	{
		ResourceType? a_ = value?.Value;
		string b_ = context.Operators.Convert<string>(a_);

		return b_;
	}

    [CqlDeclaration("ToString")]
	public  string ToString(CqlContext context, Code<Substance.FHIRSubstanceStatus> value)
	{
		Substance.FHIRSubstanceStatus? a_ = value?.Value;
		string b_ = context.Operators.Convert<string>(a_);

		return b_;
	}

    [CqlDeclaration("ToString")]
	public  string ToString(CqlContext context, Code<FHIRVersion> value)
	{
		FHIRVersion? a_ = value?.Value;
		string b_ = context.Operators.Convert<string>(a_);

		return b_;
	}

    [CqlDeclaration("ToString")]
	public  string ToString(CqlContext context, Code<FamilyMemberHistory.FamilyHistoryStatus> value)
	{
		FamilyMemberHistory.FamilyHistoryStatus? a_ = value?.Value;
		string b_ = context.Operators.Convert<string>(a_);

		return b_;
	}

    [CqlDeclaration("ToString")]
	public  string ToString(CqlContext context, Code<FilterOperator> value)
	{
		FilterOperator? a_ = value?.Value;
		string b_ = context.Operators.Convert<string>(a_);

		return b_;
	}

    [CqlDeclaration("ToString")]
	public  string ToString(CqlContext context, Code<Flag.FlagStatus> value)
	{
		Flag.FlagStatus? a_ = value?.Value;
		string b_ = context.Operators.Convert<string>(a_);

		return b_;
	}

    [CqlDeclaration("ToString")]
	public  string ToString(CqlContext context, Code<Goal.GoalLifecycleStatus> value)
	{
		Goal.GoalLifecycleStatus? a_ = value?.Value;
		string b_ = context.Operators.Convert<string>(a_);

		return b_;
	}

    [CqlDeclaration("ToString")]
	public  string ToString(CqlContext context, Code<GraphDefinition.GraphCompartmentRule> value)
	{
		GraphDefinition.GraphCompartmentRule? a_ = value?.Value;
		string b_ = context.Operators.Convert<string>(a_);

		return b_;
	}

    [CqlDeclaration("ToString")]
	public  string ToString(CqlContext context, Code<GraphDefinition.GraphCompartmentUse> value)
	{
		GraphDefinition.GraphCompartmentUse? a_ = value?.Value;
		string b_ = context.Operators.Convert<string>(a_);

		return b_;
	}

    [CqlDeclaration("ToString")]
	public  string ToString(CqlContext context, Code<GroupMeasureCode> value)
	{
		GroupMeasureCode? a_ = value?.Value;
		string b_ = context.Operators.Convert<string>(a_);

		return b_;
	}

    [CqlDeclaration("ToString")]
	public  string ToString(CqlContext context, Code<Group.GroupType> value)
	{
		Group.GroupType? a_ = value?.Value;
		string b_ = context.Operators.Convert<string>(a_);

		return b_;
	}

    [CqlDeclaration("ToString")]
	public  string ToString(CqlContext context, Code<GuidanceResponse.GuidanceResponseStatus> value)
	{
		GuidanceResponse.GuidanceResponseStatus? a_ = value?.Value;
		string b_ = context.Operators.Convert<string>(a_);

		return b_;
	}

    [CqlDeclaration("ToString")]
	public  string ToString(CqlContext context, Code<ImplementationGuide.GuidePageGeneration> value)
	{
		ImplementationGuide.GuidePageGeneration? a_ = value?.Value;
		string b_ = context.Operators.Convert<string>(a_);

		return b_;
	}

    [CqlDeclaration("ToString")]
	public  string ToString(CqlContext context, Code<ImplementationGuide.GuideParameterCode> value)
	{
		ImplementationGuide.GuideParameterCode? a_ = value?.Value;
		string b_ = context.Operators.Convert<string>(a_);

		return b_;
	}

    [CqlDeclaration("ToString")]
	public  string ToString(CqlContext context, Code<Bundle.HTTPVerb> value)
	{
		Bundle.HTTPVerb? a_ = value?.Value;
		string b_ = context.Operators.Convert<string>(a_);

		return b_;
	}

    [CqlDeclaration("ToString")]
	public  string ToString(CqlContext context, Code<Identifier.IdentifierUse> value)
	{
		Identifier.IdentifierUse? a_ = value?.Value;
		string b_ = context.Operators.Convert<string>(a_);

		return b_;
	}

    [CqlDeclaration("ToString")]
	public  string ToString(CqlContext context, Code<Person.IdentityAssuranceLevel> value)
	{
		Person.IdentityAssuranceLevel? a_ = value?.Value;
		string b_ = context.Operators.Convert<string>(a_);

		return b_;
	}

    [CqlDeclaration("ToString")]
	public  string ToString(CqlContext context, Code<ImagingStudy.ImagingStudyStatus> value)
	{
		ImagingStudy.ImagingStudyStatus? a_ = value?.Value;
		string b_ = context.Operators.Convert<string>(a_);

		return b_;
	}

    [CqlDeclaration("ToString")]
	public  string ToString(CqlContext context, Code<ImmunizationEvaluation.ImmunizationEvaluationStatusCodes> value)
	{
		ImmunizationEvaluation.ImmunizationEvaluationStatusCodes? a_ = value?.Value;
		string b_ = context.Operators.Convert<string>(a_);

		return b_;
	}

    [CqlDeclaration("ToString")]
	public  string ToString(CqlContext context, Code<Immunization.ImmunizationStatusCodes> value)
	{
		Immunization.ImmunizationStatusCodes? a_ = value?.Value;
		string b_ = context.Operators.Convert<string>(a_);

		return b_;
	}

    [CqlDeclaration("ToString")]
	public  string ToString(CqlContext context, Code<Invoice.InvoiceStatus> value)
	{
		Invoice.InvoiceStatus? a_ = value?.Value;
		string b_ = context.Operators.Convert<string>(a_);

		return b_;
	}

    [CqlDeclaration("ToString")]
	public  string ToString(CqlContext context, Code<OperationOutcome.IssueSeverity> value)
	{
		OperationOutcome.IssueSeverity? a_ = value?.Value;
		string b_ = context.Operators.Convert<string>(a_);

		return b_;
	}

    [CqlDeclaration("ToString")]
	public  string ToString(CqlContext context, Code<OperationOutcome.IssueType> value)
	{
		OperationOutcome.IssueType? a_ = value?.Value;
		string b_ = context.Operators.Convert<string>(a_);

		return b_;
	}

    [CqlDeclaration("ToString")]
	public  string ToString(CqlContext context, Code<Patient.LinkType> value)
	{
		Patient.LinkType? a_ = value?.Value;
		string b_ = context.Operators.Convert<string>(a_);

		return b_;
	}

    [CqlDeclaration("ToString")]
	public  string ToString(CqlContext context, Code<Linkage.LinkageType> value)
	{
		Linkage.LinkageType? a_ = value?.Value;
		string b_ = context.Operators.Convert<string>(a_);

		return b_;
	}

    [CqlDeclaration("ToString")]
	public  string ToString(CqlContext context, Code<ListMode> value)
	{
		ListMode? a_ = value?.Value;
		string b_ = context.Operators.Convert<string>(a_);

		return b_;
	}

    [CqlDeclaration("ToString")]
	public  string ToString(CqlContext context, Code<List.ListStatus> value)
	{
		List.ListStatus? a_ = value?.Value;
		string b_ = context.Operators.Convert<string>(a_);

		return b_;
	}

    [CqlDeclaration("ToString")]
	public  string ToString(CqlContext context, Code<Location.LocationMode> value)
	{
		Location.LocationMode? a_ = value?.Value;
		string b_ = context.Operators.Convert<string>(a_);

		return b_;
	}

    [CqlDeclaration("ToString")]
	public  string ToString(CqlContext context, Code<Location.LocationStatus> value)
	{
		Location.LocationStatus? a_ = value?.Value;
		string b_ = context.Operators.Convert<string>(a_);

		return b_;
	}

    [CqlDeclaration("ToString")]
	public  string ToString(CqlContext context, Code<MeasureReport.MeasureReportStatus> value)
	{
		MeasureReport.MeasureReportStatus? a_ = value?.Value;
		string b_ = context.Operators.Convert<string>(a_);

		return b_;
	}

    [CqlDeclaration("ToString")]
	public  string ToString(CqlContext context, Code<MeasureReport.MeasureReportType> value)
	{
		MeasureReport.MeasureReportType? a_ = value?.Value;
		string b_ = context.Operators.Convert<string>(a_);

		return b_;
	}

    [CqlDeclaration("ToString")]
	public  string ToString(CqlContext context, Code<MedicationAdministration.MedicationAdministrationStatusCodes> value)
	{
		MedicationAdministration.MedicationAdministrationStatusCodes? a_ = value?.Value;
		string b_ = context.Operators.Convert<string>(a_);

		return b_;
	}

    [CqlDeclaration("ToString")]
	public  string ToString(CqlContext context, Code<MedicationDispense.MedicationDispenseStatusCodes> value)
	{
		MedicationDispense.MedicationDispenseStatusCodes? a_ = value?.Value;
		string b_ = context.Operators.Convert<string>(a_);

		return b_;
	}

    [CqlDeclaration("ToString")]
	public  string ToString(CqlContext context, Code<MedicationKnowledge.MedicationKnowledgeStatusCodes> value)
	{
		MedicationKnowledge.MedicationKnowledgeStatusCodes? a_ = value?.Value;
		string b_ = context.Operators.Convert<string>(a_);

		return b_;
	}

    [CqlDeclaration("ToString")]
	public  string ToString(CqlContext context, Code<MedicationRequest.MedicationRequestIntent> value)
	{
		MedicationRequest.MedicationRequestIntent? a_ = value?.Value;
		string b_ = context.Operators.Convert<string>(a_);

		return b_;
	}

    [CqlDeclaration("ToString")]
	public  string ToString(CqlContext context, Code<MedicationRequest.MedicationrequestStatus> value)
	{
		MedicationRequest.MedicationrequestStatus? a_ = value?.Value;
		string b_ = context.Operators.Convert<string>(a_);

		return b_;
	}

    [CqlDeclaration("ToString")]
	public  string ToString(CqlContext context, Code<MedicationStatement.MedicationStatusCodes> value)
	{
		MedicationStatement.MedicationStatusCodes? a_ = value?.Value;
		string b_ = context.Operators.Convert<string>(a_);

		return b_;
	}

    [CqlDeclaration("ToString")]
	public  string ToString(CqlContext context, Code<Medication.MedicationStatusCodes> value)
	{
		Medication.MedicationStatusCodes? a_ = value?.Value;
		string b_ = context.Operators.Convert<string>(a_);

		return b_;
	}

    [CqlDeclaration("ToString")]
	public  string ToString(CqlContext context, Code<MessageDefinition.MessageSignificanceCategory> value)
	{
		MessageDefinition.MessageSignificanceCategory? a_ = value?.Value;
		string b_ = context.Operators.Convert<string>(a_);

		return b_;
	}

    [CqlDeclaration("ToString")]
	public  string ToString(CqlContext context, Code<MessageheaderResponseRequest> value)
	{
		MessageheaderResponseRequest? a_ = value?.Value;
		string b_ = context.Operators.Convert<string>(a_);

		return b_;
	}

    [CqlDeclaration("ToString")]
	public  string ToString(CqlContext context, Code value)
	{
		string a_ = value?.Value;

		return a_;
	}

    [CqlDeclaration("ToString")]
	public  string ToString(CqlContext context, Code<HumanName.NameUse> value)
	{
		HumanName.NameUse? a_ = value?.Value;
		string b_ = context.Operators.Convert<string>(a_);

		return b_;
	}

    [CqlDeclaration("ToString")]
	public  string ToString(CqlContext context, Code<NamingSystem.NamingSystemIdentifierType> value)
	{
		NamingSystem.NamingSystemIdentifierType? a_ = value?.Value;
		string b_ = context.Operators.Convert<string>(a_);

		return b_;
	}

    [CqlDeclaration("ToString")]
	public  string ToString(CqlContext context, Code<NamingSystem.NamingSystemType> value)
	{
		NamingSystem.NamingSystemType? a_ = value?.Value;
		string b_ = context.Operators.Convert<string>(a_);

		return b_;
	}

    [CqlDeclaration("ToString")]
	public  string ToString(CqlContext context, Code<Narrative.NarrativeStatus> value)
	{
		Narrative.NarrativeStatus? a_ = value?.Value;
		string b_ = context.Operators.Convert<string>(a_);

		return b_;
	}

    [CqlDeclaration("ToString")]
	public  string ToString(CqlContext context, Code<NoteType> value)
	{
		NoteType? a_ = value?.Value;
		string b_ = context.Operators.Convert<string>(a_);

		return b_;
	}

    [CqlDeclaration("ToString")]
	public  string ToString(CqlContext context, Code<RequestIntent> value)
	{
		RequestIntent? a_ = value?.Value;
		string b_ = context.Operators.Convert<string>(a_);

		return b_;
	}

    [CqlDeclaration("ToString")]
	public  string ToString(CqlContext context, Code<ObservationDefinition.ObservationDataType> value)
	{
		ObservationDefinition.ObservationDataType? a_ = value?.Value;
		string b_ = context.Operators.Convert<string>(a_);

		return b_;
	}

    [CqlDeclaration("ToString")]
	public  string ToString(CqlContext context, Code<ObservationDefinition.ObservationRangeCategory> value)
	{
		ObservationDefinition.ObservationRangeCategory? a_ = value?.Value;
		string b_ = context.Operators.Convert<string>(a_);

		return b_;
	}

    [CqlDeclaration("ToString")]
	public  string ToString(CqlContext context, Code<OperationDefinition.OperationKind> value)
	{
		OperationDefinition.OperationKind? a_ = value?.Value;
		string b_ = context.Operators.Convert<string>(a_);

		return b_;
	}

    [CqlDeclaration("ToString")]
	public  string ToString(CqlContext context, Code<OperationParameterUse> value)
	{
		OperationParameterUse? a_ = value?.Value;
		string b_ = context.Operators.Convert<string>(a_);

		return b_;
	}

    [CqlDeclaration("ToString")]
	public  string ToString(CqlContext context, Code<MolecularSequence.OrientationType> value)
	{
		MolecularSequence.OrientationType? a_ = value?.Value;
		string b_ = context.Operators.Convert<string>(a_);

		return b_;
	}

    [CqlDeclaration("ToString")]
	public  string ToString(CqlContext context, Code<Appointment.ParticipantRequired> value)
	{
		Appointment.ParticipantRequired? a_ = value?.Value;
		string b_ = context.Operators.Convert<string>(a_);

		return b_;
	}

    [CqlDeclaration("ToString")]
	public  string ToString(CqlContext context, Code<ParticipationStatus> value)
	{
		ParticipationStatus? a_ = value?.Value;
		string b_ = context.Operators.Convert<string>(a_);

		return b_;
	}

    [CqlDeclaration("ToString")]
	public  string ToString(CqlContext context, Code<ElementDefinition.PropertyRepresentation> value)
	{
		ElementDefinition.PropertyRepresentation? a_ = value?.Value;
		string b_ = context.Operators.Convert<string>(a_);

		return b_;
	}

    [CqlDeclaration("ToString")]
	public  string ToString(CqlContext context, Code<CodeSystem.PropertyType> value)
	{
		CodeSystem.PropertyType? a_ = value?.Value;
		string b_ = context.Operators.Convert<string>(a_);

		return b_;
	}

    [CqlDeclaration("ToString")]
	public  string ToString(CqlContext context, Code<Provenance.ProvenanceEntityRole> value)
	{
		Provenance.ProvenanceEntityRole? a_ = value?.Value;
		string b_ = context.Operators.Convert<string>(a_);

		return b_;
	}

    [CqlDeclaration("ToString")]
	public  string ToString(CqlContext context, Code<PublicationStatus> value)
	{
		PublicationStatus? a_ = value?.Value;
		string b_ = context.Operators.Convert<string>(a_);

		return b_;
	}

    [CqlDeclaration("ToString")]
	public  string ToString(CqlContext context, Code<MolecularSequence.QualityType> value)
	{
		MolecularSequence.QualityType? a_ = value?.Value;
		string b_ = context.Operators.Convert<string>(a_);

		return b_;
	}

    [CqlDeclaration("ToString")]
	public  string ToString(CqlContext context, Code<Quantity.QuantityComparator> value)
	{
		Quantity.QuantityComparator? a_ = value?.Value;
		string b_ = context.Operators.Convert<string>(a_);

		return b_;
	}

    [CqlDeclaration("ToString")]
	public  string ToString(CqlContext context, Code<Questionnaire.QuestionnaireItemOperator> value)
	{
		Questionnaire.QuestionnaireItemOperator? a_ = value?.Value;
		string b_ = context.Operators.Convert<string>(a_);

		return b_;
	}

    [CqlDeclaration("ToString")]
	public  string ToString(CqlContext context, Code<Questionnaire.QuestionnaireItemType> value)
	{
		Questionnaire.QuestionnaireItemType? a_ = value?.Value;
		string b_ = context.Operators.Convert<string>(a_);

		return b_;
	}

    [CqlDeclaration("ToString")]
	public  string ToString(CqlContext context, Code<QuestionnaireResponse.QuestionnaireResponseStatus> value)
	{
		QuestionnaireResponse.QuestionnaireResponseStatus? a_ = value?.Value;
		string b_ = context.Operators.Convert<string>(a_);

		return b_;
	}

    [CqlDeclaration("ToString")]
	public  string ToString(CqlContext context, Code<CapabilityStatement.ReferenceHandlingPolicy> value)
	{
		CapabilityStatement.ReferenceHandlingPolicy? a_ = value?.Value;
		string b_ = context.Operators.Convert<string>(a_);

		return b_;
	}

    [CqlDeclaration("ToString")]
	public  string ToString(CqlContext context, Code<ElementDefinition.ReferenceVersionRules> value)
	{
		ElementDefinition.ReferenceVersionRules? a_ = value?.Value;
		string b_ = context.Operators.Convert<string>(a_);

		return b_;
	}

    [CqlDeclaration("ToString")]
	public  string ToString(CqlContext context, Code<RelatedArtifact.RelatedArtifactType> value)
	{
		RelatedArtifact.RelatedArtifactType? a_ = value?.Value;
		string b_ = context.Operators.Convert<string>(a_);

		return b_;
	}

    [CqlDeclaration("ToString")]
	public  string ToString(CqlContext context, Code<ClaimProcessingCodes> value)
	{
		ClaimProcessingCodes? a_ = value?.Value;
		string b_ = context.Operators.Convert<string>(a_);

		return b_;
	}

    [CqlDeclaration("ToString")]
	public  string ToString(CqlContext context, Code<MolecularSequence.RepositoryType> value)
	{
		MolecularSequence.RepositoryType? a_ = value?.Value;
		string b_ = context.Operators.Convert<string>(a_);

		return b_;
	}

    [CqlDeclaration("ToString")]
	public  string ToString(CqlContext context, Code<ResearchElementDefinition.ResearchElementType> value)
	{
		ResearchElementDefinition.ResearchElementType? a_ = value?.Value;
		string b_ = context.Operators.Convert<string>(a_);

		return b_;
	}

    [CqlDeclaration("ToString")]
	public  string ToString(CqlContext context, Code<ResearchStudy.ResearchStudyStatus> value)
	{
		ResearchStudy.ResearchStudyStatus? a_ = value?.Value;
		string b_ = context.Operators.Convert<string>(a_);

		return b_;
	}

    [CqlDeclaration("ToString")]
	public  string ToString(CqlContext context, Code<ResearchSubject.ResearchSubjectStatus> value)
	{
		ResearchSubject.ResearchSubjectStatus? a_ = value?.Value;
		string b_ = context.Operators.Convert<string>(a_);

		return b_;
	}

    [CqlDeclaration("ToString")]
	public  string ToString(CqlContext context, Code<CapabilityStatement.ResourceVersionPolicy> value)
	{
		CapabilityStatement.ResourceVersionPolicy? a_ = value?.Value;
		string b_ = context.Operators.Convert<string>(a_);

		return b_;
	}

    [CqlDeclaration("ToString")]
	public  string ToString(CqlContext context, Code<MessageHeader.ResponseType> value)
	{
		MessageHeader.ResponseType? a_ = value?.Value;
		string b_ = context.Operators.Convert<string>(a_);

		return b_;
	}

    [CqlDeclaration("ToString")]
	public  string ToString(CqlContext context, Code<CapabilityStatement.RestfulCapabilityMode> value)
	{
		CapabilityStatement.RestfulCapabilityMode? a_ = value?.Value;
		string b_ = context.Operators.Convert<string>(a_);

		return b_;
	}

    [CqlDeclaration("ToString")]
	public  string ToString(CqlContext context, Code<ImplementationGuide.SPDXLicense> value)
	{
		ImplementationGuide.SPDXLicense? a_ = value?.Value;
		string b_ = context.Operators.Convert<string>(a_);

		return b_;
	}

    [CqlDeclaration("ToString")]
	public  string ToString(CqlContext context, Code<SearchParameter.SearchComparator> value)
	{
		SearchParameter.SearchComparator? a_ = value?.Value;
		string b_ = context.Operators.Convert<string>(a_);

		return b_;
	}

    [CqlDeclaration("ToString")]
	public  string ToString(CqlContext context, Code<Bundle.SearchEntryMode> value)
	{
		Bundle.SearchEntryMode? a_ = value?.Value;
		string b_ = context.Operators.Convert<string>(a_);

		return b_;
	}

    [CqlDeclaration("ToString")]
	public  string ToString(CqlContext context, Code<SearchParameter.SearchModifierCode> value)
	{
		SearchParameter.SearchModifierCode? a_ = value?.Value;
		string b_ = context.Operators.Convert<string>(a_);

		return b_;
	}

    [CqlDeclaration("ToString")]
	public  string ToString(CqlContext context, Code<SearchParamType> value)
	{
		SearchParamType? a_ = value?.Value;
		string b_ = context.Operators.Convert<string>(a_);

		return b_;
	}

    [CqlDeclaration("ToString")]
	public  string ToString(CqlContext context, Code<MolecularSequence.SequenceType> value)
	{
		MolecularSequence.SequenceType? a_ = value?.Value;
		string b_ = context.Operators.Convert<string>(a_);

		return b_;
	}

    [CqlDeclaration("ToString")]
	public  string ToString(CqlContext context, Code<ElementDefinition.SlicingRules> value)
	{
		ElementDefinition.SlicingRules? a_ = value?.Value;
		string b_ = context.Operators.Convert<string>(a_);

		return b_;
	}

    [CqlDeclaration("ToString")]
	public  string ToString(CqlContext context, Code<Slot.SlotStatus> value)
	{
		Slot.SlotStatus? a_ = value?.Value;
		string b_ = context.Operators.Convert<string>(a_);

		return b_;
	}

    [CqlDeclaration("ToString")]
	public  string ToString(CqlContext context, Code<DataRequirement.SortDirection> value)
	{
		DataRequirement.SortDirection? a_ = value?.Value;
		string b_ = context.Operators.Convert<string>(a_);

		return b_;
	}

    [CqlDeclaration("ToString")]
	public  string ToString(CqlContext context, Code<SpecimenDefinition.SpecimenContainedPreference> value)
	{
		SpecimenDefinition.SpecimenContainedPreference? a_ = value?.Value;
		string b_ = context.Operators.Convert<string>(a_);

		return b_;
	}

    [CqlDeclaration("ToString")]
	public  string ToString(CqlContext context, Code<Specimen.SpecimenStatus> value)
	{
		Specimen.SpecimenStatus? a_ = value?.Value;
		string b_ = context.Operators.Convert<string>(a_);

		return b_;
	}

    [CqlDeclaration("ToString")]
	public  string ToString(CqlContext context, Code<VerificationResult.StatusCode> value)
	{
		VerificationResult.StatusCode? a_ = value?.Value;
		string b_ = context.Operators.Convert<string>(a_);

		return b_;
	}

    [CqlDeclaration("ToString")]
	public  string ToString(CqlContext context, Code<MolecularSequence.StrandType> value)
	{
		MolecularSequence.StrandType? a_ = value?.Value;
		string b_ = context.Operators.Convert<string>(a_);

		return b_;
	}

    [CqlDeclaration("ToString")]
	public  string ToString(CqlContext context, Code<StructureDefinition.StructureDefinitionKind> value)
	{
		StructureDefinition.StructureDefinitionKind? a_ = value?.Value;
		string b_ = context.Operators.Convert<string>(a_);

		return b_;
	}

    [CqlDeclaration("ToString")]
	public  string ToString(CqlContext context, Code<StructureMap.StructureMapContextType> value)
	{
		StructureMap.StructureMapContextType? a_ = value?.Value;
		string b_ = context.Operators.Convert<string>(a_);

		return b_;
	}

    [CqlDeclaration("ToString")]
	public  string ToString(CqlContext context, Code<StructureMap.StructureMapGroupTypeMode> value)
	{
		StructureMap.StructureMapGroupTypeMode? a_ = value?.Value;
		string b_ = context.Operators.Convert<string>(a_);

		return b_;
	}

    [CqlDeclaration("ToString")]
	public  string ToString(CqlContext context, Code<StructureMap.StructureMapInputMode> value)
	{
		StructureMap.StructureMapInputMode? a_ = value?.Value;
		string b_ = context.Operators.Convert<string>(a_);

		return b_;
	}

    [CqlDeclaration("ToString")]
	public  string ToString(CqlContext context, Code<StructureMap.StructureMapModelMode> value)
	{
		StructureMap.StructureMapModelMode? a_ = value?.Value;
		string b_ = context.Operators.Convert<string>(a_);

		return b_;
	}

    [CqlDeclaration("ToString")]
	public  string ToString(CqlContext context, Code<StructureMap.StructureMapSourceListMode> value)
	{
		StructureMap.StructureMapSourceListMode? a_ = value?.Value;
		string b_ = context.Operators.Convert<string>(a_);

		return b_;
	}

    [CqlDeclaration("ToString")]
	public  string ToString(CqlContext context, Code<StructureMap.StructureMapTargetListMode> value)
	{
		StructureMap.StructureMapTargetListMode? a_ = value?.Value;
		string b_ = context.Operators.Convert<string>(a_);

		return b_;
	}

    [CqlDeclaration("ToString")]
	public  string ToString(CqlContext context, Code<StructureMap.StructureMapTransform> value)
	{
		StructureMap.StructureMapTransform? a_ = value?.Value;
		string b_ = context.Operators.Convert<string>(a_);

		return b_;
	}

    [CqlDeclaration("ToString")]
	public  string ToString(CqlContext context, Code<Subscription.SubscriptionChannelType> value)
	{
		Subscription.SubscriptionChannelType? a_ = value?.Value;
		string b_ = context.Operators.Convert<string>(a_);

		return b_;
	}

    [CqlDeclaration("ToString")]
	public  string ToString(CqlContext context, Code<Subscription.SubscriptionStatus> value)
	{
		Subscription.SubscriptionStatus? a_ = value?.Value;
		string b_ = context.Operators.Convert<string>(a_);

		return b_;
	}

    [CqlDeclaration("ToString")]
	public  string ToString(CqlContext context, Code<SupplyDelivery.SupplyDeliveryStatus> value)
	{
		SupplyDelivery.SupplyDeliveryStatus? a_ = value?.Value;
		string b_ = context.Operators.Convert<string>(a_);

		return b_;
	}

    [CqlDeclaration("ToString")]
	public  string ToString(CqlContext context, Code<SupplyRequest.SupplyRequestStatus> value)
	{
		SupplyRequest.SupplyRequestStatus? a_ = value?.Value;
		string b_ = context.Operators.Convert<string>(a_);

		return b_;
	}

    [CqlDeclaration("ToString")]
	public  string ToString(CqlContext context, Code<CapabilityStatement.SystemRestfulInteraction> value)
	{
		CapabilityStatement.SystemRestfulInteraction? a_ = value?.Value;
		string b_ = context.Operators.Convert<string>(a_);

		return b_;
	}

    [CqlDeclaration("ToString")]
	public  string ToString(CqlContext context, Code<Task.TaskIntent> value)
	{
		Task.TaskIntent? a_ = value?.Value;
		string b_ = context.Operators.Convert<string>(a_);

		return b_;
	}

    [CqlDeclaration("ToString")]
	public  string ToString(CqlContext context, Code<Task.TaskStatus> value)
	{
		Task.TaskStatus? a_ = value?.Value;
		string b_ = context.Operators.Convert<string>(a_);

		return b_;
	}

    [CqlDeclaration("ToString")]
	public  string ToString(CqlContext context, Code<TestReport.TestReportActionResult> value)
	{
		TestReport.TestReportActionResult? a_ = value?.Value;
		string b_ = context.Operators.Convert<string>(a_);

		return b_;
	}

    [CqlDeclaration("ToString")]
	public  string ToString(CqlContext context, Code<TestReport.TestReportParticipantType> value)
	{
		TestReport.TestReportParticipantType? a_ = value?.Value;
		string b_ = context.Operators.Convert<string>(a_);

		return b_;
	}

    [CqlDeclaration("ToString")]
	public  string ToString(CqlContext context, Code<TestReport.TestReportResult> value)
	{
		TestReport.TestReportResult? a_ = value?.Value;
		string b_ = context.Operators.Convert<string>(a_);

		return b_;
	}

    [CqlDeclaration("ToString")]
	public  string ToString(CqlContext context, Code<TestReport.TestReportStatus> value)
	{
		TestReport.TestReportStatus? a_ = value?.Value;
		string b_ = context.Operators.Convert<string>(a_);

		return b_;
	}

    [CqlDeclaration("ToString")]
	public  string ToString(CqlContext context, Code<TestScript.TestScriptRequestMethodCode> value)
	{
		TestScript.TestScriptRequestMethodCode? a_ = value?.Value;
		string b_ = context.Operators.Convert<string>(a_);

		return b_;
	}

    [CqlDeclaration("ToString")]
	public  string ToString(CqlContext context, Code<TriggerDefinition.TriggerType> value)
	{
		TriggerDefinition.TriggerType? a_ = value?.Value;
		string b_ = context.Operators.Convert<string>(a_);

		return b_;
	}

    [CqlDeclaration("ToString")]
	public  string ToString(CqlContext context, Code<StructureDefinition.TypeDerivationRule> value)
	{
		StructureDefinition.TypeDerivationRule? a_ = value?.Value;
		string b_ = context.Operators.Convert<string>(a_);

		return b_;
	}

    [CqlDeclaration("ToString")]
	public  string ToString(CqlContext context, Code<CapabilityStatement.TypeRestfulInteraction> value)
	{
		CapabilityStatement.TypeRestfulInteraction? a_ = value?.Value;
		string b_ = context.Operators.Convert<string>(a_);

		return b_;
	}

    [CqlDeclaration("ToString")]
	public  string ToString(CqlContext context, Code<Device.UDIEntryType> value)
	{
		Device.UDIEntryType? a_ = value?.Value;
		string b_ = context.Operators.Convert<string>(a_);

		return b_;
	}

    [CqlDeclaration("ToString")]
	public  string ToString(CqlContext context, Code<Timing.UnitsOfTime> value)
	{
		Timing.UnitsOfTime? a_ = value?.Value;
		string b_ = context.Operators.Convert<string>(a_);

		return b_;
	}

    [CqlDeclaration("ToString")]
	public  string ToString(CqlContext context, Code<ClaimUseCode> value)
	{
		ClaimUseCode? a_ = value?.Value;
		string b_ = context.Operators.Convert<string>(a_);

		return b_;
	}

    [CqlDeclaration("ToString")]
	public  string ToString(CqlContext context, Code<VisionPrescription.VisionBase> value)
	{
		VisionPrescription.VisionBase? a_ = value?.Value;
		string b_ = context.Operators.Convert<string>(a_);

		return b_;
	}

    [CqlDeclaration("ToString")]
	public  string ToString(CqlContext context, Code<VisionPrescription.VisionEyes> value)
	{
		VisionPrescription.VisionEyes? a_ = value?.Value;
		string b_ = context.Operators.Convert<string>(a_);

		return b_;
	}

    [CqlDeclaration("ToString")]
	public  string ToString(CqlContext context, Code<SearchParameter.XPathUsageType> value)
	{
		SearchParameter.XPathUsageType? a_ = value?.Value;
		string b_ = context.Operators.Convert<string>(a_);

		return b_;
	}

    [CqlDeclaration("ToString")]
	public  string ToString(CqlContext context, Base64Binary value)
	{
		byte[] a_ = value?.Value;
		string b_ = context.Operators.Convert<string>(a_);

		return b_;
	}

    [CqlDeclaration("ToString")]
	public  string ToString(CqlContext context, Id value)
	{
		string a_ = value?.Value;

		return a_;
	}

    [CqlDeclaration("ToString")]
	public  string ToString(CqlContext context, FhirString value)
	{
		string a_ = value?.Value;

		return a_;
	}

    [CqlDeclaration("ToString")]
	public  string ToString(CqlContext context, FhirUri value)
	{
		string a_ = value?.Value;

		return a_;
	}

    [CqlDeclaration("ToString")]
	public  string ToString(CqlContext context, XHtml value)
	{
		string a_ = value?.Value;

		return a_;
	}

    [CqlDeclaration("ToBoolean")]
	public  bool? ToBoolean(CqlContext context, FhirBoolean value)
	{
		bool? a_ = value?.Value;

		return a_;
	}

    [CqlDeclaration("ToDate")]
	public  CqlDate ToDate(CqlContext context, Date value)
	{
		string a_ = value?.Value;
		CqlDate b_ = context.Operators.ConvertStringToDate(a_);

		return b_;
	}

    [CqlDeclaration("ToDateTime")]
	public  CqlDateTime ToDateTime(CqlContext context, FhirDateTime value)
	{
		CqlDateTime a_ = context.Operators.Convert<CqlDateTime>(value);

		return a_;
	}

    [CqlDeclaration("ToDateTime")]
	public  CqlDateTime ToDateTime(CqlContext context, Instant value)
	{
		DateTimeOffset? a_ = value?.Value;
		CqlDateTime b_ = context.Operators.Convert<CqlDateTime>(a_);

		return b_;
	}

    [CqlDeclaration("ToDecimal")]
	public  decimal? ToDecimal(CqlContext context, FhirDecimal value)
	{
		decimal? a_ = value?.Value;

		return a_;
	}

    [CqlDeclaration("ToInteger")]
	public  int? ToInteger(CqlContext context, Integer value)
	{
		int? a_ = value?.Value;

		return a_;
	}

    [CqlDeclaration("ToTime")]
	public  CqlTime ToTime(CqlContext context, Time value)
	{
		string a_ = value?.Value;
		CqlTime b_ = context.Operators.ConvertStringToTime(a_);

		return b_;
	}

}
