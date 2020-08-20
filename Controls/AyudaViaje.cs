// Decompiled with JetBrains decompiler
// Type: Delfin.Controls.AyudaViaje
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
  public class AyudaViaje : TextBoxAyuda
  {
    public string Title;
    private AyudaViaje.TipoAyuda m_tipoAyudaNaveViaje;
    private IDelfinServices Client;
    private IContainer components;

    public short EMPR_Codigo { get; set; }

    public short SUCR_Codigo { get; set; }

    public AyudaViaje()
    {
      base.\u002Ector();
      this.InitializeComponent();
    }

    public void LoadControl(IUnityContainer ContainerService)
    {
      this.Client = (IDelfinServices) UnityContainerExtensions.Resolve<DelfinServicesProxy>(ContainerService, new ResolverOverride[0]);
      this.add_AyudaClick(new EventHandler(this.AyudaNave_AyudaClick));
    }

    public void LoadControl(IUnityContainer ContainerService, AyudaViaje.TipoAyuda x_opcion)
    {
      this.Client = (IDelfinServices) UnityContainerExtensions.Resolve<DelfinServicesProxy>(ContainerService, new ResolverOverride[0]);
      this.TipoAyudaNaveViaje = x_opcion;
      this.add_AyudaClick(new EventHandler(this.AyudaNave_AyudaClick));
    }

    public AyudaViaje.TipoAyuda TipoAyudaNaveViaje
    {
      get
      {
        return this.m_tipoAyudaNaveViaje;
      }
      set
      {
        this.m_tipoAyudaNaveViaje = value;
        if (this.m_tipoAyudaNaveViaje == AyudaViaje.TipoAyuda.Codigo)
          this.set_Tipo((TextBoxAyuda.TipoTextBoxAyuda) 0);
        else
          this.set_Tipo((TextBoxAyuda.TipoTextBoxAyuda) 1);
      }
    }

    public int? ENTC_CodTranportista { get; set; }

    public DateTime? FechaDesde { get; set; }

    private void AyudaNaveViajeValue()
    {
      try
      {
        DataTable dataTable = new DataTable();
        ObservableCollection<DataAccessFilterSQL> observableCollection1 = new ObservableCollection<DataAccessFilterSQL>();
        if (this.TipoAyudaNaveViaje == AyudaViaje.TipoAyuda.Codigo)
        {
          int result;
          if (int.TryParse(((Control) this).Text, out result))
          {
            ObservableCollection<DataAccessFilterSQL> observableCollection2 = observableCollection1;
            DataAccessFilterSQL dataAccessFilterSql1 = new DataAccessFilterSQL();
            dataAccessFilterSql1.set_FilterName("pintNVIA_CODIGO");
            dataAccessFilterSql1.set_FilterValue((object) result);
            dataAccessFilterSql1.set_FilterType((DataAccessFilterTypes) 3);
            dataAccessFilterSql1.set_FilterSize(4);
            DataAccessFilterSQL dataAccessFilterSql2 = dataAccessFilterSql1;
            observableCollection2.Add(dataAccessFilterSql2);
          }
          else
          {
            ObservableCollection<DataAccessFilterSQL> observableCollection2 = observableCollection1;
            DataAccessFilterSQL dataAccessFilterSql1 = new DataAccessFilterSQL();
            dataAccessFilterSql1.set_FilterName("pintNVIA_CODIGO");
            dataAccessFilterSql1.set_FilterValue((object) null);
            dataAccessFilterSql1.set_FilterType((DataAccessFilterTypes) 3);
            dataAccessFilterSql1.set_FilterSize(4);
            DataAccessFilterSQL dataAccessFilterSql2 = dataAccessFilterSql1;
            observableCollection2.Add(dataAccessFilterSql2);
          }
          ObservableCollection<DataAccessFilterSQL> observableCollection3 = observableCollection1;
          DataAccessFilterSQL dataAccessFilterSql3 = new DataAccessFilterSQL();
          dataAccessFilterSql3.set_FilterName("pvchNVIA_NROVIAJE");
          dataAccessFilterSql3.set_FilterValue((object) null);
          dataAccessFilterSql3.set_FilterType((DataAccessFilterTypes) 1);
          dataAccessFilterSql3.set_FilterSize(50);
          DataAccessFilterSQL dataAccessFilterSql4 = dataAccessFilterSql3;
          observableCollection3.Add(dataAccessFilterSql4);
        }
        else
        {
          ObservableCollection<DataAccessFilterSQL> observableCollection2 = observableCollection1;
          DataAccessFilterSQL dataAccessFilterSql1 = new DataAccessFilterSQL();
          dataAccessFilterSql1.set_FilterName("pintNVIA_CODIGO");
          dataAccessFilterSql1.set_FilterValue((object) null);
          dataAccessFilterSql1.set_FilterType((DataAccessFilterTypes) 3);
          dataAccessFilterSql1.set_FilterSize(4);
          DataAccessFilterSQL dataAccessFilterSql2 = dataAccessFilterSql1;
          observableCollection2.Add(dataAccessFilterSql2);
          ObservableCollection<DataAccessFilterSQL> observableCollection3 = observableCollection1;
          DataAccessFilterSQL dataAccessFilterSql3 = new DataAccessFilterSQL();
          dataAccessFilterSql3.set_FilterName("pvchNVIA_NROVIAJE");
          dataAccessFilterSql3.set_FilterValue((object) ((Control) this).Text);
          dataAccessFilterSql3.set_FilterType((DataAccessFilterTypes) 1);
          dataAccessFilterSql3.set_FilterSize(50);
          DataAccessFilterSQL dataAccessFilterSql4 = dataAccessFilterSql3;
          observableCollection3.Add(dataAccessFilterSql4);
        }
        if (this.ENTC_CodTranportista.HasValue)
        {
          ObservableCollection<DataAccessFilterSQL> observableCollection2 = observableCollection1;
          DataAccessFilterSQL dataAccessFilterSql1 = new DataAccessFilterSQL();
          dataAccessFilterSql1.set_FilterName("pintENTC_CodTransportista");
          dataAccessFilterSql1.set_FilterValue((object) this.ENTC_CodTranportista.Value);
          dataAccessFilterSql1.set_FilterType((DataAccessFilterTypes) 3);
          dataAccessFilterSql1.set_FilterSize(4);
          DataAccessFilterSQL dataAccessFilterSql2 = dataAccessFilterSql1;
          observableCollection2.Add(dataAccessFilterSql2);
          ObservableCollection<DataAccessFilterSQL> observableCollection3 = observableCollection1;
          DataAccessFilterSQL dataAccessFilterSql3 = new DataAccessFilterSQL();
          dataAccessFilterSql3.set_FilterName("NVIA_FecETA_IMPO_ETD_EXPO ");
          dataAccessFilterSql3.set_FilterValue((object) this.FechaDesde);
          dataAccessFilterSql3.set_FilterType((DataAccessFilterTypes) 5);
          dataAccessFilterSql3.set_FilterSize(8);
          DataAccessFilterSQL dataAccessFilterSql4 = dataAccessFilterSql3;
          observableCollection3.Add(dataAccessFilterSql4);
        }
        DataTable naveViajeByFilters = this.Client.GetAllNaveViajeByFilters("COM_NVIASS_TodosByAyuda", observableCollection1);
        if (naveViajeByFilters.Rows.Count == 0)
        {
          int num1 = (int) Dialogos.MostrarMensajeInformacion(this.Title, "No se encontraron coincidencias.", (Dialogos.Boton) 0);
        }
        else if (naveViajeByFilters.Rows.Count == 1)
        {
          int result;
          if (int.TryParse(naveViajeByFilters.Rows[0]["NVIA_Codigo"].ToString(), out result))
            this.LoadNaveViaje(result);
          else
            this.ClearValue();
        }
        else
        {
          List<ColumnaAyuda> columnaAyudaList1 = new List<ColumnaAyuda>();
          int num2 = 0;
          List<ColumnaAyuda> columnaAyudaList2 = columnaAyudaList1;
          ColumnaAyuda columnaAyuda1 = new ColumnaAyuda();
          columnaAyuda1.set_Index(num2);
          columnaAyuda1.set_ColumnName("NAVE_Nombre");
          columnaAyuda1.set_ColumnCaption("Nave");
          columnaAyuda1.set_Alineacion(DataGridViewContentAlignment.MiddleLeft);
          columnaAyuda1.set_Width(150);
          columnaAyuda1.set_DataType(typeof (string));
          columnaAyuda1.set_Format((string) null);
          ColumnaAyuda columnaAyuda2 = columnaAyuda1;
          columnaAyudaList2.Add(columnaAyuda2);
          int num3 = num2 + 1;
          List<ColumnaAyuda> columnaAyudaList3 = columnaAyudaList1;
          ColumnaAyuda columnaAyuda3 = new ColumnaAyuda();
          columnaAyuda3.set_Index(num3);
          columnaAyuda3.set_ColumnName("NVIA_NroViaje");
          columnaAyuda3.set_ColumnCaption("Nro. Viaje");
          columnaAyuda3.set_Alineacion(DataGridViewContentAlignment.MiddleLeft);
          columnaAyuda3.set_Width(110);
          columnaAyuda3.set_DataType(typeof (string));
          columnaAyuda3.set_Format((string) null);
          ColumnaAyuda columnaAyuda4 = columnaAyuda3;
          columnaAyudaList3.Add(columnaAyuda4);
          int num4 = num3 + 1;
          List<ColumnaAyuda> columnaAyudaList4 = columnaAyudaList1;
          ColumnaAyuda columnaAyuda5 = new ColumnaAyuda();
          columnaAyuda5.set_Index(num4);
          columnaAyuda5.set_ColumnName("NVIA_FecETA_IMPO_ETD_EXPO");
          columnaAyuda5.set_ColumnCaption("ETA\\ETD");
          columnaAyuda5.set_Alineacion(DataGridViewContentAlignment.MiddleLeft);
          columnaAyuda5.set_Width(80);
          columnaAyuda5.set_DataType(typeof (DateTime));
          columnaAyuda5.set_Format("dd/MM/yyyy");
          ColumnaAyuda columnaAyuda6 = columnaAyuda5;
          columnaAyudaList4.Add(columnaAyuda6);
          int num5 = num4 + 1;
          List<ColumnaAyuda> columnaAyudaList5 = columnaAyudaList1;
          ColumnaAyuda columnaAyuda7 = new ColumnaAyuda();
          columnaAyuda7.set_Index(num5);
          columnaAyuda7.set_ColumnName("CONS_DescRGM");
          columnaAyuda7.set_ColumnCaption("Regimen");
          columnaAyuda7.set_Alineacion(DataGridViewContentAlignment.MiddleLeft);
          columnaAyuda7.set_Width(100);
          columnaAyuda7.set_DataType(typeof (string));
          columnaAyuda7.set_Format((string) null);
          ColumnaAyuda columnaAyuda8 = columnaAyuda7;
          columnaAyudaList5.Add(columnaAyuda8);
          int num6 = num5 + 1;
          List<ColumnaAyuda> columnaAyudaList6 = columnaAyudaList1;
          ColumnaAyuda columnaAyuda9 = new ColumnaAyuda();
          columnaAyuda9.set_Index(num6);
          columnaAyuda9.set_ColumnName("CONS_DescVIA");
          columnaAyuda9.set_ColumnCaption("Vía");
          columnaAyuda9.set_Alineacion(DataGridViewContentAlignment.MiddleLeft);
          columnaAyuda9.set_Width(70);
          columnaAyuda9.set_DataType(typeof (string));
          columnaAyuda9.set_Format((string) null);
          ColumnaAyuda columnaAyuda10 = columnaAyuda9;
          columnaAyudaList6.Add(columnaAyuda10);
          int num7 = num6 + 1;
          List<ColumnaAyuda> columnaAyudaList7 = columnaAyudaList1;
          ColumnaAyuda columnaAyuda11 = new ColumnaAyuda();
          columnaAyuda11.set_Index(num7);
          columnaAyuda11.set_ColumnName("Transportista");
          columnaAyuda11.set_ColumnCaption("Transportista");
          columnaAyuda11.set_Alineacion(DataGridViewContentAlignment.MiddleLeft);
          columnaAyuda11.set_Width(150);
          columnaAyuda11.set_DataType(typeof (string));
          columnaAyuda11.set_Format((string) null);
          ColumnaAyuda columnaAyuda12 = columnaAyuda11;
          columnaAyudaList7.Add(columnaAyuda12);
          int num8 = num7 + 1;
          List<ColumnaAyuda> columnaAyudaList8 = columnaAyudaList1;
          ColumnaAyuda columnaAyuda13 = new ColumnaAyuda();
          columnaAyuda13.set_Index(num8);
          columnaAyuda13.set_ColumnName("NVIA_Codigo");
          columnaAyuda13.set_ColumnCaption("Código");
          columnaAyuda13.set_Alineacion(DataGridViewContentAlignment.MiddleRight);
          columnaAyuda13.set_Width(50);
          columnaAyuda13.set_DataType(typeof (int));
          columnaAyuda13.set_Format((string) null);
          ColumnaAyuda columnaAyuda14 = columnaAyuda13;
          columnaAyudaList8.Add(columnaAyuda14);
          int num9 = num8 + 1;
          Ayuda ayuda = new Ayuda(this.Title, naveViajeByFilters, false, (IEnumerable<ColumnaAyuda>) columnaAyudaList1, "");
          ((Control) ayuda).Width = Convert.ToInt32((double) ((Control) ayuda).Width * 1.8);
          ((Control) this).KeyUp -= new KeyEventHandler(((TextBoxAyuda) this).TextBoxAyuda_Key);
          if (((Form) ayuda).ShowDialog() == DialogResult.OK)
          {
            int result;
            if (int.TryParse(ayuda.get_Respuesta().Rows[0]["NVIA_Codigo"].ToString(), out result))
              this.LoadNaveViaje(result);
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

    public void LoadNaveViaje(int x_NAVE_Codigo)
    {
      try
      {
        NaveViaje oneNaveViaje = this.Client.GetOneNaveViaje(x_NAVE_Codigo);
        if (oneNaveViaje != null)
        {
          if (this.TipoAyudaNaveViaje == AyudaViaje.TipoAyuda.Codigo)
            this.SetValue((object) oneNaveViaje, oneNaveViaje.get_NVIA_Codigo().ToString());
          else
            this.SetValue((object) oneNaveViaje, oneNaveViaje.get_NVIA_NroViaje());
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
      this.AyudaNaveViajeValue();
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
      NroViaje = 2,
    }
  }
}
