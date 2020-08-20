using System;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using Delfin.Entities;
using Infrastructure.Aspect.Constants;
using Infrastructure.Client.FormClose;
using Infrastructure.WinFormsControls;


namespace Delfin.Principal
{
    public partial class PRO006DMview : Form, IPRO006DMview
    {
      #region [ Variables ]
      private bool Closing = false;
      #endregion

      #region [ Formulario ]
      public PRO006DMview()
      {
          InitializeComponent();
          try
          {
              btnAgregar.Click += btnAgregar_Click;
              Load += PRO006DMview_Load;
          }
          catch (Exception ex)
          { Dialogos.MostrarMensajeError(Presenter.Title, Mensajes.ConstructorView, ex); }
      }
      #endregion

      #region [ Propiedades ]
      public PRO006Presenter Presenter { get; set; }
      private Hashtable HashFormulario { get; set; }
      #endregion

      #region [ IPRO006DView ]
      public void LoadView()
      {
         try
         {
             CbPACK_Codigo.DataSource = Presenter.ListPaquetes;
             CbPACK_Codigo.ValueMember = "PACK_Codigo";
             CbPACK_Codigo.DisplayMember = "PACK_DescC";
             CbCONS_CodESS.LoadControl(Presenter.ContainerService, "Tabla Estado", "ETJ", "< Selecione Estado >", ListSortDirection.Descending);
         }
         catch (Exception ex)
         { Dialogos.MostrarMensajeError(Presenter.Title, Mensajes.LoadView, ex); }
      }

