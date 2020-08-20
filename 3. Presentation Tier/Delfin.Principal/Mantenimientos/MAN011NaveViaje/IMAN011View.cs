using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Delfin.Principal
{
    public interface IMAN011LView
    {
        Telerik.WinControls.UI.RadPageViewPage TabPageControl { get; set; }
        MAN011Presenter Presenter { get; set; }
        System.Drawing.Image IconView { get; set; }
        event Infrastructure.Client.FormClose.FormCloseEventArgs.FormCloseEventHandler CloseForm;

        void LoadView();
        void ShowItems();
    }
    public interface IMAN011MView
    {
        MAN011Presenter Presenter { get; set; }

        void LoadView();

        void ClearItem(Boolean Transportista);
        void GetItem();
        void SetItem(Boolean Edicion = false);

        void ShowValidation();
        void FormatGridDetalle(String _CONS_CodRGM);

        void DisableFromOV();
    }
}
