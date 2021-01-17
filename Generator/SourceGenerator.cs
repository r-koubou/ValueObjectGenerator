using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;

using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace ValueObjectGenerator
{
    [Generator]
    public class SourceGenerator : ISourceGenerator
    {
        private const string ValueOfAttributeName = "ValueObject";

        public void Initialize( GeneratorInitializationContext context )
        {
#if DEBUG
            if( !Debugger.IsAttached )
            {
                //Debugger.Launch();
            }
#endif

            context.RegisterForSyntaxNotifications( () => new SyntaxReceiver() );
        }

        public void Execute( GeneratorExecutionContext context )
        {
            GenerateValueOfAttribute( context );

            try
            {
                var receiver = context.SyntaxReceiver as SyntaxReceiver;
                if( receiver == null )
                {
                    return;
                }

                GenerateValueObjectCode( context, receiver );

            }
            catch( Exception e )
            {
                Trace.WriteLine( e );
            }
        }

        #region ValueOfAttribute
        private static void GenerateValueOfAttribute( GeneratorExecutionContext context )
        {
            context.AddSource( (string)ValueOfAttributeName, new ValueObjectAttributeTemplate().TransformText() );
        }
        #endregion

        #region ValueObject
        private static void GenerateValueObjectCode( GeneratorExecutionContext context, SyntaxReceiver receiver )
        {
            var classes = CorrectClasses( context, receiver );

            foreach( var info in classes )
            {
                var symbol = context.Compilation.GetSemanticModel( info.Declaration.SyntaxTree ).GetDeclaredSymbol( info.Declaration );

                if( symbol == null )
                {
                    throw new Exception( "Cannot access to Declaration SyntaxTree" );
                }

                var ns = symbol.ContainingNamespace.ToDisplayString();
                var name = symbol.Name;
                var baseTypeName = info.BaseValueType.ToString();

                var template = new ValueObjectTemplate()
                {
                    Namespace    = ns,
                    Name         = name,
                    BaseTypeName = baseTypeName,
                    ValueOption  = info.ValueOption
                };

                var code = template.TransformText();

                context.AddSource( (string)$"{ns}.{symbol.Name}", code );
            }
        }

        private static IReadOnlyCollection<ValueObjectContext> CorrectClasses(
            GeneratorExecutionContext context,
            SyntaxReceiver receiver )
        {
            var list = new List<ValueObjectContext>();

            foreach( var (declaration, attribute) in receiver.Declarations )
            {
                var typeSyntax = declaration;
                var attributeSyntax = attribute;

                if( attributeSyntax.ArgumentList is null )
                {
                    continue;
                }

                var classInfo = new ValueObjectContext();
                var semanticModel = context.Compilation.GetSemanticModel( typeSyntax.SyntaxTree );

                classInfo.Declaration = typeSyntax;

                for( var index = 0; index < attributeSyntax.ArgumentList.Arguments.Count; index++ )
                {
                    var argument = attributeSyntax.ArgumentList.Arguments[ index ];
                    var argumentExpr = argument.Expression;

                    switch( index )
                    {
                        case 0: CorrectTypeOfSyntax( argumentExpr, semanticModel, classInfo ); break;
                        case 1: CorrectValueOptionSyntax( argumentExpr, classInfo ); break;
                    }
                }

                list.Add( classInfo );
            }

            return list;
        }

        private static void CorrectTypeOfSyntax( ExpressionSyntax argumentExpr, SemanticModel semanticModel, ValueObjectContext classInfo )
        {
            if( argumentExpr is TypeOfExpressionSyntax typeExpression )
            {
                if( !( semanticModel.GetSymbolInfo( typeExpression.Type ).Symbol is ITypeSymbol symbol ) )
                {
                    throw new SyntaxErrorException( "type is missing" );
                }

                classInfo.BaseValueType = symbol;
            }
        }

        private static void CorrectValueOptionSyntax( ExpressionSyntax argumentExpr, ValueObjectContext classInfo )
        {
            var enumValue = Enum.Parse(
                typeof(ValueOption),
                argumentExpr.ToString()
                            .Replace( $"{nameof(ValueOption)}.", "" )
                            .Replace( "|", "," ) );

            classInfo.ValueOption = (ValueOption)enumValue;
        }

        #endregion

        #region Receiver
        class SyntaxReceiver : ISyntaxReceiver
        {
            private readonly List<(TypeDeclarationSyntax,AttributeSyntax)> _declarations = new List<(TypeDeclarationSyntax,AttributeSyntax)>();

            public IReadOnlyCollection<(TypeDeclarationSyntax,AttributeSyntax)> Declarations
                => new List<(TypeDeclarationSyntax,AttributeSyntax)>( _declarations );

            public void OnVisitSyntaxNode( SyntaxNode syntaxNode )
            {
                if( syntaxNode is ClassDeclarationSyntax syntax && syntax.AttributeLists.Count > 0 )
                {
                    var attribute = syntax.AttributeLists
                              .SelectMany( x => x.Attributes )
                              .FirstOrDefault( x => x.Name.ToString() is ValueOfAttributeName or ValueOfAttributeName + "Attribute" );

                    if( attribute != null )
                    {
                        _declarations.Add( ( syntax, attribute ) );
                    }
                }
            }
        }
        #endregion
    }
}
