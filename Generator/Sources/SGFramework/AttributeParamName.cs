using System;

namespace ValueObjectGenerator.SGFramework
{
    public class AttributeParamName : IEquatable<AttributeParamName>
    {
        public string Value { get; }

        public AttributeParamName( string value )
        {
            Value = value;
        }

        public bool Equals( AttributeParamName? other )
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

            return Equals( (AttributeParamName)obj );
        }

        public override int GetHashCode() => Value.GetHashCode();

        public static bool operator ==( AttributeParamName? left, AttributeParamName? right ) => Equals( left, right );

        public static bool operator !=( AttributeParamName? left, AttributeParamName? right ) => !Equals( left, right );
    }
}
