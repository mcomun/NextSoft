using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Delfin.Principal
{
   public partial class REP001AuxiliarBancosLView : UserControl, IREP001AuxiliarBancosLView
   {
      #region [ Variables ]

      #endregion

      #region [ Formulario ]

      public REP001AuxiliarBancosLView(Telerik.WinControls.UI.RadPageViewPage x_tabPageControl)
      {
         InitializeComponent();
         try
         {
            TabPageControl = x_tabPageControl;
            TitleView.FormClose += new EventHandler(TitleView_FormClose);

            btnImprimir.Click += btnImprimir_Click;
            txaCUBA_Codigo.SelectedItemCuentaBancariaChanged += txaCUBA_Codigo_SelectedItemCuentaBancariaChanged;

            cmbTIPO_CodBCO.Enabled = false;
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error inicializando el formulario LView.", ex); }
      }



      #endregion

      #region [ Propiedades ]

      public Telerik.WinControls.UI.RadPageViewPage TabPageControl { get; set; }
      public Image IconView { get { return TitleView.FormIcon; } set { TitleView.FormIcon = value; } }
      public REP001AuxiliarBancosPresenter Presenter { get; set; }
      public String MensajeError { get; set; }

      #endregion

      #region [ REP001AuxiliarBancosLView ]

      public void LoadView()
      {
         try
         {
            btnImprimir.Enabled = true;
            this.TitleView.Caption = Presenter.Title;

            txaCUBA_Codigo.LoadControl(Presenter.ContainerService, "Ayuda de Cta Cte", Delfin.Controls.Entorno.ItemEmpresa.EMPR_Codigo, Presenter.Session.UserName, Delfin.Controls.CuentaBancaria.TipoAyuda.Normal);
            cmbTIPO_CodBCO.LoadControl(Presenter.ContainerService, "Ayuda Bancos", "BCO", "< Sel. Entidad Bancaria >", ListSortDirection.Ascending);
            ObservableCollection<Entities.Tipos> x_listTipoMov = Presenter.Client.GetAllTiposByTipoCodTabla("MOV");
            clbMOVI_Codigo.Items.Clear();
            clbMOVI_Codigo.View = View.List;
            clbMOVI_Codigo.CheckBoxes = true;
            foreach (Entities.Tipos iTMov in x_listTipoMov)
            {
               ListViewItem item = new ListViewItem(String.Format("{0} - [{1}]", iTMov.TIPO_Desc1, iTMov.TIPO_Desc2)) { Tag = iTMov };
               item.Checked = true;
               clbMOVI_Codigo.Items.Add(item);
            }
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
            if (String.IsNullOrEmpty(Presenter.F_TipoMovimiento))
            {
               iscorrect = false;
               MensajeError += "* Debe seleccionar una tipo de movimiento" + Environment.NewLine;
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
            Presenter.F_TIPO_CodMOV = "";
            Presenter.F_TipoMovimiento = "";
            foreach (ListViewItem item in clbMOVI_Codigo.Items)
            {
               if (item.Checked)
               {
                  Presenter.F_TIPO_CodMOV += String.Format("{0}|", ((Entities.Tipos)item.Tag).TIPO_CodTipo);
                  Presenter.F_TipoMovimiento += String.Format("{0},", ((Entities.Tipos)item.Tag).TIPO_Desc1);
               }
            }
            Presenter.F_MBL = null; if (!String.IsNullOrEmpty(txtMBL.Text)) { Presenter.F_MBL = txtMBL.Text; }
            Presenter.F_HBL = null; if (!String.IsNullOrEmpty(txtHBL.Text)) { Presenter.F_HBL = txtHBL.Text; }
            Presenter.F_ConsiderarAnulados = chkConsiderarAnulados.Checked;
         }
         catch (Exception)
         { throw; }
      }


      #endregion

      #region [ Eventos ]

      private void btnImprimir_Click(object sender, EventArgs e)
      { Imprimir(); }

      private void txaCUBA_Codigo_SelectedItemCuentaBancariaChanged(object sender, EventArgs e)
      {
         try
         {
            if (txaCUBA_Codigo.SelectedItem != null) { cmbTIPO_CodBCO.TiposSelectedValue = txaCUBA_Codigo.SelectedItem.TIPO_CodBCO; }
            else { cmbTIPO_CodBCO.SelectedIndex = 0; }
         }
         catch (Exception)
         { }
      }

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
