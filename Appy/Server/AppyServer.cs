﻿using SelfServe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;

namespace Appy
{
    public class AppyServer : HttpFileServer
    {
        UrlRouter UrlRouter;
        ExceptionRouter ExceptionRouter;

        public AppyServer()
        {
            UrlRouter = new UrlRouter();
            UrlRouter.LoadRoutesFrom(Assembly.GetExecutingAssembly());

            ExceptionRouter = new ExceptionRouter();
            ExceptionRouter.LoadRoutesFrom(Assembly.GetExecutingAssembly());
        }

        protected override void OnPathNotFound(HttpListenerRequest rawRequest, HttpListenerResponse rawResponse)
        {
            try
            {
                UrlRouter.TryExecuteRequest(rawRequest, rawResponse);

                Log("Client requested path ({0})... Handler found", rawRequest.RawUrl);
            }
            catch (RouteNotFoundException)
            {
                base.OnPathNotFound(rawRequest, rawResponse);
            }
        }

        protected override void OnException(Exception ex)
        {
            ExceptionRouter.TryHandleException(ex);
        }
    }
}
