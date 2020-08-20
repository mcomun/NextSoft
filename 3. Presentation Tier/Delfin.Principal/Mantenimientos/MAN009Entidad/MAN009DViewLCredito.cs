using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Delfin.Controls.Tipos;
using Delfin.Entities;
using Infrastructure.Client.FormClose;
using Infrastructure.WinForms.Controls;
using Infrastructure.Aspect.BusinessEntity;
using Infrastructure.Client.ValidationRules;
using Infrastructure.Aspect.Constants;

namespace Delfin.Principal
{
   public partial class MAN009DViewLCredito : Form
   {
      #region [ Variables ]

      public enum TLCredito
      {
         Cliente = 0, Proveedor = 1
      }

      public enum TOpcion
      {
         Nuevo = 0, Editar = 1
      }

      #endregion

      #region [ Propiedades ]

      public Entities.EntidadLimiteCredito Item { get; set; }
      public MAN009Presenter Presenter { get; set; }
      public TOpcion TRegistro { get; set; }
      public TLCredito TLimiteCredito { get; set; }
      public String ENLI_Tipos { get; set; }
      public String ENLI_TiposDescripcion { get; set; }
      public String TIPO_CodMND { get; set; }
      #endregion

      #region [ Formulario ]
      public MAN009DViewLCredito(TLCredito TLimite, TOpcion Opcion)
      {
         InitializeComponent();
         try
         {
            this.StartPosition = FormStartPosition.CenterScreen;

            cmbTIPE_CodPadre.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbTIPE_CodPadre.Enabled = false;
            lblTIPE_CodPadre.Enabled = false;
            txaENTC_CodPadre.Enabled = false;
            lblENTC_CodPadre.Enabled = false;
            txtENLI_Codigo.Enabled = false;
            cmbENLI_Tipos.Enabled = false;
            txtENLI_Notas.MaxLength = 1000;

            cmbTIPO_CodMND.Tag = "TIPO_CodMNDMSGERROR";
            txnENLI_Monto.Tag = "ENLI_MontoMSGERROR";
            txnENLI_DiasDuracion.Tag = "ENLI_DiasDuracionMSGERROR";
            dtpENLI_Fecha.Tag = "ENLI_FechaMSGERROR";
            dtpENLI_FecInicio.Tag = "ENLI_FecInicioMSGERROR";
            dtpENLI_FecVencimiento.Tag = "ENLI_FecVencimientoMSGERROR";

            btnGuardar.Click += btnGuardar_Click;
            btnSalir.Click += btnSalir_Click;
            TRegistro = Opcion;
            TLimiteCredito = TLimite;
         }
         catch (Exception ex)
         { Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error inicializando.", ex); }
      }

      public void LoadView()
      {
         try
         {
            /* Cargar Controles */
            cmbTIPO_CodMND.LoadControl(Presenter.ContainerService, "Ayuda de Moneda", "MND", "< Sel. Moneda >", ListSortDirection.Ascending);
            cmbENLI_Tipos.LoadControl("Tipo de Relación Entidad", ComboBoxConstantes.OConstantes.LimiteCreditoCliente, "< Sel. Tipo>", ListSortDirection.Ascending);
            cmbENLI_Tipos.SelectedIndexChanged += cmbRELA_Tipos_SelectedIndexChanged;
            cmbENLI_FormaPago.LoadControl("Forma de Pago", ComboBoxConstantes.OConstantes.LimiteCreditoFormaPago, "< Sel. Forma Pago >", ListSortDirection.Ascending);
            cmbTipoFechaVencimiento.LoadControl("Tipo Fec. Vencimiento", ComboBoxConstantes.OConstantes.TipoFechaVencimiento, "< Sel. Tipo Fech. Vencimiento >", ListSortDirection.Ascending);

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
               panelCaption3.Visible = false;
               this.Height = this.Height - 55;
            }
            switch (TLimiteCredito)
            {
               case TLCredito.Cliente:
                  tlpDetalle.RowStyles[2].Height = 0;
                  lblENLI_FecInicio.Visible = false;
                  dtpENLI_FecInicio.Visible = false;
                  lblENLI_FecVencimiento.Visible = false;
                  dtpENLI_FecVencimiento.Visible = false;
                  lblENLI_DiasDuracion.Text = "Forma de Pago :";
                  cmbENLI_FormaPago.Visible = false;
                  //this.Size = new Size(this.Width, this.Height - 27);
                  this.Text = "Limite de Crédito del Cliente";
                  break;
               case TLCredito.Proveedor:
                  tlpDatosGenerales.RowStyles[0].Height = 0;
                  lblENLI_Fecha.Visible = false;
                  dtpENLI_Fecha.Visible = false;
                  lblENLI_Tipos.Visible = false;
                  cmbENLI_Tipos.Visible = false;
                  cmbTIPO_CodMND.Enabled = false;
                  label3.Visible = false;
                  TIPO_CodMND = Item.TIPO_CodMND;
                  lblENLI_DiasDuracion.Text = "Duración :";
                  lblENLI_DiasDuracion.Visible = false;
                  txnENLI_DiasDuracion.Visible = false;
                  lblTipoFechaVencimiento.Visible = false;
                  cmbTipoFechaVencimiento.Visible = false;
                  chkENLI_CliAutEmiCheqDiferidos.Visible = false;
                  chkENLI_CliConCredLibre.Visible = false;
                  tlpDetalle.RowStyles[3].Height = 0;
                  this.Size = new Size(this.Width, this.Height - 27);
                  this.Text = "Limite de Crédito del Proveedor";
                  break;
            }
            switch (TRegistro)
            {
               case TOpcion.Nuevo:
                  ENLI_Tipos = Item.ENLI_Tipos;
                  ENLI_TiposDescripcion = Item.ENLI_TiposDescripcion;
                  Int16 ENLI_Codigo = Item.ENLI_Codigo;
                  Item = new EntidadLimiteCredito();
                  Item.ENLI_Tipos = ENLI_Tipos;
                  Item.ENLI_Codigo = ++ENLI_Codigo;
                  Item.ENLI_TiposDescripcion = ENLI_TiposDescripcion;
                  Item.AUDI_UsrCrea = Presenter.Session.UserName;
                  cmbENLI_Tipos.ConstantesSelectedValue = Item.ENLI_Tipos;
                  cmbENLI_Tipos.Enabled = false;
                  Item.Instance = InstanceEntity.Added;
                  ClearItem();
                  if (TLimiteCredito == TLCredito.Proveedor)
                  {
                     cmbTIPO_CodMND.TiposSelectedValue = TIPO_CodMND;
                     var _Max = Presenter.Item.ListEntidadLimiteCreditosProveedor.Max(TLCPro => TLCPro.ENLI_Codigo);
                     Item.ENLI_Codigo = Convert.ToInt16(int.Parse(_Max.ToString()) + 1);
                  }
                  break;
               case TOpcion.Editar:
                  Item.AUDI_UsrMod = Presenter.Session.UserName;
                  Item.Instance = InstanceEntity.Unchanged;
                  dtpENLI_Fecha.Enabled = false;
                  break;
            }
            SetItem();
         }
         catch (Exception)
         { throw; }
      }

