using System;

using ValueObjectGenerator;

namespace Demo
{
    // struct version
    [ValueObject( typeof(int) )]
    public partial struct Sample
    {
        // By default, the Validate method is implemented and the value is checked in the constructor
        private static partial int Validate( int value )
        {
            if( value < 0 )
            {
                throw new ArgumentException( "value must be than 0" );
            }
            // The returned value will be assigned to the value member
            return value;
        }
    }

    // class version
    [ValueObject( typeof(int), Option = ValueOption.NonValidating)]
    public partial class SampleObject
    {}

    [ValueObject( typeof(int))]
    // NonNegative: Cannot assign a negative number
    [ValueNonNegative]
    public partial class NonNegativeValue
    {}

    // Explicitly set the name of the value variable
    [ValueObject( typeof(int), ValueName = "Point" )]
    // Set an explicit range of values
    [ValueRange( 0, 9999 )]
    public partial class Hp
    {}

    // Explicit implementation of the ToString method
    [ValueObject(typeof(Guid), Option = ValueOption.NonValidating | ValueOption.ToString)]
    public partial class MyGuid
    {
        private partial string ToStringImpl()
            => Value.ToString( "D" );

    }
}
