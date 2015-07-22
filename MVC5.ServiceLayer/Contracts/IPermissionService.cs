using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;
using MVC5.DomainClasses.Entities;

namespace MVC5.ServiceLayer.Contracts
{
    public interface IPermissionService
    {
        void Add(ApplicationPermission permission);
        void AddRange(IEnumerable<ApplicationPermission> permissions);
        Task RemoveAll();
        IEnumerable<ApplicationPermission> GetActualPermissions(params int[] ids);
        Task<IList<ApplicationPermission>> GetAllPermissions();
        Task<IEnumerable<SelectListItem>> GetAsSelectList();
        Task<IEnumerable<SelectListItem>> GetParentsAsSelectList();
        Task<int[]> GetPermissionsWithIds(params int[] ids);
        bool IsAnyPermissionInDb();
        bool AutoCommitEnabled { get; set; }
        ApplicationPermission GetByName(string name);
        IEnumerable<ApplicationPermission> GetActualPermissions(List<ApplicationPermission> permissions);

    }
}
