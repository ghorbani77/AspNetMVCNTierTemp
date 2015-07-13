using System.Data.Entity.ModelConfiguration;
using EntityFramework.Filters;
using MVC5.DomainClasses.Entities;

namespace MVC5.DomainClasses.Configurations
{
    public class ApplicationPermissionConfig : EntityTypeConfiguration<ApplicationPermission>
    {
        public ApplicationPermissionConfig()
        {
            Property(p => p.ActionName).HasMaxLength(50);
            Property(p => p.Description).HasMaxLength(1024);
            Property(p => p.ControllerName).HasMaxLength(50);
            Property(p => p.AreaName).HasMaxLength(50);
            this.Filter("IsMenu", a => a.Condition(p => p.IsMenu));
            Property(p => p.Name).HasMaxLength(100);
            HasMany(p => p.ApplicationRoles)
                .WithMany(a => a.Permissionses)
                .Map(a => a.ToTable("Role_Permission").MapLeftKey("PermissionId").MapRightKey("RoleId"));
        }

    }
}
