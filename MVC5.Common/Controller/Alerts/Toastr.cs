using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC5.Common.Controller.Alerts
{
    [Serializable]
    public class Toastr
    {
        public bool ShowNewestOnTop { get; set; }
        public bool ShowCloseButton { get; set; }
        public IList<ToastMessage> ToastMessages { get; set; }

        public Toastr()
        {
            ToastMessages = new List<ToastMessage>();
            ShowNewestOnTop = false;
            ShowCloseButton = false;
        }
        public ToastMessage AddToastMessage(string title, string message, bool isSticky,string alertType=AlertType.Information)
        {
            var toast = new ToastMessage()
            {
                Title = title,
                Message = message,
                AlertType = alertType,
                IsSticky = isSticky
            };
            ToastMessages.Add(toast);
            return toast;
        }
    }
}
