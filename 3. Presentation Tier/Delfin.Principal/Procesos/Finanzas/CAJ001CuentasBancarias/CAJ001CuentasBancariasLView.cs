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
using Delfin.Principal.Properties;
using Telerik.WinControls.UI;
using Telerik.WinControls;

namespace Delfin.Principal
{
   public partial class CAJ001CuentasBancariasLView : UserControl, ICAJ001CuentasBancariasLView
   {
      #region [ Variables ]
      //private String m_sortColumnName;
      //private Boolean m_sortAscending = false;
      #endregion

      #region [ Formulario ]
      public CAJ001CuentasBancariasLView(Telerik.WinControls.UI.RadPageViewPage x_tabPageControl)
      {
         InitializeComponent();
         try
         {
            TabPageControl = x_tabPageControl;

            btnNuevo.Click += new EventHandler(btnNuevo_Click);
            btnBuscar.Click += new EventHandler(btnBuscar_Click);
            btnExportar.Click += new EventHandler(btnExportar_Click);
            btnDeshacer.Click += new EventHandler(btnDeshacer_Click);

            BSItems = new BindingSource();
            BSItems.CurrentItemChanged += new EventHandler(BSItems_CurrentItemChanged);

            grdItems.CommandCellClick += grdItems_CommandCellClick;
            grdItems.CellFormatting += grdItems_CellFormatting;

            txtCUBA_Codigo.MaxLength = 3;

            comboBox1.Visible = false;
            label3.Visible = false;

            TitleView.FormClose += new EventHandler(TitleView_FormClose);
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error inicializando el formulario LView.", ex); }
      }
      #endregion

      #region [ Propiedades ]
      public Telerik.WinControls.UI.RadPageViewPage TabPageControl { get; set; }
      public Image IconView { get { return TitleView.FormIcon; } set { TitleView.FormIcon = value; } }
      public CAJ001CuentasBancariasPresenter Presenter { get; set; }
      public BindingSource BSItems { get; set; }
      #endregion

      #region [ CAJ001LView ]
      public void LoadView()
      {
         try
         {
            FormatDataGrid();

            grdItems.Enabled = false;
            btnNuevo.Enabled = true;
            btnBuscar.Enabled = true;
            btnExportar.Enabled = false;

            cmbCUBA_TipoCuenta.LoadControl("Tipo de Cuenta", Delfin.Controls.Tipos.ComboBoxConstantes.OConstantes.TipoCuenta, "< Seleccionar Tipo de Cuenta >", ListSortDirection.Ascending);

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
               //btnExportar.Enabled = true;
               Infrastructure.WinForms.Controls.GridAutoFit.Fit(this.grdItems);
            }
            else
            {
               grdItems.Enabled = false;
               btnExportar.Enabled = false;
               //btnExportar.Enabled = false;
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
      /// <summary>
      /// Dar Formato a la Grilla
      /// </summary>
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

            commandColumn = new GridViewCommandColumn();
            commandColumn.Name = "Delete";
            commandColumn.HeaderText = "Eliminar";
            commandColumn.DefaultText = "Eliminar";
            commandColumn.UseDefaultText = true;
            this.grdItems.Columns.Add(commandColumn);
            this.grdItems.Columns["Delete"].AllowSort = false;
            this.grdItems.Columns["Delete"].AllowFiltering = false;

            this.grdItems.Columns.Add("CUBA_Codigo", "Código", "CUBA_Codigo");
            this.grdItems.Columns.Add("TipoCuenta", "Tipo de Cuenta", "TipoCuenta");
            this.grdItems.Columns.Add("CUBA_NroCuenta", "Número de Cuenta", "CUBA_NroCuenta");
            this.grdItems.Columns.Add("TIPO_MND", "Moneda", "TIPO_MND");
            this.grdItems.Columns.Add("TIPO_BCO", "Banco", "TIPO_BCO");
            
            this.grdItems.Columns.Add("CUBA_Descripcion", "Descripción", "CUBA_Descripcion");

            Telerik.WinControls.UI.GridViewCheckBoxColumn _CUBA_Bloqueo = new Telerik.WinControls.UI.GridViewCheckBoxColumn();
            _CUBA_Bloqueo.Name = "CUBA_Bloqueo";
            _CUBA_Bloqueo.HeaderText = "Bloqueo";
            _CUBA_Bloqueo.FieldName = "CUBA_Bloqueo";
            this.grdItems.Columns.Add(_CUBA_Bloqueo);

            Telerik.WinControls.UI.GridViewCheckBoxColumn _CUBA_PermChequeBlanco = new Telerik.WinControls.UI.GridViewCheckBoxColumn();
            _CUBA_PermChequeBlanco.Name = "CUBA_PermChequeBlanco";
            _CUBA_PermChequeBlanco.HeaderText = "Permitir Cheque en Blanco";
            _CUBA_PermChequeBlanco.FieldName = "CUBA_PermChequeBlanco";
            this.grdItems.Columns.Add(_CUBA_PermChequeBlanco);

            Telerik.WinControls.UI.GridViewCheckBoxColumn _CheckBox = new Telerik.WinControls.UI.GridViewCheckBoxColumn();
            
            this.grdItems.Columns.Add("CUBA_CuenContable", "Cta. Contable", "CUBA_CuenContable");
            this.grdItems.Columns.Add("CUBA_CuenPuente", "Cta. Puente", "CUBA_CuenPuente");

            _CheckBox = new Telerik.WinControls.UI.GridViewCheckBoxColumn();
            _CheckBox.Name = "CUBA_CtaEmprVinculada";
            _CheckBox.HeaderText = "Empr. Vinculada";
            _CheckBox.FieldName = "CUBA_CtaEmprVinculada";
            this.grdItems.Columns.Add(_CheckBox);

            _CheckBox = new Telerik.WinControls.UI.GridViewCheckBoxColumn();
            _CheckBox.Name = "CUBA_PermImprAutomatica";
            _CheckBox.HeaderText = "Impr. Automática";
            _CheckBox.FieldName = "CUBA_PermImprAutomatica";
            this.grdItems.Columns.Add(_CheckBox);

            _CheckBox = new Telerik.WinControls.UI.GridViewCheckBoxColumn();
            _CheckBox.Name = "CUBA_MedioVirtual";
            _CheckBox.HeaderText = "Medio Virtual";
            _CheckBox.FieldName = "CUBA_MedioVirtual";
            this.grdItems.Columns.Add(_CheckBox);

            _CheckBox = new Telerik.WinControls.UI.GridViewCheckBoxColumn();
            _CheckBox.Name = "CUBA_InscritoSOL";
            _CheckBox.HeaderText = "Detracciones";
            _CheckBox.FieldName = "CUBA_InscritoSOL";
            this.grdItems.Columns.Add(_CheckBox);

            this.grdItems.Columns.Add("SUCR_Desc", "Sucursal", "SUCR_Desc");
            this.grdItems.Columns.Add("CUBA_FechaCierre", "Fecha Cierre", "CUBA_FechaCierre");

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
               if (BSItems != null && BSItems != null && BSItems.DataSource != null && BSItems.Current != null && BSItems.Current is Entities.CuentasBancarias)
               {
                  Presenter.Item = ((Entities.CuentasBancarias)BSItems.Current);
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
            Presenter.CUBA_Codigo = (!String.IsNullOrEmpty(txtCUBA_Codigo.Text) ? txtCUBA_Codigo.Text : null);
            Presenter.CUBA_TipoCuenta = cmbCUBA_TipoCuenta.ConstantesSelectedValue;
            Presenter.FecIni = mdtCUBA_FechaCierreIni.NSFecha;
            Presenter.FecFin = mdtCUBA_FechaCierreFin.NSFecha;
            Presenter.CUBA_Bloqueo = chkCUBA_Bloqueo.Checked;
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
             Titulos.Add(Presenter.Title);
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
            grdItems.Enabled = false;
            navItems.BindingSource = BSItems;
            BSItems.ResetBindings(true);
            btnExportar.Enabled = false;

            btnNuevo.Enabled = true;
            btnBuscar.Enabled = true;
            //btnExportar.Enabled = false;

            txtCUBA_Codigo.Text = String.Empty;
            cmbCUBA_TipoCuenta.SelectedIndex = 0;
            mdtCUBA_FechaCierreIni.NSFecha = null;
            mdtCUBA_FechaCierreFin.NSFecha = null;
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
         catch (Exception ex) { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al formatear el icono." + ex.Message); }
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
