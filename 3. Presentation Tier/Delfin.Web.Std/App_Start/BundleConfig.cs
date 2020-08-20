using System.Web;
using System.Web.Optimization;

namespace Delfin.Web.Std
{
   public class BundleConfig
   {
      // Para obtener más información acerca de Bundling, consulte http://go.microsoft.com/fwlink/?LinkId=254725
      public static void RegisterBundles(BundleCollection bundles)
      {
         bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                     "~/Scripts/JQuery/jquery-{version}.js",
                     "~/Scripts/JQuery/jquery.browser.js",
                     "~/Scripts/JQuery/bootstrap.js",
                     "~/Scripts/JQuery/app.js",
                     "~/Scripts/JQuery/jquery.event.drag-2.2.js"));

         bundles.Add(new ScriptBundle("~/bundles/jqueryui").Include(
                     "~/Scripts/JQuery/jquery-ui-{version}.js"));

         bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                     "~/Scripts/JQuery/jquery.validate*"));

         /* Knockout */
         bundles.Add(new ScriptBundle("~/bundles/knockout").Include(
                     "~/Scripts/Knockout/knockout-2.1.0.js"));
         
         // Utilice la versión de desarrollo de Modernizr para desarrollar y obtener información sobre los formularios. De este modo, estará
         // preparado para la producción y podrá utilizar la herramienta de creación disponible en http://modernizr.com para seleccionar solo las pruebas que necesite.
         bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                     "~/Scripts/modernizr-*"));

         bundles.Add(new StyleBundle("~/Content/css").Include(
                     "~/Content/jquery-ui-1.10.4.css",
                     "~/Content/bootstrap.css",
                     "~/Content/app.css",
                     "~/Content/font-awesome.min.css",
                     "~/Content/font-awesome.css",
                     "~/Content/font.css"));

         /*Componentes Personalizados*/
         bundles.Add(new ScriptBundle("~/bundles/components").Include(
                     "~/Scripts/ns.js",
                     "~/Scripts/Components/ProgressBar/ProgressBar.js",
                     "~/Scripts/Components/AjaxUtil/AjaxUtil.js",
                     "~/Scripts/Components/Validator/Validator.js",
                     "~/Scripts/Components/Dialog/Dialog.js",
                     "~/Scripts/Components/Calendar/Calendar.js",
                     "~/Scripts/Components/Calendar/bootstrap-datepicker.js",
                     "~/Scripts/Components/Calendar/bootstrap-datepicker.es.js",
                     "~/Scripts/Components/Message/Message.js",
                     "~/Scripts/Components/TextBox/TextBox.js",
                     "~/Scripts/master.js",
                     "~/Scripts/Components/Grid/Grid.js",
                     "~/Scripts/Components/Grid/SlickGrid/firebugx.js",
                     "~/Scripts/Components/Grid/SlickGrid/slick.*"
                     ));

         bundles.Add(new StyleBundle("~/components/css").Include(
                        "~/Scripts/Components/ProgressBar/ProgressBar.css",
                        "~/Scripts/Components/Calendar/css/datepicker3.css",
                        "~/Scripts/Components/Dialog/Dialog.css",
                        "~/Scripts/Components/Message/Message.css",
                        "~/Scripts/Components/Grid/Grid.css"
                        ));

         bundles.Add(new StyleBundle("~/Content/themes/base/css").Include(
                     "~/Content/themes/base/jquery.ui.core.css",
                     "~/Content/themes/base/jquery.ui.resizable.css",
                     "~/Content/themes/base/jquery.ui.selectable.css",
                     "~/Content/themes/base/jquery.ui.accordion.css",
                     "~/Content/themes/base/jquery.ui.autocomplete.css",
                     "~/Content/themes/base/jquery.ui.button.css",
                     "~/Content/themes/base/jquery.ui.dialog.css",
                     "~/Content/themes/base/jquery.ui.slider.css",
                     "~/Content/themes/base/jquery.ui.tabs.css",
                     "~/Content/themes/base/jquery.ui.datepicker.css",
                     "~/Content/themes/base/jquery.ui.progressbar.css",
                     "~/Content/themes/base/jquery.ui.theme.css"));
      }
   }
}