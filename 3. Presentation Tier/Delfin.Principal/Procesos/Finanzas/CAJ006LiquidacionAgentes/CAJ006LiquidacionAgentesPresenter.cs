using System;
using System.Collections.Generic;
using System.Data;
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

using System.Configuration;
using System.Net;
using System.Runtime.Serialization.Json;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using Telerik.WinControls.UI;
using Infrastructure.WinForms.Controls;

using XLExcel = Microsoft.Office.Interop.Excel;

namespace Delfin.Principal
{
   public partial class CAJ006LiquidacionAgentesPresenter
   {
      #region [ Variables ]
      public String Title = "Liquidación de Agentes";
      public String CUS = "CAJ006";
      public Boolean FleteNegativo = false;
      #endregion

      #region [ Constructor ]
      public CAJ006LiquidacionAgentesPresenter(IUnityContainer x_container, ICAJ006LiquidacionAgentesLView x_lview)
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

      public ICAJ006LiquidacionAgentesLView LView { get; set; }
      public ICAJ006LiquidacionAgentesDViewConciliacion DView { get; set; }

      public Entities.Liquidacion Item { get; set; }
      public enum TBusqueda
      {
         Normal = 0, Apertura = 1
      }

      public TBusqueda TipoBusqueda { get; set; }
      public String F_LIQU_Estado { get; set; }
      public Boolean F_Statement { get; set; }
      public String F_UnidadNegocio { get; set; }
      public Int32? F_ENTC_Codigo { get; set; }
      public DateTime Fecha { get; set; }
      public String MsgError { get; set; }
      public Boolean ConciliacionProcesado { get; set; }
      public System.Data.DataTable DTNoProcesados { get; set; }
      public System.Data.DataTable DTImportacion { get; set; }

      public String R_Estado { get; set; }
      public String R_Codigo { get; set; }
      public String R_Agente { get; set; }
      public String R_Glosa { get; set; }
      public String R_FechaEmision { get; set; }
      #endregion

      #region [ Metodos ]

      /// <summary>
      /// Actualizar el listado
      /// </summary>
      /// <param name="x_opcion"></param>
      /// <param name="x_IncluirPendientes"></param>
      public void Actualizar(TBusqueda x_opcion, Boolean x_IncluirPendientes)
      {
         try
         {
            Item.ListCtaCte = null;

            ObservableCollection<Infrastructure.Aspect.DataAccess.DataAccessFilterSQL> listFilters = new ObservableCollection<Infrastructure.Aspect.DataAccess.DataAccessFilterSQL>();
            listFilters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@psinEMPR_Codigo", FilterValue = Controls.Entorno.ItemEmpresa.EMPR_Codigo, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.Int16, FilterSize = 2 });
            listFilters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@Statement", FilterValue = F_Statement, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.Boolean, FilterSize = 1 });
            listFilters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@UnidadNegocio", FilterValue = F_UnidadNegocio, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.Char, FilterSize = 1 });
            listFilters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@pintENTC_Codigo", FilterValue = F_ENTC_Codigo, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.Int32, FilterSize = 4 });

            String x_procedure = "CAJ_CCCTSS_TodosPendientesEgresosLiquidacion";
            switch (x_opcion)
            {
               case TBusqueda.Normal:
                  x_procedure = "CAJ_CCCTSS_TodosPendientesEgresosLiquidacion";
                  break;
               case TBusqueda.Apertura:
                  listFilters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@pvchLIQU_Codigo", FilterValue = Item.LIQU_Codigo, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.Varchar, FilterSize = 20 });
                  x_procedure = "CAJ_CCCTSS_TodosLiquidacion";
                  break;
               default:
                  break;
            }
            Item.ListCtaCte = Client.GetAllCtaCteFilter(x_procedure, listFilters);

            if (x_opcion == TBusqueda.Apertura)
            {
               if (!x_IncluirPendientes && Item.ListCtaCte != null) { Item.ListCtaCte = Item.ListCtaCte.Where(Liq => Liq.Seleccionar).ToObservableCollection(); }
               foreach (Entities.CtaCte iCtaCte in Item.ListCtaCte)
               {
                  iCtaCte.ItemLiqCtaCte = new LiqCtaCte();
                  iCtaCte.ItemLiqCtaCte.EMPR_Codigo = iCtaCte.EMPR_Codigo;
                  iCtaCte.ItemLiqCtaCte.CCCT_Codigo = iCtaCte.CCCT_Codigo;
                  iCtaCte.ItemLiqCtaCte.LIQU_Codigo = iCtaCte.LIQU_Codigo;
                  iCtaCte.ItemLiqCtaCte.LCCC_Item = iCtaCte.LCCC_Item;
                  iCtaCte.ItemLiqCtaCte.Instance = Infrastructure.Aspect.BusinessEntity.InstanceEntity.Unchanged;
               }
            }

            if (LView != null)
            { LView.ShowItems(x_opcion); }
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Title, "Ha ocurrido un error actualizando.", ex); }
      }

