// Decompiled with JetBrains decompiler
// Type: Delfin.Controls.PerfilAsientos.PerfilAsientosControl
// Assembly: Delfin.Controls, Version=3.0.1.3, Culture=neutral, PublicKeyToken=null
// MVID: A4BA2B33-0E71-44B0-9838-A6C1CD0C2B15
// Assembly location: C:\Temp\Delfin.Controls.dll

using Delfin.Entities;
using Infrastructure.WinForms.Controls;
using Microsoft.Practices.Unity;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Delfin.Controls.PerfilAsientos
{
  public class PerfilAsientosControl : UserControl
  {
    private IContainer components;
    private TextBox txtCABP_Ano;
    private TableLayoutPanel tableLayoutPanel3;
    private PrefilAsientosAyuda txaCABP_Codigo;

    public PerfilAsientosControl()
    {
      this.InitializeComponent();
      this.txtCABP_Ano.ReadOnly = true;
      this.txtCABP_Ano.MaxLength = 4;
      this.txaCABP_Codigo.add_AyudaClean(new EventHandler(this.txaCABP_Codigo_AyudaClean));
      this.txaCABP_Codigo.SelectedItemPerfilAsientosChanged += new EventHandler(this.txaCABP_Codigo_SelectedItemPerfilAsientosChanged);
    }

    public void LoadControl(IUnityContainer Container, string x_title)
    {
      try
      {
        this.txaCABP_Codigo.LoadControl(Container, x_title);
        this.Title = x_title;
      }
      catch (Exception ex)
      {
        throw;
      }
    }

    public string Title { get; set; }

    public CabPerfilAsientos SelectedItem
    {
      get
      {
        return this.txaCABP_Codigo.SelectedItem;
      }
    }

    public string CABP_Ano
    {
      get
      {
        return this.txaCABP_Codigo.CABP_Ano;
      }
      set
      {
        this.txaCABP_Codigo.CABP_Ano = value;
        this.txtCABP_Ano.Text = value;
        if (this.SelectedItemChanged == null)
          return;
        this.SelectedItemChanged((object) this.SelectedItem, EventArgs.Empty);
      }
    }

    public void SetPerfilAsientos(string CABP_Ano, string CABP_Codigo)
    {
      try
      {
        if (!string.IsNullOrEmpty(CABP_Ano) && !string.IsNullOrEmpty(CABP_Codigo))
        {
          this.txtCABP_Ano.Text = CABP_Ano;
          this.txaCABP_Codigo.SetPerfilAsientos(CABP_Ano, CABP_Codigo);
          if (this.SelectedItemChanged == null)
            return;
          this.SelectedItemChanged((object) this.SelectedItem, EventArgs.Empty);
        }
        else
        {
          this.txaCABP_Codigo.ClearPerfilAsientos();
          int num = (int) Dialogos.MostrarMensajeInformacion(this.Title, "No se ingreso valores correctos.", (Dialogos.Boton) 0);
        }
      }
      catch (Exception ex)
      {
      }
    }

    public void SetPerfilAsientos(CabPerfilAsientos item)
    {
      try
      {
        if (item != null)
        {
          this.txtCABP_Ano.Text = item.get_CABP_Ano();
          this.txaCABP_Codigo.SetPerfilAsientos(item);
          if (this.SelectedItemChanged == null)
            return;
          this.SelectedItemChanged((object) this.SelectedItem, EventArgs.Empty);
        }
        else
        {
          this.txaCABP_Codigo.ClearPerfilAsientos();
          int num = (int) Dialogos.MostrarMensajeInformacion(this.Title, "No se ingreso valores correctos.", (Dialogos.Boton) 0);
        }
      }
      catch (Exception ex)
      {
      }
    }

    public void Clear()
    {
      try
      {
        this.txaCABP_Codigo.remove_AyudaClean(new EventHandler(this.txaCABP_Codigo_AyudaClean));
        this.txaCABP_Codigo.ClearPerfilAsientos();
        this.txtCABP_Ano.Clear();
        if (this.SelectedItemChanged != null)
          this.SelectedItemChanged((object) this.SelectedItem, EventArgs.Empty);
        this.txaCABP_Codigo.add_AyudaClean(new EventHandler(this.txaCABP_Codigo_AyudaClean));
      }
      catch (Exception ex)
      {
      }
    }

    public event EventHandler SelectedItemChanged;

    private void txaCABP_Codigo_AyudaClean(object sender, EventArgs e)
    {
      try
      {
        this.txaCABP_Codigo.remove_AyudaClean(new EventHandler(this.txaCABP_Codigo_AyudaClean));
        this.txaCABP_Codigo.ClearPerfilAsientos();
        if (this.SelectedItemChanged != null)
          this.SelectedItemChanged((object) this.SelectedItem, EventArgs.Empty);
        this.txaCABP_Codigo.add_AyudaClean(new EventHandler(this.txaCABP_Codigo_AyudaClean));
      }
      catch (Exception ex)
      {
      }
    }

    private void txaCABP_Codigo_SelectedItemPerfilAsientosChanged(object sender, EventArgs e)
    {
      try
      {
        if (this.SelectedItemChanged == null)
          return;
        this.SelectedItemChanged((object) this.SelectedItem, EventArgs.Empty);
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
      this.txtCABP_Ano = new TextBox();
      this.tableLayoutPanel3 = new TableLayoutPanel();
      this.txaCABP_Codigo = new PrefilAsientosAyuda();
      this.tableLayoutPanel3.SuspendLayout();
      this.SuspendLayout();
      this.txtCABP_Ano.Location = new Point(3, 3);
      this.txtCABP_Ano.Name = "txtCABP_Ano";
      this.txtCABP_Ano.Size = new Size(34, 20);
      this.txtCABP_Ano.TabIndex = 0;
      this.txtCABP_Ano.TextAlign = HorizontalAlignment.Center;
      this.tableLayoutPanel3.AutoSize = true;
      this.tableLayoutPanel3.ColumnCount = 2;
      this.tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 40f));
      this.tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 160f));
      this.tableLayoutPanel3.Controls.Add((Control) this.txtCABP_Ano, 0, 0);
      this.tableLayoutPanel3.Controls.Add((Control) this.txaCABP_Codigo, 1, 0);
      this.tableLayoutPanel3.Dock = DockStyle.Top;
      this.tableLayoutPanel3.GrowStyle = TableLayoutPanelGrowStyle.FixedSize;
      this.tableLayoutPanel3.Location = new Point(0, 0);
      this.tableLayoutPanel3.Name = "tableLayoutPanel3";
      this.tableLayoutPanel3.RowCount = 1;
      this.tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Absolute, 27f));
      this.tableLayoutPanel3.Size = new Size(200, 27);
      this.tableLayoutPanel3.TabIndex = 1;
      this.txaCABP_Codigo.set_ActivarAyudaAuto(false);
      ((Control) this.txaCABP_Codigo).Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.txaCABP_Codigo.CABP_Ano = (string) null;
      ((TextBox) this.txaCABP_Codigo).CharacterCasing = CharacterCasing.Upper;
      this.txaCABP_Codigo.set_EnabledAyuda(true);
      this.txaCABP_Codigo.set_EnabledAyudaButton(true);
      this.txaCABP_Codigo.set_EsFiltro(false);
      ((Control) this.txaCABP_Codigo).Location = new Point(43, 3);
      this.txaCABP_Codigo.set_LongitudAceptada(0);
      ((TextBoxBase) this.txaCABP_Codigo).MaxLength = 100;
      this.txaCABP_Codigo.set_MyInstanciaAyuda((TextBoxAyuda.InstanciaAyuda) 0);
      ((Control) this.txaCABP_Codigo).Name = "txaCABP_Codigo";
      this.txaCABP_Codigo.set_RellenaCeros(false);
      this.txaCABP_Codigo.SelectedItem = (CabPerfilAsientos) null;
      ((Control) this.txaCABP_Codigo).Size = new Size(154, 20);
      ((Control) this.txaCABP_Codigo).TabIndex = 1;
      this.txaCABP_Codigo.set_Tipo((TextBoxAyuda.TipoTextBoxAyuda) 1);
      this.txaCABP_Codigo.set_Value((object) null);
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.Controls.Add((Control) this.tableLayoutPanel3);
      this.Margin = new Padding(0);
      this.MinimumSize = new Size(200, 27);
      this.Name = nameof (PerfilAsientosControl);
      this.Size = new Size(200, 27);
      this.tableLayoutPanel3.ResumeLayout(false);
      this.tableLayoutPanel3.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();
    }
  }
}
