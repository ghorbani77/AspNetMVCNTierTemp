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
    [System.Web.WebPages.PageVirtualPathAttribute("~/Areas/Administrator/Views/Setting/UserSetting.cshtml")]
    public partial class _Areas_Administrator_Views_Setting_UserSetting_cshtml : System.Web.Mvc.WebViewPage<MVC5.ViewModel.AdminArea.Setting.UserSettingsViewModel>
    {
        public _Areas_Administrator_Views_Setting_UserSetting_cshtml()
        {
        }
        public override void Execute()
        {
            
            #line 2 "..\..\Areas\Administrator\Views\Setting\UserSetting.cshtml"
  
    ViewBag.Title = "تنضیمات کاربران";

            
            #line default
            #line hidden
WriteLiteral("\r\n\r\n");

            
            #line 6 "..\..\Areas\Administrator\Views\Setting\UserSetting.cshtml"
 using (Html.BeginForm())
{
  
    
            
            #line default
            #line hidden
            
            #line 9 "..\..\Areas\Administrator\Views\Setting\UserSetting.cshtml"
Write(Html.AntiForgeryToken());

            
            #line default
            #line hidden
            
            #line 9 "..\..\Areas\Administrator\Views\Setting\UserSetting.cshtml"
                            


            
            #line default
            #line hidden
WriteLiteral("    <div");

WriteLiteral(" class=\"container\"");

WriteLiteral(">\r\n        <div");

WriteLiteral(" class=\"row\"");

WriteLiteral(">\r\n            <div");

WriteLiteral(" class=\"col-md-12\"");

WriteLiteral(">\r\n                <div >\r\n                    <ul");

WriteLiteral(" class=\"nav nav-tabs\"");

WriteLiteral(">\r\n                        <li");

WriteLiteral(" class=\"active\"");

WriteLiteral(">\r\n                            <a");

WriteLiteral(" href=\"#panel-userSetting\"");

WriteLiteral(" data-toggle=\"tab\"");

WriteLiteral(">تنظیمات کاربران</a>\r\n                        </li>\r\n                        <li>" +
"\r\n                            <a");

WriteLiteral(" href=\"#panel-externalAuthSetting\"");

WriteLiteral(" data-toggle=\"tab\"");

WriteLiteral(">تنظیمات احراز هویت</a>\r\n                        </li>\r\n                    </ul>" +
"\r\n                    <div");

WriteLiteral(" class=\"tab-content\"");

WriteLiteral(">\r\n                        <div");

WriteLiteral(" class=\"tab-pane active\"");

WriteLiteral(" id=\"panel-userSetting\"");

WriteLiteral(">\r\n");

            
            #line 25 "..\..\Areas\Administrator\Views\Setting\UserSetting.cshtml"
                           
            
            #line default
            #line hidden
            
            #line 25 "..\..\Areas\Administrator\Views\Setting\UserSetting.cshtml"
                             Html.RenderPartial(MVC.Administrator.Setting.Views._UserSetting);
            
            #line default
            #line hidden
WriteLiteral("\r\n                        </div>\r\n                        <div");

WriteLiteral(" class=\"tab-pane\"");

WriteLiteral(" id=\"panel-externalAuthSetting\"");

WriteLiteral(">\r\n");

            
            #line 28 "..\..\Areas\Administrator\Views\Setting\UserSetting.cshtml"
                            
            
            #line default
            #line hidden
            
            #line 28 "..\..\Areas\Administrator\Views\Setting\UserSetting.cshtml"
                              Html.RenderPartial(MVC.Administrator.Setting.Views._ExternalAuthSetting);
            
            #line default
            #line hidden
WriteLiteral("\r\n                        </div>\r\n                    </div>\r\n                </d" +
"iv>\r\n            </div>\r\n        </div>\r\n    </div>\r\n");

            
            #line 35 "..\..\Areas\Administrator\Views\Setting\UserSetting.cshtml"
    
}

            
            #line default
            #line hidden
        }
    }
}
#pragma warning restore 1591
