using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using Delfin.Entities;
using Delfin.Principal.Properties;
using Infrastructure.Aspect.Collections;
using Infrastructure.Aspect.Constants;
using Infrastructure.Aspect.BusinessEntity;
using Infrastructure.Client.FormClose;
using Infrastructure.WinFormsControls;
using Telerik.WinControls;
using Telerik.WinControls.UI;
using Telerik.WinControls.UI.Localization;
using TiposEntidad = Delfin.Controls.TiposEntidad;
using  System.Data;
using System.Diagnostics;
using ImportarExcel = Delfin.Controls.ImportarExcel;

namespace Delfin.Principal
{
    public partial class PRO004MView : Form, IPRO004MView
   {
      #region [ Variables ]
      private bool Closing = false;
      #endregion

      #region [ Formulario ]
      public PRO004MView()
      {
         InitializeComponent();
         try
         {
             BtnGuardar.Click += BtnGuardar_Click;
             BtnImportar.Click += BtnImportar_Click;
             btnExportar.Click += btnExportar_Click;

            /* Detalle Tarjas */
             BSItemsDetalle = new BindingSource();
             BSItemsDetalle.CurrentItemChanged += BSItemsDetalle_CurrentItemChanged;
             grdItems.CommandCellClick += grdItems_CommandCellClick;
             grdItems.CellFormatting += grdItems_CellFormatting;
            
         }
         catch (Exception ex)
         { Dialogos.MostrarMensajeError(Presenter.Title, Mensajes.ConstructorView, ex); }
      }
      #endregion

      #region [ Propiedades ]
      public PRO004Presenter Presenter { get; set; }
      public BindingSource BSItemsDetalle { get; set; }
      
      private Hashtable HashFormulario { get; set; }
      #endregion

      #region [ IPRO004MView ]
      public void LoadView()
      {
         try
         {
            AyudaEntidadCliente.ContainerService = Presenter.ContainerService;
            AyudaEntidadDepTemporal.ContainerService = Presenter.ContainerService;

            CbTIPO_CodMND.LoadControl(Presenter.ContainerService, "Tabla Moneda", "MND", "< Selecione Moneda >", ListSortDirection.Descending); 
            AyudaEntidadCliente.TipoEntidad = TiposEntidad.TIPE_Cliente;
            AyudaEntidadDepTemporal.TipoEntidad = TiposEntidad.TIPE_DepositoTemporal;
            FormatDataGrid();
         }
         catch (Exception ex)
         { Dialogos.MostrarMensajeError(Presenter.Title, Mensajes.LoadView, ex); }
      }

