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

namespace Delfin.Principal
{
    public partial class REP014Presenter
    {
        #region [ Variables ]
        public String Title = "Reporte Control de Transmisiones";
        public String CUS = "REP014";
        public DateTime Fecha { get; set; }
        #endregion

        #region [ Contrusctor ]
        public REP014Presenter(IUnityContainer x_container, IREP014View x_mview)
        {
            try
            {
                this.ContainerService = x_container;
                Session = this.ContainerService.Resolve<ISessionService>();
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
                Fecha = Client.GetFecha();
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
        public IREP014View MView { get; set; }

        public System.Data.DataTable DtControlTransmisiones { get; set; }
        #endregion

        #region [ Parámetros ]
        #endregion

        #region [ Metodos ]
        public void Cargar(String x_CONS_TabRGM, String x_CONS_CodRGM, Nullable<DateTime> x_NVIA_FecETA_ETDIni, Nullable<DateTime> x_NVIA_FecETA_ETDFin)
        {
            try
            {
                DtControlTransmisiones = Client.GetAllNaveViajeByControlTransmisiones(x_CONS_TabRGM, x_CONS_CodRGM, x_NVIA_FecETA_ETDIni, x_NVIA_FecETA_ETDFin);
                if (DtControlTransmisiones != null && DtControlTransmisiones.Rows.Count > 0)
                {
                    Exportar();
                }
                else
                { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Title, "No se encontraron resultados."); }
            }
            catch (Exception ex)
            { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Title, Infrastructure.Aspect.Constants.Mensajes.NewPresenter, ex); }
        }
        #endregion

        #region [ Exportacion Excel ]
        private const String xlFont = "Calibri";
        private const Int32 xlFontSize = 11;

