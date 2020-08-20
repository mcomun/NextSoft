using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Xml;
using Delfin.Entities;
using Infrastructure.Aspect.Collections;
using Microsoft.Practices.Unity;

namespace Delfin.Principal
{
   public partial class COM007Presenter
   {
      #region [ Aprobacion Cotizacion ]
      private Boolean EnviarEmailCotizacion(Cab_Cotizacion_OV Item, Boolean isAdded)
      {
         try
         {
            //Item = Client.GetOneCab_Cotizacion_OV(Item.EMPR_Codigo.Value, Item.SUCR_Codigo.Value, Item.CCOT_Numero, Item.CCOT_Tipo);

            var BL_Usuario = ContainerService.Resolve<NextAdmin.BusinessLogic.IBLUsuarios>();

            NextAdmin.BusinessLogic.Usuarios _usuarioCotizacion = null;
            NextAdmin.BusinessLogic.Usuarios _usuarioAprobacion = null;

            //Boolean m_isAdded = (Item.Instance == Infrastructure.Aspect.BusinessEntity.InstanceEntity.Added);

            if (isAdded)
            { _usuarioCotizacion = BL_Usuario.GetOneByCodUsr(Item.AUDI_UsrCrea); }
            else
            { _usuarioCotizacion = BL_Usuario.GetOneByCodUsr(Item.AUDI_UsrMod); }

            Int32 _nivel = Client.GetOneCab_Cotizacion_OVNivelAprobacion(Item.EMPR_Codigo.Value, Item.SUCR_Codigo.Value, Item.CCOT_Tipo, Item.CCOT_Numero);

            ObservableCollection<Parametros> _listParametros = Client.GetAllParametros();

            Parametros _parametro = null;
            switch (_nivel)
            {
               case 2:
                  _parametro = _listParametros.Where(para => para.PARA_Clave == "USRAPRUEBANIVEL1_JV").FirstOrDefault();
                  if (_parametro != null && !String.IsNullOrEmpty(_parametro.PARA_Valor))
                  { _usuarioAprobacion = BL_Usuario.GetOneByCodUsr(_parametro.PARA_Valor); }
                  break;
               case 3:
                  _parametro = _listParametros.Where(para => para.PARA_Clave == "USRAPRUEBANIVEL2_GC").FirstOrDefault();
                  if (_parametro != null && !String.IsNullOrEmpty(_parametro.PARA_Valor))
                  { _usuarioAprobacion = BL_Usuario.GetOneByCodUsr(_parametro.PARA_Valor); }
                  break;
               case 4:
                  _parametro = _listParametros.Where(para => para.PARA_Clave == "USRAPRUEBANIVEL3_GG").FirstOrDefault();
                  if (_parametro != null && !String.IsNullOrEmpty(_parametro.PARA_Valor))
                  { _usuarioAprobacion = BL_Usuario.GetOneByCodUsr(_parametro.PARA_Valor); }
                  break;
               default:
                  break;
            }

            if (_usuarioAprobacion != null && _usuarioCotizacion != null)
            {
               MailMessage _message = new MailMessage();
               
               String _mailAsunto = String.Format("Aprobar Cotización Nro. {0} del Cliente {1}", Item.CCOT_NumDocVersion, Item.ENTC_NomCliente);
               String _mailMensaje = String.Format("Aprobar Cotización Nro. {0} del Cliente {1}", Item.CCOT_NumDocVersion, Item.ENTC_NomCliente);

               if (!String.IsNullOrEmpty(_usuarioAprobacion.USUA_Email) || !String.IsNullOrEmpty(_usuarioCotizacion.USUA_Email))
               {
                  if (!String.IsNullOrEmpty(_usuarioAprobacion.USUA_Email)) { _message.To.Add(_usuarioAprobacion.USUA_Email); }
                  if (!String.IsNullOrEmpty(_usuarioCotizacion.USUA_Email)) { _message.To.Add(_usuarioCotizacion.USUA_Email); }

                  _message.Subject = _mailAsunto;
                  _message.Body = _mailMensaje;
                  _message.Priority = MailPriority.Normal;

                  SendMail(_message);
                  return true;
               }
               else
               { return false; }
            }
            else
            { return false; }
         }
         catch (Exception ex)
         {
            Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Title, "Ha ocurrido un error al enviar el correo de la Cotización.", ex);
            return false; 
         }
      }
      #endregion

