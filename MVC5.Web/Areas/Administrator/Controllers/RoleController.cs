
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;
using AutoMapper;
using MVC5.Common.Controller;
using MVC5.Common.Filters;
using MVC5.Common.Helpers.Json;
using MVC5.DataLayer.Context;
using MVC5.ServiceLayer.Contracts;
using MVC5.ViewModel.AdminArea.Role;
using MVC5.Web.Filters;
using WebGrease.Css.Extensions;

namespace MVC5.Web.Areas.Administrator.Controllers
{
    //[RouteArea("Panel")]
    //[RoutePrefix("Roles")]
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

        #region List

        [HttpGet]
      //  [Route("List")]
       // [MvcAuthorize(Description = "مشاهده لیست گروه های کاربری",
       //Roles = "CanManageRoles,CanViewRoles", CanBeMenu = true)]
        [ActivityLog(Name = "ViewRoles", Description = "مشاده گروه های کاربری")]
        public virtual async Task<ActionResult> List()
        {
            var viewModel = await _roleManager.GetList();
            return View(viewModel);
        }

        #endregion

        #region Create

        [HttpGet]
       // [Route("Create")]
        //[MvcAuthorize(Description = "درج گروه کاربری جدید", Roles = "CanManageRoles,CanCreateRole", CanBeMenu = true)]
        [ActivityLog(Name = "CreateRole", Description = "درج گروه کاربری")]
        public virtual async Task<ActionResult> Create()
        {
            var viewModel = new AddRoleViewModel();
            await Populatepermissions();
            return View(viewModel);
        }
        [HttpPost]
        //[Route("Create")]
        [ValidateAntiForgeryToken]
        //[CheckReferrer]
        //[MvcAuthorize( Roles = "CanManageRoles,CanCreateRole", CanBeMenu = true)]
        public virtual async Task<ActionResult> Create(AddRoleViewModel viewModel, params int[] permissionIds)
        {
            if (!ModelState.IsValid)
            {
                ToastrError("لطفا فیلد های مورد نظر را با دقت وارد کنید");
                await Populatepermissions(permissionIds);
                return View(viewModel);
            }
            if (permissionIds == null)
            {
                ToastrWarning("لطفا برای گروه کاربری مورد نظر ، دسترسی تعیین کنید");
                await Populatepermissions();
                return View(viewModel);
            }

             _roleManager.AddRoleWithPermissions(viewModel, permissionIds);

            ToastrSuccess("عملیات ثبت گروه کاربری جدید با موفقیت انجام شد");
            return RedirectToAction(MVC.Administrator.Role.ActionNames.List, MVC.Administrator.Role.Name);
        }

        #endregion

        #region Edit

        [HttpGet]
        //[MvcAuthorize(Description = "ویرایش گروه کاربری", Roles = "CanManageRoles,CanEditRole", CanBeMenu = false)]
        [ActivityLog(Name = "EditRole", Description = " ویرایش گروه کاربری")]
        [Route("Edit/{id}")]
        public virtual async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            var viewModel = await _roleManager.GetRoleByPermissions(id.Value);
            if (viewModel == null)
                return HttpNotFound();
            await Populatepermissions(viewModel.Permissions.Select(a => a.Id).ToArray());
            return View(viewModel);
        }
        [Route("Edit/{id}")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        //[CheckReferrer]
        //[MvcAuthorize(Roles = "CanManageRoles,CanEditRole", CanBeMenu = false)]
        public virtual async Task<ActionResult> Edit(EditRoleViewModel viewModel, params int[] permissionIds)
        {
            if (!ModelState.IsValid)
            {
                ToastrError("لطفا فیلد های مورد نظر را با دقت وارد کنید");
                await Populatepermissions(permissionIds);
                return View(viewModel);
            }
            if (permissionIds == null)
            {
                ToastrWarning("لطفا برای گروه کاربری مورد نظر ، دسترسی تعیین کنید");
                await Populatepermissions();
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
        [Route("Delete/{id}")]
        [ValidateAntiForgeryToken]
        [CheckReferrer]
        [MvcAuthorize(Description = "حذف گروه کاربری", Roles = "CanManageRoles,CanDeleteRole", CanBeMenu = false)]
        [ActivityLog(Name = "DeleteRole", Description = " حذف گروه کاربری")]
        public virtual ActionResult Delete(int? id)
        {
            return View();
        }

        #endregion

        #region SetAsDefaultRegisterRole
        [MvcAuthorize(Description = "انتخاب گروه کاربری پیشفرض برای ثبت نام کاربران ", Roles = "CanSetRoleForRegister",
   CanBeMenu = false)]
        [Route("SetForRegister/{id}")]
        [ActivityLog(Name = "SetDefaultRoleForRegister", Description = "انتخاب گروه کاربری پیشفرض برای ثبت نام کاربران")]
        public virtual async Task<JsonResult> SetRoleForRegister(int? id)
        {

            await _unitOfWork.SaveChangesAsync();
            return Json(true);
        }
        #endregion

        #region RemoteValidation

        [HttpPost]
        [AjaxOnly]
        //[Route("RoleNameExist/{name}/{id}")]
        //[MvcAuthorize(Roles = "CanManageRoles,CanEditRole,CanCreateRole",
        //    CanBeMenu = false)]
        [OutputCache(NoStore = true, Duration = 0, VaryByParam = "*")]
        public virtual JsonResult RoleNameExist(string name, int? id)
        {
            return Json(true);
        }

        #endregion

        #region Private
        [NonAction]
        private async Task Populatepermissions(params int[] selectedIds)
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