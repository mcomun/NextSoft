using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Delfin.Principal
{
   public interface ICAJ006LiquidacionAgentesLView
   {
      Telerik.WinControls.UI.RadPageViewPage TabPageControl { get; set; }
      CAJ006LiquidacionAgentesPresenter Presenter { get; set; }
      Image IconView { get; set; }
      event Infrastructure.Client.FormClose.FormCloseEventArgs.FormCloseEventHandler CloseForm;

      void ClearItem();
      void GetItem();
      void SetItem(CAJ006LiquidacionAgentesPresenter.TBusqueda x_opcion);

      void ShowValidation();

      void LoadView();
      void ShowItems(CAJ006LiquidacionAgentesPresenter.TBusqueda x_opcion);
   }
   public interface ICAJ006LiquidacionAgentesDViewConciliacion
   {
      CAJ006LiquidacionAgentesPresenter Presenter { get; set; }
      String PathConciliacion { get; set; }

      void LoadView();

      //void ClearItem();
      //void GetItem();
      //void SetItem();

      //void ShowValidation();

   }

}
