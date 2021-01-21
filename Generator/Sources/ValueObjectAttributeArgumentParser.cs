using System.Collections.Generic;

using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

using ValueObjectGenerator.SGFramework;

namespace ValueObjectGenerator
{
    internal class ValueObjectAttributeArgumentParser : IAttributeArgumentParser
    {
        public void ParseAttributeArgument(
            int argumentIndex,
            AttributeArgumentSyntax argumentSyntax,
            SemanticModel semanticModel,
            ExpressionSyntax argumentExpression,
            IDictionary<AttributeParamName, object> result )
        {
            if( argumentIndex == 0 )
            {
                AttributeArgumentParserHelper.ParseTypeOfExpression(
                    argumentExpression,
                    semanticModel,
                    result,
                    AttributeParameterNames.BaseName
                );
            }
            else
            {
                //
                // named arguments
                //

                switch( argumentSyntax.NameEquals?.Name.ToString() )
                {
                    case "Option":
                        AttributeArgumentParserHelper.ParseEnumExpression<ValueOption>(
                            argumentExpression,
                            result,
                            AttributeParameterNames.OptionFlags
                        );
                        break;
                    case "ValueName":
                        AttributeArgumentParserHelper.ParseExpression(
                            argumentExpression,
                            result,
                            AttributeParameterNames.ValueName
                        );
                        break;
                }
            }
        }
    }
}
