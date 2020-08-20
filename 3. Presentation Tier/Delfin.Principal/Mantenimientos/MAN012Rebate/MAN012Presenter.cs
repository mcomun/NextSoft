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
   public class MAN012Presenter
   {
      #region [ Variables ]
      public String Title = "Mantenimiento de GRR";
      public String CUS = "MAN012";

      private GRR m_item;
      #endregion

      #region [ Contrusctor ]
      public MAN012Presenter(IUnityContainer x_container, IMAN012LView x_lview, IMAN012MView x_mview)
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

      public IMAN012LView LView { get; set; }
      public IMAN012MView MView { get; set; }

      public GRR Item
      {
         get { return m_item; }
         set { m_item = value; }
      }
      public ObservableCollection<GRR> Items { get; set; }

      public Entidad ItemTransportista { get; set; }
      
      public ObservableCollection<Paquete> ListPaquetes{ get; set; }
      #endregion

      #region [ Propiedades Filtro ]
      public String FILTRO_REBA_Tipo { get; set; }
      public Nullable<DateTime> FILTRO_REBA_FecIni { get; set; }
      public Nullable<Int32> FILTRO_ENTC_CodTransportista { get; set; }
      #endregion

      #region [ Metodos ]
      public void Actualizar()
      {
         try
         {
            Item = null;
            Items = null;

            if (FILTRO_ENTC_CodTransportista != null)
            {
               if (!String.IsNullOrEmpty(FILTRO_REBA_Tipo))
               {
                  if (FILTRO_REBA_FecIni != null)
                  {
                     ObservableCollection<Infrastructure.Aspect.DataAccess.DataAccessFilterSQL> _filters = new ObservableCollection<Infrastructure.Aspect.DataAccess.DataAccessFilterSQL>();
                     _filters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@pintENTC_CodTransportista", FilterValue = FILTRO_ENTC_CodTransportista, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.Int32, FilterSize = 4 });
                     _filters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@pchrREBA_Tipo", FilterValue = FILTRO_REBA_Tipo, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.Char, FilterSize = 1 });
                     _filters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@pdtmREBA_FecIni", FilterValue = FILTRO_REBA_FecIni, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.DateTime, FilterSize = 8 });

                     Items = Client.GetAllGRRFilter("COM_REBASS_Todos", _filters); 
                  }
                  else
                  { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Title, "Debe ingresar Fecha de Inicio."); }
               }
               else
               { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Title, "Debe seleccionar el tipo."); }
            } 
            else
            { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Title, "Debe seleccionar un transportista."); }

            LView.ShowItems();
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Title, "Ha ocurrido un error actualizando.", ex); }
      }

      public void GetContratos(Nullable<Int32> ENTC_CodTransportista, Nullable<DateTime> REBA_FecIni, Nullable<DateTime> REBA_FecFin, Boolean ShowContratos = true)
      {
         try
         {
            if (ENTC_CodTransportista.HasValue)
            {
               if (REBA_FecIni.HasValue)
               {
                  if (REBA_FecFin.HasValue)
                  {
                     ObservableCollection<Entities.Contrato> _listContratos = Client.GetAllContratoByTransportista(ENTC_CodTransportista.Value, REBA_FecIni.Value, REBA_FecFin.Value);
                     if (_listContratos != null && _listContratos.Count > 0)
                     {
                        foreach (Contrato itemContrato in _listContratos)
                        {
                           if (Item.ListGRR_Contratos.Where(dreb => dreb.CONT_Numero == itemContrato.CONT_Numero).FirstOrDefault() == null)
                           {
                              GRR_Contrato _itemGRR_Contrato = new GRR_Contrato();
                              _itemGRR_Contrato.CONT_Numero = itemContrato.CONT_Numero;
                              _itemGRR_Contrato.Instance = Infrastructure.Aspect.BusinessEntity.InstanceEntity.Added;
                              this.Item.ListGRR_Contratos.Add(_itemGRR_Contrato);
                           }
                        }

                        if (ShowContratos) { MView.SetListContratos(_listContratos); }
                     }
                     else
                     { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Title, "No se encontraron contratos para el Transportista en el rango de fechas ingresadas."); }
                  }
                  else
                  { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Title, "Debe ingresar la Fecha Fin."); }
               }
               else
               { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Title, "Debe ingresar la Fecha Inicio."); }
            }
            else
            { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Title, "Debe seleccionar el transportista."); }
         }
         catch (Exception)
         { }
      }

      public void Nuevo()
      {
         try
         {

            MView.ClearItem();
            this.Item = new GRR();
            if (FILTRO_ENTC_CodTransportista != null)
            { this.Item.ENTC_CodTransportista = FILTRO_ENTC_CodTransportista; }
            this.Item.EMPR_Codigo = Controls.Entorno.ItemEmpresa.EMPR_Codigo;
            this.Item.AUDI_UsrCrea = Session.UserName;
            this.Item.AUDI_FecCrea = Session.Fecha;
            this.Item.Instance = Infrastructure.Aspect.BusinessEntity.InstanceEntity.Added;

            foreach (Paquete itemPaquete in ListPaquetes)
            {
               GRR_Paquetes _itemGRR_Paquetes = new GRR_Paquetes();
               _itemGRR_Paquetes.PACK_Codigo = itemPaquete.PACK_Codigo;
               _itemGRR_Paquetes.Instance = Infrastructure.Aspect.BusinessEntity.InstanceEntity.Added;
               this.Item.ListGRR_Paquetes.Add(_itemGRR_Paquetes);
            }

            MView.SetItem();

            ((MAN012MView)MView).ShowDialog();
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
               this.Item = Client.GetOneGRR(Item.REBA_Tipo, Item.REBA_Codigo);
               this.Item.AUDI_UsrMod = Session.UserName;
               this.Item.AUDI_FecMod = Session.Fecha;
               this.Item.Instance = Infrastructure.Aspect.BusinessEntity.InstanceEntity.Modified;

               foreach (GRR_Paquetes itemGRR_Paquetes in Item.ListGRR_Paquetes)
               {
                  itemGRR_Paquetes.Instance = Infrastructure.Aspect.BusinessEntity.InstanceEntity.Modified;   
               }
               foreach (Paquete itemPaquete in ListPaquetes)
               {
                  if (Item.ListGRR_Paquetes.Where(dreb => dreb.PACK_Codigo == itemPaquete.PACK_Codigo).FirstOrDefault() == null)
                  {
                     GRR_Paquetes _itemDetRebate = new GRR_Paquetes();
                     _itemDetRebate.PACK_Codigo = itemPaquete.PACK_Codigo;
                     _itemDetRebate.Instance = Infrastructure.Aspect.BusinessEntity.InstanceEntity.Added;
                     this.Item.ListGRR_Paquetes.Add(_itemDetRebate);
                  }
               }

               GetContratos(Item.ENTC_CodTransportista, Item.REBA_FecIni, Item.REBA_FecFin, false);

               MView.SetItem();

               ((MAN012MView)MView).ShowDialog();
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
                  if (Client.SaveGRR(ref m_item))
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
               if (Client.SaveGRR(ref m_item))
               {
                  FILTRO_ENTC_CodTransportista = m_item.ENTC_CodTransportista;
                  FILTRO_REBA_Tipo = m_item.REBA_Tipo;
                  FILTRO_REBA_FecIni = m_item.REBA_FecIni;

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