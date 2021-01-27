﻿// ------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version: 16.0.0.0
//  
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
// ------------------------------------------------------------------------------
namespace ValueObjectGenerator
{
    using System;
    
    /// <summary>
    /// Class to produce the template output
    /// </summary>
    
    #line 1 "/Users/hiroaki/Develop/Project/OSS/ValueObjectGenerator/Generator/Sources/ValueObjectTemplate.tt"
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.TextTemplating", "16.0.0.0")]
    internal partial class ValueObjectTemplate : ValueObjectTemplateBase
    {
#line hidden
        /// <summary>
        /// Create the template output
        /// </summary>
        public virtual string TransformText()
        {
            this.Write("//\n// Generated by ValueObjectGenerator\n// DO NOT EDIT THIS FILE\n//\nusing System;\nusing System.Diagnostics.CodeAnalysis;\n");
            
            #line 8 "/Users/hiroaki/Develop/Project/OSS/ValueObjectGenerator/Generator/Sources/ValueObjectTemplate.tt"
 ValueName = ValueName.Replace( "\"", "" ); 
            
            #line default
            #line hidden
            
            #line 9 "/Users/hiroaki/Develop/Project/OSS/ValueObjectGenerator/Generator/Sources/ValueObjectTemplate.tt"
 if( !string.IsNullOrEmpty( Namespace ) ) { 
            
            #line default
            #line hidden
            this.Write("namespace ");
            
            #line 10 "/Users/hiroaki/Develop/Project/OSS/ValueObjectGenerator/Generator/Sources/ValueObjectTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Namespace));
            
            #line default
            #line hidden
            this.Write("\n{\n");
            
            #line 12 "/Users/hiroaki/Develop/Project/OSS/ValueObjectGenerator/Generator/Sources/ValueObjectTemplate.tt"
 } 
            
            #line default
            #line hidden
            this.Write("    public partial class ");
            
            #line 13 "/Users/hiroaki/Develop/Project/OSS/ValueObjectGenerator/Generator/Sources/ValueObjectTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Name));
            
            #line default
            #line hidden
            this.Write(" : IEquatable<");
            
            #line 13 "/Users/hiroaki/Develop/Project/OSS/ValueObjectGenerator/Generator/Sources/ValueObjectTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Name));
            
            #line default
            #line hidden
            this.Write(">");
            
            #line 13 "/Users/hiroaki/Develop/Project/OSS/ValueObjectGenerator/Generator/Sources/ValueObjectTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(ValueOption.HasFlag( ValueOption.Comparable ) ? $", IComparable<{Name}>" : ""));
            
            #line default
            #line hidden
            this.Write("\n    {\n        public ");
            
            #line 15 "/Users/hiroaki/Develop/Project/OSS/ValueObjectGenerator/Generator/Sources/ValueObjectTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(BaseTypeName));
            
            #line default
            #line hidden
            this.Write(" ");
            
            #line 15 "/Users/hiroaki/Develop/Project/OSS/ValueObjectGenerator/Generator/Sources/ValueObjectTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(ValueName));
            
            #line default
            #line hidden
            this.Write(" { get; }\n\n        public ");
            
            #line 17 "/Users/hiroaki/Develop/Project/OSS/ValueObjectGenerator/Generator/Sources/ValueObjectTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Name));
            
            #line default
            #line hidden
            this.Write("( ");
            
            #line 17 "/Users/hiroaki/Develop/Project/OSS/ValueObjectGenerator/Generator/Sources/ValueObjectTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(BaseTypeName));
            
            #line default
            #line hidden
            this.Write(" value )\n        {\n");
            
            #line 19 "/Users/hiroaki/Develop/Project/OSS/ValueObjectGenerator/Generator/Sources/ValueObjectTemplate.tt"
 /* Min, Max */ 
            
            #line default
            #line hidden
            
            #line 20 "/Users/hiroaki/Develop/Project/OSS/ValueObjectGenerator/Generator/Sources/ValueObjectTemplate.tt"
 if( !string.IsNullOrEmpty( Min ) && !string.IsNullOrEmpty( Max ) ) { 
            
            #line default
            #line hidden
            this.Write("            if( value < (");
            
            #line 21 "/Users/hiroaki/Develop/Project/OSS/ValueObjectGenerator/Generator/Sources/ValueObjectTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Min));
            
            #line default
            #line hidden
            this.Write(") || value > (");
            
            #line 21 "/Users/hiroaki/Develop/Project/OSS/ValueObjectGenerator/Generator/Sources/ValueObjectTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Max));
            
            #line default
            #line hidden
            this.Write(") )\n            {\n                throw new ArgumentOutOfRangeException( $\"");
            
            #line 23 "/Users/hiroaki/Develop/Project/OSS/ValueObjectGenerator/Generator/Sources/ValueObjectTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Name));
            
            #line default
            #line hidden
            this.Write(" : {value} (range:");
            
            #line 23 "/Users/hiroaki/Develop/Project/OSS/ValueObjectGenerator/Generator/Sources/ValueObjectTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Min));
            
            #line default
            #line hidden
            this.Write(" < ");
            
            #line 23 "/Users/hiroaki/Develop/Project/OSS/ValueObjectGenerator/Generator/Sources/ValueObjectTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Max));
            
            #line default
            #line hidden
            this.Write(")\" );\n            }\n            ");
            
            #line 25 "/Users/hiroaki/Develop/Project/OSS/ValueObjectGenerator/Generator/Sources/ValueObjectTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(ValueName));
            
            #line default
            #line hidden
            this.Write(" = value;\n");
            
            #line 26 "/Users/hiroaki/Develop/Project/OSS/ValueObjectGenerator/Generator/Sources/ValueObjectTemplate.tt"
 /* No Validation */ 
            
            #line default
            #line hidden
            
            #line 27 "/Users/hiroaki/Develop/Project/OSS/ValueObjectGenerator/Generator/Sources/ValueObjectTemplate.tt"
 } else if( ValueOption.HasFlag( ValueOption.NonValidating ) ) { 
            
            #line default
            #line hidden
            this.Write("            ");
            
            #line 28 "/Users/hiroaki/Develop/Project/OSS/ValueObjectGenerator/Generator/Sources/ValueObjectTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(ValueName));
            
            #line default
            #line hidden
            this.Write(" = value;\n");
            
            #line 29 "/Users/hiroaki/Develop/Project/OSS/ValueObjectGenerator/Generator/Sources/ValueObjectTemplate.tt"
 } else { 
            
            #line default
            #line hidden
            this.Write("            ");
            
            #line 30 "/Users/hiroaki/Develop/Project/OSS/ValueObjectGenerator/Generator/Sources/ValueObjectTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(ValueName));
            
            #line default
            #line hidden
            this.Write(" = Validate( value );\n");
            
            #line 31 "/Users/hiroaki/Develop/Project/OSS/ValueObjectGenerator/Generator/Sources/ValueObjectTemplate.tt"
 } 
            
            #line default
            #line hidden
            this.Write("        }\n\n");
            
            #line 34 "/Users/hiroaki/Develop/Project/OSS/ValueObjectGenerator/Generator/Sources/ValueObjectTemplate.tt"
 /* Validate method */ 
            
            #line default
            #line hidden
            
            #line 35 "/Users/hiroaki/Develop/Project/OSS/ValueObjectGenerator/Generator/Sources/ValueObjectTemplate.tt"
 if( ( string.IsNullOrEmpty( Min ) && string.IsNullOrEmpty( Max ) ) && !ValueOption.HasFlag( ValueOption.NonValidating ) ) { 
            
            #line default
            #line hidden
            this.Write("        private static partial ");
            
            #line 36 "/Users/hiroaki/Develop/Project/OSS/ValueObjectGenerator/Generator/Sources/ValueObjectTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(BaseTypeName));
            
            #line default
            #line hidden
            this.Write(" Validate( ");
            
            #line 36 "/Users/hiroaki/Develop/Project/OSS/ValueObjectGenerator/Generator/Sources/ValueObjectTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(BaseTypeName));
            
            #line default
            #line hidden
            this.Write(" value );\n");
            
            #line 37 "/Users/hiroaki/Develop/Project/OSS/ValueObjectGenerator/Generator/Sources/ValueObjectTemplate.tt"
 } 
            
            #line default
            #line hidden
            this.Write("\n");
            
            #line 39 "/Users/hiroaki/Develop/Project/OSS/ValueObjectGenerator/Generator/Sources/ValueObjectTemplate.tt"
 /* ToString */ 
            
            #line default
            #line hidden
            
            #line 40 "/Users/hiroaki/Develop/Project/OSS/ValueObjectGenerator/Generator/Sources/ValueObjectTemplate.tt"
 if( !ValueOption.HasFlag( ValueOption.ToString ) ) { 
            
            #line default
            #line hidden
            this.Write("        //\n        // Default ToString()\n        //\n        public override string ToString()\n        {\n            return ");
            
            #line 46 "/Users/hiroaki/Develop/Project/OSS/ValueObjectGenerator/Generator/Sources/ValueObjectTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(ValueName));
            
            #line default
            #line hidden
            this.Write(".ToString();\n        }\n");
            
            #line 48 "/Users/hiroaki/Develop/Project/OSS/ValueObjectGenerator/Generator/Sources/ValueObjectTemplate.tt"
 } else { 
            
            #line default
            #line hidden
            this.Write("        //\n        // Custom ToString()\n        //\n        private partial string ToStringImpl();\n\n        public override string ToString()\n        {\n            return ToStringImpl();\n        }\n");
            
            #line 58 "/Users/hiroaki/Develop/Project/OSS/ValueObjectGenerator/Generator/Sources/ValueObjectTemplate.tt"
 } 
            
            #line default
            #line hidden
            this.Write("\n        //----------------------------------------------------------------------\n        // Equality\n        //----------------------------------------------------------------------\n        public bool Equals( [AllowNull] ");
            
            #line 63 "/Users/hiroaki/Develop/Project/OSS/ValueObjectGenerator/Generator/Sources/ValueObjectTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Name));
            
            #line default
            #line hidden
            this.Write(" other )\n        {\n            if( ReferenceEquals( null, other ) )\n            {\n                return false;\n            }\n\n            if( ReferenceEquals( this, other ) )\n            {\n                return true;\n            }\n\n            return ");
            
            #line 75 "/Users/hiroaki/Develop/Project/OSS/ValueObjectGenerator/Generator/Sources/ValueObjectTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(ValueName));
            
            #line default
            #line hidden
            this.Write(" == other.");
            
            #line 75 "/Users/hiroaki/Develop/Project/OSS/ValueObjectGenerator/Generator/Sources/ValueObjectTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(ValueName));
            
            #line default
            #line hidden
            this.Write(";\n        }\n\n        public override bool Equals( [AllowNull] object obj )\n        {\n            if( ReferenceEquals( null, obj ) )\n            {\n                return false;\n            }\n\n            if( ReferenceEquals( this, obj ) )\n            {\n                return true;\n            }\n\n            if( obj.GetType() != this.GetType() )\n            {\n                return false;\n            }\n\n            return Equals( (");
            
            #line 95 "/Users/hiroaki/Develop/Project/OSS/ValueObjectGenerator/Generator/Sources/ValueObjectTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Name));
            
            #line default
            #line hidden
            this.Write(")obj );\n        }\n\n        // HashCode\n        public override int GetHashCode() => ");
            
            #line 99 "/Users/hiroaki/Develop/Project/OSS/ValueObjectGenerator/Generator/Sources/ValueObjectTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(ValueName));
            
            #line default
            #line hidden
            this.Write(".GetHashCode();\n\n        // Operator ==, !=\n        public static bool operator ==( ");
            
            #line 102 "/Users/hiroaki/Develop/Project/OSS/ValueObjectGenerator/Generator/Sources/ValueObjectTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Name));
            
            #line default
            #line hidden
            this.Write(" a, ");
            
            #line 102 "/Users/hiroaki/Develop/Project/OSS/ValueObjectGenerator/Generator/Sources/ValueObjectTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Name));
            
            #line default
            #line hidden
            this.Write(" b )\n        {\n            if( ReferenceEquals( a, b ) )\n            {\n                return true;\n            }\n\n            return a?.Equals( b ) ?? ReferenceEquals( null, b );\n        }\n\n        public static bool operator !=( ");
            
            #line 112 "/Users/hiroaki/Develop/Project/OSS/ValueObjectGenerator/Generator/Sources/ValueObjectTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Name));
            
            #line default
            #line hidden
            this.Write(" a, ");
            
            #line 112 "/Users/hiroaki/Develop/Project/OSS/ValueObjectGenerator/Generator/Sources/ValueObjectTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Name));
            
            #line default
            #line hidden
            this.Write(" b )\n        {\n            return !( a == b );\n        }\n\n        //----------------------------------------------------------------------\n        // ");
            
            #line 118 "/Users/hiroaki/Develop/Project/OSS/ValueObjectGenerator/Generator/Sources/ValueObjectTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(ValueOption.HasFlag( ValueOption.Implicit ) ? "Implicit" : "Explicit"));
            
            #line default
            #line hidden
            this.Write("\n        //----------------------------------------------------------------------\n        public static ");
            
            #line 120 "/Users/hiroaki/Develop/Project/OSS/ValueObjectGenerator/Generator/Sources/ValueObjectTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(ValueOption.HasFlag( ValueOption.Implicit ) ? "implicit" : "explicit"));
            
            #line default
            #line hidden
            this.Write(" operator ");
            
            #line 120 "/Users/hiroaki/Develop/Project/OSS/ValueObjectGenerator/Generator/Sources/ValueObjectTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(BaseTypeName));
            
            #line default
            #line hidden
            this.Write("( ");
            
            #line 120 "/Users/hiroaki/Develop/Project/OSS/ValueObjectGenerator/Generator/Sources/ValueObjectTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Name));
            
            #line default
            #line hidden
            this.Write(" x )\n        {\n            return x.");
            
            #line 122 "/Users/hiroaki/Develop/Project/OSS/ValueObjectGenerator/Generator/Sources/ValueObjectTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(ValueName));
            
            #line default
            #line hidden
            this.Write(";\n        }\n\n        public static implicit operator ");
            
            #line 125 "/Users/hiroaki/Develop/Project/OSS/ValueObjectGenerator/Generator/Sources/ValueObjectTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Name));
            
            #line default
            #line hidden
            this.Write("( ");
            
            #line 125 "/Users/hiroaki/Develop/Project/OSS/ValueObjectGenerator/Generator/Sources/ValueObjectTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(BaseTypeName));
            
            #line default
            #line hidden
            this.Write(" value )\n        {\n            return new ");
            
            #line 127 "/Users/hiroaki/Develop/Project/OSS/ValueObjectGenerator/Generator/Sources/ValueObjectTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Name));
            
            #line default
            #line hidden
            this.Write("( value );\n        }\n\n");
            
            #line 130 "/Users/hiroaki/Develop/Project/OSS/ValueObjectGenerator/Generator/Sources/ValueObjectTemplate.tt"
 if( ValueOption.HasFlag( ValueOption.Comparable ) ) { 
            
            #line default
            #line hidden
            this.Write("        //----------------------------------------------------------------------\n        // Comparable\n        //----------------------------------------------------------------------\n        public int CompareTo( ");
            
            #line 134 "/Users/hiroaki/Develop/Project/OSS/ValueObjectGenerator/Generator/Sources/ValueObjectTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Name));
            
            #line default
            #line hidden
            this.Write(" other )\n        {\n            if( ReferenceEquals( this, other ) )\n            {\n                return 0;\n            }\n\n            if( ReferenceEquals( null, other ) )\n            {\n                return 1;\n            }\n\n            return ");
            
            #line 146 "/Users/hiroaki/Develop/Project/OSS/ValueObjectGenerator/Generator/Sources/ValueObjectTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(ValueName));
            
            #line default
            #line hidden
            this.Write(".CompareTo( other.");
            
            #line 146 "/Users/hiroaki/Develop/Project/OSS/ValueObjectGenerator/Generator/Sources/ValueObjectTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(ValueName));
            
            #line default
            #line hidden
            this.Write(" );\n        }\n");
            
            #line 148 "/Users/hiroaki/Develop/Project/OSS/ValueObjectGenerator/Generator/Sources/ValueObjectTemplate.tt"
 } 
            
            #line default
            #line hidden
            this.Write("\n    }\n\n");
            
            #line 152 "/Users/hiroaki/Develop/Project/OSS/ValueObjectGenerator/Generator/Sources/ValueObjectTemplate.tt"
 if( !string.IsNullOrEmpty( Namespace ) ) { 
            
            #line default
            #line hidden
            this.Write("}\n");
            
            #line 154 "/Users/hiroaki/Develop/Project/OSS/ValueObjectGenerator/Generator/Sources/ValueObjectTemplate.tt"
 } 
            
            #line default
            #line hidden
            return this.GenerationEnvironment.ToString();
        }
    }
    
