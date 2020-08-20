using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Telerik.WinControls.UI;
using Telerik.WinControls.UI.Localization;
using Delfin.Controls.Tipos;
using Infrastructure.WinForms.Controls;
using System.Collections.ObjectModel;

namespace Delfin.Principal
{
   public partial class MAN004MView : Form, IMAN004MView
   {
      #region [ Variables ]
      /// <summary>
      /// CRISTHIAN JOSE APAZA 
      /// LISTA DE DOCUMENTOS Y TIPOS DE MOVIMIENTO DEL SERVICIO
      /// </summary>
      public sealed class TdoMov
      {

         private TdoMov() { }
         //TIPO DE MOVIMIENTO
         public const string Ambos = "A";
         public const string Costos = "C";
         public const string Ingresos = "I";
      }
      #endregion

      #region [ Formulario ]
      //public List<ServDocumentos> 
      public MAN004MView()
      {
         InitializeComponent();
         try
         {
            this.FormClosing += new FormClosingEventHandler(MView_FormClosing);
            SERV_AfeDet.CheckedChanged += SERV_AfeDet_CheckedChanged;

            /*Cristhian Jose Apaza */
            SERV_TipoMov.SelectedIndexChanged += SERV_TipoMov_SelectedIndexChanged;
            CONS_CodLNG.SelectedIndexChanged += CONS_CodLNG_SelectedIndexChanged;
            /*Fin*/

            /************* DOCUMENTOS ***************/
            btnAddDocumentos.Click += new EventHandler(btnAddDocumentos_Click);
            btnDeleteDocumentos.Click += new EventHandler(btnDeleteDocumentos_Click);
            /****************************************/

            btnAuditoria.Click += btnAuditoria_Click;
            txaCENT_Desc.AyudaClick += txaCENT_Desc_AyudaClick;
            txaCENT_Codigo.AyudaClick += txaCENT_Codigo_AyudaClick;

            txaCENT_Codigo.AyudaClean += txaCENT_Codigo_AyudaClean;
            txaCENT_Desc.AyudaClean += txaCENT_Desc_AyudaClean;

            //VIAMaritima.CheckedChanged += VIAMaritima_CheckedChanged;
            //VIAAerea.CheckedChanged += VIAAerea_CheckedChanged;
            //VIATerrestre.CheckedChanged += VIATerrestre_CheckedChanged;
            //VIAFluvial.CheckedChanged += VIAFluvial_CheckedChanged;
         }
         catch (Exception)
         { }
      }

      #endregion

      #region [ Propiedades ]
      public MAN004Presenter Presenter { get; set; }
      private bool Closing = false;
      private System.Collections.Hashtable HashFormulario { get; set; }
      #endregion

