using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Infrastructure.Aspect.BusinessEntity;
using Microsoft.Practices.Unity;
using Delfin.ServiceProxy;
using Delfin.Entities;
using Infrastructure.Client.Services.Session;
using System.Collections.ObjectModel;
using Infrastructure.WinFormsControls;
using Infrastructure.Aspect.Constants;

namespace Delfin.Principal
{
   public class PRO006Presenter
   {
      #region [ Variables ]
      public String Title = "Seguimientos";
      public String CUS = "PRO006";
      private Cab_Seguimientos m_itemLView;
      private Cab_Seguimientos m_ItemCab_Seguimientos;
      private ObservableCollection<Det_Seguimientos> m_ItemsDet_Seguimientos;
      
      #endregion

      #region [ Constructor ]
      public PRO006Presenter(IUnityContainer x_container, IPRO006LView x_lview, IPRO006MView x_mview,IPRO006DMview x_dmview)
      {
         try
         {
            ContainerService = x_container;
            Session = ContainerService.Resolve<ISessionService>();
            LView = x_lview;
            MView = x_mview;
            DView = x_dmview;
         }
         catch (Exception ex)
         { Dialogos.MostrarMensajeError(Title, Mensajes.ConstructorPresenter, ex); }
      }
      public void Load()
      {
         try
         {
            Client = ContainerService.Resolve<Delfin.ServiceContracts.IDelfinServices>();
            ListPaquetes = Client.GetAllPaquete();
            LView.LoadView();
            MView.LoadView();
            DView.LoadView();
         }
         catch (Exception ex)
         { Dialogos.MostrarMensajeError(Title, Mensajes.LoadPresenter, ex); }
      }
      #endregion

      #region [ Propiedades ]
      public IUnityContainer ContainerService { get; set; }
      public ISessionService Session { get; set; }
      public Delfin.ServiceContracts.IDelfinServices Client { get; set; }
      public IPRO006LView LView { get; set; }
      public IPRO006MView MView { get; set; }
      public IPRO006DMview DView { get; set; }
      public DateTime FILTRO_FecEmiDesde { get; set; }
      public DateTime FILTRO_FecEmiHasta { get; set; }
      public String FILTRONave { get; set; }
      public Int32 COPE_Codigo { get; set; }
      public Int32 ENTC_CodCliente { get; set; }
      public DateTime? COPE_FechaArribo { get; set; }
      public Int16? COPE_CantidadDias { get; set; }

      #region [ Encabezado Seguimientos ]
      public Cab_Seguimientos ItemLView
      {
          get { return m_itemLView; }
          set { m_itemLView = value; }
      }
      public Cab_Seguimientos ItemCab_Seguimientos
      {
          get { return m_ItemCab_Seguimientos; }
          set { m_ItemCab_Seguimientos = value; }
      }
      public ObservableCollection<Cab_Seguimientos> ItemsCab_Seguimientos { get; set; }
      #endregion

      #region [ Detalle Seguimientos ]
      public ObservableCollection<Det_Seguimientos> ItemsDet_Seguimientos
      {
          get { return m_ItemsDet_Seguimientos; }
          set { m_ItemsDet_Seguimientos = value; }
      }

      public Det_Seguimientos ItemDet_Seguimientos { get; set; }
      //public Det_Seguimientos ItemDet_Seguimientos { get; set; }
      public ObservableCollection<Paquete> ListPaquetes { get; set; }

      #endregion
      
      #endregion

      #region [ Metodos ]

