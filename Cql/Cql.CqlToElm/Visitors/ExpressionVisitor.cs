﻿using Hl7.Cql.CqlToElm.Builtin;
using Hl7.Cql.CqlToElm.Grammar;
using Hl7.Cql.Elm;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Xml;

namespace Hl7.Cql.CqlToElm.Visitors
{
    internal partial class ExpressionVisitor : Visitor<Expression>
    {
        public ExpressionVisitor(
            IModelProvider provider,
            LibraryContext libraryContext,
            TypeSpecifierVisitor typeSpecifierVisitor,
            IServiceProvider services,
            SystemLibrary system) : base(services)
        {
            ModelProvider = provider;
            LibraryContext = libraryContext;
            TypeSpecifierVisitor = typeSpecifierVisitor;
            System = system;
        }

        #region Privates
        private readonly IModelProvider ModelProvider;
        private readonly LibraryContext LibraryContext;
        private readonly TypeSpecifierVisitor TypeSpecifierVisitor;

        private XmlQualifiedName AnyTypeQName => SystemTypes.AnyTypeQName;
        private XmlQualifiedName IntegerTypeQName => SystemTypes.IntegerTypeQName;
        private XmlQualifiedName LongTypeQName => SystemTypes.LongTypeQName;
        private XmlQualifiedName DecimalTypeQName => SystemTypes.DecimalTypeQName;
        private XmlQualifiedName QuantityTypeQName => SystemTypes.QuantityTypeQName;
        private XmlQualifiedName StringTypeQName => SystemTypes.StringTypeQName;
        private XmlQualifiedName DateTypeQName => SystemTypes.DateTypeQName;
        private XmlQualifiedName TimeTypeQName => SystemTypes.TimeTypeQName;
        private XmlQualifiedName DateTimeTypeQName => SystemTypes.DateTimeTypeQName;
        private XmlQualifiedName BooleanTypeQName => SystemTypes.BooleanTypeQName;
        private XmlQualifiedName RatioTypeQName => SystemTypes.RatioTypeQName;

        private readonly SystemLibrary System;

        private InvalidOperationException UnresolvedSignature(string @operator, params Expression[] operands) =>
            throw Critical($"Could not resolve call to operator {@operator} with signature " +
                $"({string.Join(", ", operands.Select(o => o.resultTypeSpecifier?.ToString() ?? "unknown"))}");

        #endregion

        public override Expression VisitIntervalSelector([NotNull] cqlParser.IntervalSelectorContext context)
        {
            bool? lowClosed = context.GetChild(1).GetText() switch
            {
                "[" => true,
                "(" => false,
                _ => throw Critical($"Invalid interval; expecting either [ or (") // this really can't happen
            };
            var low = Visit(context.GetChild(2));
            var high = Visit(context.GetChild(4));
            if (low is Null)
            {
                if (high is Null)
                {
                    throw Critical("Intervals with both low and high null values are not allowed.");
                }
                else
                {
                    low = new As
                    {
                        operand = low,
                        asType = high.resultTypeName,
                        asTypeSpecifier = high.resultTypeSpecifier,
                        localId = NextId(),
                        locator = context.Locator(),
                        resultTypeName = high.resultTypeName,
                        resultTypeSpecifier = high.resultTypeSpecifier
                    };
                }
            }
            else if (high is Null)
            {
                high = new As
                {
                    operand = high,
                    asType = low.resultTypeName,
                    asTypeSpecifier = low.resultTypeSpecifier,
                    localId = NextId(),
                    locator = context.Locator(),
                    resultTypeName = low.resultTypeName,
                    resultTypeSpecifier = low.resultTypeSpecifier
                };
            }

            bool? highClosed = context.GetChild(5).GetText() switch
            {
                "]" => true,
                ")" => false,
                _ => throw Critical($"Invalid interval; expecting either ] or )")
            };
            TypeSpecifier? resultTypeSpecifier = null;
            if (low.resultTypeSpecifier == high.resultTypeSpecifier)
            {
                if (low.resultTypeSpecifier.IsValidOrderedType())
                {
                    if (low is Quantity lowQuantity && high is Quantity highQuantity
                        && !UnitsAreCompatible(lowQuantity.unit, highQuantity.unit))
                        Critical($"Intervals of quantities must be of the same unit.");
                    else
                        resultTypeSpecifier = IntervalType(low.resultTypeSpecifier, context);
                }
                else
                    throw Critical($"Intervals can only be constructed for types with defined minimums and maximums.  Type {low.resultTypeName?.Name} is not allowed.");
            }
            else
                throw Critical($"Interval types for low ({low.resultTypeName}) and high ({high.resultTypeName}) do not match.");

            var interval = new Elm.Interval
            {
                high = high,
                low = low,
                highClosed = highClosed.HasValue ? highClosed.Value : default,
                lowClosed = lowClosed.HasValue ? lowClosed.Value : default,
                localId = NextId(),
                locator = context.Locator(),
                resultTypeSpecifier = resultTypeSpecifier,
            };
            return interval;
        }

