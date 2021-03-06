﻿// Decompiled with JetBrains decompiler
// Type: Delfin.Controls.AyudaFactura
// Assembly: Delfin.Controls, Version=3.0.1.3, Culture=neutral, PublicKeyToken=null
// MVID: A4BA2B33-0E71-44B0-9838-A6C1CD0C2B15
// Assembly location: C:\Temp\Delfin.Controls.dll

using Delfin.Entities;
using Delfin.ServiceContracts;
using Infrastructure.Aspect.DataAccess;
using Infrastructure.WinForms.Controls;
using Infrastructure.WinFormsControls;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace Delfin.Controls
{
  public class AyudaFactura : UserControl
  {
    public string Title = "Ayuda de Factura";
    private int m_fact_codigo;
    private DocsVta m_value;
    private IContainer components;
    private TableLayoutPanel TlPanel;
    private TextBoxAyuda AyudaNroFactura;

    public AyudaFactura()
    {
      this.InitializeComponent();
      this.AyudaNroFactura.add_AyudaClick(new EventHandler(this.AyudaNroFactura_AyudaClick));
      this.AyudaNroFactura.add_AyudaClean(new EventHandler(this.AyudaNroFactura_AyudaClean));
    }

    public void LoadControl(IUnityContainer Container, string x_title, AyudaFactura.TipoAyuda x_opcion)
    {
      try
      {
        this.Client = (IDelfinServices) UnityContainerExtensions.Resolve<IDelfinServices>(Container, new ResolverOverride[0]);
        this.TAyuda = x_opcion;
        this.Title = x_title;
      }
      catch (Exception ex)
      {
      }
    }

    public int m_idCliente { get; set; }

    public IUnityContainer ContainerService { get; set; }

    private IDelfinServices Client { get; set; }

    public event EventHandler AyudaValueChanged;

    public DocsVta SelectedItem
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

    public TiposFactura TipoFactura { get; set; }

    public AyudaFactura.TipoAyuda TAyuda { get; set; }

    public bool AyudaPorOV { get; set; }

    public string CCOT_TipoNumero { get; set; }

    private string DescripcionFactura(TiposFactura x_Tipo)
    {
      string str = (string) null;
      if (x_Tipo == TiposFactura.TIPE_Factura)
        str = "Factura";
      return str;
    }

    private string Factura(TiposFactura x_Tipo)
    {
      string str = (string) null;
      if (x_Tipo == TiposFactura.TIPE_Factura)
        str = "F";
      return str;
    }

    public void ClearValue()
    {
      try
      {
        this.AyudaNroFactura.ClearValue();
        this.m_value = (DocsVta) null;
        if (this.AyudaValueChanged == null)
          return;
        this.AyudaValueChanged((object) null, EventArgs.Empty);
      }
      catch (Exception ex)
      {
      }
    }

    private void LoadAyuda()
    {
      try
      {
        int mIdCliente1 = this.m_idCliente;
        if (this.m_idCliente == 0)
        {
          int num1 = (int) Dialogos.MostrarMensajeInformacion(this.Title, "Debe Seleccionar un Cliente Primero.", (Dialogos.Boton) 0);
        }
        else
        {
          int mIdCliente2 = this.m_idCliente;
          DataSet dataSet = (DataSet) null;
          switch (this.TAyuda)
          {
            case AyudaFactura.TipoAyuda.Normal:
              dataSet = this.Client.GetDS("VEN_DOCVSS_TodosByFiltros", new List<object>()
              {
                (object) null,
                (object) null,
                (object) null,
                (object) mIdCliente2,
                (object) "I"
              });
              break;
            case AyudaFactura.TipoAyuda.Todos:
              ObservableCollection<DataAccessFilterSQL> observableCollection1 = new ObservableCollection<DataAccessFilterSQL>();
              ObservableCollection<DataAccessFilterSQL> observableCollection2 = observableCollection1;
              DataAccessFilterSQL dataAccessFilterSql1 = new DataAccessFilterSQL();
              dataAccessFilterSql1.set_FilterName("@pintENTC_Codigo");
              dataAccessFilterSql1.set_FilterValue((object) mIdCliente2);
              dataAccessFilterSql1.set_FilterType((DataAccessFilterTypes) 3);
              dataAccessFilterSql1.set_FilterSize(4);
              DataAccessFilterSQL dataAccessFilterSql2 = dataAccessFilterSql1;
              observableCollection2.Add(dataAccessFilterSql2);
              if (this.AyudaPorOV && !string.IsNullOrEmpty(this.CCOT_TipoNumero) && this.CCOT_TipoNumero.Contains("-"))
              {
                if (this.CCOT_TipoNumero.Split('-').Length == 2)
                {
                  string[] strArray = this.CCOT_TipoNumero.Split('-');
                  short result1;
                  int result2;
                  if (short.TryParse(strArray[0], out result1) && int.TryParse(strArray[1], out result2))
                  {
                    ObservableCollection<DataAccessFilterSQL> observableCollection3 = observableCollection1;
                    DataAccessFilterSQL dataAccessFilterSql3 = new DataAccessFilterSQL();
                    dataAccessFilterSql3.set_FilterName("@pbitCCOT_PorOV");
                    dataAccessFilterSql3.set_FilterValue((object) this.AyudaPorOV);
                    dataAccessFilterSql3.set_FilterType((DataAccessFilterTypes) 6);
                    dataAccessFilterSql3.set_FilterSize(1);
                    DataAccessFilterSQL dataAccessFilterSql4 = dataAccessFilterSql3;
                    observableCollection3.Add(dataAccessFilterSql4);
                    ObservableCollection<DataAccessFilterSQL> observableCollection4 = observableCollection1;
                    DataAccessFilterSQL dataAccessFilterSql5 = new DataAccessFilterSQL();
                    dataAccessFilterSql5.set_FilterName("@psinCCOT_Tipo");
                    dataAccessFilterSql5.set_FilterValue((object) result1);
                    dataAccessFilterSql5.set_FilterType((DataAccessFilterTypes) 2);
                    dataAccessFilterSql5.set_FilterSize(2);
                    DataAccessFilterSQL dataAccessFilterSql6 = dataAccessFilterSql5;
                    observableCollection4.Add(dataAccessFilterSql6);
                    ObservableCollection<DataAccessFilterSQL> observableCollection5 = observableCollection1;
                    DataAccessFilterSQL dataAccessFilterSql7 = new DataAccessFilterSQL();
                    dataAccessFilterSql7.set_FilterName("@pintCCOT_Numero");
                    dataAccessFilterSql7.set_FilterValue((object) result2);
                    dataAccessFilterSql7.set_FilterType((DataAccessFilterTypes) 3);
                    dataAccessFilterSql7.set_FilterSize(4);
                    DataAccessFilterSQL dataAccessFilterSql8 = dataAccessFilterSql7;
                    observableCollection5.Add(dataAccessFilterSql8);
                  }
                }
              }
              dataSet = this.Client.GetDSDocsVta("VEN_DOCVSS_TodosForNotaCredito", observableCollection1, false);
              break;
          }
          if (dataSet == null || dataSet.Tables[0].Rows.Count == 0)
          {
            int num2 = (int) Dialogos.MostrarMensajeInformacion(this.Title, "No se encontraron coincidencias para este Cliente.", (Dialogos.Boton) 0);
          }
          else
          {
            DataTable table = dataSet.Tables[0];
            if (table.Rows.Count == 1)
            {
              string str = string.Format("{0} {1}-{2}", (object) table.Rows[0]["TIPO_TDO"].ToString(), (object) table.Rows[0]["DOCV_Serie"].ToString().PadLeft(3, '0'), (object) table.Rows[0]["DOCV_Numero"].ToString().PadLeft(8, '0'));
              this.AyudaNroFactura.SetValue((object) table, str);
              this.m_value = new DocsVta();
              this.m_value.set_DOCV_Codigo(int.Parse(table.Rows[0]["DOCV_Codigo"].ToString()));
              this.m_value.set_DOCV_Serie(table.Rows[0]["DOCV_Serie"].ToString());
              this.m_value.set_DOCV_Numero(table.Rows[0]["DOCV_Numero"].ToString());
              this.m_value.set_DOCV_FechaEmision(new DateTime?(DateTime.Parse(table.Rows[0]["DOCV_FechaEmision"].ToString())));
              DateTime result = new DateTime();
              if (DateTime.TryParse(table.Rows[0]["DOCV_FechaVcmto"].ToString(), out result))
                this.m_value.set_DOCV_FechaVcmto(new DateTime?(result));
              this.m_value.set_ENTC_Codigo(new int?(mIdCliente2));
              this.m_value.set_DOCV_ValorTotal(Decimal.Parse(table.Rows[0]["DOCV_ValorTotal"].ToString()));
              this.m_value.set_TIPO_CodMND(table.Rows[0]["TIPO_CodMND"].ToString());
              this.m_value.set_DOCV_Estado(table.Rows[0]["DOCV_Estado"].ToString());
              this.m_value.set_DOCV_TipoCambio(Decimal.Parse(table.Rows[0]["DOCV_TipoCambio"].ToString()));
              this.m_value.set_CCCT_Pendiente(Decimal.Parse(table.Rows[0]["CCCT_Pendiente"].ToString()));
              this.m_value.set_CCCT_Codigo(int.Parse(table.Rows[0]["CCCT_Codigo"].ToString()));
              if (this.AyudaValueChanged == null)
                return;
              this.AyudaValueChanged((object) null, EventArgs.Empty);
            }
            else
            {
              List<ColumnaAyuda> columnaAyudaList1 = new List<ColumnaAyuda>();
              int num3 = 0;
              List<ColumnaAyuda> columnaAyudaList2 = columnaAyudaList1;
              ColumnaAyuda columnaAyuda1 = new ColumnaAyuda();
              ColumnaAyuda columnaAyuda2 = columnaAyuda1;
              int num4 = num3;
              int num5 = num4 + 1;
              columnaAyuda2.set_Index(num4);
              columnaAyuda1.set_ColumnName("TIPO_TDO");
              columnaAyuda1.set_ColumnCaption("T. Documento");
              columnaAyuda1.set_Alineacion(DataGridViewContentAlignment.MiddleLeft);
              columnaAyuda1.set_Width(120);
              columnaAyuda1.set_DataType(typeof (string));
              columnaAyuda1.set_Format((string) null);
              ColumnaAyuda columnaAyuda3 = columnaAyuda1;
              columnaAyudaList2.Add(columnaAyuda3);
              List<ColumnaAyuda> columnaAyudaList3 = columnaAyudaList1;
              ColumnaAyuda columnaAyuda4 = new ColumnaAyuda();
              ColumnaAyuda columnaAyuda5 = columnaAyuda4;
              int num6 = num5;
              int num7 = num6 + 1;
              columnaAyuda5.set_Index(num6);
              columnaAyuda4.set_ColumnName("DOCV_Serie");
              columnaAyuda4.set_ColumnCaption("Serie");
              columnaAyuda4.set_Alineacion(DataGridViewContentAlignment.MiddleCenter);
              columnaAyuda4.set_Width(60);
              columnaAyuda4.set_DataType(typeof (string));
              columnaAyuda4.set_Format((string) null);
              ColumnaAyuda columnaAyuda6 = columnaAyuda4;
              columnaAyudaList3.Add(columnaAyuda6);
              List<ColumnaAyuda> columnaAyudaList4 = columnaAyudaList1;
              ColumnaAyuda columnaAyuda7 = new ColumnaAyuda();
              ColumnaAyuda columnaAyuda8 = columnaAyuda7;
              int num8 = num7;
              int num9 = num8 + 1;
              columnaAyuda8.set_Index(num8);
              columnaAyuda7.set_ColumnName("DOCV_Numero");
              columnaAyuda7.set_ColumnCaption("Número");
              columnaAyuda7.set_Alineacion(DataGridViewContentAlignment.MiddleCenter);
              columnaAyuda7.set_Width(60);
              columnaAyuda7.set_DataType(typeof (string));
              columnaAyuda7.set_Format((string) null);
              ColumnaAyuda columnaAyuda9 = columnaAyuda7;
              columnaAyudaList4.Add(columnaAyuda9);
              List<ColumnaAyuda> columnaAyudaList5 = columnaAyudaList1;
              ColumnaAyuda columnaAyuda10 = new ColumnaAyuda();
              ColumnaAyuda columnaAyuda11 = columnaAyuda10;
              int num10 = num9;
              int num11 = num10 + 1;
              columnaAyuda11.set_Index(num10);
              columnaAyuda10.set_ColumnName("Moneda");
              columnaAyuda10.set_ColumnCaption("Moneda");
              columnaAyuda10.set_Alineacion(DataGridViewContentAlignment.MiddleLeft);
              columnaAyuda10.set_Width(60);
              columnaAyuda10.set_DataType(typeof (Decimal));
              columnaAyuda10.set_Format((string) null);
              ColumnaAyuda columnaAyuda12 = columnaAyuda10;
              columnaAyudaList5.Add(columnaAyuda12);
              List<ColumnaAyuda> columnaAyudaList6 = columnaAyudaList1;
              ColumnaAyuda columnaAyuda13 = new ColumnaAyuda();
              ColumnaAyuda columnaAyuda14 = columnaAyuda13;
              int num12 = num11;
              int num13 = num12 + 1;
              columnaAyuda14.set_Index(num12);
              columnaAyuda13.set_ColumnName("DOCV_ValorTotal");
              columnaAyuda13.set_ColumnCaption("Valor Total");
              columnaAyuda13.set_Alineacion(DataGridViewContentAlignment.MiddleRight);
              columnaAyuda13.set_Width(90);
              columnaAyuda13.set_DataType(typeof (Decimal));
              columnaAyuda13.set_Format("#,###,##0.00");
              ColumnaAyuda columnaAyuda15 = columnaAyuda13;
              columnaAyudaList6.Add(columnaAyuda15);
              List<ColumnaAyuda> columnaAyudaList7 = columnaAyudaList1;
              ColumnaAyuda columnaAyuda16 = new ColumnaAyuda();
              ColumnaAyuda columnaAyuda17 = columnaAyuda16;
              int num14 = num13;
              int num15 = num14 + 1;
              columnaAyuda17.set_Index(num14);
              columnaAyuda16.set_ColumnName("CCCT_Pendiente");
              columnaAyuda16.set_ColumnCaption("Saldo");
              columnaAyuda16.set_Alineacion(DataGridViewContentAlignment.MiddleRight);
              columnaAyuda16.set_Width(90);
              columnaAyuda16.set_DataType(typeof (Decimal));
              columnaAyuda16.set_Format("#,###,##0.00");
              ColumnaAyuda columnaAyuda18 = columnaAyuda16;
              columnaAyudaList7.Add(columnaAyuda18);
              List<ColumnaAyuda> columnaAyudaList8 = columnaAyudaList1;
              ColumnaAyuda columnaAyuda19 = new ColumnaAyuda();
              ColumnaAyuda columnaAyuda20 = columnaAyuda19;
              int num16 = num15;
              int num17 = num16 + 1;
              columnaAyuda20.set_Index(num16);
              columnaAyuda19.set_ColumnName("DOCV_FechaEmision");
              columnaAyuda19.set_ColumnCaption("Fecha Emisión");
              columnaAyuda19.set_Alineacion(DataGridViewContentAlignment.MiddleCenter);
              columnaAyuda19.set_Width(100);
              columnaAyuda19.set_DataType(typeof (DateTime));
              columnaAyuda19.set_Format("dd/MM/yyyy");
              ColumnaAyuda columnaAyuda21 = columnaAyuda19;
              columnaAyudaList8.Add(columnaAyuda21);
              List<ColumnaAyuda> columnaAyudaList9 = columnaAyudaList1;
              ColumnaAyuda columnaAyuda22 = new ColumnaAyuda();
              ColumnaAyuda columnaAyuda23 = columnaAyuda22;
              int num18 = num17;
              int num19 = num18 + 1;
              columnaAyuda23.set_Index(num18);
              columnaAyuda22.set_ColumnName("SERVICIOS");
              columnaAyuda22.set_ColumnCaption("Servicios");
              columnaAyuda22.set_Alineacion(DataGridViewContentAlignment.MiddleLeft);
              columnaAyuda22.set_Width(250);
              columnaAyuda22.set_DataType(typeof (Decimal));
              columnaAyuda22.set_Format((string) null);
              ColumnaAyuda columnaAyuda24 = columnaAyuda22;
              columnaAyudaList9.Add(columnaAyuda24);
              Ayuda ayuda1 = new Ayuda(this.Title, table, false, (IEnumerable<ColumnaAyuda>) columnaAyudaList1, "");
              Ayuda ayuda2 = ayuda1;
              ((Control) ayuda2).Width = ((Control) ayuda2).Width + 200;
              if (((Form) ayuda1).ShowDialog() == DialogResult.OK)
              {
                string str = string.Format("{0} {1}-{2}", (object) ayuda1.get_Respuesta().Rows[0]["TIPO_TDO"].ToString(), (object) ayuda1.get_Respuesta().Rows[0]["DOCV_Serie"].ToString().PadLeft(3, '0'), (object) ayuda1.get_Respuesta().Rows[0]["DOCV_Numero"].ToString().PadLeft(8, '0'));
                this.AyudaNroFactura.SetValue((object) ayuda1.get_Respuesta(), str);
                this.m_value = new DocsVta();
                this.m_value.set_DOCV_Codigo(int.Parse(ayuda1.get_Respuesta().Rows[0]["DOCV_Codigo"].ToString()));
                this.m_value.set_DOCV_Serie(ayuda1.get_Respuesta().Rows[0]["DOCV_Serie"].ToString());
                this.m_value.set_DOCV_Numero(ayuda1.get_Respuesta().Rows[0]["DOCV_Numero"].ToString());
                this.m_value.set_DOCV_FechaEmision(new DateTime?(DateTime.Parse(ayuda1.get_Respuesta().Rows[0]["DOCV_FechaEmision"].ToString())));
                DateTime result = new DateTime();
                if (DateTime.TryParse(ayuda1.get_Respuesta().Rows[0]["DOCV_FechaVcmto"].ToString(), out result))
                  this.m_value.set_DOCV_FechaVcmto(new DateTime?(result));
                this.m_value.set_ENTC_Codigo(new int?(mIdCliente2));
                this.m_value.set_DOCV_ValorTotal(Decimal.Parse(ayuda1.get_Respuesta().Rows[0]["DOCV_ValorTotal"].ToString()));
                this.m_value.set_TIPO_CodMND(ayuda1.get_Respuesta().Rows[0]["TIPO_CodMND"].ToString());
                this.m_value.set_DOCV_Estado(ayuda1.get_Respuesta().Rows[0]["DOCV_Estado"].ToString());
                this.m_value.set_DOCV_TipoCambio(Decimal.Parse(ayuda1.get_Respuesta().Rows[0]["DOCV_TipoCambio"].ToString()));
                if (!string.IsNullOrEmpty(ayuda1.get_Respuesta().Rows[0]["CCCT_Pendiente"].ToString()))
                  this.m_value.set_CCCT_Pendiente(Decimal.Parse(ayuda1.get_Respuesta().Rows[0]["CCCT_Pendiente"].ToString()));
                this.m_value.set_CCCT_Codigo(int.Parse(ayuda1.get_Respuesta().Rows[0]["CCCT_Codigo"].ToString()));
                if (this.AyudaValueChanged == null)
                  return;
                this.AyudaValueChanged((object) null, EventArgs.Empty);
              }
              else
                this.ClearValue();
            }
          }
        }
      }
      catch (Exception ex)
      {
        int num = (int) Dialogos.MostrarMensajeError(this.Title, "ha ocurrido un error en la Ayuda de Tarifario", ex);
      }
    }

    public void SetValue(int idCliente)
    {
      try
      {
        DocsVta oneDocsVta = this.Client.GetOneDocsVta(idCliente);
        if (oneDocsVta != null)
        {
          this.m_value = new DocsVta();
          this.SelectedItem = oneDocsVta;
          this.m_value = oneDocsVta;
          string str = string.Format("{0} {1}-{2}", (object) oneDocsVta.get_TIPO_TDO(), (object) oneDocsVta.get_DOCV_Serie().PadLeft(3, '0'), (object) oneDocsVta.get_DOCV_Numero().PadLeft(8, '0'));
          this.AyudaNroFactura.SetValue((object) oneDocsVta, str);
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

    private void AyudaNroFactura_AyudaClean(object sender, EventArgs e)
    {
      this.ClearValue();
    }

    private void AyudaNroFactura_AyudaClick(object sender, EventArgs e)
    {
      if (this.AyudaGetValores != null)
        this.AyudaGetValores((object) null, EventArgs.Empty);
      this.LoadAyuda();
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
      this.AyudaNroFactura = new TextBoxAyuda();
      this.TlPanel.SuspendLayout();
      this.SuspendLayout();
      this.TlPanel.AutoSize = true;
      this.TlPanel.BackColor = Color.LightSteelBlue;
      this.TlPanel.ColumnCount = 1;
      this.TlPanel.ColumnStyles.Add(new ColumnStyle());
      this.TlPanel.Controls.Add((Control) this.AyudaNroFactura, 0, 0);
      this.TlPanel.Dock = DockStyle.Fill;
      this.TlPanel.GrowStyle = TableLayoutPanelGrowStyle.FixedSize;
      this.TlPanel.Location = new Point(0, 0);
      this.TlPanel.Name = "TlPanel";
      this.TlPanel.RowCount = 1;
      this.TlPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 27f));
      this.TlPanel.Size = new Size(116, 26);
      this.TlPanel.TabIndex = 6;
      this.AyudaNroFactura.set_ActivarAyudaAuto(false);
      ((Control) this.AyudaNroFactura).Dock = DockStyle.Fill;
      this.AyudaNroFactura.set_EnabledAyudaButton(true);
      ((Control) this.AyudaNroFactura).Location = new Point(3, 3);
      this.AyudaNroFactura.set_LongitudAceptada(0);
      this.AyudaNroFactura.set_MyInstanciaAyuda((TextBoxAyuda.InstanciaAyuda) 0);
      ((Control) this.AyudaNroFactura).Name = "AyudaNroFactura";
      this.AyudaNroFactura.set_RellenaCeros(false);
      ((Control) this.AyudaNroFactura).Size = new Size(110, 20);
      ((Control) this.AyudaNroFactura).TabIndex = 18;
      this.AyudaNroFactura.set_Tipo((TextBoxAyuda.TipoTextBoxAyuda) 1);
      this.AyudaNroFactura.set_Value((object) null);
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.BackColor = Color.LightSteelBlue;
      this.Controls.Add((Control) this.TlPanel);
      this.Cursor = Cursors.Arrow;
      this.Name = nameof (AyudaFactura);
      this.Size = new Size(116, 26);
      this.TlPanel.ResumeLayout(false);
      this.TlPanel.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();
    }

    public enum TipoAyuda
    {
      Normal,
      Todos,
    }
  }
}
