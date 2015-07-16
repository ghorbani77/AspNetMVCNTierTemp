using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Web.Mvc;
using System.Web.WebPages;
using MVC5.Common.Controller.Alerts;

namespace MVC5.Common.Controller
{
    public static class ControllerExtentions
    {

        #region RenderViewToString
        /// <summary>
        /// Render partial view to string
        /// </summary>
        /// <param name="controller"></param>
        /// <returns>Result</returns>
        public static string RenderPartialViewToString(this ControllerBase controller)
        {
            return RenderPartialViewToString(controller, null, null);
        }

        /// <summary>
        /// Render partial view to string
        /// </summary>
        /// <param name="controller"></param>
        /// <param name="viewName">View name</param>
        /// <returns>Result</returns>
        public static string RenderPartialViewToString(this ControllerBase controller, string viewName)
        {
            return RenderPartialViewToString(controller, viewName, null);
        }

        /// <summary>
        /// Render partial view to string
        /// </summary>
        /// <param name="controller"></param>
        /// <param name="model">Model</param>
        /// <returns>Result</returns>
        public static string RenderPartialViewToString(this ControllerBase controller, object model)
        {
            return RenderPartialViewToString(controller, null, model);
        }

        /// <summary>
        /// Render partial view to string
        /// </summary>
        /// <param name="controller"></param>
        /// <param name="viewName">View name</param>
        /// <param name="model">Model</param>
        /// <returns>Result</returns>
        public static string RenderPartialViewToString(this ControllerBase controller, string viewName, object model)
        {
            if (viewName.IsEmpty())
                viewName = controller.ControllerContext.RouteData.GetRequiredString("action");

            controller.ViewData.Model = model;

            using (var sw = new StringWriter())
            {
                var viewResult = System.Web.Mvc.ViewEngines.Engines.FindPartialView(controller.ControllerContext, viewName);

                ThrowIfViewNotFound(viewResult, viewName);

                var viewContext = new ViewContext(controller.ControllerContext, viewResult.View, controller.ViewData, controller.TempData, sw);
                viewResult.View.Render(viewContext, sw);

                return sw.GetStringBuilder().ToString();
            }
        }

        /// <summary>
        /// Render view to string
        /// </summary>
        /// <returns>Result</returns>
        public static string RenderViewToString(this ControllerBase controller)
        {
            return RenderViewToString(controller, null, null, null);
        }

        /// <summary>
        /// Render view to string
        /// </summary>
        /// <param name="model">Model</param>
        /// <returns>Result</returns>
        public static string RenderViewToString(this ControllerBase controller, object model)
        {
            return RenderViewToString(controller, null, null, model);
        }

        /// <summary>
        /// Render view to string
        /// </summary>
        /// <param name="viewName">View name</param>
        /// <returns>Result</returns>
        public static string RenderViewToString(this ControllerBase controller, string viewName)
        {
            return RenderViewToString(controller, viewName, null, null);
        }

        /// <summary>
        /// Render view to string
        /// </summary>
        /// <param name="controller"></param>
        /// <param name="viewName">View name</param>
        /// <param name="model">Model</param>
        /// <returns>Result</returns>
        public static string RenderViewToString(this ControllerBase controller, string viewName, string masterName)
        {
            return RenderViewToString(controller, viewName, masterName, null);
        }

        /// <summary>
        /// Render view to string
        /// </summary>
        /// <param name="controller"></param>
        /// <param name="viewName">View name</param>
        /// <param name="masterName">Master name</param>
        /// <param name="model">Model</param>
        /// <returns>Result</returns>
        public static string RenderViewToString(this ControllerBase controller, string viewName, string masterName, object model)
        {
            if (viewName.IsEmpty())
                viewName = controller.ControllerContext.RouteData.GetRequiredString("action");

            controller.ViewData.Model = model;

            using (var sw = new StringWriter())
            {
                var viewResult = System.Web.Mvc.ViewEngines.Engines.FindView(controller.ControllerContext, viewName, masterName);

                ThrowIfViewNotFound(viewResult, viewName);

                var viewContext = new ViewContext(controller.ControllerContext, viewResult.View, controller.ViewData, controller.TempData, sw);
                viewResult.View.Render(viewContext, sw);

                return sw.GetStringBuilder().ToString();
            }
        }

        private static void ThrowIfViewNotFound(ViewEngineResult viewResult, string viewName)
        {
            // if view not found, throw an exception with searched locations
            if (viewResult.View != null) return;
            var locations = new StringBuilder();
            locations.AppendLine();

            foreach (var location in viewResult.SearchedLocations)
            {
                locations.AppendLine(location);
            }

            throw new InvalidOperationException(string.Format("The view '{0}' or its master was not found, searched locations: {1}", viewName, locations));
        }

        #endregion

        #region IsEmbeddedIntoAnotherDomain
        public static bool IsEmbeddedIntoAnotherDomain(this ControllerBase controller)
        {

            var url = controller.ControllerContext.HttpContext.Request.Url;
            var urlReferrer = controller.ControllerContext.HttpContext.Request.UrlReferrer;
            return url != null && (urlReferrer != null &&
                                   !url.Host.Equals(urlReferrer.Host,
                                       StringComparison.InvariantCultureIgnoreCase));

        }
        #endregion

        #region Alerts
        public static void AddToastrAlert(this System.Web.Mvc.Controller controller, string alertStyle, string title,string message, bool isSticky)
        {
            var alerts = controller.TempData.ContainsKey(ToastMessage.TempDataKey)
                ? (List<ToastMessage>)controller.TempData[ToastMessage.TempDataKey]
                : new List<ToastMessage>();

            alerts.Add(new ToastMessage
            {
                AlertType = alertStyle,
                Message = message,
                IsSticky = isSticky,
                Title = title
            });

            controller.TempData[BootstrapMessage.TempDataKey] = alerts;
        }
        public static void AddBootstrapAlert(this System.Web.Mvc.Controller controller, string alertStyle, string message, bool dismissable)
        {
            var alerts = controller.TempData.ContainsKey(BootstrapMessage.TempDataKey)
                ? (List<BootstrapMessage>)controller.TempData[BootstrapMessage.TempDataKey]
                : new List<BootstrapMessage>();

            alerts.Add(new BootstrapMessage
            {
                AlertType = alertStyle,
                Message = message,
                Dismissable = dismissable
            });

            controller.TempData[BootstrapMessage.TempDataKey] = alerts;
        }


        #endregion
    }
}