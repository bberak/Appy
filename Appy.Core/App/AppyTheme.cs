using BB.Common.WinForms;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace Appy.Core
{
    public class AppyTheme : JaffasTheme
    {
        public override string Name
        {
            get
            {
                return "AppyTheme";
            }
        }

        protected override void LoadProperties()
        {
            base.LoadProperties();

            Color electricBlue = Color.FromArgb(255, 0, 148, 255);
            Color lightGray = Color.FromArgb(255, 212, 212, 212);

            Units["PanelBorderWidth"] = 0;
            Colors["PanelBorder"] = Color.DarkGray;
            Colors["FormBorder"] = Color.DarkGray;
            Colors["FormBackground"] = Color.White;
            Colors["ButtonMouseOverForeground"] = Color.White;
            Colors["ButtonMouseOverBorder"] = electricBlue;
            Colors["ButtonMouseOverBackground"] = electricBlue;
            Colors["ButtonMouseDownBackground"] = electricBlue;
            Colors["ButtonForeground"] = Color.DarkGray;
            Units["ButtonBorderSize"] = 2;
            Colors["ButtonBorder"] = Color.White;
            Colors["ButtonBackground"] = Color.White;
            Colors["ResizeButtonMouseOverForeground"] = electricBlue;
            Colors["ResizeButtonMouseOverBorder"] = electricBlue;
            Colors["ResizeButtonMouseOverBackground"] = electricBlue;
            Colors["ResizeButtonMouseDownBackground"] = electricBlue;
            Colors["ResizeButtonForeground"] = Color.DarkGray;
            Units["ResizeButtonBorderSize"] = 2;
            Colors["ResizeButtonBorder"] = lightGray;
            Colors["ResizeButtonBackground"] = lightGray;
            Colors["ToolTipBackground"] = Color.White;
            Colors["ToolTipForeground"] = Color.Black;
            Units["FormBorderWidth"] = 1;
        }
    }
}
