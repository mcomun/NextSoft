// Decompiled with JetBrains decompiler
// Type: Delfin.Controls.AyudaServicio
// Assembly: Delfin.Controls, Version=3.0.1.3, Culture=neutral, PublicKeyToken=null
// MVID: A4BA2B33-0E71-44B0-9838-A6C1CD0C2B15
// Assembly location: C:\Temp\Delfin.Controls.dll

using Delfin.Entities;
using Delfin.ServiceContracts;
using Delfin.ServiceProxy;
using Infrastructure.Aspect.DataAccess;
using Infrastructure.WinForms.Controls;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;

namespace Delfin.Controls
{
  public class AyudaServicio : TextBoxAyuda
  {
    public string Title;
    private AyudaServicio.TipoAyuda m_tipoAyudaServicio;
    private IDelfinServices Client;
    private IContainer components;

    public AyudaServicio()
    {
      base.\u002Ector();
      this.InitializeComponent();
    }

    public void LoadControl(IUnityContainer ContainerService)
    {
      this.Client = (IDelfinServices) UnityContainerExtensions.Resolve<DelfinServicesProxy>(ContainerService, new ResolverOverride[0]);
      this.add_AyudaClick(new EventHandler(this.AyudaNave_AyudaClick));
    }

    public Servicio SelectedServicio
    {
      get
      {
        if (this.get_Value() != null)
          return this.get_Value() as Servicio;
        return (Servicio) null;
      }
    }

    public AyudaServicio.TipoAyuda TipoAyudaServicio
    {
      get
      {
        return this.m_tipoAyudaServicio;
      }
      set
      {
        this.m_tipoAyudaServicio = value;
        if (this.m_tipoAyudaServicio == AyudaServicio.TipoAyuda.Codigo)
          this.set_Tipo((TextBoxAyuda.TipoTextBoxAyuda) 0);
        else
          this.set_Tipo((TextBoxAyuda.TipoTextBoxAyuda) 1);
      }
    }

