using System.Data.Entity.ModelConfiguration;
using MVC5.DomainClasses.Entities;

namespace MVC5.DomainClasses.Configurations
{
    public class ApplicationUserGroupConfig : EntityTypeConfiguration<ApplicationUserGroup>
    {
        public ApplicationUserGroupConfig()
        {
            HasKey(userGroup =>
                new
                {
                    ApplicationUserId = userGroup.ApplicationUserId,
                    ApplicationGroupId = userGroup.ApplicationGroupId
                }).ToTable("GroupUser");
        }
    }
}
