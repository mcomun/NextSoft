using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Delfin.Controls.Tipos;
using Telerik.WinControls.UI;

namespace Delfin.Principal
{
   public partial class REP009FlujoCajaLView : UserControl, IREP009FlujoCajaLView
   {
      #region [ Variables ]

      #endregion

      #region [ Formulario ]

      public REP009FlujoCajaLView(Telerik.WinControls.UI.RadPageViewPage x_tabPageControl)
      {
         InitializeComponent();
         try
         {
            TabPageControl = x_tabPageControl;
            TitleView.FormClose += new EventHandler(TitleView_FormClose);
            txaCUBA_Codigo.SelectedItemCuentaBancariaChanged += txaCUBA_Codigo_SelectedItemCuentaBancariaChanged;
            btnEnviarExcel.Click += btnEnviarExcel_Click;
            btnReporte.Click += btnReporte_Click;
            cmbTIPO_CodMND.Enabled = false;
            cmbTIPO_CodBCO.Enabled = false;
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error inicializando el formulario LView.", ex); }
      }


      #endregion

      #region [ Propiedades ]

      public Telerik.WinControls.UI.RadPageViewPage TabPageControl { get; set; }
      public Image IconView { get { return TitleView.FormIcon; } set { TitleView.FormIcon = value; } }
      public REP009FlujoCajaPresenter Presenter { get; set; }
      public String MensajeError { get; set; }
      public BindingSource BSItems { get; set; }
      
      #endregion

      #region [ REP001AuxiliarBancosLView ]

      public void LoadView()
      {
         try
         {
            this.TitleView.Caption = Presenter.Title;

            txaCUBA_Codigo.LoadControl(Presenter.ContainerService, "Ayuda de Cta Cte", Delfin.Controls.Entorno.ItemEmpresa.EMPR_Codigo, Presenter.Session.UserName, Delfin.Controls.CuentaBancaria.TipoAyuda.Normal);
            cmbTIPO_CodMND.LoadControl(Presenter.ContainerService, "Tabla Monedas", "MND", "< Seleccionar Moneda >", ListSortDirection.Ascending);
            cmbTIPO.LoadControl("Tipos de Movimiento Servicio", ComboBoxConstantes.OConstantes.TipoPeriodo, "<Seleccionar Tipo>", ListSortDirection.Ascending);

            cmbPeriodo.ValueMember = "PERIODO";
            cmbPeriodo.DisplayMember = "PERIODO";
            cmbPeriodo.DataSource = Presenter.DTPeriodos;
            cmbPeriodo.SelectedValue = DateTime.Now.Date.Year.ToString();

            cmbTIPO_CodBCO.LoadControl(Presenter.ContainerService, "Bancos", "BCO", "< Sel. Ent. Bancaria >", ListSortDirection.Ascending);

            btnReporte.Visible = Presenter.ToReport;
            pnlResultado.Visible = Presenter.ToReport;

         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error cargando la vista.", ex); }
      }

      #endregion

      #region [ Metodos ]

      private void EnviarExcel()
      {
         try
         {
            GetFiltros();
            if (Validar())
            {
               Presenter.Exportar(ref pgbar);
            }
            else
            {
               Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Presenter.Title, "Existen campos obligatorios, revise los detalles.", MensajeError);
            }
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error cargando el reporte.", ex); }
      }

      public void GenerarReporte()
      {
         try
         {
            FormatGrid();

            BSItems = new BindingSource();
            BSItems.DataSource = Presenter.DTReporte;
            grdItems.DataSource = BSItems;
            navItems.BindingSource = BSItems;

            grdItems.BestFitColumns();
         }
         catch (Exception)
         { throw; }
      }

      private void FormatGrid()
      {
         try
         {
            Telerik.WinControls.UI.Localization.RadGridLocalizationProvider.CurrentProvider = new Infrastructure.WinForms.Controls.MySpanishRadGridLocalizationProvider();
            this.grdItems.Columns.Clear();
            this.grdItems.AllowAddNewRow = false;

            this.grdItems.Columns.Add("Movimiento", "Descripción", "Movimiento");

            for (int i = 2; i < Presenter.DTReporte.Columns.Count; i++)
            {
               String[] _arrayName = Presenter.DTReporte.Columns[i].ColumnName.Split('|');
               String _name = "";
               if (_arrayName.Length > 1)
               {
                  String _nameGroup = _arrayName[0];
                  if (Presenter.TipoPresentacion == REP009FlujoCajaPresenter.Tipo.Anual)
                  {
                     String _nameMonth = _arrayName[1];
                     String _nameCol = _arrayName[2];
                     _name = String.Format("{0} [{1}]", _arrayName[2], _arrayName[1]);
                  }
                  else { _name = _arrayName[1]; }
               }
               else { _name = _arrayName[0]; }

               this.grdItems.Columns.Add(Presenter.DTReporte.Columns[i].ColumnName, _name, Presenter.DTReporte.Columns[i].ColumnName);
            }

            //if (Presenter.TipoPresentacion == REP009FlujoCajaPresenter.Tipo.Anual)
            //{

            //   int index = 0;

            //   ColumnGroupsViewDefinition columnGroupsView = new ColumnGroupsViewDefinition();

            //   columnGroupsView.ColumnGroups.Add(new GridViewColumnGroup("Descripción"));
            //   columnGroupsView.ColumnGroups[index].Rows.Add(new GridViewColumnGroupRow());
            //   columnGroupsView.ColumnGroups[index].ShowHeader = false;
            //   columnGroupsView.ColumnGroups[index].Rows[0].Columns.Add(this.grdItems.Columns["Movimiento"]);
            //   index++;

            //   // Agrupación Dinamica
            //   String[] _arrayName = Presenter.DTReporte.Columns[2].ColumnName.Split('|');
            //   String _nameGroup = _arrayName[0];
            //   String _nameMonth = _arrayName[1];
            //   String _nameCol = _arrayName[2];

            //   //columnGroupsView.ColumnGroups.Add(new GridViewColumnGroup(_nameMonth));
            //   //columnGroupsView.ColumnGroups[index].Rows.Add(new GridViewColumnGroupRow());

            //   for (int i = 2; i < Presenter.DTReporte.Columns.Count - 1; i++)
            //   {
            //      _arrayName = Presenter.DTReporte.Columns[i].ColumnName.Split('|');
            //      _nameGroup = _arrayName[0];
            //      _nameMonth = _arrayName[1];
            //      _nameCol = _arrayName[2];
            //      //if (_nameGroup.Substring(0, 6) == _arrayName[0].Substring(0, 6))
            //      //{
            //      //   columnGroupsView.ColumnGroups[index].Rows[0].Columns.Add(this.grdItems.Columns[_nameCol]);
            //      //}
            //      //else
            //      //{

            //         columnGroupsView.ColumnGroups.Add(new GridViewColumnGroup(_nameMonth));
            //         columnGroupsView.ColumnGroups[index].Rows.Add(new GridViewColumnGroupRow());
            //         columnGroupsView.ColumnGroups[index].Rows[0].Columns.Add(this.grdItems.Columns[_nameCol]);
            //         index++;
            //      //}
            //   }
            //   grdItems.ViewDefinition = columnGroupsView;
            //}

            grdItems.ReadOnly = false;
            grdItems.ShowFilteringRow = false;
            grdItems.EnableFiltering = false;
            grdItems.MasterTemplate.EnableFiltering = false;
            grdItems.EnableGrouping = false;
            grdItems.MasterTemplate.EnableGrouping = false;
            grdItems.EnableSorting = false;
            grdItems.MasterTemplate.EnableCustomSorting = false;

         }
         catch (Exception)
         { throw; }
      }

      private Boolean Validar()
      {
         try
         {
            Boolean iscorrect = true;
            //MensajeError = "";
            //if (Presenter.F_CUBA_Codigo == null)
            //{
            //    iscorrect = false;
            //    MensajeError += "* Debe registrar una Cuenta Corriente" + Environment.NewLine;
            //}
            //if (String.IsNullOrEmpty(Presenter.F_TipoMovimiento))
            //{
            //    iscorrect = false;
            //    MensajeError += "* Debe seleccionar una tipo de movimiento" + Environment.NewLine;
            //}
            //if (Presenter.F_FecIni == null)
            //{
            //    iscorrect = false;
            //    MensajeError += "* Se debe registrar una fecha de Desde" + Environment.NewLine;
            //}
            //if (Presenter.F_FecIni == null)
            //{
            //    iscorrect = false;
            //    MensajeError += "* Se debe registrar una fecha Hasta" + Environment.NewLine;
            //}

            return iscorrect;
         }
         catch (Exception)
         { throw; }
      }

      private void GetFiltros()
      {
         try
         {
            Presenter.F_Tipo = null; if (cmbTIPO.ConstantesSelectedItem != null) { Presenter.F_Tipo = cmbTIPO.ConstantesSelectedItem.CONS_CodTipo; }
            Presenter.F_Periodo = null; if (cmbPeriodo.SelectedValue != null) { Presenter.F_Periodo = cmbPeriodo.SelectedValue.ToString(); }
            Presenter.F_CUBA_Codigo = null;
            if (txaCUBA_Codigo.SelectedItem != null)
            {
               Presenter.F_CUBA_Codigo = txaCUBA_Codigo.SelectedItem.CUBA_Codigo;
               Presenter.F_EntidadBancaria = cmbTIPO_CodBCO.Text;
               Presenter.F_Moneda = cmbTIPO_CodMND.Text;
               Presenter.F_NroCuenta = txaCUBA_Codigo.SelectedItem.CUBA_NroCuenta;
            }
            Presenter.F_IncluirDiferidos = chkIncluirDiferidos.Checked;
         }
         catch (Exception)
         { throw; }
      }


      #endregion

      #region [ Eventos ]

      private void txaCUBA_Codigo_SelectedItemCuentaBancariaChanged(object sender, EventArgs e)
      {
         try
         {
            if (txaCUBA_Codigo.SelectedItem != null)
            {
               cmbTIPO_CodMND.TiposSelectedValue = txaCUBA_Codigo.SelectedItem.TIPO_CodMND;
               cmbTIPO_CodBCO.TiposSelectedValue = txaCUBA_Codigo.SelectedItem.TIPO_CodBCO;
            }
         }
         catch (Exception)
         { }
      }

      private void btnEnviarExcel_Click(object sender, EventArgs e)
      {
         Presenter.TReporte = REP009FlujoCajaPresenter.TipoReporte.Excel;
         EnviarExcel();
      }

      private void btnReporte_Click(object sender, EventArgs e)
      {
         Presenter.TReporte = REP009FlujoCajaPresenter.TipoReporte.Reporte;
         EnviarExcel();
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
