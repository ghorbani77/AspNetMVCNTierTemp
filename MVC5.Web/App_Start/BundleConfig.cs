using System.Collections.Generic;
using System.Web.Optimization;

namespace MVC5.Web
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js",
                        "~/Scripts/jquery.unobtrusive-ajax.min.js"));

            var jqueryVal = new ScriptBundle("~/bundles/jqueryval").Include(
                "~/Scripts/jqueryval-default.min.js")
                .Include("~/Scripts/jquery.validate*"
                );
            jqueryVal.Orderer = new NonOrderingBundleOrderer();
            bundles.Add(jqueryVal);

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
                "~/Content/site.min.css",
                "~/Content/PagedList.min.css"));

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
    class NonOrderingBundleOrderer : IBundleOrderer
    {
        public IEnumerable<BundleFile> OrderFiles(BundleContext context, IEnumerable<BundleFile> files)
        {
            return files;
        }
    }
}
