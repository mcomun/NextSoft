// Decompiled with JetBrains decompiler
// Type: Delfin.Controls.Tipos.ComboBoxConstantes
// Assembly: Delfin.Controls, Version=3.0.1.3, Culture=neutral, PublicKeyToken=null
// MVID: A4BA2B33-0E71-44B0-9838-A6C1CD0C2B15
// Assembly location: C:\Temp\Delfin.Controls.dll

using Delfin.Entities;
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
  public class ComboBoxConstantes : ComboBox
  {
    private IContainer components;

    public ComboBoxConstantes()
    {
      this.InitializeComponent();
      try
      {
        this.DropDown += new EventHandler(this.ComboBoxConstantes_DropDown);
        this.DropDownStyle = ComboBoxStyle.DropDownList;
      }
      catch (Exception ex)
      {
        int num = (int) Dialogos.MostrarMensajeError(this.ConstantesTitulo, "Ha ocurrido un error al inicializar el formulario.", ex);
      }
    }

    public string ConstantesTitulo { get; set; }

    public ISessionService Session { get; set; }

    public string ConstantesSelectedValue
    {
      get
      {
        if (this.SelectedItem != null)
          return ((Constantes) this.SelectedItem).get_CONS_CodTipo();
        return (string) null;
      }
      set
      {
        if (value == null || string.IsNullOrEmpty(value))
        {
          if (this.ListConstantes == null || this.ListConstantes.Count <= 0)
            return;
          this.SelectedItem = (object) ((IEnumerable<Constantes>) this.ListConstantes).ElementAt<Constantes>(0);
        }
        else
          this.SelectedItem = (object) ((IEnumerable<Constantes>) this.DataSource).Where<Constantes>((Func<Constantes, bool>) (tipo => tipo.get_CONS_CodTipo() == value)).FirstOrDefault<Constantes>();
      }
    }

    public Constantes ConstantesSelectedItem
    {
      get
      {
        if (this.SelectedItem != null && ((Constantes) this.SelectedItem).get_CONS_CodTipo() != null)
          return (Constantes) this.SelectedItem;
        return (Constantes) null;
      }
      set
      {
        this.SelectedItem = (object) value;
      }
    }

    private ObservableCollection<Constantes> ListConstantes { get; set; }

    private void ComboBoxConstantes_DropDown(object sender, EventArgs e)
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
        chksTablas1.set_CHKS_Tabla("Constantes");
        CHKS_Tablas chksTablas2 = chksTablas1;
        DataTable dataTable = generarChekSum.CargarXML(chksTablas2);
        if (dataTable == null)
          return;
        this.ListConstantes = new ObservableCollection<Constantes>();
        foreach (DataRow row in (InternalDataCollectionBase) dataTable.Rows)
        {
          if (row["CONS_CodTabla"].ToString().Equals(x_tipo_codtabla))
          {
            Constantes constantes = new Constantes();
            new BusinessEntityLoader<Constantes>().LoadEntity(row, (object) constantes);
            this.ListConstantes.Add(constantes);
          }
        }
      }
      catch (Exception ex)
      {
        throw;
      }
    }

    public void LoadControl(IUnityContainer ContainerService, string x_titulo, string x_tipo_codtabla, string x_firstElement, ListSortDirection x_sortItems, string[] x_Constantes = null)
    {
      try
      {
        IDelfinServices idelfinServices = (IDelfinServices) UnityContainerExtensions.Resolve<IDelfinServices>(ContainerService, new ResolverOverride[0]);
        this.Session = (ISessionService) UnityContainerExtensions.Resolve<ISessionService>(ContainerService, new ResolverOverride[0]);
        if (x_Constantes != null)
        {
          ObservableCollection<Constantes> byConstanteTabla = idelfinServices.GetAllConstantesByConstanteTabla(x_tipo_codtabla);
          this.ListConstantes = new ObservableCollection<Constantes>();
          foreach (string xConstante in x_Constantes)
          {
            string iEST = xConstante;
            this.ListConstantes = (ObservableCollection<Constantes>) ObservableCollectionExtension.ToObservableCollection<Constantes>((IEnumerable<M0>) ((IEnumerable<Constantes>) this.ListConstantes).Concat<Constantes>((IEnumerable<Constantes>) ObservableCollectionExtension.ToObservableCollection<Constantes>((IEnumerable<M0>) ((IEnumerable<Constantes>) byConstanteTabla).Where<Constantes>((Func<Constantes, bool>) (T => T.get_CONS_CodTipo().Equals(iEST))))));
          }
        }
        else
          this.ListConstantes = idelfinServices.GetAllConstantesByConstanteTabla(x_tipo_codtabla);
        switch (x_sortItems)
        {
          case ListSortDirection.Ascending:
            this.ListConstantes = (ObservableCollection<Constantes>) ObservableCollectionExtension.ToObservableCollection<Constantes>((IEnumerable<M0>) ((IEnumerable<Constantes>) this.ListConstantes).OrderBy<Constantes, string>((Func<Constantes, string>) (tipo => tipo.get_CONS_Desc_SPA())));
            break;
          case ListSortDirection.Descending:
            this.ListConstantes = (ObservableCollection<Constantes>) ObservableCollectionExtension.ToObservableCollection<Constantes>((IEnumerable<M0>) ((IEnumerable<Constantes>) this.ListConstantes).OrderByDescending<Constantes, string>((Func<Constantes, string>) (tipo => tipo.get_CONS_Desc_SPA())));
            break;
        }
        if (x_firstElement != null)
        {
          ObservableCollection<Constantes> listConstantes = this.ListConstantes;
          int index = 0;
          Constantes constantes1 = new Constantes();
          constantes1.set_CONS_Desc_SPA(x_firstElement);
          Constantes constantes2 = constantes1;
          listConstantes.Insert(index, constantes2);
        }
        this.DataSource = (object) this.ListConstantes;
        this.ValueMember = "CONS_CodTipo";
        this.DisplayMember = "CONS_Desc_SPA";
        if (this.ListConstantes == null || this.ListConstantes.Count <= 0)
          return;
        this.SelectedItem = (object) ((IEnumerable<Constantes>) this.ListConstantes).ElementAt<Constantes>(0);
      }
      catch (Exception ex)
      {
        int num = (int) Dialogos.MostrarMensajeError(this.ConstantesTitulo, "Ha ocurrido un error al cargar los datos constantes.", ex);
      }
    }

    public void LoadControl(ObservableCollection<Constantes> x_list, string x_titulo, string x_tipo_codtabla, string x_firstElement, ListSortDirection x_sortItems)
    {
      try
      {
        this.ListConstantes = new ObservableCollection<Constantes>((IEnumerable<Constantes>) x_list);
        switch (x_sortItems)
        {
          case ListSortDirection.Ascending:
            this.ListConstantes = (ObservableCollection<Constantes>) ObservableCollectionExtension.ToObservableCollection<Constantes>((IEnumerable<M0>) ((IEnumerable<Constantes>) this.ListConstantes).OrderBy<Constantes, string>((Func<Constantes, string>) (tipo => tipo.get_CONS_Desc_SPA())));
            break;
          case ListSortDirection.Descending:
            this.ListConstantes = (ObservableCollection<Constantes>) ObservableCollectionExtension.ToObservableCollection<Constantes>((IEnumerable<M0>) ((IEnumerable<Constantes>) this.ListConstantes).OrderByDescending<Constantes, string>((Func<Constantes, string>) (tipo => tipo.get_CONS_Desc_SPA())));
            break;
        }
        if (x_firstElement != null)
        {
          ObservableCollection<Constantes> listConstantes = this.ListConstantes;
          int index = 0;
          Constantes constantes1 = new Constantes();
          constantes1.set_CONS_Desc_SPA(x_firstElement);
          Constantes constantes2 = constantes1;
          listConstantes.Insert(index, constantes2);
        }
        this.DataSource = (object) this.ListConstantes;
        this.ValueMember = "CONS_CodTipo";
        this.DisplayMember = "CONS_Desc_SPA";
        if (this.ListConstantes == null || this.ListConstantes.Count <= 0)
          return;
        this.SelectedItem = (object) ((IEnumerable<Constantes>) this.ListConstantes).ElementAt<Constantes>(0);
      }
      catch (Exception ex)
      {
        int num = (int) Dialogos.MostrarMensajeError(this.ConstantesTitulo, "Ha ocurrido un error al cargar los datos constantes.", ex);
      }
    }

    public ObservableCollection<Constantes> getSERV_TipoMov()
    {
      ObservableCollection<Constantes> observableCollection1 = new ObservableCollection<Constantes>();
      ObservableCollection<Constantes> observableCollection2 = observableCollection1;
      Constantes constantes1 = new Constantes();
      constantes1.set_CONS_CodTipo("A");
      constantes1.set_CONS_Desc_SPA("AMBOS");
      Constantes constantes2 = constantes1;
      observableCollection2.Add(constantes2);
      ObservableCollection<Constantes> observableCollection3 = observableCollection1;
      Constantes constantes3 = new Constantes();
      constantes3.set_CONS_CodTipo("C");
      constantes3.set_CONS_Desc_SPA("COSTOS");
      Constantes constantes4 = constantes3;
      observableCollection3.Add(constantes4);
      ObservableCollection<Constantes> observableCollection4 = observableCollection1;
      Constantes constantes5 = new Constantes();
      constantes5.set_CONS_CodTipo("I");
      constantes5.set_CONS_Desc_SPA("INGRESOS");
      Constantes constantes6 = constantes5;
      observableCollection4.Add(constantes6);
      return observableCollection1;
    }

    public ObservableCollection<Constantes> getNVIA_Estado()
    {
      ObservableCollection<Constantes> observableCollection1 = new ObservableCollection<Constantes>();
      ObservableCollection<Constantes> observableCollection2 = observableCollection1;
      Constantes constantes1 = new Constantes();
      constantes1.set_CONS_CodTipo("A");
      constantes1.set_CONS_Desc_SPA("ABIERTO");
      Constantes constantes2 = constantes1;
      observableCollection2.Add(constantes2);
      ObservableCollection<Constantes> observableCollection3 = observableCollection1;
      Constantes constantes3 = new Constantes();
      constantes3.set_CONS_CodTipo("P");
      constantes3.set_CONS_Desc_SPA("PRE-FACTURADO");
      Constantes constantes4 = constantes3;
      observableCollection3.Add(constantes4);
      ObservableCollection<Constantes> observableCollection4 = observableCollection1;
      Constantes constantes5 = new Constantes();
      constantes5.set_CONS_CodTipo("C");
      constantes5.set_CONS_Desc_SPA("CERRADO");
      Constantes constantes6 = constantes5;
      observableCollection4.Add(constantes6);
      return observableCollection1;
    }

    public ObservableCollection<Constantes> getTipoCuenta()
    {
      ObservableCollection<Constantes> observableCollection1 = new ObservableCollection<Constantes>();
      ObservableCollection<Constantes> observableCollection2 = observableCollection1;
      Constantes constantes1 = new Constantes();
      constantes1.set_CONS_CodTipo("A");
      constantes1.set_CONS_Desc_SPA("CUENTA DE AHORROS");
      Constantes constantes2 = constantes1;
      observableCollection2.Add(constantes2);
      ObservableCollection<Constantes> observableCollection3 = observableCollection1;
      Constantes constantes3 = new Constantes();
      constantes3.set_CONS_CodTipo("C");
      constantes3.set_CONS_Desc_SPA("CUENTA CORRIENTE");
      Constantes constantes4 = constantes3;
      observableCollection3.Add(constantes4);
      ObservableCollection<Constantes> observableCollection4 = observableCollection1;
      Constantes constantes5 = new Constantes();
      constantes5.set_CONS_CodTipo("M");
      constantes5.set_CONS_Desc_SPA("CUENTA MAESTRA");
      Constantes constantes6 = constantes5;
      observableCollection4.Add(constantes6);
      return observableCollection1;
    }

    public ObservableCollection<Constantes> getTipoEntidad_Relacion()
    {
      ObservableCollection<Constantes> observableCollection1 = new ObservableCollection<Constantes>();
      ObservableCollection<Constantes> observableCollection2 = observableCollection1;
      Constantes constantes1 = new Constantes();
      constantes1.set_CONS_CodTipo("DTE");
      constantes1.set_CONS_CodTabla("RTIPO_DTE");
      constantes1.set_CONS_Desc_SPA("DEPOSITO TEMPORAL");
      Constantes constantes2 = constantes1;
      observableCollection2.Add(constantes2);
      ObservableCollection<Constantes> observableCollection3 = observableCollection1;
      Constantes constantes3 = new Constantes();
      constantes3.set_CONS_CodTipo("VEN");
      constantes3.set_CONS_CodTabla("RTIPO_VEN");
      constantes3.set_CONS_Desc_SPA("EJECUTIVO");
      Constantes constantes4 = constantes3;
      observableCollection3.Add(constantes4);
      ObservableCollection<Constantes> observableCollection4 = observableCollection1;
      Constantes constantes5 = new Constantes();
      constantes5.set_CONS_CodTipo("CON");
      constantes5.set_CONS_CodTabla("RTIPO_CON");
      constantes5.set_CONS_Desc_SPA("CONTACTOS");
      Constantes constantes6 = constantes5;
      observableCollection4.Add(constantes6);
      ObservableCollection<Constantes> observableCollection5 = observableCollection1;
      Constantes constantes7 = new Constantes();
      constantes7.set_CONS_CodTipo("DVA");
      constantes7.set_CONS_CodTabla("RTIPO_DVA");
      constantes7.set_CONS_Desc_SPA("DEPOSITO DE VACIOS");
      Constantes constantes8 = constantes7;
      observableCollection5.Add(constantes8);
      ObservableCollection<Constantes> observableCollection6 = observableCollection1;
      Constantes constantes9 = new Constantes();
      constantes9.set_CONS_CodTipo("AGE");
      constantes9.set_CONS_CodTabla("RTIPO_AGE");
      constantes9.set_CONS_Desc_SPA("AGENTE");
      Constantes constantes10 = constantes9;
      observableCollection6.Add(constantes10);
      ObservableCollection<Constantes> observableCollection7 = observableCollection1;
      Constantes constantes11 = new Constantes();
      constantes11.set_CONS_CodTipo("CSE");
      constantes11.set_CONS_CodTabla("RTIPO_CSE");
      constantes11.set_CONS_Desc_SPA("CUSTOMER SERVICES");
      Constantes constantes12 = constantes11;
      observableCollection7.Add(constantes12);
      return observableCollection1;
    }

    public ObservableCollection<Constantes> getLimiteCredito()
    {
      ObservableCollection<Constantes> observableCollection1 = new ObservableCollection<Constantes>();
      ObservableCollection<Constantes> observableCollection2 = observableCollection1;
      Constantes constantes1 = new Constantes();
      constantes1.set_CONS_CodTipo("MAN");
      constantes1.set_CONS_CodTabla("TLCRE_MAN");
      constantes1.set_CONS_Desc_SPA("MANDATO");
      Constantes constantes2 = constantes1;
      observableCollection2.Add(constantes2);
      ObservableCollection<Constantes> observableCollection3 = observableCollection1;
      Constantes constantes3 = new Constantes();
      constantes3.set_CONS_CodTipo("SLI");
      constantes3.set_CONS_CodTabla("TLCRE_SLI");
      constantes3.set_CONS_Desc_SPA("SLI");
      Constantes constantes4 = constantes3;
      observableCollection3.Add(constantes4);
      ObservableCollection<Constantes> observableCollection4 = observableCollection1;
      Constantes constantes5 = new Constantes();
      constantes5.set_CONS_CodTipo("EXP");
      constantes5.set_CONS_CodTabla("TLCRE_EXP");
      constantes5.set_CONS_Desc_SPA("EXPORTACIÓN");
      Constantes constantes6 = constantes5;
      observableCollection4.Add(constantes6);
      ObservableCollection<Constantes> observableCollection5 = observableCollection1;
      Constantes constantes7 = new Constantes();
      constantes7.set_CONS_CodTipo("OTR");
      constantes7.set_CONS_CodTabla("TLCRE_OTR");
      constantes7.set_CONS_Desc_SPA("OTROS TRÁFICOS");
      Constantes constantes8 = constantes7;
      observableCollection5.Add(constantes8);
      ObservableCollection<Constantes> observableCollection6 = observableCollection1;
      Constantes constantes9 = new Constantes();
      constantes9.set_CONS_CodTipo("PRO");
      constantes9.set_CONS_CodTabla("TLCRE_PRO");
      constantes9.set_CONS_Desc_SPA("<PROVEEDOR>");
      Constantes constantes10 = constantes9;
      observableCollection6.Add(constantes10);
      return observableCollection1;
    }

    public ObservableCollection<Constantes> getEstadoChequera()
    {
      ObservableCollection<Constantes> observableCollection1 = new ObservableCollection<Constantes>();
      ObservableCollection<Constantes> observableCollection2 = observableCollection1;
      Constantes constantes1 = new Constantes();
      constantes1.set_CONS_CodTipo("U");
      constantes1.set_CONS_CodTabla("CHEQU_U");
      constantes1.set_CONS_Desc_SPA("EN USO");
      Constantes constantes2 = constantes1;
      observableCollection2.Add(constantes2);
      ObservableCollection<Constantes> observableCollection3 = observableCollection1;
      Constantes constantes3 = new Constantes();
      constantes3.set_CONS_CodTipo("S");
      constantes3.set_CONS_CodTabla("CHEQU_S");
      constantes3.set_CONS_Desc_SPA("SEPARADA");
      Constantes constantes4 = constantes3;
      observableCollection3.Add(constantes4);
      ObservableCollection<Constantes> observableCollection4 = observableCollection1;
      Constantes constantes5 = new Constantes();
      constantes5.set_CONS_CodTipo("D");
      constantes5.set_CONS_CodTabla("CHEQU_D");
      constantes5.set_CONS_Desc_SPA("SIN USO");
      Constantes constantes6 = constantes5;
      observableCollection4.Add(constantes6);
      ObservableCollection<Constantes> observableCollection5 = observableCollection1;
      Constantes constantes7 = new Constantes();
      constantes7.set_CONS_CodTipo("C");
      constantes7.set_CONS_CodTabla("CHEQU_C");
      constantes7.set_CONS_Desc_SPA("CERRADA");
      Constantes constantes8 = constantes7;
      observableCollection5.Add(constantes8);
      return observableCollection1;
    }

    public ObservableCollection<Constantes> getTipoChequera()
    {
      ObservableCollection<Constantes> observableCollection1 = new ObservableCollection<Constantes>();
      ObservableCollection<Constantes> observableCollection2 = observableCollection1;
      Constantes constantes1 = new Constantes();
      constantes1.set_CONS_CodTipo("N");
      constantes1.set_CONS_CodTabla("TCHEQU_N");
      constantes1.set_CONS_Desc_SPA("NORMAL");
      Constantes constantes2 = constantes1;
      observableCollection2.Add(constantes2);
      ObservableCollection<Constantes> observableCollection3 = observableCollection1;
      Constantes constantes3 = new Constantes();
      constantes3.set_CONS_CodTipo("D");
      constantes3.set_CONS_CodTabla("TCHEQU_D");
      constantes3.set_CONS_Desc_SPA("DIFERIDO");
      Constantes constantes4 = constantes3;
      observableCollection3.Add(constantes4);
      return observableCollection1;
    }

    public ObservableCollection<Constantes> getEstadoLiquidacion()
    {
      ObservableCollection<Constantes> observableCollection1 = new ObservableCollection<Constantes>();
      ObservableCollection<Constantes> observableCollection2 = observableCollection1;
      Constantes constantes1 = new Constantes();
      constantes1.set_CONS_CodTipo("A");
      constantes1.set_CONS_CodTabla("LIQU_A");
      constantes1.set_CONS_Desc_SPA("ABIERTO");
      Constantes constantes2 = constantes1;
      observableCollection2.Add(constantes2);
      ObservableCollection<Constantes> observableCollection3 = observableCollection1;
      Constantes constantes3 = new Constantes();
      constantes3.set_CONS_CodTipo("C");
      constantes3.set_CONS_CodTabla("LIQU_C");
      constantes3.set_CONS_Desc_SPA("CERRADO");
      Constantes constantes4 = constantes3;
      observableCollection3.Add(constantes4);
      return observableCollection1;
    }

    public ObservableCollection<Constantes> getUnidadNegocio()
    {
      ObservableCollection<Constantes> observableCollection1 = new ObservableCollection<Constantes>();
      ObservableCollection<Constantes> observableCollection2 = observableCollection1;
      Constantes constantes1 = new Constantes();
      constantes1.set_CONS_CodTipo("M");
      constantes1.set_CONS_CodTabla("UNEG_MAN");
      constantes1.set_CONS_Desc_SPA("MANDATO");
      Constantes constantes2 = constantes1;
      observableCollection2.Add(constantes2);
      ObservableCollection<Constantes> observableCollection3 = observableCollection1;
      Constantes constantes3 = new Constantes();
      constantes3.set_CONS_CodTipo("S");
      constantes3.set_CONS_CodTabla("UNEG_SLI");
      constantes3.set_CONS_Desc_SPA("SLI");
      Constantes constantes4 = constantes3;
      observableCollection3.Add(constantes4);
      ObservableCollection<Constantes> observableCollection4 = observableCollection1;
      Constantes constantes5 = new Constantes();
      constantes5.set_CONS_CodTipo("E");
      constantes5.set_CONS_CodTabla("UNEG_EXP");
      constantes5.set_CONS_Desc_SPA("EXPORTACIÓN");
      Constantes constantes6 = constantes5;
      observableCollection4.Add(constantes6);
      ObservableCollection<Constantes> observableCollection5 = observableCollection1;
      Constantes constantes7 = new Constantes();
      constantes7.set_CONS_CodTipo("O");
      constantes7.set_CONS_CodTabla("UNEG_OTR");
      constantes7.set_CONS_Desc_SPA("OTROS TRAFICOS");
      Constantes constantes8 = constantes7;
      observableCollection5.Add(constantes8);
      return observableCollection1;
    }

    public ObservableCollection<Constantes> getTipoPlantilla()
    {
      ObservableCollection<Constantes> observableCollection1 = new ObservableCollection<Constantes>();
      ObservableCollection<Constantes> observableCollection2 = observableCollection1;
      Constantes constantes1 = new Constantes();
      constantes1.set_CONS_CodTipo("WWW");
      constantes1.set_CONS_CodTabla("TPLA_WWW");
      constantes1.set_CONS_Desc_SPA("MEDIO VIRTUAL");
      Constantes constantes2 = constantes1;
      observableCollection2.Add(constantes2);
      ObservableCollection<Constantes> observableCollection3 = observableCollection1;
      Constantes constantes3 = new Constantes();
      constantes3.set_CONS_CodTipo("DET");
      constantes3.set_CONS_CodTabla("TPLA_DET");
      constantes3.set_CONS_Desc_SPA("DETRACCIONES");
      Constantes constantes4 = constantes3;
      observableCollection3.Add(constantes4);
      return observableCollection1;
    }

    public ObservableCollection<Constantes> getLimiteCreditoFormaPago()
    {
      ObservableCollection<Constantes> observableCollection1 = new ObservableCollection<Constantes>();
      ObservableCollection<Constantes> observableCollection2 = observableCollection1;
      Constantes constantes1 = new Constantes();
      constantes1.set_CONS_CodTipo("D");
      constantes1.set_CONS_CodTabla("ENLI_C");
      constantes1.set_CONS_Desc_SPA("CHEQUE DIFERIDO");
      Constantes constantes2 = constantes1;
      observableCollection2.Add(constantes2);
      ObservableCollection<Constantes> observableCollection3 = observableCollection1;
      Constantes constantes3 = new Constantes();
      constantes3.set_CONS_CodTipo("C");
      constantes3.set_CONS_CodTabla("ENLI_D");
      constantes3.set_CONS_Desc_SPA("CONTRA DOCUMENTO");
      Constantes constantes4 = constantes3;
      observableCollection3.Add(constantes4);
      return observableCollection1;
    }

    public ObservableCollection<Constantes> getEstadoCheque()
    {
      ObservableCollection<Constantes> observableCollection1 = new ObservableCollection<Constantes>();
      ObservableCollection<Constantes> observableCollection2 = observableCollection1;
      Constantes constantes1 = new Constantes();
      constantes1.set_CONS_CodTipo("B");
      constantes1.set_CONS_CodTabla("ECHE_B");
      constantes1.set_CONS_Desc_SPA("CHEQUE EN BLANCO");
      Constantes constantes2 = constantes1;
      observableCollection2.Add(constantes2);
      ObservableCollection<Constantes> observableCollection3 = observableCollection1;
      Constantes constantes3 = new Constantes();
      constantes3.set_CONS_CodTipo("C");
      constantes3.set_CONS_CodTabla("ECHE_C");
      constantes3.set_CONS_Desc_SPA("CHEQUE EN CARTERA");
      Constantes constantes4 = constantes3;
      observableCollection3.Add(constantes4);
      ObservableCollection<Constantes> observableCollection4 = observableCollection1;
      Constantes constantes5 = new Constantes();
      constantes5.set_CONS_CodTipo("E");
      constantes5.set_CONS_CodTabla("ECHE_E");
      constantes5.set_CONS_Desc_SPA("CHEQUE ENTREGADO");
      Constantes constantes6 = constantes5;
      observableCollection4.Add(constantes6);
      return observableCollection1;
    }

    public ObservableCollection<Constantes> getCodificacion()
    {
      ObservableCollection<Constantes> observableCollection1 = new ObservableCollection<Constantes>();
      ObservableCollection<Constantes> observableCollection2 = observableCollection1;
      Constantes constantes1 = new Constantes();
      constantes1.set_CONS_CodTipo("0000");
      constantes1.set_CONS_CodTabla("0000");
      constantes1.set_CONS_Desc_SPA("Default");
      Constantes constantes2 = constantes1;
      observableCollection2.Add(constantes2);
      ObservableCollection<Constantes> observableCollection3 = observableCollection1;
      Constantes constantes3 = new Constantes();
      constantes3.set_CONS_CodTipo("1252");
      constantes3.set_CONS_CodTabla("1252");
      constantes3.set_CONS_Desc_SPA("Codificación 1252");
      Constantes constantes4 = constantes3;
      observableCollection3.Add(constantes4);
      ObservableCollection<Constantes> observableCollection4 = observableCollection1;
      Constantes constantes5 = new Constantes();
      constantes5.set_CONS_CodTipo("UTF-8");
      constantes5.set_CONS_CodTabla("UTF-8");
      constantes5.set_CONS_Desc_SPA("Codificación UTF-8");
      Constantes constantes6 = constantes5;
      observableCollection4.Add(constantes6);
      ObservableCollection<Constantes> observableCollection5 = observableCollection1;
      Constantes constantes7 = new Constantes();
      constantes7.set_CONS_CodTipo("ASCII");
      constantes7.set_CONS_CodTabla("ASCII");
      constantes7.set_CONS_Desc_SPA("Codificación ASCII");
      Constantes constantes8 = constantes7;
      observableCollection5.Add(constantes8);
      ObservableCollection<Constantes> observableCollection6 = observableCollection1;
      Constantes constantes9 = new Constantes();
      constantes9.set_CONS_CodTipo("UTF-7");
      constantes9.set_CONS_CodTabla("UTF-7");
      constantes9.set_CONS_Desc_SPA("Codificación UTF-7");
      Constantes constantes10 = constantes9;
      observableCollection6.Add(constantes10);
      ObservableCollection<Constantes> observableCollection7 = observableCollection1;
      Constantes constantes11 = new Constantes();
      constantes11.set_CONS_CodTipo("UTF-32");
      constantes11.set_CONS_CodTabla("UTF-32");
      constantes11.set_CONS_Desc_SPA("Codificación UTF-32");
      Constantes constantes12 = constantes11;
      observableCollection7.Add(constantes12);
      ObservableCollection<Constantes> observableCollection8 = observableCollection1;
      Constantes constantes13 = new Constantes();
      constantes13.set_CONS_CodTipo("Unicode");
      constantes13.set_CONS_CodTabla("Unicode");
      constantes13.set_CONS_Desc_SPA("Codificación Unicode");
      Constantes constantes14 = constantes13;
      observableCollection8.Add(constantes14);
      ObservableCollection<Constantes> observableCollection9 = observableCollection1;
      Constantes constantes15 = new Constantes();
      constantes15.set_CONS_CodTipo("ANSI");
      constantes15.set_CONS_CodTabla("ANSI");
      constantes15.set_CONS_Desc_SPA("Codificación ANSI");
      Constantes constantes16 = constantes15;
      observableCollection9.Add(constantes16);
      return observableCollection1;
    }

    public ObservableCollection<Constantes> getTipoFacturacion()
    {
      return new ObservableCollection<Constantes>();
    }

    public ObservableCollection<Constantes> getTipoDocumento(ComboBoxConstantes.OConstantes x_otrasConstantes)
    {
      ObservableCollection<Constantes> observableCollection1 = new ObservableCollection<Constantes>();
      if (x_otrasConstantes == ComboBoxConstantes.OConstantes.TipoDocumentoIngresos)
      {
        ObservableCollection<Constantes> observableCollection2 = observableCollection1;
        Constantes constantes1 = new Constantes();
        constantes1.set_CONS_CodTipo("OV");
        constantes1.set_CONS_CodTabla("TDOC_OV");
        constantes1.set_CONS_Desc_SPA("ORDEN DE VENTA");
        Constantes constantes2 = constantes1;
        observableCollection2.Add(constantes2);
        ObservableCollection<Constantes> observableCollection3 = observableCollection1;
        Constantes constantes3 = new Constantes();
        constantes3.set_CONS_CodTipo("OP");
        constantes3.set_CONS_CodTabla("TDOC_OP");
        constantes3.set_CONS_Desc_SPA("LOGISTICO");
        Constantes constantes4 = constantes3;
        observableCollection3.Add(constantes4);
        ObservableCollection<Constantes> observableCollection4 = observableCollection1;
        Constantes constantes5 = new Constantes();
        constantes5.set_CONS_CodTipo("OT");
        constantes5.set_CONS_CodTabla("TDOC_OT");
        constantes5.set_CONS_Desc_SPA("OTROS");
        Constantes constantes6 = constantes5;
        observableCollection4.Add(constantes6);
      }
      if (x_otrasConstantes == ComboBoxConstantes.OConstantes.TipoDocumentoEgresos)
      {
        ObservableCollection<Constantes> observableCollection2 = observableCollection1;
        Constantes constantes1 = new Constantes();
        constantes1.set_CONS_CodTipo("EG");
        constantes1.set_CONS_CodTabla("TDOC_EG");
        constantes1.set_CONS_Desc_SPA("EGRESOS");
        Constantes constantes2 = constantes1;
        observableCollection2.Add(constantes2);
        ObservableCollection<Constantes> observableCollection3 = observableCollection1;
        Constantes constantes3 = new Constantes();
        constantes3.set_CONS_CodTipo("LI");
        constantes3.set_CONS_CodTabla("TDOC_LI");
        constantes3.set_CONS_Desc_SPA("LIQUIDACIONES");
        Constantes constantes4 = constantes3;
        observableCollection3.Add(constantes4);
      }
      return observableCollection1;
    }

    public ObservableCollection<Constantes> getTipoPeriodo()
    {
      ObservableCollection<Constantes> observableCollection1 = new ObservableCollection<Constantes>();
      ObservableCollection<Constantes> observableCollection2 = observableCollection1;
      Constantes constantes1 = new Constantes();
      constantes1.set_CONS_CodTipo("A");
      constantes1.set_CONS_CodTabla("PERIODO");
      constantes1.set_CONS_Desc_SPA("ANUAL");
      Constantes constantes2 = constantes1;
      observableCollection2.Add(constantes2);
      ObservableCollection<Constantes> observableCollection3 = observableCollection1;
      Constantes constantes3 = new Constantes();
      constantes3.set_CONS_CodTipo("M");
      constantes3.set_CONS_CodTabla("PERIODO");
      constantes3.set_CONS_Desc_SPA("MENSUAL");
      Constantes constantes4 = constantes3;
      observableCollection3.Add(constantes4);
      return observableCollection1;
    }

    public ObservableCollection<Constantes> getTipoFlujo()
    {
      ObservableCollection<Constantes> observableCollection1 = new ObservableCollection<Constantes>();
      ObservableCollection<Constantes> observableCollection2 = observableCollection1;
      Constantes constantes1 = new Constantes();
      constantes1.set_CONS_CodTipo("F");
      constantes1.set_CONS_CodTabla("TF_F");
      constantes1.set_CONS_Desc_SPA("FINANCIERO");
      Constantes constantes2 = constantes1;
      observableCollection2.Add(constantes2);
      ObservableCollection<Constantes> observableCollection3 = observableCollection1;
      Constantes constantes3 = new Constantes();
      constantes3.set_CONS_CodTipo("O");
      constantes3.set_CONS_CodTabla("TF_O");
      constantes3.set_CONS_Desc_SPA("OPERATIVO");
      Constantes constantes4 = constantes3;
      observableCollection3.Add(constantes4);
      return observableCollection1;
    }

    public ObservableCollection<Constantes> GetTipoMovimiento()
    {
      ObservableCollection<Constantes> observableCollection1 = new ObservableCollection<Constantes>();
      ObservableCollection<Constantes> observableCollection2 = observableCollection1;
      Constantes constantes1 = new Constantes();
      constantes1.set_CONS_CodTipo("I");
      constantes1.set_CONS_CodTabla("TM_I");
      constantes1.set_CONS_Desc_SPA("INGRESO");
      Constantes constantes2 = constantes1;
      observableCollection2.Add(constantes2);
      ObservableCollection<Constantes> observableCollection3 = observableCollection1;
      Constantes constantes3 = new Constantes();
      constantes3.set_CONS_CodTipo("E");
      constantes3.set_CONS_CodTabla("TM_E");
      constantes3.set_CONS_Desc_SPA("EGRESO");
      Constantes constantes4 = constantes3;
      observableCollection3.Add(constantes4);
      return observableCollection1;
    }

    public ObservableCollection<Constantes> GetTipoMovimientoDB()
    {
      ObservableCollection<Constantes> observableCollection1 = new ObservableCollection<Constantes>();
      ObservableCollection<Constantes> observableCollection2 = observableCollection1;
      Constantes constantes1 = new Constantes();
      constantes1.set_CONS_CodTipo("I");
      constantes1.set_CONS_CodTabla("TM_I");
      constantes1.set_CONS_Desc_SPA("DEBE");
      Constantes constantes2 = constantes1;
      observableCollection2.Add(constantes2);
      ObservableCollection<Constantes> observableCollection3 = observableCollection1;
      Constantes constantes3 = new Constantes();
      constantes3.set_CONS_CodTipo("E");
      constantes3.set_CONS_CodTabla("TM_E");
      constantes3.set_CONS_Desc_SPA("HABER");
      Constantes constantes4 = constantes3;
      observableCollection3.Add(constantes4);
      return observableCollection1;
    }

    public ObservableCollection<Constantes> getTipoFechaVencimiento()
    {
      ObservableCollection<Constantes> observableCollection1 = new ObservableCollection<Constantes>();
      ObservableCollection<Constantes> observableCollection2 = observableCollection1;
      Constantes constantes1 = new Constantes();
      constantes1.set_CONS_CodTipo("E");
      constantes1.set_CONS_CodTabla("ECHE_B");
      constantes1.set_CONS_Desc_SPA("FECHA DE EMISIÓN");
      Constantes constantes2 = constantes1;
      observableCollection2.Add(constantes2);
      ObservableCollection<Constantes> observableCollection3 = observableCollection1;
      Constantes constantes3 = new Constantes();
      constantes3.set_CONS_CodTipo("T");
      constantes3.set_CONS_CodTabla("ECHE_C");
      constantes3.set_CONS_Desc_SPA("FECHA ETA");
      Constantes constantes4 = constantes3;
      observableCollection3.Add(constantes4);
      return observableCollection1;
    }

    public ObservableCollection<Constantes> getTipoAsiento()
    {
      ObservableCollection<Constantes> observableCollection1 = new ObservableCollection<Constantes>();
      ObservableCollection<Constantes> observableCollection2 = observableCollection1;
      Constantes constantes1 = new Constantes();
      constantes1.set_CONS_CodTipo("CD");
      constantes1.set_CONS_CodTabla("TIPOASIENTO_CD");
      constantes1.set_CONS_Desc_SPA("ASIENTOS DE COMPRA - CON DETRACCION");
      Constantes constantes2 = constantes1;
      observableCollection2.Add(constantes2);
      ObservableCollection<Constantes> observableCollection3 = observableCollection1;
      Constantes constantes3 = new Constantes();
      constantes3.set_CONS_CodTipo("CS");
      constantes3.set_CONS_CodTabla("TIPOASIENTO_CS");
      constantes3.set_CONS_Desc_SPA("ASIENTOS DE COMPRA - SIN DETRACCION");
      Constantes constantes4 = constantes3;
      observableCollection3.Add(constantes4);
      ObservableCollection<Constantes> observableCollection4 = observableCollection1;
      Constantes constantes5 = new Constantes();
      constantes5.set_CONS_CodTipo("VE");
      constantes5.set_CONS_CodTabla("TIPOASIENTO_VE");
      constantes5.set_CONS_Desc_SPA("ASIENTOS DE VENTAS");
      Constantes constantes6 = constantes5;
      observableCollection4.Add(constantes6);
      ObservableCollection<Constantes> observableCollection5 = observableCollection1;
      Constantes constantes7 = new Constantes();
      constantes7.set_CONS_CodTipo("ST");
      constantes7.set_CONS_CodTabla("TIPOASIENTO_ST");
      constantes7.set_CONS_Desc_SPA("ASIENTOS DE STATEMENT");
      Constantes constantes8 = constantes7;
      observableCollection5.Add(constantes8);
      ObservableCollection<Constantes> observableCollection6 = observableCollection1;
      Constantes constantes9 = new Constantes();
      constantes9.set_CONS_CodTipo("CN");
      constantes9.set_CONS_CodTabla("TIPOASIENTO_CN");
      constantes9.set_CONS_Desc_SPA("ASIENTOS DE CANCELACIONES");
      Constantes constantes10 = constantes9;
      observableCollection6.Add(constantes10);
      ObservableCollection<Constantes> observableCollection7 = observableCollection1;
      Constantes constantes11 = new Constantes();
      constantes11.set_CONS_CodTipo("PG");
      constantes11.set_CONS_CodTabla("TIPOASIENTO_PG");
      constantes11.set_CONS_Desc_SPA("ASIENTOS DE PAGOS");
      Constantes constantes12 = constantes11;
      observableCollection7.Add(constantes12);
      return observableCollection1;
    }

    public ObservableCollection<Constantes> getTipoAsientorRegistro()
    {
      ObservableCollection<Constantes> observableCollection1 = new ObservableCollection<Constantes>();
      ObservableCollection<Constantes> observableCollection2 = observableCollection1;
      Constantes constantes1 = new Constantes();
      constantes1.set_CONS_CodTipo("11");
      constantes1.set_CONS_CodTabla("TIPOASIENTO_11");
      constantes1.set_CONS_Desc_SPA("[11]");
      Constantes constantes2 = constantes1;
      observableCollection2.Add(constantes2);
      ObservableCollection<Constantes> observableCollection3 = observableCollection1;
      Constantes constantes3 = new Constantes();
      constantes3.set_CONS_CodTipo("18");
      constantes3.set_CONS_CodTabla("TIPOASIENTO_18");
      constantes3.set_CONS_Desc_SPA("[18]");
      Constantes constantes4 = constantes3;
      observableCollection3.Add(constantes4);
      ObservableCollection<Constantes> observableCollection4 = observableCollection1;
      Constantes constantes5 = new Constantes();
      constantes5.set_CONS_CodTipo("05");
      constantes5.set_CONS_CodTabla("TIPOASIENTO_05");
      constantes5.set_CONS_Desc_SPA("[05]");
      Constantes constantes6 = constantes5;
      observableCollection4.Add(constantes6);
      ObservableCollection<Constantes> observableCollection5 = observableCollection1;
      Constantes constantes7 = new Constantes();
      constantes7.set_CONS_CodTipo("40");
      constantes7.set_CONS_CodTabla("TIPOASIENTO_40");
      constantes7.set_CONS_Desc_SPA("[40]");
      Constantes constantes8 = constantes7;
      observableCollection5.Add(constantes8);
      ObservableCollection<Constantes> observableCollection6 = observableCollection1;
      Constantes constantes9 = new Constantes();
      constantes9.set_CONS_CodTipo("43");
      constantes9.set_CONS_CodTabla("TIPOASIENTO_43");
      constantes9.set_CONS_Desc_SPA("[43]");
      Constantes constantes10 = constantes9;
      observableCollection6.Add(constantes10);
      ObservableCollection<Constantes> observableCollection7 = observableCollection1;
      Constantes constantes11 = new Constantes();
      constantes11.set_CONS_CodTipo("09");
      constantes11.set_CONS_CodTabla("TIPOASIENTO_09");
      constantes11.set_CONS_Desc_SPA("[09]");
      Constantes constantes12 = constantes11;
      observableCollection7.Add(constantes12);
      ObservableCollection<Constantes> observableCollection8 = observableCollection1;
      Constantes constantes13 = new Constantes();
      constantes13.set_CONS_CodTipo("44");
      constantes13.set_CONS_CodTabla("TIPOASIENTO_44");
      constantes13.set_CONS_Desc_SPA("[44]");
      Constantes constantes14 = constantes13;
      observableCollection8.Add(constantes14);
      ObservableCollection<Constantes> observableCollection9 = observableCollection1;
      Constantes constantes15 = new Constantes();
      constantes15.set_CONS_CodTipo("10");
      constantes15.set_CONS_CodTabla("TIPOASIENTO_10");
      constantes15.set_CONS_Desc_SPA("[10]");
      Constantes constantes16 = constantes15;
      observableCollection9.Add(constantes16);
      ObservableCollection<Constantes> observableCollection10 = observableCollection1;
      Constantes constantes17 = new Constantes();
      constantes17.set_CONS_CodTipo("16");
      constantes17.set_CONS_CodTabla("TIPOASIENTO_16");
      constantes17.set_CONS_Desc_SPA("[16]");
      Constantes constantes18 = constantes17;
      observableCollection10.Add(constantes18);
      ObservableCollection<Constantes> observableCollection11 = observableCollection1;
      Constantes constantes19 = new Constantes();
      constantes19.set_CONS_CodTipo("30");
      constantes19.set_CONS_CodTabla("TIPOASIENTO_30");
      constantes19.set_CONS_Desc_SPA("[30]");
      Constantes constantes20 = constantes19;
      observableCollection11.Add(constantes20);
      return observableCollection1;
    }

    public ObservableCollection<Constantes> GetTipoRegistroReporte()
    {
      ObservableCollection<Constantes> observableCollection1 = new ObservableCollection<Constantes>();
      ObservableCollection<Constantes> observableCollection2 = observableCollection1;
      Constantes constantes1 = new Constantes();
      constantes1.set_CONS_CodTipo("E");
      constantes1.set_CONS_CodTabla("TM_P");
      constantes1.set_CONS_Desc_SPA("POR PAGAR");
      Constantes constantes2 = constantes1;
      observableCollection2.Add(constantes2);
      ObservableCollection<Constantes> observableCollection3 = observableCollection1;
      Constantes constantes3 = new Constantes();
      constantes3.set_CONS_CodTipo("I");
      constantes3.set_CONS_CodTabla("TM_C");
      constantes3.set_CONS_Desc_SPA("POR COBRAR");
      Constantes constantes4 = constantes3;
      observableCollection3.Add(constantes4);
      return observableCollection1;
    }

    public ObservableCollection<Constantes> GetDocOrigen()
    {
      ObservableCollection<Constantes> observableCollection1 = new ObservableCollection<Constantes>();
      ObservableCollection<Constantes> observableCollection2 = observableCollection1;
      Constantes constantes1 = new Constantes();
      constantes1.set_CONS_CodTipo("OP");
      constantes1.set_CONS_CodTabla("DO_OP");
      constantes1.set_CONS_Desc_SPA("Operaciones - Logistico");
      Constantes constantes2 = constantes1;
      observableCollection2.Add(constantes2);
      ObservableCollection<Constantes> observableCollection3 = observableCollection1;
      Constantes constantes3 = new Constantes();
      constantes3.set_CONS_CodTipo("OV");
      constantes3.set_CONS_CodTabla("DO_OV");
      constantes3.set_CONS_Desc_SPA("Ordenes de Venta");
      Constantes constantes4 = constantes3;
      observableCollection3.Add(constantes4);
      return observableCollection1;
    }

    public ObservableCollection<Constantes> GetTipoResultadoRepOT()
    {
      ObservableCollection<Constantes> observableCollection1 = new ObservableCollection<Constantes>();
      ObservableCollection<Constantes> observableCollection2 = observableCollection1;
      Constantes constantes1 = new Constantes();
      constantes1.set_CONS_CodTipo("O");
      constantes1.set_CONS_CodTabla("DO_O");
      constantes1.set_CONS_Desc_SPA("Documentos de Otros Tráficos");
      Constantes constantes2 = constantes1;
      observableCollection2.Add(constantes2);
      ObservableCollection<Constantes> observableCollection3 = observableCollection1;
      Constantes constantes3 = new Constantes();
      constantes3.set_CONS_CodTipo("M");
      constantes3.set_CONS_CodTabla("DO_M");
      constantes3.set_CONS_Desc_SPA("Documentos de Mandato");
      Constantes constantes4 = constantes3;
      observableCollection3.Add(constantes4);
      return observableCollection1;
    }

    public void LoadControl(string x_titulo, ComboBoxConstantes.OConstantes x_otrasConstantes, string x_firstElement, ListSortDirection x_sortItems)
    {
      try
      {
        switch (x_otrasConstantes)
        {
          case ComboBoxConstantes.OConstantes.SERV_TipoMov:
            this.ListConstantes = this.getSERV_TipoMov();
            break;
          case ComboBoxConstantes.OConstantes.TipoCuenta:
            this.ListConstantes = this.getTipoCuenta();
            break;
          case ComboBoxConstantes.OConstantes.NVIA_Estado:
            this.ListConstantes = this.getNVIA_Estado();
            break;
          case ComboBoxConstantes.OConstantes.TIPO_RelacionEntidad:
            this.ListConstantes = this.getTipoEntidad_Relacion();
            break;
          case ComboBoxConstantes.OConstantes.LimiteCreditoCliente:
            this.ListConstantes = this.getLimiteCredito();
            break;
          case ComboBoxConstantes.OConstantes.TipoDocumentoIngresos:
            this.ListConstantes = this.getTipoDocumento(x_otrasConstantes);
            break;
          case ComboBoxConstantes.OConstantes.TipoDocumentoEgresos:
            this.ListConstantes = this.getTipoDocumento(x_otrasConstantes);
            break;
          case ComboBoxConstantes.OConstantes.EstadoChequera:
            this.ListConstantes = this.getEstadoChequera();
            break;
          case ComboBoxConstantes.OConstantes.TipoChequera:
            this.ListConstantes = this.getTipoChequera();
            break;
          case ComboBoxConstantes.OConstantes.EstadoLiquidacion:
            this.ListConstantes = this.getEstadoLiquidacion();
            break;
          case ComboBoxConstantes.OConstantes.UnidadNegocio:
            this.ListConstantes = this.getUnidadNegocio();
            break;
          case ComboBoxConstantes.OConstantes.TipoPlantilla:
            this.ListConstantes = this.getTipoPlantilla();
            break;
          case ComboBoxConstantes.OConstantes.LimiteCreditoFormaPago:
            this.ListConstantes = this.getLimiteCreditoFormaPago();
            break;
          case ComboBoxConstantes.OConstantes.EstadoCheque:
            this.ListConstantes = this.getEstadoCheque();
            break;
          case ComboBoxConstantes.OConstantes.Codificacion:
            this.ListConstantes = this.getCodificacion();
            break;
          case ComboBoxConstantes.OConstantes.TipoFacturacion:
            this.ListConstantes = this.getTipoFacturacion();
            break;
          case ComboBoxConstantes.OConstantes.TipoPeriodo:
            this.ListConstantes = this.getTipoPeriodo();
            break;
          case ComboBoxConstantes.OConstantes.TipoFlujo:
            this.ListConstantes = this.getTipoFlujo();
            break;
          case ComboBoxConstantes.OConstantes.TipoMovimiento:
            this.ListConstantes = this.GetTipoMovimiento();
            break;
          case ComboBoxConstantes.OConstantes.TipoFechaVencimiento:
            this.ListConstantes = this.getTipoFechaVencimiento();
            break;
          case ComboBoxConstantes.OConstantes.GeneracionTipoAsiento:
            this.ListConstantes = this.getTipoAsiento();
            break;
          case ComboBoxConstantes.OConstantes.GeneracionTipoAsientoRegistro:
            this.ListConstantes = this.getTipoAsientorRegistro();
            break;
          case ComboBoxConstantes.OConstantes.TipoRegistroReporte:
            this.ListConstantes = this.GetTipoRegistroReporte();
            break;
          case ComboBoxConstantes.OConstantes.DocOrigen:
            this.ListConstantes = this.GetDocOrigen();
            break;
          case ComboBoxConstantes.OConstantes.TipoResultadoRepOT:
            this.ListConstantes = this.GetTipoResultadoRepOT();
            break;
          case ComboBoxConstantes.OConstantes.TipoMovimientoDB:
            this.ListConstantes = this.GetTipoMovimientoDB();
            break;
        }
        switch (x_sortItems)
        {
          case ListSortDirection.Ascending:
            this.ListConstantes = (ObservableCollection<Constantes>) ObservableCollectionExtension.ToObservableCollection<Constantes>((IEnumerable<M0>) ((IEnumerable<Constantes>) this.ListConstantes).OrderBy<Constantes, string>((Func<Constantes, string>) (tipo => tipo.get_CONS_Desc_SPA())));
            break;
          case ListSortDirection.Descending:
            this.ListConstantes = (ObservableCollection<Constantes>) ObservableCollectionExtension.ToObservableCollection<Constantes>((IEnumerable<M0>) ((IEnumerable<Constantes>) this.ListConstantes).OrderByDescending<Constantes, string>((Func<Constantes, string>) (tipo => tipo.get_CONS_Desc_SPA())));
            break;
        }
        if (x_firstElement != null)
        {
          ObservableCollection<Constantes> listConstantes = this.ListConstantes;
          int index = 0;
          Constantes constantes1 = new Constantes();
          constantes1.set_CONS_Desc_SPA(x_firstElement);
          Constantes constantes2 = constantes1;
          listConstantes.Insert(index, constantes2);
        }
        this.DataSource = (object) this.ListConstantes;
        this.ValueMember = "CONS_CodTipo";
        this.DisplayMember = "CONS_Desc_SPA";
        if (this.ListConstantes == null || this.ListConstantes.Count <= 0)
          return;
        this.SelectedItem = (object) ((IEnumerable<Constantes>) this.ListConstantes).ElementAt<Constantes>(0);
      }
      catch (Exception ex)
      {
        int num = (int) Dialogos.MostrarMensajeError(this.ConstantesTitulo, "Ha ocurrido un error al cargar los datos constantes.", ex);
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

    public enum OConstantes
    {
      SERV_TipoMov,
      TipoCuenta,
      NVIA_Estado,
      TIPO_RelacionEntidad,
      LimiteCreditoCliente,
      TipoDocumentoIngresos,
      TipoDocumentoEgresos,
      EstadoChequera,
      TipoChequera,
      EstadoLiquidacion,
      UnidadNegocio,
      TipoPlantilla,
      LimiteCreditoFormaPago,
      EstadoCheque,
      Codificacion,
      TipoFacturacion,
      TipoPeriodo,
      TipoFlujo,
      TipoMovimiento,
      TipoFechaVencimiento,
      GeneracionTipoAsiento,
      GeneracionTipoAsientoRegistro,
      TipoRegistroReporte,
      DocOrigen,
      TipoResultadoRepOT,
      TipoMovimientoDB,
    }
  }
}
