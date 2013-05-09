using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Appy.Core
{
    public class RedirectResponse : BasicResponse
    {
        public RedirectResponse(string redirectUrl, string content = "This page has moved.")
            : base(content)
        {
            Headers.Add("Location", redirectUrl);
            StatusCode = 302;
        }
    }
}
