using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Practices.Unity;
using Delfin.ServiceContracts;
using Delfin.ServiceProxy;
using Delfin.Entities;
using Infrastructure.Aspect;
using Infrastructure.Aspect.Collections;
using Infrastructure.Client.Services.Session;
using System.Collections.ObjectModel;
using System.IO;

using System.Configuration;
using System.Net;
using System.Runtime.Serialization.Json;


namespace Delfin.Principal
{
   public partial class CAJ013RespuestaDetraccionPresenter
   {
      #region [ Variables ]
      public String Title = "RESPUESTA DE DETRACCIÓN";
      public String CUS = "CAJ013";

      #endregion

      #region [ Constructor ]
      public CAJ013RespuestaDetraccionPresenter(IUnityContainer x_container, ICAJ013RespuestaDetraccionLView x_lview)
      {
         try
         {
            this.ContainerService = x_container;
            Session = this.ContainerService.Resolve<ISessionService>();
            this.LView = x_lview;

         }
         catch (Exception)
         { throw; }
      }
      public void Load()
      {
         try
         {
            Client = ContainerService.Resolve<IDelfinServices>();

            LView.LoadView();
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Title, "Ha ocurrido un error inicializando la vista.", ex); }
      }
      #endregion

      #region [ Propiedades ]
      public IUnityContainer ContainerService { get; set; }
      public ISessionService Session { get; set; }
      public IDelfinServices Client { get; set; }

      public ICAJ013RespuestaDetraccionLView LView { get; set; }
      public ICAJ013RespuestaDetraccionMView MView { get; set; }

      public Planillas Item { get; set; }
      public ObservableCollection<Planillas> Items { get; set; }

      public String MensajeError { get; set; }

      #endregion

      #region [ Metodos ]

