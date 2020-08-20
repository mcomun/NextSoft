using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.Linq;
using System.Web;
using Delfin.Web.Std.Resources.Shared;
using Delfin.Web.Std.Util.Wrappers;

namespace Delfin.Web.Std.Util
{
   public static class Common
   {
      public static string CodigoIdentificacionSistema = ConfigurationManager.AppSettings["CodigoIdentificacionSistema"];

      public static string IdiomaInicial = ConfigurationManager.AppSettings["IdiomaInicial"];

      public static string DistribucionSession = "DistribucionSession";

      public static string CookieName = ConfigurationManager.AppSettings["CookieName"];

      public static int CookieExpirationTime = Convert.ToInt32(ConfigurationManager.AppSettings["CookieExpirationTimeHr"]);
   }

   [Serializable]
   public class DistribucionSession
   {
      public DistribucionSession()
      {

      }

      public string usuario { get; set; }

      public UsuarioLoginRequest UsuarioLogin { get; set; }

      public List<ModuloResponse> ModuloLogin { get; set; }

      public List<ClienteResponse> ClientesLogin { get; set; }
   }
}