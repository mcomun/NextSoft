// Decompiled with JetBrains decompiler
// Type: Delfin.Controls.GAsientos
// Assembly: Delfin.Controls, Version=3.0.1.3, Culture=neutral, PublicKeyToken=null
// MVID: A4BA2B33-0E71-44B0-9838-A6C1CD0C2B15
// Assembly location: C:\Temp\Delfin.Controls.dll

using System;

namespace Delfin.Controls
{
  public class GAsientos
  {
    public GAsientos.TipoAsiento TAsiento { get; set; }

    public GAsientos(GAsientos.TipoAsiento x_tasiento)
    {
      try
      {
        this.TAsiento = x_tasiento;
      }
      catch (Exception ex)
      {
        throw;
      }
    }

    public bool GenerarAsiento()
    {
      return false;
    }

    public enum TipoAsiento
    {
      AsientoCompra_SLI,
    }
  }
}
