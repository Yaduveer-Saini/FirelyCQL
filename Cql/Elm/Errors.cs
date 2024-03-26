﻿using Hl7.Cql.Abstractions.Exceptions;
using Hl7.Fhir.Language.Debugging;

namespace Hl7.Cql.Elm;

internal interface ILibraryError : ICqlError
{
    Library Library { get; }
}

internal readonly record struct LibraryMissingIncludeDefPathError(Library Library, IncludeDef IncludeDef) : ILibraryError
{
    public string GetMessage() => $"Library has an include definition with a missing path. Library Identifier: '{Library}', IncludeDef: '{IncludeDef}'";
}

internal readonly record struct MissingNameError(IGetNameAndVersion Source) : ICqlError
{
    public string GetMessage() => $"{Source.GetType().Name} did not have a valid name.";
}

internal readonly record struct MissingIdentifierError(IGetNameAndVersion Source) : ICqlError
{
    public string GetMessage() => $"{Source.GetType().Name} did not have an identifier.";
}

internal readonly record struct MissingAliasError(IGetLibraryAlias Source) : ICqlError
{
    public string GetMessage() => $"{Source.GetType().Name} did not have an alias. Source: {Source}";
}