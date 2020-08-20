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
    public partial class REP010LView : UserControl, IREP010LView
    {
        #region [ Variables ]

        #endregion

        #region [ Formulario ]
        public REP010LView(Telerik.WinControls.UI.RadPageViewPage x_tabPageControl)
        {
            InitializeComponent();
            try
            {
                TabPageControl = x_tabPageControl;

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
        public REP010Presenter Presenter { get; set; }
        public BindingSource BSItems { get; set; }
        #endregion

        #region [ IREP010LView ]
        public void LoadView()
        {
            try
            {
                ayudaENTC_CodCliente.ContainerService = Presenter.ContainerService;
                ayudaENTC_CodCliente.TipoEntidad = Delfin.Controls.TiposEntidad.TIPE_Cliente;
                ayudaENTC_CodTransportista.ContainerService = Presenter.ContainerService;
                ayudaENTC_CodTransportista.TipoEntidad = Delfin.Controls.TiposEntidad.TIPE_Transportista;
                grdItems.Enabled = false;
                //FormatDataGrid();
                cmbREBA_Tipo.AddComboBoxItem("R", "Rebate", true);
                cmbREBA_Tipo.AddComboBoxItem("G", "GRR");
                cmbREBA_Tipo.LoadComboBox("< Seleccionar Tipo >");
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
              //Nullable<DateTime> _fec_ini_embarque = null;
              //Nullable<DateTime> _fec_fin_embarque = null;
              //Nullable<DateTime> _fec_ini_llegada = null;
              //Nullable<DateTime> _fec_fin_llegada = null;
              //Nullable<DateTime> _fec_ini_tarifa = null;
              //Nullable<DateTime> _fec_fin_tarifa = null;
              //Nullable<Int32> _codigo_cliente = null;
              //Int32 _codigo_linea;
              //String _numero_hbl = null;
              //String _numero_ov = null;
              String _tipo = null;

              if (!String.IsNullOrEmpty(cmbREBA_Tipo.ComboStrSelectedValue))
              {
                 if (ayudaENTC_CodTransportista.Value != null)
                 {
                    if ((mdtNVIA_FechaIniEmbarque.NSFecha != null && mdtNVIA_FechaFinEmbarque.NSFecha != null) || (mdtNVIA_FechaIniLlegada.NSFecha != null && mdtNVIA_FechaFinLlegada.NSFecha != null) || (mdtREBA_FecIniTarifa.NSFecha != null && mdtREBA_FecFinTarifa.NSFecha != null))
                    {
                       _tipo = cmbREBA_Tipo.ComboStrSelectedValue;
                       ObservableCollection<Infrastructure.Aspect.DataAccess.DataAccessFilterSQL> _filters = new ObservableCollection<Infrastructure.Aspect.DataAccess.DataAccessFilterSQL>();

                       _filters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@psinEMPR_Codigo", FilterValue = Delfin.Controls.Entorno.ItemEmpresa.EMPR_Codigo, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.Int16, FilterSize = 2 });
                       _filters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@psinSUCR_Codigo", FilterValue = Delfin.Controls.Entorno.ItemSucursal.SUCR_Codigo, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.Int16, FilterSize = 2 });

                       _filters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@pintENTC_CodTransportista", FilterValue = ayudaENTC_CodTransportista.Value.ENTC_Codigo, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.Int32, FilterSize = 4 });
                       //_codigo_linea = ayudaENTC_CodTransportista.Value.ENTC_Codigo;

                       if (ayudaENTC_CodCliente.Value != null)
                       {
                          //_codigo_cliente = ayudaENTC_CodCliente.Value.ENTC_Codigo;
                          _filters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@pintENTC_CodCliente", FilterValue = ayudaENTC_CodCliente.Value.ENTC_Codigo, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.Int32, FilterSize = 4 });
                       }
                       if (mdtNVIA_FechaIniEmbarque.NSFecha != null)
                       {
                          //_fec_ini_embarque = mdtNVIA_FechaIniEmbarque.NSFecha.Value;
                          _filters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@pdtmDDOV_FecEmbarqueIni", FilterValue = mdtNVIA_FechaIniEmbarque.NSFecha.Value, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.DateTime, FilterSize = 8 });
                       }
                       if (mdtNVIA_FechaFinEmbarque.NSFecha != null)
                       {
                          //_fec_fin_embarque = mdtNVIA_FechaFinEmbarque.NSFecha.Value;
                          _filters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@pdtmDDOV_FecEmbarqueFin", FilterValue = mdtNVIA_FechaFinEmbarque.NSFecha.Value, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.DateTime, FilterSize = 8 });
                       }
                       if (mdtNVIA_FechaIniLlegada.NSFecha != null)
                       {
                          //_fec_ini_llegada = mdtNVIA_FechaIniLlegada.NSFecha.Value;
                          _filters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@pdtmNVIA_FecLlegadaIni", FilterValue = mdtNVIA_FechaIniLlegada.NSFecha.Value, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.DateTime, FilterSize = 8 });
                       }
                       if (mdtNVIA_FechaFinLlegada.NSFecha != null)
                       {
                          //_fec_fin_llegada = mdtNVIA_FechaFinLlegada.NSFecha.Value;
                          _filters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@pdtmNVIA_FecLlegadaFin", FilterValue = mdtNVIA_FechaFinLlegada.NSFecha.Value, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.DateTime, FilterSize = 8 });
                       }
                       if (mdtREBA_FecIniTarifa.NSFecha != null)
                       {
                          //_fec_ini_tarifa = mdtREBA_FecIniTarifa.NSFecha.Value;
                          _filters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@pdtmCCOT_FecTarifaIni", FilterValue = mdtREBA_FecIniTarifa.NSFecha.Value, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.DateTime, FilterSize = 8 });
                       }
                       if (mdtREBA_FecFinTarifa.NSFecha != null)
                       {
                          //_fec_fin_tarifa = mdtREBA_FecFinTarifa.NSFecha.Value;
                          _filters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@pdtmCCOT_FecTarifaFin", FilterValue = mdtREBA_FecFinTarifa.NSFecha.Value, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.DateTime, FilterSize = 8 });
                       }

                       if (!String.IsNullOrEmpty(txtNroHBL.Text))
                       {
                          //_numero_hbl = txtNroHBL.Text;
                          _filters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@pvchDOOV_HBL", FilterValue = txtNroHBL.Text, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.Varchar, FilterSize = 50 });
                       }
                       if (!String.IsNullOrEmpty(txtNroOV.Text))
                       {
                          //_numero_ov = txtNroOV.Text;
                          _filters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@pvchCCOT_NumDoc", FilterValue = txtNroOV.Text, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.Varchar, FilterSize = 20 });
                       }

                       Presenter.CargarReporte(_tipo, _filters);
                    }
                    else
                    {
                       Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Presenter.Title, "Debe ingresar un rango de fechas como mínimo (Fec. ETA ó Fec. Embarque");
                    }
                 }
                 else
                 { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Presenter.Title, "Debe escoger un Transportista."); }
              }
              else
              { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Presenter.Title, "Debe seleccionar de Tipo."); }
           }
           catch (Exception ex)
           { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al buscar los datos.", ex); }
        }
        private void Deshacer()
        {
            try
            {
                Presenter.LimpiarReporte();

                ayudaENTC_CodTransportista.ClearValue();
                ayudaENTC_CodTransportista.Text = string.Empty;
                mdtNVIA_FechaIniEmbarque.NSFecha = null;
                mdtNVIA_FechaFinEmbarque.NSFecha = null;
                mdtNVIA_FechaIniLlegada.NSFecha = null;
                mdtNVIA_FechaFinLlegada.NSFecha = null;
                ayudaENTC_CodCliente.ClearValue();
                ayudaENTC_CodCliente.Text = string.Empty;
                txtNroHBL.Text = string.Empty;
                txtNroOV.Text = string.Empty;

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
                    String _titulo = "Reporte de " + ayudaENTC_CodTransportista.Text;
                    DateTime thisDay = DateTime.Today;
                    List<String> _listTituloFiltro = new List<String>();
                    _listTituloFiltro.Add("GENERADO : " + thisDay.ToString("D"));
                    _xls.InsertarTitulos(_titulo, 1, ref _fila, 1, _listTituloFiltro, _cabeceras.Length);
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
