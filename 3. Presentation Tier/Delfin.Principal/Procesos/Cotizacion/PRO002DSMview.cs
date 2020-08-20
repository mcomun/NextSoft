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
    public partial class PRO002DSMview : Form, IPRO002DSMview
    {
        #region [ Variables ]
        private bool Closing = false;
        #endregion

        #region [ Formulario ]
        public PRO002DSMview()
        {
            InitializeComponent();
            try
            {
                btnAgregar.Click += btnAgregar_Click;
                CbTipoGasto.SelectedValueChanged += CbTipoGasto_SelectedValueChanged;
                txtSCOT_Cantidad.ValueChanged += txtSCOT_Cantidad_ValueChanged;
                txtSCOT_PrecioUni.ValueChanged += txtSCOT_PrecioUni_ValueChanged;
                Load += PRO002DSMview_Load;
            }
            catch (Exception ex)
            { Dialogos.MostrarMensajeError(Presenter.Title, Mensajes.ConstructorView, ex); }
        }
        void PRO002DSMview_Load(object sender, EventArgs e)
        {

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
                ENTC_CodigoEntidad.TipoEntidad = TiposEntidad.TIPE_Proveedor;

                CbSERV_Codigo.DataSource = Presenter.GetTodosServicios();
                CbSERV_Codigo.ValueMember = "SERV_Codigo";
                CbSERV_Codigo.DisplayMember = "SERV_Nombre_SPA";
                SetMaxWidth("01234567890123456789012345678901234567890123456789", CbSERV_Codigo);
                CbBase.DataSource = Presenter.ListConstantes;
                CbBase.ValueMember = "CONS_CodTipo";
                CbBase.DisplayMember = "CONS_Desc_SPA";

                CbTIPO_CodMnd.LoadControl(Presenter.ContainerService, "Tabla Moneda", "MND", "< Selecione Moneda >", ListSortDirection.Descending);

                CbTipoGasto.LoadControl(Presenter.ContainerService, "Tabla TipoGasto", "TMC", "< Seleccionar Gasto >", ListSortDirection.Descending);
            }
            catch (Exception ex)
            { Dialogos.MostrarMensajeError(Presenter.Title, Mensajes.LoadView, ex); }
        }

        private void SetMaxWidth(string textmaxlenght, ComboBox Combo)
        {
           try
           {
              System.Drawing.Graphics g = this.CreateGraphics();
              System.Drawing.Font font = this.Font;
              Combo.DropDownWidth = (Int32)g.MeasureString(textmaxlenght, font).Width;
           }
           catch (Exception)
           { throw; }
        }
        #region [ Detalle Servicio Cotización ]
        public void ClearItem()
        {
            try
            {
                ENTC_CodigoEntidad.ClearValue();
                CbSERV_Codigo.SelectedIndex = 0;
                txtSCOT_PrecioUni.Value = 0;
                txtSCOT_PrecioUni.Text = @"0";
                txtSCOT_Cantidad.Value = 0;
                txtSCOT_Cantidad.Text = @"0";
                CbBase.SelectedIndex = 0;
                CbTIPO_CodMnd.SelectedIndex = 0;
                txtSCOT_ImporteIngreso.Value = 0;
                txtSCOT_ImporteIngreso.Text = @"0";
                txtSCOT_ImporteEgreso.Value = 0;
                txtSCOT_ImporteEgreso.Text = @"0";
                CbTipoGasto.SelectedIndex = 0;
                txtSCOT_ImporteEgreso.Enabled = false;
                txtSCOT_ImporteIngreso.Enabled = false;
            }
            catch (Exception ex)
            { Dialogos.MostrarMensajeError(Presenter.Title, Mensajes.ClearItem, ex); }
        }
        public void GetItem()
        {
            try
            {
                if (ENTC_CodigoEntidad.Value != null && ENTC_CodigoEntidad.Value.ENTC_Codigo > 0)
                {
                    Presenter.TempItemDet_CotizacionServicio.ENTC_Codigo = ENTC_CodigoEntidad.Value.ENTC_Codigo;
                    Presenter.TempItemDet_CotizacionServicio.TIPE_Codigo = Convert.ToInt16(2);// proveedor
                    Presenter.TempItemDet_CotizacionServicio.Proveedor = ENTC_CodigoEntidad.Value.ENTC_RazonSocial != "" ? ENTC_CodigoEntidad.Value.ENTC_RazonSocial : ENTC_CodigoEntidad.Value.ENTC_NomCompleto;
                }
                else
                {
                    Presenter.TempItemDet_CotizacionServicio.ENTC_Codigo = null;
                    Presenter.TempItemDet_CotizacionServicio.TIPE_Codigo = null;
                    Presenter.TempItemDet_CotizacionServicio.Proveedor = null;
                }
                if (CbSERV_Codigo.SelectedValue != null)
                {
                    Presenter.TempItemDet_CotizacionServicio.SERV_Codigo = Int32.Parse(CbSERV_Codigo.SelectedValue.ToString());
                    Presenter.TempItemDet_CotizacionServicio.CONS_Desc_Servicio = CbSERV_Codigo.Text;
                }
                else
                {
                    Presenter.TempItemDet_CotizacionServicio.SERV_Codigo = null;
                    Presenter.TempItemDet_CotizacionServicio.CONS_Desc_Servicio = null;
                }
                Presenter.TempItemDet_CotizacionServicio.SCOT_PrecioUni = txtSCOT_PrecioUni.Value > 0 ? txtSCOT_PrecioUni.Value : 0;
                Presenter.TempItemDet_CotizacionServicio.SCOT_Cantidad = (short)(txtSCOT_Cantidad.Value > 0 ? Convert.ToInt16(txtSCOT_Cantidad.Value) : 0);
                if (CbBase.SelectedValue != null)
                {
                    Presenter.TempItemDet_CotizacionServicio.CONS_CodBas = CbBase.SelectedValue.ToString();
                    Presenter.TempItemDet_CotizacionServicio.CONS_TabBas = "BSL";
                    Presenter.TempItemDet_CotizacionServicio.CONS_Desc_Base = CbBase.Text;
                }
                else
                {
                    Presenter.TempItemDet_CotizacionServicio.CONS_CodBas = null;
                    Presenter.TempItemDet_CotizacionServicio.CONS_TabBas = null;
                    Presenter.TempItemDet_CotizacionServicio.CONS_Desc_Base = null;
                }
                if (CbTIPO_CodMnd.SelectedValue != null)
                {
                    Presenter.TempItemDet_CotizacionServicio.TIPO_CodMnd = CbTIPO_CodMnd.SelectedValue.ToString();
                    Presenter.TempItemDet_CotizacionServicio.TIPO_TabMnd = "MND";
                    Presenter.TempItemDet_CotizacionServicio.CONS_Desc_Moneda = CbTIPO_CodMnd.Text;
                }
                else
                {
                    Presenter.TempItemDet_CotizacionServicio.TIPO_CodMnd = null;
                    Presenter.TempItemDet_CotizacionServicio.TIPO_TabMnd = null;
                    Presenter.TempItemDet_CotizacionServicio.CONS_Desc_Moneda = null;
                }
                if (CbTipoGasto.SelectedValue != null)
                {
                    Presenter.TempItemDet_CotizacionServicio.CONS_CodTMC = CbTipoGasto.SelectedValue.ToString();
                    Presenter.TempItemDet_CotizacionServicio.CONS_TabTMC = "TMC";
                    Presenter.TempItemDet_CotizacionServicio.CONS_Desc_TMC = CbTipoGasto.Text;
                    if (CbTipoGasto.SelectedValue.ToString().Equals("001")) //ingreso
                    {
                        Presenter.TempItemDet_CotizacionServicio.SCOT_ImporteIngreso = txtSCOT_ImporteIngreso.Value > 0 ? txtSCOT_ImporteIngreso.Value : 0;
                    }
                    else //egreso
                    {
                        Presenter.TempItemDet_CotizacionServicio.SCOT_ImporteEgreso = txtSCOT_ImporteEgreso.Value > 0 ? txtSCOT_ImporteEgreso.Value : 0;
                    }
                }
                else
                {
                    Presenter.TempItemDet_CotizacionServicio.CONS_CodTMC = null;
                }
            }
            catch (Exception ex)
            { Dialogos.MostrarMensajeError(Presenter.Title, Mensajes.GetItem, ex); }
        }
        public void SetItem()
        {
            try
            {
                if (Presenter.ItemDet_CotizacionServicio.ENTC_Codigo != null)
                {
                    ENTC_CodigoEntidad.SetValue(Presenter.ItemDet_CotizacionServicio.ENTC_Codigo.Value);
                }
                if (Presenter.ItemDet_CotizacionServicio.SERV_Codigo != null)
                {
                    CbSERV_Codigo.SelectedValue = Presenter.ItemDet_CotizacionServicio.SERV_Codigo.Value;
                }
                txtSCOT_PrecioUni.Value = Presenter.ItemDet_CotizacionServicio.SCOT_PrecioUni;
                txtSCOT_PrecioUni.Text = Presenter.ItemDet_CotizacionServicio.SCOT_PrecioUni.ToString(CultureInfo.InvariantCulture);
                txtSCOT_Cantidad.Value = Convert.ToInt16(Presenter.ItemDet_CotizacionServicio.SCOT_Cantidad);
                txtSCOT_Cantidad.Text = Presenter.ItemDet_CotizacionServicio.SCOT_Cantidad.ToString(CultureInfo.InvariantCulture);
                if (Presenter.ItemDet_CotizacionServicio.CONS_CodBas != null)
                {
                    CbBase.ConstantesSelectedValue = Presenter.ItemDet_CotizacionServicio.CONS_CodBas;
                }

                if (Presenter.ItemDet_CotizacionServicio.TIPO_CodMnd != null)
                {
                    CbTIPO_CodMnd.SelectedValue = Presenter.ItemDet_CotizacionServicio.TIPO_CodMnd;
                }
                if (Presenter.ItemDet_CotizacionServicio.CONS_CodTMC != null)
                {
                    CbTipoGasto.SelectedValue = Presenter.ItemDet_CotizacionServicio.CONS_CodTMC;
                    if (Presenter.ItemDet_CotizacionServicio.CONS_CodTMC.Equals("001")) //ingreso
                    {
                        txtSCOT_ImporteIngreso.Value = Presenter.ItemDet_CotizacionServicio.SCOT_ImporteIngreso;
                        txtSCOT_ImporteIngreso.Text = Presenter.ItemDet_CotizacionServicio.SCOT_ImporteIngreso.ToString(CultureInfo.InvariantCulture);

                    }
                    else //egreso
                    {
                        txtSCOT_ImporteEgreso.Value = Presenter.ItemDet_CotizacionServicio.SCOT_ImporteEgreso;
                        txtSCOT_ImporteEgreso.Text = Presenter.ItemDet_CotizacionServicio.SCOT_ImporteEgreso.ToString(CultureInfo.InvariantCulture);
                    }
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
                btnAgregar.Enabled = true;
                switch (xInstance)
                {
                    case InstanceView.Default:
                        break;
                    case InstanceView.New:
                        Presenter.InstanceViewServicio = InstanceView.New;
                        HashFormulario = FormValidateChanges.iniciarComparacionFormulario(this);
                        break;
                    case InstanceView.Edit:
                        Presenter.InstanceViewServicio = InstanceView.Edit;
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
                Dialogos.MostrarMensajeInformacion(Presenter.Title, "Faltan ingresar datos obligatorios: ", Presenter.TempItemDet_CotizacionServicio.MensajeError, Dialogos.Boton.Detalles);
                FormShowErrorProvider<Det_Cotizacion_Servicio>.Validate(Presenter.TempItemDet_CotizacionServicio, this, errorProvider1);
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

        #region [ Detalle Servicio Cotización ]
        private void CambiosImporte()
        {
            try
            {
                if (CbTipoGasto.SelectedValue == null) { txtSCOT_ImporteEgreso.Text = @"0"; txtSCOT_ImporteIngreso.Text = @"0"; return; }
                if (CbTipoGasto.SelectedValue.ToString().Equals("001")) // ingreso
                {
                    txtSCOT_ImporteIngreso.Value = txtSCOT_Cantidad.Value * txtSCOT_PrecioUni.Value;
                    txtSCOT_ImporteIngreso.Text = (txtSCOT_Cantidad.Value * txtSCOT_PrecioUni.Value).ToString(CultureInfo.InvariantCulture);
                    txtSCOT_ImporteEgreso.Text = @"0";
                }
                else   //egreso
                {
                    txtSCOT_ImporteEgreso.Value = txtSCOT_Cantidad.Value * txtSCOT_PrecioUni.Value;
                    txtSCOT_ImporteEgreso.Text = (txtSCOT_Cantidad.Value * txtSCOT_PrecioUni.Value).ToString(CultureInfo.InvariantCulture);
                    txtSCOT_ImporteIngreso.Text = @"0";
                }
            }
            catch (Exception) { }
        }
        #endregion
        #endregion

        #region [ Eventos ]

        #region [ Detalle Servicio Cotización ]
        void btnAgregar_Click(object sender, EventArgs e)
        {
            Presenter.AgregarDetalleServicioCotizacion();
        }
        void txtSCOT_PrecioUni_ValueChanged(object sender, EventArgs e)
        {
            CambiosImporte();
        }
        void txtSCOT_Cantidad_ValueChanged(object sender, EventArgs e)
        {
            CambiosImporte();
        }
        void CbTipoGasto_SelectedValueChanged(object sender, EventArgs e)
        {
            CambiosImporte();
        }
        #endregion

        #endregion
    }
}
