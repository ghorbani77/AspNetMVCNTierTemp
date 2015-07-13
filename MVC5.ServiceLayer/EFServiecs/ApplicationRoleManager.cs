using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using MVC5.DataLayer.Context;
using MVC5.DomainClasses.Entities;
using MVC5.ServiceLayer.Contracts;
using RefactorThis.GraphDiff;

namespace MVC5.ServiceLayer.EFServiecs
{
    public class ApplicationRoleManager : RoleManager<ApplicationRole, int>, IApplicationRoleManager
    {
        #region Fields
        private readonly IDbSet<ApplicationUser> _users;
        private readonly IRoleStore<ApplicationRole, int> _roleStore;
        private readonly IDbSet<ApplicationPermission> _permissions;
        private readonly IUnitOfWork _unitOfWork;
        #endregion

        #region Constructor

        public ApplicationRoleManager(IRoleStore<ApplicationRole, int> roleStore, IUnitOfWork unitOfWork)
            : base(roleStore)
        {
            _roleStore = roleStore;
            _unitOfWork = unitOfWork;
            _users = _unitOfWork.Set<ApplicationUser>();
            _permissions = _unitOfWork.Set<ApplicationPermission>();
        }
        #endregion

        #region IApplicationRoleManager

        public ApplicationRole FindRoleByName(string roleName)
        {
            return this.FindByName(roleName); // RoleManagerExtensions
        }

        public IdentityResult CreateRole(ApplicationRole role)
        {
            return this.Create(role); // RoleManagerExtensions
        }

        public IList<ApplicationUserRole> GetUsersOfRole(string roleName)
        {
            return this.Roles.Where(role => role.Name == roleName)
                             .SelectMany(role => role.Users)
                             .ToList();
        }

        public IList<ApplicationUser> GetApplicationUsersInRole(string roleName)
        {
            var roleUserIdsQuery = from role in this.Roles
                                   where role.Name == roleName
                                   from user in role.Users
                                   select user.UserId;

            return _users.Where(applicationUser => roleUserIdsQuery.Contains(applicationUser.Id))
                         .ToList();
        }

        public IList<ApplicationRole> FindUserRoles(int userId)
        {
            var userRolesQuery = from role in this.Roles
                                 from user in role.Users
                                 where user.UserId == userId
                                 select role;

            return userRolesQuery.OrderBy(x => x.Name).ToList();
        }

        public string[] GetRolesForUser(int userId)
        {
            var roles = FindUserRoles(userId);
            if (roles == null || !roles.Any())
            {
                return new string[] { };
            }

            return roles.Select(x => x.Name).ToArray();
        }

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

        public async Task<IList<ApplicationRole>> GetAllApplicationRolesAsync()
        {
            return await this.Roles.ToListAsync();
        }

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

        public async Task<IList<string>> GetPermissionsOfRole(int roleId)
        {
            return
                await Roles.Where(a => a.Id == roleId)
                    .SelectMany(a => a.Permissionses)
                    .Select(a => a.Name)
                    .ToListAsync();
        }
        #endregion


        public async Task<IList<ApplicationPermission>> GetAllPermissions()
        {
            return await _permissions.AsNoTracking().ToListAsync();
        }

        public async Task AddPermissionsToRole(int roleId, params int[] permissions)
        {
            var role = await _roleStore.FindByIdAsync(roleId);

            if (role != null)
            {
                var actualPermissions = await _permissions.Where(a => permissions.Contains(a.Id)).ToListAsync();
                actualPermissions.ForEach(a => role.Permissionses.Add(a));

                _unitOfWork.Update(role, a => a.AssociatedCollection(b => b.Permissionses));
            }
        }


        public async Task EditPermissionsToRole(int roleId, params int[] permissions)
        {
            var role = await _roleStore.FindByIdAsync(roleId);

            if (role != null)
            {
                role.Permissionses.Clear();

                var actualPermissions = await _permissions.Where(a => permissions.Contains(a.Id)).ToListAsync();
                actualPermissions.ForEach(a => role.Permissionses.Add(a));

                _unitOfWork.Update(role, a => a.AssociatedCollection(b => b.Permissionses));
            }
        }
    }
}
