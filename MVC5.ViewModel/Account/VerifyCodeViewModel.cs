using System.ComponentModel.DataAnnotations;

namespace MVC5.ViewModel.Account
{
    public class VerifyCodeViewModel
    {
        [Required(ErrorMessage = "وارد کردن سیستم مهیا کننده ضروریست")]
        public string Provider { get; set; }

        [Required(ErrorMessage = "وارد کردن کد شناسایی ضروریست")]
        [Display(Name = "کدشناسایی")]
        public string Code { get; set; }
        public string ReturnUrl { get; set; }

        [Display(Name = "این مرورگر را به خاطر بسپار")]
        public bool RememberBrowser { get; set; }
    }
}