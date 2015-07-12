using System.Collections.Generic;

namespace MVC5.DomainClasses.Entities
{
    public class ApplicationGroup
    {
      
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual string Description { get; set; }
        public virtual GroupType Type { get; set; }
        public virtual ICollection<ApplicationRoleGroup> ApplicationRoles { get; set; }
        public virtual ICollection<ApplicationUserGroup> ApplicationUsers { get; set; }
    }
}
