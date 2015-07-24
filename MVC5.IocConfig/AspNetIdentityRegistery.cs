using System.Data.Entity;
using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
using MVC5.DataLayer.Context;
using MVC5.DomainClasses.Entities;
using MVC5.ServiceLayer.Contracts;
using MVC5.ServiceLayer.EFServiecs;
using StructureMap.Configuration.DSL;
using StructureMap.Web;

namespace MVC5.IocConfig
{
    public class AspNetIdentityRegistery : Registry
    {
        public AspNetIdentityRegistery()
        {
            For<ApplicationDbContext>().HybridHttpOrThreadLocalScoped()
                               .Use(context => (ApplicationDbContext)context.GetInstance<IUnitOfWork>());
            For<DbContext>().HybridHttpOrThreadLocalScoped()
                 .Use(context => (ApplicationDbContext)context.GetInstance<IUnitOfWork>());

            For<IUserStore<ApplicationUser, int>>()
                 .HybridHttpOrThreadLocalScoped()
                 .Use<UserStore<ApplicationUser, ApplicationRole, int, ApplicationUserLogin, ApplicationUserRole, ApplicationUserClaim>>();

          

            For<IRoleStore<ApplicationRole, int>>()
                 .HybridHttpOrThreadLocalScoped()
                 .Use<RoleStore<ApplicationRole, int, ApplicationUserRole>>();

            For<IAuthenticationManager>()
                 .Use(() => HttpContext.Current.GetOwinContext().Authentication);

            For<IApplicationSignInManager>()
                 .HybridHttpOrThreadLocalScoped()
                 .Use<ApplicationSignInManager>();

            For<IApplicationRoleManager>()
                 .HybridHttpOrThreadLocalScoped()
                 .Use<ApplicationRoleManager>();

            For<IIdentityMessageService>().Use<SmsService>();
            For<IIdentityMessageService>().Use<MVC5.ServiceLayer.EFServiecs.EmailService>();

            For<IApplicationUserManager>().HybridHttpOrThreadLocalScoped()
               .Use<ApplicationUserManager>()
               .Ctor<IIdentityMessageService>("smsService").Is<SmsService>()
               .Ctor<IIdentityMessageService>("emailService").Is<MVC5.ServiceLayer.EFServiecs.EmailService>()
               .Setter<IIdentityMessageService>(userManager => userManager.SmsService).Is<SmsService>()
               .Setter<IIdentityMessageService>(userManager => userManager.EmailService).Is<MVC5.ServiceLayer.EFServiecs.EmailService>();

            For<ApplicationUserManager>().HybridHttpOrThreadLocalScoped()
                 .Use(context => (ApplicationUserManager)context.GetInstance<IApplicationUserManager>());

            For<ICustomRoleStore>()
                      .HybridHttpOrThreadLocalScoped()
                      .Use<CustomRoleStore>();

            For<ICustomUserStore>()
                  .HybridHttpOrThreadLocalScoped()
                  .Use<CustomUserStore>();

        }
    }

}
