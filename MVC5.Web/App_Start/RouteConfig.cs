using System.Web.Mvc;
using System.Web.Routing;

namespace MVC5.Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("Content/{*pathInfo}");
            routes.IgnoreRoute("Scripts/{*pathInfo}");
            routes.IgnoreRoute("Images/{*pathInfo}");
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.IgnoreRoute("favicon.ico");
            routes.IgnoreRoute("{resource}.ico");
            routes.IgnoreRoute("{resource}.png");
            routes.IgnoreRoute("{resource}.jpg");
            routes.IgnoreRoute("{resource}.gif");
            routes.IgnoreRoute("{resource}.txt");

            routes.LowercaseUrls = true;
            routes.MapMvcAttributeRoutes();
          
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { string.Format("{0}.Controllers", typeof(RouteConfig).Namespace) }
            );
        }
    }
}