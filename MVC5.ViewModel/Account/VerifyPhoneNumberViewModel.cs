using System.ComponentModel.DataAnnotations;

namespace MVC5.ViewModel.Account
{
    public class VerifyPhoneNumberViewModel
    {
        [Required(ErrorMessage = "وارد کردن کد شناسایی ضروریست")]
        [Display(Name = "کد شناسایی")]
        public string Code { get; set; }

        [Required(ErrorMessage = "وارد کردن شماره همراه ضروریست")]
        [Phone]
        [Display(Name = "شماره همراه")]
        public string PhoneNumber { get; set; }
    }
}