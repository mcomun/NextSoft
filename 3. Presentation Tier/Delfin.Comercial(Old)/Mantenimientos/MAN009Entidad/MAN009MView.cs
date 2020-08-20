using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Delfin.Comercial.Properties;
using Delfin.Controls;
using Delfin.Entities;
using Infrastructure.Aspect.BusinessEntity;
using Infrastructure.Aspect.Collections;
using Infrastructure.Aspect.Constants;
using Infrastructure.Client.FormClose;
using Infrastructure.WinForms.Controls;
using Telerik.WinControls;
using Telerik.WinControls.UI;
using Telerik.WinControls.UI.Localization;
using Entidad = Delfin.Entities.Entidad;

using Delfin.Controls.Tipos;

namespace Delfin.Comercial
{
   public partial class MAN009MView : Form, IMAN009MView
   {
      #region [ Variables ]
      GridViewDataColumn column;
      #endregion

      #region [ Formulario ]
      public MAN009MView()
      {
         InitializeComponent();
         try
         {
            Height -= 80;

            btnGuardar.Click += new EventHandler(btnGuardar_Click);
            btnSalir.Click += new EventHandler(btnSalir_Click);

            //btnAgregar_C_IMPO.Click += new EventHandler(btnAgregar_C_IMPO_Click);
            //btnEditar_C_IMPO.Click += new EventHandler(btnEditar_C_IMPO_Click);

            //btnAgregar_C_EXPO.Click += new EventHandler(btnAgregar_C_EXPO_Click);
            //btnAgregar_C_EXPO.Click += new EventHandler(btnAgregar_C_EXPO_Click);

            //CRISTHIAN JOSE APAZA
            tsbtnNuevoRelacionado.Click += tsbtnNuevoRelacionado_Click;
            btnNuevoRelacionado.Click += tsbtnNuevoRelacionado_Click;

            BSItemsRelacionados = new BindingSource();
            grdItemsRelacionados.CommandCellClick += new Telerik.WinControls.UI.CommandCellClickEventHandler(grdItemsRelacionados_CommandCellClick);
            grdItemsRelacionados.CellFormatting += grdItemsRelacionados_CellFormatting;
            BSItemsRelacionados.CurrentItemChanged += new EventHandler(BSItemsRelacionados_CurrentItemChanged);

            #region [ Servicios Cliente ]
            tsbtnNuevoServicio.Click += tsbtnNuevoServicio_Click;
            BSItemsServicios = new BindingSource();
            grdItemsServiciosCliente.CommandCellClick += new Telerik.WinControls.UI.CommandCellClickEventHandler(grdItemsServiciosCliente_CommandCellClick);
            grdItemsServiciosCliente.CellFormatting += grdItemsServiciosCliente_CellFormatting;
            BSItemsServicios.CurrentItemChanged += BSItemsServicios_CurrentItemChanged;
            #endregion

            FormClosing += new FormClosingEventHandler(MView_FormClosing);
            visualizaNatural_Juridica();

            BSItemsDepTemporal = new BindingSource();
            BSItemsDepTemporal.CurrentItemChanged += BSItemsDepTemporal_CurrentItemChanged;

            cmbTIPO_CodTDI.Leave += cmbTIPO_CodTDI_Leave;
            cmbTIPO_CodTDI.SelectedIndexChanged += cmbTIPO_CodTDI_SelectedIndexChanged;
            txtENTC_DocIden.Leave += txtENTC_DocIden_Leave;

            /*
             * Datos Financieros de Clientes
             */

            chkENTC_Mandato.Enabled = false;
            chkENTC_Exportacion.Enabled = false;
            chkENTC_OtrosTraficos.Enabled = false;
            chkENTC_SLI.Enabled = false;

            txtENTC_ObsFinanzasCliente.MaxLength = 1024;
            txtENTC_UsrBloqueoCliente.ReadOnly = true;
            dtpENTC_FecBloqueoCliente.Enabled = false;
            txtENTC_ObsBloqueoCliente.MaxLength = 1000;

            chkENTC_BloqueoFinanzasCliente.CheckedChanged += chkENTC_BloqueoFinanzasCliente_CheckedChanged;
            grdItemsLimiteCreditoCli.CellFormatting += grdItemsLimiteCreditoCli_CellFormatting;
            grdItemsLimiteCreditoCli.CommandCellClick += grdItemsLimiteCreditoCli_CommandCellClick;

            BSItemsLimiteCreditoCliente = new BindingSource();
            /*
             * Datos Financieros del Proveedor
             */
            txtENTC_EmailFinanzas.MaxLength = 250;
            txtENTC_InterbancarioSol.MaxLength = 50;
            txtENTC_InterbancarioDol.MaxLength = 50;
            txtENTC_CuentaDetraccion.MaxLength = 50;

            txtENTC_UsrBloqueoProveedor.ReadOnly = true;
            dtpENTC_FecBloqueoProveedor.Enabled = false;
            txtENTC_ObsBloqueoProveedor.MaxLength = 1000;

            chkENTC_BloqueoFinanzasProveedor.CheckedChanged += chkENTC_BloqueoFinanzasProveedor_CheckedChanged;
            grdItemsLimiteCreditoPro.CellFormatting += grdItemsLimiteCreditoPro_CellFormatting;
            grdItemsLimiteCreditoPro.CommandCellClick += grdItemsLimiteCreditoPro_CommandCellClick;

            BSItemsLimiteCreditoProveedor = new BindingSource();

            grdItemsEntidadCuentaBancaria.CellFormatting += grdItemsEntidadCuentaBancaria_CellFormatting;
            grdItemsEntidadCuentaBancaria.CommandCellClick += grdItemsEntidadCuentaBancaria_CommandCellClick;

            BSItemsEntidadCuentaBancaria = new BindingSource();
            btnNuevoEntidadBancaria.Click += btnNuevoEntidadBancaria_Click;

            chkENTC_OcultarShipper.CheckedChanged += chkENTC_OcultarShipper_CheckedChanged;


            #region [ Auditoria ]
            btnAuditoriaEntidad.Click += btnAuditoriaEntidad_Click;
            btnAuditoriaEntidad_Servicio.Click += btnAuditoriaEntidad_Servicio_Click;
            btnAuditoriaEntidad_Relacionados.Click += btnAuditoriaEntidad_Relacionados_Click;
            #endregion

            btn_TxtENTC_Email.Click += new EventHandler(btn_TxtENTC_Email_Click);

            Load += MAN009MView_Load;
         }
         catch (Exception ex)
         { Dialogos.MostrarMensajeError(Presenter.Title, Mensajes.ConstructorView, ex); }
      }
      private void MAN009MView_Load(object sender, EventArgs e)
      {
         try
         {
            tabControl_Entidad.SelectedTab = pageDatosGenerales;
         }
         catch (Exception)
         { throw; }
      }
      #endregion

      #region [ Propiedades ]
      public MAN009Presenter Presenter { get; set; }
      private bool Closing = false;
      private Hashtable HashFormulario { get; set; }
      public BindingSource BSItemsRelacionados { get; set; }
      public BindingSource BSItemsServicios { get; set; }
      public BindingSource BSItemsDepTemporal { get; set; }
      public BindingSource BSItemsLimiteCreditoCliente { get; set; }
      public BindingSource BSItemsLimiteCreditoProveedor { get; set; }
      public BindingSource BSItemsEntidadCuentaBancaria { get; set; }
      #endregion

