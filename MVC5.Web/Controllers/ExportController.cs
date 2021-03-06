﻿using System.ComponentModel;
using System.IO;
using System.Web.Mvc;
using MVC5.Common.Controller;
using MVC5.Web.Filters;
using VikingErik.Mvc.ResumingActionResults;

namespace MVC5.Web.Controllers
{
    public partial class ExportController : BaseController
    {
        [Route("Export/{*id}")]
        [DisplayName("امکان دانلود فایل ها")]
        [Mvc5Authorize(Roles = "CanDownLoadExports", IsMenu = false)]
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