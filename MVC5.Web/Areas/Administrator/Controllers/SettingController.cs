using System.ComponentModel;
using System.Threading.Tasks;
using System.Web.Mvc;
using AutoMapper;
using MVC5.Common.Controller;
using MVC5.Common.Filters;
using MVC5.DataLayer.Context;
using MVC5.ServiceLayer.Contracts;
using MVC5.ViewModel.AdminArea.Setting;
using MVC5.Web.Filters;

namespace MVC5.Web.Areas.Administrator.Controllers
{
    [MvcAuthorize]
    [DisplayName("مدیریت تنظیمات سایت")]
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
        [DisplayName("ویرایش تنظیمات کاربران")]
        [ActivityLog(Description = "ویرایش تنظیمات مرتبط به کاربران", Name = "EditUserSetting")]
        public virtual async Task<ActionResult> UserSetting()
        {
            await _unitOfWork.SaveChangesAsync();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [CheckReferrer]
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