using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;

using System.Reflection;
using System.Drawing.Printing;


using System.Runtime.InteropServices;
using System.Drawing.Printing;

namespace Delfin.Principal
{
   public partial class Visualizador : Form
   {
      #region [ Variables ]
      private DataTable DTReporte;

      private String Title;
      private String ReportPath;
      private ReportDataSource ReportSource;
      private ReportDataSource ReportSourceDetalle;
      Microsoft.Reporting.WinForms.ReportParameter[] ReportParameters;
      private Dictionary<String, ReportDataSource> SubReportsSource;
      private Dictionary<String, ReportParameter[]> SubReportsParameter;
      #endregion

      #region [ Formulario ]
      public Visualizador(DataTable x_datos)
      {
         InitializeComponent();
         try
         {
            DTReporte = x_datos;
         }
         catch (Exception)
         { }
      }
      public Visualizador(String x_title, String x_reportpath, ReportDataSource x_report)
      {
         try
         {
            InitializeComponent();
            Title = x_title;
            ReportPath = x_reportpath;
            ReportSource = x_report;
         }
         catch (Exception)
         { }
      }
      public Visualizador(String x_title, String x_reportpath, ReportDataSource x_report, Microsoft.Reporting.WinForms.ReportParameter[] x_parameters)
      {
         try
         {
            InitializeComponent();
            Title = x_title;
            ReportPath = x_reportpath;
            ReportSource = x_report;
            ReportParameters = x_parameters;
         }
         catch (Exception)
         { }
      }
      public Visualizador(String x_title, String x_reportpath, ReportDataSource x_reportCabecera, ReportDataSource x_reportDetalle, Microsoft.Reporting.WinForms.ReportParameter[] x_parameters)
      {
         try
         {
            InitializeComponent();
            Title = x_title;
            ReportPath = x_reportpath;
            ReportSource = x_reportCabecera;
            ReportSourceDetalle = x_reportDetalle;
            ReportParameters = x_parameters;
         }
         catch (Exception)
         { }
      }
      public Visualizador(String x_title, String x_reportpath, ReportDataSource x_report, Dictionary<String, ReportDataSource> x_subreports)
      {
         InitializeComponent();
         try
         {
            Title = x_title;
            ReportPath = x_reportpath;
            ReportSource = x_report;
            SubReportsSource = x_subreports;
         }
         catch (Exception)
         { }
      }
      public Visualizador(String x_title, String x_reportpath, ReportDataSource x_report, Microsoft.Reporting.WinForms.ReportParameter[] x_parameters, Dictionary<String, ReportDataSource> x_subreports, Dictionary<String, Microsoft.Reporting.WinForms.ReportParameter[]> x_subreportsParametros = null)
      {
         InitializeComponent();
         try
         {
            Title = x_title;
            ReportPath = x_reportpath;
            ReportSource = x_report;
            ReportParameters = x_parameters;
            SubReportsSource = x_subreports;
            SubReportsParameter = x_subreportsParametros;
         }
         catch (Exception)
         { }
      }

      private void Visualizador_Load(object sender, EventArgs e)
      { 
         //this.reportViewer.RefreshReport(); 
      }
      #endregion

      #region [ Propiedades ]
      public ReportViewer Viewer { get { return this.reportViewer; } }
      #endregion

