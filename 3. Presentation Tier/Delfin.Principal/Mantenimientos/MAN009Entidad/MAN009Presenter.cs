using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Windows.Forms;
using Delfin.Controls;
using Infrastructure.Aspect.BusinessEntity;
using Infrastructure.Aspect.Constants;
using Infrastructure.WinForms.Controls;
using Microsoft.Practices.Unity;
using Delfin.ServiceContracts;
using Delfin.Entities;
using Infrastructure.Client.Services.Session;
using System.Collections.ObjectModel;
using Delfin.Principal.Mantenimientos.MAN009Entidad;
using Entidad = Delfin.Entities.Entidad;
using System.Text.RegularExpressions;
using ApplicationForm.OnLineService;

namespace Delfin.Principal
{
    public class MAN009Presenter
    {
        OnLineService.OnLineServiceClient oOnLineService = new OnLineService.OnLineServiceClient();
        public Int32 REGI_Codigo = 0;

        #region [ Variables ]
        public String Title = "Mantenimiento de Entidad";
        public String CUS = "MAN009";
        public string tipe_Desc = ""; // descripcion de la entidad
        public Boolean lsinlview = false;// por defecto 
        #endregion

        #region [ Constructor ]
        public MAN009Presenter(IUnityContainer x_container, IMAN009LView x_lview, IMAN009MView x_mview, Int16 x_tipe_codigo)
        {
            try
            {
                ContainerService = x_container;
                Session = ContainerService.Resolve<ISessionService>();
                LView = x_lview;
                MView = x_mview;
                tipe_Codigo = x_tipe_codigo;
            }
            catch (Exception ex)
            { Dialogos.MostrarMensajeError(Title, Mensajes.ConstructorPresenter, ex); }
        }
        public MAN009Presenter(IUnityContainer x_container, IMAN009MView x_mview, Int16 x_tipe_codigo)
        {
            try
            {
                ContainerService = x_container;
                Session = ContainerService.Resolve<ISessionService>();
                MView = x_mview;
                tipe_Codigo = x_tipe_codigo;
            }
            catch (Exception ex)
            { Dialogos.MostrarMensajeError(Title, Mensajes.ConstructorPresenter, ex); }
        }

        public void Load()
        {
            try
            {
                Client = ContainerService.Resolve<IDelfinServices>();

                ListServicios = Client.GetAllServicio();
                ListMoneda = Client.GetAllTiposByTipoCodTabla("MND");
                tipe_Desc = EntidadClear.getDescTipoEntidad(tipe_Codigo);
                ListConstantesBAS = Client.GetAllConstantesByConstanteTabla("BAS");
                ListConstantesRGM = Client.GetAllConstantesByConstanteTabla("RGM");

                ListRegimen = Client.GetAllConstantesByConstanteTabla("RGM");
                ListTrafico = Client.GetAllTiposByTipoCodTabla("TRF");
                ListDocIdentidad = Client.GetAllTiposByTipoCodTabla("TDI");

                ListTiposEntidad = Client.GetTodosTiposEntidad();
                Entities.TiposEntidad _tent = new Entities.TiposEntidad()
                {
                    TIPE_Codigo = 0,
                    TIPE_Descripcion = "< Seleccione Tipo Entidad >"
                };
                ListTiposEntidad.Insert(0, _tent);

                ListParametros = Client.GetAllParametros();

                //Entities.Parametros _parametros = Client.GetOneParametrosByClave("TDI_004SINRUC");
                Entities.Parametros _parametros = ListParametros.Where(Para => Para.PARA_Clave.Equals("TDI_004SINRUC")).FirstOrDefault();
                if (_parametros != null && _parametros.PARA_Valor != null)
                {
                    String[] tdi = _parametros.PARA_Valor.Split('-');
                    if (tdi.Count() > 1)
                    {
                        TIPO_CodTDI = tdi[1];
                    }
                }
                LoadParameteres();

                //lsinlview == true no carga el lview
                if (lsinlview == false) { LView.LoadView(); }

                #region [ Autorizar mostrar las propiedades de Finanzas ]
                MostrarFinanzas = false;
                switch (tipe_Codigo)
                {
                    case EntidadClear.TIPE_Proveedor:
                    case EntidadClear.TIPE_Cliente:
                        NextAdmin.Views.PAutenticacionPresenter m_autenciacionPresenter = new NextAdmin.Views.PAutenticacionPresenter(null, ContainerService);
                        var BL_PermisosUsuarioProcesos = ContainerService.Resolve<NextAdmin.BusinessLogic.IBLPermisosUsuarioProcesos>();
                        NextAdmin.BusinessLogic.PermisosUsuarioProcesos _itemPermisosUsuarioProcesos = BL_PermisosUsuarioProcesos.GetOneByUsuario(Session.AplicacionCodigo.Value, Session.UserCodigo, Delfin.Controls.variables.ENTC_ACCESOFINANZAS);
                        if (_itemPermisosUsuarioProcesos != null && _itemPermisosUsuarioProcesos.PUPR_Codigo > 0)
                        { MostrarFinanzas = true; }
                        break;
                }
                #endregion

                MView.LoadView();
            }
            catch (Exception ex)
            { Dialogos.MostrarMensajeError(Title, "Ha ocurrido un error inicializando la vista.", ex); }
        }
        #endregion

