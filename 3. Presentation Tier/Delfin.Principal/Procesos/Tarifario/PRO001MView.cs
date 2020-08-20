using System;
using System.Collections;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Delfin.Entities;
using Delfin.Principal.Properties;
using Infrastructure.Aspect.Constants;
using Infrastructure.Aspect.Collections;
using Infrastructure.Aspect.BusinessEntity;
using Infrastructure.Client.FormClose;
using Infrastructure.WinFormsControls;
using Telerik.WinControls;
using Telerik.WinControls.UI;
using Telerik.WinControls.UI.Localization;
using TiposEntidad = Delfin.Controls.TiposEntidad;

namespace Delfin.Principal
{
   public partial class PRO001MView : Form, IPRO001MView
   {
      #region [ Variables ]
      private bool Closing = false;
      GridViewDataColumn column;
      #endregion

      #region [ Formulario ]
      public PRO001MView()
      {
         InitializeComponent();
         try
         {
            /* Encabezado */
            btnCopiar.Click += btnCopiar_Click;
            btnGuardar.Click += btnGuardar_Click;
            btnSalir.Click += btnSalir_Click;
            btnNuevoDetalleTarifa.Click += btnNuevoDetalleTarifa_Click;
            BtnAgregarServicios.Click += BtnAgregarServicios_Click;
            Load += PRO001MView_Load;

            /* Detalle Tarifario */
            BSItems = new BindingSource();
            BSItems.CurrentItemChanged += new EventHandler(BSItems_CurrentItemChanged);
            grdItems.CommandCellClick += grdItems_CommandCellClick;
            grdItems.CellFormatting += grdItems_CellFormatting;

            /* Detalle Servicio */
            BSItemsServicios = new BindingSource();
            BSItemsServicios.CurrentItemChanged += BSItemsServicios_CurrentItemChanged;
            grdItemsServicios.CommandCellClick += grdItemsServicios_CommandCellClick;
            grdItemsServicios.CellFormatting+=grdItemsServicios_CellFormatting;
         }
         catch (Exception ex)
         { Dialogos.MostrarMensajeError(Presenter.Title, Mensajes.ConstructorView, ex); }
      }

      #endregion

      #region [ Propiedades ]
      public PRO001Presenter Presenter { get; set; }
      public BindingSource BSItems { get; set; }
      public BindingSource BSItemsServicios { get; set; }
      private Hashtable HashFormulario { get; set; }
      #endregion

      #region [ IPRO001MView ]
      public void LoadView()
      {
         try
         {
            ENTC_CodigoEntidad.ContainerService = Presenter.ContainerService;

            CbCONS_CodReg.LoadControl(Presenter.ContainerService, "Tabla Régimen", "RGM", "< Seleccionar Régimen >", ListSortDirection.Descending);
            CbTIPO_CodMnd.LoadControl(Presenter.ContainerService, "Tabla Moneda", "MND", "< Selecione Moneda >", ListSortDirection.Descending);
            dtpCTAR_FecEmi.NSFecha = Presenter.Session.Fecha.Date;
            dtpCTAR_FecFin.NSFecha = Presenter.Session.Fecha.Date.AddMonths(6);
            dtpCTAR_FecIni.NSFecha = Presenter.Session.Fecha.Date;
            FormatDataGrid(Presenter.TipoTarifa);
            switch (Presenter.TipoTarifa)
            {
                case "L":
                    ENTC_CodigoEntidad.TipoEntidad = TiposEntidad.TIPE_Transportista;
                    lblTipoentidad.Text = @"Linea Naviera:";
                    TabPageRebate.Show();
                    PanelServicos.Visible = true;
                    FormatDataGridServicos(Presenter.TipoTarifa);
                    CbCONS_CodReg.Visible = true;
                    lblregimen.Visible = true;
                    Height = 643;
                    BtnAgregarServicios.Visible = true;
                    break;
                case "A":
                    ENTC_CodigoEntidad.TipoEntidad = TiposEntidad.TIPE_AgenciaAduanera;
                    lblTipoentidad.Text = @"Ag. Aduanera:";
                    TabPageRebate.Hide();
                    PanelServicos.Visible = true;
                    FormatDataGridServicos(Presenter.TipoTarifa);
                    CbCONS_CodReg.Visible = true;
                    lblregimen.Visible = true;
                    BtnAgregarServicios.Visible = true;
                    Height = 643;
                    break;
                case "T":
                    lblTipoentidad.Text = @"Transportista:";
                    ENTC_CodigoEntidad.TipoEntidad = TiposEntidad.TIPE_Proveedor;
                    TabPageRebate.Hide();
                    PanelServicos.Visible = false;
                    CbCONS_CodReg.Visible = false;
                    lblregimen.Visible = false;
                    Height = 496;
                    BtnAgregarServicios.Visible = false;
                    break;
            }
         }
         catch (Exception ex)
         { Dialogos.MostrarMensajeError(Presenter.Title, Mensajes.LoadView, ex); }
      }

