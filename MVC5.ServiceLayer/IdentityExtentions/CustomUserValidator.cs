using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;

namespace MVC5.ServiceLayer.IdentityExtentions
{
    public class CustomUserValidator<TUser, TKey> : IIdentityValidator<TUser>
        where TUser : class, IUser<TKey>
        where TKey : IEquatable<TKey>
    {

        public bool AllowOnlyAlphanumericUserNames { get; set; }
        public bool RequireUniqueEmail { get; set; }

        private UserManager<TUser, TKey> Manager { get; set; }
        public CustomUserValidator(UserManager<TUser, TKey> manager)
        {
            if (manager == null)
                throw new ArgumentNullException("manager");
            AllowOnlyAlphanumericUserNames = true;
            Manager = manager;
        }
        public virtual async Task<IdentityResult> ValidateAsync(TUser item)
        {
            if (item == null)
                throw new ArgumentNullException("item");
            var errors = new List<string>();
            await ValidateUserName(item, errors);
            if (RequireUniqueEmail)
                await ValidateEmailAsync(item, errors);
            return errors.Count <= 0 ? IdentityResult.Success : IdentityResult.Failed(errors.ToArray());
        }

        private async Task ValidateUserName(TUser user, ICollection<string> errors)
        {
            if (string.IsNullOrWhiteSpace(user.UserName))
                errors.Add("نام کاربری نباید خالی باشد");
            else if (AllowOnlyAlphanumericUserNames && !Regex.IsMatch(user.UserName, "^[A-Za-z0-9@_\\.]+$"))
            {
                errors.Add("برای نام کاربری فقط از کاراکتر های مجاز استفاده کنید ");
            }
            else
            {
                var owner = await Manager.FindByNameAsync(user.UserName);
                if (owner != null && !EqualityComparer<TKey>.Default.Equals(owner.Id, user.Id))
                    errors.Add("این نام کاربری قبلا ثبت شده است");
            }
        }

        private async Task ValidateEmailAsync(TUser user, ICollection<string> errors)
        {
            var email = await Manager.GetEmailAsync(user.Id);
            if (string.IsNullOrWhiteSpace(email))
            {
                errors.Add("وارد کردن ایمیل ضروریست");
            }
            else
            {
                try
                {
                    var m = new MailAddress(email);
                }
                catch (FormatException)
                {
                    errors.Add("ایمیل را به شکل صحیح وارد کنید");
                    return;
                }
                var owner = await Manager.FindByEmailAsync(email);
                if ((object)owner != null && !EqualityComparer<TKey>.Default.Equals(owner.Id, user.Id))
                    errors.Add("این ایمیل قبلا ثبت شده است");
            }
        }
    }

}
