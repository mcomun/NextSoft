using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Infrastructure.Aspect.Constants;
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
   public partial class CAJ004ChequesEnBlancoPresenter
   {
      #region [ Variables ]
      public String Title = "Cheques en Blanco";
      public String CUS = "CAJ004";
      #endregion

      #region [ Contrusctor ]
      public CAJ004ChequesEnBlancoPresenter(IUnityContainer x_container, ICAJ004ChequesEnBlancoLView x_lview)
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
            Fecha = Client.GetFecha();

            Entities.Parametros _parametros;
            TCambio ETipoCambio = TCambio.Ventas;
            ListParametros = Client.GetAllParametros();
            _parametros = ListParametros.Where(Para => Para.PARA_Clave.Equals("TCCTACTE_PRO")).FirstOrDefault();
            if (_parametros != null && _parametros.PARA_Valor != null)
            { ETipoCambio = _parametros.PARA_Valor.Equals("VEN") ? TCambio.Ventas : TCambio.Compras; }

            LView.LoadView();

            String fecha = Fecha.ToString("yyyyMMdd");
            Entities.TiposCambio _TCambio = Client.GetOneTiposCambio(fecha);
            MensajeError = "";
            if (_TCambio != null)
            {
               switch (ETipoCambio)
               {
                  case TCambio.Ventas:
                     TipoCambio = _TCambio.TIPC_Venta;
                     break;
                  case TCambio.Compras:
                     TipoCambio = _TCambio.TIPC_Compra;
                     break;
               }
               if (!(TipoCambio > 0))
               { MensajeError = String.Format("El tipo de Cambio definido para [{0:dd/MM/yyyy}] no es correcto.", Fecha); Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Title, MensajeError); }
            }
            else { MensajeError = String.Format("No se ha definido el tipo de cambio para el dia {0:dd/MM/yyyy}", Fecha); Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Title, MensajeError); }

            _parametros = ListParametros.Where(Para => Para.PARA_Clave.Equals("MOVI_CHQBLANCO")).FirstOrDefault();
            if (_parametros != null && _parametros.PARA_Valor != null)
            {
               string x_movimientos = _parametros.PARA_Valor;
               TiposMovimientos = x_movimientos.Split('|');

               ObservableCollection<Tipos> x_ListTiposMOV = Client.GetAllTiposByTipoCodTabla("MOV");
               ListTiposMOV = new ObservableCollection<Tipos>();
               foreach (String iMov in TiposMovimientos)
               {
                  Tipos _mov = x_ListTiposMOV.Where(Mov => Mov.TIPO_CodTipo.Equals(iMov)).FirstOrDefault();
                  if (_mov != null)
                  { ListTiposMOV.Add(_mov); }
               }
            }
            else
            {
               ListTiposMOV = Client.GetAllTiposByTipoCodTabla("MOV");
            }
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Title, "Ha ocurrido un error inicializando la vista.", ex); }
      }
      #endregion

      #region [ Propiedades ]
      public IUnityContainer ContainerService { get; set; }
      public ISessionService Session { get; set; }
      public IDelfinServices Client { get; set; }

      public ICAJ004ChequesEnBlancoLView LView { get; set; }
      public ICAJ004ChequesEnBlancoMView MView { get; set; }

      public Movimiento Item { get; set; }
      public ObservableCollection<Movimiento> Items { get; set; }
      public DateTime Fecha { get; set; }

      public String MensajeError { get; set; }
      public Decimal TipoCambio { get; set; }

      public ObservableCollection<Entities.Parametros> ListParametros { get; set; }
      public ObservableCollection<Entities.Tipos> ListTiposMOV { get; set; }

      public Int32? F_MOVI_Codigo { get; set; }
      public String F_CUBA_Codigo { get; set; }
      public Int32? F_ENTC_Codigo { get; set; }
      public DateTime? F_FecIni { get; set; }
      public DateTime? F_FecFin { get; set; }

      public Int32? MOVI_Codigo { get; set; }
      public String[] TiposMovimientos { get; set; }

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
               ObservableCollection<Infrastructure.Aspect.DataAccess.DataAccessFilterSQL> listFilters = new ObservableCollection<Infrastructure.Aspect.DataAccess.DataAccessFilterSQL>();
               listFilters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@psinEMPR_Codigo", FilterValue = Controls.Entorno.ItemEmpresa.EMPR_Codigo, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.Int16, FilterSize = 2 });
               listFilters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@pintMOVI_Codigo", FilterValue = F_MOVI_Codigo, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.Int32, FilterSize = 10 });
               listFilters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@pchrCUBA_Codigo", FilterValue = F_CUBA_Codigo, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.Varchar, FilterSize = 3 });
               listFilters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@pintENTC_Codigo", FilterValue = F_ENTC_Codigo, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.Int32, FilterSize = 4 });
               listFilters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@FecIni", FilterValue = F_FecIni, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.DateTime, FilterSize = 8 });
               listFilters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@FecFin", FilterValue = F_FecFin, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.DateTime, FilterSize = 8 });

               Items = Client.GetAllMovimientoFilter("CAJ_MOVISS_BusquedaChequeBlanco", listFilters);
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
               MView = new CAJ004ChequesEnBlancoMView();
               MView.Presenter = this;
               MView.LoadView();
            }

            MView.ClearItem();
            this.Item = new Movimiento();
            this.Item.SetEstado(Movimiento.Estado.Ingresado);
            this.Item.SetTipoMovimiento(Movimiento.TipoMovimiento.EgresosCheque);
            this.Item.SetEstadoCheque(Movimiento.EstadoCheque.Blanco);

            this.Item.MOVI_TipoCambio = TipoCambio;
            this.Item.EMPR_Codigo = Controls.Entorno.ItemEmpresa.EMPR_Codigo;
            this.Item.SUCR_Codigo = Controls.Entorno.ItemSucursal.SUCR_Codigo;
            this.Item.AUDI_UsrCrea = Session.UserName;
            this.Item.AUDI_FecCrea = Session.Fecha;
            this.Item.Instance = Infrastructure.Aspect.BusinessEntity.InstanceEntity.Added;
            Item.TIPO_Movimiento = Client.GetOneTipos(Item.TIPO_TabMOV, Item.TIPO_CodMOV);
            MView.SetItem();

            isMViewShow = true;
            if (LView != null) { ((CAJ004ChequesEnBlancoMView)MView).Icon = System.Drawing.Icon.FromHandle(((System.Drawing.Bitmap)LView.IconView).GetHicon()); }
            ((CAJ004ChequesEnBlancoMView)MView).ShowDialog();
            ((CAJ004ChequesEnBlancoMView)MView).BringToFront();
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
               MView = new CAJ004ChequesEnBlancoMView();
               MView.Presenter = this;
               MView.LoadView();
            }

            if (MOVI_Codigo.HasValue)
            {
               Item = Client.GetOneMovimiento(Delfin.Controls.Entorno.ItemEmpresa.EMPR_Codigo, MOVI_Codigo.Value, Movimiento.TInterfazMovimiento.ChequeEnBlanco);

            }


            if (Item != null)
            {
               MView.ClearItem();
               this.Item.AUDI_UsrMod = Session.UserName;
               this.Item.AUDI_FecMod = Session.Fecha;
               this.Item.Instance = Infrastructure.Aspect.BusinessEntity.InstanceEntity.Modified;
               Item.TIPO_Movimiento = Client.GetOneTipos(Item.TIPO_TabMOV, Item.TIPO_CodMOV);

               MView.SetItem();

               isMViewShow = true;
               if (LView != null) { ((CAJ004ChequesEnBlancoMView)MView).Icon = System.Drawing.Icon.FromHandle(((System.Drawing.Bitmap)LView.IconView).GetHicon()); }
               ((CAJ004ChequesEnBlancoMView)MView).ShowDialog();
               ((CAJ004ChequesEnBlancoMView)MView).BringToFront();
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
                  Movimiento _item = Item;

                  if (Client.SaveMovimiento(ref _item))
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

      public bool Guardar(Boolean ShowMessage)
      {
         try
         {
            MView.GetItem();
            if (!setNroCheque(Item.CUBA_Codigo, Item.TIPO_Movimiento.TIPO_Desc2, Item.TIPO_Movimiento.TIPO_Num1.Value))
            {
               if (Infrastructure.WinForms.Controls.Dialogos.MostrarMensajePregunta(Title,
                   "No tiene definido para la cuenta bancaria una chequera, ¿desea continuar?.", Infrastructure.WinForms.Controls.Dialogos.LabelBoton.Si_No) == System.Windows.Forms.DialogResult.No)
               { return false; }
            }
            Item.TipoInterfazMovimiento = Entities.Movimiento.TInterfazMovimiento.ChequeEnBlanco;
            if (Item.Validar())
            {
               Movimiento _item = Item;
               if (Client.SaveMovimiento(ref _item, Movimiento.TInterfazMovimiento.ChequeEnBlanco))
               {
                  Item = _item;
                  if (ShowMessage) { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeSatisfactorio(Title, "Se ha guardado satisfactoriamente"); }
                  return true;
               }
               return false;
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
               ((CAJ004ChequesEnBlancoMView)MView).BringToFront();
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

      /// <summary>
      /// 
      /// </summary>
      /// <param name="CUBA_Codigo"></param>
      /// <param name="TipoMovimiento">TIPO_Desc2</param>
      /// <param name="Opcion">TIPO_Num1</param>
      /// <returns></returns>
      public Boolean setNroCheque(String CUBA_Codigo, String TipoMovimiento, Decimal Opcion)
      {
         try
         {
            if (Item.Instance == Infrastructure.Aspect.BusinessEntity.InstanceEntity.Added || Item.Instance == Infrastructure.Aspect.BusinessEntity.InstanceEntity.Modified)
            {
               ObservableCollection<Infrastructure.Aspect.DataAccess.DataAccessFilterSQL> _listFilters = new ObservableCollection<Infrastructure.Aspect.DataAccess.DataAccessFilterSQL>();
               _listFilters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@psinEMPR_Codigo", FilterValue = Delfin.Controls.Entorno.ItemEmpresa.EMPR_Codigo, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.Int16, FilterSize = 22 });
               _listFilters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@pchrCUBA_Codigo", FilterValue = CUBA_Codigo, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.Char, FilterSize = 3 });
               _listFilters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@TipoMovimiento", FilterValue = TipoMovimiento, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.Char, FilterSize = 1 });
               _listFilters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@Opcion", FilterValue = Opcion, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.Int16, FilterSize = 2 });

               ObservableCollection<Entities.Chequera> _listChequeras = Client.GetAllChequeraFilter("CAJ_CHEQSS_UnRegPorCuentaBancaria", _listFilters);
               if (_listChequeras.Count > 0)
               {
                  Item.ItemChequera = _listChequeras[0];
                  return true;
               }
               else
               { return false; }
            }
            return false;
         }
         catch (Exception)
         { throw; }
      }

      public void CloseView()
      {
         if (isMViewShow)
         { ((CAJ004ChequesEnBlancoMView)MView).Close(); }
      }
      public void IsClosedMView()
      { isMViewShow = false; }

      #endregion

      #region [ Metodos Eventos/Tareas ]

      #endregion
   }
}