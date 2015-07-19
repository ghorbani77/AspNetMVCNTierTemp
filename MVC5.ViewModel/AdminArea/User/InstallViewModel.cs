using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace MVC5.ViewModel.AdminArea.User
{
    public class InstallViewModel
    {
        [Required(ErrorMessage = "وارد کردن ایمیل ضروریست")]
        [EmailAddress(ErrorMessage = "ایمیل را به شکل صحیح وارد کنید")]
        [DisplayName("ایمیل")]
        [Remote("IsEmailExist", "Account", "", ErrorMessage = "این ایمیل قبلا در سیستم ثبت شده است", HttpMethod = "POST")]
        public string Email { get; set; }

        [Required(ErrorMessage = "وارد کردن کلمه عبور ضروریست")]
        [StringLength(100, ErrorMessage = "کلمه عبور نباید کمتر از 6 حرف و بیتشر از 100 حرف باشد", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [DisplayName("کلمه عبور")]
        public string Password { get; set; }

        [Required(ErrorMessage = "وارد کردن نام کاربری ضروریست")]
        [DisplayName("نام کاربری")]
        [Remote("IsUserNameExist", "Account", "", ErrorMessage = "این ایمیل قبلا در سیستم ثبت شده است", HttpMethod = "POST")]
        public string UserName { get; set; }
    }
}
