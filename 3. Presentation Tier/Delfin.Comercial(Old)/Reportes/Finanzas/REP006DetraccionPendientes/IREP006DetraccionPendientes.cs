using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Delfin.Comercial
{
   public interface IREP006DetraccionPendientesLView
   {

      Telerik.WinControls.UI.RadPageViewPage TabPageControl { get; set; }
      REP006DetraccionPendientesPresenter Presenter { get; set; }
      Image IconView { get; set; }
      event Infrastructure.Client.FormClose.FormCloseEventArgs.FormCloseEventHandler CloseForm;

      void LoadView();

   }
}
