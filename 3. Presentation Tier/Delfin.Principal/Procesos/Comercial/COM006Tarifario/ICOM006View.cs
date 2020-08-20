using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Delfin.Principal
{
   public interface ICOM006LView
   {
      Telerik.WinControls.UI.RadPageViewPage TabPageControl { get; set; }
      COM006Presenter Presenter { get; set; }
      Image IconView { get; set; }
      event Infrastructure.Client.FormClose.FormCloseEventArgs.FormCloseEventHandler CloseForm;

      void LoadView();
      void ShowItems();
   }
   public interface ICOM006MView
   {
      COM006Presenter Presenter { get; set; }

      void LoadView();

      void ClearItem();
      void GetItem(Boolean Tarifario);
      void SetItem(Boolean Copiar = false);
      void EnableItem(Boolean Enabled, Boolean x_EnabledFechas);

      void ShowValidation();
      void ShowTarifas(System.Data.DataTable DTTarifario);
   }
   public interface ICOM006DView
   {
      COM006Presenter Presenter { get; set; }

      void LoadView();

      void ClearItem();
      void GetItem();
      void SetItem();

      void ShowValidation();
   }
   public interface ICOM006CView
   {
      COM006Presenter Presenter { get; set; }

      void LoadView();
      void ClearItem();
      void SetItem();
      void GetItem();
   }
}
