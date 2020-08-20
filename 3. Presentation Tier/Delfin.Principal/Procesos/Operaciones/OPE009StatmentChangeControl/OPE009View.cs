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
   public partial class OPE009View : Form, IOPE009View
   {
      #region [ Variables ]

      #endregion

      #region [ Formulario ]
      public OPE009View()
      {
         InitializeComponent();
         try
         {
            btnCargar.Click += btnCargar_Click;
            btnSalir.Click += btnSalir_Click;

            cmbCONS_CodLNG.SelectedIndexChanged += cmbCONS_CodLNG_SelectedIndexChanged;
            cmbCONS_CodRGM.SelectedIndexChanged += cmbCONS_CodRGM_SelectedIndexChanged;
            //txaENTC_CodAgente.AyudaValueChanged += txaENTC_CodAgente_AyudaValueChanged;
            txaNVIA_Codigo.AyudaValueChanged += txaNVIA_Codigo_AyudaValueChanged;

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
      public OPE009Presenter Presenter { get; set; }
      #endregion

      #region [ IOPE009View ]
      public void LoadView()
      {
         try
         {
            txaNVIA_Codigo.LoadControl(Presenter.ContainerService, Delfin.Controls.AyudaViaje.TipoAyuda.Codigo);
            txaENTC_CodCliente.ContainerService = Presenter.ContainerService;
            txaENTC_CodCliente.TipoEntidad = Delfin.Controls.TiposEntidad.TIPE_Cliente;
            txaENTC_CodAgente.ContainerService = Presenter.ContainerService;
            txaENTC_CodAgente.TipoEntidad = Delfin.Controls.TiposEntidad.TIPE_Agente;
            txaENTC_CodTransportista.ContainerService = Presenter.ContainerService;
            txaENTC_CodTransportista.TipoEntidad = Delfin.Controls.TiposEntidad.TIPE_Transportista;
            
            cmbCONS_CodRGM.LoadControl(Presenter.ContainerService, "Constantes Régimen", "RGM", "< Seleccionar Régimen >", ListSortDirection.Ascending);
            cmbCONS_CodVia.LoadControl(Presenter.ContainerService, "Constantes Vía", "VIA", "< Seleccionar Vía >", ListSortDirection.Ascending);
            
            cmbCONS_CodLNG.LoadControl(Presenter.ContainerService, "Constantes Línea de Negocio", "LNG", null, ListSortDirection.Ascending);
            ObservableCollection<Entities.Constantes> _listLNG;
            //if (Presenter.CONS_CodRGM == "001")
            //{ 
            //   _listLNG = new ObservableCollection<Entities.Constantes>((cmbCONS_CodLNG.DataSource as ObservableCollection<Entities.Constantes>).Where(lng => lng.CONS_CodTipo != Delfin.Controls.variables.CONSLNG_Exportacion && lng.CONS_CodTipo != Delfin.Controls.variables.CONSLNG_SLI));
            //   cmbCONS_CodLNG.LoadControl(_listLNG, "Constantes Línea de Negocio", "LNG", "< Seleccionar Línea de Negocio >", ListSortDirection.Ascending);
            //}
            //else
            //{ 
            //   _listLNG = new ObservableCollection<Entities.Constantes>((cmbCONS_CodLNG.DataSource as ObservableCollection<Entities.Constantes>).Where(lng => lng.CONS_CodTipo == Delfin.Controls.variables.CONSLNG_Exportacion && lng.CONS_CodTipo != Delfin.Controls.variables.CONSLNG_SLI));
            //   cmbCONS_CodLNG.LoadControl(_listLNG, "Constantes Línea de Negocio", "LNG", null, ListSortDirection.Ascending);
            //}
            
            //cmbCONS_CodRGM.ConstantesSelectedValue = Presenter.CONS_CodRGM;
            cmbCONS_CodRGM.Enabled = false;
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
               _mensajeError = "* Debe ingresar la Fecha Desde.";
            }
            if (!mdtREPO_FechaTermino.NSFecha.HasValue)
            {
               _isCorrect = false;
               _mensajeError = "* Debe ingresar la Fecha hasta.";
            }
            //if (!(chkCONS_CodFLE001.Checked || chkCONS_CodFLE002.Checked || chkCONS_CodFLE003.Checked || chkCONS_CodFLE004.Checked))
            //{
            //   _isCorrect = false;
            //   _mensajeError = "* Debe marcar una condición de embarque como mínimo.";
            //}

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

               Nullable<Int32> _ENTC_CodTransportista = null;
               if (txaENTC_CodTransportista.Value != null)
               { _ENTC_CodTransportista = txaENTC_CodTransportista.Value.ENTC_Codigo; }
               _filters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@pintENTC_CodTransportista", FilterValue = _ENTC_CodTransportista, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.Int32, FilterSize = 4 });

               Nullable<Int32> _NVIA_Codigo = null;
               if (txaNVIA_Codigo.Value != null && txaNVIA_Codigo.Value is Entities.NaveViaje)
               { _NVIA_Codigo = (txaNVIA_Codigo.Value as Entities.NaveViaje).NVIA_Codigo; }
               _filters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@pintNVIA_Codigo", FilterValue = _NVIA_Codigo, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.Int32, FilterSize = 4 });

               
               DateTime _REPO_FechaInicio = mdtREPO_FechaInicio.NSFecha.Value;
               _filters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@pchrCCOT_FecEmiDesde", FilterValue = _REPO_FechaInicio, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.DateTime, FilterSize = 8 });
               DateTime _REPO_FechaTermino = mdtREPO_FechaTermino.NSFecha.Value;
               _filters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@pchrCCOT_FecEmiHasta", FilterValue = _REPO_FechaTermino, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.DateTime, FilterSize = 8 });


               

               Presenter.Cargar(_filters);
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
                  if (txaENTC_CodAgente.Value != null) //&& txaPUER_CodOrigen.SelectedItem != null
                  {
                     Boolean _validacionAgente = (Presenter.PARA_EAGENTE_SHANGHAI != null && txaENTC_CodAgente.Value.ENTC_Codigo == Presenter.PARA_EAGENTE_SHANGHAI.PARA_IntValor);
                     //Boolean _validacionPuerto = (Presenter.PARA_PAIS_MANDATO != null && txaPUER_CodOrigen.SelectedItem.TIPO_CodPais == Presenter.PARA_PAIS_MANDATO.PARA_Valor);
                     if (_validacionAgente)//&& _validacionPuerto
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
            //cmbTIPO_CodPAIOrigen.SelectedIndexChanged -= cmbTIPO_CodPAIOrigen_SelectedIndexChanged;

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
            //cmbTIPO_CodPAIOrigen.SelectedIndexChanged += cmbTIPO_CodPAIOrigen_SelectedIndexChanged;
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
      private void txaNVIA_Codigo_AyudaValueChanged(object sender, EventArgs e)
      {
         try
         {
            if (txaNVIA_Codigo.Value != null && txaNVIA_Codigo.Value is Entities.NaveViaje)
            {
               txtNVIA_NroViaje.Text = (txaNVIA_Codigo.Value as Entities.NaveViaje).NVIA_NroViaje;
               txtNAVE_Nombre.Text = (txaNVIA_Codigo.Value as Entities.NaveViaje).NAVE_Nombre;
            }
            else
            {
               txtNVIA_NroViaje.Text = null;
               txtNAVE_Nombre.Text = null;
            }
         }
         catch (Exception) { }
      }
      #endregion
   }
}