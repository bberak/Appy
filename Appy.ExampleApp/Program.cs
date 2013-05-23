﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Appy.Core;

namespace Appy.ExampleApp
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //-- TODO:
            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            Control.CheckForIllegalCrossThreadCalls = false;

            Application.Run(new App());
        }
    }
}
