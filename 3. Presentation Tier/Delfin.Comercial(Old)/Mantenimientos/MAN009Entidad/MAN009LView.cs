using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Delfin.Comercial.Properties;
using Infrastructure.Aspect.Collections;
using Telerik.WinControls;
//dgvItems.FilterDescriptors.ToDataTable();
using Telerik.WinControls.UI;//dgvItems.FilterDescriptors.ToDataTable();


namespace Delfin.Comercial
{
   public partial class MAN009LView : UserControl, IMAN009LView
   {
      #region [ Variables ]

      #endregion

      #region [ Propiedades ]
      public Telerik.WinControls.UI.RadPageViewPage TabPageControl { get; set; }
      public Image IconView { get { return TitleView.FormIcon; } set { TitleView.FormIcon = value; } }
      public MAN009Presenter Presenter { get; set; }
      public BindingSource BSItems { get; set; }
      private String m_sortColumnName;
      private Boolean m_sortAscending = false;
      #endregion

      #region [ Formulario ]

      public MAN009LView(Telerik.WinControls.UI.RadPageViewPage x_tabPageControl)
      {
         InitializeComponent();
         try
         {
            TabPageControl = x_tabPageControl;
            btnNuevo.Click += new EventHandler(btnNuevo_Click);
            btnBuscar.Click += new EventHandler(btnBuscar_Click);
            btnExportar.Click += new EventHandler(btnExportar_Click);
            btnDeshacer.Click += new EventHandler(btnDeshacer_Click);
            //PAra el menejo de (filro y ordenamiendo de) grillas

            this.grdItems.SortChanged += new Telerik.WinControls.UI.GridViewCollectionChangedEventHandler(grdItems_SortChanged);
            this.grdItems.FilterChanged += new Telerik.WinControls.UI.GridViewCollectionChangedEventHandler(grdItems_FilterChanged);
            grdItems.CellFormatting += grdItems_CellFormatting;
            BSItems = new BindingSource();
            BSItems.CurrentItemChanged += new EventHandler(BSItems_CurrentItemChanged);
            grdItems.CommandCellClick += new Telerik.WinControls.UI.CommandCellClickEventHandler(grdItems_CommandCellClick);
            TitleView.FormClose += new EventHandler(TitleView_FormClose);
            TitleView.Caption = "MANTENIMIENTO DE " + Presenter.tipe_Desc;
         }
         catch (Exception ex)
         { }
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
            commandColumn = new Telerik.WinControls.UI.GridViewCommandColumn();
            commandColumn.Name = "Delete";
            commandColumn.HeaderText = "Eliminar";
            commandColumn.DefaultText = "Eliminar";
            commandColumn.UseDefaultText = true;
            this.grdItems.Columns.Add(commandColumn);
            this.grdItems.Columns["Delete"].AllowSort = false;
            this.grdItems.Columns["Delete"].AllowFiltering = false;
            this.grdItems.Columns.Add("ENTC_Codigo", "Código", "ENTC_Codigo");
            this.grdItems.Columns.Add("Tipo_CodTDI", "Tipo Doc Iden", "Tipo_CodTDI");

            //segun el tipo de entidad mostramos los campos
            this.grdItems.Columns.Add("ENTC_DocIden", "N.I.T.", "ENTC_DocIden");
            this.grdItems.Columns.Add("ENTC_NomCompleto", "Nombre", "ENTC_NomCompleto");

            //this.grdItems.Columns.Add("ENTC_Activo", "Activo", "ENTC_Activo");
            Telerik.WinControls.UI.GridViewCheckBoxColumn checkColumn;
            checkColumn = new Telerik.WinControls.UI.GridViewCheckBoxColumn();
            checkColumn.Name = "ENTC_Activo";
            checkColumn.FieldName = "ENTC_Activo";
            checkColumn.HeaderText = "Activo";
            checkColumn.ReadOnly = true;
            this.grdItems.Columns.Add(checkColumn);

            this.grdItems.Columns.Add("ENTC_EMail", "Correo", "ENTC_EMail");
            this.grdItems.Columns.Add("ENTC_EmailReceptorFE", "Correo Factura Electrónica", "ENTC_EmailReceptorFE");
            this.grdItems.Columns.Add("ENTC_Telef1", "Tel. Fijo", "ENTC_Telef1");
            this.grdItems.Columns.Add("ENTC_Telef2", "Tel. Movil", "ENTC_Telef2");


            switch (Presenter.tipe_Codigo)
            {
               case Delfin.Controls.EntidadClear.TIPE_Cliente:
                  //this.grdItems.Columns.Add("ENTC_Prospecto", "Prospecto", "ENTC_Prospecto");
                  checkColumn = new Telerik.WinControls.UI.GridViewCheckBoxColumn();
                  checkColumn.Name = "ENTC_Prospecto";
                  checkColumn.FieldName = "ENTC_Prospecto";
                  checkColumn.HeaderText = "Prospecto";
                  checkColumn.ReadOnly = true;
                  this.grdItems.Columns.Add(checkColumn);
                  this.grdItems.Columns.Add("TIPO_HOL", "Holding", "TIPO_HOL");

                  this.grdItems.Columns.Add("ENTC_FechaCredito", "Fecha Credito", "ENTC_FechaCredito");
                  this.grdItems.Columns.Add("ENTC_DiasCredito", "Dias Credito", "ENTC_DiasCredito");

                  this.grdItems.Columns["ENTC_FechaCredito"].FormatString = "{0:dd/MM/yyyy}";

                  this.grdItems.Columns.Add("Limitecredito", "Límite de Crédito", "Limitecredito");
                  break;
               case Delfin.Controls.EntidadClear.TIPE_Proveedor:

                  break;
               case Delfin.Controls.EntidadClear.TIPE_Ejecutivo:
                  this.grdItems.Columns.Add("ENTC_FecIng", "Fec. Ingreso", "ENTC_FecIng");
                  this.grdItems.Columns.Add("ENTC_Area", "Area", "ENTC_Area");
                  this.grdItems.Columns.Add("ENTC_Cargo", "Cargo", "ENTC_Cargo");

                  break;
               case Delfin.Controls.EntidadClear.TIPE_CustomerService:
                  this.grdItems.Columns.Add("ENTC_FecIng", "Fec. Ingreso", "ENTC_FecIng");
                  this.grdItems.Columns.Add("ENTC_Area", "Area", "ENTC_Area");
                  this.grdItems.Columns.Add("ENTC_Cargo", "Cargo", "ENTC_Cargo");

                  break;
               case Delfin.Controls.EntidadClear.TIPE_Transportista:
                  break;
               case Delfin.Controls.EntidadClear.TIPE_Agente:
                  break;
               case Delfin.Controls.EntidadClear.TIPE_Broker:
                  this.grdItems.Columns.Add("ENTC_FecIng", "Fec. Ingreso", "ENTC_FecIng");
                  break;
               case Delfin.Controls.EntidadClear.TIPE_AgenteCarga:
                  break;
               case Delfin.Controls.EntidadClear.TIPE_Contacto:
                  this.grdItems.Columns.Add("ENTC_Area", "Area", "ENTC_Area");
                  this.grdItems.Columns.Add("ENTC_Cargo", "Cargo", "ENTC_Cargo");
                  break;
               default:
                  break;
            }
            this.grdItems.Columns.Add("AUDI_UsrCrea", "Creado por", "AUDI_UsrCrea");
            this.grdItems.Columns.Add("AUDI_FecCrea", "Fecha crea", "AUDI_FecCrea");
            this.grdItems.Columns.Add("AUDI_UsrMod", "Modificado por", "AUDI_UsrMod");
            this.grdItems.Columns.Add("AUDI_FecMod", "Fecha mod.", "AUDI_FecMod");
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
               if (BSItems != null && BSItems.Current != null && BSItems.Current is Entities.Entidad)
               { Presenter.Item = ((Entities.Entidad)BSItems.Current); }
               else
               { Presenter.Item = null; }
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
            Presenter.F_ENTC_RazonSoc = null;
            if (!String.IsNullOrEmpty(txtENTC_RazonSoc.Text))
            {
               Presenter.F_ENTC_RazonSoc = txtENTC_RazonSoc.Text;
            }
            Presenter.F_ENTC_DocIden = null;
            if (!String.IsNullOrEmpty(txtENTC_DocIden.Text))
            {
               Presenter.F_ENTC_DocIden = txtENTC_DocIden.Text;
            }
            Presenter.Actualizar();
            //{
            //   Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Presenter.Title, "debe ingresar un criterio de búsqueda");
            //}
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
      public void EliminarFiltros()
      {
         for (int i = 0; i < grdItems.ColumnCount; i++)
         {
            grdItems.FilterDescriptors.Clear();
         }
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
                     //si es cliente buscamos sus contactos
                     SeleccionarItem();
                     Presenter.Editar();
                     break;
                  case "Eliminar":
                     Presenter.Eliminar();
                     break;
               }
            }
         }
         catch (Exception)
         {

         }
      }
      private void grdItems_CellFormatting(object sender, CellFormattingEventArgs e)
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
                     bte.Image = Resources.editar16x16;
                     bte.ToolTipText = @"Editar Registro";
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
                     bte.Image = Resources.Sign_07;
                     bte.ToolTipText = @"Eliminar Registro";
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
      private void grdItems_SortChanged(object sender, GridViewCollectionChangedEventArgs e)
      {
         m_sortColumnName = grdItems.SortDescriptors.ToString().Substring(0, grdItems.SortDescriptors.ToString().IndexOf(" "));
         if (grdItems.SortDescriptors.ToString().Substring(grdItems.SortDescriptors.ToString().IndexOf(" ") + 1) == "ASC")
            m_sortAscending = false;
         else
            m_sortAscending = true;
         ShowItems();
      }
      private void grdItems_FilterChanged(object sender, GridViewCollectionChangedEventArgs e)
      {
         String strFiltro;
         String strValorFiltro;
         DataTable tblValoresFiltro = new DataTable();
         tblValoresFiltro = grdItems.FilterDescriptors.ToDataTable();
         if (tblValoresFiltro.Rows.Count > 0)
         {
            for (int i = 0; i < tblValoresFiltro.Rows.Count; i++)
            {
               strFiltro = tblValoresFiltro.Rows[0].ItemArray[0].ToString();
               strValorFiltro = tblValoresFiltro.Rows[0].ItemArray[2].ToString();
               BSItems.Filter = "[" + strFiltro + "] like '%" + strValorFiltro + "%'";
               //  77 ShowItems();
            }
         }
      }
      #endregion

      #region [ ICUS009LView ]
      public void LoadView()
      {
         try
         {
            EntidadAyuda.ContainerService = Presenter.ContainerService;

            this.grdItems.FilterChanged += new GridViewCollectionChangedEventHandler(grdItems_FilterChanged);
            this.grdItems.SortChanged += new GridViewCollectionChangedEventHandler(grdItems_SortChanged);

            BSItems.DataSource = null;
            grdItems.DataSource = BSItems;
            navItems.BindingSource = BSItems;
            BSItems.ResetBindings(true);
            FormatDataGrid();
            grdItems.Enabled = false;
            this.TitleView.Caption = "MANTENIMIENTO DE " + Presenter.tipe_Desc;
            EntidadAyuda.Title = "MANTENIMIENTO DE " + Presenter.tipe_Desc;
            //LblEntidad.Text = Presenter.tipe_Desc;
            EntidadAyuda.TipoEntidad = (Delfin.Controls.TiposEntidad)Presenter.tipe_Codigo;
            //Delfin.Controls.variables.GetTipoEntidad(TipoEntidad)
            //ENTC_CodCliente.TipoEntidad = Delfin.Controls.TiposEntidad.TIPE_Cliente;
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error cargando la vista.", ex); }
      }
      public void LoadFilters()
      {
         try
         {
            //if (!String.IsNullOrEmpty(AyudaEntidad.Text)) { Presenter.ENTC_RazonSoc = AyudaEntidad.Text; } else { Presenter.ENTC_RazonSoc = null; }
         }
         catch (Exception) { }
      }
      public void ShowItems()
      {
         try
         {
            if (Presenter.Items != null)
            {
               BSItems.DataSource = Presenter.Items;
               grdItems.DataSource = BSItems;
               navItems.BindingSource = BSItems;
               BSItems.ResetBindings(true);
               if (grdItems.RowCount > 0)
               {
                  grdItems.Enabled = true;
                  //JLbtnSUCR_Exportar.Enabled = true;
                  Infrastructure.WinForms.Controls.GridAutoFit.Fit(this.grdItems);
               }
               else
               {
                  grdItems.Enabled = false;
                  // JLbtnSUCR_Exportar.Enabled = false;
               }
            }
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error cargando los items.", ex); }
      }
      #endregion

      #region [ IFormClose ]
      private void TitleView_FormClose(object sender, EventArgs e)
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
