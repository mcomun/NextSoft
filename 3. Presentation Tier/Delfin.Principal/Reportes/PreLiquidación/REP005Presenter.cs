using System;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Infrastructure.Aspect.BusinessEntity;
using Microsoft.Practices.Unity;
using Delfin.ServiceProxy;
using Delfin.Entities;
using Infrastructure.Aspect.Collections;
using Infrastructure.Client.Services.Session;
using System.Collections.ObjectModel;
using Infrastructure.WinFormsControls;
using System.Data;
using Infrastructure.Aspect.Constants;
using Microsoft.Reporting.WinForms;

namespace Delfin.Principal
{
   public class REP005Presenter
   {
      #region [ Variables ]
      public String Titulo = "Pre-Liquidación";
      public String CUS = "REP005";
      #endregion

      #region [ Propiedades ]
      public IUnityContainer ContainerService { get; set; }
      public ISessionService Session { get; set; }
      public Delfin.ServiceContracts.IDelfinServices Client { get; set; }
             
      public IREP005LView LView { get; set; }
      public IPRO005RView MView { get; set; }

      public Decimal TipoCambio { get; set; }                     
      
      public DataTable Items { get; set; }

      public Int32 COPE_Codigo { get; set; }
      public Int32? ENTC_CodigoFiltro { get; set; }
      public String NroOperacion { get; set; }
      public String HBLOperacion { get; set; }
      public DateTime? FechaEmisionIni { get; set; }
      public DateTime? FechaEmisionFin { get; set; }
      public String MensajeError { get; set; }
      public String TipoReporte { get; set; }
      
      public DataSet DSReporte { get; set; }
      public ReportDataSource RepDataSourceCabecera { get; set; }
      public ReportDataSource RepDataSourceDetalle { get; set; }
      public ReportDataSource RepDataSourceDetalleAduana { get; set; }
      public ReportDataSource RepDataSourceDetalleOtrosServicios { get; set; }
      public ReportDataSource RepDataSourceDetalleTransporte { get; set; }
      public ReportDataSource RepDataSourceServicioFox { get; set; }
      public String ReportPath { get; set; }
      public ReportParameter[] Parameters { get; set; }
      
      
      #endregion

      #region [ Constructor ]
      public REP005Presenter(IUnityContainer x_container, IREP005LView x_lview, IPRO005RView x_mview)
      {
         try
         {
            ContainerService = x_container;
            Session = ContainerService.Resolve<ISessionService>();
            LView = x_lview;
            MView = x_mview;
         }
         catch (Exception ex)
         { Dialogos.MostrarMensajeError(Titulo, Mensajes.ConstructorPresenter, ex); }
      }
      public void Load()
      {
         try
         {
             Client = ContainerService.Resolve<Delfin.ServiceContracts.IDelfinServices>();
             switch (CUS)
             {
                 case "REP005Liq":
                     Titulo = "Liquidación de Servicios";
                     break;
                 case "REP005Con":
                     Titulo = "Pre-Liquidación con Servicio Logístico";
                     break;
                 case "REP005Sin":
                     Titulo = "Pre-Liquidación sin Servicio Logístico";
                     break;
             }
             LView.LoadView();
         }
         catch (Exception ex)
         { Dialogos.MostrarMensajeError(Titulo, Mensajes.LoadPresenter, ex); }
      }
      #endregion

      #region [ Metodos ]
      
      #region [ Documento de Venta ]
      
      public void Actualizar()
      {
          try
          {
              Items = null;
              LView.LoadFilters();
              MensajeError = String.Empty;
              if (FechaEmisionIni== null && FechaEmisionFin== null)
              {
                  MensajeError += "* Debe ingresar la fecha de desde y fecha de hasta" + Environment.NewLine;
              }
              if (FechaEmisionIni == null)
              {
                  MensajeError += "* Debe ingresar la fecha de desde" + Environment.NewLine;
              }
              if (FechaEmisionFin == null)
              {
                  MensajeError += "* Debe ingresar la fecha de hasta" + Environment.NewLine;
              }
              if (String.IsNullOrEmpty(MensajeError))
              {
                  if (!String.IsNullOrEmpty(TipoReporte) && TipoReporte.Equals("Liquidacion"))
                  {
                     Items = Client.GetAllOperacionLiquidacion(ENTC_CodigoFiltro, NroOperacion, HBLOperacion, FechaEmisionIni.Value, FechaEmisionFin.Value, "Resumido");// Resumido es el anterior como estaba
                  }
                  else if (!String.IsNullOrEmpty(TipoReporte) && TipoReporte.Equals("ConServicioLogistico"))// Con Servicio Logistico 
                  {
                      Items = Client.GetAllOperacionPreLiquidacion(ENTC_CodigoFiltro, NroOperacion, HBLOperacion, FechaEmisionIni.Value, FechaEmisionFin.Value, true);
                  }
                  else // Sin Servicio Logistico 
                  {
                      Items = Client.GetAllOperacionPreLiquidacion(ENTC_CodigoFiltro, NroOperacion, HBLOperacion, FechaEmisionIni.Value, FechaEmisionFin.Value, false);      
                  }
                  LView.ShowItems();    
              }
              else
              {
                 LView.ShowValidation();   
              }
          }
          catch (Exception ex)
          { Dialogos.MostrarMensajeError(Titulo, "Ha ocurrido un error actualizar los datos", ex); }
      }
      #endregion