      #region [ ICUS009MView ]
      public void LoadView()
      {
         try
         {
            cmbTIPO_CodTDI.LoadControl(Presenter.ContainerService, "Tipos de Documentos de Identidad", "TDI", "< Seleccionar Tipo Doc. Identidad >", ListSortDirection.Ascending);
            cmbTIPO_CodPAI.LoadControl(Presenter.ContainerService, "Tabla de Países", "PAI", "< Seleccionar País >", ListSortDirection.Ascending);
            cmbTIPO_CodHOL.LoadControl(Presenter.ContainerService, "Tipos de Holding", "HOL", "< Seleccionar Holding >", ListSortDirection.Ascending);
            cmbCONS_CodTFT.LoadControl(Presenter.ContainerService, "Tipos Fecha Tarifa", "TFT", "< Seleccionar Tipo Fecha Tarifa >", ListSortDirection.Ascending);
            cmbCONS_CodACU.LoadControl(Presenter.ContainerService, "Tipos de Acuerdo", "ACU", "< Selecionar Tipo Acuerdo >", ListSortDirection.Ascending);
            cmbTIPO_CodMND.LoadControl(Presenter.ContainerService, "Tipos de Moneda", "MND", "< Selecionar Tipo Moneda >", ListSortDirection.Ascending);

            cmbCONS_CodRGM.LoadControl(Presenter.ContainerService, "Tipos de Regimen", "RGM", "< Seleccionar Regimen >", ListSortDirection.Ascending);
            cmbTIPO_CodTRF.LoadControl(Presenter.ContainerService, "Tipos de Trafico", "TRF", "< Seleccionar Trafico >", ListSortDirection.Ascending);

            txaUBIG_Codigo.LoadControl(Presenter.ContainerService);
            txaUBIG_CodigoComercial.LoadControl(Presenter.ContainerService);
            visualizaNatural_Juridica();

            FormatGridRelacionados();
            FormatDataGridServicios();
            Dibujapantalla();

            FormatDataGridLimiteCreditoCliente();
            FormatDataGridLimiteCreditoProveedor();
            FormatDataGridEntidadCuentasBancarias();

         }
         catch (Exception ex)
         { Dialogos.MostrarMensajeError(Presenter.Title, Mensajes.LoadView, ex); }
      }
      public void ShowItems()
      {
         //    try
         //    {
         //        BSItemsServicios.DataSource = Presenter.Item.ListServicio;
         //        grdItemsServiciosCliente.DataSource = BSItemsServicios;
         //        navItemsServiciosCliente.BindingSource = BSItemsServicios;
         //        BSItemsServicios.ResetBindings(true);
         //    }
         //    catch (Exception ex)
         //    { Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error cargando los items.", ex); }
      }
      public void ClearItem()
      {
         try
         {
            //Int32 _ENTC_Codigo;

            chkENTC_OcultarShipper.CheckedChanged -= chkENTC_OcultarShipper_CheckedChanged;

            txtENTC_Codigo.Text = string.Empty;
            txtENTC_RazonSocial.Text = string.Empty;
            txtENTC_NomComercial.Text = string.Empty;
            cmbTIPO_CodTDI.SelectedIndex = 0;
            optENTC_TipEntJ.Checked = false;
            txtENTC_DocIden.Text = string.Empty;
            txtENTC_Nombres.Text = string.Empty;
            txtENTC_ApePat.Text = string.Empty;
            txtENTC_ApeMat.Text = string.Empty;

            txtENTC_NomComercial.Text = string.Empty;
            txtENTC_RazonSocial.Text = string.Empty;
            chkENTC_Activo.Checked = false;
            mdtENTC_FecNac.NSFecha = null;//Presenter.Session.Fecha;
            mdtENTC_FecIng.NSFecha = null;//Presenter.Session.Fecha;
            txtENTC_Notas.Text = string.Empty;
            optENTC_SexoF.Checked = false;
            txtENTC_EMail.Text = string.Empty;
            txtENTC_Web.Text = string.Empty;

            txtENTC_Telef1.Text = string.Empty;
            txtENTC_Telef2.Text = string.Empty;

            txtENTC_Beneficiario.Text = string.Empty;
            txtENTC_Area.Text = string.Empty;
            txtENTC_Cargo.Text = string.Empty;
            txtUSER_CodUsr.Text = string.Empty;

            cmbTIPO_CodPAI.SelectedIndex = 0;
            cmbTIPO_CodHOL.SelectedIndex = 0;
            cmbCONS_CodTFT.SelectedIndex = 0;

            mdtACUE_FecIni.NSFecha = null;//Presenter.Session.Fecha;
            txtACUE_Valor.Text = string.Empty;
            cmbCONS_CodACU.SelectedIndex = 0;
            chkENTC_Activo.Checked = true;
            //inicializa valores por defecto

            mdtACUE_FecIni.NSFecha = null;
            txtACUE_Valor.Text = "";
            cmbCONS_CodACU.SelectedIndex = 0;
            txtENTC_DiasCredito.Text = "0";
            txtDIRE_Direccion.Clear();
            txaUBIG_Codigo.PaisSelectedValue = "000";
            txtDIRE_DireccionComercial.Clear();
            txaUBIG_CodigoComercial.SelectedValue = "000";
            ChkENTC_Tarja.Checked = false;
            txtENTC_ValTarja.Value = 0;
            txtENTC_ValRebate.Value = 0;
            cmbTIPO_CodMND.SelectedIndex = 0;
            txtENTC_DiasCredito.Value = 0;
            mdtENTC_FecCredito.NSFecha = null;
            txtENTC_DiasCredito.Tag = "";
            mdtENTC_FecCredito.Tag = "";
            txtENTC_RazonSocial.Tag = "";
            txtENTC_Nombres.Tag = "";

            chkENTC_OcultarShipper.Checked = false;

            switch (Presenter.tipe_Codigo)
            {
               case EntidadClear.TIPE_Cliente:
                  optENTC_TipEntJ.Checked = true;
                  //this.Height = 490;
                  break;
               case EntidadClear.TIPE_Proveedor:
                  optENTC_TipEntJ.Checked = true;
                  break;
               case EntidadClear.TIPE_Ejecutivo:
                  optENTC_TipEntJ.Checked = false;
                  optENTC_TipEntN.Checked = true;
                  break;
               case EntidadClear.TIPE_CustomerService:
                  optENTC_TipEntJ.Checked = false;
                  optENTC_TipEntN.Checked = true;
                  break;
               case EntidadClear.TIPE_Transportista:
                  optENTC_TipEntJ.Checked = true;
                  optENTC_TipEntN.Checked = false;
                  break;
               case EntidadClear.TIPE_Agente:
                  optENTC_TipEntJ.Checked = true;
                  optENTC_TipEntN.Checked = false;
                  break;
               case EntidadClear.TIPE_Broker:
                  optENTC_TipEntJ.Checked = false;
                  optENTC_TipEntN.Checked = true;
                  break;
               case EntidadClear.TIPE_AgenteCarga:
                  optENTC_TipEntJ.Checked = true;
                  optENTC_TipEntN.Checked = false;

                  break;
               case EntidadClear.TIPE_Contacto:
                  optENTC_TipEntJ.Checked = false;
                  optENTC_TipEntN.Checked = true;
                  break;
               case EntidadClear.TIPE_Shipper:
                  optENTC_TipEntJ.Checked = true;
                  break;
               case EntidadClear.TIPE_AgenciaAduanera:
                  optENTC_TipEntJ.Checked = true;
                  break;
               case EntidadClear.TIPE_AgenciaMaritima:
                  optENTC_TipEntJ.Checked = true;
                  break;
               case EntidadClear.TIPE_DepositoTemporal:
                  optENTC_TipEntJ.Checked = true;
                  break;
               case EntidadClear.TIPE_DepositoVacio:
                  optENTC_TipEntJ.Checked = true;
                  break;
               default:
                  break;

            }

            visualizaNatural_Juridica();

            BSItemsServicios = new BindingSource();
            grdItemsServiciosCliente.DataSource = BSItemsServicios;
            navItemsServiciosCliente.BindingSource = BSItemsServicios;
            BSItemsServicios.ResetBindings(true);

            //nuevos campos
            txtENTC_EMail2.Text = string.Empty;
            txtENTC_EMailFE.Text = string.Empty;

            txtENTC_ObsFinanzasCliente.Text = string.Empty;
            chkENTC_BloqueoFinanzasCliente.Checked = false;
            txtENTC_UsrBloqueoCliente.Text = string.Empty;
            dtpENTC_FecBloqueoCliente.NSFecha = null;
            txtENTC_ObsBloqueoCliente.Text = string.Empty;
            chkENTC_OtrosTraficos.Checked = false;
            chkENTC_Mandato.Checked = false;
            chkENTC_Exportacion.Checked = false;
            chkENTC_SLI.Checked = false;
            txtENTC_InterbancarioDol.Text = string.Empty;
            txtENTC_InterbancarioSol.Text = string.Empty;
            txtENTC_CuentaDetraccion.Text = string.Empty;
            chkENTC_BloqueoFinanzasProveedor.Checked = false;
            txtENTC_UsrBloqueoProveedor.Text = string.Empty;
            dtpENTC_FecBloqueoProveedor.NSFecha = null;
            txtENTC_ObsBloqueoProveedor.Text = string.Empty;
            txtENTC_EmailFinanzas.Text = string.Empty;
            cmbCONS_CodRGM.SelectedIndex = 0;
            cmbTIPO_CodTRF.SelectedIndex = 0;

            chkENTC_ServicioLogistico.Checked = false;
            chkENTC_ToOrder.Checked = false;
            BSItemsRelacionados.DataSource = null;
            BSItemsRelacionados.ResetBindings(false);

         }
         catch (Exception)
         { }
      }
      public void GetItem()
      {
         try
         {
            /*$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$*/
            #region Datos Generales

            Int32 _ENTC_Codigo;

            if (Int32.TryParse(txtENTC_Codigo.Text, out _ENTC_Codigo))
            {
               Presenter.Item.ENTC_Codigo = _ENTC_Codigo;
            }

            Presenter.Item.ENTC_Activo = chkENTC_Activo.Checked;

            if (cmbCONS_CodRGM.ConstantesSelectedItem != null)
            {
               Presenter.Item.CONS_TabRGM = cmbCONS_CodRGM.ConstantesSelectedItem.CONS_CodTabla;
               Presenter.Item.CONS_CodRGM = cmbCONS_CodRGM.ConstantesSelectedItem.CONS_CodTipo;
            }
            else
            {
               Presenter.Item.CONS_TabRGM = null;
               Presenter.Item.CONS_CodRGM = null;
            }

            if (cmbTIPO_CodTRF.TiposSelectedItem != null)
            {
               Presenter.Item.TIPO_TabTRF = cmbTIPO_CodTRF.TiposSelectedItem.TIPO_CodTabla;
               Presenter.Item.TIPO_CodTRF = cmbTIPO_CodTRF.TiposSelectedItem.TIPO_CodTipo;
            }
            else
            {
               Presenter.Item.TIPO_TabTRF = null;
               Presenter.Item.TIPO_CodTRF = null;
            }

            Presenter.Item.ENTC_TipEnt = (optENTC_TipEntJ.Checked) ? "J" : "N";

            if (Presenter.Item.ENTC_TipEnt.Equals("J"))
            {
               txtENTC_RazonSocial.Tag = "ENTC_RazonSocialMSGERROR";
            }
            else
            {
               txtENTC_Nombres.Tag = "ENTC_NombresMSGERROR";
            }

            Presenter.Item.ENTC_ServicioLogistico = chkENTC_ServicioLogistico.Checked;

            if (cmbTIPO_CodTDI.TiposSelectedItem != null)
            {
               Presenter.Item.TIPO_TabTDI = cmbTIPO_CodTDI.TiposSelectedItem.TIPO_CodTabla;
               Presenter.Item.TIPO_CodTDI = cmbTIPO_CodTDI.TiposSelectedItem.TIPO_CodTipo;
            }
            else
            {
               Presenter.Item.TIPO_TabTDI = null;
               Presenter.Item.TIPO_CodTDI = null;
            }

            if (!String.IsNullOrEmpty(txtENTC_DocIden.Text))
            {
               Presenter.Item.ENTC_DocIden = txtENTC_DocIden.Text;
            }
            else
            {
               Presenter.Item.ENTC_DocIden = null;
            }
            if (!String.IsNullOrEmpty(txtENTC_RazonSocial.Text))
            {
               Presenter.Item.ENTC_RazonSocial = txtENTC_RazonSocial.Text;
            }
            else
            {
               Presenter.Item.ENTC_RazonSocial = null;
            }
            if (!String.IsNullOrEmpty(txtENTC_NomComercial.Text))
            {
               Presenter.Item.ENTC_NomComercial = txtENTC_NomComercial.Text;
            }
            else
            {
               Presenter.Item.ENTC_NomComercial = null;
            }
            if (!String.IsNullOrEmpty(txtENTC_ApePat.Text))
            {
               Presenter.Item.ENTC_ApePat = txtENTC_ApePat.Text;
            }
            else
            {
               Presenter.Item.ENTC_ApePat = null;
            }
            if (!String.IsNullOrEmpty(txtENTC_ApeMat.Text))
            {
               Presenter.Item.ENTC_ApeMat = txtENTC_ApeMat.Text;
            }
            else
            {
               Presenter.Item.ENTC_ApeMat = null;
            }
            if (!String.IsNullOrEmpty(txtENTC_Nombres.Text))
            {
               Presenter.Item.ENTC_Nombres = txtENTC_Nombres.Text;
            }
            else
            {
               Presenter.Item.ENTC_Nombres = null;
            }
            Presenter.Item.ENTC_NomCompleto = (optENTC_TipEntJ.Checked)
               ? txtENTC_RazonSocial.Text.Trim()
               : (txtENTC_ApePat.Text + " " + txtENTC_ApeMat.Text + " " + txtENTC_Nombres.Text).Trim();
            Presenter.Item.ENTC_Sexo = (optENTC_SexoF.Checked) ? "F" : "M";
            if (!String.IsNullOrEmpty(txtENTC_Area.Text))
            {
               Presenter.Item.ENTC_Area = txtENTC_Area.Text;
            }
            else
            {
               Presenter.Item.ENTC_Area = null;
            }
            if (!String.IsNullOrEmpty(txtENTC_Cargo.Text))
            {
               Presenter.Item.ENTC_Cargo = txtENTC_Cargo.Text;
            }
            else
            {
               Presenter.Item.ENTC_Cargo = null;
            }
            Presenter.Item.ENTC_FecNac = mdtENTC_FecNac.NSFecha;
            Presenter.Item.ENTC_FecIng = mdtENTC_FecIng.NSFecha;
            if (!String.IsNullOrEmpty(txtENTC_EMail.Text))
            {
               Presenter.Item.ENTC_EMail = txtENTC_EMail.Text;
            }
            else
            {
               Presenter.Item.ENTC_EMail = null;
            }
            if (!String.IsNullOrEmpty(txtENTC_EMail2.Text))
            {
               Presenter.Item.ENTC_EMail2 = txtENTC_EMail2.Text;
            }
            else
            {
                Presenter.Item.ENTC_EmailReceptorFE = null;
            }
            if (!String.IsNullOrEmpty(txtENTC_EMailFE.Text))
            {
                Presenter.Item.ENTC_EmailReceptorFE = txtENTC_EMailFE.Text;
            }
            else
            {
                Presenter.Item.ENTC_EmailReceptorFE = null;
            }
            if (!String.IsNullOrEmpty(txtENTC_Web.Text))
            {
               Presenter.Item.ENTC_Web = txtENTC_Web.Text;
            }
            else
            {
               Presenter.Item.ENTC_Web = null;
            }
            if (!String.IsNullOrEmpty(txtENTC_Telef1.Text))
            {
               Presenter.Item.ENTC_Telef1 = txtENTC_Telef1.Text;
            }
            else
            {
               Presenter.Item.ENTC_Telef1 = null;
            }
            if (!String.IsNullOrEmpty(txtENTC_Telef2.Text))
            {
               Presenter.Item.ENTC_Telef2 = txtENTC_Telef2.Text;
            }
            else
            {
               Presenter.Item.ENTC_Telef2 = null;
            }
            /*#####################################################################*/
            Presenter.Item.TIPO_TabCiu = null; //TIPO_TabCiu
            Presenter.Item.TIPO_CodCiu = null; //cmbTIPO_CodCiu 
            /*#####################################################################*/
            if (!String.IsNullOrEmpty(txtDIRE_Direccion.Text))
            {
               Presenter.Item.DIRE_Direccion = txtDIRE_Direccion.Text;
            }
            else
            {
               Presenter.Item.DIRE_Direccion = null;
            }
            Presenter.Item.TIPO_TabPaisFiscal = null;
            Presenter.Item.TIPO_CodPaisFiscal = null;
            if (txaUBIG_Codigo.PaisSelectedItem != null)
            {
               Presenter.Item.TIPO_TabPaisFiscal = txaUBIG_Codigo.PaisSelectedItem.TIPO_CodTabla;
               Presenter.Item.TIPO_CodPaisFiscal = txaUBIG_Codigo.PaisSelectedItem.TIPO_CodTipo;
            }

            if (txaUBIG_Codigo.SelectedItem != null)
            {
               Presenter.Item.UBIG_CodigoFiscal = txaUBIG_Codigo.SelectedItem.UBIG_Codigo;
            }
            else
            {
               Presenter.Item.UBIG_CodigoFiscal = null;
            }

            /*#####################################################################*/
            if (!String.IsNullOrEmpty(txtDIRE_DireccionComercial.Text))
            {
               Presenter.Item.DIRE_DireccionComercial = txtDIRE_DireccionComercial.Text;
            }
            else
            {
               Presenter.Item.DIRE_DireccionComercial = null;
            }

            if (txaUBIG_CodigoComercial.PaisSelectedItem != null)
            {
               Presenter.Item.TIPO_TabPaisComercial = txaUBIG_CodigoComercial.PaisSelectedItem.TIPO_CodTabla;
               Presenter.Item.TIPO_CodPaisComercial = txaUBIG_CodigoComercial.PaisSelectedItem.TIPO_CodTipo;
            }
            else
            {
               Presenter.Item.TIPO_TabPaisComercial = null;
               Presenter.Item.TIPO_CodPaisComercial = null;
            }

            if (txaUBIG_CodigoComercial.SelectedItem != null)
            {
               Presenter.Item.UBIG_CodigoComercial = txaUBIG_CodigoComercial.SelectedItem.UBIG_Codigo;
            }
            else
            {
               Presenter.Item.UBIG_CodigoComercial = null;
            }
            /*#####################################################################*/
            if (cmbTIPO_CodPAI.TiposSelectedItem != null)
            {
               Presenter.Item.TIPO_TabPai = cmbTIPO_CodPAI.TiposSelectedItem.TIPO_CodTabla;
               Presenter.Item.TIPO_CodPai = cmbTIPO_CodPAI.TiposSelectedItem.TIPO_CodTipo;
            }
            else
            {
               Presenter.Item.TIPO_TabPai = null;
               Presenter.Item.TIPO_CodPai = null;
            }

            if (cmbCONS_CodTFT.ConstantesSelectedItem != null)
            {
               Presenter.Item.CONS_TabTFT = cmbCONS_CodTFT.ConstantesSelectedItem.CONS_CodTabla;
               Presenter.Item.CONS_CodTFT = cmbCONS_CodTFT.ConstantesSelectedItem.CONS_CodTipo;
            }
            else
            {
               Presenter.Item.CONS_TabTFT = null;
               Presenter.Item.CONS_CodTFT = null;
            }

            if (cmbTIPO_CodHOL.TiposSelectedItem != null)
            {
               Presenter.Item.TIPO_TabHol = cmbTIPO_CodHOL.TiposSelectedItem.TIPO_CodTabla;
               Presenter.Item.TIPO_CodHol = cmbTIPO_CodHOL.TiposSelectedItem.TIPO_CodTipo;
            }
            else
            {
               Presenter.Item.TIPO_TabHol = null;
               Presenter.Item.TIPO_CodHol = null;
            }

            Presenter.Item.ENTC_Domiciliado = chkENTC_Domiciliado.Checked;
            Presenter.Item.ENTC_VIP = chkENTC_VIP.Checked;
            Presenter.Item.ENTC_Prospecto = chkENTC_Prospecto.Checked;
            Presenter.Item.ENTC_Propio = chkENTC_Propio.Checked;

            if (mdtENTC_FecCredito.NSFecha != null)
            {
               Presenter.Item.ENTC_FechaCredito = mdtENTC_FecCredito.NSFecha.Value.Date;
               txtENTC_DiasCredito.Tag = "M_ENTC_DiasCreditoMSGERROR";
            }
            else
            {
               Presenter.Item.ENTC_FechaCredito = null;
            }

            if (txtENTC_DiasCredito.Value > 0)
            {
               Presenter.Item.ENTC_DiasCredito = short.Parse(txtENTC_DiasCredito.Value.ToString());
               mdtENTC_FecCredito.Tag = "ENTC_FechaCreditoMSGERROR";
            }
            else
            {
               Presenter.Item.ENTC_DiasCredito = null;
            }

            if (!String.IsNullOrEmpty(txtENTC_Obser.Text))
            {
               Presenter.Item.ENTC_Obser = txtENTC_Obser.Text;
            }
            else
            {
               Presenter.Item.ENTC_Obser = null;
            }

            Presenter.Item.ENTC_OcultarShipper = chkENTC_OcultarShipper.Checked;
            Presenter.Item.ENTC_ToOrder  = chkENTC_ToOrder.Checked;
            #endregion
            /*$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$*/
            #region Otros Datos

            Presenter.Item.ENTC_Notas = txtENTC_Notas.Text;
            Presenter.Item.USER_CodUsr = txtUSER_CodUsr.Text;
            Presenter.Item.ENTC_Beneficiario = txtENTC_Beneficiario.Text;

            Presenter.itemEntidadAcuerdo.ACUE_FecIni = mdtACUE_FecIni.NSFecha;
            if (txtACUE_Valor.Text == "")
            {
               Presenter.itemEntidadAcuerdo.ACUE_Valor = 0;
            }
            else
            {
               Presenter.itemEntidadAcuerdo.ACUE_Valor = Convert.ToDecimal(txtACUE_Valor.Text);
            }

            if (cmbCONS_CodACU.ConstantesSelectedItem != null)
            {
               Presenter.itemEntidadAcuerdo.CONS_TabACU = cmbCONS_CodACU.ConstantesSelectedItem.CONS_CodTabla;
               Presenter.itemEntidadAcuerdo.CONS_CodACU = cmbCONS_CodACU.ConstantesSelectedItem.CONS_CodTipo;
            }
            else
            {
               Presenter.itemEntidadAcuerdo.CONS_TabACU = null;
               Presenter.itemEntidadAcuerdo.CONS_CodACU = null;
            }

            if (txtENTC_ValRebate.Value > 0)
            {
               Presenter.Item.ENTC_ValRebate = txtENTC_ValRebate.Value;
            }

            if (cmbTIPO_CodMND.SelectedIndex > 0)
            {
               Presenter.Item.TIPO_CodMND = cmbTIPO_CodMND.SelectedValue.ToString();
               Presenter.Item.TIPO_TabMND = "MND";
            }
            else
            {
               Presenter.Item.TIPO_CodMND = null;
               Presenter.Item.TIPO_TabMND = null;
            }
            Presenter.Item.ENTC_Tarja = ChkENTC_Tarja.Checked;

            if (txtENTC_ValTarja.Value > 0)
            {
               Presenter.Item.ENTC_ValTarja = txtENTC_ValTarja.Value;
            }

            //if (BSItemsServicios.DataSource != null)
            //{
            //    ObservableCollection<Entidad_Servicio> _listServicios =
            //       (ObservableCollection<Entidad_Servicio>)BSItemsServicios.DataSource;
            //    for (int i = 0; i < Presenter.Item.ListServicio.Count; i++)
            //    {
            //        Entidad_Servicio _servicio = Presenter.Item.ListServicio[i];
            //        if (_servicio.Instance != InstanceEntity.Deleted)
            //        {
            //            Entidad_Servicio _editServicio =
            //               _listServicios.Where(serv => serv.ESER_Codigo == _servicio.SERV_Codigo).FirstOrDefault();
            //            if (_editServicio != null)
            //            {
            //                Presenter.Item.ListServicio[i].SERV_Codigo = _editServicio.SERV_Codigo;
            //                Presenter.Item.ListServicio[i].ESER_Exonerado = _editServicio.ESER_Exonerado;
            //                Presenter.Item.ListServicio[i].ESER_Valor = _editServicio.ESER_Valor;
            //            }
            //        }
            //    }
            //}
            //cmbAgenteMaritimo.SelectedValue
            #endregion
            /*$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$*/
            #region Financiero Cliente

            Presenter.Item.ENTC_Mandato = chkENTC_Mandato.Checked;
            Presenter.Item.ENTC_Exportacion = chkENTC_Exportacion.Checked;
            Presenter.Item.ENTC_OtrosTraficos = chkENTC_OtrosTraficos.Checked;
            Presenter.Item.ENTC_SLI = chkENTC_SLI.Checked;
            Presenter.Item.ENTC_ObsFinanzasCliente = txtENTC_ObsFinanzasCliente.Text;

            if (Presenter.Item.ENTC_BloqueoFinanzasCliente != chkENTC_BloqueoFinanzasCliente.Checked)
            {
               Presenter.Item.ENTC_BloqueoFinanzasCliente = chkENTC_BloqueoFinanzasCliente.Checked;
               Presenter.Item.ENTC_UsrBloqueoCliente = txtENTC_UsrBloqueoCliente.Text;
               Presenter.Item.ENTC_FecBloqueoCliente = dtpENTC_FecBloqueoCliente.NSFecha;
            }
            Presenter.Item.ENTC_ObsBloqueoCliente = txtENTC_ObsBloqueoCliente.Text;
            #endregion
            /*$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$*/
            #region Financiero Proveedor

            Presenter.Item.ENTC_EmailFinanzas = txtENTC_EmailFinanzas.Text;
            Presenter.Item.ENTC_InterbancarioSol = txtENTC_InterbancarioSol.Text;
            Presenter.Item.ENTC_InterbancarioDol = txtENTC_InterbancarioDol.Text;
            Presenter.Item.ENTC_CuentaDetraccion = txtENTC_CuentaDetraccion.Text;

            if (Presenter.Item.ENTC_BloqueoFinanzasProveedor != chkENTC_BloqueoFinanzasProveedor.Checked)
            {
               Presenter.Item.ENTC_BloqueoFinanzasProveedor = chkENTC_BloqueoFinanzasProveedor.Checked;
               Presenter.Item.ENTC_UsrBloqueoProveedor = txtENTC_UsrBloqueoProveedor.Text;
               Presenter.Item.ENTC_FecBloqueoProveedor = dtpENTC_FecBloqueoProveedor.NSFecha;
            }
            Presenter.Item.ENTC_ObsBloqueoProveedor = txtENTC_ObsBloqueoProveedor.Text;
            Presenter.Item.ENTC_ProvAsumeDetraccion = chkENTC_ProvAsumeDetraccion.Checked;

            #endregion
            /*$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$*/
            Presenter.Item.ENTC_Telef3 = "";//ENTC_Telef3
            Presenter.Item.ENTC_Telef4 = "";//ENTC_Telef4
            Presenter.Item.TIPO_TabDTM = null;// TIPO_TabDTM
            Presenter.Item.TIPO_CodDTM = null;
            Presenter.Item.TIPE_Codigo = Presenter.tipe_Codigo; ///Asigna el tipo entidad que se desea crear y que el presente recibe del menu
            Presenter.itemEntidadAcuerdo.ACUE_Codigo = 0;
            /*$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$*/
         }
         catch (Exception)
         { throw; }
      }
      public void SetItem()
      {
         try
         {
            chkENTC_OcultarShipper.CheckedChanged += chkENTC_OcultarShipper_CheckedChanged;

            /*$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$*/
            #region Datos Generales

            if (Presenter.Item.ENTC_Codigo != 0)
            {
               txtENTC_Codigo.Text = Presenter.Item.ENTC_Codigo.ToString();
            }
            if (Presenter.Item.ENTC_Activo.HasValue)
            {
               chkENTC_Activo.Checked = Presenter.Item.ENTC_Activo.Value;
            }
            optENTC_TipEntJ.Checked = (Presenter.Item.ENTC_TipEnt == "J"); //Presenter.Item.ENTC_TipEnt.         ;
            optENTC_TipEntN.Checked = (Presenter.Item.ENTC_TipEnt == "N"); //Presenter.Item.ENTC_TipEnt.         ;

            chkENTC_ServicioLogistico.Checked = Presenter.Item.ENTC_ServicioLogistico;

            cmbCONS_CodRGM.SelectedIndex = -1;
            if (Presenter.Item.CONS_CodRGM != null)
            {
               cmbCONS_CodRGM.SelectedValue = Presenter.Item.CONS_CodRGM;
            }
            cmbTIPO_CodTRF.SelectedIndex = -1;
            if (Presenter.Item.TIPO_CodTRF != null)
            {
               cmbTIPO_CodTRF.SelectedValue = Presenter.Item.TIPO_CodTRF;
            }
            cmbTIPO_CodTDI.SelectedIndex = -1;
            if (Presenter.Item.TIPO_CodTDI != null)
            {
               cmbTIPO_CodTDI.SelectedValue = Presenter.Item.TIPO_CodTDI;
            }
            txtENTC_DocIden.Text = Presenter.Item.ENTC_DocIden;
            txtENTC_RazonSocial.Text = Presenter.Item.ENTC_RazonSocial;
            txtENTC_NomComercial.Text = Presenter.Item.ENTC_NomComercial;
            txtENTC_ApePat.Text = Presenter.Item.ENTC_ApePat;
            txtENTC_ApeMat.Text = Presenter.Item.ENTC_ApeMat;
            txtENTC_Nombres.Text = Presenter.Item.ENTC_Nombres;
            optENTC_SexoF.Checked = (Presenter.Item.ENTC_Sexo == "F");
            optENTC_SexoM.Checked = (Presenter.Item.ENTC_Sexo == "M");
            txtENTC_Area.Text = Presenter.Item.ENTC_Area;
            txtENTC_Cargo.Text = Presenter.Item.ENTC_Cargo;
            mdtENTC_FecNac.NSFecha = Presenter.Item.ENTC_FecNac;
            mdtENTC_FecIng.NSFecha = Presenter.Item.ENTC_FecIng;
            txtENTC_EMail.Text = Presenter.Item.ENTC_EMail;
            txtENTC_EMail2.Text = Presenter.Item.ENTC_EMail2;
            txtENTC_EMailFE.Text = Presenter.Item.ENTC_EmailReceptorFE;
            txtENTC_Web.Text = Presenter.Item.ENTC_Web;
            txtENTC_Telef1.Text = Presenter.Item.ENTC_Telef1;
            txtENTC_Telef2.Text = Presenter.Item.ENTC_Telef2;

            txtDIRE_Direccion.Text = Presenter.Item.DIRE_Direccion;
            txaUBIG_Codigo.PaisSelectedValue = Presenter.Item.TIPO_CodPaisFiscal;
            txaUBIG_Codigo.SelectedValue = Presenter.Item.UBIG_CodigoFiscal;

            txtDIRE_DireccionComercial.Text = Presenter.Item.DIRE_DireccionComercial;
            txaUBIG_CodigoComercial.PaisSelectedValue = Presenter.Item.TIPO_CodPaisComercial;
            txaUBIG_CodigoComercial.SelectedValue = Presenter.Item.UBIG_CodigoComercial;

            cmbTIPO_CodPAI.SelectedIndex = 0; if (Presenter.Item.TIPO_CodPai != null) { cmbTIPO_CodPAI.SelectedValue = Presenter.Item.TIPO_CodPai; }
            cmbCONS_CodTFT.SelectedIndex = 0; if (Presenter.Item.CONS_CodTFT != null) { cmbCONS_CodTFT.SelectedValue = Presenter.Item.CONS_CodTFT; }
            cmbTIPO_CodHOL.SelectedIndex = 0; if (Presenter.Item.TIPO_CodHol != null) { cmbTIPO_CodHOL.SelectedValue = Presenter.Item.TIPO_CodHol; }

            chkENTC_Domiciliado.Checked = Presenter.Item.ENTC_Domiciliado;
            chkENTC_VIP.Checked = Presenter.Item.ENTC_VIP;
            chkENTC_Propio.Checked = (Presenter.Item.ENTC_Propio.HasValue ? Presenter.Item.ENTC_Propio.Value : false);
            chkENTC_Prospecto.Checked = (Presenter.Item.ENTC_Prospecto.HasValue
               ? Presenter.Item.ENTC_Prospecto.Value
               : false);

            mdtENTC_FecCredito.NSFecha = Presenter.Item.ENTC_FechaCredito;
            if (Presenter.Item.ENTC_DiasCredito != null)
            {
               txtENTC_DiasCredito.Text = Presenter.Item.ENTC_DiasCredito.ToString();
            }
            txtENTC_Obser.Text = Presenter.Item.ENTC_Obser;

            chkENTC_OcultarShipper.Checked = Presenter.Item.ENTC_OcultarShipper;
            chkENTC_ToOrder.Checked = Presenter.Item.ENTC_ToOrder;
            #endregion
            /*$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$*/
            #region Otros Datos
            txtENTC_Notas.Text = Presenter.Item.ENTC_Notas;
            txtUSER_CodUsr.Text = Presenter.Item.USER_CodUsr;
            txtENTC_Beneficiario.Text = Presenter.Item.ENTC_Beneficiario;
            /*#####################################################################*/

            //solo devuelve uno
            if (Presenter.Item.EntidadAcuerdo != null)
            {
               mdtACUE_FecIni.NSFecha = Presenter.Item.EntidadAcuerdo.ACUE_FecIni;
               txtACUE_Valor.Text = Presenter.Item.EntidadAcuerdo.ACUE_Valor.ToString();
               cmbCONS_CodACU.SelectedItem = Presenter.Item.EntidadAcuerdo.CONS_CodACU;
            }
            if (Presenter.Item.ENTC_ValRebate != null) { txtENTC_ValRebate.Value = Presenter.Item.ENTC_ValRebate.Value; }
            if (Presenter.Item.TIPO_CodMND != null) { cmbTIPO_CodMND.SelectedValue = Presenter.Item.TIPO_CodMND; }
            ChkENTC_Tarja.Checked = (Presenter.Item.ENTC_Tarja.HasValue ? Presenter.Item.ENTC_Tarja.Value : false);
            if (Presenter.Item.ENTC_ValTarja != null) { txtENTC_ValTarja.Value = Presenter.Item.ENTC_ValTarja.Value; }
            #endregion
            /*$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$*/
            #region Financiero Clientes
            if (Presenter.Item.ENTC_Mandato.HasValue) { chkENTC_Mandato.Checked = Presenter.Item.ENTC_Mandato.Value; }
            if (Presenter.Item.ENTC_Exportacion.HasValue) { chkENTC_Exportacion.Checked = Presenter.Item.ENTC_Exportacion.Value; }
            if (Presenter.Item.ENTC_OtrosTraficos.HasValue) { chkENTC_OtrosTraficos.Checked = Presenter.Item.ENTC_OtrosTraficos.Value; }
            if (Presenter.Item.ENTC_SLI.HasValue) { chkENTC_SLI.Checked = Presenter.Item.ENTC_SLI.Value; }

            txtENTC_ObsFinanzasCliente.Text = Presenter.Item.ENTC_ObsFinanzasCliente;
            if (Presenter.Item.ENTC_BloqueoFinanzasCliente.HasValue) { chkENTC_BloqueoFinanzasCliente.Checked = Presenter.Item.ENTC_BloqueoFinanzasCliente.Value; }
            txtENTC_UsrBloqueoCliente.Text = Presenter.Item.ENTC_UsrBloqueoCliente;
            dtpENTC_FecBloqueoCliente.NSFecha = Presenter.Item.ENTC_FecBloqueoCliente;
            txtENTC_ObsBloqueoCliente.Text = Presenter.Item.ENTC_ObsBloqueoCliente;
            #endregion
            /*$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$*/
            #region Financiero Proveedores
            txtENTC_EmailFinanzas.Text = Presenter.Item.ENTC_EmailFinanzas;
            txtENTC_InterbancarioSol.Text = Presenter.Item.ENTC_InterbancarioSol;
            txtENTC_InterbancarioDol.Text = Presenter.Item.ENTC_InterbancarioDol;
            txtENTC_CuentaDetraccion.Text = Presenter.Item.ENTC_CuentaDetraccion;

            if (Presenter.Item.ENTC_BloqueoFinanzasProveedor.HasValue) { chkENTC_BloqueoFinanzasProveedor.Checked = Presenter.Item.ENTC_BloqueoFinanzasProveedor.Value; }
            txtENTC_UsrBloqueoProveedor.Text = Presenter.Item.ENTC_UsrBloqueoProveedor;
            dtpENTC_FecBloqueoProveedor.NSFecha = Presenter.Item.ENTC_FecBloqueoProveedor;
            txtENTC_ObsBloqueoProveedor.Text = Presenter.Item.ENTC_ObsBloqueoProveedor;
            chkENTC_ProvAsumeDetraccion.Checked = Presenter.Item.ENTC_ProvAsumeDetraccion;
            #endregion

            visualizaNatural_Juridica();
            txtENTC_Obser.Text = Presenter.Item.ENTC_Obser;

            ShowRelacionados();
            ShowServicios();

            switch (Presenter.tipe_Codigo)
            {
               case EntidadClear.TIPE_Cliente:
                  if (Presenter.Item != null)
                  {
                     BSItemsLimiteCreditoCliente.DataSource = Presenter.Item.ListEntidadLimiteCreditosCliente;
                     grdItemsLimiteCreditoCli.DataSource = BSItemsLimiteCreditoCliente;
                  }
                  break;
            }

            HashFormulario = FormValidateChanges.iniciarComparacionFormulario(this);
         }
         catch (Exception)
         {
            throw;
         }
      }
      public void ShowValidation()
      {
         try
         {
            Dialogos.MostrarMensajeInformacion(Presenter.Title, "Faltan ingresar datos obligatorios: ", Presenter.Item.MensajeError, Dialogos.Boton.Detalles);
            FormShowErrorProvider<Entidad>.Validate(Presenter.Item, this, errorProvider1);
         }
         catch (Exception ex)
         { Dialogos.MostrarMensajeError(Presenter.Title, Mensajes.ShowItems, ex); }
      }
      #endregion

