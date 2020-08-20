using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.ServiceModel.Channels;
using System.Text;
using System.Windows.Forms;
using System.Collections.ObjectModel;
using Delfin.Principal.Properties;
using Delfin.Controls;
using Infrastructure.Aspect.Collections;
using Telerik.WinControls;
using Telerik.WinControls.UI;

namespace Delfin.Principal
{
   public partial class CAJ002IngresosEgresosLView : UserControl, ICAJ002IngresosEgresosLView
   {
      #region [ Variables ]
      //private String m_sortColumnName;
      //private Boolean m_sortAscending = false;
      #endregion

      #region [ Formulario ]
      public CAJ002IngresosEgresosLView(Telerik.WinControls.UI.RadPageViewPage x_tabPageControl)
      {
         InitializeComponent();
         try
         {
            TabPageControl = x_tabPageControl;

            btnNuevo.Click += new EventHandler(btnNuevo_Click);
            btnBuscar.Click += new EventHandler(btnBuscar_Click);
            btnDeshacer.Click += new EventHandler(btnDeshacer_Click);
            btnExportar.Click += new EventHandler(btnExportar_Click);
            txaCUBA_Codigo.SelectedItemCuentaBancariaChanged += txaCUBA_Codigo_SelectedItemCuentaBancariaChanged;
            cmbTIPE_Codigo.SelectedIndexChanged += cmbTIPE_Codigo_SelectedIndexChanged;

            txtMOVI_Codigo.KeyPress += txtMOVI_Codigo_KeyPress;

            BSItems = new BindingSource();
            BSItems.CurrentItemChanged += new EventHandler(BSItems_CurrentItemChanged);

            grdItems.CommandCellClick += new Telerik.WinControls.UI.CommandCellClickEventHandler(grdItems_CommandCellClick);
            grdItems.CellFormatting += grdItems_CellFormatting;
            cmbTIPO_CodMND.Enabled = false;

            TitleView.FormClose += new EventHandler(TitleView_FormClose);

            this.txtMOVI_Codigo.MaxLength = 10;
            txtAsientoDC.MaxLength = 20;
            txtAsientoDG.MaxLength = 20;

         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error inicializando el formulario LView.", ex); }
      }

      #endregion

      #region [ Propiedades ]

      public Telerik.WinControls.UI.RadPageViewPage TabPageControl { get; set; }
      public Image IconView { get { return TitleView.FormIcon; } set { TitleView.FormIcon = value; } }
      public CAJ002IngresosEgresosPresenter Presenter { get; set; }
      public BindingSource BSItems { get; set; }

      #endregion

      #region [ ICOM007LView ]

      public void LoadView()
      {
         try
         {
            FormatDataGrid();

            txaCUBA_Codigo.LoadControl(Presenter.ContainerService, "Cuentas Bancarias", Delfin.Controls.Entorno.ItemEmpresa.EMPR_Codigo, Presenter.Session.UserName);
            cmbTIPO_CodMND.LoadControl(Presenter.ContainerService, "Moneda", "MND", "< Sel. Moneda>", ListSortDirection.Ascending);
            cmbTIPO_CodMOV.LoadControl(Presenter.ListTiposMOV, "Ayuda Movimiento", "< Sel. Tipo Movimiento >", ListSortDirection.Ascending);
            cmbTIPE_Codigo.LoadControl(Presenter.ContainerService, "Tipo de Entidad", "< Sel. Tipo de Entidad >", ListSortDirection.Ascending);
                        
            dtpMOVI_FecEmision_Fin.NSFecha = DateTime.Now.Date;
            dtpMOVI_FecEmision_Ini.NSFecha = DateTime.Now.AddDays(-7).Date;

            grdItems.Enabled = false;
            btnNuevo.Enabled = true;
            btnBuscar.Enabled = true;
            //btnExportar.Enabled = false;
            switch (Presenter.TMovimiento)
            {
               case Infrastructure.Aspect.Constants.TipoMovimientoCtaCte.Egresos:
                  txaENTC_Codigo.LoadControl(Presenter.ContainerService, TiposEntidad.TIPE_Cliente, null, null, true);
                  lblNumOperacion.Visible = false;
                  txtMOVI_NroOperacion.Visible = false;
                  TitleView.Caption = "EGRESOS";
                  break;
               case Infrastructure.Aspect.Constants.TipoMovimientoCtaCte.Ingresos:
                  txaENTC_Codigo.LoadControl(Presenter.ContainerService, TiposEntidad.TIPE_Cliente, null, null, true);
                  TitleView.Caption = "INGRESOS";
                  break;
            }
            if (!String.IsNullOrEmpty(Presenter.MensajeError)) { btnNuevo.Enabled = false; }
            //SeleccionarItem();
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error cargando la vista.", ex); }
      }

      public void ShowItems()
      {
         try
         {
            BSItems.DataSource = Presenter.Items;
            grdItems.DataSource = BSItems;
            navItems.BindingSource = BSItems;
            BSItems.ResetBindings(true);
            if (grdItems.RowCount > 0)
            {
               grdItems.Enabled = true;
               //btnExportar.Enabled = true;
               Infrastructure.WinForms.Controls.GridAutoFit.Fit(this.grdItems);
               this.grdItems.Columns["MOVI_TipoCambio"].FormatString = "{0:#,##0.0000}";
               this.grdItems.Columns["Documentos"].Width = 200;
               this.grdItems.Columns["OrdenVenta"].Width = 200;
            }
            else
            {
               grdItems.Enabled = false;
               //btnExportar.Enabled = false;
            }

            grdItems.ShowFilteringRow = true;
            grdItems.EnableFiltering = true;
            grdItems.MasterTemplate.EnableFiltering = true;
            grdItems.EnableGrouping = false;
            grdItems.MasterTemplate.EnableGrouping = false;
            grdItems.EnableSorting = true;
            grdItems.MasterTemplate.EnableCustomSorting = true;

            SeleccionarItem();
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error cargando los items.", ex); }
      }

      #endregion

      #region [ Metodos ]

      ToolStripMenuItem tsmTodos;
      String[] defaultColumns;
      private void FormatDataGrid()
      {
         try
         {
            Telerik.WinControls.UI.Localization.RadGridLocalizationProvider.CurrentProvider = new Infrastructure.WinForms.Controls.MySpanishRadGridLocalizationProvider();
            this.grdItems.Columns.Clear();
            this.grdItems.AllowAddNewRow = false;
            Telerik.WinControls.UI.GridViewCommandColumn commandColumn;
            commandColumn = new Telerik.WinControls.UI.GridViewCommandColumn();
            commandColumn.Name = "Edit";
            commandColumn.HeaderText = "Editar";
            commandColumn.DefaultText = "Editar";
            commandColumn.UseDefaultText = true;
            this.grdItems.Columns.Add(commandColumn);
            this.grdItems.Columns["Edit"].AllowSort = false;
            this.grdItems.Columns["Edit"].AllowFiltering = false;

            commandColumn = new Telerik.WinControls.UI.GridViewCommandColumn();
            commandColumn.Name = "Print";
            commandColumn.HeaderText = "Imprimir";
            commandColumn.DefaultText = "Imprimir";
            commandColumn.UseDefaultText = true;
            this.grdItems.Columns.Add(commandColumn);
            this.grdItems.Columns["Print"].AllowSort = false;
            this.grdItems.Columns["Print"].AllowFiltering = false;


            if (Presenter.TMovimiento == Infrastructure.Aspect.Constants.TipoMovimientoCtaCte.Egresos)
            {
               commandColumn = new Telerik.WinControls.UI.GridViewCommandColumn();
               commandColumn.Name = "Cheque";
               commandColumn.HeaderText = "Cheque";
               commandColumn.DefaultText = "Cheque";
               commandColumn.UseDefaultText = true;
               this.grdItems.Columns.Add(commandColumn);
               this.grdItems.Columns["Cheque"].AllowSort = false;
               this.grdItems.Columns["Cheque"].AllowFiltering = false;
            }

            this.grdItems.Columns.Add("MOVI_FecEmision", "Fecha Emisión", "MOVI_FecEmision");
            if (Presenter.TMovimiento == Infrastructure.Aspect.Constants.TipoMovimientoCtaCte.Ingresos)
            { this.grdItems.Columns.Add("MOVI_NroOperacion", "Nro. Operación", "MOVI_NroOperacion"); }
            this.grdItems.Columns.Add("TIPO_MOV", "Tipo Movimiento", "TIPO_MOV");
            this.grdItems.Columns.Add("CUBA_NroCuenta", "Nro. Cta. Bancaria", "CUBA_NroCuenta");
            this.grdItems.Columns.Add("Monto_text", "Monto", "Monto_text");
            this.grdItems.Columns.Add("MOVI_TipoCambio", "Tipo de Cambio", "MOVI_TipoCambio");
            this.grdItems.Columns["MOVI_TipoCambio"].FormatString = "{0:#,##0.0000}";
            this.grdItems.Columns.Add("TipoEntidad", "Tipo Entidad", "TipoEntidad");
            this.grdItems.Columns.Add("ENTC_DocIden", "R.U.C. / D.N.I.", "ENTC_DocIden");
            this.grdItems.Columns.Add("ENTC_RazonSocial", "Cliente / Proveedor", "ENTC_RazonSocial");
            this.grdItems.Columns.Add("MOVI_Concepto", "Concepto", "MOVI_Concepto");
            if (Presenter.TMovimiento == Infrastructure.Aspect.Constants.TipoMovimientoCtaCte.Egresos)
            {
                this.grdItems.Columns.Add("MOVI_NroOperacion", "No.Operación", "MOVI_NroOperacion");
                this.grdItems.Columns.Add("MOVI_Referencia", "Referencia", "MOVI_Referencia");
            }
            this.grdItems.Columns.Add("MOVI_FecDiferido", "Fecha Diferido", "MOVI_FecDiferido");
            this.grdItems.Columns.Add("Documentos", "Documentos", "Documentos");
            this.grdItems.Columns.Add("OrdenVenta", "OV / OP", "OrdenVenta");
            this.grdItems.Columns.Add("NEstado", "Estado", "NEstado");
            this.grdItems.Columns.Add("AsientoContable_DG", "Nro. Asiento D.G.", "AsientoContable_DG");
            this.grdItems.Columns.Add("AsientoContable_DC", "Nro. Asiento D.C.", "AsientoContable_DC");

            this.grdItems.Columns.Add("AsientoContable_DG_02", "Nro. Asiento D.G. Rev.", "AsientoContable_DG_02");

            //if (Presenter.TMovimiento == Infrastructure.Aspect.Constants.TipoMovimientoCtaCte.Egresos)
            //{
            //   /* Desvincular Otros Asiento */
            //   Telerik.WinControls.UI.GridViewCommandColumn commandColumnAO = new Telerik.WinControls.UI.GridViewCommandColumn();
            //   commandColumnAO.Name = "DAsientoContable_DG_02";
            //   commandColumnAO.HeaderText = "D.As.";
            //   commandColumnAO.DefaultText = "D.As.";
            //   commandColumnAO.UseDefaultText = true;
            //   this.grdItems.Columns.Add(commandColumnAO);
            //   this.grdItems.Columns["DAsientoContable_DG_02"].AllowSort = false;
            //   this.grdItems.Columns["DAsientoContable_DG_02"].AllowFiltering = false;

            //   Telerik.WinControls.UI.GridViewCommandColumn commandColumnReg = new Telerik.WinControls.UI.GridViewCommandColumn();
            //   commandColumnReg.Name = "RegAsientoReversion";
            //   commandColumnReg.HeaderText = "R. As. R.";
            //   commandColumnReg.DefaultText = "R. As. R.";
            //   commandColumnReg.UseDefaultText = true;
            //   this.grdItems.Columns.Add(commandColumnReg);
            //   this.grdItems.Columns["RegAsientoReversion"].AllowSort = false;
            //   this.grdItems.Columns["RegAsientoReversion"].AllowFiltering = false;
            //}

            this.grdItems.Columns.Add("AsientoContable_DG_04", "Nro. Asiento D.G. Caja", "AsientoContable_DG_04");
            this.grdItems.Columns.Add("AsientoContable_DC_04", "Nro. Asiento D.C. Caja", "AsientoContable_DC_04");

            this.grdItems.Columns.Add("MOVI_Codigo", "Código", "MOVI_Codigo");
            this.grdItems.Columns.Add("PLAN_Codigo", "Cod. Planilla", "PLAN_Codigo");

            ToolStripSeparator tsmSeparacion = new ToolStripSeparator();
            tsmColumnas.DropDownItems.Add(tsmSeparacion);
            tsmTodos = new ToolStripMenuItem("Todos");
            tsmTodos.Tag = "Todas";
            tsmTodos.Checked = false;
            tsmTodos.CheckOnClick = true;
            tsmTodos.Click += new EventHandler(tsmTodos_Click);
            tsmColumnas.DropDownItems.Add(tsmTodos);

            //Infrastructure.WinForms.Controls.GridAutoFit.Fit(grdItems);

            grdItems.ShowFilteringRow = true;
            grdItems.EnableFiltering = true;
            grdItems.MasterTemplate.EnableFiltering = true;
            grdItems.EnableGrouping = false;
            grdItems.MasterTemplate.EnableGrouping = false;
            grdItems.EnableSorting = true;
            grdItems.MasterTemplate.EnableCustomSorting = true;
            grdItems.AutoGenerateColumns = false;
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, Infrastructure.Aspect.Constants.Mensajes.FormatDataGridView, ex); }
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
         foreach (Telerik.WinControls.UI.GridViewDataColumn column in grdItems.Columns)
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
            if (Presenter != null && BSItems.Current != null)
            {
               Presenter.ItemLView = (BSItems.Current as Entities.Movimiento);
               Presenter.MOVI_Codigo = (BSItems.Current as Entities.Movimiento).MOVI_Codigo;
               Presenter.MOVI_Estado = (BSItems.Current as Entities.Movimiento).CONS_CodEST;
               Presenter.TIPO_CodMOV = (BSItems.Current as Entities.Movimiento).TIPO_CodMOV;
               Presenter.TIPO_TabMOV = (BSItems.Current as Entities.Movimiento).TIPO_TabMOV;

            }
            //else
            //{ Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Presenter.Title, "No ha seleccionado un registro."); }
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al seleccionar el item.", ex); }
      }
      private void Nuevo()
      {
         try
         {
            getFiltros();
            Presenter.Nuevo(txaCUBA_Codigo.SelectedItem);
            //if (txaCUBA_Codigo.SelectedItem != null)
            //{ Presenter.Nuevo(txaCUBA_Codigo.SelectedItem); }
            //else
            //{ Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Presenter.Title, "Para crear un registro debe seleccionar Cuenta Bancaria."); }
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al hacer nuevo.", ex); }
      }
      private void Buscar()
      {
         try
         {
            string value = txtMOVI_Codigo.Text;
            if (txtMOVI_Codigo.Text != "")
            {
               if (decimal.Parse(value) > 2147483647) { txtMOVI_Codigo.Text = "2147483647"; }
            }
            getFiltros();
            if (dtpMOVI_FecEmision_Ini.NSFecha.HasValue && dtpMOVI_FecEmision_Ini.NSFecha.HasValue)
            {
               if (dtpMOVI_FecEmision_Fin.NSFecha.Value.Date < dtpMOVI_FecEmision_Ini.NSFecha.Value.Date)
               {
                  Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Presenter.Title, "La Fecha de Inicio es Mayor a la Fecha de Fin, la consulta no devolvera resultados.");
                  return;
               }
            }
            //if (txaCUBA_Codigo.SelectedItem != null)
            //{
               Presenter.Actualizar();
            //}
            //else
            //{
            //   Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Presenter.Title, "Para realizar una busqueda debe seleccionar Cuenta Bancaria.");
            //}
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al buscar.", ex); }
      }
      private void Exportar()
      {
         try
         {
            List<String> Titulos = new List<String>();
            Titulos.Add("Reporte");
            Int32 _fila = 2;
            Infrastructure.WinForms.Controls.ExcelAportes _xls = new Infrastructure.WinForms.Controls.ExcelAportes(1, Titulos, "");
            Object[] _cabeceras = new Object[1];
            DataTable _dt = _xls.RadGridViewToDataTable(grdItems, ref _cabeceras, grdItems.FilterDescriptors.Count > 0);
            /*****************************************/
            if (_dt.Columns["Print"] != null)
            { _dt.Columns.Remove("Print"); }
            _cabeceras = new Object[_dt.Columns.Count];
            for (int i = 0; i < _dt.Columns.Count; i++)
            {
               _cabeceras[i] = _dt.Columns[i].Caption;
            }
            /*******************************************/
            if (_dt.Rows.Count > 0)
            {
               DateTime thisDay = DateTime.Today;
               List<String> _listTituloFiltro = new List<String>();
               _listTituloFiltro.Add("GENERADO : " + thisDay.ToString("D"));
               _xls.InsertarTitulos(Presenter.Title, 1, ref _fila, 1, _listTituloFiltro, _cabeceras.Length);
               _xls.addDataArray(1, _cabeceras, 1, _fila + 2, true, true);
               _xls.addDataList(1, _dt, 1, _fila + 3, true, true);
            }
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al exportar.", ex); }
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
            //btnExportar.Enabled = false;

            txtMOVI_Codigo.Text = String.Empty;
            txaCUBA_Codigo.ClearValue();
            cmbTIPO_CodMND.SelectedIndex = 0;
            txtMOVI_NroOperacion.Text = String.Empty;
            txaENTC_Codigo.Clear();
            cmbTIPO_CodMOV.SelectedIndex = 0;
            dtpMOVI_FecEmision_Ini.NSFecha = null;
            dtpMOVI_FecEmision_Fin.NSFecha = null;
            cmbTIPE_Codigo.SelectedIndex = 0;
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al deshacer la vista.", ex); }
      }
      private void getFiltros()
      {
         try
         {
            Int32 x_movi_codigo = 0;
            if (!String.IsNullOrEmpty(txtMOVI_Codigo.Text) && Int32.TryParse(txtMOVI_Codigo.Text, out x_movi_codigo))
            {
               Presenter.F_MOVI_Codigo = x_movi_codigo;

               Presenter.F_CUBA_Codigo = null;
               Presenter.F_TIPO_CodMOV = null;
               Presenter.F_MOVI_NroOperacion = null;
               Presenter.F_ENTC_Codigo = null;
               Presenter.F_FecIni = null;
               Presenter.F_FecFin = null;
               Presenter.F_TIPE_Codigo = null;
               Presenter.F_AsientoDG = null;
               Presenter.F_AsientoDC = null;
            }
            else
            {
               Presenter.F_CUBA_Codigo = null; if (txaCUBA_Codigo.SelectedItem != null) { Presenter.F_CUBA_Codigo = txaCUBA_Codigo.SelectedItem.CUBA_Codigo; }
               Presenter.F_MOVI_Codigo = null; if (!String.IsNullOrEmpty(txtMOVI_Codigo.Text)) { Presenter.F_MOVI_Codigo = Int32.Parse(txtMOVI_Codigo.Text); }
               Presenter.F_TIPO_CodMOV = null; if (cmbTIPO_CodMOV.TiposSelectedItem != null) { Presenter.F_TIPO_CodMOV = cmbTIPO_CodMOV.TiposSelectedItem.TIPO_CodTipo; }
               Presenter.F_MOVI_NroOperacion = null; if (!String.IsNullOrEmpty(txtMOVI_NroOperacion.Text.Trim())) { Presenter.F_MOVI_NroOperacion = (txtMOVI_NroOperacion.Text.Trim()); }
               Presenter.F_ENTC_Codigo = null; if (txaENTC_Codigo.SelectedItem != null) { Presenter.F_ENTC_Codigo = txaENTC_Codigo.SelectedItem.ENTC_Codigo; }
               Presenter.F_FecIni = null; if (dtpMOVI_FecEmision_Ini.NSFecha.HasValue) { Presenter.F_FecIni = dtpMOVI_FecEmision_Ini.NSFecha; }
               Presenter.F_FecFin = null; if (dtpMOVI_FecEmision_Fin.NSFecha.HasValue) { Presenter.F_FecFin = dtpMOVI_FecEmision_Fin.NSFecha; }
               Presenter.F_TIPE_Codigo = null; if (cmbTIPE_Codigo.TipoEntidadSelectedItem != null) { Presenter.F_TIPE_Codigo = cmbTIPE_Codigo.TipoEntidadSelectedItem.TIPE_Codigo; }
               Presenter.F_AsientoDG = null; if (!String.IsNullOrEmpty(txtAsientoDG.Text)) { Presenter.F_AsientoDG = txtAsientoDG.Text; }
               Presenter.F_AsientoDC = null; if (!String.IsNullOrEmpty(txtAsientoDC.Text)) { Presenter.F_AsientoDC = txtAsientoDC.Text; }
            }
         }
         catch (Exception)
         { }
      }
      private void Imprimir(Boolean x_esCheque = false)
      {
         try
         {
            if (x_esCheque)
            {
               if (Presenter.ItemLView.TIPO_CodMOV.Equals(Presenter.ItemLView.GetTipoMovimiento(Entities.Movimiento.TipoMovimiento.EgresosCheque)))
               {
                  System.Drawing.Printing.PrintDocument Document = new System.Drawing.Printing.PrintDocument();
                  Document.PrintPage += Document_PrintPage;
                  Document.Print();
               }
               else
               { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Presenter.Title, "Solo se puede imprimir los Movimientos tipo Egresos-Cheque"); }
            }
            else
            {
               if (Presenter.ItemLView.CONS_CodEST.Equals(Entities.Movimiento.GetEstado(Entities.Movimiento.Estado.Ingresado)))
               {
                  switch (Presenter.TMovimiento)
                  {
                     case Infrastructure.Aspect.Constants.TipoMovimientoCtaCte.Ingresos:
                        SeleccionarItem();
                        Presenter.ImprimirRecIngresos();
                        break;
                     case Infrastructure.Aspect.Constants.TipoMovimientoCtaCte.Egresos:
                        SeleccionarItem();
                        Presenter.ImprimirRecIngresos();
                        break;
                     //if (Presenter.Item.TIPO_CodMOV.Equals(Presenter.Item.GetTipoMovimiento(Entities.Movimiento.TipoMovimiento.EgresosCheque)))
                     //{
                     //   System.Drawing.Printing.PrintDocument Document = new System.Drawing.Printing.PrintDocument();
                     //   Document.PrintPage += Document_PrintPage;
                     //   Document.Print();
                     //}
                     //else
                     //{ Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Presenter.Title, "Solo se puede imprimir los Movimientos tipo Egresos-Cheque"); }
                     //break;
                     default:
                        break;
                  }
               }
               else
               {
                  Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Presenter.Title, "No puede imprimir un documento Anulado/Extornado."); 
               }
            }
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al realizar la impresión del Cheque.", ex); }
      }

      private void DesvincularAsiento()
      { }

      private void RegenerarReversion()
      { }

      private void Document_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
      {
         try
         {
            Presenter.Imprimir(e);
         }
         catch (Exception)
         { throw; }
      }
      #endregion

      #region [ Eventos ]
      private void btnNuevo_Click(object sender, EventArgs e)
      { Nuevo(); }
      private void btnBuscar_Click(object sender, EventArgs e)
      { Buscar(); }
      private void btnDeshacer_Click(object sender, EventArgs e)
      { Deshacer(); }
      private void btnExportar_Click(object sender, EventArgs e)
      { Exportar(); }
      private void BSItems_CurrentItemChanged(object sender, EventArgs e)
      { SeleccionarItem(); }

      private void grdItems_CommandCellClick(object sender, EventArgs e)
      {
         try
         {
            if (sender is Telerik.WinControls.UI.GridCommandCellElement)
            {
               switch ((((Telerik.WinControls.UI.GridCommandCellElement)(sender)).CommandButton).TextElement.Text)
               {
                  case "Editar":
                     SeleccionarItem();
                     Presenter.Editar();
                     break;
                  case "Eliminar":
                     SeleccionarItem();
                     Presenter.Eliminar();
                     break;
                  case "Anular":
                     SeleccionarItem();
                     Presenter.Anular();
                     break;
                  case "Imprimir":
                     SeleccionarItem();
                     Imprimir();
                     break;
                  case "Cheque":
                     SeleccionarItem();
                     Imprimir(true);
                     break;
                  case "DAsientoContable_DG_02":
                     SeleccionarItem();
                     DesvincularAsiento();
                     break;
                  case "RegAsientoReversion":
                     SeleccionarItem();
                     RegenerarReversion();
                     break;
               }
            }
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al cargar los botones para editar y eliminar.", ex); }
      }


      private void grdItems_CellFormatting(object sender, Telerik.WinControls.UI.CellFormattingEventArgs e)
      {
         try
         {
            if (e.CellElement is GridCommandCellElement)
            {
               if (e.Column.Name.Equals("Edit"))
               {
                  RadButtonElement bte = (RadButtonElement)e.CellElement.Children[0];
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
               if (e.Column.Name.Equals("Nullable"))
               {
                  RadButtonElement bte = (RadButtonElement)e.CellElement.Children[0];
                  if (bte.Image == null)
                  {
                     bte.TextImageRelation = TextImageRelation.Overlay;
                     bte.DisplayStyle = DisplayStyle.Image;
                     bte.ImageAlignment = ContentAlignment.MiddleCenter;
                     bte.Image = Resources.forbidden_16x16;
                     bte.ToolTipText = @"Anular Registro";
                     bte.AutoSize = true;
                  }
               }
               if (e.Column.Name.Equals("Delete"))
               {
                  RadButtonElement bte = (RadButtonElement)e.CellElement.Children[0];
                  if (bte.Image == null)
                  {
                     bte.TextImageRelation = TextImageRelation.Overlay;
                     bte.DisplayStyle = DisplayStyle.Image;
                     bte.ImageAlignment = ContentAlignment.MiddleCenter;
                     bte.Image = Resources.Sign_07;
                     bte.ToolTipText = @"Eliminar Registro";
                     bte.AutoSize = true;
                  }
               }
               if (e.Column.Name.Equals("Print"))
               {
                  RadButtonElement bte = (RadButtonElement)e.CellElement.Children[0];
                  if (bte.Image == null)
                  {
                     bte.TextImageRelation = TextImageRelation.Overlay;
                     bte.DisplayStyle = DisplayStyle.Image;
                     bte.ImageAlignment = ContentAlignment.MiddleCenter;
                     bte.Image = Resources.printer2_16x16;
                     bte.ToolTipText = @"Imprimir Recibo";
                     bte.AutoSize = true;
                  }
               }
               if (e.Column.Name.Equals("Cheque"))
               {
                  RadButtonElement bte = (RadButtonElement)e.CellElement.Children[0];
                  if (bte.Image == null)
                  {
                     bte.TextImageRelation = TextImageRelation.Overlay;
                     bte.DisplayStyle = DisplayStyle.Image;
                     bte.ImageAlignment = ContentAlignment.MiddleCenter;
                     bte.Image = Resources.printer2_16x16;
                     bte.ToolTipText = @"Imprimir Cheque";
                     bte.AutoSize = true;
                  }
               }
               if (e.Column.Name.Equals("D.As."))
               {
                  RadButtonElement bte = (RadButtonElement)e.CellElement.Children[0];
                  if (bte.Image == null)
                  {
                     bte.TextImageRelation = TextImageRelation.Overlay;
                     bte.DisplayStyle = DisplayStyle.Image;
                     bte.ImageAlignment = ContentAlignment.MiddleCenter;
                     bte.Image = Resources.delete_16x16;
                     bte.ToolTipText = @"Desvincular Asiento de Reversion";
                     bte.AutoSize = true;
                  }
               }
               if (e.Column.Name.Equals("R. As. R."))
               {
                  RadButtonElement bte = (RadButtonElement)e.CellElement.Children[0];
                  if (bte.Image == null)
                  {
                     bte.TextImageRelation = TextImageRelation.Overlay;
                     bte.DisplayStyle = DisplayStyle.Image;
                     bte.ImageAlignment = ContentAlignment.MiddleCenter;
                     bte.Image = Resources.refresh;
                     bte.ToolTipText = @"Regenerar Asiento de Reversión";
                     bte.AutoSize = true;
                  }
               }
               if (e.CellElement.RowInfo is GridViewNewRowInfo && e.CellElement.ColumnInfo is GridViewCommandColumn)
               {
                  ((RadButtonElement)e.CellElement.Children[0]).Visibility = ElementVisibility.Hidden;
               }
            }
         }
         catch (Exception ex) { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al formatear el icono." + ex.Message); }

      }

      private void txtMOVI_Codigo_KeyPress(object sender, KeyPressEventArgs e)
      {
         Infrastructure.Aspect.Constants.Util.ValidaCodigo_KeyPress(ref e);
      }

      private void txaCUBA_Codigo_SelectedItemCuentaBancariaChanged(object sender, EventArgs e)
      {
         try
         {
            if (txaCUBA_Codigo.SelectedItem != null)
            {
               cmbTIPO_CodMND.TiposSelectedValue = txaCUBA_Codigo.SelectedItem.TIPO_CodMND;
            }
            else { cmbTIPO_CodMND.SelectedIndex = 0; }
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
               txaENTC_Codigo.Enabled = true;
               txaENTC_Codigo.TiposEntidad = Delfin.Controls.EntidadClear.getTipoEntidadEnum(cmbTIPE_Codigo.TipoEntidadSelectedItem.TIPE_Codigo);
               txaENTC_Codigo.Clear();
            }
            else { txaENTC_Codigo.Enabled = false; txaENTC_Codigo.Clear(); }
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al cambiar el tipo de entidad.", ex); }
      }

      #endregion

      #region [ IFormClose ]
      private void TitleView_FormClose(object sender, EventArgs e)
      {
         try
         {
            if (CloseForm != null)
            {
               if (Presenter.CloseView())
               {
                  CloseForm(null,
                     new Infrastructure.Client.FormClose.FormCloseEventArgs(this.TabPageControl, Presenter.CUS));
               }
            }
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al cerrar el modulo.", ex); }
      }
      public event Infrastructure.Client.FormClose.FormCloseEventArgs.FormCloseEventHandler CloseForm;
      #endregion
   }
}
