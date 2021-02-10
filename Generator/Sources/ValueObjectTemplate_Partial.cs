using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace ValueObjectGenerator
{
    internal partial class ValueObjectTemplate
    {
        internal string Namespace { get; set; } = string.Empty;
        internal TypeDeclarationSyntax DeclarationSyntax { get; set; } = null!;
        internal string Name { get; set; } = string.Empty;
        internal string BaseTypeName { get; set; } = string.Empty;
        internal string ValueName { get; set; } = string.Empty;
        internal ValueOption ValueOption { get; set; } = ValueOption.None;
        internal string Min { get; set; } = string.Empty;
        internal string Max { get; set; } = string.Empty;
        internal bool NotNegative { get; set; } = false;
        internal bool AllowEmptyString { get; set; } = false;
        internal bool NotEmpty { get; set; } = false;
    }
}
