﻿#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
/*
 * Copyright (c) 2023, NCQA and contributors
 * See the file CONTRIBUTORS for details.
 *
 * This file is licensed under the BSD 3-Clause license
 * available at https://raw.githubusercontent.com/FirelyTeam/firely-cql-sdk/main/LICENSE
 */

using Hl7.Cql.Abstractions;
using Hl7.Cql.Compiler.Expressions;
using System;
using System.Linq.Expressions;
using Microsoft.Extensions.Logging;

namespace Hl7.Cql.Compiler
{
    internal partial class ExpressionBuilder
    {
        protected Expression As(Elm.As @as)
        {
            if (@as.operand is Elm.List list)
            {
                using (PushElement(list))
                {
                    // create new ListType[0]; instead of new object[0] as IEnumerable<object> as IEnumerable<ListType>;
                    if ((list.element?.Length ?? 0) == 0)
                    {
                        var type = TypeFor(@as.asTypeSpecifier!);
                        if (_typeResolver.ImplementsGenericIEnumerable(type))
                        {
                            var listElementType = _typeResolver.GetListElementType(type) ?? throw this.NewExpressionBuildingException($"{type} was expected to be a list type.");
                            var newArray = Expression.NewArrayBounds(listElementType, Expression.Constant(0));
                            var elmAs = new ElmAsExpression(newArray, type);
                            return elmAs;
                        }
                        else
                        {
                            throw this.NewExpressionBuildingException("Cannot use as operator on a list if the as type is not also a list type.");
                        }
                    }
                }
            }

            // asTypeSpecifier is an expression with its own resulttypespecifier that actually contains the real type
            if (@as.asTypeSpecifier != null)
            {
                using (PushElement(@as.asTypeSpecifier))
                {
                    if (@as.operand is Elm.Null)
                    {
                        var type = TypeFor(@as.asTypeSpecifier!);
                        var defaultExpression = Expression.Default(type);
                        return new ElmAsExpression(defaultExpression, type);
                    }
                    else
                    {
                        var type = TypeFor(@as.asTypeSpecifier!);
                        var operand = TranslateExpression(@as.operand!);
                        return new ElmAsExpression(operand, type);
                    }
                }
            }
            else
            {
                if (string.IsNullOrWhiteSpace(@as.asType.Name))
                    throw this.NewExpressionBuildingException("The 'as' operator has no type name.");

                if (@as.operand is null)
                    throw this.NewExpressionBuildingException("Operand cannot be null");

                var type = _typeResolver.ResolveType(@as.asType.Name!)
                    ?? throw this.NewExpressionBuildingException($"Cannot resolve type {@as.asType.Name}");

                var operand = TranslateExpression(@as.operand);
                if (!type.IsAssignableTo(operand.Type))
                {
                    _logger.LogWarning(FormatMessage($"Potentially unsafe cast from {TypeManager.PrettyTypeName(operand.Type)} to type {TypeManager.PrettyTypeName(type)}", @as.operand));
                }

                return new ElmAsExpression(operand, type);
            }
        }

        protected Expression Is(Elm.Is @is)
        {
            var op = TranslateExpression(@is.operand!);
            Type? type = null;
            if (@is.isTypeSpecifier != null)
            {
                if (@is.isTypeSpecifier is Elm.ChoiceTypeSpecifier choice)
                {
                    var firstChoiceType = TypeFor(choice.choice[0]) ?? throw this.NewExpressionBuildingException($"Could not resolve type for Is expression");
                    Expression result = Expression.TypeIs(op, firstChoiceType);
                    for (int i = 1; i < choice.choice.Length; i++)
                    {
                        var cti = TypeFor(choice.choice[i]) ?? throw this.NewExpressionBuildingException($"Could not resolve type for Is expression");
                        var ie = Expression.TypeIs(op, cti);
                        result = Expression.Or(result, ie);
                    }
                    var ta = Expression.TypeAs(result, typeof(bool?));
                    return ta;
                }

                type = TypeFor(@is.isTypeSpecifier) ?? throw this.NewExpressionBuildingException($"Could not resolve type for Is expression");
            }
            else if (!string.IsNullOrWhiteSpace(@is.isType?.Name))
            {
                type = _typeResolver.ResolveType(@is.isType.Name) ?? throw this.NewExpressionBuildingException($"Could not resolve type {@is.isType.Name}");
            }

            if (type == null)
                throw this.NewExpressionBuildingException($"Could not identify Is type specifer via {nameof(@is.isTypeSpecifier)} or {nameof(@is.isType)}.");

            var isExpression = Expression.TypeIs(op, type);
            var nullable = Expression.TypeAs(isExpression, typeof(bool?));
            return nullable;
        }


        private Expression ChangeType(Expression input, Type outputType) // @TODO: Cast
        {
            if (input.Type == outputType)
                return input;

            if (input.Type == typeof(object) || outputType.IsAssignableFrom(input.Type))
                return Expression.TypeAs(input, outputType);

            if (_typeResolver.ImplementsGenericIEnumerable(input.Type)
                && _typeResolver.ImplementsGenericIEnumerable(outputType))
            {
                var inputElementType = _typeResolver.GetListElementType(input.Type, true)!;
                var outputElementType = _typeResolver.GetListElementType(outputType, true)!;
                var lambdaParameter = Expression.Parameter(inputElementType, TypeNameToIdentifier(inputElementType, this));
                var lambdaBody = ChangeType(lambdaParameter, outputElementType);
                var lambda = Expression.Lambda(lambdaBody, lambdaParameter);
                return _operatorBinder.BindToMethod(CqlOperator.Select, input, lambda);
            }

            if(TryCorrectQiCoreBindingError(input.Type, outputType, out var correctedTo))
            {
                return _operatorBinder.BindToMethod(CqlOperator.Convert, input, Expression.Constant(correctedTo, typeof(Type)));
            }
            else
            {
                return _operatorBinder.BindToMethod(CqlOperator.Convert, input, Expression.Constant(outputType, typeof(Type)));
            }
        }
    }
}
