using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVC5.DomainClasses.Entities;

namespace MVC5.DomainClasses.Configurations
{
    public class ActivityLogTypeConfig : EntityTypeConfiguration<ActivityLogType>
    {
        public ActivityLogTypeConfig()
        {
            Property(a => a.Name).HasMaxLength(50).IsRequired().HasColumnAnnotation("Index",
                new IndexAnnotation(new IndexAttribute("IX_ActivityLogName", 1) {IsUnique = true}));
            HasMany(a => a.ActivityLogs)
                .WithRequired(a => a.LogType)
                .HasForeignKey(a => a.LogTypeId)
                .WillCascadeOnDelete(true);
        }
    }
}
