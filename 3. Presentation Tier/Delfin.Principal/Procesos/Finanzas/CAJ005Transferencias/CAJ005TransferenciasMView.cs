using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Windows.Forms;
using Delfin.Principal.Properties;
using Delfin.Entities;
using Infrastructure.Aspect.Collections;
using Telerik.WinControls;
using Telerik.WinControls.UI;

namespace Delfin.Principal
{
   public partial class CAJ005TransferenciasMView : Form, ICAJ005TransferenciasMView
   {
      #region [ Variables ]

      #endregion

      #region [ Formulario ]
      public CAJ005TransferenciasMView()
      {
         InitializeComponent();
         try
         {
            this.FormClosing += new FormClosingEventHandler(MView_FormClosing);
            this.FormClosed += CAJ005TransferenciasMView_FormClosed;

            btnGuardar.Click += btnGuardar_Click;
            btnSalir.Click += btnSalir_Click;

            tsbtnNuevoIngresos.Click += btnNuevoIngresos_Click;
            tsbtnNuevoEgresos.Click += btnNuevoEgresos_Click;
            tsbtnNuevoGastosBancarios.Click += tsbtnNuevoGastosBancarios_Click;
            btnCalcular.Click += btnCalcular_Click;

            BSItemsIngresos = new BindingSource();
            grdItemsIngresos.DataSource = BSItemsIngresos;
             navItemsIngresos.BindingSource = BSItemsIngresos;
             
            BSItemsEgresos = new BindingSource();
            grdItemsEgresos.DataSource = BSItemsEgresos;
            navItemsEgresos.BindingSource = BSItemsEgresos;

            BSItemsGastosBancarios = new BindingSource();
            grdItemsGastosBancarios.DataSource = BSItemsGastosBancarios;
             navItemsGastosBancarios.BindingSource = BSItemsGastosBancarios;

            grdItemsEgresos.CellFormatting += grdItemsEgresos_CellFormatting;
            grdItemsEgresos.CommandCellClick += grdItemsEgresos_CommandCellClick;

            grdItemsIngresos.CellFormatting += grdItemsIngresos_CellFormatting;
            grdItemsIngresos.CommandCellClick += grdItemsIngresos_CommandCellClick;

            grdItemsGastosBancarios.CellFormatting += grdItemsGastosBancarios_CellFormatting;
            grdItemsGastosBancarios.CommandCellClick += grdItemsGastosBancarios_CommandCellClick;

            txtTRAN_Codigo.Tag = "TRAN_CodigoMSGERROR";
            dtpTRAN_Fecha.Tag = "TRAN_FechaMSGERROR";
            txtTRAN_Glosa.Tag = "TRAN_GlosaMSGERROR";

            txnIngresosDSol.ReadOnly = true;
            txnIngresosHSol.ReadOnly = true;
            txnEgresosDSol.ReadOnly = true;
            txnTotalDSol.ReadOnly = true;

            txtTRAN_Glosa.MaxLength = 1000;
            txtTRAN_Codigo.Enabled = false;

            this.Load += CAJ005TransferenciasMView_Load;
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error inicializando el formulario MView.", ex); }
      }

      void btnCalcular_Click(object sender, EventArgs e)
      {
         try
         {
            CalcularDiferencias();
         }
         catch (Exception)
         { }
      }

      private void CAJ005TransferenciasMView_FormClosed(object sender, FormClosedEventArgs e)
      { Presenter.IsClosedMView(); }

      private void CAJ005TransferenciasMView_Load(object sender, EventArgs e)
      {
         tabTransferencias.SelectedTab = pageGenerales;
      }
      #endregion

      #region [ Propiedades ]
      public CAJ005TransferenciasPresenter Presenter { get; set; }
      private bool Closing = false;
      private System.Collections.Hashtable HashFormulario { get; set; }

      public BindingSource BSItemsEgresos { get; set; }
      public BindingSource BSItemsIngresos { get; set; }
      public BindingSource BSItemsGastosBancarios { get; set; }

      #endregion

      #region [ ICAJ005TransferenciasMView ]
      public void LoadView()
      {
         try
         {
            FormatGridEgresos();
            FormatGridIngresos();
            FormatGridGastosBancarios();

            txnDiferenciaDDol.ReadOnly = true;
            txnDiferenciaDSol.ReadOnly = true;
            txnDiferenciaHDol.ReadOnly = true;
            txnDiferenciaHSol.ReadOnly = true;
            txnEgresosDDol.ReadOnly = true;
            txnEgresosDSol.ReadOnly = true;
            txnEgresosHDol.ReadOnly = true;
            txnEgresosHSol.ReadOnly = true;
            txnGBancarioDDol.ReadOnly = true;
            txnGBancarioDSol.ReadOnly = true;
            txnGBancarioHDol.ReadOnly = true;
            txnGBancarioHSol.ReadOnly = true;
            txnIngresosDDol.ReadOnly = true;
            txnIngresosDSol.ReadOnly = true;
            txnIngresosHDol.ReadOnly = true;
            txnIngresosHSol.ReadOnly = true;
            txnTotalDDol.ReadOnly = true;
            txnTotalDSol.ReadOnly = true;
            txnTotalHDol.ReadOnly = true;
            txnTotalHSol.ReadOnly = true;
            
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error en el LoadView.", ex); }
      }

      public void ClearItem()
      {
         try
         {
            errorProviderTransferencia.Clear();

            BSItemsEgresos.DataSource = null;
            BSItemsEgresos.ResetBindings(true);

            BSItemsIngresos.DataSource = null;
            BSItemsIngresos.ResetBindings(true);

            BSItemsGastosBancarios.DataSource = null;
            BSItemsGastosBancarios.ResetBindings(true);

         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error en ClearItem.", ex); }
      }
      public void GetItem()
      {
         try
         {
            errorProviderTransferencia.Clear();

            if (Presenter.Item != null)
            {
               if (dtpTRAN_Fecha.NSFecha.HasValue)
               {
                  Presenter.Item.TRAN_Fecha = dtpTRAN_Fecha.NSFecha;
               }
               else
               {
                  Presenter.Item.TRAN_Fecha = null;
               }
               if (!String.IsNullOrEmpty(txtTRAN_Glosa.Text))
               {
                  Presenter.Item.TRAN_Glosa = txtTRAN_Glosa.Text;
               }
               else
               {
                  Presenter.Item.TRAN_Glosa = null;
               }
            }
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error en GetItem.", ex); }
      }
      public void SetItem()
      {
         try
         {
            if (Presenter.Item != null)
            {
               if (Presenter.Item.TRAN_Codigo > 0) { txtTRAN_Codigo.Text = Presenter.Item.TRAN_Codigo.ToString(); }
               if (Presenter.Item.TRAN_Fecha.HasValue) { dtpTRAN_Fecha.NSFecha = Presenter.Item.TRAN_Fecha; }
               if (!String.IsNullOrEmpty(Presenter.Item.TRAN_Glosa)) { txtTRAN_Glosa.Text = Presenter.Item.TRAN_Glosa; }

               BSItemsEgresos.DataSource = Presenter.Item.ListEgresos;
               BSItemsEgresos.ResetBindings(false);

               BSItemsIngresos.DataSource = Presenter.Item.ListIngresos;
               BSItemsIngresos.ResetBindings(false);

               BSItemsGastosBancarios.DataSource = Presenter.Item.ListGastosBancarios;
               BSItemsGastosBancarios.ResetBindings(false);

               CalcularDiferencias();

               tabTransferencias.SelectedTab = pageGenerales;
               HashFormulario = Infrastructure.Client.FormClose.FormValidateChanges.iniciarComparacionFormulario(this);
            }
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error en SetItem.", ex); }
      }
      public void EnabledItem(Boolean x_opcion = true)
      {
         try
         {
            btnCalcular.Enabled = x_opcion;
            tsbtnNuevoGastosBancarios.Enabled = x_opcion;
            tsbtnNuevoEgresos.Enabled = x_opcion;
            tsbtnNuevoIngresos.Enabled = x_opcion;

            txtTRAN_Glosa.ReadOnly = !x_opcion;
            dtpTRAN_Fecha.Enabled = x_opcion;

            btnGuardar.Enabled = x_opcion;


            this.grdItemsEgresos.Columns["Edit"].IsVisible = false;
            this.grdItemsEgresos.Columns["Delete"].IsVisible = false;

            this.grdItemsIngresos.Columns["Edit"].IsVisible = false;
            this.grdItemsIngresos.Columns["Delete"].IsVisible = false;

            this.grdItemsGastosBancarios.Columns["Edit"].IsVisible = false;
            this.grdItemsGastosBancarios.Columns["Delete"].IsVisible = false;

         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error en EnabledItem.", ex); }
      }

      public void ShowValidation()
      {
         try
         {
            Infrastructure.Client.FormClose.FormShowErrorProvider<Entities.Transferencia>.Validate(Presenter.Item, this, errorProviderTransferencia);
            Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Presenter.Title, "Existen campos obligatorios, revise los detalles.", Presenter.Item.MensajeError);
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error en ShowValidation.", ex); }
      }
      #endregion

      #region [ Metodos ]

      private void FormatGridEgresos()
      {
         try
         {
            Telerik.WinControls.UI.Localization.RadGridLocalizationProvider.CurrentProvider = new Infrastructure.WinForms.Controls.MySpanishRadGridLocalizationProvider();
            this.grdItemsEgresos.Columns.Clear();
            this.grdItemsEgresos.AllowAddNewRow = false;

            GridViewCommandColumn commandColumn = new GridViewCommandColumn();
            commandColumn.Name = "Edit";
            commandColumn.HeaderText = "Editar";
            commandColumn.DefaultText = "Editar";
            commandColumn.UseDefaultText = true;
            this.grdItemsEgresos.Columns.Add(commandColumn);
            this.grdItemsEgresos.Columns["Edit"].AllowSort = false;
            this.grdItemsEgresos.Columns["Edit"].AllowFiltering = false;

            commandColumn = new GridViewCommandColumn();
            commandColumn.Name = "Delete";
            commandColumn.HeaderText = "Eliminar";
            commandColumn.DefaultText = "Eliminar";
            commandColumn.UseDefaultText = true;
            this.grdItemsEgresos.Columns.Add(commandColumn);
            this.grdItemsEgresos.Columns["Delete"].AllowSort = false;
            this.grdItemsEgresos.Columns["Delete"].AllowFiltering = false;

            this.grdItemsEgresos.Columns.Add("CUBA_NroCuenta", "Cta. Banco", "CUBA_NroCuenta");
            this.grdItemsEgresos.Columns.Add("TIPO_MND", "Moneda", "TIPO_MND");
            this.grdItemsEgresos.Columns.Add("Monto", "Monto", "Monto");
            this.grdItemsEgresos.Columns["Monto"].FormatString = "{0:#,###,##0.00}";
            this.grdItemsEgresos.Columns["Monto"].TextAlignment = ContentAlignment.MiddleRight;
            this.grdItemsEgresos.Columns.Add("MOVI_TipoCambio", "Tipo Cambio", "MOVI_TipoCambio");
            this.grdItemsEgresos.Columns.Add("Oficina_Operacion", "Oficina / Nro Operación", "Oficina_Operacion");
            this.grdItemsEgresos.Columns.Add("Flujo", "Flujo", "Flujo");
            this.grdItemsEgresos.Columns.Add("MOVI_Codigo", "Cod. Movimiento", "MOVI_Codigo");

            /* Propiedades Finales */
            grdItemsEgresos.ReadOnly = true;
            grdItemsEgresos.ShowFilteringRow = false;
            grdItemsEgresos.EnableFiltering = false;
            grdItemsEgresos.MasterTemplate.EnableFiltering = false;
            grdItemsEgresos.EnableGrouping = false;
            grdItemsEgresos.MasterTemplate.EnableGrouping = false;
            grdItemsEgresos.EnableSorting = false;
            grdItemsEgresos.MasterTemplate.EnableCustomSorting = false;
            grdItemsEgresos.AutoGenerateColumns = false;

            grdItemsEgresos.BestFitColumns();
            //Infrastructure.WinForms.Controls.GridAutoFit.Fit(grdItemsEgresos);
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, Infrastructure.Aspect.Constants.Mensajes.FormatDataGridView + " (Grid Egresos)", ex); }
      }

      private void FormatGridIngresos()
      {
         try
         {
            Telerik.WinControls.UI.Localization.RadGridLocalizationProvider.CurrentProvider = new Infrastructure.WinForms.Controls.MySpanishRadGridLocalizationProvider();
            this.grdItemsIngresos.Columns.Clear();
            this.grdItemsIngresos.AllowAddNewRow = false;

            GridViewCommandColumn commandColumn;
            commandColumn = new GridViewCommandColumn();
            commandColumn.Name = "Edit";
            commandColumn.HeaderText = "Editar";
            commandColumn.DefaultText = "Editar";
            commandColumn.UseDefaultText = true;
            this.grdItemsIngresos.Columns.Add(commandColumn);
            this.grdItemsIngresos.Columns["Edit"].AllowSort = false;
            this.grdItemsIngresos.Columns["Edit"].AllowFiltering = false;

            commandColumn = new GridViewCommandColumn();
            commandColumn.Name = "Delete";
            commandColumn.HeaderText = "Eliminar";
            commandColumn.DefaultText = "Eliminar";
            commandColumn.UseDefaultText = true;
            this.grdItemsIngresos.Columns.Add(commandColumn);
            this.grdItemsIngresos.Columns["Delete"].AllowSort = false;
            this.grdItemsIngresos.Columns["Delete"].AllowFiltering = false;

            this.grdItemsIngresos.Columns.Add("CUBA_NroCuenta", "Cta. Banco", "CUBA_NroCuenta");
            this.grdItemsIngresos.Columns.Add("TIPO_MND", "Moneda", "TIPO_MND");
            this.grdItemsIngresos.Columns.Add("Monto", "Monto", "Monto");
            this.grdItemsIngresos.Columns["Monto"].FormatString = "{0:#,###,##0.00}";
            this.grdItemsIngresos.Columns["Monto"].TextAlignment = ContentAlignment.MiddleRight;
            this.grdItemsIngresos.Columns.Add("MOVI_TipoCambio", "Tipo Cambio", "MOVI_TipoCambio");
            this.grdItemsIngresos.Columns.Add("Oficina_Operacion", "Oficina / Nro Operación", "Oficina_Operacion");
            this.grdItemsIngresos.Columns.Add("Flujo", "Flujo", "Flujo");
            this.grdItemsIngresos.Columns.Add("MOVI_Codigo", "Cod. Movimiento", "MOVI_Codigo");

            /* Propiedades Finales */
            grdItemsIngresos.ReadOnly = true;
            grdItemsIngresos.ShowFilteringRow = false;
            grdItemsIngresos.EnableFiltering = false;
            grdItemsIngresos.MasterTemplate.EnableFiltering = false;
            grdItemsIngresos.EnableGrouping = false;
            grdItemsIngresos.MasterTemplate.EnableGrouping = false;
            grdItemsIngresos.EnableSorting = false;
            grdItemsIngresos.MasterTemplate.EnableCustomSorting = false;
            grdItemsIngresos.AutoGenerateColumns = false;

            grdItemsIngresos.BestFitColumns();
            //Infrastructure.WinForms.Controls.GridAutoFit.Fit(grdItemsIngresos);
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, Infrastructure.Aspect.Constants.Mensajes.FormatDataGridView + " (Grid Ingresos)", ex); }
      }

      private void FormatGridGastosBancarios()
      {
         try
         {
            Telerik.WinControls.UI.Localization.RadGridLocalizationProvider.CurrentProvider = new Infrastructure.WinForms.Controls.MySpanishRadGridLocalizationProvider();
            this.grdItemsGastosBancarios.Columns.Clear();
            this.grdItemsGastosBancarios.AllowAddNewRow = false;

            GridViewCommandColumn commandColumn = new GridViewCommandColumn();
            commandColumn.Name = "Edit";
            commandColumn.HeaderText = "Editar";
            commandColumn.DefaultText = "Editar";
            commandColumn.UseDefaultText = true;
            this.grdItemsGastosBancarios.Columns.Add(commandColumn);
            this.grdItemsGastosBancarios.Columns["Edit"].AllowSort = false;
            this.grdItemsGastosBancarios.Columns["Edit"].AllowFiltering = false;

            commandColumn = new GridViewCommandColumn();
            commandColumn.Name = "Delete";
            commandColumn.HeaderText = "Eliminar";
            commandColumn.DefaultText = "Eliminar";
            commandColumn.UseDefaultText = true;
            this.grdItemsGastosBancarios.Columns.Add(commandColumn);
            this.grdItemsGastosBancarios.Columns["Delete"].AllowSort = false;
            this.grdItemsGastosBancarios.Columns["Delete"].AllowFiltering = false;

            this.grdItemsGastosBancarios.Columns.Add("GBAN_Codigo", "Código", "GBAN_Codigo");
            this.grdItemsGastosBancarios.Columns.Add("TIPO_MND", "Moneda", "TIPO_MND");
            this.grdItemsGastosBancarios.Columns.Add("GBAN_MontoDebe", "Debe", "GBAN_MontoDebe");
            this.grdItemsGastosBancarios.Columns["GBAN_MontoDebe"].FormatString = "{0:#,###,##0.00}";
            this.grdItemsGastosBancarios.Columns["GBAN_MontoDebe"].TextAlignment = ContentAlignment.MiddleRight;
            this.grdItemsGastosBancarios.Columns.Add("GBAN_MontoHaber", "Haber", "GBAN_MontoHaber");
            this.grdItemsGastosBancarios.Columns["GBAN_MontoHaber"].FormatString = "{0:#,###,##0.00}";
            this.grdItemsGastosBancarios.Columns["GBAN_MontoHaber"].TextAlignment = ContentAlignment.MiddleRight;
            this.grdItemsGastosBancarios.Columns.Add("GBAN_TipoCambio", "Tipo Cambio", "GBAN_TipoCambio");
            this.grdItemsGastosBancarios.Columns["GBAN_TipoCambio"].FormatString = "{0:#,###,##0.00}";
            this.grdItemsGastosBancarios.Columns["GBAN_TipoCambio"].TextAlignment = ContentAlignment.MiddleRight;
            //this.grdItemsGastosBancarios.Columns.Add("Oficina", "Nro. Operación", "Oficina");
            //this.grdItemsGastosBancarios.Columns.Add("Flujo", "Flujo", "Flujo");

            /* Propiedades Finales */
            grdItemsGastosBancarios.ReadOnly = true;
            grdItemsGastosBancarios.ShowFilteringRow = false;
            grdItemsGastosBancarios.EnableFiltering = false;
            grdItemsGastosBancarios.MasterTemplate.EnableFiltering = false;
            grdItemsGastosBancarios.EnableGrouping = false;
            grdItemsGastosBancarios.MasterTemplate.EnableGrouping = false;
            grdItemsGastosBancarios.EnableSorting = false;
            grdItemsGastosBancarios.MasterTemplate.EnableCustomSorting = false;
            grdItemsGastosBancarios.AutoGenerateColumns = false;

            grdItemsGastosBancarios.BestFitColumns();
            //Infrastructure.WinForms.Controls.GridAutoFit.Fit(grdItemsGastosBancarios);
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, Infrastructure.Aspect.Constants.Mensajes.FormatDataGridView + " (Grid Gastos Bancarios)", ex); }
      }

      #region Ingresos

      private void NuevoIngresos()
      {
         try
         {
            if (Presenter.NuevoIngresos())
            {
               BSItemsIngresos.DataSource = Presenter.Item.ListIngresos;
               BSItemsIngresos.ResetBindings(false);
               grdItemsIngresos.BestFitColumns();
               navItemsIngresos.BindingSource = BSItemsIngresos;
               CalcularDiferencias();
            }
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error agregando movimientos de Ingresos.", ex); }
      }

      private void EditarIngresos()
      {
         try
         {
            if (BSItemsIngresos.Current != null)
            {
               Entities.Movimiento _movimiento = (BSItemsIngresos.Current as Entities.Movimiento);
               if (Presenter.EditarIngreso(ref _movimiento))
               {
                  BSItemsIngresos.ResetBindings(false);
                  grdItemsIngresos.BestFitColumns();
                  navItemsIngresos.BindingSource = BSItemsIngresos;
                  CalcularDiferencias();
               }
            }
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error editando un Movimiento de Ingreso.", ex); }
      }

      #endregion

      #region Egresos

      private void NuevoEgresos()
      {
         try
         {
            if (Presenter.NuevoEgresos())
            {
               BSItemsEgresos.DataSource = Presenter.Item.ListEgresos;
               BSItemsEgresos.ResetBindings(false);
               grdItemsEgresos.BestFitColumns();
               navItemsEgresos.BindingSource = BSItemsEgresos;
               CalcularDiferencias();
            }
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error agregando movimientos de Egresos.", ex); }
      }

      private void EditarEgresos()
      {
         try
         {
            if (BSItemsEgresos.Current != null)
            {
               Entities.Movimiento _movimiento = (BSItemsEgresos.Current as Entities.Movimiento);
               if (Presenter.EditarEgreso(ref _movimiento))
               {
                  BSItemsEgresos.ResetBindings(false);
                  grdItemsEgresos.BestFitColumns();
                  navItemsEgresos.BindingSource = BSItemsEgresos;
                  CalcularDiferencias();
               }
            }
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error editando un Movimiento de Egreso.", ex); }
      }

      #endregion

      #region Gastos Bancarios

      private void NuevoGastoBancario()
      {
         try
         {
            if (Presenter.NuevoGastoBancario())
            {
               BSItemsGastosBancarios.DataSource = Presenter.Item.ListGastosBancarios;
               BSItemsGastosBancarios.ResetBindings(false);
               grdItemsGastosBancarios.BestFitColumns();
               navItemsGastosBancarios.BindingSource = BSItemsGastosBancarios;
               CalcularDiferencias();
            }
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error agregando un gasto bancario.", ex); }
      }

      private void EditarGastosBancarios()
      {
         try
         {
            if (BSItemsGastosBancarios.Current != null)
            {
               Entities.GastosBancarios _gbancario = (BSItemsGastosBancarios.Current as Entities.GastosBancarios);
               if (Presenter.EditarGastoBancarios(ref _gbancario))
               {
                  BSItemsGastosBancarios.ResetBindings(false);
                  grdItemsGastosBancarios.BestFitColumns();
                  navItemsGastosBancarios.BindingSource = BSItemsGastosBancarios;
                  CalcularDiferencias();
               }
            }
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error editando un gasto bancario.", ex); }
      }

      #endregion

      private void CalcularDiferencias()
      {
         try
         {
            if (Presenter.Item != null)
            {
               Decimal _ingresosDSol = 0, _gbancarioDSol = 0;
               Decimal _ingresosDDol = 0, _gbancarioDDol = 0;
               Decimal _egresosHSol = 0, _gbancarioHSol = 0;
               Decimal _egresosHDol = 0, _gbancarioHDol = 0;
               //Decimal _ingresosDol = 0, _egresosDol = 0, _gbdebeDol = 0, _gbhaberDol = 0;
               if (Presenter.Item.ListEgresos != null && Presenter.Item.ListEgresos.Count > 0)
               {
                  /*
                   * Egresos 
                   */
                  foreach (Movimiento item in Presenter.Item.ListEgresos)
                  {
                     if (item.TIPO_CodMND.Equals(Infrastructure.Aspect.Constants.Util.getMoneda(Infrastructure.Aspect.Constants.TMoneda.Soles)))
                     {
                        _egresosHSol += item.Monto;
                        _egresosHDol += item.Monto / item.MOVI_TipoCambio.Value;
                     }
                     else if (item.TIPO_CodMND.Equals(Infrastructure.Aspect.Constants.Util.getMoneda(Infrastructure.Aspect.Constants.TMoneda.Dolares)))
                     {
                        _egresosHSol += item.Monto * item.MOVI_TipoCambio.Value;
                        _egresosHDol += item.Monto;
                     }
                  }
               }
               if (Presenter.Item.ListIngresos != null && Presenter.Item.ListIngresos.Count > 0)
               {
                  /*
                   * Ingresos
                   */
                  foreach (Movimiento item in Presenter.Item.ListIngresos)
                  {
                     if (item.TIPO_CodMND.Equals(Infrastructure.Aspect.Constants.Util.getMoneda(Infrastructure.Aspect.Constants.TMoneda.Soles)))
                     {
                        _ingresosDSol += item.Monto;
                        _ingresosDDol += item.Monto / item.MOVI_TipoCambio.Value;
                     }
                     else if (item.TIPO_CodMND.Equals(Infrastructure.Aspect.Constants.Util.getMoneda(Infrastructure.Aspect.Constants.TMoneda.Dolares)))
                     {
                        _ingresosDSol += item.Monto * item.MOVI_TipoCambio.Value;
                        _ingresosDDol += item.Monto;
                     }
                  }
               }
               if (Presenter.Item.ListGastosBancarios != null && Presenter.Item.ListGastosBancarios.Count > 0)
               {
                  foreach (GastosBancarios item in Presenter.Item.ListGastosBancarios)
                  {
                     if (item.TIPO_CodMND.Equals(Infrastructure.Aspect.Constants.Util.getMoneda(Infrastructure.Aspect.Constants.TMoneda.Soles)))
                     {
                        _gbancarioDSol += item.GBAN_MontoDebe;
                        _gbancarioDDol += item.GBAN_MontoDebe / item.GBAN_TipoCambio;
                        _gbancarioHSol += item.GBAN_MontoHaber;
                        _gbancarioHDol += item.GBAN_MontoHaber / item.GBAN_TipoCambio;
                     }
                     else if (item.TIPO_CodMND.Equals(Infrastructure.Aspect.Constants.Util.getMoneda(Infrastructure.Aspect.Constants.TMoneda.Dolares)))
                     {
                        _gbancarioDSol += item.GBAN_MontoDebe * item.GBAN_TipoCambio;
                        _gbancarioDDol += item.GBAN_MontoDebe;
                        _gbancarioHSol += item.GBAN_MontoHaber * item.GBAN_TipoCambio;
                        _gbancarioHDol += item.GBAN_MontoHaber;
                     }
                  }
               }

               txnIngresosDSol.Value = _ingresosDSol;
               txnIngresosDDol.Value = _ingresosDDol;
               txnEgresosHSol.Value = _egresosHSol;
               txnEgresosHDol.Value = _egresosHDol;

               txnGBancarioDDol.Value = _gbancarioDDol;
               txnGBancarioDSol.Value = _gbancarioDSol;
               txnGBancarioHDol.Value = _gbancarioHDol;
               txnGBancarioHSol.Value = _gbancarioHSol;

               txnTotalDDol.Value = _ingresosDDol + _gbancarioDDol;
               txnTotalDSol.Value = _ingresosDSol + _gbancarioDSol;
               txnTotalHDol.Value = _egresosHDol + _gbancarioHDol;
               txnTotalHSol.Value = _egresosHSol + _gbancarioHSol;

               txnDiferenciaDSol.Value = txnTotalHSol.Value - txnTotalDSol.Value; txnDiferenciaDSol.Visible = txnDiferenciaDSol.Value > 0;
               txnDiferenciaHSol.Value = txnTotalDSol.Value - txnTotalHSol.Value; txnDiferenciaHSol.Visible = txnDiferenciaHSol.Value > 0;

               txnDiferenciaDDol.Value = txnTotalHDol.Value - txnTotalDDol.Value; txnDiferenciaDDol.Visible = txnDiferenciaDDol.Value > 0;
               txnDiferenciaHDol.Value = txnTotalDDol.Value - txnTotalHDol.Value; txnDiferenciaHDol.Visible = txnDiferenciaHDol.Value > 0;
               
               Presenter.Item.Diferencia = txnTotalDSol.Value - txnTotalHSol.Value;
            }
         }
         catch (Exception)
         { throw; }
      }

      #endregion

      #region [ Metodos Documentos ]

      #endregion

      #region [ Eventos ]

      private void btnGuardar_Click(object sender, EventArgs e)
      {
         try
         {
            if (Presenter.Guardar(true))
            {
               this.FormClosing -= MView_FormClosing;
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
            errorProviderTransferencia.Dispose();
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

      private void tsbtnNuevoGastosBancarios_Click(object sender, EventArgs e)
      {
         NuevoGastoBancario();
      }

      private void btnNuevoEgresos_Click(object sender, EventArgs e)
      {
         NuevoEgresos();
      }

      private void btnNuevoIngresos_Click(object sender, EventArgs e)
      {
         NuevoIngresos();
      }

      private void grdItemsGastosBancarios_CommandCellClick(object sender, EventArgs e)
      {
         try
         {
            if (sender is Telerik.WinControls.UI.GridCommandCellElement)
            {
               switch ((((Telerik.WinControls.UI.GridCommandCellElement)(sender)).CommandButton).TextElement.Text)
               {
                  case "Editar":
                     EditarGastosBancarios();
                     break;
                  case "Eliminar":
                     if (BSItemsEgresos.Current != null)
                     {
                        if (Presenter.EliminarGastosBancarios(BSItemsGastosBancarios.Current as Entities.GastosBancarios))
                        {
                           BSItemsGastosBancarios.ResetBindings(false);
                           CalcularDiferencias();
                        }
                     }
                     break;
               }
            }
         }
         catch (Exception)
         { }
      }

      private void grdItemsGastosBancarios_CellFormatting(object sender, CellFormattingEventArgs e)
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

      private void grdItemsIngresos_CommandCellClick(object sender, EventArgs e)
      {
         try
         {
            if (sender is Telerik.WinControls.UI.GridCommandCellElement)
            {
               switch ((((Telerik.WinControls.UI.GridCommandCellElement)(sender)).CommandButton).TextElement.Text)
               {
                  case "Editar":
                     EditarIngresos();
                     break;
                  case "Eliminar":
                     if (BSItemsIngresos.Current != null)
                     {
                        if (Presenter.EliminarIngresos(BSItemsIngresos.Current as Entities.Movimiento))
                        {
                           BSItemsIngresos.ResetBindings(false);
                           CalcularDiferencias();
                        }
                     }
                     break;
               }
            }
         }
         catch (Exception)
         { }
      }

      private void grdItemsIngresos_CellFormatting(object sender, CellFormattingEventArgs e)
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

      private void grdItemsEgresos_CommandCellClick(object sender, EventArgs e)
      {
         try
         {
            if (sender is Telerik.WinControls.UI.GridCommandCellElement)
            {
               switch ((((Telerik.WinControls.UI.GridCommandCellElement)(sender)).CommandButton).TextElement.Text)
               {
                  case "Editar":
                     EditarEgresos();
                     break;
                  case "Eliminar":
                     if (BSItemsEgresos.Current != null)
                     {
                        if (Presenter.EliminarEgresos(BSItemsEgresos.Current as Entities.Movimiento))
                        {
                           BSItemsEgresos.ResetBindings(false);
                           CalcularDiferencias();
                        }
                     }
                     break;
               }
            }
         }
         catch (Exception)
         { }
      }

      private void grdItemsEgresos_CellFormatting(object sender, CellFormattingEventArgs e)
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
   }
}