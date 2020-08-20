﻿using System;
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
using Telerik.WinControls;
using Telerik.WinControls.UI;

namespace Delfin.Comercial
{
   public partial class CAJ005TransferenciasLView : UserControl, ICAJ005TransferenciasLView
   {
      #region [ Variables ]
      //private String m_sortColumnName;
      //private Boolean m_sortAscending = false;
      #endregion

      #region [ Formulario ]

      public CAJ005TransferenciasLView(Telerik.WinControls.UI.RadPageViewPage x_tabPageControl)
      {
         InitializeComponent();
         try
         {
            TabPageControl = x_tabPageControl;

            btnNuevo.Click += new EventHandler(btnNuevo_Click);
            btnNuevoReducido.Click += btnNuevoReducido_Click;
            btnBuscar.Click += new EventHandler(btnBuscar_Click);
            btnExportar.Click += new EventHandler(btnExportar_Click);
            btnDeshacer.Click += new EventHandler(btnDeshacer_Click);

            BSItems = new BindingSource();
            BSItems.CurrentItemChanged += new EventHandler(BSItems_CurrentItemChanged);

            grdItems.CommandCellClick += new Telerik.WinControls.UI.CommandCellClickEventHandler(grdItems_CommandCellClick);
            grdItems.CellFormatting += grdItems_CellFormatting;
            txtTRAN_Codigo.KeyPress += txtTRAN_Codigo_KeyPress;
            TitleView.FormClose += new EventHandler(TitleView_FormClose);
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error inicializando el formulario LView.", ex); }
      }

     
      #endregion

      #region [ Propiedades ]

      public Telerik.WinControls.UI.RadPageViewPage TabPageControl { get; set; }
      public Image IconView { get { return TitleView.FormIcon; } set { TitleView.FormIcon = value; } }
      public CAJ005TransferenciasPresenter Presenter { get; set; }
      public BindingSource BSItems { get; set; }
      
      #endregion

      #region [ ICAJ005TransferenciasLView ]

      public void LoadView()
      {
         try
         {
            FormatDataGrid();

            grdItems.Enabled = false;
            btnNuevo.Enabled = true;
            btnBuscar.Enabled = true;
            btnExportar.Enabled = false;

            dtpFecIni.NSFecha = new DateTime(Presenter.Fecha.Year, Presenter.Fecha.Month, 1);
            dtpFecFin.NSFecha = dtpFecIni.NSFecha.Value.AddMonths(1).AddDays(-1);

            if (!String.IsNullOrEmpty(Presenter.MensajeError)) { btnNuevo.Enabled = false; }

            //SeleccionarItem();
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
            grdItems.Columns["TRAN_Glosa"].Width = 600;

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

            commandColumn = new Telerik.WinControls.UI.GridViewCommandColumn();
            commandColumn.Name = "EditSmall";
            commandColumn.HeaderText = "Ed. Red.";
            commandColumn.DefaultText = "Ed. Red.";
            commandColumn.UseDefaultText = true;
            this.grdItems.Columns.Add(commandColumn);
            this.grdItems.Columns["EditSmall"].AllowSort = false;
            this.grdItems.Columns["EditSmall"].AllowFiltering = false;

            //commandColumn = new Telerik.WinControls.UI.GridViewCommandColumn();
            //commandColumn.Name = "Delete";
            //commandColumn.HeaderText = "Eliminar";
            //commandColumn.DefaultText = "Eliminar";
            //commandColumn.UseDefaultText = true;
            //this.grdItems.Columns.Add(commandColumn);
            //this.grdItems.Columns["Delete"].AllowSort = false;
            //this.grdItems.Columns["Delete"].AllowFiltering = false;

            commandColumn = new Telerik.WinControls.UI.GridViewCommandColumn();
            commandColumn.Name = "Nullable";
            commandColumn.HeaderText = "Anular";
            commandColumn.DefaultText = "Anular";
            commandColumn.UseDefaultText = true;
            this.grdItems.Columns.Add(commandColumn);
            this.grdItems.Columns["Nullable"].AllowSort = false;
            this.grdItems.Columns["Nullable"].AllowFiltering = false;

            this.grdItems.Columns.Add("TRAN_Codigo", "Código", "TRAN_Codigo");
            this.grdItems.Columns.Add("TRAN_Fecha", "Fecha", "TRAN_Fecha");
            this.grdItems.Columns.Add("TRAN_Glosa", "Glosa", "TRAN_Glosa");

            this.grdItems.Columns.Add("AsientoContable_DG", "Nro. Asiento D.G.", "AsientoContable_DG");
            this.grdItems.Columns.Add("AsientoContable_DC", "Nro. Asiento D.C.", "AsientoContable_DC");

            this.grdItems.Columns.Add("TRAN_Estado_Text", "Estado", "TRAN_Estado_Text");

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
               if (BSItems != null && BSItems != null && BSItems.DataSource != null && BSItems.Current != null && BSItems.Current is Entities.Transferencia)
               {
                  Presenter.Item = ((Entities.Transferencia)BSItems.Current);


               }
               else
               {
                  Presenter.Item = null;

               }
            }
            else
            {

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

      private void NuevoReducido()
      {
         try
         {
            Presenter.NuevoReducido();
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al hacer nuevo.", ex); }
      }

      private void Buscar()
      {
         try
         {
             string value = txtTRAN_Codigo.Text;
             if (txtTRAN_Codigo.Text != "")
             {
                 if (decimal.Parse(value) > 2147483647)
                 {
                     txtTRAN_Codigo.Text = "2147483647";
                 }
             }
            if (!String.IsNullOrEmpty(txtTRAN_Codigo.Text))
            {
               Presenter.F_TRAN_Codigo = int.Parse(txtTRAN_Codigo.Text);
            }
            else {Presenter.F_TRAN_Codigo=null;}
            Presenter.F_FecIni = dtpFecIni.NSFecha;
            Presenter.F_FecFin = dtpFecFin.NSFecha;

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
            /*****************************************/
            if (_dt.Columns["Nullable"] != null)
            { _dt.Columns.Remove("Nullable"); }
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

            grdItems.Enabled = false;
            btnNuevo.Enabled = true;
            btnBuscar.Enabled = true;
            btnExportar.Enabled = false;
            txtTRAN_Codigo.Clear();
            dtpFecIni.NSFecha = new DateTime(Presenter.Fecha.Year, Presenter.Fecha.Month, 1);
            dtpFecFin.NSFecha = dtpFecIni.NSFecha.Value.AddMonths(1).AddDays(-1);
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al deshacer la vista.", ex); }
      }
      
      #endregion

      #region [ Eventos ]

      private void btnNuevo_Click(object sender, EventArgs e)
      { Nuevo(); }


      private void btnNuevoReducido_Click(object sender, EventArgs e)
      { NuevoReducido(); }

      private void btnBuscar_Click(object sender, EventArgs e)
      { Buscar(); }
      private void btnVersionar_Click(object sender, EventArgs e)
      {
         SeleccionarItem();
         //Presenter.Versionar(); 
      }
      private void btnCopiar_Click(object sender, EventArgs e)
      {
         SeleccionarItem();
         //Presenter.Copiar();
      }
      private void btnPresupuestar_Click(object sender, EventArgs e)
      {
         SeleccionarItem();
         //Presenter.Presupuestar();
      }
      private void btnCoordinar_Click(object sender, EventArgs e)
      {
         SeleccionarItem();
         //Presenter.Coordinar();
      }
      private void btnConfirmar_Click(object sender, EventArgs e)
      {
         SeleccionarItem();
         //Presenter.AutorizarConfirmar();
      }
      private void btnGenerarOV_Click(object sender, EventArgs e)
      {
         SeleccionarItem();
         //Presenter.GenerarOV();
      }
      private void btnConcluir_Click(object sender, EventArgs e)
      {
         SeleccionarItem();
         //Presenter.Concluir();
      }
      private void btnImprimir_Click(object sender, EventArgs e)
      {
         SeleccionarItem();
         //Presenter.Imprimir();
      }
      private void btnAnular_Click(object sender, EventArgs e)
      {
         SeleccionarItem();
         //Presenter.Anular();
      }
      private void btnExportar_Click(object sender, EventArgs e)
      { Exportar(); }
      private void btnDeshacer_Click(object sender, EventArgs e)
      { Deshacer(); }
      void txtTRAN_Codigo_KeyPress(object sender, KeyPressEventArgs e)
      {
          try
          {
              Infrastructure.Aspect.Constants.Util.ValidaCodigo_KeyPress(ref e);
              
          }
          catch (Exception)
          { }
      }
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
                  case "Ed. Red.":
                     SeleccionarItem();
                     Presenter.EditarReducido();
                     break;
                  //case "Eliminar":
                  //   SeleccionarItem();
                  //   Presenter.Eliminar();
                  //   break;
                  case "Anular":
                     SeleccionarItem();
                     Presenter.Anular();
                     break;
               }
            }
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al cargar los botones para editar y eliminar.", ex); }

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
               if (e.Column.Name.Equals("EditSmall"))
               {
                  RadButtonElement bte = (RadButtonElement)e.CellElement.Children[0];
                  if (bte.Image == null)
                  {
                     bte.TextImageRelation = TextImageRelation.Overlay;
                     bte.DisplayStyle = DisplayStyle.Image;
                     bte.ImageAlignment = ContentAlignment.MiddleCenter;
                     bte.Image = Resources.edit_16x16;
                     bte.ToolTipText = @"Editar Registro Formato Reducido";
                     bte.AutoSize = true;
                  }
               }
               //if (e.Column.Name.Equals("Delete"))
               //{
               //   RadButtonElement bte = (RadButtonElement)e.CellElement.Children[0];
               //   if (bte.Image == null)
               //   {
               //      bte.TextImageRelation = TextImageRelation.Overlay;
               //      bte.DisplayStyle = DisplayStyle.Image;
               //      bte.ImageAlignment = ContentAlignment.MiddleCenter;
               //      bte.Image = Resources.Sign_07;
               //      bte.ToolTipText = @"Eliminar Registro";
               //      bte.AutoSize = true;
               //   }
               //}
               if (e.Column.Name.Equals("Nullable"))
               {
                  RadButtonElement bte = (RadButtonElement)e.CellElement.Children[0];
                  if (bte.Image == null)
                  {
                     bte.TextImageRelation = TextImageRelation.Overlay;
                     bte.DisplayStyle = DisplayStyle.Image;
                     bte.ImageAlignment = ContentAlignment.MiddleCenter;
                     bte.Image = Resources.forbidden_16x16;
                     bte.ToolTipText = @"Anular Registro";
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
