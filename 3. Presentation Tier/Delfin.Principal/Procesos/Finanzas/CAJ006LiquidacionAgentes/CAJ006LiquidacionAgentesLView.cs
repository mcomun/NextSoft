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

namespace Delfin.Principal
{
   public partial class CAJ006LiquidacionAgentesLView : UserControl, ICAJ006LiquidacionAgentesLView
   {
      #region [ Variables ]
      //private String m_sortColumnName;
      //private Boolean m_sortAscending = false;
      #endregion

      #region [ Formulario ]
      public CAJ006LiquidacionAgentesLView(Telerik.WinControls.UI.RadPageViewPage x_tabPageControl)
      {
         InitializeComponent();
         try
         {
            TabPageControl = x_tabPageControl;

            btnNuevo.Click += new EventHandler(btnNuevo_Click);
            btnAprobar.Click += btnAprobar_Click;
            btnConciliar.Click += btnConciliar_Click;
            btnExportar.Click += btnExportar_Click;

            btnLiquidar.Click += btnLiquidar_Click;
            btnImportarLiquidacion.Click += btnImportarLiquidacion_Click;
            btnImportarLiquidacion.Visible = false;
            btnAnular.Click += btnAnular_Click;
            btnImprimir.Click += btnImprimir_Click;
            btnExportarNoProcesados.Click += btnExportarNoProcesados_Click;

            btnAprobar.Enabled = false;
            btnConciliar.Enabled = false;
            btnAnular.Enabled = false;
            btnImprimir.Enabled = false;
            btnLiquidar.Enabled = false;
            chkIncluirPendientes.Checked = true;
            pgbBase.Visible = false;

            txaLIQU_Codigo.AyudaValueChanged += txaLIQU_Codigo_AyudaValueChanged;

            BSItems = new BindingSource();
            BSItems.CurrentItemChanged += new EventHandler(BSItems_CurrentItemChanged);

            grdItems.CommandCellClick += new Telerik.WinControls.UI.CommandCellClickEventHandler(grdItems_CommandCellClick);

            TitleView.FormClose += new EventHandler(TitleView_FormClose);

            pnlTitleDatosCancelacion.Visible = false;
            tlpDatosCancelacion.Visible = false;

            txaLIQU_Codigo.Tag = "LIQU_CodigoMSGERROR";
            txtLIQU_Glosa.Tag = "LIQU_GlosaMSGERROR";
            dtpLIQU_Fecha.Tag = "LIQU_FechaMSGERROR";
            cmbLIQU_Estado.Tag = "LIQU_EstadoMSGERROR";
            txaENTC_Codigo.Tag = "ENTC_CodigoMSGERROR";

            spcBase.Panel2Collapsed = true;
            spcResultado.Panel2Collapsed = true;
            txtObservaciones.ReadOnly = true;
            txtObservaciones.WordWrap = false;
            txaENTC_Codigo.SelectedItemChanged += txaENTC_Codigo_SelectedItemChanged;
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error inicializando el formulario LView.", ex); }
      }

      #endregion

      #region [ Propiedades ]
      public Telerik.WinControls.UI.RadPageViewPage TabPageControl { get; set; }
      public Image IconView { get { return TitleView.FormIcon; } set { TitleView.FormIcon = value; } }
      public CAJ006LiquidacionAgentesPresenter Presenter { get; set; }
      public BindingSource BSItems { get; set; }
      public BindingSource BSItemsNoProcesados { get; set; }
      #endregion

      #region [ ICAJ006LiquidacionAgentesLView ]
      public void LoadView()
      {
         try
         {
            FormatDataGrid();

            grdItems.Enabled = false;
            btnNuevo.Enabled = true;
            btnLiquidar.Enabled = false;
            btnAprobar.Enabled = false;
            btnAnular.Enabled = false;
            btnImprimir.Enabled = false;
            btnConciliar.Enabled = false;

            cmbLIQU_Estado.LoadControl("Liquidación", Delfin.Controls.Tipos.ComboBoxConstantes.OConstantes.EstadoLiquidacion, "< Sel Estado >", ListSortDirection.Ascending);
            cmbUnidadNegocio.LoadControl("Unidad de Negocio", Delfin.Controls.Tipos.ComboBoxConstantes.OConstantes.UnidadNegocio, "< Sel. Unidad Negocio>", ListSortDirection.Ascending);
            txaENTC_Codigo.LoadControl(Presenter.ContainerService, Delfin.Controls.TiposEntidad.TIPE_Agente, null, null, true);
            txaENTC_CuentaBancaria.LoadControl(Presenter.ContainerService, "Ayuda de Cuentas Bancarias", Delfin.Controls.Entorno.ItemEmpresa.EMPR_Codigo, Presenter.Session.UserName);

            dtpLIQU_Fecha.NSFecha = Presenter.Client.GetFecha();
            cmbLIQU_Estado.Enabled = false;

            txaLIQU_Codigo.AyudaClick += txaLIQU_Codigo_AyudaClick;
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error cargando la vista.", ex); }
      }
      public void ShowItems(CAJ006LiquidacionAgentesPresenter.TBusqueda x_opcion)
      {
         try
         {
            BSItems.DataSource = Presenter.Item.ListCtaCte;

            grdItems.DataSource = BSItems;
            navItems.BindingSource = BSItems;
            BSItems.ResetBindings(true);

            if (grdItems.RowCount > 0)
            {
               grdItems.Enabled = true;
               grdItems.BestFitColumns();
               grdItems.ReadOnly = false;
               grdItems.AllowEditRow = true;
               grdItems.Columns["Seleccionar"].ReadOnly = false;
               grdItems.Columns["Seleccionar"].Width = 90;

               switch (x_opcion)
               {
                  case CAJ006LiquidacionAgentesPresenter.TBusqueda.Normal:
                     btnNuevo.Enabled = true;
                     btnLiquidar.Enabled = true;
                     btnAprobar.Enabled = false;
                     btnAnular.Enabled = false;
                     btnImprimir.Enabled = false;
                     btnConciliar.Enabled = true;
                     break;
                  case CAJ006LiquidacionAgentesPresenter.TBusqueda.Apertura:
                     ShowControlesApertura();
                     break;
                  default:
                     btnNuevo.Enabled = true;
                     btnLiquidar.Enabled = false;
                     btnAprobar.Enabled = false;
                     btnAnular.Enabled = false;
                     btnImprimir.Enabled = false;
                     btnConciliar.Enabled = false;
                     grdItems.ReadOnly = true;
                     break;
               }
               //Infrastructure.WinForms.Controls.GridAutoFit.Fit(this.grdItems);
            }
            else
            {
               grdItems.Enabled = false;
               switch (x_opcion)
               {
                  case CAJ006LiquidacionAgentesPresenter.TBusqueda.Normal:
                     btnNuevo.Enabled = true;
                     btnLiquidar.Enabled = false;
                     btnAprobar.Enabled = false;
                     btnAnular.Enabled = false;
                     btnImprimir.Enabled = false;
                     btnConciliar.Enabled = false;
                     break;
                  case CAJ006LiquidacionAgentesPresenter.TBusqueda.Apertura:
                     ShowControlesApertura();
                     btnLiquidar.Enabled = false;
                     btnImprimir.Enabled = false;
                     btnConciliar.Enabled = false;
                     break;
                  default:
                     btnNuevo.Enabled = true;
                     btnLiquidar.Enabled = false;
                     btnAprobar.Enabled = false;
                     btnAnular.Enabled = false;
                     btnImprimir.Enabled = false;
                     btnConciliar.Enabled = false;
                     break;
               }
            }

            //grdItems.ShowFilteringRow = false;
            //grdItems.EnableFiltering = false;
            //grdItems.MasterTemplate.EnableFiltering = false;
            //grdItems.EnableGrouping = false;
            //grdItems.MasterTemplate.EnableGrouping = false;
            //grdItems.EnableSorting = false;
            //grdItems.MasterTemplate.EnableCustomSorting = false;
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error cargando los items.", ex); }
      }
      public void ClearItem()
      {
         try
         {
            txtLIQU_Glosa.Clear();
            dtpLIQU_Fecha.NSFecha = Presenter.Session.Fecha;
            errorProviderLiquidacion.Clear();
            //cmbUnidadNegocio.ConstantesSelectedValue = null;
            //chkIncluirPendientes.Checked = false;
            //chkStatement.Checked = false;

            spcBase.Panel2Collapsed = true;
            spcResultado.Panel2Collapsed = true;
         }
         catch (Exception)
         { throw; }
      }
      public void GetItem()
      {
         try
         {
            grdItems.EndEdit();
            if (cmbLIQU_Estado.ConstantesSelectedItem != null) { Presenter.Item.LIQU_Estado = cmbLIQU_Estado.ConstantesSelectedItem.CONS_CodTipo; } else { Presenter.Item.LIQU_Estado = null; }
            if (txaENTC_Codigo.SelectedItem != null)
            {
               Presenter.Item.ENTC_Codigo = txaENTC_Codigo.SelectedItem.ENTC_Codigo;
               Presenter.Item.TIPE_Codigo = Delfin.Controls.EntidadClear.GetCodigoTipoEntidad(Delfin.Controls.TiposEntidad.TIPE_Agente);
            }
            else { Presenter.Item.ENTC_Codigo = null; }
            if (!String.IsNullOrEmpty(txtLIQU_Glosa.Text)) { Presenter.Item.LIQU_Glosa = txtLIQU_Glosa.Text; } else { Presenter.Item.LIQU_Glosa = null; }
         }
         catch (Exception)
         { throw; }
      }
      public void SetItem(CAJ006LiquidacionAgentesPresenter.TBusqueda x_opcion)
      {
         try
         {
            if (!String.IsNullOrEmpty(Presenter.Item.LIQU_Estado)) { cmbLIQU_Estado.ConstantesSelectedValue = Presenter.Item.LIQU_Estado; } else { cmbLIQU_Estado.SelectedIndex = 0; }
            if (!String.IsNullOrEmpty(Presenter.Item.LIQU_Codigo))
            {
               txaLIQU_Codigo.AyudaValueChanged -= txaLIQU_Codigo_AyudaValueChanged;
               txaLIQU_Codigo.SetValue(Presenter.Item.LIQU_Codigo, Presenter.Item.LIQU_Codigo);
               txaLIQU_Codigo.AyudaValueChanged += txaLIQU_Codigo_AyudaValueChanged;
            }
            else
            {
               txaLIQU_Codigo.AyudaValueChanged -= txaLIQU_Codigo_AyudaValueChanged;
               txaLIQU_Codigo.ClearValue();
               txaLIQU_Codigo.AyudaValueChanged += txaLIQU_Codigo_AyudaValueChanged;
            }
            if (!String.IsNullOrEmpty(Presenter.Item.LIQU_Glosa)) { txtLIQU_Glosa.Text = Presenter.Item.LIQU_Glosa; } else { txtLIQU_Glosa.Clear(); }
            if (Presenter.Item.ENTC_Codigo != null)
            {
               txaENTC_Codigo.SetEntidad(Presenter.Item.ENTC_Codigo);
            } //else { txaENTC_Codigo.Clear(); }
            if (Presenter.Item.LIQU_Fecha != null) { dtpLIQU_Fecha.NSFecha = Presenter.Item.LIQU_Fecha; } else { dtpLIQU_Fecha.NSClear(); }
            if (!String.IsNullOrEmpty(Presenter.Item.LIQU_Estado))
            {
               cmbLIQU_Estado.ConstantesSelectedValue = Presenter.Item.LIQU_Estado;
               switch (Presenter.Item.LIQU_Estado)
               {
                  case "A":
                     cmbUnidadNegocio.Enabled = true;
                     txtLIQU_Glosa.ReadOnly = false;
                     txaENTC_Codigo.Enabled = true;
                     dtpLIQU_Fecha.Enabled = true;
                     break;
                  case "C":
                     cmbUnidadNegocio.Enabled = false;
                     txtLIQU_Glosa.ReadOnly = true;
                     txaENTC_Codigo.Enabled = false;
                     dtpLIQU_Fecha.Enabled = false;
                     break;
                  case "X":
                     cmbUnidadNegocio.Enabled = false;
                     txtLIQU_Glosa.ReadOnly = true;
                     txaENTC_Codigo.Enabled = false;
                     dtpLIQU_Fecha.Enabled = false;
                     break;
                  default:
                     cmbUnidadNegocio.Enabled = false;
                     txtLIQU_Glosa.ReadOnly = true;
                     txaENTC_Codigo.Enabled = false;
                     dtpLIQU_Fecha.Enabled = false;
                     break;
               }
            }

            GetFiltros();
            Presenter.Actualizar(x_opcion, chkIncluirPendientes.Checked);
            //if (x_opcion == CAJ006LiquidacionAgentesPresenter.TBusqueda.Apertura)
            //{
            //    btnLiquidar.Enabled = true;
            //    btnAprobar.Enabled = true;
            //    btnAnular.Enabled = true;
            //    btnImprimir.Enabled = true;
            //    btnConciliar.Enabled = true;
            //}
         }
         catch (Exception)
         { throw; }
      }
      public void ShowValidation()
      {
         try
         {
            Infrastructure.Client.FormClose.FormShowErrorProvider<Entities.Liquidacion>.Validate(Presenter.Item, this, errorProviderLiquidacion);
            Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Presenter.Title, "Existen campos obligatorios, revise los detalles.", Presenter.Item.MensajeError);
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error en ShowValidation.", ex); }
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

            Telerik.WinControls.UI.GridViewCheckBoxColumn _Seleccionar = new Telerik.WinControls.UI.GridViewCheckBoxColumn();
            _Seleccionar.Name = "Seleccionar";
            _Seleccionar.HeaderText = "Seleccionar";
            _Seleccionar.FieldName = "Seleccionar";
            _Seleccionar.ReadOnly = false;
            this.grdItems.Columns.Add(_Seleccionar);
            this.grdItems.Columns["Seleccionar"].ReadOnly = false;

            this.grdItems.Columns.Add("TIPO_TDO", "Tipo", "TIPO_TDO");
            this.grdItems.Columns.Add("CCCT_Serie", "Serie", "CCCT_Serie");
            this.grdItems.Columns.Add("CCCT_Numero", "Número", "CCCT_Numero");
            this.grdItems.Columns.Add("CCCT_FechaEmision", "Fecha Emisión", "CCCT_FechaEmision");
            this.grdItems.Columns.Add("OV_OP", "OV / OP", "OV_OP");
            this.grdItems.Columns.Add("FEmbarque", "Fecha de Embarque / Zarpe", "FEmbarque");
            this.grdItems.Columns.Add("FechaETA", "Fecha ETA", "FechaETA");
            this.grdItems.Columns.Add("NAVE_Nombre", "Nave Viaje", "NAVE_Nombre");
            this.grdItems.Columns.Add("DOOV_MBL", "MBL", "DOOV_MBL");
            this.grdItems.Columns.Add("DOOV_HBL", "HBL", "DOOV_HBL");
            this.grdItems.Columns.Add("UNegocio", "Uni. Negocio", "UNegocio");
            this.grdItems.Columns.Add("TIPO_MND", "Moneda", "TIPO_MND");
            this.grdItems.Columns.Add("CCCT_Pendiente_Cargo", "Ingreso", "CCCT_Pendiente_Cargo");
            this.grdItems.Columns.Add("CCCT_Pendiente_Abono", "Egreso", "CCCT_Pendiente_Abono");
            Telerik.WinControls.UI.GridViewCheckBoxColumn _conciliado = new Telerik.WinControls.UI.GridViewCheckBoxColumn();
            _conciliado.Name = "Conciliado";
            _conciliado.HeaderText = "Conciliado";
            _conciliado.FieldName = "Conciliado";
            this.grdItems.Columns.Add(_conciliado);
            this.grdItems.Columns.Add("CONC_FecConciliacion", "Fec. Conciliación", "CONC_FecConciliacion");
            this.grdItems.Columns.Add("CCCT_Codigo", "Transacción", "CCCT_Codigo");
            this.grdItems.Columns.Add("ObservacionesConciliacion", "Observaciones", "ObservacionesConciliacion");
            this.grdItems.Columns.Add("ConciliadoError", "Conciliacion", "ConciliadoError");
            this.grdItems.Columns.Add("PagoMNDOriginal", "Monto Referencial", "PagoMNDOriginal");


            this.grdItems.Columns["CCCT_FechaEmision"].FormatString = "{0:dd/MM/yyyy}";
            this.grdItems.Columns["FEmbarque"].FormatString = "{0:dd/MM/yyyy}";
            this.grdItems.Columns["FechaETA"].FormatString = "{0:dd/MM/yyyy}";
            this.grdItems.Columns["CCCT_Pendiente_Cargo"].FormatString = "{0:#,###,##0.00}";
            this.grdItems.Columns["CCCT_Pendiente_Abono"].FormatString = "{0:#,###,##0.00}";
            this.grdItems.Columns["CCCT_Pendiente_Cargo"].TextAlignment = ContentAlignment.MiddleRight;
            this.grdItems.Columns["CCCT_Pendiente_Abono"].TextAlignment = ContentAlignment.MiddleRight;
            this.grdItems.Columns["PagoMNDOriginal"].TextAlignment = ContentAlignment.MiddleRight;

            this.grdItems.Columns["TIPO_TDO"].ReadOnly = true;
            this.grdItems.Columns["CCCT_Serie"].ReadOnly = true;
            this.grdItems.Columns["CCCT_Numero"].ReadOnly = true;
            this.grdItems.Columns["CCCT_FechaEmision"].ReadOnly = true;
            this.grdItems.Columns["OV_OP"].ReadOnly = true;
            this.grdItems.Columns["FEmbarque"].ReadOnly = true;
            this.grdItems.Columns["FechaETA"].ReadOnly = true;
            this.grdItems.Columns["NAVE_Nombre"].ReadOnly = true;
            this.grdItems.Columns["DOOV_MBL"].ReadOnly = true;
            this.grdItems.Columns["DOOV_HBL"].ReadOnly = true;
            this.grdItems.Columns["UNegocio"].ReadOnly = true;
            this.grdItems.Columns["TIPO_MND"].ReadOnly = true;
            this.grdItems.Columns["Conciliado"].ReadOnly = true;
            this.grdItems.Columns["Conciliado"].IsVisible = false;
            this.grdItems.Columns["CONC_FecConciliacion"].ReadOnly = true;
            this.grdItems.Columns["CONC_FecConciliacion"].IsVisible = false;
            this.grdItems.Columns["UNegocio"].IsVisible = false;
            this.grdItems.Columns["CCCT_Pendiente_Cargo"].ReadOnly = true;
            this.grdItems.Columns["CCCT_Pendiente_Abono"].IsVisible = true;
            this.grdItems.Columns["CCCT_Pendiente_Cargo"].ReadOnly = true;
            this.grdItems.Columns["CCCT_Pendiente_Abono"].IsVisible = true;
            this.grdItems.Columns["ObservacionesConciliacion"].ReadOnly = true;
            this.grdItems.Columns["ObservacionesConciliacion"].IsVisible = false;
            this.grdItems.Columns["ObservacionesConciliacion"].Width = 200;
            this.grdItems.Columns["ConciliadoError"].IsVisible = false;
            this.grdItems.Columns["PagoMNDOriginal"].ReadOnly = true;

            ConditionalFormattingObject c1 = new ConditionalFormattingObject("Orange, applied to entire row", ConditionTypes.Equal, "true", "", true);
            c1.RowBackColor = Color.DarkBlue; // FromArgb(255, 91, 15, 2);
            c1.CellBackColor = Color.DarkBlue;
            c1.RowForeColor = Color.White;
            grdItems.Columns["ConciliadoError"].ConditionalFormattingObjectList.Add(c1);

            Infrastructure.WinForms.Controls.GridAutoFit.Fit(grdItems);

            //grdItems.BestFitColumns();
            grdItems.Columns["Seleccionar"].Width = 90;
            grdItems.Columns["Seleccionar"].ReadOnly = false;
            //grdItems.ReadOnly = false;
            //grdItems.ShowFilteringRow = false;
            //grdItems.EnableFiltering = false;
            //grdItems.MasterTemplate.EnableFiltering = false;
            //grdItems.EnableGrouping = false;
            //grdItems.MasterTemplate.EnableGrouping = false;
            //grdItems.EnableSorting = false;
            //grdItems.MasterTemplate.EnableCustomSorting = false;
            //grdItems.AllowColumnHeaderContextMenu = false;
            //grdItems.AllowCellContextMenu = false;
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, Infrastructure.Aspect.Constants.Mensajes.FormatDataGridView, ex); }
      }
      private void Nuevo()
      {
         try
         {
            if (txaENTC_Codigo.SelectedItem != null)
            {
               ClearItem();
               EliminarFiltros();
               Presenter.Nuevo();
               SetItem(CAJ006LiquidacionAgentesPresenter.TBusqueda.Normal);
            }
            else { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Presenter.Title, "Debe selecciona un Agente."); }
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al hacer nuevo.", ex); }
      }
      private void Liquidar()
      {
         try
         {
            if (Presenter.Liquidar())
            {
               btnNuevo_Click(null, null);
               errorProviderLiquidacion.Clear();
            }

         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al liquidar.", ex); }
      }
      private void Aprobar()
      {
         try
         {
            if (Infrastructure.WinForms.Controls.Dialogos.MostrarMensajePregunta(Presenter.Title, "¿Deseas Aprobar la liquidación seleccionada?", Infrastructure.WinForms.Controls.Dialogos.LabelBoton.Si_No) == System.Windows.Forms.DialogResult.Yes)
            {
               if (Presenter.Aprobar())
               {
                  Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeSatisfactorio(Presenter.Title, "Liquidacion Aprobada Satisfactoriamente.");
                  btnNuevo_Click(null, null);
               }
            }
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al aprobar.", ex); }
      }
      /// <summary>
      /// Realiza la conciliación de Agentes.
      /// </summary>
      private void Conciliar()
      {
         try
         {
            spcBase.Panel2Collapsed = true;
            spcResultado.Panel2Collapsed = true;
            Presenter.MsgError = "";
            pgbBase.Visible = true;
            if (Presenter.Conciliar(ref pgbBase))
            {
               /* Cuando todo el archivo a conciliar fue procesado integramente */
               Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeSatisfactorio(Presenter.Title, "Conciliación Procesada Satisfactoriamente.");
            }
            else if (Presenter.ConciliacionProcesado)
            {
               /* Muestra el resultado de los registros no procesados por que no existen en el listado de documentos a se 
                * cancelados/cobrados, y las observaciones de cada registro genera cuando no es procesado/conciliado
                **/
               spcResultado.Panel2Collapsed = !(Presenter.MsgError.Length > 0);
               if (Presenter.DTNoProcesados != null && Presenter.DTNoProcesados.Rows.Count > 0)
               {
                  BSItemsNoProcesados = new BindingSource();
                  BSItemsNoProcesados.DataSource = Presenter.DTNoProcesados;
                  grdItemsNoProcesados.DataSource = BSItemsNoProcesados;
                  bindingNavigator1.BindingSource = BSItemsNoProcesados;
                  spcBase.Panel2Collapsed = false;

                  Infrastructure.WinForms.Controls.GridAutoFit.Fit(this.grdItemsNoProcesados);
                  grdItemsNoProcesados.ShowFilteringRow = false;
                  grdItemsNoProcesados.EnableFiltering = false;
                  grdItemsNoProcesados.MasterTemplate.EnableFiltering = false;
                  grdItemsNoProcesados.EnableGrouping = false;
                  grdItemsNoProcesados.MasterTemplate.EnableGrouping = false;
                  grdItemsNoProcesados.EnableSorting = false;
                  grdItemsNoProcesados.MasterTemplate.EnableCustomSorting = false;
                  grdItemsNoProcesados.AllowColumnHeaderContextMenu = false;
                  grdItemsNoProcesados.AllowCellContextMenu = false;

                  BSItems.ResetBindings(false);

                  Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Presenter.Title, "No se proceso el archivo completo de conciliación, podra ver los registro no procesados en la zona inferior.", Presenter.MsgError);
               }
               else
               {
                  /* Solo muestra las observaciones de los registros que al ser procesados tienen alguna observación */
                  spcResultado.Panel1Collapsed = false;
                  Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Presenter.Title, "No se proceso la conciliacion, se sucitaron los siguientes errores.", Presenter.MsgError);
               }
            }
            pgbBase.Visible = false;
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al Conciliar.", ex); }
      }
      private void Anular()
      {
         try
         {
            if (Infrastructure.WinForms.Controls.Dialogos.MostrarMensajePregunta(Presenter.Title, "¿Deseas Anular la liquidación seleccionada?", Infrastructure.WinForms.Controls.Dialogos.LabelBoton.Si_No) == System.Windows.Forms.DialogResult.Yes)
            {
               if (Presenter.Anular())
               {
                  Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeSatisfactorio(Presenter.Title, "Liquidacion Anulada Satisfactoriamente.");
                  btnNuevo_Click(null, null);
               }
            }
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al aprobar.", ex); }
      }
      private void GetFiltros()
      {
         try
         {
            Presenter.F_LIQU_Estado = null;
            if (cmbLIQU_Estado.ConstantesSelectedItem != null)
            {
               Presenter.F_LIQU_Estado = cmbLIQU_Estado.ConstantesSelectedItem.CONS_CodTipo;
               Presenter.R_Estado = cmbLIQU_Estado.ConstantesSelectedItem.CONS_Desc_SPA;
            }
            Presenter.F_Statement = chkStatement.Checked;
            Presenter.F_UnidadNegocio = null; if (cmbUnidadNegocio.ConstantesSelectedItem != null) { Presenter.F_UnidadNegocio = cmbUnidadNegocio.ConstantesSelectedItem.CONS_CodTipo; }
            Presenter.F_ENTC_Codigo = null;
            if (txaENTC_Codigo.SelectedItem != null)
            {
               Presenter.F_ENTC_Codigo = txaENTC_Codigo.SelectedItem.ENTC_Codigo;
               Presenter.R_Agente = String.Format("[{0}] - {1}", txaENTC_Codigo.SelectedItem.ENTC_Codigo, txaENTC_Codigo.SelectedItem.ENTC_RazonSocial);
            }
         }
         catch (Exception)
         { throw; }
      }
      private void Exportar()
      {
         try
         {
            List<String> Titulos = new List<String>();
            Titulos.Add("Liquidación Agentes");
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
            btnNuevo.Enabled = true;
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al deshacer la vista.", ex); }
      }
      private void AyudaLiquidacion()
      {
         try
         {
            Presenter.AyudaLiquidacion(txaLIQU_Codigo.Text, chkIncluirPendientes.Checked);
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al usar la ayuda de liquidación.", ex); }
      }
      private void ExportarNoProcesados()
      {
         try
         {
            List<String> Titulos = new List<String>();
            Titulos.Add(Presenter.Title);
            Int32 _fila = 2;
            Infrastructure.WinForms.Controls.ExcelAportes _xls = new Infrastructure.WinForms.Controls.ExcelAportes(1, Titulos, "");
            Object[] _cabeceras = new Object[1];
            DataTable _dt = _xls.RadGridViewToDataTable(grdItemsNoProcesados, ref _cabeceras, grdItems.FilterDescriptors.Count > 0);
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
      private void ShowControlesApertura()
      {
         btnNuevo.Enabled = true;
         switch (Presenter.Item.LIQU_Estado)
         {
            case "A":
               btnLiquidar.Enabled = true;
               btnAprobar.Enabled = true;
               btnAnular.Enabled = true;
               btnImprimir.Enabled = true;
               btnConciliar.Enabled = true;
               grdItems.ReadOnly = false;
               break;
            case "C":
               btnLiquidar.Enabled = false;
               btnAprobar.Enabled = false;
               btnAnular.Enabled = true;
               btnImprimir.Enabled = true;
               btnConciliar.Enabled = false;
               grdItems.ReadOnly = false;
               break;
            case "X":
               btnLiquidar.Enabled = false;
               btnAprobar.Enabled = false;
               btnAnular.Enabled = false;
               btnImprimir.Enabled = false;
               btnConciliar.Enabled = false;
               grdItems.ReadOnly = true;
               break;
            default:
               btnLiquidar.Enabled = false;
               btnAprobar.Enabled = false;
               btnAnular.Enabled = false;
               btnImprimir.Enabled = false;
               btnConciliar.Enabled = false;
               grdItems.ReadOnly = true;
               break;
         }
      }
      #endregion

      #region [ Eventos ]
      private void btnNuevo_Click(object sender, EventArgs e)
      { Nuevo(); }
      private void btnImportarLiquidacion_Click(object sender, EventArgs e)
      {

      }
      private void btnLiquidar_Click(object sender, EventArgs e)
      { Liquidar(); }
      private void btnConciliar_Click(object sender, EventArgs e)
      { Conciliar(); }
      private void btnAprobar_Click(object sender, EventArgs e)
      { Aprobar(); }
      private void btnAnular_Click(object sender, EventArgs e)
      { Anular(); }
      private void btnImprimir_Click(object sender, EventArgs e)
      { Presenter.Imprimir(); }
      private void BSItems_CurrentItemChanged(object sender, EventArgs e)
      {
         try
         {
            if (BSItems.Current != null)
            {
               String x_observacion = (BSItems.Current as Entities.CtaCte).ObservacionesConciliacion;
               if (!String.IsNullOrEmpty(x_observacion))
               {
                  txtObservaciones.Text = x_observacion;
               }
               else { txtObservaciones.Clear(); }
            }
         }
         catch (Exception)
         { }
      }
      private void grdItems_CommandCellClick(object sender, EventArgs e)
      {
         try
         {
            if (sender is Telerik.WinControls.UI.GridCommandCellElement)
            {
               switch ((((Telerik.WinControls.UI.GridCommandCellElement)(sender)).CommandButton).TextElement.Text)
               {
                  case "Editar":
                     Presenter.Editar();
                     break;
                  case "Eliminar":
                     //SeleccionarItem();
                     //Presenter.Eliminar();
                     break;
               }
            }
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al cargar los botones para editar y eliminar.", ex); }

      }
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
      private void txaLIQU_Codigo_AyudaClick(object sender, EventArgs e)
      { AyudaLiquidacion(); }
      private void txaLIQU_Codigo_AyudaValueChanged(object sender, EventArgs e)
      {
         try
         {
            if (txaLIQU_Codigo.Value == null)
            {
               txaLIQU_Codigo.AyudaValueChanged -= txaLIQU_Codigo_AyudaValueChanged;
               txaLIQU_Codigo.AyudaValueChanged -= txaLIQU_Codigo_AyudaValueChanged;
               txaLIQU_Codigo.AyudaValueChanged -= txaLIQU_Codigo_AyudaValueChanged;
               btnNuevo_Click(null, null);
               //ClearItem();
               txaLIQU_Codigo.AyudaValueChanged -= txaLIQU_Codigo_AyudaValueChanged;
               txaLIQU_Codigo.AyudaValueChanged -= txaLIQU_Codigo_AyudaValueChanged;
               txaLIQU_Codigo.AyudaValueChanged += txaLIQU_Codigo_AyudaValueChanged;
            }
         }
         catch (Exception)
         { }
      }
      private void btnExportarNoProcesados_Click(object sender, EventArgs e)
      { ExportarNoProcesados(); }
      private void txaENTC_Codigo_SelectedItemChanged(object sender, EventArgs e)
      {
         try
         {
            if (txaENTC_Codigo.SelectedItem == null)
            {
               grdItems.DataSource = null;
               BSItems.DataSource = null;
               grdItems.Enabled = false;
               btnConciliar.Enabled = false;
               btnLiquidar.Enabled = false;
            }

         }
         catch (Exception)
         { }
      }
      private void btnExportar_Click(object sender, EventArgs e)
      { Exportar(); }
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

      private void spcResultado_SplitterMoved(object sender, SplitterEventArgs e)
      {

      }
   }
}
