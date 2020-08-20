using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data;
using eFactDelfin.eFactService;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.Script.Serialization;
using System.Net;
using System.Diagnostics;

namespace eFactDelfin
{
    public class eFacturacionElectronica
    {
        string connStr = ConfigurationManager.AppSettings["dbNextSoft"];
        string RUC = ConfigurationManager.AppSettings["RUC"];
        int TiempoEsperaPdf = Convert.ToInt32(ConfigurationManager.AppSettings["TiempoEsperaPdf"]); 
        TransactionServiceClient Cliente = new TransactionServiceClient();
        string TipoDocumento = "";
        //public void ProcesarFacturacionElectronica(DataTable dtFactura, string pathcsv , string pathpdf)
        public DataTable ProcesarFacturacionElectronica(String CodigoDocumento, String Email, String Usuario)
        {
            string pathlog = ConfigurationManager.AppSettings["pathlog"];
            String FechaLog = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString("00") + DateTime.Now.Day.ToString("00");
            String RutaCompletaLog = pathlog + "Log" + FechaLog + ".txt";
            DataTable dtResultado = new DataTable();
            DataRow row = dtResultado.NewRow();
            

            dtResultado.Columns.Add("pathpdf", typeof(String));
            dtResultado.Columns.Add("resultado", typeof(String));
            dtResultado.Columns.Add("mensajeerror", typeof(String));  
            
            
            try
            {

            


            DataTable dtLineas = new DataTable();
            dtLineas=GetLineasFacturacionElectronica(CodigoDocumento,Email);
            TipoDocumento = Convert.ToString(dtLineas.Rows[0]["tipodocumento"]);       
            
            
            
            
            List<string> texto = new List<string>();
            if (TipoDocumento=="001")
            {

                texto.Add(Convert.ToString(dtLineas.Rows[0]["Linea1"]));
                texto.Add(Convert.ToString(dtLineas.Rows[0]["Linea2"]));
                texto.Add(Convert.ToString(dtLineas.Rows[0]["Linea3"]));
                texto.Add(Convert.ToString(dtLineas.Rows[0]["Linea4"]));
                texto.Add(Convert.ToString(dtLineas.Rows[0]["Linea5"]));
                texto.Add(Convert.ToString(dtLineas.Rows[0]["Linea6"]));
                texto.Add(Convert.ToString(dtLineas.Rows[0]["Linea7"]));
                texto.Add(Convert.ToString(dtLineas.Rows[0]["Linea8"]));
                texto.Add(Convert.ToString(dtLineas.Rows[0]["Linea9"]));
                texto.Add(Convert.ToString(dtLineas.Rows[0]["Linea10"]));
                String Codigo = Convert.ToString(dtLineas.Rows[0]["codigo"]);
                String NumeroSunat = Convert.ToString(dtLineas.Rows[0]["numerosunat"]);

                string pathcsv = ConfigurationManager.AppSettings["pathcsvFacturas"];
                string pathpdf = ConfigurationManager.AppSettings["pathpdfFacturas"];
                string pathcdr = ConfigurationManager.AppSettings["pathcdrFacturas"];
                string pathxml = ConfigurationManager.AppSettings["pathxmlFacturas"];
                string FechaImpresion = DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString("00") + DateTime.Now.Year.ToString("00") + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString();
               
                //VerificarPermisos

                System.Security.AccessControl.FileSecurity Permisoscsv = File.GetAccessControl(pathcsv);
                System.Security.AccessControl.FileSecurity Permisospdf = File.GetAccessControl(pathpdf);
                System.Security.AccessControl.FileSecurity Permisoscdr = File.GetAccessControl(pathcdr);
                System.Security.AccessControl.FileSecurity Permisosxml = File.GetAccessControl(pathxml);
                System.Security.AccessControl.FileSecurity Permisoslog = File.GetAccessControl(pathlog);





                //String RutaCompletacsv = pathcsv + NumeroSunat + "_" + Codigo + "_" + FechaImpresion +".csv";
                String RutaCompletacsv = pathcsv + RUC + "-" + TipoDocumento.Substring(1) + "-" + NumeroSunat + ".csv";
                String RutaCompletapdf = pathpdf + RUC + "-" + TipoDocumento.Substring(1) + "-" + NumeroSunat + ".pdf";
                String RutaCompletacdr = pathcdr + RUC + "-" + TipoDocumento.Substring(1) + "-" + NumeroSunat + ".xml";
                String RutaCompletaxml = pathxml + RUC + "-" + TipoDocumento.Substring(1) + "-" + NumeroSunat + ".xml";
                
                File.WriteAllLines(RutaCompletacsv, texto);
                Byte[] bytesFactura = File.ReadAllBytes(RutaCompletacsv);

                authorization oautorizacion = new authorization();
                oautorizacion.password = ConfigurationManager.AppSettings["password"];
                oautorizacion.user = ConfigurationManager.AppSettings["usuario"];


                transactionResponseRest otransactionResponse = new transactionResponseRest();
                otransactionResponse = EnviarDocumentoRest(RutaCompletacsv);



                //List<transactionResponse> lTransactionResponse = new List<transactionResponse>(Cliente.sendInvoice(oautorizacion, bytesFactura));

                if (otransactionResponse != null)
                {
                    //transactionResponse otransactionResponse = new transactionResponse();
                    //otransactionResponse = lTransactionResponse[0];
                    //File.WriteAllBytes(pathpdf + "Factura_" + Codigo + "_" + NumeroSunat + "_" + FechaImpresion + ".pdf", lTransactionResponse[0].pdfFile);



                    //transactionResponse otransactionResponse = new transactionResponse();
                    //otransactionResponse = lTransactionResponse[0];



                     string LineaLog = DateTime.Now.ToString().PadRight(20) + "   " +
                                      Usuario.PadRight(20) + "   " +
                                       ("CREACION").PadRight(10) + "   " +
                                       TipoDocumento.PadRight(3) + "   " +
                                       ("FACTURA").PadRight(20) + "   " +
                                       Codigo.PadRight(5) + "   " +
                                       NumeroSunat.PadRight(10) + "   " +
                                       (otransactionResponse.digestValue == null ? "" : otransactionResponse.digestValue).ToString().PadRight(40) + "   " +
                                       (otransactionResponse.identifier == null ? "" : otransactionResponse.identifier).ToString().PadRight(13) + "   " +
                                       (otransactionResponse.outString == null ? "" : otransactionResponse.outString).ToString().PadRight(200) + "   " +
                                       (otransactionResponse.responseCode == null ? "" : otransactionResponse.responseCode.ToString()).ToString().PadRight(5) + "   " +
                                       (otransactionResponse.sunatError == null ? "" : (otransactionResponse.sunatError.message == null ? "" : otransactionResponse.sunatError.message)).ToString().PadRight(100) + "   " +
                                       (otransactionResponse.sunatError == null ? "" : (otransactionResponse.sunatError.sunatErrorCode == null ? "" : otransactionResponse.sunatError.sunatErrorCode.ToString())).ToString().PadRight(10) + "   " +
                                       Environment.NewLine;


                    
                    StreamWriter sw = new StreamWriter(RutaCompletaLog, true);
                    sw.Write(LineaLog);
                    sw.Close();


                    if (otransactionResponse.pdfFile != null)
                    {
                       
                        row["pathpdf"] = RutaCompletapdf;
                        File.WriteAllBytes(RutaCompletapdf, otransactionResponse.pdfFile);

                    }

                    if (otransactionResponse.cdrFile != null)
                    {
                        
                        File.WriteAllBytes(RutaCompletacdr, otransactionResponse.cdrFile);

                    }
                    if (otransactionResponse.xmlSigned != null)
                    {
                       
                        File.WriteAllBytes(RutaCompletaxml, otransactionResponse.xmlSigned);

                    }

                                     


                    if (otransactionResponse.responseCode != 0)
                    {
                        row["resultado"] = "ERROR";
                        row["mensajeerror"] = (otransactionResponse.outString == null ? "" : otransactionResponse.outString).ToString();
                    }
                    else
                    {
                        row["resultado"] = "OK";
                        row["mensajeerror"] = "OK";
                    }


                }
                else
                {
                    row["resultado"] = "ERROR";
                    row["mensajeerror"] = "NO HAY RESPUESTA DE Efact";
                }

                
            }



            if (TipoDocumento == "003")
            {

                texto.Add(Convert.ToString(dtLineas.Rows[0]["Linea1"]));
                texto.Add(Convert.ToString(dtLineas.Rows[0]["Linea2"]));
                texto.Add(Convert.ToString(dtLineas.Rows[0]["Linea3"]));
                texto.Add(Convert.ToString(dtLineas.Rows[0]["Linea4"]));
                texto.Add(Convert.ToString(dtLineas.Rows[0]["Linea5"]));
                texto.Add(Convert.ToString(dtLineas.Rows[0]["Linea6"]));
                texto.Add(Convert.ToString(dtLineas.Rows[0]["Linea7"]));
                texto.Add(Convert.ToString(dtLineas.Rows[0]["Linea8"]));
                texto.Add(Convert.ToString(dtLineas.Rows[0]["Linea9"]));
                texto.Add(Convert.ToString(dtLineas.Rows[0]["Linea10"]));
                String Codigo = Convert.ToString(dtLineas.Rows[0]["codigo"]);
                String NumeroSunat = Convert.ToString(dtLineas.Rows[0]["numerosunat"]);

                string pathcsv = ConfigurationManager.AppSettings["pathcsvBoletas"];
                string pathpdf = ConfigurationManager.AppSettings["pathpdfBoletas"];
                string pathcdr = ConfigurationManager.AppSettings["pathcdrBoletas"];
                string pathxml = ConfigurationManager.AppSettings["pathxmlBoletas"];
                string FechaImpresion = DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString("00") + DateTime.Now.Year.ToString("00") + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString();
                //String FileInvoice = pathcsv + NumeroSunat + "_" + Codigo + "_" + FechaImpresion + ".csv";



                //VerificarPermisos

                System.Security.AccessControl.FileSecurity Permisoscsv = File.GetAccessControl(pathcsv);
                System.Security.AccessControl.FileSecurity Permisospdf = File.GetAccessControl(pathpdf);
                System.Security.AccessControl.FileSecurity Permisoscdr = File.GetAccessControl(pathcdr);
                System.Security.AccessControl.FileSecurity Permisosxml = File.GetAccessControl(pathxml);
                System.Security.AccessControl.FileSecurity Permisoslog = File.GetAccessControl(pathlog);


                //String RutaCompletacsv = pathcsv + NumeroSunat + "_" + Codigo + "_" + FechaImpresion + ".csv";
                //String RutaCompletapdf = pathpdf + NumeroSunat + "_" + Codigo + "_" + FechaImpresion + ".pdf";
                //String RutaCompletacdr = pathcdr + NumeroSunat + "_" + Codigo + "_" + FechaImpresion + ".xml";
                //String RutaCompletaxml = pathxml + NumeroSunat + "_" + Codigo + "_" + FechaImpresion + ".xml";

                String RutaCompletacsv = pathcsv + RUC + "-" + TipoDocumento.Substring(1)  + "-" + NumeroSunat + ".csv";
                String RutaCompletapdf = pathpdf + RUC + "-" + TipoDocumento.Substring(1) + "-" + NumeroSunat + ".pdf";
                String RutaCompletacdr = pathcdr + RUC + "-" + TipoDocumento.Substring(1) + "-" + NumeroSunat + ".xml";
                String RutaCompletaxml = pathxml + RUC + "-" + TipoDocumento.Substring(1) + "-" + NumeroSunat + ".xml";


                File.WriteAllLines(RutaCompletacsv, texto);
                Byte[] bytesBoleta = File.ReadAllBytes(RutaCompletacsv);

                authorization oautorizacion = new authorization();
                oautorizacion.password = ConfigurationManager.AppSettings["password"];
                oautorizacion.user = ConfigurationManager.AppSettings["usuario"];

                //List<transactionResponse> lTransactionResponse = new List<transactionResponse>(Cliente.sendBoleta(oautorizacion, bytesBoleta));

                transactionResponseRest otransactionResponse = new transactionResponseRest();
                otransactionResponse = EnviarDocumentoRest(RutaCompletacsv);



                //List<transactionResponse> lTransactionResponse = new List<transactionResponse>(Cliente.sendInvoice(oautorizacion, bytesFactura));

                if (otransactionResponse != null)
                {
                    //transactionResponse otransactionResponse = new transactionResponse();
                    //otransactionResponse = lTransactionResponse[0];
                    //File.WriteAllBytes(pathpdf + "Boleta_" + Codigo + "_" + NumeroSunat + "_" + FechaImpresion + ".pdf", lTransactionResponse[0].pdfFile);


                    //transactionResponse otransactionResponse = new transactionResponse();
                    //otransactionResponse = lTransactionResponse[0];



                    string LineaLog = DateTime.Now.ToString().PadRight(20) + "   " +
                                       Usuario.PadRight(20) + "   " +
                                       ("CREACION").PadRight(10) + "   " +
                                       TipoDocumento.PadRight(3) + "   " +
                                       ("BOLETA").PadRight(20) + "   " +
                                       Codigo.PadRight(5) + "   " +
                                       NumeroSunat.PadRight(10) + "   " +
                                       (otransactionResponse.digestValue == null ? "" : otransactionResponse.digestValue).ToString().PadRight(40) + "   " +
                                       (otransactionResponse.identifier == null ? "" : otransactionResponse.identifier).ToString().PadRight(13) + "   " +
                                       (otransactionResponse.outString == null ? "" : otransactionResponse.outString).ToString().PadRight(200) + "   " +
                                       (otransactionResponse.responseCode == 0 ? "" : otransactionResponse.responseCode.ToString()).ToString().PadRight(5) + "   " +
                                       (otransactionResponse.sunatError == null ? "" : (otransactionResponse.sunatError.message == null ? "" : otransactionResponse.sunatError.message)).ToString().PadRight(100) + "   " +
                                       (otransactionResponse.sunatError == null ? "" : (otransactionResponse.sunatError.sunatErrorCode == 0 ? "" : otransactionResponse.sunatError.sunatErrorCode.ToString())).ToString().PadRight(10) + "   " +
                                       Environment.NewLine;


                    if (otransactionResponse.pdfFile != null)
                    {
                        //String RutaCompleta = pathpdf + NumeroSunat + "_" + Codigo + "_" + FechaImpresion + ".pdf";
                        row["pathpdf"] = RutaCompletapdf;
                        File.WriteAllBytes(RutaCompletapdf, otransactionResponse.pdfFile);

                    }

                    if (otransactionResponse.cdrFile != null)
                    {
                        //String RutaCompleta = pathcdr + NumeroSunat + "_" + Codigo + "_" + FechaImpresion + ".xml";
                        File.WriteAllBytes(RutaCompletacdr, otransactionResponse.cdrFile);

                    }
                    if (otransactionResponse.xmlSigned != null)
                    {
                        //String RutaCompleta = pathxml + NumeroSunat + "_" + Codigo + "_" + FechaImpresion + ".xml";
                        File.WriteAllBytes(RutaCompletaxml, otransactionResponse.xmlSigned);

                    }


                    


                    //String FechaLog = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString();
                    StreamWriter sw = new StreamWriter(RutaCompletaLog, true);
                    sw.Write(LineaLog);
                    sw.Close();



                    if (otransactionResponse.responseCode != 0)
                    {
                        row["resultado"] = "ERROR";
                        row["mensajeerror"] = (otransactionResponse.outString == null ? "" : otransactionResponse.outString).ToString();
                    }
                    else
                    {
                        row["resultado"] = "OK";
                        row["mensajeerror"] = "OK";
                    }



                }
                else
                {
                    row["resultado"] = "ERROR";
                    row["mensajeerror"] = "NO HAY RESPUESTA DE Efact";
                }


            }



            if (TipoDocumento == "007") // Nota de Credito
            {

                texto.Add(Convert.ToString(dtLineas.Rows[0]["Linea1"]));
                texto.Add(Convert.ToString(dtLineas.Rows[0]["Linea2"]));
                texto.Add(Convert.ToString(dtLineas.Rows[0]["Linea3"]));
                texto.Add(Convert.ToString(dtLineas.Rows[0]["Linea4"]));
                texto.Add(Convert.ToString(dtLineas.Rows[0]["Linea5"]));
                texto.Add(Convert.ToString(dtLineas.Rows[0]["Linea6"]));
                texto.Add(Convert.ToString(dtLineas.Rows[0]["Linea7"]));
                texto.Add(Convert.ToString(dtLineas.Rows[0]["Linea8"]));
                texto.Add(Convert.ToString(dtLineas.Rows[0]["Linea9"]));               
                String Codigo = Convert.ToString(dtLineas.Rows[0]["codigo"]);
                String NumeroSunat = Convert.ToString(dtLineas.Rows[0]["numerosunat"]);
                
                string pathcsv = ConfigurationManager.AppSettings["pathcsvNotasCredito"];
                string pathpdf = ConfigurationManager.AppSettings["pathpdfNotasCredito"];
                string pathcdr = ConfigurationManager.AppSettings["pathcdrNotasCredito"];
                string pathxml = ConfigurationManager.AppSettings["pathxmlNotasCredito"];
                string FechaImpresion = DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString("00") + DateTime.Now.Year.ToString("00") + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString();
                //String FileInvoice = pathcsv + NumeroSunat + "_" + Codigo + "_" + FechaImpresion + ".csv";



                //VerificarPermisos

                System.Security.AccessControl.FileSecurity Permisoscsv = File.GetAccessControl(pathcsv);
                System.Security.AccessControl.FileSecurity Permisospdf = File.GetAccessControl(pathpdf);
                System.Security.AccessControl.FileSecurity Permisoscdr = File.GetAccessControl(pathcdr);
                System.Security.AccessControl.FileSecurity Permisosxml = File.GetAccessControl(pathxml);
                System.Security.AccessControl.FileSecurity Permisoslog = File.GetAccessControl(pathlog);


                //String RutaCompletacsv = pathcsv + NumeroSunat + "_" + Codigo + "_" + FechaImpresion + ".csv";
                //String RutaCompletapdf = pathpdf + NumeroSunat + "_" + Codigo + "_" + FechaImpresion + ".pdf";
                //String RutaCompletacdr = pathcdr + NumeroSunat + "_" + Codigo + "_" + FechaImpresion + ".xml";
                //String RutaCompletaxml = pathxml + NumeroSunat + "_" + Codigo + "_" + FechaImpresion + ".xml";


                String RutaCompletacsv = pathcsv + RUC + "-" + TipoDocumento.Substring(1) + "-" + NumeroSunat + ".csv";
                String RutaCompletapdf = pathpdf + RUC + "-" + TipoDocumento.Substring(1) + "-" + NumeroSunat + ".pdf";
                String RutaCompletacdr = pathcdr + RUC + "-" + TipoDocumento.Substring(1) + "-" + NumeroSunat + ".xml";
                String RutaCompletaxml = pathxml + RUC + "-" + TipoDocumento.Substring(1) + "-" + NumeroSunat + ".xml";



                File.WriteAllLines(RutaCompletacsv, texto);
                Byte[] bytesBoleta = File.ReadAllBytes(RutaCompletacsv);

                authorization oautorizacion = new authorization();
                oautorizacion.password = ConfigurationManager.AppSettings["password"];
                oautorizacion.user = ConfigurationManager.AppSettings["usuario"];

                //List<transactionResponse> lTransactionResponse = new List<transactionResponse>(Cliente.sendCreditNote(oautorizacion, bytesBoleta));

                transactionResponseRest otransactionResponse = new transactionResponseRest();
                otransactionResponse = EnviarDocumentoRest(RutaCompletacsv);



                //List<transactionResponse> lTransactionResponse = new List<transactionResponse>(Cliente.sendInvoice(oautorizacion, bytesFactura));

                if (otransactionResponse != null)
                {
                    //transactionResponse otransactionResponse = new transactionResponse();
                    //otransactionResponse = lTransactionResponse[0];


                    string LineaLog = DateTime.Now.ToString().PadRight(20) + "   " +
                                       Usuario.PadRight(20) + "   " +
                                       ("CREACION").PadRight(10) + "   " +
                                       TipoDocumento.PadRight(3) + "   " +
                                       ("NOTA DE CREDITO").PadRight(20) + "   " +
                                       Codigo.PadRight(5) + "   " +
                                       NumeroSunat.PadRight(10) + "   " +
                                       (otransactionResponse.digestValue == null ? "" : otransactionResponse.digestValue).ToString().PadRight(40) + "   " +
                                       (otransactionResponse.identifier == null ? "" : otransactionResponse.identifier).ToString().PadRight(13) + "   " +
                                       (otransactionResponse.outString == null ? "" : otransactionResponse.outString).ToString().PadRight(200) + "   " +
                                       (otransactionResponse.responseCode == null ? "" : otransactionResponse.responseCode.ToString()).ToString().PadRight(5) + "   " +
                                       (otransactionResponse.sunatError == null ? "" : (otransactionResponse.sunatError.message == null ? "" : otransactionResponse.sunatError.message)).ToString().PadRight(100) + "   " +
                                       (otransactionResponse.sunatError == null ? "" : (otransactionResponse.sunatError.sunatErrorCode == null ? "" : otransactionResponse.sunatError.sunatErrorCode.ToString())).ToString().PadRight(10) + "   " +
                                       Environment.NewLine;


                    //String FechaLog = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString();
                    StreamWriter sw = new StreamWriter(RutaCompletaLog, true);
                    sw.Write(LineaLog);
                    sw.Close();


                    if (otransactionResponse.pdfFile!=null)
                    {
                        //String RutaCompleta = pathpdf + NumeroSunat + "_" + Codigo + "_" + FechaImpresion + ".pdf";
                        row["pathpdf"] = RutaCompletapdf;
                        File.WriteAllBytes(RutaCompletapdf, otransactionResponse.pdfFile);

                    }

                    if (otransactionResponse.cdrFile != null)
                    {
                        //String RutaCompleta = pathcdr + NumeroSunat + "_" + Codigo + "_" + FechaImpresion + ".xml";
                        File.WriteAllBytes(RutaCompletacdr, otransactionResponse.cdrFile);

                    }
                    if (otransactionResponse.xmlSigned != null)
                    {
                        //String RutaCompleta = pathxml + NumeroSunat + "_" + Codigo + "_" + FechaImpresion + ".xml";
                        File.WriteAllBytes(RutaCompletaxml, otransactionResponse.xmlSigned);

                    }                

                    
                    



                    if (otransactionResponse.responseCode!=0)
                    {
                        row["resultado"] = "ERROR";
                        row["mensajeerror"] = (otransactionResponse.outString == null ? "" : otransactionResponse.outString).ToString();
                    }
                    else
                    {
                        row["resultado"] = "OK";
                        row["mensajeerror"] = "OK";
                    }






                }
                else
                {
                    row["resultado"] = "ERROR";
                    row["mensajeerror"] = "NO HAY RESPUESTA DE Efact";
                }



            }



            }
            catch (Exception ex)
            {

                //String FechaLog = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString();
                StreamWriter sw = new StreamWriter(RutaCompletaLog, true);
                sw.Write(ex.Message + Environment.NewLine);
                sw.Write(Environment.NewLine);
                sw.Write(ex.StackTrace + Environment.NewLine);
                sw.Write(Environment.NewLine);
                sw.Write(ex.InnerException + Environment.NewLine);
                sw.Close();
                row["resultado"] = "ERROR";
                row["mensajeerror"] = ex.StackTrace.ToString();
                
            }

                       
            dtResultado.Rows.Add(row);
            return dtResultado;

        }




