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
    public partial class PRO004DMview : Form, IPRO004DMview
    {
      #region [ Variables ]
      private bool Closing = false;
      #endregion

      #region [ Formulario ]
      public PRO004DMview()
      {
          InitializeComponent();
          try
          {
              btnAgregar.Click += btnAgregar_Click;
              Load += PRO004DMview_Load;
          }
          catch (Exception ex)
          { Dialogos.MostrarMensajeError(Presenter.Title, Mensajes.ConstructorView, ex); }
      }
      #endregion

      #region [ Propiedades ]
      public PRO004Presenter Presenter { get; set; }
      private Hashtable HashFormulario { get; set; }
      #endregion

      #region [ IPRO004DView ]
      public void LoadView()
      {
         try
         {
             CbPACK_Codigo.DataSource = Presenter.ListPaquetes;
             CbPACK_Codigo.ValueMember = "PACK_Codigo";
             CbPACK_Codigo.DisplayMember = "PACK_DescC";
             CbCONS_CodETJ.LoadControl(Presenter.ContainerService, "Tabla Estado", "ETJ", "< Selecione Estado >", ListSortDirection.Descending);
         }
         catch (Exception ex)
         { Dialogos.MostrarMensajeError(Presenter.Title, Mensajes.LoadView, ex); }
      }

      #region [ Detalle Tarjas ]
      public void ClearItem()
      {
          try
          {
              txtcantidad.Value = 0;
              txtcantidad.Text = @"0";
              txtDTAJ_NroContenedor.Clear();
              CbPACK_Codigo.SelectedIndex = 0;
              CbCONS_CodETJ.SelectedIndex = 0;
              chkDTAJ_Tarja.Checked = false;
          }
          catch (Exception ex)
          { Dialogos.MostrarMensajeError(Presenter.Title, Mensajes.ClearItem, ex); }
      }
      public void GetItem()
      {
          try
          {
              Presenter.ItemDet_Tarjas.DTAJ_NroContenedor = txtDTAJ_NroContenedor.Text;
              Presenter.ItemDet_Tarjas.Cantidad =(short)txtcantidad.Value;
              if (CbPACK_Codigo.SelectedValue!= null)
              {
                  Presenter.ItemDet_Tarjas.PACK_Codigo = Convert.ToInt32(CbPACK_Codigo.SelectedValue);
                  Presenter.ItemDet_Tarjas.PACK_Desc = CbPACK_Codigo.Text;
              }
              else
              {
                  Presenter.ItemDet_Tarjas.PACK_Codigo = null;
              }
              if (CbCONS_CodETJ.SelectedValue != null)
              {
                  Presenter.ItemDet_Tarjas.CONS_CodETJ = CbCONS_CodETJ.SelectedValue.ToString();
                  Presenter.ItemDet_Tarjas.CONS_Estado = CbCONS_CodETJ.Text;
              }
              Presenter.ItemDet_Tarjas.DTAJ_Tarja = true;
          }
          catch (Exception ex)
          { Dialogos.MostrarMensajeError(Presenter.Title, Mensajes.GetItem, ex); }
      }
      public void SetItem()
      {
          try
          {
              txtDTAJ_NroContenedor.Text = Presenter.ItemDet_Tarjas.DTAJ_NroContenedor;
              if (Presenter.ItemDet_Tarjas.PACK_Codigo != null)
              {
                  CbPACK_Codigo.SelectedValue = Presenter.ItemDet_Tarjas.PACK_Codigo.Value;
              }
              CbCONS_CodETJ.SelectedValue = Presenter.ItemDet_Tarjas.CONS_CodETJ;
              //if (Presenter.ItemDet_Tarjas.DTAJ_Tarja != null)
              //    chkDTAJ_Tarja.Checked = Presenter.ItemDet_Tarjas.DTAJ_Tarja.Value;
          }
          catch (Exception ex)
          { Dialogos.MostrarMensajeError(Presenter.Title, Mensajes.SetItem, ex); }
      }
      public void SetInstance(InstanceView x_instance)
      {
          try
          {
              errorProvider1.Dispose();
              btnAgregar.Enabled = true;
              txtcantidad.Text = @"1";
              switch (x_instance)
              {
                  case InstanceView.Default:
                      break;
                  case InstanceView.New:
                      
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
              Dialogos.MostrarMensajeInformacion(Presenter.Title, "Faltan ingresar datos obligatorios: ", Presenter.ItemDet_Tarjas.MensajeError, Dialogos.Boton.Detalles);
              FormShowErrorProvider<Det_Tarjas>.Validate(Presenter.ItemDet_Tarjas, this, errorProvider1);
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

      #region [ Detalle Tarjas ]
      void btnAgregar_Click(object sender, EventArgs e)
      {
          Presenter.AgregarDetalleTarjas();
      }
      void PRO004DMview_Load(object sender, EventArgs e)
      {
         
      }
    
      #endregion

      #endregion
    }
}
