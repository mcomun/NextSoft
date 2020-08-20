using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using Delfin.Entities;
using Delfin.Principal.Properties;
using Infrastructure.Aspect.Collections;
using Infrastructure.Aspect.Constants;
using Infrastructure.Aspect.BusinessEntity;
using Infrastructure.Client.FormClose;
using Infrastructure.WinFormsControls;
using Telerik.WinControls;
using Telerik.WinControls.UI;
using Telerik.WinControls.UI.Localization;
using TiposEntidad = Delfin.Controls.TiposEntidad;
using System.Data;
using System.Diagnostics;
using ImportarExcel = Delfin.Controls.ImportarExcel;

namespace Delfin.Principal
{
   public partial class MAN013LView : UserControl, IMAN013LView
   {
      #region [ Formulario ]
      public MAN013LView(RadPageViewPage x_tabPageControl)
      {
         InitializeComponent();
         try
         {
            TabPageControl = x_tabPageControl;
            btnNuevo.Click += btnNuevo_Click;
            btnBuscar.Click += btnBuscar_Click;
            //btnExportar.Click += btnExportar_Click;
            //btnDeshacer.Click += btnDeshacer_Click;
            BSItems = new BindingSource();
            BSItems.CurrentItemChanged += BSItems_CurrentItemChanged;
            grdItems.CommandCellClick += grdItems_CommandCellClick;
            grdItems.CellFormatting += grdItems_CellFormatting;
            //grdItems.CellFormatting += grdItems_CellFormatting;
            TitleView.FormClose += TitleView_FormClose;
         }
         catch (Exception ex)
         { Dialogos.MostrarMensajeError(Presenter.Title, Mensajes.ConstructorView, ex); }
      }
      #endregion
      #region [ Propiedades ]
      public RadPageViewPage TabPageControl { get; set; }
      public Image IconView { get { return TitleView.FormIcon; } set { TitleView.FormIcon = value; } }
      public MAN013Presenter Presenter { get; set; }
      public BindingSource BSItems { get; set; }
      #endregion