        #region [ Propiedades ]
        public IUnityContainer ContainerService { get; set; }
        public ISessionService Session { get; set; }
        public IDelfinServices Client { get; set; }

        public IMAN009LView LView { get; set; }
        public IMAN009MView MView { get; set; }
        public MAN009RView RView { get; set; }
        public MAN009SView SView { get; set; }
        public MAN009DViewLCredito DViewCLCliente { get; set; }
        public MAN009VViewHistorial VViewHistorial { get; set; }
        public MAN009DViewCtasBancarias DViewCtasBancarias { get; set; }

        public ObservableCollection<Entities.Parametros> ListParametros { get; set; }
        public Entidad Item { get; set; }

        public Boolean MostrarFinanzas { get; set; }
        public Int16 tipe_Codigo; //Tipo entidad 1:clientes, 2:proveedores, 3:...
        public String F_ENTC_RazonSoc { get; set; }
        public String F_ENTC_DocIden { get; set; }

        private ObservableCollection<Entidad> m_Items;
        public ObservableCollection<Entidad> Items
        {
            get { if (m_Items == null) { m_Items = new ObservableCollection<Entidad>(); } return m_Items; }
            set { m_Items = value; }
        }
        public DataTable DT;
        public Entidad_Acuerdo itemEntidadAcuerdo { get; set; }// solo se usa como variable temporal
        public Entidad_Servicio itemEntidadServicio { get; set; }// solo se usa como variable temporal

        public Entidad_Relacionados ItemDepTemporalEntidad { get; set; }
        public ObservableCollection<Servicio> ListServicios { get; set; }
        public ObservableCollection<Tipos> ListMoneda { get; set; }
        public ObservableCollection<Constantes> ListConstantesBAS { get; set; }
        public ObservableCollection<Constantes> ListConstantesRGM { get; set; }
        public ObservableCollection<Entidad_Relacionados> ItemsDepTemporalEntidad { get; set; }

        public ObservableCollection<Constantes> ListRegimen { get; set; }
        public ObservableCollection<Tipos> ListTrafico { get; set; }
        public ObservableCollection<Tipos> ListDocIdentidad { get; set; }
        public ObservableCollection<Tipos> ListPaises { get; set; }
        public ObservableCollection<Entities.TiposEntidad> ListTiposEntidad { get; set; }
        public Servicio ServicioEntidad { get; set; }

        public String TIPO_CodTDI { get; set; }

        #endregion

        #region [ Parámetros ]
        public Entities.Parametros PARA_SERV_OCULTARSHIPPER { get; set; }

        private void LoadParameteres()
        {
            try
            {
                var ItemsPARAMETRO = Client.GetAllParametros();

                PARA_SERV_OCULTARSHIPPER = ItemsPARAMETRO.FirstOrDefault(para => para.PARA_Clave == "SERV_OCULTARSHIPPER");
            }
            catch (Exception)
            { }
        }
        #endregion

        #region [ Metodos ]