      #region [ Metodos ]
      public void Imprimir(String nombre, String path, Microsoft.Reporting.WinForms.ReportParameter[] Parameters)
      {
         try
         {
            Microsoft.Reporting.WinForms.ReportDataSource rds = new Microsoft.Reporting.WinForms.ReportDataSource();
            rds.Name = nombre;
            rds.Value = DTReporte;

            this.reportViewer.Reset();
            this.reportViewer.ProcessingMode = Microsoft.Reporting.WinForms.ProcessingMode.Local;
            this.reportViewer.LocalReport.EnableExternalImages = true;

            this.reportViewer.LocalReport.DataSources.Clear();
            this.reportViewer.LocalReport.DataSources.Add(rds);

            this.reportViewer.LocalReport.ReportPath = Application.StartupPath + path;
            if (Parameters != null) { this.reportViewer.LocalReport.SetParameters(Parameters); }

            this.reportViewer.LocalReport.SubreportProcessing += LocalReport_SubreportProcessing;

            this.reportViewer.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout);
            this.reportViewer.ZoomMode = Microsoft.Reporting.WinForms.ZoomMode.PageWidth;

            this.reportViewer.RefreshReport();
            this.reportViewer.LocalReport.Refresh();
         }
         catch (Exception)
         { throw; }
      }
      public void Imprimir(Boolean x_imprimir = false)
      {
         try
         {
            this.reportViewer.Reset();
            this.reportViewer.ProcessingMode = Microsoft.Reporting.WinForms.ProcessingMode.Local;
            this.reportViewer.LocalReport.EnableExternalImages = true;

            this.reportViewer.LocalReport.DataSources.Clear();
            this.reportViewer.LocalReport.DataSources.Add(ReportSource);

            if (ReportSourceDetalle != null)
            { this.reportViewer.LocalReport.DataSources.Add(ReportSourceDetalle); }
                        
            this.reportViewer.LocalReport.ReportPath = ReportPath;
            if (ReportParameters != null) { this.reportViewer.LocalReport.SetParameters(ReportParameters); }

            this.reportViewer.LocalReport.SubreportProcessing += LocalReport_SubreportProcessing;

            this.reportViewer.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout);
            this.reportViewer.ZoomMode = Microsoft.Reporting.WinForms.ZoomMode.PageWidth;

            if (x_imprimir)
            { this.reportViewer.RenderingComplete += reportViewer_RenderingComplete; }
            else
            {
               this.reportViewer.RefreshReport();
               this.reportViewer.LocalReport.Refresh();
            }
         }
         catch (Exception)
         { throw; }
      }
      public void ShowReporte(Boolean x_imprimir = false)
      {
         try
         {
            this.reportViewer.Reset();
            this.reportViewer.ProcessingMode = Microsoft.Reporting.WinForms.ProcessingMode.Local;
            this.reportViewer.LocalReport.EnableExternalImages = true;

            this.reportViewer.LocalReport.DataSources.Clear();
            this.reportViewer.LocalReport.DataSources.Add(ReportSource);

            if (ReportSourceDetalle != null)
            { this.reportViewer.LocalReport.DataSources.Add(ReportSourceDetalle); }

            this.reportViewer.LocalReport.ReportPath = ReportPath;
            
            if (ReportParameters != null) { this.reportViewer.LocalReport.SetParameters(ReportParameters); }

            this.reportViewer.LocalReport.SubreportProcessing += LocalReport_SubreportProcessing;

            this.reportViewer.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout);
            this.reportViewer.ZoomMode = Microsoft.Reporting.WinForms.ZoomMode.PageWidth;

            this.reportViewer.RefreshReport();
            this.reportViewer.LocalReport.Refresh();

            if (x_imprimir)
            { this.reportViewer.RenderingComplete += reportViewer_RenderingComplete; }
         }
         catch (Exception)
         { throw; }
      }
      #endregion

      #region [ Eventos ]
      private void LocalReport_SubreportProcessing(object sender, SubreportProcessingEventArgs e)
      {
         try
         {
            if (SubReportsSource != null && SubReportsSource.ContainsKey(e.ReportPath))
            {
               e.DataSources.Clear();
               e.DataSources.Add(SubReportsSource[e.ReportPath]);
               if(SubReportsParameter != null && SubReportsParameter.ContainsKey(e.ReportPath))
               {
                  ((LocalReport)sender).SetParameters(SubReportsParameter[e.ReportPath]);
                  //e.Parameters.(SubReportsParameter[e.ReportPath]);
               }
            }
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Title, "Ha ocurrido un error cargando los subreportes.", ex); }
      }
      private void reportViewer_RenderingComplete(object sender, RenderingCompleteEventArgs e)
      {
         try
         {
            //this.reportViewer.PrintDialog(); 
            if (ListoImprimir != null)
            { ListoImprimir(this.reportViewer); }

            //PrintwithDialog(this.reportViewer);
         }
         catch (Exception)
         { }
      }

      public delegate void ReporteImprimir(ReportViewer e);
      public event ReporteImprimir ListoImprimir;
      #endregion
   }

   public static class PrintReportViewer
   {
      internal static object ExecuteFunction(object obj, object[] parms, string fnName)
      {
         Type t = obj.GetType();
         MethodInfo[] infos = t.GetMethods(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance);
         var c = from pe in infos where pe.Name == fnName select pe;
         foreach (MethodInfo info in c)
         {
            return info.Invoke(obj, parms);
         }
         return null;


      }
      static object GetPropertyVal(object obj, string properityName)
      {
         Type t = obj.GetType();
         PropertyInfo info = t.GetProperty(properityName, BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance);
         return info.GetValue(obj, null);

      }
      public static void WriteProperityVal(object srcobj, object val, string properityName)
      {
         var infos = from inf in srcobj.GetType().GetProperties() where inf.Name == properityName select inf;
         foreach (PropertyInfo inf in infos)
         {
            inf.SetValue(srcobj, val, null);

         }

      }
      public static void PrintByPriner(Microsoft.Reporting.WinForms.ReportViewer viewer, string Printername)
      {
         //viewer.RefreshReport();
         //viewer.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout);
         PageSettings pagesettings = viewer.GetPageSettings();
         object objviewer = viewer;
         FieldInfo info = viewer.GetType().GetField("m_lastUIState", BindingFlags.FlattenHierarchy | BindingFlags.IgnoreCase | BindingFlags.Instance | BindingFlags.NonPublic);
         object m_lastUIState = info.GetValue(objviewer);
         object PostRenderArgs = null;
         var variables = from nn in viewer.GetType().Assembly.GetTypes() where nn.Name.Contains("ReportViewerStatus") || nn.Name.Contains("PostRenderArgs") select nn;
         foreach (Type type in variables)
         {
            if (type.Name.Contains("ReportViewerStatus"))
            {
               object[] prms = { m_lastUIState };
               ExecuteFunction(type, prms, "DoesStateAllowPrinting");
            }
            if (type.Name.Contains("PostRenderArgs"))
            {
               object[] ooo = { false, false };
               PostRenderArgs = Activator.CreateInstance(type, ooo);
            }
         }
         object pr = ExecuteFunction(objviewer, null, "CreateDefaultPrintSettings");
         (pr as System.Drawing.Printing.PrinterSettings).Copies = 1;
         //(pr as System.Drawing.Printing.PrinterSettings).PrinterName =  Printername ;

         {
            object[] prms = { objviewer, pr };
            ExecuteFunction(objviewer, prms, "OnPrintingBegin");
         }
         object[] processprms = { 0, 0 };
         string deviceInfo = ExecuteFunction(objviewer, processprms, "CreateEMFDeviceInfo").ToString();
         ExecuteFunction(objviewer, null, "ProcessAsyncInvokes");
         WriteProperityVal(objviewer, true, "PrintDialogDisplayed");
         //object[] parms = { "IMAGE", true, deviceInfo, Microsoft.Reporting.WinForms.PageCountMode.Estimate, report.CreateAndRegisterStream, report.AsyncCompletedEventHandler, PostRenderArgs, false };
         //ExecuteFunction(objviewer, parms, "BeginAsyncRender");
         object currentReport = GetPropertyVal(objviewer, "CurrentReport");
         object fileManager = GetPropertyVal(currentReport, "FileManager");

         object ReportPrintDocument = null;
         var variables2 = from nn in viewer.GetType().Assembly.GetTypes() where nn.Name.Contains("ReportPrintDocument") select nn;
         foreach (Type type in variables2)
         {


            object[] parms2 = { fileManager, pagesettings.Clone() };
            ConstructorInfo ci = type.GetConstructor(BindingFlags.NonPublic | BindingFlags.Instance, null, new Type[] { fileManager.GetType(), typeof(PageSettings) }, null);
            ReportPrintDocument = ci.Invoke(parms2);

            WriteProperityVal(ReportPrintDocument, pr, "PrinterSettings");
            WriteProperityVal(ReportPrintDocument, "Title", "DocumentName");
            ExecuteFunction(ReportPrintDocument, null, "Print");
         }

      }

      [DllImport("winspool.drv", CharSet = CharSet.Auto, SetLastError = true)]
      public static extern bool GetDefaultPrinter(StringBuilder pszBuffer, ref int size);
   }
}