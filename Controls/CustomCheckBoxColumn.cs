// Decompiled with JetBrains decompiler
// Type: Delfin.Controls.CustomCheckBoxColumn
// Assembly: Delfin.Controls, Version=3.0.1.3, Culture=neutral, PublicKeyToken=null
// MVID: A4BA2B33-0E71-44B0-9838-A6C1CD0C2B15
// Assembly location: C:\Temp\Delfin.Controls.dll

using System;
using Telerik.WinControls.UI;

namespace Delfin.Controls
{
  public class CustomCheckBoxColumn : GridViewCheckBoxColumn
  {
    public override Type GetCellType(GridViewRowInfo row)
    {
      if (row is GridViewTableHeaderRowInfo)
        return typeof (CheckBoxHeaderCell);
      return base.GetCellType(row);
    }
  }
}
