using Nancy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appy.ExampleApp.Modules
{
    public class MainModule : NancyModule
    {
        public MainModule()
        {
            Get["/"] = parameters =>
            {
                return View["flat-ui"];
            };
        }
    }
}
