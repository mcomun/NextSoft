// Decompiled with JetBrains decompiler
// Type: Delfin.Controls.GenerarTxt
// Assembly: Delfin.Controls, Version=3.0.1.3, Culture=neutral, PublicKeyToken=null
// MVID: A4BA2B33-0E71-44B0-9838-A6C1CD0C2B15
// Assembly location: C:\Temp\Delfin.Controls.dll

using System;
using System.Drawing;
using System.Text;

namespace Delfin.Controls
{
  public class GenerarTxt
  {
    public int[] Columnas { get; set; }

    public ContentAlignment[] Alineaciones { get; set; }

    public string[] Formatos { get; set; }

    public GenerarTxt.TipoDato[] TiposDeDatos { get; set; }

    public char[] Rellenos { get; set; }

    public int Registros { get; set; }

    public StringBuilder Archivo { get; set; }

    public string Formato { get; set; }

    public GenerarTxt()
    {
      try
      {
        this.Archivo = new StringBuilder();
        this.Registros = 0;
      }
      catch (Exception ex)
      {
      }
    }

    public void Add(string[] Linea, GenerarTxt.TipoRegistro x_opcion, GenerarTxt.SaltoLinea x_salto = GenerarTxt.SaltoLinea.Si)
    {
      try
      {
        int index = 0;
        string str1 = "";
        foreach (string s in Linea)
        {
          string str2 = "";
          Decimal result1 = new Decimal(0);
          int result2 = 0;
          switch (this.Alineaciones[index])
          {
            case ContentAlignment.MiddleLeft:
              switch (this.TiposDeDatos[index])
              {
                case GenerarTxt.TipoDato.Caracter:
                  str2 = s.Length <= this.Columnas[index] ? s.PadRight(this.Columnas[index], this.Rellenos[index]) : s.Substring(0, this.Columnas[index]);
                  break;
                case GenerarTxt.TipoDato.Numerico:
                  if (int.TryParse(s, out result2))
                    s = string.Format("{0:##########0}", (object) result2.ToString());
                  str2 = s.PadRight(this.Columnas[index], this.Rellenos[index]);
                  break;
                case GenerarTxt.TipoDato.Decimal:
                  if (Decimal.TryParse(s, out result1))
                  {
                    result1 = Math.Truncate(result1 * new Decimal(100));
                    s = string.Format("{0:##########0}", (object) result1.ToString());
                  }
                  str2 = s.PadRight(this.Columnas[index], this.Rellenos[index]);
                  break;
                case GenerarTxt.TipoDato.DecimalPunto:
                  if (Decimal.TryParse(s, out result1))
                    s = string.Format("{0}", (object) result1.ToString(this.Formato == null ? "#.00" : this.Formato));
                  str2 = s.PadRight(this.Columnas[index], this.Rellenos[index]);
                  break;
              }
            case ContentAlignment.MiddleRight:
              switch (this.TiposDeDatos[index])
              {
                case GenerarTxt.TipoDato.Caracter:
                  str2 = s.Length <= this.Columnas[index] ? s.PadLeft(this.Columnas[index], this.Rellenos[index]) : s.Substring(0, this.Columnas[index]);
                  break;
                case GenerarTxt.TipoDato.Numerico:
                  if (int.TryParse(s, out result2))
                    s = string.Format("{0:##########0}", (object) result2.ToString());
                  str2 = s.PadLeft(this.Columnas[index], this.Rellenos[index]);
                  break;
                case GenerarTxt.TipoDato.Decimal:
                  if (Decimal.TryParse(s, out result1))
                  {
                    result1 = Math.Truncate(result1 * new Decimal(100));
                    s = string.Format("{0:##########0}", (object) result1.ToString());
                  }
                  str2 = s.PadLeft(this.Columnas[index], this.Rellenos[index]);
                  break;
                case GenerarTxt.TipoDato.DecimalPunto:
                  if (Decimal.TryParse(s, out result1))
                    s = string.Format("{0}", (object) result1.ToString(this.Formato == null ? "#.00" : this.Formato));
                  str2 = s.PadLeft(this.Columnas[index], this.Rellenos[index]);
                  break;
              }
          }
          str1 += string.Format("{0}", (object) str2);
          ++index;
        }
        ++this.Registros;
        if (x_salto == GenerarTxt.SaltoLinea.Si)
        {
          this.Archivo.AppendLine(str1);
        }
        else
        {
          if (x_salto != GenerarTxt.SaltoLinea.No)
            return;
          this.Archivo.Append(str1);
        }
      }
      catch (Exception ex)
      {
        throw;
      }
    }

    public enum TipoRegistro
    {
      Cabecera,
      Registro,
    }

    public enum TipoDato
    {
      Caracter,
      Numerico,
      Decimal,
      DecimalPunto,
    }

    public enum SaltoLinea
    {
      Si,
      No,
    }
  }
}
