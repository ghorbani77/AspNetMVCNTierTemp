using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC5.Common.Controller.Alerts
{
    [Serializable]
    public class ToastMessage
    {
        public const string TempDataKey = "TempDataToastrAlert";
        public string Title { get; set; }
        public string Message { get; set; }
        public string AlertType { get; set; }
        public bool IsSticky { get; set; }
    }
}
