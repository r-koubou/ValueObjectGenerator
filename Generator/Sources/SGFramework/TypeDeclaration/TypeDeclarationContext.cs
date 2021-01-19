using System.Collections.Generic;

using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace ValueObjectGenerator.SGFramework.TypeDeclaration
{
    public class TypeDeclarationContext
    {
        public TypeDeclarationSyntax Syntax { get; }
        public SemanticModel SemanticModel { get; }

        public IDictionary<AttributeTypeName, IDictionary<AttributeParamName, object>> AttributeList { get; }
            = new Dictionary<AttributeTypeName, IDictionary<AttributeParamName, object>>();

        public TypeDeclarationContext( GeneratorExecutionContext ctx, TypeDeclarationSyntax syntax )
        {
            Syntax        = syntax;
            SemanticModel = ctx.Compilation.GetSemanticModel( syntax.SyntaxTree );
        }
    }
}
