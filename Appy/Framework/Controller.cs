using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace Appy
{
    public abstract class Controller
    {
        public Response Basic(string content, int statusCode = 200)
        {
            return new BasicResponse(content, statusCode);
        }

        public Response View(string viewName, object model = null)
        {
            return new ViewResponse(viewName, model);
        }

        public Response Redirect(string redirectUrl, string content = "This page has moved.")
        {
            return new RedirectResponse(redirectUrl, content);
        }

        public Response Json(object model)
        {
            return new JsonResponse(model);
        }

        public Cookie Cookie(string name, string value)
        {
            return new Cookie(name, value);
        }

        public Header Header(string name, string value)
        {
            return new Header(name, value);
        }
    }
}
