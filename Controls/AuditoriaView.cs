// Decompiled with JetBrains decompiler
// Type: Delfin.Controls.AuditoriaView
// Assembly: Delfin.Controls, Version=3.0.1.3, Culture=neutral, PublicKeyToken=null
// MVID: A4BA2B33-0E71-44B0-9838-A6C1CD0C2B15
// Assembly location: C:\Temp\Delfin.Controls.dll

using Delfin.Controls.Properties;
using Delfin.ServiceContracts;
using Infrastructure.Aspect.DataAccess;
using Infrastructure.WinForms.Controls;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Telerik.WinControls.Localization;
using Telerik.WinControls.UI;
using Telerik.WinControls.UI.Localization;

namespace Delfin.Controls
{
  public class AuditoriaView : Form
  {
    private string SP_COM_Cab_Cotizacion_OV = "NEX_AUDISS_COM_Cab_Cotizacion_OV";
    private string SP_COM_Det_Cotizacion_OV_Flete = "NEX_AUDISS_COM_Det_Cotizacion_OV_Flete";
    private string SP_COM_Det_Cotizacion_OV_Servicios = "NEX_AUDISS_COM_Det_Cotizacion_OV_Servicio";
    private string SP_COM_Det_Cotizacion_OV_EventosTareas = "NEX_AUDISS_COM_Det_Cotizacion_OV_EventosTareas";
    private string SP_OPE_Cab_MBL = "NEX_AUDISS_OPE_Cab_MBL";
    private string SP_OPE_Det_CNTR = "NEX_AUDISS_OPE_Det_CNTR";
    private string SP_COM_NaveViaje = "NEX_AUDISS_COM_NaveViaje ";
    private string SP_COM_DetNaveViaje = "NEX_AUDISS_COM_DetNaveViaje";
    private string SP_COM_Contrato = "NEX_AUDISS_COM_Contrato";
    private string SP_COM_Tarifa = "NEX_AUDISS_COM_Tarifa";
    private string SP_Entidad = "NEX_AUDISS_Entidad";
    private string SP_Entidad_Servicio = "NEX_AUDISS_Entidad_Servicio";
    private string SP_Entidad_Relacionados = "NEX_AUDISS_Entidad_Relacionados";
    private string SP_OPE_LoadingList = "NEX_AUDISS_OPE_LoadingList";
    private string SP_OPE_LoadingListDetalle = "NEX_AUDISS_OPE_LoadingListDetalle";
    private string SP_NEX_AUDISS_COM_Servicio = "NEX_AUDISS_COM_Servicio";
    private IContainer components;
    private ErrorProvider errValidacion;
    private Panel pnBotones;
    private Button btnExportar;
    private PanelCaption captionAuditoria;
    private BindingNavigator navItems;
    private ToolStripLabel bindingNavigatorCountItem;
    private ToolStripButton bindingNavigatorMoveLastItem;
    private ToolStripButton bindingNavigatorMoveNextItem;
    private ToolStripSeparator bindingNavigatorSeparator;
    private ToolStripTextBox bindingNavigatorPositionItem;
    private ToolStripSeparator bindingNavigatorSeparator1;
    private ToolStripButton bindingNavigatorMovePreviousItem;
    private ToolStripButton bindingNavigatorMoveFirstItem;
    private RadGridView grdItems;

    public AuditoriaView(IUnityContainer Container, TipoAuditoria x_ItemTipoAuditoria, ObservableCollection<DataAccessFilterSQL> x_ListFilters)
    {
      this.InitializeComponent();
      try
      {
        this.Title = "Auditoria";
        this.btnExportar.Click += new EventHandler(this.btnExportar_Click);
        this.BSItems = new BindingSource();
        this.grdItems.DataSource = (object) this.BSItems;
        this.navItems.BindingSource = this.BSItems;
        this.ItemTipoAuditoria = x_ItemTipoAuditoria;
        this.ListFilters = x_ListFilters;
        this.Client = (IDelfinServices) UnityContainerExtensions.Resolve<IDelfinServices>(Container, new ResolverOverride[0]);
        this.LoadAuditoria();
      }
      catch (Exception ex)
      {
        int num = (int) Dialogos.MostrarMensajeError(this.Title, "Ha ocurrido un error al inicializar el formulario.", ex);
      }
    }

