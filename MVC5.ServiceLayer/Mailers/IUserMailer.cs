using Mvc.Mailer;
using MVC5.ViewModel.Account;

namespace MVC5.ServiceLayer.Mailers
{ 
    public interface IUserMailer
    {
			MvcMailMessage ResetPassword(ResetPasswordEmail resetPasswordEmail);
			MvcMailMessage ConfirmAccount(ConfirmAccountEmail confirmAccountEmail);
	}
}