using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper.QueryableExtensions;
using EntityFramework.Extensions;
using Microsoft.AspNet.Identity;
using MVC5.DataLayer.Context;
using MVC5.DomainClasses.Entities;
using MVC5.ServiceLayer.Contracts;
using MVC5.ServiceLayer.Security;
using MVC5.ViewModel.AdminArea.Role;
using RefactorThis.GraphDiff;
using AutoMapper;

namespace MVC5.ServiceLayer.EFServiecs
{
    public class ApplicationRoleManager : RoleManager<ApplicationRole, int>, IApplicationRoleManager
    {
        #region Fields
        private readonly IMappingEngine _mappingEngine;
        private readonly IRoleStore<ApplicationRole, int> _roleStore;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IPermissionService _permissionService;
        private readonly IDbSet<ApplicationRole> _roles;
        #endregion

        #region Constructor
        public ApplicationRoleManager( IMappingEngine mappingEngine, IPermissionService permissionService, IUnitOfWork unitOfWork, IRoleStore<ApplicationRole, int> roleStore)
            : base(roleStore)
        {
            _roleStore = roleStore;
            _unitOfWork = unitOfWork;
            _roles = _unitOfWork.Set<ApplicationRole>();
            _permissionService = permissionService;
            _mappingEngine = mappingEngine;
            AutoCommitEnabled = true;
        }
        #endregion

        #region FindRoleByName
        public ApplicationRole FindRoleByName(string roleName)
        {
            return this.FindByName(roleName); // RoleManagerExtensions
        }
        #endregion

        #region CreateRole
        public IdentityResult CreateRole(ApplicationRole role)
        {
            return this.Create(role); // RoleManagerExtensions
        }
        #endregion

        #region GetUsersOfRole
        public IList<ApplicationUserRole> GetUsersOfRole(string roleName)
        {
            return this.Roles.Where(role => role.Name == roleName)
                             .SelectMany(role => role.Users)
                             .ToList();
        }
        #endregion

        #region GetApplicationUsersInRole
        public IList<ApplicationUser> GetApplicationUsersInRole(string roleName)
        {
            var roleUserIdsQuery = from role in this.Roles
                                   where role.Name == roleName
                                   from user in role.Users
                                   select user.UserId;

            return null; // _userManager.GetUsersWithRoleIds(roleUserIdsQuery.ToArray());
        }
        #endregion

        #region FindUserRoles
        public IList<ApplicationRole> FindUserRoles(int userId)
        {
            var userRolesQuery = from role in this.Roles
                                 from user in role.Users
                                 where user.UserId == userId
                                 select role;

            return userRolesQuery.OrderBy(x => x.Name).ToList();
        }
        #endregion

        #region GetRolesForUser
        public string[] GetRolesForUser(int userId)
        {
            var roles = FindUserRoles(userId);
            if (roles == null || !roles.Any())
            {
                return new string[] { };
            }

            return roles.Select(x => x.Name).ToArray();
        }

       
        #endregion

        #region IsUserInRole
        public bool IsUserInRole(int userId, string roleName)
        {
            var userRolesQuery = from role in this.Roles
                                 where role.Name == roleName
                                 from user in role.Users
                                 where user.UserId == userId
                                 select role;
            var userRole = userRolesQuery.FirstOrDefault();
            return userRole != null;
        }
     
        #endregion

        #region GetAllApplicationRolesAsync
        public async Task<IList<ApplicationRole>> GetAllApplicationRolesAsync()
        {
            return await this.Roles.ToListAsync();
        }

        #endregion

        #region GetPermissionsOfUser
        public async Task<IList<string>> GetPermissionsOfUser(int userId)
        {
            var rolesOfUser = GetRolesForUser(userId);
            var permissions = new List<string>();

            foreach (var role in rolesOfUser)
            {
                var roleName = role;
                var permissionsOfRole =
                    await
                        Roles.Where(a => a.Name == roleName)
                            .SelectMany(a => a.Permissions)
                            .Select(a => a.Name)
                            .ToListAsync();
                permissions.AddRange(permissionsOfRole);
            }

            return permissions;
        }
        #endregion

        #region GetPermissionsOfRole
        public IList<string> GetPermissionsOfRole(string roleName)
        {
            return
                 Roles.Where(a => a.Name == roleName)
                    .SelectMany(a => a.Permissions)
                    .Select(a => a.Name)
                    .ToList();
        }
        #endregion

