using System.Collections.Generic;
using MVC5.DomainClasses.Entities;
using MVC5.ViewModel.AdminArea.Security;

namespace MVC5.ServiceLayer.Security
{
    public static class SystemRoleNames
    {
        public static List<string> GetStandardRoles()
        {
            return new List<string>
            {
                SuperAdministrators,
                BlogModerators,
                Registered
            };
        }

        public static string SuperAdministrators = "مدیران ارشد";

        public static string BlogModerators = "مدیران وبلاگ";

        public static string Registered = "کاربران عضو شده";


    }
}
