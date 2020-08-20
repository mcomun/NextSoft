// Decompiled with JetBrains decompiler
// Type: Microsoft.Office.Interop.Word.Find
// Assembly: Delfin.Controls, Version=3.0.1.3, Culture=neutral, PublicKeyToken=null
// MVID: A4BA2B33-0E71-44B0-9838-A6C1CD0C2B15
// Assembly location: C:\Temp\Delfin.Controls.dll

using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Microsoft.Office.Interop.Word
{
  [Guid("000209B0-0000-0000-C000-000000000046")]
  [TypeIdentifier]
  [CompilerGenerated]
  [ComImport]
  public interface Find
  {
    [SpecialName]
    extern void _VtblGap1_48();

    [DispId(444)]
    bool Execute([MarshalAs(UnmanagedType.Struct), In, Optional] ref object FindText, [MarshalAs(UnmanagedType.Struct), In, Optional] ref object MatchCase, [MarshalAs(UnmanagedType.Struct), In, Optional] ref object MatchWholeWord, [MarshalAs(UnmanagedType.Struct), In, Optional] ref object MatchWildcards, [MarshalAs(UnmanagedType.Struct), In, Optional] ref object MatchSoundsLike, [MarshalAs(UnmanagedType.Struct), In, Optional] ref object MatchAllWordForms, [MarshalAs(UnmanagedType.Struct), In, Optional] ref object Forward, [MarshalAs(UnmanagedType.Struct), In, Optional] ref object Wrap, [MarshalAs(UnmanagedType.Struct), In, Optional] ref object Format, [MarshalAs(UnmanagedType.Struct), In, Optional] ref object ReplaceWith, [MarshalAs(UnmanagedType.Struct), In, Optional] ref object Replace, [MarshalAs(UnmanagedType.Struct), In, Optional] ref object MatchKashida, [MarshalAs(UnmanagedType.Struct), In, Optional] ref object MatchDiacritics, [MarshalAs(UnmanagedType.Struct), In, Optional] ref object MatchAlefHamza, [MarshalAs(UnmanagedType.Struct), In, Optional] ref object MatchControl);
  }
}
