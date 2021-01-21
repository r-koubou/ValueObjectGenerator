using System;
using System.Collections.Generic;
using System.Data;

using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

using ValueObjectGenerator.SGFramework;

namespace ValueObjectGenerator
{
    public static class AttributeArgumentParserHelper
    {
        public static void ParseTypeOfExpression(
            ExpressionSyntax argumentExpr,
            SemanticModel semanticModel,
            IDictionary<AttributeParamName, object> result,
            AttributeParamName key )
        {
            if( argumentExpr is TypeOfExpressionSyntax typeExpression )
            {
                if( !( semanticModel.GetSymbolInfo( typeExpression.Type ).Symbol is ITypeSymbol symbol ) )
                {
                    throw new SyntaxErrorException( "type is missing" );
                }

                result[ key ] = symbol.ToString();
            }
        }

        public static void ParseEnumExpression<TEnum>(
            ExpressionSyntax argumentExpr,
            IDictionary<AttributeParamName, object> target,
            AttributeParamName key ) where TEnum : Enum
        {
            var enumValue = SyntaxUtility.ParseEnumValue<TEnum>( argumentExpr );
            target[ key ] = enumValue;
        }

        public static void ParseExpression(
            ExpressionSyntax argumentExpr,
            IDictionary<AttributeParamName, object> target,
            AttributeParamName key )
        {
            target[ key ] = argumentExpr.ToString();
        }

    }
}
