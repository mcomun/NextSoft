using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using Infrastructure.Aspect.Constants;

namespace Delfin.Principal
{
    public interface IDOC000LView
   {
      Telerik.WinControls.UI.RadPageViewPage TabPageControl { get; set; }
      DOC000Presenter Presenter { get; set; }
      Image IconView { get; set; }
      event Infrastructure.Client.FormClose.FormCloseEventArgs.FormCloseEventHandler CloseForm;

      void LoadView();
      void ShowItems();
      void ShowItemsDetalle();
   }
   public interface IDOC000MView
   {
       DOC000Presenter Presenter { get; set; }
      void LoadView();
      void ClearItem();
      void GetItem();
      void SetItem();
      //void SetInstance(InstanceView x_instance);
      //void EnableItem(Boolean Enabled, Boolean x_EnabledFechas);

      void ShowValidation();
      //void ShowTarifas(System.Data.DataTable DTTarifario);
   }
}
