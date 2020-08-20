using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.IO;
using XLExcel = Microsoft.Office.Interop.Excel;
using System.Runtime.InteropServices;
using System.IO;
using Infrastructure.WinForms.Controls;
using Delfin.Principal.Reportes;
using Infrastructure.Aspect.Extensions;
using System.Collections.ObjectModel;

namespace Delfin.Principal
{
   public partial class OPE001Presenter
   {
      #region [ Exportar Matriz Draft ]
      private const String xlFont = "Calibri";
      private const Int32 xlFontSize = 11;
      private Int32 XLRows;

      public void ExportarMatrizDraft()
      {
         //XLExcel.Application xlApplication;
         //XLExcel.Workbook xlWorkbook;
         //XLExcel.Worksheet xlWorksheet;
         //XLExcel.Range xlRange;

         //object misValue = System.Reflection.Missing.Value;

         //xlApplication = new XLExcel.Application();
         //xlWorkbook = xlApplication.Workbooks.Add(misValue);
         //xlWorksheet = (XLExcel.Worksheet)xlWorkbook.Worksheets[1];

         try
         {
            if (Guardar(false, false, false))
            {
               ExportarMatrizDraft(Item, ListPaquetes, ListTiposPAC);

               //xlWorksheet.Columns["A:A"].ColumnWidth = 25;
               //xlWorksheet.Columns["B:B"].ColumnWidth = 25;
               //xlWorksheet.Columns["C:C"].ColumnWidth = 25;
               //xlWorksheet.Columns["D:D"].ColumnWidth = 25;
               //xlWorksheet.Columns["E:E"].ColumnWidth = 25;
               //xlWorksheet.Columns["F:F"].ColumnWidth = 25;
               //xlWorksheet.Columns["G:G"].ColumnWidth = 25;
               //xlWorksheet.Columns["H:H"].ColumnWidth = 25;

               //xlWorksheet.Rows["1:1"].RowHeight = 75;
               //xlWorksheet.Rows["2:2"].RowHeight = 16.5;
               //xlWorksheet.Rows["3:3"].RowHeight = 75;
               //xlWorksheet.Rows["4:4"].RowHeight = 16.5;
               //xlWorksheet.Rows["5:5"].RowHeight = 75;
               //xlWorksheet.Rows["6:6"].RowHeight = 16.5;
               //xlWorksheet.Rows["7:7"].RowHeight = 37.5;
               //xlWorksheet.Rows["8:8"].RowHeight = 16.5;
               //xlWorksheet.Rows["9:9"].RowHeight = 37.5;
               //xlWorksheet.Rows["10:10"].RowHeight = 16.5;
               //xlWorksheet.Rows["31:31"].RowHeight = 16.5;

               //xlRange = xlWorksheet.Range["A1:B1"];
               //SetValueHeader(xlRange, "FCL");
               //setBorderCelda(xlRange, XLExcel.XlBorderWeight.xlThick, XLExcel.XlLineStyle.xlContinuous, true, true, true, true, true, false, false, false, false);
               //xlRange = xlWorksheet.Range["C1:F1"];
               //SetValueHeader(xlRange, "DRAFT MATRIZ HBL");
               //setBorderCelda(xlRange, XLExcel.XlBorderWeight.xlThick, XLExcel.XlLineStyle.xlContinuous, true, true, true, true, true, false, false, false, false);
               //xlRange = xlWorksheet.Range["G1:H1"];
               //SetValueHeader(xlRange, "");
               //setBorderCelda(xlRange, XLExcel.XlBorderWeight.xlThick, XLExcel.XlLineStyle.xlContinuous, true, true, true, true, true, false, false, false, false);

               //xlRange = xlWorksheet.Range["A2:D2"];
               //SetValueHeader(xlRange, "SHIPPER");
               //setBorderCelda(xlRange, XLExcel.XlBorderWeight.xlThick, XLExcel.XlLineStyle.xlContinuous, true, true, true, true, true, false, false, false, false);
               //xlRange = xlWorksheet.Range["E2:H2"];
               //SetValueHeader(xlRange, "BOOKING N°");
               //setBorderCelda(xlRange, XLExcel.XlBorderWeight.xlThick, XLExcel.XlLineStyle.xlContinuous, true, true, true, true, true, false, false, false, false);

               //xlRange = xlWorksheet.Range["A3:D3"];
               //SetValueCell(xlRange, Item.DDOV_DescShipper, true);
               //setBorderCelda(xlRange, XLExcel.XlBorderWeight.xlThick, XLExcel.XlLineStyle.xlContinuous, true, true, true, true, true, false, false, false, false);
               //xlRange = xlWorksheet.Range["E3:H3"];
               //SetValueCell(xlRange, Item.DDOV_NroBooking, true);
               //setBorderCelda(xlRange, XLExcel.XlBorderWeight.xlThick, XLExcel.XlLineStyle.xlContinuous, true, true, true, true, true, false, false, false, false);

               //xlRange = xlWorksheet.Range["A4:D4"];
               //SetValueHeader(xlRange, "CONSIGNEE");
               //setBorderCelda(xlRange, XLExcel.XlBorderWeight.xlThick, XLExcel.XlLineStyle.xlContinuous, true, true, true, true, true, false, false, false, false);
               //xlRange = xlWorksheet.Range["E4:H4"];
               //SetValueHeader(xlRange, "NOTIFY");
               //setBorderCelda(xlRange, XLExcel.XlBorderWeight.xlThick, XLExcel.XlLineStyle.xlContinuous, true, true, true, true, true, false, false, false, false);               

               //xlRange = xlWorksheet.Range["A5:D5"];
               //SetValueCell(xlRange, Item.DDOV_DescConsignee, true);
               //setBorderCelda(xlRange, XLExcel.XlBorderWeight.xlThick, XLExcel.XlLineStyle.xlContinuous, true, true, true, true, true, false, false, false, false);
               //xlRange = xlWorksheet.Range["E5:H7"];
               //SetValueCell(xlRange, Item.DDOV_DescNotify, true);
               //setBorderCelda(xlRange, XLExcel.XlBorderWeight.xlThick, XLExcel.XlLineStyle.xlContinuous, true, true, true, true, true, false, false, false, false);

               //xlRange = xlWorksheet.Range["A6:B6"];
               //SetValueHeader(xlRange, "OCEAN VESSEL / VOY. N°");
               //setBorderCelda(xlRange, XLExcel.XlBorderWeight.xlThick, XLExcel.XlLineStyle.xlContinuous, true, true, true, true, true, false, false, false, false);
               //xlRange = xlWorksheet.Range["C6:D6"];
               //SetValueHeader(xlRange, "PORT OF LOADING");
               //setBorderCelda(xlRange, XLExcel.XlBorderWeight.xlThick, XLExcel.XlLineStyle.xlContinuous, true, true, true, true, true, false, false, false, false);

               //xlRange = xlWorksheet.Range["A7:B7"];
               //SetValueCell(xlRange, Item.NAVE_Nombre, true);
               //setBorderCelda(xlRange, XLExcel.XlBorderWeight.xlThick, XLExcel.XlLineStyle.xlContinuous, true, true, true, true, true, false, false, false, false);
               //xlRange = xlWorksheet.Range["C7:D7"];
               //SetValueCell(xlRange, Item.PUER_NombreOrigen, true);
               //setBorderCelda(xlRange, XLExcel.XlBorderWeight.xlThick, XLExcel.XlLineStyle.xlContinuous, true, true, true, true, true, false, false, false, false);

               //xlRange = xlWorksheet.Range["A8:D8"];
               //SetValueHeader(xlRange, "PORT OF DISCHARGE");
               //setBorderCelda(xlRange, XLExcel.XlBorderWeight.xlThick, XLExcel.XlLineStyle.xlContinuous, true, true, true, true, true, false, false, false, false);
               //xlRange = xlWorksheet.Range["E8:H8"];
               //SetValueHeader(xlRange, "MARKS");
               //setBorderCelda(xlRange, XLExcel.XlBorderWeight.xlThick, XLExcel.XlLineStyle.xlContinuous, true, true, true, true, true, false, false, false, false);

               //xlRange = xlWorksheet.Range["A9:D9"];
               //SetValueCell(xlRange, Item.PUER_NombreDestino, true);
               //setBorderCelda(xlRange, XLExcel.XlBorderWeight.xlThick, XLExcel.XlLineStyle.xlContinuous, true, true, true, true, true, false, false, false, false);
               //xlRange = xlWorksheet.Range["E9:H9"];
               //SetValueCell(xlRange, "", true);
               //setBorderCelda(xlRange, XLExcel.XlBorderWeight.xlThick, XLExcel.XlLineStyle.xlContinuous, true, true, true, true, true, false, false, false, false);


               //xlRange = xlWorksheet.Range["A10:A10"];
               //SetValueHeader(xlRange, "CONTENEDOR");
               //setBorderCelda(xlRange, XLExcel.XlBorderWeight.xlThick, XLExcel.XlLineStyle.xlContinuous, true, true, true, true, true, false, false, false, false);
               //xlRange = xlWorksheet.Range["B10:B10"];
               //SetValueHeader(xlRange, "PRECINTO");
               //setBorderCelda(xlRange, XLExcel.XlBorderWeight.xlThick, XLExcel.XlLineStyle.xlContinuous, true, true, true, true, true, false, false, false, false);
               //xlRange = xlWorksheet.Range["C10:C10"];
               //SetValueHeader(xlRange, "TIPO CONTENEDOR");
               //setBorderCelda(xlRange, XLExcel.XlBorderWeight.xlThick, XLExcel.XlLineStyle.xlContinuous, true, true, true, true, true, false, false, false, false);
               //xlRange = xlWorksheet.Range["D10:D10"];
               //SetValueHeader(xlRange, "DESCRIPCION");
               //setBorderCelda(xlRange, XLExcel.XlBorderWeight.xlThick, XLExcel.XlLineStyle.xlContinuous, true, true, true, true, true, false, false, false, false);
               //xlRange = xlWorksheet.Range["E10:E10"];
               //SetValueHeader(xlRange, "TIPO BULTO");
               //setBorderCelda(xlRange, XLExcel.XlBorderWeight.xlThick, XLExcel.XlLineStyle.xlContinuous, true, true, true, true, true, false, false, false, false);
               //xlRange = xlWorksheet.Range["F10:F10"];
               //SetValueHeader(xlRange, "BULTOS");
               //setBorderCelda(xlRange, XLExcel.XlBorderWeight.xlThick, XLExcel.XlLineStyle.xlContinuous, true, true, true, true, true, false, false, false, false);
               //xlRange = xlWorksheet.Range["G10:G10"];
               //SetValueHeader(xlRange, "PESO");
               //setBorderCelda(xlRange, XLExcel.XlBorderWeight.xlThick, XLExcel.XlLineStyle.xlContinuous, true, true, true, true, true, false, false, false, false);
               //xlRange = xlWorksheet.Range["H10:H10"];
               //SetValueHeader(xlRange, "VOLUMEN");
               //setBorderCelda(xlRange, XLExcel.XlBorderWeight.xlThick, XLExcel.XlLineStyle.xlContinuous, true, true, true, true, true, false, false, false, false);

               //xlRange = xlWorksheet.Range["A11:H30"];
               //setBorderCelda(xlRange, XLExcel.XlBorderWeight.xlThin, XLExcel.XlLineStyle.xlContinuous, true, true, true, true, true, true, true, false, false);

               //xlRange = xlWorksheet.Range["A11:H30"];
               //setBorderCelda(xlRange, XLExcel.XlBorderWeight.xlThick, XLExcel.XlLineStyle.xlContinuous, false, true, true, true, true, false, false, false, false);

               //xlRange = xlWorksheet.Range["A31:A31"];
               //SetValueHeader(xlRange, "ISSUED BY");
               //setBorderCelda(xlRange, XLExcel.XlBorderWeight.xlThick, XLExcel.XlLineStyle.xlContinuous, true, true, true, true, true, false, false, false, false);
               //xlRange = xlWorksheet.Range["B31:E31"];
               //SetValueCell(xlRange, "", true);
               //setBorderCelda(xlRange, XLExcel.XlBorderWeight.xlThick, XLExcel.XlLineStyle.xlContinuous, true, true, true, true, true, false, false, false, false);
               //xlRange = xlWorksheet.Range["F31:F31"];
               //SetValueHeader(xlRange, "DATE");
               //setBorderCelda(xlRange, XLExcel.XlBorderWeight.xlThick, XLExcel.XlLineStyle.xlContinuous, true, true, true, true, true, false, false, false, false);
               //xlRange = xlWorksheet.Range["G31:H31"];
               //SetValueCell(xlRange, "", true);
               //setBorderCelda(xlRange, XLExcel.XlBorderWeight.xlThick, XLExcel.XlLineStyle.xlContinuous, true, true, true, true, true, false, false, false, false);


               //xlApplication.Cells.Locked = true;
               //xlRange = xlWorksheet.Range["A11:H30"];
               //xlRange.Locked = false;

               //Int32 _rowIndex = 1;
               //Int32 _colIndex = 1;
               //Int32 _rowInicio= 2;
               //Int32 _rowFinal = 1;
               //String _rango = String.Empty;



               ////Formula1:="=$L$2:$L$342"

               ////J => 10    
               //_rowIndex = 1;
               //_rowInicio = 2;
               //_rowFinal = 1;
               //_colIndex = 10;
               //xlRange = xlWorksheet.Range[xlWorksheet.Cells[_rowIndex, _colIndex], xlWorksheet.Cells[_rowIndex, _colIndex]];
               //SetValueCell(xlRange, "TIPO CONTENEDOR");
               //for (int i = 0; i < ListPaquetes.Count; i++)
               //{
               //   xlRange = xlWorksheet.Range[xlWorksheet.Cells[_rowIndex + 1, _colIndex], xlWorksheet.Cells[_rowIndex + 1, _colIndex] ];
               //   SetValueCell(xlRange, String.Format("{0}-{1}", ListPaquetes[i].PACK_Codigo, ListPaquetes[i].PACK_DescC));

               //   _rowIndex += 1;
               //   _rowFinal += 1;
               //}
               //_rango = String.Format("=$J${0}:$J${1}", _rowInicio, _rowFinal);

               //xlRange = xlWorksheet.Range["C11:C30"];
               //xlRange.Validation.Delete();
               //xlRange.Validation.Add(XLExcel.XlDVType.xlValidateList, XLExcel.XlDVAlertStyle.xlValidAlertStop, XLExcel.XlFormatConditionOperator.xlBetween, _rango, misValue);
               //xlRange.Validation.IgnoreBlank = true;
               //xlRange.Validation.InCellDropdown = true;
               //xlRange.Validation.InputTitle = "TIPO CONTENEDOR";
               //xlRange.Validation.InputMessage = "Seleccionar el Tipo de Contenedor de la lista desplegable.";
               //xlRange.Validation.ErrorTitle = "TIPO CONTENEDOR";
               //xlRange.Validation.ErrorMessage = "Debe seleccionar el valor solo de la lista desplegable.";
               //xlRange.Validation.ShowInput = true;
               //xlRange.Validation.ShowError = true;

               //xlWorksheet.Columns["J:J"].Hidden = true;

               ////K => 11
               //_rowIndex = 1;
               //_rowInicio = 2;
               //_rowFinal = 1;
               //_colIndex = 11;
               //xlRange = xlWorksheet.Range[xlWorksheet.Cells[_rowIndex, _colIndex], xlWorksheet.Cells[_rowIndex, _colIndex]];
               //SetValueCell(xlRange, "TIPO BULTO");
               //for (int i = 0; i < ListTiposPAC.Count; i++)
               //{
               //   xlRange = xlWorksheet.Range[xlWorksheet.Cells[_rowIndex + 1, _colIndex], xlWorksheet.Cells[_rowIndex + 1, _colIndex]];
               //   //SetValueCell(xlRange, String.Format("{0}-{1}", ListTiposPAC[i].TIPO_CodTipo, ListTiposPAC[i].TIPO_Desc1));
               //   SetValueCell(xlRange, String.Format("{0}", ListTiposPAC[i].TIPO_Desc1));

               //   _rowIndex += 1;
               //   _rowFinal += 1;
               //}
               //_rango = String.Format("=$K${0}:$K${1}", _rowInicio, _rowFinal);

               //xlRange = xlWorksheet.Range["E11:E30"];
               //xlRange.Validation.Delete();
               //xlRange.Validation.Add(XLExcel.XlDVType.xlValidateList, XLExcel.XlDVAlertStyle.xlValidAlertStop, XLExcel.XlFormatConditionOperator.xlBetween, _rango, misValue);
               //xlRange.Validation.IgnoreBlank = true;
               //xlRange.Validation.InCellDropdown = true;
               //xlRange.Validation.InputTitle = "TIPO BULTO";
               //xlRange.Validation.InputMessage = "Seleccionar el Tipo de Bulto de la lista desplegable.";
               //xlRange.Validation.ErrorTitle = "TIPO BULTO";
               //xlRange.Validation.ErrorMessage = "Debe seleccionar el valor solo de la lista desplegable.";
               //xlRange.Validation.ShowInput = true;
               //xlRange.Validation.ShowError = true;

               //xlWorksheet.Columns["K:K"].Hidden = true;


               //xlRange = xlWorksheet.Range["F11:F30"];
               //xlRange.Validation.Delete();
               //xlRange.Validation.Add(XLExcel.XlDVType.xlValidateDecimal, XLExcel.XlDVAlertStyle.xlValidAlertStop, XLExcel.XlFormatConditionOperator.xlBetween, "0.00", "10000000.00");
               //xlRange.Validation.IgnoreBlank = true;
               //xlRange.Validation.InCellDropdown = true;
               //xlRange.Validation.InputTitle = "BULTOS";
               //xlRange.Validation.InputMessage = "Debe ingresar solo números.";
               //xlRange.Validation.ErrorTitle = "BULTOS";
               //xlRange.Validation.ErrorMessage = "Debe ingresar solo números.";
               //xlRange.Validation.ShowInput = true;
               //xlRange.Validation.ShowError = true;

               //xlRange = xlWorksheet.Range["G11:G30"];
               //xlRange.Validation.Delete();
               //xlRange.Validation.Add(XLExcel.XlDVType.xlValidateDecimal, XLExcel.XlDVAlertStyle.xlValidAlertStop, XLExcel.XlFormatConditionOperator.xlBetween, "0.00", "10000000.00");
               //xlRange.Validation.IgnoreBlank = true;
               //xlRange.Validation.InCellDropdown = true;
               //xlRange.Validation.InputTitle = "PESO";
               //xlRange.Validation.InputMessage = "Debe ingresar solo números.";
               //xlRange.Validation.ErrorTitle = "PESO";
               //xlRange.Validation.ErrorMessage = "Debe ingresar solo números.";
               //xlRange.Validation.ShowInput = true;
               //xlRange.Validation.ShowError = true;

               //xlRange = xlWorksheet.Range["H11:H30"];
               //xlRange.Validation.Delete();
               //xlRange.Validation.Add(XLExcel.XlDVType.xlValidateDecimal, XLExcel.XlDVAlertStyle.xlValidAlertStop, XLExcel.XlFormatConditionOperator.xlBetween, "0.00", "10000000.00");
               //xlRange.Validation.IgnoreBlank = true;
               //xlRange.Validation.InCellDropdown = true;
               //xlRange.Validation.InputTitle = "VOLUMEN";
               //xlRange.Validation.InputMessage = "Debe ingresar solo números.";
               //xlRange.Validation.ErrorTitle = "VOLUMEN";
               //xlRange.Validation.ErrorMessage = "Debe ingresar solo números.";
               //xlRange.Validation.ShowInput = true;
               //xlRange.Validation.ShowError = true;

               //String _password = "N3xtS0ft";
               //object object_password = (object)_password;

               //xlWorksheet.Protect(object_password, misValue, misValue, misValue, misValue, misValue, misValue, misValue, misValue, misValue, misValue, misValue, misValue, misValue, misValue, misValue);
               //xlWorkbook.Protect(object_password, misValue, misValue);

               //xlApplication.Visible = true;

            }
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Title, "Ha ocurrido un error al exportar la Matriz Draft", ex); }
         //finally
         //{
         //   if (xlWorksheet != null) { releaseObject(xlWorksheet); }
         //   if (xlWorkbook != null) { releaseObject(xlWorkbook); }
         //   if (xlApplication != null) { releaseObject(xlApplication); }
         //}
      }
      public static void ExportarMatrizDraft(Entities.Cab_Cotizacion_OV Item, ObservableCollection<Entities.Paquete> ListPaquetes, ObservableCollection<Entities.Tipos> ListTiposPAC)
      {
         XLExcel.Application xlApplication;
         XLExcel.Workbook xlWorkbook;
         XLExcel.Worksheet xlWorksheet;
         XLExcel.Range xlRange;

         object misValue = System.Reflection.Missing.Value;

         xlApplication = new XLExcel.Application();
         xlWorkbook = xlApplication.Workbooks.Add(misValue);
         xlWorksheet = (XLExcel.Worksheet)xlWorkbook.Worksheets[1];

         try
         {
            xlWorksheet.Columns["A:A"].ColumnWidth = 25;
            xlWorksheet.Columns["B:B"].ColumnWidth = 25;
            xlWorksheet.Columns["C:C"].ColumnWidth = 25;
            xlWorksheet.Columns["D:D"].ColumnWidth = 25;
            xlWorksheet.Columns["E:E"].ColumnWidth = 25;
            xlWorksheet.Columns["F:F"].ColumnWidth = 25;
            xlWorksheet.Columns["G:G"].ColumnWidth = 25 * 2;
            //xlWorksheet.Columns["H:H"].ColumnWidth = 25;

            xlWorksheet.Rows["1:1"].RowHeight = 75;
            xlWorksheet.Rows["2:2"].RowHeight = 16.5;
            xlWorksheet.Rows["3:3"].RowHeight = 75;
            xlWorksheet.Rows["4:4"].RowHeight = 16.5;
            xlWorksheet.Rows["5:5"].RowHeight = 75;
            xlWorksheet.Rows["6:6"].RowHeight = 16.5;
            xlWorksheet.Rows["7:7"].RowHeight = 37.5;
            xlWorksheet.Rows["8:8"].RowHeight = 16.5;
            xlWorksheet.Rows["9:9"].RowHeight = 37.5;
            xlWorksheet.Rows["10:10"].RowHeight = 16.5;
            xlWorksheet.Rows["31:31"].RowHeight = 16.5;

            xlRange = xlWorksheet.Range["A1:B1"];
            SetValueHeader(xlRange, "FCL");
            setBorderCelda(xlRange, XLExcel.XlBorderWeight.xlThick, XLExcel.XlLineStyle.xlContinuous, true, true, true, true, true, false, false, false, false);
            xlRange = xlWorksheet.Range["C1:F1"];
            SetValueHeader(xlRange, "DRAFT MATRIZ HBL");
            setBorderCelda(xlRange, XLExcel.XlBorderWeight.xlThick, XLExcel.XlLineStyle.xlContinuous, true, true, true, true, true, false, false, false, false);
            xlRange = xlWorksheet.Range["G1:G1"];
            SetValueHeader(xlRange, "");
            setBorderCelda(xlRange, XLExcel.XlBorderWeight.xlThick, XLExcel.XlLineStyle.xlContinuous, true, true, true, true, true, false, false, false, false);

            xlRange = xlWorksheet.Range["A2:D2"];
            SetValueHeader(xlRange, "SHIPPER");
            setBorderCelda(xlRange, XLExcel.XlBorderWeight.xlThick, XLExcel.XlLineStyle.xlContinuous, true, true, true, true, true, false, false, false, false);
            xlRange = xlWorksheet.Range["E2:G2"];
            SetValueHeader(xlRange, "BOOKING N°");
            setBorderCelda(xlRange, XLExcel.XlBorderWeight.xlThick, XLExcel.XlLineStyle.xlContinuous, true, true, true, true, true, false, false, false, false);

            xlRange = xlWorksheet.Range["A3:D3"];
            SetValueCell(xlRange, Item.DDOV_DescShipper, true);
            setBorderCelda(xlRange, XLExcel.XlBorderWeight.xlThick, XLExcel.XlLineStyle.xlContinuous, true, true, true, true, true, false, false, false, false);
            xlRange = xlWorksheet.Range["E3:G3"];
            SetValueCell(xlRange, Item.DDOV_NroBooking, true);
            setBorderCelda(xlRange, XLExcel.XlBorderWeight.xlThick, XLExcel.XlLineStyle.xlContinuous, true, true, true, true, true, false, false, false, false);

            xlRange = xlWorksheet.Range["A4:D4"];
            SetValueHeader(xlRange, "CONSIGNEE");
            setBorderCelda(xlRange, XLExcel.XlBorderWeight.xlThick, XLExcel.XlLineStyle.xlContinuous, true, true, true, true, true, false, false, false, false);
            xlRange = xlWorksheet.Range["E4:G4"];
            SetValueHeader(xlRange, "NOTIFY");
            setBorderCelda(xlRange, XLExcel.XlBorderWeight.xlThick, XLExcel.XlLineStyle.xlContinuous, true, true, true, true, true, false, false, false, false);

            xlRange = xlWorksheet.Range["A5:D5"];
            SetValueCell(xlRange, Item.DDOV_DescConsignee, true);
            setBorderCelda(xlRange, XLExcel.XlBorderWeight.xlThick, XLExcel.XlLineStyle.xlContinuous, true, true, true, true, true, false, false, false, false);
            xlRange = xlWorksheet.Range["E5:G5"];
            SetValueCell(xlRange, Item.DDOV_DescNotify, true);
            setBorderCelda(xlRange, XLExcel.XlBorderWeight.xlThick, XLExcel.XlLineStyle.xlContinuous, true, true, true, true, true, false, false, false, false);

            xlRange = xlWorksheet.Range["A6:B6"];
            SetValueHeader(xlRange, "OCEAN VESSEL / VOY. N°");
            setBorderCelda(xlRange, XLExcel.XlBorderWeight.xlThick, XLExcel.XlLineStyle.xlContinuous, true, true, true, true, true, false, false, false, false);
            xlRange = xlWorksheet.Range["C6:D6"];
            SetValueHeader(xlRange, "PORT OF LOADING");
            setBorderCelda(xlRange, XLExcel.XlBorderWeight.xlThick, XLExcel.XlLineStyle.xlContinuous, true, true, true, true, true, false, false, false, false);
            xlRange = xlWorksheet.Range["E6:G6"];
            SetValueHeader(xlRange, "DESCRIPCIÓN");
            setBorderCelda(xlRange, XLExcel.XlBorderWeight.xlThick, XLExcel.XlLineStyle.xlContinuous, true, true, true, true, true, false, false, false, false);

            xlRange = xlWorksheet.Range["A7:B7"];
            SetValueCell(xlRange, Item.NAVE_Nombre, true);
            setBorderCelda(xlRange, XLExcel.XlBorderWeight.xlThick, XLExcel.XlLineStyle.xlContinuous, true, true, true, true, true, false, false, false, false);
            xlRange = xlWorksheet.Range["C7:D7"];
            SetValueCell(xlRange, Item.PUER_NombreOrigen, true);
            setBorderCelda(xlRange, XLExcel.XlBorderWeight.xlThick, XLExcel.XlLineStyle.xlContinuous, true, true, true, true, true, false, false, false, false);
            xlRange = xlWorksheet.Range["E7:G7"];
            SetValueCell(xlRange, "", true);
            setBorderCelda(xlRange, XLExcel.XlBorderWeight.xlThick, XLExcel.XlLineStyle.xlContinuous, true, true, true, true, true, false, false, false, false);

            xlRange = xlWorksheet.Range["A8:D8"];
            SetValueHeader(xlRange, "PORT OF DISCHARGE");
            setBorderCelda(xlRange, XLExcel.XlBorderWeight.xlThick, XLExcel.XlLineStyle.xlContinuous, true, true, true, true, true, false, false, false, false);
            xlRange = xlWorksheet.Range["E8:G8"];
            SetValueHeader(xlRange, "MARKS");
            setBorderCelda(xlRange, XLExcel.XlBorderWeight.xlThick, XLExcel.XlLineStyle.xlContinuous, true, true, true, true, true, false, false, false, false);

            xlRange = xlWorksheet.Range["A9:D9"];
            SetValueCell(xlRange, Item.PUER_NombreDestino, true);
            setBorderCelda(xlRange, XLExcel.XlBorderWeight.xlThick, XLExcel.XlLineStyle.xlContinuous, true, true, true, true, true, false, false, false, false);
            xlRange = xlWorksheet.Range["E9:G9"];
            SetValueCell(xlRange, "", true);
            setBorderCelda(xlRange, XLExcel.XlBorderWeight.xlThick, XLExcel.XlLineStyle.xlContinuous, true, true, true, true, true, false, false, false, false);


            xlRange = xlWorksheet.Range["A10:A10"];
            SetValueHeader(xlRange, "CONTENEDOR");
            setBorderCelda(xlRange, XLExcel.XlBorderWeight.xlThick, XLExcel.XlLineStyle.xlContinuous, true, true, true, true, true, false, false, false, false);
            xlRange = xlWorksheet.Range["B10:B10"];
            SetValueHeader(xlRange, "PRECINTO");
            setBorderCelda(xlRange, XLExcel.XlBorderWeight.xlThick, XLExcel.XlLineStyle.xlContinuous, true, true, true, true, true, false, false, false, false);
            xlRange = xlWorksheet.Range["C10:C10"];
            SetValueHeader(xlRange, "TIPO CONTENEDOR");
            setBorderCelda(xlRange, XLExcel.XlBorderWeight.xlThick, XLExcel.XlLineStyle.xlContinuous, true, true, true, true, true, false, false, false, false);
            //xlRange = xlWorksheet.Range["D10:D10"];
            //SetValueHeader(xlRange, "DESCRIPCION");
            //setBorderCelda(xlRange, XLExcel.XlBorderWeight.xlThick, XLExcel.XlLineStyle.xlContinuous, true, true, true, true, true, false, false, false, false);
            xlRange = xlWorksheet.Range["D10:D10"];
            SetValueHeader(xlRange, "TIPO BULTO");
            setBorderCelda(xlRange, XLExcel.XlBorderWeight.xlThick, XLExcel.XlLineStyle.xlContinuous, true, true, true, true, true, false, false, false, false);
            xlRange = xlWorksheet.Range["E10:E10"];
            SetValueHeader(xlRange, "BULTOS");
            setBorderCelda(xlRange, XLExcel.XlBorderWeight.xlThick, XLExcel.XlLineStyle.xlContinuous, true, true, true, true, true, false, false, false, false);
            xlRange = xlWorksheet.Range["F10:F10"];
            SetValueHeader(xlRange, "PESO");
            setBorderCelda(xlRange, XLExcel.XlBorderWeight.xlThick, XLExcel.XlLineStyle.xlContinuous, true, true, true, true, true, false, false, false, false);
            xlRange = xlWorksheet.Range["G10:G10"];
            SetValueHeader(xlRange, "VOLUMEN");
            setBorderCelda(xlRange, XLExcel.XlBorderWeight.xlThick, XLExcel.XlLineStyle.xlContinuous, true, true, true, true, true, false, false, false, false);

            xlRange = xlWorksheet.Range["A11:G30"];
            setBorderCelda(xlRange, XLExcel.XlBorderWeight.xlThin, XLExcel.XlLineStyle.xlContinuous, true, true, true, true, true, true, true, false, false);

            xlRange = xlWorksheet.Range["A11:G30"];
            setBorderCelda(xlRange, XLExcel.XlBorderWeight.xlThick, XLExcel.XlLineStyle.xlContinuous, false, true, true, true, true, false, false, false, false);

            xlRange = xlWorksheet.Range["A31:A31"];
            SetValueHeader(xlRange, "ISSUED BY");
            setBorderCelda(xlRange, XLExcel.XlBorderWeight.xlThick, XLExcel.XlLineStyle.xlContinuous, true, true, true, true, true, false, false, false, false);
            xlRange = xlWorksheet.Range["B31:E31"];
            SetValueCell(xlRange, "", true);
            setBorderCelda(xlRange, XLExcel.XlBorderWeight.xlThick, XLExcel.XlLineStyle.xlContinuous, true, true, true, true, true, false, false, false, false);
            xlRange = xlWorksheet.Range["F31:F31"];
            SetValueHeader(xlRange, "DATE");
            setBorderCelda(xlRange, XLExcel.XlBorderWeight.xlThick, XLExcel.XlLineStyle.xlContinuous, true, true, true, true, true, false, false, false, false);
            xlRange = xlWorksheet.Range["G31:G31"];
            SetValueCell(xlRange, "", true);
            setBorderCelda(xlRange, XLExcel.XlBorderWeight.xlThick, XLExcel.XlLineStyle.xlContinuous, true, true, true, true, true, false, false, false, false);


            xlApplication.Cells.Locked = true;

            xlRange = xlWorksheet.Range["A3:D3"];
            xlRange.Locked = false;

            xlRange = xlWorksheet.Range["E3:G3"];
            xlRange.Locked = false;

            xlRange = xlWorksheet.Range["A5:D5"];
            xlRange.Locked = false;

            xlRange = xlWorksheet.Range["E5:G7"];
            xlRange.Locked = false;

            xlRange = xlWorksheet.Range["A7:B7"];
            xlRange.Locked = false;

            xlRange = xlWorksheet.Range["C7:D7"];
            xlRange.Locked = false;

            xlRange = xlWorksheet.Range["A9:D9"];
            xlRange.Locked = false;

            xlRange = xlWorksheet.Range["E9:G9"];
            xlRange.Locked = false;

            xlRange = xlWorksheet.Range["A11:G30"];
            xlRange.Locked = false;

            Int32 _rowIndex = 1;
            Int32 _colIndex = 1;
            Int32 _rowInicio = 2;
            Int32 _rowFinal = 1;
            String _rango = String.Empty;



            //Formula1:="=$L$2:$L$342"

            //J => 10    
            _rowIndex = 1;
            _rowInicio = 2;
            _rowFinal = 1;
            _colIndex = 10;
            xlRange = xlWorksheet.Range[xlWorksheet.Cells[_rowIndex, _colIndex], xlWorksheet.Cells[_rowIndex, _colIndex]];
            SetValueCell(xlRange, "TIPO CONTENEDOR");

            for (int i = 0; i < ListPaquetes.Count; i++)
            {
               xlRange = xlWorksheet.Range[xlWorksheet.Cells[_rowIndex + 1, _colIndex], xlWorksheet.Cells[_rowIndex + 1, _colIndex]];
               SetValueCell(xlRange, String.Format("{0}-{1}", ListPaquetes[i].PACK_Codigo, ListPaquetes[i].PACK_DescC));

               _rowIndex += 1;
               _rowFinal += 1;
            }
            _rango = String.Format("=$J${0}:$J${1}", _rowInicio, _rowFinal);

            xlRange = xlWorksheet.Range["C11:C30"];
            xlRange.Validation.Delete();
            xlRange.Validation.Add(XLExcel.XlDVType.xlValidateList, XLExcel.XlDVAlertStyle.xlValidAlertStop, XLExcel.XlFormatConditionOperator.xlBetween, _rango, misValue);
            xlRange.Validation.IgnoreBlank = true;
            xlRange.Validation.InCellDropdown = true;
            xlRange.Validation.InputTitle = "TIPO CONTENEDOR";
            xlRange.Validation.InputMessage = "Seleccionar el Tipo de Contenedor de la lista desplegable.";
            xlRange.Validation.ErrorTitle = "TIPO CONTENEDOR";
            xlRange.Validation.ErrorMessage = "Debe seleccionar el valor solo de la lista desplegable.";
            xlRange.Validation.ShowInput = true;
            xlRange.Validation.ShowError = true;

            xlWorksheet.Columns["J:J"].Hidden = true;

            //K => 11
            _rowIndex = 1;
            _rowInicio = 2;
            _rowFinal = 1;
            _colIndex = 11;
            xlRange = xlWorksheet.Range[xlWorksheet.Cells[_rowIndex, _colIndex], xlWorksheet.Cells[_rowIndex, _colIndex]];
            SetValueCell(xlRange, "TIPO BULTO");
            ObservableCollection<Entities.Tipos> _listTiposPAC = new ObservableCollection<Entities.Tipos>(ListTiposPAC.OrderBy(pac => pac.TIPO_Desc1));
            for (int i = 0; i < _listTiposPAC.Count; i++)
            {
               xlRange = xlWorksheet.Range[xlWorksheet.Cells[_rowIndex + 1, _colIndex], xlWorksheet.Cells[_rowIndex + 1, _colIndex]];
               //SetValueCell(xlRange, String.Format("{0}-{1}", ListTiposPAC[i].TIPO_CodTipo, ListTiposPAC[i].TIPO_Desc1));
               SetValueCell(xlRange, String.Format("{0}", _listTiposPAC[i].TIPO_Desc1));

               _rowIndex += 1;
               _rowFinal += 1;
            }
            _rango = String.Format("=$K${0}:$K${1}", _rowInicio, _rowFinal);

            xlRange = xlWorksheet.Range["D11:D30"];
            xlRange.Validation.Delete();
            xlRange.Validation.Add(XLExcel.XlDVType.xlValidateList, XLExcel.XlDVAlertStyle.xlValidAlertStop, XLExcel.XlFormatConditionOperator.xlBetween, _rango, misValue);
            xlRange.Validation.IgnoreBlank = true;
            xlRange.Validation.InCellDropdown = true;
            xlRange.Validation.InputTitle = "TIPO BULTO";
            xlRange.Validation.InputMessage = "Seleccionar el Tipo de Bulto de la lista desplegable.";
            xlRange.Validation.ErrorTitle = "TIPO BULTO";
            xlRange.Validation.ErrorMessage = "Debe seleccionar el valor solo de la lista desplegable.";
            xlRange.Validation.ShowInput = true;
            xlRange.Validation.ShowError = true;

            xlWorksheet.Columns["K:K"].Hidden = true;


            xlRange = xlWorksheet.Range["E11:E30"];
            xlRange.Validation.Delete();
            xlRange.Validation.Add(XLExcel.XlDVType.xlValidateDecimal, XLExcel.XlDVAlertStyle.xlValidAlertStop, XLExcel.XlFormatConditionOperator.xlBetween, "0.00", "10000000.00");
            xlRange.Validation.IgnoreBlank = true;
            xlRange.Validation.InCellDropdown = true;
            xlRange.Validation.InputTitle = "BULTOS";
            xlRange.Validation.InputMessage = "Debe ingresar solo números.";
            xlRange.Validation.ErrorTitle = "BULTOS";
            xlRange.Validation.ErrorMessage = "Debe ingresar solo números.";
            xlRange.Validation.ShowInput = true;
            xlRange.Validation.ShowError = true;

            xlRange = xlWorksheet.Range["F11:F30"];
            xlRange.Validation.Delete();
            xlRange.Validation.Add(XLExcel.XlDVType.xlValidateDecimal, XLExcel.XlDVAlertStyle.xlValidAlertStop, XLExcel.XlFormatConditionOperator.xlBetween, "0.00", "10000000.00");
            xlRange.Validation.IgnoreBlank = true;
            xlRange.Validation.InCellDropdown = true;
            xlRange.Validation.InputTitle = "PESO";
            xlRange.Validation.InputMessage = "Debe ingresar solo números.";
            xlRange.Validation.ErrorTitle = "PESO";
            xlRange.Validation.ErrorMessage = "Debe ingresar solo números.";
            xlRange.Validation.ShowInput = true;
            xlRange.Validation.ShowError = true;

            xlRange = xlWorksheet.Range["G11:G30"];
            xlRange.Validation.Delete();
            xlRange.Validation.Add(XLExcel.XlDVType.xlValidateDecimal, XLExcel.XlDVAlertStyle.xlValidAlertStop, XLExcel.XlFormatConditionOperator.xlBetween, "0.00", "10000000.00");
            xlRange.Validation.IgnoreBlank = true;
            xlRange.Validation.InCellDropdown = true;
            xlRange.Validation.InputTitle = "VOLUMEN";
            xlRange.Validation.InputMessage = "Debe ingresar solo números.";
            xlRange.Validation.ErrorTitle = "VOLUMEN";
            xlRange.Validation.ErrorMessage = "Debe ingresar solo números.";
            xlRange.Validation.ShowInput = true;
            xlRange.Validation.ShowError = true;

            String _password = "N3xtS0ft";
            object object_password = (object)_password;

            xlWorksheet.Protect(object_password, misValue, misValue, misValue, misValue, misValue, misValue, misValue, misValue, misValue, misValue, misValue, misValue, misValue, misValue, misValue);
            xlWorkbook.Protect(object_password, misValue, misValue);

            xlApplication.Visible = true;

         }
         catch (Exception)
         { }
         finally
         {
            if (xlWorksheet != null) { releaseObject(xlWorksheet); }
            if (xlWorkbook != null) { releaseObject(xlWorkbook); }
            if (xlApplication != null) { releaseObject(xlApplication); }
         }
      }

