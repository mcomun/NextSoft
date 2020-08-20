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
    public partial class PRO007RView : Form, IPRO007RView
   {
      #region [ Variables ]
       
      #endregion

      #region [ Propiedades ]
      public PRO007Presenter Presenter { get; set; }
      #endregion

      #region [ Formulario ]
      public PRO007RView()
      {
         InitializeComponent();
         try
         {
             btnMAN_salir.Click += btnSalir_Click;
             //Load += PRO007RView_Load;
             FormClosing += PRO007RView_FormClosing;

             this.RptImpresion.ProcessingMode = ProcessingMode.Local;
         }
         catch (Exception ex)
         { Dialogos.MostrarMensajeError(Presenter.Title, Mensajes.ConstructorView, ex); }
      }
      #endregion

      #region [ IPRO007RView ]
      public void ShowReporte()
      {
          try
          {
              RptImpresion.LocalReport.ReleaseSandboxAppDomain();
              RptImpresion.Reset();
              RptImpresion.ProcessingMode = ProcessingMode.Local;
              RptImpresion.LocalReport.DataSources.Clear();
              RptImpresion.LocalReport.DataSources.Add(Presenter.RepDataSourceCabecera);
              RptImpresion.LocalReport.DataSources.Add(Presenter.RepDataSourceDetalle);
              RptImpresion.LocalReport.ReportPath = Presenter.ReportPath;
              RptImpresion.LocalReport.SetParameters(Presenter.Parameters);
              RptImpresion.LocalReport.Refresh();
              RptImpresion.RefreshReport();
          }
          catch (Exception ex)
          { Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error de al mostrar el reporte.", ex); }
      }
      #endregion

      #region [ Metodos ]
      
      #endregion

      #region [ Eventos ]

      void PRO007RView_FormClosing(object sender, FormClosingEventArgs e)
      {
          try
          {
             RptImpresion.LocalReport.ReleaseSandboxAppDomain();
             RptImpresion.LocalReport.ReleaseSandboxAppDomain();
             RptImpresion.LocalReport.Dispose();
             RptImpresion.Reset();
          }
          catch (Exception ex) { Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al cerrar el formulario.", ex); }
      }
      void PRO007RView_Load(object sender, EventArgs e)
      {
          try
          {
             StartPosition= FormStartPosition.CenterScreen;
              WindowState = FormWindowState.Maximized;
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
