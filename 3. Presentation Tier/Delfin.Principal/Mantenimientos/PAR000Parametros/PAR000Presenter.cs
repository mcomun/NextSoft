using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.Unity;
using Delfin.ServiceContracts;
using Delfin.ServiceProxy;
using Delfin.Entities;
using Infrastructure.Client.Services.Session;
using Infrastructure.Aspect.Collections;
using System.Collections.ObjectModel;

namespace Delfin.Principal
{
    public class PAR000Presenter
    {
        #region [ Variables ]
        public String Title = "Mantenimiento de Parámetros";
        public String CUS = "PAR000";
        #endregion

        #region [ Constructor ]
        public PAR000Presenter(IUnityContainer x_container, IPAR000MView x_mview)
        {
            try
            {
                this.ContainerService = x_container;
                Session = this.ContainerService.Resolve<ISessionService>();
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


                ListResultGestion = Client.GetAllResultGestion();

                var BL_Usuarios = ContainerService.Resolve<NextAdmin.BusinessLogic.IBLUsuarios>();

                ListUsuarios = BL_Usuarios.GetAll();
                ListTiposEntidad = Client.GetAllTiposEntidad_Relacionados();
                ListTiposDocumentos = Client.GetAllTiposByTipoCodTabla("TDO");
                ListPaquetes = Client.GetAllPaquete();

                ObservableCollection<Infrastructure.Aspect.DataAccess.DataAccessFilterSQL> _listFilters = new ObservableCollection<Infrastructure.Aspect.DataAccess.DataAccessFilterSQL>();
                _listFilters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@TIPO_CodTabla", FilterValue = Session.EmpresaCodigo, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.Int32, FilterSize = 4 });

                ListTiposDocumentosContabilidad = Client.GetAllTiposFilter("TIPOSS_TodosAyudaContabilidad", _listFilters);

                MView.LoadView();
            }
            catch (Exception ex)
            { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Title, "Ha ocurrido un error inicializando la vista.", ex); }
        }
        #endregion

        #region [ Propiedades ]
        public IUnityContainer ContainerService { get; set; }
        public ISessionService Session { get; set; }
        public IDelfinServices Client { get; set; }
        public IPAR000MView MView { get; set; }
        ObservableCollection<Parametros> _Items;
        public ObservableCollection<Parametros> Items
        {
            get
            {
                if (_Items == null) { _Items = new ObservableCollection<Parametros>(); }
                return _Items;
            }
            set { _Items = value; }
        }
        public ObservableCollection<ResultGestion> ListResultGestion { get; set; }
        public ObservableCollection<NextAdmin.BusinessLogic.Usuarios> ListUsuarios { get; set; }
        public ObservableCollection<TiposEntidad> ListTiposEntidad { get; set; }
        public ObservableCollection<Tipos> ListTiposDocumentos { get; set; }
        public ObservableCollection<Tipos> ListTiposDocumentosContabilidad { get; set; }
        public ObservableCollection<Paquete> ListPaquetes { get; set; }

        public ObservableCollection<Tipos> getAllTipos(String TIPO_CodTipo)
        {
            try
            {
                return Client.GetAllTiposByTipoCodTabla(TIPO_CodTipo);
            }
            catch (Exception)
            { throw; }
        }


        #region [ KPI ]
        public Parametros KPI001MIN
        {
            get
            {
                String PARA_Clave = "KPI001MIN";
                String PARA_Desc = "KPI001MIN Prospectos";
                if (Items.Where(param => param.PARA_Clave == PARA_Clave).FirstOrDefault() == null)
                {
                    Parametros _item = new Parametros();
                    _item.EMPR_Codigo = Delfin.Controls.Entorno.ItemEmpresa.EMPR_Codigo;
                    _item.SUCR_Codigo = Delfin.Controls.Entorno.ItemSucursal.SUCR_Codigo;
                    _item.PARA_Desc = PARA_Desc;
                    _item.PARA_Clave = PARA_Clave;
                    _item.Instance = Infrastructure.Aspect.BusinessEntity.InstanceEntity.Added;
                    _item.AUDI_UsrCrea = Session.UserName;
                    _item.AUDI_FecCrea = Session.Fecha;
                    Items.Add(_item);
                }
                return Items.Where(param => param.PARA_Clave == PARA_Clave).FirstOrDefault();
            }
        }
        public Parametros KPI001MAX
        {
            get
            {
                String PARA_Clave = "KPI001MAX";
                String PARA_Desc = "KPI001MAX Prospectos";
                if (Items.Where(param => param.PARA_Clave == PARA_Clave).FirstOrDefault() == null)
                {
                    Parametros _item = new Parametros();
                    _item.EMPR_Codigo = Delfin.Controls.Entorno.ItemEmpresa.EMPR_Codigo;
                    _item.SUCR_Codigo = Delfin.Controls.Entorno.ItemSucursal.SUCR_Codigo;
                    _item.PARA_Desc = PARA_Desc;
                    _item.PARA_Clave = PARA_Clave;
                    _item.Instance = Infrastructure.Aspect.BusinessEntity.InstanceEntity.Added;
                    _item.AUDI_UsrCrea = Session.UserName;
                    _item.AUDI_FecCrea = Session.Fecha;
                    Items.Add(_item);
                }
                return Items.Where(param => param.PARA_Clave == PARA_Clave).FirstOrDefault();
            }
        }

        public Parametros KPI002MIN
        {
            get
            {
                String PARA_Clave = "KPI002MIN";
                String PARA_Desc = "KPI002MIN # Reuniones";
                if (Items.Where(param => param.PARA_Clave == PARA_Clave).FirstOrDefault() == null)
                {
                    Parametros _item = new Parametros();
                    _item.EMPR_Codigo = Delfin.Controls.Entorno.ItemEmpresa.EMPR_Codigo;
                    _item.SUCR_Codigo = Delfin.Controls.Entorno.ItemSucursal.SUCR_Codigo;
                    _item.PARA_Desc = PARA_Desc;
                    _item.PARA_Clave = PARA_Clave;
                    _item.Instance = Infrastructure.Aspect.BusinessEntity.InstanceEntity.Added;
                    _item.AUDI_UsrCrea = Session.UserName;
                    _item.AUDI_FecCrea = Session.Fecha;
                    Items.Add(_item);
                }
                return Items.Where(param => param.PARA_Clave == PARA_Clave).FirstOrDefault();
            }
        }
        public Parametros KPI002MAX
        {
            get
            {
                String PARA_Clave = "KPI002MAX";
                String PARA_Desc = "KPI002MAX # Reuniones";
                if (Items.Where(param => param.PARA_Clave == PARA_Clave).FirstOrDefault() == null)
                {
                    Parametros _item = new Parametros();
                    _item.EMPR_Codigo = Delfin.Controls.Entorno.ItemEmpresa.EMPR_Codigo;
                    _item.SUCR_Codigo = Delfin.Controls.Entorno.ItemSucursal.SUCR_Codigo;
                    _item.PARA_Desc = PARA_Desc;
                    _item.PARA_Clave = PARA_Clave;
                    _item.Instance = Infrastructure.Aspect.BusinessEntity.InstanceEntity.Added;
                    _item.AUDI_UsrCrea = Session.UserName;
                    _item.AUDI_FecCrea = Session.Fecha;
                    Items.Add(_item);
                }
                return Items.Where(param => param.PARA_Clave == PARA_Clave).FirstOrDefault();
            }
        }
        public Parametros KPI002RESG
        {
            get
            {
                String PARA_Clave = "KPI002RESG";
                String PARA_Desc = "KPI002 Resultado de Gestion Reunion";
                if (Items.Where(param => param.PARA_Clave == PARA_Clave).FirstOrDefault() == null)
                {
                    Parametros _item = new Parametros();
                    _item.EMPR_Codigo = Delfin.Controls.Entorno.ItemEmpresa.EMPR_Codigo;
                    _item.SUCR_Codigo = Delfin.Controls.Entorno.ItemSucursal.SUCR_Codigo;
                    _item.PARA_Desc = PARA_Desc;
                    _item.PARA_Clave = PARA_Clave;
                    _item.Instance = Infrastructure.Aspect.BusinessEntity.InstanceEntity.Added;
                    _item.AUDI_UsrCrea = Session.UserName;
                    _item.AUDI_FecCrea = Session.Fecha;
                    Items.Add(_item);
                }
                return Items.Where(param => param.PARA_Clave == PARA_Clave).FirstOrDefault();
            }
        }

        public Parametros KPI003MIN
        {
            get
            {
                String PARA_Clave = "KPI003MIN";
                String PARA_Desc = "KPI003MIN # TEUS";
                if (Items.Where(param => param.PARA_Clave == PARA_Clave).FirstOrDefault() == null)
                {
                    Parametros _item = new Parametros();
                    _item.EMPR_Codigo = Delfin.Controls.Entorno.ItemEmpresa.EMPR_Codigo;
                    _item.SUCR_Codigo = Delfin.Controls.Entorno.ItemSucursal.SUCR_Codigo;
                    _item.PARA_Desc = PARA_Desc;
                    _item.PARA_Clave = PARA_Clave;
                    _item.Instance = Infrastructure.Aspect.BusinessEntity.InstanceEntity.Added;
                    _item.AUDI_UsrCrea = Session.UserName;
                    _item.AUDI_FecCrea = Session.Fecha;
                    Items.Add(_item);
                }
                return Items.Where(param => param.PARA_Clave == PARA_Clave).FirstOrDefault();
            }
        }
        public Parametros KPI003MAX
        {
            get
            {
                String PARA_Clave = "KPI003MAX";
                String PARA_Desc = "KPI003MAX # TEUS";
                if (Items.Where(param => param.PARA_Clave == PARA_Clave).FirstOrDefault() == null)
                {
                    Parametros _item = new Parametros();
                    _item.EMPR_Codigo = Delfin.Controls.Entorno.ItemEmpresa.EMPR_Codigo;
                    _item.SUCR_Codigo = Delfin.Controls.Entorno.ItemSucursal.SUCR_Codigo;
                    _item.PARA_Desc = PARA_Desc;
                    _item.PARA_Clave = PARA_Clave;
                    _item.Instance = Infrastructure.Aspect.BusinessEntity.InstanceEntity.Added;
                    _item.AUDI_UsrCrea = Session.UserName;
                    _item.AUDI_FecCrea = Session.Fecha;
                    Items.Add(_item);
                }
                return Items.Where(param => param.PARA_Clave == PARA_Clave).FirstOrDefault();
            }
        }

        public Parametros KPI004MIN
        {
            get
            {
                String PARA_Clave = "KPI004MIN";
                String PARA_Desc = "KPI004MIN # OV Cerradas";
                if (Items.Where(param => param.PARA_Clave == PARA_Clave).FirstOrDefault() == null)
                {
                    Parametros _item = new Parametros();
                    _item.EMPR_Codigo = Delfin.Controls.Entorno.ItemEmpresa.EMPR_Codigo;
                    _item.SUCR_Codigo = Delfin.Controls.Entorno.ItemSucursal.SUCR_Codigo;
                    _item.PARA_Desc = PARA_Desc;
                    _item.PARA_Clave = PARA_Clave;
                    _item.Instance = Infrastructure.Aspect.BusinessEntity.InstanceEntity.Added;
                    _item.AUDI_UsrCrea = Session.UserName;
                    _item.AUDI_FecCrea = Session.Fecha;
                    Items.Add(_item);
                }
                return Items.Where(param => param.PARA_Clave == PARA_Clave).FirstOrDefault();
            }
        }
        public Parametros KPI004MAX
        {
            get
            {
                String PARA_Clave = "KPI004MAX";
                String PARA_Desc = "KPI004MAX # OV Cerradas";
                if (Items.Where(param => param.PARA_Clave == PARA_Clave).FirstOrDefault() == null)
                {
                    Parametros _item = new Parametros();
                    _item.EMPR_Codigo = Delfin.Controls.Entorno.ItemEmpresa.EMPR_Codigo;
                    _item.SUCR_Codigo = Delfin.Controls.Entorno.ItemSucursal.SUCR_Codigo;
                    _item.PARA_Desc = PARA_Desc;
                    _item.PARA_Clave = PARA_Clave;
                    _item.Instance = Infrastructure.Aspect.BusinessEntity.InstanceEntity.Added;
                    _item.AUDI_UsrCrea = Session.UserName;
                    _item.AUDI_FecCrea = Session.Fecha;
                    Items.Add(_item);
                }
                return Items.Where(param => param.PARA_Clave == PARA_Clave).FirstOrDefault();
            }
        }

        public Parametros KPI005MIN
        {
            get
            {
                String PARA_Clave = "KPI005MIN";
                String PARA_Desc = "KPI005MIN # Ataque";
                if (Items.Where(param => param.PARA_Clave == PARA_Clave).FirstOrDefault() == null)
                {
                    Parametros _item = new Parametros();
                    _item.EMPR_Codigo = Delfin.Controls.Entorno.ItemEmpresa.EMPR_Codigo;
                    _item.SUCR_Codigo = Delfin.Controls.Entorno.ItemSucursal.SUCR_Codigo;
                    _item.PARA_Desc = PARA_Desc;
                    _item.PARA_Clave = PARA_Clave;
                    _item.Instance = Infrastructure.Aspect.BusinessEntity.InstanceEntity.Added;
                    _item.AUDI_UsrCrea = Session.UserName;
                    _item.AUDI_FecCrea = Session.Fecha;
                    Items.Add(_item);
                }
                return Items.Where(param => param.PARA_Clave == PARA_Clave).FirstOrDefault();
            }
        }
        public Parametros KPI005MAX
        {
            get
            {
                String PARA_Clave = "KPI005MAX";
                String PARA_Desc = "KPI005MAX # Ataque";
                if (Items.Where(param => param.PARA_Clave == PARA_Clave).FirstOrDefault() == null)
                {
                    Parametros _item = new Parametros();
                    _item.EMPR_Codigo = Delfin.Controls.Entorno.ItemEmpresa.EMPR_Codigo;
                    _item.SUCR_Codigo = Delfin.Controls.Entorno.ItemSucursal.SUCR_Codigo;
                    _item.PARA_Desc = PARA_Desc;
                    _item.PARA_Clave = PARA_Clave;
                    _item.Instance = Infrastructure.Aspect.BusinessEntity.InstanceEntity.Added;
                    _item.AUDI_UsrCrea = Session.UserName;
                    _item.AUDI_FecCrea = Session.Fecha;
                    Items.Add(_item);
                }
                return Items.Where(param => param.PARA_Clave == PARA_Clave).FirstOrDefault();
            }
        }
        #endregion

        #region [ USUARIOS APROBACION ]
        public Parametros USRAPRUEBANIVEL1_JV
        {
            get
            {
                String PARA_Clave = "USRAPRUEBANIVEL1_JV";
                String PARA_Desc = "USUARIO APRUEBA NIVEL 1";
                if (Items.Where(param => param.PARA_Clave == PARA_Clave).FirstOrDefault() == null)
                {
                    Parametros _item = new Parametros();
                    _item.EMPR_Codigo = Delfin.Controls.Entorno.ItemEmpresa.EMPR_Codigo;
                    _item.SUCR_Codigo = Delfin.Controls.Entorno.ItemSucursal.SUCR_Codigo;
                    _item.PARA_Desc = PARA_Desc;
                    _item.PARA_Clave = PARA_Clave;
                    _item.Instance = Infrastructure.Aspect.BusinessEntity.InstanceEntity.Added;
                    _item.AUDI_UsrCrea = Session.UserName;
                    _item.AUDI_FecCrea = Session.Fecha;
                    Items.Add(_item);
                }
                return Items.Where(param => param.PARA_Clave == PARA_Clave).FirstOrDefault();
            }
        }
        public Parametros USRAPRUEBANIVEL2_GC
        {
            get
            {
                String PARA_Clave = "USRAPRUEBANIVEL2_GC";
                String PARA_Desc = "USUARIO APRUEBA NIVEL 2";
                if (Items.Where(param => param.PARA_Clave == PARA_Clave).FirstOrDefault() == null)
                {
                    Parametros _item = new Parametros();
                    _item.EMPR_Codigo = Delfin.Controls.Entorno.ItemEmpresa.EMPR_Codigo;
                    _item.SUCR_Codigo = Delfin.Controls.Entorno.ItemSucursal.SUCR_Codigo;
                    _item.PARA_Desc = PARA_Desc;
                    _item.PARA_Clave = PARA_Clave;
                    _item.Instance = Infrastructure.Aspect.BusinessEntity.InstanceEntity.Added;
                    _item.AUDI_UsrCrea = Session.UserName;
                    _item.AUDI_FecCrea = Session.Fecha;
                    Items.Add(_item);
                }
                return Items.Where(param => param.PARA_Clave == PARA_Clave).FirstOrDefault();
            }
        }
        public Parametros USRAPRUEBANIVEL3_GG
        {
            get
            {
                String PARA_Clave = "USRAPRUEBANIVEL3_GG";
                String PARA_Desc = "USUARIO APRUEBA NIVEL 3";
                if (Items.Where(param => param.PARA_Clave == PARA_Clave).FirstOrDefault() == null)
                {
                    Parametros _item = new Parametros();
                    _item.EMPR_Codigo = Delfin.Controls.Entorno.ItemEmpresa.EMPR_Codigo;
                    _item.SUCR_Codigo = Delfin.Controls.Entorno.ItemSucursal.SUCR_Codigo;
                    _item.PARA_Desc = PARA_Desc;
                    _item.PARA_Clave = PARA_Clave;
                    _item.Instance = Infrastructure.Aspect.BusinessEntity.InstanceEntity.Added;
                    _item.AUDI_UsrCrea = Session.UserName;
                    _item.AUDI_FecCrea = Session.Fecha;
                    Items.Add(_item);
                }
                return Items.Where(param => param.PARA_Clave == PARA_Clave).FirstOrDefault();
            }
        }
        #endregion

        #region [ COMISION PROFIT ]
        public Parametros COMIVENDEDOR
        {
            get
            {
                String PARA_Clave = "COMIVENDEDOR";
                String PARA_Desc = "COMISION VENDEDOR";
                if (Items.Where(param => param.PARA_Clave == PARA_Clave).FirstOrDefault() == null)
                {
                    Parametros _item = new Parametros();
                    _item.EMPR_Codigo = Delfin.Controls.Entorno.ItemEmpresa.EMPR_Codigo;
                    _item.SUCR_Codigo = Delfin.Controls.Entorno.ItemSucursal.SUCR_Codigo;
                    _item.PARA_Desc = PARA_Desc;
                    _item.PARA_Clave = PARA_Clave;
                    _item.Instance = Infrastructure.Aspect.BusinessEntity.InstanceEntity.Added;
                    _item.AUDI_UsrCrea = Session.UserName;
                    _item.AUDI_FecCrea = Session.Fecha;
                    Items.Add(_item);
                }
                return Items.Where(param => param.PARA_Clave == PARA_Clave).FirstOrDefault();
            }
        }
        public Parametros PROFITPROMTEUS
        {
            get
            {
                String PARA_Clave = "PROFITPROMTEUS";
                String PARA_Desc = "PROFIT PROMEDIO TEUS";
                if (Items.Where(param => param.PARA_Clave == PARA_Clave).FirstOrDefault() == null)
                {
                    Parametros _item = new Parametros();
                    _item.EMPR_Codigo = Delfin.Controls.Entorno.ItemEmpresa.EMPR_Codigo;
                    _item.SUCR_Codigo = Delfin.Controls.Entorno.ItemSucursal.SUCR_Codigo;
                    _item.PARA_Desc = PARA_Desc;
                    _item.PARA_Clave = PARA_Clave;
                    _item.Instance = Infrastructure.Aspect.BusinessEntity.InstanceEntity.Added;
                    _item.AUDI_UsrCrea = Session.UserName;
                    _item.AUDI_FecCrea = Session.Fecha;
                    Items.Add(_item);
                }
                return Items.Where(param => param.PARA_Clave == PARA_Clave).FirstOrDefault();
            }
        }
        public Parametros PROFITMINTEUS
        {
            get
            {
                String PARA_Clave = "PROFITMINTEUS";
                String PARA_Desc = "PROFIT MINIMO TEUS";
                if (Items.Where(param => param.PARA_Clave == PARA_Clave).FirstOrDefault() == null)
                {
                    Parametros _item = new Parametros();
                    _item.EMPR_Codigo = Delfin.Controls.Entorno.ItemEmpresa.EMPR_Codigo;
                    _item.SUCR_Codigo = Delfin.Controls.Entorno.ItemSucursal.SUCR_Codigo;
                    _item.PARA_Desc = PARA_Desc;
                    _item.PARA_Clave = PARA_Clave;
                    _item.Instance = Infrastructure.Aspect.BusinessEntity.InstanceEntity.Added;
                    _item.AUDI_UsrCrea = Session.UserName;
                    _item.AUDI_FecCrea = Session.Fecha;
                    Items.Add(_item);
                }
                return Items.Where(param => param.PARA_Clave == PARA_Clave).FirstOrDefault();
            }
        }
        #endregion

