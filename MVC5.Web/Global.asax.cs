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
    public class MvcApplication : System.Web.HttpApplication
    {

        #region Application_Start
        protected void Application_Start()
        {
            try
            {
                AreaRegistration.RegisterAllAreas();
                FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
                RouteConfig.RegisterRoutes(RouteTable.Routes);
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

            if (Request.IsLocal)
            {
                MiniProfiler.Start();
            }
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
            if (ShouldIgnoreRequest()) return;

            if (Context.User == null)
                return;
        }
        #endregion
    }
}
