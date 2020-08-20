using System;
using System.Collections.Generic;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections.ObjectModel;
using Infrastructure.Aspect.Collections;
using System.ComponentModel;
using Telerik.WinControls.UI;

namespace Delfin.Principal
{
   public partial class CAJ018AsientosStatementLView : UserControl, ICAJ018AsientosStatementLView
   {
      #region [ Variables ]
      #endregion

      #region [ Formulario ]

      public CAJ018AsientosStatementLView(Telerik.WinControls.UI.RadPageViewPage x_tabPageControl)
      {
         InitializeComponent();
         try
         {
            TabPageControl = x_tabPageControl;

            btnDeshacer.Click += new EventHandler(btnDeshacer_Click);
            btnProcesarAsientos.Click += btnProcesarAsientos_Click;
            btnBuscar.Click += btnBuscar_Click;

            TitleView.FormClose += new EventHandler(TitleView_FormClose);

            BSItems = new BindingSource();
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error inicializando el formulario LView.", ex); }
      }

      #endregion

      #region [ Propiedades ]
      public Telerik.WinControls.UI.RadPageViewPage TabPageControl { get; set; }
      public Image IconView { get { return TitleView.FormIcon; } set { TitleView.FormIcon = value; } }
      public CAJ018AsientosStatementPresenter Presenter { get; set; }

      public BindingSource BSItems { get; set; }

      #endregion

      #region [ ICAJ018AsientosStatementLView ]
      public void LoadView()
      {
         try
         {
            btnProcesarAsientos.Enabled = true;

            panelCaption3.Visible = false;
            tableLayoutPanel2.Visible = false;

            cmbCONS_CodVia.LoadControl(Presenter.ContainerService, "Tipos de Vía", "VIA", "<Seleccione una Vía>", ListSortDirection.Ascending);
            cmbCONS_CodRGM.LoadControl(Presenter.ContainerService, "Tipos de Régimen", "RGM", "< Seleccionar Régimen >", ListSortDirection.Ascending);
            cmbCONS_CodLNG.LoadControl(Presenter.ContainerService, "Constantes Línea de Negocio", "LNG", "< Seleccionar Línea Negocio >", ListSortDirection.Ascending);

            cmbCONS_CodLNG.SelectedValue = "001";

            FormatDataGrid();
            ShowComboNaves();

            DateTime Fecha = DateTime.Now;
            dtpFecIni.NSFecha = new DateTime(Fecha.Year, Fecha.Month, 1);
            dtpFecFin.NSFecha = new DateTime(Fecha.Year, Fecha.Month, 1).AddMonths(1).AddDays(-1);

         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error cargando la vista.", ex); }
      }

      #endregion

      #region [ Metodos ]

      private void Buscar()
      {
         try
         {
            Presenter.F_FecIni = dtpFecIni.NSFecha;
            Presenter.F_FecFin = dtpFecFin.NSFecha;
            if (Presenter.F_FecIni.HasValue && Presenter.F_FecFin.HasValue)
            {
               Presenter.F_CONS_CodLNG = null; Presenter.F_CONS_TabLNG = null;
               if (cmbCONS_CodLNG.ConstantesSelectedItem != null)
               {
                  Presenter.F_CONS_CodLNG = cmbCONS_CodLNG.ConstantesSelectedItem.CONS_CodTipo;
                  Presenter.F_CONS_TabLNG = cmbCONS_CodLNG.ConstantesSelectedItem.CONS_CodTabla;
               }

               Presenter.F_CONS_TabRGM = null; Presenter.F_CONS_CodRGM = null;
               if (cmbCONS_CodRGM.ConstantesSelectedItem != null)
               {
                  Presenter.F_CONS_TabRGM = cmbCONS_CodRGM.ConstantesSelectedItem.CONS_CodTabla;
                  Presenter.F_CONS_CodRGM = cmbCONS_CodRGM.ConstantesSelectedItem.CONS_CodTipo;
               }

               Presenter.F_CONS_TabVIA = null; Presenter.F_CONS_CodVIA = null;
               if (cmbCONS_CodVia.ConstantesSelectedItem != null)
               {
                  Presenter.F_CONS_TabVIA = cmbCONS_CodVia.ConstantesSelectedItem.CONS_CodTabla;
                  Presenter.F_CONS_CodVIA = cmbCONS_CodVia.ConstantesSelectedItem.CONS_CodTipo;
               }

               Presenter.F_NVIA_NroViaje = null; if (!String.IsNullOrEmpty(NVIA_NroViaje.Text)) { Presenter.F_NVIA_NroViaje = NVIA_NroViaje.Text; }
               Presenter.F_NAVE_Nombre = null; if (NAVE_Codigo.SelectedItem != null && ((Entities.Nave)NAVE_Codigo.SelectedItem).NAVE_Codigo > 0 && !String.IsNullOrEmpty(NAVE_Codigo.Text)) { Presenter.F_NAVE_Nombre = NAVE_Codigo.Text; }

               EliminarFiltros();

               Presenter.Actualizar();
            }
            else
            { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Presenter.Title, "Se debe seleccionar un rango de Fecha Valido"); }

         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido al realizar la busqueda.", ex); }
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
               //btnExportar.Enabled = true;
               //Infrastructure.WinForms.Controls.GridAutoFit.Fit(this.grdItems);
               grdItems.BestFitColumns();
            }
            else
            {
               grdItems.Enabled = false;
               //btnExportar.Enabled = false;
            }

            grdItems.ShowFilteringRow = true;
            grdItems.EnableFiltering = true;
            grdItems.MasterTemplate.EnableFiltering = true;
            grdItems.EnableGrouping = false;
            grdItems.MasterTemplate.EnableGrouping = false;
            grdItems.EnableSorting = true;
            grdItems.MasterTemplate.EnableCustomSorting = false;

         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error cargando los items.", ex); }
      }

      private Boolean getFiltros()
      {
         try
         {
            Presenter.F_FecIni = null; Presenter.F_FecFin = null;

            if (dtpFecIni.NSFecha.HasValue && dtpFecFin.NSFecha.HasValue)
            {
               Presenter.F_FecIni = dtpFecIni.NSFecha;
               Presenter.F_FecFin = dtpFecFin.NSFecha;

               return true;
            }
            else
            {
               String _msg = "";
               if (!dtpFecIni.NSFecha.HasValue) { _msg += String.Format("- Debe ingresar una fecha de Inicio.{0}", Environment.NewLine); }
               if (!dtpFecFin.NSFecha.HasValue) { _msg += String.Format("- Debe ingresar una fecha de Termino.{0}", Environment.NewLine); }
               if (!String.IsNullOrEmpty(_msg))
               { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Presenter.Title, "Existen algunos campos obligatorios, haga click de detalles para ver cuales son.", _msg); }
               return false;
            }
         }
         catch (Exception)
         { return false; }
      }

