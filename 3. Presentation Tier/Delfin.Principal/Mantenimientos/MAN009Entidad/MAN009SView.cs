using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Delfin.Controls;
using Delfin.Controls.Tipos;
using Infrastructure.Aspect.BusinessEntity;
using Infrastructure.WinForms.Controls;
using TiposEntidad = Delfin.Entities.TiposEntidad;
namespace Delfin.Principal.Mantenimientos.MAN009Entidad
{
    public partial class MAN009SView : Form
    {
        #region [ Variables ]
        public enum TServicio
        {
            Nuevo = 0, Editar = 1
        }
        #endregion

        #region [ Propiedades ]
        public Entities.Entidad_Servicio Servicio { get; set; }
        public Entities.Entidad_Servicio Item { get; set; }
        public MAN009Presenter Presenter { get; set; }
        public TServicio TRegistro { get; set; } 
        public Int32 m_TipoEntidad { get; set; }
        #endregion

        #region [ Formulario ]
        public MAN009SView(TServicio Opcion , Int16 x_EntidadPadre)
        {
            InitializeComponent();
            try
            {
                this.StartPosition = FormStartPosition.CenterScreen;
                //this.aydSERV_Codigo
                btnGuardar.Click += btnGuardar_Click;
                btnSalir.Click += btnSalir_Click;
                TRegistro = Opcion;
                m_TipoEntidad = x_EntidadPadre;
                switch (x_EntidadPadre)
                {
                    case EntidadClear.TIPE_Cliente:
                        pcTitleServicios.Caption = "Servicios del Cliente";
                        break;
                    case EntidadClear.TIPE_Proveedor:
                        pcTitleServicios.Caption = "Servicios del Proveedor";
                        break;
                    case EntidadClear.TIPE_Ejecutivo:
                        pcTitleServicios.Caption = "Servicios del Ejecutivo";
                        break;
                    case EntidadClear.TIPE_CustomerService:
                        pcTitleServicios.Caption = "Servicios del Customer Service";
                        break;
                    case EntidadClear.TIPE_Transportista:
                        pcTitleServicios.Caption = "Servicios del Transportista";
                        break;
                    case EntidadClear.TIPE_Broker:
                        pcTitleServicios.Caption = "Servicios del Broker";
                        break;
                    case EntidadClear.TIPE_Contacto:
                        pcTitleServicios.Caption = "Servicios del Contacto";
                        break;
                    case EntidadClear.TIPE_Shipper:
                        pcTitleServicios.Caption = "Servicios del Shipper";
                        break;
                    case EntidadClear.TIPE_DepositoTemporal:
                        pcTitleServicios.Caption = "Servicios del Deposito Temporal";
                        break;
                    case EntidadClear.TIPE_DepositoVacio:
                        pcTitleServicios.Caption = "Servicios del Desposito de Vacios";
                        break;
                    case EntidadClear.TIPE_Agente:
                    case EntidadClear.TIPE_AgentePortuario:
                    case EntidadClear.TIPE_AgenciaAduanera:
                    case EntidadClear.TIPE_AgenciaMaritima:
                    case EntidadClear.TIPE_AgenteCarga:
                        pcTitleServicios.Caption = "Servicios del Agente";
                        break;
                }
            }
            catch (Exception ex)
            { Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error inicializando.", ex); }
        }
        public void LoadView()
        {
            try
            {
                aydSERV_Codigo.LoadControl(Presenter.ContainerService);
                cmbTIPO_CodMnd.LoadControl(Presenter.ContainerService, "Ayuda de Moneda", "MND", "< Seleccione la Moneda >", ListSortDirection.Ascending);
                cmbCONS_CodBas.LoadControl(Presenter.ContainerService, "Ayuda de Base", "BAS", "< Seleccione el Aplicado >", ListSortDirection.Ascending);
                switch (TRegistro)
                {
                    case TServicio.Nuevo:
                        Item = new Entities.Entidad_Servicio();
                        ClearItem();
                        break;
                    case TServicio.Editar:
                        break;
                }
                if (m_TipoEntidad != Delfin.Controls.EntidadClear.TIPE_Agente)
                {
                    lblESER_Exonerado.Visible = true;
                    chkESER_Exonerado.Visible = true;
                }
                else
                {
                    lblESER_Exonerado.Visible = false;
                    chkESER_Exonerado.Visible = false;
                }

                SetItem();
            }
            catch (Exception)
            { throw; }
        }
        #endregion

        #region [ Metodos ]
        private void SetItem()
        {
            try
            {
                if (Item != null && Presenter != null)
                {
                    txtESER_Codigo.Text = Item.ESER_Codigo.ToString();
                    Int32 _SERV_Codigo;
                    if (Item.SERV_Codigo != null)
                    { _SERV_Codigo = Convert.ToInt32(Item.SERV_Codigo); aydSERV_Codigo.LoadServicio(_SERV_Codigo); }
                    if (Item.TIPO_CodMnd != null) { cmbTIPO_CodMnd.TiposSelectedValue = Item.TIPO_CodMnd; }
                    txtESER_Valor.Text = Item.ESER_Valor.ToString();
                    if (Item.CONS_CodBas != null) { cmbCONS_CodBas.ConstantesSelectedValue = Item.CONS_CodBas; }
                    chkESER_Exonerado.Checked = Item.ESER_Exonerado;
                }
            }
            catch (Exception ex)
            { throw ex; }
        }
        private void ClearItem()
        {
            try
            {
                errorProviderServicios.Clear();
                txtESER_Codigo.Clear();
                aydSERV_Codigo.ClearValue(); aydSERV_Codigo.TipoAyudaServicio = Delfin.Controls.AyudaServicio.TipoAyuda.Nombre;
                cmbTIPO_CodMnd.TiposSelectedValue = null;
                txtESER_Valor.Value = (Decimal)0.00;
                cmbCONS_CodBas.ConstantesSelectedValue = null;
                chkESER_Exonerado.Checked = false;

            }
            catch (Exception ex)
            { throw ex; }
        }
        private Boolean GetItem()
        {
            try
            {
                errorProviderServicios.Clear();
                errorProviderServicios.Dispose();
                Boolean isCorrect = true;

                Item.ESER_Codigo = Convert.ToInt32(txtESER_Codigo.Text);
                if (aydSERV_Codigo.SelectedServicio != null)
                { 
                    Item.SERV_Codigo = aydSERV_Codigo.SelectedServicio.SERV_Codigo;
                    Item.SERV_Nombre = aydSERV_Codigo.SelectedServicio.SERV_Nombre_SPA;
                    Item.CONS_TabLNG = aydSERV_Codigo.SelectedServicio.CONS_TabLNG;
                    Item.CONS_CodLNG = aydSERV_Codigo.SelectedServicio.CONS_CodLNG;
                    Item.CONS_DescLNG = aydSERV_Codigo.SelectedServicio.CONS_DescLNG;
                    Item.CONS_TabRGM = aydSERV_Codigo.SelectedServicio.CONS_TabRGM;
                    Item.CONS_CodRGM = aydSERV_Codigo.SelectedServicio.CONS_CodRGM;
                    Item.CONS_DescRGM = aydSERV_Codigo.SelectedServicio.CONS_DescRGM;
                    Item.CONS_TabVIA = aydSERV_Codigo.SelectedServicio.CONS_TabVia;
                    Item.CONS_CodVIA = aydSERV_Codigo.SelectedServicio.CONS_CodVia;
                    Item.CONS_DescVIA = aydSERV_Codigo.SelectedServicio.CONS_DescVIA;
                }
                else
                {
                    Item.SERV_Codigo = null;
                    errorProviderServicios.SetError(aydSERV_Codigo, "Debe seleccionar un servicio."); isCorrect = false;
                }
                if (cmbTIPO_CodMnd.TiposSelectedItem != null)
                {
                    Item.TIPO_TabMnd = cmbTIPO_CodMnd.TiposSelectedItem.TIPO_CodTabla;
                    Item.TIPO_CodMnd = cmbTIPO_CodMnd.TiposSelectedItem.TIPO_CodTipo;
                    Item.TIPO_DescMND = cmbTIPO_CodMnd.TiposSelectedItem.TIPO_Desc1;
                }
                else
                {
                    Item.TIPO_TabMnd = null;
                    Item.TIPO_CodMnd = null;
                    errorProviderServicios.SetError(cmbTIPO_CodMnd, "Debe seleccionar una Moneda."); isCorrect = false;
                }
                Item.ESER_Valor = Convert.ToDecimal(txtESER_Valor.Value);
                if (cmbCONS_CodBas.ConstantesSelectedItem != null)
                {
                    Item.CONS_TabBas = cmbCONS_CodBas.ConstantesSelectedItem.CONS_CodTabla;
                    Item.CONS_CodBas = cmbCONS_CodBas.ConstantesSelectedItem.CONS_CodTipo;
                    Item.CONS_DescBAS = cmbCONS_CodBas.ConstantesSelectedItem.CONS_Desc_SPA;
                }
                else
                {
                    Item.CONS_TabBas = null;
                    Item.CONS_CodBas = null;
                    errorProviderServicios.SetError(cmbCONS_CodBas, "Debe seleccionar una Base de Calculo."); isCorrect = false;
                }
                Item.ESER_Exonerado = chkESER_Exonerado.Checked;
                return isCorrect;
            }
            catch (Exception ex)
            { throw ex; }
        }
        public void ShowValidation()
        {
            try
            {
                Infrastructure.Client.FormClose.FormShowErrorProvider<Entities.Entidad_Servicio>.Validate(Item, this, errorProviderServicios);
                Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Presenter.Title, "Existen campos obligatorios, revise los detalles.", Presenter.Item.MensajeError);
            }
            catch (Exception ex)
            { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error en ShowValidation.", ex); }
        }
        #endregion

        #region [ Eventos ]
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if ( GetItem())
                {
                    errorProviderServicios.Dispose();
                    this.Servicio = this.Item;
                    this.Servicio.Instance = (TRegistro == TServicio.Nuevo
                       ? InstanceEntity.Added
                       : InstanceEntity.Modified);

                    if (TRegistro == TServicio.Nuevo)
                    {
                        this.Servicio.Instance = InstanceEntity.Added;
                        this.Servicio.AUDI_UsrCrea = Presenter.Session.UserName;
                        this.Servicio.AUDI_FecCrea = Presenter.Session.Fecha;
                        Presenter.Item.ListServicio.Add(this.Servicio);
                    }
                    if (TRegistro == TServicio.Editar)
                    {
                        this.Servicio.AUDI_UsrMod = Presenter.Session.UserName;
                        this.Servicio.AUDI_FecMod = Presenter.Session.Fecha;
                    }
                    DialogResult = DialogResult.OK;
                }
                else
                {
                    Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion("Servicios", "Faltan ingresar algunos valores.");
                }
            }
            catch (Exception ex)
            { Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al intentar guardar el relacionado.", ex); }
        }
        private void btnSalir_Click(object sender, EventArgs e)
        {
            errorProviderServicios.Dispose();
            this.Close();
        }
        #endregion
    }
}
