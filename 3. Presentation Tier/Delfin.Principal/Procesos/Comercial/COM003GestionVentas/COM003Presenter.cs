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
   public class COM003Presenter
   {
      #region [ Variables ]
      public String Title = "Gestión de Ventas";
      public String CUS = "COM003";
      #endregion

      #region [ Contrusctor ]
      public COM003Presenter(IUnityContainer x_container, ICOM003LView x_lview)
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

            ListResultGestion = Client.GetAllResultGestion().Where(resg => resg.RESG_Activo).ToObservableCollection();

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

      public ICOM003LView LView { get; set; }
      //public ICOM003MView MView { get; set; }

      public Prospecto Item { get; set; }
      public ObservableCollection<Prospecto> Items { get; set; }

      public Entidad ItemEjecutivo { get; set; }
      public Entidad ItemAgenteCarga { get; set; }
      public Nullable<DateTime> FechaProximaGestion { get; set; }
      
      public ObservableCollection<ResultGestion> ListResultGestion { get; set; }
      #endregion

      #region [ Metodos ]
      public void CargarProspectos(Int32 FiltroCodigo)
      {
         try
         {
            if (ItemEjecutivo != null)
            {
               switch (FiltroCodigo)
               {
                  case 1:
                     if (ItemAgenteCarga != null)
                     { Items = Client.GetAllProspectosByEjecutivoGestionVentas(Controls.Entorno.ItemEmpresa.EMPR_Codigo, Controls.Entorno.ItemSucursal.SUCR_Codigo, ItemEjecutivo.ENTC_Codigo, ItemAgenteCarga.ENTC_Codigo, null); }
                     else
                     { Items = Client.GetAllProspectosByEjecutivoGestionVentas(Controls.Entorno.ItemEmpresa.EMPR_Codigo, Controls.Entorno.ItemSucursal.SUCR_Codigo, ItemEjecutivo.ENTC_Codigo, null, null); }
                     LView.ShowItems(true);
                     break;
                  case 2:
                     if (FechaProximaGestion.HasValue)
                     {
                        if (FechaProximaGestion.HasValue)
                        {
                           if (ItemAgenteCarga != null)
                           { Items = Client.GetAllProspectosByEjecutivoGestionVentas(Controls.Entorno.ItemEmpresa.EMPR_Codigo, Controls.Entorno.ItemSucursal.SUCR_Codigo, ItemEjecutivo.ENTC_Codigo, ItemAgenteCarga.ENTC_Codigo, FechaProximaGestion.Value); }
                           else
                           { Items = Client.GetAllProspectosByEjecutivoGestionVentas(Controls.Entorno.ItemEmpresa.EMPR_Codigo, Controls.Entorno.ItemSucursal.SUCR_Codigo, ItemEjecutivo.ENTC_Codigo, null, FechaProximaGestion.Value); }
                           LView.ShowItems(true);
                        }
                        else
                        { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Title, "Debe seleccionar una Fecha de Asignación."); LView.ShowItems(false); }
                     }
                     else
                     { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Title, "Debe seleccionar una Fecha de Asignación."); LView.ShowItems(false); }
                     break;
               }
            }
            else
            { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Title, "Debe seleccionar un Ejecutivo."); LView.ShowItems(false); }
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Title, "Ha ocurrido un error al cargar los prospectos.", ex); }
      }
      public void NuevaGestionVentas()
      {
         try
         {
            if (Item != null)
            {
               LView.ClearItemGestionVentas();
               Item.ItemGestionVentas = new GestionVentas();
               Item.ItemGestionVentas.EMPR_Codigo = Controls.Entorno.ItemEmpresa.EMPR_Codigo;
               Item.ItemGestionVentas.SUCR_Codigo = Controls.Entorno.ItemSucursal.SUCR_Codigo;
               Item.ItemGestionVentas.GEST_Fecha = Session.Fecha;
               Item.ItemGestionVentas.PROS_codigo = Item.PROS_codigo;
               Item.ItemGestionVentas.ENTC_CodCliente = Item.ENTC_CodCliente;
               Item.ItemGestionVentas.ENTC_CodEjecutivo = ItemEjecutivo.ENTC_Codigo;
               Item.ItemGestionVentas.AUDI_UsrCrea = Session.UserName;
               Item.ItemGestionVentas.AUDI_FecCrea = Session.Fecha;
               Item.ItemGestionVentas.Instance = Infrastructure.Aspect.BusinessEntity.InstanceEntity.Added;

               LView.SetItemGestionVentas();
               LView.HabilitarDatosGestionVentas(true);
            }
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Title, Infrastructure.Aspect.Constants.Mensajes.NewPresenter, ex); }
      }
      public void EditarGestionVentas()
      {
         try
         {
            if (Item != null && Item.ItemGestionVentas != null)
            {
               LView.ClearItemGestionVentas();
               Item.ItemGestionVentas.AUDI_UsrMod = Session.UserName;
               Item.ItemGestionVentas.AUDI_FecMod = Session.Fecha;
               Item.ItemGestionVentas.Instance = Infrastructure.Aspect.BusinessEntity.InstanceEntity.Modified;
               LView.SetItemGestionVentas();
               LView.HabilitarDatosGestionVentas(true);
            }
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Title, Infrastructure.Aspect.Constants.Mensajes.NewPresenter, ex); }
      }
      public void EliminarGestionVentas()
      {
         try
         {
            if (Item != null && Item.ItemGestionVentas != null)
            {
               System.Windows.Forms.DialogResult _result = Infrastructure.WinForms.Controls.Dialogos.MostrarMensajePregunta(Title, Infrastructure.Aspect.Constants.Mensajes.PreguntaEliminar, Infrastructure.WinForms.Controls.Dialogos.LabelBoton.Si_No);
               if (_result == System.Windows.Forms.DialogResult.Yes)
               {
                  Item.Instance = Infrastructure.Aspect.BusinessEntity.InstanceEntity.Deleted;
                  if (Client.SaveGestionVentas(Item.ItemGestionVentas))
                  {
                     Item.ListGestionVentas.Remove(Item.ItemGestionVentas);
                     Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeSatisfactorio(Title, "Se ha eliminado el item.");
                     LView.ShowGestionesProspecto();
                  }
                  else
                  { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Title, "Ha ocurrido un error al guardar el item."); }
               }
            }
            else
            { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Title, "Debe seleccionar un elemento de la grilla"); }
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Title, Infrastructure.Aspect.Constants.Mensajes.DeletePresenter, ex); }
      }
      public void GuardarGestionVentas()
      {
         try
         {
            LView.GetItemGestionVentas();
            if (Item != null && Item.ItemGestionVentas != null)
            {
               if (Item.ItemGestionVentas.Validar())
               {
                  if (Client.SaveGestionVentas(Item.ItemGestionVentas))
                  {
                     Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeSatisfactorio(Title, "Se ha guardado satisfactoriamente");

                     if (Item.ItemGestionVentas.Instance == Infrastructure.Aspect.BusinessEntity.InstanceEntity.Added)
                     { Item.ListGestionVentas.Insert(0, Item.ItemGestionVentas); }
                     LView.ShowGestionesProspecto();
                     LView.SetItemGestionVentas();
                     LView.HabilitarDatosGestionVentas(false);
                  }
                  else
                  { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Title, "Ha ocurrido un error al guardar el item."); }
               }
               else
               {
                  LView.ShowValidation();
               }
            }
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Title, Infrastructure.Aspect.Constants.Mensajes.SavePresenter, ex); }
      }

      public void Contacto(Boolean Nuevo)
      {
         try
         {
            MAN009MView MAN009_mview_sinlv;
            MAN009Presenter MAN009_presenter_sinlv;
            MAN009_mview_sinlv = new MAN009MView();
            MAN009_presenter_sinlv = new MAN009Presenter(ContainerService, MAN009_mview_sinlv, Delfin.Controls.EntidadClear.TIPE_Contacto);
            MAN009_mview_sinlv.Presenter = MAN009_presenter_sinlv;
            MAN009_presenter_sinlv.lsinlview = true;
            MAN009_presenter_sinlv.tipe_Desc = "Contacto";
            MAN009_presenter_sinlv.Load();


            Entities.Entidad _prospecto = Client.GetOneEntidad(Item.ENTC_CodCliente, Delfin.Controls.EntidadClear.GetCodigoTipoEntidad(Controls.TiposEntidad.TIPE_Cliente));
            if (Nuevo)
            {
               if (MAN009_presenter_sinlv.Nuevo() != System.Windows.Forms.DialogResult.Cancel)
               {
                  if (Item.CONS_CodRGM == "001") //Importaciones
                  {
                     _prospecto.AUDI_UsrMod = Session.UserName;
                     _prospecto.AUDI_FecMod = Session.Fecha;
                     _prospecto.Instance = Infrastructure.Aspect.BusinessEntity.InstanceEntity.Modified;

                     _prospecto.ContactoImpo = MAN009_presenter_sinlv.Item;
                     _prospecto.ContactoImpo.AUDI_UsrMod = Session.UserName;
                     _prospecto.ContactoImpo.AUDI_FecMod = Session.Fecha;
                     _prospecto.ContactoImpo.Instance = Infrastructure.Aspect.BusinessEntity.InstanceEntity.Added;


                     Client.SaveEntidad(_prospecto);
                     Item.ItemContacto = MAN009_presenter_sinlv.Item;

                  }
                  else if (Item.CONS_CodRGM == "002") //Exportaciones
                  {
                     _prospecto.AUDI_UsrMod = Session.UserName;
                     _prospecto.AUDI_FecMod = Session.Fecha;
                     _prospecto.Instance = Infrastructure.Aspect.BusinessEntity.InstanceEntity.Modified;

                     _prospecto.ContactoExpo = MAN009_presenter_sinlv.Item;
                     _prospecto.ContactoExpo.AUDI_UsrMod = Session.UserName;
                     _prospecto.ContactoExpo.AUDI_FecMod = Session.Fecha;
                     _prospecto.ContactoExpo.Instance = Infrastructure.Aspect.BusinessEntity.InstanceEntity.Added;

                     Client.SaveEntidad(_prospecto);
                     Item.ItemContacto = MAN009_presenter_sinlv.Item;
                  }
               }
            }
            else
            {
               MAN009_presenter_sinlv.Item = Item.ItemContacto;
               if (MAN009_presenter_sinlv.Editar() != System.Windows.Forms.DialogResult.Cancel)
               { Item.ItemContacto = MAN009_presenter_sinlv.Item; }
            }

            LView.SetItemContacto();

         }
         catch (Exception)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Title, "Ha ocurrido un error al registrar el contacto"); }
      }
      #endregion
   }
}
