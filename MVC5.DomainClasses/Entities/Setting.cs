using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC5.DomainClasses.Entities
{
    public class Setting
    {
        public virtual int  Id{ get; set; }
        public virtual string Name { get; set; }
        public virtual string Value { get; set; }
    }
}
