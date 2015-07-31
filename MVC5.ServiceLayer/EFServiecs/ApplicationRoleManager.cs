
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using AutoMapper.QueryableExtensions;
using EFSecondLevelCache;
using EntityFramework.Extensions;
using Microsoft.AspNet.Identity;
using MVC5.DataLayer.Context;
using MVC5.DomainClasses.Entities;
using MVC5.ServiceLayer.Contracts;
using MVC5.ServiceLayer.Security;
using MVC5.Utility.EF.Filters;
using MVC5.ViewModel.AdminArea.Role;
using RefactorThis.GraphDiff;
using AutoMapper;

namespace MVC5.ServiceLayer.EFServiecs
{
    public class ApplicationRoleManager : RoleManager<ApplicationRole, int>, IApplicationRoleManager
    {
        #region Fields
        private readonly IMappingEngine _mappingEngine;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IPermissionService _permissionService;
        private readonly IDbSet<ApplicationRole> _roles;
        #endregion

        #region Constructor
        public ApplicationRoleManager(IMappingEngine mappingEngine, IPermissionService permissionService, IUnitOfWork unitOfWork, IRoleStore<ApplicationRole, int> roleStore)
            : base(roleStore)
        {
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
            return Roles.Where(role => role.Name == roleName)
                             .SelectMany(role => role.Users)
                             .ToList();
        }
        #endregion

        #region GetApplicationUsersInRole
        public IList<ApplicationUser> GetApplicationUsersInRole(string roleName)
        {
            //var roleUserIdsQuery = from role in Roles
            //                       where role.Name == roleName
            //                       from user in role.Users
            //                       select user.UserId;

            return null; //_userManager.GetUsersWithRoleIds(roleUserIdsQuery.ToArray());
        }
        #endregion

        #region FindUserRoles
        public IList<string> FindUserRoles(int userId)
        {
            var userRolesQuery = from role in Roles
                                 from user in role.Users
                                 where user.UserId == userId
                                 select role;

            return userRolesQuery.OrderBy(x => x.Name).Select(a => a.Name).Cacheable().ToList();
        }

        public IList<int> FindUserRoleIds(int userId)
        {
            var userRolesQuery = from role in Roles
                                 from user in role.Users
                                 where user.UserId == userId
                                 select role;

            return userRolesQuery.Select(a => a.Id).Cacheable().ToList();
        }

        public async Task<IList<int>> FindUserRoleIdsAsync(int userId)
        {
            var userRolesQuery = from role in Roles
                                 from user in role.Users
                                 where user.UserId == userId
                                 select role;

            return await userRolesQuery.Select(a => a.Id).Cacheable().ToListAsync();
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

            return roles.ToArray();
        }
     
        #endregion

