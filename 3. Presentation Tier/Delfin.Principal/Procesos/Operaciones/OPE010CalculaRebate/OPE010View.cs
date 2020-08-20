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
   public partial class OPE010View : Form, IOPE010View
   {
      #region [ Variables ]

      #endregion

      #region [ Formulario ]
      public OPE010View()
      {
         InitializeComponent();
         try
         {
            btnCalcular.Click += btnCalcular_Click;
            btnSalir.Click += btnSalir_Click;
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error inicializando el formulario MView.", ex); }
      }
      #endregion

      #region [ Propiedades ]
      public OPE010Presenter Presenter { get; set; }
      #endregion

      #region [ IOPE002MView ]
      public void LoadView()
      {
         try
         {
            this.Limpiar();
            ayudaENTC_CodCliente.ContainerService = Presenter.ContainerService;
            ayudaENTC_CodCliente.TipoEntidad = Delfin.Controls.TiposEntidad.TIPE_Cliente;
            ayudaENTC_CodTransportista.ContainerService = Presenter.ContainerService;
            ayudaENTC_CodTransportista.TipoEntidad = Delfin.Controls.TiposEntidad.TIPE_Transportista;

            cmbREBA_Tipo.AddComboBoxItem("R", "Rebate", true);
            cmbREBA_Tipo.AddComboBoxItem("G", "GRR");
            cmbREBA_Tipo.LoadComboBox("< Seleccionar Tipo >");
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error en el LoadView.", ex); }
      }
      #endregion

      #region [ Metodos ]
      private void Calcular()
      {
         try
         {
            //Nullable<DateTime> _fec_ini_embarque = null;
            //Nullable<DateTime> _fec_fin_embarque = null;
            //Nullable<DateTime> _fec_ini_llegada = null;
            //Nullable<DateTime> _fec_fin_llegada = null;
            //Nullable<DateTime> _fec_ini_tarifa = null;
            //Nullable<DateTime> _fec_fin_tarifa = null;
            //Nullable<Int32> _codigo_cliente = null;
            //Int32 _codigo_linea;
            //String _numero_hbl = null;
            //String _numero_ov = null;
            String _tipo = null;

            if (!String.IsNullOrEmpty(cmbREBA_Tipo.ComboStrSelectedValue))
            {
               if (ayudaENTC_CodTransportista.Value != null)
               {
                  if ((mdtNVIA_FechaIniEmbarque.NSFecha != null && mdtNVIA_FechaFinEmbarque.NSFecha != null) || (mdtNVIA_FechaIniLlegada.NSFecha != null && mdtNVIA_FechaFinLlegada.NSFecha != null) || (mdtREBA_FecIniTarifa.NSFecha != null && mdtREBA_FecFinTarifa.NSFecha != null))
                  {
                     _tipo = cmbREBA_Tipo.ComboStrSelectedValue;
                     ObservableCollection<Infrastructure.Aspect.DataAccess.DataAccessFilterSQL> _filters = new ObservableCollection<Infrastructure.Aspect.DataAccess.DataAccessFilterSQL>();
                     _filters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@pintENTC_CodTransportista", FilterValue = ayudaENTC_CodTransportista.Value.ENTC_Codigo, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.Int32, FilterSize = 4 });
                     //_codigo_linea = ayudaENTC_CodTransportista.Value.ENTC_Codigo;

                     if (ayudaENTC_CodCliente.Value != null)
                     { 
                        //_codigo_cliente = ayudaENTC_CodCliente.Value.ENTC_Codigo;
                        _filters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@pintENTC_CodCliente", FilterValue = ayudaENTC_CodCliente.Value.ENTC_Codigo, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.Int32, FilterSize = 4 });
                     }
                     if (mdtNVIA_FechaIniEmbarque.NSFecha != null)
                     {
                        //_fec_ini_embarque = mdtNVIA_FechaIniEmbarque.NSFecha.Value;
                        _filters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@pdtmDDOV_FecEmbarqueIni", FilterValue = mdtNVIA_FechaIniEmbarque.NSFecha.Value, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.DateTime, FilterSize = 8 });
                     }
                     if (mdtNVIA_FechaFinEmbarque.NSFecha != null)
                     { 
                        //_fec_fin_embarque = mdtNVIA_FechaFinEmbarque.NSFecha.Value;
                        _filters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@pdtmDDOV_FecEmbarqueFin", FilterValue = mdtNVIA_FechaFinEmbarque.NSFecha.Value, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.DateTime, FilterSize = 8 });
                     }
                     if (mdtNVIA_FechaIniLlegada.NSFecha != null)
                     { 
                        //_fec_ini_llegada = mdtNVIA_FechaIniLlegada.NSFecha.Value;
                        _filters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@pdtmNVIA_FecLlegadaIni", FilterValue = mdtNVIA_FechaIniLlegada.NSFecha.Value, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.DateTime, FilterSize = 8 });
                     }
                     if (mdtNVIA_FechaFinLlegada.NSFecha != null)
                     { 
                        //_fec_fin_llegada = mdtNVIA_FechaFinLlegada.NSFecha.Value;
                        _filters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@pdtmNVIA_FecLlegadaFin", FilterValue = mdtNVIA_FechaFinLlegada.NSFecha.Value, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.DateTime, FilterSize = 8 });
                     }
                     if (mdtREBA_FecIniTarifa.NSFecha != null)
                     { 
                        //_fec_ini_tarifa = mdtREBA_FecIniTarifa.NSFecha.Value;
                        _filters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@pdtmCCOT_FecTarifaIni", FilterValue = mdtREBA_FecIniTarifa.NSFecha.Value, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.DateTime, FilterSize = 8 });
                     }
                     if (mdtREBA_FecFinTarifa.NSFecha != null)
                     { 
                        //_fec_fin_tarifa = mdtREBA_FecFinTarifa.NSFecha.Value;
                        _filters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@pdtmCCOT_FecTarifaFin", FilterValue = mdtREBA_FecFinTarifa.NSFecha.Value, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.DateTime, FilterSize = 8 });
                     }

                     if (!String.IsNullOrEmpty(txtNroHBL.Text))
                     { 
                        //_numero_hbl = txtNroHBL.Text;
                        _filters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@pvchDOOV_HBL", FilterValue = txtNroHBL.Text, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.Varchar, FilterSize = 50 });
                     }
                     if (!String.IsNullOrEmpty(txtNroOV.Text))
                     { 
                        //_numero_ov = txtNroOV.Text;
                        _filters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@pvchCCOT_NumDoc", FilterValue = txtNroOV.Text, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.Varchar, FilterSize = 20 });
                     }
                     
                     Presenter.CalcularRebate(_tipo, _filters);
                  }
                  else
                  {
                     Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Presenter.Title, "Debe ingresar un rango de fechas como mínimo (Fec. ETA ó Fec. Embarque");
                  }
               }
               else
               { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Presenter.Title, "Debe escoger un Transportista."); }
            }
            else
            { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Presenter.Title, "Debe seleccionar de Tipo."); }
         }
         catch (Exception ex)
         { throw ex; }
      }
      private void Limpiar()
      {
         try
         {
            ayudaENTC_CodTransportista.ClearValue();
            ayudaENTC_CodTransportista.Text = string.Empty;
            mdtNVIA_FechaIniEmbarque.NSFecha = null;
            mdtNVIA_FechaFinEmbarque.NSFecha = null;
            mdtNVIA_FechaIniLlegada.NSFecha = null;
            mdtNVIA_FechaFinLlegada.NSFecha = null;
            ayudaENTC_CodCliente.ClearValue();
            ayudaENTC_CodCliente.Text = string.Empty;
            txtNroHBL.Text = string.Empty;
            txtNroOV.Text = string.Empty;
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al limpiar al reporte.", ex); }
      }
      #endregion

      #region [ Metodos Documentos ]

      #endregion

      #region [ Eventos ]
      private void btnCalcular_Click(object sender, EventArgs e)
      {
         try
         {
            this.Calcular();
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al calcular el Rebate.", ex); }
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
      #endregion

   }
}