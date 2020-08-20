using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Delfin.Entities;

namespace Delfin.Principal
{
   public partial class REP004DocRecepcionadosLView : UserControl, IREP004DocRecepcionadosLView
   {
      #region [ Variables ]

      #endregion

      #region [ Formulario ]

      public REP004DocRecepcionadosLView(Telerik.WinControls.UI.RadPageViewPage x_tabPageControl)
      {
         InitializeComponent();
         try
         {
            TabPageControl = x_tabPageControl;
            TitleView.FormClose += new EventHandler(TitleView_FormClose);
            btnImprimir.Click += btnImprimir_Click;
            cmbTIPE_Codigo.SelectedIndexChanged += cmbTIPE_Codigo_SelectedIndexChanged;
            txaENTC_Codigo.Enabled = false;

            txtHBL.MaxLength = 20;
            txtMBL.MaxLength = 20;

            txaENTC_Codigo.SelectedItemChanged += txaENTC_Codigo_SelectedItemChanged;
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error inicializando el formulario LView.", ex); }
      }

      #endregion

      #region [ Propiedades ]

      public Telerik.WinControls.UI.RadPageViewPage TabPageControl { get; set; }
      public Image IconView { get { return TitleView.FormIcon; } set { TitleView.FormIcon = value; } }
      public REP004DocRecepcionadosPresenter Presenter { get; set; }
      public String MensajeError { get; set; }

      #endregion

      #region [ REP004DocRecepcionadosLView ]

      public void LoadView()
      {
         try
         {
            btnImprimir.Enabled = true;
            //this.TitleView.Caption = Presenter.Title;

            cmbTIPE_Codigo.LoadControl(Presenter.ContainerService, "Tipo de Entidad", "< Todos >", ListSortDirection.Ascending);
            txaENTC_Codigo.LoadControl(Presenter.ContainerService, Delfin.Controls.TiposEntidad.TIPE_Cliente);
            cmbTIPO_CodDetrac.LoadControl(Presenter.ContainerService, "Tipo Detracción", "DET", "< Todos >", ListSortDirection.Ascending);
            rbtnFecEmision.Checked = true;
            //dtpFecIni.NSFecha = new DateTime(Presenter.Fecha.Year, Presenter.Fecha.Month, 1);
            dtpFecFin.NSFecha = DateTime.Now;
            cmbTipoRegistro.LoadControl("Tipo de Registro", Delfin.Controls.Tipos.ComboBoxConstantes.OConstantes.TipoRegistroReporte, "< Ambos >", ListSortDirection.Ascending);
            txaNaveViaje.LoadControl(Presenter.ContainerService, Delfin.Controls.AyudaViaje.TipoAyuda.NroViaje);

            switch (Presenter.TipoReporte)
            {
               case REP004DocRecepcionadosPresenter.TReporte.Todos:  // Todos
                  ObservableCollection<TiposEntidad> bs = (ObservableCollection<TiposEntidad>)cmbTIPE_Codigo.DataSource; // Se convierte el DataSource 
                  for (int i = 0; i < bs.Count; i++)
                  {
                     if (bs[i].TIPE_Codigo == 2 || bs[i].TIPE_Codigo == 5)
                     {
                        bs.RemoveAt(i);
                     }
                  }
                  cmbTIPE_Codigo.DataSource = null;
                  cmbTIPE_Codigo.ValueMember = "TIPE_Codigo";
                  cmbTIPE_Codigo.DisplayMember = "TIPE_Descripcion";
                  cmbTIPE_Codigo.DataSource = bs;
                  cmbTIPE_Codigo.Enabled = true;
                  break;
               default:
                  cmbTIPE_Codigo.TipoEntidadSelectedValue = ((Int16)Presenter.TipoReporte);
                  cmbTIPE_Codigo.Enabled = false;
                  break;
            }
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error cargando la vista.", ex); }
      }

      public void SetTitleView(String x_title)
      {
         try
         {
            TitleView.Caption = x_title;
         }
         catch (Exception)
         { }
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
            //if (Presenter.F_FecIni == null)
            //{
            //   iscorrect = false;
            //   MensajeError += "* Se debe registrar una fecha de Desde" + Environment.NewLine;
            //}
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
            Presenter.F_TIPE_Codigo = null;
            Presenter.F_TIPE_Codigo_Text = cmbTIPE_Codigo.Text;
            if (cmbTIPE_Codigo.TipoEntidadSelectedItem != null)
            {
               Presenter.F_TIPE_Codigo = cmbTIPE_Codigo.TipoEntidadSelectedItem.TIPE_Codigo;
               Presenter.F_TIPE_Codigo_Text = cmbTIPE_Codigo.Text;
            }
            Presenter.F_ENTC_Codigo = null;
            Presenter.F_ENTC_Codigo_Text = "< Todos >";
            if (txaENTC_Codigo.SelectedItem != null)
            {
               Presenter.F_ENTC_Codigo = txaENTC_Codigo.SelectedItem.ENTC_Codigo;
               Presenter.F_ENTC_Codigo_Text = String.IsNullOrEmpty(txaENTC_Codigo.SelectedItem.ENTC_RazonSocial) ? txaENTC_Codigo.SelectedItem.ENTC_NomCompleto : txaENTC_Codigo.SelectedItem.ENTC_RazonSocial;
            }

            Presenter.F_TipoFecha = null;
            if (rbtnFecEmision.Checked) { Presenter.F_TipoFecha = rbtnFecEmision.Tag.ToString(); Presenter.F_lblFecha = rbtnFecEmision.Text; }
            if (rbtnFecVencimiento.Checked) { Presenter.F_TipoFecha = rbtnFecVencimiento.Tag.ToString(); Presenter.F_lblFecha = rbtnFecVencimiento.Text; }
            if (rbtnFecRecepcion.Checked) { Presenter.F_TipoFecha = rbtnFecRecepcion.Tag.ToString(); Presenter.F_lblFecha = rbtnFecRecepcion.Text; }
            if (rbtnFecPosPago.Checked) { Presenter.F_TipoFecha = rbtnFecPosPago.Tag.ToString(); Presenter.F_lblFecha = rbtnFecPosPago.Text; }

            Presenter.F_FecIni = dtpFecIni.NSFecha;
            Presenter.F_FecFin = dtpFecFin.NSFecha;

            Presenter.F_MBL = null; if (!String.IsNullOrEmpty(txtMBL.Text)) { Presenter.F_MBL = txtMBL.Text; }
            Presenter.F_HBL = null; if (!String.IsNullOrEmpty(txtHBL.Text)) { Presenter.F_HBL = txtHBL.Text; }
            Presenter.F_SoloMostrarPendientes = chkSoloPendientes.Checked;

            Presenter.F_ConDetraccion = chkDetracciones.Checked;
            Presenter.F_TIPO_CodDetrac = null;
            Presenter.F_TIPO_CodDetrac_Text = cmbTIPO_CodDetrac.Text;
            if (cmbTIPO_CodDetrac.TiposSelectedItem != null)
            {
               Presenter.F_TIPO_CodDetrac = cmbTIPO_CodDetrac.TiposSelectedItem.TIPO_CodTipo;
               Presenter.F_TIPO_CodDetrac_Text = cmbTIPO_CodDetrac.Text;
            }
            Presenter.F_NVIA_Codigo = null; Presenter.F_NVIA_NroViaje = null;
            if (txaNaveViaje.Value != null) 
            { 
               Presenter.F_NVIA_Codigo = (txaNaveViaje.Value as Entities.NaveViaje).NVIA_Codigo;
               Presenter.F_NVIA_NroViaje = String.Format("{0} / {1}", (txaNaveViaje.Value as Entities.NaveViaje).NVIA_NroViaje, (txaNaveViaje.Value as Entities.NaveViaje).NAVE_Nombre); 
            }

            Presenter.F_TipoRegistro = null; if (cmbTipoRegistro.ConstantesSelectedItem != null) { Presenter.F_TipoRegistro = cmbTipoRegistro.ConstantesSelectedItem.CONS_CodTipo; }
         }
         catch (Exception)
         { throw; }
      }

      #endregion

      #region [ Eventos ]

      private void btnImprimir_Click(object sender, EventArgs e)
      { Imprimir(); }

      private void cmbTIPE_Codigo_SelectedIndexChanged(object sender, EventArgs e)
      {
         try
         {
            if (cmbTIPE_Codigo.SelectedItem != null)
            {
               txaENTC_Codigo.Enabled = true;
               txaENTC_Codigo.TiposEntidad = Delfin.Controls.EntidadClear.getTipoEntidadEnum(cmbTIPE_Codigo.TipoEntidadSelectedItem.TIPE_Codigo);
            }
            else { txaENTC_Codigo.Clear(); txaENTC_Codigo.Enabled = false; }
         }
         catch (Exception)
         { }
      }

      private void txaENTC_Codigo_SelectedItemChanged(object sender, EventArgs e)
      {
         try
         {
            txaNaveViaje.ENTC_CodTranportista = null;

            if (cmbTIPE_Codigo.TipoEntidadSelectedItem != null && cmbTIPE_Codigo.TipoEntidadSelectedItem.TIPE_Codigo == Delfin.Controls.EntidadClear.GetCodigoTipoEntidad(Delfin.Controls.TiposEntidad.TIPE_Transportista))
            {
               if (txaENTC_Codigo.SelectedItem != null)
               {
                  txaNaveViaje.ENTC_CodTranportista = txaENTC_Codigo.SelectedItem.ENTC_Codigo;
                  //txaNVIA_Codigo.FechaDesde = dtpMOVI_FecEmision.NSFecha;
               }
               else
               {
                  txaNaveViaje.ENTC_CodTranportista = null;
                  txaNaveViaje.FechaDesde = null;
               }
            }
         }
         catch (Exception) { }
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
