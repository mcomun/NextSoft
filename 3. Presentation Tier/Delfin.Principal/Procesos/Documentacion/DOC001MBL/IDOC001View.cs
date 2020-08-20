using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using Infrastructure.Aspect.Constants;

namespace Delfin.Principal
{
   public interface IDOC001LView
   {
      Telerik.WinControls.UI.RadPageViewPage TabPageControl { get; set; }
      DOC001Presenter Presenter { get; set; }
      Image IconView { get; set; }
      event Infrastructure.Client.FormClose.FormCloseEventArgs.FormCloseEventHandler CloseForm;

      void LoadView();
      void ShowItems();
      void ShowItemsDetalle();
   }
   public interface IDOC001MView
   {
      DOC001Presenter Presenter { get; set; }
      
      void LoadView();
      void ClearItem();
      void GetItem();
      void SetItem();
      void EnableItem(Boolean Enabled);

      void SetInstance(InstanceView x_instance);

      void ShowValidation();
      void ValidateItem();
   }
}