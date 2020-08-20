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
   public partial class CAJ002IngresosEgresosDViewEDiferido : Form
   {
      #region [ Variables ]

      #endregion

      #region [ Formulario ]

      public CAJ002IngresosEgresosDViewEDiferido()
      {
         InitializeComponent();
         try
         {
            cmbTIPO_CodMND.Enabled = false;
            dtpMOVI_FecDiferido.Enabled = false;
            dtpMOVI_FecEmision.Enabled = false;
            cmbTIPO_CodMOV.Enabled = false;
            txnMOVI_NroOperacion.MaxLength = 20;
            btnAceptar.Click += btnAceptar_Click;
         }
         catch (Exception)
         {

            throw;
         }
      }


      public void LoadView()
      {
         try
         {
            cmbTIPO_CodMND.LoadControl(Presenter.ContainerService, "Ayuda Moneda", "MND", "< Sel.  Moneda>", ListSortDirection.Ascending);
            cmbTIPO_CodMOV.LoadControl(Presenter.ListTiposMOV, "Ayuda Movimiento", "< Sel. Tipo Movimiento >", ListSortDirection.Ascending);
            cmbTIPO_CodMOV_Dif.LoadControl(Presenter.ListTiposMOV_Dif, "Ayuda Movimiento", "< Sel. Tipo Mov. Destino >", ListSortDirection.Ascending);
            txaCUBA_NroCuenta.LoadControl(Presenter.ContainerService, "Ayuda de Cuentas Bancarias", Delfin.Controls.Entorno.ItemEmpresa.EMPR_Codigo, Presenter.Session.UserName);

            SetItem();
            dtpMOVI_FecEjecutado2.NSFecha = DateTime.Now;
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha Ocurrido un error iniciando", ex); }
      }

      #endregion

      #region [ Propiedades ]

      public Entities.Movimiento ItemMovimiento { get; set; }
      public Entities.CuentasBancarias ItemCuentasBancaria { get; set; }

      public CAJ002IngresosEgresosPresenter Presenter { get; set; }

      public String CUBA_Codigo { get; set; }
      public DateTime MOVI_FecEjecutado { get; set; }
      public String MOVI_NroOperacion { get; set; }
      public String TIPO_CodMOV_Dif { get; set; }

      #endregion

      #region [ ICUS002MView ]

      #endregion

      #region [ Metodos ]

      private void SetItem()
      {
         try
         {
            txaCUBA_NroCuenta.SetCuentaBancaria(ItemCuentasBancaria);
            cmbTIPO_CodMND.SelectedValue = ItemCuentasBancaria.TIPO_CodMND;
            cmbTIPO_CodMOV.SelectedValue = ItemMovimiento.TIPO_CodMOV;
            dtpMOVI_FecEmision.NSFecha = ItemMovimiento.MOVI_FecEmision.Value;
            dtpMOVI_FecDiferido.NSFecha = ItemMovimiento.MOVI_FecDiferido.Value;
            txnMOVI_NroOperacion.Text = ItemMovimiento.MOVI_NroOperacion;
         }
         catch (Exception)
         { throw; }
      }

      private void Aceptar()
      {
         try
         {
            if (txaCUBA_NroCuenta.SelectedItem != null && dtpMOVI_FecEjecutado2.NSFecha.HasValue)
            {
               CUBA_Codigo = txaCUBA_NroCuenta.SelectedItem.CUBA_Codigo;
               MOVI_NroOperacion = txnMOVI_NroOperacion.Text;
               MOVI_FecEjecutado = dtpMOVI_FecEjecutado2.NSFecha.Value;
               TIPO_CodMOV_Dif = cmbTIPO_CodMOV_Dif.TiposSelectedItem.TIPO_CodTipo;
               this.DialogResult = System.Windows.Forms.DialogResult.OK;
               this.Close();
            }
            else
            {
               if (txaCUBA_NroCuenta.SelectedItem == null && !dtpMOVI_FecEjecutado2.NSFecha.HasValue)
               { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Es obligatorio la cuenta Bancaria y la Fecha de Ejecución"); }
               if (txaCUBA_NroCuenta.SelectedItem == null && dtpMOVI_FecEjecutado2.NSFecha.HasValue)
               { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Es obligatorio la cuenta Bancaria"); }
               if (txaCUBA_NroCuenta.SelectedItem != null && dtpMOVI_FecEjecutado2.NSFecha.HasValue)
               { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Es obligatorio la Fecha de Ejecución"); }
            }
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha Ocurrido aceptando los datos de ejecución", ex); }
      }

      #endregion

      #region [ Eventos ]


      private void btnAceptar_Click(object sender, EventArgs e)
      { Aceptar(); }

      #endregion

   }
}
