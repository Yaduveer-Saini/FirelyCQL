library FollowUpCareforChildrenPrescribedADHDMedicationADDFHIR version '0.1.000'

using QICore version '4.1.1'

include FHIRHelpers version '4.3.000' called FHIRHelpers
include SupplementalDataElements version '3.4.000' called SDE
include QICoreCommon version '2.0.000' called QICoreCommon
include CQMCommon version '2.0.000' called CQMCommon
include Hospice version '6.9.000' called Hospice
include CumulativeMedicationDuration version '4.0.000' called CMD

codesystem "RXNORM": 'http://www.nlm.nih.gov/research/umls/rxnorm'

valueset "Ambulatory": 'http://cts.nlm.nih.gov/fhir/ValueSet/2.16.840.1.113883.3.464.1003.122.12.1003'
valueset "Atomoxetine": 'http://cts.nlm.nih.gov/fhir/ValueSet/2.16.840.1.113883.3.464.1003.1170'
valueset "Behavioral Health Follow up Visit": 'http://cts.nlm.nih.gov/fhir/ValueSet/2.16.840.1.113883.3.464.1003.101.12.1054'
valueset "Clonidine": 'http://cts.nlm.nih.gov/fhir/ValueSet/2.16.840.1.113883.3.464.1003.1171'
valueset "Dexmethylphenidate": 'http://cts.nlm.nih.gov/fhir/ValueSet/2.16.840.1.113883.3.464.1003.1172'
valueset "Dextroamphetamine": 'http://cts.nlm.nih.gov/fhir/ValueSet/2.16.840.1.113883.3.464.1003.1173'
valueset "Encounter Inpatient": 'http://cts.nlm.nih.gov/fhir/ValueSet/2.16.840.1.113883.3.666.5.307'
valueset "Guanfacine": 'http://cts.nlm.nih.gov/fhir/ValueSet/2.16.840.1.113883.3.464.1003.196.11.1252'
valueset "Home Healthcare Services": 'http://cts.nlm.nih.gov/fhir/ValueSet/2.16.840.1.113883.3.464.1003.101.12.1016'
valueset "Initial Hospital Observation Care": 'http://cts.nlm.nih.gov/fhir/ValueSet/2.16.840.1.113883.3.464.1003.101.12.1002'
valueset "Lisdexamfetamine": 'http://cts.nlm.nih.gov/fhir/ValueSet/2.16.840.1.113883.3.464.1003.1174'
valueset "Mental Behavioral and Neurodevelopmental Disorders": 'http://cts.nlm.nih.gov/fhir/ValueSet/2.16.840.1.113883.3.464.1003.105.12.1203'
valueset "Methylphenidate": 'http://cts.nlm.nih.gov/fhir/ValueSet/2.16.840.1.113883.3.464.1003.1176'
valueset "Narcolepsy": 'http://cts.nlm.nih.gov/fhir/ValueSet/2.16.840.1.113883.3.464.1003.114.12.1011'
valueset "Office Visit": 'http://cts.nlm.nih.gov/fhir/ValueSet/2.16.840.1.113883.3.464.1003.101.12.1001'
valueset "Online Assessments": 'http://cts.nlm.nih.gov/fhir/ValueSet/2.16.840.1.113883.3.464.1003.101.12.1089'
valueset "Outpatient Consultation": 'http://cts.nlm.nih.gov/fhir/ValueSet/2.16.840.1.113883.3.464.1003.101.12.1008'
valueset "Preventive Care Services Group Counseling": 'http://cts.nlm.nih.gov/fhir/ValueSet/2.16.840.1.113883.3.464.1003.101.12.1027'
valueset "Preventive Care Services Individual Counseling": 'http://cts.nlm.nih.gov/fhir/ValueSet/2.16.840.1.113883.3.464.1003.101.12.1026'
valueset "Preventive Care Services, Initial Office Visit, 0 to 17": 'http://cts.nlm.nih.gov/fhir/ValueSet/2.16.840.1.113883.3.464.1003.101.12.1022'
valueset "Preventive Care, Established Office Visit, 0 to 17": 'http://cts.nlm.nih.gov/fhir/ValueSet/2.16.840.1.113883.3.464.1003.101.12.1024'
valueset "Psych Visit Diagnostic Evaluation": 'http://cts.nlm.nih.gov/fhir/ValueSet/2.16.840.1.113883.3.526.3.1492'
valueset "Psych Visit Psychotherapy": 'http://cts.nlm.nih.gov/fhir/ValueSet/2.16.840.1.113883.3.526.3.1496'
valueset "Psychotherapy and Pharmacologic Management": 'http://cts.nlm.nih.gov/fhir/ValueSet/2.16.840.1.113883.3.464.1003.101.12.1055'
valueset "Telephone Visits": 'http://cts.nlm.nih.gov/fhir/ValueSet/2.16.840.1.113883.3.464.1003.101.12.1080'

