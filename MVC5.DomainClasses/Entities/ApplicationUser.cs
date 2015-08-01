using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using EntityFramework.Filters;
using Microsoft.AspNet.Identity.EntityFramework;
using MVC5.DomainClasses;

namespace MVC5.DomainClasses.Entities
{

    public class ApplicationUser : IdentityUser<int, ApplicationUserLogin, ApplicationUserRole, ApplicationUserClaim>
    {
        public virtual bool IsBanned { get; set; }
        [MaxLength(512)]
        public string NameForShow { get; set; }
        public virtual bool IsDeleted { get; set; }
        public virtual bool IsSystemAccount { get; set; }
        [MaxLength(1024)]
        public virtual string AdminComment { get; set; }
        [MaxLength(50)]
        [Required]
        public virtual string AvatarFileName { get; set; }
        public virtual DateTime? BirthDay { get; set; }
        public virtual DateTime RegisterDate { get; set; }
        [MaxLength(50)]
        public virtual string GooglePlusId { get; set; }
        [MaxLength(50)]
        public virtual string FaceBookId { get; set; }
        public virtual DateTime? BannedDate { get; set; }
        public virtual string LastIp { get; set; }
        public virtual DateTime? LastLoginDate { get; set; }
        public virtual DateTime LastActivityDate { get; set; }
        public virtual CommentPermissionType CommentPermission { get; set; }
        public virtual bool CanUploadFile { get; set; }
        public virtual bool CanChangeProfilePicture { get; set; }
        public virtual bool CanModifyFirsAndLastName { get; set; }
        public virtual bool PermissionsOrRolesModified { get; set; }
        public virtual ICollection<ActivityLog> ActivityLogs { get; set; }
        public virtual ICollection<ApplicationPermission> OwnPermissions { get; set; }

    }
}
