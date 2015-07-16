using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Net.Mime;
using System.Web.Helpers;
using System.Web.Mvc;
using MVC5.Common.Controller;
using MVC5.Common.Helpers.Extentions;

namespace MVC5.Web.Controllers
{
    public partial class HomeController : BaseController
    {

        #region Fields
        private const int ADay = 86400;

        #endregion
        public virtual ActionResult Index()
        {
           ToastrSuccess("سلام","تست");
            return View();
        }


        //for waterMark site images 
        //[OutputCache(VaryByParam = "fileName", Duration = ADay)]
        //public ActionResult Image(string fileName)
        //{
        //    fileName = Path.GetFileName(fileName); 
        //    var rootPath = Server.MapPath("~/Images");
        //    var path = Path.Combine(rootPath, fileName);
        //    if (!System.IO.File.Exists(path))
        //    {
        //        const string notFoundImage = "notFound.png";
        //        path = Path.Combine(rootPath, notFoundImage);
        //        return File(path, MediaTypeNames.Image.Gif, notFoundImage);
        //    }

        //    if (!this.IsEmbeddedIntoAnotherDomain()) return File(path, MediaTypeNames.Image.Gif, fileName);

        //    var text = Url.Action(actionName: "Index", controllerName: "Home", routeValues: null, protocol: "http");
        //    var content = ImageManage.AddWaterMark(path, text);
        //    return File(content, MediaTypeNames.Image.Gif, fileName);
        //}

        public virtual ActionResult About()
        {
            ToastrWarning("سلام", "تست");
           return  RedirectToAction(MVC.Home.ActionNames.Index);
        }

        public virtual ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
