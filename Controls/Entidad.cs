// Decompiled with JetBrains decompiler
// Type: Delfin.Controls.Entidad
// Assembly: Delfin.Controls, Version=3.0.1.3, Culture=neutral, PublicKeyToken=null
// MVID: A4BA2B33-0E71-44B0-9838-A6C1CD0C2B15
// Assembly location: C:\Temp\Delfin.Controls.dll

using Delfin.Controls.Properties;
using Delfin.Entities;
using Delfin.ServiceContracts;
using Infrastructure.Aspect.Collections;
using Infrastructure.WinFormsControls;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

namespace Delfin.Controls
{
  public class Entidad : TextBox
  {
    public string Title = "Ayuda de Entidad";
    public Button AyudaButton;
    public Button NuevoButton;
    public Button EditarButton;
    private bool m_rellenaCeros;
    private Entidad.TipoTextBoxAyuda m_tipo;
    private int m_longitudAceptada;
    private bool m_activarAyudaAuto;
    private DialogResult m_AyudaDialogResult;
    private Entidad m_value;
    private IContainer components;

    public event EventHandler AyudaValueChanged;

    public Entidad()
    {
      this.InitializeEntidad();
      this.InitializeComponent();
      this.UsarTipoEntidad = true;
    }

    public Entidad(IContainer container)
    {
      container.Add((IComponent) this);
      this.InitializeEntidad();
      this.InitializeComponent();
      this.UsarTipoEntidad = true;
    }

    private void InitializeEntidad()
    {
      this.Size = new Size(100, 21);
      this.m_rellenaCeros = false;
      this.m_tipo = Entidad.TipoTextBoxAyuda.AlfaNumerico;
      this.AyudaButton = new Button();
      this.AyudaButton.Image = (Image) Resources.buscar8x8;
      this.AyudaButton.ImageAlign = ContentAlignment.BottomCenter;
      this.AyudaButton.UseVisualStyleBackColor = true;
      this.AyudaButton.Size = new Size(20, 20);
      this.AyudaButton.Dock = DockStyle.Right;
      this.AyudaButton.Cursor = Cursors.Arrow;
      this.AyudaButton.TabStop = false;
      this.Controls.Add((Control) this.AyudaButton);
      this.AyudaButton.BringToFront();
      this.AyudaButton.Enabled = true;
      this.AyudaButton.GotFocus += new EventHandler(this.AyudaButton_GotFocus);
      this.AyudaButton.Click += new EventHandler(this.AyudaBoton_Click);
      this.KeyUp += new KeyEventHandler(this.TextBoxAyuda_Key);
      this.KeyPress += new KeyPressEventHandler(this.TextBoxAyuda_KeyPress);
    }

    public IUnityContainer ContainerService { get; set; }

    public int LongitudAceptada
    {
      get
      {
        return this.m_longitudAceptada;
      }
      set
      {
        if (this.Text.Length >= value)
          this.Text = this.Text.Substring(0, value);
        this.m_longitudAceptada = value;
      }
    }

    public Entidad.TipoTextBoxAyuda Tipo
    {
      get
      {
        return this.m_tipo;
      }
      set
      {
        this.m_tipo = value;
      }
    }

    public bool RellenaCeros
    {
      get
      {
        return this.m_rellenaCeros;
      }
      set
      {
        this.m_rellenaCeros = value;
      }
    }

    public bool ActivarAyudaAuto
    {
      get
      {
        return this.m_activarAyudaAuto;
      }
      set
      {
        this.m_activarAyudaAuto = value;
      }
    }

    public override string Text
    {
      get
      {
        return base.Text;
      }
      set
      {
        base.Text = value;
      }
    }

    public override int MaxLength
    {
      get
      {
        return base.MaxLength;
      }
      set
      {
        base.MaxLength = value;
      }
    }

    public override Cursor Cursor
    {
      get
      {
        return base.Cursor;
      }
      set
      {
        base.Cursor = value;
      }
    }

    public new object Tag
    {
      get
      {
        return base.Tag;
      }
      set
      {
        base.Tag = value;
      }
    }

    public Entidad.InstanciaAyuda MyInstanciaAyuda { get; set; }

    public Entidad Value
    {
      get
      {
        return this.m_value;
      }
      set
      {
        this.m_value = value;
        if (this.AyudaValueChanged == null)
          return;
        this.AyudaValueChanged((object) this.m_value, EventArgs.Empty);
      }
    }

