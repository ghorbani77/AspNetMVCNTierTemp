using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using EntityFramework.Extensions;
using MVC5.DomainClasses.Entities;
using MVC5.ServiceLayer.Contracts;
using MVC5.DataLayer.Context;
using MVC5.ViewModel.Group;

namespace MVC5.ServiceLayer.EFServiecs
{
    public class GroupService : IGroupService
    {
        #region Fields

        private readonly IApplicationUserManager _userManager;
        private readonly IApplicationRoleManager _roleManager;
        private readonly IDbSet<ApplicationGroup> _groups;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMappingEngine _mappingEngine;
        private readonly IDbSet<ApplicationRoleGroup> _roleGroups;
        private readonly IDbSet<ApplicationUserGroup> _userGroups;
        #endregion

        #region Constructor

        public GroupService(IMappingEngine mappingEngine, IApplicationUserManager userManager,
            IApplicationRoleManager roleManager, IUnitOfWork unitOfWork)
        {
            _mappingEngine = mappingEngine;
            _unitOfWork = unitOfWork;
            _userManager = userManager;
            _roleManager = roleManager;
            _groups = _unitOfWork.Set<ApplicationGroup>();
            _roleGroups = _unitOfWork.Set<ApplicationRoleGroup>();
            _userGroups = _unitOfWork.Set<ApplicationUserGroup>();
        }

        #endregion

        #region IGroupService


        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }



        public async Task<IEnumerable<DomainClasses.Entities.ApplicationGroup>> GetAllGroups()
        {
            return await _groups.ToListAsync();
        }


        public void Update(GroupViewModel viewModel)
        {
            throw new NotImplementedException();
        }

        public Task<DomainClasses.Entities.ApplicationGroup> FindByIdAsync(int id)
        {
            return ((DbSet<ApplicationGroup>)_groups).FindAsync(new object[] { id });
        }

        public DomainClasses.Entities.ApplicationGroup FindById(int id)
        {
            return _groups.Find(id);
        }

        public DomainClasses.Entities.ApplicationGroup FindByName(int name)
        {
            throw new NotImplementedException();
        }
        #endregion

        public void Create(ApplicationGroup group)
        {
            _groups.Add(group);
        }


        public Task<bool> IsGroupExsit(string name)
        {
            return _groups.AnyAsync(a => a.Name.Equals(name));
        }



        public IQueryable<GroupViewModel> GetAllGroupsGrid()
        {
            return _groups.Project(_mappingEngine)
                .To<GroupViewModel>().AsQueryable();
        }


        public async Task<IEnumerable<int>> GetGroupRolesAsync(int id)
        {
            return
                await _roleGroups.Where(a => a.ApplicationGroupId == id).Select(a => a.ApplicationRoleId).ToListAsync();
        }

        public async Task SetRolesToGroup(int groupId, int[] permissions)
        {
            await _roleGroups.Where(a => a.ApplicationGroupId == groupId).DeleteAsync();
            await _unitOfWork.SaveChangesAsync();
            var roleGroups =
                permissions.Select(a => new ApplicationRoleGroup { ApplicationRoleId = a, ApplicationGroupId = groupId });

            try
            {
                _unitOfWork.AutoDetectChangesEnabled(false);
                ((DbSet<ApplicationRoleGroup>)_roleGroups).AddRange(roleGroups);
                await _unitOfWork.SaveChangesAsync();
            }
            finally
            {
                _unitOfWork.AutoDetectChangesEnabled();
            }

            var efectedUsers = await _userGroups.Where(a => a.ApplicationGroupId == groupId).Select(a => a.ApplicationUserId).ToListAsync();
            foreach (var userId in efectedUsers)
            {
                await RefreshUserGroupRolesAsync(userId, groupId);
            }
        }

        private async Task RefreshUserGroupRolesAsync(int userId, int groupId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            var oldUserRoles = await _userManager.GetRolesAsync(userId);
            await _userManager.RemoveFromRolesAsync(userId, oldUserRoles.ToArray());

            var newGroupRoles = await this.GetUserGroupRolesAsync(userId);

            var allRoles = await _roleManager.GetAllApplicationRolesAsync();
            var addTheseRoles = allRoles.Where(r => newGroupRoles.Any(gr => gr.ApplicationRoleId == r.Id));
            var roleNames = addTheseRoles.Select(n => n.Name).ToArray();

            await _userManager.AddToRolesAsync(userId, roleNames);

        }

        private async Task<IEnumerable<ApplicationRoleGroup>> GetUserGroupRolesAsync(int userId)
        {
            var userGroups = await _userGroups.Where(a => a.ApplicationUserId == userId).Select(a => a.ApplicationGroupId).ToListAsync();
            var roleGroups = await _roleGroups.Where(a => userGroups.Any(b => b == a.ApplicationGroupId)).ToListAsync();
            return roleGroups;
        }
    }
}
