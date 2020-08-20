using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.IO;
using System.Text;
using System.Windows.Forms;
using Infrastructure.Aspect.Constants;
using Infrastructure.WinFormsControls;
using Microsoft.Reporting.WinForms;

namespace Delfin.Principal
{
    public partial class PRO007RViewFE : DevExpress.XtraEditors.XtraForm
   {
      #region [ Variables ]
       
      #endregion

      #region [ Propiedades ]
      public PRO007Presenter Presenter { get; set; }
      public String pathpdf { get; set; }
      #endregion

      #region [ Formulario ]
      public PRO007RViewFE()
      {
         InitializeComponent();
         
      }
      #endregion

      private void PRO007RViewFE_Load(object sender, EventArgs e)
      {
          if (System.IO.File.Exists(pathpdf))
          {
              try
              {
                pdfViewerDocs.LoadDocument(pathpdf);
                pdfViewerDocs.ZoomMode = DevExpress.XtraPdfViewer.PdfZoomMode.FitToVisible;
              }
              catch (Exception)
              {  }
          }
          
      }

      private void pdfFileSaveBarItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
      {
          saveFileDialog1.Filter = "PDF file (*.pdf)|*.pdf";
          saveFileDialog1.FileName = Path.GetFileName(pathpdf);
          if (saveFileDialog1.ShowDialog() == DialogResult.OK)
          {
              string newFile = saveFileDialog1.FileName; // Path.GetFileName(pathpdf);
              File.Copy(pathpdf, newFile);
          }
      }

      
      


      
   }
}
