using System;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.UI;
using MVC5.Common.Controller;
using MVC5.Common.Filters;
using MVC5.DataLayer.Context;
using MVC5.ServiceLayer.Contracts;
using MVC5.ServiceLayer.Security;
using MVC5.ViewModel.AdminArea.User;
using MVC5.Web.Filters;
using WebGrease.Css.Extensions;

namespace MVC5.Web.Areas.Administrator.Controllers
{
    
    public partial class UserController : BaseController
    {
        #region Fields

        private readonly IPermissionService _permissionService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IApplicationUserManager _userManager;
        private readonly IApplicationRoleManager _roleManager;

        #endregion

        #region Constructor

        public UserController(IUnitOfWork unitOfWork, IPermissionService permissionService, IApplicationRoleManager roleManager,
            IApplicationUserManager userManager)
        {
            _unitOfWork = unitOfWork;
            _userManager = userManager;
            _roleManager = roleManager;
            _permissionService = permissionService;
        }

        #endregion

        #region List,ListAjax
        [HttpGet]
        [Mvc5Authorize(SystemPermissionNames.CanViewUsersList, AreaName = "Administrator", IsMenu = true)]
        [DisplayName("مشاهده لیست کاربران")]
        [ActivityLog(Name = "ViewUsers", Description = "مشاهده کاربران")]
        public virtual async Task<ActionResult> List()
        {
            await PopulateRoles();
            return View();
        }

        //[CheckReferrer]
        [Mvc5Authorize(SystemPermissionNames.CanViewUsersList)]
        [OutputCache(Location = OutputCacheLocation.None, NoStore = true)]
        public virtual ActionResult ListAjax(UserSearchViewModel search)
        {
            int total;
            var users = _userManager.GetPageList(out total, search);
            ViewBag.PageNumber = search.PageIndex;
            ViewBag.RoleIds = search.RoleIds;
            ViewBag.SearchCanChangeProfilePicture = search.SearchCanChangeProfilePicture;
            ViewBag.SearchCanModifyFirsAndLastName = search.SearchCanModifyFirsAndLastName;
            ViewBag.SearchCanUploadFile = search.SearchCanUploadFile;
            ViewBag.SearchCommentPermission = search.SearchCommentPermission;
            ViewBag.SearchEmail = search.SearchEmail;
            ViewBag.SearchFirstName = search.SearchNameForShow;
            ViewBag.SearchIp = search.SearchIp;
            ViewBag.SearchIsBanned = search.SearchIsBanned;
            ViewBag.SearchIsDeleted = search.SearchIsDeleted;
            ViewBag.SearchIsEmailConfirmed = search.SearchIsEmailConfirmed;
            ViewBag.SearchIsSystemAccount = search.SearchIsSystemAccount;
            ViewBag.SearchNameForShow = search.SearchNameForShow;
            ViewBag.SearchUserName = search.SearchUserName;
            ViewBag.TotalUsers = total;
            ViewBag.PageNumber = search.PageIndex;
            return PartialView(MVC.Administrator.User.Views.ViewNames._ListAjax, users);
        }
        #endregion

        #region Edit
        // [Route("Edit/{id}")]
        [HttpGet]
        [DisplayName("ویرایش کاربر")]
        [Mvc5Authorize(SystemPermissionNames.CanEditUser, AreaName = "Administrator")]
        [ActivityLog(Name = "EditUser", Description = "ویرایش کاربر")]
        public virtual async Task<ActionResult> Edit(int? id)
        {
            if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var viewModel = await _userManager.GetUserByRolesAsync(id.Value);
            if (viewModel == null) return HttpNotFound();
           await PopulateRoles(viewModel.Roles.Select(a => a.RoleId).ToArray());
            return View(viewModel);
        }

