using System.ComponentModel;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using CaptchaMvc.Attributes;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Mvc.Mailer;
using MVC5.Common.Caching;
using MVC5.Common.Controller;
using MVC5.Common.Filters;
using MVC5.Common.Helpers.Extentions;
using MVC5.DataLayer.Context;
using MVC5.DomainClasses.Entities;
using MVC5.ServiceLayer.Mailers;
using MVC5.Utility;
using MVC5.Utility.EF.Filters;
using MVC5.Web.Extention;
using MVC5.Web.Filters;
using MVC5.ServiceLayer.Contracts;
using MVC5.ViewModel.Account;

namespace MVC5.Web.Controllers
{
    public partial class AccountController : BaseController
    {
        #region Fields

        private readonly HttpContextBase _httpContextBase;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAuthenticationManager _authenticationManager;
        private readonly IApplicationSignInManager _signInManager;
        private readonly IApplicationUserManager _userManager;
        private readonly IUserMailer _userMailer;
        #endregion

        #region Constructor

        public AccountController(HttpContextBase httpContextBase,IApplicationUserManager userManager, IUnitOfWork unitOfWork,
            IApplicationSignInManager signInManager,
            IAuthenticationManager authenticationManager, IUserMailer userMailer
           )
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _authenticationManager = authenticationManager;
            _userMailer = userMailer;
            _unitOfWork = unitOfWork;
            _httpContextBase = httpContextBase;
        }

        #endregion

        #region ConfirmEmail
        [AllowAnonymous]
        public virtual async Task<ActionResult> ConfirmEmail(int? userId, string code)
        {
            //if(enable confirm email feature then show confirm page)
            //return view("info")
            if (userId == null || code == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var result = await _userManager.ConfirmEmailAsync(userId.Value, code);
            if (result.Succeeded)
                return View();
            ToastrWarning("مشکلی در فعال سازی اکانت شما به وجود آمد");
            return RedirectToAction(MVC.Account.ActionNames.ReceiveActivatorEmail, MVC.Account.Name);
        }
        #endregion

        #region ExternalLogin
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public virtual ActionResult ExternalLogin(string provider, string returnUrl)
        {
            return new ChallengeResult(provider, Url.Action("ExternalLoginCallback", "Account", new { ReturnUrl = returnUrl }));
        }


        [AllowAnonymous]
        public virtual async Task<ActionResult> ExternalLoginCallback(string returnUrl)
        {
            var loginInfo = await _authenticationManager.GetExternalLoginInfoAsync();
            if (loginInfo == null)
            {
                return RedirectToAction("Login");
            }

            // Sign in the user with this external login provider if the user already has a login
            var result = await _signInManager.ExternalSignInAsync(loginInfo, isPersistent: false);
            switch (result)
            {
                case SignInStatus.Success:
                    return RedirectToLocal(returnUrl);
                case SignInStatus.LockedOut:
                    return View("Lockout");
                case SignInStatus.RequiresVerification:
                    return RedirectToAction("SendCode", new { ReturnUrl = returnUrl });
                default:
                    // If the user does not have an account, then prompt the user to create an account
                    ViewBag.ReturnUrl = returnUrl;
                    ViewBag.LoginProvider = loginInfo.Login.LoginProvider;
                    return View("ExternalLoginConfirmation", new ExternalLoginConfirmationViewModel { Email = loginInfo.Email });
            }
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public virtual async Task<ActionResult> ExternalLoginConfirmation(ExternalLoginConfirmationViewModel model, string returnUrl)
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Manage");
            }

            if (ModelState.IsValid)
            {
                // Get the information about the user from the external login provider
                var info = await _authenticationManager.GetExternalLoginInfoAsync();
                if (info == null)
                {
                    return View("ExternalLoginFailure");
                }
                var user = new ApplicationUser { UserName = model.Email, Email = model.Email };
                var result = await _userManager.CreateAsync(user);
                if (result.Succeeded)
                {
                    result = await _userManager.AddLoginAsync(user.Id, info.Login);
                    if (result.Succeeded)
                    {
                        await _signInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);
                        return RedirectToLocal(returnUrl);
                    }
                }
                this.AddErrors(result);
            }

