using System;
using System.Collections;
using System.ComponentModel;
using System.Globalization;
using System.Windows.Forms;
using Delfin.Entities;
using Infrastructure.Aspect.Constants;
using Infrastructure.Client.FormClose;
using Infrastructure.WinFormsControls;
using TiposEntidad = Delfin.Controls.TiposEntidad;

namespace Delfin.Principal
{
   public partial class PRO003DSMview : Form, IPRO003DSMview
   {
      #region [ Variables ]
      private bool Closing = false;

      public enum TOpcion
      {
         Nuevo, Editar
      }
      #endregion

      #region [ Formulario ]
      public PRO003DSMview()
      {
         InitializeComponent();
         try
         {

            btnAgregar.Click += btnAgregar_Click;
            btnGuardar.Click += btnGuardar_Click;
            CbTipoGasto.SelectedValueChanged += CbTipoGasto_SelectedValueChanged;
            txtSOPE_Cantidad.ValueChanged += txtSOPE_Cantidad_ValueChanged;
            txtSOPE_PrecioUni.ValueChanged += txtSOPE_PrecioUni_ValueChanged;
            cmbTIPE_codigo.SelectedIndexChanged += cmbTIPE_codigo_SelectedIndexChanged;
            Load += PRO003DSMview_Load;
         }
         catch (Exception ex)
         { Dialogos.MostrarMensajeError(Presenter.Title, Mensajes.ConstructorView, ex); }
      }

      void cmbTIPE_codigo_SelectedIndexChanged(object sender, EventArgs e)
      {
         try
         {
            if (cmbTIPE_codigo.TipoEntidadSelectedItem != null)
            {
               ENTC_CodigoEntidad.Enabled = true;
               ENTC_CodigoEntidad.TipoEntidad = Delfin.Controls.EntidadClear.getTipoEntidadEnum(cmbTIPE_codigo.TipoEntidadSelectedItem.TIPE_Codigo);
            }
            else
            {
               ENTC_CodigoEntidad.Enabled = false;
               ENTC_CodigoEntidad.ClearValue();
            }
         }
         catch (Exception)
         { }
      }

      void PRO003DSMview_Load(object sender, EventArgs e)
      {
         if (Presenter._NuevoServicio)
         {
            btnAgregar.Visible = true;
            btnGuardar.Visible = false;
         }
         else
         {
            btnAgregar.Visible = false;
            btnGuardar.Visible = true;
         }
      }
      #endregion

      #region [ Propiedades ]
      public PRO003Presenter Presenter { get; set; }
      private Hashtable HashFormulario { get; set; }
      #endregion

      #region [ IPRO001DView ]
      public void LoadView()
      {
         try
         {
            ENTC_CodigoEntidad.LoadControl(Presenter.ContainerService, "Entidad", TiposEntidad.TIPE_Proveedor, null, true);
            cmbTIPE_codigo.LoadControl(Presenter.ContainerService, "Tipo Entidad", "< Sel. Tipo Entidad >", ListSortDirection.Ascending, 2, new Int16[] { 2, 6 });

            System.Data.DataTable _dt;
            _dt = Presenter.GetTodosServicios();
            CbSERV_Codigo.DataSource = _dt;
            CbSERV_Codigo.ValueMember = "SERV_Codigo";
            CbSERV_Codigo.DisplayMember = "SERV_Nombre_SPA";
            SetMaxWidth("12345678901234567890123456789012345678901234567890123456");
            CbBase.DataSource = Presenter.ListConstantes;
            CbBase.ValueMember = "CONS_CodTipo";
            CbBase.DisplayMember = "CONS_Desc_SPA";

            CbTIPO_CodMnd.LoadControl(Presenter.ContainerService, "Tabla Moneda", "MND", "< Selecione Moneda >", ListSortDirection.Descending);

            CbTipoGasto.LoadControl(Presenter.ContainerService, "Tabla TipoGasto", "TMC", "< Seleccionar Gasto >", ListSortDirection.Descending);
         }
         catch (Exception ex)
         { Dialogos.MostrarMensajeError(Presenter.Title, Mensajes.LoadView, ex); }
      }

      private void SetMaxWidth(string textmaxlenght)
      {
         try
         {
            System.Drawing.Graphics g = this.CreateGraphics();
            System.Drawing.Font font = this.Font;
            CbSERV_Codigo.DropDownWidth = (Int32)g.MeasureString(textmaxlenght, font).Width;
         }
         catch (Exception)
         { throw; }
      }

