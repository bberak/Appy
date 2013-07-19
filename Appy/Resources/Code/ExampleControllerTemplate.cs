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
    
    #line 1 "C:\Dev\GitHub\Appy\Appy\Resources\Code\ExampleControllerTemplate.tt"
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.TextTemplating", "11.0.0.0")]
    public partial class ExampleControllerTemplate : ExampleControllerTemplateBase
    {
#line hidden
        /// <summary>
        /// Create the template output
        /// </summary>
        public virtual string TransformText()
        {
            this.Write("using System;\r\nusing System.Collections.Generic;\r\nusing System.Linq;\r\nusing Syste" +
                    "m.Net;\r\nusing System.Text;\r\nusing System.Windows.Forms;\r\nusing BB.Common.WinForm" +
                    "s;\r\nusing Appy.Core;\r\n\r\nnamespace ");
            
            #line 15 "C:\Dev\GitHub\Appy\Appy\Resources\Code\ExampleControllerTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(this.AppNamespace));
            
            #line default
            #line hidden
            this.Write("\r\n{\r\n    public class ExampleController : Controller\r\n    {\r\n        int Count;\r\n" +
                    "        Lazy<PerformanceCounter> CpuCounter;\r\n        Lazy<PerformanceCounter> M" +
                    "emoryCounter;\r\n\r\n        public ExampleController()\r\n        {\r\n            CpuC" +
                    "ounter = new Lazy<PerformanceCounter>(() =>\r\n            {\r\n                retu" +
                    "rn new PerformanceCounter(\"Processor\", \"% Processor Time\", \"_Total\");\r\n         " +
                    "   });\r\n\r\n            MemoryCounter = new Lazy<PerformanceCounter>(() =>\r\n      " +
                    "      {\r\n                return new PerformanceCounter(\"Memory\", \"% Committed By" +
                    "tes in Use\");\r\n            });\r\n        }\r\n\r\n\t\t[Url(\"/index\")]\r\n        [Url(\"/f" +
                    "lat-ui\")]\r\n        public Response FlatUI(Request incoming)\r\n        {\r\n        " +
                    "    var name = incoming.Form.Find(\"Name\");\r\n            var email = incoming.For" +
                    "m.Find(\"Email\");\r\n\r\n            var cookie = new Cookie(\"Name\", \"Value\").Expires" +
                    "In(30);\r\n\r\n            return new ViewResponse(\"flat-ui.html\", Count);\r\n        " +
                    "}\r\n\r\n        [Url(\"/launcher\")]\r\n        public Response Launcher(Request incomi" +
                    "ng)\r\n        {\r\n            return View(\"launcher.html\") + Cookie(\"testCookie\", " +
                    "\"abc\") + Header(\"testHeader\", \"123\");\r\n        }\r\n\r\n        [Url(\"/launcher/run\"" +
                    ")]\r\n        public Response Run(Request incoming)\r\n        {\r\n            var ex" +
                    "e = string.IsNullOrEmpty(incoming.Form.Find(\"exe-input\"))\r\n                ? inc" +
                    "oming.Form.Find(\"exe-select\")\r\n                : incoming.Form.Find(\"exe-input\")" +
                    ";\r\n\r\n            Process.Start(exe);\r\n\r\n            return new RedirectResponse(" +
                    "\"/launcher\");\r\n        }\r\n\r\n        [Url(\"/testing\")]\r\n        public Response T" +
                    "esting(Request incoming)\r\n        {\r\n            Count++;\r\n\r\n            return " +
                    "new ViewResponse(\"testing.html\", Count);\r\n        }\r\n\r\n        [Url(\"/change-the" +
                    "me\")]\r\n        public Response ChangeTheme(Request incoming)\r\n        {\r\n       " +
                    "     string themeName = incoming.QueryString.Find(\"theme\");\r\n\r\n            if (t" +
                    "hemeName.Equals(\"JaffasTheme\"))\r\n                ThemeManager.ApplyTheme(new Jaf" +
                    "fasTheme());\r\n            else\r\n                ThemeManager.ApplyTheme(new Appy" +
                    "Theme());\r\n \r\n            return Redirect(\"/testing\");\r\n        }\r\n\r\n        [Ur" +
                    "l(\"/sysmon\")]\r\n        public Response SystemMonitor(Request incoming)\r\n        " +
                    "{\r\n            return View(\"system_monitor.html\");\r\n        }\r\n\r\n        [Url(\"/" +
                    "sysmon/check\")]\r\n        public Response SystemMonitorCheck(Request incoming)\r\n " +
                    "       {\r\n            var model = new\r\n            {\r\n                cpuLoad = " +
                    "(int)CpuCounter.Value.NextValue(),\r\n                memoryLoad = (int)MemoryCoun" +
                    "ter.Value.NextValue()\r\n            };\r\n\r\n            return Json(model);\r\n      " +
                    "  }\r\n    }\r\n}\r\n");
            return this.GenerationEnvironment.ToString();
        }
        
        #line 106 "C:\Dev\GitHub\Appy\Appy\Resources\Code\ExampleControllerTemplate.tt"

	public string AppNamespace {get; set; }

        
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
    public class ExampleControllerTemplateBase
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
