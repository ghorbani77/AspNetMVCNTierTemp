using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC5.Web.Filters;

namespace MVC5.Web.Controllers
{
    [MvcAuthorize]
    public partial class FileController : Controller
    {
        [DisplayName("دسترسی به تصاویر")]
        public virtual ActionResult Image(string name)
        {
            return View();
        }
        [DisplayName("دسترسی به فایل های ارسالی")]
        public virtual ActionResult UserFile(string name)
        {
            return View();
        }
        [DisplayName("دسترسی به تصاویر کاربران")]
        public virtual ActionResult Avatar(string name)
        {
            return View();
        }
    }
}
