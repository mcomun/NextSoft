// Decompiled with JetBrains decompiler
// Type: Microsoft.Office.Interop.Word.Table
// Assembly: Delfin.Controls, Version=3.0.1.3, Culture=neutral, PublicKeyToken=null
// MVID: A4BA2B33-0E71-44B0-9838-A6C1CD0C2B15
// Assembly location: C:\Temp\Delfin.Controls.dll

using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Microsoft.Office.Interop.Word
{
  [TypeIdentifier]
  [Guid("00020951-0000-0000-C000-000000000046")]
  [CompilerGenerated]
  [ComImport]
  public interface Table
  {
    [IndexerName("Range")]
    Range this[] { [DispId(0)] [return: MarshalAs(UnmanagedType.Interface)] get; }

    [SpecialName]
    extern void _VtblGap1_3();

    Columns Columns { [DispId(100)] [return: MarshalAs(UnmanagedType.Interface)] get; }

    Rows Rows { [DispId(101)] [return: MarshalAs(UnmanagedType.Interface)] get; }

    Borders Borders { [DispId(1100)] [return: MarshalAs(UnmanagedType.Interface)] get; [DispId(1100)] [param: MarshalAs(UnmanagedType.Interface), In] set; }

    [SpecialName]
    extern void _VtblGap2_11();

    [DispId(17)]
    [return: MarshalAs(UnmanagedType.Interface)]
    Cell Cell([In] int Row, [In] int Column);
  }
}
