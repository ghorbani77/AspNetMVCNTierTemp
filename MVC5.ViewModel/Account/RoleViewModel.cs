using System.ComponentModel.DataAnnotations;

namespace MVC5.ViewModel.Account
{
    public class RoleViewModel
    {
        public int Id { get; set; }
        [Required(AllowEmptyStrings = false,ErrorMessage = "وارد کردن نام ضروریست")]
        [Display(Name = "نام")]
        public string Name { get; set; }
    }
}