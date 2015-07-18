using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.DataProtection;
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
            
         //ProjectObjectFactory.Container.GetInstance<IApplicationUserManager>().SeedDatabase();

            appBuilder.CreatePerOwinContext(() => ProjectObjectFactory.Container.GetInstance<IApplicationUserManager>());
            appBuilder.CreatePerOwinContext(() => ProjectObjectFactory.Container.GetInstance<IApplicationRoleManager>());
            appBuilder.CreatePerOwinContext(() => ProjectObjectFactory.Container.GetInstance<IApplicationSignInManager>());


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

            // Enables the application to temporarily store user information when they are verifying the second factor in the two-factor authentication process.
           // appBuilder.UseTwoFactorSignInCookie(DefaultAuthenticationTypes.TwoFactorCookie, TimeSpan.FromMinutes(5));

            // Enables the application to remember the second login verification factor such as phone or email.
            // Once you check this option, your second step of verification during the login process will be remembered on the device where you logged in from.
            // This is similar to the RememberMe option when you log in.
           // appBuilder.UseTwoFactorRememberBrowserCookie(DefaultAuthenticationTypes.TwoFactorRememberBrowserCookie);

            // Uncomment the following lines to enable logging in with third party login providers
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