      #region [ IMAN013LView ]
      public void LoadView()
      {
         try
         {
            BSItems.DataSource = null;
            grdItems.DataSource = BSItems;
            navItems.BindingSource = BSItems;
            BSItems.ResetBindings(true);
            CargarCombos();
            FormatDataGrid();
            grdItems.Enabled = false;
            btnExportar.Enabled = false;
         }
         catch (Exception ex)
         { Dialogos.MostrarMensajeError(Presenter.Title, Mensajes.LoadView, ex); }
      }
      public void ShowItems()
      {
         try
         {
            BSItems.DataSource = Presenter.ItemsTiposCambio;
            grdItems.DataSource = BSItems;
            navItems.BindingSource = BSItems;
            BSItems.ResetBindings(true);
            if (grdItems.RowCount > 0)
            {
               grdItems.Enabled = true;
               btnExportar.Enabled = true;
               //GridAutoFit.Fit(grdItems);
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
      #endregion

      #region [ DataGrid ]
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
            commandColumn = new GridViewCommandColumn();
            commandColumn.Name = "Edit";
            commandColumn.HeaderText = @"Editar";
            commandColumn.DefaultText = @"Editar";
            commandColumn.UseDefaultText = true;
            grdItems.Columns.Add(commandColumn);
            grdItems.Columns["Edit"].AllowSort = false;
            grdItems.Columns["Edit"].AllowFiltering = false;
            commandColumn = new GridViewCommandColumn();
            commandColumn.Name = "Delete";
            commandColumn.HeaderText = @"Eliminar";
            commandColumn.DefaultText = @"Eliminar";
            commandColumn.UseDefaultText = true;
            grdItems.Columns.Add(commandColumn);
            grdItems.Columns["Delete"].AllowSort = false;
            grdItems.Columns["Delete"].AllowFiltering = false;

            grdItems.Columns.Add("TIPC_Fecha", "Fecha", "TIPC_Fecha");
            grdItems.Columns["TIPC_Fecha"].Width = 100;
            grdItems.Columns["TIPC_Fecha"].TextAlignment = ContentAlignment.MiddleLeft;
            grdItems.Columns["TIPC_Fecha"].ReadOnly = true;
            grdItems.Columns.Add("TIPC_Compra", "Compra", "TIPC_Compra");
            grdItems.Columns["TIPC_Compra"].FormatString = @"{0:###,##0.0000}";
            grdItems.Columns["TIPC_Compra"].Width = 100;
            grdItems.Columns["TIPC_Compra"].TextAlignment = ContentAlignment.MiddleRight;
            grdItems.Columns["TIPC_Compra"].ReadOnly = true;
            grdItems.Columns.Add("TIPC_Venta", "Venta", "TIPC_Venta");
            grdItems.Columns["TIPC_Venta"].FormatString = @"{0:###,##0.0000}";
            grdItems.Columns["TIPC_Venta"].FormatString = @"{0:###,##0.0000}";
            grdItems.Columns["TIPC_Venta"].Width = 100;
            grdItems.Columns["TIPC_Venta"].TextAlignment = ContentAlignment.MiddleRight;
            grdItems.Columns["TIPC_Venta"].ReadOnly = true;

            grdItems.Columns.Add("TIPC_DolEuro", "Cambio US$ a €", "TIPC_DolEuro");
            grdItems.Columns["TIPC_DolEuro"].FormatString = @"{0:###,##0.000000}";
            grdItems.Columns["TIPC_DolEuro"].FormatString = @"{0:###,##0.000000}";
            grdItems.Columns["TIPC_DolEuro"].Width = 120;
            grdItems.Columns["TIPC_DolEuro"].TextAlignment = ContentAlignment.MiddleRight;
            grdItems.Columns["TIPC_DolEuro"].ReadOnly = true;

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
      #endregion

      #region [ Metodos ]

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
               if (BSItems != null && BSItems.Current != null && BSItems.Current is TiposCambio)
               { Presenter.ItemTiposCambio = ((TiposCambio)BSItems.Current); }
               else
               { Presenter.ItemTiposCambio = null; }
            }
         }
         catch (Exception ex)
         {
            if (Presenter != null)
               Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al seleccionar el item.", ex);
         }
      }
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
                     SeleccionarItem();
                     Presenter.Editar(CmbAno.SelectedValue.ToString() + cmbMes.SelectedValue.ToString().PadLeft(2, '0'));
                     break;
                  case "Eliminar":
                     SeleccionarItem();
                     Presenter.Eliminar(CmbAno.SelectedValue.ToString() + cmbMes.SelectedValue.ToString().PadLeft(2, '0'));
                     break;
               }
            }
         }
         catch (Exception ex)
         { Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al cargar los botones para editar y eliminar.", ex); }

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
               if (e.CellElement.RowInfo is GridViewNewRowInfo && e.CellElement.ColumnInfo is GridViewCommandColumn)
               {
                  ((RadButtonElement)e.CellElement.Children[0]).Visibility = ElementVisibility.Hidden;
               }
            }
         }
         catch (Exception ex) { Infrastructure.WinFormsControls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al formatear el icono." + ex.Message); }
      }

      void btnNuevo_Click(object sender, EventArgs e)
      {
         Nuevo();
      }
      void btnBuscar_Click(object sender, EventArgs e)
      {
         Buscar();
      }

      private void Nuevo()
      {
         try
         {
            Presenter.Nuevo(CmbAno.SelectedValue.ToString() + cmbMes.SelectedValue.ToString().PadLeft(2, '0'));
         }
         catch (Exception ex)
         { Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al hacer nuevo.", ex); }
      }

      private void CargarCombos()
      {
         List<KeyValuePair<int, string>> loMes = new List<KeyValuePair<int, string>>();
         loMes.Add(new KeyValuePair<int, string>(1, "Enero"));
         loMes.Add(new KeyValuePair<int, string>(2, "Febrero"));
         loMes.Add(new KeyValuePair<int, string>(3, "Marzo"));
         loMes.Add(new KeyValuePair<int, string>(4, "Abril"));
         loMes.Add(new KeyValuePair<int, string>(5, "Mayo"));
         loMes.Add(new KeyValuePair<int, string>(6, "Junio"));
         loMes.Add(new KeyValuePair<int, string>(7, "Julio"));
         loMes.Add(new KeyValuePair<int, string>(8, "Agosto"));
         loMes.Add(new KeyValuePair<int, string>(9, "Setiembre"));
         loMes.Add(new KeyValuePair<int, string>(10, "Octubre"));
         loMes.Add(new KeyValuePair<int, string>(11, "Noviembre"));
         loMes.Add(new KeyValuePair<int, string>(12, "Diciembre"));
         String _Mes = DateTime.Now.Month == 1 ? "Enero" : DateTime.Now.Month == 2 ? "Febrero" : DateTime.Now.Month == 3 ? "Marzo" : DateTime.Now.Month == 4 ? "Abril" : DateTime.Now.Month == 5 ? "Mayo" : DateTime.Now.Month == 6 ? "Junio" : DateTime.Now.Month == 7 ? "Julio" : DateTime.Now.Month == 8 ? "Agosto" : DateTime.Now.Month == 9 ? "Setiembre" : DateTime.Now.Month == 10 ? "Octubre" : DateTime.Now.Month == 11 ? "Noviembre" : "Diciembre";
         cmbMes.DataSource = loMes;
         cmbMes.ValueMember = "Key";
         cmbMes.DisplayMember = "Value";
         cmbMes.SelectedIndex = cmbMes.FindStringExact(_Mes);

         List<KeyValuePair<int, int>> loAno = new List<KeyValuePair<int, int>>();
         for (int i = DateTime.Now.Year - 10; i <= DateTime.Now.Year + 2; i++)
         {
            loAno.Add(new KeyValuePair<int, int>(i, i));
         }
         CmbAno.DataSource = loAno;
         CmbAno.ValueMember = "Key";
         CmbAno.DisplayMember = "Value";
         CmbAno.SelectedIndex = CmbAno.FindStringExact(DateTime.Now.Year.ToString());
      }
      private void Buscar()
      {
         try
         {
            Presenter.Actualizar(CmbAno.SelectedValue.ToString() + cmbMes.SelectedValue.ToString().PadLeft(2, '0'));
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
            btnExportar.Enabled = false;
         }
         catch (Exception ex)
         { Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al deshacer la vista.", ex); }
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