      #region [Encabezado Tarjas ]
      public void ClearItem()
      {
          try
          {
              AyudaEntidadCliente.ClearValue();
              AyudaEntidadDepTemporal.ClearValue();
              txtTARJ_Valor.Value = 0;
              txtTARJ_Valor.Text = @"0";
              CbTIPO_CodMND.SelectedIndex = 0;
          }
          catch (Exception ex)
          { Dialogos.MostrarMensajeError(Presenter.Title, Mensajes.ClearItem, ex); }
      }
      public void GetItem()
      {
          try
          {
              if (AyudaEntidadCliente.Value != null && AyudaEntidadCliente.Value.ENTC_Codigo > 0 )
              {
                  Presenter.ItemCab_Tarjas.ENTC_Cliente = AyudaEntidadCliente.Value.ENTC_Codigo;
              }
              else
              {
                  Presenter.ItemCab_Tarjas.ENTC_Cliente =null;
              }
              if (AyudaEntidadDepTemporal.Value != null && AyudaEntidadDepTemporal.Value.ENTC_Codigo > 0)
              {
                  Presenter.ItemCab_Tarjas.ENTC_DepTemporal = AyudaEntidadDepTemporal.Value.ENTC_Codigo;
              }
              else
              {
                  Presenter.ItemCab_Tarjas.ENTC_DepTemporal = null;
              }
              Presenter.ItemCab_Tarjas.TIPO_CodMND = CbTIPO_CodMND.SelectedValue != null ? CbTIPO_CodMND.SelectedValue.ToString() : null;
              Presenter.ItemCab_Tarjas.TARJ_Valor = txtTARJ_Valor.Value > 0 ? txtTARJ_Valor.Value : 0;
              
          }                              
          catch (Exception ex)
          { Dialogos.MostrarMensajeError(Presenter.Title, Mensajes.GetItem, ex); }
      }
      public void SetItem()
      {
          try
          {
              if (Presenter.ItemCab_Tarjas.ENTC_Cliente != null)
                  AyudaEntidadCliente.SetValue(Presenter.ItemCab_Tarjas.ENTC_Cliente.Value);
              if (Presenter.ItemCab_Tarjas.ENTC_DepTemporal != null)
                  AyudaEntidadDepTemporal.SetValue(Presenter.ItemCab_Tarjas.ENTC_DepTemporal.Value);
              CbTIPO_CodMND.SelectedValue = Presenter.ItemCab_Tarjas.TIPO_CodMND;
              txtTARJ_Valor.Value= Presenter.ItemCab_Tarjas.TARJ_Valor;
              txtTARJ_Valor.Text = Presenter.ItemCab_Tarjas.TARJ_Valor.ToString(CultureInfo.InvariantCulture);
          }
          catch (Exception ex)
          { Dialogos.MostrarMensajeError(Presenter.Title, Mensajes.SetItem, ex); }
      }
      public void SetInstance(InstanceView x_instance)
      {
          try
          {
              errorProvider1.Dispose();
              AyudaEntidadCliente.Enabled = false;
              AyudaEntidadDepTemporal.Enabled = false;
              switch (x_instance)
              {
                  case InstanceView.Default:
                      break;
                  case InstanceView.New:
                      BtnImportar.Enabled = true;
                      btnExportar.Enabled = false;
                      break;
                  case InstanceView.Edit:
                      BtnImportar.Enabled = false;
                      btnExportar.Enabled = true;
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
              Dialogos.MostrarMensajeInformacion(Presenter.Title, "Faltan ingresar datos obligatorios: ", Presenter.ItemCab_Tarjas.MensajeError, Dialogos.Boton.Detalles);
              FormShowErrorProvider<Cab_Tarjas>.Validate(Presenter.ItemCab_Tarjas, this, errorProvider1);
          }
          catch (Exception ex)
          { Dialogos.MostrarMensajeError(Presenter.Title, Mensajes.ShowItems, ex); }
      }
     
      #endregion

      #region [ Detalle Tarjas ]
      public void ShowItemsDetalleTarjas()
      {
          try
          {
              BSItemsDetalle.DataSource = Presenter.ItemsDet_Tarjas.Where(var => var.Instance != InstanceEntity.Deleted).ToObservableCollection();
              grdItems.DataSource = BSItemsDetalle;
              navItems.BindingSource = BSItemsDetalle;
              BSItemsDetalle.ResetBindings(true);
          }
          catch (Exception ex)
          { Dialogos.MostrarMensajeError(Presenter.Title, Mensajes.ShowItems, ex); }
      }
      public void ClearItemsDetallesTarjas()
      {
          try
          {
              BSItemsDetalle.DataSource = null;
              grdItems.DataSource = null;
              navItems.BindingSource = null;
              Presenter.ItemsDet_Tarjas = new ObservableCollection<Det_Tarjas>();
          }
          catch (Exception ex)
          { Dialogos.MostrarMensajeError(Presenter.Title, Mensajes.ClearItem, ex); }
      }
      #endregion
      #endregion

      #region [ Metodos ]

      #region [ Encabezado ]
      private void Guardar()
      {
          try
          {
              if (!Presenter.GuardarTarifa()) return;
              errorProvider1.Dispose();
              Close();
          }
          catch (Exception)
          { }
      }
      private void Exportar()
      {
          try
          {
              List<String> Titulos = new List<String>();
              Titulos.Add("Exportación");
              Int32 _fila = 2;
              ExcelAportes _xls = new ExcelAportes(1, Titulos, "");
              Object[] _cabeceras = new Object[1];
              DataTable _dt = _xls.RadGridViewToDataTable(grdItems, ref _cabeceras, grdItems.FilterDescriptors.Count > 0);
              if (_dt.Rows.Count > 0)
              {
                  List<String> _listTituloFiltro = new List<String>();
                  _listTituloFiltro.Add("CLIENTE           : " + AyudaEntidadCliente.Text );
                  _listTituloFiltro.Add("DEPOSITO TEMPORAL : " + AyudaEntidadDepTemporal.Text);
                  _listTituloFiltro.Add("VALOR             : " + txtTARJ_Valor.Text);
                  _listTituloFiltro.Add("MONEDA            : " + CbTIPO_CodMND.Text);
                  _xls.InsertarTitulos(Presenter.Title, 1, ref _fila, 1, _listTituloFiltro, _cabeceras.Length);
                  _xls.addDataArray(1, _cabeceras, 1, _fila + 2, true, true);
                  _xls.addDataList(1, _dt, 1, _fila + 3, true, true);
              }
          }
          catch (Exception ex)
          { Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al exportar.", ex); }
      }
      #endregion

      #region [ Detalle ]
      private void FormatDataGrid()
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

              GridViewCommandColumn commandEditar;
              commandEditar = new GridViewCommandColumn();
              commandEditar.Name = "Edit";
              commandEditar.HeaderText = @"Editar";
              commandEditar.DefaultText = @"Editar";
              commandEditar.UseDefaultText = true;
              grdItems.Columns.Add(commandEditar);
              grdItems.Columns["Edit"].AllowSort = false;
              grdItems.Columns["Edit"].AllowFiltering = false;

              GridViewCommandColumn commandDeleteColumn;
              commandDeleteColumn = new GridViewCommandColumn();
              commandDeleteColumn.Name = "Delete";
              commandDeleteColumn.HeaderText = @"Eliminar";
              commandDeleteColumn.DefaultText = @"Eliminar";
              commandDeleteColumn.UseDefaultText = true;
              grdItems.Columns.Add(commandDeleteColumn);
              grdItems.Columns["Delete"].AllowSort = false;
              grdItems.Columns["Delete"].AllowFiltering = false;

              grdItems.Columns.Add("Correlativo", "Item", "Correlativo");
              grdItems.Columns["Correlativo"].Width = 40;

              grdItems.Columns.Add("Cantidad", "Cantidad", "Cantidad");
              grdItems.Columns["Cantidad"].Width = 70;

              grdItems.Columns.Add("PACK_Desc", "Contenedor", "PACK_Desc");
              grdItems.Columns["PACK_Desc"].Width = 100;

              grdItems.Columns.Add("DTAJ_NroContenedor", "Nro. Contenedor", "DTAJ_NroContenedor");
              grdItems.Columns["DTAJ_NroContenedor"].Width = 200;

              grdItems.Columns.Add("CONS_Estado", "Estado", "CONS_Estado");
              grdItems.Columns["CONS_Estado"].Width = 150;
              
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
                  if (BSItemsDetalle != null && BSItemsDetalle.Current != null && BSItemsDetalle.Current is Det_Tarjas)
                  {
                      Presenter.ItemDet_Tarjas = ((Det_Tarjas)BSItemsDetalle.Current);
                      if (Presenter.ItemDet_Tarjas.DTAJ_Item > 0)
                      {
                          Presenter.ItemDet_Tarjas.Instance = InstanceEntity.Modified;
                      }
                  }
                  else { Presenter.ItemDet_Tarjas = null; }   
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

      #region [ Encabezado Tarjas ]
      void btnExportar_Click(object sender, EventArgs e)
      {
          Exportar();
      }
      void BtnImportar_Click(object sender, EventArgs e)
      {
         String Mensaje = String.Empty;
         var excel = new ImportarExcel();
          DataTable dt = excel.Excel();
          if (dt != null)
          {
               Found:
              foreach (DataRow dr in dt.Rows)
              {
                  if (String.IsNullOrEmpty(dr["DNI/RUC CLIENTE"].ToString()) && String.IsNullOrEmpty(dr["RUC DEP TEMP"].ToString()) && String.IsNullOrEmpty(dr["MONEDA"].ToString())
                      && String.IsNullOrEmpty(dr["CONTENEDOR"].ToString()) && String.IsNullOrEmpty(dr["NRO CONTENEDOR"].ToString()) && String.IsNullOrEmpty(dr["ESTADO"].ToString()))
                  {
                      dt.Rows.Remove(dr);
                      goto Found;
                  }
              }
              Presenter.ValidarExcel(ref Mensaje, dt);
              if (!String.IsNullOrEmpty(Mensaje))
              {
                  Dialogos.MostrarMensajeInformacion(Presenter.Title, "Faltan ingresar datos obligatorios: ", Mensaje, Dialogos.Boton.Detalles);
                  DialogResult dr2 = MessageBox.Show(@"Deseas corregir el archivo excel?", @"Importación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                  if (dr2 == DialogResult.Yes)
                  {
                      try
                      {
                          Process.Start(excel.RutaExcel);
                      }
                      catch (Exception ex)
                      {
                          string message = String.Format("El archivo no puede ser abierto.\n Error : {0}", ex.Message);
                          MessageBox.Show(message, @"Abrir Archivo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                      }
                  }
                  Presenter.ItemsDet_Tarjas = new ObservableCollection<Det_Tarjas>();
              }
              else
              {
                  if (Presenter.ItemCab_Tarjas.ENTC_Cliente != null)
                      AyudaEntidadCliente.SetValue(Presenter.ItemCab_Tarjas.ENTC_Cliente.Value);

                  if (Presenter.ItemCab_Tarjas.ENTC_DepTemporal != null)
                      AyudaEntidadDepTemporal.SetValue(Presenter.ItemCab_Tarjas.ENTC_DepTemporal.Value);

                  if (Presenter.ItemCab_Tarjas.TIPO_CodMND != null)
                      CbTIPO_CodMND.SelectedValue = Presenter.ItemCab_Tarjas.TIPO_CodMND;
                  txtTARJ_Valor.Value = Presenter.ItemCab_Tarjas.TARJ_Valor;
                  txtTARJ_Valor.Text = Presenter.ItemCab_Tarjas.TARJ_Valor.ToString(CultureInfo.InvariantCulture);
                  ShowItemsDetalleTarjas();
              } 
          }
      }
      void BtnGuardar_Click(object sender, EventArgs e)
      {
          Guardar();
      }
      #endregion

      #region [ Detalle Tarjas ]
      void grdItems_CellFormatting(object sender, CellFormattingEventArgs e)
      {
          try
          {
              if (!(e.CellElement is GridCommandCellElement)) return;
              if (e.Column.Name.Equals("Edit"))
              {
                  var bte = (RadButtonElement)e.CellElement.Children[0];
                  if (bte.Image == null)
                  {
                      bte.TextImageRelation = TextImageRelation.Overlay;
                      bte.DisplayStyle = DisplayStyle.Image;
                      bte.ImageAlignment = ContentAlignment.MiddleCenter;
                      bte.Image = Resources.editar16x16;
                      bte.ToolTipText = @"Editar Registro";
                      bte.AutoSize = true;
                  }
              }
              if (e.Column.Name.Equals("Delete"))
              {
                  var bte = (RadButtonElement)e.CellElement.Children[0];
                  if (bte.Image == null)
                  {
                      bte.TextImageRelation = TextImageRelation.Overlay;
                      bte.DisplayStyle = DisplayStyle.Image;
                      bte.ImageAlignment = ContentAlignment.MiddleCenter;
                      bte.Image = Resources.Sign_07;
                      bte.ToolTipText = @"Eliminar Registro";
                      bte.AutoSize = true;
                  }
              }
              if (e.CellElement.RowInfo is GridViewNewRowInfo && e.CellElement.ColumnInfo is GridViewCommandColumn)
              {
                  e.CellElement.Children[0].Visibility = ElementVisibility.Hidden;
              }
          }
          catch (Exception ex) { Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al formatear el icono." + ex.Message); }
      }
      void grdItems_CommandCellClick(object sender, EventArgs e)
      {
          try
          {
              if (!(sender is GridCommandCellElement)) return;
              switch ((((GridCommandCellElement)(sender)).CommandButton).TextElement.Text)
              {
                  case "Editar":
                      SeleccionarItem();
                         Presenter.EditarDetalleTarjas();
                      break;
                  case "Eliminar":
                      SeleccionarItem();
                      Presenter.EliminarDetalleTarjas();
                      break;
              }
          }
          catch (Exception ex)
          { Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al eliminar el registro.", ex); }
      }
      void BSItemsDetalle_CurrentItemChanged(object sender, EventArgs e)
      {
          SeleccionarItem();
      }
   
      #endregion

      #endregion
   }
}
