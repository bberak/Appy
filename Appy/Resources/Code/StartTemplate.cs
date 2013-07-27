﻿// ------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version: 11.0.0.0
//  
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
// ------------------------------------------------------------------------------
namespace Appy
{
    using System.Linq;
    using System.Text;
    using System.Collections.Generic;
    using System;
    
    /// <summary>
    /// Class to produce the template output
    /// </summary>
    
    #line 1 "C:\Dev\GitHub\Appy\Appy\Resources\Code\StartTemplate.tt"
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.TextTemplating", "11.0.0.0")]
    public partial class StartTemplate : StartTemplateBase
    {
#line hidden
        /// <summary>
        /// Create the template output
        /// </summary>
        public virtual string TransformText()
        {
            this.Write(@"using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using BB.Common.WinForms;
using Appy.Core;

// General Information about an assembly is controlled through the following 
// set of attributes. Change these attribute values to modify the information
// associated with an assembly.
[assembly: AssemblyTitle(""");
            
            #line 20 "C:\Dev\GitHub\Appy\Appy\Resources\Code\StartTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(this.AppNamespace));
            
            #line default
            #line hidden
            this.Write("\")]\r\n[assembly: AssemblyDescription(\"\")]\r\n[assembly: AssemblyConfiguration(\"\")]\r\n" +
                    "[assembly: AssemblyCompany(\"\")]\r\n[assembly: AssemblyProduct(\"");
            
            #line 24 "C:\Dev\GitHub\Appy\Appy\Resources\Code\StartTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(this.AppNamespace));
            
            #line default
            #line hidden
            this.Write("\")]\r\n[assembly: AssemblyCopyright(\"Copyright ©  ");
            
            #line 25 "C:\Dev\GitHub\Appy\Appy\Resources\Code\StartTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(DateTime.Now.Year));
            
            #line default
            #line hidden
            this.Write(@""")]
[assembly: AssemblyTrademark("""")]
[assembly: AssemblyCulture("""")]

// Setting ComVisible to false makes the types in this assembly not visible 
// to COM components.  If you need to access a type in this assembly from 
// COM, set the ComVisible attribute to true on that type.
[assembly: ComVisible(false)]

// The following GUID is for the ID of the typelib if this project is exposed to COM
[assembly: Guid(""");
            
            #line 35 "C:\Dev\GitHub\Appy\Appy\Resources\Code\StartTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Guid.NewGuid().ToString()));
            
            #line default
            #line hidden
            this.Write(@""")]

// Version information for an assembly consists of the following four values:
//
//      Major Version
//      Minor Version 
//      Build Number
//      Revision
//
// You can specify all the values or you can default the Build and Revision Numbers 
// by using the '*' as shown below:
// [assembly: AssemblyVersion(""1.0.*"")]
[assembly: AssemblyVersion(""1.0.0.0"")]
[assembly: AssemblyFileVersion(""1.0.0.0"")]

namespace ");
            
            #line 50 "C:\Dev\GitHub\Appy\Appy\Resources\Code\StartTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(this.AppNamespace));
            
            #line default
            #line hidden
            this.Write(@"
{
    static class Start
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //-- TODO:
            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            Control.CheckForIllegalCrossThreadCalls = false;

			App app = new App(""http://localhost:");
            
            #line 65 "C:\Dev\GitHub\Appy\Appy\Resources\Code\StartTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(this.GetRandomPort()));
            
            #line default
            #line hidden
            this.Write("/index\");\r\n\t\t\tapp.Text = \"");
            
            #line 66 "C:\Dev\GitHub\Appy\Appy\Resources\Code\StartTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(this.AppName));
            
            #line default
            #line hidden
            this.Write("\";\r\n            ThemeManager.ApplyTheme(GetMyTheme());\r\n            Application.R" +
                    "un(app);\r\n        }\r\n\r\n\t\tstatic BaseTheme GetMyTheme()\r\n        {\r\n            v" +
                    "ar myTheme = new AppyTheme();\r\n\r\n            //-- Uncomment lines below to see t" +
                    "he effects!\r\n            //myTheme.Units[\"PanelBorderWidth\"] = 0;\r\n            /" +
                    "/myTheme.Colors[\"PanelBorder\"] = Color.DarkGray;\r\n            //myTheme.Colors[\"" +
                    "FormBorder\"] = Color.DarkGray;\r\n            //myTheme.Colors[\"FormBackground\"] =" +
                    " Color.Pink;\r\n            //myTheme.Colors[\"ButtonMouseOverForeground\"] = Color." +
                    "White;\r\n            //myTheme.Colors[\"ButtonMouseOverBorder\"] = Color.DeepPink;\r" +
                    "\n            //myTheme.Colors[\"ButtonMouseOverBackground\"] = Color.DeepPink;\r\n  " +
                    "          //myTheme.Colors[\"ButtonMouseDownBackground\"] = Color.DeepPink;\r\n     " +
                    "       //myTheme.Colors[\"ButtonForeground\"] = Color.DarkGray;\r\n            //myT" +
                    "heme.Units[\"ButtonBorderSize\"] = 2;\r\n            //myTheme.Colors[\"ButtonBorder\"" +
                    "] = Color.White;\r\n            //myTheme.Colors[\"ButtonBackground\"] = Color.White" +
                    ";\r\n            //myTheme.Colors[\"ResizeButtonMouseOverForeground\"] = Color.DeepP" +
                    "ink;\r\n            //myTheme.Colors[\"ResizeButtonMouseOverBorder\"] = Color.DeepPi" +
                    "nk;\r\n            //myTheme.Colors[\"ResizeButtonMouseOverBackground\"] = Color.Dee" +
                    "pPink;\r\n            //myTheme.Colors[\"ResizeButtonMouseDownBackground\"] = Color." +
                    "DeepPink;\r\n            //myTheme.Colors[\"ResizeButtonForeground\"] = Color.DarkGr" +
                    "ay;\r\n            //myTheme.Units[\"ResizeButtonBorderSize\"] = 2;\r\n            //m" +
                    "yTheme.Colors[\"ResizeButtonBorder\"] = Color.Lavender;\r\n            //myTheme.Col" +
                    "ors[\"ResizeButtonBackground\"] = Color.Lavender;\r\n            //myTheme.Colors[\"T" +
                    "oolTipBackground\"] = Color.White;\r\n            //myTheme.Colors[\"ToolTipForegrou" +
                    "nd\"] = Color.Black;\r\n            //myTheme.Units[\"FormBorderWidth\"] = 2;\r\n\r\n    " +
                    "        return myTheme;\r\n        }\r\n    }\r\n}\r\n");
            return this.GenerationEnvironment.ToString();
        }
        
        #line 104 "C:\Dev\GitHub\Appy\Appy\Resources\Code\StartTemplate.tt"

	public string AppName {get; set; }

	public string AppNamespace {get; set; }

	public int GetRandomPort()
	{
		Random rng = new Random(Environment.TickCount);

		return rng.Next(49152, 65535);
	}

        
        #line default
        #line hidden
    }
    
    #line default
    #line hidden
    #region Base class
    /// <summary>
    /// Base class for this transformation
    /// </summary>
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.TextTemplating", "11.0.0.0")]
    public class StartTemplateBase
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
