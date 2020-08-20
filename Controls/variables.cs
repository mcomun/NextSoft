// Decompiled with JetBrains decompiler
// Type: Delfin.Controls.variables
// Assembly: Delfin.Controls, Version=3.0.1.3, Culture=neutral, PublicKeyToken=null
// MVID: A4BA2B33-0E71-44B0-9838-A6C1CD0C2B15
// Assembly location: C:\Temp\Delfin.Controls.dll

namespace Delfin.Controls
{
  public class variables
  {
    public const string CONSRGM_Importacion = "001";
    public const string CONSRGM_Exportacion = "002";
    public const string CONSLNG_Mandato = "001";
    public const string CONSLNG_Exportacion = "002";
    public const string CONSLNG_SLI = "003";
    public const string CONSLNG_OtrosTraficos = "004";
    public const string CONSVIA_Maritima = "001";
    public const string CONSVIA_Aerea = "002";
    public const string CONSVIA_Terrestre = "003";
    public const string CONSVIA_Fluvial = "004";
    public const string CONSFLE_LCL_LCL = "001";
    public const string CONSFLE_LCL_FCL = "002";
    public const string CONSFLE_FCL_LCL = "003";
    public const string CONSFLE_FCL_FCL = "004";
    public const string CONSBASFIJO = "001";
    public const string CONSBASCONTENEDOR = "002";
    public const string CONSBASTEUS = "003";
    public const string CONSBASPESOVOLUMEN = "004";
    public const short CCOT_TipoCotizacion = 1;
    public const short CCOT_TipoOrdenVenta = 2;
    public const string CCOT_APROCOTIZ1 = "APROCOTIZ1";
    public const string CCOT_APROCOTIZ2 = "APROCOTIZ2";
    public const string CCOT_APROCOTIZ3 = "APROCOTIZ3";
    public const string CCOT_APROCOTIZ4 = "APROCOTIZ4";
    public const string CCOT_ANULCOTIZ = "ANULCOTIZ";
    public const string CCOT_EDITARCOTIZ = "EDITARCOTIZ";
    public const string CCOT_OVCONCLUIDA = "OVCONCLUIDA";
    public const string CCOT_OVDOCUMENTADA = "OVDOCUMENTADA";
    public const string CCOT_OVSOLOLECTURA = "OVSOLOLECTURA";
    public const string CCOT_OVEDITARCOSTO = "OVEDITARCOSTO";
    public const string ENTC_ACCESOFINANZAS = "ACCFINANZAS";
    public const string CCOT_VERCOSTOFCL = "VERCOSTOFCL";
    public const string CONS_ESTCOTINGRESADA = "001";
    public const string CONS_ESTCOTAUTORIZADA = "002";
    public const string CONS_ESTCOTCONFIRMADA = "003";
    public const string CONS_ESTCOTANULADA = "004";
    public const string CONS_ESTOVEINGRESADA = "001";
    public const string CONS_ESTOVECOORDINADA = "002";
    public const string CONS_ESTOVECONFIRMADA = "003";
    public const string CONS_ESTOVECONCLUIDA = "004";
    public const string CONS_ESTOVEANULADA = "005";
    public const string CONS_ESTOVEDOCUMENTADA = "006";
    public const string CONS_ESTOVEPREFACTURADA = "007";
    public const string CONS_ESTOVECERRADA = "008";
    public const string CONS_SERIESLI = "SERIESLI";
    public const string CONS_SERIECALLO = "SERIECALLO";
    public const string TIPOTIP_PAI = "PAI";
    public const string CODIGO_PAISPERU = "179";

    public static string GetSerieFactura(string SUCR_Desc)
    {
      string str = string.Empty;
      switch (SUCR_Desc)
      {
        case "SLI":
          str = "SERIESLI";
          break;
        case "CALLO":
          str = "SERIECALLO";
          break;
      }
      return str;
    }
  }
}
