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
using System.Windows.Forms;
using Infrastructure.WinForms.Controls;


namespace Delfin.Principal
{
   public partial class CAJ010ConciliacionPresenter
   {
      #region [ Variables ]
      public String Title = "Conciliación Bancaria";
      public String CUS = "CAJ010";
      public Boolean FleteNegativo = false;
      #endregion

      #region [ Contrusctor ]
      public CAJ010ConciliacionPresenter(IUnityContainer x_container, ICAJ010ConciliacionLView x_lview)
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

            DTPeriodos = new System.Data.DataTable();
            ObservableCollection<Infrastructure.Aspect.DataAccess.DataAccessFilterSQL> _listFilters = new ObservableCollection<Infrastructure.Aspect.DataAccess.DataAccessFilterSQL>();
            DTPeriodos = Client.GetDTAnexos("CAJ_CCCTSS_Periodos", _listFilters);

            Fecha = Client.GetFecha();

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

      public ICAJ010ConciliacionLView LView { get; set; }
      public ICAJ010ConciliacionMView MView { get; set; }

      public Movimiento Item { get; set; }
      public ObservableCollection<Movimiento> Items { get; set; }

      public System.Data.DataTable DTPeriodos { get; set; }
      public DateTime Fecha { get; set; }
      public String MensajeError { get; set; }
      #endregion

      #region [ Metodos ]

      public String F_CUBA_Codigo { get; set; }
      public String F_CONC_Periodo { get; set; }
      public DateTime? F_FecIni { get; set; }
      public DateTime? F_FecFin { get; set; }


      public void Actualizar()
      {
         try
         {
            Item = null;
            Items = null;

            if (LView != null)
            {
               ObservableCollection<Infrastructure.Aspect.DataAccess.DataAccessFilterSQL> _listFilters = new ObservableCollection<Infrastructure.Aspect.DataAccess.DataAccessFilterSQL>();
               _listFilters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@psinEMPR_Codigo", FilterValue = Controls.Entorno.ItemEmpresa.EMPR_Codigo, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.Int32, FilterSize = 4 });
               _listFilters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@pchrCUBA_Codigo", FilterValue = F_CUBA_Codigo, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.Char, FilterSize = 3 });
               _listFilters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@pvchCONC_Periodo", FilterValue = F_CONC_Periodo, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.Varchar, FilterSize = 10 });
               _listFilters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@FecIni", FilterValue = F_FecIni, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.DateTime, FilterSize = 8 });
               _listFilters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@FecFin", FilterValue = F_FecFin, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.DateTime, FilterSize = 8 });

               Items = Client.GetAllMovimientoFilter("CAJ_MOVISS_TodosConciliacion", _listFilters);

               if (Items != null)
               {
                  foreach (Entities.Movimiento iMov in Items)
                  {
                     iMov.ItemConciliacion = new Conciliacion();
                     iMov.ItemConciliacion.EMPR_Codigo = iMov.EMPR_Codigo;
                     iMov.ItemConciliacion.MOVI_Codigo = iMov.MOVI_Codigo;
                     iMov.ItemConciliacion.CONC_Codigo = iMov.CONC_Codigo;
                     iMov.ItemConciliacion.CONC_MontoBCO = iMov.CONC_MontoBCO;
                     iMov.ItemConciliacion.CONC_Periodo = iMov.CONC_Periodo;
                     iMov.ItemConciliacion.CONC_FecConciliacion = iMov.CONC_FecConciliacion;
                  }
               }

               LView.ShowItems();
            }
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Title, "Ha ocurrido un error actualizando.", ex); }
      }