code "24 HR dexmethylphenidate hydrochloride 40 MG Extended Release Oral Capsule": '1006608' from "RXNORM" display '24 HR dexmethylphenidate hydrochloride 40 MG Extended Release Oral Capsule'
code "methamphetamine hydrochloride 5 MG Oral Tablet": '977860' from "RXNORM" display 'methamphetamine hydrochloride 5 MG Oral Tablet'

parameter "Measurement Period" Interval<DateTime>default Interval[@2025-01-01T00:00:00.0, @2026-01-01T00:00:00.0 )

context Patient

define "Initial Population 1":
  AgeInYearsAt(date from start of "Intake Period") >= 6
    and AgeInYearsAt(date from
      end of "Intake Period"
    ) <= 12
    and exists "Qualifying Encounter"
    and "First ADHD Medication Prescribed During Intake Period" is not null
    and not exists "Inpatient Stay with Qualifying Diagnosis During Initiation Phase"

define "Intake Period":
  Interval["March 1 of Year Prior to Measurement Period", "Last Calendar Day of February of Measurement Period"]

define "Last Calendar Day of February of Measurement Period":
  ( DateTime(year from start of "Measurement Period", 3, 1, 23, 59, 59, 0, 0) ) - 1 day

define "March 1 of Year Prior to Measurement Period":
  DateTime((year from start of "Measurement Period" - 1), 3, 1, 0, 0, 0, 0, 0)

define "Qualifying Encounter":
  ( ["Encounter": "Office Visit"]
    union ["Encounter": "Home Healthcare Services"]
    union ["Encounter": "Preventive Care, Established Office Visit, 0 to 17"]
    union ["Encounter": "Preventive Care Services, Initial Office Visit, 0 to 17"] ) ValidEncounters
    where QICoreCommon."ToInterval" ( ValidEncounters.period ) during day of Interval["IPSD" - 6 months, "IPSD"]

    /*Index Prescription Start Date (IPSD)*/


define "IPSD":
  "First ADHD Medication Prescribed During Intake Period"

define "First ADHD Medication Prescribed During Intake Period":
  First("ADHD Medication Prescribed During Intake Period and Not Previously on ADHD Medication".startDate)

define "ADHD Medication Prescribed During Intake Period and Not Previously on ADHD Medication":
  ( ( ( ["MedicationRequest": "Atomoxetine"]
    union ["MedicationRequest": "Clonidine"]
    union ["MedicationRequest": "Dexmethylphenidate"]
    union ["MedicationRequest": "Dextroamphetamine"]
    union ["MedicationRequest": "Lisdexamfetamine"]
    union ["MedicationRequest": "methamphetamine hydrochloride 5 MG Oral Tablet"]
    union ["MedicationRequest": "Methylphenidate"]
    union ["MedicationRequest": "Guanfacine"] ) ADHDMedications
    where CMD."MedicationRequestPeriod" ( ADHDMedications ) starts during "Intake Period" ) ADHDMedicationOrder
    without ( ["MedicationRequest": "Atomoxetine"]
      union ["MedicationRequest": "Clonidine"]
      union ["MedicationRequest": "Dexmethylphenidate"]
      union ["MedicationRequest": "Dextroamphetamine"]
      union ["MedicationRequest": "Lisdexamfetamine"]
      union ["MedicationRequest": "methamphetamine hydrochloride 5 MG Oral Tablet"]
      union ["MedicationRequest": "Methylphenidate"]
      union ["MedicationRequest": "Guanfacine"] ) ActiveADHDMedication
      such that CMD."MedicationRequestPeriod" ( ActiveADHDMedication ) overlaps Interval[date from start of CMD."MedicationRequestPeriod" ( ADHDMedicationOrder ) - 120 days, date from start of CMD."MedicationRequestPeriod" ( ADHDMedicationOrder ) ) ) QualifyingMed
    return all {
      startDate: start of CMD."MedicationRequestPeriod" ( QualifyingMed )
    }
    sort by startDate asc

