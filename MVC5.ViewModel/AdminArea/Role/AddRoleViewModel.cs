using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace MVC5.ViewModel.AdminArea.Role
{
    public class AddRoleViewModel
    {
        [Required(ErrorMessage = "لطفا نام گروه را وارد کنید")]
        [DisplayName("نام گروه")]
        [MaxLength(50, ErrorMessage = "تعداد کاراکتر های نام گروه غیر مجاز است")]
        [Remote("RoleNameExist", "Role", "Admin", ErrorMessage = "این گروه قبلا در سیستم ثبت شده است", HttpMethod = "POST")]
        public string Name { get; set; }
        [Required(ErrorMessage = "لطفا توضیحاتی برای گروه وارد کنید")]
        [MaxLength(500, ErrorMessage = "تعداد کاراکتر های توضیحات گروه غیر مجاز است")]
        [DisplayName("توضیحات")]
        public string Description { get; set; }
        [DisplayName("گروه پیشفرض ثبت نام")]
        public  bool IsDefaultForRegister { get; set; }
        [DisplayName("فعال")]
        public bool IsActive { get; set; }
        public IEnumerable<SelectListItem> Permissions { get; set; }
    }
}
