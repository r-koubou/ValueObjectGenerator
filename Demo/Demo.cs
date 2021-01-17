using System;

using ValueObjectGenerator;

namespace Demo
{
    [ValueObject( typeof(int) )]
    public partial class Id
    {
        private static partial int Validate( int value )
        {
            if( value < 0 )
            {
                throw new ArgumentException( "value must be grater than 0" );
            }
            return value;
        }
    }
}
