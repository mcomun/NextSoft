using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Resources;
using System.Web;
using Delfin.Web.Std.Models.Base;
using Delfin.Web.Std.Resources.Shared;
using Delfin.Web.Std.Util;
using Delfin.Web.Std.Util.Wrappers;


namespace Delfin.Web.Std.Models.Context.Base
{
   public class BaseContext
   {
      public static void ObtenerAccesoControl(string id, string resource, Models.Base.ButtonControl button)
      {
         PermisosControl Permisos = ObtenerPermisos(id, resource);
         button.Enabled = Permisos.Enabled;
         button.Visible = Permisos.Visible;
         Permisos = null;
      }

      public static void ObtenerAccesoControl(string id, string resource, Models.Base.LinkControl button)
      {
         PermisosControl Permisos = ObtenerPermisos(id, resource);
         button.Enabled = Permisos.Enabled;
         button.Visible = Permisos.Visible;
         Permisos = null;
      }

      public static void ObtenerAccesoControl(string id, string resource, Models.Base.ImageControl button)
      {
         PermisosControl Permisos = ObtenerPermisos(id, resource);
         button.Enabled = Permisos.Enabled;
         button.Visible = Permisos.Visible;
         Permisos = null;
      }

      public static PermisosControl ObtenerPermisos(string codigoOpcion, string resource)
      {
         return new PermisosControl() { Enabled = true, Visible = true };
      }

      public static bool ValidarAccesoUrl()
      {
         bool resultado = true;
         return resultado;
      }

      //public static string ValidarAlmacenCliente(string codigoCliente)
      //{
      //   string IndicadorAlmacenCliente = null;

      //   WSComex.ComexClient oServicioComex = new WSComex.ComexClient();

      //   try
      //   {
      //      IndicadorAlmacenCliente = oServicioComex.USP_VERIFICAR_ALMACEN_CLIENTE(codigoCliente);
      //   }
      //   catch
      //   {
      //      throw new Exception("Se produjo un Error.");
      //   }
      //   finally
      //   {
      //      oServicioComex.Close();
      //   }

      //   return IndicadorAlmacenCliente;
      //}
   }

   public class PermisosControl
   {
      public bool Enabled { get; set; }
      public bool Visible { get; set; }
   }
}