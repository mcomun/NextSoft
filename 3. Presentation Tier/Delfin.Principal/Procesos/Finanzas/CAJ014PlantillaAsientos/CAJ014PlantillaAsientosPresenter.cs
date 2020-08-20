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



namespace Delfin.Principal
{
   public partial class CAJ014PlantillaAsientosPresenter
   {
      #region [ Variables ]
      public String Title = "Pantillas de Asientos";
      public String CUS = "CAJ014";

      #endregion

      #region [ Constructor ]
      public CAJ014PlantillaAsientosPresenter(IUnityContainer x_container, ICAJ014PlantillaAsientosLView x_lview)
      {
         try
         {
            this.ContainerService = x_container;
            Session = this.ContainerService.Resolve<ISessionService>();
            this.LView = x_lview;
         }
         catch (Exception)
         { throw; }
      }

      public void Load()
      {
         try
         {
            Client = ContainerService.Resolve<IDelfinServices>();

            DTPeriodos = new System.Data.DataTable();
            ObservableCollection<Infrastructure.Aspect.DataAccess.DataAccessFilterSQL> _listFilters = new ObservableCollection<Infrastructure.Aspect.DataAccess.DataAccessFilterSQL>();
            DTPeriodos = Client.GetDTAnexos("CAJ_CCCTSS_Periodos", _listFilters);
            
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

      public ICAJ014PlantillaAsientosLView LView { get; set; }
      public ICAJ014PlantillaAsientosMView MView { get; set; }

      public CabPerfilAsientos Item { get; set; }
      public ObservableCollection<CabPerfilAsientos> Items { get; set; }

      public System.Data.DataTable DTPeriodos { get; set; }

      #endregion

      #region [ Metodos ]

      public String F_CABP_Ano { get; set; }
      public String F_CABP_Codigo { get; set; }
      public String F_TIPO_CodREG { get; set; }

      public void Actualizar()
      {
         try
         {
            Item = null;
            Items = null;

            if (LView != null)
            {
               ObservableCollection<Infrastructure.Aspect.DataAccess.DataAccessFilterSQL> _listFilters = new ObservableCollection<Infrastructure.Aspect.DataAccess.DataAccessFilterSQL>();
               _listFilters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@pchrCABP_Ano", FilterValue = F_CABP_Ano, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.Char, FilterSize = 4 });
               _listFilters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@pvchCABP_Codigo", FilterValue = F_CABP_Codigo, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.Varchar, FilterSize = 3 });
               _listFilters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@pchrTIPO_CodREG", FilterValue = F_TIPO_CodREG, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.Char, FilterSize = 3 });

               Items = Client.GetAllCabPerfilAsientosFilter("CON_CABPSS_TodosBusqueda", _listFilters);

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
               MView = new CAJ014PlantillaAsientosMView();
               MView.Presenter = this;
               MView.LoadView();
            }

            MView.ClearItem();
            this.Item = new CabPerfilAsientos();
            this.Item.ListDetPerfilAsientos = new ObservableCollection<DetPerfilAsientos>();
            this.Item.ListDetPerfilAsientosEliminados = new ObservableCollection<DetPerfilAsientos>();
            this.Item.AUDI_UsrCrea = Session.UserName;
            this.Item.AUDI_FecCrea = Session.Fecha;
            this.Item.Instance = Infrastructure.Aspect.BusinessEntity.InstanceEntity.Added;
            MView.SetItem();

            isMViewShow = true;
            ((CAJ014PlantillaAsientosMView)MView).Show();
            ((CAJ014PlantillaAsientosMView)MView).BringToFront();

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
               MView = new CAJ014PlantillaAsientosMView();
               MView.Presenter = this;
               MView.LoadView();
            }

            Item = Client.GetOneCabPerfilAsientos(Item.CABP_Ano, Item.CABP_Codigo);

            if (Item != null)
            {
               MView.ClearItem();
               this.Item.AUDI_UsrMod = Session.UserName;
               this.Item.AUDI_FecMod = Session.Fecha;
               this.Item.Instance = Infrastructure.Aspect.BusinessEntity.InstanceEntity.Modified;
               MView.SetItem();

               isMViewShow = true;
               ((CAJ014PlantillaAsientosMView)MView).Show();
               ((CAJ014PlantillaAsientosMView)MView).BringToFront();
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
                      Entities.CabPerfilAsientos _item = Item;
                      if (Client.SaveCabPerfilAsientos(ref _item))
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
          }
      }

      public void EliminarDetalle(Entities.DetPerfilAsientos x_item)
      {
         try
         {
            if (Infrastructure.WinForms.Controls.Dialogos.MostrarMensajePregunta(Title, "¿Desea perder eliminar el registro seleccionado?", Infrastructure.WinForms.Controls.Dialogos.LabelBoton.Si_No) == System.Windows.Forms.DialogResult.Yes)
            {
                if (x_item.Instance != Infrastructure.Aspect.BusinessEntity.InstanceEntity.Added)
               { Item.ListDetPerfilAsientosEliminados.Add(x_item); }
               Item.ListDetPerfilAsientos.Remove(x_item);
               MView.ShowItems();
            }
         }
         catch (Exception)
         { throw; }
      }
      public bool Guardar(Boolean ShowMessage)
      {
         try
         {
            MView.GetItem();
            Entities.CabPerfilAsientos _item = Item;
             
            if (Item.Validar())
            {
               if (Client.SaveCabPerfilAsientos(ref _item))
               {
                  Item = _item;
                  if (ShowMessage) { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeSatisfactorio(Title, "Se ha guardado satisfactoriamente"); }
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
               ((CAJ014PlantillaAsientosMView)MView).BringToFront();
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
         { ((CAJ014PlantillaAsientosMView)MView).Close(); }
      }
      public void IsClosedMView()
      { isMViewShow = false; }

      #endregion

      #region [ Metodos Eventos/Tareas ]

      
      #endregion
   }
}