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
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.TextTemplating", "16.0.0.0")]
    internal partial class ValueObjectTemplate : ValueObjectTemplateBase
    {
#line hidden
        /// <summary>
        /// Create the template output
        /// </summary>
        public virtual string TransformText()
        {
            this.Write("//\n// Generated by ValueObjectGenerator\n// DO NOT EDIT THIS FILE\n//\nusing System;\nusing System.Diagnostics.CodeAnalysis;\n\n");

    ValueName = ValueName.Replace( "\"", "" );
    var declarationType = "class";
    if( IsStruct )
    {
        declarationType = "struct";
    }

    var requireMinMax = !string.IsNullOrEmpty( Min ) && !string.IsNullOrEmpty( Max );
    var requireValidateMethod = !requireMinMax && !ValueOption.HasFlag( ValueOption.NonValidating );



            #line default
            #line hidden
 if( !string.IsNullOrEmpty( Namespace ) ) {

            #line default
            #line hidden
            this.Write("namespace ");
            this.Write(this.ToStringHelper.ToStringWithCulture(Namespace));

            #line default
            #line hidden
            this.Write("\n{\n");
 }

            #line default
            #line hidden
            this.Write("    public partial ");
            this.Write(this.ToStringHelper.ToStringWithCulture(declarationType));

            #line default
            #line hidden
            this.Write(" ");
            this.Write(this.ToStringHelper.ToStringWithCulture(Name));

            #line default
            #line hidden
            this.Write(" : IEquatable<");
            this.Write(this.ToStringHelper.ToStringWithCulture(Name));

            #line default
            #line hidden
            this.Write(">");
            this.Write(this.ToStringHelper.ToStringWithCulture(ValueOption.HasFlag( ValueOption.Comparable ) ? $", IComparable<{Name}>" : ""));

            #line default
            #line hidden
            this.Write("\n    {\n        public ");
            this.Write(this.ToStringHelper.ToStringWithCulture(BaseTypeName));

            #line default
            #line hidden
            this.Write(" ");
            this.Write(this.ToStringHelper.ToStringWithCulture(ValueName));

            #line default
            #line hidden
            this.Write(" { get; }\n\n        public ");
            this.Write(this.ToStringHelper.ToStringWithCulture(Name));

            #line default
            #line hidden
            this.Write("( ");
            this.Write(this.ToStringHelper.ToStringWithCulture(BaseTypeName));

            #line default
            #line hidden
            this.Write(" value )\n        {\n");
 /* Min, Max */

            #line default
            #line hidden
 if( requireMinMax ) {

            #line default
            #line hidden
            this.Write("            if( value < (");
            this.Write(this.ToStringHelper.ToStringWithCulture(Min));

            #line default
            #line hidden
            this.Write(") || value > (");
            this.Write(this.ToStringHelper.ToStringWithCulture(Max));

            #line default
            #line hidden
            this.Write(") )\n            {\n                throw new ArgumentOutOfRangeException( $\"");
            this.Write(this.ToStringHelper.ToStringWithCulture(Name));

            #line default
            #line hidden
            this.Write(" : {value} (range:");
            this.Write(this.ToStringHelper.ToStringWithCulture(Min));

            #line default
            #line hidden
            this.Write(" < ");
            this.Write(this.ToStringHelper.ToStringWithCulture(Max));

            #line default
            #line hidden
            this.Write(")\" );\n            }\n            ");
            this.Write(this.ToStringHelper.ToStringWithCulture(ValueName));

            #line default
            #line hidden
            this.Write(" = value;\n");
 /* No Validation */

            #line default
            #line hidden
 } else if( !requireValidateMethod ) {

            #line default
            #line hidden
            this.Write("            ");
            this.Write(this.ToStringHelper.ToStringWithCulture(ValueName));

            #line default
            #line hidden
            this.Write(" = value;\n");
 } else {

            #line default
            #line hidden
            this.Write("            ");
            this.Write(this.ToStringHelper.ToStringWithCulture(ValueName));

            #line default
            #line hidden
            this.Write(" = Validate( value );\n");
 }

            #line default
            #line hidden
            this.Write("        }\n\n");
 /* Validate method */

            #line default
            #line hidden
 if( requireValidateMethod ) {

            #line default
            #line hidden
            this.Write("        private static partial ");
            this.Write(this.ToStringHelper.ToStringWithCulture(BaseTypeName));

            #line default
            #line hidden
            this.Write(" Validate( ");
            this.Write(this.ToStringHelper.ToStringWithCulture(BaseTypeName));

            #line default
            #line hidden
            this.Write(" value );\n");
 }

            #line default
            #line hidden
            this.Write("\n");
 /* ToString */

            #line default
            #line hidden
 if( !ValueOption.HasFlag( ValueOption.ToString ) ) {

            #line default
            #line hidden
            this.Write("        //\n        // Default ToString()\n        //\n        public override string ToString()\n        {\n            return ");
            this.Write(this.ToStringHelper.ToStringWithCulture(ValueName));

            #line default
            #line hidden
            this.Write(".ToString();\n        }\n");
 } else {

            #line default
            #line hidden
            this.Write("        //\n        // Custom ToString()\n        //\n        private partial string ToStringImpl();\n\n        public override string ToString()\n        {\n            return ToStringImpl();\n        }\n");
 }

            #line default
            #line hidden
            this.Write("\n        //----------------------------------------------------------------------\n        // Equality\n        //----------------------------------------------------------------------\n        public bool Equals( ");
            this.Write(this.ToStringHelper.ToStringWithCulture(IsClass ? "[AllowNull] " : ""));

            #line default
            #line hidden
            this.Write(this.ToStringHelper.ToStringWithCulture(Name));

            #line default
            #line hidden
            this.Write(" other )\n        {\n");
 if( IsClass ) {

            #line default
            #line hidden
            this.Write("            if( ReferenceEquals( null, other ) )\n            {\n                return false;\n            }\n\n            if( ReferenceEquals( this, other ) )\n            {\n                return true;\n            }\n            return ");
            this.Write(this.ToStringHelper.ToStringWithCulture(ValueName));

            #line default
            #line hidden
            this.Write(" == other.");
            this.Write(this.ToStringHelper.ToStringWithCulture(ValueName));

            #line default
            #line hidden
            this.Write(";\n");
 } else if( IsStruct ) {

            #line default
            #line hidden
            this.Write("            return Equals( ");
            this.Write(this.ToStringHelper.ToStringWithCulture(ValueName));

            #line default
            #line hidden
            this.Write(", other.");
            this.Write(this.ToStringHelper.ToStringWithCulture(ValueName));

            #line default
            #line hidden
            this.Write(" );\n");
 }

            #line default
            #line hidden
            this.Write("        }\n\n        public override bool Equals( [AllowNull] object obj )\n        {\n");
 if( IsClass ) {

            #line default
            #line hidden
            this.Write("            if( ReferenceEquals( null, obj ) )\n            {\n                return false;\n            }\n\n            if( ReferenceEquals( this, obj ) )\n            {\n                return true;\n            }\n\n            if( obj.GetType() != this.GetType() )\n            {\n                return false;\n            }\n\n            return Equals( (");
            this.Write(this.ToStringHelper.ToStringWithCulture(Name));

            #line default
            #line hidden
            this.Write(")obj );\n");
 } else if( IsStruct ) {

            #line default
            #line hidden
            this.Write("            return obj is ");
            this.Write(this.ToStringHelper.ToStringWithCulture(Name));

            #line default
            #line hidden
            this.Write(" other && Equals( other );\n");
 }

            #line default
            #line hidden
            this.Write("        }\n\n        // HashCode\n        public override int GetHashCode() => ");
            this.Write(this.ToStringHelper.ToStringWithCulture(ValueName));

            #line default
            #line hidden
            this.Write(".GetHashCode();\n\n        // Operator ==, !=\n        public static bool operator ==( ");
            this.Write(this.ToStringHelper.ToStringWithCulture(Name));

            #line default
            #line hidden
            this.Write(" a, ");
            this.Write(this.ToStringHelper.ToStringWithCulture(Name));

            #line default
            #line hidden
            this.Write(" b )\n        {\n");
 if( IsClass ) {

            #line default
            #line hidden
            this.Write("            if( ReferenceEquals( a, b ) )\n            {\n                return true;\n            }\n\n            return a?.Equals( b ) ?? ReferenceEquals( null, b );\n");
 } else if( IsStruct ) {

            #line default
            #line hidden
            this.Write("            return a.Equals( b );\n");
 }

            #line default
            #line hidden
            this.Write("        }\n\n        public static bool operator !=( ");
            this.Write(this.ToStringHelper.ToStringWithCulture(Name));

            #line default
            #line hidden
            this.Write(" a, ");
            this.Write(this.ToStringHelper.ToStringWithCulture(Name));

            #line default
            #line hidden
            this.Write(" b )\n        {\n            return !( a == b );\n        }\n\n        //----------------------------------------------------------------------\n        // ");
            this.Write(this.ToStringHelper.ToStringWithCulture(ValueOption.HasFlag( ValueOption.Implicit ) ? "Implicit" : "Explicit"));

            #line default
            #line hidden
            this.Write("\n        //----------------------------------------------------------------------\n        public static ");
            this.Write(this.ToStringHelper.ToStringWithCulture(ValueOption.HasFlag( ValueOption.Implicit ) ? "implicit" : "explicit"));

            #line default
            #line hidden
            this.Write(" operator ");
            this.Write(this.ToStringHelper.ToStringWithCulture(BaseTypeName));

            #line default
            #line hidden
            this.Write("( ");
            this.Write(this.ToStringHelper.ToStringWithCulture(Name));

            #line default
            #line hidden
            this.Write(" x )\n        {\n            return x.");
            this.Write(this.ToStringHelper.ToStringWithCulture(ValueName));

            #line default
            #line hidden
            this.Write(";\n        }\n\n        public static implicit operator ");
            this.Write(this.ToStringHelper.ToStringWithCulture(Name));

            #line default
            #line hidden
            this.Write("( ");
            this.Write(this.ToStringHelper.ToStringWithCulture(BaseTypeName));

            #line default
            #line hidden
            this.Write(" value )\n        {\n            return new ");
            this.Write(this.ToStringHelper.ToStringWithCulture(Name));

            #line default
            #line hidden
            this.Write("( value );\n        }\n\n");
 if( ValueOption.HasFlag( ValueOption.Comparable ) ) {

            #line default
            #line hidden
            this.Write("        //----------------------------------------------------------------------\n        // Comparable\n        //----------------------------------------------------------------------\n        public int CompareTo( ");
            this.Write(this.ToStringHelper.ToStringWithCulture(Name));

            #line default
            #line hidden
            this.Write(" other )\n        {\n            if( ReferenceEquals( this, other ) )\n            {\n                return 0;\n            }\n\n            if( ReferenceEquals( null, other ) )\n            {\n                return 1;\n            }\n\n            return ");
            this.Write(this.ToStringHelper.ToStringWithCulture(ValueName));

            #line default
            #line hidden
            this.Write(".CompareTo( other.");
            this.Write(this.ToStringHelper.ToStringWithCulture(ValueName));

            #line default
            #line hidden
            this.Write(" );\n        }\n");
 }

            #line default
            #line hidden
            this.Write("\n    }\n\n");
 if( !string.IsNullOrEmpty( Namespace ) ) {

            #line default
            #line hidden
            this.Write("}\n");
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
