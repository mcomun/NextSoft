// Decompiled with JetBrains decompiler
// Type: Delfin.Controls.AyudaEntidad
// Assembly: Delfin.Controls, Version=3.0.1.3, Culture=neutral, PublicKeyToken=null
// MVID: A4BA2B33-0E71-44B0-9838-A6C1CD0C2B15
// Assembly location: C:\Temp\Delfin.Controls.dll

using Infrastructure.WinFormsControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Telerik.WinControls.UI;

namespace Delfin.Controls
{
  public class AyudaEntidad : RadForm
  {
    private string m_procedure;
    private string[] m_nombres;
    private object[] m_valores;
    private BindingSource m_binding;
    private DataSet m_datos;
    private DataTable m_rpta;
    private IContainer components;
    private RadGroupBox radGroupBox2;
    private RadButton btnCancelar;
    private RadButton btnAceptar;
    private RadPanel radPanel1;
    private Label label1;
    private RadTextBox txtBus;
    private BindingNavigator bnavItems;
    private ToolStripLabel bindingNavigatorCountItem;
    private ToolStripButton bindingNavigatorMoveLastItem;
    private ToolStripButton bindingNavigatorMoveNextItem;
    private ToolStripSeparator bindingNavigatorSeparator;
    private ToolStripTextBox bindingNavigatorPositionItem;
    private ToolStripSeparator bindingNavigatorSeparator1;
    private ToolStripButton bindingNavigatorMovePreviousItem;
    private ToolStripButton bindingNavigatorMoveFirstItem;
    private RadGridView dgvResultado;

    public AyudaEntidad(string x_titulo, DataTable x_datos, bool x_multiselect, string x_Criterio = "")
    {
      this.InitializeComponent();
      this.dgvResultado.AutoGenerateColumns = false;
      this.dgvResultado.Columns.Clear();
      try
      {
        this.m_binding = new BindingSource();
        this.Titulo = x_titulo;
        this.txtBus.Text = x_Criterio;
        this.MultiSelect = x_multiselect;
        this.Cargar(x_datos);
        this.FormatearAyuda();
        this.StartPosition = FormStartPosition.CenterParent;
        this.ShowInTaskbar = false;
      }
      catch (Exception ex)
      {
        int num = (int) Dialogos.MostrarMensajeError(this.Titulo, "Ha ocurrido un error al inicializar el formulario.", ex);
      }
    }

    private void dgvResultado_KeyUp(object sender, KeyEventArgs e)
    {
      if (e.KeyCode != Keys.Return)
        return;
      if (this.CargarRpta())
        this.DialogResult = DialogResult.OK;
      else
        this.DialogResult = DialogResult.Cancel;
    }

    public AyudaEntidad(string x_titulo, DataTable x_datos, bool x_multiselect, IEnumerable<ColumnaAyuda> x_columnas, string x_Criterio = "")
    {
      this.InitializeComponent();
      this.dgvResultado.AutoGenerateColumns = false;
      this.dgvResultado.Columns.Clear();
      try
      {
        this.m_binding = new BindingSource();
        this.Titulo = x_titulo;
        this.txtBus.Text = x_Criterio;
        this.MultiSelect = x_multiselect;
        this.Cargar(x_datos, x_columnas);
        this.FormatearAyuda();
        this.StartPosition = FormStartPosition.CenterParent;
        this.ShowInTaskbar = false;
      }
      catch (Exception ex)
      {
        int num = (int) Dialogos.MostrarMensajeError(this.Titulo, "Ha ocurrido un error al inicializar el formulario.", ex);
      }
    }

    private void Ayuda_Load(object sender, EventArgs e)
    {
      try
      {
        if (this.m_binding == null || this.m_binding.DataSource == null || ((DataTable) this.m_binding.DataSource).Rows.Count != 0)
          return;
        int num = (int) Dialogos.MostrarMensajeInformacion("Ayuda", "No Existen Registros", (Dialogos.Boton) 0);
        this.Close();
      }
      catch (Exception ex)
      {
        int num = (int) Dialogos.MostrarMensajeError(this.Titulo, "Ha ocurrido un error al cargar el formulario.", ex);
      }
    }

