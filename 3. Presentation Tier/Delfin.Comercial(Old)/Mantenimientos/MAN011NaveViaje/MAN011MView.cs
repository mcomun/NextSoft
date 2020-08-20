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
using System.Text.RegularExpressions;
using System.Web;
using System.Threading;
using Outlook = Microsoft.Office.Interop.Outlook;
using System.IO;
using Delfin.Controls.Tipos;
using System.Diagnostics;

namespace Delfin.Comercial
{
    public partial class MAN011MView : Form, IMAN011MView
    {
        #region [ Variables ]
        /// <summary>
        /// CRISTHIAN JOSE APAZA 
        /// ESTADO NAVE VIAJE
        /// </summary>
        public sealed class NVIA_Estado
        {

            private NVIA_Estado()
            {
            }

            //ESTADOS
            public const string Abierto = "A";
            public const string PreFacturado = "P";
            public const string Cerrado = "C";
        }
        public sealed class _TIPO_Embarque
        {

            private _TIPO_Embarque()
            {
            }

            //TIPOS EMBARQUE
            public const string FCL = "FCL";
            public const string LCL = "LCL";
        }
        public sealed class _TIPO_Condicion
        {
            private _TIPO_Condicion() { }

            //Condicion para traer ordenes de venta
            public const Int32 Direccionamiento = 1; // Ordenes de Venta que se Direccionaron (Correo)
            public const Int32 AvisoAlmacen = 2; // Ordenes de Venta que se les envio un aviso al Almacen (Correo) 
            public const Int32 CierreNave = 3; //Ordenes de Venta que se cerraron a travez de Nave-Viaje 
            public const Int32 AbrirStatment = 4; //Ordenes de Venta que se aperturaron a travez de Nave-Viaje 
            //public const Int32 DesgloseB
        }
        #endregion

        #region [ Formulario ]
        public MAN011MView()
        {
            InitializeComponent();
            try
            {
                this.FormClosing += new FormClosingEventHandler(MView_FormClosing);
                btnMAN_guardar.Click += btnGuardar_Click;
                btnMAN_salir.Click += btnSalir_Click;

                btnCerrar_Nave.Click += btnCerrarNave_Click;

                ENTC_CodTransportista.AyudaValueChanged += ENTC_CodTransportista_AyudaValueChanged;

                //TIPO_CodPAI.SelectedIndexChanged += TIPO_CodPAI_SelectedIndexChanged; ;
                TIPO_CodPAIDetalle.SelectedIndexChanged += TIPO_CodPAIDetalle_SelectedIndexChanged;
                CONS_CodVIA.SelectedIndexChanged += CONS_CodVIADetalle_SelectedIndexChanged;
                NAVE_Codigo.SelectedIndexChanged += NAVE_Codigo_SelectedIndexChanged;
                BSItemsDetalles = new BindingSource();
                BSItemsDetalles.CurrentItemChanged += BSItemsDetalles_CurrentItemChanged;

                btnNuevoDetalle.Click += btnNuevoDetalle_Click;
                btnEditarDetalle.Click += btnEditarDetalle_Click;
                btnEliminarDetalle.Click += btnEliminarDetalle_Click;
                btnGuardarDetalle.Click += btnGuardarDetalle_Click;
                btnDeshacerDetalle.Click += btnDeshacerDetalle_Click;

                btnEmiti_Statement.Click += btnEmiti_Statment_Click;
                btnAprobarStatement.Click += btnAprobarStatment_Click;

                //BOTONES DEL PANEL
                btnEmailAlmacen.Click += btnEmailAlmacen_Click;
                btnCancelacionRecalada.Click += btnCancelacionRecalada_Click;
                btnDemoraArribo.Click += btnDemoraArribo_Click;
                btn_VoBo.Click += btnVoBo_Click;
                btnDireccionamiento.Click += btnDireccionamiento_Click;
                btnAvisosLlegada.Click += btnAvisosLlegada_Click;
                btnCargaTarjadaLCL.Click += btnCargaTarjadaLCL_Click;
                btnCargaTarjadaFCL.Click += btnCargaTarjadaFCL_Click;
                btnPreFacturar.Click += btnPreFacturar_Click;
                btnEmitir_BL.Click += btnEmitir_BL_Click;
                btnAbrirStatement.Click += btnAbrirStatment_Click;


                #region [ Auditoria ]
                btnAuditoriaNaveViaje.Click += btnAuditoriaNaveViaje_Click;
                btnAuditoriaDetNaveViaje.Click += btnAuditoriaDetNaveViaje_Click;
                #endregion
            }
            catch (Exception ex)
            {
                Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al inicializar el formulario MView.", ex);
            }
        }
        #endregion

        #region [ Propiedades ]
        public MAN011Presenter Presenter { get; set; }
        private bool Closing = false;
        private System.Collections.Hashtable HashFormulario { get; set; }
        private DataTable DT_OV = new DataTable();
        #endregion

