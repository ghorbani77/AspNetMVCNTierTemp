using System.Web.Mvc;
using MVC5.Common.Filters;
namespace MVC5.Web
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {

            //logg action errors
            //filters.Add(new ElmahHandledErrorLoggerFilter());
            //logg xss attacks 
           // filters.Add(new ElmahRequestValidationErrorFilter());
            filters.Add(new ForceWww("http://localhost:25890/"));
            //with this filter you cann't user inline script or css on page
            //filters.Add(new ContentSecurityPolicyFilterAttribute());
        }
    }
}
