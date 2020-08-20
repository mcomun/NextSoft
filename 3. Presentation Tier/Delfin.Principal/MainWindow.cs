using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ConceptCave.WaitCursor;
using Delfin.Controls;
using Delfin.Principal.Properties;
using Delfin.ServiceProxy;
using Infrastructure.Aspect.Patterns;
using Infrastructure.Client.FormClose;
using Infrastructure.Client.Services.Session;
using Infrastructure.WinFormsControls;
using System.Configuration;
using Microsoft.Practices.Unity.Configuration;
using Microsoft.Practices.Unity;
using System.Collections.ObjectModel;
using Telerik.WinControls.UI;
//using Delfin.Principal;
//using Delfin.Principal;
using System.Runtime.InteropServices;
using Delfin.ServiceContracts;
using Infrastructure.Aspect.DataAccess;

namespace Delfin.Principal
{
   public partial class MainWindow : Form
   {

      #region [ Formulario ]

      public MainWindow()
      {
         InitializeComponent();

         try
         {
             DevExpress.UserSkins.BonusSkins.Register();
             DevExpress.LookAndFeel.UserLookAndFeel.Default.SetSkinStyle("Blue");

            ((RadPageViewStripElement)(tabViews.GetChildAt(0))).StripButtons = StripViewButtons.Scroll;

            InitilizeUnity();
            AppService.DelfinServiceClient oAppService = new AppService.DelfinServiceClient();
            ApplicationWaitCursor.Cursor = Cursors.WaitCursor;
            ApplicationWaitCursor.Delay = new TimeSpan(0, 0, 0, 0, 250);

            btnConeccion.Visible = false;

            //ClientAdmin = new NextAdminServicesProxy();
            //ClientAdmin = ContainerService.Resolve<INextAdminServices>();
            //Client = new DelfinServicesProxyProxy();
            Client = ContainerService.Resolve<IDelfinServices>();
            Load += MainWindow_Load;
         }
         catch (Exception ex)
         {
            Dialogos.MostrarMensajeError("Delfin", "Ha ocurrido un error en la aplicación.", ex);
            Close();
         }
      }

      private void MainWindow_Load(object sender, EventArgs e)
      {
         Load -= MainWindow_Load;
         try
         {
            CleanOutlookButtons();

            tabViews.Pages.Clear();
            CloseAllViews();
            tabViews.ViewElement.ShowItemCloseButton = true;

            string cadena = "";
            string cn_cadena = "";

            string cadenaAdmin = "";
            string cn_cadenaAdmin = "";

            if (Infrastructure.Aspect.Cryptography.EncryptConexion.ReadConfigFileAdmin(Application.StartupPath, ref cadenaAdmin) && Infrastructure.Aspect.Cryptography.EncryptConexion.ReadConfigFileApp(Application.StartupPath, ref cadena))
            {
               cn_cadenaAdmin = String.Format("{0};Application Name={1};", Infrastructure.Aspect.Cryptography.EncryptConexion.Desencriptar(cadenaAdmin), "NextAdmin");

               String _version = "";
               if (System.Deployment.Application.ApplicationDeployment.IsNetworkDeployed)
               {
                  _version = String.Format("V:{0}", System.Deployment.Application.ApplicationDeployment.CurrentDeployment.CurrentVersion);
               }
               else
               {
                  String mLocation = System.Reflection.Assembly.GetExecutingAssembly().Location;
                  _version = String.Format("V:{0}", System.Diagnostics.FileVersionInfo.GetVersionInfo(mLocation).FileVersion.ToString());
               }

               cn_cadena = String.Format("{0};Application Name={1} | {2};", Infrastructure.Aspect.Cryptography.EncryptConexion.Desencriptar(cadena), "Sistema - Delfin Group CO - L/C/O", _version);

#if DEBUG
               //cn_cadenaAdmin = cn_cadenaAdmin.Replace("DelfinNextadmin", "NextAdminAV");
               //cn_cadena = cn_cadena.Replace("DelfinDeveloper", "DelfinNextSoftAV3");

               cn_cadenaAdmin = cn_cadenaAdmin.Replace("SERVERIBM01\\SQL12", "192.168.1.4\\SQL12");
               cn_cadena = cn_cadena.Replace("SERVERIBM01\\SQL12", "192.168.1.4\\SQL12");
               cn_cadena = cn_cadena.Replace("DelfinDeveloper", "DelfinNextSoft");
#endif

               InitilizeApplication(cn_cadenaAdmin, cn_cadena);
            }
            else
            {
               if (GetConnectionString())
               {
                  if (Infrastructure.Aspect.Cryptography.EncryptConexion.ReadConfigFileAdmin(Application.StartupPath, ref cadenaAdmin) && Infrastructure.Aspect.Cryptography.EncryptConexion.ReadConfigFileApp(Application.StartupPath, ref cadena))
                  {
                     cn_cadenaAdmin = Infrastructure.Aspect.Cryptography.EncryptConexion.Desencriptar(cadenaAdmin);
                     cn_cadena = Infrastructure.Aspect.Cryptography.EncryptConexion.Desencriptar(cadena);
                     InitilizeApplication(cn_cadenaAdmin, cn_cadena);
                  }
                  else
                  {
                     this.Close();
                  }
               }
               else
               {
                  this.Close();
               }
            }

         }
         catch (Exception)
         {
            this.Close();
         }
      }

      private void InitilizeUnity()
      {
         try
         {
            ContainerService = UnityContainerSingleton.Instance;

            var BusinessNextAdminMap = new ExeConfigurationFileMap() { ExeConfigFilename = @".\Config\NextAdminBusinessLogic.config" };
            var BusinessNextAdminConfiguration = ConfigurationManager.OpenMappedExeConfiguration(BusinessNextAdminMap, ConfigurationUserLevel.None);
            var BusinessNextAdminSection = (UnityConfigurationSection)BusinessNextAdminConfiguration.GetSection("unity");
            ContainerService.LoadConfiguration(BusinessNextAdminSection);

            var BusinessMap = new ExeConfigurationFileMap() { ExeConfigFilename = @".\Config\BusinessLogic.config" };
            var BusinessConfiguration = ConfigurationManager.OpenMappedExeConfiguration(BusinessMap, ConfigurationUserLevel.None);
            var BusinessSection = (UnityConfigurationSection)BusinessConfiguration.GetSection("unity");
            ContainerService.LoadConfiguration(BusinessSection);

            /*#################################################################################################*
            string cadena = "";
            string cn_cadena = "";
            
            if (Infrastructure.Aspect.Cryptography.EncryptConexion.ReadConfigFileAdmin(Application.StartupPath, ref cadena))
            {
            cn_cadena = Infrastructure.Aspect.Cryptography.EncryptConexion.Desencriptar(cadena);
            //InitilizeApplication(cn_cadena);
            }
            else
            {
            if (GetConnectionString())
            {
            if (Infrastructure.Aspect.Cryptography.EncryptConexion.ReadConfigFileAdmin(Application.StartupPath, ref cadena))
            {
            cn_cadena = Infrastructure.Aspect.Cryptography.EncryptConexion.Desencriptar(cadena);
            //InitilizeApplication(cn_cadena);
            }
            else
            { this.Close(); }
            }
            else
            { this.Close(); }
            }
            *#################################################################################################*/

            //String _connDB = "";
            //if (System.Configuration.ConfigurationManager.ConnectionStrings["ConnDB"].ConnectionString != null)
            //{ _connDB = System.Configuration.ConfigurationManager.ConnectionStrings["ConnDB"].ConnectionString; }

            //String _connDBAdmin = "";
            //if (System.Configuration.ConfigurationManager.ConnectionStrings["ConnDBAdmin"].ConnectionString != null)
            //{ _connDBAdmin = System.Configuration.ConfigurationManager.ConnectionStrings["ConnDBAdmin"].ConnectionString; }

            //DataAccessEnterpriseSQL.Initialize(_connDB, _connDBAdmin);

            //ContainerService.RegisterType<INextAdminServices, NextAdminServices>(new ContainerControlledLifetimeManager());
            ContainerService.RegisterType<IDelfinServices, DelfinServicesProxy>(new ContainerControlledLifetimeManager());
            ContainerService.RegisterType<ISessionService, SessionService>(new ContainerControlledLifetimeManager());

            Session = ContainerService.Resolve<ISessionService>();
         }
         catch (Exception ex)
         {
            Dialogos.MostrarMensajeError("Delfin", "Ha ocurrido un error en cargando las referencias.", ex);
            Close();
         }
      }

      private bool GetConnectionString()
      {
         try
         {
            NextAdmin.Views.PCadenaConexionView _view = new NextAdmin.Views.PCadenaConexionView();
            NextAdmin.Views.PCadenaConexionPresenter _presenter = new NextAdmin.Views.PCadenaConexionPresenter(_view, ContainerService);
            _view.Presenter = _presenter;
            //_view.MdiParent = this;
            _view.ShowDialog();
            _view.BringToFront();

            if (_view.DialogResult == System.Windows.Forms.DialogResult.OK)
            {
               return true;
            }
            else
            {
               return false;
            }
         }
         catch (Exception)
         {
            return false;
         }
      }

      private void InitilizeApplication(string x_connectionStringAdmin, string x_connectionString)
      {
         try
         {
            DataAccessEnterpriseSQL.Initialize(x_connectionString, x_connectionStringAdmin);
            CadenaConexionAdmin = x_connectionStringAdmin;

            if (!DataAccessEnterpriseSQL.DAValidateConnection(true) || !DataAccessEnterpriseSQL.DAValidateConnection())
            {
               string cadena = "";
               string cn_cadena = "";

               string cadenaAdmin = "";
               string cn_cadenaAdmin = "";

               if (GetConnectionString())
               {
                  if (Infrastructure.Aspect.Cryptography.EncryptConexion.ReadConfigFileAdmin(Application.StartupPath, ref cadenaAdmin))
                  {
                     cn_cadenaAdmin = Infrastructure.Aspect.Cryptography.EncryptConexion.Desencriptar(cadenaAdmin);

                     if (Infrastructure.Aspect.Cryptography.EncryptConexion.ReadConfigFileApp(Application.StartupPath, ref cadena))
                     {
                        cn_cadena = Infrastructure.Aspect.Cryptography.EncryptConexion.Desencriptar(cadena);
                        InitilizeApplication(cn_cadenaAdmin, cn_cadena);
                     }
                     else
                     { this.Close(); }
                  }
                  else
                  { this.Close(); }
               }
               else
               { this.Close(); }
            }
            CheckOpciones();
            Autenticar(true);
         }
         catch (Exception ex)
         {
            Dialogos.MostrarMensajeError("Delfin", "Ha ocurrido un error inicializando la aplicación.", ex);
            Close();
         }
      }

        #endregion

        #region [ Autenticacion ]

        private void Autenticar(bool inicio)
        {
            NextAdmin.Views.PAutenticacionPresenter m_autenciacionPresenter = new NextAdmin.Views.PAutenticacionPresenter(null, ContainerService);
            //NextAdmin.BusinessLogic.Usuarios m_autenciacionPresenter = new NextAdmin.BusinessLogic.Usuarios();
            try
            {
                Session.CerrarSesion();
                CleanOutlookButtons();

                tabViews.Pages.Clear();
                CloseAllViews();

                Program.frmSp.Close();

                if (m_autenciacionPresenter.AutenticarUsuario() == DialogResult.OK)
                {
                    if (m_autenciacionPresenter.Item != null)
                    {


            ItemUsuario = m_autenciacionPresenter.Item;
            //ItemUsuario.USUA_CodUsr = "sistemas";
            //ItemUsuario.USUA_Codigo = 1061;
            //ItemUsuario.USUA_Nombres = "sistemas";

            Session.UserName = ItemUsuario.USUA_CodUsr;
            Session.UserCodigo = ItemUsuario.USUA_Codigo;
            Session.UserNombreCompleto = ItemUsuario.USUA_Nombres;

                        if (ItemAplicacion != null)
                        {
                            Session.AplicacionCodigo = ItemAplicacion.APLI_Codigo;
                        }

                        lblUsuario.Text = "Bienvenido(a). " + ItemUsuario.USUA_Nombres;

                        ValidateUserOptions();

                        if (m_autenciacionPresenter.Item.USUA_CambiarPassword)
                        {
                            ActualizarPassword();
                        }

                        CallEntornoTrabajo();
                        GenerarXML();
                        Client.UsuarioTipos = Session.UserName;
                        Client.UsuarioPuertos = Session.UserName;
                        Client.UsuarioParametros = Session.UserName;
                    }
                }
                else
                {
                    Close();
                }
            }
            catch (Exception ex)
            {
                Dialogos.MostrarMensajeError("Delfin", "Ha ocurrido un error al autenticar.", ex);
                Close();
            }
        }

        private void CallEntornoTrabajo()
      {
         try
         {
            EntornoTrabajo view = new EntornoTrabajo(ContainerService);

            if (view.ShowDialog() == DialogResult.OK)
            {
               Entorno.InitializeEntorno(view.ItemEmpresa, view.ItemSucursal);
               Session.NombreEmpresa = view.ItemEmpresa.EMPR_RazonSocial;
               Session.SucursalNombre = view.ItemSucursal.SUCR_Desc;
               if (!String.IsNullOrEmpty(view.ItemSucursal.SUCR_Desc))
               {
                  DataTable dt = new DataTable();
                  dt = Client.GetOneCORR_SerieFactura("DELFIN", variables.GetSerieFactura(view.ItemSucursal.SUCR_Desc));
                  if ((dt != null && dt.Rows.Count > 0) && !String.IsNullOrEmpty(dt.Rows[0]["CORR_UltNum"].ToString()))
                  {
                     Session.PuntoVTA_Codigo = Int32.Parse(dt.Rows[0]["CORR_UltNum"].ToString()); // Serie
                  }
                  else
                  {
                     Session.PuntoVTA_Codigo = 6; // por defecto
                  }
               }
            }
            else
            {
               Close();
            }
            SetAcceso();
         }
         catch (Exception ex)
         {
            Dialogos.MostrarMensajeError("Delfin", "Ha ocurrido un error al cargar el entorno.", ex);
            Close();
         }
      }

      private void ActualizarPassword()
      {
         try
         {
            NextAdmin.Views.IPCambioPassword _view = new NextAdmin.Views.PCambioPassword();
            NextAdmin.Views.PCambioPasswordPresenter _presenter = new NextAdmin.Views.PCambioPasswordPresenter(_view, ContainerService);
            ((NextAdmin.Views.PCambioPassword)_view).Presenter = _presenter;
            ((NextAdmin.Views.PCambioPassword)_view).ShowDialog();
            //m_autenciacionPresenter.ActualizarPassword();
         }
         catch (Exception ex)
         {
            Dialogos.MostrarMensajeError("Delfin", "Ha ocurrido un error al autenticar.", ex);
            Close();
         }
      }

      private void SetAcceso()
      {
         try
         {
            tsslblEmpresa.Text = String.Format("Empresa: {0}", Session.NombreEmpresa);
            tsslblSucursal.Text = String.Format("Sucursal: {0}", Session.SucursalNombre);
            tslblHostname.Text = String.Format("Host: {0}", System.Net.Dns.GetHostName());
            String _BDAdmin = CadenaConexionAdmin.Substring(CadenaConexionAdmin.IndexOf("Catalog=") + 8, 20);
            _BDAdmin = _BDAdmin.Substring(0, _BDAdmin.IndexOf(";"));

            //if (Session.UserName != null && ItemUsuario.USUA_Administrador)
            {
               String _Instancia = Client.getNameInstancia();
               tslblServidor.Text = String.Format("Servidor: {0}", _Instancia);
               tslblBD.Text = String.Format("B.D./B.D. Admin: [{0}]/[{1}]", Client.getNameDataBase(), _BDAdmin);
            }
            //else
            //{
            //   tslblServidor.Text = "";
            //   tslblBD.Text = String.Format("B.D./B.D. Admin: [{0}]/[{1}]", Client.getNameDataBase(), _BDAdmin);
            //}

            if (System.Deployment.Application.ApplicationDeployment.IsNetworkDeployed)
            {
               tslblVersion.Text = String.Format("Versión: {0}", System.Deployment.Application.ApplicationDeployment.CurrentDeployment.CurrentVersion);
            }
            else
            {
               String mLocation = System.Reflection.Assembly.GetExecutingAssembly().Location;
               tslblVersion.Text = String.Format("Versión: {0}", System.Diagnostics.FileVersionInfo.GetVersionInfo(mLocation).FileVersion.ToString());
            }
         }
         catch (Exception)
         {
         }
      }

      /// <summary>
      /// Método para procesar los archivos locales
      /// </summary>
      private void GenerarXML()
      {
         try
         {
            DataTable dt_xml = new DataTable();
            ObservableCollection<Infrastructure.Aspect.DataAccess.DataAccessFilterSQL> _listFilters = new ObservableCollection<Infrastructure.Aspect.DataAccess.DataAccessFilterSQL>();
            /*
             * Cargar el listado de tablas se procesaran como archivos locales
             */
            dt_xml = Client.GetDTCtaCte("CHKSSS_ObtenerTablas", _listFilters);

            Infrastructure.Aspect.CheckSUM.GenerarChekSum x_generar = new Infrastructure.Aspect.CheckSUM.GenerarChekSum(Application.StartupPath, Session.UserName);
            if (x_generar.CompararObjetos(dt_xml))
            {
               Boolean IfCambio = false;
               foreach (Infrastructure.Aspect.CheckSUM.CHKS_Tablas iTablas in x_generar.ListTablas)
               {
                  /*
                   * Se procede a verificar si existe un cambio en los archivos locales, para volverlos a generar 
                   * , obtendiendo lo archivos de la base de datos
                   */
                  _listFilters = new ObservableCollection<Infrastructure.Aspect.DataAccess.DataAccessFilterSQL>();
                  if (iTablas.Cambio)
                  {
                     /* Obtener los registros a ser generados como datos locales */
                     DataSet ds_xml = Client.GetDSDocsVta(iTablas.CHKS_Procedure, _listFilters);
                     /* Ejecutar el procedimiento de almacenamiento de los registros archivos en el disco local*/
                     x_generar.GenerarXML(iTablas, ds_xml);
                     IfCambio = true;
                  }
               }
               if (IfCambio)
               { /* Si se realizo algun cambio en los arhcivos locales, tambien se actualiza el listado de tablas que
                  * que se procesan como archivos locales
                  */
                  x_generar.GenerarTablaCheckSUM();
               }
            }
         }
         catch (Exception)
         { throw; }
      }

      #endregion

      #region [ Permisos Opciones ]

      public IDelfinServices Client { get; set; }

      private NextAdmin.BusinessLogic.Aplicaciones m_itemAplicacion;
      public NextAdmin.BusinessLogic.Aplicaciones ItemAplicacion
      {
         get
         {
            return m_itemAplicacion;
         }
         set
         {
            m_itemAplicacion = value;
         }
      }

      private NextAdmin.BusinessLogic.Empresas m_itemEmpresa;
      public NextAdmin.BusinessLogic.Empresas ItemEmpresa
      {
         get
         {
            return m_itemEmpresa;
         }
         set
         {
            m_itemEmpresa = value;
         }
      }

      private NextAdmin.BusinessLogic.Usuarios m_itemUsuario;
      public NextAdmin.BusinessLogic.Usuarios ItemUsuario
      {
         get
         {
            return m_itemUsuario;
         }
         set
         {
            m_itemUsuario = value;
         }
      }

      private ObservableCollection<NextAdmin.BusinessLogic.PermisosUsuarioOpciones> m_listPermisos;
      public ObservableCollection<NextAdmin.BusinessLogic.PermisosUsuarioOpciones> ListPermisos
      {
         get
         {
            return m_listPermisos;
         }
         set
         {
            m_listPermisos = value;
         }
      }

