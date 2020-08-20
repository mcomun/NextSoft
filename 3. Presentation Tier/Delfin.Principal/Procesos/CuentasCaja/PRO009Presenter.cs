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

namespace Delfin.Principal
{
   public class PRO009Presenter
   {
      #region [ Variables ]
      public String Title = "Cuentas Caja";
      public String CUS = "LOG009";

      private CuentasBancarias m_ItemCajaCuentas;
      private Tipos m_ItemTipos;
      private ObservableCollection<CajaCuentas> m_ItemsCuentas;
      private ObservableCollection<Tipos> m_ItemsTipos;
      public DataTable _DT;

      public CajaCuentas ItemCajaCuentas
      {
         get { return m_ItemCajaCuentas; }
         set { m_ItemCajaCuentas = value; }
      }
      public ObservableCollection<CajaCuentas> ItemsCajaCuentas { get; set; }
      public ObservableCollection<Tipos> ItemsTipos { get; set; }

      #endregion
      #region [ Constructor ]
      public PRO009Presenter(IUnityContainer x_container, IPRO009LView x_lview, IPRO009MView x_mview)
      {
         try
         {
            ContainerService = x_container;
            Session = ContainerService.Resolve<ISessionService>();
            LView = x_lview;
            MView = x_mview;
         }
         catch (Exception ex)
         { Dialogos.MostrarMensajeError(Title, Mensajes.ConstructorPresenter, ex); }
      }
      public void Editar(Int32 x_CACU_Codigo)
      {
         try
         {
            MView.ClearItem();
            ItemCajaCuentas = Client.GetOneCajaCuentas(x_CACU_Codigo);
            MView.SetItem();
            MView.SetInstance(InstanceView.Edit);
            ((PRO009MView)MView).ShowDialog();
         }
         catch (Exception ex)
         { Dialogos.MostrarMensajeError(Title, Mensajes.EditPresenter, ex); }
      }
      public void Eliminar(Int32 x_CACU_Codigo)
      {
         try
         {
            if (ItemCajaCuentas != null)
            {
               DialogResult result = Dialogos.MostrarMensajePregunta(Title, Mensajes.PreguntaEliminar, Dialogos.LabelBoton.Si_No);
               if (result == DialogResult.Yes)
               {
                  ItemCajaCuentas.Instance = InstanceEntity.Deleted;
                  ItemCajaCuentas.CACU_Codigo = x_CACU_Codigo; 
                  if (Client.SaveCajaCuentas (m_ItemCajaCuentas))
                  {
                     Dialogos.MostrarMensajeSatisfactorio(Title, "Se ha eliminado el item.");
                     Actualizar();
                  }
                  else
                  { Dialogos.MostrarMensajeInformacion(Title, "No se ha podido eliminar el item debido a que ya se encuentra relacionado."); }
               }
            }
            else
            { Dialogos.MostrarMensajeInformacion(Title, "Debe seleccionar un elemento de la grilla"); }
         }
         catch (Exception ex)
         { Dialogos.MostrarMensajeError(Title, Mensajes.DeletePresenter, ex); }
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
      public void Nuevo()
      {
         try
         {
            MView.ClearItem();
            ItemCajaCuentas = new CajaCuentas 
            {
               AUDI_UsrCrea = Session.UserName,
               AUDI_FecCrea = Session.Fecha,
               TIPO_TabBCO = "BCO",
               TIPO_TabMND = "MND",
               Instance = InstanceEntity.Added
            };
            MView.SetInstance(InstanceView.New);
            ((PRO009MView)MView).ShowDialog();
         }
         catch (Exception ex)
         { Dialogos.MostrarMensajeError(Title, Mensajes.NewPresenter, ex); }
      }
      public bool Guardar()
      {
         try
         {
            MView.GetItem();
            if (ItemCajaCuentas.Validar())
            {
               if (Client.SaveCajaCuentas(m_ItemCajaCuentas))
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
      public void Actualizar()
      {
         try
         {
            ItemCajaCuentas = null;
            ItemsCajaCuentas = null;
            _DT  = Client.GetAllCajaCuentas();
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
      public IPRO009LView LView { get; set; }
      public IPRO009MView MView { get; set; }
      #endregion


   }
}
