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
   public class MAN014Presenter
   {
      #region [ Variables ]
      public String Title = "Mantenimiento de Comisiones";
      public String CUS = "MAN014";
      private Comision m_item;
      #endregion

      #region [ Contrusctor ]
      public MAN014Presenter(IUnityContainer x_container, IMAN014LView x_lview, IMAN014MView x_mview)
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

            ListPaquetes = Client.GetAllPaquete();

            LView.LoadView();
            MView.LoadView();
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Title, "Ha ocurrido un error inicializando la vista.", ex); }
      }
      #endregion

      #region [ Propiedades ]
      public IUnityContainer ContainerService { get; set; }
      public ISessionService Session { get; set; }
      public IDelfinServices Client { get; set; }

      public IMAN014LView LView { get; set; }
      public IMAN014MView MView { get; set; }

      public Comision Item
      {
         get { return m_item; }
         set { m_item = value; }
      }
      
      public ObservableCollection<Comision> Items { get; set; }

      public ObservableCollection<Paquete> ListPaquetes{ get; set; }
      #endregion

      #region [ Propiedades Filtro ]
      public Nullable<DateTime> FILTRO_FechaDesde { get; set; }
      public Nullable<DateTime> FILTRO_FechaHasta { get; set; }
      #endregion

      #region [ Metodos ]
      public void Actualizar()
      {
         try
         {
            Item = null;
            Items = null;

            if (FILTRO_FechaDesde.HasValue)
            {
               if (FILTRO_FechaHasta.HasValue)
               {
                  ObservableCollection<Infrastructure.Aspect.DataAccess.DataAccessFilterSQL> _filters = new ObservableCollection<Infrastructure.Aspect.DataAccess.DataAccessFilterSQL>();
                  _filters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@pdtmCOMI_Desde", FilterValue = FILTRO_FechaDesde, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.DateTime, FilterSize = 8 });
                  _filters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@pdtmCOMI_Hasta", FilterValue = FILTRO_FechaHasta, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.DateTime, FilterSize = 8 });
                  Items = Client.GetAllComisionFilter("COM_COMISS_Todos", _filters); 
               }
               else
               { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Title, "Debe seleccionar la Fecha Hasta."); }
            }
            else
            { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Title, "Debe seleccionar la Fecha Desde."); }

            LView.ShowItems();
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Title, "Ha ocurrido un error actualizando.", ex); }
      }

      public void Nuevo()
      {
         try
         {
            MView.ClearItem();
            this.Item = new Comision();
            this.Item.EMPR_Codigo = Delfin.Controls.Entorno.ItemEmpresa.EMPR_Codigo;
            this.Item.SUCR_Codigo = Delfin.Controls.Entorno.ItemSucursal.SUCR_Codigo;
            this.Item.AUDI_UsrCrea = Session.UserName;
            this.Item.AUDI_FecCrea = Session.Fecha;
            this.Item.Instance = Infrastructure.Aspect.BusinessEntity.InstanceEntity.Added;

            //foreach (Paquete itemPaquete in ListPaquetes)
            //{
            //   Det_Comision _itemDet_Comision = new Det_Comision();
            //   _itemDet_Comision.PACK_Codigo = itemPaquete.PACK_Codigo;
            //   _itemDet_Comision.AUDI_UsrCrea = Session.UserName;
            //   _itemDet_Comision.AUDI_FecCrea = Session.Fecha;
            //   _itemDet_Comision.Instance = Infrastructure.Aspect.BusinessEntity.InstanceEntity.Added;
            //   this.Item.ListDet_Comision.Add(_itemDet_Comision);
            //}

            MView.SetItem();

            ((MAN014MView)MView).ShowDialog();
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
               this.Item = Client.GetOneComision(this.Item.COMI_Codigo);
               this.Item.AUDI_UsrMod = Session.UserName;
               this.Item.AUDI_FecMod = Session.Fecha;
               this.Item.Instance = Infrastructure.Aspect.BusinessEntity.InstanceEntity.Modified;
               
               //foreach (Det_Comision itemDet_Comision in Item.ListDet_Comision)
               //{
               //   itemDet_Comision.AUDI_UsrMod = Session.UserName;
               //   itemDet_Comision.AUDI_FecMod = Session.Fecha;
               //   itemDet_Comision.Instance = Infrastructure.Aspect.BusinessEntity.InstanceEntity.Modified;   
               //}
               //foreach (Paquete itemPaquete in ListPaquetes)
               //{
               //   if (Item.ListDet_Comision.Where(dreb => dreb.PACK_Codigo == itemPaquete.PACK_Codigo).FirstOrDefault() == null)
               //   {
               //      Det_Comision _itemDet_Comision = new Det_Comision();
               //      _itemDet_Comision.PACK_Codigo = itemPaquete.PACK_Codigo;
               //      _itemDet_Comision.AUDI_UsrCrea = Session.UserName;
               //      _itemDet_Comision.AUDI_FecCrea = Session.Fecha;
               //      _itemDet_Comision.Instance = Infrastructure.Aspect.BusinessEntity.InstanceEntity.Added;
               //      this.Item.ListDet_Comision.Add(_itemDet_Comision);
               //   }
               //}

               MView.SetItem();

               ((MAN014MView)MView).ShowDialog();
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
                  if (Client.SaveComision(ref m_item))
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
               if (!Client.GetComisionValidar(Item.COMI_Codigo, Item.COMI_FecIni.Value, Item.COMI_FecFin.Value))
               {
                  if (Client.SaveComision(ref m_item))
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
                  Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Title, "Existe una configuración de comisiones que se cruza con el rango de fechas.");
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