        private void Exportar()
        {
            XLExcel.Application xlApplication;
            XLExcel.Workbook xlWorkbook;
            XLExcel.Worksheet xlWorksheetData;
            XLExcel.Range xlRange;

            object misValue = System.Reflection.Missing.Value;
            xlApplication = new XLExcel.Application();

            xlWorkbook = xlApplication.Workbooks.Add(misValue);
            xlWorksheetData = (XLExcel.Worksheet)xlWorkbook.Worksheets[1];
            xlWorksheetData.Name = "Control Transmisiones";

            String posPrimeraColumna = "A";
            String posUltimaColumna = "R";


            xlApplication.Visible = true;

            try
            {

                #region [ ENCABEZADO ]
                /************************ ENCABEZADO DEL REPORTE **********************/
                String _ruta = Path.Combine(System.Windows.Forms.Application.StartupPath, @"Resources\\logoDelfin2.png");
                System.Drawing.Image logoDelfin = System.Drawing.Image.FromFile(_ruta);
                xlWorksheetData.Shapes.AddPicture(_ruta, Microsoft.Office.Core.MsoTriState.msoFalse, Microsoft.Office.Core.MsoTriState.msoCTrue, 3f, 3f, 175, 95);
                xlRange = xlWorksheetData.Range["A1:C6"];
                xlRange = xlWorksheetData.Range["D1:P6"];
                SetValueHeader(xlRange, "FORMATO");

                xlRange = xlWorksheetData.Range["Q2"];
                SetValueCell(xlRange, "CODIGO: ");
                xlRange = xlWorksheetData.Range["R2"];
                SetValueCell(xlRange, "F-OPE-04");
                xlRange = xlWorksheetData.Range["Q4"];
                SetValueCell(xlRange, "VIGENCIA: ");
                xlRange = xlWorksheetData.Range["R4"];
                SetValueCell(xlRange, "30/03/2012");
                xlRange = xlWorksheetData.Range["Q6"];
                SetValueCell(xlRange, "REVISION: ");
                xlRange = xlWorksheetData.Range["R6"];
                SetValueCell(xlRange, "01");
                xlRange = xlWorksheetData.Range["A7:R7"];
                SetValueHeader(xlRange, "CONTROL DE TRANSMISIONES");

                xlRange = xlWorksheetData.Range[String.Format("{0}1:{1}7", posPrimeraColumna, posUltimaColumna)];
                setBorderCelda(xlRange, XLExcel.XlBorderWeight.xlThick, XLExcel.XlLineStyle.xlContinuous, true, true, true, true, true, true, true, false, false);

                xlRange = xlWorksheetData.Range["A11:B11"];
                SetValueHeader(xlRange, "Importacion Maritima");
                xlRange = xlWorksheetData.Range["C11"];
                SetValueCell(xlRange, "1");
                xlRange = xlWorksheetData.Range["A12:B12"];
                SetValueHeader(xlRange, "Importacion Aerea");
                xlRange = xlWorksheetData.Range["C12"];
                SetValueCell(xlRange, "2");
                xlRange = xlWorksheetData.Range["A13:B13"];
                SetValueHeader(xlRange, "Exportacion");
                xlRange = xlWorksheetData.Range["C13"];
                SetValueCell(xlRange, "3");

                xlRange = xlWorksheetData.Range["A11:C13"];
                setBorderCelda(xlRange, XLExcel.XlBorderWeight.xlThin, XLExcel.XlLineStyle.xlContinuous, true, true, true, true, true, true, true, false, false);

                xlRange = xlWorksheetData.Range["A9:C10"];
                SetValueHeader(xlRange, "LEYENDA");
                setBorderCelda(xlRange, XLExcel.XlBorderWeight.xlThick, XLExcel.XlLineStyle.xlContinuous, true, true, true, true, true, false, false, false, false);
                xlRange.Interior.Color = System.Drawing.ColorTranslator.FromHtml("#99cc00");
                /**********************************************************************/
                #endregion

                #region [ CAMPOS PARA FORMULA ]
                /********************** FECHA Y HORA LIMITE***********************/
                xlRange = xlWorksheetData.Range["E11"];
                SetValueCell(xlRange, "23:59:00");
                xlRange = xlWorksheetData.Range["E12"];
                SetValueCell(xlRange, "95:59:00");
                xlRange = xlWorksheetData.Range["F11"];
                SetValueCell(xlRange, "2:01:00");
                xlRange = xlWorksheetData.Range["F12"];
                SetValueCell(xlRange, "48:01:00");
                xlRange = xlWorksheetData.Range["E11:F12"];
                xlRange.NumberFormat = "[h]:mm:ss";
                xlRange.Font.Color = System.Drawing.Color.White;

                xlRange = xlWorksheetData.Range["E13"];
                SetValueCell(xlRange, "SI");
                xlRange = xlWorksheetData.Range["F13"];
                SetValueCell(xlRange, "NO");
                xlRange = xlWorksheetData.Range["E13:F13"];
                xlRange.NumberFormat = "d/mm/yyyy h:mm";
                xlRange.Font.Color = System.Drawing.Color.White;

                /***************************************************************/

                /******************** MONTO UIT **********************/
                xlRange = xlWorksheetData.Range["Q11"];
                SetValueHeader(xlRange, "UIT S/");
                setBorderCelda(xlRange, XLExcel.XlBorderWeight.xlThick, XLExcel.XlLineStyle.xlContinuous, true, true, true, true, true, false, false, false, false);
                xlRange.Interior.Color = System.Drawing.ColorTranslator.FromHtml("#99cc00");
                xlRange = xlWorksheetData.Range["R11"];
                SetValueHeader(xlRange, "3850");
                setBorderCelda(xlRange, XLExcel.XlBorderWeight.xlThick, XLExcel.XlLineStyle.xlContinuous, true, true, true, true, true, false, false, false, false);
                xlRange.NumberFormat = "#,##0.000";
                /*****************************************************/

                /****************** TIPO LETRA ***********************/
                xlRange = xlWorksheetData.Range["A1:R13"];
                xlRange.Font.Name = "Arial";
                xlRange.Font.Size = 10;
                /*****************************************************/
                #endregion

                #region [ CUERPO ]
                /*********************** CUERPO DEL REPORTE ***************************/
                Int32 posPrimeraFila = 17;
                Int32 posUltimaFila = 17 + (DtControlTransmisiones.Rows.Count - 1);

                /*************************************** LLENAR CUERPO ********************************************/
                object[,] datosControlTransmisiones = new object[DtControlTransmisiones.Rows.Count, DtControlTransmisiones.Columns.Count];
                for (int f = 0; f < DtControlTransmisiones.Rows.Count; f++)
                {
                    for (int c = 0; c < DtControlTransmisiones.Columns.Count; c++)
                    {
                        if (DtControlTransmisiones.Rows[f][c] != DBNull.Value)
                        {
                            if (DtControlTransmisiones.Rows[f][c].GetType() == System.Type.GetType("System.DateTime"))
                            { datosControlTransmisiones[f, c] = DtControlTransmisiones.Rows[f][c]; }
                            else
                            { datosControlTransmisiones[f, c] = DtControlTransmisiones.Rows[f][c].ToString(); }
                        }

                    }
                }
                xlRange = xlWorksheetData.Range[String.Format("{0}{1}:{2}{3}", posPrimeraColumna, posPrimeraFila, "H", posUltimaFila)];
                xlRange.Value2 = datosControlTransmisiones;
                /**************************************************************************************************/

                /******************************** FORMATO COLUMNAS ************************************************/
                String _formula = String.Empty;
                xlRange = xlWorksheetData.Range[String.Format("{0}{1}:{0}{2}", "E", posPrimeraFila, posUltimaFila)];
                xlRange.NumberFormat = "dd/mm/yy";
                xlRange = xlWorksheetData.Range[String.Format("{0}{1}:{0}{2}", "F", posPrimeraFila, posUltimaFila)];
                xlRange.NumberFormat = "hh:mm";
                xlRange = xlWorksheetData.Range[String.Format("{0}{1}:{0}{2}", "J", posPrimeraFila, posUltimaFila)];
                xlRange.NumberFormat = "dd/mm/yy";
                xlRange = xlWorksheetData.Range[String.Format("{0}{1}:{0}{2}", "K", posPrimeraFila, posUltimaFila)];
                xlRange.NumberFormat = "hh:mm";
                xlRange = xlWorksheetData.Range[String.Format("{0}{1}:{0}{2}", "L", posPrimeraFila, posUltimaFila)];
                xlRange.NumberFormat = "dd/mm/yy";
                xlRange = xlWorksheetData.Range[String.Format("{0}{1}:{0}{2}", "M", posPrimeraFila, posUltimaFila)];
                xlRange.NumberFormat = "hh:mm";
                xlRange = xlWorksheetData.Range[String.Format("{0}{1}:{0}{2}", "N", posPrimeraFila, posUltimaFila)];
                xlRange.NumberFormat = "dd/mm/yy";
                xlRange = xlWorksheetData.Range[String.Format("{0}{1}:{0}{2}", "O", posPrimeraFila, posUltimaFila)];
                xlRange.NumberFormat = "hh:mm";

                //Datos Ocultos
                xlRange = xlWorksheetData.Range[String.Format("{0}{1}:{0}{2}", "Y", posPrimeraFila, posUltimaFila)];
                _formula = String.Format("=E{0}+F{0}", posPrimeraFila);
                xlRange.Formula = _formula;
                xlRange.Columns.AutoFit();
                xlRange.NumberFormat = "d/mm/yyyy h:mm";
                xlRange.Font.Color = System.Drawing.Color.White;
                xlRange = xlWorksheetData.Range[String.Format("{0}{1}:{0}{2}", "X", posPrimeraFila, posUltimaFila)];
                _formula = String.Format("=IF(D{0}=3,I{0},IF(N17=\"\",\"\",((N{0}+O{0})+$E$11)))", posPrimeraFila);
                xlRange.Formula = _formula;
                xlRange.Columns.AutoFit();
                xlRange.NumberFormat = "d/mm/yyyy h:mm";
                xlRange.Font.Color = System.Drawing.Color.White;
                xlRange = xlWorksheetData.Range[String.Format("{0}{1}:{0}{2}", "W", posPrimeraFila, posUltimaFila)];
                _formula = String.Format("=IF(L{0}=\"\",\"\",L{0}+M{0})", posPrimeraFila);
                xlRange.Formula = _formula;
                xlRange.Columns.AutoFit();
                xlRange.NumberFormat = "d/mm/yyyy h:mm";
                xlRange.Font.Color = System.Drawing.Color.White;
                xlRange = xlWorksheetData.Range[String.Format("{0}{1}:{0}{2}", "V", posPrimeraFila, posUltimaFila)];
                _formula = String.Format("=IF(J{0}=\"\",\"\",J{0}+K{0})", posPrimeraFila);
                xlRange.Formula = _formula;
                xlRange.Columns.AutoFit();
                xlRange.NumberFormat = "dd/mm/yy h:mm";
                xlRange.Font.Color = System.Drawing.Color.White;
                xlRange = xlWorksheetData.Range[String.Format("{0}{1}:{0}{2}", "U", posPrimeraFila, posUltimaFila)];
                _formula = String.Format("=IF(J{0}=\"\",\"\",IF(V{0}>I{0},$E$13,$F$13))", posPrimeraFila);
                xlRange.Formula = _formula;
                xlRange.Columns.AutoFit();
                xlRange.Font.Color = System.Drawing.Color.White;
                xlRange = xlWorksheetData.Range[String.Format("{0}{1}:{0}{2}", "T", posPrimeraFila, posUltimaFila)];
                _formula = String.Format("=IF(W{0}=\"\",\"\",IF(W{0}>X{0},$E$13,$F$13))", posPrimeraFila);
                xlRange.Formula = _formula;
                xlRange.Columns.AutoFit();
                xlRange.Font.Color = System.Drawing.Color.White;
                //Formulas Visibles
                xlRange = xlWorksheetData.Range[String.Format("{0}{1}:{0}{2}", "Q", posPrimeraFila, posUltimaFila)];
                _formula = String.Format("=IF(U{0}=\"\",\"\",IF(U{0}=$E$13,$E$13,IF(T{0}=$E$13,$E$13,$F$13)))", posPrimeraFila);
                xlRange.Formula = _formula;
                xlRange.Columns.AutoFit();
                xlRange.NumberFormat = "dd/mm h:mm";
                xlRange = xlWorksheetData.Range[String.Format("{0}{1}:{0}{2}", "P", posPrimeraFila, posUltimaFila)];
                _formula = String.Format("=IF(D{0}=3,I{0},IF(N{0}=\"\",\"\",(N{0}+O{0})+$E$11))", posPrimeraFila);
                xlRange.Formula = _formula;
                xlRange.Columns.AutoFit();
                xlRange.NumberFormat = "dd/mm h:mm";
                xlRange = xlWorksheetData.Range[String.Format("{0}{1}:{0}{2}", "I", posPrimeraFila, posUltimaFila)];
                _formula = String.Format("=IF(D{0}=\"\",\"\",IF(D{0}=1,Y{0}-$F$12,IF(D{0}=2,Y{0}-$F$11,IF(D{0}=3,Y{0}+$E$12,0))))", posPrimeraFila);
                xlRange.Formula = _formula;
                xlRange.Columns.AutoFit();
                xlRange.NumberFormat = "dd/mm h:mm";
                xlRange = xlWorksheetData.Range[String.Format("{0}{1}:{0}{2}", "R", posPrimeraFila, posUltimaFila)];
                _formula = String.Format("=IF(U{0}=$E$13,IF(T{0}=$E$13,(R$11*10%)+($R$11*1%),$R$11*10%),IF(T{0}=$E$13,$R$11*1%,0))", posPrimeraFila);
                xlRange.Formula = _formula;
                xlRange.Columns.AutoFit();
                xlRange.NumberFormat = "#,##0.000";
                /**************************************************************************************************/

                /*************************************** BORDES Y ESTILOS *****************************************/
                xlRange = xlWorksheetData.Range[String.Format("{0}{1}:{2}{3}", posPrimeraColumna, posPrimeraFila, posUltimaColumna, posUltimaFila)];
                xlRange.WrapText = true;
                xlRange.Font.Bold = false;
                xlRange.Font.Name = "Calibri";
                xlRange.Font.Size = 10;
                xlRange.VerticalAlignment = XLExcel.XlVAlign.xlVAlignCenter;
                xlRange.HorizontalAlignment = XLExcel.XlHAlign.xlHAlignCenter;
                setBorderCelda(xlRange, XLExcel.XlBorderWeight.xlThin, XLExcel.XlLineStyle.xlContinuous, true, true, true, true, true, true, true, false, false);
                /**************************************************************************************************/

                /**********************************************************************/
                #endregion

                #region [ CABECERA ]
                /************************ CABECERA DEL REPORTE ************************/
                xlRange = xlWorksheetData.Range["A15:A16"];
                SetValueHeader(xlRange, "Q");

                xlRange = xlWorksheetData.Range["B15:B16"];
                SetValueHeader(xlRange, "NAVE");

                xlRange = xlWorksheetData.Range["C15:C16"];
                SetValueHeader(xlRange, "VIAJE");

                xlRange = xlWorksheetData.Range["D15:D16"];
                SetValueHeader(xlRange, "TIPO");

                xlRange = xlWorksheetData.Range["E15:E16"];
                SetValueHeader(xlRange, "FEC. LLEGADA - TERM. EMBARQUE");

                xlRange = xlWorksheetData.Range["F15:F16"];
                SetValueHeader(xlRange, "HORA DE LLEGADA");

                xlRange = xlWorksheetData.Range["G15:G16"];
                SetValueHeader(xlRange, "MANIFIESTO");

                xlRange = xlWorksheetData.Range["H15:H16"];
                SetValueHeader(xlRange, "MANI. DESCONSOLIDADO");

                xlRange = xlWorksheetData.Range["I15:I16"];
                SetValueHeader(xlRange, "FECHA LIMITE");

                xlRange = xlWorksheetData.Range["J15:K15"];
                SetValueHeader(xlRange, "NUMERACION");

                xlRange = xlWorksheetData.Range["J16"];
                SetValueHeader(xlRange, "FECHA");

                xlRange = xlWorksheetData.Range["K16"];
                SetValueHeader(xlRange, "HORA");

                xlRange = xlWorksheetData.Range["L15:M15"];
                SetValueHeader(xlRange, "COMPLEMENTARIA");

                xlRange = xlWorksheetData.Range["L16"];
                SetValueHeader(xlRange, "FECHA");

                xlRange = xlWorksheetData.Range["M16"];
                SetValueHeader(xlRange, "HORA");

                xlRange = xlWorksheetData.Range["N15:O15"];
                SetValueHeader(xlRange, "AG PORTUARIA");

                xlRange = xlWorksheetData.Range["N16"];
                SetValueHeader(xlRange, "FECHA");

                xlRange = xlWorksheetData.Range["O16"];
                SetValueHeader(xlRange, "HORA");

                xlRange = xlWorksheetData.Range["P15:P16"];
                SetValueHeader(xlRange, "FECHA/HORA LIMITE");

                xlRange = xlWorksheetData.Range["Q15:Q16"];
                SetValueHeader(xlRange, "MULTA");

                xlRange = xlWorksheetData.Range["R15:R16"];
                SetValueHeader(xlRange, "COSTO S/");

                xlRange = xlWorksheetData.Range[String.Format("{0}15:{1}16", posPrimeraColumna, posUltimaColumna)];
                xlRange.WrapText = true;
                xlRange.Interior.Color = System.Drawing.ColorTranslator.FromHtml("#9bc2e6");
                xlRange.Font.Name = "Calibri";
                xlRange.Font.Size = 10;
                setBorderCelda(xlRange, XLExcel.XlBorderWeight.xlThick, XLExcel.XlLineStyle.xlContinuous, true, true, true, true, true, true, true, false, false);
                /**********************************************************************/
                #endregion

                //xlApplication.Visible = true;

                releaseObject(xlWorksheetData);
                releaseObject(xlWorkbook);
                releaseObject(xlApplication);

            }
            catch (Exception ex)
            {
                releaseObject(xlWorksheetData);
                releaseObject(xlWorkbook);
                releaseObject(xlApplication);

                throw ex;
            }
        }

