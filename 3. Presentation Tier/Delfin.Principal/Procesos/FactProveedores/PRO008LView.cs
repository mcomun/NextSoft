using System;
using System.Collections.Generic;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using Delfin.Entities;
using Delfin.Principal.Properties;
using Infrastructure.Aspect.Constants;
using Infrastructure.Client.FormClose;
using Infrastructure.WinFormsControls;
using Telerik.WinControls;
using Telerik.WinControls.UI;
using Telerik.WinControls.UI.Localization;
using System.ComponentModel;

namespace Delfin.Principal
{
   public partial class PRO008LView : UserControl, IPRO008LView
   {
       #region [ Constructor ]
       public PRO008LView(RadPageViewPage x_tabPageControl)
       {
           InitializeComponent();
           try
           {
               TabPageControl = x_tabPageControl;
               btnNuevo.Click += btnNuevo_Click;
               btnBuscar.Click += btnBuscar_Click;
               btnExportar.Click += btnExportar_Click;
               btnDeshacer.Click += btnDeshacer_Click;
               BSItems = new BindingSource();
               BSItems.CurrentItemChanged += BSItems_CurrentItemChanged;
               grdItems.CommandCellClick += grdItems_CommandCellClick;
               grdItems.CellFormatting += grdItems_CellFormatting;
               TitleView.FormClose += TitleView_FormClose;
           }
           catch (Exception ex)
           { Dialogos.MostrarMensajeError(Presenter.Title, Mensajes.ConstructorView, ex); }
       } 
       #endregion

      #region [ Propiedades ]
      public RadPageViewPage TabPageControl { get; set; }
      public Image IconView { get { return TitleView.FormIcon; } set { TitleView.FormIcon = value; } }
      public PRO008Presenter Presenter { get; set; }
      public BindingSource BSItems { get; set; }
      Int32 _CCCT_Codigo; 
      Int16 _EMPR_Codigo;
      #endregion

      #region [ IPRO008LView ]
      public void LoadView()
      {
         try
         {
            Proveedor.ContainerService = Presenter.ContainerService;

            BSItems.DataSource = null;
            grdItems.DataSource = BSItems;
            navItems.BindingSource = BSItems;
            BSItems.ResetBindings(true);
            mdtFecDesdeEmision.NSFecha = DateTime.Now;
            mdtFecHastaEmision.NSFecha = DateTime.Now;
            mdtFecDesdeRegistro.NSFecha = null;
            mdtFecHastaRegistro.NSFecha = null;
            FormatDataGrid();
            grdItems.Enabled = false;
            btnNuevo.Enabled = true;
            btnBuscar.Enabled = true;
            btnExportar.Enabled = false;
            RbFechaEmision.CheckedChanged += RbFechaEmision_CheckedChanged;
            HabilitaRangoFechas(RbFechaEmision.Checked);
            cmbTIPE_Codigo.LoadControl(Presenter.ContainerService, "Tipo de Entidad", "< Sel. Tipo de Entidad >", ListSortDirection.Ascending);
            cmbTIPE_Codigo.SelectedIndexChanged += cmbTIPE_Codigo_SelectedIndexChanged;
            
         }
         catch (Exception ex)
         { Dialogos.MostrarMensajeError(Presenter.Title, Mensajes.LoadView, ex); }
      }

