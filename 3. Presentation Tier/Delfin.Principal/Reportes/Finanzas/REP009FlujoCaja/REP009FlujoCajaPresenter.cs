using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

using Microsoft.Practices.Unity;
using Delfin.ServiceContracts;
using Delfin.ServiceProxy;
using Delfin.Entities;
using Infrastructure.Client.Services.Session;

using System.IO;
using XLExcel = Microsoft.Office.Interop.Excel;
using Microsoft.Office.Tools.Excel;

namespace Delfin.Principal
{
   public class REP009FlujoCajaPresenter
   {
      #region [ Variables ]
      public String Title = "Flujo de Caja";
      public String CUS = "REPF009";

      public enum TipoReporte
      {
         Excel = 0, Reporte = 1
      }

      public enum Tipo
      {
         Anual = 0, Mensual = 1
      }

      #endregion

      #region [ Propiedades ]

      public IUnityContainer ContainerService { get; set; }
      public ISessionService Session { get; set; }
      public IDelfinServices Client { get; set; }

      public IREP009FlujoCajaLView LView { get; set; }
      public System.Data.DataTable DTPeriodos { get; set; }

      public TipoReporte TReporte { get; set; }
      public Tipo TipoPresentacion { get; set; }
      public System.Data.DataTable DTReporte { get; set; }
      public Boolean ToReport { get; set; }

      #endregion

      #region [ REP008EstadoClientePresenter ]

      public REP009FlujoCajaPresenter(IUnityContainer x_container, IREP009FlujoCajaLView x_lview)
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
            DTPeriodos = new System.Data.DataTable();
            ObservableCollection<Infrastructure.Aspect.DataAccess.DataAccessFilterSQL> _listFilters = new ObservableCollection<Infrastructure.Aspect.DataAccess.DataAccessFilterSQL>();
            DTPeriodos = Client.GetDTAnexos("CAJ_CCCTSS_Periodos", _listFilters);
            LView.LoadView();

