using System.Threading.Tasks;
using System.Web.Mvc;
using AutoMapper;
using MVC5.Common.Controller;
using MVC5.Common.Filters;
using MVC5.DataLayer.Context;
using MVC5.ServiceLayer.Contracts;
using MVC5.ServiceLayer.Settings;
using MVC5.ViewModel.AdminArea.Setting;

namespace MVC5.Web.Areas.Administrator.Controllers
{
    // [MvcAuthorize(Description = "مدیریت تنظیمات سایت", Roles = "CanManageSettings", CanBeMenu = true)]
    public partial class SettingController : BaseController
    {
        #region Fields
        private readonly IMappingEngine _mappingEngine;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ISettingService _settingService;
        #endregion

        #region ctor

        public SettingController(IUnitOfWork unitOfWork, ISettingService settingService, IMappingEngine mappingEngine)
        {
            _unitOfWork = unitOfWork;
            _settingService = settingService;
            _mappingEngine = mappingEngine;
        }
        #endregion

        #region User
        [HttpGet]
        // [MvcAuthorize(Description = "ویرایش تنظیمات کاربری", Roles = "CanManageSettings,CanEditUserSetting", CanBeMenu = true)]
        [ActivityLog(Description = "ویرایش تنظیمات کاربری", Name = "EditUserSetting")]
        public virtual async Task<ActionResult> UserSetting()
        {
            await _unitOfWork.SaveChangesAsync();

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [CheckReferrer]
        //  [MvcAuthorize(Description = "ویرایش تنظیمات کاربری", Roles = "CanManageSettings,CanEditUserSetting", CanBeMenu = true)]
        [ActivityLog(Description = "ویرایش تنظیمات کاربری", Name = "EditUserSetting")]
        public virtual async Task<ActionResult> UserSetting(UserSettingsViewModel viewModel)
        {
            await _unitOfWork.SaveChangesAsync();

            ToastrSuccess(" عملیات با موفقیت انچام شد", "تنظیمات کاربران");
            return RedirectToAction(MVC.Administrator.Home.ActionNames.Index, MVC.Administrator.Home.Name);

        }
        #endregion

    }
}