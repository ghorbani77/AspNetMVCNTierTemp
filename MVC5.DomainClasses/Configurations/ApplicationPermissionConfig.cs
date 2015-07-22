using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;
using EntityFramework.Filters;
using MVC5.DomainClasses.Entities;

namespace MVC5.DomainClasses.Configurations
{
    public class ApplicationPermissionConfig : EntityTypeConfiguration<ApplicationPermission>
    {
        public ApplicationPermissionConfig()
        {
            Property(p => p.ActionName).HasMaxLength(50).IsRequired();
            Property(p => p.Description).HasMaxLength(1024).IsRequired();
            Property(p => p.ControllerName).HasMaxLength(50).IsRequired();
            Property(p => p.AreaName).HasMaxLength(50).IsOptional();

            ToTable("Permissions");

            this.Filter("IsMenu", a => a.Condition(p => p.IsMenu));

            Property(p => p.Name)
                .HasMaxLength(100)
                .IsRequired()
                .HasColumnAnnotation("Index",
                    new IndexAnnotation(new IndexAttribute("IX_PermissionName") { IsUnique = true }));

            HasMany(p => p.ApplicationRoles)
                .WithMany(a => a.Permissions)
                .Map(a => a.ToTable("RolePermission").MapLeftKey("PermissionId").MapRightKey("RoleId"));
        }

    }
}
