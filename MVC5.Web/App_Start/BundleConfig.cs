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
                        "~/Scripts/modernizr-*"
                       ));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.min.js",
                      "~/Scripts/site.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.min.css",
                      "~/Content/Plugins/font-awesome.min.css",
                      "~/Content/site.css"));

            bundles.Add(new StyleBundle("~/Content/admin").Include(
                "~/Content/Plugins/xeditable.css",
                "~/Content/bootstrap.min.css",
                "~/Content/toastr.min.css",
                "~/Content/Plugins/font-awesome.min.css",
                "~/Content/Plugins/animate.min.css",
                "~/Content/Plugins/fileinput.min.css",
                "~/Content/Plugins/font-awesome.min.css"));

            bundles.Add(new ScriptBundle("~/bundles/admin").Include(
                      "~/Scripts/bootstrap.min.js",
                      "~/Scripts/respond.js",
                      "~/Scripts/admin.js",
                      "~/Scripts/toastr.min.js",
                      "~/Scripts/Plugins/fileinput.min.js",
                      "~/Scripts/Plugins/xeditable.min.js"
                      ));

            BundleTable.EnableOptimizations = true;

        }
    }
}
