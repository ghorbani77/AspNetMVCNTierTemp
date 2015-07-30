using System.Web.Mvc;
using MVC5.Common.Controller;

namespace MVC5.Web.Controllers
{
    [RoutePrefix("Error")]
    [Route("{action}")]
    public partial class ErrorController : BaseController
    {
        public virtual ActionResult Error404()
        {
            return View();
        }
        public virtual ActionResult Error500()
        {
            return View();
        }
    }
}