      #region [ ICUS004MView ]
      public void LoadView()
      {
         try
         {

            SERV_TipoMov.LoadControl("Tipos de Movimiento Servicio", ComboBoxConstantes.OConstantes.SERV_TipoMov, "<Seleccionar Movimiento>", ListSortDirection.Ascending);
            CONS_CodLNG.LoadControl(Presenter.ContainerService, "Constantes de linea de Negocio", "LNG", "< Seleccionar Linea de Negocio >", ListSortDirection.Ascending);
            CONS_CodBAS.LoadControl(Presenter.ContainerService, "Constantes de Base de Calculo", "BAS", "< Seleccionar Base de Calculo >", ListSortDirection.Ascending);
            TIPO_CodMND.LoadControl(Presenter.ContainerService, "Tabla Monedas", "MND", "< Seleccionar Moneda >", ListSortDirection.Ascending);
            CONS_CodRGM.LoadControl(Presenter.ContainerService, "Constantes de Régimen", "RGM", "< Seleccionar Régimen >", ListSortDirection.Ascending);
            CONS_CodVia.LoadControl(Presenter.ContainerService, "Constantes de Vía", "VIA", "< Seleccionar Vía >", ListSortDirection.Ascending);
            TIPO_CodDET.LoadControl(Presenter.ContainerService, "Tipo de Detraccion", "DET", "< Seleccionar Detracción >", ListSortDirection.Ascending);
            

            cmbCENT_Ano.ValueMember = "CENT_Ano";
            cmbCENT_Ano.DisplayMember = "CENT_Ano";
            cmbCENT_Ano.DataSource = Presenter.DSPeriodos.Tables[0];

            cmbTIPO_CodOPE.ValueMember = "TIPO_CodTipo";
            cmbTIPO_CodOPE.DisplayMember = "TIPO_Desc1";
            cmbTIPO_CodOPE.DataSource = Presenter.DSTiposOPE.Tables[0];

            cmbTIPO_CodOPE_Costo.ValueMember = "TIPO_CodTipo";
            cmbTIPO_CodOPE_Costo.DisplayMember = "TIPO_Desc1";
            cmbTIPO_CodOPE_Costo.DataSource = Presenter.DSTiposOPE_Costo.Tables[0];


            /*************** SERVICIOS/DOCUMENTOS ******************/
            CONS_CodRGM.Enabled = false;
            BSItemsDocumentos = new BindingSource();
            grdItemsDocumentos.DataSource = BSItemsDocumentos;
            FormatGridDocumentos();
            /*******************************************************/

            //Presenter.GetTabla('UNT');              
            // cmbSERV_CodUNT.DataSource = Presenter.ListTabla;
            //cmbSERV_CodUNT.ValueMember = "TIPO_TabUNT";
            //cmbSERV_CodUNT.DisplayMember = "TIPO_CodUNT";
         }
         catch (Exception)
         { }
      }
      public void ClearItem()
      {
         try
         {
            SERV_Codigo.Text = null;
            SERV_Activo.Checked = true;
            CONS_CodLNG.ConstantesSelectedValue = null;
            SERV_TipoMov.ConstantesSelectedValue = null;
            CONS_CodRGM.ConstantesSelectedValue = null;
            CONS_CodVia.ConstantesSelectedValue = null;
            SERV_NombreCorto.Text = null;
            SERV_Nombre_SPA.Text = null;
            SERV_Nombre_ENG.Text = null;
            SERV_Glosa.Text = null;
            TIPO_CodMND.TiposSelectedValue = null;
            CONS_CodBAS.ConstantesSelectedValue = null;
            SERV_Flete.Checked = false;
            chkSERV_ExcesoFlete.Checked = false;
            SERV_Valor.Text = "0.00";
            SERV_CobMin.Text = null;
            SERV_CueVta.Text = null;
            SERV_CueGas.Text = null;
            SERV_CuenPuente.Text = null;
            SERV_AfeIgv.Checked = false;
            SERV_AfeDet.Checked = false;
            SERV_AfeIgv.Checked = false;
            SERV_AfeDet.Checked = false;
            SERV_PorDet.Text = null;
            TIPO_CodDET.TiposSelectedValue = null;
            SERV_DefinidoPor.Text = null;
            SERV_Observaciones.Text = null;
            txaCENT_Desc.ClearValue();
            txaCENT_Codigo.ClearValue();
            cmbTIPO_CodOPE.SelectedIndex = 0;
            cmbTIPO_CodOPE_Costo.SelectedIndex = 0;

            BSItemsDocumentos = new BindingSource();
            grdItemsDocumentos.DataSource = BSItemsDocumentos;
            BSItemsDocumentos.ResetBindings(true);

            errorProvider1.Clear();
         }
         catch (Exception)
         { }
      }
      public void GetItem()
      {
         try
         {
            Presenter.Item.SERV_Activo = SERV_Activo.Checked;
            if (CONS_CodLNG.ConstantesSelectedItem != null)
            {
               Presenter.Item.CONS_TabLNG = CONS_CodLNG.ConstantesSelectedItem.CONS_CodTabla;
               Presenter.Item.CONS_CodLNG = CONS_CodLNG.ConstantesSelectedItem.CONS_CodTipo;
            }
            else
            {
               Presenter.Item.CONS_TabLNG = null;
               Presenter.Item.CONS_CodLNG = null;
            }

            if (SERV_TipoMov.ConstantesSelectedItem != null)
            {
               Presenter.Item.SERV_TipoMov = SERV_TipoMov.ConstantesSelectedItem.CONS_CodTipo;
            }
            else
            {
               Presenter.Item.SERV_TipoMov = null;
            }


            if (CONS_CodRGM.ConstantesSelectedItem != null)
            {
               Presenter.Item.CONS_TabRGM = CONS_CodRGM.ConstantesSelectedItem.CONS_CodTabla;
               Presenter.Item.CONS_CodRGM = CONS_CodRGM.ConstantesSelectedItem.CONS_CodTipo;
            }
            else
            {
               Presenter.Item.CONS_TabRGM = null;
               Presenter.Item.CONS_CodRGM = null;
            }
            if (CONS_CodVia.ConstantesSelectedItem != null)
            {
               Presenter.Item.CONS_TabVia = CONS_CodVia.ConstantesSelectedItem.CONS_CodTabla;
               Presenter.Item.CONS_CodVia = CONS_CodVia.ConstantesSelectedItem.CONS_CodTipo;
            }
            else
            {
               Presenter.Item.CONS_TabVia = null;
               Presenter.Item.CONS_CodVia = null;
            }

            Presenter.Item.SERV_NombreCorto = SERV_NombreCorto.Text;
            Presenter.Item.SERV_Flete = SERV_Flete.Checked;
            Presenter.Item.SERV_ExcesoFlete = chkSERV_ExcesoFlete.Checked;
            Presenter.Item.SERV_Nombre_SPA = SERV_Nombre_SPA.Text;
            Presenter.Item.SERV_Nombre_ENG = SERV_Nombre_ENG.Text;

            Presenter.Item.SERV_Glosa = SERV_Glosa.Text;

            if (TIPO_CodMND.TiposSelectedItem != null)
            {
               Presenter.Item.TIPO_TabMND = TIPO_CodMND.TiposSelectedItem.TIPO_CodTabla;
               Presenter.Item.TIPO_CodMND = TIPO_CodMND.TiposSelectedItem.TIPO_CodTipo;
            }
            else
            {
               Presenter.Item.TIPO_TabMND = null;
               Presenter.Item.TIPO_CodMND = null;
            }
            if (CONS_CodBAS.ConstantesSelectedItem != null)
            {
               Presenter.Item.CONS_TabBAS = CONS_CodBAS.ConstantesSelectedItem.CONS_CodTabla;
               Presenter.Item.CONS_CodBAS = CONS_CodBAS.ConstantesSelectedItem.CONS_CodTipo;
            }
            else
            {
               Presenter.Item.CONS_TabBAS = null;
               Presenter.Item.CONS_CodBAS = null;
            }

            Decimal varlorservicio;
            if (Decimal.TryParse(SERV_Valor.Text, out varlorservicio))
            { Presenter.Item.SERV_Valor = varlorservicio; }

            Decimal cobrominimo;
            if (Decimal.TryParse(SERV_CobMin.Text, out cobrominimo))
            { Presenter.Item.SERV_CobMin = cobrominimo; }

            //Presenter.Item.SERV_CueVta = SERV_CueVta.Text;
            //Presenter.Item.SERV_CueGas = SERV_CueGas.Text;

            Presenter.Item.SERV_CuenIngreso = SERV_CueVta.Text;
            Presenter.Item.SERV_CuenCosto = SERV_CueGas.Text;
            Presenter.Item.SERV_CuenPuente = SERV_CuenPuente.Text;

            Presenter.Item.SERV_AfeDet = SERV_AfeDet.Checked;
            Decimal pordet;
            if (Decimal.TryParse(SERV_PorDet.Text, out pordet))
            { Presenter.Item.SERV_PorDet = pordet; }

            Presenter.Item.SERV_AfeIgv = SERV_AfeIgv.Checked;

            if (TIPO_CodDET.TiposSelectedItem != null)
            {
               Presenter.Item.TIPO_TabDET = TIPO_CodDET.TiposSelectedItem.TIPO_CodTabla;
               Presenter.Item.TIPO_CodDET = TIPO_CodDET.TiposSelectedItem.TIPO_CodTipo;
            }
            else
            {
               Presenter.Item.TIPO_TabDET = null;
               Presenter.Item.TIPO_CodDET = null;
            }

            


            Presenter.Item.SERV_DefinidoPor = SERV_DefinidoPor.Text;

            Presenter.Item.SERV_Observaciones = SERV_Observaciones.Text;

            Presenter.Item.ServiciosDocumentos = ((ObservableCollection<Entities.ServiciosDocumentos>)BSItemsDocumentos.DataSource);

            Presenter.Item.CENT_Ano = null;
            if (cmbCENT_Ano.SelectedValue != null && !String.IsNullOrEmpty(cmbCENT_Ano.SelectedValue.ToString())) { Presenter.Item.CENT_Ano = cmbCENT_Ano.SelectedValue.ToString(); }

            Presenter.Item.CENT_Codigo = null;
            if (txaCENT_Codigo.Value != null) { Presenter.Item.CENT_Codigo = txaCENT_Codigo.Value.ToString(); }

            Presenter.Item.TIPO_CodOPE = null; Presenter.Item.TIPO_TabOPE = null;
            if (cmbTIPO_CodOPE.SelectedValue != null && !String.IsNullOrEmpty(cmbTIPO_CodOPE.SelectedValue.ToString().Trim()))
            { Presenter.Item.TIPO_CodOPE = cmbTIPO_CodOPE.SelectedValue.ToString(); Presenter.Item.TIPO_TabOPE = ((DataRowView)(cmbTIPO_CodOPE.SelectedItem))["TIPO_CodTabla"].ToString(); }

            Presenter.Item.TIPO_CodOPE_Costo = null; Presenter.Item.TIPO_TabOPE_Costo = null;
            if (cmbTIPO_CodOPE_Costo.SelectedValue != null && !String.IsNullOrEmpty(cmbTIPO_CodOPE_Costo.SelectedValue.ToString().Trim()))
            { Presenter.Item.TIPO_CodOPE_Costo = cmbTIPO_CodOPE_Costo.SelectedValue.ToString(); Presenter.Item.TIPO_TabOPE_Costo = ((DataRowView)(cmbTIPO_CodOPE_Costo.SelectedItem))["TIPO_CodTabla"].ToString(); }

         }
         catch (Exception)
         { }
      }
      public void SetItem()
      {
         try
         {
            if (Presenter.Item.SERV_Activo.HasValue)
            { SERV_Activo.Checked = Presenter.Item.SERV_Activo.Value; }
            SERV_Codigo.Text = Presenter.Item.SERV_Codigo.ToString();
            CONS_CodLNG.ConstantesSelectedValue = Presenter.Item.CONS_CodLNG;
            SERV_TipoMov.ConstantesSelectedValue = Presenter.Item.SERV_TipoMov;
            CONS_CodRGM.ConstantesSelectedValue = Presenter.Item.CONS_CodRGM;
            CONS_CodVia.ConstantesSelectedValue = Presenter.Item.CONS_CodVia;
            SERV_NombreCorto.Text = Presenter.Item.SERV_NombreCorto;
            if (Presenter.Item.SERV_Flete.HasValue)
            { SERV_Flete.Checked = Presenter.Item.SERV_Flete.Value; }
            if (Presenter.Item.SERV_ExcesoFlete.HasValue)
            { chkSERV_ExcesoFlete.Checked = Presenter.Item.SERV_ExcesoFlete.Value; }
            SERV_Nombre_SPA.Text = Presenter.Item.SERV_Nombre_SPA;
            SERV_Nombre_ENG.Text = Presenter.Item.SERV_Nombre_ENG;
            SERV_Valor.Text = Presenter.Item.SERV_Valor.ToString();
            SERV_Glosa.Text = Presenter.Item.SERV_Glosa;
            TIPO_CodMND.TiposSelectedValue = Presenter.Item.TIPO_CodMND;
            CONS_CodBAS.ConstantesSelectedValue = Presenter.Item.CONS_CodBAS;
            SERV_Valor.Text = System.Convert.ToString(Presenter.Item.SERV_Valor);
            SERV_CobMin.Text = System.Convert.ToString(Presenter.Item.SERV_CobMin);
            //SERV_CueVta.Text = Presenter.Item.SERV_CueVta;
            //SERV_CueGas.Text = Presenter.Item.SERV_CueGas;
            SERV_CueVta.Text = Presenter.Item.SERV_CuenIngreso;
            SERV_CueGas.Text = Presenter.Item.SERV_CuenCosto;
            if (Presenter.Item.SERV_AfeIgv.HasValue)
            { SERV_AfeIgv.Checked = Presenter.Item.SERV_AfeIgv.Value; }
            SERV_CuenPuente.Text = Presenter.Item.SERV_CuenPuente;
            if (Presenter.Item.SERV_AfeIgv.HasValue)
            { SERV_AfeIgv.Checked = Presenter.Item.SERV_AfeIgv.Value; }
            if (Presenter.Item.SERV_AfeDet.HasValue)
            { SERV_AfeDet.Checked = Presenter.Item.SERV_AfeDet.Value; }
            SERV_PorDet.Text = Presenter.Item.SERV_PorDet.ToString();
            TIPO_CodDET.TiposSelectedValue = Presenter.Item.TIPO_CodDET;
            SERV_DefinidoPor.Text = Presenter.Item.SERV_DefinidoPor;
            SERV_Observaciones.Text = Presenter.Item.SERV_Observaciones;

            //BSItemsDetalles.DataSource = Presenter.Item.ServciosDocumentos;

            //VIAMaritima.Checked = Presenter.Item.ListServicio_Via.Where(svia => svia.CONS_CodVIA == Delfin.Controls.variables.CONSVIA_Maritima).FirstOrDefault() != null;
            //VIAAerea.Checked = Presenter.Item.ListServicio_Via.Where(svia => svia.CONS_CodVIA == Delfin.Controls.variables.CONSVIA_Aerea).FirstOrDefault() != null;
            //VIATerrestre.Checked = Presenter.Item.ListServicio_Via.Where(svia => svia.CONS_CodVIA == Delfin.Controls.variables.CONSVIA_Terrestre).FirstOrDefault() != null;
            //VIAFluvial.Checked = Presenter.Item.ListServicio_Via.Where(svia => svia.CONS_CodVIA == Delfin.Controls.variables.CONSVIA_Fluvial).FirstOrDefault() != null;

            BSItemsDocumentos.DataSource = Presenter.Item.ServiciosDocumentos;
            BSItemsDocumentos.ResetBindings(true);

            SERV_Nombre_SPA.Select();
            HashFormulario = Infrastructure.Client.FormClose.FormValidateChanges.iniciarComparacionFormulario(this);

            if (!String.IsNullOrEmpty(Presenter.Item.CENT_Ano)) { cmbCENT_Ano.SelectedValue = Presenter.Item.CENT_Ano; }
            if (!String.IsNullOrEmpty(Presenter.Item.CENT_Codigo))
            {
               txaCENT_Codigo.SetValue(Presenter.Item.CENT_Codigo, Presenter.Item.CENT_Codigo);
               txaCENT_Desc.SetValue(Presenter.Item.CENT_Desc, Presenter.Item.CENT_Desc);
            }

            if (!String.IsNullOrEmpty(Presenter.Item.TIPO_CodOPE) && !String.IsNullOrEmpty(Presenter.Item.TIPO_TabOPE))
            { cmbTIPO_CodOPE.SelectedValue = Presenter.Item.TIPO_CodOPE; }

            if (!String.IsNullOrEmpty(Presenter.Item.TIPO_CodOPE_Costo) && !String.IsNullOrEmpty(Presenter.Item.TIPO_TabOPE_Costo))
            { cmbTIPO_CodOPE_Costo.SelectedValue = Presenter.Item.TIPO_CodOPE_Costo; }


         }
         catch (Exception)
         { }
      }
      public void ShowValidation()
      {
         try
         {
            Infrastructure.Client.FormClose.FormShowErrorProvider<Entities.Servicio>.Validate(Presenter.Item, this, errorProvider1);
         }
         catch (Exception)
         { }
      }
      #endregion

