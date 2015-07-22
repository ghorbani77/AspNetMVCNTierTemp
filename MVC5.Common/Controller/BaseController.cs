using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using MVC5.Common.Controller.Alerts;
using MVC5.Common.Controller;
namespace MVC5.Common.Controller
{
    public class BaseController : System.Web.Mvc.Controller
    {

        #region boostrapalerts
        public void BoostrapSuccess(string message, bool dismissable = false)
        {
            var bootstrapMessage = new BootstrapMessage
            {
                AlertType = AlertType.Success,
                Dismissable = dismissable,
                Message = message
            };
            this.AddBootstrapAlert(bootstrapMessage);
        }

        public void BoostrapInformation(string message, bool dismissable = false)
        {
            var bootstrapMessage = new BootstrapMessage
            {
                AlertType = AlertType.Information,
                Dismissable = dismissable,
                Message = message
            };
            this.AddBootstrapAlert(bootstrapMessage);
        }

        public void BoostrapWarning(string message, bool dismissable = false)
        {
            var bootstrapMessage = new BootstrapMessage
            {
                AlertType = AlertType.Warning,
                Dismissable = dismissable,
                Message = message
            };
            this.AddBootstrapAlert(bootstrapMessage);
        }

        public void BoostrapDanger(string message, bool dismissable = false)
        {
            var bootstrapMessage = new BootstrapMessage
            {
                AlertType = AlertType.Danger,
                Dismissable = dismissable,
                Message = message
            };
            this.AddBootstrapAlert(bootstrapMessage);
        }

        #endregion

        #region toastralerts

        public void ToastrError(string message, string title="",
            bool isSticky = false)
        {
            var toastMessage = new ToastMessage
            {
                AlertType = AlertType.Error,
                IsSticky = isSticky,
                Message = message,
                Title = title
            };

            this.AddToastrAlert(toastMessage);
        }
        public void ToastrWarning(string message, string title="",
          bool isSticky = false)
        {
            var toastMessage = new ToastMessage
            {
                AlertType = AlertType.Warning,
                IsSticky = isSticky,
                Message = message,
                Title = title
            };
            this.AddToastrAlert(toastMessage);
        }
        public void ToastrInformation(string message, string title="",
          bool isSticky = false)
        {
            var toastMessage = new ToastMessage
            {
                AlertType = AlertType.Information,
                IsSticky = isSticky,
                Message = message,
                Title = title
            };
            this.AddToastrAlert(toastMessage);
        }
        public void ToastrSuccess(string message, string title="",
          bool isSticky = false)
        {
            var toastMessage = new ToastMessage
            {
                AlertType = AlertType.Success,
                IsSticky = isSticky,
                Message = message,
                Title = title
            };
            this.AddToastrAlert(toastMessage);
        }
        #endregion

        #region Validation
         [ChildActionOnly]
        protected ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            return RedirectToAction("Index","Home", new { area = "" });
        }
        #endregion

    }
}

