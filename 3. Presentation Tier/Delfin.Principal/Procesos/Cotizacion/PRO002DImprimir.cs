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
   public partial class PRO002DImprimir : Form, IPRO002DImprimir
   {
      #region [ Variables ]
       
      #endregion

      #region [ Propiedades ]
      public PRO002Presenter Presenter { get; set; }
      #endregion

      #region [ Formulario ]
      public PRO002DImprimir()
      {
         InitializeComponent();
         try
         {
             btnMAN_salir.Click += btnSalir_Click;
             Load += PRO002DImprimir_Load;
             FormClosing += PRO002DImprimir_FormClosing;
         }
         catch (Exception ex)
         { Dialogos.MostrarMensajeError(Presenter.Title, Mensajes.ConstructorView, ex); }
      }

      #endregion
      #region [ IPRO002DImprimir ]
      public void ShowReporte()
      {
         try
         {
            RptImpresion.LocalReport.ReleaseSandboxAppDomain();
            RptImpresion.Reset();
            RptImpresion.ProcessingMode = ProcessingMode.Local;
            RptImpresion.LocalReport.DataSources.Clear();
            RptImpresion.LocalReport.DataSources.Add(Presenter.RepDataSourceCotizacion);
            RptImpresion.LocalReport.ReportPath = Presenter.ReportPath;
            RptImpresion.LocalReport.Refresh();
            RptImpresion.RefreshReport();
         }
         catch (Exception ex)
         { Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error de al mostrar el reporte.", ex); }
      }
      #endregion

      #region [ Eventos ]

      void PRO002DImprimir_FormClosing(object sender, FormClosingEventArgs e)
      {
         try
         {
            RptImpresion.LocalReport.ReleaseSandboxAppDomain();
            RptImpresion.LocalReport.Dispose();
            RptImpresion.Reset();
         }
         catch (Exception ex) { Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al cerrar el formulario.", ex); }
      }
      void PRO002DImprimir_Load(object sender, EventArgs e)
      {
         try
         {

         }
         catch (Exception ex)
         { Dialogos.MostrarMensajeError(Presenter.Title, Mensajes.LoadView, ex); }
      }
      private void btnSalir_Click(object sender, EventArgs e)
      {
         try
         { Close(); }
         catch (Exception ex)
         { Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al cerrar el formulario.", ex); }
      }

      #endregion
   }
}
