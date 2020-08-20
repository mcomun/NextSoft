using System;
using System.Collections.Generic;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using Telerik.WinControls.UI;
using Telerik.WinControls;
using Infrastructure.Client.Services.Session;
using Delfin.Entities;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using Delfin.Controls;
using Infrastructure.Aspect.BusinessEntity;
using Infrastructure.Aspect.Collections;
using Microsoft.Practices.Unity;
using Delfin.ServiceProxy;
using Delfin.Entities;
using Delfin.Logistico.Procesos.Facturacion;
using Infrastructure.Client.Services.Session;
using System.Collections.ObjectModel;
using Infrastructure.WinFormsControls;
using Infrastructure.Aspect.Constants;
using Microsoft.Reporting.WinForms;
using System.IO;
using System.Collections.Generic;
using System.Configuration;
using System.Collections;

namespace Delfin.Logistico
{
   public partial class PRO003LView : UserControl, IPRO003LView
   {
      #region [ Variables ]
             private PreDocsVta m_ItemPreDocsVta;
      #endregion

      #region [ Formulario ]
      public PRO003LView(Telerik.WinControls.UI.RadPageViewPage x_tabPageControl)
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
            BSItemsServicvios= new BindingSource();
            BSItems.CurrentItemChanged += new EventHandler(BSItems_CurrentItemChanged);
            grdItems.CommandCellClick += new Telerik.WinControls.UI.CommandCellClickEventHandler(grdItems_CommandCellClick);
            grdItems.CellFormatting += grdItems_CellFormatting;
            TitleView.FormClose += new EventHandler(TitleView_FormClose);
            
         }
         catch (Exception ex)
         { Infrastructure.WinFormsControls.Dialogos.MostrarMensajeError(Presenter.Title, Infrastructure.Aspect.Constants.Mensajes.ConstructorView, ex); }
      } 
      #endregion

      #region [ Propiedades ]
      public Telerik.WinControls.UI.RadPageViewPage TabPageControl { get; set; }
      public Image IconView { get { return TitleView.FormIcon; } set { TitleView.FormIcon = value; } }
      public PRO003Presenter Presenter { get; set; }
      public BindingSource BSItems { get; set; }
      public BindingSource BSItemsServicvios { set; get; }
      public ISessionService Session { get; set; }
      public PreDocsVta ItemPreDocsVta
      {
          get { return m_ItemPreDocsVta; }
          set { m_ItemPreDocsVta = value; }
      }
      #endregion

      #region [ IPRO003LView ]
      public void LoadView()
      {
         try
         {
            AyudaEntidadCliente.ContainerService = Presenter.ContainerService;

            BSItems.DataSource = null;
            grdItems.DataSource = BSItems;
            navItems.BindingSource = BSItems;
            BSItems.ResetBindings(true);

            AyudaEntidadCliente.TipoEntidad = Delfin.Controls.TiposEntidad.TIPE_Cliente;
            mdtFecDesde.NSFecha = Presenter.Session.Fecha;
            mdtFecHasta.NSFecha = Presenter.Session.Fecha;

            List<KeyValuePair<int, string>> itemsFiltros = new List<KeyValuePair<int, string>>();
            itemsFiltros.Add(new KeyValuePair<int, string>(0, "< todos >"));
            itemsFiltros.Add(new KeyValuePair<int, string>(1, "No Facturada"));
            itemsFiltros.Add(new KeyValuePair<int, string>(2, "Facturada Parcial"));
            itemsFiltros.Add(new KeyValuePair<int, string>(3, "Facturada Total"));
           

            CbSituacionFacturaProveedor.DataSource = new BindingSource(itemsFiltros, null);
            CbSituacionFacturaProveedor.DisplayMember = "Value";
            CbSituacionFacturaProveedor.ValueMember = "Key";

            CbSituacionFacturaCliente.DataSource = new BindingSource(itemsFiltros, null);
            CbSituacionFacturaCliente.DisplayMember = "Value";
            CbSituacionFacturaCliente.ValueMember = "Key";

            FormatDataGrid();
            FormatDataGridServicio ();
            grdItems.Enabled = false;
            btnNuevo.Enabled = true;
            btnBuscar.Enabled = true;
            btnExportar.Enabled = false;
            grdItemsServicios.Enabled = false;
         }
         catch (Exception ex)
         { Infrastructure.WinFormsControls.Dialogos.MostrarMensajeError(Presenter.Title, Infrastructure.Aspect.Constants.Mensajes.LoadView, ex); }
      }
      public void ShowItems()
      {
         try
         {
            BSItems.DataSource = Presenter.ItemsCab_Operacion;
            grdItems.DataSource = BSItems;
            navItems.BindingSource = BSItems;
            BSItems.ResetBindings(true);
            if (grdItems.RowCount > 0)
            {
               grdItems.Enabled = true;
               btnExportar.Enabled = true;
               Infrastructure.WinFormsControls.GridAutoFit.Fit(this.grdItems);
               grdItemsServicios.Enabled = true;
            }
            else
            {
               grdItems.Enabled = false;
               btnExportar.Enabled = false;
               BSItemsServicvios.DataSource = null;
               grdItemsServicios.DataSource = BSItemsServicvios;
               navItemsServicios.BindingSource = BSItemsServicvios;
               BSItemsServicvios.ResetBindings(true);
               grdItemsServicios.Enabled = false;
            }
         }
         catch (Exception ex)
         { Infrastructure.WinFormsControls.Dialogos.MostrarMensajeError(Presenter.Title, Infrastructure.Aspect.Constants.Mensajes.ShowItems, ex); }
      }
      public void FiltrosLView()
      {
          try
          {
              if (AyudaEntidadCliente.Value != null)
              {
                  Presenter.FILTROCliente = AyudaEntidadCliente.Value.ENTC_Codigo;
              }
              else { Presenter.FILTROCliente = null; }
              if (mdtFecDesde.NSFecha != null)
              {
                  Presenter.FILTRO_FecEmiDesde = mdtFecDesde.NSFecha.Value;  
              }
              if (mdtFecHasta.NSFecha != null)
              {
                  Presenter.FILTRO_FecEmiHasta = mdtFecHasta.NSFecha.Value;
              }
              if (!String.IsNullOrEmpty(txtNroCotizacion.Text))
              {
                  Presenter.FILTRONroOperacion = txtNroCotizacion.Text;
              }
              else { Presenter.FILTRONroOperacion = null; }
              if (CbSituacionFacturaCliente.SelectedItem != null)
              {
                  Presenter.SituacionFactCliente = Convert.ToInt32(CbSituacionFacturaCliente.SelectedValue);
              }
              if (CbSituacionFacturaProveedor.SelectedItem != null)
              {
                  Presenter.SituacionFactProveedor = Convert.ToInt32(CbSituacionFacturaProveedor.SelectedValue);
              }
          }
          catch (Exception ex)
          { Infrastructure.WinFormsControls.Dialogos.MostrarMensajeError(Presenter.Title, Infrastructure.Aspect.Constants.Mensajes.LoadView, ex); }
      }
      #endregion

      #region [ Metodos ]
      public void EliminarFiltros()
      {
          for (int i = 0; i < grdItems.ColumnCount; i++)
          {
              grdItems.FilterDescriptors.Clear();
          }
      }
      ToolStripMenuItem tsmTodos;
      String[] defaultColumns;
      private void FormatDataGrid()
      {
         try
         {
            Telerik.WinControls.UI.Localization.RadGridLocalizationProvider.CurrentProvider = new Infrastructure.WinFormsControls.MySpanishRadGridLocalizationProvider();
            grdItems.Columns.Clear();
            grdItems.AllowAddNewRow = false;
            Telerik.WinControls.UI.GridViewCommandColumn commandColumn;
            commandColumn = new Telerik.WinControls.UI.GridViewCommandColumn();
            commandColumn.Name = "Edit";
            commandColumn.HeaderText = "Editar";
            commandColumn.DefaultText = "Editar";
            commandColumn.UseDefaultText = true;
            grdItems.Columns.Add(commandColumn);
            grdItems.Columns["Edit"].AllowSort = false;
            grdItems.Columns["Edit"].AllowFiltering = false;

            commandColumn = new Telerik.WinControls.UI.GridViewCommandColumn();
            commandColumn.Name = "Delete";
            commandColumn.HeaderText = "Eliminar";
            commandColumn.DefaultText = "Eliminar";
            commandColumn.UseDefaultText = true;
            grdItems.Columns.Add(commandColumn);
            grdItems.Columns["Delete"].AllowSort = false;
            grdItems.Columns["Delete"].AllowFiltering = false;

            commandColumn = new Telerik.WinControls.UI.GridViewCommandColumn();
            commandColumn.Name = "Anular";
            commandColumn.HeaderText = "Anular";
            commandColumn.DefaultText = "Anular";
            commandColumn.UseDefaultText = true;
            grdItems.Columns.Add(commandColumn);
            grdItems.Columns["Anular"].AllowSort = false;
            grdItems.Columns["Anular"].AllowFiltering = false;

            grdItems.Columns.Add("COPE_NumDoc", "Número Operación", "COPE_NumDoc");
            grdItems.Columns.Add("COPE_MBL", "MBL", "COPE_MBL");
            grdItems.Columns.Add("COPE_HBL", "HBL", "COPE_HBL");
            
            grdItems.Columns.Add("COPE_FecEmi", "Fecha Emisión", "COPE_FecEmi");
            grdItems.Columns.Add("Cliente", "Cliente", "Cliente");
            grdItems.Columns.Add("Transportista", "Transportista", "Transportista");

            grdItems.Columns.Add("COPE_Nave", "Nave", "COPE_Nave");
            grdItems.Columns.Add("COPE_Viaje", "Viaje", "COPE_Viaje");
            grdItems.Columns.Add("DDOV_FecEmbarque", "Fecha Embarque", "DDOV_FecEmbarque");
            grdItems.Columns.Add("NVIA_FecETA_IMPO_ETD_EXPO", "Fecha ETA/ETD", "NVIA_FecETA_IMPO_ETD_EXPO");

            grdItems.Columns.Add("Agente", "Agente", "Agente");
            grdItems.Columns.Add("MonedaSTR", "Moneda", "MonedaSTR");
            grdItems.Columns.Add("COPE_ValorCosto", "Valor Costo", "COPE_ValorCosto");
            grdItems.Columns["COPE_ValorCosto"].Width = 50;
            grdItems.Columns["COPE_ValorCosto"].FormatString = @"{0:###,##0.00}";
            grdItems.Columns["COPE_ValorCosto"].AutoSizeMode = BestFitColumnMode.DisplayedCells;
            grdItems.Columns["COPE_ValorCosto"].TextAlignment = ContentAlignment.MiddleRight;

            grdItems.Columns.Add("COPE_ValorVenta", "Valor Venta", "COPE_ValorVenta");
            grdItems.Columns["COPE_ValorVenta"].Width = 50;
            grdItems.Columns["COPE_ValorVenta"].FormatString = @"{0:###,##0.00}";
            grdItems.Columns["COPE_ValorVenta"].AutoSizeMode = BestFitColumnMode.DisplayedCells;
            grdItems.Columns["COPE_ValorVenta"].TextAlignment = ContentAlignment.MiddleRight;

            grdItems.Columns.Add("COPE_Profit", "Profit", "COPE_Profit");
            grdItems.Columns["COPE_Profit"].Width = 50;
            grdItems.Columns["COPE_Profit"].FormatString = @"{0:###,##0.00}";
            grdItems.Columns["COPE_Profit"].AutoSizeMode = BestFitColumnMode.DisplayedCells;
            grdItems.Columns["COPE_Profit"].TextAlignment = ContentAlignment.MiddleRight;

            grdItems.Columns.Add("Situacion_fact_clie", "Situación Fact. Cliente", "Situacion_fact_clie");
            grdItems.Columns.Add("Situacion_fact_Prov", "Situación Fact. Proveedor", "Situacion_fact_Prov");
            grdItems.Columns.Add("CONS_CodEstadoSTR", "Estado", "CONS_CodEstadoSTR");
            
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
            Infrastructure.WinFormsControls.GridAutoFit.Fit(grdItems);
         }
         catch (Exception ex)
         { Infrastructure.WinFormsControls.Dialogos.MostrarMensajeError(Presenter.Title, Infrastructure.Aspect.Constants.Mensajes.FormatDataGridView, ex); }
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

      private void FormatDataGridServicio()
      {
          try
          {
              Telerik.WinControls.UI.Localization.RadGridLocalizationProvider.CurrentProvider = new Infrastructure.WinFormsControls.MySpanishRadGridLocalizationProvider();
              grdItemsServicios.Columns.Clear();
              grdItemsServicios.AllowAddNewRow = false;
              grdItemsServicios.AllowEditRow = false;
              grdItemsServicios.AllowCellContextMenu = false;
              grdItemsServicios.AllowColumnHeaderContextMenu = false;
              grdItemsServicios.ShowFilteringRow = false;
              grdItemsServicios.ShowGroupPanel = false;
              grdItemsServicios.Columns.Add("desc_Servicio", "Servicio", "desc_Servicio");
              grdItemsServicios.Columns["desc_Servicio"].Width = 200;
              grdItemsServicios.Columns.Add("Situacion_fac_clie", "Situación Fact. Cliente", "Situacion_fac_clie");
              grdItemsServicios.Columns["Situacion_fac_clie"].Width = 150;
              grdItemsServicios.Columns.Add("Situacion_fac_prov", "Situación Fact. Proveedor", "Situacion_fac_prov");
              grdItemsServicios.Columns["Situacion_fac_prov"].Width = 150;
              grdItemsServicios.Columns.Add("Tipo", "Tipo", "Tipo");
              grdItemsServicios.Columns["Tipo"].Width = 70;
          }
          catch (Exception ex)
          { Infrastructure.WinFormsControls.Dialogos.MostrarMensajeError(Presenter.Title, Infrastructure.Aspect.Constants.Mensajes.FormatDataGridView, ex); }
      }
      private void SeleccionarItem()
      {
         try
         {
             if (Presenter != null)
             {
                 if (BSItems != null && BSItems.Current != null && BSItems.Current is Entities.Cab_Operacion)
                 {
                     Presenter.ItemLView = ((Entities.Cab_Operacion)BSItems.Current);
                     Presenter.CargarServicios(Presenter.ItemLView.COPE_Codigo);
                     BSItemsServicvios.DataSource = Presenter.ItemsServicios;
                     grdItemsServicios.DataSource = BSItemsServicvios;
                     navItemsServicios.BindingSource = BSItemsServicvios;
                     BSItemsServicvios.ResetBindings(true);
                     Presenter.Position = BSItems.Position;
                     //Infrastructure.WinFormsControls.GridAutoFit.Fit(grdItemsServicios);
                     //grdItemsServicios.ShowFilteringRow = false;
                     //grdItemsServicios.ShowGroupPanel = false;
                 }
                 else
                 { Presenter.ItemLView = null; }
             }
         }
         catch (Exception ex)
         { Infrastructure.WinFormsControls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al seleccionar el item.", ex); }
      }
      private void Nuevo()
      {
         try
         {
            Presenter.Nuevo();
         }
         catch (Exception ex)
         { Infrastructure.WinFormsControls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al hacer nuevo.", ex); }
      }
      private void Buscar()
      {
         try
         {
             EliminarFiltros();
             Presenter.Actualizar(true);
         }
         catch (Exception ex)
         { Infrastructure.WinFormsControls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al buscar.", ex); }
      }
      private void Exportar()
      {
         try
         {
            List<String> Titulos = new List<String>();
            Titulos.Add("Reporte");
            Int32 _fila = 2;
            Infrastructure.WinFormsControls.ExcelAportes _xls = new Infrastructure.WinFormsControls.ExcelAportes(1, Titulos, "");
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
         { Infrastructure.WinFormsControls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al exportar.", ex); }
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
         { Infrastructure.WinFormsControls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al deshacer la vista.", ex); }
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
                  case "Anular":
                     SeleccionarItem();
                     Presenter.AnulaOperacion();
                     break;
               }
            }
         }
         catch (Exception ex)
         { Infrastructure.WinFormsControls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al cargar los botones para editar y eliminar.", ex); }
      
       }
      void grdItems_CellFormatting(object sender, Telerik.WinControls.UI.CellFormattingEventArgs e)
      {
          try
          {
              if (e.CellElement is GridCommandCellElement)
              {
                  if (e.Column.Name.Equals("Edit"))
                  {
                      RadButtonElement bte = (RadButtonElement)e.CellElement.Children[0];
                      if (bte.Image == null)
                      {
                          bte.TextImageRelation = TextImageRelation.Overlay;
                          bte.DisplayStyle = DisplayStyle.Image;
                          bte.ImageAlignment = ContentAlignment.MiddleCenter;
                          bte.Image = Delfin.Logistico.Properties.Resources.editar16x16;
                          bte.ToolTipText = "Editar Registro";
                          bte.AutoSize = true;
                      }
                  }
                  if (e.Column.Name.Equals("Delete"))
                  {
                      RadButtonElement bte = (RadButtonElement)e.CellElement.Children[0];
                      if (bte.Image == null)
                      {
                          bte.TextImageRelation = TextImageRelation.Overlay;
                          bte.DisplayStyle = DisplayStyle.Image;
                          bte.ImageAlignment = ContentAlignment.MiddleCenter;
                          bte.Image = Delfin.Logistico.Properties.Resources.Sign_07;
                          bte.ToolTipText = "Eliminar Registro";
                          bte.AutoSize = true;
                      }
                  }
                 
                  if (e.Column.Name.Equals("Anular"))
                  {
                      RadButtonElement bte = (RadButtonElement)e.CellElement.Children[0];
                      if (bte.Image == null)
                      {
                          bte.TextImageRelation = TextImageRelation.Overlay;
                          bte.DisplayStyle = DisplayStyle.Image;
                          bte.ImageAlignment = ContentAlignment.MiddleCenter;
                          bte.Image = Delfin.Logistico.Properties.Resources.Sign_09;
                          bte.ToolTipText = "Anular Operación";
                          bte.AutoSize = true;
                      }
                  }
                  if (e.CellElement.RowInfo is GridViewNewRowInfo && e.CellElement.ColumnInfo is GridViewCommandColumn)
                  {
                      ((RadButtonElement)e.CellElement.Children[0]).Visibility = ElementVisibility.Hidden;
                  }
              }
          }
          catch (Exception ex) { Infrastructure.WinFormsControls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al formatear el icono." + ex.Message); }
      }
      #endregion

      #region [ IFormClose ]
      private void TitleView_FormClose(object sender, EventArgs e)
      {
         if (CloseForm != null)
         {
            Presenter.CloseView();
            CloseForm(null, new Infrastructure.Client.FormClose.FormCloseEventArgs(this.TabPageControl, Presenter.CUS));
         }
      }
      public event Infrastructure.Client.FormClose.FormCloseEventArgs.FormCloseEventHandler CloseForm;
      #endregion

      private void btnPreFactura_Click(object sender, EventArgs e)
      {
          SeleccionarItem();
          PRO007LView PRO007PRE_LView;
          PRO007MView PRO007PRE_MView;
          PRO007Presenter PRO007PRE_Presenter;

          Form MView2 = new PRO007PView();
          //            //MView.ti
                      MView2.ShowDialog();

            //MView.ClearItem();
            //ItemPreDocsVta = new PreDocsVta
            //{
            //   AUDI_UsrCrea = Session.UserName,
            //   AUDI_FecCrea = Session.Fecha,
            //   Instance = InstanceEntity.Added,
            //   TIPO_TabFPG = "FPG",
            //   TIPO_TabTDO = "TDO",
            //   TIPO_TabMND = "MND"
            //};
            //      MView.ClearItemsDetalles();
            //      MView.SetInstance(InstanceView.New);
            //      //((PRO007MView)MView).ShowDialog();
            //      //isMViewShow = true;
            //      ((PRO007MView)MView).Show();
            //      ((PRO007MView)MView).BringToFront();
          


      //    {
      //        if (CbTIPO_CodMND.SelectedValue != null)
      //        {
      //            LoadOperacion();
      //            if (Presenter.COPE_Codigo > 0)
      //            {
      //                btnBuscarTarja.Enabled = false;
      //                ClearItemsDetalles();
      //                Presenter.ServiciosOperacion(CbTIPO_CodMND.TiposSelectedValue, NUDPDOV_TipoCambio.Value);
      //                ShowItemsDetalles();
      //                grdItemsServicios.Columns["Agregar"].ReadOnly = false;
      //                if (Presenter.Entc_CodigoCliente > 0)
      //                {
      //                    cmbTIPE_Codigo.TipoEntidadSelectedValue = Convert.ToInt16(TiposEntidad.TIPE_Cliente);
      //                    AyudaENTC_Cliente.SetValue(Presenter.Entc_CodigoCliente);
      //                    AyudaENTC_Cliente.Enabled = true;

      //                }

      //                //                  NUDPDOV_TipoCambio.Value = Presenter.TipoCambio > 0 ? Presenter.TipoCambio : 0;
      //                //CbTIPO_CodMND.TiposSelectedValue = Presenter.TipoMoneda ?? "001";
      //                if (Presenter.DiasCredito > 0) // credito
      //                {

      //                    CbTIPO_CodFPG.TiposSelectedValue = "002";
      //                    DTPPDOV_FechaVcmto.NSFecha = Presenter.DiasCredito > 0 ? DTPPDOV_FechaEmision.Value.Date.AddDays(Presenter.DiasCredito) : Presenter.Session.Fecha;
      //                }
      //                else // Contado
      //                {
      //                    CbTIPO_CodFPG.TiposSelectedValue = "001";
      //                    DTPPDOV_FechaVcmto.NSFecha = Presenter.Session.Fecha;
      //                }
      //                txaSeries.SetValue(!String.IsNullOrEmpty(Presenter.TipoDoc) ? Presenter.TipoDoc : "001", null);
      //                //CbTIPO_CodMND.Enabled = false;
      //            }
      //            else btnBuscarTarja.Enabled = true;
      //        }
      //        else
      //        {
      //            Dialogos.MostrarMensajeInformacion(Presenter.Title, "Debe seleccionar la moneda del documento");
      //        }
      //    }
      }
   }
}
