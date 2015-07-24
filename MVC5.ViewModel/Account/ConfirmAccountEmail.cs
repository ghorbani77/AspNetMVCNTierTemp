using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC5.ViewModel.Account
{
    public class ConfirmAccountEmail
    {
        public string To { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
        public string From { get; set; }
        public string Url { get; set; }
        public string UrlText { get; set; }
        public string ViewName { get; set; }
    }
}
