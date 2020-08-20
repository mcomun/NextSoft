using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Delfin.Entities;
using Infrastructure.Aspect.Collections;
using Infrastructure.Aspect.Constants;
using Telerik.WinControls.UI;

namespace Delfin.Principal
{
   public partial class CAJ002IngresosEgresosDView : Form
   {
      #region [ Variables ]

      public enum TInicio
      {
         Nuevo = 0, Editar = 1
      }

      #endregion

      #region [ Formulario ]

      public CAJ002IngresosEgresosDView(Infrastructure.Aspect.Constants.TipoMovimientoCtaCte x_TMovimiento)
      {
         InitializeComponent();
         try
         {
            TipoMovimiento = x_TMovimiento;

            btnBuscar.Click += btnBuscar_Click;
            btnAceptar.Click += btnAceptar_Click;
            cmbTIPE_Codigo.SelectedIndexChanged += cmbTIPE_Codigo_SelectedIndexChanged;
            txaENTC_Codigo.Enabled = false;
            txtHBL.MaxLength = 50;
            txtMBL.MaxLength = 50;

            txaENTC_Codigo.SelectedItemChanged += txaENTC_Codigo_SelectedItemChanged;
            dtpMOVI_FecEmision.SelectedDateChanged += dtpMOVI_FecEmision_SelectedDateChanged;



            BSItems = new BindingSource();
            grdItemsDocumentos.DataSource = BSItems;
            navItems.BindingSource = BSItems;
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha Ocurrido un error iniciando", ex); }
      }
      
      public void LoadView()
      {
         try
         {
            txaENTC_Codigo.LoadControl(Presenter.ContainerService, Delfin.Controls.TiposEntidad.TIPE_Cliente, null, null, true);
            cmbTIPE_Codigo.LoadControl(Presenter.ContainerService, "Tipo de Entidad", "< Sel. Tipo de Entidad >", ListSortDirection.Ascending);
            txaNVIA_Codigo.LoadControl(Presenter.ContainerService);
            cmbTIPO_CodTDO.LoadControl(Presenter.ContainerService, "Tipo Documento", "TDO", "< Sel. Tipo Documento >", ListSortDirection.Ascending);
            switch (TipoMovimiento)
            {
               case Infrastructure.Aspect.Constants.TipoMovimientoCtaCte.Ingresos:
                  cmbTipoDocumento.LoadControl("Ayuda de Tipo", Delfin.Controls.Tipos.ComboBoxConstantes.OConstantes.TipoDocumentoIngresos, "< Todos >", ListSortDirection.Ascending);
                  lblENTC_Codigo.Text = "Entidad";
                  break;
               case Infrastructure.Aspect.Constants.TipoMovimientoCtaCte.Egresos:
                  cmbTipoDocumento.LoadControl("Ayuda de Tipo", Delfin.Controls.Tipos.ComboBoxConstantes.OConstantes.TipoDocumentoEgresos, "< Sel. Tipo Documento >", ListSortDirection.Ascending);
                  lblENTC_Codigo.Text = "Entidad";
                  cmbTipoDocumento.SelectedIndex = 1;
                  break;
               default:
                  break;
            }
            dtpMOVI_FecEmision.NSFecha = new DateTime(Presenter.Client.GetFecha().Year, 1, 1);
            cmbTIPE_Codigo.TipoEntidadSelectedValue = Entidad.TIPE_Codigo;
            txaENTC_Codigo.SetEntidad(Entidad);
            FormatGridDocumentos();
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha Ocurrido un error iniciando", ex); }
      }

      #endregion

      #region [ Propiedades ]

      public CAJ002IngresosEgresosPresenter Presenter { get; set; }
      public Infrastructure.Aspect.Constants.TipoMovimientoCtaCte TipoMovimiento { get; set; }
      public ObservableCollection<Entities.DetCtaCte> Items { get; set; }
      public Entities.Entidad Entidad { get; set; }
      public Entities.CuentasBancarias CuentasBancarias { get; set; }

      public BindingSource BSItems { get; set; }
      public TInicio TipoInicio { get; set; }

      #endregion

      #region [ ICUS002MView ]

      #endregion

      #region [ Metodos ]

      private void FormatGridDocumentos(CAJ002IngresosEgresosPresenter.TBusqueda x_opcion = CAJ002IngresosEgresosPresenter.TBusqueda.Base)
      {
         try
         {
            Telerik.WinControls.UI.Localization.RadGridLocalizationProvider.CurrentProvider = new Infrastructure.WinForms.Controls.MySpanishRadGridLocalizationProvider();
            this.grdItemsDocumentos.Columns.Clear();
            this.grdItemsDocumentos.AllowAddNewRow = false;

            GridViewCheckBoxColumn checkboxColum;
            checkboxColum = new GridViewCheckBoxColumn();
            checkboxColum.Name = "Seleccionar";
            checkboxColum.HeaderText = "Seleccionar";
            checkboxColum.FieldName = "Seleccionar";
            grdItemsDocumentos.Columns.Add(checkboxColum);
            grdItemsDocumentos.Columns["Seleccionar"].Width = 90;
            grdItemsDocumentos.Columns["Seleccionar"].ReadOnly = false;
            switch (x_opcion)
            {
               case CAJ002IngresosEgresosPresenter.TBusqueda.Base:
                  this.grdItemsDocumentos.Columns.Add("TIPO_TDO", "Tipo Doc.", "TIPO_TDO");
                  this.grdItemsDocumentos.Columns.Add("CCCT_Serie", "Serie", "CCCT_Serie");
                  this.grdItemsDocumentos.Columns.Add("CCCT_Numero", "Número", "CCCT_Numero");
                  this.grdItemsDocumentos.Columns.Add("CCCT_FechaEmision", "Fecha", "CCCT_FechaEmision");

                  this.grdItemsDocumentos.Columns.Add("OV_OP", "OV / OP", "OV_OP");
                  this.grdItemsDocumentos.Columns.Add("MBL_HBL", "MBL / HBL", "MBL_HBL");
                  this.grdItemsDocumentos.Columns.Add("NAVE_Nombre", "Nave Viaje", "NAVE_Nombre");

                  this.grdItemsDocumentos.Columns.Add("TIPO_MND", "Moneda", "TIPO_MND");
                  this.grdItemsDocumentos.Columns.Add("CCCT_Monto", "Monto de Factura", "CCCT_Monto");

                  this.grdItemsDocumentos.Columns.Add("TipoCtaCte", "Tipo", "TipoCtaCte");
                  this.grdItemsDocumentos.Columns.Add("CCCT_Pendiente", "Pendiente", "CCCT_Pendiente");
                  this.grdItemsDocumentos.Columns.Add("CCCT_MontoDetraccion", "Detracción", "CCCT_MontoDetraccion");

                  if (Presenter.TMovimiento == TipoMovimientoCtaCte.Ingresos)
                  {
                     this.grdItemsDocumentos.Columns.Add("SERV_Codigo", "Cod. Servicio", "SERV_Codigo");
                     this.grdItemsDocumentos.Columns.Add("SERV_Nombre_SPA", "Nombre Servicio", "SERV_Nombre_SPA");
                     grdItemsDocumentos.Columns["SERV_Codigo"].ReadOnly = true;
                     grdItemsDocumentos.Columns["SERV_Nombre_SPA"].ReadOnly = true;
                  }
                  this.grdItemsDocumentos.Columns.Add("CCCT_Glosa", "Concepto", "CCCT_Glosa");
                  grdItemsDocumentos.Columns["CCCT_Glosa"].ReadOnly = true;
                  this.grdItemsDocumentos.Columns.Add("CCCT_Codigo", "Nro. Transaccion", "CCCT_Codigo");
                  if (Presenter.TMovimiento == TipoMovimientoCtaCte.Egresos)
                  {
                     this.grdItemsDocumentos.Columns.Add("CCCT_ProvAsumeDetraccion_Text", "Asume Detracción", "CCCT_ProvAsumeDetraccion_Text");
                     grdItemsDocumentos.Columns["CCCT_ProvAsumeDetraccion_Text"].ReadOnly = true;
                  }
                  this.grdItemsDocumentos.Columns.Add("MODULO", "Origen", "MODULO");
                  grdItemsDocumentos.Columns["MODULO"].ReadOnly = true;
                  grdItemsDocumentos.Columns["MODULO"].IsVisible = false;
                  grdItemsDocumentos.Columns["TIPO_TDO"].ReadOnly = true;
                  grdItemsDocumentos.Columns["CCCT_Serie"].ReadOnly = true;
                  grdItemsDocumentos.Columns["CCCT_Serie"].WrapText = true;
                  grdItemsDocumentos.Columns["CCCT_Numero"].ReadOnly = true;
                  grdItemsDocumentos.Columns["CCCT_Numero"].WrapText = true;
                  grdItemsDocumentos.Columns["CCCT_Numero"].TextAlignment = ContentAlignment.MiddleRight;
                  grdItemsDocumentos.Columns["OV_OP"].ReadOnly = true;
                  grdItemsDocumentos.Columns["NAVE_Nombre"].ReadOnly = true;
                  grdItemsDocumentos.Columns["TIPO_MND"].ReadOnly = true;
                  grdItemsDocumentos.Columns["CCCT_Monto"].ReadOnly = true;
                  grdItemsDocumentos.Columns["CCCT_Monto"].TextAlignment = ContentAlignment.MiddleRight;
                  grdItemsDocumentos.Columns["CCCT_Monto"].FormatString = "{0:#,###,##0.00}";
                  grdItemsDocumentos.Columns["CCCT_Codigo"].ReadOnly = true;
                  grdItemsDocumentos.Columns["CCCT_Codigo"].TextAlignment = ContentAlignment.MiddleRight;
                  grdItemsDocumentos.Columns["CCCT_FechaEmision"].ReadOnly = true;
                  grdItemsDocumentos.Columns["CCCT_FechaEmision"].FormatString = "{0:dd/MM/yyyy}";
                  grdItemsDocumentos.Columns["CCCT_Pendiente"].ReadOnly = true;
                  grdItemsDocumentos.Columns["CCCT_Pendiente"].TextAlignment = ContentAlignment.MiddleRight;
                  grdItemsDocumentos.Columns["CCCT_Pendiente"].FormatString = "{0:#,###,##0.00}";
                  grdItemsDocumentos.Columns["CCCT_MontoDetraccion"].ReadOnly = true;
                  grdItemsDocumentos.Columns["CCCT_MontoDetraccion"].TextAlignment = ContentAlignment.MiddleRight;
                  grdItemsDocumentos.Columns["CCCT_MontoDetraccion"].FormatString = "{0:#,###,##0.00}";
                  grdItemsDocumentos.Columns["MBL_HBL"].ReadOnly = true;
                  grdItemsDocumentos.Columns["TipoCtaCte"].ReadOnly = true;
                  grdItemsDocumentos.Columns["TipoCtaCte"].TextAlignment = ContentAlignment.MiddleCenter;
                  grdItemsDocumentos.Columns["TipoCtaCte"].FormatString = "{0:#,###,##0.00}";


                  break;
               case CAJ002IngresosEgresosPresenter.TBusqueda.Liquidaciones:
                  this.grdItemsDocumentos.Columns.Add("TIPO_TDO", "Tipo Doc.", "TIPO_TDO");
                  this.grdItemsDocumentos.Columns.Add("CCCT_FechaEmision", "Fecha", "CCCT_FechaEmision");
                  this.grdItemsDocumentos.Columns.Add("CCCT_Codigo", "Nro. Transaccion", "CCCT_Codigo");
                  this.grdItemsDocumentos.Columns.Add("TIPO_MND_Simbolo", "Moneda", "TIPO_MND_Simbolo");
                  this.grdItemsDocumentos.Columns.Add("CCCT_Monto", "Monto de Liquidación", "CCCT_Monto");                  

                  grdItemsDocumentos.Columns["TIPO_TDO"].ReadOnly = true;
                  grdItemsDocumentos.Columns["CCCT_FechaEmision"].ReadOnly = true;
                  grdItemsDocumentos.Columns["CCCT_Codigo"].ReadOnly = true;
                  grdItemsDocumentos.Columns["CCCT_Monto"].ReadOnly = true;

                  grdItemsDocumentos.Columns["CCCT_Monto"].ReadOnly = true;
                  grdItemsDocumentos.Columns["CCCT_Monto"].TextAlignment = ContentAlignment.MiddleRight;
                  grdItemsDocumentos.Columns["CCCT_Monto"].FormatString = "{0:#,###,##0.00}";
                  grdItemsDocumentos.Columns["CCCT_Codigo"].TextAlignment = ContentAlignment.MiddleRight;
                  grdItemsDocumentos.Columns["CCCT_FechaEmision"].ReadOnly = true;
                  grdItemsDocumentos.Columns["CCCT_FechaEmision"].FormatString = "{0:dd/MM/yyyy}";
                  break;
            }

            grdItemsDocumentos.BestFitColumns();

            /* Propiedades Finales */
            grdItemsDocumentos.ReadOnly = false;
            grdItemsDocumentos.ShowFilteringRow = true;
            grdItemsDocumentos.EnableFiltering = true;
            grdItemsDocumentos.MasterTemplate.EnableFiltering = true;
            grdItemsDocumentos.EnableGrouping = false;
            grdItemsDocumentos.MasterTemplate.EnableGrouping = false;
            grdItemsDocumentos.EnableSorting = true;
            grdItemsDocumentos.MasterTemplate.EnableCustomSorting = false;
            grdItemsDocumentos.AutoGenerateColumns = false;
            grdItemsDocumentos.AllowCellContextMenu = false;
            grdItemsDocumentos.AllowColumnHeaderContextMenu = false;

            //Infrastructure.WinForms.Controls.GridAutoFit.Fit(grdItemsDocumentos);
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, Infrastructure.Aspect.Constants.Mensajes.FormatDataGridView + " (Grid Servicios)", ex); }
      }

      private void Aceptar()
      {
         try
         {
            ObservableCollection<DetCtaCte> listDetCtaCte = Items.Where(Doc => Doc.Seleccionar).ToObservableCollection();
            String msg = "";
            foreach (DetCtaCte item in listDetCtaCte)
            {
               if (item.CCCT_MontoDetraccion > 0 && !item.DCCT_PagoDetraccion.Value && !item.CCCT_ProvAsumeDetraccion)
               {
                  msg += String.Format("* El registro: {1} tiene detracción.{0}", Environment.NewLine, item.CCCT_Codigo);
               }
            }
            if (msg.Length > 0)
            {
               if (
                  Infrastructure.WinForms.Controls.Dialogos.MostrarMensajePregunta(Presenter.Title,
                     "Existen registros que tienen detracción ¿Desea cancelar las detracciones? [Si: Cancelar detracciones] - [No: cancelar la diferencia]",
                     msg, Infrastructure.WinForms.Controls.Dialogos.LabelBoton.Si_No) ==
                  System.Windows.Forms.DialogResult.Yes)
               {
                  foreach (DetCtaCte item in listDetCtaCte)
                  {
                     if (item.CCCT_MontoDetraccion > 0 && !item.DCCT_PagoDetraccion.Value && !item.CCCT_ProvAsumeDetraccion)
                     {
                        if(item.TIPO_CodMND.Equals(Infrastructure.Aspect.Constants.Util.getMoneda(TMoneda.Soles)))
                        {
                           if ((item.CCCT_Pendiente - item.CCCT_MontoDetraccion) > 0)
                           { 
                              //item.CCCT_Saldo = item.CCCT_Pendiente - item.CCCT_MontoDetraccion;
                              item.CCCT_Saldo = item.CCCT_MontoDetraccion;
                           }
                           else if ((item.CCCT_Pendiente - item.CCCT_MontoDetraccion) == 0)
                           { item.CCCT_Saldo = item.CCCT_MontoDetraccion;  }
                           else if ((item.CCCT_Pendiente - item.CCCT_MontoDetraccion) < 0)
                           { item.CCCT_Saldo = item.CCCT_Pendiente; }
                        }
                        else if (item.TIPO_CodMND.Equals(Infrastructure.Aspect.Constants.Util.getMoneda(TMoneda.Dolares)))
                        {
                           //Decimal? _monto = item.CCCT_Pendiente - Math.Round(Convert.ToDecimal(item.CCCT_MontoDetraccion / item.CCCT_TipoCambio), 2, MidpointRounding.AwayFromZero);
                           Decimal? _monto = Math.Round(Convert.ToDecimal(item.CCCT_MontoDetraccion / item.CCCT_TipoCambio), 2, MidpointRounding.AwayFromZero);
                           if (_monto.HasValue && _monto > 0)
                           { 
                              //item.CCCT_Saldo = item.CCCT_Pendiente - Math.Round(Convert.ToDecimal(item.CCCT_MontoDetraccion / item.CCCT_TipoCambio), 2, MidpointRounding.AwayFromZero); 
                              item.CCCT_Saldo = Math.Round(Convert.ToDecimal(item.CCCT_MontoDetraccion / item.CCCT_TipoCambio), 2, MidpointRounding.AwayFromZero); 
                           }
                           else if (_monto.HasValue && _monto == 0)
                           { 
                              item.CCCT_Saldo = Math.Round(Convert.ToDecimal(item.CCCT_MontoDetraccion / item.CCCT_TipoCambio), 2, MidpointRounding.AwayFromZero); 
                           }
                           else if (_monto.HasValue && _monto < 0)
                           { item.CCCT_Saldo = item.CCCT_Pendiente; }
                        }
                        if (item.CCCT_TipoCambio.HasValue) { item.DCCT_TipoCambio = item.CCCT_TipoCambio.Value; }
                        item.CCCT_Pendiente = item.CCCT_Saldo;
                        item.DCCT_PagoDetraccion = true;
                     }
                  }
               }
               else
               {
                  foreach (DetCtaCte item in listDetCtaCte)
                  {
                     if (item.CCCT_MontoDetraccion > 0 && !item.DCCT_PagoDetraccion.Value && !item.CCCT_ProvAsumeDetraccion)
                     {
                         Decimal _TipoCambio = (item.CCCT_TipoCambio == null ? (Decimal)1 : Convert.ToDecimal(item.CCCT_TipoCambio));
                         Decimal _MontoDetraccionDol = (Decimal)0.00;
                         Decimal _MontoPendienteFinal = (Decimal)0.00;
                         if (CuentasBancarias.TIPO_CodMND == Infrastructure.Aspect.Constants.Util.getMoneda(Infrastructure.Aspect.Constants.TMoneda.Dolares))
                         {
                             _MontoDetraccionDol = Math.Round((item.CCCT_MontoDetraccion / _TipoCambio), 2, MidpointRounding.AwayFromZero);
                             if (item.TIPO_CodMND == Infrastructure.Aspect.Constants.Util.getMoneda(Infrastructure.Aspect.Constants.TMoneda.Dolares))
                             { 
                                 item.CCCT_Pendiente = ((item.CCCT_Pendiente == null ? (Decimal)0.00 : Convert.ToDecimal(item.CCCT_Pendiente)) - _MontoDetraccionDol); 
                             }
                             else if (item.TIPO_CodMND == Infrastructure.Aspect.Constants.Util.getMoneda(Infrastructure.Aspect.Constants.TMoneda.Soles))
                             { 
                                 _MontoPendienteFinal = ((item.CCCT_Pendiente == null ? (Decimal)0.00 : Convert.ToDecimal(item.CCCT_Pendiente)) / _TipoCambio);
                                 item.CCCT_Pendiente = (_MontoPendienteFinal - _MontoDetraccionDol);
                             }
                         }
                         else if (CuentasBancarias.TIPO_CodMND == Infrastructure.Aspect.Constants.Util.getMoneda(Infrastructure.Aspect.Constants.TMoneda.Soles))
                         {
                             if (item.TIPO_CodMND == Infrastructure.Aspect.Constants.Util.getMoneda(Infrastructure.Aspect.Constants.TMoneda.Soles))
                             {
                                 item.CCCT_Pendiente = ((item.CCCT_Pendiente == null ? (Decimal)0.00 : Convert.ToDecimal(item.CCCT_Pendiente)) - item.CCCT_MontoDetraccion); 
                             }
                             else if (item.TIPO_CodMND == Infrastructure.Aspect.Constants.Util.getMoneda(Infrastructure.Aspect.Constants.TMoneda.Dolares))
                             {
                                 _MontoPendienteFinal = ((item.CCCT_Pendiente == null ? (Decimal)0.00 : Convert.ToDecimal(item.CCCT_Pendiente)) * _TipoCambio);
                                 item.CCCT_Pendiente = (_MontoPendienteFinal - item.CCCT_MontoDetraccion);
                             }
                         }
                        //item.CCCT_Pendiente = item.CCCT_Pendiente - item.CCCT_MontoDetraccion;
                        item.DCCT_PagoDetraccion = false;
                     }
                  }
               }
            }
         }
         catch (Exception)
         { throw; }
      }

      private void AceptarLiquidacion()
      {
         try
         {
            ObservableCollection<DetCtaCte> listDetCtaCte = Items.Where(Doc => Doc.Seleccionar).ToObservableCollection();
            Items = new ObservableCollection<DetCtaCte>();
            String msg = "";
            if (listDetCtaCte != null && listDetCtaCte.Count > 0)
            {
               Presenter.Item.Liquidacion = new Liquidacion();
               Presenter.Item.Liquidacion.EMPR_Codigo = listDetCtaCte[0].EMPR_Codigo;
               Presenter.Item.Liquidacion.LIQU_Codigo = listDetCtaCte[0].LIQU_Codigo;
               Presenter.Item.EsLiquidacion = true;
               foreach (Entities.DetCtaCte item in listDetCtaCte)
               {
                  ObservableCollection<Infrastructure.Aspect.DataAccess.DataAccessFilterSQL> _listFilters = new ObservableCollection<Infrastructure.Aspect.DataAccess.DataAccessFilterSQL>();
                  _listFilters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@psinEMPR_Codigo", FilterValue = Delfin.Controls.Entorno.ItemEmpresa.EMPR_Codigo, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.Int16, FilterSize = 2 });
                  _listFilters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@pvchLIQU_Codigo", FilterValue = item.LIQU_Codigo, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.Varchar, FilterSize = 20 });

                  String _procedure = "CAJ_CCCTSS_TodosPorLiquidacion";
                  Items = Items.Concat(Presenter.Client.GetAllDetCtaCteFilter(_procedure, _listFilters)).ToObservableCollection();
               }
               foreach (Entities.DetCtaCte item in Items)
               {
                  item.Seleccionar = true;
               }
               Aceptar();
            }
         }
         catch (Exception)
         { throw; }
      }
      #endregion

      #region [ Eventos ]

      private void btnAceptar_Click(object sender, EventArgs e)
      {
         try
         {
            if (Items != null && Items.Count > 0)
            {
               if (Items.Where(Doc => Doc.Seleccionar).ToObservableCollection().Count > 0)
               {
                  switch (TipoMovimiento)
                  {
                     case TipoMovimientoCtaCte.Ingresos:
                        Aceptar();
                        break;
                     case TipoMovimientoCtaCte.Egresos:
                        switch (Presenter.TipoBusqueda)
                        {
                           case CAJ002IngresosEgresosPresenter.TBusqueda.Base:
                              Aceptar();
                              break;
                           case CAJ002IngresosEgresosPresenter.TBusqueda.Liquidaciones:
                              AceptarLiquidacion();
                              break;
                           default:
                              break;
                        }
                        break;
                     default:
                        break;
                  }

                  grdItemsDocumentos.EndEdit();
                  DialogResult = System.Windows.Forms.DialogResult.OK;
                  this.Close();
               }
               else { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Presenter.Title, "No ha seleccionado ningun registro"); }
            }
            else
            {
               Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Presenter.Title, "No ha seleccionado ningun registro"); ;
            }
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha Ocurrido un error", ex); }
      }

