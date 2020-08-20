using System.Drawing;
using Infrastructure.Aspect.Constants;

namespace Delfin.Logistico
{
   public interface IPRO007LView
   {
      Telerik.WinControls.UI.RadPageViewPage TabPageControl { get; set; }
      PRO007Presenter Presenter { get; set; }
      Image IconView { get; set; }
      event Infrastructure.Client.FormClose.FormCloseEventArgs.FormCloseEventHandler CloseForm;

      void LoadView();
      void ShowItems();
      void FiltrosLView();

   }
   public interface IPRO007MView
   {
      PRO007Presenter Presenter { get; set; }
      void LoadView();
      void ClearItem();
      void GetItem();
      void SetItem();
      void SetInstance(InstanceView xInstance);
      void ShowValidation();
      void SetEnabled();

      void ClearItemsDetalles();
      void ShowItemsDetalles();
      void GetItemTotales();
      void Calculos();
      void GetItemsDetalleServicios();
   }
   public interface IPRO007RView
   {
       /* Impresión */
       PRO007Presenter Presenter { get; set; }
       void ShowReporte();
   }

   public interface IPRO007DViewFPG
   {
      PRO007Presenter Presenter { get; set; }

      void LoadView();

      void ClearItem();
      void GetItem();
      void SetItem();

      void ShowValidation();
   }

   public interface IPRO007MViewFactLibre
   {
      PRO007Presenter Presenter { get; set; }

      void LoadView();

      void Nuevo();
      void ClearItem();
      void GetItem();
      void SetItem();

      void ShowValidation(string x_msg);

   }
}
