using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace MVC5.ViewModel.Account
{
    public class ChangePasswordViewModel
    {
        [Required(ErrorMessage = "لطفا کلمه عبور فعلی را وارد کنید")]
        [DataType(DataType.Password)]
        [Display(Name = "کلمه عبور فعلی")]
        public string OldPassword { get; set; }

        [Required(ErrorMessage = "لطفا کلمه عبور جدید را وارد کنید")]
        [StringLength(50, ErrorMessage = "کلمه عبور نباید کمتر از 5 حرف و بیتشر از 50 حرف باشد", MinimumLength = 5)]
        [DataType(DataType.Password)]
        [DisplayName("کلمه عبور جدید")]
        [Remote("CheckPassword", "Account", "", ErrorMessage = "این کلمه عبور به راحتی قابل تشخیص است", HttpMethod = "POST")]
        public string NewPassword { get; set; }

        [Required(ErrorMessage = "لطفا کلمه عبور جدید را وارد کنید")]
        [DataType(DataType.Password)]
        [Display(Name = "تکرار کلمه عبور")]
        [System.ComponentModel.DataAnnotations.Compare("NewPassword", ErrorMessage = "کلمات عبور باهم مطابقت ندارند")]
        public string ConfirmPassword { get; set; }
    }
}