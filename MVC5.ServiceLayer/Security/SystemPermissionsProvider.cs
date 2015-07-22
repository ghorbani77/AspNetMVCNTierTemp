using System.Collections.Generic;
using MVC5.DomainClasses.Entities;
using MVC5.ViewModel.AdminArea.Security;

namespace MVC5.ServiceLayer.Security
{
    public static class SystemPermissionsProvider
    {
        #region RoleControllerPermission



        public static ApplicationPermission CanSetRoleForRegister = new ApplicationPermission
        {
            Description = "تغییر گروه کاربری پیشفرض ثبت نام",
            ActionName = "SetRoleForRegister",
            ControllerName = "Role",
            AreaName = "Administrator",
            Name = "CanSetRoleForRegister",
            IsMenu = false
        };

        public static ApplicationPermission CanCreateRole = new ApplicationPermission
        {
            Description = "افزودن گروه کاربری",
            ActionName = "Create",
            ControllerName = "Role",
            AreaName = "Administrator",
            Name = "CanCreateRole",
            IsMenu = true
        };

        public static ApplicationPermission CanDeleteRole = new ApplicationPermission
        {
            Description = "حذف گروه کاربری",
            ActionName = "Delete",
            ControllerName = "Role",
            AreaName = "Administrator",
            Name = "CanDeleteRole",
            IsMenu = false
        };
        public static ApplicationPermission CanEditRole = new ApplicationPermission
        {
            Description = "ویرایش گروه کاربری",
            ActionName = "Edit",
            ControllerName = "Role",
            AreaName = "Administrator",
            Name = "CanEditRole",
            IsMenu = false
        };
        public static ApplicationPermission CanViewRoles = new ApplicationPermission
        {
            Description = "مشاهده گروه های کاربری",
            ActionName = "List",
            ControllerName = "Role",
            AreaName = "Administrator",
            Name = "CanViewRoles",
            IsMenu = true
        };
        #endregion

        #region UserControllerPermissions


        public static ApplicationPermission CanCreateUser = new ApplicationPermission
        {
            Description = "افزودن کاربر",
            ActionName = "Create",
            ControllerName = "User",
            AreaName = "Administrator",
            Name = "CanCreateUser",
            IsMenu = true
        };

        public static ApplicationPermission CanEditUser = new ApplicationPermission
        {
            Description = "ویرایش کاربر",
            ActionName = "Edit",
            ControllerName = "User",
            AreaName = "Administrator",
            Name = "CanEditUser",
            IsMenu = false
        };
        public static ApplicationPermission CanDeleteUser = new ApplicationPermission
        {
            Description = "حذف کاربر",
            ActionName = "Delete",
            ControllerName = "User",
            AreaName = "Administrator",
            Name = "CanDeleteUser",
            IsMenu = false
        };
        public static ApplicationPermission CanViewUsers = new ApplicationPermission
        {
            Description = "مشاهده کاربران",
            ActionName = "List",
            ControllerName = "User",
            AreaName = "Administrator",
            Name = "CanViewUsers",
            IsMenu = true
        };
        #endregion

        #region SettingControllerPermissions


        public static ApplicationPermission CanManageUserSetting = new ApplicationPermission
        {
            Description = "مدیریت تنظیمات کاربران",
            ActionName = "UserSetting",
            ControllerName = "Setting",
            AreaName = "Administrator",
            Name = "CanManageUserSetting",
            IsMenu = true
        };
        #endregion

        #region HomeControllerPermissions
        public static ApplicationPermission CanVisitAdminPanel = new ApplicationPermission
        {
            Description = "ورود به پنل مدیریت",
            ActionName = "Index",
            ControllerName = "Home",
            AreaName = "Administrator",
            Name = "CanVisitAdminPanel",
            IsMenu = true
        };
        #endregion

        #region AccountControllerPermissions

        public static ApplicationPermission CanLogOff = new ApplicationPermission
        {
            Description = "خروج از سایت حساب کاربری ",
            ActionName = "Panel",
            ControllerName = "Account",
            AreaName = "",
            Name = "CanLogOff",
            IsMenu = false
        };
        #endregion


        // and ...

        #region GetSystemPermissions
        /// <summary>
        /// get all permissions in system
        /// </summary>
        /// <returns></returns>
        public static List<ApplicationPermission> GetSystemPermissions()
        {
            return new List<ApplicationPermission>
            {
                CanViewRoles,
                CanCreateRole,
                CanEditRole,
                CanSetRoleForRegister,
                CanDeleteRole,
                CanCreateUser,
                CanViewUsers,
                CanEditUser,
                CanDeleteUser,
                CanManageUserSetting,
                CanVisitAdminPanel,
                CanLogOff,
            };
        }
        #endregion

        #region GetInvariatSystemPermissionsWithRole

        /// <summary>
        /// Get Default Permissions with own role for seed database
        /// </summary>
        /// <returns></returns>
        public static IList<DefaultPermissionsRecord> GetInvariatSystemPermissionsWithRole()
        {
            return new List<DefaultPermissionsRecord>
            {
                new DefaultPermissionsRecord
                {
                    SystemRoleName = SystemRoleNames.SuperAdministrators.Name,
                    Permissions = GetSystemPermissions()
                },
                new DefaultPermissionsRecord
                {
                    SystemRoleName = SystemRoleNames.Administrators.Name,
                    Permissions = new List<ApplicationPermission>
                    {
                        CanCreateRole,
                        CanViewUsers,
                        CanEditUser,
                        CanManageUserSetting,
                        CanVisitAdminPanel,
                        CanLogOff
                    }
                },
                new DefaultPermissionsRecord
                {
                    SystemRoleName = SystemRoleNames.BlogModerators.Name,
                    Permissions = new List<ApplicationPermission>
                    {
                        CanViewUsers,
                        CanVisitAdminPanel,
                        CanLogOff
                    }

                }
                ,
                new DefaultPermissionsRecord()
                {
                    SystemRoleName = SystemRoleNames.Registered.Name,
                    Permissions = new List<ApplicationPermission>
                    {
                        CanLogOff
                    }
                }

            };
        }
        #endregion
    }
}
