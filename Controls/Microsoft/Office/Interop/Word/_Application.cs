// Decompiled with JetBrains decompiler
// Type: Microsoft.Office.Interop.Word._Application
// Assembly: Delfin.Controls, Version=3.0.1.3, Culture=neutral, PublicKeyToken=null
// MVID: A4BA2B33-0E71-44B0-9838-A6C1CD0C2B15
// Assembly location: C:\Temp\Delfin.Controls.dll

using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Microsoft.Office.Interop.Word
{
  [TypeIdentifier]
  [Guid("00020970-0000-0000-C000-000000000046")]
  [CompilerGenerated]
  [ComImport]
  public interface _Application
  {
    [SpecialName]
    extern void _VtblGap1_4();

    Documents Documents { [DispId(6)] [return: MarshalAs(UnmanagedType.Interface)] get; }

    [SpecialName]
    extern void _VtblGap2_3();

    Selection Selection { [DispId(5)] [return: MarshalAs(UnmanagedType.Interface)] get; }

    [SpecialName]
    extern void _VtblGap3_17();

    bool Visible { [DispId(23)] get; [DispId(23)] [param: In] set; }

    [SpecialName]
    extern void _VtblGap4_85();

    [DispId(1105)]
    void Quit([MarshalAs(UnmanagedType.Struct), In, Optional] ref object SaveChanges, [MarshalAs(UnmanagedType.Struct), In, Optional] ref object OriginalFormat, [MarshalAs(UnmanagedType.Struct), In, Optional] ref object RouteDocument);
  }
}
