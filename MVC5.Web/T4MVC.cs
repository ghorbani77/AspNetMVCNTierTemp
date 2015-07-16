﻿// <auto-generated />
// This file was generated by a T4 template.
// Don't change it directly as your change would get overwritten.  Instead, make changes
// to the .tt file (i.e. the T4 template) and save it to regenerate this file.

// Make sure the compiler doesn't complain about missing Xml comments and CLS compliance
// 0108: suppress "Foo hides inherited member Foo. Use the new keyword if hiding was intended." when a controller and its abstract parent are both processed
// 0114: suppress "Foo.BarController.Baz()' hides inherited member 'Qux.BarController.Baz()'. To make the current member override that implementation, add the override keyword. Otherwise add the new keyword." when an action (with an argument) overrides an action in a parent controller
#pragma warning disable 1591, 3008, 3009, 0108, 0114
#region T4MVC

using System;
using System.Diagnostics;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Web;
using System.Web.Hosting;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using System.Web.Mvc.Html;
using System.Web.Routing;
using T4MVC;

[GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
public static partial class MVC
{
    static readonly AdminstratorClass s_Adminstrator = new AdminstratorClass();
    public static AdminstratorClass Adminstrator { get { return s_Adminstrator; } }
    public static MVC5.Web.Controllers.AccountController Account = new MVC5.Web.Controllers.T4MVC_AccountController();
    public static MVC5.Web.Controllers.ExportController Export = new MVC5.Web.Controllers.T4MVC_ExportController();
    public static MVC5.Web.Controllers.HomeController Home = new MVC5.Web.Controllers.T4MVC_HomeController();
    public static MVC5.Web.Controllers.ManageController Manage = new MVC5.Web.Controllers.T4MVC_ManageController();
    public static T4MVC.SharedController Shared = new T4MVC.SharedController();
    public static T4MVC.UserMailerController UserMailer = new T4MVC.UserMailerController();
}

namespace T4MVC
{
    [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
    public class AdminstratorClass
    {
        public readonly string Name = "Adminstrator";
        public MVC5.Web.Areas.Adminstrator.Controllers.HomeController Home = new MVC5.Web.Areas.Adminstrator.Controllers.T4MVC_HomeController();
        public MVC5.Web.Areas.Adminstrator.Controllers.RoleController Role = new MVC5.Web.Areas.Adminstrator.Controllers.T4MVC_RoleController();
        public MVC5.Web.Areas.Adminstrator.Controllers.UserController User = new MVC5.Web.Areas.Adminstrator.Controllers.T4MVC_UserController();
        public T4MVC.Adminstrator.SharedController Shared = new T4MVC.Adminstrator.SharedController();
    }
}

namespace T4MVC
{
    [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
    public class Dummy
    {
        private Dummy() { }
        public static Dummy Instance = new Dummy();
    }
}

[GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
internal partial class T4MVC_System_Web_Mvc_ActionResult : System.Web.Mvc.ActionResult, IT4MVCActionResult
{
    public T4MVC_System_Web_Mvc_ActionResult(string area, string controller, string action, string protocol = null): base()
    {
        this.InitMVCT4Result(area, controller, action, protocol);
    }
     
    public override void ExecuteResult(System.Web.Mvc.ControllerContext context) { }
    
    public string Controller { get; set; }
    public string Action { get; set; }
    public string Protocol { get; set; }
    public RouteValueDictionary RouteValueDictionary { get; set; }
}
[GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
internal partial class T4MVC_System_Web_Mvc_JsonResult : System.Web.Mvc.JsonResult, IT4MVCActionResult
{
    public T4MVC_System_Web_Mvc_JsonResult(string area, string controller, string action, string protocol = null): base()
    {
        this.InitMVCT4Result(area, controller, action, protocol);
    }
    
    public string Controller { get; set; }
    public string Action { get; set; }
    public string Protocol { get; set; }
    public RouteValueDictionary RouteValueDictionary { get; set; }
}



namespace Links
{
    [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
    public static class Scripts {
        private const string URLPATH = "~/Scripts";
        public static string Url() { return T4MVCHelpers.ProcessVirtualPath(URLPATH); }
        public static string Url(string fileName) { return T4MVCHelpers.ProcessVirtualPath(URLPATH + "/" + fileName); }
        public static readonly string _references_js = T4MVCHelpers.IsProduction() && T4Extensions.FileExists(URLPATH + "/_references.min.js") ? Url("_references.min.js") : Url("_references.js");
        public static readonly string admin_js = T4MVCHelpers.IsProduction() && T4Extensions.FileExists(URLPATH + "/admin.min.js") ? Url("admin.min.js") : Url("admin.js");
        public static readonly string admin_min_js = Url("admin.min.js");
        public static readonly string admin_min_js_map = Url("admin.min.js.map");
        public static readonly string bootstrap_js = T4MVCHelpers.IsProduction() && T4Extensions.FileExists(URLPATH + "/bootstrap.min.js") ? Url("bootstrap.min.js") : Url("bootstrap.js");
        public static readonly string bootstrap_min_js = Url("bootstrap.min.js");
        public static readonly string bootstrap_min_js_map = Url("bootstrap.min.js.map");
        public static readonly string jquery_1_10_2_intellisense_js = T4MVCHelpers.IsProduction() && T4Extensions.FileExists(URLPATH + "/jquery-1.10.2.intellisense.min.js") ? Url("jquery-1.10.2.intellisense.min.js") : Url("jquery-1.10.2.intellisense.js");
        public static readonly string jquery_1_10_2_js = T4MVCHelpers.IsProduction() && T4Extensions.FileExists(URLPATH + "/jquery-1.10.2.min.js") ? Url("jquery-1.10.2.min.js") : Url("jquery-1.10.2.js");
        public static readonly string jquery_1_10_2_min_js = Url("jquery-1.10.2.min.js");
        public static readonly string jquery_1_10_2_min_map = Url("jquery-1.10.2.min.map");
        public static readonly string jquery_2_1_4_intellisense_js = T4MVCHelpers.IsProduction() && T4Extensions.FileExists(URLPATH + "/jquery-2.1.4.intellisense.min.js") ? Url("jquery-2.1.4.intellisense.min.js") : Url("jquery-2.1.4.intellisense.js");
        public static readonly string jquery_2_1_4_js = T4MVCHelpers.IsProduction() && T4Extensions.FileExists(URLPATH + "/jquery-2.1.4.min.js") ? Url("jquery-2.1.4.min.js") : Url("jquery-2.1.4.js");
        public static readonly string jquery_2_1_4_min_js = Url("jquery-2.1.4.min.js");
        public static readonly string jquery_2_1_4_min_map = Url("jquery-2.1.4.min.map");
        public static readonly string jquery_unobtrusive_ajax_js = T4MVCHelpers.IsProduction() && T4Extensions.FileExists(URLPATH + "/jquery.unobtrusive-ajax.min.js") ? Url("jquery.unobtrusive-ajax.min.js") : Url("jquery.unobtrusive-ajax.js");
        public static readonly string jquery_unobtrusive_ajax_min_js = Url("jquery.unobtrusive-ajax.min.js");
        public static readonly string jquery_validate_vsdoc_js = T4MVCHelpers.IsProduction() && T4Extensions.FileExists(URLPATH + "/jquery.validate-vsdoc.min.js") ? Url("jquery.validate-vsdoc.min.js") : Url("jquery.validate-vsdoc.js");
        public static readonly string jquery_validate_js = T4MVCHelpers.IsProduction() && T4Extensions.FileExists(URLPATH + "/jquery.validate.min.js") ? Url("jquery.validate.min.js") : Url("jquery.validate.js");
        public static readonly string jquery_validate_min_js = Url("jquery.validate.min.js");
        public static readonly string jquery_validate_unobtrusive_js = T4MVCHelpers.IsProduction() && T4Extensions.FileExists(URLPATH + "/jquery.validate.unobtrusive.min.js") ? Url("jquery.validate.unobtrusive.min.js") : Url("jquery.validate.unobtrusive.js");
        public static readonly string jquery_validate_unobtrusive_min_js = Url("jquery.validate.unobtrusive.min.js");
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public static class material {
            private const string URLPATH = "~/Scripts/material";
            public static string Url() { return T4MVCHelpers.ProcessVirtualPath(URLPATH); }
            public static string Url(string fileName) { return T4MVCHelpers.ProcessVirtualPath(URLPATH + "/" + fileName); }
            public static readonly string material_js = T4MVCHelpers.IsProduction() && T4Extensions.FileExists(URLPATH + "/material.min.js") ? Url("material.min.js") : Url("material.js");
            public static readonly string material_min_js = Url("material.min.js");
            public static readonly string material_min_js_map = Url("material.min.js.map");
            public static readonly string ripples_js = T4MVCHelpers.IsProduction() && T4Extensions.FileExists(URLPATH + "/ripples.min.js") ? Url("ripples.min.js") : Url("ripples.js");
            public static readonly string ripples_min_js = Url("ripples.min.js");
            public static readonly string ripples_min_js_map = Url("ripples.min.js.map");
        }
    
        public static readonly string modernizr_2_6_2_js = T4MVCHelpers.IsProduction() && T4Extensions.FileExists(URLPATH + "/modernizr-2.6.2.min.js") ? Url("modernizr-2.6.2.min.js") : Url("modernizr-2.6.2.js");
        public static readonly string modernizr_2_8_3_js = T4MVCHelpers.IsProduction() && T4Extensions.FileExists(URLPATH + "/modernizr-2.8.3.min.js") ? Url("modernizr-2.8.3.min.js") : Url("modernizr-2.8.3.js");
        public static readonly string npm_js = T4MVCHelpers.IsProduction() && T4Extensions.FileExists(URLPATH + "/npm.min.js") ? Url("npm.min.js") : Url("npm.js");
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public static class plugins {
            private const string URLPATH = "~/Scripts/plugins";
            public static string Url() { return T4MVCHelpers.ProcessVirtualPath(URLPATH); }
            public static string Url(string fileName) { return T4MVCHelpers.ProcessVirtualPath(URLPATH + "/" + fileName); }
            public static readonly string fileinput_min_js = Url("fileinput.min.js");
            public static readonly string jquery_cookie_js = T4MVCHelpers.IsProduction() && T4Extensions.FileExists(URLPATH + "/jquery.cookie.min.js") ? Url("jquery.cookie.min.js") : Url("jquery.cookie.js");
            public static readonly string jquery_cookie_min_js = Url("jquery.cookie.min.js");
            public static readonly string jquery_cookie_min_js_map = Url("jquery.cookie.min.js.map");
            public static readonly string jquery_lazyload_js = T4MVCHelpers.IsProduction() && T4Extensions.FileExists(URLPATH + "/jquery.lazyload.min.js") ? Url("jquery.lazyload.min.js") : Url("jquery.lazyload.js");
            public static readonly string jquery_lazyload_min_js = Url("jquery.lazyload.min.js");
            public static readonly string jquery_sliderPro_min_js = Url("jquery.sliderPro.min.js");
            public static readonly string json2_js = T4MVCHelpers.IsProduction() && T4Extensions.FileExists(URLPATH + "/json2.min.js") ? Url("json2.min.js") : Url("json2.js");
            public static readonly string json2_min_js = Url("json2.min.js");
            public static readonly string lazysizes_js = T4MVCHelpers.IsProduction() && T4Extensions.FileExists(URLPATH + "/lazysizes.min.js") ? Url("lazysizes.min.js") : Url("lazysizes.js");
            public static readonly string lazysizes_min_js = Url("lazysizes.min.js");
            public static readonly string star_rating_js = T4MVCHelpers.IsProduction() && T4Extensions.FileExists(URLPATH + "/star-rating.min.js") ? Url("star-rating.min.js") : Url("star-rating.js");
            public static readonly string star_rating_min_js = Url("star-rating.min.js");
            public static readonly string sweet_alert_js = T4MVCHelpers.IsProduction() && T4Extensions.FileExists(URLPATH + "/sweet-alert.min.js") ? Url("sweet-alert.min.js") : Url("sweet-alert.js");
            public static readonly string sweet_alert_min_js = Url("sweet-alert.min.js");
            public static readonly string xeditable_js = T4MVCHelpers.IsProduction() && T4Extensions.FileExists(URLPATH + "/xeditable.min.js") ? Url("xeditable.min.js") : Url("xeditable.js");
            public static readonly string xeditable_min_js = Url("xeditable.min.js");
        }
    
        public static readonly string respond_js = T4MVCHelpers.IsProduction() && T4Extensions.FileExists(URLPATH + "/respond.min.js") ? Url("respond.min.js") : Url("respond.js");
        public static readonly string respond_matchmedia_addListener_js = T4MVCHelpers.IsProduction() && T4Extensions.FileExists(URLPATH + "/respond.matchmedia.addListener.min.js") ? Url("respond.matchmedia.addListener.min.js") : Url("respond.matchmedia.addListener.js");
        public static readonly string respond_matchmedia_addListener_min_js = Url("respond.matchmedia.addListener.min.js");
        public static readonly string respond_min_js = Url("respond.min.js");
        public static readonly string site_js = T4MVCHelpers.IsProduction() && T4Extensions.FileExists(URLPATH + "/site.min.js") ? Url("site.min.js") : Url("site.js");
        public static readonly string site_min_js = Url("site.min.js");
        public static readonly string site_min_js_map = Url("site.min.js.map");
        public static readonly string toastr_js = T4MVCHelpers.IsProduction() && T4Extensions.FileExists(URLPATH + "/toastr.min.js") ? Url("toastr.min.js") : Url("toastr.js");
        public static readonly string toastr_min_js = Url("toastr.min.js");
        public static readonly string warning_js = T4MVCHelpers.IsProduction() && T4Extensions.FileExists(URLPATH + "/warning.min.js") ? Url("warning.min.js") : Url("warning.js");
    }

    [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
    public static class Content {
        private const string URLPATH = "~/Content";
        public static string Url() { return T4MVCHelpers.ProcessVirtualPath(URLPATH); }
        public static string Url(string fileName) { return T4MVCHelpers.ProcessVirtualPath(URLPATH + "/" + fileName); }
        public static readonly string bootstrap_flat_min_css = Url("bootstrap-flat.min.css");
        public static readonly string bootstrap_rtl_min_css = Url("bootstrap-rtl.min.css");
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public static class favicon {
            private const string URLPATH = "~/Content/favicon";
            public static string Url() { return T4MVCHelpers.ProcessVirtualPath(URLPATH); }
            public static string Url(string fileName) { return T4MVCHelpers.ProcessVirtualPath(URLPATH + "/" + fileName); }
            public static readonly string android_chrome_144x144_png = Url("android-chrome-144x144.png");
            public static readonly string android_chrome_192x192_png = Url("android-chrome-192x192.png");
            public static readonly string android_chrome_36x36_png = Url("android-chrome-36x36.png");
            public static readonly string android_chrome_48x48_png = Url("android-chrome-48x48.png");
            public static readonly string android_chrome_72x72_png = Url("android-chrome-72x72.png");
            public static readonly string android_chrome_96x96_png = Url("android-chrome-96x96.png");
            public static readonly string apple_touch_icon_114x114_png = Url("apple-touch-icon-114x114.png");
            public static readonly string apple_touch_icon_120x120_png = Url("apple-touch-icon-120x120.png");
            public static readonly string apple_touch_icon_144x144_png = Url("apple-touch-icon-144x144.png");
            public static readonly string apple_touch_icon_152x152_png = Url("apple-touch-icon-152x152.png");
            public static readonly string apple_touch_icon_180x180_png = Url("apple-touch-icon-180x180.png");
            public static readonly string apple_touch_icon_57x57_png = Url("apple-touch-icon-57x57.png");
            public static readonly string apple_touch_icon_60x60_png = Url("apple-touch-icon-60x60.png");
            public static readonly string apple_touch_icon_72x72_png = Url("apple-touch-icon-72x72.png");
            public static readonly string apple_touch_icon_76x76_png = Url("apple-touch-icon-76x76.png");
            public static readonly string apple_touch_icon_precomposed_png = Url("apple-touch-icon-precomposed.png");
            public static readonly string apple_touch_icon_png = Url("apple-touch-icon.png");
            public static readonly string favicon_16x16_png = Url("favicon-16x16.png");
            public static readonly string favicon_32x32_png = Url("favicon-32x32.png");
            public static readonly string favicon_96x96_png = Url("favicon-96x96.png");
            public static readonly string favicon_ico = Url("favicon.ico");
        }
    
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public static class fonts {
            private const string URLPATH = "~/Content/fonts";
            public static string Url() { return T4MVCHelpers.ProcessVirtualPath(URLPATH); }
            public static string Url(string fileName) { return T4MVCHelpers.ProcessVirtualPath(URLPATH + "/" + fileName); }
            public static readonly string BYekan_eot = Url("BYekan.eot");
            public static readonly string BYekan_ttf = Url("BYekan.ttf");
            public static readonly string BYekan_woff = Url("BYekan.woff");
            public static readonly string FarMitraBold_eot = Url("FarMitraBold.eot");
            public static readonly string FarMitraBold_otf = Url("FarMitraBold.otf");
            public static readonly string FarMitraBold_woff = Url("FarMitraBold.woff");
            public static readonly string fontawesome_webfont_eot = Url("fontawesome-webfont.eot");
            public static readonly string fontawesome_webfont_svg = Url("fontawesome-webfont.svg");
            public static readonly string fontawesome_webfont_ttf = Url("fontawesome-webfont.ttf");
            public static readonly string fontawesome_webfont_woff = Url("fontawesome-webfont.woff");
            public static readonly string fontawesome_webfont_woff2 = Url("fontawesome-webfont.woff2");
            public static readonly string FontAwesome_otf = Url("FontAwesome.otf");
            public static readonly string glyphicons_halflings_regular_eot = Url("glyphicons-halflings-regular.eot");
            public static readonly string glyphicons_halflings_regular_svg = Url("glyphicons-halflings-regular.svg");
            public static readonly string glyphicons_halflings_regular_ttf = Url("glyphicons-halflings-regular.ttf");
            public static readonly string glyphicons_halflings_regular_woff = Url("glyphicons-halflings-regular.woff");
            public static readonly string glyphicons_halflings_regular_woff2 = Url("glyphicons-halflings-regular.woff2");
            public static readonly string IranianSerif_eot = Url("IranianSerif.eot");
            public static readonly string IranianSerif_woff = Url("IranianSerif.woff");
            public static readonly string irseri_ttf = Url("irseri.ttf");
            public static readonly string Material_Design_Icons_eot = Url("Material-Design-Icons.eot");
            public static readonly string Material_Design_Icons_svg = Url("Material-Design-Icons.svg");
            public static readonly string Material_Design_Icons_ttf = Url("Material-Design-Icons.ttf");
            public static readonly string Material_Design_Icons_woff = Url("Material-Design-Icons.woff");
            public static readonly string RobotoDraftBold_woff = Url("RobotoDraftBold.woff");
            public static readonly string RobotoDraftBold_woff2 = Url("RobotoDraftBold.woff2");
            public static readonly string RobotoDraftItalic_woff = Url("RobotoDraftItalic.woff");
            public static readonly string RobotoDraftItalic_woff2 = Url("RobotoDraftItalic.woff2");
            public static readonly string RobotoDraftMedium_woff = Url("RobotoDraftMedium.woff");
            public static readonly string RobotoDraftMedium_woff2 = Url("RobotoDraftMedium.woff2");
            public static readonly string RobotoDraftRegular_woff = Url("RobotoDraftRegular.woff");
            public static readonly string RobotoDraftRegular_woff2 = Url("RobotoDraftRegular.woff2");
            public static readonly string wYekan_afm = Url("wYekan.afm");
            public static readonly string wYekan_eot = Url("wYekan.eot");
            public static readonly string wYekan_otf = Url("wYekan.otf");
            public static readonly string wYekan_pfa = Url("wYekan.pfa");
            public static readonly string wYekan_pfb = Url("wYekan.pfb");
            public static readonly string wYekan_ps = Url("wYekan.ps");
            public static readonly string wYekan_pt3 = Url("wYekan.pt3");
            public static readonly string wYekan_svg = Url("wYekan.svg");
            public static readonly string wYekan_ttf = Url("wYekan.ttf");
            public static readonly string wYekan_woff = Url("wYekan.woff");
        }
    
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public static class plugins {
            private const string URLPATH = "~/Content/plugins";
            public static string Url() { return T4MVCHelpers.ProcessVirtualPath(URLPATH); }
            public static string Url(string fileName) { return T4MVCHelpers.ProcessVirtualPath(URLPATH + "/" + fileName); }
            public static readonly string animate_css = T4MVCHelpers.IsProduction() && T4Extensions.FileExists(URLPATH + "/animate.min.css") ? Url("animate.min.css") : Url("animate.css");
                 
            public static readonly string animate_min_css = Url("animate.min.css");
            public static readonly string fileinput_min_css = Url("fileinput.min.css");
            public static readonly string font_awesome_css = T4MVCHelpers.IsProduction() && T4Extensions.FileExists(URLPATH + "/font-awesome.min.css") ? Url("font-awesome.min.css") : Url("font-awesome.css");
                 
            public static readonly string font_awesome_min_css = Url("font-awesome.min.css");
            public static readonly string slider_pro_min_css = Url("slider-pro.min.css");
            public static readonly string star_rating_css = T4MVCHelpers.IsProduction() && T4Extensions.FileExists(URLPATH + "/star-rating.min.css") ? Url("star-rating.min.css") : Url("star-rating.css");
                 
            public static readonly string star_rating_min_css = Url("star-rating.min.css");
            public static readonly string xeditable_css = T4MVCHelpers.IsProduction() && T4Extensions.FileExists(URLPATH + "/xeditable.min.css") ? Url("xeditable.min.css") : Url("xeditable.css");
                 
            public static readonly string xeditable_min_css = Url("xeditable.min.css");
        }
    
        public static readonly string site_css = T4MVCHelpers.IsProduction() && T4Extensions.FileExists(URLPATH + "/site.min.css") ? Url("site.min.css") : Url("site.css");
             
        public static readonly string Site_min_css = Url("Site.min.css");
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public static class siteImg {
            private const string URLPATH = "~/Content/siteImg";
            public static string Url() { return T4MVCHelpers.ProcessVirtualPath(URLPATH); }
            public static string Url(string fileName) { return T4MVCHelpers.ProcessVirtualPath(URLPATH + "/" + fileName); }
            public static readonly string mstile_144x144_png = Url("mstile-144x144.png");
            public static readonly string mstile_150x150_png = Url("mstile-150x150.png");
            public static readonly string mstile_310x150_png = Url("mstile-310x150.png");
            public static readonly string mstile_310x310_png = Url("mstile-310x310.png");
            public static readonly string mstile_70x70_png = Url("mstile-70x70.png");
        }
    
        public static readonly string toastr_css = T4MVCHelpers.IsProduction() && T4Extensions.FileExists(URLPATH + "/toastr.min.css") ? Url("toastr.min.css") : Url("toastr.css");
             
        public static readonly string toastr_min_css = Url("toastr.min.css");
    }

    
    [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
    public static partial class Bundles
    {
        public static partial class Scripts 
        {
            public static partial class material 
            {
                public static class Assets
                {
                    public const string material_js = "~/Scripts/material/material.js"; 
                    public const string material_min_js = "~/Scripts/material/material.min.js"; 
                    public const string ripples_js = "~/Scripts/material/ripples.js"; 
                    public const string ripples_min_js = "~/Scripts/material/ripples.min.js"; 
                }
            }
            public static partial class plugins 
            {
                public static class Assets
                {
                    public const string fileinput_min_js = "~/Scripts/plugins/fileinput.min.js"; 
                    public const string jquery_cookie_js = "~/Scripts/plugins/jquery.cookie.js"; 
                    public const string jquery_cookie_min_js = "~/Scripts/plugins/jquery.cookie.min.js"; 
                    public const string jquery_lazyload_js = "~/Scripts/plugins/jquery.lazyload.js"; 
                    public const string jquery_lazyload_min_js = "~/Scripts/plugins/jquery.lazyload.min.js"; 
                    public const string jquery_sliderPro_min_js = "~/Scripts/plugins/jquery.sliderPro.min.js"; 
                    public const string json2_js = "~/Scripts/plugins/json2.js"; 
                    public const string json2_min_js = "~/Scripts/plugins/json2.min.js"; 
                    public const string lazysizes_js = "~/Scripts/plugins/lazysizes.js"; 
                    public const string lazysizes_min_js = "~/Scripts/plugins/lazysizes.min.js"; 
                    public const string star_rating_js = "~/Scripts/plugins/star-rating.js"; 
                    public const string star_rating_min_js = "~/Scripts/plugins/star-rating.min.js"; 
                    public const string sweet_alert_js = "~/Scripts/plugins/sweet-alert.js"; 
                    public const string sweet_alert_min_js = "~/Scripts/plugins/sweet-alert.min.js"; 
                    public const string xeditable_js = "~/Scripts/plugins/xeditable.js"; 
                    public const string xeditable_min_js = "~/Scripts/plugins/xeditable.min.js"; 
                }
            }
            public static class Assets
            {
                public const string _references_js = "~/Scripts/_references.js"; 
                public const string admin_js = "~/Scripts/admin.js"; 
                public const string bootstrap_js = "~/Scripts/bootstrap.js"; 
                public const string bootstrap_min_js = "~/Scripts/bootstrap.min.js"; 
                public const string jquery_1_10_2_intellisense_js = "~/Scripts/jquery-1.10.2.intellisense.js"; 
                public const string jquery_1_10_2_js = "~/Scripts/jquery-1.10.2.js"; 
                public const string jquery_1_10_2_min_js = "~/Scripts/jquery-1.10.2.min.js"; 
                public const string jquery_2_1_4_intellisense_js = "~/Scripts/jquery-2.1.4.intellisense.js"; 
                public const string jquery_2_1_4_js = "~/Scripts/jquery-2.1.4.js"; 
                public const string jquery_2_1_4_min_js = "~/Scripts/jquery-2.1.4.min.js"; 
                public const string jquery_unobtrusive_ajax_js = "~/Scripts/jquery.unobtrusive-ajax.js"; 
                public const string jquery_unobtrusive_ajax_min_js = "~/Scripts/jquery.unobtrusive-ajax.min.js"; 
                public const string jquery_validate_js = "~/Scripts/jquery.validate.js"; 
                public const string jquery_validate_min_js = "~/Scripts/jquery.validate.min.js"; 
                public const string jquery_validate_unobtrusive_js = "~/Scripts/jquery.validate.unobtrusive.js"; 
                public const string jquery_validate_unobtrusive_min_js = "~/Scripts/jquery.validate.unobtrusive.min.js"; 
                public const string modernizr_2_6_2_js = "~/Scripts/modernizr-2.6.2.js"; 
                public const string modernizr_2_8_3_js = "~/Scripts/modernizr-2.8.3.js"; 
                public const string npm_js = "~/Scripts/npm.js"; 
                public const string respond_js = "~/Scripts/respond.js"; 
                public const string respond_matchmedia_addListener_js = "~/Scripts/respond.matchmedia.addListener.js"; 
                public const string respond_matchmedia_addListener_min_js = "~/Scripts/respond.matchmedia.addListener.min.js"; 
                public const string respond_min_js = "~/Scripts/respond.min.js"; 
                public const string site_js = "~/Scripts/site.js"; 
                public const string toastr_js = "~/Scripts/toastr.js"; 
                public const string toastr_min_js = "~/Scripts/toastr.min.js"; 
                public const string warning_js = "~/Scripts/warning.js"; 
            }
        }
        public static partial class Content 
        {
            public static partial class favicon 
            {
                public static class Assets
                {
                }
            }
            public static partial class fonts 
            {
                public static class Assets
                {
                }
            }
            public static partial class plugins 
            {
                public static class Assets
                {
                    public const string animate_css = "~/Content/plugins/animate.css";
                    public const string animate_min_css = "~/Content/plugins/animate.min.css";
                    public const string fileinput_min_css = "~/Content/plugins/fileinput.min.css";
                    public const string font_awesome_css = "~/Content/plugins/font-awesome.css";
                    public const string font_awesome_min_css = "~/Content/plugins/font-awesome.min.css";
                    public const string slider_pro_min_css = "~/Content/plugins/slider-pro.min.css";
                    public const string star_rating_css = "~/Content/plugins/star-rating.css";
                    public const string star_rating_min_css = "~/Content/plugins/star-rating.min.css";
                    public const string xeditable_css = "~/Content/plugins/xeditable.css";
                }
            }
            public static partial class siteImg 
            {
                public static class Assets
                {
                }
            }
            public static class Assets
            {
                public const string bootstrap_flat_min_css = "~/Content/bootstrap-flat.min.css";
                public const string bootstrap_rtl_min_css = "~/Content/bootstrap-rtl.min.css";
                public const string site_css = "~/Content/site.css";
                public const string toastr_css = "~/Content/toastr.css";
                public const string toastr_min_css = "~/Content/toastr.min.css";
            }
        }
    }
}

[GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
internal static class T4MVCHelpers {
    // You can change the ProcessVirtualPath method to modify the path that gets returned to the client.
    // e.g. you can prepend a domain, or append a query string:
    //      return "http://localhost" + path + "?foo=bar";
    private static string ProcessVirtualPathDefault(string virtualPath) {
        // The path that comes in starts with ~/ and must first be made absolute
        string path = VirtualPathUtility.ToAbsolute(virtualPath);
        
        // Add your own modifications here before returning the path
        return path;
    }

    // Calling ProcessVirtualPath through delegate to allow it to be replaced for unit testing
    public static Func<string, string> ProcessVirtualPath = ProcessVirtualPathDefault;

    // Calling T4Extension.TimestampString through delegate to allow it to be replaced for unit testing and other purposes
    public static Func<string, string> TimestampString = System.Web.Mvc.T4Extensions.TimestampString;

    // Logic to determine if the app is running in production or dev environment
    public static bool IsProduction() { 
        return (HttpContext.Current != null && !HttpContext.Current.IsDebuggingEnabled); 
    }
}





#endregion T4MVC
#pragma warning restore 1591, 3008, 3009, 0108, 0114


