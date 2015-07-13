using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace MVC5.Common.Controller
{
    public class CookieTempDataProvider : ITempDataProvider
    {
        #region Fields
        internal const string TempDataCookieKey = "__ControllerTempData";
        readonly HttpContextBase _httpContext;
        #endregion

        #region Cons
        public CookieTempDataProvider(HttpContextBase httpContext)
        {
            if (httpContext == null)
            {
                throw new ArgumentNullException("httpContext");
            }
            _httpContext = httpContext;
        }

        #endregion

        #region Properties
        public System.Web.HttpContextBase HttpContext
        {
            get
            {
                return _httpContext;
            }
        }
        #endregion

        #region Implementation ITempDataProvider
        
       
        protected virtual IDictionary<string, object> LoadTempData(ControllerContext controllerContext)
        {
            var cookie = _httpContext.Request.Cookies[TempDataCookieKey];
            if (cookie == null || string.IsNullOrEmpty(cookie.Value)) return new Dictionary<string, object>();
            var deserializedTempData = DeserializeCookie(cookie.Value);
            return deserializedTempData;
        }

        protected virtual void SaveTempData(ControllerContext controllerContext, IDictionary<string, object> values)
        {
            var isDirty = (values != null && values.Count > 0);

            var cookieValue =SerializeToBase64EncodedString(values);
            var cookie = new System.Web.HttpCookie(TempDataCookieKey) {HttpOnly = true};

            // Remove cookie
            if (!isDirty)
            {
                cookie.Expires = DateTime.Now.AddDays(-4.0);
                cookie.Value = string.Empty;

                _httpContext.Response.Cookies.Set(cookie);

                return;

            }
            cookie.Value = cookieValue;

            _httpContext.Response.Cookies.Add(cookie);
        }

       

        IDictionary<string, object> ITempDataProvider.LoadTempData(ControllerContext controllerContext)
        {
            return LoadTempData(controllerContext);
        }

        void ITempDataProvider.SaveTempData(ControllerContext controllerContext, IDictionary<string, object> values)
        {
            SaveTempData(controllerContext, values);
        }

        #endregion

        #region Deserialize
        public static IDictionary<string, object> DeserializeCookie(string base64EncodedSerializedTempData)
        {
            var bytes = Convert.FromBase64String(base64EncodedSerializedTempData);
            var memStream = new MemoryStream(bytes);
            var binFormatter = new BinaryFormatter();
            return binFormatter.Deserialize(memStream, null) as IDictionary<string, object> /*TempDataDictionary : This returns NULL*/;
        }

        #endregion

        #region Serialize
        public static string SerializeToBase64EncodedString(IDictionary<string, object> values)
        {
            var memStream = new MemoryStream();
            memStream.Seek(0, SeekOrigin.Begin);
            var binFormatter = new BinaryFormatter();
            binFormatter.Serialize(memStream, values);
            memStream.Seek(0, SeekOrigin.Begin);
            var bytes = memStream.ToArray();
            return Convert.ToBase64String(bytes);
        }
        #endregion
    }
}
