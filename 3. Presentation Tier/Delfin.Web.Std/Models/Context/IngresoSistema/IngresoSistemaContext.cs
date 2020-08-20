using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Delfin.Web.Std.Util;
using Delfin.Web.Std.Util.Wrappers;


using Infrastructure.Aspect.Cryptography;
using Microsoft.Practices.Unity;
using NextAdmin.Entities;
using NextAdmin.ServiceContracts;
using System.Collections.ObjectModel;


namespace Delfin.Web.Std.Models.Context.IngresoSistema
{
   public class IngresoSistemaContext
   {
      #region [ Variables ]
      private const string Correcto = "C";
      private const string Password = "P";
      private const string Bloqueado = "B";

      private const string NivelSeguridad = "NIVELSEGURI";
      private const string TamañoPassword = "LONGPASSWRD";

      private const string NumeroIntentos = "NUMINTENTOS";
      private const string TiempoCaducidad = "TIEMPOCADUC";

      private const string RequierePregunta = "REQPREGUNTA";
      #endregion

      #region [ Propiedades ]
      public UnityContainer ContainerService { get; set; }
      public INextAdminServices Client { get; set; }

      public Usuarios Item { get; set; }
      public ObservableCollection<Usuarios> Items { get; set; }

      public LogAccesos ItemLogAccesos { get; set; }
      public Parametros ItemParametros { get; set; }
      #endregion


      #region Propiedades
      DistribucionSession distribucionSession = null;
      #endregion



      #region Constructor
      public IngresoSistemaContext()
      {
         distribucionSession = new DistribucionSession();
      }
      #endregion

      #region Metodos
      public IngresoSistemaModel Index()
      {
         IngresoSistemaModel Model = new IngresoSistemaModel();
         return Model;
      }

      public LoginAccesResponseAplication ValidarUsuarioAccess(IngresoSistemaModel datosUsuario)
       {
         string IdiomaInicial = Common.IdiomaInicial;

         LoginAccesResponseAplication loginAccesResponseAplication = new LoginAccesResponseAplication();
         
         //WsDinSeg.Din_Segu_ServiceClient oServicioSeguridad = new WsDinSeg.Din_Segu_ServiceClient();
         //WsDinSeg.UsuarioD4W oUsuario = new WsDinSeg.UsuarioD4W();
         //oUsuario.Cod_Usuario = datosUsuario.Usuario;
         //oUsuario.Cod_Pass = datosUsuario.Contrasenia;

         ContainerService = System.Web.HttpContext.Current.Application["ContainerService"] as UnityContainer;
         Client = ContainerService.Resolve<INextAdminServices>();

         try
         {

            ItemParametros = Client.GetAllParametros().Where(para => para.PARA_Clave == NumeroIntentos).FirstOrDefault();


            Item = Client.GetOneUsuariosByCodUsr(datosUsuario.Usuario);

            if (Item != null)
            {
               if (Item.USUA_Estado)
               {
                  ItemLogAccesos = new LogAccesos();
                  ItemLogAccesos.Instance = Infrastructure.Aspect.BusinessEntity.InstanceEntity.Added;
                  ItemLogAccesos.LOGA_Fecha = DateTime.Now;
                  ItemLogAccesos.USUA_Codigo = Item.USUA_Codigo.ToString();

                  string _imput = datosUsuario.Usuario.ToLower() + datosUsuario.Contrasenia + datosUsuario.Usuario.ToLower();
                  if (EncryptMD5.Verificar(_imput, Item.USUA_Pass))
                  {
                     ItemLogAccesos.LOGA_Resultado = Correcto;
                     Client.SaveLogAccesos(ItemLogAccesos);


                     loginAccesResponseAplication.CodigoError = "0";
                     loginAccesResponseAplication.DescripcionError = "Ingresaste!!";
                     loginAccesResponseAplication.Usuario = Item.USUA_CodUsr;
                     //return true;
                  }
                  else
                  {
                     ItemLogAccesos.LOGA_Resultado = Password;
                     Client.SaveLogAccesos(ItemLogAccesos);

                     ItemLogAccesos = Client.GetOneLogAccesosLast(Item.USUA_Codigo);

                     if (ItemLogAccesos.LOGA_Intento >= MaximoIntentos(ItemParametros))
                     {
                        ItemLogAccesos.LOGA_Resultado = Bloqueado;
                        Client.SaveLogAccesos(ItemLogAccesos);

                        Client.SaveUsuariosBloquearCuenta(Item.USUA_CodUsr, Item.USUA_CodUsr);
                     }


                     loginAccesResponseAplication.CodigoError = "1";
                     loginAccesResponseAplication.DescripcionError = "Error al ingresar";
                     loginAccesResponseAplication.Usuario = Item.USUA_CodUsr;
                  }
               }
            }

         }
         catch
         {
            throw new Exception("Se produjo un Error.");
         }
         finally
         {
            //oServicioSeguridad.Close();
         }

         return loginAccesResponseAplication;
      }

      public void PopulateComexSession(LoginAccesResponseAplication resultadoUsuario)
      {
         distribucionSession.UsuarioLogin = new UsuarioLoginRequest();

         distribucionSession.usuario = resultadoUsuario.Usuario;
         distribucionSession.UsuarioLogin.Usuario = resultadoUsuario.Usuario;
         distribucionSession.UsuarioLogin.IP = AdministracionClient.ObtenerNumeroIP();

         AdministracionSession.Guardar(distribucionSession);
      }
      #endregion

      #region [ Metodos Privados ]
      private short MaximoIntentos(Parametros x_parametros)
      {
         try
         {
            short max = 0;
            if (short.TryParse(x_parametros.PARA_Valor, out max))
            {
               return max;
            }
            else { return 3; }
         }
         catch (Exception ex)
         { throw ex; }
      }
      #endregion
   }
}