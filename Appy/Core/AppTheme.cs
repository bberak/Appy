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
        public Color ButtonBackColor
        {
            get { return Color.WhiteSmoke; }
        }

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

            Units["PanelBorderWidth"] = 0;
            Colors["PanelBorder"] = Color.DarkGray;
            Colors["FormBorder"] = Color.DarkGray;
            Colors["FormBackground"] = Color.FromArgb(255, 236, 239, 241);
            Colors["ButtonMouseOverForeground"] = Color.FromArgb(255, 236, 239, 241);
            Colors["ButtonMouseOverBorder"] = Color.FromArgb(255, 0, 148, 255);
            Colors["ButtonMouseOverBackground"] = Color.FromArgb(255, 0, 148, 255);
            Colors["ButtonMouseDownBackground"] = Color.FromArgb(255, 0, 148, 255);
            Colors["ButtonForeground"] = Color.DarkGray;
            Units["ButtonBorderSize"] = 2;
            Colors["ButtonBorder"] = Color.FromArgb(255, 236, 239, 241);
            Colors["ButtonBackground"] = Color.FromArgb(255, 236, 239, 241);
            Colors["ResizeButtonMouseOverForeground"] = Color.FromArgb(255, 0, 148, 255);
            Colors["ResizeButtonMouseOverBorder"] = Color.FromArgb(255, 0, 148, 255);
            Colors["ResizeButtonMouseOverBackground"] = Color.FromArgb(255, 0, 148, 255);
            Colors["ResizeButtonMouseDownBackground"] = Color.FromArgb(255, 0, 148, 255);
            Colors["ResizeButtonForeground"] = Color.DarkGray;
            Units["ResizeButtonBorderSize"] = 2;
            Colors["ResizeButtonBorder"] = Color.DarkGray;
            Colors["ResizeButtonBackground"] = Color.DarkGray;
        }
    }
}