      private void ProcesarAsientos()
      {
         try
         {
            if (BSItems != null && BSItems.DataSource != null)
            {
               grdItems.EndEdit();
               Presenter.ItemsNaveViaje = new ObservableCollection<Entities.NaveViaje>();
               foreach (DataRow item in ((DataTable)BSItems.DataSource).Rows)
               {
                  if (((Boolean)item["Seleccionar"]))
                  {
                     Entities.NaveViaje _naveviaje = new Entities.NaveViaje();
                     _naveviaje.NVIA_Codigo = Int32.Parse(item["NVIA_Codigo"].ToString());
                     _naveviaje.AUDI_UsrCrea = Presenter.Session.UserName;
                     _naveviaje.SUCR_Codigo = Delfin.Controls.Entorno.ItemSucursal.SUCR_Codigo;
                     _naveviaje.EMPR_Codigo = Delfin.Controls.Entorno.ItemEmpresa.EMPR_Codigo;
                     Presenter.ItemsNaveViaje.Add(_naveviaje);
                  }
               }
               if (Presenter.ItemsNaveViaje.Count > 0)
               {
                  if (Presenter.ProcesarAsiento())
                  {
                     Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeSatisfactorio(Presenter.Title, "Se ha Procesado Satisfactoriamente");
                     Presenter.Actualizar();
                  }
                  else { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Presenter.Title, "No se procesaron registros validos"); }
               }
               else { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Presenter.Title, "No se ha seleccionado ningun registro para ser procesado"); }
            }
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error, no se puede procesar la solicitud de generar asientos.", ex); }
      }