      #region [ Novedades ]
      public Boolean EnviarNovedades(Int16 EMPR_Codigo, Int16 SUCR_Codigo, Int16 CCOT_Tipo, Int32 CCOT_Numero, String Usuario)
      {
         try
         {
            Cab_Cotizacion_OV Item = Client.GetOneCab_Cotizacion_OV(EMPR_Codigo, SUCR_Codigo, CCOT_Numero, CCOT_Tipo);
            ObservableCollection<Det_Cotizacion_OV_Novedad> _listNovedades = Client.GetAllDet_Cotizacion_OV_NovedadByCab_Cotizacion_OV(CCOT_Numero, CCOT_Tipo).Where(ovno => !ovno.OVNO_Email.HasValue || (ovno.OVNO_Email.HasValue && !ovno.OVNO_Email.Value)).OrderByDescending(ovno => ovno.OVNO_Fecha).ToObservableCollection();

            //SmtpMailCS _mail = new SmtpMailCS();

            String _mailToCliente = "";
            if (!String.IsNullOrEmpty(Item.ENTC_EmailCliente) && Infrastructure.Aspect.ValidationRules.ValidarMail.ValidarE_Mail(Item.ENTC_EmailCliente))
            { _mailToCliente = Item.ENTC_EmailCliente; }

            String _mailToContacto = "";
            if (!String.IsNullOrEmpty(Item.ENTC_EmailContacto) && Infrastructure.Aspect.ValidationRules.ValidarMail.ValidarE_Mail(Item.ENTC_EmailContacto))
            { _mailToContacto = Item.ENTC_EmailContacto; }

            String _mailToNotify = "";
            if (!String.IsNullOrEmpty(Item.ENTC_EmailNotify) && Infrastructure.Aspect.ValidationRules.ValidarMail.ValidarE_Mail(Item.ENTC_EmailNotify))
            { _mailToNotify = Item.ENTC_EmailNotify; }

            String _mailToCustomer = "";
            if (!String.IsNullOrEmpty(Item.ENTC_EmailCustomer) && Infrastructure.Aspect.ValidationRules.ValidarMail.ValidarE_Mail(Item.ENTC_EmailCustomer))
            { _mailToCustomer = Item.ENTC_EmailCustomer; }

            String _mailAsunto = String.Format("Novedades Sobre Carga, Orden Venta Nro. {0}", Item.CCOT_NumDocVersion);

            String _mailMensaje = "";
            Infrastructure.Aspect.DefaultData.DataInfo _mes = Infrastructure.Aspect.DefaultData.DefaultData.GetMeses().Where(mes => mes.Codigo == DateTime.Now.Month.ToString("00")).FirstOrDefault();
            _mailMensaje += String.Format("Lima, {0} de {1} del {2}", DateTime.Now.Day.ToString(), (_mes != null ? _mes.Nombre : ""), DateTime.Now.Year.ToString()) + Environment.NewLine;
            _mailMensaje += Environment.NewLine;
            _mailMensaje += String.Format("No. Interno: {0}", Item.CCOT_NumDoc) + Environment.NewLine;
            _mailMensaje += Environment.NewLine;
            _mailMensaje += "Señores:" + Environment.NewLine;
            _mailMensaje += Environment.NewLine;
            _mailMensaje += Item.ENTC_NomCliente + Environment.NewLine;
            _mailMensaje += Environment.NewLine;
            _mailMensaje += "Estimado cliente:" + Environment.NewLine;
            _mailMensaje += "Confirmamos que hemos contactado a su proveedor y nos ha informado lo siguiente con respecto a su:" + Environment.NewLine;
            _mailMensaje += Environment.NewLine;
            _mailMensaje += "DATOS DE EMBARQUE" + Environment.NewLine;
            _mailMensaje += Environment.NewLine;
            _mailMensaje += "Origen             : " + Item.PUER_NombreOrigen + Environment.NewLine;
            _mailMensaje += "Destino            : " + Item.PUER_NombreOrigen + Environment.NewLine;
            _mailMensaje += "Proveedor          : " + Item.ENTC_NomShipper + Environment.NewLine;
            _mailMensaje += "Modo               : " + Item.CONS_DescRGM + Environment.NewLine;
            _mailMensaje += "Agente             : " + Item.ENTC_NomAgente + Environment.NewLine;
            _mailMensaje += "Bultos             : " + (Item.DCOT_Bultos.HasValue ? Item.DCOT_Bultos.ToString() : "") + Environment.NewLine;
            _mailMensaje += "Contenedor         : " + (Item.DCOT_Cantidad.HasValue ? Item.DCOT_Cantidad.ToString() + "x" : "") + Item.PACK_DescC + Environment.NewLine;
            _mailMensaje += "Referencia Cliente : " + Item.DOOV_CodReferencia + Environment.NewLine;
            _mailMensaje += Environment.NewLine;
            _mailMensaje += "DATOS NOVEDADES" + Environment.NewLine;
            _mailMensaje += Environment.NewLine;
            foreach (Det_Cotizacion_OV_Novedad itemNovedad in _listNovedades)
            {
               _mailMensaje += (itemNovedad.OVNO_Fecha.HasValue ? itemNovedad.OVNO_Fecha.Value.ToString("dd/MM/yyyy") : "") + Environment.NewLine;
               _mailMensaje += itemNovedad.OVNO_Descrip + Environment.NewLine;
            }

            _mailMensaje += Environment.NewLine;
            _mailMensaje += Environment.NewLine;
            _mailMensaje += "En caso de cualquier información adicional, no duden en contactarnos." + Environment.NewLine;
            _mailMensaje += Environment.NewLine;
            _mailMensaje += "Saludos Cordiales," + Environment.NewLine;
            _mailMensaje += Environment.NewLine;
            _mailMensaje += Item.ENTC_NomCustomer + Environment.NewLine;
            _mailMensaje += "E-mail: " + Item.ENTC_EmailCustomer + Environment.NewLine;
            _mailMensaje += "Tel:" + Item.ENTC_Tel1Customer + Environment.NewLine;
            _mailMensaje += "Cel:" + Item.ENTC_Tel2Customer + Environment.NewLine;
            _mailMensaje += "CALLE ANTEQUERA 777 - PISO 12, SAN ISIDRO" + Environment.NewLine;
            _mailMensaje += "CUSTOMER SERVICES IMPORTACIONES" + Environment.NewLine;

            try
            {
               MailMessage _message = new MailMessage();
               
               if (!String.IsNullOrEmpty(_mailToCliente)) { _message.To.Add(_mailToCliente); }
               if (!String.IsNullOrEmpty(_mailToContacto)) { _message.To.Add(_mailToContacto); }
               if (!String.IsNullOrEmpty(_mailToNotify)) { _message.To.Add(_mailToNotify); }
               if (!String.IsNullOrEmpty(_mailToCustomer)) { _message.To.Add(_mailToCustomer); }

               _message.Subject = _mailAsunto;
               _message.Body = _mailMensaje;
               _message.Priority =  MailPriority.Normal;

               SendMail(_message);

               for (int i = 0; i < _listNovedades.Count; i++)
               {
                  Det_Cotizacion_OV_Novedad itemNovedad = _listNovedades[i];

                  itemNovedad.OVNO_Email = true;
                  itemNovedad.AUDI_UsrMod = Usuario;
                  itemNovedad.AUDI_FecMod = DateTime.Now;
                  itemNovedad.Instance = Infrastructure.Aspect.BusinessEntity.InstanceEntity.Modified;

                  Client.SaveDet_Cotizacion_OV_Novedad(itemNovedad);
               }

               return true;
            }
            catch (Exception)
            { return false; }
         }
         catch (Exception)
         { throw; }
      }
      #endregion
      

