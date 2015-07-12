using System;
using System.Web;

namespace MVC5.Common.Helpers.Extentions
{
    public static class CookieHelper
    {
        

        public static void AddCookie(this HttpContextBase httpContextBase, string cookieName, string value)
        {
            httpContextBase.AddCookie(cookieName, value, DateTime.Now.AddDays(30));
        }

        public static void RemoveCookie(this HttpContextBase httpContextBase, string cookieName)
        {
            var cookie = new HttpCookie(cookieName)
            {
                Expires = DateTime.Now.AddDays(-1)
            };
            httpContextBase.Response.Cookies.Set(cookie);
        }

        public static void UpdateCookie(this HttpContextBase httpContextBase, string cookieName, string value,bool httpOnly=false)
        {
            var cookie = new HttpCookie(cookieName)
            {
                Value = httpContextBase.Server.UrlEncode(value),
                HttpOnly = httpOnly
            };
            httpContextBase.Response.Cookies.Set(cookie);
        }
        public static void AddCookie(this HttpContextBase httpContextBase, string cookieName, string value, DateTime expires,bool httpOnly=false)
        {
            var cookie = new HttpCookie(cookieName)
            {
                Expires = expires,
                Value = httpContextBase.Server.UrlEncode(value) ,// For Cookies and Unicode characters
                HttpOnly = httpOnly
            };
            httpContextBase.Response.Cookies.Add(cookie);
        }

        public static string GetCookieValue(this HttpContextBase httpContext, string cookieName)
        {
            var cookie = httpContext.Request.Cookies[cookieName];
            return cookie == null ? string.Empty : httpContext.Server.UrlDecode(cookie.Value);

            // For Cookies and Unicode characters
        }
    }
}