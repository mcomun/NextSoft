using System;
using System.Collections.Generic;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using Delfin.Entities;
using Delfin.Principal.Properties;
using Infrastructure.Aspect.Constants;
using Infrastructure.Client.FormClose;
using Infrastructure.WinFormsControls;
using Telerik.WinControls;
using Telerik.WinControls.UI;
using Telerik.WinControls.UI.Localization;

namespace Delfin.Principal
{
    public partial class REP005LView : UserControl, IREP005LView
    {
        #region [ Variables ]

        #endregion

        #region [ Formulario ]
        public REP005LView(RadPageViewPage x_tabPageControl)
        {
            InitializeComponent();
            try
            {
                TabPageControl = x_tabPageControl;
                btnDeshacer.Click += btnDeshacer_Click;
                btnBuscar.Click += btnBuscar_Click;
                BSItems = new BindingSource();
                BSItems.CurrentItemChanged += BSItems_CurrentItemChanged;
                grdItems.CommandCellClick += grdItems_CommandCellClick;
                TitleView.FormClose += TitleView_FormClose;
                grdItems.CellFormatting += grdItems_CellFormatting;
            }
            catch (Exception ex)
            { Dialogos.MostrarMensajeError(Presenter.Titulo, Mensajes.ConstructorView, ex); }
        }
        #endregion

        #region [ Propiedades ]
        public RadPageViewPage TabPageControl { get; set; }
        public Image IconView { get { return TitleView.FormIcon; } set { TitleView.FormIcon = value; } }
        public REP005Presenter Presenter { get; set; }
        public BindingSource BSItems { get; set; }
        #endregion

