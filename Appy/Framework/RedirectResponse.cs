﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Appy
{
    public class RedirectResponse : BasicResponse
    {
        public RedirectResponse(string redirectUrl, string content = "This page has moved.")
            : base(content, 302)
        {
            Headers.Add("Location", redirectUrl);
        }
    }
}
