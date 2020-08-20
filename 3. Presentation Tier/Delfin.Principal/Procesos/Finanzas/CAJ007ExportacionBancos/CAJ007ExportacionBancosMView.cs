using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Infrastructure.Aspect.Collections;
using Telerik.WinControls.UI;
using Telerik.WinControls;
using Delfin.Principal.Properties;
using Delfin.Controls;

namespace Delfin.Principal
{
   public partial class CAJ007ExportacionBancosMView : Form, ICAJ007ExportacionBancosMView
   {
      #region [ Variables ]

      #endregion

      #region [ Formulario ]
      public CAJ007ExportacionBancosMView()
      {
         InitializeComponent();
         try
         {
            this.FormClosing += new FormClosingEventHandler(MView_FormClosing);
            this.FormClosed += CAJ007ExportacionBancosMView_FormClosed;

            btnBuscar.Click += btnBuscar_Click;
            btnGuardar.Click += btnGuardar_Click;
            btnSalir.Click += btnSalir_Click;
            btnExportarTXT.Click += btnExportarTXT_Click;

            cmbTIPO_CodMND.SelectedIndexChanged += cmbTIPO_CodMND_SelectedIndexChanged;
            txaCUBA_Codigo.SelectedItemCuentaBancariaChanged += txaCUBA_Codigo_SelectedItemCuentaBancariaChanged;
            cmbTIPE_Codigo.SelectedIndexChanged += cmbTIPE_Codigo_SelectedIndexChanged;

            grdItems.CommandCellClick += grdItems_CommandCellClick;
            grdItems.CellFormatting += grdItems_CellFormatting;
            grdItems.CellEndEdit += grdItems_CellEndEdit;

            BSItems = new BindingSource();
            grdItems.DataSource = BSItems;

            lblTIPO_CodMND.Enabled = false;
            cmbTIPO_CodMND.Enabled = false;
            txtPLAN_Codigo.Enabled = false;
            cmbTIPO_CodBCO.Enabled = false;
            cmbPLAN_Tipo.Enabled = false;
            txnMonto.ReadOnly = true;
            cmbPLAN_Tipo.Tag = "PLAN_TipoMSGERROR";
            txtPLAN_Concepto.Tag = "PLAN_ConceptoMSGERROR";
            dtpPLAN_FechaEmision.Tag = "PLAN_FechaEmisionMSGERROR";

            this.Load += CAJ007ExportacionBancosMView_Load;
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error inicializando el formulario MView.", ex); }
      }

      private void CAJ007ExportacionBancosMView_FormClosed(object sender, FormClosedEventArgs e)
      { Presenter.IsClosedMView(); }

      private void CAJ007ExportacionBancosMView_Load(object sender, EventArgs e)
      {

      }
      #endregion

      #region [ Propiedades ]
      public CAJ007ExportacionBancosPresenter Presenter { get; set; }
      private bool Closing = false;
      private System.Collections.Hashtable HashFormulario { get; set; }

      public BindingSource BSItems { get; set; }

      #endregion

      #region [ ICAJ007ExportacionBancosMView ]
      public void LoadView()
      {
         try
         {
            switch (Presenter.TPlanilla)
            {
               case Delfin.Entities.Planillas.TipoPlanilla.MedioVirtual:
                  txaCUBA_Codigo.LoadControl(Presenter.ContainerService, "Ayuda de Cuenta Bancaria", Delfin.Controls.Entorno.ItemEmpresa.EMPR_Codigo, Presenter.Session.UserName, Delfin.Controls.CuentaBancaria.TipoAyuda.MedioVirtual);
                  this.Text = "Exportación a Bancos";
                  chkMostrarCtaCte.Checked = true;
                  chkMostrarCtaInterbancaria.Checked = true;
                  tblFiltroEB.Visible = true;
                  break;
               case Delfin.Entities.Planillas.TipoPlanilla.Detracciones:
                  this.Text = "Exportación de Detracciones";
                  txaCUBA_Codigo.LoadControl(Presenter.ContainerService, "Ayuda de Cuenta Bancaria", Delfin.Controls.Entorno.ItemEmpresa.EMPR_Codigo, Presenter.Session.UserName, Delfin.Controls.CuentaBancaria.TipoAyuda.Detracciones);
                  label1.Text = "Mostrar Proveedores con Cuenta para realizar Detracción";
                  tlpCBusqueda.ColumnStyles[3].Width = 0;
                  tlpCBusqueda.ColumnStyles[4].Width = 0;
                  tlpCBusqueda.ColumnStyles[5].Width = 0;
                  label2.Visible = false;
                  chkMostrarCtaInterbancaria.Visible = false;
                  chkMostrarCtaCte.Checked = true;
                  tblFiltroEB.Visible = false;
                  break;
               default:
                  break;
            }

            cmbTIPE_Codigo.LoadControl(Presenter.ContainerService, "Tipo de Entidad", "< Todos >", ListSortDirection.Ascending);
            txaENTC_Codigo.LoadControl(Presenter.ContainerService, Delfin.Controls.TiposEntidad.TIPE_Cliente, null, null, true);
            cmbPLAN_Tipo.LoadControl("Ayuda de Tipo Plantilla", Delfin.Controls.Tipos.ComboBoxConstantes.OConstantes.TipoPlantilla, "< Sel. Tipo Plantilla >", ListSortDirection.Ascending);
            cmbTIPO_CodMND.LoadControl(Presenter.ContainerService, "Ayuda de Moneda", "MND", "< Sel. Moneda >", ListSortDirection.Ascending);
            cmbTIPO_CodBCO.LoadControl(Presenter.ContainerService, "Ayuda de Bancos", "BCO", "< Sel. Banco >", ListSortDirection.Ascending);

            dtpPLAN_FechaEmision.NSFecha = Presenter.Fecha;

            FormatDataGrid();

         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error en el LoadView.", ex); }
      }

      public void ClearItem()
      {
         try
         {
            errorProviderPlanillas.Clear();


         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error en ClearItem.", ex); }
      }
      public void GetItem()
      {
         try
         {
            errorProviderPlanillas.Clear();
            if (txaCUBA_Codigo.SelectedItem != null)
            {
               Presenter.Item.ItemCuentasBancarias = txaCUBA_Codigo.SelectedItem;
               Presenter.Item.Banco = cmbTIPO_CodBCO.TiposSelectedItem.TIPO_DescC;
            }
            if (cmbPLAN_Tipo.ConstantesSelectedItem != null) { Presenter.Item.PLAN_Tipo = cmbPLAN_Tipo.ConstantesSelectedItem.CONS_CodTipo; } else { Presenter.Item.PLAN_Tipo = null; }
            if (!String.IsNullOrEmpty(txtPLAN_Concepto.Text)) { Presenter.Item.PLAN_Concepto = txtPLAN_Concepto.Text; }
            if (dtpPLAN_FechaEmision.NSFecha.HasValue) { Presenter.Item.PLAN_FechaEmision = dtpPLAN_FechaEmision.NSFecha; }
            Presenter.Item.TipoCambio = txnMOVI_TipoCambio.Value;
            Presenter.Item.RUC_Empresa = Presenter.RUC_Empresa;
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error en GetItem.", ex); }
      }
      public void SetItem()
      {
         try
         {
            if (Presenter.Item != null)
            {
               if (Presenter.Item.PLAN_FechaEmision.HasValue) { dtpPLAN_FechaEmision.NSFecha = Presenter.Item.PLAN_FechaEmision; }
               if (!String.IsNullOrEmpty(Presenter.Item.PLAN_Codigo)) { txtPLAN_Codigo.Text = Presenter.Item.PLAN_Codigo; }
               if (!String.IsNullOrEmpty(Presenter.Item.CUBA_Codigo)) { txaCUBA_Codigo.SetCuentaBancaria(Presenter.Item.EMPR_Codigo, Presenter.Item.CUBA_Codigo); }
               if (!String.IsNullOrEmpty(Presenter.Item.PLAN_Tipo)) { cmbPLAN_Tipo.ConstantesSelectedValue = Presenter.Item.PLAN_Tipo; }
               if (!String.IsNullOrEmpty(Presenter.Item.PLAN_Concepto)) { txtPLAN_Concepto.Text = Presenter.Item.PLAN_Concepto; }

               txnMOVI_TipoCambio.Value = Presenter.TipoCambio;
               txnMonto.Value = Presenter.Item.Monto;
               BSItems.DataSource = Presenter.Item.ListDetCtaCte;
               BSItems.ResetBindings(false);
               grdItems.BestFitColumns();
               if (Presenter.Item.Instance == Infrastructure.Aspect.BusinessEntity.InstanceEntity.Added)
               {
                  btnExportarTXT.Enabled = false;
               }
               else
               {
                  btnExportarTXT.Enabled = true;
               }
            }

            EnabledItem();
            HashFormulario = Infrastructure.Client.FormClose.FormValidateChanges.iniciarComparacionFormulario(this);
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error en SetItem.", ex); }
      }
      private void EnabledItem()
      {
         try
         {

         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error en EnabledItem.", ex); }
      }

      public void SetEnabledEdit(Boolean x_opcion)
      {
         try
         {
            txaCUBA_Codigo.Enabled = x_opcion;
            cmbPLAN_Tipo.Enabled = x_opcion;

         }
         catch (Exception)
         { }
      }

      public void ShowValidation()
      {
         try
         {
            Infrastructure.Client.FormClose.FormShowErrorProvider<Entities.Planillas>.Validate(Presenter.Item, this, errorProviderPlanillas);
            Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Presenter.Title, "Existen campos obligatorios, revise los detalles.", Presenter.Item.MensajeError);
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error en ShowValidation.", ex); }
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

            GridViewCommandColumn commandColumn;
            commandColumn = new GridViewCommandColumn();
            commandColumn.Name = "CtaCte";
            commandColumn.HeaderText = "Cta Cte.";
            commandColumn.DefaultText = "CtaCte";
            commandColumn.UseDefaultText = true;
            this.grdItems.Columns.Add(commandColumn);
            this.grdItems.Columns["CtaCte"].AllowSort = false;
            this.grdItems.Columns["CtaCte"].WrapText = true;
            this.grdItems.Columns["CtaCte"].AllowFiltering = false;

            GridViewCheckBoxColumn checkboxColum = new GridViewCheckBoxColumn();
            //checkboxColum.DataType = typeof(bool);
            checkboxColum.Name = "Seleccionar";
            checkboxColum.HeaderText = "Seleccionar";
            checkboxColum.FieldName = "Seleccionar";
            grdItems.Columns.Add(checkboxColum);
            grdItems.Columns["Seleccionar"].Width = 90;
            grdItems.Columns["Seleccionar"].ReadOnly = false;

            this.grdItems.Columns.Add("TIPO_TDO", "Tipo", "TIPO_TDO");
            this.grdItems.Columns.Add("CCCT_Serie", "Serie", "CCCT_Serie");
            this.grdItems.Columns.Add("CCCT_Numero", "Número", "CCCT_Numero");
            this.grdItems.Columns.Add("ENTC_DocIden", "RUC", "ENTC_DocIden");
            this.grdItems.Columns.Add("ENTC_RazonSocial", "Entidad", "ENTC_RazonSocial");
            this.grdItems.Columns.Add("CCCT_FechaEmision", "Fecha", "CCCT_FechaEmision");
            this.grdItems.Columns.Add("CCCT_Pendiente_Text", "Monto", "CCCT_Pendiente_Text");
            this.grdItems.Columns.Add("CCCT_FechaVcto", "Fec. Vencimiento", "CCCT_FechaVcto");

            this.grdItems.Columns.Add("OV_OP", "OV / OP", "OV_OP");
            this.grdItems.Columns.Add("MBL_HBL", "MBL / HBL", "MBL_HBL");
            this.grdItems.Columns.Add("NAVE_Nombre", "Nave Viaje", "NAVE_Nombre");

            this.grdItems.Columns.Add("CCCT_Estado", "Estado", "CCCT_Estado");
            this.grdItems.Columns.Add("CCCT_Codigo", "Nro.", "CCCT_Codigo");
            this.grdItems.Columns.Add("MODULO", "Modulo", "MODULO");

            if (Presenter.TPlanilla == Entities.Planillas.TipoPlanilla.MedioVirtual)
            { this.grdItems.Columns.Add("ENTC_Interbancario", "Cta. Interbancaria", "ENTC_Interbancario"); }
            this.grdItems.Columns.Add("ENCB_NroCuenta", "Cta. Asignada", "ENCB_NroCuenta");


            grdItems.Columns["Seleccionar"].ReadOnly = false;
            grdItems.Columns["TIPO_TDO"].ReadOnly = true;
            grdItems.Columns["CCCT_Serie"].ReadOnly = true;
            grdItems.Columns["CCCT_Numero"].ReadOnly = true;
            grdItems.Columns["ENTC_DocIden"].ReadOnly = true;
            grdItems.Columns["ENTC_RazonSocial"].ReadOnly = true;
            grdItems.Columns["CCCT_FechaEmision"].FormatString = "{0:dd/MM/yyyy}";
            grdItems.Columns["CCCT_FechaEmision"].ReadOnly = true;
            grdItems.Columns["CCCT_Pendiente_Text"].ReadOnly = true;
            grdItems.Columns["CCCT_Pendiente_Text"].TextAlignment = ContentAlignment.MiddleRight;
            grdItems.Columns["CCCT_Pendiente_Text"].WrapText = true;
            grdItems.Columns["CCCT_FechaVcto"].ReadOnly = true;
            grdItems.Columns["OV_OP"].ReadOnly = true;
            grdItems.Columns["NAVE_Nombre"].ReadOnly = true;
            grdItems.Columns["MBL_HBL"].ReadOnly = true;

            grdItems.Columns["CCCT_Estado"].ReadOnly = true;
            grdItems.Columns["CCCT_Codigo"].ReadOnly = true;
            grdItems.Columns["MODULO"].ReadOnly = true;

            if (Presenter.TPlanilla == Entities.Planillas.TipoPlanilla.MedioVirtual)
            { grdItems.Columns["ENTC_Interbancario"].ReadOnly = true; }
            grdItems.Columns["ENCB_NroCuenta"].ReadOnly = true;

            /* Crear Grupor para Unir cabeceras */
            ColumnGroupsViewDefinition columnGroupsView = new ColumnGroupsViewDefinition();
            columnGroupsView.ColumnGroups.Add(new GridViewColumnGroup(""));
            columnGroupsView.ColumnGroups.Add(new GridViewColumnGroup(""));
            columnGroupsView.ColumnGroups.Add(new GridViewColumnGroup("Documento"));
            columnGroupsView.ColumnGroups.Add(new GridViewColumnGroup("Datos Vinculados"));
            columnGroupsView.ColumnGroups.Add(new GridViewColumnGroup("Transacción"));
            columnGroupsView.ColumnGroups.Add(new GridViewColumnGroup("Datos Bancarios"));

            int index = 0;

            columnGroupsView.ColumnGroups[index].Rows.Add(new GridViewColumnGroupRow());
            columnGroupsView.ColumnGroups[index].ShowHeader = false;
            columnGroupsView.ColumnGroups[index].Rows[0].Columns.Add(this.grdItems.Columns["CtaCte"]);
            index++;

            columnGroupsView.ColumnGroups[index].Rows.Add(new GridViewColumnGroupRow());
            columnGroupsView.ColumnGroups[index].ShowHeader = false;
            columnGroupsView.ColumnGroups[index].Rows[0].Columns.Add(this.grdItems.Columns["Seleccionar"]);
            index++;

            columnGroupsView.ColumnGroups[index].Rows.Add(new GridViewColumnGroupRow());
            columnGroupsView.ColumnGroups[index].Rows[0].Columns.Add(this.grdItems.Columns["TIPO_TDO"]);
            columnGroupsView.ColumnGroups[index].Rows[0].Columns.Add(this.grdItems.Columns["CCCT_Serie"]);
            columnGroupsView.ColumnGroups[index].Rows[0].Columns.Add(this.grdItems.Columns["CCCT_Numero"]);
            columnGroupsView.ColumnGroups[index].Rows[0].Columns.Add(this.grdItems.Columns["ENTC_DocIden"]);
            columnGroupsView.ColumnGroups[index].Rows[0].Columns.Add(this.grdItems.Columns["ENTC_RazonSocial"]);
            columnGroupsView.ColumnGroups[index].Rows[0].Columns.Add(this.grdItems.Columns["CCCT_FechaEmision"]);
            columnGroupsView.ColumnGroups[index].Rows[0].Columns.Add(this.grdItems.Columns["CCCT_Pendiente_Text"]);
            columnGroupsView.ColumnGroups[index].Rows[0].Columns.Add(this.grdItems.Columns["CCCT_FechaVcto"]);
            index++;

            columnGroupsView.ColumnGroups[index].Rows.Add(new GridViewColumnGroupRow());
            columnGroupsView.ColumnGroups[index].Rows[0].Columns.Add(this.grdItems.Columns["OV_OP"]);
            columnGroupsView.ColumnGroups[index].Rows[0].Columns.Add(this.grdItems.Columns["MBL_HBL"]);
            columnGroupsView.ColumnGroups[index].Rows[0].Columns.Add(this.grdItems.Columns["NAVE_Nombre"]);
            index++;

            columnGroupsView.ColumnGroups[index].Rows.Add(new GridViewColumnGroupRow());
            columnGroupsView.ColumnGroups[index].ShowHeader = true;
            columnGroupsView.ColumnGroups[index].Rows[0].Columns.Add(this.grdItems.Columns["CCCT_Codigo"]);
            columnGroupsView.ColumnGroups[index].Rows[0].Columns.Add(this.grdItems.Columns["CCCT_Estado"]);
            columnGroupsView.ColumnGroups[index].Rows[0].Columns.Add(this.grdItems.Columns["MODULO"]);
            index++;

            columnGroupsView.ColumnGroups[index].Rows.Add(new GridViewColumnGroupRow());
            columnGroupsView.ColumnGroups[index].ShowHeader = true;
            if (Presenter.TPlanilla == Entities.Planillas.TipoPlanilla.MedioVirtual)
            { columnGroupsView.ColumnGroups[index].Rows[0].Columns.Add(this.grdItems.Columns["ENTC_Interbancario"]); }
            columnGroupsView.ColumnGroups[index].Rows[0].Columns.Add(this.grdItems.Columns["ENCB_NroCuenta"]);
            index++;

            grdItems.ViewDefinition = columnGroupsView;

            /* Propiedades Finales */
            grdItems.ReadOnly = false;
            grdItems.ShowFilteringRow = false;
            grdItems.EnableFiltering = false;
            grdItems.MasterTemplate.EnableFiltering = false;
            grdItems.EnableGrouping = false;
            grdItems.MasterTemplate.EnableGrouping = false;
            grdItems.EnableSorting = false;
            grdItems.MasterTemplate.EnableCustomSorting = false;
            grdItems.AutoGenerateColumns = false;

         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, Infrastructure.Aspect.Constants.Mensajes.FormatDataGridView + " (Grid Servicios)", ex); }
      }

      private void Buscar()
      {
         try
         {
            if (Presenter != null)
            {
               if (txaCUBA_Codigo.SelectedItem != null)
               {
                  Presenter.F_CUBA_Codigo = txaCUBA_Codigo.SelectedItem.CUBA_Codigo;
                  Presenter.F_TIPO_TabMND = txaCUBA_Codigo.SelectedItem.TIPO_TabMND;
                  Presenter.F_TIPO_CodMND = txaCUBA_Codigo.SelectedItem.TIPO_CodMND;
                  Presenter.F_TIPO_TabBCO = txaCUBA_Codigo.SelectedItem.TIPO_TabBCO;
                  Presenter.F_TIPO_CodBCO = txaCUBA_Codigo.SelectedItem.TIPO_CodBCO;
                  Presenter.F_MostrarTodos = chkMostrarTodos.Checked;
                  Presenter.F_MostrarCtaCte = chkMostrarCtaCte.Checked;
                  Presenter.F_MostrarCtaInterbancaria = chkMostrarCtaInterbancaria.Checked;
                  Presenter.F_FecIniDocs = dtpFecIni.NSFecha;
                  Presenter.F_FecFinDocs = dtpFecFin.NSFecha;
                  Presenter.F_ENTC_Codigo = null; if (txaENTC_Codigo.SelectedItem != null) { Presenter.F_ENTC_Codigo = txaENTC_Codigo.SelectedItem.ENTC_Codigo; }

                  Presenter.Buscar(txaCUBA_Codigo.SelectedItem.CUBA_Codigo);
               }
               else
               {
                  Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Presenter.Title, "Debe ingresar una cuenta bancaria.");
               }
            }
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al buscar los documentos asociados a la cuenta bancaria.", ex); }
      }

      private void AbrirCtaCte()
      {
         try
         {
            if (BSItems.Current != null)
            {
               Entities.DetCtaCte _detctacte = (BSItems.Current as Entities.DetCtaCte);
               Presenter.AbriCtaCte(_detctacte);
            }
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al Abrir Cta. Cte. del Item.", ex); }
      }

      public void ShowItems()
      {
         try
         {
            BSItems.DataSource = Presenter.Item.ListDetCtaCte;
            grdItems.DataSource = BSItems;
            navItems.BindingSource = BSItems;
            BSItems.ResetBindings(true);
            grdItems.Enabled = grdItems.RowCount > 0;
            grdItems.ShowFilteringRow = false;
            grdItems.EnableFiltering = false;
            grdItems.MasterTemplate.EnableFiltering = false;
            grdItems.EnableGrouping = false;
            grdItems.MasterTemplate.EnableGrouping = false;
            grdItems.EnableSorting = false;
            grdItems.MasterTemplate.EnableCustomSorting = false;
            grdItems.BestFitColumns();
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error cargando los items.", ex); }
      }

      public void SetEnabled(Boolean x_opcion)
      {
         try
         {
            btnBuscar.Visible = x_opcion;
            btnGuardar.Enabled = x_opcion;
            grdItems.Columns["Seleccionar"].IsVisible = x_opcion;
            pnlCBusqueda.Visible = x_opcion;
            tlpCBusqueda.Visible = x_opcion;

            txaCUBA_Codigo.Enabled = x_opcion;
            txtPLAN_Concepto.ReadOnly = !x_opcion;
            dtpPLAN_FechaEmision.Enabled = x_opcion;
            tblFiltroEB.Visible = x_opcion;
         }
         catch (Exception)
         { }
      }

      private void ExportarTXT()
      {
         try
         {
            if (Infrastructure.WinForms.Controls.Dialogos.MostrarMensajePregunta(Presenter.Title, "¿Desea generar el archivo para exportación?"
                  , Infrastructure.WinForms.Controls.Dialogos.LabelBoton.Si_No) == System.Windows.Forms.DialogResult.Yes)
            {
               if (txaCUBA_Codigo.SelectedItem != null)
               {
                  String Nombre = "";
                  ////////////////////////////////////////////////////

                  SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                  saveFileDialog1.Filter = "txt Texto|*.txt";
                  saveFileDialog1.Title = "Guardar Archivo";
                  saveFileDialog1.InitialDirectory = Presenter.PathExportacion;
                  saveFileDialog1.FileName = Presenter.Item.PLAN_Archivo;
                  saveFileDialog1.ShowDialog();

                  if (!String.IsNullOrEmpty(saveFileDialog1.FileName))
                  { Nombre = saveFileDialog1.FileName; }
                  else
                  { Nombre = System.IO.Path.Combine(Presenter.PathExportacion, Presenter.Item.PLAN_Archivo); }

                  ///////////////////////////////////////////////////
                  Nombre = Presenter.ExportarTXT(cmbTIPO_CodBCO.TiposSelectedItem.TIPO_DescC, Nombre);
                  if (Nombre != null)
                  {
                     if (Infrastructure.WinForms.Controls.Dialogos.MostrarMensajePregunta(Presenter.Title, "Se genero el archivo de exportacion : " + Nombre + ", desea abrir la carpeta?", Infrastructure.WinForms.Controls.Dialogos.LabelBoton.Si_No) == System.Windows.Forms.DialogResult.Yes)
                     {
                        //System.Diagnostics.Process.Start(Nombre);
                        System.Diagnostics.Process.Start(System.IO.Path.GetDirectoryName(Nombre));
                     }
                  }
                  else
                  { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Presenter.Title, "No se genero el archivo de exportación."); }
               }
               else { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Presenter.Title, "Debe selecciona una cuenta bancaria."); }
            }
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error exportando a TXT.", ex); }
      }

      #endregion

      #region [ Metodos Documentos ]

      #endregion

      #region [ Eventos ]

      private void btnBuscar_Click(object sender, EventArgs e)
      { Buscar(); }

      private void btnGuardar_Click(object sender, EventArgs e)
      {
         try
         {
            if (Presenter.Guardar(true))
            {
               ExportarTXT();
               this.FormClosing -= MView_FormClosing;
               errorProviderPlanillas.Dispose();
               Presenter.Actualizar();
               this.Close();
            }
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al guardar el formulario.", ex); }
      }

      private void btnSalir_Click(object sender, EventArgs e)
      {
         try
         {
            this.FormClosing -= MView_FormClosing;
            errorProviderPlanillas.Dispose();
            if (Infrastructure.Client.FormClose.FormValidateChanges.verificarCambioFormulario(this, HashFormulario))
            {
               if (Presenter.GuardarCambios() != System.Windows.Forms.DialogResult.Cancel)
               { this.Close(); }
               else
               { this.FormClosing += MView_FormClosing; }
            }
            else
            { this.Close(); }
            Closing = true;
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al cerrar el formulario.", ex); }
      }

      private void cmbTIPO_CodMND_SelectedIndexChanged(object sender, EventArgs e)
      {
         try
         {

         }
         catch (Exception)
         { }
      }

      private void txaCUBA_Codigo_SelectedItemCuentaBancariaChanged(object sender, EventArgs e)
      {
         try
         {
            if (txaCUBA_Codigo.SelectedItem != null)
            {
               cmbTIPO_CodMND.TiposSelectedValue = txaCUBA_Codigo.SelectedItem.TIPO_CodMND;
               cmbTIPO_CodBCO.TiposSelectedValue = txaCUBA_Codigo.SelectedItem.TIPO_CodBCO;
            }
            else
            {
               cmbTIPO_CodMND.SelectedIndex = 0; cmbTIPO_CodBCO.SelectedIndex = 0;
               grdItems.DataSource = null;
               BSItems.DataSource = null;
            }
         }
         catch (Exception)
         { }
      }

      private void MView_FormClosing(object sender, FormClosingEventArgs e)
      {
         try
         {
            if (Closing != true)
            {
               this.FormClosing -= MView_FormClosing;
               if (Infrastructure.Client.FormClose.FormValidateChanges.verificarCambioFormulario(this, HashFormulario))
               {
                  if (btnGuardar.Enabled && Presenter.GuardarCambios() == System.Windows.Forms.DialogResult.Cancel)
                  {
                     e.Cancel = true;
                     this.FormClosing += new FormClosingEventHandler(MView_FormClosing);
                  }
                  else
                  { Presenter.Actualizar(); }
               }
               else
               { Presenter.Actualizar(); }
            }
            else
            { Closing = false; e.Cancel = true; }
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al cerrar el formulario.", ex); }
      }

      private void grdItems_CommandCellClick(object sender, EventArgs e)
      {
         try
         {
            if (sender is Telerik.WinControls.UI.GridCommandCellElement)
            {
               switch ((((Telerik.WinControls.UI.GridCommandCellElement)(sender)).CommandButton).TextElement.Text)
               {
                  case "CtaCte":
                     AbrirCtaCte();
                     break;
               }
            }
         }
         catch (Exception)
         { }
      }

      private void grdItems_CellFormatting(object sender, CellFormattingEventArgs e)
      {
         try
         {
            if (e.CellElement is GridCommandCellElement)
            {
               if (e.Column.Name.Equals("CtaCte"))
               {
                  RadButtonElement bte = (RadButtonElement)e.CellElement.Children[0];
                  if (bte.Image == null)
                  {
                     bte.TextImageRelation = TextImageRelation.Overlay;
                     bte.DisplayStyle = DisplayStyle.Image;
                     bte.ImageAlignment = ContentAlignment.MiddleCenter;
                     bte.Image = Resources.document_pinned_16x16;
                     bte.ToolTipText = @"Abrir Documento Cta. Cte.";
                     bte.AutoSize = true;
                  }
               }
               if (e.CellElement.RowInfo is GridViewNewRowInfo && e.CellElement.ColumnInfo is GridViewCommandColumn)
               {
                  ((RadButtonElement)e.CellElement.Children[0]).Visibility = ElementVisibility.Hidden;
               }
            }
         }
         catch (Exception ex) { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al formatear el icono." + ex.Message); }
      }

      private void btnExportarTXT_Click(object sender, EventArgs e)
      { ExportarTXT(); }

      private void grdItems_CellEndEdit(object sender, GridViewCellEventArgs e)
      {
         try
         {
            grdItems.EndEdit();
            if (Presenter != null && Presenter.Item != null && Presenter.Item.ListDetCtaCte != null && Presenter.Item.ListDetCtaCte.Count > 0)
            {
               Decimal _total = Presenter.Item.ListDetCtaCte.Sum(Det => (Det.Seleccionar ? Det.CCCT_Pendiente : 0)).Value;
               txnMonto.Value = _total;
            }
         }
         catch (Exception)
         { }
      }

      private void cmbTIPE_Codigo_SelectedIndexChanged(object sender, EventArgs e)
      {
         try
         {
            if (cmbTIPE_Codigo.TipoEntidadSelectedItem != null)
            {
               txaENTC_Codigo.TiposEntidad = EntidadClear.getTipoEntidadEnum(cmbTIPE_Codigo.TipoEntidadSelectedItem.TIPE_Codigo);
               txaENTC_Codigo.Enabled = true;
               txaENTC_Codigo.Clear();
            }
            else
            { txaENTC_Codigo.Enabled = false; txaENTC_Codigo.Clear(); }
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al seleccionar un tipo de entidad.", ex); }
      }
      #endregion
   }
}