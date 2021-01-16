namespace ValueGenerator
{
    [System.Flags]
    internal enum OptionFlags
    {
        None = 0,
        Validate = 1 << 0,
        Implicit = 1 << 1,
        Comparable = 1 << 2,
    }
}