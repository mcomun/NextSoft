using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace Delfin.Principal
{
    public interface IMAN012LView
    {
        Telerik.WinControls.UI.RadPageViewPage TabPageControl { get; set; }
        MAN012Presenter Presenter { get; set; }
        System.Drawing.Image IconView { get; set; }
        event Infrastructure.Client.FormClose.FormCloseEventArgs.FormCloseEventHandler CloseForm;

        void SetTransportista(Int32 ENTC_CodTransportista);

        void LoadView();
        void ShowItems();
    }
    public interface IMAN012MView
    {
        MAN012Presenter Presenter { get; set; }

        void LoadView();

        void ClearItem();
        void GetItem();
        void SetItem();

        void SetListContratos(ObservableCollection<Entities.Contrato> ListContratos);

        void ShowValidation();
    }
}
