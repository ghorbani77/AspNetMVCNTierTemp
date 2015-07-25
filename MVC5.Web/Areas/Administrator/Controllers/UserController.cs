using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.UI;
using MVC5.Common.Controller;
using MVC5.Common.Filters;
using MVC5.DataLayer.Context;
using MVC5.ServiceLayer.Contracts;
using MVC5.ViewModel.AdminArea.User;
using MVC5.Web.Filters;
using WebGrease.Css.Extensions;

namespace MVC5.Web.Areas.Administrator.Controllers
{
    //[MvcAuthorize]
    [DisplayName("مدیریت کاربران")]
    public partial class UserController : BaseController
    {
        #region Fields

        private readonly IUnitOfWork _unitOfWork;
        private readonly IApplicationUserManager _userManager;
        private readonly IApplicationRoleManager _roleManager;

        #endregion

        #region Constructor

        public UserController(IUnitOfWork unitOfWork, IApplicationRoleManager roleManager,
            IApplicationUserManager userManager)
        {
            _unitOfWork = unitOfWork;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        #endregion

        #region List,ListAjax
        [HttpGet]
        [DisplayName("مشاهده لیست کاربران")]
        [ActivityLog(Name = "ViewUsers", Description = "مشاهده کاربران")]
        public virtual async Task<ActionResult> List()
        {
            await PopulateRoles();
            return View();
        }


        [OutputCache(Location = OutputCacheLocation.None, NoStore = true)]
        [ChildActionOnly]
        public virtual ActionResult ListAjax(UserSearchViewModel search)
        {
            int total;
            var users = _userManager.GetPageList(out total, search);
            ViewBag.TotalUsers = total;
            ViewBag.PageNumber = search.PageIndex;
            return PartialView(MVC.Administrator.User.Views.ViewNames._ListAjax, users);
        }
        #endregion

        #region Edit
        [Route("Edit/{id}")]
        [HttpGet]
        [DisplayName("ویرایش کاربر")]
        [ActivityLog(Name = "EditUser", Description = "ویرایش کاربر")]
        public virtual async Task<ActionResult> Edit(int? id)
        {
            if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var viewModel = await _userManager.GetUserByRoles(id.Value);
            if (viewModel == null) return HttpNotFound();
            await PopulateRoles(viewModel.Roles.Select(a => a.RoleId).ToArray());
            return View(viewModel);
        }

        [HttpPost]
        [Route("Edit/{id}")]
        //[CheckReferrer]
        [ValidateAntiForgeryToken]
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
        [ActivityLog(Name = "AddUser", Description = "درج کاربر جدید")]
        public virtual async Task<ActionResult> Create()
        {
            await PopulateRoles();
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
        //[CheckReferrer]
        public virtual async Task<ActionResult> Create(AddUserViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                ToastrError("لطفا فیلد های مورد نظر را با دقت وارد کنید");
                await PopulateRoles(viewModel.RoleIds);
                return View(viewModel);
            }
            if (viewModel.RoleIds == null || viewModel.RoleIds.Length < 1)
            {
                ToastrWarning("لطفا برای  کاربر مورد نظر ، گروه کاربری تعیین کنید");
                await PopulateRoles();
                return View(viewModel);
            }

            _userManager.AddUserWithRoles(viewModel);
            await _unitOfWork.SaveChangesAsync();
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
        [CheckReferrer]
      //  [MvcAuthorize(DependencyActionNames = "Edit,Create")]
        [OutputCache(NoStore = true, Duration = 0, VaryByParam = "*")]
        public virtual JsonResult UserNameExist(string userName, int? id)
        {
            return _userManager.CheckUserNameExist(userName, id) ? Json(false) : Json(true);
        }

        [HttpPost]
        [AjaxOnly]
        [CheckReferrer]
        //  [MvcAuthorize(DependencyActionNames = "Edit,Create")]
        [OutputCache(NoStore = true, Duration = 0, VaryByParam = "*")]
        public virtual JsonResult FirstNameExist(string firstName, int? id)
        {
            return _userManager.CheckFirstNameExist(firstName, id) ? Json(false) :
            Json(true);
        }

        [HttpPost]
        [AjaxOnly]
        [CheckReferrer]
        //  [MvcAuthorize(DependencyActionNames = "Edit,Create")]
        [OutputCache(NoStore = true, Duration = 0, VaryByParam = "*")]
        public virtual JsonResult LastNameExist(string lastName, int? id)
        {
            return _userManager.CheckLastNameExist(lastName, id) ? Json(false) : Json(true);
        }

        [HttpPost]
        [AjaxOnly]
        [CheckReferrer]
        //  [MvcAuthorize(DependencyActionNames = "Edit,Create")]
        [OutputCache(NoStore = true, Duration = 0, VaryByParam = "*")]
        public virtual JsonResult EmailExist(string email, int? id)
        {
            return _userManager.CheckEmailExist(email, id) ? Json(false) : Json(true);
        }

        [HttpPost]
        [AjaxOnly]
        [CheckReferrer]
        //  [MvcAuthorize(DependencyActionNames = "Edit,Create")]
        [OutputCache(NoStore = true, Duration = 0, VaryByParam = "*")]
        public virtual JsonResult PhoneNumberExist(string phoneNumber, int? id)
        {
            return _userManager.CheckPhoneNumberExist(phoneNumber, id) ? Json(false) : Json(true);
        }


        [HttpPost]
        [AjaxOnly]
        [CheckReferrer]
        //  [MvcAuthorize(DependencyActionNames = "Edit,Create")]
        [OutputCache(NoStore = true, Duration = 0, VaryByParam = "*")]
        public virtual JsonResult GooglePlusIdExist(string googlePlusId, int? id)
        {
            return _userManager.CheckGooglePlusIdExist(googlePlusId, id) ? Json(false) : Json(true);
        }


        [HttpPost]
        [AjaxOnly]
        [CheckReferrer]
        //  [MvcAuthorize(DependencyActionNames = "Edit,Create")]
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
        #endregion
    }
}