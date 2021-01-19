using System.Collections.Generic;

using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

using ValueObjectGenerator.SGFramework;
using ValueObjectGenerator.SGFramework.TypeDeclaration;

namespace ValueObjectGenerator
{
    [Generator]
    internal class ValueObjectGenerator : SourceGenerator<TypeDeclarationSyntaxReceiver>, IAttributeContainsChecker
    {
        private static readonly AttributeTypeName ValueObjectAttributeTypeName = new ( "ValueObject" );
        private static readonly AttributeTypeName ValueRangeAttributeTypeName = new ( "ValueRange" );

#if DEBUG
        protected override bool LaunchDebuggerOnInit => false;
#endif

        protected override TypeDeclarationSyntaxReceiver CreateReceiver()
            => new( this );

        protected override void SetupAttributeArgumentParser( Dictionary<AttributeTypeName, IAttributeArgumentParser> map )
        {
            map[ ValueObjectAttributeTypeName ] = new ValueObjectAttributeArgumentParser();
            map[ ValueRangeAttributeTypeName ]  = new ValueRangeAttributeArgumentParser();
        }

        public bool ContainsAttribute( AttributeTypeName attributeTypeName ) =>
            attributeTypeName == ValueObjectAttributeTypeName ||
            attributeTypeName == ValueRangeAttributeTypeName;

        protected override void GenerateAttributeCode( GeneratorExecutionContext context )
        {
            context.AddSource( ValueObjectAttributeTypeName.Value, new ValueObjectAttributeTemplate().TransformText() );
            context.AddSource( ValueRangeAttributeTypeName.Value, new ValueRangeAttributeTemplate().TransformText() );
        }

        protected override string GenerateCode(
            TypeDeclarationSyntax declaration,
            string nameSpace,
            string typeName,
            IDictionary<AttributeTypeName, IDictionary<AttributeParamName, object>> attributeTypeList )
        {

            #region Get Attributes
            if( !attributeTypeList.TryGetValue( ValueObjectAttributeTypeName, out var valueObjectAttributeParams ))
            {
                // "ValueObject" is Require attribute
                return string.Empty;
            }
            if( !attributeTypeList.TryGetValue( ValueRangeAttributeTypeName, out var valueRangeAttributeParams ))
            {
                // "ValueObject" is NOT Require attribute
                valueRangeAttributeParams = null!;
            }
            #endregion

            #region ValueObjectAttribute
            if( !valueObjectAttributeParams.TryGetValue( AttributeParameterNames.BaseName, out var baseName ) )
            {
                return string.Empty;
            }

            if( !valueObjectAttributeParams.TryGetValue( AttributeParameterNames.OptionFlags, out var valueOption ) )
            {
                valueOption = ValueOption.None;
            }
            #endregion

            #region ValueRangeAttribute
            object minValue = string.Empty;
            object maxValue = string.Empty;
            if( valueRangeAttributeParams != null! )
            {
                if( !valueRangeAttributeParams.TryGetValue( AttributeParameterNames.Min, out minValue ) )
                {
                    minValue = string.Empty;
                }
                if( !valueRangeAttributeParams.TryGetValue( AttributeParameterNames.Max, out maxValue ) )
                {
                    maxValue = string.Empty;
                }
            }
            #endregion

            var template = new ValueObjectTemplate()
            {
                Namespace    = nameSpace,
                Name         = typeName,
                BaseTypeName = (string)baseName,
                ValueOption  = (ValueOption)valueOption,
                Min          = minValue.ToString(),
                Max          = maxValue.ToString()
            };

            var code = template.TransformText();

            return code;
        }
    }
}