      #region [Encabezado Tarifa ]
      public void ClearItem()
      {
          try
          {
              txtCTAR_Numero.Clear();
              dtpCTAR_FecEmi.NSFecha = null;
              txtCTAR_Descrip.Clear();
              dtpCTAR_FecFin.NSFecha = null;
              dtpCTAR_FecIni.NSFecha = null;
              CbCONS_CodReg.ConstantesSelectedValue = null;
              CbCONS_CodReg.SelectedIndex = 0;
              CbTIPO_CodMnd.SelectedIndex = 0;
              ENTC_CodigoEntidad.ClearValue();
              txtCTAR_Profit.Clear();
              txtCTAR_Profit.Text = @"0";
              txtCTAR_MontoLNaviera.Value = 0;
              txtCTAR_MontoDTemporal.Value = 0;
              chkCTAR_AgMaritimo.Checked = false;
              chkCTAR_DepTemporal.Checked = false;
              chkCTAR_DepVacio.Checked = false;

              dtpCTAR_FecEmi.NSFecha = Presenter.Session.Fecha.Date;
              dtpCTAR_FecFin.NSFecha = Presenter.Session.Fecha.Date.AddMonths(6);
              dtpCTAR_FecIni.NSFecha = Presenter.Session.Fecha.Date; 
          }
          catch (Exception ex)
          { Dialogos.MostrarMensajeError(Presenter.Title, Mensajes.ClearItem, ex); }
      }
      public void GetItem()
      {
          try
          {
              Presenter.ItemCAB_Tarifa.CTAR_Numero = txtCTAR_Numero.Text;
              if (dtpCTAR_FecEmi.NSFecha != null)
              {
                  Presenter.ItemCAB_Tarifa.CTAR_FecEmi = dtpCTAR_FecEmi.NSFecha.Value;
              }
              Presenter.ItemCAB_Tarifa.CTAR_Descrip = txtCTAR_Descrip.Text;
              if (dtpCTAR_FecFin.NSFecha != null)
              {
                  Presenter.ItemCAB_Tarifa.CTAR_FecFin = dtpCTAR_FecFin.NSFecha.Value;
              }
              if (dtpCTAR_FecIni.NSFecha != null)
              {
                  Presenter.ItemCAB_Tarifa.CTAR_FecIni = dtpCTAR_FecIni.NSFecha.Value;
              }
              if (CbCONS_CodReg.SelectedIndex > 0)
              {
                  Presenter.ItemCAB_Tarifa.CONS_CodReg = CbCONS_CodReg.ConstantesSelectedValue;
              }
              else
              {
                  Presenter.ItemCAB_Tarifa.CONS_CodReg = null;
              }
              if (CbTIPO_CodMnd.SelectedIndex > 0)
              {
                  Presenter.ItemCAB_Tarifa.TIPO_CodMnd = CbTIPO_CodMnd.SelectedValue.ToString();
              }
              else
              {
                  Presenter.ItemCAB_Tarifa.TIPO_CodMnd = null;
              }
              if (ENTC_CodigoEntidad.Value != null)
              {
                  if (ENTC_CodigoEntidad.Value.ENTC_Codigo > 0)
                  {
                      Presenter.ItemCAB_Tarifa.ENTC_Codigo = ENTC_CodigoEntidad.Value.ENTC_Codigo;
                  }
              }
              if (txtCTAR_Profit.Value > 0)
              {
                  Presenter.ItemCAB_Tarifa.CTAR_Profit = txtCTAR_Profit.Value;
              }
              else
              {
                  Presenter.ItemCAB_Tarifa.CTAR_Profit = null;
              }
              if (txtCTAR_MontoLNaviera.Value > 0)
              {
                  Presenter.ItemCAB_Tarifa.CTAR_MontoLNaviera = txtCTAR_MontoLNaviera.Value;
              }
              if (txtCTAR_MontoDTemporal.Value > 0)
              {
                  Presenter.ItemCAB_Tarifa.CTAR_MontoDTemporal = txtCTAR_MontoDTemporal.Value;
              }
              Presenter.ItemCAB_Tarifa.CTAR_AgMaritimo = chkCTAR_AgMaritimo.Checked;
              Presenter.ItemCAB_Tarifa.CTAR_DepTemporal = chkCTAR_DepTemporal.Checked;
              Presenter.ItemCAB_Tarifa.CTAR_DepVacio = chkCTAR_DepVacio.Checked;
          }
          catch (Exception ex)
          { Dialogos.MostrarMensajeError(Presenter.Title, Mensajes.GetItem, ex); }
      }
      public void SetItem()
      {
          try
          {
              txtCTAR_Numero.Text = Presenter.ItemCAB_Tarifa.CTAR_Numero;
              dtpCTAR_FecEmi.NSFecha = Presenter.ItemCAB_Tarifa.CTAR_FecEmi;
              txtCTAR_Descrip.Text = Presenter.ItemCAB_Tarifa.CTAR_Descrip;
              dtpCTAR_FecFin.NSFecha = Presenter.ItemCAB_Tarifa.CTAR_FecFin;
              dtpCTAR_FecIni.NSFecha = Presenter.ItemCAB_Tarifa.CTAR_FecIni;
              CbCONS_CodReg.ConstantesSelectedValue = Presenter.ItemCAB_Tarifa.CONS_CodReg;
              CbTIPO_CodMnd.SelectedValue = Presenter.ItemCAB_Tarifa.TIPO_CodMnd;
              if (Presenter.ItemCAB_Tarifa.ENTC_Codigo != null)
              {
                  ENTC_CodigoEntidad.SetValue(Presenter.ItemCAB_Tarifa.ENTC_Codigo.Value);
              }
              if (Presenter.ItemCAB_Tarifa.CTAR_Profit != null)
              {
                  txtCTAR_Profit.Value = Presenter.ItemCAB_Tarifa.CTAR_Profit.Value;
                  txtCTAR_Profit.Text = Presenter.ItemCAB_Tarifa.CTAR_Profit.Value.ToString();
                  Presenter.Profit = Presenter.ItemCAB_Tarifa.CTAR_Profit.Value;
              }

              txtCTAR_MontoLNaviera.Value = Presenter.ItemCAB_Tarifa.CTAR_MontoLNaviera;
              txtCTAR_MontoDTemporal.Value = Presenter.ItemCAB_Tarifa.CTAR_MontoDTemporal;
              if (Presenter.ItemCAB_Tarifa.CTAR_AgMaritimo != null)
              {
                  chkCTAR_AgMaritimo.Checked = Presenter.ItemCAB_Tarifa.CTAR_AgMaritimo.Value;
              }
              if (Presenter.ItemCAB_Tarifa.CTAR_DepTemporal != null)
              {
                  chkCTAR_DepTemporal.Checked = Presenter.ItemCAB_Tarifa.CTAR_DepTemporal.Value;
              }
              if (Presenter.ItemCAB_Tarifa.CTAR_DepVacio != null)
              {
                  chkCTAR_DepVacio.Checked = Presenter.ItemCAB_Tarifa.CTAR_DepVacio.Value;
              }
          }
          catch (Exception ex)
          { Dialogos.MostrarMensajeError(Presenter.Title, Mensajes.SetItem, ex); }
      }
      public void SetInstance(InstanceView x_instance)
      {
          try
          {
              errorProvider1.Dispose();
              switch (x_instance)
              {
                  case InstanceView.Default:
                      break;
                  case InstanceView.New:
                      btnCopiar.Enabled = false;
                      HashFormulario = FormValidateChanges.iniciarComparacionFormulario(this);
                      break;
                  case InstanceView.Edit:
                      btnCopiar.Enabled = true;
                      HashFormulario = FormValidateChanges.iniciarComparacionFormulario(this);
                      break;
                  case InstanceView.Delete:
                      break;
                  case InstanceView.Save:
                      break;
              }
          }
          catch (Exception ex)
          { Dialogos.MostrarMensajeError(Presenter.Title, Mensajes.SetInstanceView, ex); }
      }
      public void ShowValidation()
      {
          try
          {
              Dialogos.MostrarMensajeInformacion(Presenter.Title, "Faltan ingresar datos obligatorios: ", Presenter.ItemCAB_Tarifa.MensajeError, Dialogos.Boton.Detalles);
              FormShowErrorProvider<Cab_Tarifa>.Validate(Presenter.ItemCAB_Tarifa, this, errorProvider1);
          }
          catch (Exception ex)
          { Dialogos.MostrarMensajeError(Presenter.Title, Mensajes.ShowItems, ex); }
      } 
      #endregion

