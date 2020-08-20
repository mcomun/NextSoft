// Decompiled with JetBrains decompiler
// Type: Delfin.Controls.UbigeoControlPresenter
// Assembly: Delfin.Controls, Version=3.0.1.3, Culture=neutral, PublicKeyToken=null
// MVID: A4BA2B33-0E71-44B0-9838-A6C1CD0C2B15
// Assembly location: C:\Temp\Delfin.Controls.dll

using Delfin.Entities;
using Delfin.ServiceContracts;
using Infrastructure.Aspect.Collections;
using Infrastructure.WinFormsControls;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Delfin.Controls
{
  public class UbigeoControlPresenter
  {
    private ObservableCollection<Tipos> m_listPaises;
    private ObservableCollection<Ubigeos> m_listUbigeo;
    private ObservableCollection<Ubigeos> m_listUbigeoDep;
    private ObservableCollection<Ubigeos> m_listUbigeoProv;
    private ObservableCollection<Ubigeos> m_listUbigeoDist;

    public UbigeoControlPresenter(IUbigeoControl x_control, IUnityContainer x_container)
    {
      try
      {
        this.Control = x_control;
        this.Container = x_container;
        this.Client = (IDelfinServices) UnityContainerExtensions.Resolve<IDelfinServices>(x_container, new ResolverOverride[0]);
      }
      catch (Exception ex)
      {
        int num = (int) Dialogos.MostrarMensajeError(this.Control.Titulo, "Ha ocurrido un error al inicializar el controlador del formulario.", ex);
      }
    }

    public IUbigeoControl Control { get; set; }

    public IUnityContainer Container { get; set; }

    public IDelfinServices Client { get; set; }

    public ObservableCollection<Tipos> ListPaises
    {
      get
      {
        return this.m_listPaises;
      }
      set
      {
        this.m_listPaises = value;
      }
    }

    public ObservableCollection<Ubigeos> ListUbigeo
    {
      get
      {
        return this.m_listUbigeo;
      }
      set
      {
        this.m_listUbigeo = value;
      }
    }

    public ObservableCollection<Ubigeos> ListUbigeoDep
    {
      get
      {
        return this.m_listUbigeoDep;
      }
      set
      {
        this.m_listUbigeoDep = value;
      }
    }

    public ObservableCollection<Ubigeos> ListUbigeoProv
    {
      get
      {
        return this.m_listUbigeoProv;
      }
      set
      {
        this.m_listUbigeoProv = value;
      }
    }

    public ObservableCollection<Ubigeos> ListUbigeoDist
    {
      get
      {
        return this.m_listUbigeoDist;
      }
      set
      {
        this.m_listUbigeoDist = value;
      }
    }

    public void LoadComboDepartamento()
    {
      try
      {
        this.ListUbigeo = this.Client.GetAllUbigeos();
        this.ListUbigeoDep = (ObservableCollection<Ubigeos>) ObservableCollectionExtension.ToObservableCollection<Ubigeos>((IEnumerable<M0>) ((IEnumerable<Ubigeos>) this.ListUbigeo).Where<Ubigeos>((Func<Ubigeos, bool>) (Ubigeo => Ubigeo.get_UBIG_CodPadre() == null)));
        ObservableCollection<Ubigeos> listUbigeoDep = this.ListUbigeoDep;
        int index = 0;
        Ubigeos ubigeos1 = new Ubigeos();
        ubigeos1.set_UBIG_Codigo("00");
        ubigeos1.set_UBIG_Desc("< Seleccione Departamento >");
        Ubigeos ubigeos2 = ubigeos1;
        listUbigeoDep.Insert(index, ubigeos2);
        this.Control.LoadComboDepartamento();
      }
      catch (Exception ex)
      {
        int num = (int) Dialogos.MostrarMensajeError(this.Control.Titulo, "Ha ocurrido un error al cargar la lista de elementos.", ex);
      }
    }

    public void LoadComboPais()
    {
      try
      {
        this.ListPaises = this.Client.GetAllTiposByTipoCodTabla("PAI");
        ObservableCollection<Tipos> listPaises = this.ListPaises;
        int index = 0;
        Tipos tipos1 = new Tipos();
        tipos1.set_TIPO_CodTipo("000");
        tipos1.set_TIPO_Desc1("< Seleccione País >");
        Tipos tipos2 = tipos1;
        listPaises.Insert(index, tipos2);
        this.Control.LoadComboPaises();
      }
      catch (Exception ex)
      {
        int num = (int) Dialogos.MostrarMensajeError(this.Control.Titulo, "Ha ocurrido un error al cargar la lista de elementos.", ex);
      }
    }

    public void LoadComboDepartamento(string x_TIPO_CodPais)
    {
      try
      {
        this.ListUbigeo = this.Client.GetAllUbigeos();
        this.ListUbigeoDep = (ObservableCollection<Ubigeos>) ObservableCollectionExtension.ToObservableCollection<Ubigeos>((IEnumerable<M0>) ((IEnumerable<Ubigeos>) this.ListUbigeo).Where<Ubigeos>((Func<Ubigeos, bool>) (Ubigeo =>
        {
          if (Ubigeo.get_UBIG_CodPadre() == null)
            return Ubigeo.get_TIPO_CodPais() == x_TIPO_CodPais;
          return false;
        })));
        ObservableCollection<Ubigeos> listUbigeoDep = this.ListUbigeoDep;
        int index = 0;
        Ubigeos ubigeos1 = new Ubigeos();
        ubigeos1.set_UBIG_Codigo("000");
        ubigeos1.set_UBIG_Desc("< Seleccione Departamento >");
        Ubigeos ubigeos2 = ubigeos1;
        listUbigeoDep.Insert(index, ubigeos2);
        this.Control.LoadComboDepartamento();
      }
      catch (Exception ex)
      {
        int num = (int) Dialogos.MostrarMensajeError(this.Control.Titulo, "Ha ocurrido un error al cargar la lista de elementos.", ex);
      }
    }

    public void LoadComboProvincia(string x_TIPO_CodPais, string x_UBIG_Codigo)
    {
      try
      {
        this.ListUbigeoProv = new ObservableCollection<Ubigeos>();
        if (!string.IsNullOrEmpty(x_UBIG_Codigo))
        {
          this.ListUbigeoProv = (ObservableCollection<Ubigeos>) ObservableCollectionExtension.ToObservableCollection<Ubigeos>((IEnumerable<M0>) ((IEnumerable<Ubigeos>) this.ListUbigeo).Where<Ubigeos>((Func<Ubigeos, bool>) (Ubigeo =>
          {
            if (Ubigeo.get_UBIG_CodPadre() == x_UBIG_Codigo)
              return Ubigeo.get_TIPO_CodPais() == x_TIPO_CodPais;
            return false;
          })));
          ObservableCollection<Ubigeos> listUbigeoProv = this.ListUbigeoProv;
          int index = 0;
          Ubigeos ubigeos1 = new Ubigeos();
          ubigeos1.set_UBIG_Codigo("00.00");
          ubigeos1.set_UBIG_Desc("< Seleccione Provincia >");
          Ubigeos ubigeos2 = ubigeos1;
          listUbigeoProv.Insert(index, ubigeos2);
        }
        this.Control.LoadComboProvincia();
      }
      catch (Exception ex)
      {
        int num = (int) Dialogos.MostrarMensajeError(this.Control.Titulo, "Ha ocurrido un error al cargar la lista de elementos.", ex);
      }
    }

    public void LoadComboDistrito(string x_TIPO_CodPais, string x_UBIG_Codigo)
    {
      try
      {
        this.ListUbigeoDist = new ObservableCollection<Ubigeos>();
        if (!string.IsNullOrEmpty(x_UBIG_Codigo))
        {
          this.ListUbigeoDist = (ObservableCollection<Ubigeos>) ObservableCollectionExtension.ToObservableCollection<Ubigeos>((IEnumerable<M0>) ((IEnumerable<Ubigeos>) this.ListUbigeo).Where<Ubigeos>((Func<Ubigeos, bool>) (Ubigeo =>
          {
            if (Ubigeo.get_UBIG_CodPadre() == x_UBIG_Codigo)
              return Ubigeo.get_TIPO_CodPais() == x_TIPO_CodPais;
            return false;
          })));
          ObservableCollection<Ubigeos> listUbigeoDist = this.ListUbigeoDist;
          int index = 0;
          Ubigeos ubigeos1 = new Ubigeos();
          ubigeos1.set_UBIG_Codigo("00.00.00");
          ubigeos1.set_UBIG_Desc("< Seleccione Distrito >");
          Ubigeos ubigeos2 = ubigeos1;
          listUbigeoDist.Insert(index, ubigeos2);
        }
        this.Control.LoadComboDistrito();
      }
      catch (Exception ex)
      {
        int num = (int) Dialogos.MostrarMensajeError(this.Control.Titulo, "Ha ocurrido un error al cargar la lista de elementos.", ex);
      }
    }
  }
}
