using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using Infrastructure.Aspect.Constants;

namespace Delfin.Principal
{
   public interface IPRO005LView
   {
      Telerik.WinControls.UI.RadPageViewPage TabPageControl { get; set; }
      PRO005Presenter Presenter { get; set; }
      Image IconView { get; set; }
      event Infrastructure.Client.FormClose.FormCloseEventArgs.FormCloseEventHandler CloseForm;

      void LoadView();
      void ShowItems();
      void ShowItemsDetalle();
   }
   public interface IPRO005MView
   {
      PRO005Presenter Presenter { get; set; }
      //void LoadView();
      //void ClearItem();
      //void GetItem();
      //void SetItem();
      //void SetInstance(InstanceView x_instance);
      //void EnableItem(Boolean Enabled, Boolean x_EnabledFechas);

      void ShowValidation();
      //void ShowTarifas(System.Data.DataTable DTTarifario);
   }
}
