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

namespace Delfin.Principal
{
   public class COM001Presenter
   {
      #region [ Variables ]
      public String Title = "Importación de Prospectos";
      public String CUS = "COM001";
      #endregion

      #region [ Contrusctor ]
      public COM001Presenter(IUnityContainer x_container, ICOM001LView x_lview)
      {
         try
         {
            this.ContainerService = x_container;
            Session = this.ContainerService.Resolve<ISessionService>();
            this.LView = x_lview;
            //this.MView = x_mview;
         }
         catch (Exception)
         { throw; }
      }
      public void Load()
      {
         try
         {
            Client = ContainerService.Resolve<IDelfinServices>();

            ListTiposCDT = Client.GetAllTiposByTipoCodTabla("CDT");
            if (ListTiposCDT == null) { ListTiposCDT = new ObservableCollection<Tipos>(); }

            ListConstantesRGM = Client.GetAllConstantesByConstanteTabla("RGM");
            if (ListConstantesRGM == null) { ListConstantesRGM = new ObservableCollection<Constantes>(); }

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

      public ICOM001LView LView { get; set; }
      //public ICOM001MView MView { get; set; }

      public Prospecto Item { get; set; }
      public ObservableCollection<Prospecto> Items { get; set; }
      
      public Entidad ItemAgenteCarga { get; set; }
      public Entidad ItemEjecutivo { get; set; }
      
      public Tipos ItemTipoCDT { get; set; }
      public ObservableCollection<Tipos> ListTiposCDT { get; set; }

      public Constantes ItemConstanteRGM { get; set; }
      public ObservableCollection<Constantes> ListConstantesRGM { get; set; }
      #endregion

      #region [ Metodos ]
      public bool Guardar()
      {
         try
         {
            //MView.GetItem();
            //if (Item.Validar())
            //{
            //   if (Client.SaveEmpresa(Item))
            //   {
            //      Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeSatisfactorio(Title, "Se ha guardado satisfactoriamente");
            //      Actualizar();
            //      return true;
            //   }
            //   else
            //   {
            //      Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Title, "Ha ocurrido un error al guardar el item.");
            //      return false;
            //   }
            //}
            //else
            //{
            //   MView.ShowValidation();
            //   return false;
            //}

            return true;
         }
         catch (Exception ex)
         {
            Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Title, Infrastructure.Aspect.Constants.Mensajes.SavePresenter, ex);
            return false;
         }
      }

      public void LoadArchivo(ref System.Windows.Forms.ProgressBar pgbProgreso, string x_IMPO_Ruta, Int32 TEUS)
      {
         try
         {
            if (ItemConstanteRGM != null)
            {
               Items = new ObservableCollection<Prospecto>();

               Infrastructure.WinForms.Controls.ImportarExcel excel = new Infrastructure.WinForms.Controls.ImportarExcel();
               String _errorMessage = "";
               System.Data.DataTable dtImportacion = excel.ReadExcel(x_IMPO_Ruta, ref _errorMessage);

               if (dtImportacion != null && dtImportacion.Rows.Count > 0)
               {
                  foreach (System.Data.DataColumn column in dtImportacion.Columns)
                  { column.ColumnName = column.ColumnName.ToUpper().Trim(); }

                  string _mensajeErrorGeneral = "";
                  int _currentRow = 1;

                  pgbProgreso.Visible = true;
                  pgbProgreso.Maximum = dtImportacion.Rows.Count + 1;

                  foreach (System.Data.DataRow _fila in dtImportacion.Rows)
                  {
                     _currentRow++;
                     pgbProgreso.Value = _currentRow;

                     string columna = null;

                     Item = null;
                     Item = new Prospecto();
                     Item.CONS_TabRGM = ItemConstanteRGM.CONS_CodTabla;
                     Item.CONS_CodRGM = ItemConstanteRGM.CONS_CodTipo;
                     Item.CONS_DescRGM = ItemConstanteRGM.CONS_Desc_SPA;

                     columna = "CONSIGNATARIO";
                     if (dtImportacion.Columns.Contains(columna))
                     {
                        if (!String.IsNullOrEmpty(_fila[columna].ToString()))
                        { Item.ENTC_RazonSocialCliente = _fila[columna].ToString(); }
                        else
                        { _mensajeErrorGeneral = String.Format("La columna {0}, no tiene un valor corecto en el archivo y es obligatorio.", columna); break; }
                     }
                     else
                     { _mensajeErrorGeneral = String.Format("No se ha encontrado la columna {0}, en el archivo y es obligatoria.", columna); break; }

                     columna = "TEUS";
                     if (dtImportacion.Columns.Contains(columna))
                     {
                        Int32 _PROS_TEUS;
                        if (Int32.TryParse(_fila[columna].ToString(), out _PROS_TEUS))
                        { Item.PROS_TEUS = _PROS_TEUS; }
                        else
                        { _mensajeErrorGeneral = String.Format("La columna {0}, no tiene un valor corecto en el archivo y es obligatorio.", columna); break; }
                     }
                     else
                     { _mensajeErrorGeneral = String.Format("No se ha encontrado la columna {0}, en el archivo y es obligatoria.", columna); break; }

                     columna = "AGENTE";
                     if (dtImportacion.Columns.Contains(columna))
                     {
                        if (!String.IsNullOrEmpty(_fila[columna].ToString()))
                        { Item.ENTC_RazonSocialAgenteCarga = _fila[columna].ToString(); }
                     }

                     columna = "COMODITY";
                     if (dtImportacion.Columns.Contains(columna))
                     {
                        if (!String.IsNullOrEmpty(_fila[columna].ToString()))
                        { Item.TIPO_DescCDT = _fila[columna].ToString(); }
                     }

                     columna = "PORCENTAJE";
                     if (dtImportacion.Columns.Contains(columna))
                     {
                        Decimal _PROS_Porcentaje;
                        if (Decimal.TryParse(_fila[columna].ToString(), out _PROS_Porcentaje))
                        { Item.PROS_Porcentaje = _PROS_Porcentaje; }
                     }

                     columna = "CONT40";
                     if (dtImportacion.Columns.Contains(columna))
                     {
                        Int32 _PROS_CNTR40;
                        if (Int32.TryParse(_fila[columna].ToString(), out _PROS_CNTR40))
                        { Item.PROS_CNTR40 = _PROS_CNTR40; }
                     }

                     columna = "CONT20";
                     if (dtImportacion.Columns.Contains(columna))
                     {
                        Int32 _PROS_CNTR20;
                        if (Int32.TryParse(_fila[columna].ToString(), out _PROS_CNTR20))
                        { Item.PROS_CNTR20 = _PROS_CNTR20; }
                     }

                     columna = "OBSERVACION";
                     if (dtImportacion.Columns.Contains(columna))
                     {
                        if (!String.IsNullOrEmpty(_fila[columna].ToString()))
                        { Item.ENTC_Notas = _fila[columna].ToString(); }
                        
                     }

                     Item.ValidarImportacion();
                     if (!String.IsNullOrEmpty(Item.MensajeError))
                     {
                        _mensajeErrorGeneral += "El registro " + _currentRow.ToString() + " tiene los siguientes errore: " + Environment.NewLine;
                        _mensajeErrorGeneral += Item.MensajeError + Environment.NewLine;
                     }

                     Items.Add(Item);
                  }

                  if (String.IsNullOrEmpty(_mensajeErrorGeneral))
                  {
                     //Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeSatisfactorio(Title, String.Format("Se ha cargado satisfactoriamente el archivo.\nTotal de registros cargados: {0}", Items.Count));

                     Items = Items.Where(pros => pros.PROS_TEUS >= TEUS).ToObservableCollection();


                     //Validar en la BD
                     Int16 _EMPR_Codigo = Controls.Entorno.ItemEmpresa.EMPR_Codigo;
                     Int16 _SUCR_Codigo = Controls.Entorno.ItemSucursal.SUCR_Codigo;
                     DateTime _PROS_FecAsignacion = DateTime.Now;
                     Items = Client.GetAllProspectosValidos(Items.ToTableValuedParameter(), _EMPR_Codigo, _SUCR_Codigo, _PROS_FecAsignacion);
                     LView.ShowItems(true);
                  }
                  else
                  {
                     Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Title, "Errores al Cargar", _mensajeErrorGeneral);
                     LView.ShowItems(false);
                     //return false;
                  }
               }
               else
               { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Title, "No se ha podido leer el archivo seleccionado."); }
            }
            else
            { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Title, "Debe seleccionar un regimen."); }
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Title, "Ha ocurrido un error al cargar el archivo.", ex); }
         finally
         {
            pgbProgreso.Visible = false;
            pgbProgreso.Maximum = 0;
            pgbProgreso.Value = 0;
         }
      }
      public void AsignarEjecutivo()
      {
         try
         {
            if (ItemEjecutivo != null)
            {
               ObservableCollection<Prospecto> _itemsSeleccionados = Items.Where(pros => pros.PROS_Asignar).ToObservableCollection();
               foreach (Prospecto _itemSeleccionado in _itemsSeleccionados)
               {
                  _itemSeleccionado.ENTC_CodEjecutivo = ItemEjecutivo.ENTC_Codigo;
                  _itemSeleccionado.ENTC_NomCompletoEjecutivo = ItemEjecutivo.ENTC_NomCompleto;
                  
               }

               Int16 _EMPR_Codigo = Controls.Entorno.ItemEmpresa.EMPR_Codigo;
               Int16 _SUCR_Codigo = Controls.Entorno.ItemSucursal.SUCR_Codigo;
               DateTime _PROS_FecAsignacion = DateTime.Now;
               String _AUDI_Usuario = "NEXTSOFT";
               Client.AsignarProspectos(_itemsSeleccionados.ToTableValuedParameter(), _EMPR_Codigo, _SUCR_Codigo, _PROS_FecAsignacion, _AUDI_Usuario);

               Items = Items.Where(pros => !pros.PROS_Asignar).ToObservableCollection();
               LView.ShowItems(true);
            }
            else
            { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Title, "Debe seleccionar un Ejecutivo."); }
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Title, "Ha ocurrido un error al asignar el Ejecutivo.", ex); }
      }
      #endregion
   }
}
