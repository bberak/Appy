﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Drawing;

namespace Appy.Core.Tests
{
    [TestClass]
    public class AppThemeTests
    {
        AppyTheme Theme;

        public AppThemeTests()
        {
            Theme = new AppyTheme();
        }

        [TestMethod]
        public void Verify_Colors_Loaded()
        {
            Color lightGray = Color.FromArgb(255, 212, 212, 212);
            Color electricBlue = Color.FromArgb(255, 0, 148, 255);

            Assert.AreEqual<Color>(Color.White, Theme.Colors["FormBackground"]);
            Assert.AreEqual<Color>(lightGray, Theme.Colors["ResizeButtonBackground"]);
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
