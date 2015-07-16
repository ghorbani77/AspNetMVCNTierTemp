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
    using System.Web.Routing;
    using System.Web.Security;
    using System.Web.UI;
    using System.Web.WebPages;
    
    #line 2 "..\..\App_Code\BootstrapBuilder.cshtml"
    using MVC5.Common.Controller.Alerts;
    
    #line default
    #line hidden
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/App_Code/BootstrapBuilder.cshtml")]
    public partial class _App_Code_BootstrapBuilder_cshtml : System.Web.Mvc.WebViewPage<dynamic>
    {

#line 7 "..\..\App_Code\BootstrapBuilder.cshtml"
public System.Web.WebPages.HelperResult ShowBootstrapAlerts(Bootstrap bootstrap)
{
#line default
#line hidden
return new System.Web.WebPages.HelperResult(__razor_helper_writer => {

#line 8 "..\..\App_Code\BootstrapBuilder.cshtml"
 
   
    if (bootstrap==null)
    {
        return;
    }

    foreach (var message in bootstrap.BootstrapMessages)
    {
        var dismissableClass = message.Dismissable ? "alert-dismissable" : null;


#line default
#line hidden
WriteLiteralTo(__razor_helper_writer, "        <div");

WriteAttributeTo(__razor_helper_writer, "class", Tuple.Create(" class=\"", 475), Tuple.Create("\"", 531)
, Tuple.Create(Tuple.Create("", 483), Tuple.Create("alert", 483), true)
, Tuple.Create(Tuple.Create(" ", 488), Tuple.Create("alert-", 489), true)

#line 18 "..\..\App_Code\BootstrapBuilder.cshtml"
, Tuple.Create(Tuple.Create("", 495), Tuple.Create<System.Object, System.Int32>(message.AlertType

#line default
#line hidden
, 495), false)

#line 18 "..\..\App_Code\BootstrapBuilder.cshtml"
, Tuple.Create(Tuple.Create(" ", 513), Tuple.Create<System.Object, System.Int32>(dismissableClass

#line default
#line hidden
, 514), false)
);

WriteLiteralTo(__razor_helper_writer, ">\r\n");


#line 19 "..\..\App_Code\BootstrapBuilder.cshtml"
            

#line default
#line hidden

#line 19 "..\..\App_Code\BootstrapBuilder.cshtml"
             if (message.Dismissable)
            {


#line default
#line hidden
WriteLiteralTo(__razor_helper_writer, "                <button");

WriteLiteralTo(__razor_helper_writer, " type=\"button\"");

WriteLiteralTo(__razor_helper_writer, " class=\"close\"");

WriteLiteralTo(__razor_helper_writer, " data-dismiss=\"alert\"");

WriteLiteralTo(__razor_helper_writer, " aria-hidden=\"true\"");

WriteLiteralTo(__razor_helper_writer, ">&times;</button>\r\n");


#line 22 "..\..\App_Code\BootstrapBuilder.cshtml"
            }


#line default
#line hidden
WriteLiteralTo(__razor_helper_writer, "            ");


#line 23 "..\..\App_Code\BootstrapBuilder.cshtml"
WriteTo(__razor_helper_writer, Html.Raw(message.Message));


#line default
#line hidden
WriteLiteralTo(__razor_helper_writer, "\r\n        </div>\r\n");


#line 25 "..\..\App_Code\BootstrapBuilder.cshtml"
    }


#line default
#line hidden
});

#line 26 "..\..\App_Code\BootstrapBuilder.cshtml"
}
#line default
#line hidden

        public _App_Code_BootstrapBuilder_cshtml()
        {
        }
        public override void Execute()
        {
WriteLiteral("\r\n");

WriteLiteral("\r\n");

WriteLiteral("\r\n\r\n");

WriteLiteral("\r\n\r\n");

        }
    }
}
#pragma warning restore 1591