using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Delfin.Web.Std
{
   public class RouteConfig
   {
      public static void RegisterRoutes(RouteCollection routes)
      {
         routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

         routes.MapRoute(
                name: "DefaultIngreso",
                url: "ingresoSistema/index/{id}",
                defaults: new { controller = "IngresoSistema", action = "", id = UrlParameter.Optional }
            );

         routes.MapRoute(
             name: "Default",
             url: "{controller}/{action}/{id}",
             defaults: new { controller = "IngresoSistema", action = "Index", id = UrlParameter.Optional }
         );
      }
   }
}