using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC5.Web.Areas.Administrator.Controllers
{
    public partial class HomeController : Controller
    {
        // GET: Administrator/Home
        public virtual ActionResult Index()
        {
            return View();
        }
    }
}