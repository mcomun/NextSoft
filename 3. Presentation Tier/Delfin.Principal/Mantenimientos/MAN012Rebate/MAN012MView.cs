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

namespace Delfin.Principal
{
   public partial class MAN012MView : Form, IMAN012MView
   {
      #region [ Variables ]

      #endregion

      #region [ Formulario ]
      public MAN012MView()
      {
         InitializeComponent();
         try
         {
            this.FormClosing += new FormClosingEventHandler(MView_FormClosing);
            btnMAN_guardar.Click += btnGuardar_Click;
            btnMAN_salir.Click += btnSalir_Click;

            btnReloadContratos.Click += btnReloadContratos_Click;

            BSGRR_Paquetes = new BindingSource();
            grdGRR_Paquetes.DataSource = BSGRR_Paquetes;

            BSGRR_Contratos = new BindingSource();
            grdGRR_Contrato.DataSource = BSGRR_Contratos;

            this.txnREBA_Valor.KeyPress += new KeyPressEventHandler(this.txnREBA_Valor_KeyPress);
            this.txnREBA_CostoFlete.KeyPress += new KeyPressEventHandler(this.txnREBA_Limite_KeyPress);
            this.txnREBA_CostoFleteDes.KeyPress += new KeyPressEventHandler(this.txnREBA_Limite_KeyPress);
            this.txnREBA_LimiteSup.KeyPress += new KeyPressEventHandler(this.txnREBA_Limite_KeyPress);
            this.txnREBA_LimiteInf.KeyPress += new KeyPressEventHandler(this.txnREBA_Limite_KeyPress);
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al inicializar el formulario MView.", ex); }
      }
      #endregion

      #region [ Propiedades ]
      public MAN012Presenter Presenter { get; set; }
      private bool Closing = false;
      private System.Collections.Hashtable HashFormulario { get; set; }
      public BindingSource BSGRR_Paquetes { get; set; }
      public BindingSource BSGRR_Contratos { get; set; }
      #endregion

      #region [ ICUS007MView ]
      public void LoadView()
      {
         try
         {
            FormatGrid();

            cmbREBA_Tipo.AddComboBoxItem("R", "Rebate", true);
            cmbREBA_Tipo.AddComboBoxItem("G", "GRR");
            cmbREBA_Tipo.LoadComboBox("< Seleccionar Tipo >");

            txaENTC_CodTransportista.ContainerService = Presenter.ContainerService;
            cmbTIPO_CodMnd.LoadControl(Presenter.ContainerService, "Tabla Monedas", "MND", "< Seleccionar Moneda >", ListSortDirection.Ascending);
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error cargando la vista.", ex); }
      }

      public void ClearItem()
      {
         try
         {
            txnREBA_Codigo.Text = "0";
            cmbREBA_Tipo.ComboStrSelectedValue = null;
            txaENTC_CodTransportista.ClearValue();
            mdtREBA_FecIni.NSFecha = null;
            mdtREBA_FecFin.NSFecha = null;
            mdtREBA_FecCalc.NSFecha = null;
            cmbTIPO_CodMnd.TiposSelectedValue = null;
            txnREBA_Valor.Value = (Decimal)0.00;
            txnREBA_CostoFlete.Value = (Decimal)0.00;
            txnREBA_CostoFleteDes.Value = (Decimal)0.00;
            txnREBA_LimiteInf.Value = (Decimal)0.00;
            txnREBA_LimiteSup.Value = (Decimal)0.00;

            txnREBA_ValorPorcentaje.Value = (Decimal)0.00;

            BSGRR_Paquetes.DataSource = null;
            BSGRR_Paquetes.ResetBindings(true);

            BSGRR_Contratos.DataSource = null;
            BSGRR_Contratos.ResetBindings(true);
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error limpiando el item.", ex); }
      }
      public void GetItem()
      {
         try
         {
            if (Presenter != null && Presenter.Item != null)
            {
               //txnREBA_Codigo.Text = "0";
               if (!String.IsNullOrEmpty(cmbREBA_Tipo.ComboStrSelectedValue))
               { Presenter.Item.REBA_Tipo = cmbREBA_Tipo.ComboStrSelectedValue; }
               else
               { Presenter.Item.REBA_Tipo = null; }

               if (txaENTC_CodTransportista.Value != null)
               { Presenter.Item.ENTC_CodTransportista = txaENTC_CodTransportista.Value.ENTC_Codigo; }
               else
               { Presenter.Item.ENTC_CodTransportista = null; }


               Presenter.Item.REBA_FecIni = mdtREBA_FecIni.NSFecha;
               Presenter.Item.REBA_FecFin = mdtREBA_FecFin.NSFecha;
               Presenter.Item.REBA_FecCalc = mdtREBA_FecCalc.NSFecha;

                    if (cmbTIPO_CodMnd.TiposSelectedItem != null)
               {
                  Presenter.Item.TIPO_TabMND = cmbTIPO_CodMnd.TiposSelectedItem.TIPO_CodTabla;
                  Presenter.Item.TIPO_CodMND = cmbTIPO_CodMnd.TiposSelectedItem.TIPO_CodTipo;
               }
               else
               {
                  Presenter.Item.TIPO_TabMND = null;
                  Presenter.Item.TIPO_CodMND = null;
               }
               if (!String.IsNullOrEmpty(Presenter.Item.REBA_Tipo) && Presenter.Item.REBA_Tipo == "R")
               { Presenter.Item.REBA_Valor = txnREBA_Valor.Value; }
               else if (!String.IsNullOrEmpty(Presenter.Item.REBA_Tipo) && Presenter.Item.REBA_Tipo == "G")
               { Presenter.Item.REBA_Valor = txnREBA_ValorPorcentaje.Value; }
               else
               { Presenter.Item.REBA_Valor = txnREBA_Valor.Value; }

               Presenter.Item.REBA_CostoFlete = txnREBA_CostoFlete.Value;
               Presenter.Item.REBA_CostoFleteDes = txnREBA_CostoFleteDes.Value;
               Presenter.Item.REBA_LimiteInf = txnREBA_LimiteInf.Value;
               Presenter.Item.REBA_LimiteSup = txnREBA_LimiteSup.Value;

               

               Presenter.Item.ListGRR_Paquetes = ((ObservableCollection<Entities.GRR_Paquetes>)BSGRR_Paquetes.DataSource).Where(gpac => gpac.PACK_Seleccionar).ToObservableCollection();
               Presenter.Item.ListGRR_Contratos = ((ObservableCollection<Entities.GRR_Contrato>)BSGRR_Contratos.DataSource).Where(gcon => gcon.CONT_Seleccionar).ToObservableCollection();
            }
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error obteniendo el item.", ex); }
      }
      public void SetItem()
      {
         try
         {
            if (Presenter != null && Presenter.Item != null)
            {
               txnREBA_Codigo.Text = Presenter.Item.REBA_Codigo.ToString();
               if (!String.IsNullOrEmpty(Presenter.Item.REBA_Tipo))
               { cmbREBA_Tipo.ComboStrSelectedValue = Presenter.Item.REBA_Tipo; }
               if (Presenter.Item.ENTC_CodTransportista.HasValue)
               { txaENTC_CodTransportista.SetValue(Presenter.Item.ENTC_CodTransportista.Value); }
               mdtREBA_FecIni.NSFecha = Presenter.Item.REBA_FecIni;
               mdtREBA_FecFin.NSFecha = Presenter.Item.REBA_FecFin;
               mdtREBA_FecCalc.NSFecha = Presenter.Item.REBA_FecCalc;
               cmbTIPO_CodMnd.TiposSelectedValue = Presenter.Item.TIPO_CodMND;

               if (!String.IsNullOrEmpty(Presenter.Item.REBA_Tipo) && Presenter.Item.REBA_Tipo == "R")
               { txnREBA_Valor.Value = Presenter.Item.REBA_Valor; }
               else if (!String.IsNullOrEmpty(Presenter.Item.REBA_Tipo) && Presenter.Item.REBA_Tipo == "G")
               { txnREBA_ValorPorcentaje.Value = Presenter.Item.REBA_Valor; }
               else
               { txnREBA_Valor.Value = Presenter.Item.REBA_Valor; }
               
               if (Presenter.Item.REBA_CostoFlete.HasValue)
               { txnREBA_CostoFlete.Value = Presenter.Item.REBA_CostoFlete.Value; }
               if (Presenter.Item.REBA_CostoFleteDes.HasValue)
               { txnREBA_CostoFleteDes.Value = Presenter.Item.REBA_CostoFleteDes.Value; }
               if (Presenter.Item.REBA_LimiteInf.HasValue)
               { txnREBA_LimiteInf.Value = Presenter.Item.REBA_LimiteInf.Value; }
               if (Presenter.Item.REBA_LimiteSup.HasValue)
               { txnREBA_LimiteSup.Value = Presenter.Item.REBA_LimiteSup.Value; }

               BSGRR_Paquetes.DataSource = Presenter.Item.ListGRR_Paquetes;
               BSGRR_Paquetes.ResetBindings(true);

               BSGRR_Contratos.DataSource = Presenter.Item.ListGRR_Contratos;
               BSGRR_Contratos.ResetBindings(true);

               ConfigureGrid();

               EnabledItem();
            }
            HashFormulario = Infrastructure.Client.FormClose.FormValidateChanges.iniciarComparacionFormulario(this);
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error seteando el item.", ex); }
      }

      public void EnabledItem()
      {
         try
         {
            Boolean _enabled = Presenter.Item.REBA_Codigo > 0;

            txnREBA_Codigo.Enabled = !_enabled;
            cmbREBA_Tipo.Enabled = !_enabled;
            txaENTC_CodTransportista.Enabled = !_enabled;
            mdtREBA_FecIni.Enabled = !_enabled;
            mdtREBA_FecFin.Enabled = !_enabled;
            //mdtREBA_FecCalc.Enabled = !_enabled;
                //cmbTIPO_CodMnd.Enabled = !_enabled;
                //txnREBA_Valor.Enabled = !_enabled;
                //txnREBA_CostoFlete.Enabled = !_enabled;
                //txnREBA_CostoFleteDes.Enabled = !_enabled;
                //txnREBA_LimiteInf.Enabled = !_enabled;
                //txnREBA_LimiteSup.Enabled = !_enabled;
            }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error limpiando el item.", ex); }
      }

      public void SetListContratos(ObservableCollection<Entities.Contrato> ListContratos)
      {
         try
         {
            (this.grdGRR_Contrato.Columns["CONT_Numero"] as Telerik.WinControls.UI.GridViewComboBoxColumn).DataSource = ListContratos;

            BSGRR_Contratos.DataSource = Presenter.Item.ListGRR_Contratos;
            BSGRR_Contratos.ResetBindings(true);
         }
         catch (Exception)
         { }
      }

      public void ShowValidation()
      {
         try
         {
            Infrastructure.Client.FormClose.FormShowErrorProvider<Entities.GRR>.Validate(Presenter.Item, this, errorGRR);
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error mostrando la validación", ex); }
      }
      #endregion

      #region [ Metodos ]
      private void FormatGrid()
      {
         try
         {
            Telerik.WinControls.UI.Localization.RadGridLocalizationProvider.CurrentProvider = new Infrastructure.WinForms.Controls.MySpanishRadGridLocalizationProvider();
            this.grdGRR_Paquetes.Columns.Clear();
            this.grdGRR_Paquetes.AllowAddNewRow = false;


            Telerik.WinControls.UI.GridViewCheckBoxColumn _seleccionar = new Telerik.WinControls.UI.GridViewCheckBoxColumn();
            _seleccionar.Name = "PACK_Seleccionar";
            _seleccionar.HeaderText = "Seleccionar";
            _seleccionar.FieldName = "PACK_Seleccionar";
            this.grdGRR_Paquetes.Columns.Add(_seleccionar);

            Telerik.WinControls.UI.GridViewComboBoxColumn _paquete = new Telerik.WinControls.UI.GridViewComboBoxColumn();
            _paquete.Name = "PACK_Codigo";
            _paquete.HeaderText = "Paquete";
            _paquete.FieldName = "PACK_Codigo";
            _paquete.ValueMember = "PACK_Codigo";
            _paquete.DisplayMember = "PACK_Desc";
            _paquete.DataSource = Presenter.ListPaquetes;
            this.grdGRR_Paquetes.Columns.Add(_paquete);




            Telerik.WinControls.UI.Localization.RadGridLocalizationProvider.CurrentProvider = new Infrastructure.WinForms.Controls.MySpanishRadGridLocalizationProvider();
            this.grdGRR_Contrato.Columns.Clear();
            this.grdGRR_Contrato.AllowAddNewRow = false;


            Telerik.WinControls.UI.GridViewCheckBoxColumn _seleccionarContrato = new Telerik.WinControls.UI.GridViewCheckBoxColumn();
            _seleccionarContrato.Name = "CONT_Seleccionar";
            _seleccionarContrato.HeaderText = "Seleccionar";
            _seleccionarContrato.FieldName = "CONT_Seleccionar";
            this.grdGRR_Contrato.Columns.Add(_seleccionarContrato);

            Telerik.WinControls.UI.GridViewComboBoxColumn _contrato = new Telerik.WinControls.UI.GridViewComboBoxColumn();
            _contrato.Name = "CONT_Numero";
            _contrato.HeaderText = "Contrato";
            _contrato.FieldName = "CONT_Numero";
            _contrato.ValueMember = "CONT_Numero";
            _contrato.DisplayMember = "CONT_Numero";
            _contrato.DataSource = null;
            this.grdGRR_Contrato.Columns.Add(_contrato);

            Telerik.WinControls.UI.GridViewTextBoxColumn _contratoequivalencia = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            _contratoequivalencia.Name = "CONT_NumeroEquivalente";
            _contratoequivalencia.HeaderText = "Contrato Equivalente";
            _contratoequivalencia.FieldName = "CONT_NumeroEquivalente";
            this.grdGRR_Contrato.Columns.Add(_contratoequivalencia);

            ConfigureGrid();
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, Infrastructure.Aspect.Constants.Mensajes.FormatDataGridView, ex); }
      }
      private void ConfigureGrid()
      {
         try
         {
            grdGRR_Paquetes.BestFitColumns();
            Infrastructure.WinForms.Controls.GridAutoFit.Fit(grdGRR_Paquetes);
            grdGRR_Paquetes.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;

            this.grdGRR_Paquetes.SelectionMode = Telerik.WinControls.UI.GridViewSelectionMode.CellSelect;
            this.grdGRR_Paquetes.MultiSelect = false;

            this.grdGRR_Paquetes.ShowFilteringRow = false;
            this.grdGRR_Paquetes.EnableFiltering = false;
            this.grdGRR_Paquetes.MasterTemplate.EnableFiltering = false;
            this.grdGRR_Paquetes.EnableGrouping = false;
            this.grdGRR_Paquetes.MasterTemplate.EnableGrouping = false;
            this.grdGRR_Paquetes.EnableSorting = false;
            this.grdGRR_Paquetes.MasterTemplate.EnableCustomSorting = false;

            this.grdGRR_Paquetes.ReadOnly = false;
            this.grdGRR_Paquetes.AllowEditRow = true;

            this.grdGRR_Paquetes.Columns["PACK_Seleccionar"].MinWidth = 80;

            this.grdGRR_Paquetes.Columns["PACK_Codigo"].ReadOnly = true;
            this.grdGRR_Paquetes.Columns["PACK_Codigo"].Width = 400;
            this.grdGRR_Paquetes.Columns["PACK_Codigo"].TextAlignment = ContentAlignment.MiddleLeft;



            grdGRR_Contrato.BestFitColumns();
            Infrastructure.WinForms.Controls.GridAutoFit.Fit(grdGRR_Contrato);
            grdGRR_Contrato.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;

            this.grdGRR_Contrato.SelectionMode = Telerik.WinControls.UI.GridViewSelectionMode.CellSelect;
            this.grdGRR_Contrato.MultiSelect = false;

            this.grdGRR_Contrato.ShowFilteringRow = false;
            this.grdGRR_Contrato.EnableFiltering = false;
            this.grdGRR_Contrato.MasterTemplate.EnableFiltering = false;
            this.grdGRR_Contrato.EnableGrouping = false;
            this.grdGRR_Contrato.MasterTemplate.EnableGrouping = false;
            this.grdGRR_Contrato.EnableSorting = false;
            this.grdGRR_Contrato.MasterTemplate.EnableCustomSorting = false;

            this.grdGRR_Contrato.ReadOnly = false;
            this.grdGRR_Contrato.AllowEditRow = true;

            this.grdGRR_Contrato.Columns["CONT_Seleccionar"].MinWidth = 80;

            this.grdGRR_Contrato.Columns["CONT_Numero"].ReadOnly = true;
            this.grdGRR_Contrato.Columns["CONT_Numero"].Width = 200;
            this.grdGRR_Contrato.Columns["CONT_Numero"].TextAlignment = ContentAlignment.MiddleLeft;

            this.grdGRR_Contrato.Columns["CONT_NumeroEquivalente"].ReadOnly = false;
            this.grdGRR_Contrato.Columns["CONT_NumeroEquivalente"].Width = 200;
            this.grdGRR_Contrato.Columns["CONT_NumeroEquivalente"].TextAlignment = ContentAlignment.MiddleLeft;
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, Infrastructure.Aspect.Constants.Mensajes.FormatDataGridView, ex); }
      }

      private void ConfigurarSegunTipo()
      {
         try
         {
            Boolean _rebate = (!String.IsNullOrEmpty(cmbREBA_Tipo.ComboStrSelectedValue) && cmbREBA_Tipo.ComboStrSelectedValue == "R");
            Boolean _grr = (!String.IsNullOrEmpty(cmbREBA_Tipo.ComboStrSelectedValue) && cmbREBA_Tipo.ComboStrSelectedValue == "G");

            tableRebateGRR.RowStyles[3].Height = _rebate ? 27 : 0;
            lblTIPO_CodMND.Visible = _rebate;
            cmbTIPO_CodMnd.Visible = _rebate;
            lblREBA_Valor.Visible = _rebate;
            txnREBA_Valor.Visible = _rebate;
            tableRebateGRR.RowStyles[4].Height = _rebate ? 27 : 0;
            lblREBA_CostoFlete.Visible = _rebate;
            txnREBA_CostoFlete.Visible = _rebate;
            lblREBA_CostoFleteDes.Visible = _rebate;
            txnREBA_CostoFleteDes.Visible = _rebate;
            tableRebateGRR.RowStyles[5].Height = _rebate ? 27 : 0;
            lblREBA_LimiteInf.Visible = _rebate;
            txnREBA_LimiteInf.Visible = _rebate;
            lblREBA_LimiteSup.Visible = _rebate;
            txnREBA_LimiteSup.Visible = _rebate;

            tableRebateGRR.RowStyles[6].Height = _grr ? 27 : 0;
            lblREBA_ValorPorcentaje.Visible = _grr;
            txnREBA_ValorPorcentaje.Visible = _grr;

            splitRebateGRR.Panel1Collapsed = _grr;

            this.grdGRR_Contrato.Columns["CONT_NumeroEquivalente"].IsVisible = _grr;
         }
         catch (Exception)
         { throw; }
      }
      #endregion

      #region [ Eventos ]
      private void btnGuardar_Click(object sender, EventArgs e)
      {
         try
         {
            if (Presenter.Guardar())
            {
               this.FormClosing -= MView_FormClosing;
               errorGRR.Dispose();
               //'Presenter.Actualizar(); ya esta actualizando al btnGuardar_Click en else presenter
               this.Close();
            }
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al Guardar.", ex); }
      }
      private void btnSalir_Click(object sender, EventArgs e)
      {
         try
         {
            this.FormClosing -= MView_FormClosing;
            errorGRR.Dispose();
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
      private void btnReloadContratos_Click(object sender, EventArgs e)
      {
         try
         {
            Int32? ENTC_CodTransportista = null;
            if (txaENTC_CodTransportista.Value != null) { ENTC_CodTransportista = txaENTC_CodTransportista.Value.ENTC_Codigo; }
            Presenter.GetContratos(ENTC_CodTransportista, mdtREBA_FecIni.NSFecha, mdtREBA_FecFin.NSFecha);
         }
         catch (Exception)
         { }
      }

      private void cmbREBA_Tipo_SelectedIndexChanged(object sender, EventArgs e)
      { ConfigurarSegunTipo(); }

      private void MView_FormClosing(object sender, FormClosingEventArgs e)
      {
         try
         {
            if (Closing != true)
            {
               this.FormClosing -= MView_FormClosing;
               if (Infrastructure.Client.FormClose.FormValidateChanges.verificarCambioFormulario(this, HashFormulario))
               {
                  if (Presenter.GuardarCambios() == System.Windows.Forms.DialogResult.Cancel)
                  {
                     e.Cancel = true;
                     this.FormClosing += new FormClosingEventHandler(MView_FormClosing);
                  }
               }
            }
            else
            { Closing = false; e.Cancel = true; }
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al cerrar el formulario.", ex); }
      }
      private void txnREBA_Valor_KeyPress(object sender, KeyPressEventArgs e)
      {
         try
         {
            txnREBA_CostoFlete.Value = (Decimal)0.00;
            txnREBA_CostoFleteDes.Value = (Decimal)0.00;
            txnREBA_LimiteInf.Value = (Decimal)0.00;
            txnREBA_LimiteSup.Value = (Decimal)0.00;
         }
         catch (Exception ex)
         { throw ex; }
      }
      private void txnREBA_Limite_KeyPress(object sender, KeyPressEventArgs e)
      {
         try
         {
            txnREBA_Valor.Value = (Decimal)0.00;
         }
         catch (Exception ex)
         { throw ex; }
      }
      #endregion

   }
}