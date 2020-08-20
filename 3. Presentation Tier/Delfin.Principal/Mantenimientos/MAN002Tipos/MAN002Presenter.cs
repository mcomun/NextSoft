using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Practices.Unity;
using Delfin.ServiceContracts;
using Delfin.ServiceProxy;
using Delfin.Entities;
using Infrastructure.Client.Services.Session;
using System.Collections.ObjectModel;

namespace Delfin.Principal
{
   public class MAN002Presenter
   {
      #region [ Variables ]
      public String Title = "Mantenimiento de Tipos";
      public String CUS = "MAN002";
      
      #endregion

      #region [ Contrusctor ]
      public MAN002Presenter(IUnityContainer x_container, IMAN002LView x_lview, IMAN002MView x_mview)
      {
         try
         {
            this.ContainerService = x_container;
            Session = this.ContainerService.Resolve<ISessionService>();
            this.LView = x_lview;
            this.MView = x_mview;
         }
         catch (Exception ex)
         { throw ex; }
      }
      public void Load()
      {
         try
         {
            Client = ContainerService.Resolve<IDelfinServices>();

            LView.LoadView();
            MView.LoadView();
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Title, "Ha ocurrido un error inicializando la vista.", ex); }
      }
      #endregion

      #region [ Propiedades ]
   

      public String TipoCodTabla { get; set; }
    
      public IUnityContainer ContainerService { get; set; }
      public ISessionService Session { get; set; }
      public IDelfinServices Client { get; set; }

      public IMAN002LView LView { get; set; }
      public IMAN002MView MView { get; set; }

      public Tipos Item { get; set; }
      public ObservableCollection<Tipos> Items { get; set; }

      public Tipos ItemTabla { get; set; }
      public ObservableCollection<Tipos> ListTabla { get; set; }
      #endregion

      #region [ Metodos ]
      public void GetTabla(string x_TipoCodTabla)
      {
         ListTabla = Client.GetAllTiposByTipoCodTabla(x_TipoCodTabla);
      }
      public void Actualizar()
      {
         try
         {
            Item = null;
            Items = null;
            if (ItemTabla != null)
            { Items = Client.GetAllTiposByTipoCodTabla(ItemTabla.TIPO_CodTipo); }

            LView.ShowItems();
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Title, "Ha ocurrido un error actualizando.", ex); }
      }

      public void Nuevo()
      {
         try
         {
            if (ItemTabla != null)
            {
               MView.ClearItem();
               this.Item = new Tipos();
               this.Item.TIPO_CodTabla = ItemTabla.TIPO_CodTipo;
               this.Item.AUDI_UsrCrea = Session.UserName;
               this.Item.AUDI_FecCrea = Session.Fecha;
               this.Item.Instance = Infrastructure.Aspect.BusinessEntity.InstanceEntity.Added;
               MView.SetItem();
               MView.setTamanoPorTipo();
               MView.TRFPaises();

               ((MAN002MView)MView).StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
               ((MAN002MView)MView).ShowDialog();
            }
            else
            { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Title, "Debe seleccionar una tabla de tipos."); }
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Title, Infrastructure.Aspect.Constants.Mensajes.NewPresenter, ex); }
      }
      public void Editar()
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
               MView.setTamanoPorTipo();
               MView.TRFPaises();

               ((MAN002MView)MView).ShowDialog();
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
                  if (Client.SaveTipos(Item))
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
               if (Client.SaveTipos(Item))
               {
                  Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeSatisfactorio(Title, "Se ha guardado satisfactoriamente");
                  Actualizar();
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
