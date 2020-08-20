// Decompiled with JetBrains decompiler
// Type: Delfin.Controls.AyudaPuerto
// Assembly: Delfin.Controls, Version=3.0.1.3, Culture=neutral, PublicKeyToken=null
// MVID: A4BA2B33-0E71-44B0-9838-A6C1CD0C2B15
// Assembly location: C:\Temp\Delfin.Controls.dll

using Delfin.Entities;
using Delfin.ServiceProxy;
using Infrastructure.Aspect.Collections;
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
  public class AyudaPuerto : UserControl
  {
    private Puerto m_selecteditem;
    private IContainer components;
    private TextBoxAyuda txaPUER_CodEstandar;
    private TextBoxAyuda txaPUER_Nombre;
    private ToolTip toolTipPuerto;

    public AyudaPuerto()
    {
      this.InitializeComponent();
      ((TextBox) this.txaPUER_CodEstandar).CharacterCasing = CharacterCasing.Upper;
      this.txaPUER_CodEstandar.add_AyudaClick(new EventHandler(this.txaPUER_CodEstandar_AyudaClick));
      this.txaPUER_CodEstandar.add_AyudaClean(new EventHandler(this.txaPUER_CodEstandar_AyudaClean));
      this.txaPUER_CodEstandar.add_AyudaLoad(new EventHandler(this.txaPUER_CodEstandar_AyudaLoad));
      ((TextBox) this.txaPUER_Nombre).CharacterCasing = CharacterCasing.Upper;
      this.txaPUER_Nombre.add_AyudaClick(new EventHandler(this.txaPUER_Nombre_AyudaClick));
      this.txaPUER_Nombre.add_AyudaClean(new EventHandler(this.txaPUER_Nombre_AyudaClean));
      this.txaPUER_Nombre.add_AyudaLoad(new EventHandler(this.txaPUER_Nombre_AyudaLoad));
    }

    public void LoadControl(IUnityContainer ContainerService, string x_title)
    {
      try
      {
        this.Title = x_title;
        this.Client = (DelfinServicesProxy) UnityContainerExtensions.Resolve<DelfinServicesProxy>(ContainerService, new ResolverOverride[0]);
      }
      catch (Exception ex)
      {
      }
    }

    private DelfinServicesProxy Client { get; set; }

    public string Title { get; set; }

    public int? SelectedValue
    {
      get
      {
        if (this.m_selecteditem != null)
          return new int?(this.m_selecteditem.get_PUER_Codigo());
        return new int?();
      }
      set
      {
        if (value.HasValue)
          this.LoadPuerto(value.Value);
        else
          this.LimpiarPuerto();
      }
    }

    public Puerto SelectedItem
    {
      get
      {
        return this.m_selecteditem;
      }
      set
      {
        this.m_selecteditem = value;
        if (this.SelectedItemChanged == null)
          return;
        this.SelectedItemChanged((object) this.SelectedItem, EventArgs.Empty);
      }
    }

    public bool DontSendTab { get; set; }

    public void Clear()
    {
      this.LimpiarPuerto();
    }

    public string CONS_TabVia { get; set; }

    public string CONS_CodVia { get; set; }

    public string TIPO_TabPais { get; set; }

    public string TIPO_CodPais { get; set; }

    private void LoadAyudaPuerto(bool x_porcodigo)
    {
      try
      {
        this.txaPUER_CodEstandar.set_EnabledAyudaButton(false);
        this.txaPUER_Nombre.set_EnabledAyudaButton(false);
        if (x_porcodigo)
        {
          if (((Control) this.txaPUER_CodEstandar).Text.Length < 2)
          {
            int num = (int) Dialogos.MostrarMensajeInformacion(this.Title, "Ingrese al menos dos caracteres \n como criterio de busqueda ej. PE...", (Dialogos.Boton) 0);
            this.txaPUER_CodEstandar.set_EnabledAyudaButton(true);
            this.txaPUER_Nombre.set_EnabledAyudaButton(true);
            return;
          }
        }
        else if (((Control) this.txaPUER_Nombre).Text.Length < 2)
        {
          int num = (int) Dialogos.MostrarMensajeInformacion(this.Title, "Ingrese al menos dos caracteres \n como criterio de busqueda ej. PE...", (Dialogos.Boton) 0);
          this.txaPUER_CodEstandar.set_EnabledAyudaButton(true);
          this.txaPUER_Nombre.set_EnabledAyudaButton(true);
          return;
        }
        DataTable dataTable1 = new DataTable();
        DataTable dataTable2 = IEnumerableExtensions.ToDataTable<Puerto>((IEnumerable<M0>) this.Client.GetAllPuertoByAyuda(this.CONS_TabVia, this.CONS_CodVia, this.TIPO_TabPais, this.TIPO_CodPais, ((Control) this.txaPUER_CodEstandar).Text, ((Control) this.txaPUER_Nombre).Text));
        dataTable2.DefaultView.Sort = x_porcodigo ? "PUER_CODIGO" : "PUER_NOMBRE";
        if (dataTable2.Rows.Count == 0)
        {
          int num = (int) Dialogos.MostrarMensajeInformacion(this.Title, "No se encontraron coincidencias.", (Dialogos.Boton) 0);
          this.txaPUER_CodEstandar.set_EnabledAyudaButton(true);
          this.txaPUER_Nombre.set_EnabledAyudaButton(true);
        }
        else if (dataTable2.Rows.Count == 1)
        {
          int result;
          if (dataTable2.Columns.Contains("PUER_Codigo") && dataTable2.Rows[0]["PUER_Codigo"] != DBNull.Value && (!string.IsNullOrEmpty(dataTable2.Rows[0]["PUER_Codigo"].ToString()) && int.TryParse(dataTable2.Rows[0]["PUER_Codigo"].ToString(), out result)))
            this.LoadPuerto(result);
          else
            this.LimpiarPuerto();
        }
        else
        {
          List<ColumnaAyuda> columnaAyudaList1 = new List<ColumnaAyuda>();
          List<ColumnaAyuda> columnaAyudaList2 = columnaAyudaList1;
          ColumnaAyuda columnaAyuda1 = new ColumnaAyuda();
          columnaAyuda1.set_Index(x_porcodigo ? 5 : 5);
          columnaAyuda1.set_ColumnName("PUER_Codigo");
          columnaAyuda1.set_ColumnCaption("Código");
          columnaAyuda1.set_Alineacion(DataGridViewContentAlignment.MiddleLeft);
          columnaAyuda1.set_Width(100);
          columnaAyuda1.set_DataType(typeof (int));
          columnaAyuda1.set_Format((string) null);
          ColumnaAyuda columnaAyuda2 = columnaAyuda1;
          columnaAyudaList2.Add(columnaAyuda2);
          List<ColumnaAyuda> columnaAyudaList3 = columnaAyudaList1;
          ColumnaAyuda columnaAyuda3 = new ColumnaAyuda();
          columnaAyuda3.set_Index(x_porcodigo ? 1 : 1);
          columnaAyuda3.set_ColumnName("PUER_CodEstandar");
          columnaAyuda3.set_ColumnCaption("Código Estandar");
          columnaAyuda3.set_Alineacion(DataGridViewContentAlignment.MiddleLeft);
          columnaAyuda3.set_Width(100);
          columnaAyuda3.set_DataType(typeof (int));
          columnaAyuda3.set_Format((string) null);
          ColumnaAyuda columnaAyuda4 = columnaAyuda3;
          columnaAyudaList3.Add(columnaAyuda4);
          List<ColumnaAyuda> columnaAyudaList4 = columnaAyudaList1;
          ColumnaAyuda columnaAyuda5 = new ColumnaAyuda();
          columnaAyuda5.set_Index(x_porcodigo ? 0 : 0);
          columnaAyuda5.set_ColumnName("PUER_Nombre");
          columnaAyuda5.set_ColumnCaption("Nombre");
          columnaAyuda5.set_Alineacion(DataGridViewContentAlignment.MiddleLeft);
          columnaAyuda5.set_Width(150);
          columnaAyuda5.set_DataType(typeof (string));
          columnaAyuda5.set_Format((string) null);
          ColumnaAyuda columnaAyuda6 = columnaAyuda5;
          columnaAyudaList4.Add(columnaAyuda6);
          List<ColumnaAyuda> columnaAyudaList5 = columnaAyudaList1;
          ColumnaAyuda columnaAyuda7 = new ColumnaAyuda();
          columnaAyuda7.set_Index(3);
          columnaAyuda7.set_ColumnName("TIPO_DescPais");
          columnaAyuda7.set_ColumnCaption("País");
          columnaAyuda7.set_Alineacion(DataGridViewContentAlignment.MiddleLeft);
          columnaAyuda7.set_Width(150);
          columnaAyuda7.set_DataType(typeof (string));
          columnaAyuda7.set_Format((string) null);
          ColumnaAyuda columnaAyuda8 = columnaAyuda7;
          columnaAyudaList5.Add(columnaAyuda8);
          List<ColumnaAyuda> columnaAyudaList6 = columnaAyudaList1;
          ColumnaAyuda columnaAyuda9 = new ColumnaAyuda();
          columnaAyuda9.set_Index(4);
          columnaAyuda9.set_ColumnName("CONS_DescVia");
          columnaAyuda9.set_ColumnCaption("Vía");
          columnaAyuda9.set_Alineacion(DataGridViewContentAlignment.MiddleLeft);
          columnaAyuda9.set_Width(100);
          columnaAyuda9.set_DataType(typeof (string));
          columnaAyuda9.set_Format((string) null);
          ColumnaAyuda columnaAyuda10 = columnaAyuda9;
          columnaAyudaList6.Add(columnaAyuda10);
          Ayuda ayuda = new Ayuda("Ayuda Puertos", dataTable2, false, (IEnumerable<ColumnaAyuda>) columnaAyudaList1, "");
          if (((Form) ayuda).ShowDialog() == DialogResult.OK)
          {
            int result;
            if (ayuda.get_Respuesta() != null && ayuda.get_Respuesta().Columns.Contains("PUER_Codigo") && (ayuda.get_Respuesta().Rows[0]["PUER_Codigo"] != DBNull.Value && !string.IsNullOrEmpty(ayuda.get_Respuesta().Rows[0]["PUER_Codigo"].ToString())) && int.TryParse(ayuda.get_Respuesta().Rows[0]["PUER_Codigo"].ToString(), out result))
              this.LoadPuerto(result);
            else
              this.LimpiarPuerto();
          }
          else
            this.LimpiarPuerto();
        }
      }
      catch (Exception ex)
      {
      }
    }

    private void LimpiarPuerto()
    {
      try
      {
        this.SelectedItem = (Puerto) null;
        this.txaPUER_CodEstandar.ClearValue();
        this.txaPUER_Nombre.ClearValue();
        this.toolTipPuerto.SetToolTip((Control) this.txaPUER_Nombre, (string) null);
        this.txaPUER_CodEstandar.set_EnabledAyudaButton(true);
        this.txaPUER_Nombre.set_EnabledAyudaButton(true);
      }
      catch (Exception ex)
      {
      }
    }

    private void LoadPuerto(int PUER_Codigo)
    {
      try
      {
        this.SelectedItem = this.Client.GetOnePuerto(PUER_Codigo);
        if (this.SelectedItem != null)
        {
          this.txaPUER_CodEstandar.SetValue((object) this.SelectedItem, this.SelectedItem.get_PUER_CodEstandar());
          this.txaPUER_Nombre.SetValue((object) this.SelectedItem, this.SelectedItem.get_PUER_Nombre() + (!string.IsNullOrEmpty(this.SelectedItem.get_TIPO_DescPais()) ? "," + this.SelectedItem.get_TIPO_DescPais() : ""));
          this.toolTipPuerto.SetToolTip((Control) this.txaPUER_Nombre, !string.IsNullOrEmpty(this.SelectedItem.get_TIPO_DescPais()) ? this.SelectedItem.get_TIPO_DescPais() : "");
          this.txaPUER_Nombre.Focus();
          if (!this.DontSendTab)
            SendKeys.Send("{TAB}");
          else
            this.DontSendTab = false;
        }
        else
          this.LimpiarPuerto();
      }
      catch (Exception ex)
      {
      }
    }

    public event EventHandler SelectedItemChanged;

    private void txaPUER_CodEstandar_AyudaClick(object sender, EventArgs e)
    {
      this.LoadAyudaPuerto(true);
    }

    private void txaPUER_Nombre_AyudaClick(object sender, EventArgs e)
    {
      this.LoadAyudaPuerto(false);
    }

    private void txaPUER_CodEstandar_AyudaLoad(object sender, EventArgs e)
    {
    }

    private void txaPUER_CodEstandar_AyudaClean(object sender, EventArgs e)
    {
      this.LimpiarPuerto();
    }

    private void txaPUER_Nombre_AyudaClean(object sender, EventArgs e)
    {
      this.LimpiarPuerto();
    }

    private void txaPUER_Nombre_AyudaLoad(object sender, EventArgs e)
    {
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      this.txaPUER_CodEstandar = new TextBoxAyuda();
      this.txaPUER_Nombre = new TextBoxAyuda();
      this.toolTipPuerto = new ToolTip();
      this.SuspendLayout();
      this.txaPUER_CodEstandar.set_ActivarAyudaAuto(false);
      this.txaPUER_CodEstandar.set_EnabledAyudaButton(true);
      ((Control) this.txaPUER_CodEstandar).Location = new Point(0, 0);
      this.txaPUER_CodEstandar.set_LongitudAceptada(0);
      this.txaPUER_CodEstandar.set_MyInstanciaAyuda((TextBoxAyuda.InstanciaAyuda) 0);
      ((Control) this.txaPUER_CodEstandar).Name = "txaPUER_CodEstandar";
      this.txaPUER_CodEstandar.set_RellenaCeros(false);
      ((Control) this.txaPUER_CodEstandar).Size = new Size(80, 20);
      ((Control) this.txaPUER_CodEstandar).TabIndex = 0;
      this.txaPUER_CodEstandar.set_Tag((object) "PUER_CodEstandarMSGERROR");
      this.txaPUER_CodEstandar.set_Tipo((TextBoxAyuda.TipoTextBoxAyuda) 1);
      this.txaPUER_CodEstandar.set_Value((object) null);
      this.txaPUER_Nombre.set_ActivarAyudaAuto(false);
      ((Control) this.txaPUER_Nombre).Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.txaPUER_Nombre.set_EnabledAyudaButton(true);
      ((Control) this.txaPUER_Nombre).Location = new Point(80, 0);
      this.txaPUER_Nombre.set_LongitudAceptada(0);
      this.txaPUER_Nombre.set_MyInstanciaAyuda((TextBoxAyuda.InstanciaAyuda) 0);
      ((Control) this.txaPUER_Nombre).Name = "txaPUER_Nombre";
      this.txaPUER_Nombre.set_RellenaCeros(false);
      ((Control) this.txaPUER_Nombre).Size = new Size(81, 20);
      ((Control) this.txaPUER_Nombre).TabIndex = 1;
      this.txaPUER_Nombre.set_Tag((object) "PUER_NombreMSGERROR");
      this.txaPUER_Nombre.set_Tipo((TextBoxAyuda.TipoTextBoxAyuda) 1);
      this.txaPUER_Nombre.set_Value((object) null);
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.BackColor = Color.LightSteelBlue;
      this.Controls.Add((Control) this.txaPUER_Nombre);
      this.Controls.Add((Control) this.txaPUER_CodEstandar);
      this.Name = nameof (AyudaPuerto);
      this.Size = new Size(161, 20);
      this.ResumeLayout(false);
      this.PerformLayout();
    }
  }
}
