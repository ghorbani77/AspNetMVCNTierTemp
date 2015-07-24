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
    [System.Web.WebPages.PageVirtualPathAttribute("~/Areas/Administrator/Views/User/Create.cshtml")]
    public partial class _Areas_Administrator_Views_User_Create_cshtml : System.Web.Mvc.WebViewPage<MVC5.ViewModel.AdminArea.User.AddUserViewModel>
    {
        public _Areas_Administrator_Views_User_Create_cshtml()
        {
        }
        public override void Execute()
        {
            
            #line 2 "..\..\Areas\Administrator\Views\User\Create.cshtml"
  
    ViewBag.Title = "درج کاربر";

            
            #line default
            #line hidden
WriteLiteral("\r\n\r\n<div");

WriteLiteral(" class=\"row\"");

WriteLiteral(">\r\n    <div");

WriteLiteral(" class=\"col-md-12\"");

WriteLiteral(">\r\n");

            
            #line 8 "..\..\Areas\Administrator\Views\User\Create.cshtml"
        
            
            #line default
            #line hidden
            
            #line 8 "..\..\Areas\Administrator\Views\User\Create.cshtml"
         using (Html.BeginForm(MVC.Administrator.User.ActionNames.Create, MVC.Administrator.User.Name, new { area = "Administrator" }, FormMethod.Post, new { User = "form", @class = "form-horizontal" }))
        {
            
            
            #line default
            #line hidden
            
            #line 10 "..\..\Areas\Administrator\Views\User\Create.cshtml"
       Write(Html.AntiForgeryToken());

            
            #line default
            #line hidden
            
            #line 10 "..\..\Areas\Administrator\Views\User\Create.cshtml"
                                    

            
            #line default
            #line hidden
WriteLiteral("            <div");

WriteLiteral(" class=\"panel panel-default\"");

WriteLiteral(">\r\n                <div");

WriteLiteral(" class=\"panel-heading\"");

WriteLiteral(">\r\n                    <strong>مشخصات کاربر</strong>\r\n                </div>\r\n   " +
"             <div");

WriteLiteral(" class=\"panel-body\"");

WriteLiteral(">\r\n\r\n                    <ul");

WriteLiteral(" class=\"nav nav-tabs\"");

WriteLiteral(">\r\n                        <li");

WriteLiteral(" class=\"active\"");

WriteLiteral(">\r\n                            <a");

WriteLiteral(" href=\"#requiredInfo\"");

WriteLiteral(" data-toggle=\"tab\"");

WriteLiteral(">مشخصات ضروری</a>\r\n                        </li>\r\n                        <li>\r\n " +
"                           <a");

WriteLiteral(" href=\"#optionalInfo\"");

WriteLiteral(" data-toggle=\"tab\"");

WriteLiteral(">مشخصات اختیاری</a>\r\n                        </li>\r\n                        <li>\r" +
"\n                            <a");

WriteLiteral(" href=\"#permissions\"");

WriteLiteral(" data-toggle=\"tab\"");

WriteLiteral(">دسترسی های جزئی</a>\r\n                        </li>\r\n                        <li>" +
"\r\n                            <a");

WriteLiteral(" href=\"#roles\"");

WriteLiteral(" data-toggle=\"tab\"");

WriteLiteral(">گروه های کاربری</a>\r\n                        </li>\r\n                    </ul>\r\n\r" +
"\n                    <div");

WriteLiteral(" class=\"tab-content\"");

WriteLiteral(">\r\n                        <div");

WriteLiteral(" class=\"tab-pane active\"");

WriteLiteral(" id=\"requiredInfo\"");

WriteLiteral(">\r\n                            <div");

WriteLiteral(" class=\"form-group\"");

WriteLiteral(">\r\n");

WriteLiteral("                                ");

            
            #line 35 "..\..\Areas\Administrator\Views\User\Create.cshtml"
                           Write(Html.LabelFor(m => m.Email, new { @class = "col-md-2 control-label" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n                                <div");

WriteLiteral(" class=\"col-md-10\"");

WriteLiteral(">\r\n");

WriteLiteral("                                    ");

            
            #line 37 "..\..\Areas\Administrator\Views\User\Create.cshtml"
                               Write(Html.TextBoxFor(m => m.Email, new { @class = "form-control" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("                                    ");

            
            #line 38 "..\..\Areas\Administrator\Views\User\Create.cshtml"
                               Write(Html.ValidationMessageFor(m => m.Email, "", new { @class = "text-danger" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n                                </div>\r\n                            </div>\r\n   " +
"                         <div");

WriteLiteral(" class=\"form-group\"");

WriteLiteral(">\r\n");

WriteLiteral("                                ");

            
            #line 42 "..\..\Areas\Administrator\Views\User\Create.cshtml"
                           Write(Html.LabelFor(m => m.UserName, new { @class = "col-md-2 control-label" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n                                <div");

WriteLiteral(" class=\"col-md-10\"");

WriteLiteral(">\r\n");

WriteLiteral("                                    ");

            
            #line 44 "..\..\Areas\Administrator\Views\User\Create.cshtml"
                               Write(Html.TextBoxFor(m => m.UserName, new { @class = "form-control" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("                                    ");

            
            #line 45 "..\..\Areas\Administrator\Views\User\Create.cshtml"
                               Write(Html.ValidationMessageFor(m => m.UserName, "", new { @class = "text-danger" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n                                </div>\r\n                            </div>\r\n\r\n " +
"                           <div");

WriteLiteral(" class=\"form-group\"");

WriteLiteral(">\r\n");

WriteLiteral("                                ");

            
            #line 50 "..\..\Areas\Administrator\Views\User\Create.cshtml"
                           Write(Html.LabelFor(m => m.Password, new { @class = "col-md-2 control-label" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n                                <div");

WriteLiteral(" class=\"col-md-10\"");

WriteLiteral(">\r\n");

WriteLiteral("                                    ");

            
            #line 52 "..\..\Areas\Administrator\Views\User\Create.cshtml"
                               Write(Html.TextBoxFor(m => m.Password, new { @class = "form-control" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("                                    ");

            
            #line 53 "..\..\Areas\Administrator\Views\User\Create.cshtml"
                               Write(Html.ValidationMessageFor(m => m.Password, "", new { @class = "text-danger" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n                                </div>\r\n                            </div>\r\n   " +
"                         <div");

WriteLiteral(" class=\"form-group\"");

WriteLiteral(">\r\n");

WriteLiteral("                                ");

            
            #line 57 "..\..\Areas\Administrator\Views\User\Create.cshtml"
                           Write(Html.LabelFor(m => m.FirstName, new { @class = "col-md-2 control-label" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n                                <div");

WriteLiteral(" class=\"col-md-10\"");

WriteLiteral(">\r\n");

WriteLiteral("                                    ");

            
            #line 59 "..\..\Areas\Administrator\Views\User\Create.cshtml"
                               Write(Html.TextBoxFor(m => m.FirstName, new { @class = "form-control" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("                                    ");

            
            #line 60 "..\..\Areas\Administrator\Views\User\Create.cshtml"
                               Write(Html.ValidationMessageFor(m => m.FirstName, "", new { @class = "text-danger" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n                                </div>\r\n                            </div>\r\n\r\n\r" +
"\n                            <div");

WriteLiteral(" class=\"form-group\"");

WriteLiteral(">\r\n");

WriteLiteral("                                ");

            
            #line 66 "..\..\Areas\Administrator\Views\User\Create.cshtml"
                           Write(Html.LabelFor(m => m.LastName, new { @class = "col-md-2 control-label" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n                                <div");

WriteLiteral(" class=\"col-md-10\"");

WriteLiteral(">\r\n");

WriteLiteral("                                    ");

            
            #line 68 "..\..\Areas\Administrator\Views\User\Create.cshtml"
                               Write(Html.TextBoxFor(m => m.LastName, new { @class = "form-control" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("                                    ");

            
            #line 69 "..\..\Areas\Administrator\Views\User\Create.cshtml"
                               Write(Html.ValidationMessageFor(m => m.LastName, "", new { @class = "text-danger" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n                                </div>\r\n                            </div>\r\n   " +
"                     </div>\r\n\r\n                        <div");

WriteLiteral(" class=\"tab-pane\"");

WriteLiteral(" id=\"optionalInfo\"");

WriteLiteral(">\r\n\r\n                            <div");

WriteLiteral(" class=\"form-group\"");

WriteLiteral(">\r\n");

WriteLiteral("                                ");

            
            #line 77 "..\..\Areas\Administrator\Views\User\Create.cshtml"
                           Write(Html.LabelFor(m => m.PhoneNumber, new { @class = "col-md-2 control-label" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n                                <div");

WriteLiteral(" class=\"col-md-10\"");

WriteLiteral(">\r\n");

WriteLiteral("                                    ");

            
            #line 79 "..\..\Areas\Administrator\Views\User\Create.cshtml"
                               Write(Html.TextBoxFor(m => m.PhoneNumber, new { @class = "form-control" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("                                    ");

            
            #line 80 "..\..\Areas\Administrator\Views\User\Create.cshtml"
                               Write(Html.ValidationMessageFor(m => m.PhoneNumber, "", new { @class = "text-danger" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n                                </div>\r\n                            </div>\r\n\r\n " +
"                           <div");

WriteLiteral(" class=\"form-group\"");

WriteLiteral(">\r\n");

WriteLiteral("                                ");

            
            #line 85 "..\..\Areas\Administrator\Views\User\Create.cshtml"
                           Write(Html.LabelFor(m => m.AdministratorComment, new { @class = "col-md-2 control-label" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n                                <div");

WriteLiteral(" class=\"col-md-10\"");

WriteLiteral(">\r\n");

WriteLiteral("                                    ");

            
            #line 87 "..\..\Areas\Administrator\Views\User\Create.cshtml"
                               Write(Html.TextAreaFor(m => m.AdministratorComment, new { @rows = 3, @class = "form-control" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("                                    ");

            
            #line 88 "..\..\Areas\Administrator\Views\User\Create.cshtml"
                               Write(Html.ValidationMessageFor(m => m.AdministratorComment, "", new { @class = "text-danger" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n                                </div>\r\n                            </div>\r\n\r\n " +
"                           <div");

WriteLiteral(" class=\"form-group\"");

WriteLiteral(">\r\n");

WriteLiteral("                                ");

            
            #line 93 "..\..\Areas\Administrator\Views\User\Create.cshtml"
                           Write(Html.LabelFor(m => m.BirthDay, new { @class = "col-md-2 control-label" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n                                <div");

WriteLiteral(" class=\"col-md-10\"");

WriteLiteral(">\r\n");

WriteLiteral("                                    ");

            
            #line 95 "..\..\Areas\Administrator\Views\User\Create.cshtml"
                               Write(Html.TextBoxFor(m => m.BirthDay, new { @class = "form-control" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("                                    ");

            
            #line 96 "..\..\Areas\Administrator\Views\User\Create.cshtml"
                               Write(Html.ValidationMessageFor(m => m.BirthDay, "", new { @class = "text-danger" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n                                </div>\r\n                            </div>\r\n\r\n " +
"                           <div");

WriteLiteral(" class=\"form-group\"");

WriteLiteral(">\r\n");

WriteLiteral("                                ");

            
            #line 101 "..\..\Areas\Administrator\Views\User\Create.cshtml"
                           Write(Html.LabelFor(m => m.GooglePlusId, new { @class = "col-md-2 control-label" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n                                <div");

WriteLiteral(" class=\"col-md-10\"");

WriteLiteral(">\r\n");

WriteLiteral("                                    ");

            
            #line 103 "..\..\Areas\Administrator\Views\User\Create.cshtml"
                               Write(Html.TextBoxFor(m => m.GooglePlusId, new { @class = "form-control" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("                                    ");

            
            #line 104 "..\..\Areas\Administrator\Views\User\Create.cshtml"
                               Write(Html.ValidationMessageFor(m => m.GooglePlusId, "", new { @class = "text-danger" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n                                </div>\r\n                            </div>\r\n   " +
"                         <div");

WriteLiteral(" class=\"form-group\"");

WriteLiteral(">\r\n");

WriteLiteral("                                ");

            
            #line 108 "..\..\Areas\Administrator\Views\User\Create.cshtml"
                           Write(Html.LabelFor(m => m.FaceBookId, new { @class = "col-md-2 control-label" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n                                <div");

WriteLiteral(" class=\"col-md-10\"");

WriteLiteral(">\r\n");

WriteLiteral("                                    ");

            
            #line 110 "..\..\Areas\Administrator\Views\User\Create.cshtml"
                               Write(Html.TextBoxFor(m => m.FaceBookId, new { @class = "form-control" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("                                    ");

            
            #line 111 "..\..\Areas\Administrator\Views\User\Create.cshtml"
                               Write(Html.ValidationMessageFor(m => m.FaceBookId, "", new { @class = "text-danger" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n                                </div>\r\n                            </div>\r\n   " +
"                     </div>\r\n\r\n                        <div");

WriteLiteral(" class=\"tab-pane\"");

WriteLiteral(" id=\"permissions\"");

WriteLiteral(">\r\n                            <div");

WriteLiteral(" class=\"row\"");

WriteLiteral(">\r\n                                <div");

WriteLiteral(" class=\"col-md-4\"");

WriteLiteral(">\r\n");

WriteLiteral("                                    ");

            
            #line 119 "..\..\Areas\Administrator\Views\User\Create.cshtml"
                               Write(Html.CheckBoxFor(m => m.IsBanned, new { @class = "checkbox-inline" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("                                    ");

            
            #line 120 "..\..\Areas\Administrator\Views\User\Create.cshtml"
                               Write(Html.LabelFor(m => m.IsBanned, new { @class = "control-label" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n                                </div>\r\n                              \r\n       " +
"                         <div");

WriteLiteral(" class=\"col-md-4\"");

WriteLiteral(">\r\n");

WriteLiteral("                                    ");

            
            #line 124 "..\..\Areas\Administrator\Views\User\Create.cshtml"
                               Write(Html.CheckBoxFor(m => m.CanChangeProfilePicture, new { @class = "checkbox-inline" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("                                    ");

            
            #line 125 "..\..\Areas\Administrator\Views\User\Create.cshtml"
                               Write(Html.LabelFor(m => m.CanChangeProfilePicture, new { @class = "control-label" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n                                </div>\r\n                                <div");

WriteLiteral(" class=\"col-md-4\"");

WriteLiteral(">\r\n");

WriteLiteral("                                    ");

            
            #line 128 "..\..\Areas\Administrator\Views\User\Create.cshtml"
                               Write(Html.CheckBoxFor(m => m.CanUploadFile, new { @class = "checkbox-inline" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("                                    ");

            
            #line 129 "..\..\Areas\Administrator\Views\User\Create.cshtml"
                               Write(Html.LabelFor(m => m.CanUploadFile, new { @class = "control-label" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n                                </div>\r\n                                <div");

WriteLiteral(" class=\"col-md-4\"");

WriteLiteral(">\r\n");

WriteLiteral("                                    ");

            
            #line 132 "..\..\Areas\Administrator\Views\User\Create.cshtml"
                               Write(Html.CheckBoxFor(m => m.CanModifyFirsAndLastName, new { @class = "checkbox-inline" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("                                    ");

            
            #line 133 "..\..\Areas\Administrator\Views\User\Create.cshtml"
                               Write(Html.LabelFor(m => m.CanModifyFirsAndLastName, new { @class = "control-label" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n                                </div>\r\n                            </div>\r\n   " +
"                     </div>\r\n\r\n                        <div");

WriteLiteral(" class=\"tab-pane\"");

WriteLiteral(" id=\"roles\"");

WriteLiteral(">\r\n                            <div");

WriteLiteral(" class=\"row\"");

WriteLiteral(">\r\n");

            
            #line 140 "..\..\Areas\Administrator\Views\User\Create.cshtml"
                                    
            
            #line default
            #line hidden
            
            #line 140 "..\..\Areas\Administrator\Views\User\Create.cshtml"
                                     foreach (var role in (IEnumerable<SelectListItem>)ViewBag.Roles)
                                    {

            
            #line default
            #line hidden
WriteLiteral("                                        ");

WriteLiteral("\r\n                                            <div");

WriteLiteral(" class=\"col-md-4\"");

WriteLiteral(">\r\n                                                <input");

WriteLiteral(" type=\"checkbox\"");

WriteLiteral(" name=\"RoleIds\"");

WriteAttribute("value", Tuple.Create(" value=\"", 8758), Tuple.Create("\"", 8777)
            
            #line 144 "..\..\Areas\Administrator\Views\User\Create.cshtml"
             , Tuple.Create(Tuple.Create("", 8766), Tuple.Create<System.Object, System.Int32>(role.Value
            
            #line default
            #line hidden
, 8766), false)
);

WriteLiteral(" class=\"checkbox-inline\"");

WriteLiteral(" />\r\n                                                <label");

WriteLiteral(" class=\"control-label\"");

WriteLiteral(">");

            
            #line 145 "..\..\Areas\Administrator\Views\User\Create.cshtml"
                                                                        Write(role.Text);

            
            #line default
            #line hidden
WriteLiteral("</label>\r\n                                            </div>\r\n                   " +
"                     ");

WriteLiteral("\r\n");

            
            #line 148 "..\..\Areas\Administrator\Views\User\Create.cshtml"
                                    }

            
            #line default
            #line hidden
WriteLiteral("                            </div>\r\n                        </div>\r\n             " +
"       </div>\r\n\r\n                </div>\r\n                \r\n                <div");

WriteLiteral(" class=\"panel-footer\"");

WriteLiteral(">\r\n                    <div");

WriteLiteral(" class=\"row\"");

WriteLiteral(">\r\n                        <div");

WriteLiteral(" class=\"col-md-12\"");

WriteLiteral(">\r\n                            <input");

WriteLiteral(" type=\"submit\"");

WriteLiteral(" class=\"btn btn-success btn-sm btn-block\"");

WriteLiteral(" value=\"ثبت اطلاعات\"");

WriteLiteral(" />\r\n                        </div>\r\n                    </div>\r\n                " +
"</div>\r\n            </div>\r\n");

            
            #line 163 "..\..\Areas\Administrator\Views\User\Create.cshtml"
        }

            
            #line default
            #line hidden
WriteLiteral("    </div>\r\n</div>\r\n");

DefineSection("Scripts", () => {

WriteLiteral("\r\n");

});

        }
    }
}
#pragma warning restore 1591
