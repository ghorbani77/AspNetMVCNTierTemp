using System;
using System.Web.Mvc;

namespace MVC5.Common.Helpers.Extentions
{
    public static class ControllerExtentions
    {
         
        public static bool IsEmbeddedIntoAnotherDomain(this Controller controller)
        {

            var url = controller.HttpContext.Request.Url;
            var urlReferrer = controller.HttpContext.Request.UrlReferrer;
            return url != null && (urlReferrer != null &&
                                   !url.Host.Equals(urlReferrer.Host,
                                       StringComparison.InvariantCultureIgnoreCase));

        }
    }
}