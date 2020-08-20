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
    public partial class PRO007RMView : Form, IPRO007RMView
   {
      #region [ Variables ]
       
      #endregion

      #region [ Propiedades ]
      public REP007Presenter Presenter { get; set; }
      #endregion

      #region [ Formulario ]
      public PRO007RMView()
      {
         InitializeComponent();
         try
         {
             btnMAN_salir.Click += btnSalir_Click;
             Load += PRO007RMView_Load;
             FormClosing += PRO007RMView_FormClosing;
         }
         catch (Exception ex)
         { Dialogos.MostrarMensajeError(Presenter.Titulo, Mensajes.ConstructorView, ex); }
      }
      #endregion

      #region [ IPRO007RMView ]
      public void ShowReporte()
      {
          try
          {
             RptImpresion.LocalReport.ReleaseSandboxAppDomain();
              RptImpresion.Reset();
              RptImpresion.ProcessingMode = ProcessingMode.Local;
              RptImpresion.LocalReport.DataSources.Clear();
              RptImpresion.LocalReport.DataSources.Add(Presenter.RepDataSource);
              RptImpresion.LocalReport.ReportPath = Presenter.ReportPath;
              //RptImpresion.LocalReport.SetParameters(Presenter.Parameters);
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

      void PRO007RMView_FormClosing(object sender, FormClosingEventArgs e)
      {
          try
          { RptImpresion.LocalReport.ReleaseSandboxAppDomain();
          RptImpresion.LocalReport.Dispose();
          RptImpresion.Reset();
          }
          catch (Exception ex) { Dialogos.MostrarMensajeError(Presenter.Titulo, "Ha ocurrido un error al cerrar el formulario.", ex); }
      }
      void PRO007RMView_Load(object sender, EventArgs e)
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
