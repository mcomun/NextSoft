using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Delfin.Principal
{
   public interface IREP004LView
   {
      Telerik.WinControls.UI.RadPageViewPage TabPageControl { get; set; }
      REP004Presenter Presenter { get; set; }
      Image IconView { get; set; }
      event Infrastructure.Client.FormClose.FormCloseEventArgs.FormCloseEventHandler CloseForm;

      void LoadView();
      void ShowItems();

      void SetItemContrato();
      void ClearItemContrato();
   }
}
