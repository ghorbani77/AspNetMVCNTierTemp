using System.Text;
using Mvc.Mailer;
using MVC5.ViewModel.Account;

namespace MVC5.ServiceLayer.Mailers
{
    public  class UserMailer : MailerBase, IUserMailer
    {
        public UserMailer()
        {
            MasterName = "_Layout";
        }

        public MvcMailMessage ResetPassword(ResetPasswordEmail resetPasswordEmail)
        {
            ViewData.Model = resetPasswordEmail;
            return Populate(x =>
            {
                x.BodyTransferEncoding = System.Net.Mime.TransferEncoding.Base64;
                x.BodyEncoding = Encoding.UTF8;
                x.Subject = "بازیابی کلمه عبور";
                x.ViewName = "ResetPassword";
                x.To.Add(resetPasswordEmail.To);
            });
        }

        public MvcMailMessage ConfirmAccount(ConfirmAccountEmail confirmAccountEmail)
        {
            ViewData.Model = confirmAccountEmail;
            return Populate(x =>
            {
                x.BodyTransferEncoding = System.Net.Mime.TransferEncoding.Base64;
                x.BodyEncoding = Encoding.UTF8;
                x.Subject = "تآیید حساب کاربری";
                x.ViewName = "ConfirmAccount";
                x.To.Add(confirmAccountEmail.To);
            });
        }
    }
}