using System.Web;
using System.Web.Optimization;

namespace FytSoa
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // 使用要用于开发和学习的 Modernizr 的开发版本。然后，当你做好
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));

            /* 后台基础  js文件 */
            bundles.Add(new ScriptBundle("~/fytadmin/basejs").Include(
                "~/Content/wwwroot/lib/js/jquery-3.2.1.js",
                "~/Content/wwwroot/lib/js/bootstrap.js",
                "~/Content/wwwroot/lib/js/jquery-ajax.js",
                "~/Content/wwwroot/lib/js/toastr.js",
                "~/Content/wwwroot/select/select2.full.min.js",
                "~/Content/wwwroot/layer/layer.js"));
            #region 后台js
            /* 后台首页菜单  js文件 */
            bundles.Add(new ScriptBundle("~/fytadmin/menujs").Include(
                "~/Content/wwwroot/lib/js/jquery-accordion-menu.js",
                "~/Content/wwwroot/lib/js/multitabs.js"));

            /* 后台首页  js文件 */
            bundles.Add(new ScriptBundle("~/fytadmin/indexjs").Include(
                "~/Content/wwwroot/lib/js/index.js"));

            /* 后台登录  js文件 */
            bundles.Add(new ScriptBundle("~/fytadmin/loginjs").Include(
                "~/Content/wwwroot/lib/js/login.js"));

            /* 后台全局  js文件 */
            bundles.Add(new ScriptBundle("~/fytadmin/public").Include(
                "~/Content/wwwroot/lib/js/fyt-comment.js"));
            /* 百度图标插件  js文件 */
            bundles.Add(new ScriptBundle("~/fytadmin/echarts").Include(
                "~/Content/wwwroot/lib/js/echarts-all.js",
                "~/Content/wwwroot/lib/js/echarts-macarons.js"));
            /* 表单验证插件  js文件 */
            bundles.Add(new ScriptBundle("~/fytadmin/validate").Include(
                "~/Content/wwwroot/lib/js/jquery.validate.js",
                "~/Content/wwwroot/lib/js/messages_zh.js"));
            /* 表格插件  js文件 */
            bundles.Add(new ScriptBundle("~/fytadmin/tablejs").Include(
                "~/Content/wwwroot/table/miniui/miniui.js",
                "~/Content/wwwroot/lib/js/fyt-tab.js"));
            #endregion

            #region  样式表
            /* 后台基础  样式表 */
            bundles.Add(new StyleBundle("~/fytadmin/basecss").Include(
                "~/Content/wwwroot/lib/css/bootstrap.min.css",
                "~/Content/wwwroot/lib/css/font-awesome.min.css",
                "~/Content/wwwroot/lib/css/toastr.css"));

            /* 后台基础  布局表 */
            bundles.Add(new StyleBundle("~/fytadmin/defaults").Include(
                "~/Content/wwwroot/lib/css/bootstrap.min.css",
                "~/Content/wwwroot/lib/css/font-awesome.min.css",
                "~/Content/wwwroot/daterangepicker/daterangepicker.css",
                "~/Content/wwwroot/select/select2.css",
                "~/Content/wwwroot/treeview/bootstrap-treeview.css",
                "~/Content/wwwroot/lib/css/toastr.css"));
            /* 登录  样式表 */
            bundles.Add(new StyleBundle("~/fytadmin/logins").Include(
                "~/Content/wwwroot/lib/css/login.css"));
            /* 后台首页  菜单 */
            bundles.Add(new StyleBundle("~/fytadmin/menucss").Include(
                "~/Content/wwwroot/lib/css/jquery-accordion-menu.css",
                "~/Content/wwwroot/lib/css/style-tab.css"));
            /* 后台全局样式表 */
            bundles.Add(new StyleBundle("~/fytadmin/styles").Include(
                "~/Content/wwwroot/lib/css/style.css"));
            /* 表格插件样式表 */
            bundles.Add(new StyleBundle("~/fytadmin/tablecss").Include(
                "~/Content/wwwroot/table/miniui/themes/default/miniui.css",
                "~/Content/wwwroot/table/miniui/themes/pure/skin.css",
                "~/Content/wwwroot/table/miniui/themes/icons.css"));
            #endregion
        }
    }
}
