using System.ComponentModel.DataAnnotations;
using Microsoft.AspNet.Identity.EntityFramework;

namespace MVC5.DomainClasses.Entities
{
    
    public class ApplicationRole : IdentityRole<int, ApplicationUserRole>
    {
        public string Descriptions { get; set; }
    }
}
