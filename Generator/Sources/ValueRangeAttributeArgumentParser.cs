using System.Collections.Generic;

using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

using ValueObjectGenerator.SGFramework;

namespace ValueObjectGenerator
{
    internal class ValueRangeAttributeArgumentParser : IAttributeArgumentParser
    {
        public void ParseAttributeArgument(
            int argumentIndex,
            SemanticModel semanticModel,
            ExpressionSyntax argumentExpression,
            IDictionary<AttributeParamName, object> result )
        {
            switch( argumentIndex )
            {
                case 0: CollectTypeOfSyntax( argumentExpression, AttributeParameterNames.Min, result ); break;
                case 1: CollectTypeOfSyntax( argumentExpression, AttributeParameterNames.Max, result ); break;
            }
        }

        private static void CollectTypeOfSyntax(
            ExpressionSyntax argumentExpr,
            AttributeParamName parameterName,
            IDictionary<AttributeParamName, object> result )
        {
            result[ parameterName ] = argumentExpr.ToString();
        }
    }
}
