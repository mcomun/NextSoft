using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
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
using System.Windows.Forms;

namespace Delfin.Principal
{
   public partial class CAJ012IngresoLibrePresenter
   {
      #region [ Variables ]
      public String Title = "Ingreso Libre de Documentos";
      public String CUS = "CAJ012";
      public Boolean FleteNegativo = false;

      public enum TipoInicio
      {
         Normal = 0, MostraCtaCte = 1
      }

      #endregion

      #region [ Constructor ]
      public CAJ012IngresoLibrePresenter(IUnityContainer x_container, ICAJ012IngresoLibreLView x_lview)
      {
         try
         {
            TInicio = TipoInicio.Normal;
            this.ContainerService = x_container;
            Session = this.ContainerService.Resolve<ISessionService>();
            this.LView = x_lview;
         }
         catch (Exception)
         { throw; }
      }

      /// <summary>
      /// Cargar un registro de cuenta corriente
      /// </summary>
      /// <param name="x_container"></param>
      public CAJ012IngresoLibrePresenter(IUnityContainer x_container, TipoInicio x_opcion)
      {
         try
         {
            TInicio = x_opcion;
            this.ContainerService = x_container;
            Session = this.ContainerService.Resolve<ISessionService>();
         }
         catch (Exception)
         { throw; }
      }

      public void Load()
      {
         try
         {
            Client = ContainerService.Resolve<IDelfinServices>();

            /*
             * Cargar parametros
             */
            Entities.Parametros _parametros;
            ETipoCambio = TCambio.Ventas;
            ListParametros = Client.GetAllParametros();
            /*
             * Cargar el parametro de Tipo de cambio a usar por la CtaCte
             */
            _parametros = ListParametros.Where(Para => Para.PARA_Clave.Equals("TCCTACTE_PRO")).FirstOrDefault();
            if (_parametros != null && _parametros.PARA_Valor != null)
            { ETipoCambio = _parametros.PARA_Valor.Equals("VEN") ? TCambio.Ventas : TCambio.Compras; }

            _parametros = ListParametros.Where(Para => Para.PARA_Clave.Equals("CUENTA_COM")).FirstOrDefault();
            if (_parametros != null)
            {
               String[] x_cta = _parametros.PARA_Valor.Split('|');
               P_Cuenta_Sol = x_cta[0];
               P_Cuenta_Dol = (x_cta.Count() > 1 ? x_cta[1] : "");
            }
            _parametros = ListParametros.Where(Para => Para.PARA_Clave.Equals("CUENTA_IGV")).FirstOrDefault();
            if (_parametros != null)
            { P_Cuenta_IGV = _parametros.PARA_Valor; }

            _parametros = ListParametros.Where(Para => Para.PARA_Clave.Equals("ILD_TIPOSTDO")).FirstOrDefault();
            if (_parametros != null)
            { TIPO_CodTDO_Disponibles = _parametros.PARA_Valor.Split('|'); }

            _parametros = ListParametros.Where(Para => Para.PARA_Clave.Equals("TR_RCOMPRAS")).FirstOrDefault();
            if (_parametros != null)
            { TR_RCOMPRAS = _parametros.PARA_Valor; }

            _parametros = ListParametros.Where(Para => Para.PARA_Clave.Equals("TR_DGENERAL")).FirstOrDefault();
            if (_parametros != null)
            { TR_DGENERAL = _parametros.PARA_Valor; }

            DET_REDONDEONORMAL = false;
            _parametros = ListParametros.Where(Para => Para.PARA_Clave.Equals("DET_REDONDEONORMAL")).FirstOrDefault();
            if (_parametros != null)
            {
               Boolean _rpt = true;
               if (!String.IsNullOrEmpty(_parametros.PARA_Valor) && _parametros.PARA_Valor.Equals("1"))
               { DET_REDONDEONORMAL = _rpt; }
            }

            _parametros = ListParametros.Where(Para => Para.PARA_Clave.Equals("GAS_DOc_PENDIENTE")).FirstOrDefault();
            if (_parametros != null)
            { CCCT_Numero_Pendiente = _parametros.PARA_Valor; }

            switch (TInicio)
            {
               case TipoInicio.Normal:
                  LView.LoadView();
                  break;
               case TipoInicio.MostraCtaCte:
                  break;
            }

            Fecha = Client.GetFecha();

            TipoCambio = GetTipoCambio(Fecha);

            /*
             * Obtener el valor del IGV
             */
            _parametros = ListParametros.Where(Para => Para.PARA_Clave.Equals("IGV")).FirstOrDefault();
            if (_parametros != null && _parametros.PARA_Valor != null)
            {
               Decimal _igv = 0;
               if (Decimal.TryParse(_parametros.PARA_Valor, out _igv))
               { IGV = _igv; }
            }
            /* Obtener Plantillas */
            ListPlantillasAsientos = Client.GetAllCabPerfilAsientos();
            ListPlantillasAsientos.Insert(0, new CabPerfilAsientos() { CABP_Codigo = null, CABP_Ano = null, CABP_Desc = "< Sel. Plantilla Asiento >" });

            ObservableCollection<Infrastructure.Aspect.DataAccess.DataAccessFilterSQL> _listFilters = new ObservableCollection<Infrastructure.Aspect.DataAccess.DataAccessFilterSQL>();
            _listFilters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@TIPO_CodTabla", FilterValue = "OPE", FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.Char, FilterSize = 3 });
            _listFilters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@TIPO_ano", FilterValue = Fecha.Year.ToString(), FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.Char, FilterSize = 4 });
            _listFilters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@Tipo", FilterValue = "C", FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.Char, FilterSize = 1 });

            DSTiposOPE = Client.GetDSDocsVta("CON_TABLSS_TodosPorTipo", _listFilters);

         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Title, "Ha ocurrido un error inicializando la vista.", ex); }
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
      #endregion