    public bool EnabledAyudaButton
    {
      get
      {
        return this.AyudaButton.Enabled;
      }
      set
      {
        this.AyudaButton.Enabled = value;
      }
    }

    public TiposEntidad TipoEntidad { get; set; }

    public bool UsarTipoEntidad { get; set; }

    protected override void OnGotFocus(EventArgs e)
    {
      base.OnGotFocus(e);
      if (!this.m_rellenaCeros)
        return;
      base.Text = this.Text.PadLeft(this.MaxLength, '0');
    }

    protected override void OnTextChanged(EventArgs e)
    {
      base.OnTextChanged(e);
    }

    public new bool Focus()
    {
      this.Select();
      return base.Focus();
    }

    private void SetInstance(Entidad.InstanciaAyuda x_instance)
    {
      try
      {
        this.MyInstanciaAyuda = x_instance;
        switch (this.MyInstanciaAyuda)
        {
          case Entidad.InstanciaAyuda.Habilitado:
            this.ReadOnly = false;
            this.Text = "";
            this.BackColor = Color.White;
            this.AyudaButton.Enabled = true;
            this.AyudaButton.Image = (Image) Resources.buscar8x8;
            break;
          case Entidad.InstanciaAyuda.Bloqueado:
            this.ReadOnly = true;
            this.BackColor = Color.LightGray;
            this.AyudaButton.Enabled = true;
            this.AyudaButton.Image = (Image) Resources.clean8x8;
            break;
        }
      }
      catch (Exception ex)
      {
        throw ex;
      }
    }

    public void AyudaValue()
    {
      try
      {
        IDelfinServices idelfinServices = (IDelfinServices) UnityContainerExtensions.Resolve<IDelfinServices>(this.ContainerService, new ResolverOverride[0]);
        DataTable dataTable1 = new DataTable();
        DataTable dataTable2 = IEnumerableExtensions.ToDataTable<Entidad>((IEnumerable<M0>) idelfinServices.GetAllEntidad(new short?(EntidadClear.GetCodigoTipoEntidad(this.TipoEntidad)), this.Text));
        if (dataTable2.Rows.Count == 0)
        {
          int num = (int) Dialogos.MostrarMensajeInformacion(this.Title, "No se encontraron coincidencias.", (Dialogos.Boton) 0);
        }
        else if (dataTable2.Rows.Count == 1)
        {
          int result;
          if (int.TryParse(dataTable2.Rows[0]["ENTC_Codigo"].ToString(), out result))
            this.SetValue(result);
          else
            this.ClearValue();
        }
        else
        {
          List<ColumnaAyuda> columnaAyudaList1 = new List<ColumnaAyuda>();
          List<ColumnaAyuda> columnaAyudaList2 = columnaAyudaList1;
          ColumnaAyuda columnaAyuda1 = new ColumnaAyuda();
          columnaAyuda1.set_Index(0);
          columnaAyuda1.set_ColumnName("ENTC_NomCompleto");
          columnaAyuda1.set_ColumnCaption(EntidadClear.getDescTipoEntidad(EntidadClear.GetCodigoTipoEntidad(this.TipoEntidad)));
          columnaAyuda1.set_Alineacion(DataGridViewContentAlignment.MiddleLeft);
          columnaAyuda1.set_Width(250);
          columnaAyuda1.set_DataType(typeof (string));
          columnaAyuda1.set_Format((string) null);
          ColumnaAyuda columnaAyuda2 = columnaAyuda1;
          columnaAyudaList2.Add(columnaAyuda2);
          List<ColumnaAyuda> columnaAyudaList3 = columnaAyudaList1;
          ColumnaAyuda columnaAyuda3 = new ColumnaAyuda();
          columnaAyuda3.set_Index(1);
          columnaAyuda3.set_ColumnName("ENTC_Codigo");
          columnaAyuda3.set_ColumnCaption("Código");
          columnaAyuda3.set_Alineacion(DataGridViewContentAlignment.MiddleRight);
          columnaAyuda3.set_Width(100);
          columnaAyuda3.set_DataType(typeof (int));
          columnaAyuda3.set_Format((string) null);
          ColumnaAyuda columnaAyuda4 = columnaAyuda3;
          columnaAyudaList3.Add(columnaAyuda4);
          Ayuda ayuda = new Ayuda("Ayuda " + EntidadClear.getDescTipoEntidad(EntidadClear.GetCodigoTipoEntidad(this.TipoEntidad)), dataTable2, false, (IEnumerable<ColumnaAyuda>) columnaAyudaList1, "");
          this.KeyUp -= new KeyEventHandler(this.TextBoxAyuda_Key);
          if (((Form) ayuda).ShowDialog() == DialogResult.OK)
          {
            int result;
            if (int.TryParse(ayuda.get_Respuesta().Rows[0]["ENTC_Codigo"].ToString(), out result))
              this.SetValue(result);
            else
              this.ClearValue();
          }
          else
            this.ClearValue();
          this.KeyUp += new KeyEventHandler(this.TextBoxAyuda_Key);
        }
      }
      catch (Exception ex)
      {
        int num = (int) Dialogos.MostrarMensajeError(this.Title, "Ha ocurrido un error al cargar la ayuda de Agente", ex);
      }
    }

