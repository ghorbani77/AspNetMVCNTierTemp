using System;
using System.ComponentModel;
using MVC5.DomainClasses;

namespace MVC5.ViewModel.AdminArea.User
{
    public class UserSearchViewModel
    {
        public UserSearchViewModel()
        {
            this.PageIndex = 1;
            this.PageSize = 10;
        }
        [DisplayName("نام کاربری")]
        public string SearchUserName { get; set; }
        [DisplayName("ایمیل")]
        public string SearchEmail { get; set; }
        [DisplayName("نام نمایشی")]
        public string SearchNameForShow { get; set; }
        public int[] RoleIds { get; set; }
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        [DisplayName("تأیید شده با ایمیل")]
        public bool SearchIsEmailConfirmed { get; set; }
        [DisplayName("کاربران غیر فعال")]
        public bool SearchIsBanned { get; set; }
        [DisplayName("کاربران حذف شده")]
        public bool SearchIsDeleted { get; set; }
        [DisplayName("کاربران سیستمی")]
        public bool SearchIsSystemAccount { get; set; }
        [DisplayName("تاریخ تولد")]
        public DateTime SearchRegisterDate { get; set; }
        [DisplayName("آی پی")]
        public string SearchIp { get; set; }
        [DisplayName("نوع دسترسی نظرات")]
        public CommentPermissionType SearchCommentPermission { get; set; }
        [DisplayName("کاربرانی با دسترسی آپلود فایل")]
        public bool SearchCanUploadFile { get; set; }
        [DisplayName("کاربرانی با دسترسی تغییر آواتار")]
        public bool SearchCanChangeProfilePicture { get; set; }
        [DisplayName("کاربرانی با دسترسی تغییر نام ")]
        public bool SearchCanModifyFirsAndLastName { get; set; }
    }
}
