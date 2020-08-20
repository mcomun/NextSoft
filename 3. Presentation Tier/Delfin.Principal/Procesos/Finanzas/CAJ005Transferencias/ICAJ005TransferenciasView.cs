using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Delfin.Principal
{
   public interface ICAJ005TransferenciasLView
   {
      Telerik.WinControls.UI.RadPageViewPage TabPageControl { get; set; }
      CAJ005TransferenciasPresenter Presenter { get; set; }
      Image IconView { get; set; }
      event Infrastructure.Client.FormClose.FormCloseEventArgs.FormCloseEventHandler CloseForm;

      void LoadView();
      void ShowItems();
   }
   public interface ICAJ005TransferenciasMView
   {
      CAJ005TransferenciasPresenter Presenter { get; set; }

      void LoadView();

      void ClearItem();
      void GetItem();
      void SetItem();
      
      void ShowValidation();
      void EnabledItem(Boolean x_opcion);

   }

   public interface ICAJ005TransferenciasMViewSmall
   {
      CAJ005TransferenciasPresenter Presenter { get; set; }

      void LoadView();

      void ClearItem();
      void GetItem();
      void SetItem();

      void ShowValidation();
      void EnabledItem(Boolean x_opcion);

   }

}
