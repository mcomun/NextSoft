using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Infrastructure.Aspect.Collections;
using Infrastructure.WinForms.Controls;

namespace Delfin.Principal
{
    public partial class PAR000MView : Form, IPAR000MView
    {
        #region [ Variables ]

        #endregion

        #region [ Formulario ]
        public PAR000MView()
        {
            InitializeComponent();
            try
            {
                btnGuardar.Click += new EventHandler(btnGuardar_Click);
                btnSalir.Click += new EventHandler(btnSalir_Click);

                TipoRESG_Codigo.SelectedIndexChanged += TipoRESG_Codigo_SelectedIndexChanged;

                USRAPROBADORNIVEL1_JV.AyudaClick += USRAPROBADORNIVEL1_JV_AyudaClick;
                USRAPROBADORNIVEL1_JV.AyudaClean += USRAPROBADORNIVEL1_JV_AyudaClean;
                USRAPROBADORNIVEL2_GC.AyudaClick += USRAPROBADORNIVEL2_GC_AyudaClick;
                USRAPROBADORNIVEL2_GC.AyudaClean += USRAPROBADORNIVEL2_GC_AyudaClean;
                USRAPROBADORNIVEL3_GG.AyudaClick += USRAPROBADORNIVEL3_GG_AyudaClick;
                USRAPROBADORNIVEL3_GG.AyudaClean += USRAPROBADORNIVEL3_GG_AyudaClean;

                ayudaRTIPO_DTE.Click += ayudaRTIPO_DTE_AyudaClick;
                ayudaRTIPO_VEN.Click += ayudaRTIPO_VEN_AyudaClick;
                ayudaRTIPO_CON.Click += ayudaRTIPO_CON_AyudaClick;
                ayudaRTIPO_DVA.Click += ayudaRTIPO_DVA_AyudaClick;
                ayudaRTIPO_AGE.Click += ayudaRTIPO_AGE_AyudaClick;
                ayudaRTIPO_CSE.Click += ayudaRTIPO_CSE_AyudaClick;
                ayudaEEJECUTIVOS.Click += ayudaEEJECUTIVOS_Click;

                EEJECUTIVOS.ReadOnly = true;

                btnFAC_TDO.Click += btnFAC_TDO_Click;
                btnFAC_TDO_OP.Click += btnFAC_TDO_OP_Click;
                btnFAC_TDO_OV.Click += btnFAC_TDO_OV_Click;
                btnPREF_TDO_SLI.Click += btnPREF_TDO_SLI_Click;
                btnPREF_TDO_ILD.Click += btnPREF_TDO_ILD_Click;
                btnTIPO_TDO_NCS.Click += btnTIPO_TDO_NCS_Click;

                btnCTAS_MANDATO.Click += btnCTAS_MANDATO_Click;
                btnTDO_A_DIARIO.Click += btnTDO_A_DIARIO_Click;
                btnSERV_FL_AJUSTE_OP.Click += btnSERV_FL_AJUSTE_OP_Click;
                btnCCCT_TIPODOCUMENTO.Click += btnCCCT_TIPODOCUMENTO_Click;
                btnMOVI_CHQBLANCO.Click += btnMOVI_CHQBLANCO_Click;
                btnTIPO_MOV_DESDIF.Click += btnTIPO_MOV_DESDIF_Click;

                ayudaRUTA_ADU_IMPO_PROV.Click += ayudaRUTA_ADU_IMPO_PROV_Click;
                ayudaRUTA_ADUANA_DEMAS.Click += ayudaRUTA_ADUANA_DEMAS_Click;


                TR_RCOMPRAS.ReadOnly = true;
                TR_RVENTAS.ReadOnly = true;
                TR_RCAJA.ReadOnly = true;
                TR_DGENERAL.ReadOnly = true;
                TR_LPLANILLA.ReadOnly = true;
                TR_RCDSTATEMENT.ReadOnly = true;
                CCCT_TIPODOCUMENTO.ReadOnly = true;
                MOVI_CHQBLANCO.ReadOnly = true;
                TIPO_MOV_DESDIF.ReadOnly = true;

                TR_CIERR_001.MaxLength = 6;
                TR_CIERR_002.MaxLength = 6;
                TR_CIERR_003.MaxLength = 6;
                TR_CIERR_004.MaxLength = 6;
                TR_CIERR_005.MaxLength = 6;
                TR_CIERR_006.MaxLength = 6;
                TR_CIERR_007.MaxLength = 6;

                DET_DIASDETRACCION.Maximum = 100;
                DET_DIASDETRACCION.DecimalPlaces = 0;
                TIPO_TDO_OVDG.MaxLength = 3;

                this.FormClosing += new FormClosingEventHandler(MView_FormClosing);
            }
            catch (Exception ex)
            { throw ex; }
        }




        #endregion

        #region [ Propiedades ]
        public PAR000Presenter Presenter { get; set; }
        private bool Closing = false;
        private System.Collections.Hashtable HashFormulario { get; set; }
        public BindingSource BSItemsPlanillas { get; set; }
        #endregion

