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
using System.IO;

using System.Configuration;
using System.Net;
using System.Runtime.Serialization.Json;


namespace Delfin.Comercial
{
   public partial class CAJ016FacturacionPresenter
   {
      #region [ Variables ]
      public String Title = "Template";
      public String CUS = "CAJ016Facturacion";
      public Boolean FleteNegativo = false;
      #endregion

      #region [ Contrusctor ]
      public CAJ016FacturacionPresenter(IUnityContainer x_container, ICAJ016FacturacionLView x_lview, ICAJ016FacturacionMView x_mview, Int16 x_CCOT_Tipo)
      {
         try
         {
            this.ContainerService = x_container;
            Session = this.ContainerService.Resolve<ISessionService>();
            this.LView = x_lview;
            this.MView = x_mview;
            
         }
         catch (Exception)
         { throw; }
      }
      public CAJ016FacturacionPresenter(IUnityContainer x_container, ICAJ016FacturacionMView x_mview, Int16 x_CCOT_Tipo)
      {
         try
         {
            this.ContainerService = x_container;
            Session = this.ContainerService.Resolve<ISessionService>();
            this.MView = x_mview;
            this.CCOT_Tipo = x_CCOT_Tipo;
         }
         catch (Exception)
         { throw; }
      }
      public void Load()
      {
         try
         {
            Client = ContainerService.Resolve<IDelfinServices>();
            

            //Infrastructure.WinForms.Controls.ComboBox.ComboxBoxItem.AddComboBoxItem("I", "Ingreso", true);
            //Infrastructure.WinForms.Controls.ComboBox.ComboxBoxItem.AddComboBoxItem("E", "Egreso");
            //ListIngresoEgreso = Infrastructure.WinForms.Controls.ComboBox.ComboxBoxItem.GetComboBoxItems();
           
            MView.LoadView(CCOT_Tipo);
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Title, "Ha ocurrido un error inicializando la vista.", ex); }
      }
      #endregion

      #region [ Propiedades ]
      public IUnityContainer ContainerService { get; set; }
      public ISessionService Session { get; set; }
      public IDelfinServices Client { get; set; }
      

      public Int16 CCOT_Tipo { get; set; }

      public ICAJ016FacturacionLView LView { get; set; }
      public ICAJ016FacturacionMView MView { get; set; }

      public Cab_Cotizacion_OV Item { get; set; }
      public ObservableCollection<Cab_Cotizacion_OV> Items { get; set; }

      #endregion

      #region [ Metodos ]
      
