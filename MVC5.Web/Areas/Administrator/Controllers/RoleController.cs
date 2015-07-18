
using System.Web.Mvc;
using MVC5.Common.Controller;
using MVC5.Common.Filters;
using MVC5.Common.Helpers;
using MVC5.Common.Helpers.Json;
using MVC5.DataLayer.Context;
using MVC5.ServiceLayer.Contracts;
using MVC5.ViewModel.AdminArea.Role;
using MVC5.Web.Filters;

namespace MVC5.Web.Areas.Administrator.Controllers
{
    [MvcAuthorize(Description = "مدیریت گروه های کاربری ", Roles = "CanManageRoles", CanBeMenu = true)]
    public partial class RoleController : BaseController
    {
        #region Fields

        private readonly IUnitOfWork _unitOfWork;
        private readonly IApplicationRoleManager _roleManager;
        private readonly IApplicationUserManager _userManager;
        #endregion

        #region Const

        public RoleController(IUnitOfWork unitOfWork, IApplicationRoleManager roleManager, IApplicationUserManager userManager)
        {
            _unitOfWork = unitOfWork;
            _roleManager = roleManager;
            _userManager = userManager;
        }
        #endregion

        #region List
        [HttpGet]
        [MvcAuthorize(Description = "درج گروه کاربری جدید",
            Roles = "CanManageRoles,CanViewRoles,CanCreateRole,CanEditRole,CanDeleteRole", CanBeMenu = true)]
        [ActivityLog(Name = "ViewRoles",Description = "مشاده گروه های کاربری")]
        public virtual ActionResult List()
        {
            return View();
        }
        #endregion

        #region Create
        [HttpGet]
        [MvcAuthorize(Description = "درج گروه کاربری جدید", Roles = "CanManageRoles,CanCreateRole", CanBeMenu = true)]
        [ActivityLog(Name = "CreateRole", Description = "درج گروه کاربری")]
        public virtual ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [CheckReferrer]
        [MvcAuthorize(Description = "درج گروه کاربری جدید", Roles = "CanManageRoles,CanCreateRole", CanBeMenu = false)]
        public virtual ActionResult Create(AddRoleViewModel viewModel)
        {
            return View();
        }
        #endregion

        #region Edit
        [HttpGet]
        [MvcAuthorize(Description = "ویرایش گروه کاربری", Roles = "CanManageRoles,CanEditRole", CanBeMenu = false)]
        [ActivityLog(Name = "EditRole", Description = " ویرایش گروه کاربری")]
        public virtual ActionResult Edit()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [CheckReferrer]
        [MvcAuthorize(Description = "ویرایش گروه کاربری", Roles = "CanManageRoles,CanEditRole", CanBeMenu = false)]
        public virtual ActionResult Edit(EditRoleViewModel viewModel)
        {
            return View();
        }
        #endregion

        #region Delete
        [HttpPost]
        [ValidateAntiForgeryToken]
        [CheckReferrer]
        [MvcAuthorize(Description = "حذف گروه کاربری", Roles = "CanManageRoles,CanDeleteRole", CanBeMenu = false)]
        [ActivityLog(Name = "DeleteRole", Description = " حذف گروه کاربری")]
        public virtual ActionResult Delete(int id)
        {
            return View();
        }
        #endregion

        #region RemoteValidation

        [HttpPost]
        [AjaxOnly]
        [MvcAuthorize(Description = "چک کردن نام گروه کاربری", 
            Roles = "CanManageRoles,CanEditRole,CanCreateRole",
            CanBeMenu = false)]
        public virtual JsonResult RoleNameExist(string name, int? id)
        {
            return new JsonNetResult();
        }

        #endregion
    }
}