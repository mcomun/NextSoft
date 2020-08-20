using System.Drawing;
using Infrastructure.Aspect.Constants;
using System.Collections.ObjectModel;

namespace Delfin.Principal
{
   public interface IPRO001LView
   {
      Telerik.WinControls.UI.RadPageViewPage TabPageControl { get; set; }
      PRO001Presenter Presenter { get; set; }
      Image IconView { get; set; }
      event Infrastructure.Client.FormClose.FormCloseEventArgs.FormCloseEventHandler CloseForm;

      void LoadView();
      void ShowItems();
      void FiltrosLView();
   }
   public interface IPRO001MView
   {
      PRO001Presenter Presenter { get; set; }
      void LoadView();
      void ClearItem();
      void GetItem();
      void SetItem();
      void SetInstance(InstanceView x_instance);
      void ShowValidation();

      void ClearItemsDetalles();
      void ShowItemsDetalleTarifario();

      void ClearItemsDetalleServicios();
      void ShowItemsDetalleServicios();
   }

   public interface IPRO001DTarifa
   {
       PRO001Presenter Presenter { get; set; }
       void LoadView();
       void ClearItem(string xTipoTarifa);
       void GetItem();
       void SetItem();
       void SetInstance(InstanceView xInstance);
       void ShowValidation();
       void SetItemST20_ST40(ref ObservableCollection<Entities.Det_Tarifa> x_items);
       void GenerarST20_ST40_HBL();
       void CerrarVenta();
   }

   public interface IPRO001DSMview
   {
       PRO001Presenter Presenter { get; set; }
       void LoadView();
       void ClearItem();
       void GetItem();
       void SetItem();
       void SetInstance(InstanceView x_instance);
       void ShowValidation();
       void CerrarVenta();
   }
}
