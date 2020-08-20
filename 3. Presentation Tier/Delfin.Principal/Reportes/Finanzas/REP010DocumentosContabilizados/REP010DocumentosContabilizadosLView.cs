using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Delfin.Principal
{
   public partial class REP010DocumentosContabilizadosLView : UserControl, IREP010DocumentosContabilizadosLView
   {
      #region [ Variables ]

      #endregion

      #region [ Formulario ]

      public REP010DocumentosContabilizadosLView(Telerik.WinControls.UI.RadPageViewPage x_tabPageControl)
      {
         InitializeComponent();
         try
         {
            TabPageControl = x_tabPageControl;
            btnBuscar.Click += btnBuscar_Click;
            btnExportar.Click += new EventHandler(btnExportar_Click);

            BSItems = new BindingSource();

            TitleView.FormClose += new EventHandler(TitleView_FormClose);
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error inicializando el formulario LView.", ex); }
      }

      #endregion

      #region [ Propiedades ]

      public Telerik.WinControls.UI.RadPageViewPage TabPageControl { get; set; }
      public Image IconView { get { return TitleView.FormIcon; } set { TitleView.FormIcon = value; } }
      public REP010DocumentosContabilizadosPresenter Presenter { get; set; }
      public BindingSource BSItems { get; set; }

      #endregion

      #region [ ICUS002MView ]

      public void LoadView()
      {
         try
         {
            this.TitleView.Caption = Presenter.Title;

            cmbTipoResultado.LoadControl("Tipo de Resultado", Delfin.Controls.Tipos.ComboBoxConstantes.OConstantes.TipoResultadoRepOT, "< Todos >", ListSortDirection.Ascending);

            dtpFecIni.NSFecha = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            dtpFecFin.NSFecha = DateTime.Now;

            FormatDataGrid();

            grdItems.Enabled = false;
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error cargando la vista.", ex); }
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

            this.grdItems.Columns.Add("NVIA_Codigo", "Código Viaje", "NVIA_Codigo");
            this.grdItems.Columns.Add("NVIA_NroViaje", "Nro. Viaje", "NVIA_NroViaje");
            this.grdItems.Columns.Add("CCOT_NumDoc", "Orden Venta", "CCOT_NumDoc");
            this.grdItems.Columns.Add("NVIA_FecPreFactura", "Fec. Prefactura", "NVIA_FecPreFactura");
            this.grdItems.Columns.Add("NVIA_FecETA_IMPO_ETD_EXPO", "Fecha ETA/ETD", "NVIA_FecETA_IMPO_ETD_EXPO");
            this.grdItems.Columns.Add("CCCT_FechaEmision", "Fecha Emisión", "CCCT_FechaEmision");
            this.grdItems.Columns.Add("SCOT_FechaOperacion", "Fec. Operación (CC)", "SCOT_FechaOperacion");
            this.grdItems.Columns.Add("AsientoContable", "Asiento Inicial", "AsientoContable");
            this.grdItems.Columns.Add("AsientoContableC", "Asiento Compras", "AsientoContableC");
            this.grdItems.Columns.Add("AsientoContableA", "Asientos Adicionales", "AsientoContableA");
            this.grdItems.Columns.Add("Origen", "Origen", "Origen");
            this.grdItems.Columns.Add("CONS_Desc_SPA", "Servicio", "CONS_Desc_SPA");

            this.grdItems.Columns.Add("TIPO_TDO", "Tip. Documento", "TIPO_TDO");
            this.grdItems.Columns.Add("CCCT_Serie", "Serie", "CCCT_Serie");
            this.grdItems.Columns.Add("CCCT_Numero", "Numero", "CCCT_Numero");
            this.grdItems.Columns.Add("ENTC_DocIden", "RUC", "ENTC_DocIden");
            this.grdItems.Columns.Add("ENTC_RazonSocial", "Razon Social", "ENTC_RazonSocial");
            this.grdItems.Columns.Add("TIPO_MND", "Moneda", "TIPO_MND");
            this.grdItems.Columns.Add("CCCT_ValVta", "Base", "CCCT_ValVta");
            this.grdItems.Columns.Add("CCCT_Imp1", "IGV", "CCCT_Imp1");
            this.grdItems.Columns.Add("CCCT_Imp3", "Renta 3ra", "CCCT_Imp3");
            this.grdItems.Columns.Add("CCCT_Imp4", "Imp. 4ta", "CCCT_Imp4");
            this.grdItems.Columns.Add("CCCT_Monto", "Total", "CCCT_Monto");
            this.grdItems.Columns.Add("CCCT_TipoCambio", "Tipo Cambio", "CCCT_TipoCambio");
            this.grdItems.Columns.Add("servicioOrigen", "Origen OP", "servicioOrigen");

            this.grdItems.Columns.Add("CCCT_Codigo", "Interno Doc.", "CCCT_Codigo");

            this.grdItems.Columns["NVIA_FecPreFactura"].FormatString = "{0:dd/MM/yyyy}";
            this.grdItems.Columns["NVIA_FecETA_IMPO_ETD_EXPO"].FormatString = "{0:dd/MM/yyyy}";
            this.grdItems.Columns["CCCT_FechaEmision"].FormatString = "{0:dd/MM/yyyy}";

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
               grdItems.Columns["CCCT_TipoCambio"].FormatString = "{0:0.0000}";
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

      private void Buscar()
      {
         try
         {
            GetFiltro();
            if ((dtpFecIni.NSFecha.HasValue && dtpFecFin.NSFecha.HasValue))
            {
               EliminarFiltros();
               Presenter.Actualizar();
            }
            else { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Presenter.Title, "Para realizar la consulta debe ingresar los rangos de fecha."); }
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al buscar.", ex); }
      }

      private void GetFiltro()
      {
         try
         {
            Presenter.F_TipoResultado = null; if (cmbTipoResultado.ConstantesSelectedItem != null) { Presenter.F_TipoResultado = cmbTipoResultado.ConstantesSelectedItem.CONS_CodTipo; }
            Presenter.F_FecIni = dtpFecIni.NSFecha;
            Presenter.F_FecFin = dtpFecFin.NSFecha;
         }
         catch (Exception)
         { throw; }
      }

      public void EliminarFiltros()
      {
         try
         {
            for (int i = 0; i < grdItems.ColumnCount; i++)
            {
               grdItems.FilterDescriptors.Clear();
            }
         }
         catch (Exception)
         { }
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

      #endregion

      #region [ Eventos ]

      private void TitleView_FormClose(object sender, EventArgs e)
      {
         if (CloseForm != null)
         {
            CloseForm(null, new Infrastructure.Client.FormClose.FormCloseEventArgs(this.TabPageControl, Presenter.CUS));
         }
      }

      private void btnExportar_Click(object sender, EventArgs e)
      { Exportar(); }

      private void btnBuscar_Click(object sender, EventArgs e)
      { Buscar(); }

      public event Infrastructure.Client.FormClose.FormCloseEventArgs.FormCloseEventHandler CloseForm;

      #endregion

   }
}
