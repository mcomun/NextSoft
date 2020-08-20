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
using Infrastructure.WinForms.Controls;
using System.Data;
using Infrastructure.Aspect.Constants;

namespace Delfin.Principal
{
   public class DOC001Presenter
   {
      #region [ Variables ]
      public String Title = "MBL";
      public String CUS = "DOC001";

      private Cab_MBL m_item;
      #endregion

      #region [ Propiedades ]
      public IUnityContainer ContainerService { get; set; }
      public ISessionService Session { get; set; }
      public IDelfinServices Client { get; set; }

      public Boolean HasLView { get; set; }

      public IDOC001LView LView { get; set; }
      public IDOC001MView MView { get; set; }

      public Cab_MBL Item
      {
         get {
            if (m_item == null) { m_item = new Cab_MBL(); }
            return m_item; }
         set { m_item = value; }
      }
      public ObservableCollection<Cab_MBL> Items { get; set; }

      
      public ObservableCollection<Paquete> ListPaquetes { get; set; }
      public ObservableCollection<Tipos> ListTiposCDT { get; set; }
      public ObservableCollection<Tipos> ListTiposPAC { get; set; }
      public ObservableCollection<Tipos> ListTiposIMO { get; set; }
      #endregion

      #region [ Constructor ]
      public DOC001Presenter(IUnityContainer x_container)
      {
         try
         {
            this.ContainerService = x_container;
            Session = this.ContainerService.Resolve<ISessionService>();
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Title, Infrastructure.Aspect.Constants.Mensajes.ConstructorPresenter, ex); }
      }
      public DOC001Presenter(IUnityContainer x_container, IDOC001MView x_mview)
      {
         try
         {
            this.ContainerService = x_container;
            Session = this.ContainerService.Resolve<ISessionService>();
            this.MView = x_mview;

            HasLView = false;
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Title, Infrastructure.Aspect.Constants.Mensajes.ConstructorPresenter, ex); }
      }
      public DOC001Presenter(IUnityContainer x_container, IDOC001LView x_lview, IDOC001MView x_mview)
      {
         try
         {
            this.ContainerService = x_container;
            Session = this.ContainerService.Resolve<ISessionService>();
            this.LView = x_lview;
            this.MView = x_mview;

            HasLView = true;
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Title, Infrastructure.Aspect.Constants.Mensajes.ConstructorPresenter, ex); }
      }
      
      public void Load()
      {
         try
         {
            Client = ContainerService.Resolve<IDelfinServices>();

            ListPaquetes = Client.GetAllPaquete();
            ListTiposCDT = Client.GetAllTiposByTipoCodTabla("CDT");
            ListTiposPAC = Client.GetAllTiposByTipoCodTabla("PAC");
            ListTiposIMO = Client.GetAllTiposByTipoCodTabla("IMO");
            
            
            if (HasLView) { LView.LoadView(); }
            MView.LoadView();
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Title, Infrastructure.Aspect.Constants.Mensajes.LoadPresenter, ex); }
      }
      #endregion

      #region [ Metodos ]
      public void Actualizar()
      {
         try
         {
            Item = null;
            Items = null;

            Items = Client.GetAllCab_MBL();

            if (HasLView) { LView.ShowItems(); }
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Title, "Ha ocurrido un error actualizando.", ex); }
      }

      public void Nuevo()
      {
         try
         {
            MView.ClearItem();
            this.Item = new Cab_MBL();
            this.Item.AUDI_UsrCrea = Session.UserName;
            this.Item.AUDI_FecCrea = Session.Fecha;
            this.Item.Instance = Infrastructure.Aspect.BusinessEntity.InstanceEntity.Added;
            MView.SetItem();

            ((DOC001MView)MView).ShowDialog();
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Title, Infrastructure.Aspect.Constants.Mensajes.NewPresenter, ex); }
      }
      public void Editar(Boolean show = true)
      {
         try
         {
            if (Item != null)
            {
               MView.ClearItem();
               this.Item.AUDI_UsrMod = Session.UserName;
               this.Item.AUDI_FecMod = Session.Fecha;
               this.Item.Instance = Infrastructure.Aspect.BusinessEntity.InstanceEntity.Modified;
               MView.SetItem();

               if (show) { ((DOC001MView)MView).ShowDialog(); }
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
                  if (Client.SaveCab_MBL(ref m_item))
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
      public bool Guardar()
      {
         try
         {
            MView.GetItem();
            if (Item.Validar())
            {
               if (Client.SaveCab_MBL(ref m_item))
               {
                  Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeSatisfactorio(Title, "Se ha guardado satisfactoriamente");

                  Item = Client.GetOneCab_MBLByNumero(m_item.CMBL_Numero);
                  
                  Editar(false);

                  return true;
               }
               else
               {
                  Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Title, "Ha ocurrido un error al guardar el item.");
                  return false;
               }
            }
            else
            {
               MView.ShowValidation();
               return false;
            }
         }
         catch (Exception ex)
         {
            Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Title, Infrastructure.Aspect.Constants.Mensajes.SavePresenter, ex);
            return false;
         }
      }
      public System.Windows.Forms.DialogResult GuardarCambios()
      {
         try
         {
            if (this.Item != null)
            {
               System.Windows.Forms.DialogResult _result = Infrastructure.WinForms.Controls.Dialogos.MostrarMensajePregunta(Title, Infrastructure.Aspect.Constants.Mensajes.SaveChangesPreguntaPresenter, Infrastructure.WinForms.Controls.Dialogos.LabelBoton.Si_No);
               if (_result == System.Windows.Forms.DialogResult.Yes)
               {
                  if (Guardar())
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
      #endregion
   }
}
