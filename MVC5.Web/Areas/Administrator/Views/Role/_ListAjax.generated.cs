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

namespace MVC5.Web.Areas.Administrator.Views.Role
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
    
    #line 2 "..\..\Areas\Administrator\Views\Role\_ListAjax.cshtml"
    using MVC5.ViewModel.AdminArea.Role;
    
    #line default
    #line hidden
    using MVC5.Web;
    
    #line 3 "..\..\Areas\Administrator\Views\Role\_ListAjax.cshtml"
    using PagedList;
    
    #line default
    #line hidden
    
    #line 4 "..\..\Areas\Administrator\Views\Role\_ListAjax.cshtml"
    using PagedList.Mvc;
    
    #line default
    #line hidden
    using StackExchange.Profiling;
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/Areas/Administrator/Views/Role/_ListAjax.cshtml")]
    public partial class _ListAjax : System.Web.Mvc.WebViewPage<IEnumerable<RoleViewModel>>
    {
        public _ListAjax()
        {
        }
        public override void Execute()
        {
WriteLiteral("\r\n");

WriteLiteral("\r\n\r\n<div");

WriteLiteral(" class=\"panel-heading\"");

WriteLiteral("><strong>لیست گروه های کاربری</strong></div>\r\n<div");

WriteLiteral(" class=\"panel-body min-height-340\"");

WriteLiteral(">\r\n    <div");

WriteLiteral(" class=\"row\"");

WriteLiteral(">\r\n        <div");

WriteLiteral(" class=\"col-md-12\"");

WriteLiteral(">\r\n            <div");

WriteLiteral(" class=\"table-responsive\"");

WriteLiteral(">\r\n                <table");

WriteLiteral(" class=\"table table-striped table-bordered\"");

WriteLiteral(">\r\n                    <thead>\r\n                        <tr>\r\n                   " +
"         <th");

WriteLiteral(" class=\"text-center\"");

WriteLiteral(">نام سیستمی</th>\r\n                            <th>توضیحات</th>\r\n                 " +
"           <th");

WriteLiteral(" class=\"text-center\"");

WriteLiteral(">فعال /غیر فعال</th>\r\n                            <th");

WriteLiteral(" class=\"text-center\"");

WriteLiteral(">گروه کاربری سیستمی</th>\r\n                            <th");

WriteLiteral(" class=\"text-center\"");

WriteLiteral(">گروه کاربری پیشفرض برای عضویت</th>\r\n                        </tr>\r\n                    <" +
"/thead>\r\n                    <tbody>\r\n");

            
            #line 25 "..\..\Areas\Administrator\Views\Role\_ListAjax.cshtml"
                        
            
            #line default
            #line hidden
            
            #line 25 "..\..\Areas\Administrator\Views\Role\_ListAjax.cshtml"
                         foreach (var role in Model)
                        {

            
            #line default
            #line hidden
WriteLiteral("                            <tr>\r\n                                <td");

WriteLiteral(" class=\"text-center\"");

WriteLiteral(">\r\n                                    <strong");

WriteLiteral(" class=\"text-info\"");

WriteLiteral(">\r\n");

WriteLiteral("                                        ");

            
            #line 30 "..\..\Areas\Administrator\Views\Role\_ListAjax.cshtml"
                                   Write(Html.ActionLink(role.Name, MVC.Administrator.Role.ActionNames.Edit, MVC.Administrator.Role.Name,
                                        new { id = role.Id, area = MVC.Administrator.Name }, null));

            
            #line default
            #line hidden
WriteLiteral("\r\n                                      \r\n                                    </s" +
"trong>\r\n                                </td>\r\n\r\n                               " +
" <td>");

            
            #line 36 "..\..\Areas\Administrator\Views\Role\_ListAjax.cshtml"
                               Write(role.Description);

            
            #line default
            #line hidden
WriteLiteral("</td>\r\n                                <td");

WriteLiteral(" class=\"text-center\"");

WriteLiteral(">\r\n");

            
            #line 38 "..\..\Areas\Administrator\Views\Role\_ListAjax.cshtml"
                                    
            
            #line default
            #line hidden
            
            #line 38 "..\..\Areas\Administrator\Views\Role\_ListAjax.cshtml"
                                     if (role.IsActive)
                                    {

            
            #line default
            #line hidden
WriteLiteral("                                        ");

WriteLiteral("\r\n                                            <i");

WriteLiteral(" class=\"fa fa-check text-success\"");

WriteLiteral("></i>\r\n                                        ");

WriteLiteral("\r\n");

            
            #line 43 "..\..\Areas\Administrator\Views\Role\_ListAjax.cshtml"
                                    }
                                    else
                                    {

            
            #line default
            #line hidden
WriteLiteral("                                        ");

WriteLiteral("\r\n                                            <i");

WriteLiteral(" class=\"fa fa-minus text-info\"");

WriteLiteral("></i>\r\n                                        ");

WriteLiteral("\r\n");

            
            #line 49 "..\..\Areas\Administrator\Views\Role\_ListAjax.cshtml"
                                    }

            
            #line default
            #line hidden
WriteLiteral("                                </td>\r\n                                <td");

WriteLiteral(" class=\"text-center\"");

WriteLiteral(">\r\n");

            
            #line 52 "..\..\Areas\Administrator\Views\Role\_ListAjax.cshtml"
                                    
            
            #line default
            #line hidden
            
            #line 52 "..\..\Areas\Administrator\Views\Role\_ListAjax.cshtml"
                                     if (role.IsSystemRole)
                                    {

            
            #line default
            #line hidden
WriteLiteral("                                        ");

WriteLiteral("\r\n                                            <i");

WriteLiteral(" class=\"fa fa-check text-success\"");

WriteLiteral("></i>\r\n                                        ");

WriteLiteral("\r\n");

            
            #line 57 "..\..\Areas\Administrator\Views\Role\_ListAjax.cshtml"
                                    }
                                    else
                                    {

            
            #line default
            #line hidden
WriteLiteral("                                        ");

WriteLiteral("\r\n                                            <i");

WriteLiteral(" class=\"fa fa-minus text-info\"");

WriteLiteral("></i>\r\n                                        ");

WriteLiteral("\r\n");

            
            #line 63 "..\..\Areas\Administrator\Views\Role\_ListAjax.cshtml"
                                    }

            
            #line default
            #line hidden
WriteLiteral("                                </td>\r\n                                <td");

WriteLiteral(" class=\"text-center\"");

WriteLiteral(">\r\n");

            
            #line 66 "..\..\Areas\Administrator\Views\Role\_ListAjax.cshtml"
                                    
            
            #line default
            #line hidden
            
            #line 66 "..\..\Areas\Administrator\Views\Role\_ListAjax.cshtml"
                                     if (role.IsDefaultForRegister)
                                    {

            
            #line default
            #line hidden
WriteLiteral("                                        ");

WriteLiteral("\r\n                                            <i");

WriteLiteral(" class=\"fa fa-check text-success\"");

WriteLiteral("></i>\r\n                                        ");

WriteLiteral("\r\n");

            
            #line 71 "..\..\Areas\Administrator\Views\Role\_ListAjax.cshtml"
                                    }
                                    else
                                    {

            
            #line default
            #line hidden
WriteLiteral("                                        ");

WriteLiteral("\r\n                                            <i");

WriteLiteral(" class=\"fa fa-minus text-info\"");

WriteLiteral("></i>\r\n                                        ");

WriteLiteral("\r\n");

            
            #line 77 "..\..\Areas\Administrator\Views\Role\_ListAjax.cshtml"
                                    }

            
            #line default
            #line hidden
WriteLiteral("                                </td>\r\n                                <td");

WriteLiteral(" class=\"text-left\"");

WriteLiteral(">\r\n\r\n");

WriteLiteral("                                    ");

            
            #line 81 "..\..\Areas\Administrator\Views\Role\_ListAjax.cshtml"
                               Write(Html.ActionLink("ویرایش", MVC.Administrator.Role.ActionNames.Edit, MVC.Administrator.Role.Name, new { id = role.Id, area = MVC.Administrator.Name }, new { @class = "btn btn-sm btn-primary" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n                                </td>\r\n                            </tr>\r\n");

            
            #line 84 "..\..\Areas\Administrator\Views\Role\_ListAjax.cshtml"
                        }

            
            #line default
            #line hidden
WriteLiteral("                    </tbody>\r\n\r\n                </table>\r\n            </div>\r\n   " +
"     </div>\r\n    </div>\r\n</div>\r\n\r\n<div");

WriteLiteral(" class=\"panel-footer\"");

WriteLiteral(">\r\n");

WriteLiteral("    ");

            
            #line 94 "..\..\Areas\Administrator\Views\Role\_ListAjax.cshtml"
Write(Html.PagedListPager(new StaticPagedList<RoleViewModel>(Model, ViewBag.PageNumber, 5, ViewBag.TotalRoles), pageNumber => Url.Action(MVC.Administrator.Role.ActionNames.ListAjax, MVC.Administrator.Role.Name, new
                {
                    term = ViewBag.Term,
                    page = pageNumber
                }), PagedListRenderOptions.EnableUnobtrusiveAjaxReplacing(PagedListRenderOptions.ClassicPlusFirstAndLast, new AjaxOptions { AllowCache = false, HttpMethod = "GET", InsertionMode = InsertionMode.Replace, UpdateTargetId = "roleList" })));

            
            #line default
            #line hidden
WriteLiteral("\r\n\r\n</div>\r\n<script>\r\n    Public.Routin();\r\n</script>");

        }
    }
}
#pragma warning restore 1591
