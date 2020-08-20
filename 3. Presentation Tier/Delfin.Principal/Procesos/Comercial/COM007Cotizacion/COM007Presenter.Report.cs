using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace Delfin.Principal
{
   public partial class COM007Presenter
   {
      #region [ Propiedades ]
      public ICOM007RView RView { get; set; }

      public Microsoft.Reporting.WinForms.ReportDataSource RepDataSourceFlete { get; set; }
      public Microsoft.Reporting.WinForms.ReportDataSource RepDataSourceService { get; set; }
      public String ReportPath { get; set; }
      public Microsoft.Reporting.WinForms.ReportParameter[] Parameters { get; set; }
      #endregion

      #region [ Metodo Impresion ]
      public void Imprimir()
      {
         try
         {
            if (ItemLView.CCOT_Tipo == Delfin.Controls.variables.CCOT_TipoCotizacion)
            {
               if (ItemLView.CONS_CodEST == Delfin.Controls.variables.CONS_ESTCOTAUTORIZADA || ItemLView.CONS_CodEST == Delfin.Controls.variables.CONS_ESTCOTCONFIRMADA)
               { CargarReporteCotizacion(); }
            }
            else if (ItemLView.CCOT_Tipo == Delfin.Controls.variables.CCOT_TipoOrdenVenta)
            {
               if (ItemLView.CONS_CodRGM == Delfin.Controls.variables.CONSRGM_Importacion)
               { CargarReporteOrdenVentaImpo(); }
               else if (ItemLView.CONS_CodRGM == Delfin.Controls.variables.CONSRGM_Exportacion)
               { CargarReporteOrdenVentaExpo(); }
            }
         }
         catch (Exception)
         { }
      }
      #endregion

      #region [ Metodos Reporte Cotizacion ]
      public void CargarReporteCotizacion()
      {
         try
         {
            RView = new COM007RView();
            RView.Presenter = this;
            ((COM007RView)RView).Show();

            Item = Client.GetOneCab_Cotizacion_OV(Delfin.Controls.Entorno.ItemEmpresa.EMPR_Codigo, Delfin.Controls.Entorno.ItemSucursal.SUCR_Codigo, Item.CCOT_Numero, Item.CCOT_Tipo);

            System.Data.DataTable DTCotizacionFlete = new System.Data.DataTable("DTCotizacionFlete");
            DTCotizacionFlete.Columns.Add("Desc", Type.GetType("System.String"));
            DTCotizacionFlete.Columns.Add("Moneda", Type.GetType("System.String"));
            DTCotizacionFlete.Columns.Add("Precio", Type.GetType("System.Decimal"));

            foreach (Entities.Det_Cotizacion_OV_Flete _flete in Item.ItemsFlete)
            {
               System.Data.DataRow _newRow = DTCotizacionFlete.NewRow();
               _newRow["Desc"] = _flete.PACK_Desc;
               _newRow["Moneda"] = Item.TIPO_DescCMND;
               _newRow["Precio"] = _flete.DCOT_PrecioUniVenta;

               DTCotizacionFlete.Rows.Add(_newRow);
            }

            System.Data.DataTable DTCotizacionServicio = new System.Data.DataTable("DTCotizacionServicio");
            DTCotizacionServicio.Columns.Add("Tipo", Type.GetType("System.String"));
            DTCotizacionServicio.Columns.Add("Desc", Type.GetType("System.String"));
            DTCotizacionServicio.Columns.Add("Moneda", Type.GetType("System.String"));
            DTCotizacionServicio.Columns.Add("Cantidad", Type.GetType("System.Decimal"));
            DTCotizacionServicio.Columns.Add("Precio", Type.GetType("System.Decimal"));
            DTCotizacionServicio.Columns.Add("Valor", Type.GetType("System.Decimal"));

            foreach (Entities.Det_Cotizacion_OV_Servicio _servicio in Item.ItemsServicio)
            {
               if (!_servicio.SCOT_Exonerado)
               {
                  System.Data.DataRow _newRow = DTCotizacionServicio.NewRow();
                  _newRow["Tipo"] = _servicio.SCOT_Origen;
                  _newRow["Desc"] = _servicio.SERV_Nombre;
                  _newRow["Moneda"] = _servicio.TIPO_DescCMnd;
                  _newRow["Cantidad"] = _servicio.SCOT_Cantidad;
                  _newRow["Precio"] = _servicio.SCOT_PrecioUni;
                  if (_servicio.CCOT_IngresoGasto == "I")
                  { _newRow["Valor"] = _servicio.SCOT_Importe_Ingreso; }
                  else
                  { _newRow["Valor"] = _servicio.SCOT_Importe_Egreso; }

                  DTCotizacionServicio.Rows.Add(_newRow);
               }
            }

            ReportPath = System.Windows.Forms.Application.StartupPath + @"\Reportes\rptCOM007Cotizacion.rdlc";
            RepDataSourceFlete = new Microsoft.Reporting.WinForms.ReportDataSource();
            RepDataSourceFlete.Name = "DTCotizacionFlete";
            RepDataSourceFlete.Value = DTCotizacionFlete;

            RepDataSourceService = new Microsoft.Reporting.WinForms.ReportDataSource();
            RepDataSourceService.Name = "DTCotizacionServicio";
            RepDataSourceService.Value = DTCotizacionServicio;

            this.Parameters = new Microsoft.Reporting.WinForms.ReportParameter[19];
            Parameters[0] = new Microsoft.Reporting.WinForms.ReportParameter("CONS_DescVIA", Item.CONS_DescVia);
            Parameters[1] = new Microsoft.Reporting.WinForms.ReportParameter("CONS_DescRGM", Item.CONS_DescRGM);
            Parameters[2] = new Microsoft.Reporting.WinForms.ReportParameter("CCOT_NumDoc", Item.CCOT_NumDoc);
            Parameters[3] = new Microsoft.Reporting.WinForms.ReportParameter("CCOT_Version", Item.CCOT_Version.ToString());
            Parameters[4] = new Microsoft.Reporting.WinForms.ReportParameter("ENTC_NomCliente", Item.ENTC_NomCliente);
            Parameters[5] = new Microsoft.Reporting.WinForms.ReportParameter("ENTC_NomContacto", Item.ENTC_NomContacto);
            Parameters[6] = new Microsoft.Reporting.WinForms.ReportParameter("CCOT_FecEmi", Item.CCOT_FecEmi.Value.ToString("dd/MM/yyyy"));
            Parameters[7] = new Microsoft.Reporting.WinForms.ReportParameter("CCOT_FecVcto", Item.CCOT_FecVcto.Value.ToString("dd/MM/yyyy"));
            Parameters[8] = new Microsoft.Reporting.WinForms.ReportParameter("CCOT_FecOferta", Item.CCOT_FecEmi.Value.AddDays(Item.CCOT_ValidezOferta).ToString("dd/MM/yyyy"));
            Parameters[9] = new Microsoft.Reporting.WinForms.ReportParameter("ENTC_EmailContacto", Item.ENTC_EmailContacto);
            Parameters[10] = new Microsoft.Reporting.WinForms.ReportParameter("PUER_NombreOrigen", Item.PUER_NombreOrigen);
            Parameters[11] = new Microsoft.Reporting.WinForms.ReportParameter("PUER_NombreDestino", Item.PUER_NombreDestino);
            Parameters[12] = new Microsoft.Reporting.WinForms.ReportParameter("Usuario", Session.UserNombreCompleto);
            Parameters[13] = new Microsoft.Reporting.WinForms.ReportParameter("ENTC_NomAgente", Item.ENTC_NomAgente);
            Parameters[14] = new Microsoft.Reporting.WinForms.ReportParameter("ENTC_EmailAgente", Item.ENTC_EmailAgente);
            Parameters[15] = new Microsoft.Reporting.WinForms.ReportParameter("CCOT_Almacenaje", Item.CCOT_Almacenaje.ToString());
            Parameters[16] = new Microsoft.Reporting.WinForms.ReportParameter("CCOT_Sobreestadia", Item.CCOT_SobreEstadia.ToString());
            Parameters[17] = new Microsoft.Reporting.WinForms.ReportParameter("CCOT_TiempoViaje", Item.CCOT_TiempoViaje.ToString());
            Parameters[18] = new Microsoft.Reporting.WinForms.ReportParameter("CCOT_Observacion", Item.CCOT_Observaciones);

            RView.ShowItems();
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Title, "Ha ocurrido un error cargando el reporte.", ex); }
      }
      public void LimpiarReporteCotizacion()
      {
         try
         {
            ReportPath = System.Windows.Forms.Application.StartupPath + @"\Reportes\rptCOM007Cotizacion.rdlc";

            RepDataSourceFlete = new Microsoft.Reporting.WinForms.ReportDataSource();
            RepDataSourceFlete.Name = "DTCotizacionFlete";
            RepDataSourceFlete.Value = null;

            RepDataSourceService = new Microsoft.Reporting.WinForms.ReportDataSource();
            RepDataSourceService.Name = "DTCotizacionServicio";
            RepDataSourceService.Value = null;

            this.Parameters = new Microsoft.Reporting.WinForms.ReportParameter[19];

            LView.ShowItems();
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Title, "Ha ocurrido un error limpiando el reporte.", ex); }
      }
      #endregion

      #region [ Metodos Reporte OrdenVentaImpo ]
      public void CargarReporteOrdenVentaImpo()
      {
         try
         {
            RView = new COM007RView();
            RView.Presenter = this;
            ((COM007RView)RView).Show();

            Item = Client.GetOneCab_Cotizacion_OV(Delfin.Controls.Entorno.ItemEmpresa.EMPR_Codigo, Delfin.Controls.Entorno.ItemSucursal.SUCR_Codigo, ItemLView.CCOT_Numero, ItemLView.CCOT_Tipo);

            ReportPath = System.Windows.Forms.Application.StartupPath + @"\Reportes\rptCOM007OrdenVentaImpo.rdlc";
            //RepDataSourceFlete = new Microsoft.Reporting.WinForms.ReportDataSource();
            //RepDataSourceFlete.Name = "DTOrdenVentaImpoFlete";
            //RepDataSourceFlete.Value = DTOrdenVentaImpoFlete;
            String _TypeQuantity = "";
            foreach (var _flete in Item.ItemsFlete)
            { _TypeQuantity += (String.IsNullOrEmpty(_TypeQuantity) ? "" : ", ") + String.Format("{0}X{1}", _flete.DCOT_Cantidad.ToString("#0"), _flete.PACK_DescC); }
            Decimal _Weight = Item.ItemsFlete.Sum(flet => flet.DCOT_Peso.HasValue ? flet.DCOT_Peso.Value : (Decimal)0.00);
            Decimal _Volume = Item.ItemsFlete.Sum(flet => flet.DCOT_Volumen.HasValue ? flet.DCOT_Volumen.Value : (Decimal)0.00);
            Decimal _Pieces = Item.ItemsFlete.Sum(flet => flet.DCOT_Cantidad);


            this.Parameters = new Microsoft.Reporting.WinForms.ReportParameter[38];

            CultureInfo _culture = new CultureInfo("en-US");

            Parameters[0] = new Microsoft.Reporting.WinForms.ReportParameter("CCOT_FecEmi", Item.CCOT_FecEmi.Value.ToString("D", _culture));
            Parameters[1] = new Microsoft.Reporting.WinForms.ReportParameter("CCOT_NumDoc", String.IsNullOrEmpty(Item.CCOT_NumDoc) ? "" : Item.CCOT_NumDoc);
            Parameters[2] = new Microsoft.Reporting.WinForms.ReportParameter("ENTC_NomAgente", String.IsNullOrEmpty(Item.ENTC_NomAgente) ? "" : Item.ENTC_NomAgente);
            Parameters[3] = new Microsoft.Reporting.WinForms.ReportParameter("DOOV_CodReferencia", String.IsNullOrEmpty(Item.DOOV_CodReferencia) ? "" : Item.DOOV_CodReferencia);
            Parameters[4] = new Microsoft.Reporting.WinForms.ReportParameter("ENTC_NomShipper", String.IsNullOrEmpty(Item.ENTC_NomShipper) ? "" : Item.ENTC_NomShipper);
            Parameters[5] = new Microsoft.Reporting.WinForms.ReportParameter("ENTC_DirShipper", String.IsNullOrEmpty(Item.ENTC_DirShipper) ? "" : Item.ENTC_DirShipper);
            Parameters[6] = new Microsoft.Reporting.WinForms.ReportParameter("ENTC_EmailShipper", String.IsNullOrEmpty(Item.ENTC_EmailShipper) ? "" : Item.ENTC_EmailShipper);
            Parameters[7] = new Microsoft.Reporting.WinForms.ReportParameter("ENTC_Tel1Shipper", String.IsNullOrEmpty(Item.ENTC_Tel1Shipper) ? "" : Item.ENTC_Tel1Shipper);
            Parameters[8] = new Microsoft.Reporting.WinForms.ReportParameter("ENTC_Tel2Shipper", String.IsNullOrEmpty(Item.ENTC_Tel2Shipper) ? "" : Item.ENTC_Tel2Shipper);
            Parameters[9] = new Microsoft.Reporting.WinForms.ReportParameter("ENTC_ContactShipper", String.IsNullOrEmpty(Item.ENTC_ContactShipper) ? "" : Item.ENTC_ContactShipper);
            Parameters[10] = new Microsoft.Reporting.WinForms.ReportParameter("ENTC_NomConsignee", String.IsNullOrEmpty(Item.ENTC_NomConsignee) ? "" : Item.ENTC_NomConsignee);
            Parameters[11] = new Microsoft.Reporting.WinForms.ReportParameter("ENTC_DirConsignee", String.IsNullOrEmpty(Item.ENTC_DirConsignee) ? "" : Item.ENTC_DirConsignee);
            Parameters[12] = new Microsoft.Reporting.WinForms.ReportParameter("ENTC_EmailConsignee", String.IsNullOrEmpty(Item.ENTC_EmailConsignee) ? "" : Item.ENTC_EmailConsignee);
            Parameters[13] = new Microsoft.Reporting.WinForms.ReportParameter("ENTC_Tel1Consignee", String.IsNullOrEmpty(Item.ENTC_Tel1Consignee) ? "" : Item.ENTC_Tel1Consignee);
            Parameters[14] = new Microsoft.Reporting.WinForms.ReportParameter("ENTC_Tel2Consignee", String.IsNullOrEmpty(Item.ENTC_Tel2Consignee) ? "" : Item.ENTC_Tel2Consignee);
            Parameters[15] = new Microsoft.Reporting.WinForms.ReportParameter("ENTC_ContactConsignee", String.IsNullOrEmpty(Item.ENTC_ContactConsignee) ? "" : Item.ENTC_ContactConsignee);
            Parameters[16] = new Microsoft.Reporting.WinForms.ReportParameter("ENTC_NomAgente2", String.IsNullOrEmpty(Item.ENTC_NomAgente) ? "" : Item.ENTC_NomAgente);
            Parameters[17] = new Microsoft.Reporting.WinForms.ReportParameter("ENTC_DirAgente", String.IsNullOrEmpty(Item.ENTC_DirAgente) ? "" : Item.ENTC_DirAgente);
            Parameters[18] = new Microsoft.Reporting.WinForms.ReportParameter("ENTC_EmailAgente", String.IsNullOrEmpty(Item.ENTC_EmailAgente) ? "" : Item.ENTC_EmailAgente);
            Parameters[19] = new Microsoft.Reporting.WinForms.ReportParameter("ENTC_Tel1Agente", String.IsNullOrEmpty(Item.ENTC_Tel1Agente) ? "" : Item.ENTC_Tel1Agente);
            Parameters[20] = new Microsoft.Reporting.WinForms.ReportParameter("ENTC_Tel2Agente", String.IsNullOrEmpty(Item.ENTC_Tel2Agente) ? "" : Item.ENTC_Tel2Agente);
            Parameters[21] = new Microsoft.Reporting.WinForms.ReportParameter("ENTC_ContactAgente", String.IsNullOrEmpty(Item.ENTC_ContactAgente) ? "" : Item.ENTC_ContactAgente);
            Parameters[22] = new Microsoft.Reporting.WinForms.ReportParameter("ENTC_NomTransportista", String.IsNullOrEmpty(Item.ENTC_NomTransportista) ? "" : Item.ENTC_NomTransportista);
            Parameters[23] = new Microsoft.Reporting.WinForms.ReportParameter("CONT_Numero", String.IsNullOrEmpty(Item.CONT_Numero) ? "" : Item.CONT_Numero);
            Parameters[24] = new Microsoft.Reporting.WinForms.ReportParameter("TIPO_DescMND", String.IsNullOrEmpty(Item.TIPO_DescCMND) ? "" : Item.TIPO_DescCMND);
            Parameters[25] = new Microsoft.Reporting.WinForms.ReportParameter("PACK_DescC", String.IsNullOrEmpty(Item.PACK_DescC) ? "" : Item.PACK_DescC);
            Parameters[26] = new Microsoft.Reporting.WinForms.ReportParameter("DCOT_Cantidad", Item.DCOT_Cantidad.HasValue ? Convert.ToInt32(Item.DCOT_Cantidad.Value).ToString() : "");
            Parameters[27] = new Microsoft.Reporting.WinForms.ReportParameter("CCOT_PagoMBL", String.IsNullOrEmpty(Item.CCOT_PagoMBL) ? "" : Item.CCOT_PagoMBL == "C" ? "COLLECT" : "PREPAID");
            Parameters[28] = new Microsoft.Reporting.WinForms.ReportParameter("PUER_NombreOrigen", String.IsNullOrEmpty(Item.PUER_NombreOrigen) ? "" : Item.PUER_NombreOrigen);
            Parameters[29] = new Microsoft.Reporting.WinForms.ReportParameter("PUER_NombreDestino", String.IsNullOrEmpty(Item.PUER_NombreDestino) ? "" : Item.PUER_NombreDestino);
            Parameters[30] = new Microsoft.Reporting.WinForms.ReportParameter("TIPO_DescCDT", String.IsNullOrEmpty(Item.TIPO_DescCDT) ? "" : Item.TIPO_DescCDT);
            Parameters[31] = new Microsoft.Reporting.WinForms.ReportParameter("DCOT_Peso", _Weight.ToString("0,0.00") + " TN");
            Parameters[32] = new Microsoft.Reporting.WinForms.ReportParameter("DCOT_Volumen", _Volume.ToString("0,0.00") + " M3");
            Parameters[33] = new Microsoft.Reporting.WinForms.ReportParameter("DCOT_Bultos", _Pieces.ToString("0,0.00"));
            Parameters[34] = new Microsoft.Reporting.WinForms.ReportParameter("CCOT_Observaciones", String.IsNullOrEmpty(Item.CCOT_Observaciones) ? "" : Item.CCOT_Observaciones);
            Parameters[35] = new Microsoft.Reporting.WinForms.ReportParameter("ENTC_NomEjecutivo", String.IsNullOrEmpty(Item.ENTC_NomEjecutivo) ? "" : Item.ENTC_NomEjecutivo);
            Parameters[36] = new Microsoft.Reporting.WinForms.ReportParameter("ENTC_NomCustomer", String.IsNullOrEmpty(Item.ENTC_NomCustomer) ? "" : Item.ENTC_NomCustomer);
            Parameters[37] = new Microsoft.Reporting.WinForms.ReportParameter("DOCT_TypeQuantity", _TypeQuantity);


            RView.ShowItems();
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Title, "Ha ocurrido un error cargando el reporte.", ex); }
      }
      public void LimpiarReporteOrdenVentaImpo()
      {
         try
         {
            ReportPath = System.Windows.Forms.Application.StartupPath + @"\Reportes\rptCOM007OrdenVentaImpo.rdlc";

            this.Parameters = new Microsoft.Reporting.WinForms.ReportParameter[37];

            LView.ShowItems();
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Title, "Ha ocurrido un error limpiando el reporte.", ex); }
      }
      #endregion

      #region [ Metodos Reporte OrdenVentaExpo ]
      public void CargarReporteOrdenVentaExpo()
      {
         try
         {
            RView = new COM007RView();
            RView.Presenter = this;
            ((COM007RView)RView).Show();

            Item = Client.GetOneCab_Cotizacion_OV(Delfin.Controls.Entorno.ItemEmpresa.EMPR_Codigo, Delfin.Controls.Entorno.ItemSucursal.SUCR_Codigo, Item.CCOT_Numero, Item.CCOT_Tipo);

            ReportPath = System.Windows.Forms.Application.StartupPath + @"\Reportes\rptCOM007OrdenVentaExpo.rdlc";

            this.Parameters = new Microsoft.Reporting.WinForms.ReportParameter[18];
            Parameters[0] = new Microsoft.Reporting.WinForms.ReportParameter("DOOV_MBL", (String.IsNullOrEmpty(Item.DOOV_MBL) ? "" : Item.DOOV_MBL.Trim()));
            Parameters[1] = new Microsoft.Reporting.WinForms.ReportParameter("CCOT_NumDoc", Item.CCOT_NumDoc);
            Parameters[2] = new Microsoft.Reporting.WinForms.ReportParameter("ENTC_NomCliente", Item.ENTC_NomCliente);
            Parameters[3] = new Microsoft.Reporting.WinForms.ReportParameter("NAVE_Nombre", Item.NAVE_Nombre);
            Parameters[4] = new Microsoft.Reporting.WinForms.ReportParameter("NVIA_FecETDMaster", Item.NVIA_FecETDMaster.HasValue ? Item.NVIA_FecETDMaster.Value.ToShortDateString() : "");
            Parameters[5] = new Microsoft.Reporting.WinForms.ReportParameter("NVIA_FecCutOff", Item.NVIA_FecCutOff.HasValue ? Item.NVIA_FecCutOff.Value.ToString() : "");
            Parameters[6] = new Microsoft.Reporting.WinForms.ReportParameter("DCOT_Producto", Item.DCOT_Producto);
            Parameters[7] = new Microsoft.Reporting.WinForms.ReportParameter("PUER_NombreOrigen", Item.PUER_NombreOrigen);
            Parameters[8] = new Microsoft.Reporting.WinForms.ReportParameter("PUER_NombreDestino", Item.PUER_NombreDestino);
            Parameters[9] = new Microsoft.Reporting.WinForms.ReportParameter("DCOT_Peso", Item.DCOT_Peso.HasValue ? Item.DCOT_Peso.Value.ToString("0,0.00") + " TN APROX." : "0.00 TN APROX.");
            Parameters[10] = new Microsoft.Reporting.WinForms.ReportParameter("PACK_DescC", Item.PACK_DescC);
            Parameters[11] = new Microsoft.Reporting.WinForms.ReportParameter("DCOT_Cantidad", Item.DCOT_Cantidad.HasValue ? Convert.ToInt32(Item.DCOT_Cantidad.Value).ToString() : "");
            Parameters[12] = new Microsoft.Reporting.WinForms.ReportParameter("CCOT_PagoMBL", String.IsNullOrEmpty(Item.CCOT_PagoMBL) ? "" : Item.CCOT_PagoMBL == "C" ? "COLLECT" : "PREPAID");
            Parameters[13] = new Microsoft.Reporting.WinForms.ReportParameter("DCOT_PrecioUniVenta", Item.DCOT_PrecioUniVenta.HasValue ? Item.DCOT_PrecioUniVenta.Value.ToString("0.00") : "");
            Parameters[14] = new Microsoft.Reporting.WinForms.ReportParameter("ENTC_NomAgentePort", Item.ENTC_NomAgentePort);
            Parameters[15] = new Microsoft.Reporting.WinForms.ReportParameter("TIPO_DescDTM", Item.ENTC_NomDepTemporal);
            Parameters[16] = new Microsoft.Reporting.WinForms.ReportParameter("DOOV_MBL2", Item.DDOV_NroBooking);
            Parameters[17] = new Microsoft.Reporting.WinForms.ReportParameter("ENTC_NomEjecutivo", Item.ENTC_NomEjecutivo);

            RView.ShowItems();
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Title, "Ha ocurrido un error cargando el reporte.", ex); }
      }
      public void LimpiarReporteOrdenVentaExpo()
      {
         try
         {
            ReportPath = System.Windows.Forms.Application.StartupPath + @"\Reportes\rptCOM007OrdenVentaExpo.rdlc";

            this.Parameters = new Microsoft.Reporting.WinForms.ReportParameter[37];

            LView.ShowItems();
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Title, "Ha ocurrido un error limpiando el reporte.", ex); }
      }
      #endregion
   }
}
