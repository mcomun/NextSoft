using System.Drawing;
using Infrastructure.Aspect.Constants;

namespace Delfin.Principal
{
   public interface IPRO010LView
   {
      Telerik.WinControls.UI.RadPageViewPage TabPageControl { get; set; }
      PRO010Presenter Presenter { get; set; }
      Image IconView { get; set; }
      event Infrastructure.Client.FormClose.FormCloseEventArgs.FormCloseEventHandler CloseForm;

      void LoadView();
      void ShowItems();
      void FiltrosLView();
   }
   public interface IPRO010MView
   {
      PRO010Presenter Presenter { get; set; }
      void LoadView();
      void ClearItem();
      void GetItem();
      void SetItem(System.Data.DataTable _dt);
      void CargaDataDocumentos(System.Data.DataTable _dt, bool IncluyePago);
      void ShowValidation();
      void SetInstance(InstanceView xInstance);
   }
   public interface IPRO010RView
   {
      PRO010Presenter Presenter { get; set; }
      void ShowReporte(int x_CAJA_Codigo);
   }
}
