using Delfin.ServiceContracts;
using Microsoft.Practices.Unity;
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
   public partial class OPE001DView : Form
   {
      #region [ Variables ]

      #endregion

      #region [ Formulario ]
      public OPE001DView(OPE001Presenter x_Presenter, Entities.Det_Cotizacion_OV_Servicio x_ItemDetalle)
      {
         InitializeComponent();

         this.ContainerService = x_Presenter.ContainerService;
         Client = ContainerService.Resolve<IDelfinServices>();

         Presenter = x_Presenter;
         ItemDetalle = x_ItemDetalle;

         ObservableCollection<Entities.ServiciosDocumentos> _serviciosDocumento = Presenter.Client.GetAllServiciosDocumentosByServCodigo(ItemDetalle.SERV_Codigo).ToObservableCollection();

         String _movimiento = (!String.IsNullOrEmpty(ItemDetalle.CCOT_IngresoGasto) ? ItemDetalle.CCOT_IngresoGasto : null);

         if (_movimiento == "E") { _movimiento = "C"; }
         ObservableCollection<Entities.Tipos> _tiposTDO = (from tdo in Presenter.ListTiposTDO
                                                           join doc in _serviciosDocumento on tdo.TIPO_CodTipo equals doc.TIPO_CodTDO
                                                           where doc.SEDO_Tipo == _movimiento
                                                           select tdo).ToObservableCollection();

         cmbTIPO_CodTDO.LoadControl(_tiposTDO, "Tipos de Documento", "< Seleccionar Tipo Documento >", ListSortDirection.Ascending);

         if (!String.IsNullOrEmpty(ItemDetalle.TIPO_CodTDO))
         { cmbTIPO_CodTDO.TiposSelectedValue = ItemDetalle.TIPO_CodTDO; }
         else if (_tiposTDO.Count == 1)
         { cmbTIPO_CodTDO.TiposSelectedValue = _tiposTDO[0].TIPO_CodTipo; }
         else
         { cmbTIPO_CodTDO.TiposSelectedValue = null; }

         dtmSCOT_FechaEmision.NSFecha = ItemDetalle.SCOT_FechaEmision;

         txtSCOT_SerieTDO.Text = ItemDetalle.SCOT_SerieTDO;
         txtSCOT_NumeroTDO.Text = ItemDetalle.SCOT_NumeroTDO;

         btnAceptar.Click += btnAceptar_Click;
         btnCancelar.Click += btnCancelar_Click;
      }
      #endregion

      #region [ Propiedades ]
      public IUnityContainer ContainerService { get; set; }
      public IDelfinServices Client { get; set; }
      public OPE001Presenter Presenter { get; set; }
      public Entities.Det_Cotizacion_OV_Servicio ItemDetalle { get; set; }
      #endregion

      #region [ Metodos ]

      private Boolean GuardarDocumento()
      {
         try
         {
            Boolean _isCorrect = true;
            String _mensajeError = String.Empty;

            if (dtmSCOT_FechaEmision.NSFecha.HasValue)
            { ItemDetalle.SCOT_FechaEmision = dtmSCOT_FechaEmision.NSFecha.Value; }
            else
            {
               ItemDetalle.SCOT_FechaEmision = null;
               _isCorrect = false;
               _mensajeError = "* Debe seleccionar una fecha de emisión valida.";
            }

            if (cmbTIPO_CodTDO.TiposSelectedItem != null)
            {
               ItemDetalle.TIPO_TabTDO = cmbTIPO_CodTDO.TiposSelectedItem.TIPO_CodTabla;
               ItemDetalle.TIPO_CodTDO = cmbTIPO_CodTDO.TiposSelectedItem.TIPO_CodTipo;
               ItemDetalle.TIPO_DescTDO = cmbTIPO_CodTDO.TiposSelectedItem.TIPO_Desc1;

               if (Infrastructure.Aspect.Constants.Util.ValidarObligatorio_Serie(cmbTIPO_CodTDO.TiposSelectedItem.TIPO_Desc2))
               {
                  if (!String.IsNullOrEmpty(txtSCOT_SerieTDO.Text.Trim()))
                  { ItemDetalle.SCOT_SerieTDO = txtSCOT_SerieTDO.Text.Trim(); }
                  else
                  {
                     ItemDetalle.SCOT_SerieTDO = null;

                     _isCorrect = false;
                     _mensajeError = "* Debe ingresar la Serie del Documento.";
                  }
               }
               else { ItemDetalle.SCOT_SerieTDO = txtSCOT_SerieTDO.Text; }

               if (Infrastructure.Aspect.Constants.Util.ValidarObligatorio_Numero(cmbTIPO_CodTDO.TiposSelectedItem.TIPO_Desc2))
               {
                  if (!String.IsNullOrEmpty(txtSCOT_NumeroTDO.Text.Trim()))
                  { ItemDetalle.SCOT_NumeroTDO = txtSCOT_NumeroTDO.Text.Trim(); }
                  else
                  {
                     ItemDetalle.SCOT_NumeroTDO = null;

                     _isCorrect = false;
                     _mensajeError = "* Debe ingresar el Número del Documento.";
                  }
               }
               else { ItemDetalle.SCOT_NumeroTDO = txtSCOT_NumeroTDO.Text; }
            }
            else
            {
               ItemDetalle.TIPO_TabTDO = null;
               ItemDetalle.TIPO_CodTDO = null;
               ItemDetalle.TIPO_DescTDO = null;

               _isCorrect = false;
               _mensajeError = "* Debe seleccionar el Tipo de Documento.";
            }

            if (_isCorrect)
            {
               ItemDetalle.Instance = Infrastructure.Aspect.BusinessEntity.InstanceEntity.Modified;
               ItemDetalle.AUDI_UsrMod = Presenter.Session.UserName;
               ItemDetalle.AUDI_FecMod = Presenter.Session.Fecha;
               _isCorrect = Client.SaveDet_Cotizacion_OV_ServicioDocumento(ItemDetalle);
            }

            if (_isCorrect)
            {
               ItemDetalle.Instance = Infrastructure.Aspect.BusinessEntity.InstanceEntity.Unchanged;
               Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeSatisfactorio("Actualización de Documento", "Se ha actualizado satisfactoriamnete el Tipo, Serie y Número de Documento.");
            }
            else
            { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion("Actualización de Documento", "No se ha podido Actualizar el Documento.", _mensajeError); }

            return _isCorrect;
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError("Actualización de Documento", "Ha ocurrido un error al Guardar la Actualización del Documento.", ex); return false; }
      }
      #endregion

      #region [ Eventos ]
      private void btnAceptar_Click(object sender, EventArgs e)
      {
         if (GuardarDocumento())
         { this.DialogResult = System.Windows.Forms.DialogResult.OK; }
      }

      private void btnCancelar_Click(object sender, EventArgs e)
      {
         this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      }
      #endregion

   }
}
