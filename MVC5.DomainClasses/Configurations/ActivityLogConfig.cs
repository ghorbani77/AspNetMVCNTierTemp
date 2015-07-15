using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;
using MVC5.DomainClasses.Entities;

namespace MVC5.DomainClasses.Configurations
{
    public class ActivityLogConfig:EntityTypeConfiguration<ActivityLog>
    {
        public ActivityLogConfig()
        {
            Property(a => a.Comment).HasMaxLength(1024).IsRequired();
            Property(a => a.CreateDate).IsRequired();
            Property(a => a.LogTypeId).HasColumnAnnotation("Index",
                new IndexAnnotation(new IndexAttribute("IX_LogTypeId", 1)));
        }
    }
}
