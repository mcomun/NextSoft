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
    public partial class REP009LView : UserControl, IREP009LView
    {
        #region [ Variables ]

        #endregion

        #region [ Formulario ]
        public REP009LView(Telerik.WinControls.UI.RadPageViewPage x_tabPageControl)
        {
            InitializeComponent();
            try
            {
                TabPageControl = x_tabPageControl;

                cmbCONS_CodRGM.SelectedIndexChanged += CONS_CodRGM_SelectedIndexChanged;

                btnBuscar.Click += new EventHandler(btnBuscar_Click);
                btnDeshacer.Click += new EventHandler(btnDeshacer_Click);
                btnExportar.Click += new EventHandler(btnExportar_Click);

                TitleView.FormClose += new EventHandler(View_FormClose);

                BSItems = new BindingSource();

                ayudaENTC_CodTransportista.AyudaValueChanged += new System.EventHandler(ENTC_CodTransportista_AyudaValueChanged);
            }
            catch (Exception ex)
            { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al crear la vista.", ex); }
        }
        #endregion

        #region [ Propiedades ]
        public Telerik.WinControls.UI.RadPageViewPage TabPageControl { get; set; }
        public Image IconView { get { return TitleView.FormIcon; } set { TitleView.FormIcon = value; } }
        public REP009Presenter Presenter { get; set; }
        public BindingSource BSItems { get; set; }


        #endregion

        #region [ IREP009LView ]
        public void LoadView()
        {
            try
            {
                ayudaENTC_CodTransportista.ContainerService = Presenter.ContainerService;
                ayudaENTC_CodTransportista.TipoEntidad = Delfin.Controls.TiposEntidad.TIPE_Transportista;

                cmbCONS_CodRGM.LoadControl(Presenter.ContainerService, "Tabla de Regimen", "RGM", "< Seleccionar Regimen >", ListSortDirection.Ascending);
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
                    //Infrastructure.WinForms.Controls.GridAutoFit.Fit(this.grdItems);
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
                grdItems.ReadOnly = false;


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
                    if (mdtNVIA_FechaIni.NSFecha != null && mdtNVIA_FechaFin.NSFecha != null)
                    {
                        if (mdtNVIA_FechaIni.NSFecha < mdtNVIA_FechaFin.NSFecha)
                        {

                            String _CONS_TabRGM = cmbCONS_CodRGM.ConstantesSelectedItem.CONS_CodTabla;
                            String _CONS_CodRGM = cmbCONS_CodRGM.ConstantesSelectedItem.CONS_CodTipo;
                            Nullable<DateTime> _NVIA_FecETAIni = null;
                            Nullable<DateTime> _NVIA_FecETAFin = null;
                            Nullable<DateTime> _NVIA_FecZarpeIni = null;
                            Nullable<DateTime> _NVIA_FecZarpeFin = null;
                            if (cmbCONS_CodRGM.ConstantesSelectedItem.CONS_CodTipo == Delfin.Controls.variables.CONSRGM_Importacion)
                            {
                                _NVIA_FecETAIni = mdtNVIA_FechaIni.NSFecha.Value;
                                _NVIA_FecETAFin = mdtNVIA_FechaFin.NSFecha.Value;
                            }
                            if (cmbCONS_CodRGM.ConstantesSelectedItem.CONS_CodTipo == Delfin.Controls.variables.CONSRGM_Exportacion)
                            {
                                _NVIA_FecZarpeIni = mdtNVIA_FechaIni.NSFecha.Value;
                                _NVIA_FecZarpeFin = mdtNVIA_FechaFin.NSFecha.Value;
                            }
                            Nullable<Int32> _ENTC_CodTransportista = null;
                            if (ayudaENTC_CodTransportista.Value != null && ayudaENTC_CodTransportista.Value.ENTC_Codigo > 0)
                            { _ENTC_CodTransportista = ayudaENTC_CodTransportista.Value.ENTC_Codigo; }
                            Int16 _NAVE_Codigo;
                            Nullable<Int16> _NAVE_Codigo2 = null;
                            if (cmbNAVE_Codigo.SelectedValue != null && Int16.TryParse(cmbNAVE_Codigo.SelectedValue.ToString(), out _NAVE_Codigo))
                            {
                                _NAVE_Codigo = Convert.ToInt16(cmbNAVE_Codigo.SelectedValue.ToString());
                                if (_NAVE_Codigo != -1)
                                {_NAVE_Codigo2 = _NAVE_Codigo;}
                            }
                            Presenter.CargarReporte(_CONS_TabRGM, _CONS_CodRGM, _NVIA_FecETAIni, _NVIA_FecETAFin, _NVIA_FecZarpeIni, _NVIA_FecZarpeFin, _ENTC_CodTransportista, _NAVE_Codigo2);
                        }
                        else
                        {
                            Dialogos.MostrarMensajeInformacion(Presenter.Title, "La Fec. Fin debe ser Mayor a la de Inicio");
                        }
                    }
                    else
                    { Dialogos.MostrarMensajeInformacion(Presenter.Title, "Debe seleccionar un Fec. de Inicio y Fin"); }
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

                ayudaENTC_CodTransportista.ClearValue();
                ayudaENTC_CodTransportista.Text = string.Empty;
                cmbNAVE_Codigo.DataSource = null;
                mdtNVIA_FechaIni.NSFecha = null;
                mdtNVIA_FechaFin.NSFecha = null;

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
        public void FormatDataGrid(String CONS_CodRGM)
        {
            try
            {
                Telerik.WinControls.UI.Localization.RadGridLocalizationProvider.CurrentProvider = new Infrastructure.WinForms.Controls.MySpanishRadGridLocalizationProvider();
                this.grdItems.Columns.Clear();
                this.grdItems.AllowAddNewRow = false;

                this.grdItems.Columns.Clear();
                this.grdItems.AllowAddNewRow = false;
                this.grdItems.AllowDeleteRow = false;
                this.grdItems.AutoGenerateColumns = false;
                this.grdItems.AllowColumnReorder = false;
                this.grdItems.AllowRowResize = false;
                this.grdItems.AllowRowReorder = false;
                this.grdItems.AllowColumnHeaderContextMenu = false;
                this.grdItems.AllowCellContextMenu = false;
                this.grdItems.AllowMultiColumnSorting = false;
                //this.grdItems.AllowEditRow = true;
                this.grdItems.ReadOnly = true;

                #region[Importaciones]
                if (CONS_CodRGM == Delfin.Controls.variables.CONSRGM_Importacion)
                {
                    this.grdItems.Columns.Add("NVIA_Estado", "Estado", "NVIA_Estado");
                    this.grdItems.Columns.Add("ETRA_NomCompleto", "Linea Naviera", "ETRA_NomCompleto");
                    this.grdItems.Columns.Add("NAVE_Nombre", "Buque", "NAVE_Nombre");
                    this.grdItems.Columns.Add("NVIA_NroViaje", "Nro. Viaje", "NVIA_NroViaje");
                    this.grdItems.Columns.Add("NVIA_FecETA_IMPO_ETD_EXPO", "ETA", "NVIA_FecETA_IMPO_ETD_EXPO");
                    this.grdItems.Columns.Add("NVIA_NroManifiesto", "Manifiesto", "NVIA_NroManifiesto");
                    this.grdItems.Columns.Add("NVIA_NorManifiestoDescon", "Manifiesto Desconsolidado", "NVIA_NorManifiestoDescon");
                    this.grdItems.Columns.Add("NVIA_FecLlega_IMPO_Zarpe_EXPO", "Fec. Llegada", "NVIA_FecLlega_IMPO_Zarpe_EXPO");
                    this.grdItems.Columns.Add("NVIA_FecDescarga_IMPO", "Fec. Descarga", "NVIA_FecDescarga_IMPO");
                    this.grdItems.Columns.Add("NVIA_FecCierreDire_IMPO_TermEmba_EXPO", "Fec. Cierre Direccionamiento", "NVIA_FecCierreDire_IMPO_TermEmba_EXPO");
                    //this.grdItems.Columns.Add("ENTC_FecRecogerDocs", "Fec. Recogo de Documentos", "ENTC_FecRecogerDocs");
                    this.grdItems.Columns.Add("CONS_NomRGM", "Regimen", "CONS_NomRGM");
                    this.grdItems.Columns.Add("CANT_OrdenVenta", "Cant. Ordenes de Venta", "CANT_OrdenVenta");
                    this.grdItems.Columns.Add("ENTC_NomOpePortuario", "Operador Portuario", "ENTC_NomOpePortuario");
                    this.grdItems.Columns.Add("NVIA_UsrEmiteStatment", "Usuario Emite Statement", "NVIA_UsrEmiteStatment");
                    this.grdItems.Columns.Add("NVIA_FecEmiteStatment", "Fecha Emite Statement", "NVIA_FecEmiteStatment");
                }
                #endregion

                #region[Exportaciones]
                if (CONS_CodRGM == Delfin.Controls.variables.CONSRGM_Exportacion)
                {
                    this.grdItems.Columns.Add("NVIA_Estado", "Estado", "NVIA_Estado");
                    this.grdItems.Columns.Add("ETRA_NomCompleto", "Linea Naviera", "ETRA_NomCompleto");
                    this.grdItems.Columns.Add("NAVE_Nombre", "Buque", "NAVE_Nombre");
                    this.grdItems.Columns.Add("NVIA_NroViaje", "Nro. Viaje", "NVIA_NroViaje");
                    this.grdItems.Columns.Add("NVIA_FecETA_IMPO_ETD_EXPO", "ETD", "NVIA_FecETA_IMPO_ETD_EXPO");
                    this.grdItems.Columns.Add("NVIA_NroManifiesto", "Manifiesto", "NVIA_NroManifiesto");
                    this.grdItems.Columns.Add("NVIA_FecLlega_IMPO_Zarpe_EXPO", "Fec. Zarpe", "NVIA_FecLlega_IMPO_Zarpe_EXPO");
                    this.grdItems.Columns.Add("NVIA_FecCierreDire_IMPO_TermEmba_EXPO", "Fec. Term. Embarque", "NVIA_FecCierreDire_IMPO_TermEmba_EXPO");
                    this.grdItems.Columns.Add("ENTC_FecRecogerDocs", "Fec. Recogo de Documentos", "ENTC_FecRecogerDocs");
                    this.grdItems.Columns.Add("CONS_NomRGM", "Regimen", "CONS_NomRGM");
                    this.grdItems.Columns.Add("CANT_OrdenVenta", "Cant. Ordenes de Venta", "CANT_OrdenVenta");
                    this.grdItems.Columns.Add("ENTC_NomOpePortuario", "Operador Portuario", "ENTC_NomOpePortuario");
                    this.grdItems.Columns.Add("NVIA_UsrEmiteStatment", "Usuario Emite Statement", "NVIA_UsrEmiteStatment");
                    this.grdItems.Columns.Add("NVIA_FecEmiteStatment", "Fecha Emite Statement", "NVIA_FecEmiteStatment");
                }
                #endregion

                Infrastructure.WinForms.Controls.GridAutoFit.Fit(grdItems);

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

        /// <summary>
        /// CRISTHIAN JOSE APAZA
        /// NAVE SEGUN TRANSPORTISTA
        /// </summary>
        private void ENTC_CodTransportista_AyudaValueChanged(object sender, EventArgs e)
        {
            if (ayudaENTC_CodTransportista.Value != null)
            {
                cmbNAVE_Codigo.Enabled = true;

                Presenter.ItemsNaveUnTransportista = Presenter.ItemsNave.Where(Trans => Trans.ENTC_CodTransportista == ayudaENTC_CodTransportista.Value.ENTC_Codigo).ToObservableCollection();
                Presenter.ItemTransportista = ayudaENTC_CodTransportista.Value;
                cmbNAVE_Codigo.ValueMember = "NAVE_Codigo";
                cmbNAVE_Codigo.DisplayMember = "NAVE_Nombre";

                Entities.Nave naveEmpty = new Entities.Nave();
                naveEmpty.NAVE_Codigo = -1;
                naveEmpty.NAVE_Nombre = "<Todos>";

                ObservableCollection<Entities.Nave> naves = Presenter.ItemsNaveUnTransportista;
                naves.Insert(0, naveEmpty);

                cmbNAVE_Codigo.DataSource = naves;
                //Presenter.Actualizar();
            }
            else
            {
                Presenter.ItemsNaveUnTransportista = new ObservableCollection<Entities.Nave>();
                Presenter.ItemTransportista = null;
                cmbNAVE_Codigo.DataSource = null;
                cmbNAVE_Codigo.Enabled = false;
            }

        }

        private void CONS_CodRGM_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmbCONS_CodRGM.ConstantesSelectedItem != null)
                {

                    if (cmbCONS_CodRGM.ConstantesSelectedItem.CONS_CodTipo == Delfin.Controls.variables.CONSRGM_Importacion)
                    {
                        lblFechaIni.Text = "Fec. Inicio ETA";
                        lblFechaFin.Text = "Fec. Fin ETA";
                    }
                    if (cmbCONS_CodRGM.ConstantesSelectedItem.CONS_CodTipo == Delfin.Controls.variables.CONSRGM_Exportacion)
                    {
                        lblFechaIni.Text = "Fec. Inicio Zarpe";
                        lblFechaFin.Text = "Fec. Fin Zarpe";
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