       void HabilitaRangoFechas(bool x_FechaEmision)
       {
           switch (x_FechaEmision) {
               case true:
                   Presenter.TipoFiltroFechas = true;
                   lblfechaemision.Enabled = x_FechaEmision;
                   mdtFecDesdeEmision.Enabled = x_FechaEmision;
                   mdtFecDesdeEmision.NSFecha = DateTime.Now.AddMonths(-1).Date;
                   mdtFecHastaEmision.NSFecha = DateTime.Now.Date;
                   lblFecHastaEmision.Enabled = x_FechaEmision;
                   mdtFecHastaEmision.Enabled = x_FechaEmision;
                   
                   mdtFecDesdeRegistro.NSFecha = null;
                   mdtFecHastaRegistro.NSFecha = null;
                   mdtFecDesdeRegistro.Enabled = !x_FechaEmision;
                   lblfecharegistro.Enabled = !x_FechaEmision;
                   lblFecHastaRegistro.Enabled = !x_FechaEmision;
                   mdtFecHastaRegistro.Enabled = !x_FechaEmision;
                   break;
               case false://Fecha Registro
                   Presenter.TipoFiltroFechas = false;
                   lblfechaemision.Enabled = x_FechaEmision;
                   mdtFecDesdeEmision.Enabled = x_FechaEmision;
                   mdtFecDesdeEmision.NSFecha = null;
                   mdtFecHastaEmision.NSFecha = null;
                   lblFecHastaEmision.Enabled = x_FechaEmision;
                   mdtFecHastaEmision.Enabled = x_FechaEmision;

                   mdtFecDesdeRegistro.NSFecha = DateTime.Now.AddMonths(-1).Date;
                   mdtFecHastaRegistro.NSFecha = DateTime.Now.Date;
                   mdtFecDesdeRegistro.Enabled = !x_FechaEmision;
                   lblfecharegistro.Enabled = !x_FechaEmision;
                   lblFecHastaRegistro.Enabled = !x_FechaEmision;
                   mdtFecHastaRegistro.Enabled = !x_FechaEmision;
                   break;
           }
       }
     
