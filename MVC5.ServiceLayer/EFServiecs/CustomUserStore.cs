using Microsoft.AspNet.Identity;
using MVC5.DomainClasses.Entities;
using MVC5.ServiceLayer.Contracts;

namespace MVC5.ServiceLayer.EFServiecs
{
    public class CustomUserStore : ICustomUserStore
    {
        private readonly IUserStore<ApplicationUser, int> _userStore;

        public CustomUserStore(IUserStore<ApplicationUser, int> userStore)
        {
            _userStore = userStore;
        }


    }
}
