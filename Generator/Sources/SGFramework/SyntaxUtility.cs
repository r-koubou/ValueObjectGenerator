using System;

using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace ValueObjectGenerator.SGFramework
{
    public static class SyntaxUtility
    {
        public static TEnum ParseEnumValue<TEnum>( ExpressionSyntax expression ) where TEnum : Enum
        {
            var type = typeof(TEnum);
            var enumName = expression.ToString()
                                     .Replace( $"{type.Name}.", "" )
                                     .Replace( "|", "," );

            var enumValue = Enum.Parse( type, enumName );

            return (TEnum)enumValue;
        }
    }
}
