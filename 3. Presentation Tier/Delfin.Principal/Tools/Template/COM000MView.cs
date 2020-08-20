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
   public partial class COM000MView : Form, ICOM000MView
   {
      #region [ Variables ]

      #endregion

      #region [ Formulario ]
      public COM000MView()
      {
         InitializeComponent();
         try
         {
            this.FormClosing += new FormClosingEventHandler(MView_FormClosing);
            this.FormClosed += COM000MView_FormClosed;

            btnGuardar.Click += btnGuardar_Click;
            btnSalir.Click += btnSalir_Click;

            BSItemsFlete = new BindingSource();
            //grdItemsFlete.DataSource = BSItemsFlete;
            //grdItemsFleteEmbarque.DataSource = BSItemsFlete;

            BSItemsServicio = new BindingSource();
            grdItemsServicio.DataSource = BSItemsServicio;

            //ENTC_CodEjecutivo.AyudaValueChanged += ENTC_CodEjecutivo_AyudaValueChanged;
            //ENTC_CodTransportista.AyudaValueChanged += ENTC_CodTransportista_AyudaValueChanged;

            //grdItemsFlete.CellEndEdit += grdItemsFlete_CellEndEdit;
            //grdItemsServicio.CellEndEdit += grdItemsServicio_CellEndEdit;
            //grdItemsServicio.CommandCellClick += grdItemsServicio_CommandCellClick;

            //btnAddFlete.Click += btnAddFlete_Click;
            //btnDelFlete.Click += btnDelFlete_Click;
            //btnAddServicio.Click += btnAddServicio_Click;
            //btnDelServicio.Click += btnDelServicio_Click;

            this.Load += COM000MView_Load;
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error inicializando el formulario MView.", ex); }
      }

      private void COM000MView_FormClosed(object sender, FormClosedEventArgs e)
      { Presenter.IsClosedMView(); }

      private void COM000MView_Load(object sender, EventArgs e)
      {
         tabCab_Cotizacion_OV.TabPages.Clear();

         tabCab_Cotizacion_OV.TabPages.Add(pageGenerales);
         tabCab_Cotizacion_OV.TabPages.Add(pageDetalle);
         if (Presenter.CCOT_Tipo == Delfin.Controls.variables.CCOT_TipoOrdenVenta)
         {
            //tabCab_Cotizacion_OV.TabPages.Add(pageNovedades);
            //tabCab_Cotizacion_OV.TabPages.Add(pageArchivos);
            //tabCab_Cotizacion_OV.TabPages.Add(pageEventosTareas);
         }
         tabCab_Cotizacion_OV.SelectedTab = pageGenerales;
      }
      #endregion

      #region [ Propiedades ]
      public COM000Presenter Presenter { get; set; }
      private bool Closing = false;
      private System.Collections.Hashtable HashFormulario { get; set; }

      public BindingSource BSItemsFlete { get; set; }
      public BindingSource BSItemsServicio { get; set; }

      public BindingSource BSItemsNovedades { get; set; }
      public BindingSource BSItemsArchivos { get; set; }
      #endregion

      #region [ ICOM000MView ]
      public void LoadView(Int16 CCOT_Tipo)
      {
         try
         {
            //ENTC_CodAgente.ContainerService = Presenter.ContainerService;
            //ENTC_CodBroker.ContainerService = Presenter.ContainerService;
            //ENTC_CodCliente.ContainerService = Presenter.ContainerService;

            FormatGridServicios();

         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error en el LoadView.", ex); }
      }

      public void ClearItem()
      {
         try
         {
            errorProviderCab_Cotizacion_OV.Clear();

            #region [ Datos Generales ]
            //CCOT_NumDocCOT.Text = String.Empty;
            //CCOT_Version.Text = String.Empty;
            ////CONS_TabEST

            #endregion

            #region [ Servicios y Tarifa ]
            //CONT_Numero.Text = string.Empty;
            //CONT_Descrip.Text = string.Empty;
            BSItemsServicio.DataSource = null;
            BSItemsServicio.ResetBindings(true);
            #endregion

         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error en ClearItem.", ex); }
      }
      public void GetItem()
      {
         try
         {
            errorProviderCab_Cotizacion_OV.Clear();

            #region [ Datos Generales ]

            //Presenter.Item.CCOT_NumDoc = CCOT_NumDocCOT.Text;

            #endregion

         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error en GetItem.", ex); }
      }
      public void SetItem()
      {
         try
         {

            //CCOT_NumDocCOT.Text = Presenter.Item.CCOT_NumDoc;
            //CCOT_Version.Text = Presenter.Item.CCOT_Version.ToString();
            //CONS_CodESTCOT.ConstantesSelectedValue = Presenter.Item.CONS_CodEST;

            EnabledItem();
            tabCab_Cotizacion_OV.SelectedTab = pageGenerales;
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

      public void ShowValidation()
      {
         try
         {
            Infrastructure.Client.FormClose.FormShowErrorProvider<Entities.Cab_Cotizacion_OV>.Validate(Presenter.Item, this, errorProviderCab_Cotizacion_OV);

            Infrastructure.Client.FormClose.FormShowErrorProvider<Entities.Cab_Cotizacion_OV>.SetTabError(tabCab_Cotizacion_OV, errorProviderCab_Cotizacion_OV);
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error en ShowValidation.", ex); }
      }
      #endregion

      #region [ Metodos ]

      private void FormatGridServicios()
      {
         try
         {

            Telerik.WinControls.UI.Localization.RadGridLocalizationProvider.CurrentProvider = new Infrastructure.WinForms.Controls.MySpanishRadGridLocalizationProvider();
            this.grdItemsServicio.Columns.Clear();
            this.grdItemsServicio.AllowAddNewRow = false;

            //Descripción del servicio
            Telerik.WinControls.UI.GridViewCheckBoxColumn _exonerado = new Telerik.WinControls.UI.GridViewCheckBoxColumn();
            _exonerado.Name = "SCOT_Exonerado";
            _exonerado.HeaderText = "Exonerado";
            _exonerado.FieldName = "SCOT_Exonerado";
            _exonerado.ReadOnly = true;
            this.grdItemsServicio.Columns.Add(_exonerado);

            //Descripción del servicio
            //Telerik.WinControls.UI.GridViewComboBoxColumn _ingresoegreso = new Telerik.WinControls.UI.GridViewComboBoxColumn();
            //_ingresoegreso.Name = "CCOT_IngresoGasto";
            //_ingresoegreso.HeaderText = "Ingreso/Egreso";
            //_ingresoegreso.FieldName = "CCOT_IngresoGasto";
            //_ingresoegreso.ValueMember = "StrCodigo";
            //_ingresoegreso.DisplayMember = "StrDesc";
            //_ingresoegreso.DataSource = Presenter.ListIngresoEgreso;
            //_ingresoegreso.FilteringMode = Telerik.WinControls.UI.GridViewFilteringMode.DisplayMember;
            //this.grdItemsServicio.Columns.Add(_ingresoegreso);
            //Descripción del servicio
            //Telerik.WinControls.UI.GridViewComboBoxColumn _servicio = new Telerik.WinControls.UI.GridViewComboBoxColumn();
            //_servicio.Name = "SERV_Codigo";
            //_servicio.HeaderText = "Servicio";
            //_servicio.FieldName = "SERV_CodigoStr";
            //_servicio.ValueMember = "SERV_CodigoStr";
            //_servicio.DisplayMember = "SERV_Nombre_SPA";
            //_servicio.DataSource = Presenter.ListServicio;
            //_servicio.DataType = typeof(System.String);
            //_servicio.FilteringMode = Telerik.WinControls.UI.GridViewFilteringMode.DisplayMember;
            //_servicio.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            //_servicio.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDown;
            //this.grdItemsServicio.Columns.Add(_servicio);
            //Proveedor del servicio
            Telerik.WinControls.UI.GridViewCommandColumn _proveedor = new Telerik.WinControls.UI.GridViewCommandColumn();
            _proveedor.Name = "Seleccionar";
            _proveedor.HeaderText = "Proveedor";
            _proveedor.DefaultText = "Seleccionar";
            _proveedor.UseDefaultText = true;
            this.grdItemsServicio.Columns.Add(_proveedor);
            this.grdItemsServicio.Columns.Add("TIPE_Codigo", "Tipo Entidad", "TIPE_Codigo");
            this.grdItemsServicio.Columns.Add("ENTC_Codigo", "Código Proveedor", "ENTC_Codigo");
            this.grdItemsServicio.Columns.Add("ENTC_NomCom", "Proveedor", "ENTC_NomCom");
            //Base (Valor, Contenedor, Peso/Volumen)
            //Telerik.WinControls.UI.GridViewComboBoxColumn _base = new Telerik.WinControls.UI.GridViewComboBoxColumn();
            //_base.Name = "CONS_CodBas";
            //_base.HeaderText = "Base";
            //_base.FieldName = "CONS_CodBas";
            //_base.ValueMember = "CONS_CodTipo";
            //_base.DisplayMember = "CONS_Desc_SPA";
            //_base.DataSource = Presenter.ListConstantesBAS;
            //_base.FilteringMode = Telerik.WinControls.UI.GridViewFilteringMode.DisplayMember;
            //this.grdItemsServicio.Columns.Add(_base);
            //Cantidad
            Telerik.WinControls.UI.GridViewDecimalColumn _cantidad = new Telerik.WinControls.UI.GridViewDecimalColumn();
            _cantidad.Name = "SCOT_Cantidad";
            _cantidad.HeaderText = "Cantidad";
            _cantidad.FieldName = "SCOT_Cantidad";
            _cantidad.DecimalPlaces = 2;
            this.grdItemsServicio.Columns.Add(_cantidad);
            //Origen del servicio (0 = Local, 1 = Destino)
            //Telerik.WinControls.UI.GridViewComboBoxColumn _origen = new Telerik.WinControls.UI.GridViewComboBoxColumn();
            //_origen.Name = "SCOT_Origen";
            //_origen.HeaderText = "Origen";
            //_origen.FieldName = "SCOT_Origen";
            //_origen.ValueMember = "StrCodigo";
            //_origen.DisplayMember = "StrDesc";
            //_origen.DataSource = Presenter.ListOrigen;
            ////_origen.FilteringMode = Telerik.WinControls.UI.GridViewFilteringMode.DisplayMember;
            //this.grdItemsServicio.Columns.Add(_origen);
            //Moneda
            //Telerik.WinControls.UI.GridViewComboBoxColumn _moneda = new Telerik.WinControls.UI.GridViewComboBoxColumn();
            //_moneda.Name = "TIPO_CodMnd";
            //_moneda.HeaderText = "Moneda";
            //_moneda.FieldName = "TIPO_CodMnd";
            //_moneda.ValueMember = "TIPO_CodTipo";
            //_moneda.DisplayMember = "TIPO_Desc1";
            //_moneda.DataSource = Presenter.ListTiposMND;
            ////_moneda.FilteringMode = Telerik.WinControls.UI.GridViewFilteringMode.DisplayMember;
            //this.grdItemsServicio.Columns.Add(_moneda);
            //Precio Unitario
            Telerik.WinControls.UI.GridViewDecimalColumn _precio = new Telerik.WinControls.UI.GridViewDecimalColumn();
            _precio.Name = "SCOT_PrecioUni";
            _precio.HeaderText = "Precio Unitario";
            _precio.FieldName = "SCOT_PrecioUni";
            _precio.DecimalPlaces = 2;
            this.grdItemsServicio.Columns.Add(_precio);
            //Importe de Venta
            Telerik.WinControls.UI.GridViewDecimalColumn _importeingreso = new Telerik.WinControls.UI.GridViewDecimalColumn();
            _importeingreso.Name = "SCOT_Importe_Ingreso";
            _importeingreso.HeaderText = "Importe Ingreso";
            _importeingreso.FieldName = "SCOT_Importe_Ingreso";
            _importeingreso.DecimalPlaces = 2;
            this.grdItemsServicio.Columns.Add(_importeingreso);
            //Importe de Venta
            Telerik.WinControls.UI.GridViewDecimalColumn _importeegreso = new Telerik.WinControls.UI.GridViewDecimalColumn();
            _importeegreso.Name = "SCOT_Importe_Egreso";
            _importeegreso.HeaderText = "Importe Egreso";
            _importeegreso.FieldName = "SCOT_Importe_Egreso";
            _importeegreso.DecimalPlaces = 2;
            this.grdItemsServicio.Columns.Add(_importeegreso);
            //Afecto a IGV (no editable)
            Telerik.WinControls.UI.GridViewCheckBoxColumn _afectoIGV = new Telerik.WinControls.UI.GridViewCheckBoxColumn();
            _afectoIGV.Name = "SERV_AfeIgv";
            _afectoIGV.HeaderText = "Afecto IGV";
            _afectoIGV.FieldName = "SERV_AfeIgv";
            this.grdItemsServicio.Columns.Add(_afectoIGV);
            //Afecto a Detracción (no editable)
            Telerik.WinControls.UI.GridViewCheckBoxColumn _afectoDetraccion = new Telerik.WinControls.UI.GridViewCheckBoxColumn();
            _afectoDetraccion.Name = "SERV_AfeDet";
            _afectoDetraccion.HeaderText = "Afecto Detracción";
            _afectoDetraccion.FieldName = "SERV_AfeDet";
            this.grdItemsServicio.Columns.Add(_afectoDetraccion);
            //Importe de Venta
            Telerik.WinControls.UI.GridViewDecimalColumn _preciosugerido = new Telerik.WinControls.UI.GridViewDecimalColumn();
            _preciosugerido.Name = "SCOT_PreSugerido";
            _preciosugerido.HeaderText = "Precio Sugerido";
            _preciosugerido.FieldName = "SCOT_PreSugerido";
            _preciosugerido.DecimalPlaces = 2;
            this.grdItemsServicio.Columns.Add(_preciosugerido);

            grdItemsServicio.BestFitColumns();
            Infrastructure.WinForms.Controls.GridAutoFit.Fit(grdItemsServicio);
            grdItemsServicio.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;

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

            this.grdItemsServicio.Columns["SCOT_PreSugerido"].IsVisible = false;
            this.grdItemsServicio.Columns["TIPE_Codigo"].IsVisible = false;
            this.grdItemsServicio.Columns["ENTC_Codigo"].IsVisible = false;

            this.grdItemsServicio.Columns["SCOT_Exonerado"].ReadOnly = true;
            this.grdItemsServicio.Columns["CCOT_IngresoGasto"].ReadOnly = false;
            this.grdItemsServicio.Columns["SERV_Codigo"].ReadOnly = false;
            this.grdItemsServicio.Columns["ENTC_NomCom"].ReadOnly = true;
            this.grdItemsServicio.Columns["CONS_CodBas"].ReadOnly = false;
            this.grdItemsServicio.Columns["SCOT_Cantidad"].ReadOnly = false;
            this.grdItemsServicio.Columns["SCOT_Origen"].ReadOnly = false;
            this.grdItemsServicio.Columns["TIPO_CodMnd"].ReadOnly = false;
            this.grdItemsServicio.Columns["SCOT_PrecioUni"].ReadOnly = false;
            this.grdItemsServicio.Columns["SCOT_Importe_Ingreso"].ReadOnly = true;
            this.grdItemsServicio.Columns["SCOT_Importe_Egreso"].ReadOnly = true;
            this.grdItemsServicio.Columns["SERV_AfeIgv"].ReadOnly = true;
            this.grdItemsServicio.Columns["SERV_AfeDet"].ReadOnly = true;

            this.grdItemsServicio.Columns["SCOT_Exonerado"].Width = 60;
            this.grdItemsServicio.Columns["CCOT_IngresoGasto"].Width = 80;
            this.grdItemsServicio.Columns["SERV_Codigo"].Width = 200;
            this.grdItemsServicio.Columns["ENTC_NomCom"].Width = 150;
            this.grdItemsServicio.Columns["CONS_CodBas"].Width = 80;
            this.grdItemsServicio.Columns["SCOT_Cantidad"].Width = 80;
            this.grdItemsServicio.Columns["SCOT_Origen"].Width = 80;
            this.grdItemsServicio.Columns["TIPO_CodMnd"].Width = 80;
            this.grdItemsServicio.Columns["SCOT_PrecioUni"].Width = 100;
            this.grdItemsServicio.Columns["SCOT_Importe_Ingreso"].Width = 100;
            this.grdItemsServicio.Columns["SCOT_Importe_Egreso"].Width = 100;
            this.grdItemsServicio.Columns["SERV_AfeIgv"].Width = 80;
            this.grdItemsServicio.Columns["SERV_AfeDet"].Width = 80;

            //this.grdItemsServicio.Columns["SERV_Codigo"].TextAlignment = ContentAlignment.MiddleLeft;
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, Infrastructure.Aspect.Constants.Mensajes.FormatDataGridView + " (Grid Servicios)", ex); }
      }
      private void AddFlete()
      {
         try
         {
            Entities.Det_Cotizacion_OV_Flete _flete = new Entities.Det_Cotizacion_OV_Flete();
            Int32 _DCOT_Item = 0;
            if (((ObservableCollection<Entities.Det_Cotizacion_OV_Flete>)BSItemsFlete.DataSource).Count > 0)
            { _DCOT_Item = ((ObservableCollection<Entities.Det_Cotizacion_OV_Flete>)BSItemsFlete.DataSource).Max(dcot => dcot.DCOT_Item); }
            _flete.DCOT_Item = _DCOT_Item + 1;
            _flete.AUDI_UsrCrea = Presenter.Session.UserName;
            _flete.AUDI_FecCrea = Presenter.Session.Fecha;
            _flete.Instance = Infrastructure.Aspect.BusinessEntity.InstanceEntity.Added;
            BSItemsFlete.Add(_flete);
            BSItemsFlete.ResetBindings(true);
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al agregar un flete", ex); }
      }

      #endregion

      #region [ Metodos Documentos ]
     
      #endregion

      #region [ Eventos ]
      private void btnGuardar_Click(object sender, EventArgs e)
      {
         try
         {
            Boolean EsProspecto = false; // = (ENTC_CodCliente.Value != null && ENTC_CodCliente.Value.ENTC_Prospecto.HasValue) ? ENTC_CodCliente.Value.ENTC_Prospecto.Value : false;
            if (Presenter.Guardar(EsProspecto, true))
            {
               //this.FormClosing -= MView_FormClosing;
               //errorProviderCab_Cotizacion_OV.Dispose();
               //Presenter.Actualizar();
               //this.Close();
            }
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al guardar el formulario.", ex); }
      }
      private void btnSalir_Click(object sender, EventArgs e)
      {
         try
         {
            Boolean EsProspecto = false; // = (ENTC_CodCliente.Value != null && ENTC_CodCliente.Value.ENTC_Prospecto.HasValue) ? ENTC_CodCliente.Value.ENTC_Prospecto.Value : false;

            this.FormClosing -= MView_FormClosing;
            errorProviderCab_Cotizacion_OV.Dispose();
            if (Infrastructure.Client.FormClose.FormValidateChanges.verificarCambioFormulario(this, HashFormulario))
            {
               if (Presenter.GuardarCambios(EsProspecto) != System.Windows.Forms.DialogResult.Cancel)
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
            Boolean EsProspecto = false; // (ENTC_CodCliente.Value != null && ENTC_CodCliente.Value.ENTC_Prospecto.HasValue) ? ENTC_CodCliente.Value.ENTC_Prospecto.Value : false;

            if (Closing != true)
            {
               this.FormClosing -= MView_FormClosing;
               if (Infrastructure.Client.FormClose.FormValidateChanges.verificarCambioFormulario(this, HashFormulario))
               {
                  if (Presenter.GuardarCambios(EsProspecto) == System.Windows.Forms.DialogResult.Cancel)
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
      #endregion
   }
}