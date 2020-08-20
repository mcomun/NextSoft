using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Delfin.Web.Std.Util
{
   public class FormatNumberType
   {
      public string NumberDecimalSeparator { get; set; }
      public string NumberGroupSeparator { get; set; }
   }

   public class InfoFormatNumberType
   {
      public string Formato { get; set; }
      public string SeparadorDecimales { get; set; }
      public string SeparadorMiles { get; set; }
   }

   [Serializable]
   public class OpcionEL
   {
      public string Codigo { get; set; }
      public string Descripcion { get; set; }
   }
}