        [HttpPost]
        //  [Route("Edit/{id}")]
        //[CheckReferrer]
        [ValidateAntiForgeryToken]
        [Mvc5Authorize(SystemPermissionNames.CanEditUser)]
        public virtual async Task<ActionResult> Edit(EditUserViewModel viewModel, params int[] roleIds)
        {
            if (!ModelState.IsValid)
            {
                ToastrError("لطفا فیلد های مورد نظر را با دقت وارد کنید");
                await PopulateRoles(roleIds);
                return View(viewModel);
            }
            if (roleIds == null || roleIds.Length < 1)
            {
                ToastrWarning("لطفا برای کاربر مورد نظر ، گروه کاربری تعیین کنید");
                await PopulateRoles();
                return View(viewModel);
            }

            _userManager.EditUserWithRoles(viewModel, roleIds);

            await _unitOfWork.SaveChangesAsync();

            ToastrSuccess("عملیات  ویرایش کاربر با موفقیت انجام شد");
            return RedirectToAction(MVC.Administrator.User.ActionNames.List, MVC.Administrator.User.Name);
        }

        #endregion

        #region Create

        [HttpGet]
        [DisplayName("ثبت کاربر جدید")]
        [Mvc5Authorize(SystemPermissionNames.CanCreateUser, AreaName = "Administrator", IsMenu = true)]
        [ActivityLog(Name = "AddUser", Description = "درج کاربر جدید")]
        public virtual async Task<ActionResult> Create()
        {
            await PopulateRoles();
            await PopulatePermissions();
            var viewModel = new AddUserViewModel
            {
                CanUploadFile = true,
                CanModifyFirsAndLastName = true,
                CanChangeProfilePicture = true
            };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Mvc5Authorize(SystemPermissionNames.CanCreateUser)]
        [AllowUploadSpecialFilesOnly(".jpg,.png,.gif", true)]
        //[CheckReferrer]
        public virtual async Task<ActionResult> Create(AddUserViewModel viewModel)
        {
            var avatarName = "avatar.jpg";
            if (!ModelState.IsValid)
            {
                ToastrError("لطفا فیلد های مورد نظر را با دقت وارد کنید");
                await PopulateRoles(viewModel.RoleIds);
                await PopulatePermissions(viewModel.PermissionIds);
                return View(viewModel);
            }
            if (viewModel.RoleIds == null || viewModel.RoleIds.Length < 1)
            {
                ToastrWarning("لطفا برای  کاربر مورد نظر ، گروه کاربری تعیین کنید");
                await PopulateRoles();
                await PopulatePermissions();
                return View(viewModel);
            }
            if (viewModel.AvatarImage != null && viewModel.AvatarImage.ContentLength > 0)
            {
                avatarName = this.UploadFile(viewModel.AvatarImage);
            }
            viewModel.AvatarFileName = avatarName;
            await _userManager.AddUser(viewModel);
            ToastrSuccess("عملیات ثبت  کاربر جدید با موفقیت انجام شد");
            return RedirectToAction(MVC.Administrator.User.ActionNames.List, MVC.Administrator.User.Name);
        }

        #endregion

        #region SoftDelete

        [HttpPost]
        [Route("SoftDelete/{id}")]
        [AjaxOnly]
        [ValidateAntiForgeryToken]
        //[CheckReferrer]
        [Mvc5Authorize(SystemPermissionNames.CanSoftDeleteUser)]
        [DisplayName("حذف منطقی کاربر")]
        [ActivityLog(Name = "SoftDeleteUser")]
        public virtual async Task<ActionResult> SoftDelete(int? id)
        {
            if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            if (!await _userManager.LogicalRemove(id.Value))
            {
                ToastrWarning("این  کاربر ، کاربر سیستمی است و حذف آن باعث اختلال در سیستم خواهد شد");
                return RedirectToAction(MVC.Administrator.User.ActionNames.List, MVC.Administrator.User.Name);
            }
            ToastrSuccess("کاربر مورد نظر با موفقیت حذف شد");
            return RedirectToAction(MVC.Administrator.User.ActionNames.List, MVC.Administrator.User.Name);

        }

        #endregion

