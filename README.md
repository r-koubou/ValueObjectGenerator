# ValueObject Generator

Generating code of value object by C# 9.0 [Source Generator](https://devblogs.microsoft.com/dotnet/introducing-c-source-generators/)



## Simple

Simple value objects can be created.



## Example

```c#
[ValueOf(typeof(int))]
public partial class Sample // 'struct' also supporting
{
    // By default, the Validate method is implemented and the value is checked in the constructor
    private static partial int Validate( int value ) => value;
}
```

will be generated to following

```c#
using System;
using System.Diagnostics.CodeAnalysis;

public partial struct Sample : IEquatable<Sample>
{
    public int Value { get; }

    public Sample( int value )
    {
        Value = Validate( value );
    }

    private static partial int Validate( int value );

    //
    // Default ToString()
    //
    public override string ToString()
    {
        return Value.ToString();
    }

    //----------------------------------------------------------------------
    // Equality
    //----------------------------------------------------------------------
    public bool Equals( Sample other )
    {
        return Equals( Value, other.Value );
    }

    public override bool Equals( [AllowNull] object obj )
    {
        return obj is Sample other && Equals( other );
    }

    // HashCode
    public override int GetHashCode() => Value.GetHashCode();

    // Operator ==, !=
    public static bool operator ==( Sample a, Sample b )
    {
        return a.Equals( b );
    }

    public static bool operator !=( Sample a, Sample b )
    {
        return !( a == b );
    }

    //----------------------------------------------------------------------
    // Explicit
    //----------------------------------------------------------------------
    public static explicit operator int( Sample x )
    {
        return x.Value;
    }

    public static implicit operator Sample( int value )
    {
        return new Sample( value );
    }
}
```



## Set your Variable name

A `ValueName` parameter will set your variable name

```c#
// Explicitly set the name of the value variable
[ValueObject(typeof(int), ValueName ="Point")]
public partial class Hp
{}
```

to

```c#
public partial class Hp : IEquatable<Hp>
{
    public int Point { get; } // variable name will be "Point" (default: "Value")
}
```



## Limit values by range setting

```c#
[ValueObject(typeof(int))]
// Set an explicit range of values
[ValueRange(0, 9999)]
public partial class Count
{}
```

to

```c#
public partial class Count : IEquatable<Count>
{
    public int Value { get; }

    public Count( int value )
    {
        if( value < (0) || value > (9999) )
        {
            throw new ArgumentOutOfRangeException( $"Hp : {value} (range:0 < 9999)" );
        }
        Value = value;
    }
  :
  :
}
```



## Option

if set an`OptionFlags` value, Generate code according to the flag value

- NonValidation

    - Don't validate in constructor

- Implicit

    - Add  implicit operato

- Comparable

  - Add  IComparable\<T\> implementation




### NonValidation


```c#
[ValueObject( typeof(int), Option = ValueOption.NonValidating)]
public partial class Sample
{}
```



### Implicit

```c#
[ValueObject( typeof(int), ValueOption.Implicit )]
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
