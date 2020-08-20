using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Delfin.Controls;
using Delfin.Controls.Tipos;
using Infrastructure.Aspect.BusinessEntity;
using Infrastructure.WinForms.Controls;
using TiposEntidad = Delfin.Entities.TiposEntidad;
using Delfin.Entities;

namespace Delfin.Principal
{
   public partial class MAN009RView : Form
   {
      #region [ Variables ]

      public enum TRelacionado
      {
         Nuevo = 0, Editar = 1
      }

      #endregion

      #region [ Propiedades ]

      public Entities.Entidad Entidad { get; set; }
      public Entities.Entidad_Relacionados Item { get; set; }
      public MAN009Presenter Presenter { get; set; }
      public TRelacionado TRegistro { get; set; }

      #endregion

      #region [ Formulario ]

      public MAN009RView(TRelacionado Opcion , Int16 x_EntidadPadre)
      {
         InitializeComponent();
         try
         {
            this.StartPosition = FormStartPosition.CenterScreen;

            txtRELA_Codigo.Tag = "RELA_CodigoMSGERROR";
            txaENTC_CodPadre.Tag = "ENTC_CodPadreMSGERROR";
            txaENTC_CodHijo.Tag = "ENTC_CodHijoMSGERROR";
            cmbCONS_CodRGM.Tag = "CONS_CodRGMMSGERROR";
            cmbTIPO_CodTRF.Tag = "TIPO_CodTRFMSGERROR";
            cmbRELA_Tipos.Tag = "RELA_TiposMSGERROR";
            chkRELA_DepTemNegociaAgente.Tag = "RELA_DepTemNegociaAgenteMSGERROR";
            cmbTIPE_CodPadre.Tag = "TIPE_CodPadreMSGERROR";
            cmbTIPE_CodHijo.Tag = "TIPE_CodHijoMSGERROR";


            cmbTIPE_CodPadre.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbTIPE_CodPadre.Enabled = false;
            lblTIPE_CodPadre.Enabled = false;
            txaENTC_CodPadre.Enabled = false;
            lblENTC_CodPadre.Enabled = false;

            txtRELA_Codigo.Enabled = false;
            cmbTIPE_CodHijo.DropDownStyle = ComboBoxStyle.DropDownList;

            btnGuardar.Click += btnGuardar_Click;
            btnSalir.Click += btnSalir_Click;
            btnAgregarNuevoRelacionado.Click += btnAgregarNuevoRelacionado_Click;
            TRegistro = Opcion;
            switch (x_EntidadPadre)
            {
                case EntidadClear.TIPE_Cliente:
                    pcTitleRelacionados.Caption = "Datos del Cliente";
                    break;
                case EntidadClear.TIPE_Proveedor:
                    pcTitleRelacionados.Caption = "Datos del Proveedor";
                    break;
                case EntidadClear.TIPE_Ejecutivo:
                    pcTitleRelacionados.Caption = "Datos del Ejecutivo";
                    break;
                case EntidadClear.TIPE_CustomerService:
                    pcTitleRelacionados.Caption = "Datos del Customer Service";
                    break;
                case EntidadClear.TIPE_Transportista:
                    pcTitleRelacionados.Caption = "Datos del Transportista";
                    break;
                case EntidadClear.TIPE_Broker:
                    pcTitleRelacionados.Caption = "Datos del Broker";
                    break;
                case EntidadClear.TIPE_Contacto:
                    pcTitleRelacionados.Caption = "Datos del Contacto";
                    break;
                case EntidadClear.TIPE_Shipper:
                    pcTitleRelacionados.Caption = "Datos del Shipper";
                    break;
                case EntidadClear.TIPE_DepositoTemporal:
                    pcTitleRelacionados.Caption = "Datos del Deposito Temporal";
                    break;
                case EntidadClear.TIPE_DepositoVacio:
                    pcTitleRelacionados.Caption = "Datos del Desposito de Vacios";
                    break;
                case EntidadClear.TIPE_Agente:
                case EntidadClear.TIPE_AgentePortuario:
                case EntidadClear.TIPE_AgenciaAduanera:
                case EntidadClear.TIPE_AgenciaMaritima:
                case EntidadClear.TIPE_AgenteCarga:
                    pcTitleRelacionados.Caption = "Datos del Agente";
                    break;
            }
         }
         catch (Exception ex)
         { Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error inicializando.", ex); }
      }


      public void LoadView()
      {
         try
         {
            /* Cargar Controles */

            cmbCONS_CodRGM.LoadControl(Presenter.ContainerService, "Ayuda de Regimen", "RGM", "< Seleccione el Régimen>", ListSortDirection.Ascending);
            cmbTIPO_CodTRF.LoadControl(Presenter.ContainerService, "Ayuda de RFT", "TRF", "< Sel. Tipo >", ListSortDirection.Ascending);
            //cmbRELA_Tipos.LoadControl("Tipo de Relación Entidad", comboBoxConstantes.OConstantes.TIPO_RelacionEntidad, "< Sel. Tipo Relación >", ListSortDirection.Ascending);
            LoadTipoEntidadRelacion();           
             cmbRELA_Tipos.SelectedIndexChanged += cmbRELA_Tipos_SelectedIndexChanged;

            cmbTIPE_CodHijo.SelectedIndex = -1;
            cmbTIPE_CodHijo.Enabled = false;
            txaENTC_CodHijo.Enabled = false;
            btnAgregarNuevoRelacionado.Enabled = false;
            //cmbTIPE_CodHijo.SelectedValue = EntidadClear.TIPE_Cliente;
            //txaENTC_CodHijo.LoadControl(Presenter.ContainerService, TiposEntidad.TIPE_Cliente, "ENTC_DocIden", "ENTC_NomCompleto");

            if (Presenter.Item.ENTC_Codigo > 0)
            {
               cmbTIPE_CodPadre.ValueMember = "TIPE_Codigo";
               cmbTIPE_CodPadre.DisplayMember = "TIPE_Descripcion";
               cmbTIPE_CodPadre.DataSource = Presenter.ListTiposEntidad;

               cmbTIPE_CodPadre.SelectedValue = Presenter.Item.TIPE_Codigo;
               txaENTC_CodPadre.LoadControl(Presenter.ContainerService, Delfin.Controls.EntidadClear.getTipoEntidadEnum(Presenter.Item.TIPE_Codigo), "ENTC_DocIden", "ENTC_NomCompleto");
               txaENTC_CodPadre.SetEntidad(Presenter.Item);
            }
            else
            {
               tableLayoutPanel3.Visible = false;
               pcTitleRelacionados.Visible = false;
               this.Height = this.Height - 55;
            }
            switch (TRegistro)
            {
               case TRelacionado.Nuevo:
                  Item = new Entities.Entidad_Relacionados();
                  ClearItem();
                  break;
               case TRelacionado.Editar:
                  cmbTIPE_CodHijo.Enabled = true;
                  txaENTC_CodHijo.Enabled = true;
                  break;

            }
            SetItem();
         }
         catch (Exception)
         { throw; }
      }

      public void LoadTipoEntidadRelacion()
{
    AppService.DelfinServiceClient oAppservice = new AppService.DelfinServiceClient();
    ObservableCollection<Constantes> observableCollection1 = new ObservableCollection<Constantes>();
    DataTable dtTiposRelacion = new DataTable();
    dtTiposRelacion = oAppservice.ExecuteSQL("SELECT * FROM NextSoft..viRELA_Tipos ORDER BY 3").Tables[0];
    int r;
    for (r = 0; r <= dtTiposRelacion.Rows.Count-1; r++)
    {
    Constantes oConstante = new Constantes();
    oConstante.CONS_CodTipo = (string)dtTiposRelacion.Rows[r][0];
    oConstante.CONS_CodTabla = "RTIPO_"+ dtTiposRelacion.Rows[r][0];
    oConstante.CONS_Desc_SPA = (string)dtTiposRelacion.Rows[r][2];
    observableCollection1.Add(oConstante);
            }
    cmbRELA_Tipos.DataSource = observableCollection1;
    cmbRELA_Tipos.ValueMember = "CONS_CodTipo";
    cmbRELA_Tipos.DisplayMember = "CONS_Desc_SPA";

} 

      void cmbRELA_Tipos_SelectedIndexChanged(object sender, EventArgs e)
      {
         try
         {
             if(cmbRELA_Tipos.SelectedIndex == 0)
             { return; }

            if (cmbRELA_Tipos.ConstantesSelectedItem != null)
            {
               cmbTIPE_CodHijo.ValueMember = "TIPE_Codigo";
               cmbTIPE_CodHijo.DisplayMember = "TIPE_Descripcion";

               ObservableCollection<Entities.TiposEntidad> _listTiposEntidad = new ObservableCollection<TiposEntidad>();

               String Valor = "";
               Entities.Parametros _parametros = Presenter.ListParametros.Where(Para => Para.PARA_Clave.Equals(cmbRELA_Tipos.ConstantesSelectedItem.CONS_CodTabla)).FirstOrDefault();
               if (_parametros != null && _parametros.PARA_Valor != null) { Valor = _parametros.PARA_Valor; }

               String[] Cadena = Valor.Split('|');
               if (Cadena.Length > 0)
               {
                  foreach (var VARIABLE in Cadena)
                  {
                     _listTiposEntidad.Add(Presenter.ListTiposEntidad.Where(TEnt => TEnt.TIPE_Codigo == Int32.Parse(VARIABLE)).FirstOrDefault());
                  }
                  cmbTIPE_CodHijo.Enabled = true;
                  txaENTC_CodHijo.Enabled = true;
               }
               else
               {
                  cmbTIPE_CodHijo.Enabled = false;
                  txaENTC_CodHijo.Enabled = false;
               }
               cmbTIPE_CodHijo.DataSource = _listTiposEntidad;
               if (cmbRELA_Tipos.ConstantesSelectedItem.CONS_CodTabla.Equals("RTIPO_DTE"))
               {
                  chkRELA_DepTemNegociaAgente.Visible = true;
                  label8.Visible = true;
               }
               else
               {
                  chkRELA_DepTemNegociaAgente.Checked = false;
                  chkRELA_DepTemNegociaAgente.Visible = false;
                  label8.Visible = false;
               }

               cmbTIPE_CodHijo.SelectedIndex = 0;
               cmbTIPE_CodHijo.SelectedIndexChanged += cmbTIPE_CodHijo_SelectedIndexChanged;
               cmbTIPE_CodHijo_SelectedIndexChanged(null, null);
            }
         }
         catch (Exception)
         { throw; }
      }

      void cmbTIPE_CodHijo_SelectedIndexChanged(object sender, EventArgs e)
      {
         try
         {
            if (cmbTIPE_CodHijo.SelectedItem != null && (cmbTIPE_CodHijo.SelectedItem as Entities.TiposEntidad).TIPE_Codigo > 0)
            {
               txaENTC_CodHijo.Enabled = true;
               btnAgregarNuevoRelacionado.Enabled = true;
               txaENTC_CodHijo.LoadControl(Presenter.ContainerService, Delfin.Controls.EntidadClear.getTipoEntidadEnum((cmbTIPE_CodHijo.SelectedItem as Entities.TiposEntidad).TIPE_Codigo), "ENTC_DocIden", "ENTC_NomCompleto");
            }
            else { txaENTC_CodHijo.Enabled = false; btnAgregarNuevoRelacionado.Enabled = false; }
         }
         catch (Exception ex)
         { Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error inicializando el control.", ex); }
      }

      #endregion

      #region [ ICUS002MView ]

      #endregion

      #region [ Metodos ]

      private void SetItem()
      {
         try
         {
            if (Item != null && Presenter != null)
            {
               if (Item.RELA_Codigo.HasValue) { txtRELA_Codigo.Text = Item.RELA_Codigo.ToString(); }
               if (Item.RELA_Tipos != null) { cmbRELA_Tipos.ConstantesSelectedValue = Item.RELA_Tipos; }
               if (Item.TIPE_CodHijo.HasValue) { cmbTIPE_CodHijo.SelectedValue = Item.TIPE_CodHijo; }
               if (Item.ENTC_CodHijo.HasValue) { txaENTC_CodHijo.SetEntidad(Item.ENTC_CodHijo); }
               if (Item.CONS_CodRGM != null) { cmbCONS_CodRGM.SelectedValue = Item.CONS_CodRGM; }
               chkRELA_DepTemNegociaAgente.Checked = (Item.RELA_DepTemNegociaAgente.HasValue ? Item.RELA_DepTemNegociaAgente.Value : false);
               if (Item.TIPO_CodTRF != null) { cmbTIPO_CodTRF.TiposSelectedValue = Item.TIPO_CodTRF; }
               if (Item.RELA_Observacion != null) { txtRELA_Observacion.Text = Item.RELA_Observacion; }

            }
         }
         catch (Exception)
         { throw; }
      }

      private void ClearItem()
      {
         try
         {
            errorProviderRelacionados.Clear();
            txtRELA_Codigo.Clear();
            cmbCONS_CodRGM.SelectedIndex = 0;
            cmbRELA_Tipos.SelectedIndex = 0;
            chkRELA_DepTemNegociaAgente.Checked = false;
            cmbTIPO_CodTRF.SelectedIndex = 0;
            cmbTIPE_CodHijo.SelectedIndex = -1;
            txaENTC_CodHijo.Clear();
            txtRELA_Observacion.Clear();
         }
         catch (Exception)
         { throw; }
      }

      private void GetItem()
      {
         try
         {
            errorProviderRelacionados.Clear();
            Item.CONS_CodRGM = null; Item.CONS_TabRGM = null;
            if (cmbCONS_CodRGM.ConstantesSelectedItem != null)
            {
               Item.CONS_CodRGM = cmbCONS_CodRGM.ConstantesSelectedItem.CONS_CodTipo;
               Item.CONS_TabRGM = cmbCONS_CodRGM.ConstantesSelectedItem.CONS_CodTabla;
               Item.REGIMEN = cmbCONS_CodRGM.Text;
            }
            Item.RELA_Tipos = null; if (cmbRELA_Tipos.ConstantesSelectedItem != null) { Item.RELA_Tipos = cmbRELA_Tipos.SelectedValue.ToString(); }
            Item.RELA_Activo = true;
            Item.TIPO_CodTRF = null; Item.TIPO_TabTRF = null; if (cmbTIPO_CodTRF.TiposSelectedItem != null) { Item.TIPO_CodTRF = cmbTIPO_CodTRF.TiposSelectedItem.TIPO_CodTipo; Item.TIPO_TabTRF = cmbTIPO_CodTRF.TiposSelectedItem.TIPO_CodTabla; }
            Item.TIPE_CodHijo = null; if (cmbTIPE_CodHijo.SelectedItem != null && (cmbTIPE_CodHijo.SelectedItem as Entities.TiposEntidad).TIPE_Codigo > 0) { Item.TIPE_CodHijo = (cmbTIPE_CodHijo.SelectedItem as Entities.TiposEntidad).TIPE_Codigo; }
            Item.ENTC_CodHijo = null; if (txaENTC_CodHijo.SelectedItem != null) { Item.ENTC_CodHijo = txaENTC_CodHijo.SelectedItem.ENTC_Codigo; }
            Item.RELA_DepTemNegociaAgente = chkRELA_DepTemNegociaAgente.Checked;
            Item.RELA_Observacion = null; if (!String.IsNullOrEmpty(txtRELA_Observacion.Text)) { Item.RELA_Observacion = txtRELA_Observacion.Text; }
         }
         catch (Exception)
         { throw; }
      }

      public void ShowValidation()
      {
         try
         {
            Infrastructure.Client.FormClose.FormShowErrorProvider<Entities.Entidad_Relacionados>.Validate(Item, this, errorProviderRelacionados);
            Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Presenter.Title, "Existen campos obligatorios, revise los detalles.", Presenter.Item.MensajeError);
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error en ShowValidation.", ex); }
      }

      #endregion

      #region [ Eventos ]
      private void btnAgregarNuevoRelacionado_Click(object sender, EventArgs e)
      {
         try
         {
            if (
               Infrastructure.WinForms.Controls.Dialogos.MostrarMensajePregunta(Presenter.Title,
                  "¿Desea Agregar un nuevo registro Entidad?", Infrastructure.WinForms.Controls.Dialogos.LabelBoton.Si_No) ==
               System.Windows.Forms.DialogResult.Yes)
            {
               MAN009MView MAN009_mview_sinlv;
               MAN009Presenter MAN009_presenter_sinlv;
               MAN009_mview_sinlv = new MAN009MView();
               MAN009_presenter_sinlv = new MAN009Presenter(Presenter.ContainerService, MAN009_mview_sinlv, (cmbTIPE_CodHijo.SelectedItem as Entities.TiposEntidad).TIPE_Codigo);
               MAN009_mview_sinlv.Presenter = MAN009_presenter_sinlv;
               MAN009_presenter_sinlv.lsinlview = true;
               MAN009_presenter_sinlv.tipe_Desc =
                  Delfin.Controls.EntidadClear.getDescTipoEntidad(
                     (cmbTIPE_CodHijo.SelectedItem as Entities.TiposEntidad).TIPE_Codigo);
               MAN009_presenter_sinlv.Load();

               MAN009_presenter_sinlv.Nuevo();
               this.Entidad = MAN009_presenter_sinlv.Item;
               txaENTC_CodHijo.SetEntidad(this.Entidad);
            }
         }
         catch (Exception ex)
         { Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error inicializando el control de Nuevo Contactos.", ex); }
      }

      private void btnSalir_Click(object sender, EventArgs e)
      {
         errorProviderRelacionados.Dispose();
         this.Close();
      }

      private void btnGuardar_Click(object sender, EventArgs e)
      {
         try
         {
            GetItem();
            if (Item.Validar())
            {
               errorProviderRelacionados.Dispose();
               this.Entidad = txaENTC_CodHijo.SelectedItem;
               this.Entidad.Relacionado = this.Item;
               this.Entidad.Relacionado.Instance = (TRegistro == TRelacionado.Nuevo
                  ? InstanceEntity.Added
                  : InstanceEntity.Modified);
               this.Entidad.CONS_RGM = Item.REGIMEN;
               if (cmbTIPO_CodTRF.TiposSelectedItem != null) { this.Entidad.TIPO_TRF = cmbTIPO_CodTRF.Text; }
               if (cmbRELA_Tipos.ConstantesSelectedItem != null) { this.Entidad.RELA_TipoRelacion = cmbRELA_Tipos.Text; }
               if ((cmbTIPE_CodHijo.SelectedItem as Entities.TiposEntidad).TIPE_Codigo > 0) { this.Entidad.TIPE_Hijo = cmbTIPE_CodHijo.Text; }

               if (TRegistro == TRelacionado.Nuevo)
               {
                  this.Entidad.Instance = InstanceEntity.Added;
                  this.Entidad.Relacionado.Instance = InstanceEntity.Added;
                  Presenter.Item.Relacionados.Add(this.Entidad);
               }
               DialogResult = DialogResult.OK;
            }
            else
            {
               ShowValidation();
            }
         }
         catch (Exception ex)
         { Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al intentar guardar el relacionado.", ex); }
      }

      #endregion

      #region [ IFormClose ]

      #endregion


      /*
       
       */
   }
}