        #region [ SERVICIOS ]
        public Parametros SERVADICIONAL
        {
            get
            {
                String PARA_Clave = "SERVADICIONAL";
                String PARA_Desc = "SERVICIO ADICIONAL";
                if (Items.Where(param => param.PARA_Clave == PARA_Clave).FirstOrDefault() == null)
                {
                    Parametros _item = new Parametros();
                    _item.EMPR_Codigo = Delfin.Controls.Entorno.ItemEmpresa.EMPR_Codigo;
                    _item.SUCR_Codigo = Delfin.Controls.Entorno.ItemSucursal.SUCR_Codigo;
                    _item.PARA_Desc = PARA_Desc;
                    _item.PARA_Clave = PARA_Clave;
                    _item.Instance = Infrastructure.Aspect.BusinessEntity.InstanceEntity.Added;
                    _item.AUDI_UsrCrea = Session.UserName;
                    _item.AUDI_FecCrea = Session.Fecha;
                    Items.Add(_item);
                }
                return Items.Where(param => param.PARA_Clave == PARA_Clave).FirstOrDefault();
            }
        }
        public Parametros SERVLOGISTICO
        {
            get
            {
                String PARA_Clave = "SERVLOGISTICO";
                String PARA_Desc = "SERVICIO LOGÍSTICO";
                if (Items.Where(param => param.PARA_Clave == PARA_Clave).FirstOrDefault() == null)
                {
                    Parametros _item = new Parametros();
                    _item.EMPR_Codigo = Delfin.Controls.Entorno.ItemEmpresa.EMPR_Codigo;
                    _item.SUCR_Codigo = Delfin.Controls.Entorno.ItemSucursal.SUCR_Codigo;
                    _item.PARA_Desc = PARA_Desc;
                    _item.PARA_Clave = PARA_Clave;
                    _item.Instance = Infrastructure.Aspect.BusinessEntity.InstanceEntity.Added;
                    _item.AUDI_UsrCrea = Session.UserName;
                    _item.AUDI_FecCrea = Session.Fecha;
                    Items.Add(_item);
                }
                return Items.Where(param => param.PARA_Clave == PARA_Clave).FirstOrDefault();
            }
        }
        public Parametros SERVOTROS
        {
            get
            {
                String PARA_Clave = "SERVOTROS";
                String PARA_Desc = "SERVICIO OTROS";
                if (Items.Where(param => param.PARA_Clave == PARA_Clave).FirstOrDefault() == null)
                {
                    Parametros _item = new Parametros();
                    _item.EMPR_Codigo = Delfin.Controls.Entorno.ItemEmpresa.EMPR_Codigo;
                    _item.SUCR_Codigo = Delfin.Controls.Entorno.ItemSucursal.SUCR_Codigo;
                    _item.PARA_Desc = PARA_Desc;
                    _item.PARA_Clave = PARA_Clave;
                    _item.Instance = Infrastructure.Aspect.BusinessEntity.InstanceEntity.Added;
                    _item.AUDI_UsrCrea = Session.UserName;
                    _item.AUDI_FecCrea = Session.Fecha;
                    Items.Add(_item);
                }
                return Items.Where(param => param.PARA_Clave == PARA_Clave).FirstOrDefault();
            }
        }
        public Parametros SERVTARJAS
        {
            get
            {
                String PARA_Clave = "SERVTARJAS";
                String PARA_Desc = "SERVICIO TARJAS";
                if (Items.Where(param => param.PARA_Clave == PARA_Clave).FirstOrDefault() == null)
                {
                    Parametros _item = new Parametros();
                    _item.EMPR_Codigo = Delfin.Controls.Entorno.ItemEmpresa.EMPR_Codigo;
                    _item.SUCR_Codigo = Delfin.Controls.Entorno.ItemSucursal.SUCR_Codigo;
                    _item.PARA_Desc = PARA_Desc;
                    _item.PARA_Clave = PARA_Clave;
                    _item.Instance = Infrastructure.Aspect.BusinessEntity.InstanceEntity.Added;
                    _item.AUDI_UsrCrea = Session.UserName;
                    _item.AUDI_FecCrea = Session.Fecha;
                    Items.Add(_item);
                }
                return Items.Where(param => param.PARA_Clave == PARA_Clave).FirstOrDefault();
            }
        }
        public Parametros SERV_OCULTARSHIPPER
        {
            get
            {
                String PARA_Clave = "SERV_OCULTARSHIPPER";
                String PARA_Desc = "SERVICIO OCULTAR SHIPPER";
                if (Items.Where(param => param.PARA_Clave == PARA_Clave).FirstOrDefault() == null)
                {
                    Parametros _item = new Parametros();
                    _item.EMPR_Codigo = Delfin.Controls.Entorno.ItemEmpresa.EMPR_Codigo;
                    _item.SUCR_Codigo = Delfin.Controls.Entorno.ItemSucursal.SUCR_Codigo;
                    _item.PARA_Desc = PARA_Desc;
                    _item.PARA_Clave = PARA_Clave;
                    _item.Instance = Infrastructure.Aspect.BusinessEntity.InstanceEntity.Added;
                    _item.AUDI_UsrCrea = Session.UserName;
                    _item.AUDI_FecCrea = Session.Fecha;
                    Items.Add(_item);
                }
                return Items.Where(param => param.PARA_Clave == PARA_Clave).FirstOrDefault();
            }
        }
        public Parametros SERVICIO_REEMBOLSO
        {
            get
            {
                String PARA_Clave = "SERVICIO_REEMBOLSO";
                String PARA_Desc = "CODIGO SERVICIO REEMBOLSO";
                if (Items.Where(param => param.PARA_Clave == PARA_Clave).FirstOrDefault() == null)
                {
                    Parametros _item = new Parametros();
                    _item.EMPR_Codigo = Delfin.Controls.Entorno.ItemEmpresa.EMPR_Codigo;
                    _item.SUCR_Codigo = Delfin.Controls.Entorno.ItemSucursal.SUCR_Codigo;
                    _item.PARA_Desc = PARA_Desc;
                    _item.PARA_Clave = PARA_Clave;
                    _item.Instance = Infrastructure.Aspect.BusinessEntity.InstanceEntity.Added;
                    _item.AUDI_UsrCrea = Session.UserName;
                    _item.AUDI_FecCrea = Session.Fecha;
                    Items.Add(_item);
                }
                return Items.Where(param => param.PARA_Clave == PARA_Clave).FirstOrDefault();
            }
        }

        public Parametros SERV_FLETE_GRR
        {
            get
            {
                String PARA_Clave = "SERV_FLETE_GRR";
                String PARA_Desc = "CODIGO SERVICIOS FLETE GRR";
                if (Items.Where(param => param.PARA_Clave == PARA_Clave).FirstOrDefault() == null)
                {
                    Parametros _item = new Parametros();
                    _item.EMPR_Codigo = Delfin.Controls.Entorno.ItemEmpresa.EMPR_Codigo;
                    _item.SUCR_Codigo = Delfin.Controls.Entorno.ItemSucursal.SUCR_Codigo;
                    _item.PARA_Desc = PARA_Desc;
                    _item.PARA_Clave = PARA_Clave;
                    _item.Instance = Infrastructure.Aspect.BusinessEntity.InstanceEntity.Added;
                    _item.AUDI_UsrCrea = Session.UserName;
                    _item.AUDI_FecCrea = Session.Fecha;
                    Items.Add(_item);
                }
                return Items.Where(param => param.PARA_Clave == PARA_Clave).FirstOrDefault();
            }
        }
        #endregion

