using System.Collections.Generic;

using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

using SGFramework;
using SGFramework.TypeDeclaration;

using ValueObjectGenerator.ExtAttributes;
using ValueObjectGenerator.ExtAttributes.Number;

namespace ValueObjectGenerator
{
    [Generator]
    internal class ValueObjectGenerator : SourceGenerator<TypeDeclarationSyntaxReceiver>, IAttributeContainsChecker
    {
        private static readonly AttributeTypeName ValueObjectAttributeTypeName = new( "ValueObject" );
        private static readonly AttributeTypeName RangeAttributeTypeName = new( "ValueRange" );
        private static readonly AttributeTypeName NotNegativeAttributeTypeName = new( "NotNegative" );
        private static readonly AttributeTypeName AllowEmptyAttributeTypeName = new( "AllowEmpty" );
        private static readonly AttributeTypeName NotEmptyAttributeTypeName = new( "NotEmpty" );

        public override TypeDeclarationSyntaxReceiver CreateSyntaxReceiver() => new( this );

        public override void SetupAttributeArgumentParser( Dictionary<AttributeTypeName, IAttributeArgumentParser> map )
        {
            map[ ValueObjectAttributeTypeName ] = new ValueObjectAttributeArgumentParser();
            map[ RangeAttributeTypeName ]       = new RangeAttributeArgumentParser();
            map[ NotNegativeAttributeTypeName ] = new EmptyAttributeArgumentParser();
            map[ AllowEmptyAttributeTypeName ]  = new EmptyAttributeArgumentParser();
            map[ NotEmptyAttributeTypeName ]    = new EmptyAttributeArgumentParser();
        }

        public bool ContainsAttribute( AttributeTypeName attributeTypeName ) =>
            attributeTypeName == ValueObjectAttributeTypeName ||
            attributeTypeName == RangeAttributeTypeName ||
            attributeTypeName == NotNegativeAttributeTypeName ||
            attributeTypeName == AllowEmptyAttributeTypeName ||
            attributeTypeName == NotEmptyAttributeTypeName;

        public override void GenerateAttributeCode( GeneratorExecutionContext context )
        {
            context.AddSource( ValueObjectAttributeTypeName.Value, new ValueObjectAttributeTemplate().TransformText() );
            context.AddSource( RangeAttributeTypeName.Value,       new ValueRangeAttributeTemplate().TransformText() );
            context.AddSource( NotNegativeAttributeTypeName.Value, new NotNegativeAttributeTemplate().TransformText() );
            context.AddSource( AllowEmptyAttributeTypeName.Value,  new AllowEmptyAttributeTemplate().TransformText() );
            context.AddSource( NotEmptyAttributeTypeName.Value,    new NotEmptyAttributeTemplate().TransformText() );
        }

        protected override string GenerateCode(
            TypeDeclarationSyntax declaration,
            string nameSpace,
            string typeName,
            IDictionary<AttributeTypeName, IDictionary<AttributeParamName, object>> attributeTypeList )
        {
            #region Get Attributes
            if( !attributeTypeList.TryGetValue( ValueObjectAttributeTypeName, out var valueObjectAttributeParams ) )
            {
                // "ValueObject" is Require attribute
                return string.Empty;
            }

            if( !attributeTypeList.TryGetValue( RangeAttributeTypeName, out var rangeAttributeParams ) )
            {
                // "ValueObject" is NOT Require attribute
                rangeAttributeParams = null!;
            }

            if( !attributeTypeList.TryGetValue( NotNegativeAttributeTypeName, out var notNegativeAttributeParams ) )
            {
                // "ValueObject" is NOT Require attribute
                notNegativeAttributeParams = null!;
            }

            if( !attributeTypeList.TryGetValue( AllowEmptyAttributeTypeName, out var allowEmptyAttributeParams ) )
            {
                // "ValueObject" is NOT Require attribute
                allowEmptyAttributeParams = null!;
            }

            if( !attributeTypeList.TryGetValue( NotEmptyAttributeTypeName, out var notEmptyAttributeParams ) )
            {
                // "ValueObject" is NOT Require attribute
                notEmptyAttributeParams = null!;
            }
            #endregion

            #region ValueObjectAttribute
            if( !valueObjectAttributeParams.TryGetValue( AttributeParameterNames.BaseName, out var baseName ) )
            {
                return string.Empty;
            }

            if( !valueObjectAttributeParams.TryGetValue( AttributeParameterNames.ValueName, out var valueName ) )
            {
                valueName = "Value";
            }

            if( !valueObjectAttributeParams.TryGetValue( AttributeParameterNames.OptionFlags, out var valueOption ) )
            {
                valueOption = ValueOption.None;
            }
            #endregion

            #region RangeAttribute
            object minValue = string.Empty;
            object maxValue = string.Empty;

            if( rangeAttributeParams != null! )
            {
                if( !rangeAttributeParams.TryGetValue( AttributeParameterNames.Min, out minValue ) )
                {
                    minValue = string.Empty;
                }

                if( !rangeAttributeParams.TryGetValue( AttributeParameterNames.Max, out maxValue ) )
                {
                    maxValue = string.Empty;
                }
            }
            #endregion

            var template = new ValueObjectTemplate
            {
                Namespace         = nameSpace,
                DeclarationSyntax = declaration,
                Name              = typeName,
                BaseTypeName      = (string)baseName,
                ValueName         = valueName.ToString(),
                ValueOption       = (ValueOption)valueOption,
                Min               = minValue.ToString(),
                Max               = maxValue.ToString(),
                NotNegative       = notNegativeAttributeParams != null,
                AllowEmpty        = allowEmptyAttributeParams != null,
                NotEmpty          = notEmptyAttributeParams != null
            };

            var code = template.TransformText();

            return code;
        }
    }
}
