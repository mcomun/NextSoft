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
   public partial class REP015StatusComprobantesLView : UserControl, IREP015StatusComprobantesLView
   {
      #region [ Variables ]

      #endregion

      #region [ Formulario ]

      public REP015StatusComprobantesLView(Telerik.WinControls.UI.RadPageViewPage x_tabPageControl)
      {
         InitializeComponent();
         try
         {
            TabPageControl = x_tabPageControl;
            btnBuscar.Click += btnBuscar_Click;
            btnExportar.Click += btnExportar_Click;

            TitleView.FormClose += new EventHandler(TitleView_FormClose);
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error inicializando el formulario LView.", ex); }
      }

      #endregion

      #region [ Propiedades ]

      public Telerik.WinControls.UI.RadPageViewPage TabPageControl { get; set; }
      public Image IconView { get { return TitleView.FormIcon; } set { TitleView.FormIcon = value; } }
      public REP015StatusComprobantesPresenter Presenter { get; set; }
      public BindingSource BSItems { get; set; }
      public String MensajeError { get; set; }

      #endregion

      #region [ REP015StatusComprobantesLView ]

      public void LoadView()
      {
         try
         {
            FormatDataGrid();

            grdItems.Enabled = false;
            btnBuscar.Enabled = true;
            btnExportar.Enabled = false;

            BSItems = new BindingSource();
            this.TitleView.Text = Presenter.Title;
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

      private void Buscar()
      {
         try
         {
            Presenter.F_ENTC_Codigo = null;
            if (txaENTC_Codigo.SelectedItem != null)
            { Presenter.F_ENTC_Codigo = txaENTC_Codigo.SelectedItem.ENTC_Codigo; }

            Presenter.F_FecIni = dtpFecIni.NSFecha;
            Presenter.F_FecFin = dtpFecFin.NSFecha;
            Presenter.F_NVIA_Codigo = null;
            if (txaNVIA_NroViaje.Value != null)
            { Presenter.F_NVIA_Codigo = (txaNVIA_NroViaje.Value as Entities.NaveViaje).NVIA_Codigo; }

            if (Presenter.F_FecIni.HasValue && Presenter.F_FecIni.HasValue && Presenter.F_FecIni.Value.Date <= Presenter.F_FecIni.Value.Date)
            { Presenter.Actualizar(); }
            else
            {
               Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Presenter.Title, "Debe seleccionar un rango de fechas valido.");
               //Presenter.FILTROItemCONSRGM = CONS_CodRGM.ConstantesSelectedItem;
               //Presenter.FILTROItemCONSFLE = CONS_CodFLE.ConstantesSelectedItem;

               
            }
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al buscar.", ex); }
      }

      private Boolean Validar()
      {
         try
         {
            Boolean iscorrect = true;
            MensajeError = "";
            //if (Presenter.F_FecIni == null)
            //{
            //   iscorrect = false;
            //   MensajeError += "* Se debe registrar una fecha de Desde" + Environment.NewLine;
            //}
            if (Presenter.F_FecFin == null)
            {
               iscorrect = false;
               MensajeError += "* Se debe registrar una fecha Hasta" + Environment.NewLine;
            }

            return iscorrect;
         }
         catch (Exception)
         { throw; }
      }

      void FormatDataGrid()
      {
         try
         {
            Telerik.WinControls.UI.Localization.RadGridLocalizationProvider.CurrentProvider = new Infrastructure.WinForms.Controls.MySpanishRadGridLocalizationProvider();
            this.grdItems.Columns.Clear();
            this.grdItems.AllowAddNewRow = false;

            this.grdItems.Columns.Add("Operacion", "Operacion", "Operacion");
            this.grdItems.Columns.Add("nave", "nave", "nave");
            this.grdItems.Columns.Add("viaje", "viaje", "viaje");
            this.grdItems.Columns.Add("cliente", "cliente", "cliente");
            this.grdItems.Columns.Add("comprobante", "comprobante", "comprobante");
            this.grdItems.Columns.Add("sucursal", "sucursal", "sucursal");
            this.grdItems.Columns.Add("numero", "numero", "numero");
            this.grdItems.Columns.Add("concepto", "concepto", "concepto");
            this.grdItems.Columns.Add("desc_concepto", "desc_concepto", "desc_concepto");
            this.grdItems.Columns.Add("importe", "importe", "importe");
            this.grdItems.Columns.Add("status", "status", "status");
            this.grdItems.Columns.Add("fecha_cob", "fecha_cob", "fecha_cob");
            this.grdItems.Columns.Add("tipo_cbte", "tipo_cbte", "tipo_cbte");

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
            navItems.BindingSource = BSItems;
            BSItems.ResetBindings(true);

            grdItems.Enabled = true;
            btnBuscar.Enabled = true;
            btnExportar.Enabled = false;
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al deshacer la vista.", ex); }
      }

      #endregion

      #region [ Eventos ]

      private void btnBuscar_Click(object sender, EventArgs e)
      { Buscar(); }

      private void btnExportar_Click(object sender, EventArgs e)
      { Exportar(); }

      private void btnDeshacer_Click(object sender, EventArgs e)
      { Deshacer(); }

      #endregion

      #region [ IFormClose ]
      private void TitleView_FormClose(object sender, EventArgs e)
      {
         if (CloseForm != null)
         {
            Presenter.CloseView();
            //BusinessLogic.Colecciones.Inicializar(Presenter.Container);
            CloseForm(null, new Infrastructure.Client.FormClose.FormCloseEventArgs(this.TabPageControl, Presenter.CUS));
         }
      }
      public event Infrastructure.Client.FormClose.FormCloseEventArgs.FormCloseEventHandler CloseForm;
      #endregion

   }
}
