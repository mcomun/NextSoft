using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Delfin.Principal
{
   public interface ICOM003LView
   {
      Telerik.WinControls.UI.RadPageViewPage TabPageControl { get; set; }
      COM003Presenter Presenter { get; set; }
      Image IconView { get; set; }
      event Infrastructure.Client.FormClose.FormCloseEventArgs.FormCloseEventHandler CloseForm;

      void LoadView();
      void ShowItems(Boolean Habilitar);

      void ShowGestionesProspecto();

      void GetItemGestionVentas();
      void SetItemGestionVentas();
      void ClearItemGestionVentas();
      void HabilitarDatosGestionVentas(Boolean Habilitar);
      void ShowValidation();

      void ClearItemContacto();
      void SetItemContacto();
   }
   //public interface ICOM003MView
   //{
   //   COM003Presenter Presenter { get; set; }

   //   void LoadView();

   //   void ClearItem();
   //   void GetItem();
   //   void SetItem();

   //   void ShowValidation();
   //}
}
