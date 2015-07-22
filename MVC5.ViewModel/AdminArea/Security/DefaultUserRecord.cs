using System;

namespace MVC5.ViewModel.AdminArea.Security
{
    public class DefaultUserRecord
    {
        public bool IsSystemAccount { get; set; }
        public DateTime RegisterDate { get; set; }
        public bool CanUploadFile { get; set; }
        public bool CanChangeProfilePicture { get; set; }
        public bool CanModifyFirsAndLastName { get; set; }
        public string Email { get; set; }
        public bool EmailConfirmed { get; set; }
        public bool LockoutEnabled { get; set; }
        public string PasswordHash { get; set; }
        public bool PhoneNumberConfirmed { get; set; }
        public string UserName { get; set; }
        public string SystemRoleName { get; set; }

    }
}
