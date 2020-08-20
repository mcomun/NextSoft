using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Delfin.Principal.Properties;
using Infrastructure.WinForms.Controls;
using Telerik.WinControls;
using Telerik.WinControls.UI;

namespace Delfin.Principal
{
   public partial class MAN005LView : UserControl, IMAN005LView
   {
      #region [ Variables ]

      #endregion

      #region [ Formulario ]
      public MAN005LView(Telerik.WinControls.UI.RadPageViewPage x_tabPageControl)
      {
         InitializeComponent();
         try
         {
            TabPageControl = x_tabPageControl;

            btnMAN_Nuevo.Click += new EventHandler(btnNuevo_Click);
            btnMAN_Buscar.Click += new EventHandler(btnBuscar_Click);
            btnMAN_Exportar.Click += new EventHandler(btnExportar_Click);
            btnMAN_Deshacer.Click += new EventHandler(btnDeshacer_Click);

            BSItems = new BindingSource();
            BSItems.CurrentItemChanged += new EventHandler(BSItems_CurrentItemChanged);

            grdItems.CommandCellClick += new Telerik.WinControls.UI.CommandCellClickEventHandler(grdItems_CommandCellClick);
            grdItems.CellFormatting += grdItems_CellFormatting;
            TitleView.FormClose += new EventHandler(TitleView_FormClose);
         }
         catch (Exception)
         { }
      }
      #endregion

      #region [ Propiedades ]
      public Telerik.WinControls.UI.RadPageViewPage TabPageControl { get; set; }
      public Image IconView { get { return TitleView.FormIcon; } set { TitleView.FormIcon = value; } }
      public MAN005Presenter Presenter { get; set; }
      public BindingSource BSItems { get; set; }
      #endregion

      #region [ IMAN005LView ]
      public void LoadView()
      {
         try
         {
            Presenter.getEntidadtransportista();
            cmbENTC_NombreCompleto.DataSource = Presenter.listEntidad;
            cmbENTC_NombreCompleto.ValueMember = "ENTC_Codigo";
            cmbENTC_NombreCompleto.DisplayMember = "ENTC_NombreCompleto";

            BSItems.DataSource = null;
            grdItems.DataSource = BSItems;
            navItems.BindingSource = BSItems;
            BSItems.ResetBindings(true);

            FormatDataGrid();

            grdItems.Enabled = false;
            btnMAN_Nuevo.Enabled = true;
            btnMAN_Buscar.Enabled = true;
            btnMAN_Exportar.Enabled = false;
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
               btnMAN_Exportar.Enabled = true;
               Infrastructure.WinForms.Controls.GridAutoFit.Fit(this.grdItems);
            }
            else
            {
               grdItems.Enabled = false;
               btnMAN_Exportar.Enabled = false;
            }
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
            commandColumn.Name = "Delete";
            commandColumn.HeaderText = "Eliminar";
            commandColumn.DefaultText = "Eliminar";
            commandColumn.UseDefaultText = true;
            this.grdItems.Columns.Add(commandColumn);
            this.grdItems.Columns["Delete"].AllowSort = false;
            this.grdItems.Columns["Delete"].AllowFiltering = false;
            this.grdItems.Columns.Add("CONT_Numero", "Número de Contrato", "CONT_Numero");
            this.grdItems.Columns.Add("CONT_Descrip", "Descripción", "CONT_Descrip");
            this.grdItems.Columns.Add("CONT_FecEmi", "Fecha de Emición", "CONT_FecEmi");
            this.grdItems.Columns.Add("CONT_FecIni", "Fecha de Inicio", "CONT_FecIni");
            this.grdItems.Columns.Add("CONT_FecFin", "Fecha Fin", "CONT_FecFin");
           

            grdItems.BestFitColumns();

            tsmColumnas.DropDownItems.Clear();
            defaultColumns = new string[grdItems.Columns.Count];
            int index = 0;
            foreach (Telerik.WinControls.UI.GridViewDataColumn column in grdItems.Columns)
            {
               ToolStripMenuItem _item = new ToolStripMenuItem(column.HeaderText);
               _item.Tag = column.Name;
               _item.Checked = column.IsVisible;
               _item.CheckOnClick = true;
               _item.Click += new EventHandler(tsmColumna_Click);
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
            tsmTodos.Click += new EventHandler(tsmTodos_Click);
            tsmColumnas.DropDownItems.Add(tsmTodos);

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
               if (BSItems != null && BSItems.Current != null && BSItems.Current is Entities.Contrato)
               { Presenter.Item = ((Entities.Contrato)BSItems.Current); }
               else
               { Presenter.Item = null; }
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
            Presenter.Actualizar();
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

            grdItems.Enabled = true;
            btnMAN_Nuevo.Enabled = true;
            btnMAN_Buscar.Enabled = true;
            btnMAN_Exportar.Enabled = false;
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
      private void grdItems_CommandCellClick(object sender, EventArgs e)
      {
         try
         {
            if (sender is Telerik.WinControls.UI.GridCommandCellElement)
            {
               switch ((((Telerik.WinControls.UI.GridCommandCellElement)(sender)).CommandButton).TextElement.Text)
               {
                  case "Editar":
                     Presenter.Editar();
                     break;
                  case "Eliminar":
                     Presenter.Eliminar();
                     break;
               }
            }
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al cargar los botones para editar y eliminar.", ex); }
      
         }
         private void cmbENTC_Transportista_Click(object sender, EventArgs e)
      {
         Presenter.entc_codtransportista = Convert.ToInt32( cmbENTC_NombreCompleto.SelectedValue) ;
      
      }
         void grdItems_CellFormatting(object sender, CellFormattingEventArgs e)
         {
             try
             {
                 if (e.CellElement is GridCommandCellElement)
                 {
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
                     if (e.Column.Name.Equals("Delete"))
                     {
                         var bte = (RadButtonElement)e.CellElement.Children[0];
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
                         e.CellElement.Children[0].Visibility = ElementVisibility.Hidden;
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
            //BusinessLogic.Colecciones.Inicializar(Presenter.Container);
            CloseForm(null, new Infrastructure.Client.FormClose.FormCloseEventArgs(this.TabPageControl, Presenter.CUS));
         }
      }
      public event Infrastructure.Client.FormClose.FormCloseEventArgs.FormCloseEventHandler CloseForm;
      #endregion
   }
}
