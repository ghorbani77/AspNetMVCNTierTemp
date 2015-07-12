using System.Web.Optimization;

namespace MVC5.Web
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*",
                        "~/Scripts/kendo.modernizr.custom.js"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.min.js",
                      "~/Scripts/site.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.min.css",
                      "~/Content/Plugins/font-awesome.min.css",
                      "~/Content/site.css"));

            bundles.Add(new ScriptBundle("~/bundles/kendo/js").Include(
                      "~/Scripts/kendo/kendo.all.min.js",
                      "~/Scritps/kendo/kendo.fa-IR.js",
                      "~/Scripts/kendo/kendo.aspnetmvc.min.js",
                      "~/Scripts/kendo.modernizr.custom.js"));

             bundles.Add(new StyleBundle("~/bundles/kendo/css").Include(
                      "~/Content/kendo/kendo.flat.min.css",
                      "~/Content/kendo/kendo.common.min.css",
                      "~/Content/kendo/kendo.rtl.min.css"));


            BundleTable.EnableOptimizations = true;
           
        }
    }
}