        #region [ ICUS007MView ]
        public void LoadView()
        {
            try
            {

                ENTC_CodTransportista.ContainerService = Presenter.ContainerService;

                ENTC_CodAgentePort_EXPO.ContainerService = Presenter.ContainerService;
                ENTC_CodAgentePortVoBo_IMPO.ContainerService = Presenter.ContainerService;
                ENTC_CodAgentePortVoBo2_IMPO.ContainerService = Presenter.ContainerService;
                ENTC_CodTermPort.ContainerService = Presenter.ContainerService;


                ENTC_CodAgentePort_EXPO.TipoEntidad = Delfin.Controls.TiposEntidad.TIPE_AgentePortuario;
                ENTC_CodAgentePortVoBo_IMPO.TipoEntidad = Delfin.Controls.TiposEntidad.TIPE_AgentePortuario;
                ENTC_CodAgentePortVoBo2_IMPO.TipoEntidad = Delfin.Controls.TiposEntidad.TIPE_AgentePortuario;
                ENTC_CodTermPort.TipoEntidad = Delfin.Controls.TiposEntidad.TIPE_DepositoTemporal;

                CONS_CodVIA.LoadControl(Presenter.ContainerService, "Tipos de Vía", "VIA", "<Seleccione una Vía>", ListSortDirection.Ascending);


                CONS_CodRGM.LoadControl(Presenter.ContainerService, "Tipos de Régimen", "RGM", "< Seleccionar Régimen >", ListSortDirection.Ascending);
                //TIPO_CodTRF.LoadControl(Presenter.ContainerService, "Tipos de Tráfico", "TRF", "< Seleccionar Tráfico >", ListSortDirection.Ascending);
                cmbNVIA_Estado.LoadControl("Estado Nave Viaje", ComboBoxConstantes.OConstantes.NVIA_Estado, "< Seleccionar Estado>", ListSortDirection.Ascending);
                //TIPO_CodPAI.LoadControl(Presenter.ContainerService, "Tabla Países", "PAI", "< Seleccionar País>>", ListSortDirection.Ascending);
                TIPO_CodPAIDetalle.LoadControl(Presenter.ContainerService, "Tabla Países", "PAI", "< Seleccionar País>>", ListSortDirection.Ascending);
                ayudaPUER_Codigo.LoadControl(Presenter.ContainerService, "Ayuda de Puerto Origen");


                CONS_CodVIA.Enabled = false;
                NAVE_Codigo.Enabled = false;
                //NVIA_FecETA_IMPO_ETD_EXPO

                OcultarCamposDetalles();
                grdItemsDetalle.Enabled = false;
                //OCULTAMOS TRAFICO QUE SE MOVERA A ORDEN DE VENTA 
                TIPO_CodTRF.Visible = false;
                lblTIPO_CodTRF.Visible = false;
            }
            catch (Exception ex)
            {
                Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error cargando la vista.", ex);
            }
        }
        public void ClearItem(Boolean Transportista)
        {
            try
            {
                //if (Transportista)
                //{
                ENTC_CodTransportista.ClearValue();
                //ENTC_CodTransportista.Text = String.Empty;
                //}
                CONS_CodVIA.ConstantesSelectedValue = null;
                //NAVE_Codigo.ValueMember = "NAVE_Codigo";
                //NAVE_Codigo.DisplayMember = "NAVE_Nombre";
                //NAVE_Codigo.DataSource = Presenter.ItemsNaveUnTransportista;
                NAVE_Codigo.DataSource = null;
                NVIA_Codigo.Text = "0";
                NVIA_NroViaje.Text = "";
                CONS_CodRGM.ConstantesSelectedValue = null;
                //TIPO_CodTRF.TiposSelectedValue = null;
                ayudaPUER_Codigo.SelectedValue = null;
                //TIPO_CodPAI.TiposSelectedValue = null;
                //PUER_Codigo.ComboIntSelectedValue = null;
                NVIA_FecETA_IMPO_ETD_EXPO.NSFecha = null;
                NVIA_FecCutOff_EXPO.NSFecha = null;
                NVIA_FecLlega_IMPO_Zarpe_EXPO.NSFecha = null;
                NVIA_FecCierreDire_IMPO_TermEmba_EXPO.NSFecha = null;
                NVIA_FecDescarga_IMPO.NSFecha = null;
                ENTC_FecRecogerDocs.NSFecha = null;
                NVIA_NroManifiesto.Clear();
                NVIA_NroManifiestoDes_IMPO.Clear();
                ENTC_CodAgentePort_EXPO.ClearValue();
                ENTC_CodTermPort.ClearValue();
                ENTC_CodAgentePortVoBo_IMPO.ClearValue();
                ENTC_CodAgentePortVoBo2_IMPO.ClearValue();
                cmbNVIA_Estado.ConstantesSelectedValue = null;

                UsrCrea.Text = null;
                FecCrea.NSFecha = null;
                NVIA_UsrPreFactura.Text = null;
                NVIA_FecPreFactura.NSFecha = null;
                NVIA_UsrCierreNave.Text = null;
                NVIA_FecCierreNave.NSFecha = null;
                txtNVIA_UsrEmiteStatment.Text = null;
                mdtNVIA_FecEmiteStatment.NSFecha = null;


                BSItemsDetalles.DataSource = null;
                grdItemsDetalle.DataSource = BSItemsDetalles;
                BSItemsDetalles.ResetBindings(true);

                InstanceItemDetalle(false, false);
                ClearItemDetalle(true);

                errorProvider1.Clear();
                errorProvider2.Clear();

                chkChangeControl.Checked = false;
            }
            catch (Exception ex)
            {
                Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error limpiando el item.", ex);
            }
        }
        public void GetItem()
        {
            try
            {
                if (Presenter != null && Presenter.Item != null)
                {
                    if (cmbNVIA_Estado.ConstantesSelectedValue != null)
                    {
                        Presenter.Item.NVIA_Estado = cmbNVIA_Estado.ConstantesSelectedItem.CONS_CodTipo;
                    }
                    else
                    {
                        Presenter.Item.NVIA_Estado = null;
                    }
                    if (ENTC_CodTransportista.Value != null)
                    {
                        Presenter.Item.ENTC_CodTransportista = ENTC_CodTransportista.Value.ENTC_Codigo;
                    }
                    else
                    {
                        Presenter.Item.ENTC_CodTransportista = null;
                    }

                    if (CONS_CodVIA.ConstantesSelectedItem != null)
                    {
                        Presenter.Item.CONS_TabVia = CONS_CodVIA.ConstantesSelectedItem.CONS_CodTabla;
                        Presenter.Item.CONS_CodVia = CONS_CodVIA.ConstantesSelectedItem.CONS_CodTipo;
                    }
                    else
                    {
                        Presenter.Item.CONS_TabVia = null;
                        Presenter.Item.CONS_CodVia = null;
                    }

                    Int16 _NAVE_Codigo;
                    if (NAVE_Codigo.SelectedValue != null && Int16.TryParse(NAVE_Codigo.SelectedValue.ToString(), out _NAVE_Codigo))
                    {
                        Presenter.Item.NAVE_Codigo = Convert.ToInt16(NAVE_Codigo.SelectedValue.ToString());
                    }
                    else
                    {
                        Presenter.Item.NAVE_Codigo = null;
                    }

                    if (NVIA_Codigo.Text.ToString() == "")
                    {
                        Presenter.Item.NVIA_Codigo = 0;
                    }
                    else
                    {
                        Presenter.Item.NVIA_Codigo = Convert.ToInt16(NVIA_Codigo.Text);
                    }

                    Presenter.Item.NVIA_NroViaje = NVIA_NroViaje.Text;

                    if (CONS_CodRGM.ConstantesSelectedItem != null)
                    {
                        Presenter.Item.CONS_TabRGM = CONS_CodRGM.ConstantesSelectedItem.CONS_CodTabla;
                        Presenter.Item.CONS_CodRGM = CONS_CodRGM.ConstantesSelectedItem.CONS_CodTipo;
                    }
                    else
                    {
                        Presenter.Item.CONS_TabRGM = null;
                        Presenter.Item.CONS_CodRGM = null;
                    }

                    //if (TIPO_CodTRF.TiposSelectedItem != null)
                    //{
                    //    Presenter.Item.TIPO_TabTRF = TIPO_CodTRF.TiposSelectedItem.TIPO_CodTabla;
                    //    Presenter.Item.TIPO_CodTRF = TIPO_CodTRF.TiposSelectedItem.TIPO_CodTipo;
                    //}
                    //else
                    //{
                    Presenter.Item.TIPO_TabTRF = null;
                    Presenter.Item.TIPO_CodTRF = null;
                    //}

                    //if (TIPO_CodPAI.TiposSelectedItem != null)
                    //{
                    //    Presenter.Item.TIPO_TabPAI = TIPO_CodPAI.TiposSelectedItem.TIPO_CodTabla;
                    //    Presenter.Item.TIPO_CodPAI = TIPO_CodPAI.TiposSelectedItem.TIPO_CodTipo;
                    //}
                    //else
                    //{
                    //    Presenter.Item.TIPO_TabPAI = null;
                    //    Presenter.Item.TIPO_CodPAI = null;
                    //}

                    if (ayudaPUER_Codigo.SelectedItem != null)
                    {
                        Presenter.Item.PUER_Codigo = ayudaPUER_Codigo.SelectedItem.PUER_Codigo;
                    }
                    else
                    {
                        Presenter.Item.PUER_Codigo = null;
                    }

                    //Presenter.Item.PUER_Codigo = PUER_Codigo.ComboIntSelectedValue;

                    Presenter.Item.NVIA_FecETA_IMPO_ETD_EXPO = NVIA_FecETA_IMPO_ETD_EXPO.NSFecha;
                    Presenter.Item.NVIA_FecLlega_IMPO_Zarpe_EXPO = NVIA_FecLlega_IMPO_Zarpe_EXPO.NSFecha;
                    Presenter.Item.NVIA_FecCierreDire_IMPO_TermEmba_EXPO = NVIA_FecCierreDire_IMPO_TermEmba_EXPO.NSFecha;
                    Presenter.Item.NVIA_NroManifiesto = NVIA_NroManifiesto.SelectedValue;
                    if (ENTC_CodTermPort.Value != null)
                    {
                        Presenter.Item.ENTC_CodTermPort = ENTC_CodTermPort.Value.ENTC_Codigo;
                    }
                    else
                    {
                        Presenter.Item.ENTC_CodTermPort = null;
                    }



                    if (CONS_CodRGM.ConstantesSelectedItem != null && CONS_CodRGM.ConstantesSelectedItem.CONS_CodTipo == Delfin.Controls.variables.CONSRGM_Exportacion)
                    {
                        Presenter.Item.NVIA_FecCutOff_EXPO = NVIA_FecCutOff_EXPO.NSFecha;
                        Presenter.Item.ENTC_FecRecogerDocs = ENTC_FecRecogerDocs.NSFecha;
                        if (ENTC_CodAgentePort_EXPO.Value != null)
                        {
                            Presenter.Item.ENTC_CodAgentePort_EXPO = ENTC_CodAgentePort_EXPO.Value.ENTC_Codigo;
                        }
                        else
                        {
                            Presenter.Item.ENTC_CodAgentePort_EXPO = null;
                        }
                    }
                    else
                    {
                        Presenter.Item.NVIA_FecCutOff_EXPO = null;
                        Presenter.Item.ENTC_FecRecogerDocs = null;
                        Presenter.Item.ENTC_CodAgentePort_EXPO = null;
                    }

                    if (CONS_CodRGM.ConstantesSelectedItem != null && CONS_CodRGM.ConstantesSelectedItem.CONS_CodTipo == Delfin.Controls.variables.CONSRGM_Importacion)
                    {
                        Presenter.Item.NVIA_FecDescarga_IMPO = NVIA_FecDescarga_IMPO.NSFecha;
                        Presenter.Item.NVIA_NorManifiestoDescon = NVIA_NroManifiestoDes_IMPO.SelectedValue;
                        if (ENTC_CodAgentePortVoBo_IMPO.Value != null)
                        {
                            Presenter.Item.ENTC_CodAgenPortVoBo_IMPO = ENTC_CodAgentePortVoBo_IMPO.Value.ENTC_Codigo;
                        }
                        else
                        {
                            Presenter.Item.ENTC_CodAgenPortVoBo_IMPO = null;
                        }
                        if (ENTC_CodAgentePortVoBo2_IMPO.Value != null)
                        {
                            Presenter.Item.ENTC_CodAgenPortVoBo2_IMPO = ENTC_CodAgentePortVoBo2_IMPO.Value.ENTC_Codigo;
                        }
                        else
                        {
                            Presenter.Item.ENTC_CodAgenPortVoBo2_IMPO = null;
                        }
                    }
                    else
                    {
                        Presenter.Item.NVIA_FecDescarga_IMPO = null;
                        Presenter.Item.NVIA_NorManifiestoDescon = null;
                        Presenter.Item.ENTC_CodAgenPortVoBo_IMPO = null;
                        Presenter.Item.ENTC_CodAgenPortVoBo2_IMPO = null;
                    }


                    //Presenter.Item.NVIA_UsrCierreNave = NVIA_UsrCierreNave.Text;
                    //Presenter.Item.NVIA_FecCierreNave = NVIA_FecCierreNave.NSFecha;
                    //Presenter.Item.NVIA_UsrPreFactura = NVIA_UsrPreFactura.Text;
                    //Presenter.Item.NVIA_FecPreFactura = NVIA_FecPreFactura.NSFecha;


                    Presenter.Item.ItemsDetNaveViaje = ((ObservableCollection<Entities.DetNaveViaje>)BSItemsDetalles.DataSource);
                }
            }
            catch (Exception ex)
            {
                Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error obteniendo el item.", ex);
            }
        }
        public void SetItem(Boolean x_Edicion = false)
        {
            try
            {
                if (Presenter != null && Presenter.Item != null)
                {
                    // String _NVIA_Estado = Presenter.Item.NVIA_Estado;
                    if (Presenter.Item.NVIA_Estado != null)
                    {
                        cmbNVIA_Estado.ConstantesSelectedValue = Presenter.Item.NVIA_Estado.Trim();
                    }
                    else
                    {
                        cmbNVIA_Estado.ConstantesSelectedValue = null;
                    }
                    if (Presenter.Item.ENTC_CodTransportista.HasValue)
                    {
                        if (Presenter.Item.ENTC_CodAgentePort_EXPO.HasValue || Presenter.Item.ENTC_CodAgenPortVoBo_IMPO.HasValue)
                        { ENTC_CodTransportista.AyudaValueChanged -= ENTC_CodTransportista_AyudaValueChanged; }
                        ENTC_CodTransportista.SetValue(Presenter.Item.ENTC_CodTransportista.Value);
                        //ENTC_CodTransportista.AyudaValueChanged -= ENTC_CodTransportista_AyudaValueChanged;
                    }

                    CONS_CodVIA.ConstantesSelectedValue = Presenter.Item.CONS_CodVia;
                                      

                    NVIA_Codigo.Text = Presenter.Item.NVIA_Codigo.ToString();
                    NVIA_NroViaje.Text = Presenter.Item.NVIA_NroViaje;
                    CONS_CodRGM.ConstantesSelectedValue = Presenter.Item.CONS_CodRGM;
                    //TIPO_CodTRF.TiposSelectedValue = Presenter.Item.TIPO_CodTRF;
                    //TIPO_CodPAI.TiposSelectedValue = Presenter.Item.TIPO_CodPAI;

                    ayudaPUER_Codigo.SelectedValue = Presenter.Item.PUER_Codigo;

                    if (NAVE_Codigo.DataSource != null)
                    {
                       if (Presenter.Item.NAVE_Codigo != null)
                       {
                          NAVE_Codigo.SelectedValue = Presenter.Item.NAVE_Codigo;
                       }
                       else
                       {
                          /*NAVE_Codigo.SelectedIndex = 0;*/
                       }
                    }
                    //PUER_Codigo.ComboIntSelectedValue = Presenter.Item.PUER_Codigo;
                    NVIA_FecETA_IMPO_ETD_EXPO.NSFecha = Presenter.Item.NVIA_FecETA_IMPO_ETD_EXPO;
                    NVIA_FecLlega_IMPO_Zarpe_EXPO.NSFecha = Presenter.Item.NVIA_FecLlega_IMPO_Zarpe_EXPO;
                    NVIA_FecCierreDire_IMPO_TermEmba_EXPO.NSFecha = Presenter.Item.NVIA_FecCierreDire_IMPO_TermEmba_EXPO;
                    if (!String.IsNullOrEmpty(Presenter.Item.NVIA_NroManifiesto))
                    { NVIA_NroManifiesto.SelectedValue = Presenter.Item.NVIA_NroManifiesto; }
                    if (Presenter.Item.ENTC_CodTermPort.HasValue)
                    {
                        ENTC_CodTermPort.SetValue(Presenter.Item.ENTC_CodTermPort.Value);
                    }


                    if (CONS_CodRGM.ConstantesSelectedItem != null && CONS_CodRGM.ConstantesSelectedItem.CONS_CodTipo == Delfin.Controls.variables.CONSRGM_Exportacion)
                    {
                        NVIA_FecCutOff_EXPO.NSFecha = Presenter.Item.NVIA_FecCutOff_EXPO;
                        ENTC_FecRecogerDocs.NSFecha = Presenter.Item.ENTC_FecRecogerDocs;
                        if (Presenter.Item.ENTC_CodAgentePort_EXPO.HasValue)
                        {
                            ENTC_CodAgentePort_EXPO.SetValue(Presenter.Item.ENTC_CodAgentePort_EXPO.Value);
                            ENTC_CodTransportista.AyudaValueChanged += ENTC_CodTransportista_AyudaValueChanged;
                        }
                        else
                        {
                            ENTC_CodAgentePort_EXPO.ClearValue();
                            ENTC_CodTransportista.AyudaValueChanged += ENTC_CodTransportista_AyudaValueChanged;
                        }
                    }

                    if (CONS_CodRGM.ConstantesSelectedItem != null && CONS_CodRGM.ConstantesSelectedItem.CONS_CodTipo == Delfin.Controls.variables.CONSRGM_Importacion)
                    {
                        NVIA_FecDescarga_IMPO.NSFecha = Presenter.Item.NVIA_FecDescarga_IMPO;
                        if (!String.IsNullOrEmpty(Presenter.Item.NVIA_NorManifiestoDescon))
                        { NVIA_NroManifiestoDes_IMPO.SelectedValue = Presenter.Item.NVIA_NorManifiestoDescon; }
                        if (Presenter.Item.ENTC_CodAgenPortVoBo_IMPO.HasValue)
                        {
                            ENTC_CodAgentePortVoBo_IMPO.SetValue(Presenter.Item.ENTC_CodAgenPortVoBo_IMPO.Value);
                            ENTC_CodTransportista.AyudaValueChanged += ENTC_CodTransportista_AyudaValueChanged;
                        }
                        else
                        {
                            ENTC_CodAgentePortVoBo_IMPO.ClearValue();
                            ENTC_CodTransportista.AyudaValueChanged += ENTC_CodTransportista_AyudaValueChanged;
                        }
                        if (Presenter.Item.ENTC_CodAgenPortVoBo2_IMPO.HasValue)
                        {
                            ENTC_CodAgentePortVoBo2_IMPO.SetValue(Presenter.Item.ENTC_CodAgenPortVoBo2_IMPO.Value);
                        }
                    }

                    UsrCrea.Text = Presenter.Item.AUDI_UsrCrea;
                    FecCrea.NSFecha = Presenter.Item.AUDI_FecCrea;
                    NVIA_UsrCierreNave.Text = Presenter.Item.NVIA_UsrCierreNave;
                    NVIA_FecCierreNave.NSFecha = Presenter.Item.NVIA_FecCierreNave;
                    NVIA_UsrPreFactura.Text = Presenter.Item.NVIA_UsrPreFactura;
                    NVIA_FecPreFactura.NSFecha = Presenter.Item.NVIA_FecPreFactura;
                    txtNVIA_UsrEmiteStatment.Text = Presenter.Item.NVIA_UsrEmiteStatment;
                    mdtNVIA_FecEmiteStatment.NSFecha = Presenter.Item.NVIA_FecEmiteStatment;


                    //BSItemsDetalles.DataSource = Presenter.Item.ItemsDetNaveViaje;
                    //grdItemsDetalle.DataSource = BSItemsDetalles;
                    //BSItemsDetalles.ResetBindings(true);

                    //InstanceItemDetalle(false, false);
                    //this.grdItemsDetalle.ShowFilteringRow = false;
                    //this.grdItemsDetalle.EnableFiltering = false;
                    //this.grdItemsDetalle.MasterTemplate.EnableFiltering = false;
                    //this.grdItemsDetalle.EnableGrouping = false;
                    //this.grdItemsDetalle.MasterTemplate.EnableGrouping = false;
                    //this.grdItemsDetalle.EnableSorting = false;
                    //this.grdItemsDetalle.MasterTemplate.EnableCustomSorting = false;

                    //if (x_Edicion)
                    //{
                    //    BSItemsDetalles.MoveFirst();
                    //    ItemDetNaveViaje = ((Entities.DetNaveViaje)BSItemsDetalles.Current);

                    //    ClearItemDetalle(true);

                    //    SetItemDetalle();
                    //    InstanceItemDetalle(true, true);
                    //    Edicion = true;
                    //}
                }
                HashFormulario = Infrastructure.Client.FormClose.FormValidateChanges.iniciarComparacionFormulario(this);
            }
            catch (Exception ex)
            {
                Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error seteando el item.", ex);
            }
        }
        public void ShowValidation()
        {
            try
            {
                Infrastructure.Client.FormClose.FormShowErrorProvider<Entities.NaveViaje>.Validate(Presenter.Item, this, errorProvider1);
            }
            catch (Exception ex)
            {
                Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error mostrando la validación", ex);
            }
        }
        #endregion

