namespace Delfin.Principal
{
   partial class MAN007MView
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
            this.components = new System.ComponentModel.Container();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnMAN_salir = new System.Windows.Forms.Button();
            this.btnMAN_guardar = new System.Windows.Forms.Button();
            this.panelCaption1 = new Infrastructure.WinForms.Controls.PanelCaption();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.PUER_Favorito = new System.Windows.Forms.CheckBox();
            this.PUER_Codigo = new Infrastructure.WinForms.Controls.TextBoxNumerico();
            this.PUER_Nombre = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lblEMPR_RUC = new System.Windows.Forms.Label();
            this.PUER_Activo = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.CONS_CodVia = new Delfin.Controls.Tipos.ComboBoxConstantes();
            this.label5 = new System.Windows.Forms.Label();
            this.PUER_CodEstandar = new System.Windows.Forms.TextBox();
            this.TIPO_CodPais = new Delfin.Controls.Tipos.ComboBoxTipos();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblPUER_CodAduana = new System.Windows.Forms.Label();
            this.txtPUER_CodAduana = new System.Windows.Forms.TextBox();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.LightSteelBlue;
            this.panel3.Controls.Add(this.btnMAN_salir);
            this.panel3.Controls.Add(this.btnMAN_guardar);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(735, 50);
            this.panel3.TabIndex = 0;
            // 
            // btnMAN_salir
            // 
            this.btnMAN_salir.AutoSize = true;
            this.btnMAN_salir.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnMAN_salir.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnMAN_salir.FlatAppearance.BorderColor = System.Drawing.Color.LightSteelBlue;
            this.btnMAN_salir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMAN_salir.ForeColor = System.Drawing.Color.Black;
            this.btnMAN_salir.Image = global::Delfin.Principal.Properties.Resources.undo;
            this.btnMAN_salir.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnMAN_salir.Location = new System.Drawing.Point(57, 0);
            this.btnMAN_salir.Margin = new System.Windows.Forms.Padding(0);
            this.btnMAN_salir.Name = "btnMAN_salir";
            this.btnMAN_salir.Size = new System.Drawing.Size(55, 50);
            this.btnMAN_salir.TabIndex = 1;
            this.btnMAN_salir.Text = "&Salir";
            this.btnMAN_salir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnMAN_salir.UseVisualStyleBackColor = true;
            this.btnMAN_salir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // btnMAN_guardar
            // 
            this.btnMAN_guardar.AutoSize = true;
            this.btnMAN_guardar.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnMAN_guardar.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnMAN_guardar.FlatAppearance.BorderColor = System.Drawing.Color.LightSteelBlue;
            this.btnMAN_guardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMAN_guardar.ForeColor = System.Drawing.Color.Black;
            this.btnMAN_guardar.Image = global::Delfin.Principal.Properties.Resources.save;
            this.btnMAN_guardar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnMAN_guardar.Location = new System.Drawing.Point(0, 0);
            this.btnMAN_guardar.Margin = new System.Windows.Forms.Padding(0);
            this.btnMAN_guardar.Name = "btnMAN_guardar";
            this.btnMAN_guardar.Size = new System.Drawing.Size(57, 50);
            this.btnMAN_guardar.TabIndex = 0;
            this.btnMAN_guardar.Text = "&Guardar";
            this.btnMAN_guardar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnMAN_guardar.UseVisualStyleBackColor = true;
            this.btnMAN_guardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // panelCaption1
            // 
            this.panelCaption1.AllowActive = false;
            this.panelCaption1.AntiAlias = false;
            this.panelCaption1.Caption = "Datos de Puerto";
            this.panelCaption1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelCaption1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
            this.panelCaption1.InactiveGradientHighColor = System.Drawing.Color.SteelBlue;
            this.panelCaption1.InactiveGradientLowColor = System.Drawing.Color.MidnightBlue;
            this.panelCaption1.Location = new System.Drawing.Point(0, 50);
            this.panelCaption1.Name = "panelCaption1";
            this.panelCaption1.Size = new System.Drawing.Size(735, 26);
            this.panelCaption1.TabIndex = 0;
            // 
            // errorProvider1
            // 
            this.errorProvider1.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errorProvider1.ContainerControl = this;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.AutoSize = true;
            this.tableLayoutPanel2.ColumnCount = 7;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.Controls.Add(this.PUER_Favorito, 4, 1);
            this.tableLayoutPanel2.Controls.Add(this.PUER_Codigo, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.PUER_Nombre, 1, 3);
            this.tableLayoutPanel2.Controls.Add(this.label2, 0, 3);
            this.tableLayoutPanel2.Controls.Add(this.lblEMPR_RUC, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.PUER_Activo, 4, 0);
            this.tableLayoutPanel2.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.CONS_CodVia, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.label5, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.PUER_CodEstandar, 1, 2);
            this.tableLayoutPanel2.Controls.Add(this.TIPO_CodPais, 4, 2);
            this.tableLayoutPanel2.Controls.Add(this.label4, 3, 0);
            this.tableLayoutPanel2.Controls.Add(this.label3, 3, 1);
            this.tableLayoutPanel2.Controls.Add(this.label6, 3, 2);
            this.tableLayoutPanel2.Controls.Add(this.lblPUER_CodAduana, 0, 4);
            this.tableLayoutPanel2.Controls.Add(this.txtPUER_CodAduana, 1, 4);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel2.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 76);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 5;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(735, 135);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // PUER_Favorito
            // 
            this.PUER_Favorito.AutoSize = true;
            this.PUER_Favorito.Dock = System.Windows.Forms.DockStyle.Left;
            this.PUER_Favorito.Location = new System.Drawing.Point(518, 30);
            this.PUER_Favorito.Name = "PUER_Favorito";
            this.PUER_Favorito.Size = new System.Drawing.Size(15, 21);
            this.PUER_Favorito.TabIndex = 6;
            this.PUER_Favorito.Tag = "PUER_FavoritoMSGERROR";
            this.PUER_Favorito.UseVisualStyleBackColor = true;
            // 
            // PUER_Codigo
            // 
            this.PUER_Codigo.BaseTipo = Infrastructure.WinForms.Controls.EstandaresFormato.General;
            this.PUER_Codigo.Decimales = 0;
            this.PUER_Codigo.Enteros = 11;
            this.PUER_Codigo.Formato = "##,###,###,##0.";
            this.PUER_Codigo.Location = new System.Drawing.Point(153, 30);
            this.PUER_Codigo.MaxLength = 12;
            this.PUER_Codigo.Name = "PUER_Codigo";
            this.PUER_Codigo.Negativo = true;
            this.PUER_Codigo.ReadOnly = true;
            this.PUER_Codigo.SinFormato = true;
            this.PUER_Codigo.Size = new System.Drawing.Size(194, 20);
            this.PUER_Codigo.TabIndex = 2;
            this.PUER_Codigo.Tag = "PUER_CodigoMSGERROR";
            this.PUER_Codigo.Text = "0";
            this.PUER_Codigo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.PUER_Codigo.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // PUER_Nombre
            // 
            this.tableLayoutPanel2.SetColumnSpan(this.PUER_Nombre, 4);
            this.PUER_Nombre.Location = new System.Drawing.Point(153, 84);
            this.PUER_Nombre.MaxLength = 100;
            this.PUER_Nombre.Name = "PUER_Nombre";
            this.PUER_Nombre.Size = new System.Drawing.Size(559, 20);
            this.PUER_Nombre.TabIndex = 4;
            this.PUER_Nombre.Tag = "PUER_NombreMSGERROR";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(10, 88);
            this.label2.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Nombre:";
            // 
            // lblEMPR_RUC
            // 
            this.lblEMPR_RUC.AutoSize = true;
            this.lblEMPR_RUC.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEMPR_RUC.Location = new System.Drawing.Point(10, 34);
            this.lblEMPR_RUC.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
            this.lblEMPR_RUC.Name = "lblEMPR_RUC";
            this.lblEMPR_RUC.Size = new System.Drawing.Size(52, 13);
            this.lblEMPR_RUC.TabIndex = 4;
            this.lblEMPR_RUC.Text = "Codigo:";
            // 
            // PUER_Activo
            // 
            this.PUER_Activo.AutoSize = true;
            this.PUER_Activo.Dock = System.Windows.Forms.DockStyle.Left;
            this.PUER_Activo.Location = new System.Drawing.Point(518, 3);
            this.PUER_Activo.Name = "PUER_Activo";
            this.PUER_Activo.Size = new System.Drawing.Size(15, 21);
            this.PUER_Activo.TabIndex = 5;
            this.PUER_Activo.Tag = "PUER_ActivoMSGERROR";
            this.PUER_Activo.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(10, 7);
            this.label1.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tipo Vía:";
            // 
            // CONS_CodVia
            // 
            this.CONS_CodVia.ConstantesSelectedItem = null;
            this.CONS_CodVia.ConstantesSelectedValue = null;
            this.CONS_CodVia.ConstantesTitulo = null;
            this.CONS_CodVia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CONS_CodVia.Enabled = false;
            this.CONS_CodVia.FormattingEnabled = true;
            this.CONS_CodVia.Location = new System.Drawing.Point(153, 3);
            this.CONS_CodVia.Name = "CONS_CodVia";
            this.CONS_CodVia.Size = new System.Drawing.Size(194, 21);
            this.CONS_CodVia.TabIndex = 1;
            this.CONS_CodVia.Tag = "CONS_CodViaMSGERROR";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(10, 61);
            this.label5.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(106, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Codigo Estandar:";
            // 
            // PUER_CodEstandar
            // 
            this.PUER_CodEstandar.Location = new System.Drawing.Point(153, 57);
            this.PUER_CodEstandar.Name = "PUER_CodEstandar";
            this.PUER_CodEstandar.Size = new System.Drawing.Size(194, 20);
            this.PUER_CodEstandar.TabIndex = 3;
            this.PUER_CodEstandar.Tag = "PUER_CodEstandarMSGERROR";
            // 
            // TIPO_CodPais
            // 
            this.TIPO_CodPais.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.TIPO_CodPais.FormattingEnabled = true;
            this.TIPO_CodPais.Location = new System.Drawing.Point(518, 57);
            this.TIPO_CodPais.Name = "TIPO_CodPais";
            this.TIPO_CodPais.Size = new System.Drawing.Size(194, 21);
            this.TIPO_CodPais.TabIndex = 7;
            this.TIPO_CodPais.Tag = "TIPO_CodPaisMSGERROR";
            this.TIPO_CodPais.TiposSelectedItem = null;
            this.TIPO_CodPais.TiposSelectedValue = null;
            this.TIPO_CodPais.TiposTitulo = null;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(375, 7);
            this.label4.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Activo:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(375, 34);
            this.label3.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Favorito:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(375, 61);
            this.label6.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "País:";
            // 
            // lblPUER_CodAduana
            // 
            this.lblPUER_CodAduana.AutoSize = true;
            this.lblPUER_CodAduana.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblPUER_CodAduana.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPUER_CodAduana.Location = new System.Drawing.Point(10, 115);
            this.lblPUER_CodAduana.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
            this.lblPUER_CodAduana.Name = "lblPUER_CodAduana";
            this.lblPUER_CodAduana.Size = new System.Drawing.Size(137, 20);
            this.lblPUER_CodAduana.TabIndex = 12;
            this.lblPUER_CodAduana.Text = "Codigo Aduana :";
            // 
            // txtPUER_CodAduana
            // 
            this.txtPUER_CodAduana.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtPUER_CodAduana.Location = new System.Drawing.Point(153, 111);
            this.txtPUER_CodAduana.MaxLength = 5;
            this.txtPUER_CodAduana.Name = "txtPUER_CodAduana";
            this.txtPUER_CodAduana.Size = new System.Drawing.Size(194, 20);
            this.txtPUER_CodAduana.TabIndex = 4;
            this.txtPUER_CodAduana.Tag = "PUER_CodAduanaMSGERROR";
            // 
            // MAN007MView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.CancelButton = this.btnMAN_salir;
            this.ClientSize = new System.Drawing.Size(735, 215);
            this.Controls.Add(this.tableLayoutPanel2);
            this.Controls.Add(this.panelCaption1);
            this.Controls.Add(this.panel3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MAN007MView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Datos de Puerto";
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

      }



      #endregion

      private System.Windows.Forms.Panel panel3;
      private System.Windows.Forms.Button btnMAN_salir;
      private System.Windows.Forms.Button btnMAN_guardar;
      private Infrastructure.WinForms.Controls.PanelCaption panelCaption1;
      private System.Windows.Forms.ErrorProvider errorProvider1;
      private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
      private System.Windows.Forms.Label lblEMPR_RUC;
      private Infrastructure.WinForms.Controls.TextBoxNumerico PUER_Codigo;
      private System.Windows.Forms.Label label4;
      private System.Windows.Forms.Label label2;
      private System.Windows.Forms.Label label1;
      private System.Windows.Forms.Label label5;
      private Controls.Tipos.ComboBoxConstantes CONS_CodVia;
      private System.Windows.Forms.TextBox PUER_Nombre;
      private System.Windows.Forms.Label label6;
      private Controls.Tipos.ComboBoxTipos TIPO_CodPais;
      private System.Windows.Forms.TextBox PUER_CodEstandar;
      private System.Windows.Forms.CheckBox PUER_Activo;
      private System.Windows.Forms.CheckBox PUER_Favorito;
      private System.Windows.Forms.Label label3;
      private System.Windows.Forms.Label lblPUER_CodAduana;
      private System.Windows.Forms.TextBox txtPUER_CodAduana;
   }
}