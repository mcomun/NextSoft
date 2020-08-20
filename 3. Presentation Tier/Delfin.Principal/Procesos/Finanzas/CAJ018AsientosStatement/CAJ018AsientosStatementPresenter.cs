using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

using Microsoft.Practices.Unity;
using Delfin.ServiceContracts;
using Delfin.ServiceProxy;
using Delfin.Entities;
using Infrastructure.Aspect;
using Infrastructure.Aspect.Collections;
using Infrastructure.Client.Services.Session;
using System.Collections.ObjectModel;
using System.IO;

using System.Configuration;
using System.Net;
using System.Runtime.Serialization.Json;


namespace Delfin.Principal
{
   public partial class CAJ018AsientosStatementPresenter
   {
      #region [ Variables ]
      public String Title = "Generación de Asientos de Statement";
      public String CUS = "CAJ018";
      #endregion

      #region [ Contrusctor ]

      public CAJ018AsientosStatementPresenter(IUnityContainer x_container, CAJ018AsientosStatementLView x_lview)
      {
         try
         {
            this.ContainerService = x_container;
            Session = this.ContainerService.Resolve<ISessionService>();
            this.LView = x_lview;
         }
         catch (Exception)
         { throw; }
      }
      public void Load()
      {
         try
         {
            Client = ContainerService.Resolve<IDelfinServices>();
            ItemsNave = new ObservableCollection<Nave>();
            ItemsNave = Client.GetAllNave(null);

            LView.LoadView();
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Title, "Ha ocurrido un error inicializando la vista.", ex); }
      }
      #endregion

      #region [ Propiedades ]
      public IUnityContainer ContainerService { get; set; }
      public ISessionService Session { get; set; }
      public IDelfinServices Client { get; set; }

      public ICAJ018AsientosStatementLView LView { get; set; }

      public DataTable Items { get; set; }

      public ObservableCollection<NaveViaje> ItemsNaveViaje { get; set; }

      public ObservableCollection<Nave> ItemsNave { get; set; }

      #endregion

      #region [ Metodos ]

      public DateTime? F_FecIni { get; set; }
      public DateTime? F_FecFin { get; set; }
      public String F_CONS_TabVIA { get; set; }
      public String F_CONS_CodVIA { get; set; }
      public String F_CONS_TabRGM { get; set; }
      public String F_CONS_CodRGM { get; set; }
      public String F_CONS_TabLNG { get; set; }
      public String F_CONS_CodLNG { get; set; }
      public String F_NVIA_NroViaje { get; set; }
      public String F_NAVE_Nombre { get; set; }

      public void Actualizar()
      {
         try
         {
            ObservableCollection<Infrastructure.Aspect.DataAccess.DataAccessFilterSQL> listFilters = new ObservableCollection<Infrastructure.Aspect.DataAccess.DataAccessFilterSQL>();
            listFilters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@pchrCONS_TabRGM", FilterValue = F_CONS_TabRGM, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.Char, FilterSize = 3 });
            listFilters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@pchrCONS_CodRGM", FilterValue = F_CONS_CodRGM, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.Char, FilterSize = 3 });
            listFilters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@pchrCONS_TabVIA", FilterValue = F_CONS_TabVIA, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.Char, FilterSize = 3 });
            listFilters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@pchrCONS_CodVIA", FilterValue = F_CONS_CodVIA, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.Char, FilterSize = 3 });
            listFilters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@pvchNVIA_NroViaje", FilterValue = F_NVIA_NroViaje, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.Varchar, FilterSize = 4 });
            listFilters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@NAVE_Nombre", FilterValue = F_NAVE_Nombre, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.Varchar, FilterSize = 50 });

            listFilters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@FecIni", FilterValue = F_FecIni, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.DateTime, FilterSize = 8 });
            listFilters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@FecFin", FilterValue = F_FecFin, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.DateTime, FilterSize = 8 });

            Items = Client.GetDTCtaCte("COM_NVIASS_TodosGAsientos", listFilters);

            LView.ShowItems();
         }
         catch (Exception)
         { throw; }
      }

      public Boolean ProcesarAsiento()
      {
         try
         {
            ObservableCollection<NaveViaje> _items = ItemsNaveViaje;
            if (Client.SaveNaveViaje(ref _items, NaveViaje.TInterfazNaveViaje.GenerarAsientos))
            { return true; }
            else
            { return false; }
         }
         catch (Exception)
         { throw; }
      }

      public void CloseView()
      {
      }

      #endregion


      #region [ Metodos Eventos/Tareas ]

      #endregion
   }
}