// Decompiled with JetBrains decompiler
// Type: Microsoft.Office.Interop.Word.Range
// Assembly: Delfin.Controls, Version=3.0.1.3, Culture=neutral, PublicKeyToken=null
// MVID: A4BA2B33-0E71-44B0-9838-A6C1CD0C2B15
// Assembly location: C:\Temp\Delfin.Controls.dll

using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Microsoft.Office.Interop.Word
{
  [Guid("0002095E-0000-0000-C000-000000000046")]
  [CompilerGenerated]
  [TypeIdentifier]
  [ComImport]
  public interface Range
  {
    [IndexerName("Text")]
    string this[] { [DispId(0)] [return: MarshalAs(UnmanagedType.BStr)] get; [DispId(0)] [param: MarshalAs(UnmanagedType.BStr), In] set; }

    [SpecialName]
    extern void _VtblGap1_6();

    Font Font { [DispId(5)] [return: MarshalAs(UnmanagedType.Interface)] get; [DispId(5)] [param: MarshalAs(UnmanagedType.Interface), In] set; }

    [SpecialName]
    extern void _VtblGap2_12();

    Borders Borders { [DispId(1100)] [return: MarshalAs(UnmanagedType.Interface)] get; [DispId(1100)] [param: MarshalAs(UnmanagedType.Interface), In] set; }
  }
}
