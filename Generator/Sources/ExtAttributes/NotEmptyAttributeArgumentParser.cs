using System.Collections.Generic;

using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

using SGFramework;

namespace ValueObjectGenerator.ExtAttributes
{
    internal class NotEmptyAttributeArgumentParser : IAttributeArgumentParser
    {
        public void ParseAttributeArgument(
            int argumentIndex,
            AttributeArgumentSyntax argumentSyntax,
            SemanticModel semanticModel,
            ExpressionSyntax argumentExpression,
            IDictionary<AttributeParamName, object> result )
        {
            switch( argumentIndex )
            {
                case 0:
                    AttributeArgumentParserHelper.ParseExpression(
                        argumentExpression,
                        result,
                        AttributeParameterNames.ExcludeWhiteSpace
                    );
                    break;
            }
        }
    }
}
