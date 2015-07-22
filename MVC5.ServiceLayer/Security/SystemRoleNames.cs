using System.Collections.Generic;
using MVC5.DomainClasses.Entities;
using MVC5.ViewModel.AdminArea.Security;

namespace MVC5.ServiceLayer.Security
{
    public static class SystemRoleNames
    {
        public static IEnumerable<DefaultRoleRecord> GetStandardRoles()
        {
            return new List<DefaultRoleRecord>
            {
                SuperAdministrators,
                Administrators,
                BlogModerators,
                Registered
            };
        } 
        public static DefaultRoleRecord SuperAdministrators = new DefaultRoleRecord
        {
            Name = "SuperAdmins",
            Description = "مدیران ارشد"
        };

        public static DefaultRoleRecord Administrators = new DefaultRoleRecord
        {
            Name = "Administrators",
            Description = "مدیران"
        };
        public static DefaultRoleRecord BlogModerators = new DefaultRoleRecord
        {
            Name = "BlogModerators",
            Description = "مدیران وبلاگ"
        };

        public static DefaultRoleRecord Registered = new DefaultRoleRecord
        {
            Name = "Registered",
            Description = "کاربران عضو شده"
        };

    }
}
