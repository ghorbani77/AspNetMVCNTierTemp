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
    using MVC5.ViewModel;
    using MVC5.Web;
    using MvcSiteMapProvider.Web.Html;
    using MvcSiteMapProvider.Web.Html.Models;
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/Manage/VerifyPhoneNumber.cshtml")]
    public partial class _Views_Manage_VerifyPhoneNumber_cshtml : System.Web.Mvc.WebViewPage<MVC5.ViewModel.Account.VerifyPhoneNumberViewModel>
    {
        public _Views_Manage_VerifyPhoneNumber_cshtml()
        {
        }
        public override void Execute()
        {
            
            #line 2 "..\..\Views\Manage\VerifyPhoneNumber.cshtml"
  
    ViewBag.Title = "Verify Phone Number";

            
            #line default
            #line hidden
WriteLiteral("\r\n\r\n<h2>");

            
            #line 6 "..\..\Views\Manage\VerifyPhoneNumber.cshtml"
Write(ViewBag.Title);

            
            #line default
            #line hidden
WriteLiteral(".</h2>\r\n\r\n");

            
            #line 8 "..\..\Views\Manage\VerifyPhoneNumber.cshtml"
 using (Html.BeginForm("VerifyPhoneNumber", "Manage", FormMethod.Post, new { @class = "form-horizontal", role = "form" }))
{
    
            
            #line default
            #line hidden
            
            #line 10 "..\..\Views\Manage\VerifyPhoneNumber.cshtml"
Write(Html.AntiForgeryToken());

            
            #line default
            #line hidden
            
            #line 10 "..\..\Views\Manage\VerifyPhoneNumber.cshtml"
                            
    
            
            #line default
            #line hidden
            
            #line 11 "..\..\Views\Manage\VerifyPhoneNumber.cshtml"
Write(Html.Hidden("phoneNumber", @Model.PhoneNumber));

            
            #line default
            #line hidden
            
            #line 11 "..\..\Views\Manage\VerifyPhoneNumber.cshtml"
                                                   

            
            #line default
            #line hidden
WriteLiteral("    <h4>Add a phone number.</h4>\r\n");

WriteLiteral("    <h5>");

            
            #line 13 "..\..\Views\Manage\VerifyPhoneNumber.cshtml"
   Write(ViewBag.Status);

            
            #line default
            #line hidden
WriteLiteral("</h5>\r\n");

WriteLiteral("    <hr />\r\n");

            
            #line 15 "..\..\Views\Manage\VerifyPhoneNumber.cshtml"
    
            
            #line default
            #line hidden
            
            #line 15 "..\..\Views\Manage\VerifyPhoneNumber.cshtml"
Write(Html.ValidationSummary("", new { @class = "text-danger" }));

            
            #line default
            #line hidden
            
            #line 15 "..\..\Views\Manage\VerifyPhoneNumber.cshtml"
                                                               

            
            #line default
            #line hidden
WriteLiteral("    <div");

WriteLiteral(" class=\"form-group\"");

WriteLiteral(">\r\n");

WriteLiteral("        ");

            
            #line 17 "..\..\Views\Manage\VerifyPhoneNumber.cshtml"
   Write(Html.LabelFor(m => m.Code, new { @class = "col-md-2 control-label" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n        <div");

WriteLiteral(" class=\"col-md-10\"");

WriteLiteral(">\r\n");

WriteLiteral("            ");

            
            #line 19 "..\..\Views\Manage\VerifyPhoneNumber.cshtml"
       Write(Html.TextBoxFor(m => m.Code, new { @class = "form-control" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n        </div>\r\n    </div>\r\n");

WriteLiteral("    <div");

WriteLiteral(" class=\"form-group\"");

WriteLiteral(">\r\n        <div");

WriteLiteral(" class=\"col-md-offset-2 col-md-10\"");

WriteLiteral(">\r\n            <input");

WriteLiteral(" type=\"submit\"");

WriteLiteral(" class=\"btn btn-default\"");

WriteLiteral(" value=\"Submit\"");

WriteLiteral(" />\r\n        </div>\r\n    </div>\r\n");

            
            #line 27 "..\..\Views\Manage\VerifyPhoneNumber.cshtml"
}

            
            #line default
            #line hidden
WriteLiteral("\r\n");

DefineSection("Scripts", () => {

WriteLiteral("\r\n");

WriteLiteral("    ");

            
            #line 30 "..\..\Views\Manage\VerifyPhoneNumber.cshtml"
Write(Scripts.Render("~/bundles/jqueryval"));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

});

        }
    }
}
#pragma warning restore 1591
