using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using EntityFramework.Extensions;
using MVC5.DataLayer.Context;
using MVC5.DomainClasses.Entities;
using MVC5.ServiceLayer.Contracts;
using MVC5.ViewModel.AdminArea.Permission;

namespace MVC5.ServiceLayer.EFServiecs
{
    public class PermissionService : IPermissionService
    {
        #region Fields

        private readonly IMappingEngine _mappingEngine;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IDbSet<ApplicationPermission> _permissions;
        #endregion

        #region Ctor

        public PermissionService(IUnitOfWork unitOfWork,IMappingEngine mappingEngine)
        {
            AutoCommitEnabled = true;
            _unitOfWork = unitOfWork;
            _permissions = _unitOfWork.Set<ApplicationPermission>();
            _mappingEngine = mappingEngine;
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
        public async Task<IEnumerable<SelectPermissionViewModel>> GetAsSelectList()
        {
            var items =
                await
                    _permissions.Include(a => a.Children)
                        .AsNoTracking()
                        .ToListAsync();
            var x = _mappingEngine.Map<IEnumerable<SelectPermissionViewModel>>(items);
            return x;
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

        #region GetPermissionByRoleIds
        public async Task<IList<string>> GetPermissionByRoleIds(int[] roleIds)
        {
            return await (from p in _permissions
                          from r in p.ApplicationRoles
                          where roleIds.Contains(r.Id)
                          select p.Name).ToListAsync();
        }
        #endregion

        #region SeedDatabase
        public void SeedDatabase(IEnumerable<ApplicationPermission> permissions)
        {
            var applicationPermissions = permissions as IList<ApplicationPermission> ?? permissions.ToList();
            var parents = applicationPermissions.Where(a => a.Parent == null).ToList();
            foreach (var parent in parents)
            {
                _permissions.AddOrUpdate(x => new { x.Name, x.ActionName, x.ControllerName, x.AreaName, x.IsMenu }, parent);
            }
            _unitOfWork.SaveChanges();

            foreach (var permission in applicationPermissions.Where(a => a.Parent != null).ToList())
            {
                _permissions.AddOrUpdate(x => new { x.Name, x.ActionName, x.ControllerName, x.AreaName, x.IsMenu }, permission);
            }
            _unitOfWork.SaveChanges();
        }
        #endregion

        #region CanAccess
        public bool CanAccess(int userId, string areaName, string controllerName, string actionName)
        {
#if DEBUG
            return true;
#endif
            return false;

        }
        #endregion

    }
}
