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
    
    #line 2 "..\..\Views\Account\_ExternalLoginsListPartial.cshtml"
    using Microsoft.Owin.Security;
    
    #line default
    #line hidden
    using MVC5.ViewModel;
    using MVC5.Web;
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/Account/_ExternalLoginsListPartial.cshtml")]
    public partial class _Views_Account__ExternalLoginsListPartial_cshtml : System.Web.Mvc.WebViewPage<MVC5.ViewModel.Account.ExternalLoginListViewModel>
    {
        public _Views_Account__ExternalLoginsListPartial_cshtml()
        {
        }
        public override void Execute()
        {
            
            #line 3 "..\..\Views\Account\_ExternalLoginsListPartial.cshtml"
  
    var loginProviders = Context.GetOwinContext().Authentication.GetExternalAuthenticationTypes();
    var authenticationDescriptions = loginProviders as AuthenticationDescription[] ?? loginProviders.ToArray();

            
            #line default
            #line hidden
WriteLiteral("\r\n\r\n");

            
            #line 8 "..\..\Views\Account\_ExternalLoginsListPartial.cshtml"
 if (authenticationDescriptions.Any())
{

    using (Html.BeginForm(MVC.Account.ActionNames.ExternalLogin, MVC.Account.Name, new { ReturnUrl = Model.ReturnUrl }))
    {
        
            
            #line default
            #line hidden
            
            #line 13 "..\..\Views\Account\_ExternalLoginsListPartial.cshtml"
   Write(Html.AntiForgeryToken());

            
            #line default
            #line hidden
            
            #line 13 "..\..\Views\Account\_ExternalLoginsListPartial.cshtml"
                                

        foreach (var p in authenticationDescriptions)
        {

            
            #line default
            #line hidden
WriteLiteral("            <div");

WriteLiteral(" class=\"col-md-6\"");

WriteLiteral(">\r\n                <input");

WriteLiteral(" type=\"submit\"");

WriteLiteral(" class=\"btn btn-danger btn-block text-capitalize\"");

WriteAttribute("id", Tuple.Create(" id=\"", 709), Tuple.Create("\"", 735)
            
            #line 18 "..\..\Views\Account\_ExternalLoginsListPartial.cshtml"
           , Tuple.Create(Tuple.Create("", 714), Tuple.Create<System.Object, System.Int32>(p.AuthenticationType
            
            #line default
            #line hidden
, 714), false)
);

WriteLiteral(" name=\"provider\"");

WriteAttribute("value", Tuple.Create("\r\n                       value=\"", 752), Tuple.Create("\"", 805)
            
            #line 19 "..\..\Views\Account\_ExternalLoginsListPartial.cshtml"
, Tuple.Create(Tuple.Create("", 784), Tuple.Create<System.Object, System.Int32>(p.AuthenticationType
            
            #line default
            #line hidden
, 784), false)
);

WriteAttribute("title", Tuple.Create(" title=\"", 806), Tuple.Create("\"", 837)
            
            #line 19 "..\..\Views\Account\_ExternalLoginsListPartial.cshtml"
, Tuple.Create(Tuple.Create("", 814), Tuple.Create<System.Object, System.Int32>(p.Caption
            
            #line default
            #line hidden
, 814), false)
, Tuple.Create(Tuple.Create(" ", 824), Tuple.Create("ورود", 825), true)
, Tuple.Create(Tuple.Create(" ", 829), Tuple.Create("با", 830), true)
, Tuple.Create(Tuple.Create(" ", 832), Tuple.Create("حساب", 833), true)
);

WriteLiteral(" />\r\n                <hr />\r\n            </div>\r\n");

            
            #line 22 "..\..\Views\Account\_ExternalLoginsListPartial.cshtml"
        }

    }
}

            
            #line default
            #line hidden
WriteLiteral("\r\n");

        }
    }
}
#pragma warning restore 1591
