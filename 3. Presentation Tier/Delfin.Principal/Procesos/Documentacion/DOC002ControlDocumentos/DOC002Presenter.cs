using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Practices.Unity;
using Delfin.ServiceContracts;
using Delfin.ServiceProxy;
using Delfin.Entities;
using Infrastructure.Aspect;
using Infrastructure.Aspect.Collections;
using Infrastructure.Client.Services.Session;
using System.Collections.ObjectModel;
using System.IO;

using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Net;
using System.Runtime.Serialization.Json;

//using Infrastructure.WinFormsControls;

namespace Delfin.Principal
{
    public partial class DOC002Presenter
    {
        #region [ Variables ]
        public String Title = "Control de Documentos";
        public String CUS = "DOC002";
        public Boolean FleteNegativo = false;
        #endregion

        #region [ Contrusctor ]
        public DOC002Presenter(IUnityContainer x_container, IDOC002LView x_lview, IDOC002MView x_mview)
        {
            try
            {
                this.ContainerService = x_container;
                Session = this.ContainerService.Resolve<ISessionService>();
                this.LView = x_lview;
                this.MView = x_mview;
            }
            catch (Exception)
            { throw; }
        }
        public void Load()
        {
            try
            {
                Client = ContainerService.Resolve<IDelfinServices>();
                ItemsParametrosCorreo = Client.GetAllParametrosByClave("CORREO%");

                //Infrastructure.WinForms.Controls.ComboBox.ComboxBoxItem.AddComboBoxItem("I", "Ingreso", true);
                //Infrastructure.WinForms.Controls.ComboBox.ComboxBoxItem.AddComboBoxItem("E", "Egreso");
                //ListIngresoEgreso = Infrastructure.WinForms.Controls.ComboBox.ComboxBoxItem.GetComboBoxItems();
                LView.LoadView();
                MView.LoadView();
                LoadParameteres();

                ListConstantesMOD = Client.GetAllConstantesByConstanteTabla("MOD");

            }
            catch (Exception ex)
            { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Title, "Ha ocurrido un error inicializando la vista.", ex); }
        }
        #endregion

        #region [ Propiedades ]
        public IUnityContainer ContainerService { get; set; }
        public ISessionService Session { get; set; }
        public IDelfinServices Client { get; set; }
        public ObservableCollection<Entities.Parametros> ItemsParametrosCorreo { get; set; }
        public IDOC002LView LView { get; set; }
        public IDOC002MView MView { get; set; }
        public DOC002DView DView { get; set; }
        public Cab_Cotizacion_OV Item { get; set; }
        public ObservableCollection<Cab_Cotizacion_OV> Items { get; set; }
        public DataTable _ControlDocumentos = new DataTable();
        public DataTable _ControlDocumentosCopia = new DataTable();
        public DataTable _DtOVSinLOAD = new DataTable();
        public LoadingList _Item { get; set; }
        public DataTable files = new DataTable();
        public Constantes FILTROItemVia { get; set; }
        public Constantes FILTROItemRegimen { get; set; }
        public Entidad FILTROItemTransportista { get; set; }
        public Nullable<Int32> FILTROItemPuerto { get; set; }
        public String FILTROItemMBL { get; set; }
        public String FILTROItemHBL { get; set; }
        public String FILTROItemOV { get; set; }
        public Nullable<DateTime> FILTROItemFecPrimerOKIni { get; set; }
        public Nullable<DateTime> FILTROItemFecPrimerOKFin { get; set; }
        public Boolean FILTROItemConPreAlerta { get; set; }
        public Boolean FILTROItemSinPreAlerta { get; set; }
        //#### VARIABLES #######
        public Nullable<Boolean> _con_prealerta { get; set; }
        public Nullable<Int32> _load_codigo { get; set; }
        public Nullable<Int32> _ccot_codigo { get; set; }
        public Nullable<Int16> _ccot_tipo { get; set; } 
        public String _ccot_estado { get; set; }
        //######################

