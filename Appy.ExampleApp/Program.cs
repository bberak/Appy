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
            app.Text = "Example App";
            ThemeManager.ApplyTheme(GetMyTheme());
            Application.Run(app);
        }

        static BaseTheme GetMyTheme()
        {
            var myTheme = new AppyTheme();

            //-- Uncomment lines below to see the effects!
            //myTheme.Units["PanelBorderWidth"] = 0;
            //myTheme.Colors["PanelBorder"] = Color.DarkGray;
            //myTheme.Colors["FormBorder"] = Color.DarkGray;
            //myTheme.Colors["FormBackground"] = Color.Pink;
            //myTheme.Colors["ButtonMouseOverForeground"] = Color.White;
            //myTheme.Colors["ButtonMouseOverBorder"] = Color.DeepPink;
            //myTheme.Colors["ButtonMouseOverBackground"] = Color.DeepPink;
            //myTheme.Colors["ButtonMouseDownBackground"] = Color.DeepPink;
            //myTheme.Colors["ButtonForeground"] = Color.DarkGray;
            //myTheme.Units["ButtonBorderSize"] = 2;
            //myTheme.Colors["ButtonBorder"] = Color.White;
            //myTheme.Colors["ButtonBackground"] = Color.White;
            //myTheme.Colors["ResizeButtonMouseOverForeground"] = Color.DeepPink;
            //myTheme.Colors["ResizeButtonMouseOverBorder"] = Color.DeepPink;
            //myTheme.Colors["ResizeButtonMouseOverBackground"] = Color.DeepPink;
            //myTheme.Colors["ResizeButtonMouseDownBackground"] = Color.DeepPink;
            //myTheme.Colors["ResizeButtonForeground"] = Color.DarkGray;
            //myTheme.Units["ResizeButtonBorderSize"] = 2;
            //myTheme.Colors["ResizeButtonBorder"] = Color.Lavender;
            //myTheme.Colors["ResizeButtonBackground"] = Color.Lavender;
            //myTheme.Colors["ToolTipBackground"] = Color.White;
            //myTheme.Colors["ToolTipForeground"] = Color.Black;
            //myTheme.Units["FormBorderWidth"] = 2;

            return myTheme;
        }
    }
}
