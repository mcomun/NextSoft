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

namespace Delfin.Principal
{
    public partial class CAJ010ConciliacionLView : UserControl, ICAJ010ConciliacionLView
    {
        #region [ Variables ]
        //private String m_sortColumnName;
        //private Boolean m_sortAscending = false;
        #endregion

        #region [ Formulario ]
        public CAJ010ConciliacionLView(Telerik.WinControls.UI.RadPageViewPage x_tabPageControl)
        {
            InitializeComponent();
            try
            {
                TabPageControl = x_tabPageControl;

                btnBuscar.Click += new EventHandler(btnBuscar_Click);
                btnCargarArchivoXLS.Click += btnCargarArchivoXLS_Click;
                btnConciliacion.Click += btnConciliacion_Click;
                btnDeshacer.Click += btnDeshacer_Click;
                btnExportar.Click += new EventHandler(btnExportar_Click);

                BSItems = new BindingSource();
                BSItems.CurrentItemChanged += new EventHandler(BSItems_CurrentItemChanged);

                grdItems.CellEndEdit += grdItems_CellEndEdit;
                txtConciliacion.ReadOnly = true;
                txtConciliacion.WordWrap = false;
                spcBase.Panel2Collapsed = true;
                btnConciliacion.Enabled = false;
                btnCargarArchivoXLS.Enabled = false;

                txaCUBA_Codigo.SelectedItemCuentaBancariaChanged += txaCUBA_Codigo_SelectedItemCuentaBancariaChanged;

                TitleView.FormClose += new EventHandler(TitleView_FormClose);
            }
            catch (Exception ex)
            { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error inicializando el formulario LView.", ex); }
        }

        #endregion

        #region [ Propiedades ]
        public Telerik.WinControls.UI.RadPageViewPage TabPageControl { get; set; }
        public Image IconView { get { return TitleView.FormIcon; } set { TitleView.FormIcon = value; } }
        public CAJ010ConciliacionPresenter Presenter { get; set; }
        public BindingSource BSItems { get; set; }
        #endregion

        #region [ ICAJ010ConciliacionLView ]
        public void LoadView()
        {
            try
            {
                FormatDataGrid();

                grdItems.Enabled = false;
                btnBuscar.Enabled = true;

                txaCUBA_Codigo.LoadControl(Presenter.ContainerService, "Cuentas Bancarias", Delfin.Controls.Entorno.ItemEmpresa.EMPR_Codigo, Presenter.Session.UserName, Delfin.Controls.CuentaBancaria.TipoAyuda.Normal);
                cmbCONC_Periodo.ValueMember = "PERIODO";
                cmbCONC_Periodo.DisplayMember = "PERIODO";
                cmbCONC_Periodo.DataSource = Presenter.DTPeriodos;

                dtpFecIni.NSFecha = new DateTime(Presenter.Fecha.Year, Presenter.Fecha.Month, 1);
                dtpFecFin.NSFecha = dtpFecIni.NSFecha.Value.AddMonths(1).AddDays(-1);

                SeleccionarItem();
                btnExportar.Enabled = false;
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
                    btnConciliacion.Enabled = true;
                    btnCargarArchivoXLS.Enabled = true;
                    grdItems.BestFitColumns();
                    btnExportar.Enabled = true;
                    //Infrastructure.WinForms.Controls.GridAutoFit.Fit(this.grdItems);
                }
                else
                {
                    grdItems.Enabled = false;
                    btnConciliacion.Enabled = false;
                    btnCargarArchivoXLS.Enabled = false;
                    btnExportar.Enabled = false;
                }

                grdItems.ShowFilteringRow = false;
                grdItems.AutoGenerateColumns = false;
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
        private void FormatDataGrid()
        {
            try
            {
                Telerik.WinControls.UI.Localization.RadGridLocalizationProvider.CurrentProvider = new Infrastructure.WinForms.Controls.MySpanishRadGridLocalizationProvider();
                this.grdItems.Columns.Clear();
                this.grdItems.AllowAddNewRow = false;
                grdItems.AutoGenerateColumns = false;

                GridViewCheckBoxColumn checkboxColum = new GridViewCheckBoxColumn();
                checkboxColum.Name = "Seleccionar";
                checkboxColum.HeaderText = "";
                checkboxColum.FieldName = "Seleccionar";
                grdItems.Columns.Add(checkboxColum);
                grdItems.Columns["Seleccionar"].Width = 90;

                this.grdItems.Columns.Add("MOVI_NroOperacion", "Nro. Operación", "MOVI_NroOperacion");
                this.grdItems.Columns.Add("MOVI_NroOficina", "Nro. Oficina", "MOVI_NroOficina");
                this.grdItems.Columns.Add("TIPO_MOV_Corta", "Tipo", "TIPO_MOV_Corta");
                //this.grdItems.Columns.Add("Monto", "Monto", "Monto");
                //this.grdItems.Columns["Monto"].FormatString = "{0:#,###,##0.00}";
                //this.grdItems.Columns["Monto"].TextAlignment = ContentAlignment.MiddleRight;
                this.grdItems.Columns.Add("CONC_Periodo", "Periodo", "CONC_Periodo");

                //this.grdItems.Columns.Add("CONC_MontoBCO", "Monto", "CONC_MontoBCO");
                //this.grdItems.Columns["CONC_MontoBCO"].FormatString = "{0:#,##0.0000}";

                this.grdItems.Columns.Add("MOVI_FecEmision", "Fecha Emisión", "MOVI_FecEmision");
                this.grdItems.Columns["MOVI_FecEmision"].FormatString = "{0:dd/MM/yyyy}";
                this.grdItems.Columns.Add("FechaSistema", "Fecha Sistema", "FechaSistema");
                this.grdItems.Columns["FechaSistema"].FormatString = "{0:dd/MM/yyyy}";
                this.grdItems.Columns.Add("Monto", "Monto Sistema", "Monto");
                this.grdItems.Columns["Monto"].FormatString = "{0:#,###,##0.00}";
                this.grdItems.Columns["Monto"].TextAlignment = ContentAlignment.MiddleRight;
                this.grdItems.Columns.Add("MOVI_Concepto", "Concepto", "MOVI_Concepto");
                this.grdItems.Columns.Add("ENTC_DocIden", "R.U.C.", "ENTC_DocIden");
                this.grdItems.Columns.Add("ENTC_RazonSocial", "Razon Social", "ENTC_RazonSocial");

                GridViewDecimalColumn CONC_MontoBCO;
                CONC_MontoBCO = new GridViewDecimalColumn();
                CONC_MontoBCO.Name = "CONC_MontoBCO";
                CONC_MontoBCO.HeaderText = "Monto Bancario";
                CONC_MontoBCO.FieldName = "CONC_MontoBCO";
                CONC_MontoBCO.DecimalPlaces = 2;
                CONC_MontoBCO.Maximum = 9999999;
                CONC_MontoBCO.FormatString = "{0:#,###,##0.00}";
                CONC_MontoBCO.Minimum = 1;
                grdItems.MasterTemplate.Columns.Add(CONC_MontoBCO);
                grdItems.Columns["CONC_MontoBCO"].TextAlignment = ContentAlignment.MiddleRight;
                //this.grdItems.Columns.Add("CONC_FecConciliacion", "Fecha", "CONC_FecConciliacion");
                Telerik.WinControls.UI.GridViewDateTimeColumn DateTimeColumn = new Telerik.WinControls.UI.GridViewDateTimeColumn();
                DateTimeColumn.Name = "CONC_FecConciliacion";
                DateTimeColumn.FieldName = "CONC_FecConciliacion";
                DateTimeColumn.HeaderText = "Fecha Bancario";
                DateTimeColumn.ReadOnly = false;
                DateTimeColumn.FormatString = "{0:dd/MM/yyyy}";
                DateTimeColumn.Format = DateTimePickerFormat.Short;
                this.grdItems.Columns.Add(DateTimeColumn);

                this.grdItems.Columns.Add("MOVI_Codigo", "Interno", "MOVI_Codigo");

                this.grdItems.Columns["Seleccionar"].ReadOnly = false;

                this.grdItems.Columns["MOVI_NroOperacion"].ReadOnly = true;
                this.grdItems.Columns["MOVI_NroOficina"].ReadOnly = true;
                this.grdItems.Columns["TIPO_MOV_Corta"].ReadOnly = true;
                this.grdItems.Columns["CONC_Periodo"].ReadOnly = true;
                this.grdItems.Columns["MOVI_FecEmision"].ReadOnly = true;
                this.grdItems.Columns["FechaSistema"].ReadOnly = true;
                this.grdItems.Columns["Monto"].ReadOnly = true;
                this.grdItems.Columns["MOVI_Concepto"].ReadOnly = true;
                this.grdItems.Columns["Monto"].ReadOnly = true;
                this.grdItems.Columns["ENTC_DocIden"].ReadOnly = true;
                this.grdItems.Columns["ENTC_RazonSocial"].ReadOnly = true;
                this.grdItems.Columns["MOVI_Codigo"].ReadOnly = true;

                this.grdItems.Columns["CONC_MontoBCO"].ReadOnly = false;
                this.grdItems.Columns["CONC_FecConciliacion"].ReadOnly = false;
                //this.grdItems.Columns[""].ReadOnly = true;

                this.grdItems.Columns["Seleccionar"].Width = 60;
                this.grdItems.Columns["MOVI_NroOperacion"].Width = 100;
                this.grdItems.Columns["MOVI_NroOficina"].Width = 100;
                this.grdItems.Columns["Monto"].Width = 120;
                this.grdItems.Columns["CONC_Periodo"].Width = 60;
                this.grdItems.Columns["CONC_MontoBCO"].Width = 120;
                this.grdItems.Columns["CONC_FecConciliacion"].Width = 120;
                this.grdItems.Columns["MOVI_Concepto"].Width = 200;
                grdItems.ReadOnly = false;
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
                    if (BSItems != null && BSItems != null && BSItems.DataSource != null && BSItems.Current != null && BSItems.Current is Entities.Movimiento)
                    {
                        Presenter.Item = ((Entities.Movimiento)BSItems.Current);
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

        private void Buscar()
        {
            try
            {
                GetFiltros();
                if (txaCUBA_Codigo.SelectedItem != null && cmbCONC_Periodo.SelectedItem != null && Presenter.F_FecIni.HasValue && Presenter.F_FecFin.HasValue)
                {
                    Presenter.Actualizar();
                }
                else
                {
                    String x_mensaje = "";
                    if (txaCUBA_Codigo.SelectedItem == null)
                    { x_mensaje += String.Format("* Debe seleccionar una cuenta Bancaria.{0}", Environment.NewLine); }
                    if (cmbCONC_Periodo.SelectedItem == null)
                    { x_mensaje += String.Format("* Debe seleccionar un Periodo.{0}", Environment.NewLine); }
                    if (!Presenter.F_FecIni.HasValue || !Presenter.F_FecFin.HasValue)
                    { x_mensaje += String.Format("* Debe seleccionar las fechas Desde y Hasta{0}", Environment.NewLine); }

                    Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Presenter.Title, "Existen campos obligatorios, revise los detalles.", x_mensaje);
                }
            }
            catch (Exception ex)
            { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al buscar.", ex); }
        }

        private void GetFiltros()
        {
            try
            {
                Presenter.F_CUBA_Codigo = null; if (txaCUBA_Codigo.SelectedItem != null) { Presenter.F_CUBA_Codigo = txaCUBA_Codigo.SelectedItem.CUBA_Codigo; }
                Presenter.F_CONC_Periodo = null; if (cmbCONC_Periodo.SelectedItem != null) { Presenter.F_CONC_Periodo = cmbCONC_Periodo.SelectedValue.ToString(); }
                Presenter.F_FecIni = dtpFecIni.NSFecha;
                Presenter.F_FecFin = dtpFecFin.NSFecha;
            }
            catch (Exception)
            { }
        }

        private void ActualizarConciliacion(GridViewCellEventArgs e)
        {
            try
            {
                if (BSItems != null && BSItems.Current != null)
                {
                    if (e.Column.FieldName.Equals("Seleccionar"))
                    {
                        if ((BSItems.Current as Entities.Movimiento).Seleccionar)
                        {
                            (BSItems.Current as Entities.Movimiento).CONC_FecConciliacion = Presenter.Fecha;
                            (BSItems.Current as Entities.Movimiento).CONC_Periodo = Presenter.F_CONC_Periodo;
                            (BSItems.Current as Entities.Movimiento).CONC_MontoBCO = (BSItems.Current as Entities.Movimiento).Monto;
                            (BSItems.Current as Entities.Movimiento).ItemConciliacion.CONC_FecConciliacion = Presenter.Fecha;
                            (BSItems.Current as Entities.Movimiento).ItemConciliacion.CONC_Periodo = Presenter.F_CONC_Periodo;
                            (BSItems.Current as Entities.Movimiento).ItemConciliacion.CONC_MontoBCO = (BSItems.Current as Entities.Movimiento).Monto;
                        }
                        else
                        {
                            (BSItems.Current as Entities.Movimiento).CONC_FecConciliacion = null;
                            (BSItems.Current as Entities.Movimiento).CONC_Periodo = null;
                            (BSItems.Current as Entities.Movimiento).CONC_MontoBCO = null;
                            (BSItems.Current as Entities.Movimiento).ItemConciliacion.CONC_FecConciliacion = null;
                            (BSItems.Current as Entities.Movimiento).ItemConciliacion.CONC_Periodo = null;
                            (BSItems.Current as Entities.Movimiento).ItemConciliacion.CONC_MontoBCO = null;
                        }
                    }
                    if (e.Column.FieldName.Equals("CONC_MontoBCO"))
                    { (BSItems.Current as Entities.Movimiento).ItemConciliacion.CONC_MontoBCO = (BSItems.Current as Entities.Movimiento).CONC_MontoBCO; }
                    if (e.Column.FieldName.Equals("CONC_FecConciliacion"))
                    { (BSItems.Current as Entities.Movimiento).ItemConciliacion.CONC_FecConciliacion = (BSItems.Current as Entities.Movimiento).CONC_FecConciliacion; }
                }
            }
            catch (Exception ex)
            { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error actualizando los valores de conciliación.", ex); }
        }

        private void GuardarConciliacion()
        {
            try
            {
                if (Presenter.Guardar(true))
                {
                    btnConciliacion.Enabled = true;
                    btnCargarArchivoXLS.Enabled = true;
                }
            }
            catch (Exception ex)
            { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error guardando los valores de conciliación.", ex); }
        }

        private void CargarXLS()
        {
            try
            {
                if (Infrastructure.WinForms.Controls.Dialogos.MostrarMensajePregunta(Presenter.Title, "¿Desea cargar un archivo Excel para conciliar con los movimientos cargados?", Infrastructure.WinForms.Controls.Dialogos.LabelBoton.Si_No) == System.Windows.Forms.DialogResult.Yes)
                {
                    txtConciliacion.Clear();
                    spcBase.Panel2Collapsed = true;
                    Presenter.CargarXLS();
                }
            }
            catch (Exception ex)
            { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error cargando el archivo de conciliación.", ex); }
        }

        public void ShowValidation()
        {
            try
            {
                //Infrastructure.Client.FormClose.FormShowErrorProvider<Entities.CabPerfilAsientos>.Validate(Presenter.Item, this, errorProviderCab_Cotizacion_OV);
                Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Presenter.Title, "Existen campos obligatorios, revise los detalles.", Presenter.MensajeError);
            }
            catch (Exception ex)
            { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error en ShowValidation.", ex); }
        }

        public void ShowConciliacion(String x_mensaje)
        {
            try
            {
                txtConciliacion.Clear();
                txtConciliacion.Text = x_mensaje;
                spcBase.Panel2Collapsed = !(x_mensaje.Length > 0);
            }
            catch (Exception)
            { }
        }

        private void Deshacer()
        {
            try
            {
                BSItems.DataSource = null;
                txaCUBA_Codigo.Clear();
                txaCUBA_Codigo.ClearCuentaBancaria();

                grdItems.DataSource = BSItems;
                navItems.BindingSource = BSItems;
                BSItems.ResetBindings(true);
                btnExportar.Enabled = false;

                grdItems.Enabled = false;
                btnConciliacion.Enabled = false;
                btnCargarArchivoXLS.Enabled = false;

                spcBase.Panel2Collapsed = true;
                dtpFecIni.NSFecha = new DateTime(Presenter.Fecha.Year, Presenter.Fecha.Month, 1);
                dtpFecFin.NSFecha = dtpFecIni.NSFecha.Value.AddMonths(1).AddDays(-1);
                cmbCONC_Periodo.SelectedIndex = 0;
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
                if (_dt.Columns["Seleccionar"] != null)
                { _dt.Columns.Remove("Seleccionar"); }
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

        #endregion

        #region [ Eventos ]
        private void btnBuscar_Click(object sender, EventArgs e)
        { Buscar(); }

        private void btnExportar_Click(object sender, EventArgs e)
        { Exportar(); }

        private void BSItems_CurrentItemChanged(object sender, EventArgs e)
        { SeleccionarItem(); }

        private void btnCargarArchivoXLS_Click(object sender, EventArgs e)
        { CargarXLS(); }

        private void btnConciliacion_Click(object sender, EventArgs e)
        { GuardarConciliacion(); }

        private void grdItems_CellEndEdit(object sender, GridViewCellEventArgs e)
        { ActualizarConciliacion(e); }

        void btnDeshacer_Click(object sender, EventArgs e)
        { Deshacer(); }

        private void txaCUBA_Codigo_SelectedItemCuentaBancariaChanged(object sender, EventArgs e)
        {
            try
            {
                if (txaCUBA_Codigo.SelectedItem == null)
                {
                    txaCUBA_Codigo.SelectedItemCuentaBancariaChanged -= txaCUBA_Codigo_SelectedItemCuentaBancariaChanged;
                    Deshacer();
                    txaCUBA_Codigo.SelectedItemCuentaBancariaChanged += txaCUBA_Codigo_SelectedItemCuentaBancariaChanged;
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
                CloseForm(null, new Infrastructure.Client.FormClose.FormCloseEventArgs(this.TabPageControl, Presenter.CUS));
            }
        }
        public event Infrastructure.Client.FormClose.FormCloseEventArgs.FormCloseEventHandler CloseForm;
        #endregion

    }
}
