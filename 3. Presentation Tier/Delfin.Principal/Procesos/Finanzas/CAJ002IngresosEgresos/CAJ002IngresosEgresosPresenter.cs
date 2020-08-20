using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Infrastructure.Aspect.BusinessEntity;
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
using System.Drawing.Printing;
using System.Drawing;
using Microsoft.Reporting.WinForms;


namespace Delfin.Principal
{
   public partial class CAJ002IngresosEgresosPresenter : ICloneable
   {
      #region [ Variables ]

      public String Title = "Movimientos";
      public String CUS = "CAJ002";
      public Boolean FleteNegativo = false;
      private Infrastructure.Aspect.Constants.TipoMovimientoCtaCte m_tmovimiento;

      public enum TInicio
      {
         Normal = 0, SoloMovimiento = 1
      }

      public enum TBusqueda
      {
         Base = 0, Liquidaciones = 1
      }

      #endregion

      #region [ Constructor ]

      public CAJ002IngresosEgresosPresenter(IUnityContainer x_container, ICAJ002IngresosEgresosLView x_lview, Infrastructure.Aspect.Constants.TipoMovimientoCtaCte x_tmovimiento)
      {
         try
         {
            this.ContainerService = x_container;
            Session = this.ContainerService.Resolve<ISessionService>();
            this.LView = x_lview;
            TMovimiento = x_tmovimiento;
            switch (x_tmovimiento)
            {
               case Infrastructure.Aspect.Constants.TipoMovimientoCtaCte.Ingresos:
                  Title = "Movimiento de Ingresos";
                  CUS = "CAJ002";
                  break;
               case Infrastructure.Aspect.Constants.TipoMovimientoCtaCte.Egresos:
                  Title = "Movimiento de Egresos";
                  CUS = "CAJ003";
                  break;
               default:
                  break;
            }
         }
         catch (Exception)
         { throw; }
      }

      public CAJ002IngresosEgresosPresenter(IUnityContainer x_container, Infrastructure.Aspect.Constants.TipoMovimientoCtaCte x_tmovimiento, TInicio x_opcion)
      {
         try
         {
            this.ContainerService = x_container;
            Session = this.ContainerService.Resolve<ISessionService>();
            TipoInicio = x_opcion;
            TMovimiento = x_tmovimiento;
            //Entities.Parametros _param = new Entities.Parametros();
            //_param = Client.GetOneParametrosByClave("EMPRESA");
            //if (_param != null)
            //{
            //   Int32 ENTC_CodEmpresa = 0;
            //   if (Int32.TryParse(_param.PARA_Valor, out ENTC_CodEmpresa))
            //   {  }
            //}
            switch (x_tmovimiento)
            {
               case Infrastructure.Aspect.Constants.TipoMovimientoCtaCte.Ingresos:
                  Title = "Movimiento de Ingresos";
                  CUS = "CAJ002";
                  break;
               case Infrastructure.Aspect.Constants.TipoMovimientoCtaCte.Egresos:
                  Title = "Movimiento de Egresos";
                  CUS = "CAJ003";
                  break;
               default:
                  break;
            }
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

            ListParametros = Client.GetAllParametros();

            #region [ Obtener el Tipo de Cambio segun configuración de parametros ]

            Entities.Parametros _parametros;
            ETipoCambio = TCambio.Ventas;
            
            switch (TMovimiento)
            {
               case Infrastructure.Aspect.Constants.TipoMovimientoCtaCte.Egresos:
                  _parametros = ListParametros.Where(Para => Para.PARA_Clave.Equals("TCCTACTE_PRO")).FirstOrDefault();
                  if (_parametros != null && _parametros.PARA_Valor != null)
                  { ETipoCambio = _parametros.PARA_Valor.Equals("VEN") ? TCambio.Ventas : TCambio.Compras; }
                  break;
               case Infrastructure.Aspect.Constants.TipoMovimientoCtaCte.Ingresos:
                  _parametros = ListParametros.Where(Para => Para.PARA_Clave.Equals("TCCTACTE_CLI")).FirstOrDefault();
                  if (_parametros != null && _parametros.PARA_Valor != null)
                  { ETipoCambio = _parametros.PARA_Valor.Equals("COM") ? TCambio.Ventas : TCambio.Compras; }

                  break;
            }
            #endregion

            ListTiposMOV = Client.GetAllTiposByTipoCodTabla("MOV").Where(Mov => Mov.TIPO_Desc2.Equals(Infrastructure.Aspect.Constants.Util.getTipoMovimientoCtaCte(TMovimiento))).ToObservableCollection();

            #region [ Obtener Parametros para Tipo de Movimiento ]

            String x_tmov = "";
            _parametros = ListParametros.Where(Para => Para.PARA_Clave.Equals("TIPO_MOV_DESDIF")).FirstOrDefault();
            if (_parametros != null && _parametros.PARA_Valor != null)
            { x_tmov = _parametros.PARA_Valor; }

            String[] x_Tipos_mov = x_tmov.Split('|');
            ListTiposMOV_Dif = new ObservableCollection<Tipos>();
            foreach (String iTMov in x_Tipos_mov)
            {
               Tipos _tipo_mov = ListTiposMOV.Where(Mov => Mov.TIPO_CodTipo.Equals(iTMov)).FirstOrDefault();
               if (_tipo_mov != null) { ListTiposMOV_Dif.Add((Tipos)_tipo_mov.Clone()); }
            }
            
            #endregion

            ListTipoDES = Client.GetAllTiposByTipoCodTabla("DES").ToObservableCollection();

            switch (TipoInicio)
            {
               case TInicio.Normal:
                  LView.LoadView();
                  break;
               case TInicio.SoloMovimiento:
                  _parametros = ListParametros.Where(Para => Para.PARA_Clave.Equals("EMPRESA")).FirstOrDefault();
                  if (_parametros != null && _parametros.PARA_Valor != null)
                  {
                     Int32 x_ENTC_CodEmpresa = 0;
                     if (Int32.TryParse(_parametros.PARA_Valor, out x_ENTC_CodEmpresa))
                     { ENTC_CodEmpresa = x_ENTC_CodEmpresa; }
                  }
                  break;
            }

            #region [ Setear el tipo de Cambio a utilizar ]

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

            #endregion

            DSPeriodos = new System.Data.DataSet();
            DSPeriodos = Client.GetDSDocsVta("CON_CENTSS_PeriodosDisponibles", null);

            TipoBusqueda = TBusqueda.Base;
            ListMView = new ObservableCollection<ICAJ002IngresosEgresosMView>();
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Title, "Ha ocurrido un error inicializando la vista.", ex); }
      }

      #endregion

      #region [ Propiedades ]

      public IUnityContainer ContainerService { get; set; }
      public ISessionService Session { get; set; }
      public IDelfinServices Client { get; set; }

      public ICAJ002IngresosEgresosLView LView { get; set; }
      public ObservableCollection<ICAJ002IngresosEgresosMView> ListMView { get; set; }
      public ICAJ002IngresosEgresosMView MView { get; set; }
      public CAJ002IngresosEgresosDView DView { get; set; }
      public CAJ002IngresosEgresosDViewEDiferido EViewDiferido { get; set; }
      public CAJ002IngresosEgresosFlujoDView FlujoDView { get; set; }
      public Entities.Movimiento Item { get; set; }
      public Entities.Movimiento ItemLView { get; set; }
      public ObservableCollection<Entities.Movimiento> Items { get; set; }
      public ObservableCollection<Entities.Parametros> ListParametros { get; set; }
      public ObservableCollection<Entities.Tipos> ListTiposMOV { get; set; }
      public ObservableCollection<Entities.Tipos> ListTiposMOV_Dif { get; set; }
      public ObservableCollection<Entities.MovimientoFlujo> ItemsMovimientosFlujo { get; set; }

      public Infrastructure.Aspect.Constants.TipoMovimientoCtaCte TMovimiento
      {
         get { return m_tmovimiento; }
         set { m_tmovimiento = value; }
      }
      public ObservableCollection<Tipos> ListTipoDES { get; set; }

