using System.Web.Mvc;
using MVC5.Web.Filters;
using MVC5.Common.Controller;

namespace MVC5.Web.Areas.Administrator.Controllers
{

    [RouteArea("Panel")]
    [RoutePrefix("Home")]
    public partial class HomeController : BaseController
    {
        [MvcAuthorize( Roles = "CanVisitAdminPanel",
       CanBeMenu = true)]
        [Route("Index")]
        public virtual ActionResult Index()
        {
            return View();
        }
    }
}