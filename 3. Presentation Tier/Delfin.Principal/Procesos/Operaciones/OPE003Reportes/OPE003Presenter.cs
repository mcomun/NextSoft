using System;
using System.Collections.Generic;
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
using XLExcel = Microsoft.Office.Interop.Excel;
using Microsoft.Office.Tools.Excel;
using System.Globalization;

namespace Delfin.Principal
{
   public partial class OPE003Presenter
   {
      #region [ Variables ]
      public String Title = "Reportes Gerencia";
      public String CUS = "OPE003";
      #endregion

      #region [ Contrusctor ]
      public OPE003Presenter(IUnityContainer x_container, IOPE003View x_mview, String x_CONS_CodRGM)
      {
         try
         {
            this.ContainerService = x_container;
            Session = this.ContainerService.Resolve<ISessionService>();

            CONS_CodRGM = x_CONS_CodRGM;

            this.MView = x_mview;

         }
         catch (Exception)
         {
            throw;
         }
      }
      public void Load()
      {
         try
         {
            Client = ContainerService.Resolve<IDelfinServices>();

            LoadParameteres();
            Int32 _ENTC_CodEmpresa;
            if (PARA_CODIGOEMPRESA != null && !String.IsNullOrEmpty(PARA_CODIGOEMPRESA.PARA_Valor) && Int32.TryParse(PARA_CODIGOEMPRESA.PARA_Valor, out _ENTC_CodEmpresa))
            {
               ItemEmpresa = new Entidad();
               ItemEmpresa = Client.GetOneEntidad(_ENTC_CodEmpresa);
            }
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
      public IOPE003View MView { get; set; }

      public Entidad ItemEmpresa { get; set; }

      public String CONS_CodRGM { get; set; }
      #endregion

      #region [ Parámetros ]
      public Entities.Parametros PARA_CODIGOEMPRESA { get; set; }
      public Entities.Parametros PARA_EAGENTE_SHANGHAI { get; set; }
      public Entities.Parametros PARA_PAIS_MANDATO { get; set; }

      private void LoadParameteres()
      {
         try
         {
            var ItemsPARAMETRO = Client.GetAllParametros();

            PARA_CODIGOEMPRESA = ItemsPARAMETRO.FirstOrDefault(para => para.PARA_Clave == "EMPRESA");
            PARA_EAGENTE_SHANGHAI = ItemsPARAMETRO.FirstOrDefault(para => para.PARA_Clave == "EAGENTE_SHANGHAI");
            PARA_PAIS_MANDATO = ItemsPARAMETRO.FirstOrDefault(para => para.PARA_Clave == "PAIS_MANDATO");
         }
         catch (Exception)
         { }
      }
      #endregion

      #region [ Metodos ]
      //public void Cargar(Int32 Reporte, Int32 Anio)
      //{
      //   try
      //   {
      //      String REPO_StoredProcedure = "";
      //      String REPO_Titulo = "";
      //      String REPO_SubTitulo = "";
      //      switch (Reporte)
      //      {
      //         case 1: //EXPO FCL
      //            REPO_StoredProcedure = "OPE_REPOSS_EXPOFCL";
      //            REPO_Titulo = "EXPORTACIONES FCL";
      //            REPO_SubTitulo = "TOTAL EMBARCADO ENERO - DICIEMBRE";
      //            break;
      //         case 2: //EXPO LCL
      //            REPO_StoredProcedure = "OPE_REPOSS_EXPOLCL";
      //            REPO_Titulo = "EXPORTACIONES LCL";
      //            REPO_SubTitulo = "TOTAL EMBARCADO ENERO - DICIEMBRE";
      //            break;
      //         case 3: //IMPO FCL
      //            REPO_StoredProcedure = "OPE_REPOSS_IMPOFCL";
      //            REPO_Titulo = "IMPORTACIONES FCL";
      //            REPO_SubTitulo = "TOTAL EMBARCADO ENERO - DICIEMBRE";
      //            break;
      //         case 4: //IMPO LCL
      //            REPO_StoredProcedure = "OPE_REPOSS_IMPOLCL";
      //            REPO_Titulo = "IMPORTACIONES LCL";
      //            REPO_SubTitulo = "TOTAL EMBARCADO ENERO - DICIEMBRE";
      //            break;
      //         case 5: //TRANSMISIONES
      //            REPO_StoredProcedure = "OPE_REPOSS_TRANSMISIONES";
      //            REPO_Titulo = "TRANSMISIONES";
      //            REPO_SubTitulo = "TOTAL EMBARCADO ENERO - DICIEMBRE";
      //            break;
      //      }
      //      Int16 EMPR_Codigo = Delfin.Controls.Entorno.ItemEmpresa.EMPR_Codigo;
      //      Int16 SUCR_Codigo = Delfin.Controls.Entorno.ItemSucursal.SUCR_Codigo;

      //      DateTime REPO_FechaInicio = Convert.ToDateTime("01/01/" + Anio.ToString());
      //      DateTime REPO_FechaTermino = Convert.ToDateTime("31/12/" + Anio.ToString());

      //      var _itemTipoCambio = Client.GetOneTiposCambio(Session.Fecha.ToString("yyyyMMdd"));
      //      if (_itemTipoCambio != null)
      //      {
      //         System.Data.DataSet dsStatment = Client.OPE_GetCab_Cotizacion_OVReporteGerencia(REPO_StoredProcedure, EMPR_Codigo, SUCR_Codigo, REPO_FechaInicio, REPO_FechaTermino, _itemTipoCambio.TIPC_Venta);

      //         if (dsStatment != null && dsStatment.Tables.Count >= 3 && dsStatment.Tables[0].Rows.Count > 0)
      //         {

      //            Exportar(ItemEmpresa.ENTC_RazonSocial, Anio, REPO_Titulo, REPO_SubTitulo, dsStatment.Tables[0], dsStatment.Tables[1], dsStatment.Tables[2]);
      //         }
      //         else
      //         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Title, "No se encontraron registros."); }
      //      }
      //      else
      //      { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Title, "Debe ingresar el Tipo de Cambio para la fecha " + Session.Fecha.ToShortDateString()); }
      //   }
      //   catch (Exception ex)
      //   { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Title, Infrastructure.Aspect.Constants.Mensajes.NewPresenter, ex); }
      //}
      public void Cargar(ObservableCollection<Infrastructure.Aspect.DataAccess.DataAccessFilterSQL> x_filters, DateTime _REPO_FechaInicio, DateTime _REPO_FechaFin, Boolean MostrarRebate, Boolean ServicioTransmision, Int32? CCOT_CodFLE)
      {
         try
         {
            String REPO_StoredProcedure = "OPE_REPOSS_GERENCIA";
            String REPO_Titulo = "";
            String REPO_Nombre = (CONS_CodRGM == "001" ? "IMPO" : "EXPO");
            String REPO_SubTitulo = "";

            if (ServicioTransmision)
            {
               REPO_Nombre = "SERVICIO DE TRANSMISIONES";
               REPO_Titulo = "SERVICIO DE TRANSMISIONES";
               REPO_SubTitulo = (CONS_CodRGM == "001" ? "Total descargado" : "Total embarcado");
            }
            else
            {
               if (CCOT_CodFLE.HasValue)
               {
                  if (CCOT_CodFLE == 1)
                  {
                     REPO_Titulo = (CONS_CodRGM == "001" ? "IMPORTACIONES" : "EXPORTACIONES") + " FCL";
                     REPO_SubTitulo = (CONS_CodRGM == "001" ? "Total descargado" : "Total embarcado");
                  }
                  else if (CCOT_CodFLE == 2)
                  {
                     REPO_Titulo = (CONS_CodRGM == "001" ? "IMPORTACIONES" : "EXPORTACIONES") + " LCL";
                     //REPO_SubTitulo = "Total embarcado";
                     REPO_SubTitulo = (CONS_CodRGM == "001" ? "Total descargado" : "Total embarcado");
                  }
               }
            }


            //switch (Reporte)
            //{
            //   case 1: //EXPO FCL
            //      REPO_StoredProcedure = "OPE_REPOSS_EXPOFCL";
            //      REPO_Titulo = "EXPORTACIONES FCL";
            //      REPO_SubTitulo = "TOTAL EMBARCADO ENERO - DICIEMBRE";
            //      break;
            //   case 2: //EXPO LCL
            //      REPO_StoredProcedure = "OPE_REPOSS_EXPOLCL";
            //      REPO_Titulo = "EXPORTACIONES LCL";
            //      REPO_SubTitulo = "TOTAL EMBARCADO ENERO - DICIEMBRE";
            //      break;
            //   case 3: //IMPO FCL
            //      REPO_StoredProcedure = "OPE_REPOSS_IMPOFCL";
            //      REPO_Titulo = "IMPORTACIONES FCL";
            //      REPO_SubTitulo = "TOTAL EMBARCADO ENERO - DICIEMBRE";
            //      break;
            //   case 4: //IMPO LCL
            //      REPO_StoredProcedure = "OPE_REPOSS_IMPOLCL";
            //      REPO_Titulo = "IMPORTACIONES LCL";
            //      REPO_SubTitulo = "TOTAL EMBARCADO ENERO - DICIEMBRE";
            //      break;
            //   case 5: //TRANSMISIONES
            //      REPO_StoredProcedure = "OPE_REPOSS_TRANSMISIONES";
            //      REPO_Titulo = "TRANSMISIONES";
            //      REPO_SubTitulo = "TOTAL EMBARCADO ENERO - DICIEMBRE";
            //      break;
            //}
            //Int16 EMPR_Codigo = Delfin.Controls.Entorno.ItemEmpresa.EMPR_Codigo;
            //Int16 SUCR_Codigo = Delfin.Controls.Entorno.ItemSucursal.SUCR_Codigo;

            //DateTime REPO_FechaInicio = Convert.ToDateTime("01/01/" + Anio.ToString());
            //DateTime REPO_FechaTermino = Convert.ToDateTime("31/12/" + Anio.ToString());

            var _itemTipoCambio = Client.GetOneTiposCambio(Session.Fecha.ToString("yyyyMMdd"));
            if (_itemTipoCambio != null)
            {
               x_filters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@pdecCCCT_TipoCambio", FilterValue = _itemTipoCambio.TIPC_Venta, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.Decimal, FilterSize = 15 });

               System.Data.DataSet dsStatment = Client.OPE_GetCab_Cotizacion_OVReporteGerencia(REPO_StoredProcedure, x_filters);

               if (dsStatment != null && dsStatment.Tables.Count >= 3 && dsStatment.Tables[0].Rows.Count > 0)
               {
                  dsStatment.Tables[0].DefaultView.RowFilter = "[ORDEN VENTA] IS NOT NULL";
                  //dsStatment.Tables[0] = dsStatment.Tables[0].DefaultView.ToTable();
                  Exportar(ItemEmpresa.ENTC_RazonSocial, _REPO_FechaInicio.Year, REPO_Titulo, REPO_SubTitulo, REPO_Nombre, dsStatment.Tables[0].DefaultView.ToTable(), dsStatment.Tables[1], dsStatment.Tables[2], _REPO_FechaInicio, _REPO_FechaFin, CCOT_CodFLE, MostrarRebate, ServicioTransmision);
                  //Exportar(ItemEmpresa.ENTC_RazonSocial, _REPO_FechaFin.Year, REPO_Titulo, REPO_SubTitulo, REPO_Nombre, dsStatment.Tables[0].DefaultView.ToTable(), dsStatment.Tables[1], dsStatment.Tables[2], _REPO_FechaInicio, _REPO_FechaFin, MostrarRebate);
               }
               else if (ServicioTransmision && dsStatment != null && dsStatment.Tables.Count > 0 && dsStatment.Tables[0].Rows.Count > 0)
               {
                  dsStatment.Tables[0].DefaultView.RowFilter = "[ORDEN VENTA] IS NOT NULL";
                  Exportar(ItemEmpresa.ENTC_RazonSocial, _REPO_FechaInicio.Year, REPO_Titulo, REPO_SubTitulo, REPO_Nombre, dsStatment.Tables[0].DefaultView.ToTable(), null, null, _REPO_FechaInicio, _REPO_FechaFin, CCOT_CodFLE, MostrarRebate, ServicioTransmision);
               }
               else
               { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Title, "No se encontraron registros."); }
            }
            else
            { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Title, "Debe ingresar el Tipo de Cambio para la fecha " + Session.Fecha.ToShortDateString()); }
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Title, Infrastructure.Aspect.Constants.Mensajes.NewPresenter, ex); }
      }
      #endregion

