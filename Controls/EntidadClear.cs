// Decompiled with JetBrains decompiler
// Type: Delfin.Controls.EntidadClear
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
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace Delfin.Controls
{
  public class EntidadClear : TextBoxAyuda
  {
    public const short TIPE_Cliente = 1;
    public const short TIPE_Proveedor = 2;
    public const short TIPE_Ejecutivo = 3;
    public const short TIPE_CustomerService = 4;
    public const short TIPE_Transportista = 5;
    public const short TIPE_Agente = 6;
    public const short TIPE_Broker = 7;
    public const short TIPE_AgenteCarga = 8;
    public const short TIPE_Contacto = 9;
    public const short TIPE_Shipper = 10;
    public const short TIPE_AgentePortuario = 11;
    public const short TIPE_AgenciaAduanera = 12;
    public const short TIPE_AgenciaMaritima = 13;
    public const short TIPE_DepositoTemporal = 14;
    public const short TIPE_DepositoVacio = 15;
    public const short TIPE_Empleado = 16;
    public string Title;
    private IContainer components;

    public string TIPO_CodCRG { get; set; }

    public EntidadClear()
    {
      base.\u002Ector();
      this.InitializeComponent();
      this.InitializeEntidad();
    }

    public EntidadClear(IContainer container)
    {
      base.\u002Ector();
      container.Add((IComponent) this);
      this.InitializeComponent();
      this.InitializeEntidad();
    }

    private void InitializeEntidad()
    {
      try
      {
        ((TextBox) this).CharacterCasing = CharacterCasing.Upper;
        ((TextBoxBase) this).MaxLength = 100;
        this.TipoEntidad = TiposEntidad.TIPE_Cliente;
        ((Control) this).Size = new Size(100, 21);
        this.add_AyudaClick(new EventHandler(this.Entidad_AyudaClick));
        this.add_AyudaClean(new EventHandler(this.Entidad_AyudaClean));
        this.add_AyudaValueChanged(new EventHandler(this.Entidad_AyudaValueChanged));
      }
      catch (Exception ex)
      {
      }
    }

    public void LoadControl(IUnityContainer Container, string x_title, TiposEntidad x_tipoentidad, string x_tipo_codcrg, bool x_soloentidad = false)
    {
      try
      {
        this.Client = (IDelfinServices) UnityContainerExtensions.Resolve<IDelfinServices>(Container, new ResolverOverride[0]);
        this.SoloEntidad = x_soloentidad;
        this.Title = x_title;
        this.TIPO_CodCRG = x_tipo_codcrg;
      }
      catch (Exception ex)
      {
      }
    }

    private IDelfinServices Client { get; set; }

    public Entidad SelectedItem
    {
      get
      {
        if (this.get_Value() != null && this.get_Value() is Entidad)
          return this.get_Value() as Entidad;
        return (Entidad) null;
      }
      set
      {
        if (value != null)
          this.SetValue((object) value, value.get_ENTC_NomCompleto());
        else
          this.ClearValue();
      }
    }

    public TiposEntidad TipoEntidad { get; set; }

    public bool PorDocIden { get; set; }

    public bool CrearNuevaEntidad { get; set; }

    public bool SoloEntidad { get; set; }

    public void AyudaEntidad()
    {
      try
      {
        string text = ((Control) this).Text;
        if (this.Client == null)
          return;
        ObservableCollection<Entidad> observableCollection = new ObservableCollection<Entidad>();
        DataTable dataTable1 = new DataTable();
        DataTable dataTable2;
        if (this.PorDocIden)
        {
          dataTable2 = IEnumerableExtensions.ToDataTable<Entidad>(this.TIPO_CodCRG == null ? (IEnumerable<M0>) this.Client.GetAllEntidadByTipoEntidadAndText(EntidadClear.GetCodigoTipoEntidad(this.TipoEntidad), (string) null, true, ((Control) this).Text) : (IEnumerable<M0>) this.Client.GetAllEntidadByTipoEntidadAndText(EntidadClear.GetCodigoTipoEntidad(this.TipoEntidad), (string) null, true, ((Control) this).Text));
          dataTable2.DefaultView.Sort = "ENTC_DocIden";
        }
        else
        {
          dataTable2 = IEnumerableExtensions.ToDataTable<Entidad>(this.TIPO_CodCRG == null ? (IEnumerable<M0>) this.Client.GetAllEntidadByTipoEntidadAndText(EntidadClear.GetCodigoTipoEntidad(this.TipoEntidad), ((Control) this).Text, true, (string) null) : (IEnumerable<M0>) this.Client.GetAllEntidadByTipoEntidadAndText(EntidadClear.GetCodigoTipoEntidad(this.TipoEntidad), ((Control) this).Text, true, (string) null));
          dataTable2.DefaultView.Sort = "ENTC_NomCompleto";
        }
        if (dataTable2.Rows.Count == 0)
        {
          if (this.CrearNuevaEntidad)
          {
            if (Dialogos.MostrarMensajePregunta(this.Title, "No se encontraron coincidencias ¿Desea crear un nuevo registro?.", (Dialogos.LabelBoton) 1) != DialogResult.Yes || this.NuevaEntidad == null)
              return;
            this.NuevaEntidad((object) null, EventArgs.Empty);
          }
          else
          {
            int num = (int) Dialogos.MostrarMensajeInformacion(this.Title, "No se encontraron coincidencias.", (Dialogos.Boton) 0);
          }
        }
        else if (dataTable2.Rows.Count == 1)
        {
          int result;
          if (int.TryParse(dataTable2.Rows[0]["ENTC_Codigo"].ToString(), out result))
            this.SetEntidad(new int?(result));
          else
            this.ClearEntidad();
        }
        else
        {
          List<ColumnaAyuda> columnaAyudaList1 = new List<ColumnaAyuda>();
          if (this.PorDocIden)
          {
            List<ColumnaAyuda> columnaAyudaList2 = columnaAyudaList1;
            ColumnaAyuda columnaAyuda1 = new ColumnaAyuda();
            columnaAyuda1.set_Index(0);
            columnaAyuda1.set_ColumnName("ENTC_DocIden");
            columnaAyuda1.set_ColumnCaption("Doc. Identidad");
            columnaAyuda1.set_Alineacion(DataGridViewContentAlignment.MiddleLeft);
            columnaAyuda1.set_Width(120);
            columnaAyuda1.set_DataType(typeof (string));
            columnaAyuda1.set_Format((string) null);
            ColumnaAyuda columnaAyuda2 = columnaAyuda1;
            columnaAyudaList2.Add(columnaAyuda2);
            List<ColumnaAyuda> columnaAyudaList3 = columnaAyudaList1;
            ColumnaAyuda columnaAyuda3 = new ColumnaAyuda();
            columnaAyuda3.set_Index(1);
            columnaAyuda3.set_ColumnName("ENTC_NomCompleto");
            columnaAyuda3.set_ColumnCaption(EntidadClear.getDescTipoEntidad(EntidadClear.GetCodigoTipoEntidad(this.TipoEntidad)));
            columnaAyuda3.set_Alineacion(DataGridViewContentAlignment.MiddleLeft);
            columnaAyuda3.set_Width(350);
            columnaAyuda3.set_DataType(typeof (string));
            columnaAyuda3.set_Format((string) null);
            ColumnaAyuda columnaAyuda4 = columnaAyuda3;
            columnaAyudaList3.Add(columnaAyuda4);
          }
          else
          {
            List<ColumnaAyuda> columnaAyudaList2 = columnaAyudaList1;
            ColumnaAyuda columnaAyuda1 = new ColumnaAyuda();
            columnaAyuda1.set_Index(0);
            columnaAyuda1.set_ColumnName("ENTC_NomCompleto");
            columnaAyuda1.set_ColumnCaption(EntidadClear.getDescTipoEntidad(EntidadClear.GetCodigoTipoEntidad(this.TipoEntidad)));
            columnaAyuda1.set_Alineacion(DataGridViewContentAlignment.MiddleLeft);
            columnaAyuda1.set_Width(350);
            columnaAyuda1.set_DataType(typeof (string));
            columnaAyuda1.set_Format((string) null);
            ColumnaAyuda columnaAyuda2 = columnaAyuda1;
            columnaAyudaList2.Add(columnaAyuda2);
            List<ColumnaAyuda> columnaAyudaList3 = columnaAyudaList1;
            ColumnaAyuda columnaAyuda3 = new ColumnaAyuda();
            columnaAyuda3.set_Index(1);
            columnaAyuda3.set_ColumnName("ENTC_DocIden");
            columnaAyuda3.set_ColumnCaption("Doc. Identidad");
            columnaAyuda3.set_Alineacion(DataGridViewContentAlignment.MiddleLeft);
            columnaAyuda3.set_Width(120);
            columnaAyuda3.set_DataType(typeof (string));
            columnaAyuda3.set_Format((string) null);
            ColumnaAyuda columnaAyuda4 = columnaAyuda3;
            columnaAyudaList3.Add(columnaAyuda4);
          }
          List<ColumnaAyuda> columnaAyudaList4 = columnaAyudaList1;
          ColumnaAyuda columnaAyuda5 = new ColumnaAyuda();
          columnaAyuda5.set_Index(3);
          columnaAyuda5.set_ColumnName("ENTC_Codigo");
          columnaAyuda5.set_ColumnCaption("Código");
          columnaAyuda5.set_Alineacion(DataGridViewContentAlignment.MiddleRight);
          columnaAyuda5.set_Width(100);
          columnaAyuda5.set_DataType(typeof (int));
          columnaAyuda5.set_Format((string) null);
          ColumnaAyuda columnaAyuda6 = columnaAyuda5;
          columnaAyudaList4.Add(columnaAyuda6);
          Ayuda ayuda = new Ayuda("Ayuda " + EntidadClear.getDescTipoEntidad(EntidadClear.GetCodigoTipoEntidad(this.TipoEntidad)), dataTable2, false, (IEnumerable<ColumnaAyuda>) columnaAyudaList1, "");
          ((Control) this).KeyUp -= new KeyEventHandler(((TextBoxAyuda) this).TextBoxAyuda_Key);
          ((Control) ayuda).Width = Convert.ToInt32((double) ((Control) ayuda).Width * 1.5);
          if (((Form) ayuda).ShowDialog() == DialogResult.OK)
          {
            int result;
            if (int.TryParse(ayuda.get_Respuesta().Rows[0]["ENTC_Codigo"].ToString(), out result))
              this.SetEntidad(new int?(result));
            else
              this.ClearEntidad();
          }
          else
            this.ClearEntidad();
          ((Control) this).KeyUp += new KeyEventHandler(((TextBoxAyuda) this).TextBoxAyuda_Key);
        }
      }
      catch (Exception ex)
      {
        int num = (int) Dialogos.MostrarMensajeError(this.Title, "Ha ocurrido un error al cargar la ayuda de Entidad", ex);
      }
    }

    public void SetEntidad(int? ENTC_Codigo)
    {
      try
      {
        if (ENTC_Codigo.HasValue)
        {
          if (this.Client == null)
            return;
          Entidad oneEntidad = this.Client.GetOneEntidad(ENTC_Codigo.Value, new short?(), this.SoloEntidad);
          if (oneEntidad != null)
          {
            if (this.PorDocIden)
              this.SetValue((object) oneEntidad, oneEntidad.get_ENTC_DocIden());
            else
              this.SetValue((object) oneEntidad, oneEntidad.get_ENTC_NomCompleto());
            this.Focus();
            SendKeys.Send("{TAB}");
          }
          else
            this.ClearEntidad();
        }
        else
          this.ClearEntidad();
      }
      catch (Exception ex)
      {
      }
    }

    public void SetEntidad(Entidad item)
    {
      try
      {
        if (item != null)
        {
          if (this.PorDocIden)
            this.SetValue((object) item, item.get_ENTC_DocIden());
          else
            this.SetValue((object) item, item.get_ENTC_NomCompleto());
          this.Focus();
          SendKeys.Send("{TAB}");
        }
        else
          this.ClearEntidad();
      }
      catch (Exception ex)
      {
      }
    }

    public void ClearEntidad()
    {
      try
      {
        this.ClearValue();
      }
      catch (Exception ex)
      {
      }
    }

    public event EventHandler NuevaEntidad;

    public event EventHandler SelectedItemEntidadChanged;

    private void Entidad_AyudaClean(object sender, EventArgs e)
    {
      try
      {
        this.ClearEntidad();
      }
      catch (Exception ex)
      {
      }
    }

    private void Entidad_AyudaClick(object sender, EventArgs e)
    {
      try
      {
        this.AyudaEntidad();
      }
      catch (Exception ex)
      {
      }
    }

    private void Entidad_AyudaValueChanged(object sender, EventArgs e)
    {
      if (this.SelectedItemEntidadChanged == null)
        return;
      this.SelectedItemEntidadChanged(this.get_Value(), EventArgs.Empty);
    }

    public static string getDescTipoEntidad(short x_tipe_codigo)
    {
      string str = "";
      switch (x_tipe_codigo)
      {
        case 1:
          str = "CLIENTES";
          break;
        case 2:
          str = "PROVEEDORES";
          break;
        case 3:
          str = "EJECUTIVOS DE VENTA";
          break;
        case 4:
          str = "CUSTOMER SERVICE";
          break;
        case 5:
          str = "TRANSPORTISTAS";
          break;
        case 6:
          str = "AGENTES";
          break;
        case 7:
          str = "BROKER";
          break;
        case 8:
          str = "AGENTE DE CARGA";
          break;
        case 9:
          str = "CONTACTO";
          break;
        case 10:
          str = "SHIPPER";
          break;
        case 11:
          str = "AGENTE PORTUARIO";
          break;
        case 12:
          str = "AGENCIA ADUANERA";
          break;
        case 13:
          str = "AGENCIA MARITIMA";
          break;
        case 14:
          str = "DEPOSITO TEMPORAL";
          break;
        case 15:
          str = "DEPÓSITO VACÍOS";
          break;
        case 16:
          str = "EMPLEADO";
          break;
      }
      return str;
    }

    public static TiposEntidad getTipoEntidadEnum(short x_tipe_codigo)
    {
      switch (x_tipe_codigo)
      {
        case 1:
          return TiposEntidad.TIPE_Cliente;
        case 2:
          return TiposEntidad.TIPE_Proveedor;
        case 3:
          return TiposEntidad.TIPE_Ejecutivo;
        case 4:
          return TiposEntidad.TIPE_Customer;
        case 5:
          return TiposEntidad.TIPE_Transportista;
        case 6:
          return TiposEntidad.TIPE_Agente;
        case 7:
          return TiposEntidad.TIPE_Broker;
        case 8:
          return TiposEntidad.TIPE_AgenteCarga;
        case 9:
          return TiposEntidad.TIPE_Contacto;
        case 10:
          return TiposEntidad.TIPE_Shipper;
        case 11:
          return TiposEntidad.TIPE_AgentePortuario;
        case 12:
          return TiposEntidad.TIPE_AgenciaAduanera;
        case 13:
          return TiposEntidad.TIPE_AgenciaMaritima;
        case 14:
          return TiposEntidad.TIPE_DepositoTemporal;
        case 15:
          return TiposEntidad.TIPE_DepositoVacio;
        default:
          return TiposEntidad.TIPE_Cliente;
      }
    }

    public static string GetTipoEntidad(TiposEntidad TipoEntidad)
    {
      switch (TipoEntidad)
      {
        case TiposEntidad.TIPE_Cliente:
          return "1";
        case TiposEntidad.TIPE_Proveedor:
          return "2";
        case TiposEntidad.TIPE_Ejecutivo:
          return "3";
        case TiposEntidad.TIPE_Customer:
          return "4";
        case TiposEntidad.TIPE_Transportista:
          return "5";
        case TiposEntidad.TIPE_Agente:
          return "6";
        case TiposEntidad.TIPE_Broker:
          return "7";
        case TiposEntidad.TIPE_AgenteCarga:
          return "8";
        case TiposEntidad.TIPE_Contacto:
          return "9";
        case TiposEntidad.TIPE_Shipper:
          return "10";
        case TiposEntidad.TIPE_AgentePortuario:
          return "11";
        case TiposEntidad.TIPE_AgenciaAduanera:
          return "12";
        case TiposEntidad.TIPE_AgenciaMaritima:
          return "13";
        case TiposEntidad.TIPE_DepositoTemporal:
          return "14";
        case TiposEntidad.TIPE_DepositoVacio:
          return "15";
        default:
          return (string) null;
      }
    }

    public static short GetCodigoTipoEntidad(TiposEntidad TipoEntidad)
    {
      switch (TipoEntidad)
      {
        case TiposEntidad.TIPE_Cliente:
          return 1;
        case TiposEntidad.TIPE_Proveedor:
          return 2;
        case TiposEntidad.TIPE_Ejecutivo:
          return 3;
        case TiposEntidad.TIPE_Customer:
          return 4;
        case TiposEntidad.TIPE_Transportista:
          return 5;
        case TiposEntidad.TIPE_Agente:
          return 6;
        case TiposEntidad.TIPE_Broker:
          return 7;
        case TiposEntidad.TIPE_AgenteCarga:
          return 8;
        case TiposEntidad.TIPE_Contacto:
          return 9;
        case TiposEntidad.TIPE_Shipper:
          return 10;
        case TiposEntidad.TIPE_AgentePortuario:
          return 11;
        case TiposEntidad.TIPE_AgenciaAduanera:
          return 12;
        case TiposEntidad.TIPE_AgenciaMaritima:
          return 13;
        case TiposEntidad.TIPE_DepositoTemporal:
          return 14;
        case TiposEntidad.TIPE_DepositoVacio:
          return 15;
        default:
          return -1;
      }
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
