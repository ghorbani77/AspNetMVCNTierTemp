using System;
using System.ComponentModel.DataAnnotations;
using EntityFramework.Filters;
using Microsoft.AspNet.Identity.EntityFramework;

namespace MVC5.DomainClasses.Entities
{

    public class ApplicationUser : IdentityUser<int, ApplicationUserLogin, ApplicationUserRole, ApplicationUserClaim>
    {
        public virtual bool IsBanned { get; set; }
        [MaxLength(50)]
        [Required]
        public virtual string FirstName { get; set; }
        [MaxLength(50)]
        [Required]
        public virtual string LastName { get; set; }
        public virtual bool IsDeleted { get; set; }
        public virtual bool IsSystemAccount { get; set; }
        [MaxLength(1024)]
        public virtual string AdminComment { get; set; }
        [MaxLength(50)]
        public virtual string AvatarPath { get; set; }
        public virtual DateTime? BirthDay { get; set; }
        public virtual DateTime RegisterDate { get; set; }
        public virtual DateTime? BannedDate { get; set; }
        public virtual DateTime? LastLoginDate { get; set; }
        [Timestamp]
        public virtual byte[] RowVersion { get; set; }

    }
}
