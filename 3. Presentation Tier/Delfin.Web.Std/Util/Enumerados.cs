using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Delfin.Web.Std.Util
{
   public class Enumerados
   {
      public struct ConfiguracionInicial
      {
         public const string CodigoIdioma = "ES-PE";
         public const string CodigoIdiomaDatePicker = "es";
         public const string FormatoFecha = "dd/MM/yyyy";
         public const string FormatoFechaHora = "dd/MM/yyyy HH:mm:ss";
         public const string FormatoHoraCorta = "hh:mm tt";
         public const string FormatoHoraLarga = "hh:mm:ss tt";
         public const string FormatoNumerico = "{0:###,###,##0}";
         public const string FormatoDecimal = "{0:###,###,##0.0000}";
         public const string FormatoPorcentaje = "{0:##,###,##0.00 %}";
         public const string FormatoEnteroSeparadorMiles = ",";
         public const string FormatoDecimalSeparadorDecimales = ".";
         public const string FormatoDecimalSeparadorMiles = ",";

         public const string NumberDecimalSeparator = ".";
         public const string NumberGroupSeparator = ",";

         public const string FormaMenu = "0";
         public const string FilasPorPagina = "10";

         public const bool CambiarMes = true;
         public const bool CambiarAnio = true;
         public const bool AutoCerrarDP = true;
      }

      public struct EstadoRegistro
      {
         public const string CodigoActivo = "1";
         public const string NombreActivo = "Activo";
         public const string CodigoInactivo = "0";
         public const string NombreInactivo = "Inactivo";
      }

      public struct TipoCarga
      {
         public const string CodigoFCL = "C";
         public const string NombreFCL = "FCL Contenedores";
         public const string CodigoLCL = "S";
         public const string NombreLCL = "LCL Carga Suelta";
      }

      public struct BDQueryTypes
      {
         public const string TIPO_CARGA = "01";
         public const string COD_ITEM = "02";
         public const string REPORTE_INDICADORES = "03";
      }
   }
}