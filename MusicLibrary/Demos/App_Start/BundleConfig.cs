using System.Web;
using System.Web.Optimization;

namespace Demos
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                        /*** Make sure popper.js is pointing to umd ***/
                        "~/Scripts/umd/popper.js",
                        "~/Scripts/bootstrap.js"
                        ));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/fontastic.css",
                      "~/Content/style.default.css",
                      "~/Content/site.css"));

            bundles.Add(new ScriptBundle("~/Scrpts/Bootstrap").Include(
                             /*** Make sure popper.js is pointing to umd ***/
                             "~/Scripts/umd/popper.js",
                             "~/Scripts/bootstrap.js",
                             "~/Scripts/charts-home.js",
                             "~/Scripts/front.js"
                             ));
        }
    }
}