      #region [ Metodos ]
      public void Dibujapantalla()
      {
         try
         {
            //tabControl_Entidad.TabPages.Remove(pageContactos);

            Text = Presenter.tipe_Desc;
            optENTC_SexoF.Checked = false;
            optENTC_TipEntJ.Checked = true;
            VisualizarDatosCliente(false);
            VisualizarDatosTransportista(false);
            VisualizarCuentaUsuario(false);
            VisualizarBeneficiario(false);
            chkENTC_VIP.Visible = false;
            chkENTC_Prospecto.Visible = false;
            chkENTC_Propio.Visible = false; // solo para ejecutivos  
            VisualizarAcuerdo(false);
            VisualizarServicio(false);
            VisualizarDepTemporal(false);
            tlpOtrosDatos.RowStyles[6].Height = 0;

            lblENTC_Direccion.Text = "Dirección";
            tlpDatosGenerales.RowStyles[15].Height = 0; //direccion comercial
            tlpDatosGenerales.RowStyles[16].Height = 0; //ubigeo comercial fila 1
            tlpDatosGenerales.RowStyles[17].Height = 0; //ubigeo comercial fila 2

            tlpDatosGenerales.RowStyles[18].Height = 27;
            tlpDatosGenerales.RowStyles[19].Height = 27;
            tlpDatosGenerales.RowStyles[20].Height = 27;
            tlpDatosGenerales.RowStyles[23].Height = 27;

            txaUBIG_CodigoComercial.Visible = false;
            txtDIRE_DireccionComercial.Visible = false;

            lblTIPO_CodHol.Visible = true;

            cmbTIPO_CodPAI.Visible = true;
            cmbTIPO_CodHOL.Visible = true;
            tlpOtrosDatos.RowStyles[0].Height = 27;
            tlpOtrosDatos.RowStyles[1].Height = 27;
            tlpOtrosDatos.RowStyles[2].Height = 27;
            tlpOtrosDatos.RowStyles[3].Height = 27;
            tlpOtrosDatos.RowStyles[4].Height = 27;
            tlpOtrosDatos.RowStyles[5].Height = 27;
            tlpOtrosDatos.RowStyles[6].Height = 27;
            tlpOtrosDatos.RowStyles[7].Height = 27;
            tlpOtrosDatos.RowStyles[8].Height = 27;

            pncAcuerdo.Visible = true;
            txtENTC_ValTarja.Visible = true;
            lblChecks.Visible = true;
            //chkENTC_Domiciliado.Visible = true;
            VisualizaControlesCredito(false);
            lblAgenteMaritimo.Visible = false;
            cmbAgenteMaritimo.Visible = false;
            //grdItemsServiciosCliente.ValueChanged -= grdDepTemporalEntidad_ValueChanged;


            lblCONS_CodRGM.Visible = false;
            cmbCONS_CodRGM.Visible = false;
            lblTIPO_CodTRF.Visible = false;
            cmbTIPO_CodTRF.Visible = false;
            chkENTC_Propio.Visible = false;
            tabControl_Entidad.TabPages.Remove(pageDepTemporal);
            //tlpDatosGenerales.RowStyles[3].Height = 0;

            lblENTC_OcultarShipper.Visible = false;
            chkENTC_OcultarShipper.Visible = false;

            lblENTC_ToOrder.Visible = false;
            chkENTC_ToOrder.Visible = false;

            switch (Presenter.tipe_Codigo)
            {
               case EntidadClear.TIPE_Empleado:
                  tabControl_Entidad.TabPages.Remove(pageFinanzasProveedor);
                  tabControl_Entidad.TabPages.Remove(pageFinanzasCliente);
                  tabControl_Entidad.TabPages.Remove(pageRelacionados);
                  tabControl_Entidad.TabPages.Remove(pageOtrosDatos);

                  chkENTC_VIP.Visible = true;
                  chkENTC_Prospecto.Visible = true;
                  VisualizarDatosCliente(true);
                  VisualizarServicio(true);
                  VisualizarDepTemporal(true);
                  optENTC_TipEntJ.Checked = true;
                  pageOtrosDatos.Show();
                  tlpOtrosDatos.RowStyles[6].Height = 27;
                  VisualizaControlesCredito(true);
                  txaUBIG_CodigoComercial.Visible = true;
                  txtDIRE_DireccionComercial.Visible = true;
                  tlpOtrosDatos.RowStyles[0].Height = 0;
                  tlpOtrosDatos.RowStyles[1].Height = 0;
                  tlpOtrosDatos.RowStyles[2].Height = 0;
                  tlpOtrosDatos.RowStyles[3].Height = 0;
                  tlpOtrosDatos.RowStyles[4].Height = 0;
                  tlpOtrosDatos.RowStyles[5].Height = 0;
                  tlpOtrosDatos.RowStyles[6].Height = 0;
                  tlpOtrosDatos.RowStyles[7].Height = 0;
                  tlpOtrosDatos.RowStyles[8].Height = 0;
                  tlpDatosGenerales.RowStyles[23].Height = 27;
                  pncAcuerdo.Visible = false;

                  lblChecks.Visible = false;
                  chkENTC_Domiciliado.Visible = false;
                  chkENTC_VIP.Visible = false;
                  chkENTC_Prospecto.Visible = false;

                  lblENTC_OcultarShipper.Visible = true;
                  chkENTC_OcultarShipper.Visible = true;

                  lblENTC_EMail.Visible = true;
                  lblENTC_EMail.Text = "Correo Contrato Mandato:";
                  txtENTC_EMail.Visible = true;

                  lblENTC_EMail2.Visible = true;
                  lblENTC_EMail2.Text = "Correo Otros Tráficos:";
                  txtENTC_EMail2.Visible = true;

                  lblENTC_EMailFE.Visible = true;
                  lblENTC_EMailFE.Text = "Correo Fact. Electrónica:";
                  txtENTC_EMailFE.Visible = true;

                  lblENTC_ServicioLogistico.Visible = true;
                  chkENTC_ServicioLogistico.Visible = true;

                  lblENTC_ToOrder.Visible = true;
                  chkENTC_ToOrder.Visible = true;
                  
                  break;
               case EntidadClear.TIPE_Cliente:
                  /**/
                  tabControl_Entidad.TabPages.Remove(pageFinanzasProveedor);
                  if (!Presenter.MostrarFinanzas) { tabControl_Entidad.TabPages.Remove(pageFinanzasCliente); }
                  /**/
                  chkENTC_VIP.Visible = true;
                  chkENTC_Prospecto.Visible = true;
                  VisualizarDatosCliente(true);
                  VisualizarServicio(true);
                  VisualizarDepTemporal(true);
                  optENTC_TipEntJ.Checked = true;
                  pageOtrosDatos.Show();
                  tlpOtrosDatos.RowStyles[6].Height = 27;
                  VisualizaControlesCredito(true);
                  txaUBIG_CodigoComercial.Visible = true;
                  txtDIRE_DireccionComercial.Visible = true;
                  tlpOtrosDatos.RowStyles[0].Height = 0;
                  tlpOtrosDatos.RowStyles[1].Height = 0;
                  tlpOtrosDatos.RowStyles[2].Height = 0;
                  tlpOtrosDatos.RowStyles[3].Height = 0;
                  tlpOtrosDatos.RowStyles[4].Height = 0;
                  tlpOtrosDatos.RowStyles[5].Height = 0;
                  tlpOtrosDatos.RowStyles[6].Height = 0;
                  tlpOtrosDatos.RowStyles[7].Height = 0;
                  tlpOtrosDatos.RowStyles[8].Height = 0;
                  tlpDatosGenerales.RowStyles[23].Height = 27;
                  pncAcuerdo.Visible = false;

                  lblChecks.Visible = false;
                  //chkENTC_Domiciliado.Visible = true;
                  chkENTC_VIP.Visible = false;
                  chkENTC_Prospecto.Visible = false;

                  lblENTC_OcultarShipper.Visible = true;
                  chkENTC_OcultarShipper.Visible = true;

                  lblENTC_EMail.Visible = true;
                  lblENTC_EMail.Text = "Correo Contrato Mandato:";
                  txtENTC_EMail.Visible = true;

                  lblENTC_EMail2.Visible = true;
                  lblENTC_EMail2.Text = "Correo Otros Tráficos:";
                  txtENTC_EMail2.Visible = true;

                  lblENTC_EMailFE.Visible = true;
                  lblENTC_EMailFE.Text = "Correo Facturación Electrónica:";
                  txtENTC_EMailFE.Visible = true;

                  lblENTC_ServicioLogistico.Visible = true;
                  chkENTC_ServicioLogistico.Visible = true;

                  lblENTC_ToOrder.Visible = true;
                  chkENTC_ToOrder.Visible = true;

                  break;
               case EntidadClear.TIPE_Proveedor:
                  tabControl_Entidad.TabPages.Remove(pageRelacionados);
                  tabControl_Entidad.TabPages.Remove(pageOtrosDatos);
                  //tabControl_Entidad.TabPages.Remove(pageDepTemporal);
                  /**/
                  tabControl_Entidad.TabPages.Remove(pageFinanzasCliente);
                  if (!Presenter.MostrarFinanzas) { tabControl_Entidad.TabPages.Remove(pageFinanzasProveedor); }
                  /**/
                  tlpDatosGenerales.RowStyles[15].Height = 0; //direccion comercial
                  tlpDatosGenerales.RowStyles[16].Height = 0; //ubigeo comercial fila 1
                  tlpDatosGenerales.RowStyles[17].Height = 0; //ubigeo comercial fila 2
                  tlpDatosGenerales.RowStyles[18].Height = 0;
                  //tlpDatosGenerales.RowStyles[24].Height = 0;
                  optENTC_TipEntJ.Checked = true;
                  VisualizaControlesCredito(true);
                  lblChecks.Visible = true;
                  //chkENTC_Domiciliado.Visible = true;
                  chkENTC_VIP.Visible = true;
                  chkENTC_Prospecto.Visible = true;
                  lblTIPO_CodHol.Visible = true;

                  lblENTC_EMail.Visible = true;
                  lblENTC_EMail.Text = "Correo: ";
                  txtENTC_EMail.Visible = true;

                  lblENTC_EMail2.Visible = false;
                  txtENTC_EMail2.Visible = false;

                  lblENTC_EMailFE.Visible = false;
                  txtENTC_EMailFE.Visible = false;

                  lblENTC_ServicioLogistico.Visible = false;
                  chkENTC_ServicioLogistico.Visible = false;

                  break;
               case EntidadClear.TIPE_Ejecutivo:
                  tabControl_Entidad.TabPages.Remove(pageRelacionados);
                  tabControl_Entidad.TabPages.Remove(pageFinanzasCliente);
                  tabControl_Entidad.TabPages.Remove(pageFinanzasProveedor);
                  //tabControl_Entidad.TabPages.Remove(pageDepTemporal);
                  VisualizarCuentaUsuario(true);
                  chkENTC_Propio.Visible = true;
                  optENTC_TipEntJ.Checked = false;
                  optENTC_TipEntN.Checked = true;
                  VisualizaControlesCredito(false);

                  lblretate.Visible = false;
                  txtENTC_ValRebate.Visible = false;
                  label1.Visible = false;
                  cmbTIPO_CodMND.Visible = false;
                  ChkENTC_Tarja.Visible = false;
                  label19.Visible = false;
                  txtENTC_ValTarja.Visible = false;
                  tlpDatosGenerales.RowStyles[2].Height = 0;
                  tlpDatosGenerales.RowStyles[18].Height = 0;
                  //tlpDatosGenerales.RowStyles[24].Height = 0;
                  tlpDatosGenerales.RowStyles[23].Height = 0;

                  lblENTC_EMail.Visible = true;
                  lblENTC_EMail.Text = "Correo: ";
                  txtENTC_EMail.Visible = true;

                  lblENTC_EMail2.Visible = false;
                  txtENTC_EMail2.Visible = false;

                  lblENTC_EMailFE.Visible = false;
                  txtENTC_EMailFE.Visible = false;

                  lblENTC_ServicioLogistico.Visible = false;
                  chkENTC_ServicioLogistico.Visible = false;

                  break;
               case EntidadClear.TIPE_CustomerService:
                  tabControl_Entidad.TabPages.Remove(pageRelacionados);
                  tabControl_Entidad.TabPages.Remove(pageFinanzasCliente);
                  tabControl_Entidad.TabPages.Remove(pageFinanzasProveedor);
                  //tabControl_Entidad.TabPages.Remove(pageDepTemporal);
                  VisualizarCuentaUsuario(true);
                  optENTC_TipEntJ.Checked = false;
                  optENTC_TipEntN.Checked = true;
                  VisualizaControlesCredito(false);
                  lblretate.Visible = false;
                  txtENTC_ValRebate.Visible = false;
                  label1.Visible = false;
                  cmbTIPO_CodMND.Visible = false;
                  ChkENTC_Tarja.Visible = false;
                  label19.Visible = false;
                  txtENTC_ValTarja.Visible = false;
                  tlpDatosGenerales.RowStyles[2].Height = 0;
                  tlpDatosGenerales.RowStyles[18].Height = 0;
                  tlpDatosGenerales.RowStyles[22].Height = 0;
                  tlpDatosGenerales.RowStyles[23].Height = 0;
                  //tlpDatosGenerales.RowStyles[24].Height = 0;

                  lblENTC_EMail.Visible = true;
                  lblENTC_EMail.Text = "Correo: ";
                  txtENTC_EMail.Visible = true;

                  lblENTC_EMail2.Visible = false;
                  txtENTC_EMail2.Visible = false;

                  lblENTC_EMailFE.Visible = false;
                  txtENTC_EMailFE.Visible = false;

                  lblENTC_ServicioLogistico.Visible = false;
                  chkENTC_ServicioLogistico.Visible = false;

                  break;
               case EntidadClear.TIPE_Transportista:
                  tabControl_Entidad.TabPages.Remove(pageFinanzasCliente);
                  tabControl_Entidad.TabPages.Remove(pageFinanzasProveedor);

                  VisualizarDatosTransportista(true);
                  optENTC_TipEntJ.Checked = true;
                  optENTC_TipEntN.Checked = false;
                  VisualizaControlesCredito(false);
                  tlpOtrosDatos.RowStyles[0].Height = 0;
                  tlpOtrosDatos.RowStyles[1].Height = 0;
                  tlpOtrosDatos.RowStyles[2].Height = 0;
                  tlpOtrosDatos.RowStyles[3].Height = 0;
                  tlpOtrosDatos.RowStyles[4].Height = 0;
                  tlpOtrosDatos.RowStyles[5].Height = 0;
                  tlpOtrosDatos.RowStyles[6].Height = 27;
                  tlpOtrosDatos.RowStyles[7].Height = 0;
                  tlpOtrosDatos.RowStyles[8].Height = 27;

                  lblAgenteMaritimo.Visible = false;
                  cmbAgenteMaritimo.Visible = false;
                  txtENTC_ValTarja.Visible = false;
                  lblretate.Visible = true;
                  ChkENTC_Tarja.Visible = false;
                  pncAcuerdo.Visible = false;
                  VisualizarServicio(false);
                  VisualizarDepTemporal(true);
                  pncServiciosCliente.Caption = "Depositos Temporales";
                  //tsbtnNuevoServicio.Visible = false;
                  //grdItemsServiciosCliente.CommandCellClick -= grdItemsServiciosCliente_CommandCellClick;
                  //grdItemsServiciosCliente.CellFormatting -= grdItemsServiciosCliente_CellFormatting;
                  //grdItemsServiciosCliente.ValueChanged += grdDepTemporalEntidad_ValueChanged;
                  FormatDataGridDepTemporal();
                  tlpDatosGenerales.RowStyles[18].Height = 0;
                  tlpDatosGenerales.RowStyles[22].Height = 0;
                  tlpDatosGenerales.RowStyles[23].Height = 0;
                  //tlpDatosGenerales.RowStyles[24].Height = 0;

                  lblENTC_EMail.Visible = true;
                  lblENTC_EMail.Text = "Correo: ";
                  txtENTC_EMail.Visible = true;

                  lblENTC_EMail2.Visible = false;
                  txtENTC_EMail2.Visible = false;

                  lblENTC_EMailFE.Visible = false;
                  txtENTC_EMailFE.Visible = false;

                  lblENTC_ServicioLogistico.Visible = false;
                  chkENTC_ServicioLogistico.Visible = false;

                  break;
               case EntidadClear.TIPE_Agente:
                  tabControl_Entidad.TabPages.Remove(pageFinanzasCliente);
                  tabControl_Entidad.TabPages.Remove(pageFinanzasProveedor);
                  //tabControl_Entidad.TabPages.Remove(pageDepTemporal);
                  VisualizarAcuerdo(true);
                  VisualizarBeneficiario(true);
                  optENTC_TipEntJ.Checked = true;
                  optENTC_TipEntN.Checked = false;
                  VisualizaControlesCredito(false);
                  VisualizarServicio(true);
                  tlpOtrosDatos.RowStyles[6].Height = 0;
                  tlpOtrosDatos.RowStyles[7].Height = 0;
                  tlpOtrosDatos.RowStyles[8].Height = 0;
                  tlpDatosGenerales.RowStyles[2].Height = 0;
                  tlpDatosGenerales.RowStyles[18].Height = 0;
                  tlpDatosGenerales.RowStyles[22].Height = 0;
                  tlpDatosGenerales.RowStyles[23].Height = 0;
                  //tlpDatosGenerales.RowStyles[24].Height = 0;

                  lblENTC_EMail.Visible = true;
                  lblENTC_EMail.Text = "Correo: ";
                  txtENTC_EMail.Visible = true;

                  lblENTC_EMail2.Visible = false;
                  txtENTC_EMail2.Visible = false;
                  
                  lblENTC_EMailFE.Visible = true;
                  txtENTC_EMailFE.Visible = true;

                  lblENTC_ServicioLogistico.Visible = false;
                  chkENTC_ServicioLogistico.Visible = false;

                  break;
               case EntidadClear.TIPE_Broker:
                  tabControl_Entidad.TabPages.Remove(pageFinanzasCliente);
                  tabControl_Entidad.TabPages.Remove(pageFinanzasProveedor);
                  //tabControl_Entidad.TabPages.Remove(pageDepTemporal);
                  VisualizarAcuerdo(true);
                  VisualizarBeneficiario(true);
                  optENTC_TipEntJ.Checked = false;
                  optENTC_TipEntN.Checked = true;
                  VisualizaControlesCredito(false);
                  VisualizarServicio(true);
                  tlpOtrosDatos.RowStyles[6].Height = 0;
                  tlpOtrosDatos.RowStyles[7].Height = 0;
                  tlpOtrosDatos.RowStyles[8].Height = 0;
                  tlpDatosGenerales.RowStyles[2].Height = 0;
                  tlpDatosGenerales.RowStyles[18].Height = 0;
                  tlpDatosGenerales.RowStyles[22].Height = 0;
                  tlpDatosGenerales.RowStyles[23].Height = 0;
                  //tlpDatosGenerales.RowStyles[24].Height = 0;

                  lblENTC_EMail.Visible = true;
                  lblENTC_EMail.Text = "Correo: ";
                  txtENTC_EMail.Visible = true;

                  lblENTC_EMail2.Visible = false;
                  txtENTC_EMail2.Visible = false;

                  lblENTC_EMailFE.Visible = false;
                  txtENTC_EMailFE.Visible = false;

                  lblENTC_ServicioLogistico.Visible = false;
                  chkENTC_ServicioLogistico.Visible = false;

                  break;
               case EntidadClear.TIPE_AgenteCarga:
                  tabControl_Entidad.TabPages.Remove(pageFinanzasCliente);
                  tabControl_Entidad.TabPages.Remove(pageFinanzasProveedor);
                  //tabControl_Entidad.TabPages.Remove(pageDepTemporal);
                  optENTC_TipEntJ.Checked = true;
                  optENTC_TipEntN.Checked = false;
                  VisualizaControlesCredito(false);
                  tlpOtrosDatos.RowStyles[6].Height = 0;
                  tlpOtrosDatos.RowStyles[7].Height = 0;
                  tlpOtrosDatos.RowStyles[8].Height = 0;
                  tlpDatosGenerales.RowStyles[2].Height = 0;
                  tlpDatosGenerales.RowStyles[18].Height = 0;
                  tlpDatosGenerales.RowStyles[22].Height = 0;
                  tlpDatosGenerales.RowStyles[23].Height = 0;
                  //tlpDatosGenerales.RowStyles[24].Height = 0;

                  lblENTC_EMail.Visible = true;
                  lblENTC_EMail.Text = "Correo: ";
                  txtENTC_EMail.Visible = true;

                  lblENTC_EMail2.Visible = false;
                  txtENTC_EMail2.Visible = false;

                  lblENTC_EMailFE.Visible = false;
                  txtENTC_EMailFE.Visible = false;

                  lblENTC_ServicioLogistico.Visible = false;
                  chkENTC_ServicioLogistico.Visible = false;

                  break;
               case EntidadClear.TIPE_Contacto:

                  tlpDatosGenerales.RowStyles[14].Height = 27;
                  tlpDatosGenerales.RowStyles[15].Height = 27;

                  tabControl_Entidad.TabPages.Remove(pageFinanzasProveedor);
                  tabControl_Entidad.TabPages.Remove(pageOtrosDatos);
                  tabControl_Entidad.TabPages.Remove(pageRelacionados);
                  tabControl_Entidad.TabPages.Remove(pageFinanzasCliente);
                  //tabControl_Entidad.TabPages.Remove(pageDepTemporal);
                  optENTC_TipEntJ.Checked = false;
                  optENTC_TipEntJ.Visible = false;
                  optENTC_TipEntN.Checked = true;

                  //tlpDatosGenerales.RowStyles[3].Height = 27;
                  lblCONS_CodRGM.Visible = true;
                  cmbCONS_CodRGM.Visible = true;
                  lblTIPO_CodTRF.Visible = true;
                  cmbTIPO_CodTRF.Visible = true;

                  lblTIPO_CodTDI.Visible = true;
                  lblENTC_DocIden.Visible = true;

                  tlpOtrosDatos.RowStyles[6].Height = 0;
                  tlpOtrosDatos.RowStyles[7].Height = 0;
                  tlpOtrosDatos.RowStyles[8].Height = 0;

                  cmbTIPO_CodTDI.DataSource = null;
                  cmbTIPO_CodTDI.LoadControl("Tipos de TDI para Contacto", ComboBoxTipos.OTipos.TDI_contacto, "< Seleccionar Tipo Doc. Identidad >", ListSortDirection.Ascending);

                  lblENTC_EMail.Visible = true;
                  lblENTC_EMail.Text = "Correo: ";
                  txtENTC_EMail.Visible = true;

                  lblENTC_EMail2.Visible = false;
                  txtENTC_EMail2.Visible = false;

                  lblENTC_EMailFE.Visible = false;
                  txtENTC_EMailFE.Visible = false;

                  lblENTC_ServicioLogistico.Visible = false;
                  chkENTC_ServicioLogistico.Visible = false;

                  break;
               case EntidadClear.TIPE_Shipper:
                  tabControl_Entidad.TabPages.Remove(pageFinanzasCliente);
                  tabControl_Entidad.TabPages.Remove(pageFinanzasProveedor);
                  //tabControl_Entidad.TabPages.Remove(pageDepTemporal);
                  chkENTC_VIP.Visible = true;
                  chkENTC_Prospecto.Visible = true;
                  VisualizarDatosCliente(true);
                  VisualizarServicio(false);
                  VisualizarDepTemporal(false);
                  optENTC_TipEntJ.Checked = true;
                  VisualizaControlesCredito(false);
                  tlpOtrosDatos.RowStyles[6].Height = 0;
                  tlpOtrosDatos.RowStyles[7].Height = 0;
                  tlpOtrosDatos.RowStyles[8].Height = 0;

                  tlpDatosGenerales.RowStyles[2].Height = 0;
                  tlpDatosGenerales.RowStyles[18].Height = 0;
                  tlpDatosGenerales.RowStyles[17].Height = 0;
                  tlpDatosGenerales.RowStyles[16].Height = 0;
                  //tlpDatosGenerales.RowStyles[24].Height = 0;

                  lblENTC_EMail.Visible = true;
                  lblENTC_EMail.Text = "Correo: ";
                  txtENTC_EMail.Visible = true;

                  lblENTC_EMail2.Visible = false;
                  txtENTC_EMail2.Visible = false;

                  lblENTC_EMailFE.Visible = false;
                  txtENTC_EMailFE.Visible = false;

                  lblENTC_ServicioLogistico.Visible = false;
                  chkENTC_ServicioLogistico.Visible = false;

                  break;
               case EntidadClear.TIPE_AgentePortuario:
                  tabControl_Entidad.TabPages.Remove(pageFinanzasCliente);
                  tabControl_Entidad.TabPages.Remove(pageFinanzasProveedor);
                  //tabControl_Entidad.TabPages.Remove(pageDepTemporal);

                  optENTC_TipEntJ.Checked = true;
                  VisualizaControlesCredito(false);
                  tlpOtrosDatos.RowStyles[6].Height = 0;
                  tlpOtrosDatos.RowStyles[7].Height = 0;
                  tlpOtrosDatos.RowStyles[8].Height = 0;

                  tlpDatosGenerales.RowStyles[2].Height = 0;
                  tlpDatosGenerales.RowStyles[18].Height = 0;
                  tlpDatosGenerales.RowStyles[22].Height = 0;
                  tlpDatosGenerales.RowStyles[23].Height = 0;
                  //tlpDatosGenerales.RowStyles[24].Height = 0;

                  lblENTC_EMail.Visible = true;
                  lblENTC_EMail.Text = "Correo: ";
                  txtENTC_EMail.Visible = true;

                  lblENTC_EMail2.Visible = false;
                  txtENTC_EMail2.Visible = false;

                  lblENTC_EMailFE.Visible = false;
                  txtENTC_EMailFE.Visible = false;

                  lblENTC_ServicioLogistico.Visible = false;
                  chkENTC_ServicioLogistico.Visible = false;

                  break;
               case EntidadClear.TIPE_AgenciaAduanera:  // Delfin Logistico
                  tabControl_Entidad.TabPages.Remove(pageFinanzasCliente);
                  tabControl_Entidad.TabPages.Remove(pageFinanzasProveedor);
                  //tabControl_Entidad.TabPages.Remove(pageDepTemporal);

                  VisualizarMantenimientoLogistico(true);
                  tlpDatosGenerales.RowStyles[1].Height = 0;
                  tlpDatosGenerales.RowStyles[20].Height = 0;
                  tlpDatosGenerales.RowStyles[23].Height = 0;
                  //tlpDatosGenerales.RowStyles[24].Height = 0;

                  lblENTC_EMail.Visible = true;
                  lblENTC_EMail.Text = "Correo: ";
                  txtENTC_EMail.Visible = true;

                  lblENTC_EMail2.Visible = false;
                  txtENTC_EMail2.Visible = false;

                  lblENTC_EMailFE.Visible = false;
                  txtENTC_EMailFE.Visible = false;

                  lblENTC_ServicioLogistico.Visible = false;
                  chkENTC_ServicioLogistico.Visible = false;

                  break;
               case EntidadClear.TIPE_AgenciaMaritima:  // Delfin Logistico
                  tabControl_Entidad.TabPages.Remove(pageFinanzasCliente);
                  tabControl_Entidad.TabPages.Remove(pageFinanzasProveedor);
                  //tabControl_Entidad.TabPages.Remove(pageDepTemporal);

                  VisualizarMantenimientoLogistico(true);

                  tlpDatosGenerales.RowStyles[18].Height = 0;
                  tlpDatosGenerales.RowStyles[20].Height = 0;
                  tlpDatosGenerales.RowStyles[23].Height = 0;
                  //tlpDatosGenerales.RowStyles[24].Height = 0;

                  lblENTC_EMail.Visible = true;
                  lblENTC_EMail.Text = "Correo: ";
                  txtENTC_EMail.Visible = true;

                  lblENTC_EMail2.Visible = false;
                  txtENTC_EMail2.Visible = false;

                  lblENTC_EMailFE.Visible = false;
                  txtENTC_EMailFE.Visible = false;

                  lblENTC_ServicioLogistico.Visible = false;
                  chkENTC_ServicioLogistico.Visible = false;

                  break;
               case EntidadClear.TIPE_DepositoTemporal:  // Delfin Logistico
                  tabControl_Entidad.TabPages.Remove(pageFinanzasCliente);
                  tabControl_Entidad.TabPages.Remove(pageFinanzasProveedor);
                  //tabControl_Entidad.TabPages.Remove(pageDepTemporal);

                  VisualizarMantenimientoLogistico(true);
                  pageOtrosDatos.Show();
                  tlpOtrosDatos.RowStyles[0].Height = 0;
                  tlpOtrosDatos.RowStyles[1].Height = 0;
                  tlpOtrosDatos.RowStyles[2].Height = 0;
                  tlpOtrosDatos.RowStyles[3].Height = 0;
                  tlpOtrosDatos.RowStyles[4].Height = 0;
                  tlpOtrosDatos.RowStyles[5].Height = 0;
                  VisualizarServicio(false);
                  VisualizarDepTemporal(false);
                  tlpDatosGenerales.RowStyles[20].Height = 0;
                  tlpDatosGenerales.RowStyles[23].Height = 0;
                  //tlpDatosGenerales.RowStyles[24].Height = 0;

                  lblENTC_EMail.Visible = true;
                  lblENTC_EMail.Text = "Correo: ";
                  txtENTC_EMail.Visible = true;

                  lblENTC_EMail2.Visible = false;
                  txtENTC_EMail2.Visible = false;

                  lblENTC_EMailFE.Visible = false;
                  txtENTC_EMailFE.Visible = false;

                  lblENTC_ServicioLogistico.Visible = false;
                  chkENTC_ServicioLogistico.Visible = false;

                  break;
               case EntidadClear.TIPE_DepositoVacio:  // Delfin Logistico
                  tabControl_Entidad.TabPages.Remove(pageFinanzasCliente);
                  tabControl_Entidad.TabPages.Remove(pageFinanzasProveedor);
                  //tabControl_Entidad.TabPages.Remove(pageDepTemporal);

                  VisualizarMantenimientoLogistico(true);
                  tlpDatosGenerales.RowStyles[20].Height = 0;
                  tlpDatosGenerales.RowStyles[23].Height = 0;
                  //tlpDatosGenerales.RowStyles[24].Height = 0;

                  lblENTC_EMail.Visible = true;
                  lblENTC_EMail.Text = "Correo: ";
                  txtENTC_EMail.Visible = true;

                  lblENTC_EMail2.Visible = false;
                  txtENTC_EMail2.Visible = false;

                  lblENTC_EMailFE.Visible = false;
                  txtENTC_EMailFE.Visible = false;

                  lblENTC_ServicioLogistico.Visible = false;
                  chkENTC_ServicioLogistico.Visible = false;

                  break;
            }

         }
         catch (Exception ex)
         {
            Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al dibujar la pantalla.", ex);
         }
      }
      private void VisualizaControlesCredito(Boolean IsVisible)
      {
         lblcredito.Visible = IsVisible;
         txtENTC_DiasCredito.Visible = IsVisible;
         mdtENTC_FecCredito.Visible = IsVisible;
         lblfechacredito.Visible = IsVisible;
      }
      private void visualizaNatural_Juridica()
      {
         try
         {
            Boolean _juridica = optENTC_TipEntJ.Checked;
            Boolean _natural = optENTC_TipEntN.Checked;


            tlpDatosGenerales.RowStyles[4].Height = _juridica ? 27 : 0;
            tlpDatosGenerales.RowStyles[5].Height = _juridica ? 27 : 0;
            lblENTC_RazonSocial.Visible = _juridica;
            txtENTC_RazonSocial.Visible = _juridica;
            lblENTC_NomComercial.Visible = _juridica;
            txtENTC_NomComercial.Visible = _juridica;


            tlpDatosGenerales.RowStyles[6].Height = _natural ? 27 : 0;
            tlpDatosGenerales.RowStyles[7].Height = _natural ? 27 : 0;
            tlpDatosGenerales.RowStyles[8].Height = _natural ? 27 : 0;
            tlpDatosGenerales.RowStyles[9].Height = _natural ? 27 : 0;
            lblENTC_ApePat.Visible = _natural;
            txtENTC_ApePat.Visible = _natural;
            lblENTC_ApeMat.Visible = _natural;
            txtENTC_ApeMat.Visible = _natural;
            lblENTC_Nombres.Visible = _natural;
            txtENTC_Nombres.Visible = _natural;
            lblENTC_Sexo.Visible = _natural;
            pnlENTC_Sexo.Visible = _natural;
            optENTC_SexoM.Visible = _natural;
            optENTC_SexoF.Visible = _natural;
            lblENTC_Area.Visible = _natural;
            txtENTC_Area.Visible = _natural;
            lblENTC_Cargo.Visible = _natural;
            txtENTC_Cargo.Visible = _natural;
            lblENTC_FecNac.Visible = _natural;
            mdtENTC_FecNac.Visible = _natural;
            lblENTC_FecIng.Visible = _natural;
            mdtENTC_FecIng.Visible = _natural;

            //tblJuridica.Visible = optENTC_TipEntJ.Checked;
            //tbllNatural.Visible = optENTC_TipEntN.Checked;
         }
         catch (Exception ex)
         { Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al configurar el tipo de entidad.", ex); }
      }
      private void VisualizarDatosCliente(Boolean IsVisible)
      {
         try
         {
            tlpDatosGenerales.RowStyles[15].Height = 27;   //direccion comercial
            tlpDatosGenerales.RowStyles[16].Height = 27;   //ubigeo comercial fila 1
            tlpDatosGenerales.RowStyles[17].Height = 27;   //ubigeo comercial fila 2
            tlpDatosGenerales.RowStyles[19].Height = IsVisible ? 27 : 0;
            tlpDatosGenerales.RowStyles[2].Height = 0;
            tlpDatosGenerales.RowStyles[23].Height = 0;
            lblTIPO_CodHol.Visible = IsVisible;
            cmbTIPO_CodHOL.Visible = IsVisible;

            lblENTC_Direccion.Text = "Dirección Fiscal";

            //txtENTC_Notas.Visible = false;
            //lblENTC_Notas.Visible = false;
            //lblUSER_CodUsr.Visible = false;
            //txtUSER_CodUsr.Visible = false;
            //lblENTC_Beneficiario.Visible = false;
            //txtENTC_Beneficiario.Visible = false;
            //pncAcuerdo.Visible = false;
            //lblACUE_FecIni.Visible = false;
            //mdtACUE_FecIni.Visible = false;
            //lblACUE_Valor.Visible = false;
            //txtACUE_Valor.Visible = false;
            //lblACUE_TipoAcuerdo.Visible = false;
            //cmbCONS_CodACU.Visible = false;
            //tlpOtrosDatos.Visible = false;

         }
         catch (Exception ex)
         { Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al configurar datos del cliente.", ex); }
      }
      private void VisualizarDatosTransportista(Boolean IsVisible)
      {
         try
         {
            lblCONS_CodTFT.Visible = IsVisible;
            cmbCONS_CodTFT.Visible = IsVisible;
         }
         catch (Exception ex)
         { Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al configurar datos del transportista.", ex); }
      }
      private void VisualizarCuentaUsuario(Boolean IsVisible)
      {
         try
         {
            tlpOtrosDatos.RowStyles[1].Height = IsVisible ? 27 : 0;
            lblUSER_CodUsr.Visible = IsVisible;
            txtUSER_CodUsr.Visible = IsVisible;
         }
         catch (Exception ex)
         { Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al configurar la cuenta de usuario.", ex); }
      }
      private void VisualizarBeneficiario(Boolean IsVisible)
      {
         try
         {
            tlpOtrosDatos.RowStyles[2].Height = IsVisible ? 27 : 0;
            lblENTC_Beneficiario.Visible = IsVisible;
            txtENTC_Beneficiario.Visible = IsVisible;
         }
         catch (Exception ex)
         { Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al configurar la cuenta de usuario.", ex); }
      }
      private void VisualizarAcuerdo(Boolean IsVisible)
      {
         try
         {
            tlpOtrosDatos.RowStyles[3].Height = IsVisible ? 27 : 0;
            tlpOtrosDatos.RowStyles[4].Height = IsVisible ? 27 : 0;
            tlpOtrosDatos.RowStyles[5].Height = IsVisible ? 27 : 0;

            pnlAcuerdo.Visible = IsVisible;
            pncAcuerdo.Visible = IsVisible;

            lblACUE_FecIni.Visible = IsVisible;
            mdtACUE_FecIni.Visible = IsVisible;
            lblACUE_Valor.Visible = IsVisible;
            txtACUE_Valor.Visible = IsVisible;
            lblACUE_TipoAcuerdo.Visible = IsVisible;
            cmbCONS_CodACU.Visible = IsVisible;
         }
         catch (Exception ex)
         { Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al configurar el acuerdo.", ex); }
      }
      private void VisualizarServicio(Boolean IsVisible)
      {
         try
         {
            pnlServiciosCliente.Visible = IsVisible;
            pncServiciosCliente.Visible = IsVisible;
            grdItemsServiciosCliente.Visible = IsVisible;
            navItemsServiciosCliente.Visible = IsVisible;
         }
         catch (Exception ex)
         { Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al configurar el servicio cliente.", ex); }
      }
      private void VisualizarDepTemporal(Boolean IsVisible)
      {
         try
         {
            pnlDepTemporalEntidad.Visible = IsVisible;
            grdDepTemporalEntidad.Visible = IsVisible;
            navDepTemporalEntidad.Visible = IsVisible;
         }
         catch (Exception ex)
         { Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al configurar el servicio cliente.", ex); }
      }
      private void Contacto(string x_contactoImpo_Expo, bool x_lNuevo)
      {

         MAN009MView MAN009_mview_sinlv;
         MAN009Presenter MAN009_presenter_sinlv;
         MAN009_mview_sinlv = new MAN009MView();
         MAN009_presenter_sinlv = new MAN009Presenter(Presenter.ContainerService, MAN009_mview_sinlv, EntidadClear.TIPE_Contacto);
         MAN009_mview_sinlv.Presenter = MAN009_presenter_sinlv;
         MAN009_presenter_sinlv.lsinlview = true;
         MAN009_presenter_sinlv.tipe_Desc = "Contacto";
         MAN009_presenter_sinlv.Load();


         if (x_lNuevo)
         { MAN009_presenter_sinlv.Nuevo(); }
         else
         {

            MAN009_presenter_sinlv.Item = Presenter.Item.ContactoImpo;

            MAN009_presenter_sinlv.Editar();
         }
         //if (x_contactoImpo_Expo == "001")
         //{        //Actualiza datos del contacto
         //   if (MAN009_presenter_sinlv.Item != null)
         //   {
         //      if (MAN009_presenter_sinlv.Item.ENTC_Codigo.ToString() != "0")
         //      {
         //         Presenter.Item.ContactoImpo = MAN009_presenter_sinlv.Item;

         //         txtENTC_Codigo_C_IMPO.Text = MAN009_presenter_sinlv.Item.ENTC_Codigo.ToString();
         //         txtENTC_ApeMat_C_IMPO.Text = MAN009_presenter_sinlv.Item.ENTC_ApeMat;
         //         txtENTC_ApePat_C_IMPO.Text = MAN009_presenter_sinlv.Item.ENTC_ApePat;
         //         txtENTC_Nombres_C_IMPO.Text = MAN009_presenter_sinlv.Item.ENTC_Nombres;
         //         txtENTC_Cargo_C_IMPO.Text = MAN009_presenter_sinlv.Item.ENTC_Cargo;
         //         txtENTC_Area_C_IMPO.Text = MAN009_presenter_sinlv.Item.ENTC_Area;
         //         txtENTC_EMail_C_IMPO.Text = MAN009_presenter_sinlv.Item.ENTC_EMail;
         //         txtENTC_Telef1_C_IMPO.Text = MAN009_presenter_sinlv.Item.ENTC_Telef1;
         //         txtENTC_Telef2_C_IMPO.Text = MAN009_presenter_sinlv.Item.ENTC_Telef2;
         //         //optENTC_Sexo_.Checked = (Presenter.Item.ContactoImpo.ENTC_Sexo == "F") ? true : false;
         //         mdtENTC_FecNac_C_IMPO.NSFecha = MAN009_presenter_sinlv.Item.ENTC_FecNac;
         //      }
         //   }
         //}
         //else
         //{
         //   if (MAN009_presenter_sinlv.Item != null)
         //   {
         //      if (MAN009_presenter_sinlv.Item.ENTC_Codigo.ToString() != "0")
         //      {
         //         Presenter.Item.ContactoExpo = MAN009_presenter_sinlv.Item;

         //         txtENTC_Codigo_C_EXPO.Text = MAN009_presenter_sinlv.Item.ENTC_Codigo.ToString();
         //         txtENTC_ApeMat_C_EXPO.Text = MAN009_presenter_sinlv.Item.ENTC_ApeMat;
         //         txtENTC_ApePat_C_EXPO.Text = MAN009_presenter_sinlv.Item.ENTC_ApePat;
         //         txtENTC_Nombres_C_EXPO.Text = MAN009_presenter_sinlv.Item.ENTC_Nombres;
         //         txtENTC_Cargo_C_EXPO.Text = MAN009_presenter_sinlv.Item.ENTC_Cargo;
         //         txtENTC_Area_C_EXPO.Text = MAN009_presenter_sinlv.Item.ENTC_Area;
         //         txtENTC_EMail_C_EXPO.Text = MAN009_presenter_sinlv.Item.ENTC_EMail;
         //         txtENTC_Telef1_C_EXPO.Text = MAN009_presenter_sinlv.Item.ENTC_Telef1;
         //         txtENTC_Telef2_C_EXPO.Text = MAN009_presenter_sinlv.Item.ENTC_Telef2;
         //         //optENTC_Sexo_.Checked = (Presenter.Item.ContactoEXPO.ENTC_Sexo == "F") ? true : false;
         //         mdtENTC_FecNac_C_EXPO.NSFecha = MAN009_presenter_sinlv.Item.ENTC_FecNac;
         //      }
         //   }
         //}

      }
      private void ValidarDocIdentidad()
      {
         try
         {
            if (cmbTIPO_CodTDI.TiposSelectedItem != null && !String.IsNullOrEmpty(txtENTC_DocIden.Text))
            {
               if (cmbTIPO_CodTDI.TiposSelectedItem.TIPO_CodTipo == Presenter.TIPO_CodTDI)
               {
                  Presenter.Item.ValidarDocIden = false;
               }
               else
               {
                  Presenter.Item.ValidarDocIden = true;
                  Presenter.ValidarDocIdentidad(cmbTIPO_CodTDI.TiposSelectedItem, txtENTC_DocIden.Text);
               }
            }
         }
         catch (Exception ex)
         { Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un erro al validar el Documento de Identidad.", ex); }
      }
      private void VisualizarMantenimientoLogistico(Boolean IsVisible)
      {
         try
         {
            pageOtrosDatos.Hide();
            tlpDatosGenerales.RowStyles[1].Height = 0;
            tlpOtrosDatos.RowStyles[1].Height = 0;
            optENTC_TipEntJ.Checked = IsVisible;
            optENTC_TipEntN.Checked = false;

            tlpDatosGenerales.RowStyles[15].Height = 0; //direccion comercial
            tlpDatosGenerales.RowStyles[16].Height = 0; //ubigeo comercial fila 1
            tlpDatosGenerales.RowStyles[17].Height = 0; //ubigeo comercial fila 2
            tlpDatosGenerales.RowStyles[18].Height = 0;
            tlpDatosGenerales.RowStyles[19].Height = 0;
            tlpDatosGenerales.RowStyles[20].Height = 27;
            VisualizaControlesCredito(true);
            lblChecks.Visible = false;

            chkENTC_Domiciliado.Visible = false;
            chkENTC_Prospecto.Visible = false;

            txtDIRE_DireccionComercial.Visible = false;
            txaUBIG_CodigoComercial.Visible = false;
            cmbTIPO_CodPAI.Visible = false;
            cmbTIPO_CodHOL.Visible = false;
         }
         catch (Exception ex)
         { Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al configurar los controles.", ex); }
      }

      #region [ Finanzas Cliente ]
      private void NuevoLimiteCreditoCliente()
      {
         try
         {
            if (BSItemsLimiteCreditoCliente.Current != null)
            {
               int posicion = BSItemsLimiteCreditoCliente.Position;
               Entities.EntidadLimiteCredito LimCredCliente = Presenter.NuevoLimiteCreditoCliente((Entities.EntidadLimiteCredito)BSItemsLimiteCreditoCliente.Current);
               if (LimCredCliente != null)
               {
                  ((ObservableCollection<Entities.EntidadLimiteCredito>)BSItemsLimiteCreditoCliente.DataSource)[posicion] = LimCredCliente;
                  ShowLimiteCreditoCliente();
               }
            }
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al crear el limite de credito", ex); }
      }
      private void EditarLimiteCreditoCliente()
      {
         try
         {
            if (BSItemsLimiteCreditoCliente.Current != null)
            {
               if (((Entities.EntidadLimiteCredito)BSItemsLimiteCreditoCliente.Current).ENLI_Codigo != 0)
               {
                  int posicion = BSItemsLimiteCreditoCliente.Position;
                  Entities.EntidadLimiteCredito LimCredCliente = Presenter.EditarLimiteCreditoCliente((Entities.EntidadLimiteCredito)BSItemsLimiteCreditoCliente.Current);
                  if (LimCredCliente != null)
                  {
                     ((ObservableCollection<Entities.EntidadLimiteCredito>)BSItemsLimiteCreditoCliente.DataSource)[posicion] = LimCredCliente;
                     ShowLimiteCreditoCliente();
                  }
               }
               else
               {
                  Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Presenter.Title, "No puede editar un registro que aun no fue creado");
               }
            }
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al editar el limite de credito", ex); }
      }
      private void HistorialLimiteCreditoCliente()
      {
         try
         {
            Presenter.HistorialLimiteCreditoCliente((Entities.EntidadLimiteCredito)BSItemsLimiteCreditoCliente.Current);
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al mostrar el hisotorial del limite de credito", ex); }
      }
      private void BloqueoUsuarioFinanzasCliente()
      {
         try
         {
            txtENTC_UsrBloqueoCliente.Text = Presenter.Session.UserName;
            dtpENTC_FecBloqueoCliente.NSFecha = Presenter.Client.GetFecha();
         }
         catch (Exception ex)
         { Dialogos.MostrarMensajeError(Presenter.Title, "Ocurrio un error bloqueando el Usuario en operaciones financieras del cliente", ex); }
      }
      private void FormatDataGridLimiteCreditoCliente()
      {
         try
         {
            Telerik.WinControls.UI.Localization.RadGridLocalizationProvider.CurrentProvider = new Infrastructure.WinForms.Controls.MySpanishRadGridLocalizationProvider();
            this.grdItemsLimiteCreditoCli.Columns.Clear();
            this.grdItemsLimiteCreditoCli.AllowAddNewRow = false;

            GridViewCommandColumn commandColumn;
            commandColumn = new GridViewCommandColumn();
            commandColumn.Name = "New";
            commandColumn.HeaderText = "Nuevo";
            commandColumn.DefaultText = "Nuevo";
            commandColumn.UseDefaultText = true;
            this.grdItemsLimiteCreditoCli.Columns.Add(commandColumn);
            this.grdItemsLimiteCreditoCli.Columns["New"].AllowSort = false;
            this.grdItemsLimiteCreditoCli.Columns["New"].AllowFiltering = false;

            commandColumn = new GridViewCommandColumn();
            commandColumn.Name = "Edit";
            commandColumn.HeaderText = "Editar";
            commandColumn.DefaultText = "Editar";
            commandColumn.UseDefaultText = true;
            this.grdItemsLimiteCreditoCli.Columns.Add(commandColumn);
            this.grdItemsLimiteCreditoCli.Columns["Edit"].AllowSort = false;
            this.grdItemsLimiteCreditoCli.Columns["Edit"].AllowFiltering = false;

            commandColumn = new GridViewCommandColumn();
            commandColumn.Name = "History";
            commandColumn.HeaderText = "Historial";
            commandColumn.DefaultText = "Historial";
            commandColumn.UseDefaultText = true;
            this.grdItemsLimiteCreditoCli.Columns.Add(commandColumn);
            this.grdItemsLimiteCreditoCli.Columns["History"].AllowSort = false;
            this.grdItemsLimiteCreditoCli.Columns["History"].AllowFiltering = false;

            this.grdItemsLimiteCreditoCli.Columns.Add("ENLI_TiposDescripcion", "Tipo", "ENLI_TiposDescripcion");
            this.grdItemsLimiteCreditoCli.Columns["ENLI_TiposDescripcion"].Width = 150;
            this.grdItemsLimiteCreditoCli.Columns.Add("TIPO_MND", "Moneda", "TIPO_MND");
            this.grdItemsLimiteCreditoCli.Columns["TIPO_MND"].Width = 80;

            //this.grdItemsLimiteCreditoCli.Columns.Add("ENLI_Monto", "Monto", "ENLI_Monto");
            GridViewDecimalColumn ENLI_Monto = new GridViewDecimalColumn();
            ENLI_Monto.Name = "ENLI_Monto";
            ENLI_Monto.HeaderText = "Monto";
            ENLI_Monto.FieldName = "ENLI_Monto";
            ENLI_Monto.DecimalPlaces = 2;
            ENLI_Monto.Maximum = 99999999;
            ENLI_Monto.Minimum = 0;
            ENLI_Monto.FormatString = "{0:#,###,##0.00}";
            ENLI_Monto.ThousandsSeparator = true;
            grdItemsLimiteCreditoCli.MasterTemplate.Columns.Add(ENLI_Monto);
            grdItemsLimiteCreditoCli.Columns["ENLI_Monto"].Width = 90;
            grdItemsLimiteCreditoCli.Columns["ENLI_Monto"].TextAlignment = ContentAlignment.MiddleRight;
            grdItemsLimiteCreditoCli.Columns["ENLI_Monto"].ReadOnly = true;

            //this.grdItemsLimiteCreditoCli.Columns.Add("ENLI_Fecha", "Fecha Convenio", "ENLI_Fecha");
            GridViewDateTimeColumn ENLI_Fecha = new GridViewDateTimeColumn();
            ENLI_Fecha.Name = "ENLI_Fecha";
            ENLI_Fecha.HeaderText = "Fecha Convenio";
            ENLI_Fecha.FieldName = "ENLI_Fecha";
            ENLI_Fecha.Format = DateTimePickerFormat.Short;
            ENLI_Fecha.FormatString = "{0:dd/MM/yyyy}";
            grdItemsLimiteCreditoCli.MasterTemplate.Columns.Add(ENLI_Fecha);
            grdItemsLimiteCreditoCli.Columns["ENLI_Fecha"].Width = 120;
            grdItemsLimiteCreditoCli.Columns["ENLI_Fecha"].TextAlignment = ContentAlignment.MiddleRight;
            grdItemsLimiteCreditoCli.Columns["ENLI_Fecha"].ReadOnly = true;

            //this.grdItemsLimiteCreditoCli.Columns.Add("ENLI_DiasDuracion", "Dias", "ENLI_DiasDuracion");
            GridViewDecimalColumn ENLI_DiasDuracion = new GridViewDecimalColumn();
            ENLI_DiasDuracion.Name = "ENLI_DiasDuracion";
            ENLI_DiasDuracion.HeaderText = "Forma de Pago";
            ENLI_DiasDuracion.FieldName = "ENLI_DiasDuracion";
            ENLI_DiasDuracion.DecimalPlaces = 0;
            ENLI_DiasDuracion.Maximum = 9999;
            ENLI_DiasDuracion.Minimum = 0;
            grdItemsLimiteCreditoCli.MasterTemplate.Columns.Add(ENLI_DiasDuracion);
            grdItemsLimiteCreditoCli.Columns["ENLI_DiasDuracion"].Width = 100;
            grdItemsLimiteCreditoCli.Columns["ENLI_DiasDuracion"].TextAlignment = ContentAlignment.MiddleRight;
            grdItemsLimiteCreditoCli.Columns["ENLI_DiasDuracion"].ReadOnly = true;

            //this.grdItemsLimiteCreditoCli.Columns.Add("ENLI_Codigo", "Código", "ENLI_Codigo");
            //this.grdItemsLimiteCreditoCli.Columns["ENLI_Codigo"].Width = 50;

            /* Propiedades Finales */
            //grdItemsLimiteCreditoCli.BestFitColumns();

            grdItemsLimiteCreditoCli.ReadOnly = true;
            grdItemsLimiteCreditoCli.ShowFilteringRow = false;
            grdItemsLimiteCreditoCli.EnableFiltering = false;
            grdItemsLimiteCreditoCli.MasterTemplate.EnableFiltering = false;
            grdItemsLimiteCreditoCli.EnableGrouping = false;
            grdItemsLimiteCreditoCli.MasterTemplate.EnableGrouping = false;
            grdItemsLimiteCreditoCli.EnableSorting = false;
            grdItemsLimiteCreditoCli.MasterTemplate.EnableCustomSorting = false;

         }
         catch (Exception ex)
         { Dialogos.MostrarMensajeError(Presenter.Title, Mensajes.FormatDataGridView, ex); }
      }
      private void grdItemsLimiteCreditoCli_CellFormatting(object sender, CellFormattingEventArgs e)
      {
         try
         {
            if (e.CellElement is GridCommandCellElement)
            {
               if (e.Column.Name.Equals("New"))
               {
                  RadButtonElement bte = (RadButtonElement)e.CellElement.Children[0];
                  if (bte.Image == null)
                  {
                     bte.TextImageRelation = TextImageRelation.Overlay;
                     bte.DisplayStyle = DisplayStyle.Image;
                     bte.ImageAlignment = ContentAlignment.MiddleCenter;
                     bte.Image = Resources.add16x16;
                     bte.ToolTipText = @"Nuevo Registro";
                     bte.AutoSize = true;
                  }
               }
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
               if (e.Column.Name.Equals("History"))
               {
                  RadButtonElement bte = (RadButtonElement)e.CellElement.Children[0];
                  if (bte.Image == null)
                  {
                     bte.TextImageRelation = TextImageRelation.Overlay;
                     bte.DisplayStyle = DisplayStyle.Image;
                     bte.ImageAlignment = ContentAlignment.MiddleCenter;
                     bte.Image = Resources.history2_16x16;
                     bte.ToolTipText = @"Historial";
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
      private void grdItemsLimiteCreditoCli_CommandCellClick(object sender, EventArgs e)
      {
         try
         {
            if (sender is Telerik.WinControls.UI.GridCommandCellElement)
            {
               switch ((((Telerik.WinControls.UI.GridCommandCellElement)(sender)).CommandButton).TextElement.Text)
               {
                  case "Editar":
                     //si es cliente buscamos sus contactos
                     EditarLimiteCreditoCliente();
                     break;
                  case "Nuevo":
                     NuevoLimiteCreditoCliente();
                     break;
                  case "Historial":
                     HistorialLimiteCreditoCliente();
                     break;
               }
            }
         }
         catch (Exception)
         { }
      }
      public void ShowLimiteCreditoCliente()
      {
         try
         {
            BSItemsLimiteCreditoCliente.DataSource = Presenter.Item.ListEntidadLimiteCreditosCliente;
            grdItemsLimiteCreditoCli.DataSource = BSItemsLimiteCreditoCliente;
            BSItemsLimiteCreditoCliente.ResetBindings(true);
         }
         catch (Exception ex)
         { Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al agregar un contacto.", ex); }
      }
      #endregion

      #region [ Finanzas Proveedor ]

      #region Limites de Credito
      private void NuevoLimiteCreditoProveedor()
      {
         try
         {
            if (BSItemsLimiteCreditoProveedor.Current != null)
            {
               int posicion = BSItemsLimiteCreditoProveedor.Position;
               Entities.EntidadLimiteCredito LimCredProveedor = Presenter.NuevoLimiteCreditoProveedor((Entities.EntidadLimiteCredito)BSItemsLimiteCreditoProveedor.Current);
               if (LimCredProveedor != null)
               {
                  ((ObservableCollection<Entities.EntidadLimiteCredito>)BSItemsLimiteCreditoProveedor.DataSource)[posicion] = LimCredProveedor;
                  ShowLimiteCreditoProveedor();
               }
            }
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al crear el limite de credito", ex); }
      }
      private void EditarLimiteCreditoProveedor()
      {
         try
         {
            if (BSItemsLimiteCreditoProveedor.Current != null)
            {
               if (((Entities.EntidadLimiteCredito)BSItemsLimiteCreditoProveedor.Current).ENLI_Codigo != 0)
               {
                  int posicion = BSItemsLimiteCreditoProveedor.Position;
                  Entities.EntidadLimiteCredito LimCredProveedor = Presenter.EditarLimiteCreditoProveedor((Entities.EntidadLimiteCredito)BSItemsLimiteCreditoProveedor.Current);
                  if (LimCredProveedor != null)
                  {
                     ((ObservableCollection<Entities.EntidadLimiteCredito>)BSItemsLimiteCreditoProveedor.DataSource)[posicion] = LimCredProveedor;
                     ShowLimiteCreditoProveedor();
                  }
               }
               else
               {
                  Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Presenter.Title, "No puede editar un registro que aun no fue creado");
               }
            }
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al editar el limite de credito", ex); }
      }
      private void HistorialLimiteCreditoProveedor()
      {
         try
         {
            Presenter.HistorialLimiteCreditoProveedor((Entities.EntidadLimiteCredito)BSItemsLimiteCreditoProveedor.Current);
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al mostrar el hisotorial del limite de credito", ex); }
      }
      private void BloqueoUsuarioFinanzasProveedor()
      {
         try
         {
            txtENTC_UsrBloqueoProveedor.Text = Presenter.Session.UserName;
            dtpENTC_FecBloqueoProveedor.NSFecha = Presenter.Client.GetFecha();
         }
         catch (Exception ex)
         { Dialogos.MostrarMensajeError(Presenter.Title, "Ocurrio un error bloqueando el Usuario en operaciones financieras del cliente", ex); }
      }
      private void FormatDataGridLimiteCreditoProveedor()
      {
         try
         {
            Telerik.WinControls.UI.Localization.RadGridLocalizationProvider.CurrentProvider = new Infrastructure.WinForms.Controls.MySpanishRadGridLocalizationProvider();
            this.grdItemsLimiteCreditoPro.Columns.Clear();
            this.grdItemsLimiteCreditoPro.AllowAddNewRow = false;

            GridViewCommandColumn commandColumn;
            commandColumn = new GridViewCommandColumn();
            commandColumn.Name = "New";
            commandColumn.HeaderText = "Nuevo";
            commandColumn.DefaultText = "Nuevo";
            commandColumn.UseDefaultText = true;
            this.grdItemsLimiteCreditoPro.Columns.Add(commandColumn);
            this.grdItemsLimiteCreditoPro.Columns["New"].AllowSort = false;
            this.grdItemsLimiteCreditoPro.Columns["New"].AllowFiltering = false;

            commandColumn = new GridViewCommandColumn();
            commandColumn.Name = "Edit";
            commandColumn.HeaderText = "Editar";
            commandColumn.DefaultText = "Editar";
            commandColumn.UseDefaultText = true;
            this.grdItemsLimiteCreditoPro.Columns.Add(commandColumn);
            this.grdItemsLimiteCreditoPro.Columns["Edit"].AllowSort = false;
            this.grdItemsLimiteCreditoPro.Columns["Edit"].AllowFiltering = false;

            commandColumn = new GridViewCommandColumn();
            commandColumn.Name = "History";
            commandColumn.HeaderText = "Historial";
            commandColumn.DefaultText = "Historial";
            commandColumn.UseDefaultText = true;
            this.grdItemsLimiteCreditoPro.Columns.Add(commandColumn);
            this.grdItemsLimiteCreditoPro.Columns["History"].AllowSort = false;
            this.grdItemsLimiteCreditoPro.Columns["History"].AllowFiltering = false;

            this.grdItemsLimiteCreditoPro.Columns.Add("TIPO_MND", "Moneda", "TIPO_MND");
            this.grdItemsLimiteCreditoPro.Columns["TIPO_MND"].Width = 80;

            this.grdItemsLimiteCreditoPro.Columns.Add("ENLI_Monto", "Monto", "ENLI_Monto");
            this.grdItemsLimiteCreditoPro.Columns["ENLI_Monto"].Width = 80;
            this.grdItemsLimiteCreditoPro.Columns["ENLI_Monto"].FormatString = "{0:#,###,###.00}";
            this.grdItemsLimiteCreditoPro.Columns["ENLI_Monto"].TextAlignment = ContentAlignment.MiddleRight;
            //GridViewDecimalColumn ENLI_Monto = new GridViewDecimalColumn();
            //ENLI_Monto.Name = "ENLI_Monto";
            //ENLI_Monto.HeaderText = "Monto";
            //ENLI_Monto.FieldName = "ENLI_Monto";
            //ENLI_Monto.DecimalPlaces = 2;
            //ENLI_Monto.Maximum = 99999999;
            //ENLI_Monto.Minimum = 0;
            //ENLI_Monto.ThousandsSeparator = true;
            //grdItemsLimiteCreditoPro.MasterTemplate.Columns.Add(ENLI_Monto);
            //grdItemsLimiteCreditoPro.Columns["ENLI_Monto"].Width = 90;
            //grdItemsLimiteCreditoPro.Columns["ENLI_Monto"].TextAlignment = ContentAlignment.MiddleRight;
            //grdItemsLimiteCreditoPro.Columns["ENLI_Monto"].ReadOnly = true;

            this.grdItemsLimiteCreditoPro.Columns.Add("ENLI_FecInicio", "Fecha Inicio", "ENLI_FecInicio");
            this.grdItemsLimiteCreditoPro.Columns["ENLI_FecInicio"].Width = 80;
            this.grdItemsLimiteCreditoPro.Columns["ENLI_FecInicio"].FormatString = "{0:dd/MM/yyyy}";
            this.grdItemsLimiteCreditoPro.Columns.Add("ENLI_FecVencimiento", "Fecha Vencimiento", "ENLI_FecVencimiento");
            this.grdItemsLimiteCreditoPro.Columns["ENLI_FecVencimiento"].Width = 100;
            this.grdItemsLimiteCreditoPro.Columns["ENLI_FecVencimiento"].FormatString = "{0:dd/MM/yyyy}";

            this.grdItemsLimiteCreditoPro.Columns.Add("ENLI_Notas", "Notas", "ENLI_Notas");
            this.grdItemsLimiteCreditoPro.Columns["ENLI_Notas"].Width = 200;
            //this.grdItemsLimiteCreditoPro.Columns.Add("ENLI_Codigo", "Código", "ENLI_Codigo");
            //this.grdItemsLimiteCreditoPro.Columns["ENLI_Codigo"].Width = 50;

            /* Propiedades Finales */
            //grdItemsLimiteCreditoCli.BestFitColumns();

            grdItemsLimiteCreditoPro.ReadOnly = true;
            grdItemsLimiteCreditoPro.ShowFilteringRow = false;
            grdItemsLimiteCreditoPro.EnableFiltering = false;
            grdItemsLimiteCreditoPro.MasterTemplate.EnableFiltering = false;
            grdItemsLimiteCreditoPro.EnableGrouping = false;
            grdItemsLimiteCreditoPro.MasterTemplate.EnableGrouping = false;
            grdItemsLimiteCreditoPro.EnableSorting = false;
            grdItemsLimiteCreditoPro.MasterTemplate.EnableCustomSorting = false;

         }
         catch (Exception ex)
         { Dialogos.MostrarMensajeError(Presenter.Title, Mensajes.FormatDataGridView, ex); }
      }
      private void grdItemsLimiteCreditoPro_CellFormatting(object sender, CellFormattingEventArgs e)
      {
         try
         {
            if (e.CellElement is GridCommandCellElement)
            {
               if (e.Column.Name.Equals("New"))
               {
                  RadButtonElement bte = (RadButtonElement)e.CellElement.Children[0];
                  if (bte.Image == null)
                  {
                     bte.TextImageRelation = TextImageRelation.Overlay;
                     bte.DisplayStyle = DisplayStyle.Image;
                     bte.ImageAlignment = ContentAlignment.MiddleCenter;
                     bte.Image = Resources.add16x16;
                     bte.ToolTipText = @"Nuevo Registro";
                     bte.AutoSize = true;
                  }
               }
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
               if (e.Column.Name.Equals("History"))
               {
                  RadButtonElement bte = (RadButtonElement)e.CellElement.Children[0];
                  if (bte.Image == null)
                  {
                     bte.TextImageRelation = TextImageRelation.Overlay;
                     bte.DisplayStyle = DisplayStyle.Image;
                     bte.ImageAlignment = ContentAlignment.MiddleCenter;
                     bte.Image = Resources.history2_16x16;
                     bte.ToolTipText = @"Historial";
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
      private void grdItemsLimiteCreditoPro_CommandCellClick(object sender, EventArgs e)
      {
         try
         {
            if (sender is Telerik.WinControls.UI.GridCommandCellElement)
            {
               switch ((((Telerik.WinControls.UI.GridCommandCellElement)(sender)).CommandButton).TextElement.Text)
               {
                  case "Editar":
                     EditarLimiteCreditoProveedor();
                     break;
                  case "Nuevo":
                     NuevoLimiteCreditoProveedor();
                     break;
                  case "Historial":
                     HistorialLimiteCreditoProveedor();
                     break;
               }
            }
         }
         catch (Exception)
         { }
      }
      public void ShowLimiteCreditoProveedor()
      {
         try
         {
            BSItemsLimiteCreditoProveedor.DataSource = Presenter.Item.ListEntidadLimiteCreditosProveedor;
            grdItemsLimiteCreditoPro.DataSource = BSItemsLimiteCreditoProveedor;
            BSItemsLimiteCreditoProveedor.ResetBindings(true);
         }
         catch (Exception ex)
         {
            Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al agregar un contacto.", ex);
         }
      }
      #endregion

      #region Cuentas Bancarias
      private void NuevoEntidadCuentaBancaria()
      {
         try
         {
            Presenter.NuevoEntidadCuentaBancaria();
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al crear la Cuenta Bancaria", ex); }
      }
      private void EditarEntidadCuentaBancaria()
      {
         try
         {
            if (BSItemsEntidadCuentaBancaria.Current != null)
            {
               int posicion = BSItemsEntidadCuentaBancaria.Position;
               Entities.EntidadCuentaBancaria _ecbancaria = Presenter.EditarEntidadCuentaBancaria((Entities.EntidadCuentaBancaria)BSItemsEntidadCuentaBancaria.Current);
               if (_ecbancaria != null)
               {
                  ((ObservableCollection<EntidadCuentaBancaria>)(BSItemsEntidadCuentaBancaria.DataSource))[posicion] = _ecbancaria;
                  ShowEntidadCuentaBancaria();
               }
            }
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al editar la Cuenta Bancaria", ex); }
      }
      private void EliminarEntidadCuentaBancaria()
      {
         try
         {
            Presenter.EliminarEntidadCuentaBancaria((Entities.EntidadCuentaBancaria)BSItemsEntidadCuentaBancaria.Current);
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al elimianr la Cuenta Bancaria", ex); }
      }
      private void FormatDataGridEntidadCuentasBancarias()
      {
         try
         {
            Telerik.WinControls.UI.Localization.RadGridLocalizationProvider.CurrentProvider = new Infrastructure.WinForms.Controls.MySpanishRadGridLocalizationProvider();
            this.grdItemsEntidadCuentaBancaria.Columns.Clear();
            this.grdItemsEntidadCuentaBancaria.AllowAddNewRow = false;

            GridViewCommandColumn commandColumn;
            //commandColumn = new GridViewCommandColumn();
            //commandColumn.Name = "New";
            //commandColumn.HeaderText = "Nuevo";
            //commandColumn.DefaultText = "Nuevo";
            //commandColumn.UseDefaultText = true;
            //this.grdItemsEntidadCuentaBancaria.Columns.Add(commandColumn);
            //this.grdItemsEntidadCuentaBancaria.Columns["New"].AllowSort = false;
            //this.grdItemsEntidadCuentaBancaria.Columns["New"].AllowFiltering = false;

            commandColumn = new GridViewCommandColumn();
            commandColumn.Name = "Edit";
            commandColumn.HeaderText = "Editar";
            commandColumn.DefaultText = "Editar";
            commandColumn.UseDefaultText = true;
            this.grdItemsEntidadCuentaBancaria.Columns.Add(commandColumn);
            this.grdItemsEntidadCuentaBancaria.Columns["Edit"].AllowSort = false;
            this.grdItemsEntidadCuentaBancaria.Columns["Edit"].AllowFiltering = false;

            commandColumn = new GridViewCommandColumn();
            commandColumn.Name = "Delete";
            commandColumn.HeaderText = "Eliminar";
            commandColumn.DefaultText = "Eliminar";
            commandColumn.UseDefaultText = true;
            this.grdItemsEntidadCuentaBancaria.Columns.Add(commandColumn);
            this.grdItemsEntidadCuentaBancaria.Columns["Delete"].AllowSort = false;
            this.grdItemsEntidadCuentaBancaria.Columns["Delete"].AllowFiltering = false;

            this.grdItemsEntidadCuentaBancaria.Columns.Add("TIPO_BCO", "Banco", "TIPO_BCO");
            this.grdItemsEntidadCuentaBancaria.Columns["TIPO_BCO"].Width = 150;

            this.grdItemsEntidadCuentaBancaria.Columns.Add("TipoCuenta", "Tipo de Cuenta", "TipoCuenta");
            this.grdItemsEntidadCuentaBancaria.Columns["TipoCuenta"].Width = 150;
            this.grdItemsEntidadCuentaBancaria.Columns.Add("ENCB_NroCuentaSol", "Cuenta en S/.", "ENCB_NroCuentaSol");
            this.grdItemsEntidadCuentaBancaria.Columns["ENCB_NroCuentaSol"].Width = 130;
            this.grdItemsEntidadCuentaBancaria.Columns.Add("ENCB_NroCuentaDol", "Cuenta en US$. ", "ENCB_NroCuentaDol");
            this.grdItemsEntidadCuentaBancaria.Columns["ENCB_NroCuentaDol"].Width = 130;

            /* Propiedades Finales */
            //grdItemsLimiteCreditoCli.BestFitColumns();

            grdItemsEntidadCuentaBancaria.ReadOnly = true;
            grdItemsEntidadCuentaBancaria.ShowFilteringRow = false;
            grdItemsEntidadCuentaBancaria.EnableFiltering = false;
            grdItemsEntidadCuentaBancaria.MasterTemplate.EnableFiltering = false;
            grdItemsEntidadCuentaBancaria.EnableGrouping = false;
            grdItemsEntidadCuentaBancaria.MasterTemplate.EnableGrouping = false;
            grdItemsEntidadCuentaBancaria.EnableSorting = false;
            grdItemsEntidadCuentaBancaria.MasterTemplate.EnableCustomSorting = false;

         }
         catch (Exception ex)
         { Dialogos.MostrarMensajeError(Presenter.Title, Mensajes.FormatDataGridView, ex); }
      }
      private void grdItemsEntidadCuentaBancaria_CellFormatting(object sender, CellFormattingEventArgs e)
      {
         try
         {
            if (e.CellElement is GridCommandCellElement)
            {
               //if (e.Column.Name.Equals("New"))
               //{
               //   RadButtonElement bte = (RadButtonElement)e.CellElement.Children[0];
               //   if (bte.Image == null)
               //   {
               //      bte.TextImageRelation = TextImageRelation.Overlay;
               //      bte.DisplayStyle = DisplayStyle.Image;
               //      bte.ImageAlignment = ContentAlignment.MiddleCenter;
               //      bte.Image = Resources.add16x16;
               //      bte.ToolTipText = @"Nuevo Registro";
               //      bte.AutoSize = true;
               //   }
               //}
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
      private void grdItemsEntidadCuentaBancaria_CommandCellClick(object sender, EventArgs e)
      {
         try
         {
            if (sender is Telerik.WinControls.UI.GridCommandCellElement)
            {
               switch ((((Telerik.WinControls.UI.GridCommandCellElement)(sender)).CommandButton).TextElement.Text)
               {
                  case "Editar":
                     EditarEntidadCuentaBancaria();
                     break;
                  case "Nuevo":
                     NuevoEntidadCuentaBancaria();
                     break;
                  case "Eliminar":
                     EliminarEntidadCuentaBancaria();
                     break;
               }
            }
         }
         catch (Exception)
         { }
      }
      public void ShowEntidadCuentaBancaria()
      {
         try
         {
            BSItemsEntidadCuentaBancaria.DataSource = Presenter.Item.ListEntidadCuentaBancarias;
            grdItemsEntidadCuentaBancaria.DataSource = BSItemsEntidadCuentaBancaria;
            BSItemsEntidadCuentaBancaria.ResetBindings(true);
         }
         catch (Exception ex)
         {
            Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al agregar un contacto.", ex);
         }
      }
      private void btnNuevoEntidadBancaria_Click(object sender, EventArgs e)
      { NuevoEntidadCuentaBancaria(); }
      #endregion

      #endregion

      #endregion

      #region [ Servicios Cliente ]

      #region [ Metodos ]
      private void AgregarServicio()
      {
         try
         {
            Presenter.AgregarServicio();
         }
         catch (Exception ex)
         { Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al momento de agregar un servicio", ex); }
      }
      private void EditarServicio()
      {
         try
         {
            if (BSItemsServicios.Current != null)
            {
               int _posicion = BSItemsServicios.Position;
               Entities.Entidad_Servicio _entidadServicios = Presenter.EditarServicio((Entities.Entidad_Servicio)(BSItemsServicios.Current));
               if (_entidadServicios != null)
               {
                  ((ObservableCollection<Entities.Entidad_Servicio>)BSItemsServicios.DataSource)[_posicion] = _entidadServicios;
                  ShowServicios();
               }
            }
         }
         catch (Exception ex)
         { Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al momento de Editar un relacionado", ex); }
      }
      private void EliminarServicio()
      {
         try
         {
            if (BSItemsServicios.Current != null)
            {
               Entities.Entidad_Servicio _entidadServicio = (Entities.Entidad_Servicio)(BSItemsServicios.Current);
               if (
                  Infrastructure.WinForms.Controls.Dialogos.MostrarMensajePregunta(Presenter.Title,
                     String.Format("¿Desea eliminar el servicio?")
                     , Infrastructure.WinForms.Controls.Dialogos.LabelBoton.Si_No) ==
                  System.Windows.Forms.DialogResult.Yes)
               {
                  BSItemsServicios.Remove(_entidadServicio);
                  _entidadServicio.Instance = InstanceEntity.Deleted;
                  Presenter.QuitarServicio(_entidadServicio);
               }
            }
         }
         catch (Exception ex)
         { Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al momento de eliminar un servicio", ex); }
      }
      public void ShowServicios()
      {
         try
         {
            BSItemsServicios.DataSource = Presenter.Item.ListServicio;
            grdItemsServiciosCliente.DataSource = BSItemsServicios;
            navItemsServiciosCliente.BindingSource = BSItemsServicios;
            BSItemsServicios.ResetBindings(true);
         }
         catch (Exception ex)
         { Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al agregar un servicio.", ex); }
      }
      private void SeleccionarItemServicio()
      {
         try
         {
            if (Presenter != null)
            {
               //if (BSItemsServicios != null && BSItemsServicios.Current != null && BSItemsServicios.Current is Entidad_Servicio)
               //{ Presenter.itemEntidadServicio = ((Entidad_Servicio)BSItemsServicios.Current); }
               //else
               //{ Presenter.itemEntidadServicio = null; }
            }
         }
         catch (Exception ex)
         { Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al seleccionar el item.", ex); }
      }
      private void FormatDataGridServicios()
      {
         try
         {
            Telerik.WinControls.UI.Localization.RadGridLocalizationProvider.CurrentProvider = new Infrastructure.WinForms.Controls.MySpanishRadGridLocalizationProvider();
            this.grdItemsServiciosCliente.Columns.Clear();
            this.grdItemsServiciosCliente.AllowAddNewRow = false;
            this.grdItemsServiciosCliente.AllowEditRow = true;
            this.grdItemsServiciosCliente.ReadOnly = false;

            Telerik.WinControls.UI.GridViewCommandColumn commandColumn;
            commandColumn = new Telerik.WinControls.UI.GridViewCommandColumn();
            commandColumn.Name = "Edit";
            commandColumn.HeaderText = "Editar";
            commandColumn.DefaultText = "Editar";
            commandColumn.UseDefaultText = true;
            this.grdItemsServiciosCliente.Columns.Add(commandColumn);
            this.grdItemsServiciosCliente.Columns["Edit"].AllowSort = false;
            this.grdItemsServiciosCliente.Columns["Edit"].AllowFiltering = false;
            commandColumn = new Telerik.WinControls.UI.GridViewCommandColumn();
            commandColumn.Name = "Delete";
            commandColumn.HeaderText = "Eliminar";
            commandColumn.DefaultText = "Eliminar";
            commandColumn.UseDefaultText = true;
            this.grdItemsServiciosCliente.Columns.Add(commandColumn);
            this.grdItemsServiciosCliente.Columns["Delete"].AllowSort = false;
            this.grdItemsServiciosCliente.Columns["Delete"].AllowFiltering = false;


            grdItemsServiciosCliente.Columns.Add("SERV_Nombre", "Servicio", "SERV_Nombre");
            grdItemsServiciosCliente.Columns.Add("CONS_DescLNG", "Línea", "CONS_DescLNG");
            grdItemsServiciosCliente.Columns.Add("CONS_DescRGM", "Régimen", "CONS_DescRGM");
            grdItemsServiciosCliente.Columns.Add("CONS_DescVIA", "Vía", "CONS_DescVIA");
            grdItemsServiciosCliente.Columns.Add("TIPO_DescMND", "Moneda", "TIPO_DescMND");
            grdItemsServiciosCliente.Columns.Add("ESER_Valor", "Valor", "ESER_Valor");
            grdItemsServiciosCliente.Columns.Add("CONS_DescBAS", "Aplicado", "CONS_DescBAS");

            if (Presenter.tipe_Codigo != Delfin.Controls.EntidadClear.TIPE_Agente)
            {
               GridViewCheckBoxColumn checkboxColum;
               checkboxColum = new GridViewCheckBoxColumn();
               checkboxColum.Name = "ESER_Exonerado";
               checkboxColum.HeaderText = "Exonerado";
               checkboxColum.FieldName = "ESER_Exonerado";
               grdItemsServiciosCliente.Columns.Add(checkboxColum);
               grdItemsServiciosCliente.Columns["ESER_Exonerado"].Width = 90;
            }

            Infrastructure.WinForms.Controls.GridAutoFit.Fit(grdItemsServiciosCliente);

            this.grdItemsServiciosCliente.ShowFilteringRow = false;
            this.grdItemsServiciosCliente.EnableFiltering = false;
            this.grdItemsServiciosCliente.MasterTemplate.EnableFiltering = false;
            this.grdItemsServiciosCliente.EnableGrouping = false;
            this.grdItemsServiciosCliente.MasterTemplate.EnableGrouping = false;
            this.grdItemsServiciosCliente.EnableSorting = false;
            this.grdItemsServiciosCliente.MasterTemplate.EnableCustomSorting = false;

            this.grdItemsServiciosCliente.ReadOnly = true;
            this.grdItemsServiciosCliente.AllowEditRow = true;
         }
         catch (Exception ex)
         { Dialogos.MostrarMensajeError(Presenter.Title, Mensajes.FormatDataGridView, ex); }
      }
      #endregion

      #region [ Eventos ]
      private void grdItemsServiciosCliente_CommandCellClick(object sender, EventArgs e)
      {
         try
         {
            if (sender is Telerik.WinControls.UI.GridCommandCellElement)
            {
               switch ((((Telerik.WinControls.UI.GridCommandCellElement)(sender)).CommandButton).TextElement.Text)
               {
                  case "Editar":
                     SeleccionarItemServicio();
                     EditarServicio();
                     break;
                  case "Eliminar":
                     EliminarServicio();
                     break;
               }
            }
         }
         catch (Exception ex)
         { Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al seleccionar el servicio.", ex); }
      }
      private void grdItemsServiciosCliente_CellFormatting(object sender, CellFormattingEventArgs e)
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
      private void BSItemsServicios_CurrentItemChanged(object sender, EventArgs e)
      { SeleccionarItemServicio(); }
      private void tsbtnNuevoServicio_Click(object sender, EventArgs e)
      { AgregarServicio(); }
      #endregion

      #endregion

      #region [ Deposito Temporal ]

      #region [ Metodos ]
      private void FormatDataGridDepTemporal()
      {
         try
         {
            RadGridLocalizationProvider.CurrentProvider = new MySpanishRadGridLocalizationProvider();
            grdDepTemporalEntidad.Columns.Clear();
            grdDepTemporalEntidad.EnableHotTracking = true;
            grdDepTemporalEntidad.EnableAlternatingRowColor = false;
            grdDepTemporalEntidad.ShowFilteringRow = false;
            grdDepTemporalEntidad.ShowHeaderCellButtons = false;
            grdDepTemporalEntidad.TableElement.RowSpacing = 0;
            grdDepTemporalEntidad.TableElement.CellSpacing = 0;
            grdDepTemporalEntidad.EnableFiltering = false;
            grdDepTemporalEntidad.MasterTemplate.EnableFiltering = false;
            grdDepTemporalEntidad.AllowColumnHeaderContextMenu = false;
            grdDepTemporalEntidad.AllowCellContextMenu = false;
            grdDepTemporalEntidad.AllowAddNewRow = false;
            grdDepTemporalEntidad.AllowDeleteRow = false;
            grdDepTemporalEntidad.AllowEditRow = true;
            grdDepTemporalEntidad.AutoGenerateColumns = false;
            grdDepTemporalEntidad.AllowMultiColumnSorting = false;
            grdDepTemporalEntidad.AllowRowResize = false;
            grdDepTemporalEntidad.AllowColumnResize = true;
            grdDepTemporalEntidad.ShowGroupPanel = false;

            GridViewCheckBoxColumn chkFacturar = new GridViewCheckBoxColumn();
            chkFacturar.Name = "Agregar";
            chkFacturar.HeaderText = @"Agregar";
            chkFacturar.FieldName = "Agregar";
            grdDepTemporalEntidad.Columns.Add(chkFacturar);
            grdDepTemporalEntidad.Columns["Agregar"].Width = 50;
            grdDepTemporalEntidad.Columns["Agregar"].ReadOnly = false;

            grdDepTemporalEntidad.Columns.Add("ENTC_Codigo", "Código", "ENTC_Codigo");
            grdDepTemporalEntidad.Columns.Add("ENTC_NomCompleto", "Descripción", "ENTC_NomCompleto");
            grdDepTemporalEntidad.Columns["ENTC_NomCompleto"].Width = 600;
            grdDepTemporalEntidad.Columns["ENTC_NomCompleto"].TextAlignment = ContentAlignment.MiddleLeft;
            grdDepTemporalEntidad.Columns["ENTC_NomCompleto"].ReadOnly = true;
         }
         catch (Exception ex)
         { Dialogos.MostrarMensajeError(Presenter.Title, Mensajes.FormatDataGridView, ex); }
      }
      public void ShowItemsDepTemporal()
      {
         try
         {
            BSItemsDepTemporal.DataSource = Presenter.ItemsDepTemporalEntidad.Where(serv => serv.Instance != InstanceEntity.Deleted).ToObservableCollection();
            grdDepTemporalEntidad.DataSource = BSItemsDepTemporal;
            navItemsServiciosCliente.BindingSource = BSItemsDepTemporal;
            BSItemsDepTemporal.ResetBindings(true);
         }
         catch (Exception ex)
         { Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al agregar un servicio.", ex); }
      }

      private void SeleccionarItemDepTemporal()
      {
         try
         {
            if (Presenter != null)
            {
               if (BSItemsDepTemporal != null && BSItemsDepTemporal.Current != null && BSItemsDepTemporal.Current is Entidad_Relacionados)
               { Presenter.ItemDepTemporalEntidad = ((Entidad_Relacionados)BSItemsDepTemporal.Current); }
               else
               { Presenter.ItemDepTemporalEntidad = null; }
            }
         }
         catch (Exception ex)
         { Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al seleccionar el item.", ex); }
      }
      #endregion

      #region [ Eventos ]
      private void grdDepTemporalEntidad_ValueChanged(object sender, EventArgs e)
      {
         try
         {
            if (!(grdDepTemporalEntidad.ActiveEditor is RadCheckBoxEditor)) return;
            grdDepTemporalEntidad.EndEdit();
            grdDepTemporalEntidad.EndUpdate();
            //BSItemsServicios.EndEdit();
            Presenter.ItemsDepTemporalEntidad = (ObservableCollection<Entidad_Relacionados>)BSItemsDepTemporal.DataSource;
            //Presenter.MarcarDepTemporal();
         }
         catch (Exception)
         { }

      }
      private void BSItemsDepTemporal_CurrentItemChanged(object sender, EventArgs e)
      {
         SeleccionarItemDepTemporal();
      }
      #endregion
      #endregion

      #region [ Eventos ]
      private void btnGuardar_Click(object sender, EventArgs e)
      {
         try
         {
             Presenter.Item.ENTC_EMail = txtENTC_EMail.Text;
             Presenter.Item.ENTC_EMail2 = txtENTC_EMail2.Text;
             Presenter.Item.ENTC_EmailReceptorFE = txtENTC_EMailFE.Text;
            if (Presenter.Guardar())
            {
               FormClosing -= MView_FormClosing;
               errorProvider1.Dispose();
               //Presenter.Actualizar(false );
               DialogResult = DialogResult.OK;
               Close();
            }
         }
         catch (Exception)
         { }
      }
      private void btnSalir_Click(object sender, EventArgs e)
      {
         try
         {
            FormClosing -= MView_FormClosing;
            errorProvider1.Dispose();
            if (FormValidateChanges.verificarCambioFormulario(this, HashFormulario))
            {
               if (Presenter.GuardarCambios() != DialogResult.Cancel)
               {
                  DialogResult = DialogResult.Cancel;
                  Close();
               }
               else
               { FormClosing += MView_FormClosing; }
            }
            else
            {
               DialogResult = DialogResult.Cancel;
               Close();
            }
            Closing = true;
         }
         catch (Exception ex)
         { Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al cerrar el formulario.", ex); }
      }
      private void MView_FormClosing(object sender, FormClosingEventArgs e)
      {
         try
         {
            if (Closing != true)
            {
               FormClosing -= MView_FormClosing;
               if (FormValidateChanges.verificarCambioFormulario(this, HashFormulario))
               {
                  if (Presenter.GuardarCambios() == DialogResult.Cancel)
                  {
                     e.Cancel = true;
                     FormClosing += new FormClosingEventHandler(MView_FormClosing);
                  }
               }
            }
            else
            { Closing = false; e.Cancel = true; }
         }
         catch (Exception ex)
         { Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al cerrar el formulario.", ex); }
      }
      private void optENTC_TipEntJ_CheckedChanged(object sender, EventArgs e)
      {
         visualizaNatural_Juridica();
         //tblJuridica.Visible = optENTC_TipEntJ.Checked;
         //tbllNatural.Visible = optENTC_TipEntN.Checked;
      }
      private void btnAgregar_C_IMPO_Click(object sender, EventArgs e)
      { Contacto("001", true); }
      private void btnEditar_C_IMPO_Click(object sender, EventArgs e)
      { Contacto("001", false); }
      private void btnAgregar_C_EXPO_Click(object sender, EventArgs e)
      { Contacto("002", true); }
      private void btnEditar_C_EXPO_Click(object sender, EventArgs e)
      { Contacto("002", false); }
      private void cmbTIPO_CodTDI_Leave(object sender, EventArgs e)
      { ValidarDocIdentidad(); }
      private void txtENTC_DocIden_Leave(object sender, EventArgs e)
      { ValidarDocIdentidad(); }
      private void cmbTIPO_CodTDI_SelectedIndexChanged(object sender, EventArgs e)
      {
         try
         {
            if (cmbTIPO_CodTDI.TiposSelectedItem != null)
            {
               if (cmbTIPO_CodTDI.TiposSelectedItem.TIPO_CodTipo == Presenter.TIPO_CodTDI)
               {
                  txtENTC_DocIden.Visible = false;
                  lblENTC_DocIden.Visible = false;
                  Presenter.Item.ValidarDocIden = false;
               }
               else
               {
                  txtENTC_DocIden.Visible = true;
                  lblENTC_DocIden.Visible = true;
                  Presenter.Item.ValidarDocIden = true;
               }
            }
         }
         catch (Exception)
         { }
      }
      private void chkENTC_BloqueoFinanzasCliente_CheckedChanged(object sender, EventArgs e)
      { BloqueoUsuarioFinanzasCliente(); }
      private void chkENTC_BloqueoFinanzasProveedor_CheckedChanged(object sender, EventArgs e)
      { BloqueoUsuarioFinanzasProveedor(); }
      private void btn_TxtENTC_Email_Click(object sender, EventArgs e)
      {
         try
         {
            String _textoCorreo = String.Empty;
            _textoCorreo = txtENTC_EMail.Text != null ? txtENTC_EMail.Text : "";
            MAN009TView _viewENTC_Correos = new MAN009TView("Correos", _textoCorreo, 500);
            if (_viewENTC_Correos.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            { txtENTC_EMail.Text = _viewENTC_Correos.Texto; }
            _viewENTC_Correos.Dispose();
            _viewENTC_Correos = null;
         }
         catch (Exception ex)
         { throw ex; }
      }
      #endregion

      #region [ Relacionados ]

      #region [ Metodos ]
      private void grdItemsRelacionados_CommandCellClick(object sender, EventArgs e)
      {
         try
         {
            if (sender is Telerik.WinControls.UI.GridCommandCellElement)
            {
               switch ((((Telerik.WinControls.UI.GridCommandCellElement)(sender)).CommandButton).TextElement.Text)
               {
                  case "Editar":
                     SeleccionarItemRelacionado();
                     EditarRelacionado();
                     break;
                  case "Eliminar":
                     EliminarRelacionado();
                     break;
               }
            }
         }
         catch (Exception)
         {

         }
      }
      private void grdItemsRelacionados_CellFormatting(object sender, CellFormattingEventArgs e)
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
      private void BSItemsRelacionados_CurrentItemChanged(object sender, EventArgs e)
      { SeleccionarItemRelacionado(); }
      /// <summary>
      /// CRISTHIAN JOSE APAZA ARHUATA
      /// AGREGAR CONTACTOS
      /// </summary>
      private void tsbtnNuevoRelacionado_Click(object sender, EventArgs e)
      { AgregarRelacionado(); }
      /// <summary>
      /// CRISTHIAN JOSE APAZA ARHUATA
      /// FORMA GRILLA CONTACTOS
      /// </summary>
      private void FormatGridRelacionados()
      {
         try
         {
            Telerik.WinControls.UI.Localization.RadGridLocalizationProvider.CurrentProvider = new Infrastructure.WinForms.Controls.MySpanishRadGridLocalizationProvider();
            this.grdItemsRelacionados.Columns.Clear();
            this.grdItemsRelacionados.AllowAddNewRow = false;
            this.grdItemsRelacionados.AllowEditRow = true;
            this.grdItemsRelacionados.ReadOnly = false;

            Telerik.WinControls.UI.GridViewCommandColumn commandColumn;
            commandColumn = new Telerik.WinControls.UI.GridViewCommandColumn();
            commandColumn.Name = "Edit";
            commandColumn.HeaderText = "Editar";
            commandColumn.DefaultText = "Editar";
            commandColumn.UseDefaultText = true;
            this.grdItemsRelacionados.Columns.Add(commandColumn);
            this.grdItemsRelacionados.Columns["Edit"].AllowSort = false;
            this.grdItemsRelacionados.Columns["Edit"].AllowFiltering = false;
            commandColumn = new Telerik.WinControls.UI.GridViewCommandColumn();
            commandColumn.Name = "Delete";
            commandColumn.HeaderText = "Eliminar";
            commandColumn.DefaultText = "Eliminar";
            commandColumn.UseDefaultText = true;
            this.grdItemsRelacionados.Columns.Add(commandColumn);
            this.grdItemsRelacionados.Columns["Delete"].AllowSort = false;
            this.grdItemsRelacionados.Columns["Delete"].AllowFiltering = false;

            grdItemsRelacionados.Columns.Add("RELA_TipoRelacion", "Tipo Relación", "RELA_TipoRelacion");
            grdItemsRelacionados.Columns.Add("CONS_RGM", "Régimen", "CONS_RGM");
            grdItemsRelacionados.Columns.Add("TIPE_Hijo", "Tipo Entidad", "TIPE_Hijo");
            grdItemsRelacionados.Columns.Add("ENTC_Codigo", "Codigo", "ENTC_Codigo");
            grdItemsRelacionados.Columns.Add("ENTC_DocIden", "Nro Documento", "ENTC_DocIden");
            grdItemsRelacionados.Columns.Add("ENTC_NomCompleto", "Razón Social / Nombres", "ENTC_NomCompleto");
            grdItemsRelacionados.Columns.Add("TIPO_TRF", "TRF", "TIPO_TRF");
            grdItemsRelacionados.Columns.Add("ENTC_EMail", "Email", "ENTC_EMail");
            grdItemsRelacionados.Columns.Add("ENTC_EmailReceptorFE", "EmailFE", "ENTC_EmailReceptorFE"); 
            grdItemsRelacionados.Columns.Add("AUDI_FecCrea", "Creación", "AUDI_FecCrea");
            grdItemsRelacionados.Columns.Add("AUDI_FecMod", "Actualización", "AUDI_FecMod");

            grdItemsRelacionados.Columns["AUDI_FecCrea"].FormatString = "{0:dd/MM/yyyy}";
            grdItemsRelacionados.Columns["AUDI_FecMod"].FormatString = "{0:dd/MM/yyyy}";

            //grdItemsRelacionados.BestFitColumns();
            Infrastructure.WinForms.Controls.GridAutoFit.Fit(grdItemsRelacionados);
            //grdItemsRelacionados.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;

            this.grdItemsRelacionados.ShowFilteringRow = false;
            this.grdItemsRelacionados.EnableFiltering = false;
            this.grdItemsRelacionados.MasterTemplate.EnableFiltering = false;
            this.grdItemsRelacionados.EnableGrouping = false;
            this.grdItemsRelacionados.MasterTemplate.EnableGrouping = false;
            this.grdItemsRelacionados.EnableSorting = false;
            this.grdItemsRelacionados.MasterTemplate.EnableCustomSorting = false;

            this.grdItemsRelacionados.ReadOnly = true;
            this.grdItemsRelacionados.AllowEditRow = true;
         }
         catch (Exception ex)
         { Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error cargar los contactos", ex); }
      }
      #endregion

      #region [Eventos]
      /// <summary>
      /// CRISTHIAN JOSE APAZA ARHUATA 
      /// LISTA DE CONTACTOS 
      /// </summary>
      private void AgregarRelacionado()
      {
         try
         {
            Presenter.AgregarRelacionado();
         }
         catch (Exception ex)
         { Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al momento de agregar un relacionado", ex); }
      }
      private void EditarRelacionado()
      {
         try
         {
            if (BSItemsRelacionados.Current != null)
            {
               int _posicion = BSItemsRelacionados.Position;
               Entities.Entidad _entidad = Presenter.EditarRelacionado((Entities.Entidad)(BSItemsRelacionados.Current));
               if (_entidad != null)
               {
                  ((ObservableCollection<Entities.Entidad>)BSItemsRelacionados.DataSource)[_posicion] = _entidad;
                  ShowRelacionados();
               }
            }
            //((Entities.Entidad)(BSItemsRelacionados.Current))=
         }
         catch (Exception ex)
         { Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al momento de Editar un relacionado", ex); }
      }
      private void EliminarRelacionado()
      {
         try
         {
            if (BSItemsRelacionados.Current != null)
            {
               Entities.Entidad _entidad = (Entities.Entidad)(BSItemsRelacionados.Current);
               if (
                  Infrastructure.WinForms.Controls.Dialogos.MostrarMensajePregunta(Presenter.Title,
                     String.Format("¿Desea eliminar el {0}: {1} seleccionado?", _entidad.RELA_TipoRelacion, _entidad.ENTC_NomCompleto)
                     , Infrastructure.WinForms.Controls.Dialogos.LabelBoton.Si_No) ==
                  System.Windows.Forms.DialogResult.Yes)
               {
                  BSItemsRelacionados.Remove(_entidad);
                  Presenter.QuitarRelacionado(_entidad);
               }
            }
         }
         catch (Exception ex)
         { Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al momento de eliminar un relacionado", ex); }
      }
      public void ShowRelacionados()
      {
         try
         {
            BSItemsRelacionados.DataSource = Presenter.Item.Relacionados;
            grdItemsRelacionados.DataSource = BSItemsRelacionados;
            //BSItemsEntContactos.DataSource = BSItemsEntContactos;
            BSItemsRelacionados.ResetBindings(true);
         }
         catch (Exception ex)
         { Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al agregar un contacto.", ex); }
      }
      private void SeleccionarItemRelacionado()
      {
         try
         {
            if (Presenter != null)
            {
               //if (BSItemsRelacionados != null && BSItemsRelacionados.Current != null && BSItemsRelacionados.Current is Entities.Entidad)
               //{ _itemContacto = ((Entities.Entidad)BSItemsRelacionados.Current); }
               //else
               //{ Presenter.Item.Relacionados = null; }
            }
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al seleccionar el item.", ex); }
      }
      #endregion

      #endregion

      #region [ Auditoria ]
      private void btnAuditoriaEntidad_Click(object sender, EventArgs e)
      {
         try
         {
            ObservableCollection<Infrastructure.Aspect.DataAccess.DataAccessFilterSQL> _filters = new ObservableCollection<Infrastructure.Aspect.DataAccess.DataAccessFilterSQL>();
            _filters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@pintENTC_Codigo", FilterValue = Presenter.Item.ENTC_Codigo, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.Int32, FilterSize = 4 });

            Delfin.Controls.AuditoriaView _auditoriaView = new Controls.AuditoriaView(Presenter.ContainerService, Delfin.Controls.TipoAuditoria.AUDI_Entidad, _filters);
            _auditoriaView.Show();
         }
         catch (Exception)
         { }
      }

      private void btnAuditoriaEntidad_Servicio_Click(object sender, EventArgs e)
      {
         try
         {
            ObservableCollection<Infrastructure.Aspect.DataAccess.DataAccessFilterSQL> _filters = new ObservableCollection<Infrastructure.Aspect.DataAccess.DataAccessFilterSQL>();
            _filters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@pintENTC_Codigo", FilterValue = Presenter.Item.ENTC_Codigo, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.Int32, FilterSize = 4 });

            Delfin.Controls.AuditoriaView _auditoriaView = new Controls.AuditoriaView(Presenter.ContainerService, Delfin.Controls.TipoAuditoria.AUDI_Entidad_Servicio, _filters);
            _auditoriaView.Show();
         }
         catch (Exception)
         { }
      }

      private void btnAuditoriaEntidad_Relacionados_Click(object sender, EventArgs e)
      {
         try
         {
            ObservableCollection<Infrastructure.Aspect.DataAccess.DataAccessFilterSQL> _filters = new ObservableCollection<Infrastructure.Aspect.DataAccess.DataAccessFilterSQL>();
            _filters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@pintENTC_Codigo", FilterValue = Presenter.Item.ENTC_Codigo, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.Int32, FilterSize = 4 });

            Delfin.Controls.AuditoriaView _auditoriaView = new Controls.AuditoriaView(Presenter.ContainerService, Delfin.Controls.TipoAuditoria.AUDI_Entidad_Relacionados, _filters);
            _auditoriaView.Show();
         }
         catch (Exception)
         { }
      }
      #endregion

      #region [ OcultarShipper ]
      private void chkENTC_OcultarShipper_CheckedChanged(object sender, EventArgs e)
      {
         try
         {
            if (Presenter.tipe_Codigo == EntidadClear.TIPE_Cliente)
            {
               if (Presenter.PARA_SERV_OCULTARSHIPPER != null)
               {
                  Int32 _SERV_Codigo;
                  if (Int32.TryParse(Presenter.PARA_SERV_OCULTARSHIPPER.PARA_Valor, out _SERV_Codigo) && chkENTC_OcultarShipper.Checked)
                  {
                     if (Presenter.Item.ListServicio.Where(eser => eser.SERV_Codigo == _SERV_Codigo).FirstOrDefault() == null)
                     {
                        Entities.Entidad_Servicio _itemEntidad_Servicio = new Entidad_Servicio();
                        //_itemEntidad_Servicio.ESER_Codigo = null;
                        Presenter.BuscarServicio(_SERV_Codigo);
                        _itemEntidad_Servicio.SERV_Codigo = Presenter.ServicioEntidad.SERV_Codigo;
                        _itemEntidad_Servicio.SERV_Nombre = Presenter.ServicioEntidad.SERV_Nombre_SPA;
                        _itemEntidad_Servicio.ESER_Valor = (Decimal)0.00;
                        //_itemEntidad_Servicio.ESER_Exonerado = null;
                        //_itemEntidad_Servicio.ENTC_Codigo = null;
                        //_itemEntidad_Servicio.ESER_Cantidad = null;
                        _itemEntidad_Servicio.TIPO_TabMnd = "MND";
                        _itemEntidad_Servicio.TIPO_CodMnd = null;
                        _itemEntidad_Servicio.CONS_TabBas = "BAS";
                        _itemEntidad_Servicio.CONS_CodBas = null;
                        _itemEntidad_Servicio.AUDI_UsrCrea = Presenter.Session.UserName;
                        _itemEntidad_Servicio.AUDI_FecCrea = Presenter.Session.Fecha;
                        _itemEntidad_Servicio.Instance = InstanceEntity.Added;

                        Presenter.Item.ListServicio.Add(_itemEntidad_Servicio);
                     }
                  }
                  else
                  {
                     while (Presenter.Item.ListServicio.Where(eser => eser.SERV_Codigo == _SERV_Codigo).FirstOrDefault() != null)
                     {
                        Entidad_Servicio _servicio = Presenter.Item.ListServicio.Where(eser => eser.SERV_Codigo == _SERV_Codigo).FirstOrDefault();
                        if (_servicio.Instance != InstanceEntity.Added)
                        {
                           _servicio.Instance = InstanceEntity.Deleted;
                           Presenter.Item.ListServicioDeleted.Add(_servicio.Clone() as Entidad_Servicio);
                        }
                        Presenter.Item.ListServicio.Remove(Presenter.Item.ListServicio.Where(eser => eser.SERV_Codigo == _SERV_Codigo).FirstOrDefault());
                     }
                  }

                  ShowServicios();
               }
            }
         }
         catch (Exception)
         { }
      }
      #endregion
   }
}