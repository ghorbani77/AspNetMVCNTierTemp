using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.UI;
using AutoMapper;
using MVC5.Common.Controller;
using MVC5.Common.Filters;
using MVC5.DataLayer.Context;
using MVC5.ServiceLayer.Contracts;
using MVC5.ServiceLayer.Security;
using MVC5.ViewModel.AdminArea.Role;
using MVC5.Web.Filters;
using WebGrease.Css.Extensions;

namespace MVC5.Web.Areas.Administrator.Controllers
{

    public partial class RoleController : BaseController
    {
        #region Fields

        private readonly IMappingEngine _mappingEngine;
        private readonly IPermissionService _permissionService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IApplicationRoleManager _roleManager;
        private readonly IApplicationUserManager _userManager;

        #endregion

        #region Const

        public RoleController(IUnitOfWork unitOfWork, IApplicationRoleManager roleManager, IPermissionService permissionService,
            IApplicationUserManager userManager, IMappingEngine mappingEngine)
        {
            _unitOfWork = unitOfWork;
            _roleManager = roleManager;
            _userManager = userManager;
            _permissionService = permissionService;
            _mappingEngine = mappingEngine;
        }

        #endregion

        #region ListAjax , List
        [HttpGet]
        [Mvc5Authorize(SystemPermissionNames.CanViewRolesList, AreaName = "Administrator", IsMenu = true)]
        [DisplayName("مشاهده لیست گروه های کاربری")]
        [ActivityLog(Name = "ViewRoles", Description = "مشاده گروه های کاربری")]
        public virtual ActionResult List()
        {
            return View();
        }

        //[CheckReferrer]
        [Mvc5Authorize( SystemPermissionNames.CanViewRolesList, AreaName = "Administrator", IsMenu = true)]
        [OutputCache(Location = OutputCacheLocation.None, NoStore = true)]
        public virtual ActionResult ListAjax(string term = "", int page = 1)
        {
            int total;
            var roles = _roleManager.GetPageList(out total, term, page, 5);
            ViewBag.TotalRoles = total;
            ViewBag.PageNumber = page;
            return PartialView(MVC.Administrator.Role.Views.ViewNames._ListAjax, roles);
        }
        #endregion

        #region Create

        [HttpGet]
        [Mvc5Authorize( SystemPermissionNames.CanCreateRole, AreaName = "Administrator", IsMenu = true)]
        [DisplayName("ثبت گروه کاربری جدید")]
        [ActivityLog(Name = "CreateRole", Description = "درج گروه کاربری")]
        public virtual async Task<ActionResult> Create()
        {
            var viewModel = new AddRoleViewModel
            {
                IsActive = true
            };
            await PopulatePermissions();
            return View(viewModel);
        }
        [HttpPost]
        [Mvc5Authorize(SystemPermissionNames.CanCreateRole)]
        [ValidateAntiForgeryToken]
        //[CheckReferrer]
        public virtual async Task<ActionResult> Create(AddRoleViewModel viewModel, params int[] permissionIds)
        {
            if (!ModelState.IsValid)
            {
                ToastrError("لطفا فیلد های مورد نظر را با دقت وارد کنید");
                await PopulatePermissions(permissionIds);
                return View(viewModel);
            }
            if (permissionIds == null)
            {
                ToastrWarning("لطفا برای گروه کاربری مورد نظر ، دسترسی تعیین کنید");
                await PopulatePermissions();
                return View(viewModel);
            }
            _roleManager.AddRoleWithPermissions(viewModel, permissionIds);
            ToastrSuccess("عملیات ثبت گروه کاربری جدید با موفقیت انجام شد");
            return RedirectToAction(MVC.Administrator.Role.ActionNames.List, MVC.Administrator.Role.Name);
        }

        #endregion

        #region Edit
        [HttpGet]
        [DisplayName("ویرایش گروه کاربری")]
        [Mvc5Authorize(SystemPermissionNames.CanEditRole, AreaName = "Administrator", IsMenu = false)]
        [ActivityLog(Name = "EditRole", Description = " ویرایش گروه کاربری")]
        //[Route("Edit/{id}")]
        public virtual async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            var viewModel = await _roleManager.GetRoleByPermissions(id.Value);
            if (viewModel == null)
                return HttpNotFound();
            await PopulatePermissions(viewModel.Permissions.Select(a => a.Id).ToArray());
            return View(viewModel);
        }

