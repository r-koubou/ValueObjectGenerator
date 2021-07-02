# ValueObject Generator

Generating code of value object by C# 9.0 [Source Generator](https://devblogs.microsoft.com/dotnet/introducing-c-source-generators/)

Simple value objects can be created.



## Example

```c#
[ValueObject(typeof(int))]
public partial class Sample // 'struct' also supporting
{
    // By default, the Validate method is defined and called from constructor
    // If ValueOption.NonValidating is set, Validate method will not be defined
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

    - Don't genetate `Valid` method
    - Don't validate in constructor

- Implicit / Explicit

    - Add  implicit / explicit operator

- Comparable

  - Add  IComparable\<T\> implementation




### NonValidation


```c#
[ValueObject( typeof(int), Option = ValueOption.NonValidating)]
public partial class Sample {}

// *Validate method will not be defined
// private static partial int Validate( int value );
```

### Explicit

```c#
[ValueObject( typeof(int), Option = ValueOption.Explicit )]
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
[ValueObject( typeof(int), Option = ValueOption.Implicit )]
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

### Value range

```c#
[ValueObject(typeof(int))]
// Set an explicit range of values
[ValueRange(0, 9999)]
public partial class Count {}
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
            throw new ArgumentOutOfRangeException( $"(Count) Out of range : {value} (range:0 < 9999)" );
        }
        Value = value;
    }
  :
  :
}
```



### Not negative

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
            throw new ArgumentException( $"(Count) value is negative : {value}" );
        }
        Value = value;
    }
  :
  :
}
```



### Not empty

```c#
[ValueObject(typeof(string))]
[NotEmpty]
public partial class Name {}
```

will be generated to following

```c#
public partial class Name : IEquatable<Name>
{
    public string Value { get; }

    public Name( string value )
    {
        if( string.IsNullOrEmpty( value ) || value.Trim().Length == 0 )
        {
            throw new ArgumentException( $"(Name) value is empty" );
        }
        Value = value;
    }
  :
  :
}
```

Note: if type is string, use string.IsNullOrEmpty, Trim. Otherwise use Linq.Any()

e,g,

```c#
[ValueObject(typeof(string[]))]
[NotEmpty]
public partial class Names {}
```

will be generated to following

```c#
public partial class Names : IEquatable<Names>
{
    public string[] Value { get; }

    public Names( string[] value )
    {
        if( !value.Any() )
        {
            throw new ArgumentException( $"(Names) value is empty" );
        }
        Value = value;
    }
  :
  :
}
```

If you do not want to treat a string with only whitespace characters as Empty, set the **ExcludeWhiteSpace** argument to true.

```c#
[ValueObject(typeof(string))]
[NotEmpty(ExcludeWhiteSpace=true)]
public partial class Name {}
```

will be generated to following

```c#
public partial class Name : IEquatable<Name>
{
    public string Value { get; }

    public Name( string value )
    {
        if( string.IsNullOrEmpty( value ) )
        {
            throw new ArgumentException( $"(Name) value is empty" );
        }
        Value = value;
    }
  :
  :
}
```
