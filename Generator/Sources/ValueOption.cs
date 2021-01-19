using System;

namespace ValueObjectGenerator
{
    [Flags]
    internal enum ValueOption
    {
        None = 0,
        NonValidating = 1 << 0,
        Implicit = 1 << 1,
        Comparable = 1 << 2,
    }
}