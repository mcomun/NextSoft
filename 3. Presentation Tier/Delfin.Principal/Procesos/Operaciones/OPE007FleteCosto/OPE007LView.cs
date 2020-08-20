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
    public partial class OPE007LView : UserControl, IOPE007LView
    {
        #region [ Variables ]

        #endregion

        #region [ Formulario ]

        public OPE007LView(Telerik.WinControls.UI.RadPageViewPage x_tabPageControl)
        {
            InitializeComponent();
            try
            {
                TabPageControl = x_tabPageControl;

                btnSincronizar.Click += new EventHandler(btnSincronizar_Click);
                btnDeshacer.Click += new EventHandler(btnDeshacer_Click);
                btnArchivo.Click += new EventHandler(btnArchivo_Click);
                TitleView.FormClose += new EventHandler(View_FormClose);
                BSItemsNoEncontrados = new BindingSource();
                BSItemsFleteDiferente = new BindingSource();
            }
            catch (Exception ex)
            { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al crear la vista.", ex); }
        }

        #endregion

        #region [ Propiedades ]

        public Telerik.WinControls.UI.RadPageViewPage TabPageControl { get; set; }
        public Image IconView { get { return TitleView.FormIcon; } set { TitleView.FormIcon = value; } }
        public OPE007Presenter Presenter { get; set; }
        public String FileName { get; set; }
        public String FilePath { get; set; }
        public BindingSource BSItemsNoEncontrados { get; set; }
        public BindingSource BSItemsFleteDiferente { get; set; }
        ToolStripMenuItem tsmTodos;
        String[] defaultColumns;

        #endregion

        #region [ IOPE007LView ]

        public void LoadView()
        {
            try
            {
                grdItemsFleteDiferente.Enabled = false;
                grdItemsNoEncontrados.Enabled = false;
                txtArchivo.ReadOnly = true;
            }
            catch (Exception ex)
            { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error cargando la vista.", ex); }
        }
        public void ShowItems()
        {
            try
            {
                /*################################### Items No Encontrados ############################*/
                this.grdItemsNoEncontrados.Columns.Clear();
                this.BSItemsNoEncontrados.DataSource = Presenter.DT_NoEncontrados;
                this.grdItemsNoEncontrados.DataSource = BSItemsNoEncontrados;
                this.navItemsNoEncontrados.BindingSource = BSItemsNoEncontrados;
                this.BSItemsNoEncontrados.ResetBindings(true);
                if (grdItemsNoEncontrados.RowCount > 0)
                {
                    this.grdItemsNoEncontrados.Enabled = true;
                    Infrastructure.WinForms.Controls.GridAutoFit.Fit(grdItemsNoEncontrados);
                }
                else
                {
                    this.grdItemsNoEncontrados.Enabled = false;
                }
                this.grdItemsNoEncontrados.AllowAddNewRow = false;
                this.grdItemsNoEncontrados.AllowAddNewRow = false;
                this.grdItemsNoEncontrados.AllowDeleteRow = false;
                this.grdItemsNoEncontrados.AutoGenerateColumns = true;
                this.grdItemsNoEncontrados.AllowColumnReorder = false;
                this.grdItemsNoEncontrados.AllowRowResize = false;
                this.grdItemsNoEncontrados.AllowRowReorder = false;
                this.grdItemsNoEncontrados.AllowColumnHeaderContextMenu = false;
                this.grdItemsNoEncontrados.AllowCellContextMenu = false;
                this.grdItemsNoEncontrados.AllowMultiColumnSorting = false;
                this.grdItemsNoEncontrados.ReadOnly = true;

                /*################################### Items De Flete Distinto ############################*/
                this.grdItemsFleteDiferente.Columns.Clear();
                this.BSItemsFleteDiferente.DataSource = Presenter.DT_Diferentes;
                this.grdItemsFleteDiferente.DataSource = BSItemsFleteDiferente;
                this.navItemsFleteDiferente.BindingSource = BSItemsFleteDiferente;
                this.BSItemsFleteDiferente.ResetBindings(true);
                if (grdItemsFleteDiferente.RowCount > 0)
                {
                    this.grdItemsFleteDiferente.Enabled = true;
                    Infrastructure.WinForms.Controls.GridAutoFit.Fit(grdItemsFleteDiferente);
                }
                else
                {
                    this.grdItemsFleteDiferente.Enabled = false;
                }
                this.grdItemsFleteDiferente.AllowAddNewRow = false;
                this.grdItemsFleteDiferente.AllowAddNewRow = false;
                this.grdItemsFleteDiferente.AllowDeleteRow = false;
                this.grdItemsFleteDiferente.AutoGenerateColumns = true;
                this.grdItemsFleteDiferente.AllowColumnReorder = false;
                this.grdItemsFleteDiferente.AllowRowResize = false;
                this.grdItemsFleteDiferente.AllowRowReorder = false;
                this.grdItemsFleteDiferente.AllowColumnHeaderContextMenu = false;
                this.grdItemsFleteDiferente.AllowCellContextMenu = false;
                this.grdItemsFleteDiferente.AllowMultiColumnSorting = false;
                this.grdItemsFleteDiferente.ReadOnly = true;

            }
            catch (Exception ex)
            { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error cargando los items.", ex); }
        }

        #endregion

        #region [ Metodos ]

        private void Sincronizar()
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(FilePath))
                {
                    if (System.IO.File.Exists(FilePath))
                    {
                        if (System.IO.Path.GetExtension(FilePath) == ".xls" || System.IO.Path.GetExtension(FilePath) == ".xlsx")
                        {
                            Infrastructure.Aspect.Importacion.ImportarExcel excel = new Infrastructure.Aspect.Importacion.ImportarExcel();
                            String _message = "";
                            DataTable DataTableImportacion = excel.Excel(FilePath, ref _message);
                            if (DataTableImportacion != null && DataTableImportacion.Rows.Count > 0)
                            {
                                foreach (System.Data.DataColumn _column in DataTableImportacion.Columns)
                                { _column.ColumnName = _column.ColumnName.Trim().ToUpper(); }
                                if (this.VerificaArchivo(DataTableImportacion))
                                {
                                    String columna;
                                    String columna2;
                                    columna = "DOCUMENT NO.";
                                    columna2 = "DOCUMENT NO#";
                                    if (DataTableImportacion.Columns.Contains(columna))
                                    {
                                        DataTableImportacion.DefaultView.RowFilter = "[" + columna + "] IS NOT NULL";
                                        DataTableImportacion = DataTableImportacion.DefaultView.ToTable();
                                    }
                                    else if (DataTableImportacion.Columns.Contains(columna2))
                                    {
                                        DataTableImportacion.DefaultView.RowFilter = "[" + columna2 + "] IS NOT NULL";
                                        DataTableImportacion = DataTableImportacion.DefaultView.ToTable();
                                    }
                                    ObservableCollection<Entities.Cab_Cotizacion_OV> _list = new ObservableCollection<Entities.Cab_Cotizacion_OV>();
                                    Entities.Cab_Cotizacion_OV _item = new Entities.Cab_Cotizacion_OV();
                                    foreach (DataRow _DataRowImportacion in DataTableImportacion.Rows)
                                    {
                                        _item = new Entities.Cab_Cotizacion_OV();

                                        //Nro. MBL
                                        columna = "DOCUMENT NO.";
                                        columna2 = "DOCUMENT NO#";
                                        if (DataTableImportacion.Columns.Contains(columna))
                                        {
                                            if (!String.IsNullOrEmpty(_DataRowImportacion[columna].ToString()))
                                            { _item.MBL = _DataRowImportacion[columna].ToString(); }
                                        }
                                        else if (DataTableImportacion.Columns.Contains(columna2))
                                        {
                                            if (!String.IsNullOrEmpty(_DataRowImportacion[columna2].ToString()))
                                            { _item.MBL = _DataRowImportacion[columna2].ToString(); }
                                        }

                                        //Nro. Contenedor
                                        columna = "CONTAINER NO.";
                                        columna2 = "CONTAINER NO#";
                                        if (DataTableImportacion.Columns.Contains(columna))
                                        {
                                            if (!String.IsNullOrEmpty(_DataRowImportacion[columna].ToString()))
                                            { _item.Contenedor = _DataRowImportacion[columna].ToString(); }
                                        }
                                        else if (DataTableImportacion.Columns.Contains(columna2))
                                        {
                                            if (!String.IsNullOrEmpty(_DataRowImportacion[columna2].ToString()))
                                            { _item.Contenedor = _DataRowImportacion[columna2].ToString(); }
                                        }

                                        //Puerto Origen 
                                        columna = "FIRST POL";
                                        columna2 = String.Empty; 
                                        if (DataTableImportacion.Columns.Contains(columna))
                                        {
                                            if (!String.IsNullOrEmpty(_DataRowImportacion[columna].ToString()))
                                            { _item.PuertoOrigen = _DataRowImportacion[columna].ToString(); }
                                        }

                                        //Nombre Nave
                                        columna = "MAIN VESSEL NAME";
                                        columna2 = String.Empty;
                                        if (DataTableImportacion.Columns.Contains(columna))
                                        {
                                            if (!String.IsNullOrEmpty(_DataRowImportacion[columna].ToString()))
                                            { _item.Nave = _DataRowImportacion[columna].ToString(); }
                                        }

                                        //Nro. De Viaje
                                        columna = "MAIN SCHEDULE VOYAGE";
                                        columna2 = String.Empty;
                                        if (DataTableImportacion.Columns.Contains(columna))
                                        {
                                            if (!String.IsNullOrEmpty(_DataRowImportacion[columna].ToString()))
                                            { _item.NroViaje = _DataRowImportacion[columna].ToString(); }
                                        }

                                        //Fecha ETA
                                        DateTime _FechaETA;
                                        var culture = System.Globalization.CultureInfo.CreateSpecificCulture("es-PE");
                                        columna = "LAST VOY. ETA DATE";
                                        columna2 = "LAST VOY# ETA DATE";
                                        if (DataTableImportacion.Columns.Contains(columna))
                                        {
                                            if (DateTime.TryParse(_DataRowImportacion[columna].ToString(), culture, System.Globalization.DateTimeStyles.None, out _FechaETA))
                                            { _item.FecETA = _FechaETA; }
                                        }
                                        else if (DataTableImportacion.Columns.Contains(columna2))
                                        {
                                            if (DateTime.TryParse(_DataRowImportacion[columna2].ToString(), culture, System.Globalization.DateTimeStyles.None, out _FechaETA))
                                            { _item.FecETA = _FechaETA; }
                                        }

                                        //Valor del Flete 
                                        Decimal _TarifaFlete = (Decimal)0.00;
                                        columna = "CONTAINER CHARGES (USD)";
                                        columna2 = "CONTAINER CHARGES #USD#";
                                        var style = System.Globalization.NumberStyles.AllowDecimalPoint;
                                        if (DataTableImportacion.Columns.Contains(columna))
                                        {
                                            if (Decimal.TryParse(_DataRowImportacion[columna].ToString(), style, culture, out _TarifaFlete))
                                            { _item.Flete = _TarifaFlete; }
                                        }
                                        else if (DataTableImportacion.Columns.Contains(columna2))
                                        {
                                            if (Decimal.TryParse(_DataRowImportacion[columna2].ToString(), style, culture, out _TarifaFlete))
                                            { _item.Flete = _TarifaFlete; } 
                                        }
                                        _list.Add(_item);
                                    }
                                    Presenter.Sincronizar(_list.ToTableValuedParameter());
                                }
                                else
                                {
                                    Dialogos.MostrarMensajeInformacion(Presenter.Title, "El archivo seleccionado no contiene las columnas según el formato.");
                                    return;
                                }
                            }
                            else
                            {
                                Dialogos.MostrarMensajeInformacion(Presenter.Title, "El archivo seleccionado no devolvio ningún registro, seleccione otro archivo.");
                                return;
                            }
                        }
                        else
                        {
                            Dialogos.MostrarMensajeInformacion(Presenter.Title, "El archivo seleccionado no es correcto, debe ingresar un Archivo de Excel (*.xls, *.xlsx)");
                            return;
                        }
                    }
                    else
                    {
                        Dialogos.MostrarMensajeInformacion(Presenter.Title, "El archivo seleccionado no existe.");
                        return;
                    }
                }
                else
                {
                    Dialogos.MostrarMensajeInformacion(Presenter.Title, "Debe seleccionar un archivo.");
                    return;
                }

            }
            catch (Exception ex)
            { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al llamar al reporte.", ex); }
        }
        private void Deshacer()
        {
            try
            {
                txtArchivo.Text = String.Empty;
                FilePath = String.Empty;
                FileName = String.Empty;

                BSItemsNoEncontrados.DataSource = null;
                grdItemsNoEncontrados.DataSource = BSItemsNoEncontrados;
                BSItemsNoEncontrados.ResetBindings(true);
                grdItemsNoEncontrados.Enabled = false;
                navItemsNoEncontrados.BindingSource = BSItemsNoEncontrados;

                BSItemsFleteDiferente.DataSource = null;
                grdItemsFleteDiferente.DataSource = BSItemsFleteDiferente;
                BSItemsFleteDiferente.ResetBindings(true);
                grdItemsFleteDiferente.Enabled = false;
                navItemsFleteDiferente.BindingSource = BSItemsFleteDiferente;
            }
            catch (Exception ex)
            { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al limpiar al reporte.", ex); }
        }
        private void BuscarArchivo()
        {
            try
            {
                String m_nsDefaultFile = "*.xls;*.xlsx";
                String m_nsFilter = "Archivos Excel (*.xls,*.xlsx)|*.xls;*.xlsx";
                FileName = String.Empty;
                FilePath = String.Empty;
                OpenFileDialog m_openFile = new OpenFileDialog();
                m_openFile.DefaultExt = m_nsDefaultFile;
                m_openFile.Filter = m_nsFilter;
                if (m_openFile.ShowDialog() == DialogResult.OK)
                {
                    FilePath = m_openFile.FileName;
                    FileName = System.IO.Path.GetFileName(m_openFile.FileName);
                    if (string.IsNullOrWhiteSpace(FilePath))
                    {
                        Dialogos.MostrarMensajeInformacion(Presenter.Title, "Debe seleccionar un archivo.");
                        return;
                    }
                    else if (!System.IO.File.Exists(FilePath))
                    {
                        Dialogos.MostrarMensajeInformacion(Presenter.Title, "El archivo seleccionado no existe.");
                        return;
                    }
                    else
                    {
                        txtArchivo.Text = FilePath;
                    }
                }
            }
            catch (Exception ex)
            { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al Buscar el Archivo.", ex); }
        }
        private Boolean VerificaArchivo(DataTable x_DataTableImportacion)
        {
            try
            {
                String columna;
                String columna2;

                //Nro. MBL
                columna = "DOCUMENT NO.";
                columna2 = "DOCUMENT NO#";
                if (!(x_DataTableImportacion.Columns.Contains(columna) || (x_DataTableImportacion.Columns.Contains(columna2))))
                { return false; }

                //Nro. Contenedor
                columna = "CONTAINER NO.";
                columna2 = "CONTAINER NO#";
                if (!(x_DataTableImportacion.Columns.Contains(columna) || (x_DataTableImportacion.Columns.Contains(columna2))))
                { return false; }

                //Puerto Origen 
                columna = "FIRST POL";
                columna2 = "FIRST POL";
                if (!(x_DataTableImportacion.Columns.Contains(columna) || (x_DataTableImportacion.Columns.Contains(columna2))))
                { return false; }

                //Nombre Nave
                columna = "MAIN VESSEL NAME";
                columna2 = "MAIN VESSEL NAME";
                if (!(x_DataTableImportacion.Columns.Contains(columna) || (x_DataTableImportacion.Columns.Contains(columna2))))
                { return false; }

                //Nro. De Viaje
                columna = "MAIN SCHEDULE VOYAGE";
                columna2 = "MAIN SCHEDULE VOYAGE";
                if (!(x_DataTableImportacion.Columns.Contains(columna) || (x_DataTableImportacion.Columns.Contains(columna2))))
                { return false; }

                //Fecha ETA
                columna = "LAST VOY. ETA DATE";
                columna2 = "LAST VOY# ETA DATE";
                if (!(x_DataTableImportacion.Columns.Contains(columna) || (x_DataTableImportacion.Columns.Contains(columna2))))
                { return false; }

                //Valor del Flete 
                columna = "CONTAINER CHARGES (USD)";
                columna2 = "CONTAINER CHARGES #USD#";
                if (!(x_DataTableImportacion.Columns.Contains(columna) || (x_DataTableImportacion.Columns.Contains(columna2))))
                { return false; }

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region [ Eventos ]

        private void btnSincronizar_Click(object sender, EventArgs e)
        { this.Sincronizar(); }
        private void btnDeshacer_Click(object sender, EventArgs e)
        { this.Deshacer(); }
        private void btnArchivo_Click(object sender, EventArgs e)
        { this.BuscarArchivo(); }

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
