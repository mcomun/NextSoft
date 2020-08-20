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
   public partial class COM006DView : Form, ICOM006DView
   {
      #region [ Variables ]

      #endregion

      #region [ Formulario ]
      public COM006DView()
      {
         InitializeComponent();
         try
         {

            this.FormClosing += new FormClosingEventHandler(MView_FormClosing);

            TIPO_CodPAIOrigen.SelectedIndexChanged += TIPO_CodPAIOrigen_SelectedIndexChanged;
            TIPO_CodPAIDestino.SelectedIndexChanged += TIPO_CodPAIDestino_SelectedIndexChanged;

            TARI_Costo.ValueChanged += TARI_Costo_ValueChanged;
            TARI_Profit1.ValueChanged += TARI_Profit1_ValueChanged;
            TARI_Profit2.ValueChanged += TARI_Profit2_ValueChanged;
            TARI_Profit3.ValueChanged += TARI_Profit3_ValueChanged;
            TARI_Profit4.ValueChanged += TARI_Profit4_ValueChanged;
         }
         catch (Exception)
         { }
      }
      #endregion

      #region [ Propiedades ]
      public COM006Presenter Presenter { get; set; }
      private bool Closing = false;
      private System.Collections.Hashtable HashFormulario { get; set; }
      #endregion

      #region [ ICOM006DView ]
      public void LoadView()
      {
         try
         {
            ENTC_CodCliente.ContainerService = Presenter.ContainerService;
            ENTC_CodTransportista.ContainerService = Presenter.ContainerService;

            ENTC_CodCliente.TipoEntidad = Delfin.Controls.TiposEntidad.TIPE_Cliente;
            ENTC_CodTransportista.TipoEntidad = Delfin.Controls.TiposEntidad.TIPE_Transportista;

            CONS_CodRGM.LoadControl(Presenter.ContainerService, "Tabla Régimen", "RGM", "< Seleccionar Régimen >", ListSortDirection.Ascending);
            CONS_CodVia.LoadControl(Presenter.ContainerService, "Tabla Vía", "VIA", "< Seleccionar Vía >", ListSortDirection.Ascending);
            CONS_CodBas.LoadControl(Presenter.ContainerService, "Tabla Base De Cálculo", "BAS", "< Seleccionar Base >", ListSortDirection.Ascending);

            TIPO_CodMnd.LoadControl(Presenter.ContainerService, "Tabla Monedas", "MND", "< Seleccionar Moneda >", ListSortDirection.Ascending);
            TIPO_CodPAIOrigen.LoadControl(Presenter.ContainerService, "Tabla Países", "PAI", "< Seleccionar País Origen >", ListSortDirection.Ascending);
            TIPO_CodPAIDestino.LoadControl(Presenter.ContainerService, "Tabla Países", "PAI", "< Seleccionar País Origen >", ListSortDirection.Ascending);

            Boolean _inicializar = true;
            foreach (Entities.Paquete _paquete in Presenter.ListPaquetes)
            {
               PACK_Codigo.AddComboBoxItem(_paquete.PACK_Codigo, _paquete.PACK_Desc, _inicializar);
               _inicializar = false;
            }
            PACK_Codigo.LoadComboBox("< Seleccionar Paquete >", ListSortDirection.Ascending);

            PUER_CodOrigen.DataSource = null;
            PUER_CodOrigen.Enabled = false;

            PUER_CodDestino.DataSource = null;
            PUER_CodDestino.Enabled = false;
         }
         catch (Exception)
         { }
      }

      public void ClearItem()
      {
         try
         {
            CONT_Numero.Text = string.Empty;
            CONT_Numero.Text = string.Empty;
            CONT_Descrip.Text = string.Empty;
            CONT_FecFin.NSFecha = null;
            CONT_FecIni.NSFecha = null;
            ENTC_CodTransportista.ClearValue();
            ENTC_CodTransportista.Text = String.Empty;
            ENTC_CodCliente.ClearValue();
            ENTC_CodCliente.Text = String.Empty;
            CONS_CodRGM.ConstantesSelectedValue = null;
            CONS_CodVia.ConstantesSelectedValue = null;



            TIPO_CodMnd.TiposSelectedValue = null;
            CONS_CodBas.ConstantesSelectedValue = null;
            TIPO_CodPAIOrigen.TiposSelectedValue = null;
            //PUER_CodOrigen.ComboIntSelectedValue = null;
            TIPO_CodPAIDestino.TiposSelectedValue = null;
            //PUER_CodDestino.ComboIntSelectedValue = null;
            
            PACK_Codigo.ComboIntSelectedValue = null;

            TARI_Peso.Text = "0.00";
            TARI_Volumen.Text = "0.00";
            TARI_Costo.Text = "0.00";
            TARI_Profit1.Text = "0.00";
            TARI_Profit2.Text = "0.00";
            TARI_Profit3.Text = "0.00";
            TARI_Profit4.Text = "0.00";
            TARI_PVenta1.Text = "0.00";
            TARI_PVenta2.Text = "0.00";
            TARI_PVenta3.Text = "0.00";
            TARI_PVenta4.Text = "0.00";

         }
         catch (Exception)
         { }
      }
      public void GetItem()
      {
         try
         {
            //TARI_Codigo  
            //EMPR_Codigo  
            //CONT_Codigo   

            Presenter.ItemTarifa.TARI_Costo = TARI_Costo.Value;
            Presenter.ItemTarifa.TARI_Profit1 = TARI_Profit1.Value;
            Presenter.ItemTarifa.TARI_Profit2 = TARI_Profit2.Value;
            Presenter.ItemTarifa.TARI_Profit3 = TARI_Profit3.Value;
            Presenter.ItemTarifa.TARI_Profit4 = TARI_Profit4.Value;
            Presenter.ItemTarifa.TARI_PVenta1 = TARI_PVenta1.Value;
            Presenter.ItemTarifa.TARI_PVenta2 = TARI_PVenta2.Value;
            Presenter.ItemTarifa.TARI_PVenta3 = TARI_PVenta3.Value;
            Presenter.ItemTarifa.TARI_PVenta4 = TARI_PVenta4.Value;
            Presenter.ItemTarifa.TARI_Peso = TARI_Peso.Value;
            Presenter.ItemTarifa.TARI_Volum = TARI_Volumen.Value;
            if (TIPO_CodMnd.TiposSelectedItem != null)
            {
               Presenter.ItemTarifa.TIPO_TabMnd = TIPO_CodMnd.TiposSelectedItem.TIPO_CodTabla;
               Presenter.ItemTarifa.TIPO_CodMnd = TIPO_CodMnd.TiposSelectedItem.TIPO_CodTipo;
            }
            else
            {
               Presenter.ItemTarifa.TIPO_TabMnd = null;
               Presenter.ItemTarifa.TIPO_CodMnd = null;
            }
            if (CONS_CodBas.ConstantesSelectedItem != null)
            {
               Presenter.ItemTarifa.CONS_TabBas = CONS_CodBas.ConstantesSelectedItem.CONS_CodTabla;
               Presenter.ItemTarifa.CONS_CodBas = CONS_CodBas.ConstantesSelectedItem.CONS_CodTipo;
            }
            else
            {
               Presenter.ItemTarifa.CONS_TabBas = null;
               Presenter.ItemTarifa.CONS_CodBas = null;
            }
            
            Presenter.ItemTarifa.PUER_CodOrigen = PUER_CodOrigen.ComboIntSelectedValue;
            Presenter.ItemTarifa.PUER_CodDestino = PUER_CodDestino.ComboIntSelectedValue;
            if (PACK_Codigo.ComboIntSelectedValue.HasValue)
            { Presenter.ItemTarifa.PACK_Codigo = PACK_Codigo.ComboIntSelectedValue.Value; }
         }
         catch (Exception)
         { }
      }
      public void SetItem()
      {
         try
         {
            CONT_Numero.Text = Presenter.Item.CONT_Numero;
            CONT_Descrip.Text = Presenter.Item.CONT_Descrip;
            CONT_FecIni.NSFecha = Presenter.Item.CONT_FecIni;
            CONT_FecFin.NSFecha = Presenter.Item.CONT_FecFin;

            if (Presenter.Item.ENTC_CodTransportista.HasValue)
            { ENTC_CodTransportista.SetValue(Presenter.Item.ENTC_CodTransportista.Value); }
            if (Presenter.Item.ENTC_CodCliente.HasValue)
            { ENTC_CodCliente.SetValue(Presenter.Item.ENTC_CodCliente.Value); }

            CONS_CodRGM.ConstantesSelectedValue = Presenter.Item.CONS_CodRGM;
            CONS_CodVia.ConstantesSelectedValue = Presenter.Item.CONS_CodVia;

            TIPO_CodMnd.TiposSelectedValue = Presenter.ItemTarifa.TIPO_CodMnd;
            CONS_CodBas.ConstantesSelectedValue = Presenter.ItemTarifa.CONS_CodBas;
            
            Entities.Puerto _puerto = null;
            _puerto = Presenter.ListPuertos.Where(puer => puer.PUER_Codigo == Presenter.ItemTarifa.PUER_CodOrigen).FirstOrDefault();
            if (_puerto != null)
            {
               TIPO_CodPAIOrigen.TiposSelectedValue = _puerto.TIPO_CodPais;
               PUER_CodOrigen.ComboIntSelectedValue = Presenter.ItemTarifa.PUER_CodOrigen;
            }
            _puerto = null;
            _puerto = Presenter.ListPuertos.Where(puer => puer.PUER_Codigo == Presenter.ItemTarifa.PUER_CodDestino).FirstOrDefault();
            if (_puerto != null)
            {
               TIPO_CodPAIDestino.TiposSelectedValue = _puerto.TIPO_CodPais;
               PUER_CodDestino.ComboIntSelectedValue = Presenter.ItemTarifa.PUER_CodDestino;
            }
            
            PACK_Codigo.ComboIntSelectedValue = Presenter.ItemTarifa.PACK_Codigo;

            TARI_Peso.Text = Presenter.ItemTarifa.TARI_Peso.HasValue ? Presenter.ItemTarifa.TARI_Peso.Value.ToString() : "0.00";
            TARI_Volumen.Text = Presenter.ItemTarifa.TARI_Volum.HasValue ? Presenter.ItemTarifa.TARI_Volum.Value.ToString() : "0.00";
            TARI_Costo.Text = Presenter.ItemTarifa.TARI_Costo.HasValue ? Presenter.ItemTarifa.TARI_Costo.Value.ToString() : "0.00";
            TARI_Profit1.Text = Presenter.ItemTarifa.TARI_Profit1.HasValue ? Presenter.ItemTarifa.TARI_Profit1.Value.ToString() : "0.00";
            TARI_Profit2.Text = Presenter.ItemTarifa.TARI_Profit2.HasValue ? Presenter.ItemTarifa.TARI_Profit2.Value.ToString() : "0.00";
            TARI_Profit3.Text = Presenter.ItemTarifa.TARI_Profit3.HasValue ? Presenter.ItemTarifa.TARI_Profit3.Value.ToString() : "0.00";
            TARI_Profit4.Text = Presenter.ItemTarifa.TARI_Profit4.HasValue ? Presenter.ItemTarifa.TARI_Profit4.Value.ToString() : "0.00";
            TARI_PVenta1.Text = Presenter.ItemTarifa.TARI_PVenta1.HasValue ? Presenter.ItemTarifa.TARI_PVenta1.Value.ToString() : "0.00";
            TARI_PVenta2.Text = Presenter.ItemTarifa.TARI_PVenta2.HasValue ? Presenter.ItemTarifa.TARI_PVenta2.Value.ToString() : "0.00";
            TARI_PVenta3.Text = Presenter.ItemTarifa.TARI_PVenta3.HasValue ? Presenter.ItemTarifa.TARI_PVenta3.Value.ToString() : "0.00";
            TARI_PVenta4.Text = Presenter.ItemTarifa.TARI_PVenta4.HasValue ? Presenter.ItemTarifa.TARI_PVenta4.Value.ToString() : "0.00";

            TARI_Costo.Select();

            HashFormulario = Infrastructure.Client.FormClose.FormValidateChanges.iniciarComparacionFormulario(this);
         }
         catch (Exception)
         { }
      }

      public void ShowValidation()
      {
         try
         {
            Infrastructure.Client.FormClose.FormShowErrorProvider<Entities.Contrato>.Validate(Presenter.Item, this, errorProvider1);
         }
         catch (Exception)
         { }
      }
      #endregion

      #region [ Metodos ]
      private void LoadPuertosOrigen()
      {
         try
         {
            Boolean _inicializar = true;
            if (TIPO_CodPAIOrigen.TiposSelectedItem != null)
            {
               ObservableCollection<Entities.Puerto> _items = Presenter.ListPuertos.Where(puer => puer.TIPO_CodPais == TIPO_CodPAIOrigen.TiposSelectedItem.TIPO_CodTipo).ToObservableCollection();
               if (_items != null && _items.Count > 0)
               {
                  foreach (Entities.Puerto _puerto in _items)
                  {
                     PUER_CodOrigen.AddComboBoxItem(_puerto.PUER_Codigo, _puerto.PUER_Nombre, _inicializar);
                     _inicializar = false;
                  }
                  PUER_CodOrigen.LoadComboBox("< Seleccionar Puerto Origen >", ListSortDirection.Ascending);
                  PUER_CodOrigen.Enabled = false;
               }
               else
               {
                  PUER_CodOrigen.DataSource = null;
                  PUER_CodOrigen.Enabled = false;
               }
            }
            else
            {
               PUER_CodOrigen.DataSource = null;
               PUER_CodOrigen.Enabled = false;
            }
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al cargar los puertos de origen.", ex); }
      }
      private void LoadPuertosDestino()
      {
         try
         {
            Boolean _inicializar = true;
            if (TIPO_CodPAIDestino.TiposSelectedItem != null)
            {
               ObservableCollection<Entities.Puerto> _items = Presenter.ListPuertos.Where(puer => puer.TIPO_CodPais == TIPO_CodPAIDestino.TiposSelectedItem.TIPO_CodTipo).ToObservableCollection();
               if (_items != null && _items.Count > 0)
               {
                  foreach (Entities.Puerto _puerto in _items)
                  {
                     PUER_CodDestino.AddComboBoxItem(_puerto.PUER_Codigo, _puerto.PUER_Nombre, _inicializar);
                     _inicializar = false;
                  }
                  PUER_CodDestino.LoadComboBox("< Seleccionar Puerto Destino >", ListSortDirection.Ascending);
                  PUER_CodDestino.Enabled = false;
               }
               else
               {
                  PUER_CodDestino.DataSource = null;
                  PUER_CodDestino.Enabled = false;
               }
            }
            else
            {
               PUER_CodDestino.DataSource = null;
               PUER_CodDestino.Enabled = false;
            }
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al cargar los puertos de destino.", ex); }
      }

      private void ProfitCahnged(Int32 ProfitIndex)
      {
         try
         {
            switch (ProfitIndex)
            {
               case 1:
                  TARI_PVenta1.Text = (TARI_Costo.Value + TARI_Profit1.Value).ToString();
                  break;
               case 2:
                  TARI_PVenta2.Text = (TARI_Costo.Value + TARI_Profit2.Value).ToString();
                  break;
               case 3:
                  TARI_PVenta3.Text = (TARI_Costo.Value + TARI_Profit3.Value).ToString();
                  break;
               case 4:
                  TARI_PVenta4.Text = (TARI_Costo.Value + TARI_Profit4.Value).ToString();
                  break;
            }
         }
         catch (Exception)
         { }
      }
      #endregion

      #region [ Eventos ]
      private void btnGuardar_Click(object sender, EventArgs e)
      {
         try
         {
            if (Presenter.GuardarTarifa())
            {
               this.FormClosing -= MView_FormClosing;
               errorProvider1.Dispose();
               //Presenter.Actualizar();
               this.Close();
            }
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al Guardar.", ex); }
      }
      private void btnSalir_Click(object sender, EventArgs e)
      {
         try
         {
            this.FormClosing -= MView_FormClosing;
            errorProvider1.Dispose();
            if (Infrastructure.Client.FormClose.FormValidateChanges.verificarCambioFormulario(this, HashFormulario))
            {
               if (Presenter.GuardarTarifaCambios() != System.Windows.Forms.DialogResult.Cancel)
               { this.Close(); }
               else
               { this.FormClosing += MView_FormClosing; }
            }
            else
            { this.Close(); }
            Closing = true;
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al cerrar el formulario.", ex); }
      }

      private void TIPO_CodPAIOrigen_SelectedIndexChanged(object sender, EventArgs e)
      { LoadPuertosOrigen(); }
      private void TIPO_CodPAIDestino_SelectedIndexChanged(object sender, EventArgs e)
      { LoadPuertosDestino(); }

      private void TARI_Costo_ValueChanged(object sender, EventArgs e)
      {
         ProfitCahnged(1);
         ProfitCahnged(2);
         ProfitCahnged(3);
         ProfitCahnged(4);
      }
      private void TARI_Profit1_ValueChanged(object sender, EventArgs e)
      { ProfitCahnged(1); }
      private void TARI_Profit2_ValueChanged(object sender, EventArgs e)
      { ProfitCahnged(2); }
      private void TARI_Profit3_ValueChanged(object sender, EventArgs e)
      { ProfitCahnged(3); }
      private void TARI_Profit4_ValueChanged(object sender, EventArgs e)
      { ProfitCahnged(4); }

      private void MView_FormClosing(object sender, FormClosingEventArgs e)
      {
         try
         {
            if (Closing != true)
            {
               this.FormClosing -= MView_FormClosing;
               if (Infrastructure.Client.FormClose.FormValidateChanges.verificarCambioFormulario(this, HashFormulario))
               {
                  if (Presenter.GuardarTarifaCambios() == System.Windows.Forms.DialogResult.Cancel)
                  {
                     e.Cancel = true;
                     this.FormClosing += new FormClosingEventHandler(MView_FormClosing);
                  }
               }
            }
            else
            { Closing = false; e.Cancel = true; }
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al cerrar el formulario.", ex); }
      }
      #endregion
   }
}

