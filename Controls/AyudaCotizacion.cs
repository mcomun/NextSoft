// Decompiled with JetBrains decompiler
// Type: Delfin.Controls.AyudaCotizacion
// Assembly: Delfin.Controls, Version=3.0.1.3, Culture=neutral, PublicKeyToken=null
// MVID: A4BA2B33-0E71-44B0-9838-A6C1CD0C2B15
// Assembly location: C:\Temp\Delfin.Controls.dll

using Delfin.Entities;
using Delfin.ServiceContracts;
using Infrastructure.WinFormsControls;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace Delfin.Controls
{
  public class AyudaCotizacion : UserControl
  {
    public string Titulo = "Ayuda de Cotización";
    private Cab_Cotizacion m_value;
    private Cab_Cotizacion m_valor;
    private int? m_ENTC_CodigoCliente;
    private int? m_ENTC_CodigoLNaviera;
    private int m_ccot_codigo;
    private IContainer components;
    private TableLayoutPanel TlPanel;
    private TextBoxAyuda AyudaNroCotizacion;

    public AyudaCotizacion()
    {
      this.InitializeComponent();
      this.AyudaNroCotizacion.add_AyudaClick(new EventHandler(this.AyudaNroCotizacion_AyudaClick));
      this.AyudaNroCotizacion.add_AyudaClean(new EventHandler(this.AyudaNroCotizacion_AyudaClean));
    }

    public IUnityContainer ContainerService { get; set; }

    public event EventHandler AyudaValueChanged;

    public Cab_Cotizacion Value
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

    public event EventHandler AyudaGetValores;

    public Cab_Cotizacion Valor
    {
      get
      {
        return this.m_value;
      }
      set
      {
        this.m_value = value;
        if (this.AyudaGetValores == null)
          return;
        this.AyudaGetValores((object) this.m_value, EventArgs.Empty);
      }
    }

    public int? ENTC_CodigoLNaviera
    {
      get
      {
        return this.m_ENTC_CodigoLNaviera;
      }
      set
      {
        this.m_ENTC_CodigoLNaviera = value;
      }
    }

    public int? ENTC_CodigoCliente
    {
      get
      {
        return this.m_ENTC_CodigoCliente;
      }
      set
      {
        this.m_ENTC_CodigoCliente = value;
      }
    }

    public int CCOT_Codigo
    {
      get
      {
        return this.m_ccot_codigo;
      }
      set
      {
        this.m_ccot_codigo = value;
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

    public TiposCotizacion TipoCotizacion { get; set; }

    private string DescripcionCotizacion(TiposCotizacion x_Tipo)
    {
      string str = (string) null;
      switch (x_Tipo)
      {
        case TiposCotizacion.TIPE_Logistico:
          str = "Servicio Logístico";
          break;
        case TiposCotizacion.TIPE_Aduanero:
          str = "Servicio Aduanero";
          break;
        case TiposCotizacion.TIPE_Transportista:
          str = "Servicio Transportista";
          break;
      }
      return str;
    }

    private string Cotizacion(TiposCotizacion x_Tipo)
    {
      string str = (string) null;
      switch (x_Tipo)
      {
        case TiposCotizacion.TIPE_Logistico:
          str = "L";
          break;
        case TiposCotizacion.TIPE_Aduanero:
          str = "A";
          break;
        case TiposCotizacion.TIPE_Transportista:
          str = "T";
          break;
      }
      return str;
    }

    public void ClearValue()
    {
      try
      {
        this.AyudaNroCotizacion.ClearValue();
        this.m_value = (Cab_Cotizacion) null;
        if (this.AyudaValueChanged == null)
          return;
        this.AyudaValueChanged((object) null, EventArgs.Empty);
      }
      catch (Exception ex)
      {
      }
    }

    private void LoadAyuda(int? ENTC_CodigoCliente, int? ENTC_CodigoLNaviera, string x_NroCotizacion, string x_CTAR_Tipo, int x_CTAR_Codigo)
    {
      try
      {
        IDelfinServices idelfinServices = (IDelfinServices) UnityContainerExtensions.Resolve<IDelfinServices>(this.ContainerService, new ResolverOverride[0]);
        DataTable dataTable = new DataTable();
        DataTable allAyudaCotizacion = idelfinServices.GetAllAyudaCotizacion(ENTC_CodigoCliente, ENTC_CodigoLNaviera, x_NroCotizacion, x_CTAR_Tipo, x_CTAR_Codigo);
        if (allAyudaCotizacion == null || allAyudaCotizacion.Rows.Count == 0)
        {
          int num = (int) Dialogos.MostrarMensajeInformacion(this.Titulo, "No se encontraron coincidencias.", (Dialogos.Boton) 0);
        }
        else if (allAyudaCotizacion.Rows.Count == 1)
        {
          this.AyudaNroCotizacion.SetValue((object) allAyudaCotizacion, allAyudaCotizacion.Rows[0]["CCOT_NumDoc"].ToString());
          this.m_value = new Cab_Cotizacion();
          this.m_value.set_CCOT_Codigo(int.Parse(allAyudaCotizacion.Rows[0]["CCOT_Codigo"].ToString()));
          this.m_value.set_CCOT_NumDoc(allAyudaCotizacion.Rows[0]["CCOT_NumDoc"].ToString());
          this.m_value.set_CCOT_FecEmi(new DateTime?(DateTime.Parse(allAyudaCotizacion.Rows[0]["CCOT_FecEmi"].ToString())));
          this.m_value.set_CCOT_FecVcto(new DateTime?(DateTime.Parse(allAyudaCotizacion.Rows[0]["CCOT_FecVcto"].ToString())));
          this.m_value.set_ENTC_Codigo(new int?(Convert.ToInt32(allAyudaCotizacion.Rows[0]["ENTC_Codigo"].ToString())));
          this.m_value.set_TIPO_CodMND(allAyudaCotizacion.Rows[0]["TIPO_CodMND"].ToString());
          if (this.AyudaValueChanged == null)
            return;
          this.AyudaValueChanged((object) null, EventArgs.Empty);
        }
        else
        {
          List<ColumnaAyuda> columnaAyudaList1 = new List<ColumnaAyuda>();
          List<ColumnaAyuda> columnaAyudaList2 = columnaAyudaList1;
          ColumnaAyuda columnaAyuda1 = new ColumnaAyuda();
          columnaAyuda1.set_Index(0);
          columnaAyuda1.set_ColumnName("CCOT_NumDoc");
          columnaAyuda1.set_ColumnCaption("Nro. Cotización");
          columnaAyuda1.set_Alineacion(DataGridViewContentAlignment.MiddleLeft);
          columnaAyuda1.set_Width(120);
          columnaAyuda1.set_DataType(typeof (string));
          columnaAyuda1.set_Format((string) null);
          ColumnaAyuda columnaAyuda2 = columnaAyuda1;
          columnaAyudaList2.Add(columnaAyuda2);
          List<ColumnaAyuda> columnaAyudaList3 = columnaAyudaList1;
          ColumnaAyuda columnaAyuda3 = new ColumnaAyuda();
          columnaAyuda3.set_Index(1);
          columnaAyuda3.set_ColumnName("Transporte");
          columnaAyuda3.set_ColumnCaption("Transportista");
          columnaAyuda3.set_Alineacion(DataGridViewContentAlignment.MiddleLeft);
          columnaAyuda3.set_Width(120);
          columnaAyuda3.set_DataType(typeof (string));
          columnaAyuda3.set_Format((string) null);
          ColumnaAyuda columnaAyuda4 = columnaAyuda3;
          columnaAyudaList3.Add(columnaAyuda4);
          List<ColumnaAyuda> columnaAyudaList4 = columnaAyudaList1;
          ColumnaAyuda columnaAyuda5 = new ColumnaAyuda();
          columnaAyuda5.set_Index(2);
          columnaAyuda5.set_ColumnName("DepTemp");
          columnaAyuda5.set_ColumnCaption("Deposito Temporal");
          columnaAyuda5.set_Alineacion(DataGridViewContentAlignment.MiddleLeft);
          columnaAyuda5.set_Width(120);
          columnaAyuda5.set_DataType(typeof (string));
          columnaAyuda5.set_Format((string) null);
          ColumnaAyuda columnaAyuda6 = columnaAyuda5;
          columnaAyudaList4.Add(columnaAyuda6);
          List<ColumnaAyuda> columnaAyudaList5 = columnaAyudaList1;
          ColumnaAyuda columnaAyuda7 = new ColumnaAyuda();
          columnaAyuda7.set_Index(3);
          columnaAyuda7.set_ColumnName("CCOT_FecEmi");
          columnaAyuda7.set_ColumnCaption("Fecha Emisión");
          columnaAyuda7.set_Alineacion(DataGridViewContentAlignment.MiddleLeft);
          columnaAyuda7.set_Width(100);
          columnaAyuda7.set_DataType(typeof (DateTime));
          columnaAyuda7.set_Format("dd/MM/yyyy");
          ColumnaAyuda columnaAyuda8 = columnaAyuda7;
          columnaAyudaList5.Add(columnaAyuda8);
          List<ColumnaAyuda> columnaAyudaList6 = columnaAyudaList1;
          ColumnaAyuda columnaAyuda9 = new ColumnaAyuda();
          columnaAyuda9.set_Index(4);
          columnaAyuda9.set_ColumnName("CCOT_FecVcto");
          columnaAyuda9.set_ColumnCaption("Fecha Vcto.");
          columnaAyuda9.set_Alineacion(DataGridViewContentAlignment.MiddleLeft);
          columnaAyuda9.set_Width(100);
          columnaAyuda9.set_DataType(typeof (DateTime));
          columnaAyuda9.set_Format("dd/MM/yyyy");
          ColumnaAyuda columnaAyuda10 = columnaAyuda9;
          columnaAyudaList6.Add(columnaAyuda10);
          List<ColumnaAyuda> columnaAyudaList7 = columnaAyudaList1;
          ColumnaAyuda columnaAyuda11 = new ColumnaAyuda();
          columnaAyuda11.set_Index(5);
          columnaAyuda11.set_ColumnName("CCOT_Observaciones");
          columnaAyuda11.set_ColumnCaption("Observaciones");
          columnaAyuda11.set_Alineacion(DataGridViewContentAlignment.MiddleLeft);
          columnaAyuda11.set_Width(250);
          columnaAyuda11.set_DataType(typeof (string));
          columnaAyuda11.set_Format((string) null);
          ColumnaAyuda columnaAyuda12 = columnaAyuda11;
          columnaAyudaList7.Add(columnaAyuda12);
          Ayuda ayuda = new Ayuda(this.Titulo, allAyudaCotizacion, false, (IEnumerable<ColumnaAyuda>) columnaAyudaList1, x_NroCotizacion);
          if (((Form) ayuda).ShowDialog() == DialogResult.OK)
          {
            this.AyudaNroCotizacion.SetValue((object) ayuda.get_Respuesta(), ayuda.get_Respuesta().Rows[0]["CCOT_NumDoc"].ToString());
            this.m_value = new Cab_Cotizacion();
            this.m_value.set_CCOT_Codigo(int.Parse(ayuda.get_Respuesta().Rows[0]["CCOT_Codigo"].ToString()));
            this.m_value.set_CCOT_NumDoc(ayuda.get_Respuesta().Rows[0]["CCOT_NumDoc"].ToString());
            this.m_value.set_CCOT_FecEmi(new DateTime?(DateTime.Parse(ayuda.get_Respuesta().Rows[0]["CCOT_FecEmi"].ToString())));
            this.m_value.set_CCOT_FecVcto(new DateTime?(DateTime.Parse(ayuda.get_Respuesta().Rows[0]["CCOT_FecVcto"].ToString())));
            this.m_value.set_ENTC_Codigo(new int?(Convert.ToInt32(ayuda.get_Respuesta().Rows[0]["ENTC_Codigo"].ToString())));
            this.m_value.set_TIPO_CodMND(ayuda.get_Respuesta().Rows[0]["TIPO_CodMND"].ToString());
            if (this.AyudaValueChanged == null)
              return;
            this.AyudaValueChanged((object) null, EventArgs.Empty);
          }
          else
            this.ClearValue();
        }
      }
      catch (Exception ex)
      {
        int num = (int) Dialogos.MostrarMensajeError(this.Titulo, "ha ocurrido un error en la Ayuda de Tarifario", ex);
      }
    }

    public void SetValue(int x_CCOT_Codigo)
    {
      try
      {
        Cab_Cotizacion oneCabCotizacion = ((IDelfinServices) UnityContainerExtensions.Resolve<IDelfinServices>(this.ContainerService, new ResolverOverride[0])).GetOneCab_Cotizacion(x_CCOT_Codigo);
        if (oneCabCotizacion != null)
        {
          this.m_value = new Cab_Cotizacion();
          this.Value = oneCabCotizacion;
          this.m_value = oneCabCotizacion;
          this.AyudaNroCotizacion.SetValue((object) oneCabCotizacion, oneCabCotizacion.get_CCOT_NumDoc());
          if (this.AyudaValueChanged == null)
            return;
          this.AyudaValueChanged((object) null, EventArgs.Empty);
        }
        else
          this.ClearValue();
      }
      catch (Exception ex)
      {
      }
    }

    private void AyudaNroCotizacion_AyudaClean(object sender, EventArgs e)
    {
      this.ClearValue();
    }

    private void AyudaNroCotizacion_AyudaClick(object sender, EventArgs e)
    {
      if (this.AyudaGetValores != null)
        this.AyudaGetValores((object) null, EventArgs.Empty);
      this.LoadAyuda(this.ENTC_CodigoCliente, this.ENTC_CodigoLNaviera, ((Control) this.AyudaNroCotizacion).Text, this.Cotizacion(this.TipoCotizacion), this.CCOT_Codigo);
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      this.TlPanel = new TableLayoutPanel();
      this.AyudaNroCotizacion = new TextBoxAyuda();
      this.TlPanel.SuspendLayout();
      this.SuspendLayout();
      this.TlPanel.AutoSize = true;
      this.TlPanel.BackColor = Color.LightSteelBlue;
      this.TlPanel.ColumnCount = 1;
      this.TlPanel.ColumnStyles.Add(new ColumnStyle());
      this.TlPanel.Controls.Add((Control) this.AyudaNroCotizacion, 0, 0);
      this.TlPanel.Dock = DockStyle.Fill;
      this.TlPanel.GrowStyle = TableLayoutPanelGrowStyle.FixedSize;
      this.TlPanel.Location = new Point(0, 0);
      this.TlPanel.Name = "TlPanel";
      this.TlPanel.RowCount = 1;
      this.TlPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 27f));
      this.TlPanel.Size = new Size(116, 26);
      this.TlPanel.TabIndex = 6;
      this.AyudaNroCotizacion.set_ActivarAyudaAuto(false);
      ((Control) this.AyudaNroCotizacion).Dock = DockStyle.Fill;
      this.AyudaNroCotizacion.set_EnabledAyudaButton(true);
      ((Control) this.AyudaNroCotizacion).Location = new Point(3, 3);
      this.AyudaNroCotizacion.set_LongitudAceptada(0);
      this.AyudaNroCotizacion.set_MyInstanciaAyuda((TextBoxAyuda.InstanciaAyuda) 0);
      ((Control) this.AyudaNroCotizacion).Name = "AyudaNroCotizacion";
      this.AyudaNroCotizacion.set_RellenaCeros(false);
      ((Control) this.AyudaNroCotizacion).Size = new Size(110, 20);
      ((Control) this.AyudaNroCotizacion).TabIndex = 18;
      this.AyudaNroCotizacion.set_Tipo((TextBoxAyuda.TipoTextBoxAyuda) 1);
      this.AyudaNroCotizacion.set_Value((object) null);
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.BackColor = Color.LightSteelBlue;
      this.Controls.Add((Control) this.TlPanel);
      this.Cursor = Cursors.Arrow;
      this.Name = nameof (AyudaCotizacion);
      this.Size = new Size(116, 26);
      this.TlPanel.ResumeLayout(false);
      this.TlPanel.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();
    }
  }
}