      #region [ Encabezado Seguimientos ]
      public void Nuevo()
      {
          try
          {
              MView.ClearItem();
              ItemCab_Seguimientos = new Cab_Seguimientos
              {
                  AUDI_UsrCrea = Session.UserName,
                  AUDI_FecCrea = Session.Fecha,
                  Instance = InstanceEntity.Added
              };
              MView.ClearItemsDetalles();
              MView.SetInstance(InstanceView.New);
              if (LView != null) { ((PRO006MView)MView).Icon = System.Drawing.Icon.FromHandle(((System.Drawing.Bitmap)LView.IconView).GetHicon()); }
              ((PRO006MView) MView).ShowDialog();


          }
          catch (Exception ex)
          { Dialogos.MostrarMensajeError(Title, Mensajes.NewPresenter, ex); }
      }
      public void Editar()
      {
          try
          {
              if (ItemCab_Seguimientos != null)
              {
                  MView.ClearItem();
                  /* Encabezado Seguimiento  :) */
                  ItemCab_Seguimientos = Client.GetOneCab_Seguimientos(ItemCab_Seguimientos.CSEG_Codigo);
                  ItemCab_Seguimientos.AUDI_UsrMod = Session.UserName;
                  ItemCab_Seguimientos.AUDI_FecMod = Session.Fecha;
                  ItemCab_Seguimientos.Instance = InstanceEntity.Modified;
                  if (ItemCab_Seguimientos.COPE_Codigo != null)
                  {
                      var itemCabOperacion = Client.GetOneCab_Operacion(ItemCab_Seguimientos.COPE_Codigo.Value);
                      if (itemCabOperacion != null && itemCabOperacion.COPE_Codigo > 0 )
                      {
                          COPE_CantidadDias = itemCabOperacion.COPE_CantidadDias;
                          COPE_FechaArribo = itemCabOperacion.COPE_FechaArribo;
                          if (itemCabOperacion.ENTC_CodCliente != null)
                          {
                              ENTC_CodCliente = itemCabOperacion.ENTC_CodCliente.Value;
                          }
                          /*  falta deposito temporal */
                          //if (true)
                          //{
                          //    //ENTC_CodDepTemporal = ItemCab_Operacion.ENTC_CodCliente.Value;
                          //} 
                      }
                      
                  }

                  MView.SetItem();
                  MView.ClearItemsDetalles();
                  /* Detalle Seguimiento  :) */
                  ItemsDet_Seguimientos = Client.GetAllByCabSeguimiento(ItemCab_Seguimientos.CSEG_Codigo);
                  MView.ShowItemsDetalles();
                  MView.SetInstance(InstanceView.Edit);
                  if (LView != null) { ((PRO006MView)MView).Icon = System.Drawing.Icon.FromHandle(((System.Drawing.Bitmap)LView.IconView).GetHicon()); }
                  ((PRO006MView)MView).Show();
                  ((PRO006MView)MView).BringToFront();
              }
              else
              { Dialogos.MostrarMensajeInformacion(Title, "Debe seleccionar un elemento de la grilla"); }
          }
          catch (Exception ex)
          { Dialogos.MostrarMensajeError(Title, Mensajes.EditPresenter, ex); }
      }
      public void Eliminar()
      {
          try
          {
              if (ItemCab_Seguimientos != null)
              {
                  DialogResult result = Dialogos.MostrarMensajePregunta(Title, Mensajes.PreguntaEliminar, Dialogos.LabelBoton.Si_No);
                  if (result == DialogResult.Yes)
                  {
                      ItemCab_Seguimientos.Instance = InstanceEntity.Deleted;
                      if (Client.SaveCab_Seguimientos(ref m_ItemCab_Seguimientos))
                      {
                          Dialogos.MostrarMensajeSatisfactorio(Title, "Se ha eliminado el item.");
                          Actualizar();
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
      public void Actualizar()
      {
          try
          {
              ItemCab_Seguimientos = null;
              ItemsCab_Seguimientos = null;
              LView.FiltrosLView();
              ItemsCab_Seguimientos = Client.GetAllByCabSeguimientoByFiltros(FILTRO_FecEmiDesde, FILTRO_FecEmiHasta,FILTRONave);
              LView.ShowItems();
          }
          catch (Exception ex)
          { Dialogos.MostrarMensajeError(Title, "Ha ocurrido un error actualizando.", ex); }
      }
      public bool GuardarSeguimiento()
      {
          try
          {
              MView.GetItem();
              if (ItemCab_Seguimientos.Validar())
              {
                  if (ItemCab_Seguimientos.Instance== InstanceEntity.Added && Client.GetExisteSeguimientoOperacion(ItemCab_Seguimientos))
                  {
                      Dialogos.MostrarMensajeInformacion(Title, "Existe un seguimiento con la misma operación verifique.");
                      return false; 
                  }
                  if (ItemsDet_Seguimientos != null && ItemsDet_Seguimientos.Count > 0)
                  {
                      ItemCab_Seguimientos.ItemsDetSeguimientos = new ObservableCollection<Det_Seguimientos>();
                      ItemCab_Seguimientos.ItemsDetSeguimientos = ItemsDet_Seguimientos;
                      if (Client.SaveCab_Seguimientos(ref m_ItemCab_Seguimientos))
                      {
                          Dialogos.MostrarMensajeSatisfactorio(Title, "Se ha guardado satisfactoriamente");
                          Actualizar();
                          return true;
                      }
                      Dialogos.MostrarMensajeInformacion(Title, "Ha ocurrido un error al guardar el item.");
                      return false;
                  }
                  Dialogos.MostrarMensajeInformacion(Title, "Debe agregar un detalle del Seguimientos como minimo");
                  return false;
              }
              MView.ShowValidation();
              return false;
          }
          catch (Exception ex)
          {
              Dialogos.MostrarMensajeError(Title, Mensajes.SavePresenter, ex);
              return false;
          }
      }
      #endregion

      #region [ Detalle Seguimientos ]
      public DataTable LoadAyudaOperacion()
       {
           try
           {
               return Client.GetAllAyudaOperacion(false);
           }
           catch (Exception) { return null; }
       }
      public void NuevoSeguimiento()
      {
          try
          {
              ItemDet_Seguimientos = new Det_Seguimientos
              {
                  AUDI_UsrCrea = Session.UserName,
                  AUDI_FecCrea = Session.Fecha,
                  Instance = InstanceEntity.Added,
                  CONS_TabESS = "ETJ"
              };
              DView.ClearItem();
              DView.SetInstance(InstanceView.New);
              ((PRO006DMview)DView).ShowDialog();
          }
          catch (Exception ex)
          { Dialogos.MostrarMensajeError(Title, Mensajes.NewPresenter, ex); }
      }
      
      public void AgregarDetalleSeguimientos()
      {
          try
          {
              DView.GetItem();
              if (ItemDet_Seguimientos.Validar())
              {
                  if (ItemDet_Seguimientos.Instance == InstanceEntity.Added)
                  {
                      ItemsDet_Seguimientos.Add(ItemDet_Seguimientos);
                  }
                 Int32 fila = 0;
                 foreach (var item in ItemsDet_Seguimientos)
                 {
                     fila++; item.Item = fila;
                 } 
                  MView.ShowItemsDetalles();
                  DView.CerrarVenta();
              }
              else
              {
                  DView.ShowValidation();
              }
          }
          catch (Exception ex)
          { Dialogos.MostrarMensajeError(Title, Mensajes.NewPresenter, ex); }
      }
      public void EditarDetalleSeguimientos()
      {
          try
          {
              if (ItemDet_Seguimientos != null)
              {
                  DView.ClearItem();
                  DView.SetItem();
                  DView.SetInstance(InstanceView.Edit);
                  ((PRO006DMview)DView).ShowDialog();
              }
              else
              { Dialogos.MostrarMensajeInformacion(Title, "Debe seleccionar un elemento de la grilla"); } 
          }
          catch (Exception ex)
          { Dialogos.MostrarMensajeError(Title, Mensajes.EditPresenter, ex); }
      }
      public void EliminarDetalleSeguimientos()
      {
          try
          {
              if (ItemDet_Seguimientos != null)
              {
                  DialogResult result = Dialogos.MostrarMensajePregunta(Title, Mensajes.PreguntaEliminar, Dialogos.LabelBoton.Si_No);
                  if (result == DialogResult.Yes)
                  {
                      if (ItemDet_Seguimientos.DSEG_Item > 0)
                      {
                          ItemDet_Seguimientos.Instance = InstanceEntity.Deleted;
                      }
                      Int32 fila = 0;
                      foreach (var item in ItemsDet_Seguimientos)
                      {
                          fila++; item.Item = fila;
                      }
                      MView.ShowItemsDetalles();
                  }
              }
              else
              { Dialogos.MostrarMensajeInformacion(Title, "Debe seleccionar un elemento de la grilla"); }
          }
          catch (Exception ex)
          { Dialogos.MostrarMensajeError(Title, Mensajes.DeletePresenter, ex); }
      }
      #endregion

      #endregion
   }
}