      private void cmbTIPE_Codigo_SelectedIndexChanged(object sender, EventArgs e)
      {
         try
         {
            if (cmbTIPE_Codigo.TipoEntidadSelectedItem != null)
            {
               txaENTC_Codigo.Enabled = true;
               txaENTC_Codigo.TiposEntidad = Delfin.Controls.EntidadClear.getTipoEntidadEnum(cmbTIPE_Codigo.TipoEntidadSelectedItem.TIPE_Codigo);
               txaENTC_Codigo.Clear();
            }
            else { txaENTC_Codigo.Enabled = false; }
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al cambiar el tipo de entidad.", ex); }
      }

      private void btnBuscar_Click(object sender, EventArgs e)
      {
         try
         {
            Int32? ENCT_Codigo = null; if (txaENTC_Codigo.SelectedItem != null) { ENCT_Codigo = txaENTC_Codigo.SelectedItem.ENTC_Codigo; }
            DateTime? Fecha = null; if (dtpMOVI_FecEmision.NSFecha.HasValue) { Fecha = dtpMOVI_FecEmision.NSFecha; }
            String TipoDocumento = null; if (cmbTipoDocumento.ConstantesSelectedItem != null) { TipoDocumento = cmbTipoDocumento.ConstantesSelectedItem.CONS_CodTipo; }
            String MBL = null; if (!String.IsNullOrEmpty(txtMBL.Text)) { MBL = txtMBL.Text; }
            String HBL = null; if (!String.IsNullOrEmpty(txtHBL.Text)) { HBL = txtHBL.Text; }

            String F_TIPO_CodTDO = null; if (cmbTIPO_CodTDO.TiposSelectedItem != null) { F_TIPO_CodTDO = cmbTIPO_CodTDO.TiposSelectedItem.TIPO_CodTipo; }
            String F_CCCT_Serie = null; if (!String.IsNullOrEmpty(txtCCCT_Serie.Text)) { F_CCCT_Serie = txtCCCT_Serie.Text; }
            String F_CCCT_Numero = null; if (!String.IsNullOrEmpty(txtCCCT_Numero.Text)) { F_CCCT_Numero = txtCCCT_Numero.Text; }
            

            Boolean x_TipoDocumento = true;
            if (TipoMovimiento == TipoMovimientoCtaCte.Egresos)
            { if (String.IsNullOrEmpty(TipoDocumento)) { x_TipoDocumento = false; } }
            //grdItemsDocumentos.Columns["MODULO"].IsVisible = x_TipoDocumento;

            if (ENCT_Codigo.HasValue && Fecha.HasValue && x_TipoDocumento)
            {               
               ObservableCollection<Infrastructure.Aspect.DataAccess.DataAccessFilterSQL> _listFilters = new ObservableCollection<Infrastructure.Aspect.DataAccess.DataAccessFilterSQL>();
               _listFilters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@psinEMPR_Codigo", FilterValue = Delfin.Controls.Entorno.ItemEmpresa.EMPR_Codigo, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.Int16, FilterSize = 2 });
               _listFilters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@pintENTC_Codigo", FilterValue = ENCT_Codigo, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.Int32, FilterSize = 4 });
               _listFilters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@pdtmCCCT_FechaEmision", FilterValue = Fecha, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.DateTime, FilterSize = 8 });
               _listFilters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@TipoDocumento", FilterValue = TipoDocumento, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.Varchar, FilterSize = 8 });
               _listFilters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@HBL", FilterValue = HBL, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.Varchar, FilterSize = 50 });
               _listFilters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@MBL", FilterValue = MBL, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.Varchar, FilterSize = 50 });

               _listFilters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@pchrTIPO_CodTDO", FilterValue = F_TIPO_CodTDO, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.Varchar, FilterSize = 3 });
               _listFilters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@pvchCCCT_Serie", FilterValue = F_CCCT_Serie, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.Varchar, FilterSize = 20 });
               _listFilters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@pvchCCCT_Numero", FilterValue = F_CCCT_Numero, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.Varchar, FilterSize = 20 });

               if (txaNVIA_Codigo.Value != null)
               { _listFilters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@pintNVIA_Codigo", FilterValue = (txaNVIA_Codigo.Value as Entities.NaveViaje).NVIA_Codigo, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.Int32, FilterSize = 4 }); }

               String _procedure = "CAJ_CCCTSS_TodosPendientes";
               switch (TipoMovimiento)
               {
                  case TipoMovimientoCtaCte.Ingresos:
                     _procedure = "CAJ_CCCTSS_TodosPendientesIngresos";
                     break;
                  case TipoMovimientoCtaCte.Egresos:
                     _procedure = "CAJ_CCCTSS_TodosPendientesEgresos";
                     if (cmbTipoDocumento.ConstantesSelectedItem.CONS_CodTipo.Equals("LI"))
                     {
                        FormatGridDocumentos(CAJ002IngresosEgresosPresenter.TBusqueda.Liquidaciones);
                        Presenter.TipoBusqueda = CAJ002IngresosEgresosPresenter.TBusqueda.Liquidaciones;
                        Presenter.Item.EsLiquidacion = true;
                     }
                     else
                     {
                        FormatGridDocumentos(CAJ002IngresosEgresosPresenter.TBusqueda.Base);
                        Presenter.TipoBusqueda = CAJ002IngresosEgresosPresenter.TBusqueda.Base;
                        Presenter.Item.EsLiquidacion = false;
                     }
                     break;
               }
               Items = Presenter.Client.GetAllDetCtaCteFilter(_procedure, _listFilters);

               if (Presenter.Item.ListDetCtaCte != null && Presenter.Item.ListDetCtaCte.Count > 0)
               {
                  foreach (Entities.DetCtaCte idetCtaCte in Presenter.Item.ListDetCtaCte)
                  {
                     Entities.DetCtaCte _delete =
                        Items.Where(Del => Del.CCCT_Codigo == idetCtaCte.CCCT_Codigo).FirstOrDefault();
                     if (_delete != null)
                     {
                        Items.Remove(_delete);
                     }
                  }
               }
               BSItems.DataSource = Items;
               BSItems.ResetBindings(true);
               grdItemsDocumentos.BestFitColumns();
            }
            else
            {
               String msg = "";
               if (!ENCT_Codigo.HasValue) { msg += "* Seleccione una Entidad" + Environment.NewLine; }
               if (!Fecha.HasValue) { msg += "* Seleccione una fecha" + Environment.NewLine; }
               if (String.IsNullOrEmpty(TipoDocumento)) { msg += "* Seleccione el tipo de busqueda" + Environment.NewLine; }
               Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Presenter.Title, "No puede realizar la busqueda, faltan datos, haga click en el boton detalles", msg);
            }
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha Ocurrido al consultar", ex); }
      }

      private void txaENTC_Codigo_SelectedItemChanged(object sender, EventArgs e)
      {
         try
         {
            txaNVIA_Codigo.ENTC_CodTranportista = null;

            if (cmbTIPE_Codigo.TipoEntidadSelectedItem != null && cmbTIPE_Codigo.TipoEntidadSelectedItem.TIPE_Codigo == Delfin.Controls.EntidadClear.GetCodigoTipoEntidad(Delfin.Controls.TiposEntidad.TIPE_Transportista))
            {
               if (txaENTC_Codigo.SelectedItem != null)
               {
                  txaNVIA_Codigo.ENTC_CodTranportista = txaENTC_Codigo.SelectedItem.ENTC_Codigo;
                  txaNVIA_Codigo.FechaDesde = dtpMOVI_FecEmision.NSFecha;
               }
               else
               {
                  txaNVIA_Codigo.ENTC_CodTranportista = null;
                  txaNVIA_Codigo.FechaDesde = null;
               }
            }
         }
         catch (Exception) { }
      }

      #region [ Metodos de Grilla ]

      private void tsmMarcarTodos_Click(object sender, EventArgs e)
      {
         try
         {
            foreach (Telerik.WinControls.UI.GridViewRowInfo _fila in grdItemsDocumentos.Rows)
            { _fila.Cells["Seleccionar"].Value = true; }
            this.grdItemsDocumentos.EndEdit();
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al marcar todos.", ex); }

      }
      private void tsmDesmarcarTodos_Click(object sender, EventArgs e)
      {
         try
         {
            foreach (Telerik.WinControls.UI.GridViewRowInfo _fila in grdItemsDocumentos.Rows)
            { _fila.Cells["Seleccionar"].Value = false; }
            this.grdItemsDocumentos.EndEdit();
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al desmarcar todos.", ex); }
      }
      private void tsmMarcarSeleccionados_Click(object sender, EventArgs e)
      {
         try
         {
            foreach (Telerik.WinControls.UI.GridViewRowInfo _fila in this.grdItemsDocumentos.SelectedRows)
            { _fila.Cells["Seleccionar"].Value = true; }
            this.grdItemsDocumentos.EndEdit();
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al marcar los seleccionados.", ex); }

      }
      private void tsmDesmarcarSeleccionados_Click(object sender, EventArgs e)
      {
         try
         {
            foreach (Telerik.WinControls.UI.GridViewRowInfo _fila in this.grdItemsDocumentos.SelectedRows)
            { _fila.Cells["Seleccionar"].Value = false; }
            this.grdItemsDocumentos.EndEdit();
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al desmarcar los seleccionados.", ex); }
      }

      private void grdItems_MouseClick(object sender, MouseEventArgs e)
      {
         if (e.Button == MouseButtons.Right)
         {
            Point pt = new Point();
            pt = grdItemsDocumentos.PointToScreen(e.Location);
            CMSseleccion.Show(pt);
         }
      }

      private void dtpMOVI_FecEmision_SelectedDateChanged(object sender, EventArgs e)
      {
         try
         {
            txaNVIA_Codigo.FechaDesde = dtpMOVI_FecEmision.NSFecha;
         }
         catch (Exception)
         { }
      }


      /*
        private void grdItems_ValueChanged(object sender, EventArgs e)
      {
         if (this.grdTarjetasDia.ActiveEditor is RadCheckBoxEditor)
         {
            Console.WriteLine(this.grdTarjetasDia.CurrentCell.RowIndex);
            Console.WriteLine(this.grdTarjetasDia.ActiveEditor.Value);
         }
      }
       */
      #endregion

      #endregion

   }
}
