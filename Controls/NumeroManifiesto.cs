// Decompiled with JetBrains decompiler
// Type: Delfin.Controls.NumeroManifiesto
// Assembly: Delfin.Controls, Version=3.0.1.3, Culture=neutral, PublicKeyToken=null
// MVID: A4BA2B33-0E71-44B0-9838-A6C1CD0C2B15
// Assembly location: C:\Temp\Delfin.Controls.dll

using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Delfin.Controls
{
  public class NumeroManifiesto : UserControl
  {
    private IContainer components;
    private TextBox txtNumero;
    private Label lblGuion;
    private TextBox txtAnio;

    public NumeroManifiesto()
    {
      this.InitializeComponent();
      this.txtAnio.KeyPress += new KeyPressEventHandler(this.txtAnio_KeyPress);
      this.txtNumero.KeyPress += new KeyPressEventHandler(this.txtNumero_KeyPress);
    }

    public string SelectedValue
    {
      get
      {
        if (!string.IsNullOrEmpty(this.txtAnio.Text))
          return this.ConcatenarValor();
        return (string) null;
      }
      set
      {
        if (!string.IsNullOrEmpty(value))
          this.LoadNroManifiesto(value);
        else
          this.LimpiarNroManifiesto();
      }
    }

    private void txtNumero_KeyPress(object sender, KeyPressEventArgs e)
    {
      if (!char.IsNumber(e.KeyChar) && e.KeyChar != '\b')
      {
        e.Handled = true;
      }
      else
      {
        if (string.IsNullOrEmpty(this.txtNumero.Text) || !(this.txtNumero.Text.Substring(0, 1) == "0"))
          return;
        this.txtNumero.Text = string.Empty;
        e.Handled = true;
        int num = (int) MessageBox.Show("No se permite el cero como primer caracter", "Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
      }
    }

    private void txtAnio_KeyPress(object sender, KeyPressEventArgs e)
    {
      if (char.IsNumber(e.KeyChar) || e.KeyChar == '\b')
        return;
      e.Handled = true;
    }

    private void LimpiarNroManifiesto()
    {
      try
      {
        this.txtNumero.Text = string.Empty;
        this.txtAnio.Text = string.Empty;
      }
      catch (Exception ex)
      {
        int num = (int) MessageBox.Show("Error al limpiar el control: " + ex.Message, "Error Interno", MessageBoxButtons.OK, MessageBoxIcon.Hand);
      }
    }

    private string ConcatenarValor()
    {
      try
      {
        return string.IsNullOrEmpty(this.txtNumero.Text) ? this.txtAnio.Text + "-" : this.txtAnio.Text + "-" + this.txtNumero.Text;
      }
      catch (Exception ex)
      {
        int num = (int) MessageBox.Show("Error al concatenar el valor : " + ex.Message, "Error Interno", MessageBoxButtons.OK, MessageBoxIcon.Hand);
        return (string) null;
      }
    }

    private void LoadNroManifiesto(string NroManifiesto)
    {
      try
      {
        char[] chArray = new char[1]{ '-' };
        string[] strArray = NroManifiesto.Split(chArray);
        this.txtAnio.Text = strArray[0];
        this.txtNumero.Text = strArray[1];
      }
      catch (Exception ex)
      {
        int num = (int) MessageBox.Show("Error al obtener el valor : " + ex.Message, "Error Interno", MessageBoxButtons.OK, MessageBoxIcon.Hand);
      }
    }

    public void Clear()
    {
      this.LimpiarNroManifiesto();
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      this.txtNumero = new TextBox();
      this.lblGuion = new Label();
      this.txtAnio = new TextBox();
      this.SuspendLayout();
      this.txtNumero.Location = new Point(94, 0);
      this.txtNumero.MaxLength = 6;
      this.txtNumero.Name = "txtNumero";
      this.txtNumero.Size = new Size(76, 20);
      this.txtNumero.TabIndex = 1;
      this.lblGuion.AutoSize = true;
      this.lblGuion.Font = new Font("Verdana", 14f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.lblGuion.Location = new Point(69, -2);
      this.lblGuion.Name = "lblGuion";
      this.lblGuion.Size = new Size(19, 23);
      this.lblGuion.TabIndex = 2;
      this.lblGuion.Text = "-";
      this.txtAnio.Location = new Point(0, 0);
      this.txtAnio.MaxLength = 4;
      this.txtAnio.Name = "txtAnio";
      this.txtAnio.Size = new Size(63, 20);
      this.txtAnio.TabIndex = 0;
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.AutoSizeMode = AutoSizeMode.GrowAndShrink;
      this.BackColor = Color.LightSteelBlue;
      this.Controls.Add((Control) this.lblGuion);
      this.Controls.Add((Control) this.txtNumero);
      this.Controls.Add((Control) this.txtAnio);
      this.MaximumSize = new Size(170, 21);
      this.MinimumSize = new Size(170, 21);
      this.Name = nameof (NumeroManifiesto);
      this.Size = new Size(170, 21);
      this.ResumeLayout(false);
      this.PerformLayout();
    }
  }
}
