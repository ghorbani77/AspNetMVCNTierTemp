using System.Web.Mvc;
using System.Web.Routing;
using AttributeRouting.Web.Mvc;

namespace MVC5.Web
{
    public static class RoutingConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {

            #region IgnoreRoutes
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
            #endregion
         
            routes.LowercaseUrls = true;
            // routes.RouteExistingFiles = true;
           routes.MapAttributeRoutes();

            routes.MapRoute(
                 name: "ImageRoute",
                 url: "File/Image/{*id}",
                 defaults: new { controller = "File", action = "Image", id = UrlParameter.Optional },
                 namespaces: new[] { string.Format("{0}.Controllers", typeof(RoutingConfig).Namespace) }
             );
            routes.MapRoute(
                name: "UserFileRoute",
                url: "File/UserFile/{*id}",
                defaults: new { controller = "File", action = "UserFile", id = UrlParameter.Optional },
                namespaces: new[] { string.Format("{0}.Controllers", typeof(RoutingConfig).Namespace) }
                );
            routes.MapRoute(
                name: "AvatarRoute",
                url: "File/Avatar/{*id}",
                defaults: new { controller = "File", action = "Avatar", id = UrlParameter.Optional },
                namespaces: new[] { string.Format("{0}.Controllers", typeof(RoutingConfig).Namespace) }
                );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = MVC.Home.Name, action = MVC.Home.ActionNames.Index, id = UrlParameter.Optional },
                namespaces: new[] { string.Format("{0}.Controllers", typeof(RoutingConfig).Namespace) }
            );
        }

    }
}
