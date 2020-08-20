// Decompiled with JetBrains decompiler
// Type: Delfin.Controls.ComboBoxTipoEntidad
// Assembly: Delfin.Controls, Version=3.0.1.3, Culture=neutral, PublicKeyToken=null
// MVID: A4BA2B33-0E71-44B0-9838-A6C1CD0C2B15
// Assembly location: C:\Temp\Delfin.Controls.dll

using Delfin.Entities;
using Delfin.ServiceContracts;
using Infrastructure.Aspect.Collections;
using Infrastructure.WinForms.Controls;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

namespace Delfin.Controls
{
  public class ComboBoxTipoEntidad : ComboBox
  {
    private IContainer components;

    public ComboBoxTipoEntidad()
    {
      this.InitializeComponent();
      try
      {
        this.DropDown += new EventHandler(this.ComboBoxTipoEntidad_DropDown);
        this.SelectedIndexChanged += new EventHandler(this.ComboBoxTipoEntidad_SelectedIndexChanged);
        this.DropDownStyle = ComboBoxStyle.DropDownList;
      }
      catch (Exception ex)
      {
        int num = (int) Dialogos.MostrarMensajeError(this.TiposTitulo, "Ha ocurrido un error al inicializar el formulario.", ex);
      }
    }

    public string TiposTitulo { get; set; }

    public short? TipoEntidadSelectedValue
    {
      get
      {
        if (this.SelectedItem != null)
          return new short?(((TiposEntidad) this.SelectedItem).get_TIPE_Codigo());
        return new short?();
      }
      set
      {
        short? nullable1 = value;
        if (!(nullable1.HasValue ? new int?((int) nullable1.GetValueOrDefault()) : new int?()).HasValue || !value.HasValue)
        {
          if (this.ListTipoEntidad == null || this.ListTipoEntidad.Count <= 0)
            return;
          this.SelectedItem = (object) ((IEnumerable<TiposEntidad>) this.ListTipoEntidad).ElementAt<TiposEntidad>(0);
        }
        else
          this.SelectedItem = (object) ((IEnumerable<TiposEntidad>) this.DataSource).Where<TiposEntidad>((Func<TiposEntidad, bool>) (tipo =>
          {
            int tipeCodigo = (int) tipo.get_TIPE_Codigo();
            short? nullable2 = value;
            if (tipeCodigo == (int) nullable2.GetValueOrDefault())
              return nullable2.HasValue;
            return false;
          })).FirstOrDefault<TiposEntidad>();
      }
    }

    public TiposEntidad TipoEntidadSelectedItem
    {
      get
      {
        if (this.SelectedItem != null && ((TiposEntidad) this.SelectedItem).get_TIPE_Codigo() > (short) 0)
          return (TiposEntidad) this.SelectedItem;
        return (TiposEntidad) null;
      }
      set
      {
        this.SelectedItem = (object) value;
      }
    }

    private ObservableCollection<TiposEntidad> ListTipoEntidad { get; set; }

    public event EventHandler TipoEntidadSelectedItemChanged;

    private void ComboBoxTipoEntidad_DropDown(object sender, EventArgs e)
    {
      try
      {
        this.DropDownWidth = this.SetDropDownWidth((ComboBox) this);
      }
      catch
      {
      }
    }

    private void ComboBoxTipoEntidad_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (this.TipoEntidadSelectedItemChanged == null)
        return;
      this.TipoEntidadSelectedItemChanged((object) this, EventArgs.Empty);
    }

    public void LoadControl(IUnityContainer Container, string x_titulo, string x_firstElement, ListSortDirection x_sortItems, short? x_para_clave = null, short[] x_tiposentidad = null)
    {
      try
      {
        IDelfinServices idelfinServices = (IDelfinServices) UnityContainerExtensions.Resolve<IDelfinServices>(Container, new ResolverOverride[0]);
        if (x_tiposentidad != null)
        {
          ObservableCollection<TiposEntidad> todosTiposEntidad = idelfinServices.GetTodosTiposEntidad();
          this.ListTipoEntidad = new ObservableCollection<TiposEntidad>();
          foreach (short num in x_tiposentidad)
          {
            short iTE = num;
            TiposEntidad tiposEntidad = ((IEnumerable<TiposEntidad>) todosTiposEntidad).Where<TiposEntidad>((Func<TiposEntidad, bool>) (TE => (int) TE.get_TIPE_Codigo() == (int) iTE)).FirstOrDefault<TiposEntidad>();
            if (x_tiposentidad != null)
              this.ListTipoEntidad.Add(tiposEntidad);
          }
        }
        else
          this.ListTipoEntidad = idelfinServices.GetTodosTiposEntidad();
        switch (x_sortItems)
        {
          case ListSortDirection.Ascending:
            this.ListTipoEntidad = (ObservableCollection<TiposEntidad>) ObservableCollectionExtension.ToObservableCollection<TiposEntidad>((IEnumerable<M0>) ((IEnumerable<TiposEntidad>) this.ListTipoEntidad).OrderBy<TiposEntidad, string>((Func<TiposEntidad, string>) (tipo => tipo.get_TIPE_Descripcion())));
            break;
          case ListSortDirection.Descending:
            this.ListTipoEntidad = (ObservableCollection<TiposEntidad>) ObservableCollectionExtension.ToObservableCollection<TiposEntidad>((IEnumerable<M0>) ((IEnumerable<TiposEntidad>) this.ListTipoEntidad).OrderByDescending<TiposEntidad, string>((Func<TiposEntidad, string>) (tipo => tipo.get_TIPE_Descripcion())));
            break;
        }
        if (x_firstElement != null)
        {
          ObservableCollection<TiposEntidad> listTipoEntidad = this.ListTipoEntidad;
          int index = 0;
          TiposEntidad tiposEntidad1 = new TiposEntidad();
          tiposEntidad1.set_TIPE_Descripcion(x_firstElement);
          TiposEntidad tiposEntidad2 = tiposEntidad1;
          listTipoEntidad.Insert(index, tiposEntidad2);
        }
        this.ValueMember = "TIPE_Codigo";
        this.DisplayMember = "TIPE_Descripcion";
        this.DataSource = (object) this.ListTipoEntidad;
        if (this.ListTipoEntidad != null && this.ListTipoEntidad.Count > 0)
          this.SelectedItem = (object) ((IEnumerable<TiposEntidad>) this.ListTipoEntidad).ElementAt<TiposEntidad>(0);
        else
          this.SelectedIndex = -1;
        if (!x_para_clave.HasValue)
          return;
        this.SelectedValue = (object) x_para_clave;
      }
      catch (Exception ex)
      {
        int num = (int) Dialogos.MostrarMensajeError(this.TiposTitulo, "Ha ocurrido un error al cargar los datos de tipo entidad.", ex);
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
  }
}
