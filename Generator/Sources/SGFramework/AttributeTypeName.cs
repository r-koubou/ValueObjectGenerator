using System;

namespace ValueObjectGenerator.SGFramework
{
    public class AttributeTypeName : IEquatable<AttributeTypeName>
    {
        public string Value { get; }

        public AttributeTypeName( string value )
        {
            Value = value;
        }

        public bool Equals( AttributeTypeName? other )
        {
            if( ReferenceEquals( null, other ) )
            {
                return false;
            }

            if( ReferenceEquals( this, other ) )
            {
                return true;
            }

            return Value == other.Value;
        }

        public override bool Equals( object? obj )
        {
            if( ReferenceEquals( null, obj ) )
            {
                return false;
            }

            if( ReferenceEquals( this, obj ) )
            {
                return true;
            }

            if( obj.GetType() != this.GetType() )
            {
                return false;
            }

            return Equals( (AttributeTypeName)obj );
        }

        public override int GetHashCode() => Value.GetHashCode();

        public static bool operator ==( AttributeTypeName? left, AttributeTypeName? right ) => Equals( left, right );

        public static bool operator !=( AttributeTypeName? left, AttributeTypeName? right ) => !Equals( left, right );
    }
}
