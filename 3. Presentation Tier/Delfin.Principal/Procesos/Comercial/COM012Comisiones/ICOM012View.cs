using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Delfin.Principal
{
   public interface ICOM012LView
   {
      Telerik.WinControls.UI.RadPageViewPage TabPageControl { get; set; }
      COM012Presenter Presenter { get; set; }
      Image IconView { get; set; }
      event Infrastructure.Client.FormClose.FormCloseEventArgs.FormCloseEventHandler CloseForm;

      void LoadView();
      void ShowItems();
   }
   public interface ICOM012MView
   {
      COM012Presenter Presenter { get; set; }

      void LoadView();

      void ShowValidation();
   }
}