            ToReport = false;
            Parametros _para = Client.GetOneParametrosByClave("REP_FLUJOCAJAREPORT");
            if (_para != null)
            {
               Boolean _rep = false;
               if(Boolean.TryParse(_para.PARA_Valor, out _rep))
               { ToReport = _rep; }
            }

         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Title, "Ha ocurrido un error inicializando la vista.", ex); }
      }

      #endregion

      #region [ Metodos ]

      public String F_Tipo { get; set; }
      public String F_Periodo { get; set; }
      public String F_CUBA_Codigo { get; set; }
      public Boolean F_IncluirDiferidos { get; set; }
      public String F_NroCuenta { get; set; }
      public String F_Moneda { get; set; }
      public String F_EntidadBancaria { get; set; }

      public void Exportar(ref System.Windows.Forms.ProgressBar pgbarrNativo)
      {
         try
         {
            TipoPresentacion = F_Tipo.Equals("A") ? Tipo.Anual : Tipo.Mensual;

            ObservableCollection<Infrastructure.Aspect.DataAccess.DataAccessFilterSQL> _listFilters = new ObservableCollection<Infrastructure.Aspect.DataAccess.DataAccessFilterSQL>();
            _listFilters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@psinEMPR_Codigo", FilterValue = Controls.Entorno.ItemEmpresa.EMPR_Codigo, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.Int16, FilterSize = 2 });
            _listFilters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@Tipo", FilterValue = F_Tipo, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.Char, FilterSize = 1 });
            _listFilters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@Periodo", FilterValue = F_Periodo, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.Char, FilterSize = 4 });
            _listFilters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@pchrCUBA_Codigo", FilterValue = F_CUBA_Codigo, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.Char, FilterSize = 3 });
            _listFilters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@IncluirDiferidos", FilterValue = F_IncluirDiferidos, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.Boolean, FilterSize = 1 });
            DTReporte = Client.GetDTCtaCte("CAJ_REPOSS_FlujoCaja", _listFilters);
            if (DTReporte != null)
            {
               switch (TReporte)
               {
                  case TipoReporte.Excel:
                     GenerarXLS(DTReporte, ref pgbarrNativo);
                     break;
                  case TipoReporte.Reporte:
                     LView.GenerarReporte();
                     break;
                  default:
                     break;
               }
            }
            else { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Title, "No existen datos para mostrar el reporte."); }
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Title, "Ha ocurrido un error Exportando el Reporte.", ex); }
      }



      private void GenerarXLS(System.Data.DataTable DTReporte, ref System.Windows.Forms.ProgressBar pgbarrNativo)
      {
         XLExcel.Application xlApplication;
         XLExcel.Workbook xlWorkbook;
         XLExcel.Worksheet xlWorksheetData;
         XLExcel.Range xlRange;

         object misValue = System.Reflection.Missing.Value;
         xlApplication = new XLExcel.Application();

         xlWorkbook = xlApplication.Workbooks.Add(misValue);
         xlWorksheetData = (XLExcel.Worksheet)xlWorkbook.Worksheets[1];
         xlWorksheetData.Name = "Flujo de Caja";

         try
         {
            pgbarrNativo.Minimum = 0;
            pgbarrNativo.Value = 0;
            pgbarrNativo.Step = 1;
            pgbarrNativo.Maximum = DTReporte.Rows.Count + DTReporte.Columns.Count * 2;

            #region [ Encabezado ]

            String _ruta = Path.Combine(System.Windows.Forms.Application.StartupPath, @"Resources\\logoDelfin2.png");
            System.Drawing.Image logoDelfin = System.Drawing.Image.FromFile(_ruta);
            xlWorksheetData.Shapes.AddPicture(_ruta, Microsoft.Office.Core.MsoTriState.msoFalse, Microsoft.Office.Core.MsoTriState.msoCTrue, 3f, 3f, 130, 68);

            #endregion

            #region [ Cuerpo ]

            xlRange = xlWorksheetData.Range["A8"];
            SetValueHeader(xlRange, "Descripción", "Arial", 10);
            setBorderCelda(xlRange, XLExcel.XlBorderWeight.xlThin, XLExcel.XlLineStyle.xlContinuous, true, true, true, true, true, false, false, false, false);

            #region [ Cabecera de la tabla de Datos ]

            int x_Col_Char = 66, x_Posicion = 8, x_Col = 2;
            Boolean _Cabeceras = false;
            foreach (System.Data.DataColumn x_Columna in DTReporte.Columns)
            {
               pgbarrNativo.Value++;

               if (x_Columna.ColumnName.Equals("TipoMovimiento")) { _Cabeceras = true; continue; }
               if (!_Cabeceras) { continue; }
               if (x_Columna.ColumnName.Equals("Total")) { break; }

               String x_NameColumnaUp = "", x_NameColumnaDown = "";
               if (F_Tipo.Equals("A"))
               {
                  String[] x_Cols = x_Columna.ColumnName.ToString().Split('|');
                  x_NameColumnaUp = x_Cols[1].ToString();
                  x_NameColumnaDown = x_Cols[2].ToString();
               }
               else if (F_Tipo.Equals("M"))
               {
                  String[] x_Cols = x_Columna.ColumnName.ToString().Split('|');
                  x_NameColumnaUp = x_Cols[1].ToString();
               }

               xlRange = xlWorksheetData.Range[xlWorksheetData.Cells[x_Posicion, x_Col], xlWorksheetData.Cells[x_Posicion, x_Col]];
               SetValueHeader(xlRange, x_NameColumnaUp, "Arial", 10);
               setBorderCelda(xlRange, XLExcel.XlBorderWeight.xlThin, XLExcel.XlLineStyle.xlContinuous, true, true, true, true, true, false, false, false, false);
               if (F_Tipo.Equals("A"))
               {
                  xlRange = xlWorksheetData.Range[xlWorksheetData.Cells[x_Posicion + 1, x_Col], xlWorksheetData.Cells[x_Posicion + 1, x_Col]];
                  SetValueHeader(xlRange, x_NameColumnaDown, "Arial", 10);
                  setBorderCelda(xlRange, XLExcel.XlBorderWeight.xlThin, XLExcel.XlLineStyle.xlContinuous, true, true, true, true, true, false, false, false, false);
               }
               x_Col_Char++;
               x_Col++;
            }
            if (F_Tipo.Equals("A")) { x_Posicion += 2; } else if (F_Tipo.Equals("M")) { x_Posicion++; }
            #endregion

            #region [ Saldo Mes Anterior ]

            int x_PosicionSaldoAnterior = x_Posicion;

            xlRange = xlWorksheetData.Range[String.Format("A{0}", x_Posicion++)];
            SetValueHeader(xlRange, "Saldo Mes Anterior", "Arial", 10);
            setBorderCelda(xlRange, XLExcel.XlBorderWeight.xlThin, XLExcel.XlLineStyle.xlContinuous, true, true, true, true, true, false, false, false, false);

            #endregion

            #region [ INGRESOS ]

            int x_PosicionIngresos = x_Posicion;
            xlRange = xlWorksheetData.Range[String.Format("A{0}", x_Posicion++)];
            SetValueHeader(xlRange, "INGRESOS", "Arial", 10);
            setBorderCelda(xlRange, XLExcel.XlBorderWeight.xlThin, XLExcel.XlLineStyle.xlContinuous, true, true, true, true, true, false, false, false, false);
            xlRange.Interior.Color = System.Drawing.ColorTranslator.FromHtml("#000000");
            xlRange.Font.Color = System.Drawing.ColorTranslator.FromHtml("#FFFFFF");

            #region [ Datos de Ingresos ]

            /* INGRESOS */
            int x_CountIngresos = 0;
            foreach (System.Data.DataRow x_Fila in DTReporte.Rows)
            {
               if (x_Fila["TipoMovimiento"].ToString().Equals("I"))
               {
                  pgbarrNativo.Value++;

                  xlRange = xlWorksheetData.Range[String.Format("A{0}", x_Posicion)];
                  xlRange.HorizontalAlignment = XLExcel.XlHAlign.xlHAlignLeft;
                  SetValueHeader(xlRange, x_Fila["Movimiento"].ToString(), "Arial", 10);
                  setBorderCelda(xlRange, XLExcel.XlBorderWeight.xlThin, XLExcel.XlLineStyle.xlContinuous, true, true, true, true, true, false, false, false, false);
                  xlRange.HorizontalAlignment = XLExcel.XlHAlign.xlHAlignLeft;

                  x_Col = 2;
                  _Cabeceras = false;
                  foreach (System.Data.DataColumn x_Columna in DTReporte.Columns)
                  {
                     if (x_Columna.ColumnName.Equals("TipoMovimiento")) { _Cabeceras = true; continue; }
                     if (!_Cabeceras) { continue; }
                     if (x_Columna.ColumnName.Equals("Total")) { break; }

                     xlRange = xlWorksheetData.Range[xlWorksheetData.Cells[x_Posicion, x_Col], xlWorksheetData.Cells[x_Posicion, x_Col]];
                     xlRange.Value = x_Fila[x_Columna.ColumnName];
                     xlRange.NumberFormat = "#,###,##0.00";
                     setBorderCelda(xlRange, XLExcel.XlBorderWeight.xlThin, XLExcel.XlLineStyle.xlContinuous, true, true, true, true, true, false, false, false, false);
                     x_Col++;


                  }
                  x_Posicion++;
                  x_CountIngresos++;
               }
            }

            #endregion
            #endregion

            #region [ EGRESOS ]

            /* EGRESOS */
            int x_PosicionEgresos = x_Posicion;
            xlRange = xlWorksheetData.Range[String.Format("A{0}", x_Posicion++)];
            xlRange.Interior.Color = System.Drawing.ColorTranslator.FromHtml("#000000");
            xlRange.Font.Color = System.Drawing.ColorTranslator.FromHtml("#FFFFFF");
            SetValueHeader(xlRange, "EGRESOS", "Arial", 10);
            setBorderCelda(xlRange, XLExcel.XlBorderWeight.xlThin, XLExcel.XlLineStyle.xlContinuous, true, true, true, true, true, false, false, false, false);

            #region [ Datos Egresos ]

            int x_CountEgresos = 0;
            foreach (System.Data.DataRow x_Fila in DTReporte.Rows)
            {
               if (x_Fila["TipoMovimiento"].ToString().Equals("E"))
               {
                  pgbarrNativo.Value++;

                  xlRange = xlWorksheetData.Range[String.Format("A{0}", x_Posicion)];
                  SetValueHeader(xlRange, x_Fila["Movimiento"].ToString(), "Arial", 10);
                  setBorderCelda(xlRange, XLExcel.XlBorderWeight.xlThin, XLExcel.XlLineStyle.xlContinuous, true, true, true, true, true, false, false, false, false);
                  xlRange.HorizontalAlignment = XLExcel.XlHAlign.xlHAlignLeft;

                  x_Col = 2;
                  _Cabeceras = false;
                  foreach (System.Data.DataColumn x_Columna in DTReporte.Columns)
                  {
                     if (x_Columna.ColumnName.Equals("TipoMovimiento"))
                     { _Cabeceras = true; continue; }
                     if (!_Cabeceras) { continue; }
                     if (x_Columna.ColumnName.Equals("Total")) { break; }

                     xlRange = xlWorksheetData.Range[xlWorksheetData.Cells[x_Posicion, x_Col], xlWorksheetData.Cells[x_Posicion, x_Col]];
                     xlRange.Value = x_Fila[x_Columna.ColumnName];
                     xlRange.NumberFormat = "#,###,##0.00";
                     setBorderCelda(xlRange, XLExcel.XlBorderWeight.xlThin, XLExcel.XlLineStyle.xlContinuous, true, true, true, true, true, false, false, false, false);
                     x_Col++;
                  }
                  x_Posicion++;
                  x_CountEgresos++;
               }
            }

            #endregion

            #endregion

            #region [ Pie ]

            //int x_PosicionCajaBancos = x_Posicion;
            //xlRange = xlWorksheetData.Range[String.Format("A{0}", x_Posicion++)];
            //SetValueHeader(xlRange, "CAJA BANCOS", "Arial", 10);
            //setBorderCelda(xlRange, XLExcel.XlBorderWeight.xlThin, XLExcel.XlLineStyle.xlContinuous, true, true, true, true, true, false, false, false, false);
            //xlRange.HorizontalAlignment = XLExcel.XlHAlign.xlHAlignLeft;

            //int x_PosicionCajaNacion = x_Posicion;
            //xlRange = xlWorksheetData.Range[String.Format("A{0}", x_Posicion++)];
            //SetValueHeader(xlRange, "CAJA BCO NACIÓN", "Arial", 10);
            //setBorderCelda(xlRange, XLExcel.XlBorderWeight.xlThin, XLExcel.XlLineStyle.xlContinuous, true, true, true, true, true, false, false, false, false);
            //xlRange.HorizontalAlignment = XLExcel.XlHAlign.xlHAlignLeft;

            int x_PosicionCajaTotal = x_Posicion;
            xlRange = xlWorksheetData.Range[String.Format("A{0}", x_Posicion)];
            SetValueHeader(xlRange, "CAJA BANCOS FINAL", "Arial", 10);
            setBorderCelda(xlRange, XLExcel.XlBorderWeight.xlThin, XLExcel.XlLineStyle.xlContinuous, true, true, true, true, true, false, false, false, false);
            xlRange.HorizontalAlignment = XLExcel.XlHAlign.xlHAlignLeft;
            xlRange.Interior.Color = System.Drawing.ColorTranslator.FromHtml("#000000");
            xlRange.Font.Color = System.Drawing.ColorTranslator.FromHtml("#FFFFFF");

            #endregion

            #region [ Formulas ]

            _Cabeceras = false;
            Boolean _PrimerSaldo = false, _ColumnaMovimiento = true;
            x_Col = 2;
            foreach (System.Data.DataColumn x_Columna in DTReporte.Columns)
            {
               pgbarrNativo.Value++;

               if (x_Columna.ColumnName.Equals("TipoMovimiento")) { _Cabeceras = true; continue; }
               if (x_Columna.ColumnName.Equals("Movimiento"))
               {
                  xlRange = xlWorksheetData.Range["A1"];
                  xlRange.EntireColumn.AutoFit();
                  //xlRange.ColumnWidth = 50;
                  continue;
               }
               if (!_Cabeceras) { continue; }
               if (x_Columna.ColumnName.Equals("Total")) { break; }

               #region [ Formulas SaldoAnterior ]

               xlRange = xlWorksheetData.Range[xlWorksheetData.Cells[x_PosicionSaldoAnterior, x_Col], xlWorksheetData.Cells[x_PosicionSaldoAnterior, x_Col]];
               String x_direccionSaldoAnterior = RangeAddress(xlRange);
               if (_PrimerSaldo)
               {
                  xlRange = xlWorksheetData.Range[xlWorksheetData.Cells[x_Posicion, x_Col - 1], xlWorksheetData.Cells[x_Posicion, x_Col - 1]];
                  String x_direccionAnterior = RangeAddress(xlRange);

                  xlRange = xlWorksheetData.Range[x_direccionSaldoAnterior];
                  setBorderCelda(xlRange, XLExcel.XlBorderWeight.xlThin, XLExcel.XlLineStyle.xlContinuous, true, true, true, true, true, false, false, false, false);
                  xlRange.Formula = String.Format("=+{0}", x_direccionAnterior);
                  xlRange.NumberFormat = "#,###,##0.00";
               }
               _PrimerSaldo = true;
               #endregion

               #region [ Formular Ingresos ]

               xlRange = xlWorksheetData.Range[xlWorksheetData.Cells[x_PosicionIngresos, x_Col], xlWorksheetData.Cells[x_PosicionIngresos, x_Col]];
               String x_direccionIngresos = RangeAddress(xlRange);
               xlRange = xlWorksheetData.Range[xlWorksheetData.Cells[x_PosicionIngresos + 1, x_Col], xlWorksheetData.Cells[x_PosicionIngresos + 1, x_Col]];
               String x_direccionIngresosInicio = RangeAddress(xlRange);
               xlRange = xlWorksheetData.Range[xlWorksheetData.Cells[x_PosicionEgresos - 1, x_Col], xlWorksheetData.Cells[x_PosicionEgresos - 1, x_Col]];
               String x_direccionIngresosTermino = RangeAddress(xlRange);

               xlRange = xlWorksheetData.Range[x_direccionIngresos];
               setBorderCelda(xlRange, XLExcel.XlBorderWeight.xlThin, XLExcel.XlLineStyle.xlContinuous, true, true, true, true, true, false, false, false, false);
               xlRange.Formula = String.Format("=SUM({0}:{1})", x_direccionIngresosInicio, x_direccionIngresosTermino);
               xlRange.NumberFormat = "#,###,##0.00";
               xlRange.Interior.Color = System.Drawing.ColorTranslator.FromHtml("#000000");
               xlRange.Font.Color = System.Drawing.ColorTranslator.FromHtml("#FFFFFF");

               #endregion

               #region [ Formulas Egresos ]

               xlRange = xlWorksheetData.Range[xlWorksheetData.Cells[x_PosicionEgresos, x_Col], xlWorksheetData.Cells[x_PosicionEgresos, x_Col]];
               String x_direccionEgresos = RangeAddress(xlRange);
               xlRange = xlWorksheetData.Range[xlWorksheetData.Cells[x_PosicionEgresos + 1, x_Col], xlWorksheetData.Cells[x_PosicionEgresos + 1, x_Col]];
               String x_direccionEgresosInicio = RangeAddress(xlRange);
               xlRange = xlWorksheetData.Range[xlWorksheetData.Cells[x_PosicionCajaTotal - 1, x_Col], xlWorksheetData.Cells[x_PosicionCajaTotal - 1, x_Col]];
               String x_direccionEgresosTermino = RangeAddress(xlRange);

               xlRange = xlWorksheetData.Range[x_direccionEgresos];
               setBorderCelda(xlRange, XLExcel.XlBorderWeight.xlThin, XLExcel.XlLineStyle.xlContinuous, true, true, true, true, true, false, false, false, false);
               xlRange.Formula = String.Format("=SUM({0}:{1})", x_direccionEgresosInicio, x_direccionEgresosTermino);
               xlRange.NumberFormat = "#,###,##0.00";
               xlRange.Interior.Color = System.Drawing.ColorTranslator.FromHtml("#000000");
               xlRange.Font.Color = System.Drawing.ColorTranslator.FromHtml("#FFFFFF");

               #endregion

               #region [ Formulas Total ]

               xlRange = xlWorksheetData.Range[xlWorksheetData.Cells[x_Posicion, x_Col], xlWorksheetData.Cells[x_Posicion, x_Col]];
               String x_direccionTotal = RangeAddress(xlRange);
               xlRange = xlWorksheetData.Range[x_direccionTotal];
               setBorderCelda(xlRange, XLExcel.XlBorderWeight.xlThin, XLExcel.XlLineStyle.xlContinuous, true, true, true, true, true, false, false, false, false);
               xlRange.Formula = String.Format("={0}+{1}+{2}", x_direccionIngresos, x_direccionEgresos, x_direccionSaldoAnterior);
               xlRange.NumberFormat = "#,###,##0.00";
               xlRange.Interior.Color = System.Drawing.ColorTranslator.FromHtml("#000000");
               xlRange.Font.Color = System.Drawing.ColorTranslator.FromHtml("#FFFFFF");

               #endregion

               x_Col++;
            }

            xlRange = xlWorksheetData.Range[xlWorksheetData.Cells[5, x_Col - 1], xlWorksheetData.Cells[5, x_Col - 1]];
            xlRange = xlWorksheetData.Range[String.Format("A1:{0}", RangeAddress(xlRange))];
            SetValueHeader(xlRange, "DELFIN GROUP CO S.A.C.", "Arial", 15);

            String x_descripcion = String.Format("Cuenta Bancaria : {0} / {1}", F_NroCuenta, F_EntidadBancaria);
            xlRange = xlWorksheetData.Range[xlWorksheetData.Cells[6, x_Col - 1], xlWorksheetData.Cells[6, x_Col - 1]];
            xlRange = xlWorksheetData.Range[String.Format("A6:{0}", RangeAddress(xlRange))];
            SetValueHeader(xlRange, x_descripcion, "Arial", 11);
            xlRange.HorizontalAlignment = XLExcel.XlHAlign.xlHAlignLeft;

            x_descripcion = String.Format("Moneda : {0}", F_Moneda);
            xlRange = xlWorksheetData.Range[xlWorksheetData.Cells[7, x_Col - 1], xlWorksheetData.Cells[7, x_Col - 1]];
            xlRange = xlWorksheetData.Range[String.Format("A7:{0}", RangeAddress(xlRange))];
            SetValueHeader(xlRange, x_descripcion, "Arial", 11);
            xlRange.HorizontalAlignment = XLExcel.XlHAlign.xlHAlignLeft;

            #endregion

            #endregion

            xlApplication.Visible = true;

            releaseObject(xlWorksheetData);
            releaseObject(xlWorkbook);
            releaseObject(xlApplication);
         }
         catch (Exception)
         {
            releaseObject(xlWorksheetData);
            releaseObject(xlWorkbook);
            releaseObject(xlApplication);
            throw;
         }
      }

      #region Metodos Utiles

      public string RangeAddress(XLExcel.Range rng)
      {
         return rng.get_AddressLocal(false, false, XLExcel.XlReferenceStyle.xlA1);
      }

      public string CellAddress(XLExcel.Worksheet sht, int row, int col)
      {
         return RangeAddress(sht.Cells[row, col]);
      }

      private void SetValue(XLExcel.Range xlRange, Object xlValue, String xlFontName, Int32 xlFontSize, Boolean xlMergeCells = false, XLExcel.XlVAlign xlVAlign = XLExcel.XlVAlign.xlVAlignCenter, XLExcel.XlHAlign xlHAlign = XLExcel.XlHAlign.xlHAlignCenter, Boolean xlBold = false, Boolean xlUnderline = false)
      {
         xlRange.MergeCells = xlMergeCells;
         xlRange.Value = xlValue;
         xlRange.Font.Name = xlFontName;
         xlRange.Font.Size = xlFontSize;
         xlRange.Font.Bold = xlBold;
         xlRange.Font.Underline = xlUnderline;
         xlRange.VerticalAlignment = xlVAlign;
         xlRange.HorizontalAlignment = xlHAlign;
      }

      private void SetValueHeader(XLExcel.Range xlRange, Object xlValue, String xlFontName, Int32 xlFontSize, Boolean xlMergeCells = true, XLExcel.XlVAlign xlVAlign = XLExcel.XlVAlign.xlVAlignCenter, XLExcel.XlHAlign xlHAlign = XLExcel.XlHAlign.xlHAlignCenter, Boolean xlBold = true, Boolean xlUnderline = false)
      { SetValue(xlRange, xlValue, xlFontName, xlFontSize, xlMergeCells, xlVAlign, xlHAlign, xlBold, xlUnderline); }

      private void SetValueCell(XLExcel.Range xlRange, Object xlValue, String xlFontName, Int32 xlFontSize, Boolean xlMergeCells = false, XLExcel.XlVAlign xlVAlign = XLExcel.XlVAlign.xlVAlignTop, XLExcel.XlHAlign xlHAlign = XLExcel.XlHAlign.xlHAlignLeft, Boolean xlBold = false, Boolean xlUnderline = false)
      { SetValue(xlRange, xlValue, xlFontName, xlFontSize, xlMergeCells, xlVAlign, xlHAlign, xlBold, xlUnderline); }

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

      #endregion

      #endregion

      #region [ Eventos ]

      #endregion

      #region [ IFormClose ]

      #endregion

   }
}