    public string Title { get; set; }

    public BindingSource BSItems { get; set; }

    public IDelfinServices Client { get; set; }

    public TipoAuditoria ItemTipoAuditoria { get; set; }

    public DataTable DTAuditoria { get; set; }

    public ObservableCollection<DataAccessFilterSQL> ListFilters { get; set; }

    private void LoadAuditoria()
    {
      try
      {
        string str1 = "";
        string str2 = "";
        switch (this.ItemTipoAuditoria)
        {
          case TipoAuditoria.AUDI_COM_Cab_Cotizacion_OV:
            str1 = this.SP_COM_Cab_Cotizacion_OV;
            str2 = "Orden de Venta";
            break;
          case TipoAuditoria.AUDI_COM_Det_Cotizacion_OV_Flete:
            str1 = this.SP_COM_Det_Cotizacion_OV_Flete;
            str2 = "Orden de Venta Detalle Flete";
            break;
          case TipoAuditoria.AUDI_COM_Det_Cotizacion_OV_Servicios:
            str1 = this.SP_COM_Det_Cotizacion_OV_Servicios;
            str2 = "Orden de Venta Detalle Servicios";
            break;
          case TipoAuditoria.AUDI_COM_Det_Cotizacion_OV_EventosTareas:
            str1 = this.SP_COM_Det_Cotizacion_OV_EventosTareas;
            str2 = "Orden de Venta Detalle Servicios Change Control";
            break;
          case TipoAuditoria.AUDI_OPE_Cab_MBL:
            str1 = this.SP_OPE_Cab_MBL;
            str2 = "MBL";
            break;
          case TipoAuditoria.AUDI_OPE_Det_CNTR:
            str1 = this.SP_OPE_Det_CNTR;
            str2 = "Orden de Venta Detalle Contenedores";
            break;
          case TipoAuditoria.AUDI_COM_NaveViaje:
            str1 = this.SP_COM_NaveViaje;
            str2 = "Nave Viaje";
            break;
          case TipoAuditoria.AUDI_COM_DetNaveViaje:
            str1 = this.SP_COM_DetNaveViaje;
            str2 = "Detalle Nave Viaje";
            break;
          case TipoAuditoria.AUDI_COM_Contrato:
            str1 = this.SP_COM_Contrato;
            str2 = "Contrato";
            break;
          case TipoAuditoria.AUDI_COM_Tarifa:
            str1 = this.SP_COM_Tarifa;
            str2 = "Tarifa";
            break;
          case TipoAuditoria.AUDI_Entidad:
            str1 = this.SP_Entidad;
            str2 = "Entidad";
            break;
          case TipoAuditoria.AUDI_Entidad_Servicio:
            str1 = this.SP_Entidad_Servicio;
            str2 = "Entidad Servicios";
            break;
          case TipoAuditoria.AUDI_Entidad_Relacionados:
            str1 = this.SP_Entidad_Relacionados;
            str2 = "Entidad Relacionados";
            break;
          case TipoAuditoria.AUDI_OPE_LoadingList:
            str1 = this.SP_OPE_LoadingList;
            str2 = "Loading List";
            break;
          case TipoAuditoria.AUDI_OPE_LoadingListDetalle:
            str1 = this.SP_OPE_LoadingListDetalle;
            str2 = "Loading List Detalle";
            break;
          case TipoAuditoria.NEX_AUDISS_COM_Servicio:
            str1 = this.SP_NEX_AUDISS_COM_Servicio;
            str2 = "Servicios";
            break;
        }
        if (!string.IsNullOrEmpty(str2))
        {
          this.Title = string.Format("Auditoria - {0}", (object) str2);
          this.Text = string.Format("Auditoria - {0}", (object) str2);
          this.captionAuditoria.set_Caption(string.Format("Resultado de la Auditoría - {0}", (object) str2));
        }
        if (string.IsNullOrEmpty(str1))
          return;
        this.DTAuditoria = this.Client.GetAllAuditoriaByFilter(str1, this.ListFilters);
        LocalizationProvider<RadGridLocalizationProvider>.CurrentProvider = (RadGridLocalizationProvider) new MySpanishRadGridLocalizationProvider();
        this.grdItems.Columns.Clear();
        this.grdItems.AllowAddNewRow = false;
        this.grdItems.AllowDeleteRow = false;
        this.grdItems.AllowEditRow = false;
        this.grdItems.AutoGenerateColumns = true;
        this.grdItems.BestFitColumns();
        this.BSItems.DataSource = (object) this.DTAuditoria;
        this.grdItems.DataSource = (object) this.BSItems;
        this.BSItems.ResetBindings(true);
        this.navItems.BindingSource = this.BSItems;
        GridAutoFit.Fit(this.grdItems);
        this.grdItems.ShowFilteringRow = false;
        this.grdItems.EnableFiltering = false;
        this.grdItems.MasterTemplate.EnableFiltering = false;
        this.grdItems.EnableGrouping = false;
        this.grdItems.MasterTemplate.EnableGrouping = false;
        this.grdItems.EnableSorting = false;
        this.grdItems.MasterTemplate.EnableCustomSorting = false;
      }
      catch (Exception ex)
      {
        int num = (int) Dialogos.MostrarMensajeError(this.Title, "Ha ocurrido un error al mostrar los elmentos en la Lista del formulario.", ex);
      }
    }

