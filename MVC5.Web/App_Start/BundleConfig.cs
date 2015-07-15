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
                      "~/Scripts/angular.min.js",
                      "~/Scripts/angular-route.min.js",
                      "~/Scripts/angular-animate.min.js",
                      "~/Scripts/angular-cookies.min.js",
                      "~/Scripts/angular-loader.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/angular").Include(
                     "~/Scripts/bootstrap.min.js",
                     "~/Scripts/site.min.js",
                     "~/Scripts/respond.min.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.min.css",
                      "~/Content/Plugins/font-awesome.min.css",
                      "~/Content/site.min.css"));

            bundles.Add(new StyleBundle("~/Content/admin").Include(
                "~/Content/Plugins/xeditable.min.css",
                "~/Content/bootstrap.min.css",
                "~/Content/toastr.min.css",
                "~/Content/Plugins/font-awesome.min.css",
                "~/Content/Plugins/animate.min.css",
                "~/Content/Plugins/fileinput.min.css",
                "~/Content/Plugins/font-awesome.min.css"));

            bundles.Add(new ScriptBundle("~/bundles/admin").Include(
                      "~/Scripts/bootstrap.min.js",
                      "~/Scripts/respond.min.js",
                      "~/Scripts/admin.js",
                      "~/Scripts/toastr.min.js",
                      "~/Scripts/Plugins/fileinput.min.js",
                      "~/Scripts/Plugins/xeditable.min.js"
                      ));

            BundleTable.EnableOptimizations = true;

        }
    }
}
