// Decompiled with JetBrains decompiler
// Type: Delfin.Controls.Utilitarios
// Assembly: Delfin.Controls, Version=3.0.1.3, Culture=neutral, PublicKeyToken=null
// MVID: A4BA2B33-0E71-44B0-9838-A6C1CD0C2B15
// Assembly location: C:\Temp\Delfin.Controls.dll

using System;
using System.IO;
using System.Text;

namespace Delfin.Controls
{
  public class Utilitarios
  {
    public static string NumberToText(Decimal value)
    {
      Decimal num1 = value;
      value = Math.Truncate(value);
      Decimal num2 = num1 - value;
      string str;
      if (value == new Decimal(0))
        str = "Cero";
      else if (value == new Decimal(1))
        str = "Uno";
      else if (value == new Decimal(2))
        str = "Dos";
      else if (value == new Decimal(3))
        str = "Tres";
      else if (value == new Decimal(4))
        str = "Cuatro";
      else if (value == new Decimal(5))
        str = "Cinco";
      else if (value == new Decimal(6))
        str = "Seis";
      else if (value == new Decimal(7))
        str = "Siete";
      else if (value == new Decimal(8))
        str = "Ocho";
      else if (value == new Decimal(9))
        str = "Nueve";
      else if (value == new Decimal(10))
        str = "Diez";
      else if (value == new Decimal(11))
        str = "Once";
      else if (value == new Decimal(12))
        str = "Doce";
      else if (value == new Decimal(13))
        str = "Trece";
      else if (value == new Decimal(14))
        str = "Catorce";
      else if (value == new Decimal(15))
        str = "Quince";
      else if (value < new Decimal(20))
        str = "Dieci" + Utilitarios.NumberToText(value - new Decimal(10));
      else if (value == new Decimal(20))
        str = "Veinte";
      else if (value < new Decimal(30))
        str = "Veinti" + Utilitarios.NumberToText(value - new Decimal(20));
      else if (value == new Decimal(30))
        str = "Treinta";
      else if (value == new Decimal(40))
        str = "Cuarenta";
      else if (value == new Decimal(50))
        str = "Cincuenta";
      else if (value == new Decimal(60))
        str = "Sesenta";
      else if (value == new Decimal(70))
        str = "Setenta";
      else if (value == new Decimal(80))
        str = "Ochenta";
      else if (value == new Decimal(90))
        str = "Noventa";
      else if (value < new Decimal(100))
        str = Utilitarios.NumberToText(Math.Truncate(value / new Decimal(10)) * new Decimal(10)) + " y " + Utilitarios.NumberToText(value % new Decimal(10));
      else if (value == new Decimal(100))
        str = "Cien";
      else if (value < new Decimal(200))
        str = "Ciento " + Utilitarios.NumberToText(value - new Decimal(100));
      else if (value == new Decimal(200) || value == new Decimal(300) || (value == new Decimal(400) || value == new Decimal(600)) || value == new Decimal(800))
        str = Utilitarios.NumberToText(Math.Truncate(value / new Decimal(100))) + "Cientos";
      else if (value == new Decimal(500))
        str = "Quinientos";
      else if (value == new Decimal(700))
        str = "Setecientos";
      else if (value == new Decimal(900))
        str = "Novecientos";
      else if (value < new Decimal(1000))
        str = Utilitarios.NumberToText(Math.Truncate(value / new Decimal(100)) * new Decimal(100)) + " " + Utilitarios.NumberToText(value % new Decimal(100));
      else if (value == new Decimal(1000))
        str = "Mil";
      else if (value < new Decimal(2000))
        str = "Mil " + Utilitarios.NumberToText(value % new Decimal(1000));
      else if (value < new Decimal(1000000))
      {
        str = Utilitarios.NumberToText(Math.Truncate(value / new Decimal(1000))) + " Mil";
        if (value % new Decimal(1000) > new Decimal(0))
          str = str + " " + Utilitarios.NumberToText(value % new Decimal(1000));
      }
      else if (value == new Decimal(1000000))
        str = "Un Millón";
      else if (value < new Decimal(2000000))
        str = "Un Millón " + Utilitarios.NumberToText(value % new Decimal(1000000));
      else if (value < new Decimal(1000000000000L))
      {
        str = Utilitarios.NumberToText(Math.Truncate(value / new Decimal(1000000))) + " Millones ";
        if (value - Math.Truncate(value / new Decimal(1000000)) * new Decimal(1000000) > new Decimal(0))
          str = str + " " + Utilitarios.NumberToText(value - Math.Truncate(value / new Decimal(1000000)) * new Decimal(1000000));
      }
      else if (value == new Decimal(1000000000000L))
        str = "Un Billón";
      else if (value < new Decimal(2000000000000L))
      {
        str = "Un Billón " + Utilitarios.NumberToText(value - Math.Truncate(value / new Decimal(1000000000000L)) * new Decimal(1000000000000L));
      }
      else
      {
        str = Utilitarios.NumberToText(Math.Truncate(value / new Decimal(1000000000000L))) + " Billones";
        if (value - Math.Truncate(value / new Decimal(1000000000000L)) * new Decimal(1000000000000L) > new Decimal(0))
          str = str + " " + Utilitarios.NumberToText(value - Math.Truncate(value / new Decimal(1000000000000L)) * new Decimal(1000000000000L));
      }
      return str;
    }

