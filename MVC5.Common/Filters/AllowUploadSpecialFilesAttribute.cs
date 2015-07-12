﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC5.Common.Filters
{
    public class AllowUploadSpecialFilesOnlyAttribute : ActionFilterAttribute
    {

        #region Fields
        private readonly string _extensionsWhiteList;
        private readonly List<string> _toFilter = new List<string>();

        #endregion

        #region Constcutor
        public AllowUploadSpecialFilesOnlyAttribute(string extensionsWhiteList)
        {
            if (string.IsNullOrWhiteSpace(extensionsWhiteList))
                throw new ArgumentNullException("extensionsWhiteList");

            _extensionsWhiteList = extensionsWhiteList;
            var extensions = extensionsWhiteList.Split(',');
            foreach (var ext in extensions.Where(ext => !string.IsNullOrWhiteSpace(ext)))
            {
                _toFilter.Add(ext.ToLowerInvariant().Trim());
            }
        }
        #endregion

        #region CanUpload
        private bool CanUpload(string fileName)
        {
            if (string.IsNullOrWhiteSpace(fileName)) return false;

            var extention = Path.GetExtension(fileName.ToLowerInvariant());
            return _toFilter.Contains(extention);
        }

        #endregion

        #region OnActionExecuting Override
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var files = filterContext.HttpContext.Request.Files;
            foreach (var postedFile in files.Cast<string>().Select(file => files[file]).Where(postedFile => postedFile != null && postedFile.ContentLength != 0))
            {
                //if user upload just image this section is required
               if (!IsImageFile(postedFile)) return;

                if (!CanUpload(postedFile.FileName))
                    throw new InvalidOperationException(
                        string.Format("You are not allowed to upload {0} file. Please upload only these files: {1}.",
                            Path.GetFileName(postedFile.FileName),
                            _extensionsWhiteList));
            }

            base.OnActionExecuting(filterContext);
        }
        #endregion

        #region IsImageFile
        public static bool IsImageFile(HttpPostedFileBase photoFile)
        {
            using (var img = Image.FromStream(photoFile.InputStream))
            {
                return img.Width > 0;
            }
        }
        #endregion

    }
}