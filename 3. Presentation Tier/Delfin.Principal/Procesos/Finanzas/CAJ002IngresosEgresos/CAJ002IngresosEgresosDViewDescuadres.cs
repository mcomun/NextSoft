using Infrastructure.Aspect.Collections;
using Infrastructure.Aspect.Constants;
using Infrastructure.Client.FormClose;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Delfin.Principal
{
   public partial class CAJ002IngresosEgresosDViewDescuadres : Form
   {
      #region [ Variables ]

      public enum TipoInicio
      {
         Nuevo = 0, Editar = 1
      }

      #endregion

      #region [ Formulario ]

      public CAJ002IngresosEgresosDViewDescuadres()
      {
         InitializeComponent();
         try
         {
            txnTIPD_TipoCambio.Tag = "TIPD_TipoCambioMSGERROR";
            txnTIPD_MontoDebe.Tag = "TIPD_MontoDebeMSGERROR";
            txnTIPD_MontoHaber.Tag = "TIPD_MontoHaberMSGERROR";
            txtTIPD_Cuenta.Tag = "TIPD_CuentaMSGERROR";
            cmbCENT_Ano.Tag = "CENT_AnoMSGERROR";
            txaCENT_Codigo.Tag = "CENT_CodigoMSGERROR";

            cmbTIPO_CodDES.Tag = "TIPO_CodDESMSGERROR";
            cmbTIPO_CodMND.Tag = "TIPO_CodMNDMSGERROR";
            //cmbTIPO_CodTDO.Tag = "TIPO_CodTDOMSGERROR";
            cmbTIPE_Codigo.Tag = "TIPE_CodigoMSGERROR";
            txaENTC_Codigo.Tag = "ENTC_CodigoMSGERROR";
            //txaCCCT_Codigo.Tag = "CCCT_CodigoMSGERROR";

            lblTIPD_Tipo.Enabled = false;
            cmbTIPD_Tipo.Enabled = true;
            lblTIPD_Item.Enabled = false;
            txtTIPD_Item.Enabled = false;
            lblTIPD_GeneraCtaCte.Enabled = false;
            chkTIPD_GeneraCtaCte.Enabled = false;
            
            txtDifDescuadre.Enabled = false;
            lblDifDescuadre.Enabled = false;
            txtPendiente.Enabled = false;
            lblPendiente.Enabled = false;

            btnGuardar.Click += btnGuardar_Click;
            btnSalir.Click += btnSalir_Click;
            cmbTIPO_CodDES.SelectedIndexChanged += cmbTIPO_CodDES_SelectedIndexChanged;
            cmbTIPD_Tipo.SelectedIndexChanged += cmbTIPD_Tipo_SelectedIndexChanged;
            cmbTIPE_Codigo.SelectedIndexChanged += cmbTIPE_Codigo_SelectedIndexChanged;

            txaCENT_Desc.AyudaClick += txaCENT_Desc_AyudaClick;
            txaCENT_Codigo.AyudaClick += txaCENT_Codigo_AyudaClick;

            txaCENT_Codigo.AyudaClean += txaCENT_Codigo_AyudaClean;
            txaCENT_Desc.AyudaClean += txaCENT_Desc_AyudaClean;
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error inicializando el formulario MView.", ex); }
      }

      #endregion

      #region [ Propiedades ]

      public CAJ002IngresosEgresosPresenter Presenter { get; set; }
      public Entities.Tipificaciones ItemTipificacion { get; set; }
      public TipoInicio TInicio { get; set; }

      #endregion

      #region [ CAJ002IngresosEgresosDViewDescuadres ]

      public void LoadView(TipoInicio x_opcion)
      {
         try
         {
            txaENTC_Codigo.LoadControl(Presenter.ContainerService, Delfin.Controls.TiposEntidad.TIPE_Cliente, null, null, true);
            cmbTIPO_CodMND.LoadControl(Presenter.ContainerService, "Ayuda Moneda", "MND", "< Sel.  Moneda>", ListSortDirection.Ascending);
            cmbTIPE_Codigo.LoadControl(Presenter.ContainerService, "Tipo de Entidad", "< Sel. Tipo de Entidad >", ListSortDirection.Ascending);
            //cmbTIPO_CodDES.LoadControl(Presenter.ContainerService, "Tipo de Descuadre/Tipificación", "DES", "< Sel. Tipificación >", ListSortDirection.Ascending);
            cmbTIPD_Tipo.LoadControl("Tipo de Tipificación", Delfin.Controls.Tipos.ComboBoxConstantes.OConstantes.TipoMovimientoDB, "< Sel. Tipo >", ListSortDirection.Ascending);

            cmbCENT_Ano.ValueMember = "CENT_Ano";
            cmbCENT_Ano.DisplayMember = "CENT_Ano";
            cmbCENT_Ano.DataSource = Presenter.DSPeriodos.Tables[0];

            txnTIPD_TipoCambio.Value = Presenter.TipoCambio;

            switch (Presenter.TMovimiento)
            {
               case TipoMovimientoCtaCte.Ingresos:
                  cmbTIPO_CodDES.LoadControl(Presenter.ListTipoDES.Where(TDES => TDES.TIPO_Desc3 == "I" || String.IsNullOrEmpty(TDES.TIPO_Desc3)).ToObservableCollection(), "Tipo Descuadre", "< Sel. Tipificación >", ListSortDirection.Ascending);
                  break;
               case TipoMovimientoCtaCte.Egresos:
                  cmbTIPO_CodDES.LoadControl(Presenter.ListTipoDES.Where(TDES => TDES.TIPO_Desc3 == "E" || String.IsNullOrEmpty(TDES.TIPO_Desc3)).ToObservableCollection(), "Tipo Descuadre", "< Sel. Tipificación >", ListSortDirection.Ascending);
                  break;
               default:
                  break;
            }

            switch (TInicio)
            {
               case TipoInicio.Nuevo:

                  break;
               case TipoInicio.Editar:
                  break;
               default:
                  break;
            }
            SetItem();
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error en el LoadView.", ex); }
      }



      #endregion

      #region [ Metodos ]

      public void ShowValidation()
      {
         try
         {
            Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Presenter.Title, "Faltan ingresar datos obligatorios: ", ItemTipificacion.MensajeError, Infrastructure.WinForms.Controls.Dialogos.Boton.Detalles);
            FormShowErrorProvider<Entities.Tipificaciones>.Validate(ItemTipificacion, this, errorProviderTipificacion);
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, Mensajes.ShowItems, ex); }
      }

      public void GetItem()
      {
         try
         {
            if (ItemTipificacion != null)
            {
               ItemTipificacion.TIPD_TipoCambio = txnTIPD_TipoCambio.Value;
               ItemTipificacion.TIPD_MontoDebe = txnTIPD_MontoDebe.Value;
               ItemTipificacion.TIPD_MontoHaber = txnTIPD_MontoHaber.Value;
               ItemTipificacion.TIPD_GeneraCtaCte = chkTIPD_GeneraCtaCte.Checked;

               if (cmbTIPD_Tipo.SelectedValue != null)
               {
                  ItemTipificacion.TIPD_Tipo = cmbTIPD_Tipo.SelectedValue.ToString();
                  ItemTipificacion.TIPD_Tipo_Text = cmbTIPD_Tipo.Text;
               }
               else { ItemTipificacion.TIPD_Tipo = null; ItemTipificacion.TIPD_Tipo_Text = null; }

               if (!String.IsNullOrEmpty(txtTIPD_Cuenta.Text)) { ItemTipificacion.TIPD_Cuenta = txtTIPD_Cuenta.Text; } else { ItemTipificacion.TIPD_Cuenta = null; }
               if (cmbCENT_Ano.SelectedValue != null) { ItemTipificacion.CENT_Ano = cmbCENT_Ano.SelectedValue.ToString(); }{ ItemTipificacion.CENT_Ano = null; }
               if (!String.IsNullOrEmpty(txaCENT_Codigo.Text)) { ItemTipificacion.CENT_Codigo = txaCENT_Codigo.Text; } else { ItemTipificacion.CENT_Codigo = null; }
               if (!String.IsNullOrEmpty(txaCENT_Desc.Text)) { ItemTipificacion.CENT_Desc = txaCENT_Desc.Text; } else { ItemTipificacion.CENT_Desc = null; }

               if (cmbTIPO_CodDES.TiposSelectedItem != null)
               {
                  ItemTipificacion.TIPO_TabDES = cmbTIPO_CodDES.TiposSelectedItem.TIPO_CodTabla;
                  ItemTipificacion.TIPO_CodDES = cmbTIPO_CodDES.TiposSelectedItem.TIPO_CodTipo;
                  ItemTipificacion.TIPO_CodDES_Text = cmbTIPO_CodDES.Text;
               }
               else
               { ItemTipificacion.TIPO_TabDES = null; ItemTipificacion.TIPO_CodDES = null; }

               if (cmbTIPO_CodMND.TiposSelectedItem != null)
               { 
                  ItemTipificacion.TIPO_TabMND = cmbTIPO_CodMND.TiposSelectedItem.TIPO_CodTabla; 
                  ItemTipificacion.TIPO_CodMND = cmbTIPO_CodMND.TiposSelectedItem.TIPO_CodTipo;
                  ItemTipificacion.TIPO_CodMND_Text = cmbTIPO_CodMND.TiposSelectedItem.TIPO_DescC;
               }
               else
               { ItemTipificacion.TIPO_TabMND = null; ItemTipificacion.TIPO_CodMND = null; }

               if (cmbTIPE_Codigo.TipoEntidadSelectedItem != null)
               {
                  ItemTipificacion.TIPE_Codigo = cmbTIPE_Codigo.TipoEntidadSelectedItem.TIPE_Codigo;
                  ItemTipificacion.TIPE_Descripcion = cmbTIPE_Codigo.TipoEntidadSelectedItem.TIPE_Descripcion;
               }
               else { ItemTipificacion.TIPE_Codigo = null; ItemTipificacion.TIPE_Descripcion = null; }
               if (txaENTC_Codigo.SelectedItem != null)
               {
                  ItemTipificacion.ENTC_Codigo = txaENTC_Codigo.SelectedItem.ENTC_Codigo;
                  ItemTipificacion.ENTC_RazonSocial = txaENTC_Codigo.SelectedItem.ENTC_RazonSocial;
               }
               else { ItemTipificacion.ENTC_Codigo = null; ItemTipificacion.ENTC_RazonSocial = null; }

               //if(cmbTIPD_Tipo.ConstantesSelectedItem

            }
         }
         catch (Exception)
         { throw; }
      }

      public void SetItem()
      {
         try
         {
            if (ItemTipificacion != null)
            {
               if (!String.IsNullOrEmpty(ItemTipificacion.TIPO_CodDES)) { cmbTIPO_CodDES.SelectedValue = ItemTipificacion.TIPO_CodDES; } else { cmbTIPO_CodDES.SelectedIndex = 0; }

               txnTIPD_TipoCambio.Value = ItemTipificacion.TIPD_TipoCambio;
               txnTIPD_MontoDebe.Value = ItemTipificacion.TIPD_MontoDebe;
               txnTIPD_MontoHaber.Value = ItemTipificacion.TIPD_MontoHaber;
               chkTIPD_GeneraCtaCte.Checked = ItemTipificacion.TIPD_GeneraCtaCte;

               if (!String.IsNullOrEmpty(ItemTipificacion.TIPD_Tipo)) { cmbTIPD_Tipo.SelectedValue = ItemTipificacion.TIPD_Tipo; } else { cmbTIPD_Tipo.SelectedIndex = -1; }
               if (!String.IsNullOrEmpty(ItemTipificacion.TIPD_Cuenta)) { txtTIPD_Cuenta.Text = ItemTipificacion.TIPD_Cuenta; } else { txtTIPD_Cuenta.Clear(); }
               if (!String.IsNullOrEmpty(ItemTipificacion.CENT_Ano)) { cmbCENT_Ano.SelectedValue = ItemTipificacion.CENT_Ano; }

               if (!String.IsNullOrEmpty(ItemTipificacion.CENT_Codigo))
               {
                  txaCENT_Codigo.SetValue(ItemTipificacion.CENT_Codigo, ItemTipificacion.CENT_Codigo);
                  txaCENT_Desc.SetValue(ItemTipificacion.CENT_Desc, ItemTipificacion.CENT_Desc);
               }

               if (!String.IsNullOrEmpty(ItemTipificacion.TIPO_CodMND)) { cmbTIPO_CodMND.SelectedValue = ItemTipificacion.TIPO_CodMND; } else { cmbTIPO_CodMND.SelectedIndex = 0; }
               if (ItemTipificacion.TIPE_Codigo.HasValue) { cmbTIPE_Codigo.SelectedValue = ItemTipificacion.TIPE_Codigo.Value; } else { cmbTIPE_Codigo.SelectedIndex = 0; }
               if (ItemTipificacion.ENTC_Codigo.HasValue) { txaENTC_Codigo.SetEntidad(ItemTipificacion.ENTC_Codigo); }

               txtDifDescuadre.Text = Presenter.Total.ToString("#,###,##0.00");
               txtPendiente.Text = Presenter.Pendiente.ToString("#,###,##0.00");
            }
         }
         catch (Exception)
         { throw; }
      }

      #endregion

      #region [ Eventos ]

      private void btnSalir_Click(object sender, EventArgs e)
      {
         try
         {
            this.Close();
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error cerrar el registro.", ex); }
      }

      private void btnGuardar_Click(object sender, EventArgs e)
      {
         try
         {
            GetItem();
            if (ItemTipificacion.Validar())
            {
               this.DialogResult = DialogResult.OK;
            }
            else { ShowValidation(); }
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error grabar el registro.", ex); }
      }

      private void cmbTIPO_CodDES_SelectedIndexChanged(object sender, EventArgs e)
      {
         try
         {
            if (cmbTIPO_CodDES.TiposSelectedItem != null)
            {
               chkTIPD_GeneraCtaCte.Visible = true;
               //cmbTIPD_Tipo.Enabled = false;
               chkTIPD_GeneraCtaCte.Checked = (cmbTIPO_CodDES.TiposSelectedItem.TIPO_Num1.HasValue ? cmbTIPO_CodDES.TiposSelectedItem.TIPO_Num1.Value == 1 : false);

               //if (!String.IsNullOrEmpty(cmbTIPO_CodDES.TiposSelectedItem.TIPO_Desc3))
               //{ cmbTIPD_Tipo.SelectedValue = cmbTIPO_CodDES.TiposSelectedItem.TIPO_Desc3; }
               //else
               //{
                  lblTIPD_Tipo.Enabled = true;
                  cmbTIPD_Tipo.Enabled = true;
                  lblTIPD_MontoDebe.Enabled = false;
                  txnTIPD_MontoDebe.Enabled = false;
                  txnTIPD_MontoDebe.Value = 0;
                  lblTIPD_MontoHaber.Enabled = false;
                  txnTIPD_MontoHaber.Enabled = false;
                  txnTIPD_MontoHaber.Value = 0;
                  cmbTIPD_Tipo.SelectedIndex = 0;
               //}

               cmbCENT_Ano.SelectedValue = Presenter.Fecha.Year.ToString();
               txtTIPD_Cuenta.Text = cmbTIPO_CodDES.TiposSelectedItem.TIPO_Desc2;

               
               if (!String.IsNullOrEmpty(cmbTIPO_CodDES.TiposSelectedItem.TIPO_Mascara))
               {
                  txaCENT_Codigo.SetValue(cmbTIPO_CodDES.TiposSelectedItem.TIPO_Mascara, cmbTIPO_CodDES.TiposSelectedItem.TIPO_Mascara);
                  //txaCENT_Desc.SetValue(cmbTIPO_CodDES.TiposSelectedItem.TIPO_Mascara, cmbTIPO_CodDES.TiposSelectedItem.TIPO_Mascara);
                  String _CENT_Codigo = txaCENT_Codigo.Text;
                  String _CENT_Desc = null;
                  if (Presenter.AyudaCentroCto(cmbCENT_Ano.SelectedValue.ToString(), ref _CENT_Codigo, ref _CENT_Desc))
                  {
                     //txaCENT_Codigo.SetValue(_CENT_Codigo, _CENT_Codigo);
                     txaCENT_Desc.SetValue(_CENT_Desc, _CENT_Desc);
                  }
                  
               }
               else
               { txaCENT_Codigo.ClearValue(); txaCENT_Desc.ClearValue(); }
            }
            else
            {
               chkTIPD_GeneraCtaCte.Checked = false;
               txtTIPD_Cuenta.Clear();
               txaCENT_Codigo.ClearValue();
               txaCENT_Desc.ClearValue();
            }
         }
         catch (Exception)
         { }
      }

      private void cmbTIPD_Tipo_SelectedIndexChanged(object sender, EventArgs e)
      {
         try
         {
            if (cmbTIPO_CodDES.TiposSelectedItem != null && cmbTIPD_Tipo.ConstantesSelectedItem != null && !String.IsNullOrEmpty(cmbTIPD_Tipo.ConstantesSelectedItem.CONS_CodTipo))
            {
               if (cmbTIPD_Tipo.ConstantesSelectedItem.CONS_CodTipo.Equals("I"))
               {
                  lblTIPD_MontoDebe.Enabled = true;
                  txnTIPD_MontoDebe.Enabled = true;
                  txnTIPD_MontoDebe.Value = 0;
                  lblTIPD_MontoHaber.Enabled = false;
                  txnTIPD_MontoHaber.Enabled = false;
                  txnTIPD_MontoHaber.Value = 0;
               }
               else if (cmbTIPD_Tipo.ConstantesSelectedItem.CONS_CodTipo.Equals("E"))
               {
                  lblTIPD_MontoDebe.Enabled = false;
                  txnTIPD_MontoDebe.Enabled = false;
                  txnTIPD_MontoDebe.Value = 0;
                  lblTIPD_MontoHaber.Enabled = true;
                  txnTIPD_MontoHaber.Enabled = true;
                  txnTIPD_MontoHaber.Value = 0;
               }
               else
               {
                  cmbTIPD_Tipo.Enabled = true;
                  lblTIPD_MontoDebe.Enabled = false;
                  txnTIPD_MontoDebe.Enabled = false;
                  txnTIPD_MontoDebe.Value = 0;
                  lblTIPD_MontoHaber.Enabled = false;
                  txnTIPD_MontoHaber.Enabled = false;
                  txnTIPD_MontoHaber.Value = 0;
               }
            }
            else
            {
               lblTIPD_Tipo.Enabled = true;
               cmbTIPD_Tipo.Enabled = true;
               lblTIPD_MontoDebe.Enabled = false;
               txnTIPD_MontoDebe.Enabled = false;
               txnTIPD_MontoDebe.Value = 0;
               lblTIPD_MontoHaber.Enabled = false;
               txnTIPD_MontoHaber.Enabled = false;
               txnTIPD_MontoHaber.Value = 0;
               cmbTIPD_Tipo.SelectedIndex = 0;
            }
         }
         catch (Exception)
         { }
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
            else { txaENTC_Codigo.Enabled = false; txaENTC_Codigo.Clear(); }
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al cambiar el tipo de entidad.", ex); }
      }

      #region [ Centros de Costo ]

      private void txaCENT_Desc_AyudaClick(object sender, EventArgs e)
      {
         try
         {
            String _CENT_Codigo = null;
            String _CENT_Desc = txaCENT_Desc.Text;
            if (Presenter.AyudaCentroCto(cmbCENT_Ano.SelectedValue.ToString(), ref _CENT_Codigo, ref _CENT_Desc))
            {
               txaCENT_Codigo.SetValue(_CENT_Codigo, _CENT_Codigo);
               txaCENT_Desc.SetValue(_CENT_Desc, _CENT_Desc);
            }
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al cargar la ayuda de Centros de Costo.", ex); }
      }

      private void txaCENT_Codigo_AyudaClick(object sender, EventArgs e)
      {
         try
         {

            String _CENT_Codigo = txaCENT_Codigo.Text;
            String _CENT_Desc = null;
            if (Presenter.AyudaCentroCto(cmbCENT_Ano.SelectedValue.ToString(), ref _CENT_Codigo, ref _CENT_Desc))
            {
               txaCENT_Codigo.SetValue(_CENT_Codigo, _CENT_Codigo);
               txaCENT_Desc.SetValue(_CENT_Desc, _CENT_Desc);
            }

         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al cargar la ayuda de Centros de Costo.", ex); }
      }

      private void txaCENT_Codigo_AyudaClean(object sender, EventArgs e)
      {
         try
         {
            if (txaCENT_Codigo.Value == null)
            { txaCENT_Desc.ClearValue(); txaCENT_Codigo.ClearValue(); }
         }
         catch (Exception)
         { }
      }

      private void txaCENT_Desc_AyudaClean(object sender, EventArgs e)
      {
         try
         {
            if (txaCENT_Desc.Value == null)
            { txaCENT_Desc.ClearValue(); txaCENT_Codigo.ClearValue(); }
         }
         catch (Exception)
         { }
      }


      #endregion

      #endregion

   }
}
