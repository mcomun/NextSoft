// Decompiled with JetBrains decompiler
// Type: Delfin.Controls.Serie.SeriesLarge
// Assembly: Delfin.Controls, Version=3.0.1.3, Culture=neutral, PublicKeyToken=null
// MVID: A4BA2B33-0E71-44B0-9838-A6C1CD0C2B15
// Assembly location: C:\Temp\Delfin.Controls.dll

using Delfin.Controls.Tipos;
using Delfin.Entities;
using Delfin.ServiceContracts;
using Infrastructure.Aspect.Collections;
using Infrastructure.WinForms.Controls.ComboBox;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Delfin.Controls.Serie
{
  public class SeriesLarge : UserControl
  {
    public string Title = "Ayuda de Entidad";
    private BindingSource BSItemsTiposTDO;
    private IContainer components;
    private TableLayoutPanel tableLayoutPanel3;
    private Infrastructure.WinForms.Controls.ComboBox.ComboBox cmbSERI_Serie;
    private TextBox txtSERI_UnidadNegocio;
    private Label lblTIPO_CodTDO;
    private Label lblSERI_UnidadNegocio;
    private Label lblSERI_Serie;
    private ComboBoxTipos cmbTIPO_CodTDO;

    public SeriesLarge()
    {
      this.InitializeComponent();
      try
      {
        this.txtSERI_UnidadNegocio.ReadOnly = true;
        ((Control) this.cmbSERI_Serie).Enabled = false;
      }
      catch (Exception ex)
      {
      }
    }

    public void LoadControl(IUnityContainer Container, string x_title, string[] x_TiposTDO = null, string[] x_UnidadNegocio = null, SeriesLarge.TInicio x_opcion = SeriesLarge.TInicio.Normal)
    {
      try
      {
        this.Client = (IDelfinServices) UnityContainerExtensions.Resolve<IDelfinServices>(Container, new ResolverOverride[0]);
        this.Title = x_title;
        if (x_TiposTDO != null)
        {
          ObservableCollection<Delfin.Entities.Tipos> tiposByTipoCodTabla = this.Client.GetAllTiposByTipoCodTabla("TDO");
          this.ListTiposTDO = new ObservableCollection<Delfin.Entities.Tipos>();
          foreach (string str in x_TiposTDO)
          {
            string iTDO = str;
            this.ListTiposTDO = (ObservableCollection<Delfin.Entities.Tipos>) ObservableCollectionExtension.ToObservableCollection<Delfin.Entities.Tipos>((IEnumerable<M0>) ((IEnumerable<Delfin.Entities.Tipos>) this.ListTiposTDO).Concat<Delfin.Entities.Tipos>((IEnumerable<Delfin.Entities.Tipos>) ObservableCollectionExtension.ToObservableCollection<Delfin.Entities.Tipos>((IEnumerable<M0>) ((IEnumerable<Delfin.Entities.Tipos>) tiposByTipoCodTabla).Where<Delfin.Entities.Tipos>((Func<Delfin.Entities.Tipos, bool>) (T => T.get_TIPO_CodTipo().Equals(iTDO))))));
          }
        }
        else
          this.ListTiposTDO = this.Client.GetAllTiposByTipoCodTabla("TDO");
        if (x_UnidadNegocio != null)
        {
          ObservableCollection<Series> allSeries = this.Client.GetAllSeries();
          this.ListSeries = new ObservableCollection<Series>();
          foreach (string str in x_UnidadNegocio)
          {
            string iUN = str;
            this.ListSeries = (ObservableCollection<Series>) ObservableCollectionExtension.ToObservableCollection<Series>((IEnumerable<M0>) ((IEnumerable<Series>) this.ListSeries).Concat<Series>((IEnumerable<Series>) ObservableCollectionExtension.ToObservableCollection<Series>((IEnumerable<M0>) ((IEnumerable<Series>) allSeries).Where<Series>((Func<Series, bool>) (S => S.get_SERI_UnidadNegocio().Contains(iUN))))).Distinct<Series>());
          }
        }
        else
          this.ListSeries = this.Client.GetAllSeries();
        ObservableCollection<Series> listSeries = this.ListSeries;
        int index = 0;
        Series series1 = new Series();
        series1.set_SERI_Serie("< Sel. Serie >");
        series1.set_SERI_Desc("%1%");
        series1.set_SERI_Activo(new bool?());
        Series series2 = series1;
        listSeries.Insert(index, series2);
        this.cmbTIPO_CodTDO.ValueMember = "TIPO_CodTipo";
        this.cmbTIPO_CodTDO.DisplayMember = "TIPO_Desc1";
        this.cmbTIPO_CodTDO.LoadControl(this.ListTiposTDO, "Ayuda de Tipos de Documento", "< Todos >", ListSortDirection.Ascending);
        this.cmbTIPO_CodTDO.SelectedIndexChanged += new EventHandler(this.cmbTIPO_CodTDO_SelectedIndexChanged);
        if (this.ListTiposTDO.Count > 1)
          this.cmbTIPO_CodTDO.SelectedIndex = 1;
        else
          this.cmbTIPO_CodTDO_SelectedIndexChanged((object) null, (EventArgs) null);
        switch (x_opcion)
        {
          case SeriesLarge.TInicio.SoloSerie:
            this.cmbTIPO_CodTDO.Enabled = false;
            this.lblTIPO_CodTDO.Enabled = false;
            break;
        }
      }
      catch (Exception ex)
      {
      }
    }

    private IDelfinServices Client { get; set; }

    public ObservableCollection<Series> ListSeries { get; set; }

    public ObservableCollection<Delfin.Entities.Tipos> ListTiposTDO { get; set; }

    public Series SelectedItem { get; set; }

    public Delfin.Entities.Tipos SelectedItemTipoTDO { get; set; }

    public event EventHandler SelectedItemTipoTDOChanged;

    public event EventHandler SelectedItemSerieChanged;

    public bool cmbTIPO_CodTDO_Enabled
    {
      get
      {
        return this.cmbTIPO_CodTDO.Enabled;
      }
      set
      {
        this.cmbTIPO_CodTDO.Enabled = value;
      }
    }

    public bool cmbSERI_Serie_Enabled
    {
      get
      {
        return ((Control) this.cmbSERI_Serie).Enabled;
      }
      set
      {
        ((Control) this.cmbSERI_Serie).Enabled = value;
      }
    }

    public void Clear()
    {
      try
      {
        this.cmbTIPO_CodTDO.SelectedIndex = 0;
      }
      catch (Exception ex)
      {
      }
    }

    public void SetValue(string TIPO_CodTDO, string SERI_Serie)
    {
      try
      {
        this.cmbTIPO_CodTDO.SelectedValue = (object) TIPO_CodTDO;
        ((ListControl) this.cmbSERI_Serie).SelectedValue = (object) SERI_Serie;
      }
      catch (Exception ex)
      {
      }
    }

    private void cmbTIPO_CodTDO_SelectedIndexChanged(object sender, EventArgs e)
    {
      try
      {
        if (this.cmbTIPO_CodTDO.TiposSelectedItem != null)
        {
          ((System.Windows.Forms.ComboBox) this.cmbSERI_Serie).SelectedIndexChanged -= new EventHandler(this.cmbSERI_Serie_SelectedIndexChanged);
          this.SelectedItemTipoTDO = this.cmbTIPO_CodTDO.TiposSelectedItem;
          ((ListControl) this.cmbSERI_Serie).ValueMember = "SERI_Serie";
          ((ListControl) this.cmbSERI_Serie).DisplayMember = "SERI_Serie";
          ((System.Windows.Forms.ComboBox) this.cmbSERI_Serie).DataSource = (object) ObservableCollectionExtension.ToObservableCollection<Series>((IEnumerable<M0>) ((IEnumerable<Series>) this.ListSeries).Where<Series>((Func<Series, bool>) (Ser =>
          {
            if (!(Ser.get_TIPO_CodTDO() == this.cmbTIPO_CodTDO.TiposSelectedItem.get_TIPO_CodTipo()))
              return Ser.get_SERI_Desc().Equals("%1%");
            return true;
          })));
          ((Control) this.cmbSERI_Serie).Enabled = true;
          if ((((System.Windows.Forms.ComboBox) this.cmbSERI_Serie).DataSource as ObservableCollection<Series>).Count > 1)
          {
            ((ListControl) this.cmbSERI_Serie).SelectedIndex = 1;
            this.txtSERI_UnidadNegocio.Text = (((System.Windows.Forms.ComboBox) this.cmbSERI_Serie).SelectedItem as Series).GetSERI_UnidadNegocio();
            this.SelectedItem = ((System.Windows.Forms.ComboBox) this.cmbSERI_Serie).SelectedItem as Series;
          }
          else
            this.cmbSERI_Serie_SelectedIndexChanged((object) null, (EventArgs) null);
          ((System.Windows.Forms.ComboBox) this.cmbSERI_Serie).SelectedIndexChanged += new EventHandler(this.cmbSERI_Serie_SelectedIndexChanged);
        }
        else
        {
          this.SelectedItemTipoTDO = (Delfin.Entities.Tipos) null;
          this.SelectedItem = (Series) null;
          ((System.Windows.Forms.ComboBox) this.cmbSERI_Serie).SelectedIndexChanged -= new EventHandler(this.cmbSERI_Serie_SelectedIndexChanged);
          ((ListControl) this.cmbSERI_Serie).SelectedIndex = -1;
          ((Control) this.cmbSERI_Serie).Enabled = false;
          this.txtSERI_UnidadNegocio.Clear();
        }
        if (this.SelectedItemTipoTDOChanged == null)
          return;
        this.SelectedItemTipoTDOChanged((object) this.SelectedItemTipoTDO, EventArgs.Empty);
      }
      catch (Exception ex)
      {
      }
    }

    private void cmbSERI_Serie_SelectedIndexChanged(object sender, EventArgs e)
    {
      try
      {
        if (((System.Windows.Forms.ComboBox) this.cmbSERI_Serie).SelectedItem != null && !(((System.Windows.Forms.ComboBox) this.cmbSERI_Serie).SelectedItem as Series).get_SERI_Desc().Equals("%1%"))
        {
          this.SelectedItem = ((System.Windows.Forms.ComboBox) this.cmbSERI_Serie).SelectedItem as Series;
          this.txtSERI_UnidadNegocio.Text = (((System.Windows.Forms.ComboBox) this.cmbSERI_Serie).SelectedItem as Series).GetSERI_UnidadNegocio();
        }
        else
        {
          this.SelectedItem = (Series) null;
          this.txtSERI_UnidadNegocio.Clear();
        }
        if (this.SelectedItemSerieChanged == null)
          return;
        this.SelectedItemSerieChanged((object) this.SelectedItem, EventArgs.Empty);
      }
      catch (Exception ex)
      {
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
      this.tableLayoutPanel3 = new TableLayoutPanel();
      this.lblTIPO_CodTDO = new Label();
      this.lblSERI_UnidadNegocio = new Label();
      this.lblSERI_Serie = new Label();
      this.cmbSERI_Serie = new Infrastructure.WinForms.Controls.ComboBox.ComboBox();
      this.txtSERI_UnidadNegocio = new TextBox();
      this.cmbTIPO_CodTDO = new ComboBoxTipos();
      this.tableLayoutPanel3.SuspendLayout();
      this.SuspendLayout();
      this.tableLayoutPanel3.AutoSize = true;
      this.tableLayoutPanel3.ColumnCount = 8;
      this.tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 150f));
      this.tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 180f));
      this.tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 70f));
      this.tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 90f));
      this.tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 75f));
      this.tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 150f));
      this.tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 15f));
      this.tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle());
      this.tableLayoutPanel3.Controls.Add((Control) this.lblTIPO_CodTDO, 0, 0);
      this.tableLayoutPanel3.Controls.Add((Control) this.lblSERI_UnidadNegocio, 4, 0);
      this.tableLayoutPanel3.Controls.Add((Control) this.lblSERI_Serie, 2, 0);
      this.tableLayoutPanel3.Controls.Add((Control) this.cmbSERI_Serie, 3, 0);
      this.tableLayoutPanel3.Controls.Add((Control) this.txtSERI_UnidadNegocio, 5, 0);
      this.tableLayoutPanel3.Controls.Add((Control) this.cmbTIPO_CodTDO, 1, 0);
      this.tableLayoutPanel3.Dock = DockStyle.Top;
      this.tableLayoutPanel3.GrowStyle = TableLayoutPanelGrowStyle.FixedSize;
      this.tableLayoutPanel3.Location = new Point(0, 0);
      this.tableLayoutPanel3.Margin = new Padding(0);
      this.tableLayoutPanel3.MinimumSize = new Size(730, 27);
      this.tableLayoutPanel3.Name = "tableLayoutPanel3";
      this.tableLayoutPanel3.RowCount = 1;
      this.tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Absolute, 27f));
      this.tableLayoutPanel3.Size = new Size(732, 27);
      this.tableLayoutPanel3.TabIndex = 1;
      this.lblTIPO_CodTDO.AutoSize = true;
      this.lblTIPO_CodTDO.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.lblTIPO_CodTDO.Location = new Point(10, 7);
      this.lblTIPO_CodTDO.Margin = new Padding(10, 7, 3, 0);
      this.lblTIPO_CodTDO.Name = "lblTIPO_CodTDO";
      this.lblTIPO_CodTDO.Size = new Size(109, 13);
      this.lblTIPO_CodTDO.TabIndex = 0;
      this.lblTIPO_CodTDO.Text = "Tipo Documento :";
      this.lblSERI_UnidadNegocio.AutoSize = true;
      this.lblSERI_UnidadNegocio.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.lblSERI_UnidadNegocio.Location = new Point(500, 7);
      this.lblSERI_UnidadNegocio.Margin = new Padding(10, 7, 3, 0);
      this.lblSERI_UnidadNegocio.Name = "lblSERI_UnidadNegocio";
      this.lblSERI_UnidadNegocio.Size = new Size(54, 13);
      this.lblSERI_UnidadNegocio.TabIndex = 4;
      this.lblSERI_UnidadNegocio.Text = "U.Neg. :";
      this.lblSERI_Serie.AutoSize = true;
      this.lblSERI_Serie.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.lblSERI_Serie.Location = new Point(340, 7);
      this.lblSERI_Serie.Margin = new Padding(10, 7, 3, 0);
      this.lblSERI_Serie.Name = "lblSERI_Serie";
      this.lblSERI_Serie.Size = new Size(46, 13);
      this.lblSERI_Serie.TabIndex = 2;
      this.lblSERI_Serie.Text = "Serie :";
      this.cmbSERI_Serie.set_ComboIntSelectedValue(new int?());
      this.cmbSERI_Serie.set_ComboSelectedItem((ComboxBoxItem) null);
      this.cmbSERI_Serie.set_ComboStrSelectedValue((string) null);
      ((System.Windows.Forms.ComboBox) this.cmbSERI_Serie).DropDownStyle = ComboBoxStyle.DropDownList;
      ((ListControl) this.cmbSERI_Serie).FormattingEnabled = true;
      ((Control) this.cmbSERI_Serie).Location = new Point(403, 3);
      ((Control) this.cmbSERI_Serie).Name = "cmbSERI_Serie";
      ((Control) this.cmbSERI_Serie).Size = new Size(84, 21);
      ((Control) this.cmbSERI_Serie).TabIndex = 3;
      this.txtSERI_UnidadNegocio.Location = new Point(568, 3);
      this.txtSERI_UnidadNegocio.Name = "txtSERI_UnidadNegocio";
      this.txtSERI_UnidadNegocio.Size = new Size(144, 20);
      this.txtSERI_UnidadNegocio.TabIndex = 5;
      this.cmbTIPO_CodTDO.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cmbTIPO_CodTDO.FormattingEnabled = true;
      this.cmbTIPO_CodTDO.Location = new Point(153, 3);
      this.cmbTIPO_CodTDO.Name = "cmbTIPO_CodTDO";
      this.cmbTIPO_CodTDO.Size = new Size(174, 21);
      this.cmbTIPO_CodTDO.TabIndex = 1;
      this.cmbTIPO_CodTDO.TiposSelectedItem = (Delfin.Entities.Tipos) null;
      this.cmbTIPO_CodTDO.TiposSelectedValue = (string) null;
      this.cmbTIPO_CodTDO.TiposTitulo = (string) null;
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.Controls.Add((Control) this.tableLayoutPanel3);
      this.Margin = new Padding(0);
      this.Name = nameof (SeriesLarge);
      this.Size = new Size(732, 27);
      this.tableLayoutPanel3.ResumeLayout(false);
      this.tableLayoutPanel3.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();
    }

    public enum TInicio
    {
      Normal,
      SoloSerie,
    }
  }
}
