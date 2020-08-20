using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
   public partial class CAJ015AsientosContablesPresenter
   {
      #region [ Variables ]
      public String Title = "Generación de Asientos Contables";
      public String CUS = "CAJ016";
      #endregion

      #region [ Contrusctor ]

      public CAJ015AsientosContablesPresenter(IUnityContainer x_container, CAJ015AsientosContablesLView x_lview)
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

            ListSubDiarios = Client.GetAllConstantes().Where(CAS => CAS.CONS_CodTabla.Equals("CAS")).ToObservableCollection().OrderBy(cas => cas.CONS_CodTipo).ToObservableCollection();
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

      public ICAJ015AsientosContablesLView LView { get; set; }

      #endregion

      #region [ Metodos ]

      public DateTime? F_FecIni { get; set; }
      public DateTime? F_FecFin { get; set; }
      public String F_TipoAsiento { get; set; }
      public String F_MesReg { get; set; }
      public String F_FecDoc { get; set; }
      public String F_Asiento { get; set; }

      public String F_Registro_1 { get; set; }
      public String F_Registro_2 { get; set; }
      public int? F_Voucher_1 { get; set; }
      public int? F_Voucher_2 { get; set; }

      public ObservableCollection<Constantes> ListSubDiarios { get; set; }

      public void ProcesarAsientos()
      {
         try
         {
            ObservableCollection<Infrastructure.Aspect.DataAccess.DataAccessFilterSQL> _listFilters = new ObservableCollection<Infrastructure.Aspect.DataAccess.DataAccessFilterSQL>();
            _listFilters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@FecIni", FilterValue = F_FecIni, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.DateTime, FilterSize = 8 });
            _listFilters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@FecFin", FilterValue = F_FecFin, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.DateTime, FilterSize = 8 });
            String x_Procedure = "";
            switch (F_TipoAsiento)
            {
               case "CD":  // ASIENTOS DE COMPRA - CON DETRACCION
                  _listFilters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@FecDoc", FilterValue = F_FecDoc, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.Char, FilterSize = 6 });
                  _listFilters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@MesReg", FilterValue = F_MesReg, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.Char, FilterSize = 2 });

                  _listFilters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@Registro_09_10", FilterValue = F_Registro_1, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.Char, FilterSize = 2 });
                  _listFilters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@Voucher", FilterValue = F_Voucher_1, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.Int32, FilterSize = 4 });
                  x_Procedure = "CAJ_PROC_RegProvOpeConDetComprasCONCAR";
                  break;
               case "CS":  // ASIENTOS DE COMPRA - SIN DETRACCION
                  _listFilters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@FecDoc", FilterValue = F_FecDoc, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.Char, FilterSize = 6 });
                  _listFilters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@MesReg", FilterValue = F_MesReg, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.Char, FilterSize = 2 });

                  _listFilters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@Registro_11_18", FilterValue = F_Registro_1, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.Char, FilterSize = 2 });
                  _listFilters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@Voucher", FilterValue = F_Voucher_1, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.Int32, FilterSize = 4 });
                  x_Procedure = "CAJ_PROC_RegProvOpeSinDetComprasCONCAR";
                  break;
               case "VE":  // ASIENTOS DE VENTAS
                  _listFilters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@FecDoc", FilterValue = F_FecDoc, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.Char, FilterSize = 6 });
                  _listFilters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@MesReg", FilterValue = F_MesReg, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.Char, FilterSize = 2 });

                  _listFilters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@Registro_05_07", FilterValue = F_Registro_1, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.Char, FilterSize = 2 });
                  _listFilters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@Voucher", FilterValue = F_Voucher_1, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.Int32, FilterSize = 4 });
                  x_Procedure = "CAJ_PROC_RegProOpeVentasConcar";
                  break;
               case "ST":  // ASIENTOS DE STATEMENT
                  _listFilters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@FecDoc", FilterValue = F_FecDoc, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.Char, FilterSize = 6 });
                  _listFilters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@MesReg", FilterValue = F_MesReg, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.Char, FilterSize = 2 });

                  _listFilters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@Registro", FilterValue = F_Registro_1, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.Char, FilterSize = 2 });
                  _listFilters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@Voucher", FilterValue = F_Voucher_1, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.Int32, FilterSize = 4 });
                  _listFilters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@Asiento", FilterValue = F_Asiento, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.Char, FilterSize = 6 });
                  x_Procedure = "CAJ_PROC_StatmentCONCAR";
                  break;
               case "CN":  // CANCELACIONES
                  _listFilters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@FecDoc", FilterValue = F_FecDoc, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.Char, FilterSize = 6 });
                  _listFilters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@MesReg", FilterValue = F_MesReg, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.Char, FilterSize = 2 });

                  _listFilters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@Registro", FilterValue = F_Registro_1, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.Char, FilterSize = 2 });
                  _listFilters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@Voucher", FilterValue = F_Voucher_1, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.Int32, FilterSize = 4 });
                  x_Procedure = "CAJ_PROC_RegCancelacionesCONCAR";
                  break;
               case "PG":  // PAGOS
                  _listFilters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@Registro", FilterValue = F_Registro_1, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.Char, FilterSize = 2 });
                  _listFilters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@VoucherDG", FilterValue = F_Voucher_1, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.Int32, FilterSize = 4 });
                  _listFilters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@VoucherDC", FilterValue = F_Voucher_2, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.Int32, FilterSize = 4 });
                  _listFilters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@FecDoc", FilterValue = F_FecDoc, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.Char, FilterSize = 6 });
                  _listFilters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@MesReg", FilterValue = F_MesReg, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.Char, FilterSize = 2 });
                  x_Procedure = "CAJ_PROC_RegPagosCONCAR";
                  break;
               default:
                  break;
            }
            String _mensaje = "";
            if (Client.SaveCtaCteGenerarAsientosByFilter(x_Procedure, _listFilters, ref _mensaje))
            {
               if (String.IsNullOrEmpty(_mensaje))
               {
                  Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeSatisfactorio(Title, "Se ha procesado la solicitud satisfactoriamente.");
               }
               else
               {
                  Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Title, "Se ha procesado la solicitud satisfactoriamente, pero existen observaciones, haga click en el boton [Detalles].", _mensaje);
               }
            }
            else
            { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Title, "No se procesaron registros."); }
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