using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace MVC5.ViewModel.Account
{
    public class ActivationEmailViewModel
    {
        [Required(ErrorMessage = "وارد کردن ایمیل ضروریست")]
        [EmailAddress(ErrorMessage = "ایمیل را به شکل صحیح وارد کنید")]
        [DisplayName("ایمیل")]
        [StringLength(450, ErrorMessage = "حداکثر طول ایمیل 450 حرف است")]
        [Remote("IsEmailAvailable", "Account", "", ErrorMessage = "ایمیل مورد نظر یافت نشد", HttpMethod = "POST")]
        public string Email { get; set; }
    }
}
