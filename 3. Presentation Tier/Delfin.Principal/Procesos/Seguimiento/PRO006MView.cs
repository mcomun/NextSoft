using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Delfin.Entities;
using Delfin.Principal.Properties;
using Infrastructure.Aspect.Constants;
using Infrastructure.Client.FormClose;
using Infrastructure.WinFormsControls;
using Telerik.WinControls;
using Telerik.WinControls.UI;
using Telerik.WinControls.UI.Localization;

namespace Delfin.Principal
{
   public partial class PRO006MView : Form, IPRO006MView
   {
      #region [ Variables ]
      private bool Closing = false;
      #endregion

      #region [ Formulario ]
      public PRO006MView()
      {
         InitializeComponent();
         try
         {
            /* Encabezado Seguimiento */
            btnGuardar.Click += btnGuardar_Click;
            btnImportar.Click += btnImportar_Click;
            btnSalir.Click+=btnSalir_Click;
            Load += PRO006MView_Load;

            /* Detalle Seguimientos */
            btnAgregarDetalle.Click += btnAgregarDetalle_Click;
            BSItems = new BindingSource();
            BSItems.CurrentItemChanged +=BSItems_CurrentItemChanged;
            grdItems.CommandCellClick += grdItems_CommandCellClick;
            grdItems.CellFormatting += grdItems_CellFormatting;

         }
         catch (Exception ex)
         { Dialogos.MostrarMensajeError(Presenter.Title, Mensajes.ConstructorView, ex); }
      }

      #endregion

      #region [ Propiedades ]
      public PRO006Presenter Presenter { get; set; }
      public BindingSource BSItems { get; set; }
      private Hashtable HashFormulario { get; set; }
      #endregion

      #region [ IPRO006MView ]
      public void LoadView()
      {
         try
         {
            ENTC_CodigoDepTemporal.ContainerService = Presenter.ContainerService;
            ENTC_CodigoEntidad.ContainerService = Presenter.ContainerService;

            FormatDataGrid();
         }
         catch (Exception ex)
         { Dialogos.MostrarMensajeError(Presenter.Title, Mensajes.LoadView, ex); }
      }

