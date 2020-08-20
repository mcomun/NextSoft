namespace Delfin.Principal
{
   partial class OPE001DView
   {
      /// <summary>
      /// Required designer variable.
      /// </summary>
      private System.ComponentModel.IContainer components = null;

      /// <summary>
      /// Clean up any resources being used.
      /// </summary>
      /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
      protected override void Dispose(bool disposing)
      {
         if (disposing && (components != null))
         {
            components.Dispose();
         }
         base.Dispose(disposing);
      }

      #region Windows Form Designer generated code

      /// <summary>
      /// Required method for Designer support - do not modify
      /// the contents of this method with the code editor.
      /// </summary>
      private void InitializeComponent()
      {
         this.pnlBotones = new System.Windows.Forms.Panel();
         this.btnCancelar = new System.Windows.Forms.Button();
         this.btnAceptar = new System.Windows.Forms.Button();
         this.tableTDO = new System.Windows.Forms.TableLayoutPanel();
         this.lblTIPO_CodTDO = new System.Windows.Forms.Label();
         this.lblSCOT_NumeroTDO = new System.Windows.Forms.Label();
         this.txtSCOT_NumeroTDO = new Infrastructure.WinForms.Controls.TextBoxAlfaNumerico();
         this.lblSCOT_SerieTDO = new System.Windows.Forms.Label();
         this.cmbTIPO_CodTDO = new Delfin.Controls.Tipos.ComboBoxTipos();
         this.txtSCOT_SerieTDO = new Infrastructure.WinForms.Controls.TextBoxAlfaNumerico();
         this.lblSCOT_FechaEmision = new System.Windows.Forms.Label();
         this.dtmSCOT_FechaEmision = new Infrastructure.WinForms.Controls.MaskDateTime();
         this.pnlBotones.SuspendLayout();
         this.tableTDO.SuspendLayout();
         this.SuspendLayout();
         // 
         // pnlBotones
         // 
         this.pnlBotones.Controls.Add(this.btnCancelar);
         this.pnlBotones.Controls.Add(this.btnAceptar);
         this.pnlBotones.Dock = System.Windows.Forms.DockStyle.Bottom;
         this.pnlBotones.Location = new System.Drawing.Point(0, 54);
         this.pnlBotones.Name = "pnlBotones";
         this.pnlBotones.Size = new System.Drawing.Size(769, 34);
         this.pnlBotones.TabIndex = 1;
         // 
         // btnCancelar
         // 
         this.btnCancelar.Location = new System.Drawing.Point(672, 5);
         this.btnCancelar.Name = "btnCancelar";
         this.btnCancelar.Size = new System.Drawing.Size(75, 23);
         this.btnCancelar.TabIndex = 1;
         this.btnCancelar.Text = "Cancelar";
         this.btnCancelar.UseVisualStyleBackColor = true;
         // 
         // btnAceptar
         // 
         this.btnAceptar.Location = new System.Drawing.Point(591, 5);
         this.btnAceptar.Name = "btnAceptar";
         this.btnAceptar.Size = new System.Drawing.Size(75, 23);
         this.btnAceptar.TabIndex = 0;
         this.btnAceptar.Text = "Aceptar";
         this.btnAceptar.UseVisualStyleBackColor = true;
         // 
         // tableTDO
         // 
         this.tableTDO.AutoSize = true;
         this.tableTDO.ColumnCount = 10;
         this.tableTDO.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
         this.tableTDO.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
         this.tableTDO.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15F));
         this.tableTDO.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
         this.tableTDO.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
         this.tableTDO.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15F));
         this.tableTDO.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
         this.tableTDO.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
         this.tableTDO.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15F));
         this.tableTDO.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
         this.tableTDO.Controls.Add(this.dtmSCOT_FechaEmision, 1, 1);
         this.tableTDO.Controls.Add(this.lblTIPO_CodTDO, 0, 0);
         this.tableTDO.Controls.Add(this.lblSCOT_NumeroTDO, 3, 0);
         this.tableTDO.Controls.Add(this.txtSCOT_NumeroTDO, 7, 0);
         this.tableTDO.Controls.Add(this.lblSCOT_SerieTDO, 6, 0);
         this.tableTDO.Controls.Add(this.cmbTIPO_CodTDO, 1, 0);
         this.tableTDO.Controls.Add(this.txtSCOT_SerieTDO, 4, 0);
         this.tableTDO.Controls.Add(this.lblSCOT_FechaEmision, 0, 1);
         this.tableTDO.Dock = System.Windows.Forms.DockStyle.Top;
         this.tableTDO.Location = new System.Drawing.Point(0, 0);
         this.tableTDO.Name = "tableTDO";
         this.tableTDO.RowCount = 2;
         this.tableTDO.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
         this.tableTDO.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
         this.tableTDO.Size = new System.Drawing.Size(769, 54);
         this.tableTDO.TabIndex = 0;
         // 
         // lblTIPO_CodTDO
         // 
         this.lblTIPO_CodTDO.AutoSize = true;
         this.lblTIPO_CodTDO.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.lblTIPO_CodTDO.Location = new System.Drawing.Point(10, 7);
         this.lblTIPO_CodTDO.Margin = new System.Windows.Forms.Padding(10, 7, 2, 0);
         this.lblTIPO_CodTDO.Name = "lblTIPO_CodTDO";
         this.lblTIPO_CodTDO.Size = new System.Drawing.Size(105, 13);
         this.lblTIPO_CodTDO.TabIndex = 0;
         this.lblTIPO_CodTDO.Text = "Tipo Documento:";
         // 
         // lblSCOT_NumeroTDO
         // 
         this.lblSCOT_NumeroTDO.AutoSize = true;
         this.lblSCOT_NumeroTDO.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.lblSCOT_NumeroTDO.Location = new System.Drawing.Point(345, 7);
         this.lblSCOT_NumeroTDO.Margin = new System.Windows.Forms.Padding(10, 7, 2, 0);
         this.lblSCOT_NumeroTDO.Name = "lblSCOT_NumeroTDO";
         this.lblSCOT_NumeroTDO.Size = new System.Drawing.Size(42, 13);
         this.lblSCOT_NumeroTDO.TabIndex = 2;
         this.lblSCOT_NumeroTDO.Text = "Serie:";
         // 
         // txtSCOT_NumeroTDO
         // 
         this.txtSCOT_NumeroTDO.Location = new System.Drawing.Point(633, 3);
         this.txtSCOT_NumeroTDO.LongitudAceptada = 0;
         this.txtSCOT_NumeroTDO.Name = "txtSCOT_NumeroTDO";
         this.txtSCOT_NumeroTDO.RellenaCeros = false;
         this.txtSCOT_NumeroTDO.Size = new System.Drawing.Size(114, 20);
         this.txtSCOT_NumeroTDO.TabIndex = 5;
         this.txtSCOT_NumeroTDO.Tag = "SCOT_NumeroTDOMSGERROR";
         this.txtSCOT_NumeroTDO.Tipo = Infrastructure.WinForms.Controls.TextBoxAlfaNumerico.TipoTextBoxAlfaNumerico.AlfaNumerico;
         // 
         // lblSCOT_SerieTDO
         // 
         this.lblSCOT_SerieTDO.AutoSize = true;
         this.lblSCOT_SerieTDO.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.lblSCOT_SerieTDO.Location = new System.Drawing.Point(560, 7);
         this.lblSCOT_SerieTDO.Margin = new System.Windows.Forms.Padding(10, 7, 2, 0);
         this.lblSCOT_SerieTDO.Name = "lblSCOT_SerieTDO";
         this.lblSCOT_SerieTDO.Size = new System.Drawing.Size(57, 13);
         this.lblSCOT_SerieTDO.TabIndex = 4;
         this.lblSCOT_SerieTDO.Text = "Número:";
         // 
         // cmbTIPO_CodTDO
         // 
         this.cmbTIPO_CodTDO.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this.cmbTIPO_CodTDO.FormattingEnabled = true;
         this.cmbTIPO_CodTDO.Location = new System.Drawing.Point(123, 3);
         this.cmbTIPO_CodTDO.Name = "cmbTIPO_CodTDO";
         this.cmbTIPO_CodTDO.Session = null;
         this.cmbTIPO_CodTDO.Size = new System.Drawing.Size(194, 21);
         this.cmbTIPO_CodTDO.TabIndex = 1;
         this.cmbTIPO_CodTDO.Tag = "TIPO_CodTDOMSGERROR";
         this.cmbTIPO_CodTDO.TiposSelectedItem = null;
         this.cmbTIPO_CodTDO.TiposSelectedValue = null;
         this.cmbTIPO_CodTDO.TiposTitulo = null;
         // 
         // txtSCOT_SerieTDO
         // 
         this.txtSCOT_SerieTDO.Location = new System.Drawing.Point(418, 3);
         this.txtSCOT_SerieTDO.LongitudAceptada = 0;
         this.txtSCOT_SerieTDO.Name = "txtSCOT_SerieTDO";
         this.txtSCOT_SerieTDO.RellenaCeros = false;
         this.txtSCOT_SerieTDO.Size = new System.Drawing.Size(114, 20);
         this.txtSCOT_SerieTDO.TabIndex = 3;
         this.txtSCOT_SerieTDO.Tag = "SCOT_SerieTDOMSGERROR";
         this.txtSCOT_SerieTDO.Tipo = Infrastructure.WinForms.Controls.TextBoxAlfaNumerico.TipoTextBoxAlfaNumerico.AlfaNumerico;
         // 
         // lblSCOT_FechaEmision
         // 
         this.lblSCOT_FechaEmision.AutoSize = true;
         this.lblSCOT_FechaEmision.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.lblSCOT_FechaEmision.Location = new System.Drawing.Point(10, 34);
         this.lblSCOT_FechaEmision.Margin = new System.Windows.Forms.Padding(10, 7, 2, 0);
         this.lblSCOT_FechaEmision.Name = "lblSCOT_FechaEmision";
         this.lblSCOT_FechaEmision.Size = new System.Drawing.Size(105, 13);
         this.lblSCOT_FechaEmision.TabIndex = 6;
         this.lblSCOT_FechaEmision.Text = "Fec. de Emisión :";
         // 
         // dtmSCOT_FechaEmision
         // 
         this.dtmSCOT_FechaEmision.Location = new System.Drawing.Point(122, 30);
         this.dtmSCOT_FechaEmision.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
         this.dtmSCOT_FechaEmision.MinimumSize = new System.Drawing.Size(100, 22);
         this.dtmSCOT_FechaEmision.Name = "dtmSCOT_FechaEmision";
         this.dtmSCOT_FechaEmision.NSActiveMouse = false;
         this.dtmSCOT_FechaEmision.NSActiveMsgFecha = false;
         this.dtmSCOT_FechaEmision.NSChangeDate = true;
         this.dtmSCOT_FechaEmision.NSDigitos = 4;
         this.dtmSCOT_FechaEmision.NSFecha = null;
         this.dtmSCOT_FechaEmision.NSSetDateNow = false;
         this.dtmSCOT_FechaEmision.Size = new System.Drawing.Size(100, 22);
         this.dtmSCOT_FechaEmision.TabIndex = 7;
         this.dtmSCOT_FechaEmision.Tag = "SCOT_FechaEmisionMSGERROR";
         // 
         // OPE001DView
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.BackColor = System.Drawing.Color.LightSteelBlue;
         this.ClientSize = new System.Drawing.Size(769, 88);
         this.ControlBox = false;
         this.Controls.Add(this.tableTDO);
         this.Controls.Add(this.pnlBotones);
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "OPE001DView";
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
         this.Text = "Actualizar Documento";
         this.pnlBotones.ResumeLayout(false);
         this.tableTDO.ResumeLayout(false);
         this.tableTDO.PerformLayout();
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.Panel pnlBotones;
      private System.Windows.Forms.Button btnCancelar;
      private System.Windows.Forms.Button btnAceptar;
      private System.Windows.Forms.TableLayoutPanel tableTDO;
      private System.Windows.Forms.Label lblTIPO_CodTDO;
      private System.Windows.Forms.Label lblSCOT_NumeroTDO;
      private System.Windows.Forms.Label lblSCOT_SerieTDO;
      private Controls.Tipos.ComboBoxTipos cmbTIPO_CodTDO;
      private Infrastructure.WinForms.Controls.TextBoxAlfaNumerico txtSCOT_NumeroTDO;
      private Infrastructure.WinForms.Controls.TextBoxAlfaNumerico txtSCOT_SerieTDO;
      private System.Windows.Forms.Label lblSCOT_FechaEmision;
      private Infrastructure.WinForms.Controls.MaskDateTime dtmSCOT_FechaEmision;

   }
}