      Boolean isMViewShow = false;
      public bool Guardar(Boolean ShowMessage)
      {
         try
         {
            if (Validar())
            {
               ObservableCollection<Entities.Movimiento> _items = Items;
               if (Client.SaveMovimiento(ref _items, Movimiento.TInterfazMovimientos.Conciliacion))
               {
                  if (ShowMessage) { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeSatisfactorio(Title, "Se ha guardado satisfactoriamente"); }
                  Actualizar();
                  return true; 
               }
            }
            else
            {
               LView.ShowValidation();
               return false;
            }
            return false;
         }
         catch (Exception ex)
         {
            Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Title, Infrastructure.Aspect.Constants.Mensajes.SavePresenter, ex);
            return false;
         }
      }

      private Boolean Validar()
      {
         try
         {
            Boolean _isCorrect = true;
            MensajeError = "";
            int _contador = 0;
            foreach (Entities.Movimiento iMov in Items)
            {
               iMov.AUDI_UsrCrea = Session.UserName;
               iMov.ItemConciliacion.CONC_MontoBCO = iMov.CONC_MontoBCO;
               iMov.ItemConciliacion.CONC_FecConciliacion = iMov.CONC_FecConciliacion;
               if (iMov.Seleccionar)
               {
                  if (!iMov.ValidarConciliacion())
                  {
                     _isCorrect = false;
                     MensajeError += String.Format("- El registro con Nro. de Operación : {2} (código interno : [{1}])  tiene las siguientes observaciones: {0}{3}", Environment.NewLine, iMov.MOVI_Codigo, iMov.MOVI_NroOperacion, iMov.MensajeError);
                  }
                  _contador++;
               }
            }
            if (_contador == 0)
            {
               _isCorrect = false;
               MensajeError += String.Format("- No se ha seleccionado ningun item para ser conciliado.{0}", Environment.NewLine);
            }

            return _isCorrect;
         }
         catch (Exception)
         { throw; }
      }


      public void CloseView()
      {
         //if (isMViewShow)
         //{ ((CAJ010ConciliacionMView)MView).Close(); }
      }
      public void IsClosedMView()
      { isMViewShow = false; }

      public void CargarXLS()
      {
         try
         {
            OpenFileDialog ofdialog = new OpenFileDialog();

            //ofdialog.InitialDirectory = "c:\\";
            ofdialog.Filter = "Archivos de Excel (*.xls)|*.xls|Archivos de Excel (*.xlsx)|*.xlsx";
            ofdialog.FilterIndex = 2;
            String Archivo = "", MensajeConciliacion = "";
            //ofdialog.RestoreDirectory = true;

            if (ofdialog.ShowDialog() == DialogResult.OK)
            {
               Archivo = Path.GetFileName(ofdialog.FileName);
               ImportarExcel excel = new ImportarExcel();
               String _message = "";
               System.Data.DataTable DataTableImportacion = excel.ReadExcel(ofdialog.FileName, 5, 1000, ref _message);
               foreach (System.Data.DataRow item in DataTableImportacion.Rows)
               {
                  #region Validar Nro de Operación

                  String _nroOperacion = "";
                  Int32 _value = 0;
                  if (Int32.TryParse(item[4].ToString(), out _value))
                  { _nroOperacion = _value.ToString("########"); }
                  else { _nroOperacion = item[4].ToString(); }

                  Entities.Movimiento _movi = Items.Where(Movi => !String.IsNullOrEmpty(Movi.MOVI_NroOperacion) && Movi.MOVI_NroOperacion.Contains(_nroOperacion) && !Movi.Seleccionar).FirstOrDefault();
                  if (_movi != null)
                  {
                     MensajeConciliacion += String.Format("- Se concilio el Nro de Operación: {1}, con el movimiento de banco con codigo interno {2} .{0}", Environment.NewLine, _movi.MOVI_NroOperacion, _movi.MOVI_Codigo);
                     _movi.Seleccionar = true;
                     _movi.CONC_MontoBCO = _movi.Monto;
                     _movi.CONC_FecConciliacion = Fecha;
                     _movi.ItemConciliacion.CONC_MontoBCO = _movi.CONC_MontoBCO;
                     _movi.ItemConciliacion.CONC_FecConciliacion = _movi.CONC_FecConciliacion;
                  }

                  #endregion
               }
               Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeSatisfactorio(Title, String.Format("Se realizo la conciliación del archivo: {0}", Archivo));
               LView.ShowConciliacion(MensajeConciliacion);
               LView.ShowItems();
            }
         }
         catch (Exception)
         { throw; }
      }

      #endregion

      #region [ Metodos Eventos/Tareas ]

      #endregion
   }
}