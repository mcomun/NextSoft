using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Delfin.Principal
{
   public partial class REP002ChequesLView : UserControl, IREP002ChequesLView
   {
      #region [ Variables ]

      #endregion

      #region [ Formulario ]

      public REP002ChequesLView(Telerik.WinControls.UI.RadPageViewPage x_tabPageControl)
      {
         InitializeComponent();
         try
         {
            TabPageControl = x_tabPageControl;
            TitleView.FormClose += new EventHandler(TitleView_FormClose);
            txaCUBA_Codigo.SelectedItemCuentaBancariaChanged += txaCUBA_Codigo_SelectedItemCuentaBancariaChanged;
            cmbTIPO_CodBCO.Enabled = false;
            btnImprimir.Click += btnImprimir_Click;
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error inicializando el formulario LView.", ex); }
      }


      private void txaCUBA_Codigo_SelectedItemCuentaBancariaChanged(object sender, EventArgs e)
      {
         try
         {
            if (txaCUBA_Codigo.SelectedItem != null)
            { cmbTIPO_CodBCO.SelectedValue = cmbTIPO_CodBCO.TiposSelectedValue = txaCUBA_Codigo.SelectedItem.TIPO_CodBCO; }
            else { cmbTIPO_CodBCO.SelectedIndex = 0; }
         }
         catch (Exception)
         { }
      }

      #endregion

      #region [ Propiedades ]

      public Telerik.WinControls.UI.RadPageViewPage TabPageControl { get; set; }
      public Image IconView { get { return TitleView.FormIcon; } set { TitleView.FormIcon = value; } }
      public REP002ChequesPresenter Presenter { get; set; }
      public String MensajeError { get; set; }
      #endregion

      #region [ REP002ChequesLView ]

      public void LoadView()
      {
         try
         {
            btnImprimir.Enabled = true;
            this.TitleView.Caption = Presenter.Title;

            txaCUBA_Codigo.LoadControl(Presenter.ContainerService, "Ayuda de Cuenta Corriente", Delfin.Controls.Entorno.ItemEmpresa.EMPR_Codigo, Presenter.Session.UserName, Delfin.Controls.CuentaBancaria.TipoAyuda.Normal);
            cmbTIPO_CodBCO.LoadControl(Presenter.ContainerService, "Moneda", "BCO", "< Entidad Bancaria >", ListSortDirection.Ascending);

            cmbMOVI_EstadoCheque.LoadControl("Estado de Cheque", Delfin.Controls.Tipos.ComboBoxConstantes.OConstantes.EstadoCheque, "< Todos >", ListSortDirection.Ascending);
            cmbTipoCheque.LoadControl("Tipo de Cheque", Delfin.Controls.Tipos.ComboBoxConstantes.OConstantes.TipoChequera, "< Todos >", ListSortDirection.Ascending);

            dtpFecIni.NSFecha = new DateTime(Presenter.Fecha.Year, Presenter.Fecha.Month, 1);
            dtpFecFin.NSFecha = dtpFecIni.NSFecha.Value.AddMonths(1).AddDays(-1);

         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error cargando la vista.", ex); }
      }

      #endregion

      #region [ Metodos ]
      private void Imprimir()
      {
         try
         {
            GetFiltros();
            if (Validar())
            {
               Presenter.Imprimir();
            }
            else
            {
               Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Presenter.Title, "Existen campos obligatorios, revise los detalles.", MensajeError);
            }
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error cargando el reporte.", ex); }
      }

      private Boolean Validar()
      {
         try
         {
            Boolean iscorrect = true;
            MensajeError = "";
            if (Presenter.F_CUBA_Codigo == null)
            {
               iscorrect = false;
               MensajeError += "* Debe registrar una Cuenta Corriente" + Environment.NewLine;
            }
            if (Presenter.F_FecIni == null)
            {
               iscorrect = false;
               MensajeError += "* Se debe registrar una fecha de Desde" + Environment.NewLine;
            }
            if (Presenter.F_FecIni == null)
            {
               iscorrect = false;
               MensajeError += "* Se debe registrar una fecha Hasta" + Environment.NewLine;
            }

            return iscorrect;
         }
         catch (Exception)
         { throw; }
      }

      private void GetFiltros()
      {
         try
         {
            Presenter.F_CUBA_Codigo = null;
            Presenter.F_CUBA_NroCuenta = null;
            if (txaCUBA_Codigo.SelectedItem != null)
            {
               Presenter.F_CUBA_Codigo = txaCUBA_Codigo.SelectedItem.CUBA_Codigo;
               Presenter.F_CUBA_NroCuenta = txaCUBA_Codigo.SelectedItem.CUBA_NroCuenta;
               Presenter.F_EntidadBancaria = cmbTIPO_CodBCO.Text;
            }
            Presenter.F_FecIni = dtpFecIni.NSFecha;
            Presenter.F_FecFin = dtpFecFin.NSFecha;
            Presenter.F_TipoCheque = null;
            Presenter.F_TipoCheque_Text = null;
            if (cmbTipoCheque.ConstantesSelectedItem != null)
            {
               Presenter.F_TipoCheque = cmbTipoCheque.ConstantesSelectedItem.CONS_CodTipo;
               Presenter.F_TipoCheque_Text = cmbTipoCheque.Text;
            }
            Presenter.F_MOVI_EstadoCheque = null;
            Presenter.F_MOVI_EstadoCheque_Text = null;
            if (cmbMOVI_EstadoCheque.ConstantesSelectedItem != null)
            {
               Presenter.F_MOVI_EstadoCheque = cmbMOVI_EstadoCheque.ConstantesSelectedItem.CONS_CodTipo;
               Presenter.F_MOVI_EstadoCheque_Text = cmbMOVI_EstadoCheque.Text;
            }
         }
         catch (Exception)
         { throw; }
      }
      #endregion

      #region [ Eventos ]

      private void btnImprimir_Click(object sender, EventArgs e)
      { Imprimir(); }

      #endregion


      #region [ IFormClose ]
      private void TitleView_FormClose(object sender, EventArgs e)
      {
         if (CloseForm != null)
         {
            CloseForm(null, new Infrastructure.Client.FormClose.FormCloseEventArgs(this.TabPageControl, Presenter.CUS));
         }
      }
      public event Infrastructure.Client.FormClose.FormCloseEventArgs.FormCloseEventHandler CloseForm;
      #endregion

   }
}
