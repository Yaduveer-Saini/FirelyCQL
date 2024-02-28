using System;
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

namespace Tuples
{
    [System.CodeDom.Compiler.GeneratedCode(".NET Code Generation", "1.0.0.0")]
    public class Tuple_DaTHNXWGHIVRYGRfGdXJYJKRZ: TupleBaseType
    {
        [CqlDeclaration("ValidEncounters")]
        public Encounter ValidEncounters { get; set; }
        [CqlDeclaration("InitialVR12OrthogonalDate")]
        public CqlDate InitialVR12OrthogonalDate { get; set; }
        [CqlDeclaration("FollowupVR12OrthogonalDate")]
        public CqlDate FollowupVR12OrthogonalDate { get; set; }
    }
}