      #region [ Propiedades ]
      public IUnityContainer ContainerService { get; set; }
      public ISessionService Session { get; set; }
      public IDelfinServices Client { get; set; }

      public ICAJ012IngresoLibreLView LView { get; set; }
      public ICAJ012IngresoLibreMView MView { get; set; }

      public TipoInicio TInicio { get; set; }

      public CtaCte Item { get; set; }
      public CtaCte ItemLView { get; set; }
      public ObservableCollection<CtaCte> Items { get; set; }

      public String MensajeError { get; set; }
      public Decimal TipoCambio { get; set; }
      public Decimal IGV { get; set; }

      public String P_Cuenta_Sol { get; set; }
      public String P_Cuenta_Dol { get; set; }
      public String P_Cuenta_IGV { get; set; }

      public ObservableCollection<Entities.Parametros> ListParametros { get; set; }
      public ObservableCollection<Entities.CabPerfilAsientos> ListPlantillasAsientos { get; set; }
      public System.Data.DataSet DSTiposOPE { get; set; }

      public Int32? F_CCCT_Codigo { get; set; }
      public Int16? F_TIPE_Codigo { get; set; }
      public Int32? F_ENTC_Codigo { get; set; }
      public String F_TIPO_CodTDO { get; set; }
      public String F_CCCT_Serie { get; set; }
      public String F_CCCT_Numero { get; set; }

      public DateTime? F_CCCT_Fecha_Ini { get; set; }
      public DateTime? F_CCCT_Fecha_Fin { get; set; }

      public String F_HBL { get; set; }
      public String F_MBL { get; set; }
      public String F_OV { get; set; }
      public Int32? F_NVIA_Codigo { get; set; }

      public String F_AsientoInicial { get; set; }
      public String F_AsientoCompras { get; set; }

      private Boolean isMViewShowed = false;
      public DateTime Fecha { get; set; }
      public String[] TIPO_CodTDO_Disponibles { get; set; }

      public String TR_RCOMPRAS { get; set; }
      public String TR_DGENERAL { get; set; }
      public Boolean DET_REDONDEONORMAL { get; set; }
      public TCambio ETipoCambio { get; set; }

      public String CCCT_Numero_Pendiente { get; set; }
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
               listFilters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@pintCCCT_Codigo", FilterValue = F_CCCT_Codigo, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.Int32, FilterSize = 4 });
               listFilters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@psinTIPE_Codigo", FilterValue = F_TIPE_Codigo, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.Int32, FilterSize = 4 });
               listFilters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@pintENTC_Codigo", FilterValue = F_ENTC_Codigo, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.Int32, FilterSize = 4 });
               listFilters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@pchrTIPO_CodTDO", FilterValue = F_TIPO_CodTDO, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.Varchar, FilterSize = 3 });
               listFilters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@pvchCCCT_Serie", FilterValue = F_CCCT_Serie, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.Varchar, FilterSize = 20 });
               listFilters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@pvchCCCT_Numero", FilterValue = F_CCCT_Numero, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.Varchar, FilterSize = 20 });
               listFilters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@FecIni", FilterValue = F_CCCT_Fecha_Ini, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.DateTime, FilterSize = 8 });
               listFilters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@FecFin", FilterValue = F_CCCT_Fecha_Fin, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.DateTime, FilterSize = 8 });

               listFilters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@OV", FilterValue = F_OV, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.Varchar, FilterSize = 20 });
               listFilters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@HBL", FilterValue = F_HBL, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.Varchar, FilterSize = 50 });
               listFilters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@MBL", FilterValue = F_MBL, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.Varchar, FilterSize = 50 });
               listFilters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@NVIA_Codigo", FilterValue = F_NVIA_Codigo, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.Int32, FilterSize = 4 });

               listFilters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@AsientoInicial", FilterValue = F_AsientoInicial, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.Varchar, FilterSize = 20 });
               listFilters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@AsientoCompras", FilterValue = F_AsientoCompras, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.Varchar, FilterSize = 20 });

               Items = Client.GetAllCtaCteFilter("CAJ_CCCTSS_TodosIngresoLibre", listFilters);

