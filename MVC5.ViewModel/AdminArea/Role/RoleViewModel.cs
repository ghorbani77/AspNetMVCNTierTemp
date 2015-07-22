using System.Collections.Generic;
using System.ComponentModel;
using System.Web.Mvc;

namespace MVC5.ViewModel.AdminArea.Role
{
    public class RoleViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description
        { get; set; }
        public virtual bool IsActive { get; set; }
        public bool IsSystemRole { get; set; }
        public  bool IsDefaultForRegister { get; set; }
        public IEnumerable<SelectListItem> Permissions { get; set; }
    }
}
