using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using Delfin.Web.Std.Models;
using Delfin.Web.Std.Models.Authentication;
using Delfin.Web.Std.Models.Context.IngresoSistema;
using Delfin.Web.Std.Util;

namespace Delfin.Web.Std.Controllers
{
    [HandleError]
    public class IngresoSistemaController : Controller
    { 
        public ActionResult Index()
        {
           IngresoSistemaModel objModel = new IngresoSistemaContext().Index();
           return View(objModel);
        }

       #region JsonResult
        [HttpPost]
        public JsonResult IngresoSistema(IngresoSistemaModel datosUsuario)
        {
           LoginAccesResponseAplication resultado = null;
           Session.Clear();
           resultado = new IngresoSistemaContext().ValidarUsuarioAccess(datosUsuario);

           if (resultado != null)
           {
              if (resultado.CodigoError == "0")
              {
                 createUserInformationCookie(datosUsuario.Usuario, "strTokenSecurityID123");
                 new IngresoSistemaContext().PopulateComexSession(resultado);
              }
           }

           return Json(resultado);
        }
       #endregion

       #region Metodos
        private void createUserInformationCookie(string username, string tokenSecurityID)
        {
           try
           {
              UserInformation userInformation = new UserInformation();
              userInformation.tokenSecurity = tokenSecurityID;
              userInformation.tokenExpirationTime = DateTime.Now.AddHours(Common.CookieExpirationTime);
              userInformation.systemCode = Common.CodigoIdentificacionSistema;
              userInformation.user = username;
              userInformation.Language = Common.IdiomaInicial;

              String json = JsonConvert.SerializeObject(userInformation);

              HttpCookie cookie = new HttpCookie(Common.CookieName);
              cookie.Expires = DateTime.Now.AddHours(Common.CookieExpirationTime);
              cookie.Value = json;
              HttpContext.Response.Cookies.Add(cookie);
           }
           catch (Exception ex)
           {

           }
        }
       #endregion
    }
}
