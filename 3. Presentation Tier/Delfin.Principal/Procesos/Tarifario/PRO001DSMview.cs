using System;
using System.ComponentModel;
using System.Windows.Forms;
using Infrastructure.Aspect.Constants;

namespace Delfin.Principal
{
    public partial class PRO001DSMview : Form, IPRO001DSMview
    {
      #region [ Variables ]
      private bool Closing = false;
      #endregion

      #region [ Formulario ]
      public PRO001DSMview()
      {
          InitializeComponent();
          try
          {
              btnAgregar.Click += btnAgregar_Click;
              this.Load += PRO001DSMview_Load;
          }
          catch (Exception ex)
          { Infrastructure.WinFormsControls.Dialogos.MostrarMensajeError(Presenter.Title, Infrastructure.Aspect.Constants.Mensajes.ConstructorView, ex); }
      }
      void PRO001DSMview_Load(object sender, EventArgs e)
      {
          
      }
      #endregion

      #region [ Propiedades ]
      public PRO001Presenter Presenter { get; set; }
      private System.Collections.Hashtable HashFormulario { get; set; }
      #endregion

      #region [ IPRO001DView ]

      private void SetMaxWidth(string textmaxlenght, ComboBox Combo)
      {
         try
         {
            System.Drawing.Graphics g = this.CreateGraphics();
            System.Drawing.Font font = this.Font;
            Combo.DropDownWidth = (Int32)g.MeasureString(textmaxlenght, font).Width;
         }
         catch (Exception)
         { throw; }
      }

      public void LoadView()
      {
         try
         {
             CbSERV_Codigo.DataSource = Presenter.GetTodosServicios();
             CbSERV_Codigo.ValueMember = "SERV_Codigo";
             CbSERV_Codigo.DisplayMember = "SERV_Nombre_SPA";
             CbTIPO_CodMnd.LoadControl(Presenter.ContainerService, "Tabla Moneda", "MND", "< Selecione Moneda >", ListSortDirection.Descending);
             SetMaxWidth("012345678901234567890123456789012345678901234567890123456789", CbSERV_Codigo);
             switch (Presenter.TipoTarifa)
             {
                 case "L":  /* Logistico  :) */
                     tlpTarifarioLogistico.RowStyles[0].Height = 27;
                     this.Height = 117;
                     break;
                 case "A":   /* Aduanero  :) */
                     tlpTarifarioLogistico.RowStyles[0].Height = 0;
                     tlpTarifarioLogistico.RowStyles[0].Height = 27;
                     tlpTarifarioLogistico.RowStyles[1].Height = 27;
                     this.Height = 172;
                     break;
             }
         }
         catch (Exception ex)
         { Infrastructure.WinFormsControls.Dialogos.MostrarMensajeError(Presenter.Title, Infrastructure.Aspect.Constants.Mensajes.LoadView, ex); }
      }

