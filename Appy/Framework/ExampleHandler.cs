using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;

namespace Appy
{
    public class ExampleHandler
    {
        int Count;

        [Url("/index")]
        [Url("/launcher")]
        public Response Launcher(Request incoming)
        {
            return new ViewResponse("launcher.html");
        }
     
        [Url("/launcher/run")]
        public Response Run(Request incoming)
        {
            var exe = string.IsNullOrEmpty(incoming.Form.Get("exe-input")) ? incoming.Form.Get("exe-select") : incoming.Form.Get("exe-input");

            Process.Start(exe);

            return new RedirectResponse("/launcher");
        }

        [Url("/testing")]
        public Response Testing(Request incoming)
        {
            Count++;

            return new ViewResponse("testing.html", Count);
        }

        [Url("/flat-ui")]
        public Response FlatUI(Request incoming)
        {
            var name = incoming.Form.Get("Name");
            var email = incoming.Form.Get("Email");

            var cookie = new Cookie("Name", "Value").ExpiresIn(30);

            return new ViewResponse("flat-ui.html", Count);
        }
    }
}
