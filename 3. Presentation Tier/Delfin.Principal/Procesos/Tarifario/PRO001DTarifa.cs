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
    public partial class PRO001DTarifa : Form ,IPRO001DTarifa
    {

      #region [ Variables ]
      private bool Closing = false;
      #endregion

      #region [ Formulario ]
      public PRO001DTarifa()
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
      public PRO001Presenter Presenter { get; set; }
      private Hashtable HashFormulario { get; set; }
      #endregion

      #region [ IPRO001DView ]
      public void LoadView()
      {
         try
         {
            ENTC_CodigoEntidad.ContainerService = Presenter.ContainerService;

            switch (Presenter.TipoTarifa)
            {
                case "L":  /* Logistico  :) */
                    ENTC_CodigoEntidad.TipoEntidad = TiposEntidad.TIPE_Transportista;
                    Text = @"Detalle Logístico";
                    tlpTarifarioLogistico.Visible = true;
                    tlpTarifarioAduaneroTransp.Visible = false;
                    CbTipoEntidad.DataSource = Presenter.ListTiposEntidad;
                    CbTipoEntidad.ValueMember = "TIPE_Codigo";
                    CbTipoEntidad.DisplayMember = "TIPE_Descripcion";
                    lblCostoAduanero.Text = @"Costo:";
                    Height = 278;
                    
                    break;
                case "A":   /* Aduanero  :) */
                    Text = @"Detalle Agente Aduanero";
                    tlpTarifarioLogistico.Visible = false;
                    tlpTarifarioAduaneroTransp.Visible = true;
                    lblCostoAduanero.Text = @"Valor:";
                    tlpTarifarioAduaneroTransp.RowStyles[0].Height = 0;
                    tlpTarifarioAduaneroTransp.RowStyles[1].Height = 27;
                    tlpTarifarioAduaneroTransp.RowStyles[2].Height = 27;
                    tlpTarifarioAduaneroTransp.RowStyles[3].Height = 0;
                    tlpTarifarioAduaneroTransp.RowStyles[4].Height = 0;

                    CbTipo.Visible = false;
                    Presenter.ListConstantes = Presenter.ListConstantes.Where(data=>data.CONS_CodTipo != "004").ToObservableCollection();
                    CbBase.DataSource = Presenter.ListConstantes;
                    CbBase.ValueMember = "CONS_CodTipo";
                    CbBase.DisplayMember = "CONS_Desc_SPA";

                    Height = 223;
                    break;
                case "T":   /* Transporte  :) */
                    Text = @"Detalle Transportista";
                    tlpTarifarioLogistico.Visible = false;
                    tlpTarifarioAduaneroTransp.Visible = true;
                    tlpTarifarioAduaneroTransp.RowStyles[0].Height = 27;
                    tlpTarifarioAduaneroTransp.RowStyles[1].Height = 27;
                    tlpTarifarioAduaneroTransp.RowStyles[2].Height = 0;
                    tlpTarifarioAduaneroTransp.RowStyles[3].Height = 27;
                    tlpTarifarioAduaneroTransp.RowStyles[4].Height = 27;
                    lblCostoAduanero.Text = @"Costo:";
                    CbTipo.Visible = true;
                    CbTipo.DataSource = Presenter.ListConstantesTipo;
                    CbTipo.ValueMember = "CONS_CodTipo";
                    CbTipo.DisplayMember = "CONS_Desc_SPA";
                    
                    CbOrigen.DataSource = Presenter.ListZonas;
                    CbOrigen.ValueMember = "TIPO_CodZONOrigen";
                    CbOrigen.DisplayMember = "TIPO_Desc1";

                    CbDestino.DataSource = Presenter.ListZonasDetino;
                    CbDestino.ValueMember = "TIPO_CodZONDestino";
                    CbDestino.DisplayMember = "TIPO_Desc1";

                    CbBase.DataSource = Presenter.ListConstantes.Where(data => data.CONS_CodTipo != "004").ToObservableCollection();
                    CbBase.ValueMember = "CONS_CodTipo";
                    CbBase.DisplayMember = "CONS_Desc_SPA";

                    Height = 223;
                    break;
            }
         }
         catch (Exception ex)
         { Dialogos.MostrarMensajeError(Presenter.Title, Mensajes.LoadView, ex); }
      }

      #region [ Detalle Tarifario ]
      public void ClearItem(string xTipoTarifa)
      {
          try
          {
              switch (xTipoTarifa)
              {
                  case "L": /* Logistico */
                      CbTipoEntidad.SelectedIndex = 0;
                      ENTC_CodigoEntidad.ClearValue();
                      txtCosto20.Value = 0;
                      txtCostoSada20.Value = 0;
                      txtCosto40.Value = 0;
                      txtCostoSada40.Value = 0;
                      txtHBL.Value = 0;
                      txtHBLSada.Value = 0;
                      break;
                  case "A": /* Aduana */
                      CbBase.SelectedIndex = 0;
                      txtMinimo.Value = 0;
                      txtCostoAduTransp.Value = 0;
                      break;
                  case "T": /* Transporte */
                      txtCostoAduTransp.Value = 0;
                      CbTipo.SelectedIndex = 0;
                      CbBase.SelectedIndex = 0;
                      txtMinimo.Value = 0;
                      CbOrigen.SelectedIndex = 0;
                      CbDestino.SelectedIndex = 0;
                      chkRoundtrip.Checked = false;
                      break;
              }
          }
          catch (Exception ex)
          { Dialogos.MostrarMensajeError(Presenter.Title, Mensajes.ClearItem, ex); }
      }
      public void GetItem()
      {
          try
          {
              switch (Presenter.TipoTarifa)
              {
                  case "L": /* Logistico */
                      Presenter.ItemDET_Tarifa.CTAR_Tipo = "L";

                      /* Tipo Entidad */
                        if (CbTipoEntidad.SelectedValue != null)
                        {
                            Presenter.ItemDET_Tarifa.TIPE_Codigo = short.Parse(CbTipoEntidad.SelectedValue.ToString());
                            Presenter.ItemDET_Tarifa.TIPE_Descripcion = CbTipoEntidad.Text;
                        }
                        else
                        {
                            Presenter.ItemDET_Tarifa.TIPE_Codigo= null;
                        }

                      /* Entidad Codigo */
                      if (ENTC_CodigoEntidad.Value != null)
                      {
                          if ((Convert.ToInt32(ENTC_CodigoEntidad.Value.ENTC_Codigo)) > 0)
                          {
                              Presenter.ItemDET_Tarifa.ENTC_Codigo = (Convert.ToInt32(ENTC_CodigoEntidad.Value.ENTC_Codigo));
                              Presenter.ItemDET_Tarifa.ENTC_RazonSocial = ENTC_CodigoEntidad.Value.ENTC_RazonSocial;
                          }
                          else
                          {
                              Presenter.ItemDET_Tarifa.ENTC_Codigo = null;
                              Presenter.ItemDET_Tarifa.ENTC_RazonSocial = null;
                          }
                      }

                      /* ST 20 */
                      if (txtCosto20.Value > 0)
                      {
                          Presenter.ItemDET_Tarifa.DTAR_Costo20 = txtCosto20.Value;
                          if (txtCosto20.Value > 0)
                          {
                              Presenter.ItemDET_Tarifa.DTAR_Venta = (Presenter.Profit + Presenter.ItemDET_Tarifa.DTAR_Costo20);
                              Presenter.ItemDET_Tarifa.DTAR_Profit = Presenter.Profit;
                          }
                      }
                      else
                      {
                          Presenter.ItemDET_Tarifa.DTAR_Venta = null;
                          Presenter.ItemDET_Tarifa.DTAR_Profit = null;
                      }

                      /* ST 20 Sada */
                      if (txtCostoSada20.Value > 0)
                      {
                          Presenter.ItemDET_Tarifa.DTAR_CostoSada20 = txtCostoSada20.Value;
                          if (txtCostoSada20.Value > 0)
                          {
                              Presenter.ItemDET_Tarifa.DTAR_VentaSada = (Presenter.Profit + Presenter.ItemDET_Tarifa.DTAR_CostoSada20);
                              Presenter.ItemDET_Tarifa.DTAR_Venta = (Presenter.Profit + Presenter.ItemDET_Tarifa.DTAR_Costo20);
                              Presenter.ItemDET_Tarifa.DTAR_Profit = Presenter.Profit;
                          }
                      }
                      else
                      {
                          Presenter.ItemDET_Tarifa.DTAR_VentaSada = null;
                          Presenter.ItemDET_Tarifa.DTAR_Profit = null;
                          Presenter.ItemDET_Tarifa.DTAR_Venta = null;
                      }

                      /* ST 40 */
                      if (txtCosto40.Value > 0)
                      {
                          Presenter.ItemDET_Tarifa.DTAR_Costo40 = txtCosto40.Value;
                          if (txtCosto40.Value > 0)
                          {
                              Presenter.ItemDET_Tarifa.DTAR_Venta = (Presenter.Profit + Presenter.ItemDET_Tarifa.DTAR_Costo40);
                              Presenter.ItemDET_Tarifa.DTAR_Profit = Presenter.Profit;
                          }
                      }
                      else
                      {
                          Presenter.ItemDET_Tarifa.DTAR_Venta = null;
                          Presenter.ItemDET_Tarifa.DTAR_Profit = null;
                          
                      }

                      /* ST 40 SADA */
                      if (txtCostoSada40.Value > 0)
                      {
                          Presenter.ItemDET_Tarifa.DTAR_CostoSada40 = txtCostoSada40.Value;
                          if (txtCostoSada40.Value > 0)
                          {
                              Presenter.ItemDET_Tarifa.DTAR_VentaSada = (Presenter.Profit + Presenter.ItemDET_Tarifa.DTAR_CostoSada40);
                              Presenter.ItemDET_Tarifa.DTAR_Venta = (Presenter.Profit + Presenter.ItemDET_Tarifa.DTAR_Costo40);
                              Presenter.ItemDET_Tarifa.DTAR_Profit = Presenter.Profit;
                          }
                      }
                      else
                      {
                          Presenter.ItemDET_Tarifa.DTAR_VentaSada = null;
                          Presenter.ItemDET_Tarifa.DTAR_Profit = null;
                          Presenter.ItemDET_Tarifa.DTAR_Venta = null;
                      }

                      if (Presenter.ItemDET_Tarifa.TIPE_Codigo != null && Presenter.ItemDET_Tarifa.TIPE_Codigo.Value.ToString(CultureInfo.InvariantCulture).Equals("13")) /* solo si es maritimo */
                      {
                          /* HBL */
                          if (txtHBL.Value > 0)
                          {
                              Presenter.ItemDET_Tarifa.DTAR_CostoHBL = txtHBL.Value;
                              if (txtHBL.Value > 0)
                              {
                                  Presenter.ItemDET_Tarifa.DTAR_Venta = (Presenter.Profit + Presenter.ItemDET_Tarifa.DTAR_CostoHBL);
                                  Presenter.ItemDET_Tarifa.DTAR_Profit = Presenter.Profit;
                              }
                          }
                          else
                          {
                              Presenter.ItemDET_Tarifa.DTAR_Venta = null;
                              Presenter.ItemDET_Tarifa.DTAR_Profit = null;
                          }
                          /* HBL SADA */
                          if (txtHBLSada.Value > 0)
                          {
                              Presenter.ItemDET_Tarifa.DTAR_CostoSadaHBL = txtHBLSada.Value;
                              if (txtHBLSada.Value > 0)
                              {
                                  Presenter.ItemDET_Tarifa.DTAR_VentaSada = (Presenter.Profit + Presenter.ItemDET_Tarifa.DTAR_CostoSadaHBL);
                                  Presenter.ItemDET_Tarifa.DTAR_Venta = (Presenter.Profit + Presenter.ItemDET_Tarifa.DTAR_CostoSadaHBL);
                                  Presenter.ItemDET_Tarifa.DTAR_Profit = Presenter.Profit;
                              }
                          }
                          else
                          {
                              Presenter.ItemDET_Tarifa.DTAR_VentaSada = null;
                              Presenter.ItemDET_Tarifa.DTAR_Profit = null;
                              Presenter.ItemDET_Tarifa.DTAR_Venta = null;
                          }
                          Presenter.ItemDET_Tarifa.CONS_TabBas = "BSL";
                          Presenter.ItemDET_Tarifa.CONS_CodBas = "004"; // HBL
                      }
                     
                      break;
                  case "A": /* Aduana */
                    if (Presenter.InstanciaDet_Tarifa == InstanceView.Edit)
                       {
                          Presenter.TempItemDET_Tarifa = Presenter.ItemsDet_Tarifa.FirstOrDefault(tipo => tipo.CTAR_Tipo == Presenter.ItemDET_Tarifa.CTAR_Tipo && tipo.CTAR_Codigo == Presenter.ItemDET_Tarifa.CTAR_Codigo && tipo.DTAR_Item == Presenter.ItemDET_Tarifa.DTAR_Item);
                       }
                      Presenter.TempItemDET_Tarifa.CTAR_Tipo = "A";
                      Presenter.TempItemDET_Tarifa.DTAR_Profit = Presenter.Profit;
                      /* Valor */
                      if (txtCostoAduTransp.Value > 0)
                      {
                          Presenter.TempItemDET_Tarifa.DTAR_Costo = txtCostoAduTransp.Value;
                          Presenter.TempItemDET_Tarifa.DTAR_VentaSada = (Presenter.Profit + Presenter.TempItemDET_Tarifa.DTAR_Costo);
                          Presenter.TempItemDET_Tarifa.DTAR_Venta = (Presenter.Profit + Presenter.TempItemDET_Tarifa.DTAR_Costo);
                      }
                      else
                      {
                          Presenter.TempItemDET_Tarifa.DTAR_Costo = null;
                          Presenter.TempItemDET_Tarifa.DTAR_VentaSada = null;
                          Presenter.TempItemDET_Tarifa.DTAR_Venta = null;
                      }

                      /* Base */
                      if (CbBase.SelectedValue != null)
                      {
                          Presenter.TempItemDET_Tarifa.CONS_CodBas = CbBase.SelectedValue.ToString();
                          Presenter.TempItemDET_Tarifa.CONS_TabBas = "BSL";
                          Presenter.TempItemDET_Tarifa.CONS_Desc_SPA = CbBase.Text;
                      }
                      else
                      {
                          Presenter.TempItemDET_Tarifa.CONS_CodBas = null;
                          Presenter.TempItemDET_Tarifa.CONS_TabBas = null;
                          Presenter.TempItemDET_Tarifa.CONS_CodTipo = null;
                      }

                      /* Minimo */
                       if (txtMinimo.Value > 0)
                        {
                            Presenter.TempItemDET_Tarifa.DTAR_Minimo = txtMinimo.Value;
                        }
                        else
                        {
                            Presenter.TempItemDET_Tarifa.DTAR_Minimo = null;
                        }
                      break;
                  case "T": /* Transporte */
                      if (Presenter.InstanciaDet_Tarifa == InstanceView.Edit)
                      {
                         Presenter.TempItemDET_Tarifa = Presenter.ItemsDet_Tarifa.FirstOrDefault(tipo => tipo.CTAR_Tipo == Presenter.ItemDET_Tarifa.CTAR_Tipo && tipo.CTAR_Codigo == Presenter.ItemDET_Tarifa.CTAR_Codigo && tipo.DTAR_Item == Presenter.ItemDET_Tarifa.DTAR_Item);
                      }
                      Presenter.TempItemDET_Tarifa.CTAR_Tipo = "T";
                      Presenter.TempItemDET_Tarifa.DTAR_Profit = Presenter.Profit;
                      /* Tipo :) */
                      if (CbTipo.SelectedValue != null)
                      {
                          Presenter.TempItemDET_Tarifa.CONS_CodTRA = CbTipo.SelectedValue.ToString();
                          Presenter.TempItemDET_Tarifa.CONS_TabTRA = "TRA";
                          Presenter.TempItemDET_Tarifa.CONS_Desc_TRA = CbTipo.Text;
                      }
                      else
                      {
                          Presenter.TempItemDET_Tarifa.CONS_CodTRA = null;
                          Presenter.TempItemDET_Tarifa.CONS_TabTRA = null;
                      }

                      /* Origen :) */
                      if (CbOrigen.TiposSelectedValue != null)
                      {
                          Presenter.TempItemDET_Tarifa.TIPO_CodZONOrigen = CbOrigen.TiposSelectedValue.ToString();
                          Presenter.TempItemDET_Tarifa.TIPO_TabZON = "ZON";
                          Presenter.TempItemDET_Tarifa.ORIGEN = CbOrigen.Text;
                      }
                      else
                      {
                          Presenter.TempItemDET_Tarifa.TIPO_CodZONOrigen = null;
                          Presenter.TempItemDET_Tarifa.TIPO_TabZON = null;
                      }

                      /* Destino :) */
                      if (CbDestino.TiposSelectedValue != null)
                      {
                          Presenter.TempItemDET_Tarifa.TIPO_CodZONDestino = CbDestino.TiposSelectedValue.ToString();
                          Presenter.TempItemDET_Tarifa.TIPO_TabZON = "ZON";
                          Presenter.TempItemDET_Tarifa.DESTINO = CbDestino.Text;
                      }
                      else
                      {
                          Presenter.TempItemDET_Tarifa.TIPO_CodZONDestino = null;
                          Presenter.TempItemDET_Tarifa.TIPO_TabZON = null;
                      }

                      /* costo :) */
                      if (txtCostoAduTransp.Value > 0)
                      {
                          Presenter.TempItemDET_Tarifa.DTAR_Costo = txtCostoAduTransp.Value;
                          Presenter.TempItemDET_Tarifa.DTAR_VentaSada = (Presenter.Profit + Presenter.TempItemDET_Tarifa.DTAR_Costo);
                          Presenter.TempItemDET_Tarifa.DTAR_Venta = (Presenter.Profit + Presenter.TempItemDET_Tarifa.DTAR_Costo);
                      }
                      else
                      {
                          Presenter.TempItemDET_Tarifa.DTAR_Costo = null;
                          Presenter.TempItemDET_Tarifa.DTAR_VentaSada = null;
                          Presenter.TempItemDET_Tarifa.DTAR_Venta = null;
                      }

                      /* Base  :) */
                      if ( CbBase.SelectedValue != null)
                      {
                          Presenter.TempItemDET_Tarifa.CONS_CodBas = CbBase.SelectedValue.ToString();
                          Presenter.TempItemDET_Tarifa.CONS_TabBas = "BSL";
                          Presenter.TempItemDET_Tarifa.CONS_Desc_SPA = CbBase.Text;
                      }
                      else
                      {
                          Presenter.TempItemDET_Tarifa.CONS_CodBas = null;
                          Presenter.TempItemDET_Tarifa.CONS_TabBas = null;
                      }

                      /* RoundTrip  :) */
                      if (chkRoundtrip.Checked)
                       {
                           Presenter.TempItemDET_Tarifa.DTAR_Roundtrip = chkRoundtrip.Checked;
                       } 
                      else
	                    {
                            Presenter.TempItemDET_Tarifa.DTAR_Roundtrip = null;
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
              switch (Presenter.TipoTarifa)
              {
                  case "L": /* Logistico */

                      /* Tipo Entidad */
                      if (Presenter.ItemDET_Tarifa.TIPE_Codigo != null)
                      {
                          CbTipoEntidad.SelectedValue = Presenter.ItemDET_Tarifa.TIPE_Codigo.Value; 
                      }

                      /* Entidad Codigo */
                      if (Presenter.ItemDET_Tarifa.ENTC_Codigo != null)
	                  {
                          ENTC_CodigoEntidad.SetValue( Presenter.ItemDET_Tarifa.ENTC_Codigo.Value);
	                  }

                      /* ST 20 */
                      if (Presenter.ItemDET_Tarifa.DTAR_Costo20 > 0)
                      {
                          txtCosto20.Value  = Presenter.ItemDET_Tarifa.DTAR_Costo20;  
                      }

                      /* ST 20 Sada */
                      if (Presenter.ItemDET_Tarifa.DTAR_CostoSada20 > 0)
                      {
                          txtCostoSada20.Value = Presenter.ItemDET_Tarifa.DTAR_CostoSada20;
                      }

                      /* ST 40 */
                      if (Presenter.ItemDET_Tarifa.DTAR_Costo40 > 0)
                      {
                          txtCosto40.Value = Presenter.ItemDET_Tarifa.DTAR_Costo40;
                      }

                      /* ST 40 SADA */
                      if (Presenter.ItemDET_Tarifa.DTAR_CostoSada40 > 0)
                      {
                          txtCostoSada40.Value  = Presenter.ItemDET_Tarifa.DTAR_CostoSada40 ;
                      }

                      if (Presenter.ItemDET_Tarifa.TIPE_Codigo != null && Presenter.ItemDET_Tarifa.TIPE_Codigo.Value.ToString(CultureInfo.InstalledUICulture).Equals("13")) /* solo si es maritimo */
                      {
                          /* HBL */
                          if (Presenter.ItemDET_Tarifa.DTAR_CostoHBL > 0)
                          {
                              txtHBL.Value = Presenter.ItemDET_Tarifa.DTAR_CostoHBL;
                          }
                          
                          /* HBL SADA */
                          if (Presenter.ItemDET_Tarifa.DTAR_CostoSadaHBL > 0)
                          {
                              txtHBLSada.Value = Presenter.ItemDET_Tarifa.DTAR_CostoSadaHBL;
                          }
                      }
                      break;
                  case "A": /* Aduana */
                      
                      /* Valor */
                      if (Presenter.ItemDET_Tarifa.DTAR_Costo > 0)
                      {
                          if (Presenter.ItemDET_Tarifa.DTAR_Costo != null)
                          {
                              txtCostoAduTransp.Value = Presenter.ItemDET_Tarifa.DTAR_Costo.Value;
                          }
                      }

                      /* Base */
                      if (!String.IsNullOrEmpty(Presenter.ItemDET_Tarifa.CONS_CodBas) )
                      {
                          CbBase.ConstantesSelectedValue = Presenter.ItemDET_Tarifa.CONS_CodBas;   
                          Presenter.ItemDET_Tarifa.CONS_CodTipo = Presenter.ItemDET_Tarifa.CONS_CodBas;
                      }
                      /* Minimo */
                      if (Presenter.ItemDET_Tarifa.DTAR_Minimo != null && Presenter.ItemDET_Tarifa.DTAR_Minimo > 0 )
                      {
                         txtMinimo.Value = Presenter.ItemDET_Tarifa.DTAR_Minimo.Value;
                      }
                      else
                      {
                         Presenter.ItemDET_Tarifa.DTAR_Minimo = null;
                      }
                      break;
                  case "T": /* Transporte */
                      
                      /* Tipo :) */
                      if (!String.IsNullOrEmpty(Presenter.ItemDET_Tarifa.CONS_CodTRA))
                      {
                          CbTipo.ConstantesSelectedValue= Presenter.ItemDET_Tarifa.CONS_CodTRA;
                      }
                      
                      /* Origen :) */
                      if (!String.IsNullOrEmpty(Presenter.ItemDET_Tarifa.TIPO_CodZONOrigen))
                      {
                          CbOrigen.TiposSelectedValue= Presenter.ItemDET_Tarifa.TIPO_CodZONOrigen;
                      }

                      /* Destino :) */
                      if (!String.IsNullOrEmpty(Presenter.ItemDET_Tarifa.TIPO_CodZONDestino ))
                      {
                          CbDestino.TiposSelectedValue = Presenter.ItemDET_Tarifa.TIPO_CodZONDestino; 
                      }
                      
                      /* costo :) */
                      if (Presenter.ItemDET_Tarifa.DTAR_Costo != null && Presenter.ItemDET_Tarifa.DTAR_Costo.Value > 0 )
                      {
                          txtCostoAduTransp.Value = Presenter.ItemDET_Tarifa.DTAR_Costo.Value;
                      }

                      /* Base  :) */
                      if (!String.IsNullOrEmpty(Presenter.ItemDET_Tarifa.CONS_CodBas))
                      {
                          CbBase.ConstantesSelectedValue = Presenter.ItemDET_Tarifa.CONS_CodBas;
                      }

                      /* RoundTrip  :) */
                      if (Presenter.ItemDET_Tarifa.DTAR_Roundtrip != null &&  Presenter.ItemDET_Tarifa.DTAR_Roundtrip.Value)
                       {
                           chkRoundtrip.Checked = Presenter.ItemDET_Tarifa.DTAR_Roundtrip.Value;
                       } 
                      break;
              }
          }
          catch (Exception ex)
          { Dialogos.MostrarMensajeError(Presenter.Title, Mensajes.SetItem, ex); }
      }
      public void SetInstance(InstanceView xInstance)
      {
          try
          {
              errorProvider1.Dispose();
              switch (xInstance)
              {
                  case InstanceView.Default:
                      break;
                  case InstanceView.New:
                      
                      HashFormulario = FormValidateChanges.iniciarComparacionFormulario(this);
                      break;
                  case InstanceView.Edit:
                      
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
              Dialogos.MostrarMensajeInformacion(Presenter.Title, "Faltan ingresar datos obligatorios: ", Presenter.TempItemDET_Tarifa.MensajeError, Dialogos.Boton.Detalles);
              FormShowErrorProvider<Det_Tarifa>.Validate(Presenter.TempItemDET_Tarifa, this, errorProvider1);
          }
          catch (Exception ex)
          { Dialogos.MostrarMensajeError(Presenter.Title, Mensajes.ShowItems, ex); }
      }
      public void GenerarST20_ST40_HBL()
      {
          try
          {
              int registros = 0;
              registros = CbTipoEntidad.SelectedValue.ToString().Equals("13") ? 3 : 2;
              Det_Tarifa _Item;
              for (int i = 0; i < registros; i++)
              {

                 if (Presenter.ItemDET_Tarifa.Instance == Infrastructure.Aspect.BusinessEntity.InstanceEntity.Modified)
                 {
                    Presenter.TempItemDET_Tarifa = Presenter.ItemDET_Tarifa;
                 }
                 else
                 {
                    Presenter.NuevoDetalleTarifarios();
                 }
                  if (i == 2)  /* HBL no tiene PACK_Codigo */
                  {
                      Presenter.TempItemDET_Tarifa.PACK_Codigo = null;
                  }
                  else
                  {
                      Presenter.TempItemDET_Tarifa.PACK_Codigo = i == 0 ? 1 : 2; // 1 =>  20 ,  2 => 40    :) 
                  }
                  /* Tipo Entidad */
                  Presenter.TempItemDET_Tarifa.TIPE_Codigo = short.Parse(CbTipoEntidad.SelectedValue.ToString());

                  /* Entidad */
                  Presenter.TempItemDET_Tarifa.ENTC_Codigo = (Convert.ToInt32(ENTC_CodigoEntidad.Value.ENTC_Codigo));
                  switch(i)
                  {
                     case 0:
                        /* ST 20 */
                        if (Presenter.ItemsDet_Tarifa.Count >0 &&  Presenter.ItemDET_Tarifa.Instance == Infrastructure.Aspect.BusinessEntity.InstanceEntity.Modified)
                        {
                           _Item = new Det_Tarifa();
                           _Item = Presenter.ItemsDet_Tarifa.FirstOrDefault(tipo => tipo.CTAR_Tipo == Presenter.TipoTarifa && tipo.PACK_Codigo == 1 && tipo.TIPE_Codigo == Presenter.TempItemDET_Tarifa.TIPE_Codigo && tipo.ENTC_Codigo == Presenter.TempItemDET_Tarifa.ENTC_Codigo);

                           _Item.DTAR_Costo = Presenter.ItemDET_Tarifa.DTAR_Costo20;
                           _Item.DTAR_Venta = (Presenter.Profit + Presenter.TempItemDET_Tarifa.DTAR_Costo);
                           _Item.DTAR_Profit = Presenter.Profit;

                           _Item.DTAR_CostoSada = Presenter.ItemDET_Tarifa.DTAR_CostoSada20;
                           _Item.DTAR_VentaSada = (Presenter.Profit + Presenter.TempItemDET_Tarifa.DTAR_CostoSada);
                           _Item.AUDI_UsrMod = Presenter.Session.UserName;  
                        }
                        Presenter.TempItemDET_Tarifa.DTAR_Costo = Presenter.ItemDET_Tarifa.DTAR_Costo20;
                        Presenter.TempItemDET_Tarifa.DTAR_Venta = (Presenter.Profit + Presenter.TempItemDET_Tarifa.DTAR_Costo);
                        Presenter.TempItemDET_Tarifa.DTAR_Profit = Presenter.Profit;

                        /* ST 20 Sada */
                        Presenter.TempItemDET_Tarifa.DTAR_CostoSada = Presenter.ItemDET_Tarifa.DTAR_CostoSada20;
                        Presenter.TempItemDET_Tarifa.DTAR_VentaSada = (Presenter.Profit+ Presenter.TempItemDET_Tarifa.DTAR_CostoSada);
                        Presenter.TempItemDET_Tarifa.DTAR_Profit = Presenter.Profit;
                        break;
                     case 1:
                      /* ST 40 */
                        if (Presenter.ItemsDet_Tarifa.Count > 0 &&  Presenter.ItemDET_Tarifa.Instance == Infrastructure.Aspect.BusinessEntity.InstanceEntity.Modified)
                        {
                           _Item = new Det_Tarifa();
                           _Item = Presenter.ItemsDet_Tarifa.FirstOrDefault(tipo => tipo.CTAR_Tipo == Presenter.TipoTarifa && tipo.PACK_Codigo == 2 && tipo.TIPE_Codigo == Presenter.TempItemDET_Tarifa.TIPE_Codigo && tipo.ENTC_Codigo == Presenter.TempItemDET_Tarifa.ENTC_Codigo);

                           _Item.DTAR_Costo = Presenter.ItemDET_Tarifa.DTAR_Costo40;
                           _Item.DTAR_Venta = (Presenter.Profit + Presenter.TempItemDET_Tarifa.DTAR_Costo);
                           _Item.DTAR_Profit = Presenter.Profit;

                           _Item.DTAR_CostoSada = Presenter.ItemDET_Tarifa.DTAR_CostoSada40;
                           _Item.DTAR_VentaSada = (Presenter.Profit + Presenter.TempItemDET_Tarifa.DTAR_CostoSada);
                           _Item.AUDI_UsrMod = Presenter.Session.UserName;
                        }
                        Presenter.TempItemDET_Tarifa.DTAR_Costo = Presenter.ItemDET_Tarifa.DTAR_Costo40;
                        Presenter.TempItemDET_Tarifa.DTAR_Venta = (Presenter.Profit+ Presenter.TempItemDET_Tarifa.DTAR_Costo);
                        Presenter.TempItemDET_Tarifa.DTAR_Profit = Presenter.Profit;

                        /* ST 40 SADA */
                        Presenter.TempItemDET_Tarifa.DTAR_CostoSada = Presenter.ItemDET_Tarifa.DTAR_CostoSada40;
                        //Presenter.TempItemDET_Tarifa.DTAR_VentaSada = ((Presenter.Profit / 100) * Presenter.TempItemDET_Tarifa.DTAR_CostoSada);
                        Presenter.TempItemDET_Tarifa.DTAR_VentaSada = (Presenter.Profit + Presenter.TempItemDET_Tarifa.DTAR_CostoSada);
                        Presenter.TempItemDET_Tarifa.DTAR_Profit = Presenter.Profit;
                        break;
                     case 2:
                        /* HBL */
                        if (Presenter.ItemsDet_Tarifa.Count > 0 && Presenter.ItemDET_Tarifa.Instance == Infrastructure.Aspect.BusinessEntity.InstanceEntity.Modified)
                        {
                           _Item = new Det_Tarifa();
                           _Item = Presenter.ItemsDet_Tarifa.FirstOrDefault(tipo => tipo.CTAR_Tipo == Presenter.TipoTarifa && tipo.PACK_Codigo == null && tipo.TIPE_Codigo == Presenter.TempItemDET_Tarifa.TIPE_Codigo && tipo.ENTC_Codigo == Presenter.TempItemDET_Tarifa.ENTC_Codigo);

                           _Item.DTAR_Costo = Presenter.ItemDET_Tarifa.DTAR_CostoHBL;
                           _Item.DTAR_Venta = (Presenter.Profit + Presenter.TempItemDET_Tarifa.DTAR_CostoHBL);
                           _Item.DTAR_Profit = Presenter.Profit;

                           _Item.DTAR_CostoSada = Presenter.ItemDET_Tarifa.DTAR_CostoSadaHBL;
                           _Item.DTAR_VentaSada = (Presenter.Profit + Presenter.TempItemDET_Tarifa.DTAR_CostoSada);
                           _Item.AUDI_UsrMod = Presenter.Session.UserName;
                        }
                        Presenter.TempItemDET_Tarifa.DTAR_Costo = Presenter.ItemDET_Tarifa.DTAR_CostoHBL;
                        Presenter.TempItemDET_Tarifa.DTAR_Venta = (Presenter.Profit+ Presenter.TempItemDET_Tarifa.DTAR_Costo);
                        Presenter.TempItemDET_Tarifa.DTAR_Profit = Presenter.Profit;

                        /* HBL SADA */
                        Presenter.TempItemDET_Tarifa.DTAR_CostoSada = Presenter.ItemDET_Tarifa.DTAR_CostoSadaHBL;
                        Presenter.TempItemDET_Tarifa.DTAR_VentaSada = (Presenter.Profit + Presenter.TempItemDET_Tarifa.DTAR_CostoSada);
                        Presenter.TempItemDET_Tarifa.DTAR_Profit = Presenter.Profit;
                        Presenter.TempItemDET_Tarifa.CONS_CodBas = "004";
                        Presenter.TempItemDET_Tarifa.CONS_TabBas = "BSL";
                        break;
                  }
                  int ultimo = 0;
                  if (Presenter.ItemsDet_Tarifa != null && Presenter.ItemsDet_Tarifa.Count > 0)
                  {
                      ultimo = Presenter.ItemsDet_Tarifa.Max(data => data.DTAR_Fila); 
                  }
                  ultimo++;
                  Presenter.TempItemDET_Tarifa.DTAR_Fila = ultimo;
                  if (Presenter.ItemsDet_Tarifa != null) Presenter.ItemsDet_Tarifa.Add(Presenter.TempItemDET_Tarifa);
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
      public void SetItemST20_ST40( ref ObservableCollection<Det_Tarifa> x_items)
      {
          try
          {
              if (x_items != null)
              {
                  decimal tempCosto20 = 0;
                  decimal tempCostoSada20 = 0;
                  decimal tempCosto40 = 0;
                  decimal tempCostoSada40 = 0;
                  Int32 _Fila = 0;
                  for (int i = 0; i < x_items.Count; i++)
                  {
                      Det_Tarifa detTarifa;
                      if (((i % 2) == 0) && i == 0)   /* primer registro */
                      {
                          detTarifa = new Det_Tarifa();
                          detTarifa = x_items.ElementAt(i);
                          _Fila=1; 
                      }
                      else
                      {
                          detTarifa = x_items.ElementAt(i);
                          detTarifa.DTAR_Costo20 = tempCosto20;
                          detTarifa.DTAR_CostoSada20 = tempCostoSada20;
                          detTarifa.DTAR_Costo40 = tempCosto40;
                          detTarifa.DTAR_CostoSada40 = tempCostoSada40;
                      }
                      if (detTarifa.PACK_Codigo == 1)
                      {
                          tempCosto20 = 0;
                          tempCostoSada20 = 0;
                          detTarifa.DTAR_Costo20 = x_items[i].DTAR_Costo != null ? x_items[i].DTAR_Costo.Value : 0;
                          if (detTarifa.DTAR_CostoSada != null)
                              detTarifa.DTAR_CostoSada20 = detTarifa.DTAR_CostoSada.Value;
                          tempCosto20 = detTarifa.DTAR_Costo20;
                          tempCostoSada20 = detTarifa.DTAR_CostoSada20;
                          detTarifa.DTAR_Fila = _Fila;
                      }

                      if (detTarifa.PACK_Codigo == 2)
                      {
                          tempCosto40 = 0;
                          tempCostoSada40 = 0;
                          detTarifa.DTAR_Costo40 = x_items[i].DTAR_Costo != null ? x_items[i].DTAR_Costo.Value : 0;
                          if (detTarifa.DTAR_CostoSada != null)
                              detTarifa.DTAR_CostoSada40 = detTarifa.DTAR_CostoSada.Value;
                          tempCosto40 = detTarifa.DTAR_Costo40;
                          tempCostoSada40 = detTarifa.DTAR_CostoSada40;
                          
                          if (detTarifa.TIPE_Codigo != null && detTarifa.TIPE_Codigo.Value.ToString(CultureInfo.InvariantCulture) != "13") /* Maritimo */
                          {
                              
                              detTarifa.DTAR_Fila = _Fila;
                              Presenter.ItemsGrillaDet_Tarifa.Add(detTarifa);
                              _Fila++;
                          }
                          else
                          {
                              detTarifa.DTAR_Fila = _Fila;
                          }
                      }
                      if (detTarifa.TIPE_Codigo != null && detTarifa.TIPE_Codigo.Value.ToString(CultureInfo.InvariantCulture).Equals("13")) /* Maritimo */
                      {
                          if (detTarifa.PACK_Codigo == null)
                          {
                              detTarifa.DTAR_CostoHBL = x_items[i].DTAR_Costo != null ? x_items[i].DTAR_Costo.Value : 0;
                              if (detTarifa.DTAR_CostoSada != null)
                                  detTarifa.DTAR_CostoSadaHBL = detTarifa.DTAR_CostoSada.Value;

                              detTarifa.DTAR_Fila = _Fila;
                              Presenter.ItemsGrillaDet_Tarifa.Add(detTarifa);
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
          Presenter.AgregarDetalleTarifario();
      }
      void PRO001DTarifa_Load(object sender, EventArgs e)
      {
          
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
                  ENTC_CodigoEntidad.ClearValue();
                  txtHBL.Text = @"0";
                  txtHBLSada.Text = @"0";
              }
          }
          catch (Exception) { }
      }
      #endregion

      private void txtCosto20_Enter(object sender, EventArgs e)
      {
         SeleccionaTexto((NumericUpDown)sender);   
      }

       private void SeleccionaTexto(NumericUpDown _Numeric)
       {
          _Numeric.Select(0, _Numeric.Value.ToString().Length);   
       }

      #endregion
    }
}





