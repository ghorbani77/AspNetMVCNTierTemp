using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC5.DomainClasses.Entities
{
    public class ActivityLog
    {
        public virtual int Id { get; set; }
        public virtual string Comment { get; set; }
        public virtual ActivityLogType LogType { get; set; }
        public virtual int LogTypeId { get; set; }
        public virtual int UserId { get; set; }
        public virtual ApplicationUser User { get; set; }
        public virtual DateTime CreateDate { get; set; }
    }
}
