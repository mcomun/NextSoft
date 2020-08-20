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
using Delfin.Controls;

namespace Delfin.Principal
{
   public partial class PRO010RView : Form, IPRO010RView
   {
      #region [ Propiedades ]
      public PRO010Presenter Presenter { get; set; }
      ToolStripMenuItem tsmTodos;
      String[] defaultColumns;
      Int32 _CAJA_Codigo;
      #endregion
      public PRO010RView()
      {
         InitializeComponent();
         try
         {
            btnMAN_salir.Click += btnSalir_Click;
            Load += PRO010RView_Load;
            FormClosing += PRO010RView_FormClosing;
         }
         catch (Exception ex)
         { Dialogos.MostrarMensajeError(Presenter.Title, Mensajes.ConstructorView, ex); }
      }
      #region [ Eventos ]

      void PRO010RView_FormClosing(object sender, FormClosingEventArgs e)
      {
         try
         {
            RptImpresion.LocalReport.ReleaseSandboxAppDomain();
            RptImpresion.LocalReport.Dispose();
            RptImpresion.Reset();
         }
         catch (Exception ex) { Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al cerrar el formulario.", ex); }
      }
      void PRO010RView_Load(object sender, EventArgs e)
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

      public void ShowReporte(Int32 x_CAJA_Codigo)
      {
         try
         {
            RptImpresion.LocalReport.ReleaseSandboxAppDomain();
            RptImpresion.Reset();

            RptImpresion.ProcessingMode = ProcessingMode.Local;
            RptImpresion.LocalReport.DataSources.Clear();

            ReportDataSource RptDataSource;

            DataTable _dt;

            _dt = Presenter.GetComprobante(x_CAJA_Codigo);

            _dt.Rows[0]["MontoLetras"] = Utilitarios.NumeroALetras(_dt.Rows[0]["RCImporte"].ToString(), "");
            _dt.Rows[0]["Usuario"] = Presenter.Session.UserName + "-" + DateTime.Now.ToString();
            RptDataSource = new ReportDataSource("DTPagos", _dt);
            RptImpresion.LocalReport.DataSources.Clear();
            RptImpresion.LocalReport.DataSources.Add(RptDataSource);
            RptImpresion.LocalReport.ReportPath = Application.StartupPath + @"\Reportes\RptComprobante.rdlc"; 
            RptImpresion.LocalReport.Refresh();
            RptImpresion.DocumentMapCollapsed = true;
            RptImpresion.RefreshReport();
         }
         catch (Exception ex)
         { Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error de al mostrar el reporte.", ex); }
      }
   }
}
