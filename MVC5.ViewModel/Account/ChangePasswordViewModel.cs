using System.ComponentModel.DataAnnotations;

namespace MVC5.ViewModel.Account
{
    public class ChangePasswordViewModel
    {
        [Required(ErrorMessage = "وارد کردن کلمه عبور فعلی ضروریست")]
        [DataType(DataType.Password)]
        [Display(Name = "کلمه عبور فعلی")]
        public string OldPassword { get; set; }

        [Required(ErrorMessage = "وارد کردن کلمه عبور جدید ضروریست")]

        [StringLength(100, ErrorMessage = "کلمه عبور نباید کمتر از 6 حرف و بیشتر از 100 حرف باشد", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "کلمه عبور جدید")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "تکرار کلمه عبور جدید")]
        [Compare("NewPassword", ErrorMessage = "کلمات عبور باهم مطابقت ندارند")]
        public string ConfirmPassword { get; set; }
    }
}