      #region [ Exportacion Excel ]
      private const String xlFont = "Calibri";
      private const Int32 xlFontSize = 11;

      private void Exportar(String Empresa, Int32 Anio, String Titulo, String SubTitulo, String Nombre, System.Data.DataTable Reporte, System.Data.DataTable Comparacion1, System.Data.DataTable Comparacion2, DateTime x_Desde, DateTime x_Hasta, Int32? x_CCOT_CodFLE, Boolean MostrarRebate = false, Boolean EsServicioTransmision = false)
      {
         XLExcel.Application xlApplication;
         XLExcel.Workbook xlWorkbook;

         XLExcel.Worksheet xlWorksheetData;
         XLExcel.Worksheet xlWorksheetPivot;
         XLExcel.Worksheet xlWorksheetComparacion = null;
         XLExcel.Worksheet xlWorksheetPivotRebate = null;

         XLExcel.Worksheet xlWorksheetPivotFFVV = null;
         XLExcel.Worksheet xlWorksheetPivotFFVVServicios = null;


         XLExcel.Range xlRange;
         XLExcel.Range xlRangeComparacion;

         object misValue = System.Reflection.Missing.Value;
         xlApplication = new XLExcel.Application();

         Int32 _WorksheetsIndex = 1;

         xlWorkbook = xlApplication.Workbooks.Add(misValue);
         xlWorksheetData = (XLExcel.Worksheet)xlWorkbook.Worksheets[_WorksheetsIndex];
         xlWorksheetData.Name = "BD";

         _WorksheetsIndex += 1;

         if (xlWorkbook.Worksheets.Count < _WorksheetsIndex)
         { xlWorkbook.Worksheets.Add(misValue, xlWorksheetData, misValue, misValue); }
         xlWorksheetPivot = (XLExcel.Worksheet)xlWorkbook.Worksheets[_WorksheetsIndex];
         xlWorksheetPivot.Name = (EsServicioTransmision ? "SERVICIO TRANSMISIONES" : ("TOTAL " + Nombre + (MostrarRebate ? " SIN REBATE" : "")));

         if (!EsServicioTransmision)
         {
            if (MostrarRebate)
            {
               _WorksheetsIndex += 1;

               if (xlWorkbook.Worksheets.Count < _WorksheetsIndex)
               { xlWorkbook.Worksheets.Add(misValue, xlWorksheetPivot, misValue, misValue); }
               xlWorksheetPivotRebate = (XLExcel.Worksheet)xlWorkbook.Worksheets[_WorksheetsIndex];
               xlWorksheetPivotRebate.Name = "TOTAL " + Nombre + " CON REBATE";

            }

            _WorksheetsIndex += 1;

            if (xlWorkbook.Worksheets.Count < _WorksheetsIndex)
            { xlWorkbook.Worksheets.Add(misValue, xlWorksheetPivot, misValue, misValue); }
            xlWorksheetPivotFFVV = (XLExcel.Worksheet)xlWorkbook.Worksheets[_WorksheetsIndex];
            xlWorksheetPivotFFVV.Name = "FUERZA VENTAS";

            _WorksheetsIndex += 1;

            if (xlWorkbook.Worksheets.Count < _WorksheetsIndex)
            { xlWorkbook.Worksheets.Add(misValue, xlWorksheetPivot, misValue, misValue); }
            xlWorksheetPivotFFVVServicios = (XLExcel.Worksheet)xlWorkbook.Worksheets[_WorksheetsIndex];
            xlWorksheetPivotFFVVServicios.Name = "FFVV POR SERVICIOS";


            _WorksheetsIndex += 1;

            if (xlWorkbook.Worksheets.Count < _WorksheetsIndex)
            { xlWorkbook.Worksheets.Add(misValue, xlWorksheetPivot, misValue, misValue); }
            xlWorksheetComparacion = (XLExcel.Worksheet)xlWorkbook.Worksheets[_WorksheetsIndex];
            xlWorksheetComparacion.Name = "COMPARATIVO";
         }

         try
         {
            String fuente = "Calibri";
            int fontsize = 11;
            int _sheetIndex = 1;

            Int32 rowIndex = 0;
            Int32 colIndex = 0;

            #region [ Statment ]
            xlWorksheetData.Activate();

            //HEADER
            var _columns = new Object[1, Reporte.Columns.Count];
            foreach (System.Data.DataColumn _column in Reporte.Columns)
            { _columns[rowIndex, colIndex] = _column.ColumnName; colIndex += 1; }
            xlRange = xlWorksheetData.Range[xlWorksheetData.Cells[1, 1], xlWorksheetData.Cells[1, Reporte.Columns.Count]];
            xlRange.Value2 = _columns;

            rowIndex = 0;
            colIndex = 0;

            //CELLS
            var _data = new Object[Reporte.Rows.Count, Reporte.Columns.Count];
            foreach (System.Data.DataRow _row in Reporte.Rows)
            {
               colIndex = 0;
               foreach (System.Data.DataColumn _column in Reporte.Columns)
               {
                  _data[rowIndex, colIndex] = _row[_column.ColumnName];
                  colIndex += 1;
               }
               rowIndex += 1;
            }

            xlRange = xlWorksheetData.Range[xlWorksheetData.Cells[2, 1], xlWorksheetData.Cells[Reporte.Rows.Count + 1, Reporte.Columns.Count]];
            xlRange.Value2 = _data;
            #endregion

            if (!EsServicioTransmision)
            {
               #region [ Comparacion ]
               xlWorksheetComparacion = (XLExcel.Worksheet)xlWorkbook.Worksheets[(MostrarRebate ? 6 : 5)];
               xlWorksheetComparacion.Name = "COMPARATIVO";

               xlWorksheetComparacion.Activate();

               rowIndex = 0;
               colIndex = 0;

               //HEADER
               _columns = new Object[1, Comparacion1.Columns.Count];
               foreach (System.Data.DataColumn _column in Comparacion1.Columns)
               { _columns[rowIndex, colIndex] = _column.ColumnName; colIndex += 1; }
               xlRangeComparacion = xlWorksheetComparacion.Range[xlWorksheetComparacion.Cells[7, 1], xlWorksheetComparacion.Cells[7, 14]];
               xlRangeComparacion.Value2 = _columns;

               rowIndex = 0;
               colIndex = 0;

               //CELLS
               _data = new Object[Comparacion1.Rows.Count, Comparacion1.Columns.Count];
               foreach (System.Data.DataRow _row in Comparacion1.Rows)
               {
                  colIndex = 0;
                  foreach (System.Data.DataColumn _column in Comparacion1.Columns)
                  { _data[rowIndex, colIndex] = _row[_column.ColumnName]; colIndex += 1; }
                  rowIndex += 1;
               }

               xlRangeComparacion = xlWorksheetComparacion.Range[xlWorksheetComparacion.Cells[8, 1], xlWorksheetComparacion.Cells[(x_CCOT_CodFLE == 1 ? 11 : 10), 14]];
               xlRangeComparacion.Value2 = _data;

               xlRangeComparacion = xlWorksheetComparacion.Range[xlWorksheetComparacion.Cells[7, 1], xlWorksheetComparacion.Cells[7, 1]];
               xlRangeComparacion.Value = (Anio - 1).ToString();

               xlRangeComparacion = xlWorksheetComparacion.Range[xlWorksheetComparacion.Cells[7, 1], xlWorksheetComparacion.Cells[(x_CCOT_CodFLE == 1 ? 11 : 10), 14]];
               setBorderCelda(xlRangeComparacion, XLExcel.XlBorderWeight.xlThin, XLExcel.XlLineStyle.xlContinuous, true, true, true, true, true, true, true, false, false);

               xlRangeComparacion = xlWorksheetComparacion.Range[xlWorksheetComparacion.Cells[7, 1], xlWorksheetComparacion.Cells[7, 14]];
               xlRangeComparacion.Interior.Pattern = XLExcel.XlPattern.xlPatternSolid;
               xlRangeComparacion.Interior.PatternColorIndex = XLExcel.XlPattern.xlPatternAutomatic;
               xlRangeComparacion.Interior.ThemeColor = XLExcel.XlThemeColor.xlThemeColorAccent2;
               xlRangeComparacion.Interior.TintAndShade = 0;
               xlRangeComparacion.Interior.PatternTintAndShade = 0;
               xlRangeComparacion.Font.ThemeColor = XLExcel.XlThemeColor.xlThemeColorDark1;
               xlRangeComparacion.Font.TintAndShade = 0;

               xlRangeComparacion = xlWorksheetComparacion.Range[xlWorksheetComparacion.Cells[7, 1], xlWorksheetComparacion.Cells[(x_CCOT_CodFLE == 1 ? 11 : 10), 1]];
               xlRangeComparacion.Interior.Pattern = XLExcel.XlPattern.xlPatternSolid;
               xlRangeComparacion.Interior.PatternColorIndex = XLExcel.XlPattern.xlPatternAutomatic;
               xlRangeComparacion.Interior.ThemeColor = XLExcel.XlThemeColor.xlThemeColorAccent2;
               xlRangeComparacion.Interior.TintAndShade = 0;
               xlRangeComparacion.Interior.PatternTintAndShade = 0;
               xlRangeComparacion.Font.ThemeColor = XLExcel.XlThemeColor.xlThemeColorDark1;
               xlRangeComparacion.Font.TintAndShade = 0;


               rowIndex = 0;
               colIndex = 0;

               //HEADER
               _columns = new Object[1, Comparacion2.Columns.Count];
               foreach (System.Data.DataColumn _column in Comparacion2.Columns)
               { _columns[rowIndex, colIndex] = _column.ColumnName; colIndex += 1; }

               xlRangeComparacion = xlWorksheetComparacion.Range[xlWorksheetComparacion.Cells[13, 1], xlWorksheetComparacion.Cells[13, Comparacion2.Columns.Count]];
               xlRangeComparacion.Value2 = _columns;

               rowIndex = 0;
               colIndex = 0;

               //CELLS
               _data = new Object[Comparacion2.Rows.Count, Comparacion2.Columns.Count];
               foreach (System.Data.DataRow _row in Comparacion2.Rows)
               {
                  colIndex = 0;
                  foreach (System.Data.DataColumn _column in Comparacion2.Columns)
                  { _data[rowIndex, colIndex] = _row[_column.ColumnName]; colIndex += 1; }
                  rowIndex += 1;
               }

               xlRangeComparacion = xlWorksheetComparacion.Range[xlWorksheetComparacion.Cells[14, 1], xlWorksheetComparacion.Cells[(x_CCOT_CodFLE == 1 ? 17 : 16), Comparacion2.Columns.Count]];
               xlRangeComparacion.Value2 = _data;

               xlRangeComparacion = xlWorksheetComparacion.Range[xlWorksheetComparacion.Cells[13, 1], xlWorksheetComparacion.Cells[13, 1]];
               xlRangeComparacion.Value = Anio.ToString();

               xlRangeComparacion = xlWorksheetComparacion.Range[xlWorksheetComparacion.Cells[13, 1], xlWorksheetComparacion.Cells[(x_CCOT_CodFLE == 1 ? 17 : 16), 14]];
               setBorderCelda(xlRangeComparacion, XLExcel.XlBorderWeight.xlThin, XLExcel.XlLineStyle.xlContinuous, true, true, true, true, true, true, true, false, false);

               xlRangeComparacion = xlWorksheetComparacion.Range[xlWorksheetComparacion.Cells[13, 1], xlWorksheetComparacion.Cells[13, 14]];
               xlRangeComparacion.Interior.Pattern = XLExcel.XlPattern.xlPatternSolid;
               xlRangeComparacion.Interior.PatternColorIndex = XLExcel.XlPattern.xlPatternAutomatic;
               xlRangeComparacion.Interior.ThemeColor = XLExcel.XlThemeColor.xlThemeColorAccent2;
               xlRangeComparacion.Interior.TintAndShade = 0;
               xlRangeComparacion.Interior.PatternTintAndShade = 0;
               xlRangeComparacion.Font.ThemeColor = XLExcel.XlThemeColor.xlThemeColorDark1;
               xlRangeComparacion.Font.TintAndShade = 0;

               xlRangeComparacion = xlWorksheetComparacion.Range[xlWorksheetComparacion.Cells[13, 1], xlWorksheetComparacion.Cells[(x_CCOT_CodFLE == 1 ? 17 : 16), 1]];
               xlRangeComparacion.Interior.Pattern = XLExcel.XlPattern.xlPatternSolid;
               xlRangeComparacion.Interior.PatternColorIndex = XLExcel.XlPattern.xlPatternAutomatic;
               xlRangeComparacion.Interior.ThemeColor = XLExcel.XlThemeColor.xlThemeColorAccent2;
               xlRangeComparacion.Interior.TintAndShade = 0;
               xlRangeComparacion.Interior.PatternTintAndShade = 0;
               xlRangeComparacion.Font.ThemeColor = XLExcel.XlThemeColor.xlThemeColorDark1;
               xlRangeComparacion.Font.TintAndShade = 0;

               XLExcel.Chart XLChart1 = (XLExcel.Chart)xlWorksheetComparacion.Shapes.AddChart(XLExcel.XlChartType.xl3DColumnClustered, 100, 300, 500, 300).Chart;

               (XLChart1.SeriesCollection() as XLExcel.SeriesCollection).NewSeries();
               (XLChart1.SeriesCollection(1) as XLExcel.Series).Name = "=COMPARATIVO!$A$7";
               (XLChart1.SeriesCollection(1) as XLExcel.Series).Values = "=COMPARATIVO!$B$" + (x_CCOT_CodFLE == 1 ? "9" : "8") + ":$M$" + (x_CCOT_CodFLE == 1 ? "9" : "8");
               (XLChart1.SeriesCollection(1) as XLExcel.Series).XValues = "=COMPARATIVO!$B$7:$M$7";

               (XLChart1.SeriesCollection() as XLExcel.SeriesCollection).NewSeries();
               (XLChart1.SeriesCollection(2) as XLExcel.Series).Name = "=COMPARATIVO!$A$13";
               (XLChart1.SeriesCollection(2) as XLExcel.Series).Values = "=COMPARATIVO!$B$" + (x_CCOT_CodFLE == 1 ? "15" : "14") + ":$M$" + (x_CCOT_CodFLE == 1 ? "15" : "14");
               (XLChart1.SeriesCollection(2) as XLExcel.Series).XValues = "=COMPARATIVO!$B$13:$M$13";

               //XLExcel.SeriesCollection XLSeriesCollection1 = XLChart1.SeriesCollection();

               //XLExcel.Series XLSerie1 = XLSeriesCollection1.NewSeries();
               //XLSerie1.Name = "=COMPARATIVO!$A$7";
               //XLSerie1.Values = "=COMPARATIVO!$B$8:$M$8";
               //XLSerie1.XValues = "=COMPARATIVO!$B$7:$M$7";

               //XLExcel.Series XLSerie2 = XLSeriesCollection1.NewSeries();
               //XLSerie2.Name = "=COMPARATIVO!$A$12";
               //XLSerie2.Values = "=COMPARATIVO!$B$13:$M$13";            
               //XLSerie2.XValues = "=COMPARATIVO!$B$7:$M$7";

               XLChart1.SetElement(Microsoft.Office.Core.MsoChartElementType.msoElementChartTitleAboveChart);
               switch (x_CCOT_CodFLE)
               {
                  case 1:
                     XLChart1.ChartTitle.Text = String.Format("COMPARATIVO {0} - TEUS {1} VS. {2} {3}", Titulo, (Anio - 1), Anio, (MostrarRebate ? " - CON REBATE" : ""));
                     break;
                  case 2:
                     //XLChart1.ChartTitle.Text = String.Format("COMPARATIVO {0} - " + (CONS_CodRGM == "001" ? "LCL" : "BB") + " {1} VS. {2}", Titulo, (Anio - 1), Anio);
                     XLChart1.ChartTitle.Text = String.Format("COMPARATIVO {0} - LCL {1} VS. {2} {3}", Titulo, (Anio - 1), Anio, (MostrarRebate ? " - CON REBATE" : ""));
                     break;
                  default:
                     XLChart1.ChartTitle.Text = String.Format("COMPARATIVO {0} {1} VS. {2} {3}", Titulo, (Anio - 1), Anio, (MostrarRebate ? " - CON REBATE" : ""));
                     break;
               }

               XLChart1.SetElement(Microsoft.Office.Core.MsoChartElementType.msoElementPrimaryValueAxisTitleAdjacentToAxis);
               XLExcel.Axis XlAxis1 = XLChart1.Axes(XLExcel.XlAxisType.xlValue, XLExcel.XlAxisGroup.xlPrimary) as XLExcel.Axis;
               XlAxis1.HasTitle = true;
               switch (x_CCOT_CodFLE)
               {
                  case 1:
                     XlAxis1.AxisTitle.Caption = "TEUS";
                     break;
                  case 2:
                     XlAxis1.AxisTitle.Caption = "LCL"; //(CONS_CodRGM == "001" ? "LCL" : "BB");
                     break;
                  default:
                     XlAxis1.AxisTitle.Caption = "TEUS";
                     break;
               }

               //XLChart1.Activate();
               XLChart1.Refresh();

               XLExcel.Chart XLChart2 = (XLExcel.Chart)xlWorksheetComparacion.Shapes.AddChart(XLExcel.XlChartType.xl3DColumnClustered, 100, 650, 500, 300).Chart;

               (XLChart2.SeriesCollection() as XLExcel.SeriesCollection).NewSeries();
               (XLChart2.SeriesCollection(1) as XLExcel.Series).Name = "=COMPARATIVO!$A$7";
               (XLChart2.SeriesCollection(1) as XLExcel.Series).Values = "=COMPARATIVO!$B$" + (x_CCOT_CodFLE == 1 ? "10" : "9") + ":$M$" + (x_CCOT_CodFLE == 1 ? "10" : "9");
               (XLChart2.SeriesCollection(1) as XLExcel.Series).XValues = "=COMPARATIVO!$B$7:$M$7";

               (XLChart2.SeriesCollection() as XLExcel.SeriesCollection).NewSeries();
               (XLChart2.SeriesCollection(2) as XLExcel.Series).Name = "=COMPARATIVO!$A$13";
               (XLChart2.SeriesCollection(2) as XLExcel.Series).Values = "=COMPARATIVO!$B$" + (x_CCOT_CodFLE == 1 ? "16" : "15") + ":$M$" + (x_CCOT_CodFLE == 1 ? "16" : "15");
               (XLChart2.SeriesCollection(2) as XLExcel.Series).XValues = "=COMPARATIVO!$B$13:$M$13";

               //XLExcel.SeriesCollection XLSeriesCollection2 = XLChart2.SeriesCollection();

               //XLExcel.Series XLSerie3 = XLSeriesCollection2.NewSeries();
               //XLSerie3.Name = "=COMPARATIVO!$A$7";
               //XLSerie3.Values = "=COMPARATIVO!$B$10:$M$10";
               //XLSerie3.XValues = "=COMPARATIVO!$B$7:$M$7";

               //XLExcel.Series XLSerie4 = XLSeriesCollection2.NewSeries();
               //XLSerie4.Name = "=COMPARATIVO!$A$13";
               //XLSerie4.Values = "=COMPARATIVO!$B$16:$M$16";
               //XLSerie4.XValues = "=COMPARATIVO!$B$13:$M$13";

               XLChart2.SetElement(Microsoft.Office.Core.MsoChartElementType.msoElementChartTitleAboveChart);
               XLChart2.ChartTitle.Text = String.Format("COMPARATIVO {0} - PROFIT {1} VS. {2}", Titulo, (Anio - 1), Anio);

               XLChart2.SetElement(Microsoft.Office.Core.MsoChartElementType.msoElementPrimaryValueAxisTitleAdjacentToAxis);
               XLExcel.Axis XlAxis2 = XLChart2.Axes(XLExcel.XlAxisType.xlValue, XLExcel.XlAxisGroup.xlPrimary) as XLExcel.Axis;
               XlAxis2.HasTitle = true;
               XlAxis2.AxisTitle.Caption = "PROFIT";


               //XLChart2.Activate();
               XLChart2.Refresh();

               //TITLE
               xlRangeComparacion = xlWorksheetComparacion.Range[xlWorksheetComparacion.Cells[2, 1], xlWorksheetComparacion.Cells[2, 14]];
               xlRangeComparacion.MergeCells = true;
               switch (x_CCOT_CodFLE)
               {
                  case 1:
                     xlRangeComparacion.Value = Titulo + " - COMPARATIVO TEUS Y PROFIT" + (MostrarRebate ? " CON REBATE" : "");
                     break;
                  case 2:
                     xlRangeComparacion.Value = Titulo + " - COMPARATIVO " + "LCL" + " Y PROFIT" + (MostrarRebate ? " CON REBATE" : ""); //(CONS_CodRGM == "001" ? "LCL" : "BB")
                     break;
                  default:
                     xlRangeComparacion.Value = Titulo + " - COMPARATIVO PROFIT" + (MostrarRebate ? " CON REBATE" : "");;
                     break;
               }

               xlRangeComparacion.Font.Bold = true;
               xlRangeComparacion.Font.Size = 16;
               xlRangeComparacion.VerticalAlignment = XLExcel.XlVAlign.xlVAlignCenter;
               xlRangeComparacion.HorizontalAlignment = XLExcel.XlHAlign.xlHAlignCenter;

               xlRangeComparacion = xlWorksheetComparacion.Range[xlWorksheetComparacion.Cells[3, 1], xlWorksheetComparacion.Cells[3, 14]];
               xlRangeComparacion.MergeCells = true;
               //xlRangeComparacion.Value = string.Format("{0} {1} - {2}  {3} VS. {4}", SubTitulo, MonthName(x_Desde.Month), MonthName(x_Hasta.Month), (Anio - 1), Anio); //SubTitulo + " - " + (Anio - 1).ToString() + " VS. " + Anio.ToString();
               xlRangeComparacion.Value = string.Format("{0} del {1} al {2}", SubTitulo, x_Desde.ToString("D", CultureInfo.CreateSpecificCulture("es-PE")), x_Hasta.ToString("D", CultureInfo.CreateSpecificCulture("es-PE"))) + " - " + (Anio - 1).ToString() + " VS. " + Anio.ToString(); ;//SubTitulo + " " + Anio.ToString();
               xlRangeComparacion.Font.Bold = true;
               xlRangeComparacion.Font.Size = 12;
               xlRangeComparacion.VerticalAlignment = XLExcel.XlVAlign.xlVAlignCenter;
               xlRangeComparacion.HorizontalAlignment = XLExcel.XlHAlign.xlHAlignCenter;

               #endregion


               #region [ TOTAL SIN REBATE ]
               xlWorksheetData.Activate();
               xlRange = xlWorksheetData.Range[xlWorksheetData.Cells[1, 1], xlWorksheetData.Cells[Reporte.Rows.Count + 1, Reporte.Columns.Count]];

               xlWorksheetPivot = (XLExcel.Worksheet)xlWorkbook.Worksheets[2];
               xlWorksheetPivot.Name = "TOTAL " + Nombre + (MostrarRebate ? " SIN REBATE" : "");
               xlWorksheetPivot.Activate();

               XLExcel.Range xlRangePivot;

               //TITLE
               xlRangePivot = xlWorksheetPivot.Range[xlWorksheetPivot.Cells[2, 1], xlWorksheetPivot.Cells[2, 14]];
               xlRangePivot.MergeCells = true;
               xlRangePivot.Value = Empresa + " - " + Titulo + (MostrarRebate ? " SIN REBATE" : "");
               xlRangePivot.Font.Bold = true;
               xlRangePivot.Font.Size = 16;
               xlRangePivot.VerticalAlignment = XLExcel.XlVAlign.xlVAlignCenter;
               xlRangePivot.HorizontalAlignment = XLExcel.XlHAlign.xlHAlignCenter;

               xlRangePivot = xlWorksheetPivot.Range[xlWorksheetPivot.Cells[3, 1], xlWorksheetPivot.Cells[3, 14]];
               xlRangePivot.MergeCells = true;
               xlRangePivot.Value = string.Format("{0} del {1} al {2}", SubTitulo, x_Desde.ToString("D", CultureInfo.CreateSpecificCulture("es-PE")), x_Hasta.ToString("D", CultureInfo.CreateSpecificCulture("es-PE")));//SubTitulo + " " + Anio.ToString();
               xlRangePivot.Font.Bold = true;
               xlRangePivot.Font.Size = 12;
               xlRangePivot.VerticalAlignment = XLExcel.XlVAlign.xlVAlignCenter;
               xlRangePivot.HorizontalAlignment = XLExcel.XlHAlign.xlHAlignCenter;


               xlRangePivot = xlWorksheetPivot.Range[xlWorksheetPivot.Cells[6, 1], xlWorksheetPivot.Cells[6, 1]]; ;

               // create Pivot Cache and Pivot Table
               XLExcel.PivotCache XLPivotCache = (XLExcel.PivotCache)xlWorkbook.PivotCaches().Add(XLExcel.XlPivotTableSourceType.xlDatabase, xlRange);
               XLExcel.PivotTable XLPivotTable = (XLExcel.PivotTable)xlWorksheetPivot.PivotTables().Add(PivotCache: XLPivotCache, TableDestination: xlRangePivot, TableName: "SIN REBATE");

               // create Pivot Field, note that name will be the same as column name on sheet one
               XLExcel.PivotField XLPivotFieldMES = (XLExcel.PivotField)XLPivotTable.PivotFields("MES");
               XLPivotFieldMES.Orientation = XLExcel.XlPivotFieldOrientation.xlColumnField;
               XLPivotFieldMES.Name = "MES";

               XLExcel.PivotField XLPivotFieldVENDEDOR = (XLExcel.PivotField)XLPivotTable.PivotFields("VENDEDOR");
               XLPivotFieldVENDEDOR.Orientation = XLExcel.XlPivotFieldOrientation.xlRowField;
               XLPivotFieldVENDEDOR.Name = "VENDEDOR";

               XLExcel.PivotField XLPivotFieldTEUS = (XLExcel.PivotField)XLPivotTable.PivotFields((EsServicioTransmision ? "BLS" : ((x_CCOT_CodFLE == 1 ? "TEUS" : "LCL"))));
               XLPivotFieldTEUS.Orientation = XLExcel.XlPivotFieldOrientation.xlDataField;
               XLPivotFieldTEUS.Function = XLExcel.XlConsolidationFunction.xlSum;
               XLPivotFieldTEUS.Name = "Sum " + (EsServicioTransmision ? "BLS" : ((x_CCOT_CodFLE == 1 ? "TEUS" : "LCL")));

               XLExcel.PivotField XLPivotFieldRENT_TOTAL = (XLExcel.PivotField)XLPivotTable.PivotFields("RENT_TOTAL");
               XLPivotFieldRENT_TOTAL.Orientation = XLExcel.XlPivotFieldOrientation.xlDataField;
               XLPivotFieldRENT_TOTAL.Function = XLExcel.XlConsolidationFunction.xlSum;
               XLPivotFieldRENT_TOTAL.Name = "Sum RENT_TOTAL";

               XLPivotTable.SubtotalLocation(XLExcel.XlSubtototalLocationType.xlAtBottom);
               XLPivotTable.DataPivotField.Orientation = XLExcel.XlPivotFieldOrientation.xlRowField;
               XLPivotTable.DataPivotField.Position = 2;

               XLPivotTable.TableStyle2 = "PivotStyleLight18";
               XLPivotTable.RowAxisLayout(XLExcel.XlLayoutRowType.xlCompactRow);
               #endregion


               if (MostrarRebate)
               {
                  #region [ TOTAL CON REBATE ]
                  xlWorksheetData.Activate();

                  xlRange = xlWorksheetData.Range[xlWorksheetData.Cells[1, 1], xlWorksheetData.Cells[Reporte.Rows.Count + 1, Reporte.Columns.Count]];

                  xlWorksheetPivotRebate = (XLExcel.Worksheet)xlWorkbook.Worksheets[3];
                  xlWorksheetPivotRebate.Name = "TOTAL " + Nombre + " CON REBATE";
                  xlWorksheetPivotRebate.Activate();

                  XLExcel.Range xlRangePivotRebate;

                  //TITLE
                  xlRangePivotRebate = xlWorksheetPivotRebate.Range[xlWorksheetPivotRebate.Cells[2, 1], xlWorksheetPivotRebate.Cells[2, 14]];
                  xlRangePivotRebate.MergeCells = true;
                  xlRangePivotRebate.Value = Empresa + " - " + Titulo + (MostrarRebate ? " CON REBATE" : "");
                  xlRangePivotRebate.Font.Bold = true;
                  xlRangePivotRebate.Font.Size = 16;
                  xlRangePivotRebate.VerticalAlignment = XLExcel.XlVAlign.xlVAlignCenter;
                  xlRangePivotRebate.HorizontalAlignment = XLExcel.XlHAlign.xlHAlignCenter;

                  xlRangePivotRebate = xlWorksheetPivotRebate.Range[xlWorksheetPivotRebate.Cells[3, 1], xlWorksheetPivotRebate.Cells[3, 14]];
                  xlRangePivotRebate.MergeCells = true;
                  xlRangePivotRebate.Value = string.Format("{0} del {1} al {2}", SubTitulo, x_Desde.ToString("D", CultureInfo.CreateSpecificCulture("es-PE")), x_Hasta.ToString("D", CultureInfo.CreateSpecificCulture("es-PE")));//SubTitulo + " " + Anio.ToString();
                  xlRangePivotRebate.Font.Bold = true;
                  xlRangePivotRebate.Font.Size = 12;
                  xlRangePivotRebate.VerticalAlignment = XLExcel.XlVAlign.xlVAlignCenter;
                  xlRangePivotRebate.HorizontalAlignment = XLExcel.XlHAlign.xlHAlignCenter;


                  xlRangePivotRebate = xlWorksheetPivotRebate.Range[xlWorksheetPivotRebate.Cells[6, 1], xlWorksheetPivotRebate.Cells[6, 1]]; ;

                  // create Pivot Cache and Pivot Table
                  //XLExcel.PivotCache XLPivotCacheRebate = (XLExcel.PivotCache)xlWorkbook.PivotCaches().Add(XLExcel.XlPivotTableSourceType.xlDatabase, xlRange);
                  XLExcel.PivotTable XLPivotTableRebate = (XLExcel.PivotTable)xlWorksheetPivotRebate.PivotTables().Add(PivotCache: XLPivotCache, TableDestination: xlRangePivotRebate, TableName: "CON REBATE");

                  // create Pivot Field, note that name will be the same as column name on sheet one
                  XLExcel.PivotField XLPivotFieldMESRebate = (XLExcel.PivotField)XLPivotTableRebate.PivotFields("MES");
                  XLPivotFieldMESRebate.Orientation = XLExcel.XlPivotFieldOrientation.xlColumnField;
                  XLPivotFieldMESRebate.Name = "MES";

                  XLExcel.PivotField XLPivotFieldVENDEDORRebate = (XLExcel.PivotField)XLPivotTableRebate.PivotFields("VENDEDOR");
                  XLPivotFieldVENDEDORRebate.Orientation = XLExcel.XlPivotFieldOrientation.xlRowField;
                  XLPivotFieldVENDEDORRebate.Name = "VENDEDOR";

                  XLExcel.PivotField XLPivotFieldTEUSRebate = (XLExcel.PivotField)XLPivotTableRebate.PivotFields((x_CCOT_CodFLE == 1 ? "TEUS" : "LCL"));
                  XLPivotFieldTEUSRebate.Orientation = XLExcel.XlPivotFieldOrientation.xlDataField;
                  XLPivotFieldTEUSRebate.Function = XLExcel.XlConsolidationFunction.xlSum;
                  XLPivotFieldTEUSRebate.Name = "Sum " + (x_CCOT_CodFLE == 1 ? "TEUS" : "LCL");

                  XLExcel.PivotField XLPivotFieldRENT_TOTALRebate = (XLExcel.PivotField)XLPivotTableRebate.PivotFields("RENTABILIDAD_CON_REBATE");
                  XLPivotFieldRENT_TOTALRebate.Orientation = XLExcel.XlPivotFieldOrientation.xlDataField;
                  XLPivotFieldRENT_TOTALRebate.Function = XLExcel.XlConsolidationFunction.xlSum;
                  XLPivotFieldRENT_TOTALRebate.Name = "Sum RENTABILIDAD_CON_REBATE";

                  XLPivotTableRebate.SubtotalLocation(XLExcel.XlSubtototalLocationType.xlAtBottom);
                  XLPivotTableRebate.DataPivotField.Orientation = XLExcel.XlPivotFieldOrientation.xlRowField;
                  XLPivotTableRebate.DataPivotField.Position = 2;

                  XLPivotTableRebate.TableStyle2 = "PivotStyleLight18";
                  XLPivotTableRebate.RowAxisLayout(XLExcel.XlLayoutRowType.xlCompactRow);
                  #endregion
               }

               #region [ FUERZA DE VENTAS ]
               xlWorksheetData.Activate();
               xlRange = xlWorksheetData.Range[xlWorksheetData.Cells[1, 1], xlWorksheetData.Cells[Reporte.Rows.Count + 1, Reporte.Columns.Count]];

               xlWorksheetPivotFFVV = (XLExcel.Worksheet)xlWorkbook.Worksheets[(MostrarRebate ? 4 : 3)];
               xlWorksheetPivotFFVV.Name = "FUERZA VENTAS";

               xlWorksheetPivotFFVV.Activate();

               XLExcel.Range xlRangePivotFFVV;

               //TITLE
               xlRangePivotFFVV = xlWorksheetPivotFFVV.Range[xlWorksheetPivotFFVV.Cells[2, 1], xlWorksheetPivotFFVV.Cells[2, 14]];
               xlRangePivotFFVV.MergeCells = true;
               xlRangePivotFFVV.Value = Empresa + " - " + Titulo + (MostrarRebate ? " CON REBATE" : "");
               xlRangePivotFFVV.Font.Bold = true;
               xlRangePivotFFVV.Font.Size = 16;
               xlRangePivotFFVV.VerticalAlignment = XLExcel.XlVAlign.xlVAlignCenter;
               xlRangePivotFFVV.HorizontalAlignment = XLExcel.XlHAlign.xlHAlignCenter;

               xlRangePivotFFVV = xlWorksheetPivotFFVV.Range[xlWorksheetPivotFFVV.Cells[3, 1], xlWorksheetPivotFFVV.Cells[3, 14]];
               xlRangePivotFFVV.MergeCells = true;
               xlRangePivotFFVV.Value = string.Format("{0} del {1} al {2}", SubTitulo, x_Desde.ToString("D", CultureInfo.CreateSpecificCulture("es-PE")), x_Hasta.ToString("D", CultureInfo.CreateSpecificCulture("es-PE")));//SubTitulo + " " + Anio.ToString();
               xlRangePivotFFVV.Font.Bold = true;
               xlRangePivotFFVV.Font.Size = 12;
               xlRangePivotFFVV.VerticalAlignment = XLExcel.XlVAlign.xlVAlignCenter;
               xlRangePivotFFVV.HorizontalAlignment = XLExcel.XlHAlign.xlHAlignCenter;


               xlRangePivotFFVV = xlWorksheetPivotFFVV.Range[xlWorksheetPivotFFVV.Cells[6, 1], xlWorksheetPivotFFVV.Cells[6, 1]]; ;

               // create Pivot Cache and Pivot Table
               //XLExcel.PivotCache XLPivotCache = (XLExcel.PivotCache)xlWorkbook.PivotCaches().Add(XLExcel.XlPivotTableSourceType.xlDatabase, xlRange);
               XLExcel.PivotTable XLPivotTableFFVV = (XLExcel.PivotTable)xlWorksheetPivotFFVV.PivotTables().Add(PivotCache: XLPivotCache, TableDestination: xlRangePivotFFVV, TableName: "FFVV");

               // create Pivot Field, note that name will be the same as column name on sheet one
               XLExcel.PivotField XLPivotFieldMESFFVV = (XLExcel.PivotField)XLPivotTableFFVV.PivotFields("MES");
               XLPivotFieldMESFFVV.Orientation = XLExcel.XlPivotFieldOrientation.xlColumnField;
               XLPivotFieldMESFFVV.Name = "MES";

               XLExcel.PivotField XLPivotFieldVENDEDORFFVV = (XLExcel.PivotField)XLPivotTableFFVV.PivotFields("VENDEDOR");
               XLPivotFieldVENDEDORFFVV.Orientation = XLExcel.XlPivotFieldOrientation.xlRowField;
               XLPivotFieldVENDEDORFFVV.Name = "VENDEDOR";

               XLExcel.PivotField XLPivotFieldTEUSFFVV = (XLExcel.PivotField)XLPivotTableFFVV.PivotFields((x_CCOT_CodFLE == 1 ? "TEUS" : "LCL"));
               XLPivotFieldTEUSFFVV.Orientation = XLExcel.XlPivotFieldOrientation.xlDataField;
               XLPivotFieldTEUSFFVV.Function = XLExcel.XlConsolidationFunction.xlSum;
               XLPivotFieldTEUSFFVV.Name = "Sum " + (x_CCOT_CodFLE == 1 ? "TEUS" : "LCL");

               if (MostrarRebate)
               {
                  XLExcel.PivotField XLPivotFieldRENT_TOTALFFVV = (XLExcel.PivotField)XLPivotTableFFVV.PivotFields("RENTABILIDAD_CON_REBATE");
                  XLPivotFieldRENT_TOTALFFVV.Orientation = XLExcel.XlPivotFieldOrientation.xlDataField;
                  XLPivotFieldRENT_TOTALFFVV.Function = XLExcel.XlConsolidationFunction.xlSum;
                  XLPivotFieldRENT_TOTALFFVV.Name = "Sum RENTABILIDAD_CON_REBATE";
               }
               else
               {
                  XLExcel.PivotField XLPivotFieldRENT_TOTALFFVV = (XLExcel.PivotField)XLPivotTableFFVV.PivotFields("RENT_TOTAL");
                  XLPivotFieldRENT_TOTALFFVV.Orientation = XLExcel.XlPivotFieldOrientation.xlDataField;
                  XLPivotFieldRENT_TOTALFFVV.Function = XLExcel.XlConsolidationFunction.xlSum;
                  XLPivotFieldRENT_TOTALFFVV.Name = "Sum RENT_TOTAL";
               }

               XLPivotTableFFVV.SubtotalLocation(XLExcel.XlSubtototalLocationType.xlAtBottom);
               XLPivotTableFFVV.DataPivotField.Orientation = XLExcel.XlPivotFieldOrientation.xlRowField;
               XLPivotTableFFVV.DataPivotField.Position = 2;

               XLPivotTableFFVV.TableStyle2 = "PivotStyleLight18";
               XLPivotTableFFVV.RowAxisLayout(XLExcel.XlLayoutRowType.xlCompactRow);
               #endregion

               #region [ FUERZA DE VENTAS TRAFICO ]
               xlWorksheetData.Activate();
               xlRange = xlWorksheetData.Range[xlWorksheetData.Cells[1, 1], xlWorksheetData.Cells[Reporte.Rows.Count + 1, Reporte.Columns.Count]];

               xlWorksheetPivotFFVVServicios = (XLExcel.Worksheet)xlWorkbook.Worksheets[(MostrarRebate ? 5 : 4)];
               xlWorksheetPivotFFVVServicios.Name = "FF VV Servicios";

               xlWorksheetPivotFFVVServicios.Activate();

               XLExcel.Range xlRangePivotFFVVServicios;

               //TITLE
               xlRangePivotFFVVServicios = xlWorksheetPivotFFVVServicios.Range[xlWorksheetPivotFFVVServicios.Cells[2, 1], xlWorksheetPivotFFVVServicios.Cells[2, 14]];
               xlRangePivotFFVVServicios.MergeCells = true;
               xlRangePivotFFVVServicios.Value = Empresa + " - " + Titulo + (MostrarRebate ? " CON REBATE POR SERVICIO" : "");
               xlRangePivotFFVVServicios.Font.Bold = true;
               xlRangePivotFFVVServicios.Font.Size = 16;
               xlRangePivotFFVVServicios.VerticalAlignment = XLExcel.XlVAlign.xlVAlignCenter;
               xlRangePivotFFVVServicios.HorizontalAlignment = XLExcel.XlHAlign.xlHAlignCenter;

               xlRangePivotFFVVServicios = xlWorksheetPivotFFVVServicios.Range[xlWorksheetPivotFFVVServicios.Cells[3, 1], xlWorksheetPivotFFVVServicios.Cells[3, 14]];
               xlRangePivotFFVVServicios.MergeCells = true;
               xlRangePivotFFVVServicios.Value = string.Format("{0} del {1} al {2}", SubTitulo, x_Desde.ToString("D", CultureInfo.CreateSpecificCulture("es-PE")), x_Hasta.ToString("D", CultureInfo.CreateSpecificCulture("es-PE")));//SubTitulo + " " + Anio.ToString();
               xlRangePivotFFVVServicios.Font.Bold = true;
               xlRangePivotFFVVServicios.Font.Size = 12;
               xlRangePivotFFVVServicios.VerticalAlignment = XLExcel.XlVAlign.xlVAlignCenter;
               xlRangePivotFFVVServicios.HorizontalAlignment = XLExcel.XlHAlign.xlHAlignCenter;


               xlRangePivotFFVVServicios = xlWorksheetPivotFFVVServicios.Range[xlWorksheetPivotFFVVServicios.Cells[6, 1], xlWorksheetPivotFFVVServicios.Cells[6, 1]]; ;

               // create Pivot Cache and Pivot Table
               //XLExcel.PivotCache XLPivotCache = (XLExcel.PivotCache)xlWorkbook.PivotCaches().Add(XLExcel.XlPivotTableSourceType.xlDatabase, xlRange);
               XLExcel.PivotTable XLPivotTableFFVVServicios = (XLExcel.PivotTable)xlWorksheetPivotFFVVServicios.PivotTables().Add(PivotCache: XLPivotCache, TableDestination: xlRangePivotFFVVServicios, TableName: "FFVV Servicios");

               // create Pivot Field, note that name will be the same as column name on sheet one
               XLExcel.PivotField XLPivotFieldMESFFVVServicios = (XLExcel.PivotField)XLPivotTableFFVVServicios.PivotFields("MES");
               XLPivotFieldMESFFVVServicios.Orientation = XLExcel.XlPivotFieldOrientation.xlColumnField;
               XLPivotFieldMESFFVVServicios.Name = "MES";

               XLExcel.PivotField XLPivotFieldVENDEDORFFVVServicios = (XLExcel.PivotField)XLPivotTableFFVVServicios.PivotFields("TRAFICO");
               XLPivotFieldVENDEDORFFVVServicios.Orientation = XLExcel.XlPivotFieldOrientation.xlRowField;
               XLPivotFieldVENDEDORFFVVServicios.Name = "TRAFICO";

               XLExcel.PivotField XLPivotFieldSERVICIOFFVVServicios = (XLExcel.PivotField)XLPivotTableFFVVServicios.PivotFields("VENDEDOR");
               XLPivotFieldSERVICIOFFVVServicios.Orientation = XLExcel.XlPivotFieldOrientation.xlRowField;
               XLPivotFieldSERVICIOFFVVServicios.Name = "VENDEDOR";

               XLExcel.PivotField XLPivotFieldTEUSFFVVServicios = (XLExcel.PivotField)XLPivotTableFFVVServicios.PivotFields((x_CCOT_CodFLE == 1 ? "TEUS" : "LCL"));
               XLPivotFieldTEUSFFVVServicios.Orientation = XLExcel.XlPivotFieldOrientation.xlDataField;
               XLPivotFieldTEUSFFVVServicios.Function = XLExcel.XlConsolidationFunction.xlSum;
               XLPivotFieldTEUSFFVVServicios.Name = "Sum " + (x_CCOT_CodFLE == 1 ? "TEUS" : "LCL");

               if (MostrarRebate)
               {
                  XLExcel.PivotField XLPivotFieldRENT_TOTALFFVVServicios = (XLExcel.PivotField)XLPivotTableFFVVServicios.PivotFields("RENTABILIDAD_CON_REBATE");
                  XLPivotFieldRENT_TOTALFFVVServicios.Orientation = XLExcel.XlPivotFieldOrientation.xlDataField;
                  XLPivotFieldRENT_TOTALFFVVServicios.Function = XLExcel.XlConsolidationFunction.xlSum;
                  XLPivotFieldRENT_TOTALFFVVServicios.Name = "Sum RENTABILIDAD_CON_REBATE";
               }
               else
               {
                  XLExcel.PivotField XLPivotFieldRENT_TOTALFFVVServicios = (XLExcel.PivotField)XLPivotTableFFVVServicios.PivotFields("RENT_TOTAL");
                  XLPivotFieldRENT_TOTALFFVVServicios.Orientation = XLExcel.XlPivotFieldOrientation.xlDataField;
                  XLPivotFieldRENT_TOTALFFVVServicios.Function = XLExcel.XlConsolidationFunction.xlSum;
                  XLPivotFieldRENT_TOTALFFVVServicios.Name = "Sum RENT_TOTAL";
               }

               XLPivotTableFFVVServicios.SubtotalLocation(XLExcel.XlSubtototalLocationType.xlAtBottom);
               XLPivotTableFFVVServicios.DataPivotField.Orientation = XLExcel.XlPivotFieldOrientation.xlRowField;
               XLPivotTableFFVVServicios.DataPivotField.Position = 2;

               XLPivotTableFFVVServicios.TableStyle2 = "PivotStyleLight18";
               XLPivotTableFFVVServicios.RowAxisLayout(XLExcel.XlLayoutRowType.xlCompactRow);
               #endregion
            }
            else
            {
               #region [ SERVICIO TRANSMISIONES ]
               xlWorksheetData.Activate();
               xlRange = xlWorksheetData.Range[xlWorksheetData.Cells[1, 1], xlWorksheetData.Cells[Reporte.Rows.Count + 1, Reporte.Columns.Count]];

               xlWorksheetPivot = (XLExcel.Worksheet)xlWorkbook.Worksheets[2];
               xlWorksheetPivot.Name = "TOTAL " + Nombre + (MostrarRebate ? " SIN REBATE" : "");
               xlWorksheetPivot.Activate();

               XLExcel.Range xlRangePivot;

               //TITLE
               xlRangePivot = xlWorksheetPivot.Range[xlWorksheetPivot.Cells[2, 1], xlWorksheetPivot.Cells[2, 14]];
               xlRangePivot.MergeCells = true;
               xlRangePivot.Value = Empresa + " - " + Titulo + (MostrarRebate ? " SIN REBATE" : "");
               xlRangePivot.Font.Bold = true;
               xlRangePivot.Font.Size = 16;
               xlRangePivot.VerticalAlignment = XLExcel.XlVAlign.xlVAlignCenter;
               xlRangePivot.HorizontalAlignment = XLExcel.XlHAlign.xlHAlignCenter;

               xlRangePivot = xlWorksheetPivot.Range[xlWorksheetPivot.Cells[3, 1], xlWorksheetPivot.Cells[3, 14]];
               xlRangePivot.MergeCells = true;
               xlRangePivot.Value = string.Format("{0} del {1} al {2}", SubTitulo, x_Desde.ToString("D", CultureInfo.CreateSpecificCulture("es-PE")), x_Hasta.ToString("D", CultureInfo.CreateSpecificCulture("es-PE")));//SubTitulo + " " + Anio.ToString();
               xlRangePivot.Font.Bold = true;
               xlRangePivot.Font.Size = 12;
               xlRangePivot.VerticalAlignment = XLExcel.XlVAlign.xlVAlignCenter;
               xlRangePivot.HorizontalAlignment = XLExcel.XlHAlign.xlHAlignCenter;


               xlRangePivot = xlWorksheetPivot.Range[xlWorksheetPivot.Cells[6, 1], xlWorksheetPivot.Cells[6, 1]]; ;

               // create Pivot Cache and Pivot Table
               XLExcel.PivotCache XLPivotCache = (XLExcel.PivotCache)xlWorkbook.PivotCaches().Add(XLExcel.XlPivotTableSourceType.xlDatabase, xlRange);
               XLExcel.PivotTable XLPivotTable = (XLExcel.PivotTable)xlWorksheetPivot.PivotTables().Add(PivotCache: XLPivotCache, TableDestination: xlRangePivot, TableName: "SIN REBATE");

               // create Pivot Field, note that name will be the same as column name on sheet one
               XLExcel.PivotField XLPivotFieldMES = (XLExcel.PivotField)XLPivotTable.PivotFields("MES");
               XLPivotFieldMES.Orientation = XLExcel.XlPivotFieldOrientation.xlColumnField;
               XLPivotFieldMES.Name = "MES";

               XLExcel.PivotField XLPivotFieldVENDEDOR = (XLExcel.PivotField)XLPivotTable.PivotFields("VENDEDOR");
               XLPivotFieldVENDEDOR.Orientation = XLExcel.XlPivotFieldOrientation.xlRowField;
               XLPivotFieldVENDEDOR.Name = "VENDEDOR";

               XLExcel.PivotField XLPivotFieldTEUS = (XLExcel.PivotField)XLPivotTable.PivotFields((EsServicioTransmision ? "BLS" : ((x_CCOT_CodFLE == 1 ? "TEUS" : "LCL"))));
               XLPivotFieldTEUS.Orientation = XLExcel.XlPivotFieldOrientation.xlDataField;
               XLPivotFieldTEUS.Function = XLExcel.XlConsolidationFunction.xlSum;
               XLPivotFieldTEUS.Name = "Sum " + (EsServicioTransmision ? "BLS" : ((x_CCOT_CodFLE == 1 ? "TEUS" : "LCL")));

               XLExcel.PivotField XLPivotFieldRENT_TOTAL = (XLExcel.PivotField)XLPivotTable.PivotFields("RENT_TOTAL");
               XLPivotFieldRENT_TOTAL.Orientation = XLExcel.XlPivotFieldOrientation.xlDataField;
               XLPivotFieldRENT_TOTAL.Function = XLExcel.XlConsolidationFunction.xlSum;
               XLPivotFieldRENT_TOTAL.Name = "Sum RENT_TOTAL";

               XLPivotTable.SubtotalLocation(XLExcel.XlSubtototalLocationType.xlAtBottom);
               XLPivotTable.DataPivotField.Orientation = XLExcel.XlPivotFieldOrientation.xlRowField;
               XLPivotTable.DataPivotField.Position = 2;

               XLPivotTable.TableStyle2 = "PivotStyleLight18";
               XLPivotTable.RowAxisLayout(XLExcel.XlLayoutRowType.xlCompactRow);
               #endregion
            }

            xlApplication.Visible = true;

            releaseObject(xlWorksheetData);

            releaseObject(xlWorksheetPivot);
            if (MostrarRebate)
            { releaseObject(xlWorksheetPivotRebate); }
            releaseObject(xlWorksheetComparacion);

            releaseObject(xlWorksheetPivotFFVV);
            releaseObject(xlWorksheetPivotFFVVServicios);

            releaseObject(xlWorkbook);
            releaseObject(xlApplication);

         }
         catch (Exception ex)
         {
            releaseObject(xlWorksheetData);
            releaseObject(xlWorksheetPivot);

            if (MostrarRebate)
            { releaseObject(xlWorksheetPivotRebate); }
            releaseObject(xlWorksheetComparacion);
            releaseObject(xlWorksheetPivotFFVV);
            releaseObject(xlWorksheetPivotFFVVServicios);

            releaseObject(xlWorkbook);
            releaseObject(xlApplication);

            throw ex;
         }
      }