      #region [ Impresión ]
      public void ImprimirFactura()
      {
          try
          {
              DSReporte = new DataSet();
              String fecha = String.Empty;
              fecha = Session.Fecha.Year.ToString() + Session.Fecha.Month.ToString().PadLeft(2, '0').Trim() + Session.Fecha.Day.ToString().PadLeft(2, '0').Trim();
              var First = Client.GetOneTiposCambio(fecha);
              TipoCambio = 0;
              TipoCambio = First != null  ? First.TIPC_Compra:0;
              if (TipoCambio > 0 )
              { 
                DSReporte = Client.GetPreLiquidacion(COPE_Codigo, TipoReporte);
                if (DSReporte != null)
                {
                    if (DSReporte.Tables.Count < 1)
                    { Dialogos.MostrarMensajeInformacion(Titulo, "No se encontraron coincidencias."); return; }

                    if (!String.IsNullOrEmpty(TipoReporte) && TipoReporte.Equals("ConServicioLogistico"))
                    {
                       ReportPath = Application.StartupPath + @"\Reportes\RptPreLiquidacion.rdlc";
                        RepDataSourceCabecera = new ReportDataSource("DSPreLiquidacion", DSReporte.Tables[0]);
                        RepDataSourceDetalle = new ReportDataSource("DESLI", DSReporte.Tables[1]);
                        RepDataSourceDetalleTransporte = new ReportDataSource("DsTransporte", DSReporte.Tables[2]);
                        RepDataSourceDetalleAduana = new ReportDataSource("DsAduanero", DSReporte.Tables[3]);
                        RepDataSourceDetalleOtrosServicios = new ReportDataSource("DsServiciosAdicionales", DSReporte.Tables[4]);
                    }
                    else if (!String.IsNullOrEmpty(TipoReporte) && TipoReporte.Equals("SinServicioLogistico"))
                    {
                       ReportPath = Application.StartupPath + @"\Reportes\RptPreLiquidacionSinSL.rdlc";
                        RepDataSourceCabecera = new ReportDataSource("DSPreLiquidacion", DSReporte.Tables[0]);
                        RepDataSourceDetalleTransporte = new ReportDataSource("DsTransporte", DSReporte.Tables[2]);
                        RepDataSourceDetalleAduana = new ReportDataSource("DsAduanero", DSReporte.Tables[3]);
                        RepDataSourceDetalleOtrosServicios = new ReportDataSource("DsServiciosAdicionales", DSReporte.Tables[4]);
                    }
                    else //  Liquidacion
                    {
                       ReportPath = Application.StartupPath + @"\Reportes\RptLiquidacion.rdlc";
                        RepDataSourceCabecera = new ReportDataSource("DsEncabezado", DSReporte.Tables[0]);
                        RepDataSourceDetalleOtrosServicios = new ReportDataSource("DsAdicional", DSReporte.Tables[1]);
                        RepDataSourceDetalle = new ReportDataSource("DsSLI", DSReporte.Tables[2]);
                        RepDataSourceDetalleTransporte = new ReportDataSource("DsTransporte", DSReporte.Tables[3]);
                        RepDataSourceDetalleAduana = new ReportDataSource("DsAduanero", DSReporte.Tables[4]);
                        RepDataSourceServicioFox = new ReportDataSource("DsServiciosFox", DSReporte.Tables[5]);
                    }
                    
                    Parameters = new ReportParameter[1];
                    Parameters[0] = new ReportParameter("TipoCambio", TipoCambio.ToString());
                    MView.ShowReporte();
                    ((PRO005RView)MView).ShowDialog();
                }     
              }
              else
              {
                  Dialogos.MostrarMensajeInformacion(Titulo, "No se encontro el tipo de cambio de hoy verifique con el administrador de sistemas");  
              }
          }
          catch (Exception ex)
          { throw ex; }
      }
      #endregion

      #endregion
   }
}
