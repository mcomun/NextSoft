using Delfin.ServiceContracts;
using Infrastructure.Aspect.DataAccess;
using Infrastructure.Aspect.Patterns;
using Infrastructure.WinFormsControls;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace Delfin.Principal
{
    public class EmailFiles
    {
        public IDelfinServices Client { get; set; }

        public IUnityContainer ContainerService { get; set; }

        public string CorreoDireccionamientoCosco(bool Por_OV, DataTable DtDireciomaniento, DateTime? Fecha_Eta_Etd, string Nombre_Transportista, string Nombre_Nave, string Numero_Viaje, string Correo_Operaciones)
        {
            string str1 = (string)null;
            try
            {
                string path2_1 = "CARTA_DIRECCIONAMIENTO";
                Directory.CreateDirectory(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), path2_1));
                string empty1 = string.Empty;
                string empty2 = string.Empty;
                string path2_2 = "Plantillas\\\\CARTA_DIRECCIONAMIENTO.docx";
                string empty3 = string.Empty;
                if (DtDireciomaniento == null)
                    return "No se encontraron MBL'(s) que Direccionar o no cuenta(n) con un Deposito";
                StringBuilder stringBuilder = new StringBuilder();
                stringBuilder.Append("<html>");
                stringBuilder.Append("<font color= #2f5496 >");
                stringBuilder.Append("<body>");
                stringBuilder.Append("<h4>Estimados : </h4>");
                stringBuilder.Append("<p>Adjunto carta de direccionamiento, considerar la siguiente descarga </p>");
                stringBuilder.Append("<p>Confirmar recepción </p>");
                stringBuilder.Append("<p><b>Saludos cordiales </b></p>");
                stringBuilder.Append("</body>");
                stringBuilder.Append("</font>");
                stringBuilder.Append("</html>");
                EnviarCorreo enviarCorreo = new EnviarCorreo();
                string _body = stringBuilder.ToString();
                bool _enviar = false;
                DataTable dataTable = DtDireciomaniento.Copy();
                string empty4 = string.Empty;
                if (Fecha_Eta_Etd.HasValue)
                    empty4 = Convert.ToDateTime((object)Fecha_Eta_Etd).ToString("dd/MM/yyyy");
                DateTime today = DateTime.Today;
                string str2 = this.MonthName(today.Month);
                bool Editable = true;
                int rows = 0;
                int num = 1;
                string path3;
                if (Por_OV)
                    path3 = "CARTA_DIRECCIONAMIENTO_" + Nombre_Nave + "_" + Numero_Viaje + "_OV_" + today.ToString("MM_dd_yy") + ".docx";
                else
                    path3 = "CARTA_DIRECCIONAMIENTO_" + Nombre_Nave + "_" + Numero_Viaje + "_" + today.ToString("MM_dd_yy") + ".docx";
                string str3 = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), path2_1, path3);
                WordDocument wordDocument = new WordDocument(Path.Combine(Application.StartupPath, path2_2), str3);
                wordDocument.FindAndReplace((object)"<_lugar_fecha>", (object)("Lima, " + today.ToString("dd") + " de " + str2 + " de " + today.ToString("yyyy")));
                wordDocument.FindAndReplace((object)"<_transportista>", (object)Nombre_Transportista);
                wordDocument.FindAndReplace((object)"<_nave_nro_viaje>", (object)(Nombre_Nave + " - " + Numero_Viaje));
                foreach (DataRow row in (InternalDataCollectionBase)dataTable.Rows)
                {
                    wordDocument.FillTable(new List<string>()
          {
            Nombre_Nave,
            Convert.ToString(row["DOOV_MBL"]),
            Convert.ToString(row["EDTE_NomCompleto"]),
            Convert.ToString(empty4),
            Convert.ToString(row["CFLE_Nombre"])
          }, 1, rows);
                    ++rows;
                    if (dataTable.Rows.Count == num)
                    {
                        wordDocument.SaveDocument(Editable);
                        wordDocument.CloseDocument();
                        string _recipient = "<COLOCAR EMAIL A ENVIAR>";
                        string _olCCrecipient = Correo_Operaciones;
                        string _subject = "DIRECCIONAMIENTO \\ " + Nombre_Transportista + " \\ " + Nombre_Nave + " \\ " + Numero_Viaje + " \\ ETA:" + empty4;
                        string _ruta = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), str3);
                        enviarCorreo.enviaCorreo(_enviar, _recipient, _olCCrecipient, _subject, _body, _ruta, "");
                    }
                    ++num;
                }
                return str1;
            }
            catch (Exception ex)
            {
                return "#-ERROR INTERNO EN EL DIRECCIONAMIENTO-#" + Environment.NewLine + ex.Message;
            }
        }

        public string CorreoDireccionamiento(DataTable DtDireciomaniento, DateTime? Fecha_Eta_Etd, string Nombre_Transportista, string Nombre_Nave, string Numero_Viaje, string Correo_Operaciones)
        {
            string str = (string)null;
            try
            {
                if (DtDireciomaniento == null)
                    return "No se encontraron MBL'(s) que Direccionar o no cuenta(n) con un Deposito";
                string empty = string.Empty;
                if (Fecha_Eta_Etd.HasValue)
                    empty = Convert.ToDateTime((object)Fecha_Eta_Etd).ToString("dd/MM/yyyy");
                EnviarCorreo enviarCorreo = new EnviarCorreo();
                string _recipient = "<COLOCAR EMAIL>";
                string _olCCrecipient = Correo_Operaciones;
                bool _enviar = false;
                StringBuilder stringBuilder1 = new StringBuilder();
                stringBuilder1.Append("<html>");
                stringBuilder1.Append("<font color= #2f5496 >");
                stringBuilder1.Append("<body>");
                stringBuilder1.Append("<h4>Estimados : </h4>");
                stringBuilder1.Append("<p>Considerar la siguiente descarga para los siguientes almacenes : </p>");
                stringBuilder1.Append("</body>");
                stringBuilder1.Append("</font>");
                stringBuilder1.Append("</html>");
                StringBuilder stringBuilder2 = new StringBuilder();
                stringBuilder2.Append("<table bgcolor=#f2f2f2 border=1 cellpadding=4 cellspacing=0 style=font-size:13px;font-face:Verdana >");
                stringBuilder2.Append("<tr><th colspan=3> DIRECCIONAMIENTO </th><tr><th> MBL </th><th> DEPOSITO </th><th> RUC </th></tr>");
                int num = 1;
                foreach (DataRow row in (InternalDataCollectionBase)DtDireciomaniento.Rows)
                {
                    stringBuilder2.Append("<tr>");
                    stringBuilder2.Append("<td>" + Convert.ToString(row["DOOV_MBL"]) + "</td>");
                    stringBuilder2.Append("<td>" + Convert.ToString(row["EDTE_NomCompleto"]) + "</td>");
                    if (Convert.ToString(row["EDTE_NomCompleto"]) == "DESCARGA DIRECTA")
                        stringBuilder2.Append("<td>" + Convert.ToString(row["ECLI_DocIden"]) + "</td>");
                    else
                        stringBuilder2.Append("<td>" + string.Empty + "</td>");
                    stringBuilder2.Append("</tr>");
                    if (DtDireciomaniento.Rows.Count == num)
                    {
                        stringBuilder2.Append("</table>");
                        stringBuilder2.Append("<font color= #2f5496 >");
                        stringBuilder2.Append("<p> </p>");
                        stringBuilder2.Append("<p>Por Favor Confirmar recepción</p>");
                        stringBuilder2.Append("<p>Saludos.</p>");
                        stringBuilder2.Append("</font>");
                        string _body = stringBuilder1.ToString() + stringBuilder2.ToString();
                        string _subject = "DIRECCIONAMIENTO \\ " + Nombre_Transportista + " \\ " + Nombre_Nave + " \\ " + Numero_Viaje + " \\ ETA:" + empty;
                        enviarCorreo.enviaCorreo(_enviar, _recipient, _olCCrecipient, _subject, _body);
                    }
                    ++num;
                }
                return str;
            }
            catch (Exception ex)
            {
                return "#-ERROR INTERNO EN EL DIRECCIONAMIENTO-#" + Environment.NewLine + ex.Message;
            }
        }

        public string DocVoBoTramarsa(bool Por_OV, DataTable DtVoBo, DateTime? Fecha_Eta_Etd, string Nombre_Agente, string Nombre_Nave, string Numero_Viaje)
        {
            string str1 = (string)null;
            try
            {
                string path2_1 = "DESGLOSE_DE_VISTO_BUENO";
                string str2 = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), path2_1);
                Directory.CreateDirectory(str2);
                string empty1 = string.Empty;
                string empty2 = string.Empty;
                string path2_2 = "Plantillas\\\\DESGLOSE_DE_VISTO_BUENO_2.docx";
                string empty3 = string.Empty;
                if (Fecha_Eta_Etd.HasValue)
                    empty3 = Convert.ToDateTime((object)Fecha_Eta_Etd).ToString("dd/MM/yyyy");
                if (DtVoBo == null)
                    return "No se encontro ningun mbl";
                DataTable dataTable = DtVoBo.Copy();
                DateTime today = DateTime.Today;
                string str3 = this.MonthName(today.Month);
                int rows = 0;
                int num = 1;
                string path3;
                if (Por_OV)
                    path3 = "DESGLOSE_DE_VISTO_BUENO_2_" + Nombre_Nave + "_" + Numero_Viaje + "_OV_" + today.ToString("MM_dd_yy") + ".docx";
                else
                    path3 = "DESGLOSE_DE_VISTO_BUENO_2_" + Nombre_Nave + "_" + Numero_Viaje + "_" + today.ToString("MM_dd_yy") + ".docx";
                string _ruta = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), path2_1, path3);
                bool Editable = true;
                WordDocument wordDocument = new WordDocument(Path.Combine(Application.StartupPath, path2_2), _ruta);
                wordDocument.FindAndReplace((object)"<_lugar_fecha>", (object)("San Isidro, " + today.ToString("dd") + " de " + str3 + " de " + today.ToString("yyyy")));
                wordDocument.FindAndReplace((object)"<_agente_portuario>", (object)Nombre_Agente);
                wordDocument.FindAndReplace((object)"<_nave_nro_viaje>", (object)(Nombre_Nave + " V.- " + Numero_Viaje));
                wordDocument.FindAndReplace((object)"<_fec_eta>", (object)empty3);
                foreach (DataRow row in (InternalDataCollectionBase)dataTable.Rows)
                {
                    List<string> records = new List<string>();
                    string str4 = Convert.ToString(row["DOOV_MBL"]).Trim();
                    if (!string.IsNullOrEmpty(str4))
                    {
                        records.Add(str4);
                        wordDocument.FillTable(records, 1, rows);
                        ++rows;
                    }
                    if (dataTable.Rows.Count == num)
                    {
                        wordDocument.SaveDocument(Editable);
                        wordDocument.CloseDocument();
                    }
                    ++num;
                }
                if (Dialogos.MostrarMensajePregunta("ARCHIVOS", "¿Desea observar los documentos generados?", (Dialogos.LabelBoton)1) == DialogResult.Yes)
                    Process.Start("EXPLORER.EXE", str2);
                return str1;
            }
            catch (Exception ex)
            {
                return "#-ERROR INTERNO EN EL DESGLOSE DE VISTO BUENO-#" + Environment.NewLine + ex.Message;
            }
        }

        public string DocVoBo(DataTable DtVoBo, DateTime? Fecha_EtaImpo, DateTime? Fecha_ZarpeExpo, int? NVIA_Codigo, string Nombre_Agente, string Nombre_Nave, string Numero_Viaje, string Codigo_Regimen)
        {
            string str1 = (string)null;
            try
            {
                string path2_1 = "DESGLOSE_DE_VISTO_BUENO";
                string str2 = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), path2_1);
                Directory.CreateDirectory(str2);
                string path2_2 = "Plantillas\\\\DESGLOSE_DE_VISTO_BUENO.docx";
                string empty1 = string.Empty;
                string empty2 = string.Empty;
                bool? nullable1 = new bool?(false);
                string empty3 = string.Empty;
                if (Fecha_EtaImpo.HasValue)
                    empty3 = Convert.ToDateTime((object)Fecha_EtaImpo).ToString("dd/MM/yyyy");
                string empty4 = string.Empty;
                if (Fecha_ZarpeExpo.HasValue)
                    empty4 = Convert.ToDateTime((object)Fecha_ZarpeExpo).ToString("dd/MM/yyyy");
                if (DtVoBo == null)
                    return "No se encontraron detalles en la(s) orden(es) de venta o no tiene Deposito Temporal";
                DataTable dataTable1 = new DataTable();
                List<List<string>> stringListList = new List<List<string>>();
                List<string> stringList1 = new List<string>();
                WordDocument wordDocument = (WordDocument)null;
                bool Editable = true;
                DataTable dataTable2 = DtVoBo.Copy();
                int num1 = 0;
                DateTime today = DateTime.Today;
                int rows = 0;
                int num2 = 1;
                string empty5 = string.Empty;
                string empty6 = string.Empty;
                string empty7 = string.Empty;
                int num3 = 0;
                Decimal num4 = new Decimal(0);
                string str3 = string.Empty;
                foreach (DataRow row1 in (InternalDataCollectionBase)dataTable2.Rows)
                {
                    int int32 = Convert.ToInt32(row1["CCOT_Numero"]);
                    if (int32 == num1 || num1 == 0)
                    {
                        num1 = Convert.ToInt32(row1["CCOT_Numero"]);
                        if (int32 != num1 || num2 == 1)
                        {
                            string path3 = "DESGLOSE_DE_VISTO_BUENO_" + Convert.ToString(row1["CCOT_NumDoc"]) + "_" + today.ToString("MM_dd_yy") + ".docx";
                            string _ruta = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), path2_1, path3);
                            wordDocument = new WordDocument(Path.Combine(Application.StartupPath, path2_2), _ruta);
                            wordDocument.FindAndReplace((object)"<lugar_fecha>", (object)("San Isidro, " + today.ToString("D")));
                            wordDocument.FindAndReplace((object)"<nro_operacion>", (object)Convert.ToString(row1["CCOT_NumDoc"]));
                            wordDocument.FindAndReplace((object)"<agente_portuario>", (object)Nombre_Agente);
                            wordDocument.FindAndReplace((object)"<nave_nro_viaje>", (object)("MN: " + Nombre_Nave + " V.: " + Numero_Viaje));
                            wordDocument.FindAndReplace((object)"<nro_mbl>", (object)Convert.ToString(row1["DOOV_MBL"]));
                            wordDocument.FindAndReplace((object)"<deposito_temporal>", (object)Convert.ToString(row1["ENTC_NomDTE"]));
                            switch (Codigo_Regimen)
                            {
                                case "002":
                                    wordDocument.FindAndReplace((object)"<_impo>", (object)" ");
                                    wordDocument.FindAndReplace((object)"<_expo>", (object)"X");
                                    wordDocument.FindAndReplace((object)"<eti_fec>", (object)"ETD");
                                    wordDocument.FindAndReplace((object)"<fecha_eta>", (object)empty4);
                                    empty5 = Convert.ToString(row1["DOOV_HBL"]);
                                    empty6 = Convert.ToString(row1["ENTC_NomSHI"]);
                                    empty7 = Convert.ToString(row1["ENTC_DocIdenSHI"]);
                                    break;
                                case "001":
                                    wordDocument.FindAndReplace((object)"<_impo>", (object)"X");
                                    wordDocument.FindAndReplace((object)"<_expo>", (object)" ");
                                    wordDocument.FindAndReplace((object)"<eti_fec>", (object)"ETA");
                                    wordDocument.FindAndReplace((object)"<fecha_eta>", (object)empty3);
                                    empty5 = Convert.ToString(row1["DOOV_HBL"]);
                                    empty6 = Convert.ToString(row1["ENTC_NomCON"]);
                                    empty7 = Convert.ToString(row1["ENTC_DocIdenCON"]);
                                    break;
                            }
                        }
                        num3 += Convert.ToInt32(row1["DHBL_CantBultos"]);
                        num4 += Convert.ToDecimal(row1["DHBL_PesoBruto"]);
                        str3 = str3 + "--" + Convert.ToString(row1["CNTR_Pack_Numero"]) + Environment.NewLine;
                        bool? nullable2 = row1["DHBL_PP"] == DBNull.Value ? new bool?(false) : new bool?(Convert.ToBoolean(row1["DHBL_PP"]));
                        if ((!nullable2.GetValueOrDefault() ? 0 : (nullable2.HasValue ? 1 : 0)) != 0)
                        {
                            dataTable1 = new DataTable();
                            DataTable dataTable3 = this.PP(NVIA_Codigo, new int?(Convert.ToInt32(row1["CCOT_Numero"])), Convert.ToString(row1["CNTR_Numero"]));
                            if (dataTable3 != null && dataTable3.Rows.Count > 0)
                            {
                                foreach (DataRow row2 in (InternalDataCollectionBase)dataTable3.Rows)
                                {
                                    List<string> stringList2 = new List<string>();
                                    stringList2.Add(Convert.ToString(row2["DOOV_HBL"]));
                                    switch (Codigo_Regimen)
                                    {
                                        case "002":
                                            stringList2.Add(Convert.ToString(row2["ENTC_NomSHI"]));
                                            stringList2.Add(Convert.ToString(row2["ENTC_DocIdenSHI"]));
                                            break;
                                        case "001":
                                            stringList2.Add(Convert.ToString(row2["ENTC_NomCON"]));
                                            stringList2.Add(Convert.ToString(row2["ENTC_DocIdenCON"]));
                                            break;
                                    }
                                    stringList2.Add(Convert.ToString(row2["DHBL_CantBultos"]));
                                    stringList2.Add(Convert.ToString(row2["DHBL_PesoBruto"]));
                                    stringList2.Add(Convert.ToString(row2["CNTR_Pack_Numero"]));
                                    stringListList.Add(stringList2);
                                }
                            }
                        }
                    }
                    else
                    {
                        stringListList.Insert(0, new List<string>()
            {
              empty5,
              empty6,
              empty7,
              Convert.ToString(num3),
              Convert.ToString(num4),
              str3
            });
                        foreach (List<string> records in stringListList)
                        {
                            wordDocument.FillTable(records, 2, rows);
                            ++rows;
                        }
                        wordDocument.SaveDocument(Editable);
                        wordDocument.CloseDocument();
                        stringListList = new List<List<string>>();
                        num1 = Convert.ToInt32(row1["CCOT_Numero"]);
                        rows = 0;
                        empty5 = string.Empty;
                        empty6 = string.Empty;
                        empty7 = string.Empty;
                        int num5 = 0;
                        Decimal num6 = new Decimal(0);
                        string empty8 = string.Empty;
                        string path3 = "DESGLOSE_DE_VISTO_BUENO_" + Convert.ToString(row1["CCOT_NumDoc"]) + "_" + today.ToString("MM_dd_yy") + ".docx";
                        string _ruta = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), path2_1, path3);
                        wordDocument = new WordDocument(Path.Combine(Application.StartupPath, path2_2), _ruta);
                        wordDocument.FindAndReplace((object)"<lugar_fecha>", (object)("San Isidro, " + today.ToString("D")));
                        wordDocument.FindAndReplace((object)"<nro_operacion>", (object)Convert.ToString(row1["CCOT_NumDoc"]));
                        wordDocument.FindAndReplace((object)"<agente_portuario>", (object)Nombre_Agente);
                        wordDocument.FindAndReplace((object)"<nave_nro_viaje>", (object)("MN: " + Nombre_Nave + " V.: " + Numero_Viaje));
                        wordDocument.FindAndReplace((object)"<nro_mbl>", (object)Convert.ToString(row1["DOOV_MBL"]));
                        wordDocument.FindAndReplace((object)"<deposito_temporal>", (object)Convert.ToString(row1["ENTC_NomDTE"]));
                        switch (Codigo_Regimen)
                        {
                            case "002":
                                wordDocument.FindAndReplace((object)"<_impo>", (object)" ");
                                wordDocument.FindAndReplace((object)"<_expo>", (object)"X");
                                wordDocument.FindAndReplace((object)"<eti_fec>", (object)"ETD");
                                wordDocument.FindAndReplace((object)"<fecha_eta>", (object)empty4);
                                empty5 = Convert.ToString(row1["DOOV_HBL"]);
                                empty6 = Convert.ToString(row1["ENTC_NomSHI"]);
                                empty7 = Convert.ToString(row1["ENTC_DocIdenSHI"]);
                                break;
                            case "001":
                                wordDocument.FindAndReplace((object)"<_impo>", (object)"X");
                                wordDocument.FindAndReplace((object)"<_expo>", (object)" ");
                                wordDocument.FindAndReplace((object)"<eti_fec>", (object)"ETA");
                                wordDocument.FindAndReplace((object)"<fecha_eta>", (object)empty3);
                                empty5 = Convert.ToString(row1["DOOV_HBL"]);
                                empty6 = Convert.ToString(row1["ENTC_NomCON"]);
                                empty7 = Convert.ToString(row1["ENTC_DocIdenCON"]);
                                break;
                        }
                        num3 = num5 + Convert.ToInt32(row1["DHBL_CantBultos"]);
                        num4 = num6 + Convert.ToDecimal(row1["DHBL_PesoBruto"]);
                        str3 = empty8 + "--" + Convert.ToString(row1["CNTR_Pack_Numero"]) + Environment.NewLine;
                        bool? nullable2 = row1["DHBL_PP"] == DBNull.Value ? new bool?(false) : new bool?(Convert.ToBoolean(row1["DHBL_PP"]));
                        if ((!nullable2.GetValueOrDefault() ? 0 : (nullable2.HasValue ? 1 : 0)) != 0)
                        {
                            dataTable1 = new DataTable();
                            DataTable dataTable3 = this.PP(NVIA_Codigo, new int?(Convert.ToInt32(row1["CCOT_Numero"])), Convert.ToString(row1["CNTR_Numero"]));
                            if (dataTable3 != null && dataTable3.Rows.Count > 0)
                            {
                                foreach (DataRow row2 in (InternalDataCollectionBase)dataTable3.Rows)
                                {
                                    List<string> stringList2 = new List<string>();
                                    stringList2.Add(Convert.ToString(row2["DOOV_HBL"]));
                                    switch (Codigo_Regimen)
                                    {
                                        case "002":
                                            stringList2.Add(Convert.ToString(row2["ENTC_NomSHI"]));
                                            stringList2.Add(Convert.ToString(row2["ENTC_DocIdenSHI"]));
                                            break;
                                        case "001":
                                            stringList2.Add(Convert.ToString(row2["ENTC_NomCON"]));
                                            stringList2.Add(Convert.ToString(row2["ENTC_DocIdenCON"]));
                                            break;
                                    }
                                    stringList2.Add(Convert.ToString(row2["DHBL_CantBultos"]));
                                    stringList2.Add(Convert.ToString(row2["DHBL_PesoBruto"]));
                                    stringList2.Add(Convert.ToString(row2["CNTR_Pack_Numero"]));
                                    stringListList.Add(stringList2);
                                }
                            }
                        }
                    }
                    if (dataTable2.Rows.Count == num2)
                    {
                        stringListList.Insert(0, new List<string>()
            {
              empty5,
              empty6,
              empty7,
              Convert.ToString(num3),
              Convert.ToString(num4),
              str3
            });
                        foreach (List<string> records in stringListList)
                        {
                            wordDocument.FillTable(records, 2, rows);
                            ++rows;
                        }
                        wordDocument.SaveDocument(Editable);
                        wordDocument.CloseDocument();
                    }
                    ++num2;
                }
                if (Dialogos.MostrarMensajePregunta("ARCHIVOS", "¿Desea observar los documentos generados?", (Dialogos.LabelBoton)1) == DialogResult.Yes)
                    Process.Start("EXPLORER.EXE", str2);
                return str1;
            }
            catch (Exception ex)
            {
                return "#-ERROR INTERNO EN EL DESGLOSE DE VISTO BUENO-#" + Environment.NewLine + ex.Message;
            }
        }

        public string DevolucionMaster(bool Por_OV, string CCOT_NumDoc, string Numero_MBL, string Nombre_Transportista, string CONS_TabRGM, string CONS_CodRGM, int ENTC_CodTransportista)
        {
            string str1 = (string)null;
            try
            {
                string path2_1 = "DEVOLUCION_MASTER";
                string str2 = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), path2_1);
                Directory.CreateDirectory(str2);
                string empty1 = string.Empty;
                string empty2 = string.Empty;
                string path2_2 = "Plantillas\\\\DEVOLUCION_MASTER.docx";
                string empty3 = string.Empty;
                string empty4 = string.Empty;
                DataTable dataTable = this.Relacionados(new int?(ENTC_CodTransportista), CONS_TabRGM, CONS_CodRGM, "CON");
                if (dataTable != null && dataTable.Rows.Count > 0)
                {
                    empty3 = Convert.ToString(dataTable.Rows[0]["ENTC_Nombre"]);
                    Convert.ToString(dataTable.Rows[0]["ENTC_EMail"]);
                }
                if (string.IsNullOrEmpty(Numero_MBL))
                    return "No se encontro MBL's";
                DateTime today = DateTime.Today;
                string path3;
                if (Por_OV)
                    path3 = "DEVOLUCION_MASTER_OV_" + CCOT_NumDoc + "_" + today.ToString("MM_dd_yy") + ".docx";
                else
                    path3 = "DEVOLUCION_MASTER_" + today.ToString("MM_dd_yy") + ".docx";
                string _ruta = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), path2_1, path3);
                bool Editable = true;
                WordDocument wordDocument = new WordDocument(Path.Combine(Application.StartupPath, path2_2), _ruta);
                wordDocument.FindAndReplace((object)"<_lugar_fecha>", (object)("San Isidro, " + today.ToString("D")));
                wordDocument.FindAndReplace((object)"<_nro_ov>", (object)CCOT_NumDoc);
                wordDocument.FindAndReplace((object)"<_nombre_transportista>", (object)Nombre_Transportista);
                wordDocument.FindAndReplace((object)"<_nombre_contacto>", (object)empty3);
                wordDocument.FindAndReplace((object)"<_numero_mbl>", (object)Numero_MBL);
                wordDocument.SaveDocument(Editable);
                wordDocument.CloseDocument();
                if (Dialogos.MostrarMensajePregunta("ARCHIVOS", "¿Desea observar los documentos generados?", (Dialogos.LabelBoton)1) == DialogResult.Yes)
                    Process.Start("EXPLORER.EXE", str2);
                return str1;
            }
            catch (Exception ex)
            {
                return "#-ERROR INTERNO EN DEVOLUCION DE MASTER-#" + Environment.NewLine + ex.Message;
            }
        }

        public string CartaRecojo(bool Por_OV, string CCOT_NumDoc, string Nombre_Cliente, string Nombre_Contacto, string Nombre_Transportista, string Numero_MBL, string Nombre_Nave, string Numero_Viaje)
        {
            string str1 = (string)null;
            try
            {
                string path2_1 = "CARTA_DE_RECOJO";
                string str2 = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), path2_1);
                Directory.CreateDirectory(str2);
                string empty1 = string.Empty;
                string empty2 = string.Empty;
                string path2_2 = "Plantillas\\\\CARTA_DE_RECOJO.docx";
                if (string.IsNullOrEmpty(Numero_MBL))
                    return "No se encontro MBL's";
                DateTime today = DateTime.Today;
                string path3;
                if (Por_OV)
                    path3 = "CARTA_DE_RECOJO_OV_" + CCOT_NumDoc + "_" + today.ToString("MM_dd_yy") + ".docx";
                else
                    path3 = "CARTA_DE_RECOJO_" + today.ToString("MM_dd_yy") + ".docx";
                string _ruta = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), path2_1, path3);
                bool Editable = true;
                WordDocument wordDocument = new WordDocument(Path.Combine(Application.StartupPath, path2_2), _ruta);
                wordDocument.FindAndReplace((object)"<_lugar_fecha>", (object)("San Isidro, " + today.ToString("D")));
                wordDocument.FindAndReplace((object)"<_nombre_contacto>", (object)Nombre_Contacto);
                wordDocument.FindAndReplace((object)"<_numero_mbl>", (object)Numero_MBL);
                wordDocument.FindAndReplace((object)"<_nave_viaje>", (object)("MN: " + Nombre_Nave + " V.: " + Numero_Viaje));
                wordDocument.FindAndReplace((object)"<_nombre_transportista>", (object)Nombre_Transportista);
                wordDocument.SaveDocument(Editable);
                wordDocument.CloseDocument();
                if (Dialogos.MostrarMensajePregunta("ARCHIVOS", "¿Desea observar los documentos generados?", (Dialogos.LabelBoton)1) == DialogResult.Yes)
                    Process.Start("EXPLORER.EXE", str2);
                return str1;
            }
            catch (Exception ex)
            {
                return "#-ERROR INTERNO AL GENERAR LA CARTA DE RECOJO-#" + Environment.NewLine + ex.Message;
            }
        }

        public string CartaAutorizacionTransmision(bool Por_OV, string CCOT_NumDoc, string Nombre_Transportista, string Nombre_Empresa, string Ruc_Empresa, string Nombre_Cliente, string Ruc_Cliente, string Numero_MBL)
        {
            string str1 = (string)null;
            try
            {
                string path2_1 = "CARTA_AUTORIZACION_TRANSMISION";
                string str2 = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), path2_1);
                Directory.CreateDirectory(str2);
                string empty1 = string.Empty;
                string empty2 = string.Empty;
                string path2_2 = "Plantillas\\\\CARTA_AUTORIZACION_TRANSMISION.docx";
                if (string.IsNullOrEmpty(Numero_MBL))
                    return "No se encontro MBL's";
                DateTime today = DateTime.Today;
                string path3;
                if (Por_OV)
                    path3 = "CARTA_AUTORIZACION_TRANSMISION_OV_" + CCOT_NumDoc + "_" + today.ToString("MM_dd_yy") + ".docx";
                else
                    path3 = "CARTA_AUTORIZACION_TRANSMISION_" + today.ToString("MM_dd_yy") + ".docx";
                string _ruta = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), path2_1, path3);
                bool Editable = true;
                WordDocument wordDocument = new WordDocument(Path.Combine(Application.StartupPath, path2_2), _ruta);
                wordDocument.FindAndReplace((object)"<_lugar_fecha>", (object)("Lima, " + today.ToString("D")));
                wordDocument.FindAndReplace((object)"<_nombre_transportista>", (object)Nombre_Transportista);
                wordDocument.FindAndReplace((object)"<_nombre_empresa>", (object)Nombre_Empresa);
                wordDocument.FindAndReplace((object)"<_ruc_empresa>", (object)Ruc_Empresa);
                wordDocument.FindAndReplace((object)"<_nombre_cliente>", (object)Nombre_Cliente);
                wordDocument.FindAndReplace((object)"<_ruc_cliente>", (object)Ruc_Cliente);
                wordDocument.FindAndReplace((object)"<_numero_mbl>", (object)Numero_MBL);
                wordDocument.SaveDocument(Editable);
                wordDocument.CloseDocument();
                if (Dialogos.MostrarMensajePregunta("ARCHIVOS", "¿Desea observar los documentos generados?", (Dialogos.LabelBoton)1) == DialogResult.Yes)
                    Process.Start("EXPLORER.EXE", str2);
                return str1;
            }
            catch (Exception ex)
            {
                return "#-ERROR INTERNO AL GENERAR LA CARTA DE AUTORIZACION DE TRANSMISION-#" + Environment.NewLine + ex.Message;
            }
        }

        public string CargaTarjada(DataTable DtCargaTarjada, DateTime? Fecha_Llegada, DateTime? Fecha_Eta_Etd, string TIPO_Embarque, string Nombre_Transportista, string Nombre_Nave, string Nombre_TermPortuario, string Numero_Manifiesto, string Numero_Viaje, string Correo_Operaciones)
        {
            string str1 = (string)null;
            try
            {
                if (DtCargaTarjada == null || DtCargaTarjada.Rows.Count <= 0)
                    return "No se encontraron detalles en la(s) orden(es) de venta";
                foreach (DataRow row in (InternalDataCollectionBase)DtCargaTarjada.Rows)
                {
                    DateTime today = DateTime.Today;
                    string str2 = Convert.ToString(row["DOOV_HBL"]);
                    string empty1 = string.Empty;
                    if (Fecha_Llegada.HasValue)
                        empty1 = Convert.ToDateTime((object)Fecha_Llegada).ToString("dd/MM/yyyy");
                    string empty2 = string.Empty;
                    if (Fecha_Eta_Etd.HasValue)
                        empty2 = Convert.ToDateTime((object)Fecha_Eta_Etd).ToString("dd/MM/yyyy");
                    EnviarCorreo enviarCorreo = new EnviarCorreo();
                    StringBuilder stringBuilder = new StringBuilder();
                    stringBuilder.Append("<html>");
                    stringBuilder.Append("<font face=Verdana size=2 >");
                    stringBuilder.Append("<table bgcolor=#a6a6a6 border=1 cellpadding=4 cellspacing=0 style=font-size:30px;width:100%;font-face:Verdana >");
                    stringBuilder.Append("<thead><tr><th> INFORME DE CARGA TARJADA </th></tr></thead>");
                    stringBuilder.Append("</table>");
                    stringBuilder.Append("<body>");
                    stringBuilder.Append("<p align=left> <b> Lima, " + today.ToString("D") + "</b> </p>");
                    stringBuilder.Append("<p align=left> <b> Estimado Cliente: </b> <br/>");
                    stringBuilder.Append(Convert.ToString(row["ENTC_NomCliente"]) + " </p>");
                    stringBuilder.Append("<p align=left> <b> ATT: </b> <br/> ");
                    stringBuilder.Append(" DELFIN GROUP Co </p>");
                    stringBuilder.Append("<p align=left> <b> HBL: </b> " + str2.Trim() + "</p><br/>");
                    stringBuilder.Append("<p>");
                    stringBuilder.Append("Por el presente, reciban un cordial saludo y así mismo informales que la MN " + Nombre_Nave);
                    stringBuilder.Append(", arribó  a " + Convert.ToString(row["PUER_NomDestino"]) + " el " + empty1);
                    stringBuilder.Append(" bajo el manifiesto: " + Numero_Manifiesto);
                    stringBuilder.Append("</p>");
                    stringBuilder.Append("<p>");
                    stringBuilder.Append(" Asimismo indicamos que su carga ya se encuentra tarjada, ya pueden solicitar su Volante de Despacho al almacén para que inicien los trámites de su nacionalización, por lo que agradeceremos informar a vuestro agente de aduanas ");
                    stringBuilder.Append("</p><br/>");
                    stringBuilder.Append("<table bgcolor=#f2f2f2 border=1 cellpadding=4 cellspacing=0 style=font-size:13px;width:100%;font-face:Verdana >");
                    stringBuilder.Append("<tr><td><b> Buque </b></td><td>" + Nombre_Nave + "</td><td><b> Terminal </b></td><td>" + Convert.ToString(row["ENTC_NomAlmacen"]) + "</td></tr>");
                    stringBuilder.Append("<tr><td><b> HBL </b></td><td>" + str2.Trim() + "</td><td><b> Linea </b></td><td>" + Nombre_Transportista + "</td></tr>");
                    stringBuilder.Append("<tr><td><b> ETA </b></td><td>" + empty2 + "</td><td><b> Ref. Cliente </b></td><td>" + Convert.ToString(row["DOOV_CodReferencia"]) + "</td></tr>");
                    stringBuilder.Append("<tr><td><b> Cantidad </b></td><td>" + Convert.ToString(row["CANT_Bultos"]) + "</td><td><b> Consignee </b></td><td>" + Convert.ToString(row["ENTC_NomConsignee"]) + "</td></tr>");
                    stringBuilder.Append("<tr><td><b> Peso </b></td><td>" + Convert.ToString(row["CANT_PesoBruto"]) + "</td><td><b> Shipper </b></td><td>" + Convert.ToString(row["ENTC_NomShipper"]) + "</td></tr>");
                    stringBuilder.Append("<tr><td><b> Volumen </b></td><td>" + Convert.ToString(row["CANT_Volumen"]) + "</td><td><b> </b></td><td> </td></tr>");
                    stringBuilder.Append("<tr><td><b> POL </b></td><td>" + Convert.ToString(row["PUER_NomOrigen"]) + "</td><td><b> </b></td><td> </td></tr>");
                    stringBuilder.Append("<tr><td><b> Destino </b></td><td>" + Convert.ToString(row["PUER_NomDestino"]) + "</td><td><b></b> </td><td> </td></tr>");
                    stringBuilder.Append("</table>");
                    if (TIPO_Embarque != "FCL")
                        stringBuilder.Append("<p align=left><b> Fecha de Tarja: -Ingrese la Fecha- </b></p>");
                    stringBuilder.Append("<p align=left><b> Atentamente </b></p>");
                    stringBuilder.Append("<p align=left> Sin otro particular quedamos de Uds. </p>");
                    stringBuilder.Append("</body>");
                    stringBuilder.Append("</font>");
                    stringBuilder.Append("</html>");
                    string _body = stringBuilder.ToString();
                    string _recipient1 = Convert.ToString(row["ENTC_EMailCliente"]);
                    string _olCCrecipient = Correo_Operaciones;
                    string _subject = "INFORME DE CARGA TARJADA \\ " + str2.Trim() + " \\ MN: " + Nombre_Nave + " V.- " + Numero_Viaje + Convert.ToString(row["DOOV_CodReferencia"]);
                    bool _enviar = true;
                    if (TIPO_Embarque != "FCL")
                        _enviar = false;
                    if (_enviar)
                    {
                        if (!string.IsNullOrEmpty(_recipient1))
                        {
                            enviarCorreo.enviaCorreo(_enviar, _recipient1, _olCCrecipient, _subject, _body);
                        }
                        else
                        {
                            int num = (int)Dialogos.MostrarMensajeInformacion("Envio de Correo", "No se puedo generar o enviar el correo por que " + Convert.ToString(row["ENTC_NomCliente"]) + " no cuenta con un correo electronico", (Dialogos.Boton)0);
                        }
                    }
                    else if (!string.IsNullOrEmpty(_recipient1))
                    {
                        enviarCorreo.enviaCorreo(_enviar, _recipient1, _olCCrecipient, _subject, _body);
                    }
                    else
                    {
                        string _recipient2 = "<INGRESE_UN_CORREO>";
                        enviarCorreo.enviaCorreo(_enviar, _recipient2, _olCCrecipient, _subject, _body);
                    }
                }
                return str1;
            }
            catch (Exception ex)
            {
                return "#-ERROR INTERNO AL GENERAR LA CARGA TARJADA-#" + Environment.NewLine + ex.Message;
            }
        }

        public string Avisos(DataTable DtAvisos, string CONS_TabRGM, string CONS_CodRGM, string CONS_TabVIA, string CONS_CodVIA, string Nombre_Transportista, string Nombre_AgenteVoBo, string Nombre_AgenteVoBo2, string Nombre_Nave, string Numero_Viaje, DateTime? Fecha_Eta_Etd, DateTime? Fecha_Llegada_Zarpe, DateTime? Fecha_RecogoDocs, DateTime? Fecha_CierreDire, string Correo_Operaciones, string Correo_Logistica)
        {
            string str1 = (string)null;
            try
            {
                if (DtAvisos == null)
                    return "No se encuentra Habilitada la Opción de Aviso de Llegada y/ó No se encontraron detalles en la(s) orden(es) de venta";
                string str2 = string.Empty;
                if (!string.IsNullOrEmpty(Nombre_AgenteVoBo) && !string.IsNullOrEmpty(Nombre_AgenteVoBo2))
                {
                    str2 = string.Format("{0} / {1}", (object)Nombre_AgenteVoBo, (object)Nombre_AgenteVoBo2);
                }
                else
                {
                    if (!string.IsNullOrEmpty(Nombre_AgenteVoBo))
                        str2 = Nombre_AgenteVoBo;
                    if (!string.IsNullOrEmpty(Nombre_AgenteVoBo2))
                        str2 = Nombre_AgenteVoBo2;
                }
                DateTime today = DateTime.Today;
                string path2_1 = "AVISOS";
                Directory.CreateDirectory(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), path2_1));
                string path3 = string.Empty;
                string path2_2 = "Plantillas\\\\RECOJO_DE_BL.docx";
                string path2_3 = string.Empty;
                if (CONS_CodRGM == "002")
                {
                    switch (CONS_CodVIA)
                    {
                        case "002":
                            path3 = "AVISO_DE_SALIDA_AEREO_" + today.ToString("MM_dd_yy") + ".docx";
                            path2_3 = "Plantillas\\\\AVISO_DE_SALIDA_AEREO.docx";
                            break;
                        case "001":
                            path3 = "AVISO_DE_ZARPE_MARITIMO_" + today.ToString("MM_dd_yy") + ".docx";
                            path2_3 = "Plantillas\\\\AVISO_DE_ZARPE_MARITIMO.docx";
                            break;
                    }
                }
                if (CONS_CodRGM == "001")
                {
                    switch (CONS_CodVIA)
                    {
                        case "002":
                            path3 = "AVISO_DE_ARRIBO_AEREO_" + today.ToString("MM_dd_yy") + ".docx";
                            path2_3 = "Plantillas\\\\AVISO_DE_ARRIBO_AEREO.docx";
                            break;
                        case "001":
                            path3 = "AVISO_DE_ARRIBO_MARITIMO_" + today.ToString("MM_dd_yy") + ".docx";
                            path2_3 = "Plantillas\\\\AVISO_DE_ARRIBO_MARITIMO.docx";
                            break;
                    }
                }
                string _ruta = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), path2_1, path3);
                string _ruta2 = Path.Combine(Application.StartupPath, path2_2);
                bool Editable = true;
                EnviarCorreo enviarCorreo = new EnviarCorreo();
                string empty1 = string.Empty;
                string empty2 = string.Empty;
                string empty3 = string.Empty;
                string empty4 = string.Empty;
                string empty5 = string.Empty;
                string empty6 = string.Empty;
                string _subject = string.Empty;
                string empty7 = string.Empty;
                bool _enviar = true;
                StringBuilder stringBuilder = new StringBuilder();
                stringBuilder.Append("<html>");
                stringBuilder.Append("<font color= #2f5496 >");
                stringBuilder.Append("<body>");
                stringBuilder.Append("<h4>Estimado Cliente: </h4>");
                if (CONS_CodRGM == "002")
                {
                    switch (CONS_CodVIA)
                    {
                        case "002":
                            stringBuilder.Append("<p>Por medio de la presente adjuntamos el Aviso de Salida de Exportación Aérea correspondiente al embarque en referencia.</p>");
                            break;
                        case "001":
                            stringBuilder.Append("<p>Por medio de la presente adjuntamos el Aviso de Zarpe de Exportación Marítima correspondiente al embarque en referencia.</p>");
                            break;
                    }
                }
                if (CONS_CodRGM == "001")
                {
                    switch (CONS_CodVIA)
                    {
                        case "002":
                            stringBuilder.Append("<p>Por medio de la presente adjuntamos el Aviso de Arribo de Importación Aérea correspondiente al embarque en referencia.</p>");
                            break;
                        case "001":
                            stringBuilder.Append("<p>Por medio de la presente adjuntamos el Aviso de Arribo de Importación Maritima correspondiente al embarque en referencia.</p>");
                            break;
                    }
                }
                stringBuilder.Append("<p>En caso tengan documentos originales y/o copias  por recoger deberán entregar la carta de recojo adjunta para que procedan con la entrega respectiva.</p>");
                stringBuilder.Append("<p>Asimismo se les solicita reenviar este aviso a su Agencia de aduanas.</p>");
                stringBuilder.Append("<p><b>Muchas gracias por confiar en Delfin Group para el manejo de sus cargas.</b></p>");
                stringBuilder.Append("<p><b>Saludos Cordiales</b></p>");
                stringBuilder.Append("</body>");
                stringBuilder.Append("</font>");
                stringBuilder.Append("</html>");
                foreach (DataRow row in (InternalDataCollectionBase)DtAvisos.Rows)
                {
                    string empty8 = string.Empty;
                    if (Fecha_Eta_Etd.HasValue)
                        empty8 = Convert.ToDateTime((object)Fecha_Eta_Etd).ToString("dd/MM/yyyy");
                    string empty9 = string.Empty;
                    if (Fecha_Llegada_Zarpe.HasValue)
                        empty9 = Convert.ToDateTime((object)Fecha_Llegada_Zarpe).ToString("dd/MM/yyyy");
                    string empty10 = string.Empty;
                    if (Fecha_RecogoDocs.HasValue)
                        empty10 = Convert.ToDateTime((object)Fecha_RecogoDocs).ToString("dd/MM/yyyy");
                    string empty11 = string.Empty;
                    if (Fecha_CierreDire.HasValue)
                        empty11 = Convert.ToDateTime((object)Fecha_CierreDire).ToString("dd/MM/yyyy");
                    WordDocument x_xd = new WordDocument(Path.Combine(Application.StartupPath, path2_3), _ruta);
                    string empty12 = string.Empty;
                    string empty13 = string.Empty;
                    DataTable dataTable1 = this.Relacionados(new int?(Convert.ToInt32(row["ENTC_CodCliente"])), CONS_TabRGM, CONS_CodRGM, "CON");
                    if (dataTable1 != null && dataTable1.Rows.Count > 0)
                    {
                        empty12 = Convert.ToString(dataTable1.Rows[0]["ENTC_Nombre"]);
                        empty13 = Convert.ToString(dataTable1.Rows[0]["ENTC_EMail"]);
                    }
                    DataTable dataTable2;
                    if (CONS_CodRGM == "002")
                    {
                        switch (CONS_CodVIA)
                        {
                            case "002":
                                x_xd.FindAndReplace((object)"<_lugar_fecha>", (object)("San Isidro, " + today.ToString("D")));
                                x_xd.FindAndReplace((object)"<_nro_ove>", (object)Convert.ToString(row["CCOT_NumDoc"]));
                                x_xd.FindAndReplace((object)"<_nombre_cliente>", (object)Convert.ToString(row["ENTC_NomCliente"]));
                                x_xd.FindAndReplace((object)"<_nombre_contacto>", (object)empty12);
                                x_xd.FindAndReplace((object)"<_email_contacto>", (object)empty13);
                                x_xd.FindAndReplace((object)"<_nro_hbl>", (object)Convert.ToString(row["DOOV_HBL"]));
                                x_xd.FindAndReplace((object)"<_nombre_consignee>", (object)Convert.ToString(row["ENTC_NomConsignee"]));
                                x_xd.FindAndReplace((object)"<_referencia>", (object)Convert.ToString(row["DOOV_CodReferencia"]));
                                x_xd.FindAndReplace((object)"<_puerto_origen>", (object)Convert.ToString(row["PUER_NomOrigen"]));
                                x_xd.FindAndReplace((object)"<_puerto_destino>", (object)Convert.ToString(row["PUER_NomDestino"]));
                                x_xd.FindAndReplace((object)"<_nombre_transportista>", (object)Nombre_Transportista);
                                x_xd.FindAndReplace((object)"<_nave_viaje>", (object)(Nombre_Nave + "-" + Numero_Viaje));
                                x_xd.FindAndReplace((object)"<_cant_bultos>", (object)Convert.ToString(row["CANT_Bultos"]));
                                x_xd.FindAndReplace((object)"<_cant_peso>", (object)Convert.ToString(row["CANT_PesoBruto"]));
                                x_xd.FindAndReplace((object)"<_fecha_etd>", (object)empty9);
                                x_xd.FindAndReplace((object)"<_nombre_deposito>", (object)Convert.ToString(row["ENTC_NomDeposito"]));
                                x_xd.FindAndReplace((object)"<_fecha_recojo>", (object)empty10);
                                short? EMPR_Codigo1 = new short?(Convert.ToInt16(row["EMPR_Codigo"]));
                                int? CCOT_Numero1 = new int?(Convert.ToInt32(row["CCOT_Numero"]));
                                dataTable2 = new DataTable();
                                DataTable x_DtPorPagar1 = this.PorPagar(EMPR_Codigo1, CCOT_Numero1);
                                this.FillTablePorPagar(ref x_xd, x_DtPorPagar1);
                                _subject = "AVISO DE SALIDA DE EXPORTACION AEREA // " + Nombre_Nave + " - Vuelo:" + Numero_Viaje + " // " + Convert.ToString(row["DOOV_HBL"]) + " // " + Convert.ToString(row["DOOV_CodReferencia"]);
                                break;
                            case "001":
                                x_xd.FindAndReplace((object)"<_lugar_fecha>", (object)("San Isidro, " + today.ToString("D")));
                                x_xd.FindAndReplace((object)"<_nro_ove>", (object)Convert.ToString(row["CCOT_NumDoc"]));
                                x_xd.FindAndReplace((object)"<_nombre_cliente>", (object)Convert.ToString(row["ENTC_NomCliente"]));
                                x_xd.FindAndReplace((object)"<_nombre_contacto>", (object)empty12);
                                x_xd.FindAndReplace((object)"<_email_contacto>", (object)empty13);
                                x_xd.FindAndReplace((object)"<_nro_hbl>", (object)Convert.ToString(row["DOOV_HBL"]));
                                x_xd.FindAndReplace((object)"<_nombre_consignee>", (object)Convert.ToString(row["ENTC_NomConsignee"]));
                                x_xd.FindAndReplace((object)"<_puerto_origen>", (object)Convert.ToString(row["PUER_NomOrigen"]));
                                x_xd.FindAndReplace((object)"<_puerto_destino>", (object)Convert.ToString(row["PUER_NomDestino"]));
                                x_xd.FindAndReplace((object)"<_fecha_zarpe>", (object)empty9);
                                x_xd.FindAndReplace((object)"<_nombre_deposito>", (object)Convert.ToString(row["ENTC_NomDeposito"]));
                                string[] strArray1 = row["NUM_Cntr"].ToString().Split('/');
                                int num1 = 0;
                                foreach (string str3 in strArray1)
                                {
                                    if (++num1 == 1)
                                        x_xd.FindAndReplace((object)"<_nros_contenedores>", (object)(str3 + "/ <_nros_contenedores>"));
                                    else
                                        x_xd.FindAndReplace((object)"<_nros_contenedores>", (object)(str3 + "/ <_nros_contenedores>"));
                                }
                                x_xd.FindAndReplace((object)"<_nros_contenedores>", (object)"");
                                x_xd.FindAndReplace((object)"<_nave_viaje>", (object)(Nombre_Nave + "-" + Numero_Viaje));
                                x_xd.FindAndReplace((object)"<_detalle_contenedor>", (object)Convert.ToString(row["TIPO_Embalaje"]));
                                x_xd.FindAndReplace((object)"<_cant_bultos>", (object)Convert.ToString(row["CANT_Bultos"]));
                                x_xd.FindAndReplace((object)"<_cant_peso>", (object)Convert.ToString(row["CANT_PesoBruto"]));
                                x_xd.FindAndReplace((object)"<_visto_bueno>", (object)str2);
                                x_xd.FindAndReplace((object)"<_nombre_transportista>", (object)Nombre_Transportista);
                                x_xd.FindAndReplace((object)"<_fecha_recojo>", (object)empty10);
                                short? EMPR_Codigo2 = new short?(Convert.ToInt16(row["EMPR_Codigo"]));
                                int? CCOT_Numero2 = new int?(Convert.ToInt32(row["CCOT_Numero"]));
                                dataTable2 = new DataTable();
                                DataTable x_DtPorPagar2 = this.PorPagar(EMPR_Codigo2, CCOT_Numero2);
                                this.FillTablePorPagar(ref x_xd, x_DtPorPagar2);
                                _subject = "AVISO DE ZARPE DE EXPORTACION MARITIMA // " + Nombre_Nave + " - Viaje:" + Numero_Viaje + " // " + Convert.ToString(row["DOOV_HBL"]) + " // " + Convert.ToString(row["DOOV_CodReferencia"]);
                                break;
                        }
                    }
                    if (CONS_CodRGM == "001")
                    {
                        switch (CONS_CodVIA)
                        {
                            case "002":
                                x_xd.FindAndReplace((object)"<_lugar_fecha>", (object)("San Isidro, " + today.ToString("D")));
                                x_xd.FindAndReplace((object)"<_nro_ove>", (object)Convert.ToString(row["CCOT_NumDoc"]));
                                x_xd.FindAndReplace((object)"<_nombre_cliente>", (object)Convert.ToString(row["ENTC_NomCliente"]));
                                x_xd.FindAndReplace((object)"<_nombre_contacto>", (object)empty12);
                                x_xd.FindAndReplace((object)"<_email_contacto>", (object)empty13);
                                x_xd.FindAndReplace((object)"<_nro_hbl>", (object)Convert.ToString(row["DOOV_HBL"]));
                                x_xd.FindAndReplace((object)"<_nombre_proveedor>", (object)Convert.ToString(row["ENTC_NomShipper"]));
                                x_xd.FindAndReplace((object)"<_referencia>", (object)Convert.ToString(row["DOOV_CodReferencia"]));
                                x_xd.FindAndReplace((object)"<_puerto_origen>", (object)Convert.ToString(row["PUER_NomOrigen"]));
                                x_xd.FindAndReplace((object)"<_puerto_destino>", (object)Convert.ToString(row["PUER_NomDestino"]));
                                x_xd.FindAndReplace((object)"<_nombre_deposito>", (object)Convert.ToString(row["ENTC_NomDeposito"]));
                                x_xd.FindAndReplace((object)"<_nombre_transportista>", (object)Nombre_Transportista);
                                x_xd.FindAndReplace((object)"<_nave_viaje>", (object)(Nombre_Nave + "-" + Numero_Viaje));
                                x_xd.FindAndReplace((object)"<_cant_bultos>", (object)Convert.ToString(row["CANT_Bultos"]));
                                x_xd.FindAndReplace((object)"<_cant_peso>", (object)Convert.ToString(row["CANT_PesoBruto"]));
                                x_xd.FindAndReplace((object)"<_fecha_eta>", (object)empty8);
                                short? EMPR_Codigo3 = new short?(Convert.ToInt16(row["EMPR_Codigo"]));
                                int? CCOT_Numero3 = new int?(Convert.ToInt32(row["CCOT_Numero"]));
                                dataTable2 = new DataTable();
                                DataTable x_DtPorPagar3 = this.PorPagar(EMPR_Codigo3, CCOT_Numero3);
                                this.FillTablePorPagar(ref x_xd, x_DtPorPagar3);
                                _subject = "AVISO DE ARRIBO DE IMPORTACION AEREA // " + Nombre_Nave + " - Vuelo:" + Numero_Viaje + " // " + Convert.ToString(row["DOOV_HBL"]) + " // " + Convert.ToString(row["DOOV_CodReferencia"]);
                                break;
                            case "001":
                                x_xd.FindAndReplace((object)"<_lugar_fecha>", (object)("San Isidro, " + today.ToString("D")));
                                x_xd.FindAndReplace((object)"<_nro_ove>", (object)Convert.ToString(row["CCOT_NumDoc"]));
                                x_xd.FindAndReplace((object)"<_nombre_cliente>", (object)Convert.ToString(row["ENTC_NomCliente"]));
                                x_xd.FindAndReplace((object)"<_nombre_contacto>", (object)empty12);
                                x_xd.FindAndReplace((object)"<_email_contacto>", (object)empty13);
                                x_xd.FindAndReplace((object)"<_nro_hbl>", (object)Convert.ToString(row["DOOV_HBL"]));
                                x_xd.FindAndReplace((object)"<_nave_viaje>", (object)(Nombre_Nave + "-" + Numero_Viaje));
                                x_xd.FindAndReplace((object)"<_nombre_proveedor>", (object)Convert.ToString(row["ENTC_NomShipper"]));
                                x_xd.FindAndReplace((object)"<_puerto_origen>", (object)Convert.ToString(row["PUER_NomOrigen"]));
                                if (row["DDOV_FecEmbarque"] != DBNull.Value)
                                {
                                    DateTime dateTime = Convert.ToDateTime(row["DDOV_FecEmbarque"]);
                                    x_xd.FindAndReplace((object)"<_fecha_zarpe>", (object)dateTime.ToString("dd/MM/yyyy"));
                                }
                                else
                                    x_xd.FindAndReplace((object)"<_fecha_zarpe>", (object)"");
                                x_xd.FindAndReplace((object)"<_fecha_eta>", (object)empty8);
                                x_xd.FindAndReplace((object)"<_nombre_deposito>", (object)Convert.ToString(row["ENTC_NomDeposito"]));
                                x_xd.FindAndReplace((object)"<_visto_bueno>", (object)str2);
                                string[] strArray2 = row["NUM_Cntr"].ToString().Split('/');
                                int num2 = 0;
                                foreach (string str3 in strArray2)
                                {
                                    if (++num2 == 1)
                                        x_xd.FindAndReplace((object)"<_nros_contenedores>", (object)(str3 + "/ <_nros_contenedores>"));
                                    else
                                        x_xd.FindAndReplace((object)"<_nros_contenedores>", (object)(str3 + "/ <_nros_contenedores>"));
                                }
                                x_xd.FindAndReplace((object)"<_nros_contenedores>", (object)"");
                                x_xd.FindAndReplace((object)"<_referencia>", (object)Convert.ToString(row["DOOV_CodReferencia"]));
                                x_xd.FindAndReplace((object)"<_puerto_destino>", (object)Convert.ToString(row["PUER_NomDestino"]));
                                x_xd.FindAndReplace((object)"<_cant_bultos>", (object)Convert.ToString(row["CANT_Bultos"]));
                                x_xd.FindAndReplace((object)"<_detalle_contenedor>", (object)Convert.ToString(row["TIPO_Embalaje"]));
                                x_xd.FindAndReplace((object)"<_cant_peso>", (object)Convert.ToString(row["CANT_PesoBruto"]));
                                x_xd.FindAndReplace((object)"<_cant_volumen>", (object)Convert.ToString(row["CANT_Volumen"]));
                                x_xd.FindAndReplace((object)"<_nombre_transportista>", (object)Nombre_Transportista);
                                x_xd.FindAndReplace((object)"<_emitir_hbl>", (object)Convert.ToString(row["EmitirHBL"]));
                                x_xd.FindAndReplace((object)"<_fecha_cierredireccionamiento>", (object)empty11);
                                short? EMPR_Codigo4 = new short?(Convert.ToInt16(row["EMPR_Codigo"]));
                                int? CCOT_Numero4 = new int?(Convert.ToInt32(row["CCOT_Numero"]));
                                dataTable2 = new DataTable();
                                DataTable x_DtPorPagar4 = this.PorPagar(EMPR_Codigo4, CCOT_Numero4);
                                this.FillTablePorPagar(ref x_xd, x_DtPorPagar4);
                                _subject = "AVISO DE ARRIBO DE IMPORTACION MARITIMA // " + Nombre_Nave + " - Viaje:" + Numero_Viaje + " // " + Convert.ToString(row["DOOV_HBL"]) + " // " + Convert.ToString(row["DOOV_CodReferencia"]);
                                break;
                        }
                    }
                    x_xd.SaveDocument(Editable);
                    x_xd.CloseDocument();
                    string str4 = Correo_Operaciones;
                    if (string.IsNullOrEmpty(str4))
                        str4 = string.Empty;
                    string empty14 = Convert.ToString(row["ENTC_EmailCustomer"]);
                    if (string.IsNullOrEmpty(empty14))
                        empty14 = string.Empty;
                    string empty15 = Convert.ToString(row["ENTC_EmailEjecutivo"]);
                    if (string.IsNullOrEmpty(empty15))
                        empty15 = string.Empty;
                    string str5 = Correo_Logistica;
                    if (string.IsNullOrEmpty(str5))
                        str5 = string.Empty;
                    string _olCCrecipient;
                    if (Convert.ToBoolean(row["CCOT_ServicioLogistico"]))
                        _olCCrecipient = str4 + "; " + empty14 + "; " + empty15 + "; " + str5;
                    else
                        _olCCrecipient = str4 + "; " + empty14 + "; " + empty15;
                    string _body = stringBuilder.ToString();
                    Convert.ToBoolean(row["CCOT_EmitirHBL"]);
                    string _recipient = Convert.ToString(row["ENTC_EMailCliente"]);
                    if (!string.IsNullOrEmpty(_recipient))
                        enviarCorreo.enviaCorreo(_enviar, _recipient, _olCCrecipient, _subject, _body, _ruta, _ruta2);
                }
                return str1;
            }
            catch (Exception ex)
            {
                return "#-ERROR INTERNO AL EMITIR LOS AVISOS-#" + Environment.NewLine + ex.Message;
            }
        }

        public string Avisos(DataTable DtAvisos, string CCOT_NumDoc)
        {
            string str1 = (string)null;
            try
            {
                if (DtAvisos == null || DtAvisos.Rows.Count <= 0)
                    return "No se encuentra Habilitada la Opción de Aviso de Llegada y/ó No se encontraron detalles en la(s) orden(es) de venta";
                DateTime today = DateTime.Today;
                string path2_1 = "AVISOS";
                Directory.CreateDirectory(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), path2_1));
                string path3 = string.Empty;
                string path2_2 = string.Empty;
                foreach (DataRow row in (InternalDataCollectionBase)DtAvisos.Rows)
                {
                    string str2 = Convert.ToString(row["VoBo"]);
                    string str3 = Convert.ToString(row["ENTC_NomLinea"]);
                    string str4 = Convert.ToString(row["NAVE_Nombre"]);
                    string str5 = Convert.ToString(row["NVIA_NroViaje"]);
                    string str6 = Convert.ToString(row["Fecha_Eta_Etd"]);
                    string str7 = Convert.ToString(row["Fecha_Llegada_Zarpe"]);
                    string str8 = Convert.ToString(row["Fecha_RecogoDocs"]);
                    string str9 = Convert.ToString(row["Fecha_CierreDire"]);
                    if (Convert.ToString(row["CONS_CodRGM"]) == "002")
                    {
                        switch (Convert.ToString(row["CONS_CodVia"]))
                        {
                            case "002":
                                path3 = "AVISO_DE_SALIDA_AEREO_" + today.ToString("MM_dd_yy") + "_" + CCOT_NumDoc + ".docx";
                                path2_2 = "Plantillas\\\\AVISO_DE_SALIDA_AEREO.docx";
                                break;
                            case "001":
                                path3 = "AVISO_DE_ZARPE_MARITIMO_" + today.ToString("MM_dd_yy") + "_" + CCOT_NumDoc + ".docx";
                                path2_2 = "Plantillas\\\\AVISO_DE_ZARPE_MARITIMO.docx";
                                break;
                        }
                    }
                    if (Convert.ToString(row["CONS_CodRGM"]) == "001")
                    {
                        switch (Convert.ToString(row["CONS_CodVia"]))
                        {
                            case "002":
                                path3 = "AVISO_DE_ARRIBO_AEREO_" + today.ToString("MM_dd_yy") + "_" + CCOT_NumDoc + ".docx";
                                path2_2 = "Plantillas\\\\AVISO_DE_ARRIBO_AEREO.docx";
                                break;
                            case "001":
                                path3 = "AVISO_DE_ARRIBO_MARITIMO_" + today.ToString("MM_dd_yy") + "_" + CCOT_NumDoc + ".docx";
                                path2_2 = "Plantillas\\\\AVISO_DE_ARRIBO_MARITIMO.docx";
                                break;
                        }
                    }
                    string str10 = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), path2_1, path3);
                    bool Editable = true;
                    WordDocument x_xd = (WordDocument)null;
                    x_xd = new WordDocument(Path.Combine(Application.StartupPath, path2_2), str10);
                    string empty1 = string.Empty;
                    string empty2 = string.Empty;
                    DataTable dataTable1 = this.Relacionados(new int?(Convert.ToInt32(row["ENTC_CodCliente"])), Convert.ToString(row["CONS_TabRGM"]), Convert.ToString(row["CONS_CodRGM"]), "CON");
                    if (dataTable1 != null && dataTable1.Rows.Count > 0)
                    {
                        empty1 = Convert.ToString(dataTable1.Rows[0]["ENTC_Nombre"]);
                        empty2 = Convert.ToString(dataTable1.Rows[0]["ENTC_EMail"]);
                    }
                    DataTable dataTable2;
                    if (Convert.ToString(row["CONS_CodRGM"]) == "002")
                    {
                        switch (Convert.ToString(row["CONS_CodVia"]))
                        {
                            case "002":
                                x_xd.FindAndReplace((object)"<_lugar_fecha>", (object)("San Isidro, " + today.ToString("D")));
                                x_xd.FindAndReplace((object)"<_nro_ove>", (object)Convert.ToString(row["CCOT_NumDoc"]));
                                x_xd.FindAndReplace((object)"<_nombre_cliente>", (object)Convert.ToString(row["ENTC_NomCliente"]));
                                x_xd.FindAndReplace((object)"<_nombre_contacto>", (object)empty1);
                                x_xd.FindAndReplace((object)"<_email_contacto>", (object)empty2);
                                x_xd.FindAndReplace((object)"<_nro_hbl>", (object)Convert.ToString(row["DOOV_HBL"]));
                                x_xd.FindAndReplace((object)"<_nombre_consignee>", (object)Convert.ToString(row["ENTC_NomConsignee"]));
                                x_xd.FindAndReplace((object)"<_referencia>", (object)Convert.ToString(row["DOOV_CodReferencia"]));
                                x_xd.FindAndReplace((object)"<_puerto_origen>", (object)Convert.ToString(row["PUER_NomOrigen"]));
                                x_xd.FindAndReplace((object)"<_puerto_destino>", (object)Convert.ToString(row["PUER_NomDestino"]));
                                x_xd.FindAndReplace((object)"<_nombre_transportista>", (object)str3);
                                x_xd.FindAndReplace((object)"<_nave_viaje>", (object)(str4 + "-" + str5));
                                x_xd.FindAndReplace((object)"<_cant_bultos>", (object)Convert.ToString(row["CANT_Bultos"]));
                                x_xd.FindAndReplace((object)"<_cant_peso>", (object)Convert.ToString(row["CANT_PesoBruto"]));
                                x_xd.FindAndReplace((object)"<_fecha_etd>", (object)str7);
                                x_xd.FindAndReplace((object)"<_nombre_deposito>", (object)Convert.ToString(row["ENTC_NomDeposito"]));
                                x_xd.FindAndReplace((object)"<_fecha_recojo>", (object)str8);
                                short? EMPR_Codigo1 = new short?(Convert.ToInt16(row["EMPR_Codigo"]));
                                int? CCOT_Numero1 = new int?(Convert.ToInt32(row["CCOT_Numero"]));
                                dataTable2 = new DataTable();
                                DataTable x_DtPorPagar1 = this.PorPagar(EMPR_Codigo1, CCOT_Numero1);
                                this.FillTablePorPagar(ref x_xd, x_DtPorPagar1);
                                break;
                            case "001":
                                x_xd.FindAndReplace((object)"<_lugar_fecha>", (object)("San Isidro, " + today.ToString("D")));
                                x_xd.FindAndReplace((object)"<_nro_ove>", (object)Convert.ToString(row["CCOT_NumDoc"]));
                                x_xd.FindAndReplace((object)"<_nombre_cliente>", (object)Convert.ToString(row["ENTC_NomCliente"]));
                                x_xd.FindAndReplace((object)"<_nombre_contacto>", (object)empty1);
                                x_xd.FindAndReplace((object)"<_email_contacto>", (object)empty2);
                                x_xd.FindAndReplace((object)"<_nro_hbl>", (object)Convert.ToString(row["DOOV_HBL"]));
                                x_xd.FindAndReplace((object)"<_nombre_consignee>", (object)Convert.ToString(row["ENTC_NomConsignee"]));
                                x_xd.FindAndReplace((object)"<_puerto_origen>", (object)Convert.ToString(row["PUER_NomOrigen"]));
                                x_xd.FindAndReplace((object)"<_puerto_destino>", (object)Convert.ToString(row["PUER_NomDestino"]));
                                x_xd.FindAndReplace((object)"<_fecha_zarpe>", (object)str7);
                                x_xd.FindAndReplace((object)"<_nombre_deposito>", (object)Convert.ToString(row["ENTC_NomDeposito"]));
                                string[] strArray1 = row["NUM_Cntr"].ToString().Split('/');
                                int num1 = 0;
                                foreach (string str11 in strArray1)
                                {
                                    if (++num1 == 1)
                                        x_xd.FindAndReplace((object)"<_nros_contenedores>", (object)(str11 + "/ <_nros_contenedores>"));
                                    else
                                        x_xd.FindAndReplace((object)"<_nros_contenedores>", (object)(str11 + "/ <_nros_contenedores>"));
                                }
                                x_xd.FindAndReplace((object)"<_nros_contenedores>", (object)"");
                                x_xd.FindAndReplace((object)"<_nave_viaje>", (object)(str4 + "-" + str5));
                                x_xd.FindAndReplace((object)"<_detalle_contenedor>", (object)Convert.ToString(row["TIPO_Embalaje"]));
                                x_xd.FindAndReplace((object)"<_cant_bultos>", (object)Convert.ToString(row["CANT_Bultos"]));
                                x_xd.FindAndReplace((object)"<_cant_peso>", (object)Convert.ToString(row["CANT_PesoBruto"]));
                                x_xd.FindAndReplace((object)"<_visto_bueno>", (object)str2);
                                x_xd.FindAndReplace((object)"<_nombre_transportista>", (object)str3);
                                x_xd.FindAndReplace((object)"<_fecha_recojo>", (object)str8);
                                short? EMPR_Codigo2 = new short?(Convert.ToInt16(row["EMPR_Codigo"]));
                                int? CCOT_Numero2 = new int?(Convert.ToInt32(row["CCOT_Numero"]));
                                dataTable2 = new DataTable();
                                DataTable x_DtPorPagar2 = this.PorPagar(EMPR_Codigo2, CCOT_Numero2);
                                this.FillTablePorPagar(ref x_xd, x_DtPorPagar2);
                                break;
                        }
                    }
                    if (Convert.ToString(row["CONS_CodRGM"]) == "001")
                    {
                        switch (Convert.ToString(row["CONS_CodVia"]))
                        {
                            case "002":
                                x_xd.FindAndReplace((object)"<_lugar_fecha>", (object)("San Isidro, " + today.ToString("D")));
                                x_xd.FindAndReplace((object)"<_nro_ove>", (object)Convert.ToString(row["CCOT_NumDoc"]));
                                x_xd.FindAndReplace((object)"<_nombre_cliente>", (object)Convert.ToString(row["ENTC_NomCliente"]));
                                x_xd.FindAndReplace((object)"<_nombre_contacto>", (object)empty1);
                                x_xd.FindAndReplace((object)"<_email_contacto>", (object)empty2);
                                x_xd.FindAndReplace((object)"<_nro_hbl>", (object)Convert.ToString(row["DOOV_HBL"]));
                                x_xd.FindAndReplace((object)"<_nombre_proveedor>", (object)Convert.ToString(row["ENTC_NomShipper"]));
                                x_xd.FindAndReplace((object)"<_referencia>", (object)Convert.ToString(row["DOOV_CodReferencia"]));
                                x_xd.FindAndReplace((object)"<_puerto_origen>", (object)Convert.ToString(row["PUER_NomOrigen"]));
                                x_xd.FindAndReplace((object)"<_puerto_destino>", (object)Convert.ToString(row["PUER_NomDestino"]));
                                x_xd.FindAndReplace((object)"<_nombre_deposito>", (object)Convert.ToString(row["ENTC_NomDeposito"]));
                                x_xd.FindAndReplace((object)"<_nombre_transportista>", (object)str3);
                                x_xd.FindAndReplace((object)"<_nave_viaje>", (object)(str4 + "-" + str5));
                                x_xd.FindAndReplace((object)"<_cant_bultos>", (object)Convert.ToString(row["CANT_Bultos"]));
                                x_xd.FindAndReplace((object)"<_cant_peso>", (object)Convert.ToString(row["CANT_PesoBruto"]));
                                x_xd.FindAndReplace((object)"<_fecha_eta>", (object)str6);
                                short? EMPR_Codigo3 = new short?(Convert.ToInt16(row["EMPR_Codigo"]));
                                int? CCOT_Numero3 = new int?(Convert.ToInt32(row["CCOT_Numero"]));
                                dataTable2 = new DataTable();
                                DataTable x_DtPorPagar3 = this.PorPagar(EMPR_Codigo3, CCOT_Numero3);
                                this.FillTablePorPagar(ref x_xd, x_DtPorPagar3);
                                break;
                            case "001":
                                x_xd.FindAndReplace((object)"<_lugar_fecha>", (object)("San Isidro, " + today.ToString("D")));
                                x_xd.FindAndReplace((object)"<_nro_ove>", (object)Convert.ToString(row["CCOT_NumDoc"]));
                                x_xd.FindAndReplace((object)"<_nombre_cliente>", (object)Convert.ToString(row["ENTC_NomCliente"]));
                                x_xd.FindAndReplace((object)"<_nombre_contacto>", (object)empty1);
                                x_xd.FindAndReplace((object)"<_email_contacto>", (object)empty2);
                                x_xd.FindAndReplace((object)"<_nro_hbl>", (object)Convert.ToString(row["DOOV_HBL"]));
                                x_xd.FindAndReplace((object)"<_nave_viaje>", (object)(str4 + "-" + str5));
                                x_xd.FindAndReplace((object)"<_nombre_proveedor>", (object)Convert.ToString(row["ENTC_NomShipper"]));
                                x_xd.FindAndReplace((object)"<_puerto_origen>", (object)Convert.ToString(row["PUER_NomOrigen"]));
                                if (row["DDOV_FecEmbarque"] != DBNull.Value)
                                {
                                    DateTime dateTime = Convert.ToDateTime(row["DDOV_FecEmbarque"]);
                                    x_xd.FindAndReplace((object)"<_fecha_zarpe>", (object)dateTime.ToString("dd/MM/yyyy"));
                                }
                                else
                                    x_xd.FindAndReplace((object)"<_fecha_zarpe>", (object)"");
                                x_xd.FindAndReplace((object)"<_fecha_eta>", (object)str6);
                                x_xd.FindAndReplace((object)"<_nombre_deposito>", (object)Convert.ToString(row["ENTC_NomDeposito"]));
                                x_xd.FindAndReplace((object)"<_visto_bueno>", (object)str2);
                                string[] strArray2 = row["NUM_Cntr"].ToString().Split('/');
                                int num2 = 0;
                                foreach (string str11 in strArray2)
                                {
                                    if (++num2 == 1)
                                        x_xd.FindAndReplace((object)"<_nros_contenedores>", (object)(str11 + "/ <_nros_contenedores>"));
                                    else
                                        x_xd.FindAndReplace((object)"<_nros_contenedores>", (object)(str11 + "/ <_nros_contenedores>"));
                                }
                                x_xd.FindAndReplace((object)"<_nros_contenedores>", (object)"");
                                x_xd.FindAndReplace((object)"<_referencia>", (object)Convert.ToString(row["DOOV_CodReferencia"]));
                                x_xd.FindAndReplace((object)"<_puerto_destino>", (object)Convert.ToString(row["PUER_NomDestino"]));
                                x_xd.FindAndReplace((object)"<_cant_bultos>", (object)Convert.ToString(row["CANT_Bultos"]));
                                x_xd.FindAndReplace((object)"<_detalle_contenedor>", (object)Convert.ToString(row["TIPO_Embalaje"]));
                                x_xd.FindAndReplace((object)"<_cant_peso>", (object)Convert.ToString(row["CANT_PesoBruto"]));
                                x_xd.FindAndReplace((object)"<_cant_volumen>", (object)Convert.ToString(row["CANT_Volumen"]));
                                x_xd.FindAndReplace((object)"<_nombre_transportista>", (object)str3);
                                x_xd.FindAndReplace((object)"<_emitir_hbl>", (object)Convert.ToString(row["EmitirHBL"]));
                                x_xd.FindAndReplace((object)"<_fecha_cierredireccionamiento>", (object)str9);
                                short? EMPR_Codigo4 = new short?(Convert.ToInt16(row["EMPR_Codigo"]));
                                int? CCOT_Numero4 = new int?(Convert.ToInt32(row["CCOT_Numero"]));
                                dataTable2 = new DataTable();
                                DataTable x_DtPorPagar4 = this.PorPagar(EMPR_Codigo4, CCOT_Numero4);
                                this.FillTablePorPagar(ref x_xd, x_DtPorPagar4);
                                break;
                        }
                    }
                    x_xd.SaveDocument(Editable);
                    x_xd.CloseDocument();
                    Process.Start("EXPLORER.EXE", str10);
                }
                return str1;
            }
            catch (Exception ex)
            {
                return "#-ERROR INTERNO AL EMITIR LOS AVISOS-#" + Environment.NewLine + ex.Message;
            }
        }

        public void CorreoFinanzasStatment(string Correo_Finanzas, string Correo_Operaciones, string Correo_Fletamento, string Correo_Customer_Impo_Expo, string Codigo_Interno, string Nombre_Nave, string Numero_Viaje, string CONS_CodRGM, DateTime? Fecha_ETA_ETD, string Nombre_Transportista)
        {
            bool _enviar = true;
            string empty1 = string.Empty;
            List<string> _olCCrecipients = new List<string>();
            if (!string.IsNullOrEmpty(Correo_Finanzas))
            {
                bool flag = true;
                string str = string.Empty;
                string _subject = string.Empty;
                string empty2 = string.Empty;
                if (Fecha_ETA_ETD.HasValue)
                    empty2 = Convert.ToDateTime((object)Fecha_ETA_ETD).ToString("dd/MM/yyyy");
                string _recipient = Correo_Finanzas;
                if (!string.IsNullOrEmpty(Correo_Operaciones))
                {
                    _olCCrecipients.Add(Correo_Operaciones);
                }
                else
                {
                    flag = false;
                    str = str + "* Operaciones" + Environment.NewLine;
                }
                if (!string.IsNullOrEmpty(Correo_Fletamento))
                {
                    _olCCrecipients.Add(Correo_Fletamento);
                }
                else
                {
                    flag = false;
                    str = str + "* Fletamento" + Environment.NewLine;
                }
                if (!string.IsNullOrEmpty(Correo_Customer_Impo_Expo))
                {
                    _olCCrecipients.Add(Correo_Customer_Impo_Expo);
                }
                else
                {
                    flag = false;
                    str = str + "* Jefe de Customer" + Environment.NewLine;
                }
                switch (CONS_CodRGM)
                {
                    case "002":
                        _subject = string.Format("NAVE CERRADA - {0} STAT - {1} -V:{2} - ETD {3} - TRANSPORTISTA {4}", (object)Codigo_Interno, (object)Nombre_Nave, (object)Numero_Viaje, (object)empty2, (object)Nombre_Transportista);
                        break;
                    case "001":
                        _subject = string.Format("NAVE CERRADA - {0} STAT - {1} -V:{2} - ETA {3} - TRANSPORTISTA {4}", (object)Codigo_Interno, (object)Nombre_Nave, (object)Numero_Viaje, (object)empty2, (object)Nombre_Transportista);
                        break;
                }
                StringBuilder stringBuilder = new StringBuilder();
                stringBuilder.Append("<html>");
                stringBuilder.Append("<font color= #2f5496 >");
                stringBuilder.Append("<body>");
                stringBuilder.Append("<h4>Sres. Finanzas: </h4>");
                stringBuilder.Append("<p><b>Favor proceder con el pago, las prefacturas ya fueron autorizadas.</b></p>");
                stringBuilder.Append("<p>Se ha procedido a cerrar la nave. </p>");
                stringBuilder.Append("<br><p><b>Saludos.</b></p>");
                stringBuilder.Append("</body>");
                stringBuilder.Append("</font>");
                stringBuilder.Append("</html>");
                string _body = stringBuilder.ToString();
                new EnviarCorreo().enviaCorreo(_enviar, _recipient, _olCCrecipients, _subject, _body);
                if (flag)
                    return;
                int num = (int)Dialogos.MostrarMensajeInformacion("Entidades sin Email", "A las siguientes Entidad no fueron incluidos para el envio de este correo por no tener un Email (Ver Detalles).", str);
            }
            else
            {
                int num1 = (int)Dialogos.MostrarMensajeInformacion("Correo de Aviso a Finanzas", "No se pudo enviar el correo de aviso a Finanzas porque no cuenta con un correo grupal", (Dialogos.Boton)0);
            }
        }

        public string CorreoEmitirHBL(DataTable Dt_EmitirHBL, string Correo_Operaciones, string Nombre_Nave, string Numero_Viaje)
        {
            string str = (string)null;
            try
            {
                if (Dt_EmitirHBL == null)
                    return "La orden de venta no cuenta con Emision de HBL";
                EnviarCorreo enviarCorreo = new EnviarCorreo();
                string _ruta = Path.Combine(Application.StartupPath, "Plantillas\\\\RECOJO_DE_BL.docx");
                string path = Path.Combine(Application.StartupPath, "Plantillas\\\\CuentasBancarias.html");
                bool _enviar = false;
                foreach (DataRow row1 in (InternalDataCollectionBase)Dt_EmitirHBL.Rows)
                {
                    string _recipient = Convert.ToString(row1["ENTC_EMailCli"]);
                    if (string.IsNullOrEmpty(_recipient))
                        _recipient = "<INGRESE_EMAIL_CLIENTE>";
                    string _olCCrecipient = Correo_Operaciones + ";" + Convert.ToString(row1["ENTC_EMailCus"]) + ";" + Convert.ToString(row1["ENTC_EMailEje"]);
                    string _subject = "EMISION DE HBL:" + Nombre_Nave + " - Viaje:" + Numero_Viaje + " - " + Convert.ToString(row1["DOOV_HBL"]) + "-" + Convert.ToString(row1["DOOV_CodReferencia"]) + "-" + Convert.ToString(row1["ENTC_NomCliente"]);
                    string _body = string.Empty;
                    StringBuilder stringBuilder1 = new StringBuilder();
                    stringBuilder1.Append("<html>");
                    stringBuilder1.Append("<font color= #2f5496 >");
                    stringBuilder1.Append("<body>");
                    stringBuilder1.Append("<h4>Estimados Clientes: </h4>");
                    stringBuilder1.Append("<h4>" + Convert.ToString(row1["ENTC_NomCliente"]) + "</h4>");
                    stringBuilder1.Append("<p> Para informarle que hemos recibido instrucción de nuestros agentes para emitir el HBl en destino, por lo que pueden pasar a recogerlo en nuestras oficinas en Callao con su carta de recojo adjunta indicando los datos de la persona que recogerá el documento, asimismo pueden comunicarse con el área de visto bueno al teléfono 6153535  anex 301 para que puedan ayudarlo con el procedimiento de visto bueno. </p>");
                    stringBuilder1.Append("</body>");
                    stringBuilder1.Append("</font>");
                    stringBuilder1.Append("</html>");
                    short? EMPR_Codigo = new short?(Convert.ToInt16(row1["EMPR_Codigo"]));
                    int? CCOT_Numero = new int?(Convert.ToInt32(row1["CCOT_Numero"]));
                    DataTable dataTable1 = new DataTable();
                    DataTable dataTable2 = this.PorPagar(EMPR_Codigo, CCOT_Numero);
                    if (dataTable2 != null && dataTable2.Rows.Count > 0)
                    {
                        StringBuilder stringBuilder2 = new StringBuilder();
                        stringBuilder2.Append("<table bgcolor=#f2f2f2 border=1 cellpadding=4 cellspacing=0 style=font-size:13px;font-face:Verdana >");
                        stringBuilder2.Append("<tr><th> CONCEPTOS </th><th> NUEVO SOLES PEN </th><th> DOLARES AMERICANOS USD </th><th>  </th></tr>");
                        int num1 = 1;
                        Decimal num2 = new Decimal(0);
                        Decimal num3 = new Decimal(0);
                        foreach (DataRow row2 in (InternalDataCollectionBase)dataTable2.Rows)
                        {
                            stringBuilder2.Append("<tr>");
                            stringBuilder2.Append("<td>" + Convert.ToString(row2["SERV_Nombre_SPA"]) + "</td>");
                            stringBuilder2.Append("<td align=right>" + Convert.ToDecimal(row2["Monto_Soles"]).ToString("#,###,##0.00") + "</td>");
                            stringBuilder2.Append("<td align=right>" + Convert.ToDecimal(row2["Monto_Dolares"]).ToString("#,###,##0.00") + "</td>");
                            stringBuilder2.Append("<td>" + Convert.ToString(row2["Incluye_IGV"]) + "</td>");
                            stringBuilder2.Append("</tr>");
                            num2 += Convert.ToDecimal(row2["Monto_Soles"]);
                            num3 += Convert.ToDecimal(row2["Monto_Dolares"]);
                            if (dataTable2.Rows.Count == num1)
                            {
                                stringBuilder2.Append("<tr>");
                                stringBuilder2.Append("<th>TOTALES</th>");
                                stringBuilder2.Append("<th align=right>" + num2.ToString("#,###,##0.00") + "</th>");
                                stringBuilder2.Append("<th align=right>" + num3.ToString("#,###,##0.00") + "</th>");
                                stringBuilder2.Append("<th></th>");
                                stringBuilder2.Append("</tr>");
                                stringBuilder2.Append("</table><br>");
                                StringBuilder stringBuilder3 = new StringBuilder();
                                stringBuilder3.Append("<html>");
                                stringBuilder3.Append("<font color= #2f5496 >");
                                stringBuilder3.Append("<body>");
                                stringBuilder3.Append("<h4> CUENTAS BANCARIAS </h4>");
                                stringBuilder3.Append("</body>");
                                stringBuilder3.Append("</font>");
                                stringBuilder3.Append("</html>");
                                StreamReader streamReader = new StreamReader(path);
                                stringBuilder3.Append(streamReader.ReadToEnd());
                                streamReader.Close();
                                _body = stringBuilder1.ToString() + stringBuilder2.ToString() + stringBuilder3.ToString();
                            }
                            ++num1;
                        }
                    }
                    else
                        _body = stringBuilder1.ToString();
                    enviarCorreo.enviaCorreo(_enviar, _recipient, _olCCrecipient, _subject, _body, _ruta, "");
                }
                return str;
            }
            catch (Exception ex)
            {
                return "#-ERROR INTERNO AL EMITIR HBL-#" + Environment.NewLine + ex.Message;
            }
        }

        private DataTable PP(int? NVIA_Codigo, int? CCOT_Numero, string CNTR_Numero)
        {
            this.ContainerService = UnityContainerSingleton.Instance;
            this.Client = (IDelfinServices)UnityContainerExtensions.Resolve<IDelfinServices>(this.ContainerService, new ResolverOverride[0]);
            DataTable dataTable = new DataTable();
            ObservableCollection<DataAccessFilterSQL> observableCollection1 = new ObservableCollection<DataAccessFilterSQL>();
            ObservableCollection<DataAccessFilterSQL> observableCollection2 = observableCollection1;
            DataAccessFilterSQL dataAccessFilterSql1 = new DataAccessFilterSQL();
            dataAccessFilterSql1.FilterName = "@pintNVIA_Codigo";
            dataAccessFilterSql1.FilterValue = NVIA_Codigo;
            dataAccessFilterSql1.FilterType = DataAccessFilterTypes.Int32;
            dataAccessFilterSql1.FilterSize = 4;
            DataAccessFilterSQL dataAccessFilterSql2 = dataAccessFilterSql1;
            observableCollection2.Add(dataAccessFilterSql2);
            ObservableCollection<DataAccessFilterSQL> observableCollection3 = observableCollection1;
            DataAccessFilterSQL dataAccessFilterSql3 = new DataAccessFilterSQL();
            dataAccessFilterSql3.FilterName = "@pintCCOT_Numero";
            dataAccessFilterSql3.FilterValue = CCOT_Numero;
            dataAccessFilterSql3.FilterType = DataAccessFilterTypes.Int32;
            dataAccessFilterSql3.FilterSize = 4;
            DataAccessFilterSQL dataAccessFilterSql4 = dataAccessFilterSql3;
            observableCollection3.Add(dataAccessFilterSql4);
            ObservableCollection<DataAccessFilterSQL> observableCollection4 = observableCollection1;
            DataAccessFilterSQL dataAccessFilterSql5 = new DataAccessFilterSQL();
            dataAccessFilterSql5.FilterName = "@pvchCNTR_Numero";
            dataAccessFilterSql5.FilterValue =CNTR_Numero;
            dataAccessFilterSql5.FilterType = DataAccessFilterTypes.Varchar;
            dataAccessFilterSql5.FilterSize = 20;
            DataAccessFilterSQL dataAccessFilterSql6 = dataAccessFilterSql5;
            observableCollection4.Add(dataAccessFilterSql6);
            return this.Client.GetDTAnexos("COM_NVIASS_PP", observableCollection1);
        }

        private DataTable Relacionados(int? ENTC_CodPadre, string CONS_TabRGM, string CONS_CodRGM, string RELA_Tipo)
        {
            try
            {
                this.ContainerService = UnityContainerSingleton.Instance;
                this.Client = (IDelfinServices)UnityContainerExtensions.Resolve<IDelfinServices>(this.ContainerService, new ResolverOverride[0]);
                DataTable dataTable = new DataTable();
                ObservableCollection<DataAccessFilterSQL> observableCollection1 = new ObservableCollection<DataAccessFilterSQL>();
                ObservableCollection<DataAccessFilterSQL> observableCollection2 = observableCollection1;
                DataAccessFilterSQL dataAccessFilterSql1 = new DataAccessFilterSQL();
                dataAccessFilterSql1.FilterName = "@pintENTC_CodPadre";
                dataAccessFilterSql1.FilterValue=ENTC_CodPadre;
                dataAccessFilterSql1.FilterType=DataAccessFilterTypes.Int32;
                dataAccessFilterSql1.FilterSize=4;
                DataAccessFilterSQL dataAccessFilterSql2 = dataAccessFilterSql1;
                observableCollection2.Add(dataAccessFilterSql2);
                ObservableCollection<DataAccessFilterSQL> observableCollection3 = observableCollection1;
                DataAccessFilterSQL dataAccessFilterSql3 = new DataAccessFilterSQL();
                dataAccessFilterSql3.FilterName="@pchrCONS_TabRGM";
                dataAccessFilterSql3.FilterValue=CONS_TabRGM;
                dataAccessFilterSql3.FilterType=DataAccessFilterTypes.Varchar;
                dataAccessFilterSql3.FilterSize=3;
                DataAccessFilterSQL dataAccessFilterSql4 = dataAccessFilterSql3;
                observableCollection3.Add(dataAccessFilterSql4);
                ObservableCollection<DataAccessFilterSQL> observableCollection4 = observableCollection1;
                DataAccessFilterSQL dataAccessFilterSql5 = new DataAccessFilterSQL();
                dataAccessFilterSql5.FilterName="@pchrCONS_CodRGM";
                dataAccessFilterSql5.FilterValue=CONS_CodRGM;
                dataAccessFilterSql5.FilterType=DataAccessFilterTypes.Varchar;
                dataAccessFilterSql5.FilterSize=3;
                DataAccessFilterSQL dataAccessFilterSql6 = dataAccessFilterSql5;
                observableCollection4.Add(dataAccessFilterSql6);
                ObservableCollection<DataAccessFilterSQL> observableCollection5 = observableCollection1;
                DataAccessFilterSQL dataAccessFilterSql7 = new DataAccessFilterSQL();
                dataAccessFilterSql7.FilterName="@pchrRELA_Tipos";
                dataAccessFilterSql7.FilterValue=RELA_Tipo;
                dataAccessFilterSql7.FilterType=DataAccessFilterTypes.Varchar;
                dataAccessFilterSql7.FilterSize=3;
                DataAccessFilterSQL dataAccessFilterSql8 = dataAccessFilterSql7;
                observableCollection5.Add(dataAccessFilterSql8);
                return this.Client.GetDTAnexos("RELASU_DatosEntidad", observableCollection1);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private DataTable PorPagar(short? EMPR_Codigo, int? CCOT_Numero)
        {
            try
            {
                this.ContainerService = UnityContainerSingleton.Instance;
                this.Client = (IDelfinServices)UnityContainerExtensions.Resolve<IDelfinServices>(this.ContainerService, new ResolverOverride[0]);
                DataTable dataTable = new DataTable();
                ObservableCollection<DataAccessFilterSQL> observableCollection1 = new ObservableCollection<DataAccessFilterSQL>();
                ObservableCollection<DataAccessFilterSQL> observableCollection2 = observableCollection1;
                DataAccessFilterSQL dataAccessFilterSql1 = new DataAccessFilterSQL();
                dataAccessFilterSql1.FilterName = "@psinEMPR_Codigo";
                dataAccessFilterSql1.FilterValue = EMPR_Codigo;
                dataAccessFilterSql1.FilterType = DataAccessFilterTypes.Int32;
                dataAccessFilterSql1.FilterSize = 4;
                DataAccessFilterSQL dataAccessFilterSql2 = dataAccessFilterSql1;
                observableCollection2.Add(dataAccessFilterSql2);
                ObservableCollection<DataAccessFilterSQL> observableCollection3 = observableCollection1;
                DataAccessFilterSQL dataAccessFilterSql3 = new DataAccessFilterSQL();
                dataAccessFilterSql3.FilterName = "@pintCCOT_Numero";
                dataAccessFilterSql3.FilterValue = CCOT_Numero;
                dataAccessFilterSql3.FilterType = DataAccessFilterTypes.Int32;
                dataAccessFilterSql3.FilterSize = 4;
                DataAccessFilterSQL dataAccessFilterSql4 = dataAccessFilterSql3;
                observableCollection3.Add(dataAccessFilterSql4);
                return this.Client.GetDTAnexos("OPE_CCOTSS_PorPagar", observableCollection1);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private string MonthName(int month)
        {
            try
            {
                return new CultureInfo("es-ES", false).DateTimeFormat.GetMonthName(month);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private void FillTablePorPagar(ref WordDocument x_xd, DataTable x_DtPorPagar)
        {
            try
            {
                int rows = 0;
                int num1 = 1;
                Decimal num2 = new Decimal(0);
                Decimal num3 = new Decimal(0);
                List<string> stringList = new List<string>();
                if (x_DtPorPagar == null || x_DtPorPagar.Rows.Count <= 0)
                    return;
                foreach (DataRow row in (InternalDataCollectionBase)x_DtPorPagar.Rows)
                {
                    if (rows == 0)
                    {
                        x_xd.FillTableNew(new List<string>()
            {
              "CONCEPTOS",
              "NUEVO SOLES PEN",
              "DOLARES AMERICANOS USD",
              ""
            }, 2, rows, false);
                        ++rows;
                    }
                    x_xd.FillTableNew(new List<string>()
          {
            Convert.ToString(row["SERV_Nombre_SPA"]),
            Convert.ToDecimal(row["Monto_Soles"]).ToString("#,###,##0.00"),
            Convert.ToDecimal(row["Monto_Dolares"]).ToString("#,###,##0.00"),
            Convert.ToString(row["Incluye_IGV"])
          }, 2, rows, false);
                    ++rows;
                    num2 += Convert.ToDecimal(row["Monto_Soles"]);
                    num3 += Convert.ToDecimal(row["Monto_Dolares"]);
                    if (x_DtPorPagar.Rows.Count == num1)
                    {
                        x_xd.FillTableNew(new List<string>()
            {
              "TOTALES",
              num2.ToString("#,###,##0.00"),
              num3.ToString("#,###,##0.00"),
              ""
            }, 2, rows, true);
                        ++rows;
                    }
                    ++num1;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public sealed class _TIPO_Embarque
        {
            public const string FCL = "FCL";
            public const string LCL = "LCL";

            private _TIPO_Embarque()
            {
            }
        }
    }
}
