using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Delfin.Principal
{
     public interface IMAN009LView
   {
      Telerik.WinControls.UI.RadPageViewPage TabPageControl { get; set; }
      MAN009Presenter Presenter { get; set; }
      System.Drawing.Image IconView { get; set; }
      event Infrastructure.Client.FormClose.FormCloseEventArgs.FormCloseEventHandler CloseForm;
      void LoadFilters();
      void LoadView();
      void ShowItems();
   }
   public interface IMAN009MView
   {
      MAN009Presenter Presenter { get; set; }

      void LoadView();

      void ClearItem();
      void GetItem();
      void SetItem();

      void ShowValidation();

      void ShowServicios();
      void ShowItemsDepTemporal();
      void ShowRelacionados();
      void ShowLimiteCreditoCliente();
      void ShowLimiteCreditoProveedor();
      void ShowEntidadCuentaBancaria();
   }

}