    private void FormatearAyuda()
    {
      this.dgvResultado.ShowFilteringRow = false;
      this.dgvResultado.AllowAddNewRow = false;
      this.dgvResultado.AllowDeleteRow = false;
      this.dgvResultado.AllowEditRow = false;
      this.dgvResultado.ShowGroupPanel = false;
    }

    public bool MultiSelect
    {
      get
      {
        return this.dgvResultado.MultiSelect;
      }
      set
      {
        this.dgvResultado.MultiSelect = value;
      }
    }

    public DataTable Respuesta
    {
      get
      {
        return this.m_rpta;
      }
    }

    public string Titulo
    {
      get
      {
        return this.Text;
      }
      set
      {
        this.Text = value;
      }
    }

    public string[] Nombres
    {
      get
      {
        return this.m_nombres;
      }
      set
      {
        this.m_nombres = value;
      }
    }

    private bool IsNumericType(Type tipo)
    {
      switch (tipo.FullName)
      {
        case "System.Byte":
          return true;
        case "System.SByte":
          return true;
        case "System.Int16":
          return true;
        case "System.UInt16":
          return true;
        case "System.Int32":
          return true;
        case "System.UInt32":
          return true;
        case "System.Int64":
          return true;
        case "System.UInt64":
          return true;
        case "System.Single":
          return true;
        case "System.Double":
          return true;
        case "System.Decimal":
          return true;
        default:
          return false;
      }
    }

    private bool CargarRpta()
    {
      try
      {
        this.m_rpta = new DataTable();
        this.m_rpta = ((DataTable) this.m_binding.DataSource).Copy();
        this.m_rpta.Rows.Clear();
        foreach (GridViewRowInfo row1 in this.dgvResultado.Rows)
        {
          if (row1.IsSelected)
          {
            DataRow row2 = this.m_rpta.NewRow();
            foreach (DataColumn column in (InternalDataCollectionBase) this.m_rpta.Columns)
              row2[column] = ((DataRowView) row1.DataBoundItem).Row[column.ColumnName];
            this.m_rpta.Rows.Add(row2);
          }
        }
        return this.m_rpta != null && this.m_rpta.Rows.Count > 0;
      }
      catch (Exception ex)
      {
        int num = (int) Dialogos.MostrarMensajeError(this.Titulo, "Ha ocurrido un error al cargar la respuesta.", ex);
        return false;
      }
    }

    public void Cargar(DataTable l_datos)
    {
      try
      {
        foreach (DataColumn column in (InternalDataCollectionBase) l_datos.Columns)
        {
          GridViewTextBoxColumn viewTextBoxColumn = new GridViewTextBoxColumn();
          viewTextBoxColumn.Name = column.ColumnName;
          viewTextBoxColumn.FieldName = column.ColumnName;
          viewTextBoxColumn.AutoSizeMode = BestFitColumnMode.DisplayedCells;
          viewTextBoxColumn.HeaderText = !string.IsNullOrEmpty(column.Caption) ? column.Caption : column.ColumnName;
          this.dgvResultado.Columns.Add((GridViewDataColumn) viewTextBoxColumn);
        }
        this.dgvResultado.BestFitColumns();
        this.m_binding.DataSource = (object) l_datos;
        this.dgvResultado.DataSource = (object) this.m_binding;
        this.bnavItems.BindingSource = this.m_binding;
      }
      catch (Exception ex)
      {
        int num = (int) Dialogos.MostrarMensajeError(this.Titulo, "Ha ocurrido un error al cargar las columnas de la ayuda.", ex);
      }
    }

