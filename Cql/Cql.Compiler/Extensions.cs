﻿using Hl7.Cql.Elm;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Runtime.CompilerServices;

namespace Hl7.Cql.Compiler
{
    internal static class Extensions
    {
        public static T[] OrEmptyArray<T>(this T[]? array) 
            => array ?? Array.Empty<T>();

        public static IReadOnlyCollection<T> OrEmptyCollection<T>(this IReadOnlyCollection<T>? collection) 
            => collection ?? Array.Empty<T>();

        public static IEnumerable<T> OrEmptyEnumerable<T>(this IEnumerable<T>? enumerable) 
            => enumerable ?? Enumerable.Empty<T>();

        public static T NotNull<T>([NotNull]this T? value, [CallerArgumentExpression(nameof(value))] string valueExpr = "")
        {
            if (value == null)
                throw new ArgumentNullException(valueExpr);
            return value;
        }
    }
}
