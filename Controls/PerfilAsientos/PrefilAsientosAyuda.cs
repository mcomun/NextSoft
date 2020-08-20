// Decompiled with JetBrains decompiler
// Type: Delfin.Controls.PerfilAsientos.PrefilAsientosAyuda
// Assembly: Delfin.Controls, Version=3.0.1.3, Culture=neutral, PublicKeyToken=null
// MVID: A4BA2B33-0E71-44B0-9838-A6C1CD0C2B15
// Assembly location: C:\Temp\Delfin.Controls.dll

using Delfin.Entities;
using Delfin.ServiceContracts;
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

namespace Delfin.Controls.PerfilAsientos
{
  public class PrefilAsientosAyuda : TextBoxAyuda
  {
    public string Title;
    private IContainer components;

    private IDelfinServices Client { get; set; }

    public CabPerfilAsientos SelectedItem
    {
      get
      {
        if (this.get_Value() != null && this.get_Value() is CabPerfilAsientos)
          return this.get_Value() as CabPerfilAsientos;
        return (CabPerfilAsientos) null;
      }
      set
      {
        if (value != null)
          this.SetValue((object) value, value.get_CABP_Desc());
        else
          this.ClearValue();
      }
    }

    public string CABP_Ano { get; set; }

    public PrefilAsientosAyuda()
    {
      //base.\u002Ector();
      this.InitializeComponent();
      this.InitializePerfilAsientos();
    }

    private void InitializePerfilAsientos()
    {
      try
      {
        ((TextBox) this).CharacterCasing = CharacterCasing.Upper;
        ((TextBoxBase) this).MaxLength = 100;
        ((Control) this).Size = new Size(100, 21);
        this.add_AyudaClick(new EventHandler(this.PerfilAsientos_AyudaClick));
        this.add_AyudaClean(new EventHandler(this.PerfilAsientos_AyudaClean));
        this.add_AyudaValueChanged(new EventHandler(this.PerfilAsientos_AyudaValueChanged));
      }
      catch (Exception ex)
      {
      }
    }

    public void LoadControl(IUnityContainer Container, string x_title)
    {
      try
      {
        this.Client = (IDelfinServices) UnityContainerExtensions.Resolve<IDelfinServices>(Container, new ResolverOverride[0]);
        this.Title = x_title;
      }
      catch (Exception ex)
      {
      }
    }

