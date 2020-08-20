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

namespace Delfin.Principal
{
   public partial class REP001LView : UserControl, IREP001LView
   {
      #region [ Variables ]

      #endregion

      #region [ Formulario ]
      public REP001LView(Telerik.WinControls.UI.RadPageViewPage x_tabPageControl)
      {
         InitializeComponent();
         try
         {
            TabPageControl = x_tabPageControl;

            btnBuscar.Click += new EventHandler(btnBuscar_Click);
            btnDeshacer.Click += new EventHandler(btnDeshacer_Click);
            btnExportar.Click += new EventHandler(btnExportar_Click);

            TIPO_CodPAIOrigen.SelectedIndexChanged += TIPO_CodPAIOrigen_SelectedIndexChanged;

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
      public REP001Presenter Presenter { get; set; }
      public BindingSource BSItems { get; set; }
      #endregion

      #region [ IREP001LView ]
      public void LoadView()
      {
         try
         {
            ENTC_CodCliente.ContainerService = Presenter.ContainerService;
            ENTC_CodTransportista.ContainerService = Presenter.ContainerService;

            TIPO_CodCDT.LoadControl(Presenter.ContainerService, "Tabla de Comodity", "CDT", "< Seleccionar Comodity >", ListSortDirection.Ascending);
            TIPO_CodTRF.LoadControl(Presenter.ContainerService, "Tabla de Comodity", "TRF", "< Seleccionar Tráfico >", ListSortDirection.Ascending);
            TIPO_CodPAIOrigen.LoadControl(Presenter.ContainerService, "Tabla Países Origen", "PAI", "< Seleccionar País Origen >", ListSortDirection.Ascending);

            FormatDataGrid();
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error cargando la vista.", ex); }
      }
      public void ShowItems()
      {
         try
         {
            BSItems.DataSource = Presenter.DTReporte;
            grdItems.DataSource = BSItems;
            //navItems.BindingSource = BSItems;
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

            this.grdItems.Columns["DCOT_Cantidad"].FormatString = "{0:###,##0}";

            grdItems.ShowFilteringRow = false;
            grdItems.EnableFiltering = false;
            grdItems.MasterTemplate.EnableFiltering = false;
            grdItems.EnableGrouping = false;
            grdItems.MasterTemplate.EnableGrouping = false;
            grdItems.EnableSorting = false;
            grdItems.MasterTemplate.EnableCustomSorting = false;
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error cargando los items.", ex); }
      }
      #endregion

      #region [ Metodos ]
      private void FormatDataGrid()
      {
         try
         {
            Telerik.WinControls.UI.Localization.RadGridLocalizationProvider.CurrentProvider = new Infrastructure.WinForms.Controls.MySpanishRadGridLocalizationProvider();
            this.grdItems.Columns.Clear();
            this.grdItems.AllowAddNewRow = false;

            this.grdItems.Columns.Add("CCOT_FecConcluye", "Fecha Conclusión", "CCOT_FecConcluye");
            this.grdItems.Columns.Add("ENTC_NomEjecutivo", "Ejecutivo", "ENTC_NomEjecutivo");
            this.grdItems.Columns.Add("ENTC_NomCustomer", "Customer", "ENTC_NomCustomer");
            this.grdItems.Columns.Add("ENTC_NomCliente", "Cliente", "ENTC_NomCliente");
            this.grdItems.Columns.Add("CCOT_NumDoc", "Orden de Venta", "CCOT_NumDoc");
            this.grdItems.Columns.Add("DOOV_HBL", "HBL", "DOOV_HBL");
            this.grdItems.Columns.Add("ENTC_NomTransportista", "Línea", "ENTC_NomTransportista");
            this.grdItems.Columns.Add("CONT_Numero", "S/C", "CONT_Numero");
            this.grdItems.Columns.Add("PACK_Desc", "Tipo Contenedor", "PACK_Desc");
            this.grdItems.Columns.Add("DCOT_Cantidad", "Cantidad Contenedores", "DCOT_Cantidad");
            this.grdItems.Columns.Add("DCOT_TEUS", "TEUS", "DCOT_TEUS");
            this.grdItems.Columns.Add("TIPO_DescCDT", "Mercadería", "TIPO_DescCDT");
            this.grdItems.Columns.Add("TIPO_DescTRF", "Tráfico", "TIPO_DescTRF");
            this.grdItems.Columns.Add("PUER_NombreOrigen", "Puerto Embarque", "PUER_NombreOrigen");
            this.grdItems.Columns.Add("PUER_NombreDestino", "Puerto Destino", "PUER_NombreDestino");
            this.grdItems.Columns.Add("NVIA_FecETDMaster", "Fecha Embarque", "NVIA_FecETDMaster");
            this.grdItems.Columns.Add("DCOT_TotalUniCosto", "Flete Costo", "DCOT_TotalUniCosto");
            this.grdItems.Columns.Add("DCOT_TotalUniVenta", "Flete Venta", "DCOT_TotalUniVenta");
            this.grdItems.Columns.Add("DCOT_Profit", "Diferencial", "DCOT_Profit");
            this.grdItems.Columns.Add("DCOT_RebateLinea", "Rebate de Línea", "DCOT_RebateLinea");
            this.grdItems.Columns.Add("DCOT_Comision", "Comisión Vendedor", "DCOT_Comision");
            this.grdItems.Columns.Add("DCOT_RebateCliente", "Rebate al Cliente", "DCOT_RebateCliente");
            this.grdItems.Columns.Add("DCOT_Rentabilidad", "Rentabilidad Total", "DCOT_Rentabilidad");

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
      private void LoadPuertosOrigen()
      {
         try
         {
            Boolean _inicializar = true;
            if (TIPO_CodPAIOrigen.TiposSelectedItem != null)
            {
               ObservableCollection<Entities.Puerto> _items = Presenter.ListPuertos.Where(puer => puer.TIPO_CodPais == TIPO_CodPAIOrigen.TiposSelectedItem.TIPO_CodTipo && puer.PUER_Favorito).ToObservableCollection();
               if (_items != null && _items.Count > 0)
               {
                  foreach (Entities.Puerto _puerto in _items)
                  {
                     PUER_CodOrigen.AddComboBoxItem(_puerto.PUER_Codigo, _puerto.PUER_Nombre, _inicializar);
                     _inicializar = false;
                  }
                  PUER_CodOrigen.LoadComboBox("< Seleccionar Puerto Origen >", ListSortDirection.Ascending);
                  PUER_CodOrigen.Enabled = true;
               }
               else
               {
                  PUER_CodOrigen.DataSource = null;
                  PUER_CodOrigen.Enabled = false;
               }
            }
            else
            {
               PUER_CodOrigen.DataSource = null;
               PUER_CodOrigen.Enabled = false;
            }
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al cargar los puertos de origen.", ex); }
      }

      private void Buscar()
      {
         try
         {
            Nullable<DateTime> _CCOT_FechaDesde = CCOT_FechaDesde.NSFecha;
            Nullable<DateTime> _CCOT_FechaHasta = CCOT_FechaHasta.NSFecha;
            Nullable<Int32> _ENTC_CodCliente = null; if (ENTC_CodCliente.Value != null && ENTC_CodCliente.Value.ENTC_Codigo > 0) { _ENTC_CodCliente = ENTC_CodCliente.Value.ENTC_Codigo; }
            Nullable<Int32> _ENTC_CodTransportista = null; if (ENTC_CodTransportista.Value != null && ENTC_CodTransportista.Value.ENTC_Codigo > 0) { _ENTC_CodTransportista = ENTC_CodTransportista.Value.ENTC_Codigo; }
            String _TIPO_TabCDT = null; if (TIPO_CodCDT.TiposSelectedItem != null) { _TIPO_TabCDT = TIPO_CodCDT.TiposSelectedItem.TIPO_CodTabla; }
            String _TIPO_CodCDT = null; if (TIPO_CodCDT.TiposSelectedItem != null) { _TIPO_CodCDT = TIPO_CodCDT.TiposSelectedItem.TIPO_CodTipo; }
            String _TIPO_TabTRF = null; if (TIPO_CodTRF.TiposSelectedItem != null) { _TIPO_TabTRF = TIPO_CodTRF.TiposSelectedItem.TIPO_CodTabla; }
            String _TIPO_CodTRF = null; if (TIPO_CodTRF.TiposSelectedItem != null) { _TIPO_CodTRF = TIPO_CodTRF.TiposSelectedItem.TIPO_CodTipo; }
            Nullable<Int32> _PUER_Codigo = PUER_CodOrigen.ComboIntSelectedValue; 
            
            Presenter.CargarReporte(_CCOT_FechaDesde, _CCOT_FechaHasta, _ENTC_CodCliente, _ENTC_CodTransportista, _TIPO_TabCDT, _TIPO_CodCDT, _TIPO_TabTRF, _TIPO_CodTRF, _PUER_Codigo);
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al llamar al reporte.", ex); }
      }
      private void Deshacer()
      {
         try
         {
            Presenter.LimpiarReporte(); 
            
            ENTC_CodCliente.ClearValue();
            ENTC_CodCliente.Text = string.Empty;
            CCOT_FechaDesde.NSFecha = null;
            CCOT_FechaHasta.NSFecha = null;
            TIPO_CodCDT.TiposSelectedValue = null;
            TIPO_CodTRF.TiposSelectedValue = null;
            TIPO_CodPAIOrigen.TiposSelectedValue = null;

            BSItems.DataSource = null;
            grdItems.DataSource = BSItems;
            BSItems.ResetBindings(true);

            grdItems.Enabled = true;
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
      #endregion

      #region [ Eventos ]
      private void btnBuscar_Click(object sender, EventArgs e)
      { Buscar(); }
      private void btnDeshacer_Click(object sender, EventArgs e)
      { Deshacer(); }
      private void btnExportar_Click(object sender, EventArgs e)
      { Exportar(); }

      private void TIPO_CodPAIOrigen_SelectedIndexChanged(object sender, EventArgs e)
      { LoadPuertosOrigen(); }
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