      #region [ Detalle Tarifario ]
      public void ClearItemsDetalles()
      {
          try
          {
              Presenter.ItemsGrillaDet_Tarifa = new ObservableCollection<Det_Tarifa>();
              Presenter.ItemsDet_Tarifa = new ObservableCollection<Det_Tarifa>();
              Presenter.ItemsDet_TarifaDelete = new ObservableCollection<Det_Tarifa> ();
              BSItems.DataSource = null;
              grdItems.DataSource = null;
              navItems.BindingSource = null;
          }
          catch (Exception ex)
          { Dialogos.MostrarMensajeError(Presenter.Title, Mensajes.ClearItem, ex); }
      }
      public void ShowItemsDetalleTarifario()
      {
          try
          {
              if (Presenter.TipoTarifa.Equals("L"))
              {
                  BSItems.DataSource = Presenter.ItemsGrillaDet_Tarifa.Where(var => var.Instance != InstanceEntity.Deleted).ToObservableCollection();
              }
              else
              {
                  BSItems.DataSource = Presenter.ItemsDet_Tarifa.Where(var => var.Instance != InstanceEntity.Deleted).ToObservableCollection();
              }
              grdItems.DataSource = BSItems;
              navItems.BindingSource = BSItems;
              BSItems.ResetBindings(true);
          }
          catch (Exception ex)
          { Dialogos.MostrarMensajeError(Presenter.Title, Mensajes.ShowItems, ex); }
      }
      #endregion

      #region [ Detalle Servicios ]
      public void ClearItemsDetalleServicios()
      {
          try
          {
              BSItemsServicios.DataSource = null;
              grdItemsServicios.DataSource = null;
              navItemsServicios.BindingSource = null;
              Presenter.ItemsDet_TarifaServicio = new ObservableCollection<Det_Tarifa_Servicio>();
          }
          catch (Exception ex)
          { Dialogos.MostrarMensajeError(Presenter.Title, Mensajes.ClearItem, ex); }
      }
      public void ShowItemsDetalleServicios()
      {
          try
          {
              BSItemsServicios.DataSource = Presenter.ItemsDet_TarifaServicio.Where(var => var.Instance != InstanceEntity.Deleted).ToObservableCollection();
              grdItemsServicios.DataSource = BSItemsServicios;
              navItemsServicios.BindingSource = BSItemsServicios;
              BSItemsServicios.ResetBindings(true);
          }
          catch (Exception ex)
          { Dialogos.MostrarMensajeError(Presenter.Title, Mensajes.ShowItems, ex); }
      }
      #endregion

      #endregion