      public TInicio TipoInicio { get; set; }
      public Decimal TipoCambio { get; set; }
      public String MensajeError { get; set; }

      public DateTime Fecha { get; set; }
      public TBusqueda TipoBusqueda { get; set; }
      public Int32 ENTC_CodEmpresa { get; set; }

      public System.Data.DataSet DSPeriodos { get; set; }

      #region [ Propiedades Utilizadas para la Busqueda del LView ]

      public Int32? F_MOVI_Codigo { get; set; }
      public String F_CUBA_Codigo { get; set; }
      public String F_MOVI_NroOperacion { get; set; }
      public Int32? F_ENTC_Codigo { get; set; }
      public String F_TIPO_CodMOV { get; set; }
      public Int16? F_TIPE_Codigo { get; set; }
      public DateTime? F_FecIni { get; set; }
      public DateTime? F_FecFin { get; set; }

      public Int32? MOVI_Codigo { get; set; }
      public String MOVI_Estado { get; set; }
      public String TIPO_TabMOV { get; set; }
      public String TIPO_CodMOV { get; set; }

      private Boolean isMViewShow = false;

      public String F_AsientoDG { get; set; }
      public String F_AsientoDC { get; set; }

      public TCambio ETipoCambio { get; set; }

      #endregion

      public Decimal Total { get; set; }
      public Decimal Pendiente { get; set; }

      #endregion

      #region [ Metodos ]