      private static void SetValue(XLExcel.Range xlRange, Object xlValue, Boolean xlMergeCells = false, XLExcel.XlVAlign xlVAlign = XLExcel.XlVAlign.xlVAlignCenter, XLExcel.XlHAlign xlHAlign = XLExcel.XlHAlign.xlHAlignCenter, Boolean xlBold = false, Boolean xlUnderline = false)
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
      private static void SetValueHeader(XLExcel.Range xlRange, Object xlValue, Boolean xlMergeCells = true, XLExcel.XlVAlign xlVAlign = XLExcel.XlVAlign.xlVAlignCenter, XLExcel.XlHAlign xlHAlign = XLExcel.XlHAlign.xlHAlignCenter, Boolean xlBold = true, Boolean xlUnderline = false)
      { SetValue(xlRange, xlValue, xlMergeCells, xlVAlign, xlHAlign, xlBold, xlUnderline); }
      private static void SetValueCell(XLExcel.Range xlRange, Object xlValue, Boolean xlMergeCells = false, XLExcel.XlVAlign xlVAlign = XLExcel.XlVAlign.xlVAlignTop, XLExcel.XlHAlign xlHAlign = XLExcel.XlHAlign.xlHAlignLeft, Boolean xlBold = false, Boolean xlUnderline = false)
      { SetValue(xlRange, xlValue, xlMergeCells, xlVAlign, xlHAlign, xlBold, xlUnderline); }

