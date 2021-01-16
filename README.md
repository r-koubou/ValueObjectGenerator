# ValueObject Generator

Generating code of value object by C# 9.0 [Source Generator](https://devblogs.microsoft.com/dotnet/introducing-c-source-generators/)



## Simple

Simple value objects can be created.



## Example

```c#
[ValueOf(typeof(int))]
public partial class Sample
{}
```

will be generated to following

```c#
using System;

namespace Demo
{
    public partial class Sample : IEquatable<Sample>
    {
        public int Value { get; }

        public Sample( int value )
        {
            Value = value;
        }

        public override string ToString()
        {
            return Value.ToString();
        }

        //----------------------------------------------------------------------
        // Equality
        //----------------------------------------------------------------------
        public bool Equals( Sample other )
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

        public override bool Equals( object obj )
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

            return Equals( (Sample)obj );
        }

        public override int GetHashCode() => Value.GetHashCode();

        //----------------------------------------------------------------------
        // Explicit
        //----------------------------------------------------------------------
        public static explicit operator string( Text1 x )
        {
            return x.Value;
        }

        public static implicit operator Text1( string value )
        {
            return new Text1( value );
        }

    }
}
```



## Option

if set an`OptionFlags` value, Generate code according to the flag value

- Validation

    - Validation in constructor

- Implicit

    - Add  implicit operato

- Comparable

  - Add  IComparable\<T\> implementation




### Validation


```c#
[ValueOf( typeof(int), OptionFlags.Validate )]
public partial class Sample
{
    // You can add validation code
    protected virtual partial int Validate( int value )
    {
        if( value < 0 )
        {
            throw new ArgumentException( "value must be > 0" );
        }
        return value;
    }
}
```

`Validate` method will be added

```c#
public partial class Sample : IEquatable<Sample>
{
    public int Value { get; }

    public Sample( int value )
    {
        Value = Validate( value );
    }

    protected virtual partial int Validate( int value );
:
:
:
```



### Implicit

```c#
[ValueOf( typeof(int), OptionFlags.Implicit )]
public partial class Sample{}
```

Implicit operators will be added in place of explicit operators.

```c#
public static implicit operator int( Sample x )
{
    return x.Value;
}

public static implicit operator Sample( int value )
{
    return new Sample( value );
}
```

Implicit type conversion enables code writing like the following

```c#
Sample sample = 1; // new Sample( 1 );
int value = sample; // Sample.Value
```