      void RbFechaEmision_CheckedChanged(object sender, EventArgs e)
      {
          try
          {
              HabilitaRangoFechas(RbFechaEmision.Checked);
          }
          catch (Exception) { }
      }
      private void BSItems_CurrentItemChanged(object sender, EventArgs e)
      { SeleccionarItem(); }
      public void ShowItems()
      {
         try
         {
            BSItems.DataSource = Presenter._DT ;
            grdItems.DataSource = BSItems;
            navItems.BindingSource = BSItems;
            BSItems.ResetBindings(true);
            if (grdItems.RowCount > 0)
            {
               grdItems.Enabled = true;
               btnExportar.Enabled = true;
               GridAutoFit.Fit(grdItems);
               grdItems.Columns["CCCT_TipoCambio"].FormatString = "{0:#,##0.000}";
            }
            else
            {
               grdItems.Enabled = false;
               btnExportar.Enabled = false;
            }
         }
         catch (Exception ex)
         { Dialogos.MostrarMensajeError(Presenter.Title, Mensajes.ShowItems, ex); }
      }
      public void FiltrosLView()
      {
         try
         {
            Presenter.CCCT_Desde = mdtFecDesdeEmision.Enabled ? mdtFecDesdeEmision.NSDateTimePicke.Value : mdtFecDesdeRegistro.NSFecha.Value;
            Presenter.CCCT_Hasta = mdtFecHastaEmision.Enabled ? mdtFecHastaEmision.NSDateTimePicke.Value : mdtFecHastaRegistro.NSFecha.Value;
            Presenter.ENTC_Codigo = Proveedor.Value == null ? 0 : Proveedor.Value.ENTC_Codigo;   
         }
         catch (Exception ex)
         { Dialogos.MostrarMensajeError(Presenter.Title, Mensajes.LoadView, ex); }
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

      private void grdItems_CommandCellClick(object sender, EventArgs e)
      {
         try
         {
            if (sender is GridCommandCellElement)
            {
               switch ((((GridCommandCellElement)(sender)).CommandButton).TextElement.Text)
               {
                  case "Editar":
                     SeleccionarItem();
                     Presenter.Editar(_CCCT_Codigo);
                     //Presenter.Editar();
                     break;
                  case "Eliminar":
                     SeleccionarItem();
                     Presenter.Eliminar(_CCCT_Codigo, _EMPR_Codigo);
                     break;
               }
            }
         }
         catch (Exception ex)
         { Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al cargar los botones para editar y eliminar.", ex); }

      }
      void grdItems_CellFormatting(object sender, CellFormattingEventArgs e)
      {
         try
         {
            if (!(e.CellElement is GridCommandCellElement)) return;
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
         catch (Exception ex) { Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al formatear el icono." + ex.Message); }
      }

      private void cmbTIPE_Codigo_SelectedIndexChanged(object sender, EventArgs e)
      {
         try
         {
            if (cmbTIPE_Codigo.TipoEntidadSelectedItem != null)
            {
               Proveedor.Enabled = true;
               Proveedor.TipoEntidad = Delfin.Controls.EntidadClear.getTipoEntidadEnum(cmbTIPE_Codigo.TipoEntidadSelectedItem.TIPE_Codigo);
            }
            else { Proveedor.Enabled = false; Proveedor.ClearValue(); }
         }
         catch (Exception)
         { }
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
            RadGridLocalizationProvider.CurrentProvider = new MySpanishRadGridLocalizationProvider();
            grdItems.Columns.Clear();
            grdItems.AllowAddNewRow = false;
            GridViewCommandColumn commandColumn;
            commandColumn = new GridViewCommandColumn();
            commandColumn.Name = "Edit";
            commandColumn.HeaderText = @"Editar";
            commandColumn.DefaultText = @"Editar";
            commandColumn.UseDefaultText = true;
            grdItems.Columns.Add(commandColumn);
            grdItems.Columns["Edit"].AllowSort = false;
            grdItems.Columns["Edit"].AllowFiltering = false;
            commandColumn = new GridViewCommandColumn();
            commandColumn.Name = "Delete";
            commandColumn.HeaderText = @"Eliminar";
            commandColumn.DefaultText = @"Eliminar";
            commandColumn.UseDefaultText = true;
            grdItems.Columns.Add(commandColumn);
            grdItems.Columns["Delete"].AllowSort = false;
            grdItems.Columns["Delete"].AllowFiltering = false;
            grdItems.Columns.Add("TIPO_Documento", "Tipo Documento", "TIPO_Documento");
            grdItems.Columns.Add("Proveedor", "Proveedor", "Proveedor");
            grdItems.Columns.Add("COPE_NumDoc", "Operación", "COPE_NumDoc");
            grdItems.Columns.Add("COPE_HBL", "HBL", "COPE_HBL");
            grdItems.Columns.Add("Cliente", "Cliente", "Cliente");
            grdItems.Columns.Add("COPE_Estado", "Estado", "COPE_Estado");
            grdItems.Columns.Add("CCCT_Serie", "Serie", "CCCT_Serie");
            grdItems.Columns.Add("CCCT_Numero", "Número", "CCCT_Numero");
            grdItems.Columns.Add("CCCT_FechaEmision", "Fecha Emisión", "CCCT_FechaEmision");
            grdItems.Columns.Add("CCCT_FecReg", "Fecha Registro", "CCCT_FecReg");
            grdItems.Columns.Add("SERVICIO", "Servicio", "SERVICIO");
            grdItems.Columns.Add("TIPO", "Tipo", "TIPO");
            grdItems.Columns.Add("TIPO_Moneda", "Moneda", "TIPO_Moneda");
            grdItems.Columns.Add("CCCT_ValVta", "Valor Costo", "CCCT_ValVta");
            grdItems.Columns.Add("CCCT_Imp1", "IGV", "CCCT_Imp1");

            grdItems.Columns.Add("TIPO_TI3", "Tipo de Renta 3ra", "TIPO_TI3");
            grdItems.Columns.Add("CCCT_Imp2", "Renta 3ra", "CCCT_Imp2");
            grdItems.Columns.Add("RetencionIGV", "Retención IGV", "RetencionIGV");

            grdItems.Columns.Add("CCCT_Monto", "Monto", "CCCT_Monto");
            grdItems.Columns.Add("CCCT_Saldo", "Saldo", "CCCT_Saldo");

            grdItems.Columns.Add("CCCT_Monto_S", "Monto S/.", "CCCT_Monto_S");
            grdItems.Columns.Add("CCCT_Monto_D", "Monto US$", "CCCT_Monto_D");
            grdItems.Columns.Add("CCCT_TipoCambio", "Tipo de Cambio", "CCCT_TipoCambio");
            grdItems.Columns.Add("TIPO_FPG", "Forma de Pago", "TIPO_FPG");
            grdItems.Columns.Add("ConDetraccion_text", "Detracción", "ConDetraccion_text");
            grdItems.Columns.Add("TIPO_DET", "Tipo Detracción", "TIPO_DET");

            grdItems.Columns.Add("AsientoContable", "Nro. Asiento", "AsientoContable");
            
            grdItems.Columns.Add("CCCT_Codigo", "Código Interno", "CCCT_Codigo");
            grdItems.BestFitColumns();

            grdItems.Columns["CCCT_ValVta"].FormatString = "{0:#,###,##0.00}";
            grdItems.Columns["CCCT_Imp1"].FormatString = "{0:#,###,##0.00}";
            grdItems.Columns["CCCT_Imp2"].FormatString = "{0:#,###,##0.00}";
            grdItems.Columns["CCCT_Monto"].FormatString = "{0:#,###,##0.00}";
            grdItems.Columns["CCCT_Saldo"].FormatString = "{0:#,###,##0.00}";
            grdItems.Columns["CCCT_Monto_S"].FormatString = "{0:#,###,##0.00}";
            grdItems.Columns["CCCT_Monto_D"].FormatString = "{0:#,###,##0.00}";
            
            tsmColumnas.DropDownItems.Clear();
            defaultColumns = new string[grdItems.Columns.Count];
            int index = 0;
            foreach (GridViewDataColumn column in grdItems.Columns)
            {
               ToolStripMenuItem _item = new ToolStripMenuItem(column.HeaderText);
               _item.Tag = column.Name;
               _item.Checked = column.IsVisible;
               _item.CheckOnClick = true;
               _item.Click += tsmColumna_Click;
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
            tsmTodos.Click += tsmTodos_Click;
            tsmColumnas.DropDownItems.Add(tsmTodos);
            GridAutoFit.Fit(grdItems);
         }
         catch (Exception ex)
         { Dialogos.MostrarMensajeError(Presenter.Title, Mensajes.FormatDataGridView, ex); }
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
         foreach (GridViewDataColumn column in grdItems.Columns)
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
               if (BSItems != null && BSItems.Current != null && BSItems.Current is System.Data.DataRowView)
               {
                  if (!Int32.TryParse(((System.Data.DataRowView)(BSItems.Current)).Row["CCCT_Codigo"].ToString(), out _CCCT_Codigo) 
                   || !Int16.TryParse(((System.Data.DataRowView)(BSItems.Current)).Row["EMPR_Codigo"].ToString(), out _EMPR_Codigo))
                  {
                      Presenter.ItemLView = null;
                  }
                   Presenter.Position = BSItems.Position;
               }
               else
               { Presenter.ItemLView = null; }
            }
         }
         catch (Exception ex)
         {
            if (Presenter != null)
               Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al seleccionar el item.", ex);
         }
      }
      private void Nuevo()
      {
         try
         {
            Presenter.Nuevo();
         }
         catch (Exception ex)
         { Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al hacer nuevo.", ex); }
      }
      private void Buscar()
      {
         try
         {
            EliminarFiltros();
            Presenter.Actualizar(true);
         }
         catch (Exception ex)
         { Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al buscar.", ex); }
      }

      private void Exportar()
      {
         try
         {
            List<String> Titulos = new List<String>();
            Titulos.Add("Reporte");
            Int32 _fila = 2;
            ExcelAportes _xls = new ExcelAportes(1, Titulos, "");
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
         { Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al exportar.", ex); }
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
            Presenter._DT = null;
         }
         catch (Exception ex)
         { Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al deshacer la vista.", ex); }
      }
      #endregion

      #region [ IFormClose ]
      private void TitleView_FormClose(object sender, EventArgs e)
      {
         if (CloseForm != null)
         {
            Presenter.CloseView();
            CloseForm(null, new FormCloseEventArgs(TabPageControl, Presenter.CUS));
         }
      }
      public event FormCloseEventArgs.FormCloseEventHandler CloseForm;
      #endregion


      
   }
}