      private static void setBorderCelda(XLExcel.Range xlRange, XLExcel.XlBorderWeight xlWeight = XLExcel.XlBorderWeight.xlThin, XLExcel.XlLineStyle xlLineStyle = XLExcel.XlLineStyle.xlContinuous, Boolean xlClearStyle = true, Boolean xlEdgeLeft = true, Boolean xlEdgeTop = true, Boolean xlEdgeRight = true, Boolean xlEdgeBottom = true, Boolean xlInsideVertical = true, Boolean xlInsideHorizontal = true, Boolean xlDiagonalDown = true, Boolean xlDiagonalUp = true)
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

      private static void releaseObject(object obj)
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

      #region [ Importar Matriz Draft ]
      public void ImportarMatrizDraft()
      {
         try
         {
            String _SHIPPER = String.Empty;
            String _CONSIGNEE = String.Empty;
            String _NOTIFY = String.Empty;
            String _MARKS = String.Empty;
            String _DESCRIPCION = String.Empty;

            System.Windows.Forms.OpenFileDialog _Dialog = new System.Windows.Forms.OpenFileDialog();
            _Dialog.Multiselect = false;
            _Dialog.Filter = "Archivos de Excel |*.xls;*.xlsx;*.xlsm";
            if (_Dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {

               ImportarExcel excel = new ImportarExcel();
               String _message = "";

               Microsoft.Office.Interop.Excel.Application XLAplication = new Microsoft.Office.Interop.Excel.Application();
               Microsoft.Office.Interop.Excel.Workbook XLWorkBook = default(Microsoft.Office.Interop.Excel.Workbook);
               Microsoft.Office.Interop.Excel.Worksheet XLWorkSheet = default(Microsoft.Office.Interop.Excel.Worksheet);

               try
               {
                  Int32 XLRow = 1;
                  Int32 XLRowTo = 1;
                  Int32 XLColumn = 1;
                  Int32 XLColumnTo = 1;
                  XLRows = 0;

                  XLAplication = new Microsoft.Office.Interop.Excel.Application();

                  if (System.IO.File.Exists(_Dialog.FileName))
                  {
                     // then go and load this into excel
                     XLWorkBook = XLAplication.Workbooks.Open(_Dialog.FileName, true, true);
                     XLWorkSheet = (Microsoft.Office.Interop.Excel.Worksheet)XLAplication.ActiveWorkbook.ActiveSheet;
                     XLRows = XLWorkSheet.UsedRange.Rows.Count - 10;

                     //SHIPPER
                     XLRow = 3;
                     XLRowTo = 3;
                     XLColumn = 1;
                     XLColumnTo = 4;
                     //_SHIPPER = XLWorkSheet.Range[XLWorkSheet.Cells[XLRow, XLColumn], XLWorkSheet.Cells[XLRowTo, XLColumnTo]].Value.ToString();
                     object[,] _dataValuesSHIPPER = (object[,])XLWorkSheet.Range[XLWorkSheet.Cells[XLRow, XLColumn], XLWorkSheet.Cells[XLRowTo, XLColumnTo]].Value2;
                     for (int i = 1; i <= _dataValuesSHIPPER.GetLength(0); i++)
                     {
                        for (int j = 1; j <= _dataValuesSHIPPER.GetLength(1); j++)
                        {
                           if (_dataValuesSHIPPER[i, j] != null && !String.IsNullOrEmpty(_dataValuesSHIPPER[i, j].ToString()))
                           { _SHIPPER += _dataValuesSHIPPER[i, j].ToString(); }
                        }
                     }

                     //CONSIGNEE
                     XLRow = 5;
                     XLRowTo = 5;
                     XLColumn = 1;
                     XLColumnTo = 4;
                     //_CONSIGNEE = XLWorkSheet.Range[XLWorkSheet.Cells[XLRow, XLColumn], XLWorkSheet.Cells[XLRowTo, XLColumnTo]].Value.ToString();
                     object[,] _dataValuesCONSIGNEE = (object[,])XLWorkSheet.Range[XLWorkSheet.Cells[XLRow, XLColumn], XLWorkSheet.Cells[XLRowTo, XLColumnTo]].Value2;
                     for (int i = 1; i <= _dataValuesCONSIGNEE.GetLength(0); i++)
                     {
                        for (int j = 1; j <= _dataValuesCONSIGNEE.GetLength(1); j++)
                        {
                           if (_dataValuesCONSIGNEE[i, j] != null && !String.IsNullOrEmpty(_dataValuesCONSIGNEE[i, j].ToString()))
                           { _CONSIGNEE += _dataValuesCONSIGNEE[i, j].ToString(); }
                        }
                     }

                     //NOTIFY
                     XLRow = 5;
                     XLRowTo = 5;
                     XLColumn = 5;
                     XLColumnTo = 7;
                     //_NOTIFY = XLWorkSheet.Range[XLWorkSheet.Cells[XLRow, XLColumn], XLWorkSheet.Cells[XLRowTo, XLColumnTo]].Value.ToString();
                     object[,] _dataValuesNOTIFY = (object[,])XLWorkSheet.Range[XLWorkSheet.Cells[XLRow, XLColumn], XLWorkSheet.Cells[XLRowTo, XLColumnTo]].Value2;
                     for (int i = 1; i <= _dataValuesNOTIFY.GetLength(0); i++)
                     {
                        for (int j = 1; j <= _dataValuesNOTIFY.GetLength(1); j++)
                        {
                           if (_dataValuesNOTIFY[i, j] != null && !String.IsNullOrEmpty(_dataValuesNOTIFY[i, j].ToString()))
                           { _NOTIFY += _dataValuesNOTIFY[i, j].ToString(); }
                        }
                     }

                     //MARKS
                     XLRow = 9;
                     XLRowTo = 9;
                     XLColumn = 5;
                     XLColumnTo = 7;
                     //_MARKS = XLWorkSheet.Range[XLWorkSheet.Cells[XLRow, XLColumn], XLWorkSheet.Cells[XLRowTo, XLColumnTo]].Value.ToString();
                     object[,] _dataValuesMARKS = (object[,])XLWorkSheet.Range[XLWorkSheet.Cells[XLRow, XLColumn], XLWorkSheet.Cells[XLRowTo, XLColumnTo]].Value2;
                     for (int i = 1; i <= _dataValuesMARKS.GetLength(0); i++)
                     {
                        for (int j = 1; j <= _dataValuesMARKS.GetLength(1); j++)
                        {
                           if (_dataValuesMARKS[i, j] != null && !String.IsNullOrEmpty(_dataValuesMARKS[i, j].ToString()))
                           { _MARKS += _dataValuesMARKS[i, j].ToString(); }
                        }
                     }

                     //DESCRIPCION
                     XLRow = 7;
                     XLRowTo = 7;
                     XLColumn = 5;
                     XLColumnTo = 7;
                     //_MARKS = XLWorkSheet.Range[XLWorkSheet.Cells[XLRow, XLColumn], XLWorkSheet.Cells[XLRowTo, XLColumnTo]].Value.ToString();
                     object[,] _dataValuesDESCRIPCION = (object[,])XLWorkSheet.Range[XLWorkSheet.Cells[XLRow, XLColumn], XLWorkSheet.Cells[XLRowTo, XLColumnTo]].Value2;
                     for (int i = 1; i <= _dataValuesDESCRIPCION.GetLength(0); i++)
                     {
                        for (int j = 1; j <= _dataValuesDESCRIPCION.GetLength(1); j++)
                        {
                           if (_dataValuesDESCRIPCION[i, j] != null && !String.IsNullOrEmpty(_dataValuesDESCRIPCION[i, j].ToString()))
                           { _DESCRIPCION += _dataValuesDESCRIPCION[i, j].ToString(); }
                        }
                     }

                  }
                  else
                  {
                     System.Runtime.InteropServices.Marshal.ReleaseComObject(XLAplication);
                     XLAplication = null;
                  }
               }
               catch (Exception ex)
               { }
               finally
               {
                  if (XLWorkSheet != null) { Marshal.FinalReleaseComObject(XLWorkSheet); }
                  if (XLWorkBook != null) { XLWorkBook.Close(false, Type.Missing, Type.Missing); Marshal.FinalReleaseComObject(XLWorkBook); }

                  Marshal.FinalReleaseComObject(XLWorkBook);
                  XLAplication.Quit();
                  Marshal.FinalReleaseComObject(XLAplication);

                  GC.Collect();
                  GC.WaitForPendingFinalizers();
               }

               System.Data.DataTable DataTableImportacion = excel.ReadExcel(_Dialog.FileName, 10, XLRows, ref _message);
               if (DataTableImportacion != null && DataTableImportacion.Rows.Count > 0)
               {
                  String _columna;
                  Boolean _isCorrect = true;
                  _columna = "CONTENEDOR"; if (!DataTableImportacion.Columns.Contains(_columna)) { _isCorrect = false; }
                  _columna = "PRECINTO"; if (!DataTableImportacion.Columns.Contains(_columna)) { _isCorrect = false; }
                  _columna = "TIPO CONTENEDOR"; if (!DataTableImportacion.Columns.Contains(_columna)) { _isCorrect = false; }
                  //_columna = "DESCRIPCION"; if (!DataTableImportacion.Columns.Contains(_columna)) { _isCorrect = false; }
                  _columna = "TIPO BULTO"; if (!DataTableImportacion.Columns.Contains(_columna)) { _isCorrect = false; }
                  _columna = "BULTOS"; if (!DataTableImportacion.Columns.Contains(_columna)) { _isCorrect = false; }
                  _columna = "PESO"; if (!DataTableImportacion.Columns.Contains(_columna)) { _isCorrect = false; }
                  _columna = "VOLUMEN"; if (!DataTableImportacion.Columns.Contains(_columna)) { _isCorrect = false; }

                  if (!_isCorrect)
                  { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Title, "el archivo seleccionado no corresponde a la plantilla de la Matriz Draft. "); }
                  else
                  {
                     Boolean _inicio = true;
                     String _descripcion = string.Empty;
                     String _tipobulto = string.Empty;

                     Entities.Det_CNTR _itemDet_CNTR = new Entities.Det_CNTR();
                     foreach (DataRow _itemDataRow in DataTableImportacion.Rows)
                     {
                        Boolean _tieneInfo = false;

                        _itemDet_CNTR = null;
                        _itemDet_CNTR = new Entities.Det_CNTR();

                        _itemDet_CNTR.CCOT_Tipo = Item.CCOT_Tipo;
                        _itemDet_CNTR.CCOT_Numero = Item.CCOT_Numero;
                        _itemDet_CNTR.DHBL_DescProducto = _DESCRIPCION;

                        //CONTENEDOR	   => CNTR_Numero
                        _columna = "CONTENEDOR";
                        if (DataTableImportacion.Columns.Contains(_columna))
                        {
                           String _CNTR_Numero;
                           if (!String.IsNullOrEmpty(_itemDataRow[_columna].ToString()))
                           {
                              _CNTR_Numero = _itemDataRow[_columna].ToString();
                              _itemDet_CNTR.CNTR_Numero = _CNTR_Numero;
                              _tieneInfo = true;
                           }
                        }

                        //PRECINTO	      => DHBL_Precinto
                        _columna = "PRECINTO";
                        if (DataTableImportacion.Columns.Contains(_columna))
                        {
                           String _DHBL_Precinto;
                           if (!String.IsNullOrEmpty(_itemDataRow[_columna].ToString()))
                           {
                              _DHBL_Precinto = _itemDataRow[_columna].ToString();
                              _itemDet_CNTR.DHBL_Precinto = _DHBL_Precinto;
                              _tieneInfo = true;
                           }
                        }

                        //TIPO CONTENEDOR	=> PACK_Codigo
                        _columna = "TIPO CONTENEDOR";
                        if (DataTableImportacion.Columns.Contains(_columna))
                        {
                           String _PACK_CodigoStr;
                           Int32 _PACK_Codigo;
                           if (!String.IsNullOrEmpty(_itemDataRow[_columna].ToString()))
                           {
                              _PACK_CodigoStr = _itemDataRow[_columna].ToString();
                              if (_PACK_CodigoStr.Split('-').Count() == 2)
                              {
                                 if (Int32.TryParse(_PACK_CodigoStr.Split('-')[0], out _PACK_Codigo))
                                 { _itemDet_CNTR.PACK_Codigo = _PACK_Codigo; _tieneInfo = true; }
                              }
                           }
                        }

                        //DESCRIPCION	   => DHBL_DescProducto
                        //_columna = "DESCRIPCION";
                        //if (DataTableImportacion.Columns.Contains(_columna))
                        //{
                        //   String _DHBL_DescProducto;
                        //   if (!String.IsNullOrEmpty(_itemDataRow[_columna].ToString()))
                        //   {
                        //      _DHBL_DescProducto = _itemDataRow[_columna].ToString();
                        //      _itemDet_CNTR.DHBL_DescProducto = _DHBL_DescProducto;
                        //      _tieneInfo = true;

                        //      if (_inicio)
                        //      { _descripcion = _DHBL_DescProducto; }
                        //      _tipobulto = string.Empty;

                        //   }
                        //}

                        //TIPO BULTO	   => TIPO_TabPAC - TIPO_CodPAC
                        _columna = "TIPO BULTO";
                        if (DataTableImportacion.Columns.Contains(_columna))
                        {
                           String _TIPO_CodPAC;

                           if (!String.IsNullOrEmpty(_itemDataRow[_columna].ToString()) && ListTiposPAC.Where(tpac => tpac.TIPO_Desc1.ToUpper() == _itemDataRow[_columna].ToString().ToUpper()).FirstOrDefault() != null)
                           {
                              //_TIPO_CodPAC = _itemDataRow[_columna].ToString();
                              _TIPO_CodPAC = ListTiposPAC.Where(tpac => tpac.TIPO_Desc1.ToUpper() == _itemDataRow[_columna].ToString().ToUpper()).FirstOrDefault().TIPO_CodTipo;

                              _itemDet_CNTR.TIPO_TabPAC = "PAC";
                              _itemDet_CNTR.TIPO_CodPAC = _TIPO_CodPAC;
                              _tieneInfo = true;

                              if (_inicio)
                              { _tipobulto = _TIPO_CodPAC; }

                              //if (_TIPO_CodPAC.Split('-').Count() == 2)
                              //{
                              //   _itemDet_CNTR.TIPO_TabPAC = "PAC";
                              //   _itemDet_CNTR.TIPO_CodPAC = _TIPO_CodPAC.Split('-')[0];
                              //}
                              //else
                              //{ break; }
                           }
                        }

                        //BULTOS	         => DHBL_CantBultos
                        _columna = "BULTOS";
                        if (DataTableImportacion.Columns.Contains(_columna))
                        {
                           Decimal _DHBL_CantBultos;
                           if (Decimal.TryParse(_itemDataRow[_columna].ToString(), out _DHBL_CantBultos))
                           { _itemDet_CNTR.DHBL_CantBultos = _DHBL_CantBultos; _tieneInfo = true; }
                        }

                        //PESO	         => DHBL_PesoBruto
                        _columna = "PESO";
                        if (DataTableImportacion.Columns.Contains(_columna))
                        {
                           Decimal _DHBL_PesoBruto;
                           if (Decimal.TryParse(_itemDataRow[_columna].ToString(), out _DHBL_PesoBruto))
                           { _itemDet_CNTR.DHBL_PesoBruto = _DHBL_PesoBruto; _tieneInfo = true; }
                        }

                        //VOLUMEN         => DHBL_Volumen
                        _columna = "VOLUMEN";
                        if (DataTableImportacion.Columns.Contains(_columna))
                        {
                           Decimal _DHBL_Volumen;
                           if (Decimal.TryParse(_itemDataRow[_columna].ToString(), out _DHBL_Volumen))
                           { _itemDet_CNTR.DHBL_Volumen = _DHBL_Volumen; _tieneInfo = true; }
                        }


                        if (_tieneInfo)
                        {
                           if (!String.IsNullOrEmpty(_descripcion) && String.IsNullOrEmpty(_itemDet_CNTR.DHBL_DescProducto))
                           { _itemDet_CNTR.DHBL_DescProducto = _descripcion; }
                           if (!String.IsNullOrEmpty(_tipobulto) && String.IsNullOrEmpty(_itemDet_CNTR.TIPO_CodPAC))
                           {
                              _itemDet_CNTR.TIPO_TabPAC = "PAC";
                              _itemDet_CNTR.TIPO_CodPAC = _tipobulto;
                           }


                           _itemDet_CNTR.DHBL_MarcasNumeros = _MARKS;

                           _itemDet_CNTR.TIPO_TabCDT = "CDT";
                           _itemDet_CNTR.TIPO_CodCDT = "001"; //GENERAL

                           _itemDet_CNTR.AUDI_UsrCrea = Session.UserName;
                           _itemDet_CNTR.AUDI_FecCrea = Session.Fecha;
                           _itemDet_CNTR.Instance = Infrastructure.Aspect.BusinessEntity.InstanceEntity.Added;

                           Item.ItemsDet_CNTR.Add(_itemDet_CNTR);
                        }

                        //CMBL_codigo 
                        //TIPO_TabIMO
                        //TIPO_CodIMO
                        //DHBL_EsIMO
                        //DHBL_ContractNRO
                        //DHBL_PP
                        //DHBL_Item
                        //TIPO_TabCDT
                        //TIPO_CodCDT
                        _inicio = false;
                     }

                     Item.DDOV_DescShipper = _SHIPPER;
                     Item.DDOV_DescConsignee = _CONSIGNEE;
                     Item.DDOV_DescNotify = _NOTIFY;

                     MView.ShowImportacionMatrizDraft();
                  }
               }
            }
         }
         catch (Exception)
         { }
      }
      #endregion

