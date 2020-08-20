// Decompiled with JetBrains decompiler
// Type: Microsoft.Office.Interop.Outlook._MailItem
// Assembly: Delfin.Controls, Version=3.0.1.3, Culture=neutral, PublicKeyToken=null
// MVID: A4BA2B33-0E71-44B0-9838-A6C1CD0C2B15
// Assembly location: C:\Temp\Delfin.Controls.dll

using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Microsoft.Office.Interop.Outlook
{
  [Guid("00063034-0000-0000-C000-000000000046")]
  [CompilerGenerated]
  [TypeIdentifier]
  [ComImport]
  public interface _MailItem
  {
    [SpecialName]
    extern void _VtblGap1_5();

    Attachments Attachments { [DispId(63509)] [return: MarshalAs(UnmanagedType.Interface)] get; }

    [SpecialName]
    extern void _VtblGap2_13();

    Inspector GetInspector { [DispId(61502)] [return: MarshalAs(UnmanagedType.Interface)] get; }

    [SpecialName]
    extern void _VtblGap3_16();

    string Subject { [DispId(55)] [return: MarshalAs(UnmanagedType.BStr)] get; [DispId(55)] [param: MarshalAs(UnmanagedType.BStr), In] set; }

    [SpecialName]
    extern void _VtblGap4_6();

    [DispId(61606)]
    void Display([MarshalAs(UnmanagedType.Struct), In, Optional] object Modal);

    [SpecialName]
    extern void _VtblGap5_24();

    string HTMLBody { [DispId(62468)] [return: MarshalAs(UnmanagedType.BStr)] get; [DispId(62468)] [param: MarshalAs(UnmanagedType.BStr), In] set; }

    [SpecialName]
    extern void _VtblGap6_11();

    Recipients Recipients { [DispId(63508)] [return: MarshalAs(UnmanagedType.Interface)] get; }

    [SpecialName]
    extern void _VtblGap7_32();

    [DispId(61557)]
    void Send();
  }
}
