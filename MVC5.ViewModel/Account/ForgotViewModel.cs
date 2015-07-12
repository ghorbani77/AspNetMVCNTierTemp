using System.ComponentModel.DataAnnotations;

namespace MVC5.ViewModel.Account
{
    public class ForgotViewModel
    {
        [Required(ErrorMessage = "وارد کردن ایمیل ضروریست")]
        [Display(Name = "ایمیل")]
        public string Email { get; set; }
    }
}