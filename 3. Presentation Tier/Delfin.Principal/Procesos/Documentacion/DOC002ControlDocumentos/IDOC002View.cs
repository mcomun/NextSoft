using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;


namespace Delfin.Principal
{
   public interface IDOC002LView
   {
      Telerik.WinControls.UI.RadPageViewPage TabPageControl { get; set; }
      DOC002Presenter Presenter { get; set; }
      Image IconView { get; set; }
      event Infrastructure.Client.FormClose.FormCloseEventArgs.FormCloseEventHandler CloseForm;

      void LoadView();
      void ShowItems();
      void ShowItems(System.Data.DataTable dt, Boolean _cp);
      void ShowItemsOV(System.Data.DataTable dt);
   }
   public interface IDOC002MView
   {
      DOC002Presenter Presenter { get; set; }

      void LoadView();
      void ShowCampos(Boolean b);
      void ClearItem();
      void GetItem();
      void SetItem();
      
      void ShowValidation();

   }

}
