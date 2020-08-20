using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Delfin.Principal
{
   public partial class MAN002MView : Form, IMAN002MView
   {
      #region [ Variables ]

      #endregion

      #region [ Formulario ]
      public MAN002MView()
      {
         InitializeComponent();
         try
         {
            btnMAN_guardar.Click += new EventHandler(btnGuardar_Click);
            btnMAN_salir.Click += new EventHandler(btnSalir_Click);

            this.FormClosing += new FormClosingEventHandler(MView_FormClosing);

            txtTIPO_CodTipo.MaxLength = 3;

            txtTIPO_Desc2.MaxLength = 100;
            txtTIPO_Desc3.MaxLength = 100;
            txtTIPO_Mascara.MaxLength = 20;
            txtTIPO_DescC.MaxLength = 20;

            SetInicio();

         }
         catch (Exception)
         { }
      }

      private void SetInicio()
      {
         try
         {
            txtTIPO_Desc2.Visible = false;
            txtTIPO_Desc3.Visible = false;
            lblTIPO_Desc2.Visible = false;
            lblTIPO_Desc3.Visible = false;
            
            txnTIPO_Num1.Visible = false;
            txnTIPO_Num2.Visible = false;
            txnTIPO_Num3.Visible = false;
            txnTIPO_Num4.Visible = false;
            lblTIPO_Num1.Visible = false;
            lblTIPO_Num2.Visible = false;
            lblTIPO_Num3.Visible = false;
            lblTIPO_Num4.Visible = false;

            lblTIPO_Mascara.Visible = false;
            txtTIPO_Mascara.Visible = false;

            tableLayoutPanel2.RowStyles[3].Height = 0;
            tableLayoutPanel2.RowStyles[4].Height = 0;
            tableLayoutPanel2.RowStyles[5].Height = 0;
            tableLayoutPanel2.RowStyles[6].Height = 0;

            this.Height = 203;
         }
         catch (Exception)
         { }
      }
      #endregion

      #region [ Propiedades ]
      public MAN002Presenter Presenter { get; set; }
      private bool Closing = false;
      private System.Collections.Hashtable HashFormulario { get; set; }
      #endregion

      #region [ ICUS002MView ]
      public void LoadView()
      {
         try
         {
            cmbTIPO_CodTRF.LoadControl(Presenter.ContainerService, "Tipos de Tráfico", "TRF", "< Seleccionar Tráfico >", ListSortDirection.Ascending);
            cmbTIPO_CodTRF.Visible = false;
            lblTIPO_CodTRF.Visible = false;
            //cmbMAN.DataSource = Presenter.ListTabla;
            //cmbMAN.ValueMember = "TIPO_CodTipo";
            //cmbMAN.DisplayMember = "TIPO_Desc1";
         }
         catch (Exception)
         { }
      }

      public void ClearItem()
      {
         try
         {
            txtTIPO_Desc.Text = null;
            txtTIPO_DescC.Text = null;
         }
         catch (Exception)
         { }
      }
      public void GetItem()
      {
         try
         {
            Presenter.Item.TIPO_Num1 = Presenter.Item.TIPO_Num1;
            Presenter.Item.TIPO_CodTabla = Presenter.Item.TIPO_CodTabla;
            Presenter.Item.TIPO_CodTipo = Presenter.Item.TIPO_CodTipo;
            Presenter.Item.TIPO_Desc1 = txtTIPO_Desc.Text;
            Presenter.Item.TIPO_Desc2 = txtTIPO_Desc2.Text;
            Presenter.Item.TIPO_Desc3 = txtTIPO_Desc3.Text;
            Presenter.Item.TIPO_DescC = txtTIPO_DescC.Text;

            Presenter.Item.TIPO_Num1 = txnTIPO_Num1.Value;
            Presenter.Item.TIPO_Num2 = txnTIPO_Num2.Value;
            Presenter.Item.TIPO_Num3 = Convert.ToInt16(txnTIPO_Num3.Value);
            Presenter.Item.TIPO_Num4 = Convert.ToInt16(txnTIPO_Num4.Value);

            Presenter.Item.TIPO_Mascara = String.IsNullOrEmpty(txtTIPO_Mascara.Text) ? null : txtTIPO_Mascara.Text;


            if (!String.IsNullOrEmpty(txtTIPO_CodTipo.Text)) { Presenter.Item.TIPO_CodTipo = txtTIPO_CodTipo.Text; } else { Presenter.Item.TIPO_CodTipo = null; }
            //#####-PAISES-#####
            if (Presenter.Item.TIPO_CodTabla == Delfin.Controls.variables.TIPOTIP_PAI)
            {
               Presenter.Item.TIPO_CodTablaHijo = cmbTIPO_CodTRF.TiposSelectedItem.TIPO_CodTabla;
               Presenter.Item.TIPO_CodTipoHijo = cmbTIPO_CodTRF.TiposSelectedItem.TIPO_CodTipo;
            }
            else
            {
               Presenter.Item.TIPO_CodTablaHijo = null;
               Presenter.Item.TIPO_CodTipoHijo = null;
            }
         }
         catch (Exception)
         { }
      }
      public void SetItem()
      {
         try
         {
            txtTIPO_Desc.Text = Presenter.Item.TIPO_Desc1;
            txtTIPO_DescC.Text = Presenter.Item.TIPO_DescC;
            txtTIPO_Desc.Select();
            txtTIPO_CodTipo.Text = Presenter.Item.TIPO_CodTipo;
            txtTIPO_Desc2.Text = Presenter.Item.TIPO_Desc2;
            txtTIPO_Desc3.Text = Presenter.Item.TIPO_Desc3;
            txnTIPO_Num1.Value = Presenter.Item.TIPO_Num1.HasValue ? Presenter.Item.TIPO_Num1.Value : 0;
            txnTIPO_Num2.Value = Presenter.Item.TIPO_Num2.HasValue ? Presenter.Item.TIPO_Num2.Value : 0;
            txnTIPO_Num3.Value = Presenter.Item.TIPO_Num3.HasValue ? Presenter.Item.TIPO_Num3.Value : 0;
            txnTIPO_Num4.Value = Presenter.Item.TIPO_Num1.HasValue ? Presenter.Item.TIPO_Num4.Value : 0;
            txtTIPO_Mascara.Text = String.IsNullOrEmpty(Presenter.Item.TIPO_Mascara) ? "" : Presenter.Item.TIPO_Mascara;

            //#####-PAISES-#####
            if (Presenter.Item.TIPO_CodTabla == Delfin.Controls.variables.TIPOTIP_PAI)
            { cmbTIPO_CodTRF.TiposSelectedValue = Presenter.Item.TIPO_CodTipoHijo; }
            else
            { cmbTIPO_CodTRF.TiposSelectedValue = null; }
            //##################

            if (Presenter.Item.Instance == Infrastructure.Aspect.BusinessEntity.InstanceEntity.Modified)
            { txtTIPO_CodTipo.Enabled = false; }
            else { txtTIPO_CodTipo.Enabled = true; }

            HashFormulario = Infrastructure.Client.FormClose.FormValidateChanges.iniciarComparacionFormulario(this);
         }
         catch (Exception)
         { }
      }

      public void TRFPaises()
      {
         try
         {
            if (Presenter.Item.TIPO_CodTabla == Delfin.Controls.variables.TIPOTIP_PAI)
            {
               lblTIPO_CodTRF.Visible = true;
               cmbTIPO_CodTRF.Visible = true;
            }
            else
            {
               cmbTIPO_CodTRF.Visible = false;
               lblTIPO_CodTRF.Visible = false;
            }
         }
         catch (Exception)
         { }
      }

      public void setTamanoPorTipo()
      {
         try
         {
            SetInicio();
            switch (Presenter.Item.TIPO_CodTabla)
            {
               case "MND":
                  lblTIPO_Desc2.Text = "Descripción Larga :";
                  lblTIPO_Desc3.Text = "Simbolo :";
                  txtTIPO_Desc2.Visible = true;
                  txtTIPO_Desc3.Visible = true;
                  lblTIPO_Desc2.Visible = true;
                  lblTIPO_Desc3.Visible = true;
                  tableLayoutPanel2.RowStyles[4].Height = 27;
                  this.Height = this.Height + 27;
                  break;
               case "DES":
                  lblTIPO_Desc2.Text = "Nro Cuenta :";
                  lblTIPO_Desc3.Text = "Tipo (I/E):";
                  lblTIPO_Mascara.Text = "Centro de Costo :";
                  txtTIPO_Desc2.Visible = true;
                  txtTIPO_Desc3.Visible = true;
                  lblTIPO_Desc2.Visible = true;
                  lblTIPO_Desc3.Visible = true;
                  lblTIPO_Num1.Visible = true;
                  txnTIPO_Num1.Visible = true;
                  lblTIPO_Num2.Visible = true;
                  txnTIPO_Num2.Visible = true;
                  lblTIPO_Mascara.Visible = true;
                  txtTIPO_Mascara.Visible = true;
                  tableLayoutPanel2.RowStyles[4].Height = 27;
                  tableLayoutPanel2.RowStyles[5].Height = 27;
                  txtTIPO_Desc2.MaxLength = 17;
                  this.Height = this.Height + 27 * 3;
                  lblTIPO_Num1.Text = "Gen.Cta-Cte. (1=Si/0=No) :";
                  lblTIPO_Num2.Text = "Gastos a DC (1=Si/0=No) :";
                  break;
               case "DET":
                  tableLayoutPanel2.RowStyles[3].Height = 0;
                  tableLayoutPanel2.RowStyles[4].Height = 27;
                  tableLayoutPanel2.RowStyles[5].Height = 27;
                  lblTIPO_Desc3.Text = "Código Sunat:";
                  lblTIPO_Desc3.Visible = true;
                  txtTIPO_Desc3.Visible = true;
                  lblTIPO_Num1.Text = "Porcentaje :";
                  lblTIPO_Num1.Visible = true;
                  txnTIPO_Num1.Visible = true;
                  this.Height = this.Height + 27 * 2;
                  break;
               case "TI3":
                  tableLayoutPanel2.RowStyles[3].Height = 0;
                  tableLayoutPanel2.RowStyles[4].Height = 0;
                  tableLayoutPanel2.RowStyles[5].Height = 27;
                  lblTIPO_Num1.Text = "Porcentaje :";
                  lblTIPO_Num1.Visible = true;
                  txnTIPO_Num1.Visible = true;
                  this.Height = this.Height + 27;
                  break;
               case "TDI":
               case "PAQ":
               case "PAC":
                  lblTIPO_Desc2.Text = "Código Aduana :";
                  lblTIPO_Desc2.Visible = true;
                  txtTIPO_Desc2.Visible = true;
                  txtTIPO_Desc2.MaxLength = 100;
                  tableLayoutPanel2.RowStyles[4].Height = 27;
                  this.Height = this.Height + 27;
                  break;
               case "SER":
                  lblTIPO_Desc2.Text = "Serie de Documento :";
                  lblTIPO_Desc2.Visible = true;
                  txtTIPO_Desc2.Visible = true;
                  txtTIPO_Desc2.MaxLength = 3;
                  tableLayoutPanel2.RowStyles[4].Height = 27;
                  this.Height = this.Height + 27;
                  break;
               case "PAI":
                  tableLayoutPanel2.RowStyles[3].Height = 27;
                  this.Height = this.Height + 27;
                  break;
               case "TDO":
                  lblTIPO_Desc2.Text = "Cod.Doc.Conta. :";
                  lblTIPO_Desc2.Visible = true;
                  txtTIPO_Desc2.Visible = true;
                  txtTIPO_Desc2.MaxLength = 3;

                  lblTIPO_Desc3.Text = "Cta.Imp.(IGV/Renta) :";
                  lblTIPO_Desc3.Visible = true;
                  txtTIPO_Desc3.Visible = true;
                  txtTIPO_Desc3.MaxLength = 20;

                  tableLayoutPanel2.RowStyles[4].Height = 27;
                  this.Height = this.Height + 27;
                  break;
               case "MOV":
                  lblTIPO_Desc3.Text = "Código Sunat :";
                  txtTIPO_Desc3.Visible = true;
                  lblTIPO_Desc3.Visible = true;
                  tableLayoutPanel2.RowStyles[4].Height = 27;
                  txtTIPO_Desc3.MaxLength = 17;
                  this.Height = this.Height + 27 * 2;
                  break;
               default:
                  break;
            }
         }
         catch (Exception)
         { }
      }

      public void ShowValidation()
      {
         try
         {
            Infrastructure.Client.FormClose.FormShowErrorProvider<Entities.Tipos>.Validate(Presenter.Item, this, errorProvider1);
            Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Presenter.Title, "Faltan ingresar datos obligatorios: ", Presenter.Item.MensajeError, Infrastructure.WinForms.Controls.Dialogos.Boton.Detalles);
         }
         catch (Exception)
         { }
      }
      #endregion

      #region [ Metodos ]

      #endregion

      #region [ Eventos ]
      private void btnGuardar_Click(object sender, EventArgs e)
      {
         try
         {
            if (Presenter.Guardar())
            {
               this.FormClosing -= MView_FormClosing;
               errorProvider1.Dispose();
               Presenter.Actualizar();
               this.Close();
            }
         }
         catch (Exception)
         { }
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
      #endregion

      private void cmbMAN_SelectedIndexChanged(object sender, EventArgs e)
      {

      }
   }
}


