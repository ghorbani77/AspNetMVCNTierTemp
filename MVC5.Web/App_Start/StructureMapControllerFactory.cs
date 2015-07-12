using System;
using System.Web.Mvc;
using System.Web.Routing;
using MVC5.IocConfig;

namespace MVC5.Web
{
    public class StructureMapControllerFactory : DefaultControllerFactory
    {
        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            if (controllerType == null)
            {
                //var url = requestContext.HttpContext.Request.RawUrl;
                ////string.Format("Page not found: {0}", url).LogException();

                //requestContext.RouteData.Values["controller"] = MVC.Search.Name;
                //requestContext.RouteData.Values["action"] = MVC.Search.ActionNames.Index;
                //requestContext.RouteData.Values["keyword"] = url.GenerateSlug().Replace("-", " ");
                //requestContext.RouteData.Values["categoryId"] = 0;
                //return SampleObjectFactory.Container.GetInstance(typeof(SearchController)) as Controller;
                throw new InvalidOperationException(string.Format("Page not found: {0}", requestContext.HttpContext.Request.RawUrl));
            }
            return ProjectObjectFactory.Container.GetInstance(controllerType) as Controller;
        }
    }
}