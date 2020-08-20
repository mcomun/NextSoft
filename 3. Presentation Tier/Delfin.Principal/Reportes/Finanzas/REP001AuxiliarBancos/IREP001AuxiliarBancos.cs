using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Delfin.Principal
{
   public interface IREP001AuxiliarBancosLView
   {

      Telerik.WinControls.UI.RadPageViewPage TabPageControl { get; set; }
      REP001AuxiliarBancosPresenter Presenter { get; set; }
      Image IconView { get; set; }
      event Infrastructure.Client.FormClose.FormCloseEventArgs.FormCloseEventHandler CloseForm;

      void LoadView();

   }
}
