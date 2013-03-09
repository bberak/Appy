using CefSharp;
using CefSharp.WinForms;
using SelfServe;
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
        AppyServer Server;

        public App(string url = "http://localhost/index")
        {
            InitializeComponent();

            Server = new AppyServer();
            Server.Start();
            Disposed += (a, e) => Server.Dispose();

            Browser = new WebView(url, new BrowserSettings());
            Browser.Dock = DockStyle.Fill;
            Controls.Add(Browser);
        }
    }
}
