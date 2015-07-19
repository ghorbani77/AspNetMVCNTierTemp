using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVC5.DomainClasses.Entities;

namespace MVC5.ServiceLayer.Security
{
    public static class SystemRoleNames
    {
        public static ApplicationRole SuperAdministrators = new ApplicationRole
        {
            Name = "SuperAdmins",
            Descriptions = "مدیران ارشد",
            IsSystemRole = true,
            IsDefaultForRegister = false,
            IsActive = true
        };
        public static ApplicationRole Administrators = new ApplicationRole
        {
            Name = "Administrators",
            Descriptions = "مدیران",
            IsSystemRole = true,
            IsDefaultForRegister = false,
            IsActive = true
        };
        public static ApplicationRole BlogModerators = new ApplicationRole
        {
            Name = "BlogModerators",
            Descriptions = "مدیران وبلاگ",
            IsSystemRole = true,
            IsDefaultForRegister = false,
            IsActive = true
        };

        public static ApplicationRole Registered = new ApplicationRole
        {
            Name = "Registered",
            Descriptions = "کاربران عضو شده",
            IsSystemRole = true,
            IsDefaultForRegister = true,
            IsActive = true
        };

    }
}
