using System.Drawing;
using Infrastructure.Aspect.Constants;

namespace Delfin.Principal
{
   public interface IPRO006LView
   {
      Telerik.WinControls.UI.RadPageViewPage TabPageControl { get; set; }
      PRO006Presenter Presenter { get; set; }
      Image IconView { get; set; }
      event Infrastructure.Client.FormClose.FormCloseEventArgs.FormCloseEventHandler CloseForm;

      void LoadView();
      void ShowItems();
      void FiltrosLView();
   }
   public interface IPRO006MView
   {
      PRO006Presenter Presenter { get; set; }
      void LoadView();
      void ClearItem();
      void GetItem();
      void SetItem();
      void SetInstance(InstanceView xInstance);
      void ShowValidation();

      void ClearItemsDetalles();
      void ShowItemsDetalles();
   }

   public interface IPRO006DMview
   {
       PRO006Presenter Presenter { get; set; }
       void LoadView();
       void ClearItem();
       void GetItem();
       void SetItem();
       void SetInstance(InstanceView xInstance);
       void ShowValidation();
       void CerrarVenta();

   }
}
