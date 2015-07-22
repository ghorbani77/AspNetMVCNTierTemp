using System.Collections.Generic;
using MVC5.DomainClasses.Entities;

namespace MVC5.ViewModel.AdminArea.Security
{
    public class DefaultPermissionsRecord
    {
        public string SystemRoleName { get; set; }
        public List<ApplicationPermission> Permissions { get; set; }
    }
}