      #region [ Detalle Servicio Operación ]

      public void ClearItem()
      {
         try
         {
            ENTC_CodigoEntidad.ClearValue();
            CbSERV_Codigo.SelectedIndex = 0;
            txtSOPE_PrecioUni.Value = 0;
            txtSOPE_PrecioUni.Text = @"0";
            txtSOPE_Cantidad.Value = 0;
            txtSOPE_Cantidad.Text = @"0";
            CbBase.SelectedIndex = 0;
            CbTIPO_CodMnd.SelectedIndex = 0;
            txtSOPE_ImporteIngreso.Value = 0;
            txtSOPE_ImporteIngreso.Text = @"0";
            txtSOPE_ImporteEgreso.Value = 0;
            txtSOPE_ImporteEgreso.Text = @"0";
            CbTipoGasto.SelectedIndex = 0;
            txtSOPE_ImporteEgreso.Enabled = false;
            txtSOPE_ImporteIngreso.Enabled = false;
            txtSOPE_Costo.Value = 0;
            txtSOPE_Costo.Text = @"0";
            cmbTIPE_codigo.SelectedIndex = 0;
         }
         catch (Exception ex)
         { Dialogos.MostrarMensajeError(Presenter.Title, Mensajes.ClearItem, ex); }
      }
      public void GetItem()
      {
         try
         {
            if (ENTC_CodigoEntidad.SelectedItem != null && ENTC_CodigoEntidad.SelectedItem.ENTC_Codigo > 0)
            {
               Presenter.TempItemDet_OperacionServicio.ENTC_Codigo = ENTC_CodigoEntidad.SelectedItem.ENTC_Codigo;
               Presenter.TempItemDet_OperacionServicio.TIPE_Codigo = cmbTIPE_codigo.TipoEntidadSelectedItem.TIPE_Codigo;
               Presenter.TempItemDet_OperacionServicio.Proveedor = !String.IsNullOrEmpty(ENTC_CodigoEntidad.SelectedItem.ENTC_RazonSocial) ? ENTC_CodigoEntidad.SelectedItem.ENTC_RazonSocial : ENTC_CodigoEntidad.SelectedItem.ENTC_NomCompleto;
            }
            else
            {
               Presenter.TempItemDet_OperacionServicio.ENTC_Codigo = null;
               Presenter.TempItemDet_OperacionServicio.TIPE_Codigo = null;
               Presenter.TempItemDet_OperacionServicio.Proveedor = null;
            }
            if (CbSERV_Codigo.SelectedValue != null)
            {
               Presenter.TempItemDet_OperacionServicio.SERV_Codigo = Int32.Parse(CbSERV_Codigo.SelectedValue.ToString());
               Presenter.TempItemDet_OperacionServicio.CONS_Desc_Servicio = CbSERV_Codigo.Text;
            }
            else
            {
               Presenter.TempItemDet_OperacionServicio.SERV_Codigo = null;
               Presenter.TempItemDet_OperacionServicio.CONS_Desc_Servicio = null;
            }
            Presenter.TempItemDet_OperacionServicio.SOPE_PrecioUni = txtSOPE_PrecioUni.Value > 0 ? txtSOPE_PrecioUni.Value : 0;
            Presenter.TempItemDet_OperacionServicio.SOPE_Cantidad = (short)(txtSOPE_Cantidad.Value > 0 ? Convert.ToInt16(txtSOPE_Cantidad.Value) : 0);
            Presenter.TempItemDet_OperacionServicio.SOPE_Costo = txtSOPE_Costo.Value;
            if (CbBase.SelectedValue != null)
            {
               Presenter.TempItemDet_OperacionServicio.CONS_CodBas = CbBase.SelectedValue.ToString();
               Presenter.TempItemDet_OperacionServicio.CONS_TabBas = "BSL";
               Presenter.TempItemDet_OperacionServicio.CONS_Desc_Base = CbBase.Text;
            }
            else
            {
               Presenter.TempItemDet_OperacionServicio.CONS_CodBas = null;
               Presenter.TempItemDet_OperacionServicio.CONS_TabBas = null;
               Presenter.TempItemDet_OperacionServicio.CONS_Desc_Base = null;
            }
            if (CbTIPO_CodMnd.SelectedValue != null)
            {
               Presenter.TempItemDet_OperacionServicio.TIPO_CodMnd = CbTIPO_CodMnd.SelectedValue.ToString();
               Presenter.TempItemDet_OperacionServicio.TIPO_TabMnd = "MND";
               Presenter.TempItemDet_OperacionServicio.CONS_Desc_Moneda = CbTIPO_CodMnd.Text;
            }
            else
            {
               Presenter.TempItemDet_OperacionServicio.TIPO_CodMnd = null;
               Presenter.TempItemDet_OperacionServicio.TIPO_TabMnd = null;
               Presenter.TempItemDet_OperacionServicio.CONS_Desc_Moneda = null;
            }
            if (CbTipoGasto.SelectedValue != null)
            {
               Presenter.TempItemDet_OperacionServicio.CONS_CodTMC = CbTipoGasto.SelectedValue.ToString();
               Presenter.TempItemDet_OperacionServicio.CONS_TabTMC = "TMC";
               Presenter.TempItemDet_OperacionServicio.CONS_Desc_TMC = CbTipoGasto.Text;
               if (CbTipoGasto.SelectedValue.ToString().Equals("001")) //ingreso
               {
                  Presenter.TempItemDet_OperacionServicio.SOPE_ImporteIngreso = txtSOPE_ImporteIngreso.Value > 0 ? txtSOPE_ImporteIngreso.Value : 0;
               }
               else //egreso
               {
                  Presenter.TempItemDet_OperacionServicio.SOPE_ImporteEgreso = txtSOPE_ImporteEgreso.Value > 0 ? txtSOPE_ImporteEgreso.Value : 0;
               }
            }
            else
            {
               Presenter.TempItemDet_OperacionServicio.CONS_CodTMC = null;
            }
         }
         catch (Exception ex)
         { Dialogos.MostrarMensajeError(Presenter.Title, Mensajes.GetItem, ex); }
      }
      public void SetItem()
      {
         try
         {
            if (Presenter.ItemDet_OperacionServicio.ENTC_Codigo != null) { ENTC_CodigoEntidad.SetEntidad(Presenter.ItemDet_OperacionServicio.ENTC_Codigo.Value);  }
            if (Presenter.ItemDet_OperacionServicio.TIPE_Codigo.HasValue) { cmbTIPE_codigo.SelectedValue = Presenter.ItemDet_OperacionServicio.TIPE_Codigo.Value; }
            if (Presenter.ItemDet_OperacionServicio.SERV_Codigo != null) { CbSERV_Codigo.SelectedValue = Presenter.ItemDet_OperacionServicio.SERV_Codigo.Value; }

            txtSOPE_PrecioUni.Value = Presenter.ItemDet_OperacionServicio.SOPE_PrecioUni;
            txtSOPE_PrecioUni.Text = Presenter.ItemDet_OperacionServicio.SOPE_PrecioUni.ToString(CultureInfo.InvariantCulture);
            txtSOPE_Cantidad.Value = Convert.ToInt16(Presenter.ItemDet_OperacionServicio.SOPE_Cantidad);
            txtSOPE_Cantidad.Text = Presenter.ItemDet_OperacionServicio.SOPE_Cantidad.ToString(CultureInfo.InvariantCulture);
            if (Presenter.ItemDet_OperacionServicio.CONS_CodBas != null) { CbBase.SelectedValue = Presenter.ItemDet_OperacionServicio.CONS_CodBas; }

            if (Presenter.ItemDet_OperacionServicio.TIPO_CodMnd != null) { CbTIPO_CodMnd.SelectedValue = Presenter.ItemDet_OperacionServicio.TIPO_CodMnd; }
            if (Presenter.ItemDet_OperacionServicio.CONS_CodTMC == null) return;
            CbTipoGasto.SelectedValue = Presenter.ItemDet_OperacionServicio.CONS_CodTMC;
            if (Presenter.ItemDet_OperacionServicio.CONS_CodTMC.Equals("001")) //ingreso
            {
               txtSOPE_ImporteIngreso.Value = Presenter.ItemDet_OperacionServicio.SOPE_ImporteIngreso;
               txtSOPE_ImporteIngreso.Text = Presenter.ItemDet_OperacionServicio.SOPE_ImporteIngreso.ToString(CultureInfo.InvariantCulture);
            }
            else //egreso
            {
               txtSOPE_ImporteEgreso.Value = Presenter.ItemDet_OperacionServicio.SOPE_ImporteEgreso;
               txtSOPE_ImporteEgreso.Text = Presenter.ItemDet_OperacionServicio.SOPE_ImporteEgreso.ToString(CultureInfo.InvariantCulture);
            }
            txtSOPE_Costo.Text = Presenter.ItemDet_OperacionServicio.SOPE_Costo.ToString();
         }
         catch (Exception ex)
         { Dialogos.MostrarMensajeError(Presenter.Title, Mensajes.SetItem, ex); }
      }
      public void SetInstance(InstanceView x_instance)
      {
         try
         {
            errorProvider1.Dispose();
            btnAgregar.Enabled = true;
            txtSOPE_ImporteIngreso.Enabled = false;
            txtSOPE_ImporteEgreso.Enabled = false;
            
            switch (x_instance)
            {
               case InstanceView.Default:
                  break;
               case InstanceView.New:
                  cmbTIPE_codigo.TipoEntidadSelectedValue = Delfin.Controls.EntidadClear.GetCodigoTipoEntidad(TiposEntidad.TIPE_Proveedor);
                  HashFormulario = FormValidateChanges.iniciarComparacionFormulario(this);
                  break;
               case InstanceView.Edit:
                  if (String.IsNullOrEmpty(Presenter.ItemDet_OperacionServicio.CONS_CodEST) || Presenter.ItemDet_OperacionServicio.CONS_CodEST != "001")
                     btnAgregar.Enabled = String.IsNullOrEmpty(Presenter.ItemDet_OperacionServicio.CONS_CodEST);
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
            Dialogos.MostrarMensajeInformacion(Presenter.Title, "Faltan ingresar datos obligatorios: ", Presenter.TempItemDet_OperacionServicio.MensajeError, Dialogos.Boton.Detalles);
            FormShowErrorProvider<Det_Operacion_Servicio>.Validate(Presenter.TempItemDet_OperacionServicio, this, errorProvider1);
         }
         catch (Exception ex)
         { Dialogos.MostrarMensajeError(Presenter.Title, Mensajes.ShowItems, ex); }
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

      #region [ Detalle Servicio Operación ]
      private void CambiosImporte()
      {
         try
         {
            if (CbTipoGasto.SelectedValue == null) { txtSOPE_ImporteEgreso.Text = @"0"; txtSOPE_ImporteIngreso.Text = @"0"; return; }
            if (CbTipoGasto.SelectedValue.ToString().Equals("001")) // ingreso
            {
               txtSOPE_ImporteIngreso.Value = txtSOPE_Cantidad.Value * txtSOPE_PrecioUni.Value;
               txtSOPE_ImporteIngreso.Text = (txtSOPE_Cantidad.Value * txtSOPE_PrecioUni.Value).ToString(CultureInfo.InvariantCulture);
               txtSOPE_ImporteEgreso.Text = @"0";
            }
            else   //egreso
            {
               txtSOPE_ImporteEgreso.Value = txtSOPE_Cantidad.Value * txtSOPE_PrecioUni.Value;
               txtSOPE_ImporteEgreso.Text = (txtSOPE_Cantidad.Value * txtSOPE_PrecioUni.Value).ToString(CultureInfo.InvariantCulture);
               txtSOPE_ImporteIngreso.Text = @"0";
            }
         }
         catch (Exception) { }
      }
      #endregion
      #endregion

      #region [ Eventos ]

      #region [ Detalle Servicio Operación ]
      void btnAgregar_Click(object sender, EventArgs e)
      {
         Presenter.AgregarDetalleServicioOperacion();
      }
      void btnGuardar_Click(object sender, EventArgs e)
      {
         try
         {
            if (Presenter.GuardarDetalleServicioOperacion())
            {
               this.DialogResult = DialogResult.OK;
            }
            CerrarVenta();
         }
         catch (Exception)
         { }
      }
      void CbTipoGasto_SelectedValueChanged(object sender, EventArgs e)
      {
         CambiosImporte();
      }
      void txtSOPE_PrecioUni_ValueChanged(object sender, EventArgs e)
      {
         CambiosImporte();
      }
      void txtSOPE_Cantidad_ValueChanged(object sender, EventArgs e)
      {
         CambiosImporte();
      }
      #endregion

      #endregion
   }
}
