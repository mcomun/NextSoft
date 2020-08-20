// Decompiled with JetBrains decompiler
// Type: Delfin.Controls.Entorno
// Assembly: Delfin.Controls, Version=3.0.1.3, Culture=neutral, PublicKeyToken=null
// MVID: A4BA2B33-0E71-44B0-9838-A6C1CD0C2B15
// Assembly location: C:\Temp\Delfin.Controls.dll

using Delfin.Entities;

namespace Delfin.Controls
{
  public class Entorno
  {
    private Entorno()
    {
    }

    public static Entorno InitializeEntorno(Empresa x_empresa, Sucursales x_sucursal)
    {
      Entorno.Instance = new Entorno();
      Entorno.ItemEmpresa = x_empresa;
      Entorno.ItemSucursal = x_sucursal;
      return Entorno.Instance;
    }

    public static Entorno Instance { get; set; }

    public static Empresa ItemEmpresa { get; set; }

    public static Sucursales ItemSucursal { get; set; }
  }
}
