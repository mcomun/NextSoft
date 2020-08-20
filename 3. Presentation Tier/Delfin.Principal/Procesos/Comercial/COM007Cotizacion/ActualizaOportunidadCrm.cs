using BigStick.Http;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web.Script.Serialization;
using System.Text;

namespace Delfin.Principal
{
    class ActualizaOportunidadCrm
    {

        public Boolean SendData(CotizacionDTO oCotizacion)
        {
            ArrayList aResult = new ArrayList();
            ActualizarCotizacionRequest request = new ActualizarCotizacionRequest();
            //request.Token =  Guid.NewGuid().ToString();
            request.CotizacionList.Add(new CotizacionDTO
            {
                idCRM=oCotizacion.idCRM,
                regimen=oCotizacion.regimen,
                via=oCotizacion.via,
                lineaNegocio=oCotizacion.lineaNegocio,
                fechaEmision=oCotizacion.fechaEmision,
                docIden=oCotizacion.docIden,
                trafico=oCotizacion.trafico,
                fechaVcto=oCotizacion.fechaVcto,
                seguro=oCotizacion.seguro,
                servicioLogistico=oCotizacion.servicioLogistico,
                codigoPuertoOrigen=oCotizacion.codigoPuertoOrigen,
                codigoPaisOrigen=oCotizacion.codigoPaisOrigen,
                codigoPuertoDestino=oCotizacion.codigoPuertoDestino,
                codigoPaisDestino=oCotizacion.codigoPaisDestino,
                transportista=oCotizacion.transportista,
                condicionEmbarque=oCotizacion.condicionEmbarque,
                condicionPagoMBL=oCotizacion.condicionPagoMBL,
                condicionPagoHBL=oCotizacion.condicionPagoHBL,
                numeroContrato=oCotizacion.numeroContrato,
                referencia=oCotizacion.referencia,
                observaciones=oCotizacion.observaciones,
                usuario=oCotizacion.usuario,
                codigoMoneda=oCotizacion.codigoMoneda,
                numeroCotizacion=oCotizacion.numeroCotizacion,
                versionCotizacion=oCotizacion.versionCotizacion,
                ContenedorList=oCotizacion.ContenedorList
            });
            Boolean bResult = true;
            try
            {
                object response = Actualizar(request);
            }
            catch (Exception ex)
            {
                bResult = false;
            }
            return bResult;
        }

        public ActualizarCotizacionResponse Actualizar(ActualizarCotizacionRequest request)
        {

            string url = "http://134.209.219.220:8080/producto2/obtener/";

            ActualizarCotizacionResponse response = new ActualizarCotizacionResponse();
            try
            {
                WebClient client = new WebClient();
                client.Headers[HttpRequestHeader.ContentType] = "application/json; charset=utf-8";
                client.Encoding = Encoding.UTF8;
                string postData = (new JavaScriptSerializer()).Serialize(request);

                postData = postData.Substring(19, postData.Length - 21);
                int iPos = postData.IndexOf("ContenedorList") + 16;
                postData = postData.Replace(postData.Substring(iPos, postData.Length - iPos), GetNewText(postData.Substring(iPos, postData.Length - iPos)));
                string responseString = client.UploadString(url, postData);
                
                JavaScriptSerializer serResponse = new JavaScriptSerializer();
                response = serResponse.Deserialize<ActualizarCotizacionResponse>(responseString);

            }
            catch (WebException webex)
            {
                { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError("Cotización", "Ha ocurrido un error al actualizar los datos en el CRM.", webex); }

                WebResponse errResp = webex.Response;
                using (Stream respStream = errResp.GetResponseStream())
                {
                    StreamReader reader = new StreamReader(respStream);
                    string text = reader.ReadToEnd();                    
                }

            }

            return response;
        }

