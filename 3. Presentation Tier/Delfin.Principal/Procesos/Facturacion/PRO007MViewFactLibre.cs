using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Infrastructure.Aspect.Collections;

namespace Delfin.Principal
{
   public partial class PRO007MViewFactLibre : Form, IPRO007MViewFactLibre
   {

      #region [ Variables ]

      #endregion

      #region [ Propiedades ]

      public PRO007Presenter Presenter { get; set; }
      public BindingSource BSItems { get; set; }

      #endregion

      #region [ Formulario ]

      public PRO007MViewFactLibre()
      {
         InitializeComponent();
         try
         {
            txtDOCV_Numero.Tag = "DOCV_NumeroMSGERROR";
            txnDOCV_TipoCambio.Tag = "DOCV_TipoCambioMSGERROR";
            dtpDOCV_FechaEmision.Tag = "DOCV_FechaEmisionMSGERROR";
            dtpDOCV_FechaVcmto.Tag = "DOCV_FechaVcmtoMSGERROR";
            cmbDOCV_Estado.Tag = "DOCV_EstadoMSGERROR";
            txnDOCV_PrecVtaTotal.Tag = "DOCV_PrecVtaTotalMSGERROR";
            txnDOCV_ValorVtaTotal.Tag = "DOCV_ValorVtaTotalMSGERROR";
            txtDOCV_Observaciones.Tag = "DOCV_ObservacionesMSGERROR";
            txnDOCV_Impuesto1.Tag = "DOCV_Impuesto1MSGERROR";
            txtDOCV_Notas.Tag = "DOCV_NotasMSGERROR";
            cmbDOCV_Serie.Tag = "DOCV_SerieMSGERROR";
            cmbTIPO_CodFPG.Tag = "TIPO_CodFPGMSGERROR";
            cmbTIPO_CodMND.Tag = "TIPO_CodMNDMSGERROR";
            cmbTIPO_CodTDO.Tag = "TIPO_CodTDOMSGERROR";
            txaEntidad.Tag = "ENTC_CodigoMSGERROR";
            cmbTIPE_Codigo.Tag = "TIPE_CodigoMSGERROR";

            txtDOCV_Numero.MaxLength = 20;
            txtDOCV_Observaciones.MaxLength = 1024;
            txtDOCV_Notas.MaxLength = 1000;

            txnDOCV_Impuesto1.Enabled = false;
            txnDOCV_PrecVtaTotal.Enabled = false;
            txnDOCV_ValorVtaTotal.Enabled = false;

            btnGuardar.Click += btnGuardar_Click;
            btnNuevoServicio.Click += btnNuevoServicio_Click;
            cmbTIPE_Codigo.SelectedIndexChanged += cmbTIPE_Codigo_SelectedIndexChanged;
            cmbTIPO_CodMND.SelectedIndexChanged += cmbTIPO_CodMND_SelectedIndexChanged;
            cmbTIPO_CodTDO.SelectedIndexChanged += cmbTIPO_CodTDO_SelectedIndexChanged;
            cmbDOCV_Serie.Enabled = false;
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error inicializando el formulario MView.", ex); }
      }

      #endregion

      #region [ ICUS002MView ]

      public void LoadView()
      {
         try
         {
            cmbDOCV_Estado.LoadControl(Presenter.ContainerService, "Tabla Estado", "FAC", "< Selecione Estado >", ListSortDirection.Descending);
            cmbTIPE_Codigo.LoadControl(Presenter.ContainerService, "Tipo Entidad", "< Sel. Tipo Entidad >", ListSortDirection.Ascending);
            txaEntidad.LoadControl(Presenter.ContainerService, Delfin.Controls.TiposEntidad.TIPE_Cliente);
            cmbTIPO_CodMND.LoadControl(Presenter.ContainerService, "Moneda", "MND", "< Sel. Tipo Moneda >", ListSortDirection.Ascending, Presenter.TiposMND);
            cmbTIPO_CodFPG.LoadControl(Presenter.ContainerService, "Forma de Pago", "FPG", "< Sel. Forma Pago >", ListSortDirection.Ascending);
            cmbTIPO_CodTDO.LoadControl(Presenter.ContainerService, "Tipo Documento", "TDO", "< Sel. Tipo Documento >", ListSortDirection.Ascending, Presenter.TiposTDO);
            FormatGridServicios();

            BSItems = new BindingSource();
            BSItems.DataSource = null;
            navItems.BindingSource = BSItems;
            grdItemsServicio.DataSource = BSItems;
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error en el LoadView.", ex); }
      }

      #endregion

      #region [ Metodos ]

      private void Guardar()
      {
         try
         {
            String x_msg = "";
            if (Presenter.GuardarFL())
            {
               Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeSatisfactorio(Presenter.Title, "Se ha guardado satisfactoriamente");
               this.Close();
            }
            else { }
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al guardar el formulario.", ex); }
      }

      public void ClearItem()
      {
         try
         {


         }
         catch (Exception)
         { }
      }
      public void GetItem()
      {
         try
         {
            if (Presenter != null && Presenter.ItemDocsVtaFL != null)
            {
               Presenter.ItemDocsVtaFL.TIPO_CodTDO = null; Presenter.ItemDocsVtaFL.TIPO_TabTDO = null;
               if (cmbTIPO_CodTDO.TiposSelectedItem != null)
               {
                  Presenter.ItemDocsVtaFL.TIPO_TabTDO = cmbTIPO_CodTDO.TiposSelectedItem.TIPO_CodTabla;
                  Presenter.ItemDocsVtaFL.TIPO_CodTDO = cmbTIPO_CodTDO.TiposSelectedItem.TIPO_CodTipo;
               }
               Presenter.ItemDocsVtaFL.DOCV_Serie = null;
               if (!String.IsNullOrEmpty(((Entities.Series)cmbDOCV_Serie.SelectedItem).SERI_Serie) && !((Entities.Series)cmbDOCV_Serie.SelectedItem).TIPO_CodTDO.Equals("000"))
               { Presenter.ItemDocsVtaFL.DOCV_Serie = ((Entities.Series)cmbDOCV_Serie.SelectedItem).SERI_Serie; }
               Presenter.ItemDocsVtaFL.DOCV_Numero = null; if (!String.IsNullOrEmpty(txtDOCV_Numero.Text)) { Presenter.ItemDocsVtaFL.DOCV_Numero = txtDOCV_Numero.Text; }
               Presenter.ItemDocsVtaFL.DOCV_FechaEmision = null; if (dtpDOCV_FechaEmision.NSFecha.HasValue) { Presenter.ItemDocsVtaFL.DOCV_FechaEmision = dtpDOCV_FechaEmision.NSFecha; }
               Presenter.ItemDocsVtaFL.DOCV_FechaVcmto = null; if (dtpDOCV_FechaVcmto.NSFecha.HasValue) { Presenter.ItemDocsVtaFL.DOCV_FechaVcmto = dtpDOCV_FechaVcmto.NSFecha; }
               Presenter.ItemDocsVtaFL.DOCV_Estado = null; if (cmbDOCV_Estado.ConstantesSelectedItem != null) { Presenter.ItemDocsVtaFL.DOCV_Estado = cmbDOCV_Estado.ConstantesSelectedItem.CONS_CodTipo; }
               Presenter.ItemDocsVtaFL.TIPE_Codigo = 0; if (cmbTIPE_Codigo.TipoEntidadSelectedItem != null) { Presenter.ItemDocsVtaFL.TIPE_Codigo = cmbTIPE_Codigo.TipoEntidadSelectedItem.TIPE_Codigo; }
               Presenter.ItemDocsVtaFL.ENTC_Codigo = null; if (txaEntidad.SelectedItem != null) { Presenter.ItemDocsVtaFL.ENTC_Codigo = txaEntidad.SelectedItem.ENTC_Codigo; }
               Presenter.ItemDocsVtaFL.TIPO_CodMND = null; Presenter.ItemDocsVtaFL.TIPO_TabMND = null;
               if (cmbTIPO_CodMND.TiposSelectedItem != null)
               {
                  Presenter.ItemDocsVtaFL.TIPO_TabMND = cmbTIPO_CodMND.TiposSelectedItem.TIPO_CodTabla;
                  Presenter.ItemDocsVtaFL.TIPO_CodMND = cmbTIPO_CodMND.TiposSelectedItem.TIPO_CodTipo;
               }
               Presenter.ItemDocsVtaFL.TIPO_TabFPG = null; Presenter.ItemDocsVtaFL.TIPO_CodFPG = null;
               if (cmbTIPO_CodFPG.TiposSelectedItem != null)
               {
                  Presenter.ItemDocsVtaFL.TIPO_CodFPG = cmbTIPO_CodFPG.TiposSelectedItem.TIPO_CodTipo;
                  Presenter.ItemDocsVtaFL.TIPO_TabFPG = cmbTIPO_CodFPG.TiposSelectedItem.TIPO_CodTabla;
               }
               Presenter.ItemDocsVtaFL.DOCV_TipoCambio = 0; if (txnDOCV_TipoCambio.Value != 0) { Presenter.ItemDocsVtaFL.DOCV_TipoCambio = txnDOCV_TipoCambio.Value; }
               Presenter.ItemDocsVtaFL.DOCV_PrecVtaTotal = 0; if (txnDOCV_PrecVtaTotal.Value != 0) { Presenter.ItemDocsVtaFL.DOCV_PrecVtaTotal = txnDOCV_PrecVtaTotal.Value; }
               Presenter.ItemDocsVtaFL.DOCV_Impuesto1 = 0; if (txnDOCV_Impuesto1.Value != 0) { Presenter.ItemDocsVtaFL.DOCV_Impuesto1 = txnDOCV_Impuesto1.Value; }
               Presenter.ItemDocsVtaFL.DOCV_ValorTotal = 0; if (txnDOCV_ValorVtaTotal.Value != 0) { Presenter.ItemDocsVtaFL.DOCV_ValorTotal = txnDOCV_ValorVtaTotal.Value; }
            }
         }
         catch (Exception)
         { throw; }
      }
      public void SetItem()
      {
         try
         {
            if (Presenter != null && Presenter.ItemDocsVtaFL != null)
            {
               if (!String.IsNullOrEmpty(Presenter.ItemDocsVtaFL.DOCV_Serie)) { cmbDOCV_Serie.SelectedValue = Presenter.ItemDocsVtaFL.DOCV_Serie; }
               if (!String.IsNullOrEmpty(Presenter.ItemDocsVtaFL.DOCV_Numero)) { txtDOCV_Numero.Text = Presenter.ItemDocsVtaFL.DOCV_Numero; }
               if (Presenter.ItemDocsVtaFL.DOCV_FechaEmision.HasValue) { dtpDOCV_FechaEmision.NSFecha = Presenter.ItemDocsVtaFL.DOCV_FechaEmision; }
               if (Presenter.ItemDocsVtaFL.DOCV_FechaVcmto.HasValue) { dtpDOCV_FechaVcmto.NSFecha = Presenter.ItemDocsVtaFL.DOCV_FechaVcmto; }
               if (!String.IsNullOrEmpty(Presenter.ItemDocsVtaFL.DOCV_Estado)) { cmbDOCV_Estado.SelectedValue = Presenter.ItemDocsVtaFL.DOCV_Estado; }
               if (Presenter.ItemDocsVtaFL.TIPE_Codigo != 0) { cmbTIPE_Codigo.SelectedValue = Presenter.ItemDocsVtaFL.TIPE_Codigo; }
               if (Presenter.ItemDocsVtaFL.ENTC_Codigo.HasValue)
               {
                  txaEntidad.SelectedItemChanged -= txaEntidad_SelectedItemChanged;
                  txaEntidad.SetEntidad(Presenter.ItemDocsVtaFL.ENTC_Codigo);
                  txaEntidad.SelectedItemChanged += txaEntidad_SelectedItemChanged;
               }
               if (!String.IsNullOrEmpty(Presenter.ItemDocsVtaFL.TIPO_CodMND)) { cmbTIPO_CodMND.SelectedValue = Presenter.ItemDocsVtaFL.TIPO_CodMND; }
               if (!String.IsNullOrEmpty(Presenter.ItemDocsVtaFL.TIPO_CodFPG)) { cmbTIPO_CodFPG.TiposSelectedValue = Presenter.ItemDocsVtaFL.TIPO_CodFPG; }
               if (Presenter.ItemDocsVtaFL.DOCV_TipoCambio != 0) { txnDOCV_TipoCambio.Value = Presenter.ItemDocsVtaFL.DOCV_TipoCambio; }

               if (!String.IsNullOrEmpty(Presenter.ItemDocsVtaFL.TIPO_CodTDO))
               {
                  cmbTIPO_CodTDO.TiposSelectedValue = Presenter.ItemDocsVtaFL.TIPO_CodTDO;
                  if (Presenter.ItemDocsVtaFL.TIPO_CodTDO.Equals(Infrastructure.Aspect.Constants.Util.getMoneda(Infrastructure.Aspect.Constants.TMoneda.Soles)))
                  {
                     if (Presenter.ItemDocsVtaFL.DOCV_PrecVtaTotal != 0) { txnDOCV_PrecVtaTotal.Value = Presenter.ItemDocsVtaFL.DOCV_PrecVtaTotal; }
                     if (Presenter.ItemDocsVtaFL.DOCV_Impuesto1 != 0) { txnDOCV_Impuesto1.Value = Presenter.ItemDocsVtaFL.DOCV_Impuesto1; }
                     if (Presenter.ItemDocsVtaFL.DOCV_ValorVtaTotal != 0) { txnDOCV_ValorVtaTotal.Value = Presenter.ItemDocsVtaFL.DOCV_ValorVtaTotal; }
                  }
                  else if (Presenter.ItemDocsVtaFL.TIPO_CodTDO.Equals(Infrastructure.Aspect.Constants.Util.getMoneda(Infrastructure.Aspect.Constants.TMoneda.Dolares)))
                  {
                     if (Presenter.ItemDocsVtaFL.DOCV_PrecVtaTotalD != 0) { txnDOCV_PrecVtaTotal.Value = Presenter.ItemDocsVtaFL.DOCV_PrecVtaTotalD; }
                     if (Presenter.ItemDocsVtaFL.DOCV_Impuesto1D != 0) { txnDOCV_Impuesto1.Value = Presenter.ItemDocsVtaFL.DOCV_Impuesto1D; }
                     if (Presenter.ItemDocsVtaFL.DOCV_ValorVtaTotalD != 0) { txnDOCV_ValorVtaTotal.Value = Presenter.ItemDocsVtaFL.DOCV_ValorVtaTotalD; }
                  }
               }
            }
         }
         catch (Exception)
         { throw; }
      }

      public void ShowValidation(String x_msg)
      {
         try
         {
            Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Presenter.Title, "Se han encontrado los siguientes errores revisar los detalles.", Presenter.ItemDocsVtaFL.MensajeError + Environment.NewLine + x_msg);
            Infrastructure.Client.FormClose.FormShowErrorProvider<Entities.DocsVta>.Validate(Presenter.ItemDocsVtaFL, this, errorProviderFacturacion);
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error en ShowValidation.", ex); }
      }

      public void Nuevo()
      {
         try
         {
            BSItems.DataSource = Presenter.ItemDocsVtaFL.ItemsDetDocsVta;
            BSItems.ResetBindings(true);
         }
         catch (Exception)
         { throw; }
      }

      private void NuevoServicio()
      {
         try
         {
            Entities.DetDocsVta _servicio = new Entities.DetDocsVta();
            Int32 _DDOV_Item = 0;
            if (BSItems.DataSource != null && ((ObservableCollection<Entities.DetDocsVta>)BSItems.DataSource).Count > 0)
            {
               _DDOV_Item = ((ObservableCollection<Entities.DetDocsVta>)BSItems.DataSource).Max(ddov => ddov.DDOV_Item);
            }
            _servicio.DDOV_Item = Convert.ToInt16(_DDOV_Item + 1);

            _servicio.AUDI_UsrCrea = Presenter.Session.UserName;
            _servicio.AUDI_FecCrea = Presenter.Session.Fecha;
            _servicio.Instance = Infrastructure.Aspect.BusinessEntity.InstanceEntity.Added;
            BSItems.Add(_servicio);
            BSItems.ResetBindings(true);
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error en el LoadView.", ex); }
      }

      private void FormatGridServicios()
      {
         try
         {

            Telerik.WinControls.UI.Localization.RadGridLocalizationProvider.CurrentProvider = new Infrastructure.WinForms.Controls.MySpanishRadGridLocalizationProvider();
            this.grdItemsServicio.Columns.Clear();
            this.grdItemsServicio.AllowAddNewRow = false;

            //Descripción del servicio
            Telerik.WinControls.UI.GridViewComboBoxColumn _servicio = new Telerik.WinControls.UI.GridViewComboBoxColumn();
            _servicio.Name = "SERV_Codigo";
            _servicio.HeaderText = "Servicio";
            _servicio.FieldName = "SERV_CodigoStr";
            _servicio.ValueMember = "SERV_CodigoStr";
            _servicio.DisplayMember = "SERV_Nombre_SPA";
            _servicio.DataSource = Presenter.ListServicio;
            _servicio.DataType = typeof(System.String);
            //_servicio.FilteringMode = Telerik.WinControls.UI.GridViewFilteringMode.DisplayMember;
            //_servicio.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            //_servicio.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDown;
            this.grdItemsServicio.Columns.Add(_servicio);


            //Cantidad
            Telerik.WinControls.UI.GridViewDecimalColumn _cantidad = new Telerik.WinControls.UI.GridViewDecimalColumn();
            _cantidad.Name = "DDOV_Cantidad";
            _cantidad.HeaderText = "Cantidad";
            _cantidad.FieldName = "DDOV_Cantidad";
            _cantidad.DecimalPlaces = 2;
            _cantidad.Minimum = (Decimal)0.00;
            this.grdItemsServicio.Columns.Add(_cantidad);
            //Precio Unitario
            Telerik.WinControls.UI.GridViewDecimalColumn _precio = new Telerik.WinControls.UI.GridViewDecimalColumn();
            _precio.Name = "DDOV_PrecioUnitario";
            _precio.HeaderText = "Precio Unitario";
            _precio.FieldName = "DDOV_PrecioUnitario";
            _precio.DecimalPlaces = 2;
            _precio.Minimum = (Decimal)0.00;
            this.grdItemsServicio.Columns.Add(_precio);
            //Afecto a IGV (no editable)
            Telerik.WinControls.UI.GridViewCheckBoxColumn _afectoIGV = new Telerik.WinControls.UI.GridViewCheckBoxColumn();
            _afectoIGV.Name = "SERV_AfeIgv";
            _afectoIGV.HeaderText = "Afecto IGV";
            _afectoIGV.FieldName = "SERV_AfeIgv";
            this.grdItemsServicio.Columns.Add(_afectoIGV);
            //Impuesto
            Telerik.WinControls.UI.GridViewDecimalColumn _impuesto = new Telerik.WinControls.UI.GridViewDecimalColumn();
            _impuesto.Name = "DDOV_Impuesto1";
            _impuesto.HeaderText = "IGV";
            _impuesto.FieldName = "DDOV_Impuesto1";
            _impuesto.DecimalPlaces = 2;
            _impuesto.Minimum = (Decimal)0.00;
            this.grdItemsServicio.Columns.Add(_impuesto);
            //Importe de Venta
            Telerik.WinControls.UI.GridViewDecimalColumn _importeingreso = new Telerik.WinControls.UI.GridViewDecimalColumn();
            _importeingreso.Name = "DDOV_ValorVenta";
            _importeingreso.HeaderText = "Importe";
            _importeingreso.FieldName = "DDOV_ValorVenta";
            _importeingreso.DecimalPlaces = 2;
            _importeingreso.Minimum = (Decimal)0.00;
            this.grdItemsServicio.Columns.Add(_importeingreso);

            grdItemsServicio.BestFitColumns();
            Infrastructure.WinForms.Controls.GridAutoFit.Fit(grdItemsServicio);

            this.grdItemsServicio.SelectionMode = Telerik.WinControls.UI.GridViewSelectionMode.CellSelect;
            this.grdItemsServicio.MultiSelect = false;

            this.grdItemsServicio.ShowFilteringRow = false;
            this.grdItemsServicio.EnableFiltering = false;
            this.grdItemsServicio.MasterTemplate.EnableFiltering = false;
            this.grdItemsServicio.EnableGrouping = false;
            this.grdItemsServicio.MasterTemplate.EnableGrouping = false;
            this.grdItemsServicio.EnableSorting = false;
            this.grdItemsServicio.MasterTemplate.EnableCustomSorting = false;

            this.grdItemsServicio.ReadOnly = false;
            this.grdItemsServicio.AllowEditRow = true;

            this.grdItemsServicio.Columns["SERV_Codigo"].ReadOnly = false;
            this.grdItemsServicio.Columns["DDOV_Cantidad"].ReadOnly = false;
            this.grdItemsServicio.Columns["DDOV_PrecioUnitario"].ReadOnly = false;
            this.grdItemsServicio.Columns["DDOV_ValorVenta"].ReadOnly = true;
            this.grdItemsServicio.Columns["SERV_AfeIgv"].ReadOnly = true;

         }
         catch (Exception ex)
         {
            Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, Infrastructure.Aspect.Constants.Mensajes.FormatDataGridView + " (Grid Servicios)", ex);
         }
      }

      private void Calcular()
      {
         try
         {
            if (Presenter.ItemDocsVtaFL != null && Presenter.ItemDocsVtaFL.ItemsDetDocsVta != null && Presenter.ItemDocsVtaFL.ItemsDetDocsVta.Count > 0)
            {
               Decimal _SubTotal = 0, _TotalIGV = 0;
               foreach (Entities.DetDocsVta iDetDoc in Presenter.ItemDocsVtaFL.ItemsDetDocsVta)
               {
                  _SubTotal += Math.Round(iDetDoc.DDOV_PrecioUnitario * iDetDoc.DDOV_Cantidad, 2, MidpointRounding.AwayFromZero);
                  iDetDoc.DDOV_ValorTotal = Math.Round(iDetDoc.DDOV_PrecioUnitario * iDetDoc.DDOV_Cantidad, 2, MidpointRounding.AwayFromZero);
                  iDetDoc.DDOV_ValorVenta = Math.Round(iDetDoc.DDOV_PrecioUnitario * iDetDoc.DDOV_Cantidad, 2, MidpointRounding.AwayFromZero);
                  iDetDoc.DDOV_Impuesto1 = 0;
                  iDetDoc.DDOV_Impuesto2 = 0;
                  iDetDoc.DDOV_Impuesto3 = 0;
                  iDetDoc.DDOV_Impuesto4 = 0;

                  if (iDetDoc.ItemServicio.SERV_AfeIgv.HasValue && iDetDoc.ItemServicio.SERV_AfeIgv.Value)
                  {
                     _TotalIGV += _SubTotal * (Presenter.IGV / 100 + 1);
                     iDetDoc.DDOV_ValorVenta = Math.Round(iDetDoc.DDOV_PrecioUnitario * iDetDoc.DDOV_Cantidad, 2, MidpointRounding.AwayFromZero) * (Presenter.IGV / 100 + 1);
                     iDetDoc.DDOV_Impuesto1 = iDetDoc.DDOV_ValorVenta - iDetDoc.DDOV_ValorTotal;
                  }
               }
               Decimal _total = 0, _impuesto = 0;
               _total = Math.Round(_TotalIGV, 2, MidpointRounding.AwayFromZero);
               _impuesto = _total - Math.Round(_SubTotal, 2, MidpointRounding.AwayFromZero);
               txnDOCV_PrecVtaTotal.Value = _SubTotal;
               txnDOCV_Impuesto1.Value = _impuesto;
               txnDOCV_ValorVtaTotal.Value = _total;
            }
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido calculando el total.", ex); }
      }

      private void CalcularCantidad(Int32 rowIndex)
      {
         try
         {
            if (grdItemsServicio.Rows[rowIndex].Cells["DDOV_Cantidad"].Value != null && !String.IsNullOrEmpty(grdItemsServicio.Rows[rowIndex].Cells["DDOV_Cantidad"].Value.ToString()))
            {
               Decimal? _DDOV_ValorTotal = 0, _DDOV_Impuesto1 = 0, _DDOV_ValorVenta = 0, _DDOV_Cantidad = 0, _DDOV_PrecioUnitario = 0;


            }
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido calculando el registro actual.", ex); }
      }

      private void SetDatosServicios(Int32 rowIndex)
      {
         try
         {

         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido calculando el registro actual.", ex); }
      }

      #endregion

      #region [ Eventos ]

      private void btnGuardar_Click(object sender, EventArgs e)
      { Guardar(); }

      private void txaEntidad_SelectedItemChanged(object sender, EventArgs e)
      {

      }

      private void cmbTIPE_Codigo_SelectedIndexChanged(object sender, EventArgs e)
      {
         try
         {
            if (cmbTIPE_Codigo.TipoEntidadSelectedItem != null)
            {
               txaEntidad.TiposEntidad = Delfin.Controls.EntidadClear.getTipoEntidadEnum(cmbTIPE_Codigo.TipoEntidadSelectedItem.TIPE_Codigo);
               txaEntidad.Enabled = true;
            }
            else { txaEntidad.Enabled = false; }
         }
         catch (Exception)
         { }
      }

      private void cmbTIPO_CodMND_SelectedIndexChanged(object sender, EventArgs e)
      {
         try
         {
            if (cmbTIPO_CodMND.TiposSelectedItem != null)
            {
               Presenter.LoadServicios(cmbTIPO_CodMND.TiposSelectedItem.TIPO_CodTabla, cmbTIPO_CodMND.TiposSelectedItem.TIPO_CodTipo);
            }
            else { Presenter.LoadServicios(null, null); }
         }
         catch (Exception)
         { }
      }

      private void cmbTIPO_CodTDO_SelectedIndexChanged(object sender, EventArgs e)
      {
         try
         {
            if (cmbTIPO_CodTDO.TiposSelectedItem != null)
            {
               cmbDOCV_Serie.DisplayMember = "SERI_Serie";
               cmbDOCV_Serie.ValueMember = "SERI_Serie";
               ObservableCollection<Entities.Series> x_listSeries = Presenter.ListSeries.Where(Ser => Ser.TIPO_CodTDO == cmbTIPO_CodTDO.TiposSelectedItem.TIPO_CodTipo).ToObservableCollection();
               x_listSeries.Insert(0, new Entities.Series() { SERI_Serie = "< Sel. Nro de Serie >", SERI_Desc = null, TIPO_CodTDO = "000" });
               cmbDOCV_Serie.DataSource = x_listSeries;
               cmbDOCV_Serie.Enabled = true;
            }
            else { cmbDOCV_Serie.SelectedIndex = 0; cmbDOCV_Serie.Enabled = false; }
         }
         catch (Exception)
         { }
      }

      private void btnNuevoServicio_Click(object sender, EventArgs e)
      { NuevoServicio(); }

      private void grdItemsServicio_CellEndEdit(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
      {
         if (e.Column.Name == "SERV_Codigo")
         { SetDatosServicios(e.RowIndex); }
         else if (e.Column.Name == "DDOV_Cantidad")
         { CalcularCantidad(e.RowIndex); }
         else if (e.Column.Name == "DDOV_PrecioUnitario")
         { CalcularCantidad(e.RowIndex); }
      }

      #endregion

      private void grdItemsServicio_Click(object sender, EventArgs e)
      {

      }

      #region [ IFormClose ]

      #endregion



   }
}
