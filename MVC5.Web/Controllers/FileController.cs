using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC5.Common.Controller;
using MVC5.ServiceLayer.Security;
using MVC5.Web.Filters;

namespace MVC5.Web.Controllers
{
    public partial class FileController : BaseController
    {
        [DisplayName("دسترسی به تصاویر")]
        [Mvc5Authorize(SystemPermissionNames.CanAccessImages)]
        public virtual ActionResult Image(string name)
        {
            return View();
        }
        [DisplayName("دسترسی به فایل های ارسالی")]
        [Mvc5Authorize(SystemPermissionNames.CanAccessUsersFiles)]
        public virtual ActionResult UserFile(string name)
        {
            return View();
        }
        [DisplayName("دسترسی به تصاویر کاربران")]
        [Mvc5Authorize(SystemPermissionNames.CanAccessUsersAvatar)]
        public virtual ActionResult Avatar(string name)
        {
            return View();
        }
    }
}