        public DataTable ProcesarBajaFacturacionElectronica(String CodigoDocumento,String Usuario)
        {


            //string pathlog = ConfigurationManager.AppSettings["pathlog"];
            //DataTable dtResultado = new DataTable();
            //DataRow row = dtResultado.NewRow();


            string pathlog = ConfigurationManager.AppSettings["pathlog"];
            String FechaLog = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString("00") + DateTime.Now.Day.ToString("00");
            String RutaCompletaLog = pathlog + "Log" + FechaLog + ".txt";
            DataTable dtResultado = new DataTable();
            DataRow row = dtResultado.NewRow();


            dtResultado.Columns.Add("pathpdf", typeof(String));
            dtResultado.Columns.Add("resultado", typeof(String));
            dtResultado.Columns.Add("mensajeerror", typeof(String));



            

            try
            {


                DataTable dtLineas = new DataTable();
                dtLineas = GetLineasBajaFacturacionElectronica(CodigoDocumento);
                List<string> texto = new List<string>();
                texto.Add(Convert.ToString(dtLineas.Rows[0]["Linea1"]));
                texto.Add(Convert.ToString(dtLineas.Rows[0]["Linea2"]));
                texto.Add(Convert.ToString(dtLineas.Rows[0]["Linea3"]));
                texto.Add(Convert.ToString(dtLineas.Rows[0]["Linea4"]));
                String Codigo = Convert.ToString(dtLineas.Rows[0]["codigo"]);
                String NumeroSunat = Convert.ToString(dtLineas.Rows[0]["numerosunat"]);

                string pathcsv = ConfigurationManager.AppSettings["pathcsvBajas"];
                string pathpdf = ConfigurationManager.AppSettings["pathpdfBajas"];
                string pathcdr = ConfigurationManager.AppSettings["pathcdrBajas"];
                string pathxml = ConfigurationManager.AppSettings["pathxmlBajas"];
                string FechaImpresion = DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Year.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString();


                string FechaBaja = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString("00") + DateTime.Now.Day.ToString("00");


                //String FileInvoice = pathcsv + "Baja_" + Codigo + "_" + NumeroSunat + "_" + FechaImpresion + ".csv";
                //String FileInvoice = pathcsv + NumeroSunat + "_" + Codigo + "_" + FechaImpresion + ".csv";

                //VerificarPermisos

                System.Security.AccessControl.FileSecurity Permisoscsv = File.GetAccessControl(pathcsv);
                System.Security.AccessControl.FileSecurity Permisospdf = File.GetAccessControl(pathpdf);
                System.Security.AccessControl.FileSecurity Permisoscdr = File.GetAccessControl(pathcdr);
                System.Security.AccessControl.FileSecurity Permisosxml = File.GetAccessControl(pathxml);
                System.Security.AccessControl.FileSecurity Permisoslog = File.GetAccessControl(pathlog);


                //String RutaCompletacsv = pathcsv + NumeroSunat + "_" + Codigo + "_" + FechaImpresion + ".csv";
                //String RutaCompletapdf = pathpdf + NumeroSunat + "_" + Codigo + "_" + FechaImpresion + ".pdf";
                //String RutaCompletacdr = pathcdr + NumeroSunat + "_" + Codigo + "_" + FechaImpresion + ".xml";
                //String RutaCompletaxml = pathxml + NumeroSunat + "_" + Codigo + "_" + FechaImpresion + ".xml";

                String RutaCompletacsv = pathcsv + RUC + "-" + "RA" + "-" + FechaBaja + "-" + Codigo + ".csv";
                String RutaCompletapdf = pathpdf + RUC + "-" + "RA" + "-" + FechaBaja + "-"+ Codigo + ".pdf";
                String RutaCompletacdr = pathcdr + RUC + "-" + "RA" + "-" + FechaBaja + "-"+ Codigo + ".xml";
                String RutaCompletaxml = pathxml + RUC + "-" + "RA" + "-" + FechaBaja + "-"+Codigo + ".xml";


                File.WriteAllLines(RutaCompletacsv, texto);
                Byte[] bytesBoleta = File.ReadAllBytes(RutaCompletacsv);

                authorization oautorizacion = new authorization();
                oautorizacion.password = ConfigurationManager.AppSettings["password"];
                oautorizacion.user = ConfigurationManager.AppSettings["usuario"];

                //List<transactionResponse> lTransactionResponse = new List<transactionResponse>(Cliente.sendVoidedDocument(oautorizacion, bytesBoleta));

                transactionResponseRest otransactionResponse = new transactionResponseRest();
                otransactionResponse = EnviarBajaRest(RutaCompletacsv);



                //List<transactionResponse> lTransactionResponse = new List<transactionResponse>(Cliente.sendInvoice(oautorizacion, bytesFactura));

                if (otransactionResponse != null)

                {
                    //transactionResponse otransactionResponse = new transactionResponse();
                    //otransactionResponse = lTransactionResponse[0];


                    //File.WriteAllBytes(pathpdf + "Baja_" + Codigo + "_" + NumeroSunat + "_" + FechaImpresion + ".pdf", lTransactionResponse[0].pdfFile);



                    //transactionResponse otransactionResponse = new transactionResponse();
                    //otransactionResponse = lTransactionResponse[0];


                    string LineaLog = DateTime.Now.ToString().PadRight(20) + "   " +
                                       Usuario.PadRight(20) + "   " +
                                       ("BAJA").PadRight(10) + "   " +
                                       TipoDocumento.PadRight(3) + "   " +
                                       ("DOCUMENTO").PadRight(20) + "   " +
                                       Codigo.PadRight(5) + "   " +
                                       NumeroSunat.PadRight(10) + "   " +
                                       (otransactionResponse.digestValue == null ? "" : otransactionResponse.digestValue).ToString().PadRight(40) + "   " +
                                       (otransactionResponse.identifier == null ? "" : otransactionResponse.identifier).ToString().PadRight(13) + "   " +
                                       (otransactionResponse.outString == null ? "" : otransactionResponse.outString).ToString().PadRight(200) + "   " +
                                       (otransactionResponse.responseCode == null ? "" : otransactionResponse.responseCode.ToString()).ToString().PadRight(5) + "   " +
                                       (otransactionResponse.sunatError == null ? "" : (otransactionResponse.sunatError.message == null ? "" : otransactionResponse.sunatError.message)).ToString().PadRight(100) + "   " +
                                       (otransactionResponse.sunatError == null ? "" : (otransactionResponse.sunatError.sunatErrorCode == null ? "" : otransactionResponse.sunatError.sunatErrorCode.ToString())).ToString().PadRight(10) + "   " +
                                       Environment.NewLine;


                    //String FechaLog = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString();
                    StreamWriter sw = new StreamWriter(RutaCompletaLog, true);
                    sw.Write(LineaLog);
                    sw.Close();


                    if (otransactionResponse.pdfFile != null)
                    {
                        //String RutaCompleta = pathpdf + "Baja_" + Codigo + "_" + NumeroSunat + "_" + FechaImpresion + ".pdf";
                        row["pathpdf"] = RutaCompletapdf;
                        File.WriteAllBytes(RutaCompletapdf, otransactionResponse.pdfFile);

                    }

                    if (otransactionResponse.cdrFile != null)
                    {
                        //String RutaCompleta = pathcdr + "Baja_" + Codigo + "_" + NumeroSunat + "_" + FechaImpresion + ".xml";
                        File.WriteAllBytes(RutaCompletacdr, otransactionResponse.cdrFile);

                    }
                    if (otransactionResponse.xmlSigned != null)
                    {
                        //String RutaCompleta = pathxml + "Baja_" + Codigo + "_" + NumeroSunat + "_" + FechaImpresion + ".xml";
                        File.WriteAllBytes(RutaCompletaxml, otransactionResponse.xmlSigned);

                    }


                    



                    if (otransactionResponse.responseCode != 0)
                    {
                        row["resultado"] = "ERROR";
                        row["mensajeerror"] = (otransactionResponse.outString == null ? "" : otransactionResponse.outString).ToString();
                    }
                    else
                    {
                        row["resultado"] = "OK";
                        row["mensajeerror"] = "OK";
                    }

                }

            }catch (Exception ex)
            {

                //String FechaLog = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString();
                StreamWriter sw = new StreamWriter(RutaCompletaLog, true);
                sw.Write(ex.Message + Environment.NewLine);
                sw.Write(Environment.NewLine);
                sw.Write(ex.StackTrace + Environment.NewLine);
                sw.Write(Environment.NewLine);
                sw.Write(ex.InnerException + Environment.NewLine);
                sw.Close();
                row["resultado"] = "ERROR";
                row["mensajeerror"] = ex.StackTrace.ToString();
            }

            dtResultado.Rows.Add(row);
            return dtResultado;


        }



