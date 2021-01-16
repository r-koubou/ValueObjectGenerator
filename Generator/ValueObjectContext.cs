using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace ValueGenerator
{
    internal class ValueObjectContext
    {
        public TypeDeclarationSyntax Declaration { get; set; } = default!;
        public ITypeSymbol BaseValueType { get; set; } = default!;
        public OptionFlags OptionFlags { get; set; } = OptionFlags.None;
    }
}
