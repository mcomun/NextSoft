using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using System.ComponentModel;
using Delfin.Entities;
using Delfin.Principal.Properties;
using Infrastructure.Aspect.Constants;
using Infrastructure.Client.FormClose;
using Infrastructure.WinFormsControls;
using Telerik.WinControls;
using Telerik.WinControls.UI;
using Telerik.WinControls.UI.Localization;

namespace Delfin.Principal
{
   public partial class PRO007LView : UserControl, IPRO007LView
   {
      #region [ Variables ]

      #endregion

      #region [ Formulario ]

      public PRO007LView(RadPageViewPage x_tabPageControl)
      {
         InitializeComponent();
         try
         {
            TabPageControl = x_tabPageControl;
            btnNuevo.Click += btnNuevo_Click;
            btnBuscar.Click += btnBuscar_Click;
            btnExportar.Click += btnExportar_Click;
            btnDeshacer.Click += btnDeshacer_Click;
            btnNuevoFactLibre.Click += btnNuevoFactLibre_Click;
            BSItems = new BindingSource();
            BSItems.CurrentItemChanged += BSItems_CurrentItemChanged;
            BSItemsDocMandato = new BindingSource();
            BSItemsDocMandato.CurrentItemChanged += BSItemsDocMandato_CurrentItemChanged;
            grdItems.CommandCellClick += grdItems_CommandCellClick;
            grdItems.CellFormatting += grdItems_CellFormatting;
            grdItemsDocMandato.CommandCellClick += grdItemsDocMandato_CommandCellClick;
            grdItemsDocMandato.CellFormatting += grdItemsDocMandato_CellFormatting;
            TitleView.FormClose += TitleView_FormClose;
            cmbTIPE_Codigo.SelectedIndexChanged += cmbTIPE_Codigo_SelectedIndexChanged;
            cmbDocOrigen.SelectedIndexChanged += cmbDocOrigen_SelectedIndexChanged;
            btnBuscar.Enabled = false;
            //txtSERI_UnidadNegocio.ReadOnly = true;
         }
         catch (Exception ex)
         { Dialogos.MostrarMensajeError(Presenter.Title, Mensajes.ConstructorView, ex); }
      }

      #endregion

      #region [ Propiedades ]

      public RadPageViewPage TabPageControl { get; set; }
      public Image IconView { get { return TitleView.FormIcon; } set { TitleView.FormIcon = value; } }
      public PRO007Presenter Presenter { get; set; }
      public BindingSource BSItems { get; set; }
      public BindingSource BSItemsDocMandato { get; set; }

      #endregion

      #region [ IPRO007LView ]

      public void LoadView()
      {
         try
         {
            tabBase.HideTabsMode = Crownwood.DotNetMagic.Controls.HideTabsModes.HideAlways;
            cmbTIPE_Codigo.LoadControl(Presenter.ContainerService, "Tipo de Entidad", "< Sel. Tipo de Entidad >", ListSortDirection.Ascending);
            cmbDOCV_Estado.LoadControl(Presenter.ContainerService, "Tabla Estado", "FAC", "< Selecione Estado >", ListSortDirection.Descending);
            cmbDOCV_Estado.SelectedValue = Infrastructure.Aspect.Constants.Util.getTipoTDO(Infrastructure.Aspect.Constants.TipoTDO.FACTURA);
            txaENTC_Codigo.LoadControl(Presenter.ContainerService, Delfin.Controls.TiposEntidad.TIPE_Cliente);
            cmbDocOrigen.LoadControl("Origen de Documento de Facturación", Delfin.Controls.Tipos.ComboBoxConstantes.OConstantes.DocOrigen, "< Sel. Origen Doc. >", ListSortDirection.Ascending);

            BSItems.DataSource = null;
            grdItems.DataSource = BSItems;
            navItems.BindingSource = BSItems;
            BSItems.ResetBindings(true);
            mdtFecDesde.NSFecha = Presenter.Session.Fecha;
            mdtFecHasta.NSFecha = Presenter.Session.Fecha;
            txtDOCV_Numero.Clear();
            txaENTC_Codigo.Clear();
            FormatDataGrid();
            FormatDataGridDocMandato();
            btnBuscar.Enabled = false;
            if (!String.IsNullOrEmpty(Presenter.TipoDocumentoVenta))
            {
               switch (Presenter.TipoDocumentoVenta)
               {
                  case "PreFactura":
                     btnNuevo.Visible = true;
                     btnNuevo.Enabled = true;
                     lblDOCV_Numero.Visible = false;
                     txtDOCV_Numero.Visible = false;
                     label2.Visible = false;
                     cmbDOCV_Estado.Visible = false;
                     cmbDocOrigen.SelectedValue = "OP";
                     cmbDocOrigen.Enabled = false;
                     //txaSeries.LoadControl(Presenter.ContainerService, "Ayuda de Series", new String[] { "001", "003" }, new String[] { "S" });
                     tabBase.HideTabsMode = Crownwood.DotNetMagic.Controls.HideTabsModes.HideAlways;
                     tabBase.SelectedTab = tpgFacturas;
                     btnBuscar.Enabled = true;
                     break;
                  case "Factura":
                     chkEstado.Visible = false;
                     btnNuevo.Visible = false;
                     //txaSeries.LoadControl(Presenter.ContainerService, "Ayuda de Series", new String[] { "001", "003", "007", "100" });
                     //tabBase.HideTabsMode = Crownwood.DotNetMagic.Controls.HideTabsModes.ShowAlways;
                     tabBase.SelectedTab = tpgFacturas;
                     tabBase.SelectionChanged += tabBase_SelectionChanged;
                     btnNuevoFactLibre.Visible = Presenter.FactLibre;
                     break;
                  case "eFact":
                     chkEstado.Visible = false;
                     btnNuevo.Visible = false;
                     //txaSeries.LoadControl(Presenter.ContainerService, "Ayuda de Series", new String[] { "001", "003", "007", "100" });
                     //tabBase.HideTabsMode = Crownwood.DotNetMagic.Controls.HideTabsModes.ShowAlways;
                     tabBase.SelectedTab = tpgFacturas;
                     tabBase.SelectionChanged += tabBase_SelectionChanged;
                     btnNuevoFactLibre.Visible = Presenter.FactLibre;
                     break;
               }
            }
            TitleView.Caption = Presenter.TipoDocumentoVenta;
            grdItems.Enabled = false;
            grdItemsDocMandato.Enabled = false;

            btnExportar.Enabled = false;

            txaSeries.SelectedItemSerieChanged += txaSeries_SelectedItemSerieChanged;
         }
         catch (Exception ex)
         { Dialogos.MostrarMensajeError(Presenter.Title, Mensajes.LoadView, ex); }
      }

