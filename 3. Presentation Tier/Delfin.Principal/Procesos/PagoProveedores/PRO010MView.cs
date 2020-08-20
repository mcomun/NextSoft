using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
   public partial class PRO010MView : Form, IPRO010MView
   {
      public PRO010MView()
      {
         InitializeComponent();
         try
         {
            btnGuardar.Click += btnGuardar_Click;
            btnBuscar.Click += btnBuscar_Click;
            btnSalir.Click += btnSalir_Click;
            grdItems.CellValidating += grdItems_CellValidating;
            grdItems.CellValidated += grdItems_CellValidated;
            grdItems.CellFormatting += grdItems_CellFormatting;
            BSItems = new BindingSource();
            BSItems.CurrentItemChanged += BSItems_CurrentItemChanged;
            NUDCAJA_Monto.Maximum = 9999999;
            NUDCAJA_Monto.Minimum = 0;
         }
         catch (Exception ex)
         { Dialogos.MostrarMensajeError(Presenter.Title, Mensajes.ConstructorView, ex); }
      }
      #region [ Propiedades ]
      public PRO010Presenter Presenter { get; set; }
      public BindingSource BSItems { get; set; }
      private Hashtable HashFormulario { get; set; }
      String[] defaultColumns;
      ToolStripMenuItem tsmTodos;
      #endregion
      #region [ IPRO010MView ]
      public void LoadView()
      {
         try
         {
            Proveedor.ContainerService = Presenter.ContainerService;

            CbTIPO_CodMND.LoadControl(Presenter.ContainerService, "Tabla Moneda", "MND", "< Selecione Moneda >", ListSortDirection.Descending);
            Presenter.CargaCajaCuentas();
            CmbCuentasCaja.DataSource = Presenter._DT;
            CmbCuentasCaja.DisplayMember = "Cuenta";
            CmbCuentasCaja.ValueMember = "CACU_Codigo";
            CargarTipoPago();
            FormatDataGrid();
            ClearItem();
            if (Presenter.CAJA_Tipo == "C")
            {
               PCEncabezado.Caption = "Datos de Pagos de Clientes";
               this.Text = "Pagos de Clientes";
               Proveedor.TipoEntidad = Delfin.Controls.TiposEntidad.TIPE_Cliente;
               label1.Text = "Cliente :";
            }
         }
         catch (Exception ex)
         { Dialogos.MostrarMensajeError(Presenter.Title, Mensajes.LoadView, ex); }
      }

      public void CargaDataDocumentos(DataTable dt, Boolean IncluyePago = false)
      {
         try
         {
            if (dt.Rows.Count > 0)
               CbTIPO_CodMND.TiposSelectedValue = dt.Rows[0]["TIPO_CodMND"].ToString();
            if (!IncluyePago)
            {
               DataColumn _Col = dt.Columns.Add("Pago", typeof(Decimal));
               foreach (DataRow _dt in dt.Rows)
               {
                  _dt["Pago"] = _dt["CCCT_Saldo"];
               }
            }
            if (dt.Rows.Count > 0)
            {
               dt.Columns.Remove("ENTC_Codigo");
               dt.Columns.Remove("Cliente");
            }
            BSItems.DataSource = dt;
            grdItems.DataSource = BSItems;
            navItems.BindingSource = BSItems;
            BSItems.ResetBindings(true);
            if (grdItems.RowCount > 0)
            {
               grdItems.Enabled = true;
            }
            else
            {
               grdItems.Enabled = false;
            }
            grdItems.Columns["Pago"].ReadOnly = false;
            HabilitaObj();
            CalculaTotal();
         }
         catch (Exception ex)
         { Dialogos.MostrarMensajeError(Presenter.Title, Mensajes.ShowItems, ex); }
      }

      private void LoadDocumentos()
      {
         DataTable dt = new DataTable("Documentos");
         Int32 _EntcCodigo = 0;
         if (Proveedor.Value != null)
         {
            _EntcCodigo = Proveedor.Value.ENTC_Codigo;
            dt = Presenter.LoadAyudaDocumentosProv(_EntcCodigo);
            if (dt != null)
            {
               if (dt.Rows.Count == 0)
               {
                  Dialogos.MostrarMensajeInformacion(Presenter.Title, "No se encontraron coincidencias.");
               }
               else if (dt.Rows.Count == 1)
               {
                  Int32 COPE_Codigo;
                  if (Int32.TryParse(dt.Rows[0]["CCCT_Codigo"].ToString(), out COPE_Codigo))
                  {
                     CargaDataDocumentos(dt);
                  }
               }
               else
               {
                  List<ColumnaAyuda> _columnas = new List<ColumnaAyuda>();
                  _columnas.Add(new ColumnaAyuda()
                  {
                     Index = 0,
                     ColumnName = "TIPO_Documento",
                     ColumnCaption = "Documento",
                     Alineacion = DataGridViewContentAlignment.MiddleLeft,
                     Width = 60,
                     DataType = typeof(String),
                     Format = null
                  });
                  _columnas.Add(new ColumnaAyuda()
                  {
                     Index = 1,
                     ColumnName = "CTCT_Serie",
                     ColumnCaption = "Serie",
                     Alineacion = DataGridViewContentAlignment.MiddleLeft,
                     Width = 50,
                     DataType = typeof(String),
                     Format = null
                  });
                  _columnas.Add(new ColumnaAyuda()
                  {
                     Index = 2,
                     ColumnName = "CTCT_Numero",
                     ColumnCaption = "Número",
                     Alineacion = DataGridViewContentAlignment.MiddleRight,
                     Width = 50,
                     DataType = typeof(DateTime),
                     Format = null
                  });
                  _columnas.Add(new ColumnaAyuda()
                  {
                     Index = 3,
                     ColumnName = "Cliente",
                     ColumnCaption = "Cliente",
                     Alineacion = DataGridViewContentAlignment.MiddleRight,
                     Width = 100,
                     DataType = typeof(String),
                     Format = null
                  });
                  _columnas.Add(new ColumnaAyuda()
                  {
                     Index = 4,
                     ColumnName = "CCCT_FechaEmision",
                     ColumnCaption = "Fecha",
                     Alineacion = DataGridViewContentAlignment.MiddleRight,
                     Width = 50,
                     DataType = typeof(DateTime),
                     Format = "dd/MM/yyyy"
                  });
                  _columnas.Add(new ColumnaAyuda()
                  {
                     Index = 5,
                     ColumnName = "TIPO_Moneda",
                     ColumnCaption = "Moneda",
                     Alineacion = DataGridViewContentAlignment.MiddleRight,
                     Width = 50,
                     DataType = typeof(String),
                     Format = null
                  });
                  _columnas.Add(new ColumnaAyuda()
                  {
                     Index = 6,
                     ColumnName = "CCCT_Monto",
                     ColumnCaption = "Total",
                     Alineacion = DataGridViewContentAlignment.MiddleRight,
                     Width = 50,
                     DataType = typeof(Decimal),
                     Format = null
                  });
                  _columnas.Add(new ColumnaAyuda()
                  {
                     Index = 7,
                     ColumnName = "CCCT_Saldo",
                     ColumnCaption = "Saldo",
                     Alineacion = DataGridViewContentAlignment.MiddleRight,
                     Width = 50,
                     DataType = typeof(Decimal),
                     Format = null
                  });
                  _columnas.Add(new ColumnaAyuda()
                  {
                     Index = 8,
                     ColumnName = "CCCT_Codigo",
                     ColumnCaption = "Codigo",
                     Alineacion = DataGridViewContentAlignment.MiddleRight,
                     Width = 5,
                     DataType = typeof(Int32),
                     Format = null
                  });
                  _columnas.Add(new ColumnaAyuda()
                  {
                     Index = 8,
                     ColumnName = "TIPO_CodMND",
                     ColumnCaption = "CodMND",
                     Alineacion = DataGridViewContentAlignment.MiddleRight,
                     Width = 3,
                     DataType = typeof(String),
                     Format = null
                  });
                  Ayuda x_Ayuda = new Ayuda("Ayuda Documentos Proveedor", dt, true, _columnas);
                  if (x_Ayuda.ShowDialog() == DialogResult.OK)
                  {
                     Int32 COPE_Codigo;
                     if (Int32.TryParse(x_Ayuda.Respuesta.Rows[0]["CCCT_Codigo"].ToString(), out COPE_Codigo))
                     {
                        CargaDataDocumentos(x_Ayuda.Respuesta);
                     }

                  }
               }
            }
            else
               Dialogos.MostrarMensajeInformacion(Presenter.Title, "No se encontraron coincidencias.");
         }
         else
         {
            Dialogos.MostrarMensajeInformacion(Presenter.Title, "Debe seleccionar un proveedor ");
         }
      }

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
                  //bte.AutoSize = true;
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
                  //bte.AutoSize = true;
               }
            }
            if (e.CellElement.RowInfo is GridViewNewRowInfo && e.CellElement.ColumnInfo is GridViewCommandColumn)
            {
               e.CellElement.Children[0].Visibility = ElementVisibility.Hidden;
            }
         }
         catch (Exception ex) { Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al formatear el icono." + ex.Message); }
      }
      private void BSItems_CurrentItemChanged(object sender, EventArgs e)
      {
         //SeleccionarItem(); 
      }

      void CargarTipoPago()
      {


         List<KeyValuePair<string, string>> lTipoPago = new List<KeyValuePair<string, string>>();
         lTipoPago.Add(new KeyValuePair<string, string>("E", "Efectivo"));
         lTipoPago.Add(new KeyValuePair<string, string>("C", "Cheque"));
         lTipoPago.Add(new KeyValuePair<string, string>("D", "Depósito"));
         CbCAJA_TipoPago.DataSource = lTipoPago;
         CbCAJA_TipoPago.ValueMember = "Key";
         CbCAJA_TipoPago.DisplayMember = "Value";

      }

      private void FormatDataGrid()
      {
         try
         {
            RadGridLocalizationProvider.CurrentProvider = new MySpanishRadGridLocalizationProvider();
            grdItems.Columns.Clear();
            grdItems.AllowAddNewRow = false;
            GridViewCommandColumn commandColumn;
            //commandColumn = new GridViewCommandColumn();
            //commandColumn.Name = "Edit";
            //commandColumn.HeaderText = @"Editar";
            //commandColumn.DefaultText = @"Editar";
            //commandColumn.UseDefaultText = true;
            //grdItems.Columns.Add(commandColumn);
            //grdItems.Columns["Edit"].AllowSort = false;
            //grdItems.Columns["Edit"].AllowFiltering = false;
            commandColumn = new GridViewCommandColumn();
            commandColumn.Name = "Delete";
            commandColumn.HeaderText = @"Eliminar";
            commandColumn.DefaultText = @"Eliminar";
            commandColumn.UseDefaultText = true;
            grdItems.Columns.Add(commandColumn);
            grdItems.Columns["Delete"].AllowSort = false;
            grdItems.Columns["Delete"].AllowFiltering = false;
            grdItems.Columns.Add("TIPO_Documento", "Tipo Documento", "TIPO_Documento");
            grdItems.Columns["TIPO_Documento"].ReadOnly = true;
            grdItems.Columns["TIPO_Documento"].Width = 60;
            grdItems.Columns.Add("CTCT_Serie", "Serie", "CTCT_Serie");
            grdItems.Columns["CTCT_Serie"].ReadOnly = true;
            grdItems.Columns["CTCT_Serie"].Width = 30;
            grdItems.Columns.Add("CTCT_Numero", "Número", "CTCT_Numero");
            grdItems.Columns["CTCT_Numero"].ReadOnly = true;
            grdItems.Columns["CTCT_Numero"].Width = 60;
            grdItems.Columns.Add("CCCT_FechaEmision", "Fecha Emisión", "CCCT_FechaEmision");
            grdItems.Columns["CCCT_FechaEmision"].ReadOnly = true;
            grdItems.Columns["CCCT_FechaEmision"].Width = 90;
            grdItems.Columns.Add("TIPO_Moneda", "Moneda", "TIPO_Moneda");
            grdItems.Columns["TIPO_Moneda"].ReadOnly = true;
            grdItems.Columns["TIPO_Moneda"].Width = 60;
            grdItems.Columns.Add("CCCT_ValVta", "Valor Venta", "CCCT_ValVta");
            grdItems.Columns["CCCT_ValVta"].ReadOnly = true;
            grdItems.Columns["CCCT_ValVta"].Width = 90;
            grdItems.Columns["CCCT_ValVta"].TextAlignment = ContentAlignment.MiddleRight;
            grdItems.Columns.Add("CCCT_Imp1", "IGV", "CCCT_Imp1");
            grdItems.Columns["CCCT_Imp1"].ReadOnly = true;
            grdItems.Columns["CCCT_Imp1"].TextAlignment = ContentAlignment.MiddleRight;
            grdItems.Columns["CCCT_Imp1"].Width = 90;
            grdItems.Columns.Add("CCCT_Monto", "Monto", "CCCT_Monto");
            grdItems.Columns["CCCT_Monto"].TextAlignment = ContentAlignment.MiddleRight;
            grdItems.Columns["CCCT_Monto"].ReadOnly = true;
            grdItems.Columns["CCCT_Monto"].Width = 90;
            grdItems.Columns.Add("CCCT_Saldo", "Saldo", "CCCT_Saldo");
            grdItems.Columns["CCCT_Saldo"].TextAlignment = ContentAlignment.MiddleRight;
            grdItems.Columns["CCCT_Saldo"].ReadOnly = true;
            grdItems.Columns["CCCT_Saldo"].Width = 90;
            GridViewDecimalColumn Pago = new GridViewDecimalColumn();
            Pago.Name = "Pago";
            Pago.HeaderText = "Pago";
            Pago.FieldName = "Pago";
            Pago.DecimalPlaces = 2;
            Pago.Maximum = 999999;
            Pago.Minimum = 0;
            grdItems.MasterTemplate.Columns.Add(Pago);
            grdItems.Columns["Pago"].TextAlignment = ContentAlignment.MiddleRight;
            grdItems.Columns["Pago"].Width = 60;
            grdItems.Columns["Pago"].ReadOnly = false;
            grdItems.Columns["Pago"].FormatString = "{0:n2}";
            grdItems.Columns.Add("CCCT_Codigo", "Codigo", "CCCT_Codigo");
            grdItems.Columns["CCCT_Codigo"].TextAlignment = ContentAlignment.MiddleRight;
            grdItems.Columns["CCCT_Codigo"].ReadOnly = true;
            grdItems.Columns["CCCT_Codigo"].IsVisible = false;

            tsmColumnas.DropDownItems.Clear();
            defaultColumns = new string[grdItems.Columns.Count];
            int index = 0;
            foreach (GridViewDataColumn column in grdItems.Columns)
            {
               ToolStripMenuItem _item = new ToolStripMenuItem(column.HeaderText);
               _item.Tag = column.Name;
               _item.Checked = column.IsVisible;
               _item.CheckOnClick = true;
               _item.Click += tsmColumna_Click;
               tsmColumnas.DropDownItems.Add(_item);

               if (column.IsVisible)
               { defaultColumns[index] = column.Name; index += 1; }
            }

            ToolStripSeparator tsmSeparacion = new ToolStripSeparator();
            tsmColumnas.DropDownItems.Add(tsmSeparacion);
            tsmTodos = new ToolStripMenuItem("Todos");
            tsmTodos.Tag = "Todas";
            tsmTodos.Checked = false;
            tsmTodos.CheckOnClick = true;
            tsmTodos.Click += tsmTodos_Click;
            tsmColumnas.DropDownItems.Add(tsmTodos);
         }
         catch (Exception ex)
         { Dialogos.MostrarMensajeError(Presenter.Title, Mensajes.FormatDataGridView, ex); }
      }

      private void tsmColumna_Click(object sender, EventArgs e)
      {
         if (sender is ToolStripMenuItem)
         {
            ToolStripMenuItem _item = (ToolStripMenuItem)sender;
            grdItems.Columns[_item.Tag.ToString()].IsVisible = _item.Checked;
            tsmTodos.Checked = false;
         }
      }

      private void btnBuscar_Click(object sender, EventArgs e)
      {
         LoadDocumentos();
      }
      private void btnSalir_Click(object sender, EventArgs e)
      {
         try
         {
            Close();
         }
         catch (Exception ex)
         { Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al cerrar el formulario.", ex); }
      }

      private void tsmTodos_Click(object sender, EventArgs e)
      {
         foreach (GridViewDataColumn column in grdItems.Columns)
         { column.IsVisible = tsmTodos.Checked; }

         foreach (ToolStripItem item in tsmColumnas.DropDownItems)
         { if (item is ToolStripMenuItem) { ((ToolStripMenuItem)item).Checked = tsmTodos.Checked; } }

         if (!tsmTodos.Checked)
         {
            foreach (String item in defaultColumns)
            {
               if (!String.IsNullOrEmpty(item))
               {
                  grdItems.Columns[item].IsVisible = true;
                  foreach (ToolStripItem tsitem in tsmColumnas.DropDownItems)
                  { if (tsitem is ToolStripMenuItem && tsitem.Tag.ToString() == item) { ((ToolStripMenuItem)tsitem).Checked = true; } }
               }
            }
         }
      }

      void btnGuardar_Click(object sender, EventArgs e)
      {
         Guardar();
      }

      private void Guardar()
      {
         if (grdItems.Rows.Count > 0)
         {
            if (!Presenter.Guardar()) return;
            errorProvider1.Dispose();
            Close();
         }
         else
            Dialogos.MostrarMensajeInformacion(Presenter.Title, "Debe Ingresar al menos un documento a pagar");
      }

      void CalculaTotal()
      {
         Decimal _Total = 0;
         for (int i = 0; i < grdItems.Rows.Count; i++)
         {
            _Total += Convert.ToDecimal(grdItems.Rows[i].Cells["Pago"].Value.ToString());
         }
         NUDCAJA_Monto.Value = _Total;
      }
      public void GetItem()
      {
         try
         {
            if (CmbCuentasCaja.SelectedItem != null)
            {
               if (CmbCuentasCaja.Enabled == true)
               { Presenter.ItemMovimiento.CUBA_Codigo = CmbCuentasCaja.SelectedValue.ToString(); }
            }
            Presenter.ItemMovimiento.MOVI_TipoCambio = NUDCAJA_TipoCambio.Value;
            //if (CbTIPO_CodMND.SelectedValue != null)
            //{ Presenter.ItemMovimiento.TIPO_CodMND = CbTIPO_CodMND.SelectedValue.ToString(); }
            Presenter.ItemMovimiento.MOVI_NroOperacion = null; //txtCAJA_NumeroCheque.Text;
            Presenter.ItemMovimiento.ENTC_Codigo = Proveedor.Value.ENTC_Codigo;
            Presenter.ItemMovimiento.MOVI_FecEmision = DTPCAJA_FechaEmision.Value;

            /*
             * Definir este tipo
             * Actualmente Definido: CAJA_TipoPago -> Efectivo, Cheque, Deposito
             */
            //Presenter.ItemMovimiento.TIPO_CodMOV = CbCAJA_TipoPago.SelectedValue.ToString();
            /*
             * Segun el tipo de Movimiento
             * Ingreso -> Debe
             * Egreso  -> Haber
             */
            //Presenter.ItemMovimiento.CAJA_Total = NUDCAJA_Monto.Value;

            /*
             * IMPLEMENTAR
             * Crear un registro de Conciliación en para este campo FechaVoucher
             * 
             * 
             * 
             */
            //Presenter.ItemMovimiento.MOVI_FecEntregaCheque = DTPCAJA_FechaVoucher.Value;

            Presenter.ItemsDetCtaCte = new ObservableCollection<DetCtaCte>();
            if (NUDCAJA_TipoCambio.Value > 0)
            {
               for (int i = 0; i < grdItems.Rows.Count; i++)
               {
                  Presenter.ItemDetCtaCte = new DetCtaCte();
                  Presenter.ItemDetCtaCte.CCCT_Codigo = Convert.ToInt32(grdItems.Rows[i].Cells["CCCT_Codigo"].Value.ToString());
                  Presenter.ItemDetCtaCte.DCCT_FechaTrans = DTPCAJA_FechaEmision.Value;
                  Presenter.ItemDetCtaCte.DCCT_TipoCambio = NUDCAJA_TipoCambio.Value;
                  Presenter.ItemDetCtaCte.DCCT_MontoHaber = Presenter.CAJA_Tipo == "P" ? 0 : CbTIPO_CodMND.SelectedValue.ToString() == "001" ? Convert.ToDecimal(grdItems.Rows[i].Cells["Pago"].Value.ToString()) : Convert.ToDecimal(grdItems.Rows[i].Cells["Pago"].Value.ToString()) * NUDCAJA_TipoCambio.Value;
                  Presenter.ItemDetCtaCte.DCCT_MontoHaberD = Presenter.CAJA_Tipo == "P" ? 0 : CbTIPO_CodMND.SelectedValue.ToString() == "001" ? Convert.ToDecimal(grdItems.Rows[i].Cells["Pago"].Value.ToString()) / NUDCAJA_TipoCambio.Value : Convert.ToDecimal(grdItems.Rows[i].Cells["Pago"].Value.ToString());
                  Presenter.ItemDetCtaCte.DCCT_MontoDebe = Presenter.CAJA_Tipo == "P" ? CbTIPO_CodMND.SelectedValue.ToString() == "001" ? Convert.ToDecimal(grdItems.Rows[i].Cells["Pago"].Value.ToString()) : Convert.ToDecimal(grdItems.Rows[i].Cells["Pago"].Value.ToString()) * NUDCAJA_TipoCambio.Value : 0;
                  Presenter.ItemDetCtaCte.DCCT_MontoDebeD = Presenter.CAJA_Tipo == "P" ? CbTIPO_CodMND.SelectedValue.ToString() == "001" ? Convert.ToDecimal(grdItems.Rows[i].Cells["Pago"].Value.ToString()) / NUDCAJA_TipoCambio.Value : Convert.ToDecimal(grdItems.Rows[i].Cells["Pago"].Value.ToString()) : 0;
                  Presenter.ItemDetCtaCte.TIPO_TabMND = "MND";
                  Presenter.ItemDetCtaCte.TIPO_CodMND = CbTIPO_CodMND.SelectedValue.ToString();
                  Presenter.ItemsDetCtaCte.Add(Presenter.ItemDetCtaCte);
               }
               Presenter.ItemMovimiento.ListDetCtaCte = Presenter.ItemsDetCtaCte;
            }
         }
         catch (Exception ex)
         { Dialogos.MostrarMensajeError(Presenter.Title, Mensajes.SetItem, ex); }
      }

      public void SetItem(DataTable _dt)
      {
         try
         {
            CbTIPO_CodMND.TiposSelectedValue = _dt.Rows[0]["TIPO_CodMND"].ToString();
            txtCAJA_NumeroCheque.Text = _dt.Rows[0]["CAJA_NroCheque"].ToString();
            NUDCAJA_Monto.Value = Convert.ToDecimal(_dt.Rows[0]["CAJA_Total"].ToString());
            NUDCAJA_TipoCambio.Value = Convert.ToDecimal(_dt.Rows[0]["CAJA_TipoCambio"].ToString());
            CbCAJA_TipoPago.SelectedValue = _dt.Rows[0]["CAJA_TipoPago"].ToString();
            if (!String.IsNullOrEmpty(_dt.Rows[0]["CACU_Codigo"].ToString()))
               CmbCuentasCaja.SelectedValue = _dt.Rows[0]["CACU_Codigo"].ToString();
            Proveedor.SetValue(Convert.ToInt32(_dt.Rows[0]["ENTC_Codigo"].ToString()));
            DTPCAJA_FechaEmision.Value = Convert.ToDateTime(_dt.Rows[0]["CAJA_FechaEmision"].ToString());
            DTPCAJA_FechaVoucher.Value = Convert.ToDateTime(_dt.Rows[0]["CAJA_FechaVoucher"].ToString());
            btnGuardar.Enabled = false;
         }
         catch (Exception ex)
         { Dialogos.MostrarMensajeError(Presenter.Title, Mensajes.SetItem, ex); }
      }

      public void ClearItem()
      {
         txtCAJA_NumeroCheque.Text = "";
         NUDCAJA_Monto.Value = 0;
         NUDCAJA_TipoCambio.Value = 0;
         DTPCAJA_FechaEmision.Value = DateTime.Now;
         CbCAJA_TipoPago.SelectedIndex = 0;
         CbTIPO_CodMND.SelectedIndex = -1;
         Proveedor.ClearValue();
         Proveedor.Clear();
         Presenter._DT = null;
         DataTable _dt;
         _dt = new DataTable();
         CargaDataDocumentos(_dt);
         HabilitaObj();
         btnGuardar.Enabled = true;
      }
      public void SetInstance(InstanceView xInstance)
      {
         try
         {
            errorProvider1.Dispose();

            switch (xInstance)
            {
               case InstanceView.Default:
                  break;
               case InstanceView.New:

                  HashFormulario = FormValidateChanges.iniciarComparacionFormulario(this);
                  break;
               case InstanceView.Edit:

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
            Dialogos.MostrarMensajeInformacion(Presenter.Title, "Faltan ingresar datos obligatorios: ", Presenter.ItemMovimiento.MensajeError, Dialogos.Boton.Detalles);
            FormShowErrorProvider<Movimiento>.Validate(Presenter.ItemMovimiento, this, errorProvider1);
         }
         catch (Exception ex)
         { Dialogos.MostrarMensajeError(Presenter.Title, Mensajes.ShowItems, ex); }
      }
      #endregion
      #region [ Grilla ]
      private void ValidarCelda(GridViewDataColumn Column, CellValidatingEventArgs e)
      {
         try
         {
            /* validacion en edicion de registro */
            Int16 _Col = 10;
            e.Row.ErrorText = string.Empty;
            GridViewDataColumn column = e.Column as GridViewDataColumn;
            var cell = e.Row.Cells[e.ColumnIndex];
            if (e.Row is GridViewDataRowInfo)
            {
               switch (column.Index)
               {
                  case 10:    /* Pago */
                     if (((Decimal)e.Value) == 0)
                     {
                        e.Row.ErrorText = "Debe ingresar Pago ";
                        e.Row.Cells[_Col].ErrorText = "Debe ingresar Pago ";
                        e.Cancel = true;
                        e.Row.Cells[_Col].Style.DrawFill = true;
                        e.Row.Cells[_Col].Style.NumberOfColors = 1;
                        e.Row.Cells[_Col].Style.GradientStyle = GradientStyles.Solid;
                        e.Row.Cells[_Col].Style.CustomizeBorder = true;
                        e.Row.Cells[_Col].Style.DrawBorder = true;
                        e.Row.Cells[_Col].Style.BorderWidth = 2;
                        e.Row.Cells[_Col].Style.BorderGradientStyle = GradientStyles.Solid;
                        e.Row.Cells[_Col].Style.BorderColor = Color.Red;
                     }
                     else
                     {
                        if (Convert.ToDecimal(e.Row.Cells[_Col - 1].Value) < ((Decimal)e.Value))
                        {
                           if (Dialogos.MostrarMensajePregunta(Presenter.Title, "El pago es mayor que el saldo. Desea continuar?") == System.Windows.Forms.DialogResult.OK)
                           {
                              CalculaTotal();
                              NUDCAJA_Monto.Value = (NUDCAJA_Monto.Value - Convert.ToDecimal(e.Row.Cells[_Col].Value)) + ((Decimal)e.Value);
                              e.Row.Cells[_Col].Style.Reset();
                           }
                           else
                           {
                              e.Cancel = true;
                              e.Row.ErrorText = "El pago no puede ser mayor que el saldo ";
                              e.Row.Cells[_Col].Value = e.Row.Cells[_Col - 1].Value;
                              e.Row.Cells[_Col].Style.Reset();
                              e.Row.Cells[_Col].Style.Reset();
                           }
                        }
                        else
                        {
                           CalculaTotal();
                           NUDCAJA_Monto.Value = (NUDCAJA_Monto.Value - Convert.ToDecimal(e.Row.Cells[_Col].Value)) + ((Decimal)e.Value);
                           e.Row.Cells[_Col].Style.Reset();
                        }
                     }
                     break;

               }
            }
         }
         catch (Exception ex) { Dialogos.MostrarMensajeError("", "Ha ocurrido un error al validar el registro." + ex.Message); }
      }
      void grdItems_CellValidating(object sender, CellValidatingEventArgs e)
      {
         try
         {
            String _MensajeError = String.Empty;
            GridViewDataColumn column = e.Column as GridViewDataColumn;
            ValidarCelda(column, e);

         }
         catch (Exception ex) { Dialogos.MostrarMensajeError("", "Ha ocurrido un error al validar el dato." + ex.Message); }
      }

      void grdItems_CellValidated(object sender, CellValidatedEventArgs e)
      {
         try
         {     /* validación en nuevo registro */

         }
         catch (Exception ex) { Dialogos.MostrarMensajeError("", "Ha ocurrido un error al validar el registro." + ex.Message); }
      }
      #endregion

      private void CbCAJA_TipoPago_SelectedIndexChanged(object sender, EventArgs e)
      {
         HabilitaObj();
      }
      private void GetTipoCambio()
      {
         String Fecha = DTPCAJA_FechaEmision.Value.Year.ToString() + DTPCAJA_FechaEmision.Value.Month.ToString().PadLeft(2, '0').Trim() + DTPCAJA_FechaEmision.Value.Day.ToString().PadLeft(2, '0').Trim();
         Presenter.ValidarTipoCambio(Fecha);
         NUDCAJA_TipoCambio.Value = Presenter.TipoCambio;

      }

      private void HabilitaObj()
      {
         switch (CbCAJA_TipoPago.SelectedValue.ToString())
         {
            case "E":
               CmbCuentasCaja.Enabled = false;
               CbTIPO_CodMND.Enabled = true;
               txtCAJA_NumeroCheque.Enabled = false;
               break;
            case "D":
               CmbCuentasCaja.Enabled = true;
               CbTIPO_CodMND.Enabled = false;
               lblSERV_DescCorta.Text = "Nro Operación :";
               txtCAJA_NumeroCheque.Enabled = true;
               break;
            case "C":
               CmbCuentasCaja.Enabled = false;
               CbTIPO_CodMND.Enabled = true;
               lblSERV_DescCorta.Text = "Nro Cheque :";
               txtCAJA_NumeroCheque.Enabled = true;
               break;
         }

      }

      private void DTPCAJA_FechaEmision_ValueChanged(object sender, EventArgs e)
      {
         GetTipoCambio();
      }
   }
}
