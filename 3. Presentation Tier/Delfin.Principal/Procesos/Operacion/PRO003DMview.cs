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
   public partial class PRO003DMview : Form, IPRO003DMview
   {
      #region [ Variables ]
      private bool Closing = false;
      #endregion

      #region [ Formulario ]
      public PRO003DMview()
      {
         InitializeComponent();
         try
         {
            btnAgregar.Click += btnAgregar_Click;
            Load += PRO003DMview_Load;
            CbTipoEntidad.SelectedValueChanged += CbTipoEntidad_SelectedValueChanged;
         }
         catch (Exception ex)
         { Dialogos.MostrarMensajeError(Presenter.Title, Mensajes.ConstructorView, ex); }
      }
      #endregion

      #region [ Propiedades ]
      public PRO003Presenter Presenter { get; set; }
      private Hashtable HashFormulario { get; set; }
      #endregion

      #region [ IPRO003DView ]
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

      #region [ Detalle Operación ]
      public void ClearItem()
      {
         try
         {
            CbTipoEntidad.SelectedIndex = 0;
            ENTC_CodigoEntidad.ClearValue();
            txtVenta20.Text = @"0";
            txtVentaSada20.Text = @"0";
            txtVentaSada20.Value = 0;
            txtVenta40.Text = @"0";
            txtVentaSada40.Text = @"0";
            txtHBL.Text = @"0";
            txtHBLSada.Text = @"0";
            txtDOPE_Cantidad20.Value = 0;
            txtDOPE_Cantidad20.Text = @"0";
            txtDOPE_Cantidad40.Value = 0;
            txtDOPE_Cantidad40.Text = @"0";
            CbBase.SelectedIndex = 0;
            txtMinimo.Text = @"0";
            txtCostoAduTransp.Text = @"0";

            txtCostoAduTransp.Text = @"0";
            CbTipo.SelectedIndex = 0;
            CbBase.SelectedIndex = 0;
            txtMinimo.Text = @"0";
            CbOrigen.SelectedIndex = 0;
            CbDestino.SelectedIndex = 0;
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
                  Presenter.CrearItem();
                  Presenter.ItemDet_Operacion.CTAR_Tipo = "L";

                  /* Tipo Entidad */
                  if (CbTipoEntidad.SelectedValue != null)
                  {
                     Presenter.ItemDet_Operacion.TIPE_Codigo = short.Parse(CbTipoEntidad.SelectedValue.ToString());
                     Presenter.ItemDet_Operacion.TIPE_Descripcion = CbTipoEntidad.Text;
                  }
                  else
                  {
                     Presenter.ItemDet_Operacion.TIPE_Codigo = null;
                  }

                  /* Entidad Codigo */
                  if (ENTC_CodigoEntidad.Value != null)
                  {
                     if ((Convert.ToInt32(ENTC_CodigoEntidad.Value.ENTC_Codigo)) > 0)
                     {
                        Presenter.ItemDet_Operacion.ENTC_Codigo = (Convert.ToInt32(ENTC_CodigoEntidad.Value.ENTC_Codigo));
                        Presenter.ItemDet_Operacion.ENTC_RazonSocial = ENTC_CodigoEntidad.Value.ENTC_RazonSocial;
                     }
                     else
                     {
                        Presenter.ItemDet_Operacion.ENTC_Codigo = null;
                        Presenter.ItemDet_Operacion.ENTC_RazonSocial = null;
                     }
                  }

                  /* Cantidad 20 */
                  Presenter.ItemDet_Operacion.DOPE_Cantidad20 = (short)(txtDOPE_Cantidad20.Value > 0 ? Convert.ToInt16(txtDOPE_Cantidad20.Value) : 0);

                  /* Cantidad 40 */
                  Presenter.ItemDet_Operacion.DOPE_Cantidad40 = (short)(txtDOPE_Cantidad40.Value > 0 ? Convert.ToInt16(txtDOPE_Cantidad40.Value) : 0);

                  /* ST 20 */
                  Presenter.ItemDet_Operacion.DOPE_Venta20 = txtVenta20.Value > 0 ? txtVenta20.Value : 0;

                  /* ST 20 Sada */
                  Presenter.ItemDet_Operacion.DOPE_VentaSada20 = txtVentaSada20.Value > 0 ? txtVentaSada20.Value : 0;

                  /* ST 40 */
                  Presenter.ItemDet_Operacion.DOPE_Venta40 = txtVenta40.Value > 0 ? txtVenta40.Value : 0;

                  /* ST 40 SADA */
                  Presenter.ItemDet_Operacion.DOPE_VentaSada40 = txtVentaSada40.Value > 0 ? txtVentaSada40.Value : 0;

                  if (Presenter.ItemDet_Operacion.TIPE_Codigo != null)
                  {
                     if (Presenter.ItemDet_Operacion.TIPE_Codigo.Value.ToString(CultureInfo.InvariantCulture).Equals("13")) /* solo si es maritimo */
                     {
                        /* HBL */
                        Presenter.ItemDet_Operacion.DOPE_VentaHBL = txtHBL.Value > 0 ? txtHBL.Value : 0;
                        /* HBL SADA */
                        Presenter.ItemDet_Operacion.DOPE_VentaSadaHBL = txtHBLSada.Value > 0 ? txtHBLSada.Value : 0;
                        Presenter.ItemDet_Operacion.CONS_TabBas = "BSL";
                        Presenter.ItemDet_Operacion.CONS_CodBas = "004"; // HBL
                     }
                  }

                  /* Total */
                  if (Presenter.ItemDet_Operacion.DOPE_Cantidad20 > 0 || Presenter.ItemDet_Operacion.DOPE_Cantidad40 > 0)
                  {
                     Presenter.ItemDet_Operacion.DOPE_PrecioTotVta20 = Presenter.ItemDet_Operacion.DOPE_Cantidad20 * (Presenter.PrecioSada ? Presenter.ItemDet_Operacion.DOPE_VentaSada20 : Presenter.ItemDet_Operacion.DOPE_Venta20);
                     Presenter.ItemDet_Operacion.DOPE_PrecioTotVta40 = Presenter.ItemDet_Operacion.DOPE_Cantidad40 * (Presenter.PrecioSada ? Presenter.ItemDet_Operacion.DOPE_VentaSada40 : Presenter.ItemDet_Operacion.DOPE_Venta40);
                     Presenter.ItemDet_Operacion.DOPE_PrecioTotVta = Presenter.ItemDet_Operacion.DOPE_PrecioTotVta20 + Presenter.ItemDet_Operacion.DOPE_PrecioTotVta40 + (Presenter.PrecioSada ? Presenter.ItemDet_Operacion.DOPE_VentaSadaHBL : Presenter.ItemDet_Operacion.DOPE_VentaHBL);
                  }
                  else
                  {
                     Presenter.ItemDet_Operacion.DOPE_PrecioTotVta = 0;
                  }
                  break;
               case "A": /* Aduana */
                  Presenter.TempItemDet_Operacion.CTAR_Tipo = "A";
                  /* Valor */
                  if (txtCostoAduTransp.Value > 0)
                  {
                     Presenter.TempItemDet_Operacion.DOPE_Venta = txtCostoAduTransp.Value;
                     Presenter.TempItemDet_Operacion.DOPE_VentaSada = 0;// Presenter.TempItemDet_Operacion.DOPE_Venta;
                  }
                  else
                  {
                     Presenter.TempItemDet_Operacion.DOPE_VentaSada = 0;
                     Presenter.TempItemDet_Operacion.DOPE_Venta = 0;
                  }

                  /* Base */
                  if (CbBase.SelectedValue != null)
                  {
                     Presenter.TempItemDet_Operacion.CONS_CodBas = CbBase.SelectedValue.ToString();
                     Presenter.TempItemDet_Operacion.CONS_TabBas = "BSL";
                     Presenter.TempItemDet_Operacion.CONS_Desc_SPA = CbBase.Text;
                  }
                  else
                  {
                     Presenter.TempItemDet_Operacion.CONS_CodBas = null;
                     Presenter.TempItemDet_Operacion.CONS_TabBas = null;
                  }

                  /* Minimo */
                  Presenter.TempItemDet_Operacion.DOPE_Minimo = txtMinimo.Value > 0 ? txtMinimo.Value : 0;

                  if (CbBase.SelectedValue != null && CbBase.SelectedValue.ToString().Equals("001")) // CIF
                  {
                     decimal valor = txtCostoAduTransp.Value * (Presenter.CCOT_CIF / 100);
                     Presenter.TempItemDet_Operacion.DOPE_PrecioTotVta = valor < Presenter.TempItemDet_Operacion.DOPE_Minimo ? Presenter.TempItemDet_Operacion.DOPE_Minimo : valor;
                  }
                  else// Otro
                  {
                     Presenter.TempItemDet_Operacion.DOPE_PrecioTotVta = Presenter.TempItemDet_Operacion.DOPE_Venta;
                  }
                  break;
               case "T": /* Transporte */
                  Presenter.TempItemDet_Operacion.CTAR_Tipo = "T";
                  /* Tipo :) */
                  if (CbTipo.SelectedValue != null)
                  {
                     Presenter.TempItemDet_Operacion.CONS_CodTRA = CbTipo.SelectedValue.ToString();
                     Presenter.TempItemDet_Operacion.CONS_TabTRA = "TRA";
                     Presenter.TempItemDet_Operacion.CONS_Desc_TRA = CbTipo.Text;
                  }
                  else
                  {
                     Presenter.TempItemDet_Operacion.CONS_CodTRA = null;
                     Presenter.TempItemDet_Operacion.CONS_TabTRA = null;
                  }

                  /* Origen :) */
                  if (CbOrigen.SelectedValue != null)
                  {
                     Presenter.TempItemDet_Operacion.TIPO_CodZONOrigen = CbOrigen.SelectedValue.ToString();
                     Presenter.TempItemDet_Operacion.TIPO_TabZON = "ZON";
                     Presenter.TempItemDet_Operacion.ORIGEN = CbOrigen.Text;
                  }
                  else
                  {
                     Presenter.TempItemDet_Operacion.TIPO_CodZONOrigen = null;
                     Presenter.TempItemDet_Operacion.TIPO_TabZON = null;
                  }

                  /* Destino :) */
                  if (CbDestino.SelectedValue != null)
                  {
                     Presenter.TempItemDet_Operacion.TIPO_CodZONDestino = CbDestino.SelectedValue.ToString();
                     Presenter.TempItemDet_Operacion.TIPO_TabZON = "ZON";
                     Presenter.TempItemDet_Operacion.DESTINO = CbDestino.Text;
                  }
                  else
                  {
                     Presenter.TempItemDet_Operacion.TIPO_CodZONDestino = null;
                     Presenter.TempItemDet_Operacion.TIPO_TabZON = null;
                  }

                  /* costo :) */
                  if (txtCostoAduTransp.Value > 0)
                  {
                     Presenter.TempItemDet_Operacion.DOPE_Venta = txtCostoAduTransp.Value;
                     Presenter.TempItemDet_Operacion.DOPE_VentaSada = 0; // Presenter.TempItemDet_Operacion.DOPE_Venta;
                  }
                  else
                  {
                     Presenter.TempItemDet_Operacion.DOPE_VentaSada = 0;
                     Presenter.TempItemDet_Operacion.DOPE_Venta = 0;
                  }

                  /* Base  :) */
                  if (CbBase.SelectedValue != null)
                  {
                     Presenter.TempItemDet_Operacion.CONS_CodBas = CbBase.SelectedValue.ToString();
                     Presenter.TempItemDet_Operacion.CONS_TabBas = "BSL";
                     Presenter.TempItemDet_Operacion.CONS_Desc_SPA = CbBase.Text;
                  }
                  else
                  {
                     Presenter.TempItemDet_Operacion.CONS_CodBas = null;
                     Presenter.TempItemDet_Operacion.CONS_TabBas = null;
                  }

                  Presenter.TempItemDet_Operacion.DOPE_PrecioTotVta = Presenter.TempItemDet_Operacion.DOPE_Venta;
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
            switch (Presenter.ItemDet_Operacion.CTAR_Tipo)
            {
               case "L": /* Logistico */
                  Presenter.TipoTarifario = Presenter.ItemDet_Operacion.CTAR_Tipo;
                  /* Tipo Entidad */
                  if (Presenter.ItemDet_Operacion.TIPE_Codigo != null)
                  {
                     CbTipoEntidad.SelectedValue = Presenter.ItemDet_Operacion.TIPE_Codigo.Value;
                  }

                  /* Entidad Codigo */
                  if (Presenter.ItemDet_Operacion.ENTC_Codigo != null)
                  {
                     ENTC_CodigoEntidad.UsarTipoEntidad = false;
                     ENTC_CodigoEntidad.SetValue(Presenter.ItemDet_Operacion.ENTC_Codigo.Value);
                     ENTC_CodigoEntidad.UsarTipoEntidad = true;
                  }

                  /* Cantidad 20 */
                  if (Presenter.ItemDet_Operacion.DOPE_Cantidad20 > 0)
                  {
                     txtDOPE_Cantidad20.Value = Presenter.ItemDet_Operacion.DOPE_Cantidad20;
                     txtDOPE_Cantidad20.Text = Presenter.ItemDet_Operacion.DOPE_Cantidad20.ToString(CultureInfo.InvariantCulture);
                  }

                  /* Cantidad 40 */
                  if (Presenter.ItemDet_Operacion.DOPE_Cantidad40 > 0)
                  {
                     txtDOPE_Cantidad40.Value = Presenter.ItemDet_Operacion.DOPE_Cantidad40;
                     txtDOPE_Cantidad40.Text = Presenter.ItemDet_Operacion.DOPE_Cantidad40.ToString(CultureInfo.InvariantCulture);
                  }

                  /* ST 20 */
                  if (Presenter.ItemDet_Operacion.DOPE_Venta20 > 0)
                  {
                     txtVenta20.Value = Presenter.ItemDet_Operacion.DOPE_Venta20;
                     txtVenta20.Text = Presenter.ItemDet_Operacion.DOPE_Venta20.ToString(CultureInfo.InvariantCulture);
                  }

                  /* ST 20 Sada */
                  if (Presenter.ItemDet_Operacion.DOPE_VentaSada20 > 0)
                  {
                     txtVentaSada20.Value = Presenter.ItemDet_Operacion.DOPE_VentaSada20;
                     txtVentaSada20.Text = Presenter.ItemDet_Operacion.DOPE_VentaSada20.ToString(CultureInfo.InvariantCulture);
                  }

                  /* ST 40 */
                  if (Presenter.ItemDet_Operacion.DOPE_Venta40 > 0)
                  {
                     txtVenta40.Value = Presenter.ItemDet_Operacion.DOPE_Venta40;
                     txtVenta40.Text = Presenter.ItemDet_Operacion.DOPE_Venta40.ToString(CultureInfo.InvariantCulture);
                  }

                  /* ST 40 SADA */
                  if (Presenter.ItemDet_Operacion.DOPE_VentaSada40 > 0)
                  {
                     txtVentaSada40.Value = Presenter.ItemDet_Operacion.DOPE_VentaSada40;
                     txtVentaSada40.Text = Presenter.ItemDet_Operacion.DOPE_VentaSada40.ToString(CultureInfo.InvariantCulture);

                  }

                  if (Presenter.ItemDet_Operacion.TIPE_Codigo != null)
                  {
                     if (Presenter.ItemDet_Operacion.TIPE_Codigo.Value.ToString(CultureInfo.InvariantCulture).Equals("13")) /* solo si es maritimo */
                     {
                        /* HBL */
                        if (Presenter.ItemDet_Operacion.DOPE_VentaHBL > 0)
                        {
                           txtHBL.Value = Presenter.ItemDet_Operacion.DOPE_VentaHBL;
                           txtHBL.Text = Presenter.ItemDet_Operacion.DOPE_VentaHBL.ToString(CultureInfo.InvariantCulture);
                        }

                        /* HBL SADA */
                        if (Presenter.ItemDet_Operacion.DOPE_VentaSadaHBL > 0)
                        {
                           txtHBLSada.Value = Presenter.ItemDet_Operacion.DOPE_VentaSadaHBL;
                           txtHBLSada.Text = Presenter.ItemDet_Operacion.DOPE_VentaSadaHBL.ToString(CultureInfo.InvariantCulture);
                        }
                     }
                  }
                  break;
               case "A": /* Aduana */
                  Presenter.TipoTarifario = Presenter.ItemDet_Operacion.CTAR_Tipo;

                  /* Valor */
                  if (Presenter.ItemDet_Operacion.DOPE_Venta > 0)
                  {
                     txtCostoAduTransp.Value = Presenter.ItemDet_Operacion.DOPE_Venta;
                     txtCostoAduTransp.Text = Presenter.ItemDet_Operacion.DOPE_Venta.ToString(CultureInfo.InvariantCulture);
                  }

                  /* Base */
                  if (!String.IsNullOrEmpty(Presenter.ItemDet_Operacion.CONS_CodBas))
                  {
                     CbBase.SelectedValue = Presenter.ItemDet_Operacion.CONS_CodBas;
                     Presenter.ItemDet_Operacion.CONS_CodTipo = Presenter.ItemDet_Operacion.CONS_CodBas;
                  }
                  /* Minimo */
                  if (Presenter.ItemDet_Operacion.DOPE_Minimo > 0)
                  {
                     txtMinimo.Value = Presenter.ItemDet_Operacion.DOPE_Minimo;
                     txtMinimo.Text = Presenter.ItemDet_Operacion.DOPE_Minimo.ToString(CultureInfo.InvariantCulture);
                  }
                  else
                  {
                     Presenter.ItemDet_Operacion.DOPE_Minimo = 0;
                  }
                  break;
               case "T": /* Transporte */
                  Presenter.TipoTarifario = Presenter.ItemDet_Operacion.CTAR_Tipo;

                  /* Tipo :) */
                  if (!String.IsNullOrEmpty(Presenter.ItemDet_Operacion.CONS_CodTRA))
                  {
                     CbTipo.SelectedValue = Presenter.ItemDet_Operacion.CONS_CodTRA;
                  }

                  /* Origen :) */
                  if (!String.IsNullOrEmpty(Presenter.ItemDet_Operacion.TIPO_CodZONOrigen))
                  {
                     CbOrigen.SelectedValue = Presenter.ItemDet_Operacion.TIPO_CodZONOrigen;
                  }

                  /* Destino :) */
                  if (!String.IsNullOrEmpty(Presenter.ItemDet_Operacion.TIPO_CodZONDestino))
                  {
                     CbDestino.SelectedValue = Presenter.ItemDet_Operacion.TIPO_CodZONDestino;
                  }

                  /* costo :) */
                  if (Presenter.ItemDet_Operacion.DOPE_Venta > 0)
                  {
                     txtCostoAduTransp.Value = Presenter.ItemDet_Operacion.DOPE_Venta;
                     txtCostoAduTransp.Text = Presenter.ItemDet_Operacion.DOPE_Venta.ToString(CultureInfo.InvariantCulture);
                  }

                  /* Base  :) */
                  if (!String.IsNullOrEmpty(Presenter.ItemDet_Operacion.CONS_CodBas))
                  {
                     CbBase.SelectedValue = Presenter.ItemDet_Operacion.CONS_CodBas;
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
            ENTC_CodigoEntidad.Enabled = false;
            CbTipoEntidad.Enabled = false;
            CbBase.Enabled = false;
            CbTipo.Enabled = false;
            CbOrigen.Enabled = false;
            CbDestino.Enabled = false;
            btnAgregar.Enabled = true;
            switch (xInstance)
            {
               case InstanceView.Default:
                  break;
               case InstanceView.New:

                  HashFormulario = FormValidateChanges.iniciarComparacionFormulario(this);
                  break;
               case InstanceView.Edit:
                  if (Presenter.ItemCab_Operacion.CONS_CodEstado != null)
                  {
                     btnAgregar.Enabled = Presenter.ItemCab_Operacion.CONS_CodEstado.Equals("001");
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
            Dialogos.MostrarMensajeInformacion(Presenter.Title, "Faltan ingresar datos obligatorios: ", Presenter.ItemDet_Operacion.MensajeError, Dialogos.Boton.Detalles);
            FormShowErrorProvider<Det_Operacion>.Validate(Presenter.ItemDet_Operacion, this, errorProvider1);
         }
         catch (Exception ex)
         { Dialogos.MostrarMensajeError(Presenter.Title, Mensajes.ShowItems, ex); }
      }
      public void GenerarST20_ST40_HBL(ref Int32 xUltimafila, ObservableCollection<Det_Operacion> tempItemsDetOperacion)
      {
         try
         {
            int registros = CbTipoEntidad.SelectedValue != null && CbTipoEntidad.SelectedValue.ToString().Equals("13") ? 3 : 2;
            int ultimaFila = Presenter.ItemsGrillaDet_Operacion.Max(data => data.DOPE_Fila);
            ultimaFila++;
            xUltimafila = ultimaFila;

            Det_Operacion _DetOperacion;
            _DetOperacion = Presenter.ItemsDet_OperacionRegistros.FirstOrDefault(tipo => tipo.CTAR_Tipo == "L");



            for (int i = 0; i < registros; i++)
            {
               Presenter.NuevoDetalleOperacion(ENTC_CodigoEntidad.Value.ENTC_Codigo, 0, 0);
               Presenter.TempItemDet_Operacion.CTAR_Tipo = "L";
               if (i == 2)  /* HBL no tiene PACK_Codigo */
               {
                  Presenter.TempItemDet_Operacion.PACK_Codigo = null;
               }
               else
               {
                  Presenter.TempItemDet_Operacion.PACK_Codigo = i == 0 ? 1 : 2; // 1 =>  20 ,  2 => 40    :P :) 
               }
               /* Tipo Entidad */
               if (CbTipoEntidad.SelectedValue != null)
                  Presenter.TempItemDet_Operacion.TIPE_Codigo = short.Parse(CbTipoEntidad.SelectedValue.ToString());

               /* Entidad */
               Presenter.TempItemDet_Operacion.ENTC_Codigo = (Convert.ToInt32(ENTC_CodigoEntidad.Value.ENTC_Codigo));

               Det_Operacion firstOrDefault;
               switch (i)
               {
                  case 0:
                     firstOrDefault = tempItemsDetOperacion.FirstOrDefault(data => data.PACK_Codigo == 1);
                     if (firstOrDefault != null)
                     {
                        Presenter.TempItemDet_Operacion.CTAR_Codigo = firstOrDefault.CTAR_Codigo != null ? firstOrDefault.CTAR_Codigo.Value : firstOrDefault.CTAR_Codigo;
                        Presenter.TempItemDet_Operacion.DTAR_Item = firstOrDefault.DTAR_Item != null ? firstOrDefault.DTAR_Item.Value : firstOrDefault.DTAR_Item;
                     }
                     Presenter.TempItemDet_Operacion.CTAR_Codigo = Presenter.ItemDet_Operacion.CTAR_Codigo;
                     Presenter.TempItemDet_Operacion.DOPE_Costo = Presenter.ItemDet_Operacion.DOPE_Costo20;
                     Presenter.TempItemDet_Operacion.DOPE_CostoSada = Presenter.ItemDet_Operacion.DOPE_CostoSada20;
                     Presenter.TempItemDet_Operacion.DOPE_Cantidad = Presenter.ItemDet_Operacion.DOPE_Cantidad20;
                     Presenter.TempItemDet_Operacion.DOPE_Cantidad20 = Presenter.ItemDet_Operacion.DOPE_Cantidad20;
                     Presenter.TempItemDet_Operacion.DOPE_Venta = Presenter.ItemDet_Operacion.DOPE_Venta20;
                     Presenter.TempItemDet_Operacion.DOPE_Venta20 = Presenter.ItemDet_Operacion.DOPE_Venta20;
                     Presenter.TempItemDet_Operacion.DOPE_VentaSada = Presenter.ItemDet_Operacion.DOPE_VentaSada20;
                     Presenter.TempItemDet_Operacion.DOPE_VentaSada20 = Presenter.ItemDet_Operacion.DOPE_VentaSada20;
                     Presenter.TempItemDet_Operacion.DOPE_PrecioTotVta = Presenter.ItemDet_Operacion.DOPE_Cantidad20 * (Presenter.PrecioSada ? Presenter.ItemDet_Operacion.DOPE_VentaSada20 : Presenter.ItemDet_Operacion.DOPE_Venta20);

                     break;
                  case 1:
                     firstOrDefault = tempItemsDetOperacion.FirstOrDefault(data => data.PACK_Codigo == 2);
                     if (firstOrDefault != null)
                     {
                        Presenter.TempItemDet_Operacion.CTAR_Codigo = firstOrDefault.CTAR_Codigo != null ? firstOrDefault.CTAR_Codigo.Value : firstOrDefault.CTAR_Codigo;
                        Presenter.TempItemDet_Operacion.DTAR_Item = firstOrDefault.DTAR_Item != null ? firstOrDefault.DTAR_Item.Value : firstOrDefault.DTAR_Item;
                     }
                     Presenter.TempItemDet_Operacion.CTAR_Codigo = Presenter.ItemDet_Operacion.CTAR_Codigo;
                     Presenter.TempItemDet_Operacion.DOPE_Costo = Presenter.ItemDet_Operacion.DOPE_Costo40;
                     Presenter.TempItemDet_Operacion.DOPE_CostoSada = Presenter.ItemDet_Operacion.DOPE_CostoSada40;
                     Presenter.TempItemDet_Operacion.DOPE_Cantidad = Presenter.ItemDet_Operacion.DOPE_Cantidad40;
                     Presenter.TempItemDet_Operacion.DOPE_Cantidad40 = Presenter.ItemDet_Operacion.DOPE_Cantidad40;
                     Presenter.TempItemDet_Operacion.DOPE_Venta = Presenter.ItemDet_Operacion.DOPE_Venta40;
                     Presenter.TempItemDet_Operacion.DOPE_Venta40 = Presenter.ItemDet_Operacion.DOPE_Venta40;
                     Presenter.TempItemDet_Operacion.DOPE_VentaSada = Presenter.ItemDet_Operacion.DOPE_VentaSada40;
                     Presenter.TempItemDet_Operacion.DOPE_VentaSada40 = Presenter.ItemDet_Operacion.DOPE_VentaSada40;
                     Presenter.TempItemDet_Operacion.DOPE_PrecioTotVta = Presenter.ItemDet_Operacion.DOPE_Cantidad40 * (Presenter.PrecioSada ? Presenter.ItemDet_Operacion.DOPE_VentaSada40 : Presenter.ItemDet_Operacion.DOPE_Venta40);
                     break;
                  case 2:
                     firstOrDefault = tempItemsDetOperacion.FirstOrDefault(data => data.PACK_Codigo == null);
                     if (firstOrDefault != null)
                     {
                        Presenter.TempItemDet_Operacion.CTAR_Codigo = firstOrDefault.CTAR_Codigo != null ? firstOrDefault.CTAR_Codigo.Value : firstOrDefault.CTAR_Codigo;
                        Presenter.TempItemDet_Operacion.DTAR_Item = firstOrDefault.DTAR_Item != null ? firstOrDefault.DTAR_Item.Value : firstOrDefault.DTAR_Item;
                     }
                     Presenter.TempItemDet_Operacion.CTAR_Codigo = Presenter.ItemDet_Operacion.CTAR_Codigo;
                     Presenter.TempItemDet_Operacion.DOPE_Costo = Presenter.ItemDet_Operacion.DOPE_CostoHBL;
                     Presenter.TempItemDet_Operacion.DOPE_CostoSada = Presenter.ItemDet_Operacion.DOPE_CostoSadaHBL;
                     Presenter.TempItemDet_Operacion.DOPE_Cantidad = Convert.ToInt16(Presenter.ItemDet_Operacion.DOPE_Cantidad20 + Presenter.ItemDet_Operacion.DOPE_Cantidad40);
                     Presenter.TempItemDet_Operacion.DOPE_Venta = Presenter.ItemDet_Operacion.DOPE_VentaHBL;
                     Presenter.TempItemDet_Operacion.DOPE_VentaHBL = Presenter.ItemDet_Operacion.DOPE_VentaHBL;
                     Presenter.TempItemDet_Operacion.DOPE_VentaSada = Presenter.ItemDet_Operacion.DOPE_VentaSadaHBL;
                     Presenter.TempItemDet_Operacion.DOPE_VentaSadaHBL = Presenter.ItemDet_Operacion.DOPE_VentaSadaHBL;
                     Presenter.TempItemDet_Operacion.CONS_CodBas = "004";
                     Presenter.TempItemDet_Operacion.CONS_TabBas = "BSL";
                     Presenter.TempItemDet_Operacion.DOPE_PrecioTotVta = Presenter.PrecioSada ? Presenter.ItemDet_Operacion.DOPE_VentaSadaHBL : Presenter.ItemDet_Operacion.DOPE_VentaHBL;
                     break;
               }
               Presenter.TempItemDet_Operacion.Validado = true;
               Presenter.TempItemDet_Operacion.DOPE_Fila = ultimaFila;
               Presenter.ItemsDet_OperacionRegistros.Add(Presenter.TempItemDet_Operacion);
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
         { Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al cerrar la ventana.", ex); }
      }
      #endregion

      #endregion

      #region [ Metodos ]

      #region [ Detalle ]

      #endregion
      #endregion

      #region [ Eventos ]

      #region [ Detalle Operación ]
      void btnAgregar_Click(object sender, EventArgs e)
      {
         if (Convert.ToDecimal(txtVenta20.Text) == 0 && Convert.ToDecimal(txtVentaSada20.Text) == 0)
            if (Convert.ToDecimal(txtDOPE_Cantidad20.Text) > 0)
            {
               Dialogos.MostrarMensajeInformacion(Presenter.Title, "El valor de venta del contenedor de 20 es 0, no puede ingresar cantidad");
               return;
            }
         if (Convert.ToDecimal(txtVenta40.Text) == 0 && Convert.ToDecimal(txtVentaSada40.Text) == 0)
            if (Convert.ToDecimal(txtDOPE_Cantidad40.Text) > 0)
            {
               Dialogos.MostrarMensajeInformacion(Presenter.Title, "El valor de venta del contenedor de 40 es 0, no puede ingresar cantidad");
               return;
            }
         Presenter.AgregarDetalleOperacion();
      }
      void PRO003DMview_Load(object sender, EventArgs e)
      {
         switch (Presenter.ItemDet_Operacion.CTAR_Tipo)
         {
            case "L":  /* Logistico  :) */
               Text = @"Servicio Logístico";
               tlpTarifarioLogistico.Visible = true;
               tlpTarifarioAduaneroTransp.Visible = false;
               Height = 331;

               break;
            case "A":   /* Aduanero  :) */
               Text = @"Servicio Aduanero";
               tlpTarifarioLogistico.Visible = false;
               tlpTarifarioAduaneroTransp.Visible = true;
               lblCostoAduanero.Text = @"Comisión:";
               tlpTarifarioAduaneroTransp.RowStyles[0].Height = 0;
               tlpTarifarioAduaneroTransp.RowStyles[1].Height = 27;
               tlpTarifarioAduaneroTransp.RowStyles[2].Height = 27;
               tlpTarifarioAduaneroTransp.RowStyles[3].Height = 0;
               tlpTarifarioAduaneroTransp.RowStyles[4].Height = 0;

               CbTipo.Visible = false;
               Height = 198;
               break;
            case "T":   /* Transporte  :) */
               Text = @"Servicio Transportista";
               tlpTarifarioLogistico.Visible = false;
               tlpTarifarioAduaneroTransp.Visible = true;
               tlpTarifarioAduaneroTransp.RowStyles[0].Height = 27;
               tlpTarifarioAduaneroTransp.RowStyles[1].Height = 27;
               tlpTarifarioAduaneroTransp.RowStyles[2].Height = 0;
               tlpTarifarioAduaneroTransp.RowStyles[3].Height = 27;
               tlpTarifarioAduaneroTransp.RowStyles[4].Height = 27;
               lblCostoAduanero.Text = @"Flete:";
               CbTipo.Visible = true;
               Height = 198;
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
