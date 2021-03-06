﻿using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using AutoMapper.QueryableExtensions;
using EFSecondLevelCache;
using EntityFramework.Extensions;
using MVC5.Common.Caching;
using MVC5.Common.Helpers.Extentions;
using MVC5.DataLayer.Context;
using MVC5.DomainClasses.Entities;
using MVC5.ServiceLayer.Contracts;
using AutoMapper;

namespace MVC5.ServiceLayer.EFServiecs
{
    public class PermissionService : IPermissionService
    {
        #region Fields

        private readonly HttpContextBase _httpContextBase;
        private readonly IMappingEngine _mappingEngine;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IDbSet<ApplicationPermission> _permissions;
        #endregion

        #region Ctor

        public PermissionService(HttpContextBase httpContextBase,IUnitOfWork unitOfWork, IMappingEngine mappingEngine)
        {
            AutoCommitEnabled = true;
            _unitOfWork = unitOfWork;
            _permissions = _unitOfWork.Set<ApplicationPermission>();
            _mappingEngine = mappingEngine;
            _httpContextBase = httpContextBase;
        }
        #endregion

        #region Add
        public void Add(ApplicationPermission permission)
        {
            _permissions.Add(permission);
        }
        #endregion

        #region
        public void AddRange(IEnumerable<ApplicationPermission> permissions)
        {
            _unitOfWork.AddThisRange(permissions);
        }

        #endregion

        #region RemoveAll
        public async Task RemoveAll()
        {
            await _permissions.DeleteAsync();
        }
        #endregion

        #region GetActualPermissions

        /// <summary>
        /// get all permissions that it's id in ids 
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public IEnumerable<ApplicationPermission> GetActualPermissions(params int[] ids)
        {
            return _permissions
                    .Where(a => ids.Contains(a.Id))
                    .ToList();
        }

        #endregion

        #region GetAllPermissions
        public async Task<IList<ApplicationPermission>> GetAllPermissions()
        {
            return await _permissions.AsNoTracking().ToListAsync();
        }
        #endregion

        #region GetAsSelectList
        public async Task<IEnumerable<SelectListItem>> GetAsSelectList()
        {
            var items =
                await
                    _permissions.Project(_mappingEngine).To<SelectListItem>()
                        .AsNoTracking().Cacheable()
                        .ToListAsync();

            return items;
        }
        #endregion

        #region GetPermissionsWithIds
        /// <summary>
        /// get all permissionIds that it's id in ids or it's parentIs in ids
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public async Task<int[]> GetPermissionsWithIds(params int[] ids)
        {
            var permissionsIds = await _permissions.AsNoTracking()
                    .Where(a => ids.Contains(a.Id)).Select(a => a.Id)
                    .ToListAsync();
            return permissionsIds.ToArray();

        }
        #endregion

        #region IsAnyPermissionInDb
        public bool IsAnyPermissionInDb()
        {
            return _permissions.Any();
        }
        #endregion

        #region AutoCommitEnabled
        public bool AutoCommitEnabled { get; set; }

        #endregion

        #region GetByName
        public ApplicationPermission GetByName(string name)
        {
            return _permissions.FirstOrDefault(a => a.Name == name);
        }
        #endregion

        #region GetActualPermissions
        public IEnumerable<ApplicationPermission> GetActualPermissions(List<ApplicationPermission> permissions)
        {
            var permissionNames = permissions.Select(a => a.Name).ToArray();
            var inDbPermissions = _permissions.Where(a => permissionNames.Any(p => p == a.Name)).ToList();
            var result = new List<ApplicationPermission>(inDbPermissions);
            var noInDbPermissions = permissions.Where(a => inDbPermissions.All(p => p.Name != a.Name)).ToList();
            result.AddRange(noInDbPermissions);
            return result;
        }
        #endregion

        #region GetUserPermissions,GetPermissionByRoleIdsAsync
        public async Task<IList<string>> GetPermissionByRoleIdsAync(int[] roleIds)
        {
            return await (from p in _permissions
                          from r in p.ApplicationRoles
                          where roleIds.Contains(r.Id)
                          select p.Name).ToListAsync();
        }

        public IList<string> GetUserPermissions(int[] roleIds, int userId)
        {
            var permissionsOfRoles = (from p in _permissions
                                      from r in p.ApplicationRoles
                                      where roleIds.Contains(r.Id)
                                      select p.Name).Future();

            var permissionsOfUser = (from p in _permissions
                                     from r in p.AssignedUsers
                                     where userId == r.Id
                                     select p.Name).Future().ToList();

            var result = permissionsOfUser.Union(permissionsOfRoles).ToList();
            return result;
        }
       
        #endregion

        #region SeedDatabase
        public void SeedDatabase(IEnumerable<ApplicationPermission> permissions)
        {
            var applicationPermissions = permissions as IList<ApplicationPermission> ?? permissions.ToList();

            foreach (var permission in applicationPermissions)
            {
                _permissions.AddOrUpdate(
                    x => new { x.Name }, permission);
            }
            _unitOfWork.SaveChanges();
        }
        #endregion

        #region HasDirectAccess
        public bool HasDirectAccess(int userId, string areaName, string controllerName,
         string[] dependencyActionNames)
        {

            var directAccessWithOwnPermissions =
                _permissions.Include(a => a.AssignedUsers).AsNoTracking().Any(
                    p =>
                        p.AssignedUsers.Any(u => u.Id == userId) & dependencyActionNames.Contains(p.ActionName) &
                        p.ControllerName == controllerName & p.AreaName == areaName);

            return directAccessWithOwnPermissions;
        }
        #endregion

        #region GetPermissionsByRoleId
        public async Task<IList<string>> GetPermissionsByRoleId(int roleId)
        {
            return await (from p in _permissions
                          from r in p.ApplicationRoles
                          where r.Id == roleId
                          select p.Name).ToListAsync();
        }
        #endregion

        #region GetPermissionIdsByRoleId
        public async Task<IList<int>> GetPermissionIdsByRoleId(int roleId)
        {
            return await (from p in _permissions
                          from r in p.ApplicationRoles
                          where r.Id == roleId
                          select p.Id).ToListAsync();
        }
        #endregion

        #region GetPermissionsWithUserId
        public IList<int> GetPermissionsWithUserId(int userId)
        {
            return (from p in _permissions
                    from r in p.AssignedUsers
                    where userId == r.Id
                    select p.Id).ToList();
        }
        #endregion

    }
}
