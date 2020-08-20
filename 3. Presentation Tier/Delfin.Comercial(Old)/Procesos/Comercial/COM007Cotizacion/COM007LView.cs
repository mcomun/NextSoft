using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections.ObjectModel;
using Delfin.Comercial.Properties;
using Infrastructure.Aspect.Collections;
using Infrastructure.WinForms.Controls;
using Telerik.WinControls;
using Telerik.WinControls.UI;

namespace Delfin.Comercial
{
   public partial class COM007LView : UserControl, ICOM007LView
   {
      #region [ Variables ]
      //private String m_sortColumnName;
      //private Boolean m_sortAscending = false;
      #endregion

      #region [ Formulario ]
      public COM007LView(Telerik.WinControls.UI.RadPageViewPage x_tabPageControl)
      {
         InitializeComponent();
         try
         {
            TabPageControl = x_tabPageControl;

            btnNuevo.Click += new EventHandler(btnNuevo_Click);
            btnBuscar.Click += new EventHandler(btnBuscar_Click);
            btnVersionar.Click += new EventHandler(btnVersionar_Click);
            btnCopiar.Click += new EventHandler(btnCopiar_Click);
            btnPresupuestar.Click += new EventHandler(btnPresupuestar_Click);
            btnCoordinar.Click += new EventHandler(btnCoordinar_Click);
            btnConfirmar.Click += new EventHandler(btnConfirmar_Click);
            btnGenerarOV.Click += new EventHandler(btnGenerarOV_Click);
            btnConcluir.Click += btnConcluir_Click;
            btnImprimir.Click += new EventHandler(btnImprimir_Click);
            btnAnular.Click += new EventHandler(btnAnular_Click);
            btnExportar.Click += new EventHandler(btnExportar_Click);
            btnDeshacer.Click += new EventHandler(btnDeshacer_Click);

            BSItems = new BindingSource();
            BSItems.CurrentItemChanged += new EventHandler(BSItems_CurrentItemChanged);

            grdItems.CommandCellClick += new Telerik.WinControls.UI.CommandCellClickEventHandler(grdItems_CommandCellClick);
            grdItems.CellFormatting += grdItemLViews_CellFormatting;
            TitleView.FormClose += new EventHandler(TitleView_FormClose);
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error inicializando el formulario LView.", ex); }
      }
      #endregion

      #region [ Propiedades ]
      public Telerik.WinControls.UI.RadPageViewPage TabPageControl { get; set; }
      public Image IconView { get { return TitleView.FormIcon; } set { TitleView.FormIcon = value; } }
      public COM007Presenter Presenter { get; set; }
      public BindingSource BSItems { get; set; }
      #endregion

      #region [ ICOM007LView ]
      public void LoadView(Int16 CCOT_Tipo)
      {
         try
         {
            ENTC_CodEjecutivo.ContainerService = Presenter.ContainerService;
            ENTC_CodCustomer.ContainerService = Presenter.ContainerService;
            ENTC_CodAgente.ContainerService = Presenter.ContainerService;
            ENTC_CodBroker.ContainerService = Presenter.ContainerService;
            ENTC_CodCliente.ContainerService = Presenter.ContainerService;
            

            if (CCOT_Tipo == Delfin.Controls.variables.CCOT_TipoCotizacion)
            {
               this.Text = "Comercial - Cotizaciones";
               this.TitleView.Caption = "COMERCIAL - COTIZACIONES";

               btnVersionar.Visible = true;
               btnPresupuestar.Visible = false;
               btnGenerarOV.Visible = true;
               
               btnConfirmar.Visible = true;
               btnConfirmar.Text = "Autorizar";
               btnAnular.Visible = true;

               btnCoordinar.Visible = false;
               btnConcluir.Visible = false;
               btnCopiar.Visible = false;

               CONS_CodEST.LoadControl(Presenter.ContainerService, "Estado Cotización", "COT", "< Todos >", ListSortDirection.Ascending);

               lblDOOV_HBL.Visible = false;
               DOOV_HBL.Visible = false;
                lblCCOT_NumPresupuesto.Visible = true;
                CCOT_NumPresupuesto.Visible = true;
            }
            else
            { 
               this.Text = "Comercial - Órdenes de Venta";
               this.TitleView.Caption = "COMERCIAL - ÓRDENES DE VENTA";

               btnVersionar.Visible = false;
               btnPresupuestar.Visible = false;
               btnGenerarOV.Visible = false;

               btnCoordinar.Visible = true;
               btnConfirmar.Visible = true;
               btnConfirmar.Text = "Confirmar";
               btnConcluir.Visible = true;
               btnAnular.Visible = true;
               btnCopiar.Visible = true;


               CONS_CodEST.LoadControl(Presenter.ContainerService, "Estado Orden de Venta", "OVE", "< Todos >", ListSortDirection.Ascending);

               lblDOOV_HBL.Visible = true;
               DOOV_HBL.Visible = true;
               lblCCOT_NumPresupuesto.Visible = false;
               CCOT_NumPresupuesto.Visible = false;
            }

            BSItems.DataSource = null;
            grdItems.DataSource = BSItems;
            navItems.BindingSource = BSItems;
            BSItems.ResetBindings(true);

            CONS_CodRGM.LoadControl(Presenter.ContainerService, "Régimen", "RGM", "< Todos >", ListSortDirection.Ascending);
            CONS_CodFLE.LoadControl(Presenter.ContainerService, "Condición de Flete", "FLE", "< Todos >", ListSortDirection.Ascending);
            CONS_CodVia.LoadControl(Presenter.ContainerService, "Tipos Vía", "VIA", "< Todos >", ListSortDirection.Ascending);
            
            ENTC_CodEjecutivo.TipoEntidad = Delfin.Controls.TiposEntidad.TIPE_Ejecutivo;
            ENTC_CodCustomer.TipoEntidad = Delfin.Controls.TiposEntidad.TIPE_Customer;
            ENTC_CodAgente.TipoEntidad = Delfin.Controls.TiposEntidad.TIPE_Agente;
            ENTC_CodBroker.TipoEntidad = Delfin.Controls.TiposEntidad.TIPE_Broker;
            ENTC_CodCliente.TipoEntidad = Delfin.Controls.TiposEntidad.TIPE_Cliente;

            CCOT_FecDesde.NSFecha = Presenter.Session.Fecha.AddDays(-7);
            CCOT_FecHasta.NSFecha = Presenter.Session.Fecha;

            FormatDataGrid();

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
            grdItems.EnableFiltering = true;
            grdItems.MasterTemplate.EnableFiltering = true;
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
            //this.grdItemLViews.Columns.Add(commandColumn);
            //this.grdItemLViews.Columns["Delete"].AllowSort = false;
            //this.grdItemLViews.Columns["Delete"].AllowFiltering = false;

            this.grdItems.Columns.Add("CONS_DescEST", "Estado", "CONS_DescEST");
            if (Presenter.CCOT_Tipo == Delfin.Controls.variables.CCOT_TipoCotizacion)
            { 
               this.grdItems.Columns.Add("CCOT_NumDocVersion", "Número/Versión Cotización", "CCOT_NumDocVersion"); 
            }
            else if (Presenter.CCOT_Tipo == Delfin.Controls.variables.CCOT_TipoOrdenVenta)
            {
               this.grdItems.Columns.Add("CCOT_NumDoc", "Número Orden Venta", "CCOT_NumDoc");
               this.grdItems.Columns.Add("CCOT_NumDocCOT", "Número/Versión Cotización", "CCOT_NumDocCOT");
               this.grdItems.Columns.Add("DOOV_HBL", "BL Hijo", "DOOV_HBL");
            }
            
            this.grdItems.Columns.Add("CCOT_NumPresupuesto", "No. CRM", "CCOT_NumPresupuesto");
            this.grdItems.Columns.Add("CCOT_FecEmi", "Fecha Emisión", "CCOT_FecEmi");
            this.grdItems.Columns.Add("ENTC_NomCliente", "Cliente", "ENTC_NomCliente");
            this.grdItems.Columns.Add("CONS_DescRGM", "Régimen", "CONS_DescRGM");
            this.grdItems.Columns.Add("CONS_DescVia", "Tipo Vía", "CONS_DescVia");
            this.grdItems.Columns.Add("CONS_DescFLE", "Condición Embarque", "CONS_DescFLE");
            this.grdItems.Columns.Add("ENTC_NomEjecutivo", "Ejecutivo Ventas", "ENTC_NomEjecutivo");
            

            //número de cotización (resultado de concatenar con guiones la sigla de la empresa, el año de la cotización, el número de cotización y el número de la última versión)
            //número de presupuesto siempre y cuando la cotización forme parte de un presupuesto
            //fecha de emisión
            //la razón social del cliente/prospecto
            //régimen
            //tipo de vía
            //condición de embarque
            //ejecutivo de ventas
            //estado.

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
            grdItems.EnableFiltering = true;
            grdItems.MasterTemplate.EnableFiltering = true;
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
               {
                  Presenter.ItemLView = ((Entities.Cab_Cotizacion_OV)BSItems.Current);

                  if (Presenter.ItemLView.CCOT_Tipo == Delfin.Controls.variables.CCOT_TipoCotizacion)
                  {
                      //antes btnVersionar.Enabled = (Presenter.ItemLView.CONS_CodEST == Delfin.Controls.variables.CONS_ESTCOTINGRESADA || Presenter.ItemLView.CONS_CodEST == Delfin.Controls.variables.CONS_ESTCOTAUTORIZADA);
                      //mod 07/07/2015 por CJ
                      //revisado 13/07/2015 por JL.....
                      //revisado 2 13/07/2015 por JL.....
                      btnVersionar.Enabled = (Presenter.ItemLView.CONS_CodEST == Delfin.Controls.variables.CONS_ESTCOTINGRESADA || Presenter.ItemLView.CONS_CodEST == Delfin.Controls.variables.CONS_ESTCOTAUTORIZADA || Presenter.ItemLView.CONS_CodEST == Delfin.Controls.variables.CONS_ESTCOTCONFIRMADA);

                      
                     btnPresupuestar.Enabled = (Presenter.ItemLView.CONS_CodEST == Delfin.Controls.variables.CONS_ESTCOTINGRESADA || Presenter.ItemLView.CONS_CodEST == Delfin.Controls.variables.CONS_ESTCOTAUTORIZADA);
                     btnConfirmar.Enabled = (Presenter.ItemLView.CONS_CodEST == Delfin.Controls.variables.CONS_ESTCOTINGRESADA);
                     btnGenerarOV.Enabled = (Presenter.ItemLView.CONS_CodEST == Delfin.Controls.variables.CONS_ESTCOTAUTORIZADA);
                     btnActualizarCRM.Enabled = (Presenter.ItemLView.CONS_CodEST == Delfin.Controls.variables.CONS_ESTCOTAUTORIZADA || Presenter.ItemLView.CONS_CodEST == Delfin.Controls.variables.CONS_ESTCOTCONFIRMADA);
                     btnAnular.Enabled = (Presenter.ItemLView.CONS_CodEST == Delfin.Controls.variables.CONS_ESTCOTINGRESADA || Presenter.ItemLView.CONS_CodEST == Delfin.Controls.variables.CONS_ESTCOTAUTORIZADA); ;
                     btnImprimir.Enabled = (Presenter.ItemLView.CONS_CodEST == Delfin.Controls.variables.CONS_ESTCOTAUTORIZADA || Presenter.ItemLView.CONS_CodEST == Delfin.Controls.variables.CONS_ESTCOTCONFIRMADA); ; ;
                  }
                  else if (Presenter.ItemLView.CCOT_Tipo == Delfin.Controls.variables.CCOT_TipoOrdenVenta)
                  {
                     btnCoordinar.Enabled = (Presenter.ItemLView.CONS_CodEST == Delfin.Controls.variables.CONS_ESTOVEINGRESADA);
                     btnConfirmar.Enabled = (Presenter.ItemLView.CONS_CodEST == Delfin.Controls.variables.CONS_ESTOVECOORDINADA);
                     btnConcluir.Enabled = (Presenter.ItemLView.CONS_CodEST == Delfin.Controls.variables.CONS_ESTOVEINGRESADA || Presenter.ItemLView.CONS_CodEST == Delfin.Controls.variables.CONS_ESTOVECOORDINADA || Presenter.ItemLView.CONS_CodEST == Delfin.Controls.variables.CONS_ESTOVECONFIRMADA);
                     btnAnular.Enabled = (Presenter.ItemLView.CONS_CodEST == Delfin.Controls.variables.CONS_ESTOVEINGRESADA || Presenter.ItemLView.CONS_CodEST == Delfin.Controls.variables.CONS_ESTOVECOORDINADA);
                     btnImprimir.Enabled = true;
                     btnCopiar.Enabled = true;
                  }
               }
               else
               {
                  Presenter.ItemLView = null;

                  btnVersionar.Enabled = false;
                  btnPresupuestar.Enabled = false;
                  btnGenerarOV.Enabled = false;
                  btnActualizarCRM.Enabled = false;
                  btnCoordinar.Enabled = false;
                  btnConfirmar.Enabled = false;
                  btnConcluir.Enabled = false;
                  btnAnular.Enabled = false;
                  btnImprimir.Enabled = false;
                  btnCopiar.Enabled = false;
               }
            }
            else
            {
               btnVersionar.Enabled = false;
               btnPresupuestar.Enabled = false;
               btnGenerarOV.Enabled = false;
               btnActualizarCRM.Enabled = false;
               btnCoordinar.Enabled = false;
               btnConfirmar.Enabled = false;
               btnConcluir.Enabled = false;
               btnAnular.Enabled = false;
               btnImprimir.Enabled = false;
               btnCopiar.Enabled = false;
            }
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al seleccionar el item.", ex); }
      }

      private void Nuevo()
      {
         try
         {
            Presenter.FILTROItemCONSRGM = CONS_CodRGM.ConstantesSelectedItem;
            Presenter.FILTROItemCONSFLE = CONS_CodFLE.ConstantesSelectedItem;
            Presenter.FILTROItemCONSVia = CONS_CodVia.ConstantesSelectedItem;
            Presenter.FILTROItemCONSEST = CONS_CodEST.ConstantesSelectedItem;
            Presenter.FILTROItemEjecutivo = ENTC_CodEjecutivo.Value;
            Presenter.FILTROItemCustomer = ENTC_CodCustomer.Value;
            Presenter.FILTROItemAgente = ENTC_CodAgente.Value;
            Presenter.FILTROItemBroker = ENTC_CodBroker.Value;
            Presenter.FILTROItemCliente = ENTC_CodCliente.Value;
            Presenter.FILTROCCOT_FecEmiDesde = CCOT_FecDesde.NSFecha;
            Presenter.FILTROCCOT_FecEmiHasta = CCOT_FecHasta.NSFecha;

            Presenter.Nuevo();
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al hacer nuevo.", ex); }
      }
      private void Buscar()
      {
         try
         {
            Presenter.FILTROItemCONSRGM = CONS_CodRGM.ConstantesSelectedItem;
            Presenter.FILTROItemCONSFLE = CONS_CodFLE.ConstantesSelectedItem;
            Presenter.FILTROItemCONSVia = CONS_CodVia.ConstantesSelectedItem;
            Presenter.FILTROItemCONSEST = CONS_CodEST.ConstantesSelectedItem;
            Presenter.FILTROItemEjecutivo = ENTC_CodEjecutivo.Value;
            Presenter.FILTROItemCustomer = ENTC_CodCustomer.Value;
            Presenter.FILTROItemAgente = ENTC_CodAgente.Value;
            Presenter.FILTROItemBroker = ENTC_CodBroker.Value;
            Presenter.FILTROItemCliente = ENTC_CodCliente.Value;
            Presenter.FILTROCCOT_FecEmiDesde = CCOT_FecDesde.NSFecha;
            Presenter.FILTROCCOT_FecEmiHasta = CCOT_FecHasta.NSFecha;
            Presenter.FILTROCCOT_NumDoc = CCOT_NumDoc.Text;
            Presenter.FILTRODOOV_HBL = DOOV_HBL.Text;
            Presenter.FILTRONoCRM = null;
            if (CCOT_NumPresupuesto.Text != "")
            { Presenter.FILTRONoCRM =  Convert.ToDecimal(CCOT_NumPresupuesto.Text); }
                       
            Presenter.Actualizar();
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
      private void btnVersionar_Click(object sender, EventArgs e)
      {
         SeleccionarItem();
         Presenter.Versionar(); 
      }
      private void btnCopiar_Click(object sender, EventArgs e)
      {
          SeleccionarItem();
          Presenter.Copiar();
      }
      private void btnPresupuestar_Click(object sender, EventArgs e)
      {
         SeleccionarItem();
         Presenter.Presupuestar();
      }
      private void btnCoordinar_Click(object sender, EventArgs e)
      {
         SeleccionarItem();
         Presenter.Coordinar();
      }
      private void btnConfirmar_Click(object sender, EventArgs e)
      {
         SeleccionarItem();
         Presenter.AutorizarConfirmar();
      }
      private void btnGenerarOV_Click(object sender, EventArgs e)
      {
         SeleccionarItem();
         Presenter.GenerarOV();
      }
      private void btnConcluir_Click(object sender, EventArgs e)
      {
         SeleccionarItem();
         Presenter.Concluir();
      }
      private void btnImprimir_Click(object sender, EventArgs e)
      {
         SeleccionarItem();
         Presenter.Imprimir();
      }
      private void btnAnular_Click(object sender, EventArgs e)
      {
         SeleccionarItem();
         Presenter.Anular();
      }
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


      void grdItemLViews_CellFormatting(object sender, CellFormattingEventArgs e)
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

      private void TitleView_Load(object sender, EventArgs e)
      {

      }

      private void btnActualizarCRM_Click(object sender, EventArgs e)
      {
          Presenter.ActualizarCRM();
      }
   }
}
