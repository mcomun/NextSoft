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


namespace Delfin.Principal
{
   public partial class MAN016FlujosPresenter
   {
      #region [ Variables ]
      public String Title = "Maestro de Flujos";
      public String CUS = "MAN016";
      public Boolean FleteNegativo = false;
      #endregion

      #region [ Contrusctor ]
       public MAN016FlujosPresenter(IUnityContainer x_container, IMAN016FlujosLView x_lview, IMAN016FlujosMView x_mview)
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
     
      public void Load()
      {
         try
         {
            Client = ContainerService.Resolve<IDelfinServices>();
            
            LView.LoadView();
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Title, "Ha ocurrido un error inicializando la vista.", ex); }
      }
      #endregion

      #region [ Propiedades ]
      public IUnityContainer ContainerService { get; set; }
      public ISessionService Session { get; set; }
      public IDelfinServices Client { get; set; }
      
      public IMAN016FlujosLView LView { get; set; }
      public IMAN016FlujosMView MView { get; set; }

      public Flujo Item { get; set; }
      public ObservableCollection<Flujo> Items { get; set; }

      public String F_TIPO_Flujo { get; set; }
      public String F_TIPO_Movimiento { get; set; }


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
                ObservableCollection<Infrastructure.Aspect.DataAccess.DataAccessFilterSQL> _listFilters = new ObservableCollection<Infrastructure.Aspect.DataAccess.DataAccessFilterSQL>();
                _listFilters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@F_TIPO_Flujo", FilterValue = F_TIPO_Flujo, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.Char, FilterSize = 1 });
                _listFilters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@F_TIPO_Movimiento", FilterValue = F_TIPO_Movimiento, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.Char, FilterSize = 1 });
                Items = Client.GetAllFlujoFilter("CAJ_FLUJSS_Todos_ByFilters", _listFilters);

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
                  MView = new MAN016FlujosMView();
                  MView.Presenter = this;
                  MView.LoadView();
               }

               MView.ClearItem();
               this.Item = new Flujo();
               this.Item.EMPR_Codigo = Controls.Entorno.ItemEmpresa.EMPR_Codigo;
               this.Item.AUDI_UsrCrea = Session.UserName;
               this.Item.AUDI_FecCrea = Session.Fecha;
               this.Item.Instance = Infrastructure.Aspect.BusinessEntity.InstanceEntity.Added;
               MView.SetItem();

               isMViewShow = true;
               ((MAN016FlujosMView)MView).ShowDialog();
               ((MAN016FlujosMView)MView).BringToFront();
            
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
               MView = new MAN016FlujosMView();
               MView.Presenter = this;
               MView.LoadView();
            }

            Item = Client.GetOneFlujo(Delfin.Controls.Entorno.ItemEmpresa.EMPR_Codigo,Item.FLUJ_Codigo);

            if (Item != null)
            {
               MView.ClearItem();
               this.Item.AUDI_UsrMod = Session.UserName;
               this.Item.AUDI_FecMod = Session.Fecha;
               this.Item.Instance = Infrastructure.Aspect.BusinessEntity.InstanceEntity.Modified;
               MView.SetItem();

               isMViewShow = true;
               ((MAN016FlujosMView)MView).ShowDialog();
               ((MAN016FlujosMView)MView).BringToFront();
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
                  System.Windows.Forms.DialogResult _result =
                      Infrastructure.WinForms.Controls.Dialogos.MostrarMensajePregunta(Title,
                          Infrastructure.Aspect.Constants.Mensajes.PreguntaEliminar,
                          Infrastructure.WinForms.Controls.Dialogos.LabelBoton.Si_No);
                  if (_result == System.Windows.Forms.DialogResult.Yes)
                  {
                      Item.Instance = Infrastructure.Aspect.BusinessEntity.InstanceEntity.Deleted;
                      Entities.Flujo _item = Item;
                      if (Client.SaveFlujo(ref _item))
                      {
                          Actualizar();
                          Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeSatisfactorio(Title,
                              "Se ha eliminado el item.");
                      }
                      else
                      {
                          Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Title,
                              "Ha ocurrido un error al guardar el item.");
                      }
                  }
              }
              else
              {
                  Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Title,
                      "Debe seleccionar un elemento de la grilla");
              }
          }
          catch (Exception ex)
          {
              string errorMsg = Delfin.Controls.Utils.getErrorMsg(ex);
              Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Title, errorMsg, ex);
              //Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Title, Infrastructure.Aspect.Constants.Mensajes.DeletePresenter, ex);
          }
      }
      public bool Guardar(Boolean ShowMessage)
      {
         try
         {
            MView.GetItem();
            FleteNegativo = false; 
            if (Item.Validar())
            {
                Boolean m_isAdded = (Item.Instance == Infrastructure.Aspect.BusinessEntity.InstanceEntity.Added);
                Entities.Flujo _item = Item;
                if (Client.SaveFlujo(ref _item))
                {
                   return true;
                }
                
               
               
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
      public System.Windows.Forms.DialogResult GuardarCambios()
      {
         try
         {
            if (this.Item != null)
            {
               ((MAN016FlujosMView)MView).BringToFront();
               System.Windows.Forms.DialogResult _result = Infrastructure.WinForms.Controls.Dialogos.MostrarMensajePregunta(Title, Infrastructure.Aspect.Constants.Mensajes.SaveChangesPreguntaPresenter, Infrastructure.WinForms.Controls.Dialogos.LabelBoton.Si_No);
               if (_result == System.Windows.Forms.DialogResult.Yes)
               {
                  if (Guardar(true))
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
         { ((MAN016FlujosMView)MView).Close(); }
      }
      public void IsClosedMView()
      { isMViewShow = false; }

      #endregion

      
      #region [ Metodos Eventos/Tareas ]
      
      #endregion
   }
}