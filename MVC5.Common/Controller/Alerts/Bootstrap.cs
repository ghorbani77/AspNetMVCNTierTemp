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
        public BootstrapMessage AddBootstrapMessage(BootstrapMessage message)
        {
            BootstrapMessages.Add(message);
            return message;
        }

       
    }
}
