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
   public partial class REP008EstadoClienteLView : UserControl, IREP008EstadoClienteLView
   {      
     #region [ Variables ]

      #endregion

      #region [ Formulario ]

      public REP008EstadoClienteLView(Telerik.WinControls.UI.RadPageViewPage x_tabPageControl)
      {
         InitializeComponent();
         try
         {
            TabPageControl = x_tabPageControl;
            TitleView.FormClose += new EventHandler(TitleView_FormClose);
            btnDeshacer.Click += btnDeshacer_Click;
            btnImprimir.Click += btnImprimir_Click;
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error inicializando el formulario LView.", ex); }
      } 

      #endregion

      #region [ Propiedades ]

      public Telerik.WinControls.UI.RadPageViewPage TabPageControl { get; set; }
      public Image IconView { get { return TitleView.FormIcon; } set { TitleView.FormIcon = value; } }
      public REP008EstadoClientePresenter Presenter { get; set; }
      public String MensajeError { get; set; }
      #endregion

      #region [ REP008EstadoClienteLView ]

      public void LoadView()
      {
         try
         {
            btnDeshacer.Enabled = true;
            this.TitleView.Caption = Presenter.Title;

            
            txaENTC_Codigo.LoadControl(Presenter.ContainerService, Delfin.Controls.TiposEntidad.TIPE_Cliente);
            cmbSERI_UnidadNegocio.LoadControl("Unidad de Negocio", Delfin.Controls.Tipos.ComboBoxConstantes.OConstantes.UnidadNegocio, "< Sel. Unidad Negocio >", ListSortDirection.Ascending);

            
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error cargando la vista.", ex); }
      }

      #endregion

      #region [ Metodos ]
      private void Deshacer()
      {
          try
          {
              txaENTC_Codigo.Clear();
              txtHBL.Clear();
              txtMBL.Clear();
              dtpFecFin.NSClear();
              dtpFecIni.NSClear();
              cmbSERI_UnidadNegocio.SelectedIndex = 0;
              chkConsiderarAnulados.Checked = false;
          }
          catch (Exception ex)
          { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido al deshacer.", ex); }
      }
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
              if (Presenter.F_Entidad <=0)
              {
                  iscorrect = false;
                  MensajeError += "* Debe selecionar un Cliente" + Environment.NewLine;
              }
              if (Presenter.F_FecIni == null)
              {
                  iscorrect = false;
                  MensajeError += "* Se debe registrar una fecha de Desde" + Environment.NewLine;
              }
              if (Presenter.F_FecFin == null)
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

              if (txaENTC_Codigo.SelectedItem != null)
              {
                 Presenter.F_Entidad = txaENTC_Codigo.SelectedItem.ENTC_Codigo;
                 Presenter.F_EntidadText = txaENTC_Codigo.SelectedItem.ENTC_NomCompleto;
              }
              if (cmbSERI_UnidadNegocio.ConstantesSelectedItem != null)
              {
                  Presenter.UnidadNegocio = cmbSERI_UnidadNegocio.ConstantesSelectedItem.CONS_CodTipo;
                  Presenter.UnidadNegocioText = cmbSERI_UnidadNegocio.ConstantesSelectedItem.CONS_Desc_SPA;
              }
              Presenter.F_FecIni = dtpFecIni.NSFecha;
              Presenter.F_FecFin = dtpFecFin.NSFecha;
              Presenter.F_MBL = null; if (!String.IsNullOrEmpty(txtMBL.Text)) { Presenter.F_MBL = txtMBL.Text; }
              Presenter.F_HBL = null; if (!String.IsNullOrEmpty(txtHBL.Text)) { Presenter.F_HBL = txtHBL.Text; }
              Presenter.F_ConsiderarAnulados = chkConsiderarAnulados.Checked;
          }
          catch (Exception)
          { throw; }
      }
      #endregion

      #region [ Eventos ]
      private void btnDeshacer_Click(object sender, EventArgs e)
      { Deshacer(); }
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
