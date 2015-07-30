using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Web.Mvc;
using MVC5.Common.Controller;
using MVC5.Common.Helpers.Extentions;
using MVC5.DomainClasses.Entities;
using MVC5.Web.Filters;

namespace MVC5.Web
{
    public static class SystemConfiguration
    {
        #region PermissionConfiguration

        public static IEnumerable<ApplicationPermission> ConfigPermissions()
        {
            var controllers =
                Assembly.GetExecutingAssembly().GetTypes()
                    .Where(
                        t =>
                            t.BaseType == typeof(BaseController) &&
                            t.CustomAttributes.Any(a => a.AttributeType == typeof(MvcAuthorizeAttribute)))
                    .ToList();

            var permissionsListToAdd = new List<ApplicationPermission>();

            foreach (var controller in controllers)
            {
                var authorizeAttribute =
                   controller.GetCustomAttribut<MvcAuthorizeAttribute>();

                if (authorizeAttribute == null)
                    continue;
                var controllerName = controller.Name.Replace("Controller", "").ToLower();
                var areaName = authorizeAttribute.AreaName.IsNotEmpty() ? authorizeAttribute.AreaName.ToLower() : "";

                var actionMethodsList =
                    controller.GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly)
                        .Where(method => (typeof(ActionResult).IsAssignableFrom(method.ReturnType) ||
                            typeof(Task<ActionResult>).IsAssignableFrom(method.ReturnType))
                                         &&
                                         method.CustomAttributes.All(
                                             a => a.AttributeType != typeof(ChildActionOnlyAttribute))
                                         &&
                                         method.CustomAttributes.All(
                                             a => a.AttributeType != typeof(AllowAnonymousAttribute))
                                         &&
                                         method.CustomAttributes.Any(
                                             a => a.AttributeType == typeof(DisplayNameAttribute)))
                        .ToList();

                permissionsListToAdd.AddRange(from methodInfo in actionMethodsList
                    let actionName = methodInfo.Name.ToLower()
                    let displayName = methodInfo.GetCustomAttribute<DisplayNameAttribute>().DisplayName
                    select new ApplicationPermission
                    {
                        AreaName = areaName, ControllerName = controllerName, ActionName = actionName, IsMenu = authorizeAttribute.IsMenu, Name = displayName
                    });
            }

            return permissionsListToAdd;
        }
        #endregion
    }
}