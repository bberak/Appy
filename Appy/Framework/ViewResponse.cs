﻿using RazorEngine;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Appy
{
    public class ViewResponse : BasicResponse
    {
        public string ViewName { get; protected set; }

        public object Model { get; protected set; }

        public ViewResponse(string viewName, object model = null)
        {
            Content = Files.ReadView(viewName);

            ViewName = viewName;

            Model = model;

            RunRazprTemplate();
        }

        void RunRazprTemplate()
        {
            Content = Razor.Parse(Content, Model, ViewName);
        }
    }
}
