// Decompiled with JetBrains decompiler
// Type: Microsoft.Office.Interop.Word._Document
// Assembly: Delfin.Controls, Version=3.0.1.3, Culture=neutral, PublicKeyToken=null
// MVID: A4BA2B33-0E71-44B0-9838-A6C1CD0C2B15
// Assembly location: C:\Temp\Delfin.Controls.dll

using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Microsoft.Office.Interop.Word
{
  [TypeIdentifier]
  [Guid("0002096B-0000-0000-C000-000000000046")]
  [CompilerGenerated]
  [ComImport]
  public interface _Document
  {
    [SpecialName]
    extern void _VtblGap1_8();

    Tables Tables { [DispId(6)] [return: MarshalAs(UnmanagedType.Interface)] get; }

    [SpecialName]
    extern void _VtblGap2_25();

    string FullName { [DispId(29)] [return: MarshalAs(UnmanagedType.BStr)] get; }

    [SpecialName]
    extern void _VtblGap3_125();

    [DispId(1105)]
    void Close([MarshalAs(UnmanagedType.Struct), In, Optional] ref object SaveChanges, [MarshalAs(UnmanagedType.Struct), In, Optional] ref object OriginalFormat, [MarshalAs(UnmanagedType.Struct), In, Optional] ref object RouteDocument);

    [SpecialName]
    extern void _VtblGap4_7();

    [DispId(108)]
    void Save();

    [SpecialName]
    extern void _VtblGap5_4();

    [DispId(113)]
    void Activate();

    [SpecialName]
    extern void _VtblGap6_116();

    [DispId(376)]
    void SaveAs([MarshalAs(UnmanagedType.Struct), In, Optional] ref object FileName, [MarshalAs(UnmanagedType.Struct), In, Optional] ref object FileFormat, [MarshalAs(UnmanagedType.Struct), In, Optional] ref object LockComments, [MarshalAs(UnmanagedType.Struct), In, Optional] ref object Password, [MarshalAs(UnmanagedType.Struct), In, Optional] ref object AddToRecentFiles, [MarshalAs(UnmanagedType.Struct), In, Optional] ref object WritePassword, [MarshalAs(UnmanagedType.Struct), In, Optional] ref object ReadOnlyRecommended, [MarshalAs(UnmanagedType.Struct), In, Optional] ref object EmbedTrueTypeFonts, [MarshalAs(UnmanagedType.Struct), In, Optional] ref object SaveNativePictureFormat, [MarshalAs(UnmanagedType.Struct), In, Optional] ref object SaveFormsData, [MarshalAs(UnmanagedType.Struct), In, Optional] ref object SaveAsAOCELetter, [MarshalAs(UnmanagedType.Struct), In, Optional] ref object Encoding, [MarshalAs(UnmanagedType.Struct), In, Optional] ref object InsertLineBreaks, [MarshalAs(UnmanagedType.Struct), In, Optional] ref object AllowSubstitutions, [MarshalAs(UnmanagedType.Struct), In, Optional] ref object LineEnding, [MarshalAs(UnmanagedType.Struct), In, Optional] ref object AddBiDiMarks);
  }
}