        #region [ EVENTOS ]
        public Parametros RELEASEHBL
        {
            get
            {
                String PARA_Clave = "RELEASEHBL";
                String PARA_Desc = "RELEASE HBL";
                if (Items.Where(param => param.PARA_Clave == PARA_Clave).FirstOrDefault() == null)
                {
                    Parametros _item = new Parametros();
                    _item.EMPR_Codigo = Delfin.Controls.Entorno.ItemEmpresa.EMPR_Codigo;
                    _item.SUCR_Codigo = Delfin.Controls.Entorno.ItemSucursal.SUCR_Codigo;
                    _item.PARA_Desc = PARA_Desc;
                    _item.PARA_Clave = PARA_Clave;
                    _item.Instance = Infrastructure.Aspect.BusinessEntity.InstanceEntity.Added;
                    _item.AUDI_UsrCrea = Session.UserName;
                    _item.AUDI_FecCrea = Session.Fecha;
                    Items.Add(_item);
                }
                return Items.Where(param => param.PARA_Clave == PARA_Clave).FirstOrDefault();
            }
        }
        public Parametros BLOQUEAROV
        {
            get
            {
                String PARA_Clave = "BLOQUEAROV";
                String PARA_Desc = "BLOQUEAR OV";
                if (Items.Where(param => param.PARA_Clave == PARA_Clave).FirstOrDefault() == null)
                {
                    Parametros _item = new Parametros();
                    _item.EMPR_Codigo = Delfin.Controls.Entorno.ItemEmpresa.EMPR_Codigo;
                    _item.SUCR_Codigo = Delfin.Controls.Entorno.ItemSucursal.SUCR_Codigo;
                    _item.PARA_Desc = PARA_Desc;
                    _item.PARA_Clave = PARA_Clave;
                    _item.Instance = Infrastructure.Aspect.BusinessEntity.InstanceEntity.Added;
                    _item.AUDI_UsrCrea = Session.UserName;
                    _item.AUDI_FecCrea = Session.Fecha;
                    Items.Add(_item);
                }
                return Items.Where(param => param.PARA_Clave == PARA_Clave).FirstOrDefault();
            }
        }
        public Parametros DESBLOQUEAROV
        {
            get
            {
                String PARA_Clave = "DESBLOQUEAROV";
                String PARA_Desc = "DESBLOQUEAR OV";
                if (Items.Where(param => param.PARA_Clave == PARA_Clave).FirstOrDefault() == null)
                {
                    Parametros _item = new Parametros();
                    _item.EMPR_Codigo = Delfin.Controls.Entorno.ItemEmpresa.EMPR_Codigo;
                    _item.SUCR_Codigo = Delfin.Controls.Entorno.ItemSucursal.SUCR_Codigo;
                    _item.PARA_Desc = PARA_Desc;
                    _item.PARA_Clave = PARA_Clave;
                    _item.Instance = Infrastructure.Aspect.BusinessEntity.InstanceEntity.Added;
                    _item.AUDI_UsrCrea = Session.UserName;
                    _item.AUDI_FecCrea = Session.Fecha;
                    Items.Add(_item);
                }
                return Items.Where(param => param.PARA_Clave == PARA_Clave).FirstOrDefault();
            }
        }
        public Parametros AGREGAREXCEPCIONOV
        {
            get
            {
                String PARA_Clave = "AGREGAREXCEPCIONOV";
                String PARA_Desc = "AGREGAR EXCEPCION OV";
                if (Items.Where(param => param.PARA_Clave == PARA_Clave).FirstOrDefault() == null)
                {
                    Parametros _item = new Parametros();
                    _item.EMPR_Codigo = Delfin.Controls.Entorno.ItemEmpresa.EMPR_Codigo;
                    _item.SUCR_Codigo = Delfin.Controls.Entorno.ItemSucursal.SUCR_Codigo;
                    _item.PARA_Desc = PARA_Desc;
                    _item.PARA_Clave = PARA_Clave;
                    _item.Instance = Infrastructure.Aspect.BusinessEntity.InstanceEntity.Added;
                    _item.AUDI_UsrCrea = Session.UserName;
                    _item.AUDI_FecCrea = Session.Fecha;
                    Items.Add(_item);
                }
                return Items.Where(param => param.PARA_Clave == PARA_Clave).FirstOrDefault();
            }
        }
        public Parametros QUITAREXCEPCIONOV
        {
            get
            {
                String PARA_Clave = "QUITAREXCEPCIONOV";
                String PARA_Desc = "QUITAR EXCEPCION OV";
                if (Items.Where(param => param.PARA_Clave == PARA_Clave).FirstOrDefault() == null)
                {
                    Parametros _item = new Parametros();
                    _item.EMPR_Codigo = Delfin.Controls.Entorno.ItemEmpresa.EMPR_Codigo;
                    _item.SUCR_Codigo = Delfin.Controls.Entorno.ItemSucursal.SUCR_Codigo;
                    _item.PARA_Desc = PARA_Desc;
                    _item.PARA_Clave = PARA_Clave;
                    _item.Instance = Infrastructure.Aspect.BusinessEntity.InstanceEntity.Added;
                    _item.AUDI_UsrCrea = Session.UserName;
                    _item.AUDI_FecCrea = Session.Fecha;
                    Items.Add(_item);
                }
                return Items.Where(param => param.PARA_Clave == PARA_Clave).FirstOrDefault();
            }
        }
        public Parametros OVDOCUMENTADA
        {
            get
            {
                String PARA_Clave = "OVDOCUMENTADA";
                String PARA_Desc = "OV DOCUMENTADA";
                if (Items.Where(param => param.PARA_Clave == PARA_Clave).FirstOrDefault() == null)
                {
                    Parametros _item = new Parametros();
                    _item.EMPR_Codigo = Delfin.Controls.Entorno.ItemEmpresa.EMPR_Codigo;
                    _item.SUCR_Codigo = Delfin.Controls.Entorno.ItemSucursal.SUCR_Codigo;
                    _item.PARA_Desc = PARA_Desc;
                    _item.PARA_Clave = PARA_Clave;
                    _item.Instance = Infrastructure.Aspect.BusinessEntity.InstanceEntity.Added;
                    _item.AUDI_UsrCrea = Session.UserName;
                    _item.AUDI_FecCrea = Session.Fecha;
                    Items.Add(_item);
                }
                return Items.Where(param => param.PARA_Clave == PARA_Clave).FirstOrDefault();
            }
        }
        public Parametros DIRECCIONALINEA
        {
            get
            {
                String PARA_Clave = "DIRECCIONALINEA";
                String PARA_Desc = "DIRECCIONAMIENTO DE LINEA";
                if (Items.Where(param => param.PARA_Clave == PARA_Clave).FirstOrDefault() == null)
                {
                    Parametros _item = new Parametros();
                    _item.EMPR_Codigo = Delfin.Controls.Entorno.ItemEmpresa.EMPR_Codigo;
                    _item.SUCR_Codigo = Delfin.Controls.Entorno.ItemSucursal.SUCR_Codigo;
                    _item.PARA_Desc = PARA_Desc;
                    _item.PARA_Clave = PARA_Clave;
                    _item.Instance = Infrastructure.Aspect.BusinessEntity.InstanceEntity.Added;
                    _item.AUDI_UsrCrea = Session.UserName;
                    _item.AUDI_FecCrea = Session.Fecha;
                    Items.Add(_item);
                }
                return Items.Where(param => param.PARA_Clave == PARA_Clave).FirstOrDefault();
            }
        }
        public Parametros EMAILALMACEN
        {
            get
            {
                String PARA_Clave = "EMAILALMACEN";
                String PARA_Desc = "CREACION DEL EMAIL PARA EL ALMACEN POR OV";
                if (Items.Where(param => param.PARA_Clave == PARA_Clave).FirstOrDefault() == null)
                {
                    Parametros _item = new Parametros();
                    _item.EMPR_Codigo = Delfin.Controls.Entorno.ItemEmpresa.EMPR_Codigo;
                    _item.SUCR_Codigo = Delfin.Controls.Entorno.ItemSucursal.SUCR_Codigo;
                    _item.PARA_Desc = PARA_Desc;
                    _item.PARA_Clave = PARA_Clave;
                    _item.Instance = Infrastructure.Aspect.BusinessEntity.InstanceEntity.Added;
                    _item.AUDI_UsrCrea = Session.UserName;
                    _item.AUDI_FecCrea = Session.Fecha;
                    Items.Add(_item);
                }
                return Items.Where(param => param.PARA_Clave == PARA_Clave).FirstOrDefault();
            }
        }
        public Parametros DESGLOSEVoBo
        {
            get
            {
                String PARA_Clave = "DESGLOSEVoBo";
                String PARA_Desc = "GENERACION DE LA CARTA DE DESGLOSE DE VoBo";
                if (Items.Where(param => param.PARA_Clave == PARA_Clave).FirstOrDefault() == null)
                {
                    Parametros _item = new Parametros();
                    _item.EMPR_Codigo = Delfin.Controls.Entorno.ItemEmpresa.EMPR_Codigo;
                    _item.SUCR_Codigo = Delfin.Controls.Entorno.ItemSucursal.SUCR_Codigo;
                    _item.PARA_Desc = PARA_Desc;
                    _item.PARA_Clave = PARA_Clave;
                    _item.Instance = Infrastructure.Aspect.BusinessEntity.InstanceEntity.Added;
                    _item.AUDI_UsrCrea = Session.UserName;
                    _item.AUDI_FecCrea = Session.Fecha;
                    Items.Add(_item);
                }
                return Items.Where(param => param.PARA_Clave == PARA_Clave).FirstOrDefault();
            }
        }
        public Parametros CARTA_AVISOS
        {
            get
            {
                String PARA_Clave = "CARTA_AVISOS";
                String PARA_Desc = "GENERACION DE LA CARTA DE AVISOS(LLEGADA_SALIDA)";
                if (Items.Where(param => param.PARA_Clave == PARA_Clave).FirstOrDefault() == null)
                {
                    Parametros _item = new Parametros();
                    _item.EMPR_Codigo = Delfin.Controls.Entorno.ItemEmpresa.EMPR_Codigo;
                    _item.SUCR_Codigo = Delfin.Controls.Entorno.ItemSucursal.SUCR_Codigo;
                    _item.PARA_Desc = PARA_Desc;
                    _item.PARA_Clave = PARA_Clave;
                    _item.Instance = Infrastructure.Aspect.BusinessEntity.InstanceEntity.Added;
                    _item.AUDI_UsrCrea = Session.UserName;
                    _item.AUDI_FecCrea = Session.Fecha;
                    Items.Add(_item);
                }
                return Items.Where(param => param.PARA_Clave == PARA_Clave).FirstOrDefault();
            }
        }
        public Parametros OVCERRADA
        {
            get
            {
                String PARA_Clave = "OVCERRADA";
                String PARA_Desc = "ESTADO DE LA ORDEN DE VENTA CERRADO";
                if (Items.Where(param => param.PARA_Clave == PARA_Clave).FirstOrDefault() == null)
                {
                    Parametros _item = new Parametros();
                    _item.EMPR_Codigo = Delfin.Controls.Entorno.ItemEmpresa.EMPR_Codigo;
                    _item.SUCR_Codigo = Delfin.Controls.Entorno.ItemSucursal.SUCR_Codigo;
                    _item.PARA_Desc = PARA_Desc;
                    _item.PARA_Clave = PARA_Clave;
                    _item.Instance = Infrastructure.Aspect.BusinessEntity.InstanceEntity.Added;
                    _item.AUDI_UsrCrea = Session.UserName;
                    _item.AUDI_FecCrea = Session.Fecha;
                    Items.Add(_item);
                }
                return Items.Where(param => param.PARA_Clave == PARA_Clave).FirstOrDefault();
            }
        }
        public Parametros APERTURA_STATMENT
        {
            get
            {
                String PARA_Clave = "APERTURA_STATMENT";
                String PARA_Desc = "APERTURA DEL STATMENT UNA VEZ CERRADO";
                if (Items.Where(param => param.PARA_Clave == PARA_Clave).FirstOrDefault() == null)
                {
                    Parametros _item = new Parametros();
                    _item.EMPR_Codigo = Delfin.Controls.Entorno.ItemEmpresa.EMPR_Codigo;
                    _item.SUCR_Codigo = Delfin.Controls.Entorno.ItemSucursal.SUCR_Codigo;
                    _item.PARA_Desc = PARA_Desc;
                    _item.PARA_Clave = PARA_Clave;
                    _item.Instance = Infrastructure.Aspect.BusinessEntity.InstanceEntity.Added;
                    _item.AUDI_UsrCrea = Session.UserName;
                    _item.AUDI_FecCrea = Session.Fecha;
                    Items.Add(_item);
                }
                return Items.Where(param => param.PARA_Clave == PARA_Clave).FirstOrDefault();
            }
        }
        public Parametros IMPRIMIRHBL
        {
            get
            {
                String PARA_Clave = "IMPRIMIRHBL";
                String PARA_Desc = "IMPRIMIR HBL";
                if (Items.Where(param => param.PARA_Clave == PARA_Clave).FirstOrDefault() == null)
                {
                    Parametros _item = new Parametros();
                    _item.EMPR_Codigo = Delfin.Controls.Entorno.ItemEmpresa.EMPR_Codigo;
                    _item.SUCR_Codigo = Delfin.Controls.Entorno.ItemSucursal.SUCR_Codigo;
                    _item.PARA_Desc = PARA_Desc;
                    _item.PARA_Clave = PARA_Clave;
                    _item.Instance = Infrastructure.Aspect.BusinessEntity.InstanceEntity.Added;
                    _item.AUDI_UsrCrea = Session.UserName;
                    _item.AUDI_FecCrea = Session.Fecha;
                    Items.Add(_item);
                }
                return Items.Where(param => param.PARA_Clave == PARA_Clave).FirstOrDefault();
            }
        }
        public Parametros PRE_ALERTA
        {
            get
            {
                String PARA_Clave = "PRE_ALERTA";
                String PARA_Desc = "DOCUMENTACION APROBADA Y COMPLETA (PRE-ALERTA)";
                if (Items.Where(param => param.PARA_Clave == PARA_Clave).FirstOrDefault() == null)
                {
                    Parametros _item = new Parametros();
                    _item.EMPR_Codigo = Delfin.Controls.Entorno.ItemEmpresa.EMPR_Codigo;
                    _item.SUCR_Codigo = Delfin.Controls.Entorno.ItemSucursal.SUCR_Codigo;
                    _item.PARA_Desc = PARA_Desc;
                    _item.PARA_Clave = PARA_Clave;
                    _item.Instance = Infrastructure.Aspect.BusinessEntity.InstanceEntity.Added;
                    _item.AUDI_UsrCrea = Session.UserName;
                    _item.AUDI_FecCrea = Session.Fecha;
                    Items.Add(_item);
                }
                return Items.Where(param => param.PARA_Clave == PARA_Clave).FirstOrDefault();
            }
        }
        public Parametros EVE_PREFACTURAR
        {
            get
            {
                String PARA_Clave = "EVE_PREFACTURAR";
                String PARA_Desc = "EVENTO PRE-FACTURACION";
                if (Items.Where(param => param.PARA_Clave == PARA_Clave).FirstOrDefault() == null)
                {
                    Parametros _item = new Parametros();
                    _item.EMPR_Codigo = Delfin.Controls.Entorno.ItemEmpresa.EMPR_Codigo;
                    _item.SUCR_Codigo = Delfin.Controls.Entorno.ItemSucursal.SUCR_Codigo;
                    _item.PARA_Desc = PARA_Desc;
                    _item.PARA_Clave = PARA_Clave;
                    _item.Instance = Infrastructure.Aspect.BusinessEntity.InstanceEntity.Added;
                    _item.AUDI_UsrCrea = Session.UserName;
                    _item.AUDI_FecCrea = Session.Fecha;
                    Items.Add(_item);
                }
                return Items.Where(param => param.PARA_Clave == PARA_Clave).FirstOrDefault();
            }
        }
        public Parametros EMITIR_STATEMENT
        {
            get
            {
                String PARA_Clave = "EMITIR_STATEMENT";
                String PARA_Desc = "EVENTO EMITIR STATEMENT";
                if (Items.Where(param => param.PARA_Clave == PARA_Clave).FirstOrDefault() == null)
                {
                    Parametros _item = new Parametros();
                    _item.EMPR_Codigo = Delfin.Controls.Entorno.ItemEmpresa.EMPR_Codigo;
                    _item.SUCR_Codigo = Delfin.Controls.Entorno.ItemSucursal.SUCR_Codigo;
                    _item.PARA_Desc = PARA_Desc;
                    _item.PARA_Clave = PARA_Clave;
                    _item.Instance = Infrastructure.Aspect.BusinessEntity.InstanceEntity.Added;
                    _item.AUDI_UsrCrea = Session.UserName;
                    _item.AUDI_FecCrea = Session.Fecha;
                    Items.Add(_item);
                }
                return Items.Where(param => param.PARA_Clave == PARA_Clave).FirstOrDefault();
            }
        }
        public Parametros DEVOLUCION_MASTER
        {
            get
            {
                String PARA_Clave = "DEVOLUCION_MASTER";
                String PARA_Desc = "EVENTO DEVOLUCION MASTER";
                if (Items.Where(param => param.PARA_Clave == PARA_Clave).FirstOrDefault() == null)
                {
                    Parametros _item = new Parametros();
                    _item.EMPR_Codigo = Delfin.Controls.Entorno.ItemEmpresa.EMPR_Codigo;
                    _item.SUCR_Codigo = Delfin.Controls.Entorno.ItemSucursal.SUCR_Codigo;
                    _item.PARA_Desc = PARA_Desc;
                    _item.PARA_Clave = PARA_Clave;
                    _item.Instance = Infrastructure.Aspect.BusinessEntity.InstanceEntity.Added;
                    _item.AUDI_UsrCrea = Session.UserName;
                    _item.AUDI_FecCrea = Session.Fecha;
                    Items.Add(_item);
                }
                return Items.Where(param => param.PARA_Clave == PARA_Clave).FirstOrDefault();
            }
        }
        public Parametros RECOJO_BLs
        {
            get
            {
                String PARA_Clave = "RECOJO_BLs";
                String PARA_Desc = "EVENTO RECOJO BLs";
                if (Items.Where(param => param.PARA_Clave == PARA_Clave).FirstOrDefault() == null)
                {
                    Parametros _item = new Parametros();
                    _item.EMPR_Codigo = Delfin.Controls.Entorno.ItemEmpresa.EMPR_Codigo;
                    _item.SUCR_Codigo = Delfin.Controls.Entorno.ItemSucursal.SUCR_Codigo;
                    _item.PARA_Desc = PARA_Desc;
                    _item.PARA_Clave = PARA_Clave;
                    _item.Instance = Infrastructure.Aspect.BusinessEntity.InstanceEntity.Added;
                    _item.AUDI_UsrCrea = Session.UserName;
                    _item.AUDI_FecCrea = Session.Fecha;
                    Items.Add(_item);
                }
                return Items.Where(param => param.PARA_Clave == PARA_Clave).FirstOrDefault();
            }
        }
        public Parametros SERVICIO_TRANSMISION
        {
            get
            {
                String PARA_Clave = "SERVICIO_TRANSMISION";
                String PARA_Desc = "EVENTO SERVICIO TRANSMISION";
                if (Items.Where(param => param.PARA_Clave == PARA_Clave).FirstOrDefault() == null)
                {
                    Parametros _item = new Parametros();
                    _item.EMPR_Codigo = Delfin.Controls.Entorno.ItemEmpresa.EMPR_Codigo;
                    _item.SUCR_Codigo = Delfin.Controls.Entorno.ItemSucursal.SUCR_Codigo;
                    _item.PARA_Desc = PARA_Desc;
                    _item.PARA_Clave = PARA_Clave;
                    _item.Instance = Infrastructure.Aspect.BusinessEntity.InstanceEntity.Added;
                    _item.AUDI_UsrCrea = Session.UserName;
                    _item.AUDI_FecCrea = Session.Fecha;
                    Items.Add(_item);
                }
                return Items.Where(param => param.PARA_Clave == PARA_Clave).FirstOrDefault();
            }
        }
        public Parametros EMISION_SDA
        {
            get
            {
                String PARA_Clave = "EMISION_SDA";
                String PARA_Desc = "EVENTO EMISION DE ARCHIVO SDA";
                if (Items.Where(param => param.PARA_Clave == PARA_Clave).FirstOrDefault() == null)
                {
                    Parametros _item = new Parametros();
                    _item.EMPR_Codigo = Delfin.Controls.Entorno.ItemEmpresa.EMPR_Codigo;
                    _item.SUCR_Codigo = Delfin.Controls.Entorno.ItemSucursal.SUCR_Codigo;
                    _item.PARA_Desc = PARA_Desc;
                    _item.PARA_Clave = PARA_Clave;
                    _item.Instance = Infrastructure.Aspect.BusinessEntity.InstanceEntity.Added;
                    _item.AUDI_UsrCrea = Session.UserName;
                    _item.AUDI_FecCrea = Session.Fecha;
                    Items.Add(_item);
                }
                return Items.Where(param => param.PARA_Clave == PARA_Clave).FirstOrDefault();
            }
        }
        public Parametros EMISION_TELEDESPACHO
        {
            get
            {
                String PARA_Clave = "EMISION_TELEDESPACHO";
                String PARA_Desc = "EVENTO EMISION DE ARCHIVO TELEDESPACHO";
                if (Items.Where(param => param.PARA_Clave == PARA_Clave).FirstOrDefault() == null)
                {
                    Parametros _item = new Parametros();
                    _item.EMPR_Codigo = Delfin.Controls.Entorno.ItemEmpresa.EMPR_Codigo;
                    _item.SUCR_Codigo = Delfin.Controls.Entorno.ItemSucursal.SUCR_Codigo;
                    _item.PARA_Desc = PARA_Desc;
                    _item.PARA_Clave = PARA_Clave;
                    _item.Instance = Infrastructure.Aspect.BusinessEntity.InstanceEntity.Added;
                    _item.AUDI_UsrCrea = Session.UserName;
                    _item.AUDI_FecCrea = Session.Fecha;
                    Items.Add(_item);
                }
                return Items.Where(param => param.PARA_Clave == PARA_Clave).FirstOrDefault();
            }
        }
        public Parametros EMISION_HBL
        {
            get
            {
                String PARA_Clave = "EMISION_HBL";
                String PARA_Desc = "EVENTO EMISION DE HBL";
                if (Items.Where(param => param.PARA_Clave == PARA_Clave).FirstOrDefault() == null)
                {
                    Parametros _item = new Parametros();
                    _item.EMPR_Codigo = Delfin.Controls.Entorno.ItemEmpresa.EMPR_Codigo;
                    _item.SUCR_Codigo = Delfin.Controls.Entorno.ItemSucursal.SUCR_Codigo;
                    _item.PARA_Desc = PARA_Desc;
                    _item.PARA_Clave = PARA_Clave;
                    _item.Instance = Infrastructure.Aspect.BusinessEntity.InstanceEntity.Added;
                    _item.AUDI_UsrCrea = Session.UserName;
                    _item.AUDI_FecCrea = Session.Fecha;
                    Items.Add(_item);
                }
                return Items.Where(param => param.PARA_Clave == PARA_Clave).FirstOrDefault();
            }
        }
        public Parametros OV_ENTREGADA
        {
            get
            {
                String PARA_Clave = "OV_ENTREGADA";
                String PARA_Desc = "EVENTO OV ENTREGADA";
                if (Items.Where(param => param.PARA_Clave == PARA_Clave).FirstOrDefault() == null)
                {
                    Parametros _item = new Parametros();
                    _item.EMPR_Codigo = Delfin.Controls.Entorno.ItemEmpresa.EMPR_Codigo;
                    _item.SUCR_Codigo = Delfin.Controls.Entorno.ItemSucursal.SUCR_Codigo;
                    _item.PARA_Desc = PARA_Desc;
                    _item.PARA_Clave = PARA_Clave;
                    _item.Instance = Infrastructure.Aspect.BusinessEntity.InstanceEntity.Added;
                    _item.AUDI_UsrCrea = Session.UserName;
                    _item.AUDI_FecCrea = Session.Fecha;
                    Items.Add(_item);
                }
                return Items.Where(param => param.PARA_Clave == PARA_Clave).FirstOrDefault();
            }
        }
        #endregion

        #region [ COD. ENTIDAD ]
        public Parametros CODIGO_TRAMARSA
        {
            get
            {
                String PARA_Clave = "CODIGO_TRAMARSA";
                String PARA_Desc = "CODIGO ENTIDAD TRAMARSA";
                if (Items.Where(param => param.PARA_Clave == PARA_Clave).FirstOrDefault() == null)
                {
                    Parametros _item = new Parametros();
                    _item.EMPR_Codigo = Delfin.Controls.Entorno.ItemEmpresa.EMPR_Codigo;
                    _item.SUCR_Codigo = Delfin.Controls.Entorno.ItemSucursal.SUCR_Codigo;
                    _item.PARA_Desc = PARA_Desc;
                    _item.PARA_Clave = PARA_Clave;
                    _item.Instance = Infrastructure.Aspect.BusinessEntity.InstanceEntity.Added;
                    _item.AUDI_UsrCrea = Session.UserName;
                    _item.AUDI_FecCrea = Session.Fecha;
                    Items.Add(_item);
                }
                return Items.Where(param => param.PARA_Clave == PARA_Clave).FirstOrDefault();
            }
        }
        public Parametros CODIGO_COSCO_PERU
        {
            get
            {
                String PARA_Clave = "CODIGO_COSCO_PERU";
                String PARA_Desc = "CODIGO ENTIDAD COSCO PERU";
                if (Items.Where(param => param.PARA_Clave == PARA_Clave).FirstOrDefault() == null)
                {
                    Parametros _item = new Parametros();
                    _item.EMPR_Codigo = Delfin.Controls.Entorno.ItemEmpresa.EMPR_Codigo;
                    _item.SUCR_Codigo = Delfin.Controls.Entorno.ItemSucursal.SUCR_Codigo;
                    _item.PARA_Desc = PARA_Desc;
                    _item.PARA_Clave = PARA_Clave;
                    _item.Instance = Infrastructure.Aspect.BusinessEntity.InstanceEntity.Added;
                    _item.AUDI_UsrCrea = Session.UserName;
                    _item.AUDI_FecCrea = Session.Fecha;
                    Items.Add(_item);
                }
                return Items.Where(param => param.PARA_Clave == PARA_Clave).FirstOrDefault();
            }
        }
        public Parametros EMPRESA
        {
            get
            {
                String PARA_Clave = "EMPRESA";
                String PARA_Desc = "CODIGO DE LA EMPRESA DELFIN GROUP CO. S.A.C";
                if (Items.Where(param => param.PARA_Clave == PARA_Clave).FirstOrDefault() == null)
                {
                    Parametros _item = new Parametros();
                    _item.EMPR_Codigo = Delfin.Controls.Entorno.ItemEmpresa.EMPR_Codigo;
                    _item.SUCR_Codigo = Delfin.Controls.Entorno.ItemSucursal.SUCR_Codigo;
                    _item.PARA_Desc = PARA_Desc;
                    _item.PARA_Clave = PARA_Clave;
                    _item.Instance = Infrastructure.Aspect.BusinessEntity.InstanceEntity.Added;
                    _item.AUDI_UsrCrea = Session.UserName;
                    _item.AUDI_FecCrea = Session.Fecha;
                    Items.Add(_item);
                }
                return Items.Where(param => param.PARA_Clave == PARA_Clave).FirstOrDefault();
            }
        }
        public Parametros EAGENTE_CHINA
        {
            get
            {
                String PARA_Clave = "EAGENTE_CHINA";
                String PARA_Desc = "ENTIDAD AGENTE CHINA";
                if (Items.Where(param => param.PARA_Clave == PARA_Clave).FirstOrDefault() == null)
                {
                    Parametros _item = new Parametros();
                    _item.EMPR_Codigo = Delfin.Controls.Entorno.ItemEmpresa.EMPR_Codigo;
                    _item.SUCR_Codigo = Delfin.Controls.Entorno.ItemSucursal.SUCR_Codigo;
                    _item.PARA_Desc = PARA_Desc;
                    _item.PARA_Clave = PARA_Clave;
                    _item.Instance = Infrastructure.Aspect.BusinessEntity.InstanceEntity.Added;
                    _item.AUDI_UsrCrea = Session.UserName;
                    _item.AUDI_FecCrea = Session.Fecha;
                    Items.Add(_item);
                }
                return Items.Where(param => param.PARA_Clave == PARA_Clave).FirstOrDefault();
            }
        }
        public Parametros EAGENTE_SHANGHAI
        {
            get
            {
                String PARA_Clave = "EAGENTE_SHANGHAI";
                String PARA_Desc = "ENTIDAD AGENTE SHANGHAI";
                if (Items.Where(param => param.PARA_Clave == PARA_Clave).FirstOrDefault() == null)
                {
                    Parametros _item = new Parametros();
                    _item.EMPR_Codigo = Delfin.Controls.Entorno.ItemEmpresa.EMPR_Codigo;
                    _item.SUCR_Codigo = Delfin.Controls.Entorno.ItemSucursal.SUCR_Codigo;
                    _item.PARA_Desc = PARA_Desc;
                    _item.PARA_Clave = PARA_Clave;
                    _item.Instance = Infrastructure.Aspect.BusinessEntity.InstanceEntity.Added;
                    _item.AUDI_UsrCrea = Session.UserName;
                    _item.AUDI_FecCrea = Session.Fecha;
                    Items.Add(_item);
                }
                return Items.Where(param => param.PARA_Clave == PARA_Clave).FirstOrDefault();
            }
        }
        public Parametros CODIGO_HAMBURG_SUD
        {
            get
            {
                String PARA_Clave = "CODIGO_HAMBURG_SUD";
                String PARA_Desc = "CODIGO ENTIDAD HAMBURG SUD";
                if (Items.Where(param => param.PARA_Clave == PARA_Clave).FirstOrDefault() == null)
                {
                    Parametros _item = new Parametros();
                    _item.EMPR_Codigo = Delfin.Controls.Entorno.ItemEmpresa.EMPR_Codigo;
                    _item.SUCR_Codigo = Delfin.Controls.Entorno.ItemSucursal.SUCR_Codigo;
                    _item.PARA_Desc = PARA_Desc;
                    _item.PARA_Clave = PARA_Clave;
                    _item.Instance = Infrastructure.Aspect.BusinessEntity.InstanceEntity.Added;
                    _item.AUDI_UsrCrea = Session.UserName;
                    _item.AUDI_FecCrea = Session.Fecha;
                    Items.Add(_item);
                }
                return Items.Where(param => param.PARA_Clave == PARA_Clave).FirstOrDefault();
            }
        }
        public Parametros CODIGO_HAPAG_LLOYD
        {
            get
            {
                String PARA_Clave = "CODIGO_HAPAG_LLOYD";
                String PARA_Desc = "CODIGO ENTIDAD HAPAG LLOYD";
                if (Items.Where(param => param.PARA_Clave == PARA_Clave).FirstOrDefault() == null)
                {
                    Parametros _item = new Parametros();
                    _item.EMPR_Codigo = Delfin.Controls.Entorno.ItemEmpresa.EMPR_Codigo;
                    _item.SUCR_Codigo = Delfin.Controls.Entorno.ItemSucursal.SUCR_Codigo;
                    _item.PARA_Desc = PARA_Desc;
                    _item.PARA_Clave = PARA_Clave;
                    _item.Instance = Infrastructure.Aspect.BusinessEntity.InstanceEntity.Added;
                    _item.AUDI_UsrCrea = Session.UserName;
                    _item.AUDI_FecCrea = Session.Fecha;
                    Items.Add(_item);
                }
                return Items.Where(param => param.PARA_Clave == PARA_Clave).FirstOrDefault();
            }
        }
        public Parametros EAGENTE_REEMBOLSO
        {
            get
            {
                String PARA_Clave = "EAGENTE_REEMBOLSO";
                String PARA_Desc = "ENTIDAD AGENTE REEMBOLSO CHINA";
                if (Items.Where(param => param.PARA_Clave == PARA_Clave).FirstOrDefault() == null)
                {
                    Parametros _item = new Parametros();
                    _item.EMPR_Codigo = Delfin.Controls.Entorno.ItemEmpresa.EMPR_Codigo;
                    _item.SUCR_Codigo = Delfin.Controls.Entorno.ItemSucursal.SUCR_Codigo;
                    _item.PARA_Desc = PARA_Desc;
                    _item.PARA_Clave = PARA_Clave;
                    _item.Instance = Infrastructure.Aspect.BusinessEntity.InstanceEntity.Added;
                    _item.AUDI_UsrCrea = Session.UserName;
                    _item.AUDI_FecCrea = Session.Fecha;
                    Items.Add(_item);
                }
                return Items.Where(param => param.PARA_Clave == PARA_Clave).FirstOrDefault();
            }
        }
        #endregion

