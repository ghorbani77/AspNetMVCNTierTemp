using System.ComponentModel.DataAnnotations;

namespace MVC5.ViewModel.Account
{
    public class SetPasswordViewModel
    {
        [Required(ErrorMessage = "وارد کردن کلمه عبور ضروریست")]
        [StringLength(100, ErrorMessage = "کلمه عبور نباید کمتر از 6 حرف و بیتشر از 100 حرف باشد", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "کلمه عبور")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "تکرار کلمه عبور")]
        [Compare("Password", ErrorMessage = "کلمات عبور وارد شده مطابقت ندارند")]
        public string ConfirmPassword { get; set; }
    }
}