        #region [ IPAR000MView ]
        public void LoadView()
        {
            try
            {
                TipoRESG_Codigo.AddComboBoxItem(0, "Neutral");
                TipoRESG_Codigo.AddComboBoxItem(1, "Positivo");
                TipoRESG_Codigo.AddComboBoxItem(-1, "Negativo");
                TipoRESG_Codigo.LoadComboBox(null);

                /**************************** SERVICIOS ************************************/
                SERVADICIONAL.LoadControl(Presenter.ContainerService);
                SERVLOGISTICO.LoadControl(Presenter.ContainerService);
                SERVOTROS.LoadControl(Presenter.ContainerService);
                SERVTARJAS.LoadControl(Presenter.ContainerService);
                SERV_OCULTARSHIPPER.LoadControl(Presenter.ContainerService);
                SERVICIO_REEMBOLSO.LoadControl(Presenter.ContainerService);
                /***************************************************************************/

                /***************************** EVENTOS ***************************************************/
                RELEASEHBL.LoadControl(Presenter.ContainerService, "Tipos de Evento", "EVE", "< Seleccionar Evento >", ListSortDirection.Ascending);
                BLOQUEAROV.LoadControl(Presenter.ContainerService, "Tipos de Evento", "EVE", "< Seleccionar Evento >", ListSortDirection.Ascending);
                DESBLOQUEAROV.LoadControl(Presenter.ContainerService, "Tipos de Evento", "EVE", "< Seleccionar Evento >", ListSortDirection.Ascending);
                AGREGAREXCEPCIONOV.LoadControl(Presenter.ContainerService, "Tipos de Evento", "EVE", "< Seleccionar Evento >", ListSortDirection.Ascending);
                QUITAREXCEPCIONOV.LoadControl(Presenter.ContainerService, "Tipos de Evento", "EVE", "< Seleccionar Evento >", ListSortDirection.Ascending);
                OVDOCUMENTADA.LoadControl(Presenter.ContainerService, "Tipos de Evento", "EVE", "< Seleccionar Evento >", ListSortDirection.Ascending);
                DIRECCIONALINEA.LoadControl(Presenter.ContainerService, "Tipos de Evento", "EVE", "< Seleccionar Evento >", ListSortDirection.Ascending);
                EMAILALMACEN.LoadControl(Presenter.ContainerService, "Tipos de Evento", "EVE", "< Seleccionar Evento >", ListSortDirection.Ascending);
                DESGLOSEVoBo.LoadControl(Presenter.ContainerService, "Tipos de Evento", "EVE", "< Seleccionar Evento >", ListSortDirection.Ascending);
                CARTA_AVISOS.LoadControl(Presenter.ContainerService, "Tipos de Evento", "EVE", "< Seleccionar Evento >", ListSortDirection.Ascending);
                OVCERRADA.LoadControl(Presenter.ContainerService, "Tipos de Evento", "EVE", "< Seleccionar Evento >", ListSortDirection.Ascending);
                APERTURA_STATMENT.LoadControl(Presenter.ContainerService, "Tipos de Evento", "EVE", "< Seleccionar Evento >", ListSortDirection.Ascending);
                IMPRIMIRHBL.LoadControl(Presenter.ContainerService, "Tipos de Evento", "EVE", "< Seleccionar Evento >", ListSortDirection.Ascending);
                PRE_ALERTA.LoadControl(Presenter.ContainerService, "Tipos de Evento", "EVE", "< Seleccionar Evento >", ListSortDirection.Ascending);
                EVE_PREFACTURAR.LoadControl(Presenter.ContainerService, "Tipos de Evento", "EVE", "< Seleccionar Evento >", ListSortDirection.Ascending);
                EMITIR_STATEMENT.LoadControl(Presenter.ContainerService, "Tipos de Evento", "EVE", "< Seleccionar Evento >", ListSortDirection.Ascending);
                DEVOLUCION_MASTER.LoadControl(Presenter.ContainerService, "Tipos de Evento", "EVE", "< Seleccionar Evento >", ListSortDirection.Ascending);
                RECOJO_BLs.LoadControl(Presenter.ContainerService, "Tipos de Evento", "EVE", "< Seleccionar Evento >", ListSortDirection.Ascending);
                SERVICIO_TRANSMISION.LoadControl(Presenter.ContainerService, "Tipos de Evento", "EVE", "< Seleccionar Evento >", ListSortDirection.Ascending);
                EMISION_SDA.LoadControl(Presenter.ContainerService, "Tipos de Evento", "EVE", "< Seleccionar Evento >", ListSortDirection.Ascending);
                EMISION_TELEDESPACHO.LoadControl(Presenter.ContainerService, "Tipos de Evento", "EVE", "< Seleccionar Evento >", ListSortDirection.Ascending);
                EMISION_HBL.LoadControl(Presenter.ContainerService, "Tipos de Evento", "EVE", "< Seleccionar Evento >", ListSortDirection.Ascending);
                OV_ENTREGADA.LoadControl(Presenter.ContainerService, "Tipos de Evento", "EVE", "< Seleccionar Evento >", ListSortDirection.Ascending);
                /******************************************************************************************/

                /**************************** CODIGOS DE ENTIDAD *************************************/
                EMPRESA.ContainerService = Presenter.ContainerService;
                EAGENTE_CHINA.ContainerService = Presenter.ContainerService;
                EAGENTE_SHANGHAI.ContainerService = Presenter.ContainerService;
                CODIGO_TRAMARSA.ContainerService = Presenter.ContainerService;
                CODIGO_COSCO_PERU.ContainerService = Presenter.ContainerService;
                CODIGO_HAMBURG_SUD.ContainerService = Presenter.ContainerService;
                CODIGO_HAPAG_LLOYD.ContainerService = Presenter.ContainerService;
                EAGENTE_REEMBOLSO.ContainerService = Presenter.ContainerService;

                EMPRESA.TipoEntidad = Delfin.Controls.TiposEntidad.TIPE_Cliente;
                EAGENTE_CHINA.TipoEntidad = Delfin.Controls.TiposEntidad.TIPE_Agente;
                EAGENTE_SHANGHAI.TipoEntidad = Delfin.Controls.TiposEntidad.TIPE_Agente;
                CODIGO_TRAMARSA.TipoEntidad = Delfin.Controls.TiposEntidad.TIPE_AgentePortuario;
                CODIGO_COSCO_PERU.TipoEntidad = Delfin.Controls.TiposEntidad.TIPE_Transportista;
                CODIGO_HAMBURG_SUD.TipoEntidad = Delfin.Controls.TiposEntidad.TIPE_Transportista;
                CODIGO_HAPAG_LLOYD.TipoEntidad = Delfin.Controls.TiposEntidad.TIPE_Transportista;
                EAGENTE_REEMBOLSO.TipoEntidad = Delfin.Controls.TiposEntidad.TIPE_Agente;
                /*************************************************************************************/

                /**************************** TIPOS DE DOCUMENTOS DE VENTA ********************************/
                TIPO_TDO_NC.LoadControl(Presenter.ContainerService, "Tipos de Doc. Venta", "TDO", "< Seleccionar Doc. Venta >", ListSortDirection.Ascending);
                TIPO_TDO_PR.LoadControl(Presenter.ContainerService, "Tipos de Doc. Venta", "TDO", "< Seleccionar Doc. Venta >", ListSortDirection.Ascending);
                TIPO_TDO_AN.LoadControl(Presenter.ContainerService, "Tipos de Doc. Venta", "TDO", "< Seleccionar Doc. Venta >", ListSortDirection.Ascending);
                TIPO_TDO_CN.LoadControl(Presenter.ContainerService, "Tipos de Doc. Venta", "TDO", "< Seleccionar Doc. Venta >", ListSortDirection.Ascending);
                /******************************************************************************************/

                TIPO_DES_GBAN.LoadControl(Presenter.ContainerService, "Tipos de Descuadre", "DES", "< Seleccionar Descuadre >", ListSortDirection.Ascending);

                /**************************** TIPOS DE CAMBIO *****************************/
                TCCTACTE_CLI.AddComboBoxItem("VEN", "Venta");
                TCCTACTE_CLI.AddComboBoxItem("COM", "Compra");
                TCCTACTE_CLI.LoadComboBox(null);

                TCCTACTE_PRO.AddComboBoxItem("VEN", "Venta");
                TCCTACTE_PRO.AddComboBoxItem("COM", "Compra");
                TCCTACTE_PRO.LoadComboBox(null);
                /**************************************************************************/

                /**************************** OTROS ***************************************/
                STATMENT_MONEDA.LoadControl(Presenter.ContainerService, "Tipos de Moneda", "MND", "< Seleccionar Moneda >", ListSortDirection.Ascending);
                TDI_004SINRUC.LoadControl(Presenter.ContainerService, "Tipos de Documento", "TDI", "< Seleccionar Documento >", ListSortDirection.Ascending);
                PAIS_MANDATO.LoadControl(Presenter.ContainerService, "Tipos de Paises", "PAI", "< Seleccionar Pais >", ListSortDirection.Ascending);
                PUERTO_SHANGHAI.LoadControl(Presenter.ContainerService, "Ayuda de Puerto");
                PUERTO_CALLAO.LoadControl(Presenter.ContainerService, "Ayuda de Puerto");

                Boolean _incio = true;
                foreach (var itemPaquete in Presenter.ListPaquetes)
                { cmbPACK_Codigo.AddComboBoxItem(itemPaquete.PACK_Codigo, itemPaquete.PACK_Desc, _incio); _incio = false; }
                cmbPACK_Codigo.LoadComboBox("< Seleccionar Paquete LCL >");

                /**************************************************************************/

                /************************** PLANILLAS *************************************/
                BSItemsPlanillas = new BindingSource();
                grdItemsPlanillas.DataSource = BSItemsPlanillas;
                FormatGridPlanillas();
                grdItemsPlanillas.BestFitColumns();
                /**************************************************************************/
            }
            catch (Exception ex)
            { throw ex; }
        }
        public void ClearItem()
        {
            try
            {
                #region [ Parametros KPIs ]
                KPI001MIN.Value = (Decimal)0.0;
                KPI001MAX.Value = (Decimal)0.0;

                KPI002MIN.Value = (Decimal)0.0;
                KPI002MAX.Value = (Decimal)0.0;
                TipoRESG_Codigo.ComboIntSelectedValue = null;

                KPI003MIN.Value = (Decimal)0.0;
                KPI003MAX.Value = (Decimal)0.0;

                KPI004MIN.Value = (Decimal)0.0;
                KPI004MAX.Value = (Decimal)0.0;

                KPI005MIN.Value = (Decimal)0.0;
                KPI005MAX.Value = (Decimal)0.0;
                #endregion

                #region [ Usuarios de Aprobacion ]
                USRAPROBADORNIVEL1_JV.ClearValue();
                USRAPROBADORNIVEL2_GC.ClearValue();
                USRAPROBADORNIVEL3_GG.ClearValue();
                #endregion

                #region [ Calculo Comisiones ]
                PROFITPROMTEUS.Value = (Decimal)0.0;
                COMIVENDEDOR.Value = (Decimal)0.0;
                PROFITMINTEUS.Value = (Decimal)0.0;
                #endregion

                #region [ Servicios ]
                SERVADICIONAL.ClearValue(); SERVADICIONAL.TipoAyudaServicio = Delfin.Controls.AyudaServicio.TipoAyuda.Nombre;
                SERVLOGISTICO.ClearValue(); SERVLOGISTICO.TipoAyudaServicio = Delfin.Controls.AyudaServicio.TipoAyuda.Nombre;
                SERVOTROS.ClearValue(); SERVOTROS.TipoAyudaServicio = Delfin.Controls.AyudaServicio.TipoAyuda.Nombre;
                SERVTARJAS.ClearValue(); SERVTARJAS.TipoAyudaServicio = Delfin.Controls.AyudaServicio.TipoAyuda.Nombre;
                SERV_OCULTARSHIPPER.ClearValue(); SERV_OCULTARSHIPPER.TipoAyudaServicio = Delfin.Controls.AyudaServicio.TipoAyuda.Nombre;
                SERVICIO_REEMBOLSO.ClearValue(); SERVICIO_REEMBOLSO.TipoAyudaServicio = Delfin.Controls.AyudaServicio.TipoAyuda.Nombre;
                txtSERV_FLETE_GRR.Text = String.Empty;
                #endregion

                #region [ Eventos ]
                RELEASEHBL.TiposSelectedValue = null;
                BLOQUEAROV.TiposSelectedValue = null;
                DESBLOQUEAROV.TiposSelectedValue = null;
                AGREGAREXCEPCIONOV.TiposSelectedValue = null;
                QUITAREXCEPCIONOV.TiposSelectedValue = null;
                OVDOCUMENTADA.TiposSelectedValue = null;
                DIRECCIONALINEA.TiposSelectedValue = null;
                EMAILALMACEN.TiposSelectedValue = null;
                DESGLOSEVoBo.TiposSelectedValue = null;
                CARTA_AVISOS.TiposSelectedValue = null;
                OVCERRADA.TiposSelectedValue = null;
                APERTURA_STATMENT.TiposSelectedValue = null;
                IMPRIMIRHBL.TiposSelectedValue = null;
                PRE_ALERTA.TiposSelectedValue = null;
                EVE_PREFACTURAR.TiposSelectedValue = null;
                EMITIR_STATEMENT.TiposSelectedValue = null;
                DEVOLUCION_MASTER.TiposSelectedValue = null;
                RECOJO_BLs.TiposSelectedValue = null;
                SERVICIO_TRANSMISION.TiposSelectedValue = null;
                EMISION_SDA.TiposSelectedValue = null;
                EMISION_TELEDESPACHO.TiposSelectedValue = null;
                EMISION_HBL.TiposSelectedValue = null;
                OV_ENTREGADA.TiposSelectedValue = null;
                #endregion

                #region [ Cod. Entidad ]
                CODIGO_TRAMARSA.ClearValue();
                CODIGO_COSCO_PERU.ClearValue();
                EMPRESA.ClearValue();
                EAGENTE_CHINA.ClearValue();
                EAGENTE_SHANGHAI.ClearValue();
                CODIGO_HAMBURG_SUD.ClearValue();
                CODIGO_HAPAG_LLOYD.ClearValue();
                EAGENTE_REEMBOLSO.ClearValue();
                #endregion

                #region [ Entidad Relacionados ]
                RTIPO_DTE.Text = String.Empty;
                RTIPO_VEN.Text = String.Empty;
                RTIPO_CON.Text = String.Empty;
                RTIPO_DVA.Text = String.Empty;
                RTIPO_AGE.Text = String.Empty;
                RTIPO_CSE.Text = String.Empty;
                EEJECUTIVOS.Text = String.Empty;
                #endregion

                #region [ Correos ]
                CORREO_OPERACIONES.Text = String.Empty;
                CORREO_DOCUMENTACION.Text = String.Empty;
                CORREO_LOGISTICA.Text = String.Empty;
                CORREO_CUSTOMER_IMPO.Text = String.Empty;
                CORREO_CUSTOMER_EXPO.Text = String.Empty;
                CORREO_FINANZAS.Text = String.Empty;
                CORREO_FLETAMENTO.Text = String.Empty;
                #endregion

                #region [ Doc. Venta ]
                TIPO_TDO_NC.TiposSelectedValue = null;
                TIPO_TDO_PR.TiposSelectedValue = null;
                TIPO_TDO_AN.TiposSelectedValue = null;
                TIPO_TDO_CN.TiposSelectedValue = null;
                #endregion

                #region [ Tipo Cambio ]
                TCCTACTE_CLI.ComboIntSelectedValue = null;
                TCCTACTE_PRO.ComboIntSelectedValue = null;
                #endregion

                #region [ Series ]
                SERIE_CALLO.Text = string.Empty;
                SERIE_EXPORTACION.Text = string.Empty;
                SERIE_MANDATO.Text = string.Empty;
                SERIE_OTRAFICOS.Text = string.Empty;
                SERIE_SLI.Text = string.Empty;
                #endregion

                #region [ Planillas ]
                BSItemsPlanillas = new BindingSource();
                grdItemsPlanillas.DataSource = BSItemsPlanillas;
                BSItemsPlanillas.ResetBindings(true);
                #endregion

                #region [ Otros ]
                IGV.Value = (Decimal)0.0;
                STATMENT_MONEDA.TiposSelectedValue = null;
                TDI_004SINRUC.TiposSelectedValue = null;
                IMPUser.Text = String.Empty;
                IMPRuta.Text = String.Empty;
                PAIS_MANDATO.TiposSelectedValue = null;
                PUERTO_SHANGHAI.SelectedValue = null;
                PUERTO_CALLAO.SelectedValue = null;

                cmbPACK_Codigo.ComboIntSelectedValue = null;
                #endregion

                #region [ Aduanas ]
                this.RUTA_SDA.Text = String.Empty;
                this.RUTA_TELEDESPACHO.Text = String.Empty;
                #endregion

                #region [ Cuentas ]
                this.CUENTA_VTA_S.Text = string.Empty;
                this.CUENTA_VTA_D.Text = string.Empty;
                this.CUENTA_IGV.Text = string.Empty;
                this.CUENTA_COM_S.Text = string.Empty;
                this.CUENTA_COM_D.Text = string.Empty;

                this.CUENTA_VTA_DIF_S.Text = string.Empty;
                this.CUENTA_VTA_DIF_D.Text = string.Empty;
                this.CUENTA_IGV_DIF_S.Text = string.Empty;
                this.CUENTA_COM_DIF_S.Text = string.Empty;
                this.CUENTA_COM_DIF_D.Text = string.Empty;

                this.CUENTA_OCPP_S.Text = string.Empty;
                this.CUENTA_OCPP_D.Text = string.Empty;
                this.CUENTA_OCPC_S.Text = string.Empty;
                this.CUENTA_OCPC_D.Text = string.Empty;
                this.CUENTA_CC_CHDIF_S.Text = string.Empty;
                this.CUENTA_CC_CHDIF_D.Text = string.Empty;
                this.CUENTA_COSTO_DIF_S.Text = string.Empty;
                this.CUENTA_COSTO_DIF_D.Text = string.Empty;

                this.CUENTA_CC_DIF_V_S.Text = String.Empty;
                this.CUENTA_CC_DIF_V_D.Text = String.Empty;
                this.CUENTA_CP_DIF_V_S.Text = String.Empty;
                this.CUENTA_CP_DIF_V_D.Text = String.Empty;
                #endregion

                #region [ Glosa ]
                this.FC_EXONERADO.Text = string.Empty;
                this.FC_OPSUJETAPOT.Text = string.Empty;
                #endregion

                #region [ Facturación ]
                this.FAC_TDO.Text = string.Empty;
                this.FAC_TDO_OP.Text = string.Empty;
                this.FAC_TDO_OV.Text = string.Empty;
                this.PREF_TDO_SLI.Text = string.Empty;
                this.PREF_TDO_ILD.Text = String.Empty;
                this.TIPO_TDO_NCS.Text = String.Empty;
                #endregion

                CCCT_TIPODOCUMENTO.Clear();
                MOVI_CHQBLANCO.Clear();
            }
            catch (Exception ex)
            { throw ex; }
        }
        public Boolean GetItem()
        {
            try
            {
                errorProvider1.Clear();
                errorProvider1.Dispose();
                Boolean isCorrect = true;

                #region [ Parametros KPIs ]
                if (KPI001MIN.Value >= 0)
                { Presenter.KPI001MIN.PARA_Valor = Convert.ToInt32(KPI001MIN.Value).ToString(); }
                else
                { Presenter.KPI001MIN.PARA_Valor = null; errorProvider1.SetError(KPI001MIN, "Debe ingresar el Valor Mínimo de Prospecto Contactados."); isCorrect = false; }
                if (KPI001MAX.Value >= 0)
                { Presenter.KPI001MAX.PARA_Valor = Convert.ToInt32(KPI001MAX.Value).ToString(); }
                else
                { Presenter.KPI001MAX.PARA_Valor = null; errorProvider1.SetError(KPI001MAX, "Debe ingresar el Valor Máximo de Prospecto Contactados."); isCorrect = false; }

                if (KPI002MIN.Value >= 0)
                { Presenter.KPI002MIN.PARA_Valor = Convert.ToInt32(KPI002MIN.Value).ToString(); }
                else
                { Presenter.KPI002MIN.PARA_Valor = null; errorProvider1.SetError(KPI002MIN, "Debe ingresar el Valor Mínimo de Reuniones."); isCorrect = false; }
                if (KPI002MAX.Value >= 0)
                { Presenter.KPI002MAX.PARA_Valor = Convert.ToInt32(KPI002MAX.Value).ToString(); }
                else
                { Presenter.KPI002MAX.PARA_Valor = null; errorProvider1.SetError(KPI002MAX, "Debe ingresar el Valor Máximo de Reuniones."); isCorrect = false; }

                if ((KPI002RESG.SelectedItem != null && ((Entities.ResultGestion)KPI002RESG.SelectedItem).RESG_Codigo != -1) && KPI002RESG.SelectedItem is Entities.ResultGestion)
                { Presenter.KPI002RESG.PARA_Valor = ((Entities.ResultGestion)KPI002RESG.SelectedItem).RESG_Codigo.ToString(); }
                else
                { Presenter.KPI002RESG.PARA_Valor = null; errorProvider1.SetError(KPI002RESG, "Debe seleccionar el Resultadoi de Gestión de Reuniones."); isCorrect = false; }

                if (KPI003MIN.Value >= 0)
                { Presenter.KPI003MIN.PARA_Valor = Convert.ToInt32(KPI003MIN.Value).ToString(); }
                else
                { Presenter.KPI003MIN.PARA_Valor = null; errorProvider1.SetError(KPI003MIN, "Debe ingresar el Valor Mínimo de TEUS Vendidos."); isCorrect = false; }
                if (KPI003MAX.Value >= 0)
                { Presenter.KPI003MAX.PARA_Valor = Convert.ToInt32(KPI003MAX.Value).ToString(); }
                else
                { Presenter.KPI003MAX.PARA_Valor = null; errorProvider1.SetError(KPI003MAX, "Debe ingresar el Valor Máximo de TEUS Vendidos."); isCorrect = false; }

                if (KPI004MIN.Value >= 0)
                { Presenter.KPI004MIN.PARA_Valor = Convert.ToInt32(KPI004MIN.Value).ToString(); }
                else
                { Presenter.KPI004MIN.PARA_Valor = null; errorProvider1.SetError(KPI004MIN, "Debe ingresar el Valor Mínimo de Ordenes de Venta."); isCorrect = false; }
                if (KPI004MAX.Value >= 0)
                { Presenter.KPI004MAX.PARA_Valor = Convert.ToInt32(KPI004MAX.Value).ToString(); }
                else
                { Presenter.KPI004MAX.PARA_Valor = null; errorProvider1.SetError(KPI004MAX, "Debe ingresar el Valor Máximo de Ordenes de Venta."); isCorrect = false; }

                if (KPI005MIN.Value >= 0)
                { Presenter.KPI005MIN.PARA_Valor = Convert.ToInt32(KPI005MIN.Value).ToString(); }
                else
                { Presenter.KPI005MIN.PARA_Valor = null; errorProvider1.SetError(KPI005MIN, "Debe ingresar el Valor Mínimo de Cotizaciones."); isCorrect = false; }
                if (KPI005MAX.Value >= 0)
                { Presenter.KPI005MAX.PARA_Valor = Convert.ToInt32(KPI005MAX.Value).ToString(); }
                else
                { Presenter.KPI005MAX.PARA_Valor = null; errorProvider1.SetError(KPI005MAX, "Debe ingresar el Valor Máximo de Cotizaciones."); isCorrect = false; }
                #endregion

                #region [ Usuarios de Aprobacion ]
                if (USRAPROBADORNIVEL1_JV.Value != null && USRAPROBADORNIVEL1_JV.Value is NextAdmin.BusinessLogic.Usuarios)
                { Presenter.USRAPRUEBANIVEL1_JV.PARA_Valor = ((NextAdmin.BusinessLogic.Usuarios)USRAPROBADORNIVEL1_JV.Value).USUA_CodUsr; }
                else
                {
                    Presenter.USRAPRUEBANIVEL1_JV.PARA_Valor = null;
                    errorProvider1.SetError(USRAPROBADORNIVEL1_JV, "Debe ingresar el usuario de Aprobación del Primer Nivel."); isCorrect = false;
                }
                if (USRAPROBADORNIVEL2_GC.Value != null && USRAPROBADORNIVEL2_GC.Value is NextAdmin.BusinessLogic.Usuarios)
                { Presenter.USRAPRUEBANIVEL2_GC.PARA_Valor = ((NextAdmin.BusinessLogic.Usuarios)USRAPROBADORNIVEL2_GC.Value).USUA_CodUsr; }
                else
                {
                    Presenter.USRAPRUEBANIVEL2_GC.PARA_Valor = null;
                    errorProvider1.SetError(USRAPROBADORNIVEL2_GC, "Debe ingresar el usuario de Aprobación del Segundo Nivel."); isCorrect = false;
                }
                if (USRAPROBADORNIVEL3_GG.Value != null && USRAPROBADORNIVEL3_GG.Value is NextAdmin.BusinessLogic.Usuarios)
                { Presenter.USRAPRUEBANIVEL3_GG.PARA_Valor = ((NextAdmin.BusinessLogic.Usuarios)USRAPROBADORNIVEL3_GG.Value).USUA_CodUsr; }
                else
                {
                    Presenter.USRAPRUEBANIVEL3_GG.PARA_Valor = null;
                    errorProvider1.SetError(USRAPROBADORNIVEL3_GG, "Debe ingresar el usuario de Aprobación del Tercer Nivel."); isCorrect = false;
                }
                #endregion

                #region [ Calculo Comisiones ]
                if (PROFITPROMTEUS.Value >= (Decimal)0.0)
                { Presenter.PROFITPROMTEUS.PARA_Valor = PROFITPROMTEUS.Value.ToString(); }
                else
                {
                    Presenter.PROFITPROMTEUS.PARA_Valor = null;
                    errorProvider1.SetError(PROFITPROMTEUS, "Debe ingresar el valor Profit Promedio TEUS."); isCorrect = false;
                }
                if (PROFITMINTEUS.Value >= (Decimal)0.0)
                { Presenter.PROFITMINTEUS.PARA_Valor = PROFITMINTEUS.Value.ToString(); }
                else
                {
                    Presenter.PROFITMINTEUS.PARA_Valor = null;
                    errorProvider1.SetError(PROFITMINTEUS, "Debe ingresar el valor Profit Minimo TEUS."); isCorrect = false;
                }
                if (COMIVENDEDOR.Value >= (Decimal)0.0)
                { Presenter.COMIVENDEDOR.PARA_Valor = COMIVENDEDOR.Value.ToString(); }
                else
                {
                    Presenter.COMIVENDEDOR.PARA_Valor = null;
                    errorProvider1.SetError(COMIVENDEDOR, "Debe ingresar el valor Comision Vendedor."); isCorrect = false;
                }
                #endregion

                #region [ Servicios ]
                if (SERVADICIONAL.SelectedServicio != null)
                { Presenter.SERVADICIONAL.PARA_Valor = SERVADICIONAL.SelectedServicio.SERV_Codigo.ToString(); }
                else
                {
                    Presenter.SERVADICIONAL.PARA_Valor = null;
                    errorProvider1.SetError(SERVADICIONAL, "Debe seleccionar un servicio."); isCorrect = false;
                }

                if (SERVLOGISTICO.SelectedServicio != null)
                { Presenter.SERVLOGISTICO.PARA_Valor = SERVLOGISTICO.SelectedServicio.SERV_Codigo.ToString(); }
                else
                {
                    Presenter.SERVLOGISTICO.PARA_Valor = null;
                    errorProvider1.SetError(SERVLOGISTICO, "Debe seleccionar un servicio."); isCorrect = false;
                }

                if (SERVOTROS.SelectedServicio != null)
                { Presenter.SERVOTROS.PARA_Valor = SERVOTROS.SelectedServicio.SERV_Codigo.ToString(); }
                else
                {
                    Presenter.SERVOTROS.PARA_Valor = null;
                    errorProvider1.SetError(SERVOTROS, "Debe seleccionar un servicio."); isCorrect = false;
                }

                if (SERVTARJAS.SelectedServicio != null)
                { Presenter.SERVTARJAS.PARA_Valor = SERVTARJAS.SelectedServicio.SERV_Codigo.ToString(); }
                else
                {
                    Presenter.SERVTARJAS.PARA_Valor = null;
                    errorProvider1.SetError(SERVTARJAS, "Debe seleccionar un servicio."); isCorrect = false;
                }

                if (SERV_OCULTARSHIPPER.SelectedServicio != null)
                { Presenter.SERV_OCULTARSHIPPER.PARA_Valor = SERV_OCULTARSHIPPER.SelectedServicio.SERV_Codigo.ToString(); }
                else
                {
                    Presenter.SERV_OCULTARSHIPPER.PARA_Valor = null;
                    errorProvider1.SetError(SERV_OCULTARSHIPPER, "Debe seleccionar un servicio."); isCorrect = false;
                }

                if (SERVICIO_REEMBOLSO.SelectedServicio != null)
                { Presenter.SERVICIO_REEMBOLSO.PARA_Valor = SERVICIO_REEMBOLSO.SelectedServicio.SERV_Codigo.ToString(); }
                else
                {
                    Presenter.SERVICIO_REEMBOLSO.PARA_Valor = null;
                    errorProvider1.SetError(SERVICIO_REEMBOLSO, "Debe seleccionar un servicio."); isCorrect = false;
                }

                if (!String.IsNullOrEmpty(txtSERV_FLETE_GRR.Text))
                { Presenter.SERV_FLETE_GRR.PARA_Valor = txtSERV_FLETE_GRR.Text; }
                else
                {
                    Presenter.SERV_FLETE_GRR.PARA_Valor = null;
                    //errorProvider1.SetError(txtSERV_FLETE_GRR, "Debe seleccionar un servicio de Flete para el cálculo de GRR."); isCorrect = false;
                }
                #endregion

                #region [ Eventos ]
                if (RELEASEHBL.TiposSelectedItem != null)
                { Presenter.RELEASEHBL.PARA_Valor = RELEASEHBL.TiposSelectedValue; }
                else
                {
                    Presenter.RELEASEHBL.PARA_Valor = null;
                    errorProvider1.SetError(RELEASEHBL, "Debe seleccionar un Evento."); isCorrect = false;
                }
                if (BLOQUEAROV.TiposSelectedItem != null)
                { Presenter.BLOQUEAROV.PARA_Valor = BLOQUEAROV.TiposSelectedValue; }
                else
                {
                    Presenter.BLOQUEAROV.PARA_Valor = null;
                    errorProvider1.SetError(BLOQUEAROV, "Debe seleccionar un Evento."); isCorrect = false;
                }
                if (DESBLOQUEAROV.TiposSelectedItem != null)
                { Presenter.DESBLOQUEAROV.PARA_Valor = DESBLOQUEAROV.TiposSelectedValue; }
                else
                {
                    Presenter.DESBLOQUEAROV.PARA_Valor = null;
                    errorProvider1.SetError(DESBLOQUEAROV, "Debe seleccionar un Evento."); isCorrect = false;
                }
                if (AGREGAREXCEPCIONOV.TiposSelectedItem != null)
                { Presenter.AGREGAREXCEPCIONOV.PARA_Valor = AGREGAREXCEPCIONOV.TiposSelectedValue; }
                else
                {
                    Presenter.AGREGAREXCEPCIONOV.PARA_Valor = null;
                    errorProvider1.SetError(AGREGAREXCEPCIONOV, "Debe seleccionar un Evento."); isCorrect = false;
                }
                if (QUITAREXCEPCIONOV.TiposSelectedItem != null)
                { Presenter.QUITAREXCEPCIONOV.PARA_Valor = QUITAREXCEPCIONOV.TiposSelectedValue; }
                else
                {
                    Presenter.QUITAREXCEPCIONOV.PARA_Valor = null;
                    errorProvider1.SetError(QUITAREXCEPCIONOV, "Debe seleccionar un Evento."); isCorrect = false;
                }
                if (OVDOCUMENTADA.TiposSelectedItem != null)
                { Presenter.OVDOCUMENTADA.PARA_Valor = OVDOCUMENTADA.TiposSelectedValue; }
                else
                {
                    Presenter.OVDOCUMENTADA.PARA_Valor = null;
                    errorProvider1.SetError(OVDOCUMENTADA, "Debe seleccionar un Evento."); isCorrect = false;
                }
                if (DIRECCIONALINEA.TiposSelectedItem != null)
                { Presenter.DIRECCIONALINEA.PARA_Valor = DIRECCIONALINEA.TiposSelectedValue; }
                else
                {
                    Presenter.DIRECCIONALINEA.PARA_Valor = null;
                    errorProvider1.SetError(DIRECCIONALINEA, "Debe seleccionar un Evento."); isCorrect = false;
                }
                if (EMAILALMACEN.TiposSelectedItem != null)
                { Presenter.EMAILALMACEN.PARA_Valor = EMAILALMACEN.TiposSelectedValue; }
                else
                {
                    Presenter.EMAILALMACEN.PARA_Valor = null;
                    errorProvider1.SetError(EMAILALMACEN, "Debe seleccionar un Evento."); isCorrect = false;
                }
                if (DESGLOSEVoBo.TiposSelectedItem != null)
                { Presenter.DESGLOSEVoBo.PARA_Valor = DESGLOSEVoBo.TiposSelectedValue; }
                else
                {
                    Presenter.DESGLOSEVoBo.PARA_Valor = null;
                    errorProvider1.SetError(DESGLOSEVoBo, "Debe seleccionar un Evento."); isCorrect = false;
                }
                if (CARTA_AVISOS.TiposSelectedItem != null)
                { Presenter.CARTA_AVISOS.PARA_Valor = CARTA_AVISOS.TiposSelectedValue; }
                else
                {
                    Presenter.CARTA_AVISOS.PARA_Valor = null;
                    errorProvider1.SetError(CARTA_AVISOS, "Debe seleccionar un Evento."); isCorrect = false;
                }
                if (OVCERRADA.TiposSelectedItem != null)
                { Presenter.OVCERRADA.PARA_Valor = OVCERRADA.TiposSelectedValue; }
                else
                {
                    Presenter.OVCERRADA.PARA_Valor = null;
                    errorProvider1.SetError(OVCERRADA, "Debe seleccionar un Evento."); isCorrect = false;
                }
                if (APERTURA_STATMENT.TiposSelectedItem != null)
                { Presenter.APERTURA_STATMENT.PARA_Valor = APERTURA_STATMENT.TiposSelectedValue; }
                else
                {
                    Presenter.APERTURA_STATMENT.PARA_Valor = null;
                    errorProvider1.SetError(APERTURA_STATMENT, "Debe seleccionar un Evento."); isCorrect = false;
                }
                if (IMPRIMIRHBL.TiposSelectedItem != null)
                { Presenter.IMPRIMIRHBL.PARA_Valor = IMPRIMIRHBL.TiposSelectedValue; }
                else
                {
                    Presenter.IMPRIMIRHBL.PARA_Valor = null;
                    errorProvider1.SetError(IMPRIMIRHBL, "Debe seleccionar un Evento."); isCorrect = false;
                }
                if (PRE_ALERTA.TiposSelectedItem != null)
                { Presenter.PRE_ALERTA.PARA_Valor = PRE_ALERTA.TiposSelectedValue; }
                else
                {
                    Presenter.PRE_ALERTA.PARA_Valor = null;
                    errorProvider1.SetError(PRE_ALERTA, "Debe seleccionar un Evento."); isCorrect = false;
                }
                if (EVE_PREFACTURAR.TiposSelectedItem != null)
                { Presenter.EVE_PREFACTURAR.PARA_Valor = EVE_PREFACTURAR.TiposSelectedValue; }
                else
                {
                    Presenter.EVE_PREFACTURAR.PARA_Valor = null;
                    errorProvider1.SetError(EVE_PREFACTURAR, "Debe seleccionar un Evento."); isCorrect = false;
                }
                if (EMITIR_STATEMENT.TiposSelectedItem != null)
                { Presenter.EMITIR_STATEMENT.PARA_Valor = EMITIR_STATEMENT.TiposSelectedValue; }
                else
                {
                    Presenter.EMITIR_STATEMENT.PARA_Valor = null;
                    errorProvider1.SetError(EMITIR_STATEMENT, "Debe seleccionar un Evento."); isCorrect = false;
                }
                if (DEVOLUCION_MASTER.TiposSelectedItem != null)
                { Presenter.DEVOLUCION_MASTER.PARA_Valor = DEVOLUCION_MASTER.TiposSelectedValue; }
                else
                {
                    Presenter.DEVOLUCION_MASTER.PARA_Valor = null;
                    errorProvider1.SetError(DEVOLUCION_MASTER, "Debe seleccionar un Evento."); isCorrect = false;
                }
                if (RECOJO_BLs.TiposSelectedItem != null)
                { Presenter.RECOJO_BLs.PARA_Valor = RECOJO_BLs.TiposSelectedValue; }
                else
                {
                    Presenter.RECOJO_BLs.PARA_Valor = null;
                    errorProvider1.SetError(RECOJO_BLs, "Debe seleccionar un Evento."); isCorrect = false;
                }
                if (SERVICIO_TRANSMISION.TiposSelectedItem != null)
                { Presenter.SERVICIO_TRANSMISION.PARA_Valor = SERVICIO_TRANSMISION.TiposSelectedValue; }
                else
                {
                    Presenter.SERVICIO_TRANSMISION.PARA_Valor = null;
                    errorProvider1.SetError(SERVICIO_TRANSMISION, "Debe seleccionar un Evento."); isCorrect = false;
                }
                if (EMISION_SDA.TiposSelectedItem != null)
                { Presenter.EMISION_SDA.PARA_Valor = EMISION_SDA.TiposSelectedValue; }
                else
                {
                    Presenter.EMISION_SDA.PARA_Valor = null;
                    errorProvider1.SetError(EMISION_SDA, "Debe seleccionar un Evento."); isCorrect = false;
                }
                if (EMISION_TELEDESPACHO.TiposSelectedItem != null)
                { Presenter.EMISION_TELEDESPACHO.PARA_Valor = EMISION_TELEDESPACHO.TiposSelectedValue; }
                else
                {
                    Presenter.EMISION_TELEDESPACHO.PARA_Valor = null;
                    errorProvider1.SetError(EMISION_TELEDESPACHO, "Debe seleccionar un Evento."); isCorrect = false;
                }
                if (EMISION_HBL.TiposSelectedItem != null)
                { Presenter.EMISION_HBL.PARA_Valor = EMISION_HBL.TiposSelectedValue; }
                else
                {
                    Presenter.EMISION_HBL.PARA_Valor = null;
                    errorProvider1.SetError(EMISION_HBL, "Debe seleccionar un Evento."); isCorrect = false;
                }
                if (OV_ENTREGADA.TiposSelectedItem != null)
                { Presenter.OV_ENTREGADA.PARA_Valor = OV_ENTREGADA.TiposSelectedValue; }
                else
                {
                    Presenter.OV_ENTREGADA.PARA_Valor = null;
                    errorProvider1.SetError(OV_ENTREGADA, "Debe seleccionar un Evento."); isCorrect = false;
                }
                #endregion

                #region [ Cod. Entidad ]
                if (EMPRESA.Value != null)
                { Presenter.EMPRESA.PARA_Valor = EMPRESA.Value.ENTC_Codigo.ToString(); }
                else
                { Presenter.EMPRESA.PARA_Valor = null; errorProvider1.SetError(EMPRESA, "Debe seleccionar una Entidad"); isCorrect = false; }
                if (EAGENTE_CHINA.Value != null)
                { Presenter.EAGENTE_CHINA.PARA_Valor = EAGENTE_CHINA.Value.ENTC_Codigo.ToString(); }
                else
                { Presenter.EAGENTE_CHINA.PARA_Valor = null; errorProvider1.SetError(EAGENTE_CHINA, "Debe seleccionar una Entidad"); isCorrect = false; }
                if (EAGENTE_SHANGHAI.Value != null)
                { Presenter.EAGENTE_SHANGHAI.PARA_Valor = EAGENTE_SHANGHAI.Value.ENTC_Codigo.ToString(); }
                else
                { Presenter.EAGENTE_SHANGHAI.PARA_Valor = null; errorProvider1.SetError(EAGENTE_SHANGHAI, "Debe seleccionar una Entidad"); isCorrect = false; }
                if (CODIGO_TRAMARSA.Value != null)
                { Presenter.CODIGO_TRAMARSA.PARA_Valor = CODIGO_TRAMARSA.Value.ENTC_Codigo.ToString(); }
                else
                { Presenter.CODIGO_TRAMARSA.PARA_Valor = null; errorProvider1.SetError(CODIGO_TRAMARSA, "Debe seleccionar una Entidad"); isCorrect = false; }
                if (CODIGO_COSCO_PERU.Value != null)
                { Presenter.CODIGO_COSCO_PERU.PARA_Valor = CODIGO_COSCO_PERU.Value.ENTC_Codigo.ToString(); }
                else
                { Presenter.CODIGO_COSCO_PERU.PARA_Valor = null; errorProvider1.SetError(CODIGO_COSCO_PERU, "Debe seleccionar una Entidad"); isCorrect = false; }
                if (CODIGO_HAMBURG_SUD.Value != null)
                { Presenter.CODIGO_HAMBURG_SUD.PARA_Valor = CODIGO_HAMBURG_SUD.Value.ENTC_Codigo.ToString(); }
                else
                { Presenter.CODIGO_HAMBURG_SUD.PARA_Valor = null; errorProvider1.SetError(CODIGO_HAMBURG_SUD, "Debe seleccionar una Entidad"); isCorrect = false; }
                if (CODIGO_HAPAG_LLOYD.Value != null)
                { Presenter.CODIGO_HAPAG_LLOYD.PARA_Valor = CODIGO_HAPAG_LLOYD.Value.ENTC_Codigo.ToString(); }
                else
                { Presenter.CODIGO_HAPAG_LLOYD.PARA_Valor = null; errorProvider1.SetError(CODIGO_HAPAG_LLOYD, "Debe seleccionar una Entidad"); isCorrect = false; }
                if (EAGENTE_REEMBOLSO.Value != null)
                { Presenter.EAGENTE_REEMBOLSO.PARA_Valor = EAGENTE_REEMBOLSO.Value.ENTC_Codigo.ToString(); }
                else
                { Presenter.EAGENTE_REEMBOLSO.PARA_Valor = null; errorProvider1.SetError(EAGENTE_REEMBOLSO, "Debe seleccionar una Entidad"); isCorrect = false; }
                #endregion

                #region [ Entidad Relacionados ]
                if (!String.IsNullOrEmpty(RTIPO_DTE.Text))
                { Presenter.RTIPO_DTE.PARA_Valor = RTIPO_DTE.Text; }
                else
                { Presenter.RTIPO_DTE.PARA_Valor = null; errorProvider1.SetError(RTIPO_DTE, "Debe ingresar un codigo"); isCorrect = false; }
                if (!String.IsNullOrEmpty(RTIPO_VEN.Text))
                { Presenter.RTIPO_VEN.PARA_Valor = RTIPO_VEN.Text; }
                else
                { Presenter.RTIPO_VEN.PARA_Valor = null; errorProvider1.SetError(RTIPO_VEN, "Debe ingresar un codigo"); isCorrect = false; }
                if (!String.IsNullOrEmpty(RTIPO_CON.Text))
                { Presenter.RTIPO_CON.PARA_Valor = RTIPO_CON.Text; }
                else
                { Presenter.RTIPO_CON.PARA_Valor = null; errorProvider1.SetError(RTIPO_CON, "Debe ingresar un codigo"); isCorrect = false; }
                if (!String.IsNullOrEmpty(RTIPO_DVA.Text))
                { Presenter.RTIPO_DVA.PARA_Valor = RTIPO_DVA.Text; }
                else
                { Presenter.RTIPO_DVA.PARA_Valor = null; errorProvider1.SetError(RTIPO_DVA, "Debe ingresar un codigo"); isCorrect = false; }
                if (!String.IsNullOrEmpty(RTIPO_AGE.Text))
                { Presenter.RTIPO_AGE.PARA_Valor = RTIPO_AGE.Text; }
                else
                { Presenter.RTIPO_AGE.PARA_Valor = null; errorProvider1.SetError(RTIPO_AGE, "Debe ingresar un codigo"); isCorrect = false; }
                if (!String.IsNullOrEmpty(RTIPO_CSE.Text))
                { Presenter.RTIPO_CSE.PARA_Valor = RTIPO_CSE.Text; }
                else
                { Presenter.RTIPO_CSE.PARA_Valor = null; errorProvider1.SetError(RTIPO_CSE, "Debe ingresar un codigo"); isCorrect = false; }
                #endregion

                #region [ Correos ]
                /*1*/
                if (!String.IsNullOrEmpty(CORREO_OPERACIONES.Text))
                {
                    if (Delfin.Controls.Utils.checkMailFormat(CORREO_OPERACIONES.Text))
                    { Presenter.CORREO_OPERACIONES.PARA_Valor = CORREO_OPERACIONES.Text; }
                    else
                    {
                        Presenter.CORREO_OPERACIONES.PARA_Valor = null;
                        errorProvider1.SetError(CORREO_OPERACIONES, "El Formato del Correo es Incorrecto"); isCorrect = false;
                    }
                }
                else
                {
                    Presenter.CORREO_OPERACIONES.PARA_Valor = null;
                    errorProvider1.SetError(CORREO_OPERACIONES, "Debe ingresar el correo Grupal de Operaciones."); isCorrect = false;
                }
                /*2*/
                if (!String.IsNullOrEmpty(CORREO_DOCUMENTACION.Text))
                {
                    if (Delfin.Controls.Utils.checkMailFormat(CORREO_DOCUMENTACION.Text))
                    { Presenter.CORREO_DOCUMENTACION.PARA_Valor = CORREO_DOCUMENTACION.Text; }
                    else
                    {
                        Presenter.CORREO_DOCUMENTACION.PARA_Valor = null;
                        errorProvider1.SetError(CORREO_DOCUMENTACION, "El Formato del Correo es Incorrecto"); isCorrect = false;
                    }
                }
                else
                {
                    Presenter.CORREO_DOCUMENTACION.PARA_Valor = null;
                    errorProvider1.SetError(CORREO_DOCUMENTACION, "Debe ingresar el correo Grupal de Documentacion."); isCorrect = false;
                }
                /*3*/
                if (!String.IsNullOrEmpty(CORREO_LOGISTICA.Text))
                {
                    if (Delfin.Controls.Utils.checkMailFormat(CORREO_LOGISTICA.Text))
                    { Presenter.CORREO_LOGISTICA.PARA_Valor = CORREO_LOGISTICA.Text; }
                    else
                    {
                        Presenter.CORREO_LOGISTICA.PARA_Valor = null;
                        errorProvider1.SetError(CORREO_LOGISTICA, "El Formato del Correo es Incorrecto"); isCorrect = false;
                    }
                }
                else
                {
                    Presenter.CORREO_LOGISTICA.PARA_Valor = null;
                    errorProvider1.SetError(CORREO_LOGISTICA, "Debe ingresar el correo Grupal de Logistica."); isCorrect = false;
                }
                /*4*/
                if (!String.IsNullOrEmpty(CORREO_CUSTOMER_IMPO.Text))
                {
                    if (Delfin.Controls.Utils.checkMailFormat(CORREO_CUSTOMER_IMPO.Text))
                    { Presenter.CORREO_CUSTOMER_IMPO.PARA_Valor = CORREO_CUSTOMER_IMPO.Text; }
                    else
                    {
                        Presenter.CORREO_CUSTOMER_IMPO.PARA_Valor = null;
                        errorProvider1.SetError(CORREO_CUSTOMER_IMPO, "El Formato del Correo es Incorrecto"); isCorrect = false;
                    }
                }
                else
                {
                    Presenter.CORREO_CUSTOMER_IMPO.PARA_Valor = null;
                    errorProvider1.SetError(CORREO_CUSTOMER_IMPO, "Debe ingresar del Jefe Customer de Importaciones."); isCorrect = false;
                }
                /*5*/
                if (!String.IsNullOrEmpty(CORREO_CUSTOMER_EXPO.Text))
                {
                    if (Delfin.Controls.Utils.checkMailFormat(CORREO_CUSTOMER_EXPO.Text))
                    { Presenter.CORREO_CUSTOMER_EXPO.PARA_Valor = CORREO_CUSTOMER_EXPO.Text; }
                    else
                    {
                        Presenter.CORREO_CUSTOMER_EXPO.PARA_Valor = null;
                        errorProvider1.SetError(CORREO_CUSTOMER_EXPO, "El Formato del Correo es Incorrecto"); isCorrect = false;
                    }
                }
                else
                {
                    Presenter.CORREO_CUSTOMER_EXPO.PARA_Valor = null;
                    errorProvider1.SetError(CORREO_CUSTOMER_EXPO, "Debe ingresar del Jefe Customer de Exportaciones."); isCorrect = false;
                }
                /*6*/
                if (!String.IsNullOrEmpty(CORREO_FINANZAS.Text))
                {
                    if (Delfin.Controls.Utils.checkMailFormat(CORREO_FINANZAS.Text))
                    { Presenter.CORREO_FINANZAS.PARA_Valor = CORREO_FINANZAS.Text; }
                    else
                    {
                        Presenter.CORREO_FINANZAS.PARA_Valor = null;
                        errorProvider1.SetError(CORREO_FINANZAS, "El Formato del Correo es Incorrecto"); isCorrect = false;
                    }
                }
                else
                {
                    Presenter.CORREO_FINANZAS.PARA_Valor = null;
                    errorProvider1.SetError(CORREO_FINANZAS, "Debe ingresar el correo Grupal de Finanzas."); isCorrect = false;
                }
                /*7*/
                if (!String.IsNullOrEmpty(CORREO_FLETAMENTO.Text))
                {
                    if (Delfin.Controls.Utils.checkMailFormat(CORREO_FLETAMENTO.Text))
                    { Presenter.CORREO_FLETAMENTO.PARA_Valor = CORREO_FLETAMENTO.Text; }
                    else
                    {
                        Presenter.CORREO_FLETAMENTO.PARA_Valor = null;
                        errorProvider1.SetError(CORREO_FLETAMENTO, "El Formato del Correo es Incorrecto"); isCorrect = false;
                    }
                }
                else
                {
                    Presenter.CORREO_FLETAMENTO.PARA_Valor = null;
                    errorProvider1.SetError(CORREO_FLETAMENTO, "Debe ingresar el correo Grupal de Fletamento."); isCorrect = false;
                }
                #endregion

                #region [ Doc. Venta ]
                if (TIPO_TDO_NC.TiposSelectedItem != null)
                { Presenter.TIPO_TDO_NC.PARA_Valor = TIPO_TDO_NC.TiposSelectedValue; }
                else
                {
                    Presenter.TIPO_TDO_NC.PARA_Valor = null;
                    errorProvider1.SetError(TIPO_TDO_NC, "Debe seleccionar un Doc. Venta"); isCorrect = false;
                }
                if (TIPO_TDO_PR.TiposSelectedItem != null)
                { Presenter.TIPO_TDO_PR.PARA_Valor = TIPO_TDO_PR.TiposSelectedValue; }
                else
                {
                    Presenter.TIPO_TDO_PR.PARA_Valor = null;
                    errorProvider1.SetError(TIPO_TDO_PR, "Debe seleccionar un Doc. Venta"); isCorrect = false;
                }
                if (TIPO_TDO_AN.TiposSelectedItem != null)
                { Presenter.TIPO_TDO_AN.PARA_Valor = TIPO_TDO_AN.TiposSelectedValue; }
                else
                {
                    Presenter.TIPO_TDO_AN.PARA_Valor = null;
                    errorProvider1.SetError(TIPO_TDO_AN, "Debe seleccionar un Doc. Venta"); isCorrect = false;
                }
                if (TIPO_TDO_CN.TiposSelectedItem != null)
                { Presenter.TIPO_TDO_CN.PARA_Valor = TIPO_TDO_CN.TiposSelectedValue; }
                else
                {
                    Presenter.TIPO_TDO_CN.PARA_Valor = null;
                    errorProvider1.SetError(TIPO_TDO_CN, "Debe seleccionar un Doc. Venta"); isCorrect = false;
                }
                #endregion

                #region [ Tipo Cambio ]
                if (TCCTACTE_CLI.SelectedItem != null)
                { Presenter.TCCTACTE_CLI.PARA_Valor = TCCTACTE_CLI.SelectedValue.ToString(); }
                else
                { Presenter.TCCTACTE_CLI.PARA_Valor = null; errorProvider1.SetError(TCCTACTE_CLI, "Debe seleccionar un tipo de cambio"); isCorrect = false; }
                if (TCCTACTE_PRO.SelectedItem != null)
                { Presenter.TCCTACTE_PRO.PARA_Valor = TCCTACTE_PRO.SelectedValue.ToString(); }
                else
                { Presenter.TCCTACTE_PRO.PARA_Valor = null; errorProvider1.SetError(TCCTACTE_PRO, "Debe seleccionar un tipo de cambio"); isCorrect = false; }
                #endregion

                #region [ Series ]
                if (!string.IsNullOrEmpty(SERIE_CALLO.Text))
                { Presenter.SERIE_CALLO.PARA_Valor = SERIE_CALLO.Text; }
                else
                { Presenter.SERIE_CALLO.PARA_Valor = null; errorProvider1.SetError(SERIE_CALLO, "Debe ingresar un Valor"); isCorrect = false; }
                if (!string.IsNullOrEmpty(SERIE_EXPORTACION.Text))
                { Presenter.SERIE_EXPORTACION.PARA_Valor = SERIE_EXPORTACION.Text; }
                else
                { Presenter.SERIE_EXPORTACION.PARA_Valor = null; errorProvider1.SetError(SERIE_EXPORTACION, "Debe ingresar un Valor"); isCorrect = false; }
                if (!string.IsNullOrEmpty(SERIE_MANDATO.Text))
                { Presenter.SERIE_MANDATO.PARA_Valor = SERIE_MANDATO.Text; }
                else
                { Presenter.SERIE_MANDATO.PARA_Valor = null; errorProvider1.SetError(SERIE_MANDATO, "Debe ingresar un Valor"); isCorrect = false; }
                if (!string.IsNullOrEmpty(SERIE_OTRAFICOS.Text))
                { Presenter.SERIE_OTRAFICOS.PARA_Valor = SERIE_OTRAFICOS.Text; }
                else
                { Presenter.SERIE_OTRAFICOS.PARA_Valor = null; errorProvider1.SetError(SERIE_OTRAFICOS, "Debe ingresar un Valor"); isCorrect = false; }
                if (!string.IsNullOrEmpty(SERIE_SLI.Text))
                { Presenter.SERIE_SLI.PARA_Valor = SERIE_SLI.Text; }
                else
                { Presenter.SERIE_SLI.PARA_Valor = null; errorProvider1.SetError(SERIE_SLI, "Debe ingresar un Valor"); isCorrect = false; }
                #endregion

                #region [ Planillas ]
                //Presenter.PLANILLAS = ((ObservableCollection<Entities.Parametros>)BSItemsPlanillas.DataSource);
                #endregion

                #region [ Otros ]
                if (IGV.Value >= 0)
                { Presenter.IGV.PARA_Valor = Convert.ToInt32(IGV.Value).ToString(); }
                else
                { Presenter.IGV.PARA_Valor = null; errorProvider1.SetError(IGV, "Debe ingresar un Valor"); isCorrect = false; }
                if (STATMENT_MONEDA.TiposSelectedItem != null)
                { Presenter.STATMENT_MONEDA.PARA_Valor = STATMENT_MONEDA.TiposSelectedValue; }
                else
                {
                    Presenter.STATMENT_MONEDA.PARA_Valor = null;
                    errorProvider1.SetError(STATMENT_MONEDA, "Debe seleccionar un tipo de moneda"); isCorrect = false;
                }
                if (TDI_004SINRUC.TiposSelectedItem != null)
                { Presenter.TDI_004SINRUC.PARA_Valor = String.Format("{0}-{1}", TDI_004SINRUC.TiposSelectedItem.TIPO_CodTabla, TDI_004SINRUC.TiposSelectedItem.TIPO_CodTipo); }
                else
                {
                    Presenter.TDI_004SINRUC.PARA_Valor = null;
                    errorProvider1.SetError(TDI_004SINRUC, "Debe seleccionar un tipo de doc"); isCorrect = false;
                }

                if (!String.IsNullOrEmpty(IMPUser.Text))
                { Presenter.IMP.PARA_Clave = IMPUser.Text; }
                else
                { Presenter.IMP.PARA_Clave = null; errorProvider1.SetError(IMPUser, "Debe ingresar un Valor"); isCorrect = false; }
                if (!String.IsNullOrEmpty(IMPRuta.Text))
                { Presenter.IMP.PARA_Valor = IMPRuta.Text; }
                else
                { Presenter.IMP.PARA_Valor = String.Empty; }

                if (PAIS_MANDATO.TiposSelectedItem != null)
                { Presenter.PAIS_MANDATO.PARA_Valor = PAIS_MANDATO.TiposSelectedValue; }
                else
                {
                    Presenter.PAIS_MANDATO.PARA_Valor = null;
                    errorProvider1.SetError(PAIS_MANDATO, "Debe seleccionar un Pais"); isCorrect = false;
                }
                if (PUERTO_SHANGHAI.SelectedItem != null)
                { Presenter.PUERTO_SHANGHAI.PARA_Valor = PUERTO_SHANGHAI.SelectedItem.PUER_Codigo.ToString(); }
                else
                { Presenter.PUERTO_SHANGHAI.PARA_Valor = null; errorProvider1.SetError(PUERTO_SHANGHAI, "Debe escoger un puerto"); isCorrect = false; }
                if (PUERTO_CALLAO.SelectedItem != null)
                { Presenter.PUERTO_CALLAO.PARA_Valor = PUERTO_CALLAO.SelectedItem.PUER_Codigo.ToString(); }
                else
                { Presenter.PUERTO_CALLAO.PARA_Valor = null; errorProvider1.SetError(PUERTO_CALLAO, "Debe escoger un puerto"); isCorrect = false; }

                if (cmbPACK_Codigo.ComboSelectedItem != null && cmbPACK_Codigo.ComboSelectedItem.IntCodigo.HasValue)
                { Presenter.PACK_LCL.PARA_Valor = cmbPACK_Codigo.ComboSelectedItem.IntCodigo.Value.ToString(); }
                else
                { Presenter.PACK_LCL.PARA_Valor = null; }

                #endregion

                #region [ Aduanas ]
                if (!String.IsNullOrEmpty(RUTA_SDA.Text))
                { Presenter.RUTA_SDA.PARA_Valor = RUTA_SDA.Text; }
                else
                { Presenter.RUTA_SDA.PARA_Valor = null; errorProvider1.SetError(RUTA_SDA, "Debe ingresar una ruta"); isCorrect = false; }
                if (!String.IsNullOrEmpty(RUTA_TELEDESPACHO.Text))
                { Presenter.RUTA_TELEDESPACHO.PARA_Valor = RUTA_TELEDESPACHO.Text; }
                else
                { Presenter.RUTA_TELEDESPACHO.PARA_Valor = null; errorProvider1.SetError(RUTA_TELEDESPACHO, "Debe ingresar una ruta"); isCorrect = false; }
                #endregion

                #region [ Contabilidad ]

                #region [ Cuentas ]
                if (!String.IsNullOrEmpty(CUENTA_IGV.Text))
                { Presenter.CUENTA_IGV.PARA_Valor = CUENTA_IGV.Text; }
                else
                { Presenter.CUENTA_IGV.PARA_Valor = null; errorProvider1.SetError(CUENTA_IGV, "Debe ingresar una cuenta IGV"); isCorrect = false; }

                if (!String.IsNullOrEmpty(CUENTA_VTA_S.Text) && !String.IsNullOrEmpty(CUENTA_VTA_D.Text))
                { Presenter.CUENTA_VTA.PARA_Valor = String.Format("{0}|{1}", CUENTA_VTA_S.Text, CUENTA_VTA_D.Text); }
                else
                {
                    if (String.IsNullOrEmpty(CUENTA_VTA_S.Text)) { Presenter.CUENTA_VTA.PARA_Valor = null; errorProvider1.SetError(CUENTA_VTA_S, "Debe ingresar una Cuenta de venta Soles"); isCorrect = false; }
                    if (String.IsNullOrEmpty(CUENTA_VTA_D.Text)) { Presenter.CUENTA_VTA.PARA_Valor = null; errorProvider1.SetError(CUENTA_VTA_D, "Debe ingresar una Cuenta de venta Dólares"); isCorrect = false; }
                }

                if (!String.IsNullOrEmpty(CUENTA_COM_S.Text) && !String.IsNullOrEmpty(CUENTA_COM_D.Text))
                { Presenter.CUENTA_COM.PARA_Valor = String.Format("{0}|{1}", CUENTA_COM_S.Text, CUENTA_COM_D.Text); }
                else
                {
                    if (String.IsNullOrEmpty(CUENTA_COM_S.Text)) { Presenter.CUENTA_COM.PARA_Valor = null; errorProvider1.SetError(CUENTA_COM_S, "Debe ingresar una Cuenta de compra Soles"); isCorrect = false; }
                    if (String.IsNullOrEmpty(CUENTA_COM_D.Text)) { Presenter.CUENTA_COM.PARA_Valor = null; errorProvider1.SetError(CUENTA_COM_D, "Debe ingresar una Cuenta de compra Dólares"); isCorrect = false; }
                }
                #endregion

                #region [ Cuentas Diferidas ]
                if (!String.IsNullOrEmpty(CUENTA_IGV_DIF_S.Text) && !String.IsNullOrEmpty(CUENTA_IGV_DIF_D.Text))
                { Presenter.CUENTA_IGV_DIF.PARA_Valor = String.Format("{0}|{1}", CUENTA_IGV_DIF_S.Text, CUENTA_IGV_DIF_D.Text); }
                else
                {
                    if (String.IsNullOrEmpty(CUENTA_IGV_DIF_S.Text)) { Presenter.CUENTA_IGV_DIF.PARA_Valor = null; errorProvider1.SetError(CUENTA_IGV_DIF_S, "Debe ingresar una cuenta IGV Diferido Soles"); isCorrect = false; }
                    if (String.IsNullOrEmpty(CUENTA_IGV_DIF_D.Text)) { Presenter.CUENTA_IGV_DIF.PARA_Valor = null; errorProvider1.SetError(CUENTA_IGV_DIF_D, "Debe ingresar una cuenta IGV Diferido Dolares"); isCorrect = false; }
                }

                if (!String.IsNullOrEmpty(CUENTA_VTA_DIF_S.Text) && !String.IsNullOrEmpty(CUENTA_VTA_DIF_D.Text))
                { Presenter.CUENTA_VTA_DIF.PARA_Valor = String.Format("{0}|{1}", CUENTA_VTA_DIF_S.Text, CUENTA_VTA_DIF_D.Text); }
                else
                {
                    if (String.IsNullOrEmpty(CUENTA_VTA_DIF_S.Text)) { Presenter.CUENTA_VTA_DIF.PARA_Valor = null; errorProvider1.SetError(CUENTA_VTA_DIF_S, "Debe ingresar una Cuenta de venta diferido Soles"); isCorrect = false; }
                    if (String.IsNullOrEmpty(CUENTA_VTA_DIF_D.Text)) { Presenter.CUENTA_VTA_DIF.PARA_Valor = null; errorProvider1.SetError(CUENTA_VTA_DIF_D, "Debe ingresar una Cuenta de venta diferido Dólares"); isCorrect = false; }
                }

                if (!String.IsNullOrEmpty(CUENTA_COM_DIF_S.Text) && !String.IsNullOrEmpty(CUENTA_COM_DIF_D.Text))
                { Presenter.CUENTA_COM_DIF.PARA_Valor = String.Format("{0}|{1}", CUENTA_COM_DIF_S.Text, CUENTA_COM_DIF_D.Text); }
                else
                {
                    if (String.IsNullOrEmpty(CUENTA_COM_DIF_S.Text)) { Presenter.CUENTA_COM_DIF.PARA_Valor = null; errorProvider1.SetError(CUENTA_COM_DIF_S, "Debe ingresar una Cuenta de compra diferido Soles"); isCorrect = false; }
                    if (String.IsNullOrEmpty(CUENTA_COM_DIF_D.Text)) { Presenter.CUENTA_COM_DIF.PARA_Valor = null; errorProvider1.SetError(CUENTA_COM_DIF_D, "Debe ingresar una Cuenta de compra diferido Dólares"); isCorrect = false; }
                }
                #endregion



                if (!String.IsNullOrEmpty(CUENTA_OCPP_S.Text) && !String.IsNullOrEmpty(CUENTA_OCPP_D.Text))
                { Presenter.CUENTA_OCPP.PARA_Valor = String.Format("{0}|{1}", CUENTA_OCPP_S.Text, CUENTA_OCPP_D.Text); }
                else
                {
                    if (String.IsNullOrEmpty(CUENTA_OCPP_S.Text)) { Presenter.CUENTA_OCPP.PARA_Valor = null; errorProvider1.SetError(CUENTA_OCPP_S, "Debe ingresar una Cuenta de Otras Cta x Pagar"); isCorrect = false; }
                    if (String.IsNullOrEmpty(CUENTA_OCPP_D.Text)) { Presenter.CUENTA_OCPP.PARA_Valor = null; errorProvider1.SetError(CUENTA_OCPP_D, "Debe ingresar una Cuenta de Otras Cta x Pagar"); isCorrect = false; }
                }

                if (!String.IsNullOrEmpty(CUENTA_OCPC_S.Text) && !String.IsNullOrEmpty(CUENTA_OCPC_D.Text))
                { Presenter.CUENTA_OCPC.PARA_Valor = String.Format("{0}|{1}", CUENTA_OCPC_S.Text, CUENTA_OCPC_D.Text); }
                else
                {
                    if (String.IsNullOrEmpty(CUENTA_OCPC_S.Text)) { Presenter.CUENTA_OCPC.PARA_Valor = null; errorProvider1.SetError(CUENTA_OCPC_S, "Debe ingresar una Cuenta de Otras Cta x Cobrar"); isCorrect = false; }
                    if (String.IsNullOrEmpty(CUENTA_OCPC_D.Text)) { Presenter.CUENTA_OCPC.PARA_Valor = null; errorProvider1.SetError(CUENTA_OCPC_D, "Debe ingresar una Cuenta de Otras Cta x Cobrar"); isCorrect = false; }
                }

                if (!String.IsNullOrEmpty(CUENTA_CC_CHDIF_S.Text) && !String.IsNullOrEmpty(CUENTA_CC_CHDIF_D.Text))
                { Presenter.CUENTA_CC_CHDIF.PARA_Valor = String.Format("{0}|{1}", CUENTA_CC_CHDIF_S.Text, CUENTA_CC_CHDIF_D.Text); }
                else
                {
                    if (String.IsNullOrEmpty(CUENTA_CC_CHDIF_S.Text)) { Presenter.CUENTA_CC_CHDIF.PARA_Valor = null; errorProvider1.SetError(CUENTA_CC_CHDIF_S, "Debe ingresar una Cuenta por Cobrar Cheque Diferido"); isCorrect = false; }
                    if (String.IsNullOrEmpty(CUENTA_CC_CHDIF_D.Text)) { Presenter.CUENTA_CC_CHDIF.PARA_Valor = null; errorProvider1.SetError(CUENTA_CC_CHDIF_D, "Debe ingresar una Cuenta por Cobrar Cheque Diferido"); isCorrect = false; }
                }

                if (!String.IsNullOrEmpty(CUENTA_CP_CHDIF_S.Text) && !String.IsNullOrEmpty(CUENTA_CP_CHDIF_D.Text))
                { Presenter.CUENTA_CP_CHDIF.PARA_Valor = String.Format("{0}|{1}", CUENTA_CP_CHDIF_S.Text, CUENTA_CP_CHDIF_D.Text); }
                else
                {
                    if (String.IsNullOrEmpty(CUENTA_CP_CHDIF_S.Text)) { Presenter.CUENTA_CP_CHDIF.PARA_Valor = null; errorProvider1.SetError(CUENTA_CP_CHDIF_S, "Debe ingresar una Cuenta por Cobrar Cheque Diferido"); isCorrect = false; }
                    if (String.IsNullOrEmpty(CUENTA_CP_CHDIF_D.Text)) { Presenter.CUENTA_CP_CHDIF.PARA_Valor = null; errorProvider1.SetError(CUENTA_CP_CHDIF_D, "Debe ingresar una Cuenta por Cobrar Cheque Diferido"); isCorrect = false; }
                }

                if (!String.IsNullOrEmpty(CUENTA_COSTO_DIF_S.Text) && !String.IsNullOrEmpty(CUENTA_COSTO_DIF_D.Text))
                { Presenter.CUENTA_COSTO_DIF.PARA_Valor = String.Format("{0}|{1}", CUENTA_COSTO_DIF_S.Text, CUENTA_COSTO_DIF_D.Text); }
                else
                {
                    if (String.IsNullOrEmpty(CUENTA_COSTO_DIF_S.Text)) { Presenter.CUENTA_COSTO_DIF.PARA_Valor = null; errorProvider1.SetError(CUENTA_COSTO_DIF_S, "Debe ingresar una Cuenta por Cobrar Cheque Diferido"); isCorrect = false; }
                    if (String.IsNullOrEmpty(CUENTA_COSTO_DIF_D.Text)) { Presenter.CUENTA_COSTO_DIF.PARA_Valor = null; errorProvider1.SetError(CUENTA_COSTO_DIF_D, "Debe ingresar una Cuenta por Cobrar Cheque Diferido"); isCorrect = false; }
                }

                /*-- 30/01/2017 --*/

                if (!String.IsNullOrEmpty(CUENTA_CC_DIF_V_S.Text) && !String.IsNullOrEmpty(CUENTA_CC_DIF_V_D.Text))
                { Presenter.CUENTA_CC_DIF_V.PARA_Valor = String.Format("{0}|{1}", CUENTA_CC_DIF_V_S.Text, CUENTA_CC_DIF_V_D.Text); }
                else
                {
                    if (String.IsNullOrEmpty(CUENTA_CC_DIF_V_S.Text)) { Presenter.CUENTA_CC_DIF_V.PARA_Valor = null; errorProvider1.SetError(CUENTA_CC_DIF_V_S, "Debe ingresar una Cuenta por Cobrar Cheque Diferido"); isCorrect = false; }
                    if (String.IsNullOrEmpty(CUENTA_CC_DIF_V_D.Text)) { Presenter.CUENTA_CC_DIF_V.PARA_Valor = null; errorProvider1.SetError(CUENTA_CC_DIF_V_D, "Debe ingresar una Cuenta por Cobrar Cheque Diferido"); isCorrect = false; }
                }

                if (!String.IsNullOrEmpty(CUENTA_CP_DIF_V_S.Text) && !String.IsNullOrEmpty(CUENTA_CP_DIF_V_D.Text))
                { Presenter.CUENTA_CP_DIF_V.PARA_Valor = String.Format("{0}|{1}", CUENTA_CP_DIF_V_S.Text, CUENTA_CP_DIF_V_D.Text); }
                else
                {
                    if (String.IsNullOrEmpty(CUENTA_CP_DIF_V_S.Text)) { Presenter.CUENTA_CP_DIF_V.PARA_Valor = null; errorProvider1.SetError(CUENTA_CP_DIF_V_S, "Debe ingresar una Cuenta por Cobrar Cheque Diferido"); isCorrect = false; }
                    if (String.IsNullOrEmpty(CUENTA_CP_DIF_V_D.Text)) { Presenter.CUENTA_CP_DIF_V.PARA_Valor = null; errorProvider1.SetError(CUENTA_CP_DIF_V_D, "Debe ingresar una Cuenta por Cobrar Cheque Diferido"); isCorrect = false; }
                }

                if (!String.IsNullOrEmpty(CUENTA_COS_DIF_OT_S.Text) && !String.IsNullOrEmpty(CUENTA_COS_DIF_OT_D.Text))
                { Presenter.CUENTA_COS_DIF_OT.PARA_Valor = String.Format("{0}|{1}", CUENTA_COS_DIF_OT_S.Text, CUENTA_COS_DIF_OT_D.Text); }
                else
                {
                    if (String.IsNullOrEmpty(CUENTA_COS_DIF_OT_S.Text)) { Presenter.CUENTA_COS_DIF_OT.PARA_Valor = null; errorProvider1.SetError(CUENTA_CP_DIF_V_S, "Debe ingresar una para Compras Diferidas de Otros Traficos"); isCorrect = false; }
                    if (String.IsNullOrEmpty(CUENTA_COS_DIF_OT_D.Text)) { Presenter.CUENTA_COS_DIF_OT.PARA_Valor = null; errorProvider1.SetError(CUENTA_CP_DIF_V_D, "Debe ingresar una para Compras Diferidas de Otros Traficos"); isCorrect = false; }
                }

                #endregion

                #region [ Contabilidad (+)]

                if (!String.IsNullOrEmpty(TR_RCOMPRAS.Text))
                { Presenter.TR_RCOMPRAS.PARA_Valor = TR_RCOMPRAS.Text; }
                else
                { Presenter.TR_RCOMPRAS.PARA_Valor = null; errorProvider1.SetError(TR_RCOMPRAS, "Debe el codigo del libro Compras"); isCorrect = false; }

                if (!String.IsNullOrEmpty(TR_RVENTAS.Text))
                { Presenter.TR_RVENTAS.PARA_Valor = TR_RVENTAS.Text; }
                else
                { Presenter.TR_RVENTAS.PARA_Valor = null; errorProvider1.SetError(TR_RVENTAS, "Debe el codigo del libro Ventas"); isCorrect = false; }

                if (!String.IsNullOrEmpty(TR_RCAJA.Text))
                { Presenter.TR_RCAJA.PARA_Valor = TR_RCAJA.Text; }
                else
                { Presenter.TR_RCAJA.PARA_Valor = null; errorProvider1.SetError(TR_RCAJA, "Debe el codigo del libro Caja"); isCorrect = false; }

                if (!String.IsNullOrEmpty(TR_DGENERAL.Text))
                { Presenter.TR_DGENERAL.PARA_Valor = TR_DGENERAL.Text; }
                else
                { Presenter.TR_DGENERAL.PARA_Valor = null; errorProvider1.SetError(TR_DGENERAL, "Debe el codigo del libro Diario"); isCorrect = false; }

                if (!String.IsNullOrEmpty(TR_LPLANILLA.Text))
                { Presenter.TR_LPLANILLA.PARA_Valor = TR_LPLANILLA.Text; }
                else
                { Presenter.TR_LPLANILLA.PARA_Valor = null; errorProvider1.SetError(TR_LPLANILLA, "Debe el codigo del libro Planillas"); isCorrect = false; }

                if (!String.IsNullOrEmpty(TR_RCDMANDATO.Text))
                { Presenter.TR_RCDMANDATO.PARA_Valor = TR_RCDMANDATO.Text; }
                else
                { Presenter.TR_RCDMANDATO.PARA_Valor = null; errorProvider1.SetError(TR_RCDMANDATO, "Debe el codigo del libro Mandato"); isCorrect = false; }

                if (!String.IsNullOrEmpty(TR_RCDSTATEMENT.Text))
                { Presenter.TR_RCDSTATEMENT.PARA_Valor = TR_RCDSTATEMENT.Text; }
                else
                { Presenter.TR_RCDSTATEMENT.PARA_Valor = null; errorProvider1.SetError(TR_RCDSTATEMENT, "Debe el codigo del libro Otros Traficos"); isCorrect = false; }

                if (!String.IsNullOrEmpty(TR_RLDIARIO.Text))
                { Presenter.TR_RLDIARIO.PARA_Valor = TR_RLDIARIO.Text; }
                else
                { Presenter.TR_RLDIARIO.PARA_Valor = null; errorProvider1.SetError(TR_RLDIARIO, "Libros de Mandato"); isCorrect = false; }

                if (!String.IsNullOrEmpty(GAS_DOc_PEN.Text))
                { Presenter.GAS_DOc_PEN.PARA_Valor = GAS_DOc_PEN.Text; }
                else
                { Presenter.GAS_DOc_PEN.PARA_Valor = null; errorProvider1.SetError(GAS_DOc_PEN, "Debe el codigo para el numero de documento a enviar al diario"); isCorrect = false; }

                if (!String.IsNullOrEmpty(RUC_DC.Text))
                { Presenter.RUC_DC.PARA_Valor = RUC_DC.Text; }
                else
                { Presenter.RUC_DC.PARA_Valor = null; errorProvider1.SetError(RUC_DC, "Debe el RUC de Delfin Collecting"); isCorrect = false; }

                if (!String.IsNullOrEmpty(RUC_DG.Text))
                { Presenter.RUC_DG.PARA_Valor = RUC_DG.Text; }
                else
                { Presenter.RUC_DG.PARA_Valor = null; errorProvider1.SetError(RUC_DG, "Debe el RUC de Delfin Group"); isCorrect = false; }

                if (!String.IsNullOrEmpty(CTAS_MANDATO.Text))
                { Presenter.CTAS_MANDATO.PARA_Valor = CTAS_MANDATO.Text; }
                else
                { Presenter.CTAS_MANDATO.PARA_Valor = null; errorProvider1.SetError(CTAS_MANDATO, "Debe Seleccionar las cuentas de Mandato"); isCorrect = false; }

                if (!String.IsNullOrEmpty(TDO_A_DIARIO.Text))
                { Presenter.TDO_A_DIARIO.PARA_Valor = TDO_A_DIARIO.Text; }
                else
                { Presenter.TDO_A_DIARIO.PARA_Valor = null; errorProvider1.SetError(TDO_A_DIARIO, "Debe seleccionar los codigos de tipos de documentos"); isCorrect = false; }

                if (!String.IsNullOrEmpty(SERV_FL_AJUSTE_OP.Text))
                { Presenter.SERV_FL_AJUSTE_OP.PARA_Valor = SERV_FL_AJUSTE_OP.Text; }
                else
                { Presenter.SERV_FL_AJUSTE_OP.PARA_Valor = null; errorProvider1.SetError(SERV_FL_AJUSTE_OP, "Debe Seleccionar los servicios de Ajuste"); isCorrect = false; }

                if (!String.IsNullOrEmpty(GAS_DOc_PENDIENTE.Text))
                { Presenter.GAS_DOc_PENDIENTE.PARA_Valor = GAS_DOc_PENDIENTE.Text; }
                else
                { Presenter.GAS_DOc_PENDIENTE.PARA_Valor = null; errorProvider1.SetError(GAS_DOc_PENDIENTE, "Debe Ingresar el codigo para el numero de documento a enviar al diario"); isCorrect = false; }

                if (!String.IsNullOrEmpty(TR_CIERR_001.Text))
                { Presenter.TR_CIERR_001.PARA_Valor = TR_CIERR_001.Text; }
                else
                { Presenter.TR_CIERR_001.PARA_Valor = null; errorProvider1.SetError(TR_CIERR_001, "Debe seleccionar el Periodo Bloqueo para este Libro de Compras"); isCorrect = false; }

                if (!String.IsNullOrEmpty(TR_CIERR_002.Text))
                { Presenter.TR_CIERR_002.PARA_Valor = TR_CIERR_002.Text; }
                else
                { Presenter.TR_CIERR_002.PARA_Valor = null; errorProvider1.SetError(TR_CIERR_002, "Debe seleccionar el Periodo Bloqueo para este Libro de Ventas"); isCorrect = false; }

                if (!String.IsNullOrEmpty(TR_CIERR_003.Text))
                { Presenter.TR_CIERR_003.PARA_Valor = TR_CIERR_003.Text; }
                else
                { Presenter.TR_CIERR_003.PARA_Valor = null; errorProvider1.SetError(TR_CIERR_003, "Debe seleccionar el Periodo Bloqueo para este Libro de Caja"); isCorrect = false; }

                if (!String.IsNullOrEmpty(TR_CIERR_004.Text))
                { Presenter.TR_CIERR_004.PARA_Valor = TR_CIERR_004.Text; }
                else
                { Presenter.TR_CIERR_004.PARA_Valor = null; errorProvider1.SetError(TR_CIERR_004, "Debe seleccionar el Periodo Bloqueo para este Libro de Diario"); isCorrect = false; }

                if (!String.IsNullOrEmpty(TR_CIERR_005.Text))
                { Presenter.TR_CIERR_005.PARA_Valor = TR_CIERR_005.Text; }
                else
                { Presenter.TR_CIERR_005.PARA_Valor = null; errorProvider1.SetError(TR_CIERR_005, "Debe seleccionar el Periodo Bloqueo para este Libro de Planilla"); isCorrect = false; }

                if (!String.IsNullOrEmpty(TR_CIERR_006.Text))
                { Presenter.TR_CIERR_006.PARA_Valor = TR_CIERR_006.Text; }
                else
                { Presenter.TR_CIERR_006.PARA_Valor = null; errorProvider1.SetError(TR_CIERR_006, "Debe seleccionar el Periodo Bloqueo para este Libro de Mandato"); isCorrect = false; }

                if (!String.IsNullOrEmpty(TR_CIERR_007.Text))
                { Presenter.TR_CIERR_007.PARA_Valor = TR_CIERR_007.Text; }
                else
                { Presenter.TR_CIERR_007.PARA_Valor = null; errorProvider1.SetError(TR_CIERR_007, "Debe seleccionar el Periodo Bloqueo para este Libro de Otros Traficos"); isCorrect = false; }

                #endregion

                #region [ Glosa ]
                if (!string.IsNullOrEmpty(FC_EXONERADO.Text))
                { Presenter.FC_EXONERADO.PARA_Valor = FC_EXONERADO.Text; }
                else
                { Presenter.FC_EXONERADO.PARA_Valor = null; errorProvider1.SetError(FC_EXONERADO, "Debe ingresar una Glosa"); isCorrect = false; }
                if (!string.IsNullOrEmpty(FC_OPSUJETAPOT.Text))
                { Presenter.FC_OPSUJETAPOT.PARA_Valor = FC_OPSUJETAPOT.Text; }
                else
                { Presenter.FC_OPSUJETAPOT.PARA_Valor = null; errorProvider1.SetError(FC_OPSUJETAPOT, "Debe ingresar una Glosa"); isCorrect = false; }
                #endregion

                #region [ Facturación ]
                if (!String.IsNullOrEmpty(FAC_TDO.Text))
                { Presenter.FAC_TDO.PARA_Valor = FAC_TDO.Text; }
                else
                { Presenter.FAC_TDO.PARA_Valor = null; errorProvider1.SetError(FAC_TDO, "Debe seleccionar un codigo"); isCorrect = false; }
                if (!String.IsNullOrEmpty(FAC_TDO_OP.Text))
                { Presenter.FAC_TDO_OP.PARA_Valor = FAC_TDO_OP.Text; }
                else
                { Presenter.FAC_TDO_OP.PARA_Valor = null; errorProvider1.SetError(FAC_TDO_OP, "Debe seleccionar un codigo"); isCorrect = false; }
                if (!String.IsNullOrEmpty(FAC_TDO_OV.Text))
                { Presenter.FAC_TDO_OV.PARA_Valor = FAC_TDO_OV.Text; }
                else
                { Presenter.FAC_TDO_OV.PARA_Valor = null; errorProvider1.SetError(FAC_TDO_OV, "Debe seleccionar un codigo"); isCorrect = false; }
                if (!String.IsNullOrEmpty(PREF_TDO_SLI.Text))
                { Presenter.PREF_TDO_SLI.PARA_Valor = PREF_TDO_SLI.Text; }
                else
                { Presenter.PREF_TDO_SLI.PARA_Valor = null; errorProvider1.SetError(PREF_TDO_SLI, "Debe seleccionar un codigo"); isCorrect = false; }

                if (!String.IsNullOrEmpty(PREF_TDO_ILD.Text))
                { Presenter.PREF_TDO_ILD.PARA_Valor = PREF_TDO_ILD.Text; }
                else
                { Presenter.PREF_TDO_ILD.PARA_Valor = null; errorProvider1.SetError(PREF_TDO_ILD, "Debe seleccionar un codigo"); isCorrect = false; }

                if (!String.IsNullOrEmpty(TIPO_TDO_NCS.Text))
                { Presenter.TIPO_TDO_NCS.PARA_Valor = TIPO_TDO_NCS.Text; }
                else
                { Presenter.TIPO_TDO_NCS.PARA_Valor = null; errorProvider1.SetError(TIPO_TDO_NCS, "Debe seleccionar un codigo"); isCorrect = false; }

                #endregion

                #region [ Finanzas ]

                if (DET_DIASDETRACCION.Value > -1)
                { Presenter.DET_DIASDETRACCION.PARA_Valor = DET_DIASDETRACCION.Value.ToString(); }
                else
                { Presenter.DET_DIASDETRACCION.PARA_Valor = null; errorProvider1.SetError(DET_DIASDETRACCION, "Debe Ingresar los dias de detracción"); isCorrect = false; }

                Presenter.DET_REDONDEONORMAL.PARA_Valor = DET_REDONDEONORMAL.Checked ? "1" : "0";

                if (!String.IsNullOrEmpty(CCCT_SERIEDIARIO.Text))
                { Presenter.CCCT_SERIEDIARIO.PARA_Valor = CCCT_SERIEDIARIO.Text; }
                else
                { Presenter.CCCT_SERIEDIARIO.PARA_Valor = null; errorProvider1.SetError(CCCT_SERIEDIARIO, "Debe ingresar la serie de Diario"); isCorrect = false; }

                if (!String.IsNullOrEmpty(CCCT_TIPODOCUMENTO.Text))
                { Presenter.CCCT_TIPODOCUMENTO.PARA_Valor = CCCT_TIPODOCUMENTO.Text; }
                else
                {
                    Presenter.CCCT_TIPODOCUMENTO.PARA_Valor = null;
                    errorProvider1.SetError(CCCT_TIPODOCUMENTO, "Debe seleccionar un Doc. Venta"); isCorrect = false;
                }

                if (!String.IsNullOrEmpty(MOVI_CHQBLANCO.Text))
                { Presenter.MOVI_CHQBLANCO.PARA_Valor = MOVI_CHQBLANCO.Text; }
                else
                {
                    Presenter.MOVI_CHQBLANCO.PARA_Valor = null;
                    errorProvider1.SetError(MOVI_CHQBLANCO, "Tipos Movimiento Cheque en Blanco."); isCorrect = false;
                }

                if (!String.IsNullOrEmpty(TIPO_DES_GBAN.Text))
                { Presenter.TIPO_DES_GBAN.PARA_Valor = String.Format("{0}|{1}", TIPO_DES_GBAN.TiposSelectedItem.TIPO_CodTabla, TIPO_DES_GBAN.SelectedValue.ToString()); }
                else
                {
                    Presenter.TIPO_DES_GBAN.PARA_Valor = null;
                    errorProvider1.SetError(TIPO_DES_GBAN, "Tipo de Gasto Bancario."); isCorrect = false;
                }

                if (!String.IsNullOrEmpty(TIPO_MOV_DESDIF.Text))
                { Presenter.TIPO_MOV_DESDIF.PARA_Valor = TIPO_MOV_DESDIF.Text; }
                else
                {
                    Presenter.TIPO_MOV_DESDIF.PARA_Valor = null;
                    errorProvider1.SetError(TIPO_MOV_DESDIF, "Destino de Documento Diferido."); isCorrect = false;
                }

                if (!String.IsNullOrEmpty(TIPO_TDO_OVDG.Text))
                { Presenter.TIPO_TDO_OVDG.PARA_Valor = TIPO_TDO_OVDG.Text; }
                else
                {
                    Presenter.TIPO_TDO_OVDG.PARA_Valor = null;
                    errorProvider1.SetError(TIPO_TDO_OVDG, "Tipos De Documento OV para Docs Diferidos.."); isCorrect = false;
                }

                if (!String.IsNullOrEmpty(CUENTA_DCHINA.Text))
                { Presenter.CUENTA_DCHINA.PARA_Valor = CUENTA_DCHINA.Text; }
                else
                {
                    Presenter.CUENTA_DCHINA.PARA_Valor = null;
                    errorProvider1.SetError(CUENTA_DCHINA, "Cuenta de Mandato - Delfin China."); isCorrect = false;
                }

                if (!String.IsNullOrEmpty(RUC_DCHINA.Text))
                { Presenter.RUC_DCHINA.PARA_Valor = RUC_DCHINA.Text; }
                else
                {
                    Presenter.RUC_DCHINA.PARA_Valor = null;
                    errorProvider1.SetError(RUC_DCHINA, "RUC - Delfin China."); isCorrect = false;
                }
                #endregion

                return isCorrect;
            }
            catch (Exception ex)
            {
                Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, Infrastructure.Aspect.Constants.Mensajes.GetItem, ex);
                return false;
            }
        }
        public void SetItem()
        {
            try
            {
                #region [ Parametros KPIs ]
                KPI001MIN.Text = Presenter.KPI001MIN.PARA_Valor.ToString();
                KPI001MAX.Text = Presenter.KPI001MAX.PARA_Valor.ToString();

                KPI002MIN.Text = Presenter.KPI002MIN.PARA_Valor.ToString();
                KPI002MAX.Text = Presenter.KPI002MAX.PARA_Valor.ToString();

                var _resultado = Presenter.ListResultGestion.Where(resg => resg.RESG_Codigo == Int16.Parse(Presenter.KPI002RESG.PARA_Valor)).FirstOrDefault();
                TipoRESG_Codigo.ComboIntSelectedValue = _resultado.RESG_PositivoNegativo;
                KPI002RESG.SelectedValue = _resultado.RESG_Codigo;

                KPI003MIN.Text = Presenter.KPI003MIN.PARA_Valor.ToString();
                KPI003MAX.Text = Presenter.KPI003MAX.PARA_Valor.ToString();

                KPI004MIN.Text = Presenter.KPI004MIN.PARA_Valor.ToString();
                KPI004MAX.Text = Presenter.KPI004MAX.PARA_Valor.ToString();

                KPI005MIN.Text = Presenter.KPI005MIN.PARA_Valor.ToString();
                KPI005MAX.Text = Presenter.KPI005MAX.PARA_Valor.ToString();
                #endregion

                #region [ Usuarios de Aprobacion ]
                NextAdmin.BusinessLogic.Usuarios _usuario = null;
                _usuario = Presenter.ListUsuarios.Where(usua => usua.USUA_CodUsr == Presenter.USRAPRUEBANIVEL1_JV.PARA_Valor).FirstOrDefault();
                if (_usuario != null)
                {
                    USRAPROBADORNIVEL1_JV.SetValue(_usuario, _usuario.USUA_CodUsr);
                    USRAPROBADORNIVEL1_JVNombre.Text = _usuario.USUA_Nombres;
                }
                _usuario = null;
                _usuario = Presenter.ListUsuarios.Where(usua => usua.USUA_CodUsr == Presenter.USRAPRUEBANIVEL2_GC.PARA_Valor).FirstOrDefault();
                if (_usuario != null)
                {
                    USRAPROBADORNIVEL2_GC.SetValue(_usuario, _usuario.USUA_CodUsr);
                    USRAPROBADORNIVEL2_GCNombre.Text = _usuario.USUA_Nombres;
                }
                _usuario = null;
                _usuario = Presenter.ListUsuarios.Where(usua => usua.USUA_CodUsr == Presenter.USRAPRUEBANIVEL3_GG.PARA_Valor).FirstOrDefault();
                if (_usuario != null)
                {
                    USRAPROBADORNIVEL3_GG.SetValue(_usuario, _usuario.USUA_CodUsr);
                    USRAPROBADORNIVEL3_GGNombre.Text = _usuario.USUA_Nombres;
                }
                #endregion

                #region [ Calculo Comisiones ]
                Decimal _valor;
                if (Decimal.TryParse(Presenter.PROFITPROMTEUS.PARA_Valor, out _valor))
                { PROFITPROMTEUS.Value = _valor; }
                if (Decimal.TryParse(Presenter.COMIVENDEDOR.PARA_Valor, out _valor))
                { COMIVENDEDOR.Value = _valor; }
                if (Decimal.TryParse(Presenter.PROFITMINTEUS.PARA_Valor, out _valor))
                { PROFITMINTEUS.Value = _valor; }
                #endregion

                #region [ Servicios ]
                Int32 _SERV_Codigo;
                if (Int32.TryParse(Presenter.SERVADICIONAL.PARA_Valor, out _SERV_Codigo))
                { SERVADICIONAL.LoadServicio(_SERV_Codigo); }
                if (Int32.TryParse(Presenter.SERVLOGISTICO.PARA_Valor, out _SERV_Codigo))
                { SERVLOGISTICO.LoadServicio(_SERV_Codigo); }
                if (Int32.TryParse(Presenter.SERVOTROS.PARA_Valor, out _SERV_Codigo))
                { SERVOTROS.LoadServicio(_SERV_Codigo); }
                if (Int32.TryParse(Presenter.SERVTARJAS.PARA_Valor, out _SERV_Codigo))
                { SERVTARJAS.LoadServicio(_SERV_Codigo); }
                if (Int32.TryParse(Presenter.SERV_OCULTARSHIPPER.PARA_Valor, out _SERV_Codigo))
                { SERV_OCULTARSHIPPER.LoadServicio(_SERV_Codigo); }
                if (Int32.TryParse(Presenter.SERVICIO_REEMBOLSO.PARA_Valor, out _SERV_Codigo))
                { SERVICIO_REEMBOLSO.LoadServicio(_SERV_Codigo); }

                txtSERV_FLETE_GRR.Text = Presenter.SERV_FLETE_GRR.PARA_Valor;
                #endregion

                #region [ Eventos ]
                RELEASEHBL.TiposSelectedValue = Presenter.RELEASEHBL.PARA_Valor;
                BLOQUEAROV.TiposSelectedValue = Presenter.BLOQUEAROV.PARA_Valor;
                DESBLOQUEAROV.TiposSelectedValue = Presenter.DESBLOQUEAROV.PARA_Valor;
                AGREGAREXCEPCIONOV.TiposSelectedValue = Presenter.AGREGAREXCEPCIONOV.PARA_Valor;
                QUITAREXCEPCIONOV.TiposSelectedValue = Presenter.QUITAREXCEPCIONOV.PARA_Valor;
                OVDOCUMENTADA.TiposSelectedValue = Presenter.OVDOCUMENTADA.PARA_Valor;
                DIRECCIONALINEA.TiposSelectedValue = Presenter.DIRECCIONALINEA.PARA_Valor;
                EMAILALMACEN.TiposSelectedValue = Presenter.EMAILALMACEN.PARA_Valor;
                DESGLOSEVoBo.TiposSelectedValue = Presenter.DESGLOSEVoBo.PARA_Valor;
                CARTA_AVISOS.TiposSelectedValue = Presenter.CARTA_AVISOS.PARA_Valor;
                OVCERRADA.TiposSelectedValue = Presenter.CARTA_AVISOS.PARA_Valor;
                APERTURA_STATMENT.TiposSelectedValue = Presenter.APERTURA_STATMENT.PARA_Valor;
                IMPRIMIRHBL.TiposSelectedValue = Presenter.IMPRIMIRHBL.PARA_Valor;
                PRE_ALERTA.TiposSelectedValue = Presenter.PRE_ALERTA.PARA_Valor;
                EVE_PREFACTURAR.TiposSelectedValue = Presenter.EVE_PREFACTURAR.PARA_Valor;
                EMITIR_STATEMENT.TiposSelectedValue = Presenter.EMITIR_STATEMENT.PARA_Valor;
                DEVOLUCION_MASTER.TiposSelectedValue = Presenter.DEVOLUCION_MASTER.PARA_Valor;
                RECOJO_BLs.TiposSelectedValue = Presenter.RECOJO_BLs.PARA_Valor;
                SERVICIO_TRANSMISION.TiposSelectedValue = Presenter.SERVICIO_TRANSMISION.PARA_Valor;
                EMISION_SDA.TiposSelectedValue = Presenter.EMISION_SDA.PARA_Valor;
                EMISION_TELEDESPACHO.TiposSelectedValue = Presenter.EMISION_TELEDESPACHO.PARA_Valor;
                EMISION_HBL.TiposSelectedValue = Presenter.EMISION_HBL.PARA_Valor;
                OV_ENTREGADA.TiposSelectedValue = Presenter.OV_ENTREGADA.PARA_Valor;
                #endregion

                #region [ Cod. Entidad ]
                Int32 _ENTC_Codigo;
                if (Int32.TryParse(Presenter.EMPRESA.PARA_Valor, out _ENTC_Codigo))
                { EMPRESA.SetValue(_ENTC_Codigo); }
                if (Int32.TryParse(Presenter.EAGENTE_CHINA.PARA_Valor, out _ENTC_Codigo))
                { EAGENTE_CHINA.SetValue(_ENTC_Codigo); }
                if (Int32.TryParse(Presenter.EAGENTE_SHANGHAI.PARA_Valor, out _ENTC_Codigo))
                { EAGENTE_SHANGHAI.SetValue(_ENTC_Codigo); }
                if (Int32.TryParse(Presenter.CODIGO_TRAMARSA.PARA_Valor, out _ENTC_Codigo))
                { CODIGO_TRAMARSA.SetValue(_ENTC_Codigo); }
                if (Int32.TryParse(Presenter.CODIGO_COSCO_PERU.PARA_Valor, out _ENTC_Codigo))
                { CODIGO_COSCO_PERU.SetValue(_ENTC_Codigo); }
                if (Int32.TryParse(Presenter.CODIGO_HAMBURG_SUD.PARA_Valor, out _ENTC_Codigo))
                { CODIGO_HAMBURG_SUD.SetValue(_ENTC_Codigo); }
                if (Int32.TryParse(Presenter.CODIGO_HAPAG_LLOYD.PARA_Valor, out _ENTC_Codigo))
                { CODIGO_HAPAG_LLOYD.SetValue(_ENTC_Codigo); }
                if (Int32.TryParse(Presenter.EAGENTE_REEMBOLSO.PARA_Valor, out _ENTC_Codigo))
                { EAGENTE_REEMBOLSO.SetValue(_ENTC_Codigo); }
                #endregion

                #region [ Entidad_Relacionados ]
                RTIPO_DTE.Text = Presenter.RTIPO_DTE.PARA_Valor;
                RTIPO_VEN.Text = Presenter.RTIPO_VEN.PARA_Valor;
                RTIPO_CON.Text = Presenter.RTIPO_CON.PARA_Valor;
                RTIPO_DVA.Text = Presenter.RTIPO_DVA.PARA_Valor;
                RTIPO_AGE.Text = Presenter.RTIPO_AGE.PARA_Valor;
                RTIPO_CSE.Text = Presenter.RTIPO_CSE.PARA_Valor;
                EEJECUTIVOS.Text = Presenter.EEJECUTIVOS.PARA_Valor;
                #endregion

                #region [ Correos ]
                CORREO_OPERACIONES.Text = Presenter.CORREO_OPERACIONES.PARA_Valor;
                CORREO_DOCUMENTACION.Text = Presenter.CORREO_DOCUMENTACION.PARA_Valor;
                CORREO_LOGISTICA.Text = Presenter.CORREO_LOGISTICA.PARA_Valor;
                CORREO_CUSTOMER_IMPO.Text = Presenter.CORREO_CUSTOMER_IMPO.PARA_Valor;
                CORREO_CUSTOMER_EXPO.Text = Presenter.CORREO_CUSTOMER_EXPO.PARA_Valor;
                CORREO_FINANZAS.Text = Presenter.CORREO_FINANZAS.PARA_Valor;
                CORREO_FLETAMENTO.Text = Presenter.CORREO_FLETAMENTO.PARA_Valor;
                #endregion

                #region [ Doc. Venta ]
                TIPO_TDO_NC.TiposSelectedValue = Presenter.TIPO_TDO_NC.PARA_Valor;
                TIPO_TDO_PR.TiposSelectedValue = Presenter.TIPO_TDO_PR.PARA_Valor;
                TIPO_TDO_AN.TiposSelectedValue = Presenter.TIPO_TDO_AN.PARA_Valor;
                TIPO_TDO_CN.TiposSelectedValue = Presenter.TIPO_TDO_CN.PARA_Valor;
                #endregion

                #region [ Tipo Cambio ]
                TCCTACTE_CLI.SelectedValue = Presenter.TCCTACTE_CLI.PARA_Valor;
                TCCTACTE_PRO.SelectedValue = Presenter.TCCTACTE_PRO.PARA_Valor;
                #endregion

                #region [ Series ]
                SERIE_CALLO.Text = Presenter.SERIE_CALLO.PARA_Valor;
                SERIE_EXPORTACION.Text = Presenter.SERIE_EXPORTACION.PARA_Valor;
                SERIE_MANDATO.Text = Presenter.SERIE_MANDATO.PARA_Valor;
                SERIE_OTRAFICOS.Text = Presenter.SERIE_OTRAFICOS.PARA_Valor;
                SERIE_SLI.Text = Presenter.SERIE_SLI.PARA_Valor;
                #endregion

                #region [ Planillas ]
                BSItemsPlanillas.DataSource = Presenter.PLANILLAS;
                BSItemsPlanillas.ResetBindings(true);
                grdItemsPlanillas.BestFitColumns();
                #endregion

                #region [ Otros ]
                IGV.Text = Presenter.IGV.PARA_Valor;
                STATMENT_MONEDA.TiposSelectedValue = Presenter.STATMENT_MONEDA.PARA_Valor;
                Char[] delimiterChars = { '-' };
                String[] _items = Presenter.TDI_004SINRUC.PARA_Valor.Split(delimiterChars);
                TDI_004SINRUC.TiposSelectedValue = _items[1];
                if (!String.IsNullOrEmpty(Presenter.IMP.PARA_Clave))
                { IMPUser.Text = Presenter.IMP.PARA_Clave; }
                else
                { IMPUser.Text = String.Format("IMP-{0}", Presenter.Session.UserName); }
                IMPRuta.Text = Presenter.IMP.PARA_Valor;
                PAIS_MANDATO.TiposSelectedValue = Presenter.PAIS_MANDATO.PARA_Valor;
                Int32 _PUER_Codigo;
                if (Int32.TryParse(Presenter.PUERTO_SHANGHAI.PARA_Valor, out _PUER_Codigo))
                { PUERTO_SHANGHAI.SelectedValue = _PUER_Codigo; }
                Int32 _PUER_Callao;
                if (Int32.TryParse(Presenter.PUERTO_CALLAO.PARA_Valor, out _PUER_Callao))
                { PUERTO_CALLAO.SelectedValue = _PUER_Callao; }

                Int32 _PACK_LCL;
                if (!String.IsNullOrEmpty(Presenter.PACK_LCL.PARA_Valor) && Int32.TryParse(Presenter.PACK_LCL.PARA_Valor, out _PACK_LCL))
                { cmbPACK_Codigo.ComboIntSelectedValue = _PACK_LCL; }
                #endregion

                #region [ Aduanas ]
                RUTA_SDA.Text = Presenter.RUTA_SDA.PARA_Valor;
                RUTA_TELEDESPACHO.Text = Presenter.RUTA_TELEDESPACHO.PARA_Valor;
                #endregion

                #region [ Cuentas ]
                CUENTA_IGV.Text = Presenter.CUENTA_IGV.PARA_Valor;

                String[] _Cuentas = new String[2];
                if (Presenter.CUENTA_VTA.PARA_Valor != null)
                { _Cuentas = Presenter.CUENTA_VTA.PARA_Valor.Split('|'); }
                else
                { _Cuentas[0] = String.Empty; _Cuentas[1] = String.Empty; }
                CUENTA_VTA_S.Text = _Cuentas[0];
                CUENTA_VTA_D.Text = _Cuentas[1];

                //String[] _Cuentas = new String[2];
                if (Presenter.CUENTA_COM.PARA_Valor != null)
                { _Cuentas = Presenter.CUENTA_COM.PARA_Valor.Split('|'); }
                else
                { _Cuentas[0] = String.Empty; _Cuentas[1] = String.Empty; }
                CUENTA_COM_S.Text = _Cuentas[0];
                CUENTA_COM_D.Text = _Cuentas[1];
                #endregion

                #region [ Cuentas Diferidos ]
                String[] _CuentasDif = new String[2];
                if (!String.IsNullOrEmpty(Presenter.CUENTA_IGV_DIF.PARA_Valor))
                { _CuentasDif = Presenter.CUENTA_IGV_DIF.PARA_Valor.Split('|'); }
                else
                { _CuentasDif[0] = String.Empty; _CuentasDif[1] = String.Empty; }
                CUENTA_IGV_DIF_S.Text = _CuentasDif[0];
                CUENTA_IGV_DIF_D.Text = _CuentasDif[1];

                if (!String.IsNullOrEmpty(Presenter.CUENTA_VTA_DIF.PARA_Valor))
                { _Cuentas = Presenter.CUENTA_VTA_DIF.PARA_Valor.Split('|'); }
                else
                { _Cuentas[0] = String.Empty; _Cuentas[1] = String.Empty; }
                CUENTA_VTA_DIF_S.Text = _Cuentas[0];
                CUENTA_VTA_DIF_D.Text = _Cuentas[1];

                //String[] _Cuentas = new String[2];
                if (Presenter.CUENTA_COM_DIF.PARA_Valor != null)
                { _Cuentas = Presenter.CUENTA_COM_DIF.PARA_Valor.Split('|'); }
                else
                { _Cuentas[0] = String.Empty; _Cuentas[1] = String.Empty; }
                CUENTA_COM_DIF_S.Text = _Cuentas[0];
                CUENTA_COM_DIF_D.Text = _Cuentas[1];
                #endregion

                /*--------------------------------------------------------------------*/
                if (Presenter.CUENTA_OCPP.PARA_Valor != null)
                { _Cuentas = Presenter.CUENTA_OCPP.PARA_Valor.Split('|'); }
                else
                { _Cuentas[0] = String.Empty; _Cuentas[1] = String.Empty; }
                CUENTA_OCPP_S.Text = _Cuentas[0];
                CUENTA_OCPP_D.Text = _Cuentas[1];

                if (Presenter.CUENTA_OCPC.PARA_Valor != null)
                { _Cuentas = Presenter.CUENTA_OCPC.PARA_Valor.Split('|'); }
                else
                { _Cuentas[0] = String.Empty; _Cuentas[1] = String.Empty; }
                CUENTA_OCPC_S.Text = _Cuentas[0];
                CUENTA_OCPC_D.Text = _Cuentas[1];

                /*--------------------------------------------------------------------*/
                if (Presenter.CUENTA_CC_CHDIF.PARA_Valor != null)
                { _Cuentas = Presenter.CUENTA_CC_CHDIF.PARA_Valor.Split('|'); }
                else
                { _Cuentas[0] = String.Empty; _Cuentas[1] = String.Empty; }
                CUENTA_CC_CHDIF_S.Text = _Cuentas[0];
                CUENTA_CC_CHDIF_D.Text = _Cuentas[1];

                if (Presenter.CUENTA_CP_CHDIF.PARA_Valor != null)
                { _Cuentas = Presenter.CUENTA_CP_CHDIF.PARA_Valor.Split('|'); }
                else
                { _Cuentas[0] = String.Empty; _Cuentas[1] = String.Empty; }
                CUENTA_CP_CHDIF_S.Text = _Cuentas[0];
                CUENTA_CP_CHDIF_D.Text = _Cuentas[1];
                /*--------------------------------------------------------------------*/
                if (Presenter.CUENTA_COSTO_DIF.PARA_Valor != null)
                { _Cuentas = Presenter.CUENTA_COSTO_DIF.PARA_Valor.Split('|'); }
                else
                { _Cuentas[0] = String.Empty; _Cuentas[1] = String.Empty; }
                CUENTA_COSTO_DIF_S.Text = _Cuentas[0];
                CUENTA_COSTO_DIF_D.Text = _Cuentas[1];
                /*-- 30/01/2017 ------------------------------------------------------------------*/

                if (Presenter.CUENTA_CC_DIF_V.PARA_Valor != null)
                { _Cuentas = Presenter.CUENTA_CC_DIF_V.PARA_Valor.Split('|'); }
                else
                { _Cuentas[0] = String.Empty; _Cuentas[1] = String.Empty; }
                CUENTA_CC_DIF_V_S.Text = _Cuentas[0];
                CUENTA_CC_DIF_V_D.Text = _Cuentas[1];

                if (Presenter.CUENTA_CP_DIF_V.PARA_Valor != null)
                { _Cuentas = Presenter.CUENTA_CP_DIF_V.PARA_Valor.Split('|'); }
                else
                { _Cuentas[0] = String.Empty; _Cuentas[1] = String.Empty; }
                CUENTA_CP_DIF_V_S.Text = _Cuentas[0];
                CUENTA_CP_DIF_V_D.Text = _Cuentas[1];

                if (Presenter.CUENTA_COS_DIF_OT.PARA_Valor != null)
                { _Cuentas = Presenter.CUENTA_COS_DIF_OT.PARA_Valor.Split('|'); }
                else
                { _Cuentas[0] = String.Empty; _Cuentas[1] = String.Empty; }
                CUENTA_COS_DIF_OT_S.Text = _Cuentas[0];
                CUENTA_COS_DIF_OT_D.Text = _Cuentas[1];

                //this.CUENTA_COS_DIF_OT.Text = Presenter.CUENTA_COS_DIF_OT.PARA_Valor;

                /*-- 23/02/2017 ------------------------------------------------------------------*/
                this.TR_RCOMPRAS.Text = Presenter.TR_RCOMPRAS.PARA_Valor;
                this.TR_RVENTAS.Text = Presenter.TR_RVENTAS.PARA_Valor;
                this.TR_RCAJA.Text = Presenter.TR_RCAJA.PARA_Valor;
                this.TR_DGENERAL.Text = Presenter.TR_DGENERAL.PARA_Valor;
                this.TR_LPLANILLA.Text = Presenter.TR_LPLANILLA.PARA_Valor;
                this.TR_RCDMANDATO.Text = Presenter.TR_RCDMANDATO.PARA_Valor;
                this.TR_RCDSTATEMENT.Text = Presenter.TR_RCDSTATEMENT.PARA_Valor;
                this.TR_RLDIARIO.Text = Presenter.TR_RLDIARIO.PARA_Valor;

                this.GAS_DOc_PEN.Text = Presenter.GAS_DOc_PEN.PARA_Valor;
                this.RUC_DC.Text = Presenter.RUC_DC.PARA_Valor;
                this.RUC_DG.Text = Presenter.RUC_DG.PARA_Valor;

                this.CTAS_MANDATO.Text = Presenter.CTAS_MANDATO.PARA_Valor;
                this.TDO_A_DIARIO.Text = Presenter.TDO_A_DIARIO.PARA_Valor;

                this.GAS_DOc_PENDIENTE.Text = Presenter.GAS_DOc_PENDIENTE.PARA_Valor;
                this.SERV_FL_AJUSTE_OP.Text = Presenter.SERV_FL_AJUSTE_OP.PARA_Valor;

                this.TR_CIERR_001.Text = Presenter.TR_CIERR_001.PARA_Valor;
                this.TR_CIERR_002.Text = Presenter.TR_CIERR_002.PARA_Valor;
                this.TR_CIERR_003.Text = Presenter.TR_CIERR_003.PARA_Valor;
                this.TR_CIERR_004.Text = Presenter.TR_CIERR_004.PARA_Valor;
                this.TR_CIERR_005.Text = Presenter.TR_CIERR_005.PARA_Valor;
                this.TR_CIERR_006.Text = Presenter.TR_CIERR_006.PARA_Valor;
                this.TR_CIERR_007.Text = Presenter.TR_CIERR_007.PARA_Valor;

                #region [ Glosa ]
                this.FC_EXONERADO.Text = Presenter.FC_EXONERADO.PARA_Valor;
                this.FC_OPSUJETAPOT.Text = Presenter.FC_OPSUJETAPOT.PARA_Valor;
                #endregion

                #region [ Facturación ]
                this.FAC_TDO.Text = Presenter.FAC_TDO.PARA_Valor;
                this.FAC_TDO_OP.Text = Presenter.FAC_TDO_OP.PARA_Valor;
                this.FAC_TDO_OV.Text = Presenter.FAC_TDO_OV.PARA_Valor;
                this.PREF_TDO_SLI.Text = Presenter.PREF_TDO_SLI.PARA_Valor;
                this.PREF_TDO_ILD.Text = Presenter.PREF_TDO_ILD.PARA_Valor;
                this.TIPO_TDO_NCS.Text = Presenter.TIPO_TDO_NCS.PARA_Valor;
                #endregion

                #region [ Finanzas ]

                this.DET_DIASDETRACCION.Value = Decimal.Parse(Presenter.DET_DIASDETRACCION.PARA_Valor);

                if (!String.IsNullOrEmpty(Presenter.DET_REDONDEONORMAL.PARA_Valor))
                { this.DET_REDONDEONORMAL.Checked = Presenter.DET_REDONDEONORMAL.PARA_Valor.Equals("1"); }
                else { this.DET_REDONDEONORMAL.Checked = false; }

                this.CCCT_SERIEDIARIO.Text = Presenter.CCCT_SERIEDIARIO.PARA_Valor;

                CCCT_TIPODOCUMENTO.Text = Presenter.CCCT_TIPODOCUMENTO.PARA_Valor;

                MOVI_CHQBLANCO.Text = Presenter.MOVI_CHQBLANCO.PARA_Valor;

                TIPO_DES_GBAN.SelectedValue = Presenter.TIPO_DES_GBAN.PARA_Valor;

                TIPO_MOV_DESDIF.Text = Presenter.TIPO_MOV_DESDIF.PARA_Valor;

                TIPO_TDO_OVDG.Text = Presenter.TIPO_TDO_OVDG.PARA_Valor;

                CUENTA_DCHINA.Text = Presenter.CUENTA_DCHINA.PARA_Valor;

                RUC_DCHINA.Text = Presenter.RUC_DCHINA.PARA_Valor;

                if (!String.IsNullOrEmpty(Presenter.TIPO_DES_GBAN.PARA_Valor))
                { TIPO_DES_GBAN.SelectedValue = Presenter.TIPO_DES_GBAN.PARA_Valor.Substring(4, 3); }
                else { TIPO_DES_GBAN.SelectedIndex = 0; }

                #endregion

                HashFormulario = Infrastructure.Client.FormClose.FormValidateChanges.iniciarComparacionFormulario(this);
            }
            catch (Exception ex)
            { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error en el poner los valores", ex); }
        }
        #endregion

        #region [ Metodos ]
        private void LoadResultadoGestion()
        {
            try
            {
                KPI002RESG.ValueMember = "RESG_Codigo";
                KPI002RESG.DisplayMember = "RESG_Desc";

                ObservableCollection<Entities.ResultGestion> _items = null;
                if (TipoRESG_Codigo.ComboIntSelectedValue.HasValue)
                {
                    _items = Presenter.ListResultGestion.Where(resg => resg.RESG_PositivoNegativo == TipoRESG_Codigo.ComboIntSelectedValue).ToObservableCollection();
                    _items.Insert(0, new Entities.ResultGestion() { RESG_Codigo = -1, RESG_Desc = "< Seleccionar Result. Gestión >" });
                    KPI002RESG.DataSource = _items;
                    KPI002RESG.SelectedIndex = 0;
                    KPI002RESG.Enabled = true;
                }
                else
                {
                    KPI002RESG.DataSource = _items;
                    KPI002RESG.Enabled = false;
                }

            }
            catch (Exception ex)
            { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error cargando los resultados de gestión.", ex); }
        }
        private void FormatGridPlanillas()
        {
            try
            {

                Telerik.WinControls.UI.Localization.RadGridLocalizationProvider.CurrentProvider = new Infrastructure.WinForms.Controls.MySpanishRadGridLocalizationProvider();
                this.grdItemsPlanillas.Columns.Clear();
                this.grdItemsPlanillas.AllowAddNewRow = false;

                this.grdItemsPlanillas.Columns.Add("PARA_Clave", "Clave", "PARA_Clave");
                this.grdItemsPlanillas.Columns.Add("PARA_Desc", "Descripción", "PARA_Desc");
                this.grdItemsPlanillas.Columns.Add("PARA_Valor", "Valor", "PARA_Valor");

                this.grdItemsPlanillas.BestFitColumns();
                Infrastructure.WinForms.Controls.GridAutoFit.Fit(grdItemsPlanillas);

                this.grdItemsPlanillas.SelectionMode = Telerik.WinControls.UI.GridViewSelectionMode.CellSelect;
                this.grdItemsPlanillas.MultiSelect = false;
                this.grdItemsPlanillas.ShowFilteringRow = false;
                this.grdItemsPlanillas.EnableFiltering = false;
                this.grdItemsPlanillas.MasterTemplate.EnableFiltering = false;
                this.grdItemsPlanillas.EnableGrouping = false;
                this.grdItemsPlanillas.MasterTemplate.EnableGrouping = false;
                this.grdItemsPlanillas.EnableSorting = false;
                this.grdItemsPlanillas.MasterTemplate.EnableCustomSorting = false;
                this.grdItemsPlanillas.ReadOnly = false;
                this.grdItemsPlanillas.AllowEditRow = true;

                this.grdItemsPlanillas.Columns["PARA_Clave"].ReadOnly = true;
                this.grdItemsPlanillas.Columns["PARA_Desc"].ReadOnly = true;

            }
            catch (Exception ex)
            {
                Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, Infrastructure.Aspect.Constants.Mensajes.FormatDataGridView + " (Grid Servicios)", ex);
            }
        }
        private String AyudaTipoEntidad(String x_Seleccionados)
        {
            String _resultado = String.Empty;
            try
            {
                if (Presenter.ListTiposEntidad != null && Presenter.ListTiposEntidad.Count > 0)
                {
                    PAR000AView _viewAyuda = new PAR000AView("Ayuda Tipos de Entidad", Presenter.ListTiposEntidad, x_Seleccionados, PAR000AView.TAyuda.TEntidad);
                    if (_viewAyuda.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    { _resultado = _viewAyuda.Texto; }
                    _viewAyuda.Dispose();
                    _viewAyuda = null;
                    return _resultado;
                }
                else
                { Dialogos.MostrarMensajeInformacion("Ayuda Entidad", "No existe ningun tipo de entidad"); return _resultado; }
            }
            catch (Exception ex)
            { throw ex; }
        }

        private String AyudaTipos(String x_Seleccionados)
        {
            String _resultado = String.Empty;
            try
            {
                if (Presenter.ListTiposDocumentos != null && Presenter.ListTiposDocumentos.Count > 0)
                {
                    PAR000AView _viewAyuda = new PAR000AView("Ayuda Tipos de Tipo de Documento", Presenter.ListTiposDocumentos, x_Seleccionados, PAR000AView.TAyuda.TDocumentos);
                    if (_viewAyuda.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    { _resultado = _viewAyuda.Texto; }
                    _viewAyuda.Dispose();
                    _viewAyuda = null;
                    return _resultado;
                }
                else
                { Dialogos.MostrarMensajeInformacion("Ayuda Entidad", "No existe ningun tipo de entidad"); return _resultado; }
            }
            catch (Exception ex)
            { throw ex; }
        }

        private String AyudaTipos(String x_Seleccionados, String x_tipo)
        {
            String _resultado = String.Empty;
            try
            {
                PAR000AView _viewAyuda = new PAR000AView("Ayuda Tipos de Tipo de Documento", Presenter.getAllTipos(x_tipo), x_Seleccionados, PAR000AView.TAyuda.TDocumentos);
                if (_viewAyuda.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                { _resultado = _viewAyuda.Texto; }
                _viewAyuda.Dispose();
                _viewAyuda = null;
                return _resultado;
            }
            catch (Exception ex)
            { throw ex; }
        }

        private String AyudaTiposContabilidad(String x_Seleccionados)
        {
            String _resultado = String.Empty;
            try
            {
                if (Presenter.ListTiposEntidad != null && Presenter.ListTiposEntidad.Count > 0)
                {
                    PAR000AView _viewAyuda = new PAR000AView("Ayuda Tipos de Tipo de Documento - Contabilidad", Presenter.ListTiposDocumentosContabilidad, x_Seleccionados, PAR000AView.TAyuda.TDocumentos);
                    _viewAyuda.Width = _viewAyuda.Width * 3;
                    _viewAyuda.Height = (int)Math.Round(_viewAyuda.Height * 1.25, 0);
                    _viewAyuda.StartPosition = FormStartPosition.CenterScreen;
                    if (_viewAyuda.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    { _resultado = _viewAyuda.Texto; }
                    _viewAyuda.Dispose();
                    _viewAyuda = null;
                    return _resultado;
                }
                else
                { Dialogos.MostrarMensajeInformacion("Ayuda Entidad", "No existe ningun tipo de entidad"); return _resultado; }
            }
            catch (Exception ex)
            { throw ex; }
        }

        private String AyudaEntidad(String x_Seleccionados)
        {
            String _resultado = String.Empty;
            try
            {
                ObservableCollection<Entities.Entidad> x_listEntidad = Presenter.getEntidadEjecutivos();
                if (x_listEntidad != null && x_listEntidad.Count > 0)
                {
                    PAR000AView _viewAyuda = new PAR000AView("Ayuda Entidades", x_listEntidad, x_Seleccionados, PAR000AView.TAyuda.Entidad);
                    if (_viewAyuda.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    { _resultado = _viewAyuda.Texto; }
                    _viewAyuda.Dispose();
                    _viewAyuda = null;
                    return _resultado;
                }
                else
                { Dialogos.MostrarMensajeInformacion("Ayuda Tipo Documentos", "No existe ningun tipo de documentos"); return _resultado; }
            }
            catch (Exception ex)
            { throw ex; }
        }

        private String AyudaCuentas(String x_Seleccionados)
        {
            String _resultado = String.Empty;
            try
            {
                ObservableCollection<Entities.Tipos> x_listCuentas = Presenter.getTiposCuentas();
                if (x_listCuentas != null && x_listCuentas.Count > 0)
                {
                    PAR000AView _viewAyuda = new PAR000AView("Ayuda Cuentas", x_listCuentas, x_Seleccionados, PAR000AView.TAyuda.CuentasContables);
                    _viewAyuda.Width = _viewAyuda.Width * 3;
                    _viewAyuda.Height = (int)Math.Round(_viewAyuda.Height * 1.25, 0);
                    _viewAyuda.StartPosition = FormStartPosition.CenterScreen;
                    if (_viewAyuda.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    { _resultado = _viewAyuda.Texto; }
                    _viewAyuda.Dispose();
                    _viewAyuda = null;
                    return _resultado;
                }
                else
                { Dialogos.MostrarMensajeInformacion("Ayuda Tipo Documentos", "No existe ningun tipo de documentos"); return _resultado; }
            }
            catch (Exception ex)
            { throw ex; }
        }
        #endregion

        #region [ Eventos ]
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (Presenter.Guardar())
                {
                    this.FormClosing -= MView_FormClosing;
                    errorProvider1.Dispose();
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
                errorProvider1.Dispose();
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
        private void TipoRESG_Codigo_SelectedIndexChanged(object sender, EventArgs e)
        { LoadResultadoGestion(); }
        private void USRAPROBADORNIVEL1_JV_AyudaClick(object sender, EventArgs e)
        {
            try
            {
                NextAdmin.BusinessLogic.Usuarios _usuario = Presenter.AyudaUsuario(USRAPROBADORNIVEL1_JV.Text);
                if (_usuario != null)
                {
                    USRAPROBADORNIVEL1_JV.SetValue(_usuario, _usuario.USUA_CodUsr);
                    USRAPROBADORNIVEL1_JVNombre.Text = _usuario.USUA_Nombres;
                }
                else
                { USRAPROBADORNIVEL1_JV.ClearValue(); }
            }
            catch (Exception ex)
            { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error en el evento de la Ayuda de Usuarios", ex); }
        }
        private void USRAPROBADORNIVEL1_JV_AyudaClean(object sender, EventArgs e)
        {
            try
            {
                USRAPROBADORNIVEL1_JV.Text = String.Empty;
                USRAPROBADORNIVEL1_JVNombre.Text = String.Empty;
            }
            catch (Exception ex)
            { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error en el evento de la Ayuda de Usuarios", ex); }
        }
        private void USRAPROBADORNIVEL2_GC_AyudaClick(object sender, EventArgs e)
        {
            try
            {
                NextAdmin.BusinessLogic.Usuarios _usuario = Presenter.AyudaUsuario(USRAPROBADORNIVEL2_GC.Text);
                if (_usuario != null)
                {
                    USRAPROBADORNIVEL2_GC.SetValue(_usuario, _usuario.USUA_CodUsr);
                    USRAPROBADORNIVEL2_GCNombre.Text = _usuario.USUA_Nombres;
                }
                else
                { USRAPROBADORNIVEL2_GC.ClearValue(); }
            }
            catch (Exception ex)
            { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error en el evento de la Ayuda de Usuarios", ex); }
        }
        private void USRAPROBADORNIVEL2_GC_AyudaClean(object sender, EventArgs e)
        {
            try
            {
                USRAPROBADORNIVEL2_GC.Text = String.Empty;
                USRAPROBADORNIVEL2_GCNombre.Text = String.Empty;
            }
            catch (Exception ex)
            { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error en el evento de la Ayuda de Usuarios", ex); }
        }
        private void USRAPROBADORNIVEL3_GG_AyudaClick(object sender, EventArgs e)
        {
            try
            {
                NextAdmin.BusinessLogic.Usuarios _usuario = Presenter.AyudaUsuario(USRAPROBADORNIVEL3_GG.Text);
                if (_usuario != null)
                {
                    USRAPROBADORNIVEL3_GG.SetValue(_usuario, _usuario.USUA_CodUsr);
                    USRAPROBADORNIVEL3_GGNombre.Text = _usuario.USUA_Nombres;
                }
                else
                { USRAPROBADORNIVEL3_GG.ClearValue(); }
            }
            catch (Exception ex)
            { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error en el evento de la Ayuda de Usuarios", ex); }
        }
        private void USRAPROBADORNIVEL3_GG_AyudaClean(object sender, EventArgs e)
        {
            try
            {
                USRAPROBADORNIVEL3_GG.Text = String.Empty;
                USRAPROBADORNIVEL3_GGNombre.Text = String.Empty;
            }
            catch (Exception ex)
            { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error en el evento de la Ayuda de Usuarios", ex); }
        }
        private void ayudaRTIPO_DTE_AyudaClick(object sender, EventArgs e)
        {
            try
            {
                String _result = AyudaTipoEntidad(RTIPO_DTE.Text);
                if (!String.IsNullOrEmpty(_result))
                { RTIPO_DTE.Text = String.Empty; RTIPO_DTE.Text = _result; }
            }
            catch (Exception ex)
            { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error en el evento de la Ayuda de Tipo de Entidad", ex); }
        }
        private void ayudaRTIPO_VEN_AyudaClick(object sender, EventArgs e)
        {
            try
            {
                String _result = AyudaTipoEntidad(RTIPO_VEN.Text);
                if (!String.IsNullOrEmpty(_result))
                { RTIPO_VEN.Text = String.Empty; RTIPO_VEN.Text = _result; }
            }
            catch (Exception ex)
            { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error en el evento de la Ayuda de Tipo de Entidad", ex); }
        }
        private void ayudaRTIPO_CON_AyudaClick(object sender, EventArgs e)
        {
            try
            {
                String _result = AyudaTipoEntidad(RTIPO_CON.Text);
                if (!String.IsNullOrEmpty(_result))
                { RTIPO_CON.Text = String.Empty; RTIPO_CON.Text = _result; }
            }
            catch (Exception ex)
            { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error en el evento de la Ayuda de Tipo de Entidad", ex); }
        }
        private void ayudaRTIPO_DVA_AyudaClick(object sender, EventArgs e)
        {
            try
            {
                String _result = AyudaTipoEntidad(RTIPO_DVA.Text);
                if (!String.IsNullOrEmpty(_result))
                { RTIPO_DVA.Text = String.Empty; RTIPO_DVA.Text = _result; }
            }
            catch (Exception ex)
            { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error en el evento de la Ayuda de Tipo de Entidad", ex); }
        }
        private void ayudaRTIPO_AGE_AyudaClick(object sender, EventArgs e)
        {
            try
            {
                String _result = AyudaTipoEntidad(RTIPO_AGE.Text);
                if (!String.IsNullOrEmpty(_result))
                { RTIPO_AGE.Text = String.Empty; RTIPO_AGE.Text = _result; }
            }
            catch (Exception ex)
            { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error en el evento de la Ayuda de Tipo de Entidad", ex); }
        }
        private void ayudaRTIPO_CSE_AyudaClick(object sender, EventArgs e)
        {
            try
            {
                String _result = AyudaTipoEntidad(RTIPO_CSE.Text);
                if (!String.IsNullOrEmpty(_result))
                { RTIPO_CSE.Text = String.Empty; RTIPO_CSE.Text = _result; }
            }
            catch (Exception ex)
            { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error en el evento de la Ayuda de Tipo de Entidad", ex); }
        }
        private void ayudaEEJECUTIVOS_Click(object sender, EventArgs e)
        {
            try
            {
                String _result = AyudaEntidad(EEJECUTIVOS.Text);
                if (!String.IsNullOrEmpty(_result))
                { EEJECUTIVOS.Text = String.Empty; EEJECUTIVOS.Text = _result; }
            }
            catch (Exception ex)
            { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error en el evento de la Ayuda de Entidad", ex); }
        }

        private void ayudaRUTA_ADU_IMPO_PROV_Click(object sender, EventArgs e)
        {
            try
            {
                System.Windows.Forms.FolderBrowserDialog _browser = new System.Windows.Forms.FolderBrowserDialog();
                if (_browser.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    this.RUTA_SDA.Text = _browser.SelectedPath;
                }
            }
            catch (Exception ex)
            { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error en el evento de la Ayuda de Explorador", ex); }
        }
        private void ayudaRUTA_ADUANA_DEMAS_Click(object sender, EventArgs e)
        {
            try
            {
                System.Windows.Forms.FolderBrowserDialog _browser = new System.Windows.Forms.FolderBrowserDialog();
                if (_browser.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    this.RUTA_TELEDESPACHO.Text = _browser.SelectedPath;
                }
            }
            catch (Exception ex)
            { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error en el evento de la Ayuda de Explorador", ex); }
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
                    }
                }
                else
                { Closing = false; e.Cancel = true; }
            }
            catch (Exception ex)
            { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al cerrar el formulario.", ex); }
        }
        private void btnPREF_TDO_SLI_Click(object sender, EventArgs e)
        {
            try
            {
                String _result = AyudaTipos(PREF_TDO_SLI.Text);
                if (!String.IsNullOrEmpty(_result))
                { PREF_TDO_SLI.Text = String.Empty; PREF_TDO_SLI.Text = _result; }
            }
            catch (Exception ex)
            { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error en el evento de la Ayuda de Tipo de Documentos", ex); }
        }
        private void btnFAC_TDO_OV_Click(object sender, EventArgs e)
        {
            try
            {
                String _result = AyudaTipos(FAC_TDO_OV.Text);
                if (!String.IsNullOrEmpty(_result))
                { FAC_TDO_OV.Text = String.Empty; FAC_TDO_OV.Text = _result; }
            }
            catch (Exception ex)
            { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error en el evento de la Ayuda de Tipo de Documentos", ex); }
        }
        private void btnFAC_TDO_OP_Click(object sender, EventArgs e)
        {
            try
            {
                String _result = AyudaTipos(FAC_TDO_OP.Text);
                if (!String.IsNullOrEmpty(_result))
                { FAC_TDO_OP.Text = String.Empty; FAC_TDO_OP.Text = _result; }
            }
            catch (Exception ex)
            { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error en el evento de la Ayuda de Tipo de Documentos", ex); }
        }
        private void btnFAC_TDO_Click(object sender, EventArgs e)
        {
            try
            {
                String _result = AyudaTipos(FAC_TDO.Text);
                if (!String.IsNullOrEmpty(_result))
                { FAC_TDO.Text = String.Empty; FAC_TDO.Text = _result; }
            }
            catch (Exception ex)
            { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error en el evento de la Ayuda de Tipo de Documentos", ex); }
        }

        private void btnPREF_TDO_ILD_Click(object sender, EventArgs e)
        {
            try
            {
                String _result = AyudaTipos(PREF_TDO_ILD.Text);
                if (!String.IsNullOrEmpty(_result))
                { PREF_TDO_ILD.Text = String.Empty; PREF_TDO_ILD.Text = _result; }
            }
            catch (Exception ex)
            { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error en el evento de la Ayuda de Tipo de Documentos", ex); }
        }

        private void btnTIPO_TDO_NCS_Click(object sender, EventArgs e)
        {
            try
            {
                String _result = AyudaTipos(TIPO_TDO_NCS.Text);
                if (!String.IsNullOrEmpty(_result))
                { TIPO_TDO_NCS.Text = String.Empty; TIPO_TDO_NCS.Text = _result; }
            }
            catch (Exception ex)
            { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error en el evento de la Ayuda de Tipo de Documentos", ex); }
        }


        private void btnSERV_FLETE_GRR_Click(object sender, EventArgs e)
        {
            try
            {
                PAR000SView _view = new PAR000SView(Presenter.ContainerService, txtSERV_FLETE_GRR.Text);
                _view.ShowDialog();
                txtSERV_FLETE_GRR.Text = _view.PARA_Valor;
                _view = null;
            }
            catch (Exception) { }
        }

        void btnTDO_A_DIARIO_Click(object sender, EventArgs e)
        {
            try
            {
                String _result = AyudaTipos(TDO_A_DIARIO.Text);
                if (!String.IsNullOrEmpty(_result))
                { TDO_A_DIARIO.Text = String.Empty; TDO_A_DIARIO.Text = _result; }
            }
            catch (Exception ex)
            { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error en el evento de la Ayuda de Tipo de Documentos", ex); }
        }

        private void btnCTAS_MANDATO_Click(object sender, EventArgs e)
        {
            try
            {
                String _result = AyudaCuentas(CTAS_MANDATO.Text);
                if (!String.IsNullOrEmpty(_result))
                { CTAS_MANDATO.Text = String.Empty; CTAS_MANDATO.Text = _result; }
            }
            catch (Exception ex)
            { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error en el evento de la Ayuda de Tipo de Documentos", ex); }
        }

        private void btnSERV_FL_AJUSTE_OP_Click(object sender, EventArgs e)
        {
            try
            {
                PAR000SView _view = new PAR000SView(Presenter.ContainerService, SERV_FL_AJUSTE_OP.Text, '|');
                _view.ShowDialog();
                SERV_FL_AJUSTE_OP.Text = _view.PARA_Valor;
                _view = null;
            }
            catch (Exception ex)
            { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error en el evento de la Ayuda de Tipo de Servicios de Flete Ajuste", ex); }
        }

        private void btnCCCT_TIPODOCUMENTO_Click(object sender, EventArgs e)
        {
            try
            {
                String _result = AyudaTiposContabilidad(CCCT_TIPODOCUMENTO.Text);
                if (!String.IsNullOrEmpty(_result))
                { CCCT_TIPODOCUMENTO.Text = String.Empty; CCCT_TIPODOCUMENTO.Text = _result; }
            }
            catch (Exception ex)
            { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error en el evento de la Ayuda de Tipo de Servicios de Flete Ajuste", ex); }
        }


        private void btnMOVI_CHQBLANCO_Click(object sender, EventArgs e)
        {
            try
            {
                String _result = AyudaTipos(MOVI_CHQBLANCO.Text, "MOV");
                if (!String.IsNullOrEmpty(_result))
                { MOVI_CHQBLANCO.Text = String.Empty; MOVI_CHQBLANCO.Text = _result; }
            }
            catch (Exception ex)
            { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error en el evento de la Ayuda de Tipo de Documentos", ex); }
        }

        private void btnTIPO_MOV_DESDIF_Click(object sender, EventArgs e)
        {
            try
            {
                String _result = AyudaTipos(TIPO_MOV_DESDIF.Text, "MOV");
                if (!String.IsNullOrEmpty(_result))
                { TIPO_MOV_DESDIF.Text = String.Empty; TIPO_MOV_DESDIF.Text = _result; }
            }
            catch (Exception ex)
            { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error en el evento de la Ayuda de Tipo de Documentos", ex); }
        }

        #endregion

        private void label86_Click(object sender, EventArgs e)
        {

        }
    }
}