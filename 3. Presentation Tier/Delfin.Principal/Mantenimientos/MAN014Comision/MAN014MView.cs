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

namespace Delfin.Principal
{
   public partial class MAN014MView : Form, IMAN014MView
   {
      #region [ Variables ]

      #endregion

      #region [ Formulario ]
      public MAN014MView()
      {
         InitializeComponent();
         try
         {
            this.FormClosing += new FormClosingEventHandler(MView_FormClosing);
            btnGuardar.Click += btnGuardar_Click;
            btnSalir.Click += btnSalir_Click;

            btnAddDetComision.Click += btnAddDetComision_Click;
            btnDelComision.Click += btnDelComision_Click;

            BSDetComision = new BindingSource();
            grdDetComision.DataSource = BSDetComision;
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al inicializar el formulario MView.", ex); }
      }
      #endregion

      #region [ Propiedades ]
      public MAN014Presenter Presenter { get; set; }
      private bool Closing = false;
      private System.Collections.Hashtable HashFormulario { get; set; }
      public BindingSource BSDetComision { get; set; }
      #endregion

      #region [ IMNA013MView ]
      public void LoadView()
      {
         try
         {
            cmbTIPO_CodMND.LoadControl(Presenter.ContainerService, "Tabla Moneda", "MND", "< Seleccionar Moneda >", ListSortDirection.Ascending);
            
            FormatGrid();
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error cargando la vista.", ex); }
      }

      public void ClearItem()
      {
         try
         {
            txnCOMI_Codigo.Text = "0";
            mdtCOMI_FecIni.NSFecha = null;
            mdtCOMI_FecFin.NSFecha = null;
            cmbTIPO_CodMND.TiposSelectedValue = null;

            BSDetComision.DataSource = null;
            BSDetComision.ResetBindings(true);
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error limpiando el item.", ex); }
      }
      public void GetItem()
      {
         try
         {
            if (Presenter != null && Presenter.Item != null)
            {
               if (mdtCOMI_FecIni.NSFecha.HasValue)
               { Presenter.Item.COMI_FecIni = mdtCOMI_FecIni.NSFecha.Value; }
               else { Presenter.Item.COMI_FecIni = null; }
               if (mdtCOMI_FecFin.NSFecha.HasValue)
               { Presenter.Item.COMI_FecFin = mdtCOMI_FecFin.NSFecha.Value; }
               else { Presenter.Item.COMI_FecFin = null; }
               
               if (cmbTIPO_CodMND.TiposSelectedItem != null)
               {
                  Presenter.Item.TIPO_TabMND = cmbTIPO_CodMND.TiposSelectedItem.TIPO_CodTabla;
                  Presenter.Item.TIPO_CodMND = cmbTIPO_CodMND.TiposSelectedItem.TIPO_CodTipo;
               }
               else
               {
                  Presenter.Item.TIPO_TabMND = null;
                  Presenter.Item.TIPO_CodMND = null;
               }

               Presenter.Item.ListDet_Comision = ((ObservableCollection<Entities.Det_Comision>)BSDetComision.DataSource);
            }
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error obteniendo el item.", ex); }
      }
      public void SetItem()
      {
         try
         {
            if (Presenter != null && Presenter.Item != null)
            {
               txnCOMI_Codigo.Value = Presenter.Item.COMI_Codigo;
               mdtCOMI_FecIni.NSFecha = Presenter.Item.COMI_FecIni;
               mdtCOMI_FecFin.NSFecha = Presenter.Item.COMI_FecFin;

               cmbTIPO_CodMND.TiposSelectedValue = Presenter.Item.TIPO_CodMND;
               
               BSDetComision.DataSource = Presenter.Item.ListDet_Comision;
               BSDetComision.ResetBindings(true);

               ConfigureGrid();
            }
            HashFormulario = Infrastructure.Client.FormClose.FormValidateChanges.iniciarComparacionFormulario(this);
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error seteando el item.", ex); }
      }

      public void ShowValidation()
      {
         try
         {
            Infrastructure.Client.FormClose.FormShowErrorProvider<Entities.Comision>.Validate(Presenter.Item, this, errorProvider1);
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error mostrando la validación", ex); }
      }
      #endregion

      #region [ Metodos ]
      private void FormatGrid()
      {
         try
         {
            Telerik.WinControls.UI.Localization.RadGridLocalizationProvider.CurrentProvider = new Infrastructure.WinForms.Controls.MySpanishRadGridLocalizationProvider();
            this.grdDetComision.Columns.Clear();
            this.grdDetComision.AllowAddNewRow = false;

            Telerik.WinControls.UI.GridViewComboBoxColumn _paquete = new Telerik.WinControls.UI.GridViewComboBoxColumn();
            _paquete.Name = "PACK_Codigo";
            _paquete.HeaderText = "Tipo Paquete";
            _paquete.FieldName = "PACK_Codigo";
            _paquete.ValueMember = "PACK_Codigo";
            _paquete.DisplayMember = "PACK_Desc";
            _paquete.DataSource = Presenter.ListPaquetes;
            this.grdDetComision.Columns.Add(_paquete);

            Telerik.WinControls.UI.GridViewDecimalColumn _DCOM_MinProfit = new Telerik.WinControls.UI.GridViewDecimalColumn();
            _DCOM_MinProfit.Name = "DCOM_MinProfit";
            _DCOM_MinProfit.HeaderText = "Profit Mínimo";
            _DCOM_MinProfit.FieldName = "DCOM_MinProfit";
            _DCOM_MinProfit.DecimalPlaces = 0;
            this.grdDetComision.Columns.Add(_DCOM_MinProfit);

            Telerik.WinControls.UI.GridViewDecimalColumn _DCOM_Valor = new Telerik.WinControls.UI.GridViewDecimalColumn();
            _DCOM_Valor.Name = "DCOM_Valor";
            _DCOM_Valor.HeaderText = "Valor";
            _DCOM_Valor.FieldName = "DCOM_Valor";
            _DCOM_Valor.DecimalPlaces = 2;
            this.grdDetComision.Columns.Add(_DCOM_Valor);

            ConfigureGrid();
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, Infrastructure.Aspect.Constants.Mensajes.FormatDataGridView, ex); }
      }
      private void ConfigureGrid()
      {
         try
         {
            grdDetComision.BestFitColumns();
            Infrastructure.WinForms.Controls.GridAutoFit.Fit(grdDetComision);
            grdDetComision.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;

            this.grdDetComision.SelectionMode = Telerik.WinControls.UI.GridViewSelectionMode.CellSelect;
            this.grdDetComision.MultiSelect = false;

            this.grdDetComision.ShowFilteringRow = false;
            this.grdDetComision.EnableFiltering = false;
            this.grdDetComision.MasterTemplate.EnableFiltering = false;
            this.grdDetComision.EnableGrouping = false;
            this.grdDetComision.MasterTemplate.EnableGrouping = false;
            this.grdDetComision.EnableSorting = false;
            this.grdDetComision.MasterTemplate.EnableCustomSorting = false;

            this.grdDetComision.ReadOnly = false;
            this.grdDetComision.AllowEditRow = true;

            this.grdDetComision.Columns["PACK_Codigo"].ReadOnly = false;
            this.grdDetComision.Columns["DCOM_MinProfit"].ReadOnly = false;
            this.grdDetComision.Columns["DCOM_Valor"].ReadOnly = false;
            
            this.grdDetComision.Columns["PACK_Codigo"].MinWidth = 400;
            this.grdDetComision.Columns["PACK_Codigo"].TextAlignment = ContentAlignment.MiddleLeft;
            
            this.grdDetComision.Columns["DCOM_MinProfit"].MinWidth = 150;
            this.grdDetComision.Columns["DCOM_Valor"].MinWidth = 150;
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, Infrastructure.Aspect.Constants.Mensajes.FormatDataGridView, ex); }
      }

      private void AddDet_Comision()
      {
         try
         {
            Entities.Det_Comision _Det_Comision = new Entities.Det_Comision();
            Int32 _DCOM_Item = 0;
            if (((ObservableCollection<Entities.Det_Comision>)BSDetComision.DataSource).Count > 0)
            { _DCOM_Item = ((ObservableCollection<Entities.Det_Comision>)BSDetComision.DataSource).Max(dcom => dcom.DCOM_Item); }
            _Det_Comision.DCOM_Item = _DCOM_Item + 1;
            _Det_Comision.AUDI_UsrCrea = Presenter.Session.UserName;
            _Det_Comision.AUDI_FecCrea = Presenter.Session.Fecha;
            _Det_Comision.Instance = Infrastructure.Aspect.BusinessEntity.InstanceEntity.Added;
            BSDetComision.Add(_Det_Comision);
            BSDetComision.ResetBindings(true);
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al agregar un servicio", ex); }
      }
      private void DelDet_Comision()
      {
         try
         {
            if (BSDetComision.Current != null && BSDetComision.Current is Entities.Det_Comision)
            {
               Entities.Det_Comision _Det_Comision = (Entities.Det_Comision)BSDetComision.Current;
               if (_Det_Comision.Instance != Infrastructure.Aspect.BusinessEntity.InstanceEntity.Added)
               {
                  _Det_Comision.AUDI_UsrMod = Presenter.Session.UserName;
                  _Det_Comision.AUDI_FecMod = Presenter.Session.Fecha;
                  _Det_Comision.Instance = Infrastructure.Aspect.BusinessEntity.InstanceEntity.Deleted;
                  Presenter.Item.ListDet_ComisionDeleted.Add(_Det_Comision);
               }
               BSDetComision.RemoveCurrent();
               BSDetComision.ResetBindings(true);
            }
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al eliminar un servicio", ex); }
      }
      #endregion

      #region [ Eventos ]
      private void btnGuardar_Click(object sender, EventArgs e)
      {
         try
         {
            if (Presenter.Guardar())
            {
               this.FormClosing -= MView_FormClosing;
               errorProvider1.Dispose();
               //'Presenter.Actualizar(); ya esta actualizando al btnGuardar_Click en else presenter
               this.Close();
            }
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al Guardar.", ex); }
      }
      private void btnSalir_Click(object sender, EventArgs e)
      {
         try
         {
            this.FormClosing -= MView_FormClosing;
            errorProvider1.Dispose();
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

      private void btnAddDetComision_Click(object sender, EventArgs e)
      { AddDet_Comision(); }
      private void btnDelComision_Click(object sender, EventArgs e)
      { DelDet_Comision(); }

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
               }
            }
            else
            { Closing = false; e.Cancel = true; }
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al cerrar el formulario.", ex); }
      }
      #endregion
   }
}