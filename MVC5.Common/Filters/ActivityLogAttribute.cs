using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC5.Common.Filters
{
    [AttributeUsage(AttributeTargets.Method)]
    public class ActivityLogAttribute : Attribute
    {
        public string Name { get; set; }
        public string Description { get; set; }

    }
}
