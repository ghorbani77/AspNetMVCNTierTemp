using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace MVC5.Web.Filters
{

    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, Inherited = true, AllowMultiple = true)]
    public sealed class Mvc5AuthorizeAttribute : AuthorizeAttribute
    {
        #region Ctor

        public Mvc5AuthorizeAttribute(params string[] permissions):base()
        {
            Roles = string.Join(",", permissions);
        }

        #endregion

        #region Properties
        public string AreaName { get; set; }
        public bool IsMenu { get; set; }
        #endregion

        #region HandleUnauthorizedRequest
        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            if (filterContext.HttpContext.Request.IsAuthenticated)
            {
                System.Web.Security.FormsAuthentication.SignOut();
                throw new UnauthorizedAccessException(); //to avoid multiple redirects
            }
            else
            {
                HandleAjaxRequest(filterContext);
                base.HandleUnauthorizedRequest(filterContext);
            }
        }
        #endregion

        #region Private
        private static void HandleAjaxRequest(ControllerContext filterContext)
        {
            var ctx = filterContext.HttpContext;
            if (!ctx.Request.IsAjaxRequest())
                return;

            ctx.Response.StatusCode = (int)HttpStatusCode.Forbidden; //براي درخواست‌هاي اجكسي اعتبار سنجي نشده
            ctx.Response.End();
        }
        #endregion
     
    }

}