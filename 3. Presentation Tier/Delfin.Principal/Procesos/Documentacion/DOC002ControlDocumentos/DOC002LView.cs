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
using Telerik.WinControls;
using Telerik.WinControls.UI;
using Infrastructure.WinForms.Controls;

namespace Delfin.Principal
{
   public partial class DOC002LView : UserControl, IDOC002LView
   {
      #region [ Variables ]
      //private String m_sortColumnName;
      //private Boolean m_sortAscending = false;
      #endregion

      #region [ Formulario ]
      public DOC002LView(Telerik.WinControls.UI.RadPageViewPage x_tabPageControl)
      {
         InitializeComponent();
         try
         {
            TabPageControl = x_tabPageControl;

            //btnNuevo.Click += new EventHandler(btnNuevo_Click);
            btnBuscar.Click += new EventHandler(btnBuscar_Click);
            btn_ActualizarPreAlerta.Click += new EventHandler(btn_ActualizarPreAlerta_Click);
            btnExportar.Click += new EventHandler(btnExportar_Click);
            btnDeshacer.Click += new EventHandler(btnDeshacer_Click);
            btnCorreo.Click += new EventHandler(btnCorreo_Click);
            btn_Nuevo.Click += new EventHandler(btnNuevo_Click);

            BSItems = new BindingSource();
            BSItems.CurrentItemChanged += new EventHandler(BSItems_CurrentItemChanged);

            BSItemsOV = new BindingSource();

            grdItems.CommandCellClick += new Telerik.WinControls.UI.CommandCellClickEventHandler(grdItems_CommandCellClick);
            //grdItems.SelectionChanging += grdItems_SelectionChanging;
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
      public DOC002Presenter Presenter { get; set; }
      public BindingSource BSItems { get; set; }
      public BindingSource BSItemsOV { get; set; }
      public DataTable DtOVs { get; set; }
      #endregion

      #region [ IDOC002LView ]
      /// <summary>
      /// CRITERIOS DE BUSQUEDA
      /// rbtnLOAD_SegundoOKCon                 => Con Pre-Alerta (Con Segundo OK Loading List)
      /// rbtnLOAD_SegundoOKSin                 => Sin Pre-Alerta (Sin Segundo OK Loading List)
      /// txaENTC_CodTransportista              => Línea o Trabnsportista de la NaveViaje
      /// cmbCONS_CodRGM                        => Régimen de la OV
      /// cmbCONS_CodVia                        => Vía de la OV
      /// txtLOAD_HBL                           => Número de HBL del Loading List
      /// txtLOAD_MBL                           => Número de HBL del Loading List
      /// txtCCOT_NumDoc                        => Número de la OV
      /// ayudaPuertoOrigen                     => Ayuda del Puerto Origen
      /// mdtLOAD_FecPrimerOKInicio             => Fecha de Inicio del Primer Ok del Loading List
      /// mdtLOAD_FecPrimerOKFin                => Fecha de Fin del Primer Ok del Loading List
      /// 
      /// DATOS PÁRA EL CONTROL DE DOCUMENTOS
      /// txtLOAD_Observaciones                 => Observaciones respecto al al Segundo Ok del Loading List
      /// mdtFec_Entrega
      /// mtdFec_Devolucion
      /// txtLOAD_SegundoUsuario                => Usuario que realiza el Segundo Ok del Loading List  
      /// </summary>
      public void LoadView()
      {
         try
         {

            cmbCONS_CodRGM.LoadControl(Presenter.ContainerService, "Combo Constantes de Régimen", "RGM", "< Seleccionar Régimen >", ListSortDirection.Ascending);
            cmbCONS_CodVia.LoadControl(Presenter.ContainerService, "Combo Constantes de Vía", "VIA", "< Seleccionar Vía >", ListSortDirection.Ascending);
            ayudaPuertoOrigen.LoadControl(Presenter.ContainerService, "Ayuda de Puerto Origen");
            txtENTC_CodTransportista.ContainerService = Presenter.ContainerService;
            txtENTC_CodTransportista.TipoEntidad = Delfin.Controls.TiposEntidad.TIPE_Transportista;


            FormatDataGrid();
            FormatDataGridOV();

            grdItems.Enabled = false;
            grdItemsOV.Enabled = false;
            btnCorreo.Enabled = false;
            btnBuscar.Enabled = true;
            btnExportar.Enabled = false;
            btn_ActualizarPreAlerta.Enabled = false;
            tabServiciosAdicionales.SelectedTab = pageControlDocumentos;
            SetItem();
            SeleccionarItem();
            Presenter.ActualizarOVs(null, null);
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
               btn_ActualizarPreAlerta.Enabled = true;
               Infrastructure.WinForms.Controls.GridAutoFit.Fit(this.grdItems);
            }
            else
            {
               grdItems.Enabled = false;
               btnExportar.Enabled = false;
               btn_ActualizarPreAlerta.Enabled = false;
            }

            grdItems.ShowFilteringRow = true;
            grdItems.EnableFiltering = true;
            grdItems.MasterTemplate.EnableFiltering = false;
            grdItems.EnableGrouping = false;
            grdItems.MasterTemplate.EnableGrouping = false;
            grdItems.EnableSorting = false;//cuidado
            grdItems.MasterTemplate.EnableCustomSorting = false;

            SeleccionarItem();
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error cargando los items.", ex); }
      }
      public void ShowItems(System.Data.DataTable dt, Boolean _cp) //_CP VERIFICA SI ES CON PRE ALERTA O NO 
      {
         try
         {
            BSItems.DataSource = dt;
            grdItems.DataSource = BSItems;
            navItems.BindingSource = BSItems;
            BSItems.ResetBindings(true);
            if (grdItems.RowCount > 0)
            {
               grdItems.Enabled = true;
               btnExportar.Enabled = true;
               btn_ActualizarPreAlerta.Enabled = true;
               btnCorreo.Enabled = true;
               Infrastructure.WinForms.Controls.GridAutoFit.Fit2(grdItems);
               //Infrastructure.WinForms.Controls.GridAutoFit.Fit(this.grdItems);
            }
            else
            {
               grdItems.Enabled = false;
               btnExportar.Enabled = false;
               btnCorreo.Enabled = false;
               btn_ActualizarPreAlerta.Enabled = false;
            }

            grdItems.ShowFilteringRow = true;
            grdItems.EnableFiltering = true;
            grdItems.MasterTemplate.EnableFiltering = true;
            grdItems.EnableGrouping = false;
            grdItems.MasterTemplate.EnableGrouping = false;
            grdItems.EnableSorting = false;
            grdItems.MasterTemplate.EnableCustomSorting = false;
            grdItems.ReadOnly = false;

            if (_cp)
            {
               grdItems.AllowEditRow = true;
               grdItems.Columns["LOAD_SegundoOK"].ReadOnly = true;
               grdItems.Columns["LOAD_EnvioCorreo"].ReadOnly = true;
               btn_ActualizarPreAlerta.Enabled = false;
               btnCorreo.Enabled = false;
            }
            else
            {
               grdItems.AllowEditRow = true;
               grdItems.Columns["LOAD_SegundoOK"].ReadOnly = false;
               grdItems.Columns["LOAD_EnvioCorreo"].ReadOnly = false;
               //btn_ActualizarPreAlerta.Enabled = true;
               //btnCorreo.Enabled = true;
            }
            SeleccionarItem();
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error cargando los items.", ex); }
      }
      public void ShowItemsOV(System.Data.DataTable dt)
      {
         try
         {
            BSItemsOV.DataSource = dt;
            grdItemsOV.DataSource = BSItemsOV;
            navItemsOV.BindingSource = BSItemsOV;
            BSItemsOV.ResetBindings(true);
            if (grdItemsOV.RowCount > 0)
            {
               grdItemsOV.Enabled = true;
               Infrastructure.WinForms.Controls.GridAutoFit.Fit(grdItemsOV);
               //Infrastructure.WinForms.Controls.GridAutoFit.Fit(this.grdItemsOV);
            }
            else
            {
               grdItemsOV.Enabled = false;
            }

            grdItemsOV.ShowFilteringRow = true;
            grdItemsOV.EnableFiltering = true;
            grdItemsOV.MasterTemplate.EnableFiltering = true;
            grdItemsOV.EnableGrouping = true;
            grdItemsOV.MasterTemplate.EnableGrouping = true;
            grdItemsOV.EnableSorting = false;
            grdItemsOV.MasterTemplate.EnableCustomSorting = false;
            grdItemsOV.ReadOnly = false;


         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error cargando los items.", ex); }
      }
      public void SetItem()
      {
         try
         {
            mdtLOAD_FecSegundoOK.Enabled = false;
            mdtLOAD_FecSegundoOK.NSFecha = Presenter.Session.Fecha;
            //txtLOAD_SegundoUsuario.Enabled = false;
            txtLOAD_SegundoUsuario.Text = Presenter.Session.UserName;
            rbtnLOAD_SegundoOKSin.Checked = true;
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error en SetItem.", ex); }
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
            this.grdItems.AllowDeleteRow = false;
            this.grdItems.AutoGenerateColumns = false;
            this.grdItems.AllowColumnReorder = false;
            this.grdItems.AllowRowResize = false;
            this.grdItems.AllowRowReorder = false;
            this.grdItems.AllowColumnHeaderContextMenu = false;
            this.grdItems.AllowCellContextMenu = false;
            this.grdItems.AllowMultiColumnSorting = false;
            //this.grdItems.AllowEditRow = true;
            this.grdItems.ReadOnly = true;

            //##########################################################
            Telerik.WinControls.UI.GridViewCommandColumn commandColumn;
            commandColumn = new Telerik.WinControls.UI.GridViewCommandColumn();
            commandColumn.Name = "Edit";
            commandColumn.HeaderText = "Editar";
            commandColumn.DefaultText = "Editar";
            commandColumn.UseDefaultText = true;
            this.grdItems.Columns.Add(commandColumn);
            this.grdItems.Columns["Edit"].AllowSort = false;
            this.grdItems.Columns["Edit"].AllowFiltering = false;
            commandColumn = new Telerik.WinControls.UI.GridViewCommandColumn();
            commandColumn.Name = "Delete";
            commandColumn.HeaderText = "Eliminar";
            commandColumn.DefaultText = "Eliminar";
            commandColumn.UseDefaultText = true;
            this.grdItems.Columns.Add(commandColumn);
            this.grdItems.Columns["Delete"].AllowSort = false;
            this.grdItems.Columns["Delete"].AllowFiltering = false;
            commandColumn = new Telerik.WinControls.UI.GridViewCommandColumn();
            commandColumn.Name = "Files";
            commandColumn.HeaderText = "Documentos";
            commandColumn.DefaultText = "Documentos";
            commandColumn.UseDefaultText = true;
            this.grdItems.Columns.Add(commandColumn);
            this.grdItems.Columns["Files"].AllowSort = false;
            this.grdItems.Columns["Files"].AllowFiltering = false;
            //##########################################################

            #region [ Documentos Pre_alerta]
            ///Pre_Alerta
            Telerik.WinControls.UI.GridViewCheckBoxColumn _preAlerta = new Telerik.WinControls.UI.GridViewCheckBoxColumn();
            _preAlerta.Name = "LOAD_SegundoOK";
            _preAlerta.HeaderText = "Pre-Alerta";
            _preAlerta.FieldName = "LOAD_SegundoOK";
            this.grdItems.Columns.Add(_preAlerta);
            //grdItems.Columns["LOAD_SegundoOK"].ReadOnly = false;
            ///Enviar Correo
            Telerik.WinControls.UI.GridViewCheckBoxColumn _enviarCorreo = new Telerik.WinControls.UI.GridViewCheckBoxColumn();
            _enviarCorreo.Name = "LOAD_EnvioCorreo";
            _enviarCorreo.HeaderText = "Enviar Correo";
            _enviarCorreo.FieldName = "LOAD_EnvioCorreo";
            this.grdItems.Columns.Add(_enviarCorreo);
            //grdItems.Columns["LOAD_EnvioCorreo"].ReadOnly = false;

            this.grdItems.Columns.Add("LOAD_SegundoUsuario", "Enviado Por", "LOAD_SegundoUsuario");
            grdItems.Columns["LOAD_SegundoUsuario"].ReadOnly = true;
            this.grdItems.Columns.Add("LOAD_FecSegundoOK", "Fec. Pre-Alerta", "LOAD_FecSegundoOK");
            grdItems.Columns["LOAD_FecSegundoOK"].ReadOnly = true;
            this.grdItems.Columns.Add("LOAD_ObserSegundoOk", "Observaciones Pre-Alerta", "LOAD_ObserSegundoOk");
            grdItems.Columns["LOAD_ObserSegundoOk"].ReadOnly = true;
            this.grdItems.Columns.Add("LOAD_FecDevolucion", "Fec. Devolucion", "LOAD_FecDevolucion");
            grdItems.Columns["LOAD_FecDevolucion"].ReadOnly = true;

            //this.grdItems.Columns.Add("TRAN_Glosa", "Glosa", "TRAN_Glosa");
            #endregion

            #region [ Loading List ]
            this.grdItems.Columns.Add("LOAD_Codigo", "Codigo LOAD", "LOAD_Codigo");
            grdItems.Columns["LOAD_Codigo"].IsVisible = false;
            this.grdItems.Columns.Add("LOAD_HBL", "Nro. HBL", "LOAD_HBL");
            grdItems.Columns["LOAD_HBL"].ReadOnly = true;
            this.grdItems.Columns.Add("LOAD_MBL", "Nro. MBL", "LOAD_MBL");
            grdItems.Columns["LOAD_MBL"].ReadOnly = true;
            this.grdItems.Columns.Add("PUER_NombreLOADOri", "Puerto Origen", "PUER_NombreLOADOri");
            grdItems.Columns["PUER_NombreLOADOri"].ReadOnly = true;
            this.grdItems.Columns.Add("PUER_CodEstLOADOri", "Puerto Origen", "PUER_CodEstLOADOri");
            grdItems.Columns["PUER_CodEstLOADOri"].IsVisible = false;
            //Loading List (Correo)
            this.grdItems.Columns.Add("PUER_NombreLOADDes", "Puerto Destino", "PUER_NombreLOADDes");
            grdItems.Columns["PUER_NombreLOADDes"].IsVisible = false;
            //this.grdItems.Columns.Add("PUER_CodEstLOADOri", "M/V", "PUER_CodEstLOADOri");
            //grdItems.Columns["CCOT_Codigo"].IsVisible = false;
            this.grdItems.Columns.Add("LOAD_ETD", "ETD", "LOAD_ETD");
            grdItems.Columns["LOAD_ETD"].IsVisible = false;
            this.grdItems.Columns.Add("LOAD_Carrier", "CARRIER", "LOAD_Carrier");
            grdItems.Columns["LOAD_Carrier"].IsVisible = false;
            this.grdItems.Columns.Add("LOAD_Booking", "BOOKING NO.", "LOAD_Booking");
            grdItems.Columns["LOAD_Booking"].IsVisible = false;
            this.grdItems.Columns.Add("CNTR_Numero", "CNTR", "CNTR_Numero");
            grdItems.Columns["CNTR_Numero"].IsVisible = false;
            this.grdItems.Columns.Add("LOAD_Shipper", "SHIPPER", "LOAD_Shipper");
            grdItems.Columns["LOAD_Shipper"].IsVisible = false;
            this.grdItems.Columns.Add("LOAD_Consignee", "CONSIGNEE", "LOAD_Consignee");
            grdItems.Columns["LOAD_Consignee"].IsVisible = false;
            this.grdItems.Columns.Add("LOAD_NaveViaje", "NAVE-VIAJE", "LOAD_NaveViaje");
            grdItems.Columns["LOAD_NaveViaje"].IsVisible = false;
            #endregion

            #region[ Orden de Venta ]
            this.grdItems.Columns.Add("CCOT_Codigo", "Codigo OV", "CCOT_Codigo");
            grdItems.Columns["CCOT_Codigo"].IsVisible = false;
            this.grdItems.Columns.Add("CCOT_Tipo", "Tipo", "CCOT_Tipo");
            grdItems.Columns["CCOT_Tipo"].IsVisible = false;
            this.grdItems.Columns.Add("CCOT_Estado", "Estado", "CCOT_Estado");
            grdItems.Columns["CCOT_Estado"].IsVisible = false;
            this.grdItems.Columns.Add("CCOT_NumDoc", "Nro. OV", "CCOT_NumDoc");
            grdItems.Columns["CCOT_NumDoc"].ReadOnly = true;
            this.grdItems.Columns.Add("CCOT_FecEmi", "Fec. Emision", "CCOT_FecEmi");
            grdItems.Columns["CCOT_FecEmi"].ReadOnly = true;
            this.grdItems.Columns.Add("DDOV_FecEmbarque", "Fec. Embarque", "DDOV_FecEmbarque");
            grdItems.Columns["DDOV_FecEmbarque"].ReadOnly = true;
            this.grdItems.Columns.Add("ECLI_NomCompleto", "Cliente", "ECLI_NomCompleto");
            grdItems.Columns["ECLI_NomCompleto"].ReadOnly = true;
            this.grdItems.Columns.Add("EAGE_NomCompleto", "Agente", "EAGE_NomCompleto");
            grdItems.Columns["EAGE_NomCompleto"].ReadOnly = true;
            this.grdItems.Columns.Add("CONS_DescRGM", "Régimen", "CONS_DescRGM");
            grdItems.Columns["CONS_DescRGM"].ReadOnly = true;
            this.grdItems.Columns.Add("CONS_DescVIA", "Vía", "CONS_DescVIA");
            grdItems.Columns["CONS_DescVIA"].ReadOnly = true;
            this.grdItems.Columns.Add("EEJE_NomCompleto", "Ejecutivo", "EEJE_NomCompleto");
            grdItems.Columns["EEJE_NomCompleto"].ReadOnly = true;
            this.grdItems.Columns.Add("ECUS_NomCompleto", "Customer", "ECUS_NomCompleto");
            grdItems.Columns["ECUS_NomCompleto"].ReadOnly = true;
            this.grdItems.Columns.Add("ETRA_NomCompleto", "Linea Naviera", "ETRA_NomCompleto");
            grdItems.Columns["ETRA_NomCompleto"].ReadOnly = true;
            this.grdItems.Columns.Add("PUER_NombreOri", "Puerto Origen", "PUER_NombreOri");
            grdItems.Columns["PUER_NombreOri"].ReadOnly = true;
            this.grdItems.Columns.Add("PUER_NombreDes", "Puerto Destino", "PUER_NombreDes");
            grdItems.Columns["PUER_NombreDes"].ReadOnly = true;
            this.grdItems.Columns.Add("PUER_CodEstandarOri", "Puerto Origen", "PUER_CodEstandarOri");
            grdItems.Columns["PUER_CodEstandarOri"].IsVisible = false;
            this.grdItems.Columns.Add("PUER_CodEstandarDeS", "Puerto Destino", "PUER_CodEstandarDeS");
            grdItems.Columns["PUER_CodEstandarDeS"].IsVisible = false;
            #endregion


            //GRUPOS EN LA GRILLA
            var columnGroupsView = new ColumnGroupsViewDefinition();
            columnGroupsView.ColumnGroups.Add(new GridViewColumnGroup("Documentos"));
            columnGroupsView.ColumnGroups.Add(new GridViewColumnGroup("Loading List"));
            columnGroupsView.ColumnGroups.Add(new GridViewColumnGroup("Orden de Venta"));

            // DOCUMENTOS
            columnGroupsView.ColumnGroups[0].Rows.Add(new GridViewColumnGroupRow());
            columnGroupsView.ColumnGroups[0].Rows[0].Columns.Add(grdItems.Columns["Edit"]);
            columnGroupsView.ColumnGroups[0].Rows[0].Columns.Add(grdItems.Columns["Delete"]);
            columnGroupsView.ColumnGroups[0].Rows[0].Columns.Add(grdItems.Columns["Files"]);
            columnGroupsView.ColumnGroups[0].Rows[0].Columns.Add(grdItems.Columns["LOAD_SegundoOK"]);
            columnGroupsView.ColumnGroups[0].Rows[0].Columns.Add(grdItems.Columns["LOAD_EnvioCorreo"]);
            columnGroupsView.ColumnGroups[0].Rows[0].Columns.Add(grdItems.Columns["LOAD_SegundoUsuario"]);
            columnGroupsView.ColumnGroups[0].Rows[0].Columns.Add(grdItems.Columns["LOAD_FecSegundoOK"]);
            columnGroupsView.ColumnGroups[0].Rows[0].Columns.Add(grdItems.Columns["LOAD_ObserSegundoOk"]);
            columnGroupsView.ColumnGroups[0].Rows[0].Columns.Add(grdItems.Columns["LOAD_FecDevolucion"]);
            grdItems.ViewDefinition = columnGroupsView;

            //LOSDING LIST
            columnGroupsView.ColumnGroups[1].Rows.Add(new GridViewColumnGroupRow());
            //columnGroupsView.ColumnGroups[1].Rows[0].Columns.Add(grdItems.Columns["LOAD_Codigo"]);
            columnGroupsView.ColumnGroups[1].Rows[0].Columns.Add(grdItems.Columns["LOAD_HBL"]);
            columnGroupsView.ColumnGroups[1].Rows[0].Columns.Add(grdItems.Columns["LOAD_MBL"]);
            columnGroupsView.ColumnGroups[1].Rows[0].Columns.Add(grdItems.Columns["PUER_NombreLOADOri"]);
            grdItems.ViewDefinition = columnGroupsView;

            //ORDEN DE VENTA 
            columnGroupsView.ColumnGroups[2].Rows.Add(new GridViewColumnGroupRow());
            columnGroupsView.ColumnGroups[2].Rows[0].Columns.Add(grdItems.Columns["CCOT_NumDoc"]);
            columnGroupsView.ColumnGroups[2].Rows[0].Columns.Add(grdItems.Columns["CCOT_FecEmi"]);
            columnGroupsView.ColumnGroups[2].Rows[0].Columns.Add(grdItems.Columns["DDOV_FecEmbarque"]);
            columnGroupsView.ColumnGroups[2].Rows[0].Columns.Add(grdItems.Columns["ECLI_NomCompleto"]);
            columnGroupsView.ColumnGroups[2].Rows[0].Columns.Add(grdItems.Columns["EAGE_NomCompleto"]);
            columnGroupsView.ColumnGroups[2].Rows[0].Columns.Add(grdItems.Columns["CONS_DescRGM"]);
            columnGroupsView.ColumnGroups[2].Rows[0].Columns.Add(grdItems.Columns["CONS_DescVIA"]);
            columnGroupsView.ColumnGroups[2].Rows[0].Columns.Add(grdItems.Columns["EEJE_NomCompleto"]);
            columnGroupsView.ColumnGroups[2].Rows[0].Columns.Add(grdItems.Columns["ECUS_NomCompleto"]);
            columnGroupsView.ColumnGroups[2].Rows[0].Columns.Add(grdItems.Columns["ETRA_NomCompleto"]);
            columnGroupsView.ColumnGroups[2].Rows[0].Columns.Add(grdItems.Columns["PUER_NombreOri"]);
            columnGroupsView.ColumnGroups[2].Rows[0].Columns.Add(grdItems.Columns["PUER_NombreDes"]);
            grdItems.ViewDefinition = columnGroupsView;

            //grdItems.BestFitColumns();

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
            Infrastructure.WinForms.Controls.GridAutoFit.Fit2(grdItems);

         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, Infrastructure.Aspect.Constants.Mensajes.FormatDataGridView, ex); }
      }
      private void FormatDataGridOV()
      {
         try
         {
            Telerik.WinControls.UI.Localization.RadGridLocalizationProvider.CurrentProvider = new Infrastructure.WinForms.Controls.MySpanishRadGridLocalizationProvider();

            this.grdItemsOV.Columns.Clear();
            this.grdItemsOV.AllowAddNewRow = false;
            this.grdItemsOV.AllowDeleteRow = false;
            this.grdItemsOV.AutoGenerateColumns = false;
            this.grdItemsOV.AllowColumnReorder = false;
            this.grdItemsOV.AllowRowResize = false;
            this.grdItemsOV.AllowRowReorder = false;
            this.grdItemsOV.AllowColumnHeaderContextMenu = false;
            this.grdItemsOV.AllowCellContextMenu = false;
            this.grdItemsOV.AllowMultiColumnSorting = false;
            //this.grdItemsOV.AllowEditRow = true;
            this.grdItemsOV.ReadOnly = true;


            #region[ Orden de Venta ]
            this.grdItemsOV.Columns.Add("CCOT_Codigo", "Codigo OV", "CCOT_Codigo");
            grdItemsOV.Columns["CCOT_Codigo"].IsVisible = false;
            this.grdItemsOV.Columns.Add("CCOT_NumDoc", "Nro. OV", "CCOT_NumDoc");
            //grdItemsOV.Columns["CCOT_NumDoc"].ReadOnly = true;
            this.grdItemsOV.Columns.Add("CCOT_FecEmi", "Fec. Emision", "CCOT_FecEmi");
            //grdItemsOV.Columns["CCOT_FecEmi"].ReadOnly = true;
            this.grdItemsOV.Columns.Add("DDOV_FecEmbarque", "Fec. Embarque", "DDOV_FecEmbarque");
            //grdItemsOV.Columns["DDOV_FecEmbarque"].ReadOnly = true;
            this.grdItemsOV.Columns.Add("ECLI_NomCompleto", "Cliente", "ECLI_NomCompleto");
            //grdItemsOV.Columns["ECLI_NomCompleto"].ReadOnly = true;
            this.grdItemsOV.Columns.Add("EAGE_NomCompleto", "Agente", "EAGE_NomCompleto");
            //grdItemsOV.Columns["EAGE_NomCompleto"].ReadOnly = true;
            this.grdItemsOV.Columns.Add("NAVE_Nombre", "Nave", "NAVE_Nombre");
            this.grdItemsOV.Columns.Add("NVIA_NroViaje", "Nro Viaje", "NVIA_NroViaje");
            this.grdItemsOV.Columns.Add("CONS_DescRGM", "Régimen", "CONS_DescRGM");
            //grdItemsOV.Columns["CONS_DescRGM"].ReadOnly = true;
            this.grdItemsOV.Columns.Add("CONS_DescVIA", "Vía", "CONS_DescVIA");
            //grdItemsOV.Columns["CONS_DescVIA"].ReadOnly = true;
            this.grdItemsOV.Columns.Add("EEJE_NomCompleto", "Ejecutivo", "EEJE_NomCompleto");
            //grdItemsOV.Columns["EEJE_NomCompleto"].ReadOnly = true;
            this.grdItemsOV.Columns.Add("ECUS_NomCompleto", "Customer", "ECUS_NomCompleto");
            //grdItemsOV.Columns["ECUS_NomCompleto"].ReadOnly = true;
            this.grdItemsOV.Columns.Add("ETRA_NomCompleto", "Linea Naviera", "ETRA_NomCompleto");
            //grdItemsOV.Columns["ETRA_NomCompleto"].ReadOnly = true;
            this.grdItemsOV.Columns.Add("PUER_NombreOri", "Puerto Origen", "PUER_NombreOri");
            //grdItemsOV.Columns["PUER_NombreOri"].ReadOnly = true;
            this.grdItemsOV.Columns.Add("PUER_NombreDes", "Puerto Destino", "PUER_NombreDes");
            //grdItemsOV.Columns["PUER_NombreDes"].ReadOnly = true;
            this.grdItemsOV.Columns.Add("PUER_CodEstandarOri", "Puerto Origen", "PUER_CodEstandarOri");
            grdItemsOV.Columns["PUER_CodEstandarOri"].IsVisible = false;
            this.grdItemsOV.Columns.Add("PUER_CodEstandarDeS", "Puerto Destino", "PUER_CodEstandarDeS");
            grdItemsOV.Columns["PUER_CodEstandarDeS"].IsVisible = false;
            #endregion

            tsmColumnas.DropDownItems.Clear();
            defaultColumns = new string[grdItemsOV.Columns.Count];
            int index = 0;
            foreach (Telerik.WinControls.UI.GridViewDataColumn column in grdItemsOV.Columns)
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
            Infrastructure.WinForms.Controls.GridAutoFit.Fit2(grdItemsOV);

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
               if (BSItems != null && BSItems.DataSource != null && BSItems.Current != null)//&& BSItems.Current is Entities.Cab_Cotizacion_OV
               {
                  DataRowView current = (DataRowView)BSItems.Current;
                  if (current["LOAD_Codigo"] != System.DBNull.Value)
                  { Presenter._load_codigo = Convert.ToInt32(current["LOAD_Codigo"]); }
                  else
                  { Presenter._load_codigo = null; }
                  if (current["LOAD_SegundoOK"] != System.DBNull.Value)
                  { Presenter._con_prealerta = Convert.ToBoolean(current["LOAD_SegundoOK"]); }
                  else
                  { Presenter._con_prealerta = false; }
                  if (current["CCOT_Codigo"] != System.DBNull.Value)
                  { Presenter._ccot_codigo = Convert.ToInt32(current["CCOT_Codigo"]); }
                  else
                  { Presenter._ccot_codigo = null; }
                  if (current["CCOT_Tipo"] != System.DBNull.Value)
                  { Presenter._ccot_tipo = Convert.ToInt16(current["CCOT_Tipo"]); }
                  else
                  { Presenter._ccot_tipo = null; }
                  if (current["CCOT_Estado"] != System.DBNull.Value)
                  { Presenter._ccot_estado = Convert.ToString(current["CCOT_Estado"]); }
                  else
                  { Presenter._ccot_estado = String.Empty; }
                  //Presenter._ccot_codigo = Convert.ToInt32(current["CCOT_Codigo"]);
               }
               else
               {
                  Presenter._con_prealerta = null;
                  Presenter._load_codigo = null;
               }
            }
            else
            {

            }
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al seleccionar el item.", ex); }
      }
      private void Buscar()
      {
         try
         {
            if (tabServiciosAdicionales.SelectedTab == pageControlDocumentos)
            {
               String _mensaje = "";
               if (!String.IsNullOrEmpty(txtLOAD_HBL.Text) || !String.IsNullOrEmpty(txtLOAD_MBL.Text) || !String.IsNullOrEmpty(txtCCOT_NumDoc.Text) || mdtLOAD_FecPrimerOKInicio.NSFecha != null || mdtLOAD_FecPrimerOKFin.NSFecha != null)
               {
                  Presenter.FILTROItemRegimen = cmbCONS_CodRGM.ConstantesSelectedItem;
                  Presenter.FILTROItemVia = cmbCONS_CodVia.ConstantesSelectedItem;
                  if (txtENTC_CodTransportista.Value != null)
                  { Presenter.FILTROItemTransportista = txtENTC_CodTransportista.Value; }
                  else
                  { Presenter.FILTROItemTransportista = null; }
                  if (ayudaPuertoOrigen.SelectedItem != null)
                  { Presenter.FILTROItemPuerto = ayudaPuertoOrigen.SelectedItem.PUER_Codigo; }
                  else
                  { Presenter.FILTROItemPuerto = null; }
                  Presenter.FILTROItemHBL = null;
                  if (!String.IsNullOrEmpty(txtLOAD_HBL.Text))
                  { Presenter.FILTROItemHBL = txtLOAD_HBL.Text; }
                  Presenter.FILTROItemMBL = null;
                  if (!String.IsNullOrEmpty(txtLOAD_MBL.Text))
                  { Presenter.FILTROItemMBL = txtLOAD_MBL.Text; }
                  Presenter.FILTROItemOV = null;
                  if (!String.IsNullOrEmpty(txtCCOT_NumDoc.Text))
                  { Presenter.FILTROItemOV = txtCCOT_NumDoc.Text; }
                  Presenter.FILTROItemConPreAlerta = rbtnLOAD_SegundoOKCon.Checked;
                  Presenter.FILTROItemSinPreAlerta = rbtnLOAD_SegundoOKSin.Checked;
                  Presenter.FILTROItemFecPrimerOKIni = mdtLOAD_FecPrimerOKInicio.NSFecha;
                  Presenter.FILTROItemFecPrimerOKFin = mdtLOAD_FecPrimerOKFin.NSFecha;
                  //Presenter.FILTROItemCONSRGM = CONS_CodRGM.ConstantesSelectedItem;
                  //Presenter.FILTROItemCONSFLE = CONS_CodFLE.ConstantesSelectedItem;
                  Presenter.Actualizar();

               }
               else
               {
                  _mensaje += "* Nro. HBL" + Environment.NewLine;
                  _mensaje += "* Nro. MBL" + Environment.NewLine;
                  _mensaje += "* Nro. OV's" + Environment.NewLine;
                  _mensaje += "* Fecha de Recepción de Inicio" + Environment.NewLine;
                  _mensaje += "* Fecha de Recepción de Fin" + Environment.NewLine;
                  Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion("Filtros de Control de Documentos", "Debe ingresar un valor en cualquiera de las siguientes opciones: (Ver Detalles).", _mensaje);
               }
            }
            if (tabServiciosAdicionales.SelectedTab == pageOrdenVenta)
            {
               String _CONS_TabRGM = null;
               String _CONS_CodRGM = null;
               if (cmbCONS_CodRGM.ConstantesSelectedItem != null)
               {
                  _CONS_TabRGM = cmbCONS_CodRGM.ConstantesSelectedItem.CONS_CodTabla;
                  _CONS_CodRGM = cmbCONS_CodRGM.ConstantesSelectedItem.CONS_CodTipo;
               }
               Presenter.ActualizarOVs(_CONS_TabRGM, _CONS_CodRGM);
            }


         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al buscar.", ex); }
      }
      private void Exportar()
      {
         try
         {
            if (tabServiciosAdicionales.SelectedTab == pageControlDocumentos)
            {
               List<String> Titulos = new List<String>();
               Titulos.Add(Presenter.Title);
               Int32 _fila = 2;
               Infrastructure.WinForms.Controls.ExcelAportes _xls = new Infrastructure.WinForms.Controls.ExcelAportes(1, Titulos, "");
               Object[] _cabeceras = new Object[1];
               DataTable _dt = _xls.RadGridViewToDataTable(grdItems, ref _cabeceras, grdItems.FilterDescriptors.Count > 0);
               /*****************************************/
               if (_dt.Columns["Files"] != null)
               { _dt.Columns.Remove("Files"); }
               if (_dt.Columns["LOAD_SegundoOK"] != null)
               { _dt.Columns.Remove("LOAD_SegundoOK"); }
               if (_dt.Columns["LOAD_EnvioCorreo"] != null)
               { _dt.Columns.Remove("LOAD_EnvioCorreo"); }
               _cabeceras = new Object[_dt.Columns.Count];
               for (int i = 0; i < _dt.Columns.Count; i++)
               {
                  _cabeceras[i] = _dt.Columns[i].Caption;
               }

               /*******************************************/
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
            else
            {
               if (tabServiciosAdicionales.SelectedTab == pageOrdenVenta)
               {
                  List<String> Titulos = new List<String>();
                  Titulos.Add("Reporte");
                  Int32 _fila = 2;
                  Infrastructure.WinForms.Controls.ExcelAportes _xls = new Infrastructure.WinForms.Controls.ExcelAportes(1, Titulos, "");
                  Object[] _cabeceras = new Object[1];
                  DataTable _dt = _xls.RadGridViewToDataTable(grdItemsOV, ref _cabeceras, grdItemsOV.FilterDescriptors.Count > 0);
                  if (_dt.Rows.Count > 0)
                  {
                     List<String> _listTituloFiltro = new List<String>();
                     _listTituloFiltro.Add("");
                     _xls.InsertarTitulos(Presenter.Title, 1, ref _fila, 1, _listTituloFiltro, _cabeceras.Length);
                     _xls.addDataArray(1, _cabeceras, 1, _fila + 2, true, true);
                     _xls.addDataList(1, _dt, 1, _fila + 3, true, true);
                  }
               }
            }

         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al exportar.", ex); }
      }
      private void Deshacer()
      {
         try
         {
            /// CRITERIOS DE BUSQUEDA
            rbtnLOAD_SegundoOKCon.Checked = false;
            rbtnLOAD_SegundoOKSin.Checked = true;
            txtENTC_CodTransportista.Clear();
            cmbCONS_CodRGM.SelectedIndex = 0;
            cmbCONS_CodVia.SelectedIndex = 0;
            txtLOAD_HBL.Text = string.Empty;
            txtLOAD_MBL.Text = string.Empty;
            txtCCOT_NumDoc.Text = string.Empty;
            ayudaPuertoOrigen.SelectedValue = null;
            mdtLOAD_FecPrimerOKInicio.NSFecha = null;
            mdtLOAD_FecPrimerOKFin.NSFecha = null;

            /// DATOS PÁRA EL CONTROL DE DOCUMENTOS
            txtLOAD_Observaciones.Text = string.Empty;
            //mdtLOAD_FecSegundoOK.NSFecha = null;
            //mtdLOAD_FecDevolucion.NSFecha = null;
            txtLOAD_SegundoUsuario.Text = string.Empty;

            /// GRILLA
            BSItems.DataSource = null;
            grdItems.DataSource = BSItems;
            grdItems.Enabled = false;
            navItems.BindingSource = BSItems;
            BSItems.ResetBindings(true);

            BSItemsOV.DataSource = null;
            grdItemsOV.DataSource = BSItemsOV;
            grdItemsOV.Enabled = false;
            navItemsOV.BindingSource = BSItemsOV;
            BSItemsOV.ResetBindings(true);

            ///BOTONES
            btnCorreo.Enabled = false;
            btnBuscar.Enabled = true;
            btnExportar.Enabled = false;
            btn_ActualizarPreAlerta.Enabled = false;
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al deshacer la vista.", ex); }
      }
      private bool ActualizaPreAlerta()
      {
         Boolean _iscorrect = false;
         try
         {

            //if (mtdLOAD_FecDevolucion.NSFecha == null)
            //{
            //    Dialogos.MostrarMensajeInformacion(Presenter.Title, "Debe seleccionar un Fecha de Devolución");
            //}
            //else
            //{
            DateTime _fecHoy = DateTime.Today;
            DataTable _dt = new DataTable("PreAlerta");
            //_dt.Columns.Add("CCOT_Codigo", typeof(Int32));
            _dt.Columns.Add("LOAD_Codigo", typeof(Int32));
            _dt.Columns.Add("LOAD_ObserSegundoOk", typeof(String));
            _dt.Columns.Add("LOAD_FecSegundoOK", typeof(DateTime));
            _dt.Columns.Add("LOAD_FecDevolucion", typeof(DateTime));
            _dt.Columns.Add("LOAD_SegundoUsuario", typeof(String));
            _dt.Columns.Add("LOAD_SegundoOK", typeof(Boolean));

            //#####*** EVENTOS ***#####
            DtOVs = new DataTable("Eventos");
            DtOVs.Columns.Add("CCOT_Numero", typeof(Int32));
            DtOVs.Columns.Add("CCOT_Tipo", typeof(Int32));
            //#########################
            for (int i = 0; i < this.grdItems.RowCount; i++)
            {
               if (grdItems.Rows[i].Cells["LOAD_SegundoOK"].Value != System.DBNull.Value)
               {
                  if (Convert.ToBoolean(grdItems.Rows[i].Cells["LOAD_SegundoOK"].Value))
                  {
                     DateTime _fechoy = DateTime.Today;
                     DataRow _dr = _dt.NewRow();
                     //_dr["CCOT_Codigo"] = ;
                     _dr["LOAD_Codigo"] = grdItems.Rows[i].Cells["LOAD_Codigo"].Value;
                     _dr["LOAD_ObserSegundoOk"] = txtLOAD_Observaciones.Text;
                     _dr["LOAD_FecSegundoOK"] = mdtLOAD_FecSegundoOK.NSFecha;
                     _dr["LOAD_FecDevolucion"] = _fechoy.ToString("d");
                     _dr["LOAD_SegundoUsuario"] = txtLOAD_SegundoUsuario.Text; //Presenter.Session.UserName;
                     _dr["LOAD_SegundoOK"] = grdItems.Rows[i].Cells["LOAD_SegundoOK"].Value;
                     _dt.Rows.Add(_dr);

                     //#####*** EVENTOS ***#####
                     if (grdItems.Rows[i].Cells["CCOT_Codigo"].Value != System.DBNull.Value)
                     {
                        DataRow _drov = DtOVs.NewRow();
                        _drov["CCOT_Numero"] = grdItems.Rows[i].Cells["CCOT_Codigo"].Value;
                        _drov["CCOT_Tipo"] = grdItems.Rows[i].Cells["CCOT_Tipo"].Value;
                        DtOVs.Rows.Add(_drov);
                     }
                     //#########################
                  }
               }
            }
            if (_dt.Rows.Count > 0)
            {
               if (Presenter.ActualizarPreAlerta(_dt))
               {
                  Dialogos.MostrarMensajeSatisfactorio(Presenter.Title, "Se realizó la actualización satisfactoriamente");
               }
               Presenter.Actualizar(false);
               //Deshacer();
               _iscorrect = true;
               return _iscorrect;
            }
            else
            {
               Dialogos.MostrarMensajeInformacion(Presenter.Title, "Usted no seleccionó un items");
               return _iscorrect;
            }
            //}
         }
         catch (Exception ex)
         { Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido una error al durante el proceso del Pre_Alerta", ex); return _iscorrect; }
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
      public StringBuilder CreateHeader(ref StringBuilder _table)
      {
         _table.Append("<table border=1 cellpadding=4 cellspacing=0 style=font-size:10px >");
         _table.Append("<tr><th> POL </th><th> M/V </th><th> ETD </th><th> CARRIER </th><th> BOOKING NO. </th><th> HB/L </th><th> CNTR </th><th> SHIPPER </th><th> CONSIGNEE </th></tr>");
         return _table;
      }
      private void Correo()
      {
         try
         {

            ObservableCollection<Entities.LoadingList> ItemsCorreo = new ObservableCollection<Entities.LoadingList>();
            Delfin.Controls.EnviarCorreo ec = new Controls.EnviarCorreo();
            string body = null;
            string recipient = null;
            string olCCrecipient = null;
            string subject = null;
            string _CodPOL_Actual = "POL";
            StringBuilder tb = new StringBuilder();
            Boolean enviar = false;
            Object _PUER_Origen = string.Empty;
            Object _PUER_Destino = string.Empty;
            for (int i = 0; i < this.grdItems.RowCount; i++)
            {
               if (grdItems.Rows[i].Cells["LOAD_EnvioCorreo"].Value != System.DBNull.Value)
               {
                  string expression = "LOAD_Codigo = " + Convert.ToInt32(grdItems.Rows[i].Cells["LOAD_Codigo"].Value);
                  DataRow[] results = Presenter._ControlDocumentosCopia.Select(expression);
                  Boolean correo = false;
                  if (results[0]["LOAD_EnvioCorreo"] != System.DBNull.Value)
                  { correo = Convert.ToBoolean(results[0]["LOAD_EnvioCorreo"]); }

                  if (Convert.ToBoolean(grdItems.Rows[i].Cells["LOAD_EnvioCorreo"].Value) && !correo)
                  {
                     if (_CodPOL_Actual == "POL")
                     {
                        CreateHeader(ref tb);
                        _PUER_Origen = grdItems.Rows[i].Cells["PUER_NombreLOADOri"].Value;
                        _PUER_Destino = grdItems.Rows[i].Cells["PUER_NombreLOADDes"].Value;
                     }

                     if (Convert.ToString(grdItems.Rows[i].Cells["PUER_CodEstLOADOri"].Value) == _CodPOL_Actual || _CodPOL_Actual == "POL")
                     {
                        _CodPOL_Actual = Convert.ToString(grdItems.Rows[i].Cells["PUER_CodEstLOADOri"].Value);

                        //#####################################################################################
                        tb.Append("<tr>");
                        tb.Append("<td>" + grdItems.Rows[i].Cells["PUER_NombreLOADOri"].Value + "</td>");
                        tb.Append("<td>" + grdItems.Rows[i].Cells["LOAD_NaveViaje"].Value + "</td>");
                        tb.Append("<td>" + grdItems.Rows[i].Cells["LOAD_ETD"].Value + "</td>");
                        tb.Append("<td>" + grdItems.Rows[i].Cells["LOAD_Carrier"].Value + "</td>");
                        tb.Append("<td>" + grdItems.Rows[i].Cells["LOAD_Booking"].Value + "</td>");
                        tb.Append("<td>" + grdItems.Rows[i].Cells["LOAD_HBL"].Value + "</td>");
                        tb.Append("<td>" + grdItems.Rows[i].Cells["CNTR_Numero"].Value + "</td>");
                        tb.Append("<td>" + grdItems.Rows[i].Cells["LOAD_Shipper"].Value + "</td>");
                        tb.Append("<td>" + grdItems.Rows[i].Cells["LOAD_Consignee"].Value + "</td>");
                        tb.Append("</tr>");
                        //#####################################################################################

                     }
                     else
                     {
                        //########################################################################################################

                        tb.Append("</table>");
                        tb.Append("<font color= #2f5496>");
                        tb.Append("<h4>Dear all : </h4>");
                        tb.Append("<p>We have received the loading of this week and we don´t have these pre alerts , please kindly send us these documents.</p>");
                        tb.Append("<p>Regards.</p>");
                        tb.Append("</font>");
                        body = tb.ToString();
                        recipient = "<Ingrese un correo electronico>";
                        olCCrecipient = BuscarCorreo("CORREO_DOCUMENTACION");
                        subject = "DOCUMENTS REQUESTS POD" + " - " + _PUER_Destino + " FROM: " + _PUER_Origen;
                        ec.enviaCorreo(enviar, recipient, olCCrecipient, subject, body);

                        //########################################################################################################

                        _CodPOL_Actual = Convert.ToString(grdItems.Rows[i].Cells["PUER_CodEstLOADOri"].Value);
                        tb = new StringBuilder();
                        CreateHeader(ref tb);
                        _PUER_Origen = grdItems.Rows[i].Cells["PUER_NombreLOADOri"].Value;
                        _PUER_Destino = grdItems.Rows[i].Cells["PUER_NombreLOADDes"].Value;
                        tb.Append("<tr>");
                        tb.Append("<td>" + grdItems.Rows[i].Cells["PUER_NombreLOADOri"].Value + "</td>");
                        tb.Append("<td>" + grdItems.Rows[i].Cells["LOAD_NaveViaje"].Value + "</td>");
                        tb.Append("<td>" + grdItems.Rows[i].Cells["LOAD_ETD"].Value + "</td>");
                        tb.Append("<td>" + grdItems.Rows[i].Cells["LOAD_Carrier"].Value + "</td>");
                        tb.Append("<td>" + grdItems.Rows[i].Cells["LOAD_Booking"].Value + "</td>");
                        tb.Append("<td>" + grdItems.Rows[i].Cells["LOAD_HBL"].Value + "</td>");
                        tb.Append("<td>" + grdItems.Rows[i].Cells["CNTR_Numero"].Value + "</td>");
                        tb.Append("<td>" + grdItems.Rows[i].Cells["LOAD_Shipper"].Value + "</td>");
                        tb.Append("<td>" + grdItems.Rows[i].Cells["LOAD_Consignee"].Value + "</td>");
                        tb.Append("</tr>");

                        //########################################################################################################
                     }

                     //###########################################################################################
                     ItemsCorreo.Add(new Entities.LoadingList
                     {
                        LOAD_EnvioCorreo = Convert.ToBoolean(grdItems.Rows[i].Cells["LOAD_EnvioCorreo"].Value)
                      ,
                        LOAD_EnvioCorreoUsuario = Presenter.Session.UserName
                      ,
                        LOAD_Codigo = Convert.ToInt32(grdItems.Rows[i].Cells["LOAD_Codigo"].Value)
                     });
                     //###########################################################################################

                  }
               }
            }
            if (ItemsCorreo.Count() != 0)
            {
               //###############################################################################################
               tb.Append("</table>");
               tb.Append("<font color= #2f5496>");
               tb.Append("<h4>Dear all : </h4>");
               tb.Append("<p>We have received the loading of this week and we don´t have these pre alerts , please kindly send us these documents.</p>");
               tb.Append("<p>Regards.</p>");
               tb.Append("</font>");
               body = tb.ToString();
               recipient = "<Ingrese un correo electronico>";
               olCCrecipient = BuscarCorreo("CORREO_DOCUMENTACION");
               subject = "DOCUMENTS REQUESTS POD" + " - " + _PUER_Destino + " FROM: " + _PUER_Origen;
               ec.enviaCorreo(enviar, recipient, olCCrecipient, subject, body);
               //###############################################################################################
               Presenter.EnviarCorreo(ItemsCorreo);
               Presenter.Actualizar();
            }
            else
            {
               Dialogos.MostrarMensajeInformacion(Presenter.Title, "Usted no seleccionó un items nuevo");
            }
         }
         catch (Exception ex)
         { Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido una error al durante el envio del Corre", ex); }
      }
      private String BuscarCorreo(String _PARA_Clave)
      {
         String correo = string.Empty;
         ObservableCollection<Entities.Parametros> ParametrosCorreo = new ObservableCollection<Entities.Parametros>();
         Entities.Parametros ItemCorreo = new Entities.Parametros();
         ParametrosCorreo = Presenter.ItemsParametrosCorreo.Where(Trans => Trans.PARA_Clave == _PARA_Clave).ToObservableCollection();
         ItemCorreo = ParametrosCorreo[0];
         correo = ItemCorreo.PARA_Valor;
         return correo;
      }
      #endregion

      #region [ Eventos ]
      private void btnBuscar_Click(object sender, EventArgs e)
      { Buscar(); }
      private void btn_ActualizarPreAlerta_Click(object sender, EventArgs e)
      {
         if (ActualizaPreAlerta())
         {
            //#####*** EVENTOS ***#####
            if (Presenter.PARA_PREALERTA != null)
            {
               if (!string.IsNullOrEmpty(Presenter.PARA_PREALERTA.PARA_Valor))
               { Presenter.GenerarEventosTareas("Se ha aprobado la documentacion como completa (Pre-Alerta)", Presenter.PARA_PREALERTA.PARA_Valor, DtOVs); }
               else
               {
                  Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Presenter.Title, "No existe parametro de configuracion PREALERTA, valide sus parametros del sistema");
               }
            }
            else
            {
               Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Presenter.Title, "No existe parametro de configuracion PREALERTA, valide sus parametros del sistema");
            }
            //#########################
         }
      }
      private void btnExportar_Click(object sender, EventArgs e)
      { Exportar(); }
      private void btnDeshacer_Click(object sender, EventArgs e)
      { Deshacer(); }
      private void btnCorreo_Click(object sender, EventArgs e)
      { Correo(); }
      private void btnNuevo_Click(object sender, EventArgs e)
      { Nuevo(); }
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
                  case "Documentos":
                     SeleccionarItem();
                     Presenter.ShowsDocuments();
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
      //private void grdItems_SelectionChanging(object sender, CancelEventArgs e)
      //{
      //    SeleccionarItem();
      //    Presenter.Documents();
      //}
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
               if (e.Column.Name.Equals("Delete"))
               {
                  var bte = (RadButtonElement)e.CellElement.Children[0];
                  if (bte.Image == null)
                  {
                     bte.TextImageRelation = TextImageRelation.Overlay;
                     bte.DisplayStyle = DisplayStyle.Image;
                     bte.ImageAlignment = ContentAlignment.MiddleCenter;
                     bte.Image = Resources.Sign_07;
                     bte.ToolTipText = @"Eliminar Registro";
                     bte.AutoSize = true;
                  }
               }
               if (e.Column.Name.Equals("Files"))
               {
                  var bte = (RadButtonElement)e.CellElement.Children[0];
                  if (bte.Image == null)
                  {
                     bte.TextImageRelation = TextImageRelation.Overlay;
                     bte.DisplayStyle = DisplayStyle.Image;
                     bte.ImageAlignment = ContentAlignment.MiddleCenter;
                     bte.Image = Resources.document_check_16x16;
                     bte.ToolTipText = @"Ver Registro";
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
