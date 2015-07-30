using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using EntityFramework.Extensions;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.DataProtection;
using MVC5.Common.Caching;
using MVC5.Common.Controller;
using MVC5.Common.Helpers.Extentions;
using MVC5.DataLayer.Context;
using MVC5.DomainClasses.Entities;
using MVC5.ServiceLayer.Contracts;
using MVC5.ServiceLayer.IdentityExtentions;
using MVC5.ServiceLayer.QueryExtensions;
using MVC5.ServiceLayer.Security;
using MVC5.Utility;
using MVC5.Utility.EF.Filters;
using MVC5.ViewModel.AdminArea.User;
using RefactorThis.GraphDiff;

namespace MVC5.ServiceLayer.EFServiecs
{
    public class ApplicationUserManager : UserManager<ApplicationUser, int>, IApplicationUserManager
    {

        #region Fields

        private readonly HttpContextBase _contextBase;
        private readonly IPermissionService _permissionService;
        private readonly IApplicationRoleManager _roleManager;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IDbSet<ApplicationUser> _users;
        private readonly IDataProtectionProvider _dataProtectionProvider;
        private readonly IMappingEngine _mappingEngine;

        #endregion

        #region Constructor

        public ApplicationUserManager(HttpContextBase contextBase, IPermissionService permissionService, IUserStore<ApplicationUser, int> userStore, IApplicationRoleManager roleManager, IUnitOfWork unitOfWork,
            IMappingEngine mappingEngine, IDataProtectionProvider dataProtectionProvider,
             IIdentityMessageService smsService,
            IIdentityMessageService emailService)
            : base(userStore)
        {
            _permissionService = permissionService;
            AutoCommitEnabled = true;
            _dataProtectionProvider = dataProtectionProvider;
            _mappingEngine = mappingEngine;
            EmailService = emailService;
            SmsService = smsService;
            _unitOfWork = unitOfWork;
            _users = _unitOfWork.Set<ApplicationUser>();
            _roleManager = roleManager;
            _contextBase = contextBase;
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

        public void SeedDatabase()
        {
            const string systemAdminUserName = "SystemAdmin";
            const string systemAdminEmail = "Admin@gmail.com";
            const string systemAdminPassword = "Admin1234@gmail.com";

            var newUser = this.FindByName(systemAdminUserName);
            if (newUser == null)
            {
                newUser = new ApplicationUser
                {
                    UserName = systemAdminUserName,
                    CanChangeProfilePicture = true,
                    CanModifyFirsAndLastName = true,
                    CanUploadFile = true,
                    EmailConfirmed = true,
                    IsSystemAccount = true,
                    LockoutEnabled = false,
                    PhoneNumberConfirmed = true,
                    Email = systemAdminEmail,
                    RegisterDate = DateTime.Now,
                    AvatarFileName = "avatar.jpg"
                };
                var result = this.Create(newUser, systemAdminPassword);
            }
            var userRoles = this.GetRoles(newUser.Id);
            if (userRoles.Any(a => a == SystemRoleNames.SuperAdministrators)) return;
            this.AddToRole(newUser.Id, SystemRoleNames.SuperAdministrators);
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
                RequireUniqueEmail = true
            };

            PasswordValidator = new CustomPasswordValidator
            {
                RequiredLength = 5,
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


            if (_dataProtectionProvider == null) return;

            var dataProtector = _dataProtectionProvider.Create("Asp.net Identity");
            UserTokenProvider = new DataProtectorTokenProvider<ApplicationUser, int>(dataProtector);

        }
        #endregion

        #region DeleteAll
        public async Task RemoveAll()
        {
            await Users.DeleteAsync();
        }
        #endregion

        #region GetUsersWithRoleIds
        public IList<ApplicationUser> GetUsersWithRoleIds(params int[] ids)
        {
            return Users.Where(applicationUser => ids.Contains(applicationUser.Id))
                .ToList();
        }
        #endregion

        #region AutoCommitEnabled
        public bool AutoCommitEnabled { get; set; }

        #endregion

        #region Any
        public bool Any()
        {
            return _users.Any();
        }
        #endregion

        #region AddRange
        public void AddRange(IEnumerable<ApplicationUser> users)
        {
            _unitOfWork.AddThisRange(users);
        }
        #endregion

        #region IsExistByUserName

        public bool IsExistByUserName(string userName)
        {
            return Users.Any(a => a.UserName == userName);
        }
        #endregion

        #region GetPageList
        public IList<UserViewModel> GetPageList(out int total, UserSearchViewModel search)
        {
            var users = _users.AsNoTracking().OrderBy(a => a.Id).AsQueryable();
            if (search.RoleIds != null && search.RoleIds.Length > 0)
            {
                users =
                    users.Include(a => a.Roles)
                        .Where(a => a.Roles.Select(r => r.RoleId).Intersect(search.RoleIds).Any())
                        .AsQueryable();
            }
            if (search.SearchUserName.IsNotEmpty())
                users = users.SearchByUserName(search.SearchUserName);
            if (search.SearchEmail.IsNotEmpty())
                users = users.SearchByEmail(search.SearchEmail);
            if (search.SearchNameForShow.IsNotEmpty())
                users = users.SearchByNameForShow(search.SearchNameForShow);
           
            if (search.SearchIp.IsNotEmpty())
                users = users.SearchByIp(search.SearchIp);
            if (search.SearchCanChangeProfilePicture)
                _unitOfWork.EnableFiltering(UserFilters.CanChangeProfilePicList);
            if (search.SearchCanModifyFirsAndLastName)
                _unitOfWork.EnableFiltering(UserFilters.CanModifyFirsAndLastNameList);
            if (search.SearchCanUploadFile)
                _unitOfWork.EnableFiltering(UserFilters.CanUploadfileList);
            if (search.SearchIsBanned)
                _unitOfWork.EnableFiltering(UserFilters.BannedList);
            if (search.SearchIsDeleted)
                _unitOfWork.EnableFiltering(UserFilters.DeletedList);
            if (search.SearchIsEmailConfirmed)
                _unitOfWork.EnableFiltering(UserFilters.EmailConfirmedList);
            if (search.SearchIsSystemAccount)
                _unitOfWork.EnableFiltering(UserFilters.SystemAccountList);

            total = users.FutureCount();
            var query =
                users.OrderByUserName()
                    .SkipAndTake(search.PageIndex - 1, search.PageSize)
                    .Future().ToList();
            return _mappingEngine.Map<IList<UserViewModel>>(query);
        }
        #endregion

        #region GetUserByRoles
        public async Task<EditUserViewModel> GetUserByRolesAsync(int id)
        {
           var userWithRoles= await 
                _users.AsNoTracking()
                    .Include(a => a.Roles)
                    .FirstOrDefaultAsync(a => a.Id == id);
            return _mappingEngine.Map<EditUserViewModel>(userWithRoles);
        }
     
        #endregion

        #region EditUserWithRoles
        public void EditUserWithRoles(EditUserViewModel viewModel, int[] roleIds)
        {
            var key = viewModel.Id.ToString(CultureInfo.InvariantCulture) + "_roles";
            _contextBase.InvalidateCache(key);
            var user = _users.Include(a => a.Roles).First(a => a.Id == viewModel.Id);
            _mappingEngine.Map(viewModel, user);

            foreach (var roleId in from roleId in roleIds let userRoleRecord = user.Roles.FirstOrDefault(a => a.RoleId == roleId) where userRoleRecord == null select roleId)
            {
                user.Roles.Add(new ApplicationUserRole { RoleId = roleId, UserId = user.Id });
            }

        }
        #endregion

        #region SetRolesToUser
        public void SetRolesToUser(ApplicationUser user, IEnumerable<ApplicationRole> roles)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region AddUser
        public async Task AddUser(AddUserViewModel viewModel)
        {
            var user = _mappingEngine.Map<ApplicationUser>(viewModel);
            viewModel.RoleIds.ToList().ForEach(roleId => user.Roles.Add(new ApplicationUserRole { RoleId = roleId }));
            _users.Add(user);
            await _unitOfWork.SaveChangesAsync();
            _unitOfWork.MarkAsDetached(user);
            if (viewModel.PermissionIds == null || viewModel.PermissionIds.Length <= 0) return;
            user.OwnPermissions = new Collection<ApplicationPermission>();
            var permissions = _permissionService.GetActualPermissions(viewModel.PermissionIds).ToList();
            permissions.ForEach(a => user.OwnPermissions.Add(a));
            _unitOfWork.Update(user, a => a.AssociatedCollection(b => b.OwnPermissions));
            await _unitOfWork.SaveChangesAsync();
        }
        #endregion

        #region LogicalRemove
        public async Task<bool> LogicalRemove(int id)
        {
            var key = id.ToString(CultureInfo.InvariantCulture) + "_roles";
            _contextBase.InvalidateCache(key);
            _unitOfWork.EnableFiltering(UserFilters.NotSystemAccountList);
            var result = await _users.Where(a => a.Id == id).UpdateAsync(a => new ApplicationUser { IsDeleted = true });
            return result > 0;
        }
        #endregion

        #region Validations

        public bool CheckUserNameExist(string userName, int? id)
        {
            userName = userName.ToLower();
            return id == null
                ? _users.Any(a => a.UserName.ToLower() == userName)
                : _users.Any(a => a.UserName.ToLower() == userName && a.Id != id.Value);
        }

        public bool CheckEmailExist(string email, int? id)
        {
            email = email.FixGmailDots().ToLower();
            return id == null
               ? _users.Any(a => a.Email.ToLower() == email)
               : _users.Any(a => a.Email.ToLower() == email && a.Id != id.Value);
        }

        public bool CheckNameForShowExist(string nameForShow, int? id)
        {
            nameForShow = nameForShow.GetFriendlyPersianName();
            return id == null
             ? _users.Any(a => a.NameForShow.ToLower() == nameForShow)
             : _users.Any(a => a.NameForShow.ToLower() == nameForShow && a.Id != id.Value);
        }

        public bool CheckGooglePlusIdExist(string googlePlusId, int? id)
        {
            return id == null
                    ? _users.Any(a => a.GooglePlusId.ToLower() == googlePlusId)
                    : _users.Any(a => a.GooglePlusId.ToLower() == googlePlusId && a.Id != id.Value);
        }

        public bool CheckFacebookIdExist(string faceBookId, int? id)
        {
            return id == null
              ? _users.Any(a => a.FaceBookId.ToLower() == faceBookId)
              : _users.Any(a => a.FaceBookId.ToLower() == faceBookId && a.Id != id.Value);
        }

        public bool CheckPhoneNumberExist(string phoneNumber, int? id)
        {
            return id == null
               ? _users.Any(a => a.PhoneNumber == phoneNumber)
               : _users.Any(a => a.PhoneNumber == phoneNumber && a.Id != id.Value);
        }
        #endregion

        #region override GetRolesAsync
        public async override Task<IList<string>> GetRolesAsync(int userId)
        {
            var key = userId.ToString(CultureInfo.InvariantCulture) + "_roles";
            var cachedRoles = _contextBase.CacheRead<List<string>>(key);
            if (cachedRoles != null && cachedRoles.Count >= 1) return cachedRoles;
            var userRoleIds = _roleManager.FindUserRoleIds(userId);
            var result = await _permissionService.GetPermissionByRoleIds(userRoleIds.ToArray());
            _contextBase.CacheInsert(key, result, 20);
            return result;
        }

        #endregion

        #region CustomGetUserRoles
        public IList<int> CustomGetUserRoles(int id)
        {
            return _roleManager.FindUserRoleIds(id);
        }

        #endregion

        #region CreateAsync
        public async Task<int> CreateAsync(ViewModel.Account.RegisterViewModel viewModel)
        {
            var user = _mappingEngine.Map<ApplicationUser>(viewModel);
            await CreateAsync(user, viewModel.Password);
            await AddToRoleAsync(user.Id, await _roleManager.GetDefaultRoleForRegister());
            return user.Id;
        }
        #endregion

        #region CustomValidatePasswordAsync
        public async Task<string> CustomValidatePasswordAsync(string pass)
        {
            var result = await PasswordValidator.ValidateAsync(pass);
            return result.Errors.GetUserManagerErros();
        }
        #endregion

        #region ChechIsBanneduser
        public bool ChecKIsUserBanned(int id)
        {
            return _users.Any(a => a.Id == id & a.IsBanned);
        }
        #endregion

        #region GetEmailStore
        public IUserEmailStore<ApplicationUser, int> GetEmailStore()
        {
            var cast = Store as IUserEmailStore<ApplicationUser, int>;
            if (cast == null)
            {
                throw new NotSupportedException("not support");
            }
            return cast;
        }

        #endregion

        #region 
        public bool CanAccess(int userId, string areaName, string controllerName, string actionName, string dependencyActionNames)
        {
            var controller = controllerName.ToLower();

            var area = areaName;
            if (area.IsNotEmpty())
                area = area.ToLower();

            var actions = !dependencyActionNames.IsNotEmpty()
                ? new[] { actionName.ToLower() }
                : SplitString(dependencyActionNames);

            var rolesOfUser = CustomGetUserRoles(userId);
            var rolesOfPermission = _permissionService.GetRolesOfPermission(area, controller, actions);
            return rolesOfPermission.Intersect(rolesOfUser).Any() ||
                   _permissionService.HasDirectAccess(userId, area, controller, actions);
        }
        #endregion
      
        #region Private
        private static string[] SplitString(string dependencies)
        {
            if (dependencies == null) return new string[0];
            var split = from dependency in dependencies.Split(',')
                        let lowerDependency = dependency.ToLower()
                        where !string.IsNullOrEmpty(lowerDependency)
                        select lowerDependency;
            return split.ToArray();
        }
        #endregion

        #region IsEmailConfirmedByUserNameAsync
        public Task<bool> IsEmailConfirmedByUserNameAsync(string userName)
        {
            _unitOfWork.EnableFiltering(UserFilters.EmailConfirmedList);
            return _users.AnyAsync(a => a.UserName == userName);
        }

        #endregion
     
    }
}
