using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Infrastructure.Aspect.Collections;
using Infrastructure.WinForms.Controls;
using Telerik.WinControls.UI;
using Telerik.WinControls;
using Delfin.Principal.Properties;

namespace Delfin.Principal
{
   public partial class CAJ014PlantillaAsientosMView : Form, ICAJ014PlantillaAsientosMView
   {
      #region [ Variables ]

      #endregion

      #region [ Formulario ]
      public CAJ014PlantillaAsientosMView()
      {
         InitializeComponent();
         try
         {
            this.FormClosing += new FormClosingEventHandler(MView_FormClosing);
            this.FormClosed += CAJ014PlantillaAsientosMView_FormClosed;

            btnGuardar.Click += btnGuardar_Click;
            btnSalir.Click += btnSalir_Click;
            btnNuevoDocumento.Click += btnNuevoDocumento_Click;
          
            grdItems.CommandCellClick += grdItems_CommandCellClick;
            grdItems.CellFormatting += grdItems_CellFormatting;

            BSItems = new BindingSource();

            this.Load += CAJ014PlantillaAsientosMView_Load;
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error inicializando el formulario MView.", ex); }
      }

      private void CAJ014PlantillaAsientosMView_FormClosed(object sender, FormClosedEventArgs e)
      { Presenter.IsClosedMView(); }

      private void CAJ014PlantillaAsientosMView_Load(object sender, EventArgs e)
      {

      }

      #endregion

      #region [ Propiedades ]
      public CAJ014PlantillaAsientosPresenter Presenter { get; set; }
      private bool Closing = false;
      private System.Collections.Hashtable HashFormulario { get; set; }

      public BindingSource BSItems { get; set; }
      #endregion

      #region [ ICAJ014PlantillaAsientosMView ]

      public void LoadView()
      {
         try
         {
            FormatDataGrid();

            cmbCABP_Ano.ValueMember = "PERIODO";
            cmbCABP_Ano.DisplayMember = "PERIODO";
            cmbCABP_Ano.DataSource = Presenter.DTPeriodos;
            cmbTIPO_CodREG.LoadControl(Presenter.ContainerService, "Tipo Registros", "REG", "< Sel. Tipo Reg. >", ListSortDirection.Ascending);

            txtCABP_Codigo.MaxLength = 3;
            txtCABP_Codigo.ReadOnly = true;
            txtCABP_Desc.MaxLength = 100;

         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error en el LoadView.", ex); }
      }

      public void ClearItem()
      {
         try
         {
            errorProviderCab_Cotizacion_OV.Clear();


         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error en ClearItem.", ex); }
      }
      public void GetItem()
      {
         try
         {
            errorProviderCab_Cotizacion_OV.Clear();

            if (cmbCABP_Ano.SelectedItem != null) { Presenter.Item.CABP_Ano = cmbCABP_Ano.SelectedValue.ToString(); } else { Presenter.Item.CABP_Ano = null; }
            if (!String.IsNullOrEmpty(txtCABP_Codigo.Text)) { Presenter.Item.CABP_Codigo = txtCABP_Codigo.Text; } else { Presenter.Item.CABP_Codigo = null; }
            if (!String.IsNullOrEmpty(txtCABP_Desc.Text)) { Presenter.Item.CABP_Desc = txtCABP_Desc.Text; } else { Presenter.Item.CABP_Desc = null; }
            if (cmbTIPO_CodREG.TiposSelectedItem != null)
            {
               Presenter.Item.TIPO_CodREG = cmbTIPO_CodREG.TiposSelectedItem.TIPO_CodTipo;
               Presenter.Item.TIPO_TabREG = cmbTIPO_CodREG.TiposSelectedItem.TIPO_CodTabla;
            }
            else
            {
               Presenter.Item.TIPO_CodREG = null;
               Presenter.Item.TIPO_TabREG = null;
            }
            if (txnCABP_ValorRef.Value != 0) { Presenter.Item.CABP_ValorRef = txnCABP_ValorRef.Value; } else { Presenter.Item.CABP_ValorRef = null; }

         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error en GetItem.", ex); }
      }
      public void SetItem()
      {
         try
         {
             if (!String.IsNullOrEmpty(Presenter.Item.CABP_Ano))
             {
                 cmbCABP_Ano.SelectedValue = Presenter.Item.CABP_Ano;
                 cmbCABP_Ano.Enabled = false;
             }
             else
             {
                 cmbCABP_Ano.Enabled = true;
             }
             if (!String.IsNullOrEmpty(Presenter.Item.CABP_Codigo))
             {
                 txtCABP_Codigo.Text = Presenter.Item.CABP_Codigo;
                 txtCABP_Codigo.Enabled = false;
             }
             else
             {
                 txtCABP_Codigo.Enabled = true;
             }

            if (!String.IsNullOrEmpty(Presenter.Item.CABP_Desc)) { txtCABP_Desc.Text = Presenter.Item.CABP_Desc; }
            if (!String.IsNullOrEmpty(Presenter.Item.TIPO_CodREG)) { cmbTIPO_CodREG.SelectedValue = Presenter.Item.TIPO_CodREG; }
            if (Presenter.Item.CABP_ValorRef.HasValue) { txnCABP_ValorRef.Value = Convert.ToDecimal(Presenter.Item.CABP_ValorRef.Value); }

            ShowItems();

            EnabledItem();
            HashFormulario = Infrastructure.Client.FormClose.FormValidateChanges.iniciarComparacionFormulario(this);
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error en SetItem.", ex); }
      }

      public void ShowItems()
      {
         try
         {
            BSItems.DataSource = Presenter.Item.ListDetPerfilAsientos;
            grdItems.DataSource = BSItems;
            navItems.BindingSource = BSItems;
            BSItems.ResetBindings(false);
         }
         catch (Exception)
         { throw; }
      }

      private void EnabledItem()
      {
         try
         {

         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error en EnabledItem.", ex); }
      }

      public void ShowValidation()
      {
         try
         {
            Infrastructure.Client.FormClose.FormShowErrorProvider<Entities.CabPerfilAsientos>.Validate(Presenter.Item, this, errorProviderCab_Cotizacion_OV);
            Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Presenter.Title, "Existen campos obligatorios, revise los detalles.", Presenter.Item.MensajeError);
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error en ShowValidation.", ex); }
      }
      #endregion

      #region [ Metodos ]

      private void FormatDataGrid()
      {
         try
         {
            Telerik.WinControls.UI.Localization.RadGridLocalizationProvider.CurrentProvider = new Infrastructure.WinForms.Controls.MySpanishRadGridLocalizationProvider();
            this.grdItems.Columns.Clear();
            this.grdItems.AllowAddNewRow = false;

            GridViewCommandColumn commandColumn;
            commandColumn = new GridViewCommandColumn();
            commandColumn.Name = "Delete";
            commandColumn.HeaderText = "Eliminar";
            commandColumn.DefaultText = "Eliminar";
            commandColumn.UseDefaultText = true;
            this.grdItems.Columns.Add(commandColumn);
            this.grdItems.Columns["Delete"].AllowSort = false;
            this.grdItems.Columns["Delete"].AllowFiltering = false;

            Telerik.WinControls.UI.GridViewCommandColumn _proveedor = new Telerik.WinControls.UI.GridViewCommandColumn();

            this.grdItems.Columns.Add("CUEN_Codigo", "Cuenta", "CUEN_Codigo");
            this.grdItems.Columns.Add("DETP_Glosa", "Glosa", "DETP_Glosa");
            this.grdItems.Columns.Add("CENT_Codigo", "Centro Costo", "CENT_Codigo");
            Telerik.WinControls.UI.GridViewDecimalColumn _debe = new Telerik.WinControls.UI.GridViewDecimalColumn();
            _debe.Name = "DETP_DebePorc";
            _debe.HeaderText = "Debe";
            _debe.FieldName = "DETP_DebePorc";
            _debe.DecimalPlaces = 2;
            _debe.Maximum = 999;
            _debe.Minimum = 0;
            _debe.FormatString = "{0:#0.00}";
            this.grdItems.Columns.Add(_debe);

            Telerik.WinControls.UI.GridViewDecimalColumn _haber = new Telerik.WinControls.UI.GridViewDecimalColumn();
            _haber.Name = "DETP_HaberPorc";
            _haber.HeaderText = "Haber";
            _haber.FieldName = "DETP_HaberPorc";
            _haber.DecimalPlaces = 2;
            _haber.Maximum = 999;
            _haber.Minimum = 0;
            _haber.FormatString = "{0:#0.00}";
            this.grdItems.Columns.Add(_haber);

            grdItems.BestFitColumns();
            Infrastructure.WinForms.Controls.GridAutoFit.Fit(grdItems);
            grdItems.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;

            this.grdItems.SelectionMode = Telerik.WinControls.UI.GridViewSelectionMode.CellSelect;
            this.grdItems.MultiSelect = false;

            this.grdItems.ShowFilteringRow = false;
            this.grdItems.EnableFiltering = false;
            this.grdItems.MasterTemplate.EnableFiltering = false;
            this.grdItems.EnableGrouping = false;
            this.grdItems.MasterTemplate.EnableGrouping = false;
            this.grdItems.EnableSorting = false;
            this.grdItems.MasterTemplate.EnableCustomSorting = false;

            this.grdItems.ReadOnly = false;
            this.grdItems.AllowEditRow = true;

            this.grdItems.Columns["CUEN_Codigo"].ReadOnly = false;
            this.grdItems.Columns["DETP_Glosa"].ReadOnly = false;
            this.grdItems.Columns["CENT_Codigo"].ReadOnly = false;
            this.grdItems.Columns["DETP_DebePorc"].ReadOnly = false;
            this.grdItems.Columns["DETP_HaberPorc"].ReadOnly = false;

            this.grdItems.Columns["CUEN_Codigo"].Width = 70;
            this.grdItems.Columns["DETP_Glosa"].Width = 200;
            this.grdItems.Columns["DETP_DebePorc"].Width = 80;
            this.grdItems.Columns["DETP_HaberPorc"].Width = 80;
            this.grdItems.Columns["CENT_Codigo"].Width = 80;
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, Infrastructure.Aspect.Constants.Mensajes.FormatDataGridView + " (Grid Servicios)", ex); }
      }

      private void AddDetPerfil()
      {
         try
         {
            if (BSItems != null)
            {
               Entities.DetPerfilAsientos _flete = new Entities.DetPerfilAsientos();
               Int16 _DCOT_Item = 0;
               if (((ObservableCollection<Entities.DetPerfilAsientos>)BSItems.DataSource).Count > 0)
               { _DCOT_Item = ((ObservableCollection<Entities.DetPerfilAsientos>)BSItems.DataSource).Max(dcot => dcot.DETP_Item); }
               _flete.DETP_Item = Convert.ToInt16(_DCOT_Item + 1);
               _flete.AUDI_UsrCrea = Presenter.Session.UserName;
               _flete.AUDI_FecCrea = Presenter.Session.Fecha;
               _flete.Instance = Infrastructure.Aspect.BusinessEntity.InstanceEntity.Added;
               
               BSItems.Add(_flete);
               BSItems.ResetBindings(true);
               
            }
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al agregar un nuevo detalle", ex); }
      }

      #endregion

      #region [ Metodos Documentos ]

      private void EliminarDetalle()
      {
         try
         {
            if (BSItems.Current != null)
            {
               Presenter.EliminarDetalle((BSItems.Current as Entities.DetPerfilAsientos));
            }
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al eliminar un nuevo detalle", ex); }
      }

      #endregion

      #region [ Eventos ]

     


       
       private  void btnNuevoDocumento_Click(object sender, EventArgs e)
      { AddDetPerfil(); }

      private void btnGuardar_Click(object sender, EventArgs e)
      {
         try
         {
            if (Presenter.Guardar(true))
            {
               this.FormClosing -= MView_FormClosing;
               errorProviderCab_Cotizacion_OV.Dispose();
               Presenter.Actualizar();
               this.Close();
            }
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al guardar el formulario.", ex); }
      }

      private void btnSalir_Click(object sender, EventArgs e)
      {
         try
         {
            this.FormClosing -= MView_FormClosing;
            errorProviderCab_Cotizacion_OV.Dispose();
            if (Infrastructure.Client.FormClose.FormValidateChanges.verificarCambioFormulario(this, HashFormulario))
            {
               if (Presenter.GuardarCambios() != System.Windows.Forms.DialogResult.Cancel)
               { this.Close(); }
               else
               { this.FormClosing += MView_FormClosing; }
            }
            else
            { this.Close(); }
            Closing = true;
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al cerrar el formulario.", ex); }
      }

      private void MView_FormClosing(object sender, FormClosingEventArgs e)
      {
         try
         {
            if (Closing != true)
            {
               this.FormClosing -= MView_FormClosing;
               if (Infrastructure.Client.FormClose.FormValidateChanges.verificarCambioFormulario(this, HashFormulario))
               {
                  if (Presenter.GuardarCambios() == System.Windows.Forms.DialogResult.Cancel)
                  {
                     e.Cancel = true;
                     this.FormClosing += new FormClosingEventHandler(MView_FormClosing);
                  }
                  else
                  { Presenter.Actualizar(); }
               }
               else
               { Presenter.Actualizar(); }
            }
            else
            { Closing = false; e.Cancel = true; }
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al cerrar el formulario.", ex); }
      }

      private void grdItems_CommandCellClick(object sender, EventArgs e)
      {
         try
         {
            if (sender is Telerik.WinControls.UI.GridCommandCellElement)
            {
               switch ((((Telerik.WinControls.UI.GridCommandCellElement)(sender)).CommandButton).TextElement.Text)
               {
                  case "Eliminar":
                     EliminarDetalle();
                     break;
               }
            }
         }
         catch (Exception)
         { }
      }

      private void grdItems_CellFormatting(object sender, CellFormattingEventArgs e)
      {
         try
         {
            if (e.CellElement is GridCommandCellElement)
            {
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
      
   }
}