      #region [ Metodos ]

      #region [ Encabezado ]
      private void Guardar()
      {
          try
          {
              if (Presenter.GuardarTarifa())
              {
                  errorProvider1.Dispose();
                  Close();
              }
          }
          catch (Exception)
          { }
      }
      #endregion

      #region [ Detalle ]
      private void FormatDataGrid(String x_TipoTarifa)
      {
          try
          {
              RadGridLocalizationProvider.CurrentProvider = new MySpanishRadGridLocalizationProvider();
              grdItems.Columns.Clear();
              grdItems.EnableHotTracking = true;
              grdItems.EnableAlternatingRowColor = false;
              grdItems.ShowFilteringRow = false;
              grdItems.ShowHeaderCellButtons = false;
              grdItems.TableElement.RowSpacing = 0;
              grdItems.TableElement.CellSpacing = 0;
              grdItems.EnableFiltering = false;
              grdItems.MasterTemplate.EnableFiltering = false;
              grdItems.AllowColumnHeaderContextMenu = false;
              grdItems.AllowCellContextMenu = false;
              grdItems.AllowAddNewRow = false;
              grdItems.AllowDeleteRow = false;
              grdItems.AllowEditRow = false;
              grdItems.AutoGenerateColumns = false;
              grdItems.AllowMultiColumnSorting = false;
              grdItems.AllowRowResize = false;
              grdItems.AllowColumnResize = true;
              grdItems.ShowGroupPanel = false;

              switch (x_TipoTarifa)
              {
                case "L":  /* Logistico */

                      GridViewCommandColumn commandEdiarColumn;
                      commandEdiarColumn = new GridViewCommandColumn();
                      commandEdiarColumn.Name = "Edit";
                      commandEdiarColumn.HeaderText = @"Editar";
                      commandEdiarColumn.DefaultText = @"Editar";
                      commandEdiarColumn.UseDefaultText = true;
                      grdItems.Columns.Add(commandEdiarColumn);
                      grdItems.Columns["Edit"].AllowSort = false;
                      grdItems.Columns["Edit"].AllowFiltering = false;

                      GridViewCommandColumn commandColumn;
                      commandColumn = new GridViewCommandColumn();
                      commandColumn.Name = "Delete";
                      commandColumn.HeaderText = @"Eliminar";
                      commandColumn.DefaultText = @"Eliminar";
                      commandColumn.UseDefaultText = true;
                      grdItems.Columns.Add(commandColumn);
                      grdItems.Columns["Delete"].AllowSort = false;
                      grdItems.Columns["Delete"].AllowFiltering = false;

                      grdItems.Columns.Add("TIPE_Descripcion", "Rol", "TIPE_Descripcion");
                      grdItems.Columns["TIPE_Descripcion"].Width = 120;

                      grdItems.Columns.Add("ENTC_RazonSocial", "Entidad", "ENTC_RazonSocial");
                      grdItems.Columns["ENTC_RazonSocial"].Width = 200;

                      grdItems.Columns.Add("DTAR_Costo20", "Costo", "DTAR_Costo20");
                      grdItems.Columns["DTAR_Costo20"].Width = 70;
                      grdItems.Columns["DTAR_Costo20"].FormatString = @"{0:###,##0.00}";
                      grdItems.Columns["DTAR_Costo20"].AutoSizeMode = BestFitColumnMode.DisplayedCells;
                      grdItems.Columns["DTAR_Costo20"].TextAlignment = ContentAlignment.MiddleRight;

                      grdItems.Columns.Add("DTAR_CostoSada20", "Costo Sada", "DTAR_CostoSada20");
                      grdItems.Columns["DTAR_CostoSada20"].Width = 70;
                      grdItems.Columns["DTAR_CostoSada20"].FormatString = @"{0:###,##0.00}";
                      grdItems.Columns["DTAR_CostoSada20"].AutoSizeMode = BestFitColumnMode.DisplayedCells;
                      grdItems.Columns["DTAR_CostoSada20"].TextAlignment = ContentAlignment.MiddleRight;

                      grdItems.Columns.Add("DTAR_Costo40", "Costo", "DTAR_Costo40");
                      grdItems.Columns["DTAR_Costo40"].Width = 70;
                      grdItems.Columns["DTAR_Costo40"].FormatString = @"{0:###,##0.00}";
                      grdItems.Columns["DTAR_Costo40"].AutoSizeMode = BestFitColumnMode.DisplayedCells;
                      grdItems.Columns["DTAR_Costo40"].TextAlignment = ContentAlignment.MiddleRight;

                      grdItems.Columns.Add("DTAR_CostoSada40", "Costo Sada", "DTAR_CostoSada40");
                      grdItems.Columns["DTAR_CostoSada40"].Width = 70;
                      grdItems.Columns["DTAR_CostoSada40"].FormatString = @"{0:###,##0.00}";
                      grdItems.Columns["DTAR_CostoSada40"].AutoSizeMode = BestFitColumnMode.DisplayedCells;
                      grdItems.Columns["DTAR_CostoSada40"].TextAlignment = ContentAlignment.MiddleRight;

                      grdItems.Columns.Add("DTAR_CostoHBL", "HBL", "DTAR_CostoHBL");
                      grdItems.Columns["DTAR_CostoHBL"].Width = 70;
                      grdItems.Columns["DTAR_CostoHBL"].FormatString = @"{0:###,##0.00}";
                      grdItems.Columns["DTAR_CostoHBL"].AutoSizeMode = BestFitColumnMode.DisplayedCells;
                      grdItems.Columns["DTAR_CostoHBL"].TextAlignment = ContentAlignment.MiddleRight;

                      grdItems.Columns.Add("DTAR_CostoSadaHBL", "HBL Sada", "DTAR_CostoSadaHBL");
                      grdItems.Columns["DTAR_CostoSadaHBL"].Width = 70;
                      grdItems.Columns["DTAR_CostoSadaHBL"].FormatString = @"{0:###,##0.00}";
                      grdItems.Columns["DTAR_CostoSadaHBL"].AutoSizeMode = BestFitColumnMode.DisplayedCells;
                      grdItems.Columns["DTAR_CostoSadaHBL"].TextAlignment = ContentAlignment.MiddleRight;

                      

                      ColumnGroupsViewDefinition columnGroupsView = new ColumnGroupsViewDefinition();
                      columnGroupsView.ColumnGroups.Add(new GridViewColumnGroup("Acciones"));
                      columnGroupsView.ColumnGroups.Add(new GridViewColumnGroup("Datos Generales"));
                      columnGroupsView.ColumnGroups.Add(new GridViewColumnGroup("Standar 20"));
                      columnGroupsView.ColumnGroups.Add(new GridViewColumnGroup("Standar 40"));
                      columnGroupsView.ColumnGroups.Add(new GridViewColumnGroup("HBL"));
                      
                      columnGroupsView.ColumnGroups[0].Rows.Add(new GridViewColumnGroupRow());
                      columnGroupsView.ColumnGroups[0].Rows[0].Columns.Add(grdItems.Columns["Edit"]);
                      columnGroupsView.ColumnGroups[0].Rows[0].Columns.Add(grdItems.Columns["Delete"]);

                      columnGroupsView.ColumnGroups[1].Rows.Add(new GridViewColumnGroupRow());
                      columnGroupsView.ColumnGroups[1].Rows[0].Columns.Add(grdItems.Columns["TIPE_Descripcion"]);
                      columnGroupsView.ColumnGroups[1].Rows[0].Columns.Add(grdItems.Columns["ENTC_RazonSocial"]);


                      columnGroupsView.ColumnGroups[2].Rows.Add(new GridViewColumnGroupRow());
                      columnGroupsView.ColumnGroups[2].Rows[0].Columns.Add(grdItems.Columns["DTAR_Costo20"]);
                      columnGroupsView.ColumnGroups[2].Rows[0].Columns.Add(grdItems.Columns["DTAR_CostoSada20"]);

                      columnGroupsView.ColumnGroups[3].Rows.Add(new GridViewColumnGroupRow());
                      columnGroupsView.ColumnGroups[3].Rows[0].Columns.Add(grdItems.Columns["DTAR_Costo40"]);
                      columnGroupsView.ColumnGroups[3].Rows[0].Columns.Add(grdItems.Columns["DTAR_CostoSada40"]);

                      columnGroupsView.ColumnGroups[4].Rows.Add(new GridViewColumnGroupRow());
                      columnGroupsView.ColumnGroups[4].Rows[0].Columns.Add(grdItems.Columns["DTAR_CostoHBL"]);
                      columnGroupsView.ColumnGroups[4].Rows[0].Columns.Add(grdItems.Columns["DTAR_CostoSadaHBL"]);

                      grdItems.ViewDefinition = columnGroupsView;

                      break;
                case "A":  /* Aduana */
                      GridViewCommandColumn commandEditar;
                      commandEditar = new GridViewCommandColumn();
                      commandEditar.Name = "Edit";
                      commandEditar.HeaderText = @"Editar";
                      commandEditar.DefaultText = @"Editar";
                      commandEditar.UseDefaultText = true;
                      grdItems.Columns.Add(commandEditar);
                      grdItems.Columns["Edit"].AllowSort = false;
                      grdItems.Columns["Edit"].AllowFiltering = false;
                      grdItems.Columns["Edit"].Width = 60;

                       GridViewCommandColumn commandDeleteColumn;
                       commandDeleteColumn = new GridViewCommandColumn();
                       commandDeleteColumn.Name = "Delete";
                       commandDeleteColumn.HeaderText = @"Eliminar";
                       commandDeleteColumn.DefaultText = @"Eliminar";
                       commandDeleteColumn.UseDefaultText = true;
                       grdItems.Columns.Add(commandDeleteColumn);
                       grdItems.Columns["Delete"].AllowSort = false;
                       grdItems.Columns["Delete"].AllowFiltering = false;

                       grdItems.Columns.Add("CONS_Desc_SPA", "Base", "CONS_Desc_SPA");
                       grdItems.Columns["CONS_Desc_SPA"].Width = 300;

                       grdItems.Columns.Add("DTAR_Costo", "Valor", "DTAR_Costo");
                       grdItems.Columns["DTAR_Costo"].Width = 70;
                       grdItems.Columns["DTAR_Costo"].FormatString = @"{0:###,##0.00}";
                       grdItems.Columns["DTAR_Costo"].AutoSizeMode = BestFitColumnMode.DisplayedCells;
                       grdItems.Columns["DTAR_Costo"].TextAlignment = ContentAlignment.MiddleRight;

                       grdItems.Columns.Add("DTAR_Minimo", "Minimo", "DTAR_Minimo");
                       grdItems.Columns["DTAR_Minimo"].Width = 70;
                       grdItems.Columns["DTAR_Minimo"].FormatString = @"{0:###,##0.00}";
                       grdItems.Columns["DTAR_Minimo"].AutoSizeMode = BestFitColumnMode.DisplayedCells;
                       grdItems.Columns["DTAR_Minimo"].TextAlignment = ContentAlignment.MiddleRight;
                       
                      break;
                case "T":  /* Transporte */
                      GridViewCommandColumn commandEdita;
                      commandEdita = new GridViewCommandColumn();
                      commandEdita.Name = "Edit";
                      commandEdita.HeaderText = @"Editar";
                      commandEdita.DefaultText = @"Editar";
                      commandEdita.UseDefaultText = true;
                      grdItems.Columns.Add(commandEdita);
                      grdItems.Columns["Edit"].AllowSort = false;
                      grdItems.Columns["Edit"].AllowFiltering = false;
                      
                      GridViewCommandColumn commanDeleteColumn;
                      commanDeleteColumn = new GridViewCommandColumn();
                      commanDeleteColumn.Name = "Delete";
                      commanDeleteColumn.HeaderText = @"Eliminar";
                      commanDeleteColumn.DefaultText = @"Eliminar";
                      commanDeleteColumn.UseDefaultText = true;
                      grdItems.Columns.Add(commanDeleteColumn);
                      grdItems.Columns["Delete"].AllowSort = false;
                      grdItems.Columns["Delete"].AllowFiltering = false;

                      grdItems.Columns.Add("CONS_Desc_TRA", "Tipo", "CONS_Desc_TRA");
                      grdItems.Columns["CONS_Desc_TRA"].Width = 120;

                      grdItems.Columns.Add("ORIGEN", "Origen", "ORIGEN");
                      grdItems.Columns["ORIGEN"].Width = 150;

                      grdItems.Columns.Add("DESTINO", "Destino", "DESTINO");
                      grdItems.Columns["DESTINO"].Width = 150;

                      grdItems.Columns.Add("DTAR_Costo", "Costo", "DTAR_Costo");
                      grdItems.Columns["DTAR_Costo"].Width = 70;
                      grdItems.Columns["DTAR_Costo"].FormatString = @"{0:###,##0.00}";
                      grdItems.Columns["DTAR_Costo"].AutoSizeMode = BestFitColumnMode.DisplayedCells;
                      grdItems.Columns["DTAR_Costo"].TextAlignment = ContentAlignment.MiddleRight;

                      grdItems.Columns.Add("CONS_Desc_SPA", "Base", "CONS_Desc_SPA");
                      grdItems.Columns["CONS_Desc_SPA"].Width = 120;

                      GridViewCheckBoxColumn chkDTAR_Roundtrip = new GridViewCheckBoxColumn();
                      chkDTAR_Roundtrip.Name = "DTAR_Roundtrip";
                      chkDTAR_Roundtrip.HeaderText = @"Roundtrip";
                      chkDTAR_Roundtrip.FieldName = "DTAR_Roundtrip";
                      grdItems.Columns.Add(chkDTAR_Roundtrip);
                      grdItems.Columns["DTAR_Roundtrip"].Width = 65;
                      grdItems.Columns["DTAR_Roundtrip"].ReadOnly = true;
                      break;
              }
              
          }
          catch (Exception ex)
          { Dialogos.MostrarMensajeError(Presenter.Title, Mensajes.FormatDataGridView, ex); }
      }
      private void SeleccionarItem()
      {
          try
          {
              if (Presenter != null)
              {
                  if (BSItems != null && BSItems.Current != null && BSItems.Current is Det_Tarifa)
                  {
                      Presenter.ItemDET_Tarifa = ((Det_Tarifa)BSItems.Current);
                  }
                  else
                  { Presenter.ItemDET_Tarifa = null; }
              }
          }
          catch (Exception ex)
          {
              if (Presenter != null)
                  Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al seleccionar el item.", ex);
          }
      }
      #endregion

