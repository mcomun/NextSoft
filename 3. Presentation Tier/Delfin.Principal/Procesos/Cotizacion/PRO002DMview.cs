using System;
using System.Collections;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using Delfin.Entities;
using Infrastructure.Aspect.Constants;
using Infrastructure.Aspect.Collections;
using Infrastructure.Client.FormClose;
using Infrastructure.WinFormsControls;
using TiposEntidad = Delfin.Controls.TiposEntidad;


namespace Delfin.Principal
{
    public partial class PRO002DMview : Form, IPRO002DMview
    {
      #region [ Variables ]
      private bool Closing = false;
      #endregion

      #region [ Formulario ]
      public PRO002DMview()
      {
          InitializeComponent();
          try
          {
              btnAgregar.Click += btnAgregar_Click;
              Load += PRO001DTarifa_Load;
              CbTipoEntidad.SelectedValueChanged += CbTipoEntidad_SelectedValueChanged;
          }
          catch (Exception ex)
          { Dialogos.MostrarMensajeError(Presenter.Title, Mensajes.ConstructorView, ex); }
      }
      #endregion

      #region [ Propiedades ]
      public PRO002Presenter Presenter { get; set; }
      private Hashtable HashFormulario { get; set; }
      #endregion

      #region [ IPRO001DView ]
      public void LoadView()
      {
         try
         {
            ENTC_CodigoEntidad.ContainerService = Presenter.ContainerService;
             ENTC_CodigoEntidad.TipoEntidad = TiposEntidad.TIPE_Transportista;

             CbTipoEntidad.DataSource = Presenter.ListTiposEntidad;
             CbTipoEntidad.ValueMember = "TIPE_Codigo";
             CbTipoEntidad.DisplayMember = "TIPE_Descripcion";

             Presenter.ListConstantes = Presenter.ListConstantes.Where(data => data.CONS_CodTipo != "004").ToObservableCollection();
             CbBase.DataSource = Presenter.ListConstantes;
             CbBase.ValueMember = "CONS_CodTipo";
             CbBase.DisplayMember = "CONS_Desc_SPA";

             CbTipo.DataSource = Presenter.ListConstantesTipo;
             CbTipo.ValueMember = "CONS_CodTipo";
             CbTipo.DisplayMember = "CONS_Desc_SPA";

             CbOrigen.DataSource = Presenter.ListZonas;
             CbOrigen.ValueMember = "TIPO_CodZONOrigen";
             CbOrigen.DisplayMember = "TIPO_Desc1";

             CbDestino.DataSource = Presenter.ListZonasDestino;
             CbDestino.ValueMember = "TIPO_CodZONDestino";
             CbDestino.DisplayMember = "TIPO_Desc1";
         }
         catch (Exception ex)
         { Dialogos.MostrarMensajeError(Presenter.Title, Mensajes.LoadView, ex); }
      }

