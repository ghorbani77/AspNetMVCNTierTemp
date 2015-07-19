using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using MVC5.Common.Controller;
using MVC5.Common.Filters;
using MVC5.Common.Helpers.Extentions;
using MVC5.DataLayer.Context;
using MVC5.DomainClasses.Entities;
using MVC5.ServiceLayer.Contracts;
using MVC5.ViewModel.Account;
using MVC5.ViewModel.AdminArea.User;
using MVC5.Web.Filters;
using System.Threading.Tasks;

namespace MVC5.Web.Controllers
{
    public partial class InstallController : BaseController
    {
        #region Fields

        private readonly IApplicationUserManager _userManager;
        private readonly IApplicationRoleManager _roleManager;
        private readonly IPermissionService _permissionService;
        private readonly ISettingService _settingService;
        private readonly IUnitOfWork _unitOfWork;

        #endregion

        #region Ctor

        public InstallController(IUnitOfWork unitOfWork, IApplicationRoleManager roleManager,
            IApplicationUserManager userManager, ISettingService settingService, IPermissionService permissionService)
        {
            _unitOfWork = unitOfWork;
            _permissionService = permissionService;
            _userManager = userManager;
            _roleManager = roleManager;
            _settingService = settingService;
        }

        #endregion

        #region PermissionConfiguration
        [NonAction]
        private async Task<IEnumerable<ApplicationPermission>> ConfigPermissions()
        {
            var controllers =
                Assembly.GetExecutingAssembly()
                    .GetTypes()
                    .Where(
                        t =>
                            t.BaseType == typeof(BaseController) &&
                            t.CustomAttributes.Any(a => a.AttributeType == typeof(MvcAuthorizeAttribute)))
                    .ToList();

            var addedPermissions = new List<string>();
            var permissionsListToAdd = new List<ApplicationPermission>();

            foreach (var controller in controllers)
            {
                var controllerName = controller.Name.Replace("Controller", "").ToLower();

                var authorizeAttribute =
                    controller.GetCustomAttributes(true).First(x => x is MvcAuthorizeAttribute) as MvcAuthorizeAttribute;

                if (authorizeAttribute == null)
                    continue;


                var areaName = authorizeAttribute.AreaName;
                if (areaName.HasValue())
                {
                    areaName = areaName.ToLower();
                }

                var parentPermission = new ApplicationPermission
                {
                    AreaName = areaName,
                    ControllerName = controllerName,
                    ActionName = authorizeAttribute.DefaultActioName,
                    IsMenu = authorizeAttribute.CanBeMenu,
                    ParentId = null,
                    Name = authorizeAttribute.Roles,
                    Description = authorizeAttribute.Description
                   
                };

                var actionMethodsList = controller.GetMethods()
                    .Where(x =>
                        x.CustomAttributes.Any(a => a.AttributeType == typeof(MvcAuthorizeAttribute)))
                    .Where(
                        x =>
                            (x.ReturnType == typeof(ActionResult) ||
                             x.ReturnType.BaseType == typeof(ActionResult)));

                permissionsListToAdd.Add(parentPermission);
                addedPermissions.Add(parentPermission.Name);

                foreach (var methodInfo in actionMethodsList)
                {
                    authorizeAttribute =
                        methodInfo.GetCustomAttributes(true).First(x => x is MvcAuthorizeAttribute) as
                            MvcAuthorizeAttribute;

                    if (authorizeAttribute == null) continue;

                    var methodName = methodInfo.Name.ToLower();

                    var childPermissionName =
                        authorizeAttribute.Roles.Split(',').FirstOrDefault(a => addedPermissions.All(b => b != a));

                    if (!childPermissionName.HasValue()) continue;

                    var childPermission = new ApplicationPermission
                    {
                        AreaName = areaName,
                        ControllerName = controllerName,
                        ActionName = methodName,
                        IsMenu = authorizeAttribute.CanBeMenu,
                        Parent = parentPermission,
                        Name = childPermissionName,
                        Description = authorizeAttribute.Description,
                        
                    };

                    addedPermissions.Add(childPermissionName);

                    permissionsListToAdd.Add(childPermission);

                }
            }
            _permissionService.AddRange(permissionsListToAdd);
            await _unitOfWork.SaveChangesAsync();

            return permissionsListToAdd;
        }
        #endregion

        #region StartInstall
        [HttpGet]
        public virtual ActionResult Start()
        {
            ToastrInformation("برای راه اندازی سیستم نیاز است اطلاعات زیر را وارد کنید", isSticky: true);
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        //[CheckReferrer]
        public virtual async Task<ActionResult> Start(InstallViewModel viewModel)
        {
            //if db created then redirect to home page

            Server.ScriptTimeout = 300;

            await _permissionService.RemoveAll();
            _userManager.DeleteAll();
            _roleManager.DeleteAll();

            var addedPermissions = await ConfigPermissions();

            await _roleManager.SeedDatabase(addedPermissions);
            await _userManager.SeedDatabase(viewModel);

            ToastrSuccess("عملیات نصب با موفقیت انجام شد");
            return RedirectToAction(MVC.Home.ActionNames.Index, MVC.Home.Name);
        }
        #endregion

    }
}