using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using MVC5.IocConfig;
using MVC5.ServiceLayer.Contracts;
using StackExchange.Profiling;
using StructureMap.Web.Pipeline;
using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace MVC5.Web
{
    public class MvcApplication : HttpApplication
    {

        #region Application_Start
        protected void Application_Start()
        {
            try
            {
                AreaRegistration.RegisterAllAreas();
                RoutingConfig.RegisterRoutes(RouteTable.Routes);
                FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
                BundleConfig.RegisterBundles(BundleTable.Bundles);
                CustomAppConfig.Config();
            }
            catch
            {
                HttpRuntime.UnloadAppDomain(); // سبب ری استارت برنامه و آغاز مجدد آن با درخواست بعدی می‌شود
                throw;
            }

        }
        #endregion

        #region Application_EndRequest
        protected void Application_EndRequest(object sender, EventArgs e)
        {
            HttpContextLifecycle.DisposeAndClearAll();
            MiniProfiler.Stop();
        }
        #endregion

        #region Application_BeginRequest
        private void Application_BeginRequest(object sender, EventArgs e)
        {
#if DEBUG
            if (Request.IsLocal)
            {
                MiniProfiler.Start();
            }
#endif
        }
        #endregion

        #region ShouldIgnoreRequest
        private bool ShouldIgnoreRequest()
        {
            string[] reservedPath =
              {
                  "/__browserLink",
                  "/Images",
                  "/Scripts",
                  "/Content"
              };

            var rawUrl = Context.Request.RawUrl;
            if (reservedPath.Any(path => rawUrl.StartsWith(path, StringComparison.OrdinalIgnoreCase)))
            {
                return true;
            }

            return BundleTable.Bundles.Select(bundle => bundle.Path.TrimStart('~'))
                      .Any(bundlePath => rawUrl.StartsWith(bundlePath, StringComparison.OrdinalIgnoreCase));
        }
        #endregion

        #region Application_AuthenticateRequest

        protected void Application_AuthenticateRequest(Object sender, EventArgs e)
        {
           // for forms Authentication if (ShouldIgnoreRequest()) return;

            if (Context.User == null)
                return;

            if (
                !ProjectObjectFactory.Container.GetInstance<IApplicationUserManager>()
                    .CheckIsUserBannedOrDelete(User.Identity.GetUserId<int>())) return;
            ProjectObjectFactory.Container.GetInstance<IAuthenticationManager>().SignOut();
        }
        #endregion
    }
}
