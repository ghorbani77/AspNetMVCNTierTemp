using System.Web.Mvc;
using MVC5.Web.Filters;

namespace MVC5.Web.Areas.Adminstrator.Controllers
{
   // [MvcAuthorize(Description = "پنل مدیریت", Roles = "AdminPanel", CanBeMenu = true)]
    public partial class HomeController : Controller
    {
      //  [MvcAuthorize(Description = "مشاهده پنل مدیریت", Roles = "AdminPanel,CanViewAdminPanel", CanBeMenu = true)]
        public virtual ActionResult Index()
        {
            return View();
         
        }
    }
}