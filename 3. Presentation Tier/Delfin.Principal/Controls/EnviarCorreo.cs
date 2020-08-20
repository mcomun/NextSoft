// Decompiled with JetBrains decompiler
// Type: Delfin.Controls.EnviarCorreo
// Assembly: Delfin.Controls, Version=3.0.1.3, Culture=neutral, PublicKeyToken=null
// MVID: A4BA2B33-0E71-44B0-9838-A6C1CD0C2B15
// Assembly location: C:\Temp\Delfin.Controls.dll

using Delfin.Entities;
using Infrastructure.WinForms.Controls;
using Microsoft.CSharp.RuntimeBinder;
using Microsoft.Office.Interop.Outlook;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Delfin.Principal
{
  public class EnviarCorreo
  {
    public void enviaCorreo(ObservableCollection<Entidad> _olBCCRecipients, string _recipient, string _subject, string _body)
    {
      try
      {
        char[] chArray = new char[1]{ ';' };
        // ISSUE: variable of a compiler-generated type
        Microsoft.Office.Interop.Outlook.Application instance = (Microsoft.Office.Interop.Outlook.Application) Activator.CreateInstance(Type.GetTypeFromCLSID(new Guid("0006F03A-0000-0000-C000-000000000046")));
        // ISSUE: reference to a compiler-generated field
          enviaCorreo.c
        if (EnviarCorreo. \u003CenviaCorreo\u003Eo__SiteContainer0.\u003C\u003Ep__Site1 == null)
        {
          // ISSUE: reference to a compiler-generated field
          EnviarCorreo.\u003CenviaCorreo\u003Eo__SiteContainer0.\u003C\u003Ep__Site1 = CallSite<Func<CallSite, object, _MailItem>>.Create(Microsoft.CSharp.RuntimeBinder.Binder.Convert(CSharpBinderFlags.ConvertExplicit, typeof (_MailItem), typeof (EnviarCorreo)));
        }
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated method
        // ISSUE: variable of a compiler-generated type
        _MailItem mailItem = EnviarCorreo.\u003CenviaCorreo\u003Eo__SiteContainer0.\u003C\u003Ep__Site1.Target((CallSite) EnviarCorreo.\u003CenviaCorreo\u003Eo__SiteContainer0.\u003C\u003Ep__Site1, instance.CreateItem(OlItemType.olMailItem));
        // ISSUE: variable of a compiler-generated type
        Inspector getInspector = mailItem.GetInspector;
        bool flag = true;
        string str1 = "";
        // ISSUE: variable of a compiler-generated type
        Recipients recipients = mailItem.Recipients;
        using (IEnumerator<Entidad> enumerator = _olBCCRecipients.GetEnumerator())
        {
          while (((IEnumerator) enumerator).MoveNext())
          {
            Entidad current = enumerator.Current;
            if (string.IsNullOrEmpty(current.get_ENTC_EMail()))
            {
              flag = false;
              str1 = str1 + "* " + current.get_ENTC_NomCompleto() + Environment.NewLine;
            }
            else
            {
              string[] strArray = current.get_ENTC_EMail().Split(chArray);
              if (strArray != null && strArray.Length != 0)
              {
                foreach (string str2 in strArray)
                {
                  if (!string.IsNullOrEmpty(str2.Trim()))
                  {
                    // ISSUE: reference to a compiler-generated method
                    // ISSUE: variable of a compiler-generated type
                    Recipient recipient = recipients.Add(str2.Trim());
                    recipient.Type = 3;
                    // ISSUE: reference to a compiler-generated method
                    recipient.Resolve();
                  }
                }
              }
            }
          }
        }
        if (!flag)
        {
          int num = (int) Dialogos.MostrarMensajeInformacion("Entidades sin Email", "A las siguientes Entidad no fueron incluidos para el envio de este correo por no tener un Email (Ver Detalles).", str1);
        }
        // ISSUE: reference to a compiler-generated method
        // ISSUE: variable of a compiler-generated type
        Recipient recipient1 = recipients.Add(_recipient.Trim());
        // ISSUE: reference to a compiler-generated method
        recipient1.Resolve();
        mailItem.Subject = _subject;
        mailItem.HTMLBody = _body + mailItem.HTMLBody;
        // ISSUE: reference to a compiler-generated method
        mailItem.Display((object) true);
      }
      catch (Exception ex)
      {
        int num = (int) MessageBox.Show("Error durante el proceso del Envío del Correo: " + ex.Message, "Error Interno", MessageBoxButtons.OK, MessageBoxIcon.Hand);
      }
    }

    public void enviaCorreo(bool _enviar, string _recipient, string _olCCrecipient, string _subject, string _body)
    {
      try
      {
        char[] chArray = new char[1]{ ';' };
        string[] strArray = (string[]) null;
        // ISSUE: variable of a compiler-generated type
        Microsoft.Office.Interop.Outlook.Application instance = (Microsoft.Office.Interop.Outlook.Application) Activator.CreateInstance(Type.GetTypeFromCLSID(new Guid("0006F03A-0000-0000-C000-000000000046")));
        // ISSUE: reference to a compiler-generated field
        if (EnviarCorreo.\u003CenviaCorreo\u003Eo__SiteContainer2.\u003C\u003Ep__Site3 == null)
        {
          // ISSUE: reference to a compiler-generated field
          EnviarCorreo.\u003CenviaCorreo\u003Eo__SiteContainer2.\u003C\u003Ep__Site3 = CallSite<Func<CallSite, object, _MailItem>>.Create(Microsoft.CSharp.RuntimeBinder.Binder.Convert(CSharpBinderFlags.ConvertExplicit, typeof (_MailItem), typeof (EnviarCorreo)));
        }
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated method
        // ISSUE: variable of a compiler-generated type
        _MailItem mailItem = EnviarCorreo.\u003CenviaCorreo\u003Eo__SiteContainer2.\u003C\u003Ep__Site3.Target((CallSite) EnviarCorreo.\u003CenviaCorreo\u003Eo__SiteContainer2.\u003C\u003Ep__Site3, instance.CreateItem(OlItemType.olMailItem));
        // ISSUE: variable of a compiler-generated type
        Inspector getInspector = mailItem.GetInspector;
        // ISSUE: variable of a compiler-generated type
        Recipients recipients = mailItem.Recipients;
        if (!string.IsNullOrEmpty(_olCCrecipient))
          strArray = _olCCrecipient.Split(chArray);
        if (strArray != null && strArray.Length != 0)
        {
          foreach (string str in strArray)
          {
            if (!string.IsNullOrEmpty(str.Trim()))
            {
              // ISSUE: reference to a compiler-generated method
              // ISSUE: variable of a compiler-generated type
              Recipient recipient = recipients.Add(str.Trim());
              recipient.Type = 2;
              // ISSUE: reference to a compiler-generated method
              recipient.Resolve();
            }
          }
        }
        if (!string.IsNullOrEmpty(_recipient))
          strArray = _recipient.Split(chArray);
        if (strArray != null && strArray.Length != 0)
        {
          foreach (string str in strArray)
          {
            if (!string.IsNullOrEmpty(str.Trim()))
            {
              // ISSUE: reference to a compiler-generated method
              // ISSUE: variable of a compiler-generated type
              Recipient recipient = recipients.Add(str.Trim());
              recipient.Type = 1;
              // ISSUE: reference to a compiler-generated method
              recipient.Resolve();
            }
          }
        }
        mailItem.Subject = _subject;
        mailItem.HTMLBody = _body + mailItem.HTMLBody;
        if (_enviar)
        {
          // ISSUE: reference to a compiler-generated method
          mailItem.Send();
        }
        else
        {
          // ISSUE: reference to a compiler-generated method
          mailItem.Display((object) true);
        }
      }
      catch (Exception ex)
      {
        int num = (int) MessageBox.Show("Error durante el proceso del Envío del Correo: " + ex.Message, "Error Interno", MessageBoxButtons.OK, MessageBoxIcon.Hand);
      }
    }

    public void enviaCorreo(bool _enviar, string _recipient, string _olCCrecipient, string _subject, string _body, string _ruta, string _ruta2)
    {
      try
      {
        char[] chArray = new char[1]{ ';' };
        string[] strArray = (string[]) null;
        // ISSUE: variable of a compiler-generated type
        Microsoft.Office.Interop.Outlook.Application instance = (Microsoft.Office.Interop.Outlook.Application) Activator.CreateInstance(Type.GetTypeFromCLSID(new Guid("0006F03A-0000-0000-C000-000000000046")));
        // ISSUE: reference to a compiler-generated field
        if (EnviarCorreo.\u003CenviaCorreo\u003Eo__SiteContainer4.\u003C\u003Ep__Site5 == null)
        {
          // ISSUE: reference to a compiler-generated field
          EnviarCorreo.\u003CenviaCorreo\u003Eo__SiteContainer4.\u003C\u003Ep__Site5 = CallSite<Func<CallSite, object, _MailItem>>.Create(Microsoft.CSharp.RuntimeBinder.Binder.Convert(CSharpBinderFlags.ConvertExplicit, typeof (_MailItem), typeof (EnviarCorreo)));
        }
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated method
        // ISSUE: variable of a compiler-generated type
        _MailItem mailItem = EnviarCorreo.\u003CenviaCorreo\u003Eo__SiteContainer4.\u003C\u003Ep__Site5.Target((CallSite) EnviarCorreo.\u003CenviaCorreo\u003Eo__SiteContainer4.\u003C\u003Ep__Site5, instance.CreateItem(OlItemType.olMailItem));
        // ISSUE: variable of a compiler-generated type
        Inspector getInspector = mailItem.GetInspector;
        // ISSUE: variable of a compiler-generated type
        Recipients recipients = mailItem.Recipients;
        if (!string.IsNullOrEmpty(_olCCrecipient))
          strArray = _olCCrecipient.Split(chArray);
        if (strArray != null && strArray.Length != 0)
        {
          foreach (string str in strArray)
          {
            if (!string.IsNullOrEmpty(str.Trim()))
            {
              // ISSUE: reference to a compiler-generated method
              // ISSUE: variable of a compiler-generated type
              Recipient recipient = recipients.Add(str.Trim());
              recipient.Type = 2;
              // ISSUE: reference to a compiler-generated method
              recipient.Resolve();
            }
          }
        }
        if (!string.IsNullOrEmpty(_recipient))
          strArray = _recipient.Split(chArray);
        if (strArray != null && strArray.Length != 0)
        {
          foreach (string str in strArray)
          {
            if (!string.IsNullOrEmpty(str.Trim()))
            {
              // ISSUE: reference to a compiler-generated method
              // ISSUE: variable of a compiler-generated type
              Recipient recipient = recipients.Add(str.Trim());
              recipient.Type = 1;
              // ISSUE: reference to a compiler-generated method
              recipient.Resolve();
            }
          }
        }
        mailItem.Subject = _subject;
        mailItem.HTMLBody = _body + mailItem.HTMLBody;
        // ISSUE: reference to a compiler-generated method
        mailItem.Attachments.Add((object) _ruta, (object) OlAttachmentType.olEmbeddeditem, (object) Missing.Value, (object) Missing.Value);
        if (!string.IsNullOrEmpty(_ruta2))
        {
          // ISSUE: reference to a compiler-generated method
          mailItem.Attachments.Add((object) _ruta2, (object) OlAttachmentType.olEmbeddeditem, (object) Missing.Value, (object) Missing.Value);
        }
        if (_enviar)
        {
          // ISSUE: reference to a compiler-generated method
          mailItem.Send();
        }
        else
        {
          // ISSUE: reference to a compiler-generated method
          mailItem.Display((object) true);
        }
      }
      catch (Exception ex)
      {
        int num = (int) MessageBox.Show("Error durante el proceso del Envío del Correo: " + ex.Message, "Error Interno", MessageBoxButtons.OK, MessageBoxIcon.Hand);
      }
    }

    public void enviaCorreo(bool _enviar, string _recipient, List<string> _olCCrecipients, string _subject, string _body)
    {
      try
      {
        char[] chArray = new char[1]{ ';' };
        string[] strArray = (string[]) null;
        // ISSUE: variable of a compiler-generated type
        Microsoft.Office.Interop.Outlook.Application instance = (Microsoft.Office.Interop.Outlook.Application) Activator.CreateInstance(Type.GetTypeFromCLSID(new Guid("0006F03A-0000-0000-C000-000000000046")));
        // ISSUE: reference to a compiler-generated field
        if (EnviarCorreo.\u003CenviaCorreo\u003Eo__SiteContainer6.\u003C\u003Ep__Site7 == null)
        {
          // ISSUE: reference to a compiler-generated field
          EnviarCorreo.\u003CenviaCorreo\u003Eo__SiteContainer6.\u003C\u003Ep__Site7 = CallSite<Func<CallSite, object, _MailItem>>.Create(Microsoft.CSharp.RuntimeBinder.Binder.Convert(CSharpBinderFlags.ConvertExplicit, typeof (_MailItem), typeof (EnviarCorreo)));
        }
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated method
        // ISSUE: variable of a compiler-generated type
        _MailItem mailItem = EnviarCorreo.\u003CenviaCorreo\u003Eo__SiteContainer6.\u003C\u003Ep__Site7.Target((CallSite) EnviarCorreo.\u003CenviaCorreo\u003Eo__SiteContainer6.\u003C\u003Ep__Site7, instance.CreateItem(OlItemType.olMailItem));
        // ISSUE: variable of a compiler-generated type
        Inspector getInspector = mailItem.GetInspector;
        // ISSUE: variable of a compiler-generated type
        Recipients recipients = mailItem.Recipients;
        foreach (string olCcrecipient in _olCCrecipients)
        {
          if (!string.IsNullOrEmpty(olCcrecipient))
          {
            // ISSUE: reference to a compiler-generated method
            // ISSUE: variable of a compiler-generated type
            Recipient recipient = recipients.Add(olCcrecipient);
            recipient.Type = 2;
            // ISSUE: reference to a compiler-generated method
            recipient.Resolve();
          }
        }
        if (!string.IsNullOrEmpty(_recipient))
          strArray = _recipient.Split(chArray);
        if (strArray != null && strArray.Length != 0)
        {
          foreach (string Name in strArray)
          {
            // ISSUE: reference to a compiler-generated method
            // ISSUE: variable of a compiler-generated type
            Recipient recipient = recipients.Add(Name);
            recipient.Type = 1;
            // ISSUE: reference to a compiler-generated method
            recipient.Resolve();
          }
        }
        mailItem.Subject = _subject;
        mailItem.HTMLBody = _body + mailItem.HTMLBody;
        if (_enviar)
        {
          // ISSUE: reference to a compiler-generated method
          mailItem.Send();
        }
        else
        {
          // ISSUE: reference to a compiler-generated method
          mailItem.Display((object) true);
        }
      }
      catch (Exception ex)
      {
        int num = (int) MessageBox.Show("Error durante el proceso del Envío del Correo: " + ex.Message, "Error Interno", MessageBoxButtons.OK, MessageBoxIcon.Hand);
      }
      Thread.Sleep(10000);
    }

    private string ReadSignature()
    {
      string path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\Microsoft\\Firmas";
      string str1 = string.Empty;
      DirectoryInfo directoryInfo = new DirectoryInfo(path);
      if (directoryInfo.Exists)
      {
        FileInfo[] files = directoryInfo.GetFiles("*.htm");
        if (files.Length > 0)
        {
          str1 = new StreamReader(files[0].FullName, Encoding.Default).ReadToEnd();
          if (!string.IsNullOrEmpty(str1))
          {
            string str2 = files[0].Name.Replace(files[0].Extension, string.Empty);
            str1 = str1.Replace(str2 + "_files/", path + "/" + str2 + "_files/");
          }
        }
      }
      return str1;
    }

    private string Signature()
    {
      StringBuilder stringBuilder = new StringBuilder();
      stringBuilder.Append("<table CELLSPACING=10 cellpadding=12>");
      stringBuilder.Append("<tr>  ");
      stringBuilder.Append("<td><img src=http://www.delfingroupco.com/sitio/mysite/images/logoHeader.png><br>");
      stringBuilder.Append("</td>  ");
      stringBuilder.Append("<td>  ");
      stringBuilder.Append("<font size=2 color= #2f5496 >");
      stringBuilder.Append("<b>DELFIN GROUP Co</b><br>");
      stringBuilder.Append("Teléfono: (511) 615 3535<br>");
      stringBuilder.Append("Web: <a href=«http://www.delfingroupco.com»>http://www.delfingroupco.com</a><br>");
      stringBuilder.Append("</font>");
      stringBuilder.Append("</td></tr>");
      stringBuilder.Append("</table>");
      return stringBuilder.ToString();
    }
  }
}
