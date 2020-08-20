namespace Delfin.Principal
{
   partial class CAJ001CuentasBancariasCView
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
         this.btnSalir = new System.Windows.Forms.Button();
         this.btnGuardar = new System.Windows.Forms.Button();
         this.panelCaption3 = new Infrastructure.WinForms.Controls.PanelCaption();
         this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
         this.txnCHEQ_NroActual = new Infrastructure.WinForms.Controls.TextBoxNumerico();
         this.txnCHEQ_NroFinal = new Infrastructure.WinForms.Controls.TextBoxNumerico();
         this.txnCHEQ_NroInicial = new Infrastructure.WinForms.Controls.TextBoxNumerico();
         this.txtCHEQ_Codigo = new System.Windows.Forms.TextBox();
         this.lblCHEQ_NroActual = new System.Windows.Forms.Label();
         this.lblCHEQ_NroFinal = new System.Windows.Forms.Label();
         this.lblCHEQ_Codigo = new System.Windows.Forms.Label();
         this.lblCHEQ_NroInicial = new System.Windows.Forms.Label();
         this.cmbCHEQ_Estado = new Delfin.Controls.Tipos.ComboBoxConstantes();
         this.lblCHEQ_Estado = new System.Windows.Forms.Label();
         this.lblCHEQ_Diferido = new System.Windows.Forms.Label();
         this.cmbCHEQ_Diferido = new Delfin.Controls.Tipos.ComboBoxConstantes();
         this.errorProviderChequera = new System.Windows.Forms.ErrorProvider(this.components);
         this.panel3.SuspendLayout();
         this.tableLayoutPanel3.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.errorProviderChequera)).BeginInit();
         this.SuspendLayout();
         // 
         // panel3
         // 
         this.panel3.BackColor = System.Drawing.Color.LightSteelBlue;
         this.panel3.Controls.Add(this.btnSalir);
         this.panel3.Controls.Add(this.btnGuardar);
         this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
         this.panel3.Location = new System.Drawing.Point(0, 0);
         this.panel3.Name = "panel3";
         this.panel3.Size = new System.Drawing.Size(735, 50);
         this.panel3.TabIndex = 0;
         // 
         // btnSalir
         // 
         this.btnSalir.AutoSize = true;
         this.btnSalir.Dock = System.Windows.Forms.DockStyle.Left;
         this.btnSalir.FlatAppearance.BorderColor = System.Drawing.Color.LightSteelBlue;
         this.btnSalir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
         this.btnSalir.ForeColor = System.Drawing.Color.Black;
         this.btnSalir.Image = global::Delfin.Principal.Properties.Resources.undo;
         this.btnSalir.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
         this.btnSalir.Location = new System.Drawing.Point(57, 0);
         this.btnSalir.Margin = new System.Windows.Forms.Padding(0);
         this.btnSalir.Name = "btnSalir";
         this.btnSalir.Size = new System.Drawing.Size(55, 50);
         this.btnSalir.TabIndex = 1;
         this.btnSalir.Text = "&Salir";
         this.btnSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
         this.btnSalir.UseVisualStyleBackColor = true;
         // 
         // btnGuardar
         // 
         this.btnGuardar.AutoSize = true;
         this.btnGuardar.Dock = System.Windows.Forms.DockStyle.Left;
         this.btnGuardar.FlatAppearance.BorderColor = System.Drawing.Color.LightSteelBlue;
         this.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
         this.btnGuardar.ForeColor = System.Drawing.Color.Black;
         this.btnGuardar.Image = global::Delfin.Principal.Properties.Resources.save;
         this.btnGuardar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
         this.btnGuardar.Location = new System.Drawing.Point(0, 0);
         this.btnGuardar.Margin = new System.Windows.Forms.Padding(0);
         this.btnGuardar.Name = "btnGuardar";
         this.btnGuardar.Size = new System.Drawing.Size(57, 50);
         this.btnGuardar.TabIndex = 0;
         this.btnGuardar.Text = "&Guardar";
         this.btnGuardar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
         this.btnGuardar.UseVisualStyleBackColor = true;
         // 
         // panelCaption3
         // 
         this.panelCaption3.AllowActive = false;
         this.panelCaption3.AntiAlias = false;
         this.panelCaption3.Caption = "Datos del Chequera";
         this.panelCaption3.Dock = System.Windows.Forms.DockStyle.Top;
         this.panelCaption3.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
         this.panelCaption3.InactiveGradientHighColor = System.Drawing.Color.SteelBlue;
         this.panelCaption3.InactiveGradientLowColor = System.Drawing.Color.MidnightBlue;
         this.panelCaption3.Location = new System.Drawing.Point(0, 50);
         this.panelCaption3.Name = "panelCaption3";
         this.panelCaption3.Size = new System.Drawing.Size(735, 26);
         this.panelCaption3.TabIndex = 1;
         // 
         // tableLayoutPanel3
         // 
         this.tableLayoutPanel3.AutoSize = true;
         this.tableLayoutPanel3.ColumnCount = 10;
         this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
         this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
         this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15F));
         this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
         this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
         this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15F));
         this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
         this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
         this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15F));
         this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
         this.tableLayoutPanel3.Controls.Add(this.txnCHEQ_NroActual, 1, 2);
         this.tableLayoutPanel3.Controls.Add(this.txnCHEQ_NroFinal, 4, 1);
         this.tableLayoutPanel3.Controls.Add(this.txnCHEQ_NroInicial, 1, 1);
         this.tableLayoutPanel3.Controls.Add(this.txtCHEQ_Codigo, 1, 0);
         this.tableLayoutPanel3.Controls.Add(this.lblCHEQ_NroActual, 0, 2);
         this.tableLayoutPanel3.Controls.Add(this.lblCHEQ_NroFinal, 3, 1);
         this.tableLayoutPanel3.Controls.Add(this.lblCHEQ_Codigo, 0, 0);
         this.tableLayoutPanel3.Controls.Add(this.lblCHEQ_NroInicial, 0, 1);
         this.tableLayoutPanel3.Controls.Add(this.cmbCHEQ_Estado, 4, 3);
         this.tableLayoutPanel3.Controls.Add(this.lblCHEQ_Estado, 3, 3);
         this.tableLayoutPanel3.Controls.Add(this.lblCHEQ_Diferido, 0, 3);
         this.tableLayoutPanel3.Controls.Add(this.cmbCHEQ_Diferido, 1, 3);
         this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Top;
         this.tableLayoutPanel3.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
         this.tableLayoutPanel3.Location = new System.Drawing.Point(0, 76);
         this.tableLayoutPanel3.Name = "tableLayoutPanel3";
         this.tableLayoutPanel3.RowCount = 4;
         this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
         this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
         this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
         this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
         this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
         this.tableLayoutPanel3.Size = new System.Drawing.Size(735, 108);
         this.tableLayoutPanel3.TabIndex = 2;
         // 
         // txnCHEQ_NroActual
         // 
         this.txnCHEQ_NroActual.BaseTipo = Infrastructure.WinForms.Controls.EstandaresFormato.Decimal;
         this.txnCHEQ_NroActual.Decimales = 0;
         this.txnCHEQ_NroActual.Enteros = 9;
         this.txnCHEQ_NroActual.Formato = "###,###,##0.";
         this.txnCHEQ_NroActual.Location = new System.Drawing.Point(153, 57);
         this.txnCHEQ_NroActual.MaxLength = 11;
         this.txnCHEQ_NroActual.Name = "txnCHEQ_NroActual";
         this.txnCHEQ_NroActual.Negativo = true;
         this.txnCHEQ_NroActual.SinFormato = false;
         this.txnCHEQ_NroActual.Size = new System.Drawing.Size(194, 20);
         this.txnCHEQ_NroActual.TabIndex = 7;
         this.txnCHEQ_NroActual.Text = "0";
         this.txnCHEQ_NroActual.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
         this.txnCHEQ_NroActual.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
         // 
         // txnCHEQ_NroFinal
         // 
         this.txnCHEQ_NroFinal.BaseTipo = Infrastructure.WinForms.Controls.EstandaresFormato.Decimal;
         this.txnCHEQ_NroFinal.Decimales = 0;
         this.txnCHEQ_NroFinal.Enteros = 9;
         this.txnCHEQ_NroFinal.Formato = "###,###,##0.";
         this.txnCHEQ_NroFinal.Location = new System.Drawing.Point(518, 30);
         this.txnCHEQ_NroFinal.MaxLength = 11;
         this.txnCHEQ_NroFinal.Name = "txnCHEQ_NroFinal";
         this.txnCHEQ_NroFinal.Negativo = true;
         this.txnCHEQ_NroFinal.SinFormato = false;
         this.txnCHEQ_NroFinal.Size = new System.Drawing.Size(194, 20);
         this.txnCHEQ_NroFinal.TabIndex = 5;
         this.txnCHEQ_NroFinal.Text = "0";
         this.txnCHEQ_NroFinal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
         this.txnCHEQ_NroFinal.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
         // 
         // txnCHEQ_NroInicial
         // 
         this.txnCHEQ_NroInicial.BaseTipo = Infrastructure.WinForms.Controls.EstandaresFormato.Decimal;
         this.txnCHEQ_NroInicial.Decimales = 0;
         this.txnCHEQ_NroInicial.Enteros = 9;
         this.txnCHEQ_NroInicial.Formato = "###,###,##0.";
         this.txnCHEQ_NroInicial.Location = new System.Drawing.Point(153, 30);
         this.txnCHEQ_NroInicial.MaxLength = 11;
         this.txnCHEQ_NroInicial.Name = "txnCHEQ_NroInicial";
         this.txnCHEQ_NroInicial.Negativo = true;
         this.txnCHEQ_NroInicial.SinFormato = false;
         this.txnCHEQ_NroInicial.Size = new System.Drawing.Size(194, 20);
         this.txnCHEQ_NroInicial.TabIndex = 3;
         this.txnCHEQ_NroInicial.Text = "0";
         this.txnCHEQ_NroInicial.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
         this.txnCHEQ_NroInicial.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
         // 
         // txtCHEQ_Codigo
         // 
         this.txtCHEQ_Codigo.Location = new System.Drawing.Point(153, 3);
         this.txtCHEQ_Codigo.Name = "txtCHEQ_Codigo";
         this.txtCHEQ_Codigo.Size = new System.Drawing.Size(194, 20);
         this.txtCHEQ_Codigo.TabIndex = 1;
         // 
         // lblCHEQ_NroActual
         // 
         this.lblCHEQ_NroActual.AutoSize = true;
         this.lblCHEQ_NroActual.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.lblCHEQ_NroActual.Location = new System.Drawing.Point(10, 61);
         this.lblCHEQ_NroActual.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
         this.lblCHEQ_NroActual.Name = "lblCHEQ_NroActual";
         this.lblCHEQ_NroActual.Size = new System.Drawing.Size(100, 13);
         this.lblCHEQ_NroActual.TabIndex = 6;
         this.lblCHEQ_NroActual.Text = "Número Actual :";
         // 
         // lblCHEQ_NroFinal
         // 
         this.lblCHEQ_NroFinal.AutoSize = true;
         this.lblCHEQ_NroFinal.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.lblCHEQ_NroFinal.Location = new System.Drawing.Point(375, 34);
         this.lblCHEQ_NroFinal.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
         this.lblCHEQ_NroFinal.Name = "lblCHEQ_NroFinal";
         this.lblCHEQ_NroFinal.Size = new System.Drawing.Size(91, 13);
         this.lblCHEQ_NroFinal.TabIndex = 4;
         this.lblCHEQ_NroFinal.Text = "Número Final :";
         // 
         // lblCHEQ_Codigo
         // 
         this.lblCHEQ_Codigo.AutoSize = true;
         this.lblCHEQ_Codigo.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.lblCHEQ_Codigo.Location = new System.Drawing.Point(10, 7);
         this.lblCHEQ_Codigo.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
         this.lblCHEQ_Codigo.Name = "lblCHEQ_Codigo";
         this.lblCHEQ_Codigo.Size = new System.Drawing.Size(56, 13);
         this.lblCHEQ_Codigo.TabIndex = 0;
         this.lblCHEQ_Codigo.Text = "Código :";
         // 
         // lblCHEQ_NroInicial
         // 
         this.lblCHEQ_NroInicial.AutoSize = true;
         this.lblCHEQ_NroInicial.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.lblCHEQ_NroInicial.Location = new System.Drawing.Point(10, 34);
         this.lblCHEQ_NroInicial.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
         this.lblCHEQ_NroInicial.Name = "lblCHEQ_NroInicial";
         this.lblCHEQ_NroInicial.Size = new System.Drawing.Size(99, 13);
         this.lblCHEQ_NroInicial.TabIndex = 2;
         this.lblCHEQ_NroInicial.Text = "Número Inicial :";
         // 
         // cmbCHEQ_Estado
         // 
         this.cmbCHEQ_Estado.ConstantesSelectedItem = null;
         this.cmbCHEQ_Estado.ConstantesSelectedValue = null;
         this.cmbCHEQ_Estado.ConstantesTitulo = null;
         this.cmbCHEQ_Estado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this.cmbCHEQ_Estado.FormattingEnabled = true;
         this.cmbCHEQ_Estado.Location = new System.Drawing.Point(518, 84);
         this.cmbCHEQ_Estado.Name = "cmbCHEQ_Estado";
         this.cmbCHEQ_Estado.Session = null;
         this.cmbCHEQ_Estado.Size = new System.Drawing.Size(194, 21);
         this.cmbCHEQ_Estado.TabIndex = 11;
         // 
         // lblCHEQ_Estado
         // 
         this.lblCHEQ_Estado.AutoSize = true;
         this.lblCHEQ_Estado.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.lblCHEQ_Estado.Location = new System.Drawing.Point(375, 88);
         this.lblCHEQ_Estado.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
         this.lblCHEQ_Estado.Name = "lblCHEQ_Estado";
         this.lblCHEQ_Estado.Size = new System.Drawing.Size(54, 13);
         this.lblCHEQ_Estado.TabIndex = 10;
         this.lblCHEQ_Estado.Text = "Estado :";
         // 
         // lblCHEQ_Diferido
         // 
         this.lblCHEQ_Diferido.AutoSize = true;
         this.lblCHEQ_Diferido.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.lblCHEQ_Diferido.Location = new System.Drawing.Point(10, 88);
         this.lblCHEQ_Diferido.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
         this.lblCHEQ_Diferido.Name = "lblCHEQ_Diferido";
         this.lblCHEQ_Diferido.Size = new System.Drawing.Size(61, 13);
         this.lblCHEQ_Diferido.TabIndex = 8;
         this.lblCHEQ_Diferido.Text = "Diferido :";
         // 
         // cmbCHEQ_Diferido
         // 
         this.cmbCHEQ_Diferido.ConstantesSelectedItem = null;
         this.cmbCHEQ_Diferido.ConstantesSelectedValue = null;
         this.cmbCHEQ_Diferido.ConstantesTitulo = null;
         this.cmbCHEQ_Diferido.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this.cmbCHEQ_Diferido.FormattingEnabled = true;
         this.cmbCHEQ_Diferido.Location = new System.Drawing.Point(153, 84);
         this.cmbCHEQ_Diferido.Name = "cmbCHEQ_Diferido";
         this.cmbCHEQ_Diferido.Session = null;
         this.cmbCHEQ_Diferido.Size = new System.Drawing.Size(194, 21);
         this.cmbCHEQ_Diferido.TabIndex = 9;
         // 
         // errorProviderChequera
         // 
         this.errorProviderChequera.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
         this.errorProviderChequera.ContainerControl = this;
         // 
         // CAJ001CuentasBancariasCView
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.BackColor = System.Drawing.Color.LightSteelBlue;
         this.ClientSize = new System.Drawing.Size(735, 188);
         this.Controls.Add(this.tableLayoutPanel3);
         this.Controls.Add(this.panelCaption3);
         this.Controls.Add(this.panel3);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
         this.Name = "CAJ001CuentasBancariasCView";
         this.Text = "Chequera";
         this.panel3.ResumeLayout(false);
         this.panel3.PerformLayout();
         this.tableLayoutPanel3.ResumeLayout(false);
         this.tableLayoutPanel3.PerformLayout();
         ((System.ComponentModel.ISupportInitialize)(this.errorProviderChequera)).EndInit();
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.Panel panel3;
      private System.Windows.Forms.Button btnSalir;
      private System.Windows.Forms.Button btnGuardar;
      private Infrastructure.WinForms.Controls.PanelCaption panelCaption3;
      private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
      private System.Windows.Forms.Label lblCHEQ_NroFinal;
      private System.Windows.Forms.Label lblCHEQ_Codigo;
      private System.Windows.Forms.Label lblCHEQ_NroInicial;
      private Infrastructure.WinForms.Controls.TextBoxNumerico txnCHEQ_NroActual;
      private Infrastructure.WinForms.Controls.TextBoxNumerico txnCHEQ_NroFinal;
      private Infrastructure.WinForms.Controls.TextBoxNumerico txnCHEQ_NroInicial;
      private System.Windows.Forms.TextBox txtCHEQ_Codigo;
      private System.Windows.Forms.Label lblCHEQ_Estado;
      private System.Windows.Forms.Label lblCHEQ_Diferido;
      private System.Windows.Forms.Label lblCHEQ_NroActual;
      private Controls.Tipos.ComboBoxConstantes cmbCHEQ_Estado;
      private System.Windows.Forms.ErrorProvider errorProviderChequera;
      private Controls.Tipos.ComboBoxConstantes cmbCHEQ_Diferido;
   }
}