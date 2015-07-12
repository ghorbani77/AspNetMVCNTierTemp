using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using MVC5.DomainClasses.Entities;
using MVC5.ServiceLayer.Contracts;

namespace MVC5.ServiceLayer.EFServiecs
{
   public class ApplicationSignInManager : SignInManager<ApplicationUser, int>,IApplicationSignInManager
    {

        #region Fields
        private readonly ApplicationUserManager _userManager;
        private readonly IAuthenticationManager _authenticationManager;
        #endregion

        #region Constructor

        public ApplicationSignInManager(ApplicationUserManager userManager, IAuthenticationManager authenticationManager)
            : base(userManager, authenticationManager)
        {
            _userManager = userManager;
            _authenticationManager = authenticationManager;
        }
        #endregion
    }
}
