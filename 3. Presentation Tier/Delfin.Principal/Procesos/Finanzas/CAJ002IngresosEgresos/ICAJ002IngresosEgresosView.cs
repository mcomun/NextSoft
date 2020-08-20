using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Delfin.Principal
{
   public interface ICAJ002IngresosEgresosLView
   {
      Telerik.WinControls.UI.RadPageViewPage TabPageControl { get; set; }
      CAJ002IngresosEgresosPresenter Presenter { get; set; }
      Image IconView { get; set; }
      event Infrastructure.Client.FormClose.FormCloseEventArgs.FormCloseEventHandler CloseForm;

      void LoadView();
      void ShowItems();
   }
   public interface ICAJ002IngresosEgresosMView
   {
      CAJ002IngresosEgresosPresenter Presenter { get; set; }
      CAJ002IngresosEgresosPresenter PresenterBase { get; set; }

      void LoadView();

      void ClearItem();
      void GetItem();
      void SetItem();
      void SetItemFlujo();
      
      void ShowValidation();

      void SetEnabled(Boolean x_opcion);
      void EnabledItemEditar(Boolean x_opcion = true);
      void SetDiferido();
      void SetEjecutado();
   }

}
