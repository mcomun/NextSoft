// Decompiled with JetBrains decompiler
// Type: Delfin.Controls.UbigeoPaisControl
// Assembly: Delfin.Controls, Version=3.0.1.3, Culture=neutral, PublicKeyToken=null
// MVID: A4BA2B33-0E71-44B0-9838-A6C1CD0C2B15
// Assembly location: C:\Temp\Delfin.Controls.dll

using Delfin.Entities;
using Infrastructure.WinFormsControls;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Delfin.Controls
{
  public class UbigeoPaisControl : UserControl, IUbigeoControl
  {
    private IContainer components;
    private TableLayoutPanel tableUbigeo;
    private ComboBox UBIG_CodigoDEPA;
    private ComboBox UBIG_CodigoPROV;
    private ComboBox UBIG_CodigoDIST;
    private Label label2;
    private Label lblENTC_Telef1;
    private Label label1;
    private Label label3;
    private ComboBox TIPO_CodPais;

    public UbigeoPaisControl()
    {
      this.InitializeComponent();
      this.TIPO_CodPais.SelectedIndexChanged += new EventHandler(this.TIPO_CodPais_SelectedIndexChanged);
    }

    public UbigeoControlPresenter Presenter { get; set; }

    public string TableName
    {
      get
      {
        return this.tableUbigeo.Name;
      }
      set
      {
        this.tableUbigeo.Name = value;
      }
    }

    public string PaisSelectedValue
    {
      get
      {
        if (this.TIPO_CodPais.SelectedItem != null && this.TIPO_CodPais.SelectedValue != null && this.TIPO_CodPais.SelectedValue != (object) "000")
          return ((Tipos) this.TIPO_CodPais.SelectedItem).get_TIPO_CodTipo();
        return (string) null;
      }
      set
      {
        if (string.IsNullOrEmpty(value))
          this.TIPO_CodPais.SelectedValue = (object) "000";
        else
          this.TIPO_CodPais.SelectedValue = (object) value;
      }
    }

    public Tipos PaisSelectedItem
    {
      get
      {
        if (this.TIPO_CodPais.SelectedItem != null)
          return (Tipos) this.TIPO_CodPais.SelectedItem;
        return (Tipos) null;
      }
    }

    public string DepartamentoSelectedValue
    {
      get
      {
        if (this.UBIG_CodigoDEPA.SelectedItem != null)
          return ((Ubigeos) this.UBIG_CodigoDEPA.SelectedItem).get_UBIG_Codigo();
        return (string) null;
      }
      set
      {
        if (!string.IsNullOrEmpty(value))
          this.UBIG_CodigoDEPA.SelectedValue = (object) value;
        else
          this.UBIG_CodigoDEPA.SelectedValue = (object) null;
      }
    }

    public Ubigeos DepartamentoSelectedItem
    {
      get
      {
        if (this.UBIG_CodigoDEPA.SelectedItem != null)
          return (Ubigeos) this.UBIG_CodigoDEPA.SelectedItem;
        return (Ubigeos) null;
      }
      set
      {
        if (value != null && !string.IsNullOrEmpty(value.get_UBIG_Codigo()))
          this.UBIG_CodigoDEPA.SelectedValue = (object) value.get_UBIG_Codigo();
        else
          this.UBIG_CodigoDEPA.SelectedValue = (object) null;
      }
    }

    public string ProvinciaSelectedValue
    {
      get
      {
        if (this.UBIG_CodigoPROV.SelectedItem != null)
          return ((Ubigeos) this.UBIG_CodigoPROV.SelectedItem).get_UBIG_Codigo();
        return (string) null;
      }
      set
      {
        if (!string.IsNullOrEmpty(value))
          this.UBIG_CodigoPROV.SelectedValue = (object) value;
        else
          this.UBIG_CodigoPROV.SelectedValue = (object) null;
      }
    }

    public Ubigeos ProvinciaSelectedItem
    {
      get
      {
        if (this.UBIG_CodigoPROV.SelectedItem != null)
          return (Ubigeos) this.UBIG_CodigoPROV.SelectedItem;
        return (Ubigeos) null;
      }
      set
      {
        if (value != null && !string.IsNullOrEmpty(value.get_UBIG_Codigo()))
          this.UBIG_CodigoPROV.SelectedValue = (object) value.get_UBIG_Codigo();
        else
          this.UBIG_CodigoPROV.SelectedValue = (object) null;
      }
    }

    public string DistritoSelectedValue
    {
      get
      {
        if (this.UBIG_CodigoDIST.SelectedItem != null)
          return ((Ubigeos) this.UBIG_CodigoDIST.SelectedItem).get_UBIG_Codigo();
        return (string) null;
      }
      set
      {
        if (!string.IsNullOrEmpty(value))
          this.UBIG_CodigoDIST.SelectedValue = (object) value;
        else
          this.UBIG_CodigoDIST.SelectedValue = (object) null;
      }
    }

    public Ubigeos DistritoSelectedItem
    {
      get
      {
        if (this.UBIG_CodigoDIST.SelectedItem != null)
          return (Ubigeos) this.UBIG_CodigoDIST.SelectedItem;
        return (Ubigeos) null;
      }
      set
      {
        if (value != null && !string.IsNullOrEmpty(value.get_UBIG_Codigo()))
          this.UBIG_CodigoDIST.SelectedValue = (object) value.get_UBIG_Codigo();
        else
          this.UBIG_CodigoDIST.SelectedValue = (object) null;
      }
    }

    public string SelectedValue
    {
      get
      {
        if (this.UBIG_CodigoDIST.SelectedItem != null)
          return ((Ubigeos) this.UBIG_CodigoDIST.SelectedItem).get_UBIG_Codigo();
        return (string) null;
      }
      set
      {
        if (string.IsNullOrEmpty(value))
        {
          this.UBIG_CodigoDEPA.SelectedItem = (object) null;
          this.UBIG_CodigoPROV.SelectedItem = (object) null;
          this.UBIG_CodigoDIST.SelectedItem = (object) null;
        }
        else
        {
          string[] strArray = value.Split('.');
          if (strArray.Length == 1)
            this.UBIG_CodigoDEPA.SelectedValue = (object) value.Trim();
          else if (strArray.Length == 2)
          {
            this.UBIG_CodigoDEPA.SelectedValue = (object) strArray[0];
            this.UBIG_CodigoPROV.SelectedValue = (object) value.Trim();
          }
          else if (strArray.Length == 3)
          {
            this.UBIG_CodigoDEPA.SelectedValue = (object) strArray[0];
            this.UBIG_CodigoPROV.SelectedValue = (object) (strArray[0] + "." + strArray[1]);
            this.UBIG_CodigoDIST.SelectedValue = (object) value.Trim();
          }
          else
          {
            if (this.Presenter == null || this.Presenter.ListUbigeoDep == null || this.Presenter.ListUbigeoDep.Count <= 0)
              return;
            this.UBIG_CodigoDEPA.SelectedValue = (object) ((IEnumerable<Ubigeos>) this.Presenter.ListUbigeoDep).ElementAt<Ubigeos>(0).get_UBIG_Codigo();
          }
        }
      }
    }

    public Ubigeos SelectedItem
    {
      get
      {
        if (this.UBIG_CodigoDIST.SelectedItem != null && ((Ubigeos) this.UBIG_CodigoDIST.SelectedItem).get_UBIG_Codigo() != null)
          return (Ubigeos) this.UBIG_CodigoDIST.SelectedItem;
        return (Ubigeos) null;
      }
    }

    private void TIPO_CodPais_SelectedIndexChanged(object sender, EventArgs e)
    {
      try
      {
        if (this.TIPO_CodPais.SelectedItem != null && this.TIPO_CodPais.SelectedValue != null && this.TIPO_CodPais.SelectedValue.ToString() != "000")
        {
          this.UBIG_CodigoDEPA.SelectedIndexChanged -= new EventHandler(this.UBIG_CodigoDEPA_SelectedIndexChanged);
          this.UBIG_CodigoDEPA.DataSource = (object) null;
          this.Presenter.LoadComboDepartamento(((Tipos) this.TIPO_CodPais.SelectedItem).get_TIPO_CodTipo());
          this.UBIG_CodigoPROV.SelectedIndexChanged -= new EventHandler(this.UBIG_CodigoPROV_SelectedIndexChanged);
          this.UBIG_CodigoPROV.DataSource = (object) null;
          this.UBIG_CodigoPROV.SelectedIndexChanged += new EventHandler(this.UBIG_CodigoPROV_SelectedIndexChanged);
          this.UBIG_CodigoDIST.DataSource = (object) null;
          this.UBIG_CodigoDEPA.SelectedIndexChanged += new EventHandler(this.UBIG_CodigoDEPA_SelectedIndexChanged);
          if (!this.Enabled)
            return;
          this.UBIG_CodigoDEPA.Enabled = true;
          this.UBIG_CodigoPROV.Enabled = false;
          this.UBIG_CodigoDIST.Enabled = false;
        }
        else
        {
          this.UBIG_CodigoDEPA.DataSource = (object) null;
          if (this.Enabled)
            this.UBIG_CodigoDEPA.Enabled = false;
          this.TIPO_CodPais.SelectedIndex = 0;
        }
      }
      catch (Exception ex)
      {
        int num = (int) Dialogos.MostrarMensajeError(this.Titulo, "Ha ocurrido un error al cargar los Departametos.", ex);
      }
    }

    private void UBIG_CodigoDEPA_SelectedIndexChanged(object sender, EventArgs e)
    {
      try
      {
        if (this.TIPO_CodPais.SelectedItem != null && this.TIPO_CodPais.SelectedValue != null && (this.TIPO_CodPais.SelectedValue.ToString() != "000" && this.UBIG_CodigoDEPA.SelectedItem != null) && (this.UBIG_CodigoDEPA.SelectedValue != null && this.UBIG_CodigoDEPA.SelectedValue != (object) "00"))
        {
          this.UBIG_CodigoPROV.SelectedIndexChanged -= new EventHandler(this.UBIG_CodigoPROV_SelectedIndexChanged);
          this.UBIG_CodigoPROV.DataSource = (object) null;
          this.Presenter.LoadComboProvincia(((Tipos) this.TIPO_CodPais.SelectedItem).get_TIPO_CodTipo(), ((Ubigeos) this.UBIG_CodigoDEPA.SelectedItem).get_UBIG_Codigo());
          this.UBIG_CodigoDIST.DataSource = (object) null;
          this.UBIG_CodigoPROV.SelectedIndexChanged += new EventHandler(this.UBIG_CodigoPROV_SelectedIndexChanged);
          if (!this.Enabled)
            return;
          this.UBIG_CodigoPROV.Enabled = true;
          this.UBIG_CodigoDIST.Enabled = false;
        }
        else
        {
          this.UBIG_CodigoPROV.DataSource = (object) null;
          if (this.Enabled)
            this.UBIG_CodigoPROV.Enabled = false;
          this.UBIG_CodigoDEPA.SelectedIndex = 0;
        }
      }
      catch (Exception ex)
      {
        int num = (int) Dialogos.MostrarMensajeError(this.Titulo, "Ha ocurrido un error al cargar las Provincias.", ex);
      }
    }

    private void UBIG_CodigoPROV_SelectedIndexChanged(object sender, EventArgs e)
    {
      try
      {
        if (this.TIPO_CodPais.SelectedItem != null && this.TIPO_CodPais.SelectedValue != null && (this.TIPO_CodPais.SelectedValue.ToString() != "000" && this.UBIG_CodigoPROV.SelectedItem != null) && (this.UBIG_CodigoPROV.SelectedValue != null && this.UBIG_CodigoPROV.SelectedValue != (object) "00.00"))
        {
          this.UBIG_CodigoDIST.DataSource = (object) null;
          this.Presenter.LoadComboDistrito(((Tipos) this.TIPO_CodPais.SelectedItem).get_TIPO_CodTipo(), ((Ubigeos) this.UBIG_CodigoPROV.SelectedItem).get_UBIG_Codigo());
          if (!this.Enabled)
            return;
          this.UBIG_CodigoDIST.Enabled = true;
        }
        else
        {
          this.UBIG_CodigoDIST.DataSource = (object) null;
          if (!this.Enabled)
            return;
          this.UBIG_CodigoDIST.Enabled = false;
        }
      }
      catch (Exception ex)
      {
        int num = (int) Dialogos.MostrarMensajeError(this.Titulo, "Ha ocurrido un error al cargar los Distritos.", ex);
      }
    }

    public string Titulo { get; set; }

    public void LoadControl(IUnityContainer x_container)
    {
      try
      {
        this.Presenter = new UbigeoControlPresenter((IUbigeoControl) this, x_container);
        this.Presenter.LoadComboPais();
        this.UBIG_CodigoDEPA.SelectedIndexChanged += new EventHandler(this.UBIG_CodigoDEPA_SelectedIndexChanged);
        this.UBIG_CodigoPROV.SelectedIndexChanged += new EventHandler(this.UBIG_CodigoPROV_SelectedIndexChanged);
        if (!this.Enabled)
          return;
        this.UBIG_CodigoDEPA.Enabled = false;
        this.UBIG_CodigoPROV.Enabled = false;
        this.UBIG_CodigoDIST.Enabled = false;
      }
      catch (Exception ex)
      {
        int num = (int) Dialogos.MostrarMensajeError(this.Titulo, "Ha ocurrido un error al cargar los Combos de Ubigeo.", ex);
      }
    }

    public void LoadComboPaises()
    {
      try
      {
        this.TIPO_CodPais.DataSource = (object) this.Presenter.ListPaises;
        this.TIPO_CodPais.ValueMember = "TIPO_CodTipo";
        this.TIPO_CodPais.DisplayMember = "TIPO_Desc1";
        if (this.Presenter.ListPaises == null || this.Presenter.ListPaises.Count <= 0 || ((IEnumerable<Tipos>) this.Presenter.ListPaises).ElementAt<Tipos>(0).get_TIPO_CodTipo() == null)
          return;
        this.TIPO_CodPais.SelectedValue = (object) ((IEnumerable<Tipos>) this.Presenter.ListPaises).ElementAt<Tipos>(0).get_TIPO_CodTipo();
      }
      catch (Exception ex)
      {
        int num = (int) Dialogos.MostrarMensajeError(this.Titulo, "Ha ocurrido un error al cargar los Países.", ex);
      }
    }

    public void LoadComboDepartamento()
    {
      try
      {
        this.UBIG_CodigoDEPA.DataSource = (object) this.Presenter.ListUbigeoDep;
        this.UBIG_CodigoDEPA.ValueMember = "UBIG_Codigo";
        this.UBIG_CodigoDEPA.DisplayMember = "UBIG_Desc";
        if (this.Presenter.ListUbigeoDep == null || this.Presenter.ListUbigeoDep.Count <= 0 || ((IEnumerable<Ubigeos>) this.Presenter.ListUbigeoDep).ElementAt<Ubigeos>(0).get_UBIG_Codigo() == null)
          return;
        this.UBIG_CodigoDEPA.SelectedValue = (object) ((IEnumerable<Ubigeos>) this.Presenter.ListUbigeoDep).ElementAt<Ubigeos>(0).get_UBIG_Codigo();
      }
      catch (Exception ex)
      {
        int num = (int) Dialogos.MostrarMensajeError(this.Titulo, "Ha ocurrido un error al cargar los Departamentos.", ex);
      }
    }

    public void LoadComboProvincia()
    {
      try
      {
        this.UBIG_CodigoPROV.DataSource = (object) this.Presenter.ListUbigeoProv;
        this.UBIG_CodigoPROV.ValueMember = "UBIG_Codigo";
        this.UBIG_CodigoPROV.DisplayMember = "UBIG_Desc";
        if (this.Presenter.ListUbigeoProv == null || this.Presenter.ListUbigeoProv.Count <= 0)
          return;
        this.UBIG_CodigoPROV.SelectedValue = (object) ((IEnumerable<Ubigeos>) this.Presenter.ListUbigeoProv).ElementAt<Ubigeos>(0).get_UBIG_Codigo();
      }
      catch (Exception ex)
      {
        int num = (int) Dialogos.MostrarMensajeError(this.Titulo, "Ha ocurrido un error al cargar las Provincias.", ex);
      }
    }

    public void LoadComboDistrito()
    {
      try
      {
        this.UBIG_CodigoDIST.DataSource = (object) this.Presenter.ListUbigeoDist;
        this.UBIG_CodigoDIST.ValueMember = "UBIG_Codigo";
        this.UBIG_CodigoDIST.DisplayMember = "UBIG_Desc";
        if (this.Presenter.ListUbigeoDist == null || this.Presenter.ListUbigeoDist.Count <= 0)
          return;
        this.UBIG_CodigoDIST.SelectedValue = (object) ((IEnumerable<Ubigeos>) this.Presenter.ListUbigeoDist).ElementAt<Ubigeos>(0).get_UBIG_Codigo();
      }
      catch (Exception ex)
      {
        int num = (int) Dialogos.MostrarMensajeError(this.Titulo, "Ha ocurrido un error al cargar los Distritos.", ex);
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
      this.tableUbigeo = new TableLayoutPanel();
      this.UBIG_CodigoDIST = new ComboBox();
      this.label2 = new Label();
      this.label1 = new Label();
      this.UBIG_CodigoPROV = new ComboBox();
      this.UBIG_CodigoDEPA = new ComboBox();
      this.lblENTC_Telef1 = new Label();
      this.label3 = new Label();
      this.TIPO_CodPais = new ComboBox();
      this.tableUbigeo.SuspendLayout();
      this.SuspendLayout();
      this.tableUbigeo.AutoSize = true;
      this.tableUbigeo.ColumnCount = 6;
      this.tableUbigeo.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 150f));
      this.tableUbigeo.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 200f));
      this.tableUbigeo.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 15f));
      this.tableUbigeo.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 150f));
      this.tableUbigeo.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 200f));
      this.tableUbigeo.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 15f));
      this.tableUbigeo.Controls.Add((Control) this.UBIG_CodigoDIST, 4, 1);
      this.tableUbigeo.Controls.Add((Control) this.label2, 3, 1);
      this.tableUbigeo.Controls.Add((Control) this.label1, 0, 1);
      this.tableUbigeo.Controls.Add((Control) this.UBIG_CodigoPROV, 1, 1);
      this.tableUbigeo.Controls.Add((Control) this.UBIG_CodigoDEPA, 4, 0);
      this.tableUbigeo.Controls.Add((Control) this.lblENTC_Telef1, 3, 0);
      this.tableUbigeo.Controls.Add((Control) this.label3, 0, 0);
      this.tableUbigeo.Controls.Add((Control) this.TIPO_CodPais, 1, 0);
      this.tableUbigeo.Dock = DockStyle.Fill;
      this.tableUbigeo.Location = new Point(0, 0);
      this.tableUbigeo.Margin = new Padding(0);
      this.tableUbigeo.Name = "tableUbigeo";
      this.tableUbigeo.RowCount = 2;
      this.tableUbigeo.RowStyles.Add(new RowStyle(SizeType.Absolute, 27f));
      this.tableUbigeo.RowStyles.Add(new RowStyle(SizeType.Absolute, 27f));
      this.tableUbigeo.Size = new Size(730, 54);
      this.tableUbigeo.TabIndex = 0;
      this.UBIG_CodigoDIST.DropDownStyle = ComboBoxStyle.DropDownList;
      this.UBIG_CodigoDIST.FormattingEnabled = true;
      this.UBIG_CodigoDIST.Location = new Point(518, 30);
      this.UBIG_CodigoDIST.Name = "UBIG_CodigoDIST";
      this.UBIG_CodigoDIST.Size = new Size(194, 21);
      this.UBIG_CodigoDIST.TabIndex = 7;
      this.label2.AutoSize = true;
      this.label2.Location = new Point(375, 34);
      this.label2.Margin = new Padding(10, 7, 3, 0);
      this.label2.Name = "label2";
      this.label2.Size = new Size(42, 13);
      this.label2.TabIndex = 6;
      this.label2.Text = "Distrito:";
      this.label2.TextAlign = ContentAlignment.TopRight;
      this.label1.AutoSize = true;
      this.label1.Location = new Point(10, 34);
      this.label1.Margin = new Padding(10, 7, 3, 0);
      this.label1.Name = "label1";
      this.label1.Size = new Size(54, 13);
      this.label1.TabIndex = 4;
      this.label1.Text = "Provincia:";
      this.label1.TextAlign = ContentAlignment.TopRight;
      this.UBIG_CodigoPROV.DropDownStyle = ComboBoxStyle.DropDownList;
      this.UBIG_CodigoPROV.FormattingEnabled = true;
      this.UBIG_CodigoPROV.Location = new Point(153, 30);
      this.UBIG_CodigoPROV.Name = "UBIG_CodigoPROV";
      this.UBIG_CodigoPROV.Size = new Size(194, 21);
      this.UBIG_CodigoPROV.TabIndex = 5;
      this.UBIG_CodigoDEPA.DropDownStyle = ComboBoxStyle.DropDownList;
      this.UBIG_CodigoDEPA.FormattingEnabled = true;
      this.UBIG_CodigoDEPA.Location = new Point(518, 3);
      this.UBIG_CodigoDEPA.Name = "UBIG_CodigoDEPA";
      this.UBIG_CodigoDEPA.Size = new Size(194, 21);
      this.UBIG_CodigoDEPA.TabIndex = 3;
      this.lblENTC_Telef1.AutoSize = true;
      this.lblENTC_Telef1.Location = new Point(375, 7);
      this.lblENTC_Telef1.Margin = new Padding(10, 7, 3, 0);
      this.lblENTC_Telef1.Name = "lblENTC_Telef1";
      this.lblENTC_Telef1.Size = new Size(77, 13);
      this.lblENTC_Telef1.TabIndex = 2;
      this.lblENTC_Telef1.Text = "Departamento:";
      this.lblENTC_Telef1.TextAlign = ContentAlignment.TopRight;
      this.label3.AutoSize = true;
      this.label3.Location = new Point(10, 7);
      this.label3.Margin = new Padding(10, 7, 3, 0);
      this.label3.Name = "label3";
      this.label3.Size = new Size(32, 13);
      this.label3.TabIndex = 0;
      this.label3.Text = "País:";
      this.label3.TextAlign = ContentAlignment.TopRight;
      this.TIPO_CodPais.DropDownStyle = ComboBoxStyle.DropDownList;
      this.TIPO_CodPais.FormattingEnabled = true;
      this.TIPO_CodPais.Location = new Point(153, 3);
      this.TIPO_CodPais.Name = "TIPO_CodPais";
      this.TIPO_CodPais.Size = new Size(194, 21);
      this.TIPO_CodPais.TabIndex = 1;
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.BackColor = Color.LightSteelBlue;
      this.Controls.Add((Control) this.tableUbigeo);
      this.Name = nameof (UbigeoPaisControl);
      this.Size = new Size(730, 54);
      this.tableUbigeo.ResumeLayout(false);
      this.tableUbigeo.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();
    }
  }
}
