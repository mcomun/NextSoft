using System;
using System.Drawing;
using Infrastructure.Aspect.Constants;

namespace Delfin.Principal
{
   public interface IMAN013LView
   {
      Telerik.WinControls.UI.RadPageViewPage TabPageControl { get; set; }
      MAN013Presenter Presenter { get; set; }
      Image IconView { get; set; }
      event Infrastructure.Client.FormClose.FormCloseEventArgs.FormCloseEventHandler CloseForm;

      void LoadView();
      void ShowItems();
   }
   public interface IMAN013MView
   {
      MAN013Presenter Presenter { get; set; }
      void ClearItem();
      void GetItem();
      void SetItem();
      void SetFecha(DateTime x_fecha);
   }
}
