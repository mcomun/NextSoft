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
   public partial class CAJ007ExportacionBancosLView : UserControl, ICAJ007ExportacionBancosLView
   {
      #region [ Variables ]
      //private String m_sortColumnName;
      //private Boolean m_sortAscending = false;
      #endregion

      #region [ Formulario ]
      public CAJ007ExportacionBancosLView(Telerik.WinControls.UI.RadPageViewPage x_tabPageControl)
      {
         InitializeComponent();
         try
         {
            TabPageControl = x_tabPageControl;

            btnNuevo.Click += new EventHandler(btnNuevo_Click);
            btnExportar.Click += new EventHandler(btnExportar_Click);
            btnBuscar.Click+=btnBuscar_Click;

            BSItems = new BindingSource();
            BSItems.CurrentItemChanged += new EventHandler(BSItems_CurrentItemChanged);

            grdItems.CommandCellClick += grdItems_CommandCellClick;
            grdItems.CellFormatting += grdItems_CellFormatting;

            TitleView.FormClose += new EventHandler(TitleView_FormClose);
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error inicializando el formulario LView.", ex); }
      }
      #endregion

      #region [ Propiedades ]
      public Telerik.WinControls.UI.RadPageViewPage TabPageControl { get; set; }
      public Image IconView { get { return TitleView.FormIcon; } set { TitleView.FormIcon = value; } }
      public CAJ007ExportacionBancosPresenter Presenter { get; set; }
      public BindingSource BSItems { get; set; }
      #endregion

      #region [ ICAJ007ExportacionBancosLView ]
      public void LoadView()
      {
         try
         {
            TitleView.Caption = Presenter.Title;

            FormatDataGrid();

            grdItems.Enabled = false;
            btnNuevo.Enabled = true;
            btnExportar.Enabled = false;

            dtpFecIni.NSFecha = new DateTime(Presenter.Fecha.Year, Presenter.Fecha.Month, 1);
            dtpFecFin.NSFecha = dtpFecIni.NSFecha.Value.AddMonths(1).AddDays(-1);
            
            SeleccionarItem();

            if (!String.IsNullOrEmpty(Presenter.MensajeError)) { btnNuevo.Enabled = false; }
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
            grdItems.Enabled = grdItems.RowCount > 0;
            grdItems.ShowFilteringRow = false;
            grdItems.EnableFiltering = true;
            grdItems.MasterTemplate.EnableFiltering = true;
            grdItems.EnableGrouping = false;
            grdItems.MasterTemplate.EnableGrouping = false;
            grdItems.EnableSorting = true;
            grdItems.MasterTemplate.EnableCustomSorting = true;
            grdItems.BestFitColumns();

            btnExportar.Enabled = grdItems.Enabled;
            
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

            GridViewCommandColumn commandColumn;
            commandColumn = new GridViewCommandColumn();
            commandColumn.Name = "Edit";
            commandColumn.HeaderText = "Revisar";
            commandColumn.DefaultText = "Ver";
            commandColumn.UseDefaultText = true;
            this.grdItems.Columns.Add(commandColumn);
            this.grdItems.Columns["Edit"].AllowSort = false;
            this.grdItems.Columns["Edit"].AllowFiltering = false;

            commandColumn = new GridViewCommandColumn();
            commandColumn.Name = "Print";
            commandColumn.HeaderText = "Imprimir";
            commandColumn.DefaultText = "Imprimir";
            commandColumn.UseDefaultText = true;
            this.grdItems.Columns.Add(commandColumn);
            this.grdItems.Columns["Print"].AllowSort = false;
            this.grdItems.Columns["Print"].AllowFiltering = false;

            //commandColumn = new GridViewCommandColumn();
            //commandColumn.Name = "Delete";
            //commandColumn.HeaderText = "Eliminar";
            //commandColumn.DefaultText = "Eliminar";
            //commandColumn.UseDefaultText = true;
            //this.grdItems.Columns.Add(commandColumn);
            //this.grdItems.Columns["Delete"].AllowSort = false;
            //this.grdItems.Columns["Delete"].AllowFiltering = false;

            this.grdItems.Columns.Add("PLAN_Codigo", "Interno", "PLAN_Codigo");
            this.grdItems.Columns.Add("PLAN_FechaEmision", "Fecha", "PLAN_FechaEmision");
            this.grdItems.Columns["PLAN_FechaEmision"].FormatString = "{0:dd/MM/yyyy}";
            this.grdItems.Columns.Add("TIPO_MND", "Moneda", "TIPO_MND");
            this.grdItems.Columns.Add("Monto", "Monto", "Monto");
            this.grdItems.Columns["Monto"].FormatString = "{0:#,###,##0.00}";
            this.grdItems.Columns["Monto"].TextAlignment = ContentAlignment.MiddleRight;
            this.grdItems.Columns.Add("CUBA_NroCuenta", "Nro. Cuenta", "CUBA_NroCuenta");
            this.grdItems.Columns.Add("TIPO_BCO", "Entidad Bancaria", "TIPO_BCO");
            this.grdItems.Columns.Add("PLAN_Concepto", "Concepto", "PLAN_Concepto");
            this.grdItems.Columns.Add("AsientoCaja", "Asientos Generados", "AsientoCaja");
            this.grdItems.Columns.Add("CONS_EST", "Estado", "CONS_EST");
            //this.grdItems.Columns.Add("Documentos", "Documentos", "Documentos");
            
            //this.grdItems.Columns.Add("Total", "Total", "Total");

            grdItems.BestFitColumns();

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

      private void SeleccionarItem()
      {
         try
         {
            if (Presenter != null)
            {
               if (BSItems != null && BSItems != null && BSItems.DataSource != null && BSItems.Current != null && BSItems.Current is Entities.Planillas)
               {
                  Presenter.Item = ((Entities.Planillas)BSItems.Current);
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
            getFiltros();
            if (Presenter.F_FecIni.HasValue && Presenter.F_FecFin.HasValue)
            { Presenter.Actualizar(); }
            else { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Presenter.Title, "Debe ingresar la fechas para realizar la busqueda."); }
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al buscar.", ex); }
      }
      private void getFiltros()
      {
         try
         {
            Presenter.F_FecIni = null; if (dtpFecIni.NSFecha.HasValue) { Presenter.F_FecIni = dtpFecIni.NSFecha; }
            Presenter.F_FecFin = null; if (dtpFecFin.NSFecha.HasValue) { Presenter.F_FecFin = dtpFecFin.NSFecha; }

         }
         catch (Exception)
         { }
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

            grdItems.Enabled = true;
            btnNuevo.Enabled = true;
            btnExportar.Enabled = false;
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
                  case "Ver":
                     SeleccionarItem();
                     Presenter.Editar();
                     break;
                  case "Eliminar":
                     SeleccionarItem();
                     Presenter.Eliminar();
                     break;
                  case "Imprimir":
                     SeleccionarItem();
                     Presenter.Imprimir();
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
                     bte.Image = Resources.folder_view_16x16;
                     bte.ToolTipText = @"Editar Planilla";
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
                     bte.Image = Resources.delete1;
                     bte.ToolTipText = @"Eliminar Planilla";
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
                     bte.ToolTipText = @"Imprimir Planilla";
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
