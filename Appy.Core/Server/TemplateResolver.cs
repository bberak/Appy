using RazorEngine.Templating;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Appy.Core
{
    public class TemplateResolver : ITemplateResolver
    {
        public string Resolve(string viewName)
        {
            return Files.ReadView(viewName);
        }
    }
}
