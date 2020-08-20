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
    public partial class PRO006RView : Form, IPRO006RView
   {
      #region [ Variables ]
       
      #endregion

      #region [ Propiedades ]
      public REP006Presenter Presenter { get; set; }
      #endregion

      #region [ Formulario ]
      public PRO006RView()
      {
         InitializeComponent();
         try
         {
             btnMAN_salir.Click += btnSalir_Click;
             Load += PRO006RView_Load;
             FormClosing += PRO006RView_FormClosing;
         }
         catch (Exception ex)
         { Dialogos.MostrarMensajeError(Presenter.Titulo, Mensajes.ConstructorView, ex); }
      }
      #endregion

      #region [ IPRO006RView ]
      public void ShowReporte()
      {
          try
          {
              RptImpresion.LocalReport.ReleaseSandboxAppDomain();
              RptImpresion.Reset();
              RptImpresion.ProcessingMode = ProcessingMode.Local;
              RptImpresion.LocalReport.DataSources.Clear();
             if(Presenter.RepDataSourceTarjas != null)
                  RptImpresion.LocalReport.DataSources.Add(Presenter.RepDataSourceTarjas);
             if (Presenter.RepDataSourceReBate != null)
               RptImpresion.LocalReport.DataSources.Add(Presenter.RepDataSourceReBate);
              RptImpresion.LocalReport.ReportPath = Presenter.ReportPath;
              RptImpresion.LocalReport.SetParameters(Presenter.Parameters);
              RptImpresion.LocalReport.Refresh();
              RptImpresion.RefreshReport();
          }
          catch (Exception ex)
          { Dialogos.MostrarMensajeError(Presenter.Titulo, "Ha ocurrido un error de al mostrar el reporte.", ex); }
      }
      #endregion

      #region [ Metodos ]
      
      #endregion

      #region [ Eventos ]

      void PRO006RView_FormClosing(object sender, FormClosingEventArgs e)
      {
          try
          { RptImpresion.LocalReport.ReleaseSandboxAppDomain();
          RptImpresion.LocalReport.Dispose();
          RptImpresion.Reset();
          }
          catch (Exception ex) { Dialogos.MostrarMensajeError(Presenter.Titulo, "Ha ocurrido un error al cerrar el formulario.", ex); }
      }
      void PRO006RView_Load(object sender, EventArgs e)
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
