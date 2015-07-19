using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using EntityFramework.Extensions;
using Microsoft.AspNet.Identity;
using MVC5.DataLayer.Context;
using MVC5.DomainClasses.Entities;
using MVC5.ServiceLayer.Contracts;
using MVC5.ServiceLayer.Security;
using RefactorThis.GraphDiff;

namespace MVC5.ServiceLayer.EFServiecs
{
    public class ApplicationRoleManager : RoleManager<ApplicationRole, int>, IApplicationRoleManager
    {
        #region Fields
       // private readonly IApplicationUserManager _userManager;
        private readonly IRoleStore<ApplicationRole, int> _roleStore;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IPermissionService _permissionService;
        private readonly IDbSet<ApplicationRole> _roles;
        #endregion

        #region Constructor
        public ApplicationRoleManager(IApplicationUserManager userManager,IPermissionService permissionService, IRoleStore<ApplicationRole, int> roleStore, IUnitOfWork unitOfWork)
            : base(roleStore)
        {
            _roleStore = roleStore;
            _unitOfWork = unitOfWork;
            _roles = _unitOfWork.Set<ApplicationRole>();
            _permissionService = permissionService;
          //  _userManager = userManager;
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
                            .SelectMany(a => a.Permissionses)
                            .Select(a => a.Name)
                            .ToListAsync();
                permissions.AddRange(permissionsOfRole);
            }

            return permissions;
        }
        #endregion

        #region GetPermissionsOfRole
        public async Task<IList<string>> GetPermissionsOfRole(int roleId)
        {
            return
                await Roles.Where(a => a.Id == roleId)
                    .SelectMany(a => a.Permissionses)
                    .Select(a => a.Name)
                    .ToListAsync();
        }
        #endregion

        #region EditPermissionsToRole
        public async Task EditPermissionsToRole(int roleId, params int[] permissions)
        {
            var role = await _roles.Include(r => r.Permissionses).AsNoTracking().FirstOrDefaultAsync(r => r.Id == roleId);

            if (role != null)
            {
                role.Permissionses.Clear();
                var actualPermissions = await _permissionService.GetActualPermissions(permissions);

                foreach (var permission in actualPermissions)
                {
                    role.Permissionses.Add(permission);
                }

                _unitOfWork.Update(role, a => a.AssociatedCollection(b => b.Permissionses));
            }
        }
        #endregion

        #region SeedDatabase
        public async Task SeedDatabase(IEnumerable<ApplicationPermission> permissions)
        {
            var permissionIds = permissions.Select(a => a.Id).ToArray();
            _roles.Add(SystemRoleNames.SuperAdministrators);
            _roles.Add(SystemRoleNames.Administrators);
            _roles.Add(SystemRoleNames.BlogModerators);
            _roles.Add(SystemRoleNames.Registered);

            await _unitOfWork.SaveChangesAsync();

            await EditPermissionsToRole(SystemRoleNames.SuperAdministrators.Id, permissionIds);
            await _unitOfWork.SaveChangesAsync();
        }
        #endregion

        #region DeleteAll
        public void DeleteAll()
        {
            Roles.Delete();
        }
        #endregion

      
    }
}
