using System.Web.Mvc;

namespace MVC5.Web.Areas.Adminstrator.Controllers
{
    public partial class HomeController : Controller
    {
        // GET: Adminstrator/Home
        public virtual ActionResult Index()
        {
            return View();
        }
    }
}