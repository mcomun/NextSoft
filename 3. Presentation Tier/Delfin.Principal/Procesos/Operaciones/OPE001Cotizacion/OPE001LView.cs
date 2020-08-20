using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections.ObjectModel;
using Delfin.Principal.Properties;
using Infrastructure.Aspect.Collections;
using Infrastructure.WinForms.Controls;
using Telerik.WinControls;
using Telerik.WinControls.UI;

namespace Delfin.Principal
{
   public partial class OPE001LView : UserControl, IOPE001LView
   {
      #region [ Variables ]

      #endregion

      #region [ Formulario ]
      public OPE001LView(Telerik.WinControls.UI.RadPageViewPage x_tabPageControl)
      {
         InitializeComponent();
         try
         {
            TabPageControl = x_tabPageControl;

            btnNuevo.Click += new EventHandler(btnNuevo_Click);
            btnBuscar.Click += new EventHandler(btnBuscar_Click);
            btnExportar.Click += new EventHandler(btnExportar_Click);
            btnDeshacer.Click += new EventHandler(btnDeshacer_Click);

            BSItems = new BindingSource();
            BSItems.CurrentItemChanged += new EventHandler(BSItems_CurrentItemChanged);

            grdItems.CommandCellClick += new Telerik.WinControls.UI.CommandCellClickEventHandler(grdItems_CommandCellClick);
            grdItems.CellFormatting += grdItems_CellFormatting;

            TitleView.FormClose += new EventHandler(TitleView_FormClose);
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error inicializando el formulario LView.", ex); }
      }
      #endregion

      #region [ Propiedades ]
      public Telerik.WinControls.UI.RadPageViewPage TabPageControl { get; set; }
      public Image IconView { get { return TitleView.FormIcon; } set { TitleView.FormIcon = value; } }
      public OPE001Presenter Presenter { get; set; }
      public BindingSource BSItems { get; set; }
      #endregion

      #region [ IOPE001LView ]
      /// <summary>
      /// CONTROLES
      /// txaENTC_CodCliente                    => Ayuda del Cliente de la OV
      /// txaENTC_CodShipper                    => Ayuda del Shipper de la OV
      /// txaENTC_CodEjecutivo                  => Ayuda del Ejecutivo de la OV
      /// txaENTC_CodCustomer                   => Ayuda del Customer de la OV
      /// txaENTC_CodAgente                     => Ayuda del Agente de la OV
      /// txaPUER_CodOrigen                     => Puerto Origen de la OV
      /// txaPUER_CodDestino                    => Puerto Destino de la OV
      /// txaNAVE_Codigo                        => Nave de la NaveViaje
      /// txaNVIA_NroViaje                      => Número de Viaje de la NaveViaje
      /// txaENTC_CodTransportista              => Línea o Trabnsportista de la NaveViaje
      /// cmbTIPO_CodTDO                        => Tipo de Doc. Emisión de los servicios de la OV
      /// txtSCOT_SerieTDO                      => Serie del Doc. Emisión de los servicios de la OV
      /// txtSCOT_NumeroTDO                     => Número del Doc. Emisión de los servicios de la OV
      /// cmbCONS_CodRGM                        => Régimen de la OV
      /// cmbCONS_CodVia                        => Vía de la OV
      /// cmbCONS_CodFLE                        => Condición de embarque de la OV
      /// cmbTIPO_CodCDT                        => Conmodity de los conetenedores de la OV
      /// txtDOOV_HBL                           => Número de HBL de la OV
      /// txtDOOV_MBL                           => Número de HBL de la OV
      /// txtCNTR_Numero                        => Número de Contenedor de los contenedores de la OV
      /// txtCCOT_NumDoc                        => Número de la OV
      /// chkDHBL_EsIMO                         => Determina si la carga es peligrosa en los detalles de los contenedores
      /// mdtDDOV_FecEmbarqueDesde              => Fecha de Embarque Desde que se registra en al OV
      /// mdtDDOV_FecEmbarqueHasta              => Fecha de Embarque Desde que se registra en al OV
      /// mdtNVIA_FecETAZarpeDesde              => Para Importación de usara la Fecha ETA y para Exportación se usará la Zarpe de la NaveViaje Desde 
      /// mdtNVIA_FecETAZarpeHasta              => Para Importación de usara la Fecha ETA y para Exportación se usará la Zarpe de la NaveViaje Hasta
      /// mdtCCOT_FecRecepcionDocumentosDesde   => Fecha de cuando se recepcionaron los documentos de la OV Desde
      /// mdtCCOT_FecRecepcionDocumentosHasta   => Fecha de cuando se recepcionaron los documentos de la OV Desde
      /// chkCCOT_Bloqueado                     => Determina si la OV se encuentra bloqueada
      /// chkCCOT_ConExcepcion                  => Determina si la OV se encuentra con excepcion
      /// chkCCOT_EmitirHBL                     => Determina si la OV va a emitir HBL
      /// chkCCOT_ServicioLogistico             => Determina si la OV tiene Servicio Logistico
      /// chkCCOT_VBOperaciones                 => Determina si la OV tiene el Vb de Operaciones
      /// chkCCOT_VBLogistico                   => Determina si la OV tiene el Vb de Logistico
      /// chkCCOT_DiferenciaFlete               => Determina si la OV tiene agregado el servicio de Diferencia de Flete
      /// chkCCOT_DiferenciaFleteRecup          => Determina si la OV tiene agregado el servicio de Diferencia de Flete y este ha sido recuperado
      /// </summary>
      public void LoadView()
      {
         try
         {
            this.Text = "Operaciones - Órdenes de Venta";
            this.TitleView.Caption = "Operaciones - Órdenes de Venta";

            //txaENTC_CodCliente
            txaENTC_CodCliente.ContainerService = Presenter.ContainerService;
            txaENTC_CodCliente.TipoEntidad = Delfin.Controls.TiposEntidad.TIPE_Cliente;
            //txaENTC_CodShipper
            txaENTC_CodShipper.ContainerService = Presenter.ContainerService;
            txaENTC_CodShipper.TipoEntidad = Delfin.Controls.TiposEntidad.TIPE_Shipper;
            //txaENTC_CodEjecutivo
            txaENTC_CodEjecutivo.ContainerService = Presenter.ContainerService;
            txaENTC_CodEjecutivo.TipoEntidad = Delfin.Controls.TiposEntidad.TIPE_Ejecutivo;
            //txaENTC_CodCustomer
            txaENTC_CodCustomer.ContainerService = Presenter.ContainerService;
            txaENTC_CodCustomer.TipoEntidad = Delfin.Controls.TiposEntidad.TIPE_Customer;
            //txaENTC_CodAgente
            txaENTC_CodAgente.ContainerService = Presenter.ContainerService;
            txaENTC_CodAgente.TipoEntidad = Delfin.Controls.TiposEntidad.TIPE_Agente;
            //txaPUER_CodOrigen
            txaPUER_CodOrigen.LoadControl(Presenter.ContainerService, "Ayuda de Puerto Origen");
            //txaPUER_CodDestino
            txaPUER_CodDestino.LoadControl(Presenter.ContainerService, "Ayuda de Puerto Destino");
            //txaNAVE_Codigo
            txaNAVE_Codigo.LoadControl(Presenter.ContainerService);
            //txaNVIA_NroViaje
            txaNVIA_NroViaje.LoadControl(Presenter.ContainerService);
            //txaENTC_CodTransportista
            txaENTC_CodTransportista.ContainerService = Presenter.ContainerService;
            txaENTC_CodTransportista.TipoEntidad = Delfin.Controls.TiposEntidad.TIPE_Transportista;
            //cmbTIPO_CodTDO
            cmbTIPO_CodTDO.LoadControl(Presenter.ContainerService, "Combo Tipos de Documento", "TDO", "< Seleccionar Tipo Documento >", ListSortDirection.Ascending);
            //txtSCOT_SerieTDO
            //txtSCOT_NumeroTDO
            //cmbCONS_CodRGM
            cmbCONS_CodRGM.LoadControl(Presenter.ContainerService, "Combo Constantes de Régimen", "RGM", "< Seleccionar Régimen >", ListSortDirection.Ascending);

            String[] _estados = new String[] { "004", "006", "007", "008" };
            cmbCONS_CodEST.LoadControl(Presenter.ContainerService, "Combo Constantes de Estado de la O.V.", "OVE", "< Seleccionar Estado >", ListSortDirection.Ascending, _estados);
            //cmbCONS_CodVia
            cmbCONS_CodVia.LoadControl(Presenter.ContainerService, "Combo Constantes de Vía", "VIA", "< Seleccionar Vía >", ListSortDirection.Ascending);
            //cmbCONS_CodFLE
            cmbCONS_CodFLE.LoadControl(Presenter.ContainerService, "Combo Constantes de Condición de Embarque", "FLE", "< Seleccionar Condición Embarque >", ListSortDirection.Ascending);
            //cmbTIPO_CodCDT
            cmbTIPO_CodCDT.LoadControl(Presenter.ContainerService, "Combo Tipos de Comodity", "CDT", "< Seleccionar Comodity >", ListSortDirection.Ascending);
            //txtDOOV_HBL
            //txtDOOV_MBL
            //txtCNTR_Numero
            //txtCCOT_NumDoc
            //chkDHBL_EsIMO
            //mdtDDOV_FecEmbarqueDesde
            //mdtDDOV_FecEmbarqueHasta
            //mdtNVIA_FecETAZarpeDesde
            //mdtNVIA_FecETAZarpeHasta
            //mdtCCOT_FecRecDocsDesde
            //mdtCCOT_FecRecDocsHasta

            mdtCCOT_FecEmisionDesde.NSFecha = Presenter.Session.Fecha.AddMonths(-2);
            mdtCCOT_FecEmisionHasta.NSFecha = Presenter.Session.Fecha;

            //chkCCOT_Bloqueado
            //chkCCOT_ConExcepcion
            //chkCCOT_EmitirHBL
            //chkCCOT_ServicioLogistico
            //chkCCOT_VBOperaciones
            //chkCCOT_VBLogistico
            //chkCCOT_DiferenciaFlete
            //chkCCOT_DiferenciaFleteRecup

            FormatDataGrid();

            BSItems.DataSource = null;
            grdItems.DataSource = BSItems;
            navItems.BindingSource = BSItems;
            BSItems.ResetBindings(true);

            grdItems.Enabled = false;
            btnNuevo.Enabled = true;
            btnBuscar.Enabled = true;
            btnExportar.Enabled = false;

            SeleccionarItem();
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error cargando la vista.", ex); }
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
               btnExportar.Enabled = true;
               Infrastructure.WinForms.Controls.GridAutoFit.Fit(this.grdItems);
            }
            else
            {
               grdItems.Enabled = false;
               btnExportar.Enabled = false;
            }

            grdItems.ShowFilteringRow = false;
            grdItems.EnableFiltering = false;
            grdItems.MasterTemplate.EnableFiltering = false;
            grdItems.EnableGrouping = false;
            grdItems.MasterTemplate.EnableGrouping = false;
            grdItems.EnableSorting = false;
            grdItems.MasterTemplate.EnableCustomSorting = false;

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
            Telerik.WinControls.UI.GridViewCommandColumn commandColumn;
            commandColumn = new Telerik.WinControls.UI.GridViewCommandColumn();
            commandColumn.Name = "Edit";
            commandColumn.HeaderText = "Editar";
            commandColumn.DefaultText = "Editar";
            commandColumn.UseDefaultText = true;
            this.grdItems.Columns.Add(commandColumn);
            this.grdItems.Columns["Edit"].AllowSort = false;
            this.grdItems.Columns["Edit"].AllowFiltering = false;
            //commandColumn = new Telerik.WinControls.UI.GridViewCommandColumn();
            //commandColumn.Name = "Delete";
            //commandColumn.HeaderText = "Eliminar";
            //commandColumn.DefaultText = "Eliminar";
            //commandColumn.UseDefaultText = true;
            //this.grdItems.Columns.Add(commandColumn);
            //this.grdItems.Columns["Delete"].AllowSort = false;
            //this.grdItems.Columns["Delete"].AllowFiltering = false;

            //this.grdItems.Columns.Add("", "Estado","");
            this.grdItems.Columns.Add("CCOT_NumDoc", "Número Orden Venta", "CCOT_NumDoc");
            this.grdItems.Columns.Add("CCOT_FecEmi", "Fecha Emisión", "CCOT_FecEmi");
            this.grdItems.Columns.Add("ENTC_NomCliente", "Cliente", "ENTC_NomCliente");
            this.grdItems.Columns.Add("CONS_DescRGM", "Régimen", "CONS_DescRGM");
            this.grdItems.Columns.Add("CONS_DescVIA", "Tipo Vía", "CONS_DescVIA");
            //this.grdItems.Columns.Add("TIPO_DescCDT", "Condición Embarque", "TIPO_DescCDT");
            this.grdItems.Columns.Add("ENTC_NomEjecutivo", "Ejecutivo de Ventas", "ENTC_NomEjecutivo");
            this.grdItems.Columns.Add("ENTC_NomShipper", "Shipper", "ENTC_NomShipper");
            this.grdItems.Columns.Add("ENTC_NomCustomer", "Customer", "ENTC_NomCustomer");
            this.grdItems.Columns.Add("ENTC_NomAgente", "Agente", "ENTC_NomAgente");
            this.grdItems.Columns.Add("DOOV_HBL", "HBL", "DOOV_HBL");
            this.grdItems.Columns.Add("DOOV_MBL", "MBL", "DOOV_MBL");
            //this.grdItems.Columns.Add("CNTR_Numero", "Número Contenedor", "CNTR_Numero");
            this.grdItems.Columns.Add("PUER_NombreOrigen", "Puerto Origen", "PUER_NombreOrigen");
            this.grdItems.Columns.Add("PUER_NombreDestino", "Puerto Destino", "PUER_NombreDestino");
            this.grdItems.Columns.Add("NAVE_Nombre", "Nave", "NAVE_Nombre");
            this.grdItems.Columns.Add("NVIA_NroViaje", "Viaje", "NVIA_NroViaje");
            this.grdItems.Columns.Add("ENTC_NomTransportista", "Transportista", "ENTC_NomTransportista");
            this.grdItems.Columns.Add("ENTC_NomDepTemporal", "Almacén", "ENTC_NomDepTemporal");
            this.grdItems.Columns.Add("NVIA_FecETA_Zarpe", "Fecha ETA/Zarpe", "NVIA_FecETA_Zarpe");
            this.grdItems.Columns.Add("DDOV_FecEmbarque", "Fecha Embarque", "DDOV_FecEmbarque");
            this.grdItems.Columns.Add("CCOT_FecRecDocs", "Fecha Ingreso Documentos", "CCOT_FecRecDocs");
            this.grdItems.Columns.Add("CONS_DescEST", "Estado", "CONS_DescEST");


            Telerik.WinControls.UI.GridViewCheckBoxColumn _checkColumn;
            _checkColumn = new Telerik.WinControls.UI.GridViewCheckBoxColumn("Bloqueado", "CCOT_Bloqueado");
            _checkColumn.HeaderText = "Bloqueado";
            this.grdItems.Columns.Add(_checkColumn);
            _checkColumn = new Telerik.WinControls.UI.GridViewCheckBoxColumn("Con Excepción", "CCOT_ConExcepcion");
            _checkColumn.HeaderText = "Con Excepción";
            this.grdItems.Columns.Add(_checkColumn);
            _checkColumn = new Telerik.WinControls.UI.GridViewCheckBoxColumn("Emitir HBL", "CCOT_EmitirHBL");
            _checkColumn.HeaderText = "Emitir HBL";
            this.grdItems.Columns.Add(_checkColumn);
            _checkColumn = new Telerik.WinControls.UI.GridViewCheckBoxColumn("Servicio Logístico", "CCOT_ServicioLogistico");
            _checkColumn.HeaderText = "Servicio Logístico";
            this.grdItems.Columns.Add(_checkColumn);
            _checkColumn = new Telerik.WinControls.UI.GridViewCheckBoxColumn("VB Operaciones", "CCOT_VBOperaciones");
            _checkColumn.HeaderText = "VB Operaciones";
            this.grdItems.Columns.Add(_checkColumn);
            _checkColumn = new Telerik.WinControls.UI.GridViewCheckBoxColumn("VB Logística", "CCOT_VBLogistico");
            _checkColumn.HeaderText = "VB Logística";
            this.grdItems.Columns.Add(_checkColumn);

            grdItems.BestFitColumns();

            tsmColumnas.DropDownItems.Clear();
            defaultColumns = new string[grdItems.Columns.Count];
            int index = 0;
            foreach (Telerik.WinControls.UI.GridViewDataColumn column in grdItems.Columns)
            {
               ToolStripMenuItem _item = new ToolStripMenuItem(column.HeaderText);
               _item.Tag = column.Name;
               _item.Checked = column.IsVisible;
               _item.CheckOnClick = true;
               _item.Click += new EventHandler(tsmColumna_Click);
               tsmColumnas.DropDownItems.Add(_item);

               if (column.IsVisible)
               { defaultColumns[index] = column.Name; index += 1; }
            }

            ToolStripSeparator tsmSeparacion = new ToolStripSeparator();
            tsmColumnas.DropDownItems.Add(tsmSeparacion);
            tsmTodos = new ToolStripMenuItem("Todos");
            tsmTodos.Tag = "Todas";
            tsmTodos.Checked = false;
            tsmTodos.CheckOnClick = true;
            tsmTodos.Click += new EventHandler(tsmTodos_Click);
            tsmColumnas.DropDownItems.Add(tsmTodos);

            Infrastructure.WinForms.Controls.GridAutoFit.Fit(grdItems);

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

      private void SeleccionarItem()
      {
         try
         {
            if (Presenter != null)
            {
               if (BSItems != null && BSItems != null && BSItems.DataSource != null && BSItems.Current != null && BSItems.Current is Entities.Cab_Cotizacion_OV)
               { Presenter.ItemLView = ((Entities.Cab_Cotizacion_OV)BSItems.Current); }
               else
               { Presenter.ItemLView = null; }
            }
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al seleccionar el item.", ex); }
      }

      private void Nuevo()
      {
         try
         {


            Presenter.Nuevo();
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al hacer nuevo.", ex); }
      }
      private void Buscar()
      {
         try
         {
            Boolean _isCorrect = true;
            String _mensaje = "";

            if (String.IsNullOrEmpty(txtCCOT_NumDoc.Text) && String.IsNullOrEmpty(txtDOOV_MBL.Text) && String.IsNullOrEmpty(txtDOOV_HBL.Text) && String.IsNullOrEmpty(txtCNTR_Numero.Text))
            {
               if (!mdtCCOT_FecEmisionDesde.NSFecha.HasValue)
               { _isCorrect = false; _mensaje += "* Debe ingresar la Fecha de Emisión Desde." + Environment.NewLine; }

               if (!mdtCCOT_FecEmisionHasta.NSFecha.HasValue)
               { _isCorrect = false; _mensaje += "* Debe ingresar la Fecha de Emisión Hasta."; }
            }

            if (_isCorrect)
            {
               Presenter.ListFilters = new ObservableCollection<Infrastructure.Aspect.DataAccess.DataAccessFilterSQL>();

               Nullable<Int32> _ENTC_CodCliente = null; if (txaENTC_CodCliente.Value != null) { _ENTC_CodCliente = txaENTC_CodCliente.Value.ENTC_Codigo; }
               Presenter.ListFilters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@pintENTC_CodCliente", FilterValue = _ENTC_CodCliente, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.Int32, FilterSize = 4 });

               Nullable<Int32> _ENTC_CodShipper = null; if (txaENTC_CodShipper.Value != null) { _ENTC_CodShipper = txaENTC_CodShipper.Value.ENTC_Codigo; }
               Presenter.ListFilters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@pintENTC_CodShipper", FilterValue = _ENTC_CodShipper, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.Int32, FilterSize = 4 });

               Nullable<Int32> _ENTC_CodEjecutivo = null; if (txaENTC_CodEjecutivo.Value != null) { _ENTC_CodEjecutivo = txaENTC_CodEjecutivo.Value.ENTC_Codigo; }
               Presenter.ListFilters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@pintENTC_CodEjecutivo", FilterValue = _ENTC_CodEjecutivo, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.Int32, FilterSize = 4 });

               Nullable<Int32> _ENTC_CodCustomer = null; if (txaENTC_CodCustomer.Value != null) { _ENTC_CodCustomer = txaENTC_CodCustomer.Value.ENTC_Codigo; }
               Presenter.ListFilters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@pintENTC_CodCustomer", FilterValue = _ENTC_CodCustomer, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.Int32, FilterSize = 4 });

               Nullable<Int32> _ENTC_CodAgente = null; if (txaENTC_CodAgente.Value != null) { _ENTC_CodAgente = txaENTC_CodAgente.Value.ENTC_Codigo; }
               Presenter.ListFilters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@pintENTC_CodAgente", FilterValue = _ENTC_CodAgente, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.Int32, FilterSize = 4 });

               Nullable<Int32> _PUER_CodOrigen = null; if (txaPUER_CodOrigen.SelectedItem != null) { _PUER_CodOrigen = txaPUER_CodOrigen.SelectedItem.PUER_Codigo; }
               Presenter.ListFilters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@pintPUER_CodOrigen", FilterValue = _PUER_CodOrigen, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.Int32, FilterSize = 4 });

               Nullable<Int32> _PUER_CodDestino = null; if (txaPUER_CodDestino.SelectedItem != null) { _PUER_CodDestino = txaPUER_CodDestino.SelectedItem.PUER_Codigo; }
               Presenter.ListFilters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@pintPUER_CodDestino", FilterValue = _PUER_CodDestino, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.Int32, FilterSize = 4 });

               Nullable<Int16> _NAVE_Codigo = null; if (txaNAVE_Codigo.Value != null && txaNAVE_Codigo.Value is Entities.Nave && (txaNAVE_Codigo.Value as Entities.Nave).NAVE_Codigo > 0) { _NAVE_Codigo = (txaNAVE_Codigo.Value as Entities.Nave).NAVE_Codigo; }
               Presenter.ListFilters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@psinNAVE_Codigo", FilterValue = _NAVE_Codigo, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.Int16, FilterSize = 2 });

               Nullable<Int32> _NVIA_Codigo = null; if (txaNVIA_NroViaje.Value != null && txaNVIA_NroViaje.Value is Entities.NaveViaje && (txaNVIA_NroViaje.Value as Entities.NaveViaje).NVIA_Codigo > 0) { _NVIA_Codigo = (txaNVIA_NroViaje.Value as Entities.NaveViaje).NVIA_Codigo; }
               Presenter.ListFilters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@pintNVIA_Codigo", FilterValue = _NVIA_Codigo, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.Int32, FilterSize = 4 });

               Nullable<Int32> _ENTC_CodTransportista = null; if (txaENTC_CodTransportista.Value != null) { _ENTC_CodTransportista = txaENTC_CodTransportista.Value.ENTC_Codigo; }
               Presenter.ListFilters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@pintENTC_CodTransportista", FilterValue = _ENTC_CodTransportista, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.Int32, FilterSize = 4 });

               String _TIPO_TabTDO = cmbTIPO_CodTDO.TiposSelectedItem != null ? cmbTIPO_CodTDO.TiposSelectedItem.TIPO_CodTabla : null;
               Presenter.ListFilters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@pchrTIPO_TabTDO", FilterValue = _TIPO_TabTDO, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.Char, FilterSize = 3 });

               String _TIPO_CodTDO = cmbTIPO_CodTDO.TiposSelectedItem != null ? cmbTIPO_CodTDO.TiposSelectedItem.TIPO_CodTipo : null;
               Presenter.ListFilters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@pchrTIPO_CodTDO", FilterValue = _TIPO_CodTDO, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.Char, FilterSize = 3 });

               String _CONS_TabEST = cmbCONS_CodEST.ConstantesSelectedItem != null ? cmbCONS_CodEST.ConstantesSelectedItem.CONS_CodTabla : null;
               Presenter.ListFilters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@pchrCONS_TabEST", FilterValue = _CONS_TabEST, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.Char, FilterSize = 3 });

               String _CONS_CodEST = cmbCONS_CodEST.ConstantesSelectedItem != null ? cmbCONS_CodEST.ConstantesSelectedItem.CONS_CodTipo : null;
               Presenter.ListFilters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@pchrCONS_CodEST", FilterValue = _CONS_CodEST, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.Char, FilterSize = 3 });

               String _SCOT_SerieTDO = null; if (!String.IsNullOrEmpty(txtSCOT_SerieTDO.Text)) { _SCOT_SerieTDO = txtSCOT_SerieTDO.Text.Trim(); }
               Presenter.ListFilters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@pvchSCOT_SerieTDO", FilterValue = _SCOT_SerieTDO, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.Varchar, FilterSize = 20 });

               String _SCOT_NumeroTDO = null; if (!String.IsNullOrEmpty(txtSCOT_NumeroTDO.Text)) { _SCOT_NumeroTDO = txtSCOT_NumeroTDO.Text.Trim(); }
               Presenter.ListFilters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@pvchSCOT_NumeroTDO", FilterValue = _SCOT_NumeroTDO, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.Varchar, FilterSize = 20 });

               String _CONS_TabRGM = cmbCONS_CodRGM.ConstantesSelectedItem != null ? cmbCONS_CodRGM.ConstantesSelectedItem.CONS_CodTabla : null;
               Presenter.ListFilters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@pchrCONS_TabRGM", FilterValue = _CONS_TabRGM, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.Char, FilterSize = 3 });

               String _CONS_CodRGM = cmbCONS_CodRGM.ConstantesSelectedItem != null ? cmbCONS_CodRGM.ConstantesSelectedItem.CONS_CodTipo : null;
               Presenter.ListFilters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@pchrCONS_CodRGM", FilterValue = _CONS_CodRGM, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.Char, FilterSize = 3 });

               String _CONS_TabVia = cmbCONS_CodVia.ConstantesSelectedItem != null ? cmbCONS_CodVia.ConstantesSelectedItem.CONS_CodTabla : null;
               Presenter.ListFilters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@pchrCONS_TabVia", FilterValue = _CONS_TabVia, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.Char, FilterSize = 3 });

               String _CONS_CodVia = cmbCONS_CodVia.ConstantesSelectedItem != null ? cmbCONS_CodVia.ConstantesSelectedItem.CONS_CodTipo : null;
               Presenter.ListFilters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@pchrCONS_CodVia", FilterValue = _CONS_CodVia, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.Char, FilterSize = 3 });

               String _CONS_TabFLE = cmbCONS_CodFLE.ConstantesSelectedItem != null ? cmbCONS_CodFLE.ConstantesSelectedItem.CONS_CodTabla : null;
               Presenter.ListFilters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@pchrCONS_TabFLE", FilterValue = _CONS_TabFLE, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.Char, FilterSize = 3 });

               String _CONS_CodFLE = cmbCONS_CodFLE.ConstantesSelectedItem != null ? cmbCONS_CodFLE.ConstantesSelectedItem.CONS_CodTipo : null;
               Presenter.ListFilters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@pchrCONS_CodFLE", FilterValue = _CONS_CodFLE, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.Char, FilterSize = 3 });

               String _TIPO_TabCDT = cmbTIPO_CodCDT.TiposSelectedItem != null ? cmbTIPO_CodCDT.TiposSelectedItem.TIPO_CodTabla : null;
               Presenter.ListFilters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@pchrTIPO_TabCDT", FilterValue = _TIPO_TabCDT, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.Char, FilterSize = 3 });

               String _TIPO_CodCDT = cmbTIPO_CodCDT.TiposSelectedItem != null ? cmbTIPO_CodCDT.TiposSelectedItem.TIPO_CodTipo : null;
               Presenter.ListFilters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@pchrTIPO_CodCDT", FilterValue = _TIPO_CodCDT, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.Char, FilterSize = 3 });

               String _DOOV_HBL = null; if (!String.IsNullOrEmpty(txtDOOV_HBL.Text)) { _DOOV_HBL = txtDOOV_HBL.Text.Trim(); }
               Presenter.ListFilters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@pvchDOOV_HBL", FilterValue = _DOOV_HBL, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.Varchar, FilterSize = 50 });

               String _DOOV_MBL = null; if (!String.IsNullOrEmpty(txtDOOV_MBL.Text)) { _DOOV_MBL = txtDOOV_MBL.Text.Trim(); }
               Presenter.ListFilters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@pvchDOOV_MBL", FilterValue = _DOOV_MBL, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.Varchar, FilterSize = 50 });

               String _CNTR_Numero = null; if (!String.IsNullOrEmpty(txtCNTR_Numero.Text)) { _CNTR_Numero = txtCNTR_Numero.Text.Trim(); }
               Presenter.ListFilters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@pvchCNTR_Numero", FilterValue = _CNTR_Numero, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.Varchar, FilterSize = 20 });

               String _CCOT_NumDoc = null; if (!String.IsNullOrEmpty(txtCCOT_NumDoc.Text)) { _CCOT_NumDoc = txtCCOT_NumDoc.Text.Trim(); }
               Presenter.ListFilters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@pvchCCOT_NumDoc", FilterValue = _CCOT_NumDoc, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.Varchar, FilterSize = 20 });

               Boolean _DHBL_EsIMO = chkDHBL_EsIMO.Checked;
               Presenter.ListFilters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@pbitDHBL_EsIMO", FilterValue = _DHBL_EsIMO, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.Boolean, FilterSize = 1 });

               Nullable<DateTime> _DDOV_FecEmbarqueDesde = mdtDDOV_FecEmbarqueDesde.NSFecha.HasValue ? mdtDDOV_FecEmbarqueDesde.NSFecha : null;
               Presenter.ListFilters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@pdtmDDOV_FecEmbarqueDesde", FilterValue = _DDOV_FecEmbarqueDesde, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.DateTime, FilterSize = 8 });

               Nullable<DateTime> _DDOV_FecEmbarqueHasta = mdtDDOV_FecEmbarqueHasta.NSFecha.HasValue ? mdtDDOV_FecEmbarqueHasta.NSFecha : null;
               Presenter.ListFilters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@pdtmDDOV_FecEmbarqueHasta", FilterValue = _DDOV_FecEmbarqueHasta, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.DateTime, FilterSize = 8 });

               Nullable<DateTime> _NVIA_FecETAZarpeDesde = mdtNVIA_FecETAZarpeDesde.NSFecha.HasValue ? mdtNVIA_FecETAZarpeDesde.NSFecha : null;
               Presenter.ListFilters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@pdtmNVIA_FecETAZarpeDesde", FilterValue = _NVIA_FecETAZarpeDesde, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.DateTime, FilterSize = 8 });

               Nullable<DateTime> _NVIA_FecETAZarpeHasta = mdtNVIA_FecETAZarpeHasta.NSFecha.HasValue ? mdtNVIA_FecETAZarpeHasta.NSFecha : null;
               Presenter.ListFilters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@pdtmNVIA_FecETAZarpeHasta", FilterValue = _NVIA_FecETAZarpeHasta, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.DateTime, FilterSize = 8 });

               Nullable<DateTime> _CCOT_FecRecDocsDesde = mdtCCOT_FecRecDocsDesde.NSFecha.HasValue ? mdtCCOT_FecRecDocsDesde.NSFecha : null;
               Presenter.ListFilters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@pdtmCCOT_FecRecDocsDesde", FilterValue = _CCOT_FecRecDocsDesde, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.DateTime, FilterSize = 8 });

               Nullable<DateTime> _CCOT_FecRecDocsHasta = mdtCCOT_FecRecDocsHasta.NSFecha.HasValue ? mdtCCOT_FecRecDocsHasta.NSFecha : null;
               Presenter.ListFilters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@pdtmCCOT_FecRecDocsHasta", FilterValue = _CCOT_FecRecDocsHasta, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.DateTime, FilterSize = 8 });

               Nullable<DateTime> _CCOT_FecEmisionDesde = mdtCCOT_FecEmisionDesde.NSFecha.HasValue ? mdtCCOT_FecEmisionDesde.NSFecha : null;
               Presenter.ListFilters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@pdtmCCOT_FecEmisionDesde", FilterValue = _CCOT_FecEmisionDesde, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.DateTime, FilterSize = 8 });

               Nullable<DateTime> _CCOT_FecEmisionHasta = mdtCCOT_FecEmisionHasta.NSFecha.HasValue ? mdtCCOT_FecEmisionHasta.NSFecha : null;
               Presenter.ListFilters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@pdtmCCOT_FecEmisionHasta", FilterValue = _CCOT_FecEmisionHasta, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.DateTime, FilterSize = 8 });

               Boolean _CCOT_Bloqueado = chkCCOT_Bloqueado.Checked;
               Presenter.ListFilters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@pbitCCOT_Bloqueado", FilterValue = _CCOT_Bloqueado, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.Boolean, FilterSize = 1 });

               Boolean _CCOT_ConExcepcion = chkCCOT_ConExcepcion.Checked;
               Presenter.ListFilters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@pbitCCOT_ConExcepcion", FilterValue = _CCOT_ConExcepcion, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.Boolean, FilterSize = 1 });

               Boolean _CCOT_EmitirHBL = chkCCOT_EmitirHBL.Checked;
               Presenter.ListFilters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@pbitCCOT_EmitirHBL", FilterValue = _CCOT_EmitirHBL, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.Boolean, FilterSize = 1 });

               Boolean _CCOT_ServicioLogistico = chkCCOT_ServicioLogistico.Checked;
               Presenter.ListFilters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@pbitCCOT_ServicioLogistico", FilterValue = _CCOT_ServicioLogistico, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.Boolean, FilterSize = 1 });

               Boolean _CCOT_VBOperaciones = chkCCOT_VBOperaciones.Checked;
               Presenter.ListFilters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@pbitCCOT_VBOperaciones", FilterValue = _CCOT_VBOperaciones, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.Boolean, FilterSize = 1 });

               Boolean _CCOT_VBLogistico = chkCCOT_VBLogistico.Checked;
               Presenter.ListFilters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@pbitCCOT_VBLogistico", FilterValue = _CCOT_VBLogistico, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.Boolean, FilterSize = 1 });

               Boolean _CCOT_DiferenciaFlete = chkCCOT_DiferenciaFlete.Checked;
               Presenter.ListFilters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@pbitCCOT_DiferenciaFlete", FilterValue = _CCOT_DiferenciaFlete, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.Boolean, FilterSize = 1 });

               Boolean _CCOT_DiferenciaFleteRecup = chkCCOT_DiferenciaFleteRecup.Checked;
               Presenter.ListFilters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@pbitCCOT_DiferenciaFleteRecup", FilterValue = _CCOT_DiferenciaFleteRecup, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.Boolean, FilterSize = 1 });

               Boolean _CCOT_OVConcluida = Presenter.OVCONCLUIDA;
               Presenter.ListFilters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@pbitCCOT_OVConcluida", FilterValue = _CCOT_OVConcluida, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.Boolean, FilterSize = 1 });
               Boolean _CCOT_OVDocumentada = Presenter.OVDOCUMENTADA;
               Presenter.ListFilters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@pbitCCOT_OVDocumentada", FilterValue = _CCOT_OVDocumentada, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.Boolean, FilterSize = 1 });
               Boolean _CCOT_OVSoloLectura = Presenter.OVSOLOLECTURA;
               Presenter.ListFilters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@pbitCCOT_OVSoloLectura", FilterValue = _CCOT_OVSoloLectura, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.Boolean, FilterSize = 1 });

               Int16 _empresa = Delfin.Controls.Entorno.ItemEmpresa.EMPR_Codigo;
               Presenter.ListFilters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@psinEMPR_Codigo", FilterValue = _empresa, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.Int16, FilterSize = 2 });
               Int16 _sucursal = Delfin.Controls.Entorno.ItemSucursal.SUCR_Codigo;
               Presenter.ListFilters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@psinSUCR_Codigo", FilterValue = _sucursal, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.Int16, FilterSize = 2 });

               Presenter.Actualizar();
            }
            else
            { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Presenter.Title, "Debe ingresar los campos obligatorios para realizar la búsqueda (Ver Detalles).", _mensaje); }
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
            txaENTC_CodCliente.ClearValue();
            txaENTC_CodShipper.ClearValue();
            txaENTC_CodEjecutivo.ClearValue();
            txaENTC_CodCustomer.ClearValue();
            txaENTC_CodAgente.ClearValue();
            txaPUER_CodOrigen.Clear();
            txaPUER_CodDestino.Clear();
            //txaNAVE_Codigo.Clear();
            txaNAVE_Codigo.ClearValue();
            //txaNVIA_NroViaje.Clear();
            txaNVIA_NroViaje.ClearValue();
            txaENTC_CodTransportista.ClearValue();
            cmbTIPO_CodTDO.TiposSelectedValue = null;
            txtSCOT_SerieTDO.Text = String.Empty;
            txtSCOT_NumeroTDO.Text = String.Empty;
            cmbCONS_CodRGM.ConstantesSelectedValue = null;
            cmbCONS_CodVia.ConstantesSelectedValue = null;
            cmbCONS_CodFLE.ConstantesSelectedValue = null;
            cmbTIPO_CodCDT.TiposSelectedValue = null;
            txtDOOV_HBL.Text = String.Empty;
            txtDOOV_MBL.Text = String.Empty;
            txtCNTR_Numero.Text = String.Empty;
            txtCCOT_NumDoc.Text = String.Empty;
            chkDHBL_EsIMO.Checked = false;
            mdtDDOV_FecEmbarqueDesde.NSFecha = null;
            mdtDDOV_FecEmbarqueHasta.NSFecha = null;
            mdtNVIA_FecETAZarpeDesde.NSFecha = null;
            mdtNVIA_FecETAZarpeHasta.NSFecha = null;
            mdtCCOT_FecRecDocsDesde.NSFecha = null;
            mdtCCOT_FecRecDocsHasta.NSFecha = null;
            mdtCCOT_FecEmisionDesde.NSFecha = null;
            mdtCCOT_FecEmisionHasta.NSFecha = null;
            chkCCOT_Bloqueado.Checked = false;
            chkCCOT_ConExcepcion.Checked = false;
            chkCCOT_EmitirHBL.Checked = false;
            chkCCOT_ServicioLogistico.Checked = false;
            chkCCOT_VBOperaciones.Checked = false;
            chkCCOT_VBLogistico.Checked = false;
            chkCCOT_DiferenciaFlete.Checked = false;
            chkCCOT_DiferenciaFleteRecup.Checked = false;

            mdtCCOT_FecEmisionDesde.NSFecha = Presenter.Session.Fecha.AddMonths(-2);
            mdtCCOT_FecEmisionHasta.NSFecha = Presenter.Session.Fecha;

            BSItems.DataSource = null;
            grdItems.DataSource = BSItems;
            navItems.BindingSource = BSItems;
            BSItems.ResetBindings(true);

            grdItems.Enabled = true;
            btnNuevo.Enabled = true;
            btnBuscar.Enabled = true;
            btnExportar.Enabled = false;
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al deshacer la vista.", ex); }
      }
      #endregion

      #region [ Eventos ]
      private void btnNuevo_Click(object sender, EventArgs e)
      { Nuevo(); }
      private void btnBuscar_Click(object sender, EventArgs e)
      { Buscar(); }
      private void btnExportar_Click(object sender, EventArgs e)
      { Exportar(); }
      private void btnDeshacer_Click(object sender, EventArgs e)
      { Deshacer(); }

      private void BSItems_CurrentItemChanged(object sender, EventArgs e)
      { SeleccionarItem(); }
      private void grdItems_CommandCellClick(object sender, EventArgs e)
      {
         try
         {
            if (sender is Telerik.WinControls.UI.GridCommandCellElement)
            {
               switch ((((Telerik.WinControls.UI.GridCommandCellElement)(sender)).CommandButton).TextElement.Text)
               {
                  case "Editar":
                     SeleccionarItem();
                     Presenter.Editar();
                     break;
                  case "Eliminar":
                     SeleccionarItem();
                     Presenter.Eliminar();
                     break;
               }
            }
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al cargar los botones para editar y eliminar.", ex); }

      }
      void grdItems_CellFormatting(object sender, CellFormattingEventArgs e)
      {
         try
         {
            if (e.CellElement is GridCommandCellElement)
            {
               if (e.Column.Name.Equals("Edit"))
               {
                  var bte = (RadButtonElement)e.CellElement.Children[0];
                  if (bte.Image == null)
                  {
                     bte.TextImageRelation = TextImageRelation.Overlay;
                     bte.DisplayStyle = DisplayStyle.Image;
                     bte.ImageAlignment = ContentAlignment.MiddleCenter;
                     bte.Image = Resources.editar16x16;
                     bte.ToolTipText = @"Editar Registro";
                     bte.AutoSize = true;
                  }
               }
               if (e.CellElement.RowInfo is GridViewNewRowInfo && e.CellElement.ColumnInfo is GridViewCommandColumn)
               {
                  e.CellElement.Children[0].Visibility = ElementVisibility.Hidden;
               }
            }

         }
         catch (Exception ex) { Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al formatear el icono." + ex.Message); }
      }

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
