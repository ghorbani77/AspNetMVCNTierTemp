﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34014
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ASP
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Text;
    using System.Web;
    using System.Web.Helpers;
    using System.Web.Mvc;
    using System.Web.Mvc.Ajax;
    using System.Web.Mvc.Html;
    using System.Web.Optimization;
    using System.Web.Routing;
    using System.Web.Security;
    using System.Web.UI;
    using System.Web.WebPages;
    using MVC5.Web;
    using StackExchange.Profiling;
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/Areas/Administrator/Views/Role/Create.cshtml")]
    public partial class _Areas_Administrator_Views_Role_Create_cshtml : System.Web.Mvc.WebViewPage<MVC5.ViewModel.AdminArea.Role.AddRoleViewModel>
    {
        public _Areas_Administrator_Views_Role_Create_cshtml()
        {
        }
        public override void Execute()
        {
            
            #line 2 "..\..\Areas\Administrator\Views\Role\Create.cshtml"
  
    ViewBag.Title = "درج نقش کاربری";

            
            #line default
            #line hidden
WriteLiteral("\r\n\r\n<div");

WriteLiteral(" class=\"row\"");

WriteLiteral(">\r\n    <div");

WriteLiteral(" class=\"col-md-10 col-md-offset-1\"");

WriteLiteral(">\r\n");

            
            #line 8 "..\..\Areas\Administrator\Views\Role\Create.cshtml"
        
            
            #line default
            #line hidden
            
            #line 8 "..\..\Areas\Administrator\Views\Role\Create.cshtml"
         using (Html.BeginForm(MVC.Administrator.Role.ActionNames.Create, MVC.Administrator.Role.Name, new { area = "Administrator" }, FormMethod.Post, new { role = "form", @class = "form-horizontal" }))
        {
            
            
            #line default
            #line hidden
            
            #line 10 "..\..\Areas\Administrator\Views\Role\Create.cshtml"
       Write(Html.AntiForgeryToken());

            
            #line default
            #line hidden
            
            #line 10 "..\..\Areas\Administrator\Views\Role\Create.cshtml"
                                    

            
            #line default
            #line hidden
WriteLiteral("            <div");

WriteLiteral(" class=\"jumbotron custom\"");

WriteLiteral(">\r\n                <div");

WriteLiteral(" class=\"form-group\"");

WriteLiteral(">\r\n");

WriteLiteral("                    ");

            
            #line 13 "..\..\Areas\Administrator\Views\Role\Create.cshtml"
               Write(Html.LabelFor(m => m.Name, new { @class = "col-md-2 control-label" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n                    <div");

WriteLiteral(" class=\"col-md-10\"");

WriteLiteral(">\r\n");

WriteLiteral("                        ");

            
            #line 15 "..\..\Areas\Administrator\Views\Role\Create.cshtml"
                   Write(Html.TextBoxFor(m => m.Name, new { @class = "form-control" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("                        ");

            
            #line 16 "..\..\Areas\Administrator\Views\Role\Create.cshtml"
                   Write(Html.ValidationMessageFor(m => m.Name, "", new { @class = "text-danger" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n                    </div>\r\n                </div>\r\n                <div");

WriteLiteral(" class=\"form-group\"");

WriteLiteral(">\r\n");

WriteLiteral("                    ");

            
            #line 20 "..\..\Areas\Administrator\Views\Role\Create.cshtml"
               Write(Html.LabelFor(m => m.Description, new { @class = "col-md-2 control-label" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n                    <div");

WriteLiteral(" class=\"col-md-10\"");

WriteLiteral(">\r\n");

WriteLiteral("                        ");

            
            #line 22 "..\..\Areas\Administrator\Views\Role\Create.cshtml"
                   Write(Html.TextBoxFor(m => m.Description, new { @class = "form-control" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("                        ");

            
            #line 23 "..\..\Areas\Administrator\Views\Role\Create.cshtml"
                   Write(Html.ValidationMessageFor(m => m.Description, "", new { @class = "text-danger" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n                    </div>\r\n                </div>\r\n                <div");

WriteLiteral(" class=\"form-group\"");

WriteLiteral(">\r\n                    <div");

WriteLiteral(" class=\"col-md-2 col-md-offset-2\"");

WriteLiteral(">\r\n");

WriteLiteral("                        ");

            
            #line 28 "..\..\Areas\Administrator\Views\Role\Create.cshtml"
                   Write(Html.CheckBoxFor(m => m.IsActive, new { @class = "checkbox-inline" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("                        ");

            
            #line 29 "..\..\Areas\Administrator\Views\Role\Create.cshtml"
                   Write(Html.LabelFor(m => m.IsActive, new { @class = "control-label" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n                    </div>\r\n                    <div");

WriteLiteral(" class=\"col-md-3\"");

WriteLiteral(">\r\n");

WriteLiteral("                        ");

            
            #line 32 "..\..\Areas\Administrator\Views\Role\Create.cshtml"
                   Write(Html.CheckBoxFor(m => m.IsDefaultForRegister, new { @class = "checkbox-inline" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("                        ");

            
            #line 33 "..\..\Areas\Administrator\Views\Role\Create.cshtml"
                   Write(Html.LabelFor(m => m.IsDefaultForRegister, new { @class = "control-label" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n                    </div>\r\n                </div>\r\n\r\n            </div>\r\n");

WriteLiteral("            <hr />\r\n");

WriteLiteral("            <strong>دسترسی ها</strong>\r\n");

WriteLiteral("            <div");

WriteLiteral(" class=\"jumbotron custom\"");

WriteLiteral(">\r\n                <div");

WriteLiteral(" class=\"row\"");

WriteLiteral(">\r\n                    <div");

WriteLiteral(" class=\"col-md-12\"");

WriteLiteral(">\r\n");

            
            #line 43 "..\..\Areas\Administrator\Views\Role\Create.cshtml"
                        
            
            #line default
            #line hidden
            
            #line 43 "..\..\Areas\Administrator\Views\Role\Create.cshtml"
                         foreach (var permission in (IEnumerable<SelectListItem>)ViewBag.Permissions)
                        {

            
            #line default
            #line hidden
WriteLiteral("                            ");

WriteLiteral("\r\n                                <div");

WriteLiteral(" class=\"col-md-4\"");

WriteLiteral(">\r\n                                    <input");

WriteLiteral(" type=\"checkbox\"");

WriteLiteral(" name=\"PermissionIds\"");

WriteAttribute("value", Tuple.Create(" value=\"", 2457), Tuple.Create("\"", 2482)
            
            #line 47 "..\..\Areas\Administrator\Views\Role\Create.cshtml"
       , Tuple.Create(Tuple.Create("", 2465), Tuple.Create<System.Object, System.Int32>(permission.Value
            
            #line default
            #line hidden
, 2465), false)
);

WriteLiteral(" class=\"checkbox-inline\"");

WriteLiteral(" />\r\n                                    <label");

WriteLiteral(" class=\"control-label\"");

WriteLiteral(">");

            
            #line 48 "..\..\Areas\Administrator\Views\Role\Create.cshtml"
                                                            Write(permission.Text);

            
            #line default
            #line hidden
WriteLiteral("</label>\r\n                                </div>\r\n                            ");

WriteLiteral("\r\n");

            
            #line 51 "..\..\Areas\Administrator\Views\Role\Create.cshtml"
                        }

            
            #line default
            #line hidden
WriteLiteral("                    </div>\r\n                </div>\r\n            </div>\r\n");

            
            #line 55 "..\..\Areas\Administrator\Views\Role\Create.cshtml"


            
            #line default
            #line hidden
WriteLiteral("            <hr />\r\n");

WriteLiteral("            <div");

WriteLiteral(" class=\"row\"");

WriteLiteral(">\r\n                <div");

WriteLiteral(" class=\"col-md-12\"");

WriteLiteral(">\r\n                    <div");

WriteLiteral(" class=\"form-group\"");

WriteLiteral(">\r\n                        <div");

WriteLiteral(" class=\"col-md-12\"");

WriteLiteral(">\r\n                            <input");

WriteLiteral(" type=\"submit\"");

WriteLiteral(" class=\"btn btn-success btn-sm btn-block\"");

WriteLiteral(" value=\"ثبت اطلاعات\"");

WriteLiteral(" />\r\n                        </div>\r\n                    </div>\r\n                " +
"</div>\r\n            </div>\r\n");

            
            #line 66 "..\..\Areas\Administrator\Views\Role\Create.cshtml"

        }

            
            #line default
            #line hidden
WriteLiteral("    </div>\r\n\r\n\r\n</div>\r\n");

DefineSection("Scripts", () => {

WriteLiteral("\r\n");

WriteLiteral("    ");

            
            #line 73 "..\..\Areas\Administrator\Views\Role\Create.cshtml"
Write(Scripts.Render("~/bundles/jqueryval"));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

});

        }
    }
}
#pragma warning restore 1591