        #region [ IPROC003LView ]
        public void LoadFilters()
        {
            try
            {
                Presenter.FechaEmisionIni = mdtFecDesde.NSFecha != null ? mdtFecDesde.NSFecha.Value : (DateTime?)null;
                Presenter.FechaEmisionFin = mdtFecHasta.NSFecha != null ? mdtFecHasta.NSFecha.Value : (DateTime?)null;
                Presenter.NroOperacion = !String.IsNullOrEmpty(TxtNroOperacion.Text) ? TxtNroOperacion.Text : null;
                Presenter.HBLOperacion = !String.IsNullOrEmpty(txtHBL.Text) ? txtHBL.Text : null;
                Presenter.ENTC_CodigoFiltro = AyudaCliente.Value != null ? AyudaCliente.Value.ENTC_Codigo : (int?)null;
            }
            catch (Exception) { }
        }
        public void ShowValidation()
        {
            try
            {
                Dialogos.MostrarMensajeInformacion(Presenter.Titulo, "Faltan ingresar datos obligatorios: ", Presenter.MensajeError, Dialogos.Boton.Detalles);
            }
            catch (Exception ex)
            { Dialogos.MostrarMensajeError(Presenter.Titulo, Mensajes.ShowItems, ex); }
        }
        public void LoadView()
      {
         try
         {
            BSItems.DataSource = null;
            grdItems.DataSource = BSItems;
            navItems.BindingSource = BSItems;
            BSItems.ResetBindings(true);
            FormatDataGrid();
            grdItems.Enabled = false;
            Presenter.ENTC_CodigoFiltro = null;
            TxtNroOperacion.Clear();
            txtHBL.Clear();
            mdtFecDesde.NSFecha = DateTime.Now;
            mdtFecHasta.NSFecha = DateTime.Now;
            AyudaCliente.ClearValue();
            AyudaCliente.ContainerService = Presenter.ContainerService;
            switch (Presenter.CUS)
            {
                case "REP005Liq":
                    TitleView.Text = "Liquidación de Servicios";
                    break;
                case "REP005Con":
                    TitleView.Text = "Pre-Liquidación con Servicio Logístico";
                    break;
                case "REP005Sin":
                    TitleView.Text = "Pre-Liquidación sin Servicio Logístico";
                    break;
            }
         }
         catch (Exception ex)
         { Dialogos.MostrarMensajeError(Presenter.Titulo, Mensajes.LoadView, ex); }
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
                    GridAutoFit.Fit(grdItems);
                }
                else
                {
                    grdItems.Enabled = false;
                }
            }
            catch (Exception ex)
            { Dialogos.MostrarMensajeError(Presenter.Titulo, Mensajes.ShowItems, ex); }
        }
        #endregion

        #region [ Metodos ]
        private void FormatDataGrid()
        {
            try
            {
                RadGridLocalizationProvider.CurrentProvider = new MySpanishRadGridLocalizationProvider();
                grdItems.Columns.Clear();
                grdItems.AllowAddNewRow = false;
                GridViewCommandColumn commandColumn;

                commandColumn = new GridViewCommandColumn();
                commandColumn.Name = "Imprimir";
                commandColumn.HeaderText = @"Imprimir";
                commandColumn.DefaultText = @"Imprimir";
                commandColumn.UseDefaultText = true;
                grdItems.Columns.Add(commandColumn);
                grdItems.Columns["Imprimir"].AllowSort = false;
                grdItems.Columns["Imprimir"].AllowFiltering = false;
                grdItems.Columns.Add("COPE_NumDoc", "Número Operación", "COPE_NumDoc");
                grdItems.Columns.Add("COPE_FecEmi", "Fecha Emisión", "COPE_FecEmi");
                grdItems.Columns.Add("Cliente", "Cliente", "Cliente");
                grdItems.Columns.Add("COPE_HBL", "HBL", "COPE_HBL");
                grdItems.Columns.Add("MonedaSTR", "Moneda", "MonedaSTR");
                grdItems.Columns.Add("CONS_CodEstadoSTR", "Estado", "CONS_CodEstadoSTR");
                grdItems.Columns.Add("COPE_Observacion", "Observacación", "COPE_Observacion");
                grdItems.BestFitColumns();
                GridAutoFit.Fit(grdItems);
            }
            catch (Exception ex)
            { Dialogos.MostrarMensajeError(Presenter.Titulo, Mensajes.FormatDataGridView, ex); }
        }
        private void SeleccionarItem()
        {
            try
            {
                if (Presenter != null)
                {
                    if (BSItems != null && BSItems.Current != null && BSItems.Current is DataRowView)
                    {
                        Int32 xCOPE_Codigo;
                        if (Int32.TryParse(((DataRowView)(BSItems.Current)).Row["COPE_Codigo"].ToString(), out xCOPE_Codigo))
                        {
                            Presenter.COPE_Codigo = xCOPE_Codigo;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                if (Presenter != null) Dialogos.MostrarMensajeError(Presenter.Titulo, "Ha ocurrido un error al seleccionar el item.", ex);
            }
        }
        private void Buscar()
        {
            try
            {
                EliminarFiltros();
                Presenter.Actualizar();
            }
            catch (Exception ex)
            { Dialogos.MostrarMensajeError(Presenter.Titulo, "Ha ocurrido un error al buscar.", ex); }
        }
        private void Deshacer()
        {
            try
            {
                EliminarFiltros();
                BSItems.DataSource = null;
                grdItems.DataSource = BSItems;
                navItems.BindingSource = BSItems;
                BSItems.ResetBindings(true);
                grdItems.Enabled = true;
                Presenter.ENTC_CodigoFiltro = null;
                TxtNroOperacion.Clear();
                txtHBL.Clear();
                mdtFecDesde.NSFecha = DateTime.Now.AddMonths(-1);
                mdtFecHasta.NSFecha = DateTime.Now.AddMonths(2);
                AyudaCliente.ClearValue();
            }
            catch (Exception ex)
            { Dialogos.MostrarMensajeError(Presenter.Titulo, "Ha ocurrido un error al deshacer la vista.", ex); }
        }
        private void EliminarFiltros()
        {
            for (int i = 0; i < grdItems.ColumnCount; i++)
            {
                grdItems.FilterDescriptors.Clear();
            }
        }

        #endregion

        #region [ Eventos ]
        private void btnBuscar_Click(object sender, EventArgs e)
        { Buscar(); }
        private void btnDeshacer_Click(object sender, EventArgs e)
        { Deshacer(); }
        private void BSItems_CurrentItemChanged(object sender, EventArgs e)
        { SeleccionarItem(); }
        void grdItems_CommandCellClick(object sender, EventArgs e)
        {
            try
            {
                if (sender is GridCommandCellElement)
                {
                    switch ((((GridCommandCellElement)(sender)).CommandButton).TextElement.Text)
                    {
                        case "Imprimir":
                            SeleccionarItem();
                            Presenter.ImprimirFactura();
                            break;
                    }
                }
            }
            catch (Exception ex)
            { Dialogos.MostrarMensajeError(Presenter.Titulo, "Ha ocurrido un error al cargar los botones para editar y eliminar.", ex); }
        }
        void grdItems_CellFormatting(object sender, CellFormattingEventArgs e)
        {
            if (e.CellElement is GridCommandCellElement)
            {
                if (e.Column.Name.Equals("Imprimir"))
                {
                    var bte = (RadButtonElement)e.CellElement.Children[0];
                    if (bte.Image == null)
                    {
                        bte.TextImageRelation = TextImageRelation.Overlay;
                        bte.DisplayStyle = DisplayStyle.Image;
                        bte.ImageAlignment = ContentAlignment.MiddleCenter;
                        bte.Image = Resources.printer2;
                        bte.ToolTipText = @"Imprimir";
                        bte.AutoSize = true;
                    }
                }
            }
        }
        #endregion

        #region [ IFormClose ]
        private void TitleView_FormClose(object sender, EventArgs e)
        {
            if (CloseForm != null)
            {
                CloseForm(null, new FormCloseEventArgs(TabPageControl, Presenter.CUS));
            }
        }
        public event FormCloseEventArgs.FormCloseEventHandler CloseForm;
        #endregion
    }
}
