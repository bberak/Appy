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

namespace Appy.Core
{
    public partial class App : MetroForm
    {
        WebView Browser;
        HttpServer Server;

        public App()
            :this(new AppyServer(), "http://localhost/index"){ }

        public App(HttpServer server, string url)
        {
            InitializeComponent();

            LoadServer(server);

            LoadBrowser(url);

            LoadRazorEngine(); 
      
            LoadTheme();
        }

        void LoadServer(HttpServer server)
        {
            Server = server;
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
            ThemeManager.ApplyTheme(new AppyTheme());
        }
    }
}