    public static string NumeroALetras(string num, string x_moneda)
    {
      double d;
      try
      {
        d = Convert.ToDouble(num);
      }
      catch
      {
        return "";
      }
      long int64 = Convert.ToInt64(Math.Truncate(d));
      string str1 = " CON " + Convert.ToInt32(Math.Abs(Math.Round((d - (double) int64) * 100.0, 2))).ToString("00") + "/100";
      string str2 = Utilitarios.NumeroALetras(Convert.ToDouble(int64)) + str1 + " " + x_moneda;
      if (Convert.ToDouble(int64) < 0.0)
        return "(" + str2 + ")";
      return str2;
    }

    private static string NumeroALetras(double value)
    {
      value = Math.Abs(value);
      value = Math.Truncate(value);
      string str;
      if (value == 0.0)
        str = "CERO";
      else if (value == 1.0)
        str = "UNO";
      else if (value == 2.0)
        str = "DOS";
      else if (value == 3.0)
        str = "TRES";
      else if (value == 4.0)
        str = "CUATRO";
      else if (value == 5.0)
        str = "CINCO";
      else if (value == 6.0)
        str = "SEIS";
      else if (value == 7.0)
        str = "SIETE";
      else if (value == 8.0)
        str = "OCHO";
      else if (value == 9.0)
        str = "NUEVE";
      else if (value == 10.0)
        str = "DIEZ";
      else if (value == 11.0)
        str = "ONCE";
      else if (value == 12.0)
        str = "DOCE";
      else if (value == 13.0)
        str = "TRECE";
      else if (value == 14.0)
        str = "CATORCE";
      else if (value == 15.0)
        str = "QUINCE";
      else if (value < 20.0)
        str = "DIECI" + Utilitarios.NumeroALetras(value - 10.0);
      else if (value == 20.0)
        str = "VEINTE";
      else if (value < 30.0)
        str = "VEINTI" + Utilitarios.NumeroALetras(value - 20.0);
      else if (value == 30.0)
        str = "TREINTA";
      else if (value == 40.0)
        str = "CUARENTA";
      else if (value == 50.0)
        str = "CINCUENTA";
      else if (value == 60.0)
        str = "SESENTA";
      else if (value == 70.0)
        str = "SETENTA";
      else if (value == 80.0)
        str = "OCHENTA";
      else if (value == 90.0)
        str = "NOVENTA";
      else if (value < 100.0)
        str = Utilitarios.NumeroALetras(Math.Truncate(value / 10.0) * 10.0) + " Y " + Utilitarios.NumeroALetras(value % 10.0);
      else if (value == 100.0)
        str = "CIEN";
      else if (value < 200.0)
        str = "CIENTO " + Utilitarios.NumeroALetras(value - 100.0);
      else if (value == 200.0 || value == 300.0 || (value == 400.0 || value == 600.0) || value == 800.0)
        str = Utilitarios.NumeroALetras(Math.Truncate(value / 100.0)) + "CIENTOS";
      else if (value == 500.0)
        str = "QUINIENTOS";
      else if (value == 700.0)
        str = "SETECIENTOS";
      else if (value == 900.0)
        str = "NOVECIENTOS";
      else if (value < 1000.0)
        str = Utilitarios.NumeroALetras(Math.Truncate(value / 100.0) * 100.0) + " " + Utilitarios.NumeroALetras(value % 100.0);
      else if (value == 1000.0)
        str = "MIL";
      else if (value < 2000.0)
        str = "MIL " + Utilitarios.NumeroALetras(value % 1000.0);
      else if (value < 1000000.0)
      {
        str = Utilitarios.NumeroALetras(Math.Truncate(value / 1000.0)) + " MIL";
        if (value % 1000.0 > 0.0)
          str = str + " " + Utilitarios.NumeroALetras(value % 1000.0);
      }
      else if (value == 1000000.0)
        str = "UN MILLON";
      else if (value < 2000000.0)
        str = "UN MILLON " + Utilitarios.NumeroALetras(value % 1000000.0);
      else if (value < 1000000000000.0)
      {
        str = Utilitarios.NumeroALetras(Math.Truncate(value / 1000000.0)) + " MILLONES ";
        if (value - Math.Truncate(value / 1000000.0) * 1000000.0 > 0.0)
          str = str + " " + Utilitarios.NumeroALetras(value - Math.Truncate(value / 1000000.0) * 1000000.0);
      }
      else if (value == 1000000000000.0)
        str = "UN BILLON";
      else if (value < 2000000000000.0)
      {
        str = "UN BILLON " + Utilitarios.NumeroALetras(value - Math.Truncate(value / 1000000000000.0) * 1000000000000.0);
      }
      else
      {
        str = Utilitarios.NumeroALetras(Math.Truncate(value / 1000000000000.0)) + " BILLONES";
        if (value - Math.Truncate(value / 1000000000000.0) * 1000000000000.0 > 0.0)
          str = str + " " + Utilitarios.NumeroALetras(value - Math.Truncate(value / 1000000000000.0) * 1000000000000.0);
      }
      return str;
    }

