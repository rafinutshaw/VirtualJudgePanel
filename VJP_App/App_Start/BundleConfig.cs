using System.Web;
using System.Web.Optimization;

namespace VJP_App
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {

            //                        Jquery


            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                        "~/Scripts/umd/popper.js",
                        "~/Scripts/bootstrap.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/angular").Include(
                        "~/Scripts/angular.min.js"));



            //                      For Login Page


            bundles.Add(new ScriptBundle("~/bundles/select2").Include(
                      "~/Scripts/select2.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/tilt").Include(
                      "~/Scripts/tilt.jquery.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/Login").Include(
                      "~/Scripts/Login.main.js"));


            //                      For SignUp Page

            bundles.Add(new ScriptBundle("~/bundles/SignUp").Include(
                      "~/Scripts/SignUp/particles.js",
                      "~/Scripts/SignUp/app.js",
                      "~/Scripts/SignUp/stats.js"));



            //                      For Home Page

            bundles.Add(new ScriptBundle("~/bundles/Home").Include(
                      "~/Scripts/Home/web.js"));





            //                      CSS


            //                      Bootstrap

            bundles.Add(new StyleBundle("~/Content/bootstrap").Include(
                     "~/Content/bootstrap.css"));


            bundles.Add(new StyleBundle("~/Content/Site").Include(
                      "~/Content/Site.css"));


            //                      Font Awesome

            bundles.Add(new StyleBundle("~/Content/fontawesome").Include(
                      "~/Content/all.min.css"));



            //                      For Login Page

            bundles.Add(new StyleBundle("~/Content/animate").Include(
                      "~/Content/css/animate/animate.css"));

            bundles.Add(new StyleBundle("~/Content/css-hamburgers").Include(
                      "~/Content/css/css-hamburgers/css-hamburgers.min.css"));

            bundles.Add(new StyleBundle("~/Content/Login").Include(
                      "~/Content/css/Login/main.css",
                      "~/Content/css/Login/util.css"));

            bundles.Add(new StyleBundle("~/Content/select2").Include(
                      "~/Content/css/select2.css"));




            //                      For SignUp Page

            bundles.Add(new StyleBundle("~/Content/SignUp").Include(
                      "~/Content/css/SignUp/style.css"));





            //                      For Home Page

            bundles.Add(new StyleBundle("~/Content/Home").Include(
                      "~/Content/css/Home/normalize.css",
                      "~/Content/css/Home/web.css",
                      "~/Content/css/Home/spproject.css"));
        }
    }
}