    public void Cargar(DataTable l_datos, IEnumerable<ColumnaAyuda> x_columnas)
    {
      try
      {
        if (x_columnas != null)
        {
          for (int index = 0; index < x_columnas.Count<ColumnaAyuda>(); ++index)
          {
            GridViewTextBoxColumn viewTextBoxColumn = new GridViewTextBoxColumn();
            viewTextBoxColumn.Name = x_columnas.ElementAt<ColumnaAyuda>(index).ColumnName;
            viewTextBoxColumn.FieldName = x_columnas.ElementAt<ColumnaAyuda>(index).ColumnName;
            viewTextBoxColumn.FormatString = x_columnas.ElementAt<ColumnaAyuda>(index).Format;
            viewTextBoxColumn.TextAlignment = x_columnas.ElementAt<ColumnaAyuda>(index).Alineacion;
            viewTextBoxColumn.Width = x_columnas.ElementAt<ColumnaAyuda>(index).Width;
            viewTextBoxColumn.HeaderText = x_columnas.ElementAt<ColumnaAyuda>(index).ColumnCaption;
            this.dgvResultado.Columns.Add((GridViewDataColumn) viewTextBoxColumn);
          }
        }
        this.m_binding.DataSource = (object) l_datos;
        this.dgvResultado.DataSource = (object) this.m_binding;
        this.bnavItems.BindingSource = this.m_binding;
      }
      catch (Exception ex)
      {
        int num = (int) Dialogos.MostrarMensajeError(this.Titulo, "Ha ocurrido un error al cargar las columnas de la ayuda.", ex);
      }
    }

    private void btnAceptar_Click(object sender, EventArgs e)
    {
      if (this.CargarRpta())
        this.DialogResult = DialogResult.OK;
      else
        this.DialogResult = DialogResult.Cancel;
    }

    private void btnCancelar_Click(object sender, EventArgs e)
    {
      ((DataTable) this.m_binding.DataSource).Copy().Rows.Clear();
      this.DialogResult = DialogResult.Cancel;
    }

    private void dgvResultado_CellDoubleClick(object sender, GridViewCellEventArgs e)
    {
      if (e.RowIndex < 0 || !this.CargarRpta())
        return;
      this.DialogResult = DialogResult.OK;
    }

    private void txtBus_TextChanged(object sender, EventArgs e)
    {
      try
      {
        string fieldName = this.dgvResultado.Columns[0].FieldName;
        string str = this.txtBus.Text.Trim();
        if (!string.IsNullOrEmpty(str))
        {
          if (this.IsNumericType(((DataTable) ((BindingSource) this.dgvResultado.DataSource).DataSource).Columns[this.dgvResultado.Columns[0].FieldName].DataType))
            this.m_binding.Filter = "[" + fieldName + "] = " + str;
          else
            this.m_binding.Filter = "[" + fieldName + "] like '" + str + "%'";
        }
        else
          this.m_binding.Filter = (string) null;
      }
      catch (Exception ex)
      {
      }
    }

