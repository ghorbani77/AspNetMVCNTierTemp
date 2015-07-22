using Microsoft.AspNet.Identity;
using MVC5.DomainClasses.Entities;
using MVC5.ServiceLayer.Contracts;

namespace MVC5.ServiceLayer.EFServiecs
{
    public class CustomRoleStore : ICustomRoleStore
    {
        private readonly IRoleStore<ApplicationRole, int> _roleStore;

        public CustomRoleStore(IRoleStore<ApplicationRole, int> roleStore)
        {
            _roleStore = roleStore;
        }
    }
}
