using BB.Common.WinForms;
using CefSharp;
using CefSharp.WinForms;
using RazorEngine;
using RazorEngine.Configuration;
using RazorEngine.Templating;
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
    public partial class App : MetroForm
    {
        WebView Browser;
        AppyServer Server;

        public App(string url = "http://localhost/test")
        {
            InitializeComponent();

            LoadServer();

            LoadBrowser(url);

            LoadRazorEngine(); 
      
            LoadTheme();
        }

        void LoadServer()
        {
            Server = new AppyServer();
            Server.Start();
            Disposed += (a, e) => Server.Dispose();
        }

        void LoadBrowser(string url)
        {
            Browser = new WebView(url, new BrowserSettings());
            Browser.Dock = DockStyle.Fill;
            BrowserContainer.Controls.Add(Browser);
        }

        void LoadRazorEngine()
        {
            var razorConfig = new TemplateServiceConfiguration { Resolver = new TemplateResolver() };
            Razor.SetTemplateService(new TemplateService(razorConfig));
        }

        void LoadTheme()
        {
            ThemeManager.ApplyTheme(new AppTheme());
        }
    }
}
