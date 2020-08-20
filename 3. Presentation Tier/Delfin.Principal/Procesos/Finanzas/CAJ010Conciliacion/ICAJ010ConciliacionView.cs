using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Delfin.Principal
{
   public interface ICAJ010ConciliacionLView
   {
      Telerik.WinControls.UI.RadPageViewPage TabPageControl { get; set; }
      CAJ010ConciliacionPresenter Presenter { get; set; }
      Image IconView { get; set; }
      event Infrastructure.Client.FormClose.FormCloseEventArgs.FormCloseEventHandler CloseForm;

      void LoadView();
      void ShowItems();

      void ShowValidation();
      void ShowConciliacion(String x_mensaje);
   }
   public interface ICAJ010ConciliacionMView
   {
      CAJ010ConciliacionPresenter Presenter { get; set; }

      void LoadView();

      void ClearItem();
      void GetItem();
      void SetItem();
      
      void ShowValidation();

   }

}
