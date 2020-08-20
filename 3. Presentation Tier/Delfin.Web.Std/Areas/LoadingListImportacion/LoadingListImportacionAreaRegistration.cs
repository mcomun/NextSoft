using System.Web.Mvc;

namespace Delfin.Web.Std.Areas.LoadingListImportacion
{
   public class LoadingListImportacionAreaRegistration : AreaRegistration
   {
      public override string AreaName
      {
         get
         {
            return "LoadingListImportacion";
         }
      }

      public override void RegisterArea(AreaRegistrationContext context)
      {
         context.MapRoute(
             "LoadingListImportacion_default",
             "LoadingListImportacion/{controller}/{action}/{id}",
             new { action = "Index", id = UrlParameter.Optional }
         );
      }
   }
}
