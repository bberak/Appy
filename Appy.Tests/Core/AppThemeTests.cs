using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Drawing;

namespace Appy.Tests
{
    [TestClass]
    public class AppThemeTests
    {
        AppTheme Theme;

        public AppThemeTests()
        {
            Theme = new AppTheme();
        }

        [TestMethod]
        public void Verify_Colors_Loaded()
        {
            Color smokeyWhite = Color.FromArgb(255, 236, 239, 241);
            Color electricBlue = Color.FromArgb(255, 0, 148, 255);

            Assert.AreEqual<Color>(smokeyWhite, Theme.Colors["FormBackground"]);
            Assert.AreEqual<Color>(electricBlue, Theme.Colors["ButtonMouseOverBackground"]);
        }

        [TestMethod]
        public void Verify_Units_Loaded()
        {
            Assert.AreEqual<int>(0, Theme.Units["PanelBorderWidth"]);
            Assert.AreEqual<int>(2, Theme.Units["ButtonBorderSize"]);
            Assert.AreEqual<int>(2, Theme.Units["ResizeButtonBorderSize"]);
        }
    }
}
