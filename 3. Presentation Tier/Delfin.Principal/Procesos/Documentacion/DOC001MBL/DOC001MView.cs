using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Delfin.Principal
{
   public partial class DOC001MView : Form, IDOC001MView
   {
      #region [ Variables ]
      
      #endregion

      #region [ Formulario ]
      public DOC001MView()
      {
         InitializeComponent();

         BSCab_Cotizacion_OV = new BindingSource();
         BSDet_CNTR = new BindingSource();

         BSCab_Cotizacion_OV.CurrentItemChanged += BSCab_Cotizacion_OV_CurrentItemChanged;

         grdItems.DataSource = BSCab_Cotizacion_OV;
         grdItemsCNTR.DataSource = BSDet_CNTR;

         btnGuardar.Click += btnGuardar_Click;
         btnSalir.Click += btnSalir_Click;
         this.FormClosing += MView_FormClosing;

         btnAuditoriaCab_MBL.Click += btnAuditoriaCab_MBL_Click;
      }
      #endregion

      #region [ Propiedades ]
      public DOC001Presenter Presenter { get; set; }
      
      private bool Closing = false;
      private System.Collections.Hashtable HashFormulario { get; set; }

      public BindingSource BSCab_Cotizacion_OV { get; set; }
      public BindingSource BSDet_CNTR { get; set; }
      #endregion

      #region [ IDOC001MView ]
      public void LoadView()
      {
         try
         {
            cmbCONS_CodRGM.LoadControl(Presenter.ContainerService, "Constantes de Régimen", "RGM", "< Seleccionar Régimen >", ListSortDirection.Ascending);

            cmbTIPE_CodTransportista.AddComboBoxItem(5, "Transportista", true);
            cmbTIPE_CodTransportista.LoadComboBox("< Seleccionar Transportista >");

            txaENTC_CodTransportista.ContainerService = Presenter.ContainerService;
            txaPUER_Codigo.LoadControl(Presenter.ContainerService, "Ayuda de Puerto");

            cmbTIPO_CodPAQ.LoadControl(Presenter.ContainerService, "Tipos de Tipo de Carga", "PAQ", "< Seleccionar Tipo de Carga >", ListSortDirection.Ascending);

            FormatGridOVs();
            FormatGridCNTR();
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, Infrastructure.Aspect.Constants.Mensajes.LoadView, ex);  }
      }

      public void ClearItem()
      {
         try
         {
            txtCMBL_Numero.Text = String.Empty;
            cmbCONS_CodRGM.ConstantesSelectedValue = null;
            mdtCBML_FecEmi.NSFecha = null;
            //cmbTIPE_CodTransportista
            txaENTC_CodTransportista.Clear();
            txnCMBL_CantHijos.Value = (Decimal)0;
            txaPUER_Codigo.Clear();
            cmbTIPO_CodPAQ.TiposSelectedValue = null;
            txnCMBL_CantBultos.Value = (Decimal)0.00;
            txnCMBL_PesoBruto.Value = (Decimal)0.00;
            txnCMBL_Volumen.Value = (Decimal)0.00;
            txtCMBL_Desc.Text = String.Empty;
            txtCMBL_MarcasNumeros.Text = String.Empty;

            BSCab_Cotizacion_OV.DataSource = null;
            BSCab_Cotizacion_OV.ResetBindings(true);

            BSDet_CNTR.DataSource = null;
            BSDet_CNTR.ResetBindings(true);
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, Infrastructure.Aspect.Constants.Mensajes.ClearItem, ex); }
      }
      public void GetItem()
      {
         try
         {
            Presenter.Item.CMBL_Numero = txtCMBL_Numero.Text;            
            if (cmbCONS_CodRGM.ConstantesSelectedItem != null)
            { 
               Presenter.Item.CONS_TabRGM = cmbCONS_CodRGM.ConstantesSelectedItem.CONS_CodTabla;
               Presenter.Item.CONS_CodRGM = cmbCONS_CodRGM.ConstantesSelectedItem.CONS_CodTipo;
            }
            else
            {
               Presenter.Item.CONS_TabRGM = null;
               Presenter.Item.CONS_CodRGM = null;
            }            
            Presenter.Item.CBML_FecEmi = mdtCBML_FecEmi.NSFecha;
            //cmbTIPE_CodTransportista
            if (txaENTC_CodTransportista.Value != null)
            { Presenter.Item.ENTC_CodTransportista = txaENTC_CodTransportista.Value.ENTC_Codigo; }
            else
            { Presenter.Item.ENTC_CodTransportista = null; }
            Int16 _CMBL_CantHijos = 0;
            if (Int16.TryParse(txnCMBL_CantHijos.Value.ToString(), out _CMBL_CantHijos))
            { Presenter.Item.CMBL_CantHijos = _CMBL_CantHijos; }
            else
            { Presenter.Item.CMBL_CantHijos = null; }
            if (txaPUER_Codigo.SelectedItem != null)
            { Presenter.Item.PUER_Codigo = txaPUER_Codigo.SelectedItem.PUER_Codigo; }
            else
            { Presenter.Item.PUER_Codigo = null; }
            if (cmbTIPO_CodPAQ.TiposSelectedItem != null)
            { 
               Presenter.Item.TIPO_TabPAQ = cmbTIPO_CodPAQ.TiposSelectedItem.TIPO_CodTabla;
               Presenter.Item.TIPO_CodPAQ = cmbTIPO_CodPAQ.TiposSelectedItem.TIPO_CodTipo;
            }
            else
            {
               Presenter.Item.TIPO_TabPAQ = null;
               Presenter.Item.TIPO_CodPAQ = null;
            }
            Presenter.Item.CMBL_CantBultos = txnCMBL_CantBultos.Value;
            Presenter.Item.CMBL_PesoBruto = txnCMBL_PesoBruto.Value;
            Presenter.Item.CMBL_Volumen = txnCMBL_Volumen.Value;
            Presenter.Item.CMBL_Desc = txtCMBL_Desc.Text;
            Presenter.Item.CMBL_MarcasNumeros = txtCMBL_MarcasNumeros.Text;
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, Infrastructure.Aspect.Constants.Mensajes.GetItem, ex); }
      }
      public void SetItem()
      {
         try
         {
            txtCMBL_Numero.Text = Presenter.Item.CMBL_Numero;
            cmbCONS_CodRGM.ConstantesSelectedValue = Presenter.Item.CONS_CodRGM;
            mdtCBML_FecEmi.NSFecha = Presenter.Item.CBML_FecEmi;
            cmbTIPE_CodTransportista.ComboIntSelectedValue = Presenter.Item.TIPE_CodTransportista;
            if (Presenter.Item.ENTC_CodTransportista.HasValue)
            { txaENTC_CodTransportista.SetValue(Presenter.Item.ENTC_CodTransportista.Value); }
            if (Presenter.Item.CMBL_CantHijos.HasValue)
            { txnCMBL_CantHijos.Value = Presenter.Item.CMBL_CantHijos.Value; }
            txaPUER_Codigo.SelectedValue = Presenter.Item.PUER_Codigo;
            cmbTIPO_CodPAQ.TiposSelectedValue = Presenter.Item.TIPO_CodPAQ;
            if (Presenter.Item.CMBL_CantBultos.HasValue)
            { txnCMBL_CantBultos.Value = Presenter.Item.CMBL_CantBultos.Value; }
            if (Presenter.Item.CMBL_PesoBruto.HasValue)
            { txnCMBL_PesoBruto.Value = Presenter.Item.CMBL_PesoBruto.Value; }
            if (Presenter.Item.CMBL_Volumen.HasValue)
            { txnCMBL_Volumen.Value = Presenter.Item.CMBL_Volumen.Value; }
            txtCMBL_Desc.Text = Presenter.Item.CMBL_Desc;
            txtCMBL_MarcasNumeros.Text = Presenter.Item.CMBL_MarcasNumeros;

            BSCab_Cotizacion_OV.DataSource = Presenter.Item.ListCab_Cotizacion_OV;
            BSCab_Cotizacion_OV.ResetBindings(true);

            SetDetCNTR();

            EnableItem(true);

            HashFormulario = Infrastructure.Client.FormClose.FormValidateChanges.iniciarComparacionFormulario(this);
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, Infrastructure.Aspect.Constants.Mensajes.SetItem, ex); }
      }
      public void EnableItem(bool Enabled)
      {
         try
         {
            txtCMBL_Numero.Enabled = false; //Enabled;
            cmbCONS_CodRGM.Enabled = false; //Enabled;
            mdtCBML_FecEmi.Enabled = false; //Enabled;
            cmbTIPE_CodTransportista.Enabled = false; //Enabled;
            txaENTC_CodTransportista.Enabled = false; //Enabled;
            txnCMBL_CantHijos.Enabled = false; //Enabled;
            txaPUER_Codigo.Enabled = false; //Enabled;
            cmbTIPO_CodPAQ.Enabled = Enabled;
            txnCMBL_CantBultos.Enabled = false; //Enabled;
            txnCMBL_PesoBruto.Enabled = false; //Enabled;
            txnCMBL_Volumen.Enabled = false; //Enabled;
            txtCMBL_Desc.Enabled = Enabled;
            txtCMBL_MarcasNumeros.Enabled = Enabled;
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, Infrastructure.Aspect.Constants.Mensajes.EnabledItem, ex); }
      }

      public void SetInstance(Infrastructure.Aspect.Constants.InstanceView x_instance)
      {
         try
         {

         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, Infrastructure.Aspect.Constants.Mensajes.SetInstanceView, ex); }
      }

      public void ShowValidation()
      {
         try
         {
            Infrastructure.Client.FormClose.FormShowErrorProvider<Entities.Cab_MBL>.Validate(Presenter.Item, this, errorValidacion);
            Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Presenter.Title, "Existen campos obligatorios revisar detalles.", Presenter.Item.MensajeError);
         }
         catch (Exception ex)
         {
            Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error en ShowValidation.", ex);
         }
      }

      public void ValidateItem()
      {
         try
         {

         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, Infrastructure.Aspect.Constants.Mensajes.ValidateItem, ex); }
      }
      #endregion

      #region [ Metodos ]
      private void FormatGridOVs()
      {
         try
         {
            Telerik.WinControls.UI.Localization.RadGridLocalizationProvider.CurrentProvider = new Infrastructure.WinForms.Controls.MySpanishRadGridLocalizationProvider();
            this.grdItems.Columns.Clear();
            this.grdItems.AllowAddNewRow = false;

            this.grdItems.Columns.Add("CCOT_NumDoc", "Número OV", "CCOT_NumDoc");
            this.grdItems.Columns.Add("DOOV_MBL", "MBL", "DOOV_MBL");
            this.grdItems.Columns.Add("DOOV_HBL", "HBL", "DOOV_HBL");
            this.grdItems.Columns.Add("ENTC_NomCliente", "Cliente", "ENTC_NomCliente");
            this.grdItems.Columns.Add("ENTC_NomTransportista", "Transportista", "ENTC_NomTransportista");
            this.grdItems.Columns.Add("ENTC_NomAgente", "Agente", "ENTC_NomAgente");
            this.grdItems.Columns.Add("ENTC_NomBroker", "Broker", "ENTC_NomBroker");
            this.grdItems.Columns.Add("CONS_DescRGM", "Régimen", "CONS_DescRGM");
            this.grdItems.Columns.Add("ENTC_NomConsignatario", "Consignatario", "ENTC_NomConsignatario");
            this.grdItems.Columns.Add("ENTC_NomShipper", "Shipper", "ENTC_NomShipper");
            this.grdItems.Columns.Add("PUER_NomEmbarque", "Puerto Embarque", "PUER_NomEmbarque");
            this.grdItems.Columns.Add("PUER_NomOrigen", "Puerto Origen", "PUER_NomOrigen");
            this.grdItems.Columns.Add("PUER_NomDestino", "Puerto Destino", "PUER_NomDestino");
            this.grdItems.Columns.Add("ENTC_NomNotify", "Notify", "ENTC_NomNotify");

            this.grdItems.AutoGenerateColumns = false;
            this.grdItems.BestFitColumns();
            Infrastructure.WinForms.Controls.GridAutoFit.Fit(grdItems);
            this.grdItems.ShowFilteringRow = false;
            this.grdItems.EnableFiltering = false;
            this.grdItems.MasterTemplate.EnableFiltering = false;
            this.grdItems.EnableGrouping = false;
            this.grdItems.MasterTemplate.EnableGrouping = false;
            this.grdItems.EnableSorting = false;
            this.grdItems.MasterTemplate.EnableCustomSorting = false;
         }
         catch (Exception)
         {
            
            throw;
         }
      }
      private void FormatGridCNTR()
      {
         try
         {
            Telerik.WinControls.UI.Localization.RadGridLocalizationProvider.CurrentProvider = new Infrastructure.WinForms.Controls.MySpanishRadGridLocalizationProvider();
            this.grdItemsCNTR.Columns.Clear();
            this.grdItemsCNTR.AllowAddNewRow = false;

            grdItemsCNTR.Columns.Add("CNTR_Numero", "Número del Contenedor", "CNTR_Numero");
            grdItemsCNTR.Columns.Add("DHBL_Precinto", "Precinto", "DHBL_Precinto");
            
            Telerik.WinControls.UI.GridViewComboBoxColumn _tipocontenedor = new Telerik.WinControls.UI.GridViewComboBoxColumn();
            _tipocontenedor.Name = "PACK_Codigo";
            _tipocontenedor.HeaderText = "Tipo Contenedor";
            _tipocontenedor.FieldName = "PACK_Codigo";
            _tipocontenedor.ValueMember = "PACK_Codigo";
            _tipocontenedor.DisplayMember = "PACK_DescC";
            _tipocontenedor.DataSource = Presenter.ListPaquetes;
            this.grdItemsCNTR.Columns.Add(_tipocontenedor);

            grdItemsCNTR.Columns.Add("DHBL_DescProducto", "Descripción de la Carga", "DHBL_DescProducto");
            grdItemsCNTR.Columns.Add("DHBL_MarcasNumeros", "Marcas y Números", "DHBL_MarcasNumeros");
            grdItemsCNTR.Columns.Add("DHBL_CantBultos", "Cantidad de Bultos", "DHBL_CantBultos");
            grdItemsCNTR.Columns.Add("DHBL_PesoBruto", "Peso (Kg.)", "DHBL_PesoBruto");
            grdItemsCNTR.Columns.Add("DHBL_Volumen", "Volumen (M³)", "DHBL_Volumen");


            Telerik.WinControls.UI.GridViewComboBoxColumn _comodity = new Telerik.WinControls.UI.GridViewComboBoxColumn();
            _comodity.Name = "TIPO_CodCDT";
            _comodity.HeaderText = "Comodity";
            _comodity.FieldName = "TIPO_CodCDT";
            _comodity.ValueMember = "TIPO_CodTipo";
            _comodity.DisplayMember = "TIPO_Desc1";
            _comodity.DataSource = Presenter.ListTiposCDT;
            this.grdItemsCNTR.Columns.Add(_comodity);

            Telerik.WinControls.UI.GridViewComboBoxColumn _tipobulto = new Telerik.WinControls.UI.GridViewComboBoxColumn();
            _tipobulto.Name = "TIPO_CodPAC";
            _tipobulto.HeaderText = "Tipo Bulto";
            _tipobulto.FieldName = "TIPO_CodPAC";
            _tipobulto.ValueMember = "TIPO_CodTipo";
            _tipobulto.DisplayMember = "TIPO_Desc1";
            _tipobulto.DataSource = Presenter.ListTiposPAC;
            this.grdItemsCNTR.Columns.Add(_tipobulto);


            Telerik.WinControls.UI.GridViewCheckBoxColumn _esimo = new Telerik.WinControls.UI.GridViewCheckBoxColumn();
            _esimo.Name = "DHBL_EsIMO";
            _esimo.HeaderText = "Es IMO";
            _esimo.FieldName = "DHBL_EsIMO";
            this.grdItemsCNTR.Columns.Add(_esimo);

            Telerik.WinControls.UI.GridViewComboBoxColumn _tipoimo = new Telerik.WinControls.UI.GridViewComboBoxColumn();
            _tipoimo.Name = "TIPO_CodIMO";
            _tipoimo.HeaderText = "Clase IMO";
            _tipoimo.FieldName = "TIPO_CodIMO";
            _tipoimo.ValueMember = "TIPO_CodTipo";
            _tipoimo.DisplayMember = "TIPO_Desc1";
            _tipoimo.DataSource = Presenter.ListTiposIMO;
            this.grdItemsCNTR.Columns.Add(_tipoimo);

            grdItemsCNTR.Columns.Add("DHBL_ContractNRO", "Contract NRO", "DHBL_ContractNRO");

            Telerik.WinControls.UI.GridViewCheckBoxColumn _pp = new Telerik.WinControls.UI.GridViewCheckBoxColumn();
            _pp.Name = "DHBL_PP";
            _pp.HeaderText = "Es Parte Contenedor";
            _pp.FieldName = "DHBL_PP";
            this.grdItemsCNTR.Columns.Add(_pp);

            this.grdItems.AutoGenerateColumns = false;
            this.grdItemsCNTR.BestFitColumns();
            Infrastructure.WinForms.Controls.GridAutoFit.Fit(grdItemsCNTR);
            this.grdItemsCNTR.ShowFilteringRow = false;
            this.grdItemsCNTR.EnableFiltering = false;
            this.grdItemsCNTR.MasterTemplate.EnableFiltering = false;
            this.grdItemsCNTR.EnableGrouping = false;
            this.grdItemsCNTR.MasterTemplate.EnableGrouping = false;
            this.grdItemsCNTR.EnableSorting = false;
            this.grdItemsCNTR.MasterTemplate.EnableCustomSorting = false;
         }
         catch (Exception)
         {
            
            throw;
         }
      }

      private void SetDetCNTR()
      {
         try
         {
            if (BSCab_Cotizacion_OV.Current != null && BSCab_Cotizacion_OV.Current is Entities.Cab_Cotizacion_OV)
            {
               BSDet_CNTR.DataSource = (BSCab_Cotizacion_OV.Current as Entities.Cab_Cotizacion_OV).ItemsDet_CNTR;
               BSDet_CNTR.ResetBindings(true);
            }
         }
         catch (Exception)
         { }
      }
      #endregion

      #region [ Eventos ]
      private void BSCab_Cotizacion_OV_CurrentItemChanged(object sender, EventArgs e)
      { SetDetCNTR(); }

      private void btnGuardar_Click(object sender, EventArgs e)
      {
         try
         {
            if (Presenter.Guardar())
            {
               Closing = true;
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
            errorValidacion.Dispose();
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
            {
               Closing = false;
               //e.Cancel = true;
            }
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al cerrar el formulario.", ex); }
      }
      #endregion

      #region [ Auditoria ]
      private void btnAuditoriaCab_MBL_Click(object sender, EventArgs e)
      {
         try
         {
            ObservableCollection<Infrastructure.Aspect.DataAccess.DataAccessFilterSQL> _filters = new ObservableCollection<Infrastructure.Aspect.DataAccess.DataAccessFilterSQL>();
            _filters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@pintCMBL_codigo", FilterValue = Presenter.Item.CMBL_codigo, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.Int32, FilterSize = 4 });

            Delfin.Controls.AuditoriaView _auditoriaView = new Controls.AuditoriaView(Presenter.ContainerService, Delfin.Controls.TipoAuditoria.AUDI_OPE_Cab_MBL, _filters);
            _auditoriaView.Show();
         }
         catch (Exception)
         { }
      }
      #endregion
   }
}