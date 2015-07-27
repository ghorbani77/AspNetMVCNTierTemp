using System.ComponentModel;
using System.Web.Mvc;
using MVC5.Web.Filters;
using MVC5.Common.Controller;

namespace MVC5.Web.Areas.Administrator.Controllers
{
    [MvcAuthorize(AreaName = "Administrator")]
    [DisplayName("دسترسی به پنل مدیریت")]
    public partial class HomeController : BaseController
    {
        [DisplayName("مشاهده پنل مدیریت")]
        public virtual ActionResult Index()
        {

            return View();
        }
    }
}