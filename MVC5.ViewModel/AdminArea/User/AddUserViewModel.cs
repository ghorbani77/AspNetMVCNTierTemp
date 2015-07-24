using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web;
using System.Web.Mvc;
using MVC5.DomainClasses;

namespace MVC5.ViewModel.AdminArea.User
{
    public class AddUserViewModel
    {
        [DisplayName("ایمیل")]
        [EmailAddress(ErrorMessage = "لطفا ایمیل را صحیح وارد کنید")]
        [Required(ErrorMessage = "لطفا ایمیل را وارد کنید")]
        [MaxLength(50, ErrorMessage = "تعداد حروف ایمیل غیر مجاز است")]
        [Remote("EmailExist", "User", "Administrator", ErrorMessage = "این ایمیل قبلا در سیستم ثبت شده است", HttpMethod = "POST")]
        public string Email { get; set; }
        [DisplayName("کلمه عبور")]
        [Required(ErrorMessage = "لطفا کلمه عبور را وارد کنید")]
        [MaxLength(128, ErrorMessage = "تعداد حروف کلمه عبور غیر مجاز است")]
        public string Password { get; set; }

        [RegularExpression("09(1[0-9]|3[1-9]|2[1-9])-?[0-9]{3}-?[0-9]{4}",
            ErrorMessage = "لطفا شماره همراه  را به شکل صحیح وارد کنید")]
        [DisplayName("شماره همراه")]
        [Remote("PhoneNumberExist", "User", "Administrator", ErrorMessage = "این شماره  قبلا در سیستم ثبت شده است", HttpMethod = "POST")]
        public string PhoneNumber { get; set; }

        [DisplayName("نام کاربری")]
        [Required(ErrorMessage = "لطفا نام کاربری را وارد کنید")]
        [MaxLength(50, ErrorMessage = "تعداد حروف نام کاربری غیر مجاز است")]
        [Remote("UserNameExist", "User", "Administrator", ErrorMessage = "این نام کاربری قبلا در سیستم ثبت شده است", HttpMethod = "POST")]
        // [WhiteSpace("validate for prevent white space")]
        public string UserName { get; set; }
        [DisplayName("قفل شود")]
        public bool IsBanned { get; set; }
        [DisplayName("نام")]
        [MaxLength(50, ErrorMessage = "تعداد حروف نام  غیر مجاز است")]
        [Required(ErrorMessage = "لطفا نام را وارد کنید")]
        [Remote("FirstNameExist", "User", "Administrator", ErrorMessage = "این نام قبلا در سیستم ثبت شده است", HttpMethod = "POST")]
        public string FirstName { get; set; }
        [DisplayName("نام خانوادگی")]
        [MaxLength(50, ErrorMessage = "تعداد حروف نام خانوادگی  غیر مجاز است")]
        [Required(ErrorMessage = "لطفا نام خانوادگی را وارد کنید")]
        [Remote("LastNameExist", "User", "Administrator", ErrorMessage = "این نام خانوادگی قبلا در سیستم ثبت شده است", HttpMethod = "POST")]
        public string LastName { get; set; }
       
        [DisplayName("نظر مدیر")]
        [MaxLength(1024, ErrorMessage = "تعداد حروف نظر مدیر غیر مجاز است")]
        public string AdministratorComment { get; set; }
        public HttpPostedFileBase Avatar { get; set; }
        public string AvatarPath { get; set; }
        [DisplayName("تاریخ تولد")]
        public string BirthDay { get; set; }
        [DisplayName(" آی دی گوگل پلاس")]
        [MaxLength(20, ErrorMessage = "تعداد کاراکتر های آی دی گوگل پلاس غیر مجاز است")]
        [Remote("GooglePlusIdExist", "User", "Administrator", ErrorMessage = "این آدرس قبلا در سیستم ثبت شده است", HttpMethod = "POST")]
        public string GooglePlusId { get; set; }
        [DisplayName("آی دی فیسبوک")]
        [MaxLength(20, ErrorMessage = "تعداد کاراکتر های آی دی فیسبوک غیر مجاز است")]
        [Remote("FaceBookIdExist", "User", "Administrator", ErrorMessage = "این آدرس قبلا در سیستم ثبت شده است", HttpMethod = "POST")]
        public string FaceBookId { get; set; }
        [DisplayName("تأییدیه ایمیل")]
        public bool EmailConfirmed { get; set; }
        [DisplayName("دسترسی برای نظرات")]
        public CommentPermissionType CommentPermissionType { get; set; }
        [DisplayName("دسترسی برای آپلود فایل")]
        public bool CanUploadFile { get; set; }
        [DisplayName("دسترسی برای تغییر آواتار")]
        public bool CanChangeProfilePicture { get; set; }
        [DisplayName("دسترسی برای تغییر نام-نام خانوادگی")]
        public bool CanModifyFirsAndLastName { get; set; }
        public int[] RoleIds { get; set; }
    }
}