        string GetNewText(string OldText)
        {
            string NewText = "\"";

            int c;
            for (c = 0; c <= OldText.Length-1; c++)
            {
                if (OldText.Substring(c, 1) != "\"")
                {
                    NewText += OldText.Substring(c, 1);
                }
                if (OldText.Substring(c, 1) == "]")
                {
                    NewText += OldText.Substring(c, 1) + "\"";
                }
            }

            return NewText;
        }

        //public ActualizarCotizacionResponse Actualizar(ActualizarCotizacionRequest request)    
        //{

        //    string url = "http://134.209.219.220:8080/producto2/obtener/";
        //    RestDialer restDialer = new RestDialer();
        //    ActualizarCotizacionResponse response = restDialer.PostJSON<ActualizarCotizacionResponse, ActualizarCotizacionRequest>(request, url, "");
        //    if (response == null)
        //    {
        //        throw new Exception("Formato no valido en respuesta de url: " + url);
        //    }
        //    return response;
        //}

        public class ActualizarCotizacionRequest : BaseRequest
        {
            public ActualizarCotizacionRequest()
            {
                this.CotizacionList = new List<CotizacionDTO>();
            }
            //public string Token { get; set; }
            public List<CotizacionDTO> CotizacionList { get; set; }
        }

        public class CotizacionDTO
        {
            public string idCRM { get; set; }
            public string regimen { get; set; }
            public string via { get; set; }
            public string lineaNegocio { get; set; }
            public string fechaEmision { get; set; }
            public string docIden { get; set; }
            public string trafico { get; set; }
            public string fechaVcto { get; set; }
            public Boolean seguro { get; set; }
            public Boolean servicioLogistico { get; set; }
            public string codigoPuertoOrigen { get; set; }
            public string codigoPaisOrigen { get; set; }
            public string codigoPuertoDestino { get; set; }
            public string codigoPaisDestino { get; set; }
            public string transportista { get; set; }
            public string condicionEmbarque { get; set; }
            public string condicionPagoMBL { get; set; }
            public string condicionPagoHBL { get; set; }
            public string numeroContrato { get; set; }
            public string referencia { get; set; }
            public string observaciones { get; set; }
            public string usuario { get; set; }
            public string codigoMoneda { get; set; }
            public string numeroCotizacion { get; set; }
            public string versionCotizacion { get; set; }
            public List<ContenedorDTO> ContenedorList { get; set; }
        }

        public class ContenedorDTO
        {
            public string tipoContenedor { get; set; }
            public int cantidadTipoContenedor { get; set; }
            public Double precioUnitarioTipoContenedor { get; set; }
            public Double importeTotalTipoContenedor { get; set; }
        }

        public class BaseRequest
        {
            public BaseRequest()
            {
                //this.Meta = new MetaRequest();
            }

            //public MetaRequest Meta { get; set; }
        }

        public class MetaRequest
        {
            public string Usuario { get; set; }

            public int CurrentPage { get; set; }
            public int Size { get; set; }
        }

        public class ActualizarCotizacionResponse : BaseResponse
        {
            public ActualizarCotizacionResponse()
            {
                this.ErrorList = new List<CotizacionError>();
            }

            public List<CotizacionError> ErrorList { get; set; }
        }

        public class CotizacionError
        {
            public string idCRM { get; set; }
            public string numeroCotizacion { get; set; }
            public string versionCotizacion { get; set; }
        }

        public class BaseResponse
        {
            public BaseResponse()
            {
                this.Result = new Result();
                //this.Meta = new MetaResponse();
            }

            public Result Result { get; set; }
            //public MetaResponse Meta { get; set; }
        }

        public class Result
        {
            public Result()
            {
                this.Success = false;
                this.ErrCode = "";
                this.Message = "";
                this.Messages = new List<Result>();
            }

            public bool Success { get; set; }
            public string ErrCode { get; set; }
            public string Message { get; set; }
            public Guid IdError { get; set; }
            public List<Result> Messages { get; set; }
        }

        public class MetaResponse
        {
            public int Total { get; set; }
        }

    }
}
