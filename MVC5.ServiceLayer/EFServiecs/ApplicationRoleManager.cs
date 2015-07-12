using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using MVC5.DataLayer.Context;
using MVC5.DomainClasses.Entities;
using MVC5.ServiceLayer.Contracts;

namespace MVC5.ServiceLayer.EFServiecs
{
    public class ApplicationRoleManager : RoleManager<ApplicationRole, int>, IApplicationRoleManager
    {
        #region Fields
        private readonly IDbSet<ApplicationUser> _users;
        private readonly IRoleStore<ApplicationRole, int> _roleStore;
        private readonly IUnitOfWork _unitOfWork;
        #endregion

        #region Constructor

        public ApplicationRoleManager(IRoleStore<ApplicationRole, int> roleStore, IUnitOfWork unitOfWork)
            : base(roleStore)
        {
            _roleStore = roleStore;
            _unitOfWork = unitOfWork;
            _users = _unitOfWork.Set<ApplicationUser>();
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

        public IList<ApplicationUserRole> GetCustomUsersInRole(string roleName)
        {
            return this.Roles.Where(role => role.Name == roleName)
                             .SelectMany(role => role.Users)
                             .ToList();
            // = this.FindByName(roleName).Users
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

        public Task<List<ApplicationRole>> GetAllApplicationRolesAsync()
        {
            return this.Roles.ToListAsync();
        }

        #endregion
    }
}
