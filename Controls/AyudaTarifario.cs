// Decompiled with JetBrains decompiler
// Type: Delfin.Controls.AyudaTarifario
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
  public class AyudaTarifario : UserControl
  {
    public string Titulo = "Ayuda de Tarifa";
    private Cab_Tarifa m_value;
    private IContainer components;
    private TableLayoutPanel TlPanel;
    private TextBoxAyuda AyudaNroTarifa;
    private TextBoxAyuda AyudaDescTarifa;

    public AyudaTarifario()
    {
      this.InitializeComponent();
      this.AyudaNroTarifa.add_AyudaClick(new EventHandler(this.AyudaNroTarifa_AyudaClick));
      this.AyudaNroTarifa.add_AyudaClean(new EventHandler(this.AyudaNroTarifa_AyudaClean));
      this.AyudaDescTarifa.add_AyudaClick(new EventHandler(this.AyudaDescTarifa_AyudaClick));
      this.AyudaDescTarifa.add_AyudaClean(new EventHandler(this.AyudaDescTarifa_AyudaClean));
    }

    public IUnityContainer ContainerService { get; set; }

    public event EventHandler AyudaValueChanged;

    public Cab_Tarifa Value
    {
      get
      {
        return this.m_value;
      }
      set
      {
        this.m_value = value;
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

    public TiposTarifas TipoTarifa { get; set; }

    public int CTAR_Codigo { get; set; }

    private string DescripcionTarifario(TiposTarifas x_Tipo)
    {
      string str = (string) null;
      switch (x_Tipo)
      {
        case TiposTarifas.TIPE_Logistico:
          str = "Servicio Logístico";
          break;
        case TiposTarifas.TIPE_Aduanero:
          str = "Servicio Aduanero";
          break;
        case TiposTarifas.TIPE_Transportista:
          str = "Servicio Transportista";
          break;
      }
      return str;
    }

    private string Tarifario(TiposTarifas x_Tipo)
    {
      string str = (string) null;
      switch (x_Tipo)
      {
        case TiposTarifas.TIPE_Logistico:
          str = "L";
          break;
        case TiposTarifas.TIPE_Aduanero:
          str = "A";
          break;
        case TiposTarifas.TIPE_Transportista:
          str = "T";
          break;
      }
      return str;
    }

    public void ClearValue()
    {
      try
      {
        this.AyudaNroTarifa.ClearValue();
        this.AyudaDescTarifa.ClearValue();
        this.m_value = (Cab_Tarifa) null;
        if (this.AyudaValueChanged == null)
          return;
        this.AyudaValueChanged((object) null, EventArgs.Empty);
      }
      catch (Exception ex)
      {
      }
    }

    public void LoadAyuda(string x_NroTarifa, string x_DescripTarifa, string x_CTAR_Tipo)
    {
      try
      {
        IDelfinServices idelfinServices = (IDelfinServices) UnityContainerExtensions.Resolve<IDelfinServices>(this.ContainerService, new ResolverOverride[0]);
        DataTable dataTable = new DataTable();
        DataTable allAyudaTarifa = idelfinServices.GetAllAyudaTarifa(x_NroTarifa, x_DescripTarifa, x_CTAR_Tipo, this.CTAR_Codigo);
        if (allAyudaTarifa == null || allAyudaTarifa.Rows.Count == 0)
        {
          int num = (int) Dialogos.MostrarMensajeInformacion(this.Titulo, "No se encontraron coincidencias.", (Dialogos.Boton) 0);
        }
        else if (allAyudaTarifa.Rows.Count == 1)
        {
          this.AyudaNroTarifa.SetValue((object) allAyudaTarifa, allAyudaTarifa.Rows[0]["CTAR_Numero"].ToString());
          this.AyudaDescTarifa.SetValue((object) allAyudaTarifa, allAyudaTarifa.Rows[0]["CTAR_Descrip"].ToString());
          this.m_value = new Cab_Tarifa();
          this.m_value.set_CTAR_Codigo(int.Parse(allAyudaTarifa.Rows[0]["CTAR_Codigo"].ToString()));
          this.m_value.set_CTAR_Tipo(allAyudaTarifa.Rows[0]["CTAR_Tipo"].ToString());
          this.m_value.set_CTAR_Descrip(allAyudaTarifa.Rows[0]["CTAR_Descrip"].ToString());
          this.m_value.set_CTAR_Numero(allAyudaTarifa.Rows[0]["CTAR_Numero"].ToString());
          this.m_value.set_CTAR_FecIni(DateTime.Parse(allAyudaTarifa.Rows[0]["CTAR_FecIni"].ToString()));
          this.m_value.set_CTAR_FecFin(DateTime.Parse(allAyudaTarifa.Rows[0]["CTAR_FecFin"].ToString()));
          if (this.AyudaValueChanged == null)
            return;
          this.AyudaValueChanged((object) null, EventArgs.Empty);
        }
        else
        {
          List<ColumnaAyuda> columnaAyudaList1 = new List<ColumnaAyuda>();
          if (!string.IsNullOrEmpty(x_NroTarifa))
          {
            List<ColumnaAyuda> columnaAyudaList2 = columnaAyudaList1;
            ColumnaAyuda columnaAyuda1 = new ColumnaAyuda();
            columnaAyuda1.set_Index(0);
            columnaAyuda1.set_ColumnName("CTAR_Numero");
            columnaAyuda1.set_ColumnCaption("Nro. Tarifa");
            columnaAyuda1.set_Alineacion(DataGridViewContentAlignment.MiddleLeft);
            columnaAyuda1.set_Width(100);
            columnaAyuda1.set_DataType(typeof (string));
            columnaAyuda1.set_Format((string) null);
            ColumnaAyuda columnaAyuda2 = columnaAyuda1;
            columnaAyudaList2.Add(columnaAyuda2);
            List<ColumnaAyuda> columnaAyudaList3 = columnaAyudaList1;
            ColumnaAyuda columnaAyuda3 = new ColumnaAyuda();
            columnaAyuda3.set_Index(1);
            columnaAyuda3.set_ColumnName("CTAR_Descrip");
            columnaAyuda3.set_ColumnCaption(this.DescripcionTarifario(this.TipoTarifa));
            columnaAyuda3.set_Alineacion(DataGridViewContentAlignment.MiddleLeft);
            columnaAyuda3.set_Width(250);
            columnaAyuda3.set_DataType(typeof (string));
            columnaAyuda3.set_Format((string) null);
            ColumnaAyuda columnaAyuda4 = columnaAyuda3;
            columnaAyudaList3.Add(columnaAyuda4);
          }
          else
          {
            List<ColumnaAyuda> columnaAyudaList2 = columnaAyudaList1;
            ColumnaAyuda columnaAyuda1 = new ColumnaAyuda();
            columnaAyuda1.set_Index(0);
            columnaAyuda1.set_ColumnName("CTAR_Descrip");
            columnaAyuda1.set_ColumnCaption(this.DescripcionTarifario(this.TipoTarifa));
            columnaAyuda1.set_Alineacion(DataGridViewContentAlignment.MiddleLeft);
            columnaAyuda1.set_Width(250);
            columnaAyuda1.set_DataType(typeof (string));
            columnaAyuda1.set_Format((string) null);
            ColumnaAyuda columnaAyuda2 = columnaAyuda1;
            columnaAyudaList2.Add(columnaAyuda2);
            List<ColumnaAyuda> columnaAyudaList3 = columnaAyudaList1;
            ColumnaAyuda columnaAyuda3 = new ColumnaAyuda();
            columnaAyuda3.set_Index(1);
            columnaAyuda3.set_ColumnName("CTAR_Numero");
            columnaAyuda3.set_ColumnCaption("Nro. Tarifa");
            columnaAyuda3.set_Alineacion(DataGridViewContentAlignment.MiddleLeft);
            columnaAyuda3.set_Width(100);
            columnaAyuda3.set_DataType(typeof (string));
            columnaAyuda3.set_Format((string) null);
            ColumnaAyuda columnaAyuda4 = columnaAyuda3;
            columnaAyudaList3.Add(columnaAyuda4);
          }
          List<ColumnaAyuda> columnaAyudaList4 = columnaAyudaList1;
          ColumnaAyuda columnaAyuda5 = new ColumnaAyuda();
          columnaAyuda5.set_Index(2);
          columnaAyuda5.set_ColumnName("CTAR_FecIni");
          columnaAyuda5.set_ColumnCaption("Fecha Inicio");
          columnaAyuda5.set_Alineacion(DataGridViewContentAlignment.MiddleLeft);
          columnaAyuda5.set_Width(90);
          columnaAyuda5.set_DataType(typeof (DateTime));
          columnaAyuda5.set_Format("dd/MM/yyyy");
          ColumnaAyuda columnaAyuda6 = columnaAyuda5;
          columnaAyudaList4.Add(columnaAyuda6);
          List<ColumnaAyuda> columnaAyudaList5 = columnaAyudaList1;
          ColumnaAyuda columnaAyuda7 = new ColumnaAyuda();
          columnaAyuda7.set_Index(3);
          columnaAyuda7.set_ColumnName("CTAR_FecFin");
          columnaAyuda7.set_ColumnCaption("Fecha Fin");
          columnaAyuda7.set_Alineacion(DataGridViewContentAlignment.MiddleLeft);
          columnaAyuda7.set_Width(90);
          columnaAyuda7.set_DataType(typeof (DateTime));
          columnaAyuda7.set_Format("dd/MM/yyyy");
          ColumnaAyuda columnaAyuda8 = columnaAyuda7;
          columnaAyudaList5.Add(columnaAyuda8);
          List<ColumnaAyuda> columnaAyudaList6 = columnaAyudaList1;
          ColumnaAyuda columnaAyuda9 = new ColumnaAyuda();
          columnaAyuda9.set_Index(4);
          columnaAyuda9.set_ColumnName("CTAR_Codigo");
          columnaAyuda9.set_ColumnCaption("Código");
          columnaAyuda9.set_Alineacion(DataGridViewContentAlignment.MiddleLeft);
          columnaAyuda9.set_Width(50);
          columnaAyuda9.set_DataType(typeof (int));
          columnaAyuda9.set_Format((string) null);
          ColumnaAyuda columnaAyuda10 = columnaAyuda9;
          columnaAyudaList6.Add(columnaAyuda10);
          List<ColumnaAyuda> columnaAyudaList7 = columnaAyudaList1;
          ColumnaAyuda columnaAyuda11 = new ColumnaAyuda();
          columnaAyuda11.set_Index(5);
          columnaAyuda11.set_ColumnName("CTAR_Tipo");
          columnaAyuda11.set_ColumnCaption("Tipo Tarifa");
          columnaAyuda11.set_Alineacion(DataGridViewContentAlignment.MiddleLeft);
          columnaAyuda11.set_Width(65);
          columnaAyuda11.set_DataType(typeof (string));
          columnaAyuda11.set_Format((string) null);
          ColumnaAyuda columnaAyuda12 = columnaAyuda11;
          columnaAyudaList7.Add(columnaAyuda12);
          Ayuda ayuda = new Ayuda(this.Titulo, allAyudaTarifa, false, (IEnumerable<ColumnaAyuda>) columnaAyudaList1, x_NroTarifa != null ? x_NroTarifa : x_DescripTarifa);
          if (((Form) ayuda).ShowDialog() == DialogResult.OK)
          {
            this.AyudaNroTarifa.SetValue((object) ayuda.get_Respuesta(), ayuda.get_Respuesta().Rows[0]["CTAR_Numero"].ToString());
            this.AyudaDescTarifa.SetValue((object) ayuda.get_Respuesta(), ayuda.get_Respuesta().Rows[0]["CTAR_Descrip"].ToString());
            this.m_value = new Cab_Tarifa();
            this.m_value.set_CTAR_Codigo(int.Parse(ayuda.get_Respuesta().Rows[0]["CTAR_Codigo"].ToString()));
            this.m_value.set_CTAR_Tipo(ayuda.get_Respuesta().Rows[0]["CTAR_Tipo"].ToString());
            this.m_value.set_CTAR_Descrip(ayuda.get_Respuesta().Rows[0]["CTAR_Descrip"].ToString());
            this.m_value.set_CTAR_Numero(ayuda.get_Respuesta().Rows[0]["CTAR_Numero"].ToString());
            this.m_value.set_CTAR_FecIni(DateTime.Parse(ayuda.get_Respuesta().Rows[0]["CTAR_FecIni"].ToString()));
            this.m_value.set_CTAR_FecFin(DateTime.Parse(ayuda.get_Respuesta().Rows[0]["CTAR_FecFin"].ToString()));
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

    public void SetValue(int x_CTAR_Codigo, string x_CTAR_Tipo, bool x_AyudaChanged = true)
    {
      try
      {
        Cab_Tarifa oneCabTarifa = ((IDelfinServices) UnityContainerExtensions.Resolve<IDelfinServices>(this.ContainerService, new ResolverOverride[0])).GetOneCab_Tarifa(x_CTAR_Tipo, x_CTAR_Codigo);
        if (oneCabTarifa != null)
        {
          this.m_value = new Cab_Tarifa();
          this.Value = oneCabTarifa;
          this.m_value = oneCabTarifa;
          this.AyudaNroTarifa.SetValue((object) oneCabTarifa, oneCabTarifa.get_CTAR_Numero());
          this.AyudaDescTarifa.SetValue((object) oneCabTarifa, oneCabTarifa.get_CTAR_Descrip());
          if (!x_AyudaChanged || this.AyudaValueChanged == null)
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

    private void AyudaDescTarifa_AyudaClean(object sender, EventArgs e)
    {
      this.ClearValue();
    }

    private void AyudaDescTarifa_AyudaClick(object sender, EventArgs e)
    {
      this.LoadAyuda((string) null, ((Control) this.AyudaDescTarifa).Text, this.Tarifario(this.TipoTarifa));
    }

    private void AyudaNroTarifa_AyudaClean(object sender, EventArgs e)
    {
      this.ClearValue();
    }

    private void AyudaNroTarifa_AyudaClick(object sender, EventArgs e)
    {
      this.LoadAyuda(((Control) this.AyudaNroTarifa).Text, (string) null, this.Tarifario(this.TipoTarifa));
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
      this.AyudaNroTarifa = new TextBoxAyuda();
      this.AyudaDescTarifa = new TextBoxAyuda();
      this.TlPanel.SuspendLayout();
      this.SuspendLayout();
      this.TlPanel.AutoSize = true;
      this.TlPanel.BackColor = Color.LightSteelBlue;
      this.TlPanel.ColumnCount = 3;
      this.TlPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 134f));
      this.TlPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 17f));
      this.TlPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 271f));
      this.TlPanel.Controls.Add((Control) this.AyudaNroTarifa, 0, 0);
      this.TlPanel.Controls.Add((Control) this.AyudaDescTarifa, 1, 0);
      this.TlPanel.Dock = DockStyle.Fill;
      this.TlPanel.GrowStyle = TableLayoutPanelGrowStyle.FixedSize;
      this.TlPanel.Location = new Point(0, 0);
      this.TlPanel.Name = "TlPanel";
      this.TlPanel.RowCount = 1;
      this.TlPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 27f));
      this.TlPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 27f));
      this.TlPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 27f));
      this.TlPanel.Size = new Size(422, 26);
      this.TlPanel.TabIndex = 6;
      this.AyudaNroTarifa.set_ActivarAyudaAuto(false);
      ((Control) this.AyudaNroTarifa).Dock = DockStyle.Fill;
      this.AyudaNroTarifa.set_EnabledAyudaButton(true);
      ((Control) this.AyudaNroTarifa).Location = new Point(3, 3);
      this.AyudaNroTarifa.set_LongitudAceptada(0);
      this.AyudaNroTarifa.set_MyInstanciaAyuda((TextBoxAyuda.InstanciaAyuda) 0);
      ((Control) this.AyudaNroTarifa).Name = "AyudaNroTarifa";
      this.AyudaNroTarifa.set_RellenaCeros(false);
      ((Control) this.AyudaNroTarifa).Size = new Size(128, 20);
      ((Control) this.AyudaNroTarifa).TabIndex = 18;
      this.AyudaNroTarifa.set_Tipo((TextBoxAyuda.TipoTextBoxAyuda) 1);
      this.AyudaNroTarifa.set_Value((object) null);
      this.AyudaDescTarifa.set_ActivarAyudaAuto(false);
      this.TlPanel.SetColumnSpan((Control) this.AyudaDescTarifa, 2);
      ((Control) this.AyudaDescTarifa).Dock = DockStyle.Fill;
      this.AyudaDescTarifa.set_EnabledAyudaButton(true);
      ((Control) this.AyudaDescTarifa).Location = new Point(137, 3);
      this.AyudaDescTarifa.set_LongitudAceptada(0);
      this.AyudaDescTarifa.set_MyInstanciaAyuda((TextBoxAyuda.InstanciaAyuda) 0);
      ((Control) this.AyudaDescTarifa).Name = "AyudaDescTarifa";
      this.AyudaDescTarifa.set_RellenaCeros(false);
      ((Control) this.AyudaDescTarifa).Size = new Size(282, 20);
      ((Control) this.AyudaDescTarifa).TabIndex = 19;
      this.AyudaDescTarifa.set_Tipo((TextBoxAyuda.TipoTextBoxAyuda) 1);
      this.AyudaDescTarifa.set_Value((object) null);
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.BackColor = Color.LightSteelBlue;
      this.Controls.Add((Control) this.TlPanel);
      this.Cursor = Cursors.Arrow;
      this.Name = nameof (AyudaTarifario);
      this.Size = new Size(422, 26);
      this.TlPanel.ResumeLayout(false);
      this.TlPanel.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();
    }
  }
}