        public override Expression VisitListSelector([NotNull] cqlParser.ListSelectorContext context)
        {
            var elementCount = context.ChildCount - 2;
            if ((elementCount & 0x1) == 1)
                elementCount = (elementCount >> 1) + 1;
            else
                elementCount >>= 1;
            if (elementCount == 0)
                return new List
                {
                    localId = NextId(),
                    locator = context.Locator(),
                    element = Array.Empty<Expression>(),
                    resultTypeSpecifier = ListType(NamedType(AnyTypeQName, context), context),
                };

            var elements = new Expression[elementCount];
            var elementTypes = new ListElementPromotion[elementCount];
            var maximalElementType = ListElementPromotion.None;
            for (int i = 1, j = 0; i < context.ChildCount; i += 2)
            {
                var element = Visit(context.GetChild(i));
                elements[j] = element;
                if (element.resultTypeName == QuantityTypeQName)
                {
                    elementTypes[j] = ListElementPromotion.Quantity;
                    maximalElementType = ListElementPromotion.Quantity;
                }
                else if (element.resultTypeName == DecimalTypeQName)
                {
                    elementTypes[j] = ListElementPromotion.Decimal;
                    maximalElementType = (ListElementPromotion)Math.Max((int)maximalElementType, (int)ListElementPromotion.Decimal);
                }
                else if (element.resultTypeName == LongTypeQName)
                {
                    elementTypes[j] = ListElementPromotion.Long;
                    maximalElementType = (ListElementPromotion)Math.Max((int)maximalElementType, (int)ListElementPromotion.Long);
                }
                else if (element.resultTypeName == IntegerTypeQName)
                {
                    elementTypes[j] = ListElementPromotion.Integer;
                }
                j++;
            }
            for (int i = 0; i < elements.Length; i++)
                elements[i] = promote(elements[i], elementTypes[i], maximalElementType);

            Expression promote(Expression expression, ListElementPromotion from, ListElementPromotion to) =>
                from switch
                {
                    ListElementPromotion.Decimal => to switch
                    {
                        ListElementPromotion.Quantity => toQuantity(expression),
                        _ => expression
                    },
                    ListElementPromotion.Long => to switch
                    {
                        ListElementPromotion.Quantity => toQuantity(expression),
                        ListElementPromotion.Decimal => toDecimal(expression),
                        _ => expression
                    },
                    ListElementPromotion.Integer => to switch
                    {
                        ListElementPromotion.Quantity => toQuantity(expression),
                        ListElementPromotion.Decimal => toDecimal(expression),
                        ListElementPromotion.Long => toLong(expression),
                        _ => expression,
                    },
                    _ => expression,
                };
            Expression toQuantity(Expression ex) => new ToQuantity
            {
                operand = new ToDecimal
                {
                    operand = ex,
                    localId = NextId(),
                    locator = ex.locator,
                    resultTypeName = DecimalTypeQName,
                    resultTypeSpecifier = NamedType(DecimalTypeQName, context),
                },
                localId = NextId(),
                locator = ex.locator,
                resultTypeName = QuantityTypeQName,
                resultTypeSpecifier = NamedType(QuantityTypeQName, context),
            };
            Expression toDecimal(Expression ex) => new ToDecimal
            {
                operand = ex,
                localId = NextId(),
                locator = ex.locator,
                resultTypeName = DecimalTypeQName,
                resultTypeSpecifier = NamedType(DecimalTypeQName, context),
            };
            Expression toLong(Expression ex) => new ToLong
            {
                operand = ex,
                localId = NextId(),
                locator = ex.locator,
                resultTypeName = LongTypeQName,
                resultTypeSpecifier = NamedType(LongTypeQName, context),
            };

            TypeSpecifier? listElementType = null;
            var typeCount = elements
                .Select(e => e.resultTypeName)
                .Distinct()
                .Count();
            if (typeCount == 1)
                listElementType = elements[0].resultTypeSpecifier;
            else
                listElementType = NamedType(AnyTypeQName, context);

            var list = new List
            {
                element = elements,
                localId = NextId(),
                locator = context.Locator(),
                resultTypeSpecifier = ListType(listElementType, context)
            };
            return list;
        }

        //  '[' (contextIdentifier '->')? namedTypeSpecifier (':' (codePath codeComparator)? terminology)? ']'
        public override Expression VisitRetrieve([NotNull] cqlParser.RetrieveContext context)
        {
            var contextName = context.contextIdentifier().GetText();
            var codePath = context.codePath().GetText();
            var codeComparator = context.codeComparator().GetText();
            var terminology = Visit(context.terminology());
            var type = (NamedTypeSpecifier)TypeSpecifierVisitor.Visit(context.namedTypeSpecifier());

            var contextExpressionRef = new ExpressionRef
            {
                name = contextName,
            };

            var retrieve = new Retrieve
            {
                localId = NextId(),
                locator = context.Locator(),
                dataType = type.name,
                templateId = ModelProvider.GetDefaultProfileUriForType(type),
                context = contextExpressionRef,
                codeComparator = codeComparator,
                codes = terminology,
                codeProperty = codePath,
                resultTypeSpecifier = ListType(type, context)
            };

            return retrieve;
        }

        private enum ListElementPromotion
        {
            None,
            Integer,
            Long,
            Decimal,
            Quantity
        }
    }
}
