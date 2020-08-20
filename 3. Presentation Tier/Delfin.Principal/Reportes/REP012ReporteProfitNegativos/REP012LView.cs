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
using Infrastructure.WinForms.Controls;

namespace Delfin.Principal
{
    public partial class REP012LView : UserControl, IREP012LView
    {
        #region [ Variables ]

        #endregion

        #region [ Formulario ]
        public REP012LView(Telerik.WinControls.UI.RadPageViewPage x_tabPageControl)
        {
            InitializeComponent();
            try
            {
                TabPageControl = x_tabPageControl;

                txtCCOT_NumDoc.MaxLength = 20;
                txtDOOV_HBL.MaxLength = 50;
                btnBuscar.Click += new EventHandler(btnBuscar_Click);
                btnDeshacer.Click += new EventHandler(btnDeshacer_Click);
                btnExportar.Click += new EventHandler(btnExportar_Click);

                TitleView.FormClose += new EventHandler(View_FormClose);

                BSItems = new BindingSource();

            }
            catch (Exception ex)
            { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al crear la vista.", ex); }
        }

        #endregion

        #region [ Propiedades ]
        public Telerik.WinControls.UI.RadPageViewPage TabPageControl { get; set; }
        public Image IconView { get { return TitleView.FormIcon; } set { TitleView.FormIcon = value; } }
        public REP012Presenter Presenter { get; set; }
        public BindingSource BSItems { get; set; }
        #endregion

        #region [ IREP012LView ]
        public void LoadView()
        {
            try
            {
                ayudaENTC_Transportista.ContainerService = Presenter.ContainerService;
                ayudaENTC_Ejecutivo.ContainerService = Presenter.ContainerService;
                ayudaENTC_Cliente.ContainerService = Presenter.ContainerService;
                ayudaENTC_Transportista.TipoEntidad = Delfin.Controls.TiposEntidad.TIPE_Transportista;
                ayudaENTC_Ejecutivo.TipoEntidad = Delfin.Controls.TiposEntidad.TIPE_Ejecutivo;
                ayudaENTC_Cliente.TipoEntidad = Delfin.Controls.TiposEntidad.TIPE_Cliente;

                grdItems.Enabled = false;
                //FormatDataGrid();
            }
            catch (Exception ex)
            { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error cargando la vista.", ex); }
        }
        public void ShowItems()
        {
            try
            {

                grdItems.ShowFilteringRow = false;
                grdItems.EnableFiltering = false;
                grdItems.MasterTemplate.EnableFiltering = false;
                grdItems.EnableGrouping = false;
                grdItems.MasterTemplate.EnableGrouping = false;
                grdItems.EnableSorting = false;
                grdItems.MasterTemplate.EnableCustomSorting = false;

                grdItems.AutoGenerateColumns = false;
                grdItems.AllowAddNewRow = false;
                grdItems.AllowDeleteRow = false;
                grdItems.AllowRowResize = false;
                grdItems.AllowEditRow = true;

                grdItems.DataSource = null;
                BSItems.DataSource = null;
                grdItems.Columns.Clear();
                grdItems.BestFitColumns();
                BSItems.ResetBindings(true);

                BSItems.DataSource = Presenter.DTReporte;
                grdItems.DataSource = BSItems;
                BSItems.ResetBindings(true);

                grdItems.ClipboardCopyMode = GridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;
                grdItems.SelectionMode = GridViewSelectionMode.FullRowSelect;
                grdItems.MultiSelect = true;

            }
            catch (Exception ex)
            { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error cargando los items.", ex); }
        }
        public void ShowItems(System.Data.DataTable dt)
        {
            try
            {
                BSItems.DataSource = dt;
                grdItems.DataSource = BSItems;
                navItemsReport.BindingSource = BSItems;
                BSItems.ResetBindings(true);
                if (grdItems.RowCount > 0)
                {
                    grdItems.Enabled = true;
                    btnExportar.Enabled = true;
                    Infrastructure.WinForms.Controls.GridAutoFit.Fit2(grdItems);
                    this.grdItems.AutoGenerateColumns = true; // LLenar la grilla segun el DataTable

                }
                else
                {
                    grdItems.Enabled = false;
                    btnExportar.Enabled = false;
                }

                this.grdItems.AllowEditRow = false;
                this.grdItems.ShowFilteringRow = true;
                this.grdItems.EnableFiltering = true;
                this.grdItems.MasterTemplate.EnableFiltering = true;
                this.grdItems.EnableGrouping = false;
                this.grdItems.MasterTemplate.EnableGrouping = false;
                this.grdItems.EnableSorting = false;
                this.grdItems.MasterTemplate.EnableCustomSorting = false;
                this.grdItems.ReadOnly = false;


            }
            catch (Exception ex)
            { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error cargando los items.", ex); }
        }
        #endregion

        #region [ Metodos ]

        private void Buscar()
        {
            try
            {
                String _mensaje = "";
                if (!String.IsNullOrEmpty(txtCCOT_NumDoc.Text) || !String.IsNullOrEmpty(txtDOOV_HBL.Text) || mdtCCOT_FecIniConcluye.NSFecha != null || mdtCCOT_FecFinConcluye.NSFecha != null)
                {
                    String _nro_hbl = null;
                    String _nro_ordenventa = null;
                    Nullable<DateTime> _fec_ini_concluye = null;
                    Nullable<DateTime> _fec_fin_concluye = null;
                    Nullable<Int32> _codigo_transportista = null;
                    Nullable<Int32> _codigo_ejecutivo = null;
                    Nullable<Int32> _codigo_cliente = null;

                    _fec_ini_concluye = mdtCCOT_FecIniConcluye.NSFecha;
                    _fec_fin_concluye = mdtCCOT_FecFinConcluye.NSFecha;
                    if (!String.IsNullOrEmpty(txtDOOV_HBL.Text))
                    { _nro_hbl = txtDOOV_HBL.Text; }
                    if (!String.IsNullOrEmpty(txtCCOT_NumDoc.Text))
                    { _nro_ordenventa = txtCCOT_NumDoc.Text; }
                    if (ayudaENTC_Transportista.Value != null)
                    { _codigo_transportista = ayudaENTC_Transportista.Value.ENTC_Codigo; }
                    if (ayudaENTC_Ejecutivo.Value != null)
                    { _codigo_ejecutivo = ayudaENTC_Ejecutivo.Value.ENTC_Codigo; }
                    if (ayudaENTC_Cliente.Value != null)
                    { _codigo_cliente = ayudaENTC_Cliente.Value.ENTC_Codigo; }

                    Presenter.CargarReporte(_fec_ini_concluye, _fec_fin_concluye, _nro_hbl, _nro_ordenventa, _codigo_transportista, _codigo_ejecutivo, _codigo_cliente);
                }
                else
                {
                    _mensaje += "* Fecha de Inicio de Concluye" + Environment.NewLine;
                    _mensaje += "* Fecha de Fin de Concluye" + Environment.NewLine;
                    _mensaje += "* Nro. MBL" + Environment.NewLine;
                    _mensaje += "* Nro. OV's" + Environment.NewLine;
                    Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion("Filtros del Reportes", "Debe ingresar un valor en cualquiera de las siguientes opciones: (Ver Detalles).", _mensaje);
                }
            }
            catch (Exception ex)
            { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al llamar al reporte.", ex); }
        }
        private void Deshacer()
        {
            try
            {
                Presenter.LimpiarReporte();

                txtCCOT_NumDoc.Text = string.Empty;
                txtDOOV_HBL.Text = string.Empty;
                mdtCCOT_FecIniConcluye.NSFecha = null;
                mdtCCOT_FecFinConcluye.NSFecha = null;
                ayudaENTC_Transportista.ClearValue();
                ayudaENTC_Transportista.Text = string.Empty;
                ayudaENTC_Ejecutivo.ClearValue();
                ayudaENTC_Ejecutivo.Text = string.Empty;
                ayudaENTC_Cliente.ClearValue();
                ayudaENTC_Cliente.Text = string.Empty;

                BSItems.DataSource = null;
                grdItems.DataSource = BSItems;
                BSItems.ResetBindings(true);

                grdItems.Enabled = false;
                navItemsReport.BindingSource = BSItems;

                btnBuscar.Enabled = true;
                btnExportar.Enabled = false;
            }
            catch (Exception ex)
            { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al limpiar al reporte.", ex); }
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

        ToolStripMenuItem tsmTodos;
        String[] defaultColumns;
        public void FormatDataGrid()
        {
            try
            {
                Telerik.WinControls.UI.Localization.RadGridLocalizationProvider.CurrentProvider = new Infrastructure.WinForms.Controls.MySpanishRadGridLocalizationProvider();
                this.grdItems.Columns.Clear();
                this.grdItems.AllowAddNewRow = false;

                this.grdItems.Columns.Clear();
                this.grdItems.AllowAddNewRow = false;
                this.grdItems.AllowDeleteRow = false;
                this.grdItems.AutoGenerateColumns = true;
                this.grdItems.AllowColumnReorder = false;
                this.grdItems.AllowRowResize = false;
                this.grdItems.AllowRowReorder = false;
                this.grdItems.AllowColumnHeaderContextMenu = false;
                this.grdItems.AllowCellContextMenu = false;
                this.grdItems.AllowMultiColumnSorting = false;
                //this.grdItems.AllowEditRow = true;
                this.grdItems.ReadOnly = true;



            }
            catch (Exception ex)
            { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, Infrastructure.Aspect.Constants.Mensajes.FormatDataGridView, ex); }
        }
        #endregion

        #region [ Eventos ]
        private void btnBuscar_Click(object sender, EventArgs e)
        { Buscar(); }
        private void btnDeshacer_Click(object sender, EventArgs e)
        { Deshacer(); }
        private void btnExportar_Click(object sender, EventArgs e)
        { Exportar(); }

        #endregion

        #region [ IFormClose ]
        private void View_FormClose(object sender, EventArgs e)
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