    public void AyudaEntidad()
    {
      try
      {
        string text = ((Control) this).Text;
        if (this.CABP_Ano == null)
        {
          int num1 = (int) Dialogos.MostrarMensajeInformacion(this.Title, "No se ingreso un Periodo Correcto (Año).", (Dialogos.Boton) 0);
        }
        else
        {
          if (this.Client == null)
            return;
          ObservableCollection<CabPerfilAsientos> observableCollection1 = new ObservableCollection<CabPerfilAsientos>();
          ObservableCollection<DataAccessFilterSQL> observableCollection2 = new ObservableCollection<DataAccessFilterSQL>();
          ObservableCollection<DataAccessFilterSQL> observableCollection3 = observableCollection2;
          DataAccessFilterSQL dataAccessFilterSql1 = new DataAccessFilterSQL();
          dataAccessFilterSql1.set_FilterName("@pchrCABP_Ano");
          dataAccessFilterSql1.set_FilterValue((object) this.CABP_Ano);
          dataAccessFilterSql1.set_FilterType((DataAccessFilterTypes) 0);
          dataAccessFilterSql1.set_FilterSize(4);
          DataAccessFilterSQL dataAccessFilterSql2 = dataAccessFilterSql1;
          observableCollection3.Add(dataAccessFilterSql2);
          DataTable dataTable1 = new DataTable();
          DataTable dataTable2 = IEnumerableExtensions.ToDataTable<CabPerfilAsientos>((IEnumerable<M0>) this.Client.GetAllCabPerfilAsientosFilter("CON_CABPSS_TodosAyuda", observableCollection2));
          dataTable2.DefaultView.Sort = "CABP_Desc";
          if (dataTable2.Rows.Count == 0)
          {
            int num2 = (int) Dialogos.MostrarMensajeInformacion(this.Title, "No se encontraron coincidencias.", (Dialogos.Boton) 0);
          }
          else if (dataTable2.Rows.Count == 1)
          {
            if (dataTable2.Rows[0]["CABP_Codigo"] != DBNull.Value)
              this.SetPerfilAsientos(this.CABP_Ano, dataTable2.Rows[0]["CABP_Codigo"].ToString());
            else
              this.ClearPerfilAsientos();
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
            columnaAyuda1.set_ColumnName("CABP_Ano");
            columnaAyuda1.set_ColumnCaption("Periodo");
            columnaAyuda1.set_Alineacion(DataGridViewContentAlignment.MiddleCenter);
            columnaAyuda1.set_Width(50);
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
            columnaAyuda4.set_ColumnName("CABP_Codigo");
            columnaAyuda4.set_ColumnCaption("Código");
            columnaAyuda4.set_Alineacion(DataGridViewContentAlignment.MiddleCenter);
            columnaAyuda4.set_Width(50);
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
            columnaAyuda7.set_ColumnName("CABP_Desc");
            columnaAyuda7.set_ColumnCaption("Descripción");
            columnaAyuda7.set_Alineacion(DataGridViewContentAlignment.MiddleLeft);
            columnaAyuda7.set_Width(120);
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
            columnaAyuda10.set_ColumnName("CABP_ValorRef");
            columnaAyuda10.set_ColumnCaption("Valor Referencial");
            columnaAyuda10.set_Alineacion(DataGridViewContentAlignment.MiddleRight);
            columnaAyuda10.set_Width(90);
            columnaAyuda10.set_DataType(typeof (Decimal));
            columnaAyuda10.set_Format((string) null);
            ColumnaAyuda columnaAyuda12 = columnaAyuda10;
            columnaAyudaList5.Add(columnaAyuda12);
            Ayuda ayuda = new Ayuda("Ayuda de Plantillas de Asientos", dataTable2, false, (IEnumerable<ColumnaAyuda>) columnaAyudaList1, "");
            ((Control) this).KeyUp -= new KeyEventHandler(((TextBoxAyuda) this).TextBoxAyuda_Key);
            if (((Form) ayuda).ShowDialog() == DialogResult.OK)
            {
              if (dataTable2.Rows[0]["CABP_Codigo"] != DBNull.Value)
                this.SetPerfilAsientos(this.CABP_Ano, ayuda.get_Respuesta().Rows[0]["CABP_Codigo"].ToString());
              else
                this.ClearPerfilAsientos();
            }
            else
              this.ClearPerfilAsientos();
            ((Control) this).KeyUp += new KeyEventHandler(((TextBoxAyuda) this).TextBoxAyuda_Key);
          }
        }
      }
      catch (Exception ex)
      {
        int num = (int) Dialogos.MostrarMensajeError(this.Title, "Ha ocurrido un error al cargar la ayuda de Entidad", ex);
      }
    }

    public void SetPerfilAsientos(string CABP_Ano, string CABP_Codigo)
    {
      try
      {
        if (CABP_Codigo != null)
        {
          if (this.Client == null)
            return;
          CabPerfilAsientos cabPerfilAsientos = this.Client.GetOneCabPerfilAsientos(CABP_Ano, CABP_Codigo);
          if (cabPerfilAsientos != null)
          {
            this.SetValue((object) cabPerfilAsientos, cabPerfilAsientos.get_CABP_Desc());
            this.Focus();
            SendKeys.Send("{TAB}");
          }
          else
            this.ClearPerfilAsientos();
        }
        else
          this.ClearPerfilAsientos();
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
          this.SetValue((object) item, item.get_CABP_Codigo());
          this.Focus();
          SendKeys.Send("{TAB}");
        }
        else
          this.ClearPerfilAsientos();
      }
      catch (Exception ex)
      {
      }
    }

    public void ClearPerfilAsientos()
    {
      try
      {
        this.ClearValue();
      }
      catch (Exception ex)
      {
      }
    }

    public event EventHandler SelectedItemPerfilAsientosChanged;

    private void PerfilAsientos_AyudaClean(object sender, EventArgs e)
    {
      try
      {
        this.ClearPerfilAsientos();
      }
      catch (Exception ex)
      {
      }
    }

    private void PerfilAsientos_AyudaClick(object sender, EventArgs e)
    {
      try
      {
        this.AyudaEntidad();
      }
      catch (Exception ex)
      {
      }
    }

    private void PerfilAsientos_AyudaValueChanged(object sender, EventArgs e)
    {
      if (this.SelectedItemPerfilAsientosChanged == null)
        return;
      this.SelectedItemPerfilAsientosChanged(this.get_Value(), EventArgs.Empty);
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
  }
}
