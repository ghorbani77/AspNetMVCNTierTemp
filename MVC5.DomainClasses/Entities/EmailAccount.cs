using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC5.DomainClasses.Entities
{
    public class EmailAccount
    {
        public virtual int Id { get; set; }
        public virtual string EmailAddress { get; set; }
        public virtual bool UserSsl { get; set; }
        public virtual bool IsDefaultEmail { get; set; }
        public virtual string Host { get; set; }
        public virtual string UserName { get; set; }
        public virtual string Password { get; set; }
        public virtual bool  UserDefaultCredential { get; set; }
        public virtual string EmailDisplayName { get; set; }
        public virtual int PortNumber { get; set; }
    }
}