      private void CheckOpciones()
      {
         try
         {
            //NextAdminAplicaciones = Container.Resolve<NextAdmin.BusinessLogic.IBLAplicaciones>();
            ItemAplicacion = new NextAdmin.BusinessLogic.Aplicaciones();
            ItemAplicacion.APLI_Codigo = 1;
            ItemAplicacion.APLI_Desc = "DELFIN";
            ItemAplicacion.APLI_DescC = "DELFIN";
            ItemAplicacion.APLI_Path = Application.ExecutablePath;
            //ItemAplicacion.APLI_Icono
            ItemAplicacion.APLI_Estado = true;
            ItemAplicacion.APLI_Observacion = "DELFIN";
            ItemAplicacion.AUDI_UsrCrea = "SISTEMAS";

            ItemEmpresa = new NextAdmin.BusinessLogic.Empresas();
            ItemEmpresa.EMPR_Codigo = 1;
            ItemEmpresa.EMPR_Desc = "DELFIN GROUP Co";
            ItemEmpresa.EMPR_DescC = "DELFIN";
            ItemEmpresa.EMPR_Direccion = "CALLE ANTEQUERA N°777, PISO 12 - SAN ISIDRO";
            ItemEmpresa.EMPR_Telefono1 = "(511) 615 3535";
            ItemEmpresa.EMPR_Telefono2 = "-";
            ItemEmpresa.EMPR_Fax = "(511) 615 3553";
            ItemEmpresa.EMPR_Email = "customerper@delfingroupco.com.pe";
            ItemEmpresa.EMPR_RUC = "20516667550";
            ItemEmpresa.EMPR_BaseDatos = "DELFIN";
            ItemEmpresa.EMPR_Estado = true;

            DataTable dtOpciones = new DataTable("Opciones");
            DataColumn dcOpciones;
            DataRow drOpciones;

            //OPCI_Codigo
            dcOpciones = new DataColumn();
            dcOpciones.ColumnName = "OPCI_Codigo";
            dcOpciones.DataType = Type.GetType("System.Int32");
            dcOpciones.AllowDBNull = false;
            dtOpciones.Columns.Add(dcOpciones);
            //OPCI_Desc
            dcOpciones = new DataColumn();
            dcOpciones.ColumnName = "OPCI_Desc";
            dcOpciones.DataType = Type.GetType("System.String");
            dcOpciones.AllowDBNull = false;
            dtOpciones.Columns.Add(dcOpciones);
            //OPCI_DescC
            dcOpciones = new DataColumn();
            dcOpciones.ColumnName = "OPCI_DescC";
            dcOpciones.DataType = Type.GetType("System.String");
            dcOpciones.AllowDBNull = false;
            dtOpciones.Columns.Add(dcOpciones);
            //OPCI_CodigoPadre
            dcOpciones = new DataColumn();
            dcOpciones.ColumnName = "OPCI_CodigoPadre";
            dcOpciones.DataType = Type.GetType("System.Int32");
            dcOpciones.AllowDBNull = true;
            dtOpciones.Columns.Add(dcOpciones);
            //APLI_Codigo
            dcOpciones = new DataColumn();
            dcOpciones.ColumnName = "APLI_Codigo";
            dcOpciones.DataType = Type.GetType("System.Int32");
            dcOpciones.AllowDBNull = false;
            dtOpciones.Columns.Add(dcOpciones);
            //OPCI_Estado
            dcOpciones = new DataColumn();
            dcOpciones.ColumnName = "OPCI_Estado";
            dcOpciones.DataType = Type.GetType("System.Boolean");
            dcOpciones.AllowDBNull = false;
            dtOpciones.Columns.Add(dcOpciones);

            Int32 _opci_codigo = 1;
            Int32 _opci_codigopadre;
            Int32 _opci_codigopadre2;

            #region [ Mantenimientos ]

            drOpciones = dtOpciones.NewRow();
            drOpciones["OPCI_Codigo"] = _opci_codigo;
            drOpciones["OPCI_Desc"] = "Mantenimientos";
            drOpciones["OPCI_DescC"] = "MANTE";
            //drOpciones["OPCI_CodigoPadre"] = null;
            drOpciones["APLI_Codigo"] = ItemAplicacion.APLI_Codigo;
            drOpciones["OPCI_Estado"] = true;
            dtOpciones.Rows.Add(drOpciones);

            _opci_codigopadre = _opci_codigo;
            _opci_codigo += 1;
            foreach (ToolStripItem subitem in toolMantenimientos.Items)
            {
               drOpciones = dtOpciones.NewRow();
               drOpciones["OPCI_Codigo"] = _opci_codigo;
               drOpciones["OPCI_Desc"] = !String.IsNullOrEmpty(subitem.Text) ? subitem.Text : "-";
               drOpciones["OPCI_DescC"] = subitem.Tag.ToString();
               drOpciones["OPCI_CodigoPadre"] = _opci_codigopadre;
               drOpciones["APLI_Codigo"] = ItemAplicacion.APLI_Codigo;
               drOpciones["OPCI_Estado"] = true;
               dtOpciones.Rows.Add(drOpciones);

               if (subitem is ToolStripDropDownButton)
               {
                  _opci_codigopadre2 = _opci_codigo;
                  _opci_codigo += 1;
                  foreach (ToolStripItem subsubitem in ((ToolStripDropDownButton)subitem).DropDownItems)
                  {
                     drOpciones = dtOpciones.NewRow();
                     drOpciones["OPCI_Codigo"] = _opci_codigo;
                     drOpciones["OPCI_Desc"] = !String.IsNullOrEmpty(subsubitem.Text) ? subsubitem.Text : "-";
                     drOpciones["OPCI_DescC"] = subsubitem.Tag.ToString();
                     drOpciones["OPCI_CodigoPadre"] = _opci_codigopadre2;
                     drOpciones["APLI_Codigo"] = ItemAplicacion.APLI_Codigo;
                     drOpciones["OPCI_Estado"] = true;
                     dtOpciones.Rows.Add(drOpciones);

                     _opci_codigo += 1;
                  }
               }

               _opci_codigo += 1;
            }

            #endregion

            #region [ Comercial ]

            drOpciones = dtOpciones.NewRow();
            drOpciones["OPCI_Codigo"] = _opci_codigo;
            drOpciones["OPCI_Desc"] = "Comercial";
            drOpciones["OPCI_DescC"] = "COMER";
            //drOpciones["OPCI_CodigoPadre"] = null;
            drOpciones["APLI_Codigo"] = ItemAplicacion.APLI_Codigo;
            drOpciones["OPCI_Estado"] = true;
            dtOpciones.Rows.Add(drOpciones);

            _opci_codigopadre = _opci_codigo;
            _opci_codigo += 1;
            foreach (ToolStripItem subitem in toolComercial.Items)
            {
               drOpciones = dtOpciones.NewRow();
               drOpciones["OPCI_Codigo"] = _opci_codigo;
               drOpciones["OPCI_Desc"] = !String.IsNullOrEmpty(subitem.Text) ? subitem.Text : "-";
               drOpciones["OPCI_DescC"] = subitem.Tag.ToString();
               drOpciones["OPCI_CodigoPadre"] = _opci_codigopadre;
               drOpciones["APLI_Codigo"] = ItemAplicacion.APLI_Codigo;
               drOpciones["OPCI_Estado"] = true;
               dtOpciones.Rows.Add(drOpciones);

               if (subitem is ToolStripDropDownButton)
               {
                  _opci_codigopadre2 = _opci_codigo;
                  _opci_codigo += 1;
                  foreach (ToolStripItem subsubitem in ((ToolStripDropDownButton)subitem).DropDownItems)
                  {
                     drOpciones = dtOpciones.NewRow();
                     drOpciones["OPCI_Codigo"] = _opci_codigo;
                     drOpciones["OPCI_Desc"] = !String.IsNullOrEmpty(subsubitem.Text) ? subsubitem.Text : "-";
                     drOpciones["OPCI_DescC"] = subsubitem.Tag.ToString();
                     drOpciones["OPCI_CodigoPadre"] = _opci_codigopadre2;
                     drOpciones["APLI_Codigo"] = ItemAplicacion.APLI_Codigo;
                     drOpciones["OPCI_Estado"] = true;
                     dtOpciones.Rows.Add(drOpciones);

                     _opci_codigo += 1;
                  }
               }
               _opci_codigo += 1;
            }

            #endregion

            #region [ Operaciones ]

            drOpciones = dtOpciones.NewRow();
            drOpciones["OPCI_Codigo"] = _opci_codigo;
            drOpciones["OPCI_Desc"] = "Operaciones";
            drOpciones["OPCI_DescC"] = "OPERA";
            //drOpciones["OPCI_CodigoPadre"] = null;
            drOpciones["APLI_Codigo"] = ItemAplicacion.APLI_Codigo;
            drOpciones["OPCI_Estado"] = true;
            dtOpciones.Rows.Add(drOpciones);

            _opci_codigopadre = _opci_codigo;
            _opci_codigo += 1;
            foreach (ToolStripItem subitem in toolOperaciones.Items)
            {
               drOpciones = dtOpciones.NewRow();
               drOpciones["OPCI_Codigo"] = _opci_codigo;
               drOpciones["OPCI_Desc"] = !String.IsNullOrEmpty(subitem.Text) ? subitem.Text : "-";
               drOpciones["OPCI_DescC"] = subitem.Tag.ToString();
               drOpciones["OPCI_CodigoPadre"] = _opci_codigopadre;
               drOpciones["APLI_Codigo"] = ItemAplicacion.APLI_Codigo;
               drOpciones["OPCI_Estado"] = true;
               dtOpciones.Rows.Add(drOpciones);

               if (subitem is ToolStripDropDownButton)
               {
                  _opci_codigopadre2 = _opci_codigo;
                  _opci_codigo += 1;
                  foreach (ToolStripItem subsubitem in ((ToolStripDropDownButton)subitem).DropDownItems)
                  {
                     drOpciones = dtOpciones.NewRow();
                     drOpciones["OPCI_Codigo"] = _opci_codigo;
                     drOpciones["OPCI_Desc"] = !String.IsNullOrEmpty(subsubitem.Text) ? subsubitem.Text : "-";
                     drOpciones["OPCI_DescC"] = subsubitem.Tag.ToString();
                     drOpciones["OPCI_CodigoPadre"] = _opci_codigopadre2;
                     drOpciones["APLI_Codigo"] = ItemAplicacion.APLI_Codigo;
                     drOpciones["OPCI_Estado"] = true;
                     dtOpciones.Rows.Add(drOpciones);

                     _opci_codigo += 1;
                  }
               }
               _opci_codigo += 1;
            }

            #endregion

            #region [ Finanzas ]

            drOpciones = dtOpciones.NewRow();
            drOpciones["OPCI_Codigo"] = _opci_codigo;
            drOpciones["OPCI_Desc"] = "Finanzas";
            drOpciones["OPCI_DescC"] = "FINAN";
            //drOpciones["OPCI_CodigoPadre"] = null;
            drOpciones["APLI_Codigo"] = ItemAplicacion.APLI_Codigo;
            drOpciones["OPCI_Estado"] = true;
            dtOpciones.Rows.Add(drOpciones);

            _opci_codigopadre = _opci_codigo;
            _opci_codigo += 1;
            foreach (ToolStripItem subitem in toolFinanzas.Items)
            {
               drOpciones = dtOpciones.NewRow();
               drOpciones["OPCI_Codigo"] = _opci_codigo;
               drOpciones["OPCI_Desc"] = !String.IsNullOrEmpty(subitem.Text) ? subitem.Text : "-";
               drOpciones["OPCI_DescC"] = subitem.Tag.ToString();
               drOpciones["OPCI_CodigoPadre"] = _opci_codigopadre;
               drOpciones["APLI_Codigo"] = ItemAplicacion.APLI_Codigo;
               drOpciones["OPCI_Estado"] = true;
               dtOpciones.Rows.Add(drOpciones);

               if (subitem is ToolStripDropDownButton)
               {
                  _opci_codigopadre2 = _opci_codigo;
                  _opci_codigo += 1;
                  foreach (ToolStripItem subsubitem in ((ToolStripDropDownButton)subitem).DropDownItems)
                  {
                     drOpciones = dtOpciones.NewRow();
                     drOpciones["OPCI_Codigo"] = _opci_codigo;
                     drOpciones["OPCI_Desc"] = !String.IsNullOrEmpty(subsubitem.Text) ? subsubitem.Text : "-";
                     drOpciones["OPCI_DescC"] = subsubitem.Tag.ToString();
                     drOpciones["OPCI_CodigoPadre"] = _opci_codigopadre2;
                     drOpciones["APLI_Codigo"] = ItemAplicacion.APLI_Codigo;
                     drOpciones["OPCI_Estado"] = true;
                     dtOpciones.Rows.Add(drOpciones);

                     _opci_codigo += 1;
                  }
               }
               _opci_codigo += 1;
            }

            #endregion

            #region [ Logistico ]

            drOpciones = dtOpciones.NewRow();
            drOpciones["OPCI_Codigo"] = _opci_codigo;
            drOpciones["OPCI_Desc"] = "Logistico";
            drOpciones["OPCI_DescC"] = "LOGIS";
            //drOpciones["OPCI_CodigoPadre"] = null;
            drOpciones["APLI_Codigo"] = ItemAplicacion.APLI_Codigo;
            drOpciones["OPCI_Estado"] = true;
            dtOpciones.Rows.Add(drOpciones);

            _opci_codigopadre = _opci_codigo;
            _opci_codigo += 1;
            foreach (ToolStripItem subitem in toolLogistico.Items)
            {
               drOpciones = dtOpciones.NewRow();
               drOpciones["OPCI_Codigo"] = _opci_codigo;
               drOpciones["OPCI_Desc"] = !String.IsNullOrEmpty(subitem.Text) ? subitem.Text : "-";
               drOpciones["OPCI_DescC"] = subitem.Tag.ToString();
               drOpciones["OPCI_CodigoPadre"] = _opci_codigopadre;
               drOpciones["APLI_Codigo"] = ItemAplicacion.APLI_Codigo;
               drOpciones["OPCI_Estado"] = true;
               dtOpciones.Rows.Add(drOpciones);

               if (subitem is ToolStripDropDownButton)
               {
                  _opci_codigopadre2 = _opci_codigo;
                  _opci_codigo += 1;
                  foreach (ToolStripItem subsubitem in ((ToolStripDropDownButton)subitem).DropDownItems)
                  {
                     drOpciones = dtOpciones.NewRow();
                     drOpciones["OPCI_Codigo"] = _opci_codigo;
                     drOpciones["OPCI_Desc"] = !String.IsNullOrEmpty(subsubitem.Text) ? subsubitem.Text : "-";
                     drOpciones["OPCI_DescC"] = subsubitem.Tag.ToString();
                     drOpciones["OPCI_CodigoPadre"] = _opci_codigopadre2;
                     drOpciones["APLI_Codigo"] = ItemAplicacion.APLI_Codigo;
                     drOpciones["OPCI_Estado"] = true;
                     dtOpciones.Rows.Add(drOpciones);

                     _opci_codigo += 1;
                  }
               }
               _opci_codigo += 1;
            }

                #endregion

                #region [ ServicioLogistico ]
                drOpciones = dtOpciones.NewRow();
                drOpciones["OPCI_Codigo"] = _opci_codigo;
                drOpciones["OPCI_Desc"] = "Servicio Logistico";
                drOpciones["OPCI_DescC"] = "SELOG";
                //drOpciones["OPCI_CodigoPadre"] = null;
                drOpciones["APLI_Codigo"] = ItemAplicacion.APLI_Codigo;
                drOpciones["OPCI_Estado"] = true;
                dtOpciones.Rows.Add(drOpciones);

                _opci_codigopadre = _opci_codigo;
                _opci_codigo += 1;
                foreach (ToolStripItem subitem in toolServicioLogistico.Items)
                {
                    drOpciones = dtOpciones.NewRow();
                    drOpciones["OPCI_Codigo"] = _opci_codigo;
                    drOpciones["OPCI_Desc"] = !String.IsNullOrEmpty(subitem.Text) ? subitem.Text : "-";
                    drOpciones["OPCI_DescC"] = subitem.Tag.ToString();
                    drOpciones["OPCI_CodigoPadre"] = _opci_codigopadre;
                    drOpciones["APLI_Codigo"] = ItemAplicacion.APLI_Codigo;
                    drOpciones["OPCI_Estado"] = true;
                    dtOpciones.Rows.Add(drOpciones);

                    if (subitem is ToolStripDropDownButton)
                    {
                        _opci_codigopadre2 = _opci_codigo;
                        _opci_codigo += 1;
                        foreach (ToolStripItem subsubitem in ((ToolStripDropDownButton)subitem).DropDownItems)
                        {
                            drOpciones = dtOpciones.NewRow();
                            drOpciones["OPCI_Codigo"] = _opci_codigo;
                            drOpciones["OPCI_Desc"] = !String.IsNullOrEmpty(subsubitem.Text) ? subsubitem.Text : "-";
                            drOpciones["OPCI_DescC"] = subsubitem.Tag.ToString();
                            drOpciones["OPCI_CodigoPadre"] = _opci_codigopadre2;
                            drOpciones["APLI_Codigo"] = ItemAplicacion.APLI_Codigo;
                            drOpciones["OPCI_Estado"] = true;
                            dtOpciones.Rows.Add(drOpciones);

                            _opci_codigo += 1;
                        }
                    }
                    _opci_codigo += 1;
                }

                #endregion

                #region [ Tarifario ]
                drOpciones = dtOpciones.NewRow();
                drOpciones["OPCI_Codigo"] = _opci_codigo;
                drOpciones["OPCI_Desc"] = "Tarifario";
                drOpciones["OPCI_DescC"] = "TARIF";
                //drOpciones["OPCI_CodigoPadre"] = null;
                drOpciones["APLI_Codigo"] = ItemAplicacion.APLI_Codigo;
                drOpciones["OPCI_Estado"] = true;
                dtOpciones.Rows.Add(drOpciones);

                _opci_codigopadre = _opci_codigo;
                _opci_codigo += 1;
                foreach (ToolStripItem subitem in toolTarifario.Items)
                {
                    drOpciones = dtOpciones.NewRow();
                    drOpciones["OPCI_Codigo"] = _opci_codigo;
                    drOpciones["OPCI_Desc"] = !String.IsNullOrEmpty(subitem.Text) ? subitem.Text : "-";
                    drOpciones["OPCI_DescC"] = subitem.Tag.ToString();
                    drOpciones["OPCI_CodigoPadre"] = _opci_codigopadre;
                    drOpciones["APLI_Codigo"] = ItemAplicacion.APLI_Codigo;
                    drOpciones["OPCI_Estado"] = true;
                    dtOpciones.Rows.Add(drOpciones);

                    if (subitem is ToolStripDropDownButton)
                    {
                        _opci_codigopadre2 = _opci_codigo;
                        _opci_codigo += 1;
                        foreach (ToolStripItem subsubitem in ((ToolStripDropDownButton)subitem).DropDownItems)
                        {
                            drOpciones = dtOpciones.NewRow();
                            drOpciones["OPCI_Codigo"] = _opci_codigo;
                            drOpciones["OPCI_Desc"] = !String.IsNullOrEmpty(subsubitem.Text) ? subsubitem.Text : "-";
                            drOpciones["OPCI_DescC"] = subsubitem.Tag.ToString();
                            drOpciones["OPCI_CodigoPadre"] = _opci_codigopadre2;
                            drOpciones["APLI_Codigo"] = ItemAplicacion.APLI_Codigo;
                            drOpciones["OPCI_Estado"] = true;
                            dtOpciones.Rows.Add(drOpciones);

                            _opci_codigo += 1;
                        }
                    }
                    _opci_codigo += 1;
                }

                #endregion

                #region [ Reportes ]

            drOpciones = dtOpciones.NewRow();
            drOpciones["OPCI_Codigo"] = _opci_codigo;
            drOpciones["OPCI_Desc"] = "Reportes";
            drOpciones["OPCI_DescC"] = "REPOR";
            //drOpciones["OPCI_CodigoPadre"] = null;
            drOpciones["APLI_Codigo"] = ItemAplicacion.APLI_Codigo;
            drOpciones["OPCI_Estado"] = true;
            dtOpciones.Rows.Add(drOpciones);

            _opci_codigopadre = _opci_codigo;
            _opci_codigo += 1;
            foreach (ToolStripItem subitem in toolReportes.Items)
            {
               drOpciones = dtOpciones.NewRow();
               drOpciones["OPCI_Codigo"] = _opci_codigo;
               drOpciones["OPCI_Desc"] = !String.IsNullOrEmpty(subitem.Text) ? subitem.Text : "-";
               drOpciones["OPCI_DescC"] = subitem.Tag.ToString();
               drOpciones["OPCI_CodigoPadre"] = _opci_codigopadre;
               drOpciones["APLI_Codigo"] = ItemAplicacion.APLI_Codigo;
               drOpciones["OPCI_Estado"] = true;
               dtOpciones.Rows.Add(drOpciones);

               if (subitem is ToolStripDropDownButton)
               {
                  _opci_codigopadre2 = _opci_codigo;
                  _opci_codigo += 1;
                  foreach (ToolStripItem subsubitem in ((ToolStripDropDownButton)subitem).DropDownItems)
                  {
                     drOpciones = dtOpciones.NewRow();
                     drOpciones["OPCI_Codigo"] = _opci_codigo;
                     drOpciones["OPCI_Desc"] = !String.IsNullOrEmpty(subsubitem.Text) ? subsubitem.Text : "-";
                     drOpciones["OPCI_DescC"] = subsubitem.Tag.ToString();
                     drOpciones["OPCI_CodigoPadre"] = _opci_codigopadre2;
                     drOpciones["APLI_Codigo"] = ItemAplicacion.APLI_Codigo;
                     drOpciones["OPCI_Estado"] = true;
                     dtOpciones.Rows.Add(drOpciones);

                     _opci_codigo += 1;
                  }
               }

               _opci_codigo += 1;
            }

            #endregion

            //}
            //}

            //ProxyNextAdmin.ValidateApplication(ref m_itemAplicacion, ref m_itemEmpresa, dtOpciones);

            DataTable dtProcesos = new DataTable("Procesos");
            DataColumn dcProcesos;
            DataRow drProcesos;
            Int32 _proc_codigo = 1;

            //PROC_Codigo
            dcProcesos = new DataColumn();
            dcProcesos.ColumnName = "PROC_Codigo";
            dcProcesos.DataType = Type.GetType("System.Int32");
            dcProcesos.AllowDBNull = false;
            dtProcesos.Columns.Add(dcProcesos);
            //PROC_Desc
            dcProcesos = new DataColumn();
            dcProcesos.ColumnName = "PROC_Desc";
            dcProcesos.DataType = Type.GetType("System.String");
            dcProcesos.AllowDBNull = false;
            dtProcesos.Columns.Add(dcProcesos);
            //PROC_DescC
            dcProcesos = new DataColumn();
            dcProcesos.ColumnName = "PROC_DescC";
            dcProcesos.DataType = Type.GetType("System.String");
            dcProcesos.AllowDBNull = false;
            dtProcesos.Columns.Add(dcProcesos);
            //APLI_Codigo
            dcProcesos = new DataColumn();
            dcProcesos.ColumnName = "APLI_Codigo";
            dcProcesos.DataType = Type.GetType("System.Int32");
            dcProcesos.AllowDBNull = false;
            dtProcesos.Columns.Add(dcProcesos);
            //PROC_Estado
            dcProcesos = new DataColumn();
            dcProcesos.ColumnName = "PROC_Estado";
            dcProcesos.DataType = Type.GetType("System.Boolean");
            dcProcesos.AllowDBNull = false;
            dtProcesos.Columns.Add(dcProcesos);

            drProcesos = dtProcesos.NewRow();
            drProcesos["PROC_Codigo"] = _proc_codigo;
            _proc_codigo += 1;
            drProcesos["PROC_Desc"] = "APROBACION COTIZACION NIVEL 1";
            drProcesos["PROC_DescC"] = variables.CCOT_APROCOTIZ1;
            drProcesos["APLI_Codigo"] = ItemAplicacion.APLI_Codigo;
            drProcesos["PROC_Estado"] = true;
            dtProcesos.Rows.Add(drProcesos);

            drProcesos = dtProcesos.NewRow();
            drProcesos["PROC_Codigo"] = _proc_codigo;
            _proc_codigo += 1;
            drProcesos["PROC_Desc"] = "APROBACION COTIZACION NIVEL 2";
            drProcesos["PROC_DescC"] = variables.CCOT_APROCOTIZ2;
            drProcesos["APLI_Codigo"] = ItemAplicacion.APLI_Codigo;
            drProcesos["PROC_Estado"] = true;
            dtProcesos.Rows.Add(drProcesos);

            drProcesos = dtProcesos.NewRow();
            drProcesos["PROC_Codigo"] = _proc_codigo;
            _proc_codigo += 1;
            drProcesos["PROC_Desc"] = "APROBACION COTIZACION NIVEL 3";
            drProcesos["PROC_DescC"] = variables.CCOT_APROCOTIZ3;
            drProcesos["APLI_Codigo"] = ItemAplicacion.APLI_Codigo;
            drProcesos["PROC_Estado"] = true;
            dtProcesos.Rows.Add(drProcesos);

            drProcesos = dtProcesos.NewRow();
            drProcesos["PROC_Codigo"] = _proc_codigo;
            _proc_codigo += 1;
            drProcesos["PROC_Desc"] = "APROBACION COTIZACION NIVEL 4";
            drProcesos["PROC_DescC"] = variables.CCOT_APROCOTIZ4;
            drProcesos["APLI_Codigo"] = ItemAplicacion.APLI_Codigo;
            drProcesos["PROC_Estado"] = true;
            dtProcesos.Rows.Add(drProcesos);

            drProcesos = dtProcesos.NewRow();
            drProcesos["PROC_Codigo"] = _proc_codigo;
            _proc_codigo += 1;
            drProcesos["PROC_Desc"] = "ANULACION COTIZACION";
            drProcesos["PROC_DescC"] = variables.CCOT_ANULCOTIZ;
            drProcesos["APLI_Codigo"] = ItemAplicacion.APLI_Codigo;
            drProcesos["PROC_Estado"] = true;
            dtProcesos.Rows.Add(drProcesos);

            drProcesos = dtProcesos.NewRow();
            drProcesos["PROC_Codigo"] = _proc_codigo;
            _proc_codigo += 1;
            drProcesos["PROC_Desc"] = "PERMISO EDICION ORDEN VENTA";
            drProcesos["PROC_DescC"] = variables.CCOT_EDITARCOTIZ;
            drProcesos["APLI_Codigo"] = ItemAplicacion.APLI_Codigo;
            drProcesos["PROC_Estado"] = true;
            dtProcesos.Rows.Add(drProcesos);





            //Acceso para visualizar OV con estado “Concluidas” 
            drProcesos = dtProcesos.NewRow();
            drProcesos["PROC_Codigo"] = _proc_codigo;
            _proc_codigo += 1;
            drProcesos["PROC_Desc"] = "VISUALIZAR OV CONCLUIDAS";
            drProcesos["PROC_DescC"] = variables.CCOT_OVCONCLUIDA;
            drProcesos["APLI_Codigo"] = ItemAplicacion.APLI_Codigo;
            drProcesos["PROC_Estado"] = true;
            dtProcesos.Rows.Add(drProcesos);

            //Acceso para operaciones para que puedan visualizar OV con estado Documentadas o con estado pre-facturado
            drProcesos = dtProcesos.NewRow();
            drProcesos["PROC_Codigo"] = _proc_codigo;
            _proc_codigo += 1;
            drProcesos["PROC_Desc"] = "VISUALIZAR OV DOCUMENTADAS O PREFACTURADAS";
            drProcesos["PROC_DescC"] = variables.CCOT_OVDOCUMENTADA;
            drProcesos["APLI_Codigo"] = ItemAplicacion.APLI_Codigo;
            drProcesos["PROC_Estado"] = true;
            dtProcesos.Rows.Add(drProcesos);

            //Acceso de solo lectura para usuarios de otras áreas
            drProcesos = dtProcesos.NewRow();
            drProcesos["PROC_Codigo"] = _proc_codigo;
            _proc_codigo += 1;
            drProcesos["PROC_Desc"] = "VISUALIZAR OV MODO SOLO LECTURA";
            drProcesos["PROC_DescC"] = variables.CCOT_OVSOLOLECTURA;
            drProcesos["APLI_Codigo"] = ItemAplicacion.APLI_Codigo;
            drProcesos["PROC_Estado"] = true;
            dtProcesos.Rows.Add(drProcesos);

            //Acceso de edición costo OV Operaciones
            drProcesos = dtProcesos.NewRow();
            drProcesos["PROC_Codigo"] = _proc_codigo;
            _proc_codigo += 1;
            drProcesos["PROC_Desc"] = "EDITAR FLETE COSTO OV OPERACIONES";
            drProcesos["PROC_DescC"] = variables.CCOT_OVEDITARCOSTO;
            drProcesos["APLI_Codigo"] = ItemAplicacion.APLI_Codigo;
            drProcesos["PROC_Estado"] = true;
            dtProcesos.Rows.Add(drProcesos);

            // Bloqueos de usuarios - Realizado por Finanzas
            drProcesos = dtProcesos.NewRow();
            drProcesos["PROC_Codigo"] = _proc_codigo;
            _proc_codigo += 1;
            drProcesos["PROC_Desc"] = "ACCESO A DATOS DE FINANZAS EN MAESTRO DE ENTIDAD";
            drProcesos["PROC_DescC"] = variables.ENTC_ACCESOFINANZAS;
            drProcesos["APLI_Codigo"] = ItemAplicacion.APLI_Codigo;
            drProcesos["PROC_Estado"] = true;
            dtProcesos.Rows.Add(drProcesos);

            var BL_Empresas = ContainerService.Resolve<NextAdmin.BusinessLogic.IBLEmpresas>();
            var BL_Aplicacion = ContainerService.Resolve<NextAdmin.BusinessLogic.IBLAplicaciones>();

            Boolean _EMPR_Correcto = BL_Empresas.SaveValidar(ref m_itemEmpresa);
            Boolean _APLI_Correcto = BL_Aplicacion.ValidateApplication(ref m_itemAplicacion, dtOpciones, dtProcesos);

            if (_EMPR_Correcto && _APLI_Correcto)
            {
               ItemEmpresa = BL_Empresas.GetOne(m_itemEmpresa.EMPR_Codigo);

               if (_APLI_Correcto)
               {
                  ItemAplicacion = BL_Aplicacion.GetOne(m_itemAplicacion.APLI_Codigo);
                  Session.AplicacionCodigo = ItemAplicacion.APLI_Codigo;
               }
               else
               {
                  Session.AplicacionCodigo = null;
               }
            }
         }
         catch (Exception ex)
         {
            Dialogos.MostrarMensajeError(Text, "Ha ocurrido un error verificando las opciones.", ex);
         }
      }
      private void ValidateUserOptions()
      {
         try
         {
            var BL_PermisosUsuarioOpciones = ContainerService.Resolve<NextAdmin.BusinessLogic.IBLPermisosUsuarioOpciones>();
            ListPermisos = new ObservableCollection<NextAdmin.BusinessLogic.PermisosUsuarioOpciones>();
            if (ItemUsuario != null && ItemEmpresa != null && ItemAplicacion != null)
            {
               ListPermisos = BL_PermisosUsuarioOpciones.GetAllByUsuarioEmpresaCodigo(ItemUsuario.USUA_Codigo, ItemEmpresa.EMPR_Codigo, ItemAplicacion.APLI_Codigo);
               //ListPermisos = ClientAdmin.GetAllPermisosUsuarioOpcionesByUsuario(ItemUsuario.USUA_Codigo, ItemEmpresa.EMPR_Codigo, ItemAplicacion.APLI_Codigo); 
            }

            CleanOutlookButtons();

            ValidateOutlookButton("MANTE", ref toolMantenimientos);
            ValidateOutlookButton("COMER", ref toolComercial);
            ValidateOutlookButton("OPERA", ref toolOperaciones);
            ValidateOutlookButton("LOGIS", ref toolLogistico);
            ValidateOutlookButton("FINAN", ref toolFinanzas);
            ValidateOutlookButton("REPOR", ref toolReportes);
                ValidateOutlookButton("SELOG", ref toolServicioLogistico);
                ValidateOutlookButton("TARIF", ref toolTarifario);
            }
         catch (Exception)
         {
         }
      }
      private void CleanOutlookButtons()
      {
         try
         {
            olbMenuAlmafin.Buttons.Clear();
            ShowMenu("");
            pnlBotones.Height = 0;
            //olbMenuAlmafin.Height = 0;
         }
         catch (Exception)
         {
         }
      }
      private void ValidateOutlookButton(string opcion, ref ToolStrip tool)
      {
         try
         {
            NextAdmin.BusinessLogic.PermisosUsuarioOpciones _permiso;

            _permiso = ListPermisos.Where(puop => puop.OPCI_DescC == opcion).FirstOrDefault();
            if (_permiso != null)
            {
               switch (_permiso.PUOP_Permiso.ToUpper())
               {
                  case "H":
                     AddOutlookButton(opcion, true);
                     ValidateToolStripOption(ref tool);
                     break;
                  case "O":
                     //olbMenuAlmafin.Buttons.RemoveAt(i);
                     //i -= 1;
                     break;
                  case "D":
                     AddOutlookButton(opcion, false);
                     //olbMenuAlmafin.Buttons[i].Enabled = false;
                     break;
                  default:
                     break;
               }
            }
            else
            {
               //olbMenuAlmafin.Buttons.RemoveAt(i);
               //i -= 1;
            }
         }
         catch (Exception)
         {
         }
      }
      private void ValidateToolStripOption(ref ToolStrip tool)
      {
         try
         {
            NextAdmin.BusinessLogic.PermisosUsuarioOpciones _permiso;
            for (int j = 0; j < tool.Items.Count; j++)
            {
               ToolStripItem subitem = tool.Items[j];

               _permiso = ListPermisos.Where(puop => puop.OPCI_DescC == subitem.Tag.ToString()).FirstOrDefault();
               if (_permiso != null)
               {
                  switch (_permiso.PUOP_Permiso.ToUpper())
                  {
                     case "H":
                        tool.Items[j].Enabled = true;
                        break;
                     case "O":
                        tool.Items[j].Visible = false;
                        //tool.Items.RemoveAt(j); j -= 1;
                        break;
                     case "D":
                        tool.Items[j].Enabled = false;
                        break;
                     default:
                        break;
                  }
               }
               else
               {
                  tool.Items[j].Visible = false;
                  //tool.Items.RemoveAt(j); j -= 1; 
               }

               if (subitem is ToolStripDropDownButton)
               {
                  for (int k = 0; k < ((ToolStripDropDownButton)subitem).DropDownItems.Count; k++)
                  {
                     ToolStripItem subsubitem = ((ToolStripDropDownButton)subitem).DropDownItems[k];

                     _permiso = ListPermisos.Where(puop => puop.OPCI_DescC == subsubitem.Tag.ToString()).FirstOrDefault();
                     if (_permiso != null)
                     {
                        switch (_permiso.PUOP_Permiso.ToUpper())
                        {
                           case "H":
                              ((ToolStripDropDownButton)subitem).DropDownItems[k].Enabled = true;
                              break;
                           case "O":
                              ((ToolStripDropDownButton)subitem).DropDownItems[k].Visible = false;
                              //((ToolStripDropDownButton)subitem).DropDownItems.RemoveAt(k); k -= 1;
                              break;
                           case "D":
                              ((ToolStripDropDownButton)subitem).DropDownItems[k].Enabled = false;
                              break;
                           default:
                              break;
                        }
                     }
                     else
                     {
                        ((ToolStripDropDownButton)subitem).DropDownItems[k].Visible = false;
                        //((ToolStripDropDownButton)subitem).DropDownItems.RemoveAt(k); k -= 1; 
                     }
                  }
               }
            }
         }
         catch (Exception)
         {
         }
      }
      private void AddOutlookButton(string opcion, bool enabled)
      {
         try
         {
            switch (opcion)
            {
               case "MANTE":
                  OutlookBarButton outlookBarButton1 = new OutlookBarButton();
                  outlookBarButton1.Enabled = enabled;
                  outlookBarButton1.Image = Resources.cube_blue;
                  outlookBarButton1.Tag = opcion;
                  outlookBarButton1.Text = "Mantenimientos";
                  olbMenuAlmafin.Buttons.Add(outlookBarButton1);

                  pnlBotones.Height += 32;

                  break;
               case "COMER":
                  OutlookBarButton outlookBarButton2 = new OutlookBarButton();
                  outlookBarButton2.Enabled = enabled;
                  outlookBarButton2.Image = Resources.index_replace;
                  outlookBarButton2.Tag = "COMER";
                  outlookBarButton2.Text = "Comercial";
                  olbMenuAlmafin.Buttons.Add(outlookBarButton2);

                  pnlBotones.Height += 32;

                  break;
               case "OPERA":
                  OutlookBarButton outlookBarButtonOperaciones = new OutlookBarButton();
                  outlookBarButtonOperaciones.Enabled = enabled;
                  outlookBarButtonOperaciones.Image = Resources.package;
                  outlookBarButtonOperaciones.Tag = "OPERA";
                  outlookBarButtonOperaciones.Text = "Operaciones";
                  olbMenuAlmafin.Buttons.Add(outlookBarButtonOperaciones);

                  pnlBotones.Height += 32;

                  break;
               case "LOGIS":
                  OutlookBarButton outlookBarButton3 = new OutlookBarButton();
                  outlookBarButton3.Enabled = enabled;
                  outlookBarButton3.Image = Resources.Order_Tracking_toolbar_32x32;
                  outlookBarButton3.Tag = "LOGIS";
                  outlookBarButton3.Text = "Logistico";
                  olbMenuAlmafin.Buttons.Add(outlookBarButton3);

                  pnlBotones.Height += 32;

                  break;
               case "FINAN":
                  OutlookBarButton outlookBarButtonFinanzas = new OutlookBarButton();
                  outlookBarButtonFinanzas.Enabled = enabled;
                  outlookBarButtonFinanzas.Image = resizeImage(Resources.Finanzas, new Size(26, 26));
                  outlookBarButtonFinanzas.Tag = "FINAN";
                  outlookBarButtonFinanzas.Text = "Finanzas";
                  olbMenuAlmafin.Buttons.Add(outlookBarButtonFinanzas);

                  pnlBotones.Height += 32;

                  break;
               case "REPOR":
                  OutlookBarButton outlookBarButton4 = new OutlookBarButton();
                  outlookBarButton4.Enabled = enabled;
                  outlookBarButton4.Image = resizeImage(Resources.Reportes, new Size(26, 26));
                        outlookBarButton4.Tag = "REPOR";
                  outlookBarButton4.Text = "Reportes";
                  olbMenuAlmafin.Buttons.Add(outlookBarButton4);

                  pnlBotones.Height += 32;

                  break;
                    case "SELOG":
                        OutlookBarButton outlookBarButtonServicioLogistico = new OutlookBarButton();
                        outlookBarButtonServicioLogistico.Enabled = enabled;
                        outlookBarButtonServicioLogistico.Image = resizeImage(Resources.ServicioLogistico, new Size(32, 32)); 
                        outlookBarButtonServicioLogistico.Tag = "SELOG";
                        outlookBarButtonServicioLogistico.Text = "Servicio Logístico";
                        olbMenuAlmafin.Buttons.Add(outlookBarButtonServicioLogistico);

                        pnlBotones.Height += 32;

                        break;
                    case "TARIF":
                        OutlookBarButton outlookBarButtonTarifario = new OutlookBarButton();
                        outlookBarButtonTarifario.Enabled = enabled;
                        outlookBarButtonTarifario.Image = resizeImage(Resources.Tarifario, new Size(28, 28));
                        outlookBarButtonTarifario.Tag = "TARIF";
                        outlookBarButtonTarifario.Text = "Tarifario";
                        olbMenuAlmafin.Buttons.Add(outlookBarButtonTarifario);

                        pnlBotones.Height += 32;

                        break;
                }
         }
         catch (Exception)
         {
         }
      }
        public static Image resizeImage(Image imgToResize, Size size)
        {
            return (Image)(new Bitmap(imgToResize, size));
        }

      private void ShowMenu(string x_opcion)
      {
         try
         {
            pnlMenuMantenimientos.Visible = (x_opcion == "MANTE");
            pnlMenuComercial.Visible = (x_opcion == "COMER");
            pnlMenuOperaciones.Visible = (x_opcion == "OPERA");
            pnlMenuLogistico.Visible = (x_opcion == "LOGIS");
            pnlMenuFinanzas.Visible = (x_opcion == "FINAN");
            pnlMenuReportes.Visible = (x_opcion == "REPOR");
                pnlMenuServicioLogistico.Visible = (x_opcion == "SELOG");
                pnlMenuTarifario.Visible = (x_opcion == "TARIF");

                switch (x_opcion)
            {
               case "MANTE":
                  pnlMenuMantenimientos.Dock = DockStyle.Fill;
                  break;
               case "COMER":
                  pnlMenuComercial.Dock = DockStyle.Fill;
                  break;
               case "OPERA":
                  pnlMenuOperaciones.Dock = DockStyle.Fill;
                  break;
               case "LOGIS":
                  pnlMenuLogistico.Dock = DockStyle.Fill;
                  break;
               case "FINAN":
                  pnlMenuFinanzas.Dock = DockStyle.Fill;
                  break;
               case "REPOR":
                  pnlMenuReportes.Dock = DockStyle.Fill;
                  break;
                    case "SELOG":
                        pnlMenuServicioLogistico.Dock = DockStyle.Fill;
                        break;
                    case "TARIF":
                        pnlMenuTarifario.Dock = DockStyle.Fill;
                        break;
                    default:
                  break;
            }
         }
         catch (Exception)
         {
         }
      }
      #endregion

      #region [ Propiedades ]
      public IUnityContainer ContainerService { get; set; }
      public ISessionService Session { get; set; }
      private String CadenaConexionAdmin;
      #endregion

      #region [ Eventos ]

      private void dtpFecha_ValueChanged(object sender, EventArgs e)
      {
         //if (Session.Fecha != dtpFecha.Value)
         //{ Session.Fecha = dtpFecha.Value; }
      }
      private void btnCerrarSesion_Click(object sender, EventArgs e)
      {
         Autenticar(false);
      }
      private void btnChangePassword_Click(object sender, EventArgs e)
      {
         ActualizarPassword();
      }
      private void btnConeccion_Click(object sender, EventArgs e)
      {
         //InitilizeConexion(); 
      }
      private void tsbtnCerrarSesion_Click(object sender, EventArgs e)
      {
         Session.CerrarSesion();
         lblUsuario.Text = "Bienvenido(0) .";
         tabViews.Pages.Clear();
         Autenticar(false);
      }
      private void tsbtnSalir_Click(object sender, EventArgs e)
      {
         Close();
      }

      #region [ Form Events ]
      private void CloseAllViews()
      {
         try
         {
            OPE011_mview = null;
            OPE012_mview = null;
            LOG006_mview = null;
            LOG009_mview = null;
            COM013_mview = null;
            COM014_mview = null;

            MAN000_lview = null;
            MAN000_mview = null;
            MAN000_presenter = null;

            MAN001_lview = null;
            MAN001_mview = null;
            MAN001_presenter = null;

            MAN002_lview = null;
            MAN002_mview = null;
            MAN002_presenter = null;

            MAN003_lview = null;
            MAN003_mview = null;
            MAN003_presenter = null;

            MAN004_lview = null;
            MAN004_mview = null;
            MAN004_presenter = null;

            //MAN005_lview = null;
            //MAN005_mview = null;
            //MAN005_presenter = null;

            MAN006_lview = null;
            MAN006_mview = null;
            MAN006_presenter = null;

            MAN007_lview = null;
            MAN007_mview = null;
            MAN007_presenter = null;

            MAN008_lview = null;
            MAN008_mview = null;
            MAN008_presenter = null;

            MAN0091_lview = null;
            MAN0091_mview = null;
            MAN0091_presenter = null;

            MAN0092_lview = null;
            MAN0092_mview = null;
            MAN0092_presenter = null;

            MAN0093_lview = null;
            MAN0093_mview = null;
            MAN0093_presenter = null;

            MAN0094_lview = null;
            MAN0094_mview = null;
            MAN0094_presenter = null;

            MAN0095_lview = null;
            MAN0095_mview = null;
            MAN0095_presenter = null;

            MAN0096_lview = null;
            MAN0096_mview = null;
            MAN0096_presenter = null;

            MAN0097_lview = null;
            MAN0097_mview = null;
            MAN0097_presenter = null;

            MAN0098_lview = null;
            MAN0098_mview = null;
            MAN0098_presenter = null;

            //MAN0099_lview = null;
            //MAN0099_mview = null;
            //MAN0099_presenter = null;

            MAN00910_lview = null;
            MAN00910_mview = null;
            MAN00910_presenter = null;

            MAN00911_lview = null;
            MAN00911_mview = null;
            MAN00911_presenter = null;

            MAN00912_lview = null;
            MAN00912_mview = null;
            MAN00912_presenter = null;

            MAN00913_lview = null;
            MAN00913_mview = null;
            MAN00913_presenter = null;

            MAN00914_lview = null;
            MAN00914_mview = null;
            MAN00914_presenter = null;

            MAN00915_lview = null;
            MAN00915_mview = null;
            MAN00915_presenter = null;

            MAN00916_lview = null;
            MAN00916_mview = null;
            MAN00916_presenter = null;

            MAN010_lview = null;
            MAN010_mview = null;
            MAN010_presenter = null;

            MAN011_lview = null;
            MAN011_mview = null;
            MAN011_presenter = null;

            MAN012_lview = null;
            MAN012_mview = null;
            MAN012_presenter = null;

            MAN013_lview = null;
            MAN013_mview = null;
            MAN013_presenter = null;

            MAN014_lview = null;
            MAN014_mview = null;
            MAN014_presenter = null;

            MAN015_lview = null;
            MAN015_mview = null;
            MAN015_presenter = null;

            MAN016_lview = null;
            MAN016_mview = null;
            MAN016_presenter = null;

            COM001_lview = null;
            COM001_presenter = null;

            COM002_lview = null;
            COM002_presenter = null;

            COM003_lview = null;
            COM003_presenter = null;

            COM004_lview = null;
            COM004_presenter = null;

            COM005_lview = null;
            COM005_presenter = null;

            COM006_lview = null;
            COM006_mview = null;
            COM006_dview = null;
            COM006_presenter = null;

            COM007_lview = null;
            COM007_mview = null;
            COM007_presenter = null;

            COM008_lview = null;
            COM008_mview = null;
            COM008_presenter = null;

            PRO001_LView = null;
            PRO001_MView = null;
            PRO001_DView = null;
            PRO001_DSView = null;
            PRO001_Presenter = null;

            PRO0001_LView = null;
            PRO0001_MView = null;
            PRO0001_DView = null;
            PRO0001_DSView = null;
            PRO0001_Presenter = null;

            PRO00001_LView = null;
            PRO00001_MView = null;
            PRO00001_DView = null;
            PRO00001_DSView = null;
            PRO00001_Presenter = null;

            PRO002_LView = null;
            PRO002_MView = null;
            PRO002_DView = null;
            PRO002_DSView = null;
            PRO002_Presenter = null;
            PRO002_Imprimir = null;

            PRO003_LView = null;
            PRO003_MView = null;
            PRO003_DView = null;
            PRO003_DSView = null;
            PRO003_Presenter = null;

            PRO005_LView = null;
            PRO005_Presenter = null;

            PRO004_LView = null;
            PRO004_Presenter = null;

            PRO006_LView = null;
            PRO006_MView = null;
            PRO006_DMView = null;
            PRO006_Presenter = null;

            PRO007_LView = null;
            PRO007_MView = null;
            PRO007_RMView = null;
            PRO007_Presenter = null;

            PRO007FE_LView = null;
            PRO007FE_MView = null;
            PRO007FE_RMView = null;
            PRO007FE_Presenter = null;

            PRO008_LView = null;
            PRO008_MView = null;
            PRO008_Presenter = null;

            //PRO009_LView = null;
            //PRO009_MView = null;
            //PRO009_Presenter = null;

            PRO010_LView = null;
            PRO010_MView = null;
            PRO010_Presenter = null;
            PRO010_RView = null;

            PRO011_LView = null;
            PRO011_MView = null;
            PRO011_Presenter = null;
            PRO011_RView = null;

            PRO007PRE_LView = null;
            PRO007PRE_MView = null;
            PRO007PRE_Presenter = null;

            MAN013_lview = null;
            MAN013_mview = null;
            MAN013_presenter = null;

            REP005_LView = null;
            REP005_MView = null;
            REP005_Presenter = null;

            REP005S_LView = null;
            REP005S_MView = null;
            REP005S_Presenter = null;

            REP005L_LView = null;
            REP005L_MView = null;
            REP005L_Presenter = null;

            REP006_LView = null;
            REP006_MView = null;
            REP006_Presenter = null;

            REP007_LView = null;
            REP007_RMView = null;
            REP007_Presenter = null;

            REP008_LView = null;
            REP008_RMView = null;
            REP008_Presenter = null;

            REP009_lview = null;
            REP009_presenter = null;

            REP010_lview = null;
            REP010_presenter = null;

            REP011_lview = null;
            REP011_presenter = null;

            REP012_lview = null;
            REP012_presenter = null;

            REP013_lview = null;
            REP013_presenter = null;

            REP0081_LView = null;
            REP0081_RMView = null;
            REP0081_Presenter = null;

            CAJ001_lview = null;
            CAJ001_mview = null;
            CAJ001_presenter = null;

            CAJ002_lview = null;
            CAJ002_presenter = null;

            CAJ003_lview = null;
            CAJ003_presenter = null;

            CAJ004_lview = null;
            CAJ004_presenter = null;

            CAJ005_lview = null;
            CAJ005_presenter = null;

            CAJ006_lview = null;
            CAJ006_presenter = null;

            CAJ007_lview = null;
            CAJ007_presenter = null;

            CAJ008_lview = null;
            CAJ008_presenter = null;

            CAJ010_lview = null;
            CAJ010_presenter = null;

            CAJ011_lview = null;
            CAJ011_presenter = null;

            CAJ012_lview = null;
            CAJ012_presenter = null;

            CAJ013_lview = null;
            CAJ013_presenter = null;

            CAJ014_lview = null;
            CAJ014_presenter = null;

            CAJ015_lview = null;
            CAJ015_presenter = null;

            CAJ018_lview = null;
            CAJ018_presenter = null;

            OPE001_lview = null;
            OPE001_mview = null;
            OPE001_presenter = null;

            DOC002_lview = null;
            DOC002_mview = null;
            DOC002_presenter = null;

            REP001_FinanzasLview = null;
            REP001_FinanzasPresenter = null;

            REP002_FinanzasLview = null;
            REP002_FinanzasPresenter = null;

            REP003_FinanzasLview = null;
            REP003_FinanzasPresenter = null;

            REP004_FinanzasLview = null;
            REP004_FinanzasPresenter = null;

            REP004_FinanzasLview02 = null;
            REP004_FinanzasPresenter02 = null;

            REP004_FinanzasLview03 = null;
            REP004_FinanzasPresenter = null;

            REP004_FinanzasLview04 = null;
            REP004_FinanzasPresenter04 = null;

            //REP005_FinanzasLview = null;
            //REP005_FinanzasPresenter = null;

            //REP006_FinanzasLview = null;
            //REP006_FinanzasPresenter = null;

            REP007_FinanzasLview = null;
            REP007_FinanzasPresenter = null;

            REP008_FinanzasLview = null;
            REP008_FinanzasPresenter = null;

            REP009_FinanzasLview = null;
            REP009_FinanzasPresenter = null;

            REP015_FinanzasLview = null;
            REP015_FinanzasPresenter = null;

            REP010_FinanzasLview = null;
            REP010_FinanzasPresenter = null;

            PRO022_LView = null;
            PRO022_MView = null;
            PRO022_Presenter = null;

            OPE005LView = null;
            OPE005Presenter = null;

            OPE006LView = null;
            OPE006Presenter = null;

            OPE007LView = null;
            OPE007Presenter = null;

            OPE008LView = null;
            OPE008Presenter = null;
         }
         catch (Exception)
         {
         }
      }

