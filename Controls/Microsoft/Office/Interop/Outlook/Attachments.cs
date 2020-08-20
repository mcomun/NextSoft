// Decompiled with JetBrains decompiler
// Type: Microsoft.Office.Interop.Outlook.Attachments
// Assembly: Delfin.Controls, Version=3.0.1.3, Culture=neutral, PublicKeyToken=null
// MVID: A4BA2B33-0E71-44B0-9838-A6C1CD0C2B15
// Assembly location: C:\Temp\Delfin.Controls.dll

using System.Collections;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Microsoft.Office.Interop.Outlook
{
  [Guid("0006303C-0000-0000-C000-000000000046")]
  [CompilerGenerated]
  [TypeIdentifier]
  [ComImport]
  public interface Attachments : IEnumerable
  {
    [SpecialName]
    extern void _VtblGap1_6();

    [DispId(101)]
    [return: MarshalAs(UnmanagedType.Interface)]
    Attachment Add([MarshalAs(UnmanagedType.Struct), In] object Source, [MarshalAs(UnmanagedType.Struct), In, Optional] object Type, [MarshalAs(UnmanagedType.Struct), In, Optional] object Position, [MarshalAs(UnmanagedType.Struct), In, Optional] object DisplayName);
  }
}