        #region [ RELACIONADOS ]
        public Parametros RTIPO_DTE
        {
            get
            {
                String PARA_Clave = "RTIPO_DTE";
                String PARA_Desc = "RELACIONADO - DEPOSITO TEMPORAL";
                if (Items.Where(param => param.PARA_Clave == PARA_Clave).FirstOrDefault() == null)
                {
                    Parametros _item = new Parametros();
                    _item.EMPR_Codigo = Delfin.Controls.Entorno.ItemEmpresa.EMPR_Codigo;
                    _item.SUCR_Codigo = Delfin.Controls.Entorno.ItemSucursal.SUCR_Codigo;
                    _item.PARA_Desc = PARA_Desc;
                    _item.PARA_Clave = PARA_Clave;
                    _item.Instance = Infrastructure.Aspect.BusinessEntity.InstanceEntity.Added;
                    _item.AUDI_UsrCrea = Session.UserName;
                    _item.AUDI_FecCrea = Session.Fecha;
                    Items.Add(_item);
                }
                return Items.Where(param => param.PARA_Clave == PARA_Clave).FirstOrDefault();
            }
        }
        public Parametros RTIPO_VEN
        {
            get
            {
                String PARA_Clave = "RTIPO_VEN";
                String PARA_Desc = "RELACIONADO - EJECUTIVO";
                if (Items.Where(param => param.PARA_Clave == PARA_Clave).FirstOrDefault() == null)
                {
                    Parametros _item = new Parametros();
                    _item.EMPR_Codigo = Delfin.Controls.Entorno.ItemEmpresa.EMPR_Codigo;
                    _item.SUCR_Codigo = Delfin.Controls.Entorno.ItemSucursal.SUCR_Codigo;
                    _item.PARA_Desc = PARA_Desc;
                    _item.PARA_Clave = PARA_Clave;
                    _item.Instance = Infrastructure.Aspect.BusinessEntity.InstanceEntity.Added;
                    _item.AUDI_UsrCrea = Session.UserName;
                    _item.AUDI_FecCrea = Session.Fecha;
                    Items.Add(_item);
                }
                return Items.Where(param => param.PARA_Clave == PARA_Clave).FirstOrDefault();
            }
        }
        public Parametros RTIPO_CON
        {
            get
            {
                String PARA_Clave = "RTIPO_CON";
                String PARA_Desc = "RELACIONADO - CONTACTOS";
                if (Items.Where(param => param.PARA_Clave == PARA_Clave).FirstOrDefault() == null)
                {
                    Parametros _item = new Parametros();
                    _item.EMPR_Codigo = Delfin.Controls.Entorno.ItemEmpresa.EMPR_Codigo;
                    _item.SUCR_Codigo = Delfin.Controls.Entorno.ItemSucursal.SUCR_Codigo;
                    _item.PARA_Desc = PARA_Desc;
                    _item.PARA_Clave = PARA_Clave;
                    _item.Instance = Infrastructure.Aspect.BusinessEntity.InstanceEntity.Added;
                    _item.AUDI_UsrCrea = Session.UserName;
                    _item.AUDI_FecCrea = Session.Fecha;
                    Items.Add(_item);
                }
                return Items.Where(param => param.PARA_Clave == PARA_Clave).FirstOrDefault();
            }
        }
        public Parametros RTIPO_DVA
        {
            get
            {
                String PARA_Clave = "RTIPO_DVA";
                String PARA_Desc = "RELACIONADO - DEPOSITO DE VACIOS";
                if (Items.Where(param => param.PARA_Clave == PARA_Clave).FirstOrDefault() == null)
                {
                    Parametros _item = new Parametros();
                    _item.EMPR_Codigo = Delfin.Controls.Entorno.ItemEmpresa.EMPR_Codigo;
                    _item.SUCR_Codigo = Delfin.Controls.Entorno.ItemSucursal.SUCR_Codigo;
                    _item.PARA_Desc = PARA_Desc;
                    _item.PARA_Clave = PARA_Clave;
                    _item.Instance = Infrastructure.Aspect.BusinessEntity.InstanceEntity.Added;
                    _item.AUDI_UsrCrea = Session.UserName;
                    _item.AUDI_FecCrea = Session.Fecha;
                    Items.Add(_item);
                }
                return Items.Where(param => param.PARA_Clave == PARA_Clave).FirstOrDefault();
            }
        }
        public Parametros RTIPO_AGE
        {
            get
            {
                String PARA_Clave = "RTIPO_AGE";
                String PARA_Desc = "RELACIONADO - AGENTE DE CARGA";
                if (Items.Where(param => param.PARA_Clave == PARA_Clave).FirstOrDefault() == null)
                {
                    Parametros _item = new Parametros();
                    _item.EMPR_Codigo = Delfin.Controls.Entorno.ItemEmpresa.EMPR_Codigo;
                    _item.SUCR_Codigo = Delfin.Controls.Entorno.ItemSucursal.SUCR_Codigo;
                    _item.PARA_Desc = PARA_Desc;
                    _item.PARA_Clave = PARA_Clave;
                    _item.Instance = Infrastructure.Aspect.BusinessEntity.InstanceEntity.Added;
                    _item.AUDI_UsrCrea = Session.UserName;
                    _item.AUDI_FecCrea = Session.Fecha;
                    Items.Add(_item);
                }
                return Items.Where(param => param.PARA_Clave == PARA_Clave).FirstOrDefault();
            }
        }
        public Parametros RTIPO_CSE
        {
            get
            {
                String PARA_Clave = "RTIPO_CSE";
                String PARA_Desc = "RELACIONADO - CUSTOMER SERVICE";
                if (Items.Where(param => param.PARA_Clave == PARA_Clave).FirstOrDefault() == null)
                {
                    Parametros _item = new Parametros();
                    _item.EMPR_Codigo = Delfin.Controls.Entorno.ItemEmpresa.EMPR_Codigo;
                    _item.SUCR_Codigo = Delfin.Controls.Entorno.ItemSucursal.SUCR_Codigo;
                    _item.PARA_Desc = PARA_Desc;
                    _item.PARA_Clave = PARA_Clave;
                    _item.Instance = Infrastructure.Aspect.BusinessEntity.InstanceEntity.Added;
                    _item.AUDI_UsrCrea = Session.UserName;
                    _item.AUDI_FecCrea = Session.Fecha;
                    Items.Add(_item);
                }
                return Items.Where(param => param.PARA_Clave == PARA_Clave).FirstOrDefault();
            }
        }

        public Parametros EEJECUTIVOS
        {
            get
            {
                String PARA_Clave = "EEJECUTIVOS";
                String PARA_Desc = "EJECUTIVOS SIN REBATE";
                if (Items.Where(param => param.PARA_Clave == PARA_Clave).FirstOrDefault() == null)
                {
                    Parametros _item = new Parametros();
                    _item.EMPR_Codigo = Delfin.Controls.Entorno.ItemEmpresa.EMPR_Codigo;
                    _item.SUCR_Codigo = Delfin.Controls.Entorno.ItemSucursal.SUCR_Codigo;
                    _item.PARA_Desc = PARA_Desc;
                    _item.PARA_Clave = PARA_Clave;
                    _item.Instance = Infrastructure.Aspect.BusinessEntity.InstanceEntity.Added;
                    _item.AUDI_UsrCrea = Session.UserName;
                    _item.AUDI_FecCrea = Session.Fecha;
                    Items.Add(_item);
                }
                return Items.Where(param => param.PARA_Clave == PARA_Clave).FirstOrDefault();
            }
        }
        #endregion

        #region [ CORREOS ]
        public Parametros CORREO_OPERACIONES
        {
            get
            {
                String PARA_Clave = "CORREO_OPERACIONES";
                String PARA_Desc = "CORREO GRUPAL DE OPERACIONES";
                if (Items.Where(param => param.PARA_Clave == PARA_Clave).FirstOrDefault() == null)
                {
                    Parametros _item = new Parametros();
                    _item.EMPR_Codigo = Delfin.Controls.Entorno.ItemEmpresa.EMPR_Codigo;
                    _item.SUCR_Codigo = Delfin.Controls.Entorno.ItemSucursal.SUCR_Codigo;
                    _item.PARA_Desc = PARA_Desc;
                    _item.PARA_Clave = PARA_Clave;
                    _item.Instance = Infrastructure.Aspect.BusinessEntity.InstanceEntity.Added;
                    _item.AUDI_UsrCrea = Session.UserName;
                    _item.AUDI_FecCrea = Session.Fecha;
                    Items.Add(_item);
                }
                return Items.Where(param => param.PARA_Clave == PARA_Clave).FirstOrDefault();
            }
        }
        public Parametros CORREO_DOCUMENTACION
        {
            get
            {
                String PARA_Clave = "CORREO_DOCUMENTACION";
                String PARA_Desc = "CORREO GRUPAL DE DOCUMENTACION";
                if (Items.Where(param => param.PARA_Clave == PARA_Clave).FirstOrDefault() == null)
                {
                    Parametros _item = new Parametros();
                    _item.EMPR_Codigo = Delfin.Controls.Entorno.ItemEmpresa.EMPR_Codigo;
                    _item.SUCR_Codigo = Delfin.Controls.Entorno.ItemSucursal.SUCR_Codigo;
                    _item.PARA_Desc = PARA_Desc;
                    _item.PARA_Clave = PARA_Clave;
                    _item.Instance = Infrastructure.Aspect.BusinessEntity.InstanceEntity.Added;
                    _item.AUDI_UsrCrea = Session.UserName;
                    _item.AUDI_FecCrea = Session.Fecha;
                    Items.Add(_item);
                }
                return Items.Where(param => param.PARA_Clave == PARA_Clave).FirstOrDefault();
            }
        }
        public Parametros CORREO_LOGISTICA
        {
            get
            {
                String PARA_Clave = "CORREO_LOGISTICA";
                String PARA_Desc = "CORREO GRUPAL DE LOGISTICA";
                if (Items.Where(param => param.PARA_Clave == PARA_Clave).FirstOrDefault() == null)
                {
                    Parametros _item = new Parametros();
                    _item.EMPR_Codigo = Delfin.Controls.Entorno.ItemEmpresa.EMPR_Codigo;
                    _item.SUCR_Codigo = Delfin.Controls.Entorno.ItemSucursal.SUCR_Codigo;
                    _item.PARA_Desc = PARA_Desc;
                    _item.PARA_Clave = PARA_Clave;
                    _item.Instance = Infrastructure.Aspect.BusinessEntity.InstanceEntity.Added;
                    _item.AUDI_UsrCrea = Session.UserName;
                    _item.AUDI_FecCrea = Session.Fecha;
                    Items.Add(_item);
                }
                return Items.Where(param => param.PARA_Clave == PARA_Clave).FirstOrDefault();
            }
        }
        public Parametros CORREO_FLETAMENTO
        {
            get
            {
                String PARA_Clave = "CORREO_FLETAMENTO";
                String PARA_Desc = "CORREO GRUPAL DE FLETAMENTO";
                if (Items.Where(param => param.PARA_Clave == PARA_Clave).FirstOrDefault() == null)
                {
                    Parametros _item = new Parametros();
                    _item.EMPR_Codigo = Delfin.Controls.Entorno.ItemEmpresa.EMPR_Codigo;
                    _item.SUCR_Codigo = Delfin.Controls.Entorno.ItemSucursal.SUCR_Codigo;
                    _item.PARA_Desc = PARA_Desc;
                    _item.PARA_Clave = PARA_Clave;
                    _item.Instance = Infrastructure.Aspect.BusinessEntity.InstanceEntity.Added;
                    _item.AUDI_UsrCrea = Session.UserName;
                    _item.AUDI_FecCrea = Session.Fecha;
                    Items.Add(_item);
                }
                return Items.Where(param => param.PARA_Clave == PARA_Clave).FirstOrDefault();
            }
        }
        public Parametros CORREO_FINANZAS
        {
            get
            {
                String PARA_Clave = "CORREO_FINANZAS";
                String PARA_Desc = "CORREO GRUPAL DE FINANZAS";
                if (Items.Where(param => param.PARA_Clave == PARA_Clave).FirstOrDefault() == null)
                {
                    Parametros _item = new Parametros();
                    _item.EMPR_Codigo = Delfin.Controls.Entorno.ItemEmpresa.EMPR_Codigo;
                    _item.SUCR_Codigo = Delfin.Controls.Entorno.ItemSucursal.SUCR_Codigo;
                    _item.PARA_Desc = PARA_Desc;
                    _item.PARA_Clave = PARA_Clave;
                    _item.Instance = Infrastructure.Aspect.BusinessEntity.InstanceEntity.Added;
                    _item.AUDI_UsrCrea = Session.UserName;
                    _item.AUDI_FecCrea = Session.Fecha;
                    Items.Add(_item);
                }
                return Items.Where(param => param.PARA_Clave == PARA_Clave).FirstOrDefault();
            }
        }
        public Parametros CORREO_CUSTOMER_EXPO
        {
            get
            {
                String PARA_Clave = "CORREO_CUSTOMER_EXPO";
                String PARA_Desc = "CORREO DEL JEFE DE CUSTOMER EXPORTACIONES";
                if (Items.Where(param => param.PARA_Clave == PARA_Clave).FirstOrDefault() == null)
                {
                    Parametros _item = new Parametros();
                    _item.EMPR_Codigo = Delfin.Controls.Entorno.ItemEmpresa.EMPR_Codigo;
                    _item.SUCR_Codigo = Delfin.Controls.Entorno.ItemSucursal.SUCR_Codigo;
                    _item.PARA_Desc = PARA_Desc;
                    _item.PARA_Clave = PARA_Clave;
                    _item.Instance = Infrastructure.Aspect.BusinessEntity.InstanceEntity.Added;
                    _item.AUDI_UsrCrea = Session.UserName;
                    _item.AUDI_FecCrea = Session.Fecha;
                    Items.Add(_item);
                }
                return Items.Where(param => param.PARA_Clave == PARA_Clave).FirstOrDefault();
            }
        }
        public Parametros CORREO_CUSTOMER_IMPO
        {
            get
            {
                String PARA_Clave = "CORREO_CUSTOMER_IMPO";
                String PARA_Desc = "CORREO DEL JEFE DE CUSTOMER IMPORTACIONES";
                if (Items.Where(param => param.PARA_Clave == PARA_Clave).FirstOrDefault() == null)
                {
                    Parametros _item = new Parametros();
                    _item.EMPR_Codigo = Delfin.Controls.Entorno.ItemEmpresa.EMPR_Codigo;
                    _item.SUCR_Codigo = Delfin.Controls.Entorno.ItemSucursal.SUCR_Codigo;
                    _item.PARA_Desc = PARA_Desc;
                    _item.PARA_Clave = PARA_Clave;
                    _item.Instance = Infrastructure.Aspect.BusinessEntity.InstanceEntity.Added;
                    _item.AUDI_UsrCrea = Session.UserName;
                    _item.AUDI_FecCrea = Session.Fecha;
                    Items.Add(_item);
                }
                return Items.Where(param => param.PARA_Clave == PARA_Clave).FirstOrDefault();
            }
        }
        #endregion

        #region [ DOC. VENTA ]
        public Parametros TIPO_TDO_NC
        {
            get
            {
                String PARA_Clave = "TIPO_TDO_NC";
                String PARA_Desc = "TIPO DE DOCUMENTO NOTA DE CREDITO";
                if (Items.Where(param => param.PARA_Clave == PARA_Clave).FirstOrDefault() == null)
                {
                    Parametros _item = new Parametros();
                    _item.EMPR_Codigo = Delfin.Controls.Entorno.ItemEmpresa.EMPR_Codigo;
                    _item.SUCR_Codigo = Delfin.Controls.Entorno.ItemSucursal.SUCR_Codigo;
                    _item.PARA_Desc = PARA_Desc;
                    _item.PARA_Clave = PARA_Clave;
                    _item.Instance = Infrastructure.Aspect.BusinessEntity.InstanceEntity.Added;
                    _item.AUDI_UsrCrea = Session.UserName;
                    _item.AUDI_FecCrea = Session.Fecha;
                    Items.Add(_item);
                }
                return Items.Where(param => param.PARA_Clave == PARA_Clave).FirstOrDefault();
            }
        }
        public Parametros TIPO_TDO_PR
        {
            get
            {
                String PARA_Clave = "TIPO_TDO_PR";
                String PARA_Desc = "TIPO DE DOCUMENTO PROVISION";
                if (Items.Where(param => param.PARA_Clave == PARA_Clave).FirstOrDefault() == null)
                {
                    Parametros _item = new Parametros();
                    _item.EMPR_Codigo = Delfin.Controls.Entorno.ItemEmpresa.EMPR_Codigo;
                    _item.SUCR_Codigo = Delfin.Controls.Entorno.ItemSucursal.SUCR_Codigo;
                    _item.PARA_Desc = PARA_Desc;
                    _item.PARA_Clave = PARA_Clave;
                    _item.Instance = Infrastructure.Aspect.BusinessEntity.InstanceEntity.Added;
                    _item.AUDI_UsrCrea = Session.UserName;
                    _item.AUDI_FecCrea = Session.Fecha;
                    Items.Add(_item);
                }
                return Items.Where(param => param.PARA_Clave == PARA_Clave).FirstOrDefault();
            }
        }
        public Parametros TIPO_TDO_AN
        {
            get
            {
                String PARA_Clave = "TIPO_TDO_AN";
                String PARA_Desc = "TIPO DE DOCUMENTO ANTICIPO";
                if (Items.Where(param => param.PARA_Clave == PARA_Clave).FirstOrDefault() == null)
                {
                    Parametros _item = new Parametros();
                    _item.EMPR_Codigo = Delfin.Controls.Entorno.ItemEmpresa.EMPR_Codigo;
                    _item.SUCR_Codigo = Delfin.Controls.Entorno.ItemSucursal.SUCR_Codigo;
                    _item.PARA_Desc = PARA_Desc;
                    _item.PARA_Clave = PARA_Clave;
                    _item.Instance = Infrastructure.Aspect.BusinessEntity.InstanceEntity.Added;
                    _item.AUDI_UsrCrea = Session.UserName;
                    _item.AUDI_FecCrea = Session.Fecha;
                    Items.Add(_item);
                }
                return Items.Where(param => param.PARA_Clave == PARA_Clave).FirstOrDefault();
            }
        }
        public Parametros TIPO_TDO_CN
        {
            get
            {
                String PARA_Clave = "TIPO_TDO_CN";
                String PARA_Desc = "TIPO DE DOCUMENTO CREDIT NOTE";
                if (Items.Where(param => param.PARA_Clave == PARA_Clave).FirstOrDefault() == null)
                {
                    Parametros _item = new Parametros();
                    _item.EMPR_Codigo = Delfin.Controls.Entorno.ItemEmpresa.EMPR_Codigo;
                    _item.SUCR_Codigo = Delfin.Controls.Entorno.ItemSucursal.SUCR_Codigo;
                    _item.PARA_Desc = PARA_Desc;
                    _item.PARA_Clave = PARA_Clave;
                    _item.Instance = Infrastructure.Aspect.BusinessEntity.InstanceEntity.Added;
                    _item.AUDI_UsrCrea = Session.UserName;
                    _item.AUDI_FecCrea = Session.Fecha;
                    Items.Add(_item);
                }
                return Items.Where(param => param.PARA_Clave == PARA_Clave).FirstOrDefault();
            }
        }
        #endregion

