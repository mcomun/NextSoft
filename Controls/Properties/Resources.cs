// Decompiled with JetBrains decompiler
// Type: Delfin.Controls.Properties.Resources
// Assembly: Delfin.Controls, Version=3.0.1.3, Culture=neutral, PublicKeyToken=null
// MVID: A4BA2B33-0E71-44B0-9838-A6C1CD0C2B15
// Assembly location: C:\Temp\Delfin.Controls.dll

using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Resources;
using System.Runtime.CompilerServices;

namespace Delfin.Controls.Properties
{
  [GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
  [CompilerGenerated]
  [DebuggerNonUserCode]
  internal class Resources
  {
    private static ResourceManager resourceMan;
    private static CultureInfo resourceCulture;

    internal Resources()
    {
    }

    [EditorBrowsable(EditorBrowsableState.Advanced)]
    internal static ResourceManager ResourceManager
    {
      get
      {
        if (object.ReferenceEquals((object) Delfin.Controls.Properties.Resources.resourceMan, (object) null))
          Delfin.Controls.Properties.Resources.resourceMan = new ResourceManager("Delfin.Controls.Properties.Resources", typeof (Delfin.Controls.Properties.Resources).Assembly);
        return Delfin.Controls.Properties.Resources.resourceMan;
      }
    }

    [EditorBrowsable(EditorBrowsableState.Advanced)]
    internal static CultureInfo Culture
    {
      get
      {
        return Delfin.Controls.Properties.Resources.resourceCulture;
      }
      set
      {
        Delfin.Controls.Properties.Resources.resourceCulture = value;
      }
    }

    internal static Bitmap buscar8x8
    {
      get
      {
        return (Bitmap) Delfin.Controls.Properties.Resources.ResourceManager.GetObject(nameof (buscar8x8), Delfin.Controls.Properties.Resources.resourceCulture);
      }
    }

    internal static Bitmap clean8x8
    {
      get
      {
        return (Bitmap) Delfin.Controls.Properties.Resources.ResourceManager.GetObject(nameof (clean8x8), Delfin.Controls.Properties.Resources.resourceCulture);
      }
    }

    internal static Bitmap edit8x8
    {
      get
      {
        return (Bitmap) Delfin.Controls.Properties.Resources.ResourceManager.GetObject(nameof (edit8x8), Delfin.Controls.Properties.Resources.resourceCulture);
      }
    }

    internal static Bitmap export
    {
      get
      {
        return (Bitmap) Delfin.Controls.Properties.Resources.ResourceManager.GetObject(nameof (export), Delfin.Controls.Properties.Resources.resourceCulture);
      }
    }

    internal static Bitmap nuevo8x8
    {
      get
      {
        return (Bitmap) Delfin.Controls.Properties.Resources.ResourceManager.GetObject(nameof (nuevo8x8), Delfin.Controls.Properties.Resources.resourceCulture);
      }
    }
  }
}
