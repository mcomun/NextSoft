using System.Drawing;
using Infrastructure.Aspect.Constants;

namespace Delfin.Principal
{
   public interface IPRO008LView
   {
      Telerik.WinControls.UI.RadPageViewPage TabPageControl { get; set; }
      PRO008Presenter Presenter { get; set; }
      Image IconView { get; set; }
      event Infrastructure.Client.FormClose.FormCloseEventArgs.FormCloseEventHandler CloseForm;

      void LoadView();
      void ShowItems();
      void FiltrosLView();
   }
   public interface IPRO008MView
   {
      PRO008Presenter Presenter { get; set; }
      void LoadView();
      void ClearItem();
      void GetItem();
      void SetItem();
      void ShowValidation();
      void SetInstance(InstanceView xInstance);
      bool ConvertColeccion();
   }
}