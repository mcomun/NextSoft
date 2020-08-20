using System.Drawing;
using Infrastructure.Aspect.Constants;

namespace Delfin.Principal
{
    public interface IPRO004LView
    {
        Telerik.WinControls.UI.RadPageViewPage TabPageControl { get; set; }
        PRO004Presenter Presenter { get; set; }
        Image IconView { get; set; }
        event Infrastructure.Client.FormClose.FormCloseEventArgs.FormCloseEventHandler CloseForm;

        void LoadView();
        void ShowItems();
        void FiltrosLView();
    }
    public interface IPRO004MView
    {
        PRO004Presenter Presenter { get; set; }
        void LoadView();
        void ClearItem();
        void GetItem();
        void SetItem();
        void SetInstance(InstanceView x_instance);
        void ShowValidation();
        void ClearItemsDetallesTarjas();
        void ShowItemsDetalleTarjas();
    }

    public interface IPRO004DMview
    {
        PRO004Presenter Presenter { get; set; }
        void LoadView();
        void ClearItem();
        void GetItem();
        void SetItem();
        void SetInstance(InstanceView x_instance);
        void ShowValidation();
        void CerrarVenta();
    }
}
