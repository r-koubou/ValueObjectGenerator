using System.Collections.Generic;
using System.Data;

using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

using ValueObjectGenerator.SGFramework;

namespace ValueObjectGenerator
{
    internal class ValueObjectAttributeArgumentParser : IAttributeArgumentParser
    {
        public void ParseAttributeArgument(
            int argumentIndex,
            SemanticModel semanticModel,
            ExpressionSyntax argumentExpression,
            IDictionary<AttributeParamName, object> result )
        {
            switch( argumentIndex )
            {
                case 0: CollectTypeOfSyntax( argumentExpression, semanticModel, result ); break;
                case 1: CollectValueOptionSyntax( argumentExpression, result ); break;
            }
        }

        private static void CollectTypeOfSyntax(
            ExpressionSyntax argumentExpr,
            SemanticModel semanticModel,
            IDictionary<AttributeParamName, object> result )
        {
            if( argumentExpr is TypeOfExpressionSyntax typeExpression )
            {
                if( !( semanticModel.GetSymbolInfo( typeExpression.Type ).Symbol is ITypeSymbol symbol ) )
                {
                    throw new SyntaxErrorException( "type is missing" );
                }

                result[ AttributeParameterNames.BaseName ] = symbol.ToString();
            }
        }

        private static void CollectValueOptionSyntax(
            ExpressionSyntax argumentExpr,
            IDictionary<AttributeParamName, object> result )
        {
            var enumValue = SyntaxUtility.ParseEnumValue<ValueOption>( argumentExpr );
            result[ AttributeParameterNames.OptionFlags ] = enumValue;
        }
    }
}