    private void AyudaServicioDialog()
    {
      try
      {
        DataTable dataTable = new DataTable();
        ObservableCollection<DataAccessFilterSQL> observableCollection1 = new ObservableCollection<DataAccessFilterSQL>();
        if (this.TipoAyudaServicio == AyudaServicio.TipoAyuda.Codigo)
        {
          int result;
          if (int.TryParse(((Control) this).Text, out result))
          {
            ObservableCollection<DataAccessFilterSQL> observableCollection2 = observableCollection1;
            DataAccessFilterSQL dataAccessFilterSql1 = new DataAccessFilterSQL();
            dataAccessFilterSql1.set_FilterName("@pintSERV_Codigo");
            dataAccessFilterSql1.set_FilterValue((object) result);
            dataAccessFilterSql1.set_FilterType((DataAccessFilterTypes) 3);
            dataAccessFilterSql1.set_FilterSize(4);
            DataAccessFilterSQL dataAccessFilterSql2 = dataAccessFilterSql1;
            observableCollection2.Add(dataAccessFilterSql2);
            ObservableCollection<DataAccessFilterSQL> observableCollection3 = observableCollection1;
            DataAccessFilterSQL dataAccessFilterSql3 = new DataAccessFilterSQL();
            dataAccessFilterSql3.set_FilterName("@pvchSERV_Nombre_SPA");
            dataAccessFilterSql3.set_FilterValue((object) null);
            dataAccessFilterSql3.set_FilterType((DataAccessFilterTypes) 1);
            dataAccessFilterSql3.set_FilterSize(100);
            DataAccessFilterSQL dataAccessFilterSql4 = dataAccessFilterSql3;
            observableCollection3.Add(dataAccessFilterSql4);
          }
          else
          {
            ObservableCollection<DataAccessFilterSQL> observableCollection2 = observableCollection1;
            DataAccessFilterSQL dataAccessFilterSql1 = new DataAccessFilterSQL();
            dataAccessFilterSql1.set_FilterName("@pintSERV_Codigo");
            dataAccessFilterSql1.set_FilterValue((object) null);
            dataAccessFilterSql1.set_FilterType((DataAccessFilterTypes) 3);
            dataAccessFilterSql1.set_FilterSize(4);
            DataAccessFilterSQL dataAccessFilterSql2 = dataAccessFilterSql1;
            observableCollection2.Add(dataAccessFilterSql2);
            ObservableCollection<DataAccessFilterSQL> observableCollection3 = observableCollection1;
            DataAccessFilterSQL dataAccessFilterSql3 = new DataAccessFilterSQL();
            dataAccessFilterSql3.set_FilterName("@pvchSERV_Nombre_SPA");
            dataAccessFilterSql3.set_FilterValue((object) null);
            dataAccessFilterSql3.set_FilterType((DataAccessFilterTypes) 1);
            dataAccessFilterSql3.set_FilterSize(100);
            DataAccessFilterSQL dataAccessFilterSql4 = dataAccessFilterSql3;
            observableCollection3.Add(dataAccessFilterSql4);
          }
        }
        else
        {
          ObservableCollection<DataAccessFilterSQL> observableCollection2 = observableCollection1;
          DataAccessFilterSQL dataAccessFilterSql1 = new DataAccessFilterSQL();
          dataAccessFilterSql1.set_FilterName("@pintSERV_Codigo");
          dataAccessFilterSql1.set_FilterValue((object) null);
          dataAccessFilterSql1.set_FilterType((DataAccessFilterTypes) 3);
          dataAccessFilterSql1.set_FilterSize(4);
          DataAccessFilterSQL dataAccessFilterSql2 = dataAccessFilterSql1;
          observableCollection2.Add(dataAccessFilterSql2);
          ObservableCollection<DataAccessFilterSQL> observableCollection3 = observableCollection1;
          DataAccessFilterSQL dataAccessFilterSql3 = new DataAccessFilterSQL();
          dataAccessFilterSql3.set_FilterName("@pvchSERV_Nombre_SPA");
          dataAccessFilterSql3.set_FilterValue((object) null);
          dataAccessFilterSql3.set_FilterType((DataAccessFilterTypes) 1);
          dataAccessFilterSql3.set_FilterSize(100);
          DataAccessFilterSQL dataAccessFilterSql4 = dataAccessFilterSql3;
          observableCollection3.Add(dataAccessFilterSql4);
        }
        DataTable serviciosDtByFilters = this.Client.GetAllServiciosDTByFilters("COM_SERVSS_Ayuda", observableCollection1);
        if (serviciosDtByFilters.Rows.Count == 0)
        {
          int num = (int) Dialogos.MostrarMensajeInformacion(this.Title, "No se encontraron coincidencias.", (Dialogos.Boton) 0);
        }
        else if (serviciosDtByFilters.Rows.Count == 1)
        {
          int result;
          if (int.TryParse(serviciosDtByFilters.Rows[0]["SERV_Codigo"].ToString(), out result))
            this.LoadServicio(result);
          else
            this.ClearValue();
        }
        else
        {
          List<ColumnaAyuda> columnaAyudaList1 = new List<ColumnaAyuda>();
          List<ColumnaAyuda> columnaAyudaList2 = columnaAyudaList1;
          ColumnaAyuda columnaAyuda1 = new ColumnaAyuda();
          columnaAyuda1.set_Index(0);
          columnaAyuda1.set_ColumnName("SERV_Codigo");
          columnaAyuda1.set_ColumnCaption("Código");
          columnaAyuda1.set_Alineacion(DataGridViewContentAlignment.MiddleRight);
          columnaAyuda1.set_Width(50);
          columnaAyuda1.set_DataType(typeof (int));
          columnaAyuda1.set_Format((string) null);
          ColumnaAyuda columnaAyuda2 = columnaAyuda1;
          columnaAyudaList2.Add(columnaAyuda2);
          List<ColumnaAyuda> columnaAyudaList3 = columnaAyudaList1;
          ColumnaAyuda columnaAyuda3 = new ColumnaAyuda();
          columnaAyuda3.set_Index(1);
          columnaAyuda3.set_ColumnName("SERV_Nombre_SPA");
          columnaAyuda3.set_ColumnCaption("Nombre");
          columnaAyuda3.set_Alineacion(DataGridViewContentAlignment.MiddleLeft);
          columnaAyuda3.set_Width(100);
          columnaAyuda3.set_DataType(typeof (string));
          columnaAyuda3.set_Format((string) null);
          ColumnaAyuda columnaAyuda4 = columnaAyuda3;
          columnaAyudaList3.Add(columnaAyuda4);
          List<ColumnaAyuda> columnaAyudaList4 = columnaAyudaList1;
          ColumnaAyuda columnaAyuda5 = new ColumnaAyuda();
          columnaAyuda5.set_Index(2);
          columnaAyuda5.set_ColumnName("CONS_DescRGM");
          columnaAyuda5.set_ColumnCaption("Régimen");
          columnaAyuda5.set_Alineacion(DataGridViewContentAlignment.MiddleLeft);
          columnaAyuda5.set_Width(150);
          columnaAyuda5.set_DataType(typeof (string));
          columnaAyuda5.set_Format((string) null);
          ColumnaAyuda columnaAyuda6 = columnaAyuda5;
          columnaAyudaList4.Add(columnaAyuda6);
          List<ColumnaAyuda> columnaAyudaList5 = columnaAyudaList1;
          ColumnaAyuda columnaAyuda7 = new ColumnaAyuda();
          columnaAyuda7.set_Index(3);
          columnaAyuda7.set_ColumnName("CONS_DescVIA");
          columnaAyuda7.set_ColumnCaption("Vía");
          columnaAyuda7.set_Alineacion(DataGridViewContentAlignment.MiddleLeft);
          columnaAyuda7.set_Width(120);
          columnaAyuda7.set_DataType(typeof (string));
          columnaAyuda7.set_Format((string) null);
          ColumnaAyuda columnaAyuda8 = columnaAyuda7;
          columnaAyudaList5.Add(columnaAyuda8);
          List<ColumnaAyuda> columnaAyudaList6 = columnaAyudaList1;
          ColumnaAyuda columnaAyuda9 = new ColumnaAyuda();
          columnaAyuda9.set_Index(4);
          columnaAyuda9.set_ColumnName("CONS_DescLNG");
          columnaAyuda9.set_ColumnCaption("Línea Negocio");
          columnaAyuda9.set_Alineacion(DataGridViewContentAlignment.MiddleLeft);
          columnaAyuda9.set_Width(120);
          columnaAyuda9.set_DataType(typeof (string));
          columnaAyuda9.set_Format((string) null);
          ColumnaAyuda columnaAyuda10 = columnaAyuda9;
          columnaAyudaList6.Add(columnaAyuda10);
          Ayuda ayuda = new Ayuda(this.Title, serviciosDtByFilters, false, (IEnumerable<ColumnaAyuda>) columnaAyudaList1, "");
          ((Control) this).KeyUp -= new KeyEventHandler(((TextBoxAyuda) this).TextBoxAyuda_Key);
          if (((Form) ayuda).ShowDialog() == DialogResult.OK)
          {
            int result;
            if (int.TryParse(ayuda.get_Respuesta().Rows[0]["SERV_Codigo"].ToString(), out result))
              this.LoadServicio(result);
            else
              this.ClearValue();
          }
          else
            this.ClearValue();
          ((Control) this).KeyUp += new KeyEventHandler(((TextBoxAyuda) this).TextBoxAyuda_Key);
        }
      }
      catch (Exception ex)
      {
        int num = (int) Dialogos.MostrarMensajeError(this.Title, "Ha ocurrido un error al cargar la ayuda de Agente", ex);
      }
    }

    public void LoadServicio(int x_SERV_Codigo)
    {
      try
      {
        Servicio oneServicio = this.Client.GetOneServicio(x_SERV_Codigo);
        if (oneServicio != null)
        {
          if (this.TipoAyudaServicio == AyudaServicio.TipoAyuda.Codigo)
            this.SetValue((object) oneServicio, oneServicio.get_SERV_Codigo().ToString());
          else
            this.SetValue((object) oneServicio, oneServicio.get_SERV_Nombre_SPA());
          this.Focus();
          SendKeys.Send("{TAB}");
        }
        else
          this.ClearValue();
      }
      catch (Exception ex)
      {
      }
    }

    private void AyudaNave_AyudaClick(object sender, EventArgs e)
    {
      this.AyudaServicioDialog();
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
      Codigo = 1,
      Nombre = 2,
    }
  }
}
