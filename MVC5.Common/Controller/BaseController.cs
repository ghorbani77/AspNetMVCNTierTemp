using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVC5.Common.Controller.Alerts;
using MVC5.Common.Controller;
namespace MVC5.Common.Controller
{
    public class BaseController : System.Web.Mvc.Controller
    {
        #region boostrapalerts
        public void BoostrapSuccess(string message, bool dismissable = false)
        {
            this.AddBootstrapAlert(AlertType.Success, message, dismissable);
        }

        public void BoostrapInformation(string message, bool dismissable = false)
        {
            this.AddBootstrapAlert(AlertType.Information, message, dismissable);
        }

        public void BoostrapWarning(string message, bool dismissable = false)
        {
            this.AddBootstrapAlert(AlertType.Warning, message, dismissable);
        }

        public void BoostrapDanger(string message, bool dismissable = false)
        {
            this.AddBootstrapAlert(AlertType.Danger, message, dismissable);
        }

        #endregion

        #region toastralerts

        public void ToastrDanger(string message, string title,
            bool isSticky = false)
        {
            this.AddToastrAlert(AlertType.Danger, title, message, isSticky);
        }
        public void ToastrWarning(string message, string title,
          bool isSticky = false)
        {
            this.AddToastrAlert(AlertType.Warning, title, message, isSticky);
        }
        public void ToastrInformation(string message, string title,
          bool isSticky = false)
        {
            this.AddToastrAlert(AlertType.Information, title, message, isSticky);
        }
        public void ToastrSuccess(string message, string title,
          bool isSticky = false)
        {
            this.AddToastrAlert(AlertType.Success, title, message, isSticky);
        }
        #endregion

    }
}

