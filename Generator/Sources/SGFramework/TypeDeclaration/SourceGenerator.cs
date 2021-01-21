using System;
using System.Collections.Generic;
using System.Diagnostics;

using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace ValueObjectGenerator.SGFramework.TypeDeclaration
{
    public abstract class SourceGenerator<TReceiver> : ISourceGenerator
        where TReceiver : ITypeDeclarationSyntaxReceiver
    {
        protected Dictionary<AttributeTypeName, IAttributeArgumentParser> AttributeArgumentParsers { get; } = new();

        #region Abstruct, Virtual methods
#if DEBUG
        protected abstract bool LaunchDebuggerOnInit { get; }
#endif
        protected abstract TReceiver CreateReceiver();
        protected abstract void SetupAttributeArgumentParser( Dictionary<AttributeTypeName, IAttributeArgumentParser> map );
        protected abstract void GenerateAttributeCode( GeneratorExecutionContext context );
        protected abstract string GenerateCode(
            TypeDeclarationSyntax declaration,
            string nameSpace,
            string typeName,
            IDictionary<AttributeTypeName, IDictionary<AttributeParamName, object>> attributeTypeList );
        #endregion

        public virtual void Initialize( GeneratorInitializationContext context )
        {
#if DEBUG
            if( LaunchDebuggerOnInit && !Debugger.IsAttached )
            {
                Debugger.Launch();
            }
#endif
            SetupAttributeArgumentParser( AttributeArgumentParsers );

            var receiver = CreateReceiver();
            context.RegisterForSyntaxNotifications( () => receiver );
        }

        public virtual void Execute( GeneratorExecutionContext context )
        {
            try
            {
                GenerateAttributeCode( context );

                var receiver = context.SyntaxReceiver is TReceiver syntaxReceiver ? syntaxReceiver : default;
                if( receiver == null )
                {
                    return;
                }

                var declarations = CollectDeclarations( context, receiver );

                foreach( var x in declarations )
                {
                    var symbol = context.Compilation.GetSemanticModel( x.Syntax.SyntaxTree ).GetDeclaredSymbol( x.Syntax );

                    if( symbol == null )
                    {
                        throw new Exception( "Cannot access to Declaration SyntaxTree" );
                    }

                    var ns = symbol.ContainingNamespace.ToDisplayString();
                    var name = symbol.Name;
                    var hintName = $"{ns}.{name}.cs";

                    if( string.IsNullOrEmpty( ns ) )
                    {
                        ns = hintName = string.Empty;
                    }

                    var code = GenerateCode( x.Syntax, ns, name, x.AttributeList );

                    if( !string.IsNullOrEmpty( code ) )
                    {
                        context.AddSource( hintName, code );
                    }
                }
            }
            catch( Exception e )
            {
                Trace.WriteLine( e );
            }

        }

        #region Collect

        private IReadOnlyCollection<TypeDeclarationContext> CollectDeclarations(
            GeneratorExecutionContext context,
            TReceiver receiver )
        {
            var result = new List<TypeDeclarationContext>();

            foreach( var declaration in receiver.Declarations.Keys )
            {
                var ctx = new TypeDeclarationContext( context, declaration );

                CollectAttributes( receiver, declaration, ctx );
                result.Add( ctx );
            }

            return result;
        }

        private void CollectAttributes(
            TReceiver receiver,
            TypeDeclarationSyntax declaration,
            TypeDeclarationContext context )
        {
            foreach( var attribute in receiver.Declarations[ declaration ] )
            {
                if( attribute.ArgumentList is null )
                {
                    continue;
                }

                var attributeName = new AttributeTypeName( attribute.Name.ToString() );

                if( !AttributeArgumentParsers.TryGetValue( attributeName, out var parser ) )
                {
                    continue;
                }

                var attributeArgumentCount = attribute.ArgumentList.Arguments.Count;
                var attributeParameters = new Dictionary<AttributeParamName, object>();

                for( var index = 0; index < attributeArgumentCount; index++ )
                {
                    var argument = attribute.ArgumentList.Arguments[ index ];
                    var argumentExpression = argument.Expression;

                    parser.ParseAttributeArgument(
                        index,
                        argument,
                        context.SemanticModel,
                        argumentExpression,
                        attributeParameters
                    );
                }

                context.AttributeList[ attributeName ] = attributeParameters;
            }
        }
        #endregion
    }
}
