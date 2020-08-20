using System;
using System.IO;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Data.Sql;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Net.Mail;
using System.Configuration;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraRichEdit;
using MessageSender;

namespace Delfin.Principal.Procesos.Facturacion   
{
        public partial class PRO007RViewRC : Form
    {

	    internal DataTable dtPrint = new DataTable();
	    internal ArrayList aParams = new ArrayList();
        internal string RptFile, eMail;
        internal Boolean bSendMail = false;
            
        public PRO007RViewRC()
        {
            InitializeComponent();
        }

        private void PRO007RViewRC_Load(object sender, EventArgs e)
        {
            CrystalDecisions.CrystalReports.Engine.ReportDocument drPrint = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
            DataRow oRow = dtPrint.Rows[0];
            String sFile = ConfigurationManager.AppSettings["pathpdfRecibos"] + "RC-" + oRow["DOCV_Serie"] + "-" + oRow["DOCV_Numero"] + ".pdf";
            try
            {
                drPrint.FileName = System.IO.Directory.GetCurrentDirectory() + "\\Reportes\\" + RptFile;
                drPrint.SetDataSource(dtPrint);
                for (int p = 0; p <= aParams.Count - 1; p++)
                {
                    drPrint.SetParameterValue(p, aParams[p]);
                }
                if (!File.Exists(sFile))
                { 
                    drPrint.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, sFile);
                    SendMessage(sFile, oRow);
                }
                CrystalReportViewer.ReportSource = drPrint;
            }
            catch (Exception ex)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        private void SendMessage(string sFile, DataRow drSource)
        {
            MessageSender.SendMessage oSendMail = new MessageSender.SendMessage();
            MailMessage _message = new MailMessage();
            RichEditControl _BodyHtml = new RichEditControl();
            _BodyHtml.LoadDocument("MensajeEmisionRecibo.doc", DevExpress.XtraRichEdit.DocumentFormat.Doc);
            _message.Subject = drSource["TipoDocumento"] + " Nº " + drSource["DOCV_Serie"] + "-" + drSource["DOCV_Numero"];
                _message.From = new MailAddress("delfin@delfingroupco.com.pe", "Delfin Group Co. SAC");
                _message.IsBodyHtml = true;
                _message.Body = _BodyHtml.HtmlText;
                _message.Priority = MailPriority.Normal;
                _message.To.Add(eMail);
                //_message.To.Add("ferarell@hotmail.com");
                //_message.Bcc.Add("itsupport@delfingroupco.com.pe");
                if (sFile != null)
                    _message.Attachments.Add(new Attachment(sFile));
                oSendMail.SendMail(_message, false, null);
        }

        private void CrystalReportViewer_Load(object sender, EventArgs e)
        {
            
        }

        private void CrystalReportViewer_Click(object sender, EventArgs e)
        {
            
        }

        #region [ Propiedades ]

        public PRO007Presenter Presenter { get; set; }

        #endregion
    }

}