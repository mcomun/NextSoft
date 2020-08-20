using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Delfin.Comercial
{
   public interface ICAJ016FacturacionLView
   {
      Telerik.WinControls.UI.RadPageViewPage TabPageControl { get; set; }
      CAJ016FacturacionPresenter Presenter { get; set; }
      Image IconView { get; set; }
      event Infrastructure.Client.FormClose.FormCloseEventArgs.FormCloseEventHandler CloseForm;

      void LoadView(Int16 CCOT_Tipo);
      void ShowItems();
   }
   public interface ICAJ016FacturacionMView
   {
      CAJ016FacturacionPresenter Presenter { get; set; }

      void LoadView(Int16 CCOT_Codigo);

      void ClearItem();
      void GetItem();
      void SetItem();
      
      void ShowValidation();

   }

}
