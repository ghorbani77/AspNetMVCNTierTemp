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

namespace MVC5.Web.RazorHelpers
{
    using System.Web.Mvc;
#line 4 "..\..\RazorHelpers\BootstrapBuilder.cshtml"
    using MVC5.Common.Controller.Alerts;
    
    #line default
    #line hidden
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    public static class BootstrapBuilder
    {

public static System.Web.WebPages.HelperResult ShowBootstrapAlerts(Bootstrap bootstrap)
{
return new System.Web.WebPages.HelperResult(__razor_helper_writer => {



#line 10 "..\..\RazorHelpers\BootstrapBuilder.cshtml"
 
   
    if (bootstrap==null)
    {
        return;
    }

    foreach (var message in bootstrap.BootstrapMessages)
    {
        var dismissableClass = message.Dismissable ? "alert-dismissable" : null;

#line default
#line hidden

WebViewPage.WriteLiteralTo(@__razor_helper_writer, "        <div class=\"alert alert-");



#line 20 "..\..\RazorHelpers\BootstrapBuilder.cshtml"
WebViewPage.WriteTo(@__razor_helper_writer, message.AlertType);

#line default
#line hidden

WebViewPage.WriteLiteralTo(@__razor_helper_writer, " ");



#line 20 "..\..\RazorHelpers\BootstrapBuilder.cshtml"
        WebViewPage.WriteTo(@__razor_helper_writer, dismissableClass);

#line default
#line hidden

WebViewPage.WriteLiteralTo(@__razor_helper_writer, "\">\r\n");



#line 21 "..\..\RazorHelpers\BootstrapBuilder.cshtml"
             if (message.Dismissable)
            {

#line default
#line hidden

WebViewPage.WriteLiteralTo(@__razor_helper_writer, "                <button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-hid" +
"den=\"true\">&times;</button>\r\n");



#line 24 "..\..\RazorHelpers\BootstrapBuilder.cshtml"
            }

#line default
#line hidden

WebViewPage.WriteLiteralTo(@__razor_helper_writer, "            ");



#line 25 "..\..\RazorHelpers\BootstrapBuilder.cshtml"
WebViewPage.WriteTo(@__razor_helper_writer, message.Message);

#line default
#line hidden

WebViewPage.WriteLiteralTo(@__razor_helper_writer, "\r\n        </div>\r\n");



#line 27 "..\..\RazorHelpers\BootstrapBuilder.cshtml"
    }

#line default
#line hidden

});

}


    }
}
#pragma warning restore 1591
