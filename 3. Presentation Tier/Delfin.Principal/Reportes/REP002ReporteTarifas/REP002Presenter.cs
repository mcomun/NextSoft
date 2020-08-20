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
using Delfin.Controls;

namespace Delfin.Principal
{
   public class REP002Presenter
   {
      #region [ Variables ]
      public String Title = "Reporte de Tarifas";
      public String CUS = "REP002";
      #endregion

      #region [ Contrusctor ]
      public REP002Presenter(IUnityContainer x_container, IREP002LView x_lview)
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
            ListPuertos = Client.GetAllPuerto();
            ListPaquetes = Client.GetAllPaquete();
            LView.LoadView();
            //MView.LoadView();
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Title, "Ha ocurrido un error inicializando la vista.", ex); }
      }
      #endregion

      #region [ Propiedades ]
      public IUnityContainer ContainerService { get; set; }
      public ISessionService Session { get; set; }
      public IDelfinServices Client { get; set; }

      public IREP002LView LView { get; set; }

      public ObservableCollection<Puerto> ListPuertos { get; set; }
      public ObservableCollection<Paquete> ListPaquetes { get; set; }
      public System.Data.DataTable DTReporte { get; set; }
      public Entities.Entidad Transportista { get; set; }
      public Contrato ItemContrato { get; set; }
      #endregion

      #region [ Metodos ]
      public void CargarReporte(String CONS_TabRGM, String CONS_CodRGM, String CONS_TabVIA, String CONS_CodVIA, DateTime CONT_Fecha, Nullable<Int32> PACK_Codigo, Nullable<Int32> ENTC_CodTransportista, Nullable<Int32> CONT_Codigo, Nullable<Int32> PUER_CodOrigen, Nullable<Int32> PUER_CodDestino, Boolean CONT_Activo)
      {
         try
         {

            DTReporte = Client.GetAllContratoByReporte(Delfin.Controls.Entorno.ItemEmpresa.EMPR_Codigo, CONS_TabRGM, CONS_CodRGM, CONS_TabVIA, CONS_CodVIA, CONT_Fecha, PACK_Codigo, ENTC_CodTransportista, CONT_Codigo, PUER_CodOrigen, PUER_CodDestino, CONT_Activo);

            if (DTReporte != null && DTReporte.Rows.Count > 0)
            {
               LView.ShowItems();
            }
            else
            { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Title, "No se encontraron resultados."); }

         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Title, "Ha ocurrido un error cargando el reporte.", ex); }
      }
      public void LimpiarReporte()
      {
         try
         {
            DTReporte = new System.Data.DataTable();
            LView.ShowItems();
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Title, "Ha ocurrido un error limpiando el reporte.", ex); }
      }
      #endregion

      #region [ Metodos Contrato ]
      public void AyudaContrato(String CONS_TabRGM, String CONS_CodRGM, String CONS_TabVIA, String CONS_CodVIA, Nullable<Int32> ENTC_CodTransportista)
      {
         try
         {
            Int32 _CONT_Codigo = -1;
            String _TIPO_TabPaisOrigen = null;
            String _TIPO_CodPaisOrigen = null;
            Nullable<Int32> _PUER_CodigoOrigen = null;
            String _TIPO_TabPaisDestino = null;
            String _TIPO_CodPaisDestino = null;
            Nullable<Int32> _PUER_CodigoDestino = null;

            System.Data.DataTable dtAyuda = new System.Data.DataTable();
            dtAyuda = Client.GetAllContratoByAyuda(Delfin.Controls.Entorno.ItemEmpresa.EMPR_Codigo,ENTC_CodTransportista, CONS_TabRGM, CONS_CodRGM, CONS_TabVIA, CONS_CodVIA, null, null).ToDataTable();
            
            if (dtAyuda.Rows.Count == 0)
            { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Title, "No se encontraron coincidencias."); }
            else if (dtAyuda.Rows.Count == 1)
            {
               if (Int32.TryParse(dtAyuda.Rows[0]["CONT_Codigo"].ToString(), out _CONT_Codigo))
               {
                  _TIPO_TabPaisOrigen = dtAyuda.Rows[0]["TIPO_TabPaisOrigen"].ToString();
                  _TIPO_CodPaisOrigen = dtAyuda.Rows[0]["TIPO_CodPaisOrigen"].ToString();
                  if (dtAyuda.Rows[0]["PUER_CodigoOrigen"] != System.DBNull.Value)
                  {
                     Int32 _PUER_CodigoOrigenValue;
                     if (Int32.TryParse(dtAyuda.Rows[0]["PUER_CodigoOrigen"].ToString(), out _PUER_CodigoOrigenValue))
                     { _PUER_CodigoOrigen = _PUER_CodigoOrigenValue; }
                  }
                  _TIPO_TabPaisDestino = dtAyuda.Rows[0]["TIPO_TabPaisDestino"].ToString();
                  _TIPO_CodPaisDestino = dtAyuda.Rows[0]["TIPO_CodPaisDestino"].ToString();

                  if (dtAyuda.Rows[0]["PUER_CodigoDestino"] != System.DBNull.Value)
                  {
                     Int32 _PUER_CodigoDestinoValue;
                     if (Int32.TryParse(dtAyuda.Rows[0]["PUER_CodigoDestino"].ToString(), out _PUER_CodigoDestinoValue))
                     { _PUER_CodigoDestino = _PUER_CodigoDestinoValue; }
                  }
               }
            }
            else
            {
               List<Infrastructure.WinForms.Controls.ColumnaAyuda> _columnas = new List<Infrastructure.WinForms.Controls.ColumnaAyuda>();
               _columnas.Add(new Infrastructure.WinForms.Controls.ColumnaAyuda()
               {
                  Index = 0,
                  ColumnName = "CONT_Numero",
                  ColumnCaption = "Número"
               });
               _columnas.Add(new Infrastructure.WinForms.Controls.ColumnaAyuda()
               {
                  Index = 1,
                  ColumnName = "CONT_Descrip",
                  ColumnCaption = "Descripción"
               });
               _columnas.Add(new Infrastructure.WinForms.Controls.ColumnaAyuda()
               {
                  Index = 2,
                  ColumnName = "CONT_FecIni",
                  ColumnCaption = "Fec. Inicio"
               });
               _columnas.Add(new Infrastructure.WinForms.Controls.ColumnaAyuda()
               {
                  Index = 3,
                  ColumnName = "CONT_FecFin",
                  ColumnCaption = "Fec. Fin"
               });
               _columnas.Add(new Infrastructure.WinForms.Controls.ColumnaAyuda()
               {
                  Index = 4,
                  ColumnName = "CONT_FecEmi",
                  ColumnCaption = "Fec. Emisión"
               });
               _columnas.Add(new Infrastructure.WinForms.Controls.ColumnaAyuda()
               {
                  Index = 5,
                  ColumnName = "TIPO_DescPaisOrigen",
                  ColumnCaption = "País Origen"
               });
               _columnas.Add(new Infrastructure.WinForms.Controls.ColumnaAyuda()
               {
                  Index = 6,
                  ColumnName = "PUER_NombreOrigen",
                  ColumnCaption = "Puerto Origen"
               });
               _columnas.Add(new Infrastructure.WinForms.Controls.ColumnaAyuda()
               {
                  Index = 7,
                  ColumnName = "TIPO_DescPaisDestino",
                  ColumnCaption = "País Destino"
               });
               _columnas.Add(new Infrastructure.WinForms.Controls.ColumnaAyuda()
               {
                  Index = 8,
                  ColumnName = "PUER_NombreDestino",
                  ColumnCaption = "Puerto Destino"
               });
               _columnas.Add(new Infrastructure.WinForms.Controls.ColumnaAyuda()
               {
                  Index = 9,
                  ColumnName = "CONT_Codigo",
                  ColumnCaption = "Código"
               });
               

               Infrastructure.WinForms.Controls.Ayuda x_Ayuda = new Infrastructure.WinForms.Controls.Ayuda("Ayuda Contrato", dtAyuda, false, _columnas);
               if (x_Ayuda.ShowDialog() == System.Windows.Forms.DialogResult.OK)
               {
                  if (Int32.TryParse(x_Ayuda.Respuesta.Rows[0]["CONT_Codigo"].ToString(), out _CONT_Codigo))
                  {
                     _TIPO_TabPaisOrigen = x_Ayuda.Respuesta.Rows[0]["TIPO_TabPaisOrigen"].ToString();
                     _TIPO_CodPaisOrigen = x_Ayuda.Respuesta.Rows[0]["TIPO_CodPaisOrigen"].ToString();
                     if (x_Ayuda.Respuesta.Rows[0]["PUER_CodigoOrigen"] != System.DBNull.Value)
                     {
                        Int32 _PUER_CodigoOrigenValue;
                        if (Int32.TryParse(x_Ayuda.Respuesta.Rows[0]["PUER_CodigoOrigen"].ToString(), out _PUER_CodigoOrigenValue))
                        { _PUER_CodigoOrigen = _PUER_CodigoOrigenValue; }
                     }
                     _TIPO_TabPaisDestino = x_Ayuda.Respuesta.Rows[0]["TIPO_TabPaisDestino"].ToString();
                     _TIPO_CodPaisDestino = x_Ayuda.Respuesta.Rows[0]["TIPO_CodPaisDestino"].ToString();
                     if (x_Ayuda.Respuesta.Rows[0]["PUER_CodigoDestino"] != System.DBNull.Value)
                     {
                        Int32 _PUER_CodigoDestinoValue;
                        if (Int32.TryParse(x_Ayuda.Respuesta.Rows[0]["PUER_CodigoDestino"].ToString(), out _PUER_CodigoDestinoValue))
                        { _PUER_CodigoDestino = _PUER_CodigoDestinoValue; }
                     }
                  }

               }
            }

            if (_CONT_Codigo > 0)
            {
               Contrato _itemContrato = Client.GetOneContrato(Delfin.Controls.Entorno.ItemEmpresa.EMPR_Codigo, _CONT_Codigo);
               _itemContrato.TIPO_TabPaisOrigen = _TIPO_TabPaisOrigen;
               _itemContrato.TIPO_CodPaisOrigen = _TIPO_CodPaisOrigen;
               _itemContrato.PUER_CodigoOrigen = _PUER_CodigoOrigen;
               _itemContrato.TIPO_TabPaisDestino = _TIPO_TabPaisDestino;
               _itemContrato.TIPO_CodPaisDestino = _TIPO_CodPaisDestino;
               _itemContrato.PUER_CodigoDestino = _PUER_CodigoDestino;

               ItemContrato = _itemContrato;
               LView.SetItemContrato();
            }
            else
            { LView.ClearItemContrato(); }
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Title, "ha ocurrido un error en la Ayuda de Contrato", ex); }
      }
      #endregion
   }
}
