using System;

using NUnit.Framework;

using ValueObjectGenerator;

namespace Tests
{
    [ValueObject( typeof(int), ValueOption.NonValidating )]
    public partial class IntObject {}

    [ValueObject( typeof(int), ValueOption.NonValidating | ValueOption.Implicit )]
    public partial class IntImplicitObject {}

    [ValueObject( typeof(string) )]
    public partial class ValidatedString
    {
        private static partial string Validate( string value )
        {
            if( string.IsNullOrEmpty( value ) )
            {
                throw new ArgumentException( "value is empty" );
            }

            return value;
        }
    }

    public class ValueTest
    {
        [Test]
        [TestCase( 0 )]
        [TestCase( 10 )]
        [TestCase( 100 )]
        public void SameValueTest( int v )
        {
            var var1 = new IntObject( v );
            Assert.IsTrue( var1 == new IntObject( v )  );
            Assert.IsFalse( var1 == new IntObject( v + 1 )  );
            Assert.AreEqual( var1, new IntObject( v ) );

            IntObject nullObj = null!;
            Assert.IsFalse( var1 == nullObj  );
            Assert.IsTrue( var1 != nullObj  );
        }

        [Test]
        [TestCase( 100 )]
        public void ImplicitCastTest( int v )
        {
            var implicitObject = new IntImplicitObject( v );
            int intValue = implicitObject;
            Assert.AreEqual( v, intValue );

            intValue       = v;
            implicitObject = intValue;
            Assert.AreEqual( implicitObject.Value, v );

        }

        [Test]
        public void ValidTest()
        {
            Assert.Catch<ArgumentException>( () => _ = new ValidatedString( "" ) );
            Assert.Catch<ArgumentException>( () => _ = new ValidatedString( null! ) );
        }
    }
}
