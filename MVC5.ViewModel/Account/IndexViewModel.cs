using System.Collections.Generic;
using Microsoft.AspNet.Identity;

namespace MVC5.ViewModel.Account
{
    public class IndexViewModel
    {
        public bool HasPassword { get; set; }
        public IList<UserLoginInfo> Logins { get; set; }
    }
}