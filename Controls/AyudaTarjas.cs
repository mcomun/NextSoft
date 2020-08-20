// Decompiled with JetBrains decompiler
// Type: Delfin.Controls.AyudaTarjas
// Assembly: Delfin.Controls, Version=3.0.1.3, Culture=neutral, PublicKeyToken=null
// MVID: A4BA2B33-0E71-44B0-9838-A6C1CD0C2B15
// Assembly location: C:\Temp\Delfin.Controls.dll

using Delfin.ServiceContracts;
using Infrastructure.WinFormsControls;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Telerik.WinControls.Localization;
using Telerik.WinControls.UI;
using Telerik.WinControls.UI.Localization;

namespace Delfin.Controls
{
  public class AyudaTarjas : RadForm
  {
    private BindingSource m_binding;
    private IContainer components;
    private RadGroupBox radGroupBox2;
    private RadButton btnCancelar;
    private RadButton btnAceptar;
    private RadGridView dgvResultado;
    private BindingNavigator bnavItems;
    private ToolStripLabel bindingNavigatorCountItem;
    private ToolStripButton bindingNavigatorMoveLastItem;
    private ToolStripButton bindingNavigatorMoveNextItem;
    private ToolStripSeparator bindingNavigatorSeparator;
    private ToolStripTextBox bindingNavigatorPositionItem;
    private ToolStripSeparator bindingNavigatorSeparator1;
    private ToolStripButton bindingNavigatorMovePreviousItem;
    private ToolStripButton bindingNavigatorMoveFirstItem;

    private IUnityContainer ContainerService { get; set; }

    public static DataTable DTServicios { set; get; }

    public static DataTable RespuestaServicios { set; get; }

    public AyudaTarjas(int x_DOCV_Codigo, string x_TIPO_CodMND, Decimal x_TipoCambio)
    {
      this.InitializeComponent();
      try
      {
        this.FormatearAyuda();
        this.dgvResultado.ValueChanged += new EventHandler(this.dgvResultado_ValueChanged);
        this.StartPosition = FormStartPosition.CenterParent;
        this.ShowInTaskbar = false;
        IDelfinServices idelfinServices = (IDelfinServices) UnityContainerExtensions.Resolve<IDelfinServices>(this.ContainerService, new ResolverOverride[0]);
        AyudaTarjas.DTServicios = new DataTable();
        AyudaTarjas.DTServicios = idelfinServices.GetAllDet_TarjasServiciosFacturacion(x_DOCV_Codigo > 0 ? x_DOCV_Codigo : 0, x_TIPO_CodMND, x_TipoCambio);
        this.m_binding = new BindingSource();
        this.m_binding.DataSource = (object) AyudaTarjas.DTServicios;
        this.dgvResultado.DataSource = (object) this.m_binding;
        this.bnavItems.BindingSource = this.m_binding;
      }
      catch (Exception ex)
      {
        int num = (int) Dialogos.MostrarMensajeError("Ayuda Tarjas", "Ha ocurrido un error al inicializar el formulario.", ex);
      }
    }

    public static DialogResult MostrarAyuda(IUnityContainer ContainerService, int x_DOCV_Codigo, string x_TIPO_CodMND, Decimal x_TipoCambio)
    {
      return new AyudaTarjas(x_DOCV_Codigo > 0 ? x_DOCV_Codigo : 0, x_TIPO_CodMND, x_TipoCambio)
      {
        ContainerService = ContainerService
      }.ShowDialog();
    }

    public static DataTable RespuestaAyuda()
    {
      DataTable dataTable = new DataTable();
      AyudaTarjas.RespuestaServicios = ((IEnumerable<DataRow>) AyudaTarjas.DTServicios.Select("Agregar = 'True'")).CopyToDataTable<DataRow>();
      return AyudaTarjas.RespuestaServicios;
    }

