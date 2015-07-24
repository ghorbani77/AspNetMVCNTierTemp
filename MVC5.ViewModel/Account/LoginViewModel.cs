using System.ComponentModel.DataAnnotations;

namespace MVC5.ViewModel.Account
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "وارد کردن نام کاربری ضروریست")]
        [Display(Name = "نام کاربری")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "وارد کردن کلمه عبور ضروریست")]
        [DataType(DataType.Password)]
        [Display(Name = "کلمه عبور")]
        public string Password { get; set; }

        [Display(Name = "مرا به خاطر بسپار")]
        public bool RememberMe { get; set; }
    }
}