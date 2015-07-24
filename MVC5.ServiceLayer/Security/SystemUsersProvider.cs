using System;
using System.Collections.Generic;
using Microsoft.AspNet.Identity;
using MVC5.ViewModel.AdminArea.Security;

namespace MVC5.ServiceLayer.Security
{
    public static class SystemUsersProvider
    {
        /// <summary>
        /// get invariat users for seed data
        /// </summary>
        /// <returns></returns>
        public static DefaultUserRecord GetStandardSystemUser =

            new DefaultUserRecord
            {
                SystemRoleName = SystemRoleNames.SuperAdministrators,
                UserName = "Admin",
                PasswordHash ="Admin1234@gmai.com",
                CanChangeProfilePicture = true,
                CanModifyFirsAndLastName = true,
                CanUploadFile = true,
                EmailConfirmed = true,
                IsSystemAccount = true,
                LockoutEnabled = false,
                PhoneNumberConfirmed = true,
                Email = "admin1234@gmai.com",
                RegisterDate = DateTime.Now
            };

        // and ...
    }


}
