namespace Delfin.Principal
{
   partial class MAN009DViewCtasBancarias
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
         this.panel3 = new System.Windows.Forms.Panel();
         this.btnSalir = new System.Windows.Forms.Button();
         this.btnGuardar = new System.Windows.Forms.Button();
         this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
         this.cmbTIPE_CodPadre = new System.Windows.Forms.ComboBox();
         this.lblTIPE_CodPadre = new System.Windows.Forms.Label();
         this.lblENTC_CodPadre = new System.Windows.Forms.Label();
         this.txaENTC_CodPadre = new Delfin.Controls.EntidadDocIden();
         this.panelCaption1 = new Infrastructure.WinForms.Controls.PanelCaption();
         this.panelCaption3 = new Infrastructure.WinForms.Controls.PanelCaption();
         this.tlpDetalle = new System.Windows.Forms.TableLayoutPanel();
         this.txtENCB_NroCuentaDol = new System.Windows.Forms.TextBox();
         this.label2 = new System.Windows.Forms.Label();
         this.cmbENCB_TipoCuenta = new Delfin.Controls.Tipos.ComboBoxConstantes();
         this.label8 = new System.Windows.Forms.Label();
         this.lblENLI_Tipos = new System.Windows.Forms.Label();
         this.cmbTIPO_CodBCO = new Delfin.Controls.Tipos.ComboBoxTipos();
         this.label1 = new System.Windows.Forms.Label();
         this.txtENCB_NroCuentaSol = new System.Windows.Forms.TextBox();
         this.panel3.SuspendLayout();
         this.tableLayoutPanel3.SuspendLayout();
         this.tlpDetalle.SuspendLayout();
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
         this.panel3.Size = new System.Drawing.Size(1167, 50);
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
         this.btnGuardar.Image = global::Delfin.Principal.Properties.Resources.save;
         this.btnGuardar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
         this.btnGuardar.Location = new System.Drawing.Point(0, 0);
         this.btnGuardar.Margin = new System.Windows.Forms.Padding(0);
         this.btnGuardar.Name = "btnGuardar";
         this.btnGuardar.Size = new System.Drawing.Size(57, 50);
         this.btnGuardar.TabIndex = 0;
         this.btnGuardar.Text = "Guardar";
         this.btnGuardar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
         this.btnGuardar.UseVisualStyleBackColor = true;
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
         this.tableLayoutPanel3.Controls.Add(this.cmbTIPE_CodPadre, 1, 0);
         this.tableLayoutPanel3.Controls.Add(this.lblTIPE_CodPadre, 0, 0);
         this.tableLayoutPanel3.Controls.Add(this.lblENTC_CodPadre, 3, 0);
         this.tableLayoutPanel3.Controls.Add(this.txaENTC_CodPadre, 4, 0);
         this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Top;
         this.tableLayoutPanel3.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
         this.tableLayoutPanel3.Location = new System.Drawing.Point(0, 76);
         this.tableLayoutPanel3.Name = "tableLayoutPanel3";
         this.tableLayoutPanel3.RowCount = 1;
         this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
         this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
         this.tableLayoutPanel3.Size = new System.Drawing.Size(1167, 27);
         this.tableLayoutPanel3.TabIndex = 2;
         // 
         // cmbTIPE_CodPadre
         // 
         this.cmbTIPE_CodPadre.FormattingEnabled = true;
         this.cmbTIPE_CodPadre.Location = new System.Drawing.Point(153, 3);
         this.cmbTIPE_CodPadre.Name = "cmbTIPE_CodPadre";
         this.cmbTIPE_CodPadre.Size = new System.Drawing.Size(194, 21);
         this.cmbTIPE_CodPadre.TabIndex = 1;
         // 
         // lblTIPE_CodPadre
         // 
         this.lblTIPE_CodPadre.AutoSize = true;
         this.lblTIPE_CodPadre.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
         this.lblTIPE_CodPadre.Location = new System.Drawing.Point(10, 7);
         this.lblTIPE_CodPadre.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
         this.lblTIPE_CodPadre.Name = "lblTIPE_CodPadre";
         this.lblTIPE_CodPadre.Size = new System.Drawing.Size(88, 13);
         this.lblTIPE_CodPadre.TabIndex = 0;
         this.lblTIPE_CodPadre.Text = "Tipo de Entidad :";
         // 
         // lblENTC_CodPadre
         // 
         this.lblENTC_CodPadre.AutoSize = true;
         this.lblENTC_CodPadre.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
         this.lblENTC_CodPadre.Location = new System.Drawing.Point(375, 7);
         this.lblENTC_CodPadre.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
         this.lblENTC_CodPadre.Name = "lblENTC_CodPadre";
         this.lblENTC_CodPadre.Size = new System.Drawing.Size(85, 13);
         this.lblENTC_CodPadre.TabIndex = 2;
         this.lblENTC_CodPadre.Text = "Código Entidad :";
         // 
         // txaENTC_CodPadre
         // 
         this.txaENTC_CodPadre.BackColor = System.Drawing.Color.LightSteelBlue;
         this.txaENTC_CodPadre.CrearNuevaEntidad = false;
         this.txaENTC_CodPadre.Location = new System.Drawing.Point(515, 0);
         this.txaENTC_CodPadre.Margin = new System.Windows.Forms.Padding(0);
         this.txaENTC_CodPadre.MinimumSize = new System.Drawing.Size(565, 27);
         this.txaENTC_CodPadre.Name = "txaENTC_CodPadre";
         this.txaENTC_CodPadre.Size = new System.Drawing.Size(565, 27);
         this.txaENTC_CodPadre.TabIndex = 3;
         this.txaENTC_CodPadre.TagEntidad = null;
         this.txaENTC_CodPadre.TiposEntidad = Delfin.Controls.TiposEntidad.TIPE_AgenciaAduanera;
         // 
         // panelCaption1
         // 
         this.panelCaption1.AllowActive = false;
         this.panelCaption1.AntiAlias = false;
         this.panelCaption1.Caption = "Datos de la Entidad";
         this.panelCaption1.Dock = System.Windows.Forms.DockStyle.Top;
         this.panelCaption1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
         this.panelCaption1.InactiveGradientHighColor = System.Drawing.Color.SteelBlue;
         this.panelCaption1.InactiveGradientLowColor = System.Drawing.Color.MidnightBlue;
         this.panelCaption1.Location = new System.Drawing.Point(0, 50);
         this.panelCaption1.Name = "panelCaption1";
         this.panelCaption1.Size = new System.Drawing.Size(1167, 26);
         this.panelCaption1.TabIndex = 1;
         // 
         // panelCaption3
         // 
         this.panelCaption3.AllowActive = false;
         this.panelCaption3.AntiAlias = false;
         this.panelCaption3.Caption = "Detalle";
         this.panelCaption3.Dock = System.Windows.Forms.DockStyle.Top;
         this.panelCaption3.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
         this.panelCaption3.InactiveGradientHighColor = System.Drawing.Color.SteelBlue;
         this.panelCaption3.InactiveGradientLowColor = System.Drawing.Color.MidnightBlue;
         this.panelCaption3.Location = new System.Drawing.Point(0, 103);
         this.panelCaption3.Name = "panelCaption3";
         this.panelCaption3.Size = new System.Drawing.Size(1167, 26);
         this.panelCaption3.TabIndex = 3;
         // 
         // tlpDetalle
         // 
         this.tlpDetalle.AutoSize = true;
         this.tlpDetalle.ColumnCount = 10;
         this.tlpDetalle.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
         this.tlpDetalle.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
         this.tlpDetalle.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15F));
         this.tlpDetalle.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
         this.tlpDetalle.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
         this.tlpDetalle.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15F));
         this.tlpDetalle.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
         this.tlpDetalle.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
         this.tlpDetalle.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15F));
         this.tlpDetalle.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
         this.tlpDetalle.Controls.Add(this.txtENCB_NroCuentaDol, 7, 1);
         this.tlpDetalle.Controls.Add(this.label2, 0, 1);
         this.tlpDetalle.Controls.Add(this.cmbENCB_TipoCuenta, 1, 1);
         this.tlpDetalle.Controls.Add(this.label8, 6, 1);
         this.tlpDetalle.Controls.Add(this.lblENLI_Tipos, 0, 0);
         this.tlpDetalle.Controls.Add(this.cmbTIPO_CodBCO, 1, 0);
         this.tlpDetalle.Controls.Add(this.label1, 3, 1);
         this.tlpDetalle.Controls.Add(this.txtENCB_NroCuentaSol, 4, 1);
         this.tlpDetalle.Dock = System.Windows.Forms.DockStyle.Top;
         this.tlpDetalle.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
         this.tlpDetalle.Location = new System.Drawing.Point(0, 129);
         this.tlpDetalle.Name = "tlpDetalle";
         this.tlpDetalle.RowCount = 2;
         this.tlpDetalle.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
         this.tlpDetalle.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
         this.tlpDetalle.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
         this.tlpDetalle.Size = new System.Drawing.Size(1167, 54);
         this.tlpDetalle.TabIndex = 4;
         // 
         // txtENCB_NroCuentaDol
         // 
         this.txtENCB_NroCuentaDol.Location = new System.Drawing.Point(883, 30);
         this.txtENCB_NroCuentaDol.Name = "txtENCB_NroCuentaDol";
         this.txtENCB_NroCuentaDol.Size = new System.Drawing.Size(194, 20);
         this.txtENCB_NroCuentaDol.TabIndex = 7;
         // 
         // label2
         // 
         this.label2.AutoSize = true;
         this.label2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
         this.label2.Location = new System.Drawing.Point(10, 34);
         this.label2.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
         this.label2.Name = "label2";
         this.label2.Size = new System.Drawing.Size(86, 13);
         this.label2.TabIndex = 2;
         this.label2.Text = "Tipo de Cuenta :";
         // 
         // cmbENCB_TipoCuenta
         // 
         this.cmbENCB_TipoCuenta.ConstantesSelectedItem = null;
         this.cmbENCB_TipoCuenta.ConstantesSelectedValue = null;
         this.cmbENCB_TipoCuenta.ConstantesTitulo = null;
         this.cmbENCB_TipoCuenta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this.cmbENCB_TipoCuenta.FormattingEnabled = true;
         this.cmbENCB_TipoCuenta.Location = new System.Drawing.Point(153, 30);
         this.cmbENCB_TipoCuenta.Name = "cmbENCB_TipoCuenta";
         this.cmbENCB_TipoCuenta.Size = new System.Drawing.Size(194, 21);
         this.cmbENCB_TipoCuenta.TabIndex = 3;
         // 
         // label8
         // 
         this.label8.AutoSize = true;
         this.label8.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
         this.label8.Location = new System.Drawing.Point(740, 34);
         this.label8.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
         this.label8.Name = "label8";
         this.label8.Size = new System.Drawing.Size(94, 13);
         this.label8.TabIndex = 6;
         this.label8.Text = "Nro. Cuenta US$ :";
         // 
         // lblENLI_Tipos
         // 
         this.lblENLI_Tipos.AutoSize = true;
         this.lblENLI_Tipos.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
         this.lblENLI_Tipos.Location = new System.Drawing.Point(10, 7);
         this.lblENLI_Tipos.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
         this.lblENLI_Tipos.Name = "lblENLI_Tipos";
         this.lblENLI_Tipos.Size = new System.Drawing.Size(44, 13);
         this.lblENLI_Tipos.TabIndex = 0;
         this.lblENLI_Tipos.Text = "Banco :";
         // 
         // cmbTIPO_CodBCO
         // 
         this.cmbTIPO_CodBCO.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this.cmbTIPO_CodBCO.FormattingEnabled = true;
         this.cmbTIPO_CodBCO.Location = new System.Drawing.Point(153, 3);
         this.cmbTIPO_CodBCO.Name = "cmbTIPO_CodBCO";
         this.cmbTIPO_CodBCO.Size = new System.Drawing.Size(194, 21);
         this.cmbTIPO_CodBCO.TabIndex = 1;
         this.cmbTIPO_CodBCO.TiposSelectedItem = null;
         this.cmbTIPO_CodBCO.TiposSelectedValue = null;
         this.cmbTIPO_CodBCO.TiposTitulo = null;
         // 
         // label1
         // 
         this.label1.AutoSize = true;
         this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
         this.label1.Location = new System.Drawing.Point(375, 34);
         this.label1.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
         this.label1.Name = "label1";
         this.label1.Size = new System.Drawing.Size(88, 13);
         this.label1.TabIndex = 4;
         this.label1.Text = "Nro. Cuenta S/. :";
         // 
         // txtENCB_NroCuentaSol
         // 
         this.txtENCB_NroCuentaSol.Location = new System.Drawing.Point(518, 30);
         this.txtENCB_NroCuentaSol.Name = "txtENCB_NroCuentaSol";
         this.txtENCB_NroCuentaSol.Size = new System.Drawing.Size(194, 20);
         this.txtENCB_NroCuentaSol.TabIndex = 5;
         // 
         // MAN009DViewCtasBancarias
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.BackColor = System.Drawing.Color.LightSteelBlue;
         this.ClientSize = new System.Drawing.Size(1167, 195);
         this.Controls.Add(this.tlpDetalle);
         this.Controls.Add(this.panelCaption3);
         this.Controls.Add(this.tableLayoutPanel3);
         this.Controls.Add(this.panelCaption1);
         this.Controls.Add(this.panel3);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
         this.Name = "MAN009DViewCtasBancarias";
         this.Text = "Cuentas Bancarias";
         this.panel3.ResumeLayout(false);
         this.panel3.PerformLayout();
         this.tableLayoutPanel3.ResumeLayout(false);
         this.tableLayoutPanel3.PerformLayout();
         this.tlpDetalle.ResumeLayout(false);
         this.tlpDetalle.PerformLayout();
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.Panel panel3;
      private System.Windows.Forms.Button btnSalir;
      private System.Windows.Forms.Button btnGuardar;
      private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
      private System.Windows.Forms.ComboBox cmbTIPE_CodPadre;
      private System.Windows.Forms.Label lblTIPE_CodPadre;
      private System.Windows.Forms.Label lblENTC_CodPadre;
      private Controls.EntidadDocIden txaENTC_CodPadre;
      private Infrastructure.WinForms.Controls.PanelCaption panelCaption1;
      private Infrastructure.WinForms.Controls.PanelCaption panelCaption3;
      private System.Windows.Forms.TableLayoutPanel tlpDetalle;
      private System.Windows.Forms.Label label2;
      private System.Windows.Forms.Label label8;
      private System.Windows.Forms.Label lblENLI_Tipos;
      private System.Windows.Forms.TextBox txtENCB_NroCuentaSol;
      private System.Windows.Forms.Label label1;
      private Controls.Tipos.ComboBoxTipos cmbTIPO_CodBCO;
      private Controls.Tipos.ComboBoxConstantes cmbENCB_TipoCuenta;
      private System.Windows.Forms.TextBox txtENCB_NroCuentaDol;
   }
}