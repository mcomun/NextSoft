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
   public partial class REP007AntiguedadDeudaLView : UserControl, IREP007AntiguedadDeudaLView
   {      
      #region [ Variables ]

      #endregion

      #region [ Formulario ]

      public REP007AntiguedadDeudaLView(Telerik.WinControls.UI.RadPageViewPage x_tabPageControl)
      {
         InitializeComponent();
         try
         {
            TabPageControl = x_tabPageControl;
            TitleView.FormClose += new EventHandler(TitleView_FormClose);

            btnImprimir.Click += btnImprimir_Click;

         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error inicializando el formulario LView.", ex); }
      }

      

      #endregion

      #region [ Propiedades ]

      public Telerik.WinControls.UI.RadPageViewPage TabPageControl { get; set; }
      public Image IconView { get { return TitleView.FormIcon; } set { TitleView.FormIcon = value; } }
      public REP007AntiguedadDeudaPresenter Presenter { get; set; }

      #endregion

      #region [ REP007AntiguedadDeudaLView ]

      public void LoadView()
      {
         try
         {
            this.TitleView.Caption = Presenter.Title;

            cmbTIPE_Codigo.LoadControl(Presenter.ContainerService, "Tipo de Entidad", "< Sel Tipo Entidad >", ListSortDirection.Ascending);
            cmbTIPE_Codigo.SelectedIndexChanged += cmbTIPE_Codigo_SelectedIndexChanged;
            txaENTC_Codigo.LoadControl(Presenter.ContainerService, Delfin.Controls.TiposEntidad.TIPE_Cliente);            
            cmbSERI_UnidadNegocio.LoadControl("Unidad de Negocio", Delfin.Controls.Tipos.ComboBoxConstantes.OConstantes.UnidadNegocio, "< Sel. Unidad Negocio >", ListSortDirection.Ascending);

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
            Presenter.F_FecIni = null; Presenter.F_FecIni = dtpFecIni.NSFecha;
            Presenter.F_FecFin = null; Presenter.F_FecFin = dtpFecFin.NSFecha;
            if (dtpFecIni.NSFecha.HasValue && dtpFecFin.NSFecha.HasValue && dtpFecIni.NSFecha.Value.Date <= dtpFecFin.NSFecha.Value.Date)
            {
               Presenter.Imprimir();
            }
            else
            {
               Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Debe ingresar una rango de fechas validas."); 
            }
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido imprimiendo el reporte.", ex); }
      }

      #endregion

      #region [ Eventos ]

      void btnImprimir_Click(object sender, EventArgs e)
      { Imprimir(); }

      private void cmbTIPE_Codigo_SelectedIndexChanged(object sender, EventArgs e)
      {
         try
         {
            if (cmbTIPE_Codigo.TipoEntidadSelectedItem != null)
            {
               txaENTC_Codigo.TiposEntidad = Delfin.Controls.EntidadClear.getTipoEntidadEnum(cmbTIPE_Codigo.TipoEntidadSelectedItem.TIPE_Codigo);
            }
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