        #region Delete
        //[HttpPost]
        //[Route("SoftDelete/{id}")]
        //[AjaxOnly]
        //[ValidateAntiForgeryToken]
        ////[CheckReferrer]
        ////[MvcAuthorize( Roles = "CanSoftDeleteUser")]
        //[ActivityLog(Name = "SoftDeleteUser")]
        //public virtual async Task<ActionResult> SoftDelete(int? id)
        //{
        //    if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    if (!await _userManager.LogicalRemove(id.Value))
        //    {
        //        ToastrWarning("این  کاربر ، کاربر سیستمی است و حذف آن باعث اختلال در سیستم خواهد شد");
        //        return RedirectToAction(MVC.Administrator.User.ActionNames.List, MVC.Administrator.User.Name);
        //    }
        //    ToastrSuccess("کاربر مورد نظر با موفقیت حذف شد");
        //    return RedirectToAction(MVC.Administrator.User.ActionNames.List, MVC.Administrator.User.Name);

        //}
        #endregion

        #region RemoteValidations

        [HttpPost]
        [AjaxOnly]
        //[CheckReferrer]
        [Mvc5Authorize(SystemPermissionNames.CanEditUser,SystemPermissionNames.CanCreateUser)]
        [OutputCache(NoStore = true, Duration = 0, VaryByParam = "*")]
        public virtual JsonResult UserNameExist(string userName, int? id)
        {
            return _userManager.CheckUserNameExist(userName, id) ? Json(false) : Json(true);
        }

      

        [HttpPost]
        [AjaxOnly]
        //[CheckReferrer]
        [Mvc5Authorize(SystemPermissionNames.CanEditUser, SystemPermissionNames.CanCreateUser)]
        [OutputCache(NoStore = true, Duration = 0, VaryByParam = "*")]
        public virtual JsonResult LastNameForShowExist(string nameForShow, int? id)
        {
            return _userManager.CheckNameForShowExist(nameForShow, id) ? Json(false) : Json(true);
        }

        [HttpPost]
        [AjaxOnly]
        //[CheckReferrer]
        [Mvc5Authorize(SystemPermissionNames.CanEditUser, SystemPermissionNames.CanCreateUser)]
        [OutputCache(NoStore = true, Duration = 0, VaryByParam = "*")]
        public virtual JsonResult EmailExist(string email, int? id)
        {
            return _userManager.CheckEmailExist(email, id) ? Json(false) : Json(true);
        }

        [HttpPost]
        [AjaxOnly]
        // [CheckReferrer]
        [Mvc5Authorize(SystemPermissionNames.CanEditUser, SystemPermissionNames.CanCreateUser)]
        [OutputCache(NoStore = true, Duration = 0, VaryByParam = "*")]
        public virtual JsonResult PhoneNumberExist(string phoneNumber, int? id)
        {
            return _userManager.CheckPhoneNumberExist(phoneNumber, id) ? Json(false) : Json(true);
        }


        [HttpPost]
        [AjaxOnly]
        //[CheckReferrer]
        [Mvc5Authorize(SystemPermissionNames.CanEditUser, SystemPermissionNames.CanCreateUser)]
        [OutputCache(NoStore = true, Duration = 0, VaryByParam = "*")]
        public virtual JsonResult GooglePlusIdExist(string googlePlusId, int? id)
        {
            return _userManager.CheckGooglePlusIdExist(googlePlusId, id) ? Json(false) : Json(true);
        }


        [HttpPost]
        [AjaxOnly]
        //[CheckReferrer]
        [Mvc5Authorize(SystemPermissionNames.CanEditUser, SystemPermissionNames.CanCreateUser)]
        [OutputCache(NoStore = true, Duration = 0, VaryByParam = "*")]
        public virtual JsonResult FaceBookIdExist(string faceBookId, int? id)
        {
            return _userManager.CheckFacebookIdExist(faceBookId, id) ? Json(false) : Json(true);
        }

        #endregion

        #region Private
        [NonAction]
        private async Task PopulateRoles(params int[] selectedIds)
        {
            var roles = await _roleManager.GetAllAsSelectList();

            if (selectedIds != null)
            {
                roles.ForEach(a => a.Selected = selectedIds.Any(b => int.Parse(a.Value) == b));
            }

            ViewBag.Roles = roles;
        }

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