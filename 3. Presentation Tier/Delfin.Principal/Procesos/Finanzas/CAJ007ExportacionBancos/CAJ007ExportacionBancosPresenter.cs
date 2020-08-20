using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Windows.Forms;
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
using System.Drawing;
using Microsoft.Reporting.WinForms;


namespace Delfin.Principal
{
   public partial class CAJ007ExportacionBancosPresenter
   {
      #region [ Variables ]
      public String Title = "Exportación a Bancos";
      public String CUS = "CAJ007";

      public enum TCambio
      {
         Ventas = 0, Compras = 1
      }

      #endregion

      #region [ Constructor ]
      public CAJ007ExportacionBancosPresenter(IUnityContainer x_container, ICAJ007ExportacionBancosLView x_lview, Entities.Planillas.TipoPlanilla x_opcion)
      {
         try
         {
            this.ContainerService = x_container;
            Session = this.ContainerService.Resolve<ISessionService>();
            TPlanilla = x_opcion;
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

            String fecha = Fecha.ToString("yyyyMMdd");
            Entities.TiposCambio _TCambio = Client.GetOneTiposCambio(fecha);
            MensajeError = "";
            if (_TCambio != null)
            {
               TipoCambio = _TCambio.TIPC_Venta;
               if (!(TipoCambio > 0))
               { MensajeError = String.Format("El tipo de Cambio definido para [{0:dd/MM/yyyy}] no es correcto.", Fecha); Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Title, MensajeError); }
            }
            else { MensajeError = String.Format("No se ha definido el tipo de cambio para el dia {0:dd/MM/yyyy}", Fecha); Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Title, MensajeError); }

            switch (TPlanilla)
            {
               case Planillas.TipoPlanilla.MedioVirtual:
                  Title = "EXPORTACIÓN A BANCOS";
                  CUS = "CAJ007";
                  break;
               case Planillas.TipoPlanilla.Detracciones:
                  Title = "EXPORTACIÓN DETRACCIÓN";
                  CUS = "CAJ008";
                  break;
               default:
                  break;
            }

            Entities.Parametros para = Client.GetOneParametrosByClave("EMPRESA");
            if (para != null)
            {
               RUC_Empresa = para.PARA_Valor;
            }

            LView.LoadView();

