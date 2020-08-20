using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;

namespace Delfin.Web.Std.Util
{
   public class Utilitario
   {
      public static string ConvertFormatDatePresentacion(string formatDateApplication)
      {
         string format = formatDateApplication;
         format = format.Replace("yy", "y");
         format = format.Replace("MM", "mm");
         format = format.Replace("MMMM", "MM");
         return format;
      }

      private static readonly DateTime Jan1st1970 = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

      public static long CurrentTimeMillis()
      {
         return (long)(DateTime.UtcNow - Jan1st1970).TotalMilliseconds;
      }

      public static decimal? StringFormatDecimal(string value)
      {
         string format = Enumerados.ConfiguracionInicial.FormatoDecimal;

         FormatNumberType numberFormat = new FormatNumberType();
         numberFormat.NumberDecimalSeparator = Enumerados.ConfiguracionInicial.NumberDecimalSeparator;
         numberFormat.NumberGroupSeparator = Enumerados.ConfiguracionInicial.NumberGroupSeparator;

         try
         {
            if (!format.Contains("{"))
               format = "{0:" + format + "}";

            NumberFormatInfo numberFormatInfo = new NumberFormatInfo();
            numberFormatInfo.NumberDecimalSeparator = numberFormat.NumberDecimalSeparator;
            numberFormatInfo.NumberGroupSeparator = numberFormat.NumberGroupSeparator;

            return string.IsNullOrEmpty(value) ? (decimal?)null : Decimal.Parse(value, numberFormatInfo);
         }
         catch (FormatException)
         {
            throw new Exception("Formato decimal invalido");
         }
      }
   }
}