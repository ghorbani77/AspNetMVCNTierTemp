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
    
    #line 1 "..\..\Views\Account\Register.cshtml"
    using CaptchaMvc.HtmlHelpers;
    
    #line default
    #line hidden
    using MVC5.ViewModel;
    
    #line 2 "..\..\Views\Account\Register.cshtml"
    using MVC5.ViewModel.Account;
    
    #line default
    #line hidden
    using MVC5.Web;
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/Account/Register.cshtml")]
    public partial class _Views_Account_Register_cshtml : System.Web.Mvc.WebViewPage<RegisterViewModel>
    {
        public _Views_Account_Register_cshtml()
        {
        }
        public override void Execute()
        {
            
            #line 4 "..\..\Views\Account\Register.cshtml"
  
    

            
            #line default
            #line hidden
WriteLiteral("\r\n<div");

WriteLiteral(" class=\"row\"");

WriteLiteral(">\r\n\r\n");

            
            #line 9 "..\..\Views\Account\Register.cshtml"
    
            
            #line default
            #line hidden
            
            #line 9 "..\..\Views\Account\Register.cshtml"
     using (Html.BeginForm(MVC.Account.ActionNames.Register, MVC.Account.Name, FormMethod.Post, new { area = "", @class = "form-horizontal", role = "form" }))
    {
        
            
            #line default
            #line hidden
            
            #line 11 "..\..\Views\Account\Register.cshtml"
   Write(Html.AntiForgeryToken());

            
            #line default
            #line hidden
            
            #line 11 "..\..\Views\Account\Register.cshtml"
                                

            
            #line default
            #line hidden
WriteLiteral("        <div");

WriteLiteral(" class=\"col-md-10 col-md-offset-1\"");

WriteLiteral(">\r\n            <div");

WriteLiteral(" class=\"panel panel-default\"");

WriteLiteral(">\r\n                <div");

WriteLiteral(" class=\"panel-heading\"");

WriteLiteral(">\r\n                    <strong>ساخت حساب کاربری جدید</strong>\r\n                </" +
"div>\r\n                <div");

WriteLiteral(" class=\"panel-body\"");

WriteLiteral(">\r\n                    <div");

WriteLiteral(" class=\"form-group\"");

WriteLiteral(">\r\n");

WriteLiteral("                        ");

            
            #line 19 "..\..\Views\Account\Register.cshtml"
                   Write(Html.LabelFor(m => m.Email, new { @class = "col-md-2 control-label" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n                        <div");

WriteLiteral(" class=\"col-md-10\"");

WriteLiteral(">\r\n");

WriteLiteral("                            ");

            
            #line 21 "..\..\Views\Account\Register.cshtml"
                       Write(Html.TextBoxFor(m => m.Email, new { @class = "form-control" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("                            ");

            
            #line 22 "..\..\Views\Account\Register.cshtml"
                       Write(Html.ValidationMessageFor(m => m.Email, "", new { @class = "text-danger" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n                        </div>\r\n                    </div>\r\n                   " +
" <div");

WriteLiteral(" class=\"form-group\"");

WriteLiteral(">\r\n");

WriteLiteral("                        ");

            
            #line 26 "..\..\Views\Account\Register.cshtml"
                   Write(Html.LabelFor(m => m.Password, new { @class = "col-md-2 control-label" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n                        <div");

WriteLiteral(" class=\"col-md-10\"");

WriteLiteral(">\r\n");

WriteLiteral("                            ");

            
            #line 28 "..\..\Views\Account\Register.cshtml"
                       Write(Html.PasswordFor(m => m.Password, new { @class = "form-control" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("                            ");

            
            #line 29 "..\..\Views\Account\Register.cshtml"
                       Write(Html.ValidationMessageFor(m => m.Password, "", new { @class = "text-danger" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n                        </div>\r\n                    </div>\r\n                   " +
" <div");

WriteLiteral(" class=\"form-group\"");

WriteLiteral(">\r\n");

WriteLiteral("                        ");

            
            #line 33 "..\..\Views\Account\Register.cshtml"
                   Write(Html.LabelFor(m => m.ConfirmPassword, new { @class = "col-md-2 control-label" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n                        <div");

WriteLiteral(" class=\"col-md-10\"");

WriteLiteral(">\r\n");

WriteLiteral("                            ");

            
            #line 35 "..\..\Views\Account\Register.cshtml"
                       Write(Html.PasswordFor(m => m.ConfirmPassword, new { @class = "form-control" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("                            ");

            
            #line 36 "..\..\Views\Account\Register.cshtml"
                       Write(Html.ValidationMessageFor(m => m.ConfirmPassword, "", new { @class = "text-danger" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n                        </div>\r\n                    </div>\r\n                   " +
" <div");

WriteLiteral(" class=\"form-group\"");

WriteLiteral(">\r\n");

WriteLiteral("                        ");

            
            #line 40 "..\..\Views\Account\Register.cshtml"
                   Write(Html.LabelFor(m => m.UserName, new { @class = "col-md-2 control-label" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n                        <div");

WriteLiteral(" class=\"col-md-10\"");

WriteLiteral(">\r\n");

WriteLiteral("                            ");

            
            #line 42 "..\..\Views\Account\Register.cshtml"
                       Write(Html.TextBoxFor(m => m.UserName, new { @class = "form-control" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("                            ");

            
            #line 43 "..\..\Views\Account\Register.cshtml"
                       Write(Html.ValidationMessageFor(m => m.UserName, "", new { @class = "text-danger" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n                        </div>\r\n                    </div>\r\n                   " +
" <div");

WriteLiteral(" class=\"form-group\"");

WriteLiteral(">\r\n");

WriteLiteral("                        ");

            
            #line 47 "..\..\Views\Account\Register.cshtml"
                   Write(Html.MathCaptcha(MVC.Shared.Views._CaptchaPartial));

            
            #line default
            #line hidden
WriteLiteral("\r\n\r\n                    </div>\r\n                </div>\r\n                <div");

WriteLiteral(" class=\"panel-footer\"");

WriteLiteral(">\r\n                    <div");

WriteLiteral(" class=\"row\"");

WriteLiteral(">\r\n                        <div");

WriteLiteral(" class=\"col-md-12\"");

WriteLiteral(">\r\n                            <input");

WriteLiteral(" type=\"submit\"");

WriteLiteral(" class=\"btn btn-success btn-block\"");

WriteLiteral(" value=\"تأیید اطلاعات برای تکمیل عضویت\"");

WriteLiteral(" />\r\n                        </div>\r\n                    </div>\r\n                " +
"</div>\r\n            </div>\r\n\r\n        </div>\r\n");

            
            #line 61 "..\..\Views\Account\Register.cshtml"
    }

            
            #line default
            #line hidden
WriteLiteral("\r\n</div>\r\n");

DefineSection("Scripts", () => {

WriteLiteral("\r\n");

WriteLiteral("    ");

            
            #line 65 "..\..\Views\Account\Register.cshtml"
Write(Scripts.Render("~/bundles/bootstrap"));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("    ");

            
            #line 66 "..\..\Views\Account\Register.cshtml"
Write(Scripts.Render("~/bundles/jqueryval"));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

});

        }
    }
}
#pragma warning restore 1591