      public void Actualizar()
      {
         try
         {
            Item = null;
            Items = null;

            if (LView != null)
            {
               LView.ShowItems();
            }
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Title, "Ha ocurrido un error actualizando.", ex); }
      }

      public Infrastructure.Aspect.Constants.CCabeceraRDetracciones CRespuestas { get; set; }
      
      public bool AbrirArchivo(Object Codificacion)
      {
          try
          {
              String x_DCabecera = "Datos de cabecera";
              String x_nroOperacion = "Numero de operacion";
              String x_fechahora = "Fecha y hora de pago";
              String x_archivo = "Archivo";
              String x_lote = "Lote";
              String x_ruc = "RUC del Adquiriente";
              String x_razsocial = "Razón Social del Adquiriente";
              String x_nrodepositos = "Numero de depositos";
              String x_montototal = "Monto total";

              String x_DDetalle = "Datos de detalle";
              String x_NroConstancia = "Numero de constancia";
              String x_TDocProveedor = "Tipo Documento del Proveedor";
              String x_NroDocProveedor = "Número Documento del Proveedor";
              String x_NomRazSocial = "Nombre/Razón Social del Proveedor";
              String x_CodOperacion = "Codigo operacion";
              String x_NomOperacion = "Nombre operacion";
              String x_CodServicio = "Codigo bien o servicio";
              String x_NomServicio = "Nombre bien o servicio";
              String x_MontoDeposito = "Monto deposito";
              String x_PeriodoTributario = "Periodo Tributario";
              String x_TipoComprobante = "Tipo de Comprobante";
              String x_NroComprobante = "Número de Comprobante";

              CRespuestas.EMPR_Codigo = Controls.Entorno.ItemEmpresa.EMPR_Codigo;
              CRespuestas.ListRespuestas =
                  new ObservableCollection<Infrastructure.Aspect.Constants.CRespuestaDetracciones>();

              #region Leer Archivo Plano

              int counter = 0;
              string line;

              // Leer archivo linea por linea
              FileStream stream = new FileStream(@CRespuestas.PathArchivo, FileMode.Open, FileAccess.Read);

              StreamReader file;
              try
              {
                  file = new StreamReader(stream, Encoding.GetEncoding(Convert.ToInt32(Codificacion)));
              }
              catch (Exception)
              {
                  file = new StreamReader(stream, Encoding.GetEncoding(Codificacion.ToString()));
              }

              CRespuestas.Archivo = new StringBuilder();
              Boolean x_cuerpo = false, x_cabecera = true, x_primero = true;
              Infrastructure.Aspect.Constants.CRespuestaDetracciones x_crepuesta =
                  new Infrastructure.Aspect.Constants.CRespuestaDetracciones();
              while ((line = file.ReadLine()) != null)
              {
                  CRespuestas.Archivo.AppendLine(line);

                  #region [ Levantar Respuesta Detracciones]

                  #region [ Cabecera ]

                  if (line.Contains(x_DCabecera))
                  {
                      x_cabecera = true;
                  }
                  if (x_cabecera)
                  {
                      if (line.Contains(x_nroOperacion))
                      {
                          CRespuestas.NroOperacion = line.Substring(x_nroOperacion.Length).Trim();
                      }
                      if (line.Contains(x_fechahora))
                      {
                          DateTime x_fecha;
                          if (DateTime.TryParse(line.Substring(x_fechahora.Length).Trim(), out x_fecha))
                          {
                              CRespuestas.FechaHora = x_fecha;
                          }
                      }
                      if (line.Contains(x_archivo))
                      {
                          CRespuestas.NombreArchivo = line.Substring(x_archivo.Length).Trim();
                      }
                      if (line.Contains(x_lote))
                      {
                          CRespuestas.Lote = line.Substring(x_lote.Length).Trim();
                      }
                      if (line.Contains(x_ruc))
                      {
                          CRespuestas.RUC = line.Substring(x_ruc.Length).Trim();
                      }
                      if (line.Contains(x_nrodepositos))
                      {
                          Int32 _nrodep;
                          if (Int32.TryParse(line.Substring(x_nrodepositos.Length).Trim(), out _nrodep))
                          {
                              CRespuestas.NroDepositos = _nrodep;
                          }
                      }
                      if (line.Contains(x_montototal))
                      {
                          Decimal _monto;
                          if (Decimal.TryParse(line.Substring(x_montototal.Length).Trim(), out _monto))
                          {
                              CRespuestas.MontoTotal = _monto;
                          }
                      }
                  }

                  #endregion

                  #region [ Detalle ]

                  if (line.Contains(x_DDetalle))
                  {
                      x_cuerpo = true;
                      x_cabecera = false;
                  }
                  if (line.Contains(x_NroConstancia) && x_cuerpo)
                  {
                      if (!x_primero)
                      {
                          x_crepuesta.EMPR_Codigo = Controls.Entorno.ItemEmpresa.EMPR_Codigo;
                          x_crepuesta.AUDI_UsrMod = Session.UserName;
                          x_crepuesta.Fecha = CRespuestas.FechaHora.Value;
                          CRespuestas.ListRespuestas.Add(x_crepuesta);
                          x_crepuesta = new Infrastructure.Aspect.Constants.CRespuestaDetracciones();
                      }
                      x_primero = false;
                  }
                  if (x_cuerpo && line.Trim().Length > 0)
                  {
                      if (line.Contains(x_NroConstancia))
                      {
                          x_crepuesta.NroConstancia = line.Substring(x_NroConstancia.Length).Trim();
                      }
                      if (line.Contains(x_TDocProveedor))
                      {
                          x_crepuesta.TipoDocProveedor = line.Substring(x_TDocProveedor.Length).Trim().Substring(0, 1);
                      }
                      if (line.Contains(x_NroDocProveedor))
                      {
                          x_crepuesta.NroDocProveedor = line.Substring(x_NroDocProveedor.Length).Trim();
                      }
                      if (line.Contains(x_PeriodoTributario))
                      {
                          x_crepuesta.PeriodosTributario = line.Substring(x_PeriodoTributario.Length).Trim();
                      }
                      if (line.Contains(x_TipoComprobante))
                      {
                          x_crepuesta.TipoComprobante = line.Substring(x_TipoComprobante.Length).Trim().Substring(0, 2);
                      }
                      if (line.Contains(x_NroComprobante))
                      {
                          x_crepuesta.NumeroComprobante = line.Substring(x_NroComprobante.Length).Trim();
                      }
                      if (line.Contains(x_NomRazSocial))
                      {
                          x_crepuesta.RazonSocial = line.Substring(x_NomRazSocial.Length).Trim();
                      }
                  }

                  #endregion

                  #endregion

                  counter++;
              }

              x_crepuesta.EMPR_Codigo = Controls.Entorno.ItemEmpresa.EMPR_Codigo;
              x_crepuesta.AUDI_UsrMod = Session.UserName;
              x_crepuesta.Fecha = CRespuestas.FechaHora.Value;
              CRespuestas.ListRespuestas.Add(x_crepuesta);
              file.Close();

              #endregion

              return true;
          }
          catch (Exception ex)
          {
              Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Title, "Ha ocurrido un error cargando el archivo.", ex);
              return false;
          }
      }
           
      public Boolean LevantarRespuesta()
      {
         try
         {
            String _mensaje = "";
            if (Client.SavePlanillasLevantarRespuesta(CRespuestas, ref _mensaje))
            {
               MensajeError = _mensaje;
               return !(MensajeError.Length > 0);
            }
            return false;
         }
         catch (Exception)
         { throw; }
      }

      public void CloseView()
      {         
          //((CAJ013RespuestaDetraccionMView)MView).Close(); 
      }

      #endregion

      #region [ Metodos Eventos/Tareas ]

      #endregion
   }

}