      private void SetValue(XLExcel.Range xlRange, Object xlValue, Boolean xlMergeCells = false, XLExcel.XlVAlign xlVAlign = XLExcel.XlVAlign.xlVAlignCenter, XLExcel.XlHAlign xlHAlign = XLExcel.XlHAlign.xlHAlignCenter, Boolean xlBold = false, Boolean xlUnderline = false)
      {
         xlRange.MergeCells = xlMergeCells;
         xlRange.Value = xlValue;
         xlRange.Font.Name = xlFont;
         xlRange.Font.Size = xlFontSize;
         xlRange.Font.Bold = xlBold;
         xlRange.Font.Underline = xlUnderline;
         xlRange.VerticalAlignment = xlVAlign;
         xlRange.HorizontalAlignment = xlHAlign;
      }
      private void SetValueHeader(XLExcel.Range xlRange, Object xlValue, Boolean xlMergeCells = true, XLExcel.XlVAlign xlVAlign = XLExcel.XlVAlign.xlVAlignCenter, XLExcel.XlHAlign xlHAlign = XLExcel.XlHAlign.xlHAlignCenter, Boolean xlBold = true, Boolean xlUnderline = false)
      { SetValue(xlRange, xlValue, xlMergeCells, xlVAlign, xlHAlign, xlBold, xlUnderline); }
      private void SetValueCell(XLExcel.Range xlRange, Object xlValue, Boolean xlMergeCells = false, XLExcel.XlVAlign xlVAlign = XLExcel.XlVAlign.xlVAlignTop, XLExcel.XlHAlign xlHAlign = XLExcel.XlHAlign.xlHAlignLeft, Boolean xlBold = false, Boolean xlUnderline = false)
      { SetValue(xlRange, xlValue, xlMergeCells, xlVAlign, xlHAlign, xlBold, xlUnderline); }

