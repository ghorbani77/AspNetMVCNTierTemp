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
                "~/Content/bootstrap-flat.min.css",
                "~/Content/bootstrap-rtl.min.css",
                "~/Content/toastr.min.css",
                "~/Content/plugins/font-awesome.min.css",
                "~/Content/plugins/fileinput.min.css",
                "~/Content/site.min.css"));

            bundles.Add(new StyleBundle("~/Content/admin").Include(
                "~/Content/bootstrap-flat.min.css",
                "~/Content/bootstrap-rtl.min.css",
                "~/Content/toastr.min.css",
                "~/Content/plugins/font-awesome.min.css",
                "~/Content/ionicons.min.css",
                "~/Content/admin/AdminLTE.min.css",
                "~/Content/admin/skins/skin-blue-light.min.css",
                "~/Content/plugins/fileinput.min.css"));

            bundles.Add(new ScriptBundle("~/bundles/admin").Include(
                      "~/Scripts/bootstrap.min.js",
                      "~/Scripts/respond.min.js",
                      "~/Scripts/admin/admin.min.js",
                      "~/Scripts/toastr.min.js",
                      "~/Scripts/plugins/fileinput.min.js",
                     "~/Scripts/admin/app.min.js"
                      ));


            BundleTable.EnableOptimizations = true;

        }
    }
}
