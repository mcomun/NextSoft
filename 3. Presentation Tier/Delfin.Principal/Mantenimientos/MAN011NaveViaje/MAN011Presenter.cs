using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.Unity;
using Delfin.ServiceContracts;
using Delfin.ServiceProxy;
using Delfin.Entities;
using Infrastructure.Client.Services.Session;
using System.Collections.ObjectModel;
using System.Data;
using System.IO;
using System.Windows.Forms;

namespace Delfin.Principal
{
    public class MAN011Presenter
    {
        #region [ Variables ]
        public String Title = "Mantenimiento de NaveViaje";
        public String CUS = "MAN011";
        public Decimal TIPC_Venta;
        public Nullable<Int32> m_Cod_Transportista;
        #endregion

        #region [ Contrusctor ]
        public MAN011Presenter(IUnityContainer x_container, IMAN011LView x_lview, IMAN011MView x_mview)
        {
            try
            {
                this.ContainerService = x_container;
                Session = this.ContainerService.Resolve<ISessionService>();
                this.LView = x_lview;
                this.MView = x_mview;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public MAN011Presenter(IUnityContainer x_container, IMAN011MView x_mview)
        {
            try
            {
                this.ContainerService = x_container;
                Session = this.ContainerService.Resolve<ISessionService>();

                this.MView = x_mview;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public void Load()
        {
            try
            {
                Client = ContainerService.Resolve<IDelfinServices>();

                ListPuertos = new ObservableCollection<Puerto>();//Client.GetAllPuerto();

                ItemTransportista = new Entidad();
                ItemsNave = new ObservableCollection<Nave>();
                ItemsNaveUnTransportista = new ObservableCollection<Nave>();
                ItemsParametrosCorreo = new ObservableCollection<Parametros>();
                ItemsNave = Client.GetAllNave(null);
                ListConstantesMOD = Client.GetAllConstantesByConstanteTabla("MOD");
                //ItemsParametrosCorreo = Client.GetAllParametrosByClave("CO%");
                LoadParameteres();

                if (LView != null)
                {
                    LView.LoadView();
                }
                MView.LoadView();
            }
            catch (Exception ex)
            {
                Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Title, "Ha ocurrido un error inicializando la vista.", ex);
            }
        }
        #endregion

        #region [ Parámetros ]
        public Entities.Parametros PARA_CODIGOCOSCO { get; set; }
        public Entities.Parametros PARA_CODIGOTRAMARSA { get; set; }
        public Entities.Parametros PARA_CORREOOPERACIONES { get; set; }
        public Entities.Parametros PARA_CORREOLOGISTICA { get; set; }
        public Entities.Parametros PARA_CORREOFINANZAS { get; set; }
        public Entities.Parametros PARA_CORREOFLETAMENTO { get; set; }
        public Entities.Parametros PARA_CORREOCUSTOMER_IMPO { get; set; }
        public Entities.Parametros PARA_CORREOCUSTOMER_EXPO { get; set; }
        public Entities.Parametros PARA_CODIGOEMPRESA { get; set; } //Empresa de DELFIN GROUP PERU 
        //####### EVENTOS #######
        public Entities.Parametros PARA_DIRECCIONAMIENTOLINEA { get; set; }
        public Entities.Parametros PARA_EMAILALMACEN { get; set; }
        public Entities.Parametros PARA_DESGLOSEVoBo { get; set; }
        public Entities.Parametros PARA_CARTAAVISOS { get; set; }
        public Entities.Parametros PARA_OVCERRADA { get; set; }
        public Entities.Parametros PARA_APERTURASTATMENT { get; set; }
        public Entities.Parametros PARA_EMITIRSTATEMENT { get; set; }
        //#######################
        private void LoadParameteres()
        {
            try
            {
                var ItemsPARAMETRO = Client.GetAllParametros();
                PARA_CODIGOCOSCO = ItemsPARAMETRO.FirstOrDefault(para => para.PARA_Clave == "CODIGO_COSCO_PERU");
                PARA_CODIGOTRAMARSA = ItemsPARAMETRO.FirstOrDefault(para => para.PARA_Clave == "CODIGO_TRAMARSA");
                PARA_CORREOOPERACIONES = ItemsPARAMETRO.FirstOrDefault(para => para.PARA_Clave == "CORREO_OPERACIONES");
                PARA_CORREOLOGISTICA = ItemsPARAMETRO.FirstOrDefault(para => para.PARA_Clave == "CORREO_LOGISTICA");
                PARA_CORREOFINANZAS = ItemsPARAMETRO.FirstOrDefault(para => para.PARA_Clave == "CORREO_FINANZAS");
                PARA_CORREOFLETAMENTO = ItemsPARAMETRO.FirstOrDefault(para => para.PARA_Clave == "CORREO_FLETAMENTO");
                PARA_CORREOCUSTOMER_IMPO = ItemsPARAMETRO.FirstOrDefault(para => para.PARA_Clave == "CORREO_CUSTOMER_IMPO");
                PARA_CORREOCUSTOMER_EXPO = ItemsPARAMETRO.FirstOrDefault(para => para.PARA_Clave == "CORREO_CUSTOMER_EXPO");
                PARA_CODIGOEMPRESA = ItemsPARAMETRO.FirstOrDefault(para => para.PARA_Clave == "EMPRESA");
                //####### EVENTOS #######
                PARA_DIRECCIONAMIENTOLINEA = ItemsPARAMETRO.FirstOrDefault(para => para.PARA_Clave == "DIRECCIONALINEA");
                PARA_EMAILALMACEN = ItemsPARAMETRO.FirstOrDefault(para => para.PARA_Clave == "EMAILALMACEN");
                PARA_DESGLOSEVoBo = ItemsPARAMETRO.FirstOrDefault(para => para.PARA_Clave == "DESGLOSEVoBo");
                PARA_CARTAAVISOS = ItemsPARAMETRO.FirstOrDefault(para => para.PARA_Clave == "CARTA_AVISOS");
                PARA_OVCERRADA = ItemsPARAMETRO.FirstOrDefault(para => para.PARA_Clave == "OVCERRADA");
                PARA_APERTURASTATMENT = ItemsPARAMETRO.FirstOrDefault(para => para.PARA_Clave == "APERTURA_STATMENT");
                PARA_EMITIRSTATEMENT = ItemsPARAMETRO.FirstOrDefault(para => para.PARA_Clave == "EMITIR_STATEMENT");
                //#######################
            }
            catch (Exception)
            { }
        }
        #endregion

        #region [ Propiedades ]
        public IUnityContainer ContainerService { get; set; }
        public ISessionService Session { get; set; }
        public IDelfinServices Client { get; set; }
        public IMAN011LView LView { get; set; }
        public IMAN011MView MView { get; set; }
        public NaveViaje Item { get; set; }
        public Entidad ItemTransportista { get; set; }
        public ObservableCollection<NaveViaje> Items { get; set; }
        public Constantes ItemVIA { get; set; }
        public DateTime x_NVIA_FecETA = new DateTime();
        public Nave ItemNave { get; set; }
        public ObservableCollection<Parametros> ItemsParametrosCorreo { get; set; }
        public ObservableCollection<Nave> ItemsNave { get; set; }
        public ObservableCollection<Nave> ItemsNaveUnTransportista { get; set; }
        public ObservableCollection<Puerto> ListPuertos { get; set; }
        public Constantes FILTROEstado { get; set; }
        public Constantes FILTROItemVia { get; set; }
        public Constantes FILTROItemRegimen { get; set; }
        public Entidad FILTROItemTransportista { get; set; }
        public Nullable<Int16> FILTROItemNave { get; set; }
        public Nullable<DateTime> FILTROItemFecCreacion { get; set; }
        public String FILTROItemNroViaje { get; set; }
        public ObservableCollection<Constantes> ListConstantesMOD { get; set; }
        public ObservableCollection<Det_Cotizacion_OV_EventosTareas> ItemsEventosTareas { get; set; }
        public Det_Cotizacion_OV_EventosTareas ItemEventoTarea { get; set; }
        //CARTAS
        public DataTable VoBo = new DataTable(); // CARTA DE DESGLOSE DE VoBo
        public DataTable DtDireciomaniento = new DataTable(); // CARTA DE CAMBIO DE ALMACEN(DIRECCIONAMIENTO)
        public DataTable DtCargaTarjada = new DataTable(); // CORREO DE CARGA TARJADA FCL/LCL
        public DataTable DtEmisionHBL = new DataTable(); // CORREO DE LOS CLIENTES EMISION DE HBL
        public DataTable DtAvisos = new DataTable(); //AVISO DE LLEGADA, ZARPE, SALIDA.....
        public DataTable DtPP = new DataTable();//Parte del contenedor 
        #endregion

        #region [ Metodos ]
        public void Actualizar(bool x_BaseDatos = true)
        {
            try
            {
                if (x_BaseDatos)
                {
                    Item = null;
                    Items = null;
                    String NVIA_Estado = null;
                    String CONS_TabVia = null;
                    String CONS_CodVia = null;
                    String CONS_TabRGM = null;
                    String CONS_CodRGM = null;
                    Nullable<Int32> ENTC_CodTransportista = null;
                    Nullable<Int16> NAVE_Codigo = null;
                    Nullable<DateTime> NVIA_FecCreacion = null;
                    String NVIA_NroViaje = null;


                    if (FILTROEstado != null)
                    {
                        NVIA_Estado = FILTROEstado.CONS_CodTipo;
                    }

                    if (FILTROItemTransportista != null)
                    {
                        ENTC_CodTransportista = FILTROItemTransportista.ENTC_Codigo;
                    }

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

                    if (FILTROItemNave != null && FILTROItemNave != -1)
                    {
                        NAVE_Codigo = FILTROItemNave;
                    }
                    else
                    {
                        NAVE_Codigo = null;
                    }

                    if (FILTROItemNroViaje != null)
                    {
                        NVIA_NroViaje = FILTROItemNroViaje;
                    }
                    else
                    {
                        NVIA_NroViaje = null;
                    }

                    if (FILTROItemFecCreacion != null)
                    {
                        NVIA_FecCreacion = FILTROItemFecCreacion.Value;
                    }

                    Items = Client.GetAllNaveViajeByFiltros(true, NVIA_Estado, CONS_TabRGM, CONS_CodRGM, CONS_TabVia, CONS_CodVia, ENTC_CodTransportista, NAVE_Codigo, NVIA_FecCreacion, NVIA_NroViaje);
                    if (Items == null || Items.Count == 0)
                    {
                        Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Title, "No se encontraron coincidencias ");
                    }

                }
                else
                {
                    if (this.Item.Instance == Infrastructure.Aspect.BusinessEntity.InstanceEntity.Added)
                    {
                        if (Items == null)
                        {
                            Items = new ObservableCollection<NaveViaje>();
                        }
                        Items.Add(Item);
                    }
                    else if (this.Item.Instance == Infrastructure.Aspect.BusinessEntity.InstanceEntity.Modified)
                    {
                        Items.Contains(Item);
                    }
                }
                LView.ShowItems();
            }
            catch (Exception ex)
            {
                Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Title, "Ha ocurrido un error actualizando.", ex);
            }
        }
        public System.Windows.Forms.DialogResult Nuevo()
        {
            try
            {
                //if (ItemTransportista != null)
                //{
                MView.ClearItem(false);
                this.Item = new NaveViaje();
                //this.Item.NAVE_Codigo = Item.NAVE_Codigo;
                //this.Item.NAVE_Nombre = Item.NAVE_Nombre;
                if (ItemTransportista != null)
                {
                    this.Item.ENTC_CodTransportista = ItemTransportista.ENTC_Codigo;
                }
                this.Item.AUDI_UsrCrea = Session.UserName;
                this.Item.AUDI_FecCrea = Session.Fecha;
                this.Item.NVIA_Estado = "A";
                //this.Item.TIPO_CodTRF = "001";
                this.Item.Instance = Infrastructure.Aspect.BusinessEntity.InstanceEntity.Added;
                MView.SetItem(false);
                return ((MAN011MView)MView).ShowDialog();
                //}
                //else
                //{ Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Title, "Debe seleccionar un Transportista."); return System.Windows.Forms.DialogResult.Cancel; }
            }
            catch (Exception ex)
            {
                Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Title, Infrastructure.Aspect.Constants.Mensajes.NewPresenter, ex);
                return System.Windows.Forms.DialogResult.Cancel;
            }
        }
        public System.Windows.Forms.DialogResult NuevoEdicion()
        {
            try
            {
                MView.ClearItem(true);
                //this.Item = new NaveViaje();
                //this.Item.NAVE_Codigo = Item.NAVE_Codigo;
                //this.Item.NAVE_Nombre = Item.NAVE_Nombre;

                //this.Item.ENTC_CodTransportista = ItemTransportista.ENTC_Codigo;
                this.Item.AUDI_UsrCrea = Session.UserName;
                this.Item.AUDI_FecCrea = Session.Fecha;
                this.Item.Instance = Infrastructure.Aspect.BusinessEntity.InstanceEntity.Added;
                MView.SetItem(true);
                MView.DisableFromOV();
                return ((MAN011MView)MView).ShowDialog();
            }
            catch (Exception ex)
            {
                Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Title, Infrastructure.Aspect.Constants.Mensajes.NewPresenter, ex);
                return System.Windows.Forms.DialogResult.Cancel;
            }
        }
        public System.Windows.Forms.DialogResult Editar()
        {
            try
            {
                if (Item != null)
                {
                    Item = Client.GetOneNaveViaje(Item.NVIA_Codigo);
                    //DtEmisionHBL = new DataTable();
                    //DtEmisionHBL = Client.GetAllEmisionHBLByNaveViaje(Item.NVIA_Codigo);
                    if (String.IsNullOrEmpty(Item.NVIA_Estado))
                    {
                        this.Item.NVIA_Estado = "A";
                    }
                    this.m_Cod_Transportista = Item.ENTC_CodTransportista;
                    MView.ClearItem(false);
                    this.Item.AUDI_UsrMod = Session.UserName;
                    this.Item.AUDI_FecMod = Session.Fecha;
                    this.Item.Instance = Infrastructure.Aspect.BusinessEntity.InstanceEntity.Modified;
                    MView.SetItem(false);
                    MView.FormatGridDetalle(Item.CONS_CodRGM);

                    //((MAN011MView)MView).Visible = false;
                    return ((MAN011MView)MView).ShowDialog();
                }
                else
                {
                    Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Title, "Debe seleccionar un elemento de la grilla");
                    return System.Windows.Forms.DialogResult.Cancel;
                }
            }
            catch (Exception ex)
            {
                Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Title, Infrastructure.Aspect.Constants.Mensajes.EditPresenter, ex);
                return System.Windows.Forms.DialogResult.Cancel;
            }
        }
        public void Eliminar()
        {
            try
            {
                if (Item != null)
                {
                    try
                    {
                        System.Windows.Forms.DialogResult _result = Infrastructure.WinForms.Controls.Dialogos.MostrarMensajePregunta(Title, Infrastructure.Aspect.Constants.Mensajes.PreguntaEliminar, Infrastructure.WinForms.Controls.Dialogos.LabelBoton.Si_No);
                        if (_result == System.Windows.Forms.DialogResult.Yes)
                        {
                            Item.Instance = Infrastructure.Aspect.BusinessEntity.InstanceEntity.Deleted;
                            if (Client.SaveNaveViaje(Item) > 0)
                            {
                                Actualizar(true);
                                Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeSatisfactorio(Title, "Se ha eliminado el item.");
                            }
                            else
                            {
                                Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Title, "Ha ocurrido un error al guardar el item.");
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        string errorMsg = Delfin.Controls.Utils.getErrorMsg(ex);
                        Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Title, errorMsg, ex);
                    }
                }
                else
                {
                    Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Title, "Debe seleccionar un elemento de la grilla");
                }
            }
            catch (Exception ex)
            {
                Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Title, Infrastructure.Aspect.Constants.Mensajes.DeletePresenter, ex);
            }
        }
        public bool Guardar()
        {
            try
            {
                MView.GetItem();
                if (Item.Validar())
                {
                    String _MenssaggeError = ValidarExistencia(Item);
                    if (String.IsNullOrEmpty(_MenssaggeError))
                    {
                        Boolean _ActulizarOVS = false;
                        if (ValidarOrdenVenta(Item.NVIA_Codigo,ref _ActulizarOVS))
                        {
                            Int32 _NVIA_Codigo = Client.SaveNaveViaje(Item);
                            if (_NVIA_Codigo > 0)
                            //{
                            //   Item.NVIA_Codigo = _NVIA_Codigo;
                            //if (Client.SaveNaveViaje(Item))
                            {
                                if (_ActulizarOVS)
                                {
                                    Client.UpdateTransportistaOVsByNVIA(Item.NVIA_Codigo, Item.ENTC_CodTransportista);
                                }
                                Item.NVIA_Codigo = _NVIA_Codigo;
                                Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeSatisfactorio(Title, "Se ha guardado satisfactoriamente");
                                if (LView != null)
                                {
                                    Actualizar(true);
                                }
                                return true;
                                return true;
                            }
                            //}
                            else
                            {
                                Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Title, "Ha ocurrido un error al guardar el item.");
                                return false;
                            }
                        }
                        else
                        {
                            return false;
                        }
                    }
                    else
                    {
                        Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Title, _MenssaggeError);
                        return false;
                    }
                }
                else
                {
                    MView.ShowValidation();
                    return false;
                }
            }
            catch (Exception ex)
            {
                Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Title, Infrastructure.Aspect.Constants.Mensajes.SavePresenter, ex);
                return false;
            }
        }
        /// <summary>
        /// Metodo para refrescar la pantalla con nuevos datos 
        /// </summary>
        public void ScreenRefresh(Int32 x_NVIA_Codigo)
        {
            try
            {
                Item = Client.GetOneNaveViaje(x_NVIA_Codigo);
                MView.ClearItem(false);
                this.Item.AUDI_UsrMod = Session.UserName;
                this.Item.AUDI_FecMod = Session.Fecha;
                this.Item.Instance = Infrastructure.Aspect.BusinessEntity.InstanceEntity.Modified;
                MView.SetItem(false);
                MView.FormatGridDetalle(Item.CONS_CodRGM);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public System.Windows.Forms.DialogResult GuardarCambios()
        {
            try
            {
                if (this.Item != null)
                {
                    System.Windows.Forms.DialogResult _result = Infrastructure.WinForms.Controls.Dialogos.MostrarMensajePregunta(Title, Infrastructure.Aspect.Constants.Mensajes.SaveChangesPreguntaPresenter, Infrastructure.WinForms.Controls.Dialogos.LabelBoton.Si_No);
                    if (_result == System.Windows.Forms.DialogResult.Yes)
                    {
                        if (Guardar())
                        {
                            return System.Windows.Forms.DialogResult.Yes;
                        }
                        else
                        {
                            return System.Windows.Forms.DialogResult.Cancel;
                        }
                    }
                    else
                    {
                        return _result;
                    }
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
        public void CargaTarjada(Nullable<Int32> NVIA_Codigo, String TIPO_Embarque)
        {
            Nullable<Int32> _CCOT_Numero = null;
            DtCargaTarjada = new DataTable();
            DtCargaTarjada = Client.GetAllCargaTarjadaByNaveViaje(NVIA_Codigo, TIPO_Embarque, _CCOT_Numero);
        }
        public void DesgloseVoBo(Nullable<Int32> NVIA_Codigo, Int16 TIPO_VoBo)
        {
            Nullable<Int32> _CCOT_Numero = null;
            VoBo = new DataTable();
            VoBo = Client.GetAllDet_CntrByNaveViaje(NVIA_Codigo, TIPO_VoBo, _CCOT_Numero);
        }
        public void Direccionamiento(Nullable<Int32> NVIA_Codigo, Int16 TIPO_Direccionamiento)
        {
            Nullable<Int32> _CCOT_Numero = null;
            DtDireciomaniento = new DataTable();
            DtDireciomaniento = Client.GetAllMBLsByNaveViaje(NVIA_Codigo, TIPO_Direccionamiento, _CCOT_Numero);
        }
        //public void PP(Nullable<Int32> NVIA_Codigo ,Nullable<Int32> CCOT_Numero , String CNTR_Numero)
        //{
        //    DtPP = new DataTable();
        //    ObservableCollection<Infrastructure.Aspect.DataAccess.DataAccessFilterSQL> _listFilters = new ObservableCollection<Infrastructure.Aspect.DataAccess.DataAccessFilterSQL>();
        //    _listFilters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@pintNVIA_Codigo", FilterValue = NVIA_Codigo, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.Int32, FilterSize = 4 });
        //    _listFilters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@pintCCOT_Numero", FilterValue = CCOT_Numero, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.Int32, FilterSize = 4 });
        //    _listFilters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@pvchCNTR_Numero", FilterValue = CNTR_Numero, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.Varchar, FilterSize = 20 });
        //    DtPP = Client.GetDTAnexos("COM_NVIASS_PP", _listFilters);
        //}
        public void CartasAvisos()
        {
            DtAvisos = new DataTable();
            DtAvisos = Client.GetAllAvisosByNaveViaje(Item.NVIA_Codigo, null,null,null);
        }
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
                else
                { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Title, "No hay Ordenes de venta para generar eventos."); }

            }
            catch (Exception ex)
            {
                Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Title, "Error al momento de generar Eventos", ex);
            }
        }
        public DataTable BuscarOv(Int32 NVIA_Codigo, Int32 TIPO_Condicion)
        {
            DataTable DT_OV = new DataTable();
            try
            {
                ObservableCollection<Infrastructure.Aspect.DataAccess.DataAccessFilterSQL> _listFilters = new ObservableCollection<Infrastructure.Aspect.DataAccess.DataAccessFilterSQL>();
                _listFilters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@pintNVIA_Codigo", FilterValue = NVIA_Codigo, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.Int32, FilterSize = 4 });
                _listFilters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@pintTIPO_Condicion", FilterValue = TIPO_Condicion, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.Int32, FilterSize = 4 });
                DT_OV = Client.GetDTAnexos("COM_NVIASS_OrdenesVentas", _listFilters);
                return DT_OV;
            }
            catch (Exception ex)
            {
                Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Title, "Error al momento de traer ordenes de venta", ex);
                return DT_OV;
            }
        }
        private String ValidarExistencia(NaveViaje x_item)
        {
            try
            {
                String _MenssaggeError = String.Empty;
                _MenssaggeError = Client.CheckNaveViaje(x_item);
                return _MenssaggeError;

            }
            catch (Exception ex)
            { throw ex; }
        }
        private Boolean ValidarOrdenVenta(Nullable<Int32> x_NVIA_Codigo, ref Boolean x_ActualizarOVs)
        {
            try
            {
                if (Item.Instance == Infrastructure.Aspect.BusinessEntity.InstanceEntity.Modified)
                {
                    String _OrdenesVenta = String.Empty;
                    if (m_Cod_Transportista != Item.ENTC_CodTransportista)
                    {
                        _OrdenesVenta = Client.OrdenesVentaByNVIA(x_NVIA_Codigo);
                        if (String.IsNullOrEmpty(_OrdenesVenta))
                        {
                            return true;
                        }
                        else
                        {
                            DialogResult _result = Infrastructure.WinForms.Controls.Dialogos.MostrarMensajePregunta(Title, "Usted a cambiado el Transportista se actualizará las siguiente Orden(es) de Venta(detalles) ¿Deseea Proceder? ", _OrdenesVenta, Infrastructure.WinForms.Controls.Dialogos.LabelBoton.Acceptar_Cancelar);
                            if (_result == System.Windows.Forms.DialogResult.OK)
                            {
                                x_ActualizarOVs = true;
                                return true;
                            }
                            else
                            {
                                return false;
                            }
                        }
                    }
                    else
                    {
                        return true;
                    }
                }
                else
                {
                    return true;
                }
            }
            catch (Exception ex)
            { throw ex; }
        }
        #endregion

        #region [ Metodos Statment ]
        public String EmitirStatment(Boolean ChangeControl, ref DataTable x_DTOV)
        {
            String _rutaStatment = String.Empty;
            try
            {
                String _mensaje = "";
                Boolean _isCorrect = true;

                Int16 _EMPR_Codigo = Controls.Entorno.ItemEmpresa.EMPR_Codigo;
                Int16 _SUCR_Codigo = Controls.Entorno.ItemSucursal.SUCR_Codigo;
                Int32 _NVIA_Codigo = Item.NVIA_Codigo;
                Nullable<Int16> _CCOT_Tipo = null;
                Nullable<Int32> _CCOT_Numero = null;

                _isCorrect = Client.OPE_SaveCab_Cotizacion_OV_ValidarCuentasCorrientes(_EMPR_Codigo, _SUCR_Codigo, _NVIA_Codigo, _CCOT_Tipo, _CCOT_Numero, ref _mensaje);

                if (_isCorrect)
                {
                    // GENERAR EXCEL
                    Int16 EMPR_Codigo = Delfin.Controls.Entorno.ItemEmpresa.EMPR_Codigo;
                    Int16 SUCR_Codigo = Delfin.Controls.Entorno.ItemSucursal.SUCR_Codigo;
                    Int32 NVIA_Codigo = Item.NVIA_Codigo;
                    Nullable<Int16> CCOT_Tipo = null;
                    Nullable<Int32> CCOT_Numero = null;
                    String Usuario = Session.UserName;
                   
                    /******************* VALIDAMOS FECHA ETA & ZARPE *********************************/
                    Nullable<DateTime> Fec_ETA_Impo_Zarpe_Expo = null;
                    String _MensajeFechas = String.Empty;
                    switch (Item.CONS_CodRGM)
                    {
                        case Delfin.Controls.variables.CONSRGM_Importacion:
                            Fec_ETA_Impo_Zarpe_Expo = Item.NVIA_FecETA_IMPO_ETD_EXPO;
                            _MensajeFechas = "Debe Ingresar la Fecha ETA para Emitir Statement";
                            break;
                        case Delfin.Controls.variables.CONSRGM_Exportacion:
                            Fec_ETA_Impo_Zarpe_Expo = Item.NVIA_FecLlega_IMPO_Zarpe_EXPO;
                            _MensajeFechas = "Debe Ingresar la Fecha Zarpe para Emitir Statement";
                            break;
                    }
                    if (Fec_ETA_Impo_Zarpe_Expo != null)
                    {
                        var _itemTipoCambio = Client.GetOneTiposCambio(Session.Fecha.ToString("yyyyMMdd"));
                        if (_itemTipoCambio != null)
                        {
                            System.Data.DataTable dtStatment = Client.OPE_GetCab_Cotizacion_OVStatment(EMPR_Codigo, SUCR_Codigo, NVIA_Codigo, CCOT_Tipo, CCOT_Numero, Usuario, _itemTipoCambio.TIPC_Venta, ChangeControl, false);

                            if (dtStatment != null && dtStatment.Rows.Count > 0)
                            {
                                String _folder = @"STATEMENT";
                                String pathString = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), _folder);
                                System.IO.Directory.CreateDirectory(pathString);
                                _rutaStatment = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), _folder, "Statement" + Item.NVIA_Codigo + ".xls");
                                Infrastructure.WinForms.Controls.ExportarExcel.Export(dtStatment, true, _rutaStatment);
                                // Actualizamos el usuario que emitio el statment
                                if ((!String.IsNullOrEmpty(_rutaStatment)) && (File.Exists((string)_rutaStatment)))
                                {
                                    Boolean _iscorrect = Client.EmiteStatment_Update_User(NVIA_Codigo, Usuario);
                                    x_DTOV.Columns.Add("CCOT_Numero", typeof(String));
                                    x_DTOV.Columns.Add("CCOT_Tipo", typeof(Int16));
                                    foreach (DataRow drStatement in dtStatment.Rows)
                                    {
                                        string l_ccot_numero = Convert.ToString(drStatement["ORDEN VENTA"]);
                                        if (!String.IsNullOrEmpty(l_ccot_numero))
                                        {
                                            int l_tam = l_ccot_numero.Length;
                                            l_ccot_numero = l_ccot_numero.Substring((l_tam - 4), 4);
                                            DataRow dr = x_DTOV.NewRow();
                                            dr["CCOT_Numero"] = l_ccot_numero;
                                            dr["CCOT_Tipo"] = 2;
                                            x_DTOV.Rows.Add(dr);
                                        }
                                    }
                                }
                            }
                            else
                            { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Title, "No se han encontrado registros para emitir el Statement"); }
                        }
                        else
                        { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Title, "Debe ingresar el Tipo de Cambio para la fecha " + Session.Fecha.ToShortDateString()); }
                    }
                    else
                    { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Title, _MensajeFechas); }
                }
                else
                {
                    if (!String.IsNullOrEmpty(_mensaje))
                    { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Title, "Ha ocurrido un error al emitir el Statement.", _mensaje); }
                    else
                    { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Title, "Ha ocurrido un error al emitir el Statement."); }
                }

                return _rutaStatment;
            }
            catch (Exception ex)
            {
                Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Title, "Ha Ocurrido un error al emitir el Statement", ex);
                return _rutaStatment;
            }
        }
        public bool AbrirStatment()
        {
            try
            {
                Int32 _NVIA_Codigo = Item.NVIA_Codigo;
                String _Mensaje = String.Empty;
                Boolean _isCorrect = Client.AbrirStatment_Update_NaveViaje_OV(_NVIA_Codigo,ref _Mensaje);
                if (_isCorrect)
                {
                    Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeSatisfactorio(Title, "Se ha procesado la Apertura del Statment Correctamente");
                    return true;
                }
                else
                { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Title, "Ha ocurrido un error al procesar la Apertura del Statment",_Mensaje); return false; }
            }
            catch (Exception ex)
            { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Title, "Ha Ocurrido un error al Abrir el Statment", ex); return false; }
        }
        public Boolean PreFacturar()
        {
            try
            {
                var _itemTipoCambio = Client.GetOneTiposCambio(Session.Fecha.ToString("yyyyMMdd"));
                DateTime _fecha = Client.GetFecha();
               
                if (_itemTipoCambio != null)
                {
                    TIPC_Venta = _itemTipoCambio.TIPC_Venta;
                    Int16 _EMPR_Codigo = Controls.Entorno.ItemEmpresa.EMPR_Codigo;
                    Int16 _SUCR_Codigo = Controls.Entorno.ItemSucursal.SUCR_Codigo;
                    Int32 _NVIA_Codigo = Item.NVIA_Codigo;
                    Nullable<Int16> _CCOT_Tipo = null;
                    Nullable<Int32> _CCOT_Numero = null;
                    Decimal _CCCT_TipoCambio = _itemTipoCambio.TIPC_Venta;
                    DateTime _CCCT_FecEmision = _fecha; // Session.Fecha;
                    String _AUDI_Usuario = Session.UserName;

                    String _mensaje = "";
                    Boolean _isCorrect = true;

                    //_isCorrect = Client.SaveAprobarStatment(Item.NVIA_Codigo, Session.UserName, ref _mensaje);
                    //if (_isCorrect)
                    //{ 
                    _isCorrect = Client.OPE_SaveCab_Cotizacion_OV_GenerarCuentasCorrientes(_EMPR_Codigo, _SUCR_Codigo, _NVIA_Codigo, _CCOT_Tipo, _CCOT_Numero, _CCCT_TipoCambio, _CCCT_FecEmision, _AUDI_Usuario, true, ref _mensaje);
                    //}

                    if (_isCorrect)
                    { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeSatisfactorio(Title, "Se ha procesado la Pre-Facturación correctamente."); return true; }
                    else
                    {
                        if (!String.IsNullOrEmpty(_mensaje))
                        { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Title, "Ha ocurrido un error al procesar la Pre-Facturación.", _mensaje); return false; }
                        else
                        { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Title, "Ha ocurrido un error al procesar la Pre-Facturación."); return false; }
                    }
                }
                else
                { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Title, "Debe ingresar el Tipo de Cambio para la fecha " + Session.Fecha.ToShortDateString()); return false; }
            }
            catch (Exception ex)
            { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Title, "Ha Ocurrido un error al procesar la Pre-Facturación", ex); return false; }
        }
        #endregion
    }
}