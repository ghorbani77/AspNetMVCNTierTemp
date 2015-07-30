using MVC5.DataLayer.Context;
using MVC5.DomainClasses;

namespace MVC5.ServiceLayer.Settings
{
    public class UserSettings : SettingsBase
    {
        public UserSettings(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
            UsernamesEnabled = true;
            UserRegistrationType = UserRegistrationType.Standard;
            AvatarMaximumSizeBytes = 20000;
            DefaultAvatarEnabled = true;
            UserNameFormat = UserShowNameFormat.ShowName;
            DateOfBirthEnabled = true;
            NewsletterEnabled = true;
        }

        /// <summary>
        /// Gets or sets a value indicating whether usernames are used instead of emails
        /// </summary>
        public bool UsernamesEnabled { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether users are allowed to change their usernames
        /// </summary>
        public bool AllowUsersToChangeUsername { get; set; }

        /// <summary>
        /// User registration type
        /// </summary>
        public UserRegistrationType UserRegistrationType { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether Users are allowed to upload avatars.
        /// </summary>
        public bool AllowUsersToUploadAvatars { get; set; }

        /// <summary>
        /// Gets or sets a maximum avatar size (in bytes)
        /// </summary>
        public int AvatarMaximumSizeBytes { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether to display default user avatar.
        /// </summary>
        public bool DefaultAvatarEnabled { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to show Users join date
        /// </summary>
        public bool ShowUsersJoinDate { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether Users are allowed to view profiles of other Users
        /// </summary>
        public bool AllowViewingProfiles { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether 'New User' notification message should be sent to a store owner
        /// </summary>
        public bool NotifyNewUserRegistration { get; set; }

        /// <summary>
        /// User name formatting
        /// </summary>
        public UserShowNameFormat UserNameFormat { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether 'Newsletter' form field is enabled
        /// </summary>
        public bool NewsletterEnabled { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to hide newsletter box
        /// </summary>
        public bool HideNewsletterBlock { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether 'Date of Birth' is enabled
        /// </summary>
        public bool DateOfBirthEnabled { get; set; }

    }
}
