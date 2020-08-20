using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Delfin.Principal
{
    public interface IMAN002LView
    {
        Telerik.WinControls.UI.RadPageViewPage TabPageControl { get; set; }
        MAN002Presenter Presenter { get; set; }
        System.Drawing.Image IconView { get; set; }
        event Infrastructure.Client.FormClose.FormCloseEventArgs.FormCloseEventHandler CloseForm;

        void LoadView();
        void ShowItems();
    }
    public interface IMAN002MView
    {
        MAN002Presenter Presenter { get; set; }

        void LoadView();

        void ClearItem();
        void GetItem();
        void SetItem();

        void ShowValidation();
        void setTamanoPorTipo();
        void TRFPaises();
    }
}
