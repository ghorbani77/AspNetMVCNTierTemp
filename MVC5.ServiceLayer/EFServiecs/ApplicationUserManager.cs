using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.DataProtection;
using MVC5.DomainClasses.Entities;
using MVC5.ServiceLayer.Contracts;
using MVC5.ServiceLayer.IdentityExtentions;

namespace MVC5.ServiceLayer.EFServiecs
{
    public class ApplicationUserManager : UserManager<ApplicationUser, int>, IApplicationUserManager
    {

        #region Fields
        private readonly IDataProtectionProvider _dataProtectionProvider;
        private readonly IIdentityMessageService _emailService;
        private readonly IApplicationRoleManager _roleManager;
        private readonly IIdentityMessageService _smsService;
        private readonly IUserStore<ApplicationUser, int> _userStore;
        #endregion

        #region Constructor

        public ApplicationUserManager(IDataProtectionProvider dataProtectionProvider, IIdentityMessageService identityMessageService, IApplicationRoleManager roleManager, IUserStore<ApplicationUser, int> userStore)
            : base(userStore)
        {
            _dataProtectionProvider = dataProtectionProvider;
            _emailService = identityMessageService;
            _smsService = identityMessageService;
            _userStore = userStore;
            _roleManager = roleManager;

            this.CreateApplicationUserManager();
        }
        #endregion

        #region IApplicationUserManager

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(ApplicationUser applicationUser)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await CreateIdentityAsync(applicationUser, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }

        public async Task<bool> HasPassword(int userId)
        {
            var user = await FindByIdAsync(userId);
            return user != null && user.PasswordHash != null;
        }

        public async Task<bool> HasPhoneNumber(int userId)
        {
            var user = await FindByIdAsync(userId);
            return user != null && user.PhoneNumber != null;
        }

        public Func<CookieValidateIdentityContext, Task> OnValidateIdentity()
        {
            return SecurityStampValidator.OnValidateIdentity<ApplicationUserManager, ApplicationUser, int>(
                         validateInterval: TimeSpan.FromMinutes(30),
                         regenerateIdentityCallback: GenerateUserIdentityAsync,
                         getUserIdCallback: id => id.GetUserId<int>());
        }

        public void SeedDatabase()
        {
            const string name = "admin@example.com";
            const string password = "Admin@123456";
            const string roleName = "Admin";

            var role = _roleManager.FindRoleByName(roleName);
            if (role == null)
            {
                role = new ApplicationRole
                {
                    Name = roleName
                };
                var roleresult = _roleManager.CreateRole(role);
            }

            var user = this.FindByName(name);
            if (user == null)
            {
                user = new ApplicationUser { UserName = name, Email = name, EmailConfirmed = true };
                this.Create(user, password);

                this.SetLockoutEnabled(user.Id, false);
                this.SetTwoFactorEnabled(user.Id, false);
            }


            var rolesForUser = this.GetRoles(user.Id);
            if (!rolesForUser.Contains(role.Name))
            {
                this.AddToRole(user.Id, role.Name);
            }
        }

        private static async Task<ClaimsIdentity> GenerateUserIdentityAsync(ApplicationUserManager manager, ApplicationUser applicationUser)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(applicationUser, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }

        public Task<List<ApplicationUser>> GetAllUsersAsync()
        {
            return Users.ToListAsync();
        }
        public bool IsEmailInDatabase(string email)
        {
            var user = this.FindByEmail(email);
            return user != null;
        }
        public bool IsPhoneNumberInDatabase(string phoneNumber)
        {
            
            return this.Users.Any(u => u.PhoneNumber.Equals(phoneNumber));

        }
        #endregion

        #region CreateApplicationUserManager

        private void CreateApplicationUserManager()
        {
            this.UserValidator = new CustomUserValidator<ApplicationUser, int>(this)
            {
                AllowOnlyAlphanumericUserNames = false,
                RequireUniqueEmail = false
            };

            this.PasswordValidator = new CustomPasswordValidator()
            {
                RequiredLength = 6,
                RequireNonLetterOrDigit = false,
                RequireDigit = false,
                RequireLowercase = false,
                RequireUppercase = false
            };

            this.UserLockoutEnabledByDefault = true;
            this.DefaultAccountLockoutTimeSpan = TimeSpan.FromMinutes(5);
            this.MaxFailedAccessAttemptsBeforeLockout = 5;

            this.RegisterTwoFactorProvider("PhoneCode", new PhoneNumberTokenProvider<ApplicationUser, int>
            {
                MessageFormat = "کد فعال سازی شما {0} است"
            });
            this.RegisterTwoFactorProvider("EmailCode", new EmailTokenProvider<ApplicationUser, int>
            {
                Subject = "کد فعال سازی",
                BodyFormat = "کد فعال سازی شما {0} است"
            });

            this.EmailService = _emailService;
            this.SmsService = _smsService;

            if (_dataProtectionProvider == null) return;

            var dataProtector = _dataProtectionProvider.Create("Asp.net Identity");
            this.UserTokenProvider = new DataProtectorTokenProvider<ApplicationUser, int>(dataProtector);

        }
        #endregion

    }
}
