using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace MVC5.ViewModel.Account
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "وارد کردن ایمیل ضروریست")]
        [EmailAddress(ErrorMessage = "ایمیل را به شکل صحیح وارد کنید")]
        [DisplayName("ایمیل")]
        [Remote("IsEmailExist", "Account","",ErrorMessage = "این ایمیل قبلا در سیستم ثبت شده است", HttpMethod = "POST")]
        public string Email { get; set; }

        [Required(ErrorMessage = "وارد کردن کلمه عبور ضروریست")]
        [StringLength(100, ErrorMessage = "کلمه عبور نباید کمتر از 6 حرف و بیتشر از 100 حرف باشد", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [DisplayName("کلمه عبور")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [DisplayName("تکرار کلمه عبور")]
        [System.ComponentModel.DataAnnotations.Compare("Password", ErrorMessage = "کلمات عبور وارد شده مطابقت ندارند")]
        public string ConfirmPassword { get; set; }

        [DisplayName("شماره همراه")]
        [Required(ErrorMessage = "وارد کردن شماره همراه ضروریست")]
        [Remote("IsPhoneNumberExist", "Account", "", ErrorMessage = "این شماره همراه قبلا ثبت شده است", HttpMethod = "POST")]
        [RegularExpression("09(1[0-9]|3[1-9]|2[1-9])-?[0-9]{3}-?[0-9]{4}", ErrorMessage = "لطفا شماره همراه خود را به شکل صحیح وارد کنید")]
        public string PhoneNumber { get; set; }
    }
}