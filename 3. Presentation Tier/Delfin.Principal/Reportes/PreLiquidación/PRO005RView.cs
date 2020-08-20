using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Infrastructure.Aspect.Constants;
using Infrastructure.WinFormsControls;
using Microsoft.Reporting.WinForms;

namespace Delfin.Principal
{
    public partial class PRO005RView : Form, IPRO005RView
   {
      #region [ Variables ]
       
      #endregion

      #region [ Propiedades ]
      public REP005Presenter Presenter { get; set; }
      #endregion

      #region [ Formulario ]
      public PRO005RView()
      {
         InitializeComponent();
         try
         {
             btnMAN_salir.Click += btnSalir_Click;
             Load += PRO005RView_Load;
             FormClosing += PRO005RView_FormClosing;
         }
         catch (Exception ex)
         { Dialogos.MostrarMensajeError(Presenter.Titulo, Mensajes.ConstructorView, ex); }
      }
      #endregion

      #region [ IPRO005RView ]
      public void ShowReporte()
      {
          try
          {
             RptImpresion.LocalReport.ReleaseSandboxAppDomain();
              RptImpresion.Reset();

              RptImpresion.ProcessingMode = ProcessingMode.Local;
              RptImpresion.LocalReport.DataSources.Clear();
              if (!String.IsNullOrEmpty(Presenter.TipoReporte) && Presenter.TipoReporte.Equals("Liquidacion"))
              {
                  RptImpresion.LocalReport.DataSources.Add(Presenter.RepDataSourceCabecera);
                  RptImpresion.LocalReport.DataSources.Add(Presenter.RepDataSourceDetalleOtrosServicios);
                  RptImpresion.LocalReport.DataSources.Add(Presenter.RepDataSourceDetalle);
                  RptImpresion.LocalReport.DataSources.Add(Presenter.RepDataSourceDetalleTransporte);
                  RptImpresion.LocalReport.DataSources.Add(Presenter.RepDataSourceDetalleAduana);   
                  RptImpresion.LocalReport.DataSources.Add(Presenter.RepDataSourceServicioFox);   
                  
              }
              else if (!String.IsNullOrEmpty(Presenter.TipoReporte) && Presenter.TipoReporte.Equals("ConServicioLogistico"))// Con Servicio Logistico 
              {
                  RptImpresion.LocalReport.DataSources.Add(Presenter.RepDataSourceDetalle);   // Servicio Logistico
                  RptImpresion.LocalReport.DataSources.Add(Presenter.RepDataSourceCabecera);
                  RptImpresion.LocalReport.DataSources.Add(Presenter.RepDataSourceDetalleTransporte);
                  RptImpresion.LocalReport.DataSources.Add(Presenter.RepDataSourceDetalleAduana);
                  RptImpresion.LocalReport.DataSources.Add(Presenter.RepDataSourceDetalleOtrosServicios);  

              }
              else if (!String.IsNullOrEmpty(Presenter.TipoReporte) && Presenter.TipoReporte.Equals("SinServicioLogistico"))// Sin Servicio Logistico 
              {
                  RptImpresion.LocalReport.DataSources.Add(Presenter.RepDataSourceCabecera);
                  RptImpresion.LocalReport.DataSources.Add(Presenter.RepDataSourceDetalleTransporte);
                  RptImpresion.LocalReport.DataSources.Add(Presenter.RepDataSourceDetalleAduana);
                  RptImpresion.LocalReport.DataSources.Add(Presenter.RepDataSourceDetalleOtrosServicios);   
              }
              RptImpresion.LocalReport.ReportPath = Presenter.ReportPath;
              RptImpresion.LocalReport.SetParameters(Presenter.Parameters);
              RptImpresion.LocalReport.Refresh();
              RptImpresion.DocumentMapCollapsed = true;
              RptImpresion.RefreshReport();
          }
          catch (Exception ex)
          { Dialogos.MostrarMensajeError(Presenter.Titulo, "Ha ocurrido un error de al mostrar el reporte.", ex); }
      }
      #endregion

      #region [ Metodos ]
      
      #endregion

      #region [ Eventos ]

      void PRO005RView_FormClosing(object sender, FormClosingEventArgs e)
      {
          try
          { RptImpresion.LocalReport.ReleaseSandboxAppDomain();
          RptImpresion.LocalReport.Dispose();
          RptImpresion.Reset();
          }
          catch (Exception ex) { Dialogos.MostrarMensajeError(Presenter.Titulo, "Ha ocurrido un error al cerrar el formulario.", ex); }
      }
      void PRO005RView_Load(object sender, EventArgs e)
      {
          try
          {

          }
          catch (Exception ex)
          { Dialogos.MostrarMensajeError(Presenter.Titulo, Mensajes.LoadView, ex); }
      }
      private void btnSalir_Click(object sender, EventArgs e)
      {
          try
          { Close(); }
          catch (Exception ex)
          { Dialogos.MostrarMensajeError(Presenter.Titulo, "Ha ocurrido un error al cerrar el formulario.", ex); }
      }
      
      #endregion
      
   }
}