      #region [ Metodos ]
      /// <summary>
      /// Autor: Cristhian Jose Apaza
      /// Descripcion: Metodo que configura la interfaz según el tipo de movimiento
      /// </summary>
      private void ShowCamposCostoIngresos()
      {
         try
         {
            if (SERV_TipoMov.ConstantesSelectedItem != null)
            {

               switch (SERV_TipoMov.ConstantesSelectedItem.CONS_CodTipo)
               {
                  case TdoMov.Ambos:
                     lblSERV_CueVta.Enabled = true;
                     SERV_CueVta.Enabled = true;
                     lblSERV_CueGas.Enabled = true;
                     SERV_CueGas.Enabled = true;
                     break;
                  case TdoMov.Costos:
                     lblSERV_CueVta.Enabled = false;
                     SERV_CueVta.Enabled = false;
                     lblSERV_CueGas.Enabled = true;
                     SERV_CueGas.Enabled = true;
                     SERV_CueVta.Text = null;
                     break;
                  case TdoMov.Ingresos:
                     lblSERV_CueVta.Enabled = true;
                     SERV_CueVta.Enabled = true;
                     lblSERV_CueGas.Enabled = false;
                     SERV_CueGas.Enabled = false;
                     SERV_CueGas.Text = null;
                     break;
               }
            }
            else
            {
               lblSERV_CueVta.Enabled = false;
               SERV_CueVta.Enabled = false;
               lblSERV_CueGas.Enabled = false;
               SERV_CueGas.Enabled = false;
               SERV_CueVta.Text = null;
               SERV_CueGas.Text = null;
               //Faltan Documentos
            }

         }
         catch (Exception ex)
         { throw ex; }
      }
      private void ShowRegimen()
      {
         try
         {
            if (CONS_CodLNG.ConstantesSelectedItem != null)
            {
               switch (CONS_CodLNG.ConstantesSelectedItem.CONS_CodTipo)
               {
                  case Delfin.Controls.variables.CONSLNG_Exportacion:
                     CONS_CodRGM.ConstantesSelectedValue = Delfin.Controls.variables.CONSRGM_Exportacion;
                     CONS_CodRGM.Enabled = false;
                     break;
                  case Delfin.Controls.variables.CONSLNG_Mandato:
                  case Delfin.Controls.variables.CONSLNG_OtrosTraficos:
                     CONS_CodRGM.ConstantesSelectedValue = Delfin.Controls.variables.CONSRGM_Importacion;
                     CONS_CodRGM.Enabled = false;
                     break;
                  case Delfin.Controls.variables.CONSLNG_SLI:
                     CONS_CodRGM.ConstantesSelectedValue = null;
                     CONS_CodRGM.Enabled = true;
                     break;
                  default:
                     CONS_CodRGM.ConstantesSelectedValue = null;
                     CONS_CodRGM.Enabled = false;
                     break;
               }
            }
            else
            {
               CONS_CodRGM.ConstantesSelectedValue = null;
               CONS_CodRGM.Enabled = false;
            }
         }
         catch (Exception ex)
         { throw ex; }
      }
      #endregion

