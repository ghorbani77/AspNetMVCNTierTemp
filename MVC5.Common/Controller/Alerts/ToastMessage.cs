using System;

namespace MVC5.Common.Controller.Alerts
{
    [Serializable]
    public class ToastMessage
    {
        public const string TempDataKey = "TempDataToastrAlerts";
        public string Title { get; set; }
        public string Message { get; set; }
        public string AlertType { get; set; }
        public bool IsSticky { get; set; }
    }
}
