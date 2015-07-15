using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web;
using System.Web.Mvc;

namespace MVC5.ViewModel.AdminArea.User
{
    public class UserViewModel
    {
        public int  Id { get; set; }
        [DisplayName("ایمیل")]
        public string Email { get; set; }
        [DisplayName("نام کاربری")]
        public string UserName { get; set; }
        [DisplayName("قفل")]
        public bool IsBanned { get; set; }
        [DisplayName("کاربر سیستمی")]
        public bool IsSystemAccount { get; set; }
        [DisplayName("نظر مدیر")]
        public string AdminComment { get; set; }

    }
}
