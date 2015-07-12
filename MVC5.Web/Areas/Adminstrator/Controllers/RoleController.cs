using System.Web.Mvc;

namespace MVC5.Web.Areas.Adminstrator.Controllers
{
    public partial class RoleController : Controller
    {
        // GET: Adminstrator/Role
        public virtual ActionResult Index()
        {
            return View();
        }
    }
}