define "Inpatient Stay with Qualifying Diagnosis During Initiation Phase":
  "Inpatient Stay with Qualifying Diagnosis" InpatientStay
    where CQMCommon."ToDateInterval" ( InpatientStay.period ) starts 30 days or less after day of "IPSD"

define "Inpatient Stay with Qualifying Diagnosis":
  ["Encounter": "Encounter Inpatient"] InpatientStay
    where exists ( ( "PrincipalDiagnosis"(InpatientStay) ) EncounterDiagnosis
        where EncounterDiagnosis.code in "Mental Behavioral and Neurodevelopmental Disorders"
    )

define function "PrincipalDiagnosis"(Encounter Encounter):
  ( Encounter.diagnosis D
    where D.rank = 1 ) PD
    return singleton from ( [Condition] C
        where C.id = PD.condition.reference.getId ( )
    )

define "Denominator 1":
  "Initial Population 1"

define "Denominator Exclusions":
  Hospice."Has Hospice Services"
    or exists ( "Narcolepsy Exclusion" )

define "Narcolepsy Exclusion":
  ["Condition": "Narcolepsy"] Narcolepsy
    where QICoreCommon."ToPrevalenceInterval" ( Narcolepsy ) starts on or before end of "Measurement Period"

define "Numerator 1":
  exists ( "Encounter During Initiation Phase" )

define "Encounter During Initiation Phase":
  "Qualifying Numerator Encounter" ValidNumeratorEncounter
    where CQMCommon."ToDateInterval" ( ValidNumeratorEncounter.period ) starts 30 days or less after day of "IPSD"

define "Qualifying Numerator Encounter":
  ( ["Encounter": "Office Visit"]
      union ["Encounter": "Initial Hospital Observation Care"]
      union ["Encounter": "Preventive Care Services Group Counseling"]
      union ["Encounter": "Behavioral Health Follow up Visit"]
      union ["Encounter": "Preventive Care Services Individual Counseling"]
      union ( ["Encounter": "Psychotherapy and Pharmacologic Management"] PsychPharmManagement
          where exists ( PsychPharmManagement.location Location
              where CQMCommon."GetLocation" ( Location.location ).type in "Ambulatory"
          )
      )
      union ["Encounter": "Outpatient Consultation"]
      union ["Encounter": "Home Healthcare Services"]
      union ["Encounter": "Preventive Care Services, Initial Office Visit, 0 to 17"]
      union ["Encounter": "Preventive Care, Established Office Visit, 0 to 17"]
      union ["Encounter": "Psych Visit Diagnostic Evaluation"]
      union ["Encounter": "Psych Visit Psychotherapy"]
      union ["Encounter": "Telephone Visits"]
  )

define "Initial Population 2":
  AgeInYearsAt(date from start of "Intake Period") >= 6
    and AgeInYearsAt(date from
      end of "Intake Period"
    ) <= 12
    and exists "Qualifying Encounter"
    and "First ADHD Medication Prescribed During Intake Period" is not null
    and "Has ADHD Cumulative Medication Duration Greater Than or Equal to 210 Days"
    and not exists "Inpatient Stay with Qualifying Diagnosis During Continuation and Maintenance Phase"

define "Has ADHD Cumulative Medication Duration Greater Than or Equal to 210 Days":
  "ADHD Cumulative Medication Duration" >= 210

define "ADHD Cumulative Medication Duration":
  CMD."CumulativeDuration" ( "ADHD Medications Taken on IPSD or During Continuation and Maintenance Phase" )

define "Inpatient Stay with Qualifying Diagnosis During Continuation and Maintenance Phase":
  "Inpatient Stay with Qualifying Diagnosis" InpatientStay
    where CQMCommon."ToDateInterval" ( InpatientStay.period ) starts 300 days or less after day of "IPSD"

