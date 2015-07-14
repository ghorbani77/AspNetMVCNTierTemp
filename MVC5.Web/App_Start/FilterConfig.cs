using System.Web.Mvc;
using MVC5.Common.Filters;
using MVC5.Web.Filters;

namespace MVC5.Web
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            //logg action errors
            filters.Add(new ElmahHandledErrorLoggerFilter());
            //logg xss attacks 
            filters.Add(new ElmahRequestValidationErrorFilter());
            filters.Add(new ForceWww(""));
            filters.Add(new ContentSecurityPolicyFilterAttribute());
        }
    }
}
