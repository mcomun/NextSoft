using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections.ObjectModel;
using Infrastructure.Aspect.Collections;
using Telerik.WinControls.UI;
using Telerik.WinControls;
using Delfin.Principal.Properties;

namespace Delfin.Principal
{
   public partial class CAJ011AnularDocBancosLView : UserControl, ICAJ011AnularDocBancosLView
   {
      #region [ Variables ]
      //private String m_sortColumnName;
      //private Boolean m_sortAscending = false;
      #endregion

      #region [ Formulario ]
      public CAJ011AnularDocBancosLView(Telerik.WinControls.UI.RadPageViewPage x_tabPageControl)
      {
         InitializeComponent();
         try
         {
            TabPageControl = x_tabPageControl;

            btnBuscar.Click += new EventHandler(btnBuscar_Click);
            btnDeshacer.Click += new EventHandler(btnDeshacer_Click);
            btnExportar.Click += new EventHandler(btnExportar_Click);

            sctBase.Panel2Collapsed = true;
            cmbTIPO_CodMND.Enabled = false;
            cmbTIPO_CodBCO.Enabled = false;

            BSItems = new BindingSource();
            BSItems.CurrentItemChanged += new EventHandler(BSItems_CurrentItemChanged);
            grdItems.CommandCellClick += new Telerik.WinControls.UI.CommandCellClickEventHandler(grdItems_CommandCellClick);
            grdItems.CellFormatting += grdItems_CellFormatting;
            txaCUBA_Codigo.SelectedItemCuentaBancariaChanged += txaCUBA_Codigo_SelectedItemCuentaBancariaChanged;

            TitleView.FormClose += new EventHandler(TitleView_FormClose);
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error inicializando el formulario LView.", ex); }
      }
      #endregion

      #region [ Propiedades ]
      public Telerik.WinControls.UI.RadPageViewPage TabPageControl { get; set; }
      public Image IconView { get { return TitleView.FormIcon; } set { TitleView.FormIcon = value; } }
      public CAJ011AnularDocBancosPresenter Presenter { get; set; }
      public BindingSource BSItems { get; set; }
      #endregion

      #region [ ICAJ011AnularDocBancosLView ]

      public void LoadView()
      {
         try
         {
            cmbTIPO_CodMND.LoadControl(Presenter.ContainerService, "Ayuda de Moneda", "MND", "< Sel. Moneda >", ListSortDirection.Ascending);
            cmbTIPO_CodBCO.LoadControl(Presenter.ContainerService, "Ayuda de Bancos", "BCO", "< Sel. Banco >", ListSortDirection.Ascending);
            txaCUBA_Codigo.LoadControl(Presenter.ContainerService, "Ayuda de Cuentas Bancarias", Delfin.Controls.Entorno.ItemEmpresa.EMPR_Codigo, Presenter.Session.UserName);

            FormatDataGrid();
            FormatDataGridDetalle();

            dtpFecIni.NSFecha = new DateTime(Presenter.Fecha.Year, Presenter.Fecha.Month, 1);
            dtpFecFin.NSFecha = dtpFecIni.NSFecha.Value.AddMonths(1).AddDays(-1);

            grdItems.Enabled = false;
            btnBuscar.Enabled = true;
            btnExportar.Enabled = false;
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
               Infrastructure.WinForms.Controls.GridAutoFit.Fit(this.grdItems);
               btnExportar.Enabled = true;
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
            commandColumn.Name = "Extornar";
            commandColumn.HeaderText = "Extornar";
            commandColumn.DefaultText = "Extornar";
            commandColumn.UseDefaultText = true;
            this.grdItems.Columns.Add(commandColumn);
            this.grdItems.Columns["Extornar"].AllowSort = false;
            this.grdItems.Columns["Extornar"].AllowFiltering = false;

            commandColumn = new Telerik.WinControls.UI.GridViewCommandColumn();
            commandColumn.Name = "Nullable";
            commandColumn.HeaderText = "Anular";
            commandColumn.DefaultText = "Anular";
            commandColumn.UseDefaultText = true;
            this.grdItems.Columns.Add(commandColumn);
            this.grdItems.Columns["Nullable"].AllowSort = false;
            this.grdItems.Columns["Nullable"].AllowFiltering = false;

            this.grdItems.Columns.Add("MOVI_FecEmision", "Fecha Emisión", "MOVI_FecEmision");
            this.grdItems.Columns.Add("MOVI_NroOperacion", "Nro. Operación", "MOVI_NroOperacion");
            this.grdItems.Columns.Add("TIPO_MOV", "Tipo Movimiento", "TIPO_MOV");
            this.grdItems.Columns.Add("Monto", "Monto", "Monto");
            this.grdItems.Columns.Add("MOVI_TipoCambio", "Tipo de Cambio", "MOVI_TipoCambio");
            this.grdItems.Columns.Add("ENTC_DocIden", "R.U.C. / D.N.I.", "ENTC_DocIden");
            this.grdItems.Columns.Add("ENTC_RazonSocial", "Cliente / Proveedor", "ENTC_RazonSocial");
            this.grdItems.Columns.Add("MOVI_Concepto", "Concepto", "MOVI_Concepto");
            //this.grdItems.Columns.Add("MOVI_FecDiferido", "Fecha Diferido", "MOVI_FecDiferido");
            //this.grdItems.Columns.Add("Documentos", "Documentos", "Documentos");
            //this.grdItems.Columns.Add("OrdenVenta", "Orden de Venta", "OrdenVenta");
            this.grdItems.Columns.Add("NEstado", "Estado", "NEstado");
            this.grdItems.Columns.Add("MOVI_Codigo", "Código", "MOVI_Codigo");
            this.grdItems.Columns.Add("PLAN_Codigo", "Cod. Planilla", "PLAN_Codigo");
            this.grdItems.Columns.Add("Extornado_Text", "Extornado", "Extornado_Text");
            this.grdItems.Columns.Add("Transferencia_Text", "Transferencia", "Transferencia_Text");
            this.grdItems.Columns.Add("Diferido_Text", "Diferido", "Diferido_Text");
            this.grdItems.Columns.Add("ChequeEnBlanco_Text", "Cheque en Blanco", "ChequeEnBlanco_Text");

            this.grdItems.Columns["Extornado_Text"].TextAlignment = ContentAlignment.MiddleCenter;
            this.grdItems.Columns["Transferencia_Text"].TextAlignment = ContentAlignment.MiddleCenter;
            this.grdItems.Columns["Diferido_Text"].TextAlignment = ContentAlignment.MiddleCenter;
            this.grdItems.Columns["ChequeEnBlanco_Text"].TextAlignment = ContentAlignment.MiddleCenter;

            //Telerik.WinControls.UI.GridViewCheckBoxColumn checkColumn;
            //checkColumn = new Telerik.WinControls.UI.GridViewCheckBoxColumn();
            //checkColumn.Name = "Extornado";
            //checkColumn.FieldName = "Extornado";
            //checkColumn.HeaderText = "Extornado";
            //checkColumn.ReadOnly = false;
            //this.grdItems.Columns.Add(checkColumn);


            ToolStripSeparator tsmSeparacion = new ToolStripSeparator();
            tsmColumnas.DropDownItems.Add(tsmSeparacion);
            tsmTodos = new ToolStripMenuItem("Todos");
            tsmTodos.Tag = "Todas";
            tsmTodos.Checked = false;
            tsmTodos.CheckOnClick = true;
            tsmTodos.Click += new EventHandler(tsmTodos_Click);
            tsmColumnas.DropDownItems.Add(tsmTodos);

            Infrastructure.WinForms.Controls.GridAutoFit.Fit(grdItems);

            grdItems.ReadOnly = true;
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

      private void FormatDataGridDetalle()
      {
         try
         {
            Telerik.WinControls.UI.Localization.RadGridLocalizationProvider.CurrentProvider = new Infrastructure.WinForms.Controls.MySpanishRadGridLocalizationProvider();
            this.grdItemsDetalle.Columns.Clear();
            this.grdItemsDetalle.AllowAddNewRow = false;
            
            this.grdItemsDetalle.Columns.Add("MOVI_FecEmision", "Fecha Emisión", "MOVI_FecEmision");
            this.grdItemsDetalle.Columns.Add("MOVI_NroOperacion", "Nro. Operación", "MOVI_NroOperacion");
            this.grdItemsDetalle.Columns.Add("TIPO_MOV", "Tipo Movimiento", "TIPO_MOV");
            this.grdItemsDetalle.Columns.Add("Monto", "Monto", "Monto");
            this.grdItemsDetalle.Columns.Add("MOVI_TipoCambio", "Tipo de Cambio", "MOVI_TipoCambio");
            this.grdItemsDetalle.Columns.Add("ENTC_RazonSocial", "Cliente / Proveedor", "ENTC_RazonSocial");
            this.grdItemsDetalle.Columns.Add("MOVI_Concepto", "Concepto", "MOVI_Concepto");
            //this.grdItems.Columns.Add("MOVI_FecDiferido", "Fecha Diferido", "MOVI_FecDiferido");
            //this.grdItems.Columns.Add("Documentos", "Documentos", "Documentos");
            //this.grdItems.Columns.Add("OrdenVenta", "Orden de Venta", "OrdenVenta");
            this.grdItemsDetalle.Columns.Add("NEstado", "Estado", "NEstado");
            this.grdItemsDetalle.Columns.Add("MOVI_Codigo", "Código", "MOVI_Codigo");
            this.grdItemsDetalle.Columns.Add("Extornado_Text", "Extornado", "Extornado_Text");
            this.grdItemsDetalle.Columns.Add("Transferencia_Text", "Transferencia", "Transferencia_Text");
            this.grdItemsDetalle.Columns.Add("Diferido_Text", "Diferido", "Diferido_Text");
            this.grdItemsDetalle.Columns.Add("ChequeEnBlanco_Text", "Cheque en Blanco", "ChequeEnBlanco_Text");

            this.grdItemsDetalle.Columns["Extornado_Text"].TextAlignment = ContentAlignment.MiddleCenter;
            this.grdItemsDetalle.Columns["Transferencia_Text"].TextAlignment = ContentAlignment.MiddleCenter;
            this.grdItemsDetalle.Columns["Diferido_Text"].TextAlignment = ContentAlignment.MiddleCenter;
            this.grdItemsDetalle.Columns["ChequeEnBlanco_Text"].TextAlignment = ContentAlignment.MiddleCenter;

            //Telerik.WinControls.UI.GridViewCheckBoxColumn checkColumn;
            //checkColumn = new Telerik.WinControls.UI.GridViewCheckBoxColumn();
            //checkColumn.Name = "Extornado";
            //checkColumn.FieldName = "Extornado";
            //checkColumn.HeaderText = "Extornado";
            //checkColumn.ReadOnly = false;
            //this.grdItems.Columns.Add(checkColumn);


            ToolStripSeparator tsmSeparacion = new ToolStripSeparator();
            tsmColumnas.DropDownItems.Add(tsmSeparacion);
            tsmTodos = new ToolStripMenuItem("Todos");
            tsmTodos.Tag = "Todas";
            tsmTodos.Checked = false;
            tsmTodos.CheckOnClick = true;
            tsmTodos.Click += new EventHandler(tsmTodos_Click);
            tsmColumnas.DropDownItems.Add(tsmTodos);

            Infrastructure.WinForms.Controls.GridAutoFit.Fit(grdItemsDetalle);

            grdItemsDetalle.ReadOnly = true;
            grdItemsDetalle.ShowFilteringRow = false;
            grdItemsDetalle.EnableFiltering = false;
            grdItemsDetalle.MasterTemplate.EnableFiltering = false;
            grdItemsDetalle.EnableGrouping = false;
            grdItemsDetalle.MasterTemplate.EnableGrouping = false;
            grdItemsDetalle.EnableSorting = false;
            grdItemsDetalle.MasterTemplate.EnableCustomSorting = false;
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
                  Presenter.Item = ((Entities.Movimiento)BSItems.Current);
               }
               else
               {
                  Presenter.Item = null;
               }
            }
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al seleccionar el item.", ex); }
      }

      private void Buscar()
      {
         try
         {
            GetFiltros();
            if (Presenter.F_CUBA_Codigo != null)
            {
               Presenter.Actualizar();
            }
            else { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Presenter.Title, "Debe seleccionar una cuenta bancaria para realizar la búsqueda"); }
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al buscar.", ex); }
      }

      private void GetFiltros()
      {
         try
         {
            Presenter.F_FecIni = null; if (dtpFecIni.NSFecha.HasValue) { Presenter.F_FecIni = dtpFecIni.NSFecha; }
            Presenter.F_FecFin = null; if (dtpFecFin.NSFecha.HasValue) { Presenter.F_FecFin = dtpFecFin.NSFecha; }
            Presenter.F_CUBA_Codigo = null; if (txaCUBA_Codigo.SelectedItem != null) { Presenter.F_CUBA_Codigo = txaCUBA_Codigo.SelectedItem.CUBA_Codigo; }
         }
         catch (Exception)
         { throw; }
      }

      private void Exportar()
      {
         try
         {
             List<String> Titulos = new List<String>();
             Titulos.Add(Presenter.Title);
             Int32 _fila = 2;
             Infrastructure.WinForms.Controls.ExcelAportes _xls = new Infrastructure.WinForms.Controls.ExcelAportes(1, Titulos, "");
             Object[] _cabeceras = new Object[1];
             DataTable _dt = _xls.RadGridViewToDataTable(grdItems, ref _cabeceras, grdItems.FilterDescriptors.Count > 0);
             /*****************************************/
             if (_dt.Columns["Extornar"] != null)
             { _dt.Columns.Remove("Extornar"); }
             if (_dt.Columns["Nullable"] != null)
             { _dt.Columns.Remove("Nullable"); }
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

            grdItems.Enabled = true;
            btnBuscar.Enabled = true;
            btnExportar.Enabled = false;
            txaCUBA_Codigo.ClearCuentaBancaria();
            cmbTIPO_CodMND.SelectedIndex = 0;
            cmbTIPO_CodBCO.SelectedIndex = 0;
            dtpFecIni.NSFecha = new DateTime(Presenter.Fecha.Year, Presenter.Fecha.Month, 1);
            dtpFecFin.NSFecha = dtpFecIni.NSFecha.Value.AddMonths(1).AddDays(-1);
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al deshacer la vista.", ex); }
      }
      #endregion

      #region [ Eventos ]

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
                  case "Extornar":
                     SeleccionarItem();
                     Presenter.Extornar();
                     break;
                  case "Anular":
                     SeleccionarItem();
                     Presenter.Anular();
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
               if (e.Column.Name.Equals("Extornar"))
               {
                  RadButtonElement bte = (RadButtonElement)e.CellElement.Children[0];
                  if (bte.Image == null)
                  {
                     bte.TextImageRelation = TextImageRelation.Overlay;
                     bte.DisplayStyle = DisplayStyle.Image;
                     bte.ImageAlignment = ContentAlignment.MiddleCenter;
                     bte.Image = Resources.scroll_error_16x16;
                     bte.ToolTipText = @"Extornar Registro";
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
            {
               cmbTIPO_CodMND.TiposSelectedValue = txaCUBA_Codigo.SelectedItem.TIPO_CodMND;
               cmbTIPO_CodBCO.TiposSelectedValue = txaCUBA_Codigo.SelectedItem.TIPO_CodBCO;
            }
            else { cmbTIPO_CodMND.SelectedIndex = 0; cmbTIPO_CodBCO.SelectedIndex = 0; }
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
