// Decompiled with JetBrains decompiler
// Type: Delfin.Controls.Utils
// Assembly: Delfin.Controls, Version=3.0.1.3, Culture=neutral, PublicKeyToken=null
// MVID: A4BA2B33-0E71-44B0-9838-A6C1CD0C2B15
// Assembly location: C:\Temp\Delfin.Controls.dll

using System;
using System.Text.RegularExpressions;

namespace Delfin.Controls
{
  public class Utils
  {
    public static string getErrorMsg(Exception ex)
    {
      int startIndex = ex.Message.ToString().IndexOf("#");
      int num = ex.Message.ToString().LastIndexOf("#");
      return startIndex < 0 || num <= 0 ? ex.Message : ex.Message.ToString().Substring(startIndex, num - startIndex);
    }

    public static bool checkMailFormat(string x_mail)
    {
      string pattern = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";
      return Regex.IsMatch(x_mail, pattern) && Regex.Replace(x_mail, pattern, string.Empty).Length == 0;
    }

    public static bool checkMail(string x_nombre, string x_mail, ref string x_mensaje)
    {
      try
      {
        char[] chArray = new char[1]{ ';' };
        if (string.IsNullOrEmpty(x_mail))
        {
          // ISSUE: explicit reference operation
          // ISSUE: variable of a reference type
          string& local = @x_mensaje;
          // ISSUE: explicit reference operation
          // ISSUE: explicit reference operation
          ^local = ^local + string.Format("* La Entidad {0} no tiene Correo Electrónico", (object) x_nombre) + Environment.NewLine;
          return false;
        }
        string[] strArray = x_mail.Split(chArray);
        if (strArray != null && strArray.Length != 0)
        {
          bool flag = true;
          foreach (string str in strArray)
          {
            if (!string.IsNullOrEmpty(str.Trim()) && !Utils.checkMailFormat(str.Trim()))
            {
              // ISSUE: explicit reference operation
              // ISSUE: variable of a reference type
              string& local = @x_mensaje;
              // ISSUE: explicit reference operation
              // ISSUE: explicit reference operation
              ^local = ^local + string.Format("* El correo \"{0}\" de {1} No tiene el Formato Correcto", (object) str.Trim(), (object) x_nombre) + Environment.NewLine;
              flag = false;
            }
          }
          return flag;
        }
        // ISSUE: explicit reference operation
        // ISSUE: variable of a reference type
        string& local1 = @x_mensaje;
        // ISSUE: explicit reference operation
        // ISSUE: explicit reference operation
        ^local1 = ^local1 + string.Format("* La Entidad {0} no tiene Correo Electrónico", (object) x_nombre) + Environment.NewLine;
        return false;
      }
      catch (Exception ex)
      {
        throw;
      }
    }
  }
}
