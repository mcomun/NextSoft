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
   public partial class CAJ013RespuestaDetraccionLView : UserControl, ICAJ013RespuestaDetraccionLView
   {
      #region [ Variables ]
      //private String m_sortColumnName;
      //private Boolean m_sortAscending = false;
      #endregion

      #region [ Formulario ]
      public CAJ013RespuestaDetraccionLView(Telerik.WinControls.UI.RadPageViewPage x_tabPageControl)
      {
         InitializeComponent();
         try
         {
            TabPageControl = x_tabPageControl;

            btnLevantar.Click += btnLevantar_Click;
            btnDeshacer.Click += btnDeshacer_Click;
            txaOpenFile.AyudaClick += txaOpenFile_AyudaClick;
            txaOpenFile.AbrirClick += txaOpenFile_AbrirClick;
            //txaOpenFile.AbrirButton.Visible = false;
            cmbCodificacion.LoadControl("Codificación", Delfin.Controls.Tipos.ComboBoxConstantes.OConstantes.Codificacion, "<  Tipo de Codificación >", ListSortDirection.Ascending);
            cmbCodificacion.SelectedIndex = 1;
            spcArchivo.Panel2Collapsed = true;

            txtLote.ReadOnly = true;
            txtNombreArchivo.ReadOnly = true;
            txtNroOperacion.ReadOnly = true;
            txaEntidad.Enabled = false;
            txnMontoTotal.ReadOnly = true;
            txnNroDepositos.ReadOnly = true;
            dtpFechaHora.Enabled = false;
            txtArchivo.ReadOnly = true;
            txtArchivo.WordWrap = false;
            txtObservaciones.ReadOnly = true;

            btnLevantar.Enabled = false;
            btnDeshacer.Enabled = false;

            BSItems = new BindingSource();
            BSItems.CurrentItemChanged += new EventHandler(BSItems_CurrentItemChanged);

            TitleView.FormClose += new EventHandler(TitleView_FormClose);
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error inicializando el formulario LView.", ex); }
      }

      #endregion

      #region [ Propiedades ]
      public Telerik.WinControls.UI.RadPageViewPage TabPageControl { get; set; }
      public Image IconView { get { return TitleView.FormIcon; } set { TitleView.FormIcon = value; } }
      public CAJ013RespuestaDetraccionPresenter Presenter { get; set; }
      public BindingSource BSItems { get; set; }
      #endregion

      #region [ ICAJ013RespuestaDetraccionLView ]
      public void LoadView()
      {
         try
         {
            FormatDataGrid();

            grdItems.Enabled = false;
            btnLevantar.Enabled = false;

            txaEntidad.LoadControl(Presenter.ContainerService, Delfin.Controls.TiposEntidad.TIPE_Cliente);

            SeleccionarItem();
            TitleView.Caption = Presenter.Title;
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error cargando la vista.", ex); }
      }
      public void ShowItems()
      {
         try
         {
            BSItems.DataSource = Presenter.CRespuestas.ListRespuestas;
            grdItems.DataSource = BSItems;
            navItems.BindingSource = BSItems;
            BSItems.ResetBindings(true);
            if (grdItems.RowCount > 0)
            {
               grdItems.Enabled = true;
               Infrastructure.WinForms.Controls.GridAutoFit.Fit(this.grdItems);
            }
            else
            {
               grdItems.Enabled = false;
            }

            grdItems.ShowFilteringRow = false;
            grdItems.EnableFiltering = false;
            grdItems.MasterTemplate.EnableFiltering = false;
            grdItems.EnableGrouping = false;
            grdItems.MasterTemplate.EnableGrouping = false;
            grdItems.EnableSorting = false;
            grdItems.MasterTemplate.EnableCustomSorting = false;
            grdItems.BestFitColumns();

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
            this.grdItems.Columns.Add("TipoComprobante", "Tipo Comprobante", "TipoComprobante");
            this.grdItems.Columns.Add("Serie", "Serie", "Serie");
            this.grdItems.Columns.Add("Numero", "Numero", "Numero");
            this.grdItems.Columns.Add("TipoDocProveedor", "Tipo", "TipoDocProveedor");
            this.grdItems.Columns.Add("NroDocProveedor", "RUC", "NroDocProveedor");
            this.grdItems.Columns.Add("RazonSocial", "Razon Social", "RazonSocial");
            this.grdItems.Columns.Add("PeriodosTributario", "Periodo", "PeriodosTributario");
            
            /* Propiedades Finales */
            grdItems.ReadOnly = true;
            grdItems.ShowFilteringRow = false;
            grdItems.EnableFiltering = false;
            grdItems.MasterTemplate.EnableFiltering = false;
            grdItems.EnableGrouping = false;
            grdItems.MasterTemplate.EnableGrouping = false;
            grdItems.EnableSorting = false;
            grdItems.MasterTemplate.EnableCustomSorting = false;

            Infrastructure.WinForms.Controls.GridAutoFit.Fit(grdItems);

         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, Infrastructure.Aspect.Constants.Mensajes.FormatDataGridView, ex); }
      }
      
      public void SetItem()
      {
         try
         {
            if (!String.IsNullOrEmpty(Presenter.CRespuestas.NroOperacion)) { txtNroOperacion.Text = Presenter.CRespuestas.NroOperacion; }
            if (Presenter.CRespuestas.FechaHora.HasValue) { dtpFechaHora.NSFecha = Presenter.CRespuestas.FechaHora; }
            if (!String.IsNullOrEmpty(Presenter.CRespuestas.NombreArchivo)) { txtNombreArchivo.Text = Presenter.CRespuestas.NombreArchivo; }
            if (!String.IsNullOrEmpty(Presenter.CRespuestas.Lote)) { txtLote.Text = Presenter.CRespuestas.Lote; }
            if (!String.IsNullOrEmpty(Presenter.CRespuestas.RUC)) { txaEntidad.SetEntidad(Presenter.CRespuestas.RUC); }
            if (Presenter.CRespuestas.NroDepositos.HasValue) { txnNroDepositos.Value = Convert.ToDecimal(Presenter.CRespuestas.NroDepositos); }
            if (Presenter.CRespuestas.MontoTotal.HasValue) { txnMontoTotal.Value = Presenter.CRespuestas.MontoTotal.Value; }
         }
         catch (Exception)
         { throw; }
      }

      private void SeleccionarItem()
      {
         try
         {
            if (Presenter != null)
            {
               if (BSItems != null && BSItems != null && BSItems.DataSource != null && BSItems.Current != null && BSItems.Current is Entities.Planillas)
               {
                  Presenter.Item = ((Entities.Planillas)BSItems.Current);

               }
               else
               {
                  Presenter.Item = null;
               }
            }
            else
            {
            }
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al seleccionar el item.", ex); }
      }

      private void AbrirArchivo()
      {
         try
         {
            if (cmbCodificacion.ConstantesSelectedItem != null)
            {
               if (!String.IsNullOrEmpty(txaOpenFile.FullPath))
               {
                  Presenter.CRespuestas = new Infrastructure.Aspect.Constants.CCabeceraRDetracciones();
                  Presenter.CRespuestas.PathArchivo = txaOpenFile.FullPath;
                  if( Presenter.AbrirArchivo(cmbCodificacion.SelectedValue.ToString()))
                  {
                      txtArchivo.Text = Presenter.CRespuestas.Archivo.ToString();
                      btnLevantar.Enabled = true;
                      btnDeshacer.Enabled = true;
                      SetItem();
                      ShowItems();
                  }
                  else
                  {
                     
                      Deshacer();
                  }
               }
               else
               { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Presenter.Title, "Debe seleccionar un archivo."); }
            }
            else
            { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Presenter.Title, "Debe seleccionar un tipo de codificacón para el archivo."); }
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "El archivo que ha seleccionado es incorrecto. ", ex); }
      }

      private void LevantarRespuesta()
      {
         try
         {
            
             if (Presenter.CRespuestas.ListRespuestas != null && Presenter.CRespuestas.ListRespuestas.Count > 0)
            {
               if (!Presenter.LevantarRespuesta())
               {
                  txtObservaciones.Text = Presenter.MensajeError;
                  spcArchivo.Panel2Collapsed = false;
                  Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Presenter.Title, "Se hizo el levantamiento, algunos registro no se actualizaron, puede revisar el cuadro con las observaciones.");
               }
               else
               {
                  Deshacer();
                  Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Presenter.Title, "Se realizo el levantamiento de la respuesta de todos los registros.");
               }
            }
         }
         catch (Exception)
         { }
      }

      private void Deshacer()
      {
         try
         {
            txtArchivo.Clear();
            txtLote.Clear();
            txtNombreArchivo.Clear();
            txtNroOperacion.Clear();
            txnMontoTotal.Clear();
            txnNroDepositos.Clear();
            txtObservaciones.Clear();
            txaEntidad.Clear();
            txaOpenFile.Clear();
            dtpFechaHora.NSClear();
            spcArchivo.Panel2Collapsed = true;

            Presenter.CRespuestas.ListRespuestas = null;
            ShowItems();

            btnLevantar.Enabled = false;
            //btnDeshacer.Enabled = false;
         }
         catch (Exception)
         { }
      }

      #endregion

      #region [ Eventos ]

      private void btnDeshacer_Click(object sender, EventArgs e)
      { Deshacer(); }

      private void BSItems_CurrentItemChanged(object sender, EventArgs e)
      { SeleccionarItem(); }
      
      private void txaOpenFile_AyudaClick(object sender, EventArgs e)
      { AbrirArchivo(); }

      private void txaOpenFile_AbrirClick(object sender, EventArgs e)
      { AbrirArchivo(); }

      private void btnLevantar_Click(object sender, EventArgs e)
      { LevantarRespuesta(); }


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