      private void setBorderCelda(XLExcel.Range xlRange, XLExcel.XlBorderWeight xlWeight = XLExcel.XlBorderWeight.xlThin, XLExcel.XlLineStyle xlLineStyle = XLExcel.XlLineStyle.xlContinuous, Boolean xlClearStyle = true, Boolean xlEdgeLeft = true, Boolean xlEdgeTop = true, Boolean xlEdgeRight = true, Boolean xlEdgeBottom = true, Boolean xlInsideVertical = true, Boolean xlInsideHorizontal = true, Boolean xlDiagonalDown = true, Boolean xlDiagonalUp = true)
      {
         if (xlClearStyle)
         {
            xlRange.Borders[XLExcel.XlBordersIndex.xlDiagonalDown].LineStyle = XLExcel.XlLineStyle.xlLineStyleNone;
            xlRange.Borders[XLExcel.XlBordersIndex.xlDiagonalUp].LineStyle = XLExcel.XlLineStyle.xlLineStyleNone;
            xlRange.Borders[XLExcel.XlBordersIndex.xlEdgeLeft].LineStyle = XLExcel.XlLineStyle.xlLineStyleNone;
            xlRange.Borders[XLExcel.XlBordersIndex.xlEdgeTop].LineStyle = XLExcel.XlLineStyle.xlLineStyleNone;
            xlRange.Borders[XLExcel.XlBordersIndex.xlEdgeBottom].LineStyle = XLExcel.XlLineStyle.xlLineStyleNone;
            xlRange.Borders[XLExcel.XlBordersIndex.xlEdgeRight].LineStyle = XLExcel.XlLineStyle.xlLineStyleNone;
            xlRange.Borders[XLExcel.XlBordersIndex.xlInsideVertical].LineStyle = XLExcel.XlLineStyle.xlLineStyleNone;
            xlRange.Borders[XLExcel.XlBordersIndex.xlInsideHorizontal].LineStyle = XLExcel.XlLineStyle.xlLineStyleNone;
         }

         //xlEdgeLeft
         if (xlEdgeLeft)
         {
            xlRange.Borders[XLExcel.XlBordersIndex.xlEdgeLeft].LineStyle = xlLineStyle;
            xlRange.Borders[XLExcel.XlBordersIndex.xlEdgeLeft].Weight = xlWeight;
            xlRange.Borders[XLExcel.XlBordersIndex.xlEdgeLeft].ColorIndex = 0;
            xlRange.Borders[XLExcel.XlBordersIndex.xlEdgeLeft].TintAndShade = 0;
         }
         //xlEdgeTop
         if (xlEdgeTop)
         {
            xlRange.Borders[XLExcel.XlBordersIndex.xlEdgeTop].LineStyle = xlLineStyle;
            xlRange.Borders[XLExcel.XlBordersIndex.xlEdgeTop].Weight = xlWeight;
            xlRange.Borders[XLExcel.XlBordersIndex.xlEdgeTop].ColorIndex = 0;
            xlRange.Borders[XLExcel.XlBordersIndex.xlEdgeTop].TintAndShade = 0;
         }
         //xlEdgeRight
         if (xlEdgeRight)
         {
            xlRange.Borders[XLExcel.XlBordersIndex.xlEdgeRight].LineStyle = xlLineStyle;
            xlRange.Borders[XLExcel.XlBordersIndex.xlEdgeRight].Weight = xlWeight;
            xlRange.Borders[XLExcel.XlBordersIndex.xlEdgeRight].ColorIndex = 0;
            xlRange.Borders[XLExcel.XlBordersIndex.xlEdgeRight].TintAndShade = 0;
         }
         //xlEdgeBottom
         if (xlEdgeBottom)
         {
            xlRange.Borders[XLExcel.XlBordersIndex.xlEdgeBottom].LineStyle = xlLineStyle;
            xlRange.Borders[XLExcel.XlBordersIndex.xlEdgeBottom].Weight = xlWeight;
            xlRange.Borders[XLExcel.XlBordersIndex.xlEdgeBottom].ColorIndex = 0;
            xlRange.Borders[XLExcel.XlBordersIndex.xlEdgeBottom].TintAndShade = 0;
         }
         //xlInsideVertical
         if (xlInsideVertical)
         {
            xlRange.Borders[XLExcel.XlBordersIndex.xlInsideVertical].LineStyle = xlLineStyle;
            xlRange.Borders[XLExcel.XlBordersIndex.xlInsideVertical].Weight = xlWeight;
            xlRange.Borders[XLExcel.XlBordersIndex.xlInsideVertical].ColorIndex = 0;
            xlRange.Borders[XLExcel.XlBordersIndex.xlInsideVertical].TintAndShade = 0;
         }
         //xlInsideHorizontal
         if (xlInsideHorizontal)
         {
            xlRange.Borders[XLExcel.XlBordersIndex.xlInsideHorizontal].LineStyle = xlLineStyle;
            xlRange.Borders[XLExcel.XlBordersIndex.xlInsideHorizontal].Weight = xlWeight;
            xlRange.Borders[XLExcel.XlBordersIndex.xlInsideHorizontal].ColorIndex = 0;
            xlRange.Borders[XLExcel.XlBordersIndex.xlInsideHorizontal].TintAndShade = 0;
         }
         //xlDiagonalDown

         //xlDiagonalUp

      }

      private void releaseObject(object obj)
      {
         try
         {
            System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
            obj = null;
         }
         catch (Exception)
         {
            obj = null;
            //MessageBox.Show("Exception Occured while releasing object " + ex.ToString());
         }
         finally
         {
            GC.Collect();
         }
      }

      private String MonthName(int month)
      {
         try
         {
            System.Globalization.DateTimeFormatInfo dtinfo = new System.Globalization.CultureInfo("es-PE", false).DateTimeFormat;
            return dtinfo.GetMonthName(month);
         }
         catch (Exception)
         {
            throw;
         }
      }
      #endregion
   }
}