      [DllImport("kernel32.dll", EntryPoint = "SetProcessWorkingSetSize", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
      private static extern int SetProcessWorkingSetSize(IntPtr process, int minimumWorkingSetSize, int maximumWorkingSetSize);

      private void View_CloseForm(object sender, FormCloseEventArgs e)
      {
         try
         {
            tabViews.Pages.Remove((RadPageViewPage)e.TabPageControl);
            if (!String.IsNullOrEmpty(e.CUS))
            {
                FormPageClosed(e.CUS);
               //switch (e.CUS)
               //{
               //   case "MAN000":
               //      MAN000_lview = null;
               //      MAN000_mview = null;
               //      MAN000_presenter = null;
               //      break;
               //   case "MAN001":
               //      MAN001_lview = null;
               //      MAN001_mview = null;
               //      MAN001_presenter = null;
               //      break;
               //   case "MAN002":
               //      MAN002_lview = null;
               //      MAN002_mview = null;
               //      MAN002_presenter = null;
               //      break;
               //   case "MAN003":
               //      MAN003_lview = null;
               //      MAN003_mview = null;
               //      MAN003_presenter = null;
               //      break;
               //   case "MAN004":
               //      MAN004_lview = null;
               //      MAN004_mview = null;
               //      MAN004_presenter = null;
               //      break;
               //   case "MAN005":
               //      //MAN005_lview = null;
               //      //MAN005_mview = null;
               //      //MAN005_presenter = null;
               //      break;
               //   case "MAN006":
               //      MAN006_lview = null;
               //      MAN006_mview = null;
               //      MAN006_presenter = null;
               //      break;
               //   case "MAN007":
               //      MAN007_lview = null;
               //      MAN007_mview = null;
               //      MAN007_presenter = null;
               //      break;
               //   case "MAN008":
               //      MAN008_lview = null;
               //      MAN008_mview = null;
               //      MAN008_presenter = null;
               //      break;
               //   case "MAN0091":
               //      MAN0091_lview = null;
               //      MAN0091_mview = null;
               //      MAN0091_presenter = null;
               //      break;
               //   case "MAN0092":
               //      MAN0092_lview = null;
               //      MAN0092_mview = null;
               //      MAN0092_presenter = null;
               //      break;
               //   case "MAN0093":
               //      MAN0093_lview = null;
               //      MAN0093_mview = null;
               //      MAN0093_presenter = null;
               //      break;
               //   case "MAN0094":
               //      MAN0094_lview = null;
               //      MAN0094_mview = null;
               //      MAN0094_presenter = null;
               //      break;
               //   case "MAN0095":
               //      MAN0095_lview = null;
               //      MAN0095_mview = null;
               //      MAN0095_presenter = null;
               //      break;
               //   case "MAN0096":
               //      MAN0096_lview = null;
               //      MAN0096_mview = null;
               //      MAN0096_presenter = null;
               //      break;
               //   case "MAN0097":
               //      MAN0097_lview = null;
               //      MAN0097_mview = null;
               //      MAN0097_presenter = null;
               //      break;
               //   case "MAN0098":
               //      MAN0098_lview = null;
               //      MAN0098_mview = null;
               //      MAN0098_presenter = null;
               //      break;
               //   case "MAN0099":
               //      //MAN0099_lview = null;
               //      //MAN0099_mview = null;
               //      //MAN0099_presenter = null;
               //      break;
               //   case "MAN00910":
               //      MAN00910_lview = null;
               //      MAN00910_mview = null;
               //      MAN00910_presenter = null;
               //      break;
               //   case "MAN00911":
               //      MAN00911_lview = null;
               //      MAN00911_mview = null;
               //      MAN00911_presenter = null;
               //      break;
               //   case "MAN00912":
               //      MAN00912_lview = null;
               //      MAN00912_mview = null;
               //      MAN00912_presenter = null;
               //      break;
               //   case "MAN00913":
               //      MAN00913_lview = null;
               //      MAN00913_mview = null;
               //      MAN00913_presenter = null;
               //      break;
               //   case "MAN00914":
               //      MAN00914_lview = null;
               //      MAN00914_mview = null;
               //      MAN00914_presenter = null;
               //      break;
               //   case "MAN00915":
               //      MAN00915_lview = null;
               //      MAN00915_mview = null;
               //      MAN00915_presenter = null;
               //      break;
               //   case "MAN00916":
               //      MAN00916_lview = null;
               //      MAN00916_mview = null;
               //      MAN00916_presenter = null;
               //      break;
               //   case "MAN010":
               //      MAN010_lview = null;
               //      MAN010_mview = null;
               //      MAN010_presenter = null;
               //      break;
               //   case "MAN011":
               //      MAN011_lview = null;
               //      MAN011_mview = null;
               //      MAN011_presenter = null;
               //      break;
               //   case "MAN012":
               //      MAN012_lview = null;
               //      MAN012_mview = null;
               //      MAN012_presenter = null;
               //      break;
               //   case "MAN013":
               //      MAN013_lview = null;
               //      MAN013_mview = null;
               //      MAN013_presenter = null;
               //      break;
               //   case "MAN014":
               //      MAN014_lview = null;
               //      MAN014_mview = null;
               //      MAN014_presenter = null;
               //      break;
               //   case "MAN015":
               //      MAN015_lview = null;
               //      MAN015_mview = null;
               //      MAN015_presenter = null;
               //      break;
               //   case "MAN016":
               //      MAN016_lview = null;
               //      MAN016_mview = null;
               //      MAN016_presenter = null;
               //      break;
               //   case "COM001":
               //      COM001_lview = null;
               //      COM001_presenter = null;
               //      break;
               //   case "COM002":
               //      COM002_lview = null;
               //      COM002_presenter = null;
               //      break;
               //   case "COM003":
               //      COM003_lview = null;
               //      COM003_presenter = null;
               //      break;
               //   case "COM004":
               //      COM004_lview = null;
               //      COM004_presenter = null;
               //      break;
               //   case "COM005":
               //      COM005_lview = null;
               //      COM005_presenter = null;
               //      break;
               //   case "COM006":
               //      COM006_lview = null;
               //      COM006_mview = null;
               //      COM006_dview = null;
               //      COM006_presenter = null;
               //      break;
               //   case "COM007":
               //      COM007_lview = null;
               //      COM007_mview = null;
               //      COM007_presenter = null;
               //      break;
               //   case "COM008":
               //      COM008_lview = null;
               //      COM008_mview = null;
               //      COM008_presenter = null;
               //      break;
               //   case "REP001":
               //      REP001_lview = null;
               //      REP001_presenter = null;
               //      break;
               //   case "REP002":
               //      REP002_lview = null;
               //      REP002_presenter = null;
               //      break;
               //   case "REP003":
               //      REP003_lview = null;
               //      REP003_presenter = null;
               //      break;
               //   case "REP004":
               //      REP004_lview = null;
               //      REP004_presenter = null;
               //      break;
               //   case "LOG001":
               //      PRO001_LView = null;
               //      PRO001_MView = null;
               //      PRO001_DSView = null;
               //      PRO001_DView = null;
               //      PRO001_Presenter = null;
               //      break;
               //   case "LOG0001":
               //      PRO0001_LView = null;
               //      PRO0001_MView = null;
               //      PRO0001_DView = null;
               //      PRO0001_DSView = null;
               //      PRO0001_Presenter = null;
               //      break;
               //   case "LOG00001":
               //      PRO00001_LView = null;
               //      PRO00001_MView = null;
               //      PRO00001_DView = null;
               //      PRO00001_DSView = null;
               //      PRO00001_Presenter = null;
               //      break;
               //   case "LOG002":
               //      PRO002_LView = null;
               //      PRO002_MView = null;
               //      PRO002_DView = null;
               //      PRO002_DSView = null;
               //      PRO002_Presenter = null;
               //      PRO002_Imprimir = null;
               //      break;
               //   case "LOG003":
               //      PRO003_LView = null;
               //      PRO003_MView = null;
               //      PRO003_DView = null;
               //      PRO003_DSView = null;
               //      PRO003_Presenter = null;
               //      break;
               //   case "LOG004":
               //      PRO004_LView = null;
               //      PRO004_Presenter = null;
               //      break;
               //   case "LOG005":
               //      PRO005_LView = null;
               //      PRO005_Presenter = null;
               //      break;
               //   case "LOG006":
               //      PRO006_LView = null;
               //      PRO006_MView = null;
               //      PRO006_DMView = null;
               //      PRO006_Presenter = null;
               //      break;
               //   case "Factura":
               //      PRO007_LView = null;
               //      PRO007_MView = null;
               //      PRO007_RMView = null;
               //      PRO007_Presenter = null;
               //      break;
               //   case "Facturación Electrónica":
               //      PRO007FE_LView = null;
               //      PRO007FE_MView = null;
               //      PRO007FE_RMView = null;
               //      PRO007FE_Presenter = null;
               //      break;
               //   case "LOG008":
               //      PRO008_LView = null;
               //      PRO008_MView = null;
               //      PRO008_Presenter = null;
               //      break;
               //   //case "LOG009":
               //   //   PRO009_LView = null;
               //   //   PRO009_MView = null;
               //   //   PRO009_Presenter = null;
               //   //   break;
               //   case "LOG010":
               //      PRO010_LView = null;
               //      PRO010_MView = null;
               //      PRO010_Presenter = null;
               //      PRO010_RView = null;
               //      break;
               //   case "LOG011":
               //      PRO011_LView = null;
               //      PRO011_MView = null;
               //      PRO011_Presenter = null;
               //      PRO010_RView = null;
               //      break;
               //   case "PreFactura":
               //      PRO007PRE_LView = null;
               //      PRO007PRE_MView = null;
               //      PRO007PRE_Presenter = null;
               //      break;
               //   case "REP005Con":
               //      REP005_LView = null;
               //      REP005_MView = null;
               //      REP005_Presenter = null;
               //      break;
               //   case "REP005Sin":
               //      REP005S_LView = null;
               //      REP005S_MView = null;
               //      REP005S_Presenter = null;
               //      break;
               //   case "REP005Liq":
               //      REP005L_LView = null;
               //      REP005L_MView = null;
               //      REP005L_Presenter = null;
               //      break;
               //   case "REP006":
               //      REP006_LView = null;
               //      REP006_MView = null;
               //      REP006_Presenter = null;
               //      break;
               //   case "REP007":
               //      REP007_LView = null;
               //      REP007_RMView = null;
               //      REP007_Presenter = null;
               //      break;
               //   case "REP008":
               //      REP008_LView = null;
               //      REP008_RMView = null;
               //      REP008_Presenter = null;
               //      break;
               //   case "REP0081":
               //      REP0081_LView = null;
               //      REP0081_RMView = null;
               //      REP0081_Presenter = null;
               //      break;
               //   case "REP009":
               //      REP009_lview = null;
               //      //REP009_RMView = null;
               //      REP009_presenter = null;
               //      break;
               //   case "REP010":
               //      REP010_lview = null;
               //      //REP009_RMView = null;
               //      REP010_presenter = null;
               //      break;
               //   case "REP011":
               //      REP011_lview = null;
               //      //REP009_RMView = null;
               //      REP011_presenter = null;
               //      break;
               //   case "REP012":
               //      REP012_lview = null;
               //      //REP009_RMView = null;
               //      REP012_presenter = null;
               //      break;
               //   case "REP013":
               //      REP013_lview = null;
               //      //REP013_RMView = null;
               //      REP013_presenter = null;
               //      break;
               //   case "CAJ001":
               //      CAJ001_lview = null;
               //      CAJ001_mview = null;
               //      CAJ001_presenter = null;
               //      break;
               //   case "CAJ002":
               //      CAJ002_lview = null;
               //      CAJ002_presenter = null;
               //      break;
               //   case "CAJ003":
               //      CAJ003_lview = null;
               //      CAJ003_presenter = null;
               //      break;
               //   case "CAJ004":
               //      CAJ004_lview = null;
               //      CAJ004_presenter = null;
               //      break;
               //   case "CAJ005":
               //      CAJ005_lview = null;
               //      CAJ005_presenter = null;
               //      break;
               //   case "CAJ006":
               //      CAJ006_lview = null;
               //      CAJ006_presenter = null;
               //      break;
               //   case "CAJ007":
               //      CAJ007_lview = null;
               //      CAJ007_presenter = null;
               //      break;
               //   case "CAJ008":
               //      CAJ008_lview = null;
               //      CAJ008_presenter = null;
               //      break;
               //   case "CAJ009":

               //      break;
               //   case "CAJ010":
               //      CAJ010_lview = null;
               //      CAJ010_presenter = null;
               //      break;
               //   case "CAJ011":
               //      CAJ011_lview = null;
               //      CAJ011_presenter = null;
               //      break;
               //   case "CAJ012":
               //      CAJ012_lview = null;
               //      CAJ012_presenter = null;
               //      break;
               //   case "CAJ013":
               //      CAJ013_lview = null;
               //      CAJ013_presenter = null;
               //      break;
               //   case "CAJ014":
               //      CAJ014_lview = null;
               //      CAJ014_presenter = null;
               //      break;
               //   case "CAJ016":
               //      CAJ015_lview = null;
               //      CAJ015_presenter = null;
               //      break;
               //   case "CAJ018":
               //      CAJ018_lview = null;
               //      CAJ018_presenter = null;
               //      break;
               //   case "OPE001":
               //      OPE001_lview = null;
               //      OPE001_mview = null;
               //      OPE001_presenter = null;
               //      break;

               //   case "DOC002":
               //      DOC002_lview = null;
               //      DOC002_mview = null;
               //      DOC002_presenter = null;
               //      break;
               //   case "REPF001":
               //      REP001_FinanzasLview = null;
               //      REP001_FinanzasPresenter = null;
               //      break;
               //   case "REPF002":
               //      REP002_FinanzasLview = null;
               //      REP002_FinanzasPresenter = null;
               //      break;
               //   case "REPF003":
               //      REP003_FinanzasLview = null;
               //      REP003_FinanzasPresenter = null;
               //      break;
               //   case "REPF0040":
               //      REP004_FinanzasLview = null;
               //      REP004_FinanzasPresenter = null;
               //      break;
               //   case "REPF0046":
               //      REP004_FinanzasLview02 = null;
               //      REP004_FinanzasPresenter02 = null;
               //      break;
               //   case "REPF0042":
               //      REP004_FinanzasLview03 = null;
               //      REP004_FinanzasPresenter03 = null;
               //      break;
               //   case "REPF0045":
               //      REP004_FinanzasLview04 = null;
               //      REP004_FinanzasPresenter04 = null;
               //      break;
               //   case "REP015":
               //      REP015_FinanzasLview = null;
               //      REP015_FinanzasPresenter = null;
               //      break;
               //   case "REP0101":
               //      REP010_FinanzasLview = null;
               //      REP010_FinanzasPresenter = null;
               //      break;
               //   //case "REPF005":
               //   //   REP005_FinanzasLview = null;
               //   //   REP005_FinanzasPresenter = null;
               //   //   break;
               //   //case "REPF006":
               //   //   REP006_FinanzasLview = null;
               //   //   REP006_FinanzasPresenter = null;
               //   //   break;
               //   case "REPF007":
               //      REP007_FinanzasLview = null;
               //      REP007_FinanzasPresenter = null;
               //      break;
               //   case "REPF008":
               //      REP008_FinanzasLview = null;
               //      REP008_FinanzasPresenter = null;
               //      break;
               //   case "REPF009":
               //      REP009_FinanzasLview = null;
               //      REP009_FinanzasPresenter = null;
               //      break;
               //   case "PRO022":
               //      PRO022_LView = null;
               //      PRO022_MView = null;
               //      PRO022_Presenter = null;
               //      break;
               //   case "OPE005":
               //      OPE005LView = null;
               //      OPE005Presenter = null;
               //      break;
               //   case "OPE006":
               //      OPE006LView = null;
               //      OPE006Presenter = null;
               //      break;
               //   case "OPE007":
               //      OPE007LView = null;
               //      OPE007Presenter = null;
               //      break;
               //   case "OPE008":
               //      OPE008LView = null;
               //      OPE008Presenter = null;
               //      break;
               //}
            }
         }
         catch (Exception ex)
         {
            Dialogos.MostrarMensajeError("Delfin", "Ha ocurrido un error al cerrar la pestaña.", ex);
         }
         finally
         {
            GC.WaitForPendingFinalizers();
            GC.Collect();
            SetProcessWorkingSetSize(Process.GetCurrentProcess().Handle, -1, -1);
         }
      }

      private void olbMenuAlmafin_Click(object sender, OutlookBar.ButtonClickEventArgs e)
      {
         try
         {
            ShowMenu(e.SelectedButton.Tag.ToString());
         }
         catch (Exception ex)
         {
            Dialogos.MostrarMensajeError("Delfin", "Ha ocurrido un error al mostrar las opciones del menú.", ex);
         }
      }

      private void menu_CollapsedMenu(object sender, EventArgs e)
      {
         try
         {
            lblUsuario.Text = "";

            splitMenuContainer.Width = 35;

            menuCaptionMantenimientos.CollapsedMenu -= menu_CollapsedMenu;
            menuCaptionComercial.CollapsedMenu -= menu_CollapsedMenu;
            menuCaptionOperaciones.CollapsedMenu -= menu_CollapsedMenu;
            menuCaptionLogistico.CollapsedMenu -= menu_CollapsedMenu;
            menuCaptionFinanzas.CollapsedMenu -= menu_CollapsedMenu;
            menuCaptionReportes.CollapsedMenu -= menu_CollapsedMenu;
                menuCaptionServicioLogistico.CollapsedMenu -= menu_CollapsedMenu;
                menuCaptionTarifario.CollapsedMenu -= menu_CollapsedMenu;

            menuCaptionMantenimientos.IsCollapsed = true;
            menuCaptionComercial.IsCollapsed = true;
            menuCaptionOperaciones.IsCollapsed = true;
            menuCaptionLogistico.IsCollapsed = true;
            menuCaptionFinanzas.IsCollapsed = true;
            menuCaptionReportes.IsCollapsed = true;
                menuCaptionServicioLogistico.IsCollapsed = true;
                menuCaptionTarifario.IsCollapsed = true;

            menuCaptionMantenimientos.CollapsedMenu += menu_CollapsedMenu;
            menuCaptionComercial.CollapsedMenu += menu_CollapsedMenu;
            menuCaptionOperaciones.CollapsedMenu += menu_CollapsedMenu;
            menuCaptionLogistico.CollapsedMenu += menu_CollapsedMenu;
            menuCaptionFinanzas.CollapsedMenu += menu_CollapsedMenu;
            menuCaptionReportes.CollapsedMenu += menu_CollapsedMenu;
                menuCaptionServicioLogistico.CollapsedMenu += menu_CollapsedMenu;
                menuCaptionTarifario.CollapsedMenu += menu_CollapsedMenu;

            menuCaptionMantenimientos.Text = "";
            foreach (ToolStripItem item in toolMantenimientos.Items)
            {
               if (item.GetType() == typeof(ToolStripButton))
               {
                  ((ToolStripButton)item).DisplayStyle = ToolStripItemDisplayStyle.Image;
               }
            }
            menuCaptionComercial.Text = "";
            foreach (ToolStripItem item in toolComercial.Items)
            {
               if (item.GetType() == typeof(ToolStripButton))
               {
                  ((ToolStripButton)item).DisplayStyle = ToolStripItemDisplayStyle.Image;
               }
            }
            menuCaptionOperaciones.Text = "";
            foreach (ToolStripItem item in toolOperaciones.Items)
            {
               if (item.GetType() == typeof(ToolStripButton))
               {
                  ((ToolStripButton)item).DisplayStyle = ToolStripItemDisplayStyle.Image;
               }
            }
            menuCaptionLogistico.Text = "";
            foreach (ToolStripItem item in toolLogistico.Items)
            {
               if (item.GetType() == typeof(ToolStripButton))
               {
                  ((ToolStripButton)item).DisplayStyle = ToolStripItemDisplayStyle.Image;
               }
            }
            menuCaptionFinanzas.Text = "";
            foreach (ToolStripItem item in toolFinanzas.Items)
            {
               if (item.GetType() == typeof(ToolStripButton))
               {
                  ((ToolStripButton)item).DisplayStyle = ToolStripItemDisplayStyle.Image;
               }
            }
            menuCaptionReportes.Text = "";
            foreach (ToolStripItem item in toolReportes.Items)
            {
               if (item.GetType() == typeof(ToolStripButton))
               {
                  ((ToolStripButton)item).DisplayStyle = ToolStripItemDisplayStyle.Image;
               }
            }

                menuCaptionServicioLogistico.Text = "";
                foreach (ToolStripItem item in toolServicioLogistico.Items)
                {
                    if (item.GetType() == typeof(ToolStripButton))
                    {
                        ((ToolStripButton)item).DisplayStyle = ToolStripItemDisplayStyle.Image;
                    }
                }

                menuCaptionTarifario.Text = "";
                foreach (ToolStripItem item in toolTarifario.Items)
                {
                    if (item.GetType() == typeof(ToolStripButton))
                    {
                        ((ToolStripButton)item).DisplayStyle = ToolStripItemDisplayStyle.Image;
                    }
                }

            }
         catch (Exception)
         {
         }
      }
      private void menu_ShowMenu(object sender, EventArgs e)
      {
         try
         {
            lblUsuario.Text = "Bienvenido(a). " + Session.UserNombreCompleto;
            splitMenuContainer.Width = 185;

            menuCaptionMantenimientos.ShowMenu -= menu_ShowMenu;
            menuCaptionComercial.ShowMenu -= menu_ShowMenu;
            menuCaptionOperaciones.ShowMenu -= menu_ShowMenu;
            menuCaptionLogistico.ShowMenu -= menu_ShowMenu;
            menuCaptionFinanzas.ShowMenu -= menu_ShowMenu;
            menuCaptionReportes.ShowMenu -= menu_ShowMenu;
                menuCaptionServicioLogistico.ShowMenu -= menu_ShowMenu;
                menuCaptionTarifario.ShowMenu -= menu_ShowMenu;

            menuCaptionMantenimientos.IsCollapsed = false;
            menuCaptionComercial.IsCollapsed = false;
            menuCaptionOperaciones.IsCollapsed = false;
            menuCaptionLogistico.IsCollapsed = false;
            menuCaptionFinanzas.IsCollapsed = false;
            menuCaptionReportes.IsCollapsed = false;
                menuCaptionServicioLogistico.IsCollapsed = false;
                menuCaptionTarifario.IsCollapsed = false;

            menuCaptionMantenimientos.ShowMenu += menu_ShowMenu;
            menuCaptionComercial.ShowMenu += menu_ShowMenu;
            menuCaptionOperaciones.ShowMenu += menu_ShowMenu;
            menuCaptionLogistico.ShowMenu += menu_ShowMenu;
            menuCaptionFinanzas.ShowMenu += menu_ShowMenu;
            menuCaptionReportes.ShowMenu += menu_ShowMenu;
                menuCaptionServicioLogistico.ShowMenu += menu_ShowMenu;
                menuCaptionTarifario.ShowMenu += menu_ShowMenu;

            menuCaptionMantenimientos.Text = "Mantenimientos";
            foreach (ToolStripItem item in toolMantenimientos.Items)
            {
               if (item.GetType() == typeof(ToolStripButton))
               {
                  ((ToolStripButton)item).DisplayStyle = ToolStripItemDisplayStyle.ImageAndText;
               }
            }
            menuCaptionComercial.Text = "Comercial";
            foreach (ToolStripItem item in toolComercial.Items)
            {
               if (item.GetType() == typeof(ToolStripButton))
               {
                  ((ToolStripButton)item).DisplayStyle = ToolStripItemDisplayStyle.ImageAndText;
               }
            }
            menuCaptionOperaciones.Text = "Operaciones";
            foreach (ToolStripItem item in toolOperaciones.Items)
            {
               if (item.GetType() == typeof(ToolStripButton))
               {
                  ((ToolStripButton)item).DisplayStyle = ToolStripItemDisplayStyle.ImageAndText;
               }
            }
            menuCaptionLogistico.Text = "Logístico";
            foreach (ToolStripItem item in toolLogistico.Items)
            {
               if (item.GetType() == typeof(ToolStripButton))
               {
                  ((ToolStripButton)item).DisplayStyle = ToolStripItemDisplayStyle.ImageAndText;
               }
            }
            menuCaptionFinanzas.Text = "Finanzas";
            foreach (ToolStripItem item in toolFinanzas.Items)
            {
               if (item.GetType() == typeof(ToolStripButton))
               {
                  ((ToolStripButton)item).DisplayStyle = ToolStripItemDisplayStyle.ImageAndText;
               }
            }
            menuCaptionReportes.Text = "Reportes";
            foreach (ToolStripItem item in toolReportes.Items)
            {
               if (item.GetType() == typeof(ToolStripButton))
               {
                  ((ToolStripButton)item).DisplayStyle = ToolStripItemDisplayStyle.ImageAndText;
               }
            }

                menuCaptionServicioLogistico.Text = "Servicio Logístico";
                foreach (ToolStripItem item in toolServicioLogistico.Items)
                {
                    if (item.GetType() == typeof(ToolStripButton))
                    {
                        ((ToolStripButton)item).DisplayStyle = ToolStripItemDisplayStyle.ImageAndText;
                    }
                }

                menuCaptionTarifario.Text = "Tarifario";
                foreach (ToolStripItem item in toolTarifario.Items)
                {
                    if (item.GetType() == typeof(ToolStripButton))
                    {
                        ((ToolStripButton)item).DisplayStyle = ToolStripItemDisplayStyle.ImageAndText;
                    }
                }

            }
            catch (Exception)
         {
         }
      }
      #endregion

      #region [ Mantenimientos ]
      PAR000MView PAR000_mview;
      PAR000Presenter PAR000_presenter;
      RadPageViewPage _pageView;

      private void PAR000Parametros_Click(object sender, EventArgs e)
      {
         try
         {
            PAR000_mview = new PAR000MView();
            PAR000_presenter = new PAR000Presenter(ContainerService, PAR000_mview);
            PAR000_mview.Presenter = PAR000_presenter;

            PAR000_presenter.Load();
            PAR000_presenter.Editar();
         }
         catch (Exception)
         {
         }
      }

      MAN000LView MAN000_lview;
      MAN000MView MAN000_mview;
      MAN000Presenter MAN000_presenter;
      private void MAN000Empresas_Click(object sender, EventArgs e)
      {
         try
         {
            if (MAN000_lview == null)
            {
               RadPageViewPage _pageView = new RadPageViewPage();
               MAN000_lview = new MAN000LView(_pageView);
               MAN000_mview = new MAN000MView();
               MAN000_presenter = new MAN000Presenter(ContainerService, MAN000_lview, MAN000_mview);
               MAN000_lview.Presenter = MAN000_presenter;
               MAN000_lview.IconView = MAN000Empresas.Image;
               MAN000_mview.Presenter = MAN000_presenter;
               _pageView.BackColor = Color.LightSteelBlue;
               _pageView.Controls.Add(MAN000_lview);
               _pageView.Text = MAN000Empresas.Text;
               _pageView.Image = MAN000Empresas.Image;
               _pageView.Tag = MAN000_presenter.CUS;
               MAN000_lview.Dock = DockStyle.Fill;
               tabViews.Pages.Add(_pageView);
               MAN000_lview.CloseForm += View_CloseForm;

               MAN000_presenter.Load();
            }
            tabViews.SelectedPage = MAN000_lview.TabPageControl;
         }
         catch (Exception)
         {
         }
      }

      MAN001LView MAN001_lview;
      MAN001MView MAN001_mview;
      MAN001Presenter MAN001_presenter;
      private void MAN001Sucursales_Click(object sender, EventArgs e)
      {
         try
         {
            if (MAN001_lview == null)
            {
               RadPageViewPage _pageView = new RadPageViewPage();
               MAN001_lview = new MAN001LView(_pageView);
               MAN001_mview = new MAN001MView();
               MAN001_presenter = new MAN001Presenter(ContainerService, MAN001_lview, MAN001_mview);
               MAN001_lview.Presenter = MAN001_presenter;
               MAN001_lview.IconView = MAN001Sucursales.Image;
               MAN001_mview.Presenter = MAN001_presenter;
               _pageView.BackColor = Color.LightSteelBlue;
               _pageView.Controls.Add(MAN001_lview);
               _pageView.Text = MAN001Sucursales.Text;
               _pageView.Image = MAN001Sucursales.Image;
               _pageView.Tag = MAN001_presenter.CUS;
               MAN001_lview.Dock = DockStyle.Fill;
               tabViews.Pages.Add(_pageView);
               MAN001_lview.CloseForm += View_CloseForm;

               MAN001_presenter.Load();
            }
            tabViews.SelectedPage = MAN001_lview.TabPageControl;
         }
         catch (Exception)
         {
         }
      }

      MAN002LView MAN002_lview;
      MAN002MView MAN002_mview;
      MAN002Presenter MAN002_presenter;
      private void MAN002Tipos_Click(object sender, EventArgs e)
      {
         try
         {
            if (MAN002_lview == null)
            {
               RadPageViewPage _pageView = new RadPageViewPage();
               MAN002_lview = new MAN002LView(_pageView);
               MAN002_mview = new MAN002MView();
               MAN002_presenter = new MAN002Presenter(ContainerService, MAN002_lview, MAN002_mview);
               MAN002_lview.Presenter = MAN002_presenter;
               MAN002_lview.IconView = MAN002Tipos.Image;
               MAN002_mview.Presenter = MAN002_presenter;
               _pageView.BackColor = Color.LightSteelBlue;
               _pageView.Controls.Add(MAN002_lview);
               _pageView.Text = MAN002Tipos.Text;
               _pageView.Image = MAN002Tipos.Image;
               _pageView.Tag = MAN002_presenter.CUS;
               MAN002_lview.Dock = DockStyle.Fill;
               tabViews.Pages.Add(_pageView);
               MAN002_lview.CloseForm += View_CloseForm;

               MAN002_presenter.Load();
            }
            tabViews.SelectedPage = MAN002_lview.TabPageControl;
         }
         catch (Exception)
         {
         }
      }

      MAN003LView MAN003_lview;
      MAN003MView MAN003_mview;
      MAN003Presenter MAN003_presenter;
      private void MAN003ResultadosGestion_Click(object sender, EventArgs e)
      {
         try
         {
            if (MAN003_lview == null)
            {
               RadPageViewPage _pageView = new RadPageViewPage();
               MAN003_lview = new MAN003LView(_pageView);
               MAN003_mview = new MAN003MView();
               MAN003_presenter = new MAN003Presenter(ContainerService, MAN003_lview, MAN003_mview);
               MAN003_lview.Presenter = MAN003_presenter;
               MAN003_lview.IconView = MAN003ResultadosGestion.Image;
               MAN003_mview.Presenter = MAN003_presenter;
               _pageView.BackColor = Color.LightSteelBlue;
               _pageView.Controls.Add(MAN003_lview);
               _pageView.Text = MAN003ResultadosGestion.Text;
               _pageView.Image = MAN003ResultadosGestion.Image;
               _pageView.Tag = MAN003_presenter.CUS;
               MAN003_lview.Dock = DockStyle.Fill;
               tabViews.Pages.Add(_pageView);
               MAN003_lview.CloseForm += View_CloseForm;

               MAN003_presenter.Load();
            }
            tabViews.SelectedPage = MAN003_lview.TabPageControl;
         }
         catch (Exception)
         {
         }
      }

      MAN004LView MAN004_lview;
      MAN004MView MAN004_mview;
      MAN004Presenter MAN004_presenter;
      private void MAN004Servicios_Click(object sender, EventArgs e)
      {
         try
         {
            if (MAN004_lview == null)
            {
               RadPageViewPage _pageView = new RadPageViewPage();
               MAN004_lview = new MAN004LView(_pageView);
               MAN004_mview = new MAN004MView();
               MAN004_presenter = new MAN004Presenter(ContainerService, MAN004_lview, MAN004_mview);
               MAN004_lview.Presenter = MAN004_presenter;
               MAN004_lview.IconView = MAN004Servicios.Image;
               MAN004_mview.Presenter = MAN004_presenter;
               _pageView.BackColor = Color.LightSteelBlue;
               _pageView.Controls.Add(MAN004_lview);
               _pageView.Text = MAN004Servicios.Text;
               _pageView.Image = MAN004Servicios.Image;
               _pageView.Tag = MAN004_presenter.CUS;
               MAN004_lview.Dock = DockStyle.Fill;
               tabViews.Pages.Add(_pageView);
               MAN004_lview.CloseForm += View_CloseForm;

               MAN004_presenter.Load();
            }
            tabViews.SelectedPage = MAN004_lview.TabPageControl;
         }
         catch (Exception)
         {
         }
      }

      //MAN005LView MAN005_lview;
      //MAN005MView MAN005_mview;
      //MAN005Presenter MAN005_presenter;
      //private void MAN005Contratos_Click(object sender, EventArgs e)
      //{
      //   try
      //   {
      //      if (MAN005_lview == null)
      //      {
      //         RadPageViewPage _pageView = new RadPageViewPage();
      //         MAN005_lview = new MAN005LView(_pageView);
      //         MAN005_mview = new MAN005MView();
      //         MAN005_presenter = new MAN005Presenter(this.Container, MAN005_lview, MAN005_mview);
      //         MAN005_lview.Presenter = MAN005_presenter;
      //         MAN005_lview.IconView = MAN005Contratos.Image;
      //         MAN005_mview.Presenter = MAN005_presenter;
      //         _pageView.BackColor = System.Drawing.Color.LightSteelBlue;
      //         _pageView.Controls.Add(MAN005_lview);
      //         _pageView.Text = MAN005Contratos.Text;
      //         _pageView.Image = MAN005Contratos.Image;
      //         MAN005_lview.Dock = DockStyle.Fill;
      //         tabViews.Pages.Add(_pageView);
      //         MAN005_lview.CloseForm += new Infrastructure.Client.FormClose.FormCloseEventArgs.FormCloseEventHandler(View_CloseForm);

      //         MAN005_presenter.Load();
      //      }
      //      tabViews.SelectedPage = MAN005_lview.TabPageControl;
      //   }
      //   catch (Exception)
      //   { }
      //}

      MAN006LView MAN006_lview;
      MAN006MView MAN006_mview;
      MAN006Presenter MAN006_presenter;
      private void MAN006Ubigeos_Click(object sender, EventArgs e)
      {
         try
         {
            if (MAN006_lview == null)
            {
               RadPageViewPage _pageView = new RadPageViewPage();
               MAN006_lview = new MAN006LView(_pageView);
               MAN006_mview = new MAN006MView();
               MAN006_presenter = new MAN006Presenter(ContainerService, MAN006_lview, MAN006_mview);
               MAN006_lview.Presenter = MAN006_presenter;
               MAN006_lview.IconView = MAN006Ubigeos.Image;
               MAN006_mview.Presenter = MAN006_presenter;
               _pageView.BackColor = Color.LightSteelBlue;
               _pageView.Controls.Add(MAN006_lview);
               _pageView.Text = MAN006Ubigeos.Text;
               _pageView.Image = MAN006Ubigeos.Image;
               _pageView.Tag = MAN006_presenter.CUS;
               MAN006_lview.Dock = DockStyle.Fill;
               tabViews.Pages.Add(_pageView);
               MAN006_lview.CloseForm += View_CloseForm;

               MAN006_presenter.Load();
            }
            tabViews.SelectedPage = MAN006_lview.TabPageControl;
         }
         catch (Exception)
         {
         }
      }

      MAN007LView MAN007_lview;
      MAN007MView MAN007_mview;
      MAN007Presenter MAN007_presenter;
      private void MAN007Puertos_Click(object sender, EventArgs e)
      {
         try
         {
            if (MAN007_lview == null)
            {
               RadPageViewPage _pageView = new RadPageViewPage();
               MAN007_lview = new MAN007LView(_pageView);
               MAN007_mview = new MAN007MView();
               MAN007_presenter = new MAN007Presenter(ContainerService, MAN007_lview, MAN007_mview);
               MAN007_lview.Presenter = MAN007_presenter;
               MAN007_lview.IconView = MAN007Puertos.Image;
               MAN007_mview.Presenter = MAN007_presenter;
               _pageView.BackColor = Color.LightSteelBlue;
               _pageView.Controls.Add(MAN007_lview);
               _pageView.Text = MAN007Puertos.Text;
               _pageView.Image = MAN007Puertos.Image;
               _pageView.Tag = MAN007_presenter.CUS;
               MAN007_lview.Dock = DockStyle.Fill;
               tabViews.Pages.Add(_pageView);
               MAN007_lview.CloseForm += View_CloseForm;

               MAN007_presenter.Load();
            }
            tabViews.SelectedPage = MAN007_lview.TabPageControl;
         }
         catch (Exception)
         {
         }
      }

      MAN008LView MAN008_lview;
      MAN008MView MAN008_mview;
      MAN008Presenter MAN008_presenter;
      private void MAN008Paquetes_Click(object sender, EventArgs e)
      {
         try
         {
            if (MAN008_lview == null)
            {
               RadPageViewPage _pageView = new RadPageViewPage();
               MAN008_lview = new MAN008LView(_pageView);
               MAN008_mview = new MAN008MView();
               MAN008_presenter = new MAN008Presenter(ContainerService, MAN008_lview, MAN008_mview);
               MAN008_lview.Presenter = MAN008_presenter;
               MAN008_lview.IconView = MAN008Paquetes.Image;
               MAN008_mview.Presenter = MAN008_presenter;
               _pageView.BackColor = Color.LightSteelBlue;
               _pageView.Controls.Add(MAN008_lview);
               _pageView.Text = MAN008Paquetes.Text;
               _pageView.Image = MAN008Paquetes.Image;
               _pageView.Tag = MAN008_presenter.CUS;
               MAN008_lview.Dock = DockStyle.Fill;
               tabViews.Pages.Add(_pageView);
               MAN008_lview.CloseForm += View_CloseForm;

               MAN008_presenter.Load();
            }
            tabViews.SelectedPage = MAN008_lview.TabPageControl;
         }
         catch (Exception)
         {
         }
      }

      //MAN009LView MAN009_lview;
      //MAN009MView MAN009_mview;
      //MAN009Presenter MAN009_presenter;
      //private void MAN009Entidad_Click(object sender, EventArgs e)
      //{
      //    try
      //    {
      //        if (MAN009_lview == null)
      //        {
      //            RadPageViewPage _pageView = new RadPageViewPage();
      //            MAN009_lview = new MAN009LView(_pageView);
      //            MAN009_mview = new MAN009MView();
      //            MAN009_presenter = new MAN009Presenter(this.Container, MAN009_lview, MAN009_mview);

      //            MAN009_lview.Presenter = MAN009_presenter;
      //            MAN009_lview.IconView = MAN009Entidad.Image;
      //            MAN009_mview.Presenter = MAN009_presenter;
      //            _pageView.BackColor = System.Drawing.Color.LightSteelBlue;
      //            _pageView.Controls.Add(MAN009_lview);
      //            _pageView.Text = MAN009Entidad.Text;
      //            _pageView.Image = MAN009Entidad.Image;
      //            MAN009_lview.Dock = DockStyle.Fill;
      //            tabViews.Pages.Add(_pageView);
      //            MAN009_lview.CloseForm += new Infrastructure.Client.FormClose.FormCloseEventArgs.FormCloseEventHandler(View_CloseForm);

      //            MAN009_presenter.Load();
      //        }
      //        tabViews.SelectedPage = MAN009_lview.TabPageControl;
      //    }
      //    catch (Exception)
      //    { }
      //}

      #region [ Entidad ]

      MAN009LView MAN0091_lview;
      MAN009MView MAN0091_mview;
      MAN009Presenter MAN0091_presenter;
      private void MAN0091_Click(object sender, EventArgs e)
      {
         try
         {
            if (MAN0091_lview == null)
            {
               RadPageViewPage _pageView = new RadPageViewPage();
               MAN0091_lview = new MAN009LView(_pageView);
               MAN0091_mview = new MAN009MView();
               MAN0091_presenter = new MAN009Presenter(ContainerService, MAN0091_lview, MAN0091_mview, 1);
               MAN0091_presenter.CUS = "MAN0091";
               MAN0091_lview.Presenter = MAN0091_presenter;
               MAN0091_lview.IconView = MAN0091.Image;
               MAN0091_mview.Presenter = MAN0091_presenter;
               _pageView.BackColor = Color.LightSteelBlue;
               _pageView.Controls.Add(MAN0091_lview);
               _pageView.Text = MAN0091.Text;
               _pageView.Image = MAN0091.Image;
               _pageView.Tag = MAN0091_presenter.CUS;
               MAN0091_lview.Dock = DockStyle.Fill;
               tabViews.Pages.Add(_pageView);
               MAN0091_lview.CloseForm += View_CloseForm;

               MAN0091_presenter.Load();
            }
            tabViews.SelectedPage = MAN0091_lview.TabPageControl;
         }
         catch (Exception)
         {
         }
      }

      MAN009LView MAN0092_lview;
      MAN009MView MAN0092_mview;
      MAN009Presenter MAN0092_presenter;
      private void MAN0092_Click(object sender, EventArgs e)
      {
         try
         {
            if (MAN0092_lview == null)
            {
               RadPageViewPage _pageView = new RadPageViewPage();
               MAN0092_lview = new MAN009LView(_pageView);
               MAN0092_mview = new MAN009MView();
               MAN0092_presenter = new MAN009Presenter(ContainerService, MAN0092_lview, MAN0092_mview, 2);
               MAN0092_presenter.CUS = "MAN0092";
               MAN0092_lview.Presenter = MAN0092_presenter;
               MAN0092_lview.IconView = MAN0092.Image;
               MAN0092_mview.Presenter = MAN0092_presenter;
               _pageView.BackColor = Color.LightSteelBlue;
               _pageView.Controls.Add(MAN0092_lview);
               _pageView.Text = MAN0092.Text;
               _pageView.Tag = MAN0092_presenter.CUS;
               _pageView.Image = MAN0092.Image;
               MAN0092_lview.Dock = DockStyle.Fill;
               tabViews.Pages.Add(_pageView);
               MAN0092_lview.CloseForm += View_CloseForm;

               MAN0092_presenter.Load();
            }
            tabViews.SelectedPage = MAN0092_lview.TabPageControl;
         }
         catch (Exception)
         {
         }
      }

      MAN009LView MAN0093_lview;
      MAN009MView MAN0093_mview;
      MAN009Presenter MAN0093_presenter;
      private void MAN0093_Click(object sender, EventArgs e)
      {
         try
         {
            if (MAN0093_lview == null)
            {
               RadPageViewPage _pageView = new RadPageViewPage();
               MAN0093_lview = new MAN009LView(_pageView);
               MAN0093_mview = new MAN009MView();
               MAN0093_presenter = new MAN009Presenter(ContainerService, MAN0093_lview, MAN0093_mview, 3);
               MAN0093_presenter.CUS = "MAN0093";
               MAN0093_lview.Presenter = MAN0093_presenter;
               MAN0093_lview.IconView = MAN0093.Image;
               MAN0093_mview.Presenter = MAN0093_presenter;
               _pageView.BackColor = Color.LightSteelBlue;
               _pageView.Controls.Add(MAN0093_lview);
               _pageView.Text = MAN0093.Text;
               _pageView.Image = MAN0093.Image;
               _pageView.Tag = MAN0093_presenter.CUS;
               MAN0093_lview.Dock = DockStyle.Fill;
               tabViews.Pages.Add(_pageView);
               MAN0093_lview.CloseForm += View_CloseForm;

               MAN0093_presenter.Load();
            }
            tabViews.SelectedPage = MAN0093_lview.TabPageControl;
         }
         catch (Exception)
         {
         }
      }

      MAN009LView MAN0094_lview;
      MAN009MView MAN0094_mview;
      MAN009Presenter MAN0094_presenter;
      private void MAN0094_Click(object sender, EventArgs e)
      {
         try
         {
            if (MAN0094_lview == null)
            {
               RadPageViewPage _pageView = new RadPageViewPage();
               MAN0094_lview = new MAN009LView(_pageView);
               MAN0094_mview = new MAN009MView();
               MAN0094_presenter = new MAN009Presenter(ContainerService, MAN0094_lview, MAN0094_mview, 4);
               MAN0094_presenter.CUS = "MAN0094";
               MAN0094_lview.Presenter = MAN0094_presenter;
               MAN0094_lview.IconView = MAN0094.Image;
               MAN0094_mview.Presenter = MAN0094_presenter;
               _pageView.BackColor = Color.LightSteelBlue;
               _pageView.Controls.Add(MAN0094_lview);
               _pageView.Text = MAN0094.Text;
               _pageView.Image = MAN0094.Image;
               _pageView.Tag = MAN0094_presenter.CUS;
               MAN0094_lview.Dock = DockStyle.Fill;
               tabViews.Pages.Add(_pageView);
               MAN0094_lview.CloseForm += View_CloseForm;

               MAN0094_presenter.Load();
            }
            tabViews.SelectedPage = MAN0094_lview.TabPageControl;
         }
         catch (Exception)
         {
         }
      }

      MAN009LView MAN0095_lview;
      MAN009MView MAN0095_mview;
      MAN009Presenter MAN0095_presenter;
      private void MAN0095_Click(object sender, EventArgs e)
      {
         try
         {
            if (MAN0095_lview == null)
            {
               RadPageViewPage _pageView = new RadPageViewPage();
               MAN0095_lview = new MAN009LView(_pageView);
               MAN0095_mview = new MAN009MView();
               MAN0095_presenter = new MAN009Presenter(ContainerService, MAN0095_lview, MAN0095_mview, 5);
               MAN0095_presenter.CUS = "MAN0095";
               MAN0095_lview.Presenter = MAN0095_presenter;
               MAN0095_lview.IconView = MAN0095.Image;
               MAN0095_mview.Presenter = MAN0095_presenter;
               _pageView.BackColor = Color.LightSteelBlue;
               _pageView.Controls.Add(MAN0095_lview);
               _pageView.Text = MAN0095.Text;
               _pageView.Image = MAN0095.Image;
               _pageView.Tag = MAN0095_presenter.CUS;
               MAN0095_lview.Dock = DockStyle.Fill;
               tabViews.Pages.Add(_pageView);
               MAN0095_lview.CloseForm += View_CloseForm;

               MAN0095_presenter.Load();
            }
            tabViews.SelectedPage = MAN0095_lview.TabPageControl;
         }
         catch (Exception)
         {
         }
      }

      MAN009LView MAN0096_lview;
      MAN009MView MAN0096_mview;
      MAN009Presenter MAN0096_presenter;
      private void MAN0096_Click(object sender, EventArgs e)
      {
         try
         {
            if (MAN0096_lview == null)
            {
               RadPageViewPage _pageView = new RadPageViewPage();
               MAN0096_lview = new MAN009LView(_pageView);
               MAN0096_mview = new MAN009MView();
               MAN0096_presenter = new MAN009Presenter(ContainerService, MAN0096_lview, MAN0096_mview, 6);
               MAN0096_presenter.CUS = "MAN0096";
               MAN0096_lview.Presenter = MAN0096_presenter;
               MAN0096_lview.IconView = MAN0096.Image;
               MAN0096_mview.Presenter = MAN0096_presenter;
               _pageView.BackColor = Color.LightSteelBlue;
               _pageView.Controls.Add(MAN0096_lview);
               _pageView.Text = MAN0096.Text;
               _pageView.Image = MAN0096.Image;
               _pageView.Tag = MAN0096_presenter.CUS;
               MAN0096_lview.Dock = DockStyle.Fill;
               tabViews.Pages.Add(_pageView);
               MAN0096_lview.CloseForm += View_CloseForm;

               MAN0096_presenter.Load();
            }
            tabViews.SelectedPage = MAN0096_lview.TabPageControl;
         }
         catch (Exception)
         {
         }
      }

      MAN009LView MAN0097_lview;
      MAN009MView MAN0097_mview;
      MAN009Presenter MAN0097_presenter;
      private void MAN0097_Click(object sender, EventArgs e)
      {
         try
         {
            if (MAN0097_lview == null)
            {
               RadPageViewPage _pageView = new RadPageViewPage();
               MAN0097_lview = new MAN009LView(_pageView);
               MAN0097_mview = new MAN009MView();
               MAN0097_presenter = new MAN009Presenter(ContainerService, MAN0097_lview, MAN0097_mview, 7);
               MAN0097_presenter.CUS = "MAN0097";
               MAN0097_lview.Presenter = MAN0097_presenter;
               MAN0097_lview.IconView = MAN0097.Image;
               MAN0097_mview.Presenter = MAN0097_presenter;
               _pageView.BackColor = Color.LightSteelBlue;
               _pageView.Controls.Add(MAN0097_lview);
               _pageView.Text = MAN0097.Text;
               _pageView.Image = MAN0097.Image;
               _pageView.Tag = MAN0097_presenter.CUS;
               MAN0097_lview.Dock = DockStyle.Fill;
               tabViews.Pages.Add(_pageView);
               MAN0097_lview.CloseForm += View_CloseForm;

               MAN0097_presenter.Load();
            }
            tabViews.SelectedPage = MAN0097_lview.TabPageControl;
         }
         catch (Exception)
         {
         }
      }

      MAN009LView MAN0098_lview;
      MAN009MView MAN0098_mview;
      MAN009Presenter MAN0098_presenter;
      private void MAN0098_Click(object sender, EventArgs e)
      {
         try
         {
            if (MAN0098_lview == null)
            {
               RadPageViewPage _pageView = new RadPageViewPage();
               MAN0098_lview = new MAN009LView(_pageView);
               MAN0098_mview = new MAN009MView();
               MAN0098_presenter = new MAN009Presenter(ContainerService, MAN0098_lview, MAN0098_mview, 8);
               MAN0098_presenter.CUS = "MAN0098";
               MAN0098_lview.Presenter = MAN0098_presenter;
               MAN0098_lview.IconView = MAN0098.Image;
               MAN0098_mview.Presenter = MAN0098_presenter;
               _pageView.BackColor = Color.LightSteelBlue;
               _pageView.Controls.Add(MAN0098_lview);
               _pageView.Text = MAN0098.Text;
               _pageView.Image = MAN0098.Image;
               _pageView.Tag = MAN0098_presenter.CUS;
               MAN0098_lview.Dock = DockStyle.Fill;
               tabViews.Pages.Add(_pageView);
               MAN0098_lview.CloseForm += View_CloseForm;

               MAN0098_presenter.Load();
            }
            tabViews.SelectedPage = MAN0098_lview.TabPageControl;
         }
         catch (Exception)
         {
         }
      }

      MAN009LView MAN0099_lview;
      MAN009MView MAN0099_mview;
      MAN009Presenter MAN0099_presenter;
      private void MAN0099_Click(object sender, EventArgs e)
      {
         try
         {
            if (MAN0099_lview == null)
            {
               RadPageViewPage _pageView = new RadPageViewPage();
               MAN0099_lview = new MAN009LView(_pageView);
               MAN0099_mview = new MAN009MView();
               MAN0099_presenter = new MAN009Presenter(ContainerService, MAN0099_lview, MAN0099_mview, 9);
               MAN0099_presenter.CUS = "MAN0099";
               MAN0099_lview.Presenter = MAN0099_presenter;
               MAN0099_lview.IconView = MAN009Entidad.Image;
               MAN0099_mview.Presenter = MAN0099_presenter;
               _pageView.BackColor = System.Drawing.Color.LightSteelBlue;
               _pageView.Controls.Add(MAN0099_lview);
               _pageView.Text = MAN0099.Text;
               _pageView.Image = MAN009Entidad.Image;
               _pageView.Tag = MAN0099_presenter.CUS;
               MAN0099_lview.Dock = DockStyle.Fill;
               tabViews.Pages.Add(_pageView);
               MAN0099_lview.CloseForm += new Infrastructure.Client.FormClose.FormCloseEventArgs.FormCloseEventHandler(View_CloseForm);

               MAN0099_presenter.Load();
            }
            tabViews.SelectedPage = MAN0099_lview.TabPageControl;
         }
         catch (Exception)
         { }
      }

      MAN009LView MAN00910_lview;
      MAN009MView MAN00910_mview;
      MAN009Presenter MAN00910_presenter;
      private void MAN00910_Click(object sender, EventArgs e)
      {
         try
         {
            if (MAN00910_lview == null)
            {
               RadPageViewPage _pageView = new RadPageViewPage();
               MAN00910_lview = new MAN009LView(_pageView);
               MAN00910_mview = new MAN009MView();
               MAN00910_presenter = new MAN009Presenter(ContainerService, MAN00910_lview, MAN00910_mview, 10);
               MAN00910_presenter.CUS = "MAN00910";
               MAN00910_lview.Presenter = MAN00910_presenter;
               MAN00910_lview.IconView = MAN00910.Image;
               MAN00910_mview.Presenter = MAN00910_presenter;
               _pageView.BackColor = Color.LightSteelBlue;
               _pageView.Controls.Add(MAN00910_lview);
               _pageView.Text = MAN00910.Text;
               _pageView.Image = MAN00910.Image;
               _pageView.Tag = MAN00910_presenter.CUS;
               MAN00910_lview.Dock = DockStyle.Fill;
               tabViews.Pages.Add(_pageView);
               MAN00910_lview.CloseForm += View_CloseForm;

               MAN00910_presenter.Load();
            }
            tabViews.SelectedPage = MAN00910_lview.TabPageControl;
         }
         catch (Exception)
         {
         }
      }

      MAN009LView MAN00911_lview;
      MAN009MView MAN00911_mview;
      MAN009Presenter MAN00911_presenter;
      private void MAN00911_Click(object sender, EventArgs e)
      {
         try
         {
            if (MAN00911_lview == null)
            {
               RadPageViewPage _pageView = new RadPageViewPage();
               MAN00911_lview = new MAN009LView(_pageView);
               MAN00911_mview = new MAN009MView();
               MAN00911_presenter = new MAN009Presenter(ContainerService, MAN00911_lview, MAN00911_mview, 11);
               MAN00911_presenter.CUS = "MAN00911";
               MAN00911_lview.Presenter = MAN00911_presenter;
               MAN00911_lview.IconView = MAN00911.Image;
               MAN00911_mview.Presenter = MAN00911_presenter;
               _pageView.BackColor = Color.LightSteelBlue;
               _pageView.Controls.Add(MAN00911_lview);
               _pageView.Text = MAN00911.Text;
               _pageView.Image = MAN00911.Image;
               _pageView.Tag = MAN00911_presenter.CUS;
               MAN00911_lview.Dock = DockStyle.Fill;
               tabViews.Pages.Add(_pageView);
               MAN00911_lview.CloseForm += View_CloseForm;

               MAN00911_presenter.Load();
            }
            tabViews.SelectedPage = MAN00911_lview.TabPageControl;
         }
         catch (Exception)
         {
         }
      }

      MAN009LView MAN00912_lview;
      MAN009MView MAN00912_mview;
      MAN009Presenter MAN00912_presenter;
      private void MAN00912_Click(object sender, EventArgs e)
      {
         try
         {
            if (MAN00912_lview == null)
            {
               RadPageViewPage _pageView = new RadPageViewPage();
               MAN00912_lview = new MAN009LView(_pageView);
               MAN00912_mview = new MAN009MView();
               MAN00912_presenter = new MAN009Presenter(ContainerService, MAN00912_lview, MAN00912_mview, 12);
               MAN00912_presenter.CUS = "MAN00912";
               MAN00912_lview.Presenter = MAN00912_presenter;
               MAN00912_lview.IconView = MAN00912.Image;
               MAN00912_mview.Presenter = MAN00912_presenter;
               _pageView.BackColor = Color.LightSteelBlue;
               _pageView.Controls.Add(MAN00912_lview);
               _pageView.Text = MAN00912.Text;
               _pageView.Image = MAN00912.Image;
               _pageView.Tag = MAN00912_presenter.CUS;
               MAN00912_lview.Dock = DockStyle.Fill;
               tabViews.Pages.Add(_pageView);
               MAN00912_lview.CloseForm += View_CloseForm;
               MAN00912_presenter.Load();
            }
            tabViews.SelectedPage = MAN00912_lview.TabPageControl;
         }
         catch (Exception)
         {
         }
      }

      MAN009LView MAN00913_lview;
      MAN009MView MAN00913_mview;
      MAN009Presenter MAN00913_presenter;
      private void MAN00913_Click(object sender, EventArgs e)
      {
         try
         {
            if (MAN00913_lview == null)
            {
               RadPageViewPage _pageView = new RadPageViewPage();
               MAN00913_lview = new MAN009LView(_pageView);
               MAN00913_mview = new MAN009MView();
               MAN00913_presenter = new MAN009Presenter(ContainerService, MAN00913_lview, MAN00913_mview, 13);
               MAN00913_presenter.CUS = "MAN00913";
               MAN00913_lview.Presenter = MAN00913_presenter;
               MAN00913_lview.IconView = MAN00913.Image;
               MAN00913_mview.Presenter = MAN00913_presenter;
               _pageView.BackColor = Color.LightSteelBlue;
               _pageView.Controls.Add(MAN00913_lview);
               _pageView.Text = MAN00913.Text;
               _pageView.Image = MAN00913.Image;
               _pageView.Tag = MAN00913_presenter.CUS;
               MAN00913_lview.Dock = DockStyle.Fill;
               tabViews.Pages.Add(_pageView);
               MAN00913_lview.CloseForm += View_CloseForm;
               MAN00913_presenter.Load();
            }
            tabViews.SelectedPage = MAN00913_lview.TabPageControl;
         }
         catch (Exception)
         {
         }
      }

      MAN009LView MAN00914_lview;
      MAN009MView MAN00914_mview;
      MAN009Presenter MAN00914_presenter;
      private void MAN00914_Click(object sender, EventArgs e)
      {
         try
         {
            if (MAN00914_lview == null)
            {
               RadPageViewPage _pageView = new RadPageViewPage();
               MAN00914_lview = new MAN009LView(_pageView);
               MAN00914_mview = new MAN009MView();
               MAN00914_presenter = new MAN009Presenter(ContainerService, MAN00914_lview, MAN00914_mview, 14);
               MAN00914_presenter.CUS = "MAN00914";
               MAN00914_lview.Presenter = MAN00914_presenter;
               MAN00914_lview.IconView = MAN00914.Image;
               MAN00914_mview.Presenter = MAN00914_presenter;
               _pageView.BackColor = Color.LightSteelBlue;
               _pageView.Controls.Add(MAN00914_lview);
               _pageView.Text = MAN00914.Text;
               _pageView.Image = MAN00914.Image;
               _pageView.Tag = MAN00914_presenter.CUS;
               MAN00914_lview.Dock = DockStyle.Fill;
               tabViews.Pages.Add(_pageView);
               MAN00914_lview.CloseForm += View_CloseForm;
               MAN00914_presenter.Load();
            }
            tabViews.SelectedPage = MAN00914_lview.TabPageControl;
         }
         catch (Exception)
         {
         }
      }

      MAN009LView MAN00915_lview;
      MAN009MView MAN00915_mview;
      MAN009Presenter MAN00915_presenter;
      private void MAN00915_Click(object sender, EventArgs e)
      {
         try
         {
            if (MAN00915_lview == null)
            {
               RadPageViewPage _pageView = new RadPageViewPage();
               MAN00915_lview = new MAN009LView(_pageView);
               MAN00915_mview = new MAN009MView();
               MAN00915_presenter = new MAN009Presenter(ContainerService, MAN00915_lview, MAN00915_mview, 15);
               MAN00915_presenter.CUS = "MAN00915";
               MAN00915_lview.Presenter = MAN00915_presenter;
               MAN00915_lview.IconView = MAN00915.Image;
               MAN00915_mview.Presenter = MAN00915_presenter;
               _pageView.BackColor = Color.LightSteelBlue;
               _pageView.Controls.Add(MAN00915_lview);
               _pageView.Text = MAN00915.Text;
               _pageView.Image = MAN00915.Image;
               _pageView.Tag = MAN00915_presenter.CUS;
               MAN00915_lview.Dock = DockStyle.Fill;
               tabViews.Pages.Add(_pageView);
               MAN00915_lview.CloseForm += View_CloseForm;
               MAN00915_presenter.Load();
            }
            tabViews.SelectedPage = MAN00915_lview.TabPageControl;
         }
         catch (Exception)
         {
         }
      }

      MAN009LView MAN00916_lview;
      MAN009MView MAN00916_mview;
      MAN009Presenter MAN00916_presenter;
      /// <summary>
      /// Mantenimiento de Empleados
      /// </summary>
      /// <param name="sender">The source of the event.</param>
      /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
      private void MAN00916_Click(object sender, EventArgs e)
      {
         try
         {
            if (MAN00916_lview == null)
            {
               RadPageViewPage _pageView = new RadPageViewPage();
               MAN00916_lview = new MAN009LView(_pageView);
               MAN00916_mview = new MAN009MView();
               MAN00916_presenter = new MAN009Presenter(ContainerService, MAN00916_lview, MAN00916_mview, 16);
               MAN00916_presenter.CUS = "MAN00916";
               MAN00916_lview.Presenter = MAN00916_presenter;
               MAN00916_lview.IconView = MAN00916.Image;
               MAN00916_mview.Presenter = MAN00916_presenter;               
               _pageView.BackColor = Color.LightSteelBlue;
               _pageView.Controls.Add(MAN00916_lview);
               _pageView.Text = MAN00916.Text;
               _pageView.Image = MAN00916.Image;
               _pageView.Tag = MAN00916_presenter.CUS;
               MAN00916_lview.Dock = DockStyle.Fill;
               tabViews.Pages.Add(_pageView);
               MAN00916_lview.CloseForm += View_CloseForm;
               MAN00916_presenter.Load();
            }
            tabViews.SelectedPage = MAN00916_lview.TabPageControl;
         }
         catch (Exception)
         {
         }
      }
      #endregion

      MAN010LView MAN010_lview;
      MAN010MView MAN010_mview;
      MAN010Presenter MAN010_presenter;
      private void MAN010Naves_Click(object sender, EventArgs e)
      {
         try
         {
            if (MAN010_lview == null)
            {
               RadPageViewPage _pageView = new RadPageViewPage();
               MAN010_lview = new MAN010LView(_pageView);
               MAN010_mview = new MAN010MView();
               MAN010_presenter = new MAN010Presenter(ContainerService, MAN010_lview, MAN010_mview);
               MAN010_lview.Presenter = MAN010_presenter;
               MAN010_lview.IconView = MAN010Naves.Image;
               MAN010_mview.Presenter = MAN010_presenter;
               _pageView.BackColor = Color.LightSteelBlue;
               _pageView.Controls.Add(MAN010_lview);
               _pageView.Text = MAN010Naves.Text;
               _pageView.Image = MAN010Naves.Image;
               _pageView.Tag = MAN010_presenter.CUS;
               MAN010_lview.Dock = DockStyle.Fill;
               tabViews.Pages.Add(_pageView);
               MAN010_lview.CloseForm += View_CloseForm;

               MAN010_presenter.Load();
            }
            tabViews.SelectedPage = MAN010_lview.TabPageControl;
         }
         catch (Exception)
         {
         }
      }

      MAN011LView MAN011_lview;
      MAN011MView MAN011_mview;
      MAN011Presenter MAN011_presenter;
      private void MAN011NaveViaje_Click(object sender, EventArgs e)
      {
         try
         {
            if (MAN011_lview == null)
            {
               RadPageViewPage _pageView = new RadPageViewPage();
               MAN011_lview = new MAN011LView(_pageView);
               MAN011_mview = new MAN011MView();
               MAN011_presenter = new MAN011Presenter(ContainerService, MAN011_lview, MAN011_mview);
               MAN011_lview.Presenter = MAN011_presenter;
               MAN011_lview.IconView = MAN011NaveViaje.Image;
               MAN011_mview.Presenter = MAN011_presenter;
               _pageView.BackColor = Color.LightSteelBlue;
               _pageView.Controls.Add(MAN011_lview);
               _pageView.Text = MAN011NaveViaje.Text;
               _pageView.Image = MAN011NaveViaje.Image;
               _pageView.Tag = MAN011_presenter.CUS;
               MAN011_lview.Dock = DockStyle.Fill;
               tabViews.Pages.Add(_pageView);
               MAN011_lview.CloseForm += View_CloseForm;

               MAN011_presenter.Load();
            }
            tabViews.SelectedPage = MAN011_lview.TabPageControl;
         }
         catch (Exception)
         {
         }
      }

      MAN012LView MAN012_lview;
      MAN012MView MAN012_mview;
      MAN012Presenter MAN012_presenter;
      private void MAN012Rebates_Click(object sender, EventArgs e)
      {
         try
         {
            if (MAN012_lview == null)
            {
               RadPageViewPage _pageView = new RadPageViewPage();
               MAN012_lview = new MAN012LView(_pageView);
               MAN012_mview = new MAN012MView();
               MAN012_presenter = new MAN012Presenter(ContainerService, MAN012_lview, MAN012_mview);
               MAN012_lview.Presenter = MAN012_presenter;
               MAN012_lview.IconView = MAN012Rebates.Image;
               MAN012_mview.Presenter = MAN012_presenter;
               _pageView.BackColor = Color.LightSteelBlue;
               _pageView.Controls.Add(MAN012_lview);
               _pageView.Text = MAN012Rebates.Text;
               _pageView.Image = MAN012Rebates.Image;
               _pageView.Tag = MAN012_presenter.CUS;
               MAN012_lview.Dock = DockStyle.Fill;
               tabViews.Pages.Add(_pageView);
               MAN012_lview.CloseForm += View_CloseForm;

               MAN012_presenter.Load();
            }
            tabViews.SelectedPage = MAN012_lview.TabPageControl;
         }
         catch (Exception)
         {
         }
      }

      MAN013LView MAN013_lview;
      MAN013MView MAN013_mview;
      MAN013Presenter MAN013_presenter;
      private void MAN013TiposCambio_Click(object sender, EventArgs e)
      {
         try
         {
            if (MAN013_lview == null)
            {
               RadPageViewPage _pageView = new RadPageViewPage();
               MAN013_lview = new MAN013LView(_pageView);
               MAN013_mview = new MAN013MView();
               MAN013_presenter = new MAN013Presenter(ContainerService, MAN013_lview, MAN013_mview);
               MAN013_lview.Presenter = MAN013_presenter;
               MAN013_lview.IconView = MAN013TiposCambio.Image;
               MAN013_mview.Presenter = MAN013_presenter;
               _pageView.BackColor = Color.LightSteelBlue;
               _pageView.Controls.Add(MAN013_lview);
               _pageView.Text = MAN013TiposCambio.Text;
               _pageView.Image = MAN013TiposCambio.Image;
               _pageView.Tag = MAN013_presenter.CUS;
               MAN013_lview.Dock = DockStyle.Fill;
               tabViews.Pages.Add(_pageView);
               MAN013_lview.CloseForm += View_CloseForm;
               MAN013_presenter.Load();
            }
            tabViews.SelectedPage = MAN013_lview.TabPageControl;
         }
         catch (Exception)
         {
         }
      }

      MAN014LView MAN014_lview;
      MAN014MView MAN014_mview;
      MAN014Presenter MAN014_presenter;
      private void MAN014Comisiones_Click(object sender, EventArgs e)
      {
         try
         {
            if (MAN014_lview == null)
            {
               RadPageViewPage _pageView = new RadPageViewPage();
               MAN014_lview = new MAN014LView(_pageView);
               MAN014_mview = new MAN014MView();
               MAN014_presenter = new MAN014Presenter(ContainerService, MAN014_lview, MAN014_mview);
               MAN014_lview.Presenter = MAN014_presenter;
               MAN014_lview.IconView = MAN014Comisiones.Image;
               MAN014_mview.Presenter = MAN014_presenter;
               _pageView.BackColor = Color.LightSteelBlue;
               _pageView.Controls.Add(MAN014_lview);
               _pageView.Text = MAN014Comisiones.Text;
               _pageView.Image = MAN014Comisiones.Image;
               _pageView.Tag = MAN014_presenter.CUS;
               MAN014_lview.Dock = DockStyle.Fill;
               tabViews.Pages.Add(_pageView);
               MAN014_lview.CloseForm += View_CloseForm;
               MAN014_presenter.Load();
            }
            tabViews.SelectedPage = MAN014_lview.TabPageControl;
         }
         catch (Exception)
         { }
      }

      MAN015SeriesLView MAN015_lview;
      MAN015SeriesMView MAN015_mview;
      MAN015SeriesPresenter MAN015_presenter;
      private void MAN015Series_Click(object sender, EventArgs e)
      {
         try
         {
            if (MAN015_lview == null)
            {
               RadPageViewPage _pageView = new RadPageViewPage();
               MAN015_lview = new MAN015SeriesLView(_pageView);
               MAN015_mview = new MAN015SeriesMView();
               MAN015_presenter = new MAN015SeriesPresenter(ContainerService, MAN015_lview, MAN015_mview);
               MAN015_lview.Presenter = MAN015_presenter;
               MAN015_lview.IconView = MAN015Series.Image;
               MAN015_mview.Presenter = MAN015_presenter;
               _pageView.BackColor = Color.LightSteelBlue;
               _pageView.Controls.Add(MAN015_lview);
               _pageView.Text = MAN015Series.Text;
               _pageView.Image = MAN015Series.Image;
               _pageView.Tag = MAN015_presenter.CUS;
               MAN015_lview.Dock = DockStyle.Fill;
               tabViews.Pages.Add(_pageView);
               MAN015_lview.CloseForm += View_CloseForm;
               MAN015_presenter.Load();
            }
            tabViews.SelectedPage = MAN015_lview.TabPageControl;
         }
         catch (Exception)
         { }
      }
      MAN016FlujosLView MAN016_lview;
      MAN016FlujosMView MAN016_mview;
      MAN016FlujosPresenter MAN016_presenter;
      private void MAN016Flujos_Click(object sender, EventArgs e)
      {
         try
         {
            if (MAN016_lview == null)
            {
               RadPageViewPage _pageView = new RadPageViewPage();
               MAN016_lview = new MAN016FlujosLView(_pageView);
               MAN016_mview = new MAN016FlujosMView();
               MAN016_presenter = new MAN016FlujosPresenter(ContainerService, MAN016_lview, MAN016_mview);
               MAN016_lview.Presenter = MAN016_presenter;
               MAN016_lview.IconView = MAN016Flujos.Image;
               MAN016_mview.Presenter = MAN016_presenter;
               _pageView.BackColor = Color.LightSteelBlue;
               _pageView.Controls.Add(MAN016_lview);
               _pageView.Text = MAN016Flujos.Text;
               _pageView.Image = MAN016Flujos.Image;
               _pageView.Tag = MAN016_presenter.CUS;
               MAN016_lview.Dock = DockStyle.Fill;
               tabViews.Pages.Add(_pageView);
               MAN016_lview.CloseForm += View_CloseForm;
               MAN016_presenter.Load();
            }
            tabViews.SelectedPage = MAN016_lview.TabPageControl;
         }
         catch (Exception)
         { }
      }
      #endregion

      #region [ Comercial ]

      COM001LView COM001_lview;
      //COM001MView COM001_mview;
      COM001Presenter COM001_presenter;
      private void COM001ImportacionProspectos_Click(object sender, EventArgs e)
      {
         try
         {
            if (COM001_lview == null)
            {
               RadPageViewPage _pageView = new RadPageViewPage();
               COM001_lview = new COM001LView(_pageView);
               //COM001_mview = new COM001MView();
               COM001_presenter = new COM001Presenter(ContainerService, COM001_lview); // COM001Presenter(this.Container, CUS002_lview, CUS002_mview);
               COM001_lview.Presenter = COM001_presenter;
               COM001_lview.IconView = COM001ImportacionProspectos.Image;
               //COM001_mview.Presenter = COM001_presenter;
               _pageView.Image = COM001ImportacionProspectos.Image;
               _pageView.BackColor = Color.LightSteelBlue;
               _pageView.Controls.Add(COM001_lview);
               _pageView.Text = COM001ImportacionProspectos.Text;
               _pageView.Tag = COM001_presenter.CUS;
               COM001_lview.Dock = DockStyle.Fill;
               tabViews.Pages.Add(_pageView);
               COM001_lview.CloseForm += View_CloseForm;

               COM001_presenter.Load();
            }
            tabViews.SelectedPage = COM001_lview.TabPageControl;
         }
         catch (Exception ex)
         {
            Dialogos.MostrarMensajeError(Text, "Ha Ocurrido un error al llamar la vista: " + COM001ImportacionProspectos.Text, ex);
         }
      }

      COM002LView COM002_lview;
      //COM002MView COM002_mview;
      COM002Presenter COM002_presenter;
      private void COM002AsigancionProspectos_Click(object sender, EventArgs e)
      {
         try
         {
            if (COM002_lview == null)
            {
               RadPageViewPage _pageView = new RadPageViewPage();
               COM002_lview = new COM002LView(_pageView);
               //COM002_mview = new COM002MView();
               COM002_presenter = new COM002Presenter(ContainerService, COM002_lview);
               COM002_lview.Presenter = COM002_presenter;
               COM002_lview.IconView = COM002AsigancionProspectos.Image;
               //COM002_mview.Presenter = COM002_presenter;
               _pageView.Image = COM002AsigancionProspectos.Image;
               _pageView.BackColor = Color.LightSteelBlue;
               _pageView.Controls.Add(COM002_lview);
               _pageView.Text = COM002AsigancionProspectos.Text;
               _pageView.Tag = COM002_presenter.CUS;
               COM002_lview.Dock = DockStyle.Fill;
               tabViews.Pages.Add(_pageView);
               COM002_lview.CloseForm += View_CloseForm;
               COM002_presenter.Load();
            }
            tabViews.SelectedPage = COM002_lview.TabPageControl;
         }
         catch (Exception ex)
         {
            Dialogos.MostrarMensajeError(Text, "Ha Ocurrido un error al llamar la vista: " + COM002AsigancionProspectos.Text, ex);
         }
      }

      COM003LView COM003_lview;
      //COM003MView COM003_mview;
      COM003Presenter COM003_presenter;
      private void COM003GestionVentas_Click(object sender, EventArgs e)
      {
         try
         {
            if (COM003_lview == null)
            {
               RadPageViewPage _pageView = new RadPageViewPage();
               COM003_lview = new COM003LView(_pageView);
               //COM003_mview = new COM003MView();
               COM003_presenter = new COM003Presenter(ContainerService, COM003_lview);
               COM003_lview.Presenter = COM003_presenter;
               COM003_lview.IconView = COM003GestionVentas.Image;
               //COM003_mview.Presenter = COM003_presenter;
               _pageView.Image = COM003GestionVentas.Image;
               _pageView.BackColor = Color.LightSteelBlue;
               _pageView.Controls.Add(COM003_lview);
               _pageView.Text = COM003GestionVentas.Text;
               _pageView.Tag = COM003_presenter.CUS;
               COM003_lview.Dock = DockStyle.Fill;
               tabViews.Pages.Add(_pageView);
               COM003_lview.CloseForm += View_CloseForm;
               COM003_presenter.Load();
            }
            tabViews.SelectedPage = COM003_lview.TabPageControl;
         }
         catch (Exception ex)
         {
            Dialogos.MostrarMensajeError(Text, "Ha Ocurrido un error al llamar la vista: " + COM003GestionVentas.Text, ex);
         }
      }

      COM004LView COM004_lview;
      //COM004MView COM004_mview;
      COM004Presenter COM004_presenter;
      private void COM004KPIContactados_Click(object sender, EventArgs e)
      {
         try
         {
            if (COM004_lview == null)
            {
               RadPageViewPage _pageView = new RadPageViewPage();
               COM004_lview = new COM004LView(_pageView);
               //COM004_mview = new COM004MView();
               COM004_presenter = new COM004Presenter(ContainerService, COM004_lview);
               COM004_lview.Presenter = COM004_presenter;
               COM004_lview.IconView = COM004KPIContactados.Image;
               //COM004_mview.Presenter = COM004_presenter;
               _pageView.Image = COM004KPIContactados.Image;
               _pageView.BackColor = Color.LightSteelBlue;
               _pageView.Controls.Add(COM004_lview);
               _pageView.Text = COM004KPIContactados.Text;
               _pageView.Tag = COM004_presenter.CUS;
               COM004_lview.Dock = DockStyle.Fill;
               tabViews.Pages.Add(_pageView);
               COM004_lview.CloseForm += View_CloseForm;
               COM004_presenter.Load();
            }
            tabViews.SelectedPage = COM004_lview.TabPageControl;
         }
         catch (Exception ex)
         {
            Dialogos.MostrarMensajeError(Text, "Ha Ocurrido un error al llamar la vista: " + COM004KPIContactados.Text, ex);
         }
      }

      COM005LView COM005_lview;
      //COM005MView COM005_mview;
      COM005Presenter COM005_presenter;
      private void COM005KPIReuniones_Click(object sender, EventArgs e)
      {
         try
         {
            if (COM005_lview == null)
            {
               RadPageViewPage _pageView = new RadPageViewPage();
               COM005_lview = new COM005LView(_pageView);
               //COM005_mview = new COM005MView();
               COM005_presenter = new COM005Presenter(ContainerService, COM005_lview);
               COM005_lview.Presenter = COM005_presenter;
               COM005_lview.IconView = COM005KPIReuniones.Image;
               //COM005_mview.Presenter = COM005_presenter;
               _pageView.Image = COM005KPIReuniones.Image;
               _pageView.BackColor = Color.LightSteelBlue;
               _pageView.Controls.Add(COM005_lview);
               _pageView.Text = COM005KPIReuniones.Text;
               _pageView.Tag = COM005_presenter.CUS;
               COM005_lview.Dock = DockStyle.Fill;
               tabViews.Pages.Add(_pageView);
               COM005_lview.CloseForm += View_CloseForm;
               COM005_presenter.Load();
            }
            tabViews.SelectedPage = COM005_lview.TabPageControl;
         }
         catch (Exception ex)
         {
            Dialogos.MostrarMensajeError(Text, "Ha Ocurrido un error al llamar la vista: " + COM005KPIReuniones.Text, ex);
         }
      }

      COM006LView COM006_lview;
      COM006MView COM006_mview;
      COM006DView COM006_dview;
      COM006Presenter COM006_presenter;
      private void COM006ContratoTarifario_Click(object sender, EventArgs e)
      {
         try
         {
            if (COM006_lview == null)
            {
               RadPageViewPage _pageView = new RadPageViewPage();
               COM006_lview = new COM006LView(_pageView);
               COM006_mview = new COM006MView();
               COM006_dview = new COM006DView();
               COM006_presenter = new COM006Presenter(ContainerService, COM006_lview, COM006_mview, COM006_dview);
               COM006_lview.Presenter = COM006_presenter;
               COM006_lview.IconView = COM006ContratoTarifario.Image;
               COM006_mview.Presenter = COM006_presenter;
               COM006_dview.Presenter = COM006_presenter;
               _pageView.Image = COM006ContratoTarifario.Image;
               _pageView.BackColor = Color.LightSteelBlue;
               _pageView.Controls.Add(COM006_lview);
               _pageView.Text = COM006ContratoTarifario.Text;
               _pageView.Tag = COM006_presenter.CUS;
               COM006_lview.Dock = DockStyle.Fill;
               tabViews.Pages.Add(_pageView);
               COM006_lview.CloseForm += View_CloseForm;
               COM006_presenter.Load();
            }
            tabViews.SelectedPage = COM006_lview.TabPageControl;
         }
         catch (Exception ex)
         {
            Dialogos.MostrarMensajeError(Text, "Ha Ocurrido un error al llamar la vista: " + COM006ContratoTarifario.Text, ex);
         }
      }

      COM007LView COM007_lview;
      COM007MView COM007_mview;
      COM007Presenter COM007_presenter;
      private void COM007Cotizacion_Click(object sender, EventArgs e)
      {
         try
         {
            if (COM007_lview == null)
            {
               RadPageViewPage _pageView = new RadPageViewPage();
               COM007_lview = new COM007LView(_pageView);
               COM007_mview = new COM007MView();
               COM007_presenter = new COM007Presenter(ContainerService, COM007_lview, COM007_mview, variables.CCOT_TipoCotizacion);
               COM007_lview.Presenter = COM007_presenter;
               COM007_lview.IconView = COM007Cotizacion.Image;
               COM007_mview.Presenter = COM007_presenter;
               _pageView.Image = COM007Cotizacion.Image;
               _pageView.BackColor = Color.LightSteelBlue;
               _pageView.Controls.Add(COM007_lview);
               _pageView.Text = COM007Cotizacion.Text;
               _pageView.Tag = COM007_presenter.CUS;
               COM007_lview.Dock = DockStyle.Fill;
               tabViews.Pages.Add(_pageView);
               COM007_lview.CloseForm += View_CloseForm;
               COM007_presenter.Load();
            }
            tabViews.SelectedPage = COM007_lview.TabPageControl;
         }
         catch (Exception ex)
         {
            Dialogos.MostrarMensajeError(Text, "Ha Ocurrido un error al llamar la vista: " + COM007Cotizacion.Text, ex);
         }
      }

      COM007LView COM008_lview;
      COM007MView COM008_mview;
      COM007Presenter COM008_presenter;
      private void COM008OrdenVenta_Click(object sender, EventArgs e)
      {
         try
         {
            if (COM008_lview == null)
            {
               RadPageViewPage _pageView = new RadPageViewPage();
               COM008_lview = new COM007LView(_pageView);
               COM008_mview = new COM007MView();
               COM008_presenter = new COM007Presenter(ContainerService, COM008_lview, COM008_mview, variables.CCOT_TipoOrdenVenta);
               COM008_lview.Presenter = COM008_presenter;
               COM008_lview.IconView = COM008OrdenVenta.Image;
               COM008_mview.Presenter = COM008_presenter;
               _pageView.Image = COM008OrdenVenta.Image;
               _pageView.BackColor = Color.LightSteelBlue;
               _pageView.Controls.Add(COM008_lview);
               _pageView.Text = COM008OrdenVenta.Text;
               _pageView.Tag = COM008_presenter.CUS;
               COM008_lview.Dock = DockStyle.Fill;
               tabViews.Pages.Add(_pageView);
               COM008_lview.CloseForm += View_CloseForm;
               COM008_presenter.Load();
            }
            tabViews.SelectedPage = COM008_lview.TabPageControl;
         }
         catch (Exception ex)
         {
            Dialogos.MostrarMensajeError(Text, "Ha Ocurrido un error al llamar la vista: " + COM007Cotizacion.Text, ex);
         }
      }

      COM009LView COM009_lview;
      //COM009MView COM009_mview;
      COM009Presenter COM009_presenter;
      private void COM009KPICotizaciones_Click(object sender, EventArgs e)
      {
         try
         {
            if (COM009_lview == null)
            {
               RadPageViewPage _pageView = new RadPageViewPage();
               COM009_lview = new COM009LView(_pageView);
               //COM009_mview = new COM009MView();
               COM009_presenter = new COM009Presenter(ContainerService, COM009_lview);
               COM009_lview.Presenter = COM009_presenter;
               COM009_lview.IconView = COM009KPICotizaciones.Image;
               //COM009_mview.Presenter = COM009_presenter;
               _pageView.Image = COM009KPICotizaciones.Image;
               _pageView.BackColor = Color.LightSteelBlue;
               _pageView.Controls.Add(COM009_lview);
               _pageView.Text = COM009KPICotizaciones.Text;
               _pageView.Tag = COM009_presenter.CUS;
               COM009_lview.Dock = DockStyle.Fill;
               tabViews.Pages.Add(_pageView);
               COM009_lview.CloseForm += View_CloseForm;
               COM009_presenter.Load();
            }
            tabViews.SelectedPage = COM009_lview.TabPageControl;
         }
         catch (Exception ex)
         {
            Dialogos.MostrarMensajeError(Text, "Ha Ocurrido un error al llamar la vista: " + COM009KPICotizaciones.Text, ex);
         }
      }

      COM010LView COM010_lview;
      //COM010MView COM010_mview;
      COM010Presenter COM010_presenter;
      private void COM010KPIOrdenesVenta_Click(object sender, EventArgs e)
      {
         try
         {
            if (COM010_lview == null)
            {
               RadPageViewPage _pageView = new RadPageViewPage();
               COM010_lview = new COM010LView(_pageView);
               //COM010_mview = new COM010MView();
               COM010_presenter = new COM010Presenter(ContainerService, COM010_lview);
               COM010_lview.Presenter = COM010_presenter;
               COM010_lview.IconView = COM010KPIOrdenesVenta.Image;
               //COM010_mview.Presenter = COM010_presenter;
               _pageView.Image = COM010KPIOrdenesVenta.Image;
               _pageView.BackColor = Color.LightSteelBlue;
               _pageView.Controls.Add(COM010_lview);
               _pageView.Text = COM010KPIOrdenesVenta.Text;
               _pageView.Tag = COM010_presenter.CUS;
               COM010_lview.Dock = DockStyle.Fill;
               tabViews.Pages.Add(_pageView);
               COM010_lview.CloseForm += View_CloseForm;
               COM010_presenter.Load();
            }
            tabViews.SelectedPage = COM010_lview.TabPageControl;
         }
         catch (Exception ex)
         {
            Dialogos.MostrarMensajeError(Text, "Ha Ocurrido un error al llamar la vista: " + COM010KPIOrdenesVenta.Text, ex);
         }
      }

      COM011LView COM011_lview;
      //COM011MView COM011_mview;
      COM011Presenter COM011_presenter;
      private void COM011KPITEUSVendidos_Click(object sender, EventArgs e)
      {
         try
         {
            if (COM011_lview == null)
            {
               RadPageViewPage _pageView = new RadPageViewPage();
               COM011_lview = new COM011LView(_pageView);
               //COM011_mview = new COM011MView();
               COM011_presenter = new COM011Presenter(ContainerService, COM011_lview);
               COM011_lview.Presenter = COM011_presenter;
               COM011_lview.IconView = COM011KPITEUSVendidos.Image;
               //COM011_mview.Presenter = COM011_presenter;
               _pageView.Image = COM011KPITEUSVendidos.Image;
               _pageView.BackColor = Color.LightSteelBlue;
               _pageView.Controls.Add(COM011_lview);
               _pageView.Text = COM011KPITEUSVendidos.Text;
               _pageView.Tag = COM011_presenter.CUS;
               COM011_lview.Dock = DockStyle.Fill;
               tabViews.Pages.Add(_pageView);
               COM011_lview.CloseForm += View_CloseForm;
               COM011_presenter.Load();
            }
            tabViews.SelectedPage = COM011_lview.TabPageControl;
         }
         catch (Exception ex)
         {
            Dialogos.MostrarMensajeError(Text, "Ha Ocurrido un error al llamar la vista: " + COM011KPITEUSVendidos.Text, ex);
         }
      }

      //COM012LView COM012_lview;
      COM012MView COM012_mview;
      COM012Presenter COM012_presenter;
      private void COM12Comisiones_Click(object sender, EventArgs e)
      {
         try
         {
            if (COM012_mview == null)
            {
               COM012_mview = new COM012MView();
               COM012_presenter = new COM012Presenter(ContainerService, COM012_mview);
               COM012_mview.Presenter = COM012_presenter;
               COM012_presenter.Load();

               COM012_mview.FormClosed += MView_FormClosed;
            }
            COM012_mview.Show();
         }
         catch (Exception ex)
         {
            Dialogos.MostrarMensajeError(Text, "Ha Ocurrido un error al llamar la vista: " + COM007Cotizacion.Text, ex);
         }

         //try
         //{
         //   if (COM012_lview == null)
         //   {
         //      RadPageViewPage _pageView = new RadPageViewPage();
         //      COM012_lview = new COM012LView(_pageView);
         //      COM012_mview = new COM012MView();
         //      COM012_presenter = new COM012Presenter(ContainerService, COM012_lview, COM012_mview);
         //      COM012_lview.Presenter = COM012_presenter;
         //      COM012_lview.IconView = COM12Comisiones.Image;
         //      COM012_mview.Presenter = COM012_presenter;
         //      _pageView.Image = COM12Comisiones.Image;
         //      _pageView.BackColor = Color.LightSteelBlue;
         //      _pageView.Controls.Add(COM012_lview);
         //      _pageView.Text = COM12Comisiones.Text;
         //      COM012_lview.Dock = DockStyle.Fill;
         //      tabViews.Pages.Add(_pageView);
         //      COM012_lview.CloseForm += View_CloseForm;
         //      COM012_presenter.Load();
         //   }
         //   tabViews.SelectedPage = COM012_lview.TabPageControl;
         //}
         //catch (Exception ex)
         //{
         //   Dialogos.MostrarMensajeError(Text, "Ha Ocurrido un error al llamar la vista: " + COM12Comisiones.Text, ex);
         //}
      }

      #endregion

      #region [ Reportes ]

      REP001LView REP001_lview;
      //REP001MView REP001_mview;
      REP001Presenter REP001_presenter;

      private void REP001Fletamiento_Click(object sender, EventArgs e)
      {
         try
         {
            if (REP001_lview == null)
            {
               RadPageViewPage _pageView = new RadPageViewPage();
               REP001_lview = new REP001LView(_pageView);
               //REP001_mview = new REP001MView();
               REP001_presenter = new REP001Presenter(ContainerService, REP001_lview);
               REP001_lview.Presenter = REP001_presenter;
               REP001_lview.IconView = REP001Fletamiento.Image;
               //REP001_mview.Presenter = REP001_presenter;
               _pageView.Image = REP001Fletamiento.Image;
               _pageView.BackColor = Color.LightSteelBlue;
               _pageView.Controls.Add(REP001_lview);
               _pageView.Text = REP001Fletamiento.Text;
               _pageView.Tag = REP001_presenter.CUS;
               REP001_lview.Dock = DockStyle.Fill;
               tabViews.Pages.Add(_pageView);
               REP001_lview.CloseForm += View_CloseForm;
               REP001_presenter.Load();
            }
            tabViews.SelectedPage = REP001_lview.TabPageControl;
         }
         catch (Exception ex)
         {
            Dialogos.MostrarMensajeError(Text, "Ha Ocurrido un error al llamar la vista: " + REP001Fletamiento.Text, ex);
         }
      }

      REP002LView REP002_lview;
      //REP002MView REP002_mview;
      REP002Presenter REP002_presenter;

      private void REP002Tarifario_Click(object sender, EventArgs e)
      {
         try
         {
            if (REP002_lview == null)
            {
               RadPageViewPage _pageView = new RadPageViewPage();
               REP002_lview = new REP002LView(_pageView);
               //REP002_mview = new REP002MView();
               REP002_presenter = new REP002Presenter(ContainerService, REP002_lview);
               REP002_lview.Presenter = REP002_presenter;
               REP002_lview.IconView = REP002Tarifario.Image;
               //REP002_mview.Presenter = REP002_presenter;
               _pageView.Image = REP002Tarifario.Image;
               _pageView.BackColor = Color.LightSteelBlue;
               _pageView.Controls.Add(REP002_lview);
               _pageView.Text = REP002Tarifario.Text;
               _pageView.Tag = REP002_presenter.CUS;
               REP002_lview.Dock = DockStyle.Fill;
               tabViews.Pages.Add(_pageView);
               REP002_lview.CloseForm += View_CloseForm;
               REP002_presenter.Load();
            }
            tabViews.SelectedPage = REP002_lview.TabPageControl;
         }
         catch (Exception ex)
         {
            Dialogos.MostrarMensajeError(Text, "Ha Ocurrido un error al llamar la vista: " + REP002Tarifario.Text, ex);
         }
      }

      REP003LView REP003_lview;
      //REP003MView REP003_mview;
      REP003Presenter REP003_presenter;

      private void REP003OrdenVenta_Click(object sender, EventArgs e)
      {
         try
         {
            if (REP003_lview == null)
            {
               RadPageViewPage _pageView = new RadPageViewPage();
               REP003_lview = new REP003LView(_pageView);
               //REP003_mview = new REP003MView();
               REP003_presenter = new REP003Presenter(ContainerService, REP003_lview);
               REP003_lview.Presenter = REP003_presenter;
               REP003_lview.IconView = REP003OrdenVenta.Image;
               //REP003_mview.Presenter = REP003_presenter;
               _pageView.Image = REP003OrdenVenta.Image;
               _pageView.BackColor = Color.LightSteelBlue;
               _pageView.Controls.Add(REP003_lview);
               _pageView.Text = REP003OrdenVenta.Text;
               _pageView.Tag = REP003_presenter.CUS;
               REP003_lview.Dock = DockStyle.Fill;
               tabViews.Pages.Add(_pageView);
               REP003_lview.CloseForm += View_CloseForm;
               REP003_presenter.Load();
            }
            tabViews.SelectedPage = REP003_lview.TabPageControl;
         }
         catch (Exception ex)
         {
            Dialogos.MostrarMensajeError(Text, "Ha Ocurrido un error al llamar la vista: " + REP003OrdenVenta.Text, ex);
         }
      }

      REP004LView REP004_lview;
      //REP004MView REP004_mview;
      REP004Presenter REP004_presenter;

      private void REP004TarifarioCosto_Click(object sender, EventArgs e)
      {
         try
         {
            if (REP004_lview == null)
            {
               RadPageViewPage _pageView = new RadPageViewPage();
               REP004_lview = new REP004LView(_pageView);
               //REP004_mview = new REP004MView();
               REP004_presenter = new REP004Presenter(ContainerService, REP004_lview);
               REP004_lview.Presenter = REP004_presenter;
               REP004_lview.IconView = REP004TarifarioCosto.Image;
               //REP004_mview.Presenter = REP004_presenter;
               _pageView.Image = REP004TarifarioCosto.Image;
               _pageView.BackColor = Color.LightSteelBlue;
               _pageView.Controls.Add(REP004_lview);
               _pageView.Text = REP004TarifarioCosto.Text;
               _pageView.Tag = REP004_presenter.CUS;
               REP004_lview.Dock = DockStyle.Fill;
               tabViews.Pages.Add(_pageView);
               REP004_lview.CloseForm += View_CloseForm;
               REP004_presenter.Load();
            }
            tabViews.SelectedPage = REP004_lview.TabPageControl;
         }
         catch (Exception ex)
         {
            Dialogos.MostrarMensajeError(Text, "Ha Ocurrido un error al llamar la vista: " + REP004TarifarioCosto.Text, ex);
         }
      }

      REP009LView REP009_lview;
      //REP009MView REP009_mview;
      REP009Presenter REP009_presenter;

      private void REP009PlanillaBuque_Click(object sender, EventArgs e)
      {
         try
         {
            if (REP009_lview == null)
            {
               RadPageViewPage _pageView = new RadPageViewPage();
               REP009_lview = new REP009LView(_pageView);
               //REP009_mview = new REP009MView();
               REP009_presenter = new REP009Presenter(ContainerService, REP009_lview);
               REP009_lview.Presenter = REP009_presenter;
               REP009_lview.IconView = REP009PlanillaBuque.Image;
               //REP009_mview.Presenter = REP009_presenter;
               _pageView.Image = REP009PlanillaBuque.Image;
               _pageView.BackColor = Color.LightSteelBlue;
               _pageView.Controls.Add(REP009_lview);
               _pageView.Text = REP009PlanillaBuque.Text;
               _pageView.Tag = REP009_presenter.CUS;
               REP009_lview.Dock = DockStyle.Fill;
               tabViews.Pages.Add(_pageView);
               REP009_lview.CloseForm += View_CloseForm;
               REP009_presenter.Load();
            }
            tabViews.SelectedPage = REP009_lview.TabPageControl;
         }
         catch (Exception ex)
         {
            Dialogos.MostrarMensajeError(Text, "Ha Ocurrido un error al llamar la vista: " + REP009PlanillaBuque.Text, ex);
         }
      }

      REP010LView REP010_lview;
      //REP010MView REP010_mview;
      REP010Presenter REP010_presenter;
      private void REP010HapagHsud_Click(object sender, EventArgs e)
      {
         try
         {
            if (REP010_lview == null)
            {
               RadPageViewPage _pageView = new RadPageViewPage();
               REP010_lview = new REP010LView(_pageView);
               //REP010_mview = new REP010MView();
               REP010_presenter = new REP010Presenter(ContainerService, REP010_lview);
               REP010_lview.Presenter = REP010_presenter;
               REP010_lview.IconView = REP010HapagHsud.Image;
               //REP010_mview.Presenter = REP010_presenter;
               _pageView.Image = REP010HapagHsud.Image;
               _pageView.BackColor = Color.LightSteelBlue;
               _pageView.Controls.Add(REP010_lview);
               _pageView.Text = REP010HapagHsud.Text;
               _pageView.Tag = REP010_presenter.CUS;
               REP010_lview.Dock = DockStyle.Fill;
               tabViews.Pages.Add(_pageView);
               REP010_lview.CloseForm += View_CloseForm;
               REP010_presenter.Load();
            }
            tabViews.SelectedPage = REP010_lview.TabPageControl;
         }
         catch (Exception ex)
         {
            Dialogos.MostrarMensajeError(Text, "Ha Ocurrido un error al llamar la vista: " + REP010HapagHsud.Text, ex);
         }
      }

      REP011LView REP011_lview;
      //REP011MView REP011_mview;
      REP011Presenter REP011_presenter;
      private void REP011NaveTeus_Click(object sender, EventArgs e)
      {
         try
         {
            if (REP011_lview == null)
            {
               RadPageViewPage _pageView = new RadPageViewPage();
               REP011_lview = new REP011LView(_pageView);
               //REP011_mview = new REP011MView();
               REP011_presenter = new REP011Presenter(ContainerService, REP011_lview);
               REP011_lview.Presenter = REP011_presenter;
               REP011_lview.IconView = REP011NaveTeus.Image;
               //REP011_mview.Presenter = REP011_presenter;
               _pageView.Image = REP011NaveTeus.Image;
               _pageView.BackColor = Color.LightSteelBlue;
               _pageView.Controls.Add(REP011_lview);
               _pageView.Text = REP011NaveTeus.Text;
               _pageView.Tag = REP011_presenter.CUS;
               REP011_lview.Dock = DockStyle.Fill;
               tabViews.Pages.Add(_pageView);
               REP011_lview.CloseForm += View_CloseForm;
               REP011_presenter.Load();
            }
            tabViews.SelectedPage = REP011_lview.TabPageControl;
         }
         catch (Exception ex)
         {
            Dialogos.MostrarMensajeError(Text, "Ha Ocurrido un error al llamar la vista: " + REP011NaveTeus.Text, ex);
         }

      }

      REP012LView REP012_lview;
      //REP012MView REP012_mview;
      REP012Presenter REP012_presenter;
      private void REP012ProfitNegativo_Click(object sender, EventArgs e)
      {
         try
         {
            if (REP012_lview == null)
            {
               RadPageViewPage _pageView = new RadPageViewPage();
               REP012_lview = new REP012LView(_pageView);
               //REP012_mview = new REP012MView();
               REP012_presenter = new REP012Presenter(ContainerService, REP012_lview);
               REP012_lview.Presenter = REP012_presenter;
               REP012_lview.IconView = REP012ProfitNegativo.Image;
               //REP012_mview.Presenter = REP012_presenter;
               _pageView.Image = REP012ProfitNegativo.Image;
               _pageView.BackColor = Color.LightSteelBlue;
               _pageView.Controls.Add(REP012_lview);
               _pageView.Text = REP012ProfitNegativo.Text;
               _pageView.Tag = REP012_presenter.CUS;
               REP012_lview.Dock = DockStyle.Fill;
               tabViews.Pages.Add(_pageView);
               REP012_lview.CloseForm += View_CloseForm;
               REP012_presenter.Load();
            }
            tabViews.SelectedPage = REP012_lview.TabPageControl;
         }
         catch (Exception ex)
         {
            Dialogos.MostrarMensajeError(Text, "Ha Ocurrido un error al llamar la vista: " + REP012ProfitNegativo.Text, ex);
         }
      }

      REP013LView REP013_lview;
      //REP013MView REP013_mview;
      REP013Presenter REP013_presenter;
      private void REP013ComEjecutivo_Click(object sender, EventArgs e)
      {
         try
         {
            if (REP013_lview == null)
            {
               RadPageViewPage _pageView = new RadPageViewPage();
               REP013_lview = new REP013LView(_pageView);
               //REP013_mview = new REP013MView();
               REP013_presenter = new REP013Presenter(ContainerService, REP013_lview);
               REP013_lview.Presenter = REP013_presenter;
               REP013_lview.IconView = REP013ComEjecutivo.Image;
               //REP013_mview.Presenter = REP013_presenter;
               _pageView.Image = REP013ComEjecutivo.Image;
               _pageView.BackColor = Color.LightSteelBlue;
               _pageView.Controls.Add(REP013_lview);
               _pageView.Text = REP013ComEjecutivo.Text;
               _pageView.Tag = REP013_presenter.CUS;
               REP013_lview.Dock = DockStyle.Fill;
               tabViews.Pages.Add(_pageView);
               REP013_lview.CloseForm += View_CloseForm;
               REP013_presenter.Load();
            }
            tabViews.SelectedPage = REP013_lview.TabPageControl;
         }
         catch (Exception ex)
         {
            Dialogos.MostrarMensajeError(Text, "Ha Ocurrido un error al llamar la vista: " + REP013ComEjecutivo.Text, ex);
         }
      }

      REP014View REP014_mview;
      REP014Presenter REP014_presenter;
      private void REP014ControlTransmisiones_Click(object sender, EventArgs e)
      {
         try
         {
            if (REP014_mview == null)
            {
               REP014_mview = new REP014View();
               REP014_presenter = new REP014Presenter(ContainerService, REP014_mview);
               REP014_mview.Presenter = REP014_presenter;
               REP014_presenter.Load();

               REP014_mview.FormClosed += MView_FormClosed;
            }
            REP014_mview.Show();
         }
         catch (Exception ex)
         {
            Dialogos.MostrarMensajeError(Text, "Ha Ocurrido un error al llamar la vista: " + REP014ControlTransmisiones.Text, ex);
         }
      }

      #endregion

      #region [ Logistico ]

      PRO001LView PRO001_LView;
      PRO001MView PRO001_MView;
      PRO001DTarifa PRO001_DView;
      PRO001DSMview PRO001_DSView;
      PRO001Presenter PRO001_Presenter;

      private void LOG001Logistico_Click(object sender, EventArgs e)
      {
         try
         {
            if (PRO001_LView == null)
            {
               RadPageViewPage _pageView = new RadPageViewPage();
               PRO001_LView = new PRO001LView(_pageView);
               PRO001_MView = new PRO001MView();
               PRO001_DView = new PRO001DTarifa();
               PRO001_DSView = new PRO001DSMview();
               PRO001_Presenter = new PRO001Presenter(ContainerService, PRO001_LView, PRO001_MView, PRO001_DView, PRO001_DSView, "L");
               PRO001_Presenter.CUS = "LOG001";
               PRO001_LView.Presenter = PRO001_Presenter;
               PRO001_LView.IconView = LOG001Logistico.Image;
               PRO001_MView.Presenter = PRO001_Presenter;
               PRO001_DView.Presenter = PRO001_Presenter;
               PRO001_DSView.Presenter = PRO001_Presenter;
               _pageView.BackColor = Color.LightSteelBlue;
               _pageView.Controls.Add(PRO001_LView);
               _pageView.Text = LOG001Logistico.Text;
               _pageView.Image = LOG001Logistico.Image;
               _pageView.Tag = PRO001_Presenter.CUS;
               PRO001_LView.Dock = DockStyle.Fill;
               tabViews.Pages.Add(_pageView);
               PRO001_LView.CloseForm += View_CloseForm;
               PRO001_Presenter.Load();
            }
            tabViews.SelectedPage = PRO001_LView.TabPageControl;
         }
         catch (Exception ex)
         {
            Dialogos.MostrarMensajeError(Text, "Ha ocurrido un error al llamar la vista: " + LOG001Logistico.Text, ex);
         }
      }

      PRO001LView PRO0001_LView;
      PRO001MView PRO0001_MView;
      PRO001DTarifa PRO0001_DView;
      PRO001DSMview PRO0001_DSView;
      PRO001Presenter PRO0001_Presenter;

      private void LOG001Aduanero_Click(object sender, EventArgs e)
      {
         try
         {
            if (PRO0001_LView == null)
            {
               RadPageViewPage _pageView = new RadPageViewPage();
               PRO0001_LView = new PRO001LView(_pageView);
               PRO0001_MView = new PRO001MView();
               PRO0001_DView = new PRO001DTarifa();
               PRO0001_DSView = new PRO001DSMview();
               PRO0001_Presenter = new PRO001Presenter(ContainerService, PRO0001_LView, PRO0001_MView, PRO0001_DView, PRO0001_DSView, "A");
               PRO0001_Presenter.CUS = "LOG0001";
               PRO0001_LView.Presenter = PRO0001_Presenter;
               PRO0001_LView.IconView = LOG001Aduanero.Image;
               PRO0001_MView.Presenter = PRO0001_Presenter;
               PRO0001_DView.Presenter = PRO0001_Presenter;
               PRO0001_DSView.Presenter = PRO0001_Presenter;
               _pageView.BackColor = Color.LightSteelBlue;
               _pageView.Controls.Add(PRO0001_LView);
               _pageView.Text = LOG001Aduanero.Text;
               _pageView.Image = LOG001Aduanero.Image;
               _pageView.Tag = PRO001_Presenter.CUS;
               PRO0001_LView.Dock = DockStyle.Fill;
               tabViews.Pages.Add(_pageView);
               PRO0001_LView.CloseForm += View_CloseForm;
               PRO0001_Presenter.Load();
            }
            tabViews.SelectedPage = PRO0001_LView.TabPageControl;
         }
         catch (Exception ex)
         {
            Dialogos.MostrarMensajeError(Text, "Ha ocurrido un error al llamar la vista: " + LOG001Aduanero.Text, ex);
         }
      }

      PRO001LView PRO00001_LView;
      PRO001MView PRO00001_MView;
      PRO001DTarifa PRO00001_DView;
      PRO001DSMview PRO00001_DSView;
      PRO001Presenter PRO00001_Presenter;

      private void LOG001Transporte_Click(object sender, EventArgs e)
      {
         try
         {
            if (PRO00001_LView == null)
            {
               RadPageViewPage _pageView = new RadPageViewPage();
               PRO00001_LView = new PRO001LView(_pageView);
               PRO00001_MView = new PRO001MView();
               PRO00001_DView = new PRO001DTarifa();
               PRO00001_DSView = new PRO001DSMview();
               PRO00001_Presenter = new PRO001Presenter(ContainerService, PRO00001_LView, PRO00001_MView, PRO00001_DView, PRO0001_DSView, "T");
               PRO00001_Presenter.CUS = "LOG00001";
               PRO00001_LView.Presenter = PRO00001_Presenter;
               PRO00001_LView.IconView = LOG001Transporte.Image;
               PRO00001_MView.Presenter = PRO00001_Presenter;
               PRO00001_DView.Presenter = PRO00001_Presenter;
               PRO00001_DSView.Presenter = PRO00001_Presenter;
               _pageView.BackColor = Color.LightSteelBlue;
               _pageView.Controls.Add(PRO00001_LView);
               _pageView.Text = LOG001Transporte.Text;
               _pageView.Image = LOG001Transporte.Image;
               _pageView.Tag = PRO00001_Presenter.CUS;
               PRO00001_LView.Dock = DockStyle.Fill;
               tabViews.Pages.Add(_pageView);
               PRO00001_LView.CloseForm += View_CloseForm;
               PRO00001_Presenter.Load();
            }
            tabViews.SelectedPage = PRO00001_LView.TabPageControl;
         }
         catch (Exception ex)
         {
            Dialogos.MostrarMensajeError(Text, "Ha ocurrido un error al llamar la vista: " + LOG001Transporte.Text, ex);
         }
      }

      PRO002LView PRO002_LView;
      PRO002MView PRO002_MView;
      PRO002DMview PRO002_DView;
      PRO002DSMview PRO002_DSView;
      PRO002Presenter PRO002_Presenter;
      PRO002DImprimir PRO002_Imprimir;

      private void LOG002Cotizaciones_Click(object sender, EventArgs e)
      {
         try
         {
            if (PRO002_LView == null)
            {
               RadPageViewPage _pageView = new RadPageViewPage();
               PRO002_LView = new PRO002LView(_pageView);
               PRO002_MView = new PRO002MView();
               PRO002_DView = new PRO002DMview();
               PRO002_DSView = new PRO002DSMview();
               PRO002_Imprimir = new PRO002DImprimir();
               PRO002_Presenter = new PRO002Presenter(ContainerService, PRO002_LView, PRO002_MView, PRO002_DView, PRO002_DSView, PRO002_Imprimir);
               PRO002_Presenter.CUS = "LOG002";
               PRO002_Imprimir.Presenter = PRO002_Presenter;
               PRO002_LView.Presenter = PRO002_Presenter;
               PRO002_LView.IconView = LOG002Cotizaciones.Image;
               PRO002_MView.Presenter = PRO002_Presenter;
               PRO002_DView.Presenter = PRO002_Presenter;
               PRO002_DSView.Presenter = PRO002_Presenter;
               _pageView.BackColor = Color.LightSteelBlue;
               _pageView.Controls.Add(PRO002_LView);
               _pageView.Text = LOG002Cotizaciones.Text;
               _pageView.Image = LOG002Cotizaciones.Image;
               _pageView.Tag = PRO002_Presenter.CUS;
               PRO002_LView.Dock = DockStyle.Fill;
               tabViews.Pages.Add(_pageView);
               PRO002_LView.CloseForm += View_CloseForm;
               PRO002_Presenter.Load();
            }
            tabViews.SelectedPage = PRO002_LView.TabPageControl;
         }
         catch (Exception ex)
         {
            Dialogos.MostrarMensajeError(Text, "Ha ocurrido un error al llamar la vista: " + LOG002Cotizaciones.Text, ex);
         }
      }

      PRO005LView PRO005_LView;
      PRO005Presenter PRO005_Presenter;

      private void LOG005Direccionamiento_Click(object sender, EventArgs e)
      {
         try
         {
            if (PRO005_LView == null)
            {
               RadPageViewPage _pageView = new RadPageViewPage();
               PRO005_LView = new PRO005LView(_pageView);
               PRO005_Presenter = new PRO005Presenter(ContainerService, PRO005_LView);
               PRO005_Presenter.CUS = "LOG005";
               PRO005_LView.Presenter = PRO005_Presenter;
               PRO005_LView.IconView = LOG005Direccionamiento.Image;
               _pageView.BackColor = Color.LightSteelBlue;
               _pageView.Controls.Add(PRO005_LView);
               _pageView.Text = LOG005Direccionamiento.Text;
               _pageView.Image = LOG005Direccionamiento.Image;
               _pageView.Tag = PRO005_Presenter.CUS;
               PRO005_LView.Dock = DockStyle.Fill;
               tabViews.Pages.Add(_pageView);
               PRO005_LView.CloseForm += View_CloseForm;
               PRO005_Presenter.Load();
            }
            tabViews.SelectedPage = PRO005_LView.TabPageControl;
         }
         catch (Exception ex)
         {
            Dialogos.MostrarMensajeError(Text, "Ha ocurrido un error al llamar la vista: " + LOG005Direccionamiento.Text, ex);
         }
      }

      PRO003LView PRO003_LView;
      PRO003MView PRO003_MView;
      PRO003DMview PRO003_DView;
      PRO003DSMview PRO003_DSView;
      PRO003Presenter PRO003_Presenter;

      private void LOG008Operacion_Click(object sender, EventArgs e)
      {
         try
         {
            if (PRO003_LView == null)
            {
               RadPageViewPage _pageView = new RadPageViewPage();
               PRO003_LView = new PRO003LView(_pageView);
               PRO003_MView = new PRO003MView();
               PRO003_DView = new PRO003DMview();
               PRO003_DSView = new PRO003DSMview();
               PRO003_Presenter = new PRO003Presenter(ContainerService, PRO003_LView, PRO003_MView, PRO003_DView, PRO003_DSView);
               PRO003_Presenter.CUS = "LOG003";
               PRO003_LView.Presenter = PRO003_Presenter;
               PRO003_LView.IconView = LOG008Operacion.Image;
               PRO003_MView.Presenter = PRO003_Presenter;
               PRO003_DView.Presenter = PRO003_Presenter;
               PRO003_DSView.Presenter = PRO003_Presenter;
               _pageView.BackColor = Color.LightSteelBlue;
               _pageView.Controls.Add(PRO003_LView);
               _pageView.Text = LOG008Operacion.Text;
               _pageView.Image = LOG008Operacion.Image;
               _pageView.Tag = PRO003_Presenter.CUS;
               PRO003_LView.Dock = DockStyle.Fill;
               tabViews.Pages.Add(_pageView);
               PRO003_LView.CloseForm += View_CloseForm;
               PRO003_Presenter.Load();
            }
            tabViews.SelectedPage = PRO003_LView.TabPageControl;
         }
         catch (Exception ex)
         {
            Dialogos.MostrarMensajeError(Text, "Ha ocurrido un error al llamar la vista: " + LOG008Operacion.Text, ex);
         }
      }

      PRO006LView PRO006_LView;
      PRO006MView PRO006_MView;
      IPRO006DMview PRO006_DMView;
      PRO006Presenter PRO006_Presenter;

      private void LOG006Seguimientos_Click(object sender, EventArgs e)
      {
         try
         {
            if (PRO006_LView == null)
            {
               RadPageViewPage _pageView = new RadPageViewPage();
               PRO006_LView = new PRO006LView(_pageView);
               PRO006_MView = new PRO006MView();
               PRO006_DMView = new PRO006DMview();
               PRO006_Presenter = new PRO006Presenter(ContainerService, PRO006_LView, PRO006_MView, PRO006_DMView);
               PRO006_Presenter.CUS = "LOG006";
               PRO006_LView.Presenter = PRO006_Presenter;
               PRO006_LView.IconView = LOG006Seguimientos.Image;
               PRO006_MView.Presenter = PRO006_Presenter;
               PRO006_DMView.Presenter = PRO006_Presenter;
               _pageView.BackColor = Color.LightSteelBlue;
               _pageView.Controls.Add(PRO006_LView);
               _pageView.Text = LOG006Seguimientos.Text;
               _pageView.Image = LOG006Seguimientos.Image;
               _pageView.Tag = PRO006_Presenter.CUS;
               PRO006_LView.Dock = DockStyle.Fill;
               tabViews.Pages.Add(_pageView);
               PRO006_LView.CloseForm += View_CloseForm;
               PRO006_Presenter.Load();
            }
            tabViews.SelectedPage = PRO006_LView.TabPageControl;
         }
         catch (Exception ex)
         {
            Dialogos.MostrarMensajeError(Text, "Ha ocurrido un error al llamar la vista: " + LOG006Seguimientos.Text, ex);
         }
      }

      PRO022LView PRO022_LView;
      PRO022MView PRO022_MView;
      PRO022Presenter PRO022_Presenter;

      private void LOG022NotaCredito_Click(object sender, EventArgs e)
      {
         try
         {
            if (PRO022_LView == null)
            {
               RadPageViewPage _pageView = new RadPageViewPage();
               PRO022_LView = new PRO022LView(_pageView);
               PRO022_MView = new PRO022MView();
               PRO022_Presenter = new PRO022Presenter(ContainerService, PRO022_LView);
               PRO022_Presenter.CUS = "PRO022";
               PRO022_LView.Presenter = PRO022_Presenter;
               PRO022_MView.Presenter = PRO022_Presenter;
               //PRO022_LView.IconView = PRO022NotaCredito.Image;
               _pageView.BackColor = Color.LightSteelBlue;
               _pageView.Controls.Add(PRO022_LView);
               _pageView.Tag = PRO022_Presenter.CUS;
               //_pageView.Text = PRO022NotaCredito.Text;
               //_pageView.Image = PRO022NotaCredito.Image;
               PRO022_LView.Dock = DockStyle.Fill;
               tabViews.Pages.Add(_pageView);
               PRO022_LView.CloseForm += View_CloseForm;
               PRO022_Presenter.Load();
            }
            tabViews.SelectedPage = PRO022_LView.TabPageControl;
         }
         catch (Exception ex)
         {
            //Dialogos.MostrarMensajeError(Text, "Ha ocurrido un error al llamar la vista: " + PRO022NotaCredito.Text, ex);
         }
      }

      PRO004MView PRO004_MView;
      PRO004DMview PRO004_DView;
      PRO004LView PRO004_LView;
      PRO004Presenter PRO004_Presenter;

      private void LOG007Tarjas_Click(object sender, EventArgs e)
      {
         try
         {
            if (PRO004_LView == null)
            {
               RadPageViewPage _pageView = new RadPageViewPage();
               PRO004_LView = new PRO004LView(_pageView);
               PRO004_MView = new PRO004MView();
               PRO004_DView = new PRO004DMview();
               PRO004_Presenter = new PRO004Presenter(ContainerService, PRO004_LView, PRO004_MView, PRO004_DView);
               PRO004_Presenter.CUS = "LOG004";
               PRO004_LView.Presenter = PRO004_Presenter;
               PRO004_MView.Presenter = PRO004_Presenter;
               PRO004_DView.Presenter = PRO004_Presenter;
               PRO004_LView.IconView = LOG007Tarjas.Image;
               _pageView.BackColor = Color.LightSteelBlue;
               _pageView.Controls.Add(PRO004_LView);
               _pageView.Text = LOG007Tarjas.Text;
               _pageView.Image = LOG007Tarjas.Image;
               _pageView.Tag = PRO004_Presenter.CUS;
               PRO004_LView.Dock = DockStyle.Fill;
               tabViews.Pages.Add(_pageView);
               PRO004_LView.CloseForm += View_CloseForm;
               PRO004_Presenter.Load();
            }
            tabViews.SelectedPage = PRO004_LView.TabPageControl;
         }
         catch (Exception ex)
         {
            Dialogos.MostrarMensajeError(Text, "Ha ocurrido un error al llamar la vista: " + LOG007Tarjas.Text, ex);
         }
      }

      PRO007LView PRO007_LView;
      PRO007MView PRO007_MView;
      PRO007RView PRO007_RMView;
      PRO007Presenter PRO007_Presenter;

      private void LOG004Clientes_Click(object sender, EventArgs e)
      {
         try
         {
            if (PRO007_LView == null)
            {
               RadPageViewPage _pageView = new RadPageViewPage();
               PRO007_LView = new PRO007LView(_pageView);
               PRO007_MView = new PRO007MView();
               PRO007_RMView = new PRO007RView();
               PRO007_Presenter = new PRO007Presenter(ContainerService, PRO007_LView, PRO007_MView, PRO007_RMView);
               PRO007_Presenter.CUS = "Factura";
               PRO007_LView.Presenter = PRO007_Presenter;
               PRO007_LView.IconView = LOG004Clientes.Image;
               PRO007_MView.Presenter = PRO007_Presenter;
               PRO007_RMView.Presenter = PRO007_Presenter;
               _pageView.BackColor = Color.LightSteelBlue;
               _pageView.Controls.Add(PRO007_LView);
               _pageView.Text = LOG004Clientes.Text;
               _pageView.Image = LOG004Clientes.Image;
               _pageView.Tag = PRO007_Presenter.CUS;
               PRO007_LView.Dock = DockStyle.Fill;
               tabViews.Pages.Add(_pageView);
               PRO007_LView.CloseForm += View_CloseForm;
               PRO007_Presenter.TipoDocumentoVenta = "Factura";
               PRO007_Presenter.Load();
            }
            tabViews.SelectedPage = PRO007_LView.TabPageControl;
         }
         catch (Exception ex)
         {
            Dialogos.MostrarMensajeError(Text, "Ha ocurrido un error al llamar la vista: " + LOG004Clientes.Text, ex);
         }
      }

      PRO007LView PRO007FE_LView;
      PRO007MView PRO007FE_MView;
      PRO007RView PRO007FE_RMView;
      PRO007Presenter PRO007FE_Presenter;

      private void LOG004FEClientes_Click(object sender, EventArgs e)
      {
          try
          {
              if (PRO007FE_LView == null)
              {
                  RadPageViewPage _pageView = new RadPageViewPage();
                  PRO007FE_LView = new PRO007LView(_pageView);
                  PRO007FE_MView = new PRO007MView();
                  PRO007FE_RMView = new PRO007RView();
                  PRO007FE_Presenter = new PRO007Presenter(ContainerService, PRO007FE_LView, PRO007FE_MView, PRO007FE_RMView);
                  PRO007FE_Presenter.CUS = "Facturación Electrónica";
                  PRO007FE_LView.Presenter = PRO007FE_Presenter;
                  PRO007FE_LView.IconView = LOG004FEClientes.Image;
                  PRO007FE_MView.Presenter = PRO007FE_Presenter;
                  PRO007FE_RMView.Presenter = PRO007FE_Presenter;
                  _pageView.BackColor = Color.LightSteelBlue;
                  _pageView.Controls.Add(PRO007FE_LView);
                  _pageView.Text = LOG004FEClientes.Text;
                  _pageView.Image = LOG004FEClientes.Image;
                  _pageView.Tag = PRO007FE_Presenter.CUS;
                  PRO007FE_LView.Dock = DockStyle.Fill;
                  tabViews.Pages.Add(_pageView);
                  PRO007FE_LView.CloseForm += View_CloseForm;
                  PRO007FE_Presenter.TipoDocumentoVenta = "eFact";
                  PRO007FE_Presenter.Load();
              }
              tabViews.SelectedPage = PRO007FE_LView.TabPageControl;
          }
          catch (Exception ex)
          {
              Dialogos.MostrarMensajeError(Text, "Ha ocurrido un error al llamar la vista: " + LOG004FEClientes.Text, ex);
          }
      }


      PRO008LView PRO008_LView;
      PRO008MView PRO008_MView;
      PRO008Presenter PRO008_Presenter;

      private void LOG004Proveedores_Click(object sender, EventArgs e)
      {
         try
         {
            if (PRO008_LView == null)
            {
               RadPageViewPage _pageView = new RadPageViewPage();
               PRO008_LView = new PRO008LView(_pageView);
               PRO008_MView = new PRO008MView();
               PRO008_Presenter = new PRO008Presenter(ContainerService, PRO008_LView, PRO008_MView);
               PRO008_Presenter.CUS = "LOG008";
               PRO008_LView.Presenter = PRO008_Presenter;
               PRO008_LView.IconView = LOG004Proveedores.Image;
               PRO008_MView.Presenter = PRO008_Presenter;
               _pageView.BackColor = Color.LightSteelBlue;
               _pageView.Controls.Add(PRO008_LView);
               _pageView.Text = LOG004Proveedores.Text;
               _pageView.Image = LOG004Proveedores.Image;
               _pageView.Tag = PRO008_Presenter.CUS;
               PRO008_LView.Dock = DockStyle.Fill;
               tabViews.Pages.Add(_pageView);
               PRO008_LView.CloseForm += View_CloseForm;
               PRO008_Presenter.Load();
            }
            tabViews.SelectedPage = PRO008_LView.TabPageControl;
         }
         catch (Exception ex)
         {
            Dialogos.MostrarMensajeError(Text, "Ha ocurrido un error al llamar la vista: " + LOG004Proveedores.Text, ex);
         }
      }

      //PRO009LView PRO009_LView;
      //PRO009MView PRO009_MView;
      //PRO009Presenter PRO009_Presenter;
      private void LOG00522CtasCaja_Click(object sender, EventArgs e)
      {
         try
         {
            //      if (PRO009_LView == null)
            //      {
            //         RadPageViewPage _pageView = new RadPageViewPage();
            //         PRO009_LView = new PRO009LView(_pageView);
            //         PRO009_MView = new PRO009MView();
            //         PRO009_Presenter = new PRO009Presenter(ContainerService, PRO009_LView, PRO009_MView);
            //         PRO009_Presenter.CUS = "LOG009";
            //         PRO009_LView.Presenter = PRO009_Presenter;
            //         PRO009_LView.IconView = LOG00522CtasCaja.Image;
            //         PRO009_MView.Presenter = PRO009_Presenter;
            //         _pageView.BackColor = Color.LightSteelBlue;
            //         _pageView.Controls.Add(PRO009_LView);
            //         _pageView.Text = LOG00522CtasCaja.Text;
            //         _pageView.Image = LOG00522CtasCaja.Image;
            //         PRO009_LView.Dock = DockStyle.Fill;
            //         tabViews.Pages.Add(_pageView);
            //         PRO009_LView.CloseForm += View_CloseForm;
            //         PRO009_Presenter.Load();
            //      }
            //      tabViews.SelectedPage = PRO009_LView.TabPageControl;
         }
         catch (Exception ex)
         {
            //Dialogos.MostrarMensajeError(Text, "Ha ocurrido un error al llamar la vista: " + LOG00522CtasCaja.Text, ex);
         }
      }

      PRO010LView PRO010_LView;
      PRO010MView PRO010_MView;
      PRO010Presenter PRO010_Presenter;
      PRO010RView PRO010_RView;

      private void LOG00522Pagos_Click(object sender, EventArgs e)
      {
         try
         {
            //if (PRO010_LView == null)
            //{
            //    RadPageViewPage _pageView = new RadPageViewPage();
            //    PRO010_LView = new PRO010LView(_pageView);
            //    PRO010_MView = new PRO010MView();
            //    PRO010_RView = new PRO010RView();
            //    PRO010_Presenter = new PRO010Presenter(ContainerService, PRO010_LView, PRO010_MView, PRO010_RView);
            //    PRO010_Presenter.CUS = "LOG010";
            //    PRO010_Presenter.CAJA_Tipo = "P";
            //    PRO010_LView.Presenter = PRO010_Presenter;
            //    PRO010_LView.IconView = LOG00522Pagos.Image;
            //    PRO010_MView.Presenter = PRO010_Presenter;
            //    PRO010_RView.Presenter = PRO010_Presenter;
            //    _pageView.BackColor = Color.LightSteelBlue;
            //    _pageView.Controls.Add(PRO010_LView);
            //    _pageView.Text = "Pago Proveedores";
            //    _pageView.Image = LOG00522Pagos.Image;
            //    PRO010_LView.Dock = DockStyle.Fill;
            //    tabViews.Pages.Add(_pageView);
            //    PRO010_LView.CloseForm += View_CloseForm;
            //    PRO010_Presenter.Load();
            //}
            //tabViews.SelectedPage = PRO010_LView.TabPageControl;
         }
         catch (Exception ex)
         {
            //Dialogos.MostrarMensajeError(Text, "Ha ocurrido un error al llamar la vista: " + LOG00522Pagos.Text, ex);
         }
      }

      PRO010LView PRO011_LView;
      PRO010MView PRO011_MView;
      PRO010Presenter PRO011_Presenter;
      PRO010RView PRO011_RView;

      private void LOG005Clientes_Click(object sender, EventArgs e)
      {
         try
         {
            //if (PRO011_LView == null)
            //{
            //    RadPageViewPage _pageView = new RadPageViewPage();
            //    PRO011_LView = new PRO010LView(_pageView);
            //    PRO011_MView = new PRO010MView();
            //    PRO011_RView = new PRO010RView();
            //    PRO011_Presenter = new PRO010Presenter(ContainerService, PRO011_LView, PRO011_MView, PRO011_RView);
            //    PRO011_Presenter.CUS = "LOG011";
            //    PRO011_Presenter.CAJA_Tipo = "C";
            //    PRO011_LView.Presenter = PRO011_Presenter;
            //    PRO011_LView.IconView = LOG005Clientes.Image;
            //    PRO011_MView.Presenter = PRO011_Presenter;
            //    PRO011_RView.Presenter = PRO011_Presenter;
            //    _pageView.BackColor = Color.LightSteelBlue;
            //    _pageView.Controls.Add(PRO011_LView);
            //    _pageView.Text = "Pago Clientes";
            //    _pageView.Image = LOG00522Pagos.Image;
            //    PRO011_LView.Dock = DockStyle.Fill;
            //    tabViews.Pages.Add(_pageView);
            //    PRO011_LView.CloseForm += View_CloseForm;
            //    PRO011_Presenter.Load();
            //}
            //tabViews.SelectedPage = PRO011_LView.TabPageControl;
         }
         catch (Exception ex)
         {
            //Dialogos.MostrarMensajeError(Text, "Ha ocurrido un error al llamar la vista: " + LOG00522Pagos.Text, ex);
         }
      }

      PRO007LView PRO007PRE_LView;
      PRO007MView PRO007PRE_MView;
      PRO007Presenter PRO007PRE_Presenter;

      private void toolPreFacturacion_Click(object sender, EventArgs e)
      {
         try
         {
            if (PRO007PRE_LView == null)
            {
               RadPageViewPage _pageView = new RadPageViewPage();
               PRO007PRE_LView = new PRO007LView(_pageView);
               PRO007PRE_MView = new PRO007MView();

               PRO007PRE_Presenter = new PRO007Presenter(ContainerService, PRO007PRE_LView, PRO007PRE_MView);
               PRO007PRE_Presenter.CUS = "PreFactura";
               PRO007PRE_LView.Presenter = PRO007PRE_Presenter;
               PRO007PRE_LView.IconView = LOG008Clientes.Image;
               PRO007PRE_MView.Presenter = PRO007PRE_Presenter;
               _pageView.BackColor = Color.LightSteelBlue;
               _pageView.Controls.Add(PRO007PRE_LView);
               _pageView.Text = LOG008Clientes.Text;
               _pageView.Image = LOG008Clientes.Image;
               _pageView.Tag = PRO007PRE_Presenter.CUS;
               PRO007PRE_LView.Dock = DockStyle.Fill;
               tabViews.Pages.Add(_pageView);
               PRO007PRE_LView.CloseForm += View_CloseForm;
               PRO007PRE_Presenter.TipoDocumentoVenta = "PreFactura";
               PRO007PRE_Presenter.Load();
            }
            tabViews.SelectedPage = PRO007PRE_LView.TabPageControl;
         }
         catch (Exception ex)
         {
            Dialogos.MostrarMensajeError(Text, "Ha ocurrido un error al llamar la vista: " + LOG008Clientes.Text, ex);
         }
      }

      REP005LView REP005_LView;
      PRO005RView REP005_MView;
      REP005Presenter REP005_Presenter;

      private void ConServicioLogistico_Click(object sender, EventArgs e)
      {
         try
         {
            if (REP005_LView == null)
            {
               RadPageViewPage _pageView = new RadPageViewPage();
               REP005_LView = new REP005LView(_pageView);
               REP005_MView = new PRO005RView();
               REP005_Presenter = new REP005Presenter(ContainerService, REP005_LView, REP005_MView);
               REP005_Presenter.CUS = "REP005Con";
               REP005_LView.Presenter = REP005_Presenter;
               REP005_LView.IconView = ConServicioLogistico.Image;
               REP005_MView.Presenter = REP005_Presenter;
               _pageView.BackColor = Color.LightSteelBlue;
               _pageView.Controls.Add(REP005_LView);
               _pageView.Text = @"Pre-Liquidación con Servicio Logístico";
               _pageView.Image = ConServicioLogistico.Image;
               _pageView.Tag = REP005_Presenter.CUS;
               REP005_LView.Dock = DockStyle.Fill;
               tabViews.Pages.Add(_pageView);
               REP005_LView.CloseForm += View_CloseForm;
               REP005_Presenter.TipoReporte = "ConServicioLogistico";
               REP005_Presenter.Load();
            }
            tabViews.SelectedPage = REP005_LView.TabPageControl;
         }
         catch (Exception ex)
         {
            Dialogos.MostrarMensajeError(Text, "Ha ocurrido un error al llamar la vista: " + "Pre-Liquidación con Servicio Logístico", ex);
         }
      }

      REP005LView REP005S_LView;
      PRO005RView REP005S_MView;
      REP005Presenter REP005S_Presenter;

      private void SinServicioLogístico_Click(object sender, EventArgs e)
      {
         try
         {
            if (REP005S_LView == null)
            {
               RadPageViewPage _pageView = new RadPageViewPage();
               REP005S_LView = new REP005LView(_pageView);
               REP005S_MView = new PRO005RView();
               REP005S_Presenter = new REP005Presenter(ContainerService, REP005S_LView, REP005S_MView);
               REP005S_Presenter.CUS = "REP005Sin";
               REP005S_LView.Presenter = REP005S_Presenter;
               REP005S_LView.IconView = SinServicioLogístico.Image;
               REP005S_MView.Presenter = REP005S_Presenter;
               _pageView.BackColor = Color.LightSteelBlue;
               _pageView.Controls.Add(REP005S_LView);
               _pageView.Text = @"Pre-Liquidación sin Servicio Logístico";
               _pageView.Image = SinServicioLogístico.Image;
               _pageView.Tag = REP005S_Presenter.CUS;
               REP005S_LView.Dock = DockStyle.Fill;
               tabViews.Pages.Add(_pageView);
               REP005S_LView.CloseForm += View_CloseForm;
               REP005S_Presenter.TipoReporte = "SinServicioLogistico";
               REP005S_Presenter.Load();
            }
            tabViews.SelectedPage = REP005S_LView.TabPageControl;
         }
         catch (Exception ex)
         {
            Dialogos.MostrarMensajeError(Text, "Ha ocurrido un error al llamar la vista: " + "Pre-Liquidación sin Servicio Logístico", ex);
         }
      }

      REP005LView REP005L_LView;
      PRO005RView REP005L_MView;
      REP005Presenter REP005L_Presenter;

      private void REP0051Liquidación_Click(object sender, EventArgs e)
      {
         try
         {
            if (REP005L_LView == null)
            {
               RadPageViewPage _pageView = new RadPageViewPage();
               REP005L_LView = new REP005LView(_pageView);
               REP005L_MView = new PRO005RView();
               REP005L_Presenter = new REP005Presenter(ContainerService, REP005L_LView, REP005L_MView);
               REP005L_Presenter.CUS = "REP005Liq";
               REP005L_LView.Presenter = REP005L_Presenter;
               REP005L_LView.IconView = SinServicioLogístico.Image;
               REP005L_MView.Presenter = REP005L_Presenter;
               _pageView.BackColor = Color.LightSteelBlue;
               _pageView.Controls.Add(REP005L_LView);
               _pageView.Text = @"Liquidación de Servicios";
               _pageView.Image = SinServicioLogístico.Image;
               _pageView.Tag = REP005L_Presenter.CUS;
               REP005L_LView.Dock = DockStyle.Fill;
               tabViews.Pages.Add(_pageView);
               REP005L_LView.CloseForm += View_CloseForm;
               REP005L_Presenter.TipoReporte = "Liquidacion";
               REP005L_Presenter.Load();
            }
            tabViews.SelectedPage = REP005L_LView.TabPageControl;
         }
         catch (Exception ex)
         {
            Dialogos.MostrarMensajeError(Text, "Ha ocurrido un error al llamar la vista: " + "Liquidación de Servicios", ex);
         }
      }

      REP006LView REP006_LView;
      PRO006RView REP006_MView;
      REP006Presenter REP006_Presenter;

      private void tarjaRebateToolStripMenuItem_Click(object sender, EventArgs e)
      {
         try
         {
            if (REP006_LView == null)
            {
               RadPageViewPage _pageView = new RadPageViewPage();
               REP006_LView = new REP006LView(_pageView);
               REP006_MView = new PRO006RView();
               REP006_Presenter = new REP006Presenter(ContainerService, REP006_LView, REP006_MView);
               REP006_Presenter.CUS = "REP006";
               REP006_LView.Presenter = REP006_Presenter;
               REP006_LView.IconView = tarjaRebateToolStripMenuItem.Image;
               REP006_MView.Presenter = REP006_Presenter;
               _pageView.BackColor = Color.LightSteelBlue;
               _pageView.Controls.Add(REP006_LView);
               _pageView.Text = @"Tarjas / Rebate ";
               _pageView.Image = tarjaRebateToolStripMenuItem.Image;
               _pageView.Tag = REP006_Presenter.CUS;
               REP006_LView.Dock = DockStyle.Fill;
               tabViews.Pages.Add(_pageView);
               REP006_LView.CloseForm += View_CloseForm;
               REP006_Presenter.Load();
            }
            tabViews.SelectedPage = REP006_LView.TabPageControl;
         }
         catch (Exception ex)
         {
            Dialogos.MostrarMensajeError(Text, "Ha ocurrido un error al llamar la vista: " + "Tarjas / Rebate", ex);
         }
      }

      REP007LView REP007_LView;
      PRO007RMView REP007_RMView;
      REP007Presenter REP007_Presenter;

      private void ingresosToolStripMenuItem_Click(object sender, EventArgs e)
      {
         try
         {
            if (REP007_LView == null)
            {
               RadPageViewPage _pageView = new RadPageViewPage();
               REP007_LView = new REP007LView(_pageView);
               REP007_RMView = new PRO007RMView();
               REP007_Presenter = new REP007Presenter(ContainerService, REP007_LView, REP007_RMView);
               REP007_Presenter.CUS = "REP007";
               REP007_LView.Presenter = REP007_Presenter;
               REP007_LView.IconView = ingresosToolStripMenuItem.Image;
               REP007_RMView.Presenter = REP007_Presenter;
               _pageView.BackColor = Color.LightSteelBlue;
               _pageView.Controls.Add(REP007_LView);
               _pageView.Text = @"Ingresos";
               _pageView.Image = ingresosToolStripMenuItem.Image;
               _pageView.Tag = REP007_Presenter.CUS;
               REP007_LView.Dock = DockStyle.Fill;
               tabViews.Pages.Add(_pageView);
               REP007_LView.CloseForm += View_CloseForm;
               REP007_Presenter.Load();
            }
            tabViews.SelectedPage = REP007_LView.TabPageControl;
         }
         catch (Exception ex)
         {
            Dialogos.MostrarMensajeError(Text, "Ha ocurrido un error al llamar la vista: " + "Ingresos", ex);
         }
      }

      REP008LView REP008_LView;
      PRO008RMView REP008_RMView;
      REP008Presenter REP008_Presenter;

      private void serviciosAdicionalesToolStripMenuItem_Click(object sender, EventArgs e)
      {
         try
         {
            if (REP008_LView == null)
            {
               RadPageViewPage _pageView = new RadPageViewPage();
               REP008_LView = new REP008LView(_pageView);
               REP008_RMView = new PRO008RMView();
               REP008_Presenter = new REP008Presenter(ContainerService, REP008_LView, REP008_RMView);
               REP008_Presenter.CUS = "REP008";
               REP008_LView.Presenter = REP008_Presenter;
               REP008_LView.IconView = serviciosAdicionalesToolStripMenuItem.Image;
               REP008_RMView.Presenter = REP008_Presenter;
               _pageView.BackColor = Color.LightSteelBlue;
               _pageView.Controls.Add(REP008_LView);
               _pageView.Text = @"Servicios Adicionales ";
               _pageView.Image = serviciosAdicionalesToolStripMenuItem.Image;
               _pageView.Tag = REP008_Presenter.CUS;
               REP008_LView.Dock = DockStyle.Fill;
               tabViews.Pages.Add(_pageView);
               REP008_LView.CloseForm += View_CloseForm;
               REP008_Presenter.TipoReporte = "Transporte";
               REP008_Presenter.Load();
            }
            tabViews.SelectedPage = REP008_LView.TabPageControl;
         }
         catch (Exception ex)
         {
            Dialogos.MostrarMensajeError(Text, "Ha ocurrido un error al llamar la vista: " + "Servicios Adicionales", ex);
         }
      }

      REP008LView REP0081_LView;
      PRO008RMView REP0081_RMView;
      REP008Presenter REP0081_Presenter;

      private void RepServiciosAduanas_Click(object sender, EventArgs e)
      {
         try
         {
            if (REP0081_LView == null)
            {
               RadPageViewPage _pageView = new RadPageViewPage();
               REP0081_LView = new REP008LView(_pageView);
               REP0081_RMView = new PRO008RMView();
               REP0081_Presenter = new REP008Presenter(ContainerService, REP0081_LView, REP0081_RMView);
               REP0081_Presenter.CUS = "REP0081";
               REP0081_LView.Presenter = REP0081_Presenter;
               REP0081_LView.IconView = RepServiciosAduanas.Image;
               REP0081_RMView.Presenter = REP0081_Presenter;
               _pageView.BackColor = Color.LightSteelBlue;
               _pageView.Controls.Add(REP0081_LView);
               _pageView.Text = @"Servicios Aduana ";
               _pageView.Image = RepServiciosAduanas.Image;
               _pageView.Tag = REP0081_Presenter.CUS;
               REP0081_LView.Dock = DockStyle.Fill;
               tabViews.Pages.Add(_pageView);
               REP0081_LView.CloseForm += View_CloseForm;
               REP0081_Presenter.TipoReporte = "Aduana";
               REP0081_Presenter.Load();
            }
            tabViews.SelectedPage = REP0081_LView.TabPageControl;
         }
         catch (Exception ex)
         {
            Dialogos.MostrarMensajeError(Text, "Ha ocurrido un error al llamar la vista: " + "Servicios Aduana", ex);
         }
      }

      #endregion

      #region [ Operaciones ]

      OPE001LView OPE001_lview;
      OPE001MView OPE001_mview;
      OPE001Presenter OPE001_presenter;

      private void OPE001OrdenVenta_Click(object sender, EventArgs e)
      {
         try
         {
            if (OPE001_lview == null)
            {
               RadPageViewPage _pageView = new RadPageViewPage();
               OPE001_lview = new OPE001LView(_pageView);
               OPE001_mview = new OPE001MView();
               OPE001_presenter = new OPE001Presenter(ContainerService, OPE001_lview, OPE001_mview);
               OPE001_lview.Presenter = OPE001_presenter;
               OPE001_lview.IconView = OPE001OrdenVenta.Image;
               OPE001_mview.Presenter = OPE001_presenter;
               _pageView.Image = OPE001OrdenVenta.Image;
               _pageView.BackColor = Color.LightSteelBlue;
               _pageView.Controls.Add(OPE001_lview);
               _pageView.Text = OPE001OrdenVenta.Text;
               _pageView.Tag = OPE001_presenter.CUS;
               OPE001_lview.Dock = DockStyle.Fill;
               tabViews.Pages.Add(_pageView);
               OPE001_lview.CloseForm += View_CloseForm;
               OPE001_presenter.Load();
            }
            tabViews.SelectedPage = OPE001_lview.TabPageControl;
         }
         catch (Exception ex)
         {
            Dialogos.MostrarMensajeError(Text, "Ha Ocurrido un error al llamar la vista: " + COM007Cotizacion.Text, ex);
         }
      }

      DOC002LView DOC002_lview;
      DOC002MView DOC002_mview;
      DOC002Presenter DOC002_presenter;

      private void DOC002ControlDocumentos_Click(object sender, EventArgs e)
      {
         try
         {
            if (DOC002_lview == null)
            {
               RadPageViewPage _pageView = new RadPageViewPage();
               DOC002_lview = new DOC002LView(_pageView);
               DOC002_mview = new DOC002MView();
               DOC002_presenter = new DOC002Presenter(ContainerService, DOC002_lview, DOC002_mview);
               DOC002_lview.Presenter = DOC002_presenter;
               DOC002_lview.IconView = DOC002ControlDocumentos.Image;
               DOC002_mview.Presenter = DOC002_presenter;
               _pageView.Image = DOC002ControlDocumentos.Image;
               _pageView.BackColor = Color.LightSteelBlue;
               _pageView.Controls.Add(DOC002_lview);
               _pageView.Text = DOC002ControlDocumentos.Text;
               _pageView.Tag = DOC002_presenter.CUS;
               DOC002_lview.Dock = DockStyle.Fill;
               tabViews.Pages.Add(_pageView);
               DOC002_lview.CloseForm += View_CloseForm;
               DOC002_presenter.Load();
            }
            tabViews.SelectedPage = DOC002_lview.TabPageControl;
         }
         catch (Exception ex)
         {
            Dialogos.MostrarMensajeError(Text, "Ha Ocurrido un error al llamar la vista: " + COM007Cotizacion.Text, ex);
         }
      }


      OPE002View OPE002MView;
      OPE002Presenter OPE002Presenter;
      private void OPE002_Click(object sender, EventArgs e)
      {
         try
         {
            if (OPE002MView == null)
            {
               OPE002MView = new OPE002View();
               OPE002Presenter = new OPE002Presenter(ContainerService, OPE002MView);
               OPE002MView.Presenter = OPE002Presenter;
               OPE002Presenter.Load();

               OPE002MView.FormClosed += MView_FormClosed;
            }
            OPE002MView.Show();
         }
         catch (Exception ex)
         {
            Dialogos.MostrarMensajeError(Text, "Ha Ocurrido un error al llamar la vista: " + OPE_R_001.Text, ex);
         }
      }

      OPE003View OPE003MView;
      OPE003Presenter OPE003Presenter;
      private void OPE003Gerencia_Click(object sender, EventArgs e)
      {
         try
         {
            if (OPE003MView == null)
            {
               OPE003MView = new OPE003View();
               OPE003Presenter = new OPE003Presenter(ContainerService, OPE003MView, "001");
               OPE003MView.Presenter = OPE003Presenter;
               OPE003Presenter.Load();

               OPE003MView.FormClosed += MView_FormClosed;
            }
            OPE003MView.Show();
            OPE003MView.Name = "OPE003View";
         }
         catch (Exception ex)
         {
            Dialogos.MostrarMensajeError(Text, "Ha Ocurrido un error al llamar la vista: " + COM007Cotizacion.Text, ex);
         }
      }

      OPE003View OPE003MView_EXPO;
      OPE003Presenter OPE003Presenter_EXPO;
      private void OPE003Gerencia_EXPO_Click(object sender, EventArgs e)
      {
         try
         {
            if (OPE003MView_EXPO == null)
            {
               OPE003MView_EXPO = new OPE003View();
               OPE003Presenter_EXPO = new OPE003Presenter(ContainerService, OPE003MView_EXPO, "002");
               OPE003MView_EXPO.Presenter = OPE003Presenter_EXPO;
               OPE003Presenter_EXPO.Load();

               OPE003MView_EXPO.FormClosed += MView_FormClosed;
            }
            OPE003MView_EXPO.Show();
            OPE003MView_EXPO.Name = "OPE003MView_EXPO";
         }
         catch (Exception ex)
         {
            Dialogos.MostrarMensajeError(Text, "Ha Ocurrido un error al llamar la vista: " + COM007Cotizacion.Text, ex);
         }
      }

      OPE004View OPE004MView;
      OPE004Presenter OPE004Presenter;
      private void OPE004Aduana_Click(object sender, EventArgs e)
      {
         try
         {
            if (OPE004MView == null)
            {
               OPE004MView = new OPE004View();
               OPE004Presenter = new OPE004Presenter(ContainerService, OPE004MView);
               OPE004MView.Presenter = OPE004Presenter;
               OPE004Presenter.Load();

               OPE004MView.FormClosed += MView_FormClosed;
            }
            OPE004MView.Show();
         }
         catch (Exception ex)
         {
            Dialogos.MostrarMensajeError(Text, "Ha Ocurrido un error al llamar la vista: " + COM007Cotizacion.Text, ex);
         }
      }

      OPE005LView OPE005LView;
      OPE005Presenter OPE005Presenter;
      private void OPE005ConsultaServicios_Click(object sender, EventArgs e)
      {
         try
         {
            if (OPE005LView == null)
            {
               RadPageViewPage _pageView = new RadPageViewPage();
               OPE005LView = new OPE005LView(_pageView);
               //COM004_mview = new COM004MView();
               OPE005Presenter = new OPE005Presenter(ContainerService, OPE005LView);
               OPE005LView.Presenter = OPE005Presenter;
               OPE005LView.IconView = OPE005ConsultaServicios.Image;
               //COM004_mview.Presenter = COM004_presenter;
               _pageView.Image = OPE005ConsultaServicios.Image;
               _pageView.BackColor = Color.LightSteelBlue;
               _pageView.Controls.Add(OPE005LView);
               _pageView.Text = OPE005ConsultaServicios.Text;
               _pageView.Tag = OPE005Presenter.CUS;
               OPE005LView.Dock = DockStyle.Fill;
               tabViews.Pages.Add(_pageView);
               OPE005LView.CloseForm += View_CloseForm;
               OPE005Presenter.Load();
            }
            tabViews.SelectedPage = OPE005LView.TabPageControl;
         }
         catch (Exception ex)
         {
            Dialogos.MostrarMensajeError(Text, "Ha Ocurrido un error al llamar la vista: " + COM004KPIContactados.Text, ex);
         }
      }

      OPE006LView OPE006LView;
      OPE006Presenter OPE006Presenter;
      private void OPE006ConsultaCorrelativos_Click(object sender, EventArgs e)
      {
         try
         {
            if (OPE006LView == null)
            {
               RadPageViewPage _pageView = new RadPageViewPage();
               OPE006LView = new OPE006LView(_pageView);
               //COM004_mview = new COM004MView();
               OPE006Presenter = new OPE006Presenter(ContainerService, OPE006LView);
               OPE006LView.Presenter = OPE006Presenter;
               OPE006LView.IconView = OPE006ConsultaCorrelativos.Image;
               //COM004_mview.Presenter = COM004_presenter;
               _pageView.Image = OPE006ConsultaCorrelativos.Image;
               _pageView.BackColor = Color.LightSteelBlue;
               _pageView.Controls.Add(OPE006LView);
               _pageView.Text = OPE006ConsultaCorrelativos.Text;
               _pageView.Tag = OPE006Presenter.CUS;
               OPE006LView.Dock = DockStyle.Fill;
               tabViews.Pages.Add(_pageView);
               OPE006LView.CloseForm += View_CloseForm;
               OPE006Presenter.Load();
            }
            tabViews.SelectedPage = OPE006LView.TabPageControl;
         }
         catch (Exception ex)
         {
            Dialogos.MostrarMensajeError(Text, "Ha Ocurrido un error al llamar la vista: " + OPE006ConsultaCorrelativos.Text, ex);
         }
      }

      OPE007LView OPE007LView;
      OPE007Presenter OPE007Presenter;
      private void OPE007ImportarFleteCosto_Click(object sender, EventArgs e)
      {
         try
         {
            if (OPE007LView == null)
            {
               RadPageViewPage _pageView = new RadPageViewPage();
               OPE007LView = new OPE007LView(_pageView);
               //COM004_mview = new COM004MView();
               OPE007Presenter = new OPE007Presenter(ContainerService, OPE007LView);
               OPE007LView.Presenter = OPE007Presenter;
               OPE007LView.IconView = OPE007ImportarFleteCosto.Image;
               //COM004_mview.Presenter = COM004_presenter;
               _pageView.Image = OPE007ImportarFleteCosto.Image;
               _pageView.BackColor = Color.LightSteelBlue;
               _pageView.Controls.Add(OPE007LView);
               _pageView.Text = OPE007ImportarFleteCosto.Text;
               _pageView.Tag = OPE007Presenter.CUS;
               OPE007LView.Dock = DockStyle.Fill;
               tabViews.Pages.Add(_pageView);
               OPE007LView.CloseForm += View_CloseForm;
               OPE007Presenter.Load();
            }
            tabViews.SelectedPage = OPE007LView.TabPageControl;
         }
         catch (Exception ex)
         {
            Dialogos.MostrarMensajeError(Text, "Ha Ocurrido un error al llamar la vista: " + OPE007ImportarFleteCosto.Text, ex);
         }
      }

      OPE008LView OPE008LView;
      OPE008Presenter OPE008Presenter;
      private void OPE008CierreChangeControl_Click(object sender, EventArgs e)
      {
         try
         {
            if (OPE008LView == null)
            {
               RadPageViewPage _pageView = new RadPageViewPage();
               OPE008LView = new OPE008LView(_pageView);
               OPE008Presenter = new OPE008Presenter(ContainerService, OPE008LView);
               OPE008LView.Presenter = OPE008Presenter;
               OPE008LView.IconView = OPE008CierreChangeControl.Image;
               _pageView.Image = OPE008CierreChangeControl.Image;
               _pageView.BackColor = Color.LightSteelBlue;
               _pageView.Controls.Add(OPE008LView);
               _pageView.Text = OPE008CierreChangeControl.Text;
               _pageView.Tag = OPE008Presenter.CUS;
               OPE008LView.Dock = DockStyle.Fill;
               tabViews.Pages.Add(_pageView);
               OPE008LView.CloseForm += View_CloseForm;
               OPE008Presenter.Load();
            }
            tabViews.SelectedPage = OPE008LView.TabPageControl;
         }
         catch (Exception ex)
         {
            Dialogos.MostrarMensajeError(Text, "Ha Ocurrido un error al llamar la vista: " + OPE008CierreChangeControl.Text, ex);
         }
      }

      OPE009View OPE009MView;
      OPE009Presenter OPE009Presenter;
      private void OPE009StatmentChangeControl_Click(object sender, EventArgs e)
      {
         try
         {
            if (OPE009MView == null)
            {
               OPE009MView = new OPE009View();
               OPE009Presenter = new OPE009Presenter(ContainerService, OPE009MView);
               OPE009MView.Presenter = OPE009Presenter;
               OPE009Presenter.Load();

               OPE009MView.FormClosed += MView_FormClosed;
            }
            OPE009MView.Show();
         }
         catch (Exception ex)
         {
            Dialogos.MostrarMensajeError(Text, "Ha Ocurrido un error al llamar la vista: " + OPE009StatmentChangeControl.Text, ex);
         }
      }

      OPE010View OPE010_mview;
      OPE010Presenter OPE010_presenter;
      private void OPE010CalcularRebate_Click(object sender, EventArgs e)
      {
         try
         {
            if (OPE010_mview == null)
            {
               OPE010_mview = new OPE010View();
               OPE010_presenter = new OPE010Presenter(ContainerService, OPE010_mview);
               OPE010_mview.Presenter = OPE010_presenter;
               OPE010_presenter.Load();

               OPE010_mview.FormClosed += MView_FormClosed;
            }
            OPE010_mview.Show();
         }
         catch (Exception ex)
         {
            Dialogos.MostrarMensajeError(Text, "Ha Ocurrido un error al llamar la vista: " + OPE010CalcularRebate.Text, ex);
         }
      }

      ApplicationForm.BreakdownForm OPE011_mview;

      private void OPE011Desglose_Click(object sender, EventArgs e)
      {
          try
          {
              if (OPE011_mview == null)
              {
                  OPE011_mview = new ApplicationForm.BreakdownForm();
                  OPE011_mview.AppUser = ItemUsuario.USUA_CodUsr;
                  OPE011_mview.TopLevel = false;
                  OPE011_mview.Dock = DockStyle.Fill;
                  OPE011_mview.FormBorderStyle = FormBorderStyle.None;
                  _pageView = new RadPageViewPage();
                  OPE011_mview.Parent = _pageView;
                  _pageView.Controls.Add(OPE011_mview);
                  _pageView.Text = OPE011_mview.Text;
                  _pageView.Tag = ((System.Windows.Forms.ToolStripItem)(sender)).Tag;
                  tabViews.Pages.Add(_pageView);
                  OPE011_mview.Show();
              }
              else
              { tabViews.SelectedPage = _pageView; }
          }
          catch (Exception ex)
          {
              Dialogos.MostrarMensajeError(Text, "Ha Ocurrido un error al llamar la vista: Desglose de BL", ex);
          }
          tabViews.SelectedPage = _pageView;
      }

        ApplicationForm.RoutingOrderServiceAssignForm OPE012_mview;

        private void OPE012AsignacionServicios_Click(object sender, EventArgs e)
        {
            try
            {
                if (OPE012_mview == null)
                {
                    OPE012_mview = new ApplicationForm.RoutingOrderServiceAssignForm();
                    OPE012_mview.AppUser = ItemUsuario.USUA_CodUsr;
                    OPE012_mview.TopLevel = false;
                    OPE012_mview.Dock = DockStyle.Fill;
                    OPE012_mview.FormBorderStyle = FormBorderStyle.None;
                    _pageView = new RadPageViewPage();
                    OPE012_mview.Parent = _pageView;
                    _pageView.Controls.Add(OPE012_mview);
                    _pageView.Text = OPE012_mview.Text;
                    _pageView.Tag = ((System.Windows.Forms.ToolStripItem)(sender)).Tag;
                    tabViews.Pages.Add(_pageView);
                    OPE012_mview.Show();
                }
                else
                { tabViews.SelectedPage = _pageView; }
            }
            catch (Exception ex)
            {
                Dialogos.MostrarMensajeError(Text, "Ha Ocurrido un error al llamar la vista: Asignación Masiva de Servicios", ex);
            }
            tabViews.SelectedPage = _pageView;
        }

        ApplicationForm.RelatedCompanyRequestForm COM014_mview;

        private void COM014EmpresaVinculada_Click(object sender, EventArgs e)
        {
            try
            {
                if (COM014_mview == null)
                {
                    COM014_mview = new ApplicationForm.RelatedCompanyRequestForm();
                    COM014_mview.AppUser = ItemUsuario.USUA_CodUsr;
                    COM014_mview.TopLevel = false;
                    COM014_mview.Dock = DockStyle.Fill;
                    COM014_mview.FormBorderStyle = FormBorderStyle.None;
                    _pageView = new RadPageViewPage();
                    COM014_mview.Parent = _pageView;
                    _pageView.Controls.Add(COM014_mview);
                    _pageView.Text = COM014_mview.Text;
                    _pageView.Tag = ((System.Windows.Forms.ToolStripItem)(sender)).Tag;
                    tabViews.Pages.Add(_pageView);
                    COM014_mview.Show();
                }
                else
                { tabViews.SelectedPage = _pageView; }
            }
            catch (Exception ex)
            {
                Dialogos.MostrarMensajeError(Text, "Ha Ocurrido un error al llamar la vista: Asignación Masiva de Servicios", ex);
            }
            tabViews.SelectedPage = _pageView;
        }

        ApplicationForm.CargoAddressingForm LOG009_mview;
       
      private void LOG009Direccionamiento_Click(object sender, EventArgs e)
      {
          try
          {
              if (LOG009_mview == null)
              {
                  LOG009_mview = new ApplicationForm.CargoAddressingForm();
                  LOG009_mview.AppUser = ItemUsuario.USUA_CodUsr;
                  LOG009_mview.TopLevel = false;
                  LOG009_mview.Dock = DockStyle.Fill;
                  LOG009_mview.FormBorderStyle = FormBorderStyle.None;
                  _pageView = new RadPageViewPage();
                  LOG009_mview.Parent = _pageView;
                  _pageView.Controls.Add(LOG009_mview);
                  _pageView.Text = LOG009_mview.Text;
                  _pageView.Tag = ((System.Windows.Forms.ToolStripItem)(sender)).Tag;
                  tabViews.Pages.Add(_pageView);
                  LOG009_mview.Show();
              }
              else
              { tabViews.SelectedPage = _pageView; }
          }
          catch (Exception ex)
          {
              Dialogos.MostrarMensajeError(Text, "Ha Ocurrido un error al llamar la vista: Direccionamiento de Carga", ex);
          }
          tabViews.SelectedPage = _pageView; 
      }

      ApplicationForm.DemurrageForm COM013_mview;

      private void COM013Sobrestadia_Click(object sender, EventArgs e)
      {
          try
          {
              if (COM013_mview == null)
              {
                  COM013_mview = new ApplicationForm.DemurrageForm();
                  COM013_mview.AppUser = ItemUsuario.USUA_CodUsr;
                  COM013_mview.TopLevel = false;
                  COM013_mview.Dock = DockStyle.Fill;
                  COM013_mview.FormBorderStyle = FormBorderStyle.None;
                  _pageView = new RadPageViewPage();
                  COM013_mview.Parent = _pageView;
                  _pageView.Controls.Add(COM013_mview);
                  _pageView.Text = COM013_mview.Text;
                  _pageView.Tag = ((System.Windows.Forms.ToolStripItem)(sender)).Tag;
                  tabViews.Pages.Add(_pageView);
                  COM013_mview.Show();
              }
              else
              { tabViews.SelectedPage = _pageView; }
          }
          catch (Exception ex)
          {
              Dialogos.MostrarMensajeError(Text, "Ha Ocurrido un error al llamar la vista: Sobrestadía", ex);
          }
          tabViews.SelectedPage = _pageView;
      }

      private void MView_FormClosed(object sender, FormClosedEventArgs e)
      {
         switch (((Form)sender).Name)
         {
             case "LogisticOperationQueryForm":
                 LOG006_mview = null;
                    break;
             case "CargoAddressingForm":
                 LOG009_mview = null;
                 break;
             case "DemurrageForm":
                 COM013_mview = null;
                 break;
            case "COM012MView":
               COM012_mview = null;
               COM012_presenter = null;
               break;
            case "OPE002View":
               OPE002MView = null;
               OPE002Presenter = null;
               break;
            case "OPE003View":
               OPE003MView = null;
               OPE003Presenter = null;
               break;
            case "OPE003MView_EXPO":
               OPE003MView_EXPO = null;
               OPE003Presenter_EXPO = null;
               break;
            case "OPE004View":
               OPE004MView = null;
               OPE004Presenter = null;
               break;

            case "REP014View":
               REP014_mview = null;
               REP014_presenter = null;
               break;

            case "OPE009View":
               OPE009MView = null;
               OPE009Presenter = null;
               break;

            case "OPE010View":
               OPE010_mview = null;
               OPE010_presenter = null;
               break;

            case "CAJ017View":
               CAJ017_mview = null;
               CAJ017_presenter = null;
               break;

         }
      }
      #endregion

      #region [ Finanzas ]

      CAJ001CuentasBancariasLView CAJ001_lview;
      CAJ001CuentasBancariasMView CAJ001_mview;
      CAJ001CuentasBancariasPresenter CAJ001_presenter;
      private void CAJ001CuentasBancarias_Click(object sender, EventArgs e)
      {
         try
         {
            if (CAJ001_lview == null)
            {
               RadPageViewPage _pageView = new RadPageViewPage();
               CAJ001_lview = new CAJ001CuentasBancariasLView(_pageView);
               CAJ001_mview = new CAJ001CuentasBancariasMView();
               CAJ001_presenter = new CAJ001CuentasBancariasPresenter(ContainerService, CAJ001_lview, CAJ001_mview);
               CAJ001_lview.Presenter = CAJ001_presenter;
               CAJ001_lview.IconView = CAJ001CuentasBancarias.Image;
               CAJ001_mview.Presenter = CAJ001_presenter;
               _pageView.Image = CAJ001CuentasBancarias.Image;
               _pageView.BackColor = Color.LightSteelBlue;
               _pageView.Controls.Add(CAJ001_lview);
               _pageView.Text = CAJ001CuentasBancarias.Text;
               _pageView.Tag = CAJ001_presenter.CUS;
               CAJ001_lview.Dock = DockStyle.Fill;
               tabViews.Pages.Add(_pageView);
               CAJ001_lview.CloseForm += View_CloseForm;
               CAJ001_presenter.Load();
            }
            tabViews.SelectedPage = CAJ001_lview.TabPageControl;
         }
         catch (Exception ex)
         {
            Dialogos.MostrarMensajeError(Text, "Ha Ocurrido un error al llamar la vista: " + CAJ001CuentasBancarias.Text, ex);
         }
      }

      CAJ002IngresosEgresosLView CAJ002_lview;
      CAJ002IngresosEgresosPresenter CAJ002_presenter;
      private void CAJ002Ingresos_Click(object sender, EventArgs e)
      {
         try
         {
            if (CAJ002_lview == null)
            {
               RadPageViewPage _pageView = new RadPageViewPage();
               CAJ002_lview = new CAJ002IngresosEgresosLView(_pageView);
               CAJ002_presenter = new CAJ002IngresosEgresosPresenter(ContainerService, CAJ002_lview, Infrastructure.Aspect.Constants.TipoMovimientoCtaCte.Ingresos);
               CAJ002_lview.Presenter = CAJ002_presenter;
               CAJ002_lview.IconView = CAJ002Ingresos.Image;
               _pageView.Image = CAJ002Ingresos.Image;
               _pageView.BackColor = Color.LightSteelBlue;
               _pageView.Controls.Add(CAJ002_lview);
               _pageView.Text = CAJ002Ingresos.Text;
               _pageView.Tag = CAJ002_presenter.CUS;
               CAJ002_lview.Dock = DockStyle.Fill;
               tabViews.Pages.Add(_pageView);
               CAJ002_lview.CloseForm += View_CloseForm;
               CAJ002_presenter.Load();
            }
            tabViews.SelectedPage = CAJ002_lview.TabPageControl;
         }
         catch (Exception ex)
         {
            Dialogos.MostrarMensajeError(Text, "Ha Ocurrido un error al llamar la vista: " + CAJ002Ingresos.Text, ex);
         }
      }

      CAJ002IngresosEgresosLView CAJ003_lview;
      CAJ002IngresosEgresosPresenter CAJ003_presenter;
      private void CAJ003Egresos_Click(object sender, EventArgs e)
      {
         try
         {
            if (CAJ003_lview == null)
            {
               RadPageViewPage _pageView = new RadPageViewPage();
               CAJ003_lview = new CAJ002IngresosEgresosLView(_pageView);
               CAJ003_presenter = new CAJ002IngresosEgresosPresenter(ContainerService, CAJ003_lview, Infrastructure.Aspect.Constants.TipoMovimientoCtaCte.Egresos);
               CAJ003_lview.Presenter = CAJ003_presenter;
               CAJ003_lview.IconView = CAJ003Egresos.Image;
               _pageView.Image = CAJ003Egresos.Image;
               _pageView.BackColor = Color.LightSteelBlue;
               _pageView.Controls.Add(CAJ003_lview);
               _pageView.Text = CAJ003Egresos.Text;
               _pageView.Tag = CAJ003_presenter.CUS;
               CAJ003_lview.Dock = DockStyle.Fill;
               tabViews.Pages.Add(_pageView);
               CAJ003_lview.CloseForm += View_CloseForm;
               CAJ003_presenter.Load();
            }
            tabViews.SelectedPage = CAJ003_lview.TabPageControl;
         }
         catch (Exception ex)
         {
            Dialogos.MostrarMensajeError(Text, "Ha Ocurrido un error al llamar la vista: " + CAJ003Egresos.Text, ex);
         }
      }

      CAJ004ChequesEnBlancoLView CAJ004_lview;
      CAJ004ChequesEnBlancoPresenter CAJ004_presenter;
      private void CAJ004ChequesEnBlanco_Click(object sender, EventArgs e)
      {
         try
         {
            if (CAJ004_lview == null)
            {
               RadPageViewPage _pageView = new RadPageViewPage();
               CAJ004_lview = new CAJ004ChequesEnBlancoLView(_pageView);
               CAJ004_presenter = new CAJ004ChequesEnBlancoPresenter(ContainerService, CAJ004_lview);
               CAJ004_lview.Presenter = CAJ004_presenter;
               CAJ004_lview.IconView = CAJ004ChequesEnBlanco.Image;
               _pageView.Image = CAJ004ChequesEnBlanco.Image;
               _pageView.BackColor = Color.LightSteelBlue;
               _pageView.Controls.Add(CAJ004_lview);
               _pageView.Text = CAJ004ChequesEnBlanco.Text;
               _pageView.Tag = CAJ004_presenter.CUS;
               CAJ004_lview.Dock = DockStyle.Fill;
               tabViews.Pages.Add(_pageView);
               CAJ004_lview.CloseForm += View_CloseForm;
               CAJ004_presenter.Load();
            }
            tabViews.SelectedPage = CAJ004_lview.TabPageControl;
         }
         catch (Exception ex)
         {
            Dialogos.MostrarMensajeError(Text, "Ha Ocurrido un error al llamar la vista: " + CAJ004ChequesEnBlanco.Text, ex);
         }
      }

      CAJ005TransferenciasLView CAJ005_lview;
      CAJ005TransferenciasPresenter CAJ005_presenter;
      private void CAJ005Transferencias_Click(object sender, EventArgs e)
      {
         try
         {
            if (CAJ005_lview == null)
            {
               RadPageViewPage _pageView = new RadPageViewPage();
               CAJ005_lview = new CAJ005TransferenciasLView(_pageView);
               CAJ005_presenter = new CAJ005TransferenciasPresenter(ContainerService, CAJ005_lview);
               CAJ005_lview.Presenter = CAJ005_presenter;
               CAJ005_lview.IconView = CAJ005Transferencias.Image;
               _pageView.Image = CAJ005Transferencias.Image;
               _pageView.BackColor = Color.LightSteelBlue;
               _pageView.Controls.Add(CAJ005_lview);
               _pageView.Text = CAJ005Transferencias.Text;
               _pageView.Tag = CAJ005_presenter.CUS;
               CAJ005_lview.Dock = DockStyle.Fill;
               tabViews.Pages.Add(_pageView);
               CAJ005_lview.CloseForm += View_CloseForm;
               CAJ005_presenter.Load();
            }
            tabViews.SelectedPage = CAJ005_lview.TabPageControl;
         }
         catch (Exception ex)
         {
            Dialogos.MostrarMensajeError(Text, "Ha Ocurrido un error al llamar la vista: " + CAJ005Transferencias.Text, ex);
         }
      }

      CAJ006LiquidacionAgentesLView CAJ006_lview;
      CAJ006LiquidacionAgentesPresenter CAJ006_presenter;
      private void CAJ006LiquidacionAgentes_Click(object sender, EventArgs e)
      {
         try
         {
            if (CAJ006_lview == null)
            {
               RadPageViewPage _pageView = new RadPageViewPage();
               CAJ006_lview = new CAJ006LiquidacionAgentesLView(_pageView);
               CAJ006_presenter = new CAJ006LiquidacionAgentesPresenter(ContainerService, CAJ006_lview);
               CAJ006_lview.Presenter = CAJ006_presenter;
               CAJ006_lview.IconView = CAJ006LiquidacionAgentes.Image;
               _pageView.Image = CAJ006LiquidacionAgentes.Image;
               _pageView.BackColor = Color.LightSteelBlue;
               _pageView.Controls.Add(CAJ006_lview);
               _pageView.Text = CAJ006LiquidacionAgentes.Text;
               _pageView.Tag = CAJ006_presenter.CUS;
               CAJ006_lview.Dock = DockStyle.Fill;
               tabViews.Pages.Add(_pageView);
               CAJ006_lview.CloseForm += View_CloseForm;
               CAJ006_presenter.Load();
            }
            tabViews.SelectedPage = CAJ006_lview.TabPageControl;
         }
         catch (Exception ex)
         {
            Dialogos.MostrarMensajeError(Text, "Ha Ocurrido un error al llamar la vista: " + CAJ006LiquidacionAgentes.Text, ex);
         }
      }

      CAJ007ExportacionBancosLView CAJ007_lview;
      CAJ007ExportacionBancosPresenter CAJ007_presenter;
      private void CAJ007ExportacionBancos_Click(object sender, EventArgs e)
      {
         try
         {
            if (CAJ007_lview == null)
            {
               RadPageViewPage _pageView = new RadPageViewPage();
               CAJ007_lview = new CAJ007ExportacionBancosLView(_pageView);
               CAJ007_presenter = new CAJ007ExportacionBancosPresenter(ContainerService, CAJ007_lview, Entities.Planillas.TipoPlanilla.MedioVirtual);
               CAJ007_lview.Presenter = CAJ007_presenter;
               CAJ007_lview.IconView = CAJ007ExportacionBancos.Image;
               _pageView.Image = CAJ007ExportacionBancos.Image;
               _pageView.BackColor = Color.LightSteelBlue;
               _pageView.Controls.Add(CAJ007_lview);
               _pageView.Text = CAJ007ExportacionBancos.Text;
               _pageView.Tag = CAJ007_presenter.CUS;
               CAJ007_lview.Dock = DockStyle.Fill;
               tabViews.Pages.Add(_pageView);
               CAJ007_lview.CloseForm += View_CloseForm;
               CAJ007_presenter.Load();
            }
            tabViews.SelectedPage = CAJ007_lview.TabPageControl;
         }
         catch (Exception ex)
         {
            Dialogos.MostrarMensajeError(Text, "Ha Ocurrido un error al llamar la vista: " + CAJ007ExportacionBancos.Text, ex);
         }
      }

      CAJ007ExportacionBancosLView CAJ008_lview;
      CAJ007ExportacionBancosPresenter CAJ008_presenter;
      private void CAJ008ExportarDetracciones_Click(object sender, EventArgs e)
      {
         try
         {
            if (CAJ008_lview == null)
            {
               RadPageViewPage _pageView = new RadPageViewPage();
               CAJ008_lview = new CAJ007ExportacionBancosLView(_pageView);
               CAJ008_presenter = new CAJ007ExportacionBancosPresenter(ContainerService, CAJ008_lview, Entities.Planillas.TipoPlanilla.Detracciones);
               CAJ008_lview.Presenter = CAJ008_presenter;
               CAJ008_lview.IconView = CAJ008ExportarDetracciones.Image;
               _pageView.Image = CAJ008ExportarDetracciones.Image;
               _pageView.BackColor = Color.LightSteelBlue;
               _pageView.Controls.Add(CAJ008_lview);
               _pageView.Text = CAJ008ExportarDetracciones.Text;
               _pageView.Tag = CAJ008_presenter.CUS;
               CAJ008_lview.Dock = DockStyle.Fill;
               tabViews.Pages.Add(_pageView);
               CAJ008_lview.CloseForm += View_CloseForm;
               CAJ008_presenter.Load();
            }
            tabViews.SelectedPage = CAJ008_lview.TabPageControl;
         }
         catch (Exception ex)
         {
            Dialogos.MostrarMensajeError(Text, "Ha Ocurrido un error al llamar la vista: " + CAJ008ExportarDetracciones.Text, ex);
         }
      }

      CAJ010ConciliacionLView CAJ010_lview;
      CAJ010ConciliacionPresenter CAJ010_presenter;
      private void CAJ010Conciliacion_Click(object sender, EventArgs e)
      {
         try
         {
            if (CAJ010_lview == null)
            {
               RadPageViewPage _pageView = new RadPageViewPage();
               CAJ010_lview = new CAJ010ConciliacionLView(_pageView);
               CAJ010_presenter = new CAJ010ConciliacionPresenter(ContainerService, CAJ010_lview);
               CAJ010_lview.Presenter = CAJ010_presenter;
               CAJ010_lview.IconView = CAJ010Conciliacion.Image;
               _pageView.Image = CAJ010Conciliacion.Image;
               _pageView.BackColor = Color.LightSteelBlue;
               _pageView.Controls.Add(CAJ010_lview);
               _pageView.Text = CAJ010Conciliacion.Text;
               _pageView.Tag = CAJ010_presenter.CUS;
               CAJ010_lview.Dock = DockStyle.Fill;
               tabViews.Pages.Add(_pageView);
               CAJ010_lview.CloseForm += View_CloseForm;
               CAJ010_presenter.Load();
            }
            tabViews.SelectedPage = CAJ010_lview.TabPageControl;
         }
         catch (Exception ex)
         {
            Dialogos.MostrarMensajeError(Text, "Ha Ocurrido un error al llamar la vista: " + CAJ010Conciliacion.Text, ex);
         }
      }

      CAJ011AnularDocBancosLView CAJ011_lview;
      CAJ011AnularDocBancosPresenter CAJ011_presenter;
      private void CAJ011AnularDocBancos_Click(object sender, EventArgs e)
      {
         try
         {
            if (CAJ011_lview == null)
            {
               RadPageViewPage _pageView = new RadPageViewPage();
               CAJ011_lview = new CAJ011AnularDocBancosLView(_pageView);
               CAJ011_presenter = new CAJ011AnularDocBancosPresenter(ContainerService, CAJ011_lview);
               CAJ011_lview.Presenter = CAJ011_presenter;
               CAJ011_lview.IconView = CAJ011AnularDocBancos.Image;
               _pageView.Image = CAJ011AnularDocBancos.Image;
               _pageView.BackColor = Color.LightSteelBlue;
               _pageView.Controls.Add(CAJ011_lview);
               _pageView.Text = CAJ011AnularDocBancos.Text;
               _pageView.Tag = CAJ011_presenter.CUS;
               CAJ011_lview.Dock = DockStyle.Fill;
               tabViews.Pages.Add(_pageView);
               CAJ011_lview.CloseForm += View_CloseForm;
               CAJ011_presenter.Load();
            }
            tabViews.SelectedPage = CAJ011_lview.TabPageControl;
         }
         catch (Exception ex)
         {
            Dialogos.MostrarMensajeError(Text, "Ha Ocurrido un error al llamar la vista: " + CAJ011AnularDocBancos.Text, ex);
         }
      }

      CAJ012IngresoLibreLView CAJ012_lview;
      CAJ012IngresoLibrePresenter CAJ012_presenter;
      private void CAJ012IngresoLibre_Click(object sender, EventArgs e)
      {
         try
         {
            if (CAJ012_lview == null)
            {
               RadPageViewPage _pageView = new RadPageViewPage();
               CAJ012_lview = new CAJ012IngresoLibreLView(_pageView);
               CAJ012_presenter = new CAJ012IngresoLibrePresenter(ContainerService, CAJ012_lview);
               CAJ012_lview.Presenter = CAJ012_presenter;
               CAJ012_lview.IconView = CAJ012IngresoLibre.Image;
               _pageView.Image = CAJ012IngresoLibre.Image;
               _pageView.BackColor = Color.LightSteelBlue;
               _pageView.Controls.Add(CAJ012_lview);
               _pageView.Text = CAJ012IngresoLibre.Text;
               _pageView.Tag = CAJ012_presenter.CUS;
               CAJ012_lview.Dock = DockStyle.Fill;
               tabViews.Pages.Add(_pageView);
               CAJ012_lview.CloseForm += View_CloseForm;
               CAJ012_presenter.Load();
            }
            tabViews.SelectedPage = CAJ012_lview.TabPageControl;
         }
         catch (Exception ex)
         {
            Dialogos.MostrarMensajeError(Text, "Ha Ocurrido un error al llamar la vista: " + CAJ012IngresoLibre.Text, ex);
         }
      }

      CAJ013RespuestaDetraccionLView CAJ013_lview;
      CAJ013RespuestaDetraccionPresenter CAJ013_presenter;
      private void CAJ013RespuestaDetraccion_Click(object sender, EventArgs e)
      {
         try
         {
            if (CAJ013_lview == null)
            {
               RadPageViewPage _pageView = new RadPageViewPage();
               CAJ013_lview = new CAJ013RespuestaDetraccionLView(_pageView);
               CAJ013_presenter = new CAJ013RespuestaDetraccionPresenter(ContainerService, CAJ013_lview);
               CAJ013_lview.Presenter = CAJ013_presenter;
               CAJ013_lview.IconView = CAJ013RespuestaDetraccion.Image;
               _pageView.Image = CAJ013RespuestaDetraccion.Image;
               _pageView.BackColor = Color.LightSteelBlue;
               _pageView.Controls.Add(CAJ013_lview);
               _pageView.Text = CAJ013RespuestaDetraccion.Text;
               _pageView.Tag = CAJ013_presenter.CUS;
               CAJ013_lview.Dock = DockStyle.Fill;
               tabViews.Pages.Add(_pageView);
               CAJ013_lview.CloseForm += View_CloseForm;
               CAJ013_presenter.Load();
            }
            tabViews.SelectedPage = CAJ013_lview.TabPageControl;
         }
         catch (Exception ex)
         {
            Dialogos.MostrarMensajeError(Text, "Ha Ocurrido un error al llamar la vista: " + CAJ013RespuestaDetraccion.Text, ex);
         }
      }

      CAJ014PlantillaAsientosLView CAJ014_lview;
      CAJ014PlantillaAsientosPresenter CAJ014_presenter;
      private void CAJ014PlantillaAsientos_Click(object sender, EventArgs e)
      {
         try
         {
            if (CAJ014_lview == null)
            {
               RadPageViewPage _pageView = new RadPageViewPage();
               CAJ014_lview = new CAJ014PlantillaAsientosLView(_pageView);
               CAJ014_presenter = new CAJ014PlantillaAsientosPresenter(ContainerService, CAJ014_lview);
               CAJ014_lview.Presenter = CAJ014_presenter;
               CAJ014_lview.IconView = CAJ014PlantillaAsientos.Image;
               _pageView.Image = CAJ014PlantillaAsientos.Image;
               _pageView.BackColor = Color.LightSteelBlue;
               _pageView.Controls.Add(CAJ014_lview);
               _pageView.Text = CAJ014PlantillaAsientos.Text;
               _pageView.Tag = CAJ014_presenter.CUS;
               CAJ014_lview.Dock = DockStyle.Fill;
               tabViews.Pages.Add(_pageView);
               CAJ014_lview.CloseForm += View_CloseForm;
               CAJ014_presenter.Load();
            }
            tabViews.SelectedPage = CAJ014_lview.TabPageControl;
         }
         catch (Exception ex)
         {
            Dialogos.MostrarMensajeError(Text, "Ha Ocurrido un error al llamar la vista: " + CAJ014PlantillaAsientos.Text, ex);
         }
      }

      CAJ015AsientosContablesLView CAJ015_lview;
      CAJ015AsientosContablesPresenter CAJ015_presenter;
      private void CAJ015AsientosContables_Click(object sender, EventArgs e)
      {
         try
         {
            //if (CAJ015_lview == null)
            //{
            //   RadPageViewPage _pageView = new RadPageViewPage();
            //   CAJ015_lview = new CAJ015AsientosContablesLView(_pageView);
            //   CAJ015_presenter = new CAJ015AsientosContablesPresenter(ContainerService, CAJ015_lview);
            //   CAJ015_lview.Presenter = CAJ015_presenter;
            //   CAJ015_lview.IconView = CAJ015AsientosContables.Image;
            //   _pageView.Image = CAJ015AsientosContables.Image;
            //   _pageView.BackColor = Color.LightSteelBlue;
            //   _pageView.Controls.Add(CAJ015_lview);
            //   _pageView.Text = CAJ015AsientosContables.Text;
            //   CAJ015_lview.Dock = DockStyle.Fill;
            //   tabViews.Pages.Add(_pageView);
            //   CAJ015_lview.CloseForm += View_CloseForm;
            //   CAJ015_presenter.Load();
            //}
            //tabViews.SelectedPage = CAJ015_lview.TabPageControl;
         }
         catch (Exception ex)
         {
            Dialogos.MostrarMensajeError(Text, "Ha Ocurrido un error al llamar la vista: " + CAJ015AsientosContables.Text, ex);
         }
      }

      CAJ018AsientosStatementLView CAJ018_lview;
      CAJ018AsientosStatementPresenter CAJ018_presenter;
      private void CAJ018AsientosStatement_Click(object sender, EventArgs e)
      {
         try
         {
            if (CAJ018_lview == null)
            {
               RadPageViewPage _pageView = new RadPageViewPage();
               CAJ018_lview = new CAJ018AsientosStatementLView(_pageView);
               CAJ018_presenter = new CAJ018AsientosStatementPresenter(ContainerService, CAJ018_lview);
               CAJ018_lview.Presenter = CAJ018_presenter;
               CAJ018_lview.IconView = CAJ018AsientosStatement.Image;
               _pageView.Image = CAJ018AsientosStatement.Image;
               _pageView.BackColor = Color.LightSteelBlue;
               _pageView.Controls.Add(CAJ018_lview);
               _pageView.Text = CAJ018AsientosStatement.Text;
               _pageView.Tag = CAJ018_presenter.CUS;
               CAJ018_lview.Dock = DockStyle.Fill;
               tabViews.Pages.Add(_pageView);
               CAJ018_lview.CloseForm += View_CloseForm;
               CAJ018_presenter.Load();
            }
            tabViews.SelectedPage = CAJ018_lview.TabPageControl;
         }
         catch (Exception ex)
         { Dialogos.MostrarMensajeError(Text, "Ha Ocurrido un error al llamar la vista: " + CAJ018AsientosStatement.Text, ex); }
      }

      CAJ017View CAJ017_mview;
      CAJ017Presenter CAJ017_presenter;
      private void CAJ017AvisosLlegada_Click(object sender, EventArgs e)
      {
         try
         {
            if (CAJ017_mview == null)
            {
               CAJ017_mview = new CAJ017View();
               CAJ017_presenter = new CAJ017Presenter(ContainerService, CAJ017_mview);
               CAJ017_mview.Presenter = CAJ017_presenter;
               CAJ017_presenter.Load();

               CAJ017_mview.FormClosed += MView_FormClosed;
            }
            CAJ017_mview.Show();
         }
         catch (Exception ex)
         {
            Dialogos.MostrarMensajeError(Text, "Ha Ocurrido un error al llamar la vista: " + CAJ017AvisosLlegada.Text, ex);
         }
      }

        ApplicationForm.AccountingTransferForm FIN001_mview;

        private void FIN001TransferenciaContable_Click(object sender, EventArgs e)
        {
            try
            {
                if (FIN001_mview == null)
                {
                    FIN001_mview = new ApplicationForm.AccountingTransferForm();
                    FIN001_mview.AppUser = ItemUsuario.USUA_CodUsr;
                    FIN001_mview.TopLevel = false;
                    FIN001_mview.Dock = DockStyle.Fill;
                    FIN001_mview.FormBorderStyle = FormBorderStyle.None;
                    _pageView = new RadPageViewPage();
                    FIN001_mview.Parent = _pageView;
                    _pageView.Controls.Add(FIN001_mview);
                    _pageView.Text = FIN001_mview.Text;
                    _pageView.Tag = ((System.Windows.Forms.ToolStripItem)(sender)).Tag;
                    tabViews.Pages.Add(_pageView);
                    FIN001_mview.Show();
                }
                else
                { tabViews.SelectedPage = _pageView; }
            }
            catch (Exception ex)
            {
                Dialogos.MostrarMensajeError(Text, "Ha Ocurrido un error al llamar la vista: Transferencia Contable", ex);
            }
            tabViews.SelectedPage = _pageView;
        }

        ApplicationForm.ElectronicInvoicingForm FIN002_mview;

        private void FIN002FacturacionElectronica_Click(object sender, EventArgs e)
        {
            try
            {
                if (FIN002_mview == null)
                {
                    FIN002_mview = new ApplicationForm.ElectronicInvoicingForm();
                    FIN002_mview.AppUser = ItemUsuario.USUA_CodUsr;
                    FIN002_mview.TopLevel = false;
                    FIN002_mview.Dock = DockStyle.Fill;
                    FIN002_mview.FormBorderStyle = FormBorderStyle.None;
                    _pageView = new RadPageViewPage();
                    FIN002_mview.Parent = _pageView;
                    _pageView.Controls.Add(FIN002_mview);
                    _pageView.Text = FIN002_mview.Text;
                    _pageView.Tag = ((System.Windows.Forms.ToolStripItem)(sender)).Tag;
                    tabViews.Pages.Add(_pageView);
                    FIN002_mview.Show();
                }
                else
                { tabViews.SelectedPage = _pageView; }
            }
            catch (Exception ex)
            {
                Dialogos.MostrarMensajeError(Text, "Ha Ocurrido un error al llamar la vista: Facturación Electrónica", ex);
            }
            tabViews.SelectedPage = _pageView;
        }

        #endregion

        #region [ Reportes - Finanzas ]

        REP001AuxiliarBancosLView REP001_FinanzasLview;
      REP001AuxiliarBancosPresenter REP001_FinanzasPresenter;
      private void REP001AuxiliarBancos_Click(object sender, EventArgs e)
      {
         try
         {
            if (REP001_FinanzasLview == null)
            {
               RadPageViewPage _pageView = new RadPageViewPage();
               REP001_FinanzasLview = new REP001AuxiliarBancosLView(_pageView);
               REP001_FinanzasPresenter = new REP001AuxiliarBancosPresenter(ContainerService, REP001_FinanzasLview);
               REP001_FinanzasLview.Presenter = REP001_FinanzasPresenter;
               REP001_FinanzasLview.IconView = REP001AuxiliarBancos.Image;
               _pageView.Image = REP001AuxiliarBancos.Image;
               _pageView.BackColor = Color.LightSteelBlue;
               _pageView.Controls.Add(REP001_FinanzasLview);
               _pageView.Text = REP001AuxiliarBancos.Text;
               _pageView.Tag = REP001_FinanzasPresenter.CUS;
               REP001_FinanzasLview.Dock = DockStyle.Fill;
               tabViews.Pages.Add(_pageView);
               REP001_FinanzasLview.CloseForm += View_CloseForm;
               REP001_FinanzasPresenter.Load();
            }
            tabViews.SelectedPage = REP001_FinanzasLview.TabPageControl;
         }
         catch (Exception ex)
         {
            Dialogos.MostrarMensajeError(Text, "Ha Ocurrido un error al llamar la vista: " + REP001AuxiliarBancos.Text, ex);
         }
      }

      REP002ChequesLView REP002_FinanzasLview;
      REP002ChequesPresenter REP002_FinanzasPresenter;
      private void REP002Cheques_Click(object sender, EventArgs e)
      {
         try
         {
            if (REP002_FinanzasLview == null)
            {
               RadPageViewPage _pageView = new RadPageViewPage();
               REP002_FinanzasLview = new REP002ChequesLView(_pageView);
               REP002_FinanzasPresenter = new REP002ChequesPresenter(ContainerService, REP002_FinanzasLview);
               REP002_FinanzasLview.Presenter = REP002_FinanzasPresenter;
               REP002_FinanzasLview.IconView = REP002Cheques.Image;
               _pageView.Image = REP002Cheques.Image;
               _pageView.BackColor = Color.LightSteelBlue;
               _pageView.Controls.Add(REP002_FinanzasLview);
               _pageView.Text = REP002Cheques.Text;
               _pageView.Tag = REP002_FinanzasPresenter.CUS;
               REP002_FinanzasLview.Dock = DockStyle.Fill;
               tabViews.Pages.Add(_pageView);
               REP002_FinanzasLview.CloseForm += View_CloseForm;
               REP002_FinanzasPresenter.Load();
            }
            tabViews.SelectedPage = REP002_FinanzasLview.TabPageControl;
         }
         catch (Exception ex)
         {
            Dialogos.MostrarMensajeError(Text, "Ha Ocurrido un error al llamar la vista: " + REP002Cheques.Text, ex);
         }
      }

      REP003PlanillaExportacionLView REP003_FinanzasLview;
      REP003PlanillaExportacionPresenter REP003_FinanzasPresenter;
      //private void REP003PlanillaExportacion_Click(object sender, EventArgs e)
      //{
      //   try
      //   {
      //      if (REP003_FinanzasLview == null)
      //      {
      //         RadPageViewPage _pageView = new RadPageViewPage();
      //         REP003_FinanzasLview = new REP003PlanillaExportacionLView(_pageView);
      //         REP003_FinanzasPresenter = new REP003PlanillaExportacionPresenter(ContainerService, REP003_FinanzasLview);
      //         REP003_FinanzasLview.Presenter = REP003_FinanzasPresenter;
      //         REP003_FinanzasLview.IconView = REP003PlanillaExportacion.Image;
      //         _pageView.Image = REP003PlanillaExportacion.Image;
      //         _pageView.BackColor = Color.LightSteelBlue;
      //         _pageView.Controls.Add(REP003_FinanzasLview);
      //         _pageView.Text = REP003PlanillaExportacion.Text;
      //         REP003_FinanzasLview.Dock = DockStyle.Fill;
      //         tabViews.Pages.Add(_pageView);
      //         REP003_FinanzasLview.CloseForm += View_CloseForm;
      //         REP003_FinanzasPresenter.Load();
      //      }
      //      tabViews.SelectedPage = REP003_FinanzasLview.TabPageControl;
      //   }
      //   catch (Exception ex)
      //   {
      //      Dialogos.MostrarMensajeError(Text, "Ha Ocurrido un error al llamar la vista: " + REP003PlanillaExportacion.Text, ex);
      //   }
      //}

      REP004DocRecepcionadosLView REP004_FinanzasLview;
      REP004DocRecepcionadosPresenter REP004_FinanzasPresenter;
      private void REP004DocRecepcionados_Click(object sender, EventArgs e)
      {
         try
         {
            if (REP004_FinanzasLview == null)
            {
               RadPageViewPage _pageView = new RadPageViewPage();
               REP004_FinanzasLview = new REP004DocRecepcionadosLView(_pageView);
               REP004_FinanzasPresenter = new REP004DocRecepcionadosPresenter(ContainerService, REP004_FinanzasLview, REP004DocRecepcionadosPresenter.TReporte.Todos);
               REP004_FinanzasLview.Presenter = REP004_FinanzasPresenter;
               REP004_FinanzasLview.IconView = REP004DocRecepcionado.Image;
               _pageView.Image = REP004DocRecepcionado.Image;
               _pageView.BackColor = Color.LightSteelBlue;
               _pageView.Controls.Add(REP004_FinanzasLview);
               _pageView.Text = REP004DocRecepcionado.Text;
               _pageView.Tag = REP004_FinanzasPresenter.CUS;
               REP004_FinanzasLview.SetTitleView(REP004DocRecepcionado.Text);
               REP004_FinanzasLview.Dock = DockStyle.Fill;
               tabViews.Pages.Add(_pageView);
               REP004_FinanzasLview.CloseForm += View_CloseForm;
               REP004_FinanzasPresenter.Load();
            }
            tabViews.SelectedPage = REP004_FinanzasLview.TabPageControl;
         }
         catch (Exception ex)
         {
            Dialogos.MostrarMensajeError(Text, "Ha Ocurrido un error al llamar la vista: " + REP004DocRecepcionado.Text, ex);
         }
      }
      REP004DocRecepcionadosLView REP004_FinanzasLview02;
      REP004DocRecepcionadosPresenter REP004_FinanzasPresenter02;
      private void REP004DocRecepcionadosAgente_Click(object sender, EventArgs e)
      {
         try
         {
            if (REP004_FinanzasLview02 == null)
            {
               RadPageViewPage _pageView = new RadPageViewPage();
               REP004_FinanzasLview02 = new REP004DocRecepcionadosLView(_pageView);
               REP004_FinanzasPresenter02 = new REP004DocRecepcionadosPresenter(ContainerService, REP004_FinanzasLview02, REP004DocRecepcionadosPresenter.TReporte.Agente);
               REP004_FinanzasLview02.Presenter = REP004_FinanzasPresenter02;
               REP004_FinanzasLview02.IconView = REP004DocRecepcionadosAgente.Image;
               _pageView.Image = REP004DocRecepcionadosAgente.Image;
               _pageView.BackColor = Color.LightSteelBlue;
               _pageView.Controls.Add(REP004_FinanzasLview02);
               _pageView.Text = REP004DocRecepcionadosAgente.Text;
               _pageView.Tag = REP004_FinanzasPresenter02.CUS;
               REP004_FinanzasLview02.SetTitleView(REP004DocRecepcionado.Text + " - " + REP004DocRecepcionadosAgente.Text);
               REP004_FinanzasLview02.Dock = DockStyle.Fill;
               tabViews.Pages.Add(_pageView);
               REP004_FinanzasLview02.CloseForm += View_CloseForm;
               REP004_FinanzasPresenter02.Load();
            }
            tabViews.SelectedPage = REP004_FinanzasLview02.TabPageControl;
         }
         catch (Exception ex)
         {
            Dialogos.MostrarMensajeError(Text, "Ha Ocurrido un error al llamar la vista: " + REP004DocRecepcionadosAgente.Text, ex);
         }
      }

      REP004DocRecepcionadosLView REP004_FinanzasLview03;
      REP004DocRecepcionadosPresenter REP004_FinanzasPresenter03;
      private void REP004DocRecepcionadosProveedor_Click(object sender, EventArgs e)
      {
         try
         {
            if (REP004_FinanzasLview03 == null)
            {
               RadPageViewPage _pageView = new RadPageViewPage();
               REP004_FinanzasLview03 = new REP004DocRecepcionadosLView(_pageView);
               REP004_FinanzasPresenter03 = new REP004DocRecepcionadosPresenter(ContainerService, REP004_FinanzasLview03, REP004DocRecepcionadosPresenter.TReporte.Proveedor);
               REP004_FinanzasLview03.Presenter = REP004_FinanzasPresenter03;
               REP004_FinanzasLview03.IconView = REP004DocRecepcionadosProveedor.Image;
               _pageView.Image = REP004DocRecepcionadosProveedor.Image;
               _pageView.BackColor = Color.LightSteelBlue;
               _pageView.Controls.Add(REP004_FinanzasLview03);
               _pageView.Text = REP004DocRecepcionadosProveedor.Text;
               _pageView.Tag = REP004_FinanzasPresenter03.CUS;
               REP004_FinanzasLview03.SetTitleView(REP004DocRecepcionado.Text + " - " + REP004DocRecepcionadosProveedor.Text);
               REP004_FinanzasLview03.Dock = DockStyle.Fill;
               tabViews.Pages.Add(_pageView);
               REP004_FinanzasLview03.CloseForm += View_CloseForm;
               REP004_FinanzasPresenter03.Load();
            }
            tabViews.SelectedPage = REP004_FinanzasLview03.TabPageControl;
         }
         catch (Exception ex)
         {
            Dialogos.MostrarMensajeError(Text, "Ha Ocurrido un error al llamar la vista: " + REP004DocRecepcionadosProveedor.Text, ex);
         }
      }
      REP004DocRecepcionadosLView REP004_FinanzasLview04;
      REP004DocRecepcionadosPresenter REP004_FinanzasPresenter04;
      private void REP004DocRecepcionadosTransportista_Click(object sender, EventArgs e)
      {
         try
         {
            if (REP004_FinanzasLview04 == null)
            {
               RadPageViewPage _pageView = new RadPageViewPage();
               REP004_FinanzasLview04 = new REP004DocRecepcionadosLView(_pageView);
               REP004_FinanzasPresenter04 = new REP004DocRecepcionadosPresenter(ContainerService, REP004_FinanzasLview04, REP004DocRecepcionadosPresenter.TReporte.Transportista);
               REP004_FinanzasLview04.Presenter = REP004_FinanzasPresenter04;
               REP004_FinanzasLview04.IconView = REP004DocRecepcionadosTransportista.Image;
               _pageView.Image = REP004DocRecepcionadosTransportista.Image;
               _pageView.BackColor = Color.LightSteelBlue;
               _pageView.Controls.Add(REP004_FinanzasLview04);
               _pageView.Text = REP004DocRecepcionadosTransportista.Text;
               _pageView.Tag = REP004_FinanzasPresenter04.CUS;
               REP004_FinanzasLview04.SetTitleView(REP004DocRecepcionado.Text + " - " + REP004DocRecepcionadosTransportista.Text);
               REP004_FinanzasLview04.Dock = DockStyle.Fill;
               tabViews.Pages.Add(_pageView);
               REP004_FinanzasLview04.CloseForm += View_CloseForm;
               REP004_FinanzasPresenter04.Load();
            }
            tabViews.SelectedPage = REP004_FinanzasLview04.TabPageControl;
         }
         catch (Exception ex)
         {
            Dialogos.MostrarMensajeError(Text, "Ha Ocurrido un error al llamar la vista: " + REP004DocRecepcionadosTransportista.Text, ex);
         }
      }


      //REP005DocumentosPendientesLView REP005_FinanzasLview;
      //REP005DocumentosPendientesPresenter REP005_FinanzasPresenter;
      //private void REP005DocumentosPendientes_Click(object sender, EventArgs e)
      //{
      //   try
      //   {
      //      if (REP005_FinanzasLview == null)
      //      {
      //         RadPageViewPage _pageView = new RadPageViewPage();
      //         REP005_FinanzasLview = new REP005DocumentosPendientesLView(_pageView);
      //         REP005_FinanzasPresenter = new REP005DocumentosPendientesPresenter(ContainerService, REP005_FinanzasLview);
      //         REP005_FinanzasLview.Presenter = REP005_FinanzasPresenter;
      //         REP005_FinanzasLview.IconView = REP005DocumentosPendientes.Image;
      //         _pageView.Image = REP005DocumentosPendientes.Image;
      //         _pageView.BackColor = Color.LightSteelBlue;
      //         _pageView.Controls.Add(REP005_FinanzasLview);
      //         _pageView.Text = REP005DocumentosPendientes.Text;
      //         REP005_FinanzasLview.Dock = DockStyle.Fill;
      //         tabViews.Pages.Add(_pageView);
      //         REP005_FinanzasLview.CloseForm += View_CloseForm;
      //         REP005_FinanzasPresenter.Load();
      //      }
      //      tabViews.SelectedPage = REP005_FinanzasLview.TabPageControl;
      //   }
      //   catch (Exception ex)
      //   {
      //      Dialogos.MostrarMensajeError(Text, "Ha Ocurrido un error al llamar la vista: " + REP005DocumentosPendientes.Text, ex);
      //   }
      //}

      //REP006DetraccionPendientesLView REP006_FinanzasLview;
      //REP006DetraccionPendientesPresenter REP006_FinanzasPresenter;
      //private void REP006DetraccionPendientes_Click(object sender, EventArgs e)
      //{
      //   try
      //   {
      //      if (REP006_FinanzasLview == null)
      //      {
      //         RadPageViewPage _pageView = new RadPageViewPage();
      //         REP006_FinanzasLview = new REP006DetraccionPendientesLView(_pageView);
      //         REP006_FinanzasPresenter = new REP006DetraccionPendientesPresenter(ContainerService, REP006_FinanzasLview);
      //         REP006_FinanzasLview.Presenter = REP006_FinanzasPresenter;
      //         REP006_FinanzasLview.IconView = REP006DetraccionPendientes.Image;
      //         _pageView.Image = REP006DetraccionPendientes.Image;
      //         _pageView.BackColor = Color.LightSteelBlue;
      //         _pageView.Controls.Add(REP006_FinanzasLview);
      //         _pageView.Text = REP006DetraccionPendientes.Text;
      //         REP006_FinanzasLview.Dock = DockStyle.Fill;
      //         tabViews.Pages.Add(_pageView);
      //         REP006_FinanzasLview.CloseForm += View_CloseForm;
      //         REP006_FinanzasPresenter.Load();
      //      }
      //      tabViews.SelectedPage = REP006_FinanzasLview.TabPageControl;
      //   }
      //   catch (Exception ex)
      //   {
      //      Dialogos.MostrarMensajeError(Text, "Ha Ocurrido un error al llamar la vista: " + REP006DetraccionPendientes.Text, ex);
      //   }
      //}

      REP007AntiguedadDeudaLView REP007_FinanzasLview;
      REP007AntiguedadDeudaPresenter REP007_FinanzasPresenter;
      private void REP007AntiguedadDeuda_Click(object sender, EventArgs e)
      {
         try
         {
            if (REP007_FinanzasLview == null)
            {
               RadPageViewPage _pageView = new RadPageViewPage();
               REP007_FinanzasLview = new REP007AntiguedadDeudaLView(_pageView);
               REP007_FinanzasPresenter = new REP007AntiguedadDeudaPresenter(ContainerService, REP007_FinanzasLview);
               REP007_FinanzasLview.Presenter = REP007_FinanzasPresenter;
               REP007_FinanzasLview.IconView = REP007AntiguedadDeuda.Image;
               _pageView.Image = REP007AntiguedadDeuda.Image;
               _pageView.BackColor = Color.LightSteelBlue;
               _pageView.Controls.Add(REP007_FinanzasLview);
               _pageView.Text = REP007AntiguedadDeuda.Text;
               _pageView.Tag = REP007_FinanzasPresenter.CUS;
               REP007_FinanzasLview.Dock = DockStyle.Fill;
               tabViews.Pages.Add(_pageView);
               REP007_FinanzasLview.CloseForm += View_CloseForm;
               REP007_FinanzasPresenter.Load();
            }
            tabViews.SelectedPage = REP007_FinanzasLview.TabPageControl;
         }
         catch (Exception ex)
         {
            Dialogos.MostrarMensajeError(Text, "Ha Ocurrido un error al llamar la vista: " + REP007AntiguedadDeuda.Text, ex);
         }
      }

      REP008EstadoClienteLView REP008_FinanzasLview;
      REP008EstadoClientePresenter REP008_FinanzasPresenter;
      private void REP008EstadoCliente_Click(object sender, EventArgs e)
      {
         try
         {
            if (REP008_FinanzasLview == null)
            {
               RadPageViewPage _pageView = new RadPageViewPage();
               REP008_FinanzasLview = new REP008EstadoClienteLView(_pageView);
               REP008_FinanzasPresenter = new REP008EstadoClientePresenter(ContainerService, REP008_FinanzasLview);
               REP008_FinanzasLview.Presenter = REP008_FinanzasPresenter;
               REP008_FinanzasLview.IconView = REP008EstadoCliente.Image;
               _pageView.Image = REP008EstadoCliente.Image;
               _pageView.BackColor = Color.LightSteelBlue;
               _pageView.Controls.Add(REP008_FinanzasLview);
               _pageView.Text = REP008EstadoCliente.Text;
               _pageView.Tag = REP008_FinanzasPresenter.CUS;
               REP008_FinanzasLview.Dock = DockStyle.Fill;
               tabViews.Pages.Add(_pageView);
               REP008_FinanzasLview.CloseForm += View_CloseForm;
               REP008_FinanzasPresenter.Load();
            }
            tabViews.SelectedPage = REP008_FinanzasLview.TabPageControl;
         }
         catch (Exception ex)
         {
            Dialogos.MostrarMensajeError(Text, "Ha Ocurrido un error al llamar la vista: " + REP008EstadoCliente.Text, ex);
         }
      }
      REP009FlujoCajaLView REP009_FinanzasLview;
      REP009FlujoCajaPresenter REP009_FinanzasPresenter;
      private void REP009FlujoCaja_Click(object sender, EventArgs e)
      {
         try
         {
            if (REP009_FinanzasLview == null)
            {
               RadPageViewPage _pageView = new RadPageViewPage();
               REP009_FinanzasLview = new REP009FlujoCajaLView(_pageView);
               REP009_FinanzasPresenter = new REP009FlujoCajaPresenter(ContainerService, REP009_FinanzasLview);
               REP009_FinanzasLview.Presenter = REP009_FinanzasPresenter;
               REP009_FinanzasLview.IconView = REP009FlujoCaja.Image;
               _pageView.Image = REP009FlujoCaja.Image;
               _pageView.BackColor = Color.LightSteelBlue;
               _pageView.Controls.Add(REP009_FinanzasLview);
               _pageView.Text = REP009FlujoCaja.Text;
               _pageView.Tag = REP009_FinanzasPresenter.CUS;
               REP009_FinanzasLview.Dock = DockStyle.Fill;
               tabViews.Pages.Add(_pageView);
               REP009_FinanzasLview.CloseForm += View_CloseForm;
               REP009_FinanzasPresenter.Load();
            }
            tabViews.SelectedPage = REP009_FinanzasLview.TabPageControl;
         }
         catch (Exception ex)
         {
            Dialogos.MostrarMensajeError(Text, "Ha Ocurrido un error al llamar la vista: " + REP009FlujoCaja.Text, ex);
         }
      }

      REP015StatusComprobantesLView REP015_FinanzasLview;
      REP015StatusComprobantesPresenter REP015_FinanzasPresenter;
      private void REP015StatusComprobantes_Click(object sender, EventArgs e)
      {
         try
         {
            if (REP015_FinanzasLview == null)
            {
               RadPageViewPage _pageView = new RadPageViewPage();
               REP015_FinanzasLview = new REP015StatusComprobantesLView(_pageView);
               REP015_FinanzasPresenter = new REP015StatusComprobantesPresenter(ContainerService, REP015_FinanzasLview);
               REP015_FinanzasLview.Presenter = REP015_FinanzasPresenter;
               REP015_FinanzasLview.IconView = REP015StatusComprobantes.Image;
               _pageView.Image = REP015StatusComprobantes.Image;
               _pageView.BackColor = Color.LightSteelBlue;
               _pageView.Controls.Add(REP015_FinanzasLview);
               _pageView.Text = REP015StatusComprobantes.Text;
               _pageView.Tag = REP015_FinanzasPresenter.CUS;
               REP015_FinanzasLview.Dock = DockStyle.Fill;
               tabViews.Pages.Add(_pageView);
               REP015_FinanzasLview.CloseForm += View_CloseForm;
               REP015_FinanzasPresenter.Load();
            }
            tabViews.SelectedPage = REP015_FinanzasLview.TabPageControl;
         }
         catch (Exception ex)
         {
            Dialogos.MostrarMensajeError(Text, "Ha Ocurrido un error al llamar la vista: " + REP009FlujoCaja.Text, ex);
         }
      }

      REP010DocumentosContabilizadosLView REP010_FinanzasLview;
      REP010DocumentosContabilizadosPresenter REP010_FinanzasPresenter;
      private void REP010DocumentosContabilizados_Click(object sender, EventArgs e)
      {
         try
         {
            if (REP010_FinanzasLview == null)
            {
               RadPageViewPage _pageView = new RadPageViewPage();
               REP010_FinanzasLview = new REP010DocumentosContabilizadosLView(_pageView);
               REP010_FinanzasPresenter = new REP010DocumentosContabilizadosPresenter(ContainerService, REP010_FinanzasLview);
               REP010_FinanzasLview.Presenter = REP010_FinanzasPresenter;
               REP010_FinanzasLview.IconView = REP010DocumentosContabilizados.Image;
               _pageView.Image = REP010DocumentosContabilizados.Image;
               _pageView.BackColor = Color.LightSteelBlue;
               _pageView.Controls.Add(REP010_FinanzasLview);
               _pageView.Text = REP010DocumentosContabilizados.Text;
               _pageView.Tag = REP010_FinanzasPresenter.CUS;
               REP010_FinanzasLview.Dock = DockStyle.Fill;
               tabViews.Pages.Add(_pageView);
               REP010_FinanzasLview.CloseForm += View_CloseForm;
               REP010_FinanzasPresenter.Load();
            }
            tabViews.SelectedPage = REP010_FinanzasLview.TabPageControl;
         }
         catch (Exception ex)
         {
            Dialogos.MostrarMensajeError(Text, "Ha Ocurrido un error al llamar la vista: " + REP009FlujoCaja.Text, ex);
         }
      }

        #endregion

        #region [ Servicio Logistico ]

        ApplicationForm.LogisticOperationQueryForm LOG006_mview;

        private void LOG006Operaciones_Click(object sender, EventArgs e)
        {
            try
            {
                if (LOG006_mview == null)
                {
                    LOG006_mview = new ApplicationForm.LogisticOperationQueryForm();
                    LOG006_mview.AppUser = ItemUsuario.USUA_CodUsr;
                    LOG006_mview.TopLevel = false;
                    LOG006_mview.Dock = DockStyle.Fill;
                    LOG006_mview.FormBorderStyle = FormBorderStyle.None;
                    _pageView = new RadPageViewPage();
                    LOG006_mview.Parent = _pageView;
                    _pageView.Controls.Add(LOG006_mview);
                    _pageView.Text = LOG006_mview.Text;
                    _pageView.Tag = ((System.Windows.Forms.ToolStripItem)(sender)).Tag;
                    tabViews.Pages.Add(_pageView);
                    LOG006_mview.Show();
                }
                else
                { tabViews.SelectedPage = _pageView; }
            }
            catch (Exception ex)
            {
                Dialogos.MostrarMensajeError(Text, "Ha Ocurrido un error al llamar la vista: Direccionamiento de Carga", ex);
            }
            tabViews.SelectedPage = _pageView;
        }


        //ApplicationForm.CargoAddressingForm LOG0091_mview;

        private void LOG009Direccionamiento1_Click(object sender, EventArgs e)
        {
            try
            {
                if (LOG009_mview == null)
                {
                    LOG009_mview = new ApplicationForm.CargoAddressingForm();
                    LOG009_mview.AppUser = ItemUsuario.USUA_CodUsr;
                    LOG009_mview.TopLevel = false;
                    LOG009_mview.Dock = DockStyle.Fill;
                    LOG009_mview.FormBorderStyle = FormBorderStyle.None;
                    _pageView = new RadPageViewPage();
                    LOG009_mview.Parent = _pageView;
                    _pageView.Controls.Add(LOG009_mview);
                    _pageView.Text = LOG009_mview.Text;
                    _pageView.Tag = ((System.Windows.Forms.ToolStripItem)(sender)).Tag;
                    tabViews.Pages.Add(_pageView);
                    LOG009_mview.Show();
                }
                else
                { tabViews.SelectedPage = _pageView; }
            }
            catch (Exception ex)
            {
                Dialogos.MostrarMensajeError(Text, "Ha Ocurrido un error al llamar la vista: Direccionamiento de Carga", ex);
            }
            tabViews.SelectedPage = _pageView;
        }
        #endregion

        #region [ Tarifario ]

        #endregion

        private void tabViews_PageRemoving(object sender, RadPageViewCancelEventArgs e)
      {
          FormPageClosed(e.Page.Tag.ToString());
      }

      private void FormPageClosed(string FormName)
      {
          switch (FormName)
          {
                case "FIN001":
                    FIN001_mview = null;
                    break;
                case "FIN002":
                    FIN002_mview = null;
                    break;
                case "OPE011":
                  OPE011_mview = null;
                  break;
                case "OPE012":
                    OPE012_mview = null;
                    break;
                case "LOG006":
                    LOG006_mview = null;
                    break;
                case "LOG009":
                  LOG009_mview = null;
                  break;
              case "COM013":
                  COM013_mview = null;
                  break;
                case "COM014":
                    COM014_mview = null;
                    break;
                case "MAN000":
                  MAN000_lview = null;
                  MAN000_mview = null;
                  MAN000_presenter = null;
                  break;
              case "MAN001":
                  MAN001_lview = null;
                  MAN001_mview = null;
                  MAN001_presenter = null;
                  break;
              case "MAN002":
                  MAN002_lview = null;
                  MAN002_mview = null;
                  MAN002_presenter = null;
                  break;
              case "MAN003":
                  MAN003_lview = null;
                  MAN003_mview = null;
                  MAN003_presenter = null;
                  break;
              case "MAN004":
                  MAN004_lview = null;
                  MAN004_mview = null;
                  MAN004_presenter = null;
                  break;
              case "MAN005":
                  //MAN005_lview = null;
                  //MAN005_mview = null;
                  //MAN005_presenter = null;
                  break;
              case "MAN006":
                  MAN006_lview = null;
                  MAN006_mview = null;
                  MAN006_presenter = null;
                  break;
              case "MAN007":
                  MAN007_lview = null;
                  MAN007_mview = null;
                  MAN007_presenter = null;
                  break;
              case "MAN008":
                  MAN008_lview = null;
                  MAN008_mview = null;
                  MAN008_presenter = null;
                  break;
              case "MAN0091":
                  MAN0091_lview = null;
                  MAN0091_mview = null;
                  MAN0091_presenter = null;
                  break;
              case "MAN0092":
                  MAN0092_lview = null;
                  MAN0092_mview = null;
                  MAN0092_presenter = null;
                  break;
              case "MAN0093":
                  MAN0093_lview = null;
                  MAN0093_mview = null;
                  MAN0093_presenter = null;
                  break;
              case "MAN0094":
                  MAN0094_lview = null;
                  MAN0094_mview = null;
                  MAN0094_presenter = null;
                  break;
              case "MAN0095":
                  MAN0095_lview = null;
                  MAN0095_mview = null;
                  MAN0095_presenter = null;
                  break;
              case "MAN0096":
                  MAN0096_lview = null;
                  MAN0096_mview = null;
                  MAN0096_presenter = null;
                  break;
              case "MAN0097":
                  MAN0097_lview = null;
                  MAN0097_mview = null;
                  MAN0097_presenter = null;
                  break;
              case "MAN0098":
                  MAN0098_lview = null;
                  MAN0098_mview = null;
                  MAN0098_presenter = null;
                  break;
              case "MAN0099":
                  //MAN0099_lview = null;
                  //MAN0099_mview = null;
                  //MAN0099_presenter = null;
                  break;
              case "MAN00910":
                  MAN00910_lview = null;
                  MAN00910_mview = null;
                  MAN00910_presenter = null;
                  break;
              case "MAN00911":
                  MAN00911_lview = null;
                  MAN00911_mview = null;
                  MAN00911_presenter = null;
                  break;
              case "MAN00912":
                  MAN00912_lview = null;
                  MAN00912_mview = null;
                  MAN00912_presenter = null;
                  break;
              case "MAN00913":
                  MAN00913_lview = null;
                  MAN00913_mview = null;
                  MAN00913_presenter = null;
                  break;
              case "MAN00914":
                  MAN00914_lview = null;
                  MAN00914_mview = null;
                  MAN00914_presenter = null;
                  break;
              case "MAN00915":
                  MAN00915_lview = null;
                  MAN00915_mview = null;
                  MAN00915_presenter = null;
                  break;
              case "MAN00916":
                  MAN00916_lview = null;
                  MAN00916_mview = null;
                  MAN00916_presenter = null;
                  break;
              case "MAN010":
                  MAN010_lview = null;
                  MAN010_mview = null;
                  MAN010_presenter = null;
                  break;
              case "MAN011":
                  MAN011_lview = null;
                  MAN011_mview = null;
                  MAN011_presenter = null;
                  break;
              case "MAN012":
                  MAN012_lview = null;
                  MAN012_mview = null;
                  MAN012_presenter = null;
                  break;
              case "MAN013":
                  MAN013_lview = null;
                  MAN013_mview = null;
                  MAN013_presenter = null;
                  break;
              case "MAN014":
                  MAN014_lview = null;
                  MAN014_mview = null;
                  MAN014_presenter = null;
                  break;
              case "MAN015":
                  MAN015_lview = null;
                  MAN015_mview = null;
                  MAN015_presenter = null;
                  break;
              case "MAN016":
                  MAN016_lview = null;
                  MAN016_mview = null;
                  MAN016_presenter = null;
                  break;
              case "COM001":
                  COM001_lview = null;
                  COM001_presenter = null;
                  break;
              case "COM002":
                  COM002_lview = null;
                  COM002_presenter = null;
                  break;
              case "COM003":
                  COM003_lview = null;
                  COM003_presenter = null;
                  break;
              case "COM004":
                  COM004_lview = null;
                  COM004_presenter = null;
                  break;
              case "COM005":
                  COM005_lview = null;
                  COM005_presenter = null;
                  break;
              case "COM006":
                  COM006_lview = null;
                  COM006_mview = null;
                  COM006_dview = null;
                  COM006_presenter = null;
                  break;
              case "COM007":
                  COM007_lview = null;
                  COM007_mview = null;
                  COM007_presenter = null;
                  break;
              case "COM008":
                  COM008_lview = null;
                  COM008_mview = null;
                  COM008_presenter = null;
                  break;
              case "REP001":
                  REP001_lview = null;
                  REP001_presenter = null;
                  break;
              case "REP002":
                  REP002_lview = null;
                  REP002_presenter = null;
                  break;
              case "REP003":
                  REP003_lview = null;
                  REP003_presenter = null;
                  break;
              case "REP004":
                  REP004_lview = null;
                  REP004_presenter = null;
                  break;
              case "LOG001":
                  PRO001_LView = null;
                  PRO001_MView = null;
                  PRO001_DSView = null;
                  PRO001_DView = null;
                  PRO001_Presenter = null;
                  break;
              case "LOG0001":
                  PRO0001_LView = null;
                  PRO0001_MView = null;
                  PRO0001_DView = null;
                  PRO0001_DSView = null;
                  PRO0001_Presenter = null;
                  break;
              case "LOG00001":
                  PRO00001_LView = null;
                  PRO00001_MView = null;
                  PRO00001_DView = null;
                  PRO00001_DSView = null;
                  PRO00001_Presenter = null;
                  break;
              case "LOG002":
                  PRO002_LView = null;
                  PRO002_MView = null;
                  PRO002_DView = null;
                  PRO002_DSView = null;
                  PRO002_Presenter = null;
                  PRO002_Imprimir = null;
                  break;
              case "LOG003":
                  PRO003_LView = null;
                  PRO003_MView = null;
                  PRO003_DView = null;
                  PRO003_DSView = null;
                  PRO003_Presenter = null;
                  break;
              case "LOG004":
                  PRO004_LView = null;
                  PRO004_Presenter = null;
                  break;
              case "LOG005":
                  PRO005_LView = null;
                  PRO005_Presenter = null;
                  break;
              //case "LOG006":
              //    PRO006_LView = null;
              //    PRO006_MView = null;
              //    PRO006_DMView = null;
              //    PRO006_Presenter = null;
              //    break;
              case "Factura":
                  PRO007_LView = null;
                  PRO007_MView = null;
                  PRO007_RMView = null;
                  PRO007_Presenter = null;
                  break;
              case "Facturación Electrónica":
                  PRO007FE_LView = null;
                  PRO007FE_MView = null;
                  PRO007FE_RMView = null;
                  PRO007FE_Presenter = null;
                  break;
              case "LOG008":
                  PRO008_LView = null;
                  PRO008_MView = null;
                  PRO008_Presenter = null;
                  break;
              //case "LOG009":
              //   PRO009_LView = null;
              //   PRO009_MView = null;
              //   PRO009_Presenter = null;
              //   break;
              case "LOG010":
                  PRO010_LView = null;
                  PRO010_MView = null;
                  PRO010_Presenter = null;
                  PRO010_RView = null;
                  break;
              case "LOG011":
                  PRO011_LView = null;
                  PRO011_MView = null;
                  PRO011_Presenter = null;
                  PRO010_RView = null;
                  break;
              case "PreFactura":
                  PRO007PRE_LView = null;
                  PRO007PRE_MView = null;
                  PRO007PRE_Presenter = null;
                  break;
              case "REP005Con":
                  REP005_LView = null;
                  REP005_MView = null;
                  REP005_Presenter = null;
                  break;
              case "REP005Sin":
                  REP005S_LView = null;
                  REP005S_MView = null;
                  REP005S_Presenter = null;
                  break;
              case "REP005Liq":
                  REP005L_LView = null;
                  REP005L_MView = null;
                  REP005L_Presenter = null;
                  break;
              case "REP006":
                  REP006_LView = null;
                  REP006_MView = null;
                  REP006_Presenter = null;
                  break;
              case "REP007":
                  REP007_LView = null;
                  REP007_RMView = null;
                  REP007_Presenter = null;
                  break;
              case "REP008":
                  REP008_LView = null;
                  REP008_RMView = null;
                  REP008_Presenter = null;
                  break;
              case "REP0081":
                  REP0081_LView = null;
                  REP0081_RMView = null;
                  REP0081_Presenter = null;
                  break;
              case "REP009":
                  REP009_lview = null;
                  //REP009_RMView = null;
                  REP009_presenter = null;
                  break;
              case "REP010":
                  REP010_lview = null;
                  //REP009_RMView = null;
                  REP010_presenter = null;
                  break;
              case "REP011":
                  REP011_lview = null;
                  //REP009_RMView = null;
                  REP011_presenter = null;
                  break;
              case "REP012":
                  REP012_lview = null;
                  //REP009_RMView = null;
                  REP012_presenter = null;
                  break;
              case "REP013":
                  REP013_lview = null;
                  //REP013_RMView = null;
                  REP013_presenter = null;
                  break;
              case "CAJ001":
                  CAJ001_lview = null;
                  CAJ001_mview = null;
                  CAJ001_presenter = null;
                  break;
              case "CAJ002":
                  CAJ002_lview = null;
                  CAJ002_presenter = null;
                  break;
              case "CAJ003":
                  CAJ003_lview = null;
                  CAJ003_presenter = null;
                  break;
              case "CAJ004":
                  CAJ004_lview = null;
                  CAJ004_presenter = null;
                  break;
              case "CAJ005":
                  CAJ005_lview = null;
                  CAJ005_presenter = null;
                  break;
              case "CAJ006":
                  CAJ006_lview = null;
                  CAJ006_presenter = null;
                  break;
              case "CAJ007":
                  CAJ007_lview = null;
                  CAJ007_presenter = null;
                  break;
              case "CAJ008":
                  CAJ008_lview = null;
                  CAJ008_presenter = null;
                  break;
              case "CAJ009":

                  break;
              case "CAJ010":
                  CAJ010_lview = null;
                  CAJ010_presenter = null;
                  break;
              case "CAJ011":
                  CAJ011_lview = null;
                  CAJ011_presenter = null;
                  break;
              case "CAJ012":
                  CAJ012_lview = null;
                  CAJ012_presenter = null;
                  break;
              case "CAJ013":
                  CAJ013_lview = null;
                  CAJ013_presenter = null;
                  break;
              case "CAJ014":
                  CAJ014_lview = null;
                  CAJ014_presenter = null;
                  break;
              case "CAJ016":
                  CAJ015_lview = null;
                  CAJ015_presenter = null;
                  break;
              case "CAJ018":
                  CAJ018_lview = null;
                  CAJ018_presenter = null;
                  break;
              case "OPE001":
                  OPE001_lview = null;
                  OPE001_mview = null;
                  OPE001_presenter = null;
                  break;

              case "DOC002":
                  DOC002_lview = null;
                  DOC002_mview = null;
                  DOC002_presenter = null;
                  break;
              case "REPF001":
                  REP001_FinanzasLview = null;
                  REP001_FinanzasPresenter = null;
                  break;
              case "REPF002":
                  REP002_FinanzasLview = null;
                  REP002_FinanzasPresenter = null;
                  break;
              case "REPF003":
                  REP003_FinanzasLview = null;
                  REP003_FinanzasPresenter = null;
                  break;
              case "REPF0040":
                  REP004_FinanzasLview = null;
                  REP004_FinanzasPresenter = null;
                  break;
              case "REPF0046":
                  REP004_FinanzasLview02 = null;
                  REP004_FinanzasPresenter02 = null;
                  break;
              case "REPF0042":
                  REP004_FinanzasLview03 = null;
                  REP004_FinanzasPresenter03 = null;
                  break;
              case "REPF0045":
                  REP004_FinanzasLview04 = null;
                  REP004_FinanzasPresenter04 = null;
                  break;
              case "REP015":
                  REP015_FinanzasLview = null;
                  REP015_FinanzasPresenter = null;
                  break;
              case "REP0101":
                  REP010_FinanzasLview = null;
                  REP010_FinanzasPresenter = null;
                  break;
              //case "REPF005":
              //   REP005_FinanzasLview = null;
              //   REP005_FinanzasPresenter = null;
              //   break;
              //case "REPF006":
              //   REP006_FinanzasLview = null;
              //   REP006_FinanzasPresenter = null;
              //   break;
              case "REPF007":
                  REP007_FinanzasLview = null;
                  REP007_FinanzasPresenter = null;
                  break;
              case "REPF008":
                  REP008_FinanzasLview = null;
                  REP008_FinanzasPresenter = null;
                  break;
              case "REPF009":
                  REP009_FinanzasLview = null;
                  REP009_FinanzasPresenter = null;
                  break;
              case "PRO022":
                  PRO022_LView = null;
                  PRO022_MView = null;
                  PRO022_Presenter = null;
                  break;
              case "OPE005":
                  OPE005LView = null;
                  OPE005Presenter = null;
                  break;
              case "OPE006":
                  OPE006LView = null;
                  OPE006Presenter = null;
                  break;
              case "OPE007":
                  OPE007LView = null;
                  OPE007Presenter = null;
                  break;
              case "OPE008":
                  OPE008LView = null;
                  OPE008Presenter = null;
                  break;
          }

      }

      #endregion

   }
}