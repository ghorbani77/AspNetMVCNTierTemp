using System.Data.Entity.ModelConfiguration;
using EntityFramework.Filters;
using MVC5.DomainClasses.Entities;

namespace MVC5.DomainClasses.Configurations
{
    public class ApplicationGroupConfig : EntityTypeConfiguration<ApplicationGroup>
    {
        public ApplicationGroupConfig()
        {
            HasMany(group => group.ApplicationUsers)
            .WithRequired()
            .HasForeignKey<int>(group => group.ApplicationGroupId);
          
            HasMany(group => group.ApplicationRoles)
            .WithRequired()
            .HasForeignKey<int>(ap => ap.ApplicationGroupId);
            this.Filter("SystmGroupsFilter", a => a.Condition(b => b.Type == GroupType.System));
            this.Filter("CustomGroupsFilter", a => a.Condition(b => b.Type == GroupType.Custom));
            ToTable("Groups");
           
        }

    }
}
