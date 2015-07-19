using System.IO;
using System.Web.Mvc;
using VikingErik.Mvc.ResumingActionResults;

namespace MVC5.Web.Controllers
{
    public partial class ExportController : Controller
    {
        [Route("Export/{*id}")]
        public virtual ActionResult Index(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return Redirect("/");
            }
            var filename = Path.GetFileName(id);
            var path = Server.MapPath("~/Export/" + filename);
            return new ResumingFilePathResult(path, System.Net.Mime.MediaTypeNames.Application.Octet);
        }
    }
}