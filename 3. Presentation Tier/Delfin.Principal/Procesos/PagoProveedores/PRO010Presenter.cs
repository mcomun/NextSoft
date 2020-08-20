using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Infrastructure.Aspect.BusinessEntity;
using Microsoft.Practices.Unity;
using Delfin.ServiceProxy;
using Delfin.Entities;
using Infrastructure.Client.Services.Session;
using System.Collections.ObjectModel;
using Infrastructure.WinFormsControls;
using Infrastructure.Aspect.Constants;
using Infrastructure.Aspect.Collections;

namespace Delfin.Principal
{
   public class PRO010Presenter
   {
      #region [ Variables ]
      public String Title = "Pago Proveedores";
      public String CUS = "LOG010";

      private Movimiento m_ItemMovimiento;
      private DetCtaCte m_ItemDetCtaCte;
      private ObservableCollection<DetCtaCte> m_ItemsDetCtaCte;
      private ObservableCollection<Movimiento> m_ItemsMovimiento;
      public DataTable _DT;
      public String CAJA_Tipo { get; set; }
      public Movimiento ItemMovimiento
      {
         get { return m_ItemMovimiento; }
         set { m_ItemMovimiento = value; }
      }
      public DetCtaCte ItemDetCtaCte
      {
         get { return m_ItemDetCtaCte; }
         set { m_ItemDetCtaCte = value; }
      }

      public DateTime dtpDesde { get; set; }
      public DateTime dtpHasta { get; set; }
      public ObservableCollection<CtaCte> ItemsCaja { get; set; }
      public ObservableCollection<DetCtaCte> ItemsDetCtaCte { get; set; }

      #endregion
      #region [ Constructor ]
      public PRO010Presenter(IUnityContainer x_container, IPRO010LView x_lview, IPRO010MView x_mview, IPRO010RView x_rview)
      {
         try
         {
            ContainerService = x_container;
            Session = ContainerService.Resolve<ISessionService>();
            ItemsDetCtaCte = new ObservableCollection<DetCtaCte>(); 
            LView = x_lview;
            MView = x_mview;
            RView = x_rview;
         }
         catch (Exception ex)
         { Dialogos.MostrarMensajeError(Title, Mensajes.ConstructorPresenter, ex); }
      }

      public void Imprimir(Int32 x_CAJA_Codigo)
      {
         try
         {
            RView.ShowReporte(x_CAJA_Codigo);
           
            ((PRO010RView)RView).Show();
            ((PRO010RView)RView).BringToFront();
         }
         catch (Exception ex)
         { Dialogos.MostrarMensajeError(Title, Mensajes.ConstructorPresenter, ex); }
      }

      public DataTable GetComprobante(Int32 x_CAJA_Codigo)
      {
         try
         {
            return new DataTable(); // Client.GetOneMovimiento(Convert.ToInt16(Session.EmpresaCodigo), x_CAJA_Codigo); //GetComprobante(x_CAJA_Codigo);
         }
         catch (Exception ex)
         { Dialogos.MostrarMensajeError(Title, Mensajes.ConstructorPresenter, ex); return null; }
      }

      public Boolean ValidarTipoCambio(String _Fecha)
      {
         String fecha = String.Empty;
         //fecha = Session.Fecha.Year.ToString() + Session.Fecha.Month.ToString().PadLeft(2, '0').Trim() + Session.Fecha.Day.ToString().PadLeft(2, '0').Trim();
         var First = Client.GetOneTiposCambio(_Fecha);
         TipoCambio = 0;
         TipoCambio = First != null ? First.TIPC_Compra : 0;
         if (TipoCambio > 0)
         {
            return true;
         }
         Dialogos.MostrarMensajeInformacion(Title, "No se encontro el tipo de cambio de hoy verifique con el administrador de sistemas");
         return false;
      }

      public void Load()
      {
         try
         {
            Client = ContainerService.Resolve<Delfin.ServiceContracts.IDelfinServices>();

            LView.LoadView();
            MView.LoadView();

         }
         catch (Exception ex)
         { Dialogos.MostrarMensajeError(Title, Mensajes.LoadPresenter, ex); }
      }

