using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Delfin.Principal
{
   public interface ICAJ007ExportacionBancosLView
   {
      Telerik.WinControls.UI.RadPageViewPage TabPageControl { get; set; }
      CAJ007ExportacionBancosPresenter Presenter { get; set; }
      Image IconView { get; set; }
      event Infrastructure.Client.FormClose.FormCloseEventArgs.FormCloseEventHandler CloseForm;

      void LoadView();
      void ShowItems();
   }
   public interface ICAJ007ExportacionBancosMView
   {
      CAJ007ExportacionBancosPresenter Presenter { get; set; }

      void LoadView();

      void ClearItem();
      void GetItem();
      void SetItem();

      void SetEnabled(Boolean x_opcion);
      void ShowValidation();
      void ShowItems();
      void SetEnabledEdit(Boolean x_opcion);
   }

}