      public void ShowItems()
      {
         try
         {
            if (!String.IsNullOrEmpty(Presenter.TipoDocumentoVenta))
            {
               switch (Presenter.TipoDocumentoVenta)
               {
                  case "PreFactura":
                     switch (Presenter.TipoFacturacion)
                     {
                        case PRO007Presenter.TFacturacion.SLI:
                           BSItems.DataSource = Presenter.ItemsPreDocsVta;
                           break;
                        case PRO007Presenter.TFacturacion.Mandato:
                           BSItemsDocMandato.DataSource = Presenter.ItemsCtaCteDocMandato;
                           break;
                        case PRO007Presenter.TFacturacion.Otros:
                           BSItems.DataSource = Presenter.ItemsCtaCte;
                           break;
                     }
                     break;
                  case "Factura":
                     switch (Presenter.TipoFacturacion)
                     {
                         case PRO007Presenter.TFacturacion.SLI:
                         case PRO007Presenter.TFacturacion.Otros:
                             BSItems.DataSource = Presenter.ItemsDocsVta;
                             break;
                         case PRO007Presenter.TFacturacion.Mandato:
                             BSItemsDocMandato.DataSource = Presenter.ItemsCtaCteDocMandato;
                             grdItemsDocMandato.DataSource = BSItemsDocMandato;
                             navItemsDocMandato.BindingSource = BSItemsDocMandato;
                             BSItemsDocMandato.ResetBindings(true);
                             if (grdItemsDocMandato.RowCount > 0)
                             {
                                 grdItemsDocMandato.Enabled = true;
                                 btnExportar.Enabled = true;
                                 GridAutoFit.Fit(grdItemsDocMandato);
                             }
                             else
                             {
                                 grdItemsDocMandato.Enabled = false;
                                 btnExportar.Enabled = false;
                             }
                             break;
                     }
                     break;
                     case "eFact":
                     switch (Presenter.TipoFacturacion)
                     {
                        case PRO007Presenter.TFacturacion.SLI:
                        case PRO007Presenter.TFacturacion.Otros:
                           BSItems.DataSource = Presenter.ItemsDocsVta;
                           break;
                        case PRO007Presenter.TFacturacion.Mandato:
                           BSItemsDocMandato.DataSource = Presenter.ItemsCtaCteDocMandato;
                           grdItemsDocMandato.DataSource = BSItemsDocMandato;
                           navItemsDocMandato.BindingSource = BSItemsDocMandato;
                           BSItemsDocMandato.ResetBindings(true);
                           if (grdItemsDocMandato.RowCount > 0)
                           {
                              grdItemsDocMandato.Enabled = true;
                              btnExportar.Enabled = true;
                              GridAutoFit.Fit(grdItemsDocMandato);
                           }
                           else
                           {
                              grdItemsDocMandato.Enabled = false;
                              btnExportar.Enabled = false;
                           }
                           break;
                        default:
                           break;
                     }

                     break;
               }
            }
            grdItems.DataSource = BSItems;
            navItems.BindingSource = BSItems;
            BSItems.ResetBindings(true);
            if (grdItems.RowCount > 0)
            {
               grdItems.Enabled = true;
               btnExportar.Enabled = true;
               GridAutoFit.Fit(grdItems);
               if (Presenter.TipoDocumentoVenta.Equals("Factura"))
               { grdItems.Columns["TipoCambio"].FormatString = "{0:#,##0.000}"; }
            }
            else
            {
               grdItems.Enabled = false;
               btnExportar.Enabled = false;
            }
         }
         catch (Exception ex)
         { Dialogos.MostrarMensajeError(Presenter.Title, Mensajes.ShowItems, ex); }
      }

      public void FiltrosLView()
      {
         try
         {
            Presenter.NroFacturaFiltro = !String.IsNullOrEmpty(txtDOCV_Numero.Text) ? txtDOCV_Numero.Text : null;
            Presenter.FecEmisiónIniFiltro = mdtFecDesde.NSFecha != null ? mdtFecDesde.NSFecha.Value : (DateTime?)null;
            Presenter.FecEmisiónFinFiltro = mdtFecHasta.NSFecha != null ? mdtFecHasta.NSFecha.Value : (DateTime?)null;

            if (txaENTC_Codigo.SelectedItem != null)
            { Presenter.Entc_CodigoFiltro = txaENTC_Codigo.SelectedItem.ENTC_Codigo; }
            else { Presenter.Entc_CodigoFiltro = null; }
            Presenter.F_TIPO_TabTDO = null; Presenter.F_TIPO_CodTDO = null; Presenter.F_Serie = null; Presenter.F_UnidadNegocio = null;
            if (txaSeries.Enabled && txaSeries.SelectedItem != null)
            {
               Presenter.F_TIPO_TabTDO = txaSeries.SelectedItem.TIPO_TabTDO;
               Presenter.F_TIPO_CodTDO = txaSeries.SelectedItem.TIPO_CodTDO;
               Presenter.F_Serie = txaSeries.SelectedItem.SERI_Serie;
               Presenter.F_UnidadNegocio = txaSeries.SelectedItem.SERI_UnidadNegocio;
            }
            if (!txaSeries.Enabled && tabBase.SelectedTab == tpgDocMandato)
            { Presenter.F_UnidadNegocio = "M"; }

            Presenter.F_Estado = chkEstado.Checked;
            Presenter.F_DocumentosSinSerie = chkFacturaSinSerie.Checked;
            if (cmbDOCV_Estado.SelectedValue == null)
            { Presenter.F_DOCV_Estado = null; }
            else
            { Presenter.F_DOCV_Estado = cmbDOCV_Estado.SelectedValue.ToString() == "001" ? "E" : cmbDOCV_Estado.SelectedValue.ToString() == "002" ? "I" : "A"; }

            if (Presenter.F_UnidadNegocio == null)
            {
               if (cmbDocOrigen.ConstantesSelectedItem.CONS_CodTipo.Equals("OP"))
               { Presenter.F_UnidadNegocio = "S"; }
               else { Presenter.F_UnidadNegocio = null; }
            }
         }
         catch (Exception ex)
         { Dialogos.MostrarMensajeError(Presenter.Title, Mensajes.LoadView, ex); }
      }

      #endregion

      #region [ Metodos ]