        #region [ Metodos ]
        private void Save()
        {
            try
            {
                if (Presenter.Guardar())
                {
                    this.FormClosing -= MView_FormClosing;
                    errorProvider1.Dispose();
                    //Presenter.Actualizar();
                    //this.Close();
                    this.DialogResult = System.Windows.Forms.DialogResult.OK;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void ShowCamposImpoExpo()
        {
            try
            {
                if (CONS_CodRGM.ConstantesSelectedItem != null)
                {
                    if (CONS_CodRGM.ConstantesSelectedItem.CONS_CodTipo == Delfin.Controls.variables.CONSRGM_Importacion)
                    {
                        tableNaveViaje.RowStyles[4].Height = 27;
                        tableNaveViaje.RowStyles[5].Height = 27;
                        tableNaveViaje.RowStyles[6].Height = 27;
                        tableNaveViaje.RowStyles[7].Height = 27;
                        tableNaveViaje.RowStyles[8].Height = 27;
                        tableNaveViaje.RowStyles[9].Height = 0;
                        tableNaveViaje.RowStyles[10].Height = 27;
                        tableNaveViaje.RowStyles[11].Height = 27;
                        tableNaveViaje.RowStyles[12].Height = 27;
                        tableDetalle.RowStyles[0].Height = 0;
                        tableDetalle.RowStyles[1].Height = 0;

                        //lblTIPO_CodPAI.Text = "País Destino:";
                        //lblTIPO_CodPAI.Visible = true;
                        //TIPO_CodPAI.Visible = true;
                        lblPUER_Codigo.Text = "Puerto Destino:";
                        lblPUER_Codigo.Visible = true;
                        ayudaPUER_Codigo.Visible = true;
                        lblNVIA_NroViaje.Visible = true;
                        NVIA_NroViaje.Visible = true;

                        lblNVIA_FecLlega_IMPO_Zarpe_EXPO.Visible = true;
                        NVIA_FecLlega_IMPO_Zarpe_EXPO.Visible = true;
                        if (CONS_CodVIA.ConstantesSelectedItem != null && CONS_CodVIA.ConstantesSelectedItem.CONS_CodTipo == Delfin.Controls.variables.CONSVIA_Aerea)
                        {
                            ShowCamposVia();
                        }
                        else
                        {
                            lblNVIA_NroViaje.Text = "Nro. Viaje";
                            lblNVIA_FecLlega_IMPO_Zarpe_EXPO.Text = "Fec. Llegada";
                        }
                        //PUER_Codigo.Visible = true;
                        lblNVIA_FecETA_IMPO_ETD_EXPO.Text = "Fecha ETA:";
                        lblNVIA_FecETA_IMPO_ETD_EXPO.Visible = true;
                        NVIA_FecETA_IMPO_ETD_EXPO.Visible = true;
                        lblNVIA_FecCutOff_EXPO.Visible = false;
                        NVIA_FecCutOff_EXPO.Visible = false;
                        lblNVIA_FecCierreDire_IMPO_TermEmba_EXPO.Text = "Fec Cierre Direc.:";
                        lblNVIA_FecCierreDire_IMPO_TermEmba_EXPO.Visible = true;
                        NVIA_FecCierreDire_IMPO_TermEmba_EXPO.Visible = true;
                        lblNVIA_FecDescarga_IMPO.Visible = true;
                        NVIA_FecDescarga_IMPO.Visible = true;
                        lblNVIA_FecRecogerDocs.Visible = false;
                        ENTC_FecRecogerDocs.Visible = false;
                        lblNVIA_NroManifiesto.Visible = true;
                        NVIA_NroManifiesto.Visible = true;
                        lblNVIA_NroManifiestoDes_IMPO.Visible = true;
                        NVIA_NroManifiestoDes_IMPO.Visible = true;
                        lblENTC_CodAgentePort_EXPO.Visible = false;
                        ENTC_CodAgentePort_EXPO.Visible = false;
                        lblENTC_CodTermPort.Visible = true;
                        ENTC_CodTermPort.Visible = true;
                        lblENTC_CodAgentePortVoBo_IMPO.Visible = true;
                        ENTC_CodAgentePortVoBo_IMPO.Visible = true;
                        lblENTC_CodAgentePortVoBo2_IMPO.Visible = true;
                        ENTC_CodAgentePortVoBo2_IMPO.Visible = true;
                        lblUsrCrea.Visible = true;
                        UsrCrea.Visible = true;
                        lblFecCrea.Visible = true;
                        FecCrea.Visible = true;
                        lblNVIA_UsrPreFactura.Visible = true;
                        NVIA_UsrPreFactura.Visible = true;
                        lblNVIA_UsrPreFactura.Visible = true;
                        NVIA_FecPreFactura.Visible = true;
                        lblNVIA_UsrCierreNave.Visible = true;
                        NVIA_UsrCierreNave.Visible = true;
                        lblNVIA_FecCierreNave.Visible = true;
                        lblNVIA_UsrEmiteStatment.Visible = true;
                        txtNVIA_UsrEmiteStatment.Visible = true;
                        lblNVIA_FecEmiteStatment.Visible = true;
                        mdtNVIA_FecEmiteStatment.Visible = true;
                        NVIA_FecCierreNave.Visible = true;
                        //lblTIPO_CodPAIDetalle.Text = "País Origen:";
                        //lblPUER_CodigoDetalle.Text = "Puerto Origen:";
                        //lblDVIA_FecETA_EXPO_ETDMaster_IMPO.Text = "Fecha ETD Master:";

                        UsrCrea.Enabled = false;
                        FecCrea.Enabled = false;
                        NVIA_UsrCierreNave.Enabled = false;
                        NVIA_FecCierreNave.Enabled = false;
                        NVIA_UsrPreFactura.Enabled = false;
                        NVIA_FecPreFactura.Enabled = false;
                        txtNVIA_UsrEmiteStatment.Enabled = false;
                        mdtNVIA_FecEmiteStatment.Enabled = false;
                        cmbNVIA_Estado.Enabled = false;
                    }
                    else if (CONS_CodRGM.ConstantesSelectedItem.CONS_CodTipo == Delfin.Controls.variables.CONSRGM_Exportacion)
                    {
                        tableNaveViaje.RowStyles[4].Height = 27;
                        tableNaveViaje.RowStyles[5].Height = 27;
                        tableNaveViaje.RowStyles[6].Height = 27;
                        tableNaveViaje.RowStyles[7].Height = 27;
                        tableNaveViaje.RowStyles[8].Height = 27;
                        tableNaveViaje.RowStyles[9].Height = 27;
                        tableNaveViaje.RowStyles[10].Height = 27;
                        tableNaveViaje.RowStyles[11].Height = 0;
                        tableNaveViaje.RowStyles[12].Height = 0;
                        tableDetalle.RowStyles[0].Height = 0;
                        tableDetalle.RowStyles[1].Height = 0;

                        //lblTIPO_CodPAI.Text = "País Origen:";
                        //lblTIPO_CodPAI.Visible = true;
                        //TIPO_CodPAI.Visible = true;
                        lblPUER_Codigo.Text = "Puerto Origen:";
                        lblPUER_Codigo.Visible = true;
                        ayudaPUER_Codigo.Visible = true;
                        lblNVIA_NroViaje.Visible = true;
                        NVIA_NroViaje.Visible = true;
                        lblNVIA_FecLlega_IMPO_Zarpe_EXPO.Visible = true;
                        NVIA_FecLlega_IMPO_Zarpe_EXPO.Visible = true;
                        if (CONS_CodVIA.ConstantesSelectedItem != null && CONS_CodVIA.ConstantesSelectedItem.CONS_CodTipo == Delfin.Controls.variables.CONSVIA_Aerea)
                        {
                            ShowCamposVia();
                        }
                        else
                        {
                            lblNVIA_NroViaje.Text = "Nro. Viaje";
                            lblNVIA_FecLlega_IMPO_Zarpe_EXPO.Text = "Fec. Zarpe";
                            ;
                        }
                        //PUER_Codigo.Visible = true;
                        lblNVIA_FecETA_IMPO_ETD_EXPO.Text = "Fecha ETD:";
                        lblNVIA_FecETA_IMPO_ETD_EXPO.Visible = true;
                        NVIA_FecETA_IMPO_ETD_EXPO.Visible = true;
                        lblNVIA_FecCutOff_EXPO.Visible = true;
                        NVIA_FecCutOff_EXPO.Visible = true;
                        lblNVIA_FecCierreDire_IMPO_TermEmba_EXPO.Text = "Fec Ter. Emb:";
                        lblNVIA_FecCierreDire_IMPO_TermEmba_EXPO.Visible = true;
                        NVIA_FecCierreDire_IMPO_TermEmba_EXPO.Visible = true;
                        lblNVIA_FecDescarga_IMPO.Visible = false;
                        NVIA_FecDescarga_IMPO.Visible = false;
                        lblNVIA_FecRecogerDocs.Visible = true;
                        ENTC_FecRecogerDocs.Visible = true;
                        lblNVIA_NroManifiesto.Visible = true;
                        NVIA_NroManifiesto.Visible = true;
                        lblNVIA_NroManifiestoDes_IMPO.Visible = false;
                        NVIA_NroManifiestoDes_IMPO.Visible = false;
                        lblENTC_CodAgentePort_EXPO.Visible = true;
                        ENTC_CodAgentePort_EXPO.Visible = true;
                        lblENTC_CodTermPort.Visible = true;
                        ENTC_CodTermPort.Visible = true;
                        lblENTC_CodAgentePortVoBo_IMPO.Visible = false;
                        ENTC_CodAgentePortVoBo_IMPO.Visible = false;
                        lblENTC_CodAgentePortVoBo2_IMPO.Visible = false;
                        ENTC_CodAgentePortVoBo2_IMPO.Visible = false;
                        lblUsrCrea.Visible = true;
                        UsrCrea.Visible = true;
                        lblFecCrea.Visible = true;
                        FecCrea.Visible = true;
                        lblNVIA_UsrPreFactura.Visible = true;
                        NVIA_UsrPreFactura.Visible = true;
                        lblNVIA_UsrPreFactura.Visible = true;
                        NVIA_FecPreFactura.Visible = true;
                        lblNVIA_UsrCierreNave.Visible = true;
                        NVIA_UsrCierreNave.Visible = true;
                        lblNVIA_FecCierreNave.Visible = true;
                        NVIA_FecCierreNave.Visible = true;
                        lblNVIA_UsrEmiteStatment.Visible = true;
                        txtNVIA_UsrEmiteStatment.Visible = true;
                        lblNVIA_FecEmiteStatment.Visible = true;
                        mdtNVIA_FecEmiteStatment.Visible = true;
                        //tableDetalle.RowStyles[0].Height = 27;
                        //tableDetalle.RowStyles[1].Height = 27;
                        //lblTIPO_CodPAIDetalle.Text = "País Destino:";
                        //lblPUER_CodigoDetalle.Text = "Puerto Destino:";
                        //lblDVIA_FecETA_EXPO_ETDMaster_IMPO.Text = "Fecha ETA:";
                        //lblTIPO_CodPAIDetalle.Visible = true;
                        //TIPO_CodPAIDetalle.Visible = true;
                        //lblPUER_CodigoDetalle.Visible = true;
                        //PUER_CodigoDetalle.Visible = true;
                        //lblDVIA_FecETA_EXPO_ETDMaster_IMPO.Visible = true;
                        //DVIA_FecETA_EXPO_ETDMaster_IMPO.Visible = true;

                        UsrCrea.Enabled = false;
                        FecCrea.Enabled = false;
                        NVIA_UsrCierreNave.Enabled = false;
                        NVIA_FecCierreNave.Enabled = false;
                        NVIA_UsrPreFactura.Enabled = false;
                        NVIA_FecPreFactura.Enabled = false;
                        txtNVIA_UsrEmiteStatment.Enabled = false;
                        mdtNVIA_FecEmiteStatment.Enabled = false;
                        cmbNVIA_Estado.Enabled = false;
                    }
                }
                else
                {
                    tableNaveViaje.RowStyles[4].Height = 0;
                    tableNaveViaje.RowStyles[5].Height = 0;
                    tableNaveViaje.RowStyles[6].Height = 0;
                    tableNaveViaje.RowStyles[7].Height = 0;
                    tableNaveViaje.RowStyles[8].Height = 0;
                    tableNaveViaje.RowStyles[9].Height = 0;
                    tableNaveViaje.RowStyles[10].Height = 0;
                    tableNaveViaje.RowStyles[11].Height = 0;
                    tableNaveViaje.RowStyles[12].Height = 0;
                    tableDetalle.RowStyles[0].Height = 0;
                    tableDetalle.RowStyles[1].Height = 0;

                    //lblTIPO_CodPAI.Visible = false;
                    //TIPO_CodPAI.Visible = false;
                    lblPUER_Codigo.Visible = false;
                    ayudaPUER_Codigo.Visible = false;
                    lblNVIA_NroViaje.Visible = false;
                    NVIA_NroViaje.Visible = false;
                    //PUER_Codigo.Visible = false;
                    lblNVIA_FecETA_IMPO_ETD_EXPO.Visible = false;
                    NVIA_FecETA_IMPO_ETD_EXPO.Visible = false;
                    lblNVIA_FecCutOff_EXPO.Visible = false;
                    NVIA_FecCutOff_EXPO.Visible = false;
                    lblNVIA_FecLlega_IMPO_Zarpe_EXPO.Visible = false;
                    NVIA_FecLlega_IMPO_Zarpe_EXPO.Visible = false;
                    lblNVIA_FecCierreDire_IMPO_TermEmba_EXPO.Visible = false;
                    NVIA_FecCierreDire_IMPO_TermEmba_EXPO.Visible = false;
                    lblNVIA_FecDescarga_IMPO.Visible = false;
                    NVIA_FecDescarga_IMPO.Visible = false;
                    lblNVIA_FecRecogerDocs.Visible = false;
                    ENTC_FecRecogerDocs.Visible = false;
                    lblNVIA_NroManifiesto.Visible = false;
                    NVIA_NroManifiesto.Visible = false;
                    lblNVIA_NroManifiestoDes_IMPO.Visible = false;
                    NVIA_NroManifiestoDes_IMPO.Visible = false;
                    lblENTC_CodAgentePort_EXPO.Visible = false;
                    ENTC_CodAgentePort_EXPO.Visible = false;
                    lblENTC_CodTermPort.Visible = false;
                    ENTC_CodTermPort.Visible = false;
                    ENTC_CodAgentePortVoBo_IMPO.Visible = false;
                    lblENTC_CodAgentePortVoBo_IMPO.Visible = false;
                    ENTC_CodAgentePortVoBo2_IMPO.Visible = false;
                    lblENTC_CodAgentePortVoBo2_IMPO.Visible = false;


                    UsrCrea.Enabled = false;
                    FecCrea.Enabled = false;
                    NVIA_UsrCierreNave.Enabled = false;
                    NVIA_FecCierreNave.Enabled = false;
                    NVIA_UsrPreFactura.Enabled = false;
                    NVIA_FecPreFactura.Enabled = false;
                    txtNVIA_UsrEmiteStatment.Enabled = false;
                    mdtNVIA_FecEmiteStatment.Enabled = false;
                    cmbNVIA_Estado.Enabled = false;
                }
            }
            catch (Exception)
            {
            }

        }
        private void ShowCamposVia()
        {
            if (CONS_CodVIA.ConstantesSelectedItem != null)
            {

                if (CONS_CodVIA.ConstantesSelectedItem.CONS_CodTipo == Delfin.Controls.variables.CONSVIA_Aerea)
                {
                    lblNVIA_NroViaje.Text = "Nro. Vuelo";
                    lblNVIA_FecLlega_IMPO_Zarpe_EXPO.Text = "Fec. de Vuelo";
                }
                else
                {
                    ShowCamposImpoExpo();
                }
                NAVE_Codigo.Enabled = true;

                //Presenter.ItemsNaveUnTransportista = Presenter.ItemsNave.Where(Trans => Trans.ENTC_CodTransportista == ENTC_CodTransportista.Value.ENTC_Codigo && Trans.CONS_CodVia == CONS_CodVIA.ConstantesSelectedItem.CONS_CodTipo).ToObservableCollection();
                Presenter.ItemsNaveUnTransportista = Presenter.ItemsNave.Where(Trans => Trans.CONS_CodVia == CONS_CodVIA.ConstantesSelectedItem.CONS_CodTipo).ToObservableCollection();
                Presenter.ItemTransportista = ENTC_CodTransportista.Value;

                if (Presenter.ItemsNaveUnTransportista.Count == 0)
                {
                    NAVE_Codigo.Enabled = false;
                }
                NAVE_Codigo.ValueMember = "NAVE_Codigo";
                NAVE_Codigo.DisplayMember = "NAVE_Nombre";
                NAVE_Codigo.DataSource = Presenter.ItemsNaveUnTransportista;



                //Presenter.Actualizar();
            }
            else
            {
                Presenter.ItemsNaveUnTransportista = new ObservableCollection<Entities.Nave>();
                Presenter.ItemTransportista = null;
                ShowCamposImpoExpo();
                NAVE_Codigo.DataSource = null;
                NAVE_Codigo.Enabled = false;
            }
        }
        /// <summary>
        /// CRISTHIAN JOSE APAZA ARHUATA
        /// BLOQUEAR BOTONES SEGUN EL ESTADO DE LA NAVE VIAJE 
        /// </summary>
        private void ShowBotones()
        {
            try
            {
                if (Presenter.Item.NVIA_Codigo != 0)
                {
                    switch (Presenter.Item.NVIA_Estado.Trim())
                    {
                        case NVIA_Estado.Abierto:
                            if (Presenter.Item.NVIA_EmitioStatment)
                            {
                                ShowBotenesPreFacturado_EmisionStatment(false);
                            }
                            else
                            {
                                //######### BOTONES #################
                                btnMAN_guardar.Enabled = true;
                                btnMAN_salir.Enabled = true;
                                btnEmiti_Statement.Enabled = true;
                                btnAprobarStatement.Enabled = false;
                                btnAbrirStatement.Enabled = false;
                                btnCerrar_Nave.Enabled = false;
                                btnEmail.Enabled = false;
                                btnArchivos.Enabled = false;
                                //######### CAMPOS ##################
                                ENTC_CodTransportista.Enabled = true;
                                CONS_CodVIA.Enabled = true;
                                //NAVE_Codigo.Enabled = true;
                                CONS_CodRGM.Enabled = false;
                                ayudaPUER_Codigo.Enabled = true;
                                NVIA_NroViaje.Enabled = true;
                                NVIA_FecETA_IMPO_ETD_EXPO.Enabled = true;
                                NVIA_FecCutOff_EXPO.Enabled = true;
                                NVIA_FecLlega_IMPO_Zarpe_EXPO.Enabled = true;
                                NVIA_FecCierreDire_IMPO_TermEmba_EXPO.Enabled = true;
                                NVIA_FecDescarga_IMPO.Enabled = true;
                                ENTC_FecRecogerDocs.Enabled = true;
                                NVIA_NroManifiesto.Enabled = true;
                                NVIA_NroManifiestoDes_IMPO.Enabled = true;
                                ENTC_CodAgentePort_EXPO.Enabled = true;
                                ENTC_CodTermPort.Enabled = true;
                                ENTC_CodAgentePortVoBo_IMPO.Enabled = true;
                                ENTC_CodAgentePortVoBo2_IMPO.Enabled = true;
                                //###################################
                            }
                            break;
                        case NVIA_Estado.PreFacturado:
                            ShowBotenesPreFacturado_EmisionStatment(true);
                            break;
                        case NVIA_Estado.Cerrado:
                            //######### BOTONES #################
                            btnMAN_guardar.Enabled = true;
                            btnMAN_salir.Enabled = true;
                            btnEmiti_Statement.Enabled = true;
                            btnAprobarStatement.Enabled = false;
                            btnAbrirStatement.Enabled = false;
                            btnCerrar_Nave.Enabled = false;
                            btnEmail.Enabled = false;
                            btnArchivos.Enabled = false;
                            //######### CAMPOS ##################
                            ENTC_CodTransportista.Enabled = false;
                            CONS_CodVIA.Enabled = false;
                            NAVE_Codigo.Enabled = false;
                            CONS_CodRGM.Enabled = false;
                            ayudaPUER_Codigo.Enabled = false;
                            NVIA_NroViaje.Enabled = false;
                            NVIA_FecETA_IMPO_ETD_EXPO.Enabled = false;
                            NVIA_FecCutOff_EXPO.Enabled = false;
                            NVIA_FecLlega_IMPO_Zarpe_EXPO.Enabled = false;
                            NVIA_FecCierreDire_IMPO_TermEmba_EXPO.Enabled = false;
                            NVIA_FecDescarga_IMPO.Enabled = false;
                            ENTC_FecRecogerDocs.Enabled = false;
                            NVIA_NroManifiesto.Enabled = false;
                            NVIA_NroManifiestoDes_IMPO.Enabled = false;
                            ENTC_CodAgentePort_EXPO.Enabled = false;
                            ENTC_CodTermPort.Enabled = false;
                            ENTC_CodAgentePortVoBo_IMPO.Enabled = false;
                            ENTC_CodAgentePortVoBo2_IMPO.Enabled = false;
                            //###################################
                            break;
                    }
                }
                else
                {
                    //######### BOTONES ############
                    btnMAN_guardar.Enabled = true;
                    btnMAN_salir.Enabled = true;
                    btnEmiti_Statement.Enabled = false;
                    btnAprobarStatement.Enabled = false;
                    btnAbrirStatement.Enabled = false;
                    btnCerrar_Nave.Enabled = false;
                    btnEmail.Enabled = false;
                    btnArchivos.Enabled = false;
                    //#############################
                    //######### CAMPOS ##################
                    ENTC_CodTransportista.Enabled = true;
                    CONS_CodVIA.Enabled = true;
                    //NAVE_Codigo.Enabled = true;
                    CONS_CodRGM.Enabled = true;
                    ayudaPUER_Codigo.Enabled = true;
                    NVIA_NroViaje.Enabled = true;
                    NVIA_FecETA_IMPO_ETD_EXPO.Enabled = true;
                    NVIA_FecCutOff_EXPO.Enabled = true;
                    NVIA_FecLlega_IMPO_Zarpe_EXPO.Enabled = true;
                    NVIA_FecCierreDire_IMPO_TermEmba_EXPO.Enabled = true;
                    NVIA_FecDescarga_IMPO.Enabled = true;
                    ENTC_FecRecogerDocs.Enabled = true;
                    NVIA_NroManifiesto.Enabled = true;
                    NVIA_NroManifiestoDes_IMPO.Enabled = true;
                    ENTC_CodAgentePort_EXPO.Enabled = true;
                    ENTC_CodTermPort.Enabled = true;
                    ENTC_CodAgentePortVoBo_IMPO.Enabled = true;
                    ENTC_CodAgentePortVoBo2_IMPO.Enabled = true;
                    //###################################
                }
            }
            catch (Exception ex)
            {
                Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al bloquear los botones.", ex);
            }
        }
        private void ShowBotenesPreFacturado_EmisionStatment(Boolean X_PreFacturado)
        {
            //######### BOTONES #################
            btnMAN_guardar.Enabled = true;
            btnMAN_salir.Enabled = true;
            btnEmiti_Statement.Enabled = true;
            if (X_PreFacturado)
            {
                btnAprobarStatement.Enabled = false;
                btnAbrirStatement.Enabled = true;
                btnCerrar_Nave.Enabled = true;
                btnAvisosLlegada.Enabled = true;
            }
            else
            {
                btnAprobarStatement.Enabled = true;
                btnAbrirStatement.Enabled = false;
                btnCerrar_Nave.Enabled = false;
                btnAvisosLlegada.Enabled = false;
            }
            btnEmail.Enabled = true;
            btnArchivos.Enabled = true;
            //######### ARCHIVOS & CORREOS ######
            switch (Presenter.Item.CONS_CodRGM)
            {
                case Delfin.Controls.variables.CONSRGM_Importacion:
                    btnEmailAlmacen.Enabled = true;
                    btnCancelacionRecalada.Enabled = true;
                    btnDemoraArribo.Enabled = true;
                    btnEmitir_BL.Enabled = true;
                    //btnAvisosLlegada.Enabled = true;
                    btnCargaTarjadaLCL.Enabled = true;
                    btnCargaTarjadaFCL.Enabled = true;
                    btnDireccionamiento.Enabled = true;
                    btn_VoBo.Enabled = true;
                    break;
                case Delfin.Controls.variables.CONSRGM_Exportacion:
                    btnEmailAlmacen.Enabled = false;
                    btnCancelacionRecalada.Enabled = false;
                    btnDemoraArribo.Enabled = false;
                    btnEmitir_BL.Enabled = true;
                    //btnAvisosLlegada.Enabled = true;
                    btnCargaTarjadaLCL.Enabled = false;
                    btnCargaTarjadaFCL.Enabled = false;
                    btnDireccionamiento.Enabled = false;
                    btn_VoBo.Enabled = true;
                    break;
            }
            //######### CAMPOS ##################
            if (X_PreFacturado)
            {
                ENTC_CodTransportista.Enabled = false;
                ayudaPUER_Codigo.Enabled = false;
                NVIA_NroViaje.Enabled = false;
            }
            else
            {
                ENTC_CodTransportista.Enabled = true;
                ayudaPUER_Codigo.Enabled = true;
                NVIA_NroViaje.Enabled = true;
            }
            CONS_CodVIA.Enabled = false;
            NAVE_Codigo.Enabled = false;
            CONS_CodRGM.Enabled = false;
            NVIA_FecETA_IMPO_ETD_EXPO.Enabled = true;
            NVIA_FecCutOff_EXPO.Enabled = true;
            NVIA_FecLlega_IMPO_Zarpe_EXPO.Enabled = true;
            NVIA_FecCierreDire_IMPO_TermEmba_EXPO.Enabled = true;
            NVIA_FecDescarga_IMPO.Enabled = true;
            ENTC_FecRecogerDocs.Enabled = true;
            NVIA_NroManifiesto.Enabled = true;
            NVIA_NroManifiestoDes_IMPO.Enabled = true;
            ENTC_CodAgentePort_EXPO.Enabled = true;
            ENTC_CodTermPort.Enabled = true;
            ENTC_CodAgentePortVoBo_IMPO.Enabled = true;
            ENTC_CodAgentePortVoBo2_IMPO.Enabled = true;
            //###################################
        }
        private void LoadPuertos()
        {
            //try
            //{
            //    Boolean _inicializar = true;
            //    if (TIPO_CodPAI.TiposSelectedItem != null)
            //    {
            //        ObservableCollection<Entities.Puerto> _items = Presenter.ListPuertos.Where(puer => puer.TIPO_CodPais == TIPO_CodPAI.TiposSelectedItem.TIPO_CodTipo && puer.PUER_Favorito).ToObservableCollection();
            //        if (_items != null && _items.Count > 0)
            //        {
            //            foreach (Entities.Puerto _puerto in _items)
            //            {
            //                PUER_Codigo.AddComboBoxItem(_puerto.PUER_Codigo, _puerto.PUER_Nombre, _inicializar);
            //                _inicializar = false;
            //            }
            //            PUER_Codigo.LoadComboBox("< Seleccionar Puerto >", ListSortDirection.Ascending);
            //            PUER_Codigo.Enabled = true;
            //        }
            //        else
            //        {
            //            PUER_Codigo.DataSource = null;
            //            PUER_Codigo.Enabled = false;
            //        }
            //    }
            //    else
            //    {
            //        PUER_Codigo.DataSource = null;
            //        PUER_Codigo.Enabled = false;
            //    }
            //}
            //catch (Exception ex)
            //{ Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al cargar los puertos de origen.", ex); }
        }
        private void LoadPuertosDetalle()
        {
            try
            {
                Boolean _inicializar = true;
                if (TIPO_CodPAIDetalle.TiposSelectedItem != null)
                {
                    ObservableCollection<Entities.Puerto> _items = Presenter.ListPuertos.Where(puer => puer.TIPO_CodPais == TIPO_CodPAIDetalle.TiposSelectedItem.TIPO_CodTipo && puer.PUER_Favorito).ToObservableCollection();
                    if (_items != null && _items.Count > 0)
                    {
                        foreach (Entities.Puerto _puerto in _items)
                        {
                            PUER_CodigoDetalle.AddComboBoxItem(_puerto.PUER_Codigo, _puerto.PUER_Nombre, _inicializar);
                            _inicializar = false;
                        }
                        PUER_CodigoDetalle.LoadComboBox("< Seleccionar Puerto >", ListSortDirection.Ascending);
                        PUER_CodigoDetalle.Enabled = true;
                    }
                    else
                    {
                        PUER_CodigoDetalle.DataSource = null;
                        PUER_CodigoDetalle.Enabled = false;
                    }
                }
                else
                {
                    PUER_CodigoDetalle.DataSource = null;
                    PUER_CodigoDetalle.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al cargar los puertos de origen.", ex);
            }
        }
        public StringBuilder CreateHeader(ref StringBuilder _table)
        {
            _table.Append("<table border=1 cellpadding=4 cellspacing=0 style=font-size:10px >");
            _table.Append("<tr><th colspan=6> DESCARGAS </th><tr><th> MBL </th><th> HBL </th><th> CLIENTE </th><th> NAVE </th><th> VIAJE </th><th> DEPOSITO </th></tr>");
            return _table;
        }
        public StringBuilder CreateBody(ref StringBuilder _table, Entities.Cab_Cotizacion_OV item)
        {
            _table.Append("<tr>");
            _table.Append("<td>" + item.DOOV_MBL + "</td>");
            _table.Append("<td>" + item.DOOV_HBL + "</td>");
            _table.Append("<td>" + item.ENTC_NomCliente + "</td>");
            _table.Append("<td>" + Presenter.Item.NAVE_Nombre + "</td>");
            _table.Append("<td>" + Presenter.Item.NVIA_NroViaje + "</td>");
            _table.Append("<td>" + item.ENTC_NomDTE + "</td>");
            _table.Append("</tr>");
            return _table;
        }
        public void FormatGridDetalle(String _CONS_CodRGM)
        {


            Telerik.WinControls.UI.Localization.RadGridLocalizationProvider.CurrentProvider = new Infrastructure.WinForms.Controls.MySpanishRadGridLocalizationProvider();
            this.grdItemsDetalle.Columns.Clear();
            this.grdItemsDetalle.AllowAddNewRow = false;

            switch (_CONS_CodRGM)
            {
                case Delfin.Controls.variables.CONSRGM_Importacion:
                    grdItemsDetalle.Columns.Add("DVIA_FecETA_EXPO_ETDMaster_IMPO", "Fecha Embarque", "DVIA_FecETA_EXPO_ETDMaster_IMPO");
                    break;
                case Delfin.Controls.variables.CONSRGM_Exportacion:
                    grdItemsDetalle.Columns.Add("DVIA_FecETA_EXPO_ETDMaster_IMPO", "Fecha ETA", "DVIA_FecETA_EXPO_ETDMaster_IMPO");
                    break;
            }

            grdItemsDetalle.Columns.Add("TIPO_DescPAI", "País", "TIPO_DescPAI");
            grdItemsDetalle.Columns.Add("PUER_Nombre", "Puerto", "PUER_Nombre");

            grdItemsDetalle.BestFitColumns();
            Infrastructure.WinForms.Controls.GridAutoFit.Fit(grdItemsDetalle);
            grdItemsDetalle.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;

            this.grdItemsDetalle.Enabled = true;
            this.grdItemsDetalle.ShowFilteringRow = false;
            this.grdItemsDetalle.EnableFiltering = false;
            this.grdItemsDetalle.MasterTemplate.EnableFiltering = false;
            this.grdItemsDetalle.EnableGrouping = false;
            this.grdItemsDetalle.MasterTemplate.EnableGrouping = false;
            this.grdItemsDetalle.EnableSorting = false;
            this.grdItemsDetalle.MasterTemplate.EnableCustomSorting = false;

            //##############################
            BSItemsDetalles.DataSource = Presenter.Item.ItemsDetNaveViaje;
            grdItemsDetalle.DataSource = BSItemsDetalles;
            BSItemsDetalles.ResetBindings(true);
            //##############################
        }
        //private String BuscarCorreo_Codigo(String _PARA_Clave)
        //{
        //    String valor = string.Empty;
        //    ObservableCollection<Entities.Parametros> ParametrosCorreo = new ObservableCollection<Entities.Parametros>();
        //    Entities.Parametros ItemCorreo = new Entities.Parametros();
        //    ParametrosCorreo = Presenter.ItemsParametrosCorreo.Where(Trans => Trans.PARA_Clave == _PARA_Clave).ToObservableCollection();
        //    ItemCorreo = ParametrosCorreo[0];
        //    valor = ItemCorreo.PARA_Valor;
        //    return valor;
        //}
        /// <summary>
        /// CRISTHIAN JOSE APAZA ARHUATA
        /// OCULTAR LOS BOTONES Y CAMPOS PARA LA CREACION DE UN DETALLE PORQUE SERA DE FORMA AUTOMATICA
        /// </summary>
        private void OcultarCamposDetalles()
        {
            try
            {
                btnNuevoDetalle.Visible = false;
                btnEditarDetalle.Visible = false;
                btnEliminarDetalle.Visible = false;
                btnGuardarDetalle.Visible = false;
                btnDeshacerDetalle.Visible = false;
                lblTIPO_CodPAIDetalle.Visible = false;
                TIPO_CodPAIDetalle.Visible = false;
                lblPUER_CodigoDetalle.Visible = false;
                PUER_CodigoDetalle.Visible = false;
                lblDVIA_FecETA_EXPO_ETDMaster_IMPO.Visible = false;
                DVIA_FecETA_EXPO_ETDMaster_IMPO.Visible = false;
            }
            catch (Exception ex)
            {
                Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al ocultar el detalle.", ex);
            }
        }
        /// <summary>
        /// CRISTHIAN JOSE APAZA ARHUATA
        /// EMAIL A LOS ALMACENES (DIRECCIONAMIENTO)
        /// </summary>
        private Boolean EmailAlmacen()
        {
            Boolean _iscorrect = false;
            try
            {
                if (Presenter.Item.ItemsNVIA_DepTemp != null && Presenter.Item.ItemsNVIA_DepTemp.Count > 0)
                {
                    string _mensajeError = string.Empty;
                    string olCCrecipient = Presenter.PARA_CORREOOPERACIONES == null ? null : Presenter.PARA_CORREOOPERACIONES.PARA_Valor;
                    Delfin.Controls.Utils.checkMail("Operaciones", olCCrecipient, ref _mensajeError);
                    foreach (Entities.Cab_Cotizacion_OV item in Presenter.Item.ItemsNVIA_DepTemp)
                    {
                        Delfin.Controls.Utils.checkMail(item.ENTC_NomDTE, item.ENTC_EmailDTE, ref _mensajeError);
                    }
                    if (string.IsNullOrEmpty(_mensajeError))
                    {
                        Delfin.Controls.EnviarCorreo ec = new Controls.EnviarCorreo();
                        string body = null;
                        string recipient = null;
                        string subject = null;
                        string almacen = null;

                        Boolean enviar = false;
                        StringBuilder _body = new StringBuilder();

                        _body.Append("<html>");
                        _body.Append("<font color= #2f5496 >");
                        _body.Append("<body>");
                        _body.Append("<h4>Estimados : </h4>");
                        _body.Append("<p>Considerar la siguiente descarga para sus almacenes </p>");
                        _body.Append("</body>");
                        _body.Append("</font>");
                        _body.Append("</html>");


                        StringBuilder _table = new StringBuilder();
                        Int32 _CodDTE_Actual = 0;
                        int pos = 1;
                        foreach (Entities.Cab_Cotizacion_OV item in Presenter.Item.ItemsNVIA_DepTemp)
                        {
                            if (_CodDTE_Actual == 0)
                            {
                                CreateHeader(ref _table);
                                almacen = item.ENTC_NomDTE;
                                recipient = item.ENTC_EmailDTE; if (String.IsNullOrEmpty(recipient)) { recipient = "<INGRESE_EMAIL_DTE>"; }
                            }

                            if (item.ENTC_CodDTE == _CodDTE_Actual || _CodDTE_Actual == 0)
                            {
                                _CodDTE_Actual = item.ENTC_CodDTE;
                                CreateBody(ref _table, item);

                            }
                            else
                            {
                                //######################################################
                                _table.Append("</table>");
                                _table.Append("<font color= #2f5496 >");
                                _table.Append("<p> </p>");
                                _table.Append("<p>Por Favor Confirmar recepción</p>");
                                _table.Append("<p>Saludos.</p>");
                                _table.Append("</font>");
                                body = _body.ToString() + _table.ToString();
                                subject = "DIRECCIONAMIENTO \\ " + Presenter.Item.NAVE_Nombre + "-" + Presenter.Item.NVIA_NroViaje + " \\ " + almacen;
                                ec.enviaCorreo(enviar, recipient, olCCrecipient, subject, body);
                                //######################################################

                                _CodDTE_Actual = item.ENTC_CodDTE;
                                almacen = item.ENTC_NomDTE;
                                recipient = item.ENTC_EmailDTE; if (String.IsNullOrEmpty(recipient)) { recipient = "<INGRESE_EMAIL_DTE>"; }
                                _table = new StringBuilder();
                                CreateHeader(ref _table);
                                CreateBody(ref _table, item);
                            }

                            if (pos == Presenter.Item.ItemsNVIA_DepTemp.Count)
                            {
                                //######################################################
                                _table.Append("</table>");
                                _table.Append("<font color= #2f5496 >");
                                _table.Append("<p> </p>");
                                _table.Append("<p>Por Favor Confirmar recepción</p>");
                                _table.Append("<p>Saludos.</p>");
                                _table.Append("</font>");
                                body = _body.ToString() + _table.ToString();
                                subject = "DIRECCIONAMIENTO \\ " + Presenter.Item.NAVE_Nombre + "-" + Presenter.Item.NVIA_NroViaje + " \\ " + almacen;
                                ec.enviaCorreo(enviar, recipient, olCCrecipient, subject, body);
                                //######################################################
                                _iscorrect = true;
                            }
                            pos++;
                        }
                    }
                    else
                    {
                        Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Presenter.Title, "Verifique los siguientes Correos Electronicos (detalles)", _mensajeError);
                        _iscorrect = false;
                    }
                    return _iscorrect;
                }
                else
                {
                    Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Presenter.Title, "No hay Ordenes de venta con Almacenes relacionadas a esta Nave Viaje");
                    return _iscorrect;
                }
            }
            catch (Exception)
            {
                return _iscorrect;
            }
        }
        #endregion

        #region [ Eventos ]
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (NVIA_FecETA_IMPO_ETD_EXPO.NSFecha != null)
                {
                    DateTime _FecCrea = Convert.ToDateTime(FecCrea.NSFecha);
                    DateTime _NVIA_FecETA_IMPO_ETD_EXPO = Convert.ToDateTime(NVIA_FecETA_IMPO_ETD_EXPO.NSFecha);
                    if (_FecCrea > _NVIA_FecETA_IMPO_ETD_EXPO)
                    {
                        String _Mensaje = String.Format("La fecha ETA/ETD {0} que se está registrando es inferior a la fecha de creación {1}. ¿Desea continuar?", _NVIA_FecETA_IMPO_ETD_EXPO.ToString("dd/MM/yyyy"), _FecCrea.ToString("dd/MM/yyyy"));
                        System.Windows.Forms.DialogResult _result = Infrastructure.WinForms.Controls.Dialogos.MostrarMensajePregunta(Presenter.Title, _Mensaje, Infrastructure.WinForms.Controls.Dialogos.LabelBoton.Si_No);
                        if (_result == System.Windows.Forms.DialogResult.Yes)
                        {
                            Save();
                        }
                    }
                    else
                    {
                        Save();
                    }
                }
                else
                {
                    Save();
                }
            }
            catch (Exception ex)
            {
                Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al Guardar.", ex);
            }
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
                    {
                        //this.Close();
                        this.DialogResult = System.Windows.Forms.DialogResult.OK;
                    }
                    else
                    {
                        this.FormClosing += MView_FormClosing;
                    }
                }
                else
                {
                    //this.Close();
                    this.DialogResult = System.Windows.Forms.DialogResult.OK;
                }
                Closing = true;
            }
            catch (Exception ex)
            {
                Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al cerrar el formulario.", ex);
            }
        }
        private void ENTC_CodTransportista_AyudaValueChanged(object sender, EventArgs e)
        {
            if (ENTC_CodTransportista.Value != null)
            {
                if (ENTC_CodTransportista.Value.Relacionados != null && ENTC_CodTransportista.Value.Relacionados.Count > 0)
                {
                    var Relacionado = ENTC_CodTransportista.Value.Relacionados.Where(rela => rela.TIPE_Codigo == Convert.ToInt16(Delfin.Controls.TiposEntidad.TIPE_AgentePortuario)).FirstOrDefault();
                    if (Relacionado != null)
                    {
                        ENTC_CodAgentePort_EXPO.SetValue(Relacionado.ENTC_Codigo);
                        ENTC_CodAgentePortVoBo_IMPO.SetValue(Relacionado.ENTC_Codigo);
                    }
                    else
                    {
                        ENTC_CodAgentePort_EXPO.ClearValue();
                        ENTC_CodAgentePortVoBo_IMPO.ClearValue();
                    }
                }
                else
                {
                    ENTC_CodAgentePort_EXPO.ClearValue();
                    ENTC_CodAgentePortVoBo_IMPO.ClearValue();
                }
            }
            else
            {
                ENTC_CodAgentePort_EXPO.ClearValue();
                ENTC_CodAgentePortVoBo_IMPO.ClearValue();
            }
        }
        private void CONS_CodVIADetalle_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ShowCamposVia();
            }
            catch (Exception)
            { }
        }
        private void NAVE_Codigo_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
               if (string.IsNullOrEmpty(NVIA_NroViaje.Text) || Presenter.Item.Instance == Infrastructure.Aspect.BusinessEntity.InstanceEntity.Added)
               {
                  if (NAVE_Codigo.SelectedItem != null)
                  { NVIA_NroViaje.Text = NAVE_Codigo.Text; ; }
                  else
                  { NVIA_NroViaje.Text = String.Empty; }
               }

            }
            catch (Exception)
            { }
        }
        private void CONS_CodRGM_SelectedIndexChanged(object sender, EventArgs e)
        {
            ShowCamposImpoExpo();
        }
        private void TIPO_CodPAI_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadPuertos();
        }
        private void TIPO_CodPAIDetalle_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadPuertosDetalle();
        }
        private void cmbNVIA_Estado_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbNVIA_Estado.ConstantesSelectedItem != null)
            {
                ShowBotones();
            }
            else
            {
                btnPreFacturar.Enabled = false;
                btnCerrar_Nave.Enabled = false;
                btnEmiti_Statement.Enabled = false;
                btnEmail.Enabled = false;
                btnArchivos.Enabled = false;
            }


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
                {
                    Closing = false;
                    e.Cancel = true;
                }
            }
            catch (Exception ex)
            {
                Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al cerrar el formulario.", ex);
            }
        }

        #region [ Correos & Archivos ]
        private void btnEmailAlmacen_Click(object sender, EventArgs e)
        {
            if (EmailAlmacen())
            {
                DT_OV = new DataTable();
                DT_OV = Presenter.BuscarOv(Presenter.Item.NVIA_Codigo, _TIPO_Condicion.AvisoAlmacen);
                Presenter.GenerarEventosTareas("Se ha generado el correo para el Aviso de Almacen de la Orden de Venta desde Nave-Viaje", Presenter.PARA_EMAILALMACEN.PARA_Valor, DT_OV);
            }
        }
        private void btnCancelacionRecalada_Click(object sender, EventArgs e)
        {
            try
            {
                if (Presenter.Item.ItemsNVIA_Clientes != null && Presenter.Item.ItemsNVIA_Clientes.Count > 0)
                {
                    string _mensajeError = string.Empty;
                    string recipient = Presenter.PARA_CORREOOPERACIONES == null ? null : Presenter.PARA_CORREOOPERACIONES.PARA_Valor;
                    Delfin.Controls.Utils.checkMail("Operaciones", recipient, ref _mensajeError);
                    foreach (Entities.Entidad item in Presenter.Item.ItemsNVIA_Clientes)
                    {
                        Delfin.Controls.Utils.checkMail(item.ENTC_NomCompleto, item.ENTC_EMail, ref _mensajeError);
                    }
                    if (string.IsNullOrEmpty(_mensajeError))
                    {
                        Delfin.Controls.EnviarCorreo ec = new Controls.EnviarCorreo();
                        string subject = "OMITE RECALADA " + Presenter.Item.NAVE_Nombre + " - Viaje:" + Presenter.Item.NVIA_NroViaje;
                        StringBuilder _body = new StringBuilder();
                        _body.Append("<html>");
                        _body.Append("<font color= #2f5496 >");
                        _body.Append("<body>");
                        _body.Append("<h4>Estimados Clientes: </h4>");
                        _body.Append("<p> Por medio de la  presente los saludamos cordialmente y les informamos que la Nave " + Presenter.Item.NAVE_Nombre + " ha cancelado recalada en Callao por temas operativos, se adjunta comunicado de la línea </p>");
                        _body.Append("</body>");
                        _body.Append("</font>");
                        _body.Append("</html>");
                        string body = _body.ToString();
                        ec.enviaCorreo(Presenter.Item.ItemsNVIA_Clientes, recipient, subject, body);
                    }
                    else
                    {
                        Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Presenter.Title, "Verifique los siguientes Correos Electronicos (detalles)", _mensajeError);
                    }
                }
                else
                {
                    Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Presenter.Title, "No se encontró ningun Cliente relacionado a esta Nave Viaje");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error durante el proceso del Envío del Correo: " + ex.Message, "Error Interno", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnDemoraArribo_Click(object sender, EventArgs e)
        {
            try
            {
                if (Presenter.Item.ItemsNVIA_Clientes != null && Presenter.Item.ItemsNVIA_Clientes.Count > 0)
                {
                    string _mensajeError = string.Empty;
                    string recipient = Presenter.PARA_CORREOOPERACIONES == null ? null : Presenter.PARA_CORREOOPERACIONES.PARA_Valor;
                    Delfin.Controls.Utils.checkMail("Operaciones", recipient, ref _mensajeError);
                    foreach (Entities.Entidad item in Presenter.Item.ItemsNVIA_Clientes)
                    {
                        Delfin.Controls.Utils.checkMail(item.ENTC_NomCompleto, item.ENTC_EMail, ref _mensajeError);
                    }
                    if (string.IsNullOrEmpty(_mensajeError))
                    {
                        Delfin.Controls.EnviarCorreo ec = new Controls.EnviarCorreo();
                        string subject = "INFORME DE LA NAVE:" + Presenter.Item.NAVE_Nombre + " - Viaje:" + Presenter.Item.NVIA_NroViaje;
                        StringBuilder _body = new StringBuilder();
                        _body.Append("<html>");
                        _body.Append("<font color= #2f5496 >");
                        _body.Append("<body>");
                        _body.Append("<h4>Estimados Clientes: </h4>");
                        _body.Append("<p> Por medio de la  presente los saludamos cordialmente y les informamos que la Nave " + Presenter.Item.NAVE_Nombre + " tiene un nuevo Eta a " + Presenter.Item.PUER_Nombre + " se adjunta comunicado de la línea. </p>");
                        _body.Append("</body>");
                        _body.Append("</font>");
                        _body.Append("</html>");
                        string body = _body.ToString();
                        ec.enviaCorreo(Presenter.Item.ItemsNVIA_Clientes, recipient, subject, body);
                    }
                    else
                    {
                        Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Presenter.Title, "Verifique los siguientes Correos Electronicos (detalles)", _mensajeError);
                    }
                }
                else
                {
                    Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Presenter.Title, "No se encontró ningun Cliente relacionado a esta Nave Viaje");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error durante el proceso del Envío del Correo: " + ex.Message, "Error Interno", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnCargaTarjadaLCL_Click(object sender, EventArgs e)
        {
            try
            {

                //########## PARAMETROS ##########
                Delfin.Controls.EmailFiles EFiles = null;
                Nullable<DateTime> _fec_eta_etd = Presenter.Item.NVIA_FecETA_IMPO_ETD_EXPO;
                Nullable<DateTime> _fec_llegada = Presenter.Item.NVIA_FecLlega_IMPO_Zarpe_EXPO;
                String _nombre_transportista = Presenter.Item.ENTC_NomTransp;
                String _nombre_nave = Presenter.Item.NAVE_Nombre;
                String _numero_viaje = Presenter.Item.NVIA_NroViaje;
                String _nombre_termportuario = Presenter.Item.ENTC_NomTermin;
                String _numero_manifiesto = Presenter.Item.NVIA_NroManifiesto;
                String _correo_operaciones = Presenter.PARA_CORREOOPERACIONES == null ? null : Presenter.PARA_CORREOOPERACIONES.PARA_Valor;
                //################################

                Presenter.CargaTarjada(Presenter.Item.NVIA_Codigo, _TIPO_Embarque.LCL);
                if (Presenter.DtCargaTarjada != null && Presenter.DtCargaTarjada.Rows.Count > 0)
                {
                    string _mensajeError = string.Empty;
                    Delfin.Controls.Utils.checkMail("Operaciones", _correo_operaciones, ref _mensajeError);
                    foreach (DataRow drCargaTarjada in Presenter.DtCargaTarjada.Rows)
                    {
                        string _nombre = Convert.ToString(drCargaTarjada["ENTC_NomCliente"]);
                        string _correo = Convert.ToString(drCargaTarjada["ENTC_EMailCliente"]);
                        Delfin.Controls.Utils.checkMail(_nombre, _correo, ref _mensajeError);
                    }
                    if (string.IsNullOrEmpty(_mensajeError))
                    {
                        EFiles = new Controls.EmailFiles();
                        String _mensaje = EFiles.CargaTarjada(Presenter.DtCargaTarjada, _fec_llegada, _fec_eta_etd, _TIPO_Embarque.LCL, _nombre_transportista, _nombre_nave, _nombre_termportuario, _numero_manifiesto, _numero_viaje, _correo_operaciones);
                        if (!String.IsNullOrEmpty(_mensaje))
                        {
                            if (_mensaje.Substring(0, 1) == "#")
                            { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Presenter.Title, "OCURRIO UN ERROR EN EL METODO DE DESGLOSE DE VoBo (Ver Detalles)", _mensaje); }
                            else
                            {
                                _mensaje = String.Format("No hay de Ordenes de Venta con el Tipo de Embarque LCL ó {0}", _mensaje);
                                Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Presenter.Title, _mensaje);
                            }
                        }
                    }
                    else
                    {
                        Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Presenter.Title, "Verifique los siguientes Correos Electronicos (detalles)", _mensajeError);
                    }
                    //CargaTarjada(_TIPO_Embarque.LCL);
                }
                else
                {
                    Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Presenter.Title, "No hay de Ordenes de Venta con el Tipo de Embarque LCL");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error durante el proceso del Envío del Correo: " + ex.Message, "Error Interno", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void btnCargaTarjadaFCL_Click(object sender, EventArgs e)
        {
            try
            {
                //########## PARAMETROS ##########
                Delfin.Controls.EmailFiles EFiles = null;
                Nullable<DateTime> _fec_eta_etd = Presenter.Item.NVIA_FecETA_IMPO_ETD_EXPO;
                Nullable<DateTime> _fec_llegada = Presenter.Item.NVIA_FecLlega_IMPO_Zarpe_EXPO;
                String _nombre_transportista = Presenter.Item.ENTC_NomTransp;
                String _nombre_nave = Presenter.Item.NAVE_Nombre;
                String _numero_viaje = Presenter.Item.NVIA_NroViaje;
                String _nombre_termportuario = Presenter.Item.ENTC_NomTermin;
                String _numero_manifiesto = Presenter.Item.NVIA_NroManifiesto;
                String _correo_operaciones = Presenter.PARA_CORREOOPERACIONES == null ? null : Presenter.PARA_CORREOOPERACIONES.PARA_Valor;
                //################################

                Presenter.CargaTarjada(Presenter.Item.NVIA_Codigo, _TIPO_Embarque.FCL);
                if (Presenter.DtCargaTarjada != null && Presenter.DtCargaTarjada.Rows.Count > 0)
                {
                    string _mensajeError = string.Empty;
                    Delfin.Controls.Utils.checkMail("Operaciones", _correo_operaciones, ref _mensajeError);
                    foreach (DataRow drCargaTarjada in Presenter.DtCargaTarjada.Rows)
                    {
                        string _nombre = Convert.ToString(drCargaTarjada["ENTC_NomCliente"]);
                        string _correo = Convert.ToString(drCargaTarjada["ENTC_EMailCliente"]);
                        Delfin.Controls.Utils.checkMail(_nombre, _correo, ref _mensajeError);
                    }
                    if (string.IsNullOrEmpty(_mensajeError))
                    {
                        EFiles = new Controls.EmailFiles();
                        String _mensaje = EFiles.CargaTarjada(Presenter.DtCargaTarjada, _fec_llegada, _fec_eta_etd, _TIPO_Embarque.FCL, _nombre_transportista, _nombre_nave, _nombre_termportuario, _numero_manifiesto, _numero_viaje, _correo_operaciones);
                        if (!String.IsNullOrEmpty(_mensaje))
                        {
                            if (_mensaje.Substring(0, 1) == "#")
                            { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Presenter.Title, "OCURRIO UN ERROR EN EL METODO DE DESGLOSE DE VoBo (Ver Detalles)", _mensaje); }
                            else
                            {
                                _mensaje = String.Format("No hay de Ordenes de Venta con el Tipo de Embarque FCL ó {0}", _mensaje);
                                Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Presenter.Title, _mensaje);
                            }
                        }

                        //CargaTarjada(_TIPO_Embarque.FCL);
                    }
                    else
                    {
                        Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Presenter.Title, "Verifique los siguientes Correos Electronicos (detalles)", _mensajeError);
                    }
                    //CargaTarjada(_TIPO_Embarque.LCL);
                }
                else
                {
                    Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Presenter.Title, "No hay de Ordenes de Venta con el Tipo de Embarque FCL");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error durante el proceso del Envío del Correo: " + ex.Message, "Error Interno", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void btnVoBo_Click(object sender, EventArgs e)
        {
            try
            {
                String _Cod_Tramarsa = Presenter.PARA_CODIGOTRAMARSA.PARA_Valor;//BuscarCorreo_Codigo("CODIGO_TRAMARSA");
                String _Cod_AgentePor = Convert.ToString(Presenter.Item.ENTC_CodAgenPortVoBo_IMPO);
                Nullable<Int32> _NVIA_Codigo = Presenter.Item.NVIA_Codigo;

                //########## PARAMETROS ##########
                Delfin.Controls.EmailFiles EFiles = null;
                Boolean _por_ov = false;
                Nullable<DateTime> _fec_eta = Presenter.Item.NVIA_FecETA_IMPO_ETD_EXPO;
                Nullable<DateTime> _fec_zarpe = Presenter.Item.NVIA_FecLlega_IMPO_Zarpe_EXPO;
                Nullable<Int32> _nvia_codigo = Presenter.Item.NVIA_Codigo;
                String _agente = String.Empty;
                switch (Presenter.Item.CONS_CodRGM)
                {
                    case Delfin.Controls.variables.CONSRGM_Importacion:
                        _agente = Presenter.Item.ENTC_NomAgent1;
                        break;
                    case Delfin.Controls.variables.CONSRGM_Exportacion:
                        _agente = Presenter.Item.ENTC_NomAgente;
                        break;
                }
                String _nombre_nave = Presenter.Item.NAVE_Nombre;
                String _numero_viaje = Presenter.Item.NVIA_NroViaje;
                String _codigo_regimen = Presenter.Item.CONS_CodRGM;
                //################################

                if (_Cod_AgentePor == _Cod_Tramarsa)
                {
                    Presenter.DesgloseVoBo(_NVIA_Codigo, 2); //cualquier numero execto el 1 es TRAMARSA
                    EFiles = new Controls.EmailFiles();
                    String _mensaje = EFiles.DocVoBoTramarsa(_por_ov, Presenter.VoBo, _fec_eta, _agente, _nombre_nave, _numero_viaje);
                    if (!String.IsNullOrEmpty(_mensaje))
                    {
                        if (_mensaje.Substring(0, 1) == "#")
                        { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Presenter.Title, "OCURRIO UN ERROR EN EL METODO DE DESGLOSE DE VoBo (Ver Detalles)", _mensaje); }
                        else
                        { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Presenter.Title, _mensaje); }
                    }
                    else
                    {
                        Presenter.GenerarEventosTareas("Se ha generado el Doc. de Desglose De VoBo desde Nave-Viaje", Presenter.PARA_DESGLOSEVoBo.PARA_Valor, Presenter.VoBo);
                    }
                }
                else
                {
                    Presenter.DesgloseVoBo(_NVIA_Codigo, 1); //numero 1 cualquier agente menos TRAMARSA
                    EFiles = new Controls.EmailFiles();
                    String _mensaje = EFiles.DocVoBo(Presenter.VoBo, _fec_eta, _fec_zarpe, _nvia_codigo, _agente, _nombre_nave, _numero_viaje, _codigo_regimen);
                    if (!String.IsNullOrEmpty(_mensaje))
                    {
                        if (_mensaje.Substring(0, 1) == "#")
                        { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Presenter.Title, "OCURRIO UN ERROR EN EL METODO DE DESGLOSE DE VoBo (Ver Detalles)", _mensaje); }
                        else
                        { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Presenter.Title, _mensaje); }
                    }
                    else
                    {
                        Presenter.GenerarEventosTareas("Se ha generado el Doc. de Desglose De VoBo desde Nave-Viaje", Presenter.PARA_DESGLOSEVoBo.PARA_Valor, Presenter.VoBo);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error durante el proceso de abrir el documento: " + ex.Message, "Error Interno", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnDireccionamiento_Click(object sender, EventArgs e)
        {
            try
            {
                string _mensajeError = string.Empty;
                string _correo_ope = Presenter.PARA_CORREOOPERACIONES == null ? null : Presenter.PARA_CORREOOPERACIONES.PARA_Valor;
                Delfin.Controls.Utils.checkMail("Operaciones", _correo_ope, ref _mensajeError);
                if (string.IsNullOrEmpty(_mensajeError))
                {
                    String _Cod_Cosco = Presenter.PARA_CODIGOCOSCO.PARA_Valor;//BuscarCorreo_Codigo("CODIGO_COSCO_PERU");
                    String _Cod_Transportista = Convert.ToString(Presenter.Item.ENTC_CodTransportista);
                    Nullable<Int32> _NVIA_Codigo = Presenter.Item.NVIA_Codigo;

                    //########## PARAMETROS ##########
                    Delfin.Controls.EmailFiles EFiles = null;
                    Boolean _por_ov = false;
                    Nullable<DateTime> _fec_eta_etd = Presenter.Item.NVIA_FecETA_IMPO_ETD_EXPO;
                    String _transportista = Presenter.Item.ENTC_NomTransp;
                    String _nombre_nave = Presenter.Item.NAVE_Nombre;
                    String _numero_viaje = Presenter.Item.NVIA_NroViaje;
                    //################################

                    if (_Cod_Transportista == _Cod_Cosco)
                    {
                        Presenter.Direccionamiento(_NVIA_Codigo, 1); //numero 1 es COSCO
                        EFiles = new Controls.EmailFiles();
                        String _mensaje = EFiles.CorreoDireccionamientoCosco(_por_ov, Presenter.DtDireciomaniento, _fec_eta_etd, _transportista, _nombre_nave, _numero_viaje, _correo_ope);
                        if (!String.IsNullOrEmpty(_mensaje))
                        {
                            if (_mensaje.Substring(0, 1) == "#")
                            { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Presenter.Title, "OCURRIO UN ERROR EN EL METODO DE DIRECCIONAMIENTO (Ver Detalles)", _mensaje); }
                            else
                            { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Presenter.Title, _mensaje); }
                        }
                        else
                        {
                            DT_OV = new DataTable();
                            DT_OV = Presenter.BuscarOv(Presenter.Item.NVIA_Codigo, _TIPO_Condicion.Direccionamiento);
                            Presenter.GenerarEventosTareas("Se ha generado el correo para el Direccionamiento de la Linea de la Orden de Venta desde Nave-Viaje", Presenter.PARA_DIRECCIONAMIENTOLINEA.PARA_Valor, DT_OV);
                        }
                    }
                    else
                    {
                        Presenter.Direccionamiento(_NVIA_Codigo, 2); //cualquier otro numero es otro transportista
                        EFiles = new Controls.EmailFiles();
                        String _mensaje = EFiles.CorreoDireccionamiento(Presenter.DtDireciomaniento, _fec_eta_etd, _transportista, _nombre_nave, _numero_viaje, _correo_ope);
                        if (!String.IsNullOrEmpty(_mensaje))
                        {
                            if (_mensaje.Substring(0, 1) == "#")
                            { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Presenter.Title, "OCURRIO UN ERROR EN EL METODO DE DIRECCIONAMIENTO (Ver Detalles)", _mensaje); }
                            else
                            { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Presenter.Title, _mensaje); }
                        }
                        else
                        {
                            DT_OV = new DataTable();
                            DT_OV = Presenter.BuscarOv(Presenter.Item.NVIA_Codigo, _TIPO_Condicion.Direccionamiento);
                            Presenter.GenerarEventosTareas("Se ha generado el correo para el Direccionamiento de la Linea de la Orden de Venta desde Nave-Viaje", Presenter.PARA_DIRECCIONAMIENTOLINEA.PARA_Valor, DT_OV);
                        }
                    }
                }
                else
                {
                    Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Presenter.Title, "Verifique los siguientes Correos Electronicos (detalles)", _mensajeError);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error durante el proceso del Envío del Correo Direccionamiento: " + ex.Message, "Error Interno", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public bool IsValidEmail(string email)
        {
            if (email.Trim() == "")
            { return false; }
            //return Regex.IsMatch(email, "^([0-9a-zA-Z]([-\\.\\w]*[0-9a-zA-Z])*[-\\.\\w]*[-\\.\\w]@([0-9a-zA-Z][-\\w]*[0-9a-zA-Z]\\.)+[a-zA-Z]{2,9})$");
            return true;
        }
        private void btnAvisosLlegada_Click(object sender, EventArgs e)
        {
            try
            {
                string _mensajeError = string.Empty;
                string _correo_ope = Presenter.PARA_CORREOOPERACIONES == null ? null : Presenter.PARA_CORREOOPERACIONES.PARA_Valor;
                string _correo_log = Presenter.PARA_CORREOLOGISTICA == null ? null : Presenter.PARA_CORREOLOGISTICA.PARA_Valor;
                Presenter.CartasAvisos();
                if (Presenter.DtAvisos != null && Presenter.DtAvisos.Rows.Count > 0)
                {
                    Delfin.Controls.Utils.checkMail("Operaciones", _correo_ope, ref _mensajeError);
                    Delfin.Controls.Utils.checkMail("Logística", _correo_log, ref _mensajeError);
                    foreach (DataRow drAvisos in Presenter.DtAvisos.Rows)
                    {
                        //Delfin.Controls.Utils.checkMail(Convert.ToString(drAvisos["ENTC_NomCliente"]), Convert.ToString(drAvisos["ENTC_EMailCliente"]), ref _mensajeError);
                        if (!IsValidEmail(drAvisos["ENTC_EmailCliente"].ToString()))
                        {
                            _mensajeError = "El correo " + drAvisos["ENTC_EmailCliente"].ToString() + " de " + drAvisos["ENTC_NomCliente"].ToString() + " no tiene el formato correcto.";
                        }
                        Delfin.Controls.Utils.checkMail(Convert.ToString(drAvisos["ENTC_NomCustomer"]), Convert.ToString(drAvisos["ENTC_EmailCustomer"]), ref _mensajeError);
                        Delfin.Controls.Utils.checkMail(Convert.ToString(drAvisos["ENTC_NomEjecutivo"]), Convert.ToString(drAvisos["ENTC_EmailEjecutivo"]), ref _mensajeError);
                    }
                }
                if (string.IsNullOrEmpty(_mensajeError))
                {
                    //########## PARAMETROS ##########
                    Delfin.Controls.EmailFiles EFiles = null;
                    String _correo_cus = String.Empty;
                    String _cons_tabrgm = Presenter.Item.CONS_TabRGM;
                    String _cons_codrgm = Presenter.Item.CONS_CodRGM;
                    String _cons_tabvia = Presenter.Item.CONS_TabVia;
                    String _cons_codvia = Presenter.Item.CONS_CodVia;
                    String _transportista = Presenter.Item.ENTC_NomTransp;
                    String _vobo1 = String.Empty;
                    String _vobo2 = String.Empty;
                    Nullable<DateTime> _fec_eta_etd = Presenter.Item.NVIA_FecETA_IMPO_ETD_EXPO;
                    switch (Presenter.Item.CONS_CodRGM)
                    {
                        case Delfin.Controls.variables.CONSRGM_Exportacion:
                            _vobo1 = Presenter.Item.ENTC_NomAgente;
                            _vobo2 = String.Empty;
                            _correo_cus = Presenter.PARA_CORREOCUSTOMER_EXPO.PARA_Valor;
                            break;
                        case Delfin.Controls.variables.CONSRGM_Importacion:
                            _vobo1 = Presenter.Item.ENTC_NomAgent1;
                            _vobo2 = Presenter.Item.ENTC_NomAgent2;
                            _correo_cus = Presenter.PARA_CORREOCUSTOMER_IMPO.PARA_Valor;
                            break;
                    }
                    String _nombre_nave = Presenter.Item.NAVE_Nombre;
                    String _numero_viaje = Presenter.Item.NVIA_NroViaje;
                    String _codigo_interno = Presenter.Item.NVIA_Codigo.ToString();
                    Nullable<DateTime> _fec_llegada_zarpe = Presenter.Item.NVIA_FecLlega_IMPO_Zarpe_EXPO;
                    Nullable<DateTime> _fec_recogo_docs = Presenter.Item.ENTC_FecRecogerDocs;
                    Nullable<DateTime> _fec_cierre_dir = Presenter.Item.NVIA_FecCierreDire_IMPO_TermEmba_EXPO;
                    //################################

                    EFiles = new Controls.EmailFiles();
                    String _mensaje = EFiles.Avisos(Presenter.DtAvisos, _cons_tabrgm, _cons_codrgm, _cons_tabvia, _cons_codvia, _transportista, _vobo1, _vobo2, _nombre_nave, _numero_viaje, _fec_eta_etd, _fec_llegada_zarpe, _fec_recogo_docs, _fec_cierre_dir, _correo_ope, _correo_log);
                    if (!String.IsNullOrEmpty(_mensaje))
                    {
                        if (_mensaje.Substring(0, 1) == "#")
                        { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Presenter.Title, "OCURRIO UN ERROR EN EL METODO DE AVISOS (Ver Detalles)", _mensaje); }
                        else
                        { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Presenter.Title, _mensaje); }
                    }
                    else
                    {
                        Presenter.GenerarEventosTareas("Se ha generado el correo Aviso de Llegada o Salida de la Orden de Venta desde Nave-Viaje", Presenter.PARA_CARTAAVISOS.PARA_Valor, Presenter.DtAvisos);
                    }
                }
                else
                {
                    Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Presenter.Title, "Verifique los siguientes Correos Electronicos (detalles)", _mensajeError);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error durante el proceso del Envío del Aviso de Llegada: " + ex.Message, "Error Interno", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #endregion

        #region [ Metodos Detalles ]
        public Boolean Edicion { get; set; }
        private Entities.DetNaveViaje ItemDetNaveViaje = null;
        public BindingSource BSItemsDetalles { get; set; }
        private void InstanceItemDetalle(Boolean ItemEnabled, Boolean EnabledGuardar)
        {
            try
            {
                TIPO_CodPAIDetalle.Enabled = ItemEnabled;
                PUER_CodigoDetalle.Enabled = ItemEnabled;
                DVIA_FecETA_EXPO_ETDMaster_IMPO.Enabled = ItemEnabled;


                btnNuevoDetalle.Enabled = !EnabledGuardar;
                btnEditarDetalle.Enabled = (!EnabledGuardar && ItemDetNaveViaje != null);
                btnEliminarDetalle.Enabled = (!EnabledGuardar && ItemDetNaveViaje != null);
                btnGuardarDetalle.Enabled = EnabledGuardar;
                btnDeshacerDetalle.Enabled = EnabledGuardar;
            }
            catch (Exception ex)
            {
                Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, Infrastructure.Aspect.Constants.Mensajes.SetInstanceView, ex);
            }
        }
        private void ClearItemDetalle(Boolean Pais)
        {
            try
            {
                if (Pais)
                {
                    TIPO_CodPAIDetalle.TiposSelectedValue = null;
                }
                PUER_CodigoDetalle.ComboIntSelectedValue = null;
                DVIA_FecETA_EXPO_ETDMaster_IMPO.NSFecha = null;
            }
            catch (Exception ex)
            {
                Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, Infrastructure.Aspect.Constants.Mensajes.ClearItem, ex);
            }
        }
        private void GetItemDetalle()
        {
            try
            {
                if (ItemDetNaveViaje != null)
                {
                    if (TIPO_CodPAIDetalle.TiposSelectedItem != null)
                    {
                        ItemDetNaveViaje.TIPO_TabPAI = TIPO_CodPAIDetalle.TiposSelectedItem.TIPO_CodTabla;
                        ItemDetNaveViaje.TIPO_CodPAI = TIPO_CodPAIDetalle.TiposSelectedItem.TIPO_CodTipo;
                        ItemDetNaveViaje.TIPO_DescPAI = TIPO_CodPAIDetalle.TiposSelectedItem.TIPO_Desc1;
                    }
                    else
                    {
                        ItemDetNaveViaje.TIPO_TabPAI = null;
                        ItemDetNaveViaje.TIPO_CodPAI = null;
                    }
                    if (PUER_CodigoDetalle.ComboIntSelectedValue.HasValue)
                    {
                        Entities.Puerto _puerto = Presenter.ListPuertos.Where(puer => puer.PUER_Codigo == PUER_CodigoDetalle.ComboIntSelectedValue.Value).FirstOrDefault();
                        if (_puerto != null)
                        {
                            ItemDetNaveViaje.PUER_Codigo = _puerto.PUER_Codigo;
                            ItemDetNaveViaje.PUER_Nombre = _puerto.PUER_Nombre;
                        }
                        else
                        {
                            ItemDetNaveViaje.PUER_Codigo = null;
                            ItemDetNaveViaje.PUER_Nombre = null;
                        }
                    }
                    else
                    {
                        ItemDetNaveViaje.PUER_Codigo = null;
                        ItemDetNaveViaje.PUER_Nombre = null;
                    }

                    ItemDetNaveViaje.DVIA_FecETA_EXPO_ETDMaster_IMPO = DVIA_FecETA_EXPO_ETDMaster_IMPO.NSFecha;
                }
            }
            catch (Exception ex)
            {
                Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, Infrastructure.Aspect.Constants.Mensajes.GetItem, ex);
            }
        }
        private void SetItemDetalle()
        {
            try
            {
                if (ItemDetNaveViaje != null)
                {
                    TIPO_CodPAIDetalle.TiposSelectedValue = ItemDetNaveViaje.TIPO_CodPAI;
                    PUER_CodigoDetalle.ComboIntSelectedValue = ItemDetNaveViaje.PUER_Codigo;
                    DVIA_FecETA_EXPO_ETDMaster_IMPO.NSFecha = ItemDetNaveViaje.DVIA_FecETA_EXPO_ETDMaster_IMPO;
                }
            }
            catch (Exception ex)
            {
                Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, Infrastructure.Aspect.Constants.Mensajes.SetItem, ex);
            }
        }
        private void MostrarErrorItemDetalle()
        {
            try
            {
                Infrastructure.Client.FormClose.FormShowErrorProvider<Entities.DetNaveViaje>.Validate(ItemDetNaveViaje, tableDetalle, errorProvider2);
            }
            catch (Exception ex)
            {
                Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error en ShowValidation.", ex);
            }
        }
        private void BSItemsDetalles_CurrentItemChanged(object sender, EventArgs e)
        {
            try
            {
                if (BSItemsDetalles.Current != null && BSItemsDetalles.Current is Entities.DetNaveViaje)
                {
                    ItemDetNaveViaje = ((Entities.DetNaveViaje)BSItemsDetalles.Current);
                }
                else
                {
                    ItemDetNaveViaje = null;
                }
            }
            catch (Exception ex)
            {
                Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, Infrastructure.Aspect.Constants.Mensajes.CurrentItemChanged, ex);
            }
        }
        private void btnNuevoDetalle_Click(object sender, EventArgs e)
        {
            try
            {
                ClearItemDetalle(false);
                ItemDetNaveViaje = new Entities.DetNaveViaje();
                ItemDetNaveViaje.AUDI_UsrCrea = Presenter.Session.UserName;
                ItemDetNaveViaje.AUDI_FecCrea = Presenter.Session.Fecha;
                ItemDetNaveViaje.Instance = Infrastructure.Aspect.BusinessEntity.InstanceEntity.Added;
                //SetItemDetalle();
                InstanceItemDetalle(true, true);
                Edicion = false;
            }
            catch (Exception ex)
            {
                Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, Infrastructure.Aspect.Constants.Mensajes.NewPresenter, ex);
            }
        }
        private void btnEditarDetalle_Click(object sender, EventArgs e)
        {
            try
            {
                if (ItemDetNaveViaje != null)
                {
                    ClearItemDetalle(true);
                    ItemDetNaveViaje.AUDI_UsrMod = Presenter.Session.UserName;
                    ItemDetNaveViaje.AUDI_FecMod = Presenter.Session.Fecha;
                    if (ItemDetNaveViaje.Instance != Infrastructure.Aspect.BusinessEntity.InstanceEntity.Added)
                    {
                        ItemDetNaveViaje.Instance = Infrastructure.Aspect.BusinessEntity.InstanceEntity.Modified;
                    }
                    SetItemDetalle();
                    InstanceItemDetalle(true, true);
                    Edicion = true;
                }
                else
                {
                    Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Presenter.Title, "Debe seleccionar un elemento de la grilla");
                }
            }
            catch (Exception ex)
            {
                Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, Infrastructure.Aspect.Constants.Mensajes.EditPresenter, ex);
            }
        }
        private void btnEliminarDetalle_Click(object sender, EventArgs e)
        {
            try
            {
                if (ItemDetNaveViaje != null)
                {
                    System.Windows.Forms.DialogResult _result = Infrastructure.WinForms.Controls.Dialogos.MostrarMensajePregunta(Presenter.Title, Infrastructure.Aspect.Constants.Mensajes.PreguntaEliminar, Infrastructure.WinForms.Controls.Dialogos.LabelBoton.Si_No);
                    if (_result == System.Windows.Forms.DialogResult.Yes)
                    {
                        if (ItemDetNaveViaje.Instance != Infrastructure.Aspect.BusinessEntity.InstanceEntity.Added)
                        {
                            ItemDetNaveViaje.AUDI_UsrMod = Presenter.Session.UserName;
                            ItemDetNaveViaje.AUDI_FecMod = Presenter.Session.Fecha;
                            ItemDetNaveViaje.Instance = Infrastructure.Aspect.BusinessEntity.InstanceEntity.Deleted;
                            Presenter.Item.ItemsDeletedDetNaveViaje.Add(ItemDetNaveViaje);
                        }
                        BSItemsDetalles.RemoveCurrent();
                        BSItemsDetalles.ResetBindings(true);
                        Edicion = false;
                    }
                }
                else
                {
                    Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Presenter.Title, "Debe seleccionar un elemento de la grilla");
                }
            }
            catch (Exception ex)
            {
                Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, Infrastructure.Aspect.Constants.Mensajes.DeletePresenter, ex);
            }
        }
        private void btnGuardarDetalle_Click(object sender, EventArgs e)
        {
            try
            {
                if (ItemDetNaveViaje != null)
                {
                    GetItemDetalle();
                    if (ItemDetNaveViaje.Validar())
                    {
                        if (!Edicion)
                        {
                            BSItemsDetalles.Add(ItemDetNaveViaje);
                        }
                        else
                        {
                            BSItemsDetalles[BSItemsDetalles.Position] = ItemDetNaveViaje;
                        }

                        BSItemsDetalles.ResetBindings(true);
                        ItemDetNaveViaje = null;
                        ClearItemDetalle(false);
                        if (BSItemsDetalles.Current != null && BSItemsDetalles.Current is Entities.DetNaveViaje)
                        {
                            ItemDetNaveViaje = ((Entities.DetNaveViaje)BSItemsDetalles.Current);
                        }
                        else
                        {
                            ItemDetNaveViaje = null;
                        }
                        InstanceItemDetalle(false, false);
                        Edicion = false;
                    }
                    else
                    {
                        MostrarErrorItemDetalle();
                    }
                }
            }
            catch (Exception ex)
            {
                Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, Infrastructure.Aspect.Constants.Mensajes.SavePresenter, ex);
            }
        }
        private void btnDeshacerDetalle_Click(object sender, EventArgs e)
        {
            try
            {
                ClearItemDetalle(true);
                InstanceItemDetalle(false, false);
                BSItemsDetalles.MoveFirst();
                Edicion = false;
            }
            catch (Exception)
            {
            }
        }
        #endregion

        #region [ Statment ]
        /// <summary>
        /// CRISTHIAN JOSE APAZA
        /// BOTON CERRAR NAVE
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCerrarNave_Click(object sender, EventArgs e)
        {
            try
            {
                cmbNVIA_Estado.ConstantesSelectedValue = NVIA_Estado.Cerrado;

                NVIA_UsrCierreNave.Text = Presenter.Item.AUDI_UsrMod;
                NVIA_FecCierreNave.NSFecha = Presenter.Item.AUDI_FecMod;
                Int32 _nvia_codigo = Presenter.Item.NVIA_Codigo;
                if (Presenter.Guardar())
                {
                    //########## EVENTOS #############
                    DT_OV = new DataTable();
                    DT_OV = Presenter.BuscarOv(_nvia_codigo, _TIPO_Condicion.CierreNave);
                    Presenter.GenerarEventosTareas("Se ha generado el Cierre Operativo de la Orden de Venta desde Nave-Viaje", Presenter.PARA_OVCERRADA.PARA_Valor, DT_OV);
                    //################################

                    Presenter.ScreenRefresh(_nvia_codigo);
                }
            }
            catch (Exception ex)
            {
                Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al Cerrar La Nave.", ex);
            }
        }
        private void btnEmiti_Statment_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable _DTOV = new DataTable();
                String _rutaStatment = Presenter.EmitirStatment(chkChangeControl.Checked, ref _DTOV);

                if ((!String.IsNullOrEmpty(_rutaStatment)) && (File.Exists((string)_rutaStatment)))
                {
                    Presenter.GenerarEventosTareas("Se ha emitido el Statement de la Orden de Venta desde Nave-Viaje", Presenter.PARA_EMITIRSTATEMENT.PARA_Valor, _DTOV);

                    Boolean enviar = false;
                    String recipient = @"<INGRESE UN CORREO>";
                    String olCCrecipient = Presenter.PARA_CORREOOPERACIONES.PARA_Valor;
                    String subject = @"STATEMENT" + " // " + Convert.ToString(Presenter.Item.NVIA_Codigo) + " - " + Presenter.Item.CONS_DescRGM + " - " + Presenter.Item.CONS_DescVIA + " - MN: " + Presenter.Item.NAVE_Nombre + " . " + Presenter.Item.NVIA_NroViaje;
                    StringBuilder _body = new StringBuilder();
                    _body.Append("<html>");
                    _body.Append("<font color= #2f5496 >");
                    _body.Append("<body>");
                    _body.Append("<h4>Estimadas: </h4>");
                    _body.Append("<p><b>Adjunto stat de MN en referencia.</b></p>");
                    _body.Append("</body>");
                    _body.Append("</font>");
                    _body.Append("</html>");
                    String body = _body.ToString();
                    Delfin.Controls.EnviarCorreo ecStatment = new Controls.EnviarCorreo();
                    ecStatment.enviaCorreo(enviar, recipient, olCCrecipient, subject, body, _rutaStatment, "");

                    Presenter.ScreenRefresh(Presenter.Item.NVIA_Codigo);
                }
                else
                { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Presenter.Title, "No se ha generado ningun documento"); }
            }
            catch (Exception ex)
            { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha Ocurrido un error al emitir el Statment", ex); }
        }
        private void btnAprobarStatment_Click(object sender, EventArgs e)
        {
            try
            {
                if (Infrastructure.WinForms.Controls.Dialogos.MostrarMensajePregunta(Presenter.Title, "¿Esta seguro que desea Aprobar Statment?", Infrastructure.WinForms.Controls.Dialogos.LabelBoton.Si_No) == System.Windows.Forms.DialogResult.Yes)
                {
                    string _mensajeError = string.Empty;
                    string _correo_ope = Presenter.PARA_CORREOOPERACIONES == null ? null : Presenter.PARA_CORREOOPERACIONES.PARA_Valor;
                    string _correo_log = Presenter.PARA_CORREOLOGISTICA == null ? null : Presenter.PARA_CORREOLOGISTICA.PARA_Valor;
                    string _correo_fin = Presenter.PARA_CORREOFINANZAS == null ? null : Presenter.PARA_CORREOFINANZAS.PARA_Valor;
                    string _correo_fle = Presenter.PARA_CORREOFLETAMENTO == null ? null : Presenter.PARA_CORREOFLETAMENTO.PARA_Valor;
                    Delfin.Controls.Utils.checkMail("Operaciones", _correo_ope, ref _mensajeError);
                    Delfin.Controls.Utils.checkMail("Logística", _correo_log, ref _mensajeError);
                    Delfin.Controls.Utils.checkMail("Finanzas", _correo_fin, ref _mensajeError);
                    Delfin.Controls.Utils.checkMail("Fletamento", _correo_fle, ref _mensajeError);
                    if (string.IsNullOrEmpty(_mensajeError))
                    {
                        if (Presenter.PreFacturar())
                        {
                            NVIA_UsrPreFactura.Text = Presenter.Item.AUDI_UsrMod;
                            NVIA_FecPreFactura.NSFecha = Presenter.Item.AUDI_FecMod;
                            //########## PARAMETROS ##########
                            Delfin.Controls.EmailFiles EFiles = null;
                            string _correo_cus = String.Empty;
                            string _cons_tabrgm = Presenter.Item.CONS_TabRGM;
                            string _cons_codrgm = Presenter.Item.CONS_CodRGM;
                            string _cons_tabvia = Presenter.Item.CONS_TabVia;
                            string _cons_codvia = Presenter.Item.CONS_CodVia;
                            string _transportista = Presenter.Item.ENTC_NomTransp;
                            string _vobo1 = String.Empty;
                            string _vobo2 = String.Empty;
                            Nullable<DateTime> _fec_eta_etd = Presenter.Item.NVIA_FecETA_IMPO_ETD_EXPO;
                            switch (Presenter.Item.CONS_CodRGM)
                            {
                                case Delfin.Controls.variables.CONSRGM_Exportacion:
                                    _vobo1 = Presenter.Item.ENTC_NomAgente;
                                    _vobo2 = String.Empty;
                                    _correo_cus = Presenter.PARA_CORREOCUSTOMER_EXPO.PARA_Valor;
                                    break;
                                case Delfin.Controls.variables.CONSRGM_Importacion:
                                    _vobo1 = Presenter.Item.ENTC_NomAgent1;
                                    _vobo2 = Presenter.Item.ENTC_NomAgent2;
                                    _correo_cus = Presenter.PARA_CORREOCUSTOMER_IMPO.PARA_Valor;
                                    break;
                            }
                            string _nombre_nave = Presenter.Item.NAVE_Nombre;
                            string _numero_viaje = Presenter.Item.NVIA_NroViaje;
                            string _codigo_interno = Presenter.Item.NVIA_Codigo.ToString();
                            Nullable<DateTime> _fec_llegada_zarpe = Presenter.Item.NVIA_FecLlega_IMPO_Zarpe_EXPO;
                            Nullable<DateTime> _fec_recogo_docs = Presenter.Item.ENTC_FecRecogerDocs;
                            Nullable<DateTime> _fec_cierre_dir = Presenter.Item.NVIA_FecCierreDire_IMPO_TermEmba_EXPO;
                            //################################

                            #region [ Correo-Finanzas ]
                            EFiles = new Controls.EmailFiles();
                            EFiles.CorreoFinanzasStatment(_correo_fin, _correo_ope, _correo_fle, _correo_cus, _codigo_interno, _nombre_nave, _numero_viaje, _cons_codrgm, _fec_eta_etd, _transportista);
                            #endregion

                            Presenter.ScreenRefresh(Presenter.Item.NVIA_Codigo);
                        }
                    }
                    else
                    {
                        Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Presenter.Title, "Verifique los siguientes Correos Electronicos (detalles)", _mensajeError);
                    }
                }
            }
            catch (Exception ex)
            { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha Ocurrido un error al aprobar el Statement", ex); }

        }
        private void btnAbrirStatment_Click(object sender, EventArgs e)
        {
            try
            {
                if (Infrastructure.WinForms.Controls.Dialogos.MostrarMensajePregunta(Presenter.Title, "¿Esta seguro que desea Abrir Statment?", Infrastructure.WinForms.Controls.Dialogos.LabelBoton.Si_No) == System.Windows.Forms.DialogResult.Yes)
                {
                    if (Presenter.AbrirStatment())
                    {
                        //########## EVENTOS ###########
                        DT_OV = new DataTable();
                        DT_OV = Presenter.BuscarOv(Presenter.Item.NVIA_Codigo, _TIPO_Condicion.AbrirStatment);
                        Presenter.GenerarEventosTareas("Se ha generado la Apertura del Statement de la Orden de Venta desde Nave-Viaje", Presenter.PARA_APERTURASTATMENT.PARA_Valor, DT_OV);
                        //##############################

                        Presenter.ScreenRefresh(Presenter.Item.NVIA_Codigo);
                    }
                }
            }
            catch (Exception ex)
            { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha Ocurrido un error al abrir el Statement", ex); }
        }
        private void btnPreFacturar_Click(object sender, EventArgs e)
        {
            Presenter.PreFacturar();
        }
        private void btnEmitir_BL_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    if (Presenter.DtEmisionHBL != null)
            //    {
            //        Delfin.Controls.EnviarCorreo ec = new Controls.EnviarCorreo();
            //        string archivo = @"Plantillas\\RECOGO_DE_BL.docx";
            //        string attachments = Path.Combine(Application.StartupPath, archivo);
            //        Boolean enviar = false;

            //        foreach (DataRow drEmisionHBL in Presenter.DtEmisionHBL.Rows)
            //        {
            //            string recipient = Convert.ToString(drEmisionHBL["ENTC_EMailCli"]); if (String.IsNullOrEmpty(recipient)) { recipient = "<INGRESE_EMAIL_CLIENTE>"; }
            //            string olCCrecipient = Presenter.PARA_CORREOOPERACIONES.PARA_Valor + ";" + Convert.ToString(drEmisionHBL["ENTC_EMailCus"]) + ";" + Convert.ToString(drEmisionHBL["ENTC_EMailEje"]);
            //            string subject = "EMISION DE HBL:" + Presenter.Item.NAVE_Nombre + " - Viaje:" + Presenter.Item.NVIA_NroViaje + " - " + Convert.ToString(drEmisionHBL["DOOV_HBL"]) + "-" + Convert.ToString(drEmisionHBL["DOOV_CodReferencia"]) + "-" + Convert.ToString(drEmisionHBL["ENTC_NomCliente"]);
            //            StringBuilder _body = new StringBuilder();
            //            _body.Append("<html>");
            //            _body.Append("<font color= #2f5496 >");
            //            _body.Append("<body>");
            //            _body.Append("<h4>Estimados Clientes: </h4>");
            //            _body.Append("<h4>" + Convert.ToString(drEmisionHBL["ENTC_NomCliente"]) + "</h4>");
            //            _body.Append("<p> Para informarle que hemos recibido instrucción de nuestros agentes para emitir el HBl en destino, por lo que pueden pasar a recogerlo en nuestras oficinas en Callao con su carta de recojo adjunta indicando los datos de la persona que recogerá el documento, asimismo pueden comunicarse con el área de visto bueno al teléfono 6153535  anex 301 para que puedan ayudarlo con el procedimiento de visto bueno. </p>");
            //            _body.Append("</body>");
            //            _body.Append("</font>");
            //            _body.Append("</html>");
            //            string body = _body.ToString();
            //            ec.enviaCorreo(enviar, recipient, olCCrecipient, subject, body, attachments, "");
            //        }
            //    }
            //    else
            //    {
            //        Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Presenter.Title, "No se encontraron Ordenes de Venta con Emision de HBL relacionadas a esta Nave-Viaje");
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("Error durante el proceso del Envío del Correo: " + ex.Message, "Error Interno", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        }
        #endregion

        #region [ Auditoria ]
        private void btnAuditoriaNaveViaje_Click(object sender, EventArgs e)
        {
            try
            {
                ObservableCollection<Infrastructure.Aspect.DataAccess.DataAccessFilterSQL> _filters = new ObservableCollection<Infrastructure.Aspect.DataAccess.DataAccessFilterSQL>();
                _filters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@pintNVIA_Codigo", FilterValue = Presenter.Item.NVIA_Codigo, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.Int32, FilterSize = 4 });

                Delfin.Controls.AuditoriaView _auditoriaView = new Controls.AuditoriaView(Presenter.ContainerService, Delfin.Controls.TipoAuditoria.AUDI_COM_NaveViaje, _filters);
                _auditoriaView.Show();
            }
            catch (Exception)
            { }
        }
        private void btnAuditoriaDetNaveViaje_Click(object sender, EventArgs e)
        {
            try
            {
                ObservableCollection<Infrastructure.Aspect.DataAccess.DataAccessFilterSQL> _filters = new ObservableCollection<Infrastructure.Aspect.DataAccess.DataAccessFilterSQL>();
                _filters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@pintNVIA_Codigo", FilterValue = Presenter.Item.NVIA_Codigo, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.Int32, FilterSize = 4 });

                Delfin.Controls.AuditoriaView _auditoriaView = new Controls.AuditoriaView(Presenter.ContainerService, Delfin.Controls.TipoAuditoria.AUDI_COM_DetNaveViaje, _filters);
                _auditoriaView.Show();
            }
            catch (Exception)
            { }
        }
        #endregion


        public void DisableFromOV()
        {
            try
            {
                ENTC_CodTransportista.Enabled = false;
                CONS_CodVIA.Enabled = false;
                CONS_CodRGM.Enabled = false;
                ayudaPUER_Codigo.Enabled = false;
            }
            catch (Exception)
            { }
        }
    }
}