      private void Deshacer()
      {
         try
         {
            btnProcesarAsientos.Enabled = true;
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al deshacer la vista.", ex); }
      }

      private void FormatDataGrid()
      {
         try
         {
            Telerik.WinControls.UI.Localization.RadGridLocalizationProvider.CurrentProvider = new Infrastructure.WinForms.Controls.MySpanishRadGridLocalizationProvider();
            this.grdItems.Columns.Clear();
            this.grdItems.AllowAddNewRow = false;
            Telerik.WinControls.UI.GridViewCommandColumn commandColumn;

            GridViewCheckBoxColumn checkboxColum;
            checkboxColum = new GridViewCheckBoxColumn();
            checkboxColum.Name = "Seleccionar";
            checkboxColum.HeaderText = "Seleccionar";
            checkboxColum.FieldName = "Seleccionar";
            this.grdItems.Columns.Add(checkboxColum);
            this.grdItems.Columns["Seleccionar"].Width = 90;
            this.grdItems.Columns["Seleccionar"].ReadOnly = false;

            this.grdItems.Columns.Add("NVIA_Codigo", "Código", "NVIA_Codigo");
            this.grdItems.Columns.Add("NAVE_Nombre", "NAVE", "NAVE_Nombre");
            this.grdItems.Columns.Add("NVIA_NroViaje", "NroViaje", "NVIA_NroViaje");
            this.grdItems.Columns.Add("NVIA_FecETA_IMPO_ETD_EXPO", "Fecha ETA/ETD", "NVIA_FecETA_IMPO_ETD_EXPO");
            this.grdItems.Columns.Add("NVIA_FecPreFactura", "Fecha Pre-Factura", "NVIA_FecPreFactura");

            this.grdItems.Columns.Add("AsientoContable", "Nro. Asiento", "AsientoContable");
            this.grdItems.Columns.Add("CONS_DescRGM", "Régimen", "CONS_DescRGM");
            this.grdItems.Columns.Add("CONS_DescVIA", "Via", "CONS_DescVIA");
            this.grdItems.Columns.Add("ENTC_NomTransp", "Transportista", "ENTC_NomTransp");
            this.grdItems.Columns.Add("DocsMandato", "Doc. Mandato", "DocsMandato");
            this.grdItems.Columns.Add("NVIA_DesEstado", "Estado", "NVIA_DesEstado");

            this.grdItems.Columns["NVIA_Codigo"].ReadOnly = true;
            this.grdItems.Columns["NAVE_Nombre"].ReadOnly = true;
            this.grdItems.Columns["NVIA_NroViaje"].ReadOnly = true;

            this.grdItems.Columns["NVIA_FecETA_IMPO_ETD_EXPO"].ReadOnly = true;
            this.grdItems.Columns["NVIA_FecETA_IMPO_ETD_EXPO"].FormatString = "{0:dd/MM/yyyy}";
            this.grdItems.Columns["NVIA_FecPreFactura"].ReadOnly = true;
            this.grdItems.Columns["NVIA_FecPreFactura"].FormatString = "{0:dd/MM/yyyy}";

            this.grdItems.Columns["AsientoContable"].ReadOnly = true;
            this.grdItems.Columns["AsientoContable"].ReadOnly = true;
            this.grdItems.Columns["CONS_DescRGM"].ReadOnly = true;
            this.grdItems.Columns["CONS_DescVIA"].ReadOnly = true;
            this.grdItems.Columns["ENTC_NomTransp"].ReadOnly = true;
            this.grdItems.Columns["DocsMandato"].ReadOnly = true;

            grdItems.BestFitColumns();

            grdItems.SelectionMode = Telerik.WinControls.UI.GridViewSelectionMode.FullRowSelect;
            grdItems.MultiSelect = true;
            grdItems.ReadOnly = false;
            grdItems.ShowFilteringRow = false;
            grdItems.EnableFiltering = false;
            grdItems.MasterTemplate.EnableFiltering = false;
            grdItems.EnableGrouping = false;
            grdItems.MasterTemplate.EnableGrouping = false;
            grdItems.EnableSorting = false;
            grdItems.MasterTemplate.EnableCustomSorting = false;
            grdItems.AutoGenerateColumns = false;
            grdItems.AllowCellContextMenu = false;
            grdItems.AllowColumnHeaderContextMenu = false;
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

         NAVE_Codigo.Text = String.Empty; NAVE_Codigo.AutoCompleteSource = AutoCompleteSource.ListItems;
         NAVE_Codigo.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
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

      #endregion

      #region [ Eventos ]

      private void btnBuscar_Click(object sender, EventArgs e)
      { Buscar(); }


      private void btnProcesarAsientos_Click(object sender, EventArgs e)
      { ProcesarAsientos(); }

      private void btnDeshacer_Click(object sender, EventArgs e)
      { Deshacer(); }

      #region [ Metodos de Grilla ]

      private void tsmMarcarTodos_Click(object sender, EventArgs e)
      {
         try
         {
            foreach (Telerik.WinControls.UI.GridViewRowInfo _fila in grdItems.Rows)
            { _fila.Cells["Seleccionar"].Value = true; }
            this.grdItems.EndEdit();
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al marcar todos.", ex); }

      }
      private void tsmDesmarcarTodos_Click(object sender, EventArgs e)
      {
         try
         {
            foreach (Telerik.WinControls.UI.GridViewRowInfo _fila in grdItems.Rows)
            { _fila.Cells["Seleccionar"].Value = false; }
            this.grdItems.EndEdit();
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al desmarcar todos.", ex); }
      }
      private void tsmMarcarSeleccionados_Click(object sender, EventArgs e)
      {
         try
         {
            foreach (Telerik.WinControls.UI.GridViewRowInfo _fila in this.grdItems.SelectedRows)
            { _fila.Cells["Seleccionar"].Value = true; }
            this.grdItems.EndEdit();
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al marcar los seleccionados.", ex); }

      }
      private void tsmDesmarcarSeleccionados_Click(object sender, EventArgs e)
      {
         try
         {
            foreach (Telerik.WinControls.UI.GridViewRowInfo _fila in this.grdItems.SelectedRows)
            { _fila.Cells["Seleccionar"].Value = false; }
            this.grdItems.EndEdit();
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al desmarcar los seleccionados.", ex); }
      }

      private void grdItems_MouseClick(object sender, MouseEventArgs e)
      {
         if (e.Button == MouseButtons.Right)
         {
            Point pt = new Point();
            pt = grdItems.PointToScreen(e.Location);
            CMSseleccion.Show(pt);
         }
      }
      /*
        private void grdItems_ValueChanged(object sender, EventArgs e)
      {
         if (this.grdTarjetasDia.ActiveEditor is RadCheckBoxEditor)
         {
            Console.WriteLine(this.grdTarjetasDia.CurrentCell.RowIndex);
            Console.WriteLine(this.grdTarjetasDia.ActiveEditor.Value);
         }
      }
       */
      #endregion

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