      #region [ Eventos ]
      private void btnGuardar_Click(object sender, EventArgs e)
      {
         try
         {
            grdItemsDocumentos.EndEdit();
            if (Presenter.Guardar())
            {
               this.FormClosing -= MView_FormClosing;
               errorProvider1.Dispose();
               Presenter.Actualizar();
               this.Close();
            }
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al Guardar.", ex); }
      }
      private void btnSalir_Click(object sender, EventArgs e)
      {
         try
         {
            this.FormClosing -= MView_FormClosing;
            errorProvider1.Dispose();
            if (Infrastructure.Client.FormClose.FormValidateChanges.verificarCambioFormulario(this, HashFormulario))
            {
               if (Presenter.GuardarCambios() != System.Windows.Forms.DialogResult.Cancel)
               { this.Close(); }
               else
               { this.FormClosing += MView_FormClosing; }
            }
            else
            { this.Close(); }
            Closing = true;
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al cerrar el formulario.", ex); }
      }
      private void SERV_AfeDet_CheckedChanged(object sender, EventArgs e)
      {
         try
         {
            /*Cristhian Jose Apaza*/
            //Combo tipo de detraccion
            lblTIPO_CodDET.Enabled = SERV_AfeDet.Checked;
            TIPO_CodDET.Enabled = SERV_AfeDet.Checked;
            //Porcentaje de detraccion
            lblSERV_PorDet.Enabled = SERV_AfeDet.Checked;
            SERV_PorDet.Enabled = SERV_AfeDet.Checked;
            SERV_PorDet.Text = "0.00";

         }
         catch (Exception)
         { }
      }
      private void SERV_TipoMov_SelectedIndexChanged(object sender, EventArgs e)
      {
         ShowCamposCostoIngresos();
      }
      private void CONS_CodLNG_SelectedIndexChanged(object sender, EventArgs e)
      {
         ShowRegimen();
      }
      private void MView_FormClosing(object sender, FormClosingEventArgs e)
      {
         try
         {
            if (Closing != true)
            {
               this.FormClosing -= MView_FormClosing;
               if (Infrastructure.Client.FormClose.FormValidateChanges.verificarCambioFormulario(this, HashFormulario))
               {
                  if (Presenter.GuardarCambios() == System.Windows.Forms.DialogResult.Cancel)
                  {
                     e.Cancel = true;
                     this.FormClosing += new FormClosingEventHandler(MView_FormClosing);
                  }
               }
            }
            else
            { Closing = false; e.Cancel = true; }
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al cerrar el formulario.", ex); }
      }


      private void txaCENT_Desc_AyudaClick(object sender, EventArgs e)
      {
         try
         {
            String _CENT_Codigo = null;
            String _CENT_Desc = txaCENT_Desc.Text;
            if (Presenter.AyudaCentroCto(cmbCENT_Ano.SelectedValue.ToString(), ref _CENT_Codigo, ref _CENT_Desc))
            {
               txaCENT_Codigo.SetValue(_CENT_Codigo, _CENT_Codigo);
               txaCENT_Desc.SetValue(_CENT_Desc, _CENT_Desc);
            }
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al cargar la ayuda de Centros de Costo.", ex); }
      }

      private void txaCENT_Codigo_AyudaClick(object sender, EventArgs e)
      {
         try
         {

            String _CENT_Codigo = txaCENT_Codigo.Text;
            String _CENT_Desc = null;
            if (Presenter.AyudaCentroCto(cmbCENT_Ano.SelectedValue.ToString(), ref _CENT_Codigo, ref _CENT_Desc))
            {
               txaCENT_Codigo.SetValue(_CENT_Codigo, _CENT_Codigo);
               txaCENT_Desc.SetValue(_CENT_Desc, _CENT_Desc);
            }

         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al cargar la ayuda de Centros de Costo.", ex); }
      }

      private void txaCENT_Codigo_AyudaClean(object sender, EventArgs e)
      {
         try
         {
            if (txaCENT_Codigo.Value == null)
            { txaCENT_Desc.ClearValue(); txaCENT_Codigo.ClearValue(); }
         }
         catch (Exception)
         { }
      }

      private void txaCENT_Desc_AyudaClean(object sender, EventArgs e)
      {
         try
         {
            if (txaCENT_Desc.Value == null)
            { txaCENT_Desc.ClearValue(); txaCENT_Codigo.ClearValue(); }
         }
         catch (Exception)
         { }
      }


      #endregion

      #region [ Servicios/Documentos ]

      #region [ Propiedades ]
      public BindingSource BSItemsDocumentos { get; set; }
      #endregion

      #region [ Metodos ]
      private void FormatGridDocumentos()
      {
         try
         {

            Telerik.WinControls.UI.Localization.RadGridLocalizationProvider.CurrentProvider = new Infrastructure.WinForms.Controls.MySpanishRadGridLocalizationProvider();
            this.grdItemsDocumentos.Columns.Clear();
            this.grdItemsDocumentos.AllowAddNewRow = false;

            //TIPOS DE DOCUMENTOS (TDO)
            Telerik.WinControls.UI.GridViewComboBoxColumn _servicio = new Telerik.WinControls.UI.GridViewComboBoxColumn();
            _servicio.Name = "TIPO_CodTDO";
            _servicio.HeaderText = "DOCUMENTO";
            _servicio.FieldName = "TIPO_CodTDO";
            _servicio.ValueMember = "TIPO_CodTipo";
            _servicio.DisplayMember = "TIPO_Desc1";
            _servicio.DataSource = Presenter.ListTiposTDO;
            _servicio.DataType = typeof(System.String);
            this.grdItemsDocumentos.Columns.Add(_servicio);

            //TIPO DE MOVIMIENTO (INGRESOS/COSTOS)
            Telerik.WinControls.UI.GridViewComboBoxColumn _ingresocosto = new Telerik.WinControls.UI.GridViewComboBoxColumn();
            _ingresocosto.Name = "SEDO_Tipo";
            _ingresocosto.HeaderText = "INGRESO/COSTO";
            _ingresocosto.FieldName = "SEDO_Tipo";
            _ingresocosto.ValueMember = "StrCodigo";
            _ingresocosto.DisplayMember = "StrDesc";
            _ingresocosto.DataSource = Presenter.ListIngresoCosto;
            _ingresocosto.FilteringMode = Telerik.WinControls.UI.GridViewFilteringMode.DisplayMember;
            this.grdItemsDocumentos.Columns.Add(_ingresocosto);

            this.grdItemsDocumentos.Columns.Add("SEDO_Item", "Item", "SEDO_Item");

            grdItemsDocumentos.BestFitColumns();
            Infrastructure.WinForms.Controls.GridAutoFit.Fit(grdItemsDocumentos);

            this.grdItemsDocumentos.SelectionMode = Telerik.WinControls.UI.GridViewSelectionMode.CellSelect;
            this.grdItemsDocumentos.MultiSelect = false;

            this.grdItemsDocumentos.ShowFilteringRow = false;
            this.grdItemsDocumentos.EnableFiltering = false;
            this.grdItemsDocumentos.MasterTemplate.EnableFiltering = false;
            this.grdItemsDocumentos.EnableGrouping = false;
            this.grdItemsDocumentos.MasterTemplate.EnableGrouping = false;
            this.grdItemsDocumentos.EnableSorting = false;
            this.grdItemsDocumentos.MasterTemplate.EnableCustomSorting = false;

            this.grdItemsDocumentos.ReadOnly = false;
            this.grdItemsDocumentos.AllowEditRow = true;

            this.grdItemsDocumentos.Columns["SEDO_Tipo"].ReadOnly = false;
            this.grdItemsDocumentos.Columns["TIPO_CodTDO"].ReadOnly = false;

            this.grdItemsDocumentos.Columns["SEDO_Tipo"].Width = 100;
            this.grdItemsDocumentos.Columns["TIPO_CodTDO"].Width = 200;

            this.grdItemsDocumentos.Columns["SEDO_Item"].IsVisible = false;

         }
         catch (Exception ex)
         {
            Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, Infrastructure.Aspect.Constants.Mensajes.FormatDataGridView + " (Grid Servicios)", ex);
         }
      }
      private void AddDocumento()
      {
         try
         {
            Entities.ServiciosDocumentos _serviciosDocumentos = new Entities.ServiciosDocumentos();
            _serviciosDocumentos.SERV_Codigo = Presenter.Item.SERV_Codigo;
            _serviciosDocumentos.TIPO_TabTDO = "TDO";
            _serviciosDocumentos.Instance = Infrastructure.Aspect.BusinessEntity.InstanceEntity.Added;
            BSItemsDocumentos.Add(_serviciosDocumentos);
            BSItemsDocumentos.ResetBindings(true);
         }
         catch (Exception ex)
         {
            Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al agregar un documento", ex);
         }
      }
      private void DeleteDocumento()
      {
         try
         {
            if (BSItemsDocumentos.Current != null && BSItemsDocumentos.Current is Entities.ServiciosDocumentos)
            {
               Entities.ServiciosDocumentos _serviciosDocumentos = (Entities.ServiciosDocumentos)BSItemsDocumentos.Current;
               if (_serviciosDocumentos.Instance != Infrastructure.Aspect.BusinessEntity.InstanceEntity.Added)
               {
                  _serviciosDocumentos.SERV_Codigo = Presenter.Item.SERV_Codigo;
                  _serviciosDocumentos.Instance = Infrastructure.Aspect.BusinessEntity.InstanceEntity.Deleted;
                  Presenter.Item.ServiciosDocumentosDelete.Add(_serviciosDocumentos);
               }
               BSItemsDocumentos.RemoveCurrent();
               BSItemsDocumentos.ResetBindings(true);
            }
         }
         catch (Exception ex)
         {
            Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al eliminar un servicio", ex);
         }
      }
      #endregion

      #region [ Eventos ]
      private void btnAddDocumentos_Click(object sender, EventArgs e)
      {
         AddDocumento();
      }
      private void btnDeleteDocumentos_Click(object sender, EventArgs e)
      {
         DeleteDocumento();
      }

      private void btnAuditoria_Click(object sender, EventArgs e)
      {

         try
         {
            ObservableCollection<Infrastructure.Aspect.DataAccess.DataAccessFilterSQL> _filters = new ObservableCollection<Infrastructure.Aspect.DataAccess.DataAccessFilterSQL>();
            _filters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@pintSERV_Codigo", FilterValue = Presenter.Item.SERV_Codigo, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.Int32, FilterSize = 4 });

            Delfin.Controls.AuditoriaView _auditoriaView = new Controls.AuditoriaView(Presenter.ContainerService, Delfin.Controls.TipoAuditoria.NEX_AUDISS_COM_Servicio, _filters);
            _auditoriaView.Show();
         }
         catch (Exception)
         { }
      }
      #endregion

      private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
      {

      }

        #endregion

        private void MAN004MView_Load(object sender, EventArgs e)
        {

        }
    }
}

