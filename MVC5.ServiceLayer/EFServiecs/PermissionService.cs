using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using EntityFramework.Extensions;
using MVC5.DataLayer.Context;
using MVC5.DomainClasses.Entities;
using MVC5.ServiceLayer.Contracts;

namespace MVC5.ServiceLayer.EFServiecs
{
    public class PermissionService : IPermissionService
    {
        #region Fields

        private readonly IUnitOfWork _unitOfWork;
        private readonly IDbSet<ApplicationPermission> _permissions;
        #endregion

        #region Ctor

        public PermissionService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _permissions = _unitOfWork.Set<ApplicationPermission>();
        }
        #endregion

        public void Add(ApplicationPermission permission)
        {
            _permissions.Add(permission);
        }

        public void AddRange(IEnumerable<ApplicationPermission> permissions)
        {
            foreach (var applicationPermission in permissions)
            {
                Add(applicationPermission);
            }
        }


        public async Task RemoveAll()
        {
            await _permissions.DeleteAsync();
        }


        public async Task<IEnumerable<ApplicationPermission>> GetActualPermissions(params int[] ids)
        {
            return await _permissions.Where(a => ids.Contains(a.Id)).AsNoTracking().ToListAsync();
        }

        public async Task<IList<ApplicationPermission>> GetAllPermissions()
        {
            return await _permissions.AsNoTracking().ToListAsync();
        }
    }
}
