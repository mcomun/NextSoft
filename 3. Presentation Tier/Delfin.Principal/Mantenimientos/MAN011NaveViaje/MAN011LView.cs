using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Delfin.Principal.Properties;
using Infrastructure.Aspect.Collections;

using Delfin.Controls.Tipos;
using Infrastructure.WinForms.Controls;
using Telerik.WinControls;
using Telerik.WinControls.UI;

namespace Delfin.Principal
{
    public partial class MAN011LView : UserControl, IMAN011LView
    {
        #region [ Variables ]
        #endregion

        #region [ Formulario ]
        public MAN011LView(Telerik.WinControls.UI.RadPageViewPage x_tabPageControl)
        {
            InitializeComponent();
            try
            {
                TabPageControl = x_tabPageControl;

                btnNuevo.Click += new EventHandler(btnNuevo_Click);
                btnBuscar.Click += new EventHandler(btnBuscar_Click);
                btnExportar.Click += new EventHandler(btnExportar_Click);
                btnDeshacer.Click += new EventHandler(btnDeshacer_Click);
                ENTC_CodTransportista.AyudaValueChanged += new System.EventHandler(ENTC_CodTransportista_AyudaValueChanged);


                BSItems = new BindingSource();
                BSItems.CurrentItemChanged += new EventHandler(BSItems_CurrentItemChanged);

                grdItems.CommandCellClick += new Telerik.WinControls.UI.CommandCellClickEventHandler(grdItems_CommandCellClick);
                grdItems.CellFormatting += grdItems_CellFormatting;
                TitleView.FormClose += new EventHandler(TitleView_FormClose);
            }
            catch (Exception ex)
            { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error inicializando el formulario LView", ex); }
        }
        #endregion

        #region [ Propiedades ]
        public Telerik.WinControls.UI.RadPageViewPage TabPageControl { get; set; }
        public Image IconView { get { return TitleView.FormIcon; } set { TitleView.FormIcon = value; } }
        public MAN011Presenter Presenter { get; set; }
        public BindingSource BSItems { get; set; }
        #endregion

        #region [ IMAN011LView ]
        public void LoadView()
        {
            try
            {
                cmbCONS_CodVia.LoadControl(Presenter.ContainerService, "Tipos de Vía", "VIA", "<Seleccione una Vía>", ListSortDirection.Ascending);
                cmbCONS_CodRGM.LoadControl(Presenter.ContainerService, "Tipos de Régimen", "RGM", "< Seleccionar Régimen >", ListSortDirection.Ascending);
                cmbNVIA_Estado.LoadControl("Estado Nave Viaje", ComboBoxConstantes.OConstantes.NVIA_Estado, "< Seleccionar Estado>", ListSortDirection.Ascending);
                ENTC_CodTransportista.ContainerService = Presenter.ContainerService;

                BSItems.DataSource = null;
                grdItems.DataSource = BSItems;
                navItems.BindingSource = BSItems;
                BSItems.ResetBindings(true);

                FormatDataGrid();
                ShowComboNaves();
                grdItems.Enabled = false;
                btnNuevo.Enabled = true;
                btnBuscar.Enabled = true;
                btnExportar.Enabled = false;
                mdtNVIA_FecCreacion.NSFecha = DateTime.Now;
                mdtNVIA_FecCreacion.NSFecha = mdtNVIA_FecCreacion.NSFecha.Value.AddDays(-30);

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
                    Infrastructure.WinForms.Controls.GridAutoFit.Fit(this.grdItems);
                }
                else
                {
                    grdItems.Enabled = false;
                    btnExportar.Enabled = false;
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

                this.grdItems.Columns.Add("NVIA_Codigo", "Código", "NVIA_Codigo");
                this.grdItems.Columns.Add("NVIA_DesEstado", "Estado", "NVIA_DesEstado");
                this.grdItems.Columns.Add("NAVE_Nombre", "NAVE", "NAVE_Nombre");
                this.grdItems.Columns.Add("NVIA_NroViaje", "NroViaje", "NVIA_NroViaje");
                this.grdItems.Columns.Add("ENTC_NomTransp", "Transportista", "ENTC_NomTransp");
                this.grdItems.Columns.Add("CONS_DescRGM", "Régimen", "CONS_DescRGM");
                //this.grdItems.Columns.Add("TIPO_DescTRF", "Tráfico", "TIPO_DescTRF");
                this.grdItems.Columns.Add("NVIA_FecETA_IMPO_ETD_EXPO", "Fecha ETA/ETD", "NVIA_FecETA_IMPO_ETD_EXPO");

                //this.grdItems.Columns.Add("TIPO_DescPAI", "País", "TIPO_DescPAI");
                this.grdItems.Columns.Add("PUER_Nombre", "Puerto", "PUER_Nombre");
                //this.grdItems.Columns.Add("ENTC_NomAgentePort_EXPO", "Agente Portuario", "ENTC_NomAgentePort_EXPO");


                this.grdItems.Columns.Add("AUDI_UsrCrea", "Usuario Creación", "AUDI_UsrCrea");
                this.grdItems.Columns.Add("AUDI_FecCrea", "Fecha Creación", "AUDI_FecCrea");
                this.grdItems.Columns.Add("NVIA_UsrPreFactura", "Usuario Pre-Factura", "NVIA_UsrPreFactura");
                this.grdItems.Columns.Add("NVIA_UsrCierreNave", "Usuario Cierra", "NVIA_UsrCierreNave");

                //this.grdItems.Columns["TIPO_DescPAI"].IsVisible = false;


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

            NAVE_Codigo.Text = String.Empty;NAVE_Codigo.AutoCompleteSource = AutoCompleteSource.ListItems;
            NAVE_Codigo.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
        }
        private void SeleccionarItem()
        {
            try
            {
                if (Presenter != null)
                {
                    if (BSItems != null && BSItems.Current != null && BSItems.Current is Entities.NaveViaje)
                    { Presenter.Item = ((Entities.NaveViaje)BSItems.Current); }
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
                //if (Presenter.ItemsNaveUnTransportista.Count > 0)
                //{
                Presenter.ItemTransportista = ENTC_CodTransportista.Value;
                Presenter.Nuevo();
                //}
                //else
                //{
                //   Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Presenter.Title, "El transportista seleccionado no tiene naves, primero registre una Nave para luego registrar un viaje");
                //}
            }
            catch (Exception ex)
            { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al hacer nuevo.", ex); }
        }
        private void Buscar()
        {
            try
            {
                //if (ENTC_CodTransportista.Value != null)
                //{
                    Presenter.FILTROEstado = cmbNVIA_Estado.ConstantesSelectedItem;
                    Presenter.FILTROItemRegimen = cmbCONS_CodRGM.ConstantesSelectedItem;
                    Presenter.FILTROItemVia = cmbCONS_CodVia.ConstantesSelectedItem;
                    Presenter.FILTROItemTransportista = ENTC_CodTransportista.Value;
                    Int16 _NAVE_Codigo;
                    if (NAVE_Codigo.SelectedValue != null && Int16.TryParse(NAVE_Codigo.SelectedValue.ToString(), out _NAVE_Codigo))
                    {
                        if (NAVE_Codigo.SelectedValue.ToString() != "-1")
                        { Presenter.FILTROItemNave = Convert.ToInt16(NAVE_Codigo.SelectedValue.ToString()); }
                        else
                        { Presenter.FILTROItemNave = null; }
                    }
                    else
                    { Presenter.FILTROItemNave = null; }
                    //Presenter.FILTROItemNave = Convert.ToInt16(NAVE_Codigo.SelectedValue.ToString()); 
                    Presenter.FILTROItemFecCreacion = mdtNVIA_FecCreacion.NSFecha;
                    Presenter.FILTROItemNroViaje = null;
                    if (!String.IsNullOrEmpty(NVIA_NroViaje.Text))
                    { Presenter.FILTROItemNroViaje = NVIA_NroViaje.Text; }
                    //Presenter.ItemTransportista = ENTC_CodTransportista.Value;
                    Presenter.Actualizar();
                //}
                //else
                //{
                //    Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Presenter.Title, "Debe seleccionar un transportista.");
                //}
                
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
                grdItems.Enabled = false;
                navItems.BindingSource = BSItems;
                BSItems.ResetBindings(true);

                grdItems.Enabled = true;
                btnNuevo.Enabled = true;
                btnBuscar.Enabled = true;
                btnExportar.Enabled = false;

                cmbCONS_CodRGM.SelectedIndex = 0;
                cmbCONS_CodVia.SelectedIndex = 0;
                ENTC_CodTransportista.ClearValue(); ;
                mdtNVIA_FecCreacion.NSFecha = null;
                //NAVE_Codigo.DataSource = null;
                NAVE_Codigo.SelectedIndex = 0;
            }
            catch (Exception ex)
            { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al deshacer la vista.", ex); }
        }
        #endregion

        #region [ Eventos ]
        private void btnNuevo_Click(object sender, EventArgs e)
        { Nuevo(); }
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Buscar();
        }
        private void btnExportar_Click(object sender, EventArgs e)
        { Exportar(); }
        private void btnDeshacer_Click(object sender, EventArgs e)
        { Deshacer(); }
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
        /// <summary>
        /// CRISTHIAN JOSE APAZA
        /// NAVE SEGUN TRANSPORTISTA
        /// </summary>
        private void ENTC_CodTransportista_AyudaValueChanged(object sender, EventArgs e)
        {
            //    if (ENTC_CodTransportista.Value != null)
            //    {
            //        NAVE_Codigo.Enabled = true;

            //        Presenter.ItemsNaveUnTransportista = Presenter.ItemsNave.Where(Trans => Trans.ENTC_CodTransportista == ENTC_CodTransportista.Value.ENTC_Codigo).ToObservableCollection();
            //        Presenter.ItemTransportista = ENTC_CodTransportista.Value;
            //        NAVE_Codigo.ValueMember = "NAVE_Codigo";
            //        NAVE_Codigo.DisplayMember = "NAVE_Nombre";

            //        Entities.Nave naveEmpty = new Entities.Nave();
            //        naveEmpty.NAVE_Codigo = -1;
            //        naveEmpty.NAVE_Nombre = "<Todos>";

            //        ObservableCollection<Entities.Nave> naves = Presenter.ItemsNaveUnTransportista;
            //        naves.Insert(0, naveEmpty);

            //        NAVE_Codigo.DataSource = naves;
            //        //Presenter.Actualizar();
            //    }
            //    else
            //    {
            //        Presenter.ItemsNaveUnTransportista = new ObservableCollection<Entities.Nave>();
            //        Presenter.ItemTransportista = null;
            //    }

        }
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
            { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al ejecutar el comando de la grilla.", ex); }
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