      public bool Guardar()
      {
         try
         {
            MView.GetItem();
            if (ItemMovimiento.Validar())
            {
               if (Client.SaveMovimiento(ref m_ItemMovimiento))
               {
                  Dialogos.MostrarMensajeSatisfactorio(Title, "Se ha guardado satisfactoriamente");
                  Actualizar();
                  return true;
               }
               Dialogos.MostrarMensajeInformacion(Title, "Ha ocurrido un error al guardar el item.");
               return false;
            }
            MView.ShowValidation();
            return false;
         }
         catch (Exception ex)
         {
            Dialogos.MostrarMensajeError(Title, Mensajes.SavePresenter, ex);
            return false;
         }
      }

      public void Editar(Int32 x_CAJA_Codigo)
      {
         try
         {
            MView.ClearItem();
            //DataSet _DS;
            //_DS = Client.GetOneCaja(x_CAJA_Codigo);
            //DataTable _DataCabecera = new DataTable();
            //_DataCabecera = _DS.Tables[0];
            //_DT = _DS.Tables[1]; 
            //MView.SetItem(_DataCabecera);
            //MView.CargaDataDocumentos(_DT, true);
            //MView.SetInstance(InstanceView.Edit);
            ((PRO010MView)MView).Show();
            ((PRO010MView)MView).BringToFront();
         }
         catch (Exception ex)
         { Dialogos.MostrarMensajeError(Title, Mensajes.EditPresenter, ex); }
      }

      public DataTable LoadAyudaDocumentosProv(Int32 x_ENTC_Codigo)
      {
         try
         {
            return Client.GetCtaCtePendientes(Convert.ToInt16(CAJA_Tipo=="C"?1:2), x_ENTC_Codigo);
         }
         catch (Exception ex)
         { return null ; }
      }

      public void Eliminar(Int32 x_MOVI_Codigo)
      {
         try
         {
            DialogResult result = Dialogos.MostrarMensajePregunta(Title, Mensajes.PreguntaEliminar, Dialogos.LabelBoton.Si_No);
            if (result == DialogResult.Yes)
            {
               ItemMovimiento = new Movimiento(); 
               ItemMovimiento.Instance = InstanceEntity.Deleted;
               ItemMovimiento.MOVI_Codigo = x_MOVI_Codigo;
               if (Client.SaveMovimiento(ref m_ItemMovimiento))
               {
                  Dialogos.MostrarMensajeSatisfactorio(Title, "Se ha eliminado el item.");
                  Actualizar();
               }
               else
               { Dialogos.MostrarMensajeInformacion(Title, "No se ha podido eliminar el item debido a que ya se encuentra relacionado."); }
            }
         }
         catch (Exception ex)
         { Dialogos.MostrarMensajeError(Title, Mensajes.DeletePresenter, ex); }
      }

      public void CargaCajaCuentas()
      {
         _DT = Client.GetAllCuentasBancarias().ToDataTable();
      }
      public void Nuevo()
      {
         try
         {
            MView.ClearItem();
            ItemMovimiento = new Movimiento
            {
               AUDI_UsrCrea = Session.UserName,
               AUDI_FecCrea = Session.Fecha,
               Instance = InstanceEntity.Added
            };
            MView.SetInstance(InstanceView.New);
           
            ((PRO010MView)MView).Show();
            ((PRO010MView)MView).BringToFront();
         }
         catch (Exception ex)
         { Dialogos.MostrarMensajeError(Title, Mensajes.NewPresenter, ex); }
      }

      public void Actualizar()
      {
         try
         {
            ItemMovimiento  = null;
            _DT  = null;
            LView.FiltrosLView();
            ObservableCollection<Infrastructure.Aspect.DataAccess.DataAccessFilterSQL> _listFilters = new ObservableCollection<Infrastructure.Aspect.DataAccess.DataAccessFilterSQL>();
            _listFilters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "psinEMPR_CODIGO", FilterValue = Session.EmpresaCodigo, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.Int16, FilterSize = 22 });
            _DT = Client.GetDTMovimiento("", _listFilters);
            LView.ShowItems();
         }
         catch (Exception ex)
         { Dialogos.MostrarMensajeError(Title, "Ha ocurrido un error actualizando.", ex); }
      }
      #endregion
      #region [ Propiedades ]
      public IUnityContainer ContainerService { get; set; }
      public ISessionService Session { get; set; }
      public Delfin.ServiceContracts.IDelfinServices Client { get; set; }
      public IPRO010LView LView { get; set; }
      public IPRO010MView MView { get; set; }
      public IPRO010RView RView { get; set; }
      public Decimal TipoCambio { get; set; }
      #endregion
   }
}
