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
    
    #line 2 "..\..\RazorHelpers\ToastrBuilder.cshtml"
    using MVC5.Common.Controller.Alerts;
    
    #line default
    #line hidden
    
    #line 3 "..\..\RazorHelpers\ToastrBuilder.cshtml"
    using MVC5.Common.Helpers.Extentions;
    
    #line default
    #line hidden
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    public static class ToastrBuilder
    {

public static System.Web.WebPages.HelperResult ShowToastMessages(Toastr toastr)
{
return new System.Web.WebPages.HelperResult(__razor_helper_writer => {



#line 10 "..\..\RazorHelpers\ToastrBuilder.cshtml"
 
    if (toastr == null)
    {
        return;
    }

#line default
#line hidden

WebViewPage.WriteLiteralTo(@__razor_helper_writer, "    <script>\r\n    $(function () {\r\n        toastr.options.closeButton = \'");



#line 17 "..\..\RazorHelpers\ToastrBuilder.cshtml"
WebViewPage.WriteTo(@__razor_helper_writer, toastr.ShowCloseButton);

#line default
#line hidden

WebViewPage.WriteLiteralTo(@__razor_helper_writer, "\';\r\n        toastr.options.newestOnTop = \'");



#line 18 "..\..\RazorHelpers\ToastrBuilder.cshtml"
WebViewPage.WriteTo(@__razor_helper_writer, toastr.ShowNewestOnTop);

#line default
#line hidden

WebViewPage.WriteLiteralTo(@__razor_helper_writer, "\';\r\n        toastr.options.progressBar = \'");



#line 19 "..\..\RazorHelpers\ToastrBuilder.cshtml"
WebViewPage.WriteTo(@__razor_helper_writer, toastr.ProgressBar);

#line default
#line hidden

WebViewPage.WriteLiteralTo(@__razor_helper_writer, "\';\r\n");



#line 20 "..\..\RazorHelpers\ToastrBuilder.cshtml"
         foreach (var message in toastr.ToastMessages)
        {
            var toastTypeValue = message.AlertType.ToLower();

#line default
#line hidden

WebViewPage.WriteLiteralTo(@__razor_helper_writer, "            ");

WebViewPage.WriteLiteralTo(@__razor_helper_writer, "var optionsOverride = { /* Add message specific options here */ };\r\n");



#line 24 "..\..\RazorHelpers\ToastrBuilder.cshtml"
            if (message.IsSticky)
            {
               

#line default
#line hidden

WebViewPage.WriteLiteralTo(@__razor_helper_writer, "                ");

WebViewPage.WriteLiteralTo(@__razor_helper_writer, "toastr.options.timeOut = 0;\r\n        toastr.options.progressBar = false;\r\n       " +
" toastr.options.extendedTimeout = 0;");

WebViewPage.WriteLiteralTo(@__razor_helper_writer, "\r\n");



#line 30 "..\..\RazorHelpers\ToastrBuilder.cshtml"
            }
            if (message.Title.IsNotEmpty())
            {

#line default
#line hidden

WebViewPage.WriteLiteralTo(@__razor_helper_writer, "                ");

WebViewPage.WriteLiteralTo(@__razor_helper_writer, "toastr[\'");



#line 33 "..\..\RazorHelpers\ToastrBuilder.cshtml"
WebViewPage.WriteTo(@__razor_helper_writer, toastTypeValue);

#line default
#line hidden

WebViewPage.WriteLiteralTo(@__razor_helper_writer, "\'](\'");



#line 33 "..\..\RazorHelpers\ToastrBuilder.cshtml"
  WebViewPage.WriteTo(@__razor_helper_writer, message.Message);

#line default
#line hidden

WebViewPage.WriteLiteralTo(@__razor_helper_writer, "\', \'");



#line 33 "..\..\RazorHelpers\ToastrBuilder.cshtml"
                      WebViewPage.WriteTo(@__razor_helper_writer, message.Title);

#line default
#line hidden

WebViewPage.WriteLiteralTo(@__razor_helper_writer, "\');\r\n");



#line 34 "..\..\RazorHelpers\ToastrBuilder.cshtml"
              }
            else
            {

#line default
#line hidden

WebViewPage.WriteLiteralTo(@__razor_helper_writer, "                ");

WebViewPage.WriteLiteralTo(@__razor_helper_writer, "toastr[\'");



#line 37 "..\..\RazorHelpers\ToastrBuilder.cshtml"
WebViewPage.WriteTo(@__razor_helper_writer, toastTypeValue);

#line default
#line hidden

WebViewPage.WriteLiteralTo(@__razor_helper_writer, "\'](\'");



#line 37 "..\..\RazorHelpers\ToastrBuilder.cshtml"
  WebViewPage.WriteTo(@__razor_helper_writer, message.Message);

#line default
#line hidden

WebViewPage.WriteLiteralTo(@__razor_helper_writer, "\');\r\n");



#line 38 "..\..\RazorHelpers\ToastrBuilder.cshtml"
              }
        }

#line default
#line hidden

WebViewPage.WriteLiteralTo(@__razor_helper_writer, "    });\r\n    </script>\r\n");



#line 42 "..\..\RazorHelpers\ToastrBuilder.cshtml"

#line default
#line hidden

});

}


    }
}
#pragma warning restore 1591
