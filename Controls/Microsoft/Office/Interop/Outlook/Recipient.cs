// Decompiled with JetBrains decompiler
// Type: Microsoft.Office.Interop.Outlook.Recipient
// Assembly: Delfin.Controls, Version=3.0.1.3, Culture=neutral, PublicKeyToken=null
// MVID: A4BA2B33-0E71-44B0-9838-A6C1CD0C2B15
// Assembly location: C:\Temp\Delfin.Controls.dll

using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Microsoft.Office.Interop.Outlook
{
  [Guid("00063045-0000-0000-C000-000000000046")]
  [CompilerGenerated]
  [TypeIdentifier]
  [ComImport]
  public interface Recipient
  {
    [SpecialName]
    extern void _VtblGap1_19();

    int Type { [DispId(3093)] get; [DispId(3093)] [param: In] set; }

    [SpecialName]
    extern void _VtblGap2_2();

    [DispId(113)]
    bool Resolve();
  }
}