    private void FormatearAyuda()
    {
      LocalizationProvider<RadGridLocalizationProvider>.CurrentProvider = (RadGridLocalizationProvider) new MySpanishRadGridLocalizationProvider();
      this.dgvResultado.Columns.Clear();
      this.dgvResultado.EnableHotTracking = true;
      this.dgvResultado.EnableAlternatingRowColor = false;
      this.dgvResultado.ShowFilteringRow = false;
      this.dgvResultado.ShowHeaderCellButtons = false;
      this.dgvResultado.TableElement.RowSpacing = 0;
      this.dgvResultado.TableElement.CellSpacing = 0;
      this.dgvResultado.EnableFiltering = false;
      this.dgvResultado.MasterTemplate.EnableFiltering = false;
      this.dgvResultado.AllowColumnHeaderContextMenu = false;
      this.dgvResultado.AllowCellContextMenu = false;
      this.dgvResultado.AllowAddNewRow = false;
      this.dgvResultado.AllowDeleteRow = false;
      this.dgvResultado.AllowEditRow = true;
      this.dgvResultado.AutoGenerateColumns = false;
      this.dgvResultado.AllowMultiColumnSorting = false;
      this.dgvResultado.AllowRowResize = false;
      this.dgvResultado.AllowColumnResize = true;
      this.dgvResultado.ShowGroupPanel = false;
      GridViewCheckBoxColumn viewCheckBoxColumn = new GridViewCheckBoxColumn();
      viewCheckBoxColumn.Name = "Agregar";
      viewCheckBoxColumn.HeaderText = "Agregar";
      viewCheckBoxColumn.FieldName = "Agregar";
      this.dgvResultado.Columns.Add((GridViewDataColumn) viewCheckBoxColumn);
      this.dgvResultado.Columns["Agregar"].Width = 50;
      this.dgvResultado.Columns["Agregar"].ReadOnly = false;
      this.dgvResultado.Columns.Add("Cliente", "Cliente", "Cliente");
      this.dgvResultado.Columns["Cliente"].Width = 300;
      this.dgvResultado.Columns["Cliente"].TextAlignment = ContentAlignment.MiddleLeft;
      this.dgvResultado.Columns["Cliente"].ReadOnly = true;
      this.dgvResultado.Columns.Add("DepTemporal", "Dep. Temporal", "DepTemporal");
      this.dgvResultado.Columns["DepTemporal"].Width = 300;
      this.dgvResultado.Columns["DepTemporal"].TextAlignment = ContentAlignment.MiddleLeft;
      this.dgvResultado.Columns["DepTemporal"].ReadOnly = true;
      this.dgvResultado.Columns.Add("DTAJ_NroContenedor", "Nro. Contenedor", "DTAJ_NroContenedor");
      this.dgvResultado.Columns["DTAJ_NroContenedor"].Width = 150;
      this.dgvResultado.Columns["DTAJ_NroContenedor"].TextAlignment = ContentAlignment.MiddleLeft;
      this.dgvResultado.Columns["DTAJ_NroContenedor"].ReadOnly = true;
      this.dgvResultado.Columns.Add("PACK_Desc", "Contenedor", "PACK_Desc");
      this.dgvResultado.Columns["PACK_Desc"].Width = 150;
      this.dgvResultado.Columns["PACK_Desc"].TextAlignment = ContentAlignment.MiddleLeft;
      this.dgvResultado.Columns["PACK_Desc"].ReadOnly = true;
      this.dgvResultado.Columns.Add("Moneda", "Moneda", "Moneda");
      this.dgvResultado.Columns["Moneda"].Width = 100;
      this.dgvResultado.Columns["Moneda"].TextAlignment = ContentAlignment.MiddleLeft;
      this.dgvResultado.Columns["Moneda"].ReadOnly = true;
    }

    private void dgvResultado_ValueChanged(object sender, EventArgs e)
    {
      if (!(this.dgvResultado.ActiveEditor is RadCheckBoxEditor))
        return;
      this.dgvResultado.EndEdit();
      this.dgvResultado.EndUpdate();
      this.m_binding.EndEdit();
      AyudaTarjas.DTServicios = (DataTable) this.m_binding.DataSource;
    }

    private void Ayuda_Load(object sender, EventArgs e)
    {
      try
      {
        if (this.m_binding == null || this.m_binding.DataSource == null || ((DataTable) this.m_binding.DataSource).Rows.Count != 0)
          return;
        int num = (int) Dialogos.MostrarMensajeInformacion("Ayuda Tarjas", "No Existen Registros", (Dialogos.Boton) 0);
        this.Close();
      }
      catch (Exception ex)
      {
        int num = (int) Dialogos.MostrarMensajeError("Ayuda Tarjas", "Ha ocurrido un error al cargar el formulario.", ex);
      }
    }