        private void SetValue(XLExcel.Range xlRange, Object xlValue, Boolean xlMergeCells = false, XLExcel.XlVAlign xlVAlign = XLExcel.XlVAlign.xlVAlignCenter, XLExcel.XlHAlign xlHAlign = XLExcel.XlHAlign.xlHAlignCenter, Boolean xlBold = false, Boolean xlUnderline = false)//String xlFontName, Int32 xlFontSize,
        {
            xlRange.MergeCells = xlMergeCells;
            xlRange.Value = xlValue;
            //xlRange.Font.Name = xlFontName;
            //xlRange.Font.Size = xlFontSize;
            xlRange.Font.Bold = xlBold;
            xlRange.Font.Underline = xlUnderline;
            xlRange.VerticalAlignment = xlVAlign;
            xlRange.HorizontalAlignment = xlHAlign;
        }
        private void SetValueHeader(XLExcel.Range xlRange, Object xlValue, Boolean xlMergeCells = true, XLExcel.XlVAlign xlVAlign = XLExcel.XlVAlign.xlVAlignCenter, XLExcel.XlHAlign xlHAlign = XLExcel.XlHAlign.xlHAlignCenter, Boolean xlBold = true, Boolean xlUnderline = false)//String xlFontName, Int32 xlFontSize,
        { SetValue(xlRange, xlValue, xlMergeCells, xlVAlign, xlHAlign, xlBold, xlUnderline); }// xlFontName, xlFontSize
        private void SetValueCell(XLExcel.Range xlRange, Object xlValue, Boolean xlMergeCells = false, XLExcel.XlVAlign xlVAlign = XLExcel.XlVAlign.xlVAlignTop, XLExcel.XlHAlign xlHAlign = XLExcel.XlHAlign.xlHAlignLeft, Boolean xlBold = false, Boolean xlUnderline = false)//String xlFontName, Int32 xlFontSize;
        { SetValue(xlRange, xlValue, xlMergeCells, xlVAlign, xlHAlign, xlBold, xlUnderline); }//, xlFontName, xlFontSize

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
    }
}