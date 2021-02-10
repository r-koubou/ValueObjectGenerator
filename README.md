# ValueObject Generator

Generating code of value object by C# 9.0 [Source Generator](https://devblogs.microsoft.com/dotnet/introducing-c-source-generators/)



## Simple

Simple value objects can be created.



## Example

```c#
[ValueObject(typeof(int))]
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
        return Value.ToString() ?? "";
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
}
```



------



## ValueObject Attribute

`[ValueObject <type>, [ValueName], [Option] ]`

### Type (*Required)

Type of value. use typeof syntax.

### ValiableName

Applied to variable name (default: "Value")

e.g.

```c#
// Explicitly set the name of the value variable
[ValueObject(typeof(int), ValueName ="Point")]
public partial class Hp {}
```

will be generated to following

```c#
public partial class Hp : IEquatable<Hp>
{
    public int Point { get; } // variable name will be "Point" (default: "Value")
}
```



### Option

Flags to specify additional value specifications.

if set an`OptionFlags` value to ValueObjectAttribute, Generate code according to the flag value

- NonValidation

    - Don't validate in constructor

- Implicit / Explicit

    - Add  implicit / explicit operator

- Comparable

  - Add  IComparable\<T\> implementation




### NonValidation


```c#
[ValueObject( typeof(int), Option = ValueOption.NonValidating)]
public partial class Sample {}
```

### Explicit

```c#
[ValueObject( typeof(int), ValueOption.Explicit )]
public partial class Sample {}
```

will be generated to following

```c#
public static explicit operator int( Sample x )
{
    return x.Value;
}

public static implicit operator Sample( int value )
{
    return new Sample( value );
}
```

### Implicit

```c#
[ValueObject( typeof(int), ValueOption.Implicit )]
public partial class Sample {}
```

will be generated to following

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



------



## Available other attribute

Provides presets for validation. In many cases, it is exclusive to the Validate method.

### Limit values by range setting

```c#
[ValueObject(typeof(int))]
// Set an explicit range of values
[ValueRange(0, 9999)]
public partial class Count
{}
```

will be generated to following

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



### Limit values by non-negative

```c#
[ValueObject(typeof(int))]
[NotNegative]
public partial class Count {}
```

will be generated to following

```c#
public partial class Count : IEquatable<Count>
{
    public int Value { get; }

    public Count( int value )
    {
        if( value < 0 )
        {
            throw new ArgumentException( $"value is negative : {value}" );
        }
        Value = value;
    }
  :
  :
}
```



### Allow empty string

```c#
[ValueObject(typeof(string))]
[AllowEmptyString]
public partial class Name {}
```

will be generated to following

```c#
public partial class Name : IEquatable<Count>
{
    public string Value { get; }

    public AllowEmptyString( string value )
    {
        Value = string.IsNullOrEmpty( value ) ? string.Empty : value;
    }
  :
  :
}
```



### Deny empty

NOTE: Require Linq

```c#
[ValueObject(typeof(string))]
[NotEmpty]
public partial class Name {}
```

will be generated to following

```c#
public partial class Name : IEquatable<Count>
{
    public string Value { get; }

    public AllowEmptyString( string value )
    {
        if( !value.Any() )
        {
            throw new ArgumentException( $"(Name) : value is empty" );
        }
        Value = value;
    }
  :
  :
}
```
