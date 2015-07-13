using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVC5.DomainClasses.Entities;

namespace MVC5.DomainClasses.Configurations
{
   public class SettingConfig:EntityTypeConfiguration<Setting>
   {
       public SettingConfig()
       {
           Property(s => s.Name).HasMaxLength(50);
           Property(s => s.Value).HasMaxLength(50);
       }
    }
}
