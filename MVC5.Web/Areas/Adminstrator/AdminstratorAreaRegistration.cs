using System.Web.Mvc;

namespace MVC5.Web.Areas.Adminstrator
{
    public class AdminstratorAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Adminstrator";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Adminstrator_default",
                "Adminstrator/{controller}/{action}/{id}",
                new {controller="Home", action = "Index", id = UrlParameter.Optional },
                namespaces: new [] { string.Format("{0}.Controllers",this.GetType().Namespace)}
            );
        }
    }
}