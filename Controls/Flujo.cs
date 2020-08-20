// Decompiled with JetBrains decompiler
// Type: Delfin.Controls.Flujo
// Assembly: Delfin.Controls, Version=3.0.1.3, Culture=neutral, PublicKeyToken=null
// MVID: A4BA2B33-0E71-44B0-9838-A6C1CD0C2B15
// Assembly location: C:\Temp\Delfin.Controls.dll

using Delfin.Entities;
using Delfin.ServiceContracts;
using Delfin.ServiceProxy;
using Infrastructure.Aspect.Collections;
using Infrastructure.Aspect.DataAccess;
using Infrastructure.WinForms.Controls;
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
  public class Flujo : TextBoxAyuda
  {
    public string Title;
    private IContainer components;

    public short EMPR_Codigo { get; set; }

    private IDelfinServices Client { get; set; }

    public Flujo.TipoAyuda TAyuda { get; set; }

    public Flujo SelectedItem
    {
      get
      {
        if (this.get_Value() != null && this.get_Value() is Flujo)
          return this.get_Value() as Flujo;
        return (Flujo) null;
      }
      set
      {
        if (value != null)
          this.SetValue((object) value, value.get_FLUJ_Codigo());
        else
          this.ClearValue();
      }
    }

    public Flujo()
    {
      base.\u002Ector();
      this.InitializeComponent();
      this.InitializeEntidad();
    }

    public Flujo(IContainer container)
    {
      base.\u002Ector();
      container.Add((IComponent) this);
      this.InitializeComponent();
      this.InitializeEntidad();
    }

    private void InitializeEntidad()
    {
      try
      {
        ((TextBox) this).CharacterCasing = CharacterCasing.Upper;
        ((TextBoxBase) this).MaxLength = 100;
        ((Control) this).Size = new Size(100, 21);
        this.add_AyudaClick(new EventHandler(this.Flujo_AyudaClick));
        this.add_AyudaClean(new EventHandler(this.Flujo_AyudaClean));
        this.add_AyudaValueChanged(new EventHandler(this.Flujo_AyudaValueChanged));
      }
      catch (Exception ex)
      {
      }
    }

    public void LoadControl(IUnityContainer Container, string x_title, int x_empr_codigo, Flujo.TipoAyuda x_opcion)
    {
      try
      {
        this.Client = (IDelfinServices) UnityContainerExtensions.Resolve<IDelfinServices>(Container, new ResolverOverride[0]);
        this.EMPR_Codigo = Convert.ToInt16(x_empr_codigo);
        this.TAyuda = x_opcion;
        this.Title = x_title;
      }
      catch (Exception ex)
      {
      }
    }

    private void AyudaFlujos()
    {
      try
      {
        string text = ((Control) this).Text;
        if (this.Client == null)
          this.Client = (IDelfinServices) new DelfinServicesProxy();
        DataTable dataTable1 = new DataTable();
        ObservableCollection<DataAccessFilterSQL> observableCollection1 = new ObservableCollection<DataAccessFilterSQL>();
        ObservableCollection<DataAccessFilterSQL> observableCollection2 = observableCollection1;
        DataAccessFilterSQL dataAccessFilterSql1 = new DataAccessFilterSQL();
        dataAccessFilterSql1.set_FilterName("@F_TIPO_Flujo");
        dataAccessFilterSql1.set_FilterValue((object) null);
        dataAccessFilterSql1.set_FilterType((DataAccessFilterTypes) 0);
        dataAccessFilterSql1.set_FilterSize(1);
        DataAccessFilterSQL dataAccessFilterSql2 = dataAccessFilterSql1;
        observableCollection2.Add(dataAccessFilterSql2);
        switch (this.TAyuda)
        {
          case Flujo.TipoAyuda.Normal:
            ObservableCollection<DataAccessFilterSQL> observableCollection3 = observableCollection1;
            DataAccessFilterSQL dataAccessFilterSql3 = new DataAccessFilterSQL();
            dataAccessFilterSql3.set_FilterName("@F_TIPO_Movimiento");
            dataAccessFilterSql3.set_FilterValue((object) null);
            dataAccessFilterSql3.set_FilterType((DataAccessFilterTypes) 0);
            dataAccessFilterSql3.set_FilterSize(1);
            DataAccessFilterSQL dataAccessFilterSql4 = dataAccessFilterSql3;
            observableCollection3.Add(dataAccessFilterSql4);
            break;
          case Flujo.TipoAyuda.Ingresos:
            ObservableCollection<DataAccessFilterSQL> observableCollection4 = observableCollection1;
            DataAccessFilterSQL dataAccessFilterSql5 = new DataAccessFilterSQL();
            dataAccessFilterSql5.set_FilterName("@F_TIPO_Movimiento");
            dataAccessFilterSql5.set_FilterValue((object) "I");
            dataAccessFilterSql5.set_FilterType((DataAccessFilterTypes) 0);
            dataAccessFilterSql5.set_FilterSize(1);
            DataAccessFilterSQL dataAccessFilterSql6 = dataAccessFilterSql5;
            observableCollection4.Add(dataAccessFilterSql6);
            break;
          case Flujo.TipoAyuda.Egresos:
            ObservableCollection<DataAccessFilterSQL> observableCollection5 = observableCollection1;
            DataAccessFilterSQL dataAccessFilterSql7 = new DataAccessFilterSQL();
            dataAccessFilterSql7.set_FilterName("@F_TIPO_Movimiento");
            dataAccessFilterSql7.set_FilterValue((object) "E");
            dataAccessFilterSql7.set_FilterType((DataAccessFilterTypes) 0);
            dataAccessFilterSql7.set_FilterSize(1);
            DataAccessFilterSQL dataAccessFilterSql8 = dataAccessFilterSql7;
            observableCollection5.Add(dataAccessFilterSql8);
            break;
        }
        DataTable dataTable2 = IEnumerableExtensions.ToDataTable<Flujo>((IEnumerable<M0>) this.Client.GetAllFlujoFilter("CAJ_FLUJSS_Todos_ByFilters", observableCollection1));
        if (dataTable2.Rows.Count == 0)
        {
          int num1 = (int) Dialogos.MostrarMensajeInformacion(this.Title, "No se encontraron coincidencias.", (Dialogos.Boton) 0);
        }
        else if (dataTable2.Rows.Count == 1)
        {
          if (dataTable2.Rows[0]["FLUJ_Codigo"] != DBNull.Value)
            this.SetCuentaBancaria(this.EMPR_Codigo, dataTable2.Rows[0]["FLUJ_Codigo"].ToString());
          else
            this.ClearFlujo();
        }
        else
        {
          List<ColumnaAyuda> columnaAyudaList1 = new List<ColumnaAyuda>();
          int num2 = 0;
          List<ColumnaAyuda> columnaAyudaList2 = columnaAyudaList1;
          ColumnaAyuda columnaAyuda1 = new ColumnaAyuda();
          ColumnaAyuda columnaAyuda2 = columnaAyuda1;
          int num3 = num2;
          int num4 = num3 + 1;
          columnaAyuda2.set_Index(num3);
          columnaAyuda1.set_ColumnName("FLUJ_Codigo");
          columnaAyuda1.set_ColumnCaption("Código");
          columnaAyuda1.set_Alineacion(DataGridViewContentAlignment.MiddleLeft);
          columnaAyuda1.set_Width(50);
          columnaAyuda1.set_DataType(typeof (string));
          columnaAyuda1.set_Format((string) null);
          ColumnaAyuda columnaAyuda3 = columnaAyuda1;
          columnaAyudaList2.Add(columnaAyuda3);
          List<ColumnaAyuda> columnaAyudaList3 = columnaAyudaList1;
          ColumnaAyuda columnaAyuda4 = new ColumnaAyuda();
          ColumnaAyuda columnaAyuda5 = columnaAyuda4;
          int num5 = num4;
          int num6 = num5 + 1;
          columnaAyuda5.set_Index(num5);
          columnaAyuda4.set_ColumnName("FLUJ_Glosa");
          columnaAyuda4.set_ColumnCaption("Glosa");
          columnaAyuda4.set_Alineacion(DataGridViewContentAlignment.MiddleLeft);
          columnaAyuda4.set_Width(50);
          columnaAyuda4.set_DataType(typeof (string));
          columnaAyuda4.set_Format((string) null);
          ColumnaAyuda columnaAyuda6 = columnaAyuda4;
          columnaAyudaList3.Add(columnaAyuda6);
          List<ColumnaAyuda> columnaAyudaList4 = columnaAyudaList1;
          ColumnaAyuda columnaAyuda7 = new ColumnaAyuda();
          ColumnaAyuda columnaAyuda8 = columnaAyuda7;
          int num7 = num6;
          int num8 = num7 + 1;
          columnaAyuda8.set_Index(num7);
          columnaAyuda7.set_ColumnName("FLUJ_TipoFlujo_Text");
          columnaAyuda7.set_ColumnCaption("Tipo Flujo");
          columnaAyuda7.set_Alineacion(DataGridViewContentAlignment.MiddleLeft);
          columnaAyuda7.set_Width(120);
          columnaAyuda7.set_DataType(typeof (string));
          columnaAyuda7.set_Format((string) null);
          ColumnaAyuda columnaAyuda9 = columnaAyuda7;
          columnaAyudaList4.Add(columnaAyuda9);
          List<ColumnaAyuda> columnaAyudaList5 = columnaAyudaList1;
          ColumnaAyuda columnaAyuda10 = new ColumnaAyuda();
          ColumnaAyuda columnaAyuda11 = columnaAyuda10;
          int num9 = num8;
          int num10 = num9 + 1;
          columnaAyuda11.set_Index(num9);
          columnaAyuda10.set_ColumnName("FLUJ_TipoMovimiento_Text");
          columnaAyuda10.set_ColumnCaption("Tipo Movimiento");
          columnaAyuda10.set_Alineacion(DataGridViewContentAlignment.MiddleCenter);
          columnaAyuda10.set_Width(150);
          columnaAyuda10.set_DataType(typeof (int));
          columnaAyuda10.set_Format((string) null);
          ColumnaAyuda columnaAyuda12 = columnaAyuda10;
          columnaAyudaList5.Add(columnaAyuda12);
          Ayuda ayuda = new Ayuda("Ayuda Tipos Flujos", dataTable2, false, (IEnumerable<ColumnaAyuda>) columnaAyudaList1, "");
          ((Form) ayuda).Size = new Size(((Control) ayuda).Width + 150, ((Control) ayuda).Height);
          ((Control) this).KeyUp -= new KeyEventHandler(((TextBoxAyuda) this).TextBoxAyuda_Key);
          if (((Form) ayuda).ShowDialog() == DialogResult.OK)
          {
            if (dataTable2.Rows[0]["FLUJ_Codigo"] != DBNull.Value)
              this.SetCuentaBancaria(this.EMPR_Codigo, ayuda.get_Respuesta().Rows[0]["FLUJ_Codigo"].ToString());
            else
              this.ClearFlujo();
          }
          else
            this.ClearFlujo();
          ((Control) this).KeyUp += new KeyEventHandler(((TextBoxAyuda) this).TextBoxAyuda_Key);
        }
      }
      catch (Exception ex)
      {
        int num = (int) Dialogos.MostrarMensajeError(this.Title, "Ha ocurrido un error al cargar la ayuda de Cuenta Bancaria", ex);
      }
    }

    public void SetCuentaBancaria(short x_EMPR_Codigo, string X_FLUJ_Codigo)
    {
      try
      {
        if (X_FLUJ_Codigo != null)
        {
          if (this.Client == null)
            return;
          Flujo oneFlujo = this.Client.GetOneFlujo(x_EMPR_Codigo, X_FLUJ_Codigo);
          if (oneFlujo != null)
          {
            this.SetValue((object) oneFlujo, oneFlujo.get_FLUJ_Glosa());
            this.Focus();
            SendKeys.Send("{TAB}");
          }
          else
            this.ClearFlujo();
        }
        else
          this.ClearFlujo();
      }
      catch (Exception ex)
      {
      }
    }

    public void SetCuentaBancaria(Flujo x_CuentaBancaria)
    {
      try
      {
        if (x_CuentaBancaria != null)
        {
          if (this.Client == null)
            return;
          Flujo flujo = x_CuentaBancaria;
          if (flujo != null)
          {
            this.SetValue((object) flujo, flujo.get_FLUJ_Codigo());
            this.Focus();
            SendKeys.Send("{TAB}");
          }
          else
            this.ClearFlujo();
        }
        else
          this.ClearFlujo();
      }
      catch (Exception ex)
      {
      }
    }

    public void ClearFlujo()
    {
      try
      {
        this.ClearValue();
      }
      catch (Exception ex)
      {
      }
    }

    public event EventHandler SelectedItemFlujoChanged;

    private void Flujo_AyudaClean(object sender, EventArgs e)
    {
      try
      {
        this.ClearFlujo();
      }
      catch (Exception ex)
      {
      }
    }

    private void Flujo_AyudaClick(object sender, EventArgs e)
    {
      try
      {
        this.AyudaFlujos();
      }
      catch (Exception ex)
      {
      }
    }

    private void Flujo_AyudaValueChanged(object sender, EventArgs e)
    {
      if (this.SelectedItemFlujoChanged == null)
        return;
      this.SelectedItemFlujoChanged(this.get_Value(), EventArgs.Empty);
    }

    protected virtual void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      this.components = (IContainer) new Container();
    }

    public enum TipoAyuda
    {
      Normal,
      Ingresos,
      Egresos,
    }
  }
}
