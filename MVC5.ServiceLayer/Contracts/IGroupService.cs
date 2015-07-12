using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MVC5.DomainClasses.Entities;
using MVC5.ViewModel.Group;

namespace MVC5.ServiceLayer.Contracts
{
    public interface IGroupService
    {
        Task DeleteAsync(int id);
        void Create(ApplicationGroup group);
        void Delete(int id);
        IQueryable<GroupViewModel> GetAllGroupsGrid( );
        Task<IEnumerable<ApplicationGroup>> GetAllGroups();
        void Update(GroupViewModel viewModel);
        Task<ApplicationGroup> FindByIdAsync(int id);
        ApplicationGroup FindById(int id);
        Task<bool> IsGroupExsit(string name);
        ApplicationGroup FindByName(int name);
        Task<IEnumerable<int>> GetGroupRolesAsync(int id);
        Task SetRolesToGroup(int groupId, int[] permissions);
    }
}
