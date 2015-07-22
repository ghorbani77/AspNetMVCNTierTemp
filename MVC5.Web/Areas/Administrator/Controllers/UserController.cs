using System.Web.Mvc;
using MVC5.Common.Controller;
using MVC5.Common.Filters;
using MVC5.Common.Helpers.Json;
using MVC5.DataLayer.Context;
using MVC5.ServiceLayer.Contracts;
using MVC5.ViewModel.AdminArea.User;
using MVC5.Web.Filters;

namespace MVC5.Web.Areas.Administrator.Controllers
{
    [RouteArea("Panel")]
    [RoutePrefix("Users")]
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

        #region List
        [Route("List")]
        [HttpGet]
        [MvcAuthorize(Description = "مشاهده کاربران", Roles = "CanManageUsers,CanViewUsers",
            CanBeMenu = true)]
        [ActivityLog(Name = "ViewUsers", Description = "مشاهده کاربران")]
        public virtual ActionResult List()
        {
            return View();
        }

        #endregion

        #region Edit
        [Route("Edit/{id}")]
        [HttpGet]
        [MvcAuthorize(Description = "ویرایش کاربر", Roles = "CanManageUsers,CanEditUser",
            CanBeMenu = false)]
        [ActivityLog(Name = "EditUser", Description = "ویرایش کاربر")]
        public virtual ActionResult Edit(int? id)
        {
            return View();
        }

        [HttpPost]
        [Route("Edit/{id}")]
        [CheckReferrer]
        [ValidateAntiForgeryToken]
        [MvcAuthorize( Roles = "CanManageUsers,CanEditUser",
            CanBeMenu = false)]
        public virtual ActionResult Edit(EditUserViewModel viewModel)
        {
            return View();
        }

        #endregion

        #region Create

        [HttpGet]
        [Route("Create")]
        [MvcAuthorize(Description = "درج کاربر جدید", Roles = "CanManageUsers,CanCreateUser",
            CanBeMenu = true)]
        [ActivityLog(Name = "AddUser", Description = "درج کاربر جدید")]
        public virtual ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [CheckReferrer]
        [Route("Create")]
        [ValidateAntiForgeryToken]
        [MvcAuthorize( Roles = "CanManageUsers,CanCreateUser",
            CanBeMenu = true)]
        public virtual ActionResult Create(AddUserViewModel viewModel)
        {
            return View();
        }

        #endregion

        #region Delete

        [HttpPost]
        [Route("Delete")]
        [CheckReferrer]
        [ValidateAntiForgeryToken]
        [MvcAuthorize(Description = "حذف کاربر", Roles = "CanManageUsers,CanDeleteUser",
            CanBeMenu = false)]
        [ActivityLog(Name = "DeleteUser", Description = "حذف کاربر")]
        public virtual ActionResult Delete(int id)
        {
            return View();
        }

        #endregion

        #region RemoteValidations

        [HttpPost]
        [AjaxOnly]
        [MvcAuthorize(
            Roles = "CanManageUsers,CanEditUser,CanCreateUser",
            CanBeMenu = false)]
        [OutputCache(NoStore = true, Duration = 0, VaryByParam = "*")]
        public virtual JsonResult UserNameExist(string userName, int? id)
        {
            return new JsonNetResult();
        }

        [HttpPost]
        [AjaxOnly]
        [MvcAuthorize(
            Roles = "CanManageUsers,CanEditUser,CanCreateUser",
            CanBeMenu = false)]
        [OutputCache(NoStore = true, Duration = 0, VaryByParam = "*")]
        public virtual JsonResult FirstNameExist(string firstName, int? id)
        {
            return new JsonNetResult();
        }

        [HttpPost]
        [AjaxOnly]
        [MvcAuthorize(
            Roles = "CanManageUsers,CanEditUser,CanCreateUser",
            CanBeMenu = false)]
        [OutputCache(NoStore = true, Duration = 0, VaryByParam = "*")]
        public virtual JsonResult LastNameExist(string lastName, int? id)
        {
            return new JsonNetResult();
        }

        [HttpPost]
        [AjaxOnly]
        [MvcAuthorize(
            Roles = "CanManageUsers,CanEditUser,CanCreateUser",
            CanBeMenu = false)]
        [OutputCache(NoStore = true, Duration = 0, VaryByParam = "*")]
        public virtual JsonResult EmailExist(string email, int? id)
        {
            return new JsonNetResult();
        }

        [HttpPost]
        [AjaxOnly]
        [MvcAuthorize(
            Roles = "CanManageUsers,CanEditUser,CanCreateUser",
            CanBeMenu = false)]
        [OutputCache(NoStore = true, Duration = 0, VaryByParam = "*")]
        public virtual JsonResult PhoneNumberExist(string phoneNumber, int? id)
        {
            return new JsonNetResult();
        }


        [HttpPost]
        [AjaxOnly]
        [MvcAuthorize(
            Roles = "CanManageUsers,CanEditUser,CanCreateUser",
            CanBeMenu = false)]
        [OutputCache(NoStore = true, Duration = 0, VaryByParam = "*")]
        public virtual JsonResult GooglePlusIdExist(string phoneNumber, int? id)
        {
            return new JsonNetResult();
        }


        [HttpPost]
        [AjaxOnly]
        [MvcAuthorize(
            Roles = "CanManageUsers,CanEditUser,CanCreateUser",
            CanBeMenu = false)]
        [OutputCache(NoStore = true, Duration = 0, VaryByParam = "*")]
        public virtual JsonResult FaceBookIdExist(string phoneNumber, int? id)
        {
            return new JsonNetResult();
        }

        #endregion

    }
}