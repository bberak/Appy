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
            Content = Files.ReadView(viewName);

            RunRazprTemplate(model);
        }

        void RunRazprTemplate(object model)
        {
            Content = Razor.Parse(Content, model);
        }
    }
}
