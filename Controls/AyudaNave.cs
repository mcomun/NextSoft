// Decompiled with JetBrains decompiler
// Type: Delfin.Controls.AyudaNave
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
  public class AyudaNave : TextBoxAyuda
  {
    public string Title;
    private IDelfinServices Client;
    private IContainer components;

    public AyudaNave()
    {
      base.\u002Ector();
      this.InitializeComponent();
    }

    public void LoadControl(IUnityContainer ContainerService)
    {
      this.Client = (IDelfinServices) UnityContainerExtensions.Resolve<DelfinServicesProxy>(ContainerService, new ResolverOverride[0]);
      this.add_AyudaClick(new EventHandler(this.AyudaNave_AyudaClick));
    }

    public Nave SelectedItem { get; set; }

    private void AyudaNaveValue()
    {
      try
      {
        DataTable dataTable = new DataTable();
        ObservableCollection<DataAccessFilterSQL> observableCollection1 = new ObservableCollection<DataAccessFilterSQL>();
        ObservableCollection<DataAccessFilterSQL> observableCollection2 = observableCollection1;
        DataAccessFilterSQL dataAccessFilterSql1 = new DataAccessFilterSQL();
        dataAccessFilterSql1.set_FilterName("@pvchNAVE_Nombre");
        dataAccessFilterSql1.set_FilterValue((object) ((Control) this).Text);
        dataAccessFilterSql1.set_FilterType((DataAccessFilterTypes) 1);
        dataAccessFilterSql1.set_FilterSize(50);
        DataAccessFilterSQL dataAccessFilterSql2 = dataAccessFilterSql1;
        observableCollection2.Add(dataAccessFilterSql2);
        DataTable allNaveByFilters = this.Client.GetAllNaveByFilters("COM_NAVESS_TodosByAyuda", observableCollection1);
        if (allNaveByFilters.Rows.Count == 0)
        {
          int num = (int) Dialogos.MostrarMensajeInformacion(this.Title, "No se encontraron coincidencias.", (Dialogos.Boton) 0);
        }
        else if (allNaveByFilters.Rows.Count == 1)
        {
          short result;
          if (short.TryParse(allNaveByFilters.Rows[0]["NAVE_Codigo"].ToString(), out result))
          {
            this.SetValue(result);
          }
          else
          {
            this.SelectedItem = (Nave) null;
            this.ClearValue();
          }
        }
        else
        {
          List<ColumnaAyuda> columnaAyudaList1 = new List<ColumnaAyuda>();
          List<ColumnaAyuda> columnaAyudaList2 = columnaAyudaList1;
          ColumnaAyuda columnaAyuda1 = new ColumnaAyuda();
          columnaAyuda1.set_Index(0);
          columnaAyuda1.set_ColumnName("NAVE_Nombre");
          columnaAyuda1.set_ColumnCaption("Nombre");
          columnaAyuda1.set_Alineacion(DataGridViewContentAlignment.MiddleLeft);
          columnaAyuda1.set_Width(250);
          columnaAyuda1.set_DataType(typeof (string));
          columnaAyuda1.set_Format((string) null);
          ColumnaAyuda columnaAyuda2 = columnaAyuda1;
          columnaAyudaList2.Add(columnaAyuda2);
          List<ColumnaAyuda> columnaAyudaList3 = columnaAyudaList1;
          ColumnaAyuda columnaAyuda3 = new ColumnaAyuda();
          columnaAyuda3.set_Index(1);
          columnaAyuda3.set_ColumnName("NAVE_Codigo");
          columnaAyuda3.set_ColumnCaption("Código");
          columnaAyuda3.set_Alineacion(DataGridViewContentAlignment.MiddleRight);
          columnaAyuda3.set_Width(100);
          columnaAyuda3.set_DataType(typeof (int));
          columnaAyuda3.set_Format((string) null);
          ColumnaAyuda columnaAyuda4 = columnaAyuda3;
          columnaAyudaList3.Add(columnaAyuda4);
          Ayuda ayuda = new Ayuda(this.Title, allNaveByFilters, false, (IEnumerable<ColumnaAyuda>) columnaAyudaList1, "");
          ((Control) this).KeyUp -= new KeyEventHandler(((TextBoxAyuda) this).TextBoxAyuda_Key);
          if (((Form) ayuda).ShowDialog() == DialogResult.OK)
          {
            short result;
            if (short.TryParse(ayuda.get_Respuesta().Rows[0]["NAVE_Codigo"].ToString(), out result))
            {
              this.SetValue(result);
            }
            else
            {
              this.SelectedItem = (Nave) null;
              this.ClearValue();
            }
          }
          else
          {
            this.SelectedItem = (Nave) null;
            this.ClearValue();
          }
          ((Control) this).KeyUp += new KeyEventHandler(((TextBoxAyuda) this).TextBoxAyuda_Key);
        }
      }
      catch (Exception ex)
      {
        int num = (int) Dialogos.MostrarMensajeError(this.Title, "Ha ocurrido un error al cargar la ayuda de Agente", ex);
      }
    }

    public void SetValue(short x_NAVE_Codigo)
    {
      try
      {
        this.SelectedItem = this.Client.GetOneNave(x_NAVE_Codigo);
        if (this.SelectedItem != null)
        {
          this.SetValue((object) this.SelectedItem, this.SelectedItem.get_NAVE_Nombre());
          this.Focus();
          SendKeys.Send("{TAB}");
        }
        else
        {
          this.SelectedItem = (Nave) null;
          this.ClearValue();
        }
      }
      catch (Exception ex)
      {
      }
    }

    private void AyudaNave_AyudaClick(object sender, EventArgs e)
    {
      this.AyudaNaveValue();
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
