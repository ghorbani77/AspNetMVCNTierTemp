using System.Web.Mvc;
using MVC5.DataLayer.Context;
using MVC5.ServiceLayer.Contracts;

namespace MVC5.Web.Areas.Adminstrator.Controllers
{
    public partial class RoleController : Controller
    {
        #region Fields

        private readonly IUnitOfWork _unitOfWork;
        private readonly IApplicationRoleManager _roleManager;
        private readonly IApplicationUserManager _userManager;
        #endregion

        #region Const

        public RoleController(IUnitOfWork unitOfWork,IApplicationRoleManager roleManager,IApplicationUserManager userManager)
        {
            _unitOfWork = unitOfWork;
            _roleManager = roleManager;
            _userManager = userManager;
        }
        #endregion

        #region Create
        [HttpGet]
        [ActionName("")]
        public virtual ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual ActionResult Create()
        {
            return View();
        }
        #endregion
        
    }
}