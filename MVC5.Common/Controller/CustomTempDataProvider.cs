using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
using System.Web.Mvc;

namespace MVC5.Common.Controller
{
    public class CustomTempDataProvider : ITempDataProvider
    {
        private const string CookieName = "TempDataProvider";

        private readonly IFormatter _formatter;
        public CustomTempDataProvider(IFormatter formatter)
        {
           
            _formatter = formatter;
        }

        public IDictionary<string, object> LoadTempData(ControllerContext controllerContext)
        {
            return GetTempDataFromCookie(controllerContext);
        }

        public void SaveTempData(ControllerContext controllerContext, IDictionary<string, object> values)
        {
            var currentValues = GetTempDataFromCookie(controllerContext);
            if (currentValues.SequenceEqual(values))
            {
                return;
            }
            var cookie = new HttpCookie(CookieName)
            {
                Value = string.Empty,
                HttpOnly = true,
                Path = controllerContext.HttpContext.Request.ApplicationPath,
                Secure = controllerContext.HttpContext.Request.IsSecureConnection
            };

            if (values.Count == 0)
            {
                cookie.Expires = DateTime.Now.AddDays(-1);
                controllerContext.HttpContext.Response.Cookies.Set(cookie);

                return;
            }

            using (var stream = new MemoryStream())
            {
                _formatter.Serialize(stream, values);
                var bytes = stream.ToArray();

                cookie.Value = Convert.ToBase64String(bytes);
            }
            controllerContext.HttpContext.Response.Cookies.Add(cookie);
        }

        private IDictionary<string, object> GetTempDataFromCookie(ControllerContext controllerContext)
        {
            var cookie = controllerContext.HttpContext.Request.Cookies[CookieName];
            if (cookie == null || string.IsNullOrEmpty(cookie.Value)) return new Dictionary<string, object>();
            var bytes = Convert.FromBase64String(cookie.Value);
            using (var stream = new MemoryStream(bytes))
            {
                return _formatter.Deserialize(stream) as IDictionary<string, object>;
            }
        }
    }
}
