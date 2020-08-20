using System;
using System.Collections.Generic;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Delfin.Entities;
using Delfin.Principal.Properties;
using Infrastructure.Aspect.Constants;
using Infrastructure.Client.FormClose;
using Infrastructure.WinFormsControls;
using Telerik.WinControls.UI;
using Telerik.WinControls;
using Telerik.WinControls.UI.Localization;
using TiposEntidad = Delfin.Controls.TiposEntidad;

namespace Delfin.Principal
{
   public partial class PRO002LView : UserControl, IPRO002LView
   {
      #region [ Variables ]

      #endregion

      #region [ Formulario ]
      public PRO002LView(RadPageViewPage x_tabPageControl)
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
            
         }
         catch (Exception ex)
         { Dialogos.MostrarMensajeError(Presenter.Title, Mensajes.ConstructorView, ex); }
      }

      
      #endregion

      #region [ Propiedades ]
      public RadPageViewPage TabPageControl { get; set; }
      public Image IconView { get { return TitleView.FormIcon; } set { TitleView.FormIcon = value; } }
      public PRO002Presenter Presenter { get; set; }
      public BindingSource BSItems { get; set; }
      #endregion

      #region [ IPRO002LView ]
      public void LoadView()
      {
         try
         {
            AyudaEntidadCliente.ContainerService = Presenter.ContainerService;

            BSItems.DataSource = null;
            grdItems.DataSource = BSItems;
            navItems.BindingSource = BSItems;
            BSItems.ResetBindings(true);

            AyudaEntidadCliente.TipoEntidad = TiposEntidad.TIPE_Cliente;
            mdtFecDesde.NSFecha = Presenter.Session.Fecha;
            mdtFecHasta.NSFecha = Presenter.Session.Fecha;

            FormatDataGrid();
            grdItems.Enabled = false;
            btnNuevo.Enabled = true;
            btnBuscar.Enabled = true;
            btnExportar.Enabled = false;
         }
         catch (Exception ex)
         { Dialogos.MostrarMensajeError(Presenter.Title, Mensajes.LoadView, ex); }
      }
      public void ShowItems()
      {
         try
         {
            BSItems.DataSource = Presenter.ItemsCab_Cotizacion;
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
              if (AyudaEntidadCliente.Value != null)
              {
                  Presenter.FILTROCliente = AyudaEntidadCliente.Value.ENTC_Codigo;
              }
              else { Presenter.FILTROCliente = null; }
              if (mdtFecDesde.NSFecha != null)
              {
                  Presenter.FILTRO_FecEmiDesde = mdtFecDesde.NSFecha.Value;  
              }
              if (mdtFecHasta.NSFecha != null)
              {
                  Presenter.FILTRO_FecEmiHasta = mdtFecHasta.NSFecha.Value;
              }
              if (!String.IsNullOrEmpty(txtNroCotizacion.Text))
              {
                  Presenter.FILTRONroCotizacion = txtNroCotizacion.Text;
              } else { Presenter.FILTRONroCotizacion = null; }
          }
          catch (Exception ex)
          { Dialogos.MostrarMensajeError(Presenter.Title, Mensajes.LoadView, ex); }
      }
      #endregion

      #region [ Metodos ]
      public void EliminarFiltros()
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
            commandColumn = new GridViewCommandColumn();
            commandColumn.Name = "Edit";
            commandColumn.HeaderText = "Editar";
            commandColumn.DefaultText = "Editar";
            commandColumn.UseDefaultText = true;
            grdItems.Columns.Add(commandColumn);
            grdItems.Columns["Edit"].AllowSort = false;
            grdItems.Columns["Edit"].AllowFiltering = false;

            //commandColumn = new GridViewCommandColumn();
            //commandColumn.Name = "Delete";
            //commandColumn.HeaderText = "Eliminar";
            //commandColumn.DefaultText = "Eliminar";
            //commandColumn.UseDefaultText = true;
            //grdItems.Columns.Add(commandColumn);
            //grdItems.Columns["Delete"].AllowSort = false;
            //grdItems.Columns["Delete"].AllowFiltering = false;

            commandColumn = new GridViewCommandColumn();
            commandColumn.Name = "Aprobar";
            commandColumn.HeaderText = "Aprobar";
            commandColumn.DefaultText = "Aprobar";
            commandColumn.UseDefaultText = true;
            grdItems.Columns.Add(commandColumn);
            grdItems.Columns["Aprobar"].AllowSort = false;
            grdItems.Columns["Aprobar"].AllowFiltering = false;

            commandColumn = new GridViewCommandColumn();
            commandColumn.Name = "Anular";
            commandColumn.HeaderText = "Anular";
            commandColumn.DefaultText = "Anular";
            commandColumn.UseDefaultText = true;
            grdItems.Columns.Add(commandColumn);
            grdItems.Columns["Anular"].AllowSort = false;
            grdItems.Columns["Anular"].AllowFiltering = false;

            grdItems.Columns.Add("CCOT_NumDoc", "Número Cotización", "CCOT_NumDoc");
            grdItems.Columns.Add("CCOT_FecEmi", "Fecha Emisión", "CCOT_FecEmi");
            grdItems.Columns.Add("CCOT_FecVcto", "Fecha Vencimiento", "CCOT_FecVcto");
            grdItems.Columns.Add("Cliente", "Cliente", "Cliente");
            grdItems.Columns.Add("LNaviera", "Linea Naviera", "LNaviera");
            grdItems.Columns.Add("CONS_CodEstadosTR", "Estado", "CONS_CodEstadosTR");
            grdItems.Columns.Add("CCOT_Observaciones", "Observaciones", "CCOT_Observaciones");
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
               if (BSItems != null && BSItems.Current != null && BSItems.Current is Cab_Cotizacion)
               { Presenter.ItemLView = ((Cab_Cotizacion)BSItems.Current); }
               else
               { Presenter.ItemLView = null; }
            }
         }
         catch (Exception ex)
         { Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al seleccionar el item.", ex); }
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
             EliminarFiltros();
             Presenter.Actualizar();
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
                     SeleccionarItem();
                     Presenter.Editar();
                     break;
                  case "Eliminar":
                     SeleccionarItem();
                     Presenter.Eliminar();
                     break;
                  case "Aprobar":
                     SeleccionarItem();
                     Presenter.AprobarAnular("Aprobar");
                     break;
                  case "Anular":
                     SeleccionarItem();
                     Presenter.AprobarAnular("Anular");
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
                  if (e.Column.Name.Equals("Aprobar"))
                  {
                      RadButtonElement bte = (RadButtonElement)e.CellElement.Children[0];
                      if (bte.Image == null)
                      {
                          bte.TextImageRelation = TextImageRelation.Overlay;
                          bte.DisplayStyle = DisplayStyle.Image;
                          bte.ImageAlignment = ContentAlignment.MiddleCenter;
                          bte.Image = Resources.Alert_11;
                          bte.ToolTipText = @"Aprobar Cotización";
                          bte.AutoSize = true;
                          
                      }
                      //GridCommandCellElement cell = (GridCommandCellElement)e.CellElement;
                      //if (cell.RowInfo.Cells["CONS_CodEstadosTR"].Value != null && cell.RowInfo.Cells["CONS_CodEstadosTR"].Value == "AUTORIZADA")
                      //{
                      //    cell.CommandButton.Enabled = true;
                      //}
                      //else
                      //{
                      //    cell.CommandButton.Enabled = false;
                      //}
                  }
                  if (e.Column.Name.Equals("Anular"))
                  {
                      RadButtonElement bte = (RadButtonElement)e.CellElement.Children[0];
                      if (bte.Image == null)
                      {
                          bte.TextImageRelation = TextImageRelation.Overlay;
                          bte.DisplayStyle = DisplayStyle.Image;
                          bte.ImageAlignment = ContentAlignment.MiddleCenter;
                          bte.Image = Resources.Sign_09;
                          bte.ToolTipText = "Anular Cotización";
                          bte.AutoSize = true;
                      }
                      //GridCommandCellElement cell = (GridCommandCellElement)e.CellElement;
                      //if (cell.RowInfo.Cells["CONS_CodEstadosTR"].Value != null && cell.RowInfo.Cells["CONS_CodEstadosTR"].Value == "ANULADA")
                      //{
                      //    cell.CommandButton.Enabled = true;
                      //}
                      //else
                      //{
                      //    cell.CommandButton.Enabled = false;
                      //}
                  }
                  if (e.CellElement.RowInfo is GridViewNewRowInfo && e.CellElement.ColumnInfo is GridViewCommandColumn)
                  {
                      ((RadButtonElement)e.CellElement.Children[0]).Visibility = ElementVisibility.Hidden;
                  }
              }
          }
          catch (Exception ex) { Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al formatear el icono." + ex.Message); }
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
