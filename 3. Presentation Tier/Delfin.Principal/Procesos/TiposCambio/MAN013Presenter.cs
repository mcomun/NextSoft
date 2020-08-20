using System;
using System.Diagnostics;
using System.Windows.Forms;
using Infrastructure.Aspect.BusinessEntity;
using Microsoft.Practices.Unity;
using Delfin.ServiceProxy;
using Delfin.Entities;
using Infrastructure.Client.Services.Session;
using System.Collections.ObjectModel;
using Infrastructure.WinFormsControls;
using Infrastructure.Aspect.Constants;
using System.Data;

namespace Delfin.Principal
{
   public class MAN013Presenter
   {
      #region [ Variables ]
      public String Title = "Tipos de Cambio";
      public String CUS = "MAN013";
      public String _FiltroTC="";
      private TiposCambio m_ItemTiposCambio;
      private ObservableCollection<TiposCambio> m_ItemsTiposCambio;

      public ObservableCollection<TiposCambio> ItemsTiposCambio
      {
         get { return m_ItemsTiposCambio; }
         set { m_ItemsTiposCambio = value; }
      }
      public TiposCambio ItemTiposCambio { get; set; }

      #endregion


      #region [ Propiedades ]
      public IUnityContainer ContainerService { get; set; }
      public ISessionService Session { get; set; }
      public Delfin.ServiceContracts.IDelfinServices Client { get; set; }

      public IMAN013LView LView { get; set; }
      public IMAN013MView MView { get; set; }
      #endregion

      #region [ Constructor ]
      public MAN013Presenter(IUnityContainer x_container, IMAN013LView x_lview, IMAN013MView x_mview)
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
      public void Load()
      {
         try
         {
            Client = ContainerService.Resolve<Delfin.ServiceContracts.IDelfinServices>();
            LView.LoadView();
         }
         catch (Exception ex)
         { Dialogos.MostrarMensajeError(Title, Mensajes.LoadPresenter, ex); }
      }

      public void Nuevo(String _Fecha)
      {
         try
         {
            _FiltroTC = _Fecha;
            MView.ClearItem();
            ItemTiposCambio = new TiposCambio 
            {
               AUDI_UsrCrea = Session.UserName,
               AUDI_FecCrea = Session.Fecha,
               Instance = InstanceEntity.Added,
            };
            MView.SetFecha(Client.GetFecha());
            ((MAN013MView)MView).ShowDialog();
         }
         catch (Exception ex)
         { Dialogos.MostrarMensajeError(Title, Mensajes.NewPresenter, ex); }
      }

      public void ValidaExistente(String _Fecha)
      {
         ItemTiposCambio = Client.GetOneTiposCambio(_Fecha);
         if (ItemTiposCambio != null)
         {
            ItemTiposCambio.AUDI_UsrMod = Session.UserName;
            ItemTiposCambio.AUDI_FecMod = Session.Fecha;
            ItemTiposCambio.Instance = InstanceEntity.Modified;
            MView.SetItem();
         }
         else
         {
            ItemTiposCambio = new TiposCambio
            {
               AUDI_UsrCrea = Session.UserName,
               AUDI_FecCrea = Session.Fecha,
               Instance = InstanceEntity.Added,
            };
         }
      }

      public void Editar(String _Fecha)
      {
         try
         {
            _FiltroTC = _Fecha; 
            if (ItemTiposCambio != null)
            {
               string l_fechaBuscar = ItemTiposCambio.TIPC_Fecha;
               MView.ClearItem();
               /* Encabezado  :) */
               /*ItemTiposCambio = Client.GetOneTiposCambio(ItemTiposCambio.TIPC_Fecha);*/
               ItemTiposCambio = Client.GetOneTiposCambio(l_fechaBuscar);
               ItemTiposCambio.AUDI_UsrMod = Session.UserName;
               ItemTiposCambio.AUDI_FecMod = Session.Fecha;
               ItemTiposCambio.Instance = InstanceEntity.Modified;
               MView.SetItem();

               /* Detalle Tarjas :) */
               ((MAN013MView)MView).ShowDialog();
            }
            else
            { Dialogos.MostrarMensajeInformacion(Title, "Debe seleccionar un elemento de la grilla"); }
         }
         catch (Exception ex)
         { Dialogos.MostrarMensajeError(Title, Mensajes.EditPresenter, ex); }
      }

      public void Eliminar(String _Fecha)
      {
         try
         {
            if (ItemTiposCambio != null)
            {
               DialogResult result = Dialogos.MostrarMensajePregunta(Title, Mensajes.PreguntaEliminar, Dialogos.LabelBoton.Si_No);
               if (result == DialogResult.Yes)
               {
                  ItemTiposCambio.Instance = InstanceEntity.Deleted;
                  if (Client.SaveTiposCambio(ItemTiposCambio))
                  {
                     Dialogos.MostrarMensajeSatisfactorio(Title, "Se ha eliminado el item.");
                     Actualizar(_Fecha);
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

      public void Actualizar(String _Fecha)
      {
         ItemsTiposCambio = Client.GetAllTiposCambio(_Fecha);
         LView.ShowItems(); 
      }

      public bool Guardar()
      {
         try
         {
            MView.GetItem();
            if (Client.SaveTiposCambio(ItemTiposCambio))
            {
               Dialogos.MostrarMensajeSatisfactorio(Title, "Se ha guardado satisfactoriamente");
               Actualizar(_FiltroTC);
               return true;
            }
            else
            {
               Dialogos.MostrarMensajeSatisfactorio(Title, "Ha ocurrido un problema al guardar el Tipo de Cambio");
               return false;
            }
         }
         catch (Exception ex)
         {
            Dialogos.MostrarMensajeError(Title, Mensajes.SavePresenter, ex);
            return false;
         }
      }
      
      #endregion
   }
}
