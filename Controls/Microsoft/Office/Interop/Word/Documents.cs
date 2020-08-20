// Decompiled with JetBrains decompiler
// Type: Microsoft.Office.Interop.Word.Documents
// Assembly: Delfin.Controls, Version=3.0.1.3, Culture=neutral, PublicKeyToken=null
// MVID: A4BA2B33-0E71-44B0-9838-A6C1CD0C2B15
// Assembly location: C:\Temp\Delfin.Controls.dll

using System.Collections;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Microsoft.Office.Interop.Word
{
  [TypeIdentifier]
  [Guid("0002096C-0000-0000-C000-000000000046")]
  [CompilerGenerated]
  [ComImport]
  public interface Documents : IEnumerable
  {
    [SpecialName]
    extern void _VtblGap1_15();

    [DispId(19)]
    [return: MarshalAs(UnmanagedType.Interface)]
    Document Open([MarshalAs(UnmanagedType.Struct), In] ref object FileName, [MarshalAs(UnmanagedType.Struct), In, Optional] ref object ConfirmConversions, [MarshalAs(UnmanagedType.Struct), In, Optional] ref object ReadOnly, [MarshalAs(UnmanagedType.Struct), In, Optional] ref object AddToRecentFiles, [MarshalAs(UnmanagedType.Struct), In, Optional] ref object PasswordDocument, [MarshalAs(UnmanagedType.Struct), In, Optional] ref object PasswordTemplate, [MarshalAs(UnmanagedType.Struct), In, Optional] ref object Revert, [MarshalAs(UnmanagedType.Struct), In, Optional] ref object WritePasswordDocument, [MarshalAs(UnmanagedType.Struct), In, Optional] ref object WritePasswordTemplate, [MarshalAs(UnmanagedType.Struct), In, Optional] ref object Format, [MarshalAs(UnmanagedType.Struct), In, Optional] ref object Encoding, [MarshalAs(UnmanagedType.Struct), In, Optional] ref object Visible, [MarshalAs(UnmanagedType.Struct), In, Optional] ref object OpenAndRepair, [MarshalAs(UnmanagedType.Struct), In, Optional] ref object DocumentDirection, [MarshalAs(UnmanagedType.Struct), In, Optional] ref object NoEncodingDialog, [MarshalAs(UnmanagedType.Struct), In, Optional] ref object XMLTransform);
  }
}