        #region [ Entidad ]
        public void Actualizar(bool x_BaseDatos = true)
        {
            try
            {
                ObservableCollection<Infrastructure.Aspect.DataAccess.DataAccessFilterSQL> _listFilters = new ObservableCollection<Infrastructure.Aspect.DataAccess.DataAccessFilterSQL>();
                _listFilters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@pintENTC_Codigo", FilterValue = null, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.Int32, FilterSize = 4 });
                _listFilters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@pvchENTC_NomCompleto", FilterValue = F_ENTC_RazonSoc, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.Varchar, FilterSize = 150 });
                _listFilters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@pvchTIPE_Codigo", FilterValue = tipe_Codigo, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.Int16, FilterSize = 2 });
                _listFilters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@pvchENTC_DocIden", FilterValue = F_ENTC_DocIden, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.Varchar, FilterSize = 25 });

                if (x_BaseDatos)
                {
                    Item = null;
                    Items = null;
                    LView.LoadFilters();

                    Items = Client.GetAllEntidadFilter("ENTCSS_Todos", _listFilters);
                    //Items = Client.GetAllEntidad(tipe_Codigo, F_ENTC_RazonSoc);
                }
                else
                {
                    LView.LoadFilters();
                    Items = Client.GetAllEntidadFilter("ENTCSS_Todos", _listFilters);
                    //Items = Client.GetAllEntidad(tipe_Codigo, F_ENTC_RazonSoc);
                }
                LView.ShowItems();
            }
            catch (Exception ex)
            { Dialogos.MostrarMensajeError(Title, "Ha ocurrido un error actualizando.", ex); }
        }
        public DialogResult Nuevo()
        {
            try
            {
                MView.ClearItem();
                Item = new Entidad();
                itemEntidadAcuerdo = new Entidad_Acuerdo();
                itemEntidadServicio = new Entidad_Servicio();
                Item.ListAcuerdo = new ObservableCollection<Entidad_Acuerdo>();
                Item.ListServicio = new ObservableCollection<Entidad_Servicio>();
                Item.ItemsDepTemporalEntidad = new ObservableCollection<Entidad_Relacionados>();
                Item.ListEntidadCuentaBancarias = new ObservableCollection<EntidadCuentaBancaria>();
                Item.ListEntidadCuentaBancariasEliminados = new ObservableCollection<EntidadCuentaBancaria>();
                Item.ListEntidadLimiteCreditosCliente = new ObservableCollection<EntidadLimiteCredito>();
                Item.ListEntidadLimiteCreditosProveedor = new ObservableCollection<EntidadLimiteCredito>();
                Item.ItemsDepTemporalEntidad = new ObservableCollection<Entidad_Relacionados>();

                Item.Relacionados = new ObservableCollection<Entidad>();

                Item.AUDI_UsrCrea = Session.UserName;
                Item.AUDI_FecCrea = Session.Fecha;
                Item.Instance = InstanceEntity.Added;
                if (tipe_Codigo == EntidadClear.TIPE_Transportista)
                {
                    ItemsDepTemporalEntidad = Client.GetAllEntidadRelacionadosByCliente(null, "DTE");
                    MView.ShowItemsDepTemporal();
                }

                ObservableCollection<Infrastructure.Aspect.DataAccess.DataAccessFilterSQL> _listFilters = new ObservableCollection<Infrastructure.Aspect.DataAccess.DataAccessFilterSQL>();
                switch (tipe_Codigo)
                {
                    case EntidadClear.TIPE_Cliente:
                        _listFilters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@pintENTC_Codigo", FilterValue = Item.ENTC_Codigo, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.Int32, FilterSize = 4 });
                        _listFilters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@psinTIPE_Codigo", FilterValue = tipe_Codigo, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.Int16, FilterSize = 2 });
                        Item.ListEntidadLimiteCreditosCliente = Client.GetAllEntidadLimiteCreditoFilter("CAJ_ENLISS_TodosPorCliente", _listFilters);
                        MView.ShowLimiteCreditoCliente();
                        break;
                    case EntidadClear.TIPE_Proveedor:
                        _listFilters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@pintENTC_Codigo", FilterValue = Item.ENTC_Codigo, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.Int32, FilterSize = 4 });
                        _listFilters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@psinTIPE_Codigo", FilterValue = tipe_Codigo, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.Int16, FilterSize = 2 });
                        Item.ListEntidadLimiteCreditosProveedor = Client.GetAllEntidadLimiteCreditoFilter("CAJ_ENLISS_TodosPorProveedor", _listFilters);
                        MView.ShowLimiteCreditoProveedor();
                        break;
                }

                return ((MAN009MView)MView).ShowDialog();
            }
            catch (Exception ex)
            { Dialogos.MostrarMensajeError(Title, Mensajes.NewPresenter, ex); return DialogResult.Cancel; }
        }
        public DialogResult Editar()
        {
            try
            {
                if (Item != null)
                {
                    MView.ClearItem();

                    Item.AUDI_UsrMod = Session.UserName;
                    Item.AUDI_FecMod = Session.Fecha;
                    Item.Instance = InstanceEntity.Modified;
                    itemEntidadAcuerdo = new Entidad_Acuerdo();
                    Item.ListAcuerdo = new ObservableCollection<Entidad_Acuerdo>();

                    Item.Relacionados = new ObservableCollection<Entidad>();

                    if (tipe_Codigo == EntidadClear.TIPE_Cliente || tipe_Codigo == EntidadClear.TIPE_Agente)
                    { Item.ListServicio = Client.GetAllEntidad_Servicio(Item.ENTC_Codigo); }
                    //buscamos si tiene contacto
                    //Items = Client.GetAllEntidad(tipe_Codigo.ToString());
                    // solo buscamos la entidad con todos sus hijos si es cliente
                    //if (tipe_Codigo == EntidadClear.TIPE_Cliente || tipe_Codigo == EntidadClear.TIPE_Broker ||
                    //    tipe_Codigo == EntidadClear.TIPE_DepositoTemporal || tipe_Codigo == EntidadClear.TIPE_Agente)
                    //{
                    Item = Client.GetOneEntidad(Item.ENTC_Codigo, tipe_Codigo);
                    Item.AUDI_UsrMod = Session.UserName;
                    Item.AUDI_FecMod = Session.Fecha;
                    Item.Instance = InstanceEntity.Modified;
                    //} //buscamos los contactos del cliente  

                    ObservableCollection<Infrastructure.Aspect.DataAccess.DataAccessFilterSQL> _listFilters = new ObservableCollection<Infrastructure.Aspect.DataAccess.DataAccessFilterSQL>();
                    switch (tipe_Codigo)
                    {
                        case EntidadClear.TIPE_Cliente:
                            _listFilters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@pintENTC_Codigo", FilterValue = Item.ENTC_Codigo, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.Int32, FilterSize = 4 });
                            _listFilters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@psinTIPE_Codigo", FilterValue = tipe_Codigo, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.Int16, FilterSize = 2 });
                            Item.ListEntidadLimiteCreditosCliente = Client.GetAllEntidadLimiteCreditoFilter("CAJ_ENLISS_TodosPorCliente", _listFilters);
                            MView.ShowLimiteCreditoCliente();
                            break;
                        case EntidadClear.TIPE_Proveedor:
                            _listFilters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@pintENTC_Codigo", FilterValue = Item.ENTC_Codigo, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.Int32, FilterSize = 4 });
                            _listFilters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@psinTIPE_Codigo", FilterValue = tipe_Codigo, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.Int16, FilterSize = 2 });
                            Item.ListEntidadLimiteCreditosProveedor = Client.GetAllEntidadLimiteCreditoFilter("CAJ_ENLISS_TodosPorProveedor", _listFilters);
                            MView.ShowLimiteCreditoProveedor();

                            _listFilters = new ObservableCollection<Infrastructure.Aspect.DataAccess.DataAccessFilterSQL>();
                            _listFilters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@pintENTC_Codigo", FilterValue = Item.ENTC_Codigo, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.Int32, FilterSize = 4 });
                            Item.ListEntidadCuentaBancarias = Client.GetAllEntidadCuentaBancariaFilter("CAJ_ENCBSS_TodosPorProveedor", _listFilters);
                            if (Item.ListEntidadCuentaBancarias == null) { Item.ListEntidadCuentaBancarias = new ObservableCollection<EntidadCuentaBancaria>(); }
                            MView.ShowEntidadCuentaBancaria();

                            break;
                    }

                    MView.SetItem();
                    if (tipe_Codigo == EntidadClear.TIPE_Transportista)
                    {
                        ItemsDepTemporalEntidad = Client.GetAllEntidadRelacionadosByCliente(Item.ENTC_Codigo, "DTE");
                        MView.ShowItemsDepTemporal();
                    }
                    else
                    {
                        MView.ShowServicios();
                        MView.ShowRelacionados();
                    }
                    return ((MAN009MView)MView).ShowDialog();
                }
                else
                { Dialogos.MostrarMensajeInformacion(Title, "Debe seleccionar un elemento"); return DialogResult.Cancel; }
            }
            catch (Exception ex)
            { Dialogos.MostrarMensajeError(Title, Mensajes.EditPresenter, ex); return DialogResult.Cancel; }
        }
        public void Eliminar()
        {
            try
            {
                if (Item != null)
                {
                    DialogResult _result = Dialogos.MostrarMensajePregunta(Title, Mensajes.PreguntaEliminar, Dialogos.LabelBoton.Si_No);
                    if (_result == DialogResult.Yes)
                    {
                        Item.Instance = InstanceEntity.Deleted;
                        Entidad x_Item = Client.SaveEntidad(Item);
                        if (x_Item == null)
                        {
                            Actualizar();
                            Dialogos.MostrarMensajeSatisfactorio(Title, "Se ha eliminado el item.");
                        }
                        else
                        { Dialogos.MostrarMensajeInformacion(Title, "Ha ocurrido un error al guardar el item."); }
                    }
                }
                else
                { Dialogos.MostrarMensajeInformacion(Title, "Debe seleccionar un elemento de la grilla"); }
            }
            catch (Exception ex)
            { Dialogos.MostrarMensajeError(Title, Mensajes.DeletePresenter, ex); }
        }
        public bool Guardar()
        {
            try
            {
                MView.GetItem();
                if (Item.Validar() && ValidarEmail() && ValidarDirecciones())
                {
                    Entidad _duplicado = Client.GetOneEntidadValidarDocIden(Item.ENTC_Codigo, Item.TIPO_TabTDI, Item.TIPO_CodTDI, Item.ENTC_DocIden);
                    if (_duplicado != null)
                    {
                        Dialogos.MostrarMensajeInformacion(Title, "Existe un registro con los mismo Documento y Número de Identidad(" + _duplicado.ENTC_NomCompleto + ").");
                        return false;
                    }
                    Item.ItemsDepTemporalEntidad = new ObservableCollection<Entidad_Relacionados>();
                    Item.ItemsDepTemporalEntidad = ItemsDepTemporalEntidad;
                    Item = Client.SaveEntidad(Item);
                    //Client.ClientCredentials= enviar u objeto con las credenciales
                    if (Item != null)
                    {
                        //Extranet
                        if (REGI_Codigo != 0)
                        {
                            EntidadRegistro_BE oCustomerRegister = new EntidadRegistro_BE
                            {
                                REGI_Codigo = REGI_Codigo,
                                ENTC_Codigo = Item.ENTC_Codigo,
                                REGI_Estado = "I",
                                AUDI_UsrMod = Item.AUDI_UsrCrea,
                                AUDI_FecMod = DateTime.Now
                            };
                            oOnLineService.StatusUpdateCustomerRegister(oCustomerRegister);
                        }

                        Dialogos.MostrarMensajeSatisfactorio(Title, "Se ha guardado satisfactoriamente");
                        if (lsinlview == false)
                        { Actualizar(false); }
                        return true;
                    }
                    else
                    {
                        Dialogos.MostrarMensajeInformacion(Title, "Ha ocurrido un error al guardar el" + tipe_Desc);
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
                Dialogos.MostrarMensajeError(Title, Mensajes.SavePresenter, ex);
                return false;
            }
        }

        public DialogResult GuardarCambios()
        {
            try
            {
                if (Item != null)
                {
                    DialogResult _result = Dialogos.MostrarMensajePregunta(Title, Mensajes.SaveChangesPreguntaPresenter, Dialogos.LabelBoton.Si_No);
                    if (_result == DialogResult.Yes)
                    {
                        if (Guardar())
                        { return DialogResult.Yes; }
                        else
                        { return DialogResult.Cancel; }
                    }
                    else
                    { return _result; }
                }
                else
                {
                    Dialogos.MostrarMensajeInformacion(Title, "Ha ocurrido un error al cerrar el formulario.");
                    return DialogResult.Cancel;
                }
            }
            catch (Exception ex)
            {
                Dialogos.MostrarMensajeError(Title, Mensajes.SavePresenter, ex);
                return DialogResult.Cancel;
            }
        }
        public void ValidarDocIdentidad(Tipos ItemTipoTDI, String ENTC_DocIden)
        {
            try
            {
                Entidad existe = Client.GetOneEntidadValidarDocIden(Item.ENTC_Codigo, ItemTipoTDI.TIPO_CodTabla, ItemTipoTDI.TIPO_CodTipo, ENTC_DocIden);
                if (existe != null)
                {
                    if (Dialogos.MostrarMensajePregunta(Title, "Existe un registro con los mismo Documneto y Número de Identidad(" + existe.ENTC_NomCompleto + ").\n ¿Desea cargarlo para editarlo?.", Dialogos.LabelBoton.Si_No) == DialogResult.Yes)
                    {
                        Item = null;
                        Item = existe;
                        MView.ClearItem();
                        Item.AUDI_UsrMod = Session.UserName;
                        Item.AUDI_FecMod = Session.Fecha;
                        Item.Instance = InstanceEntity.Modified;
                        if (tipe_Codigo == EntidadClear.TIPE_Cliente)
                        { Item.ListServicio = Client.GetAllEntidad_Servicio(Item.ENTC_Codigo); }

                        //buscamos si tiene contacto
                        //Items = Client.GetAllEntidad(tipe_Codigo.ToString());
                        // solo buscamos la entidad con todos sus hijos si es cliente
                        if (tipe_Codigo == EntidadClear.TIPE_Cliente || tipe_Codigo == EntidadClear.TIPE_Broker)
                        {
                            Item = Client.GetOneEntidad(Item.ENTC_Codigo, null);
                            Item.AUDI_UsrMod = Session.UserName;
                            Item.AUDI_FecMod = Session.Fecha;
                            Item.Instance = InstanceEntity.Modified;
                        } //buscamos los contactos del cliente  
                        MView.SetItem();
                        if (tipe_Codigo == EntidadClear.TIPE_Transportista)
                        {
                            ItemsDepTemporalEntidad = Client.GetAllEntidadRelacionadosByCliente(Item.ENTC_Codigo, "DTE");
                            MView.ShowItemsDepTemporal();
                        }
                        else
                        {
                            MView.ShowServicios();
                        }
                    }
                }
            }
            catch (Exception ex)
            { Dialogos.MostrarMensajeError(Title, "Ha ocurrido un erro al validar el Documento de Identidad.", ex); }
        }
        public bool ValidarEmail()
        {
            try
            {
                bool l_correcto = true;
                bool l_email1OK = true;
                bool l_email2OK = true;
                bool l_email3OK = true;
                char[] delimiterChars = { ';' };
                string[] m_itemsDestino = null;

                Item.ENTC_EMailMSGERROR = string.Empty;
                if (!string.IsNullOrEmpty(Item.ENTC_EMail))
                {
                    m_itemsDestino = Item.ENTC_EMail.Split(delimiterChars);
                    if (m_itemsDestino != null && m_itemsDestino.Length != 0)
                    {
                        foreach (string _correo in m_itemsDestino)
                        {
                            if (!string.IsNullOrEmpty(_correo.Trim()))
                            {
                                //if (!Delfin.Controls.Utils.checkMailFormat(_correo.Trim()))
                                if (!IsValidEmail(_correo.Trim()))
                                { l_email1OK = false; }
                            }
                        }
                    }
                    if (!l_email1OK)
                    { Item.ENTC_EMailMSGERROR = "El Formato del Correo es Incorrecto"; }
                }

                Item.ENTC_EMail2MSGERROR = string.Empty;
                if (!string.IsNullOrEmpty(Item.ENTC_EMail2))
                {
                    m_itemsDestino = Item.ENTC_EMail2.Split(delimiterChars);
                    if (m_itemsDestino != null && m_itemsDestino.Length != 0)
                    {
                        foreach (string _correo in m_itemsDestino)
                        {
                            if (!string.IsNullOrEmpty(_correo.Trim()))
                            {
                                //if (!Delfin.Controls.Utils.checkMailFormat(_correo.Trim()))
                                if (!IsValidEmail(_correo.Trim()))
                                { l_email2OK = false; }
                            }
                        }
                    }
                    if (!l_email2OK)
                    { Item.ENTC_EMail2MSGERROR = "El Formato del Correo es Incorrecto"; }
                }

                //Item.ENTC_EMail3MSGERROR = string.Empty;
                if (!string.IsNullOrEmpty(Item.ENTC_EmailReceptorFE))
                {
                    m_itemsDestino = Item.ENTC_EmailReceptorFE.Split(delimiterChars);
                    if (m_itemsDestino != null && m_itemsDestino.Length != 0)
                    {
                        foreach (string _correo in m_itemsDestino)
                        {
                            if (!string.IsNullOrEmpty(_correo.Trim()))
                            {
                                //if (!Delfin.Controls.Utils.checkMailFormat(_correo.Trim()))
                                if (!IsValidEmail(_correo.Trim()))
                                { l_email3OK = false; }
                            }
                        }
                    }
                    //if (!l_email3OK)
                    //{ Item.ENTC_EMail2MSGERROR = "El Formato del Correo es Incorrecto"; }
                }

                if (!l_email1OK || !l_email2OK || !l_email3OK)
                {
                    l_correcto = false;
                    Item.MensajeError += "El Formato de alguno de los correos ingresados es incorrecto" + Environment.NewLine;
                }
                else { l_correcto = true; }
                return l_correcto;
            }
            catch (Exception ex)
            { throw ex; }
        }
        public bool IsValidEmail(string email)
        {
            if (email.Trim() == "")
            { return false; }
            //return Regex.IsMatch(email, "^([0-9a-zA-Z]([-\\.\\w]*[0-9a-zA-Z])*[-\\.\\w]*[-\\.\\w]@([0-9a-zA-Z][-\\w]*[0-9a-zA-Z]\\.)+[a-zA-Z]{2,9})$");
            return true;
        }
        public bool ValidarDirecciones()
        {
            try
            {
                bool l_correcto = true;
                bool l_direccionFiscal = true;
                bool l_direccionComercial = true;
                string l_mensaje = string.Empty;
                if (Item.TIPO_TabPaisFiscal != null && Item.TIPO_CodPaisFiscal != null)
                {
                    if (string.IsNullOrEmpty(Item.DIRE_Direccion))
                    { l_direccionFiscal = false; }
                }
                if (Item.TIPO_TabPaisComercial != null && Item.TIPO_CodPaisComercial != null)
                {
                    if (string.IsNullOrEmpty(Item.DIRE_DireccionComercial))
                    { l_direccionComercial = false; }
                }
                if (!l_direccionFiscal || !l_direccionComercial)
                {
                    l_correcto = false;
                    Item.MensajeError += "Debe ingresar una Dirección para poder guardar el registro" + Environment.NewLine;
                }
                else { l_correcto = true; }
                return l_correcto;
            }
            catch (Exception ex)
            { throw ex; }
        }
        #endregion

        #region [ Datos Financieros - Cliente ]

        public Entities.EntidadLimiteCredito NuevoLimiteCreditoCliente(Entities.EntidadLimiteCredito LimCredCliente)
        {
            try
            {
                DViewCLCliente = new MAN009DViewLCredito(MAN009DViewLCredito.TLCredito.Cliente, MAN009DViewLCredito.TOpcion.Nuevo);
                DViewCLCliente.Presenter = this;
                DViewCLCliente.Item = LimCredCliente;
                DViewCLCliente.LoadView();
                if (DViewCLCliente.ShowDialog() == DialogResult.OK)
                {
                    return DViewCLCliente.Item;
                }
                return null;
            }
            catch (Exception)
            { throw; }
        }

        public Entities.EntidadLimiteCredito EditarLimiteCreditoCliente(Entities.EntidadLimiteCredito LimCredCliente)
        {
            try
            {
                DViewCLCliente = new MAN009DViewLCredito(MAN009DViewLCredito.TLCredito.Cliente, MAN009DViewLCredito.TOpcion.Editar);
                DViewCLCliente.Presenter = this;
                DViewCLCliente.Item = LimCredCliente;
                DViewCLCliente.LoadView();
                if (DViewCLCliente.ShowDialog() == DialogResult.OK)
                {
                    return DViewCLCliente.Item;
                }
                return null;
            }
            catch (Exception)
            { throw; }
        }

        public void HistorialLimiteCreditoCliente(Entities.EntidadLimiteCredito LimCredCliente)
        {
            try
            {
                ObservableCollection<Infrastructure.Aspect.DataAccess.DataAccessFilterSQL> _listFilters = new ObservableCollection<Infrastructure.Aspect.DataAccess.DataAccessFilterSQL>();
                _listFilters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@pintENTC_Codigo", FilterValue = Item.ENTC_Codigo, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.Int32, FilterSize = 4 });
                _listFilters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@psinTIPE_Codigo", FilterValue = Item.TIPE_Codigo, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.Int16, FilterSize = 2 });
                _listFilters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@pchrENLI_Tipos", FilterValue = LimCredCliente.ENLI_Tipos, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.Varchar, FilterSize = 3 });
                ObservableCollection<Entities.EntidadLimiteCredito> x_ListEntidadLimiteCreditos = Client.GetAllEntidadLimiteCreditoFilter("CAJ_ENLISS_TodosHistorialCliente", _listFilters);
                if (x_ListEntidadLimiteCreditos != null && x_ListEntidadLimiteCreditos.Count > 0)
                {
                    VViewHistorial = new MAN009VViewHistorial(MAN009DViewLCredito.TLCredito.Cliente, x_ListEntidadLimiteCreditos, String.Format("Entidad: {1} / Tipo: {0}", LimCredCliente.ENLI_TiposDescripcion, Item.ENTC_NomCompleto));
                    VViewHistorial.StartPosition = FormStartPosition.CenterScreen;
                    VViewHistorial.ShowDialog();
                }
                else { Dialogos.MostrarMensajeInformacion(Title, "No existen elementos que mostrar"); }
            }
            catch (Exception)
            { throw; }
        }

        #endregion

        #region [ Datos Financieros - Proveedor ]

        #region Limite de Credito

        public Entities.EntidadLimiteCredito NuevoLimiteCreditoProveedor(Entities.EntidadLimiteCredito LimCredProveedor)
        {
            try
            {
                DViewCLCliente = new MAN009DViewLCredito(MAN009DViewLCredito.TLCredito.Proveedor, MAN009DViewLCredito.TOpcion.Nuevo);
                DViewCLCliente.Presenter = this;
                DViewCLCliente.Item = LimCredProveedor;
                DViewCLCliente.Item.TIPE_Codigo = Item.TIPE_Codigo;
                DViewCLCliente.LoadView();
                if (DViewCLCliente.ShowDialog() == DialogResult.OK)
                {
                    return DViewCLCliente.Item;
                }
                return null;
            }
            catch (Exception)
            { throw; }
        }

        public Entities.EntidadLimiteCredito EditarLimiteCreditoProveedor(Entities.EntidadLimiteCredito LimCredProveedor)
        {
            try
            {
                DViewCLCliente = new MAN009DViewLCredito(MAN009DViewLCredito.TLCredito.Proveedor, MAN009DViewLCredito.TOpcion.Editar);
                DViewCLCliente.Presenter = this;
                DViewCLCliente.Item = LimCredProveedor;
                DViewCLCliente.LoadView();
                if (DViewCLCliente.ShowDialog() == DialogResult.OK)
                {
                    return DViewCLCliente.Item;
                }
                return null;
            }
            catch (Exception)
            { throw; }
        }

        public void HistorialLimiteCreditoProveedor(Entities.EntidadLimiteCredito LimCredito)
        {
            try
            {
                ObservableCollection<Infrastructure.Aspect.DataAccess.DataAccessFilterSQL> _listFilters = new ObservableCollection<Infrastructure.Aspect.DataAccess.DataAccessFilterSQL>();
                _listFilters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@pintENTC_Codigo", FilterValue = Item.ENTC_Codigo, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.Int32, FilterSize = 4 });
                _listFilters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@psinTIPE_Codigo", FilterValue = Item.TIPE_Codigo, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.Int16, FilterSize = 2 });
                _listFilters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@pchrTIPO_TabMND", FilterValue = LimCredito.TIPO_TabMND, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.Varchar, FilterSize = 3 });
                _listFilters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@pchrTIPO_CodMND", FilterValue = LimCredito.TIPO_CodMND, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.Varchar, FilterSize = 3 });

                ObservableCollection<Entities.EntidadLimiteCredito> x_ListEntidadLimiteCreditos = Client.GetAllEntidadLimiteCreditoFilter("CAJ_ENLISS_TodosHistorialProveedor", _listFilters);
                if (x_ListEntidadLimiteCreditos != null && x_ListEntidadLimiteCreditos.Count > 0)
                {
                    VViewHistorial = new MAN009VViewHistorial(MAN009DViewLCredito.TLCredito.Proveedor, x_ListEntidadLimiteCreditos, String.Format("Entidad: {1} / Tipo: {0}", LimCredito.ENLI_TiposDescripcion, Item.ENTC_NomCompleto));
                    VViewHistorial.StartPosition = FormStartPosition.CenterScreen;
                    VViewHistorial.ShowDialog();
                }
                else { Dialogos.MostrarMensajeInformacion(Title, "No existen elementos que mostrar"); }
            }
            catch (Exception)
            { throw; }
        }

        #endregion

        #region Cuentas Bancarias

        public Boolean NuevoEntidadCuentaBancaria()
        {
            try
            {
                DViewCtasBancarias = new MAN009DViewCtasBancarias(MAN009DViewCtasBancarias.TRegistro.Nuevo);
                DViewCtasBancarias.Presenter = this;
                DViewCtasBancarias.LoadView();
                if (DViewCtasBancarias.ShowDialog() == DialogResult.OK)
                {
                    Item.ListEntidadCuentaBancarias.Add(DViewCtasBancarias.Item);
                    MView.ShowEntidadCuentaBancaria();
                    return true;
                }
                return false;
            }
            catch (Exception)
            { throw; }
        }

        public Entities.EntidadCuentaBancaria EditarEntidadCuentaBancaria(Entities.EntidadCuentaBancaria x_ECBancaria)
        {
            try
            {
                DViewCtasBancarias = new MAN009DViewCtasBancarias(MAN009DViewCtasBancarias.TRegistro.Editar);
                DViewCtasBancarias.Presenter = this;
                DViewCtasBancarias.Item = x_ECBancaria;
                DViewCtasBancarias.LoadView();
                if (DViewCtasBancarias.ShowDialog() == DialogResult.OK)
                {
                    return DViewCtasBancarias.Item;
                }
                return null;
            }
            catch (Exception)
            { throw; }
        }

        public void EliminarEntidadCuentaBancaria(Entities.EntidadCuentaBancaria x_ECBancaria)
        {
            try
            {
                if (
                   Infrastructure.WinForms.Controls.Dialogos.MostrarMensajePregunta(Title,
                      "¿Desea eliminar el registro seleccionado?", Infrastructure.WinForms.Controls.Dialogos.LabelBoton.Si_No) ==
                   System.Windows.Forms.DialogResult.Yes)
                {
                    if (Item.ListEntidadCuentaBancariasEliminados == null) { Item.ListEntidadCuentaBancariasEliminados = new ObservableCollection<EntidadCuentaBancaria>(); }
                    Item.ListEntidadCuentaBancariasEliminados.Add(x_ECBancaria);
                    Item.ListEntidadCuentaBancarias.Remove(x_ECBancaria);
                    MView.ShowEntidadCuentaBancaria();
                    Dialogos.MostrarMensajeSatisfactorio(Title, "Eliminado Satisfactoriamente");
                }
            }
            catch (Exception)
            { throw; }
        }

        #endregion

        #endregion

        #region [ Relacionados ]

        public void AgregarRelacionado()
        {
            try
            {
                RView = new MAN009RView(MAN009RView.TRelacionado.Nuevo, Item.TIPE_Codigo);
                RView.Presenter = this;
                RView.LoadView();
                if (RView.ShowDialog() == DialogResult.OK)
                {
                    MView.ShowRelacionados();
                }
            }
            catch (Exception)
            { throw; }
        }

        public Entidad EditarRelacionado(Entidad x_erelacionado)
        {
            try
            {
                RView = new MAN009RView(MAN009RView.TRelacionado.Editar, Item.TIPE_Codigo);
                RView.Presenter = this;
                RView.Entidad = x_erelacionado;
                RView.Item = x_erelacionado.Relacionado;
                RView.LoadView();
                if (RView.ShowDialog() == DialogResult.OK)
                {
                    return RView.Entidad;
                }
                return null;
            }
            catch (Exception)
            { throw; }
        }

        public void QuitarRelacionado(Entities.Entidad x_erelacionado)
        {
            try
            {
                if (Item.RelacionadosEliminados == null) { Item.RelacionadosEliminados = new ObservableCollection<Entidad>(); }
                Item.RelacionadosEliminados.Add(x_erelacionado);
            }
            catch (Exception)
            { throw; }
        }

        #endregion

        #region [ Servicio ]
        public void AgregarServicio()
        {
            try
            {
                SView = new MAN009SView(MAN009SView.TServicio.Nuevo, Item.TIPE_Codigo);
                SView.Presenter = this;
                SView.LoadView();
                if (SView.ShowDialog() == DialogResult.OK)
                {
                    MView.ShowServicios();
                }
            }
            catch (Exception ex)
            { throw ex; }
        }
        public Entidad_Servicio EditarServicio(Entidad_Servicio x_eservicio)
        {
            try
            {
                SView = new MAN009SView(MAN009SView.TServicio.Editar, Item.TIPE_Codigo);
                SView.Presenter = this;
                SView.Servicio = x_eservicio;
                SView.Item = x_eservicio;
                SView.LoadView();
                if (SView.ShowDialog() == DialogResult.OK)
                {
                    return SView.Servicio;
                }
                return null;
            }
            catch (Exception)
            { throw; }
        }
        public void QuitarServicio(Entities.Entidad_Servicio x_eservicio)
        {
            try
            {
                if (Item.ListServicioDeleted == null) { Item.ListServicioDeleted = new ObservableCollection<Entidad_Servicio>(); }
                Item.ListServicioDeleted.Add(x_eservicio);
            }
            catch (Exception)
            { throw; }
        }
        public void BuscarServicio(Int32 SERV_Codigo)
        {
            ServicioEntidad = Client.GetOneServicio(SERV_Codigo);
        }
        #endregion

        #region [ Deposito Temporal ]

        #endregion

        #endregion
    }
}
