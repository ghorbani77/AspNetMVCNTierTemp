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
    
    #line 1 "..\..\Views\Shared\_Layout.cshtml"
    using StackExchange.Profiling;
    
    #line default
    #line hidden
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/Shared/_Layout.cshtml")]
    public partial class _Views_Shared__Layout_cshtml : System.Web.Mvc.WebViewPage<dynamic>
    {
        public _Views_Shared__Layout_cshtml()
        {
        }
        public override void Execute()
        {
WriteLiteral("<!DOCTYPE html>\r\n<html");

WriteLiteral(" lang=\"fa\"");

WriteLiteral(">\r\n<head>\r\n\r\n");

WriteLiteral("    ");

            
            #line 6 "..\..\Views\Shared\_Layout.cshtml"
Write(RenderSection("meta", false));

            
            #line default
            #line hidden
WriteLiteral(@"

    <!--[if lt IE 9]>
         <script src=""https://oss.maxcdn.com/html5shiv/3.7.2/html5shiv.min.js""></script>
         <script src=""https://oss.maxcdn.com/respond/1.4.2/respond.min.js""></script>
     <![endif]-->
    <!--[if lte IE 6]>
        <script src=""/Scripts/warning.js""></script>
        <script>window.onload = function () { e(""js/ie6/"") ;}</script><![endif]-->
    <!--noscript-->
");

WriteLiteral("    ");

            
            #line 16 "..\..\Views\Shared\_Layout.cshtml"
Write(Styles.Render("~/Content/css"));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("    ");

            
            #line 17 "..\..\Views\Shared\_Layout.cshtml"
Write(Scripts.Render("~/bundles/modernizr"));

            
            #line default
            #line hidden
WriteLiteral("\r\n    <noscript>\r\n        <meta");

WriteLiteral(" http-equiv=\"refresh\"");

WriteLiteral(" content=\"0;url=/NoScript.html\"");

WriteLiteral(">\r\n    </noscript>\r\n</head>\r\n<body>\r\n    <header>\r\n        <div");

WriteLiteral(" class=\"navbar navbar-default navbar-fixed-top\"");

WriteLiteral(">\r\n            <div");

WriteLiteral(" class=\"container\"");

WriteLiteral(">\r\n                <div");

WriteLiteral(" class=\"navbar-header\"");

WriteLiteral(">\r\n                    <button");

WriteLiteral(" type=\"button\"");

WriteLiteral(" class=\"navbar-toggle\"");

WriteLiteral(" data-toggle=\"collapse\"");

WriteLiteral(" data-target=\".navbar-collapse\"");

WriteLiteral(">\r\n                        <span");

WriteLiteral(" class=\"icon-bar\"");

WriteLiteral("></span>\r\n                        <span");

WriteLiteral(" class=\"icon-bar\"");

WriteLiteral("></span>\r\n                        <span");

WriteLiteral(" class=\"icon-bar\"");

WriteLiteral("></span>\r\n                    </button>\r\n");

WriteLiteral("                    ");

            
            #line 32 "..\..\Views\Shared\_Layout.cshtml"
               Write(Html.ActionLink("MVC5", MVC.Home.ActionNames.Index, MVC.Home.Name, new { area = "" }, new { @class = "navbar-brand" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n\r\n                </div>\r\n                <div");

WriteLiteral(" class=\"navbar-collapse collapse\"");

WriteLiteral(">\r\n                    <ul");

WriteLiteral(" class=\"nav navbar-nav\"");

WriteLiteral(">\r\n                        <li>");

            
            #line 37 "..\..\Views\Shared\_Layout.cshtml"
                       Write(Html.ActionLink("خانه", MVC.Home.ActionNames.Index, MVC.Home.Name, new { area = "" }, null));

            
            #line default
            #line hidden
WriteLiteral("</li>\r\n                        <li>");

            
            #line 38 "..\..\Views\Shared\_Layout.cshtml"
                       Write(Html.ActionLink("درباره ما", MVC.Home.ActionNames.About, MVC.Home.Name, new { area = "" }, null));

            
            #line default
            #line hidden
WriteLiteral("</li>\r\n                        <li>");

            
            #line 39 "..\..\Views\Shared\_Layout.cshtml"
                       Write(Html.ActionLink("تماس با ما", MVC.Home.ActionNames.Contact, MVC.Home.Name, new { area = "" }, null));

            
            #line default
            #line hidden
WriteLiteral("</li>\r\n");

            
            #line 40 "..\..\Views\Shared\_Layout.cshtml"
                        
            
            #line default
            #line hidden
            
            #line 40 "..\..\Views\Shared\_Layout.cshtml"
                           Html.RenderPartial(MVC.Shared.Views.ViewNames._LoginPartial); 
            
            #line default
            #line hidden
WriteLiteral("\r\n                    </ul>\r\n                </div>\r\n            </div>\r\n        " +
"</div>\r\n    </header>\r\n\r\n    <div");

WriteLiteral(" class=\"container\"");

WriteLiteral(" style=\"margin-top: 100px;\"");

WriteLiteral(">\r\n");

WriteLiteral("        ");

            
            #line 48 "..\..\Views\Shared\_Layout.cshtml"
   Write(RenderBody());

            
            #line default
            #line hidden
WriteLiteral("\r\n    </div>\r\n");

WriteLiteral("    ");

            
            #line 50 "..\..\Views\Shared\_Layout.cshtml"
Write(Scripts.Render("~/bundles/jquery"));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("    ");

            
            #line 51 "..\..\Views\Shared\_Layout.cshtml"
Write(Scripts.Render("~/bundles/bootstrap"));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("    ");

            
            #line 52 "..\..\Views\Shared\_Layout.cshtml"
Write(RenderSection("scripts", required: false));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

            
            #line 53 "..\..\Views\Shared\_Layout.cshtml"
    
            
            #line default
            #line hidden
            
            #line 53 "..\..\Views\Shared\_Layout.cshtml"
      Html.RenderPartial(MVC.Shared.Views.ViewNames._Toastr);
            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("    ");

            
            #line 54 "..\..\Views\Shared\_Layout.cshtml"
Write(MiniProfiler.RenderIncludes());

            
            #line default
            #line hidden
WriteLiteral("\r\n</body>\r\n</html>\r\n");

        }
    }
}
#pragma warning restore 1591
