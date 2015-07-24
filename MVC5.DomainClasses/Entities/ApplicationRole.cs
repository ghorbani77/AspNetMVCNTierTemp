using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNet.Identity.EntityFramework;

namespace MVC5.DomainClasses.Entities
{
    
    public class ApplicationRole : IdentityRole<int, ApplicationUserRole>
    {
        [MaxLength(1024)]
        public string Description { get; set; }
        public virtual bool IsSystemRole { get; set; }
        public virtual bool IsDefaultForRegister { get; set; }
        public virtual bool IsActive { get; set; }
        public virtual ICollection<ApplicationPermission> Permissions { get; set; }
        public virtual ICollection<ApplicationRole> Children { get; set; }
        public virtual ApplicationRole Parent { get; set; }
        public virtual int? ParentId { get; set; }
    }
}