      #region [ Servicios ]
      private void FormatDataGridServicos(String x_TipoTarifa)
      {
          try
          {
              RadGridLocalizationProvider.CurrentProvider = new MySpanishRadGridLocalizationProvider();
              grdItemsServicios.Columns.Clear();
              grdItemsServicios.EnableHotTracking = true;
              grdItemsServicios.EnableAlternatingRowColor = false;
              grdItemsServicios.ShowFilteringRow = false;
              grdItemsServicios.ShowHeaderCellButtons = false;
              grdItemsServicios.TableElement.RowSpacing = 0;
              grdItemsServicios.TableElement.CellSpacing = 0;
              grdItemsServicios.EnableFiltering = false;
              grdItemsServicios.MasterTemplate.EnableFiltering = false;
              grdItemsServicios.AllowColumnHeaderContextMenu = false;
              grdItemsServicios.AllowCellContextMenu = false;
              grdItemsServicios.AllowAddNewRow = false;
              grdItemsServicios.AllowDeleteRow = false;
              grdItemsServicios.AllowEditRow = false;
              grdItemsServicios.AutoGenerateColumns = false;
              grdItemsServicios.AllowMultiColumnSorting = false;
              grdItemsServicios.AllowRowResize = false;
              grdItemsServicios.AllowColumnResize = true;
              grdItemsServicios.ShowGroupPanel = false;

              GridViewCommandColumn commandEditar;
              commandEditar = new GridViewCommandColumn();
              commandEditar.Name = "Edit";
              commandEditar.HeaderText = @"Editar";
              commandEditar.DefaultText = @"Editar";
              commandEditar.UseDefaultText = true;
              grdItemsServicios.Columns.Add(commandEditar);
              grdItemsServicios.Columns["Edit"].AllowSort = false;
              grdItemsServicios.Columns["Edit"].AllowFiltering = false;

              GridViewCommandColumn commandDeleteColumn;
              commandDeleteColumn = new GridViewCommandColumn();
              commandDeleteColumn.Name = "Delete";
              commandDeleteColumn.HeaderText = @"Eliminar";
              commandDeleteColumn.DefaultText = @"Eliminar";
              commandDeleteColumn.UseDefaultText = true;
              grdItemsServicios.Columns.Add(commandDeleteColumn);
              grdItemsServicios.Columns["Delete"].AllowSort = false;
              grdItemsServicios.Columns["Delete"].AllowFiltering = false;

              switch (x_TipoTarifa)
              {

                  case "L":  /* Logistico */
                      grdItemsServicios.Columns.Add("TIPO_Desc_Servicio", "Servicio", "TIPO_Desc_Servicio");
                      grdItemsServicios.Columns["TIPO_Desc_Servicio"].Width = 300;
                      break;
                  case "A":  /* Aduana */
                      grdItemsServicios.Columns.Add("TIPO_Desc_Servicio", "Servicio", "TIPO_Desc_Servicio");
                      grdItemsServicios.Columns["TIPO_Desc_Servicio"].Width = 300;

                      grdItemsServicios.Columns.Add("CONS_Desc_Moneda", "Moneda", "CONS_Desc_Moneda");
                      grdItemsServicios.Columns["CONS_Desc_Moneda"].Width = 90;

                      grdItemsServicios.Columns.Add("DTAS_Costo", "Valor", "DTAS_Costo");
                      grdItemsServicios.Columns["DTAS_Costo"].Width = 70;
                      grdItemsServicios.Columns["DTAS_Costo"].FormatString = "{0:###,##0.00}";
                      grdItemsServicios.Columns["DTAS_Costo"].AutoSizeMode = BestFitColumnMode.DisplayedCells;
                      grdItemsServicios.Columns["DTAS_Costo"].TextAlignment = ContentAlignment.MiddleRight;

                      GridViewCheckBoxColumn chkDTAS_IGV = new GridViewCheckBoxColumn();
                      chkDTAS_IGV.Name = "DTAS_IGV";
                      chkDTAS_IGV.HeaderText = "IGV";
                      chkDTAS_IGV.FieldName = "DTAS_IGV";
                      grdItemsServicios.Columns.Add(chkDTAS_IGV);
                      grdItemsServicios.Columns["DTAS_IGV"].Width = 50;
                      grdItemsServicios.Columns["DTAS_IGV"].ReadOnly = false;              
                      break;
                  case "T":  /* Transporte */
                      break;
              }
          }
          catch (Exception ex)
          { Dialogos.MostrarMensajeError(Presenter.Title, Mensajes.FormatDataGridView, ex); }
      }
      private void SeleccionarItemServicios()
      {
          try
          {
              if (Presenter != null)
              {
                  if (BSItemsServicios != null && BSItemsServicios.Current != null && BSItemsServicios.Current is Det_Tarifa_Servicio)
                  {
                      Presenter.ItemDet_TarifaServicio = ((Det_Tarifa_Servicio)BSItemsServicios.Current);
                  }
                  else
                  { Presenter.ItemDet_TarifaServicio = null; }
              }
          }
          catch (Exception ex)
          {
              if (Presenter != null)
                  Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al seleccionar el item.", ex);
          }
      }
      #endregion

