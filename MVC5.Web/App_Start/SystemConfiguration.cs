using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using MVC5.Common.Controller;
using MVC5.Common.Helpers.Extentions;
using MVC5.DomainClasses.Entities;
using MVC5.Web.Filters;

namespace MVC5.Web
{
    public static class SystemConfiguration
    {
        //#region PermissionConfiguration

        //public static IEnumerable<ApplicationPermission> ConfigPermissions()
        //{
        //    var controllers =
        //        Assembly.GetExecutingAssembly()
        //            .GetTypes()
        //            .Where(
        //                t =>
        //                    t.BaseType == typeof(BaseController) &&
        //                    t.CustomAttributes.Any(a => a.AttributeType == typeof(MvcAuthorizeAttribute)))
        //            .ToList();

        //    var addedPermissions = new List<string>();
        //    var permissionsListToAdd = new List<ApplicationPermission>();

        //    foreach (var controller in controllers)
        //    {
        //        var authorizeAttribute =
        //           controller.GetCustomAttribut<MvcAuthorizeAttribute>();

        //        if (authorizeAttribute == null)
        //            continue;

        //        //set controller name
        //        var routePrefix = controller.GetCustomAttribut<RoutePrefixAttribute>();
        //        var controllerName = routePrefix == null
        //            ? controller.Name.Replace("Controller", "").ToLower()
        //            : routePrefix.Prefix.ToLower();

        //        //set area name . for this project RouteArea Attr should be Assign to Controller
        //        var areaName = controller.GetCustomAttribut<RouteAreaAttribute>().AreaName.ToLower();

        //        //instantiate new permission that is parent permission 
        //        var parentPermission = new ApplicationPermission
        //        {
        //            AreaName = areaName,
        //            ControllerName = controllerName,
        //            ActionName = authorizeAttribute.DefaultActioName,
        //            IsMenu = authorizeAttribute.CanBeMenu,
        //            Name = authorizeAttribute.Roles,
        //            Description = authorizeAttribute.Description
        //        };

        //        //get all  action methods for special controller
        //        var actionMethodsList = controller.GetMethods()
        //            .Where(x =>
        //                x.CustomAttributes.Any(a => a.AttributeType == typeof(MvcAuthorizeAttribute)));

        //        //add instantiated permission to list  that will add to db
        //        permissionsListToAdd.Add(parentPermission);
        //        //add permission names that added to permissionsListToAdd to prevent duplicate permission name
        //        addedPermissions.Add(parentPermission.Name);

        //        foreach (var methodInfo in actionMethodsList)
        //        {
        //            authorizeAttribute =
        //                methodInfo.GetCustomAttribute<MvcAuthorizeAttribute>();
        //            if (authorizeAttribute == null || !authorizeAttribute.Description.IsNotEmpty()) continue;


        //            var routeAttribute = methodInfo.GetCustomAttribute<RouteAttribute>();

        //            //set method name .if route attribute set to action , then we can user it for set action Name of permission
        //            var methodName = routeAttribute == null
        //                ? methodInfo.Name.ToLower()
        //                : routeAttribute.Template.ToLower();

        //            //set permission name if this name isn't int added List 
        //            var childPermissionName =
        //                authorizeAttribute.Roles.Split(',').FirstOrDefault(a => addedPermissions.All(b => b != a));

        //            if (!childPermissionName.IsNotEmpty()) continue;

        //            var childPermission = new ApplicationPermission
        //            {
        //                AreaName = areaName,
        //                ControllerName = controllerName,
        //                ActionName = methodName,
        //                IsMenu = authorizeAttribute.CanBeMenu,
        //                Name = childPermissionName,
        //                Description = authorizeAttribute.Description,

        //            };

        //            addedPermissions.Add(childPermissionName);
        //            permissionsListToAdd.Add(childPermission);
        //        }
        //    }

        //    return permissionsListToAdd;
        //}
        //#endregion
    }
}