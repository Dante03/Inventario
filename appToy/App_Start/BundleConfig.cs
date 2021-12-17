using System.Web.Optimization;

namespace appToy
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));
            bundles.Add(new ScriptBundle("~/bundles/vue").Include(
                        "~/Scripts/vue.js"));
            bundles.Add(new ScriptBundle("~/bundles/vueresource").Include(
                        "~/Scripts/vue-resource.js"));
            bundles.Add(new ScriptBundle("~/bundles/vue-data").Include(
                        "~/Scripts/vue-data.js"));
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));
        }
    }
}
