﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNet.Identity.EntityFramework;

namespace MVC5.DomainClasses.Entities
{
    
    public class ApplicationRole : IdentityRole<int, ApplicationUserRole>
    {
        [MaxLength(1024)]
        public string Descriptions { get; set; }
        public virtual bool IsSystemRole { get; set; }
        public virtual bool IsDefaultForRegister { get; set; }
        public virtual bool IsActive { get; set; }
        public virtual ICollection<ApplicationPermission> Permissionses { get; set; }
    }
}
