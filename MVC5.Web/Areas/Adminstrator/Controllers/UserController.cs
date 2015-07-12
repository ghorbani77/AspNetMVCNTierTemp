using System.Web.Mvc;

namespace MVC5.Web.Areas.Adminstrator.Controllers
{
    public partial class UserController : Controller
    {
        // GET: Adminstrator/User
        public virtual ActionResult Index()
        {
            return View();
        }
    }
}