        #region [ TIPO CAMBIO ]
        public Parametros TCCTACTE_CLI
        {
            get
            {
                String PARA_Clave = "TCCTACTE_CLI";
                String PARA_Desc = "TIPO DE CAMBIO PARA CLIENTES";
                if (Items.Where(param => param.PARA_Clave == PARA_Clave).FirstOrDefault() == null)
                {
                    Parametros _item = new Parametros();
                    _item.EMPR_Codigo = Delfin.Controls.Entorno.ItemEmpresa.EMPR_Codigo;
                    _item.SUCR_Codigo = Delfin.Controls.Entorno.ItemSucursal.SUCR_Codigo;
                    _item.PARA_Desc = PARA_Desc;
                    _item.PARA_Clave = PARA_Clave;
                    _item.Instance = Infrastructure.Aspect.BusinessEntity.InstanceEntity.Added;
                    _item.AUDI_UsrCrea = Session.UserName;
                    _item.AUDI_FecCrea = Session.Fecha;
                    Items.Add(_item);
                }
                return Items.Where(param => param.PARA_Clave == PARA_Clave).FirstOrDefault();
            }
        }
        public Parametros TCCTACTE_PRO
        {
            get
            {
                String PARA_Clave = "TCCTACTE_PRO";
                String PARA_Desc = "TIPO DE CAMBIO PARA PROVEEDORES";
                if (Items.Where(param => param.PARA_Clave == PARA_Clave).FirstOrDefault() == null)
                {
                    Parametros _item = new Parametros();
                    _item.EMPR_Codigo = Delfin.Controls.Entorno.ItemEmpresa.EMPR_Codigo;
                    _item.SUCR_Codigo = Delfin.Controls.Entorno.ItemSucursal.SUCR_Codigo;
                    _item.PARA_Desc = PARA_Desc;
                    _item.PARA_Clave = PARA_Clave;
                    _item.Instance = Infrastructure.Aspect.BusinessEntity.InstanceEntity.Added;
                    _item.AUDI_UsrCrea = Session.UserName;
                    _item.AUDI_FecCrea = Session.Fecha;
                    Items.Add(_item);
                }
                return Items.Where(param => param.PARA_Clave == PARA_Clave).FirstOrDefault();
            }
        }
        #endregion

        #region [ SERIES ]
        public Parametros SERIE_CALLO
        {
            get
            {
                String PARA_Clave = "SERIE_CALLO";
                String PARA_Desc = "SERIE PARA CALLAO";
                if (Items.Where(param => param.PARA_Clave == PARA_Clave).FirstOrDefault() == null)
                {
                    Parametros _item = new Parametros();
                    _item.EMPR_Codigo = Delfin.Controls.Entorno.ItemEmpresa.EMPR_Codigo;
                    _item.SUCR_Codigo = Delfin.Controls.Entorno.ItemSucursal.SUCR_Codigo;
                    _item.PARA_Desc = PARA_Desc;
                    _item.PARA_Clave = PARA_Clave;
                    _item.Instance = Infrastructure.Aspect.BusinessEntity.InstanceEntity.Added;
                    _item.AUDI_UsrCrea = Session.UserName;
                    _item.AUDI_FecCrea = Session.Fecha;
                    Items.Add(_item);
                }
                return Items.Where(param => param.PARA_Clave == PARA_Clave).FirstOrDefault();
            }
        }
        public Parametros SERIE_EXPORTACION
        {
            get
            {
                String PARA_Clave = "SERIE_EXPORTACION";
                String PARA_Desc = "SERIE PARA EXPORTACIONES";
                if (Items.Where(param => param.PARA_Clave == PARA_Clave).FirstOrDefault() == null)
                {
                    Parametros _item = new Parametros();
                    _item.EMPR_Codigo = Delfin.Controls.Entorno.ItemEmpresa.EMPR_Codigo;
                    _item.SUCR_Codigo = Delfin.Controls.Entorno.ItemSucursal.SUCR_Codigo;
                    _item.PARA_Desc = PARA_Desc;
                    _item.PARA_Clave = PARA_Clave;
                    _item.Instance = Infrastructure.Aspect.BusinessEntity.InstanceEntity.Added;
                    _item.AUDI_UsrCrea = Session.UserName;
                    _item.AUDI_FecCrea = Session.Fecha;
                    Items.Add(_item);
                }
                return Items.Where(param => param.PARA_Clave == PARA_Clave).FirstOrDefault();
            }
        }
        public Parametros SERIE_MANDATO
        {
            get
            {
                String PARA_Clave = "SERIE_MANDATO";
                String PARA_Desc = "SERIE PARA MANDATO";
                if (Items.Where(param => param.PARA_Clave == PARA_Clave).FirstOrDefault() == null)
                {
                    Parametros _item = new Parametros();
                    _item.EMPR_Codigo = Delfin.Controls.Entorno.ItemEmpresa.EMPR_Codigo;
                    _item.SUCR_Codigo = Delfin.Controls.Entorno.ItemSucursal.SUCR_Codigo;
                    _item.PARA_Desc = PARA_Desc;
                    _item.PARA_Clave = PARA_Clave;
                    _item.Instance = Infrastructure.Aspect.BusinessEntity.InstanceEntity.Added;
                    _item.AUDI_UsrCrea = Session.UserName;
                    _item.AUDI_FecCrea = Session.Fecha;
                    Items.Add(_item);
                }
                return Items.Where(param => param.PARA_Clave == PARA_Clave).FirstOrDefault();
            }
        }
        public Parametros SERIE_OTRAFICOS
        {
            get
            {
                String PARA_Clave = "SERIE_OTRAFICOS";
                String PARA_Desc = "SERIE PARA OTROS TRAFICOS";
                if (Items.Where(param => param.PARA_Clave == PARA_Clave).FirstOrDefault() == null)
                {
                    Parametros _item = new Parametros();
                    _item.EMPR_Codigo = Delfin.Controls.Entorno.ItemEmpresa.EMPR_Codigo;
                    _item.SUCR_Codigo = Delfin.Controls.Entorno.ItemSucursal.SUCR_Codigo;
                    _item.PARA_Desc = PARA_Desc;
                    _item.PARA_Clave = PARA_Clave;
                    _item.Instance = Infrastructure.Aspect.BusinessEntity.InstanceEntity.Added;
                    _item.AUDI_UsrCrea = Session.UserName;
                    _item.AUDI_FecCrea = Session.Fecha;
                    Items.Add(_item);
                }
                return Items.Where(param => param.PARA_Clave == PARA_Clave).FirstOrDefault();
            }
        }
        public Parametros SERIE_SLI
        {
            get
            {
                String PARA_Clave = "SERIE_SLI";
                String PARA_Desc = "SERIE PARA SLI";
                if (Items.Where(param => param.PARA_Clave == PARA_Clave).FirstOrDefault() == null)
                {
                    Parametros _item = new Parametros();
                    _item.EMPR_Codigo = Delfin.Controls.Entorno.ItemEmpresa.EMPR_Codigo;
                    _item.SUCR_Codigo = Delfin.Controls.Entorno.ItemSucursal.SUCR_Codigo;
                    _item.PARA_Desc = PARA_Desc;
                    _item.PARA_Clave = PARA_Clave;
                    _item.Instance = Infrastructure.Aspect.BusinessEntity.InstanceEntity.Added;
                    _item.AUDI_UsrCrea = Session.UserName;
                    _item.AUDI_FecCrea = Session.Fecha;
                    Items.Add(_item);
                }
                return Items.Where(param => param.PARA_Clave == PARA_Clave).FirstOrDefault();
            }
        }
        #endregion

        #region [ PLANILLAS ]
        public ObservableCollection<Parametros> PLANILLAS
        {
            get
            {
                String PARA_Clave1 = "DET_2";
                String PARA_Clave2 = "WWW_2";
                if (Items.Where(param => param.PARA_Clave.Contains(PARA_Clave1) || param.PARA_Clave.Contains(PARA_Clave2)) == null)
                {
                    return null;
                }
                else
                { return Items.Where(param => param.PARA_Clave.Contains(PARA_Clave1) || param.PARA_Clave.Contains(PARA_Clave2)).ToObservableCollection(); }
            }
        }
        #endregion

        #region [ OTROS ]
        public Parametros IGV
        {
            get
            {
                String PARA_Clave = "IGV";
                String PARA_Desc = "IGV";
                if (Items.Where(param => param.PARA_Clave == PARA_Clave).FirstOrDefault() == null)
                {
                    Parametros _item = new Parametros();
                    _item.EMPR_Codigo = Delfin.Controls.Entorno.ItemEmpresa.EMPR_Codigo;
                    _item.SUCR_Codigo = Delfin.Controls.Entorno.ItemSucursal.SUCR_Codigo;
                    _item.PARA_Desc = PARA_Desc;
                    _item.PARA_Clave = PARA_Clave;
                    _item.Instance = Infrastructure.Aspect.BusinessEntity.InstanceEntity.Added;
                    _item.AUDI_UsrCrea = Session.UserName;
                    _item.AUDI_FecCrea = Session.Fecha;
                    Items.Add(_item);
                }
                return Items.Where(param => param.PARA_Clave == PARA_Clave).FirstOrDefault();
            }
        }
        public Parametros STATMENT_MONEDA
        {
            get
            {
                String PARA_Clave = "STATMENT_MONEDA";
                String PARA_Desc = "MONEDA DE GENERACION STATMENT";
                if (Items.Where(param => param.PARA_Clave == PARA_Clave).FirstOrDefault() == null)
                {
                    Parametros _item = new Parametros();
                    _item.EMPR_Codigo = Delfin.Controls.Entorno.ItemEmpresa.EMPR_Codigo;
                    _item.SUCR_Codigo = Delfin.Controls.Entorno.ItemSucursal.SUCR_Codigo;
                    _item.PARA_Desc = PARA_Desc;
                    _item.PARA_Clave = PARA_Clave;
                    _item.Instance = Infrastructure.Aspect.BusinessEntity.InstanceEntity.Added;
                    _item.AUDI_UsrCrea = Session.UserName;
                    _item.AUDI_FecCrea = Session.Fecha;
                    Items.Add(_item);
                }
                return Items.Where(param => param.PARA_Clave == PARA_Clave).FirstOrDefault();
            }
        }
        public Parametros TDI_004SINRUC
        {
            get
            {
                String PARA_Clave = "TDI_004SINRUC";
                String PARA_Desc = "PARAMETRO DE TIPO TDI=SIN RUC";
                if (Items.Where(param => param.PARA_Clave == PARA_Clave).FirstOrDefault() == null)
                {
                    Parametros _item = new Parametros();
                    _item.EMPR_Codigo = Delfin.Controls.Entorno.ItemEmpresa.EMPR_Codigo;
                    _item.SUCR_Codigo = Delfin.Controls.Entorno.ItemSucursal.SUCR_Codigo;
                    _item.PARA_Desc = PARA_Desc;
                    _item.PARA_Clave = PARA_Clave;
                    _item.Instance = Infrastructure.Aspect.BusinessEntity.InstanceEntity.Added;
                    _item.AUDI_UsrCrea = Session.UserName;
                    _item.AUDI_FecCrea = Session.Fecha;
                    Items.Add(_item);
                }
                return Items.Where(param => param.PARA_Clave == PARA_Clave).FirstOrDefault();
            }
        }
        public Parametros IMP
        {
            get
            {
                String PARA_Clave = String.Format("IMP-{0}", Session.UserName);
                String PARA_Desc = String.Format("IMP-{0}", Session.UserName);
                if (Items.Where(param => param.PARA_Clave == PARA_Clave).FirstOrDefault() == null)
                {
                    Parametros _item = new Parametros();
                    _item.EMPR_Codigo = Delfin.Controls.Entorno.ItemEmpresa.EMPR_Codigo;
                    _item.SUCR_Codigo = Delfin.Controls.Entorno.ItemSucursal.SUCR_Codigo;
                    _item.PARA_Desc = PARA_Desc;
                    _item.PARA_Clave = PARA_Clave;
                    _item.Instance = Infrastructure.Aspect.BusinessEntity.InstanceEntity.Added;
                    _item.AUDI_UsrCrea = Session.UserName;
                    _item.AUDI_FecCrea = Session.Fecha;
                    Items.Add(_item);
                }
                return Items.Where(param => param.PARA_Clave == PARA_Clave).FirstOrDefault();
            }
        }
        public Parametros PUERTO_SHANGHAI
        {
            get
            {
                String PARA_Clave = "PUERTO_SHANGHAI";
                String PARA_Desc = "PUERTO SHANGHAI";
                if (Items.Where(param => param.PARA_Clave == PARA_Clave).FirstOrDefault() == null)
                {
                    Parametros _item = new Parametros();
                    _item.EMPR_Codigo = Delfin.Controls.Entorno.ItemEmpresa.EMPR_Codigo;
                    _item.SUCR_Codigo = Delfin.Controls.Entorno.ItemSucursal.SUCR_Codigo;
                    _item.PARA_Desc = PARA_Desc;
                    _item.PARA_Clave = PARA_Clave;
                    _item.Instance = Infrastructure.Aspect.BusinessEntity.InstanceEntity.Added;
                    _item.AUDI_UsrCrea = Session.UserName;
                    _item.AUDI_FecCrea = Session.Fecha;
                    Items.Add(_item);
                }
                return Items.Where(param => param.PARA_Clave == PARA_Clave).FirstOrDefault();
            }
        }
        public Parametros PUERTO_CALLAO
        {
            get
            {
                String PARA_Clave = "PUERTO_CALLAO";
                String PARA_Desc = "PUERTO CALLAO";
                if (Items.Where(param => param.PARA_Clave == PARA_Clave).FirstOrDefault() == null)
                {
                    Parametros _item = new Parametros();
                    _item.EMPR_Codigo = Delfin.Controls.Entorno.ItemEmpresa.EMPR_Codigo;
                    _item.SUCR_Codigo = Delfin.Controls.Entorno.ItemSucursal.SUCR_Codigo;
                    _item.PARA_Desc = PARA_Desc;
                    _item.PARA_Clave = PARA_Clave;
                    _item.Instance = Infrastructure.Aspect.BusinessEntity.InstanceEntity.Added;
                    _item.AUDI_UsrCrea = Session.UserName;
                    _item.AUDI_FecCrea = Session.Fecha;
                    Items.Add(_item);
                }
                return Items.Where(param => param.PARA_Clave == PARA_Clave).FirstOrDefault();
            }
        }
        public Parametros PAIS_MANDATO
        {
            get
            {
                String PARA_Clave = "PAIS_MANDATO";
                String PARA_Desc = "CODIGO DEL PAIS PARA MANDATO";
                if (Items.Where(param => param.PARA_Clave == PARA_Clave).FirstOrDefault() == null)
                {
                    Parametros _item = new Parametros();
                    _item.EMPR_Codigo = Delfin.Controls.Entorno.ItemEmpresa.EMPR_Codigo;
                    _item.SUCR_Codigo = Delfin.Controls.Entorno.ItemSucursal.SUCR_Codigo;
                    _item.PARA_Desc = PARA_Desc;
                    _item.PARA_Clave = PARA_Clave;
                    _item.Instance = Infrastructure.Aspect.BusinessEntity.InstanceEntity.Added;
                    _item.AUDI_UsrCrea = Session.UserName;
                    _item.AUDI_FecCrea = Session.Fecha;
                    Items.Add(_item);
                }
                return Items.Where(param => param.PARA_Clave == PARA_Clave).FirstOrDefault();
            }
        }

        public Parametros PACK_LCL
        {
            get
            {
                String PARA_Clave = "PACK_LCL";
                String PARA_Desc = "TIPO PAQUETE LCL";
                if (Items.Where(param => param.PARA_Clave == PARA_Clave).FirstOrDefault() == null)
                {
                    Parametros _item = new Parametros();
                    _item.EMPR_Codigo = Delfin.Controls.Entorno.ItemEmpresa.EMPR_Codigo;
                    _item.SUCR_Codigo = Delfin.Controls.Entorno.ItemSucursal.SUCR_Codigo;
                    _item.PARA_Desc = PARA_Desc;
                    _item.PARA_Clave = PARA_Clave;
                    _item.Instance = Infrastructure.Aspect.BusinessEntity.InstanceEntity.Added;
                    _item.AUDI_UsrCrea = Session.UserName;
                    _item.AUDI_FecCrea = Session.Fecha;
                    Items.Add(_item);
                }
                return Items.Where(param => param.PARA_Clave == PARA_Clave).FirstOrDefault();
            }
        }
        #endregion

        #region [ ADUANAS ]
        public Parametros RUTA_TELEDESPACHO
        {
            get
            {
                String PARA_Clave = "RUTA_TELEDESPACHO";
                String PARA_Desc = "RUTA PARA LOS ARCHIVOS DE TELEDESPACHO";
                if (Items.Where(param => param.PARA_Clave == PARA_Clave).FirstOrDefault() == null)
                {
                    Parametros _item = new Parametros();
                    _item.EMPR_Codigo = Delfin.Controls.Entorno.ItemEmpresa.EMPR_Codigo;
                    _item.SUCR_Codigo = Delfin.Controls.Entorno.ItemSucursal.SUCR_Codigo;
                    _item.PARA_Desc = PARA_Desc;
                    _item.PARA_Clave = PARA_Clave;
                    _item.Instance = Infrastructure.Aspect.BusinessEntity.InstanceEntity.Added;
                    _item.AUDI_UsrCrea = Session.UserName;
                    _item.AUDI_FecCrea = Session.Fecha;
                    Items.Add(_item);
                }
                return Items.Where(param => param.PARA_Clave == PARA_Clave).FirstOrDefault();
            }
        }
        public Parametros RUTA_SDA
        {
            get
            {
                String PARA_Clave = "RUTA_SDA";
                String PARA_Desc = "RUTA PARA ARCHIVOS SDA";
                if (Items.Where(param => param.PARA_Clave == PARA_Clave).FirstOrDefault() == null)
                {
                    Parametros _item = new Parametros();
                    _item.EMPR_Codigo = Delfin.Controls.Entorno.ItemEmpresa.EMPR_Codigo;
                    _item.SUCR_Codigo = Delfin.Controls.Entorno.ItemSucursal.SUCR_Codigo;
                    _item.PARA_Desc = PARA_Desc;
                    _item.PARA_Clave = PARA_Clave;
                    _item.Instance = Infrastructure.Aspect.BusinessEntity.InstanceEntity.Added;
                    _item.AUDI_UsrCrea = Session.UserName;
                    _item.AUDI_FecCrea = Session.Fecha;
                    Items.Add(_item);
                }
                return Items.Where(param => param.PARA_Clave == PARA_Clave).FirstOrDefault();
            }
        }
        #endregion

        #region [ CUENTAS ]

        public Parametros CUENTA_IGV
        {
            get
            {
                String PARA_Clave = "CUENTA_IGV";
                String PARA_Desc = "Cuenta de IGV";
                if (Items.Where(param => param.PARA_Clave == PARA_Clave).FirstOrDefault() == null)
                {
                    Parametros _item = new Parametros();
                    _item.EMPR_Codigo = Delfin.Controls.Entorno.ItemEmpresa.EMPR_Codigo;
                    _item.SUCR_Codigo = Delfin.Controls.Entorno.ItemSucursal.SUCR_Codigo;
                    _item.PARA_Desc = PARA_Desc;
                    _item.PARA_Clave = PARA_Clave;
                    _item.Instance = Infrastructure.Aspect.BusinessEntity.InstanceEntity.Added;
                    _item.AUDI_UsrCrea = Session.UserName;
                    _item.AUDI_FecCrea = Session.Fecha;
                    Items.Add(_item);
                }
                return Items.Where(param => param.PARA_Clave == PARA_Clave).FirstOrDefault();
            }
        }

        public Parametros CUENTA_VTA
        {
            get
            {
                String PARA_Clave = "CUENTA_VTA";
                String PARA_Desc = "Cuenta de Venta (S/.|US$)";
                if (Items.Where(param => param.PARA_Clave == PARA_Clave).FirstOrDefault() == null)
                {
                    Parametros _item = new Parametros();
                    _item.EMPR_Codigo = Delfin.Controls.Entorno.ItemEmpresa.EMPR_Codigo;
                    _item.SUCR_Codigo = Delfin.Controls.Entorno.ItemSucursal.SUCR_Codigo;
                    _item.PARA_Desc = PARA_Desc;
                    _item.PARA_Clave = PARA_Clave;
                    _item.Instance = Infrastructure.Aspect.BusinessEntity.InstanceEntity.Added;
                    _item.AUDI_UsrCrea = Session.UserName;
                    _item.AUDI_FecCrea = Session.Fecha;
                    Items.Add(_item);
                }
                return Items.Where(param => param.PARA_Clave == PARA_Clave).FirstOrDefault();
            }
        }

