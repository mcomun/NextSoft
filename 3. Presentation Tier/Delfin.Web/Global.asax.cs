using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

using System.Configuration;
using Infrastructure.Aspect.DataAccess;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;
using Delfin.ServiceContracts;
using Delfin.ServiceProxy;
using NextAdmin.ServiceContracts;
using NextAdmin.ServiceImplementations;

namespace Delfin.Web
{
   // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
   // visit http://go.microsoft.com/?LinkId=9394801

   public class MvcApplication : System.Web.HttpApplication
   {
      protected void Application_Start()
      {
         AreaRegistration.RegisterAllAreas();

         WebApiConfig.Register(GlobalConfiguration.Configuration);
         FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
         RouteConfig.RegisterRoutes(RouteTable.Routes);
         BundleConfig.RegisterBundles(BundleTable.Bundles);
         AuthConfig.RegisterAuth();

         try
         {
            var ContainerService = new UnityContainer();

            var NextAdminBusinessPath = System.Web.HttpContext.Current.Server.MapPath("~/Config/NextAdminBusinessLogic.config");
            var NextAdminBusinessMap = new ExeConfigurationFileMap() { ExeConfigFilename = NextAdminBusinessPath };
            var NextAdminBusinessSection = System.Configuration.ConfigurationManager.OpenMappedExeConfiguration(NextAdminBusinessMap, ConfigurationUserLevel.None).GetSection("unity") as UnityConfigurationSection;
            ContainerService.LoadConfiguration(NextAdminBusinessSection);

            var BusinessPath = System.Web.HttpContext.Current.Server.MapPath("~/Config/BusinessLogic.config");
            var BusinessMap = new ExeConfigurationFileMap() { ExeConfigFilename = BusinessPath };
            var BusinessSection = System.Configuration.ConfigurationManager.OpenMappedExeConfiguration(BusinessMap, ConfigurationUserLevel.None).GetSection("unity") as UnityConfigurationSection;
            ContainerService.LoadConfiguration(BusinessSection);

            String _connDB = "";
            if (System.Configuration.ConfigurationManager.ConnectionStrings["ConnDB"].ConnectionString != null)
            { _connDB = System.Configuration.ConfigurationManager.ConnectionStrings["ConnDB"].ConnectionString; }

            String _connDBAdmin = "";
            if (System.Configuration.ConfigurationManager.ConnectionStrings["ConnDBAdmin"].ConnectionString != null)
            { _connDBAdmin = System.Configuration.ConfigurationManager.ConnectionStrings["ConnDBAdmin"].ConnectionString; }

            DataAccessEnterpriseSQL.Initialize(_connDB, _connDBAdmin);

            ContainerService.RegisterType<INextAdminServices, NextAdminServices>(new ContainerControlledLifetimeManager());
            ContainerService.RegisterType<IDelfinServices, DelfinServicesProxy>(new ContainerControlledLifetimeManager());
            //ContainerService.RegisterType<ISessionService, SessionService>(new ContainerControlledLifetimeManager());

            //Session = ContainerService.Resolve<ISessionService>();

            System.Web.HttpContext.Current.Application["ContainerService"] = ContainerService;
         }
         catch (Exception)
         { }
      }
   }
}