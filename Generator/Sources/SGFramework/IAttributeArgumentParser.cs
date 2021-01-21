using System.Collections.Generic;

using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace ValueObjectGenerator.SGFramework
{
    public interface IAttributeArgumentParser
    {
        public void ParseAttributeArgument(
            int argumentIndex,
            AttributeArgumentSyntax argumentSyntax,
            SemanticModel semanticModel,
            ExpressionSyntax argumentExpression,
            IDictionary<AttributeParamName,object> result );
    }
}
