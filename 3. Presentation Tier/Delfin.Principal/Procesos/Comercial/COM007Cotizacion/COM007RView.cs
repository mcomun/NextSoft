using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Delfin.Principal
{
   public partial class COM007RView : Form, ICOM007RView
   {
      #region [ Variables ]

      #endregion

      #region [ Formulario ]
      public COM007RView()
      {
         InitializeComponent();
         rvwReporte.ReportExport += rvwReporte_ReportExport;
      }
      #endregion
      
      #region [ Propiedades ]
      public COM007Presenter Presenter { get; set; }
      #endregion

      #region [ ICOM007RView ]
      public void ShowItems()
      {
         try
         {
            rvwReporte.LocalReport.DataSources.Clear();
            if (this.Presenter.RepDataSourceFlete != null) { rvwReporte.LocalReport.DataSources.Add(this.Presenter.RepDataSourceFlete); }
            if (this.Presenter.RepDataSourceService != null) { rvwReporte.LocalReport.DataSources.Add(this.Presenter.RepDataSourceService); }
            rvwReporte.LocalReport.ReportPath = this.Presenter.ReportPath;
            rvwReporte.LocalReport.SetParameters(this.Presenter.Parameters);

            rvwReporte.LocalReport.SubreportProcessing += LocalReport_SubreportProcessing;

            rvwReporte.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout);
            rvwReporte.ZoomMode = Microsoft.Reporting.WinForms.ZoomMode.PageWidth;

            rvwReporte.LocalReport.Refresh();
            rvwReporte.RefreshReport();
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error cargando los items.", ex); }
      }
      #endregion

      #region [ Metodos ]
      private string GetRenderingExtension(Microsoft.Reporting.WinForms.RenderingExtension extension)
      {
         switch (extension.Name.ToUpper())
         {
            case "PDF":
               return ".pdf";
            case "CSV":
               return ".csv";
            case "EXCEL":
               return ".xls";
            case "MHTML":
               return ".mhtml";
            case "IMAGE":
               return ".tif";
            case "XML":
               return ".xml";
            case "WORD":
               return ".doc";
            case "HTML4.0":
               return ".html";
            case "NULL":
               throw new NotImplementedException("Extension not implemented.");
         }
         throw new NotImplementedException("Extension not implemented.");
      }
      #endregion

      #region [ Eventos ]
      private void LocalReport_SubreportProcessing(object sender, Microsoft.Reporting.WinForms.SubreportProcessingEventArgs e)
      {
         try
         {
            if (e.ReportPath == "rptCOM007CotizacionFlete")
            {
               e.DataSources.Clear();
               e.DataSources.Add(this.Presenter.RepDataSourceFlete);
            }
            else if (e.ReportPath == "rptCOM007CotizacionServicios")
            {
               e.DataSources.Clear();
               e.DataSources.Add(this.Presenter.RepDataSourceService);
            }
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error cargando los subreportes.", ex); }
      }
      private void rvwReporte_ReportExport(object sender, Microsoft.Reporting.WinForms.ReportExportEventArgs e)
      {
         e.Cancel = true;
         string extension = GetRenderingExtension(e.Extension);

         SaveFileDialog saveFileDialog = new SaveFileDialog()
         {
            Title = "Save As",
            CheckPathExists = true,
            InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
            Filter = e.Extension.LocalizedName + " (*" + extension + ")|*" + extension + "|All files(*.*)|*.*",
            FilterIndex = 0
         };

         if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
         {
            this.rvwReporte.ExportDialog(e.Extension, e.DeviceInfo, saveFileDialog.FileName);
            Process.Start(saveFileDialog.FileName);
         }
      }
      #endregion
   }
}
