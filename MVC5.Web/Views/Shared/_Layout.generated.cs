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
Write(RenderSection("meta",false));

            
            #line default
            #line hidden
WriteLiteral(@"

    <!--[if lt IE 9]>
        <script src=""https://cdnjs.cloudflare.com/ajax/libs/html5shiv/3.7.2/html5shiv.js""></script>
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
WriteLiteral("\r\n\r\n    <noscript>\r\n        <meta");

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

            
            #line 33 "..\..\Views\Shared\_Layout.cshtml"
               Write(Html.ActionLink("MVC5", "Index", "Home", new { area = "" }, new { @class = "navbar-brand" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n\r\n                </div>\r\n                <div");

WriteLiteral(" class=\"navbar-collapse collapse\"");

WriteLiteral(">\r\n                    <ul");

WriteLiteral(" class=\"nav navbar-nav\"");

WriteLiteral(">\r\n                        <li>");

            
            #line 38 "..\..\Views\Shared\_Layout.cshtml"
                       Write(Html.ActionLink("خانه", "Index", "Home", new { area = "" }, null));

            
            #line default
            #line hidden
WriteLiteral("</li>\r\n                        <li>");

            
            #line 39 "..\..\Views\Shared\_Layout.cshtml"
                       Write(Html.ActionLink("درباره ما", "About", "Home", new { area = "" }, null));

            
            #line default
            #line hidden
WriteLiteral("</li>\r\n                        <li>");

            
            #line 40 "..\..\Views\Shared\_Layout.cshtml"
                       Write(Html.ActionLink("تماس با ما", "Contact", "Home", new { area = "" }, null));

            
            #line default
            #line hidden
WriteLiteral("</li>\r\n\r\n\r\n");

            
            #line 43 "..\..\Views\Shared\_Layout.cshtml"
                        
            
            #line default
            #line hidden
            
            #line 43 "..\..\Views\Shared\_Layout.cshtml"
                         if (Request.IsAuthenticated && User.IsInRole("Admin"))
                        {

            
            #line default
            #line hidden
WriteLiteral("                            <li>");

            
            #line 45 "..\..\Views\Shared\_Layout.cshtml"
                           Write(Html.ActionLink("RolesAdmin", "Index", "RolesAdmin"));

            
            #line default
            #line hidden
WriteLiteral("</li>\r\n");

WriteLiteral("                            <li>");

            
            #line 46 "..\..\Views\Shared\_Layout.cshtml"
                           Write(Html.ActionLink("UsersAdmin", "Index", "UsersAdmin"));

            
            #line default
            #line hidden
WriteLiteral("</li>\r\n");

            
            #line 47 "..\..\Views\Shared\_Layout.cshtml"
                        }

            
            #line default
            #line hidden
WriteLiteral("\r\n                    </ul>\r\n                </div>\r\n            </div>\r\n        " +
"</div>\r\n    </header>\r\n\r\n    <div");

WriteLiteral(" class=\"container\"");

WriteLiteral(">\r\n        <hr />\r\n");

WriteLiteral("        ");

            
            #line 57 "..\..\Views\Shared\_Layout.cshtml"
   Write(RenderBody());

            
            #line default
            #line hidden
WriteLiteral("\r\n    </div>\r\n\r\n    <footer>\r\n\r\n    </footer>\r\n\r\n");

WriteLiteral("    ");

            
            #line 64 "..\..\Views\Shared\_Layout.cshtml"
Write(Scripts.Render("~/bundles/jquery"));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("    ");

            
            #line 65 "..\..\Views\Shared\_Layout.cshtml"
Write(Scripts.Render("~/bundles/bootstrap"));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("    ");

            
            #line 66 "..\..\Views\Shared\_Layout.cshtml"
Write(RenderSection("scripts", required: false));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("    ");

            
            #line 67 "..\..\Views\Shared\_Layout.cshtml"
Write(MiniProfiler.RenderIncludes());

            
            #line default
            #line hidden
WriteLiteral("\r\n</body>\r\n</html>\r\n");

        }
    }
}
#pragma warning restore 1591