        public DataTable GetLineasFacturacionElectronica(String CodigoDocumento, String Email)
        {

            
            SqlConnection connection;
            SqlCommand command;
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataSet dsFacturacionElectronica = new DataSet();
            string queryGetDocumentos = "exec VEN_DDOVSS_FacturacionEletronica '" + CodigoDocumento + "' ,  " + "'" + Email + "'";
            
            connection = new SqlConnection(connStr);

            

            try
            {
                connection.Open();

                command = new SqlCommand(queryGetDocumentos, connection);
                adapter.SelectCommand = command;
                adapter.Fill(dsFacturacionElectronica, "dtLineas");
                adapter.Dispose();
                command.Dispose();
                connection.Close();
         
            }
            catch (Exception)
            {
                
                throw;
            }
            return dsFacturacionElectronica.Tables[0];
        }


        public DataTable GetLineasBajaFacturacionElectronica(String CodigoDocumento)
        {


            SqlConnection connection;
            SqlCommand command;
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataSet dsBajaFacturacionElectronica = new DataSet();
            string queryGetDocumentos = "exec VEN_DDOVSS_BajaFacturacionEletronica '" + CodigoDocumento + "'";
            connection = new SqlConnection(connStr);

            try
            {
                connection.Open();

                command = new SqlCommand(queryGetDocumentos, connection);
                adapter.SelectCommand = command;
                adapter.Fill(dsBajaFacturacionElectronica, "dtBajaLineas");
                adapter.Dispose();
                command.Dispose();
                connection.Close();

            }
            catch (Exception)
            {

                throw;
            }
            return dsBajaFacturacionElectronica.Tables[0];
        }



