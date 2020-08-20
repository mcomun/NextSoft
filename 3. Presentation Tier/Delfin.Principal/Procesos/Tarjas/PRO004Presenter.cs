using System;
using System.Diagnostics;
using System.Windows.Forms;
using Infrastructure.Aspect.BusinessEntity;
using Microsoft.Practices.Unity;
using Delfin.ServiceProxy;
using Delfin.Entities;
using Infrastructure.Client.Services.Session;
using System.Collections.ObjectModel;
using Infrastructure.WinFormsControls;
using Infrastructure.Aspect.Constants;
using  System.Data;

namespace Delfin.Principal
{
   public class PRO004Presenter
   {
      #region [ Variables ]
      public String Title = "Tarjas";
      public String CUS = "PRO004";
      private Cab_Tarjas m_ItemCab_Tarjas;
      private ObservableCollection<Det_Tarjas> m_ItemsDet_Tarjas;
      
      #endregion

      #region [ Constructor ]
      public PRO004Presenter(IUnityContainer x_container, IPRO004LView x_lview, IPRO004MView x_mview, IPRO004DMview x_dview)
      {
         try
         {
            ContainerService = x_container;
            Session = ContainerService.Resolve<ISessionService>();
            LView = x_lview;
            MView = x_mview;
            DView = x_dview;
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

      public IPRO004LView LView { get; set; }
      public IPRO004MView MView { get; set; }
      public IPRO004DMview DView { get; set; }
      
      public ObservableCollection<Paquete> ListPaquetes { get; set; }
      public InstanceView InstanciaDet_Tarjas { get; set; }

      public DateTime FiltroFecIni { get; set; }
      public DateTime FiltroFecFin { get; set; }
      #region [ Encabezado Tarjas ]
      
   
      public Cab_Tarjas ItemCab_Tarjas
      {
          get { return m_ItemCab_Tarjas; }
          set { m_ItemCab_Tarjas = value; }
      }
      public ObservableCollection<Cab_Tarjas> ItemsCab_Tarjas { get; set; }
      #endregion

      #region [ Detalle Tarjas ]

      public ObservableCollection<Det_Tarjas> ItemsDet_Tarjas
      {
          get { return m_ItemsDet_Tarjas; }
          set { m_ItemsDet_Tarjas = value; }
      }
      public Det_Tarjas ItemDet_Tarjas { get; set; }
      public Det_Tarjas TempItemDet_Tarjas { get; set; }

      #endregion
      
      #endregion

      #region [ Metodos ]

      #region [ Encabezado Tarjas ]
      public void Nuevo()
      {
          try
          {
              MView.ClearItem();
              ItemCab_Tarjas = new Cab_Tarjas
              {
                  AUDI_UsrCrea = Session.UserName,
                  AUDI_FecCrea = Session.Fecha,
                  Instance = InstanceEntity.Added,
                  TIPO_TabMND = "MND"
              };
              ItemDet_Tarjas = new Det_Tarjas();
              MView.ClearItemsDetallesTarjas();
              MView.SetInstance(InstanceView.New);
              if (LView != null) { ((PRO004MView)MView).Icon = System.Drawing.Icon.FromHandle(((System.Drawing.Bitmap)LView.IconView).GetHicon()); }
              ((PRO004MView)MView).ShowDialog();
          }
          catch (Exception ex)
          { Dialogos.MostrarMensajeError(Title, Mensajes.NewPresenter, ex); }
      }
      public void Editar()
      {
          try
          {
              if (ItemCab_Tarjas != null)
              {
                  MView.ClearItem();
                  /* Encabezado  :) */
                  ItemCab_Tarjas = Client.GetOneCab_Tarjas(ItemCab_Tarjas.TARJ_Codigo);
                  ItemCab_Tarjas.AUDI_UsrMod = Session.UserName;
                  ItemCab_Tarjas.AUDI_FecMod = Session.Fecha;
                  ItemCab_Tarjas.Instance = InstanceEntity.Modified;
                  MView.SetItem();

                  /* Detalle Tarjas :) */
                  MView.ClearItemsDetallesTarjas();
                  ItemsDet_Tarjas = Client.GetAllDet_TarjasPorTARJ_Codigo(ItemCab_Tarjas.TARJ_Codigo);
                  
                  foreach (var item in ItemsDet_Tarjas)
                  {
                      item.Correlativo = item.DTAJ_Item;
                      item.Cantidad = 1;
                  }
                  MView.ShowItemsDetalleTarjas();
                  MView.SetInstance(InstanceView.Edit);
                  if (LView != null) { ((PRO004MView)MView).Icon = System.Drawing.Icon.FromHandle(((System.Drawing.Bitmap)LView.IconView).GetHicon()); }
                  ((PRO004MView)MView).ShowDialog();
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
              if (ItemCab_Tarjas != null)
              {
                  DialogResult result = Dialogos.MostrarMensajePregunta(Title, Mensajes.PreguntaEliminar, Dialogos.LabelBoton.Si_No);
                  if (result == DialogResult.Yes)
                  {
                      ItemCab_Tarjas.Instance = InstanceEntity.Deleted;
                      if (Client.SaveCab_Tarjas(ref m_ItemCab_Tarjas))
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
              ItemCab_Tarjas = null;
              ItemsCab_Tarjas = null;
              LView.FiltrosLView();
              FiltroFecIni = DateTime.Now;
              FiltroFecFin = DateTime.Now;
              ItemsCab_Tarjas = Client.GetAllTarjasPorFiltros(FiltroFecIni, FiltroFecFin);
              LView.ShowItems();
          }
          catch (Exception ex)
          { Dialogos.MostrarMensajeError(Title, "Ha ocurrido un error actualizando.", ex); }
      }
      public bool GuardarTarifa()
      {
          try
          {
              MView.GetItem();
              if (ItemCab_Tarjas.Validar())
              {
                  if (ItemsDet_Tarjas != null && ItemsDet_Tarjas.Count > 0)
                  {
                      ItemCab_Tarjas.ItemsDet_Tarjas = new ObservableCollection<Det_Tarjas>();
                      ItemCab_Tarjas.ItemsDet_Tarjas = ItemsDet_Tarjas;
                      if (Client.SaveCab_Tarjas(ref m_ItemCab_Tarjas))
                      {
                          Dialogos.MostrarMensajeSatisfactorio(Title, "Se ha guardado satisfactoriamente");
                          Actualizar();
                          return true;
                      }
                      Dialogos.MostrarMensajeInformacion(Title, "Ha ocurrido un error al guardar el item.");
                      return false;
                  }
                  Dialogos.MostrarMensajeInformacion(Title, "Debe agregar un detalle del Tarjas como minimo");
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

      #region [Detalle Tarjas]
      public void AgregarDetalleTarjas()
      {
          try
          {
            DView.GetItem();
            if (ItemDet_Tarjas.Validar())
            {
                MView.ShowItemsDetalleTarjas();
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
      public void EditarDetalleTarjas()
      {
          try
          {
              if (ItemDet_Tarjas != null)
              {
                  DView.ClearItem();
                  DView.SetItem();
                  DView.SetInstance(InstanceView.Edit);
                  ((PRO004DMview)DView).ShowDialog();
              }
              else
              { Dialogos.MostrarMensajeInformacion(Title, "Debe seleccionar un elemento de la grilla"); }
          }
          catch (Exception ex)
          { Dialogos.MostrarMensajeError(Title, Mensajes.EditPresenter, ex); }
      }
      public void EliminarDetalleTarjas()
      {
          try
          {
              if (ItemDet_Tarjas != null)
              {
                  DialogResult result = Dialogos.MostrarMensajePregunta(Title, Mensajes.PreguntaEliminar, Dialogos.LabelBoton.Si_No);
                  if (result == DialogResult.Yes)
                  {
                    if (ItemDet_Tarjas.DTAJ_Item > 0)
                    {
                        ItemDet_Tarjas.Instance = InstanceEntity.Deleted;
                    }
                    else
                    {
                        ItemsDet_Tarjas.Remove(ItemDet_Tarjas);
                    }
                    MView.ShowItemsDetalleTarjas();
                      
                  }
              }
              else
              { Dialogos.MostrarMensajeInformacion(Title, "Debe seleccionar un elemento de la grilla"); }
          }
          catch (Exception ex)
          { Dialogos.MostrarMensajeError(Title, Mensajes.DeletePresenter, ex); }
      }
      public void ValidarExcel(ref string x_mensajeError,DataTable dt)
      {
          try
          {
              int contadorRow = 0;
              ItemsDet_Tarjas = new ObservableCollection<Det_Tarjas>();
              foreach (DataRow filas in dt.Rows)
              {
                  contadorRow++;
                  if (contadorRow == 1)
                  {
                      ItemCab_Tarjas = new Cab_Tarjas
                      {
                          AUDI_UsrCrea = Session.UserName,
                          AUDI_FecCrea = Session.Fecha,
                          Instance = InstanceEntity.Added,
                          TIPO_TabMND = "MND",
                      };
                        /*  Solo Valida los primeros fila del encabezado */
                      if (filas["VALOR"] != DBNull.Value)
                      {
                          ItemCab_Tarjas.TARJ_Valor = Convert.ToDecimal(filas["VALOR"]);
                      }
                      if (filas["DNI/RUC CLIENTE"] != DBNull.Value)
                      {
                          var cliente = Client.GetEntidadOnePorRuc(filas["DNI/RUC CLIENTE"].ToString(),1); /*  1 => cliente  :) */
                          if (cliente != null && cliente.ENTC_Codigo > 0)
                          {
                              ItemCab_Tarjas.ENTC_Cliente = cliente.ENTC_Codigo;
                          }
                          else
                          {
                              x_mensajeError += "* Campo obligatorio DNI/RUC no existe CLIENTE, fila Nro: " + (contadorRow) + Environment.NewLine;
                          }
                      }
                      else
                      {
                          x_mensajeError += "* Campo obligatorio DNI/RUC CLIENTE, fila Nro: " + (contadorRow) + Environment.NewLine;
                      }
                      if (filas["RUC DEP TEMP"] != DBNull.Value)
                      {
                          var depTemp = Client.GetEntidadOnePorRuc(filas["RUC DEP TEMP"].ToString(),14); /* 14 => cliente  :) */
                          if (depTemp != null && depTemp.ENTC_Codigo > 0)
                          {
                              ItemCab_Tarjas.ENTC_DepTemporal = depTemp.ENTC_Codigo;
                          }
                          else
                          {
                              x_mensajeError += "* Campo obligatorio RUC no existe DEPOSITO TEMPORAL, fila Nro: " + (contadorRow) + Environment.NewLine;
                          }
                      }
                      else
                      {
                          x_mensajeError += "* Campo obligatorio RUC DEPOSITO TEMPORAL, fila Nro: " + (contadorRow) + Environment.NewLine;
                      }
                      if (filas["MONEDA"] != DBNull.Value)
                      {
                          switch (filas["MONEDA"].ToString())
                          {
                              case "SOLES":
                                  ItemCab_Tarjas.TIPO_CodMND = "001";
                                  break;
                              case "DOLAR":
                                  ItemCab_Tarjas.TIPO_CodMND = "002";
                                  break;
                              case "Euro":
                                  ItemCab_Tarjas.TIPO_CodMND = "003";
                                  break;
                              case "PESOS":
                                  ItemCab_Tarjas.TIPO_CodMND = "004";
                                  break;
                          }
                      }
                      else
                      {
                          x_mensajeError += "* Campo obligatorio MONEDA, fila Nro: " + (contadorRow) + Environment.NewLine;
                      }
                  }
                  
                  ItemDet_Tarjas = new Det_Tarjas
                  {
                      Instance = InstanceEntity.Added,
                      AUDI_UsrCrea = Session.UserName,
                      AUDI_FecCrea = Session.Fecha
                  };

                  if (filas["CONTENEDOR"] != DBNull.Value)
                  {
                      ItemDet_Tarjas.PACK_Desc = filas["CONTENEDOR"].ToString();
                      switch (filas["CONTENEDOR"].ToString())
                      {
                          case "STANDAR 20":
                              ItemDet_Tarjas.PACK_Codigo = 1;
                              break;
                          case "STANDAR 40":
                              ItemDet_Tarjas.PACK_Codigo = 2;
                              break;
                          case "HQ 45":
                              ItemDet_Tarjas.PACK_Codigo = 3;
                              break;
                          case "REEFER 20":
                              ItemDet_Tarjas.PACK_Codigo = 4;
                              break;
                      }
                  }
                  else
                  {
                      x_mensajeError += "* Campo obligatorio CONTENEDOR, fila Nro: " + (contadorRow) + Environment.NewLine;
                  }
                  if (filas["NRO CONTENEDOR"] == DBNull.Value)
                  {
                      x_mensajeError += "* Campo obligatorio NRO. CONTENEDOR, fila Nro: " + (contadorRow) +
                                        Environment.NewLine;
                  }
                  else
                  {
                      ItemDet_Tarjas.DTAJ_NroContenedor = filas["NRO CONTENEDOR"].ToString();    
                  }
                  //if (filas["TARJA"] != null)
                  //{
                  //    ItemDet_Tarjas.DTAJ_Tarja = (bool?)(filas["TARJA"] = !string.IsNullOrEmpty("TARJA") ? true : false);
                  //}
                  //else
                  //{
                  //    ItemDet_Tarjas.DTAJ_Tarja = false;
                  //}

                  if (filas["ESTADO"] != DBNull.Value)
                  {
                      switch (filas["ESTADO"].ToString())
                      {
                          case "INGRESADA":
                              ItemDet_Tarjas.CONS_CodETJ = "001";
                              break;
                          case "RETIRADA":
                              ItemDet_Tarjas.CONS_CodETJ = "002";
                              break;
                          case "DEUDA":
                              ItemDet_Tarjas.CONS_CodETJ = "003";
                              break;
                          case "FACTURADA":
                              ItemDet_Tarjas.CONS_CodETJ = "004";
                              break;
                          case "COBRADA":
                              ItemDet_Tarjas.CONS_CodETJ = "005";
                              break;
                      }
                      ItemDet_Tarjas.CONS_TabETJ = "ETJ";
                      ItemDet_Tarjas.CONS_Estado = filas["ESTADO"].ToString();
                  }
                  else
                  {
                      x_mensajeError += "* Campo obligatorio ESTADO, fila Nro: " + (contadorRow) + Environment.NewLine;
                  }
                  ItemDet_Tarjas.Correlativo = contadorRow;
                  ItemDet_Tarjas.Cantidad = 1;
                  if (!String.IsNullOrEmpty(x_mensajeError))
                  {
                      ItemsDet_Tarjas = new ObservableCollection<Det_Tarjas>();
                  }
                  else
                  {
                      ItemsDet_Tarjas.Add(ItemDet_Tarjas);
                  }
              }
          }
          catch (Exception ex) { }
      }
      #endregion

      #endregion

   }
}
