using System.ComponentModel.DataAnnotations;
using Microsoft.AspNet.Identity.EntityFramework;

namespace MVC5.DomainClasses.Entities
{
    
    public class ApplicationRole : IdentityRole<int, ApplicationUserRole>
    {
        [MaxLength(50)]
        public string Descriptions { get; set; }
    }
}
