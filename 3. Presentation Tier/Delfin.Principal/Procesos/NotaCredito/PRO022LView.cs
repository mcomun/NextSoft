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
   public partial class PRO022LView : UserControl, IPRO022LView
   {
      #region [ Variables ]

      #endregion

      #region [ Formulario ]

      public PRO022LView(RadPageViewPage x_tabPageControl)
      {
         InitializeComponent();
         try
         {
            TabPageControl = x_tabPageControl;
            btnNuevo.Click += btnNuevo_Click;
            btnBuscar.Click += btnBuscar_Click;
            btnExportar.Click += btnExportar_Click;
            btnDeshacer.Click += btnDeshacer_Click;
            BSItems = new BindingSource();
            BSItems.CurrentItemChanged += BSItems_CurrentItemChanged;
            grdItems.CommandCellClick += grdItems_CommandCellClick;
            grdItems.CellFormatting += grdItems_CellFormatting;
            TitleView.FormClose += TitleView_FormClose;

            txtSERI_UnidadNegocio.ReadOnly = true;
         }
         catch (Exception ex)
         { Dialogos.MostrarMensajeError(Presenter.Title, Mensajes.ConstructorView, ex); }
      }

      #endregion

      #region [ Propiedades ]

      public RadPageViewPage TabPageControl { get; set; }
      public Image IconView { get { return TitleView.FormIcon; } set { TitleView.FormIcon = value; } }
      public PRO022Presenter Presenter { get; set; }
      public BindingSource BSItems { get; set; }

      #endregion

      #region [ IPRO022LView ]

      public void LoadView()
      {
         try
         {
            txaENTC_Codigo.LoadControl(Presenter.ContainerService, Delfin.Controls.TiposEntidad.TIPE_Cliente);

            BSItems.DataSource = null;
            grdItems.DataSource = BSItems;
            navItems.BindingSource = BSItems;
            BSItems.ResetBindings(true);

            txtNumeroFact.Clear();
            txaENTC_Codigo.Clear();
            FormatDataGrid();

            grdItems.Enabled = false;
            btnBuscar.Enabled = true;
            btnExportar.Enabled = false;

            dtpDOCV_FechaEmisionNCIni.NSFecha = new DateTime(Presenter.Fecha.Year, Presenter.Fecha.Month, 1);
            dtpDOCV_FechaEmisionNCFin.NSFecha = dtpDOCV_FechaEmisionNCIni.NSFecha.Value.AddMonths(1).AddDays(-1);

            /* Series */
            cmbSERI_Serie.DisplayMember = "SERI_Serie";
            cmbSERI_Serie.ValueMember = "SERI_Serie";
            cmbSERI_Serie.DataSource = Presenter.ListSeries;

            cmbSERI_Serie.SelectedIndexChanged += cmbSERI_Serie_SelectedIndexChanged;

         }
         catch (Exception ex)
         { Dialogos.MostrarMensajeError(Presenter.Title, Mensajes.LoadView, ex); }
      }

      public void ShowItems()
      {
         try
         {
            BSItems.DataSource = Presenter.ItemsNotaCreditoDS.Tables[0];

            grdItems.DataSource = BSItems;
            navItems.BindingSource = BSItems;
            BSItems.ResetBindings(true);
            if (grdItems.RowCount > 0)
            {
               grdItems.Enabled = true;
               btnExportar.Enabled = true;
               GridAutoFit.Fit(grdItems);
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
            Presenter.F_NroNotaCreditoFiltro = !String.IsNullOrEmpty(txtDOCV_NumeroNC.Text) ? txtDOCV_NumeroNC.Text : null;
            Presenter.F_NroFacturaFiltro = !String.IsNullOrEmpty(txtDOCV_NumeroFac.Text) ? txtDOCV_NumeroFac.Text : null;
            Presenter.F_FecEmisionIniFiltro = dtpDOCV_FechaEmisionNCIni.NSFecha != null ? dtpDOCV_FechaEmisionNCIni.NSFecha : (DateTime?)null;
            Presenter.F_FecEmisionFinFiltro = dtpDOCV_FechaEmisionNCFin.NSFecha != null ? dtpDOCV_FechaEmisionNCFin.NSFecha : (DateTime?)null;
            Presenter.F_Entc_CodigoFiltro = txaENTC_Codigo.SelectedItem != null ? txaENTC_Codigo.SelectedItem.ENTC_Codigo : (int?)null;
            if (!String.IsNullOrEmpty((cmbSERI_Serie.SelectedItem as Entities.Series).SERI_Desc))
            { Presenter.F_DOCV_Serie = (cmbSERI_Serie.SelectedItem as Entities.Series).SERI_Serie; }
            else { Presenter.F_DOCV_Serie = null; }
         }
         catch (Exception ex)
         { Dialogos.MostrarMensajeError(Presenter.Title, Mensajes.LoadView, ex); }
      }

      #endregion

      #region [ Metodos ]

      public void EliminarFiltrosGrid()
      {
         for (int i = 0; i < grdItems.ColumnCount; i++)
         {
            grdItems.FilterDescriptors.Clear();
         }
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

            //###
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

            commandColumn = new GridViewCommandColumn();
            commandColumn.Name = "Imprimir";
            commandColumn.HeaderText = @"Imprimir";
            commandColumn.DefaultText = @"Imprimir";
            commandColumn.UseDefaultText = true;
            grdItems.Columns.Add(commandColumn);
            grdItems.Columns["Imprimir"].AllowSort = false;
            grdItems.Columns["Imprimir"].AllowFiltering = false;
            //###

            grdItems.Columns.Add("DOCV_Serie", "Serie", "DOCV_Serie");
            grdItems.Columns.Add("DOCV_Numero", "Nro.", "DOCV_Numero");
            grdItems.Columns.Add("DOCV_FechaEmision", "Fecha Emisión", "DOCV_FechaEmision");
            grdItems.Columns.Add("Moneda", "Moneda", "Moneda");
            grdItems.Columns.Add("DOCV_ValorVtaTotal", "Valor Venta", "DOCV_ValorVtaTotal");
            grdItems.Columns.Add("Cliente", "Cliente", "Cliente");

            grdItems.Columns.Add("TIPO_TDO_Factura", "T. Documento", "TIPO_TDO_Factura");
            grdItems.Columns.Add("NroFactura", "Nro. Documento", "NroFactura");
            grdItems.Columns.Add("MontoFactura", "Monto Documento", "MontoFactura");

            grdItems.Columns.Add("HBL_MBL", "MBL / HBL", "HBL_MBL");
            grdItems.Columns.Add("OV_OP", "OP / OV", "OV_OP");
            grdItems.Columns.Add("DOCV_Codigo", "Interno", "DOCV_Codigo");

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
               if (BSItems != null && BSItems.Current != null && BSItems.Current is System.Data.DataRowView)
               {
                  int _DOCV_Codigo = 0;
                  int.TryParse(((System.Data.DataRowView)(BSItems.Current)).Row["DOCV_Codigo"].ToString(), out _DOCV_Codigo);
                  Presenter.ItemNotaCreditoSelectedID = _DOCV_Codigo;
               }
               else
               { Presenter.ItemNotaCredito = null; }
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
         /*
         if (Presenter.ItemPreDocsVta.DOCV_Estado.Equals("I") || Presenter.ItemPreDocsVta.DOCV_Estado.Equals("E")) return false;
         Dialogos.MostrarMensajeInformacion(Presenter.Title, "El registro anulado no se puede editar");
         */
         return true;

      }

      private bool BloquearBotonesEdicionFacturacion()
      {
         //if (Presenter.ItemDocsVta.DOCV_Estado.Equals("I") || Presenter.ItemDocsVta.DOCV_Estado.Equals("E")) return false;
         //Dialogos.MostrarMensajeInformacion(Presenter.Title, "El registro anulado no se puede editar");
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

      private void Buscar()
      {
         try
         {
            EliminarFiltrosGrid();
            FiltrosLView();
            if (!String.IsNullOrEmpty(Presenter.F_DOCV_Serie))
            { Presenter.Actualizar(); }
            else
            { Dialogos.MostrarMensajeInformacion(Presenter.Title, "Se debe seleccionar una serie."); }
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

            grdItems.Enabled = true;
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
      private void btnBuscar_Click(object sender, EventArgs e)
      { Buscar(); }
      private void btnExportar_Click(object sender, EventArgs e)
      { Exportar(); }
      private void btnDeshacer_Click(object sender, EventArgs e)
      { Deshacer(); }
      private void BSItems_CurrentItemChanged(object sender, EventArgs e)
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
                     if (Presenter.ItemNotaCreditoSelectedID != 0)
                     {
                        Presenter.Editar(Presenter.ItemNotaCreditoSelectedID);
                     }
                     break;
                  case "Anular":
                     if (Presenter.ItemNotaCreditoSelectedID != 0)
                     {
                        Presenter.Anular(Presenter.ItemNotaCreditoSelectedID);
                     }
                     break;
                  case "Imprimir":
                     if (Presenter.ItemNotaCreditoSelectedID != 0)
                     {
                        Presenter.Imprimir(Presenter.ItemNotaCreditoSelectedID);
                     }
                     break;
               }
            }
         }
         catch (Exception ex)
         { Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al cargar los botones para editar y eliminar.", ex); }

      }
      void grdItems_CellFormatting(object sender, CellFormattingEventArgs e)
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
                  bte.ToolTipText = @"Anular NC";
                  bte.AutoSize = true;
               }
            }

            if (e.Column.Name.Equals("Imprimir"))
            {
               var bte = (RadButtonElement)e.CellElement.Children[0];
               if (bte.Image == null)
               {
                  bte.TextImageRelation = TextImageRelation.Overlay;
                  bte.DisplayStyle = DisplayStyle.Image;
                  bte.ImageAlignment = ContentAlignment.MiddleCenter;
                  bte.Image = Resources.printer2;
                  bte.ToolTipText = @"Imprimir";
                  bte.AutoSize = true;
               }
            }

            if (e.CellElement.RowInfo is GridViewNewRowInfo && e.CellElement.ColumnInfo is GridViewCommandColumn)
            {
               e.CellElement.Children[0].Visibility = ElementVisibility.Hidden;
            }
         }
         catch (Exception ex) { Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al formatear el icono." + ex.Message); }
      }

      private void cmbSERI_Serie_SelectedIndexChanged(object sender, EventArgs e)
      {
         try
         {
            if (String.IsNullOrEmpty((cmbSERI_Serie.SelectedItem as Series).SERI_Serie))
            {
               txtSERI_UnidadNegocio.Clear();
            }
            else
            {
               txtSERI_UnidadNegocio.Text = (cmbSERI_Serie.SelectedItem as Entities.Series).GetSERI_UnidadNegocio();
            }
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
            CloseForm(null, new FormCloseEventArgs(TabPageControl, Presenter.CUS));
         }
      }
      public event FormCloseEventArgs.FormCloseEventHandler CloseForm;

      #endregion
   }
}