    public void SetValue(int ENTC_Codigo)
    {
      try
      {
        IDelfinServices idelfinServices = (IDelfinServices) UnityContainerExtensions.Resolve<IDelfinServices>(this.ContainerService, new ResolverOverride[0]);
        short? nullable = new short?(EntidadClear.GetCodigoTipoEntidad(this.TipoEntidad));
        Entidad oneEntidad = idelfinServices.GetOneEntidad(ENTC_Codigo, nullable, false);
        if (oneEntidad != null)
        {
          this.Text = oneEntidad.get_ENTC_NomCompleto();
          this.Value = oneEntidad;
          this.m_value = oneEntidad;
          this.SetInstance(Entidad.InstanciaAyuda.Bloqueado);
          this.Select(oneEntidad.get_ENTC_NomCompleto().Length, 1);
        }
        else
          this.ClearValue();
      }
      catch (Exception ex)
      {
      }
    }

    public void ClearValue()
    {
      try
      {
        this.Value = (Entidad) null;
        this.Text = "";
        this.SetInstance(Entidad.InstanciaAyuda.Habilitado);
      }
      catch (Exception ex)
      {
      }
    }

    protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
    {
      if ((msg.Msg == 256 || msg.Msg == 260) && keyData == Keys.Tab)
        this.OnKeyDown(new KeyEventArgs(Keys.Tab));
      return base.ProcessCmdKey(ref msg, keyData);
    }

    protected void ActivarControlAutomatico(object sender, EventArgs e)
    {
      int num = this.m_activarAyudaAuto ? 1 : 0;
    }

    protected void AyudaBoton_Click(object sender, EventArgs e)
    {
      if (!this.EnabledAyudaButton)
        return;
      if (this.MyInstanciaAyuda == Entidad.InstanciaAyuda.Habilitado)
        this.AyudaValue();
      else
        this.ClearValue();
    }

    protected void TextBoxAyuda_Key(object sender, KeyEventArgs e)
    {
      if (e.KeyCode != Keys.F4 || !this.EnabledAyudaButton)
        return;
      if (this.Text.Trim().Length >= this.m_longitudAceptada && this.m_activarAyudaAuto)
        this.AyudaValue();
      else
        this.AyudaValue();
    }

    protected void TextBoxAyuda_KeyPress(object sender, KeyPressEventArgs e)
    {
      if (this.m_tipo != Entidad.TipoTextBoxAyuda.Numerico)
        return;
      NumberFormatInfo numberFormat = CultureInfo.CurrentCulture.NumberFormat;
      string decimalSeparator = numberFormat.NumberDecimalSeparator;
      string numberGroupSeparator = numberFormat.NumberGroupSeparator;
      string negativeSign = numberFormat.NegativeSign;
      string str = e.KeyChar.ToString();
      if (char.IsDigit(e.KeyChar) || str.Equals(decimalSeparator) || (str.Equals(numberGroupSeparator) || str.Equals(negativeSign)) || e.KeyChar == '\b')
        return;
      e.Handled = true;
    }

    private void AyudaButton_GotFocus(object sender, EventArgs e)
    {
      this.Focus();
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
    }

    public enum TipoTextBoxAyuda
    {
      Numerico,
      AlfaNumerico,
    }

    public enum InstanciaAyuda
    {
      Habilitado,
      Bloqueado,
    }
  }
}
