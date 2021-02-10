using System;

namespace ValueObjectGenerator
{
    [Flags]
    internal enum ValueOption
    {
        None = 0,
        NonValidating = 1 << 0,
        Explicit = 1 << 1,
        Implicit = 1 << 2,
        Comparable = 1 << 3,
        ToString = 1 << 4,
    }
}