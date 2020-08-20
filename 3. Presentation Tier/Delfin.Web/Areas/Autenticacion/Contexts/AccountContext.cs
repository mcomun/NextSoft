using Infrastructure.Aspect.Cryptography;
using Microsoft.Practices.Unity;
using NextAdmin.Entities;
using NextAdmin.ServiceContracts;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web;

namespace Delfin.Web.Areas.Autenticacion.Contexts
{
   public class AccountContext : IDisposable
   {
      #region [ Variables ]
      public String Title = "Mantenimiento de Usuarios";
      public String CUS = "CUS005";

      private const string Correcto = "C";
      private const string Password = "P";
      private const string Bloqueado = "B";

      private const string NivelSeguridad = "NIVELSEGURI";
      private const string TamañoPassword = "LONGPASSWRD";

      private const string NumeroIntentos = "NUMINTENTOS";
      private const string TiempoCaducidad = "TIEMPOCADUC";

      private const string RequierePregunta = "REQPREGUNTA";
      #endregion

      #region [ Constructor ]
      public AccountContext()
      {
         try
         {
            ContainerService = System.Web.HttpContext.Current.Application["ContainerService"] as UnityContainer;
            Client = ContainerService.Resolve<INextAdminServices>();
         }
         catch (Exception)
         { }
      }
      public void Dispose()
      { Client = null; }
      #endregion

      #region [ Propiedades ]
      public UnityContainer ContainerService { get; set; }
      public INextAdminServices Client { get; set; }

      public Usuarios Item { get; set; }
      public ObservableCollection<Usuarios> Items { get; set; }

      public LogAccesos ItemLogAccesos { get; set; }
      public Parametros ItemParametros { get; set; }
      #endregion

      #region [ Metodos Usuario ]
      public Boolean InsertarUsuario(Usuarios Item)
      { return true; }
      public Boolean ActualizarUsuario(Usuarios Item)
      { return true; }
      public Usuarios ConsultarUsuario(String UserName)
      {
         try
         {
            Item = Client.GetOneUsuariosByCodUsr(UserName);
            if (Item != null)
            { return Item; }
            else
            { return null; }
         }
         catch (Exception)
         { return null; }
      }
      #endregion

      #region [ Metodos Autenticación ]
      public bool Autenticar(string x_usua_CodUsr, string x_usua_Password)
      {
         try
         {
            ItemParametros = Client.GetAllParametros().Where(para => para.PARA_Clave == NumeroIntentos).FirstOrDefault();


            Item = Client.GetOneUsuariosByCodUsr(x_usua_CodUsr);

            if (Item != null)
            {
               if (Item.USUA_Estado)
               {
                  ItemLogAccesos = new LogAccesos();
                  ItemLogAccesos.Instance = Infrastructure.Aspect.BusinessEntity.InstanceEntity.Added;
                  ItemLogAccesos.LOGA_Fecha = DateTime.Now;
                  ItemLogAccesos.USUA_Codigo = Item.USUA_Codigo.ToString();

                  string _imput = x_usua_CodUsr.ToLower() + x_usua_Password + x_usua_CodUsr.ToLower();
                  if (EncryptMD5.Verificar(_imput, Item.USUA_Pass))
                  {
                     ItemLogAccesos.LOGA_Resultado = Correcto;
                     Client.SaveLogAccesos(ItemLogAccesos);
                     return true;
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
                  }
               }
            }

            return false;
         }
         catch (Exception)
         { return false; }
      }
      
      #endregion

      #region [ Metodos Actualización Contraseña ]
      public bool Actualizar(string x_username, string x_usua_PasswordActual, string x_usua_PasswordNueva, string x_usua_PasswordValidacion)
      {
         try
         {
            var Item = Client.GetOneUsuariosByCodUsr(x_username);
            if (Item != null)
            {
               string _imput = x_username.ToLower() + x_usua_PasswordActual + x_username.ToLower();
               if (EncryptMD5.Verificar(_imput, Item.USUA_Pass))
               {
                  if (x_usua_PasswordNueva == x_usua_PasswordValidacion)
                  {
                     Item.USUA_Pass = Infrastructure.Aspect.Cryptography.EncryptMD5.Encriptar(x_username.ToLower() + x_usua_PasswordNueva + x_username.ToLower());
                     Item.Instance = Infrastructure.Aspect.BusinessEntity.InstanceEntity.Modified;
                     Item.USUA_CambiarPassword = (Item.USUA_CambiarPassword) ? false : Item.USUA_CambiarPassword;
                     Item.AUDI_UsrMod = x_username;
                     Item.AUDI_FecMod = DateTime.Now;

                     if (Client.SaveUsuarios(Item))
                     { return true; }
                  }
               }
            }
            return false;
         }
         catch (Exception ex)
         { throw ex; }
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