      #endregion

      #region [ Eventos ]

      #region [ Encabezado Tarifario ]
      private void btnGuardar_Click(object sender, EventArgs e)
      { Guardar(); }
      private void btnSalir_Click(object sender, EventArgs e)
      {
          try
          {
              Close();
          }
          catch (Exception ex)
          { Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al cerrar el formulario.", ex); }
      }
      void btnCopiar_Click(object sender, EventArgs e)
      {
          Presenter.Copia();
          txtCTAR_Numero.Clear();
      }
      void PRO001MView_Load(object sender, EventArgs e)
      {
          Text = Presenter.tipe_Desc;
          TabTarifario.SelectedTab = TabPageTarifa;
      }
      #endregion

      #region [ Detalle Tarifario ]
      void btnNuevoDetalleTarifa_Click(object sender, EventArgs e)
      {
          try
          {
             if (txtCTAR_Profit.Value > 0 || Presenter.TipoTarifa.Equals("L") )
              {
                  Presenter.Profit = txtCTAR_Profit.Value;
                  Presenter.LoadDetalleTarifario(InstanceView.New);
              }
              else
              {
                  Presenter.Profit = 0;
                   Dialogos.MostrarMensajeInformacion(Presenter.Title, "Debe Ingresar Profit Primero"); 
              }
          }
          catch (Exception) { }
      }
      private void BSItems_CurrentItemChanged(object sender, EventArgs e)
      { SeleccionarItem(); }
      void grdItems_ValueChanged(object sender, EventArgs e)
      {
          try
          {
              if (grdItems.ActiveEditor is RadCheckBoxEditor)
              {
                  grdItems.EndEdit();
                  grdItems.EndUpdate();
                  BSItems.EndEdit();
                  Presenter.ItemsGrillaDet_Tarifa = (ObservableCollection<Det_Tarifa>)BSItems.DataSource;
              }
          }
          catch (Exception ex)
          { Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido una error al activar la casilla de verificación", ex); }
      }
      void grdItems_CommandCellClick(object sender, EventArgs e)
      {
          try
          {
              if (sender is GridCommandCellElement)
              {
                  switch ((((GridCommandCellElement)(sender)).CommandButton).TextElement.Text)
                  {
                      case "Editar":
                          SeleccionarItem();
                          Presenter.EditarDetalleTarifa();
                          break;
                      case "Eliminar":
                          SeleccionarItem();
                          Presenter.EliminarDetalleTarifario();
                          break;
                  }
              }
          }
          catch (Exception ex)
          { Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al eliminar el registro.", ex); }
      }
      void grdItems_CellFormatting(object sender, CellFormattingEventArgs e)
      {
          try
          {
              if (e.CellElement is GridCommandCellElement)
              {
                  if (e.Column.Name.Equals("Edit"))
                  {
                      RadButtonElement bte = (RadButtonElement)e.CellElement.Children[0];
                      if (bte.Image == null)
                      {
                          bte.TextImageRelation = TextImageRelation.Overlay;
                          bte.DisplayStyle = DisplayStyle.Image;
                          bte.ImageAlignment = ContentAlignment.MiddleCenter;
                          bte.Image = Resources.editar16x16;
                          bte.ToolTipText = "Búscar Entidad";
                          bte.AutoSize = true;
                      }
                  }
                  if (e.Column.Name.Equals("Delete"))
                  {
                      RadButtonElement bte = (RadButtonElement)e.CellElement.Children[0];
                      if (bte.Image == null)
                      {
                          bte.TextImageRelation = TextImageRelation.Overlay;
                          bte.DisplayStyle = DisplayStyle.Image;
                          bte.ImageAlignment = ContentAlignment.MiddleCenter;
                          bte.Image = Resources.Sign_07;
                          bte.ToolTipText = "Eliminar Registro";
                          bte.AutoSize = true;
                      }
                  }
                  if (e.CellElement.RowInfo is GridViewNewRowInfo && e.CellElement.ColumnInfo is GridViewCommandColumn)
                  {
                      e.CellElement.Children[0].Visibility = ElementVisibility.Hidden;
                  }
              }
              
          }
          catch (Exception ex) { Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al formatear el icono." + ex.Message); }
      }
      #endregion

      #region [ Servicios ]
      void BtnAgregarServicios_Click(object sender, EventArgs e)
      {
          try
          {
              Presenter.LoadNuevoDetalleServicioTarifa();
          }
          catch (Exception) { }
      }
      void grdItemsServicios_CellFormatting(object sender, CellFormattingEventArgs e)
      {
          try
          {
              if (e.CellElement is GridCommandCellElement)
              {
                  if (e.Column.Name.Equals("Edit"))
                  {
                      RadButtonElement bte = (RadButtonElement)e.CellElement.Children[0];
                      if (bte.Image == null)
                      {
                          bte.TextImageRelation = TextImageRelation.Overlay;
                          bte.DisplayStyle = DisplayStyle.Image;
                          bte.ImageAlignment = ContentAlignment.MiddleCenter;
                          bte.Image = Resources.editar16x16;
                          bte.ToolTipText = "Búscar Entidad";
                          bte.AutoSize = true;
                      }
                  }
                  if (e.Column.Name.Equals("Delete"))
                  {
                      RadButtonElement bte = (RadButtonElement)e.CellElement.Children[0];
                      if (bte.Image == null)
                      {
                          bte.TextImageRelation = TextImageRelation.Overlay;
                          bte.DisplayStyle = DisplayStyle.Image;
                          bte.ImageAlignment = ContentAlignment.MiddleCenter;
                          bte.Image = Resources.Sign_07;
                          bte.ToolTipText = "Eliminar Registro";
                          bte.AutoSize = true;
                      }
                  }
                  if (e.CellElement.RowInfo is GridViewNewRowInfo && e.CellElement.ColumnInfo is GridViewCommandColumn)
                  {
                      e.CellElement.Children[0].Visibility = ElementVisibility.Hidden;
                  }
              }
          }
          catch (Exception ex) { Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al formatear el icono." + ex.Message); }
      }
      void grdItemsServicios_CommandCellClick(object sender, EventArgs e)
      {
          try
          {
              if (sender is GridCommandCellElement)
              {
                  switch ((((GridCommandCellElement)(sender)).CommandButton).TextElement.Text)
                  {
                      case "Editar":
                          SeleccionarItemServicios();
                          Presenter.EditarServicioDetalleTarifa();
                          break;
                      case "Eliminar":
                          SeleccionarItem();
                          Presenter.EliminarDetalleServicioTarifa();
                          break;
                  }
              }
          }
          catch (Exception ex)
          { Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al eliminar el registro.", ex); }
      }
      void BSItemsServicios_CurrentItemChanged(object sender, EventArgs e)
      {
          SeleccionarItemServicios();
      } 
      #endregion

      private void PRO001MView_FormClosed(object sender, FormClosedEventArgs e)
      {
          Presenter.IsClosedMView();
      }

      #endregion
   }
}


