using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace SandysBakery.App_Start
{
    public class BundleConfig
    {
        // For more information on Bundling, visit https://go.microsoft.com/fwlink/?LinkID=303951
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/WebFormsJs").Include(
                            "~/Scripts/WebForms/WebForms.js",
                            "~/Scripts/WebForms/WebUIValidation.js",
                            "~/Scripts/WebForms/MenuStandards.js",
                            "~/Scripts/WebForms/Focus.js",
                            "~/Scripts/WebForms/GridView.js",
                            "~/Scripts/WebForms/DetailsView.js",
                            "~/Scripts/WebForms/TreeView.js",
                            "~/Scripts/WebForms/WebParts.js"));

            bundles.Add(new ScriptBundle("~/bundles/Global").Include(
                            "~/vendor/jquery/jquery.min.js",
                            "~/vendor/bootstrap/js/bootstrap.bundle.min.js",
                            "~/vendor/jquery-easing/jquery.easing.min.js",
                            "~/Scripts/js/sb-admin-2.js"));

            // Order is very important for these files to work, they have explicit dependencies
            bundles.Add(new ScriptBundle("~/bundles/MsAjaxJs").Include(
                 "~/Scripts/WebForms/MsAjax/MicrosoftAjax.js",
                 "~/Scripts/WebForms/MsAjax/MicrosoftAjaxApplicationServices.js",
                 "~/Scripts/WebForms/MsAjax/MicrosoftAjaxTimer.js",
                 "~/Scripts/WebForms/MsAjax/MicrosoftAjaxWebForms.js"));

            // Use the Development version of Modernizr to develop with and learn from. Then, when you’re
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                            "~/Scripts/modernizr-*"));

            bundles.Add(new StyleBundle("~/Content/Global").Include(
                            "~/vendor/fontawesome-free/css/all.min.css",
                            "~/Content/css/sb-admin-2.min.css"));

        }
    }
}