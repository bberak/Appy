using Nancy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nancy.TinyIoc;
using Nancy.Bootstrapper;
using Nancy.Conventions;

namespace Appy.Core.Nancy
{
    public class AppyBootstrapper : DefaultNancyBootstrapper
    {
        protected override void ApplicationStartup(TinyIoCContainer container, IPipelines pipelines)
        {
            this.Conventions.ViewLocationConventions.Add((viewName, model, context) =>
            {
                return String.Concat("Site/Views/", viewName);
            });
        }

        protected override void ConfigureConventions(NancyConventions nancyConventions)
        {
            base.ConfigureConventions(nancyConventions);

            nancyConventions.StaticContentsConventions.AddDirectory("Site/");
        }
    }
}
