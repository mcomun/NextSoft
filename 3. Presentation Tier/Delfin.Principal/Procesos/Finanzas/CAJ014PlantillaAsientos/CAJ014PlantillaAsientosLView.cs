using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;

using Telerik.WinControls.UI;
using System.Windows.Forms;
using Delfin.Principal.Properties;
using System.Drawing;
using Telerik.WinControls;


namespace Delfin.Principal
{
   public partial class CAJ014PlantillaAsientosLView : UserControl, ICAJ014PlantillaAsientosLView
   {
      #region [ Variables ]

      #endregion

      #region [ Formulario ]
      public CAJ014PlantillaAsientosLView(Telerik.WinControls.UI.RadPageViewPage x_tabPageControl)
      {
         InitializeComponent();
         try
         {
            TabPageControl = x_tabPageControl;

            btnNuevo.Click += new EventHandler(btnNuevo_Click);
            btnBuscar.Click += new EventHandler(btnBuscar_Click);
            btnExportar.Click += new EventHandler(btnExportar_Click);

            BSItems = new BindingSource();
            BSItems.CurrentItemChanged += new EventHandler(BSItems_CurrentItemChanged);

            grdItems.CommandCellClick += new Telerik.WinControls.UI.CommandCellClickEventHandler(grdItems_CommandCellClick);
            grdItems.CellFormatting += grdItems_CellFormatting;

            TitleView.FormClose += new EventHandler(TitleView_FormClose);

            txtCABP_Codigo.MaxLength = 3;
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error inicializando el formulario LView.", ex); }
      }
      #endregion

      #region [ Propiedades ]
      public Telerik.WinControls.UI.RadPageViewPage TabPageControl { get; set; }
      public Image IconView { get { return TitleView.FormIcon; } set { TitleView.FormIcon = value; } }
      public CAJ014PlantillaAsientosPresenter Presenter { get; set; }
      public BindingSource BSItems { get; set; }
      #endregion

      #region [ ICAJ014PlantillaAsientosLView ]
      public void LoadView()
      {
         try
         {
            FormatDataGrid();

            cmbCABP_Ano.ValueMember = "PERIODO";
            cmbCABP_Ano.DisplayMember = "PERIODO";
            cmbCABP_Ano.DataSource = Presenter.DTPeriodos;
            cmbTIPO_CodREG.LoadControl(Presenter.ContainerService, "Tipo Registros", "REG", "< Sel. Tipo Reg. >", ListSortDirection.Ascending);

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

            commandColumn = new Telerik.WinControls.UI.GridViewCommandColumn();
            commandColumn.Name = "Delete";
            commandColumn.HeaderText = "Eliminar";
            commandColumn.DefaultText = "Eliminar";
            commandColumn.UseDefaultText = true;
            this.grdItems.Columns.Add(commandColumn);
            this.grdItems.Columns["Delete"].AllowSort = false;
            this.grdItems.Columns["Delete"].AllowFiltering = false;

            this.grdItems.Columns.Add("CABP_Ano", "Periodo", "CABP_Ano");
            this.grdItems.Columns.Add("CABP_Codigo", "Código", "CABP_Codigo");
            this.grdItems.Columns.Add("CABP_Desc", "Descripción", "CABP_Desc");
            this.grdItems.Columns.Add("TIPO_REG", "Tipo de Registro", "TIPO_REG");

            grdItems.BestFitColumns();
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
     
      private void SeleccionarItem()
      {
         try
         {
            if (Presenter != null)
            {
               if (BSItems != null && BSItems != null && BSItems.DataSource != null && BSItems.Current != null && BSItems.Current is Entities.CabPerfilAsientos)
               {
                  Presenter.Item = ((Entities.CabPerfilAsientos)BSItems.Current);
               }
               else
               {
                  Presenter.Item = null;
               }
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
             if (!string.IsNullOrEmpty(cmbCABP_Ano.Text))
             {
                 Presenter.F_CABP_Ano = cmbCABP_Ano.Text;
             }
             else
             {
                 Presenter.F_CABP_Ano = null;
             }
             if (!string.IsNullOrEmpty(txtCABP_Codigo.Text))
             {
                 Presenter.F_CABP_Codigo = txtCABP_Codigo.Text;
             }
             else
             {
                 Presenter.F_CABP_Codigo = null;
             }
             if (cmbTIPO_CodREG.TiposSelectedItem != null)
             {
                 Presenter.F_TIPO_CodREG = cmbTIPO_CodREG.TiposSelectedItem.TIPO_CodTipo;
             }
             else
             {
                 Presenter.F_TIPO_CodREG = null;
             }

             
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
             Titulos.Add(Presenter.Title);
             Int32 _fila = 2;
             Infrastructure.WinForms.Controls.ExcelAportes _xls = new Infrastructure.WinForms.Controls.ExcelAportes(1, Titulos, "");
             Object[] _cabeceras = new Object[1];
             DataTable _dt = _xls.RadGridViewToDataTable(grdItems, ref _cabeceras, grdItems.FilterDescriptors.Count > 0);
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
   }
}
