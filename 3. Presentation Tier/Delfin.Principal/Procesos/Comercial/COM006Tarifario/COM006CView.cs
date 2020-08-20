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
   public partial class COM006CView : Form, ICOM006CView
   {
      #region [ Variables ]
      private bool Closing = false;
      #endregion

      #region [ Formulario ]
      public COM006CView()
      {
         InitializeComponent();
         try
         {
            rbtContrato.CheckedChanged += rbtContrato_CheckedChanged;
            rbtTarifas.CheckedChanged += rbtTarifas_CheckedChanged;
            TIPO_CodPAI.SelectedIndexChanged += TIPO_CodPAI_SelectedIndexChanged;

            SetMetodoCopiado();

            btnGuardar.Click += btnGuardar_Click;
            btnSalir.Click += btnSalir_Click;
         }
         catch (Exception)
         { }
      }

      
      #endregion

      #region [ Propiedades ]
      public COM006Presenter Presenter { get; set; }
      #endregion

      #region [ ICOM006CView ]
      public void LoadView()
      {
         try
         {
            CONS_CodRGM.LoadControl(Presenter.ContainerService, "Tabla Régimen", "RGM", "< Seleccionar Régimen >", ListSortDirection.Ascending);
            CONS_CodVia.LoadControl(Presenter.ContainerService, "Tabla Vía", "VIA", "< Seleccionar Vía >", ListSortDirection.Ascending);

            TIPO_CodPAI.LoadControl(Presenter.ContainerService, "Tabla Países", "PAI", "< Seleccionar País Origen >", ListSortDirection.Ascending);
            PUER_Codigo.DataSource = null;
            PUER_Codigo.Enabled = false;

            CONT_Numero.Enabled = false;
            CONT_FecEmi.Enabled = false;
            CONT_Descrip.Enabled = false;
            CONT_FecFin.Enabled = false;
            CONT_FecIni.Enabled = false;
            CONS_CodRGM.Enabled = false;
            CONS_CodVia.Enabled = false;

            //PUER_CodDestino.DataSource = null;
            //PUER_CodDestino.Enabled = false;
         }
         catch (Exception)
         { }
      }
      public void ClearItem()
      {
         try
         {
            CONT_Numero.Text = string.Empty;
            CONT_FecEmi.NSFecha = null;
            CONT_Descrip.Text = string.Empty;
            CONT_FecFin.NSFecha = null;
            CONT_FecIni.NSFecha = null;
            CONS_CodRGM.ConstantesSelectedValue = null;
            CONS_CodVia.ConstantesSelectedValue = null;

            CONT_NumeroNew.Text = string.Empty;
            CONT_FecEmiNew.NSFecha = null;
            CONT_DescripNew.Text = string.Empty;
            CONT_FecFinNew.NSFecha = null;
            CONT_FecIniNew.NSFecha = null;

            TIPO_CodPAI.TiposSelectedValue = null;
            PUER_Codigo.ComboIntSelectedValue = null;
         }
         catch (Exception)
         { }
      }
      public void SetItem()
      {
         try
         {
            CONT_Numero.Text = Presenter.Item.CONT_Numero;
            CONT_FecEmi.NSFecha = Presenter.Item.CONT_FecEmi;
            CONT_Descrip.Text = Presenter.Item.CONT_Descrip;
            CONT_FecIni.NSFecha = Presenter.Item.CONT_FecIni;
            CONT_FecFin.NSFecha = Presenter.Item.CONT_FecFin;

            CONT_NumeroNew.Text = Presenter.Item.CONT_Numero;
            CONT_FecEmiNew.NSFecha = Presenter.Session.Fecha;
            CONT_FecIniNew.NSFecha = Presenter.Item.CONT_FecIni;
            CONT_FecFinNew.NSFecha = Presenter.Item.CONT_FecFin;
            CONT_DescripNew.Text = Presenter.Item.CONT_Descrip;

            CONS_CodRGM.ConstantesSelectedValue = Presenter.Item.CONS_CodRGM;
            CONS_CodVia.ConstantesSelectedValue = Presenter.Item.CONS_CodVia;
         }
         catch (Exception)
         { }
      }
      public void GetItem()
      {
         try
         {

            //Presenter.Item.CONT_Codigo = CONT_Codigo.Text;
            Presenter.ItemCopia.CONT_Numero = CONT_NumeroNew.Text;
            Presenter.ItemCopia.CONT_FecEmi = CONT_FecEmiNew.NSFecha;
            Presenter.ItemCopia.CONT_FecFin = CONT_FecFinNew.NSFecha;
            Presenter.ItemCopia.CONT_FecIni = CONT_FecIniNew.NSFecha;
            Presenter.ItemCopia.CONT_Descrip = CONT_DescripNew.Text;

            if (CONS_CodRGM.ConstantesSelectedItem != null)
            {
               Presenter.ItemCopia.CONS_TapRGM = CONS_CodRGM.ConstantesSelectedItem.CONS_CodTabla;
               Presenter.ItemCopia.CONS_CodRGM = CONS_CodRGM.ConstantesSelectedItem.CONS_CodTipo;
            }
            else
            {
               Presenter.ItemCopia.CONS_TapRGM = null;
               Presenter.ItemCopia.CONS_CodRGM = null;
            }
            if (CONS_CodVia.ConstantesSelectedItem != null)
            {
               Presenter.ItemCopia.CONS_TapVia = CONS_CodVia.ConstantesSelectedItem.CONS_CodTabla;
               Presenter.ItemCopia.CONS_CodVia = CONS_CodVia.ConstantesSelectedItem.CONS_CodTipo;
            }
            else
            {
               Presenter.ItemCopia.CONS_TapVia = null;
               Presenter.ItemCopia.CONS_CodVia = null;
            }

            Presenter.ItemCopia.ENTC_CodTransportista = Presenter.Item.ENTC_CodTransportista;
            Presenter.ItemCopia.ENTC_CodCliente = Presenter.Item.ENTC_CodCliente;
            Presenter.ItemCopia.TIPO_TabMND = Presenter.Item.TIPO_TabMND;
            Presenter.ItemCopia.TIPO_CodMND = Presenter.Item.TIPO_CodMND;
            
         }
         catch (Exception)
         { }
      }
      #endregion

      #region [ Metodos ]
      private void SetMetodoCopiado()
      {
         try
         {
            Boolean EnableContrato = rbtContrato.Checked;

            lblCONT_NumeroNew.Enabled = EnableContrato;
            CONT_NumeroNew.Enabled = EnableContrato;
            lblCONT_FecEmiNew.Enabled = EnableContrato;
            CONT_FecEmiNew.Enabled = EnableContrato;
            lblCONT_FecIniNew.Enabled = EnableContrato;
            CONT_FecIniNew.Enabled = EnableContrato;
            lblCONT_FecFinNew.Enabled = EnableContrato;
            CONT_FecFinNew.Enabled = EnableContrato;
            lblCONT_DescripNew.Enabled = EnableContrato;
            CONT_DescripNew.Enabled = EnableContrato;

            lblTIPO_CodPAI.Enabled = !EnableContrato;
            TIPO_CodPAI.Enabled = !EnableContrato;
            lblPUER_Codigo.Enabled = !EnableContrato;
            PUER_Codigo.Enabled = !EnableContrato;
         }
         catch (Exception)
         { }
      }
      private void LoadPuertos()
      {
         try
         {
            Boolean _inicializar = true;
            if (TIPO_CodPAI.TiposSelectedItem != null && CONS_CodVia.ConstantesSelectedItem != null)
            {
               ObservableCollection<Entities.Puerto> _items = Presenter.ListPuertos.Where(puer => puer.PUER_Favorito && puer.TIPO_CodPais == TIPO_CodPAI.TiposSelectedItem.TIPO_CodTipo && puer.CONS_CodVia == CONS_CodVia.ConstantesSelectedItem.CONS_CodTipo).ToObservableCollection();
               if (_items != null && _items.Count > 0)
               {
                  foreach (Entities.Puerto _puerto in _items)
                  {
                     PUER_Codigo.AddComboBoxItem(_puerto.PUER_Codigo, _puerto.PUER_Nombre, _inicializar);
                     _inicializar = false;
                  }
                  PUER_Codigo.LoadComboBox("< Seleccionar Puerto Origen >", ListSortDirection.Ascending);
                  PUER_Codigo.Enabled = true;
               }
               else
               {
                  PUER_Codigo.DataSource = null;
                  PUER_Codigo.Enabled = false;
               }
            }
            else
            {
               PUER_Codigo.DataSource = null;
               PUER_Codigo.Enabled = false;
            }
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al cargar los puertos.", ex); }
      }
      private void Guardar()
      {
         try
         {
            Boolean _CopiarContrato = rbtContrato.Checked;
            Int32 _PUER_Codigo = -1;
            if (!rbtContrato.Checked && PUER_Codigo.ComboIntSelectedValue.HasValue)
            { _PUER_Codigo = PUER_Codigo.ComboIntSelectedValue.Value; }

            if (Presenter.GuardarCopia(_CopiarContrato, _PUER_Codigo))
            { this.Close(); }
         }
         catch (Exception)
         { }
      }
      #endregion

      #region [ Eventos ]
      private void btnGuardar_Click(object sender, EventArgs e)
      { Guardar(); }
      private void btnSalir_Click(object sender, EventArgs e)
      {
         try
         {
            this.Close();
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al cerrar el formulario.", ex); }
      }

      private void rbtContrato_CheckedChanged(object sender, EventArgs e)
      { SetMetodoCopiado(); }
      private void rbtTarifas_CheckedChanged(object sender, EventArgs e)
      { SetMetodoCopiado(); }

      private void TIPO_CodPAI_SelectedIndexChanged(object sender, EventArgs e)
      { LoadPuertos(); }
      #endregion
   }
}
