// Decompiled with JetBrains decompiler
// Type: Delfin.Controls.IUbigeoControl
// Assembly: Delfin.Controls, Version=3.0.1.3, Culture=neutral, PublicKeyToken=null
// MVID: A4BA2B33-0E71-44B0-9838-A6C1CD0C2B15
// Assembly location: C:\Temp\Delfin.Controls.dll

namespace Delfin.Controls
{
  public interface IUbigeoControl
  {
    string Titulo { get; set; }

    void LoadComboPaises();

    void LoadComboDepartamento();

    void LoadComboProvincia();

    void LoadComboDistrito();
  }
}
