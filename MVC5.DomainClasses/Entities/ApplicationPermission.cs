using System.Collections.Generic;

namespace MVC5.DomainClasses.Entities
{
    public class ApplicationPermission
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual string ActionName { get; set; }
        public virtual string ControllerName { get; set; }
        public virtual string AreaName{ get; set; }
        public virtual bool IsMenu { get; set; }
        public virtual string Description { get; set; }
        public virtual ICollection<ApplicationRole> ApplicationRoles { get; set; }

    }
}