      public void Actualizar()
      {
         try
         {
            Item = null;
            Items = null;

            if (LView != null)
            {
               //String CONS_TabRGM = null; if (FILTROItemCONSRGM != null) { CONS_TabRGM = FILTROItemCONSRGM.CONS_CodTabla; }
               //String CONS_CodRGM = null; if (FILTROItemCONSRGM != null) { CONS_CodRGM = FILTROItemCONSRGM.CONS_CodTipo; }
               //String CONS_TabFLE = null; if (FILTROItemCONSFLE != null) { CONS_TabFLE = FILTROItemCONSFLE.CONS_CodTabla; }
               
               //Items = Client.GetAllCab_Cotizacion_OVByFiltro(Delfin.Controls.Entorno.ItemEmpresa.EMPR_Codigo, Delfin.Controls.Entorno.ItemSucursal.SUCR_Codigo, CCOT_Tipo, CONS_TabRGM, CONS_CodRGM, CONS_TabFLE, CONS_CodFLE, CONS_TabVia, CONS_CodVia, CONS_TabEST, CONS_CodEST, ENTC_CodEjecutivo, ENTC_CodCustomer, ENTC_CodAgente, ENTC_CodBroker, ENTC_CodCliente, CCOT_FecEmiDesde, CCOT_FecEmiHasta, CCOT_NumDoc, DOOV_HBL);

               LView.ShowItems();
            }
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Title, "Ha ocurrido un error actualizando.", ex); }
      }

      
      Boolean isMViewShow = false;
      public void Nuevo()
      {
         try
         {
               if (!isMViewShow)
               {
                  MView = new CAJ016FacturacionMView();
                  MView.Presenter = this;
                  MView.LoadView(this.CCOT_Tipo);
               }

               MView.ClearItem();
               this.Item = new Cab_Cotizacion_OV();
               this.Item.CCOT_Tipo = CCOT_Tipo;
               this.Item.CCOT_Version = 1;
               this.Item.CCOT_FecEmi = Session.Fecha;
               this.Item.EMPR_Codigo = Controls.Entorno.ItemEmpresa.EMPR_Codigo;
               this.Item.SUCR_Codigo = Controls.Entorno.ItemSucursal.SUCR_Codigo;
               this.Item.AUDI_UsrCrea = Session.UserName;
               this.Item.AUDI_FecCrea = Session.Fecha;
               this.Item.Instance = Infrastructure.Aspect.BusinessEntity.InstanceEntity.Added;
               MView.SetItem();

               isMViewShow = true;
               ((CAJ016FacturacionMView)MView).Show();
               ((CAJ016FacturacionMView)MView).BringToFront();
            
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Title, Infrastructure.Aspect.Constants.Mensajes.NewPresenter, ex); }
      }
      public void Editar()
      {
         try
         {
            if (!isMViewShow)
            {
               MView = new CAJ016FacturacionMView();
               MView.Presenter = this;
               MView.LoadView(this.CCOT_Tipo);
            }

            Item = Client.GetOneCab_Cotizacion_OV(Delfin.Controls.Entorno.ItemEmpresa.EMPR_Codigo, Delfin.Controls.Entorno.ItemSucursal.SUCR_Codigo, Item.CCOT_Numero, Item.CCOT_Tipo);

            if (Item != null)
            {
               MView.ClearItem();
               this.Item.AUDI_UsrMod = Session.UserName;
               this.Item.AUDI_FecMod = Session.Fecha;
               this.Item.Instance = Infrastructure.Aspect.BusinessEntity.InstanceEntity.Modified;
               MView.SetItem();

               isMViewShow = true;
               ((CAJ016FacturacionMView)MView).Show();
               ((CAJ016FacturacionMView)MView).BringToFront();
            }
            else
            { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Title, "Debe seleccionar un elemento de la grilla"); }
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Title, Infrastructure.Aspect.Constants.Mensajes.EditPresenter, ex); }
      }
      

      public void Eliminar()
      {
         try
         {
            if (Item != null)
            {
               System.Windows.Forms.DialogResult _result = Infrastructure.WinForms.Controls.Dialogos.MostrarMensajePregunta(Title, Infrastructure.Aspect.Constants.Mensajes.PreguntaEliminar, Infrastructure.WinForms.Controls.Dialogos.LabelBoton.Si_No);
               if (_result == System.Windows.Forms.DialogResult.Yes)
               {
                  Item.Instance = Infrastructure.Aspect.BusinessEntity.InstanceEntity.Deleted;
                  Item = Client.SaveCab_Cotizacion_OV(Item);
                  if (Item != null)
                  {
                     Actualizar();
                     Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeSatisfactorio(Title, "Se ha eliminado el item.");
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
      public bool Guardar(Boolean EsProspecto, Boolean ShowMessage)
      {
         try
         {
            MView.GetItem();
            FleteNegativo = false; 
            if (Item.Validar(ref FleteNegativo))
            {
               if (Item.CCOT_Tipo == Delfin.Controls.variables.CCOT_TipoCotizacion && (Item.CONS_CodEST == Delfin.Controls.variables.CONS_ESTCOTCONFIRMADA || Item.CONS_CodEST == Delfin.Controls.variables.CONS_ESTCOTANULADA))
               { return true; }
               if (Item.CCOT_Tipo == Delfin.Controls.variables.CCOT_TipoOrdenVenta && (Item.CONS_CodEST == Delfin.Controls.variables.CONS_ESTOVECONCLUIDA || Item.CONS_CodEST == Delfin.Controls.variables.CONS_ESTOVEANULADA)) //Item.CONS_CodEST == Delfin.Controls.variables.CONS_ESTOVECONFIRMADA || 
               { return true; }

               if (Item.CCOT_Tipo == Delfin.Controls.variables.CCOT_TipoOrdenVenta && EsProspecto)
               {
                  Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Title, "Debe actualizar la información del Cliente para poder crearle una Orden de Venta.");
                  return false; 
               }
               if (FleteNegativo == true)
               {
                   Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Title, "La Orden de Venta tiene un Profit Negativo.");
                   //return true;
               }

               Boolean m_isAdded = (Item.Instance == Infrastructure.Aspect.BusinessEntity.InstanceEntity.Added);
               Item = Client.SaveCab_Cotizacion_OV(Item);
               
            }
            else
            {
               MView.ShowValidation();
               return false;
            }
            return false;
         }
         catch (Exception ex)
         {
            Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Title, Infrastructure.Aspect.Constants.Mensajes.SavePresenter, ex);
            return false;
         }
      }
      public System.Windows.Forms.DialogResult GuardarCambios(Boolean EsProspecto)
      {
         try
         {
            if (this.Item != null)
            {
               if (Item.CCOT_Tipo == Delfin.Controls.variables.CCOT_TipoCotizacion && (Item.CONS_CodEST == Delfin.Controls.variables.CONS_ESTCOTCONFIRMADA || Item.CONS_CodEST == Delfin.Controls.variables.CONS_ESTCOTANULADA))
               { return System.Windows.Forms.DialogResult.No; }
               if (Item.CCOT_Tipo == Delfin.Controls.variables.CCOT_TipoOrdenVenta && (Item.CONS_CodEST == Delfin.Controls.variables.CONS_ESTOVECONFIRMADA || Item.CONS_CodEST == Delfin.Controls.variables.CONS_ESTOVECONCLUIDA || Item.CONS_CodEST == Delfin.Controls.variables.CONS_ESTOVEANULADA))
               { return System.Windows.Forms.DialogResult.No; }

               ((CAJ016FacturacionMView)MView).BringToFront();
               System.Windows.Forms.DialogResult _result = Infrastructure.WinForms.Controls.Dialogos.MostrarMensajePregunta(Title, Infrastructure.Aspect.Constants.Mensajes.SaveChangesPreguntaPresenter, Infrastructure.WinForms.Controls.Dialogos.LabelBoton.Si_No);
               if (_result == System.Windows.Forms.DialogResult.Yes)
               {
                  if (Guardar(EsProspecto, true))
                  { return System.Windows.Forms.DialogResult.Yes; }
                  else
                  { return System.Windows.Forms.DialogResult.Cancel; }
               }
               else
               { return _result; }
            }
            else
            {
               Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Title, "Ha ocurrido un error al cerrar el formulario.");
               return System.Windows.Forms.DialogResult.Cancel;
            }
         }
         catch (Exception ex)
         {
            Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Title, Infrastructure.Aspect.Constants.Mensajes.SavePresenter, ex);
            return System.Windows.Forms.DialogResult.Cancel;
         }
      }

      public void CloseView()
      {
         if (isMViewShow)
         { ((CAJ016FacturacionMView)MView).Close(); }
      }
      public void IsClosedMView()
      { isMViewShow = false; }

      public Boolean VerificarPemisoEdicion()
      {
         try
         {
            //NextAdmin.Entities.PermisosUsuarioProcesos _itemPermisosUsuarioProcesos = ClientNextAdmin.GetOnePermisosUsuarioProcesosByUsuario(Session.AplicacionCodigo.Value, Session.UserCodigo, Delfin.Controls.variables.CCOT_EDITARCOTIZ);
            //if (_itemPermisosUsuarioProcesos != null && _itemPermisosUsuarioProcesos.PUPR_Codigo > 0)
            //{ return true; }
            //else
            //{ return false; }
            return true;
         }
         catch (Exception)
         { return false; }
      }
      #endregion

      
      #region [ Metodos Eventos/Tareas ]
      
      #endregion
   }
}