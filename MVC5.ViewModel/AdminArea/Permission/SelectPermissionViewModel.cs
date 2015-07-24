using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace MVC5.ViewModel.AdminArea.Permission
{
    public class SelectPermissionViewModel : SelectListItem
    {
        public List<SelectPermissionViewModel> Children  { get; set; }
    }
}
