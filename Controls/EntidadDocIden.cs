// Decompiled with JetBrains decompiler
// Type: Delfin.Controls.EntidadDocIden
// Assembly: Delfin.Controls, Version=3.0.1.3, Culture=neutral, PublicKeyToken=null
// MVID: A4BA2B33-0E71-44B0-9838-A6C1CD0C2B15
// Assembly location: C:\Temp\Delfin.Controls.dll

using Delfin.Entities;
using Delfin.ServiceContracts;
using Infrastructure.Aspect.DataAccess;
using Infrastructure.WinForms.Controls;
using Microsoft.Practices.Unity;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Delfin.Controls
{
  public class EntidadDocIden : UserControl
  {
    private IContainer components;
    private TableLayoutPanel tableLayoutPanel1;
    private EntidadClear txaENTC_DOCIDEN;
    private EntidadClear txaENTC_NOMCOMPLETO;

    public EntidadDocIden()
    {
      this.InitializeComponent();
      this.txaENTC_DOCIDEN.PorDocIden = true;
      this.txaENTC_DOCIDEN.add_AyudaClean(new EventHandler(this.txaENTC_DOCIDEN_AyudaClean));
      this.txaENTC_NOMCOMPLETO.add_AyudaClean(new EventHandler(this.txaENTC_NOMCOMPLETO_AyudaClean));
      this.txaENTC_DOCIDEN.add_AyudaValueChanged(new EventHandler(this.txaENTC_DOCIDEN_AyudaValueChanged));
      this.txaENTC_NOMCOMPLETO.add_AyudaValueChanged(new EventHandler(this.txaENTC_NOMCOMPLETO_AyudaValueChanged));
      this.txaENTC_DOCIDEN.NuevaEntidad += new EventHandler(this.txaENTC_DOCIDEN_NuevaEntidad);
      this.txaENTC_NOMCOMPLETO.NuevaEntidad += new EventHandler(this.txaENTC_NOMCOMPLETO_NuevaEntidad);
    }

    public void LoadControl(IUnityContainer Container, TiposEntidad x_TipoEntidad, string ENTC_DOCIDEN_NAME = null, string ENTC_NOMCOMPLETO_NAME = null, bool x_soloentidad = false)
    {
      try
      {
        this.Client = (IDelfinServices) UnityContainerExtensions.Resolve<IDelfinServices>(Container, new ResolverOverride[0]);
        this.SoloEntidad = x_soloentidad;
        this.txaENTC_DOCIDEN.LoadControl(Container, "Ayuda de Entidad", x_TipoEntidad, (string) null, x_soloentidad);
        this.txaENTC_NOMCOMPLETO.LoadControl(Container, "Ayuda de Entidad", x_TipoEntidad, (string) null, x_soloentidad);
        this.txaENTC_DOCIDEN.TipoEntidad = x_TipoEntidad;
        this.txaENTC_NOMCOMPLETO.TipoEntidad = x_TipoEntidad;
        if (!string.IsNullOrEmpty(ENTC_DOCIDEN_NAME))
          ((Control) this.txaENTC_DOCIDEN).Name = ENTC_DOCIDEN_NAME;
        if (string.IsNullOrEmpty(ENTC_NOMCOMPLETO_NAME))
          return;
        ((Control) this.txaENTC_NOMCOMPLETO).Name = ENTC_NOMCOMPLETO_NAME;
      }
      catch (Exception ex)
      {
      }
    }

    private IDelfinServices Client { get; set; }

    public object TagEntidad
    {
      get
      {
        return this.txaENTC_NOMCOMPLETO.get_Tag();
      }
      set
      {
        this.txaENTC_NOMCOMPLETO.set_Tag(value);
      }
    }

    public bool SoloEntidad { get; set; }

    public TiposEntidad TiposEntidad
    {
      get
      {
        return this.txaENTC_NOMCOMPLETO.TipoEntidad;
      }
      set
      {
        this.txaENTC_DOCIDEN.TipoEntidad = value;
        this.txaENTC_NOMCOMPLETO.TipoEntidad = value;
      }
    }

    public Entidad SelectedItem
    {
      get
      {
        return this.txaENTC_NOMCOMPLETO.SelectedItem;
      }
    }

    public bool CrearNuevaEntidad
    {
      get
      {
        return this.txaENTC_DOCIDEN.CrearNuevaEntidad;
      }
      set
      {
        this.txaENTC_DOCIDEN.CrearNuevaEntidad = value;
        this.txaENTC_NOMCOMPLETO.CrearNuevaEntidad = value;
      }
    }

    public void SetEntidad(int? ENTC_Codigo)
    {
      try
      {
        if (ENTC_Codigo.HasValue)
        {
          this.txaENTC_DOCIDEN.SetEntidad(new int?(ENTC_Codigo.Value));
          this.txaENTC_NOMCOMPLETO.SetEntidad(this.txaENTC_DOCIDEN.get_Value() as Entidad);
        }
        else
        {
          this.txaENTC_DOCIDEN.ClearEntidad();
          this.txaENTC_NOMCOMPLETO.ClearEntidad();
        }
        if (this.SelectedItemChanged == null)
          return;
        this.SelectedItemChanged((object) this.SelectedItem, EventArgs.Empty);
      }
      catch (Exception ex)
      {
      }
    }

    public void SetEntidad(string ENTC_DocIden)
    {
      try
      {
        if (!string.IsNullOrEmpty(ENTC_DocIden))
        {
          ObservableCollection<DataAccessFilterSQL> observableCollection1 = new ObservableCollection<DataAccessFilterSQL>();
          ObservableCollection<DataAccessFilterSQL> observableCollection2 = observableCollection1;
          DataAccessFilterSQL dataAccessFilterSql1 = new DataAccessFilterSQL();
          dataAccessFilterSql1.set_FilterName("@pvchENTC_DocIden");
          dataAccessFilterSql1.set_FilterValue((object) ENTC_DocIden);
          dataAccessFilterSql1.set_FilterType((DataAccessFilterTypes) 1);
          dataAccessFilterSql1.set_FilterSize(25);
          DataAccessFilterSQL dataAccessFilterSql2 = dataAccessFilterSql1;
          observableCollection2.Add(dataAccessFilterSql2);
          ObservableCollection<Entidad> allEntidadFilter = this.Client.GetAllEntidadFilter("ENTCSS_UnRegDocIden", observableCollection1);
          if (allEntidadFilter != null && allEntidadFilter.Count > 0)
          {
            this.txaENTC_DOCIDEN.SetEntidad(allEntidadFilter[0]);
            this.txaENTC_NOMCOMPLETO.SetEntidad(allEntidadFilter[0]);
          }
        }
        else
        {
          this.txaENTC_DOCIDEN.ClearEntidad();
          this.txaENTC_NOMCOMPLETO.ClearEntidad();
        }
        if (this.SelectedItemChanged == null)
          return;
        this.SelectedItemChanged((object) this.SelectedItem, EventArgs.Empty);
      }
      catch (Exception ex)
      {
      }
    }

    public void SetEntidad(Entidad x_itemENTIDAD)
    {
      try
      {
        if (x_itemENTIDAD != null)
        {
          this.txaENTC_DOCIDEN.SetValue((object) x_itemENTIDAD, x_itemENTIDAD.get_ENTC_DocIden());
          this.txaENTC_NOMCOMPLETO.SetValue((object) x_itemENTIDAD, x_itemENTIDAD.get_ENTC_NomCompleto());
        }
        else
        {
          this.txaENTC_DOCIDEN.ClearEntidad();
          this.txaENTC_NOMCOMPLETO.ClearEntidad();
        }
        if (this.SelectedItemChanged == null)
          return;
        this.SelectedItemChanged((object) this.SelectedItem, EventArgs.Empty);
      }
      catch (Exception ex)
      {
      }
    }

    public void Clear()
    {
      try
      {
        this.txaENTC_DOCIDEN.ClearEntidad();
        this.txaENTC_NOMCOMPLETO.ClearEntidad();
        if (this.SelectedItemChanged == null)
          return;
        this.SelectedItemChanged((object) this.SelectedItem, EventArgs.Empty);
      }
      catch (Exception ex)
      {
      }
    }

    public string txaENTC_DOCIDEN_Name
    {
      get
      {
        return ((Control) this.txaENTC_DOCIDEN).Name;
      }
      set
      {
        ((Control) this.txaENTC_DOCIDEN).Name = value;
      }
    }

    public string txaENTC_NOMCOMPLETO_Name
    {
      get
      {
        return ((Control) this.txaENTC_NOMCOMPLETO).Name;
      }
      set
      {
        ((Control) this.txaENTC_NOMCOMPLETO).Name = value;
      }
    }

    public event EventHandler NuevaEntidad;

    public event EventHandler SelectedItemChanged;

    private void txaENTC_DOCIDEN_AyudaClean(object sender, EventArgs e)
    {
      try
      {
        this.txaENTC_NOMCOMPLETO.remove_AyudaClean(new EventHandler(this.txaENTC_NOMCOMPLETO_AyudaClean));
        this.txaENTC_NOMCOMPLETO.ClearEntidad();
        this.txaENTC_NOMCOMPLETO.add_AyudaClean(new EventHandler(this.txaENTC_NOMCOMPLETO_AyudaClean));
        if (this.SelectedItemChanged == null)
          return;
        this.SelectedItemChanged((object) this.SelectedItem, EventArgs.Empty);
      }
      catch (Exception ex)
      {
      }
    }

    private void txaENTC_NOMCOMPLETO_AyudaClean(object sender, EventArgs e)
    {
      try
      {
        this.txaENTC_DOCIDEN.remove_AyudaClean(new EventHandler(this.txaENTC_DOCIDEN_AyudaClean));
        this.txaENTC_DOCIDEN.ClearEntidad();
        this.txaENTC_DOCIDEN.add_AyudaClean(new EventHandler(this.txaENTC_DOCIDEN_AyudaClean));
        if (this.SelectedItemChanged == null)
          return;
        this.SelectedItemChanged((object) this.SelectedItem, EventArgs.Empty);
      }
      catch (Exception ex)
      {
      }
    }

    private void txaENTC_DOCIDEN_AyudaValueChanged(object sender, EventArgs e)
    {
      try
      {
        if (this.txaENTC_DOCIDEN.SelectedItem != null)
        {
          this.txaENTC_NOMCOMPLETO.remove_AyudaValueChanged(new EventHandler(this.txaENTC_NOMCOMPLETO_AyudaValueChanged));
          this.txaENTC_NOMCOMPLETO.SetValue((object) this.txaENTC_DOCIDEN.SelectedItem, this.txaENTC_DOCIDEN.SelectedItem.get_ENTC_NomCompleto());
          this.txaENTC_NOMCOMPLETO.add_AyudaValueChanged(new EventHandler(this.txaENTC_NOMCOMPLETO_AyudaValueChanged));
        }
        if (this.SelectedItemChanged == null)
          return;
        this.SelectedItemChanged((object) this.SelectedItem, EventArgs.Empty);
      }
      catch (Exception ex)
      {
      }
    }

    private void txaENTC_NOMCOMPLETO_AyudaValueChanged(object sender, EventArgs e)
    {
      try
      {
        if (this.txaENTC_NOMCOMPLETO.SelectedItem != null)
        {
          this.txaENTC_DOCIDEN.remove_AyudaValueChanged(new EventHandler(this.txaENTC_DOCIDEN_AyudaValueChanged));
          this.txaENTC_DOCIDEN.SetValue((object) this.txaENTC_NOMCOMPLETO.SelectedItem, this.txaENTC_NOMCOMPLETO.SelectedItem.get_ENTC_DocIden());
          this.txaENTC_DOCIDEN.add_AyudaValueChanged(new EventHandler(this.txaENTC_DOCIDEN_AyudaValueChanged));
        }
        if (this.SelectedItemChanged == null)
          return;
        this.SelectedItemChanged((object) this.SelectedItem, EventArgs.Empty);
      }
      catch (Exception ex)
      {
      }
    }

    private void txaENTC_DOCIDEN_NuevaEntidad(object sender, EventArgs e)
    {
      if (this.NuevaEntidad == null)
        return;
      this.NuevaEntidad((object) null, EventArgs.Empty);
    }

    private void txaENTC_NOMCOMPLETO_NuevaEntidad(object sender, EventArgs e)
    {
      if (this.NuevaEntidad == null)
        return;
      this.NuevaEntidad((object) null, EventArgs.Empty);
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
      this.tableLayoutPanel1 = new TableLayoutPanel();
      this.txaENTC_DOCIDEN = new EntidadClear(this.components);
      this.txaENTC_NOMCOMPLETO = new EntidadClear(this.components);
      this.tableLayoutPanel1.SuspendLayout();
      this.SuspendLayout();
      this.tableLayoutPanel1.ColumnCount = 5;
      this.tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 200f));
      this.tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 15f));
      this.tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 150f));
      this.tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 200f));
      this.tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle());
      this.tableLayoutPanel1.Controls.Add((Control) this.txaENTC_DOCIDEN, 0, 0);
      this.tableLayoutPanel1.Controls.Add((Control) this.txaENTC_NOMCOMPLETO, 2, 0);
      this.tableLayoutPanel1.Dock = DockStyle.Fill;
      this.tableLayoutPanel1.Location = new Point(0, 0);
      this.tableLayoutPanel1.Name = "tableLayoutPanel1";
      this.tableLayoutPanel1.RowCount = 1;
      this.tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 27f));
      this.tableLayoutPanel1.Size = new Size(565, 27);
      this.tableLayoutPanel1.TabIndex = 0;
      this.txaENTC_DOCIDEN.set_ActivarAyudaAuto(false);
      ((Control) this.txaENTC_DOCIDEN).BackColor = Color.White;
      ((TextBox) this.txaENTC_DOCIDEN).CharacterCasing = CharacterCasing.Upper;
      this.txaENTC_DOCIDEN.set_EnabledAyudaButton(true);
      ((Control) this.txaENTC_DOCIDEN).Location = new Point(3, 3);
      this.txaENTC_DOCIDEN.set_LongitudAceptada(0);
      ((TextBoxBase) this.txaENTC_DOCIDEN).MaxLength = 100;
      this.txaENTC_DOCIDEN.set_MyInstanciaAyuda((TextBoxAyuda.InstanciaAyuda) 0);
      ((Control) this.txaENTC_DOCIDEN).Name = "txaENTC_DOCIDEN";
      this.txaENTC_DOCIDEN.set_RellenaCeros(false);
      ((Control) this.txaENTC_DOCIDEN).Size = new Size(194, 20);
      ((Control) this.txaENTC_DOCIDEN).TabIndex = 0;
      this.txaENTC_DOCIDEN.set_Tipo((TextBoxAyuda.TipoTextBoxAyuda) 1);
      this.txaENTC_DOCIDEN.TipoEntidad = TiposEntidad.TIPE_AgenciaAduanera;
      this.txaENTC_DOCIDEN.set_Value((object) null);
      this.txaENTC_NOMCOMPLETO.set_ActivarAyudaAuto(false);
      ((Control) this.txaENTC_NOMCOMPLETO).BackColor = Color.White;
      ((TextBox) this.txaENTC_NOMCOMPLETO).CharacterCasing = CharacterCasing.Upper;
      this.tableLayoutPanel1.SetColumnSpan((Control) this.txaENTC_NOMCOMPLETO, 2);
      this.txaENTC_NOMCOMPLETO.set_EnabledAyudaButton(true);
      ((Control) this.txaENTC_NOMCOMPLETO).Location = new Point(218, 3);
      this.txaENTC_NOMCOMPLETO.set_LongitudAceptada(0);
      ((TextBoxBase) this.txaENTC_NOMCOMPLETO).MaxLength = 100;
      this.txaENTC_NOMCOMPLETO.set_MyInstanciaAyuda((TextBoxAyuda.InstanciaAyuda) 0);
      ((Control) this.txaENTC_NOMCOMPLETO).Name = "txaENTC_NOMCOMPLETO";
      this.txaENTC_NOMCOMPLETO.set_RellenaCeros(false);
      ((Control) this.txaENTC_NOMCOMPLETO).Size = new Size(344, 20);
      ((Control) this.txaENTC_NOMCOMPLETO).TabIndex = 1;
      this.txaENTC_NOMCOMPLETO.set_Tipo((TextBoxAyuda.TipoTextBoxAyuda) 1);
      this.txaENTC_NOMCOMPLETO.TipoEntidad = TiposEntidad.TIPE_AgenciaAduanera;
      this.txaENTC_NOMCOMPLETO.set_Value((object) null);
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.BackColor = Color.LightSteelBlue;
      this.Controls.Add((Control) this.tableLayoutPanel1);
      this.MinimumSize = new Size(565, 27);
      this.Name = nameof (EntidadDocIden);
      this.Size = new Size(565, 27);
      this.tableLayoutPanel1.ResumeLayout(false);
      this.tableLayoutPanel1.PerformLayout();
      this.ResumeLayout(false);
    }
  }
}
