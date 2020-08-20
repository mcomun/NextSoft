using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Delfin.Web.Std.Util.Wrappers;

namespace Delfin.Web.Std.Models
{
   public class IngresoSistemaModel
   {
      public string Usuario { get; set; }

      public string Contrasenia { get; set; }

      public int ValidacionUsuario { get; set; }

      public string RutaPrincipal { get; set; }
   }

   public class LoginAccesResponseAplication
   {
      public string CodigoError { get; set; }

      public string DescripcionError { get; set; }

      public string Usuario { get; set; }

      //public List<ModuloResponse> ListaModulos { get; set; }

      //public List<ClienteResponse> ListaClientes { get; set; }
   }
}