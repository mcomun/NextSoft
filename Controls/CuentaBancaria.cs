// Decompiled with JetBrains decompiler
// Type: Delfin.Controls.CuentaBancaria
// Assembly: Delfin.Controls, Version=3.0.1.3, Culture=neutral, PublicKeyToken=null
// MVID: A4BA2B33-0E71-44B0-9838-A6C1CD0C2B15
// Assembly location: C:\Temp\Delfin.Controls.dll

using Delfin.Entities;
using Delfin.ServiceContracts;
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
  public class CuentaBancaria : TextBoxAyuda
  {
    public string Title;
    private IContainer components;

    public short EMPR_Codigo { get; set; }

    public string Usuario { get; set; }

    private IDelfinServices Client { get; set; }

    public CuentaBancaria.TipoAyuda TAyuda { get; set; }

    public CuentasBancarias SelectedItem
    {
      get
      {
        if (this.get_Value() != null && this.get_Value() is CuentasBancarias)
          return this.get_Value() as CuentasBancarias;
        return (CuentasBancarias) null;
      }
      set
      {
        if (value != null)
          this.SetValue((object) value, value.get_CUBA_NroCuenta());
        else
          this.ClearValue();
      }
    }

    public CuentaBancaria()
    {
      base.\u002Ector();
      this.InitializeComponent();
      this.Inicializar();
    }

    public CuentaBancaria(IContainer container)
    {
      base.\u002Ector();
      container.Add((IComponent) this);
      this.InitializeComponent();
      this.Inicializar();
    }

    private void Inicializar()
    {
      try
      {
        ((TextBox) this).CharacterCasing = CharacterCasing.Upper;
        ((TextBoxBase) this).MaxLength = 100;
        ((Control) this).Size = new Size(100, 21);
        this.add_AyudaClick(new EventHandler(this.CuentaBancaria_AyudaClick));
        this.add_AyudaClean(new EventHandler(this.CuentaBancaria_AyudaClean));
        this.add_AyudaValueChanged(new EventHandler(this.CuentaBancaria_AyudaValueChanged));
      }
      catch (Exception ex)
      {
      }
    }

    public void LoadControl(IUnityContainer Container, string x_title, int x_empr_codigo, string x_Usuario, CuentaBancaria.TipoAyuda x_opcion = CuentaBancaria.TipoAyuda.Normal)
    {
      try
      {
        this.Client = (IDelfinServices) UnityContainerExtensions.Resolve<IDelfinServices>(Container, new ResolverOverride[0]);
        this.EMPR_Codigo = Convert.ToInt16(x_empr_codigo);
        this.Title = x_title;
        this.TAyuda = x_opcion;
        this.Usuario = x_Usuario;
      }
      catch (Exception ex)
      {
      }
    }

    private void AyudaCuentaBancaria()
    {
      try
      {
        string text = ((Control) this).Text;
        if (this.Client == null)
          return;
        DataTable dataTable = new DataTable();
        ObservableCollection<DataAccessFilterSQL> observableCollection1 = new ObservableCollection<DataAccessFilterSQL>();
        ObservableCollection<DataAccessFilterSQL> observableCollection2 = observableCollection1;
        DataAccessFilterSQL dataAccessFilterSql1 = new DataAccessFilterSQL();
        dataAccessFilterSql1.set_FilterName("@psinEMPR_Codigo");
        dataAccessFilterSql1.set_FilterValue((object) this.EMPR_Codigo);
        dataAccessFilterSql1.set_FilterType((DataAccessFilterTypes) 2);
        dataAccessFilterSql1.set_FilterSize(2);
        DataAccessFilterSQL dataAccessFilterSql2 = dataAccessFilterSql1;
        observableCollection2.Add(dataAccessFilterSql2);
        ObservableCollection<DataAccessFilterSQL> observableCollection3 = observableCollection1;
        DataAccessFilterSQL dataAccessFilterSql3 = new DataAccessFilterSQL();
        dataAccessFilterSql3.set_FilterName("@pvchCUBA_NroCuenta");
        dataAccessFilterSql3.set_FilterValue((object) text);
        dataAccessFilterSql3.set_FilterType((DataAccessFilterTypes) 1);
        dataAccessFilterSql3.set_FilterSize(20);
        DataAccessFilterSQL dataAccessFilterSql4 = dataAccessFilterSql3;
        observableCollection3.Add(dataAccessFilterSql4);
        ObservableCollection<DataAccessFilterSQL> observableCollection4 = observableCollection1;
        DataAccessFilterSQL dataAccessFilterSql5 = new DataAccessFilterSQL();
        dataAccessFilterSql5.set_FilterName("@Usuario");
        dataAccessFilterSql5.set_FilterValue((object) this.Usuario);
        dataAccessFilterSql5.set_FilterType((DataAccessFilterTypes) 1);
        dataAccessFilterSql5.set_FilterSize(20);
        DataAccessFilterSQL dataAccessFilterSql6 = dataAccessFilterSql5;
        observableCollection4.Add(dataAccessFilterSql6);
        switch (this.TAyuda)
        {
          case CuentaBancaria.TipoAyuda.MedioVirtual:
            ObservableCollection<DataAccessFilterSQL> observableCollection5 = observableCollection1;
            DataAccessFilterSQL dataAccessFilterSql7 = new DataAccessFilterSQL();
            dataAccessFilterSql7.set_FilterName("@pbitCUBA_MedioVirtual");
            dataAccessFilterSql7.set_FilterValue((object) true);
            dataAccessFilterSql7.set_FilterType((DataAccessFilterTypes) 6);
            dataAccessFilterSql7.set_FilterSize(1);
            DataAccessFilterSQL dataAccessFilterSql8 = dataAccessFilterSql7;
            observableCollection5.Add(dataAccessFilterSql8);
            break;
          case CuentaBancaria.TipoAyuda.Detracciones:
            ObservableCollection<DataAccessFilterSQL> observableCollection6 = observableCollection1;
            DataAccessFilterSQL dataAccessFilterSql9 = new DataAccessFilterSQL();
            dataAccessFilterSql9.set_FilterName("@pbitCUBA_InscritoSOL");
            dataAccessFilterSql9.set_FilterValue((object) true);
            dataAccessFilterSql9.set_FilterType((DataAccessFilterTypes) 6);
            dataAccessFilterSql9.set_FilterSize(1);
            DataAccessFilterSQL dataAccessFilterSql10 = dataAccessFilterSql9;
            observableCollection6.Add(dataAccessFilterSql10);
            break;
        }
        DataTable cuentasBancarias = this.Client.GetDTCuentasBancarias("CAJ_CUBASS_Ayuda", observableCollection1);
        if (cuentasBancarias.Rows.Count == 0)
        {
          int num1 = (int) Dialogos.MostrarMensajeInformacion(this.Title, "No se encontraron coincidencias.", (Dialogos.Boton) 0);
        }
        else if (cuentasBancarias.Rows.Count == 1)
        {
          if (cuentasBancarias.Rows[0]["CUBA_Codigo"] != DBNull.Value)
            this.SetCuentaBancaria(this.EMPR_Codigo, cuentasBancarias.Rows[0]["CUBA_Codigo"].ToString());
          else
            this.ClearCuentaBancaria();
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
          columnaAyuda1.set_ColumnName("CUBA_NroCuenta");
          columnaAyuda1.set_ColumnCaption("Nro. Cuenta Bancaria");
          columnaAyuda1.set_Alineacion(DataGridViewContentAlignment.MiddleLeft);
          columnaAyuda1.set_Width(120);
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
          columnaAyuda4.set_ColumnName("TIPO_MND");
          columnaAyuda4.set_ColumnCaption("Moneda");
          columnaAyuda4.set_Alineacion(DataGridViewContentAlignment.MiddleCenter);
          columnaAyuda4.set_Width(50);
          columnaAyuda4.set_DataType(typeof (int));
          columnaAyuda4.set_Format((string) null);
          ColumnaAyuda columnaAyuda6 = columnaAyuda4;
          columnaAyudaList3.Add(columnaAyuda6);
          List<ColumnaAyuda> columnaAyudaList4 = columnaAyudaList1;
          ColumnaAyuda columnaAyuda7 = new ColumnaAyuda();
          ColumnaAyuda columnaAyuda8 = columnaAyuda7;
          int num7 = num6;
          int num8 = num7 + 1;
          columnaAyuda8.set_Index(num7);
          columnaAyuda7.set_ColumnName("CUBA_Descripcion");
          columnaAyuda7.set_ColumnCaption("Descripción");
          columnaAyuda7.set_Alineacion(DataGridViewContentAlignment.MiddleLeft);
          columnaAyuda7.set_Width(200);
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
          columnaAyuda10.set_ColumnName("TIPO_BCO");
          columnaAyuda10.set_ColumnCaption("Banco");
          columnaAyuda10.set_Alineacion(DataGridViewContentAlignment.MiddleLeft);
          columnaAyuda10.set_Width(150);
          columnaAyuda10.set_DataType(typeof (int));
          columnaAyuda10.set_Format((string) null);
          ColumnaAyuda columnaAyuda12 = columnaAyuda10;
          columnaAyudaList5.Add(columnaAyuda12);
          List<ColumnaAyuda> columnaAyudaList6 = columnaAyudaList1;
          ColumnaAyuda columnaAyuda13 = new ColumnaAyuda();
          ColumnaAyuda columnaAyuda14 = columnaAyuda13;
          int num11 = num10;
          int num12 = num11 + 1;
          columnaAyuda14.set_Index(num11);
          columnaAyuda13.set_ColumnName("CUBA_CtaEmprVinculada");
          columnaAyuda13.set_ColumnCaption("Cta. Vinculada");
          columnaAyuda13.set_Alineacion(DataGridViewContentAlignment.MiddleLeft);
          columnaAyuda13.set_Width(70);
          columnaAyuda13.set_DataType(typeof (string));
          columnaAyuda13.set_Format((string) null);
          ColumnaAyuda columnaAyuda15 = columnaAyuda13;
          columnaAyudaList6.Add(columnaAyuda15);
          List<ColumnaAyuda> columnaAyudaList7 = columnaAyudaList1;
          ColumnaAyuda columnaAyuda16 = new ColumnaAyuda();
          ColumnaAyuda columnaAyuda17 = columnaAyuda16;
          int num13 = num12;
          int num14 = num13 + 1;
          columnaAyuda17.set_Index(num13);
          columnaAyuda16.set_ColumnName("TipoCuenta");
          columnaAyuda16.set_ColumnCaption("Tipo de Cuenta");
          columnaAyuda16.set_Alineacion(DataGridViewContentAlignment.MiddleLeft);
          columnaAyuda16.set_Width(150);
          columnaAyuda16.set_DataType(typeof (string));
          columnaAyuda16.set_Format((string) null);
          ColumnaAyuda columnaAyuda18 = columnaAyuda16;
          columnaAyudaList7.Add(columnaAyuda18);
          List<ColumnaAyuda> columnaAyudaList8 = columnaAyudaList1;
          ColumnaAyuda columnaAyuda19 = new ColumnaAyuda();
          ColumnaAyuda columnaAyuda20 = columnaAyuda19;
          int num15 = num14;
          int num16 = num15 + 1;
          columnaAyuda20.set_Index(num15);
          columnaAyuda19.set_ColumnName("Chequera");
          columnaAyuda19.set_ColumnCaption("Chequera");
          columnaAyuda19.set_Alineacion(DataGridViewContentAlignment.MiddleLeft);
          columnaAyuda19.set_Width(65);
          columnaAyuda19.set_DataType(typeof (string));
          columnaAyuda19.set_Format((string) null);
          ColumnaAyuda columnaAyuda21 = columnaAyuda19;
          columnaAyudaList8.Add(columnaAyuda21);
          List<ColumnaAyuda> columnaAyudaList9 = columnaAyudaList1;
          ColumnaAyuda columnaAyuda22 = new ColumnaAyuda();
          ColumnaAyuda columnaAyuda23 = columnaAyuda22;
          int num17 = num16;
          int num18 = num17 + 1;
          columnaAyuda23.set_Index(num17);
          columnaAyuda22.set_ColumnName("CUBA_Codigo");
          columnaAyuda22.set_ColumnCaption("Código");
          columnaAyuda22.set_Alineacion(DataGridViewContentAlignment.MiddleCenter);
          columnaAyuda22.set_Width(50);
          columnaAyuda22.set_DataType(typeof (string));
          columnaAyuda22.set_Format((string) null);
          ColumnaAyuda columnaAyuda24 = columnaAyuda22;
          columnaAyudaList9.Add(columnaAyuda24);
          Ayuda ayuda = new Ayuda("Ayuda de Cuentas Bancarias", cuentasBancarias, false, (IEnumerable<ColumnaAyuda>) columnaAyudaList1, "");
          ((Form) ayuda).Size = new Size(((Control) ayuda).Width + 300, ((Control) ayuda).Height);
          ((Control) this).KeyUp -= new KeyEventHandler(((TextBoxAyuda) this).TextBoxAyuda_Key);
          if (((Form) ayuda).ShowDialog() == DialogResult.OK)
          {
            if (cuentasBancarias.Rows[0]["CUBA_Codigo"] != DBNull.Value)
              this.SetCuentaBancaria(this.EMPR_Codigo, ayuda.get_Respuesta().Rows[0]["CUBA_Codigo"].ToString());
            else
              this.ClearCuentaBancaria();
          }
          else
            this.ClearCuentaBancaria();
          ((Control) this).KeyUp += new KeyEventHandler(((TextBoxAyuda) this).TextBoxAyuda_Key);
        }
      }
      catch (Exception ex)
      {
        int num = (int) Dialogos.MostrarMensajeError(this.Title, "Ha ocurrido un error al cargar la ayuda de Cuenta Bancaria", ex);
      }
    }

    public void SetCuentaBancaria(short x_EMPR_Codigo, string x_CUBA_Codigo)
    {
      try
      {
        if (x_CUBA_Codigo != null)
        {
          if (this.Client == null)
            return;
          CuentasBancarias cuentasBancarias = this.Client.GetOneCuentasBancarias(x_EMPR_Codigo, x_CUBA_Codigo);
          if (cuentasBancarias != null)
          {
            this.SetValue((object) cuentasBancarias, cuentasBancarias.get_CUBA_NroCuenta());
            this.Focus();
            SendKeys.Send("{TAB}");
          }
          else
            this.ClearCuentaBancaria();
        }
        else
          this.ClearCuentaBancaria();
      }
      catch (Exception ex)
      {
        throw;
      }
    }

    public void SetCuentaBancaria(CuentasBancarias x_CuentaBancaria)
    {
      try
      {
        if (x_CuentaBancaria != null)
        {
          CuentasBancarias cuentasBancarias = x_CuentaBancaria;
          if (cuentasBancarias != null)
          {
            this.SetValue((object) cuentasBancarias, cuentasBancarias.get_CUBA_NroCuenta());
            this.Focus();
            SendKeys.Send("{TAB}");
          }
          else
            this.ClearCuentaBancaria();
        }
        else
          this.ClearCuentaBancaria();
      }
      catch (Exception ex)
      {
      }
    }

    public void ClearCuentaBancaria()
    {
      try
      {
        this.ClearValue();
      }
      catch (Exception ex)
      {
      }
    }

    public event EventHandler SelectedItemCuentaBancariaChanged;

    private void CuentaBancaria_AyudaClean(object sender, EventArgs e)
    {
      try
      {
        this.ClearCuentaBancaria();
      }
      catch (Exception ex)
      {
      }
    }

    private void CuentaBancaria_AyudaClick(object sender, EventArgs e)
    {
      try
      {
        this.AyudaCuentaBancaria();
      }
      catch (Exception ex)
      {
      }
    }

    private void CuentaBancaria_AyudaValueChanged(object sender, EventArgs e)
    {
      if (this.SelectedItemCuentaBancariaChanged == null)
        return;
      this.SelectedItemCuentaBancariaChanged(this.get_Value(), EventArgs.Empty);
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
      MedioVirtual,
      Detracciones,
    }
  }
}
