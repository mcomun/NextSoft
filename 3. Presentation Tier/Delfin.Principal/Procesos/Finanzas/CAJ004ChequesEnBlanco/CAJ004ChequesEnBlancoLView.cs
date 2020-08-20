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
   public partial class CAJ004ChequesEnBlancoLView : UserControl, ICAJ004ChequesEnBlancoLView
   {
      #region [ Variables ]
      //private String m_sortColumnName;
      //private Boolean m_sortAscending = false;
      #endregion

      #region [ Formulario ]
      public CAJ004ChequesEnBlancoLView(Telerik.WinControls.UI.RadPageViewPage x_tabPageControl)
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
            BSItems = new BindingSource();
            BSItems.CurrentItemChanged += new EventHandler(BSItems_CurrentItemChanged);

            grdItems.CommandCellClick += new Telerik.WinControls.UI.CommandCellClickEventHandler(grdItems_CommandCellClick);
            grdItems.CellFormatting += grdItems_CellFormatting;

            TitleView.FormClose += new EventHandler(TitleView_FormClose);

            txtMOVI_Codigo.KeyPress += txtMOVI_Codigo_KeyPress;
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error inicializando el formulario LView.", ex); }
      }


      #endregion

      #region [ Propiedades ]
      public Telerik.WinControls.UI.RadPageViewPage TabPageControl { get; set; }
      public Image IconView { get { return TitleView.FormIcon; } set { TitleView.FormIcon = value; } }
      public CAJ004ChequesEnBlancoPresenter Presenter { get; set; }
      public BindingSource BSItems { get; set; }
      #endregion

      #region [ ICAJ004ChequesEnBlancoLView ]
      public void LoadView()
      {
         try
         {
            FormatDataGrid();

            grdItems.Enabled = false;
            btnNuevo.Enabled = true;
            btnBuscar.Enabled = true;
            btnExportar.Enabled = false;

            dtpMOVI_FecEmision_Ini.NSFecha = new DateTime(Presenter.Fecha.Year, Presenter.Fecha.Month, 1);
            dtpMOVI_FecEmision_Fin.NSFecha = dtpMOVI_FecEmision_Ini.NSFecha.Value.AddMonths(1).AddDays(-1);
            txaENTC_Codigo.LoadControl(Presenter.ContainerService, TiposEntidad.TIPE_Proveedor, null, null, true);
            txaCUBA_Codigo.LoadControl(Presenter.ContainerService, "Cuentas Bancarias", Delfin.Controls.Entorno.ItemEmpresa.EMPR_Codigo, Presenter.Session.UserName);
            cmbTIPO_CodMND.LoadControl(Presenter.ContainerService, "Moneda", "MND", "< Sel. Moneda>", ListSortDirection.Ascending);

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
            }
            else
            {
               grdItems.Enabled = false;
               btnExportar.Enabled = false;
            }

            grdItems.ShowFilteringRow = false;
            grdItems.EnableFiltering = false;
            grdItems.MasterTemplate.EnableFiltering = false;
            grdItems.EnableGrouping = false;
            grdItems.MasterTemplate.EnableGrouping = false;
            grdItems.EnableSorting = false;
            grdItems.MasterTemplate.EnableCustomSorting = false;

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
            //commandColumn = new Telerik.WinControls.UI.GridViewCommandColumn();
            //commandColumn.Name = "Delete";
            //commandColumn.HeaderText = "Eliminar";
            //commandColumn.DefaultText = "Eliminar";
            //commandColumn.UseDefaultText = true;
            //this.grdItems.Columns.Add(commandColumn);
            //this.grdItems.Columns["Delete"].AllowSort = false;
            //this.grdItems.Columns["Delete"].AllowFiltering = false;

            this.grdItems.Columns.Add("MOVI_Codigo", "Interno", "MOVI_Codigo");
            this.grdItems.Columns.Add("TIPO_MOV", "Tipo Movimiento", "TIPO_MOV");
            this.grdItems.Columns.Add("MOVI_Numero", "Nro. Cheque", "MOVI_Numero");
            this.grdItems.Columns.Add("CUBA_Codigo", "Código", "CUBA_Codigo");
            this.grdItems.Columns.Add("CUBA_NroCuenta", "Nro. Cuenta", "CUBA_NroCuenta");
            this.grdItems.Columns.Add("MOVI_FecEmision", "Fecha Emisión", "MOVI_FecEmision");
            this.grdItems.Columns.Add("TIPO_MND", "Moneda", "TIPO_MND");
            this.grdItems.Columns.Add("ENTC_DocIden", "RUC Entidad", "ENTC_DocIden");
            this.grdItems.Columns.Add("ENTC_RazonSocial", "Entidad", "ENTC_RazonSocial");

            ToolStripSeparator tsmSeparacion = new ToolStripSeparator();
            tsmColumnas.DropDownItems.Add(tsmSeparacion);
            tsmTodos = new ToolStripMenuItem("Todos");
            tsmTodos.Tag = "Todas";
            tsmTodos.Checked = false;
            tsmTodos.CheckOnClick = true;
            tsmTodos.Click += new EventHandler(tsmTodos_Click);
            tsmColumnas.DropDownItems.Add(tsmTodos);

            Infrastructure.WinForms.Controls.GridAutoFit.Fit(grdItems);

            grdItems.ShowFilteringRow = false;
            grdItems.EnableFiltering = false;
            grdItems.MasterTemplate.EnableFiltering = false;
            grdItems.EnableGrouping = false;
            grdItems.MasterTemplate.EnableGrouping = false;
            grdItems.EnableSorting = false;
            grdItems.MasterTemplate.EnableCustomSorting = false;
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
               if (BSItems != null && BSItems != null && BSItems.DataSource != null && BSItems.Current != null && BSItems.Current is Entities.Movimiento)
               {
                  Presenter.MOVI_Codigo = (BSItems.Current as Entities.Movimiento).MOVI_Codigo;
               }
               else
               {
                  Presenter.MOVI_Codigo = null;
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
            Presenter.Nuevo();
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
               if (decimal.Parse(value) > 2147483647)
               {
                  txtMOVI_Codigo.Text = "2147483647";
               }
            }
            getFiltros();

            Presenter.Actualizar();
            grdItems.BestFitColumns();
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al buscar.", ex); }
      }

      private void getFiltros()
      {
         try
         {
            Presenter.F_CUBA_Codigo = null; if (txaCUBA_Codigo.SelectedItem != null) { Presenter.F_CUBA_Codigo = txaCUBA_Codigo.SelectedItem.CUBA_Codigo; }
            Presenter.F_MOVI_Codigo = null; if (!String.IsNullOrEmpty(txtMOVI_Codigo.Text)) { Presenter.F_MOVI_Codigo = Int32.Parse(txtMOVI_Codigo.Text); }
            Presenter.F_ENTC_Codigo = null; if (txaENTC_Codigo.SelectedItem != null) { Presenter.F_ENTC_Codigo = txaENTC_Codigo.SelectedItem.ENTC_Codigo; }
            Presenter.F_FecIni = null; if (dtpMOVI_FecEmision_Ini.NSFecha.HasValue) { Presenter.F_FecIni = dtpMOVI_FecEmision_Ini.NSFecha; }
            Presenter.F_FecFin = null; if (dtpMOVI_FecEmision_Ini.NSFecha.HasValue) { Presenter.F_FecFin = dtpMOVI_FecEmision_Fin.NSFecha; }
         }
         catch (Exception)
         { }
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
            btnExportar.Enabled = false;
            txtMOVI_Codigo.Clear();
            txaCUBA_Codigo.ClearCuentaBancaria();
            txaENTC_Codigo.Clear();
            cmbTIPO_CodMND.SelectedIndex = 0;
            dtpMOVI_FecEmision_Ini.NSFecha = new DateTime(Presenter.Fecha.Year, Presenter.Fecha.Month, 1);
            dtpMOVI_FecEmision_Fin.NSFecha = dtpMOVI_FecEmision_Ini.NSFecha.Value.AddMonths(1).AddDays(-1);
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al deshacer la vista.", ex); }
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

      void txtMOVI_Codigo_KeyPress(object sender, KeyPressEventArgs e)
      {
         try
         {
            Infrastructure.Aspect.Constants.Util.ValidaCodigo_KeyPress(ref e);
         }
         catch (Exception)
         { }
      }

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
               //if (e.Column.Name.Equals("Delete"))
               //{
               //   RadButtonElement bte = (RadButtonElement)e.CellElement.Children[0];
               //   if (bte.Image == null)
               //   {
               //      bte.TextImageRelation = TextImageRelation.Overlay;
               //      bte.DisplayStyle = DisplayStyle.Image;
               //      bte.ImageAlignment = ContentAlignment.MiddleCenter;
               //      bte.Image = Resources.Sign_07;
               //      bte.ToolTipText = @"Eliminar Registro";
               //      bte.AutoSize = true;
               //   }
               //}
               if (e.CellElement.RowInfo is GridViewNewRowInfo && e.CellElement.ColumnInfo is GridViewCommandColumn)
               {
                  ((RadButtonElement)e.CellElement.Children[0]).Visibility = ElementVisibility.Hidden;
               }
            }
         }
         catch (Exception ex) { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al formatear el icono." + ex.Message); }
      }
      private void txaCUBA_Codigo_SelectedItemCuentaBancariaChanged(object sender, EventArgs e)
      {
         try
         {
            if (txaCUBA_Codigo.SelectedItem != null)
            { cmbTIPO_CodMND.TiposSelectedValue = txaCUBA_Codigo.SelectedItem.TIPO_CodMND; }
            else { cmbTIPO_CodMND.SelectedIndex = 0; }
         }
         catch (Exception)
         { }
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
