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
    using System.Web.Mvc.Html;
#line 2 "..\..\Views\Manage\ManageLogins.cshtml"
#line default
    #line hidden

    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/Manage/ManageLogins.cshtml")]
    public partial class _Views_Manage_ManageLogins_cshtml : System.Web.Mvc.WebViewPage<MVC5.ViewModel.Account.ManageLoginsViewModel>
    {
        public _Views_Manage_ManageLogins_cshtml()
        {
        }
        public override void Execute()
        {
            
            #line 3 "..\..\Views\Manage\ManageLogins.cshtml"
  
    ViewBag.Title = "Manage your external logins";

            
            #line default
            #line hidden
WriteLiteral("\r\n\r\n<h2>");

            
            #line 7 "..\..\Views\Manage\ManageLogins.cshtml"
Write(ViewBag.Title);

            
            #line default
            #line hidden
WriteLiteral(".</h2>\r\n\r\n<p");

WriteLiteral(" class=\"text-success\"");

WriteLiteral(">");

            
            #line 9 "..\..\Views\Manage\ManageLogins.cshtml"
                   Write(ViewBag.StatusMessage);

            
            #line default
            #line hidden
WriteLiteral("</p>\r\n");

            
            #line 10 "..\..\Views\Manage\ManageLogins.cshtml"
 if (Model.CurrentLogins.Count > 0)
{

            
            #line default
            #line hidden
WriteLiteral("    <h4>Registered Logins</h4>\r\n");

WriteLiteral("    <table");

WriteLiteral(" class=\"table table-striped table-hover table-bordered table-condensed\"");

WriteLiteral(">\r\n        <tbody>\r\n");

            
            #line 15 "..\..\Views\Manage\ManageLogins.cshtml"
            
            
            #line default
            #line hidden
            
            #line 15 "..\..\Views\Manage\ManageLogins.cshtml"
             foreach (var account in Model.CurrentLogins)
            {

            
            #line default
            #line hidden
WriteLiteral("                <tr>\r\n                    <td>");

            
            #line 18 "..\..\Views\Manage\ManageLogins.cshtml"
                   Write(account.LoginProvider);

            
            #line default
            #line hidden
WriteLiteral("</td>\r\n                    <td>\r\n");

            
            #line 20 "..\..\Views\Manage\ManageLogins.cshtml"
                        
            
            #line default
            #line hidden
            
            #line 20 "..\..\Views\Manage\ManageLogins.cshtml"
                         if (ViewBag.ShowRemoveButton)
                        {
                            using (Html.BeginForm("RemoveLogin", "Manage"))
                            {
                                
            
            #line default
            #line hidden
            
            #line 24 "..\..\Views\Manage\ManageLogins.cshtml"
                           Write(Html.AntiForgeryToken());

            
            #line default
            #line hidden
            
            #line 24 "..\..\Views\Manage\ManageLogins.cshtml"
                                                        

            
            #line default
            #line hidden
WriteLiteral("                                <div>\r\n");

WriteLiteral("                                    ");

            
            #line 26 "..\..\Views\Manage\ManageLogins.cshtml"
                               Write(Html.Hidden("loginProvider", account.LoginProvider));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("                                    ");

            
            #line 27 "..\..\Views\Manage\ManageLogins.cshtml"
                               Write(Html.Hidden("providerKey", account.ProviderKey));

            
            #line default
            #line hidden
WriteLiteral("\r\n                                    <input");

WriteLiteral(" type=\"submit\"");

WriteLiteral(" class=\"btn btn-default\"");

WriteLiteral(" value=\"Remove\"");

WriteAttribute("title", Tuple.Create(" title=\"", 1133), Tuple.Create("\"", 1199)
, Tuple.Create(Tuple.Create("", 1141), Tuple.Create("Remove", 1141), true)
, Tuple.Create(Tuple.Create(" ", 1147), Tuple.Create("this", 1148), true)
            
            #line 28 "..\..\Views\Manage\ManageLogins.cshtml"
                                  , Tuple.Create(Tuple.Create(" ", 1152), Tuple.Create<System.Object, System.Int32>(account.LoginProvider
            
            #line default
            #line hidden
, 1153), false)
, Tuple.Create(Tuple.Create(" ", 1175), Tuple.Create("login", 1176), true)
, Tuple.Create(Tuple.Create(" ", 1181), Tuple.Create("from", 1182), true)
, Tuple.Create(Tuple.Create(" ", 1186), Tuple.Create("your", 1187), true)
, Tuple.Create(Tuple.Create(" ", 1191), Tuple.Create("account", 1192), true)
);

WriteLiteral(" />\r\n                                </div>\r\n");

            
            #line 30 "..\..\Views\Manage\ManageLogins.cshtml"
                            }
                        }
                        else
                        {

            
            #line default
            #line hidden
WriteLiteral("                            ");

WriteLiteral(" &nbsp;\r\n");

            
            #line 35 "..\..\Views\Manage\ManageLogins.cshtml"
                        }

            
            #line default
            #line hidden
WriteLiteral("                    </td>\r\n                </tr>\r\n");

            
            #line 38 "..\..\Views\Manage\ManageLogins.cshtml"
            }

            
            #line default
            #line hidden
WriteLiteral("        </tbody>\r\n    </table>\r\n");

            
            #line 41 "..\..\Views\Manage\ManageLogins.cshtml"
}

            
            #line default
            #line hidden
            
            #line 42 "..\..\Views\Manage\ManageLogins.cshtml"
 if (Model.OtherLogins.Count > 0)
{

            
            #line default
            #line hidden
WriteLiteral("    <h4>Add another service to log in.</h4>\r\n");

WriteLiteral("    <hr />\r\n");

            
            #line 46 "..\..\Views\Manage\ManageLogins.cshtml"
    using (Html.BeginForm("LinkLogin", "Manage"))
    {
        
            
            #line default
            #line hidden
            
            #line 48 "..\..\Views\Manage\ManageLogins.cshtml"
   Write(Html.AntiForgeryToken());

            
            #line default
            #line hidden
            
            #line 48 "..\..\Views\Manage\ManageLogins.cshtml"
                                

            
            #line default
            #line hidden
WriteLiteral("        <div");

WriteLiteral(" id=\"socialLoginList\"");

WriteLiteral(">\r\n        <p>\r\n");

            
            #line 51 "..\..\Views\Manage\ManageLogins.cshtml"
            
            
            #line default
            #line hidden
            
            #line 51 "..\..\Views\Manage\ManageLogins.cshtml"
             foreach (var p in Model.OtherLogins)
            {

            
            #line default
            #line hidden
WriteLiteral("                <button");

WriteLiteral(" type=\"submit\"");

WriteLiteral(" class=\"btn btn-default\"");

WriteAttribute("id", Tuple.Create(" id=\"", 1889), Tuple.Create("\"", 1915)
            
            #line 53 "..\..\Views\Manage\ManageLogins.cshtml"
, Tuple.Create(Tuple.Create("", 1894), Tuple.Create<System.Object, System.Int32>(p.AuthenticationType
            
            #line default
            #line hidden
, 1894), false)
);

WriteLiteral(" name=\"provider\"");

WriteAttribute("value", Tuple.Create(" value=\"", 1932), Tuple.Create("\"", 1961)
            
            #line 53 "..\..\Views\Manage\ManageLogins.cshtml"
                                , Tuple.Create(Tuple.Create("", 1940), Tuple.Create<System.Object, System.Int32>(p.AuthenticationType
            
            #line default
            #line hidden
, 1940), false)
);

WriteAttribute("title", Tuple.Create(" title=\"", 1962), Tuple.Create("\"", 2006)
, Tuple.Create(Tuple.Create("", 1970), Tuple.Create("Log", 1970), true)
, Tuple.Create(Tuple.Create(" ", 1973), Tuple.Create("in", 1974), true)
, Tuple.Create(Tuple.Create(" ", 1976), Tuple.Create("using", 1977), true)
, Tuple.Create(Tuple.Create(" ", 1982), Tuple.Create("your", 1983), true)
            
            #line 53 "..\..\Views\Manage\ManageLogins.cshtml"
                                                                               , Tuple.Create(Tuple.Create(" ", 1987), Tuple.Create<System.Object, System.Int32>(p.Caption
            
            #line default
            #line hidden
, 1988), false)
, Tuple.Create(Tuple.Create(" ", 1998), Tuple.Create("account", 1999), true)
);

WriteLiteral(">");

            
            #line 53 "..\..\Views\Manage\ManageLogins.cshtml"
                                                                                                                                                                               Write(p.AuthenticationType);

            
            #line default
            #line hidden
WriteLiteral("</button>\r\n");

            
            #line 54 "..\..\Views\Manage\ManageLogins.cshtml"
            }

            
            #line default
            #line hidden
WriteLiteral("        </p>\r\n        </div>\r\n");

            
            #line 57 "..\..\Views\Manage\ManageLogins.cshtml"
    }
}

            
            #line default
            #line hidden
WriteLiteral("\r\n");

        }
    }
}
#pragma warning restore 1591