using System;
using System.Drawing;
using Delfin.Entities;
using Infrastructure.Aspect.Constants;
using System.Collections.ObjectModel;

namespace Delfin.Principal
{
    public interface IPRO003LView
    {
        Telerik.WinControls.UI.RadPageViewPage TabPageControl { get; set; }
        PRO003Presenter Presenter { get; set; }
        Image IconView { get; set; }
        event Infrastructure.Client.FormClose.FormCloseEventArgs.FormCloseEventHandler CloseForm;

        void LoadView();
        void ShowItems();
        void FiltrosLView();
    }
    public interface IPRO003MView
    {
        PRO003Presenter Presenter { get; set; }
        void LoadView();
        void ClearItem();
        void GetItem();
        void SetItem();
        void SetInstance(InstanceView xInstance);
        void ShowValidation();

        void FiltrosCotizaciones();
        void ClearItemsDetallesOperacion();
        void ShowItemsLogisticoDetalleOperacion();
        void ShowItemsAduaneroDetalleOperacion();
        void ShowItemsTransporteDetalleOperacion();

        void SetItemST20_ST40_HBL(ref ObservableCollection<Entities.Det_Operacion> xItems, Boolean xBuscar);

        void ClearItemsDetalleServiciosOperactivo();
        void ShowItemsDetalleServiciosOperativo();
    }
    public interface IPRO003DMview
    {
        PRO003Presenter Presenter { get; set; }
        void LoadView();
        void ClearItem();
        void GetItem();
        void SetItem();
        void SetInstance(InstanceView xInstance);
        void ShowValidation();
        void GenerarST20_ST40_HBL(ref Int32 xUltimafila, ObservableCollection<Det_Operacion> tempItemsDetOperacion);
        void CerrarVenta();
    }
    public interface IPRO003DSMview
    {
        PRO003Presenter Presenter { get; set; }
        void LoadView();
        void ClearItem();
        void GetItem();
        void SetItem();
        void SetInstance(InstanceView x_instance);
        void ShowValidation();
        void CerrarVenta();
    }

}