      #region [ Emision HBL ]
      public void EmitirHBL(Boolean SinLogo, Boolean SinFormato, Boolean SinFlete, Boolean Detallado)
      {
         try
         {
            MView.GetItem();

            if (PARA_IMPRIMIRHBL != null && Item.ItemsEventosTareas != null && Item.ItemsEventosTareas.Where(even => even.TIPO_CodEVE == PARA_IMPRIMIRHBL.PARA_Valor).FirstOrDefault() == null)
            {
               //Agregar Evento de Impresion
               Entities.Det_Cotizacion_OV_EventosTareas ItemEventoTarea = new Entities.Det_Cotizacion_OV_EventosTareas();
               ItemEventoTarea.CCOT_Tipo = Item.CCOT_Tipo;
               ItemEventoTarea.CCOT_Numero = Item.CCOT_Numero;
               //ItemEventoTarea.EVEN_Item
               ItemEventoTarea.EVEN_Fecha = DateTime.Now;
               ItemEventoTarea.EVEN_Cumplida = true;
               ItemEventoTarea.EVEN_Usuario = Session.UserName;
               ItemEventoTarea.EVEN_Observaciones = PARA_IMPRIMIRHBL.PARA_Desc;
               ItemEventoTarea.TIPO_TabEVE = "EVE";
               ItemEventoTarea.TIPO_CodEVE = PARA_IMPRIMIRHBL.PARA_Valor;
               ItemEventoTarea.CONS_TabMOD = "MOD";
               ItemEventoTarea.CONS_CodMOD = "001";
               ItemEventoTarea.EVEN_Manual = false;
               ItemEventoTarea.AUDI_UsrCrea = Session.UserName;
               ItemEventoTarea.AUDI_FecCrea = Session.Fecha;

               Item.ItemsEventosTareas.Add(ItemEventoTarea);

               ItemEventoTarea.Instance = Infrastructure.Aspect.BusinessEntity.InstanceEntity.Added;
            }

            if (Guardar(false, false))
            {
               if (Item != null)
               {
                  System.Data.DataSet _ds = new System.Data.DataSet();
                  System.Data.DataTable _dtCabecera = new System.Data.DataTable();
                  System.Data.DataTable _dtDetalle = new System.Data.DataTable();
                  System.Data.DataTable _dtDetalle2 = new System.Data.DataTable();
                  //ObservableCollection<Infrastructure.Aspect.DataAccess.DataAccessFilter> _listFilters = new ObservableCollection<Infrastructure.Aspect.DataAccess.DataAccessFilter>();
                  //_listFilters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilter() { FilterName = "psinEMPR_CODIGO", FilterValue = Item.EMPR_CODIGO, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.Int16, FilterSize = 22 });
                  //_listFilters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilter() { FilterName = "psinSUCR_CODIGO", FilterValue = Item.SUCR_CODIGO, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.Int16, FilterSize = 22 });
                  //_listFilters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilter() { FilterName = "psinTERM_CODIGO", FilterValue = Item.TERM_CODIGO, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.Int16, FilterSize = 22 });
                  //_listFilters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilter() { FilterName = "pintPARP_CODIGO", FilterValue = Item.PARP_CODIGO, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.Int32, FilterSize = 22 });
                  //_listFilters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilter() { FilterName = "pdteFACT_FECINI", FilterValue = Item.PARP_FECAPE, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.Date, FilterSize = 7 });
                  //_listFilters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilter() { FilterName = "pdteFACT_FECFIN", FilterValue = Item.PARP_FECCIE, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.Date, FilterSize = 7 });


                  //_dtReporte = Client.GetDTPARTEPAGO("PQ_SDT_PARTEPAGO.SDT_PARPSS_Reporte", _listFilters);

                  _ds = Client.OPE_GetOneCab_Cotizacion_OVImpresionHBL(Item.CCOT_Tipo, Item.CCOT_Numero);

                  if (_ds != null)
                  {
                     _dtCabecera = _ds.Tables[0];
                     _dtDetalle = (!Detallado ? _ds.Tables[1] : _ds.Tables[3]);
                     _dtDetalle2 = _ds.Tables[2];
                     if (_dtCabecera != null && _dtCabecera.Rows.Count > 0 && _dtDetalle != null && _dtDetalle.Rows.Count > 0)
                     {
                        Microsoft.Reporting.WinForms.ReportDataSource rds = new Microsoft.Reporting.WinForms.ReportDataSource();
                        rds.Name = "DSOPE001HBL";
                        rds.Value = _dtCabecera;


                        //if (!(Item.CONS_CodFLE == Delfin.Controls.variables.CONSFLE_FCL_FCL || Item.CONS_CodFLE == Delfin.Controls.variables.CONSFLE_LCL_FCL))
                        //{ _dtDetalle.Rows.Clear(); }

                        Microsoft.Reporting.WinForms.ReportDataSource rdsDet = new Microsoft.Reporting.WinForms.ReportDataSource();
                        rdsDet.Name = "DSOPE001HBLDET";
                        rdsDet.Value = _dtDetalle;

                        Microsoft.Reporting.WinForms.ReportDataSource rdsDet2 = new Microsoft.Reporting.WinForms.ReportDataSource();
                        rdsDet2.Name = "DSOPE001DHBL2";
                        rdsDet2.Value = _dtDetalle2;

                        Int32 _totalBultos = 0;
                        Decimal _pesoBruto = 0, _volumen = 0;
                        String _tipoBulto = "";
                        String _bultosLetras = "";
                        if (_dtDetalle.Compute("Sum(DHBL_CantBultos)", "") != null && _dtDetalle.Compute("Sum(DHBL_CantBultos)", "") != DBNull.Value)
                        {
                           _totalBultos = Convert.ToInt32(_dtDetalle.Compute("Sum(DHBL_CantBultos)", ""));
                           _tipoBulto = _dtDetalle.Rows[0]["DHBL_KindPackage"].ToString();
                           _bultosLetras = "SAY " + NumbersExtensions.ToWords(_totalBultos).ToUpper() + " " + _tipoBulto + " ONLY";
                        }
                        if (_dtDetalle.Compute("Sum(DHBL_PesoBruto)", "") != null && _dtDetalle.Compute("Sum(DHBL_PesoBruto)", "") != DBNull.Value)
                        { _pesoBruto = Convert.ToDecimal(_dtDetalle.Compute("Sum(DHBL_PesoBruto)", "")); }
                        if (_dtDetalle.Compute("Sum(DHBL_Volumen)", "") != null && _dtDetalle.Compute("Sum(DHBL_Volumen)", "") != DBNull.Value)
                        { _volumen = Convert.ToDecimal(_dtDetalle.Compute("Sum(DHBL_Volumen)", "")); }

                        Microsoft.Reporting.WinForms.ReportParameter[] _parameters = new Microsoft.Reporting.WinForms.ReportParameter[10];

                        String _pathLogo = "File:///" + System.IO.Path.GetDirectoryName(System.Windows.Forms.Application.ExecutablePath);
                         //if (DateTime.Now >= Convert.ToDateTime("01-01-2019"))
                         //{ _pathLogo += "\\Imagenes\\LogoHK.png"; }
                         //else
                        { _pathLogo += "\\Imagenes\\LogoHK.png"; }


                        _parameters[0] = new Microsoft.Reporting.WinForms.ReportParameter("parLogo", _pathLogo);
                        _parameters[1] = new Microsoft.Reporting.WinForms.ReportParameter("parSinLogo", SinLogo.ToString());
                        _parameters[2] = new Microsoft.Reporting.WinForms.ReportParameter("parSinFormato", SinFormato.ToString()); 
                        _parameters[3] = new Microsoft.Reporting.WinForms.ReportParameter("parSinFlete", SinFlete.ToString());

                        _parameters[4] = new Microsoft.Reporting.WinForms.ReportParameter("parCantidadLetras", _bultosLetras);
                        _parameters[5] = new Microsoft.Reporting.WinForms.ReportParameter("parContenedores", (Item.CONS_CodFLE == Delfin.Controls.variables.CONSFLE_FCL_FCL || Item.CONS_CodFLE == Delfin.Controls.variables.CONSFLE_LCL_FCL).ToString());

                        _parameters[6] = new Microsoft.Reporting.WinForms.ReportParameter("DHBL_PesoBruto", _pesoBruto.ToString("#,###,##0.000"));
                        _parameters[7] = new Microsoft.Reporting.WinForms.ReportParameter("DHBL_Volumen", _volumen.ToString("#,###,##0.000"));
                        _parameters[8] = new Microsoft.Reporting.WinForms.ReportParameter("DHBL_CantBultos", String.Format("{0:#,###,##0} {1}", _totalBultos, _tipoBulto));
                        _parameters[9] = new Microsoft.Reporting.WinForms.ReportParameter("TipoContenedor", (!(Item.CONS_CodFLE == Delfin.Controls.variables.CONSFLE_FCL_FCL || Item.CONS_CodFLE == Delfin.Controls.variables.CONSFLE_LCL_FCL)? "(LCL/LCL)": " "));

                        //String _path = "Delfin.Principal.Reportes.OPE001Cotizacion.OPE001MBL.rdlc";
                        String _path = System.IO.Path.GetDirectoryName(System.Windows.Forms.Application.ExecutablePath) + "\\Reportes\\OPE001MBL.rdlc";
                        //String _path = System.IO.Path.GetDirectoryName(System.Windows.Forms.Application.ExecutablePath) + "\\Reportes\\OPE001MBL.rdlc";
                        //String _path = System.IO.Path.GetDirectoryName(System.Windows.Forms.Application.ExecutablePath) + "\\Reportes\\OPE001MBL.rdlc";
                        
                        Dictionary<String, Microsoft.Reporting.WinForms.ReportDataSource> x_subreports = new Dictionary<string, Microsoft.Reporting.WinForms.ReportDataSource>();
                        x_subreports.Add("OPE001MBL_Contenedor", rdsDet2);
                        x_subreports.Add("OPE001MBL_Detalle", rdsDet);

                        //Microsoft.Reporting.WinForms.ReportParameter[] _parametersSubreport = new Microsoft.Reporting.WinForms.ReportParameter[1];
                        //_parametersSubreport[0] = new Microsoft.Reporting.WinForms.ReportParameter("TipoContenedor", "LCL/LCL");
                        //Dictionary<String, Microsoft.Reporting.WinForms.ReportParameter[]> x_subreportsParametros = new Dictionary<String, Microsoft.Reporting.WinForms.ReportParameter[]>();
                        //x_subreportsParametros.Add("OPE001MBL_Detalle", _parametersSubreport);

                        Visualizador _impresion = new Visualizador("", _path, rds, _parameters, x_subreports, null) { StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen };
                        _impresion.Imprimir();
                        _impresion.ShowDialog();
                     }
                     else
                     { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Title, "No se ha podido imprimir el registro porque no devolvió ningun resultado."); }
                  }
               }
               else
               { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Title, "No se ha podido imprimir el registro."); }

               //MView.SelectTab(3);
            }
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Title, "Ha ocurrido un error cargando el reporte.", ex); }
      }
      #endregion
   }
}