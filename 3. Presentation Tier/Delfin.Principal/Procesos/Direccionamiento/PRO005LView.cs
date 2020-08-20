using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Infrastructure.Aspect.Constants;
using Infrastructure.Aspect.Collections;
using Infrastructure.Aspect.BusinessEntity;
using Infrastructure.WinFormsControls;
using Telerik.WinControls;
using Telerik.WinControls.UI;
using Telerik.WinControls.UI.Localization;
using DevExpress.XtraGrid;

namespace Delfin.Principal
{
   public partial class PRO005LView : UserControl, IPRO005LView
   {
      #region [ Variables ]
      Boolean _CargaGrid = false;

      #endregion
      #region [ Formulario ]
      public PRO005LView(Telerik.WinControls.UI.RadPageViewPage x_tabPageControl)
      {
         InitializeComponent();
         try
         {
            TabPageControl = x_tabPageControl;
            BSItems = new BindingSource();
            BSItems.CurrentItemChanged += new EventHandler(BSItems_CurrentItemChanged);
            BSItemsDetalle = new BindingSource();
            BSItemsDetalle.CurrentItemChanged += new EventHandler(BSItemsDetalle_CurrentItemChanged);
            grdItemsDetalle.RowValidating += grdItemsDetalle_RowValidating;
            btnForward.Click += BtnForward_AyudaClick;
            TitleView.FormClose += TitleView_FormClose;
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, Infrastructure.Aspect.Constants.Mensajes.ConstructorView, ex); }
      }
      public void LoadView()
      {
         try
         {
            AyudaEntidadCliente.ContainerService = Presenter.ContainerService;
            AyudaEntidadDepTmp.ContainerService = Presenter.ContainerService;
            AyudaEntidadLinea.ContainerService = Presenter.ContainerService;

            AyudaEntidadCliente.TipoEntidad = Delfin.Controls.TiposEntidad.TIPE_Cliente;
            AyudaEntidadDepTmp.TipoEntidad = Delfin.Controls.TiposEntidad.TIPE_DepositoTemporal;
            AyudaEntidadLinea.TipoEntidad = Delfin.Controls.TiposEntidad.TIPE_Transportista;

            //txaNave.LoadControl(Presenter.ContainerService);
            txaNave.LoadControl(Presenter.ContainerService);

            Presenter.LoadPaquetes();
            FormatDataGrid();
            FormatDataGridDetalles();
            //mdtFecDesde.NSFecha = Presenter.Session.Fecha.AddMonths(-1);
            //mdtFecHasta.NSFecha = Presenter.Session.Fecha;
            //mdtFADesde.NSFecha = Presenter.Session.Fecha.AddMonths(-1);
            //mdtFAHasta.NSFecha = Presenter.Session.Fecha;
            //Presenter.LoadNaves();
            Deshacer();
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, Infrastructure.Aspect.Constants.Mensajes.LoadView, ex); }
      }
      #endregion
      #region [ Propiedades ]
      public Telerik.WinControls.UI.RadPageViewPage TabPageControl { get; set; }
      public Image IconView { get { return TitleView.FormIcon; } set { TitleView.FormIcon = value; } }
      public PRO005Presenter Presenter { get; set; }
      public BindingSource BSItems { get; set; }
      public BindingSource BSItemsDetalle { get; set; }

      private void FormatDataGrid()
      {
         try
         {
            Telerik.WinControls.UI.Localization.RadGridLocalizationProvider.CurrentProvider = new Infrastructure.WinForms.Controls.MySpanishRadGridLocalizationProvider();
            this.grdItems.Columns.Clear();
            this.grdItems.AllowAddNewRow = false;
            this.grdItems.AllowDeleteRow = false;
            this.grdItems.AutoGenerateColumns = false;
            this.grdItems.AllowColumnReorder = false;
            this.grdItems.EnableSorting = true;
            this.grdItems.EnableFiltering = true;
            this.grdItems.AllowRowResize = false;
            this.grdItems.AllowRowReorder = false;
            this.grdItems.AllowColumnHeaderContextMenu = false;
            this.grdItems.AllowCellContextMenu = false;
            //this.grdItems.AllowMultiColumnSorting = false;

            GridViewCheckBoxColumn ChkActualiza = new GridViewCheckBoxColumn();
            ChkActualiza.Name = "Actualiza";
            ChkActualiza.FieldName = "Actualiza";
            ChkActualiza.Width = 30;
            this.grdItems.Columns.Add(ChkActualiza);
            grdItems.Columns["Actualiza"].ReadOnly = false;
            this.grdItems.Columns.Add("CCOT_NumDoc", "OV", "CCOT_NumDoc");
            this.grdItems.Columns.Add("CDIR_FecEmision", "Fecha Emisión", "CDIR_FecEmision");
            this.grdItems.Columns.Add("CDIR_FecArribo", "Fecha Arribo", "CDIR_FecArribo");
            this.grdItems.Columns.Add("CDIR_HBL", "HBL", "CDIR_HBL");
            this.grdItems.Columns.Add("CDIR_MBL", "MBL", "CDIR_MBL");
            this.grdItems.Columns.Add("Cliente", "Cliente", "Cliente");
            this.grdItems.Columns.Add("LNaviera", "Linea Naviera", "LNaviera");
            this.grdItems.Columns.Add("DTemporal", "Depósito Temporal", "DTemporal");
            this.grdItems.Columns.Add("CDIR_Nave", "Nave", "CDIR_Nave");
            this.grdItems.Columns.Add("CDIR_Viaje", "Viaje", "CDIR_Viaje");
            this.grdItems.Columns.Add("CDIR_Codigo", "Codigo", "CDIR_Codigo");
            this.grdItems.Columns.Add("CT20", "Cont.20", "CT20");
            this.grdItems.Columns.Add("CT40", "Cont.40", "CT40");
            grdItems.Columns["CCOT_NumDoc"].Width = 90;
            grdItems.Columns["CDIR_FecEmision"].Width = 100;
            grdItems.Columns["CDIR_FecArribo"].Width = 100;
            grdItems.Columns["CDIR_HBL"].Width = 130;
            grdItems.Columns["CDIR_MBL"].Width = 130;
            grdItems.Columns["Cliente"].Width = 200;
            grdItems.Columns["LNaviera"].Width = 200;
            grdItems.Columns["DTemporal"].Width = 200;
            grdItems.Columns["CDIR_Nave"].Width = 200;
            grdItems.Columns["CDIR_Viaje"].Width = 100;
            grdItems.Columns["CDIR_FecEmision"].ReadOnly = true;
            grdItems.Columns["CDIR_FecArribo"].ReadOnly = true;
            grdItems.Columns["CDIR_HBL"].ReadOnly = true;
            grdItems.Columns["CDIR_MBL"].ReadOnly = true;
            grdItems.Columns["Cliente"].ReadOnly = true;
            grdItems.Columns["LNaviera"].ReadOnly = true;
            grdItems.Columns["DTemporal"].ReadOnly = true;
            grdItems.Columns["CDIR_Nave"].ReadOnly = true;
            grdItems.Columns["CDIR_Viaje"].ReadOnly = true;
            grdItems.Columns["CDIR_Codigo"].IsVisible = false;
            grdItems.Columns["CDIR_FecEmision"].FormatString = "{0:dd/MM/yyy}";
            grdItems.Columns["CDIR_FecArribo"].FormatString = "{0:dd/MM/yyy}";

         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, Infrastructure.Aspect.Constants.Mensajes.FormatDataGridView, ex); }
      }

      private void FormatDataGridDetalles()
      {
         try
         {
            Telerik.WinControls.UI.Localization.RadGridLocalizationProvider.CurrentProvider = new Infrastructure.WinForms.Controls.MySpanishRadGridLocalizationProvider();
            this.grdItemsDetalle.Columns.Clear();
            this.grdItemsDetalle.AllowAddNewRow = false;
            this.grdItemsDetalle.AllowDeleteRow = false;
            this.grdItemsDetalle.AutoGenerateColumns = false;
            this.grdItemsDetalle.AllowColumnReorder = false;
            this.grdItemsDetalle.AllowRowResize = false;
            //this.grdItemsDetalle.AllowRowReorder = false;
            this.grdItemsDetalle.AllowColumnHeaderContextMenu = false;
            this.grdItemsDetalle.AllowCellContextMenu = false;

            this.grdItemsDetalle.Columns.Add("DDIR_Item", "Item", "DDIR_Item");
            this.grdItemsDetalle.Columns.Add("DDIR_Cantidad", "Cantidad", "DDIR_Cantidad");
            this.grdItemsDetalle.Columns.Add("DDIR_Contenedor", "Nro. Contenedor", "DDIR_Contenedor");
            this.grdItemsDetalle.Columns.Add("DDIR_MontoTarja", "Tarja", "DDIR_MontoTarja");
            this.grdItemsDetalle.Columns.Add("DDIR_MontoRebate", "Rebate", "DDIR_MontoRebate");

            GridViewComboBoxColumn CmbPaquete = new GridViewComboBoxColumn();
            CmbPaquete.Name = "PACK_Codigo";
            CmbPaquete.HeaderText = "Contenedor";
            CmbPaquete.DataSource = Presenter.ItemsPaquete;
            CmbPaquete.ValueMember = "PACK_Codigo";
            CmbPaquete.DisplayMember = "PACK_Desc";
            CmbPaquete.FieldName = "PACK_Codigo";
            CmbPaquete.Width = 240;
            this.grdItemsDetalle.Columns.Add(CmbPaquete);
            grdItemsDetalle.Columns["PACK_Codigo"].ReadOnly = true;
            grdItemsDetalle.Columns["DDIR_Item"].Width = 100;
            grdItemsDetalle.Columns["DDIR_Cantidad"].Width = 120;
            grdItemsDetalle.Columns["DDIR_Contenedor"].Width = 150;
            grdItemsDetalle.Columns["DDIR_MontoTarja"].Width = 160;
            grdItemsDetalle.Columns["DDIR_MontoRebate"].Width = 160;
            grdItemsDetalle.Columns["DDIR_Item"].ReadOnly = true;
            grdItemsDetalle.Columns["DDIR_Cantidad"].ReadOnly = true;
            grdItemsDetalle.Columns["DDIR_Contenedor"].ReadOnly = true;
            grdItemsDetalle.Columns["DDIR_MontoTarja"].ReadOnly = true;
            grdItemsDetalle.Columns["DDIR_MontoRebate"].ReadOnly = true;

            grdItemsDetalle.Columns["DDIR_MontoRebate"].FormatString = "{0:#,##0.00}";
            grdItemsDetalle.Columns["DDIR_MontoTarja"].FormatString = "{0:#,##0.00}";

            grdItemsDetalle.Columns["DDIR_MontoRebate"].TextAlignment = ContentAlignment.MiddleRight;
            grdItemsDetalle.Columns["DDIR_MontoTarja"].TextAlignment = ContentAlignment.MiddleRight;


         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, Infrastructure.Aspect.Constants.Mensajes.FormatDataGridView, ex); }
      }

      void grdItemsDetalle_RowValidating(object sender, RowValidatingEventArgs e)
      {
         try
         {
            e.Row.ErrorText = string.Empty;
            if (e.Row is GridViewDataRowInfo)
            {

               if (e.Row.Cells["PACK_Codigo"].Value == null || ((Int32)(e.Row.Cells["PACK_Codigo"].Value) == 0))
               {
                  e.Row.ErrorText = "Debe ingresar servicio ";
                  e.Row.Cells[4].ErrorText = "Debe ingresar servicio ";
                  e.Cancel = true;
                  e.Row.Cells[4].Style.DrawFill = true;
                  e.Row.Cells[4].Style.NumberOfColors = 1;
                  e.Row.Cells[4].Style.GradientStyle = GradientStyles.Solid;
                  e.Row.Cells[4].Style.CustomizeBorder = true;
                  e.Row.Cells[4].Style.DrawBorder = true;
                  e.Row.Cells[4].Style.BorderWidth = 2;
                  e.Row.Cells[4].Style.BorderGradientStyle = GradientStyles.Solid;
                  e.Row.Cells[4].Style.BorderColor = Color.Red;
               }
               else { e.Row.Cells[4].Style.Reset(); }

            }
         }
         catch (Exception ex) { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al validar el registro." + ex.Message); }
      }

      public void ShowItems()
      {
         try
         {
            _CargaGrid = true;
            BSItems.DataSource = Presenter._dtDireccionamiento;
            grdItems.DataSource = BSItems;
            //navItems.BindingSource = BSItems;
            BSItems.ResetBindings(true);
            HabilitaBotones(grdItems.RowCount > 0 ? true : false);
            _CargaGrid = false;
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, Infrastructure.Aspect.Constants.Mensajes.ShowItems, ex); }
      }

      public void ShowItemsDetalle()
      {
         BSItemsDetalle.DataSource = Presenter._dtDireccionamiento;
         grdItemsDetalle.DataSource = BSItemsDetalle;
         BSItemsDetalle.ResetBindings(true);
      }

      private void dgvItems_RowFormatting(object sender, RowFormattingEventArgs e)
      {
         try
         {
            //if (e.RowElement.RowInfo.Cells["DTemporal"].Value == null || e.RowElement.RowInfo.Cells["DTemporal"].Value == "" )
            //{
            //   e.RowElement.Enabled = true;
            //}
            //else
            //{
            //   e.RowElement.Enabled = false;
            //}

         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al formatear las celdas de la grilla.", ex); }
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

      #region [ Eventos ]
      private void BSItems_CurrentItemChanged(object sender, EventArgs e)
      {
          if (grdItems.CurrentRow.Index > -1)
          {
              SeleccionarItem();
          }
      }
      private void BSItemsDetalle_CurrentItemChanged(object sender, EventArgs e)
      {

      }
      private void SeleccionarItem()
      {
         try
         {
            if (Presenter != null && !_CargaGrid)
            {
               if (BSItems != null && BSItems.Current != null)
               {

                  DataRowView _drv = (DataRowView)grdItems.CurrentRow.DataBoundItem;
                  DataRow _DR = _drv.Row;
                  Presenter.BuscarDetalle(Convert.ToInt32(_DR[0].ToString()));
                  //Infrastructure.WinFormsControls.GridAutoFit.Fit(this.grdItemsDetalle);
                  //Presenter.ItemDireccionamiento = ((Entities.Cab_Direccionamiento)BSItems.Current);
                  //Presenter.BuscarDetalle(Presenter.ItemDireccionamiento.CDIR_Codigo);
               }
               else
               { Presenter.ItemDireccionamiento = null; }
            }
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al seleccionar el item.", ex); }
      }
      void grdItems_ValueChanged(object sender, EventArgs e)
      {
         try
         {
            if (!(grdItems.ActiveEditor is RadCheckBoxEditor)) return;
            grdItems.EndEdit();
            grdItems.EndUpdate();
            BSItems.EndEdit();
            //Presenter.Items = (ObservableCollection<DocsVta>)BSItems.DataSource;
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido una error al activar la casilla", ex); }
      }
      #endregion
      #region [ Metodos ]
      private void btnBuscar_Click(object sender, EventArgs e)
      {
         Int32? ENTC_CodCliente = null; if (AyudaEntidadCliente.Value != null) { ENTC_CodCliente = AyudaEntidadCliente.Value.ENTC_Codigo; }
         Int32? ENTC_CodLineaN = null;  if(AyudaEntidadLinea.Value != null) ENTC_CodLineaN = AyudaEntidadLinea.Value.ENTC_Codigo;
         Int32? ENTC_CodDepositoT = null; if (AyudaEntidadDepTmp.Value != null) { ENTC_CodDepositoT = AyudaEntidadDepTmp.Value.ENTC_Codigo; }
         //Int16 NAVE_Cod = Convert.ToInt16(NAVE_Codigo.SelectedValue.ToString());
         //if (mdtFecDesde.NSFecha != null || mdtFecHasta.NSFecha != null)
         Presenter.Buscar(mdtFecDesde.NSFecha, mdtFecHasta.NSFecha, mdtFADesde.NSFecha, mdtFAHasta.NSFecha, txtHBL.Text, txtMBL.Text, ENTC_CodCliente, ENTC_CodLineaN, ENTC_CodDepositoT, 0, txaNave.Text, txtViaje.Text);
         //else
         //{
         //   Dialogos.MostrarMensajeInformacion(Presenter.Title, "Debe ingresar rango de fechas");
         //   return;
         //}
         if (grdItems.RowCount > 0)
         {
            grdItems.Rows[0].IsSelected = true;
         }
      }

      #endregion

      private void btnAsignar_Click(object sender, EventArgs e)
      {
         try
         {
            if (AyudaEntidadDepTmp.Value == null)
            {
                Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Presenter.Title, "Debe seleccionar un depósito temporal");
            }
            else
            {
               DataTable _dt = new DataTable("DepTemporales");
               _dt.Columns.Add("Codigo", typeof(Int32));
               _dt.Columns.Add("DepTemporal", typeof(Int32));
               _dt.Columns.Add("Usuario", typeof(String));
               for (int i = 0; i < this.grdItems.RowCount; i++)
               {
                  if (grdItems.Rows[i].Cells["Actualiza"].Value != null)
                  {
                     DataRow _dr = _dt.NewRow();
                     _dr["Codigo"] = grdItems.Rows[i].Cells["CDIR_Codigo"].Value;
                     _dr["DepTemporal"] = AyudaEntidadDepTmp.Value.ENTC_Codigo;
                     _dr["Usuario"] = Presenter.Session.UserName;
                     _dt.Rows.Add(_dr);
                  }
               }
               if (_dt.Rows.Count > 0)
               {
                  Presenter.ActualizarDepTemporal(_dt);
                  btnBuscar_Click(sender, e);
               }
            }
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido una error al asignar el depósito temporal", ex); }
      }

      private void HabilitaBotones(Boolean Tipo)
      {
         btnExportar.Enabled = Tipo;
         btnAsignar.Enabled = Tipo;
         grdItems.Enabled = Tipo;
         grdItemsDetalle.Enabled = Tipo;
      }

      private void btnDeshacer_Click(object sender, EventArgs e)
      {
         Deshacer();
      }
      private void Deshacer()
      {
         try
         {
            BSItems.DataSource = null;
            BSItemsDetalle.DataSource = null;
            grdItems.DataSource = BSItems;
            BSItems.ResetBindings(true);
            BSItemsDetalle.ResetBindings(true);

            grdItems.Enabled = true;
            grdItemsDetalle.Enabled = true;
            btnBuscar.Enabled = true;
            btnAsignar.Enabled = false;
            btnExportar.Enabled = false;
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al deshacer la vista.", ex); }
      }

      private void btnExportar_Click(object sender, EventArgs e)
      {
         Exportar();
      }
      private void Exportar()
      {
         try
         {
            List<String> Titulos = new List<String>();
            Titulos.Add("Reporte");
            Int32 _fila = 2;
            ExcelAportes _xls = new ExcelAportes(1, Titulos, "");
            Object[] _cabeceras = new Object[1];
            DataTable _dt = new DataTable();
            //_dt = ((System.Data.DataTable)(((System.Windows.Forms.BindingSource)(grdItems.DataSource)).DataSource)).DataSet.Tables[0]; 
             _dt=RadGridViewToDataTable(grdItems, ref _cabeceras, grdItems.FilterDescriptors.Count > 0);
            if (_dt.Rows.Count > 0)
            {
               List<String> _listTituloFiltro = new List<String>();
               _listTituloFiltro.Add("");
               _xls.InsertarTitulos(Presenter.Title, 1, ref _fila, 1, _listTituloFiltro, _cabeceras.Length);
               _xls.addDataArray(1, _cabeceras, 1, _fila + 2, true, true);
               _xls.addDataList(1, _dt, 1, _fila + 3, true, true);
            }
         }
         catch (Exception ex)
         { Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al exportar.", ex); }
      }

      public DataTable RadGridViewToDataTable(RadGridView Grid, ref object[] _NuevasCabeceras, bool x_Filter)
      {
          DataTable dataTable = new DataTable();
          try
          {
              foreach (GridViewColumn column1 in (Collection<GridViewDataColumn>)Grid.Columns)
              {
                  if (Grid.Columns[column1.Name].DataType.FullName.ToString().StartsWith("System.Nullable`1"))
                  {
                      DataColumn column2 = new DataColumn(Grid.Columns[column1.Name].FieldName);
                      column2.AllowDBNull = true;
                      switch (Grid.Columns[column1.Name].DataType.ToString())
                      {
                          case "System.Nullable`1[System.DateTime]":
                              column2.DataType = Type.GetType("System.DateTime");
                              break;
                      }
                      dataTable.Columns.Add(column2);
                      dataTable.Columns[column1.Name].Caption = column1.HeaderText.ToUpper();
                  }
                  else
                  {
                      
                      dataTable.Columns.Add(column1.Name, Grid.Columns[column1.Name].DataType);
                      if (column1.HeaderText != null)
                      {
                          dataTable.Columns[column1.Name].Caption = column1.HeaderText.ToUpper();
                      }
                          else
                      {
                      dataTable.Columns[column1.Name].Caption = "";
                          }
                  }
              }
              if (x_Filter)
              {
                  foreach (GridViewRowInfo childRow in Grid.ChildRows)
                  {
                      DataRow row = dataTable.NewRow();
                      for (int index = 0; index < Grid.Columns.Count; ++index)
                          row[index] = childRow.Cells[index].Value == null ? (object)DBNull.Value : childRow.Cells[index].Value;
                      dataTable.Rows.Add(row);
                  }
              }
              else
              {
                  foreach (GridViewRowInfo row1 in Grid.Rows)
                  {
                      DataRow row2 = dataTable.NewRow();
                      for (int index = 0; index < Grid.Columns.Count; ++index)
                          row2[index] = row1.Cells[index].Value == null ? (object)DBNull.Value : row1.Cells[index].Value;
                      dataTable.Rows.Add(row2);
                  }
              }
              foreach (GridViewColumn column in (Collection<GridViewDataColumn>)Grid.Columns)
              {
                  if (column.IsVisible && column.Name == "Edit")
                      dataTable.Columns.Remove("Edit");
                  else if (column.IsVisible && column.Name == "Delete")
                      dataTable.Columns.Remove("Delete");
                  else if (!column.IsVisible)
                      dataTable.Columns.Remove(column.Name);
                  else if (column.IsVisible && column.Name == "DEUD_BitAgregado")
                      dataTable.Columns.Remove("DEUD_BitAgregado");
              }
              _NuevasCabeceras = new object[dataTable.Columns.Count];
              for (int index = 0; index < dataTable.Columns.Count; ++index)
                  _NuevasCabeceras[index] = (object)dataTable.Columns[index].Caption;
              return dataTable;
          }
          catch
          {
              return new DataTable();
          }
      }

      private void CargarDatosForward(DataTable _dt)
      {
         //Presenter.CDIR_Codigo = Convert.ToInt32(_dt.Rows[0]["Operacion"].ToString());
         //txtMBL.Text = _dt.Rows[0]["MBL"].ToString();
         //txtHBL.Text = _dt.Rows[0]["HBL"].ToString();
         ////Cliente.SetValue(Convert.ToInt32(dt.Rows[0]["ENTC_Codigo"].ToString()));
         //txtNave.Text = _dt.Rows[0]["Nave"].ToString();
         //txtViaje.Text = _dt.Rows[0]["Viaje"].ToString();
         //dtpCOPE_FechaEmision.Value = Convert.ToDateTime(dt.Rows[0]["COPE_FecEmi"].ToString());
         //btnHelpDetalle.Enabled = true;
      }


      private void BtnForward_AyudaClick(object sender, EventArgs e)
      {
         try
         {
            System.Data.DataTable dt = new System.Data.DataTable();
            //if (txaNave.SelectedItem != null && String.IsNullOrEmpty(txtViaje.Text))
            if (txaNave.SelectedItem != null && String.IsNullOrEmpty(txaNave.Text))
            //
            {
               Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Presenter.Title, "Debe ingresar Nave y Viaje");
               return;
            }
            String _Cliente = "";
            String _LineaN = "";
            String _Nave = null;
            if (AyudaEntidadCliente.Value != null) { _Cliente = AyudaEntidadCliente.Value.ENTC_RazonSocial; }
            if (AyudaEntidadLinea.Value != null) { _LineaN = AyudaEntidadLinea.Value.ENTC_RazonSocial; }
            if (txaNave.SelectedItem != null) { _Nave = txaNave.SelectedItem.NAVE_Nombre; }
            dt = Presenter.CargarForward(_Nave, txtViaje.Text);
            if (dt == null || dt.Rows.Count == 0)
            { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Presenter.Title, "No se encontraron coincidencias."); }
            else if (dt.Rows.Count == 1)
            {
               Presenter.AgregarDireccionamiento(dt);
            }
            else
            {
               var columnas = new System.Collections.Generic.List<Infrastructure.WinForms.Controls.ColumnaAyuda>();

               columnas.Add(new Infrastructure.WinForms.Controls.ColumnaAyuda()
               {
                  Index = 0,
                  ColumnName = "Operacion",
                  ColumnCaption = "Número",
                  Alineacion = DataGridViewContentAlignment.MiddleLeft,
                  Width = 120,
                  DataType = typeof(System.String),
                  Format = null
               });
               columnas.Add(new Infrastructure.WinForms.Controls.ColumnaAyuda()
               {
                  Index = 1,
                  ColumnName = "MBL",
                  ColumnCaption = "MBL",
                  Alineacion = DataGridViewContentAlignment.MiddleLeft,
                  Width = 150,
                  DataType = typeof(System.String),
                  Format = null
               });
               columnas.Add(new Infrastructure.WinForms.Controls.ColumnaAyuda()
               {
                  Index = 2,
                  ColumnName = "HBL",
                  ColumnCaption = "HBL",
                  Alineacion = DataGridViewContentAlignment.MiddleLeft,
                  Width = 150,
                  DataType = typeof(System.String),
                  Format = null
               });
               columnas.Add(new Infrastructure.WinForms.Controls.ColumnaAyuda()
               {
                  Index = 3,
                  ColumnName = "Cliente",
                  ColumnCaption = "Cliente",
                  Alineacion = DataGridViewContentAlignment.MiddleLeft,
                  Width = 200,
                  DataType = typeof(System.String),
                  Format = null
               });
               columnas.Add(new Infrastructure.WinForms.Controls.ColumnaAyuda()
               {
                  Index = 4,
                  ColumnName = "LNaviera",
                  ColumnCaption = "Linea Naviera",
                  Alineacion = DataGridViewContentAlignment.MiddleLeft,
                  Width = 100,
                  DataType = typeof(System.String),
                  Format = null,
               });
               columnas.Add(new Infrastructure.WinForms.Controls.ColumnaAyuda()
               {
                  Index = 5,
                  ColumnName = "TipoContenedor",
                  ColumnCaption = "Tipo Contenedor",
                  Alineacion = DataGridViewContentAlignment.MiddleLeft,
                  Width = 80,
                  DataType = typeof(System.String),
                  Format = null,
               });
               columnas.Add(new Infrastructure.WinForms.Controls.ColumnaAyuda()
               {
                  Index = 6,
                  ColumnName = "Nave",
                  ColumnCaption = "buque",
                  Alineacion = DataGridViewContentAlignment.MiddleLeft,
                  Width = 100,
                  DataType = typeof(System.String),
                  Format = null,
               });
               columnas.Add(new Infrastructure.WinForms.Controls.ColumnaAyuda()
               {
                  Index = 7,
                  ColumnName = "Viaje",
                  ColumnCaption = "Viaje",
                  Alineacion = DataGridViewContentAlignment.MiddleLeft,
                  Width = 100,
                  DataType = typeof(System.String),
                  Format = null,
               });
               columnas.Add(new Infrastructure.WinForms.Controls.ColumnaAyuda()
               {
                  Index = 8,
                  ColumnName = "FLLegada",
                  ColumnCaption = "Fecha Llegada",
                  Alineacion = DataGridViewContentAlignment.MiddleLeft,
                  Width = 100,
                  DataType = typeof(System.String),
                  Format = null,
               });
               columnas.Add(new Infrastructure.WinForms.Controls.ColumnaAyuda()
               {
                  Index = 9,
                  ColumnName = "FSalida",
                  ColumnCaption = "Fecha Salida",
                  Alineacion = DataGridViewContentAlignment.MiddleLeft,
                  Width = 100,
                  DataType = typeof(System.String),
                  Format = null,
               });
               columnas.Add(new Infrastructure.WinForms.Controls.ColumnaAyuda()
               {
                  Index = 10,
                  ColumnName = "CONTENEDORES",
                  ColumnCaption = "Cantidad Contenedores",
                  Alineacion = DataGridViewContentAlignment.MiddleRight,
                  Width = 80,
                  DataType = typeof(System.Int32),
                  Format = null,
               });
               var xAyuda = new Infrastructure.WinForms.Controls.Ayuda(Presenter.Title, dt, true, columnas, "");
               xAyuda.Width = xAyuda.Width * 2;
               if (xAyuda.ShowDialog() == DialogResult.OK)
               {
                  Presenter.AgregarDireccionamiento(xAyuda.Respuesta);
                  btnBuscar_Click(null, null);
               }
            }
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error en la importación desde el Forward", ex); }
      }
   }
}
