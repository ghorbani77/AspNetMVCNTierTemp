using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC5.ServiceLayer.Security
{
    public static class SystemPermissionNames
    {
        public const string CanEditRole = "CanEditRole";
        public const string CanDeleteRole = "CanDeleteRole";
        public const string CanViewRolesList = "CanViewRolesList";
        public const string CanCreateRole = "CanCreateRole";
        public const string CanSetDefaultRoleForRegister = "CanSetDefaultRoleForRegister";
        public const string CanEditUser = "CanEditUser";
        public const string CanCreateUser = "CanCreateUser";
        public const string CanDeleteUser = "CanDeleteUser";
        public const string CanSoftDeleteUser = "CanSoftDeleteUser";
        public const string CanViewUsersList = "CanViewUsersList";
        public const string CanEditUsersSetting = "CanEditUsersSetting";
        public const string CanAccessImages = "CanAccessImages";
        public const string CanViewAdminPanel = "CanViewAdminPanel";
        public const string CanAccessUsersFiles = "CanAccessUsersFiles";
        public const string CanAccessUsersAvatar = "CanAccessUsersAvatar";

    }
}
