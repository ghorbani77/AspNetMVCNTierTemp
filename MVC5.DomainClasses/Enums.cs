using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MVC5.DomainClasses
{

    #region Users
    /// <summary>
    /// Represents the customer name fortatting enumeration
    /// </summary>
    public enum UserShowNameFormat : int
    {
        /// <summary>
        /// Show emails
        /// </summary>
        [Display(Name = "نمایش ایمیل")]
        ShowEmail = 1,
        /// <summary>
        /// Show usernames
        /// </summary>
        [Display(Name = "نایش نام کاربری")]
        ShowUsername = 2,
        /// <summary>
        /// Show first name
        /// </summary>
        [Display(Name = "نمایش نام")]
        ShowName = 3
    }

    public enum UserRegistrationType : int
    {
        /// <summary>
        /// Standard account creation
        /// </summary>
        [Display(Name = "استاندارد")]
        Standard = 1,
        /// <summary>
        /// Email validation is required after registration
        /// </summary>
        [Display(Name = "فعال سازی با ایمیل")]
        EmailValidation = 2,
        /// <summary>
        /// A customer should be approved by administrator
        /// </summary>
        [Display(Name = "با تآیید مدیر")]
        AdminApproval = 3,
        /// <summary>
        /// Registration is disabled
        /// </summary>
        [Display(Name = "غیر فعال")]
        Disabled = 4,
    }

    #endregion //Users

    public enum CommentPermissionType : int
    {
        [Display(Name = "با تأیید مدیریت")]
        WithApprove = 1,
        [Display(Name = "بلامانع است")]
        WithOutApporove = 2,
        [Display(Name = "ممنوع است")]
        Forbidden = 3
    }
}
