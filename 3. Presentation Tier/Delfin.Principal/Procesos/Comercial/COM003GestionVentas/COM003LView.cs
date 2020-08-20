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

namespace Delfin.Principal
{
   public partial class COM003LView : UserControl, ICOM003LView
   {
      #region [ Variables ]

      #endregion

      #region [ Formulario ]
      public COM003LView(Telerik.WinControls.UI.RadPageViewPage x_tabPageControl)
      {
         InitializeComponent();
         try
         {
            TabPageControl = x_tabPageControl;

            TabGestionVentas.SelectedIndex = 0;
            TabGestionVentas.SelectedTab = TabGestionVentas.TabPages[0];

            cmbFiltro.SelectedIndexChanged += cmbFiltro_SelectedIndexChanged;

            TipoRESG_Codigo.SelectedIndexChanged += TipoRESG_Codigo_SelectedIndexChanged;

            txeEjecutivo.TipoEntidad = Delfin.Controls.TiposEntidad.TIPE_Ejecutivo;
            txeAgenteCarga.TipoEntidad = Delfin.Controls.TiposEntidad.TIPE_AgenteCarga;

            btnBuscar.Click += btnBuscar_Click;
            btnDeshacer.Click += btnDeshacer_Click;
            btnNuevoContacto.Click += btnNuevoContacto_Click;
            btnEditarContacto.Click += btnEditarContacto_Click;

            btnAnterior.Click += btnAnterior_Click;
            btnSiguiente.Click += btnSiguiente_Click;

            tsbNuevaGestion.Click += tsbNuevaGestion_Click;
            tsbEditarGestion.Click += tsbEditarGestion_Click;
            tsbEliminarGestion.Click += tsbEliminarGestion_Click;
            tsbGuardarGestion.Click += tsbGuardarGestion_Click;
            tsbDeshacerGestion.Click += tsbDeshacerGestion_Click;

            BSItems = new BindingSource();
            BSItems.CurrentItemChanged += BSItems_CurrentItemChanged;

            BSItemsGetsionVentas = new BindingSource();
            BSItemsGetsionVentas.CurrentItemChanged += BSItemsGetsionVentas_CurrentItemChanged;

            grdItems.MouseDoubleClick += grdItems_MouseDoubleClick;
            grdItems.CellClick += grdItems_CellClick;
            grdItems.SortChanged += grdItems_SortChanged;

            TitleView.FormClose += new EventHandler(View_FormClose);
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error cargando el formulario de Gestion de Ventas.", ex); }
      }

      

      
      #endregion

      #region [ Propiedades ]
      public Telerik.WinControls.UI.RadPageViewPage TabPageControl { get; set; }
      public Image IconView { get { return TitleView.FormIcon; } set { TitleView.FormIcon = value; } }
      public COM003Presenter Presenter { get; set; }
      public BindingSource BSItems { get; set; }
      public BindingSource BSItemsGetsionVentas { get; set; }
      #endregion

      #region [ ICUS003LView ]
      public void LoadView()
      {
         try
         {
            txeAgenteCarga.ContainerService = Presenter.ContainerService;
            txeEjecutivo.ContainerService = Presenter.ContainerService;

            BSItems.DataSource = null;
            grdItems.DataSource = BSItems;
            navItems.BindingSource = BSItems;
            navItemsDetalis.BindingSource = BSItems;
            BSItems.ResetBindings(true);

            cmbFiltro.AddComboBoxItem(1, "Todos", true);
            cmbFiltro.AddComboBoxItem(2, "Programados");
            cmbFiltro.LoadComboBox("< Seleccionar Filtro >");

            TipoRESG_Codigo.AddComboBoxItem(0, "Neutral");
            TipoRESG_Codigo.AddComboBoxItem(1, "Positivo");
            TipoRESG_Codigo.AddComboBoxItem(-1, "Negativo");
            TipoRESG_Codigo.LoadComboBox(null);

            cmbTiposCDT.LoadControl(Presenter.ContainerService, "Tipos de Comodity", "CDT", "< Todos >", ListSortDirection.Ascending);
            TIPO_CodGES.LoadControl(Presenter.ContainerService, "Tipos de gestón", "GES", "< Seleccionar Tipo Gestión >", ListSortDirection.Ascending);
            TIPO_CodGESProxima.LoadControl(Presenter.ContainerService, "Tipos de Próxima Gestión", "GES", "< Seleccionar Próximo Tipo Gestión >", ListSortDirection.Ascending);

            FormatDataGrid();

            HabilitarDatosProspecto(false);
            ClearItem();
            HabilitarDatosGestionVentas(false);
            ClearItemGestionVentas();
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error cargando la vista.", ex); }
      }
      public void ShowItems(Boolean Habilitar)
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
               Infrastructure.WinForms.Controls.GridAutoFit.Fit(grdItems);

               grdItems.ShowFilteringRow = false;
               grdItems.EnableFiltering = false;
               grdItems.MasterTemplate.EnableFiltering = false;
               grdItems.EnableGrouping = false;
               grdItems.MasterTemplate.EnableGrouping = false;
               grdItems.EnableSorting = true;
               grdItems.MasterTemplate.EnableCustomSorting = true;
               if (cmbFiltro.ComboSelectedItem.IntCodigo == 2)
               { this.grdItems.Columns["GEST_FechaProximaGestion1"].FormatString = "{0:hh:mm tt}"; }
               HabilitarFiltroGestion(false);
            }
            else
            {
               grdItems.ShowFilteringRow = false;
               grdItems.EnableFiltering = false;
               grdItems.MasterTemplate.EnableFiltering = false;
               grdItems.EnableGrouping = false;
               grdItems.MasterTemplate.EnableGrouping = false;
               grdItems.EnableSorting = false;
               grdItems.MasterTemplate.EnableCustomSorting = false;

               HabilitarFiltroGestion(true);
               grdItems.Enabled = false;
            }
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
            this.grdItems.AllowEditRow = false;

            if (cmbFiltro.ComboSelectedItem != null && cmbFiltro.ComboSelectedItem.IntCodigo == 2)
            {

               //this.grdItems.Columns.Add("GEST_DescGES", "ULTIMA GESTIÓN", "GEST_DescGES");
               //this.grdItems.Columns.Add("GEST_Fecha", "ULTIMA FECHA GESTIÓN", "GEST_Fecha");
               //this.grdItems.Columns.Add("GEST_DescResultado", "ULTIMO RESULTADO GESTIÓN", "GEST_DescResultado");
               //this.grdItems.Columns.Add("GEST_DescGESProxima", "PRÓXIMA GESTIÓN", "GEST_DescGESProxima");
               //this.grdItems.Columns.Add("GEST_FechaProximaGestion", "FECHA PROX. GESTIÓN", "GEST_FechaProximaGestion");

               //Telerik.WinControls.UI.GridViewDateTimeColumn dateTimeColumn = new Telerik.WinControls.UI.GridViewDateTimeColumn();
               //dateTimeColumn.Name = "GEST_FechaProximaGestion1";
               //dateTimeColumn.HeaderText = "HORA PROX. GESTIÓN";
               //dateTimeColumn.FieldName = "GEST_FechaProximaGestion";
               //dateTimeColumn.DataType = typeof(Nullable<DateTime>);
               //dateTimeColumn.FormatString = "{0:yyyy/MM/dd}";
               //this.grdItems.Columns.Add(dateTimeColumn);

            //}
            //else
            //{
               //this.grdItems.Columns.Add("GEST_FechaProximaGestion", "FECHA PROX. GESTIÓN", "GEST_FechaProximaGestion");

               Telerik.WinControls.UI.GridViewDateTimeColumn dateTimeColumn = new Telerik.WinControls.UI.GridViewDateTimeColumn();
               dateTimeColumn.Name = "GEST_FechaProximaGestion1";
               dateTimeColumn.HeaderText = "HORA PROX. GESTIÓN";
               dateTimeColumn.FieldName = "GEST_FechaProximaGestion";
               dateTimeColumn.DataType = typeof(Nullable<DateTime>);
               dateTimeColumn.FormatString = "{0:yyyy/MM/dd}";
               this.grdItems.Columns.Add(dateTimeColumn);
               
               this.grdItems.Columns.Add("GEST_DescGESProxima", "PRÓXIMA GESTIÓN", "GEST_DescGESProxima");

               this.grdItems.Columns.Add("GEST_DescGES", "ULTIMA GESTIÓN", "GEST_DescGES");
               this.grdItems.Columns.Add("GEST_Fecha", "ULTIMA FECHA GESTIÓN", "GEST_Fecha");
               this.grdItems.Columns.Add("GEST_DescResultado", "ULTIMO RESULTADO GESTIÓN", "GEST_DescResultado");
            }

            Telerik.WinControls.UI.GridViewCheckBoxColumn _check = new Telerik.WinControls.UI.GridViewCheckBoxColumn();
            _check.Name = "ENTC_Prospecto";
            _check.HeaderText = "PROSPECTO";
            _check.FieldName = "ENTC_Prospecto";
            this.grdItems.Columns.Add(_check);
                        
            this.grdItems.Columns.Add("ENTC_RazonSocialAgenteCarga", "AGENTE CARGA", "ENTC_RazonSocialAgenteCarga");
            this.grdItems.Columns.Add("TIPO_DescCDT", "COMODITY", "TIPO_DescCDT");
            this.grdItems.Columns.Add("ENTC_RazonSocialCliente", "CONSIGNATARIO/EMBARCADOR", "ENTC_RazonSocialCliente");
            this.grdItems.Columns.Add("PROS_TEUS", "TEUS", "PROS_TEUS");
            this.grdItems.Columns.Add("PROS_Porcentaje", "PORCENTAJE", "PROS_Porcentaje");
            this.grdItems.Columns.Add("PROS_CNTR40", "CONTENEDOR 40", "PROS_CNTR40");
            this.grdItems.Columns.Add("PROS_CNTR20", "CONTENEDOR 20", "PROS_CNTR20");
            
            grdItems.BestFitColumns();
            Infrastructure.WinForms.Controls.GridAutoFit.Fit(grdItems);

            //tsmColumnas.DropDownItems.Clear();
            //defaultColumns = new string[grdItems.Columns.Count];
            //int index = 0;
            //foreach (Telerik.WinControls.UI.GridViewDataColumn column in grdItems.Columns)
            //{
            //   ToolStripMenuItem _item = new ToolStripMenuItem(column.HeaderText);
            //   _item.Tag = column.Name;
            //   _item.Checked = column.IsVisible;
            //   _item.CheckOnClick = true;
            //   _item.Click += new EventHandler(tsmColumna_Click);
            //   tsmColumnas.DropDownItems.Add(_item);

            //   if (column.IsVisible)
            //   { defaultColumns[index] = column.Name; index += 1; }
            //}

            //ToolStripSeparator tsmSeparacion = new ToolStripSeparator();
            //tsmColumnas.DropDownItems.Add(tsmSeparacion);
            //tsmTodos = new ToolStripMenuItem("Todos");
            //tsmTodos.Tag = "Todas";
            //tsmTodos.Checked = false;
            //tsmTodos.CheckOnClick = true;
            //tsmTodos.Click += new EventHandler(tsmTodos_Click);
            //tsmColumnas.DropDownItems.Add(tsmTodos);


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

      #region [ Metodos Prospectos ]
      private void CambiarFiltro()
      {
         try
         {
            if (cmbFiltro.SelectedValue != null && cmbFiltro.SelectedValue is Int32)
            {
               Int32 _filtroCodigo = Convert.ToInt32(cmbFiltro.SelectedValue);
               switch (_filtroCodigo)
               {
                  case 1:
                     FILTRORangoFechas.Visible = false;
                     break;
                  case 2:
                     FILTRORangoFechas.Visible = true;
                     mdtFechaProximaGestion.NSFecha = Presenter.Session.Fecha;
                     break;
                  default:
                     FILTRORangoFechas.Visible = false;
                     break;
               }
            }
            else
            { FILTRORangoFechas.Visible = false; }
            
            FormatDataGrid();
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha Ocurrido un error al seleccionar el filtro.", ex); }
      }
      private void SeleccionarItem()
      {
         try
         {
            if (Presenter != null)
            {
               if (BSItems != null && BSItems.Current != null && BSItems.Current is Entities.Prospecto)
               { Presenter.Item = ((Entities.Prospecto)BSItems.Current); }
               else
               { Presenter.Item = null; }
               SetItem(); 
            }
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha Ocurrido un error al seleccionar el item de la grila.", ex); }
      }
      private void ClearItem()
      {
         try
         {
            ENTC_RazonSocialCliente.Text = String.Empty;
            ENTC_RazonSocialAgenteCarga.Text = String.Empty;
            PROS_FecAsignacion.Text = String.Empty;
            TIPO_DescCDT.Text = String.Empty;
            CONS_DescRGM.Text = String.Empty;
            PROS_TEUS.Text = String.Empty;
            PROS_Porcentaje.Text = String.Empty;
            PROS_CNTR20.Text = String.Empty;
            PROS_CNTR40.Text = String.Empty;

            ClearItemContacto();
            ClearItemGestionVentas();

            HabilitarDatosProspecto(false);
            HabilitarDatosContacto(false);
            HabilitarDatosGestionVentas(false);

            BSItemsGetsionVentas.DataSource = null;
            navGestiones.BindingSource = BSItemsGetsionVentas;
            BSItemsGetsionVentas.ResetBindings(true);
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha Ocurrido un error al limpiar el item.", ex); }
      }
      private void SetItem()
      {
         try
         {
            ClearItem();

            if (Presenter.Item != null)
            {
               ENTC_RazonSocialCliente.Text = Presenter.Item.ENTC_RazonSocialCliente;
               ENTC_RazonSocialAgenteCarga.Text = Presenter.Item.ENTC_RazonSocialAgenteCarga;
               PROS_FecAsignacion.Text = Presenter.Item.PROS_FecAsignacion.ToShortDateString();
               TIPO_DescCDT.Text = Presenter.Item.TIPO_DescCDT;
               CONS_DescRGM.Text = Presenter.Item.CONS_DescRGM;
               PROS_TEUS.Text = Presenter.Item.PROS_TEUS.ToString();
               PROS_Porcentaje.Text = Presenter.Item.PROS_Porcentaje.ToString();
               PROS_CNTR20.Text = Presenter.Item.PROS_CNTR20.ToString();
               PROS_CNTR40.Text = Presenter.Item.PROS_CNTR40.ToString();

               SetItemContacto();

               ShowGestionesProspecto();

               HabilitarDatosProspecto(true);
            }
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha Ocurrido un error al setear el item.", ex); }
      }
      private void Buscar()
      {
         try
         {
            Presenter.ItemEjecutivo = txeEjecutivo.Value;
            Presenter.ItemAgenteCarga = txeAgenteCarga.Value;
            Presenter.FechaProximaGestion = mdtFechaProximaGestion.NSFecha;

            if (cmbFiltro.SelectedValue != null && cmbFiltro.SelectedValue is Int32 && Int32.Parse(cmbFiltro.SelectedValue.ToString()) > 0)
            {
               Int32 _filtroCodigo = Convert.ToInt32(cmbFiltro.SelectedValue);

               Presenter.CargarProspectos(_filtroCodigo);
            }
            else
            { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Presenter.Title, "Debe seleccionar un filtro válido."); }
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al buscar.", ex); }
      }
      private void Deshacer()
      {
         try
         {
            BSItems.DataSource = null;
            grdItems.DataSource = BSItems;
            navItems.BindingSource = BSItems;
            BSItems.ResetBindings(true);
            grdItems.Enabled = false;

            txeEjecutivo.ClearValue();
            txeEjecutivo.Text = string.Empty;

            txeAgenteCarga.ClearValue();
            txeAgenteCarga.Text = string.Empty;

            cmbFiltro.SelectedIndex = 0;
            cmbTiposCDT.SelectedIndex = 0;


            mdtFechaProximaGestion.NSFecha = Presenter.Session.Fecha;

            ClearItem();
            HabilitarFiltroGestion(true);
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al deshacer la vista.", ex); }
      }
      private void Anterior()
      {
         try
         {
            if (!mdtFechaProximaGestion.NSFecha.HasValue) { mdtFechaProximaGestion.NSFecha = Presenter.Session.Fecha; }
            mdtFechaProximaGestion.NSFecha = mdtFechaProximaGestion.NSFecha.Value.AddDays(-1);
            Buscar();
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al hacer día anterior.", ex); }
      }
      private void Siguiente()
      {
         try
         {
            if (!mdtFechaProximaGestion.NSFecha.HasValue) { mdtFechaProximaGestion.NSFecha = Presenter.Session.Fecha; }
            mdtFechaProximaGestion.NSFecha = mdtFechaProximaGestion.NSFecha.Value.AddDays(1);
            Buscar();
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al hacer día siguiente.", ex); }
      }
      #endregion

      #region [ Metodos Contacto ]
      public void ClearItemContacto()
      {
         try
         {
            ENTC_NomCompleto.Text = String.Empty;
            ENTC_Area.Text = String.Empty;
            ENTC_Cargo.Text = String.Empty;
            ENTC_EMail.Text = String.Empty;
            ENTC_Telef1.Text = String.Empty;
            ENTC_Telef2.Text = String.Empty;

            HabilitarDatosContacto(false);
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha Ocurrido un error al limpiar el item de Contacto.", ex); }

      }
      public void SetItemContacto()
      {
         try
         {
            ClearItemContacto();

            if (Presenter.Item != null && Presenter.Item.ItemContacto != null)
            {
               ENTC_NomCompleto.Text = Presenter.Item.ItemContacto.ENTC_NomCompleto;
               ENTC_Area.Text = Presenter.Item.ItemContacto.ENTC_Area;
               ENTC_Cargo.Text = Presenter.Item.ItemContacto.ENTC_Cargo;
               ENTC_EMail.Text = Presenter.Item.ItemContacto.ENTC_EMail;
               ENTC_Telef1.Text = Presenter.Item.ItemContacto.ENTC_Telef1;
               ENTC_Telef2.Text = Presenter.Item.ItemContacto.ENTC_Telef2;

               HabilitarDatosContacto(true);

               btnNuevoContacto.Enabled = true;
            }
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha Ocurrido un error al setear el item de Contacto.", ex); }
      }
      private void NuevoContacto()
      {
         try
         {
            Presenter.Contacto(true);
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha Ocurrido un error al crear nuevo item de Contacto.", ex); }
      }
      private void EditarContacto()
      {
         try
         {
            Presenter.Contacto(false);
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha Ocurrido un error al editar el item de Contacto.", ex); }
      }
      #endregion
      
      #region [ Metodos Gestion ]
      public void ShowGestionesProspecto()
      {
         try
         {
            BSItemsGetsionVentas.DataSource = Presenter.Item.ListGestionVentas;
            navGestiones.BindingSource = BSItemsGetsionVentas;
            BSItemsGetsionVentas.ResetBindings(true);
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha Ocurrido un error al mostrar las Gestiones de Ventas.", ex); }
      }
      private void Gestionar()
      {
         try
         {
            //TabGestionVentas.SelectedIndex = 1;
            //TabGestionVentas.SelectedTab = TabGestionVentas.TabPages[1];
            TabGestionVentas.SelectedTab = pageDatosProspecto;
            DeshacerGestion();
            if (Presenter != null && Presenter.Item != null && !String.IsNullOrEmpty(Presenter.Item.GEST_CodGESProxima))
            { TIPO_CodGES.TiposSelectedValue = Presenter.Item.GEST_CodGESProxima; }
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha Ocurrido un error al hacer nuevo item de Gestión de Ventas.", ex); }
      }
      private void NuevaGestion()
      {
         try
         {
            Presenter.NuevaGestionVentas();
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha Ocurrido un error al hacer nuevo item de Gestión de Ventas.", ex); }
      }
      private void EditarGestion()
      {
         try
         {
            Presenter.EditarGestionVentas();
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha Ocurrido un error al hacer editar item de Gestión de Ventas.", ex); }
      }
      private void EliminarGestion()
      {
         try
         {
            Presenter.EliminarGestionVentas();
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha Ocurrido un error al hacer eliminar item de Gestión de Ventas.", ex); }
      }
      private void GuardarGestion()
      {
         try
         {
            Presenter.GuardarGestionVentas();
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha Ocurrido un error al guardar el item de Gestión de Ventas.", ex); }
      }
      private void DeshacerGestion()
      {
         try
         {
            SeleccionarItemGestionVentas();
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha Ocurrido un error al guardar el item de Gestión de Ventas.", ex); }
      }
      private void SeleccionarItemGestionVentas()
      {
         try
         {
            ClearItemGestionVentas();
            HabilitarDatosGestionVentas(false);
            if (Presenter != null && Presenter.Item != null)
            {
               if (BSItemsGetsionVentas != null && BSItemsGetsionVentas.Current != null && BSItemsGetsionVentas.Current is Entities.GestionVentas)
               {
                  Presenter.Item.ItemGestionVentas = ((Entities.GestionVentas)BSItemsGetsionVentas.Current);
                  SetItemGestionVentas();
               }
               else
               { 
                  Presenter.Item.ItemGestionVentas = null; 
               }
            }
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha Ocurrido un error al seleccionar el item de Gestión de Ventas.", ex); }
      }
      public void ClearItemGestionVentas()
      {
         try
         {
            TIPO_CodGES.TiposSelectedValue = null;
            GEST_Fecha.Text = String.Empty;
            TipoRESG_Codigo.SelectedIndex = 0;
            RESG_Codigo.SelectedIndex = 0;
            TIPO_CodGESProxima.TiposSelectedValue = null;
            GEST_FechaProximaGestion.NSFecha = null;
            GEST_TiempoProximaGestion.NSFecha = null;
            GEST_TiempoProximaGestion.NSMaskedTextBox.Text = null;
            GEST_Observacion.Text = String.Empty;
            
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha Ocurrido un error al limpiar el item.", ex); }
      }
      public void SetItemGestionVentas()
      {
         try
         {
            ClearItemGestionVentas();

            if (Presenter.Item != null && Presenter.Item.ItemGestionVentas != null)
            {
               TIPO_CodGES.TiposSelectedValue = Presenter.Item.ItemGestionVentas.TIPO_CodGES;
               GEST_Fecha.Text = Presenter.Item.ItemGestionVentas.GEST_Fecha.Value.ToShortDateString();

               if (Presenter.Item.ItemGestionVentas.RESG_Codigo != null)
               {
                  Entities.ResultGestion _resutado = Presenter.ListResultGestion.Where(resg => resg.RESG_Codigo == Presenter.Item.ItemGestionVentas.RESG_Codigo).FirstOrDefault();
                  if (_resutado != null)
                  {
                     TipoRESG_Codigo.ComboIntSelectedValue = _resutado.RESG_PositivoNegativo;
                     RESG_Codigo.SelectedValue = Presenter.Item.ItemGestionVentas.RESG_Codigo;
                  }
               }

               TIPO_CodGESProxima.TiposSelectedValue = Presenter.Item.ItemGestionVentas.TIPO_CodGESProxima;
               GEST_FechaProximaGestion.NSFecha = Presenter.Item.ItemGestionVentas.GEST_FechaProximaGestion;
               if (Presenter.Item.ItemGestionVentas.GEST_TiempoProximaGestion.HasValue)
               { GEST_TiempoProximaGestion.NSFecha = new DateTime(Presenter.Session.Fecha.Year, Presenter.Session.Fecha.Month, Presenter.Session.Fecha.Day, Presenter.Item.ItemGestionVentas.GEST_TiempoProximaGestion.Value.Hours, Presenter.Item.ItemGestionVentas.GEST_TiempoProximaGestion.Value.Minutes, Presenter.Item.ItemGestionVentas.GEST_TiempoProximaGestion.Value.Seconds); }
               GEST_Observacion.Text = Presenter.Item.ItemGestionVentas.GEST_Observacion;
            }
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha Ocurrido un error al setear el item.", ex); }
      }
      public void GetItemGestionVentas()
      {
         try
         {
            if (Presenter.Item != null && Presenter.Item.ItemGestionVentas != null)
            {
               if (TIPO_CodGES.TiposSelectedItem != null)
               {
                  Presenter.Item.ItemGestionVentas.TIPO_TabGES = TIPO_CodGES.TiposSelectedItem.TIPO_CodTabla;
                  Presenter.Item.ItemGestionVentas.TIPO_CodGES = TIPO_CodGES.TiposSelectedItem.TIPO_CodTipo;
               }
               else
               {
                  Presenter.Item.ItemGestionVentas.TIPO_TabGES = null;
                  Presenter.Item.ItemGestionVentas.TIPO_CodGES = null;
               }
               //Presenter.Item.ItemGestionVentas.GEST_Fecha = GEST_Fecha.Text;
               if (RESG_Codigo.SelectedItem != null && RESG_Codigo.SelectedItem is Entities.ResultGestion && ((Entities.ResultGestion)RESG_Codigo.SelectedItem).RESG_Codigo > 0)
               { Presenter.Item.ItemGestionVentas.RESG_Codigo = ((Entities.ResultGestion)RESG_Codigo.SelectedItem).RESG_Codigo; }
               else
               { Presenter.Item.ItemGestionVentas.RESG_Codigo = null; }

               if (TIPO_CodGESProxima.TiposSelectedItem != null)
               {
                  Presenter.Item.ItemGestionVentas.TIPO_TabGESProxima = TIPO_CodGESProxima.TiposSelectedItem.TIPO_CodTabla;
                  Presenter.Item.ItemGestionVentas.TIPO_CodGESProxima = TIPO_CodGESProxima.TiposSelectedItem.TIPO_CodTipo;
               }
               else
               {
                  Presenter.Item.ItemGestionVentas.TIPO_TabGESProxima = null;
                  Presenter.Item.ItemGestionVentas.TIPO_CodGESProxima = null;
               }

               Presenter.Item.ItemGestionVentas.GEST_FechaProximaGestion = GEST_FechaProximaGestion.NSFecha;

               if (GEST_TiempoProximaGestion.NSFecha.HasValue)
               { Presenter.Item.ItemGestionVentas.GEST_TiempoProximaGestion = new TimeSpan(GEST_TiempoProximaGestion.NSFecha.Value.Hour, GEST_TiempoProximaGestion.NSFecha.Value.Minute, 0); }
               else
               { Presenter.Item.ItemGestionVentas.GEST_TiempoProximaGestion = null; }
               Presenter.Item.ItemGestionVentas.GEST_Observacion = GEST_Observacion.Text;
            }
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha Ocurrido un error al obtener el item.", ex); }
      }
      public void ShowValidation()
      { }

      private void LoadResultadoGestion()
      {
         try
         {
            RESG_Codigo.ValueMember = "RESG_Codigo";
            RESG_Codigo.DisplayMember = "RESG_Desc";

            ObservableCollection<Entities.ResultGestion> _items = null;

            if (TipoRESG_Codigo.ComboIntSelectedValue.HasValue)
            {
               _items = Presenter.ListResultGestion.Where(resg => resg.RESG_PositivoNegativo == TipoRESG_Codigo.ComboIntSelectedValue).ToObservableCollection();
               _items.Insert(0, new Entities.ResultGestion() { RESG_Codigo = -1, RESG_Desc = "< Seleccionar Result. Gestión >" });
               RESG_Codigo.DataSource = _items;
               RESG_Codigo.SelectedIndex = 0;
            }
            RESG_Codigo.DataSource = _items;
            RESG_Codigo.SelectedIndex = 0;
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error cargando los resultados de gestión.", ex); }
      }
      #endregion

      #region [ Metodos Habilitacion ]
      private void HabilitarFiltroGestion(Boolean Habilitar)
      {
         try
         {
            txeEjecutivo.Enabled = Habilitar;
            txeAgenteCarga.Enabled = Habilitar;
            cmbFiltro.Enabled = Habilitar;
            cmbTiposCDT.Enabled = Habilitar;
            //btnAnterior.Enabled = Habilitar;
            //mdtFechaProximaGestion.Enabled = Habilitar;
            //btnSiguiente.Enabled = Habilitar;
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha Ocurrido un error al habilitar el filtro.", ex); }
      }
      private void HabilitarDatosProspecto(Boolean Habilitar)
      {
         try
         {
            ENTC_RazonSocialCliente.Enabled = Habilitar;
            ENTC_RazonSocialAgenteCarga.Enabled = Habilitar;
            PROS_FecAsignacion.Enabled = Habilitar;
            TIPO_DescCDT.Enabled = Habilitar;
            CONS_DescRGM.Enabled = Habilitar;
            PROS_TEUS.Enabled = Habilitar;
            PROS_Porcentaje.Enabled = Habilitar;
            PROS_CNTR20.Enabled = Habilitar;
            PROS_CNTR40.Enabled = Habilitar;

            ENTC_NomCompleto.Enabled = Habilitar;
            ENTC_Area.Enabled = Habilitar;
            ENTC_Cargo.Enabled = Habilitar;
            ENTC_EMail.Enabled = Habilitar;
            ENTC_Telef1.Enabled = Habilitar;
            ENTC_Telef2.Enabled = Habilitar;

            navGestiones.Enabled = Habilitar;
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha Ocurrido un error al habilitar el item.", ex); }
      }
      private void HabilitarDatosContacto(Boolean Habilitar)
      {
         try
         {
            ENTC_NomCompleto.Enabled = Habilitar;
            ENTC_Area.Enabled = Habilitar;
            ENTC_Cargo.Enabled = Habilitar;
            ENTC_EMail.Enabled = Habilitar;
            ENTC_Telef1.Enabled = Habilitar;
            ENTC_Telef2.Enabled = Habilitar;

            navGestiones.Enabled = Habilitar;
            btnNuevoContacto.Enabled = !Habilitar;
            btnEditarContacto.Enabled = Habilitar;
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha Ocurrido un error al habilitar el item.", ex); }
      }
      public void HabilitarDatosGestionVentas(Boolean Habilitar)
      {
         try
         {
            TIPO_CodGES.Enabled = Habilitar;
            GEST_Fecha.Enabled = Habilitar;
            TipoRESG_Codigo.Enabled = Habilitar;
            RESG_Codigo.Enabled = Habilitar;
            TIPO_CodGESProxima.Enabled = Habilitar;
            GEST_FechaProximaGestion.Enabled = Habilitar;
            GEST_TiempoProximaGestion.Enabled = Habilitar;
            GEST_Observacion.Enabled = Habilitar;

            tsbNuevaGestion.Enabled = !Habilitar;
            tsbEditarGestion.Enabled = (!Habilitar && Presenter != null && Presenter.Item != null && Presenter.Item.ItemGestionVentas != null);
            tsbEliminarGestion.Enabled = (!Habilitar && Presenter != null && Presenter.Item != null && Presenter.Item.ItemGestionVentas != null);
            tsbGuardarGestion.Enabled = Habilitar;
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha Ocurrido un error al habilitar el item de gestión de ventas.", ex); }
      }
      #endregion
      #endregion

      #region [ Eventos ]
      private void btnBuscar_Click(object sender, EventArgs e)
      { Buscar(); }
      private void btnDeshacer_Click(object sender, EventArgs e)
      { Deshacer(); }
      private void btnNuevoContacto_Click(object sender, EventArgs e)
      { NuevoContacto(); }
      private void btnEditarContacto_Click(object sender, EventArgs e)
      { EditarContacto(); }

      private void btnAnterior_Click(object sender, EventArgs e)
      { Anterior(); }
      private void btnSiguiente_Click(object sender, EventArgs e)
      { Siguiente(); }
      
      private void tsbNuevaGestion_Click(object sender, EventArgs e)
      { NuevaGestion(); }
      private void tsbEditarGestion_Click(object sender, EventArgs e)
      { EditarGestion(); }
      private void tsbEliminarGestion_Click(object sender, EventArgs e)
      { EliminarGestion(); }
      private void tsbGuardarGestion_Click(object sender, EventArgs e)
      { GuardarGestion(); }
      private void tsbDeshacerGestion_Click(object sender, EventArgs e)
      { DeshacerGestion(); }

      private void BSItems_CurrentItemChanged(object sender, EventArgs e)
      { SeleccionarItem(); }
      private void BSItemsGetsionVentas_CurrentItemChanged(object sender, EventArgs e)
      { SeleccionarItemGestionVentas(); }
      private void grdItems_CommandCellClick(object sender, EventArgs e)
      {
         try
         {
            //if (sender is Telerik.WinControls.UI.GridCommandCellElement)
            //{
            //   switch ((((Telerik.WinControls.UI.GridCommandCellElement)(sender)).CommandButton).TextElement.Text)
            //   {
            //      case "Editar":
            //         Presenter.Editar();
            //         break;
            //      case "Eliminar":
            //         Presenter.Eliminar();
            //         break;
            //   }
            //}
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha Ocurrido un error al ejecutar los comandos de la grila.", ex); }
      }

      private void cmbFiltro_SelectedIndexChanged(object sender, EventArgs e)
      { CambiarFiltro(); }

      Int32 rowIndex = -1;
      private void grdItems_CellClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
      {
         try
         { rowIndex = e.RowIndex; }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al seleccionar la fila.", ex); }
      }
      private void grdItems_MouseDoubleClick(object sender, MouseEventArgs e)
      {
         try
         {
            if (rowIndex >= 0)
            { Gestionar(); }
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al seleccionar el item.", ex); }
      }
      private void grdItems_SortChanged(object sender, Telerik.WinControls.UI.GridViewCollectionChangedEventArgs e)
      {
         try
         {
            if (grdItems.MasterTemplate.SortDescriptors != null && grdItems.MasterTemplate.SortDescriptors.Count > 0 && BSItems != null && BSItems.DataSource != null)
            {
               foreach (var item in grdItems.MasterTemplate.SortDescriptors)
               {
                  switch (item.PropertyName)
                  {
                     case "GEST_FechaProximaGestion":
                        if (item.Direction == ListSortDirection.Ascending)
                        { BSItems.DataSource = ((System.Collections.ObjectModel.ObservableCollection<Entities.Prospecto>)BSItems.DataSource).OrderBy(deud => deud.GEST_FechaProximaGestion).ToObservableCollection(); }
                        else
                        { BSItems.DataSource = ((System.Collections.ObjectModel.ObservableCollection<Entities.Prospecto>)BSItems.DataSource).OrderByDescending(deud => deud.GEST_FechaProximaGestion).ToObservableCollection(); }
                        break;
                     case "GEST_DescGESProxima":
                        if (item.Direction == ListSortDirection.Ascending)
                        { BSItems.DataSource = ((System.Collections.ObjectModel.ObservableCollection<Entities.Prospecto>)BSItems.DataSource).OrderBy(deud => deud.GEST_DescGESProxima).ToObservableCollection(); }
                        else
                        { BSItems.DataSource = ((System.Collections.ObjectModel.ObservableCollection<Entities.Prospecto>)BSItems.DataSource).OrderByDescending(deud => deud.GEST_DescGESProxima).ToObservableCollection(); }
                        break;
                     case "GEST_DescGES":
                        if (item.Direction == ListSortDirection.Ascending)
                        { BSItems.DataSource = ((System.Collections.ObjectModel.ObservableCollection<Entities.Prospecto>)BSItems.DataSource).OrderBy(deud => deud.GEST_DescGES).ToObservableCollection(); }
                        else
                        { BSItems.DataSource = ((System.Collections.ObjectModel.ObservableCollection<Entities.Prospecto>)BSItems.DataSource).OrderByDescending(deud => deud.GEST_DescGES).ToObservableCollection(); }
                        break;
                     case "GEST_Fecha":
                        if (item.Direction == ListSortDirection.Ascending)
                        { BSItems.DataSource = ((System.Collections.ObjectModel.ObservableCollection<Entities.Prospecto>)BSItems.DataSource).OrderBy(deud => deud.GEST_Fecha).ToObservableCollection(); }
                        else
                        { BSItems.DataSource = ((System.Collections.ObjectModel.ObservableCollection<Entities.Prospecto>)BSItems.DataSource).OrderByDescending(deud => deud.GEST_Fecha).ToObservableCollection(); }
                        break;
                     case "GEST_DescResultado":
                        if (item.Direction == ListSortDirection.Ascending)
                        { BSItems.DataSource = ((System.Collections.ObjectModel.ObservableCollection<Entities.Prospecto>)BSItems.DataSource).OrderBy(deud => deud.GEST_DescResultado).ToObservableCollection(); }
                        else
                        { BSItems.DataSource = ((System.Collections.ObjectModel.ObservableCollection<Entities.Prospecto>)BSItems.DataSource).OrderByDescending(deud => deud.GEST_DescResultado).ToObservableCollection(); }
                        break;
                     case "ENTC_RazonSocialAgenteCarga":
                        if (item.Direction == ListSortDirection.Ascending)
                        { BSItems.DataSource = ((System.Collections.ObjectModel.ObservableCollection<Entities.Prospecto>)BSItems.DataSource).OrderBy(deud => deud.ENTC_RazonSocialAgenteCarga).ToObservableCollection(); }
                        else
                        { BSItems.DataSource = ((System.Collections.ObjectModel.ObservableCollection<Entities.Prospecto>)BSItems.DataSource).OrderByDescending(deud => deud.ENTC_RazonSocialAgenteCarga).ToObservableCollection(); }
                        break;
                     case "TIPO_DescCDT":
                        if (item.Direction == ListSortDirection.Ascending)
                        { BSItems.DataSource = ((System.Collections.ObjectModel.ObservableCollection<Entities.Prospecto>)BSItems.DataSource).OrderBy(deud => deud.TIPO_DescCDT).ToObservableCollection(); }
                        else
                        { BSItems.DataSource = ((System.Collections.ObjectModel.ObservableCollection<Entities.Prospecto>)BSItems.DataSource).OrderByDescending(deud => deud.TIPO_DescCDT).ToObservableCollection(); }
                        break;
                     case "ENTC_RazonSocialCliente":
                        if (item.Direction == ListSortDirection.Ascending)
                        { BSItems.DataSource = ((System.Collections.ObjectModel.ObservableCollection<Entities.Prospecto>)BSItems.DataSource).OrderBy(deud => deud.ENTC_RazonSocialCliente).ToObservableCollection(); }
                        else
                        { BSItems.DataSource = ((System.Collections.ObjectModel.ObservableCollection<Entities.Prospecto>)BSItems.DataSource).OrderByDescending(deud => deud.ENTC_RazonSocialCliente).ToObservableCollection(); }
                        break;
                     case "PROS_TEUS":
                        if (item.Direction == ListSortDirection.Ascending)
                        { BSItems.DataSource = ((System.Collections.ObjectModel.ObservableCollection<Entities.Prospecto>)BSItems.DataSource).OrderBy(deud => deud.PROS_TEUS).ToObservableCollection(); }
                        else
                        { BSItems.DataSource = ((System.Collections.ObjectModel.ObservableCollection<Entities.Prospecto>)BSItems.DataSource).OrderByDescending(deud => deud.PROS_TEUS).ToObservableCollection(); }
                        break;
                     case "PROS_Porcentaje":
                        if (item.Direction == ListSortDirection.Ascending)
                        { BSItems.DataSource = ((System.Collections.ObjectModel.ObservableCollection<Entities.Prospecto>)BSItems.DataSource).OrderBy(deud => deud.PROS_Porcentaje).ToObservableCollection(); }
                        else
                        { BSItems.DataSource = ((System.Collections.ObjectModel.ObservableCollection<Entities.Prospecto>)BSItems.DataSource).OrderByDescending(deud => deud.PROS_Porcentaje).ToObservableCollection(); }
                        break;
                     case "PROS_CNTR40":
                        if (item.Direction == ListSortDirection.Ascending)
                        { BSItems.DataSource = ((System.Collections.ObjectModel.ObservableCollection<Entities.Prospecto>)BSItems.DataSource).OrderBy(deud => deud.PROS_CNTR40).ToObservableCollection(); }
                        else
                        { BSItems.DataSource = ((System.Collections.ObjectModel.ObservableCollection<Entities.Prospecto>)BSItems.DataSource).OrderByDescending(deud => deud.PROS_CNTR40).ToObservableCollection(); }
                        break;
                     case "PROS_CNTR20":
                        if (item.Direction == ListSortDirection.Ascending)
                        { BSItems.DataSource = ((System.Collections.ObjectModel.ObservableCollection<Entities.Prospecto>)BSItems.DataSource).OrderBy(deud => deud.PROS_CNTR20).ToObservableCollection(); }
                        else
                        { BSItems.DataSource = ((System.Collections.ObjectModel.ObservableCollection<Entities.Prospecto>)BSItems.DataSource).OrderByDescending(deud => deud.PROS_CNTR20).ToObservableCollection(); }
                        break;
                     default:
                        break;
                  }
                  break;
               }

               this.BSItems.ResetBindings(true);
            }
         }
         catch (Exception)
         { }
      }

      private void TipoRESG_Codigo_SelectedIndexChanged(object sender, EventArgs e)
      { LoadResultadoGestion(); }
      #endregion

      #region [ IFormClose ]
      private void View_FormClose(object sender, EventArgs e)
      {
         if (CloseForm != null)
         {
            //BusinessLogic.Colecciones.Inicializar(Presenter.Container);
            CloseForm(null, new Infrastructure.Client.FormClose.FormCloseEventArgs(this.TabPageControl, Presenter.CUS));
         }
      }
      public event Infrastructure.Client.FormClose.FormCloseEventArgs.FormCloseEventHandler CloseForm;
      #endregion
   }
}
