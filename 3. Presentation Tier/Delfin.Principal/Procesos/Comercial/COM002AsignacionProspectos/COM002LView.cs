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
   public partial class COM002LView : UserControl, ICOM002LView
   {
      #region [ Variables ]

      #endregion

      #region [ Formulario ]
      public COM002LView(Telerik.WinControls.UI.RadPageViewPage x_tabPageControl)
      {
         InitializeComponent();
         try
         {
            TabPageControl = x_tabPageControl;

            tsmMarcarTodos.Click += tsmMarcarTodos_Click;
            tsmMarcarSeleccionados.Click += tsmMarcarSeleccionados_Click;
            tsmDesmarcarSeleccionados.Click += tsmDesmarcarSeleccionados_Click;
            tsmDesmarcarTodos.Click += tsmDesmarcarTodos_Click;

            txeEjecutivoNuevo.TipoEntidad = Delfin.Controls.TiposEntidad.TIPE_Ejecutivo;
            txeEjecutivoActual.TipoEntidad = Delfin.Controls.TiposEntidad.TIPE_Ejecutivo;
            txeAgenteCarga.TipoEntidad = Delfin.Controls.TiposEntidad.TIPE_AgenteCarga;

            btnBuscar.Click += btnBuscar_Click;
            btnDeshacer.Click += btnDeshacer_Click;
            btnAsignar.Click += btnAsignar_Click;
            BSItems = new BindingSource();

            //grdItems.FilterChanged += grdItems_FilterChanged;

            TitleView.FormClose += new EventHandler(View_FormClose);
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al crear la vista.", ex); }
      }
      #endregion

      #region [ Propiedades ]
      public Telerik.WinControls.UI.RadPageViewPage TabPageControl { get; set; }
      public Image IconView { get { return TitleView.FormIcon; } set { TitleView.FormIcon = value; } }
      public COM002Presenter Presenter { get; set; }
      public BindingSource BSItems { get; set; }
      #endregion

      #region [ ICOM002LView ]
      public void LoadView()
      {
         try
         {
            txeAgenteCarga.ContainerService = Presenter.ContainerService;
            txeEjecutivoActual.ContainerService = Presenter.ContainerService;
            txeEjecutivoNuevo.ContainerService = Presenter.ContainerService;

            BSItems.DataSource = null;
            grdItems.DataSource = BSItems;
            navItems.BindingSource = BSItems;
            BSItems.ResetBindings(true);

            FormatDataGrid();

            HabilitarAsignacion(false);

            //btnEjecutar.Enabled = false;
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error cargando la vista.", ex); }
      }
      public void ShowItems(Boolean Habilitar)
      {
         try
         {
            BSItems.DataSource = Presenter.Items.ToDataTable();
            grdItems.DataSource = BSItems;
            navItems.BindingSource = BSItems;
            BSItems.ResetBindings(true);
            if (grdItems.RowCount > 0)
            {
               grdItems.Enabled = true;

               this.grdItems.ReadOnly = false;
               this.grdItems.AllowEditRow = true;
               this.grdItems.Columns["PROS_Asignar"].ReadOnly = false;
               //this.grdItems.Columns["ENTC_NomCompletoEjecutivo"].ReadOnly = true;
               this.grdItems.Columns["ENTC_Prospecto"].ReadOnly = true;
               this.grdItems.Columns["ENTC_RazonSocialAgenteCarga"].ReadOnly = true;
               this.grdItems.Columns["TIPO_DescCDT"].ReadOnly = true;
               this.grdItems.Columns["ENTC_RazonSocialCliente"].ReadOnly = true;
               this.grdItems.Columns["PROS_TEUS"].ReadOnly = true;
               this.grdItems.Columns["PROS_Porcentaje"].ReadOnly = true;
               this.grdItems.Columns["PROS_CNTR40"].ReadOnly = true;
               this.grdItems.Columns["PROS_CNTR20"].ReadOnly = true;

               HabilitarAsignacion(Habilitar);
            }
            else
            {
               HabilitarAsignacion(false);
               grdItems.Enabled = false;
            }
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
            this.grdItems.AllowEditRow = true;

            Telerik.WinControls.UI.GridViewCheckBoxColumn _checkColumn = new Telerik.WinControls.UI.GridViewCheckBoxColumn();
            _checkColumn.Name = "PROS_Asignar";
            _checkColumn.FieldName = "PROS_Asignar";
            _checkColumn.HeaderText = "ASIGNAR";
            _checkColumn.ReadOnly = false;
            _checkColumn.DataType = typeof(Boolean);
            this.grdItems.Columns.Add(_checkColumn);

            //this.grdItems.Columns.Add("ENTC_NomCompletoEjecutivo", "EJECUTIVO", "ENTC_NomCompletoEjecutivo");
            this.grdItems.Columns.Add("ENTC_RazonSocialAgenteCarga", "AGENTE CARGA", "ENTC_RazonSocialAgenteCarga");
            this.grdItems.Columns.Add("TIPO_DescCDT", "COMODITY", "TIPO_DescCDT");
            Telerik.WinControls.UI.GridViewCheckBoxColumn _check = new Telerik.WinControls.UI.GridViewCheckBoxColumn();
            _check.Name = "ENTC_Prospecto";
            _check.HeaderText = "PROSPECTO";
            _check.FieldName = "ENTC_Prospecto";
            this.grdItems.Columns.Add(_check);
            this.grdItems.Columns.Add("ENTC_RazonSocialCliente", "CONSIGNATARIO/EMBARCADOR", "ENTC_RazonSocialCliente");
            this.grdItems.Columns.Add("PROS_DiasAsignacion", "DÍAS ASIGNACIÓN", "PROS_DiasAsignacion");
            this.grdItems.Columns.Add("PROS_TEUS", "TEUS", "PROS_TEUS");
            this.grdItems.Columns.Add("PROS_Porcentaje", "PORCENTAJE", "PROS_Porcentaje");
            this.grdItems.Columns.Add("PROS_CNTR40", "CONTENEDOR 40", "PROS_CNTR40");
            this.grdItems.Columns.Add("PROS_CNTR20", "CONTENEDOR 20", "PROS_CNTR20");
            grdItems.BestFitColumns();

            Infrastructure.WinForms.Controls.GridAutoFit.Fit(grdItems);

            grdItems.SelectionMode = Telerik.WinControls.UI.GridViewSelectionMode.FullRowSelect;
            grdItems.MultiSelect = true;

            grdItems.EnableFiltering = true;
            grdItems.ShowFilteringRow = false;
            grdItems.MasterTemplate.EnableFiltering = true;
            grdItems.MasterTemplate.ShowHeaderCellButtons = true;
            grdItems.MasterTemplate.ShowFilteringRow = false; 
            
            grdItems.EnableGrouping = false;
            grdItems.MasterTemplate.EnableGrouping = false;
            grdItems.EnableSorting = true;
            grdItems.MasterTemplate.EnableCustomSorting = true;
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
               if (BSItems != null && BSItems.Current != null && BSItems.Current is Entities.Prospecto)
               { Presenter.Item = ((Entities.Prospecto)BSItems.Current); }
               else
               { Presenter.Item = null; }
            }
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha Ocurrido un error al seleccionar el item de la grila.", ex); }
      }

      private void Buscar()
      {
         try
         {
            Presenter.ItemEjecutivoActual = txeEjecutivoActual.Value;
            Presenter.ItemAgenteCarga = txeAgenteCarga.Value;
            Presenter.FechaAsignacion = mdtFechaAsignacion.NSFecha;

            Presenter.CargarProspectos();
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al buscar.", ex); }
      }
      private void Deshacer()
      {
         try
         {
            txeEjecutivoActual.ClearValue();
            mdtFechaAsignacion.NSFecha = null;
            txeAgenteCarga.ClearValue();
            txeEjecutivoNuevo.ClearValue();

            BSItems.DataSource = null;
            grdItems.DataSource = BSItems;
            navItems.BindingSource = BSItems;
            BSItems.ResetBindings(true);

            HabilitarAsignacion(false);
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al deshacer la vista.", ex); }
      }
      private void HabilitarAsignacion(Boolean Habilitar)
      {
         try
         {
            txeEjecutivoActual.Enabled = !Habilitar;
            txeEjecutivoActual.EnabledAyudaButton = !Habilitar;
            txeAgenteCarga.Enabled = !Habilitar;
            txeAgenteCarga.EnabledAyudaButton = !Habilitar;
            mdtFechaAsignacion.Enabled = !Habilitar;
            btnBuscar.Enabled = !Habilitar;

            txeEjecutivoNuevo.Enabled = Habilitar;
            txeEjecutivoNuevo.EnabledAyudaButton = Habilitar;
            btnAsignar.Enabled = Habilitar;
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al deshacer la vista.", ex); }
      }

      private void AsignarEjecutivo()
      {
         try
         {
            Presenter.ItemEjecutivoNuevo = txeEjecutivoNuevo.Value;
            //Presenter.Items = (ObservableCollection<Entities.Prospecto>)BSItems.DataSource;
            Presenter.Items = ((DataTable)BSItems.DataSource).ToObservableCollection<Entities.Prospecto>();
            Presenter.AsignarEjecutivo();
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al ejecutar la asignación del ejecutivo.", ex); }
      }
      #endregion

      #region [ Eventos ]
      private void btnBuscar_Click(object sender, EventArgs e)
      { Buscar(); }
      private void btnAsignar_Click(object sender, EventArgs e)
      { AsignarEjecutivo(); }
      private void btnDeshacer_Click(object sender, EventArgs e)
      { Deshacer(); }

      private void tsmMarcarTodos_Click(object sender, EventArgs e)
      {
         try
         {
            foreach (Telerik.WinControls.UI.GridViewRowInfo _fila in grdItems.Rows)
            { _fila.Cells["PROS_Asignar"].Value = true; }
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
            { _fila.Cells["PROS_Asignar"].Value = false; }
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
            { _fila.Cells["PROS_Asignar"].Value = true; }
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
            { _fila.Cells["PROS_Asignar"].Value = false; }
            this.grdItems.EndEdit();
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al desmarcar los seleccionados.", ex); }
      }

      private void BSItems_CurrentItemChanged(object sender, EventArgs e)
      { SeleccionarItem(); }

      bool _clearFiltro = false;
      string filtro;
      private void grdItems_FilterChanged(object sender, Telerik.WinControls.UI.GridViewCollectionChangedEventArgs e)
      {
         try
         {
            filtro = "";
            foreach (var item in grdItems.FilterDescriptors)
            {
               if (String.IsNullOrEmpty(filtro))
               { filtro += item.Expression; }
               else
               { filtro += " AND " + item.Expression; }
            }

            if (!String.IsNullOrEmpty(filtro))
            { BSItems.Filter = filtro; }
            else
            { BSItems.Filter = null; }

            BSItems.ResetBindings(true);
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
