using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Infrastructure.Aspect.Collections;

namespace Delfin.Principal
{
   public partial class OPE003View : Form, IOPE003View
   {
      #region [ Variables ]
       public sealed class TipoFecha
       {

           private TipoFecha()
           {
           }
           //ESTADOS
           public const int FechaETA = 1;
           public const int FechaEmbarque = 2;
           public const int FechaExportacion = 3;
       }
      #endregion

      #region [ Formulario ]
      public OPE003View()
      {
         InitializeComponent();
         try
         {
            btnCargar.Click += btnCargar_Click;
            btnSalir.Click += btnSalir_Click;

            cmbCONS_CodLNG.SelectedIndexChanged += cmbCONS_CodLNG_SelectedIndexChanged;
            cmbCONS_CodRGM.SelectedIndexChanged += cmbCONS_CodRGM_SelectedIndexChanged;
            txaENTC_CodAgente.AyudaValueChanged += txaENTC_CodAgente_AyudaValueChanged;
            cmbTIPO_CodPAIOrigen.SelectedIndexChanged += cmbTIPO_CodPAIOrigen_SelectedIndexChanged;

            this.Load += OPE002View_Load;
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error inicializando el formulario MView.", ex); }
      }
      private void OPE002View_Load(object sender, EventArgs e)
      {
         
      }
      #endregion

      #region [ Propiedades ]
      public OPE003Presenter Presenter { get; set; }
      #endregion

      #region [ IOPE002MView ]
      public void LoadView()
      {
         try
         {
            txaENTC_CodCliente.ContainerService = Presenter.ContainerService;
            txaENTC_CodCliente.TipoEntidad = Delfin.Controls.TiposEntidad.TIPE_Cliente;
            txaENTC_CodAgente.ContainerService = Presenter.ContainerService;
            txaENTC_CodAgente.TipoEntidad = Delfin.Controls.TiposEntidad.TIPE_Agente;
            txaENTC_CodEjecutivo.ContainerService = Presenter.ContainerService;
            txaENTC_CodEjecutivo.TipoEntidad = Delfin.Controls.TiposEntidad.TIPE_Ejecutivo;
            txaENTC_CodTransportista.ContainerService = Presenter.ContainerService;
            txaENTC_CodTransportista.TipoEntidad = Delfin.Controls.TiposEntidad.TIPE_Transportista;
            cmbTIPO_CodPAIOrigen.LoadControl(Presenter.ContainerService, "Tabla de Paises", "PAI", "< Seleccionar País Origen >", ListSortDirection.Ascending);
            txaPUER_CodOrigen.LoadControl(Presenter.ContainerService, "Ayuda Puertos de Origen");
            cmbTIPO_CodPAIDestino.LoadControl(Presenter.ContainerService, "Tabla de Paises", "PAI", "< Seleccionar País Destino >", ListSortDirection.Ascending);
            txaPUER_CodDestino.LoadControl(Presenter.ContainerService, "Ayuda Puertos de Destino");
            //chkCONS_CodFLE001
            //chkCONS_CodFLE002
            //chkCONS_CodFLE003
            //chkCONS_CodFLE004
            cmbCONS_CodRGM.LoadControl(Presenter.ContainerService, "Constantes Régimen", "RGM", "< Seleccionar Régimen >", ListSortDirection.Ascending);
            cmbCONS_CodVia.LoadControl(Presenter.ContainerService, "Constantes Vía", "VIA", "< Seleccionar Vía >", ListSortDirection.Ascending);
            //cmbCCOT_TipoFecha.AddComboBoxItem(1, "Por ETA", true);
            //cmbCCOT_TipoFecha.AddComboBoxItem(2, "Por ETD");
            //cmbCCOT_TipoFecha.LoadComboBox("< Seleccionar Tipo de Fecha >");
            
            cmbCONS_CodLNG.LoadControl(Presenter.ContainerService, "Constantes Línea de Negocio", "LNG", null, ListSortDirection.Ascending);
            ObservableCollection<Entities.Constantes> _listLNG;
            if (Presenter.CONS_CodRGM == "001")
            { 
               _listLNG = new ObservableCollection<Entities.Constantes>((cmbCONS_CodLNG.DataSource as ObservableCollection<Entities.Constantes>).Where(lng => lng.CONS_CodTipo != Delfin.Controls.variables.CONSLNG_Exportacion && lng.CONS_CodTipo != Delfin.Controls.variables.CONSLNG_SLI));
               cmbCONS_CodLNG.LoadControl(_listLNG, "Constantes Línea de Negocio", "LNG", "< Seleccionar Línea de Negocio >", ListSortDirection.Ascending);
            }
            else
            { 
               _listLNG = new ObservableCollection<Entities.Constantes>((cmbCONS_CodLNG.DataSource as ObservableCollection<Entities.Constantes>).Where(lng => lng.CONS_CodTipo == Delfin.Controls.variables.CONSLNG_Exportacion && lng.CONS_CodTipo != Delfin.Controls.variables.CONSLNG_SLI));
               cmbCONS_CodLNG.LoadControl(_listLNG, "Constantes Línea de Negocio", "LNG", null, ListSortDirection.Ascending);
            }
            

            //mdtCCOT_FecEmisionDesde
            //mdtCCOT_FecEmisionHasta

            cmbTipoFecha.AddComboBoxItem(TipoFecha.FechaETA,"Fecha ETA", true);
            cmbTipoFecha.AddComboBoxItem(TipoFecha.FechaEmbarque, "Fecha Embarque");
            cmbTipoFecha.LoadComboBox("< Seleccione una Fecha >");

            cmbCCOT_CodFLE.AddComboBoxItem(1, "FCL", true);
            cmbCCOT_CodFLE.AddComboBoxItem(2, "LCL");
            cmbCCOT_CodFLE.LoadComboBox("< Todos >");


            cmbREPO_Gerencia.AddComboBoxItem(1, "EXPO FCL", true);
            cmbREPO_Gerencia.AddComboBoxItem(2, "EXPO LCL");
            cmbREPO_Gerencia.AddComboBoxItem(3, "IMPO FCL");
            cmbREPO_Gerencia.AddComboBoxItem(4, "IMPO LCL");
            cmbREPO_Gerencia.AddComboBoxItem(5, "TRANSMISIONES");

            cmbREPO_Gerencia.LoadComboBox("< Seleccionar Reporte >");

            Boolean _inicio = true;
            for (int _anio = 2015; _anio <= Presenter.Session.Fecha.Year; _anio++)
            {
               if (_inicio)
               { cmbREPO_Anio.AddComboBoxItem(_anio, _anio.ToString(), true); }
               else
               { cmbREPO_Anio.AddComboBoxItem(_anio, _anio.ToString()); }
               _inicio = false;
            }

            cmbREPO_Anio.LoadComboBox("< Seleccionar Año >", ListSortDirection.Ascending);
            cmbREPO_Anio.ComboIntSelectedValue = Presenter.Session.Fecha.Year;

            cmbCONS_CodRGM.ConstantesSelectedValue = Presenter.CONS_CodRGM;
            cmbCONS_CodRGM.Enabled = false;

            if (Presenter.CONS_CodRGM == Delfin.Controls.variables.CONSRGM_Exportacion)
            {
                tableDatosGenerales.RowStyles[9].Height = 0;
                lblTipoFecha.Visible = false;
                cmbTipoFecha.Visible = false;
            }
            else if (Presenter.CONS_CodRGM == Delfin.Controls.variables.CONSRGM_Importacion)
            {
                tableDatosGenerales.RowStyles[9].Height = 27;
                lblTipoFecha.Visible = true;
                cmbTipoFecha.Visible = true;
            }
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error en el LoadView.", ex); }
      }

      public void ShowValidation()
      {
         try
         {
            
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error en ShowValidation.", ex); }
      }
      #endregion

      #region [ Metodos ]
      private void Cargar()
      {
         try
         {
            Boolean _isCorrect = true;
            String _mensajeError = String.Empty;

            if (!mdtREPO_FechaInicio.NSFecha.HasValue)
            { 
               _isCorrect = false;
               _mensajeError += "* Debe ingresar la Fecha Desde." + Environment.NewLine;
            }
            if (!mdtREPO_FechaTermino.NSFecha.HasValue)
            {
               _isCorrect = false;
               _mensajeError += "* Debe ingresar la Fecha hasta." + Environment.NewLine;
            }
            if (Presenter.CONS_CodRGM == Delfin.Controls.variables.CONSRGM_Importacion)
            {
                if (cmbTipoFecha.ComboSelectedItem == null)
                {
                    _isCorrect = false;
                    _mensajeError += "* Debe seleccionar un Tipo de Fecha" + Environment.NewLine;
                }
            }
            if (cmbCCOT_CodFLE.ComboSelectedItem == null && !chkServicioTransmision.Checked)
            {
                _isCorrect = false;
                _mensajeError += "* Debe seleccionar una condición de embarque como mínimo.";
            }

            if (_isCorrect)
            {
               ObservableCollection<Infrastructure.Aspect.DataAccess.DataAccessFilterSQL> _filters = new ObservableCollection<Infrastructure.Aspect.DataAccess.DataAccessFilterSQL>();

               Int16 _EMPR_Codigo = Delfin.Controls.Entorno.ItemEmpresa.EMPR_Codigo;
               Int16 _SUCR_Codigo = Delfin.Controls.Entorno.ItemSucursal.SUCR_Codigo;
               _filters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@psinEMPR_Codigo", FilterValue = _EMPR_Codigo, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.Int16, FilterSize = 2 });
               _filters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@psinSUCR_Codigo", FilterValue = _SUCR_Codigo, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.Int16, FilterSize = 2 });

               String _CONS_TabLNG = null;
               String _CONS_CodLNG = null;
               if (cmbCONS_CodLNG.ConstantesSelectedItem != null)
               {
                  _CONS_TabLNG = cmbCONS_CodLNG.ConstantesSelectedItem.CONS_CodTabla;
                  _CONS_CodLNG = cmbCONS_CodLNG.ConstantesSelectedItem.CONS_CodTipo;
               }
               _filters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@pchrCONS_TabLNG", FilterValue = _CONS_TabLNG, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.Char, FilterSize = 3 });
               _filters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@pchrCONS_CodLNG", FilterValue = _CONS_CodLNG, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.Char, FilterSize = 3 });

               String _CONS_TabRGM = null;
               String _CONS_CodRGM = null;
               if (cmbCONS_CodRGM.ConstantesSelectedItem != null)
               {
                  _CONS_TabRGM = cmbCONS_CodRGM.ConstantesSelectedItem.CONS_CodTabla;
                  _CONS_CodRGM = cmbCONS_CodRGM.ConstantesSelectedItem.CONS_CodTipo;
               }
               _filters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@pchrCONS_TabRGM", FilterValue = _CONS_TabRGM, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.Char, FilterSize = 3 });
               _filters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@pchrCONS_CodRGM", FilterValue = _CONS_CodRGM, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.Char, FilterSize = 3 });

               String _CONS_TabVIA = null;
               String _CONS_CodVIA = null;
               if (cmbCONS_CodVia.ConstantesSelectedItem != null)
               {
                  _CONS_TabVIA = cmbCONS_CodVia.ConstantesSelectedItem.CONS_CodTabla;
                  _CONS_CodVIA = cmbCONS_CodVia.ConstantesSelectedItem.CONS_CodTipo;
               }
               _filters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@pchrCONS_TabVIA", FilterValue = _CONS_TabVIA, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.Char, FilterSize = 3 });
               _filters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@pchrCONS_CodVIA", FilterValue = _CONS_CodVIA, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.Char, FilterSize = 3 });

               Nullable<Int32> _ENTC_CodCliente = null;
               if (txaENTC_CodCliente.Value != null)
               { _ENTC_CodCliente = txaENTC_CodCliente.Value.ENTC_Codigo; }
               _filters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@pintENTC_CodCliente", FilterValue = _ENTC_CodCliente, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.Int32, FilterSize = 4 });

               Nullable<Int32> _ENTC_CodAgente = null;
               if (txaENTC_CodAgente.Value != null)
               { _ENTC_CodAgente = txaENTC_CodAgente.Value.ENTC_Codigo; }
               _filters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@pintENTC_CodAgente", FilterValue = _ENTC_CodAgente, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.Int32, FilterSize = 4 });

               Nullable<Int32> _ENTC_CodEjecutivo = null;
               if (txaENTC_CodEjecutivo.Value != null)
               { _ENTC_CodEjecutivo = txaENTC_CodEjecutivo.Value.ENTC_Codigo; }
               _filters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@pintENTC_CodEjecutivo", FilterValue = _ENTC_CodEjecutivo, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.Int32, FilterSize = 4 });

               Nullable<Int32> _ENTC_CodTransportista = null;
               if (txaENTC_CodTransportista.Value != null)
               { _ENTC_CodTransportista = txaENTC_CodTransportista.Value.ENTC_Codigo; }
               _filters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@pintENTC_CodTransportista", FilterValue = _ENTC_CodTransportista, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.Int32, FilterSize = 4 });

               String _TIPO_TabPAIOrigen = null;
               String _TIPO_CodPAIOrigen = null;
               if (cmbTIPO_CodPAIOrigen.TiposSelectedItem != null)
               {
                  _TIPO_TabPAIOrigen = cmbTIPO_CodPAIOrigen.TiposSelectedItem.TIPO_CodTabla;
                  _TIPO_CodPAIOrigen = cmbTIPO_CodPAIOrigen.TiposSelectedItem.TIPO_CodTipo;
               }
               _filters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@pchrTIPO_TabPAIOrigen", FilterValue = _TIPO_TabPAIOrigen, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.Char, FilterSize = 3 });
               _filters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@pchrTIPO_CodPAIOrigen", FilterValue = _TIPO_CodPAIOrigen, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.Char, FilterSize = 3 });

               Nullable<Int32> _PUER_CodOrigen = null;
               if (txaPUER_CodOrigen.SelectedItem != null)
               { _PUER_CodOrigen = txaPUER_CodOrigen.SelectedItem.PUER_Codigo; }
               _filters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@pintPUER_CodOrigen", FilterValue = _PUER_CodOrigen, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.Int32, FilterSize = 4 });

               String _TIPO_TabPAIDestino = null;
               String _TIPO_CodPAIDestino = null;
               if (cmbTIPO_CodPAIDestino.TiposSelectedItem != null)
               {
                  _TIPO_TabPAIDestino = cmbTIPO_CodPAIDestino.TiposSelectedItem.TIPO_CodTabla;
                  _TIPO_CodPAIDestino = cmbTIPO_CodPAIDestino.TiposSelectedItem.TIPO_CodTipo;
               }
               _filters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@pchrTIPO_TabPAIDestino", FilterValue = _TIPO_TabPAIDestino, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.Char, FilterSize = 3 });
               _filters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@pchrTIPO_CodPAIDestino", FilterValue = _TIPO_CodPAIDestino, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.Char, FilterSize = 3 });

               Nullable<Int32> _PUER_CodDestino = null;
               if (txaPUER_CodDestino.SelectedItem != null)
               { _PUER_CodDestino = txaPUER_CodDestino.SelectedItem.PUER_Codigo; }
               _filters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@pintPUER_CodDestino", FilterValue = _PUER_CodDestino, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.Int32, FilterSize = 4 });

               String _CONS_TabFLE001 = null;
               String _CONS_CodFLE001 = null;
               if (cmbCCOT_CodFLE.ComboSelectedItem == null || cmbCCOT_CodFLE.ComboIntSelectedValue == 2 || chkServicioTransmision.Checked)  
               {
                  _CONS_TabFLE001 = "FLE";
                  _CONS_CodFLE001 = "001";
               }
               _filters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@pchrCONS_TabFLE001", FilterValue = _CONS_TabFLE001, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.Char, FilterSize = 3 });
               _filters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@pchrCONS_CodFLE001", FilterValue = _CONS_CodFLE001, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.Char, FilterSize = 3 });

               String _CONS_TabFLE002 = null;
               String _CONS_CodFLE002 = null;
               if (cmbCCOT_CodFLE.ComboSelectedItem == null || cmbCCOT_CodFLE.ComboIntSelectedValue == 1 || chkServicioTransmision.Checked)  
               {
                  _CONS_TabFLE002 = "FLE";
                  _CONS_CodFLE002 = "002";
               }
               _filters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@pchrCONS_TabFLE002", FilterValue = _CONS_TabFLE002, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.Char, FilterSize = 3 });
               _filters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@pchrCONS_CodFLE002", FilterValue = _CONS_CodFLE002, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.Char, FilterSize = 3 });

               String _CONS_TabFLE003 = null;
               String _CONS_CodFLE003 = null;
               if (cmbCCOT_CodFLE.ComboSelectedItem == null || cmbCCOT_CodFLE.ComboIntSelectedValue == 2 || chkServicioTransmision.Checked)  
               {
                  _CONS_TabFLE003 = "FLE";
                  _CONS_CodFLE003 = "003";
               }
               _filters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@pchrCONS_TabFLE003", FilterValue = _CONS_TabFLE003, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.Char, FilterSize = 3 });
               _filters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@pchrCONS_CodFLE003", FilterValue = _CONS_CodFLE003, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.Char, FilterSize = 3 });

               String _CONS_TabFLE004 = null;
               String _CONS_CodFLE004 = null;
               if (cmbCCOT_CodFLE.ComboSelectedItem == null || cmbCCOT_CodFLE.ComboIntSelectedValue == 1 || chkServicioTransmision.Checked)  
               {
                  _CONS_TabFLE004 = "FLE";
                  _CONS_CodFLE004 = "004";
               }
               _filters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@pchrCONS_TabFLE004", FilterValue = _CONS_TabFLE004, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.Char, FilterSize = 3 });
               _filters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@pchrCONS_CodFLE004", FilterValue = _CONS_CodFLE004, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.Char, FilterSize = 3 });

               DateTime _REPO_FechaInicio = mdtREPO_FechaInicio.NSFecha.Value;
               _filters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@pdtmREPO_FechaInicio", FilterValue = _REPO_FechaInicio, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.DateTime, FilterSize = 8 });
               DateTime _REPO_FechaTermino = mdtREPO_FechaTermino.NSFecha.Value;
               _filters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@pdtmREPO_FechaTermino", FilterValue = _REPO_FechaTermino, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.DateTime, FilterSize = 8 });


               _filters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@pbtiCCOT_MostarRebate", FilterValue = chkMostrarRebate.Checked, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.Boolean, FilterSize = 1 });
               _filters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@pbtiCCOT_ServicioTransmision", FilterValue = chkServicioTransmision.Checked, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.Boolean, FilterSize = 1 });

               if (Presenter.CONS_CodRGM == Delfin.Controls.variables.CONSRGM_Exportacion)
               {
                   _filters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@pintTipoFecha", FilterValue = TipoFecha.FechaExportacion, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.Int32, FilterSize = 2 });
               }
               else if (Presenter.CONS_CodRGM == Delfin.Controls.variables.CONSRGM_Importacion)
               {
                   _filters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@pintTipoFecha", FilterValue = cmbTipoFecha.ComboIntSelectedValue, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.Int32, FilterSize = 2 });
               }


               Presenter.Cargar(_filters, _REPO_FechaInicio, _REPO_FechaTermino, chkMostrarRebate.Checked, chkServicioTransmision.Checked, cmbCCOT_CodFLE.ComboIntSelectedValue);
            }
            else
            { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Presenter.Title, "Faltan datos obligatorios revise los detalles.", _mensajeError); }
         }
         catch (Exception)
         { }
      }
      #endregion

      #region [ Metodos Linea Negocio ]
      private void EstablecerLineaNegocio()
      {
         try
         {
            cmbCONS_CodLNG.SelectedIndexChanged -= cmbCONS_CodLNG_SelectedIndexChanged;

            cmbCONS_CodLNG.ConstantesSelectedValue = null;

            if (cmbCONS_CodRGM.ConstantesSelectedItem != null)
            {
               if (cmbCONS_CodRGM.ConstantesSelectedItem.CONS_CodTipo == Delfin.Controls.variables.CONSRGM_Exportacion)
               { cmbCONS_CodLNG.ConstantesSelectedValue = Delfin.Controls.variables.CONSLNG_Exportacion; }
               else if (cmbCONS_CodRGM.ConstantesSelectedItem.CONS_CodTipo == Delfin.Controls.variables.CONSRGM_Importacion)
               {
                  if (txaENTC_CodAgente.Value != null && txaPUER_CodOrigen.SelectedItem != null)
                  {
                     Boolean _validacionAgente = (Presenter.PARA_EAGENTE_SHANGHAI != null && txaENTC_CodAgente.Value.ENTC_Codigo == Presenter.PARA_EAGENTE_SHANGHAI.PARA_IntValor);
                     //Boolean _validacionPuerto = (Presenter.PARA_PAIS_MANDATO != null && txaPUER_CodOrigen.SelectedItem.TIPO_CodPais == Presenter.PARA_PAIS_MANDATO.PARA_Valor);
                     if (_validacionAgente) //&& _validacionPuerto
                     { cmbCONS_CodLNG.ConstantesSelectedValue = Delfin.Controls.variables.CONSLNG_Mandato; }
                     else
                     { cmbCONS_CodLNG.ConstantesSelectedValue = Delfin.Controls.variables.CONSLNG_OtrosTraficos; }
                  }
               }
            }

            cmbCONS_CodLNG.SelectedIndexChanged += cmbCONS_CodLNG_SelectedIndexChanged;
         }
         catch (Exception)
         { }
      }
      private void SetLineaNegocio()
      {
         try
         {
            cmbCONS_CodRGM.SelectedIndexChanged -= cmbCONS_CodRGM_SelectedIndexChanged;
            txaENTC_CodAgente.AyudaValueChanged -= txaENTC_CodAgente_AyudaValueChanged;
            cmbTIPO_CodPAIOrigen.SelectedIndexChanged -= cmbTIPO_CodPAIOrigen_SelectedIndexChanged;

            if (cmbCONS_CodLNG.ConstantesSelectedItem != null && !String.IsNullOrEmpty(cmbCONS_CodLNG.ConstantesSelectedItem.CONS_CodTipo))
            {
               switch (cmbCONS_CodLNG.ConstantesSelectedItem.CONS_CodTipo)
               {
                  case Delfin.Controls.variables.CONSLNG_Mandato:
                     cmbCONS_CodRGM.ConstantesSelectedValue = Delfin.Controls.variables.CONSRGM_Importacion;
                     cmbCONS_CodRGM.Enabled = false;
                     //txaENTC_CodAgente.SetValue(Presenter.PARA_EAGENTE_SHANGHAI.PARA_IntValor);
                     txaENTC_CodAgente.Enabled = false;
                     //cmbTIPO_CodPAIOrigen.TiposSelectedValue = Presenter.PARA_PAIS_MANDATO.PARA_Valor;
                     //cmbTIPO_CodPAIOrigen.Enabled = false;
                     break;
                  case Delfin.Controls.variables.CONSLNG_Exportacion:
                     cmbCONS_CodRGM.ConstantesSelectedValue = Delfin.Controls.variables.CONSRGM_Exportacion;
                     cmbCONS_CodRGM.Enabled = false;
                     txaENTC_CodAgente.ClearValue();
                     txaENTC_CodAgente.Enabled = true;
                     //cmbTIPO_CodPAIOrigen.TiposSelectedValue = null;
                     //cmbTIPO_CodPAIOrigen.Enabled = true;
                     break;
                  case Delfin.Controls.variables.CONSLNG_OtrosTraficos:
                     cmbCONS_CodRGM.ConstantesSelectedValue = Delfin.Controls.variables.CONSRGM_Importacion;
                     cmbCONS_CodRGM.Enabled = false;
                     txaENTC_CodAgente.ClearValue();
                     txaENTC_CodAgente.Enabled = true;
                     //cmbTIPO_CodPAIOrigen.TiposSelectedValue = null;
                     //cmbTIPO_CodPAIOrigen.Enabled = true;
                     break;
                  //case Delfin.Controls.variables.CONSLNG_Mandato:
                  //   break;
               }
            }
            else
            {
               //cmbCONS_CodRGM.ConstantesSelectedValue = null;
               //cmbCONS_CodRGM.Enabled = true;
               txaENTC_CodAgente.ClearValue();
               txaENTC_CodAgente.Enabled = true;
               //cmbTIPO_CodPAIOrigen.TiposSelectedValue = null;
               //cmbTIPO_CodPAIOrigen.Enabled = true;
            }


            cmbCONS_CodRGM.SelectedIndexChanged += cmbCONS_CodRGM_SelectedIndexChanged;
            txaENTC_CodAgente.AyudaValueChanged += txaENTC_CodAgente_AyudaValueChanged;
            cmbTIPO_CodPAIOrigen.SelectedIndexChanged += cmbTIPO_CodPAIOrigen_SelectedIndexChanged;
         }
         catch (Exception)
         { }
      }
      #endregion

      #region [ Eventos ]
      private void btnCargar_Click(object sender, EventArgs e)
      {
         try
         {
            //if (cmbREPO_Gerencia.ComboIntSelectedValue.HasValue)
            //{
            //   if (cmbREPO_Anio.ComboIntSelectedValue.HasValue)
            //   {
                  //Presenter.Cargar(cmbREPO_Gerencia.ComboIntSelectedValue.Value, cmbREPO_Anio.ComboIntSelectedValue.Value);
                  Cargar();
            //   }
            //   else
            //   { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Presenter.Title, "Debe seleccionar el Año."); }
            //}
            //else
            //{ Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Presenter.Title, "Debe seleccionar el Reporte."); }
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al guardar el formulario.", ex); }
      }
      private void btnSalir_Click(object sender, EventArgs e)
      {
         try
         {
            this.Close();
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al cerrar el formulario.", ex); }
      }

      private void cmbCONS_CodLNG_SelectedIndexChanged(object sender, EventArgs e)
      {
         try
         {
            SetLineaNegocio();
         }
         catch (Exception) { }
      }
      private void cmbCONS_CodRGM_SelectedIndexChanged(object sender, EventArgs e)
      { EstablecerLineaNegocio(); }
      private void txaENTC_CodAgente_AyudaValueChanged(object sender, EventArgs e)
      { EstablecerLineaNegocio(); }
      private void cmbTIPO_CodPAIOrigen_SelectedIndexChanged(object sender, EventArgs e)
      { 
         //EstablecerLineaNegocio(); 
      }
      #endregion
   }
}