define "ADHD Medications Taken on IPSD or During Continuation and Maintenance Phase":
  ( ( CMD."RolloutIntervals" ( ( ["MedicationRequest": "Atomoxetine"] AtomoxetineMed
        return all {
          period: CMD."MedicationRequestPeriod" ( AtomoxetineMed ),
          periodStart: start of CMD."MedicationRequestPeriod" ( AtomoxetineMed )
        }
        sort by periodStart
    ).period )
  )
    union ( CMD."RolloutIntervals" ( ( ["MedicationRequest": "Clonidine"] ClonidineMed
          return all {
            period: CMD."MedicationRequestPeriod" ( ClonidineMed ),
            periodStart: start of CMD."MedicationRequestPeriod" ( ClonidineMed )
          }
          sort by periodStart
      ).period )
    )
    union ( CMD."RolloutIntervals" ( ( ["MedicationRequest": "Dexmethylphenidate"] DexmethylphenidateMed
          return all {
            period: CMD."MedicationRequestPeriod" ( DexmethylphenidateMed ),
            periodStart: start of CMD."MedicationRequestPeriod" ( DexmethylphenidateMed )
          }
          sort by periodStart
      ).period )
    )
    union ( CMD."RolloutIntervals" ( ( ["MedicationRequest": "Dextroamphetamine"] DextroamphetamineMed
          return all {
            period: CMD."MedicationRequestPeriod" ( DextroamphetamineMed ),
            periodStart: start of CMD."MedicationRequestPeriod" ( DextroamphetamineMed )
          }
          sort by periodStart
      ).period )
    )
    union ( CMD."RolloutIntervals" ( ( ["MedicationRequest": "Lisdexamfetamine"] LisdexamfetamineMed
          return all {
            period: CMD."MedicationRequestPeriod" ( LisdexamfetamineMed ),
            periodStart: start of CMD."MedicationRequestPeriod" ( LisdexamfetamineMed )
          }
          sort by periodStart
      ).period )
    )
    union ( CMD."RolloutIntervals" ( ( ["MedicationRequest": "Methylphenidate"] MethylphenidateMed
          return all {
            period: CMD."MedicationRequestPeriod" ( MethylphenidateMed ),
            periodStart: start of CMD."MedicationRequestPeriod" ( MethylphenidateMed )
          }
          sort by periodStart
      ).period )
    )
    union ( CMD."RolloutIntervals" ( ( ["MedicationRequest": "Guanfacine"] GuanfacineMed
          return all {
            period: CMD."MedicationRequestPeriod" ( GuanfacineMed ),
            periodStart: start of CMD."MedicationRequestPeriod" ( GuanfacineMed )
          }
          sort by periodStart
      ).period )
    )
    union ( CMD."RolloutIntervals" ( ( ["MedicationRequest": "methamphetamine hydrochloride 5 MG Oral Tablet"] MethamphetamineMed
          return all {
            period: CMD."MedicationRequestPeriod" ( MethamphetamineMed ),
            periodStart: start of CMD."MedicationRequestPeriod" ( MethamphetamineMed )
          }
          sort by periodStart
      ).period )
    ) ) ADHDMedication
    let IPSDAndContinuationMaintenancePhase: Interval["IPSD", "IPSD" + 300 days]
    return all ADHDMedication
      intersect IPSDAndContinuationMaintenancePhase

define "Denominator 2":
  "Initial Population 2"

define "Numerator 2":
  exists ( "Encounter During Initiation Phase" )
    and ( ( "Two or More Encounters 31 to 300 Days into Continuation and Maintenance Phase" )
        or ( exists ( "Encounter 31 to 300 Days into Continuation and Maintenance Phase" Encounter1
              with "Online Assessment 31 to 300 Days into Continuation and Maintenance Phase" Encounter2
                such that Encounter1 is not null
                  and Encounter2 is not null
                  and Encounter1 !~ Encounter2
          )
        )
    )

define "Two or More Encounters 31 to 300 Days into Continuation and Maintenance Phase":
  Count("Encounter 31 to 300 Days into Continuation and Maintenance Phase") >= 2

define "Encounter 31 to 300 Days into Continuation and Maintenance Phase":
  "Qualifying Numerator Encounter" ValidNumeratorEncounter
    where CQMCommon."ToDateInterval" ( ValidNumeratorEncounter.period ) starts during day of Interval["IPSD" + 31 days, "IPSD" + 300 days]
    return date from start of ValidNumeratorEncounter.period

define "Online Assessment 31 to 300 Days into Continuation and Maintenance Phase":
  ["Encounter": "Online Assessments"] OnlineAssessment
    where CQMCommon."ToDateInterval" ( OnlineAssessment.period ) starts during day of Interval["IPSD" + 31 days, "IPSD" + 300 days]
    return date from start of OnlineAssessment.period

define "SDE Ethnicity":
  SDE."SDE Ethnicity"

define "SDE Payer":
  SDE."SDE Payer"

define "SDE Race":
  SDE."SDE Race"

define "SDE Sex":
  SDE."SDE Sex"
