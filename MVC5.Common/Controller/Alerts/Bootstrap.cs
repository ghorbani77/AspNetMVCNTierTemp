using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC5.Common.Controller.Alerts
{
    [Serializable]
    public class Bootstrap
    {
        public IList<BootstrapMessage> BootstrapMessages { get; set; }

        public Bootstrap()
        {
            BootstrapMessages=new List<BootstrapMessage>();
        }
        public BootstrapMessage AddBootstrapMessage(string title, string message,bool dismissable, string  alertType=AlertType.Information)
        {
            var bootstrap = new BootstrapMessage()
            {
                Message = message,
                AlertType = alertType,
                Dismissable = dismissable
            };
            BootstrapMessages.Add(bootstrap);
            return bootstrap;
        }

       
    }
}