        public Parametros CUENTA_COM
        {
            get
            {
                String PARA_Clave = "CUENTA_COM";
                String PARA_Desc = "Cuenta de Compra (S/.|US$)";
                if (Items.Where(param => param.PARA_Clave == PARA_Clave).FirstOrDefault() == null)
                {
                    Parametros _item = new Parametros();
                    _item.EMPR_Codigo = Delfin.Controls.Entorno.ItemEmpresa.EMPR_Codigo;
                    _item.SUCR_Codigo = Delfin.Controls.Entorno.ItemSucursal.SUCR_Codigo;
                    _item.PARA_Desc = PARA_Desc;
                    _item.PARA_Clave = PARA_Clave;
                    _item.Instance = Infrastructure.Aspect.BusinessEntity.InstanceEntity.Added;
                    _item.AUDI_UsrCrea = Session.UserName;
                    _item.AUDI_FecCrea = Session.Fecha;
                    Items.Add(_item);
                }
                return Items.Where(param => param.PARA_Clave == PARA_Clave).FirstOrDefault();
            }
        }

        public Parametros CUENTA_IGV_DIF
        {
            get
            {
                String PARA_Clave = "CUENTA_IGV_DIF";
                String PARA_Desc = "Cuenta de IGV diferido";
                if (Items.Where(param => param.PARA_Clave == PARA_Clave).FirstOrDefault() == null)
                {
                    Parametros _item = new Parametros();
                    _item.EMPR_Codigo = Delfin.Controls.Entorno.ItemEmpresa.EMPR_Codigo;
                    _item.SUCR_Codigo = Delfin.Controls.Entorno.ItemSucursal.SUCR_Codigo;
                    _item.PARA_Desc = PARA_Desc;
                    _item.PARA_Clave = PARA_Clave;
                    _item.Instance = Infrastructure.Aspect.BusinessEntity.InstanceEntity.Added;
                    _item.AUDI_UsrCrea = Session.UserName;
                    _item.AUDI_FecCrea = Session.Fecha;
                    Items.Add(_item);
                }
                return Items.Where(param => param.PARA_Clave == PARA_Clave).FirstOrDefault();
            }
        }

        public Parametros CUENTA_VTA_DIF
        {
            get
            {
                String PARA_Clave = "CUENTA_VTA_DIF";
                String PARA_Desc = "Cuenta de Venta (S/.|US$) Diferido";
                if (Items.Where(param => param.PARA_Clave == PARA_Clave).FirstOrDefault() == null)
                {
                    Parametros _item = new Parametros();
                    _item.EMPR_Codigo = Delfin.Controls.Entorno.ItemEmpresa.EMPR_Codigo;
                    _item.SUCR_Codigo = Delfin.Controls.Entorno.ItemSucursal.SUCR_Codigo;
                    _item.PARA_Desc = PARA_Desc;
                    _item.PARA_Clave = PARA_Clave;
                    _item.Instance = Infrastructure.Aspect.BusinessEntity.InstanceEntity.Added;
                    _item.AUDI_UsrCrea = Session.UserName;
                    _item.AUDI_FecCrea = Session.Fecha;
                    Items.Add(_item);
                }
                return Items.Where(param => param.PARA_Clave == PARA_Clave).FirstOrDefault();
            }
        }

        public Parametros CUENTA_COM_DIF
        {
            get
            {
                String PARA_Clave = "CUENTA_COM_DIF";
                String PARA_Desc = "Cuenta de Compra (S/.|US$)";
                if (Items.Where(param => param.PARA_Clave == PARA_Clave).FirstOrDefault() == null)
                {
                    Parametros _item = new Parametros();
                    _item.EMPR_Codigo = Delfin.Controls.Entorno.ItemEmpresa.EMPR_Codigo;
                    _item.SUCR_Codigo = Delfin.Controls.Entorno.ItemSucursal.SUCR_Codigo;
                    _item.PARA_Desc = PARA_Desc;
                    _item.PARA_Clave = PARA_Clave;
                    _item.Instance = Infrastructure.Aspect.BusinessEntity.InstanceEntity.Added;
                    _item.AUDI_UsrCrea = Session.UserName;
                    _item.AUDI_FecCrea = Session.Fecha;
                    Items.Add(_item);
                }
                return Items.Where(param => param.PARA_Clave == PARA_Clave).FirstOrDefault();
            }
        }

        public Parametros CUENTA_OCPP
        {
            get
            {
                String PARA_Clave = "CUENTA_OCPP";
                String PARA_Desc = "Otras Cta x Pagar(S/.|US$)";
                if (Items.Where(param => param.PARA_Clave == PARA_Clave).FirstOrDefault() == null)
                {
                    Parametros _item = new Parametros();
                    _item.EMPR_Codigo = Delfin.Controls.Entorno.ItemEmpresa.EMPR_Codigo;
                    _item.SUCR_Codigo = Delfin.Controls.Entorno.ItemSucursal.SUCR_Codigo;
                    _item.PARA_Desc = PARA_Desc;
                    _item.PARA_Clave = PARA_Clave;
                    _item.Instance = Infrastructure.Aspect.BusinessEntity.InstanceEntity.Added;
                    _item.AUDI_UsrCrea = Session.UserName;
                    _item.AUDI_FecCrea = Session.Fecha;
                    Items.Add(_item);
                }
                return Items.Where(param => param.PARA_Clave == PARA_Clave).FirstOrDefault();
            }
        }

        public Parametros CUENTA_OCPC
        {
            get
            {
                String PARA_Clave = "CUENTA_OCPC";
                String PARA_Desc = "Otras Cta x Cobrar(S/.|US$)";
                if (Items.Where(param => param.PARA_Clave == PARA_Clave).FirstOrDefault() == null)
                {
                    Parametros _item = new Parametros();
                    _item.EMPR_Codigo = Delfin.Controls.Entorno.ItemEmpresa.EMPR_Codigo;
                    _item.SUCR_Codigo = Delfin.Controls.Entorno.ItemSucursal.SUCR_Codigo;
                    _item.PARA_Desc = PARA_Desc;
                    _item.PARA_Clave = PARA_Clave;
                    _item.Instance = Infrastructure.Aspect.BusinessEntity.InstanceEntity.Added;
                    _item.AUDI_UsrCrea = Session.UserName;
                    _item.AUDI_FecCrea = Session.Fecha;
                    Items.Add(_item);
                }
                return Items.Where(param => param.PARA_Clave == PARA_Clave).FirstOrDefault();
            }
        }

        public Parametros CUENTA_CC_CHDIF
        {
            get
            {
                String PARA_Clave = "CUENTA_CC_CHDIF";
                String PARA_Desc = "Cuenta Por cobrar Cheque Diferido(S/.|US$)";
                if (Items.Where(param => param.PARA_Clave == PARA_Clave).FirstOrDefault() == null)
                {
                    Parametros _item = new Parametros();
                    _item.EMPR_Codigo = Delfin.Controls.Entorno.ItemEmpresa.EMPR_Codigo;
                    _item.SUCR_Codigo = Delfin.Controls.Entorno.ItemSucursal.SUCR_Codigo;
                    _item.PARA_Desc = PARA_Desc;
                    _item.PARA_Clave = PARA_Clave;
                    _item.Instance = Infrastructure.Aspect.BusinessEntity.InstanceEntity.Added;
                    _item.AUDI_UsrCrea = Session.UserName;
                    _item.AUDI_FecCrea = Session.Fecha;
                    Items.Add(_item);
                }
                return Items.Where(param => param.PARA_Clave == PARA_Clave).FirstOrDefault();
            }
        }

        public Parametros CUENTA_CP_CHDIF
        {
            get
            {
                String PARA_Clave = "CUENTA_CP_CHDIF";
                String PARA_Desc = "Cuenta Por Pagar Cheque Diferido(S/.|US$)";
                if (Items.Where(param => param.PARA_Clave == PARA_Clave).FirstOrDefault() == null)
                {
                    Parametros _item = new Parametros();
                    _item.EMPR_Codigo = Delfin.Controls.Entorno.ItemEmpresa.EMPR_Codigo;
                    _item.SUCR_Codigo = Delfin.Controls.Entorno.ItemSucursal.SUCR_Codigo;
                    _item.PARA_Desc = PARA_Desc;
                    _item.PARA_Clave = PARA_Clave;
                    _item.Instance = Infrastructure.Aspect.BusinessEntity.InstanceEntity.Added;
                    _item.AUDI_UsrCrea = Session.UserName;
                    _item.AUDI_FecCrea = Session.Fecha;
                    Items.Add(_item);
                }
                return Items.Where(param => param.PARA_Clave == PARA_Clave).FirstOrDefault();
            }
        }

        public Parametros CUENTA_COSTO_DIF
        {
            get
            {
                String PARA_Clave = "CUENTA_COSTO_DIF";
                String PARA_Desc = "Cuenta de Costo Diferido(S/.|US$)";
                if (Items.Where(param => param.PARA_Clave == PARA_Clave).FirstOrDefault() == null)
                {
                    Parametros _item = new Parametros();
                    _item.EMPR_Codigo = Delfin.Controls.Entorno.ItemEmpresa.EMPR_Codigo;
                    _item.SUCR_Codigo = Delfin.Controls.Entorno.ItemSucursal.SUCR_Codigo;
                    _item.PARA_Desc = PARA_Desc;
                    _item.PARA_Clave = PARA_Clave;
                    _item.Instance = Infrastructure.Aspect.BusinessEntity.InstanceEntity.Added;
                    _item.AUDI_UsrCrea = Session.UserName;
                    _item.AUDI_FecCrea = Session.Fecha;
                    Items.Add(_item);
                }
                return Items.Where(param => param.PARA_Clave == PARA_Clave).FirstOrDefault();
            }
        }

        public Parametros CUENTA_CC_DIF_V
        {
            get
            {
                String PARA_Clave = "CUENTA_CC_DIF_V";
                String PARA_Desc = "Cuenta de Costo Diferido(S/.|US$)";
                if (Items.Where(param => param.PARA_Clave == PARA_Clave).FirstOrDefault() == null)
                {
                    Parametros _item = new Parametros();
                    _item.EMPR_Codigo = Delfin.Controls.Entorno.ItemEmpresa.EMPR_Codigo;
                    _item.SUCR_Codigo = Delfin.Controls.Entorno.ItemSucursal.SUCR_Codigo;
                    _item.PARA_Desc = PARA_Desc;
                    _item.PARA_Clave = PARA_Clave;
                    _item.Instance = Infrastructure.Aspect.BusinessEntity.InstanceEntity.Added;
                    _item.AUDI_UsrCrea = Session.UserName;
                    _item.AUDI_FecCrea = Session.Fecha;
                    Items.Add(_item);
                }
                return Items.Where(param => param.PARA_Clave == PARA_Clave).FirstOrDefault();
            }
        }

        public Parametros CUENTA_CP_DIF_V
        {
            get
            {
                String PARA_Clave = "CUENTA_CP_DIF_V";
                String PARA_Desc = "Cuenta de Costo Diferido(S/.|US$)";
                if (Items.Where(param => param.PARA_Clave == PARA_Clave).FirstOrDefault() == null)
                {
                    Parametros _item = new Parametros();
                    _item.EMPR_Codigo = Delfin.Controls.Entorno.ItemEmpresa.EMPR_Codigo;
                    _item.SUCR_Codigo = Delfin.Controls.Entorno.ItemSucursal.SUCR_Codigo;
                    _item.PARA_Desc = PARA_Desc;
                    _item.PARA_Clave = PARA_Clave;
                    _item.Instance = Infrastructure.Aspect.BusinessEntity.InstanceEntity.Added;
                    _item.AUDI_UsrCrea = Session.UserName;
                    _item.AUDI_FecCrea = Session.Fecha;
                    Items.Add(_item);
                }
                return Items.Where(param => param.PARA_Clave == PARA_Clave).FirstOrDefault();
            }
        }

        public Parametros TR_RCOMPRAS
        {
            get
            {
                String PARA_Clave = "TR_RCOMPRAS";
                String PARA_Desc = "Libro de Compras";
                if (Items.Where(param => param.PARA_Clave == PARA_Clave).FirstOrDefault() == null)
                {
                    Parametros _item = new Parametros();
                    _item.EMPR_Codigo = Delfin.Controls.Entorno.ItemEmpresa.EMPR_Codigo;
                    _item.SUCR_Codigo = Delfin.Controls.Entorno.ItemSucursal.SUCR_Codigo;
                    _item.PARA_Desc = PARA_Desc;
                    _item.PARA_Clave = PARA_Clave;
                    _item.Instance = Infrastructure.Aspect.BusinessEntity.InstanceEntity.Added;
                    _item.AUDI_UsrCrea = Session.UserName;
                    _item.AUDI_FecCrea = Session.Fecha;
                    Items.Add(_item);
                }
                return Items.Where(param => param.PARA_Clave == PARA_Clave).FirstOrDefault();
            }
        }

        public Parametros TR_RVENTAS
        {
            get
            {
                String PARA_Clave = "TR_RVENTAS";
                String PARA_Desc = "Libro de Ventas";
                if (Items.Where(param => param.PARA_Clave == PARA_Clave).FirstOrDefault() == null)
                {
                    Parametros _item = new Parametros();
                    _item.EMPR_Codigo = Delfin.Controls.Entorno.ItemEmpresa.EMPR_Codigo;
                    _item.SUCR_Codigo = Delfin.Controls.Entorno.ItemSucursal.SUCR_Codigo;
                    _item.PARA_Desc = PARA_Desc;
                    _item.PARA_Clave = PARA_Clave;
                    _item.Instance = Infrastructure.Aspect.BusinessEntity.InstanceEntity.Added;
                    _item.AUDI_UsrCrea = Session.UserName;
                    _item.AUDI_FecCrea = Session.Fecha;
                    Items.Add(_item);
                }
                return Items.Where(param => param.PARA_Clave == PARA_Clave).FirstOrDefault();
            }
        }

        public Parametros TR_RCAJA
        {
            get
            {
                String PARA_Clave = "TR_RCAJA";
                String PARA_Desc = "Libro de Caja";
                if (Items.Where(param => param.PARA_Clave == PARA_Clave).FirstOrDefault() == null)
                {
                    Parametros _item = new Parametros();
                    _item.EMPR_Codigo = Delfin.Controls.Entorno.ItemEmpresa.EMPR_Codigo;
                    _item.SUCR_Codigo = Delfin.Controls.Entorno.ItemSucursal.SUCR_Codigo;
                    _item.PARA_Desc = PARA_Desc;
                    _item.PARA_Clave = PARA_Clave;
                    _item.Instance = Infrastructure.Aspect.BusinessEntity.InstanceEntity.Added;
                    _item.AUDI_UsrCrea = Session.UserName;
                    _item.AUDI_FecCrea = Session.Fecha;
                    Items.Add(_item);
                }
                return Items.Where(param => param.PARA_Clave == PARA_Clave).FirstOrDefault();
            }
        }

        public Parametros TR_DGENERAL
        {
            get
            {
                String PARA_Clave = "TR_DGENERAL";
                String PARA_Desc = "Libro Diario General";
                if (Items.Where(param => param.PARA_Clave == PARA_Clave).FirstOrDefault() == null)
                {
                    Parametros _item = new Parametros();
                    _item.EMPR_Codigo = Delfin.Controls.Entorno.ItemEmpresa.EMPR_Codigo;
                    _item.SUCR_Codigo = Delfin.Controls.Entorno.ItemSucursal.SUCR_Codigo;
                    _item.PARA_Desc = PARA_Desc;
                    _item.PARA_Clave = PARA_Clave;
                    _item.Instance = Infrastructure.Aspect.BusinessEntity.InstanceEntity.Added;
                    _item.AUDI_UsrCrea = Session.UserName;
                    _item.AUDI_FecCrea = Session.Fecha;
                    Items.Add(_item);
                }
                return Items.Where(param => param.PARA_Clave == PARA_Clave).FirstOrDefault();
            }
        }

        public Parametros TR_LPLANILLA
        {
            get
            {
                String PARA_Clave = "TR_LPLANILLA";
                String PARA_Desc = "Libro Planilla";
                if (Items.Where(param => param.PARA_Clave == PARA_Clave).FirstOrDefault() == null)
                {
                    Parametros _item = new Parametros();
                    _item.EMPR_Codigo = Delfin.Controls.Entorno.ItemEmpresa.EMPR_Codigo;
                    _item.SUCR_Codigo = Delfin.Controls.Entorno.ItemSucursal.SUCR_Codigo;
                    _item.PARA_Desc = PARA_Desc;
                    _item.PARA_Clave = PARA_Clave;
                    _item.Instance = Infrastructure.Aspect.BusinessEntity.InstanceEntity.Added;
                    _item.AUDI_UsrCrea = Session.UserName;
                    _item.AUDI_FecCrea = Session.Fecha;
                    Items.Add(_item);
                }
                return Items.Where(param => param.PARA_Clave == PARA_Clave).FirstOrDefault();
            }
        }

        public Parametros TR_RCDMANDATO
        {
            get
            {
                String PARA_Clave = "TR_RCDMANDATO";
                String PARA_Desc = "Libro Mandato";
                if (Items.Where(param => param.PARA_Clave == PARA_Clave).FirstOrDefault() == null)
                {
                    Parametros _item = new Parametros();
                    _item.EMPR_Codigo = Delfin.Controls.Entorno.ItemEmpresa.EMPR_Codigo;
                    _item.SUCR_Codigo = Delfin.Controls.Entorno.ItemSucursal.SUCR_Codigo;
                    _item.PARA_Desc = PARA_Desc;
                    _item.PARA_Clave = PARA_Clave;
                    _item.Instance = Infrastructure.Aspect.BusinessEntity.InstanceEntity.Added;
                    _item.AUDI_UsrCrea = Session.UserName;
                    _item.AUDI_FecCrea = Session.Fecha;
                    Items.Add(_item);
                }
                return Items.Where(param => param.PARA_Clave == PARA_Clave).FirstOrDefault();
            }
        }

        public Parametros TR_RCDSTATEMENT
        {
            get
            {
                String PARA_Clave = "TR_RCDSTATEMENT";
                String PARA_Desc = "Libro Otros Tráficos";
                if (Items.Where(param => param.PARA_Clave == PARA_Clave).FirstOrDefault() == null)
                {
                    Parametros _item = new Parametros();
                    _item.EMPR_Codigo = Delfin.Controls.Entorno.ItemEmpresa.EMPR_Codigo;
                    _item.SUCR_Codigo = Delfin.Controls.Entorno.ItemSucursal.SUCR_Codigo;
                    _item.PARA_Desc = PARA_Desc;
                    _item.PARA_Clave = PARA_Clave;
                    _item.Instance = Infrastructure.Aspect.BusinessEntity.InstanceEntity.Added;
                    _item.AUDI_UsrCrea = Session.UserName;
                    _item.AUDI_FecCrea = Session.Fecha;
                    Items.Add(_item);
                }
                return Items.Where(param => param.PARA_Clave == PARA_Clave).FirstOrDefault();
            }
        }

        public Parametros TR_RLDIARIO
        {
            get
            {
                String PARA_Clave = "TR_RLDIARIO";
                String PARA_Desc = "Libros de Diario";
                if (Items.Where(param => param.PARA_Clave == PARA_Clave).FirstOrDefault() == null)
                {
                    Parametros _item = new Parametros();
                    _item.EMPR_Codigo = Delfin.Controls.Entorno.ItemEmpresa.EMPR_Codigo;
                    _item.SUCR_Codigo = Delfin.Controls.Entorno.ItemSucursal.SUCR_Codigo;
                    _item.PARA_Desc = PARA_Desc;
                    _item.PARA_Clave = PARA_Clave;
                    _item.Instance = Infrastructure.Aspect.BusinessEntity.InstanceEntity.Added;
                    _item.AUDI_UsrCrea = Session.UserName;
                    _item.AUDI_FecCrea = Session.Fecha;
                    Items.Add(_item);
                }
                return Items.Where(param => param.PARA_Clave == PARA_Clave).FirstOrDefault();
            }
        }

