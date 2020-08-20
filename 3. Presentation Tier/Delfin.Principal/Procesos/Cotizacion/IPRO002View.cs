using System;
using System.Drawing;
using Infrastructure.Aspect.Constants;
using System.Collections.ObjectModel;

namespace Delfin.Principal
{
    public interface IPRO002LView
    {
        Telerik.WinControls.UI.RadPageViewPage TabPageControl { get; set; }
        PRO002Presenter Presenter { get; set; }
        Image IconView { get; set; }
        event Infrastructure.Client.FormClose.FormCloseEventArgs.FormCloseEventHandler CloseForm;

        void LoadView();
        void ShowItems();
        void FiltrosLView();
    }
    public interface IPRO002MView
    {
        PRO002Presenter Presenter { get; set; }
        void LoadView();
        void ClearItem();
        void GetItem();
        void SetItem();
        void SetInstance(InstanceView x_instance);
        void ShowValidation();
        void SetItemServicio(String x_CTAR_Tipo, Int32 x_CTAR_Codigo);

        void FiltrosTarifas();
        void ClearItemsDetallesCotizacion();
        void ShowItemsLogisticoDetalleCotizacion(Boolean Nuevo);
        void ShowItemsAduaneroDetalleCotizacion();
        void ShowItemsTransporteDetalleCotizacion();

        void SetItemST20_ST40_HBL(ref ObservableCollection<Entities.Det_Cotizacion> x_items);
        void SeteaCabTarifarios(Int32 _CTAR_Codigo, String _CTAR_Tipo);
        void ClearItemsDetalleServicios();
        void ShowItemsDetalleServicios();
    }

    public interface IPRO002DMview
    {
        PRO002Presenter Presenter { get; set; }
        void LoadView();
        void ClearItem();
        void GetItem();
        void SetItem();
        void SetInstance(InstanceView x_instance);
        void ShowValidation();
        void GenerarST20_ST40_HBL(String _CTAR_Tipo, Int32? _CTAR_Codigo, Int16? _DTAR_Item);
        void CerrarVenta();
    }
    public interface IPRO002DSMview
    {
        PRO002Presenter Presenter { get; set; }
        void LoadView();
        void ClearItem();
        void GetItem();
        void SetItem();
        void SetInstance(InstanceView xInstance);
        void ShowValidation();
        void CerrarVenta();
    }
    public interface IPRO002DImprimir
    {
       /* Impresión */
       PRO002Presenter Presenter { get; set; }
       void ShowReporte();

    }

}