    public static void SaveFile(string x_ruta, object _codificacion, StringBuilder m_file)
    {
      if (_codificacion == null)
        _codificacion = (object) "0000";
      if (File.Exists(x_ruta))
      {
        File.SetAttributes(x_ruta, FileAttributes.Normal);
        File.Delete(x_ruta);
      }
      if (_codificacion != null)
      {
        if (_codificacion.ToString() == "0000")
        {
          using (StreamWriter streamWriter = new StreamWriter(x_ruta, true))
          {
            streamWriter.WriteLine(m_file.ToString());
            return;
          }
        }
      }
      try
      {
        int int32 = Convert.ToInt32(_codificacion);
        using (StreamWriter streamWriter = new StreamWriter(x_ruta, true, Encoding.GetEncoding(int32)))
          streamWriter.WriteLine(m_file.ToString());
      }
      catch (Exception ex)
      {
        using (StreamWriter streamWriter = new StreamWriter(x_ruta, true, Encoding.GetEncoding(_codificacion.ToString())))
          streamWriter.WriteLine(m_file.ToString());
      }
    }

    public static void SaveFileSinSalto(string x_ruta, object _codificacion, StringBuilder m_file)
    {
      if (_codificacion == null)
        _codificacion = (object) "0000";
      if (File.Exists(x_ruta))
      {
        File.SetAttributes(x_ruta, FileAttributes.Normal);
        File.Delete(x_ruta);
      }
      if (_codificacion != null)
      {
        if (_codificacion.ToString() == "0000")
        {
          using (StreamWriter streamWriter = new StreamWriter(x_ruta, true))
          {
            streamWriter.Write(m_file.ToString());
            return;
          }
        }
      }
      try
      {
        int int32 = Convert.ToInt32(_codificacion);
        using (StreamWriter streamWriter = new StreamWriter(x_ruta, true, Encoding.GetEncoding(int32)))
          streamWriter.Write(m_file.ToString());
      }
      catch (Exception ex)
      {
        using (StreamWriter streamWriter = new StreamWriter(x_ruta, true, Encoding.GetEncoding(_codificacion.ToString())))
          streamWriter.Write(m_file.ToString());
      }
    }
  }
}
