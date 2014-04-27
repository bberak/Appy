using Appy.Core.Framework;
using Appy.Core.Themes;
using BB.Common.WinForms;
using CefSharp;
using CefSharp.WinForms;
using Nancy.Hosting.Self;
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
        NancyHost Server;

        public App(string url)
        {
            InitializeComponent();

            LoadServer(url);

            LoadBrowser(url);
      
            LoadTheme();

            LoadIcon();
        }

        void LoadServer(string url)
        {
            var config = new HostConfiguration
            {
                UrlReservations = new UrlReservations { CreateAutomatically = true }
            };

            Server = new NancyHost(config, new Uri(url));
            Server.Start();
            Disposed += (a, e) => Server.Dispose();
        }

        void LoadBrowser(string url)
        {
            Browser = new WebView(url, new BrowserSettings());
            Browser.Dock = DockStyle.Fill;
            BrowserContainer.Controls.Add(Browser);
        }

        void LoadTheme()
        {
            ThemeManager.ApplyTheme(new AppyTheme());
        }

        void LoadIcon()
        {
            string iconFile = "App.ico";

            if (Files.Exists(iconFile))
                Icon = new Icon(iconFile);
        }
    }
}
