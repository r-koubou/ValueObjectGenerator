using System.Collections.Generic;

using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace ValueObjectGenerator.SGFramework.TypeDeclaration
{
    public interface ITypeDeclarationSyntaxReceiver : ISyntaxReceiver
    {
        public IReadOnlyDictionary<TypeDeclarationSyntax, IReadOnlyCollection<AttributeSyntax>> Declarations { get; }
        public IAttributeContainsChecker AttributeContainsChecker { get; set; }
    }
}
