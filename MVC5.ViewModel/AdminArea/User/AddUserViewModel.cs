using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web;
using System.Web.Mvc;
using MVC5.DomainClasses;

namespace MVC5.ViewModel.AdminArea.User
{
    public class AddUserViewModel
    {
        [Required(ErrorMessage = "لطفا ایمیل خود را وارد کنید")]
        [EmailAddress(ErrorMessage = "ایمیل را به شکل صحیح وارد کنید")]
        [DisplayName("ایمیل")]
        [StringLength(450, ErrorMessage = "حداکثر طول ایمیل 450 حرف است")]
        [Remote("IsEmailExist", "User", "Administrator", ErrorMessage = "این ایمیل قبلا در سیستم ثبت شده است", HttpMethod = "POST")]
        public string Email { get; set; }

        [Required(ErrorMessage = "لطفا کلمه عبور را وارد کنید")]
        [StringLength(50, ErrorMessage = "کلمه عبور نباید کمتر از 5 حرف و بیتشر از 50 حرف باشد", MinimumLength = 5)]
        [DataType(DataType.Password)]
        [DisplayName("کلمه عبور")]
        [Remote("CheckPassword", "User", "Administrator", ErrorMessage = "این کلمه عبور به راحتی قابل تشخیص است", HttpMethod = "POST")]
        public string Password { get; set; }

        [Required(ErrorMessage = "لطفا نام کاربری را وارد کنید")]
        [DisplayName("نام کاربری")]
        [StringLength(450, ErrorMessage = "کلمه عبور نباید کمتر از 5 حرف و بیتشر از 450 حرف باشد", MinimumLength = 5)]
        [Remote("IsUserNameExist", "User", "Administrator", ErrorMessage = "این نام کاربری قبلا در سیستم ثبت شده است", HttpMethod = "POST")]
        [RegularExpression("^[a-zA-Z0-9_]*$", ErrorMessage = "لطفا فقط از حروف انگلیسی و اعدد استفاده کنید")]
        public string UserName { get; set; }
        [DisplayName("قفل شود")]

        public bool IsBanned { get; set; }
        [Required(ErrorMessage = "لطفا نام نمایشی خود را وارد کنید")]
        [DisplayName("نام نمایشی")]
        [StringLength(450, ErrorMessage = "نام نمایشی نباید کمتر از 5 حرف و بیتشر از 450 حرف باشد", MinimumLength = 5)]
        [Remote("IsNameForShowExist", "User", "Administrator", ErrorMessage = "این نام نمایشی قبلا در سیستم ثبت شده است", HttpMethod = "POST")]
        [RegularExpression(@"^[\u0600-\u06FF,\u0590-\u05FF,0-9\s]*$", ErrorMessage = "لطفا فقط ازاعداد و حروف  فارسی استفاده کنید")]
        public string NameForShow { get; set; }
       
        [DisplayName("نظر مدیر")]
        [MaxLength(1024, ErrorMessage = "تعداد حروف نظر مدیر غیر مجاز است")]
        public string AdministratorComment { get; set; }
        [DisplayName("تصویر پروفایل")]
        public string AvatarFileName { get; set; }
        [DisplayName(" آی دی گوگل پلاس")]
        [StringLength(50, ErrorMessage = " آی دی نباید  بیتشر از 50 حرف باشد")]
        [Remote("GooglePlusIdExist", "User", "Administrator", ErrorMessage = "این آی دی قبلا در سیستم ثبت شده است", HttpMethod = "POST")]
        public string GooglePlusId { get; set; }
        [DisplayName("آی دی فیسبوک")]
        [StringLength(50, ErrorMessage = " آی دی نباید  بیتشر از 50 حرف باشد")]
        [Remote("FaceBookIdExist", "User", "Administrator", ErrorMessage = "این آی دی قبلا در سیستم ثبت شده است", HttpMethod = "POST")]
        public string FaceBookId { get; set; }
        [DisplayName("تأییدیه ایمیل")]
        public bool EmailConfirmed { get; set; }
        [DisplayName("دسترسی برای نظرات")]
        public CommentPermissionType CommentPermission { get; set; }
        [DisplayName("دسترسی برای آپلود فایل")]
        public bool CanUploadFile { get; set; }
        [DisplayName("دسترسی برای تغییر آواتار")]
        public bool CanChangeProfilePicture { get; set; }
        [DisplayName("دسترسی برای تغییر نام-نام خانوادگی")]
        public bool CanModifyFirsAndLastName { get; set; }
        public int[] RoleIds { get; set; }
        public int[] PermissionIds { get; set; }
        public HttpPostedFileBase AvatarImage { get; set; }
    }
}