        //REst Baja

        public transactionResponseRest EnviarBajaRest(string pathcsv)
        {

            transactionResponseRest otransactionResponseRest = new transactionResponseRest();

            //Obtener Token
            string usuarioRest = ConfigurationManager.AppSettings["usuarioRest"];
            string passwordRest = ConfigurationManager.AppSettings["passwordRest"];
            string grantType = ConfigurationManager.AppSettings["granttype"];


            string dataToken = "username=" + usuarioRest + "&password=" + passwordRest + "&grant_type=" + grantType;
            string methodToken = "POST";
            WebClient clientToken = new WebClient();
            clientToken.Headers.Add("Content-Type", "application/x-www-form-urlencoded");
            string svcCredentials = Convert.ToBase64String(ASCIIEncoding.ASCII.GetBytes("client" + ":" + "secret"));
            clientToken.Headers.Add("Authorization", "Basic " + svcCredentials);


            string urlToken = ConfigurationManager.AppSettings["urlToken"];
            string jsonToken = clientToken.UploadString(urlToken, methodToken, dataToken);
            JavaScriptSerializer serToken = new JavaScriptSerializer();
            Token vToken = serToken.Deserialize<Token>(jsonToken);



            //Enviar Documento CSV
            string urlSendCsv = ConfigurationManager.AppSettings["urlSendCsv"];

            string methodcsv = "POST";
            WebClient clientcsv = new WebClient();
            clientcsv.Headers.Add("Authorization", "Bearer " + vToken.access_token);
            Respuesta rDoc = new Respuesta();
            try
            {
                byte[] resp = clientcsv.UploadFile(urlSendCsv, methodcsv, pathcsv);
                string result = System.Text.Encoding.UTF8.GetString(resp);
                JavaScriptSerializer sercsv = new JavaScriptSerializer();
                rDoc = sercsv.Deserialize<Respuesta>(result);
                otransactionResponseRest.sunatError = new sunatError();
                otransactionResponseRest.sunatError.sunatErrorCode = Convert.ToInt32(rDoc.code);
                otransactionResponseRest.sunatError.message = rDoc.description;
                otransactionResponseRest.digestValue = rDoc.description;



            }
            catch (WebException webex)
            {
                WebResponse errResp = webex.Response;
                using (Stream respStream = errResp.GetResponseStream())
                {
                    StreamReader reader = new StreamReader(respStream);
                    string text = reader.ReadToEnd();
                    JavaScriptSerializer sercsv = new JavaScriptSerializer();
                    rDoc = sercsv.Deserialize<Respuesta>(text);
                    otransactionResponseRest.sunatError = new sunatError();
                    otransactionResponseRest.sunatError.sunatErrorCode = Convert.ToInt32(rDoc.code);
                    otransactionResponseRest.responseCode = Convert.ToInt32(rDoc.code);
                    otransactionResponseRest.outString = rDoc.description;
                    otransactionResponseRest.sunatError.message = rDoc.description;
                    otransactionResponseRest.outString = rDoc.description;
                }
            }

            otransactionResponseRest.pdfFile = null;
            otransactionResponseRest.xmlSigned = null;
            otransactionResponseRest.cdrFile = null;
            return otransactionResponseRest;
        }



