using System.Web.Mvc;
using Microsoft.AspNet.Identity;

namespace MVC5.Web.Extention
{
    public static class ControllerExtention
    {
        [NonAction]
        public static void AddErrors(this Controller controller, IdentityResult result)
        {
            foreach (var error in result.Errors)
            {

                controller.ModelState.AddModelError("", error);
            }
        }
        [NonAction]
        public static void AddErrors(this Controller controller, string property, string error)
        {
            controller.ModelState.AddModelError(property, error);
        }
    }
}