      /// <summary>
      /// Cargar el listado de la pantalla Principal LView
      /// </summary>
      public void Actualizar()
      {
         try
         {
            ItemLView = null;
            Items = null;

            if (LView != null)
            {
               ObservableCollection<Infrastructure.Aspect.DataAccess.DataAccessFilterSQL> listFilters = new ObservableCollection<Infrastructure.Aspect.DataAccess.DataAccessFilterSQL>();
               listFilters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@psinEMPR_Codigo", FilterValue = Controls.Entorno.ItemEmpresa.EMPR_Codigo, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.Int16, FilterSize = 2 });
               listFilters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@pintMOVI_Codigo", FilterValue = F_MOVI_Codigo, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.Int32, FilterSize = 10 });
               listFilters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@pchrCUBA_Codigo", FilterValue = F_CUBA_Codigo, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.Varchar, FilterSize = 3 });
               listFilters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@pintMOVI_NroOperacion", FilterValue = F_MOVI_NroOperacion, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.Varchar, FilterSize = 20 });
               listFilters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@pintENTC_Codigo", FilterValue = F_ENTC_Codigo, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.Int32, FilterSize = 4 });
               listFilters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@pchrTIPO_CodMOV", FilterValue = F_TIPO_CodMOV, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.Varchar, FilterSize = 3 });
               listFilters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@FecIni", FilterValue = F_FecIni, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.DateTime, FilterSize = 8 });
               listFilters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@FecFin", FilterValue = F_FecFin, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.DateTime, FilterSize = 8 });
               listFilters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@TIPE_Codigo", FilterValue = F_TIPE_Codigo, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.Int16, FilterSize = 2 });

               listFilters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@Asiento_DG", FilterValue = F_AsientoDG, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.Varchar, FilterSize = 20 });
               listFilters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@Asiento_DC", FilterValue = F_AsientoDC, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.Varchar, FilterSize = 20 });

               switch (TMovimiento)
               {
                  case TipoMovimientoCtaCte.Ingresos:
                     listFilters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@TipoIE", FilterValue = "I", FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.Char, FilterSize = 1 });
                     //Items = Client.GetAllMovimientoFilter("CAJ_MOVISS_IngresosBusqueda", listFilters);
                     break;
                  case TipoMovimientoCtaCte.Egresos:
                     listFilters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@TipoIE", FilterValue = "E", FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.Char, FilterSize = 1 });
                     //Items = Client.GetAllMovimientoFilter("CAJ_MOVISS_EgresosBusqueda", listFilters);
                     break;
               }
               Items = Client.GetAllMovimientoFilter("CAJ_MOVISS_Busqueda", listFilters);
               LView.ShowItems();
            }
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Title, "Ha ocurrido un error actualizando.", ex); }
      }

      public Decimal GetTipoCambio(DateTime x_fecha)
      {
         Decimal x_TipoCambio = 0;
         try
         {
            /*
             * Obtener el tipo de cambio
             */
            String fecha = x_fecha.ToString("yyyyMMdd");

            Entities.TiposCambio _TCambio = Client.GetOneTiposCambio(fecha);

            //Entities.TiposCambio _TCambio = GetTipoCambio(Fecha);

            MensajeError = "";
            if (_TCambio != null)
            {
               switch (ETipoCambio)
               {
                  case TCambio.Ventas:
                     x_TipoCambio = _TCambio.TIPC_Venta;
                     break;
                  case TCambio.Compras:
                     x_TipoCambio = _TCambio.TIPC_Compra;
                     break;
               }
               if (!(x_TipoCambio > 0))
               { MensajeError = String.Format("El tipo de Cambio definido para [{0:dd/MM/yyyy}] no es correcto.", Fecha); Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Title, MensajeError); }
            }
            else { MensajeError = String.Format("No se ha definido el tipo de cambio para el dia {0:dd/MM/yyyy}", Fecha); Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Title, MensajeError); }
         }
         catch (Exception)
         { }
         return x_TipoCambio;
      }

      /// <summary>
      /// Crear un nuevo registro de Ingreso/Egreso segun la opción de inicio de la aplicación
      /// </summary>
      /// <param name="x_CuentaBancaria">Clase de cuenta bancaria</param>
      public void Nuevo(Entities.CuentasBancarias x_CuentaBancaria)
      {
         try
         {
            if (TipoCambio == 0) { TipoCambio = GetTipoCambio(Fecha); }

            MView = new CAJ002IngresosEgresosMView(CAJ002IngresosEgresosMView.TipoInicio.Nuevo);
            MView.Presenter = (this.Clone() as CAJ002IngresosEgresosPresenter);
            MView.PresenterBase = this;
            MView.LoadView();

            MView.ClearItem();
            MView.Presenter.Item = new Entities.Movimiento();
            MView.Presenter.Item.EMPR_Codigo = Controls.Entorno.ItemEmpresa.EMPR_Codigo;
            MView.Presenter.Item.SUCR_Codigo = Controls.Entorno.ItemSucursal.SUCR_Codigo;
            MView.Presenter.Item.AUDI_UsrCrea = Session.UserName;
            MView.Presenter.Item.AUDI_FecCrea = Session.Fecha;
            MView.Presenter.Item.MOVI_FecEmision = Fecha;
            MView.Presenter.Item.MOVI_FecOperacion = Fecha;
            MView.Presenter.Item.Instance = Infrastructure.Aspect.BusinessEntity.InstanceEntity.Added;
            MView.Presenter.Item.ListFlujos = new ObservableCollection<MovimientoFlujo>();
            MView.Presenter.Item.ListDetCtaCte = new ObservableCollection<DetCtaCte>();
            MView.Presenter.Item.SetEstado(Movimiento.Estado.Ingresado);
            MView.Presenter.Item.SetEstadoCheque(Movimiento.EstadoCheque.Cartera);
            MView.Presenter.Item.ItemCuentasBancarias = x_CuentaBancaria;
            MView.Presenter.Item.TIPO_CodMOV = getTipoMovimiento(TMovimiento);
            MView.Presenter.Item.ListTipificaciones = new ObservableCollection<Tipificaciones>();
            MView.Presenter.Item.ListTipificacionesEliminados = new ObservableCollection<Tipificaciones>();
            switch (TMovimiento)
            {
               case TipoMovimientoCtaCte.Ingresos:
                  MView.Presenter.Item.TIPE_Codigo = Controls.EntidadClear.GetCodigoTipoEntidad(Controls.TiposEntidad.TIPE_Cliente);
                  break;
               case TipoMovimientoCtaCte.Egresos:
                  MView.Presenter.Item.TIPE_Codigo = Controls.EntidadClear.GetCodigoTipoEntidad(Controls.TiposEntidad.TIPE_Proveedor);
                  break;
            }

            if (!String.IsNullOrEmpty(MensajeError))
            { MView.SetEnabled(false); Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Title, MensajeError); }
            MView.SetItem();

            if (LView != null) { ((CAJ002IngresosEgresosMView)MView).Icon = System.Drawing.Icon.FromHandle(((System.Drawing.Bitmap)LView.IconView).GetHicon()); }
            ((CAJ002IngresosEgresosMView)MView).Show();
            ((CAJ002IngresosEgresosMView)MView).BringToFront();
            ListMView.Add(MView);
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Title, Infrastructure.Aspect.Constants.Mensajes.NewPresenter, ex); }
      }

      /// <summary>
      /// Crear un nuevo registro
      /// </summary>
      /// <returns></returns>
      public DialogResult Nuevo()
      {
         try
         {
            MView = new CAJ002IngresosEgresosMView(CAJ002IngresosEgresosMView.TipoInicio.Nuevo);
            MView.Presenter = this;
            MView.LoadView();

            MView.ClearItem();
            MView.Presenter.Item = new Entities.Movimiento();
            MView.Presenter.Item.EMPR_Codigo = Controls.Entorno.ItemEmpresa.EMPR_Codigo;
            MView.Presenter.Item.SUCR_Codigo = Controls.Entorno.ItemSucursal.SUCR_Codigo;
            MView.Presenter.Item.AUDI_UsrCrea = Session.UserName;
            MView.Presenter.Item.AUDI_FecCrea = Session.Fecha;
            MView.Presenter.Item.MOVI_FecEmision = Fecha;
            MView.Presenter.Item.Instance = Infrastructure.Aspect.BusinessEntity.InstanceEntity.Added;
            MView.Presenter.Item.ListDetCtaCte = new ObservableCollection<DetCtaCte>();
            MView.Presenter.Item.SetEstado(Movimiento.Estado.Ingresado);
            MView.Presenter.Item.SetEstadoCheque(Movimiento.EstadoCheque.Cartera);
            MView.Presenter.Item.TIPE_Codigo = Controls.EntidadClear.GetCodigoTipoEntidad(Controls.TiposEntidad.TIPE_Cliente);
            MView.Presenter.Item.ENTC_Codigo = ENTC_CodEmpresa;

            switch (TMovimiento)
            {
               case TipoMovimientoCtaCte.Ingresos:
                  MView.Presenter.Item.SetTipoMovimiento(Movimiento.TipoMovimiento.IngresosTransferenciaCuentasPropias);
                  break;
               case TipoMovimientoCtaCte.Egresos:
                  MView.Presenter.Item.SetTipoMovimiento(Movimiento.TipoMovimiento.EgresosTransferenciaCuentasPropias);
                  break;
               default:
                  break;
            }
            if (!String.IsNullOrEmpty(MensajeError))
            {
               MView.SetEnabled(false);
               Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Title, MensajeError);
            }
            MView.SetItem();
            if (LView != null) { ((CAJ002IngresosEgresosMView)MView).Icon = System.Drawing.Icon.FromHandle(((System.Drawing.Bitmap)LView.IconView).GetHicon()); }
            ((CAJ002IngresosEgresosMView)MView).Height = ((CAJ002IngresosEgresosMView)MView).Height - (187 + 27 * 3);
            ((CAJ002IngresosEgresosMView)MView).StartPosition = FormStartPosition.CenterScreen;
            return ((CAJ002IngresosEgresosMView)MView).ShowDialog();
         }
         catch (Exception ex)
         {
            Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Title, Infrastructure.Aspect.Constants.Mensajes.NewPresenter, ex);
            return DialogResult.Cancel;
         }
      }

      public void Editar()
      {
         try
         {
            if (MOVI_Codigo.HasValue)
            {
               /*
                * Verificar si existe una instancia ya abierta
                */
               MView =
                  ListMView.Where(
                     MV => MV.Presenter.ItemLView != null)
                     .ToObservableCollection().Where(MV_Data => MV_Data.Presenter.ItemLView.MOVI_Codigo == MOVI_Codigo.Value).ToObservableCollection()
                     .FirstOrDefault();
               if (MView == null)
               {
                  MView = new CAJ002IngresosEgresosMView(CAJ002IngresosEgresosMView.TipoInicio.Editar);
                  MView.Presenter = (this.Clone() as CAJ002IngresosEgresosPresenter);
                  MView.PresenterBase = this;
                  MView.LoadView();
                  MView.Presenter.Item = Client.GetOneMovimiento(Controls.Entorno.ItemEmpresa.EMPR_Codigo, MOVI_Codigo.Value);
                  if (MView.Presenter.Item != null)
                  {
                     MView.ClearItem();
                     MView.Presenter.Item.AUDI_UsrMod = Session.UserName;
                     MView.Presenter.Item.AUDI_FecMod = Session.Fecha;
                     MView.Presenter.Item.AUDI_UsrCrea = Session.UserName;
                     MView.Presenter.Item.Instance = Infrastructure.Aspect.BusinessEntity.InstanceEntity.Modified;
                     MView.SetItem();

                     if (!String.IsNullOrEmpty(MView.Presenter.Item.MOVI_EstadoCheque))
                     {
                        if (MView.Presenter.Item.MOVI_EstadoCheque.Equals(Movimiento.GetEstadoCheque(Movimiento.EstadoCheque.Blanco)))
                        { MView.Presenter.Item.SetEstadoCheque(Movimiento.EstadoCheque.Cartera); }
                        else
                        {
                           if ((MView.Presenter.Item.TIPO_CodMOV.Equals(MView.Presenter.Item.GetTipoMovimiento(Entities.Movimiento.TipoMovimiento.EgresosChequeDiferido)) || MView.Presenter.Item.TIPO_CodMOV.Equals(MView.Presenter.Item.GetTipoMovimiento(Entities.Movimiento.TipoMovimiento.IngresosDiferidos))) && !MView.Presenter.Item.MOVI_FecEjecutado.HasValue)
                           { MView.SetDiferido(); }
                        }
                     }
                     else
                     {
                        if ((MView.Presenter.Item.TIPO_CodMOV.Equals(MView.Presenter.Item.GetTipoMovimiento(Entities.Movimiento.TipoMovimiento.EgresosChequeDiferido)) || MView.Presenter.Item.TIPO_CodMOV.Equals(MView.Presenter.Item.GetTipoMovimiento(Entities.Movimiento.TipoMovimiento.IngresosDiferidos))) && !MView.Presenter.Item.MOVI_FecEjecutado.HasValue)
                        { MView.SetDiferido(); }
                     }

                     MView.EnabledItemEditar(false);
                     if (MView.Presenter.Item.MOVI_FecEjecutado.HasValue) { MView.SetEjecutado(); }
                     if (MView.Presenter.Item.CONS_CodEST.Equals(Entities.Movimiento.GetEstado(Entities.Movimiento.Estado.Anulado)))
                     { MView.SetEnabled(false); }
                     if (LView != null) { ((CAJ002IngresosEgresosMView)MView).Icon = System.Drawing.Icon.FromHandle(((System.Drawing.Bitmap)LView.IconView).GetHicon()); }
                     ((CAJ002IngresosEgresosMView)MView).Show();
                     ((CAJ002IngresosEgresosMView)MView).BringToFront();
                     ListMView.Add(MView);
                  }
                  else
                  {
                     Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Title, "Debe seleccionar un elemento de la grilla");
                  }
               }
               else
               {
                  Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Title, "Ya ha abierto el registro seleccionado");
                  ((CAJ002IngresosEgresosMView)MView).BringToFront();
               }
            }
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Title, Infrastructure.Aspect.Constants.Mensajes.EditPresenter, ex); }
      }

      public DialogResult EditarMovimiento()
      {
         try
         {
            MView = new CAJ002IngresosEgresosMView(CAJ002IngresosEgresosMView.TipoInicio.Editar);
            MView.Presenter = this;
            MView.LoadView();
            if (MView.Presenter.Item != null)
            {
               MView.ClearItem();
               MView.Presenter.Item.AUDI_UsrMod = Session.UserName;
               MView.Presenter.Item.AUDI_FecMod = Session.Fecha;
               MView.Presenter.Item.Instance = Infrastructure.Aspect.BusinessEntity.InstanceEntity.Modified;
               MView.SetItem();
               if (LView != null) { ((CAJ002IngresosEgresosMView)MView).Icon = System.Drawing.Icon.FromHandle(((System.Drawing.Bitmap)LView.IconView).GetHicon()); }
               ((CAJ002IngresosEgresosMView)MView).Height = ((CAJ002IngresosEgresosMView)MView).Height - (187 + 27 * 2);
               ((CAJ002IngresosEgresosMView)MView).StartPosition = FormStartPosition.CenterScreen;
               return ((CAJ002IngresosEgresosMView)MView).ShowDialog();
            }
            else
            {
               Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Title, "Debe seleccionar un elemento de la grilla");
            }
            return DialogResult.Cancel;
         }
         catch (Exception ex)
         {
            Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Title, Infrastructure.Aspect.Constants.Mensajes.EditPresenter, ex);
            return DialogResult.Cancel;
         }
      }

      public void Eliminar()
      {
         try
         {
            if (ItemLView != null)
            {
               System.Windows.Forms.DialogResult _result = Infrastructure.WinForms.Controls.Dialogos.MostrarMensajePregunta(Title, Infrastructure.Aspect.Constants.Mensajes.PreguntaEliminar, Infrastructure.WinForms.Controls.Dialogos.LabelBoton.Si_No);
               if (_result == System.Windows.Forms.DialogResult.Yes)
               {
                  ItemLView.Instance = Infrastructure.Aspect.BusinessEntity.InstanceEntity.Deleted;
                  Entities.Movimiento _item = ItemLView;
                  if (Client.SaveMovimiento(ref _item))
                  {
                     ItemLView = _item;
                     if (ItemLView != null)
                     {
                        Actualizar();
                        Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeSatisfactorio(Title, "Se ha eliminado el item.");
                     }
                     else
                     { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Title, "Ha ocurrido un error al guardar el item."); }
                  }
               }
            }
            else
            { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Title, "Debe seleccionar un elemento de la grilla"); }
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Title, Infrastructure.Aspect.Constants.Mensajes.DeletePresenter, ex); }
      }

      /// <summary>
      /// Anular registros
      /// </summary>
      public void Anular()
      {
         try
         {
            if (!MOVI_Estado.Equals(Entities.Movimiento.GetEstado(Entities.Movimiento.Estado.Anulado)))
            {
               if (
                  Infrastructure.WinForms.Controls.Dialogos.MostrarMensajePregunta(Title,
                     "¿Desea Anular el registro seleccionado?",
                     Infrastructure.WinForms.Controls.Dialogos.LabelBoton.Si_No) ==
                  System.Windows.Forms.DialogResult.Yes)
               {
                  MotivoAnulacion _motivoAnulacion = new MotivoAnulacion() { StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen };
                  DateTime _fecha = Fecha;
                  if (_motivoAnulacion.LoadControl(_fecha, Session.UserName) ==
                      System.Windows.Forms.DialogResult.OK)
                  {
                     Entities.Movimiento _movimiento = new Movimiento();
                     _movimiento.EMPR_Codigo = Controls.Entorno.ItemEmpresa.EMPR_Codigo;
                     _movimiento.MOVI_Codigo = MOVI_Codigo.Value;
                     _movimiento.TIPO_TabMOV = TIPO_TabMOV;
                     _movimiento.TIPO_CodMOV = TIPO_CodMOV;
                     _movimiento.MOVI_FecAnulacion = _fecha;
                     _movimiento.MOVI_GlosaAnulacion = _motivoAnulacion.Observacion;
                     _movimiento.MOVI_UserAnulacion = Session.UserName;
                     _movimiento.AUDI_UsrMod = Session.UserName;

                     if (Client.SaveMovimientoAnular(ref _movimiento))
                     {
                        Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeSatisfactorio(Title, "Se Anulo el registro Satisfactoriamente.");
                        Actualizar();
                     }
                  }
               }
            }
            else
            { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Title, "NO puede anular un registro ya anulado."); }
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Title, "Ha ocurrido un error anulando.", ex); }
      }

      /// <summary>
      /// Procedimiento para imprimir un registro tipo cheque, utilizando los valores configurados en la chequera del la cuenta corriente
      /// con la que se creo el registro de Egreso
      /// </summary>
      /// <param name="e"></param>
      public void Imprimir(System.Drawing.Printing.PrintPageEventArgs e)
      {
         try
         {
            String x_printename = "";
            try
            {
               Entities.Parametros _para = Client.GetOneParametrosByClave(String.Format("IMP-{0}", Session.UserName));
               if (_para != null && !String.IsNullOrEmpty(_para.PARA_Valor)) { x_printename = _para.PARA_Valor; }
               else
               {
                  Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Title, "No se ha configurado la Impresora para su usuario, el proceso no puede completarse");
                  return;
               }
            }
            catch (Exception)
            {
               Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Title, "No se ha configurado la Impresora para su usuario, el proceso no puede completarse");
               return;
            }

            ItemLView.TIPO_Movimiento = Client.GetOneTipos(ItemLView.TIPO_TabMOV, ItemLView.TIPO_CodMOV);
            if (setNroCheque(ItemLView.CUBA_Codigo, ItemLView.TIPO_Movimiento.TIPO_Desc2, ItemLView.TIPO_Movimiento.TIPO_Num1.Value))
            {
               System.Drawing.Font fuente = new System.Drawing.Font("Verdana", 8);

               if (!String.IsNullOrEmpty(ItemLView.ItemChequera.CHEQ_Coordenadas))
               {
                  Int32 x_CFecha_X = 0, x_CFecha_Y = 0, x_COrdenDe_X = 0, x_COrdenDe_Y = 0, x_CMonto_X = 0, x_CMonto_Y = 0, x_CMontoLetras_X = 0, x_CMontoLetras_Y = 0
                      , x_CFirma1_X = 0, x_CFirma1_Y = 0, x_CFirma2_X = 0, x_CFirma2_Y = 0, x_CNoNegociable_X = 0, x_CNoNegociable_Y = 0, x_CReferencias_X = 0, x_CReferencias_Y = 0;


                  String[] _coord = ItemLView.ItemChequera.CHEQ_Coordenadas.Split('|');
                  for (int i = 0; i < _coord.Count(); i++)
                  {
                     String[] _valor = _coord[i].Split(',');
                     if (i == 0) { x_CFecha_X = Int32.Parse(_valor[0]); x_CFecha_Y = Int32.Parse(_valor[1]); }
                     if (i == 1) { x_COrdenDe_X = Int32.Parse(_valor[0]); x_COrdenDe_Y = Int32.Parse(_valor[1]); }
                     if (i == 2) { x_CMonto_X = Int32.Parse(_valor[0]); x_CMonto_Y = Int32.Parse(_valor[1]); }
                     if (i == 3) { x_CMontoLetras_X = Int32.Parse(_valor[0]); x_CMontoLetras_Y = Int32.Parse(_valor[1]); }
                     if (i == 4) { x_CFirma1_X = Int32.Parse(_valor[0]); x_CFirma1_Y = Int32.Parse(_valor[1]); }
                     if (i == 5) { x_CFirma2_X = Int32.Parse(_valor[0]); x_CFirma2_Y = Int32.Parse(_valor[1]); }
                     if (i == 6) { x_CNoNegociable_X = Int32.Parse(_valor[0]); x_CNoNegociable_Y = Int32.Parse(_valor[1]); }
                     if (i == 7) { x_CReferencias_X = Int32.Parse(_valor[0]); x_CReferencias_Y = Int32.Parse(_valor[1]); }
                  }

                  //System.Drawing.Printing.PrintPageEventArgs e = new PrintPageEventArgs();
                  e.Graphics.PageUnit = GraphicsUnit.Millimeter;
                  e.Graphics.DrawString(ItemLView.MOVI_FecEmision.ToString(), fuente, System.Drawing.Brushes.Black, x_CFecha_X, x_CFecha_Y);
                  e.Graphics.DrawString(ItemLView.MOVI_OrdenDe.ToString(), fuente, System.Drawing.Brushes.Black, x_COrdenDe_X, x_COrdenDe_Y);
                  e.Graphics.DrawString(ItemLView.MOVI_MontoHaber.ToString(), fuente, System.Drawing.Brushes.Black, x_CMonto_X, x_CMonto_Y);

                  String MontoLetras = Infrastructure.Aspect.Constants.Util.NumberToText(ItemLView.MOVI_MontoHaber);
                  e.Graphics.DrawString(MontoLetras, fuente, System.Drawing.Brushes.Black, x_CMontoLetras_X, x_CMontoLetras_Y);
                  String Firma1 = "-", Firma2 = "-";

                  ObservableCollection<Infrastructure.Aspect.DataAccess.DataAccessFilterSQL> _listFilters = new ObservableCollection<Infrastructure.Aspect.DataAccess.DataAccessFilterSQL>();
                  _listFilters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@psinEMPR_Codigo", FilterValue = ItemLView.EMPR_Codigo, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.Int16, FilterSize = 22 });
                  _listFilters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@pchrCUBA_Codigo", FilterValue = ItemLView.CUBA_Codigo, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.Varchar, FilterSize = 20 });

                  ItemLView.ItemsFirmas = Client.GetAllFirmasFilter("CAJ_FIRMSS_TodosByFilters", _listFilters);
                  if (ItemLView.ItemsFirmas != null && ItemLView.ItemsFirmas.Count > 0)
                  {
                     Firma1 = String.Format("{1}{0}{2}", Environment.NewLine, ItemLView.ItemsFirmas[0].FIRM_Nombre, ItemLView.ItemsFirmas[0].FIRM_Cargo);
                     if (ItemLView.ItemsFirmas.Count > 1)
                     { Firma2 = String.Format("{1}{0}{2}", Environment.NewLine, ItemLView.ItemsFirmas[1].FIRM_Nombre, ItemLView.ItemsFirmas[1].FIRM_Cargo); }
                  }

                  e.Graphics.DrawString(Firma1, fuente, System.Drawing.Brushes.Black, x_CFirma1_X, x_CFirma1_Y);
                  e.Graphics.DrawString(Firma2, fuente, System.Drawing.Brushes.Black, x_CFirma2_X, x_CFirma2_Y);
                  e.Graphics.DrawString(ItemLView.MOVI_NoNegociable ? "NO NEGOCIABLE" : "", fuente, System.Drawing.Brushes.Black, x_CNoNegociable_X, x_CNoNegociable_Y);
                  e.Graphics.DrawString(ItemLView.MOVI_Referencia.ToString(), fuente, System.Drawing.Brushes.Black, x_CReferencias_X, x_CReferencias_Y);

               }
               else
               { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Title, "No se han configurado las coordenadas para la impresión del cheque"); }
            }
            else { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Title, "No existe una chequera definida para imprimir este cheque"); }

         }
         catch (Exception)
         { throw; }
      }

      public Boolean ImprimirRecIngresos()
      {
         try
         {
            if (Infrastructure.WinForms.Controls.Dialogos.MostrarMensajePregunta(Title, "¿Desea Imprimir el Recibo?", Infrastructure.WinForms.Controls.Dialogos.LabelBoton.Si_No) == System.Windows.Forms.DialogResult.Yes)
            {
               System.Data.DataTable dtReporte = new System.Data.DataTable();
               ObservableCollection<Infrastructure.Aspect.DataAccess.DataAccessFilterSQL> _listFilters = new ObservableCollection<Infrastructure.Aspect.DataAccess.DataAccessFilterSQL>();
               _listFilters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@psinEMPR_Codigo", FilterValue = Delfin.Controls.Entorno.ItemEmpresa.EMPR_Codigo, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.Int16, FilterSize = 2 });
               _listFilters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@pintMOVI_Codigo", FilterValue = ItemLView.MOVI_Codigo, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.Int32, FilterSize = 4 });
               //_listFilters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@TipoMovimiento", FilterValue = TMovimiento == TipoMovimientoCtaCte.Ingresos ? "I" : "E", FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.Char, FilterSize = 1 });
               dtReporte = Client.GetDTCuentasBancarias("CAJ_MOVISS_ImprimirComprobante", _listFilters);

               if (dtReporte != null && dtReporte.Rows.Count > 0)
               {
                  dtReporte.Rows[0]["MontoLetras"] = Delfin.Controls.Utilitarios.NumeroALetras(dtReporte.Rows[0]["ImporteRecibido"].ToString(), "");
                  dtReporte.Rows[0]["Usuario"] = Session.UserName + "-" + DateTime.Now.ToString();

                  String ReportPath = null;
                  dtReporte.TableName = "DTPagos";
                  ReportPath = Application.StartupPath + @"\Reportes\CAJ002IngresosEgresosPagos.rdlc";

                  Microsoft.Reporting.WinForms.ReportParameter[] _parameters = new Microsoft.Reporting.WinForms.ReportParameter[1];
                  _parameters[0] = new Microsoft.Reporting.WinForms.ReportParameter("parTipoMovimiento", (TMovimiento == TipoMovimientoCtaCte.Ingresos ? "I" : "E"));

                  ReportDataSource RepDetalle = new ReportDataSource("DTPagos", dtReporte);

                  Visualizador rpt = new Visualizador("Comprobante de Pago", ReportPath, RepDetalle, _parameters);
                  rpt.StartPosition = FormStartPosition.CenterScreen;
                  rpt.Imprimir();
                  rpt.ShowDialog();
                  return true;
               }
               else
               { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Title, "No se encontro información para la impresión."); }
            }
            return false;
         }
         catch (Exception)
         { throw; }
      }

      public bool Guardar(Boolean ShowMessage)
      {
         try
         {
            MView.GetItem();
            FleteNegativo = false;
            if (Item.Validar())
            {
               //
               //Item.ListFlujos = ItemsMovimientosFlujo;
               Entities.Movimiento _item = Item;
               /*
                * Actualizar Estado del Cheque Si es un cheque en blanco 
                */
               if (!String.IsNullOrEmpty(_item.MOVI_EstadoCheque))
               {
                  if (_item.MOVI_EstadoCheque.Equals(Movimiento.GetEstadoCheque(Movimiento.EstadoCheque.Blanco)))
                  { _item.SetEstadoCheque(Movimiento.EstadoCheque.Cartera); }
               }
               /* 
                * Guardar Movimiento 
                */
               if (Client.SaveMovimiento(ref _item))
               {
                  Item = _item;
                  ItemLView = _item;
                  if (TMovimiento == TipoMovimientoCtaCte.Ingresos)
                  {
                     if (Item.Instance == InstanceEntity.Added && ImprimirRecIngresos())
                     {
                        if (ShowMessage)
                        { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeSatisfactorio(Title, "Se ha guardado/Impreso satisfactoriamente"); }
                     }
                     else
                     {
                        if (ShowMessage)
                        { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeSatisfactorio(Title, "Se ha guardado satisfactoriamente"); }
                     }
                  }
                  else
                  {
                     if (ShowMessage)
                     { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeSatisfactorio(Title, "Se ha guardado satisfactoriamente"); }
                  }
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
            return false;
         }
         catch (Exception ex)
         {
            Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Title, Infrastructure.Aspect.Constants.Mensajes.SavePresenter, ex);
            return false;
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
         catch (Exception)
         { throw; }
      }

      /// <summary>
      /// Este metodo se utiliza para aquelos registros que son cheques diferidos puedan hacer el pago efectivo
      /// </summary>
      /// <returns></returns>
      public bool EjecutarDiferido(CuentasBancarias x_ItemCuentasBancarias)
      {
         try
         {
            System.Windows.Forms.DialogResult _result = Infrastructure.WinForms.Controls.Dialogos.MostrarMensajePregunta(Title, "¿Desea hacer efectivo el cheque diferido?", Infrastructure.WinForms.Controls.Dialogos.LabelBoton.Si_No);
            if (_result == System.Windows.Forms.DialogResult.Yes)
            {
               EViewDiferido = new CAJ002IngresosEgresosDViewEDiferido();
               EViewDiferido.StartPosition = FormStartPosition.CenterScreen;
               EViewDiferido.FormBorderStyle = FormBorderStyle.FixedSingle;
               EViewDiferido.Presenter = this;
               EViewDiferido.ItemMovimiento = Item;
               EViewDiferido.ItemCuentasBancaria = x_ItemCuentasBancarias;
               EViewDiferido.LoadView();
               if (EViewDiferido.ShowDialog() == DialogResult.OK)
               {
                  MView.GetItem();
                  Item.MOVI_FecEjecutado = EViewDiferido.MOVI_FecEjecutado;
                  Item.CUBA_Codigo = EViewDiferido.CUBA_Codigo;
                  Item.MOVI_NroOperacion = EViewDiferido.MOVI_NroOperacion;
                  Item.TIPO_CodMOV = EViewDiferido.TIPO_CodMOV_Dif;

                  Entities.Movimiento _item = Item;
                  /* 
                   * Ejecutar el movimiento diferido
                   */
                  if (Client.SaveMovimiento(ref _item, Movimiento.TInterfazMovimiento.EjecutarDiferido))
                  {
                     Item = _item;
                     Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeSatisfactorio(Title, String.Format("Se ha ejecutado satisfactoriamente, con fecha {0:dd/MM/yyyy}", Item.MOVI_FecEjecutado));
                     return true;
                  }
                  else
                  {
                     Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Title, "Ha ocurrido un error al ejecutar el item.");
                     return false;
                  }
               }
            }
            return false;
         }
         catch (Exception)
         { throw; }
      }

      /// <summary>
      /// Este proceso permite cambiar la fecha de diferido, ingresando une nueva fecha
      /// </summary>
      /// <returns></returns>
      public bool Rediferir()
      {
         try
         {
            System.Windows.Forms.DialogResult _result = Infrastructure.WinForms.Controls.Dialogos.MostrarMensajePregunta(Title, "¿Desea cambiar la fecha de diferido?", Infrastructure.WinForms.Controls.Dialogos.LabelBoton.Si_No);
            if (_result == System.Windows.Forms.DialogResult.Yes)
            {
               /* Levanta una interfaz donde se solicta la nueva fecha del documento diferido */
               CAJ002IngresosEgresosFView FView = new CAJ002IngresosEgresosFView() { StartPosition = FormStartPosition.CenterScreen };
               FView.LoadView(Item.MOVI_FecDiferido.Value);
               if (FView.ShowDialog() == DialogResult.OK)
               {
                  MView.GetItem();
                  Item.MOVI_FecDiferido = FView.FechaDiferido;

                  Entities.Movimiento _item = Item;
                  /* 
                   * Rediferir Movimiento
                   */
                  if (Client.SaveMovimiento(ref _item, Movimiento.TInterfazMovimiento.RediferirMovimiento))
                  {
                     Item = _item;
                     Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeSatisfactorio(Title, String.Format("Se realizo el cambio de fecha del movimiento Diferido, a la fecha {0:dd/MM/yyyy}", Item.MOVI_FecDiferido));
                     return true;
                  }
                  else
                  {
                     Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Title, "Ha ocurrido un error rediferir el item.");
                     return false;
                  }
               }
            }
            return false;
         }
         catch (Exception)
         { throw; }
      }

      public Boolean Aceptar()
      {
         try
         {
            MView.GetItem();
            Item.TieneDescuadre = false;
            if (Item.Validar())
            {
               Item.TIPO_CodMND = Item.ItemCuentasBancarias.TIPO_CodMND;
               return true;
            }
            else
            {
               MView.ShowValidation();
               return false;
            }
            return false;
         }
         catch (Exception)
         { throw; }
      }

      public System.Windows.Forms.DialogResult GuardarCambios()
      {
         try
         {
            if (this.Item != null)
            {

               ((CAJ002IngresosEgresosMView)MView).BringToFront();
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
      /// Validar el cierre de todas las instancias abiertas
      /// </summary>
      /// <returns></returns>
      public Boolean CloseView()
      {
         try
         {
            if (ListMView != null && ListMView.Count > 0)
            {
               if (
                  Infrastructure.WinForms.Controls.Dialogos.MostrarMensajePregunta(Title,
                     "Se ha detectado que existen ventanas abiertas, ¿Desea cerrar todas las ventanas abiertas por este modulo?",
                     Infrastructure.WinForms.Controls.Dialogos.LabelBoton.Si_No) ==
                  System.Windows.Forms.DialogResult.Yes)
               {
                  foreach (var Item in ListMView)
                  {
                     (Item as CAJ002IngresosEgresosMView).CloseMView();
                  }
                  ListMView = new ObservableCollection<ICAJ002IngresosEgresosMView>();
                  return true;
               }
            }
            else
            { return true; }
            return false;
         }
         catch (Exception)
         { throw; }
      }

      /// <summary>
      /// Eliminar la instancia del listado que maneja el presenter principal
      /// </summary>
      /// <param name="xMView"></param>
      public void CloseMView(CAJ002IngresosEgresosMView xMView)
      {
         try
         {
            if (xMView != null && ListMView != null && ListMView.Count > 0)
            {
               ListMView.Remove(xMView);
            }
         }
         catch (Exception)
         { throw; }
      }

      public void IsClosedMView()
      { isMViewShow = false; }

      /// <summary>
      /// Obtener el codigo de movimiento, segun el tipo de movimiento
      /// </summary>
      /// <param name="x_opcion"></param>
      /// <returns></returns>
      public String getTipoMovimiento(Infrastructure.Aspect.Constants.TipoMovimientoCtaCte x_opcion)
      {
         try
         {
            return String.Format("{0:000}", (int)x_opcion);
         }
         catch (Exception)
         { }
         return "";
      }

      #region [ Documentos ]

      /// <summary>
      /// Crear un nuevo documento para el detalle
      /// </summary>
      /// <param name="x_CuentasBancarias">Objeto de cuenta bancaria</param>
      /// <param name="x_Entidad">Objeto entidad</param>
      /// <param name="x_TIPO_CodMND">Tipo de Moneda</param>
      /// <param name="x_TipoCambio">Tipo de Cambio</param>
      /// <returns></returns>
      public Boolean NuevoDocumento(Entities.CuentasBancarias x_CuentasBancarias, Entities.Entidad x_Entidad, String x_TIPO_CodMND, Decimal x_TipoCambio)
      {
         try
         {
            DView = new CAJ002IngresosEgresosDView(TMovimiento);
            DView.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            DView.Presenter = this;
            DView.Entidad = x_Entidad;
            DView.CuentasBancarias = x_CuentasBancarias;
            DView.TipoInicio = CAJ002IngresosEgresosDView.TInicio.Nuevo;
            DView.LoadView();
            if (DView.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
               #region [ Recalcular el Importe sugerido, segun La moneda de la cuenta y la moneda de la deuda ]
               foreach (DetCtaCte item in DView.Items.Where(DCCT => DCCT.Seleccionar))
               {
                  if (item.DCCT_TipoCambio == 0) { item.DCCT_TipoCambio = TipoCambio; }
                  item.Instance = InstanceEntity.Added;
                  if (x_TIPO_CodMND.Equals(Infrastructure.Aspect.Constants.Util.getMoneda(TMoneda.Soles)))
                  {
                     if (item.TIPO_CodMND.Equals(x_TIPO_CodMND))
                     {
                        item.CCCT_Pendiente = item.CCCT_Pendiente;
                     }
                     else if (item.TIPO_CodMND.Equals(Infrastructure.Aspect.Constants.Util.getMoneda(TMoneda.Dolares)))
                     {
                        if (item.DCCT_PagoDetraccion.HasValue && item.DCCT_PagoDetraccion.Value && x_TIPO_CodMND.Equals("001"))
                        { item.CCCT_Pendiente = item.CCCT_MontoDetraccion; }
                        else
                        { item.CCCT_Pendiente = Math.Round(item.CCCT_Pendiente.Value * item.DCCT_TipoCambio, 2, MidpointRounding.AwayFromZero); }
                     }
                  }
                  else if (x_TIPO_CodMND.Equals(Infrastructure.Aspect.Constants.Util.getMoneda(TMoneda.Dolares)))
                  {
                     if (item.TIPO_CodMND.Equals(x_TIPO_CodMND))
                     {
                        item.CCCT_Pendiente = item.CCCT_Pendiente;
                     }
                     else if (item.TIPO_CodMND.Equals(Infrastructure.Aspect.Constants.Util.getMoneda(TMoneda.Soles)))
                     {
                        item.CCCT_Pendiente = Math.Round(item.CCCT_Pendiente.Value / x_TipoCambio, MidpointRounding.AwayFromZero);
                     }
                  }
                  if (x_CuentasBancarias.TIPO_CodMND.Equals(Infrastructure.Aspect.Constants.Util.getMoneda(TMoneda.Soles)))
                  {
                     if (item.TIPO_CodMND_Real.Equals(Infrastructure.Aspect.Constants.Util.getMoneda(TMoneda.Soles)))
                     {
                        item.CCCT_Monto_Real = Math.Round((item.CCCT_Pendiente.HasValue ? item.CCCT_Pendiente.Value : 0), 2, MidpointRounding.AwayFromZero);
                        item.CCCT_Saldo = Math.Round((item.CCCT_Pendiente_Real.HasValue ? item.CCCT_Pendiente_Real.Value : 0), 2, MidpointRounding.AwayFromZero) - item.CCCT_Monto_Real;
                     }
                     else if (item.TIPO_CodMND_Real.Equals(Infrastructure.Aspect.Constants.Util.getMoneda(TMoneda.Dolares)))
                     {
                        item.CCCT_Monto_Real = Math.Round(((item.CCCT_Pendiente.HasValue ? item.CCCT_Pendiente.Value : 0) / item.DCCT_TipoCambio), 2, MidpointRounding.AwayFromZero);
                        item.CCCT_Saldo = Math.Round((item.CCCT_Pendiente_Real.HasValue ? item.CCCT_Pendiente_Real.Value : 0), 2, MidpointRounding.AwayFromZero) - item.CCCT_Monto_Real;
                     }
                  }
                  else if (x_CuentasBancarias.TIPO_CodMND.Equals(Infrastructure.Aspect.Constants.Util.getMoneda(TMoneda.Dolares)))
                  {
                     if (item.TIPO_CodMND_Real.Equals(Infrastructure.Aspect.Constants.Util.getMoneda(TMoneda.Dolares)))
                     {
                        item.CCCT_Monto_Real = Math.Round((item.CCCT_Pendiente.HasValue ? item.CCCT_Pendiente.Value : 0), 2, MidpointRounding.AwayFromZero);
                        item.CCCT_Saldo = Math.Round((item.CCCT_Pendiente_Real.HasValue ? item.CCCT_Pendiente_Real.Value : 0), 2, MidpointRounding.AwayFromZero) - item.CCCT_Monto_Real;
                     }
                     else if (item.TIPO_CodMND_Real.Equals(Infrastructure.Aspect.Constants.Util.getMoneda(TMoneda.Soles)))
                     {
                        item.CCCT_Monto_Real = Math.Round(((item.CCCT_Pendiente.HasValue ? item.CCCT_Pendiente.Value : 0) * item.DCCT_TipoCambio), 2, MidpointRounding.AwayFromZero);
                        item.CCCT_Saldo = Math.Round((item.CCCT_Pendiente_Real.HasValue ? item.CCCT_Pendiente_Real.Value : 0), 2, MidpointRounding.AwayFromZero) - item.CCCT_Monto_Real;
                     }
                  }
               }
               #endregion

               Item.ListDetCtaCte = Item.ListDetCtaCte.Concat(DView.Items.Where(Sel => Sel.Seleccionar).ToObservableCollection()).ToObservableCollection();

               return true;
            }
            return false;
         }
         catch (Exception)
         { throw; }
      }

      /// <summary>
      /// Eliminar documentos de la interfaz
      /// </summary>
      /// <param name="_detctacte"></param>
      /// <returns></returns>
      public Boolean EliminarDocumento(Entities.DetCtaCte _detctacte)
      {
         try
         {
            if (Infrastructure.WinForms.Controls.Dialogos.MostrarMensajePregunta(Title, "¿Desea eliminar el registro seleccionado?", Infrastructure.WinForms.Controls.Dialogos.LabelBoton.Si_No) == System.Windows.Forms.DialogResult.Yes)
            {
               if (Item.ListDetCtaCteEliminados == null) { Item.ListDetCtaCteEliminados = new ObservableCollection<DetCtaCte>(); }
               Item.ListDetCtaCteEliminados.Add(_detctacte);
               Item.ListDetCtaCte.Remove(_detctacte);
               return true;
            }
            return false;
         }
         catch (Exception)
         { throw; }
      }

      /// <summary>
      /// Abrir registro de cuenta corriente
      /// </summary>
      /// <param name="_detctacte"></param>
      public void AbriCtaCte(Entities.DetCtaCte _detctacte)
      {
         try
         {
            CAJ012IngresoLibrePresenter CAJ012_presenter;
            CAJ012_presenter = new CAJ012IngresoLibrePresenter(ContainerService, CAJ012IngresoLibrePresenter.TipoInicio.MostraCtaCte);
            CAJ012_presenter.Load();
            CAJ012_presenter.ItemLView = new CtaCte();
            CAJ012_presenter.ItemLView.ListDetCtaCteAsientos = new ObservableCollection<DetCtaCteAsientos>();
            CAJ012_presenter.ItemLView.EMPR_Codigo = _detctacte.EMPR_Codigo;
            CAJ012_presenter.ItemLView.CCCT_Codigo = _detctacte.CCCT_Codigo;
            CAJ012_presenter.Editar();
         }
         catch (Exception)
         { throw; }
      }

      #endregion

      #region [ Flujos ]

      public Boolean AgregarFlujo()
      {
         try
         {
            MView.SetItemFlujo();

            return true;
         }
         catch (Exception)
         { throw; }
      }
      public Boolean NuevoMovimientoFlujo(int x_item)
      {
         try
         {
            Entities.MovimientoFlujo _movimientoFlujo = new Entities.MovimientoFlujo();

            _movimientoFlujo.MFLU_Item = Convert.ToInt16(++x_item);
            _movimientoFlujo.EMPR_Codigo = Controls.Entorno.ItemEmpresa.EMPR_Codigo;
            _movimientoFlujo.AUDI_UsrCrea = Session.UserName;
            _movimientoFlujo.AUDI_FecCrea = Session.Fecha;

            _movimientoFlujo.MOVI_Codigo = Item.MOVI_Codigo;
            _movimientoFlujo.Instance = InstanceEntity.Added;

            CAJ002IngresosEgresosFlujoDView FView = new CAJ002IngresosEgresosFlujoDView();
            FView.Presenter = this;
            FView.LoadView(CAJ002IngresosEgresosFlujoDView.TInicio.Nuevo);
            FView.ItemMovimientoFlujo = _movimientoFlujo;
            FView.StartPosition = FormStartPosition.CenterScreen;
            if (FView.ShowDialog() == DialogResult.OK)
            {
               Item.ListFlujos.Add(FView.ItemMovimientoFlujo);
               return true;
            }
            return false;


         }
         catch (Exception)
         { throw; }
      }
      public Boolean EditarMovimientoFlujo(ref Entities.MovimientoFlujo _movimientoFlujo)
      {
         try
         {
            //Entities.Chequera _chequera = new Entities.Chequera();
            //_chequera.CHEQ_Codigo = ++x_item;
            _movimientoFlujo.EMPR_Codigo = Controls.Entorno.ItemEmpresa.EMPR_Codigo;
            _movimientoFlujo.AUDI_UsrMod = Session.UserName;
            _movimientoFlujo.AUDI_FecMod = Session.Fecha;

            CAJ002IngresosEgresosFlujoDView FView = new CAJ002IngresosEgresosFlujoDView();
            FView.ItemMovimientoFlujo = _movimientoFlujo;
            FView.Presenter = this;
            FView.LoadView(CAJ002IngresosEgresosFlujoDView.TInicio.Nuevo);

            FView.StartPosition = FormStartPosition.CenterScreen;
            if (FView.ShowDialog() == DialogResult.OK)
            {
               //Item.ListChequera.Add(CView.Item);
               return true;
            }
            return false;
         }
         catch (Exception)
         { throw; }
      }

      #endregion

      #region [ Tipificaciones ]

      public Boolean NuevaTipificacion(Int32 x_item, Int16 x_TIPE_Codigo, Int32 x_ENTC_Codigo, String x_TIPO_CodMND, Decimal x_TipoCambio)
      {
         try
         {
            Entities.Tipificaciones _tipificacion = new Entities.Tipificaciones();

            _tipificacion.TIPD_Item = Convert.ToInt16(++x_item);
            _tipificacion.EMPR_Codigo = Controls.Entorno.ItemEmpresa.EMPR_Codigo;
            _tipificacion.AUDI_UsrCrea = Session.UserName;
            _tipificacion.AUDI_FecCrea = Session.Fecha;

            _tipificacion.MOVI_Codigo = Item.MOVI_Codigo;
            _tipificacion.TIPE_Codigo = x_TIPE_Codigo;
            _tipificacion.ENTC_Codigo = x_ENTC_Codigo;
            _tipificacion.TIPD_TipoCambio = x_TipoCambio;
            _tipificacion.TIPO_CodMND = x_TIPO_CodMND;
            _tipificacion.Instance = InstanceEntity.Added;

            CAJ002IngresosEgresosDViewDescuadres DView = new CAJ002IngresosEgresosDViewDescuadres();
            DView.Presenter = this;
            DView.ItemTipificacion = _tipificacion;
            DView.FormBorderStyle = FormBorderStyle.FixedDialog;
            DView.LoadView(CAJ002IngresosEgresosDViewDescuadres.TipoInicio.Nuevo);

            DView.StartPosition = FormStartPosition.CenterScreen;
            if (DView.ShowDialog() == DialogResult.OK)
            {
               Item.ListTipificaciones.Add(DView.ItemTipificacion);
               return true;
            }
            return false;
         }
         catch (Exception)
         { throw; }
      }

      public Boolean EditarTipificacion(ref Tipificaciones x_tipificacion)
      {
         try
         {
            //Entities.Chequera _chequera = new Entities.Chequera();
            //_chequera.CHEQ_Codigo = ++x_item;
            x_tipificacion.EMPR_Codigo = Controls.Entorno.ItemEmpresa.EMPR_Codigo;
            x_tipificacion.AUDI_UsrMod = Session.UserName;
            x_tipificacion.AUDI_FecMod = Session.Fecha;

            CAJ002IngresosEgresosDViewDescuadres DView = new CAJ002IngresosEgresosDViewDescuadres();
            DView.ItemTipificacion = x_tipificacion;
            DView.Presenter = this;
            DView.LoadView(CAJ002IngresosEgresosDViewDescuadres.TipoInicio.Editar);

            DView.StartPosition = FormStartPosition.CenterScreen;
            if (DView.ShowDialog() == DialogResult.OK)
            { return true; }
            return false;
         }
         catch (Exception)
         { throw; }
      }

      public Boolean EliminarTipificacion()
      {
         try
         {

            return false;
         }
         catch (Exception)
         { throw; }
      }

      #endregion

      public Boolean AyudaCentroCto(String x_CENT_Ano, ref String x_CENT_Codigo, ref String x_CENT_Desc)
      {
         try
         {
            ObservableCollection<Infrastructure.Aspect.DataAccess.DataAccessFilterSQL> _listFilters = new ObservableCollection<Infrastructure.Aspect.DataAccess.DataAccessFilterSQL>();
            _listFilters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@CENT_Ano", FilterValue = x_CENT_Ano, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.Char, FilterSize = 4 });
            _listFilters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@CENT_Codigo", FilterValue = x_CENT_Codigo, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.Varchar, FilterSize = 17 });
            _listFilters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@CENT_Desc", FilterValue = x_CENT_Desc, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.Varchar, FilterSize = 50 });

            System.Data.DataTable dtAyuda = new System.Data.DataTable();
            dtAyuda = Client.GetDTChequera("CON_CENTSS_TodosAyuda", _listFilters);

            if (dtAyuda.Rows.Count == 0)
            { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Title, "No se encontraron coincidencias."); }
            else if (dtAyuda.Rows.Count == 1)
            {
               x_CENT_Ano = dtAyuda.Rows[0]["CENT_Ano"].ToString();
               x_CENT_Desc = dtAyuda.Rows[0]["CENT_Desc"].ToString();
               x_CENT_Codigo = dtAyuda.Rows[0]["CENT_Codigo"].ToString();
               return true;
            }
            else
            {
               int i = 0;
               List<Infrastructure.WinForms.Controls.ColumnaAyuda> _columnas = new List<Infrastructure.WinForms.Controls.ColumnaAyuda>();
               _columnas.Add(new Infrastructure.WinForms.Controls.ColumnaAyuda()
               {
                  Index = i++,
                  ColumnName = "CENT_Ano",
                  ColumnCaption = "Año",
                  Alineacion = DataGridViewContentAlignment.MiddleCenter,
                  Width = 60,
                  DataType = typeof(System.String),
                  Format = null
               });
               _columnas.Add(new Infrastructure.WinForms.Controls.ColumnaAyuda()
               {
                  Index = i++,
                  ColumnName = "CENT_Codigo",
                  ColumnCaption = "Código",
                  Alineacion = DataGridViewContentAlignment.MiddleLeft,
                  Width = 100,
                  DataType = typeof(System.String),
                  Format = null
               });

               _columnas.Add(new Infrastructure.WinForms.Controls.ColumnaAyuda()
               {
                  Index = i++,
                  ColumnName = "CENT_Desc",
                  ColumnCaption = "Descripción",
                  Alineacion = DataGridViewContentAlignment.MiddleLeft,
                  Width = 250,
                  DataType = typeof(System.String),
                  Format = null
               });

               Infrastructure.WinForms.Controls.Ayuda x_Ayuda = new Infrastructure.WinForms.Controls.Ayuda("Ayuda - Centros de Costo", dtAyuda, false, _columnas);

               if (x_Ayuda.ShowDialog() == System.Windows.Forms.DialogResult.OK)
               {
                  x_CENT_Ano = x_Ayuda.Respuesta.Rows[0]["CENT_Ano"].ToString();
                  x_CENT_Codigo = x_Ayuda.Respuesta.Rows[0]["CENT_Codigo"].ToString();
                  x_CENT_Desc = x_Ayuda.Respuesta.Rows[0]["CENT_Desc"].ToString();
                  return true;
               }
               else { throw new Exception("Error en el dialogo de Ayuda de Horarios Disponibles"); }
            }
         }
         catch (Exception)
         { throw; }
         return false;
      }

      #endregion

      #region Clone

      /// <summary>
      /// Metodo para clonar la instancia Presenter para cada MView
      /// </summary>
      /// <returns></returns>
      public object Clone()
      {
         // Obtenemos una copia superficial de la clase
         CAJ002IngresosEgresosPresenter nuevo = (CAJ002IngresosEgresosPresenter)this.MemberwiseClone();
         return nuevo;
      }


      #endregion
   }
}