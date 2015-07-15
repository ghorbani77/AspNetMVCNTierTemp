using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC5.DomainClasses.Entities
{
    public class ActivityLogType
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual bool IsEnable { get; set; }
        public virtual ICollection<ActivityLog> ActivityLogs  { get; set; }
    }
}
