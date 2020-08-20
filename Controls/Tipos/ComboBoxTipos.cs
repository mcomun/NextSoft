// Decompiled with JetBrains decompiler
// Type: Delfin.Controls.Tipos.ComboBoxTipos
// Assembly: Delfin.Controls, Version=3.0.1.3, Culture=neutral, PublicKeyToken=null
// MVID: A4BA2B33-0E71-44B0-9838-A6C1CD0C2B15
// Assembly location: C:\Temp\Delfin.Controls.dll

using Delfin.ServiceContracts;
using Infrastructure.Aspect.BusinessEntity;
using Infrastructure.Aspect.CheckSUM;
using Infrastructure.Aspect.Collections;
using Infrastructure.Client.Services.Session;
using Infrastructure.WinFormsControls;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Delfin.Controls.Tipos
{
  public class ComboBoxTipos : ComboBox
  {
    private IContainer components;

    public ComboBoxTipos()
    {
      this.InitializeComponent();
      try
      {
        this.DropDown += new EventHandler(this.ComboBoxTipos_DropDown);
        this.DropDownStyle = ComboBoxStyle.DropDownList;
      }
      catch (Exception ex)
      {
        int num = (int) Dialogos.MostrarMensajeError(this.TiposTitulo, "Ha ocurrido un error al inicializar el formulario.", ex);
      }
    }

    public ISessionService Session { get; set; }

    public string TiposTitulo { get; set; }

    public string TiposSelectedValue
    {
      get
      {
        if (this.SelectedItem != null)
          return ((Delfin.Entities.Tipos) this.SelectedItem).get_TIPO_CodTipo();
        return (string) null;
      }
      set
      {
        if (value == null || string.IsNullOrEmpty(value))
        {
          if (this.ListTipos == null || this.ListTipos.Count <= 0)
            return;
          this.SelectedItem = (object) ((IEnumerable<Delfin.Entities.Tipos>) this.ListTipos).ElementAt<Delfin.Entities.Tipos>(0);
        }
        else
          this.SelectedItem = (object) ((IEnumerable<Delfin.Entities.Tipos>) this.DataSource).Where<Delfin.Entities.Tipos>((Func<Delfin.Entities.Tipos, bool>) (tipo => tipo.get_TIPO_CodTipo() == value)).FirstOrDefault<Delfin.Entities.Tipos>();
      }
    }

    public Delfin.Entities.Tipos TiposSelectedItem
    {
      get
      {
        if (this.SelectedItem != null && ((Delfin.Entities.Tipos) this.SelectedItem).get_TIPO_CodTipo() != null)
          return (Delfin.Entities.Tipos) this.SelectedItem;
        return (Delfin.Entities.Tipos) null;
      }
      set
      {
        this.SelectedItem = (object) value;
      }
    }

    private ObservableCollection<Delfin.Entities.Tipos> ListTipos { get; set; }

    private void ComboBoxTipos_DropDown(object sender, EventArgs e)
    {
      try
      {
        this.DropDownWidth = this.SetDropDownWidth((ComboBox) this);
      }
      catch
      {
      }
    }

    private void CargarTablaXML(string x_tipo_codtabla)
    {
      try
      {
        GenerarChekSum generarChekSum = new GenerarChekSum(Application.StartupPath, this.Session.get_UserName());
        CHKS_Tablas chksTablas1 = new CHKS_Tablas();
        chksTablas1.set_CHKS_Tabla("Tipos");
        CHKS_Tablas chksTablas2 = chksTablas1;
        DataTable dataTable = generarChekSum.CargarXML(chksTablas2);
        if (dataTable == null)
          return;
        this.ListTipos = new ObservableCollection<Delfin.Entities.Tipos>();
        foreach (DataRow row in (InternalDataCollectionBase) dataTable.Rows)
        {
          if (row["TIPO_CodTabla"].ToString().Equals(x_tipo_codtabla))
          {
            Delfin.Entities.Tipos tipos = new Delfin.Entities.Tipos();
            new BusinessEntityLoader<Delfin.Entities.Tipos>().LoadEntity(row, (object) tipos);
            this.ListTipos.Add(tipos);
          }
        }
      }
      catch (Exception ex)
      {
        throw;
      }
    }

    public void LoadControl(string x_titulo, ComboBoxTipos.OTipos x_oTipos, string x_firstElement, ListSortDirection x_sortItems)
    {
      try
      {
        if (x_oTipos == ComboBoxTipos.OTipos.TDI_contacto)
          this.ListTipos = this.getTDI_Contacto();
        switch (x_sortItems)
        {
          case ListSortDirection.Ascending:
            this.ListTipos = (ObservableCollection<Delfin.Entities.Tipos>) ObservableCollectionExtension.ToObservableCollection<Delfin.Entities.Tipos>((IEnumerable<M0>) ((IEnumerable<Delfin.Entities.Tipos>) this.ListTipos).OrderBy<Delfin.Entities.Tipos, string>((Func<Delfin.Entities.Tipos, string>) (tipo => tipo.get_TIPO_Desc1())));
            break;
          case ListSortDirection.Descending:
            this.ListTipos = (ObservableCollection<Delfin.Entities.Tipos>) ObservableCollectionExtension.ToObservableCollection<Delfin.Entities.Tipos>((IEnumerable<M0>) ((IEnumerable<Delfin.Entities.Tipos>) this.ListTipos).OrderByDescending<Delfin.Entities.Tipos, string>((Func<Delfin.Entities.Tipos, string>) (tipo => tipo.get_TIPO_Desc1())));
            break;
        }
        if (x_firstElement != null)
        {
          ObservableCollection<Delfin.Entities.Tipos> listTipos = this.ListTipos;
          int index = 0;
          Delfin.Entities.Tipos tipos1 = new Delfin.Entities.Tipos();
          tipos1.set_TIPO_Desc1(x_firstElement);
          Delfin.Entities.Tipos tipos2 = tipos1;
          listTipos.Insert(index, tipos2);
        }
        this.ValueMember = "TIPO_CodTipo";
        this.DisplayMember = "TIPO_Desc1";
        this.DataSource = (object) this.ListTipos;
        if (this.ListTipos != null && this.ListTipos.Count > 0)
          this.SelectedItem = (object) ((IEnumerable<Delfin.Entities.Tipos>) this.ListTipos).ElementAt<Delfin.Entities.Tipos>(0);
        else
          this.SelectedIndex = -1;
      }
      catch (Exception ex)
      {
        int num = (int) Dialogos.MostrarMensajeError(this.TiposTitulo, "Ha ocurrido un error al cargar los datos tipos.", ex);
      }
    }

    public void LoadControl(IUnityContainer Container, string x_titulo, string x_tipo_codtabla, string x_firstElement, ListSortDirection x_sortItems, string[] x_Tipos = null)
    {
      try
      {
        IDelfinServices idelfinServices = (IDelfinServices) UnityContainerExtensions.Resolve<IDelfinServices>(Container, new ResolverOverride[0]);
        this.Session = (ISessionService) UnityContainerExtensions.Resolve<ISessionService>(Container, new ResolverOverride[0]);
        if (x_Tipos != null)
        {
          ObservableCollection<Delfin.Entities.Tipos> tiposByTipoCodTabla = idelfinServices.GetAllTiposByTipoCodTabla(x_tipo_codtabla);
          this.ListTipos = new ObservableCollection<Delfin.Entities.Tipos>();
          foreach (string xTipo in x_Tipos)
          {
            string iTDO = xTipo;
            this.ListTipos = (ObservableCollection<Delfin.Entities.Tipos>) ObservableCollectionExtension.ToObservableCollection<Delfin.Entities.Tipos>((IEnumerable<M0>) ((IEnumerable<Delfin.Entities.Tipos>) this.ListTipos).Concat<Delfin.Entities.Tipos>((IEnumerable<Delfin.Entities.Tipos>) ObservableCollectionExtension.ToObservableCollection<Delfin.Entities.Tipos>((IEnumerable<M0>) ((IEnumerable<Delfin.Entities.Tipos>) tiposByTipoCodTabla).Where<Delfin.Entities.Tipos>((Func<Delfin.Entities.Tipos, bool>) (T => T.get_TIPO_CodTipo().Equals(iTDO))))));
          }
        }
        else
          this.ListTipos = idelfinServices.GetAllTiposByTipoCodTabla(x_tipo_codtabla);
        switch (x_sortItems)
        {
          case ListSortDirection.Ascending:
            this.ListTipos = (ObservableCollection<Delfin.Entities.Tipos>) ObservableCollectionExtension.ToObservableCollection<Delfin.Entities.Tipos>((IEnumerable<M0>) ((IEnumerable<Delfin.Entities.Tipos>) this.ListTipos).OrderBy<Delfin.Entities.Tipos, string>((Func<Delfin.Entities.Tipos, string>) (tipo => tipo.get_TIPO_Desc1())));
            break;
          case ListSortDirection.Descending:
            this.ListTipos = (ObservableCollection<Delfin.Entities.Tipos>) ObservableCollectionExtension.ToObservableCollection<Delfin.Entities.Tipos>((IEnumerable<M0>) ((IEnumerable<Delfin.Entities.Tipos>) this.ListTipos).OrderByDescending<Delfin.Entities.Tipos, string>((Func<Delfin.Entities.Tipos, string>) (tipo => tipo.get_TIPO_Desc1())));
            break;
        }
        if (x_firstElement != null)
        {
          ObservableCollection<Delfin.Entities.Tipos> listTipos = this.ListTipos;
          int index = 0;
          Delfin.Entities.Tipos tipos1 = new Delfin.Entities.Tipos();
          tipos1.set_TIPO_Desc1(x_firstElement);
          Delfin.Entities.Tipos tipos2 = tipos1;
          listTipos.Insert(index, tipos2);
        }
        this.ValueMember = "TIPO_CodTipo";
        this.DisplayMember = "TIPO_Desc1";
        this.DataSource = (object) this.ListTipos;
        if (this.ListTipos != null && this.ListTipos.Count > 0)
          this.SelectedItem = (object) ((IEnumerable<Delfin.Entities.Tipos>) this.ListTipos).ElementAt<Delfin.Entities.Tipos>(0);
        else
          this.SelectedIndex = -1;
      }
      catch (Exception ex)
      {
        int num = (int) Dialogos.MostrarMensajeError(this.TiposTitulo, "Ha ocurrido un error al cargar los datos tipos.", ex);
      }
    }

    public void LoadControl(ObservableCollection<Delfin.Entities.Tipos> x_listTipos, string x_titulo, string x_firstElement, ListSortDirection x_sortItems)
    {
      try
      {
        this.ListTipos = x_listTipos;
        switch (x_sortItems)
        {
          case ListSortDirection.Ascending:
            this.ListTipos = (ObservableCollection<Delfin.Entities.Tipos>) ObservableCollectionExtension.ToObservableCollection<Delfin.Entities.Tipos>((IEnumerable<M0>) ((IEnumerable<Delfin.Entities.Tipos>) this.ListTipos).OrderBy<Delfin.Entities.Tipos, string>((Func<Delfin.Entities.Tipos, string>) (tipo => tipo.get_TIPO_Desc1())));
            break;
          case ListSortDirection.Descending:
            this.ListTipos = (ObservableCollection<Delfin.Entities.Tipos>) ObservableCollectionExtension.ToObservableCollection<Delfin.Entities.Tipos>((IEnumerable<M0>) ((IEnumerable<Delfin.Entities.Tipos>) this.ListTipos).OrderByDescending<Delfin.Entities.Tipos, string>((Func<Delfin.Entities.Tipos, string>) (tipo => tipo.get_TIPO_Desc1())));
            break;
        }
        if (x_firstElement != null)
        {
          ObservableCollection<Delfin.Entities.Tipos> listTipos = this.ListTipos;
          int index = 0;
          Delfin.Entities.Tipos tipos1 = new Delfin.Entities.Tipos();
          tipos1.set_TIPO_Desc1(x_firstElement);
          Delfin.Entities.Tipos tipos2 = tipos1;
          listTipos.Insert(index, tipos2);
        }
        this.ValueMember = "TIPO_CodTipo";
        this.DisplayMember = "TIPO_Desc1";
        this.DataSource = (object) this.ListTipos;
        if (this.ListTipos != null && this.ListTipos.Count > 0)
          this.SelectedItem = (object) ((IEnumerable<Delfin.Entities.Tipos>) this.ListTipos).ElementAt<Delfin.Entities.Tipos>(0);
        else
          this.SelectedIndex = -1;
      }
      catch (Exception ex)
      {
        int num = (int) Dialogos.MostrarMensajeError(this.TiposTitulo, "Ha ocurrido un error al cargar los datos tipos.", ex);
      }
    }

    private int SetDropDownWidth(ComboBox myCombo)
    {
      int num = 0;
      foreach (object obj in myCombo.Items)
      {
        int width = TextRenderer.MeasureText(myCombo.GetItemText(obj), myCombo.Font).Width;
        if (width > num)
          num = width;
      }
      return num + SystemInformation.VerticalScrollBarWidth;
    }

    public ObservableCollection<Delfin.Entities.Tipos> getTDI_Contacto()
    {
      ObservableCollection<Delfin.Entities.Tipos> observableCollection1 = new ObservableCollection<Delfin.Entities.Tipos>();
      ObservableCollection<Delfin.Entities.Tipos> observableCollection2 = observableCollection1;
      Delfin.Entities.Tipos tipos1 = new Delfin.Entities.Tipos();
      tipos1.set_TIPO_CodTabla("TDI");
      tipos1.set_TIPO_CodTipo("002");
      tipos1.set_TIPO_Desc1("DNI");
      Delfin.Entities.Tipos tipos2 = tipos1;
      observableCollection2.Add(tipos2);
      ObservableCollection<Delfin.Entities.Tipos> observableCollection3 = observableCollection1;
      Delfin.Entities.Tipos tipos3 = new Delfin.Entities.Tipos();
      tipos3.set_TIPO_CodTabla("TDI");
      tipos3.set_TIPO_CodTipo("003");
      tipos3.set_TIPO_Desc1("PASAPORTE");
      Delfin.Entities.Tipos tipos4 = tipos3;
      observableCollection3.Add(tipos4);
      return observableCollection1;
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      this.components = (IContainer) new Container();
    }

    public enum OTipos
    {
      TDI_contacto,
    }
  }
}