      Boolean isMViewShow = false;

      /// <summary>
      /// Crear una nueva liquidación, cargando el listado de documentos pendientes segun el agente seleccionado
      /// </summary>
      public void Nuevo()
      {
         try
         {
            this.Item = new Liquidacion();
            this.Item.EMPR_Codigo = Controls.Entorno.ItemEmpresa.EMPR_Codigo;
            this.Item.AUDI_UsrCrea = Session.UserName;
            this.Item.AUDI_FecCrea = Session.Fecha;
            this.Item.LIQU_Fecha = Client.GetFecha();
            this.Item.SetEstado(Liquidacion.Estado.Abierta);
            Item.ListCtaCte = new ObservableCollection<CtaCte>();
            Item.ListCtaCteEliminados = new ObservableCollection<CtaCte>();
            this.Item.Instance = Infrastructure.Aspect.BusinessEntity.InstanceEntity.Added;
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Title, Infrastructure.Aspect.Constants.Mensajes.NewPresenter, ex); }
      }

      /// <summary>
      /// Editar la liquidación creada, cargando los registros anteriormente registrados
      /// </summary>
      public void Editar()
      {
         try
         {
            Item = Client.GetOneLiquidacion(Item.EMPR_Codigo, Item.LIQU_Codigo);

            if (Item != null)
            {
               this.Item.AUDI_UsrMod = Session.UserName;
               this.Item.AUDI_FecMod = Session.Fecha;
               this.Item.Instance = Infrastructure.Aspect.BusinessEntity.InstanceEntity.Modified;
            }
            else
            { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Title, "Debe seleccionar un elemento de la grilla"); }
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Title, Infrastructure.Aspect.Constants.Mensajes.EditPresenter, ex); }
      }

      /// <summary>
      /// Guardar la liquidación con todos los documentos pendientes seleccionados
      /// </summary>
      /// <returns></returns>
      public bool Liquidar()
      {
         try
         {
            LView.GetItem();
            if (Item.Validar())
            {
               Entities.Liquidacion _item = Item;
               if (Client.SaveLiquidacion(ref _item))
               {
                  Item = _item;
                  Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeSatisfactorio(Title, String.Format("Se ha liquidado satisfactoriamente, se generó la liquidación Nro: {0}", _item.LIQU_Codigo));
                  return true;
               }
            }
            else
            {
               LView.ShowValidation();
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
      /// Cambiar de estado la liquidación a estado 'A'
      /// </summary>
      /// <returns></returns>
      public Boolean Aprobar()
      {
         try
         {
            Item.SetEstado(Liquidacion.Estado.Cerrada);
            Item.AUDI_UsrMod = Session.UserName;
            Item.Instance = Infrastructure.Aspect.BusinessEntity.InstanceEntity.Modified;
            Entities.Liquidacion _item = Item;
            if (Client.SaveLiquidacion(ref _item, Liquidacion.TOperacion.Aprobar))
            {
               return true;
            }
            return false;
         }
         catch (Exception)
         { throw; }
      }

      /// <summary>
      /// Cargar uuna interfaz para poder realizar la conciliación utilizando un documento Excel, proporcionado por el sistema
      /// </summary>
      /// <returns></returns>
      public Boolean Conciliar(ref System.Windows.Forms.ProgressBar x_PBar)
      {
         try
         {
            DView = new CAJ006LiquidacionAgentesDViewConciliacion();
            DView.LoadView();
            DView.Presenter = this;
            (DView as CAJ006LiquidacionAgentesDViewConciliacion).StartPosition = FormStartPosition.CenterScreen;
            DTNoProcesados = null;
            if ((DView as CAJ006LiquidacionAgentesDViewConciliacion).ShowDialog() == DialogResult.OK)
            {
               ConciliacionProcesado = true;
               Boolean x_opcion = false;
               if (ProcesarConciliacion(DView.PathConciliacion, 2, ref x_PBar))
               {
                  x_opcion = true;
               }
               ImportarExcel excel = new ImportarExcel();
               excel.SetDataExcel(DTImportacion, DView.PathConciliacion, 2, new String[] { "OV", "Documento", "Observaciones" });
               return x_opcion;
            }
            return false;
         }
         catch (Exception)
         { throw; }
      }

      /// <summary>
      /// Realiza la operación de Conciliar, recibiendo el archivo a ser conciliado
      /// </summary>
      /// <param name="PathConciliacion">Ruta del archivo que utilizara para realizar la conciliaciónd agentes</param>
      /// <returns>true: si se proceso el archivo correctamente</returns>
      public Boolean ProcesarConciliacion(String PathConciliacion, Int32 x_Header, ref System.Windows.Forms.ProgressBar x_PBar)
      {
         try
         {
            String Archivo = "", MensajeConciliacion = "";
            if (System.IO.File.Exists(PathConciliacion))
            {
               Archivo = Path.GetFileName(PathConciliacion);
               ImportarExcel excel = new ImportarExcel();
               String _message = "";
               DTImportacion = excel.ReadExcel(PathConciliacion, 1, 5000, x_Header, new Int32[] { 6, 18 }, ref _message, ref x_PBar);
               DTNoProcesados = DTImportacion.Clone();
               MsgError = "";
                if (!DTImportacion.Columns.Contains("OV"))
                { DTImportacion.Columns.Add("OV", typeof(String)); }
                if (!DTImportacion.Columns.Contains("Documento"))
                { DTImportacion.Columns.Add("Documento", typeof(String)); }
                if (!DTImportacion.Columns.Contains("Observaciones"))
                { DTImportacion.Columns.Add("Observaciones", typeof(String)); }

               x_PBar.Maximum = x_PBar.Value + DTImportacion.Rows.Count;

               ObservableCollection<Entities.CtaCte> x_ListGroup = new ObservableCollection<CtaCte>();
               x_ListGroup = (from CCCT in Item.ListCtaCte
                              group CCCT by new { CCCT.OV_OP, CCCT.DOOV_HBL } into LCCCT
                              select new CtaCte
                              {
                                 CCCT_Pendiente = LCCCT.Sum(x => x.CCCT_Pendiente),
                                 OV_OP = LCCCT.Key.OV_OP,
                                 DOOV_HBL = LCCCT.Key.DOOV_HBL
                              }
                             ).ToObservableCollection();

               Boolean x_IsCorrecto = true;
               foreach (System.Data.DataRow item in DTImportacion.Rows)
               {
                  #region Validar Documento

                  String x_HBL = item[5].ToString().Trim();
                  String x_MontoString = item[17].ToString();
                  Decimal x_Monto = 0, Monto = 0;
                  if (Decimal.TryParse(x_MontoString, out x_Monto)) { Monto = Math.Abs(x_Monto); }

                  /* Filtrar todos los documentos que coinciden (tipos, serie y numero de documento */
                  ObservableCollection<Entities.CtaCte> x_listCtaCte = x_ListGroup.Where(Cta => Cta.DOOV_HBL.Equals(x_HBL) &&
                                                                                                (Cta.CCCT_Pendiente.HasValue ? Math.Abs(Cta.CCCT_Pendiente.Value) : 0) == Monto).ToObservableCollection();

                  if (x_listCtaCte != null && x_listCtaCte.Count > 0)
                  {
                     ObservableCollection<Entities.CtaCte> x_listCtaCteCMP = Item.ListCtaCte.Where(Cta => Cta.OV_OP.Equals(x_listCtaCte[0].OV_OP)).ToObservableCollection();
                     x_listCtaCte[0].ConciliadoAgente = true;

                     item["OV"] = x_listCtaCte[0].OV_OP;
                     if (x_listCtaCteCMP != null && x_listCtaCteCMP.Count > 0)
                     {
                        foreach (CtaCte iCtaCte in x_listCtaCteCMP)
                        {
                           iCtaCte.Seleccionar = true;
                           item["Documento"] += String.Format("{0} {1}-{2} {3}", iCtaCte.TIPO_TDO, iCtaCte.CCCT_Serie, iCtaCte.CCCT_Numero, x_listCtaCteCMP.Count > 1 ? "/" : "");
                           item["Observaciones"] += String.IsNullOrEmpty(iCtaCte.ObservacionesConciliacion) ? "-" : iCtaCte.ObservacionesConciliacion + (x_listCtaCteCMP.Count > 1 ? "/" : "");
                        }
                     }
                  }
                  else { DTNoProcesados.ImportRow(item); x_IsCorrecto = false; }

                  #endregion
                  x_PBar.Value++;
               }
               return !(MsgError.Length > 0) && x_IsCorrecto;
            }
            else { throw new Exception("El archivo no existe"); }
            return false;
         }
         catch (Exception)
         { throw; }
      }



      /// <summary>
      /// Cambiar el estado de la liquidación, a estado anulado = 'X'
      /// </summary>
      /// <returns></returns>
      public Boolean Anular()
      {
         try
         {
            Item.SetEstado(Liquidacion.Estado.Anulada);
            Item.AUDI_UsrMod = Session.UserName;
            Item.Instance = Infrastructure.Aspect.BusinessEntity.InstanceEntity.Modified;
            Entities.Liquidacion _item = Item;
            if (Client.SaveLiquidacion(ref _item, Liquidacion.TOperacion.Anular))
            {
               return true;
            }
            return false;
         }
         catch (Exception)
         { throw; }
      }

      /// <summary>
      /// Cargar la ayuda de liquidaciones
      /// </summary>
      /// <param name="LIQU_Codigo"></param>
      /// <param name="x_IncluirPendientes"></param>
      public void AyudaLiquidacion(String LIQU_Codigo, Boolean x_IncluirPendientes)
      {
         try
         {
            System.Data.DataTable dtAyuda = new System.Data.DataTable();
            ObservableCollection<Infrastructure.Aspect.DataAccess.DataAccessFilterSQL> _listFilters = new ObservableCollection<Infrastructure.Aspect.DataAccess.DataAccessFilterSQL>();
            _listFilters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@psinEMPR_Codigo", FilterValue = Controls.Entorno.ItemEmpresa.EMPR_Codigo, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.Int16, FilterSize = 2 });
            _listFilters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@pvchLIQU_Codigo", FilterValue = LIQU_Codigo, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.Varchar, FilterSize = 20 });

            dtAyuda = Client.GetDTLiquidacion("CAJ_LIQUSS_TodosAyuda", _listFilters);
            if (dtAyuda.Rows.Count == 0)
            { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Title, "No se encontraron coincidencias."); }
            else if (dtAyuda.Rows.Count == 1)
            {
               LIQU_Codigo = dtAyuda.Rows[0]["LIQU_Codigo"].ToString();
               Item = Client.GetOneLiquidacion(Controls.Entorno.ItemEmpresa.EMPR_Codigo, LIQU_Codigo);
               LView.SetItem(CAJ006LiquidacionAgentesPresenter.TBusqueda.Apertura);
            }
            else
            {
               int i = 0;
               List<Infrastructure.WinForms.Controls.ColumnaAyuda> _columnas = new List<Infrastructure.WinForms.Controls.ColumnaAyuda>();
               _columnas.Add(new Infrastructure.WinForms.Controls.ColumnaAyuda()
               {
                  Index = i++,
                  ColumnName = "LIQU_Codigo",
                  ColumnCaption = "Código",
                  Alineacion = DataGridViewContentAlignment.MiddleCenter,
                  Width = 80,
                  DataType = typeof(System.String),
                  Format = null
               });
               _columnas.Add(new Infrastructure.WinForms.Controls.ColumnaAyuda()
               {
                  Index = i++,
                  ColumnName = "LIQU_Fecha",
                  ColumnCaption = "Fecha",
                  Alineacion = DataGridViewContentAlignment.MiddleRight,
                  Width = 80,
                  DataType = typeof(System.String),
                  Format = "dd/MM/yyyy"
               });

               _columnas.Add(new Infrastructure.WinForms.Controls.ColumnaAyuda()
               {
                  Index = i++,
                  ColumnName = "ENTC_DocIden",
                  ColumnCaption = "R.U.C.",
                  Alineacion = DataGridViewContentAlignment.MiddleLeft,
                  Width = 80,
                  DataType = typeof(System.String),
                  Format = null
               });

               _columnas.Add(new Infrastructure.WinForms.Controls.ColumnaAyuda()
               {
                  Index = i++,
                  ColumnName = "ENTC_RazonSocial",
                  ColumnCaption = "Razon Social",
                  Alineacion = DataGridViewContentAlignment.MiddleLeft,
                  Width = 200,
                  DataType = typeof(System.String),
                  Format = null
               });

               _columnas.Add(new Infrastructure.WinForms.Controls.ColumnaAyuda()
               {
                  Index = i++,
                  ColumnName = "LIQU_Estado_Text",
                  ColumnCaption = "Estado",
                  Alineacion = DataGridViewContentAlignment.MiddleLeft,
                  Width = 100,
                  DataType = typeof(System.String),
                  Format = null
               });

               Infrastructure.WinForms.Controls.Ayuda x_Ayuda = new Infrastructure.WinForms.Controls.Ayuda("Ayuda - Liquidaciones ", dtAyuda, false, _columnas);
               x_Ayuda.Width = x_Ayuda.Width + 150;

               if (x_Ayuda.ShowDialog() == System.Windows.Forms.DialogResult.OK)
               {
                  LIQU_Codigo = x_Ayuda.Respuesta.Rows[0]["LIQU_Codigo"].ToString();
                  Item = Client.GetOneLiquidacion(Controls.Entorno.ItemEmpresa.EMPR_Codigo, LIQU_Codigo);
                  LView.SetItem(CAJ006LiquidacionAgentesPresenter.TBusqueda.Apertura);
               }
               else { }
            }
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Title, "Ha ocurrido un error al utilizar la ayuda de Liquidaciones.", ex); }
      }

      public System.Windows.Forms.DialogResult GuardarCambios(Boolean EsProspecto)
      {
         try
         {
            if (this.Item != null)
            {

               //((CAJ006LiquidacionAgentesMView)MView).BringToFront();
               //System.Windows.Forms.DialogResult _result = Infrastructure.WinForms.Controls.Dialogos.MostrarMensajePregunta(Title, Infrastructure.Aspect.Constants.Mensajes.SaveChangesPreguntaPresenter, Infrastructure.WinForms.Controls.Dialogos.LabelBoton.Si_No);
               //if (_result == System.Windows.Forms.DialogResult.Yes)
               //{
               //   if (Guardar(EsProspecto, true))
               //   { return System.Windows.Forms.DialogResult.Yes; }
               //   else
               //   { return System.Windows.Forms.DialogResult.Cancel; }
               //}
               //else
               //{ return _result; }
               return System.Windows.Forms.DialogResult.Cancel;
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
         //if (isMViewShow)
         //{ ((CAJ006LiquidacionAgentesMView)MView).Close(); }
      }

      public void IsClosedMView()
      { isMViewShow = false; }


      #endregion

      #region [ Metodos Eventos/Tareas ]

      /// <summary>
      /// Imprimir el listado de documentos de una liquidación
      /// </summary>
      public void Imprimir()
      {
         try
         {

            if (Item.ListCtaCte.Count > 0)
            {
               Liquidar();
               System.Data.DataTable dtReporte = new System.Data.DataTable();
               System.Data.DataTable dtReporteTotales = new System.Data.DataTable();
               dtReporte = Item.ListCtaCte.Where(O => O.Seleccionar).ToObservableCollection().ToDataTable();

               ObservableCollection<Entities.CtaCte> x_ListGroup = new ObservableCollection<CtaCte>();
               x_ListGroup = (from CCCT in Item.ListCtaCte.Where(O => O.Seleccionar).ToObservableCollection()
                              group CCCT by new { CCCT.TIPO_CodMND, CCCT.TIPO_MND } into LCCCT
                              select new CtaCte
                              {
                                 CCCT_Pendiente = LCCCT.Sum(x => x.CCCT_Pendiente),
                                 CCCT_Pendiente_Cargo = LCCCT.Sum(y => y.CCCT_Pendiente_Cargo),
                                 CCCT_Pendiente_Abono = LCCCT.Sum(z => z.CCCT_Pendiente_Abono),
                                 TIPO_CodMND = LCCCT.Key.TIPO_CodMND,
                                 TIPO_MND = LCCCT.Key.TIPO_MND
                              }
                             ).ToObservableCollection();
               dtReporteTotales = x_ListGroup.ToDataTable();


               R_Codigo = Item.LIQU_Codigo;
               R_FechaEmision = Item.LIQU_Fecha.Value.ToString("dd/MM/yyyy");
               R_Glosa = Item.LIQU_Glosa;

               if (dtReporte != null && dtReporte.Rows.Count > 0)
               {
                  String ReportPath = null;
                  dtReporte.TableName = "CtaCte";
                  ReportPath = Application.StartupPath + @"\Reportes\CAJ006LiquidacionAgentes.rdlc";
                  //ReportDataSource RepDetalle = new ReportDataSource("LiquidacionAgentesDS", dtReporte);

                  Microsoft.Reporting.WinForms.ReportDataSource rds = new Microsoft.Reporting.WinForms.ReportDataSource();
                  rds.Name = "LiquidacionAgentesDS";
                  rds.Value = dtReporte;

                  Microsoft.Reporting.WinForms.ReportDataSource rdsDet = new Microsoft.Reporting.WinForms.ReportDataSource();
                  rdsDet.Name = "DSTotales";
                  rdsDet.Value = dtReporteTotales;

                  Dictionary<String, Microsoft.Reporting.WinForms.ReportDataSource> x_subreports = new Dictionary<string, Microsoft.Reporting.WinForms.ReportDataSource>();
                  x_subreports.Add("CAJ006LiquidacionAgentesTotal", rdsDet);

                  Microsoft.Reporting.WinForms.ReportParameter[] Parameters = new Microsoft.Reporting.WinForms.ReportParameter[7];
                  Fecha = Client.GetFecha();
                  String _fecha = Fecha.ToString("dd/MM/yyyy HH:mm");
                  String _agente = F_ENTC_Codigo.ToString();
                  Parameters[0] = new Microsoft.Reporting.WinForms.ReportParameter("Titulo", "Reporte de " + Title);
                  Parameters[1] = new Microsoft.Reporting.WinForms.ReportParameter("FechaHora", _fecha);
                  Parameters[2] = new Microsoft.Reporting.WinForms.ReportParameter("Agente", R_Agente);
                  Parameters[3] = new Microsoft.Reporting.WinForms.ReportParameter("Codigo", R_Codigo);
                  Parameters[4] = new Microsoft.Reporting.WinForms.ReportParameter("Glosa", R_Glosa);
                  Parameters[5] = new Microsoft.Reporting.WinForms.ReportParameter("FechaEmision", R_FechaEmision);
                  Parameters[6] = new Microsoft.Reporting.WinForms.ReportParameter("Estado", R_Estado);

                  //Visualizador rpt = new Visualizador("Reporte de Liquidación de Agentes", ReportPath, RepDetalle, Parameters);
                  //rpt.StartPosition = FormStartPosition.CenterScreen;
                  //rpt.Imprimir();
                  //rpt.ShowDialog();
                  Visualizador _impresion = new Visualizador("", ReportPath, rds, Parameters, x_subreports, null) { StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen };
                  _impresion.Imprimir();
                  _impresion.ShowDialog();
               }
               else { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Title, "No se encontraron registros"); }
            }



         }
         catch (Exception)
         { throw; }
      }
      #endregion
   }
}