using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Delfin.Principal
{
   public partial class CAJ011AnularDocBancosFView : Form
   {
      #region [ Variables ]

      #endregion

      #region [ Propiedades ]

      public Entities.Movimiento Item { get; set; }
      public CAJ011AnularDocBancosPresenter Presenter { get; set; }
      public DateTime Fecha { get; set; }

      #endregion

      #region [ Formulario ]

      public CAJ011AnularDocBancosFView()
      {
         InitializeComponent();
         try
         {
            btnAceptar.Click += btnAceptar_Click;
            btnSalir.Click += btnSalir_Click;

            txaENTC_Codigo.Enabled = false;
            cmbTIPE_Codigo.Enabled = false;
            cmbTIPO_CodMOV.Enabled = false;
            txtMOVI_Codigo.ReadOnly = true;
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ocurrio un error en la interfaz", ex); }
      }

      public void LoadView()
      {
         try
         {
            txaENTC_Codigo.LoadControl(Presenter.ContainerService, Delfin.Controls.TiposEntidad.TIPE_Cliente, null, null, true);
            cmbTIPO_CodMOV.LoadControl(Presenter.ContainerService, "Tipos de Movimiento", "MOV", "< Tipo de Movimiento >", ListSortDirection.Ascending);
            cmbTIPE_Codigo.LoadControl(Presenter.ContainerService, "Tipo Entidad", "< Tipo de Entidad >", ListSortDirection.Ascending);
            cmbTIPE_Codigo.SelectedIndexChanged += cmbTIPE_Codigo_SelectedIndexChanged;

            SetItem();
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ocurrio un error en la interfaz", ex); }
      }

      #endregion

      #region [ ICUS002MView ]

      #endregion

      #region [ Metodos ]

      private void SetItem()
      {
         try
         {
            if (Item != null)
            {
               txtMOVI_Codigo.Text = Item.MOVI_Codigo.ToString();
               cmbTIPO_CodMOV.SelectedValue = Item.TIPO_CodMOV;
               cmbTIPE_Codigo.TipoEntidadSelectedValue = Item.TIPE_Codigo;
               txaENTC_Codigo.SetEntidad(Item.ENTC_Codigo);
            }
         }
         catch (Exception)
         { throw; }
      }

      #endregion

      #region [ Eventos ]

      private void btnSalir_Click(object sender, EventArgs e)
      {
         try
         {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ocurrio un error en la interfaz", ex); }
      }

      private void btnAceptar_Click(object sender, EventArgs e)
      {
         try
         {
            if (dtpFecFin.NSFecha.HasValue)
            {
               Fecha = dtpFecFin.NSFecha.Value.Date;
               this.DialogResult = System.Windows.Forms.DialogResult.OK;
               this.Close();
            }
            else { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Debe seleccionar una fecha para completar el proceso"); }
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ocurrio al seleccionar la fecha", ex); }
      }

      private void cmbTIPE_Codigo_SelectedIndexChanged(object sender, EventArgs e)
      {
         try
         {
            if (cmbTIPE_Codigo.TipoEntidadSelectedItem != null)
            {
               txaENTC_Codigo.TiposEntidad = Delfin.Controls.EntidadClear.getTipoEntidadEnum(cmbTIPE_Codigo.TipoEntidadSelectedItem.TIPE_Codigo);
            }
            else { cmbTIPE_Codigo.SelectedIndex = 0; }
         }
         catch (Exception)
         { throw; }
      }

      #endregion

      #region [ IFormClose ]

      #endregion

   }
}
