using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Delfin.Principal
{
   public interface ICAJ012IngresoLibreLView
   {
      Telerik.WinControls.UI.RadPageViewPage TabPageControl { get; set; }
      CAJ012IngresoLibrePresenter Presenter { get; set; }
      Image IconView { get; set; }
      event Infrastructure.Client.FormClose.FormCloseEventArgs.FormCloseEventHandler CloseForm;

      void LoadView();
      void ShowItems();
   }
   public interface ICAJ012IngresoLibreMView
   {
      CAJ012IngresoLibrePresenter Presenter { get; set; }

      void LoadView();

      void ClearItem();
      void GetItem();
      void SetItem();
      
      void ShowValidation();

   }

}
