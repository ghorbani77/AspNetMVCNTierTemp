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
         using (Html.BeginForm(MVC.Administrator.User.ActionNames.Create, MVC.Administrator.User.Name, new { area = MVC.Administrator.Name }, FormMethod.Post, new { User = "form", @class = "form-horizontal" }))
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

WriteLiteral(">دسترسی های</a>\r\n                        </li>\r\n                        <li>\r\n   " +
"                         <a");

WriteLiteral(" href=\"#settings\"");

WriteLiteral(" data-toggle=\"tab\"");

WriteLiteral(">تنظیمات کاربری</a>\r\n                        </li>\r\n                        <li>\r" +
"\n                            <a");

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

            
            #line 38 "..\..\Areas\Administrator\Views\User\Create.cshtml"
                           Write(Html.LabelFor(m => m.Email, new { @class = "col-md-2 control-label" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n                                <div");

WriteLiteral(" class=\"col-md-10\"");

WriteLiteral(">\r\n");

WriteLiteral("                                    ");

            
            #line 40 "..\..\Areas\Administrator\Views\User\Create.cshtml"
                               Write(Html.TextBoxFor(m => m.Email, new { @class = "form-control" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("                                    ");

            
            #line 41 "..\..\Areas\Administrator\Views\User\Create.cshtml"
                               Write(Html.ValidationMessageFor(m => m.Email, "", new { @class = "text-danger" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n                                </div>\r\n                            </div>\r\n   " +
"                         <div");

WriteLiteral(" class=\"form-group\"");

WriteLiteral(">\r\n");

WriteLiteral("                                ");

            
            #line 45 "..\..\Areas\Administrator\Views\User\Create.cshtml"
                           Write(Html.LabelFor(m => m.UserName, new { @class = "col-md-2 control-label" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n                                <div");

WriteLiteral(" class=\"col-md-10\"");

WriteLiteral(">\r\n");

WriteLiteral("                                    ");

            
            #line 47 "..\..\Areas\Administrator\Views\User\Create.cshtml"
                               Write(Html.TextBoxFor(m => m.UserName, new { @class = "form-control" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("                                    ");

            
            #line 48 "..\..\Areas\Administrator\Views\User\Create.cshtml"
                               Write(Html.ValidationMessageFor(m => m.UserName, "", new { @class = "text-danger" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n                                </div>\r\n                            </div>\r\n\r\n " +
"                           <div");

WriteLiteral(" class=\"form-group\"");

WriteLiteral(">\r\n");

WriteLiteral("                                ");

            
            #line 53 "..\..\Areas\Administrator\Views\User\Create.cshtml"
                           Write(Html.LabelFor(m => m.Password, new { @class = "col-md-2 control-label" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n                                <div");

WriteLiteral(" class=\"col-md-10\"");

WriteLiteral(">\r\n");

WriteLiteral("                                    ");

            
            #line 55 "..\..\Areas\Administrator\Views\User\Create.cshtml"
                               Write(Html.TextBoxFor(m => m.Password, new { @class = "form-control" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("                                    ");

            
            #line 56 "..\..\Areas\Administrator\Views\User\Create.cshtml"
                               Write(Html.ValidationMessageFor(m => m.Password, "", new { @class = "text-danger" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n                                </div>\r\n                            </div>\r\n   " +
"                         <div");

WriteLiteral(" class=\"form-group\"");

WriteLiteral(">\r\n");

WriteLiteral("                                ");

            
            #line 60 "..\..\Areas\Administrator\Views\User\Create.cshtml"
                           Write(Html.LabelFor(m => m.FirstName, new { @class = "col-md-2 control-label" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n                                <div");

WriteLiteral(" class=\"col-md-10\"");

WriteLiteral(">\r\n");

WriteLiteral("                                    ");

            
            #line 62 "..\..\Areas\Administrator\Views\User\Create.cshtml"
                               Write(Html.TextBoxFor(m => m.FirstName, new { @class = "form-control" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("                                    ");

            
            #line 63 "..\..\Areas\Administrator\Views\User\Create.cshtml"
                               Write(Html.ValidationMessageFor(m => m.FirstName, "", new { @class = "text-danger" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n                                </div>\r\n                            </div>\r\n\r\n\r" +
"\n                            <div");

WriteLiteral(" class=\"form-group\"");

WriteLiteral(">\r\n");

WriteLiteral("                                ");

            
            #line 69 "..\..\Areas\Administrator\Views\User\Create.cshtml"
                           Write(Html.LabelFor(m => m.LastName, new { @class = "col-md-2 control-label" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n                                <div");

WriteLiteral(" class=\"col-md-10\"");

WriteLiteral(">\r\n");

WriteLiteral("                                    ");

            
            #line 71 "..\..\Areas\Administrator\Views\User\Create.cshtml"
                               Write(Html.TextBoxFor(m => m.LastName, new { @class = "form-control" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("                                    ");

            
            #line 72 "..\..\Areas\Administrator\Views\User\Create.cshtml"
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

            
            #line 80 "..\..\Areas\Administrator\Views\User\Create.cshtml"
                           Write(Html.LabelFor(m => m.PhoneNumber, new { @class = "col-md-2 control-label" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n                                <div");

WriteLiteral(" class=\"col-md-10\"");

WriteLiteral(">\r\n");

WriteLiteral("                                    ");

            
            #line 82 "..\..\Areas\Administrator\Views\User\Create.cshtml"
                               Write(Html.TextBoxFor(m => m.PhoneNumber, new { @class = "form-control" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("                                    ");

            
            #line 83 "..\..\Areas\Administrator\Views\User\Create.cshtml"
                               Write(Html.ValidationMessageFor(m => m.PhoneNumber, "", new { @class = "text-danger" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n                                </div>\r\n                            </div>\r\n\r\n " +
"                           <div");

WriteLiteral(" class=\"form-group\"");

WriteLiteral(">\r\n");

WriteLiteral("                                ");

            
            #line 88 "..\..\Areas\Administrator\Views\User\Create.cshtml"
                           Write(Html.LabelFor(m => m.AdministratorComment, new { @class = "col-md-2 control-label" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n                                <div");

WriteLiteral(" class=\"col-md-10\"");

WriteLiteral(">\r\n");

WriteLiteral("                                    ");

            
            #line 90 "..\..\Areas\Administrator\Views\User\Create.cshtml"
                               Write(Html.TextAreaFor(m => m.AdministratorComment, new { @rows = 3, @class = "form-control" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("                                    ");

            
            #line 91 "..\..\Areas\Administrator\Views\User\Create.cshtml"
                               Write(Html.ValidationMessageFor(m => m.AdministratorComment, "", new { @class = "text-danger" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n                                </div>\r\n                            </div>\r\n\r\n\r" +
"\n                            <div");

WriteLiteral(" class=\"form-group\"");

WriteLiteral(">\r\n");

WriteLiteral("                                ");

            
            #line 97 "..\..\Areas\Administrator\Views\User\Create.cshtml"
                           Write(Html.LabelFor(m => m.GooglePlusId, new { @class = "col-md-2 control-label" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n                                <div");

WriteLiteral(" class=\"col-md-10\"");

WriteLiteral(">\r\n");

WriteLiteral("                                    ");

            
            #line 99 "..\..\Areas\Administrator\Views\User\Create.cshtml"
                               Write(Html.TextBoxFor(m => m.GooglePlusId, new { @class = "form-control" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("                                    ");

            
            #line 100 "..\..\Areas\Administrator\Views\User\Create.cshtml"
                               Write(Html.ValidationMessageFor(m => m.GooglePlusId, "", new { @class = "text-danger" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n                                </div>\r\n                            </div>\r\n   " +
"                         <div");

WriteLiteral(" class=\"form-group\"");

WriteLiteral(">\r\n");

WriteLiteral("                                ");

            
            #line 104 "..\..\Areas\Administrator\Views\User\Create.cshtml"
                           Write(Html.LabelFor(m => m.FaceBookId, new { @class = "col-md-2 control-label" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n                                <div");

WriteLiteral(" class=\"col-md-10\"");

WriteLiteral(">\r\n");

WriteLiteral("                                    ");

            
            #line 106 "..\..\Areas\Administrator\Views\User\Create.cshtml"
                               Write(Html.TextBoxFor(m => m.FaceBookId, new { @class = "form-control" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("                                    ");

            
            #line 107 "..\..\Areas\Administrator\Views\User\Create.cshtml"
                               Write(Html.ValidationMessageFor(m => m.FaceBookId, "", new { @class = "text-danger" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n                                </div>\r\n                            </div>\r\n   " +
"                         <div");

WriteLiteral(" class=\"form-group\"");

WriteLiteral(">\r\n");

WriteLiteral("                                ");

            
            #line 111 "..\..\Areas\Administrator\Views\User\Create.cshtml"
                           Write(Html.LabelFor(m => m.AvatarFileName, new { @class = "col-md-2 control-label" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n                                <div");

WriteLiteral(" class=\"col-md-10\"");

WriteLiteral(" dir=\"ltr\"");

WriteLiteral(">\r\n                                    <input");

WriteLiteral(" id=\"AvatarImage\"");

WriteLiteral(" name=\"AvatarImage\"");

WriteLiteral(" type=\"file\"");

WriteLiteral(" accept=\"image/*\"");

WriteLiteral(">\r\n                                </div>\r\n                            </div>\r\n  " +
"                      </div>\r\n                        <div");

WriteLiteral(" class=\"tab-pane\"");

WriteLiteral(" id=\"permissions\"");

WriteLiteral(">\r\n                            <div");

WriteLiteral(" class=\"row\"");

WriteLiteral(">\r\n");

            
            #line 119 "..\..\Areas\Administrator\Views\User\Create.cshtml"
                                
            
            #line default
            #line hidden
            
            #line 119 "..\..\Areas\Administrator\Views\User\Create.cshtml"
                                 foreach (var permission in (IEnumerable<SelectListItem>)ViewBag.Permissions)
                                {

            
            #line default
            #line hidden
WriteLiteral("                                    ");

WriteLiteral("\r\n                                        <div");

WriteLiteral(" class=\"col-md-4\"");

WriteLiteral(">\r\n                                            <input");

WriteLiteral(" type=\"checkbox\"");

WriteAttribute("id", Tuple.Create(" id=\"", 7279), Tuple.Create("\"", 7301)
            
            #line 123 "..\..\Areas\Administrator\Views\User\Create.cshtml"
, Tuple.Create(Tuple.Create("", 7284), Tuple.Create<System.Object, System.Int32>(permission.Value
            
            #line default
            #line hidden
, 7284), false)
);

WriteLiteral(" name=\"PermissionIds\"");

WriteAttribute("value", Tuple.Create(" value=\"", 7323), Tuple.Create("\"", 7348)
            
            #line 123 "..\..\Areas\Administrator\Views\User\Create.cshtml"
                                      , Tuple.Create(Tuple.Create("", 7331), Tuple.Create<System.Object, System.Int32>(permission.Value
            
            #line default
            #line hidden
, 7331), false)
);

WriteLiteral(" class=\"checkbox-inline\"");

WriteLiteral(" />\r\n                                            <label");

WriteAttribute("for", Tuple.Create(" for=\"", 7428), Tuple.Create("\"", 7451)
            
            #line 124 "..\..\Areas\Administrator\Views\User\Create.cshtml"
, Tuple.Create(Tuple.Create("", 7434), Tuple.Create<System.Object, System.Int32>(permission.Value
            
            #line default
            #line hidden
, 7434), false)
);

WriteLiteral(" class=\"control-label\"");

WriteLiteral(">");

            
            #line 124 "..\..\Areas\Administrator\Views\User\Create.cshtml"
                                                                                            Write(permission.Text);

            
            #line default
            #line hidden
WriteLiteral("</label>\r\n                                        </div>\r\n                       " +
"             ");

WriteLiteral("\r\n");

            
            #line 127 "..\..\Areas\Administrator\Views\User\Create.cshtml"
                                }

            
            #line default
            #line hidden
WriteLiteral("                            </div>\r\n                        </div>\r\n             " +
"           <div");

WriteLiteral(" class=\"tab-pane\"");

WriteLiteral(" id=\"settings\"");

WriteLiteral(">\r\n                            <div");

WriteLiteral(" class=\"row\"");

WriteLiteral(">\r\n                                <div");

WriteLiteral(" class=\"col-md-4\"");

WriteLiteral(">\r\n");

WriteLiteral("                                    ");

            
            #line 133 "..\..\Areas\Administrator\Views\User\Create.cshtml"
                               Write(Html.CheckBoxFor(m => m.IsBanned, new { @class = "checkbox-inline" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("                                    ");

            
            #line 134 "..\..\Areas\Administrator\Views\User\Create.cshtml"
                               Write(Html.LabelFor(m => m.IsBanned, new { @class = "control-label" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n                                </div>\r\n\r\n                                <div");

WriteLiteral(" class=\"col-md-4\"");

WriteLiteral(">\r\n");

WriteLiteral("                                    ");

            
            #line 138 "..\..\Areas\Administrator\Views\User\Create.cshtml"
                               Write(Html.CheckBoxFor(m => m.CanChangeProfilePicture, new { @class = "checkbox-inline" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("                                    ");

            
            #line 139 "..\..\Areas\Administrator\Views\User\Create.cshtml"
                               Write(Html.LabelFor(m => m.CanChangeProfilePicture, new { @class = "control-label" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n                                </div>\r\n                                <div");

WriteLiteral(" class=\"col-md-4\"");

WriteLiteral(">\r\n");

WriteLiteral("                                    ");

            
            #line 142 "..\..\Areas\Administrator\Views\User\Create.cshtml"
                               Write(Html.CheckBoxFor(m => m.CanUploadFile, new { @class = "checkbox-inline" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("                                    ");

            
            #line 143 "..\..\Areas\Administrator\Views\User\Create.cshtml"
                               Write(Html.LabelFor(m => m.CanUploadFile, new { @class = "control-label" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n                                </div>\r\n                                <div");

WriteLiteral(" class=\"col-md-4\"");

WriteLiteral(">\r\n");

WriteLiteral("                                    ");

            
            #line 146 "..\..\Areas\Administrator\Views\User\Create.cshtml"
                               Write(Html.CheckBoxFor(m => m.CanModifyFirsAndLastName, new { @class = "checkbox-inline" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("                                    ");

            
            #line 147 "..\..\Areas\Administrator\Views\User\Create.cshtml"
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

            
            #line 154 "..\..\Areas\Administrator\Views\User\Create.cshtml"
                                
            
            #line default
            #line hidden
            
            #line 154 "..\..\Areas\Administrator\Views\User\Create.cshtml"
                                 foreach (var role in (IEnumerable<SelectListItem>)ViewBag.Roles)
                                {

            
            #line default
            #line hidden
WriteLiteral("                                    ");

WriteLiteral("\r\n                                        <div");

WriteLiteral(" class=\"col-md-4\"");

WriteLiteral(">\r\n                                            <input");

WriteLiteral(" type=\"checkbox\"");

WriteAttribute("id", Tuple.Create(" id=\"", 9592), Tuple.Create("\"", 9608)
            
            #line 158 "..\..\Areas\Administrator\Views\User\Create.cshtml"
, Tuple.Create(Tuple.Create("", 9597), Tuple.Create<System.Object, System.Int32>(role.Value
            
            #line default
            #line hidden
, 9597), false)
);

WriteLiteral(" name=\"RoleIds\"");

WriteAttribute("value", Tuple.Create(" value=\"", 9624), Tuple.Create("\"", 9643)
            
            #line 158 "..\..\Areas\Administrator\Views\User\Create.cshtml"
                          , Tuple.Create(Tuple.Create("", 9632), Tuple.Create<System.Object, System.Int32>(role.Value
            
            #line default
            #line hidden
, 9632), false)
);

WriteLiteral(" class=\"checkbox-inline\"");

WriteLiteral(" />\r\n                                            <label");

WriteAttribute("for", Tuple.Create(" for=\"", 9723), Tuple.Create("\"", 9740)
            
            #line 159 "..\..\Areas\Administrator\Views\User\Create.cshtml"
, Tuple.Create(Tuple.Create("", 9729), Tuple.Create<System.Object, System.Int32>(role.Value
            
            #line default
            #line hidden
, 9729), false)
);

WriteLiteral(" class=\"control-label\"");

WriteLiteral(">");

            
            #line 159 "..\..\Areas\Administrator\Views\User\Create.cshtml"
                                                                                      Write(role.Text);

            
            #line default
            #line hidden
WriteLiteral("</label>\r\n                                        </div>\r\n                       " +
"             ");

WriteLiteral("\r\n");

            
            #line 162 "..\..\Areas\Administrator\Views\User\Create.cshtml"
                                }

            
            #line default
            #line hidden
WriteLiteral("                            </div>\r\n                        </div>\r\n             " +
"       </div>\r\n\r\n                </div>\r\n\r\n                <div");

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

            
            #line 177 "..\..\Areas\Administrator\Views\User\Create.cshtml"
        }

            
            #line default
            #line hidden
WriteLiteral("    </div>\r\n</div>\r\n");

DefineSection("Scripts", () => {

WriteLiteral(@"
    <script>
        $(""#AvatarImage"").fileinput({
            showUpload:false,
            previewFileType: ""image"",
            msgInvalidFileType: ""از فایل معتبر استفاده کنید"",
            maxFileSize: ""10240"",
            msgSizeTooLarge:""حجم فایل مورد نظر بیشتر از حجم مورد قبول است"",
            browseClass: ""btn btn-success"",
            browseLabel: ""انتخاب تصویر"",
            browseIcon: '<i class=""glyphicon glyphicon-picture""></i>',
            removeClass: ""btn btn-danger"",
            removeLabel: ""حذف"",
            removeIcon: '<i class=""glyphicon glyphicon-trash""></i>',
            allowedFileExtensions: [""jpg"", ""gif"", ""png""]
        });
    </script>
");

});

        }
    }
}
#pragma warning restore 1591