        public Parametros GAS_DOc_PEN
        {
            get
            {
                String PARA_Clave = "GAS_DOc_PEN";
                String PARA_Desc = "Documento Pendiente";
                if (Items.Where(param => param.PARA_Clave == PARA_Clave).FirstOrDefault() == null)
                {
                    Parametros _item = new Parametros();
                    _item.EMPR_Codigo = Delfin.Controls.Entorno.ItemEmpresa.EMPR_Codigo;
                    _item.SUCR_Codigo = Delfin.Controls.Entorno.ItemSucursal.SUCR_Codigo;
                    _item.PARA_Desc = PARA_Desc;
                    _item.PARA_Clave = PARA_Clave;
                    _item.Instance = Infrastructure.Aspect.BusinessEntity.InstanceEntity.Added;
                    _item.AUDI_UsrCrea = Session.UserName;
                    _item.AUDI_FecCrea = Session.Fecha;
                    Items.Add(_item);
                }
                return Items.Where(param => param.PARA_Clave == PARA_Clave).FirstOrDefault();
            }
        }

        public Parametros RUC_DC
        {
            get
            {
                String PARA_Clave = "RUC_DC";
                String PARA_Desc = "RUC Delfin Collecting";
                if (Items.Where(param => param.PARA_Clave == PARA_Clave).FirstOrDefault() == null)
                {
                    Parametros _item = new Parametros();
                    _item.EMPR_Codigo = Delfin.Controls.Entorno.ItemEmpresa.EMPR_Codigo;
                    _item.SUCR_Codigo = Delfin.Controls.Entorno.ItemSucursal.SUCR_Codigo;
                    _item.PARA_Desc = PARA_Desc;
                    _item.PARA_Clave = PARA_Clave;
                    _item.Instance = Infrastructure.Aspect.BusinessEntity.InstanceEntity.Added;
                    _item.AUDI_UsrCrea = Session.UserName;
                    _item.AUDI_FecCrea = Session.Fecha;
                    Items.Add(_item);
                }
                return Items.Where(param => param.PARA_Clave == PARA_Clave).FirstOrDefault();
            }
        }

        public Parametros RUC_DG
        {
            get
            {
                String PARA_Clave = "RUC_DG";
                String PARA_Desc = "RUC Delfin Group";
                if (Items.Where(param => param.PARA_Clave == PARA_Clave).FirstOrDefault() == null)
                {
                    Parametros _item = new Parametros();
                    _item.EMPR_Codigo = Delfin.Controls.Entorno.ItemEmpresa.EMPR_Codigo;
                    _item.SUCR_Codigo = Delfin.Controls.Entorno.ItemSucursal.SUCR_Codigo;
                    _item.PARA_Desc = PARA_Desc;
                    _item.PARA_Clave = PARA_Clave;
                    _item.Instance = Infrastructure.Aspect.BusinessEntity.InstanceEntity.Added;
                    _item.AUDI_UsrCrea = Session.UserName;
                    _item.AUDI_FecCrea = Session.Fecha;
                    Items.Add(_item);
                }
                return Items.Where(param => param.PARA_Clave == PARA_Clave).FirstOrDefault();
            }
        }

        public Parametros CTAS_MANDATO
        {
            get
            {
                String PARA_Clave = "CTAS_MANDATO";
                String PARA_Desc = "Cuentas de Mandato";
                if (Items.Where(param => param.PARA_Clave == PARA_Clave).FirstOrDefault() == null)
                {
                    Parametros _item = new Parametros();
                    _item.EMPR_Codigo = Delfin.Controls.Entorno.ItemEmpresa.EMPR_Codigo;
                    _item.SUCR_Codigo = Delfin.Controls.Entorno.ItemSucursal.SUCR_Codigo;
                    _item.PARA_Desc = PARA_Desc;
                    _item.PARA_Clave = PARA_Clave;
                    _item.Instance = Infrastructure.Aspect.BusinessEntity.InstanceEntity.Added;
                    _item.AUDI_UsrCrea = Session.UserName;
                    _item.AUDI_FecCrea = Session.Fecha;
                    Items.Add(_item);
                }
                return Items.Where(param => param.PARA_Clave == PARA_Clave).FirstOrDefault();
            }
        }

        public Parametros TDO_A_DIARIO
        {
            get
            {
                String PARA_Clave = "TDO_A_DIARIO";
                String PARA_Desc = "Tipo de documentos enviados al Diario";
                if (Items.Where(param => param.PARA_Clave == PARA_Clave).FirstOrDefault() == null)
                {
                    Parametros _item = new Parametros();
                    _item.EMPR_Codigo = Delfin.Controls.Entorno.ItemEmpresa.EMPR_Codigo;
                    _item.SUCR_Codigo = Delfin.Controls.Entorno.ItemSucursal.SUCR_Codigo;
                    _item.PARA_Desc = PARA_Desc;
                    _item.PARA_Clave = PARA_Clave;
                    _item.Instance = Infrastructure.Aspect.BusinessEntity.InstanceEntity.Added;
                    _item.AUDI_UsrCrea = Session.UserName;
                    _item.AUDI_FecCrea = Session.Fecha;
                    Items.Add(_item);
                }
                return Items.Where(param => param.PARA_Clave == PARA_Clave).FirstOrDefault();
            }
        }

        public Parametros SERV_FL_AJUSTE_OP
        {
            get
            {
                String PARA_Clave = "SERV_FL_AJUSTE_OP";
                String PARA_Desc = "Cuentas de Mandato";
                if (Items.Where(param => param.PARA_Clave == PARA_Clave).FirstOrDefault() == null)
                {
                    Parametros _item = new Parametros();
                    _item.EMPR_Codigo = Delfin.Controls.Entorno.ItemEmpresa.EMPR_Codigo;
                    _item.SUCR_Codigo = Delfin.Controls.Entorno.ItemSucursal.SUCR_Codigo;
                    _item.PARA_Desc = PARA_Desc;
                    _item.PARA_Clave = PARA_Clave;
                    _item.Instance = Infrastructure.Aspect.BusinessEntity.InstanceEntity.Added;
                    _item.AUDI_UsrCrea = Session.UserName;
                    _item.AUDI_FecCrea = Session.Fecha;
                    Items.Add(_item);
                }
                return Items.Where(param => param.PARA_Clave == PARA_Clave).FirstOrDefault();
            }
        }

        public Parametros GAS_DOc_PENDIENTE
        {
            get
            {
                String PARA_Clave = "GAS_DOc_PENDIENTE";
                String PARA_Desc = "Cuentas de Mandato";
                if (Items.Where(param => param.PARA_Clave == PARA_Clave).FirstOrDefault() == null)
                {
                    Parametros _item = new Parametros();
                    _item.EMPR_Codigo = Delfin.Controls.Entorno.ItemEmpresa.EMPR_Codigo;
                    _item.SUCR_Codigo = Delfin.Controls.Entorno.ItemSucursal.SUCR_Codigo;
                    _item.PARA_Desc = PARA_Desc;
                    _item.PARA_Clave = PARA_Clave;
                    _item.Instance = Infrastructure.Aspect.BusinessEntity.InstanceEntity.Added;
                    _item.AUDI_UsrCrea = Session.UserName;
                    _item.AUDI_FecCrea = Session.Fecha;
                    Items.Add(_item);
                }
                return Items.Where(param => param.PARA_Clave == PARA_Clave).FirstOrDefault();
            }
        }

        public Parametros CUENTA_COS_DIF_OT
        {
            get
            {
                String PARA_Clave = "CUENTA_COS_DIF_OT";
                String PARA_Desc = "Cuentas de Mandato";
                if (Items.Where(param => param.PARA_Clave == PARA_Clave).FirstOrDefault() == null)
                {
                    Parametros _item = new Parametros();
                    _item.EMPR_Codigo = Delfin.Controls.Entorno.ItemEmpresa.EMPR_Codigo;
                    _item.SUCR_Codigo = Delfin.Controls.Entorno.ItemSucursal.SUCR_Codigo;
                    _item.PARA_Desc = PARA_Desc;
                    _item.PARA_Clave = PARA_Clave;
                    _item.Instance = Infrastructure.Aspect.BusinessEntity.InstanceEntity.Added;
                    _item.AUDI_UsrCrea = Session.UserName;
                    _item.AUDI_FecCrea = Session.Fecha;
                    Items.Add(_item);
                }
                return Items.Where(param => param.PARA_Clave == PARA_Clave).FirstOrDefault();
            }
        }

        public Parametros TR_CIERR_001
        {
            get
            {
                String PARA_Clave = "TR_CIERR_001";
                String PARA_Desc = "Libro Compras";
                if (Items.Where(param => param.PARA_Clave == PARA_Clave).FirstOrDefault() == null)
                {
                    Parametros _item = new Parametros();
                    _item.EMPR_Codigo = Delfin.Controls.Entorno.ItemEmpresa.EMPR_Codigo;
                    _item.SUCR_Codigo = Delfin.Controls.Entorno.ItemSucursal.SUCR_Codigo;
                    _item.PARA_Desc = PARA_Desc;
                    _item.PARA_Clave = PARA_Clave;
                    _item.Instance = Infrastructure.Aspect.BusinessEntity.InstanceEntity.Added;
                    _item.AUDI_UsrCrea = Session.UserName;
                    _item.AUDI_FecCrea = Session.Fecha;
                    Items.Add(_item);
                }
                return Items.Where(param => param.PARA_Clave == PARA_Clave).FirstOrDefault();
            }
        }

        public Parametros TR_CIERR_002
        {
            get
            {
                String PARA_Clave = "TR_CIERR_002";
                String PARA_Desc = "Libro Venta";
                if (Items.Where(param => param.PARA_Clave == PARA_Clave).FirstOrDefault() == null)
                {
                    Parametros _item = new Parametros();
                    _item.EMPR_Codigo = Delfin.Controls.Entorno.ItemEmpresa.EMPR_Codigo;
                    _item.SUCR_Codigo = Delfin.Controls.Entorno.ItemSucursal.SUCR_Codigo;
                    _item.PARA_Desc = PARA_Desc;
                    _item.PARA_Clave = PARA_Clave;
                    _item.Instance = Infrastructure.Aspect.BusinessEntity.InstanceEntity.Added;
                    _item.AUDI_UsrCrea = Session.UserName;
                    _item.AUDI_FecCrea = Session.Fecha;
                    Items.Add(_item);
                }
                return Items.Where(param => param.PARA_Clave == PARA_Clave).FirstOrDefault();
            }
        }

        public Parametros TR_CIERR_003
        {
            get
            {
                String PARA_Clave = "TR_CIERR_003";
                String PARA_Desc = "Libro Compras";
                if (Items.Where(param => param.PARA_Clave == PARA_Clave).FirstOrDefault() == null)
                {
                    Parametros _item = new Parametros();
                    _item.EMPR_Codigo = Delfin.Controls.Entorno.ItemEmpresa.EMPR_Codigo;
                    _item.SUCR_Codigo = Delfin.Controls.Entorno.ItemSucursal.SUCR_Codigo;
                    _item.PARA_Desc = PARA_Desc;
                    _item.PARA_Clave = PARA_Clave;
                    _item.Instance = Infrastructure.Aspect.BusinessEntity.InstanceEntity.Added;
                    _item.AUDI_UsrCrea = Session.UserName;
                    _item.AUDI_FecCrea = Session.Fecha;
                    Items.Add(_item);
                }
                return Items.Where(param => param.PARA_Clave == PARA_Clave).FirstOrDefault();
            }
        }

        public Parametros TR_CIERR_004
        {
            get
            {
                String PARA_Clave = "TR_CIERR_004";
                String PARA_Desc = "Libro Diario";
                if (Items.Where(param => param.PARA_Clave == PARA_Clave).FirstOrDefault() == null)
                {
                    Parametros _item = new Parametros();
                    _item.EMPR_Codigo = Delfin.Controls.Entorno.ItemEmpresa.EMPR_Codigo;
                    _item.SUCR_Codigo = Delfin.Controls.Entorno.ItemSucursal.SUCR_Codigo;
                    _item.PARA_Desc = PARA_Desc;
                    _item.PARA_Clave = PARA_Clave;
                    _item.Instance = Infrastructure.Aspect.BusinessEntity.InstanceEntity.Added;
                    _item.AUDI_UsrCrea = Session.UserName;
                    _item.AUDI_FecCrea = Session.Fecha;
                    Items.Add(_item);
                }
                return Items.Where(param => param.PARA_Clave == PARA_Clave).FirstOrDefault();
            }
        }

        public Parametros TR_CIERR_005
        {
            get
            {
                String PARA_Clave = "TR_CIERR_005";
                String PARA_Desc = "Libro Planillas";
                if (Items.Where(param => param.PARA_Clave == PARA_Clave).FirstOrDefault() == null)
                {
                    Parametros _item = new Parametros();
                    _item.EMPR_Codigo = Delfin.Controls.Entorno.ItemEmpresa.EMPR_Codigo;
                    _item.SUCR_Codigo = Delfin.Controls.Entorno.ItemSucursal.SUCR_Codigo;
                    _item.PARA_Desc = PARA_Desc;
                    _item.PARA_Clave = PARA_Clave;
                    _item.Instance = Infrastructure.Aspect.BusinessEntity.InstanceEntity.Added;
                    _item.AUDI_UsrCrea = Session.UserName;
                    _item.AUDI_FecCrea = Session.Fecha;
                    Items.Add(_item);
                }
                return Items.Where(param => param.PARA_Clave == PARA_Clave).FirstOrDefault();
            }
        }

        public Parametros TR_CIERR_006
        {
            get
            {
                String PARA_Clave = "TR_CIERR_006";
                String PARA_Desc = "Libro Mandato";
                if (Items.Where(param => param.PARA_Clave == PARA_Clave).FirstOrDefault() == null)
                {
                    Parametros _item = new Parametros();
                    _item.EMPR_Codigo = Delfin.Controls.Entorno.ItemEmpresa.EMPR_Codigo;
                    _item.SUCR_Codigo = Delfin.Controls.Entorno.ItemSucursal.SUCR_Codigo;
                    _item.PARA_Desc = PARA_Desc;
                    _item.PARA_Clave = PARA_Clave;
                    _item.Instance = Infrastructure.Aspect.BusinessEntity.InstanceEntity.Added;
                    _item.AUDI_UsrCrea = Session.UserName;
                    _item.AUDI_FecCrea = Session.Fecha;
                    Items.Add(_item);
                }
                return Items.Where(param => param.PARA_Clave == PARA_Clave).FirstOrDefault();
            }
        }

        public Parametros TR_CIERR_007
        {
            get
            {
                String PARA_Clave = "TR_CIERR_007";
                String PARA_Desc = "Libro Otros Traficos";
                if (Items.Where(param => param.PARA_Clave == PARA_Clave).FirstOrDefault() == null)
                {
                    Parametros _item = new Parametros();
                    _item.EMPR_Codigo = Delfin.Controls.Entorno.ItemEmpresa.EMPR_Codigo;
                    _item.SUCR_Codigo = Delfin.Controls.Entorno.ItemSucursal.SUCR_Codigo;
                    _item.PARA_Desc = PARA_Desc;
                    _item.PARA_Clave = PARA_Clave;
                    _item.Instance = Infrastructure.Aspect.BusinessEntity.InstanceEntity.Added;
                    _item.AUDI_UsrCrea = Session.UserName;
                    _item.AUDI_FecCrea = Session.Fecha;
                    Items.Add(_item);
                }
                return Items.Where(param => param.PARA_Clave == PARA_Clave).FirstOrDefault();
            }
        }
        #endregion

        #region [ Finanzas ]

        public Parametros DET_DIASDETRACCION
        {
            get
            {
                String PARA_Clave = "DET_DIASDETRACCION";
                String PARA_Desc = "Dias de Detracción";
                if (Items.Where(param => param.PARA_Clave == PARA_Clave).FirstOrDefault() == null)
                {
                    Parametros _item = new Parametros();
                    _item.EMPR_Codigo = Delfin.Controls.Entorno.ItemEmpresa.EMPR_Codigo;
                    _item.SUCR_Codigo = Delfin.Controls.Entorno.ItemSucursal.SUCR_Codigo;
                    _item.PARA_Desc = PARA_Desc;
                    _item.PARA_Clave = PARA_Clave;
                    _item.Instance = Infrastructure.Aspect.BusinessEntity.InstanceEntity.Added;
                    _item.AUDI_UsrCrea = Session.UserName;
                    _item.AUDI_FecCrea = Session.Fecha;
                    Items.Add(_item);
                }
                return Items.Where(param => param.PARA_Clave == PARA_Clave).FirstOrDefault();
            }
        }


        public Parametros DET_REDONDEONORMAL
        {
            get
            {
                String PARA_Clave = "DET_REDONDEONORMAL";
                String PARA_Desc = "Aplicación del redondeo de la detracción .";
                if (Items.Where(param => param.PARA_Clave == PARA_Clave).FirstOrDefault() == null)
                {
                    Parametros _item = new Parametros();
                    _item.EMPR_Codigo = Delfin.Controls.Entorno.ItemEmpresa.EMPR_Codigo;
                    _item.SUCR_Codigo = Delfin.Controls.Entorno.ItemSucursal.SUCR_Codigo;
                    _item.PARA_Desc = PARA_Desc;
                    _item.PARA_Clave = PARA_Clave;
                    _item.Instance = Infrastructure.Aspect.BusinessEntity.InstanceEntity.Added;
                    _item.AUDI_UsrCrea = Session.UserName;
                    _item.AUDI_FecCrea = Session.Fecha;
                    Items.Add(_item);
                }
                return Items.Where(param => param.PARA_Clave == PARA_Clave).FirstOrDefault();
            }
        }
        public Parametros CCCT_SERIEDIARIO
        {
            get
            {
                String PARA_Clave = "CCCT_SERIEDIARIO";
                String PARA_Desc = "Serie que se define para los doc. en diario.";
                if (Items.Where(param => param.PARA_Clave == PARA_Clave).FirstOrDefault() == null)
                {
                    Parametros _item = new Parametros();
                    _item.EMPR_Codigo = Delfin.Controls.Entorno.ItemEmpresa.EMPR_Codigo;
                    _item.SUCR_Codigo = Delfin.Controls.Entorno.ItemSucursal.SUCR_Codigo;
                    _item.PARA_Desc = PARA_Desc;
                    _item.PARA_Clave = PARA_Clave;
                    _item.Instance = Infrastructure.Aspect.BusinessEntity.InstanceEntity.Added;
                    _item.AUDI_UsrCrea = Session.UserName;
                    _item.AUDI_FecCrea = Session.Fecha;
                    Items.Add(_item);
                }
                return Items.Where(param => param.PARA_Clave == PARA_Clave).FirstOrDefault();
            }
        }
        public Parametros CCCT_TIPODOCUMENTO
        {
            get
            {
                String PARA_Clave = "CCCT_TIPODOCUMENTO";
                String PARA_Desc = "Tipo de Documento Sin Numero.";
                if (Items.Where(param => param.PARA_Clave == PARA_Clave).FirstOrDefault() == null)
                {
                    Parametros _item = new Parametros();
                    _item.EMPR_Codigo = Delfin.Controls.Entorno.ItemEmpresa.EMPR_Codigo;
                    _item.SUCR_Codigo = Delfin.Controls.Entorno.ItemSucursal.SUCR_Codigo;
                    _item.PARA_Desc = PARA_Desc;
                    _item.PARA_Clave = PARA_Clave;
                    _item.Instance = Infrastructure.Aspect.BusinessEntity.InstanceEntity.Added;
                    _item.AUDI_UsrCrea = Session.UserName;
                    _item.AUDI_FecCrea = Session.Fecha;
                    Items.Add(_item);
                }
                return Items.Where(param => param.PARA_Clave == PARA_Clave).FirstOrDefault();
            }
        }

