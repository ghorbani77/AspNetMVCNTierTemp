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
   public class SettingConfig:EntityTypeConfiguration<Setting>
   {
       public SettingConfig()
       {
           HasKey(a =>new
           {
               a.Name,
               a.Type
           });

           Property(s => s.Name).HasMaxLength(50).IsRequired().HasColumnAnnotation("Index",
               new IndexAnnotation(new IndexAttribute("IX_SettingName")));

           Property(s => s.Value).IsOptional();
       }
    }
}