      #region [ Detalle Tarifario ]
      public void ClearItem()
      {
          try
          {
              CbTipoEntidad.SelectedIndex = 0;
              ENTC_CodigoEntidad.ClearValue();
              txtVenta20.Text = @"0";
              txtVentaSada20.Text = @"0";
              txtVenta40.Text = @"0";
              txtVentaSada40.Text = @"0";
              txtHBL.Text = @"0";
              txtHBLSada.Text = @"0";

              CbBase.SelectedIndex = 0;
              txtMinimo.Text = @"0";
              txtCostoAduTransp.Text = @"0";

              txtCostoAduTransp.Text = @"0";
              CbTipo.SelectedIndex = 0;
              CbBase.SelectedIndex = 0;
              txtMinimo.Text = @"0";
              CbOrigen.SelectedIndex = 0;
              CbDestino.SelectedIndex = 0;
              chkRoundtrip.Checked = false;
          }
          catch (Exception ex)
          { Dialogos.MostrarMensajeError(Presenter.Title, Mensajes.ClearItem, ex); }
      }
      public void GetItem()
      {
          try
          {
              switch (Presenter.TipoTarifario)
              {
                  case "L": /* Logistico */
                      Presenter.ItemDet_Cotizacion.CTAR_Tipo = "L";

                      /* Tipo Entidad */
                      if (CbTipoEntidad.SelectedValue != null)
                      {
                          Presenter.ItemDet_Cotizacion.TIPE_Codigo = short.Parse(CbTipoEntidad.SelectedValue.ToString());
                          Presenter.ItemDet_Cotizacion.TIPE_Descripcion = CbTipoEntidad.Text;
                      }
                      else
                      {
                          Presenter.ItemDet_Cotizacion.TIPE_Codigo = null;
                      }

                      /* Entidad Codigo */
                      if (ENTC_CodigoEntidad.Value != null)
                      {
                          if ((Convert.ToInt32(ENTC_CodigoEntidad.Value.ENTC_Codigo)) > 0)
                          {
                              Presenter.ItemDet_Cotizacion.ENTC_Codigo = (Convert.ToInt32(ENTC_CodigoEntidad.Value.ENTC_Codigo));
                              Presenter.ItemDet_Cotizacion.ENTC_RazonSocial = ENTC_CodigoEntidad.Value.ENTC_RazonSocial;
                          }
                          else
                          {
                              Presenter.ItemDet_Cotizacion.ENTC_Codigo = null;
                              Presenter.ItemDet_Cotizacion.ENTC_RazonSocial = null;
                          }
                      }

                      /* ST 20 */
                      if (txtVenta20.Value > 0)
                      {
                          Presenter.ItemDet_Cotizacion.DCOT_Venta20 = txtVenta20.Value; 
                          Presenter.ItemDet_Cotizacion.DCOT_Profit = null;
                      }
                      else
                      {
                          Presenter.ItemDet_Cotizacion.DCOT_Venta20 = 0;
                          Presenter.ItemDet_Cotizacion.DCOT_Profit = null;
                      }

                      /* ST 20 Sada */
                      if (txtVentaSada20.Value > 0)
                      {
                          Presenter.ItemDet_Cotizacion.DCOT_VentaSada20 = txtVentaSada20.Value;
                          Presenter.ItemDet_Cotizacion.DCOT_Profit = null;
                      }
                      else
                      {
                          Presenter.ItemDet_Cotizacion.DCOT_VentaSada20 = 0;
                          Presenter.ItemDet_Cotizacion.DCOT_Profit = null;
                      }

                      /* ST 40 */
                      if (txtVenta40.Value > 0)
                      {
                          Presenter.ItemDet_Cotizacion.DCOT_Venta40 = txtVenta40.Value;
                          Presenter.ItemDet_Cotizacion.DCOT_Profit = null;
                      }
                      else
                      {
                          Presenter.ItemDet_Cotizacion.DCOT_Venta40 = 0;
                          Presenter.ItemDet_Cotizacion.DCOT_Profit = null;
                      }

                      /* ST 40 SADA */
                      if (txtVentaSada40.Value > 0)
                      {
                          Presenter.ItemDet_Cotizacion.DCOT_VentaSada40 = txtVentaSada40.Value;
                          Presenter.ItemDet_Cotizacion.DCOT_Profit = null;
                      }
                      else
                      {
                          Presenter.ItemDet_Cotizacion.DCOT_VentaSada40 = 0;
                          Presenter.ItemDet_Cotizacion.DCOT_Profit = null;
                      }

                      if (Presenter.ItemDet_Cotizacion.TIPE_Codigo != null && Presenter.ItemDet_Cotizacion.TIPE_Codigo.Value.ToString(CultureInfo.InvariantCulture).Equals("13")) /* solo si es maritimo */
                      {
                          /* HBL */
                          if (txtHBL.Value > 0)
                          {
                              Presenter.ItemDet_Cotizacion.DCOT_VentaHBL = txtHBL.Value;
                              Presenter.ItemDet_Cotizacion.DCOT_Profit = null;
                          }
                          else
                          {
                              Presenter.ItemDet_Cotizacion.DCOT_VentaHBL = 0;
                              Presenter.ItemDet_Cotizacion.DCOT_Profit = null;
                          }
                          /* HBL SADA */
                          if (txtHBLSada.Value > 0)
                          {
                              Presenter.ItemDet_Cotizacion.DCOT_VentaSadaHBL = txtHBLSada.Value;
                              Presenter.ItemDet_Cotizacion.DCOT_Profit = null;
                          }
                          else
                          {
                              Presenter.ItemDet_Cotizacion.DCOT_VentaSadaHBL = 0;
                              Presenter.ItemDet_Cotizacion.DCOT_Profit = null;
                          }
                          Presenter.ItemDet_Cotizacion.CONS_TabBas = "BSL";
                          Presenter.ItemDet_Cotizacion.CONS_CodBas = "004"; // HBL
                      }

                      break;
                  case "A": /* Aduana */
                      Presenter.TempItemDet_Cotizacion.CTAR_Tipo = "A";
                      Presenter.TempItemDet_Cotizacion.DCOT_Profit = null;
                      /* Valor */
                      if (txtCostoAduTransp.Value > 0)
                      {
                          Presenter.TempItemDet_Cotizacion.DCOT_Venta = txtCostoAduTransp.Value;
                          Presenter.TempItemDet_Cotizacion.DCOT_VentaSada = 0;// Presenter.TempItemDet_Cotizacion.DCOT_Venta;
                      }
                      else
                      {
                          Presenter.TempItemDet_Cotizacion.DCOT_VentaSada = 0;
                          Presenter.TempItemDet_Cotizacion.DCOT_Venta = 0;
                      }

                      /* Base */
                      if (CbBase.SelectedValue != null)
                      {
                          Presenter.TempItemDet_Cotizacion.CONS_CodBas = CbBase.SelectedValue.ToString();
                          Presenter.TempItemDet_Cotizacion.CONS_TabBas = "BSL";
                          Presenter.TempItemDet_Cotizacion.CONS_Desc_SPA = CbBase.Text;
                      }
                      else
                      {
                          Presenter.TempItemDet_Cotizacion.CONS_CodBas = null;
                          Presenter.TempItemDet_Cotizacion.CONS_TabBas = null;
                          Presenter.TempItemDet_Cotizacion.CONS_CodTipo = null;
                      }

                      /* Minimo */
                      Presenter.TempItemDet_Cotizacion.DCOT_Minimo = txtMinimo.Value > 0 ? txtMinimo.Value : 0;
                      break;
                  case "T": /* Transporte */
                      Presenter.TempItemDet_Cotizacion.CTAR_Tipo = "T";
                      Presenter.TempItemDet_Cotizacion.DCOT_Profit = null;
                      /* Tipo :) */
                      if (CbTipo.SelectedValue != null)
                      {
                          Presenter.TempItemDet_Cotizacion.CONS_CodTRA = CbTipo.SelectedValue.ToString();
                          Presenter.TempItemDet_Cotizacion.CONS_TabTRA = "TRA";
                          Presenter.TempItemDet_Cotizacion.CONS_Desc_TRA = CbTipo.Text;
                      }
                      else
                      {
                          Presenter.TempItemDet_Cotizacion.CONS_CodTRA = null;
                          Presenter.TempItemDet_Cotizacion.CONS_TabTRA = null;
                      }

                      /* Origen :) */
                      if (CbOrigen.SelectedValue != null)
                      {
                          Presenter.TempItemDet_Cotizacion.TIPO_CodZONOrigen = CbOrigen.SelectedValue.ToString();
                          Presenter.TempItemDet_Cotizacion.TIPO_TabZON = "ZON";
                          Presenter.TempItemDet_Cotizacion.ORIGEN = CbOrigen.Text;
                      }
                      else
                      {
                          Presenter.TempItemDet_Cotizacion.TIPO_CodZONOrigen = null;
                          Presenter.TempItemDet_Cotizacion.TIPO_TabZON = null;
                      }

                      /* Destino :) */
                      if (CbDestino.SelectedValue != null)
                      {
                          Presenter.TempItemDet_Cotizacion.TIPO_CodZONDestino = CbDestino.SelectedValue.ToString();
                          Presenter.TempItemDet_Cotizacion.TIPO_TabZON = "ZON";
                          Presenter.TempItemDet_Cotizacion.DESTINO = CbDestino.Text;
                      }
                      else
                      {
                          Presenter.TempItemDet_Cotizacion.TIPO_CodZONDestino = null;
                          Presenter.TempItemDet_Cotizacion.TIPO_TabZON = null;
                      }

                      /* costo :) */
                      if (txtCostoAduTransp.Value > 0)
                      {
                          Presenter.TempItemDet_Cotizacion.DCOT_Venta = txtCostoAduTransp.Value;
                          Presenter.TempItemDet_Cotizacion.DCOT_VentaSada = 0; //Presenter.TempItemDet_Cotizacion.DCOT_Venta;
                      }
                      else
                      {
                          Presenter.TempItemDet_Cotizacion.DCOT_VentaSada = 0;
                          Presenter.TempItemDet_Cotizacion.DCOT_Venta = 0;
                      }

                      /* Base  :) */
                      if (CbBase.SelectedValue != null)
                      {
                          Presenter.TempItemDet_Cotizacion.CONS_CodBas = CbBase.SelectedValue.ToString();
                          Presenter.TempItemDet_Cotizacion.CONS_TabBas = "BSL";
                          Presenter.TempItemDet_Cotizacion.CONS_Desc_SPA = CbBase.Text;
                      }
                      else
                      {
                          Presenter.TempItemDet_Cotizacion.CONS_CodBas = null;
                          Presenter.TempItemDet_Cotizacion.CONS_TabBas = null;
                      }

                      /* RoundTrip  :) */
                      if (chkRoundtrip.Checked)
                      {
                          Presenter.TempItemDet_Cotizacion.DCOT_Roudtrip = chkRoundtrip.Checked;
                      }
                      else
                      {
                          Presenter.TempItemDet_Cotizacion.DCOT_Roudtrip = null;
                      }
                      break;
              }
          }
          catch (Exception ex)
          { Dialogos.MostrarMensajeError(Presenter.Title, Mensajes.GetItem, ex); }
      }
      public void SetItem()
      {
          try
          {
              switch (Presenter.ItemDet_Cotizacion.CTAR_Tipo)
              {
                  case "L": /* Logistico */
                      Presenter.TipoTarifario = Presenter.ItemDet_Cotizacion.CTAR_Tipo;
                      /* Tipo Entidad */
                      CbTipoEntidad.SelectedValue = Presenter.ItemDet_Cotizacion.TIPE_Codigo.Value;

                      /* Entidad Codigo */
                      if (Presenter.ItemDet_Cotizacion.ENTC_Codigo != null)
                      {
                          ENTC_CodigoEntidad.SetValue(Presenter.ItemDet_Cotizacion.ENTC_Codigo.Value);
                      }

                      /* ST 20 */
                      if (Presenter.ItemDet_Cotizacion.DCOT_Venta20 > 0)
                      {
                          txtVenta20.Value = Presenter.ItemDet_Cotizacion.DCOT_Venta20;
                          txtVenta20.Text = Presenter.ItemDet_Cotizacion.DCOT_Venta20.ToString();
                      }

                      /* ST 20 Sada */
                      if (Presenter.ItemDet_Cotizacion.DCOT_VentaSada20 > 0)
                      {
                          txtVentaSada20.Value = Presenter.ItemDet_Cotizacion.DCOT_VentaSada20;
                          txtVentaSada20.Text = Presenter.ItemDet_Cotizacion.DCOT_VentaSada20.ToString();
                      }

                      /* ST 40 */
                      if (Presenter.ItemDet_Cotizacion.DCOT_Venta40 > 0)
                      {
                          txtVenta40.Value = Presenter.ItemDet_Cotizacion.DCOT_Venta40;
                          txtVenta40.Text = Presenter.ItemDet_Cotizacion.DCOT_Venta40.ToString();
                      }

                      /* ST 40 SADA */
                      if (Presenter.ItemDet_Cotizacion.DCOT_VentaSada40 > 0)
                      {
                          txtVentaSada40.Value = Presenter.ItemDet_Cotizacion.DCOT_VentaSada40;
                          txtVentaSada40.Text = Presenter.ItemDet_Cotizacion.DCOT_VentaSada40.ToString();

                      }

                      if (Presenter.ItemDet_Cotizacion.TIPE_Codigo.Value.ToString().Equals("13")) /* solo si es maritimo */
                      {
                          /* HBL */
                          if (Presenter.ItemDet_Cotizacion.DCOT_VentaHBL > 0)
                          {
                              txtHBL.Value = Presenter.ItemDet_Cotizacion.DCOT_VentaHBL;
                              txtHBL.Text = Presenter.ItemDet_Cotizacion.DCOT_VentaHBL.ToString(); ;
                          }

                          /* HBL SADA */
                          if (Presenter.ItemDet_Cotizacion.DCOT_VentaSadaHBL > 0)
                          {
                              txtHBLSada.Value = Presenter.ItemDet_Cotizacion.DCOT_VentaSadaHBL;
                              txtHBLSada.Text = Presenter.ItemDet_Cotizacion.DCOT_VentaSadaHBL.ToString();
                          }
                      }
                      break;
                  case "A": /* Aduana */
                      Presenter.TipoTarifario = Presenter.ItemDet_Cotizacion.CTAR_Tipo;

                      /* Valor */
                      if (Presenter.ItemDet_Cotizacion.DCOT_Venta > 0)
                      {
                          txtCostoAduTransp.Value = Presenter.ItemDet_Cotizacion.DCOT_Venta;
                          txtCostoAduTransp.Text = Presenter.ItemDet_Cotizacion.DCOT_Venta.ToString();
                      }

                      /* Base */
                      if (!String.IsNullOrEmpty(Presenter.ItemDet_Cotizacion.CONS_CodBas))
                      {
                          CbBase.SelectedValue = Presenter.ItemDet_Cotizacion.CONS_CodBas;
                          Presenter.ItemDet_Cotizacion.CONS_CodTipo = Presenter.ItemDet_Cotizacion.CONS_CodBas;
                      }
                      /* Minimo */
                      if (Presenter.ItemDet_Cotizacion.DCOT_Minimo != null && Presenter.ItemDet_Cotizacion.DCOT_Minimo > 0)
                      {
                          txtMinimo.Value = Presenter.ItemDet_Cotizacion.DCOT_Minimo;
                          txtMinimo.Text = Presenter.ItemDet_Cotizacion.DCOT_Minimo.ToString();
                      }
                      else
                      {
                          Presenter.ItemDet_Cotizacion.DCOT_Minimo = 0;
                      }
                      break;
                  case "T": /* Transporte */
                      Presenter.TipoTarifario = Presenter.ItemDet_Cotizacion.CTAR_Tipo;

                      /* Tipo :) */
                      if (!String.IsNullOrEmpty(Presenter.ItemDet_Cotizacion.CONS_CodTRA))
                      {
                          CbTipo.SelectedValue = Presenter.ItemDet_Cotizacion.CONS_CodTRA;
                      }

                      /* Origen :) */
                      if (!String.IsNullOrEmpty(Presenter.ItemDet_Cotizacion.TIPO_CodZONOrigen))
                      {
                          CbOrigen.TiposSelectedValue  = Presenter.ItemDet_Cotizacion.TIPO_CodZONOrigen;
                      }

                      /* Destino :) */
                      if (!String.IsNullOrEmpty(Presenter.ItemDet_Cotizacion.TIPO_CodZONDestino))
                      {
                         CbDestino.TiposSelectedValue = Presenter.ItemDet_Cotizacion.TIPO_CodZONDestino;
                      }

                      /* costo :) */
                      if (Presenter.ItemDet_Cotizacion.DCOT_Venta != null && Presenter.ItemDet_Cotizacion.DCOT_Venta > 0)
                      {
                          txtCostoAduTransp.Value = Presenter.ItemDet_Cotizacion.DCOT_Venta;
                          txtCostoAduTransp.Text = Presenter.ItemDet_Cotizacion.DCOT_Venta.ToString();
                      }

                      /* Base  :) */
                      if (!String.IsNullOrEmpty(Presenter.ItemDet_Cotizacion.CONS_CodBas))
                      {
                          CbBase.SelectedValue = Presenter.ItemDet_Cotizacion.CONS_CodBas;
                      }

                      /* RoundTrip  :) */
                      if (Presenter.ItemDet_Cotizacion.DCOT_Roudtrip != null && (bool)Presenter.ItemDet_Cotizacion.DCOT_Roudtrip.Value)
                      {
                          chkRoundtrip.Checked = Presenter.ItemDet_Cotizacion.DCOT_Roudtrip.Value;
                      }
                      break;
              }
          }
          catch (Exception ex)
          { Dialogos.MostrarMensajeError(Presenter.Title, Mensajes.SetItem, ex); }
      }
      public void SetInstance(InstanceView x_instance)
      {
          try
          {
              errorProvider1.Dispose();
              ENTC_CodigoEntidad.Enabled = false;
              CbTipoEntidad.Enabled = false;
              //CbBase.Enabled = false;
              //CbTipo.Enabled = false;
              //CbOrigen.Enabled = false;
              //CbDestino.Enabled = false;
              btnAgregar.Enabled = true;
              switch (x_instance)
              {
                  case InstanceView.Default:
                      break;
                  case InstanceView.New:
                      
                      HashFormulario = FormValidateChanges.iniciarComparacionFormulario(this);
                      break;
                  case InstanceView.Edit:
                      if (!String.IsNullOrEmpty(Presenter.ItemCab_Cotizacion.CONS_CodEstado))
                      {
                          btnAgregar.Enabled = Presenter.ItemCab_Cotizacion.CONS_CodEstado.Equals("001");
                      }
                      HashFormulario = FormValidateChanges.iniciarComparacionFormulario(this);
                      break;
                  case InstanceView.Delete:
                      break;
                  case InstanceView.Save:
                      break;
              }
          }
          catch (Exception ex)
          { Dialogos.MostrarMensajeError(Presenter.Title, Mensajes.SetInstanceView, ex); }
      }
      public void ShowValidation()
      {
          try
          {
              Dialogos.MostrarMensajeInformacion(Presenter.Title, "Faltan ingresar datos obligatorios: ", Presenter.ItemDet_Cotizacion.MensajeError, Dialogos.Boton.Detalles);
              FormShowErrorProvider<Det_Cotizacion>.Validate(Presenter.ItemDet_Cotizacion, this, errorProvider1);
          }
          catch (Exception ex)
          { Dialogos.MostrarMensajeError(Presenter.Title, Mensajes.ShowItems, ex); }
      }
      public void GenerarST20_ST40_HBL(String _CTAR_Tipo, Int32? _CTAR_Codigo, Int16? _DTAR_Item )
      {
          try
          {
              int _registros = 0;
              if (CbTipoEntidad.SelectedValue.ToString().Equals("13"))   /* solo si es maritimo */
              {
                  _registros = 3;
              }
              else
              {
                  _registros = 2;
              }
              for (int i = 0; i < _registros; i++)
              {
                 Presenter.NuevoDetalleCotizaciones(_CTAR_Tipo, _CTAR_Codigo, _DTAR_Item, ENTC_CodigoEntidad.Value.ENTC_Codigo);

                  if (i == 2)  /* HBL no tiene PACK_Codigo */
                  {
                      Presenter.TempItemDet_Cotizacion.PACK_Codigo = null;
                  }
                  else
                  {
                      Presenter.TempItemDet_Cotizacion.PACK_Codigo = i == 0 ? 1 : 2; // 1 =>  20 ,  2 => 40    :) 
                  }
                  /* Tipo Entidad */
                  Presenter.TempItemDet_Cotizacion.TIPE_Codigo = short.Parse(CbTipoEntidad.SelectedValue.ToString());

                  /* Entidad */
                  Presenter.TempItemDet_Cotizacion.ENTC_Codigo = (Convert.ToInt32(ENTC_CodigoEntidad.Value.ENTC_Codigo));

                  if (i == 0)
                  {
                      /* ST 20 */
                      Presenter.TempItemDet_Cotizacion.DCOT_Venta = Presenter.ItemDet_Cotizacion.DCOT_Venta20;
                      Presenter.TempItemDet_Cotizacion.DCOT_Costo = Presenter.ItemDet_Cotizacion.DCOT_Costo20;
                      Presenter.TempItemDet_Cotizacion.DCOT_Profit = Presenter.ItemDet_Cotizacion.DCOT_Profit;

                      /* ST 20 Sada */
                      Presenter.TempItemDet_Cotizacion.DCOT_VentaSada = Presenter.ItemDet_Cotizacion.DCOT_VentaSada20;
                      Presenter.TempItemDet_Cotizacion.DCOT_CostoSada = Presenter.ItemDet_Cotizacion.DCOT_CostoSada20;
                      Presenter.TempItemDet_Cotizacion.DCOT_Profit = Presenter.ItemDet_Cotizacion.DCOT_Profit;
                  }
                  else if (i == 1)
                  {
                      /* ST 40 */
                      Presenter.TempItemDet_Cotizacion.DCOT_Venta = Presenter.ItemDet_Cotizacion.DCOT_Venta40;
                      Presenter.TempItemDet_Cotizacion.DCOT_Costo = Presenter.ItemDet_Cotizacion.DCOT_Costo40;
                      Presenter.TempItemDet_Cotizacion.DCOT_Profit = Presenter.ItemDet_Cotizacion.DCOT_Profit;

                      /* ST 40 SADA */
                      Presenter.TempItemDet_Cotizacion.DCOT_VentaSada = Presenter.ItemDet_Cotizacion.DCOT_VentaSada40;
                      Presenter.TempItemDet_Cotizacion.DCOT_CostoSada = Presenter.ItemDet_Cotizacion.DCOT_CostoSada40;
                      Presenter.TempItemDet_Cotizacion.DCOT_Profit = Presenter.ItemDet_Cotizacion.DCOT_Profit;
                  }
                  else if (i == 2)
                  {
                      /* HBL */
                      Presenter.TempItemDet_Cotizacion.DCOT_Venta = Presenter.ItemDet_Cotizacion.DCOT_VentaHBL;
                      Presenter.TempItemDet_Cotizacion.DCOT_Costo = Presenter.ItemDet_Cotizacion.DCOT_CostoHBL;
                      Presenter.TempItemDet_Cotizacion.DCOT_Profit = Presenter.ItemDet_Cotizacion.DCOT_Profit;

                      /* HBL SADA */
                      Presenter.TempItemDet_Cotizacion.DCOT_VentaSada = Presenter.ItemDet_Cotizacion.DCOT_VentaSadaHBL;
                      Presenter.TempItemDet_Cotizacion.DCOT_CostoSada = Presenter.ItemDet_Cotizacion.DCOT_CostoSadaHBL;
                      Presenter.TempItemDet_Cotizacion.DCOT_Profit = Presenter.ItemDet_Cotizacion.DCOT_Profit;
                      Presenter.TempItemDet_Cotizacion.CONS_CodBas = "004";
                      Presenter.TempItemDet_Cotizacion.CONS_TabBas = "BSL";
                  }
                  Presenter.ItemsDet_CotizacionRegistros.Add(Presenter.TempItemDet_Cotizacion);
              }
          }
          catch (Exception ex)
          { Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al agregar el nuevo registro.", ex); }
      }
      public void CerrarVenta()
      {
          try
          {
              Close();
          }
          catch (Exception ex)
          { Dialogos.MostrarMensajeError(Presenter.Title,"Ha ocurrido un error al cerrar la ventana.", ex); }
      }
      #endregion

      #endregion

      #region [ Metodos ]

      #region [ Detalle ]
      public void SetItemST20_ST40( ref ObservableCollection<Det_Cotizacion> x_items)
      {
          try
          {
              if (x_items != null)
              {
                  decimal _TempVenta20 = 0;
                  decimal _TempVentaSada20 = 0;
                  decimal _TempVenta40 = 0;
                  decimal _TempVentaSada40 = 0;
                  Det_Cotizacion _Det_Cotizacion = new Det_Cotizacion();
                  Int32 _Fila = 0;
                  for (int i = 0; i < x_items.Count; i++)
                  {
                      if (((i % 2) == 0) && i == 0)   /* primer registro */
                      {
                          _Det_Cotizacion = new Det_Cotizacion();
                          _Det_Cotizacion = x_items.ElementAt(i);
                          _Fila = 1;
                      }
                      else
                      {
                          _Det_Cotizacion = x_items.ElementAt(i);
                          _Det_Cotizacion.DCOT_Venta20 = _TempVenta20;
                          _Det_Cotizacion.DCOT_VentaSada20 = _TempVentaSada20;
                          _Det_Cotizacion.DCOT_Venta40 = _TempVenta40;
                          _Det_Cotizacion.DCOT_VentaSada40 = _TempVentaSada40;
                      }
                      if (_Det_Cotizacion.PACK_Codigo == 1)
                      {
                          _TempVenta20 = 0;
                          _TempVentaSada20 = 0;
                          _Det_Cotizacion.DCOT_Venta20 = x_items[i].DCOT_Venta;
                          _Det_Cotizacion.DCOT_VentaSada20 = _Det_Cotizacion.DCOT_VentaSada;
                          _TempVenta20 = _Det_Cotizacion.DCOT_Venta20;
                          _TempVentaSada20 = _Det_Cotizacion.DCOT_VentaSada20;
                          _Det_Cotizacion.DCOT_Fila = _Fila;
                      }

                      if (_Det_Cotizacion.PACK_Codigo == 2)
                      {
                          _TempVenta40 = 0;
                          _TempVentaSada40 = 0;
                          _Det_Cotizacion.DCOT_Venta40 = x_items[i].DCOT_Venta;
                          _Det_Cotizacion.DCOT_VentaSada40 = _Det_Cotizacion.DCOT_VentaSada;
                          _TempVenta40 = _Det_Cotizacion.DCOT_Venta40;
                          _TempVentaSada40 = _Det_Cotizacion.DCOT_VentaSada40;

                          if (_Det_Cotizacion.TIPE_Codigo != null && _Det_Cotizacion.TIPE_Codigo.Value.ToString(CultureInfo.InvariantCulture) != "13") /* Maritimo */
                          {

                              _Det_Cotizacion.DCOT_Fila = _Fila;
                              Presenter.ItemsGrillaDet_Cotizacion.Add(_Det_Cotizacion);
                              _Fila++;
                          }
                          else
                          {
                              _Det_Cotizacion.DCOT_Fila = _Fila;
                          }
                      }
                      if (_Det_Cotizacion.TIPE_Codigo != null && _Det_Cotizacion.TIPE_Codigo.Value.ToString(CultureInfo.InvariantCulture).Equals("13")) /* Maritimo */
                      {
                          if (_Det_Cotizacion.PACK_Codigo == null)
                          {
                              _Det_Cotizacion.DCOT_VentaHBL = x_items[i].DCOT_Venta;
                              _Det_Cotizacion.DCOT_VentaSadaHBL = _Det_Cotizacion.DCOT_VentaSada;

                              _Det_Cotizacion.DCOT_Fila = _Fila;
                              Presenter.ItemsGrillaDet_Cotizacion.Add(_Det_Cotizacion);
                              _Fila++;

                          }
                      }
                  }
              }
          }
          catch (Exception ex)
          { Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al agregar el nuevo registro.", ex); }
      }
      #endregion
      #endregion

      #region [ Eventos ]

      #region [ Detalle Tarifario ]
      void btnAgregar_Click(object sender, EventArgs e)
      {
          Presenter.AgregarDetalleCotizacion();
      }
      void PRO001DTarifa_Load(object sender, EventArgs e)
      {
          switch (Presenter.ItemDet_Cotizacion.CTAR_Tipo)
          {
              case "L":  /* Logistico  :) */
                  Text = "Servicio Logístico";
                  tlpTarifarioLogistico.Visible = true;
                  tlpTarifarioAduaneroTransp.Visible = false;
                  Height = 278;

                  break;
              case "A":   /* Aduanero  :) */
                  Text = "Servicio Aduanero";
                  tlpTarifarioLogistico.Visible = false;
                  tlpTarifarioAduaneroTransp.Visible = true;
                  lblCostoAduanero.Text = "Comisión:";
                  tlpTarifarioAduaneroTransp.RowStyles[0].Height = 0;
                  tlpTarifarioAduaneroTransp.RowStyles[1].Height = 27;
                  tlpTarifarioAduaneroTransp.RowStyles[2].Height = 27;
                  tlpTarifarioAduaneroTransp.RowStyles[3].Height = 0;
                  tlpTarifarioAduaneroTransp.RowStyles[4].Height = 0;

                  CbTipo.Visible = false;
                  Height = 223;
                  break;
              case "T":   /* Transporte  :) */
                  Text = "Servicio Transportista";
                  tlpTarifarioLogistico.Visible = false;
                  tlpTarifarioAduaneroTransp.Visible = true;
                  tlpTarifarioAduaneroTransp.RowStyles[0].Height = 27;
                  tlpTarifarioAduaneroTransp.RowStyles[1].Height = 27;
                  tlpTarifarioAduaneroTransp.RowStyles[2].Height = 0;
                  tlpTarifarioAduaneroTransp.RowStyles[3].Height = 27;
                  tlpTarifarioAduaneroTransp.RowStyles[4].Height = 27;
                  lblCostoAduanero.Text = "Flete:";
                  CbTipo.Visible = true;
                  Height = 223;
                  break;
          }
      }
      void CbTipoEntidad_SelectedValueChanged(object sender, EventArgs e)
      {
          try
          {
              /* solo 13 => Agencia Maritima , 14 => Deposito Temporal, 15 => Deposito Vacio */
              if (CbTipoEntidad.SelectedValue != null)
              {
                  switch (CbTipoEntidad.SelectedValue.ToString())
                  {
                      case "13":
                          ENTC_CodigoEntidad.TipoEntidad = TiposEntidad.TIPE_AgenciaMaritima;
                          txtHBL.Enabled = true;
                          txtHBLSada.Enabled = true;
                          break;
                      case "14":
                          ENTC_CodigoEntidad.TipoEntidad = TiposEntidad.TIPE_DepositoTemporal;
                          txtHBL.Enabled = false;
                          txtHBLSada.Enabled = false;
                          break;
                      case "15":
                          ENTC_CodigoEntidad.TipoEntidad = TiposEntidad.TIPE_DepositoVacio;
                          txtHBL.Enabled = false;
                          txtHBLSada.Enabled = false;
                          break;
                  }
              }
          }
          catch (Exception) { }
      }
      #endregion

      #endregion
    }
}