      #region [ Detalle Seguimiento ]
      public void ClearItem()
      {
          try
          {
              mdtDSEG_FechaArribo.NSFecha= null;
              mdtDSEG_FecIngresoDep.NSFecha = null;
              mdtDSEG_FecRetiroDep.NSFecha = null;
              mdtDSEG_FecPago.NSFecha = null;
              CbPACK_Codigo.SelectedIndex = 0;
              txtDSEG_NroContenedor.Clear();
              chkDSEG_Tarja.Checked = false;
              CbCONS_CodESS.SelectedIndex = 0;
              mdtFecVencimiento.NSFecha = null;
          }
          catch (Exception ex)
          { Dialogos.MostrarMensajeError(Presenter.Title, Mensajes.ClearItem, ex); }
      }
      public void GetItem()
      {
          try
          {
              Presenter.ItemDet_Seguimientos.DSEG_FechaArribo = mdtDSEG_FechaArribo.NSFecha != null ? (DateTime?) mdtDSEG_FechaArribo.NSFecha.Value : null;
              Presenter.ItemDet_Seguimientos.DSEG_FecIngresoDep = mdtDSEG_FecIngresoDep.NSFecha != null ? (DateTime?) mdtDSEG_FecIngresoDep.NSFecha.Value: null;
              Presenter.ItemDet_Seguimientos.DSEG_FecPago = mdtDSEG_FecPago.NSFecha != null ? (DateTime?) mdtDSEG_FecPago.NSFecha.Value: null;
              Presenter.ItemDet_Seguimientos.DSEG_FecRetiroDep = mdtDSEG_FecRetiroDep.NSFecha != null? (DateTime?) mdtDSEG_FecRetiroDep.NSFecha.Value: null;
              if (CbPACK_Codigo.SelectedValue != null)
              {
                  Presenter.ItemDet_Seguimientos.PACK_Codigo = Convert.ToInt32(CbPACK_Codigo.SelectedValue);
                  Presenter.ItemDet_Seguimientos.PACK_DescC  = CbPACK_Codigo.Text;
              }
              Presenter.ItemDet_Seguimientos.DSEG_NroContenedor = !String.IsNullOrEmpty(txtDSEG_NroContenedor.Text) ? txtDSEG_NroContenedor.Text : null;
              Presenter.ItemDet_Seguimientos.DSEG_Tarja = chkDSEG_Tarja.Checked;
              if (CbCONS_CodESS.SelectedValue != null )
              {
                  Presenter.ItemDet_Seguimientos.CONS_CodESS = CbCONS_CodESS.SelectedValue.ToString();
                  Presenter.ItemDet_Seguimientos.CONS_CodESSSTR = CbCONS_CodESS.Text;
              }
              else
              {
                  Presenter.ItemDet_Seguimientos.CONS_CodESS = null;
                  Presenter.ItemDet_Seguimientos.CONS_CodESSSTR = null;
              }
          }
          catch (Exception ex)
          { Dialogos.MostrarMensajeError(Presenter.Title, Mensajes.GetItem, ex); }
      }
      public void SetItem()
      {
          try
          {
              mdtDSEG_FechaArribo.NSFecha = Presenter.ItemDet_Seguimientos.DSEG_FechaArribo != null ? (DateTime?) Presenter.ItemDet_Seguimientos.DSEG_FechaArribo.Value : null;
              mdtDSEG_FecIngresoDep.NSFecha = Presenter.ItemDet_Seguimientos.DSEG_FecIngresoDep != null ? (DateTime?)Presenter.ItemDet_Seguimientos.DSEG_FecIngresoDep.Value : null;
              mdtDSEG_FecPago.NSFecha = Presenter.ItemDet_Seguimientos.DSEG_FecPago != null ? (DateTime?) Presenter.ItemDet_Seguimientos.DSEG_FecPago.Value: null;
              mdtDSEG_FecRetiroDep.NSFecha = Presenter.ItemDet_Seguimientos.DSEG_FecRetiroDep != null ? (DateTime?) Presenter.ItemDet_Seguimientos.DSEG_FecRetiroDep.Value : null;
              if (mdtDSEG_FechaArribo.NSFecha != null && Presenter.COPE_CantidadDias != null)
              {
                  mdtFecVencimiento.NSFecha = mdtDSEG_FechaArribo.NSFecha.Value.AddDays(Convert.ToDouble(Presenter.COPE_CantidadDias.Value));
              } else mdtFecVencimiento.NSFecha = null;

              if (Presenter.ItemDet_Seguimientos.PACK_Codigo > 0)
              {
                  CbPACK_Codigo.SelectedValue = Presenter.ItemDet_Seguimientos.PACK_Codigo;
              }
              txtDSEG_NroContenedor.Text = Presenter.ItemDet_Seguimientos.DSEG_NroContenedor;
              chkDSEG_Tarja.Checked = Presenter.ItemDet_Seguimientos.DSEG_Tarja;
              if (Presenter.ItemDet_Seguimientos.CONS_CodESS != null)
              {
                  CbCONS_CodESS.SelectedValue = Presenter.ItemDet_Seguimientos.CONS_CodESS; 
              }
          }
          catch (Exception ex)
          { Dialogos.MostrarMensajeError(Presenter.Title, Mensajes.SetItem, ex); }
      }
      public void SetInstance(InstanceView xInstance)
      {
          try
          {
              errorProvider1.Dispose();
              switch (xInstance)
              {
                  case InstanceView.Default:
                      break;
                  case InstanceView.New:
                      mdtDSEG_FechaArribo.NSFecha = Presenter.COPE_FechaArribo != null ? Presenter.COPE_FechaArribo.Value : (DateTime?) null;
                      if (Presenter.COPE_FechaArribo != null && Presenter.COPE_CantidadDias != null)
                      {
                          mdtFecVencimiento.NSFecha = Presenter.COPE_FechaArribo.Value.AddDays(Convert.ToDouble(Presenter.COPE_CantidadDias.Value));
                      } else mdtFecVencimiento.NSFecha = null;
                      HashFormulario = FormValidateChanges.iniciarComparacionFormulario(this);
                      break;
                  case InstanceView.Edit:
                      HashFormulario = FormValidateChanges.iniciarComparacionFormulario(this);
                      break;
                  case InstanceView.Delete:
                      break;
                  case InstanceView.Save:
                      break;
                
              }
          }
          catch (Exception ex)
          { Dialogos.MostrarMensajeError(Presenter.Title, Mensajes.SetInstanceView, ex); }
      }
      public void ShowValidation()
      {
          try
          {
              Dialogos.MostrarMensajeInformacion(Presenter.Title, "Faltan ingresar datos obligatorios: ", Presenter.ItemDet_Seguimientos.MensajeError, Dialogos.Boton.Detalles);
              FormShowErrorProvider<Det_Seguimientos>.Validate(Presenter.ItemDet_Seguimientos, this, errorProvider1);
          }
          catch (Exception ex)
          { Dialogos.MostrarMensajeError(Presenter.Title, Mensajes.ShowItems, ex); }
      }
      public void CerrarVenta()
      {
          try
          {
              Close();
          }
          catch (Exception ex)
          { Dialogos.MostrarMensajeError(Presenter.Title,"Ha ocurrido un error al cerrar la ventana.", ex); }
      }
      #endregion

      #endregion

      #region [ Metodos ]

      #region [ Detalle ]
  
      #endregion
      #endregion

      #region [ Eventos ]

      #region [ Detalle Seguimiento ]
      void btnAgregar_Click(object sender, EventArgs e)
      {
          Presenter.AgregarDetalleSeguimientos();
      }
      void PRO006DMview_Load(object sender, EventArgs e)
      {
         
      }

      #endregion

      #endregion
    }
}
