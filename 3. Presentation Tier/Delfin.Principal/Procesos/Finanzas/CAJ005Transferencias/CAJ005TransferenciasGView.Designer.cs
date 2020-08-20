namespace Delfin.Principal
{
   partial class CAJ005TransferenciasGView
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
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbTIPO_CodMND = new Delfin.Controls.Tipos.ComboBoxTipos();
            this.label1 = new System.Windows.Forms.Label();
            this.txtGBAN_Codigo = new System.Windows.Forms.TextBox();
            this.lblTRAN_Codigo = new System.Windows.Forms.Label();
            this.lblGBAN_MontoDebe = new System.Windows.Forms.Label();
            this.txnGBAN_MontoDebe = new Infrastructure.WinForms.Controls.TextBoxNumerico();
            this.lblGBAN_MontoHaber = new System.Windows.Forms.Label();
            this.txnGBAN_MontoHaber = new Infrastructure.WinForms.Controls.TextBoxNumerico();
            this.txnGBAN_TipoCambio = new Infrastructure.WinForms.Controls.TextBoxNumerico();
            this.panelCaption3 = new Infrastructure.WinForms.Controls.PanelCaption();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnSalir = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.tableLayoutPanel3.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
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
            this.tableLayoutPanel3.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.cmbTIPO_CodMND, 1, 1);
            this.tableLayoutPanel3.Controls.Add(this.label1, 3, 1);
            this.tableLayoutPanel3.Controls.Add(this.txtGBAN_Codigo, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.lblTRAN_Codigo, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.lblGBAN_MontoDebe, 0, 2);
            this.tableLayoutPanel3.Controls.Add(this.txnGBAN_MontoDebe, 1, 2);
            this.tableLayoutPanel3.Controls.Add(this.lblGBAN_MontoHaber, 3, 2);
            this.tableLayoutPanel3.Controls.Add(this.txnGBAN_MontoHaber, 4, 2);
            this.tableLayoutPanel3.Controls.Add(this.txnGBAN_TipoCambio, 4, 1);
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
            this.tableLayoutPanel3.Size = new System.Drawing.Size(749, 108);
            this.tableLayoutPanel3.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(10, 34);
            this.label2.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Moneda :";
            // 
            // cmbTIPO_CodMND
            // 
            this.cmbTIPO_CodMND.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTIPO_CodMND.FormattingEnabled = true;
            this.cmbTIPO_CodMND.Location = new System.Drawing.Point(153, 30);
            this.cmbTIPO_CodMND.Name = "cmbTIPO_CodMND";
            this.cmbTIPO_CodMND.Size = new System.Drawing.Size(194, 21);
            this.cmbTIPO_CodMND.TabIndex = 3;
            this.cmbTIPO_CodMND.TiposSelectedItem = null;
            this.cmbTIPO_CodMND.TiposSelectedValue = null;
            this.cmbTIPO_CodMND.TiposTitulo = null;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(375, 34);
            this.label1.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Tipo de Cambio :";
            // 
            // txtGBAN_Codigo
            // 
            this.txtGBAN_Codigo.Location = new System.Drawing.Point(153, 3);
            this.txtGBAN_Codigo.Name = "txtGBAN_Codigo";
            this.txtGBAN_Codigo.Size = new System.Drawing.Size(194, 20);
            this.txtGBAN_Codigo.TabIndex = 1;
            // 
            // lblTRAN_Codigo
            // 
            this.lblTRAN_Codigo.AutoSize = true;
            this.lblTRAN_Codigo.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTRAN_Codigo.Location = new System.Drawing.Point(10, 7);
            this.lblTRAN_Codigo.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
            this.lblTRAN_Codigo.Name = "lblTRAN_Codigo";
            this.lblTRAN_Codigo.Size = new System.Drawing.Size(56, 13);
            this.lblTRAN_Codigo.TabIndex = 0;
            this.lblTRAN_Codigo.Text = "Código :";
            // 
            // lblGBAN_MontoDebe
            // 
            this.lblGBAN_MontoDebe.AutoSize = true;
            this.lblGBAN_MontoDebe.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGBAN_MontoDebe.Location = new System.Drawing.Point(10, 61);
            this.lblGBAN_MontoDebe.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
            this.lblGBAN_MontoDebe.Name = "lblGBAN_MontoDebe";
            this.lblGBAN_MontoDebe.Size = new System.Drawing.Size(84, 13);
            this.lblGBAN_MontoDebe.TabIndex = 6;
            this.lblGBAN_MontoDebe.Text = "Monto Debe :";
            // 
            // txnGBAN_MontoDebe
            // 
            this.txnGBAN_MontoDebe.BaseTipo = Infrastructure.WinForms.Controls.EstandaresFormato.Decimal;
            this.txnGBAN_MontoDebe.Decimales = 2;
            this.txnGBAN_MontoDebe.Enteros = 9;
            this.txnGBAN_MontoDebe.Formato = "###,###,##0.00";
            this.txnGBAN_MontoDebe.Location = new System.Drawing.Point(153, 57);
            this.txnGBAN_MontoDebe.MaxLength = 13;
            this.txnGBAN_MontoDebe.Name = "txnGBAN_MontoDebe";
            this.txnGBAN_MontoDebe.Negativo = true;
            this.txnGBAN_MontoDebe.SinFormato = false;
            this.txnGBAN_MontoDebe.Size = new System.Drawing.Size(194, 20);
            this.txnGBAN_MontoDebe.TabIndex = 7;
            this.txnGBAN_MontoDebe.Text = "0.00";
            this.txnGBAN_MontoDebe.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txnGBAN_MontoDebe.Value = new decimal(new int[] {
            0,
            0,
            0,
            131072});
            // 
            // lblGBAN_MontoHaber
            // 
            this.lblGBAN_MontoHaber.AutoSize = true;
            this.lblGBAN_MontoHaber.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGBAN_MontoHaber.Location = new System.Drawing.Point(375, 61);
            this.lblGBAN_MontoHaber.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
            this.lblGBAN_MontoHaber.Name = "lblGBAN_MontoHaber";
            this.lblGBAN_MontoHaber.Size = new System.Drawing.Size(88, 13);
            this.lblGBAN_MontoHaber.TabIndex = 8;
            this.lblGBAN_MontoHaber.Text = "Monto Haber :";
            // 
            // txnGBAN_MontoHaber
            // 
            this.txnGBAN_MontoHaber.BaseTipo = Infrastructure.WinForms.Controls.EstandaresFormato.Decimal;
            this.txnGBAN_MontoHaber.Decimales = 2;
            this.txnGBAN_MontoHaber.Enteros = 9;
            this.txnGBAN_MontoHaber.Formato = "###,###,##0.00";
            this.txnGBAN_MontoHaber.Location = new System.Drawing.Point(518, 57);
            this.txnGBAN_MontoHaber.MaxLength = 13;
            this.txnGBAN_MontoHaber.Name = "txnGBAN_MontoHaber";
            this.txnGBAN_MontoHaber.Negativo = true;
            this.txnGBAN_MontoHaber.SinFormato = false;
            this.txnGBAN_MontoHaber.Size = new System.Drawing.Size(194, 20);
            this.txnGBAN_MontoHaber.TabIndex = 9;
            this.txnGBAN_MontoHaber.Text = "0.00";
            this.txnGBAN_MontoHaber.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txnGBAN_MontoHaber.Value = new decimal(new int[] {
            0,
            0,
            0,
            131072});
            // 
            // txnGBAN_TipoCambio
            // 
            this.txnGBAN_TipoCambio.BaseTipo = Infrastructure.WinForms.Controls.EstandaresFormato.Decimal;
            this.txnGBAN_TipoCambio.Decimales = 4;
            this.txnGBAN_TipoCambio.Enteros = 9;
            this.txnGBAN_TipoCambio.Formato = "###,###,##0.0000";
            this.txnGBAN_TipoCambio.Location = new System.Drawing.Point(518, 30);
            this.txnGBAN_TipoCambio.MaxLength = 6;
            this.txnGBAN_TipoCambio.Name = "txnGBAN_TipoCambio";
            this.txnGBAN_TipoCambio.Negativo = true;
            this.txnGBAN_TipoCambio.SinFormato = false;
            this.txnGBAN_TipoCambio.Size = new System.Drawing.Size(194, 20);
            this.txnGBAN_TipoCambio.TabIndex = 5;
            this.txnGBAN_TipoCambio.Text = "0.0000";
            this.txnGBAN_TipoCambio.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txnGBAN_TipoCambio.Value = new decimal(new int[] {
            0,
            0,
            0,
            262144});
            // 
            // panelCaption3
            // 
            this.panelCaption3.AllowActive = false;
            this.panelCaption3.AntiAlias = false;
            this.panelCaption3.Caption = "Datos del Detalle";
            this.panelCaption3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelCaption3.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
            this.panelCaption3.InactiveGradientHighColor = System.Drawing.Color.SteelBlue;
            this.panelCaption3.InactiveGradientLowColor = System.Drawing.Color.MidnightBlue;
            this.panelCaption3.Location = new System.Drawing.Point(0, 50);
            this.panelCaption3.Name = "panelCaption3";
            this.panelCaption3.Size = new System.Drawing.Size(749, 26);
            this.panelCaption3.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.LightSteelBlue;
            this.panel3.Controls.Add(this.btnSalir);
            this.panel3.Controls.Add(this.btnGuardar);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(749, 50);
            this.panel3.TabIndex = 0;
            // 
            // btnSalir
            // 
            this.btnSalir.AutoSize = true;
            this.btnSalir.DialogResult = System.Windows.Forms.DialogResult.Cancel;
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
            this.btnSalir.Text = "Salir";
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
            this.btnGuardar.Image = global::Delfin.Principal.Properties.Resources.check;
            this.btnGuardar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnGuardar.Location = new System.Drawing.Point(0, 0);
            this.btnGuardar.Margin = new System.Windows.Forms.Padding(0);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(57, 50);
            this.btnGuardar.TabIndex = 0;
            this.btnGuardar.Text = "&Aceptar";
            this.btnGuardar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnGuardar.UseVisualStyleBackColor = true;
            // 
            // CAJ005TransferenciasGView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(749, 167);
            this.Controls.Add(this.tableLayoutPanel3);
            this.Controls.Add(this.panelCaption3);
            this.Controls.Add(this.panel3);
            this.Name = "CAJ005TransferenciasGView";
            this.Text = "Gastos Bancarios";
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
      private Infrastructure.WinForms.Controls.PanelCaption panelCaption3;
      private System.Windows.Forms.Panel panel3;
      private System.Windows.Forms.Button btnSalir;
      private System.Windows.Forms.Button btnGuardar;
      private System.Windows.Forms.TextBox txtGBAN_Codigo;
      private Infrastructure.WinForms.Controls.TextBoxNumerico txnGBAN_MontoHaber;
      private System.Windows.Forms.Label lblGBAN_MontoHaber;
      private System.Windows.Forms.Label lblGBAN_MontoDebe;
      private System.Windows.Forms.Label lblTRAN_Codigo;
      private Infrastructure.WinForms.Controls.TextBoxNumerico txnGBAN_MontoDebe;
      private Controls.Tipos.ComboBoxTipos cmbTIPO_CodMND;
      private System.Windows.Forms.Label label1;
      private Infrastructure.WinForms.Controls.TextBoxNumerico txnGBAN_TipoCambio;
      private System.Windows.Forms.Label label2;
   }
}