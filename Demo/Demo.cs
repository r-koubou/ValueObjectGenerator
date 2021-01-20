using System;

using ValueObjectGenerator;

namespace Demo
{
    [ValueObject(typeof(int))]
    [ValueRange(0, 9999)]
    public partial class Hp
    {}

    [ValueObject(typeof(Guid), ValueOption.NonValidating | ValueOption.ToString)]
    public partial class MyGuid
    {
        private partial string ToStringImpl()
            => Value.ToString( "D" );

    }
}