    private void btnAceptar_Click(object sender, EventArgs e)
    {
      AyudaTarjas.RespuestaAyuda();
      this.DialogResult = DialogResult.OK;
    }

    private void btnCancelar_Click(object sender, EventArgs e)
    {
      AyudaTarjas.RespuestaServicios = (DataTable) null;
      this.DialogResult = DialogResult.Cancel;
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
      this.dgvResultado = new RadGridView();
      this.bnavItems = new BindingNavigator(this.components);
      this.bindingNavigatorCountItem = new ToolStripLabel();
      this.bindingNavigatorMoveLastItem = new ToolStripButton();
      this.bindingNavigatorMoveNextItem = new ToolStripButton();
      this.bindingNavigatorSeparator = new ToolStripSeparator();
      this.bindingNavigatorPositionItem = new ToolStripTextBox();
      this.bindingNavigatorSeparator1 = new ToolStripSeparator();
      this.bindingNavigatorMovePreviousItem = new ToolStripButton();
      this.bindingNavigatorMoveFirstItem = new ToolStripButton();
      this.radGroupBox2.BeginInit();
      this.radGroupBox2.SuspendLayout();
      this.btnCancelar.BeginInit();
      this.btnAceptar.BeginInit();
      this.dgvResultado.BeginInit();
      this.dgvResultado.MasterTemplate.BeginInit();
      this.bnavItems.BeginInit();
      this.bnavItems.SuspendLayout();
      this.BeginInit();
      this.SuspendLayout();
      this.radGroupBox2.AccessibleRole = AccessibleRole.Grouping;
      this.radGroupBox2.BackColor = Color.SteelBlue;
      this.radGroupBox2.Controls.Add((Control) this.btnCancelar);
      this.radGroupBox2.Controls.Add((Control) this.btnAceptar);
      this.radGroupBox2.Dock = DockStyle.Bottom;
      this.radGroupBox2.ForeColor = Color.DarkSlateGray;
      this.radGroupBox2.HeaderText = "";
      this.radGroupBox2.Location = new Point(0, 278);
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
      this.dgvResultado.Dock = DockStyle.Top;
      this.dgvResultado.Location = new Point(0, 0);
      this.dgvResultado.Name = "dgvResultado";
      this.dgvResultado.Size = new Size(542, 249);
      this.dgvResultado.TabIndex = 50;
      this.dgvResultado.Text = "radGridView1";
      this.bnavItems.AddNewItem = (ToolStripItem) null;
      this.bnavItems.BackColor = Color.SteelBlue;
      this.bnavItems.CountItem = (ToolStripItem) this.bindingNavigatorCountItem;
      this.bnavItems.DeleteItem = (ToolStripItem) null;
      this.bnavItems.Dock = DockStyle.Bottom;
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
      this.bnavItems.Location = new Point(0, 249);
      this.bnavItems.MoveFirstItem = (ToolStripItem) this.bindingNavigatorMoveFirstItem;
      this.bnavItems.MoveLastItem = (ToolStripItem) this.bindingNavigatorMoveLastItem;
      this.bnavItems.MoveNextItem = (ToolStripItem) this.bindingNavigatorMoveNextItem;
      this.bnavItems.MovePreviousItem = (ToolStripItem) this.bindingNavigatorMovePreviousItem;
      this.bnavItems.Name = "bnavItems";
      this.bnavItems.Padding = new Padding(3);
      this.bnavItems.PositionItem = (ToolStripItem) this.bindingNavigatorPositionItem;
      this.bnavItems.RenderMode = ToolStripRenderMode.System;
      this.bnavItems.Size = new Size(542, 29);
      this.bnavItems.TabIndex = 51;
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
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.ClientSize = new Size(542, 318);
      this.Controls.Add((Control) this.bnavItems);
      this.Controls.Add((Control) this.radGroupBox2);
      this.Controls.Add((Control) this.dgvResultado);
      this.FormBorderStyle = FormBorderStyle.FixedSingle;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = nameof (AyudaTarjas);
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
      this.dgvResultado.MasterTemplate.EndInit();
      this.dgvResultado.EndInit();
      this.bnavItems.EndInit();
      this.bnavItems.ResumeLayout(false);
      this.bnavItems.PerformLayout();
      this.EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();
    }
  }
}
