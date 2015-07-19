using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using EntityFramework.Extensions;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.DataProtection;
using MVC5.DomainClasses;
using MVC5.DomainClasses.Entities;
using MVC5.ServiceLayer.Contracts;
using MVC5.ServiceLayer.IdentityExtentions;
using MVC5.ServiceLayer.Security;
using MVC5.ViewModel.Account;
using MVC5.ViewModel.AdminArea.User;

namespace MVC5.ServiceLayer.EFServiecs
{
    public class ApplicationUserManager : UserManager<ApplicationUser, int>, IApplicationUserManager
    {

        #region Fields
        private readonly IDataProtectionProvider _dataProtectionProvider;
        private readonly IIdentityMessageService _emailService;
        private readonly IIdentityMessageService _smsService;
        private readonly IMappingEngine _mappingEngine;
        private readonly IUserStore<ApplicationUser, int> _userStore;
        #endregion

        #region Constructor
        public ApplicationUserManager(IMappingEngine mappingEngine, IDataProtectionProvider dataProtectionProvider, IIdentityMessageService identityMessageService, IUserStore<ApplicationUser, int> userStore)
            : base(userStore)
        {
            _dataProtectionProvider = dataProtectionProvider;
            _emailService = identityMessageService;
            _smsService = identityMessageService;
            _userStore = userStore;
            _mappingEngine = mappingEngine;

            CreateApplicationUserManager();
        }
        #endregion

        #region GenerateUserIdentityAsync
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(ApplicationUser applicationUser)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await CreateIdentityAsync(applicationUser, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
        #endregion

        #region HasPassword

        public async Task<bool> HasPassword(int userId)
        {
            var user = await FindByIdAsync(userId);
            return user != null && user.PasswordHash != null;
        }

        #endregion

        #region HasPhoneNumber
        public async Task<bool> HasPhoneNumber(int userId)
        {
            var user = await FindByIdAsync(userId);
            return user != null && user.PhoneNumber != null;
        }
        #endregion

        #region OnValidateIdentity
        public Func<CookieValidateIdentityContext, Task> OnValidateIdentity()
        {
            return SecurityStampValidator.OnValidateIdentity<ApplicationUserManager, ApplicationUser, int>(
                         validateInterval: TimeSpan.FromMinutes(30),
                         regenerateIdentityCallback: GenerateUserIdentityAsync,
                         getUserIdCallback: id => id.GetUserId<int>());
        }

        #endregion

        #region SeedDatabase
        public async Task SeedDatabase(InstallViewModel viewModel)
        {
            var user = _mappingEngine.Map<ApplicationUser>(viewModel);

            user.EmailConfirmed = true;
            user.TwoFactorEnabled = false;
            user.PhoneNumberConfirmed = true;
            user.CanChangeProfilePicture = true;
            user.LockoutEnabled = false;
            user.IsSystemAccount = true;
            user.CommentPermission = CommentPermissionType.WithOutApporove;
            user.CanChangeProfilePicture = true;
            user.CanModifyFirsAndLastName = true;
            user.CanUploadFile = true;

            await CreateAsync(user,viewModel.Password);
            await AddToRoleAsync(user.Id, SystemRoleNames.SuperAdministrators.Name);
        }

        #endregion

        #region GenerateUserIdentityAsync
        private static async Task<ClaimsIdentity> GenerateUserIdentityAsync(ApplicationUserManager manager, ApplicationUser applicationUser)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(applicationUser, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
        #endregion

        #region GetAllUsersAsync
        public Task<List<ApplicationUser>> GetAllUsersAsync()
        {
            return Users.ToListAsync();
        }
        #endregion

        #region IsEmailInDatabase
        public bool IsEmailInDatabase(string email)
        {
            var user = this.FindByEmail(email);
            return user != null;
        }
        #endregion

        #region IsPhoneNumberInDatabase
        public bool IsPhoneNumberInDatabase(string phoneNumber)
        {

            return Users.Any(u => u.PhoneNumber.Equals(phoneNumber, StringComparison.InvariantCultureIgnoreCase));

        }
        #endregion

        #region IsUserNameInDatabase
        public bool IsUserNameInDatabase(string userName)
        {
            return Users.Any(a => a.UserName.Equals(userName, StringComparison.InvariantCultureIgnoreCase));
        }
        #endregion

        #region CreateApplicationUserManager

        private void CreateApplicationUserManager()
        {
            UserValidator = new CustomUserValidator<ApplicationUser, int>(this)
            {
                AllowOnlyAlphanumericUserNames = false,
                RequireUniqueEmail = false
            };

            PasswordValidator = new CustomPasswordValidator()
            {
                RequiredLength = 6,
                RequireNonLetterOrDigit = false,
                RequireDigit = false,
                RequireLowercase = false,
                RequireUppercase = false
            };

            UserLockoutEnabledByDefault = true;
            DefaultAccountLockoutTimeSpan = TimeSpan.FromMinutes(5);
            MaxFailedAccessAttemptsBeforeLockout = 5;

            //RegisterTwoFactorProvider("PhoneCode", new PhoneNumberTokenProvider<ApplicationUser, int>
            //{
            //    MessageFormat = "کد فعال سازی شما {0} است"
            //});
            //RegisterTwoFactorProvider("EmailCode", new EmailTokenProvider<ApplicationUser, int>
            //{
            //    Subject = "کد فعال سازی",
            //    BodyFormat = "کد فعال سازی شما {0} است"
            //});

            EmailService = _emailService;
            SmsService = _smsService;

            if (_dataProtectionProvider == null) return;

            var dataProtector = _dataProtectionProvider.Create("Asp.net Identity");
            UserTokenProvider = new DataProtectorTokenProvider<ApplicationUser, int>(dataProtector);

        }
        #endregion

        #region DeleteAll
        public void DeleteAll()
        {
            Users.Delete();
        }
        #endregion

        #region GetUsersWithRoleIds
        public IList<ApplicationUser> GetUsersWithRoleIds(params int[] ids)
        {
            return Users.Where(applicationUser => ids.Contains(applicationUser.Id))
                .ToList();
        }
        #endregion
       
    }
}
