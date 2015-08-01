using System.ComponentModel;
using System.Web.Mvc;
using MVC5.ServiceLayer.Security;
using MVC5.Web.Filters;
using MVC5.Common.Controller;

namespace MVC5.Web.Areas.Administrator.Controllers
{
    public partial class HomeController : BaseController
    {
        [Mvc5Authorize(SystemPermissionNames.CanViewAdminPanel, 
            AreaName = "Administrator", IsMenu = true)]
        [DisplayName("مشاهده پنل مدیریت")]
        public virtual ActionResult Index()
        {

            return View();
        }
    }
}