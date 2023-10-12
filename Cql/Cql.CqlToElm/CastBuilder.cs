﻿using Hl7.Cql.CqlToElm.Builtin;
using Hl7.Cql.Elm;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Hl7.Cql.CqlToElm
{
    internal record ArgumentCaster(Expression Caster, int Cost, GenericParameterAssignments? Assignments, string? Error)
    {
        public bool Success => Error is null;
    }

    internal record FunctionMatchResult(Expression[] Casters, int Cost, TypeSpecifier ReturnType, string? Error)
    {
        public bool Success => Error is null;
    }

    //internal record Signature(TypeSpecifier[] Parameters, TypeSpecifier Result)
    //{
    //    public Signature(FunctionDef def) : this(def.operand.Select(o => o.operandTypeSpecifier).ToArray(), def.resultTypeSpecifier)
    //    {
    //    }
    //}

    /// <summary>
    /// Builds the implicit casts described in the CQL spec. Given the type of the parameter and an expression 
    /// representing the argument at the call site, this class will the necessary chain of nested expressions
    /// to implement the implicit casts.
    /// 
    /// See https://cql.hl7.org/03-developersguide.html#conversion-precedence
    /// </summary>
    internal class CastBuilder
    {
        public IModelProvider Provider { get; }
        public CastBuilder(IModelProvider provider)
        {
            Provider = provider;
        }

        public FunctionMatchResult Build(FunctionDef candidate, Expression[] arguments)
        {
            var genericReplacements = new GenericParameterAssignments();

            if (candidate.operand.Length != arguments.Length)
                return new(arguments, int.MaxValue, candidate.resultTypeSpecifier, $"Number or arguments should be the same as the number of parameters in the FunctionDef.");

            var argumentResults = new List<ArgumentCaster>();
            string? error = null;

            for (int ix = 0; ix < candidate.operand.Length; ix++)
            {
                var targetType = candidate.operand[ix].operandTypeSpecifier.ReplaceGenericParameters(genericReplacements);
                var argumentResult = build(arguments[ix], targetType);

                if (!argumentResult.Success)
                {
                    error = $"The {BuiltInFunctionDef.GetArgumentName(ix)} argument {argumentResult.Error}.";
                    break;
                }

                if (argumentResult.Assignments is not null)
                    genericReplacements.AddRange(argumentResult.Assignments);

                argumentResults.Add(argumentResult);
            }

            return new(
                Casters: argumentResults.Select(a => a.Caster).ToArray(),
                Cost: argumentResults.Sum(a => a.Cost),
                ReturnType: candidate.resultTypeSpecifier.ReplaceGenericParameters(genericReplacements),
                Error: error);
        }

        /// <summary>
        /// Update a signature with new assignments of an open generic parameter.
        /// </summary>
        //private static Signature replaceGeneric(Signature sig, GenericParameterAssignments map)
        //{
        //    return sig with
        //    {
        //        Parameters = sig.Parameters.Select(a => a.ReplaceGenericParameters(map)).ToArray(),
        //        Result = sig.Result.ReplaceGenericParameters(map)
        //    };
        //}

        private ArgumentCaster build(Expression argument, TypeSpecifier to)
        {
            var argumentType = argument.resultTypeSpecifier;
            var locatorContext = new StringLocatorRuleContext(argument.locator);

            // The trivial case, equal types
            if (argumentType == to)
                return new(argument, 0, null, null);

            // if parameter type is any, then any argument type is ok.
            // This is really a poor-mans subtype test, but it will do for now.
            if (to == SystemTypes.AnyType)
                return new(argument, 0, null, null);

            // If the parameter type is a generic type parameter, then we can assign any type to it,
            // unless it is already assigned to previously, in which case we need to check we can cast
            // to the assigned type for that generic type parameter.
            if (to is ParameterTypeSpecifier gtp)
                return new(argument, 0, new() { { gtp, argumentType } }, null);

            // Nulls get promoted to any type necessary. If the target type has unbound
            // generic parameters, we will default those to System.Any.
            if (argument is Null n)
            {
                var unbound = to.GetGenericParameters().ToList();
                var map = unbound.Any()
                    ? new GenericParameterAssignments(unbound.Select(gp => KeyValuePair.Create(gp, (TypeSpecifier)SystemTypes.AnyType)))
                    : null;

                if (map is not null)
                    to = to.ReplaceGenericParameters(map);

                var @as = SystemLibrary.As.Call(false, to, n, locatorContext);

                return new(@as, 1, map, null);
            }

            // Casting a List<X> to a List<Y> is not possible in general(?), but it is
            // when Y is an unbound generic type for now.
            if (argumentType is ListTypeSpecifier fromList && to is ListTypeSpecifier toList)
            {
                var prototypeInstance = new Null { resultTypeSpecifier = fromList.elementType };
                var elementCast = build(prototypeInstance, toList.elementType);

                // For now, we assume that we have no co- or contravariance, so only the "identity" cast is allowed
                // (note that this may mean we have assigned a type to a generic type parameter.)
                if (elementCast.Success && elementCast.Caster == prototypeInstance)
                    return new(argument, elementCast.Cost, elementCast.Assignments, null);
                else
                {
                    return elementCast;
                }
            }

            // Casting an Interval<X> to an Interval<Y> is not possible in general(?), but it is
            // when Y is an unbound generic type for now.
            if (argumentType is IntervalTypeSpecifier fromInterval && to is IntervalTypeSpecifier toInterval)
            {
                var prototypeInstance = new Null { resultTypeSpecifier = fromInterval.pointType };
                var elementCast = build(prototypeInstance, toInterval.pointType);

                // For now, we assume that we have no co- or contravariance, so only the "identity" cast is allowed
                // (note that this may mean we have assigned a type to a generic type parameter.)
                if (elementCast.Success && elementCast.Caster == prototypeInstance)
                    return new(argument, elementCast.Cost, elementCast.Assignments, null);
                else
                {
                    return elementCast;
                }
            }

            // TODO: choice

            // TODO: decimal/int etc implicits

            // TODO: interval promotion

            // List demotion
            if (argumentType is ListTypeSpecifier && to is not ListTypeSpecifier)
            {
                try
                {
                    var nested = SystemLibrary.SingletonFrom.Call(Provider, locatorContext, argument);
                    var intermediate = build(nested, to);
                    return intermediate with { Cost = intermediate.Cost + 1 };
                }
                catch (Exception e)
                {
                    return new(argument, int.MaxValue, null, e.Message);
                }
            }

            // TODO: interval demotion

            // List promotion
            if (argumentType is not ListTypeSpecifier && to is ListTypeSpecifier)
            {
                try
                {
                    var nested = SystemLibrary.ToList.Call(Provider, locatorContext, argument);
                    var intermediate = build(nested, to);
                    return intermediate with { Cost = intermediate.Cost + 1 };
                }
                catch (Exception e)
                {
                    return new(argument, int.MaxValue, null, e.Message);
                }
            }

            // No cast found
            return new(argument, int.MaxValue, null, $"cannot implicitly be cast from {argumentType} to {to}");
        }

    }
}