      public void EliminarFiltros()
      {
         try
         {
            for (int i = 0; i < grdItems.ColumnCount; i++)
            {
               grdItems.FilterDescriptors.Clear();
            }
         }
         catch (Exception)
         { }
      }
      ToolStripMenuItem tsmTodos;
      String[] defaultColumns;
      private void FormatDataGrid()
      {
         try
         {
            RadGridLocalizationProvider.CurrentProvider = new MySpanishRadGridLocalizationProvider();
            grdItems.Columns.Clear();
            grdItems.AllowAddNewRow = false;
            GridViewCommandColumn commandColumn;
            GridViewCommandColumn commandColumn2;
            commandColumn = new GridViewCommandColumn();
            commandColumn.Name = "Edit";
            commandColumn.HeaderText = @"Editar";
            commandColumn.DefaultText = @"Editar";
            commandColumn.UseDefaultText = true;
            grdItems.Columns.Add(commandColumn);
            grdItems.Columns["Edit"].AllowSort = false;
            grdItems.Columns["Edit"].AllowFiltering = false;

            commandColumn = new GridViewCommandColumn();
            commandColumn.Name = "Anular";
            commandColumn.HeaderText = @"Anular";
            commandColumn.DefaultText = @"Anular";
            commandColumn.UseDefaultText = true;
            grdItems.Columns.Add(commandColumn);
            grdItems.Columns["Anular"].AllowSort = false;
            grdItems.Columns["Anular"].AllowFiltering = false;

            if (!String.IsNullOrEmpty(Presenter.TipoDocumentoVenta))
            {
               switch (Presenter.TipoDocumentoVenta)
               {
                  case "PreFactura":
                     commandColumn = new GridViewCommandColumn();
                     commandColumn.Name = "Facturar";
                     commandColumn.HeaderText = @"Facturar";
                     commandColumn.DefaultText = @"Facturar";
                     commandColumn.UseDefaultText = true;
                     grdItems.Columns.Add(commandColumn);
                     grdItems.Columns["Facturar"].AllowSort = false;
                     grdItems.Columns["Facturar"].AllowFiltering = false;
                     break;
                  case "Factura":
                     commandColumn2 = new GridViewCommandColumn();
                     commandColumn2.Name = "Revisar";
                     commandColumn2.HeaderText = "Revisar";
                     commandColumn2.DefaultText = "Revisar";
                     commandColumn2.UseDefaultText = true;
                     this.grdItems.Columns.Add(commandColumn2);
                     this.grdItems.Columns["Revisar"].AllowSort = false;
                     this.grdItems.Columns["Revisar"].AllowFiltering = false;

                     commandColumn = new GridViewCommandColumn();
                     commandColumn.Name = "Impresion";
                     commandColumn.HeaderText = @"Impresión";
                     commandColumn.DefaultText = @"Impresión";
                     commandColumn.UseDefaultText = true;
                     grdItems.Columns.Add(commandColumn);
                     grdItems.Columns["Impresion"].AllowSort = false;
                     grdItems.Columns["Impresion"].AllowFiltering = false;
                     break;

                       
                  case "eFact":
                     commandColumn2 = new GridViewCommandColumn();
                     commandColumn2.Name = "Revisar";
                     commandColumn2.HeaderText = "Revisar";
                     commandColumn2.DefaultText = "Revisar";
                     commandColumn2.UseDefaultText = true;
                     this.grdItems.Columns.Add(commandColumn2);
                     this.grdItems.Columns["Revisar"].AllowSort = false;
                     this.grdItems.Columns["Revisar"].AllowFiltering = false;

                     commandColumn = new GridViewCommandColumn();
                     commandColumn.Name = "Impresion";
                     commandColumn.HeaderText = @"Impresión";
                     commandColumn.DefaultText = @"Impresión";
                     commandColumn.UseDefaultText = true;
                     grdItems.Columns.Add(commandColumn);
                     grdItems.Columns["Impresion"].AllowSort = false;
                     grdItems.Columns["Impresion"].AllowFiltering = false;
                     break;

               }
            }
            switch (Presenter.TipoDocumentoVenta)
            {
               case "PreFactura":

                  switch (Presenter.TipoFacturacion)
                  {
                     case PRO007Presenter.TFacturacion.Otros:
                        grdItems.Columns.Add("CCCT_Serie", "Serie", "CCCT_Serie");
                        //grdItems.Columns.Add("CCCT_Numero", "Nro. Factura", "CCCT_Numero");
                        grdItems.Columns.Add("CCCT_FechaEmision", "Fecha Emisión", "CCCT_FechaEmision");
                        grdItems.Columns.Add("ENTC_DocIden", "R.U.C.", "ENTC_DocIden");
                        grdItems.Columns.Add("ENTC_RazonSocial", "Cliente", "ENTC_RazonSocial");
                        grdItems.Columns.Add("TIPO_MND", "Moneda", "TIPO_MND");
                        grdItems.Columns.Add("CCCT_Monto", "Valor Venta", "CCCT_Monto");
                        grdItems.Columns.Add("DOOV_HBL", "HBL", "DOOV_HBL");
                        grdItems.Columns.Add("DOOV_MBL", "MBL", "DOOV_MBL");
                        grdItems.Columns.Add("NumDoc", "Nro. Operación", "NumDoc");
                        //grdItems.Columns.Add("CCCT_Estado_text", "Estado", "CCCT_Estado_text");
                        break;
                     case PRO007Presenter.TFacturacion.SLI:
                        grdItems.Columns.Add("TIPO_TDO", "Tipo Documento", "TIPO_TDO");
                        grdItems.Columns.Add("DOCV_Serie", "Serie", "DOCV_Serie");
                        //grdItems.Columns.Add("DOCV_Numero", "Nro. Factura", "DOCV_Numero");
                        grdItems.Columns.Add("DOCV_FechaEmision", "Fecha Emisión", "DOCV_FechaEmision");
                        grdItems.Columns.Add("ENTC_DocIden", "R.U.C.", "ENTC_DocIden");
                        grdItems.Columns.Add("Cliente", "Cliente", "Cliente");
                        grdItems.Columns.Add("Moneda", "Moneda", "Moneda");
                        grdItems.Columns.Add("DOCV_ValorVtaTotal", "Valor Venta", "DOCV_ValorVtaTotal");
                        grdItems.Columns.Add("COPE_HBL", "HBL", "COPE_HBL");
                        grdItems.Columns.Add("COPE_NumDoc", "Nro. Operación", "COPE_NumDoc");
                        grdItems.Columns.Add("DOCV_EstadoStr", "Estado", "DOCV_EstadoStr");
                        grdItems.Columns.Add("PDOC_Codigo", "Interno", "PDOC_Codigo");
                        break;
                     default:
                        break;
                  }
                  break;
               case "Factura":
                  grdItems.Columns.Add("TIPO_TDO", "Tipo Documento", "TIPO_TDO");
                  grdItems.Columns.Add("DOCV_Serie", "Serie", "DOCV_Serie");
                  grdItems.Columns.Add("DOCV_Numero", "Número", "DOCV_Numero");
                  grdItems.Columns.Add("DOCV_FechaEmision", "Fecha Emisión", "DOCV_FechaEmision");
                  grdItems.Columns.Add("ENTC_DocIden", "R.U.C / DNI", "ENTC_DocIden");
                  grdItems.Columns.Add("Cliente", "Cliente", "Cliente");

                  grdItems.Columns.Add("TIPO_FPG", "Forma de Pago", "TIPO_FPG");
                  commandColumn = new GridViewCommandColumn();
                  commandColumn.Name = "FPG";
                  commandColumn.HeaderText = @"F. Pago";
                  commandColumn.DefaultText = @"FPG";
                  commandColumn.UseDefaultText = true;
                  grdItems.Columns.Add(commandColumn);
                  grdItems.Columns["FPG"].AllowSort = false;
                  grdItems.Columns["FPG"].AllowFiltering = false;
                  grdItems.Columns.Add("DOCV_FechaVcmto", "Fecha Vencimiento", "DOCV_FechaVcmto");

                  grdItems.Columns.Add("Moneda", "Moneda", "Moneda");
                  grdItems.Columns.Add("DOCV_ValorVtaTotal", "Valor Venta", "DOCV_ValorVtaTotal");
                  grdItems.Columns.Add("HBL_MBL", "HBL / MBL", "HBL_MBL");
                  grdItems.Columns.Add("OV_OP", "OV / OP", "OV_OP");
                  grdItems.Columns.Add("DOCV_EstadoStr", "Estado", "DOCV_EstadoStr");

                  commandColumn = new GridViewCommandColumn();
                  commandColumn.Name = "REGENERAR";
                  commandColumn.HeaderText = @"Regenerar";
                  commandColumn.DefaultText = @"REGENERAR";
                  commandColumn.UseDefaultText = true;

                  if (cmbDocOrigen.ConstantesSelectedItem != null)
                  {
                     if (cmbDocOrigen.ConstantesSelectedItem.CONS_CodTipo.Equals("OV"))
                     {
                        commandColumn.IsVisible = true;
                     }
                     else if (cmbDocOrigen.ConstantesSelectedItem.CONS_CodTipo.Equals("OP"))
                     {
                        commandColumn.IsVisible = false;
                     }
                  }

                  grdItems.Columns.Add(commandColumn);

                  grdItems.Columns.Add("CCCT_Glosa", "Concepto", "CCCT_Glosa");
                  grdItems.Columns.Add("AsientoContable", "Nro. Asiento", "AsientoContable");

                  grdItems.Columns.Add("Base", "Base Imponible", "Base");
                  grdItems.Columns.Add("IGV", "IGV", "IGV");
                  grdItems.Columns.Add("CCCT_Monto_S", "Total S/.", "CCCT_Monto_S");
                  grdItems.Columns.Add("CCCT_Monto_D", "Total US$", "CCCT_Monto_D");

                  GridViewDecimalColumn ESER_Cantidad;
                  ESER_Cantidad = new GridViewDecimalColumn();
                  ESER_Cantidad.Name = "TipoCambio";
                  ESER_Cantidad.HeaderText = "Tipo Cambio";
                  ESER_Cantidad.FieldName = "TipoCambio";
                  ESER_Cantidad.DecimalPlaces = 3;
                  ESER_Cantidad.Maximum = 9999;
                  ESER_Cantidad.Minimum = 0;
                  grdItems.Columns.Add(ESER_Cantidad);
                  grdItems.Columns["TipoCambio"].Width = 90;
                  grdItems.Columns["TipoCambio"].TextAlignment = ContentAlignment.MiddleRight;
                  grdItems.Columns["TipoCambio"].ReadOnly = false;


                  //grdItems.Columns.Add("TipoCambio", "Tipo Cambio", "TipoCambio");

                  grdItems.Columns.Add("DOCV_Codigo", "Interno", "DOCV_Codigo");
                  break;




               case "eFact":
                  grdItems.Columns.Add("TIPO_TDO", "Tipo Documento", "TIPO_TDO");
                  grdItems.Columns.Add("DOCV_Serie", "Serie", "DOCV_Serie");
                  grdItems.Columns.Add("DOCV_Numero", "Número", "DOCV_Numero");
                  grdItems.Columns.Add("DOCV_FechaEmision", "Fecha Emisión", "DOCV_FechaEmision");
                  grdItems.Columns.Add("ENTC_DocIden", "R.U.C / DNI", "ENTC_DocIden");
                  grdItems.Columns.Add("Cliente", "Cliente", "Cliente");
                  grdItems.Columns.Add("emailFE", "Email", "emailFE");

                  grdItems.Columns.Add("TIPO_FPG", "Forma de Pago", "TIPO_FPG");
                  commandColumn = new GridViewCommandColumn();
                  commandColumn.Name = "FPG";
                  commandColumn.HeaderText = @"F. Pago";
                  commandColumn.DefaultText = @"FPG";
                  commandColumn.UseDefaultText = true;
                  grdItems.Columns.Add(commandColumn);
                  grdItems.Columns["FPG"].AllowSort = false;
                  grdItems.Columns["FPG"].AllowFiltering = false;
                  grdItems.Columns.Add("DOCV_FechaVcmto", "Fecha Vencimiento", "DOCV_FechaVcmto");

                  grdItems.Columns.Add("Moneda", "Moneda", "Moneda");
                  grdItems.Columns.Add("DOCV_ValorVtaTotal", "Valor Venta", "DOCV_ValorVtaTotal");
                  grdItems.Columns.Add("HBL_MBL", "HBL / MBL", "HBL_MBL");
                  grdItems.Columns.Add("OV_OP", "OV / OP", "OV_OP");
                  grdItems.Columns.Add("DOCV_EstadoStr", "Estado", "DOCV_EstadoStr");

                  commandColumn = new GridViewCommandColumn();
                  commandColumn.Name = "REGENERAR";
                  commandColumn.HeaderText = @"Regenerar";
                  commandColumn.DefaultText = @"REGENERAR";
                  commandColumn.UseDefaultText = true;

                  if (cmbDocOrigen.ConstantesSelectedItem != null)
                  {
                      if (cmbDocOrigen.ConstantesSelectedItem.CONS_CodTipo.Equals("OV"))
                      {
                          commandColumn.IsVisible = true;
                      }
                      else if (cmbDocOrigen.ConstantesSelectedItem.CONS_CodTipo.Equals("OP"))
                      {
                          commandColumn.IsVisible = false;
                      }
                  }

                  grdItems.Columns.Add(commandColumn);

                  grdItems.Columns.Add("CCCT_Glosa", "Concepto", "CCCT_Glosa");
                  grdItems.Columns.Add("AsientoContable", "Nro. Asiento", "AsientoContable");

                  grdItems.Columns.Add("Base", "Base Imponible", "Base");
                  grdItems.Columns.Add("IGV", "IGV", "IGV");
                  grdItems.Columns.Add("CCCT_Monto_S", "Total S/.", "CCCT_Monto_S");
                  grdItems.Columns.Add("CCCT_Monto_D", "Total US$", "CCCT_Monto_D");

                  GridViewDecimalColumn ESER_Cantidad_eFact;
                  ESER_Cantidad_eFact = new GridViewDecimalColumn();
                  ESER_Cantidad_eFact.Name = "TipoCambio";
                  ESER_Cantidad_eFact.HeaderText = "Tipo Cambio";
                  ESER_Cantidad_eFact.FieldName = "TipoCambio";
                  ESER_Cantidad_eFact.DecimalPlaces = 3;
                  ESER_Cantidad_eFact.Maximum = 9999;
                  ESER_Cantidad_eFact.Minimum = 0;
                  grdItems.Columns.Add(ESER_Cantidad_eFact);
                  grdItems.Columns["TipoCambio"].Width = 90;
                  grdItems.Columns["TipoCambio"].TextAlignment = ContentAlignment.MiddleRight;
                  grdItems.Columns["TipoCambio"].ReadOnly = false;


                  //grdItems.Columns.Add("TipoCambio", "Tipo Cambio", "TipoCambio");

                  grdItems.Columns.Add("DOCV_Codigo", "Interno", "DOCV_Codigo");
                  break;

            }

            grdItems.BestFitColumns();

            tsmColumnas.DropDownItems.Clear();
            defaultColumns = new string[grdItems.Columns.Count];
            int index = 0;
            foreach (GridViewDataColumn column in grdItems.Columns)
            {
               ToolStripMenuItem _item = new ToolStripMenuItem(column.HeaderText);
               _item.Tag = column.Name;
               _item.Checked = column.IsVisible;
               _item.CheckOnClick = true;
               _item.Click += tsmColumna_Click;
               tsmColumnas.DropDownItems.Add(_item);

               if (column.IsVisible)
               { defaultColumns[index] = column.Name; index += 1; }
            }

            ToolStripSeparator tsmSeparacion = new ToolStripSeparator();
            tsmColumnas.DropDownItems.Add(tsmSeparacion);
            tsmTodos = new ToolStripMenuItem("Todos");
            tsmTodos.Tag = "Todas";
            tsmTodos.Checked = false;
            tsmTodos.CheckOnClick = true;
            tsmTodos.Click += tsmTodos_Click;
            tsmColumnas.DropDownItems.Add(tsmTodos);
            GridAutoFit.Fit(grdItems);
         }
         catch (Exception ex)
         { Dialogos.MostrarMensajeError(Presenter.Title, Mensajes.FormatDataGridView, ex); }
      }
      private void FormatDataGridDocMandato()
      {
         try
         {
            RadGridLocalizationProvider.CurrentProvider = new MySpanishRadGridLocalizationProvider();
            grdItemsDocMandato.Columns.Clear();
            grdItemsDocMandato.AllowAddNewRow = false;
            GridViewCommandColumn commandColumn;
            GridViewCommandColumn commandColumn2;

            commandColumn = new GridViewCommandColumn();
            commandColumn.Name = "Impresion";
            commandColumn.HeaderText = @"Impresión";
            commandColumn.DefaultText = @"Impresión";
            commandColumn.UseDefaultText = true;
            grdItemsDocMandato.Columns.Add(commandColumn);
            grdItemsDocMandato.Columns["Impresion"].AllowSort = false;
            grdItemsDocMandato.Columns["Impresion"].AllowFiltering = false;

            grdItemsDocMandato.Columns.Add("TIPO_TDO", "Tipo Documento", "TIPO_TDO");
            grdItemsDocMandato.Columns.Add("CCCT_Serie", "Serie", "CCCT_Serie");
            grdItemsDocMandato.Columns.Add("CCCT_Numero", "Número", "CCCT_Numero");
            grdItemsDocMandato.Columns.Add("CCCT_FechaEmision", "Fecha Emisión", "CCCT_FechaEmision");
            grdItemsDocMandato.Columns.Add("ENTC_DocIden", "R.U.C / DNI", "ENTC_DocIden");
            grdItemsDocMandato.Columns.Add("ENTC_RazonSocial", "Entidad", "ENTC_RazonSocial");

            grdItemsDocMandato.Columns.Add("TIPO_MND", "Moneda", "TIPO_MND");
            grdItemsDocMandato.Columns.Add("CCCT_Monto", "Valor Venta", "CCCT_Monto");
            grdItemsDocMandato.Columns.Add("MBL_HBL", "HBL / MBL", "MBL_HBL");
            grdItemsDocMandato.Columns.Add("OV_OP", "OV / OP", "OV_OP");
            //grdItemsDocMandato.Columns.Add("DOCV_EstadoStr", "Estado", "DOCV_EstadoStr");
            grdItemsDocMandato.Columns.Add("CCCT_Glosa", "Concepto", "CCCT_Glosa");
            grdItemsDocMandato.Columns.Add("CCCT_Codigo", "Interno", "CCCT_Codigo");
            grdItemsDocMandato.Columns.Add("CCCT_RCImpreso_Text", "Impreso", "CCCT_RCImpreso_Text");

            grdItemsDocMandato.BestFitColumns();
            GridAutoFit.Fit(grdItemsDocMandato);
         }
         catch (Exception ex)
         { Dialogos.MostrarMensajeError(Presenter.Title, Mensajes.FormatDataGridView, ex); }
      }
      private void tsmColumna_Click(object sender, EventArgs e)
      {
         if (sender is ToolStripMenuItem)
         {
            ToolStripMenuItem _item = (ToolStripMenuItem)sender;
            grdItems.Columns[_item.Tag.ToString()].IsVisible = _item.Checked;
            tsmTodos.Checked = false;
         }
      }
      private void tsmTodos_Click(object sender, EventArgs e)
      {
         foreach (GridViewDataColumn column in grdItems.Columns)
         { column.IsVisible = tsmTodos.Checked; }

         foreach (ToolStripItem item in tsmColumnas.DropDownItems)
         { if (item is ToolStripMenuItem) { ((ToolStripMenuItem)item).Checked = tsmTodos.Checked; } }

         if (!tsmTodos.Checked)
         {
            foreach (String item in defaultColumns)
            {
               if (!String.IsNullOrEmpty(item))
               {
                  grdItems.Columns[item].IsVisible = true;
                  foreach (ToolStripItem tsitem in tsmColumnas.DropDownItems)
                  { if (tsitem is ToolStripMenuItem && tsitem.Tag.ToString() == item) { ((ToolStripMenuItem)tsitem).Checked = true; } }
               }
            }
         }
      }
      private void SeleccionarItem()
      {
         try
         {
            if (Presenter != null)
            {
               switch (Presenter.TipoFacturacion)
               {
                  case PRO007Presenter.TFacturacion.SLI:
                     if (BSItems != null && BSItems.Current != null && BSItems.Current is PreDocsVta)
                     { Presenter.ItemPreDocsVta = ((PreDocsVta)BSItems.Current); }
                     else
                     { Presenter.ItemPreDocsVta = null; }
                     break;
                  case PRO007Presenter.TFacturacion.Otros:
                     if (BSItems != null && BSItems.Current != null && BSItems.Current is CtaCte)
                     {
                        Presenter.ItemCtaCte = ((CtaCte)BSItems.Current);
                        Presenter.ItemCtaCte.SerieFacturacion = txaSeries.SelectedItem.SERI_Serie;
                     }
                     else
                     { Presenter.ItemCtaCte = null; }
                     break;
                  case PRO007Presenter.TFacturacion.Mandato:
                     if (BSItemsDocMandato != null && BSItemsDocMandato.Current != null && BSItemsDocMandato.Current is CtaCte)
                     {
                        Presenter.ItemCtaCteDocMandato = ((CtaCte)BSItemsDocMandato.Current);
                     }
                     else
                     { Presenter.ItemCtaCteDocMandato = null; }
                     break;
                     break;
                  default:
                     break;
               }
            }
         }
         catch (Exception ex)
         {
            if (Presenter != null)
               Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al seleccionar el item.", ex);
         }
      }
      private void SeleccionarItemFactura()
      {
         try
         {
            if (Presenter != null)
            {
               if (BSItems != null && BSItems.Current != null && BSItems.Current is DocsVta)
               { Presenter.ItemDocsVta = ((DocsVta)BSItems.Current); }
               else
               { Presenter.ItemDocsVta = null; }
            }
         }
         catch (Exception ex)
         {
            if (Presenter != null)
               Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al seleccionar el item.", ex);
         }
      }
      private bool BloquearBotonesEdicion()
      {
         if (Presenter.ItemPreDocsVta.DOCV_Estado.Equals("I") || Presenter.ItemPreDocsVta.DOCV_Estado.Equals("E")) return false;
         Dialogos.MostrarMensajeInformacion(Presenter.Title, "El registro anulado no se puede editar");
         return true;
      }
      private bool BloquearBotonesEdicionFacturacion()
      {
         if (Presenter.ItemDocsVta.DOCV_Estado.Equals("I") || Presenter.ItemDocsVta.DOCV_Estado.Equals("E")) return false;
         Dialogos.MostrarMensajeInformacion(Presenter.Title, "El registro anulado no se puede editar");
         return true;
      }
      private void Nuevo()
      {
         try
         {
            Presenter.Nuevo();
         }
         catch (Exception ex)
         { Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al hacer nuevo.", ex); }
      }

      private void NuevoFactLibre()
      {
         try
         {
            Presenter.NuevoFL();
         }
         catch (Exception ex)
         { Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al hacer Nuevo Fact. Libre.", ex); }
      }

      private void Buscar()
      {
         try
         {
            if (tabBase.SelectedTab == tpgFacturas)
            {
               FiltrosLView();
               FormatDataGrid();
               EliminarFiltros();
               Presenter.Actualizar();
            } if (tabBase.SelectedTab == tpgDocMandato)
            {
               FormatDataGrid();
               EliminarFiltros();
               Presenter.Actualizar();
            }
         }
         catch (Exception ex)
         { Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al buscar.", ex); }
      }
      private void Exportar()
      {
         try
         {
            List<String> Titulos = new List<String>();
            Titulos.Add("Reporte");
            Int32 _fila = 2;
            ExcelAportes _xls = new ExcelAportes(1, Titulos, "");
            Object[] _cabeceras = new Object[1];
            DataTable _dt = _xls.RadGridViewToDataTable(grdItems, ref _cabeceras, grdItems.FilterDescriptors.Count > 0);
            if (_dt.Rows.Count > 0)
            {
               List<String> _listTituloFiltro = new List<String>();
               _listTituloFiltro.Add("");
               _xls.InsertarTitulos(Presenter.Title, 1, ref _fila, 1, _listTituloFiltro, _cabeceras.Length);
               _xls.addDataArray(1, _cabeceras, 1, _fila + 2, true, true);
               _xls.addDataList(1, _dt, 1, _fila + 3, true, true);
            }
         }
         catch (Exception ex)
         { Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al exportar.", ex); }
      }
      private void Deshacer()
      {
         try
         {
            BSItems.DataSource = null;
            grdItems.DataSource = BSItems;
            navItems.BindingSource = BSItems;
            BSItems.ResetBindings(true);

            grdItems.Enabled = false;
            btnNuevo.Enabled = true;
            btnBuscar.Enabled = true;
            btnExportar.Enabled = false;
         }
         catch (Exception ex)
         { Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al deshacer la vista.", ex); }
      }

      #endregion

      #region [ Eventos ]

      private void btnNuevo_Click(object sender, EventArgs e)
      { Nuevo(); }
      private void btnNuevoFactLibre_Click(object sender, EventArgs e)
      { NuevoFactLibre(); }
      private void btnBuscar_Click(object sender, EventArgs e)
      { Buscar(); }
      private void btnExportar_Click(object sender, EventArgs e)
      { Exportar(); }
      private void btnDeshacer_Click(object sender, EventArgs e)
      { Deshacer(); }

      private void BSItems_CurrentItemChanged(object sender, EventArgs e)
      { SeleccionarItem(); }
      private void BSItemsDocMandato_CurrentItemChanged(object sender, EventArgs e)
      { SeleccionarItem(); }

      private void grdItems_CommandCellClick(object sender, EventArgs e)
      {
         try
         {
            if (sender is GridCommandCellElement)
            {
               switch ((((GridCommandCellElement)(sender)).CommandButton).TextElement.Text)
               {
                  case "Editar":
                     if (!String.IsNullOrEmpty(Presenter.TipoDocumentoVenta))
                     {
                        switch (Presenter.TipoDocumentoVenta)
                        {
                           case "PreFactura":
                              SeleccionarItem();
                              if (!BloquearBotonesEdicion())
                              {
                                 Presenter.TInicio = PRO007Presenter.TipoInicio.EditarPreFactura;
                                 Presenter.Editar("", 0);
                              }
                              break;

                           case "Factura":
                              SeleccionarItemFactura();
                              if (!BloquearBotonesEdicionFacturacion())
                              {
                                 if (Presenter.ItemDocsVta.TIPO_CodTDO.Equals(Infrastructure.Aspect.Constants.Util.getTipoTDO(Infrastructure.Aspect.Constants.TipoTDO.NOTA_CREDITO)))
                                 {
                                    Presenter.TInicio = PRO007Presenter.TipoInicio.EditarNotaCredito;
                                    Presenter.AbrirNotaCredito();
                                 }
                                 else
                                 {
                                    Presenter.TInicio = PRO007Presenter.TipoInicio.EditarPreFactura;
                                    Presenter.AbrirFactura();
                                 }
                              }
                              break;

                           case "eFact":
                              SeleccionarItemFactura();
                              if (!BloquearBotonesEdicionFacturacion())
                              {
                                  if (Presenter.ItemDocsVta.TIPO_CodTDO.Equals(Infrastructure.Aspect.Constants.Util.getTipoTDO(Infrastructure.Aspect.Constants.TipoTDO.NOTA_CREDITO)))
                                  {
                                      Presenter.TInicio = PRO007Presenter.TipoInicio.EditarNotaCredito;
                                      Presenter.AbrirNotaCredito();
                                  }
                                  else
                                  {
                                      Presenter.TInicio = PRO007Presenter.TipoInicio.EditarPreFactura;
                                      Presenter.AbrirFactura();
                                  }
                              }
                              break;


                        }
                     }
                     break;
                  case "Anular":
                     if (!String.IsNullOrEmpty(Presenter.TipoDocumentoVenta))
                     {
                        switch (Presenter.TipoDocumentoVenta)
                        {
                           case "PreFactura":
                              SeleccionarItem();
                              switch (Presenter.ItemPreDocsVta.DOCV_Estado)
                              {
                                 case "I":
                                    Dialogos.MostrarMensajeInformacion(Presenter.Title, "No puede Anular una pre factura cuando ya esta impresa");
                                    break;
                                 case "A":
                                    Dialogos.MostrarMensajeInformacion(Presenter.Title, "La pre factura ya ha sido anulada");
                                    break;
                                 case "E":
                                    Presenter.AnularPreFactura();
                                    break;
                              }
                              break;
                           case "Factura":
                              SeleccionarItemFactura();
                              switch (Presenter.TipoFacturacion)
                              {
                                 case PRO007Presenter.TFacturacion.SLI:
                                      Presenter.AnularFactura_SLI(Presenter.TipoDocumentoVenta);
                                    break;
                                 case PRO007Presenter.TFacturacion.Otros:
                                    Presenter.AnularFactura_OV(Presenter.TipoDocumentoVenta);
                                    break;
                                 default:
                                    break;
                              }

                              break;

                           case "eFact":
                              SeleccionarItemFactura();
                              switch (Presenter.TipoFacturacion)
                              {
                                  case PRO007Presenter.TFacturacion.SLI:
                                      Presenter.AnularFactura_SLI(Presenter.TipoDocumentoVenta);
                                      break;
                                  case PRO007Presenter.TFacturacion.Otros:
                                      Presenter.AnularFactura_OV(Presenter.TipoDocumentoVenta);
                                      break;
                                  default:
                                      break;
                              }

                              break;

                        }
                     }
                     break;
                  case "Facturar":
                     SeleccionarItem();
                     Presenter.Facturar();
                     break;
                  case "Impresión":
                     if (Infrastructure.WinForms.Controls.Dialogos.MostrarMensajePregunta(Presenter.Title, "¿Desea emitir el documento seleccionado?", Infrastructure.WinForms.Controls.Dialogos.LabelBoton.Si_No) == System.Windows.Forms.DialogResult.Yes)
                     {
                        SeleccionarItemFactura();
                        Presenter.TImpresion = PRO007Presenter.TipoImpresion.Imprimir;
                        if (!Presenter.ItemDocsVta.CCOT_Bloqueado)
                        {
                           if (Presenter.ItemDocsVta.TIPO_CodTDO.Equals(Infrastructure.Aspect.Constants.Util.getTipoTDO(Infrastructure.Aspect.Constants.TipoTDO.NOTA_CREDITO)))
                           { Presenter.ImpresionNC(); }
                           else if (Presenter.ItemDocsVta.TIPO_CodTDO.Equals(Infrastructure.Aspect.Constants.Util.getTipoTDO(Infrastructure.Aspect.Constants.TipoTDO.RECIBO_CAJA)))
                           { Presenter.ImpresionRC(); }
                           else if (Presenter.ItemDocsVta.TIPO_CodTDO.Equals(Infrastructure.Aspect.Constants.Util.getTipoTDO(Infrastructure.Aspect.Constants.TipoTDO.RECIBO_CREDITO)))
                           { Presenter.ImpresionRC(); }
                           else
                           { Presenter.Impresion(); }
                           Presenter.Actualizar();
                        }
                        else
                        { Dialogos.MostrarMensajeInformacion(Presenter.Title, String.Format("La orden de venta: {0} se encuentra bloqueada, no podra emitir ningún documento asociado.", Presenter.ItemDocsVta.OV_OP)); }

                     }
                     break;
                  case "Revisar":
                     SeleccionarItemFactura();
                     if (!String.IsNullOrEmpty(Presenter.ItemDocsVta.DOCV_Numero))
                     {
                        Presenter.TImpresion = PRO007Presenter.TipoImpresion.Revisar;
                        Presenter.Impresion();
                     }
                     else { Dialogos.MostrarMensajeInformacion(Presenter.Title, "No se puede revisar un documento que no ha sido impreso."); }
                     break;
                  case "FPG":
                     SeleccionarItemFactura();
                     if (Presenter.ItemDocsVta.TIPO_CodTDO.Equals("007"))
                     { }
                     else
                     {
                        SeleccionarItemFactura();
                        if (Presenter.FormaDePago()) { BSItems.ResetBindings(false); }
                     }
                     break;
                  case "REGENERAR":
                     SeleccionarItemFactura();
                     if (Presenter.RegenerarDocumento()) { BSItems.ResetBindings(false); }
                     break;
               }
            }
         }
         catch (Exception ex)
         { Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al cargar los botones para editar y anular.", ex); }

      }
      private void grdItems_CellFormatting(object sender, CellFormattingEventArgs e)
      {
         try
         {
            if (!(e.CellElement is GridCommandCellElement)) return;
            if (e.Column.Name.Equals("Edit"))
            {
               var bte = (RadButtonElement)e.CellElement.Children[0];
               if (bte.Image == null)
               {
                  bte.TextImageRelation = TextImageRelation.Overlay;
                  bte.DisplayStyle = DisplayStyle.Image;
                  bte.ImageAlignment = ContentAlignment.MiddleCenter;
                  bte.Image = Resources.editar16x16;
                  bte.ToolTipText = @"Editar Registro";
                  bte.AutoSize = true;
               }
            }
            if (e.Column.Name.Equals("Anular"))
            {
               var bte = (RadButtonElement)e.CellElement.Children[0];
               if (bte.Image == null)
               {
                  bte.TextImageRelation = TextImageRelation.Overlay;
                  bte.DisplayStyle = DisplayStyle.Image;
                  bte.ImageAlignment = ContentAlignment.MiddleCenter;
                  bte.Image = Resources.Sign_09;
                  bte.ToolTipText = @"Anular Pre-Factura";
                  bte.AutoSize = true;
               }
            }
            if (e.Column.Name.Equals("FPG"))
            {
               var bte = (RadButtonElement)e.CellElement.Children[0];
               if (bte.Image == null)
               {
                  bte.TextImageRelation = TextImageRelation.Overlay;
                  bte.DisplayStyle = DisplayStyle.Image;
                  bte.ImageAlignment = ContentAlignment.MiddleCenter;
                  bte.Image = Resources.document_into;
                  bte.ToolTipText = @"Editar la Forma de Pago";
                  bte.AutoSize = true;
               }
            }
            if (e.Column.Name.Equals("REGENERAR"))
            {
               var bte = (RadButtonElement)e.CellElement.Children[0];
               if (bte.Image == null)
               {
                  bte.TextImageRelation = TextImageRelation.Overlay;
                  bte.DisplayStyle = DisplayStyle.Image;
                  bte.ImageAlignment = ContentAlignment.MiddleCenter;
                  bte.Image = Resources.document_exchange_16x16;
                  bte.ToolTipText = @"Regenerar Documento de Venta";
                  bte.AutoSize = true;
               }
            }
            if (!String.IsNullOrEmpty(Presenter.TipoDocumentoVenta))
            {
               switch (Presenter.TipoDocumentoVenta)
               {
                  case "PreFactura":
                     if (e.Column.Name.Equals("Facturar"))
                     {
                        var bte = (RadButtonElement)e.CellElement.Children[0];
                        if (bte.Image == null)
                        {
                           bte.TextImageRelation = TextImageRelation.Overlay;
                           bte.DisplayStyle = DisplayStyle.Image;
                           bte.ImageAlignment = ContentAlignment.MiddleCenter;
                           bte.Image = Resources.Write_11;
                           bte.ToolTipText = @"Facturar";
                           bte.AutoSize = true;
                        }
                     }
                     break;
                  case "Factura":
                     if (e.Column.Name.Equals("Impresion"))
                     {
                        var bte = (RadButtonElement)e.CellElement.Children[0];
                        if (bte.Image == null)
                        {
                           bte.TextImageRelation = TextImageRelation.Overlay;
                           bte.DisplayStyle = DisplayStyle.Image;
                           bte.ImageAlignment = ContentAlignment.MiddleCenter;
                           bte.Image = Resources.printer2;
                           bte.ToolTipText = @"Impresión";
                           bte.AutoSize = true;
                        }
                     }
                     if (e.Column.Name.Equals("Revisar"))
                     {
                        RadButtonElement bte = (RadButtonElement)e.CellElement.Children[0];
                        if (bte.Image == null)
                        {
                           bte.TextImageRelation = TextImageRelation.Overlay;
                           bte.DisplayStyle = DisplayStyle.Image;
                           bte.ImageAlignment = ContentAlignment.MiddleCenter;
                           bte.Image = Resources.contract;
                           bte.ToolTipText = @"Revisar";
                           bte.AutoSize = true;
                        }
                     }
                     break;



                  case "eFact":
                     if (e.Column.Name.Equals("Impresion"))
                     {
                         var bte = (RadButtonElement)e.CellElement.Children[0];
                         if (bte.Image == null)
                         {
                             bte.TextImageRelation = TextImageRelation.Overlay;
                             bte.DisplayStyle = DisplayStyle.Image;
                             bte.ImageAlignment = ContentAlignment.MiddleCenter;
                             bte.Image = Resources.printer2;
                             bte.ToolTipText = @"Impresión";
                             bte.AutoSize = true;
                         }
                     }
                     if (e.Column.Name.Equals("Revisar"))
                     {
                         RadButtonElement bte = (RadButtonElement)e.CellElement.Children[0];
                         if (bte.Image == null)
                         {
                             bte.TextImageRelation = TextImageRelation.Overlay;
                             bte.DisplayStyle = DisplayStyle.Image;
                             bte.ImageAlignment = ContentAlignment.MiddleCenter;
                             bte.Image = Resources.contract;
                             bte.ToolTipText = @"Revisar";
                             bte.AutoSize = true;
                         }
                     }
                     break;

               }
            }
            if (e.CellElement.RowInfo is GridViewNewRowInfo && e.CellElement.ColumnInfo is GridViewCommandColumn)
            {
               e.CellElement.Children[0].Visibility = ElementVisibility.Hidden;
            }
         }
         catch (Exception ex) { Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al formatear el icono." + ex.Message); }
      }

      private void grdItemsDocMandato_CommandCellClick(object sender, EventArgs e)
      {
         try
         {
            if (sender is GridCommandCellElement)
            {
               switch ((((GridCommandCellElement)(sender)).CommandButton).TextElement.Text)
               {

                  case "Impresión":
                     if (Infrastructure.WinForms.Controls.Dialogos.MostrarMensajePregunta(Presenter.Title, "¿Desea emitir el documento seleccionado?", Infrastructure.WinForms.Controls.Dialogos.LabelBoton.Si_No) == System.Windows.Forms.DialogResult.Yes)
                     {
                        if (!Presenter.ItemCtaCteDocMandato.CCOT_Bloqueado)
                        { Presenter.ImpresionRC(); }
                        else
                        { Dialogos.MostrarMensajeInformacion(Presenter.Title, String.Format("La orden de venta: {0} se encuentra bloqueada, no podra imprimir ningun documento relacionado", Presenter.ItemCtaCteDocMandato.OV_OP)); }
                        Presenter.Actualizar();
                     }
                     break;
               }
            }
         }
         catch (Exception ex)
         { Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al cargar los botones para editar y anular.", ex); }
      }
      private void grdItemsDocMandato_CellFormatting(object sender, CellFormattingEventArgs e)
      {
         try
         {
            if (!(e.CellElement is GridCommandCellElement)) return;
            if (e.Column.Name.Equals("Impresion"))
            {
               var bte = (RadButtonElement)e.CellElement.Children[0];
               if (bte.Image == null)
               {
                  bte.TextImageRelation = TextImageRelation.Overlay;
                  bte.DisplayStyle = DisplayStyle.Image;
                  bte.ImageAlignment = ContentAlignment.MiddleCenter;
                  bte.Image = Resources.printer2;
                  bte.ToolTipText = @"Impresión";
                  bte.AutoSize = true;
               }
            }

         }
         catch (Exception ex) { Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al formatear el icono." + ex.Message); }
      }

      private void txaSeries_SelectedItemSerieChanged(object sender, EventArgs e)
      {
         try
         {
            //if (grdItems.Enabled)
            //{
            txaSeries.SelectedItemSerieChanged -= txaSeries_SelectedItemSerieChanged;
            Deshacer();
            txaSeries.SelectedItemSerieChanged += txaSeries_SelectedItemSerieChanged;
            if (txaSeries.SelectedItem != null)
            {
               if (txaSeries.SelectedItem.SERI_UnidadNegocio.Equals("S"))
               {
                  Presenter.TipoFacturacion = PRO007Presenter.TFacturacion.SLI;
                  switch (Presenter.TipoDocumentoVenta)
                  {
                     case "PreFactura":
                        chkEstado.Visible = true;
                        break;
                     case "Factura":
                        chkEstado.Visible = false;
                        break;
                  }
                  chkEstado.Checked = false;
               }
               else
               {
                  Presenter.TipoFacturacion = PRO007Presenter.TFacturacion.Otros;
                  chkEstado.Visible = false;
                  chkEstado.Checked = false;
               }
            }
            //}
         }
         catch (Exception)
         { Presenter.TipoFacturacion = PRO007Presenter.TFacturacion.Otros; }
      }

      private void cmbDocOrigen_SelectedIndexChanged(object sender, EventArgs e)
      {
         try
         {
            if (cmbDocOrigen.ConstantesSelectedItem != null)
            {
               txaSeries.Enabled = true;
               if (cmbDocOrigen.ConstantesSelectedItem.CONS_CodTipo.Equals("OP"))
               {
                  Entities.Parametros para = Presenter.Client.GetOneParametrosByClave("FAC_TDO_OP");
                  String[] TiposTDO = null;
                  if (para != null) { TiposTDO = para.PARA_Valor.ToString().Split('|'); }
                  txaSeries.LoadControl(Presenter.ContainerService, "Ayuda de Series", TiposTDO, new String[] { "S" });
                  Presenter.TipoFacturacion = PRO007Presenter.TFacturacion.SLI;
                  grdItems.Columns["REGENERAR"].IsVisible = false;
               }
               else if (cmbDocOrigen.ConstantesSelectedItem.CONS_CodTipo.Equals("OV"))
               {
                  Entities.Parametros para = Presenter.Client.GetOneParametrosByClave("FAC_TDO_OV");
                  String[] TiposTDO = null;
                  if (para != null) { TiposTDO = para.PARA_Valor.ToString().Split('|'); }
                  txaSeries.LoadControl(Presenter.ContainerService, "Ayuda de Series", TiposTDO, new String[] { "O", "M", "E" });
                  Presenter.TipoFacturacion = PRO007Presenter.TFacturacion.Otros;
               }
               btnBuscar.Enabled = true;
            }
            else
            {
               txaSeries.Enabled = false;
               btnBuscar.Enabled = false;
            }
         }
         catch (Exception)
         { }
      }

      private void tabBase_SelectionChanged(Crownwood.DotNetMagic.Controls.TabControl sender, Crownwood.DotNetMagic.Controls.TabPage oldPage, Crownwood.DotNetMagic.Controls.TabPage newPage)
      {
         try
         {
            if (tabBase.SelectedTab == tpgDocMandato)
            {
               txaSeries.Enabled = false;
               cmbDOCV_Estado.Enabled = false;
               lblDOCV_Numero.Enabled = false;
               txtDOCV_Numero.Enabled = false;
               Presenter.TipoFacturacion = PRO007Presenter.TFacturacion.Mandato;
               chkFacturaSinSerie.Enabled = false;
               cmbDocOrigen.Enabled = false;
               btnBuscar.Enabled = true;
            }
            else
            {
               txaSeries.Enabled = true;
               cmbDOCV_Estado.Enabled = true;
               lblDOCV_Numero.Enabled = true;
               txtDOCV_Numero.Enabled = true;
               Presenter.TipoFacturacion = PRO007Presenter.TFacturacion.Otros;
               chkFacturaSinSerie.Enabled = true;
               cmbDocOrigen.Enabled = true;
               btnBuscar.Enabled = cmbDocOrigen.SelectedIndex != 0;
            }
         }
         catch (Exception)
         { }
      }

      private void cmbTIPE_Codigo_SelectedIndexChanged(object sender, EventArgs e)
      {
         try
         {
            if (cmbTIPE_Codigo.TipoEntidadSelectedItem != null)
            {
               txaENTC_Codigo.TiposEntidad = Delfin.Controls.EntidadClear.getTipoEntidadEnum(cmbTIPE_Codigo.TipoEntidadSelectedItem.TIPE_Codigo);
               txaENTC_Codigo.Enabled = true;
               txaENTC_Codigo.Clear();
            }
            else
            { txaENTC_Codigo.Enabled = false; txaENTC_Codigo.Clear(); }
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al seleccionar un tipo de entidad.", ex); }
      }

      #endregion

      #region [ IFormClose ]
      private void TitleView_FormClose(object sender, EventArgs e)
      {
         if (CloseForm != null)
         {
            CloseForm(null, new FormCloseEventArgs(TabPageControl, Presenter.CUS));
         }
      }
      public event FormCloseEventArgs.FormCloseEventHandler CloseForm;
      #endregion
   }
}