        //##### EVENTOS #####
        public ObservableCollection<Constantes> ListConstantesMOD { get; set; }
        public ObservableCollection<Det_Cotizacion_OV_EventosTareas> ItemsEventosTareas { get; set; }
        public Det_Cotizacion_OV_EventosTareas ItemEventoTarea { get; set; }
        //###################
        #endregion

        #region [ Parámetros ]
        //####### EVENTOS #######
        public Entities.Parametros PARA_PREALERTA { get; set; }
        public Entities.Parametros PARA_OVENTREGADA { get; set; }
        //#######################
        private void LoadParameteres()
        {
            try
            {
                var ItemsPARAMETRO = Client.GetAllParametros();
                //####### EVENTOS #######
                PARA_PREALERTA = ItemsPARAMETRO.FirstOrDefault(para => para.PARA_Clave == "PRE_ALERTA");
                PARA_OVENTREGADA = ItemsPARAMETRO.FirstOrDefault(para => para.PARA_Clave == "OV_ENTREGADA");
                //#######################
            }
            catch (Exception)
            { }
        }
        #endregion

        #region [ Metodos ]
        public void Actualizar(Boolean x_showMessage = true)
        {
            try
            {
                Item = null;
                Items = null;

                _ControlDocumentos = new DataTable();

                String CONS_TabVia = null;
                String CONS_CodVia = null;
                String CONS_TabRGM = null;
                String CONS_CodRGM = null;
                Nullable<Int32> ENTC_CodTransportista = null;
                Nullable<Int32> PUER_CodOrigen = null;
                String LOAD_HBL = null;
                String LOAD_MBL = null;
                String CCOT_NumDoc = null;
                Nullable<DateTime> LOAD_FecPrimerOkIni = null;
                Nullable<DateTime> LOAD_FecPrimerOkFin = null;

                Boolean LOAD_SegundoOk = false; if (FILTROItemConPreAlerta != null) { LOAD_SegundoOk = FILTROItemConPreAlerta; }

                if (LView != null)
                {
                    if (FILTROItemTransportista != null)
                    { ENTC_CodTransportista = FILTROItemTransportista.ENTC_Codigo; }
                    if (FILTROItemRegimen != null)
                    {
                        CONS_TabRGM = FILTROItemRegimen.CONS_CodTabla;
                        CONS_CodRGM = FILTROItemRegimen.CONS_CodTipo;
                    }
                    if (FILTROItemVia != null)
                    {
                        CONS_TabVia = FILTROItemVia.CONS_CodTabla;
                        CONS_CodVia = FILTROItemVia.CONS_CodTipo;
                    }
                    if (FILTROItemPuerto != null)
                    { PUER_CodOrigen = FILTROItemPuerto; }
                    if (FILTROItemHBL != null)
                    { LOAD_HBL = FILTROItemHBL; }
                    if (FILTROItemMBL != null)
                    { LOAD_MBL = FILTROItemMBL; }
                    if (FILTROItemOV != null)
                    { CCOT_NumDoc = FILTROItemOV; }
                    if (FILTROItemFecPrimerOKIni != null)
                    { LOAD_FecPrimerOkIni = FILTROItemFecPrimerOKIni.Value; }
                    if (FILTROItemFecPrimerOKFin != null)
                    { LOAD_FecPrimerOkFin = FILTROItemFecPrimerOKFin.Value; }


                    _ControlDocumentos = Client.GetAllCab_OV_CabLOADByFiltro(LOAD_SegundoOk, CONS_TabRGM, CONS_CodRGM, CONS_TabVia, CONS_CodVia, ENTC_CodTransportista, PUER_CodOrigen, LOAD_HBL, LOAD_MBL, CCOT_NumDoc, LOAD_FecPrimerOkIni, LOAD_FecPrimerOkFin);
                    LView.ShowItems(_ControlDocumentos, LOAD_SegundoOk);

                    if (_ControlDocumentos == null)
                    {
                       if (x_showMessage) { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Title, "No se encontraron coincidencias "); }
                    }
                    else
                    {
                        _ControlDocumentosCopia = _ControlDocumentos.Copy();
                    }
                    //String CONS_TabRGM = null; if (FILTROItemCONSRGM != null) { CONS_TabRGM = FILTROItemCONSRGM.CONS_CodTabla; }
                    //String CONS_CodRGM = null; if (FILTROItemCONSRGM != null) { CONS_CodRGM = FILTROItemCONSRGM.CONS_CodTipo; }
                    //String CONS_TabFLE = null; if (FILTROItemCONSFLE != null) { CONS_TabFLE = FILTROItemCONSFLE.CONS_CodTabla; }

                    //Items = Client.GetAllCab_Cotizacion_OVByFiltro(Delfin.Controls.Entorno.ItemEmpresa.EMPR_Codigo, Delfin.Controls.Entorno.ItemSucursal.SUCR_Codigo, CCOT_Tipo, CONS_TabRGM, CONS_CodRGM, CONS_TabFLE, CONS_CodFLE, CONS_TabVia, CONS_CodVia, CONS_TabEST, CONS_CodEST, ENTC_CodEjecutivo, ENTC_CodCustomer, ENTC_CodAgente, ENTC_CodBroker, ENTC_CodCliente, CCOT_FecEmiDesde, CCOT_FecEmiHasta, CCOT_NumDoc, DOOV_HBL);


                    


                }
            }
            catch (Exception ex)
            { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Title, "Ha ocurrido un error actualizando.", ex); }
        }
        public void ActualizarOVs(string CONS_TabRGM, string CONS_CodRGM)
        {
            try
            {
                _DtOVSinLOAD = new DataTable();
                _DtOVSinLOAD = Client.GetAllOVSinLOAD(CONS_TabRGM, CONS_CodRGM);
                LView.ShowItemsOV(_DtOVSinLOAD);
            }
            catch (Exception ex)
            { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Title, "Ha ocurrido un error actualizando.", ex); }
        }
        Boolean isMViewShow = false;
        public void Nuevo()
        {
            try
            {
                MView.ClearItem();
                this._Item = new LoadingList();
                this._Item.LOAD_SegundoOK = false;
                this._Item.LOAD_CargaUsuario = Session.UserName;

                this._Item.Instance = Infrastructure.Aspect.BusinessEntity.InstanceEntity.Added;
                MView.ShowCampos(true);
                MView.SetItem();

                isMViewShow = true;
                ((DOC002MView)MView).ShowDialog();

            }
            catch (Exception ex)
            { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Title, Infrastructure.Aspect.Constants.Mensajes.NewPresenter, ex); }
        }
        public void Editar()
        {
            try
            {
                //if (!isMViewShow)
                //{
                //    MView = new DOC002MView();
                //    MView.Presenter = this;
                //    MView.LoadView();
                //}
                Boolean _Estado = false;
                switch (_ccot_estado)
                {
                    case "004":
                    case "006":
                    case "007":
                        _Estado = true;
                        break;
                    default:
                        _Estado = false;
                        break;
                }
                if (_load_codigo != null)
                {
                    if ((_con_prealerta == true && _ccot_codigo != null && _Estado) || (_con_prealerta != true))
                    {
                        _Item = Client.GetALoadingListByLoad_Codigo(_load_codigo);
                        MView.ClearItem();
                        //this._Item.AUDI_UsrMod = Session.UserName;
                        //this._Item.AUDI_FecMod = Session.Fecha;
                        this._Item.Instance = Infrastructure.Aspect.BusinessEntity.InstanceEntity.Modified;
                        if (_Item.LOAD_FecDevolucion == null && _con_prealerta == true)
                        { _Item.LOAD_FecDevolucion = DateTime.Now; }
                        MView.ShowCampos(true);
                        MView.SetItem();
                        isMViewShow = true;

                        ((DOC002MView)MView).ShowDialog();
                    }
                    else
                    { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Title, "El registro no cuenta con una Orden de Venta en estado Concluida en Adelante"); }

                }
                else
                { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Title, "Debe seleccionar un elemento de la grilla"); }
            }
            catch (Exception ex)
            { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Title, Infrastructure.Aspect.Constants.Mensajes.EditPresenter, ex); }
        }
        public Boolean ActualizarPreAlerta(DataTable _data)
        {
            try
            {
                return Client.SavePreAlerta(_data);
            }
            catch (Exception ex)
            {/* Infrastructure.WinFormsControls.Dialogos.MostrarMensajeError(Title, Infrastructure.Aspect.Constants.Mensajes.LoadPresenter, ex); */}
            return false;
        }
        public void EnviarCorreo(ObservableCollection<Entities.LoadingList> _items)
        {
            try
            {
                foreach (Entities.LoadingList item in _items)
                {
                    Client.UpdateLoadingListCorreo(Convert.ToInt32(item.LOAD_Codigo), Convert.ToBoolean(item.LOAD_EnvioCorreo), item.LOAD_EnvioCorreoUsuario);
                }

            }
            catch (Exception ex)
            { }
        }
        public void Eliminar()
        {
            try
            {
                if (_con_prealerta != true)
                {
                    if (_load_codigo != null)
                    {
                        try
                        {
                            System.Windows.Forms.DialogResult _result = Infrastructure.WinForms.Controls.Dialogos.MostrarMensajePregunta(Title, Infrastructure.Aspect.Constants.Mensajes.PreguntaEliminar, Infrastructure.WinForms.Controls.Dialogos.LabelBoton.Si_No);
                            if (_result == System.Windows.Forms.DialogResult.Yes)
                            {
                                _Item = new LoadingList();
                                _Item.Instance = Infrastructure.Aspect.BusinessEntity.InstanceEntity.Deleted;
                                _Item.LOAD_Codigo = _load_codigo;
                                if (Client.SaveLoadingListControlDoc(_Item))
                                {
                                    Actualizar();
                                    Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeSatisfactorio(Title, "Se ha eliminado el item.");
                                }
                                else
                                { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Title, "Ha ocurrido un error al guardar el item."); }
                            }
                        }

                        catch (Exception ex)
                        {
                            string errorMsg = Delfin.Controls.Utils.getErrorMsg(ex);
                            Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Title, errorMsg, ex);
                        }
                    }
                    else
                    { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Title, "Debe seleccionar un elemento de la grilla"); }
                }
                else
                { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Title, "No puede eliminar un registro que ya tiene Pre-Alerta"); }
            }
            catch (Exception ex)
            { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Title, Infrastructure.Aspect.Constants.Mensajes.DeletePresenter, ex); }
        }
        public bool Guardar()
        {
            try
            {
                MView.GetItem();

                if (Client.SaveLoadingListControlDoc(_Item))
                {
                    if (_con_prealerta == true && _ccot_codigo != null && _ccot_tipo != null)
                    {
                        if (PARA_OVENTREGADA != null)
                        {
                            if (!string.IsNullOrEmpty(PARA_OVENTREGADA.PARA_Valor))
                            { GenerarEventosTareas("OV Entregada", PARA_OVENTREGADA.PARA_Valor, Convert.ToInt32(_ccot_codigo), Convert.ToInt16(_ccot_tipo)); }
                            else
                            {
                                Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Title, "No existe parametro de configuracion OV_ENTREGADA, valide sus parametros del sistema");
                            }
                        }
                        else
                        {
                            Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Title, "No existe parametro de configuracion OV_ENTREGADA, valide sus parametros del sistema");
                        }
                    }
                    Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeSatisfactorio(Title, "Se ha guardado satisfactoriamente");

                    Actualizar();
                    return true;

                }
                else
                {
                    Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Title, "Ha ocurrido un error al guardar el item.");
                    return false;
                }

            }

            catch (Exception ex)
            {
                string errorMsg = Delfin.Controls.Utils.getErrorMsg(ex);
                Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Title, errorMsg, ex);
                //Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Title, Infrastructure.Aspect.Constants.Mensajes.SavePresenter, ex);
                return false;
            }
        }
        public System.Windows.Forms.DialogResult GuardarCambios()
        {
            try
            {
                if (this._Item != null)
                {

                    System.Windows.Forms.DialogResult _result = Infrastructure.WinForms.Controls.Dialogos.MostrarMensajePregunta(Title, Infrastructure.Aspect.Constants.Mensajes.SaveChangesPreguntaPresenter, Infrastructure.WinForms.Controls.Dialogos.LabelBoton.Si_No);
                    if (_result == System.Windows.Forms.DialogResult.Yes)
                    {
                        if (Guardar())
                        { return System.Windows.Forms.DialogResult.Yes; }
                        else
                        { return System.Windows.Forms.DialogResult.Cancel; }
                    }
                    else
                    { return _result; }
                }
                else
                {
                    Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Title, "Ha ocurrido un error al cerrar el formulario.");
                    return System.Windows.Forms.DialogResult.Cancel;
                }
            }
            catch (Exception ex)
            {
                Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Title, Infrastructure.Aspect.Constants.Mensajes.SavePresenter, ex);
                return System.Windows.Forms.DialogResult.Cancel;
            }
        }
        public void CloseView()
        {
            if (isMViewShow)
            { ((DOC002MView)MView).Close(); }
        }
        public void IsClosedMView()
        { isMViewShow = false; }
        public Boolean VerificarPemisoEdicion()
        {
            try
            {
                var BL_PermisosUsuarioProcesos = ContainerService.Resolve<NextAdmin.BusinessLogic.IBLPermisosUsuarioProcesos>();
                NextAdmin.BusinessLogic.PermisosUsuarioProcesos _itemPermisosUsuarioProcesos = BL_PermisosUsuarioProcesos.GetOneByUsuario(Session.AplicacionCodigo.Value, Session.UserCodigo, Delfin.Controls.variables.CCOT_EDITARCOTIZ);
                if (_itemPermisosUsuarioProcesos != null && _itemPermisosUsuarioProcesos.PUPR_Codigo > 0)
                { return true; }
                else
                { return false; }
            }
            catch (Exception)
            { return false; }
        }
        public void ShowsDocuments()
        {
            try
            {

                if (_load_codigo != null)
                {
                    files = new DataTable();
                    ObservableCollection<Infrastructure.Aspect.DataAccess.DataAccessFilterSQL> _listFilters = new ObservableCollection<Infrastructure.Aspect.DataAccess.DataAccessFilterSQL>();
                    _listFilters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@pintLOAD_Codigo", FilterValue = _load_codigo, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.Int32, FilterSize = 4 });
                    files = Client.GetDTAnexos("OPE_CCOTSS_Files", _listFilters);
                    if (files != null && files.Rows.Count > 0)
                    {
                        DView = new DOC002DView();
                        DView.Presenter = this;
                        DView.DTFiles = files.Copy();
                        DView.LoadView();
                        ((DOC002DView)DView).ShowDialog();
                    }
                    else
                    { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Title, "Este Item no cuenta con ningun Documentos"); }
                }
                else
                {
                    Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Title, "Debe seleccionar un Items");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion

        #region [ Metodos Eventos/Tareas ]
        public void GenerarEventosTareas(String Observacion_Evento, String Codigo_Evento, DataTable DT_OV)
        {
            try
            {
                ItemsEventosTareas = new ObservableCollection<Det_Cotizacion_OV_EventosTareas>();
                int pos = 1;
                Int32 _CCOT_NumActual = 0;

                if (DT_OV != null && DT_OV.Rows.Count > 0)
                {
                    foreach (DataRow drOV in DT_OV.Rows)
                    {
                        if ((Convert.ToInt32(drOV["CCOT_Numero"])) != _CCOT_NumActual)
                        {
                            _CCOT_NumActual = (Convert.ToInt32(drOV["CCOT_Numero"]));

                            ItemEventoTarea = new Det_Cotizacion_OV_EventosTareas();
                            ItemEventoTarea.CCOT_Numero = (Convert.ToInt32(drOV["CCOT_Numero"]));
                            ItemEventoTarea.CCOT_Tipo = (Convert.ToInt16(drOV["CCOT_Tipo"]));
                            ItemEventoTarea.EVEN_Fecha = DateTime.Now;
                            ItemEventoTarea.EVEN_Cumplida = true;
                            ItemEventoTarea.EVEN_Usuario = Session.UserName;
                            ItemEventoTarea.EVEN_Observaciones = Observacion_Evento;
                            ItemEventoTarea.TIPO_TabEVE = "EVE";
                            ItemEventoTarea.TIPO_CodEVE = Codigo_Evento;
                            if (ListConstantesMOD != null && ListConstantesMOD.Count > 0 && ListConstantesMOD.First() != null)
                            {
                                ItemEventoTarea.CONS_TabMOD = ListConstantesMOD.First().CONS_CodTabla;
                                ItemEventoTarea.CONS_CodMOD = ListConstantesMOD.First().CONS_CodTipo;
                            }
                            ItemEventoTarea.EVEN_Manual = false;

                            ItemEventoTarea.AUDI_UsrCrea = Session.UserName;
                            ItemEventoTarea.AUDI_FecCrea = Session.Fecha;

                            ItemEventoTarea.Instance = Infrastructure.Aspect.BusinessEntity.InstanceEntity.Added;

                            ItemsEventosTareas.Add(ItemEventoTarea);
                        }
                        else
                        { _CCOT_NumActual = (Convert.ToInt32(drOV["CCOT_Numero"])); }
                        if (DT_OV.Rows.Count == pos)
                        {
                            if ((Client.SaveDet_Cotizacion_OV_EventosTareas(ItemsEventosTareas)))
                            {
                                Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Title, "Se han Generado Eventos");
                            }
                        }
                        pos++;
                    }
                }
                //else
                //{ Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Title, "No hay Ordenes de venta para generar eventos."); }

            }
            catch (Exception ex)
            {
                Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Title, "Error al momento de generar Eventos", ex);
            }
        }
        public void GenerarEventosTareas(String Observacion_Evento, String Codigo_Evento, Int32 x_CCOT_Numero, Int16 x_CCOT_Tipo)
        {
            try
            {
                ItemsEventosTareas = new ObservableCollection<Det_Cotizacion_OV_EventosTareas>();
                ItemEventoTarea = new Det_Cotizacion_OV_EventosTareas();
                ItemEventoTarea.CCOT_Numero = x_CCOT_Numero;
                ItemEventoTarea.CCOT_Tipo = x_CCOT_Tipo;
                ItemEventoTarea.EVEN_Fecha = DateTime.Now;
                ItemEventoTarea.EVEN_Cumplida = true;
                ItemEventoTarea.EVEN_Usuario = Session.UserName;
                ItemEventoTarea.EVEN_Observaciones = Observacion_Evento;
                ItemEventoTarea.TIPO_TabEVE = "EVE";
                ItemEventoTarea.TIPO_CodEVE = Codigo_Evento;
                if (ListConstantesMOD != null && ListConstantesMOD.Count > 0 && ListConstantesMOD.First() != null)
                {
                    ItemEventoTarea.CONS_TabMOD = ListConstantesMOD.First().CONS_CodTabla;
                    ItemEventoTarea.CONS_CodMOD = ListConstantesMOD.First().CONS_CodTipo;
                }
                ItemEventoTarea.EVEN_Manual = false;

                ItemEventoTarea.AUDI_UsrCrea = Session.UserName;
                ItemEventoTarea.AUDI_FecCrea = Session.Fecha;

                ItemEventoTarea.Instance = Infrastructure.Aspect.BusinessEntity.InstanceEntity.Added;

                ItemsEventosTareas.Add(ItemEventoTarea);

                if ((Client.SaveDet_Cotizacion_OV_EventosTareas(ItemsEventosTareas)))
                {
                    Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Title, "Se han Generado Eventos");
                }

            }
            catch (Exception ex)
            {
                Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Title, "Error al momento de generar Eventos", ex);
            }
        }
        #endregion
    }
}