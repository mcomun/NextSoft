using System;
using System.Collections.Generic;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections.ObjectModel;
using Infrastructure.Aspect.Collections;
using System.ComponentModel;

namespace Delfin.Principal
{
   public partial class CAJ015AsientosContablesLView : UserControl, ICAJ015AsientosContablesLView
   {
      #region [ Variables ]
      #endregion

      #region [ Formulario ]

      public CAJ015AsientosContablesLView(Telerik.WinControls.UI.RadPageViewPage x_tabPageControl)
      {
         InitializeComponent();
         try
         {
            TabPageControl = x_tabPageControl;

            btnDeshacer.Click += new EventHandler(btnDeshacer_Click);
            btnProcesarAsientos.Click += btnProcesarAsientos_Click;

            TitleView.FormClose += new EventHandler(TitleView_FormClose);
            dtpFecIni.SelectedDateChanged += dtpFecIni_SelectedDateChanged;

            txtPeriodo.MaxLength = 6;
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error inicializando el formulario LView.", ex); }
      }


      #endregion

      #region [ Propiedades ]
      public Telerik.WinControls.UI.RadPageViewPage TabPageControl { get; set; }
      public Image IconView { get { return TitleView.FormIcon; } set { TitleView.FormIcon = value; } }
      public CAJ015AsientosContablesPresenter Presenter { get; set; }
      #endregion

      #region [ ICAJ015AsientosContablesLView ]
      public void LoadView()
      {
         try
         {
            /* CONS_CodTipo = "CD", CONS_CodTabla = "TIPOASIENTO_CD", CONS_Desc_SPA = "ASIENTOS DE COMPRA - CON DETRACCION" });
             * CONS_CodTipo = "CS", CONS_CodTabla = "TIPOASIENTO_CS", CONS_Desc_SPA = "ASIENTOS DE COMPRA - SIN DETRACCION" }); 
             * CONS_CodTipo = "VE", CONS_CodTabla = "TIPOASIENTO_VE", CONS_Desc_SPA = "ASIENTOS DE VENTAS" }); 
             * CONS_CodTipo = "ST", CONS_CodTabla = "TIPOASIENTO_ST", CONS_Desc_SPA = "ASIENTOS DE STATEMENT" }); 
             * CONS_CodTipo = "CN", CONS_CodTabla = "TIPOASIENTO_CN", CONS_Desc_SPA = "CANCELACIONES" }); 
             */
            cmbTipoAsiento.LoadControl("Tipo de Asiento", Delfin.Controls.Tipos.ComboBoxConstantes.OConstantes.GeneracionTipoAsiento, "< Sel. Tipo Asiento >", ListSortDirection.Ascending);
            cmbTipoAsiento.SelectedIndexChanged += cmbTipoAsiento_SelectedIndexChanged;
            btnProcesarAsientos.Enabled = true;
            //cmbRegistro_1.LoadControl(Presenter.ContainerService, "Tipo de Asiento", "CAS", "< Tipo de Registro >", ListSortDirection.Ascending);
            cmbRegistro_1.ValueMember = "CONS_CodTipo";
            cmbRegistro_1.DisplayMember = "CONS_Desc_SPA";
            cmbRegistro_1.DataSource = Presenter.ListSubDiarios;
            cmbRegistro_1.SelectedIndexChanged += cmbRegistro_1_SelectedIndexChanged;
            cmbRegistro_2.LoadControl(Presenter.ContainerService, "Tipo de Asiento", "CAS", "< Tipo de Registro >", ListSortDirection.Ascending);
            cmbTipoAsiento_SelectedIndexChanged(null, null);
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error cargando la vista.", ex); }
      }

      private void cmbTipoAsiento_SelectedIndexChanged(object sender, EventArgs e)
      {
         try
         {
            lblNroAsiento.Visible = false;
            txtNroAsiento.Visible = false;

            lblRegistro_1.Visible = true;
            cmbRegistro_1.Visible = true;
            lblVoucher_1.Visible = true;
            txnVoucher_1.Visible = true;

            lblRegistro_2.Visible = false;
            cmbRegistro_2.Visible = false;
            lblVoucher_2.Visible = false;
            txnVoucher_2.Visible = false;

            lblRegistro_1.Enabled = true;
            cmbRegistro_1.Enabled = true;
            lblVoucher_1.Enabled = true;
            txnVoucher_1.Enabled = true;

            lblRegistro_2.Enabled = true;
            cmbRegistro_2.Enabled = true;
            lblVoucher_2.Enabled = true;
            txnVoucher_2.Enabled = true;

            txnVoucher_1.Value = 0;
            txnVoucher_2.Value = 0;
            txtNroAsiento.Clear();

            cmbRegistro_1.ValueMember = "CONS_CodTipo";
            cmbRegistro_1.DisplayMember = "CONS_Desc_SPA";

            if (dtpFecIni.NSFecha.HasValue && String.IsNullOrEmpty(txtPeriodo.Text))
            { txtPeriodo.Text = dtpFecIni.NSFecha.Value.ToString("yyyyMM"); }

            if (cmbTipoAsiento.ConstantesSelectedItem != null)
            {
               switch (cmbTipoAsiento.ConstantesSelectedItem.CONS_CodTipo)
               {
                  case "CD": // "ASIENTOS DE COMPRA - CON DETRACCION" 
                     lblRegistro_1.Text = "Reg. Sub Diario :";
                     cmbRegistro_1.DataSource = getSubDiarios("GASIENTO_SCCD");
                     cmbRegistro_1.SelectedValue = "009";
                     break;
                  case "CS": // "ASIENTOS DE COMPRA - SIN DETRACCION"
                     lblRegistro_1.Text = "Reg. Sub Diario";
                     cmbRegistro_1.DataSource = getSubDiarios("GASIENTO_SCSD");
                     break;
                  case "VE": // "ASIENTOS DE VENTAS"
                     lblRegistro_1.Text = "Reg. Sub Diario";
                     cmbRegistro_1.DataSource = getSubDiarios("GASIENTO_SV");
                     cmbRegistro_1.SelectedValue = "005";
                     break;
                  case "ST": // "ASIENTOS DE STATEMENT"
                     lblRegistro_1.Text = "Reg. Sub Diario";
                     cmbRegistro_1.DataSource = getSubDiarios("GASIENTO_SS");
                     cmbRegistro_1.SelectedValue = "016";

                     lblNroAsiento.Visible = true;
                     txtNroAsiento.Visible = true;

                     if (dtpFecIni.NSFecha.HasValue)
                     { txtNroAsiento.Text = String.Format("{0:00}0001", dtpFecIni.NSFecha.Value.Month); }

                     break;
                  case "CN": // "CANCELACIONES" 30
                     lblRegistro_1.Text = "Reg. Sub Diario";
                     cmbRegistro_1.DataSource = getSubDiarios("GASIENTO_SC");
                     cmbRegistro_1.SelectedValue = "036";
                     break;
                  case "PG": // "PAGOS" 30
                     lblRegistro_1.Text = "Reg. Sub Diario";
                     cmbRegistro_1.DataSource = getSubDiarios("GASIENTO_SP");
                     cmbRegistro_1.SelectedValue = "002";
                     cmbRegistro_1_SelectedIndexChanged(null, null);

                     break;
                  default:
                     lblRegistro_1.Text = "Reg. Sub Diario";
                     cmbRegistro_1.DataSource = Presenter.ListSubDiarios;
                     cmbRegistro_1.SelectedIndex = 0;
                     lblRegistro_2.Text = "Reg. Sub Diario";
                     lblRegistro_2.Enabled = false;
                     cmbRegistro_2.Enabled = false;
                     lblVoucher_2.Enabled = false;
                     txnVoucher_2.Enabled = false;
                     cmbRegistro_2.SelectedIndex = 0;
                     break;
               }
            }
            else
            {
               lblRegistro_1.Text = "Registro / Libro";
               cmbRegistro_1.SelectedIndex = 0;

               lblRegistro_2.Text = "Registro / Libro";
               lblRegistro_2.Enabled = false;
               cmbRegistro_2.Enabled = false;
               lblVoucher_2.Enabled = false;
               txnVoucher_2.Enabled = false;
               cmbRegistro_2.SelectedIndex = 0;
            }
         }
         catch (Exception)
         { throw; }
      }

      public ObservableCollection<Entities.Constantes> ListSubDiarios { get; set; }
      private ObservableCollection<Entities.Constantes> getSubDiarios(String x_clave)
      {
         try
         {
            Entities.Parametros _pasientos = new Entities.Parametros();
            //ObservableCollection<Entities.Constantes> _listSubDiarios = new ObservableCollection<Entities.Constantes>();
            _pasientos = Presenter.Client.GetOneParametrosByClave(x_clave);
            if (_pasientos != null)
            {
               ListSubDiarios = new ObservableCollection<Entities.Constantes>();
               foreach (String item in _pasientos.PARA_Valor.Split('|'))
               {
                  if (!String.IsNullOrEmpty(item))
                  {
                     if (item.Split('-').Length > 1)
                     {
                        Entities.Constantes x_item = Presenter.ListSubDiarios.Where(CAS => CAS.CONS_CodTipo.Equals(item.Split('-')[0])).FirstOrDefault();
                        x_item.CONS_Desc_ENG = item.Split('-')[1];
                        ListSubDiarios.Add(x_item);
                        lblRegistro_2.Visible = true; lblRegistro_2.Enabled = false;
                        cmbRegistro_2.Visible = true; cmbRegistro_2.Enabled = false;
                        txnVoucher_2.Visible = true; txnVoucher_2.Enabled = true;
                        cmbRegistro_2.SelectedValue = item.Split('-')[1];
                     }
                     else
                     {
                        ListSubDiarios.Add(Presenter.ListSubDiarios.Where(CAS => CAS.CONS_CodTipo.Equals(item)).FirstOrDefault());
                        lblRegistro_2.Visible = false;
                        cmbRegistro_2.Visible = false;
                        txnVoucher_2.Visible = false;
                     }
                  }
               }
               return ListSubDiarios.OrderBy(cas => cas.CONS_CodTipo).ToObservableCollection();
            }
            else { return Presenter.ListSubDiarios; }
         }
         catch (Exception)
         { throw; }
      }
      #endregion

      #region [ Metodos ]

      private Boolean getFiltros()
      {
         try
         {
            Presenter.F_FecIni = null; Presenter.F_FecFin = null; Presenter.F_TipoAsiento = null;

            if (dtpFecIni.NSFecha.HasValue && dtpFecFin.NSFecha.HasValue && cmbTipoAsiento.ConstantesSelectedItem != null && !String.IsNullOrEmpty(txtPeriodo.Text) && txtPeriodo.Text.Length == 6)
            {
               Presenter.F_FecIni = dtpFecIni.NSFecha;
               Presenter.F_FecFin = dtpFecFin.NSFecha;
               Presenter.F_TipoAsiento = cmbTipoAsiento.ConstantesSelectedItem.CONS_CodTipo;
               Presenter.F_Asiento = txtNroAsiento.Text;
               if (cmbTipoAsiento.ConstantesSelectedItem != null)
               {
                  if (cmbRegistro_1.SelectedValue != null)
                  { Presenter.F_Registro_1 = cmbRegistro_1.SelectedValue.ToString().Substring(1); }
                  else { Presenter.F_Registro_1 = null; }
                  if (cmbRegistro_2.SelectedValue != null)
                  { Presenter.F_Registro_2 = cmbRegistro_2.SelectedValue.ToString().Substring(1); }
                  else { Presenter.F_Registro_2 = null; }

                  Presenter.F_FecDoc = txtPeriodo.Text;
                  Presenter.F_MesReg = txtPeriodo.Text.Substring(4, 2);
                  Presenter.F_Voucher_1 = Convert.ToInt32(txnVoucher_1.Value);
                  Presenter.F_Voucher_2 = Convert.ToInt32(txnVoucher_2.Value);
               }
               else
               {
                  Presenter.F_Registro_1 = null;
                  Presenter.F_Registro_2 = null;
                  Presenter.F_Voucher_1 = null;
                  Presenter.F_Voucher_2 = null;
                  Presenter.F_FecDoc = null;
               }
               return true;
            }
            else
            {
               String _msg = "";
               if (!dtpFecIni.NSFecha.HasValue) { _msg += String.Format("- Debe ingresar una fecha de Inicio.{0}", Environment.NewLine); }
               if (!dtpFecFin.NSFecha.HasValue) { _msg += String.Format("- Debe ingresar una fecha de Termino.{0}", Environment.NewLine); }
               if (String.IsNullOrEmpty(txtPeriodo.Text)) { _msg += String.Format("- Debe ingresar una periodo valido.{0}", Environment.NewLine); }
               if (cmbTipoAsiento.ConstantesSelectedItem == null) { _msg += String.Format("- Debe seleccionar un tipo de asiento.{0}", Environment.NewLine); }
               if (!String.IsNullOrEmpty(_msg))
               { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Presenter.Title, "Existen algunos campos obligatorios, haga click de detalles para ver cuales son.", _msg); }
               return false;
            }
         }
         catch (Exception)
         { return false; }
      }

      private void ProcesarAsientos()
      {
         try
         {
            if (getFiltros())
            {
               String _mensaje;
               Presenter.ProcesarAsientos();
            }
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error, no se puede procesar la solicitud de generar asientos.", ex); }
      }

      private void Deshacer()
      {
         try
         {
            btnProcesarAsientos.Enabled = true;
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al deshacer la vista.", ex); }
      }
      #endregion

      #region [ Eventos ]

      private void btnProcesarAsientos_Click(object sender, EventArgs e)
      { ProcesarAsientos(); }

      private void btnDeshacer_Click(object sender, EventArgs e)
      { Deshacer(); }

      /// <summary>
      /// Actualizar el numero de asiento cuando es una interfaz de statement
      /// </summary>
      /// <param name="sender">The source of the event.</param>
      /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
      private void dtpFecIni_SelectedDateChanged(object sender, EventArgs e)
      {
         try
         {
            //if (dtpFecIni.NSFecha.HasValue && cmbTipoAsiento.ConstantesSelectedItem.CONS_CodTipo.Equals("ST"))
            //{ txtNroAsiento.Text = String.Format("{0:00}0001", dtpFecIni.NSFecha.Value.Month); }
            //else 
            if (dtpFecIni.NSFecha.HasValue)
            { txtPeriodo.Text = dtpFecIni.NSFecha.Value.ToString("yyyyMM"); }

         }
         catch (Exception)
         { }
      }

      private void cmbRegistro_1_SelectedIndexChanged(object sender, EventArgs e)
      {
         try
         {
            if (cmbTipoAsiento.SelectedItem != null && cmbRegistro_1.SelectedValue != null)
            {
               if (cmbTipoAsiento.ConstantesSelectedItem.CONS_CodTipo.Equals("PG"))
               {
                  cmbRegistro_2.SelectedValue = ((Entities.Constantes)cmbRegistro_1.SelectedItem).CONS_Desc_ENG;
                  if (cmbRegistro_2.SelectedValue != null)
                  {
                     lblRegistro_2.Visible = true;
                     cmbRegistro_2.Visible = true;
                     txnVoucher_2.Visible = true;
                     lblVoucher_2.Visible = true;
                  }
                  else
                  {
                     lblRegistro_2.Visible = false;
                     cmbRegistro_2.Visible = false;
                     txnVoucher_2.Visible = false;
                     lblVoucher_2.Visible = false;
                  }
               }
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
            Presenter.CloseView();
            //BusinessLogic.Colecciones.Inicializar(Presenter.Container);
            CloseForm(null, new Infrastructure.Client.FormClose.FormCloseEventArgs(this.TabPageControl, Presenter.CUS));
         }
      }
      public event Infrastructure.Client.FormClose.FormCloseEventArgs.FormCloseEventHandler CloseForm;
      #endregion
   }
}
