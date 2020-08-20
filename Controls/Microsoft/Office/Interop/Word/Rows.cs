// Decompiled with JetBrains decompiler
// Type: Microsoft.Office.Interop.Word.Rows
// Assembly: Delfin.Controls, Version=3.0.1.3, Culture=neutral, PublicKeyToken=null
// MVID: A4BA2B33-0E71-44B0-9838-A6C1CD0C2B15
// Assembly location: C:\Temp\Delfin.Controls.dll

using System.Collections;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Microsoft.Office.Interop.Word
{
  [Guid("0002094C-0000-0000-C000-000000000046")]
  [TypeIdentifier]
  [CompilerGenerated]
  [ComImport]
  public interface Rows : IEnumerable
  {
    [SpecialName]
    extern void _VtblGap1_4();

    WdRowAlignment Alignment { [DispId(4)] get; [DispId(4)] [param: In] set; }

    [SpecialName]
    extern void _VtblGap2_19();

    [DispId(100)]
    [return: MarshalAs(UnmanagedType.Interface)]
    Row Add([MarshalAs(UnmanagedType.Struct), In, Optional] ref object BeforeRow);
  }
}
