/*
 * Copyright (c) 2024, NCQA and contributors
 * See the file CONTRIBUTORS for details.
 *
 * This file is licensed under the BSD 3-Clause license
 * available at https://raw.githubusercontent.com/FirelyTeam/firely-cql-sdk/main/LICENSE
 */

using System;
using System.Linq;
using Hl7.Cql.Abstractions.Exceptions;
using Hl7.Cql.Elm;

namespace Hl7.Cql.Compiler;

/// <summary>
/// Pre-processes the ELM library to ensure the ELM library is in a state that can be compiled.
/// </summary>
/// <remarks>For now, this means ensuring all FunctionRefs have a resultTypeSpecifier,
/// but more will follow.</remarks>
internal class ElmPreprocessor
{
    public static void Process(Library library, LibrarySet librarySet)
    {
        var walker = new ElmTreeWalker(visit);

        bool visit(object node)
        {
            // Do not process anything else than FunctionRefs
            if (node is not FunctionRef fref)
                return false;

            // If the FunctionRef is ok, we're done.
            if (fref.resultTypeSpecifier is not null)
                return true;

            // If it has a resultTypeName but no resultTypeSpecifier, make one.
            if (fref.resultTypeName is not null)
            {
                fref.resultTypeSpecifier = fref.resultTypeName.ToNamedType();
                return true;
            }

            if (!librarySet.TryResolveDefinition(library, fref, out ExpressionDef? expressionDef))
                throw new UnresolvedReferenceError(library, fref).ToException();

            if (expressionDef is MethodGroup mg)
            {
                var candidates = mg.GetOverloads(fref.signature ?? []);

                fref.resultTypeSpecifier = candidates.Count switch
                {
                    0   => throw new UnresolvedReferenceError(library, fref).ToException(),
                    > 1 => throw new AmbiguousMatch(library, fref).ToException(),
                    _   => candidates.Single().GetTypeSpecifier()
                };
            }
            else
            {
                fref.resultTypeSpecifier = expressionDef.GetTypeSpecifier();
            }

            return true;
        }
    }
}