            PathExportacion = Path.Combine(System.Windows.Forms.Application.StartupPath, "Exportacion");
            if (!Directory.Exists(PathExportacion))
            {
               Directory.CreateDirectory(PathExportacion);
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

      public ICAJ007ExportacionBancosLView LView { get; set; }
      public ICAJ007ExportacionBancosMView MView { get; set; }

      public ObservableCollection<Planillas> Items { get; set; }
      public Planillas Item { get; set; }

      public DateTime Fecha { get; set; }
      public Decimal TipoCambio { get; set; }
      public String MensajeError { get; set; }
      public String RUC_Empresa { get; set; }

      public ObservableCollection<Entities.Parametros> ListParametros { get; set; }

      public Planillas.TipoPlanilla TPlanilla { get; set; }
      public String PathExportacion { get; set; }
      #endregion

      #region [ Metodos ]

      public DateTime? F_FecIni { get; set; }
      public DateTime? F_FecFin { get; set; }
      public String F_CUBA_Codigo { get; set; }
      public String F_TIPO_TabBCO { get; set; }
      public String F_TIPO_CodBCO { get; set; }
      public String F_TIPO_TabMND { get; set; }
      public String F_TIPO_CodMND { get; set; }

      public Boolean F_MostrarTodos { get; set; }
      public Boolean F_MostrarCtaCte { get; set; }
      public Boolean F_MostrarCtaInterbancaria { get; set; }
      public Int16? F_TIPE_Codigo { get; set; }
      public Int32? F_ENTC_Codigo { get; set; }
      public DateTime? F_FecIniDocs { get; set; }
      public DateTime? F_FecFinDocs { get; set; }


      public void Actualizar()
      {
         try
         {
            Items = null;

            if (LView != null)
            {
               ObservableCollection<Infrastructure.Aspect.DataAccess.DataAccessFilterSQL> _listFilters = new ObservableCollection<Infrastructure.Aspect.DataAccess.DataAccessFilterSQL>();
               _listFilters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@psinEMPR_Codigo", FilterValue = Controls.Entorno.ItemEmpresa.EMPR_Codigo, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.Int16, FilterSize = 2 });
               _listFilters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@pchrPLAN_Tipo", FilterValue = Planillas.GetTipoPlanilla(TPlanilla), FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.Varchar, FilterSize = 3 });
               _listFilters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@FecIni", FilterValue = F_FecIni, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.DateTime, FilterSize = 8 });
               _listFilters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@FecFin", FilterValue = F_FecFin, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.DateTime, FilterSize = 8 });

               Items = Client.GetAllPlanillasFilter("CAJ_PLANSS_Todos", _listFilters);

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
               MView = new CAJ007ExportacionBancosMView();
               MView.Presenter = this;
               MView.LoadView();
            }

            MView.ClearItem();
            this.Item = new Planillas();
            this.Item.EMPR_Codigo = Controls.Entorno.ItemEmpresa.EMPR_Codigo;
            this.Item.SetEstado(Planillas.Estado.Ingresado);
            this.Item.SetTipoPlanilla(TPlanilla);
            this.Item.AUDI_UsrCrea = Session.UserName;
            this.Item.AUDI_FecCrea = Session.Fecha;
            this.Item.Instance = Infrastructure.Aspect.BusinessEntity.InstanceEntity.Added;
            this.Item.TPlanilla = TPlanilla;
            MView.SetItem();

            isMViewShow = true;
            if (LView != null) { ((CAJ007ExportacionBancosMView)MView).Icon = System.Drawing.Icon.FromHandle(((System.Drawing.Bitmap)LView.IconView).GetHicon()); }
            ((CAJ007ExportacionBancosMView)MView).Show();
            ((CAJ007ExportacionBancosMView)MView).BringToFront();

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
               MView = new CAJ007ExportacionBancosMView();
               MView.Presenter = this;
               MView.LoadView();
            }

            Item = Client.GetOnePlanillas(Delfin.Controls.Entorno.ItemEmpresa.EMPR_Codigo, Item.PLAN_Tipo, Item.PLAN_Codigo);

            if (Item != null)
            {
               MView.ClearItem();
               this.Item.AUDI_UsrMod = Session.UserName;
               this.Item.AUDI_FecMod = Session.Fecha;
               this.Item.Instance = Infrastructure.Aspect.BusinessEntity.InstanceEntity.Modified;
               this.Item.TPlanilla = TPlanilla;
               MView.SetItem();
               MView.SetEnabled(false);
               MView.SetEnabledEdit(false);
               MView.ShowItems();

               isMViewShow = true;
               if (LView != null) { ((CAJ007ExportacionBancosMView)MView).Icon = System.Drawing.Icon.FromHandle(((System.Drawing.Bitmap)LView.IconView).GetHicon()); }
               ((CAJ007ExportacionBancosMView)MView).Show();
               ((CAJ007ExportacionBancosMView)MView).BringToFront();
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
                  Entities.Planillas _item = Item;
                  if (Client.SavePlanillas(ref _item))
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

      public void Imprimir()
      {
         try
         {
            System.Data.DataTable dtReporte = new System.Data.DataTable();
            ObservableCollection<Infrastructure.Aspect.DataAccess.DataAccessFilterSQL> _listFilters = new ObservableCollection<Infrastructure.Aspect.DataAccess.DataAccessFilterSQL>();
            _listFilters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@psinEMPR_Codigo", FilterValue = Delfin.Controls.Entorno.ItemEmpresa.EMPR_Codigo, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.Int16, FilterSize = 2 });
            _listFilters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@pchrPLAN_Tipo", FilterValue = Item.PLAN_Tipo, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.Char, FilterSize = 3 });
            _listFilters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@pvchPLAN_Codigo", FilterValue = Item.PLAN_Codigo, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.Varchar, FilterSize = 20 });

            dtReporte = Client.GetDTCuentasBancarias("CAJ_REPOSS_EgresosPorPlanilla", _listFilters);

            if (dtReporte != null && dtReporte.Rows.Count > 0)
            {
               String ReportPath = null;
               dtReporte.TableName = "DSDetalle";
               ReportPath = Application.StartupPath + @"\Reportes\REP003PlanillaExportacion.rdlc";
               ReportDataSource RepDetalle = new ReportDataSource("DSDetalle", dtReporte);

               Microsoft.Reporting.WinForms.ReportParameter[] Parameters = new Microsoft.Reporting.WinForms.ReportParameter[2];
               Fecha = Client.GetFecha();
               String _fecha = Fecha.ToString("dd/MM/yyyy HH:mm");
               Parameters[0] = new Microsoft.Reporting.WinForms.ReportParameter("Titulo", "Reporte de " + Title);
               Parameters[1] = new Microsoft.Reporting.WinForms.ReportParameter("FechaHora", _fecha);
               //Parameters[3] = new Microsoft.Reporting.WinForms.ReportParameter("FechaDesde", F_FecIni.Value.ToString("dd/MM/yyyy"));
               //Parameters[4] = new Microsoft.Reporting.WinForms.ReportParameter("FechaHasta", F_FecFin.Value.ToString("dd/MM/yyyy"));

               Visualizador rpt = new Visualizador("Reporte de Planilla de Exportación a Bancos", ReportPath, RepDetalle, Parameters);
               rpt.StartPosition = FormStartPosition.CenterScreen;
               rpt.Imprimir();
               rpt.ShowDialog();
            }
            else { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Title, "No se encontraron registros"); }

         }
         catch (Exception)
         { throw; }
      }

      public void Buscar(string CUBA_Codigo)
      {
         try
         {
            ObservableCollection<Infrastructure.Aspect.DataAccess.DataAccessFilterSQL> _listFilters = new ObservableCollection<Infrastructure.Aspect.DataAccess.DataAccessFilterSQL>();
            _listFilters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@psinEMPR_Codigo", FilterValue = Controls.Entorno.ItemEmpresa.EMPR_Codigo, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.Int16, FilterSize = 2 });
            _listFilters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@pchrCUBA_Codigo", FilterValue = CUBA_Codigo, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.Varchar, FilterSize = 3 });
            _listFilters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@pchrTIPO_TabBCO", FilterValue = F_TIPO_TabBCO, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.Char, FilterSize = 3 });
            _listFilters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@pchrTIPO_CodBCO", FilterValue = F_TIPO_CodBCO, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.Char, FilterSize = 3 });
            _listFilters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@pchrTIPO_TabMND", FilterValue = F_TIPO_TabMND, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.Char, FilterSize = 3 });
            _listFilters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@pchrTIPO_CodMND", FilterValue = F_TIPO_CodMND, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.Char, FilterSize = 3 });
            _listFilters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@MostrarTodos", FilterValue = F_MostrarTodos, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.Boolean, FilterSize = 1 });
            _listFilters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@MostrarCtaCte", FilterValue = F_MostrarCtaCte, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.Boolean, FilterSize = 1 });
            _listFilters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@MostrarCtaInterbancaria", FilterValue = F_MostrarCtaInterbancaria, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.Boolean, FilterSize = 1 });

            switch (TPlanilla)
            {
               case Planillas.TipoPlanilla.MedioVirtual:
                  _listFilters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@pintENTC_Codigo", FilterValue = F_ENTC_Codigo, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.Int32, FilterSize = 4 });
                  _listFilters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@FecIniDocs", FilterValue = F_FecIniDocs, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.DateTime, FilterSize = 8 });
                  _listFilters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@FecFinDocs", FilterValue = F_FecFinDocs, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.DateTime, FilterSize = 8 });
                  Item.ListDetCtaCte = Client.GetAllDetCtaCteFilter("CAJ_CCCTSS_TodosPendientesMedioVirtual", _listFilters);
                  break;
               case Planillas.TipoPlanilla.Detracciones:
                  Item.ListDetCtaCte = Client.GetAllDetCtaCteFilter("CAJ_CCCTSS_TodosPendientesDetracciones", _listFilters);
                  break;
               default:
                  break;
            }

            MView.ShowItems();
         }
         catch (Exception)
         { throw; }
      }

      public bool Guardar(Boolean ShowMessage)
      {
         try
         {
            MView.GetItem();
            if (Item.ListDetCtaCte != null)
            {
               Item.ListDetCtaCte = Item.ListDetCtaCte.Where(DCta => DCta.Seleccionar).ToObservableCollection();
            }
            if (Item.Validar())
            {
               //ObservableCollection<Entities.DetCtaCte> _listGroup = new ObservableCollection<Entities.DetCtaCte>();
               //_listGroup = (from DCtaCte in Item.ListDetCtaCte
               //              group DCtaCte by new { DCtaCte.ENTC_DocIden, DCtaCte.ENTC_RazonSocial, DCtaCte.MOVI_Codigo, DCtaCte.ENTC_Codigo } into LDetCtaCte
               //              select new DetCtaCte()
               //              {
               //                 ENTC_Codigo = LDetCtaCte.Key.ENTC_Codigo,
               //                 ENTC_DocIden = LDetCtaCte.Key.ENTC_DocIden,
               //                 ENTC_RazonSocial = LDetCtaCte.Key.ENTC_RazonSocial,
               //                 MOVI_Codigo = LDetCtaCte.Key.MOVI_Codigo,
               //                 CCCT_Pendiente = LDetCtaCte.Sum(x => x.CCCT_Pendiente)
               //              }
               //             ).ToObservableCollection();

               Item.ListMovimiento = new ObservableCollection<Movimiento>();
               //foreach (Entities.DetCtaCte iGroup in _listGroup)
               //{
               Entities.Movimiento _movi = new Movimiento();
               //if (iGroup.MOVI_Codigo == null) {
               _movi.Instance = Infrastructure.Aspect.BusinessEntity.InstanceEntity.Added;
               //}
               _movi.CUBA_Codigo = Item.ItemCuentasBancarias.CUBA_Codigo;
               _movi.EMPR_Codigo = Item.EMPR_Codigo;
               _movi.SUCR_Codigo = Delfin.Controls.Entorno.ItemSucursal.SUCR_Codigo;
               _movi.SetTipoMovimiento(Movimiento.TipoMovimiento.EgresosTransferenciaMVirtual);
               _movi.SetEstado(Movimiento.Estado.Ingresado);
               _movi.MOVI_FecEmision = Item.PLAN_FechaEmision;

               decimal _total = Item.ListDetCtaCte.Sum(Det => (Det.CCCT_Pendiente.HasValue ? Det.CCCT_Pendiente.Value : 0));

               _movi.MOVI_MontoHaber = _total;
               _movi.MOVI_MontoDebe = 0;
               _movi.MOVI_Cheque = false;
               _movi.ENTC_Codigo = Item.ListDetCtaCte[0].ENTC_Codigo;
               _movi.AUDI_UsrCrea = Session.UserName;
               _movi.MOVI_TipoCambio = Item.TipoCambio;
               _movi.MOVI_FecOperacion = Item.PLAN_FechaEmision;

               Item.ListMovimiento.Add(_movi);
               //}

               Entities.Planillas _item = Item;
               if (Client.SavePlanillas(ref _item))
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

      public String ExportarTXT(String x_banco, String NombreDestino)
      {
         try
         {
            ObservableCollection<Infrastructure.Aspect.DataAccess.DataAccessFilterSQL> _listFilters = new ObservableCollection<Infrastructure.Aspect.DataAccess.DataAccessFilterSQL>();
            _listFilters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@psinEMPR_Codigo", FilterValue = Item.EMPR_Codigo, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.Int16, FilterSize = 2 });
            _listFilters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@pchrPLAN_Tipo", FilterValue = Item.PLAN_Tipo, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.Varchar, FilterSize = 3 });
            _listFilters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@pvchPLAN_Codigo", FilterValue = Item.PLAN_Codigo, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.Varchar, FilterSize = 20 });

            System.Data.DataTable dtExportar = new System.Data.DataTable();
            switch (TPlanilla)
            {
               case Planillas.TipoPlanilla.MedioVirtual:
                  dtExportar = Client.GetDTDetCtaCte("CAJ_DCCTSS_ExportarTXT", _listFilters);
                  break;
               case Planillas.TipoPlanilla.Detracciones:
                  dtExportar = Client.GetDTDetCtaCte("CAJ_DCCTSS_ExportarTXTDetraccion", _listFilters);
                  break;
               default:
                  break;
            }
            if (dtExportar.Rows.Count > 0)
            {
               switch (TPlanilla)
               {
                  case Planillas.TipoPlanilla.MedioVirtual:
                     switch (x_banco)
                     {
                        case "BCP":
                           return ExportarMV_BCP(dtExportar, x_banco, NombreDestino);
                           break;
                        case "BBVA":
                           break;
                        case "INTERBANK":
                           break;
                        case "BANBIF":
                           switch (TPlanilla)
                           {
                              case Planillas.TipoPlanilla.MedioVirtual:
                                 return ExportarMV_BANBIF(dtExportar, x_banco, NombreDestino);
                              case Planillas.TipoPlanilla.Detracciones:
                                 break;
                           }
                           break;
                        case "BN":

                           break;
                        default:
                           break;
                     }
                     break;
                  case Planillas.TipoPlanilla.Detracciones:
                     return ExportarDet_BN(dtExportar, x_banco, NombreDestino);
                     break;
                  default:
                     break;
               }
            }
            else { throw new Exception("No se encontraron registros"); }
            return null;
         }
         catch (Exception)
         { throw; }
      }

      private Decimal ChekSum(System.Data.DataTable dtExportar)
      {
         try
         {
            Decimal _total = 0;
            _total += ValidarNumero(dtExportar.Rows[0]["CUBA_NroCuenta"].ToString());
            foreach (System.Data.DataRow item in dtExportar.Rows)
            {
               _total += ValidarNumero(item["NroCuenta"].ToString().Trim());
            }
            return _total;
         }
         catch (Exception)
         { throw; }
      }

      private Decimal ValidarNumero(String x_cuenta)
      {
         try
         {
            Decimal _cuenta = 0;
            if (Decimal.TryParse(x_cuenta, out _cuenta))
            {
               return _cuenta;
            }
            else
            {
               Char[] _charsCuenta = x_cuenta.ToCharArray();
               String _newCuenta = "";
               foreach (char iChar in _charsCuenta)
               {
                  Int16 _numero = 0;
                  if (Int16.TryParse(iChar.ToString(), out _numero))
                  { _newCuenta = String.Format("{0}{1}", _newCuenta, _numero); }
                  else
                  { _newCuenta = String.Format("{0}{1}", _newCuenta, 0); }
               }
               if (Decimal.TryParse(_newCuenta, out _cuenta))
               {
                  return _cuenta;
               }
            }
            return _cuenta;
         }
         catch (Exception)
         { throw; }
      }

      private String ExportarMV_BCP(System.Data.DataTable dtExportar, String x_banco, String NombreDestino)
      {
         try
         {
            Delfin.Controls.GenerarTxt _generadorCacebera = new Controls.GenerarTxt();
            _generadorCacebera.Columnas = new int[10] { 1, 6, 8, 1, 4, 20, 17, 40, 1, 15 };
            _generadorCacebera.TiposDeDatos = new Controls.GenerarTxt.TipoDato[10] { Controls.GenerarTxt.TipoDato.Caracter, Controls.GenerarTxt.TipoDato.Numerico, 
                                                                                     Controls.GenerarTxt.TipoDato.Caracter, Controls.GenerarTxt.TipoDato.Caracter, 
                                                                                     Controls.GenerarTxt.TipoDato.Caracter, Controls.GenerarTxt.TipoDato.Caracter, 
                                                                                     Controls.GenerarTxt.TipoDato.Caracter, Controls.GenerarTxt.TipoDato.Caracter, 
                                                                                     Controls.GenerarTxt.TipoDato.Caracter, Controls.GenerarTxt.TipoDato.Numerico, 
                                                                             };
            _generadorCacebera.Alineaciones = new ContentAlignment[10] { ContentAlignment.MiddleLeft, ContentAlignment.MiddleRight, ContentAlignment.MiddleLeft, ContentAlignment.MiddleRight, ContentAlignment.MiddleLeft,
                                                                         ContentAlignment.MiddleLeft, ContentAlignment.MiddleRight, ContentAlignment.MiddleLeft, ContentAlignment.MiddleLeft, ContentAlignment.MiddleRight,
                                                                        };
            _generadorCacebera.Rellenos = new Char[10] { ' ', '0', ' ', ' ', ' ', ' ', '0', ' ', ' ', '0' };
            _generadorCacebera.Formato = "0000000000000.00";

            String[] Linea = new String[10];
            Linea[0] = "1";
            Linea[1] = dtExportar.Rows.Count.ToString();
            Linea[2] = Fecha.ToString("yyyyMMdd");
            Linea[3] = dtExportar.Rows[0]["CUBA_TipoCuenta"].ToString();
            Linea[4] = dtExportar.Rows[0]["MND"].ToString();
            Linea[5] = dtExportar.Rows[0]["CUBA_NroCuenta"].ToString();
            Linea[6] = dtExportar.Rows[0]["TOTAL"].ToString();
            Linea[7] = "";
            Linea[8] = "S";
            Linea[9] = ChekSum(dtExportar).ToString();
            _generadorCacebera.Add(Linea, Controls.GenerarTxt.TipoRegistro.Registro);

            Delfin.Controls.GenerarTxt _generadorDetalle = new Controls.GenerarTxt();
            _generadorDetalle.Columnas = new int[13] { 1, 1, 20, 1, 1, 12, 3, 75, 40, 20, 4, 17, 1 };
            _generadorDetalle.TiposDeDatos = new Controls.GenerarTxt.TipoDato[13] { Controls.GenerarTxt.TipoDato.Caracter, Controls.GenerarTxt.TipoDato.Caracter, 
                                                                                    Controls.GenerarTxt.TipoDato.Caracter, Controls.GenerarTxt.TipoDato.Caracter, 
                                                                                    Controls.GenerarTxt.TipoDato.Caracter, Controls.GenerarTxt.TipoDato.Caracter, 
                                                                                    Controls.GenerarTxt.TipoDato.Caracter, Controls.GenerarTxt.TipoDato.Caracter, 
                                                                                    Controls.GenerarTxt.TipoDato.Caracter, Controls.GenerarTxt.TipoDato.Caracter, 
                                                                                    Controls.GenerarTxt.TipoDato.Caracter, Controls.GenerarTxt.TipoDato.DecimalPunto, 
                                                                                    Controls.GenerarTxt.TipoDato.Caracter};
            _generadorDetalle.Alineaciones = new ContentAlignment[13] { ContentAlignment.MiddleLeft, ContentAlignment.MiddleLeft, ContentAlignment.MiddleLeft, 
                                                                        ContentAlignment.MiddleLeft, ContentAlignment.MiddleLeft, ContentAlignment.MiddleLeft, 
                                                                        ContentAlignment.MiddleLeft, ContentAlignment.MiddleLeft, ContentAlignment.MiddleLeft, 
                                                                        ContentAlignment.MiddleLeft, ContentAlignment.MiddleLeft, ContentAlignment.MiddleRight, 
                                                                        ContentAlignment.MiddleLeft };

            _generadorDetalle.Rellenos = new Char[13] { ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '0', ' ' };
            _generadorDetalle.Formato = "0000000000000.00";
            _generadorDetalle.Archivo.Append(_generadorCacebera.Archivo.ToString());
            _generadorDetalle.Registros++;

            int i = 0;
            foreach (System.Data.DataRow iDetCta in dtExportar.Rows)
            {
               i++;
               String[] LineaCuerpo = new String[13];
               LineaCuerpo[0] = "2";
               LineaCuerpo[1] = iDetCta["TipoCuenta"].ToString().Trim();
               LineaCuerpo[2] = iDetCta["NroCuenta"].ToString().Trim();
               LineaCuerpo[3] = iDetCta["ModalidadPago"].ToString().Trim();
               LineaCuerpo[4] = iDetCta["TDI"].ToString().Trim();
               LineaCuerpo[5] = iDetCta["ENTC_DocIden"].ToString().Trim();
               LineaCuerpo[6] = iDetCta["CorrelativoDocProveedor"].ToString().Trim();
               LineaCuerpo[7] = iDetCta["ENTC_RazonSocial"].ToString().Trim();
               LineaCuerpo[8] = iDetCta["ReferenciaBeneficiario"].ToString().Trim();
               LineaCuerpo[9] = iDetCta["ReferenciaEmpresa"].ToString().Trim();
               LineaCuerpo[10] = iDetCta["MND"].ToString().Trim();
               LineaCuerpo[11] = iDetCta["CCCT_Monto"].ToString().Trim();
               LineaCuerpo[12] = iDetCta["ValidarIDC"].ToString().Trim();

               if (i == dtExportar.Rows.Count)
               { _generadorDetalle.Add(LineaCuerpo, Controls.GenerarTxt.TipoRegistro.Registro, Controls.GenerarTxt.SaltoLinea.No); }
               else
               { _generadorDetalle.Add(LineaCuerpo, Controls.GenerarTxt.TipoRegistro.Registro, Controls.GenerarTxt.SaltoLinea.Si); }
            }
            String PathSave = NombreDestino; // Path.Combine(NombreDestino, Item.PLAN_Archivo);
            Controls.Utilitarios.SaveFileSinSalto(PathSave, null, _generadorDetalle.Archivo);
            return PathSave;
         }
         catch (Exception)
         { throw; }
      }

      private String ExportarMV_BANBIF(System.Data.DataTable dtExportar, String x_banco, String NombreDestino)
      {
         try
         {

            Delfin.Controls.GenerarTxt _generador = new Controls.GenerarTxt();
            _generador.Columnas = new int[16] { 1, 15, 60, 1, 14, 3, 10, 8, 15, 1, 3, 3, 20, 14, 8, 2 };
            _generador.TiposDeDatos = new Controls.GenerarTxt.TipoDato[16] { Controls.GenerarTxt.TipoDato.Caracter, Controls.GenerarTxt.TipoDato.Caracter, Controls.GenerarTxt.TipoDato.Caracter, Controls.GenerarTxt.TipoDato.Numerico, Controls.GenerarTxt.TipoDato.Caracter ,
                                                                             Controls.GenerarTxt.TipoDato.Caracter, Controls.GenerarTxt.TipoDato.Decimal, Controls.GenerarTxt.TipoDato.Caracter, Controls.GenerarTxt.TipoDato.Caracter, Controls.GenerarTxt.TipoDato.Numerico, 
                                                                             Controls.GenerarTxt.TipoDato.Numerico, Controls.GenerarTxt.TipoDato.Caracter, Controls.GenerarTxt.TipoDato.Numerico, Controls.GenerarTxt.TipoDato.Caracter, Controls.GenerarTxt.TipoDato.Numerico,
                                                                             Controls.GenerarTxt.TipoDato.Numerico};
            _generador.Alineaciones = new ContentAlignment[16] { ContentAlignment.MiddleLeft, ContentAlignment.MiddleLeft, ContentAlignment.MiddleLeft, ContentAlignment.MiddleRight, ContentAlignment.MiddleLeft,
                                                                 ContentAlignment.MiddleLeft, ContentAlignment.MiddleRight, ContentAlignment.MiddleLeft, ContentAlignment.MiddleLeft, ContentAlignment.MiddleRight,
                                                                 ContentAlignment.MiddleRight, ContentAlignment.MiddleLeft, ContentAlignment.MiddleRight, ContentAlignment.MiddleLeft, ContentAlignment.MiddleRight,
                                                                 ContentAlignment.MiddleRight
            };
            _generador.Rellenos = new Char[16] { ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ' };
            foreach (System.Data.DataRow iDetCta in dtExportar.Rows)
            {
               String[] Linea = new String[16];
               Linea[0] = iDetCta["TDI"].ToString().Trim();
               Linea[1] = iDetCta["ENTC_DocIden"].ToString().Trim();
               Linea[2] = iDetCta["ENTC_RazonSocial"].ToString().Trim();
               Linea[3] = iDetCta["TDO"].ToString().Trim();
               Linea[4] = iDetCta["CCCT_Numero"].ToString().Trim();
               Linea[5] = iDetCta["MND"].ToString().Trim();
               Linea[6] = iDetCta["CCCT_Monto"].ToString().Trim();
               Linea[7] = iDetCta["CCCT_FecCancel"].ToString().Trim();
               Linea[8] = iDetCta["CodigoPropio"].ToString().Trim();
               Linea[9] = iDetCta["FPG"].ToString().Trim();
               Linea[10] = iDetCta["CodigoBanco"].ToString().Trim();
               Linea[11] = iDetCta["MND_CTA"].ToString().Trim();
               Linea[12] = iDetCta["NroCuenta"].ToString().Trim();
               Linea[13] = iDetCta["NotaCredito"].ToString().Trim();
               Linea[14] = iDetCta["FechaAdelanto"].ToString().Trim();
               Linea[15] = iDetCta["Constante"].ToString().Trim();

               _generador.Add(Linea, Controls.GenerarTxt.TipoRegistro.Registro);
            }
            String PathSave = NombreDestino; // Path.Combine(NombreDestino, Item.PLAN_Archivo);
            Controls.Utilitarios.SaveFile(PathSave, null, _generador.Archivo);
            return PathSave;
         }
         catch (Exception)
         { throw; }
      }

      private String ExportarDet_BN(System.Data.DataTable dtExportar, String x_banco, String NombreDestino)
      {
         try
         {

            Delfin.Controls.GenerarTxt _generadorCabecera = new Controls.GenerarTxt();
            _generadorCabecera.Columnas = new int[5] { 1, 11, 35, 6, 15 };
            _generadorCabecera.TiposDeDatos = new Controls.GenerarTxt.TipoDato[5] { Controls.GenerarTxt.TipoDato.Caracter, Controls.GenerarTxt.TipoDato.Caracter, 
                                                                                     Controls.GenerarTxt.TipoDato.Caracter, Controls.GenerarTxt.TipoDato.Caracter, 
                                                                                     Controls.GenerarTxt.TipoDato.Decimal };
            _generadorCabecera.Alineaciones = new ContentAlignment[5] { ContentAlignment.MiddleLeft, ContentAlignment.MiddleLeft, ContentAlignment.MiddleLeft, 
                                                                        ContentAlignment.MiddleRight, ContentAlignment.MiddleRight };
            _generadorCabecera.Rellenos = new Char[5] { ' ', ' ', ' ', ' ', '0' };
            String[] Linea = new String[5];
            Linea[0] = "*".ToString().Trim();
            Linea[1] = dtExportar.Rows[0]["EMPR_RUC"].ToString().Trim();
            Linea[2] = dtExportar.Rows[0]["EMPR_RazonSocial"].ToString().Trim();
            Linea[3] = dtExportar.Rows[0]["LOTE"].ToString().Trim();
            Linea[4] = dtExportar.Rows[0]["TOTAL"].ToString().Trim();
            _generadorCabecera.Add(Linea, Controls.GenerarTxt.TipoRegistro.Registro);


            Delfin.Controls.GenerarTxt _generador = new Controls.GenerarTxt();
            _generador.Columnas = new int[12] { 1, 11, 35, 9, 3, 11, 15, 2, 6, 2, 4, 8 };
            _generador.TiposDeDatos = new Controls.GenerarTxt.TipoDato[12] { Controls.GenerarTxt.TipoDato.Caracter, Controls.GenerarTxt.TipoDato.Caracter, 
                                                                             Controls.GenerarTxt.TipoDato.Caracter, Controls.GenerarTxt.TipoDato.Caracter, 
                                                                             Controls.GenerarTxt.TipoDato.Caracter, Controls.GenerarTxt.TipoDato.Caracter, 
                                                                             Controls.GenerarTxt.TipoDato.Decimal, Controls.GenerarTxt.TipoDato.Caracter, 
                                                                             Controls.GenerarTxt.TipoDato.Caracter, Controls.GenerarTxt.TipoDato.Caracter, 
                                                                             Controls.GenerarTxt.TipoDato.Caracter, Controls.GenerarTxt.TipoDato.Caracter};
            _generador.Alineaciones = new ContentAlignment[12] { ContentAlignment.MiddleLeft, ContentAlignment.MiddleLeft, ContentAlignment.MiddleLeft, 
                                                                 ContentAlignment.MiddleLeft, ContentAlignment.MiddleLeft, ContentAlignment.MiddleLeft, 
                                                                 ContentAlignment.MiddleRight, ContentAlignment.MiddleLeft, ContentAlignment.MiddleLeft, 
                                                                 ContentAlignment.MiddleRight, ContentAlignment.MiddleRight, ContentAlignment.MiddleRight };
            _generador.Rellenos = new Char[12] { ' ', ' ', ' ', '0', ' ', ' ', '0', ' ', ' ', '0', '0', '0' };
            _generador.Archivo.Append(_generadorCabecera.Archivo.ToString());

            int _conta = 0;

            foreach (System.Data.DataRow iDetCta in dtExportar.Rows)
            {
               _conta++;
               String[] LineaCuerpo = new String[12];
               LineaCuerpo[0] = iDetCta["TIPO_CodTDI"].ToString().Trim();
               LineaCuerpo[1] = iDetCta["ENTC_DocIden"].ToString().Trim();
               LineaCuerpo[2] = iDetCta["ENTC_RazonSocial"].ToString().Trim();
               LineaCuerpo[3] = iDetCta["Proforma"].ToString().Trim();
               LineaCuerpo[4] = iDetCta["TIPO_CodSunat"].ToString().Trim();
               LineaCuerpo[5] = iDetCta["ENTC_CuentaDetraccion"].ToString().Trim();
               LineaCuerpo[6] = iDetCta["CCCT_Monto"].ToString().Trim();
               LineaCuerpo[7] = iDetCta["TipoOperacion"].ToString().Trim();
               LineaCuerpo[8] = iDetCta["PeriodoTributario"].ToString().Trim();
               LineaCuerpo[9] = iDetCta["TipoDocumento"].ToString().Trim();
               LineaCuerpo[10] = iDetCta["CCCT_Serie"].ToString().Trim();
               LineaCuerpo[11] = iDetCta["CCCT_Numero"].ToString().Trim();

               if (_conta == dtExportar.Rows.Count)
               { _generador.Add(LineaCuerpo, Controls.GenerarTxt.TipoRegistro.Registro, Controls.GenerarTxt.SaltoLinea.No); }
               else
               { _generador.Add(LineaCuerpo, Controls.GenerarTxt.TipoRegistro.Registro, Controls.GenerarTxt.SaltoLinea.Si); }
            }
            String PathSave = NombreDestino; // Path.Combine(NombreDestino, Item.PLAN_Archivo);
            Controls.Utilitarios.SaveFile(PathSave, null, _generador.Archivo);
            return PathSave;
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
            CAJ012_presenter.ItemLView.EMPR_Codigo = _detctacte.EMPR_Codigo;
            CAJ012_presenter.ItemLView.CCCT_Codigo = _detctacte.CCCT_Codigo;
            CAJ012_presenter.Editar();
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
               ((CAJ007ExportacionBancosMView)MView).BringToFront();
               System.Windows.Forms.DialogResult _result = Infrastructure.WinForms.Controls.Dialogos.MostrarMensajePregunta(Title, Infrastructure.Aspect.Constants.Mensajes.SaveChangesPreguntaPresenter, Infrastructure.WinForms.Controls.Dialogos.LabelBoton.Si_No);
               if (_result == System.Windows.Forms.DialogResult.Yes)
               {
                  return System.Windows.Forms.DialogResult.Yes;
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
         { ((CAJ007ExportacionBancosMView)MView).Close(); }
      }

      public void IsClosedMView()
      { isMViewShow = false; }

      #endregion

      #region [ Metodos Eventos/Tareas ]

      #endregion
   }
}