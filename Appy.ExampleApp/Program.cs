using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Appy.Core;
using BB.Common.WinForms;
using System.Drawing;

namespace Appy.ExampleApp
{
    static class Program
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

            App app = new App();
            ThemeManager.ApplyTheme(GetModifiedTheme());
            Application.Run(app);
        }

        static BaseTheme GetModifiedTheme()
        {
            var modifiedTheme = new AppyTheme();
            //-- Uncomment line below to see the effects!
            //modifiedTheme.Colors["ButtonMouseOverForeground"] = Color.Red;

            return modifiedTheme;
        }
    }
}
