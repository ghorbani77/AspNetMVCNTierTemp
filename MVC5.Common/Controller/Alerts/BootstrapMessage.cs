﻿namespace MVC5.Common.Controller.Alerts
{
    public class BootstrapMessage
    {
        public const string TempDataKey = "TempDataBootstrapAlerts";
        public string AlertType { get; set; }
        public string Message { get; set; }
        public bool Dismissable { get; set; }
    }
}