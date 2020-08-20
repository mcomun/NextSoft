using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
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
   public partial class CAJ012IngresoLibreLView : UserControl, ICAJ012IngresoLibreLView
   {
      #region [ Variables ]
      //private String m_sortColumnName;
      //private Boolean m_sortAscending = false;
      #endregion

      #region [ Formulario ]
      
      public CAJ012IngresoLibreLView(Telerik.WinControls.UI.RadPageViewPage x_tabPageControl)
      {
         InitializeComponent();
         try
         {
            TabPageControl = x_tabPageControl;

            btnNuevo.Click += new EventHandler(btnNuevo_Click);
            btnBuscar.Click += new EventHandler(btnBuscar_Click);

            btnExportar.Click += new EventHandler(btnExportar_Click);
            btnDeshacer.Click += new EventHandler(btnDeshacer_Click);

            txtCCCT_Codigo.KeyPress += txtCCCT_Codigo_KeyPress;

            BSItems = new BindingSource();
            BSItems.CurrentItemChanged += new EventHandler(BSItems_CurrentItemChanged);

            grdItems.CommandCellClick += new Telerik.WinControls.UI.CommandCellClickEventHandler(grdItems_CommandCellClick);
            grdItems.CellFormatting += grdItems_CellFormatting;

            cmbTIPE_Codigo.SelectedIndexChanged += cmbTIPE_Codigo_SelectedIndexChanged;
            TitleView.FormClose += new EventHandler(TitleView_FormClose);

            txtAsientoInicial.MaxLength = 20;
            txtAsientoCompras.MaxLength = 20;
            txtNumDoc.MaxLength = 20;
            txtHBL.MaxLength = 50;
            txtMBL.MaxLength = 50;
            txtCCCT_Serie.MaxLength = 20;
            txtCCCT_Numero.MaxLength = 20;
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error inicializando el formulario LView.", ex); }
      }

      #endregion

      #region [ Propiedades ]
      public Telerik.WinControls.UI.RadPageViewPage TabPageControl { get; set; }
      public Image IconView { get { return TitleView.FormIcon; } set { TitleView.FormIcon = value; } }
      public CAJ012IngresoLibrePresenter Presenter { get; set; }
      public BindingSource BSItems { get; set; }
      #endregion

      #region [ ICAJ012IngresoLibreLView ]
      public void LoadView()
      {
         try
         {
            cmbTIPE_Codigo.LoadControl(Presenter.ContainerService, "Tipo de Entidad", "< Sel. Tipo de Entidad >", ListSortDirection.Ascending);
            txaENTC_Codigo.LoadControl(Presenter.ContainerService, TiposEntidad.TIPE_Cliente);
            cmbTIPO_CodTDO.LoadControl(Presenter.ContainerService, "Tipo Documento", "TDO", "< Sel. Tipo Documento >", ListSortDirection.Ascending);

            txaNVIA_Codigo.LoadControl(Presenter.ContainerService);

            FormatDataGrid();

            grdItems.Enabled = false;
            btnNuevo.Enabled = true;
            btnBuscar.Enabled = true;
            btnExportar.Enabled = false;

            dtpCCCT_Fecha_Fin.NSFecha = Presenter.Client.GetFecha();
            dtpCCCT_Fecha_Ini.NSFecha = dtpCCCT_Fecha_Fin.NSFecha.Value.AddDays(-7).Date; //new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);

            SeleccionarItem();
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
               btnExportar.Enabled = true;
               Infrastructure.WinForms.Controls.GridAutoFit.Fit(this.grdItems);
               grdItems.Columns["CCCT_TipoCambio"].FormatString = "{0:0.0000}";
            }
            else
            {
               grdItems.Enabled = false;
               btnExportar.Enabled = false;
            }

            //grdItems.ShowFilteringRow = false;
            //grdItems.EnableFiltering = false;
            //grdItems.MasterTemplate.EnableFiltering = false;
            //grdItems.EnableGrouping = false;
            //grdItems.MasterTemplate.EnableGrouping = false;
            //grdItems.EnableSorting = false;
            //grdItems.MasterTemplate.EnableCustomSorting = false;

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
            Telerik.WinControls.UI.GridViewCommandColumn commandColumnDel = new Telerik.WinControls.UI.GridViewCommandColumn();
            commandColumnDel.Name = "Delete";
            commandColumnDel.HeaderText = "Eliminar";
            commandColumnDel.DefaultText = "Eliminar";
            commandColumnDel.UseDefaultText = true;
            this.grdItems.Columns.Add(commandColumnDel);
            this.grdItems.Columns["Delete"].AllowSort = false;
            this.grdItems.Columns["Delete"].AllowFiltering = false;

            this.grdItems.Columns.Add("CCCT_Codigo", "Código", "CCCT_Codigo");
            this.grdItems.Columns.Add("TIPE_Descripcion", "Tipo Entidad", "TIPE_Descripcion");
            this.grdItems.Columns.Add("ENTC_DocIden", "R.U.C. / D.N.I.", "ENTC_DocIden");
            this.grdItems.Columns.Add("ENTC_RazonSocial", "Entidad", "ENTC_RazonSocial");
            this.grdItems.Columns.Add("TIPO_MND", "Moneda", "TIPO_MND");
            //this.grdItems.Columns.Add("TIPO_FPG", "Forma Pago", "TIPO_FPG");
            this.grdItems.Columns.Add("TIPO_TDO", "Tipo Documento", "TIPO_TDO");
            this.grdItems.Columns.Add("CCCT_Serie", "Serie", "CCCT_Serie");
            this.grdItems.Columns.Add("CCCT_Numero", "Numero", "CCCT_Numero");
            this.grdItems.Columns.Add("CCCT_FechaEmision", "Fecha Emisión", "CCCT_FechaEmision");
            this.grdItems.Columns.Add("CCCT_ValVta", "Valor Venta", "CCCT_ValVta");
            this.grdItems.Columns.Add("CCCT_Monto", "Monto", "CCCT_Monto");
            this.grdItems.Columns.Add("CCCT_TipoCambio", "Tipo Cambio", "CCCT_TipoCambio");
            this.grdItems.Columns.Add("TipoCtaCte", "Tipo", "TipoCtaCte");
            this.grdItems.Columns.Add("DocVenta", "Doc. Venta", "DocVenta");
            this.grdItems.Columns.Add("OV_OP", "OV / OP", "OV_OP");
            this.grdItems.Columns.Add("MBL_HBL", "MBL / HBL", "MBL_HBL");
            this.grdItems.Columns.Add("Viaje", "Viaje", "Viaje");
            this.grdItems.Columns.Add("NVIA_FecPreFactura", "Fec. Prefactura", "NVIA_FecPreFactura");
            this.grdItems.Columns.Add("NVIA_FecETA_IMPO_ETD_EXPO", "Fecha ETA/ETD", "NVIA_FecETA_IMPO_ETD_EXPO");
            this.grdItems.Columns.Add("CCCT_Glosa", "Glosa", "CCCT_Glosa");
            this.grdItems.Columns.Add("ConDetraccion_text", "Detraccion", "ConDetraccion_text");

            Telerik.WinControls.UI.GridViewCommandColumn commandColumnSend = new Telerik.WinControls.UI.GridViewCommandColumn();
            commandColumnSend.Name = "SendAsiento";
            commandColumnSend.HeaderText = "As. al Diario";
            commandColumnSend.DefaultText = "As. al Diario";
            commandColumnSend.UseDefaultText = true;
            this.grdItems.Columns.Add(commandColumnSend);
            this.grdItems.Columns["SendAsiento"].AllowSort = false;
            this.grdItems.Columns["SendAsiento"].AllowFiltering = false;

            this.grdItems.Columns.Add("AsientoContable", "Nro. Asiento", "AsientoContable");
            /* Desvincular Asiento Inicial*/
            Telerik.WinControls.UI.GridViewCommandColumn commandColumnAP = new Telerik.WinControls.UI.GridViewCommandColumn();
            commandColumnAP.Name = "DAsientoContable";
            commandColumnAP.HeaderText = "D.As.";
            commandColumnAP.DefaultText = "D.As.";
            commandColumnAP.UseDefaultText = true;
            this.grdItems.Columns.Add(commandColumnAP);
            this.grdItems.Columns["DAsientoContable"].AllowSort = false;
            this.grdItems.Columns["DAsientoContable"].AllowFiltering = false;

            this.grdItems.Columns.Add("AsientoContableC", "Nro. Asiento Compras", "AsientoContableC");
            /* Descvincular Asiento Compras/Reversion*/
            Telerik.WinControls.UI.GridViewCommandColumn commandColumnAC = new Telerik.WinControls.UI.GridViewCommandColumn();
            commandColumnAC.Name = "DAsientoContableC";
            commandColumnAC.HeaderText = "D.As.C/R";
            commandColumnAC.DefaultText = "D.As.C/R";
            commandColumnAC.UseDefaultText = true;
            this.grdItems.Columns.Add(commandColumnAC);
            this.grdItems.Columns["DAsientoContableC"].AllowSort = false;
            this.grdItems.Columns["DAsientoContableC"].AllowFiltering = false;

            this.grdItems.Columns.Add("AsientoContableO", "Asientos Adicionales", "AsientoContableO");
            /* Desvincular Otros Asiento */
            Telerik.WinControls.UI.GridViewCommandColumn commandColumnAO = new Telerik.WinControls.UI.GridViewCommandColumn();
            commandColumnAO.Name = "DAsientoContableO";
            commandColumnAO.HeaderText = "D.O.As.";
            commandColumnAO.DefaultText = "D.O.As.";
            commandColumnAO.UseDefaultText = true;
            this.grdItems.Columns.Add(commandColumnAO);
            this.grdItems.Columns["DAsientoContableO"].AllowSort = false;
            this.grdItems.Columns["DAsientoContableO"].AllowFiltering = false;

            Telerik.WinControls.UI.GridViewCommandColumn commandColumnReg = new Telerik.WinControls.UI.GridViewCommandColumn();
            commandColumnReg.Name = "RegAsientoCompras";
            commandColumnReg.HeaderText = "R. As. R/C";
            commandColumnReg.DefaultText = "R. As. R/C";
            commandColumnReg.UseDefaultText = true;
            this.grdItems.Columns.Add(commandColumnReg);
            this.grdItems.Columns["RegAsientoCompras"].AllowSort = false;
            this.grdItems.Columns["RegAsientoCompras"].AllowFiltering = false;

            this.grdItems.Columns.Add("ESTADO", "Estado", "ESTADO");

            Infrastructure.WinForms.Controls.GridAutoFit.Fit(grdItems);
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
            if (Presenter != null)
            {
               if (BSItems != null && BSItems != null && BSItems.DataSource != null && BSItems.Current != null && BSItems.Current is Entities.CtaCte)
               {
                  Presenter.ItemLView = ((Entities.CtaCte)BSItems.Current);
               }
               else
               {
                  Presenter.ItemLView = null;
               }
            }
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al seleccionar el item.", ex); }
      }

      private void Nuevo()
      {
         try
         {
            //Presenter.FILTROItemCONSRGM = CONS_CodRGM.ConstantesSelectedItem;
            //Presenter.FILTROItemCONSFLE = CONS_CodFLE.ConstantesSelectedItem;

            Presenter.Nuevo();
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al hacer nuevo.", ex); }
      }
      private void Buscar()
      {
         try
         {
            GetFiltro();
            if ((dtpCCCT_Fecha_Ini.NSFecha.HasValue && dtpCCCT_Fecha_Fin.NSFecha.HasValue) || !String.IsNullOrEmpty(txtCCCT_Codigo.Text))
            {
               EliminarFiltros();
               Presenter.Actualizar();
            }
            else { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Presenter.Title, "Para realizar la consulta debe ingresar los rangos de fecha."); }
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al buscar.", ex); }
      }

      private void GetFiltro()
      {
         try
         {
            Presenter.F_CCCT_Numero = null;
            if (!String.IsNullOrEmpty(txtCCCT_Codigo.Text))
            {
               Presenter.F_CCCT_Codigo = Int32.Parse(txtCCCT_Codigo.Text);

               Presenter.F_TIPE_Codigo = null;
               Presenter.F_ENTC_Codigo = null;
               Presenter.F_TIPO_CodTDO = null;
               Presenter.F_CCCT_Serie = null;
               Presenter.F_CCCT_Numero = null;
               Presenter.F_CCCT_Fecha_Ini = null;
               Presenter.F_CCCT_Fecha_Fin = null;
               Presenter.F_MBL = null;
               Presenter.F_HBL = null;
               Presenter.F_OV = null;
               Presenter.F_NVIA_Codigo = null;
               Presenter.F_AsientoCompras = null;
               Presenter.F_AsientoInicial = null;
               return;
            }
            else
            {
               Presenter.F_CCCT_Codigo = null;
            }
            Presenter.F_TIPE_Codigo = null; if (cmbTIPE_Codigo.TipoEntidadSelectedItem != null) { Presenter.F_TIPE_Codigo = cmbTIPE_Codigo.TipoEntidadSelectedItem.TIPE_Codigo; }
            Presenter.F_ENTC_Codigo = null; if (txaENTC_Codigo.SelectedItem != null) { Presenter.F_ENTC_Codigo = txaENTC_Codigo.SelectedItem.ENTC_Codigo; }
            Presenter.F_TIPO_CodTDO = null; if (cmbTIPO_CodTDO.TiposSelectedItem != null) { Presenter.F_TIPO_CodTDO = cmbTIPO_CodTDO.TiposSelectedItem.TIPO_CodTipo; }
            Presenter.F_CCCT_Serie = null; if (!String.IsNullOrEmpty(txtCCCT_Serie.Text)) { Presenter.F_CCCT_Serie = txtCCCT_Serie.Text; }
            Presenter.F_CCCT_Numero = null; if (!String.IsNullOrEmpty(txtCCCT_Numero.Text)) { Presenter.F_CCCT_Numero = txtCCCT_Numero.Text; }
            Presenter.F_CCCT_Fecha_Ini = null; if (dtpCCCT_Fecha_Ini.NSFecha.HasValue) { Presenter.F_CCCT_Fecha_Ini = dtpCCCT_Fecha_Ini.NSFecha; }
            Presenter.F_CCCT_Fecha_Fin = null; if (dtpCCCT_Fecha_Fin.NSFecha.HasValue) { Presenter.F_CCCT_Fecha_Fin = dtpCCCT_Fecha_Fin.NSFecha; }
            Presenter.F_HBL = null; if (!String.IsNullOrEmpty(txtHBL.Text)) { Presenter.F_HBL = txtHBL.Text; }
            Presenter.F_MBL = null; if (!String.IsNullOrEmpty(txtMBL.Text)) { Presenter.F_MBL = txtMBL.Text; }
            Presenter.F_OV = null; if (!String.IsNullOrEmpty(txtNumDoc.Text)) { Presenter.F_OV = txtNumDoc.Text; }
            Presenter.F_NVIA_Codigo = null; if (txaNVIA_Codigo.Value != null) { Presenter.F_NVIA_Codigo = ((Entities.NaveViaje)txaNVIA_Codigo.Value).NVIA_Codigo; }
            Presenter.F_AsientoCompras = null; if (!String.IsNullOrEmpty(txtAsientoCompras.Text)) { Presenter.F_AsientoCompras = txtAsientoCompras.Text; }
            Presenter.F_AsientoInicial = null; if (!String.IsNullOrEmpty(txtAsientoInicial.Text)) { Presenter.F_AsientoInicial = txtAsientoInicial.Text; }
         }
         catch (Exception ex)
         { throw ex; }
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
            btnExportar.Enabled = false;
            txtCCCT_Codigo.Clear();
            cmbTIPE_Codigo.SelectedIndex = 0;
            cmbTIPO_CodTDO.SelectedIndex = 0;
            txaENTC_Codigo.Clear();
            txtCCCT_Serie.Clear();
            txtCCCT_Numero.Clear();
            dtpCCCT_Fecha_Ini.NSFecha = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            dtpCCCT_Fecha_Fin.NSFecha = Presenter.Client.GetFecha();
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al deshacer la vista.", ex); }
      }

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

      #endregion

      #region [ Eventos ]
      private void btnNuevo_Click(object sender, EventArgs e)
      { Nuevo(); }
      private void btnBuscar_Click(object sender, EventArgs e)
      { Buscar(); }
      private void btnExportar_Click(object sender, EventArgs e)
      { Exportar(); }
      private void btnDeshacer_Click(object sender, EventArgs e)
      { Deshacer(); }

      private void BSItems_CurrentItemChanged(object sender, EventArgs e)
      { SeleccionarItem(); }

      #region [ Eventos de Grilla ]
      
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
                  case "D.As.":
                     SeleccionarItem();
                     if (Presenter.DesvincularAsiento(Entities.CtaCte.TipoDesvinculacion.AsientoProvision))
                     {
                        Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeSatisfactorio(Presenter.Title, "Se realizo la operación satisfactoriamente");
                        Presenter.Actualizar();
                     }
                     break;
                  case "D.As.C/R":
                     SeleccionarItem();
                     if(Presenter.DesvincularAsiento(Entities.CtaCte.TipoDesvinculacion.AsientoCompRev))
                     {  
                        Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeSatisfactorio(Presenter.Title, "Se realizo la operación satisfactoriamente");
                        Presenter.Actualizar();
                     }
                     break;
                  case "D.O.As.":
                     SeleccionarItem();
                     if(Presenter.DesvincularAsiento(Entities.CtaCte.TipoDesvinculacion.AsientoORevComp))
                     {  
                        Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeSatisfactorio(Presenter.Title, "Se realizo la operación satisfactoriamente");
                        Presenter.Actualizar();
                     }
                     break;
                  case "As. al Diario":
                     SeleccionarItem();
                     if (Presenter.EnviarADiario())
                     {
                        Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeSatisfactorio(Presenter.Title, "Se realizo la operación satisfactoriamente");
                        Presenter.Actualizar();
                     }
                     break;
                  case "R. As. R/C":
                     SeleccionarItem();
                     if (Presenter.RegenerarAsientoReversion())
                     {
                        Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeSatisfactorio(Presenter.Title, "Se realizo la operación satisfactoriamente");
                        Presenter.Actualizar();
                     }
                     break;
               }
            }
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al cargar los botones para editar y eliminar.", ex); }

      }

      private void grdItems_CellFormatting(object sender, CellFormattingEventArgs e)
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
               else if (e.Column.Name.Equals("Delete"))
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
               else if (e.Column.Name.Equals("NUllable"))
               {
                  RadButtonElement bte = (RadButtonElement)e.CellElement.Children[0];
                  if (bte.Image == null)
                  {
                     bte.TextImageRelation = TextImageRelation.Overlay;
                     bte.DisplayStyle = DisplayStyle.Image;
                     bte.ImageAlignment = ContentAlignment.MiddleCenter;
                     bte.Image = Resources.Cancel_24x24;
                     bte.ToolTipText = @"Anular Registro";
                     bte.AutoSize = true;
                  }
               }
               else if (e.Column.Name.Equals("DAsientoContable"))
               {
                  RadButtonElement bte = (RadButtonElement)e.CellElement.Children[0];
                  if (bte.Image == null)
                  {
                     bte.TextImageRelation = TextImageRelation.Overlay;
                     bte.DisplayStyle = DisplayStyle.Image;
                     bte.ImageAlignment = ContentAlignment.MiddleCenter;
                     bte.Image = Resources.delete_16x16;
                     bte.ToolTipText = @"Desvincular Asiento Contable";
                     bte.AutoSize = true;
                  }
               }
               else if (e.Column.Name.Equals("DAsientoContableC"))
               {
                  RadButtonElement bte = (RadButtonElement)e.CellElement.Children[0];
                  if (bte.Image == null)
                  {
                     bte.TextImageRelation = TextImageRelation.Overlay;
                     bte.DisplayStyle = DisplayStyle.Image;
                     bte.ImageAlignment = ContentAlignment.MiddleCenter;
                     bte.Image = Resources.delete_16x16;
                     bte.ToolTipText = @"Desvincular Asiento Compras/Reversion";
                     bte.AutoSize = true;
                  }
               }
               else if (e.Column.Name.Equals("DAsientoContableO"))
               {
                  RadButtonElement bte = (RadButtonElement)e.CellElement.Children[0];
                  if (bte.Image == null)
                  {
                     bte.TextImageRelation = TextImageRelation.Overlay;
                     bte.DisplayStyle = DisplayStyle.Image;
                     bte.ImageAlignment = ContentAlignment.MiddleCenter;
                     bte.Image = Resources.delete_16x16;
                     bte.ToolTipText = @"Desvincular Asiento Reversion de Compras";
                     bte.AutoSize = true;
                  }
               }
               else if (e.Column.Name.Equals("SendAsiento"))
               {
                  RadButtonElement bte = (RadButtonElement)e.CellElement.Children[0];
                  if (bte.Image == null)
                  {
                     bte.TextImageRelation = TextImageRelation.Overlay;
                     bte.DisplayStyle = DisplayStyle.Image;
                     bte.ImageAlignment = ContentAlignment.MiddleCenter;
                     bte.Image = Resources.arrow_right_green_16x16;
                     bte.ToolTipText = @"Enviar Asiento a libro de Diario";
                     bte.AutoSize = true;
                  }
               }
               else if (e.Column.Name.Equals("RegAsientoCompras"))
               {
                  RadButtonElement bte = (RadButtonElement)e.CellElement.Children[0];
                  if (bte.Image == null)
                  {
                     bte.TextImageRelation = TextImageRelation.Overlay;
                     bte.DisplayStyle = DisplayStyle.Image;
                     bte.ImageAlignment = ContentAlignment.MiddleCenter;
                     bte.Image = Resources.refresh;
                     bte.ToolTipText = @"Regenerar Asiento de Reversión de Compras";
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
      
      #endregion

      private void txtCCCT_Codigo_KeyPress(object sender, KeyPressEventArgs e)
      {
         Infrastructure.Aspect.Constants.Util.ValidaCodigo_KeyPress(ref e);
      }

      private void cmbTIPE_Codigo_SelectedIndexChanged(object sender, EventArgs e)
      {
         try
         {
            if (cmbTIPE_Codigo.TipoEntidadSelectedItem != null)
            {
               txaENTC_Codigo.Clear();
               txaENTC_Codigo.TiposEntidad = EntidadClear.getTipoEntidadEnum(cmbTIPE_Codigo.TipoEntidadSelectedItem.TIPE_Codigo);
               txaENTC_Codigo.Enabled = true;
            }
            else
            {
               txaENTC_Codigo.Clear();
               txaENTC_Codigo.Enabled = false;
            }

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
            Presenter.CloseView();
            //BusinessLogic.Colecciones.Inicializar(Presenter.Container);
            CloseForm(null, new Infrastructure.Client.FormClose.FormCloseEventArgs(this.TabPageControl, Presenter.CUS));
         }
      }
      public event Infrastructure.Client.FormClose.FormCloseEventArgs.FormCloseEventHandler CloseForm;
      #endregion
   }
}
