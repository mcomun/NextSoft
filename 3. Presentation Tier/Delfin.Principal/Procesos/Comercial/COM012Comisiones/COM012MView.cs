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
   public partial class COM012MView : Form, ICOM012MView
   {
      #region [ Variables ]

      #endregion

      #region [ Formulario ]
      public COM012MView()
      {
         InitializeComponent();
         try
         {
            btnProcesar.Click += btnProcesar_Click;
            btnSalir.Click += btnSalir_Click;

             txaNVIA_Codigo.AyudaValueChanged +=txaNVIA_Codigo_AyudaValueChanged;
             txaNVIA_NroViaje.AyudaValueChanged += txaNVIA_NroViaje_AyudaValueChanged;

            this.Load += OPE001RView_Load;
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error inicializando el formulario MView.", ex); }
      }

      private void OPE001RView_Load(object sender, EventArgs e)
      {
         
      }
      #endregion

      #region [ Propiedades ]
      public COM012Presenter Presenter { get; set; }
      #endregion

      #region [ ICOM012MView ]
      public void LoadView()
      {
         try
         {
            ayudaENTC_CodEjecutivo.ContainerService = Presenter.ContainerService;
            ayudaENTC_CodEjecutivo.TipoEntidad = Delfin.Controls.TiposEntidad.TIPE_Ejecutivo;


            txaNVIA_Codigo.LoadControl(Presenter.ContainerService);
            txaNVIA_NroViaje.LoadControl(Presenter.ContainerService);
            cmbTIPO_CodTRF.LoadControl(Presenter.ContainerService, "Tipos de Tráfico", "TRF", "< Seleccionar Tráfico >", ListSortDirection.Ascending);
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
      private void ClearDatosViaje()
      {
         try
         {
            txaNVIA_Codigo.AyudaValueChanged -= txaNVIA_Codigo_AyudaValueChanged;
            txaNVIA_NroViaje.AyudaValueChanged -= txaNVIA_NroViaje_AyudaValueChanged;

            txaNVIA_Codigo.ClearValue();
            txaNVIA_NroViaje.ClearValue();
            txtNAVE_Nombre.Text = String.Empty;
            txtENTC_NomTransportista.Text = string.Empty;
            cmbTIPO_CodTRF.TiposSelectedValue = null;

            txaNVIA_Codigo.AyudaValueChanged += txaNVIA_Codigo_AyudaValueChanged;
            txaNVIA_NroViaje.AyudaValueChanged += txaNVIA_NroViaje_AyudaValueChanged;
         }
         catch (Exception)
         { }
      }
      private void SetDatosViaje(Entities.NaveViaje ItemViaje)
      {
         try
         {
            txaNVIA_Codigo.AyudaValueChanged -= txaNVIA_Codigo_AyudaValueChanged;
            txaNVIA_NroViaje.AyudaValueChanged -= txaNVIA_NroViaje_AyudaValueChanged;

            txaNVIA_Codigo.LoadNaveViaje(ItemViaje.NVIA_Codigo);
            txaNVIA_NroViaje.LoadNaveViaje(ItemViaje.NVIA_Codigo);
            txtNAVE_Nombre.Text = ItemViaje.NAVE_Nombre;
            txtENTC_NomTransportista.Text = ItemViaje.ENTC_NomTransportista;
            cmbTIPO_CodTRF.TiposSelectedValue = ItemViaje.TIPO_CodTRF;

            txaNVIA_Codigo.AyudaValueChanged += txaNVIA_Codigo_AyudaValueChanged;
            txaNVIA_NroViaje.AyudaValueChanged += txaNVIA_NroViaje_AyudaValueChanged;
         }
         catch (Exception)
         { } 
      }

      private void Procesar()
      {
         try
         {
            Boolean _tieneFiltro = false;

            //if (txaNVIA_NroViaje.Value != null && txaNVIA_NroViaje.Value is Entities.NaveViaje) { _tieneFiltro = true; }

            ObservableCollection<Infrastructure.Aspect.DataAccess.DataAccessFilterSQL> _filters = new ObservableCollection<Infrastructure.Aspect.DataAccess.DataAccessFilterSQL>();

            if (mdtNVIA_FechaIniEmbarque.NSFecha != null && mdtNVIA_FechaFinEmbarque.NSFecha != null) { _tieneFiltro = true; }
            if (mdtNVIA_FechaIniLlegada.NSFecha != null && mdtNVIA_FechaFinLlegada.NSFecha != null) { _tieneFiltro = true; }


            Int16 _EMPR_Codigo = Delfin.Controls.Entorno.ItemEmpresa.EMPR_Codigo;
            Int16 _SUCR_Codigo = Delfin.Controls.Entorno.ItemSucursal.SUCR_Codigo;
            _filters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@psinEMPR_Codigo", FilterValue = _EMPR_Codigo, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.Int16, FilterSize = 2 });
            _filters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@psinSUCR_Codigo", FilterValue = _SUCR_Codigo, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.Int16, FilterSize = 2 });

            if (mdtNVIA_FechaIniEmbarque.NSFecha != null) { _filters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@pdtmDDOV_FecEmbarqueIni", FilterValue = mdtNVIA_FechaIniEmbarque.NSFecha.Value, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.DateTime, FilterSize = 8 }); }
            if (mdtNVIA_FechaFinEmbarque.NSFecha != null) { _filters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@pdtmDDOV_FecEmbarqueFin", FilterValue = mdtNVIA_FechaFinEmbarque.NSFecha.Value, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.DateTime, FilterSize = 8 }); }
            if (mdtNVIA_FechaIniLlegada.NSFecha != null) { _filters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@pdtmNVIA_FecLlegadaIni", FilterValue = mdtNVIA_FechaIniLlegada.NSFecha.Value, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.DateTime, FilterSize = 8 }); }
            if (mdtNVIA_FechaFinLlegada.NSFecha != null) { _filters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@pdtmNVIA_FecLlegadaFin", FilterValue = mdtNVIA_FechaFinLlegada.NSFecha.Value, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.DateTime, FilterSize = 8 }); }
            if (ayudaENTC_CodEjecutivo.Value != null) { _filters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@pintENTC_CodEjecutivo", FilterValue = ayudaENTC_CodEjecutivo.Value.ENTC_Codigo, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.Int32, FilterSize = 4 }); }

            _filters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@pvchAUDI_Usuario", FilterValue = Presenter.Session.UserName, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.Varchar, FilterSize = 20 });

            if (_tieneFiltro)
            { Presenter.Procesar(_filters); /*((txaNVIA_Codigo.Value as Entities.NaveViaje).NVIA_Codigo);*/ }
            else
            { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Presenter.Title, "Debe ingresar un rango de Fechas de Embarque o de ETA"); }
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al guardar el formulario.", ex); }
      }
      #endregion

      #region [ Metodos Documentos ]
     
      #endregion

      #region [ Eventos ]
      private void btnProcesar_Click(object sender, EventArgs e)
      {
         Procesar();  
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

      private void txaNVIA_NroViaje_AyudaValueChanged(object sender, EventArgs e)
      {
         if (txaNVIA_NroViaje.Value != null && txaNVIA_NroViaje.Value is Entities.NaveViaje)
         { SetDatosViaje(txaNVIA_NroViaje.Value as Entities.NaveViaje); }
         else
         { ClearDatosViaje(); }
      }
      private void txaNVIA_Codigo_AyudaValueChanged(object sender, EventArgs e)
      {
         if (txaNVIA_Codigo.Value != null && txaNVIA_Codigo.Value is Entities.NaveViaje)
         { SetDatosViaje(txaNVIA_Codigo.Value as Entities.NaveViaje); }
         else
         { ClearDatosViaje(); }
      }
      #endregion
   }
} 