    public void Preview()
    {
      try
      {
        List<string> stringList = new List<string>();
        stringList.Add("Reporte");
        int num = 2;
        ExcelAportes excelAportes = new ExcelAportes(1, stringList, "");
        object[] objArray = new object[1];
        DataTable dataTable = excelAportes.RadGridViewToDataTable(this.grdItems, ref objArray, this.grdItems.FilterDescriptors.Count > 0);
        if (dataTable.Rows.Count <= 0)
          return;
        excelAportes.InsertarTitulos(this.Title, 1, ref num, 1, new List<string>()
        {
          ""
        }, objArray.Length);
        excelAportes.addDataArray(1, objArray, 1, num + 2, true, true);
        excelAportes.addDataList(1, dataTable, 1, num + 3, true, true);
      }
      catch (Exception ex)
      {
        int num = (int) Dialogos.MostrarMensajeError(this.Title, "A ocurrido un error exportando al  Excel.", ex);
      }
    }

    private void btnExportar_Click(object sender, EventArgs e)
    {
      this.Preview();
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
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (AuditoriaView));
      this.errValidacion = new ErrorProvider(this.components);
      this.pnBotones = new Panel();
      this.btnExportar = new Button();
      this.captionAuditoria = new PanelCaption();
      this.navItems = new BindingNavigator(this.components);
      this.bindingNavigatorCountItem = new ToolStripLabel();
      this.bindingNavigatorMoveLastItem = new ToolStripButton();
      this.bindingNavigatorMoveNextItem = new ToolStripButton();
      this.bindingNavigatorSeparator = new ToolStripSeparator();
      this.bindingNavigatorPositionItem = new ToolStripTextBox();
      this.bindingNavigatorSeparator1 = new ToolStripSeparator();
      this.bindingNavigatorMovePreviousItem = new ToolStripButton();
      this.bindingNavigatorMoveFirstItem = new ToolStripButton();
      this.grdItems = new RadGridView();
      ((ISupportInitialize) this.errValidacion).BeginInit();
      this.pnBotones.SuspendLayout();
      this.navItems.BeginInit();
      this.navItems.SuspendLayout();
      this.grdItems.BeginInit();
      this.grdItems.MasterTemplate.BeginInit();
      this.SuspendLayout();
      this.errValidacion.BlinkStyle = ErrorBlinkStyle.NeverBlink;
      this.errValidacion.ContainerControl = (ContainerControl) this;
      this.pnBotones.BackColor = Color.LightSteelBlue;
      this.pnBotones.Controls.Add((Control) this.btnExportar);
      this.pnBotones.Dock = DockStyle.Top;
      this.pnBotones.ForeColor = SystemColors.ActiveCaptionText;
      this.pnBotones.Location = new Point(0, 0);
      this.pnBotones.Name = "pnBotones";
      this.pnBotones.Size = new Size(984, 50);
      this.pnBotones.TabIndex = 43;
      this.btnExportar.AutoSize = true;
      this.btnExportar.Dock = DockStyle.Left;
      this.btnExportar.FlatAppearance.BorderColor = Color.SteelBlue;
      this.btnExportar.FlatStyle = FlatStyle.Flat;
      this.btnExportar.ForeColor = Color.Black;
      this.btnExportar.Image = (Image) Resources.export;
      this.btnExportar.ImageAlign = ContentAlignment.TopCenter;
      this.btnExportar.Location = new Point(0, 0);
      this.btnExportar.Margin = new Padding(0);
      this.btnExportar.Name = "btnExportar";
      this.btnExportar.Size = new Size(58, 50);
      this.btnExportar.TabIndex = 2;
      this.btnExportar.Text = "&Exportar";
      this.btnExportar.TextAlign = ContentAlignment.BottomCenter;
      this.btnExportar.UseVisualStyleBackColor = true;
      this.captionAuditoria.set_AllowActive(false);
      this.captionAuditoria.set_AntiAlias(false);
      this.captionAuditoria.set_Caption("Resultado de la Auditoría");
      ((Control) this.captionAuditoria).Dock = DockStyle.Top;
      ((Control) this.captionAuditoria).Font = new Font("Tahoma", 9.75f, FontStyle.Bold);
      this.captionAuditoria.set_InactiveGradientHighColor(Color.SteelBlue);
      this.captionAuditoria.set_InactiveGradientLowColor(Color.MidnightBlue);
      ((Control) this.captionAuditoria).Location = new Point(0, 50);
      ((Control) this.captionAuditoria).Name = "captionAuditoria";
      ((Control) this.captionAuditoria).Size = new Size(984, 26);
      ((Control) this.captionAuditoria).TabIndex = 48;
      this.navItems.AddNewItem = (ToolStripItem) null;
      this.navItems.BackColor = Color.SteelBlue;
      this.navItems.CountItem = (ToolStripItem) this.bindingNavigatorCountItem;
      this.navItems.DeleteItem = (ToolStripItem) null;
      this.navItems.Dock = DockStyle.Bottom;
      this.navItems.GripStyle = ToolStripGripStyle.Hidden;
      this.navItems.Items.AddRange(new ToolStripItem[8]
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
      this.navItems.Location = new Point(0, 582);
      this.navItems.MoveFirstItem = (ToolStripItem) this.bindingNavigatorMoveFirstItem;
      this.navItems.MoveLastItem = (ToolStripItem) this.bindingNavigatorMoveLastItem;
      this.navItems.MoveNextItem = (ToolStripItem) this.bindingNavigatorMoveNextItem;
      this.navItems.MovePreviousItem = (ToolStripItem) this.bindingNavigatorMovePreviousItem;
      this.navItems.Name = "navItems";
      this.navItems.Padding = new Padding(3);
      this.navItems.PositionItem = (ToolStripItem) this.bindingNavigatorPositionItem;
      this.navItems.RenderMode = ToolStripRenderMode.System;
      this.navItems.Size = new Size(984, 29);
      this.navItems.TabIndex = 50;
      this.navItems.Text = "bindingNavigator1";
      this.bindingNavigatorCountItem.Alignment = ToolStripItemAlignment.Right;
      this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
      this.bindingNavigatorCountItem.Size = new Size(35, 20);
      this.bindingNavigatorCountItem.Text = "of {0}";
      this.bindingNavigatorCountItem.ToolTipText = "Número total de elementos";
      this.bindingNavigatorMoveLastItem.Alignment = ToolStripItemAlignment.Right;
      this.bindingNavigatorMoveLastItem.DisplayStyle = ToolStripItemDisplayStyle.Image;
      this.bindingNavigatorMoveLastItem.Image = (Image) componentResourceManager.GetObject("bindingNavigatorMoveLastItem.Image");
      this.bindingNavigatorMoveLastItem.Name = "bindingNavigatorMoveLastItem";
      this.bindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = true;
      this.bindingNavigatorMoveLastItem.Size = new Size(23, 20);
      this.bindingNavigatorMoveLastItem.Text = "Ultimo";
      this.bindingNavigatorMoveNextItem.Alignment = ToolStripItemAlignment.Right;
      this.bindingNavigatorMoveNextItem.DisplayStyle = ToolStripItemDisplayStyle.Image;
      this.bindingNavigatorMoveNextItem.Image = (Image) componentResourceManager.GetObject("bindingNavigatorMoveNextItem.Image");
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
      this.bindingNavigatorMovePreviousItem.Image = (Image) componentResourceManager.GetObject("bindingNavigatorMovePreviousItem.Image");
      this.bindingNavigatorMovePreviousItem.Name = "bindingNavigatorMovePreviousItem";
      this.bindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = true;
      this.bindingNavigatorMovePreviousItem.Size = new Size(23, 20);
      this.bindingNavigatorMovePreviousItem.Text = "Anterior";
      this.bindingNavigatorMoveFirstItem.Alignment = ToolStripItemAlignment.Right;
      this.bindingNavigatorMoveFirstItem.DisplayStyle = ToolStripItemDisplayStyle.Image;
      this.bindingNavigatorMoveFirstItem.Image = (Image) componentResourceManager.GetObject("bindingNavigatorMoveFirstItem.Image");
      this.bindingNavigatorMoveFirstItem.Name = "bindingNavigatorMoveFirstItem";
      this.bindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = true;
      this.bindingNavigatorMoveFirstItem.Size = new Size(23, 20);
      this.bindingNavigatorMoveFirstItem.Text = "Primero";
      this.grdItems.BackColor = SystemColors.ControlLightLight;
      this.grdItems.Dock = DockStyle.Fill;
      this.grdItems.Location = new Point(0, 76);
      this.grdItems.Name = "grdItems";
      this.grdItems.RootElement.ControlBounds = new Rectangle(0, 76, 240, 150);
      this.grdItems.Size = new Size(984, 506);
      this.grdItems.TabIndex = 51;
      this.grdItems.TabStop = false;
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.BackColor = Color.LightSteelBlue;
      this.ClientSize = new Size(984, 611);
      this.Controls.Add((Control) this.grdItems);
      this.Controls.Add((Control) this.navItems);
      this.Controls.Add((Control) this.captionAuditoria);
      this.Controls.Add((Control) this.pnBotones);
      this.FormBorderStyle = FormBorderStyle.FixedSingle;
      this.MinimizeBox = false;
      this.Name = nameof (AuditoriaView);
      this.StartPosition = FormStartPosition.CenterScreen;
      this.Text = "Auditoria";
      ((ISupportInitialize) this.errValidacion).EndInit();
      this.pnBotones.ResumeLayout(false);
      this.pnBotones.PerformLayout();
      this.navItems.EndInit();
      this.navItems.ResumeLayout(false);
      this.navItems.PerformLayout();
      this.grdItems.MasterTemplate.EndInit();
      this.grdItems.EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();
    }
  }
}
