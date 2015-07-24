using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.DataProtection;
using MVC5.DataLayer.Context;
using MVC5.ServiceLayer.EFServiecs;
using Owin;
using StructureMap.Web;
using MVC5.IocConfig;
using MVC5.ServiceLayer.Contracts;

namespace MVC5.Web
{
    public  class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }

        private static void ConfigureAuth(IAppBuilder appBuilder)
        {
            ProjectObjectFactory.Container.Configure(config => config.For<IDataProtectionProvider>()
                .HybridHttpOrThreadLocalScoped()
                .Use(() => appBuilder.GetDataProtectionProvider()));

            ProjectObjectFactory.Container.GetInstance<IApplicationRoleManager>()
             .SeedDatabase(SystemConfiguration.ConfigPermissions());

            ProjectObjectFactory.Container.GetInstance<IApplicationUserManager>()
               .SeedDatabase();

            appBuilder.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Account/Login"),
                SlidingExpiration = true,
                Provider = new CookieAuthenticationProvider
                {
                    OnValidateIdentity =
                            ProjectObjectFactory.Container.GetInstance<IApplicationUserManager>().OnValidateIdentity()
                }

            });

            
            appBuilder.UseExternalSignInCookie();
          
          
            appBuilder.UseFacebookAuthentication(
               appId: "fdsfdsfs",
               appSecret: "fdfsfs");

            appBuilder.UseGoogleAuthentication(
                clientId: "fdsfsdfs",
                clientSecret: "fdsfsf");

            
        }
    }
}
