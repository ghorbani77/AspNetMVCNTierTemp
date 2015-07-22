using System;
using System.Net;
using System.Web.Mvc;
using Microsoft.Owin.Security;

namespace MVC5.Web.Filters
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method,Inherited = true, AllowMultiple = true)]
    public sealed class MvcAuthorizeAttribute : AuthorizeAttribute
    {

        #region Fields
        private readonly IAuthenticationManager _authenticationManager;
        
        #endregion

        #region Properties
        public string Description { get; set; }
        public bool CanBeMenu { get; set; }
        public string DefaultActioName { get; set; }
        #endregion

        #region Constructor
        public MvcAuthorizeAttribute(IAuthenticationManager authenticationManager)
        {
            _authenticationManager = authenticationManager;
        }

        public MvcAuthorizeAttribute()
        {

        }
        #endregion
       
        #region HandleUnauthorizedRequest
        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            if (filterContext.HttpContext.Request.IsAuthenticated)
            {
                _authenticationManager.SignOut();
                throw new UnauthorizedAccessException(); //to avoid multiple redirects
            }
            HandleAjaxRequest(filterContext);
            base.HandleUnauthorizedRequest(filterContext);
        }
        #endregion

        #region HandleAjaxRequest
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