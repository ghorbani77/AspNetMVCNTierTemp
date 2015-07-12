using System.Data.Entity.ModelConfiguration;
using MVC5.DomainClasses.Entities;

namespace MVC5.DomainClasses.Configurations
{
    public class ApplicationRoleGroupConfig : EntityTypeConfiguration<ApplicationRoleGroup>
    {
        public ApplicationRoleGroupConfig()
        {
            HasKey(roleGroup =>
                new
                {
                    ApplicationRoleId = roleGroup.ApplicationRoleId,
                    ApplicationGroupId = roleGroup.ApplicationGroupId
                }).ToTable("GroupRole");
        }
    }
}
