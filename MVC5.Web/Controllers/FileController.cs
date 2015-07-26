using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC5.Web.Controllers
{
    public class FileController : Controller
    {
        public ActionResult Image(string name)
        {
            return View();
        }

        public ActionResult UserFile(string name)
        {
            return View();
        }

        public ActionResult Avatar(string name)
        {
            return View();
        }
    }
}
