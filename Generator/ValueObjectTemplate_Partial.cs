namespace ValueObjectGenerator
{
    internal partial class ValueObjectTemplate
    {
        internal string Namespace { get; set; } = string.Empty;
        internal string Name { get; set; } = string.Empty;
        internal string BaseTypeName { get; set; } = string.Empty;
        internal OptionFlags Option { get; set; } = OptionFlags.None;
    }
}
