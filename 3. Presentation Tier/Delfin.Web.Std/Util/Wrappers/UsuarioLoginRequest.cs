using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Delfin.Web.Std.Util.Wrappers
{
   [Serializable]
   public class UsuarioLoginRequest
   {
      public string Usuario { get; set; }

      public string NombreCompleto { get; set; }

      public int CodigoPais { get; set; }

      public string CodigoMoneda { get; set; }

      public int CodigoUnidadNegocio { get; set; }

      public Guid SessionID { get; set; }

      public string Host { get { return System.Net.Dns.GetHostName(); } }

      public string IP { get; set; }

      public UsuarioLoginRequest()
      {
         this.Usuario = "admin";
         this.NombreCompleto = "Carlos Rios";
         this.CodigoPais = 1;
         this.CodigoUnidadNegocio = 1;
         this.SessionID = Guid.NewGuid();
         this.CodigoMoneda = "PEN";
      }
   }
}