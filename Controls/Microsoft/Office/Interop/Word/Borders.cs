﻿// Decompiled with JetBrains decompiler
// Type: Microsoft.Office.Interop.Word.Borders
// Assembly: Delfin.Controls, Version=3.0.1.3, Culture=neutral, PublicKeyToken=null
// MVID: A4BA2B33-0E71-44B0-9838-A6C1CD0C2B15
// Assembly location: C:\Temp\Delfin.Controls.dll

using System.Collections;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Microsoft.Office.Interop.Word
{
  [CompilerGenerated]
  [TypeIdentifier]
  [Guid("0002093C-0000-0000-C000-000000000046")]
  [ComImport]
  public interface Borders : IEnumerable
  {
    [SpecialName]
    extern void _VtblGap1_5();

    int Enable { [DispId(2)] get; [DispId(2)] [param: In] set; }

    [SpecialName]
    extern void _VtblGap2_38();

    Border this[[In] WdBorderType Index] { [DispId(0)] [return: MarshalAs(UnmanagedType.Interface)] get; }
  }
}
