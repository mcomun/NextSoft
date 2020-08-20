using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections.ObjectModel;

namespace Delfin.Principal
{
   public partial class COM001LView : UserControl, ICOM001LView
   {
      #region [ Variables ]

      #endregion

      #region [ Formulario ]
      public COM001LView(Telerik.WinControls.UI.RadPageViewPage x_tabPageControl)
      {
         InitializeComponent();
         try
         {
            TabPageControl = x_tabPageControl;

            txoArchivo.Filter = "Archivos de Excel (*.xls)|*.xls";
            txeEjecutivo.AyudaValueChanged += txeEjecutivo_AyudaValueChanged;
            
            tsmMarcarTodos.Click += tsmMarcarTodos_Click;
            tsmMarcarSeleccionados.Click += tsmMarcarSeleccionados_Click;
            tsmDesmarcarSeleccionados.Click += tsmDesmarcarSeleccionados_Click;
            tsmDesmarcarTodos.Click += tsmDesmarcarTodos_Click;

            btnEjecutar.Click += btnEjecutar_Click;
            btnDeshacer.Click += btnDeshacer_Click;
            btnAsignar.Click += btnAsignar_Click;
            BSItems = new BindingSource();

            TitleView.FormClose += new EventHandler(View_FormClose);
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al crear la vista.", ex); }
      }
      #endregion

      #region [ Propiedades ]
      public Telerik.WinControls.UI.RadPageViewPage TabPageControl { get; set; }
      public Image IconView { get { return TitleView.FormIcon; } set { TitleView.FormIcon = value; } }
      public COM001Presenter Presenter { get; set; }
      public BindingSource BSItems { get; set; }
      #endregion

      #region [ ICUS001LView ]
      public void LoadView()
      {
         try
         {
            cmbRegimen.ValueMember = "CONS_CodTipo";
            cmbRegimen.DisplayMember = "CONS_Desc_SPA";
            cmbRegimen.DataSource = Presenter.ListConstantesRGM;
            cmbRegimen.SelectedIndex = -1;

            txeEjecutivo.ContainerService = Presenter.ContainerService;
            txeEjecutivo.TipoEntidad = Delfin.Controls.TiposEntidad.TIPE_Ejecutivo;
            
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
            BSItems.DataSource = Presenter.Items;
            grdItems.DataSource = BSItems;
            navItems.BindingSource = BSItems;
            BSItems.ResetBindings(true);
            if (grdItems.RowCount > 0)
            {
               grdItems.Enabled = true;

               this.grdItems.ReadOnly = false;
               this.grdItems.AllowEditRow = true;
               this.grdItems.Columns["PROS_Asignar"].ReadOnly = false;
               this.grdItems.Columns["ENTC_NomCompletoEjecutivo"].ReadOnly = true;
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

            this.grdItems.Columns.Add("ENTC_NomCompletoEjecutivo", "EJECUTIVO", "ENTC_NomCompletoEjecutivo");
            this.grdItems.Columns.Add("ENTC_RazonSocialAgenteCarga", "AGENTE CARGA", "ENTC_RazonSocialAgenteCarga");
            this.grdItems.Columns.Add("TIPO_DescCDT", "COMODITY", "TIPO_DescCDT");
            this.grdItems.Columns.Add("ENTC_RazonSocialCliente", "CONSIGNATARIO/EMBARCADOR", "ENTC_RazonSocialCliente");
            this.grdItems.Columns.Add("PROS_TEUS", "TEUS", "PROS_TEUS");
            this.grdItems.Columns.Add("PROS_Porcentaje", "PORCENTAJE", "PROS_Porcentaje");
            this.grdItems.Columns.Add("PROS_CNTR40", "CONTENEDOR 40", "PROS_CNTR40");
            this.grdItems.Columns.Add("PROS_CNTR20", "CONTENEDOR 20", "PROS_CNTR20");
            this.grdItems.Columns.Add("ENTC_Notas", "OBSERVACION", "ENTC_Notas");
            grdItems.BestFitColumns();

            Infrastructure.WinForms.Controls.GridAutoFit.Fit(grdItems);

            grdItems.SelectionMode = Telerik.WinControls.UI.GridViewSelectionMode.FullRowSelect;
            grdItems.MultiSelect = true;

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
               if (BSItems != null && BSItems.Current != null && BSItems.Current is Entities.Prospecto)
               { Presenter.Item = ((Entities.Prospecto)BSItems.Current); }
               else
               { Presenter.Item = null; }
            }
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha Ocurrido un error al seleccionar el item de la grila.", ex); }
      }

      private void Nuevo()
      {
         try
         {

         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al hacer nuevo.", ex); }
      }
      private void Buscar()
      {
         try
         {

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
               _xls.InsertarTitulos("Mantenimiento de Tipos", 1, ref _fila, 1, _listTituloFiltro, _cabeceras.Length);
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
            cmbRegimen.SelectedIndex = -1;
            txoArchivo.Clear();
            txeEjecutivo.ClearValue();

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
            txoArchivo.Enabled = !Habilitar;
            txoArchivo.EnableButton = !Habilitar;
            txnTEUS.Enabled = !Habilitar;
            cmbRegimen.Enabled = !Habilitar;
            
            //btnEjecutar.Enabled = !Habilitar;

            txeEjecutivo.Enabled = Habilitar;
            txeEjecutivo.EnabledAyudaButton = Habilitar;
            btnAsignar.Enabled = Habilitar;
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al deshacer la vista.", ex); }
      }

      private void SeleccionarArchivo()
      {
         try
         {

            if (!String.IsNullOrEmpty(txoArchivo.Text) && !String.IsNullOrEmpty(txoArchivo.FullPath) && System.IO.File.Exists(txoArchivo.FullPath))
            {
               System.IO.FileInfo file_info = new System.IO.FileInfo(txoArchivo.FullPath);
               Int32 numBytes = Convert.ToInt32(file_info.Length);

               //btnEjecutar.Enabled = true;
            }
            else
            { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Presenter.Title, "Debe seleccionar un archivo."); }
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al cargar el archivo de excel.", ex); }
      }
      private void EjecutarImportacion()
      {
         try
         {
            if (!String.IsNullOrEmpty(txoArchivo.Text) && !String.IsNullOrEmpty(txoArchivo.FullPath) && System.IO.File.Exists(txoArchivo.FullPath))
            {
               Int32 _PROS_TEUS = 0;
               if (!Int32.TryParse(txnTEUS.Text, out _PROS_TEUS))
               { _PROS_TEUS = 0; }

               if (cmbRegimen.SelectedItem != null && cmbRegimen.SelectedItem is Entities.Constantes)
               { Presenter.ItemConstanteRGM = (Entities.Constantes)cmbRegimen.SelectedItem; }
               else
               { Presenter.ItemConstanteRGM = null; }

               Presenter.LoadArchivo(ref pgrImportacion, txoArchivo.FullPath, _PROS_TEUS);
            }
            else
            { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Presenter.Title, "Debe seleccionar un archivo."); }
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al ejecutar la importación.", ex); }
      }
      private void AsignarEjecutivo()
      {
         try
         {
            Presenter.Items = (ObservableCollection<Entities.Prospecto>)BSItems.DataSource;
            Presenter.AsignarEjecutivo();
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al ejecutar la asignación del ejecutivo.", ex); }
      }
      #endregion

      #region [ Eventos ]
      private void btnEjecutar_Click(object sender, EventArgs e)
      { EjecutarImportacion(); }
      private void btnAsignar_Click(object sender, EventArgs e)
      { AsignarEjecutivo(); }
      private void btnDeshacer_Click(object sender, EventArgs e)
      { Deshacer(); }

      private void txeEjecutivo_AyudaValueChanged(object sender, EventArgs e)
      {
         try
         {
            Presenter.ItemEjecutivo = txeEjecutivo.Value; 
         }
         catch (Exception)
         { }
      }

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