               LView.ShowItems();
            }
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Title, "Ha ocurrido un error actualizando.", ex); }
      }

      /// <summary>
      /// Crear nuevo documento, se realizan operaciones anexas cuando es un documento nuevo, creado desde este modulo
      /// </summary>
      /// <param name="x_show"></param>
      public void Nuevo(Boolean x_show = true)
      {
         try
         {
            if (!isMViewShowed || !x_show)
            {
               if (TipoCambio == 0) { TipoCambio = GetTipoCambio(Fecha); }

               if (!isMViewShowed)
               {
                  MView = new CAJ012IngresoLibreMView();
                  MView.Presenter = this;
                  MView.LoadView();
               }

               MView.ClearItem();
               this.Item = new CtaCte();

               this.Item.EMPR_Codigo = Controls.Entorno.ItemEmpresa.EMPR_Codigo;
               this.Item.SUCR_Codigo = Controls.Entorno.ItemSucursal.SUCR_Codigo;
               this.Item.CCCT_TipoCambio = TipoCambio;
               this.Item.AUDI_UsrCrea = Session.UserName;
               this.Item.AUDI_FecCrea = Session.Fecha;
               this.Item.CCCT_FechaRecepcion = Fecha;
               this.Item.CCCT_CuentaIGV = P_Cuenta_IGV;
               this.Item.CCCT_FecReg = Fecha;
               this.Item.ListDetCtaCteAsientos = new ObservableCollection<DetCtaCteAsientos>();
               this.Item.Instance = Infrastructure.Aspect.BusinessEntity.InstanceEntity.Added;
               this.Item.TMovimiento = CtaCte.TipoMovimiento.Egreso;

               MView.SetItem();

               if (!isMViewShowed)
               {
                  isMViewShowed = true;
                  if (LView != null) { ((CAJ012IngresoLibreMView)MView).Icon = System.Drawing.Icon.FromHandle(((System.Drawing.Bitmap)LView.IconView).GetHicon()); }
                  ((CAJ012IngresoLibreMView)MView).Show();
                  ((CAJ012IngresoLibreMView)MView).BringToFront();
               }
            }
            else
            {
               Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Title, "La ventana de edición ya se encuentra activa.");
               ((CAJ012IngresoLibreMView)MView).BringToFront();
            }

         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Title, Infrastructure.Aspect.Constants.Mensajes.NewPresenter, ex); }
      }

      /// <summary>
      /// Permite modificar todos los datos mostrados en pantalla
      /// </summary>
      /// <param name="x_show"></param>
      public void Editar(Boolean x_show = true)
      {
         try
         {
            if (!isMViewShowed || !x_show)
            {
               if (!isMViewShowed)
               {
                  MView = new CAJ012IngresoLibreMView();
                  MView.Presenter = this;
                  MView.LoadView();
               }

               Item = Client.GetOneCtaCte(ItemLView.EMPR_Codigo, ItemLView.CCCT_Codigo, CtaCte.TInterfazCtaCte.IngresoLibre);

               if (Item != null)
               {
                  MView.ClearItem();
                  this.Item.AUDI_UsrMod = Session.UserName;
                  this.Item.AUDI_FecMod = Session.Fecha;
                  this.Item.Instance = Infrastructure.Aspect.BusinessEntity.InstanceEntity.Modified;
                  this.Item.TMovimiento = this.Item.TipoCtaCte.Equals("I") ? CtaCte.TipoMovimiento.Ingreso : CtaCte.TipoMovimiento.Egreso;
                  if (String.IsNullOrEmpty(this.Item.CCCT_CuentaIGV)) { this.Item.CCCT_CuentaIGV = P_Cuenta_IGV; }
                  //GenerarAsiento();
                  MView.SetItem();

                  if (!string.IsNullOrEmpty(this.Item.CCCT_Estado) && this.Item.CCCT_Estado.Equals("X")) { TInicio = TipoInicio.MostraCtaCte; }

                  isMViewShowed = true;
                  switch (TInicio)
                  {
                     case TipoInicio.Normal:
                        if (LView != null) { ((CAJ012IngresoLibreMView)MView).Icon = System.Drawing.Icon.FromHandle(((System.Drawing.Bitmap)LView.IconView).GetHicon()); }
                        ((CAJ012IngresoLibreMView)MView).Show();
                        ((CAJ012IngresoLibreMView)MView).BringToFront();
                        break;
                     case TipoInicio.MostraCtaCte:
                        if (LView != null) { ((CAJ012IngresoLibreMView)MView).Icon = System.Drawing.Icon.FromHandle(((System.Drawing.Bitmap)LView.IconView).GetHicon()); }
                        ((CAJ012IngresoLibreMView)MView).ShowDialog();
                        break;
                  }
               }
               else
               {
                  Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Title,
                     "Debe seleccionar un elemento de la grilla");
               }
            }
            else
            {
               Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Title, "La ventana de edición ya se encuentra activa.");
               ((CAJ012IngresoLibreMView)MView).BringToFront();
            }
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Title, Infrastructure.Aspect.Constants.Mensajes.EditPresenter, ex); }
      }

      /// <summary>
      /// Eliminar un documento, solo se completa la operacion si se ha creado desde este modulo, ya que 
      /// no se podra eliminar el registro si se creo desde otro modulo por los enlaces relacionados
      /// </summary>
      public void Eliminar()
      {
         try
         {
            if (ItemLView != null)
            {
               System.Windows.Forms.DialogResult _result =
                   Infrastructure.WinForms.Controls.Dialogos.MostrarMensajePregunta(Title,
                       Infrastructure.Aspect.Constants.Mensajes.PreguntaEliminar,
                       Infrastructure.WinForms.Controls.Dialogos.LabelBoton.Si_No);
               if (_result == System.Windows.Forms.DialogResult.Yes)
               {
                  ItemLView.Instance = Infrastructure.Aspect.BusinessEntity.InstanceEntity.Deleted;
                  Entities.CtaCte _item = ItemLView;
                  if (Client.SaveCtaCte(ref _item, CtaCte.TInterfazCtaCte.IngresoLibre))
                  {
                     ItemLView = _item;
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

      public void Anular()
      {
         try
         {
            if (ItemLView != null)
            {
               System.Windows.Forms.DialogResult _result =
                   Infrastructure.WinForms.Controls.Dialogos.MostrarMensajePregunta(Title,
                       Infrastructure.Aspect.Constants.Mensajes.PreguntaAnular,
                       Infrastructure.WinForms.Controls.Dialogos.LabelBoton.Si_No);
               if (_result == System.Windows.Forms.DialogResult.Yes)
               {
                  ItemLView.Instance = Infrastructure.Aspect.BusinessEntity.InstanceEntity.Modified;
                  ItemLView.AUDI_UsrAnulacion = Session.UserName;
                  ItemLView.CONS_CodANU = Constantes.GetTabAnulacion();
                  ItemLView.CONS_TabANU = Constantes.GetCodAnulacion(Constantes.TipoAnulacion.AnulacionIL);
                  Entities.CtaCte _item = ItemLView;
                  if (Client.SaveCtaCte(ref _item, CtaCte.TInterfazCtaCte.AnularCtaCte))
                  {
                     ItemLView = _item;

                     Actualizar();
                     Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeSatisfactorio(Title,
                         "Se ha anulo el item.");
                  }
                  else
                  {
                     Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Title,
                         "Ha ocurrido un error al anular el item.");
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

      private Boolean CtaCteRelacionados(String x_tipo)
      {
         try
         {
            ObservableCollection<Infrastructure.Aspect.DataAccess.DataAccessFilterSQL> _listFilters = new ObservableCollection<Infrastructure.Aspect.DataAccess.DataAccessFilterSQL>();
            _listFilters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@psinEMPR_Codigo", FilterValue = ItemLView.EMPR_Codigo, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.Int16, FilterSize = 2 });
            _listFilters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@pintCCCT_Codigo", FilterValue = ItemLView.CCCT_Codigo, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.Int32, FilterSize = 4 });
            _listFilters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@Asiento", FilterValue = x_tipo, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.Char, FilterSize = 1 });
            ObservableCollection<CtaCte> _listRelacionados = Client.GetAllCtaCteFilter("CAJ_CCCTSS_ConsultarAgrupados", _listFilters);

            return _listRelacionados.Count > 1;
         }
         catch (Exception)
         { throw; }
      }

      private Boolean Validación()
      {
         try
         {
            if (ItemLView.DOCV_Codigo.HasValue)
            {
               Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Title, String.Format("El registro seleccionado es un documento de Venta, no puede continuar con el proceso."));
               return false; ;
            }
            if (!String.IsNullOrEmpty(ItemLView.OrigenDocumento) && ItemLView.OrigenDocumento.Equals("M"))
            {
               Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Title, String.Format("El registro seleccionado es un documento de mandato, no puede continuar con el proceso."));
               return false;
            }
            return true;
         }
         catch (Exception)
         { throw; }
      }

      public Boolean DesvincularAsiento(CtaCte.TipoDesvinculacion x_opcion)
      {
         try
         {
            Boolean _IsCorrect = false;
            String _consulta = "", x_asiento = "", _opcion = "";

            if (!Validación()){ return _IsCorrect; }

            String _OrigenCompras = "";

            switch (x_opcion)
            {
               case CtaCte.TipoDesvinculacion.AsientoProvision:

                  if (String.IsNullOrEmpty(ItemLView.AsientoContable))
                  {
                     Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Title, String.Format("El registro seleccionado no tiene un asiento de Provisión que desvincular"));
                     return _IsCorrect;
                  }
                  if (!String.IsNullOrEmpty(ItemLView.AsientoContableC))
                  {
                     Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Title, String.Format("No puede desvincular un asiento que ya tiene una Reversión a Compras [{0}]", ItemLView.AsientoContableC));
                     return _IsCorrect;
                  }
                  x_asiento = ItemLView.AsientoContable;
                  _opcion = "P";
                  _OrigenCompras = ItemLView.CCCT_OrigenContable;
                  break;
               case CtaCte.TipoDesvinculacion.AsientoCompRev:
                  if (String.IsNullOrEmpty(ItemLView.AsientoContableC))
                  {
                     Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Title, String.Format("El registro seleccionado no tiene un asiento Compras/Reversion que desvincular"));
                     return _IsCorrect;
                  }
                  x_asiento = ItemLView.AsientoContableC;
                  _opcion = "C";
                  _OrigenCompras = (String.IsNullOrEmpty(ItemLView.CCCT_OrigenContableCompras) ? ItemLView.CCCT_OrigenContableCompras : ItemLView.CCCT_OrigenContable);
                  break;
               case CtaCte.TipoDesvinculacion.AsientoORevComp:
                  if (String.IsNullOrEmpty(ItemLView.AsientoContableO))
                  {
                     Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Title, String.Format("El registro seleccionado no tiene un asiento Reversion que desvincular"));
                     return _IsCorrect;
                  }
                  x_asiento = ItemLView.AsientoContableO;
                  _opcion = "R";
                  _OrigenCompras = null;
                  break;
               default:
                  break;
            }


            if (CtaCteRelacionados(_opcion))
            {
               _consulta = String.Format("El registro seleccionado, tiene mas de un documento relacionado, esta acción desvinvulara todos los documentos relacionados, ¿Desea Continuar?", x_asiento);
               if (Infrastructure.WinForms.Controls.Dialogos.MostrarMensajePregunta(Title, _consulta, Infrastructure.WinForms.Controls.Dialogos.LabelBoton.Si_No) == System.Windows.Forms.DialogResult.No)
               { return _IsCorrect; }
            }

            _consulta = String.Format("¿Desea desvincular el Asiento <{0}> del documento?, el proceso no se podra revertir", x_asiento);

            if (Infrastructure.WinForms.Controls.Dialogos.MostrarMensajePregunta(Title, _consulta, Infrastructure.WinForms.Controls.Dialogos.LabelBoton.Si_No) == System.Windows.Forms.DialogResult.Yes)
            {
               Delfin.Principal.Procesos.Finanzas.CAJ012IngresoLibreDView DView = new Procesos.Finanzas.CAJ012IngresoLibreDView(x_asiento);
               DView.WindowState = FormWindowState.Normal;
               DView.StartPosition = FormStartPosition.CenterScreen;
               DView.FormBorderStyle = FormBorderStyle.FixedDialog;
               DView.Text = "Desvincular Asiento:  " + x_asiento;
               if (DView.ShowDialog() == DialogResult.OK)
               {
                  _IsCorrect = Client.SaveCtaCteDesvinculacion(ItemLView.EMPR_Codigo, ItemLView.CCCT_Codigo, x_opcion, DView.TOpcion, Session.UserName);
               }
            }
            return _IsCorrect;
         }
         catch (Exception)
         { throw; }
      }

      public Boolean EnviarADiario()
      {
         try
         {
            Boolean _IsCorrect = false;

            if (!Validación()) { return _IsCorrect; }
            if (!String.IsNullOrEmpty(ItemLView.AsientoContable))
            {
               Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Title, String.Format("El registro seleccionado tiene un asiento de provisión, no puede continuar con el proceso."));
               return _IsCorrect;
            }

            Delfin.Principal.Procesos.Finanzas.CAJ012IngresoLibre.CAJ012IngresoLibreAView AView = new Procesos.Finanzas.CAJ012IngresoLibre.CAJ012IngresoLibreAView();
            AView.WindowState = FormWindowState.Normal;
            AView.StartPosition = FormStartPosition.CenterScreen;
            AView.FormBorderStyle = FormBorderStyle.FixedDialog;
            AView.Text = "Enviar asiento a Libro de Diario";

            AView.CCCT_Numero = CCCT_Numero_Pendiente;
            if (ItemLView.CCCT_FecReg.HasValue) { AView.CCCT_FecReg = ItemLView.CCCT_FecReg.Value; }
            if (ItemLView.CCCT_FechaEmision.HasValue) { AView.CCCT_FechaEmision = ItemLView.CCCT_FechaEmision.Value; }
            AView.CCCT_Codigo = ItemLView.CCCT_Codigo;
            AView.LoadView();

            if (AView.ShowDialog() == DialogResult.OK)
            {
               Entities.CtaCte _item = new CtaCte();
               _item.EMPR_Codigo = ItemLView.EMPR_Codigo;
               _item.CCCT_Codigo = ItemLView.CCCT_Codigo;
               _item.CCCT_FechaEmision = AView.CCCT_FechaEmision;
               _item.CCCT_FecReg = AView.CCCT_FecReg;
               _item.CCCT_Numero = CCCT_Numero_Pendiente;
               _item.AUDI_UsrCrea = Session.UserName;
                if (Client.SaveCtaCte(ref _item, CtaCte.TInterfazCtaCte.EnviarAsientoADiario))
                {_IsCorrect = true;}
                    else
                {_IsCorrect = false;}
               
            }
            return _IsCorrect;
         }
         catch (Exception)
         { throw; }
      }

      public Boolean RegenerarAsientoReversion()
      {
         try
         {
            Boolean _IsCorrect = false;

            if (!Validación()) { return _IsCorrect; }

            String _consulta = String.Format("¿Desea volver a Generar el Asiento de Reversión de Compras?");

            if (Infrastructure.WinForms.Controls.Dialogos.MostrarMensajePregunta(Title, _consulta, Infrastructure.WinForms.Controls.Dialogos.LabelBoton.Si_No) == System.Windows.Forms.DialogResult.Yes)
            {
               Entities.CtaCte _item = new CtaCte();
               _item.EMPR_Codigo = ItemLView.EMPR_Codigo;
               _item.CCCT_Codigo = ItemLView.CCCT_Codigo;
               _item.AUDI_UsrMod = Session.UserName;
               if (Client.SaveCtaCte(ref _item, CtaCte.TInterfazCtaCte.RegenerarAsientoReversionCompras))
               { _IsCorrect = true; }
               else
               { _IsCorrect = false; }
               //_IsCorrect = Client.SaveCtaCte(ref _item, CtaCte.TInterfazCtaCte.RegenerarAsientoReversionCompras);
            }

            return _IsCorrect;
         }
         catch (Exception)
         { throw; }
      }

      /// <summary>
      /// Guardar el documento
      /// </summary>
      /// <param name="ShowMessage"></param>
      /// <returns></returns>
      public bool Guardar(Boolean ShowMessage)
      {
          try
          {
              MView.GetItem();
              FleteNegativo = false;
              String _msg = "";
              if (Item.Validar() && ValidarAsiento(ref _msg))
              {
                  Entities.CtaCte _item = Item;
                  if (Client.SaveCtaCte(ref _item, CtaCte.TInterfazCtaCte.IngresoLibre))
                  {
                      if (ShowMessage) { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeSatisfactorio(Title, "Se ha guardado satisfactoriamente"); }
                      return true;
                  }
                  return false;
              }
              else
              {
                  Item.SetMensajeError(_msg);
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

      //public bool Guardar(Boolean ShowMessage)
      //{
      //    try
      //    {
      //        MView.GetItem();
      //        FleteNegativo = false;
      //        String _msg = "";
      //        if (Item.Validar() && ValidarAsiento(ref _msg))
      //        {
      //            Entities.CtaCte _item = Item;
      //            //String _voucher = Client.SaveCtaCteILD(ref _item, CtaCte.TInterfazCtaCte.IngresoLibre);
      //            String _voucher = Client.SaveCtaCteSLI(ref _item, x_DOPE_Items);
      //            if (_voucher != "")
      //            {
      //                if (ShowMessage) { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeSatisfactorio(Title, "Se generó el asiento contable: " + _voucher); }
      //                return true;
      //            }
      //            return false;
      //        }
      //        else
      //        {
      //            Item.SetMensajeError(_msg);
      //            MView.ShowValidation();
      //            return false;
      //        }
      //        return false;
      //    }
      //    catch (Exception ex)
      //    {
      //        Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Title, Infrastructure.Aspect.Constants.Mensajes.SavePresenter, ex);
      //        return false;
      //    }
      //}

      #region [ Generar Asientos ]

      private Boolean ValidarAsiento(ref String x_msg)
      {
         try
         {
            x_msg = "";
            Boolean m_isCorrect = true;
            Decimal m_porcentaje = 0;
            foreach (Entities.DetCtaCteAsientos item in Item.ListDetCtaCteAsientos)
            {
               item.EMPR_Codigo = Controls.Entorno.ItemEmpresa.EMPR_Codigo;
               if (!String.IsNullOrEmpty(item.TIPO_CodOPE.Trim())) { item.TIPO_TabOPE = "OPE"; }
               if (!item.Validar())
               {
                  m_isCorrect = false;
                  x_msg += String.Format("Debe validar los siguiente errores del detalle del asiento del Item [{2}]: {0}{1}", Environment.NewLine, item.MensajeError, item.DCCA_Item);
               }
               m_porcentaje += item.DCCA_DebePorc + item.DCCA_HaberPorc;
            }
            if (Item.ListDetCtaCteAsientos.Count > 0 && m_porcentaje != 100)
            {
               m_isCorrect = false;
               x_msg += String.Format("- El porcentaje total debe sumar el 100% {0}", Environment.NewLine);
            }
            if (Item.ListDetCtaCteAsientos.Count == 0 && Item.TMovimiento == CtaCte.TipoMovimiento.Egreso && Item.Instance == Infrastructure.Aspect.BusinessEntity.InstanceEntity.Added)
            {
               m_isCorrect = false;
               x_msg += String.Format("- Este documento tiene que tener un detalle de asiento{0}", Environment.NewLine);
            }

            if (!String.IsNullOrEmpty(Item.CCCT_NroDetraccion) || Item.CCCT_FecDetraccion.HasValue)
            {
               if (String.IsNullOrEmpty(Item.CCCT_NroDetraccion)) { x_msg += String.Format("- Debe ingresarse el Numero de Detracción.{0}", Environment.NewLine); m_isCorrect = false; }
               if (!Item.CCCT_FecDetraccion.HasValue) { x_msg += String.Format("- Debe ingresarse la fecha de Detracción.{0}", Environment.NewLine); m_isCorrect = false; }
            }

            CuadrarAsiento();
            return m_isCorrect;
         }
         catch (Exception)
         { throw; }
         return false;
      }

      private void CuadrarAsiento()
      {
         try
         {
            if (Item != null && Item.ListDetCtaCteAsientos != null && Item.ListDetCtaCteAsientos.Count > 0)
            {
               Decimal BaseDebe = Item.ListDetCtaCteAsientos.Sum(Det => Det.DCCA_DebeMonto);
               if (BaseDebe != Item.CCCT_ValVta)
               {
                  Decimal Diff = Item.CCCT_ValVta.Value - BaseDebe;
                  Decimal Maximo = Item.ListDetCtaCteAsientos.Max(Det => Det.DCCA_DebeMonto);
                  Entities.DetCtaCteAsientos _detAsiento = Item.ListDetCtaCteAsientos.Where(Det => Det.DCCA_DebeMonto == Maximo).FirstOrDefault();
                  _detAsiento.DCCA_DebeMonto += Diff;
               }
            }
         }
         catch (Exception)
         { throw; }
      }

      /// <summary>
      /// Obtener los datos de la plantilla de asiento configurada
      /// </summary>
      /// <param name="CABP_Ano"></param>
      /// <param name="CABP_Codigo"></param>
      public void ObtenerAsientos(String CABP_Ano, String CABP_Codigo)
      {
         try
         {
            if (!String.IsNullOrEmpty(CABP_Ano) && !String.IsNullOrEmpty(CABP_Codigo))
            {
               ObservableCollection<Infrastructure.Aspect.DataAccess.DataAccessFilterSQL> listFilters = new ObservableCollection<Infrastructure.Aspect.DataAccess.DataAccessFilterSQL>();
               listFilters = new ObservableCollection<Infrastructure.Aspect.DataAccess.DataAccessFilterSQL>();
               listFilters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@pchrCABP_Ano", FilterValue = CABP_Ano, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.Char, FilterSize = 4 });
               listFilters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@pvchCABP_Codigo", FilterValue = CABP_Codigo, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.Varchar, FilterSize = 3 });
               Item.ItemCabPerfilAsientos = new CabPerfilAsientos() { CABP_Ano = CABP_Ano, CABP_Codigo = CABP_Codigo };
               Item.ItemCabPerfilAsientos.ListDetPerfilAsientos = Client.GetAllDetPerfilAsientosFilter("CON_DETPSS_TodosPorCabecera", listFilters);
            }
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Title, "Error al obtener asientos", ex); }
      }

      /// <summary>
      /// Generar los asientos, utilizando las plantillas configurada desde este medio
      /// </summary>
      public void GenerarAsiento()
      {
         try
         {
            if (Item.ItemCabPerfilAsientos != null && Item.ItemCabPerfilAsientos.ListDetPerfilAsientos != null && Item.ItemCabPerfilAsientos.ListDetPerfilAsientos.Count > 0)
            {
               if (!Item.CCCT_ValVta.HasValue)
               {
                  foreach (Entities.DetPerfilAsientos iDet in Item.ItemCabPerfilAsientos.ListDetPerfilAsientos)
                  {
                     iDet.DETP_HaberPorc = iDet.DETP_HaberPorc / 100;
                     iDet.DETP_DebePorc = iDet.DETP_DebePorc / 100;
                  }
                  return;
               }
               Decimal x_BaseIMponible = Item.CCCT_ValVta.Value;
               Decimal x_Impuesto = (Item.CCCT_Imp1.HasValue ? Item.CCCT_Imp1.Value : 0);
               if (Item.TIPO_CodTDO.Equals(Entities.Tipos.GetTipo(Tipos.TipoTDO.NotaCredito)))
               {
                  foreach (Entities.DetPerfilAsientos iDet in Item.ItemCabPerfilAsientos.ListDetPerfilAsientos)
                  {
                     if (iDet.DETP_DebePorc.HasValue)
                     {
                        iDet.Haber = (iDet.DETP_DebePorc.Value / 100) * x_BaseIMponible;
                        iDet.DETP_HaberPorc = iDet.DETP_DebePorc / 100;
                        iDet.DETP_DebePorc = null;
                     }
                     else if (iDet.DETP_HaberPorc.HasValue)
                     {
                        iDet.Debe = (iDet.DETP_HaberPorc.Value / 100) * x_BaseIMponible;
                        iDet.DETP_DebePorc = iDet.DETP_HaberPorc / 100;
                        iDet.DETP_HaberPorc = null;
                     }

                     Entities.DetCtaCteAsientos DAsientos = new DetCtaCteAsientos();
                     DAsientos.DCCA_Cuenta = iDet.CUEN_Codigo;
                     DAsientos.CENT_Codigo = iDet.CENT_Codigo;
                     DAsientos.DCCA_DebePorc = iDet.DETP_DebePorc.HasValue ? iDet.DETP_DebePorc.Value : 0;
                     DAsientos.DCCA_HaberPorc = iDet.DETP_HaberPorc.HasValue ? iDet.DETP_HaberPorc.Value : 0;
                     DAsientos.DCCA_Glosa = iDet.DETP_Glosa;
                     DAsientos.CENT_Desc = iDet.CENT_Desc;
                     DAsientos.CUEN_Desc = iDet.CUEN_Desc;
                     DAsientos.AUDI_UsrCrea = Session.UserName;
                     Item.ListDetCtaCteAsientos.Add(DAsientos);

                  }
                  Item.ItemCabPerfilAsientos.ListDetPerfilAsientos.Add(new Entities.DetPerfilAsientos() { CUEN_Codigo = "Impuesto :", Haber = x_Impuesto });
                  Item.ItemCabPerfilAsientos.ListDetPerfilAsientos.Add(new Entities.DetPerfilAsientos() { CUEN_Codigo = "Total :", Debe = (x_BaseIMponible + x_Impuesto) });
               }
               else
               {
                  Item.ListDetCtaCteAsientos = new ObservableCollection<DetCtaCteAsientos>();
                  foreach (Entities.DetPerfilAsientos iDet in Item.ItemCabPerfilAsientos.ListDetPerfilAsientos)
                  {
                     if (iDet.DETP_DebePorc.HasValue) { iDet.Debe = (iDet.DETP_DebePorc.Value / 100) * x_BaseIMponible; iDet.DETP_DebePorc /= 100; }
                     if (iDet.DETP_HaberPorc.HasValue) { iDet.Haber = (iDet.DETP_HaberPorc.Value / 100) * x_BaseIMponible; iDet.DETP_HaberPorc /= 100; }

                     Entities.DetCtaCteAsientos DAsientos = new DetCtaCteAsientos();
                     DAsientos.DCCA_Cuenta = iDet.CUEN_Codigo;
                     DAsientos.CENT_Codigo = iDet.CENT_Codigo;
                     DAsientos.DCCA_DebePorc = iDet.DETP_DebePorc.HasValue ? iDet.DETP_DebePorc.Value * 100 : 0;
                     DAsientos.DCCA_HaberPorc = iDet.DETP_HaberPorc.HasValue ? iDet.DETP_HaberPorc.Value * 100 : 0;
                     DAsientos.DCCA_Glosa = iDet.DETP_Glosa;
                     DAsientos.CENT_Desc = iDet.CENT_Desc;
                     DAsientos.CUEN_Desc = iDet.CUEN_Desc;
                     DAsientos.TIPO_TabOPE = "OPE";
                     DAsientos.TIPO_CodOPE = "001";
                     DAsientos.AUDI_UsrCrea = Session.UserName;
                     Item.ListDetCtaCteAsientos.Add(DAsientos);
                  }

                  Item.ItemCabPerfilAsientos.ListDetPerfilAsientos.Add(new Entities.DetPerfilAsientos() { CUEN_Codigo = "Impuesto :", Debe = x_Impuesto });
                  Item.ItemCabPerfilAsientos.ListDetPerfilAsientos.Add(new Entities.DetPerfilAsientos() { CUEN_Codigo = "Total :", Haber = (x_BaseIMponible + x_Impuesto) });
               }
            }
         }
         catch (Exception)
         { throw; }
      }

      /// <summary>
      /// Ayuda de Centro de Costo
      /// </summary>
      /// <param name="x_CENT_Codigo">The x cent codigo.</param>
      /// <param name="x_CENT_Desc">The x cent desc.</param>
      /// <returns></returns>
      /// <exception cref="Exception">Error en el dialogo de Ayuda de Horarios Disponibles</exception>
      public Boolean AyudaCentroCto(ref String x_CENT_Ano, ref String x_CENT_Codigo, ref String x_CENT_Desc)
      {
         try
         {
            x_CENT_Ano = Fecha.Year.ToString();
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

      /// <summary>
      /// Ayuda de Cuentas Contables
      /// </summary>
      /// <param name="x_DCCA_Cuenta">The x dcca cuenta.</param>
      /// <returns></returns>
      public Boolean AyudaCuenta(ref String x_DCCA_Cuenta, ref String x_CUEN_Desc, ref Boolean x_ValidarCentroCto)
      {
         try
         {
            String x_CUEN_Ano = Fecha.Year.ToString();
            ObservableCollection<Infrastructure.Aspect.DataAccess.DataAccessFilterSQL> _listFilters = new ObservableCollection<Infrastructure.Aspect.DataAccess.DataAccessFilterSQL>();
            _listFilters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@CUEN_Ano", FilterValue = x_CUEN_Ano, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.Char, FilterSize = 4 });
            _listFilters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@CUEN_Codigo", FilterValue = x_DCCA_Cuenta, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.Varchar, FilterSize = 17 });

            System.Data.DataTable dtAyuda = new System.Data.DataTable();
            dtAyuda = Client.GetDTChequera("CON_CUENSS_TodosAyuda", _listFilters);

            if (dtAyuda.Rows.Count == 0)
            { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Title, "No se encontraron coincidencias."); }
            else if (dtAyuda.Rows.Count == 1)
            {
               x_DCCA_Cuenta = dtAyuda.Rows[0]["CUEN_Codigo"].ToString();
               x_CUEN_Desc = dtAyuda.Rows[0]["CUEN_Desc"].ToString();
               bool _vcc = false;
               x_ValidarCentroCto = _vcc;
               if (Boolean.TryParse(dtAyuda.Rows[0]["CUEN_CentroCto"].ToString(), out _vcc))
               { x_ValidarCentroCto = _vcc; }

               return true;
            }
            else
            {
               int i = 0;
               List<Infrastructure.WinForms.Controls.ColumnaAyuda> _columnas = new List<Infrastructure.WinForms.Controls.ColumnaAyuda>();
               _columnas.Add(new Infrastructure.WinForms.Controls.ColumnaAyuda()
               {
                  Index = i++,
                  ColumnName = "CUEN_Codigo",
                  ColumnCaption = "Código",
                  Alineacion = DataGridViewContentAlignment.MiddleLeft,
                  Width = 100,
                  DataType = typeof(System.String),
                  Format = null
               });

               _columnas.Add(new Infrastructure.WinForms.Controls.ColumnaAyuda()
               {
                  Index = i++,
                  ColumnName = "CUEN_Desc",
                  ColumnCaption = "Descripción",
                  Alineacion = DataGridViewContentAlignment.MiddleLeft,
                  Width = 250,
                  DataType = typeof(System.String),
                  Format = null
               });

               _columnas.Add(new Infrastructure.WinForms.Controls.ColumnaAyuda()
               {
                  Index = i++,
                  ColumnName = "CUEN_ano",
                  ColumnCaption = "Año",
                  Alineacion = DataGridViewContentAlignment.MiddleCenter,
                  Width = 60,
                  DataType = typeof(System.String),
                  Format = null
               });

               Infrastructure.WinForms.Controls.Ayuda x_Ayuda = new Infrastructure.WinForms.Controls.Ayuda("Ayuda - Centros de Cuentas Contables", dtAyuda, false, _columnas);

               if (x_Ayuda.ShowDialog() == System.Windows.Forms.DialogResult.OK)
               {
                  x_DCCA_Cuenta = x_Ayuda.Respuesta.Rows[0]["CUEN_Codigo"].ToString();
                  x_CUEN_Desc = x_Ayuda.Respuesta.Rows[0]["CUEN_Desc"].ToString();

                  bool _vcc = false;
                  x_ValidarCentroCto = _vcc;
                  if (Boolean.TryParse(x_Ayuda.Respuesta.Rows[0]["CUEN_CentroCto"].ToString(), out _vcc))
                  { x_ValidarCentroCto = _vcc; }
                  return true;
               }
               else { throw new Exception("Error en el dialogo de Ayuda de Horarios Disponibles"); }
            }
         }
         catch (Exception)
         { throw; }
         return false;
      }

      public Boolean EliminarDetAsiento(Entities.DetCtaCteAsientos x_detasiento)
      {
         try
         {
            if (Infrastructure.WinForms.Controls.Dialogos.MostrarMensajePregunta(Title, "¿Desea eliminar el registro seleccionado?", Infrastructure.WinForms.Controls.Dialogos.LabelBoton.Si_No) == System.Windows.Forms.DialogResult.Yes)
            {
               if (Item.ListDetCtaCteAsientosEliminados == null) { Item.ListDetCtaCteAsientosEliminados = new ObservableCollection<DetCtaCteAsientos>(); }
               if (Item.Instance == Infrastructure.Aspect.BusinessEntity.InstanceEntity.Added) { Item.ListDetCtaCteAsientosEliminados.Add(x_detasiento); }
               Item.ListDetCtaCteAsientos.Remove(x_detasiento);
               return true;
            }
            return false;
         }
         catch (Exception)
         { throw; }
      }

      #endregion

      public Boolean CargarFormaPago(Int32 ENTC_Codigo, ref Int16 DiasDuracion)
      {
         try
         {
            Decimal _monto = 0;
            return Client.GetOneEntidadLimiteCredito(Controls.Entorno.ItemEmpresa.EMPR_Codigo, ENTC_Codigo, ref _monto, ref DiasDuracion);
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
               if (TInicio != TipoInicio.MostraCtaCte)
               {
                  ((CAJ012IngresoLibreMView)MView).BringToFront();
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
               { return System.Windows.Forms.DialogResult.Yes; }
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
         if (isMViewShowed)
         {
            isMViewShowed = false;
            ((CAJ012IngresoLibreMView)MView).Close();
         }
      }

      public void IsClosedMView()
      { isMViewShowed = false; }

      #endregion

      #region [ Metodos Eventos/Tareas ]

      #endregion
   }
}