    private void txtBus_KeyDown(object sender, KeyEventArgs e)
    {
      if (e.KeyCode == Keys.Down)
        this.m_binding.MoveNext();
      else if (e.KeyCode == Keys.Up)
        this.m_binding.MovePrevious();
      else if (e.KeyCode == Keys.Next)
      {
        this.m_binding.MoveNext();
      }
      else
      {
        if (e.KeyCode != Keys.Back)
          return;
        this.m_binding.MovePrevious();
      }
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      this.components = (IContainer) new Container();
      this.radGroupBox2 = new RadGroupBox();
      this.btnCancelar = new RadButton();
      this.btnAceptar = new RadButton();
      this.radPanel1 = new RadPanel();
      this.label1 = new Label();
      this.txtBus = new RadTextBox();
      this.bnavItems = new BindingNavigator(this.components);
      this.bindingNavigatorCountItem = new ToolStripLabel();
      this.bindingNavigatorMoveLastItem = new ToolStripButton();
      this.bindingNavigatorMoveNextItem = new ToolStripButton();
      this.bindingNavigatorSeparator = new ToolStripSeparator();
      this.bindingNavigatorPositionItem = new ToolStripTextBox();
      this.bindingNavigatorSeparator1 = new ToolStripSeparator();
      this.bindingNavigatorMovePreviousItem = new ToolStripButton();
      this.bindingNavigatorMoveFirstItem = new ToolStripButton();
      this.dgvResultado = new RadGridView();
      this.radGroupBox2.BeginInit();
      this.radGroupBox2.SuspendLayout();
      this.btnCancelar.BeginInit();
      this.btnAceptar.BeginInit();
      this.radPanel1.BeginInit();
      this.radPanel1.SuspendLayout();
      this.txtBus.BeginInit();
      this.bnavItems.BeginInit();
      this.bnavItems.SuspendLayout();
      this.dgvResultado.BeginInit();
      this.dgvResultado.MasterTemplate.BeginInit();
      this.BeginInit();
      this.SuspendLayout();
      this.radGroupBox2.AccessibleRole = AccessibleRole.Grouping;
      this.radGroupBox2.Controls.Add((Control) this.btnCancelar);
      this.radGroupBox2.Controls.Add((Control) this.btnAceptar);
      this.radGroupBox2.Dock = DockStyle.Bottom;
      this.radGroupBox2.ForeColor = Color.DarkSlateGray;
      this.radGroupBox2.HeaderText = "";
      this.radGroupBox2.Location = new Point(0, 317);
      this.radGroupBox2.Name = "radGroupBox2";
      this.radGroupBox2.RootElement.Padding = new Padding(2, 18, 2, 2);
      this.radGroupBox2.Size = new Size(542, 40);
      this.radGroupBox2.TabIndex = 8;
      this.btnCancelar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      this.btnCancelar.DialogResult = DialogResult.Cancel;
      this.btnCancelar.ImageAlignment = ContentAlignment.MiddleCenter;
      this.btnCancelar.Location = new Point(280, 8);
      this.btnCancelar.Name = "btnCancelar";
      this.btnCancelar.Padding = new Padding(10, 0, 0, 0);
      this.btnCancelar.RootElement.Padding = new Padding(10, 0, 0, 0);
      this.btnCancelar.Size = new Size(100, 24);
      this.btnCancelar.TabIndex = 7;
      this.btnCancelar.Text = "&Cancelar";
      this.btnCancelar.TextImageRelation = TextImageRelation.ImageBeforeText;
      this.btnCancelar.Click += new EventHandler(this.btnCancelar_Click);
      this.btnAceptar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      this.btnAceptar.ForeColor = Color.Red;
      this.btnAceptar.ImageAlignment = ContentAlignment.MiddleCenter;
      this.btnAceptar.Location = new Point(176, 8);
      this.btnAceptar.Name = "btnAceptar";
      this.btnAceptar.Padding = new Padding(10, 0, 0, 0);
      this.btnAceptar.RootElement.Padding = new Padding(10, 0, 0, 0);
      this.btnAceptar.Size = new Size(100, 24);
      this.btnAceptar.TabIndex = 6;
      this.btnAceptar.Text = "&Aceptar";
      this.btnAceptar.TextImageRelation = TextImageRelation.ImageBeforeText;
      this.btnAceptar.Click += new EventHandler(this.btnAceptar_Click);
      this.radPanel1.Controls.Add((Control) this.label1);
      this.radPanel1.Controls.Add((Control) this.txtBus);
      this.radPanel1.Dock = DockStyle.Top;
      this.radPanel1.Location = new Point(0, 0);
      this.radPanel1.Name = "radPanel1";
      this.radPanel1.Size = new Size(542, 39);
      this.radPanel1.TabIndex = 10;
      this.label1.AutoSize = true;
      this.label1.Font = new Font("Segoe UI", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.label1.ForeColor = Color.DarkSlateGray;
      this.label1.Location = new Point(6, 9);
      this.label1.Name = "label1";
      this.label1.Size = new Size(72, 17);
      this.label1.TabIndex = 2;
      this.label1.Text = "Búsqueda:";
      this.txtBus.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.txtBus.Location = new Point(84, 9);
      this.txtBus.Name = "txtBus";
      this.txtBus.NullText = "Ingrese criterio de búsqueda";
      this.txtBus.Size = new Size(451, 20);
      this.txtBus.TabIndex = 1;
      this.txtBus.TabStop = false;
      this.txtBus.TextChanged += new EventHandler(this.txtBus_TextChanged);
      this.txtBus.KeyDown += new KeyEventHandler(this.txtBus_KeyDown);
      this.txtBus.KeyUp += new KeyEventHandler(this.dgvResultado_KeyUp);
      this.bnavItems.AddNewItem = (ToolStripItem) null;
      this.bnavItems.BackColor = Color.Transparent;
      this.bnavItems.CountItem = (ToolStripItem) this.bindingNavigatorCountItem;
      this.bnavItems.DeleteItem = (ToolStripItem) null;
      this.bnavItems.GripStyle = ToolStripGripStyle.Hidden;
      this.bnavItems.Items.AddRange(new ToolStripItem[8]
      {
        (ToolStripItem) this.bindingNavigatorMoveLastItem,
        (ToolStripItem) this.bindingNavigatorMoveNextItem,
        (ToolStripItem) this.bindingNavigatorSeparator,
        (ToolStripItem) this.bindingNavigatorCountItem,
        (ToolStripItem) this.bindingNavigatorPositionItem,
        (ToolStripItem) this.bindingNavigatorSeparator1,
        (ToolStripItem) this.bindingNavigatorMovePreviousItem,
        (ToolStripItem) this.bindingNavigatorMoveFirstItem
      });
      this.bnavItems.Location = new Point(0, 288);
      this.bnavItems.MoveFirstItem = (ToolStripItem) this.bindingNavigatorMoveFirstItem;
      this.bnavItems.MoveLastItem = (ToolStripItem) this.bindingNavigatorMoveLastItem;
      this.bnavItems.MoveNextItem = (ToolStripItem) this.bindingNavigatorMoveNextItem;
      this.bnavItems.MovePreviousItem = (ToolStripItem) this.bindingNavigatorMovePreviousItem;
      this.bnavItems.Name = "bnavItems";
      this.bnavItems.Padding = new Padding(3);
      this.bnavItems.PositionItem = (ToolStripItem) this.bindingNavigatorPositionItem;
      this.bnavItems.RenderMode = ToolStripRenderMode.System;
      this.bnavItems.Size = new Size(542, 29);
      this.bnavItems.TabIndex = 49;
      this.bnavItems.Text = "bindingNavigator1";
      this.bindingNavigatorCountItem.Alignment = ToolStripItemAlignment.Right;
      this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
      this.bindingNavigatorCountItem.Size = new Size(37, 20);
      this.bindingNavigatorCountItem.Text = "de {0}";
      this.bindingNavigatorCountItem.ToolTipText = "Número total de elementos";
      this.bindingNavigatorMoveLastItem.Alignment = ToolStripItemAlignment.Right;
      this.bindingNavigatorMoveLastItem.DisplayStyle = ToolStripItemDisplayStyle.Image;
      this.bindingNavigatorMoveLastItem.Name = "bindingNavigatorMoveLastItem";
      this.bindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = true;
      this.bindingNavigatorMoveLastItem.Size = new Size(23, 20);
      this.bindingNavigatorMoveLastItem.Text = "Ultimo";
      this.bindingNavigatorMoveNextItem.Alignment = ToolStripItemAlignment.Right;
      this.bindingNavigatorMoveNextItem.DisplayStyle = ToolStripItemDisplayStyle.Image;
      this.bindingNavigatorMoveNextItem.Name = "bindingNavigatorMoveNextItem";
      this.bindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = true;
      this.bindingNavigatorMoveNextItem.Size = new Size(23, 20);
      this.bindingNavigatorMoveNextItem.Text = "Siguiente";
      this.bindingNavigatorSeparator.Alignment = ToolStripItemAlignment.Right;
      this.bindingNavigatorSeparator.Name = "bindingNavigatorSeparator";
      this.bindingNavigatorSeparator.Size = new Size(6, 23);
      this.bindingNavigatorPositionItem.AccessibleName = "Position";
      this.bindingNavigatorPositionItem.Alignment = ToolStripItemAlignment.Right;
      this.bindingNavigatorPositionItem.AutoSize = false;
      this.bindingNavigatorPositionItem.Margin = new Padding(3, 0, 1, 0);
      this.bindingNavigatorPositionItem.Name = "bindingNavigatorPositionItem";
      this.bindingNavigatorPositionItem.Size = new Size(50, 23);
      this.bindingNavigatorPositionItem.Text = "0";
      this.bindingNavigatorPositionItem.ToolTipText = "Posición Actual";
      this.bindingNavigatorSeparator1.Alignment = ToolStripItemAlignment.Right;
      this.bindingNavigatorSeparator1.Name = "bindingNavigatorSeparator1";
      this.bindingNavigatorSeparator1.Size = new Size(6, 23);
      this.bindingNavigatorMovePreviousItem.Alignment = ToolStripItemAlignment.Right;
      this.bindingNavigatorMovePreviousItem.DisplayStyle = ToolStripItemDisplayStyle.Image;
      this.bindingNavigatorMovePreviousItem.Name = "bindingNavigatorMovePreviousItem";
      this.bindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = true;
      this.bindingNavigatorMovePreviousItem.Size = new Size(23, 20);
      this.bindingNavigatorMovePreviousItem.Text = "Anterior";
      this.bindingNavigatorMoveFirstItem.Alignment = ToolStripItemAlignment.Right;
      this.bindingNavigatorMoveFirstItem.DisplayStyle = ToolStripItemDisplayStyle.Image;
      this.bindingNavigatorMoveFirstItem.Name = "bindingNavigatorMoveFirstItem";
      this.bindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = true;
      this.bindingNavigatorMoveFirstItem.Size = new Size(23, 20);
      this.bindingNavigatorMoveFirstItem.Text = "Primero";
      this.dgvResultado.Dock = DockStyle.Top;
      this.dgvResultado.Location = new Point(0, 39);
      this.dgvResultado.Name = "dgvResultado";
      this.dgvResultado.Size = new Size(542, 249);
      this.dgvResultado.TabIndex = 50;
      this.dgvResultado.Text = "radGridView1";
      this.dgvResultado.CellDoubleClick += new GridViewCellEventHandler(this.dgvResultado_CellDoubleClick);
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.ClientSize = new Size(542, 357);
      this.Controls.Add((Control) this.bnavItems);
      this.Controls.Add((Control) this.radGroupBox2);
      this.Controls.Add((Control) this.dgvResultado);
      this.Controls.Add((Control) this.radPanel1);
      this.FormBorderStyle = FormBorderStyle.FixedSingle;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "Ayuda";
      this.RootElement.ApplyShapeToControl = true;
      this.ShowInTaskbar = false;
      this.StartPosition = FormStartPosition.CenterScreen;
      this.Text = "Ayuda";
      this.ThemeName = "ControlDefault";
      this.Load += new EventHandler(this.Ayuda_Load);
      this.radGroupBox2.EndInit();
      this.radGroupBox2.ResumeLayout(false);
      this.btnCancelar.EndInit();
      this.btnAceptar.EndInit();
      this.radPanel1.EndInit();
      this.radPanel1.ResumeLayout(false);
      this.radPanel1.PerformLayout();
      this.txtBus.EndInit();
      this.bnavItems.EndInit();
      this.bnavItems.ResumeLayout(false);
      this.bnavItems.PerformLayout();
      this.dgvResultado.MasterTemplate.EndInit();
      this.dgvResultado.EndInit();
      this.EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();
    }
  }
}