        //Rest Documentos


        public transactionResponseRest EnviarDocumentoRest(string pathcsv)
        {

            transactionResponseRest otransactionResponseRest = new transactionResponseRest();

            //Obtener Token
            string usuarioRest = ConfigurationManager.AppSettings["usuarioRest"];
            string passwordRest = ConfigurationManager.AppSettings["passwordRest"];
            string grantType = ConfigurationManager.AppSettings["granttype"];


            string dataToken = "username=" + usuarioRest + "&password=" + passwordRest + "&grant_type=" + grantType;
            string methodToken = "POST";
            WebClient clientToken = new WebClient();
            clientToken.Headers.Add("Content-Type", "application/x-www-form-urlencoded");
            string svcCredentials = Convert.ToBase64String(ASCIIEncoding.ASCII.GetBytes("client" + ":" + "secret"));
            clientToken.Headers.Add("Authorization", "Basic " + svcCredentials);


            string urlToken = ConfigurationManager.AppSettings["urlToken"];
            string jsonToken = clientToken.UploadString(urlToken, methodToken, dataToken);
            JavaScriptSerializer serToken = new JavaScriptSerializer();
            Token vToken = serToken.Deserialize<Token>(jsonToken);



            //Enviar Documento CSV
            string urlSendCsv = ConfigurationManager.AppSettings["urlSendCsv"];

            string methodcsv = "POST";
            WebClient clientcsv = new WebClient();
            clientcsv.Headers.Add("Authorization", "Bearer " + vToken.access_token);
            Respuesta rDoc = new Respuesta();           
            try
            {
                byte[] resp = clientcsv.UploadFile(urlSendCsv, methodcsv, pathcsv);
                string result = System.Text.Encoding.UTF8.GetString(resp);
                JavaScriptSerializer sercsv = new JavaScriptSerializer();
                rDoc = sercsv.Deserialize<Respuesta>(result);
                otransactionResponseRest.sunatError = new sunatError();
                otransactionResponseRest.sunatError.sunatErrorCode = Convert.ToInt32(rDoc.code);
                otransactionResponseRest.sunatError.message = rDoc.description;
                otransactionResponseRest.digestValue = rDoc.description;
                otransactionResponseRest.outString = rDoc.description;
                

            }
            catch (WebException webex)
            {
                WebResponse errResp = webex.Response;
                using (Stream respStream = errResp.GetResponseStream())
                {
                    StreamReader reader = new StreamReader(respStream);
                    string text = reader.ReadToEnd();
                    JavaScriptSerializer sercsv = new JavaScriptSerializer();
                    rDoc = sercsv.Deserialize<Respuesta>(text);
                    otransactionResponseRest.sunatError = new sunatError();
                    otransactionResponseRest.sunatError.sunatErrorCode = Convert.ToInt32(rDoc.code);
                    otransactionResponseRest.responseCode = Convert.ToInt32(rDoc.code);
                    otransactionResponseRest.sunatError.message = rDoc.description;
                    otransactionResponseRest.outString = rDoc.description;

                }
            }

            
            //Obtener PDF
            string urlGetPdf = ConfigurationManager.AppSettings["urlGetPdf"];
            WebClient clientpdf = new WebClient();
            clientpdf.Headers.Add("Authorization", "Bearer " + vToken.access_token);

            try
            {

                Stopwatch sw = new Stopwatch();
                sw.Start();
                string result ="";
                //do
                //{
                    result = "";
                    byte[] resppdf = clientpdf.DownloadData(urlGetPdf + rDoc.description);
                    result = System.Text.Encoding.UTF8.GetString(resppdf);
                    //JavaScriptSerializer serResultPdf = new JavaScriptSerializer();
                    //vRespuesta = serResultPdf.Deserialize<Respuesta>(result);
                    do
                    {
                        resppdf = clientpdf.DownloadData(urlGetPdf + rDoc.description);
                        result = System.Text.Encoding.UTF8.GetString(resppdf);
                    }
                    while (result.Contains("-9998") && sw.Elapsed.TotalSeconds < TiempoEsperaPdf);

                    otransactionResponseRest.pdfFile = resppdf;

                //} while (result.Contains("-9998") && sw.Elapsed.TotalSeconds  < TiempoEsperaPdf);

                sw.Stop();

                
                //string result = System.Text.Encoding.UTF8.GetString(resppdf);
                //File.WriteAllBytes(@"C:\DocumentosElectronicos\csv\Facturas\20516667550-01-F006-10016108.pdf", resppdf);

            }
            catch (WebException webex)
            {
                WebResponse errResp = webex.Response;
                using (Stream respStream = errResp.GetResponseStream())
                {
                    StreamReader reader = new StreamReader(respStream);
                 
                    string text = reader.ReadToEnd();
                    JavaScriptSerializer sercsv = new JavaScriptSerializer();
                    rDoc = sercsv.Deserialize<Respuesta>(text);
                    otransactionResponseRest.sunatError = new sunatError();
                    otransactionResponseRest.sunatError.sunatErrorCode = Convert.ToInt32(rDoc.code);
                    //otransactionResponseRest.responseCode = Convert.ToInt32(rDoc.code);
                    otransactionResponseRest.sunatError.message = rDoc.description;
                    otransactionResponseRest.outString = rDoc.description;
                }
            }






            //Obtener XML
            WebClient clientxml = new WebClient();
            clientxml.Headers.Add("Authorization", "Bearer " + vToken.access_token);
            string urlGetXml = ConfigurationManager.AppSettings["urlGetXml"]; //"https://ose-gw1.efact.pe:443/api-efact-ose/v1/xml/"'
            try
            {

                //clientcsv.
                byte[] respxml = clientxml.DownloadData(urlGetXml + rDoc.description);
                otransactionResponseRest.xmlSigned = respxml;
                //string resultxml = System.Text.Encoding.UTF8.GetString(respxml);
                //File.WriteAllBytes(@"C:\DocumentosElectronicos\csv\Facturas\20516667550-01-F006-10016108.xml", respxml);

            }
            catch (WebException webex)
            {
                WebResponse errResp = webex.Response;
                using (Stream respStream = errResp.GetResponseStream())
                {
                    StreamReader reader = new StreamReader(respStream);
                    string text = reader.ReadToEnd();
                    JavaScriptSerializer sercsv = new JavaScriptSerializer();
                    rDoc = sercsv.Deserialize<Respuesta>(text);
                    otransactionResponseRest.sunatError = new sunatError();
                    otransactionResponseRest.sunatError.sunatErrorCode = Convert.ToInt32(rDoc.code);
                    //otransactionResponseRest.responseCode = Convert.ToInt32(rDoc.code);
                    otransactionResponseRest.sunatError.message = rDoc.description;
                    otransactionResponseRest.outString = rDoc.description;
                }
            }




            //Obtener CDR
            WebClient clientcdr = new WebClient();
            clientcdr.Headers.Add("Authorization", "Bearer " + vToken.access_token);
            string urlGetCdr = ConfigurationManager.AppSettings["urlGetCdr"]; //"https://ose-gw1.efact.pe:443/api-efact-ose/v1/cdr/"'
            try
            {

                //clientcsv.
                byte[] respcdr = clientcdr.DownloadData(urlGetCdr + rDoc.description);
                otransactionResponseRest.cdrFile = respcdr;
                //string resultcdr = System.Text.Encoding.UTF8.GetString(respcdr);
                //File.WriteAllBytes(@"C:\DocumentosElectronicos\csv\Facturas\20516667550-01-F006-10016108.cdr", respcdr);

            }
            catch (WebException webex)
            {
                WebResponse errResp = webex.Response;
                using (Stream respStream = errResp.GetResponseStream())
                {
                    StreamReader reader = new StreamReader(respStream);
                    string text = reader.ReadToEnd();
                    JavaScriptSerializer sercsv = new JavaScriptSerializer();
                    rDoc = sercsv.Deserialize<Respuesta>(text);
                    otransactionResponseRest.sunatError = new sunatError();
                    otransactionResponseRest.sunatError.sunatErrorCode = Convert.ToInt32(rDoc.code);
                    //otransactionResponseRest.responseCode = Convert.ToInt32(rDoc.code);
                    otransactionResponseRest.sunatError.message = rDoc.description;
                    otransactionResponseRest.outString = rDoc.description;
                    
                }
            }


            return otransactionResponseRest;




        }








    }




}