    #line default
    #line hidden
    #region Base class
    /// <summary>
    /// Base class for this transformation
    /// </summary>
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.TextTemplating", "16.0.0.0")]
    internal class ValueObjectTemplateBase
    {
        #region Fields
        private global::System.Text.StringBuilder generationEnvironmentField;
        private global::System.CodeDom.Compiler.CompilerErrorCollection errorsField;
        private global::System.Collections.Generic.List<int> indentLengthsField;
        private string currentIndentField = "";
        private bool endsWithNewline;
        private global::System.Collections.Generic.IDictionary<string, object> sessionField;
        #endregion
        #region Properties
        /// <summary>
        /// The string builder that generation-time code is using to assemble generated output
        /// </summary>
        protected System.Text.StringBuilder GenerationEnvironment
        {
            get
            {
                if ((this.generationEnvironmentField == null))
                {
                    this.generationEnvironmentField = new global::System.Text.StringBuilder();
                }
                return this.generationEnvironmentField;
            }
            set
            {
                this.generationEnvironmentField = value;
            }
        }
        /// <summary>
        /// The error collection for the generation process
        /// </summary>
        public System.CodeDom.Compiler.CompilerErrorCollection Errors
        {
            get
            {
                if ((this.errorsField == null))
                {
                    this.errorsField = new global::System.CodeDom.Compiler.CompilerErrorCollection();
                }
                return this.errorsField;
            }
        }
        /// <summary>
        /// A list of the lengths of each indent that was added with PushIndent
        /// </summary>
        private System.Collections.Generic.List<int> indentLengths
        {
            get
            {
                if ((this.indentLengthsField == null))
                {
                    this.indentLengthsField = new global::System.Collections.Generic.List<int>();
                }
                return this.indentLengthsField;
            }
        }
        /// <summary>
        /// Gets the current indent we use when adding lines to the output
        /// </summary>
        public string CurrentIndent
        {
            get
            {
                return this.currentIndentField;
            }
        }
        /// <summary>
        /// Current transformation session
        /// </summary>
        public virtual global::System.Collections.Generic.IDictionary<string, object> Session
        {
            get
            {
                return this.sessionField;
            }
            set
            {
                this.sessionField = value;
            }
        }
        #endregion
        #region Transform-time helpers
        /// <summary>
        /// Write text directly into the generated output
        /// </summary>
        public void Write(string textToAppend)
        {
            if (string.IsNullOrEmpty(textToAppend))
            {
                return;
            }
            // If we're starting off, or if the previous text ended with a newline,
            // we have to append the current indent first.
            if (((this.GenerationEnvironment.Length == 0) 
                        || this.endsWithNewline))
            {
                this.GenerationEnvironment.Append(this.currentIndentField);
                this.endsWithNewline = false;
            }
            // Check if the current text ends with a newline
            if (textToAppend.EndsWith(global::System.Environment.NewLine, global::System.StringComparison.CurrentCulture))
            {
                this.endsWithNewline = true;
            }
            // This is an optimization. If the current indent is "", then we don't have to do any
            // of the more complex stuff further down.
            if ((this.currentIndentField.Length == 0))
            {
                this.GenerationEnvironment.Append(textToAppend);
                return;
            }
            // Everywhere there is a newline in the text, add an indent after it
            textToAppend = textToAppend.Replace(global::System.Environment.NewLine, (global::System.Environment.NewLine + this.currentIndentField));
            // If the text ends with a newline, then we should strip off the indent added at the very end
            // because the appropriate indent will be added when the next time Write() is called
            if (this.endsWithNewline)
            {
                this.GenerationEnvironment.Append(textToAppend, 0, (textToAppend.Length - this.currentIndentField.Length));
            }
            else
            {
                this.GenerationEnvironment.Append(textToAppend);
            }
        }
        /// <summary>
        /// Write text directly into the generated output
        /// </summary>
        public void WriteLine(string textToAppend)
        {
            this.Write(textToAppend);
            this.GenerationEnvironment.AppendLine();
            this.endsWithNewline = true;
        }
        /// <summary>
        /// Write formatted text directly into the generated output
        /// </summary>
        public void Write(string format, params object[] args)
        {
            this.Write(string.Format(global::System.Globalization.CultureInfo.CurrentCulture, format, args));
        }
        /// <summary>
        /// Write formatted text directly into the generated output
        /// </summary>
        public void WriteLine(string format, params object[] args)
        {
            this.WriteLine(string.Format(global::System.Globalization.CultureInfo.CurrentCulture, format, args));
        }
        /// <summary>
        /// Raise an error
        /// </summary>
        public void Error(string message)
        {
            System.CodeDom.Compiler.CompilerError error = new global::System.CodeDom.Compiler.CompilerError();
            error.ErrorText = message;
            this.Errors.Add(error);
        }
        /// <summary>
        /// Raise a warning
        /// </summary>
        public void Warning(string message)
        {
            System.CodeDom.Compiler.CompilerError error = new global::System.CodeDom.Compiler.CompilerError();
            error.ErrorText = message;
            error.IsWarning = true;
            this.Errors.Add(error);
        }
        /// <summary>
        /// Increase the indent
        /// </summary>
        public void PushIndent(string indent)
        {
            if ((indent == null))
            {
                throw new global::System.ArgumentNullException("indent");
            }
            this.currentIndentField = (this.currentIndentField + indent);
            this.indentLengths.Add(indent.Length);
        }
        /// <summary>
        /// Remove the last indent that was added with PushIndent
        /// </summary>
        public string PopIndent()
        {
            string returnValue = "";
            if ((this.indentLengths.Count > 0))
            {
                int indentLength = this.indentLengths[(this.indentLengths.Count - 1)];
                this.indentLengths.RemoveAt((this.indentLengths.Count - 1));
                if ((indentLength > 0))
                {
                    returnValue = this.currentIndentField.Substring((this.currentIndentField.Length - indentLength));
                    this.currentIndentField = this.currentIndentField.Remove((this.currentIndentField.Length - indentLength));
                }
            }
            return returnValue;
        }
        /// <summary>
        /// Remove any indentation
        /// </summary>
        public void ClearIndent()
        {
            this.indentLengths.Clear();
            this.currentIndentField = "";
        }
        #endregion
        #region ToString Helpers
        /// <summary>
        /// Utility class to produce culture-oriented representation of an object as a string.
        /// </summary>
        public class ToStringInstanceHelper
        {
            private System.IFormatProvider formatProviderField  = global::System.Globalization.CultureInfo.InvariantCulture;
            /// <summary>
            /// Gets or sets format provider to be used by ToStringWithCulture method.
            /// </summary>
            public System.IFormatProvider FormatProvider
            {
                get
                {
                    return this.formatProviderField ;
                }
                set
                {
                    if ((value != null))
                    {
                        this.formatProviderField  = value;
                    }
                }
            }
            /// <summary>
            /// This is called from the compile/run appdomain to convert objects within an expression block to a string
            /// </summary>
            public string ToStringWithCulture(object objectToConvert)
            {
                if ((objectToConvert == null))
                {
                    throw new global::System.ArgumentNullException("objectToConvert");
                }
                System.Type t = objectToConvert.GetType();
                System.Reflection.MethodInfo method = t.GetMethod("ToString", new System.Type[] {
                            typeof(System.IFormatProvider)});
                if ((method == null))
                {
                    return objectToConvert.ToString();
                }
                else
                {
                    return ((string)(method.Invoke(objectToConvert, new object[] {
                                this.formatProviderField })));
                }
            }
        }
        private ToStringInstanceHelper toStringHelperField = new ToStringInstanceHelper();
        /// <summary>
        /// Helper to produce culture-oriented representation of an object as a string
        /// </summary>
        public ToStringInstanceHelper ToStringHelper
        {
            get
            {
                return this.toStringHelperField;
            }
        }
        #endregion
    }
    #endregion
}
