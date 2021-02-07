namespace ValueObjectGenerator
{
    internal partial class ValueObjectTemplate
    {
        internal string Namespace { get; set; } = string.Empty;
        internal bool IsClass { get; set; } = false;
        internal bool IsStruct { get; set; } = false;
        internal string Name { get; set; } = string.Empty;
        internal string BaseTypeName { get; set; } = string.Empty;
        internal string ValueName { get; set; } = string.Empty;
        internal ValueOption ValueOption { get; set; } = ValueOption.None;
        internal string Min { get; set; } = string.Empty;
        internal string Max { get; set; } = string.Empty;
    }
}
