using BB.Common.WinForms;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace Appy
{
    public class AppTheme : JaffasTheme
    {
        public override string Name
        {
            get
            {
                return "AppTheme";
            }
        }

        protected override void LoadProperties()
        {
            base.LoadProperties();

            Color smokeyWhite = Color.FromArgb(255, 236, 239, 241);
            Color electricBlue = Color.FromArgb(255, 0, 148, 255);

            Units["PanelBorderWidth"] = 0;
            Colors["PanelBorder"] = Color.DarkGray;
            Colors["FormBorder"] = Color.DarkGray;
            Colors["FormBackground"] = smokeyWhite;
            Colors["ButtonMouseOverForeground"] = smokeyWhite;
            Colors["ButtonMouseOverBorder"] = electricBlue;
            Colors["ButtonMouseOverBackground"] = electricBlue;
            Colors["ButtonMouseDownBackground"] = electricBlue;
            Colors["ButtonForeground"] = Color.DarkGray;
            Units["ButtonBorderSize"] = 2;
            Colors["ButtonBorder"] = smokeyWhite;
            Colors["ButtonBackground"] = smokeyWhite;
            Colors["ResizeButtonMouseOverForeground"] = electricBlue;
            Colors["ResizeButtonMouseOverBorder"] = electricBlue;
            Colors["ResizeButtonMouseOverBackground"] = electricBlue;
            Colors["ResizeButtonMouseDownBackground"] = electricBlue;
            Colors["ResizeButtonForeground"] = Color.DarkGray;
            Units["ResizeButtonBorderSize"] = 2;
            Colors["ResizeButtonBorder"] = Color.DarkGray;
            Colors["ResizeButtonBackground"] = Color.DarkGray;
            Colors["ToolTipBackground"] = Color.White;
            Colors["ToolTipForeground"] = Color.Black;
            Units["FormBorderWidth"] = 1;
        }
    }
}