      #region [ Detalle Servicio Tarifa ]
      public void ClearItem()
      {
          try
          {
              CbSERV_Codigo.SelectedIndex = 0;
              txtSCOT_PrecioUni.Value = 0;
              chkRoundtrip.Checked = false; 
              CbTIPO_CodMnd.SelectedIndex = 0;
          }
          catch (Exception ex)
          { Infrastructure.WinFormsControls.Dialogos.MostrarMensajeError(Presenter.Title, Infrastructure.Aspect.Constants.Mensajes.ClearItem, ex); }
      }
      public void GetItem()
      {
          try
          {
              if (CbSERV_Codigo.SelectedValue != null)
              {
                  Presenter.TempItemDet_TarifaServicio.SERV_Codigo = Int32.Parse(CbSERV_Codigo.SelectedValue.ToString());
                  Presenter.TempItemDet_TarifaServicio.TIPO_Desc_Servicio = CbSERV_Codigo.Text;
              }
              else
              {
                  Presenter.TempItemDet_TarifaServicio.SERV_Codigo = null;
                  Presenter.TempItemDet_TarifaServicio.TIPO_Desc_Servicio = null;
              }
              switch (Presenter.TipoTarifa)
              {
                  case "L": /* Logistico */
                      
                      break;
                  case "A": /* Aduana */
                       Presenter.TempItemDet_TarifaServicio.DTAS_Costo = txtSCOT_PrecioUni.Value > 0 ? txtSCOT_PrecioUni.Value : 0;
                      if (CbTIPO_CodMnd.SelectedValue != null)
                      {
                          Presenter.TempItemDet_TarifaServicio.TIPO_CodMnd = CbTIPO_CodMnd.SelectedValue.ToString();
                          Presenter.TempItemDet_TarifaServicio.TIPO_TabMnd = "MND";
                          Presenter.TempItemDet_TarifaServicio.CONS_Desc_Moneda = CbTIPO_CodMnd.Text;
                      }
                      else
                      {
                          Presenter.TempItemDet_TarifaServicio.TIPO_CodMnd = null;
                          Presenter.TempItemDet_TarifaServicio.TIPO_TabMnd = null;
                          Presenter.TempItemDet_TarifaServicio.CONS_Desc_Moneda = null;
                      }
                      if (chkRoundtrip.Checked)
                      {
                          Presenter.TempItemDet_TarifaServicio.DTAS_IGV = true;
                      }
                      else
                      {
                          Presenter.TempItemDet_TarifaServicio.DTAS_IGV = false;
                      }
                      break;
              }
          }
          catch (Exception ex)
          { Infrastructure.WinFormsControls.Dialogos.MostrarMensajeError(Presenter.Title, Infrastructure.Aspect.Constants.Mensajes.GetItem, ex); }
      }
      public void SetItem()
      {
          try
          {
              if (Presenter.ItemDet_TarifaServicio.SERV_Codigo != null)
              {
                  CbSERV_Codigo.SelectedValue = Int32.Parse(Presenter.ItemDet_TarifaServicio.SERV_Codigo.Value.ToString());  
              }
              if (Presenter.ItemDet_TarifaServicio.DTAS_Costo!= null)
              {
                  txtSCOT_PrecioUni.Value = Presenter.ItemDet_TarifaServicio.DTAS_Costo.Value;
              }
              
              if (Presenter.ItemDet_TarifaServicio.TIPO_CodMnd != null)
              {
                  CbTIPO_CodMnd.SelectedValue = Presenter.ItemDet_TarifaServicio.TIPO_CodMnd;
              }
              if (Presenter.ItemDet_TarifaServicio.DTAS_IGV != null)
              {
                  chkRoundtrip.Checked = Presenter.ItemDet_TarifaServicio.DTAS_IGV.Value;
              }
          }
          catch (Exception ex)
          { Infrastructure.WinFormsControls.Dialogos.MostrarMensajeError(Presenter.Title, Infrastructure.Aspect.Constants.Mensajes.SetItem, ex); }
      }
      public void SetInstance(InstanceView x_instance)
      {
          try
          {
              errorProvider1.Dispose();
              switch (x_instance)
              {
                  case InstanceView.Default:
                      break;
                  case InstanceView.New:
                      Presenter.ItemDet_TarifaServicio = new Entities.Det_Tarifa_Servicio();
                      Presenter.InstanciaDet_TarifaServicio = Infrastructure.Aspect.Constants.InstanceView.New;
                      HashFormulario = Infrastructure.Client.FormClose.FormValidateChanges.iniciarComparacionFormulario(this);
                      break;
                  case InstanceView.Edit:
                      Presenter.InstanciaDet_TarifaServicio = Infrastructure.Aspect.Constants.InstanceView.Edit;
                      HashFormulario = Infrastructure.Client.FormClose.FormValidateChanges.iniciarComparacionFormulario(this);
                      break;
                  case InstanceView.Delete:
                      break;
                  case InstanceView.Save:
                      break;
              }
          }
          catch (Exception ex)
          { Infrastructure.WinFormsControls.Dialogos.MostrarMensajeError(Presenter.Title, Mensajes.SetInstanceView, ex); }
      }
      public void ShowValidation()
      {
          try
          {
              Infrastructure.WinFormsControls.Dialogos.MostrarMensajeInformacion(Presenter.Title, "Faltan ingresar datos obligatorios: ", Presenter.TempItemDet_TarifaServicio.MensajeError, Infrastructure.WinFormsControls.Dialogos.Boton.Detalles);
              Infrastructure.Client.FormClose.FormShowErrorProvider<Entities.Det_Tarifa_Servicio>.Validate(Presenter.TempItemDet_TarifaServicio, this, errorProvider1);
          }
          catch (Exception ex)
          { Infrastructure.WinFormsControls.Dialogos.MostrarMensajeError(Presenter.Title, Infrastructure.Aspect.Constants.Mensajes.ShowItems, ex); }
      }
      public void CerrarVenta()
      {
          try
          {
              this.Close();
          }
          catch (Exception ex)
          { Infrastructure.WinFormsControls.Dialogos.MostrarMensajeError(Presenter.Title,"Ha ocurrido un error al cerrar la ventana.", ex); }
      }
      #endregion

      #endregion

      #region [ Metodos ]

      #region [ Detalle Servicio Tarifa ]
   
      #endregion
      #endregion

      #region [ Eventos ]

      #region [ Detalle Servicio Tarifa ]
      void btnAgregar_Click(object sender, EventArgs e)
      {
          Presenter.AgregarDetalleServicioTarifa();
      }

      private void txtCosto20_Enter(object sender, EventArgs e)
      {
         SeleccionaTexto((NumericUpDown)sender);
      }

      private void SeleccionaTexto(NumericUpDown _Numeric)
      {
         _Numeric.Select(0, _Numeric.Value.ToString().Length);
      }
      #endregion

      #endregion
    }
}