            ViewBag.ReturnUrl = returnUrl;
            return View(model);
        }


        [AllowAnonymous]
        public virtual ActionResult ExternalLoginFailure()
        {
            return View();
        }
        #endregion

        #region ForgetPassword
        [AllowAnonymous]
        public virtual ActionResult ForgotPassword()
        {
            //if(enable forget feature then show forget page)
            //return view("info")
            return View();
        }


        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public virtual async Task<ActionResult> ForgotPassword(ForgotPasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByNameAsync(model.Email);
                if (user == null || !(await _userManager.IsEmailConfirmedAsync(user.Id)))
                {
                    // Don't reveal that the user does not exist or is not confirmed
                    return View("ForgotPasswordConfirmation");
                }

                var code = await _userManager.GeneratePasswordResetTokenAsync(user.Id);
                if (Request.Url == null) return View("ForgotPasswordConfirmation");
                var callbackUrl = Url.Action("ResetPassword", "Account",
                    new { userId = user.Id, code }, protocol: Request.Url.Scheme);
                await _userManager.SendEmailAsync(user.Id, "Reset Password", "Please reset your password by clicking here: <a href=\"" + callbackUrl + "\">link</a>");
                ViewBag.Link = callbackUrl;
                return View("ForgotPasswordConfirmation");
            }
            return View(model);
        }

        [AllowAnonymous]
        public virtual ActionResult ForgotPasswordConfirmation()
        {
            return View();
        }

        #endregion

        #region Login,LogOff
        [AllowAnonymous]
        public virtual ActionResult Login(string returnUrl)
        {
            //if(enable login feature then show login page)
            //return view("info")
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        //[CheckReferrer]
        [ValidateAntiForgeryToken]
        [CaptchaVerify("تصویر امنیتی را درست وارد کنید")]
        public virtual async Task<ActionResult> Login(LoginViewModel model, string returnUrl)
        {
            if (_userManager.CheckIsUserBannedOrDelete(model.UserName))
            {
                this.AddErrors("UserName", "حساب کاربری شما مسدود شده است");
                return View(model);
            }
            if (!_userManager.IsEmailConfirmedByUserNameAsync(model.UserName))
            {
                ToastrWarning("برای ورود به سایت لازم است حساب خود را فعال کنید");
                return RedirectToAction(MVC.Account.ActionNames.ReceiveActivatorEmail, MVC.Account.Name);
            }

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var result = await _signInManager.PasswordSignInAsync
                (model.UserName.ToLower(), model.Password, model.RememberMe, shouldLockout: true);

            switch (result)
            {
                case SignInStatus.Success:
                    return RedirectToLocal(returnUrl);
                case SignInStatus.LockedOut:
                    ToastrError(
                        string.Format("دقیقه دوباره امتحان کنید {0} حساب شما قفل شد ! لطفا بعد از ",
                            _userManager.DefaultAccountLockoutTimeSpan), isSticky: true);
                    return View(model);
                case SignInStatus.Failure:
                    ToastrError(ModelState.GetListOfErrors());
                    return View(model);
                default:
                    ToastrError(
                        "در این لحظه امکان ورود به  سابت وجود ندارد . مراتب را با مسئولان سایت در میان بگذارید",
                        isSticky: true);
                    return View(model);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        // [CheckReferrer]
        [Mvc5Authorize]
        public virtual ActionResult LogOff()
        {
            _authenticationManager.SignOut();
            return RedirectToAction(MVC.Home.ActionNames.Index, MVC.Home.Name, new { area = "" });
        }

        #endregion

        #region Register
        [AllowAnonymous]
        public virtual ActionResult Register()
        {
            // if("register is enable")
            // return RedirectToAction("info)
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        // [CheckReferrer]
        [ValidateAntiForgeryToken]
        [CaptchaVerify("تصویر امنیتی را درست وارد کنید")]
        public virtual async Task<ActionResult> Register(RegisterViewModel model)
        {
            #region Validation
            if (_userManager.CheckEmailExist(model.Email, null))
                this.AddErrors("Email", "این ایمیل قبلا در سیستم ثبت شده است");

            if (_userManager.CheckUserNameExist(model.UserName, null))
                this.AddErrors("UserName", "این نام کاربری قبلا در سیستم ثبت شده است");

            if (_userManager.CheckNameForShowExist(model.NameForShow, null))
                this.AddErrors("NameForShow", "این نام نمایشی قبلا در سیستم ثبت شده است");

            if (!model.Password.IsSafePasword())
                this.AddErrors("Password", "این کلمه عبور به راحتی قابل تشخیص است");

            if (!ModelState.IsValid)
            {
                return View(model);
            }


            #endregion

            var userId = await _userManager.CreateAsync(model);

            await SendConfirmationEmail(model.Email.FixGmailDots(), userId);

            ToastrSuccess("حساب کاربری شما با موفقیت ایجاد شد. برای فعال سازی " +
                          "حساب خود به صندوق پستی خود مراجعه کنید",
                isSticky: true);

            return RedirectToAction(MVC.Home.ActionNames.Index, MVC.Home.Name);
        }
        #endregion

        #region ResePassword

        [AllowAnonymous]
        public virtual ActionResult ResetPassword(string code)
        {
            //if(enable resetpass feature then show resetpass page)
            //return view("info")
            if (code == null) return RedirectToAction(MVC.Error.ActionNames.Error404, MVC.Error.Name);

            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        //[CheckReferrer]
        [ValidateAntiForgeryToken]
        [CaptchaVerify("تصویر امنیتی را درست وارد کنید")]
        public virtual async Task<ActionResult> ResetPassword(ResetPasswordViewModel model)
        {
            if (!model.Password.IsSafePasword())
                this.AddErrors("Password", "این کلمه عبور به راحتی قابل تشخیص است");
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var user = await _userManager.FindByNameAsync(model.Email.ToLower());
            if (user == null)
            {
                // Don't reveal that the user does not exist
                return RedirectToAction(MVC.Account.ActionNames.ResetPasswordConfirmation, MVC.Account.Name);
            }
            var result = await _userManager.ResetPasswordAsync(user.Id, model.Code, model.Password);
            if (result.Succeeded)
            {
                await _signInManager.SignInAsync(user,false, false);
                return RedirectToAction(MVC.Account.ActionNames.ResetPasswordConfirmation, MVC.Account.Name);
            }
            this.AddErrors(result);
            ToastrError(ModelState.GetListOfErrors());
            return View(model);
        }

        [AllowAnonymous]
        public virtual ActionResult ResetPasswordConfirmation()
        {
            return View();
        }
        #endregion

        #region ReceiveActivatorEmail
        [AllowAnonymous]
        public virtual ActionResult ReceiveActivatorEmail()
        {
            //if(enable receiveactivator feature then show receiveactivator page)
            //return view("info")
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        // [CheckReferrer]
        [ValidateAntiForgeryToken]
        [CaptchaVerify("تصویر امنیتی را درست وارد کنید")]
        public virtual async Task<ActionResult> ReceiveActivatorEmail(ActivationEmailViewModel viewModel)
        {
            if (!_userManager.IsEmailAvailableForConfirm(viewModel.Email))
                this.AddErrors("Email", "ایمیل مورد نظر یافت نشد");
            if (_userManager.CheckIsUserBannedOrDeleteByEmail(viewModel.Email))
                this.AddErrors("Email", "اکانت شما مسدود شده است");
            if (!ModelState.IsValid)
                return View(viewModel);
            _unitOfWork.DisableFiltering(UserFilters.BannedList);
            var user = await _userManager.FindByEmailAsync(viewModel.Email);
            await SendConfirmationEmail(viewModel.Email, user.Id);
            ToastrSuccess("ایمیلی تحت عنوان فعال سازی اکانت به آدرس ایمیل شما ارسال گردید");
            return RedirectToAction(MVC.Account.ActionNames.ReceiveActivatorEmail, MVC.Account.Name);
        }

        #endregion

        #region AdminMenu
        [OverrideAuthorization]
        [Authorize]
        public virtual ActionResult AdminMenu()
        {
            //get user info 
            //get adminMneu page content from site setting

            return View();
        }
        #endregion

        #region Validation

        [HttpPost]
        [AllowAnonymous]
        [OutputCache(Location = OutputCacheLocation.None, NoStore = true, Duration = 0, VaryByParam = "*")]
        public virtual JsonResult IsEmailAvailable(string email)
        {
            return _userManager.IsEmailAvailableForConfirm(email) ? Json(true) : Json(false);
        }

        [HttpPost]
        [AllowAnonymous]
        [OutputCache(Location = OutputCacheLocation.None, NoStore = true, Duration = 0, VaryByParam = "*")]
        public virtual JsonResult CheckPassword(string password)
        {
            return password.IsSafePasword() ? Json(true) : Json(false);
        }
        [HttpPost]
        [AllowAnonymous]
        [OutputCache(Location = OutputCacheLocation.None, NoStore = true, Duration = 0, VaryByParam = "*")]
        public virtual JsonResult IsNameForShowExist(string nameForShow, int? id)
        {
            return _userManager.CheckNameForShowExist(nameForShow, id) ? Json(false) : Json(true);
        }
        [HttpPost]
        [AllowAnonymous]
        [OutputCache(Location = OutputCacheLocation.None, NoStore = true, Duration = 0, VaryByParam = "*")]
        public virtual JsonResult IsEmailExist(string email, int? id)
        {
            var check = _userManager.CheckEmailExist(email, id);
            return check ? Json(false) : Json(true);
        }

        [HttpPost]
        [AllowAnonymous]
        [OutputCache(Location = OutputCacheLocation.None, NoStore = true, Duration = 0, VaryByParam = "*")]
        public virtual JsonResult IsUserNameExist(string userName, int? id)
        {
            return _userManager.CheckUserNameExist(userName, id) ? Json(false) : Json(true);
        }
        #endregion

        #region Private
        [NonAction]
        private async Task SendConfirmationEmail(string emailAddress, int userId)
        {
            var code = await _userManager.GenerateEmailConfirmationTokenAsync(userId);
            var callbackUrl = Url.Abs(Url.Action(MVC.Account.ActionNames.ConfirmEmail, MVC.Account.Name,
                new { userId, code, area = "" }, protocol: Request.Url.Scheme));
            var email = new ConfirmAccountEmail
            {
                Subject = "فعال سازی حساب کاربری",
                To = emailAddress.FixGmailDots(),
                Message = "با سلام. لطفا برای تایید حساب خود بر روی لینک زیر کلیک کنید ",
                Url = callbackUrl,
                UrlText = "برای فعال سازی اینجا کلیک کنید",
                ViewName = MVC.UserMailer.Views.ViewNames.ConfirmAccount
            };

            await _userMailer.ConfirmAccount(email).SendAsync();
        }
        #endregion
    }
}