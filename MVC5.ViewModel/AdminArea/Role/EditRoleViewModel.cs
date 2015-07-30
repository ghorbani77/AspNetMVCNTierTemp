using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using MVC5.DomainClasses.Entities;

namespace MVC5.ViewModel.AdminArea.Role
{
    public class EditRoleViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "لطفا نام گروه را وارد کنید")]
        [DisplayName("نام گروه")]
        [MaxLength(20, ErrorMessage = "تعداد کاراکتر های نام گروه غیر مجاز است")]
        [Remote("RoleNameExist", "Role", "Administrator", ErrorMessage = "این گروه قبلا در سیستم ثبت شده است", HttpMethod = "POST", AdditionalFields = "Id")]
        public string Name { get; set; }
        [Required(ErrorMessage = "لطفا توضیحاتی برای گروه وارد کنید")]
        [MaxLength(500, ErrorMessage = "تعداد کاراکتر های توضیحات گروه غیر مجاز است")]
        [DisplayName("توضیحات")]
        public string Description { get; set; }
        [DisplayName("گروه پیشفرض ثبت نام است؟")]
        public bool IsDefaultForRegister { get; set; }
        [DisplayName("فعال باشد؟")]
        public bool IsActive { get; set; }
        [DisplayName("گروه سیستمی است؟")]
        public bool IsSystemRole { get; set; }
        public ICollection<ApplicationPermission> Permissions { get; set; }
    }
}
