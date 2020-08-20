using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Practices.Unity;
using Delfin.ServiceContracts;
using Delfin.ServiceProxy;
using Delfin.Entities;
using Infrastructure.Aspect;
using Infrastructure.Aspect.Collections;
using Infrastructure.Client.Services.Session;
using System.Collections.ObjectModel;

namespace Delfin.Principal
{
   public class COM002Presenter
   {
      #region [ Variables ]
      public String Title = "Re-Asignación de Prospectos";
      public String CUS = "COM002";
      #endregion

      #region [ Contrusctor ]
      public COM002Presenter(IUnityContainer x_container, ICOM002LView x_lview)
      {
         try
         {
            this.ContainerService = x_container;
            Session = this.ContainerService.Resolve<ISessionService>();
            this.LView = x_lview;
            //this.MView = x_mview;
         }
         catch (Exception)
         { throw; }
      }
      public void Load()
      {
         try
         {
            Client = ContainerService.Resolve<IDelfinServices>();
            
            LView.LoadView();
            //MView.LoadView();
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Title, "Ha ocurrido un error inicializando la vista.", ex); }
      }
      #endregion

      #region [ Propiedades ]
      public IUnityContainer ContainerService { get; set; }
      public ISessionService Session { get; set; }
      public IDelfinServices Client { get; set; }

      public ICOM002LView LView { get; set; }
      //public ICOM001MView MView { get; set; }

      public Prospecto Item { get; set; }
      public ObservableCollection<Prospecto> Items { get; set; }

      public Entidad ItemEjecutivoActual { get; set; }
      public Entidad ItemAgenteCarga { get; set; }
      public Nullable<DateTime> FechaAsignacion { get; set; }
      public Entidad ItemEjecutivoNuevo { get; set; }
      #endregion

      #region [ Metodos ]
      public void CargarProspectos()
      {
         try
         {
            if (ItemEjecutivoActual != null)
            {
               if (FechaAsignacion.HasValue)
               { 
                  if (ItemAgenteCarga != null)
                  { Items = Client.GetAllProspectosByEjecutivo(Controls.Entorno.ItemEmpresa.EMPR_Codigo, Controls.Entorno.ItemSucursal.SUCR_Codigo, ItemEjecutivoActual.ENTC_Codigo, ItemAgenteCarga.ENTC_Codigo, FechaAsignacion.Value, null, null); }
                  else
                  { Items = Client.GetAllProspectosByEjecutivo(Controls.Entorno.ItemEmpresa.EMPR_Codigo, Controls.Entorno.ItemSucursal.SUCR_Codigo, ItemEjecutivoActual.ENTC_Codigo, null, FechaAsignacion.Value, null, null); }

                  LView.ShowItems(true);
               }
               else
               { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Title, "Debe seleccionar una Fecha de Asignación."); LView.ShowItems(false); }
            }
            else
            { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Title, "Debe seleccionar un Ejecutivo."); LView.ShowItems(false); }
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Title, "Ha ocurrido un error al cargar los prospectos.", ex); }
      }
      public void AsignarEjecutivo()
      {
         try
         {
            if (ItemEjecutivoNuevo != null)
            {
               ObservableCollection<Prospecto> _itemsSeleccionados = Items.Where(pros => pros.PROS_Asignar).ToObservableCollection();
               foreach (Prospecto _itemSeleccionado in _itemsSeleccionados)
               {
                  _itemSeleccionado.ENTC_CodEjecutivo = ItemEjecutivoNuevo.ENTC_Codigo;
                  _itemSeleccionado.ENTC_NomCompletoEjecutivo = ItemEjecutivoNuevo.ENTC_NomCompleto;
               }

               Int16 _EMPR_Codigo = Controls.Entorno.ItemEmpresa.EMPR_Codigo;
               Int16 _SUCR_Codigo = Controls.Entorno.ItemSucursal.SUCR_Codigo;
               DateTime _PROS_FecAsignacion = Session.Fecha;
               String _AUDI_Usuario = Session.UserName;
               Client.ReAsignarProspectos(_itemsSeleccionados.ToTableValuedParameter(), _EMPR_Codigo, _SUCR_Codigo, _PROS_FecAsignacion, _AUDI_Usuario);

               Items = Items.Where(pros => !pros.PROS_Asignar).ToObservableCollection();
               LView.ShowItems(true);
            }
            else
            { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Title, "Debe seleccionar un Ejecutivo."); }
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Title, "Ha ocurrido un error al asignar el Ejecutivo.", ex); }
      }
      #endregion
   }
}