      #region [ SMTP MAIL]
      private string m_username;
      private string m_password;
      private string m_host;
      private int m_puerto;
      private bool m_enablessl;
      private bool m_isBodyHTML;
      private bool m_isExchange;
      private string m_serverExchange;

      public bool GetConfiguracion()
      {
         try
         {
            XmlDocument _xmlConfiguracion = new XmlDocument();
            _xmlConfiguracion.Load(AppDomain.CurrentDomain.BaseDirectory + "SmtpMail.xml");

            if (_xmlConfiguracion.HasChildNodes)
            {
               foreach (XmlNode _nodo in _xmlConfiguracion.ChildNodes)
               {
                  switch (_nodo.Name.ToLower())
                  {
                     case "configuracion":
                        m_username = _nodo.Attributes["UserName"].Value;
                        m_password = _nodo.Attributes["Password"].Value;
                        m_host = _nodo.Attributes["Host"].Value;
                        m_puerto = Convert.ToInt32(_nodo.Attributes["Port"].Value);
                        m_enablessl = Convert.ToBoolean(_nodo.Attributes["EnableSSL"].Value);
                        m_isBodyHTML = Convert.ToBoolean(_nodo.Attributes["IsBodyHTML"].Value);
                        m_isExchange = Convert.ToBoolean(_nodo.Attributes["IsExchange"].Value); ;
                        m_serverExchange = _nodo.Attributes["ServerExchange"].Value;
                        break;
                     default:
                        break;
                  }
               }
            }

            return true;
         }
         catch (Exception ex)
         { throw ex; }
      }

      private int SendMail(MailMessage _message)
      {
         try
         {
            GetConfiguracion();

            NetworkCredential _credentials = new NetworkCredential(m_username, m_password);

            SmtpClient _smtp = new SmtpClient();
            _smtp.Host = m_host;
            _smtp.Port = m_puerto;
            _smtp.UseDefaultCredentials = false;
            _smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            _smtp.EnableSsl = m_enablessl;
            _smtp.Credentials = _credentials;
            _smtp.Timeout = 300000;

            _message.From = new MailAddress(m_username);

            _smtp.Send(_message);

            return 1;
         }
         catch (Exception)
         { throw; }
      }
      #endregion
   }
}
