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
                "~/Scripts/respond.min.js",
                "~/Scripts/plugins/fileinput.min.js",
                "~/Scripts/toastr.min.js",
                "~/Scripts/site.min.js"
                ));

            bundles.Add(new StyleBundle("~/Content/css").Include(
              "~/Content/customBootstrap.min.css",
                "~/Content/toastr.min.css",
                "~/Content/plugins/font-awesome.min.css",
                "~/Content/plugins/fileinput.min.css",
                "~/Content/site.min.css"));

            bundles.Add(new StyleBundle("~/Content/adminCss").Include(
                "~/Content/customBootstrap.min.css",
                "~/Content/toastr.min.css",
                "~/Content/plugins/font-awesome.min.css",
                "~/Content/ionicons.min.css",
                 "~/Content/site.min.css",
                "~/Content/plugins/fileinput.min.css"));

            bundles.Add(new ScriptBundle("~/bundles/adminJs").Include(
                "~/Scripts/bootstrap.min.js",
                "~/Scripts/respond.min.js",
                "~/Scripts/toastr.min.js",
                "~/Scripts/plugins/fileinput.min.js",
                "~/Scripts/site.min.js"
                ));


            BundleTable.EnableOptimizations = true;

        }
    }
}
