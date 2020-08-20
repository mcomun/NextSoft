using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Delfin.Web.Std.Util;
//using Delfin.Web.Std.Util.Wrappers;

namespace Delfin.Web.Std.Controllers
{
    public class HomeController : BaseController
    {
       //#region Propiedades
       //DistribucionSession distribucionSession = null;
       //#endregion

       //#region Constructor
       //public HomeController()
       // {
       //    distribucionSession = new DistribucionSession();
       // }
       // #endregion

        public ActionResult Index()
        {
           //DistribucionSession.UsuarioLogin = new UsuarioLoginRequest();

            //distribucionSession.usuario = "ADMIN"; 
            //AdministracionSession.Guardar(distribucionSession);
            DistribucionSession distribucionSession = Delfin.Web.Std.AdministracionSession.Obtener();
            var sUsuario = distribucionSession.usuario;

            ViewBag.Message = Delfin.Web.Std.Resources.Shared.Resource.TitleContent;
            ViewBag.User = sUsuario;
            return View();
        }

        public ActionResult LogOut()
        {
           DistribucionSession distribucionSession = Delfin.Web.Std.AdministracionSession.Obtener();
           //var sUsuario = distribucionSession.UsuarioLogin.NombreCompleto;
           //if (sUsuario == null)
           var sUsuario = distribucionSession.usuario;
           ViewBag.Usuario = sUsuario;

           HttpCookie userInformationCookieDelfinComex = HttpContext.Request.Cookies[Common.CookieName];
           if (userInformationCookieDelfinComex != null)
           {
              HttpCookie cookie = new HttpCookie(Common.CookieName);
              cookie.Expires = DateTime.Now.AddHours(0);
              HttpContext.Response.Cookies.Add(cookie);
              AdministracionSession.KillSession(Common.DistribucionSession, 1);
           }
           else
           {
              AdministracionSession.KillSession(Common.DistribucionSession);
           }

           return View();
        }

    }
}