        #region SetPermissionsToRole
        public void SetPermissionsToRole(int? roleId, string name, IEnumerable<ApplicationPermission> permissions)
        {

            var role = roleId != null
                    ? _roles.Where(a => a.Id == roleId.Value).AsNoTracking().Include(a => a.Permissions).FirstOrDefault()
                    : _roles.Where(a => a.Name == name).AsNoTracking().Include(a => a.Permissions).FirstOrDefault();

            if (role == null) return;
            role.Permissions.Clear();

            foreach (var permission in permissions)
            {
                role.Permissions.Add(permission);
            }
            _unitOfWork.Update(role, a => a.AssociatedCollection(b => b.Permissions));
            _unitOfWork.SaveChanges();
        }
        #endregion

        #region SeedDatabase
        /// <summary>
        /// for instal permissions with roles
        /// </summary>
        public void SeedDatabase()
        {
            if (_roles.Any(a => a.Name == SystemRoleNames.SuperAdministrators.Name)) return;

            _unitOfWork.ValidateOnSaveEnabled = false;
            _unitOfWork.ProxyCreationEnabled = false;

            var systemRoleNames = SystemRoleNames.GetStandardRoles();
            foreach (var role in systemRoleNames)
            {
                var systemRole = _roles.AsNoTracking().FirstOrDefault(a => a.Name == role.Name) ?? new ApplicationRole
                {
                    Description = role.Description,
                    Name = role.Name,
                    IsActive = true,
                    IsDefaultForRegister = role.Name == SystemRoleNames.Registered.Name,
                    IsSystemRole = true
                };

                var defaultPermissionsRecord = SystemPermissionsProvider.GetInvariatSystemPermissionsWithRole()
                    .FirstOrDefault(a => a.SystemRoleName == role.Name);

                systemRole.Permissions = new List<ApplicationPermission>();

                if (defaultPermissionsRecord != null)
                {
                    var actualPermissions = _permissionService.GetActualPermissions(
                   defaultPermissionsRecord.Permissions);

                    foreach (var permission in actualPermissions)
                    {
                        systemRole.Permissions.Add(permission);
                    }
                }

                try
                {
                    _unitOfWork.Update(systemRole, a => a.OwnedCollection(b => b.Permissions));
                    _unitOfWork.SaveChanges();
                }
                finally
                {
                    _unitOfWork.ValidateOnSaveEnabled = true;
                    _unitOfWork.ProxyCreationEnabled = true;
                }
            }


        }

        #endregion

        #region DeleteAll
        public async Task RemoteAll()
        {
            await Roles.DeleteAsync();
        }
        #endregion

        #region GetList


        public async Task<IEnumerable<ViewModel.AdminArea.Role.RoleViewModel>> GetList()
        {
            return await _roles.Project(_mappingEngine).To<RoleViewModel>().ToListAsync();
        }
        #endregion

        #region AddRoleWithPermissions
        public void AddRoleWithPermissions(AddRoleViewModel viewModel, params int[] ids)
        {
            var role = _mappingEngine.Map<ApplicationRole>(viewModel);
            this.Create(role);

            var permissoinsIdsToAddeRole = _permissionService.GetActualPermissions(ids);
            SetPermissionsToRole(role.Id, null, permissoinsIdsToAddeRole);
        }
        #endregion

        #region GetRoleByPermissions
        public Task<EditRoleViewModel> GetRoleByPermissions(int id)
        {
            var viewModel = _roles.AsNoTracking()
                    .Project(_mappingEngine)
                    .To<EditRoleViewModel>()
                    .FirstOrDefaultAsync(a => a.Id == id);

            return viewModel;

        }
        #endregion

        #region EditRoleWithPermissions
        public void EditRoleWithPermissions(EditRoleViewModel viewModel, params int[] ids)
        {
            var role = _mappingEngine.Map<ApplicationRole>(viewModel);
            _unitOfWork.MarkAsChanged(role);

            var permissoinsIdsToAddeRole = _permissionService.GetActualPermissions(ids);
            SetPermissionsToRole(role.Id, null, permissoinsIdsToAddeRole);
        }
        #endregion

        #region AddRange
        public void AddRange(IEnumerable<ApplicationRole> roles)
        {
            _unitOfWork.AddThisRange(roles);
        }
        #endregion

        #region AnyAsync
        public Task<bool> AnyAsync()
        {
            return _roles.AnyAsync();
        }
        public bool Any()
        {
            return _roles.Any();
        }
        #endregion

        #region AutoCommitEnabled
        public bool AutoCommitEnabled { get; set; }
        #endregion

    }
}