        public Parametros MOVI_CHQBLANCO
        {
            get
            {
                String PARA_Clave = "MOVI_CHQBLANCO";
                String PARA_Desc = "Tipos Movimiento Cheque en Blanco.";
                if (Items.Where(param => param.PARA_Clave == PARA_Clave).FirstOrDefault() == null)
                {
                    Parametros _item = new Parametros();
                    _item.EMPR_Codigo = Delfin.Controls.Entorno.ItemEmpresa.EMPR_Codigo;
                    _item.SUCR_Codigo = Delfin.Controls.Entorno.ItemSucursal.SUCR_Codigo;
                    _item.PARA_Desc = PARA_Desc;
                    _item.PARA_Clave = PARA_Clave;
                    _item.Instance = Infrastructure.Aspect.BusinessEntity.InstanceEntity.Added;
                    _item.AUDI_UsrCrea = Session.UserName;
                    _item.AUDI_FecCrea = Session.Fecha;
                    Items.Add(_item);
                }
                return Items.Where(param => param.PARA_Clave == PARA_Clave).FirstOrDefault();
            }
        }
        public Parametros TIPO_DES_GBAN
        {
            get
            {
                String PARA_Clave = "TIPO_DES_GBAN";
                String PARA_Desc = "Tipos De Descuadre - Gasto Bancario.";
                if (Items.Where(param => param.PARA_Clave == PARA_Clave).FirstOrDefault() == null)
                {
                    Parametros _item = new Parametros();
                    _item.EMPR_Codigo = Delfin.Controls.Entorno.ItemEmpresa.EMPR_Codigo;
                    _item.SUCR_Codigo = Delfin.Controls.Entorno.ItemSucursal.SUCR_Codigo;
                    _item.PARA_Desc = PARA_Desc;
                    _item.PARA_Clave = PARA_Clave;
                    _item.Instance = Infrastructure.Aspect.BusinessEntity.InstanceEntity.Added;
                    _item.AUDI_UsrCrea = Session.UserName;
                    _item.AUDI_FecCrea = Session.Fecha;
                    Items.Add(_item);
                }
                return Items.Where(param => param.PARA_Clave == PARA_Clave).FirstOrDefault();
            }
        }
        public Parametros TIPO_MOV_DESDIF
        {
            get
            {
                String PARA_Clave = "TIPO_MOV_DESDIF";
                String PARA_Desc = "Tipos De Movimiento - Para diferido.";
                if (Items.Where(param => param.PARA_Clave == PARA_Clave).FirstOrDefault() == null)
                {
                    Parametros _item = new Parametros();
                    _item.EMPR_Codigo = Delfin.Controls.Entorno.ItemEmpresa.EMPR_Codigo;
                    _item.SUCR_Codigo = Delfin.Controls.Entorno.ItemSucursal.SUCR_Codigo;
                    _item.PARA_Desc = PARA_Desc;
                    _item.PARA_Clave = PARA_Clave;
                    _item.Instance = Infrastructure.Aspect.BusinessEntity.InstanceEntity.Added;
                    _item.AUDI_UsrCrea = Session.UserName;
                    _item.AUDI_FecCrea = Session.Fecha;
                    Items.Add(_item);
                }
                return Items.Where(param => param.PARA_Clave == PARA_Clave).FirstOrDefault();
            }
        }
        public Parametros TIPO_TDO_OVDG
        {
            get
            {
                String PARA_Clave = "TIPO_TDO_OVDG";
                String PARA_Desc = "Tipos De Documento OV para Docs Diferidos.";
                if (Items.Where(param => param.PARA_Clave == PARA_Clave).FirstOrDefault() == null)
                {
                    Parametros _item = new Parametros();
                    _item.EMPR_Codigo = Delfin.Controls.Entorno.ItemEmpresa.EMPR_Codigo;
                    _item.SUCR_Codigo = Delfin.Controls.Entorno.ItemSucursal.SUCR_Codigo;
                    _item.PARA_Desc = PARA_Desc;
                    _item.PARA_Clave = PARA_Clave;
                    _item.Instance = Infrastructure.Aspect.BusinessEntity.InstanceEntity.Added;
                    _item.AUDI_UsrCrea = Session.UserName;
                    _item.AUDI_FecCrea = Session.Fecha;
                    Items.Add(_item);
                }
                return Items.Where(param => param.PARA_Clave == PARA_Clave).FirstOrDefault();
            }
        }
        public Parametros CUENTA_DCHINA
        {
            get
            {
                String PARA_Clave = "CUENTA_DCHINA";
                String PARA_Desc = "Cuenta de Mandato - Delfin China.";
                if (Items.Where(param => param.PARA_Clave == PARA_Clave).FirstOrDefault() == null)
                {
                    Parametros _item = new Parametros();
                    _item.EMPR_Codigo = Delfin.Controls.Entorno.ItemEmpresa.EMPR_Codigo;
                    _item.SUCR_Codigo = Delfin.Controls.Entorno.ItemSucursal.SUCR_Codigo;
                    _item.PARA_Desc = PARA_Desc;
                    _item.PARA_Clave = PARA_Clave;
                    _item.Instance = Infrastructure.Aspect.BusinessEntity.InstanceEntity.Added;
                    _item.AUDI_UsrCrea = Session.UserName;
                    _item.AUDI_FecCrea = Session.Fecha;
                    Items.Add(_item);
                }
                return Items.Where(param => param.PARA_Clave == PARA_Clave).FirstOrDefault();
            }
        }
        public Parametros RUC_DCHINA
        {
            get
            {
                String PARA_Clave = "RUC_DCHINA";
                String PARA_Desc = "RUC - Delfin China.";
                if (Items.Where(param => param.PARA_Clave == PARA_Clave).FirstOrDefault() == null)
                {
                    Parametros _item = new Parametros();
                    _item.EMPR_Codigo = Delfin.Controls.Entorno.ItemEmpresa.EMPR_Codigo;
                    _item.SUCR_Codigo = Delfin.Controls.Entorno.ItemSucursal.SUCR_Codigo;
                    _item.PARA_Desc = PARA_Desc;
                    _item.PARA_Clave = PARA_Clave;
                    _item.Instance = Infrastructure.Aspect.BusinessEntity.InstanceEntity.Added;
                    _item.AUDI_UsrCrea = Session.UserName;
                    _item.AUDI_FecCrea = Session.Fecha;
                    Items.Add(_item);
                }
                return Items.Where(param => param.PARA_Clave == PARA_Clave).FirstOrDefault();
            }
        }

        #endregion

        #region [ GLOSA ]
        public Parametros FC_EXONERADO
        {
            get
            {
                String PARA_Clave = "FC_EXONERADO";
                String PARA_Desc = "MENSAJE PARA DOCUMENTOS EXONERADOS DE IGV";
                if (Items.Where(param => param.PARA_Clave == PARA_Clave).FirstOrDefault() == null)
                {
                    Parametros _item = new Parametros();
                    _item.EMPR_Codigo = Delfin.Controls.Entorno.ItemEmpresa.EMPR_Codigo;
                    _item.SUCR_Codigo = Delfin.Controls.Entorno.ItemSucursal.SUCR_Codigo;
                    _item.PARA_Desc = PARA_Desc;
                    _item.PARA_Clave = PARA_Clave;
                    _item.Instance = Infrastructure.Aspect.BusinessEntity.InstanceEntity.Added;
                    _item.AUDI_UsrCrea = Session.UserName;
                    _item.AUDI_FecCrea = Session.Fecha;
                    Items.Add(_item);
                }
                return Items.Where(param => param.PARA_Clave == PARA_Clave).FirstOrDefault();
            }
        }
        public Parametros FC_OPSUJETAPOT
        {
            get
            {
                String PARA_Clave = "FC_OPSUJETAPOT";
                String PARA_Desc = "MENSAJE PARA DOCUMENTOS FACTURA";
                if (Items.Where(param => param.PARA_Clave == PARA_Clave).FirstOrDefault() == null)
                {
                    Parametros _item = new Parametros();
                    _item.EMPR_Codigo = Delfin.Controls.Entorno.ItemEmpresa.EMPR_Codigo;
                    _item.SUCR_Codigo = Delfin.Controls.Entorno.ItemSucursal.SUCR_Codigo;
                    _item.PARA_Desc = PARA_Desc;
                    _item.PARA_Clave = PARA_Clave;
                    _item.Instance = Infrastructure.Aspect.BusinessEntity.InstanceEntity.Added;
                    _item.AUDI_UsrCrea = Session.UserName;
                    _item.AUDI_FecCrea = Session.Fecha;
                    Items.Add(_item);
                }
                return Items.Where(param => param.PARA_Clave == PARA_Clave).FirstOrDefault();
            }
        }
        #endregion

        #region [ FACTURACION ]
        public Parametros FAC_TDO
        {
            get
            {
                String PARA_Clave = "FAC_TDO";
                String PARA_Desc = "TIPO DE DOCUMENTO PARA LA FACTURACIÓN";
                if (Items.Where(param => param.PARA_Clave == PARA_Clave).FirstOrDefault() == null)
                {
                    Parametros _item = new Parametros();
                    _item.EMPR_Codigo = Delfin.Controls.Entorno.ItemEmpresa.EMPR_Codigo;
                    _item.SUCR_Codigo = Delfin.Controls.Entorno.ItemSucursal.SUCR_Codigo;
                    _item.PARA_Desc = PARA_Desc;
                    _item.PARA_Clave = PARA_Clave;
                    _item.Instance = Infrastructure.Aspect.BusinessEntity.InstanceEntity.Added;
                    _item.AUDI_UsrCrea = Session.UserName;
                    _item.AUDI_FecCrea = Session.Fecha;
                    Items.Add(_item);
                }
                return Items.Where(param => param.PARA_Clave == PARA_Clave).FirstOrDefault();
            }
        }
        public Parametros FAC_TDO_OP
        {
            get
            {
                String PARA_Clave = "FAC_TDO_OP";
                String PARA_Desc = "TIPO DE DOCUMENTO PARA LA FACTURACIÓN OP";
                if (Items.Where(param => param.PARA_Clave == PARA_Clave).FirstOrDefault() == null)
                {
                    Parametros _item = new Parametros();
                    _item.EMPR_Codigo = Delfin.Controls.Entorno.ItemEmpresa.EMPR_Codigo;
                    _item.SUCR_Codigo = Delfin.Controls.Entorno.ItemSucursal.SUCR_Codigo;
                    _item.PARA_Desc = PARA_Desc;
                    _item.PARA_Clave = PARA_Clave;
                    _item.Instance = Infrastructure.Aspect.BusinessEntity.InstanceEntity.Added;
                    _item.AUDI_UsrCrea = Session.UserName;
                    _item.AUDI_FecCrea = Session.Fecha;
                    Items.Add(_item);
                }
                return Items.Where(param => param.PARA_Clave == PARA_Clave).FirstOrDefault();
            }
        }
        public Parametros FAC_TDO_OV
        {
            get
            {
                String PARA_Clave = "FAC_TDO_OV";
                String PARA_Desc = "TIPO DE DOCUMENTO PARA LA FACTURACIÓN OV";
                if (Items.Where(param => param.PARA_Clave == PARA_Clave).FirstOrDefault() == null)
                {
                    Parametros _item = new Parametros();
                    _item.EMPR_Codigo = Delfin.Controls.Entorno.ItemEmpresa.EMPR_Codigo;
                    _item.SUCR_Codigo = Delfin.Controls.Entorno.ItemSucursal.SUCR_Codigo;
                    _item.PARA_Desc = PARA_Desc;
                    _item.PARA_Clave = PARA_Clave;
                    _item.Instance = Infrastructure.Aspect.BusinessEntity.InstanceEntity.Added;
                    _item.AUDI_UsrCrea = Session.UserName;
                    _item.AUDI_FecCrea = Session.Fecha;
                    Items.Add(_item);
                }
                return Items.Where(param => param.PARA_Clave == PARA_Clave).FirstOrDefault();
            }
        }
        public Parametros PREF_TDO_SLI
        {
            get
            {
                String PARA_Clave = "PREF_TDO_SLI";
                String PARA_Desc = "TIPO DE DOCUMENTO PARA LA PREFACTURACION DE SLI";
                if (Items.Where(param => param.PARA_Clave == PARA_Clave).FirstOrDefault() == null)
                {
                    Parametros _item = new Parametros();
                    _item.EMPR_Codigo = Delfin.Controls.Entorno.ItemEmpresa.EMPR_Codigo;
                    _item.SUCR_Codigo = Delfin.Controls.Entorno.ItemSucursal.SUCR_Codigo;
                    _item.PARA_Desc = PARA_Desc;
                    _item.PARA_Clave = PARA_Clave;
                    _item.Instance = Infrastructure.Aspect.BusinessEntity.InstanceEntity.Added;
                    _item.AUDI_UsrCrea = Session.UserName;
                    _item.AUDI_FecCrea = Session.Fecha;
                    Items.Add(_item);
                }
                return Items.Where(param => param.PARA_Clave == PARA_Clave).FirstOrDefault();
            }
        }
        public Parametros PREF_TDO_ILD
        {
            get
            {
                String PARA_Clave = "ILD_TIPOSTDO";
                String PARA_Desc = "TIPO DE DOCUMENTO PARA LA EL INGRESO LIBRE DE DOCUMENTOS";
                if (Items.Where(param => param.PARA_Clave == PARA_Clave).FirstOrDefault() == null)
                {
                    Parametros _item = new Parametros();
                    _item.EMPR_Codigo = Delfin.Controls.Entorno.ItemEmpresa.EMPR_Codigo;
                    _item.SUCR_Codigo = Delfin.Controls.Entorno.ItemSucursal.SUCR_Codigo;
                    _item.PARA_Desc = PARA_Desc;
                    _item.PARA_Clave = PARA_Clave;
                    _item.Instance = Infrastructure.Aspect.BusinessEntity.InstanceEntity.Added;
                    _item.AUDI_UsrCrea = Session.UserName;
                    _item.AUDI_FecCrea = Session.Fecha;
                    Items.Add(_item);
                }
                return Items.Where(param => param.PARA_Clave == PARA_Clave).FirstOrDefault();
            }
        }

        public Parametros TIPO_TDO_NCS
        {
            get
            {
                String PARA_Clave = "TIPO_TDO_NCS";
                String PARA_Desc = "TIPO DE DOCUMENTO NOTA DE CREDITO";
                if (Items.Where(param => param.PARA_Clave == PARA_Clave).FirstOrDefault() == null)
                {
                    Parametros _item = new Parametros();
                    _item.EMPR_Codigo = Delfin.Controls.Entorno.ItemEmpresa.EMPR_Codigo;
                    _item.SUCR_Codigo = Delfin.Controls.Entorno.ItemSucursal.SUCR_Codigo;
                    _item.PARA_Desc = PARA_Desc;
                    _item.PARA_Clave = PARA_Clave;
                    _item.Instance = Infrastructure.Aspect.BusinessEntity.InstanceEntity.Added;
                    _item.AUDI_UsrCrea = Session.UserName;
                    _item.AUDI_FecCrea = Session.Fecha;
                    Items.Add(_item);
                }
                return Items.Where(param => param.PARA_Clave == PARA_Clave).FirstOrDefault();
            }
        }
        #endregion

        public ObservableCollection<Entities.Entidad> getEntidadEjecutivos()
        {
            try
            {
                ObservableCollection<Entities.Entidad> x_listEntidad = new ObservableCollection<Entidad>();
                x_listEntidad = Client.GetAllEntidad(Delfin.Controls.EntidadClear.GetCodigoTipoEntidad(Controls.TiposEntidad.TIPE_Ejecutivo), null);
                return x_listEntidad;
            }
            catch (Exception)
            { return null; }
        }

        public ObservableCollection<Entities.Tipos> getTiposCuentas()
        {
            try
            {
                ObservableCollection<Entities.Tipos> x_listCuentas = new ObservableCollection<Tipos>();

                ObservableCollection<Infrastructure.Aspect.DataAccess.DataAccessFilterSQL> _listFilters = new ObservableCollection<Infrastructure.Aspect.DataAccess.DataAccessFilterSQL>();
                _listFilters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@CUEN_Ano", FilterValue = DateTime.Now.Year, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.Char, FilterSize = 4 });
                System.Data.DataTable dt = Client.GetDTAnexos("CON_CUENSS_TodosAyuda", _listFilters);

                foreach (System.Data.DataRow iDT in dt.Rows)
                {
                    Entities.Tipos cta = new Tipos();
                    cta.TIPO_CodTipo = iDT["CUEN_Desc"].ToString();
                    cta.TIPO_Desc1 = iDT["CUEN_Codigo"].ToString().Trim();

                    x_listCuentas.Add(cta);
                }

                return x_listCuentas;
            }
            catch (Exception)
            { return null; }
        }

        #endregion

        #region [ Metodos ]
        public void Editar()
        {
            try
            {

                MView.ClearItem();
                Items = Client.GetAllParametros();
                MView.SetItem();
                ((PAR000MView)MView).ShowDialog();
            }
            catch (Exception ex)
            { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Title, Infrastructure.Aspect.Constants.Mensajes.EditPresenter, ex); }
        }
        public bool Guardar()
        {
            try
            {
                if (MView.GetItem())
                {

                    if (Client.SaveParametros(Items))
                    {
                        Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeSatisfactorio(Title, "Se ha guardado satisfactoriamente.");
                        return true;
                    }
                    else
                    {
                        Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Title, "Ha ocurrido un error al guardar los parámetros.");
                        return false;
                    }
                }
                else
                {
                    Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Title, "Faltan ingresar algunos valores.");
                    return false;
                }
            }
            catch (Exception ex)
            {
                Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Title, Infrastructure.Aspect.Constants.Mensajes.SavePresenter, ex);
                return false;
            }
        }
        public System.Windows.Forms.DialogResult GuardarCambios()
        {
            try
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
            catch (Exception ex)
            {
                Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Title, Infrastructure.Aspect.Constants.Mensajes.SavePresenter, ex);
                return System.Windows.Forms.DialogResult.Cancel;
            }
        }
        public NextAdmin.BusinessLogic.Usuarios AyudaUsuario(String Usuario)
        {
            try
            {
                NextAdmin.BusinessLogic.Usuarios _usuario = null;

                System.Data.DataTable dtAyuda = ListUsuarios.ToDataTable(); ;
                if (!String.IsNullOrEmpty(Usuario))
                {
                    dtAyuda.DefaultView.RowFilter = "USUA_CodUsr LIKE " + Usuario;
                    dtAyuda = dtAyuda.DefaultView.ToTable();
                }

                if (dtAyuda.Rows.Count == 0)
                { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Title, "No se encontraron coincidencias."); }
                else if (dtAyuda.Rows.Count == 1)
                {
                    Int32 _USUA_Codigo;
                    if (Int32.TryParse(dtAyuda.Rows[0]["USUA_Codigo"].ToString(), out _USUA_Codigo))
                    { _usuario = ListUsuarios.Where(usua => usua.USUA_Codigo == _USUA_Codigo).FirstOrDefault(); }
                }
                else
                {
                    List<Infrastructure.WinForms.Controls.ColumnaAyuda> _columnas = new List<Infrastructure.WinForms.Controls.ColumnaAyuda>();
                    _columnas.Add(new Infrastructure.WinForms.Controls.ColumnaAyuda()
                    {
                        Index = 0,
                        ColumnName = "USUA_CodUsr",
                        ColumnCaption = "Usuario"
                    });
                    _columnas.Add(new Infrastructure.WinForms.Controls.ColumnaAyuda()
                    {
                        Index = 1,
                        ColumnName = "USUA_Nombres",
                        ColumnCaption = "Nombre"
                    });
                    _columnas.Add(new Infrastructure.WinForms.Controls.ColumnaAyuda()
                    {
                        Index = 2,
                        ColumnName = "USUA_Email",
                        ColumnCaption = "E-mail"
                    });
                    _columnas.Add(new Infrastructure.WinForms.Controls.ColumnaAyuda()
                    {
                        Index = 3,
                        ColumnName = "USUA_Codigo",
                        ColumnCaption = "Código"
                    });
                    Infrastructure.WinForms.Controls.Ayuda x_Ayuda = new Infrastructure.WinForms.Controls.Ayuda("Ayuda Usuarior", dtAyuda, false, _columnas);
                    if (x_Ayuda.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        Int32 _USUA_Codigo;
                        if (Int32.TryParse(x_Ayuda.Respuesta.Rows[0]["USUA_Codigo"].ToString(), out _USUA_Codigo))
                        { _usuario = ListUsuarios.Where(usua => usua.USUA_Codigo == _USUA_Codigo).FirstOrDefault(); }
                    }
                }

                return _usuario;
            }
            catch (Exception ex)
            {
                Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Title, "Ha ocurrido un error en la Ayuda de Usuarios", ex);
                return null;
            }
        }
        #endregion
    }
}