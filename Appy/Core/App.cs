using CefSharp;
using CefSharp.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Appy
{
    public partial class App : Form
    {
        WebView Browser;

        public App(string url = "https://github.com/bberak/")
        {
            InitializeComponent();
            Browser = new WebView(url, new BrowserSettings());
            Browser.Dock = DockStyle.Fill;
            Controls.Add(Browser);
        }
    }
}
