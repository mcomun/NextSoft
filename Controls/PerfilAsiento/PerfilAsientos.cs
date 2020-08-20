// Decompiled with JetBrains decompiler
// Type: Delfin.Controls.PerfilAsiento.PerfilAsientos
// Assembly: Delfin.Controls, Version=3.0.1.3, Culture=neutral, PublicKeyToken=null
// MVID: A4BA2B33-0E71-44B0-9838-A6C1CD0C2B15
// Assembly location: C:\Temp\Delfin.Controls.dll

using Delfin.Entities;
using Delfin.ServiceContracts;
using Infrastructure.Aspect.Collections;
using Infrastructure.Aspect.DataAccess;
using Infrastructure.WinForms.Controls.ComboBox;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Delfin.Controls.PerfilAsiento
{
  public class PerfilAsientos : UserControl
  {
    public string Title = "Ayuda Perfil de Asientos";
    private IContainer components;
    private TableLayoutPanel tableLayoutPanel3;
    private Infrastructure.WinForms.Controls.ComboBox.ComboBox cmbCABP_Codigo;
    private Infrastructure.WinForms.Controls.ComboBox.ComboBox cmbCABP_Ano;

    public PerfilAsientos()
    {
      this.InitializeComponent();
    }

    public void LoadControl(IUnityContainer Container, string x_title)
    {
      try
      {
        this.Client = (IDelfinServices) UnityContainerExtensions.Resolve<IDelfinServices>(Container, new ResolverOverride[0]);
        this.Title = x_title;
        this.ListCodigos = this.Client.GetAllCabPerfilAsientosFilter("CON_CABPSS_Todos", new ObservableCollection<DataAccessFilterSQL>());
        ObservableCollection<CabPerfilAsientos> listCodigos = this.ListCodigos;
        int index = 0;
        CabPerfilAsientos cabPerfilAsientos1 = new CabPerfilAsientos();
        cabPerfilAsientos1.set_CABP_Codigo((string) null);
        cabPerfilAsientos1.set_CABP_Ano("< Año >");
        cabPerfilAsientos1.set_CABP_Desc("< Sel. Plantilla Asiento >");
        CabPerfilAsientos cabPerfilAsientos2 = cabPerfilAsientos1;
        listCodigos.Insert(index, cabPerfilAsientos2);
        this.ListAnhos = (ObservableCollection<CabPerfilAsientos>) ObservableCollectionExtension.ToObservableCollection<CabPerfilAsientos>((IEnumerable<M0>) ((IEnumerable<CabPerfilAsientos>) this.ListCodigos).GroupBy(PerfilAno => new
        {
          CABP_Ano = PerfilAno.get_CABP_Ano()
        }).Select<IGrouping<\u003C\u003Ef__AnonymousType0<string>, CabPerfilAsientos>, CabPerfilAsientos>(Perfil =>
        {
          CabPerfilAsientos cabPerfilAsientos = new CabPerfilAsientos();
          cabPerfilAsientos.set_CABP_Ano(Perfil.Key.CABP_Ano);
          return cabPerfilAsientos;
        }));
        ((ListControl) this.cmbCABP_Ano).ValueMember = "CABP_Ano";
        ((ListControl) this.cmbCABP_Ano).DisplayMember = "CABP_Ano";
        ((ListControl) this.cmbCABP_Codigo).ValueMember = "CABP_Codigo";
        ((ListControl) this.cmbCABP_Codigo).DisplayMember = "CABP_Desc";
        ((System.Windows.Forms.ComboBox) this.cmbCABP_Ano).DataSource = (object) this.ListAnhos;
        ((System.Windows.Forms.ComboBox) this.cmbCABP_Ano).SelectedIndexChanged += new EventHandler(this.cmbCABP_Ano_SelectedIndexChanged);
        this.cmbCABP_Ano_SelectedIndexChanged((object) null, (EventArgs) null);
      }
      catch (Exception ex)
      {
      }
    }

    private void cmbCABP_Ano_SelectedIndexChanged(object sender, EventArgs e)
    {
      try
      {
        if (((System.Windows.Forms.ComboBox) this.cmbCABP_Ano).SelectedItem != null && !string.IsNullOrEmpty((((System.Windows.Forms.ComboBox) this.cmbCABP_Ano).SelectedItem as CabPerfilAsientos).get_CABP_Ano()))
        {
          ((System.Windows.Forms.ComboBox) this.cmbCABP_Codigo).DataSource = (object) ObservableCollectionExtension.ToObservableCollection<CabPerfilAsientos>((IEnumerable<M0>) ((IEnumerable<CabPerfilAsientos>) this.ListCodigos).Where<CabPerfilAsientos>((Func<CabPerfilAsientos, bool>) (Per =>
          {
            if (!(Per.get_CABP_Ano() == (((System.Windows.Forms.ComboBox) this.cmbCABP_Ano).SelectedItem as CabPerfilAsientos).get_CABP_Ano()))
              return Per.get_CABP_Ano().Equals("< Año >");
            return true;
          })));
          ((Control) this.cmbCABP_Codigo).Enabled = true;
        }
        else
        {
          ((ListControl) this.cmbCABP_Codigo).SelectedIndex = -1;
          ((Control) this.cmbCABP_Codigo).Enabled = false;
        }
        if (this.SelectedItemCabPerfilAsientosChanged == null)
          return;
        this.SelectedItemCabPerfilAsientosChanged((object) this.SelectedItem, EventArgs.Empty);
      }
      catch (Exception ex)
      {
      }
    }

    private IDelfinServices Client { get; set; }

    private ObservableCollection<CabPerfilAsientos> ListAnhos { get; set; }

    private ObservableCollection<CabPerfilAsientos> ListCodigos { get; set; }

    public CabPerfilAsientos SelectedItem { get; set; }

    public event EventHandler SelectedItemCabPerfilAsientosChanged;

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      this.components = (IContainer) new Container();
      this.tableLayoutPanel3 = new TableLayoutPanel();
      this.cmbCABP_Codigo = new Infrastructure.WinForms.Controls.ComboBox.ComboBox(this.components);
      this.cmbCABP_Ano = new Infrastructure.WinForms.Controls.ComboBox.ComboBox(this.components);
      this.tableLayoutPanel3.SuspendLayout();
      this.SuspendLayout();
      this.tableLayoutPanel3.AutoSize = true;
      this.tableLayoutPanel3.ColumnCount = 3;
      this.tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 60f));
      this.tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 140f));
      this.tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle());
      this.tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20f));
      this.tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20f));
      this.tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20f));
      this.tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20f));
      this.tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20f));
      this.tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20f));
      this.tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20f));
      this.tableLayoutPanel3.Controls.Add((Control) this.cmbCABP_Codigo, 1, 0);
      this.tableLayoutPanel3.Controls.Add((Control) this.cmbCABP_Ano, 0, 0);
      this.tableLayoutPanel3.Dock = DockStyle.Top;
      this.tableLayoutPanel3.GrowStyle = TableLayoutPanelGrowStyle.FixedSize;
      this.tableLayoutPanel3.Location = new Point(0, 0);
      this.tableLayoutPanel3.Name = "tableLayoutPanel3";
      this.tableLayoutPanel3.RowCount = 1;
      this.tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Absolute, 27f));
      this.tableLayoutPanel3.Size = new Size(202, 27);
      this.tableLayoutPanel3.TabIndex = 1;
      this.cmbCABP_Codigo.set_ComboIntSelectedValue(new int?());
      this.cmbCABP_Codigo.set_ComboSelectedItem((ComboxBoxItem) null);
      this.cmbCABP_Codigo.set_ComboStrSelectedValue((string) null);
      ((System.Windows.Forms.ComboBox) this.cmbCABP_Codigo).DropDownStyle = ComboBoxStyle.DropDownList;
      ((ListControl) this.cmbCABP_Codigo).FormattingEnabled = true;
      ((Control) this.cmbCABP_Codigo).Location = new Point(63, 3);
      ((Control) this.cmbCABP_Codigo).Name = "cmbCABP_Codigo";
      ((Control) this.cmbCABP_Codigo).Size = new Size(134, 21);
      ((Control) this.cmbCABP_Codigo).TabIndex = 2;
      this.cmbCABP_Ano.set_ComboIntSelectedValue(new int?());
      this.cmbCABP_Ano.set_ComboSelectedItem((ComboxBoxItem) null);
      this.cmbCABP_Ano.set_ComboStrSelectedValue((string) null);
      ((System.Windows.Forms.ComboBox) this.cmbCABP_Ano).DropDownStyle = ComboBoxStyle.DropDownList;
      ((ListControl) this.cmbCABP_Ano).FormattingEnabled = true;
      ((Control) this.cmbCABP_Ano).Location = new Point(3, 3);
      ((Control) this.cmbCABP_Ano).Name = "cmbCABP_Ano";
      ((Control) this.cmbCABP_Ano).Size = new Size(54, 21);
      ((Control) this.cmbCABP_Ano).TabIndex = 2;
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.Controls.Add((Control) this.tableLayoutPanel3);
      this.Margin = new Padding(0);
      this.MinimumSize = new Size(200, 27);
      this.Name = nameof (PerfilAsientos);
      this.Size = new Size(202, 27);
      this.tableLayoutPanel3.ResumeLayout(false);
      this.ResumeLayout(false);
      this.PerformLayout();
    }
  }
}
