// Decompiled with JetBrains decompiler
// Type: Microsoft.Office.Interop.Outlook._Application
// Assembly: Delfin.Controls, Version=3.0.1.3, Culture=neutral, PublicKeyToken=null
// MVID: A4BA2B33-0E71-44B0-9838-A6C1CD0C2B15
// Assembly location: C:\Temp\Delfin.Controls.dll

using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Microsoft.Office.Interop.Outlook
{
  [Guid("00063001-0000-0000-C000-000000000046")]
  [CompilerGenerated]
  [TypeIdentifier]
  [ComImport]
  public interface _Application
  {
    [SpecialName]
    extern void _VtblGap1_9();

    [DispId(266)]
    [return: MarshalAs(UnmanagedType.IDispatch)]
    object CreateItem([In] OlItemType ItemType);
  }
}
