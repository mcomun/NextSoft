namespace Delfin.Principal
{
   partial class MAN013MView
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
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MAN013MView));
         this.panel3 = new System.Windows.Forms.Panel();
         this.btnSalir = new System.Windows.Forms.Button();
         this.btnGuardar = new System.Windows.Forms.Button();
         this.panelCaption1 = new Infrastructure.WinFormsControls.PanelCaption();
         this.tlpDatosTarifas = new System.Windows.Forms.TableLayoutPanel();
         this.txnTIPC_DolEuro = new Infrastructure.WinForms.Controls.TextBoxNumerico();
         this.lblTIPC_DolEuro = new System.Windows.Forms.Label();
         this.lblCONT_Numero = new System.Windows.Forms.Label();
         this.lblCONT_Descrip = new System.Windows.Forms.Label();
         this.lblCONT_FecIni = new System.Windows.Forms.Label();
         this.dtpTIPC_Fecha = new Infrastructure.WinForms.Controls.MaskDateTime();
         this.txtTIPC_Compra = new Infrastructure.WinFormsControls.TextBoxNumerico();
         this.txtTIPC_Venta = new Infrastructure.WinFormsControls.TextBoxNumerico();
         this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
         this.panel3.SuspendLayout();
         this.tlpDatosTarifas.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
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
         this.panel3.Size = new System.Drawing.Size(317, 50);
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
         this.btnSalir.Image = ((System.Drawing.Image)(resources.GetObject("btnSalir.Image")));
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
         this.btnGuardar.Image = ((System.Drawing.Image)(resources.GetObject("btnGuardar.Image")));
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
         // panelCaption1
         // 
         this.panelCaption1.AllowActive = false;
         this.panelCaption1.AntiAlias = false;
         this.panelCaption1.Caption = "Datos del Tipo de Cambio";
         this.panelCaption1.Dock = System.Windows.Forms.DockStyle.Top;
         this.panelCaption1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
         this.panelCaption1.InactiveGradientHighColor = System.Drawing.Color.SteelBlue;
         this.panelCaption1.InactiveGradientLowColor = System.Drawing.Color.MidnightBlue;
         this.panelCaption1.Location = new System.Drawing.Point(0, 50);
         this.panelCaption1.Name = "panelCaption1";
         this.panelCaption1.Size = new System.Drawing.Size(317, 26);
         this.panelCaption1.TabIndex = 1;
         // 
         // tlpDatosTarifas
         // 
         this.tlpDatosTarifas.AutoSize = true;
         this.tlpDatosTarifas.ColumnCount = 4;
         this.tlpDatosTarifas.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
         this.tlpDatosTarifas.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
         this.tlpDatosTarifas.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15F));
         this.tlpDatosTarifas.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
         this.tlpDatosTarifas.Controls.Add(this.txnTIPC_DolEuro, 1, 4);
         this.tlpDatosTarifas.Controls.Add(this.lblTIPC_DolEuro, 0, 4);
         this.tlpDatosTarifas.Controls.Add(this.lblCONT_Numero, 0, 0);
         this.tlpDatosTarifas.Controls.Add(this.lblCONT_Descrip, 0, 1);
         this.tlpDatosTarifas.Controls.Add(this.lblCONT_FecIni, 0, 2);
         this.tlpDatosTarifas.Controls.Add(this.dtpTIPC_Fecha, 1, 0);
         this.tlpDatosTarifas.Controls.Add(this.txtTIPC_Compra, 1, 1);
         this.tlpDatosTarifas.Controls.Add(this.txtTIPC_Venta, 1, 2);
         this.tlpDatosTarifas.Dock = System.Windows.Forms.DockStyle.Top;
         this.tlpDatosTarifas.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
         this.tlpDatosTarifas.Location = new System.Drawing.Point(0, 76);
         this.tlpDatosTarifas.Name = "tlpDatosTarifas";
         this.tlpDatosTarifas.RowCount = 6;
         this.tlpDatosTarifas.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
         this.tlpDatosTarifas.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
         this.tlpDatosTarifas.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
         this.tlpDatosTarifas.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 9F));
         this.tlpDatosTarifas.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
         this.tlpDatosTarifas.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
         this.tlpDatosTarifas.Size = new System.Drawing.Size(317, 144);
         this.tlpDatosTarifas.TabIndex = 2;
         // 
         // txnTIPC_DolEuro
         // 
         this.txnTIPC_DolEuro.BaseTipo = Infrastructure.WinForms.Controls.EstandaresFormato.Ninguno;
         this.txnTIPC_DolEuro.Decimales = 6;
         this.txnTIPC_DolEuro.Enteros = 9;
         this.txnTIPC_DolEuro.Formato = "###,###,##0.000000";
         this.txnTIPC_DolEuro.Location = new System.Drawing.Point(153, 93);
         this.txnTIPC_DolEuro.MaxLength = 10;
         this.txnTIPC_DolEuro.Name = "txnTIPC_DolEuro";
         this.txnTIPC_DolEuro.Negativo = true;
         this.txnTIPC_DolEuro.SinFormato = false;
         this.txnTIPC_DolEuro.Size = new System.Drawing.Size(139, 20);
         this.txnTIPC_DolEuro.TabIndex = 7;
         this.txnTIPC_DolEuro.Text = "0.000000";
         this.txnTIPC_DolEuro.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
         this.txnTIPC_DolEuro.Value = new decimal(new int[] {
            0,
            0,
            0,
            393216});
         // 
         // lblTIPC_DolEuro
         // 
         this.lblTIPC_DolEuro.AutoSize = true;
         this.lblTIPC_DolEuro.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.lblTIPC_DolEuro.Location = new System.Drawing.Point(10, 97);
         this.lblTIPC_DolEuro.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
         this.lblTIPC_DolEuro.Name = "lblTIPC_DolEuro";
         this.lblTIPC_DolEuro.Size = new System.Drawing.Size(133, 13);
         this.lblTIPC_DolEuro.TabIndex = 6;
         this.lblTIPC_DolEuro.Text = "T.C. Dolares a Euros :";
         // 
         // lblCONT_Numero
         // 
         this.lblCONT_Numero.AutoSize = true;
         this.lblCONT_Numero.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.lblCONT_Numero.Location = new System.Drawing.Point(10, 7);
         this.lblCONT_Numero.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
         this.lblCONT_Numero.Name = "lblCONT_Numero";
         this.lblCONT_Numero.Size = new System.Drawing.Size(49, 13);
         this.lblCONT_Numero.TabIndex = 0;
         this.lblCONT_Numero.Text = "Fecha :";
         // 
         // lblCONT_Descrip
         // 
         this.lblCONT_Descrip.AutoSize = true;
         this.lblCONT_Descrip.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.lblCONT_Descrip.Location = new System.Drawing.Point(10, 34);
         this.lblCONT_Descrip.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
         this.lblCONT_Descrip.Name = "lblCONT_Descrip";
         this.lblCONT_Descrip.Size = new System.Drawing.Size(62, 13);
         this.lblCONT_Descrip.TabIndex = 2;
         this.lblCONT_Descrip.Text = "Compra :";
         // 
         // lblCONT_FecIni
         // 
         this.lblCONT_FecIni.AutoSize = true;
         this.lblCONT_FecIni.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.lblCONT_FecIni.Location = new System.Drawing.Point(10, 61);
         this.lblCONT_FecIni.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
         this.lblCONT_FecIni.Name = "lblCONT_FecIni";
         this.lblCONT_FecIni.Size = new System.Drawing.Size(48, 13);
         this.lblCONT_FecIni.TabIndex = 4;
         this.lblCONT_FecIni.Text = "Venta :";
         // 
         // dtpTIPC_Fecha
         // 
         this.dtpTIPC_Fecha.Location = new System.Drawing.Point(153, 3);
         this.dtpTIPC_Fecha.MinimumSize = new System.Drawing.Size(100, 22);
         this.dtpTIPC_Fecha.Name = "dtpTIPC_Fecha";
         this.dtpTIPC_Fecha.NSActiveMouse = false;
         this.dtpTIPC_Fecha.NSActiveMsgFecha = false;
         this.dtpTIPC_Fecha.NSChangeDate = true;
         this.dtpTIPC_Fecha.NSDigitos = 4;
         this.dtpTIPC_Fecha.NSFecha = null;
         this.dtpTIPC_Fecha.NSSetDateNow = false;
         this.dtpTIPC_Fecha.Size = new System.Drawing.Size(101, 22);
         this.dtpTIPC_Fecha.TabIndex = 1;
         this.dtpTIPC_Fecha.Tag = "CTAR_FecIniMSGERROR";
         this.dtpTIPC_Fecha.mdtChangeDate += new System.EventHandler(this.dtpTIPC_Fecha_mdtChangeDate);
         // 
         // txtTIPC_Compra
         // 
         this.txtTIPC_Compra.BaseTipo = Infrastructure.WinFormsControls.EstandaresFormato.Ninguno;
         this.txtTIPC_Compra.Decimales = 4;
         this.txtTIPC_Compra.Enteros = 9;
         this.txtTIPC_Compra.Formato = "###,###,##0.0000";
         this.txtTIPC_Compra.Location = new System.Drawing.Point(153, 30);
         this.txtTIPC_Compra.MaxLength = 9;
         this.txtTIPC_Compra.Name = "txtTIPC_Compra";
         this.txtTIPC_Compra.Negativo = false;
         this.txtTIPC_Compra.SinFormato = false;
         this.txtTIPC_Compra.Size = new System.Drawing.Size(139, 20);
         this.txtTIPC_Compra.TabIndex = 3;
         this.txtTIPC_Compra.Tag = "CTAR_ProfitMSGERROR";
         this.txtTIPC_Compra.Text = "0.0000";
         this.txtTIPC_Compra.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
         this.txtTIPC_Compra.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
         // 
         // txtTIPC_Venta
         // 
         this.txtTIPC_Venta.BaseTipo = Infrastructure.WinFormsControls.EstandaresFormato.Ninguno;
         this.txtTIPC_Venta.Decimales = 4;
         this.txtTIPC_Venta.Enteros = 9;
         this.txtTIPC_Venta.Formato = "###,###,##0.0000";
         this.txtTIPC_Venta.Location = new System.Drawing.Point(153, 57);
         this.txtTIPC_Venta.MaxLength = 9;
         this.txtTIPC_Venta.Name = "txtTIPC_Venta";
         this.txtTIPC_Venta.Negativo = false;
         this.txtTIPC_Venta.SinFormato = false;
         this.txtTIPC_Venta.Size = new System.Drawing.Size(139, 20);
         this.txtTIPC_Venta.TabIndex = 5;
         this.txtTIPC_Venta.Tag = "CTAR_ProfitMSGERROR";
         this.txtTIPC_Venta.Text = "0.0000";
         this.txtTIPC_Venta.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
         this.txtTIPC_Venta.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
         // 
         // errorProvider1
         // 
         this.errorProvider1.ContainerControl = this;
         // 
         // MAN013MView
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(317, 198);
         this.Controls.Add(this.tlpDatosTarifas);
         this.Controls.Add(this.panelCaption1);
         this.Controls.Add(this.panel3);
         this.Name = "MAN013MView";
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
         this.Text = "Tipos de Cambio";
         this.panel3.ResumeLayout(false);
         this.panel3.PerformLayout();
         this.tlpDatosTarifas.ResumeLayout(false);
         this.tlpDatosTarifas.PerformLayout();
         ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.Panel panel3;
      private System.Windows.Forms.Button btnSalir;
      private System.Windows.Forms.Button btnGuardar;
      private Infrastructure.WinFormsControls.PanelCaption panelCaption1;
      private System.Windows.Forms.TableLayoutPanel tlpDatosTarifas;
      private System.Windows.Forms.Label lblCONT_Numero;
      private System.Windows.Forms.Label lblCONT_Descrip;
      private System.Windows.Forms.Label lblCONT_FecIni;
      private Infrastructure.WinForms.Controls.MaskDateTime dtpTIPC_Fecha;
      private Infrastructure.WinFormsControls.TextBoxNumerico txtTIPC_Compra;
      private Infrastructure.WinFormsControls.TextBoxNumerico txtTIPC_Venta;
      private System.Windows.Forms.ErrorProvider errorProvider1;
      private System.Windows.Forms.Label lblTIPC_DolEuro;
      private Infrastructure.WinForms.Controls.TextBoxNumerico txnTIPC_DolEuro;
   }
}