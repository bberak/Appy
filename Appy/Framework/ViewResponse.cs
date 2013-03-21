using RazorEngine;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Appy
{
    public class ViewResponse : BasicResponse
    {
        public ViewResponse(string viewName, object model = null)
        {
            Content = FindAndReadFile(viewName);

            RunRazprTemplate(model);
        }

        string FindAndReadFile(string viewName)
        {
            string pattern = @"Site\Views\" + viewName;

            string[] files = Directory.GetFiles(Environment.CurrentDirectory, pattern, SearchOption.AllDirectories);

            if (files != null && files.Length > 0)
                return File.ReadAllText(files[0]);

            throw new Exception("Could not find any files matching the pattern: " + pattern);
        }

        void RunRazprTemplate(object model)
        {
            Content = Razor.Parse(Content, model);
        }
    }
}
