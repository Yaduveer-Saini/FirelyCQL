﻿using System.Diagnostics;

namespace Hl7.Cql.Compiler.Builders;

[DebuggerDisplay("{DebuggerView}")]
partial class LibrarySetExpressionBuilderContext : ILibrarySetExpressionBuilderContext
{
    public IBuilderContext? OuterBuilderContext => null;
    public BuilderContextDebuggerInfo? DebuggerInfo { get; }
    public string DebuggerView => this.GetDebuggerView();
}