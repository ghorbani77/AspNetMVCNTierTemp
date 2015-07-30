using System.Web.Mvc;

namespace MVC5.Web.Areas.Administrator
{
    public class AdministratorAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Administrator";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Administrator_default",
                "Administrator/{controller}/{action}/{id}",
                new { controller = MVC.Administrator.Home.Name, action = MVC.Administrator.Home.ActionNames.Index, id = UrlParameter.Optional },
                namespaces: new[] { string.Format("{0}.Controllers", typeof(AdministratorAreaRegistration).Namespace) }
                );
        }
    }
}