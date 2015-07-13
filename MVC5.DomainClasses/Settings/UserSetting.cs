namespace MVC5.DomainClasses.Settings
{
    public class UserSetting:ISettings
    {
        public UserSetting()
		{
			UsernamesEnabled = true;
			UserRegistrationType = UserRegistrationType.Standard;
			AvatarMaximumSizeBytes = 20000;
			DefaultAvatarEnabled = true;
			UserNameFormat = UserShowNameFormat.ShowFirstName;
			DateOfBirthEnabled = true;
			NewsletterEnabled = true;
		}
        /// <summary>
        /// get or sets a value indicating default role name for that user register
        /// </summary>
        public string RoleNameForDefaultRegiste { get; set; }
		/// <summary>
        /// Gets or sets a value indicating whether usernames are used instead of emails
        /// </summary>
        public bool UsernamesEnabled { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether users are allowed to change their usernames
        /// </summary>
        public bool AllowUsersToChangeUsernames { get; set; }

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
        /// Gets or sets a value indicating whether 'Gender' is enabled
        /// </summary>
        public bool GenderEnabled { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether 'Date of Birth' is enabled
        /// </summary>
        public bool DateOfBirthEnabled { get; set; }
       

        // codehint: sm-add (no ui, only db edit)
        public string PrefillLoginUsername { get; set; }
        public string PrefillLoginPwd { get; set; }
    }
}
