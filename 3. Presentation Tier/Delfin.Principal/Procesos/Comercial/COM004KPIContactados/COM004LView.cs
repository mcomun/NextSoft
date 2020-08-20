using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections.ObjectModel;

namespace Delfin.Principal
{
   public partial class COM004LView : UserControl, ICOM004LView
   {
      #region [ Variables ]

      #endregion

      #region [ Formulario ]
      public COM004LView(Telerik.WinControls.UI.RadPageViewPage x_tabPageControl)
      {
         InitializeComponent();
         try
         {
            TabPageControl = x_tabPageControl;

            txeEjecutivo.TipoEntidad = Delfin.Controls.TiposEntidad.TIPE_Ejecutivo;

            btnBuscar.Click += btnBuscar_Click;
            btnDeshacer.Click += btnDeshacer_Click;
            chkPorEjecutivo.CheckedChanged += chkPorEjecutivo_CheckedChanged;
            
            TitleView.FormClose += new EventHandler(View_FormClose);
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al crear la vista.", ex); }
      }

      
      #endregion

      #region [ Propiedades ]
      public Telerik.WinControls.UI.RadPageViewPage TabPageControl { get; set; }
      public Image IconView { get { return TitleView.FormIcon; } set { TitleView.FormIcon = value; } }
      public COM004Presenter Presenter { get; set; }
      public BindingSource BSItems { get; set; }
      #endregion

      #region [ ICOM004LView ]
      public void LoadView()
      {
         try
         {
            txeEjecutivo.ContainerService = Presenter.ContainerService;
            chkPorEjecutivo.Checked = false;
            HabilitarEjecutivo(false);
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error cargando la vista.", ex); }
      }
      public void ShowItems()
      {
         try
         {
            rvwReporte.LocalReport.DataSources.Clear();
            rvwReporte.LocalReport.DataSources.Add(this.Presenter.RepDataSource);
            rvwReporte.LocalReport.ReportPath = this.Presenter.ReportPath;
            rvwReporte.LocalReport.SetParameters(this.Presenter.Parameters);
            rvwReporte.LocalReport.Refresh();
            rvwReporte.RefreshReport();
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error cargando los items.", ex); }
      }
      #endregion

      #region [ Metodos ]
      private void Buscar()
      {
         try
         {
            Presenter.CargarReporte(mdtFechaDesde.NSFecha, mdtFechaHasta.NSFecha, chkPorEjecutivo.Checked, txeEjecutivo.Value);
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al llamar al reporte.", ex); }
      }
      private void Deshacer()
      {
         try
         {
            //Presenter.LimpiarReporte();
            txeEjecutivo.ClearValue();
            txeEjecutivo.Text = string.Empty;
            mdtFechaDesde.NSFecha = null;
            mdtFechaHasta.NSFecha = null;
            rvwReporte.Clear();
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al limpiar al reporte.", ex); }
      }

      private void HabilitarEjecutivo(Boolean Habilitar)
      {
         try
         {
            txeEjecutivo.Enabled = Habilitar;
            txeEjecutivo.AyudaButton.Enabled = Habilitar;
            txeEjecutivo.ClearValue();
            txeEjecutivo.Text = String.Empty;
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al habilitar el Ejecutivo.", ex); }
      }
      #endregion

      #region [ Eventos ]
      private void btnBuscar_Click(object sender, EventArgs e)
      { Buscar(); }
      private void btnDeshacer_Click(object sender, EventArgs e)
      { Deshacer(); }

      private void chkPorEjecutivo_CheckedChanged(object sender, EventArgs e)
      { HabilitarEjecutivo(chkPorEjecutivo.Checked); }
      #endregion

      #region [ IFormClose ]
      private void View_FormClose(object sender, EventArgs e)
      {
         if (CloseForm != null)
         {
            //BusinessLogic.Colecciones.Inicializar(Presenter.Container);
            CloseForm(null, new Infrastructure.Client.FormClose.FormCloseEventArgs(this.TabPageControl, Presenter.CUS));
         }
      }
      public event Infrastructure.Client.FormClose.FormCloseEventArgs.FormCloseEventHandler CloseForm;
      #endregion
   }
}