      #region [Encabezado Seguimientos ]
      public void ClearItem()
      {
          try
          {
              ENTC_CodigoEntidad.ClearValue();
              ENTC_CodigoDepTemporal.ClearValue();
              txtHBL.Clear();
              
          }
          catch (Exception ex)
          { Dialogos.MostrarMensajeError(Presenter.Title, Mensajes.ClearItem, ex); }
      }
      public void GetItem()
      {
          try
          {
              Presenter.ItemCab_Seguimientos.CSEG_HBL = !String.IsNullOrEmpty(txtHBL.Text) ? txtHBL.Text : null;
              Presenter.ItemCab_Seguimientos.COPE_Codigo = Presenter.COPE_Codigo != 0 ? Presenter.COPE_Codigo : 0;
              Presenter.ItemCab_Seguimientos.CSEG_FechaEmision = DateTime.Now;
          }
          catch (Exception ex)
          { Dialogos.MostrarMensajeError(Presenter.Title, Mensajes.GetItem, ex); }
      }
      public void SetItem()
      {
          try
          {
              txtHBL.Text = Presenter.ItemCab_Seguimientos.CSEG_HBL;
              if (Presenter.ItemCab_Seguimientos.COPE_Codigo != null)
              {
                  Presenter.COPE_Codigo = Presenter.ItemCab_Seguimientos.COPE_Codigo.Value; 
              }
              if (Presenter.ENTC_CodCliente != 0)
              {
                  ENTC_CodigoEntidad.SetValue(Presenter.ENTC_CodCliente);
              }
              else
              {
                    ENTC_CodigoEntidad.ClearValue();
              }
              /* falta deposito temporal */
              //Presenter.ItemCab_Seguimientos.CSEG_FechaEmision = DateTime.Now; 
          }
          catch (Exception ex)
          { Dialogos.MostrarMensajeError(Presenter.Title, Mensajes.SetItem, ex); }
      }
      public void SetInstance(InstanceView xInstance)
      {
          try
          {
              errorProvider1.Dispose();
              ENTC_CodigoEntidad.Enabled = false;
              ENTC_CodigoDepTemporal.Enabled = false;
              txtHBL.Enabled = false;
              switch (xInstance)
              {
                  case InstanceView.Default:
                      break;
                  case InstanceView.New:
                      btnImportar.Enabled = true;
                      Presenter.ItemDet_Seguimientos = new Det_Seguimientos();
                      HashFormulario = FormValidateChanges.iniciarComparacionFormulario(this);
                      break;
                  case InstanceView.Edit:
                      btnImportar.Enabled = false;
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
              Dialogos.MostrarMensajeInformacion(Presenter.Title, "Faltan ingresar datos obligatorios: ", Presenter.ItemCab_Seguimientos.MensajeError, Dialogos.Boton.Detalles);
              FormShowErrorProvider<Cab_Seguimientos>.Validate(Presenter.ItemCab_Seguimientos, this, errorProvider1);
          }
          catch (Exception ex)
          { Dialogos.MostrarMensajeError(Presenter.Title, Mensajes.ShowItems, ex); }
      } 
      #endregion

      #region [ Detalle Seguimientos ]
      public void ClearItemsDetalles()
      {
          try
          {
              Presenter.ItemsDet_Seguimientos = new ObservableCollection<Det_Seguimientos>();
              BSItems.DataSource = null;
          }
          catch (Exception ex)
          { Dialogos.MostrarMensajeError(Presenter.Title, Mensajes.ClearItem, ex); }
      }
      public void ShowItemsDetalles()
      {
          try
          {
              BSItems.DataSource = Presenter.ItemsDet_Seguimientos;
              grdItems.DataSource = BSItems;
              navItems.BindingSource = BSItems;
              BSItems.ResetBindings(true);
              grdItems.Enabled = grdItems.RowCount > 0;
          }
          catch (Exception ex)
          { Dialogos.MostrarMensajeError(Presenter.Title, Mensajes.ShowItems, ex); }
      }
      #endregion
      #endregion

      #region [ Metodos ]

      #region [ Encabezado Seguimiento ]
      private void Guardar()
      {
          if (!Presenter.GuardarSeguimiento()) return;
          errorProvider1.Dispose();
          Close();
      }

       private void LimpiarAyuda()
       {
           Presenter.COPE_Codigo = 0;
           txtHBL.Clear();
           Presenter.COPE_FechaArribo = null;
           Presenter.COPE_CantidadDias = null; 
       }
      private void LoadImportacion()
       {
           DataTable dt = new DataTable();
           dt = Presenter.LoadAyudaOperacion();
          if (dt != null)
          {
              if (dt.Rows.Count == 0)
              {
                  Dialogos.MostrarMensajeInformacion(Presenter.Title, "No se encontraron coincidencias.");
              }
              else if (dt.Rows.Count == 1)
              {
                  Int32 COPE_Codigo;
                  if (Int32.TryParse(dt.Rows[0]["COPE_Codigo"].ToString(), out COPE_Codigo))
                  {
                      Presenter.COPE_Codigo = COPE_Codigo;
                      ENTC_CodigoEntidad.SetValue(Convert.ToInt32(dt.Rows[0]["ENTC_CodCliente"].ToString()));
                      txtHBL.Text = dt.Rows[0]["COPE_HBL"].ToString();
                      Presenter.COPE_FechaArribo = dt.Rows[0]["COPE_FechaArribo"] != null ? (DateTime?)dt.Rows[0]["COPE_FechaArribo"]: null;
                      Presenter.COPE_CantidadDias = dt.Rows[0]["COPE_CantidadDias"] != null ? (Int16?)dt.Rows[0]["COPE_CantidadDias"]:null;
                  } else { LimpiarAyuda(); }
              }
              else
              {
                  List<ColumnaAyuda> _columnas = new List<ColumnaAyuda>();
                  _columnas.Add(new ColumnaAyuda()
                  {
                      Index = 0,
                      ColumnName = "COPE_NumDoc",
                      ColumnCaption = "Nro. Operación",
                      Alineacion = DataGridViewContentAlignment.MiddleLeft,
                      Width = 120,
                      DataType = typeof (String),
                      Format = null
                  });
                  _columnas.Add(new ColumnaAyuda()
                  {
                      Index = 1,
                      ColumnName = "COPE_FecEmi",
                      ColumnCaption = "Fecha Emisión",
                      Alineacion = DataGridViewContentAlignment.MiddleRight,
                      Width = 110,
                      DataType = typeof (DateTime),
                      Format = "dd/MM/yyyy"
                  });
                  _columnas.Add(new ColumnaAyuda()
                  {
                      Index = 2,
                      ColumnName = "COPE_HBL",
                      ColumnCaption = "HBL",
                      Alineacion = DataGridViewContentAlignment.MiddleRight,
                      Width = 100,
                      DataType = typeof (String),
                      Format = null
                  });
                  _columnas.Add(new ColumnaAyuda()
                  {
                      Index = 3,
                      ColumnName = "COPE_FechaArribo",
                      ColumnCaption = "Fecha Arribo",
                      Alineacion = DataGridViewContentAlignment.MiddleRight,
                      Width = 110,
                      DataType = typeof(DateTime),
                      Format = "dd/MM/yyyy"
                  });
                  _columnas.Add(new ColumnaAyuda()
                  {
                      Index = 4,
                      ColumnName = "CLIENTE",
                      ColumnCaption = "Cliente",
                      Alineacion = DataGridViewContentAlignment.BottomLeft,
                      Width = 200,
                      DataType = typeof(String),
                      Format = null
                  });
                  _columnas.Add(new ColumnaAyuda()
                  {
                      Index = 5,
                      ColumnName = "COPE_CantidadDias",
                      ColumnCaption = "Días",
                      Alineacion = DataGridViewContentAlignment.MiddleRight,
                      Width = 50,
                      DataType = typeof(Int16),
                      Format = null
                  });
                  _columnas.Add(new ColumnaAyuda()
                  {
                      Index = 6,
                      ColumnName = "COPE_Codigo",
                      ColumnCaption = "Código",
                      Alineacion = DataGridViewContentAlignment.MiddleRight,
                      Width = 50,
                      DataType = typeof (Int32),
                      Format = null
                  });
                  _columnas.Add(new ColumnaAyuda()
                  {
                      Index = 7,
                      ColumnName = "ENTC_CodCliente",
                      ColumnCaption = "Cliente",
                      Alineacion = DataGridViewContentAlignment.MiddleRight,
                      Width = 50,
                      DataType = typeof (Int32),
                      Format = null ,
                      
                  });
                  Ayuda x_Ayuda = new Ayuda("Ayuda Operación", dt, false, _columnas);
                  if (x_Ayuda.ShowDialog() == DialogResult.OK)
                  {
                      Int32 COPE_Codigo;
                      if (Int32.TryParse(x_Ayuda.Respuesta.Rows[0]["COPE_Codigo"].ToString(), out COPE_Codigo))
                      {
                          Presenter.COPE_Codigo = COPE_Codigo;
                          ENTC_CodigoEntidad.SetValue(Convert.ToInt32(x_Ayuda.Respuesta.Rows[0]["ENTC_CodCliente"].ToString()));
                          txtHBL.Text = x_Ayuda.Respuesta.Rows[0]["COPE_HBL"].ToString();
                          Presenter.COPE_FechaArribo = dt.Rows[0]["COPE_FechaArribo"] != null ? (DateTime?)dt.Rows[0]["COPE_FechaArribo"] : null;
                          Presenter.COPE_CantidadDias = dt.Rows[0]["COPE_CantidadDias"] != null ? (Int16?)dt.Rows[0]["COPE_CantidadDias"] : null;
                      }
                      else { LimpiarAyuda(); }
                  }
                  else { LimpiarAyuda(); }
              }
          }
          else
              Dialogos.MostrarMensajeInformacion(Presenter.Title, "No se encontraron coincidencias.");
       }
      #endregion

      #region [ Detalle Seguimiento ]
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

              grdItems.Columns.Add("Item", "Item", "Item");
              grdItems.Columns["Item"].Width = 30;
              grdItems.Columns["Item"].TextAlignment = ContentAlignment.MiddleCenter;

              grdItems.Columns.Add("DSEG_FechaArribo", "Fecha de Arribo", "DSEG_FechaArribo");
              grdItems.Columns["DSEG_FechaArribo"].Width = 100;
              grdItems.Columns["DSEG_FechaArribo"].FormatString = @"{0:dd/MM/yyyy}";
              grdItems.Columns["DSEG_FechaArribo"].AutoSizeMode = BestFitColumnMode.DisplayedCells;
              grdItems.Columns["DSEG_FechaArribo"].TextAlignment = ContentAlignment.MiddleRight;

              grdItems.Columns.Add("DSEG_FecIngresoDep", "Fecha Ingreso Dep.", "DSEG_FecIngresoDep");
              grdItems.Columns["DSEG_FecIngresoDep"].Width = 110;
              grdItems.Columns["DSEG_FecIngresoDep"].FormatString = @"{0:dd/MM/yyyy}";
              grdItems.Columns["DSEG_FecIngresoDep"].AutoSizeMode = BestFitColumnMode.DisplayedCells;
              grdItems.Columns["DSEG_FecIngresoDep"].TextAlignment = ContentAlignment.MiddleRight;

              grdItems.Columns.Add("DSEG_FecRetiroDep", "Fecha Retiro Dep.", "DSEG_FecRetiroDep");
              grdItems.Columns["DSEG_FecRetiroDep"].Width = 110;
              grdItems.Columns["DSEG_FecRetiroDep"].FormatString = @"{0:dd/MM/yyyy}";
              grdItems.Columns["DSEG_FecRetiroDep"].AutoSizeMode = BestFitColumnMode.DisplayedCells;
              grdItems.Columns["DSEG_FecRetiroDep"].TextAlignment = ContentAlignment.MiddleRight;

              grdItems.Columns.Add("DSEG_FecPago", "Fecha de Pago", "DSEG_FecPago");
              grdItems.Columns["DSEG_FecPago"].Width =95;
              grdItems.Columns["DSEG_FecPago"].FormatString = @"{0:dd/MM/yyyy}";
              grdItems.Columns["DSEG_FecPago"].AutoSizeMode = BestFitColumnMode.DisplayedCells;
              grdItems.Columns["DSEG_FecPago"].TextAlignment = ContentAlignment.MiddleRight;

              grdItems.Columns.Add("PACK_DescC", "Contenedor", "PACK_DescC");
              grdItems.Columns["PACK_DescC"].Width = 80;

              grdItems.Columns.Add("DSEG_NroContenedor", "Nro. Contenedor", "DSEG_NroContenedor");
              grdItems.Columns["DSEG_NroContenedor"].Width = 150;

              GridViewCheckBoxColumn chkDSEG_Tarja = new GridViewCheckBoxColumn();
              chkDSEG_Tarja.Name = "DSEG_Tarja";
              chkDSEG_Tarja.HeaderText = @"Tarja";
              chkDSEG_Tarja.FieldName = "DSEG_Tarja";
              grdItems.Columns.Add(chkDSEG_Tarja);
              grdItems.Columns["DSEG_Tarja"].Width = 40;
              grdItems.Columns["DSEG_Tarja"].ReadOnly = true;

              grdItems.Columns.Add("CONS_CodESSSTR", "Estado", "CONS_CodESSSTR");
              grdItems.Columns["CONS_CodESSSTR"].Width = 110;
          }
          catch (Exception ex)
          { Dialogos.MostrarMensajeError(Presenter.Title, Mensajes.FormatDataGridView, ex); }
      }
      private void SeleccionarItem()
      {
          try
          {
              if (Presenter == null) return;
              if (BSItems != null && BSItems.Current != null && BSItems.Current is Det_Seguimientos)
              {
                  Presenter.ItemDet_Seguimientos = ((Det_Seguimientos)BSItems.Current);
                  if (Presenter.ItemDet_Seguimientos.Item > 0 )
                  {
                      Presenter.ItemDet_Seguimientos.AUDI_UsrMod = Presenter.Session.UserName;
                      Presenter.ItemDet_Seguimientos.AUDI_FecMod = Presenter.Session.Fecha;
                  }
              }
              else
              { Presenter.ItemDet_Seguimientos = null; }
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

      #region [ Encabezado Seguimientos ]
      void PRO006MView_Load(object sender, EventArgs e)
      {

      }
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
      void btnImportar_Click(object sender, EventArgs e)
      {
        LoadImportacion();
      }
      
      #endregion

      #region [ Detalle Seguimientos ]
      void btnAgregarDetalle_Click(object sender, EventArgs e)
      {
        Presenter.NuevoSeguimiento();
      }
      private void BSItems_CurrentItemChanged(object sender, EventArgs e)
      { SeleccionarItem(); }
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
                          Presenter.EditarDetalleSeguimientos();
                          break;
                      case "Eliminar":
                          SeleccionarItem();
                          Presenter.EliminarDetalleSeguimientos();
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
              
          }
          catch (Exception ex) { Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al formatear el icono." + ex.Message); }
      }
      #endregion

      private void btnImportar_Click_1(object sender, EventArgs e)
      {

      }

      #endregion
   }
}


