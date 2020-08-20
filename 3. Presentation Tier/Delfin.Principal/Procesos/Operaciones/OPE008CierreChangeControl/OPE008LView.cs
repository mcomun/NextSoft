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
using Telerik.WinControls.UI;
using Infrastructure.WinForms.Controls;

namespace Delfin.Principal
{
   public partial class OPE008LView : UserControl, IOPE008LView
   {
      #region [ Variables ]

      #endregion

      #region [ Formulario ]
      public OPE008LView(Telerik.WinControls.UI.RadPageViewPage x_tabPageControl)
      {
         InitializeComponent();
         try
         {
            TabPageControl = x_tabPageControl;

            btnBuscar.Click += new EventHandler(btnBuscar_Click);
            btnDeshacer.Click += new EventHandler(btnDeshacer_Click);
            TitleView.FormClose += new EventHandler(View_FormClose);

            BSItems = new BindingSource();
            grdItems.DataSource = BSItems;
            navItems.BindingSource = BSItems;

            grdItems.CellFormatting += grdItems_CellFormatting;
            grdItems.CommandCellClick += grdItems_CommandCellClick;
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al crear la vista.", ex); }
      }
      #endregion

      #region [ Propiedades ]
      public Telerik.WinControls.UI.RadPageViewPage TabPageControl { get; set; }
      public Image IconView { get { return TitleView.FormIcon; } set { TitleView.FormIcon = value; } }
      public OPE008Presenter Presenter { get; set; }
      public BindingSource BSItems { get; set; }
      #endregion

      #region [ IOPE008LView ]
      public void LoadView()
      {
         try
         {
            bool _iniciar = true;
            for (int i = Presenter.Session.Fecha.Year; i >= 2016; i--)
            { cmbCHAN_Anio.AddComboBoxItem(i, i.ToString(), _iniciar); _iniciar = false; }
            cmbCHAN_Anio.LoadComboBox("< Seleccionar Año >");

            FormatDataGrid();
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error cargando la vista.", ex); }
      }
      public void ShowItems()
      {
         try
         {
            BSItems.DataSource = Presenter.Items;
            BSItems.ResetBindings(true);
            grdItems.BestFitColumns();
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
            Telerik.WinControls.UI.GridViewCommandColumn commandColumnCerrar;
            commandColumnCerrar = new Telerik.WinControls.UI.GridViewCommandColumn();
            commandColumnCerrar.Name = "Cerrar";
            commandColumnCerrar.HeaderText = "Cerrar";
            commandColumnCerrar.DefaultText = "Cerrar";
            commandColumnCerrar.UseDefaultText = true;
            this.grdItems.Columns.Add(commandColumnCerrar);
            this.grdItems.Columns["Cerrar"].AllowSort = false;
            this.grdItems.Columns["Cerrar"].AllowFiltering = false;

            Telerik.WinControls.UI.GridViewCommandColumn commandColumnAperturar;
            commandColumnAperturar = new Telerik.WinControls.UI.GridViewCommandColumn();
            commandColumnAperturar.Name = "Aperturar";
            commandColumnAperturar.HeaderText = "Aperturar";
            commandColumnAperturar.DefaultText = "Aperturar";
            commandColumnAperturar.UseDefaultText = true;
            this.grdItems.Columns.Add(commandColumnAperturar);
            this.grdItems.Columns["Aperturar"].AllowSort = false;
            this.grdItems.Columns["Aperturar"].AllowFiltering = false;

            this.grdItems.Columns.Add("CHAN_DescMes", "Mes", "CHAN_DescMes");
            this.grdItems.Columns.Add("CHAN_DescEstado", "Estado", "CHAN_DescEstado");
            this.grdItems.Columns.Add("CHAN_UsuarioCierre", "Usuario Último Cierre", "CHAN_UsuarioCierre");
            this.grdItems.Columns.Add("CHAN_FechaCierre", "Fecha Último Cierre", "CHAN_FechaCierre");
            this.grdItems.Columns.Add("CHAN_UsuarioApertura", "Usuario Última Apertura", "CHAN_UsuarioApertura");
            this.grdItems.Columns.Add("CHAN_FechaApertura", "Fecha Última Apertura", "CHAN_FechaApertura");

            this.grdItems.Columns.Add("AsientoContable", "Asiento", "AsientoContable");


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
               if (BSItems != null && BSItems != null && BSItems.DataSource != null && BSItems.Current != null && BSItems.Current is Entities.CierresChangeControl)
               { Presenter.Item = ((Entities.CierresChangeControl)BSItems.Current); }
               else
               { Presenter.Item = null; }
            }
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al seleccionar el item.", ex); }
      }

      private void Buscar()
      {
         try
         {
            if (cmbCHAN_Anio.ComboSelectedItem != null)
            {
               Presenter.FILTRO_CHAN_Anio = (Int16)cmbCHAN_Anio.ComboSelectedItem.IntCodigo;

               Presenter.Actualizar();
            }
            else
            {
               Presenter.FILTRO_CHAN_Anio = null;

               Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Presenter.Title, "Debe seleccionar el año."); 
            }
            
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al limpiar al reporte.", ex); }
      }
      private void Cerrar()
      {
         try
         {
            
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al limpiar al reporte.", ex); }
      }
      private void Deshacer()
      {
         try
         {
            cmbCHAN_Anio.ComboStrSelectedValue = null;

            BSItems.DataSource = null;
            BSItems.ResetBindings(true);
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al limpiar al reporte.", ex); }
      }
      #endregion

      #region [ Eventos ]
      private void btnBuscar_Click(object sender, EventArgs e)
      { this.Buscar(); }
      private void btnDeshacer_Click(object sender, EventArgs e)
      { this.Deshacer(); }

      private void grdItems_CellFormatting(object sender, CellFormattingEventArgs e)
      {
         try
         {
            if (e.CellElement is GridCommandCellElement)
            {
               if (e.Column.Name.Equals("Cerrar"))
               {
                  var bte = (RadButtonElement)e.CellElement.Children[0];
                  if (bte.Image == null)
                  {
                     bte.TextImageRelation = TextImageRelation.Overlay;
                     bte.DisplayStyle = Telerik.WinControls.DisplayStyle.Image;
                     bte.ImageAlignment = ContentAlignment.MiddleCenter;
                     bte.Image = Delfin.Principal.Properties.Resources.forbidden_16x16;
                     bte.ToolTipText = @"Cerrar Mes";
                     bte.AutoSize = true;
                  }
               }
               if (e.Column.Name.Equals("Aperturar"))
               {
                  var bte = (RadButtonElement)e.CellElement.Children[0];
                  if (bte.Image == null)
                  {
                     bte.TextImageRelation = TextImageRelation.Overlay;
                     bte.DisplayStyle = Telerik.WinControls.DisplayStyle.Image;
                     bte.ImageAlignment = ContentAlignment.MiddleCenter;
                     bte.Image = Delfin.Principal.Properties.Resources.check_16x16;
                     bte.ToolTipText = @"Aperturar Mes";
                     bte.AutoSize = true;
                  }
               }
               if (e.CellElement.RowInfo is GridViewNewRowInfo && e.CellElement.ColumnInfo is GridViewCommandColumn)
               { e.CellElement.Children[0].Visibility = Telerik.WinControls.ElementVisibility.Hidden; }
            }

         }
         catch (Exception ex) { Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al formatear el icono." + ex.Message); }
      }
      private void grdItems_CommandCellClick(object sender, EventArgs e)
      {
         try
         {
            if (sender is Telerik.WinControls.UI.GridCommandCellElement)
            {
               switch ((((Telerik.WinControls.UI.GridCommandCellElement)(sender)).CommandButton).TextElement.Text)
               {
                  case "Cerrar":
                     SeleccionarItem();
                     Presenter.Cerrar();
                     break;
                  case "Aperturar":
                     SeleccionarItem();
                     Presenter.Aperturar();
                     break;
               }
            }
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al cargar los botones para editar y eliminar.", ex); }

      }
      #endregion

      #region [ IFormClose ]
      private void View_FormClose(object sender, EventArgs e)
      {
         if (CloseForm != null)
         { CloseForm(null, new Infrastructure.Client.FormClose.FormCloseEventArgs(this.TabPageControl, Presenter.CUS)); }
      }
      public event Infrastructure.Client.FormClose.FormCloseEventArgs.FormCloseEventHandler CloseForm;
      #endregion

   }
}