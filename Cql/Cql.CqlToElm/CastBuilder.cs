﻿using Hl7.Cql.Elm;
using System.Linq;

namespace Hl7.Cql.CqlToElm
{
    /// <summary>
    /// Builds the implicit casts described in the CQL spec. Given the type of the parameter and an expression 
    /// representing the argument at the call site, this class will the necessary chain of nested expressions
    /// to implement the implicit casts.
    /// 
    /// See https://cql.hl7.org/03-developersguide.html#conversion-precedence
    /// </summary>
    internal class CastBuilder
    {
        public GenericParameterAssignments GenericAssignments { get; } = new GenericParameterAssignments();
        public IModelProvider Provider { get; }

        public CastBuilder(IModelProvider provider)
        {
            Provider = provider;
        }

        public TypeSpecifier Replace(TypeSpecifier ts) => ts.ReplaceGenericParameters(GenericAssignments);

        public bool TryBuildCast(Expression fromExpr, OperandDef to, out Expression? result) =>
            TryBuildCast(fromExpr, to.operandTypeSpecifier, out result);

        public bool TryBuildCast(Expression fromExpr, TypeSpecifier to, out Expression? result)
        {
            var from = fromExpr.resultTypeSpecifier;

            // The trivial case, equal types
            if (from == to)
            {
                result = fromExpr;
                return true;
            }

            // if parameter type is any, then any argument type is ok.
            // This is really a poor-mans subtype test, but it will do for now.
            if (to == SystemTypes.AnyType)
            {
                result = fromExpr;
                return true;
            }

            // If the parameter type is a generic type parameter, then we can assign any type to it,
            // unless it is already assigned to previously, in which case we need to check we can cast
            // to the assigned type for that generic type parameter.
            if (to is ParameterTypeSpecifier gtp)
            {
                if (GenericAssignments.TryGetValue(gtp, out var assignedType))
                    return TryBuildCast(fromExpr, assignedType, out result);
                else
                {
                    result = fromExpr;
                    GenericAssignments.Add(gtp, fromExpr.resultTypeSpecifier);
                    return true;
                }
            }

            // Nulls get promoted to any type necessary. If the target type has unbound
            // generic parameters, we will default those to System.Any.
            if (fromExpr is Null n)
            {
                var unbound = to.GetGenericParameters().ToList();
                if (unbound.Any())
                {
                    foreach (var u in unbound)
                        GenericAssignments.Add(u, SystemTypes.AnyType);
                    to = to.ReplaceGenericParameters(GenericAssignments);
                }

                result = SystemLibrary.As.Create(to, n);
                return true;
            }

            // Casting a List<X> to a List<Y>
            if (from is ListTypeSpecifier fromList && to is ListTypeSpecifier toList)
            {
                var prototypeInstance = new Null { resultTypeSpecifier = fromList.elementType };
                var elementCastSuccess = TryBuildCast(prototypeInstance, toList.elementType, out var elementCast);

                // For now, we assume that we have no co- or contravariance, so only the "identity" cast is allowed
                // (note that this may mean we have assigned a type to a generic type parameter.)
                if (elementCastSuccess && elementCast == prototypeInstance)
                {
                    result = fromExpr;
                    return true;
                }
                else
                {
                    result = default;
                    return false;
                }
            }

            // Casting a List<X> to a List<Y>
            if (from is IntervalTypeSpecifier fromInterval && to is IntervalTypeSpecifier toInterval)
            {
                var prototypeInstance = new Null { resultTypeSpecifier = fromInterval.pointType };
                var elementCastSuccess = TryBuildCast(prototypeInstance, toInterval.pointType, out var elementCast);

                // For now, we assume that we have no co- or contravariance, so only the "identity" cast is allowed
                // (note that this may mean we have assigned a type to a generic type parameter.)
                if (elementCastSuccess && elementCast == prototypeInstance)
                {
                    result = fromExpr;
                    return true;
                }
                else
                {
                    result = default;
                    return false;
                }
            }


            // TODO: choice

            // TODO: decimal/int etc implicits

            // TODO: interval promotion

            // List demotion
            if (from is ListTypeSpecifier && to is not ListTypeSpecifier)
            {
                try
                {
                    var nested = SystemLibrary.SingletonFrom.Build(Provider, fromExpr);
                    return TryBuildCast(nested, to, out result);
                }
                catch
                {
                    result = default;
                    return false;
                }
            }

            // TODO: interval demotion

            // List promotion
            if (from is not ListTypeSpecifier && to is ListTypeSpecifier)
            {
                try
                {
                    var nested = SystemLibrary.ToList.Build(Provider, fromExpr);
                    return TryBuildCast(nested, to, out result);
                }
                catch
                {
                    result = default;
                    return false;
                }
            }


            // No cast found
            result = fromExpr;
            return false;
        }

    }

}
