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
                            t.BaseType == typeof(BaseController))
                    .ToList();

            var permissionsListToAdd = new List<ApplicationPermission>();

            foreach (var controller in controllers)
            {
                var controllerName = controller.Name.Replace("Controller", "").ToLower();

                var actionMethodsList =
                    controller.GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly)
                        .Where(method => (typeof (ActionResult).IsAssignableFrom(method.ReturnType) ||
                                          typeof (Task<ActionResult>).IsAssignableFrom(method.ReturnType))
                                         &&
                                         method.CustomAttributes.All(
                                             a => a.AttributeType != typeof (ChildActionOnlyAttribute))
                                         &&
                                         method.CustomAttributes.All(
                                             a => a.AttributeType != typeof (AllowAnonymousAttribute))
                                         &&
                                         method.CustomAttributes.Any(
                                             a => a.AttributeType == typeof (DisplayNameAttribute))
                                         &&
                                         method.CustomAttributes.Any(
                                             a => a.AttributeType == typeof (Mvc5AuthorizeAttribute)))
                        .ToList();

                permissionsListToAdd.AddRange(from methodInfo in actionMethodsList
                                              let actionName = methodInfo.Name.ToLower()
                                              let displayName = methodInfo.GetCustomAttribute<DisplayNameAttribute>().DisplayName
                                              let authorizeAttribute = methodInfo.GetCustomAttribute<Mvc5AuthorizeAttribute>()
                                              let areaName = authorizeAttribute.AreaName.IsNotEmpty() ? authorizeAttribute.AreaName.ToLower() : ""
                                              select new ApplicationPermission
                                              {
                                                  Description = displayName,
                                                  AreaName = areaName,
                                                  ControllerName = controllerName,
                                                  ActionName = actionName,
                                                  IsMenu = authorizeAttribute.IsMenu,
                                                  Name = authorizeAttribute.Roles
                                              });
            }

            return permissionsListToAdd;
        }
        #endregion
    }
}