        //[Route("Edit/{id}")]
        [Mvc5Authorize(SystemPermissionNames.CanEditRole)]
        [HttpPost]
        [ValidateAntiForgeryToken]
        //[CheckReferrer]
        public virtual async Task<ActionResult> Edit(EditRoleViewModel viewModel, params int[] permissionIds)
        {
            if (!ModelState.IsValid)
            {
                ToastrError("لطفا فیلد های مورد نظر را با دقت وارد کنید");
                await PopulatePermissions(permissionIds);
                return View(viewModel);
            }
            if (permissionIds == null || permissionIds.Length < 1)
            {
                ToastrWarning("لطفا برای گروه کاربری مورد نظر ، دسترسی تعیین کنید");
                await PopulatePermissions();
                return View(viewModel);
            }

            _roleManager.EditRoleWithPermissions(viewModel, permissionIds);
            await _unitOfWork.SaveChangesAsync();

            ToastrSuccess("عملیات ویرایش گروه کاربری  با موفقیت انجام شد");
            return RedirectToAction(MVC.Administrator.Role.ActionNames.List, MVC.Administrator.Role.Name);
        }

        #endregion

        #region Delete

        [HttpPost]
        //[Route("Delete/{id}")]
        [ValidateAntiForgeryToken]
        //[CheckReferrer]
        [Mvc5Authorize(SystemPermissionNames.CanDeleteRole, AreaName = "Administrator", IsMenu = false)]
        [DisplayName("حذف گروه کاربری")]
        [ActivityLog(Name = "DeleteRole", Description = " حذف گروه کاربری")]
        public virtual async Task<ActionResult> Delete(int? id)
        {
            if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            if (await _roleManager.CheckRoleIsSystemRoleAsync(id.Value))
            {
                ToastrWarning("این گروه کاربری سیستمی است و حذف آن باعث اختلال در سیستم خواهد شد");
                return RedirectToAction(MVC.Administrator.Role.ActionNames.List, MVC.Administrator.Role.Name);
            }
            await _roleManager.RemoveById(id.Value);
            ToastrSuccess("گروه مورد نظر با موفقیت حذف شد");
            return RedirectToAction(MVC.Administrator.Role.ActionNames.List, MVC.Administrator.Role.Name);
        }

        #endregion

        #region SetAsDefaultRegisterRole
        [HttpPost]
        [AjaxOnly]
        [ValidateAntiForgeryToken]
        //[CheckReferrer]
        [Mvc5Authorize(SystemPermissionNames.CanSetDefaultRoleForRegister, AreaName = "Administrator", IsMenu = false)]
        [DisplayName("تغییر گروه کاربری پیش فرض")]
        [Route("SetForRegister/{id}")]
        [ActivityLog(Name = "SetDefaultRoleForRegister", Description = "انتخاب گروه کاربری پیشفرض برای ثبت نام کاربران")]
        public virtual async Task<ActionResult> SetRoleForRegister(int? id)
        {
            if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            await _roleManager.SetRoleAsRegistrationDefaultRoleAsync(id.Value);
            await _unitOfWork.SaveChangesAsync();
            ToastrSuccess("گروه کاربری مورد نظر با موفقیت به عنوان گروه کاربری پیشفرض ثبت نام انتخاب شد");
            return RedirectToAction(MVC.Administrator.Role.ActionNames.List, MVC.Administrator.Role.Name);
        }
        #endregion

        #region RemoteValidation

        [HttpPost]
        [AjaxOnly]
        // [CheckReferrer]
        [Mvc5Authorize(SystemPermissionNames.CanCreateRole, SystemPermissionNames.CanEditRole)]
        [OutputCache(NoStore = true, Duration = 0, VaryByParam = "*")]
        public virtual JsonResult RoleNameExist(string name, int? id)
        {
            return _roleManager.ChechForExisByName(name, id) ? Json(false) : Json(true);
        }

        #endregion

        #region Private
        [NonAction]
        private async Task PopulatePermissions(params int[] selectedIds)
        {
            var permissions = await _permissionService.GetAsSelectList();

            if (selectedIds != null)
            {
                permissions.ForEach(a => a.Selected = selectedIds.Any(b => int.Parse(a.Value) == b));
            }

            ViewBag.Permissions = permissions;
        }

        #endregion
    }
}