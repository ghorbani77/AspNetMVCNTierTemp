using System.Web.Mvc;
using MVC5.Common.Filters;
using MVC5.Common.Helpers;
using MVC5.Common.Helpers.Json;
using MVC5.DataLayer.Context;
using MVC5.ServiceLayer.Contracts;
using MVC5.ViewModel.AdminArea.User;
using MVC5.Web.Filters;

namespace MVC5.Web.Areas.Adminstrator.Controllers
{
   // [MvcAuthorize(Description = "مشاهده کاربران", Roles = "CanManageUsers",  CanBeMenu = true)]
    public partial class UserController : Controller
    {
        #region Fields

        private readonly IUnitOfWork _unitOfWork;
        private readonly IApplicationUserManager _userManager;
        private readonly IApplicationRoleManager _roleManager;
        #endregion

        #region Constructor

        public UserController(IUnitOfWork unitOfWork, IApplicationRoleManager roleManager, IApplicationUserManager userManager)
        {
            _unitOfWork = unitOfWork;
            _userManager = userManager;
            _roleManager = roleManager;
        }
        #endregion

        #region List

        [HttpGet]
        //[MvcAuthorize(Description = "مشاهده کاربران", Roles = "CanManageUsers,CanDeleteUser,CanCreateUser,CanEditUser,CanViewUsers",
        //    CanBeMenu = true)]
        [ActivityLog(Name = "ViewUsers", Description = "مشاهده کاربران")]
        public virtual ActionResult List()
        {
            return View();
        }

        #endregion

        #region Edit
        [HttpGet]
        [MvcAuthorize(Description = "ویرایش کاربر", Roles = "CanManageUsers,CanEditUser",
            CanBeMenu = false)]
        [ActivityLog(Name = "EditUser", Description = "ویرایش کاربر")]
        public virtual ActionResult Edit()
        {
            return View();
        }

        [HttpPost]
        [CheckReferrer]
        [ValidateAntiForgeryToken]
        [MvcAuthorize(Description = "ویرایش کاربر", Roles = "CanManageUsers,CanEditUser",
            CanBeMenu = false)]
        public virtual ActionResult Edit(EditUserViewModel viewModel)
        {
            return View();
        }

        #endregion

        #region Create
        [HttpGet]
        [MvcAuthorize(Description = "درج کاربر جدید", Roles = "CanManageUsers,CanCreateUser",
            CanBeMenu = true)]
        [ActivityLog(Name = "AddUser", Description = "درج کاربر جدید")]
        public virtual ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [CheckReferrer]
        [ValidateAntiForgeryToken]
        [MvcAuthorize(Description = "درج کاربر جدید", Roles = "CanManageUsers,CanCreateUser",
         CanBeMenu = false)]
        public virtual ActionResult Create(AddUserViewModel viewModel)
        {
            return View();
        }
        #endregion

        #region Delete
          
        [HttpPost]
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
        [MvcAuthorize(Description = "چک کردن نام کاربری",
            Roles = "CanManageUsers,CanEditUser,CanCreateUser",
            CanBeMenu = false)]
        public virtual JsonResult UserNameExist(string userName, int? id)
        {
            return new JsonNetResult();
        }

        [HttpPost]
        [AjaxOnly]
        [MvcAuthorize(Description = "چک کردن نام کاربر",
            Roles = "CanManageUsers,CanEditUser,CanCreateUser",
            CanBeMenu = false)]
        public virtual JsonResult FirstNameExist(string firstName, int? id)
        {
            return new JsonNetResult();
        }

        [HttpPost]
        [AjaxOnly]
        [MvcAuthorize(Description = "چک کردن نام خانوادگی کاربر",
            Roles = "CanManageUsers,CanEditUser,CanCreateUser",
            CanBeMenu = false)]
        public virtual JsonResult LastNameExist(string lastName, int? id)
        {
            return new JsonNetResult();
        }

        [HttpPost]
        [AjaxOnly]
        [MvcAuthorize(Description = "چک کردن ایمیل",
            Roles = "CanManageUsers,CanEditUser,CanCreateUser",
            CanBeMenu = false)]
        public virtual JsonResult EmailExist(string email, int? id)
        {
            return new JsonNetResult();
        }

        [HttpPost]
        [AjaxOnly]
        [MvcAuthorize(Description = "چک کردن شماره همراه",
            Roles = "CanManageUsers,CanEditUser,CanCreateUser",
            CanBeMenu = false)]
        public virtual JsonResult PhoneNumberExist(string phoneNumber, int? id)
        {
            return new JsonNetResult();
        }


        [HttpPost]
        [AjaxOnly]
        [MvcAuthorize(Description = "چک کردن آی دی گوگل پلاس",
            Roles = "CanManageUsers,CanEditUser,CanCreateUser",
            CanBeMenu = false)]
        public virtual JsonResult GooglePlusIdExist(string phoneNumber, int? id)
        {
            return new JsonNetResult();
        }


        [HttpPost]
        [AjaxOnly]
        [MvcAuthorize(Description = "چک کردن آی دی فیسبوک",
            Roles = "CanManageUsers,CanEditUser,CanCreateUser",
            CanBeMenu = false)]
        public virtual JsonResult FaceBookIdExist(string phoneNumber, int? id)
        {
            return new JsonNetResult();
        }
        #endregion

    }
}