      void cmbRELA_Tipos_SelectedIndexChanged(object sender, EventArgs e)
      {
         try
         {
            if (cmbENLI_Tipos.ConstantesSelectedItem != null)
            {


            }
         }
         catch (Exception)
         { throw; }
      }

      public void ShowValidation()
      {
         try
         {
            Dialogos.MostrarMensajeInformacion(Presenter.Title, "Faltan ingresar datos obligatorios: ", Item.MensajeError, Dialogos.Boton.Detalles);
            FormShowErrorProvider<EntidadLimiteCredito>.Validate(Item, this, errorProviderLC);
         }
         catch (Exception ex)
         { Dialogos.MostrarMensajeError(Presenter.Title, Mensajes.ShowItems, ex); }
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
               if (Item.ENLI_Codigo > 0) { txtENLI_Codigo.Text = Item.ENLI_Codigo.ToString(); }
               if (Item.ENLI_Fecha != null) { dtpENLI_Fecha.NSFecha = Item.ENLI_Fecha; }
               if (Item.ENLI_Tipos != null) { cmbENLI_Tipos.ConstantesSelectedValue = Item.ENLI_Tipos; }
               if (Item.TIPO_CodMND != null) { cmbTIPO_CodMND.TiposSelectedValue = Item.TIPO_CodMND; }
               if (Item.ENLI_Monto != null) { txnENLI_Monto.Value = Item.ENLI_Monto.Value; }
               if (Item.ENLI_DiasDuracion != null) { txnENLI_DiasDuracion.Value = Item.ENLI_DiasDuracion.Value; }
               if (Item.ENLI_FecInicio != null) { dtpENLI_FecInicio.NSFecha = Item.ENLI_FecInicio; }
               if (Item.ENLI_FecVencimiento != null) { dtpENLI_FecVencimiento.NSFecha = Item.ENLI_FecVencimiento; }
               if (!String.IsNullOrEmpty(Item.ENLI_Notas )) { txtENLI_Notas.Text = Item.ENLI_Notas; }
               if (!String.IsNullOrEmpty(Item.ENLI_FormaPago )) { cmbENLI_FormaPago.ConstantesSelectedValue = Item.ENLI_FormaPago; }
               if (!String.IsNullOrEmpty(Item.ENLI_TipoFecVencimiento)) { cmbTipoFechaVencimiento.SelectedValue = Item.ENLI_TipoFecVencimiento; }
               chkENLI_CliAutEmiCheqDiferidos.Checked = Item.ENLI_CliAutEmiCheqDiferidos;
               chkENLI_CliConCredLibre.Checked = Item.ENLI_CliConCredLibre;
            }
         }
         catch (Exception)
         { throw; }
      }

      private void ClearItem()
      {
         try
         {
            txtENLI_Codigo.Clear();
            dtpENLI_Fecha.NSClear();
            cmbENLI_Tipos.SelectedIndex = 0;
            cmbTIPO_CodMND.SelectedIndex = 0;
            txnENLI_DiasDuracion.Clear();
            txnENLI_Monto.Clear();
            dtpENLI_FecInicio.NSClear();
            dtpENLI_FecVencimiento.NSClear();
            txtENLI_Notas.Clear();
         }
         catch (Exception)
         { throw; }
      }

      private void GetItem()
      {
         try
         {
            Item.ENLI_Fecha = null; if (dtpENLI_Fecha.NSFecha.HasValue) { Item.ENLI_Fecha = dtpENLI_Fecha.NSFecha; }
            //Item.ENLI_Tipos = null; if (cmbENLI_Tipos.ConstantesSelectedItem != null) { Item.ENLI_Tipos = cmbENLI_Tipos.ConstantesSelectedItem.CONS_CodTipo; }
            Item.TIPO_CodMND = null; Item.TIPO_TabMND = null;
            if (cmbTIPO_CodMND.TiposSelectedItem != null)
            {
               Item.TIPO_CodMND = cmbTIPO_CodMND.TiposSelectedItem.TIPO_CodTipo;
               Item.TIPO_TabMND = cmbTIPO_CodMND.TiposSelectedItem.TIPO_CodTabla;
               Item.TIPO_MND = cmbTIPO_CodMND.TiposSelectedItem.TIPO_DescC;
            }
            Item.ENLI_Monto = null; if (txnENLI_Monto.Value > 0) { Item.ENLI_Monto = txnENLI_Monto.Value; }
            Item.ENLI_DiasDuracion = null; if (txnENLI_DiasDuracion.Value > 0) { Item.ENLI_DiasDuracion = Convert.ToInt16(txnENLI_DiasDuracion.Value); }
            Item.ENLI_FecInicio = null; if (dtpENLI_FecInicio.NSFecha.HasValue) { Item.ENLI_FecInicio = dtpENLI_FecInicio.NSFecha; }
            Item.ENLI_FecVencimiento = null; if (dtpENLI_FecVencimiento.NSFecha.HasValue) { Item.ENLI_FecVencimiento = dtpENLI_FecVencimiento.NSFecha; }
            Item.ENLI_Notas = null; if (txtENLI_Notas.Text.Length > 0) { Item.ENLI_Notas = txtENLI_Notas.Text; }
            Item.TIPE_Codigo = 0; if ((cmbTIPE_CodPadre.SelectedItem as TiposEntidad).TIPE_Codigo > 0) { Item.TIPE_Codigo = (cmbTIPE_CodPadre.SelectedItem as TiposEntidad).TIPE_Codigo; }
            Item.ENLI_FormaPago = null; if (cmbENLI_FormaPago.ConstantesSelectedItem != null) { Item.ENLI_FormaPago = cmbENLI_FormaPago.ConstantesSelectedItem.CONS_CodTipo; }
            Item.ENLI_TipoFecVencimiento = null; if (cmbTipoFechaVencimiento.ConstantesSelectedItem != null) { Item.ENLI_TipoFecVencimiento = cmbTipoFechaVencimiento.ConstantesSelectedItem.CONS_CodTipo; }
            Item.ENLI_CliAutEmiCheqDiferidos = chkENLI_CliAutEmiCheqDiferidos.Checked;
            Item.ENLI_CliConCredLibre = chkENLI_CliConCredLibre.Checked;
         }
         catch (Exception)
         { throw; }
      }

      #endregion

      #region [ Eventos ]

      private void btnSalir_Click(object sender, EventArgs e)
      {
         errorProviderLC.Dispose();
         this.Close();
      }

      private void btnGuardar_Click(object sender, EventArgs e)
      {
         try
         {
            GetItem();
            if (Item.Validar())
            {
               if (TRegistro == TOpcion.Nuevo)
               {
                  this.Item.Instance = InstanceEntity.Added;
                  errorProviderLC.Dispose();
               }
               DialogResult = DialogResult.OK;
            }
            else
            {
               ShowValidation();
               //Dialogos.MostrarMensajeInformacion(Presenter.Title, "No se puede grabar, existen campos obligatorios", Item.MensajeError);
            }
         }
         catch (Exception ex)
         { Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al intentar guardar el limite de credito.", ex); }
      }

      #endregion

      #region [ IFormClose ]

      #endregion

   }
}
