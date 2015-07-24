using System.Web.Mvc;
using MVC5.Common.Controller;
using MVC5.Web.Filters;

namespace MVC5.Web.Controllers
{
    [MvcAuthorize]
    public partial class HomeController : BaseController
    {

        #region Fields
        private const int ADay = 86400;

        #endregion

        #region Ctor

        #endregion
        public virtual ActionResult Index()
        {

            ToastrSuccess("سلام");
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
        [AllowAnonymous]
        public virtual ActionResult About()
        {
            ToastrWarning("سلام");
            return RedirectToAction("Index");
        }
        [AllowAnonymous]
        public virtual ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
