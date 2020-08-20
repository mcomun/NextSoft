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
    public partial class REP011LView : UserControl, IREP011LView
    {
        #region [ Variables ]

        #endregion

        #region [ Formulario ]
        public REP011LView(Telerik.WinControls.UI.RadPageViewPage x_tabPageControl)
        {
            InitializeComponent();
            try
            {
                TabPageControl = x_tabPageControl;

                cmbCONS_CodRGM.SelectedIndexChanged += cmbCONS_CodRGM_SelectedIndexChanged;

                btnBuscar.Click += new EventHandler(btnBuscar_Click);
                btnDeshacer.Click += new EventHandler(btnDeshacer_Click);
                btnExportar.Click += new EventHandler(btnExportar_Click);

                TitleView.FormClose += new EventHandler(View_FormClose);

                BSItems = new BindingSource();
                rbtnGeneral.Checked = true;
                rbtnDetallado.Checked = false;
            }
            catch (Exception ex)
            { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al crear la vista.", ex); }
        }

        #endregion

        #region [ Propiedades ]
        public Telerik.WinControls.UI.RadPageViewPage TabPageControl { get; set; }
        public Image IconView { get { return TitleView.FormIcon; } set { TitleView.FormIcon = value; } }
        public REP011Presenter Presenter { get; set; }
        public BindingSource BSItems { get; set; }
        #endregion

        #region [ IREP011LView ]
        public void LoadView()
        {
            try
            {
                ayudaENTC_Transportista.ContainerService = Presenter.ContainerService;
                ayudaENTC_Vendedor.ContainerService = Presenter.ContainerService;
                ayudaENTC_Deposito.ContainerService = Presenter.ContainerService;
                ayudaENTC_Transportista.TipoEntidad = Delfin.Controls.TiposEntidad.TIPE_Cliente;
                ayudaENTC_Vendedor.TipoEntidad = Delfin.Controls.TiposEntidad.TIPE_Ejecutivo;
                ayudaENTC_Deposito.TipoEntidad = Delfin.Controls.TiposEntidad.TIPE_DepositoTemporal;

                cmbCONS_CodRGM.LoadControl(Presenter.ContainerService, "Tabla de Regimen", "RGM", "< Seleccionar Regimen >", ListSortDirection.Ascending);
                ShowComboNaves();
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
                if (cmbCONS_CodRGM.ConstantesSelectedItem != null)
                {
                    String _cons_tabrgm = cmbCONS_CodRGM.ConstantesSelectedItem.CONS_CodTabla;
                    String _cons_codrgm = cmbCONS_CodRGM.ConstantesSelectedItem.CONS_CodTipo;
                    String _nro_viaje = null;
                    Nullable<DateTime> _fec_ini_embarque = null;
                    Nullable<DateTime> _fec_fin_embarque = null;
                    Nullable<DateTime> _fec_ini_eta = null;
                    Nullable<DateTime> _fec_fin_eta = null;
                    Nullable<DateTime> _fec_ini_zarpe = null;
                    Nullable<DateTime> _fec_fin_zarpe = null;
                    Nullable<Int32> _codigo_transportista = null;
                    Nullable<Int32> _codigo_vendedor = null;
                    Nullable<Int32> _codigo_deposito = null;
                    Nullable<Int16> _codigo_nave = null;

                    if (!String.IsNullOrEmpty(txtNVIA_NroViaje.Text))
                    { _nro_viaje = txtNVIA_NroViaje.Text; }
                    if (cmbCONS_CodRGM.ConstantesSelectedItem.CONS_CodTipo == Delfin.Controls.variables.CONSRGM_Importacion)
                    {
                        _fec_ini_eta = mdtNVIA_FechaIniEtaZarpe.NSFecha;
                        _fec_fin_eta = mdtNVIA_FechaFinEtaZarpe.NSFecha;
                    }
                    if (cmbCONS_CodRGM.ConstantesSelectedItem.CONS_CodTipo == Delfin.Controls.variables.CONSRGM_Exportacion)
                    {
                        _fec_ini_zarpe = mdtNVIA_FechaIniEtaZarpe.NSFecha;
                        _fec_fin_zarpe = mdtNVIA_FechaFinEtaZarpe.NSFecha;
                    }
                    _fec_ini_embarque = mdtCCOT_FecIniEmbarque.NSFecha;
                    _fec_fin_embarque = mdtCCOT_FecFinEmbarque.NSFecha;
                    if (ayudaENTC_Transportista.Value != null)
                    { _codigo_transportista = ayudaENTC_Transportista.Value.ENTC_Codigo; }
                    if (ayudaENTC_Vendedor.Value != null)
                    { _codigo_vendedor = ayudaENTC_Vendedor.Value.ENTC_Codigo; }
                    if (ayudaENTC_Deposito.Value != null)
                    { _codigo_deposito = ayudaENTC_Deposito.Value.ENTC_Codigo; }
                    Int16 _codigoNave;
                    if (NAVE_Codigo.SelectedValue != null && Int16.TryParse(NAVE_Codigo.SelectedValue.ToString(), out _codigoNave))
                    {
                        if (NAVE_Codigo.SelectedValue.ToString() != "-1")
                        { _codigo_nave = Convert.ToInt16(NAVE_Codigo.SelectedValue.ToString()); }
                        else
                        { _codigo_nave = null; }
                    }
                    else
                    { _codigo_nave = null; }

                    Presenter.CargarReporte(_cons_tabrgm, _cons_codrgm, _nro_viaje, _fec_ini_eta, _fec_fin_eta, _fec_ini_zarpe, _fec_fin_zarpe, _fec_ini_embarque, _fec_fin_embarque, _codigo_transportista, _codigo_vendedor, _codigo_deposito, _codigo_nave, rbtnDetallado.Checked);
                }
                else
                { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Presenter.Title, "Debe seleccionar el Régimen."); }
            }
            catch (Exception ex)
            { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al llamar al reporte.", ex); }
        }
        private void Deshacer()
        {
            try
            {
                Presenter.LimpiarReporte();

                cmbCONS_CodRGM.SelectedIndex = 0;
                txtNVIA_NroViaje.Text = string.Empty;
                mdtNVIA_FechaFinEtaZarpe.NSFecha = null;
                mdtNVIA_FechaIniEtaZarpe.NSFecha = null;
                mdtCCOT_FecIniEmbarque.NSFecha = null;
                mdtCCOT_FecFinEmbarque.NSFecha = null;
                ayudaENTC_Transportista.ClearValue();
                ayudaENTC_Transportista.Text = string.Empty;
                ayudaENTC_Vendedor.ClearValue();
                ayudaENTC_Vendedor.Text = string.Empty;
                ayudaENTC_Deposito.ClearValue();
                ayudaENTC_Deposito.Text = string.Empty;

                BSItems.DataSource = null;
                grdItems.DataSource = BSItems;
                BSItems.ResetBindings(true);

                grdItems.Enabled = false;
                navItemsReport.BindingSource = BSItems;

                btnBuscar.Enabled = true;
                btnExportar.Enabled = false;
                NAVE_Codigo.SelectedIndex = 0;
            }
            catch (Exception ex)
            { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al limpiar al reporte.", ex); }
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
        private void ShowComboNaves()
        {
            NAVE_Codigo.ValueMember = "NAVE_Codigo";
            NAVE_Codigo.DisplayMember = "NAVE_Nombre";

            Entities.Nave naveEmpty = new Entities.Nave();
            naveEmpty.NAVE_Codigo = -1;
            naveEmpty.NAVE_Nombre = "<Todos>";
            ObservableCollection<Entities.Nave> naves = Presenter.ItemsNave;
            naves.Insert(0, naveEmpty);
            NAVE_Codigo.DataSource = naves;

            NAVE_Codigo.AutoCompleteSource = AutoCompleteSource.ListItems;
            NAVE_Codigo.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
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

        private void cmbCONS_CodRGM_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmbCONS_CodRGM.ConstantesSelectedItem != null)
                {

                    if (cmbCONS_CodRGM.ConstantesSelectedItem.CONS_CodTipo == Delfin.Controls.variables.CONSRGM_Importacion)
                    {
                        lblFechaIniEtaZarpe.Text = "Fec. Inicio ETA";
                        lblFechaFinEtaZarpe.Text = "Fec. Fin ETA";
                    }
                    if (cmbCONS_CodRGM.ConstantesSelectedItem.CONS_CodTipo == Delfin.Controls.variables.CONSRGM_Exportacion)
                    {
                        lblFechaIniEtaZarpe.Text = "Fec. Inicio Zarpe";
                        lblFechaFinEtaZarpe.Text = "Fec. Fin Zarpe";
                    }

                }


            }
            catch (Exception)
            { }
        }
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
