using System.ComponentModel;
using System.Web.Mvc;

namespace MVC5.ViewModel.AdminArea.Role
{
    public class RoleViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Descriptions { get; set; }
        public bool IsSystemRole { get; set; }
        public  bool IsDefaultForRegister { get; set; }
        public SelectList Permissions { get; set; }
    }
}