        #region IsUserInRole
        public bool IsUserInRole(int userId, string roleName)
        {
            var userRolesQuery = from role in Roles
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
            return await Roles.ToListAsync();
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
        public void SetPermissionsToRole(ApplicationRole role, IEnumerable<ApplicationPermission> permissions)
        {
            role.Permissions=new Collection<ApplicationPermission>();
            foreach (var permission in permissions)
            {
                role.Permissions.Add(permission);
            }
            if (role.IsDefaultForRegister)
                ChangeDefaultRegisterRole(role.Id);
            _unitOfWork.Update(role, a => a.AssociatedCollection(b => b.Permissions));
            _unitOfWork.SaveChanges();
        }
        #endregion

        #region SeedDatabase
        /// <summary>
        /// for instal permissions with roles
        /// </summary>
        public void SeedDatabase(IEnumerable<ApplicationPermission> permissions)
        {
            var applicationPermissions = permissions as IList<ApplicationPermission> ?? permissions.ToList();
            _permissionService.SeedDatabase(applicationPermissions);

            var superAdministrators = new ApplicationRole
            {
                Name = SystemRoleNames.SuperAdministrators,
                IsActive = true,
                IsSystemRole = true,
                Description = "مدیران سیستمی برنامه",
                Permissions = new Collection<ApplicationPermission>()
            };

            _roles.AddOrUpdate(a => a.Name, superAdministrators);
            _unitOfWork.SaveChanges();
            _unitOfWork.MarkAsDetached(superAdministrators);

            foreach (var permission in applicationPermissions)
            {
                superAdministrators.Permissions.Add(permission);
            }
            _unitOfWork.Update(superAdministrators, a => a.AssociatedCollection(c => c.Permissions));
            _unitOfWork.SaveChanges();
        }

        #endregion

        #region DeleteAll
        public async Task RemoteAll()
        {
            await Roles.DeleteAsync();
        }
        #endregion

        #region GetList


        public async Task<IEnumerable<RoleViewModel>> GetList()
        {
            return await _roles.Project(_mappingEngine).To<RoleViewModel>().ToListAsync();
        }
        #endregion

        #region AddRoleWithPermissions
        public void AddRoleWithPermissions(AddRoleViewModel viewModel, params int[] ids)
        {
            var role = _mappingEngine.Map<ApplicationRole>(viewModel);
            var permissoinsIdsToAddeRole = _permissionService.GetActualPermissions(ids);

            SetPermissionsToRole(role, permissoinsIdsToAddeRole);
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
            var permissoinsIdsToAddeRole = _permissionService.GetActualPermissions(ids);
            SetPermissionsToRole(role, permissoinsIdsToAddeRole);
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

        #region ChechForExisByName
        public bool ChechForExisByName(string name, int? id)
        {
            return id == null ? _roles.Any(a => a.Name.ToLower() == name)
                : _roles.Any(a => a.Name.ToLower() == name && id.Value != a.Id);
        }
        #endregion

        #region GetPageList
        public IEnumerable<RoleViewModel> GetPageList(out int total, string term, int page, int count = 10)
        {
            var roles = _roles.AsNoTracking().OrderBy(a => a.Id).AsQueryable();
            if (!string.IsNullOrEmpty(term))
                roles = roles.Where(a => a.Name.Contains(term));
            total = roles.FutureCount();
            var result =
                roles.Skip((page - 1) * count).Take(count).Project(_mappingEngine).To<RoleViewModel>().Future().ToList();

            return result;
        }
        #endregion

        #region RemoveById
        public async Task RemoveById(int id)
        {
            await _roles.Where(a => a.Id == id).DeleteAsync();
        }

        #endregion

        #region CheckRoleIsSystemRoleAsync
        public async Task<bool> CheckRoleIsSystemRoleAsync(int id)
        {
            return await _roles.AnyAsync(a => a.Id == id && a.IsSystemRole);
        }
        #endregion

        #region SetRoleAsRegistrationDefaultRoleAsync
        public async Task SetRoleAsRegistrationDefaultRoleAsync(int id)
        {
            _unitOfWork.EnableFiltering("IsDefaultRegisteRole");
            var role = await _roles.FirstOrDefaultAsync();
            role.IsActive = false;
            _unitOfWork.DisableFiltering("IsDefaultRegisteRole");
            await _roles.Where(a => a.Id == id).UpdateAsync(a => new ApplicationRole { IsDefaultForRegister = true });
        }

        #endregion

        #region GetAllAsSelectList
        public async Task<IEnumerable<SelectListItem>> GetAllAsSelectList()
        {
            _unitOfWork.EnableFiltering(RoleFilters.ActiveList);
            var roles = await _roles.AsNoTracking().Project(_mappingEngine).To<SelectListItem>().Cacheable().ToListAsync();
            return roles;
        }
        #endregion

        public Task<string> GetDefaultRoleForRegister()
        {
            return _roles.Where(a => a.IsDefaultForRegister).Select(a => a.Name).FirstOrDefaultAsync();
        }


        public void ChangeDefaultRegisterRole(int id)
        {
            _roles.Where(a => a.Id != id).Update(a => new ApplicationRole {IsDefaultForRegister = false});
        }

    }
}
