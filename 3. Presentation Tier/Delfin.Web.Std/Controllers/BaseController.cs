using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Globalization;
using System.Configuration;
using Delfin.Web.Std.Models;
using Delfin.Web.Std.Models.Base;
using Delfin.Web.Std.Models.Context.Base;
using Delfin.Web.Std.Util;
using Newtonsoft.Json;

namespace Delfin.Web.Std.Controllers
{
    public class BaseController : Controller
    {
       #region Members
       DistribucionSession distribucionSession = null;
       #endregion

       #region Constructor
       public BaseController()
       {

       }

       private void InitializeDistribucionSession()
       {
          this.distribucionSession = Delfin.Web.Std.AdministracionSession.Obtener();
       }
       #endregion

       #region Métodos
       protected override void OnActionExecuting(ActionExecutingContext filterContext)
       {
          if (AdministracionSession.Obtener() == null)
          {
             filterContext.Result = this.Redirect("~/");
             return;
          }

          if (!BaseContext.ValidarAccesoUrl() && !filterContext.HttpContext.Request.IsAjaxRequest())
          {
             filterContext.Result = this.Redirect("~/Error/NotAuthorized");
             return;
          }

          InitializeDistribucionSession();
          base.OnActionExecuting(filterContext);
       }

       public DistribucionSession ObtenerSesion()
       {
          return AdministracionSession.Obtener();
       }

       public void GuardarSesion(DistribucionSession distribucionSession)
       {
          AdministracionSession.Guardar(distribucionSession);
       }
       #endregion
    }
}

namespace Delfin.Web.Std
{
   public static class AdministracionSession
   {
      public static DistribucionSession Obtener()
      {
         DistribucionSession session = null;

         if (HttpContext.Current.Session[Common.DistribucionSession] != null)
         {
            session = (DistribucionSession)HttpContext.Current.Session[Common.DistribucionSession];
         }

         return session;
      }

      public static void Guardar(DistribucionSession distribucionSession)
      {
         HttpContext.Current.Session[Common.DistribucionSession] = distribucionSession;
      }

      public static void KillSession(string session, int codigo = 0)
      {
         if (codigo != 0)
         {
            HttpContext.Current.Session.Abandon();
         }
         else
         {
            HttpContext.Current.Session.Remove(session);
         }
      }
   }

   public static class AdministracionClient
   {
      public static string ObtenerNumeroIP()
      {
         string VisitorsIPAddr = string.Empty;

         if (System.Web.HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"] != null)
         {
            VisitorsIPAddr = System.Web.HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"].ToString();
         }
         else if (System.Web.HttpContext.Current.Request.UserHostAddress.Length != 0)
         {
            VisitorsIPAddr = System.Web.HttpContext.Current.Request.UserHostAddress;
         }
         return VisitorsIPAddr;
      }
   }
}