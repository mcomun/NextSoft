namespace Delfin.Principal
{
   partial class MAN001MView
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
         this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
         this.lblSUCR_Direccion = new System.Windows.Forms.Label();
         this.lblSUCR_Desc = new System.Windows.Forms.Label();
         this.txtSUCR_Direccion = new System.Windows.Forms.TextBox();
         this.txtSUCR_Desc = new System.Windows.Forms.TextBox();
         this.txtSUCR_Ruc = new Infrastructure.WinForms.Controls.TextBoxNumerico();
         this.lblSUCR_Ruc = new System.Windows.Forms.Label();
         this.txtSUCR_DescC = new System.Windows.Forms.TextBox();
         this.lblSUCR_DescC = new System.Windows.Forms.Label();
         this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
         this.panel3.SuspendLayout();
         this.tableLayoutPanel2.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
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
         this.panel3.TabIndex = 1;
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
         this.btnMAN_salir.Size = new System.Drawing.Size(60, 50);
         this.btnMAN_salir.TabIndex = 1;
         this.btnMAN_salir.Text = "&Salir";
         this.btnMAN_salir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
         this.btnMAN_salir.UseVisualStyleBackColor = true;
         // 
         // btnMAN_guardar
         // 
         this.btnMAN_guardar.AutoSize = true;
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
         // 
         // panelCaption1
         // 
         this.panelCaption1.AllowActive = false;
         this.panelCaption1.AntiAlias = false;
         this.panelCaption1.Caption = "Datos de la Sucursal";
         this.panelCaption1.Dock = System.Windows.Forms.DockStyle.Top;
         this.panelCaption1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
         this.panelCaption1.InactiveGradientHighColor = System.Drawing.Color.SteelBlue;
         this.panelCaption1.InactiveGradientLowColor = System.Drawing.Color.MidnightBlue;
         this.panelCaption1.Location = new System.Drawing.Point(0, 50);
         this.panelCaption1.Name = "panelCaption1";
         this.panelCaption1.Size = new System.Drawing.Size(735, 26);
         this.panelCaption1.TabIndex = 0;
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
         this.tableLayoutPanel2.Controls.Add(this.lblSUCR_Direccion, 0, 2);
         this.tableLayoutPanel2.Controls.Add(this.lblSUCR_Desc, 0, 1);
         this.tableLayoutPanel2.Controls.Add(this.txtSUCR_Direccion, 1, 2);
         this.tableLayoutPanel2.Controls.Add(this.txtSUCR_Desc, 1, 1);
         this.tableLayoutPanel2.Controls.Add(this.txtSUCR_Ruc, 1, 0);
         this.tableLayoutPanel2.Controls.Add(this.lblSUCR_Ruc, 0, 0);
         this.tableLayoutPanel2.Controls.Add(this.txtSUCR_DescC, 4, 0);
         this.tableLayoutPanel2.Controls.Add(this.lblSUCR_DescC, 3, 0);
         this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Top;
         this.tableLayoutPanel2.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
         this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 76);
         this.tableLayoutPanel2.Name = "tableLayoutPanel2";
         this.tableLayoutPanel2.RowCount = 3;
         this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
         this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
         this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
         this.tableLayoutPanel2.Size = new System.Drawing.Size(735, 81);
         this.tableLayoutPanel2.TabIndex = 1;
         // 
         // lblSUCR_Direccion
         // 
         this.lblSUCR_Direccion.AutoSize = true;
         this.lblSUCR_Direccion.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.lblSUCR_Direccion.Location = new System.Drawing.Point(10, 61);
         this.lblSUCR_Direccion.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
         this.lblSUCR_Direccion.Name = "lblSUCR_Direccion";
         this.lblSUCR_Direccion.Size = new System.Drawing.Size(65, 13);
         this.lblSUCR_Direccion.TabIndex = 6;
         this.lblSUCR_Direccion.Text = "Dirección:";
         // 
         // lblSUCR_Desc
         // 
         this.lblSUCR_Desc.AutoSize = true;
         this.lblSUCR_Desc.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.lblSUCR_Desc.Location = new System.Drawing.Point(10, 34);
         this.lblSUCR_Desc.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
         this.lblSUCR_Desc.Name = "lblSUCR_Desc";
         this.lblSUCR_Desc.Size = new System.Drawing.Size(78, 13);
         this.lblSUCR_Desc.TabIndex = 7;
         this.lblSUCR_Desc.Text = "Descripción:";
         // 
         // txtSUCR_Direccion
         // 
         this.tableLayoutPanel2.SetColumnSpan(this.txtSUCR_Direccion, 4);
         this.txtSUCR_Direccion.Location = new System.Drawing.Point(153, 57);
         this.txtSUCR_Direccion.Name = "txtSUCR_Direccion";
         this.txtSUCR_Direccion.Size = new System.Drawing.Size(559, 20);
         this.txtSUCR_Direccion.TabIndex = 7;
         this.txtSUCR_Direccion.Tag = "SUCR_DirecMSGERROR";
         // 
         // txtSUCR_Desc
         // 
         this.tableLayoutPanel2.SetColumnSpan(this.txtSUCR_Desc, 4);
         this.txtSUCR_Desc.Location = new System.Drawing.Point(153, 30);
         this.txtSUCR_Desc.Name = "txtSUCR_Desc";
         this.txtSUCR_Desc.Size = new System.Drawing.Size(559, 20);
         this.txtSUCR_Desc.TabIndex = 4;
         this.txtSUCR_Desc.Tag = "SUCR_DescMSGERROR";
         // 
         // txtSUCR_Ruc
         // 
         this.txtSUCR_Ruc.BaseTipo = Infrastructure.WinForms.Controls.EstandaresFormato.General;
         this.txtSUCR_Ruc.Decimales = 0;
         this.txtSUCR_Ruc.Enteros = 11;
         this.txtSUCR_Ruc.Formato = "##,###,###,##0.";
         this.txtSUCR_Ruc.Location = new System.Drawing.Point(153, 3);
         this.txtSUCR_Ruc.MaxLength = 11;
         this.txtSUCR_Ruc.Name = "txtSUCR_Ruc";
         this.txtSUCR_Ruc.Negativo = false;
         this.txtSUCR_Ruc.ReadOnly = true;
         this.txtSUCR_Ruc.SinFormato = true;
         this.txtSUCR_Ruc.Size = new System.Drawing.Size(194, 20);
         this.txtSUCR_Ruc.TabIndex = 3;
         this.txtSUCR_Ruc.Text = "0";
         this.txtSUCR_Ruc.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
         this.txtSUCR_Ruc.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
         // 
         // lblSUCR_Ruc
         // 
         this.lblSUCR_Ruc.AutoSize = true;
         this.lblSUCR_Ruc.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.lblSUCR_Ruc.Location = new System.Drawing.Point(10, 7);
         this.lblSUCR_Ruc.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
         this.lblSUCR_Ruc.Name = "lblSUCR_Ruc";
         this.lblSUCR_Ruc.Size = new System.Drawing.Size(37, 13);
         this.lblSUCR_Ruc.TabIndex = 2;
         this.lblSUCR_Ruc.Text = "RUC:";
         // 
         // txtSUCR_DescC
         // 
         this.txtSUCR_DescC.Location = new System.Drawing.Point(518, 3);
         this.txtSUCR_DescC.Name = "txtSUCR_DescC";
         this.txtSUCR_DescC.Size = new System.Drawing.Size(194, 20);
         this.txtSUCR_DescC.TabIndex = 5;
         this.txtSUCR_DescC.Tag = "SUCR_DescCMSGERROR";
         // 
         // lblSUCR_DescC
         // 
         this.lblSUCR_DescC.AutoSize = true;
         this.lblSUCR_DescC.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.lblSUCR_DescC.Location = new System.Drawing.Point(375, 7);
         this.lblSUCR_DescC.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
         this.lblSUCR_DescC.Name = "lblSUCR_DescC";
         this.lblSUCR_DescC.Size = new System.Drawing.Size(114, 13);
         this.lblSUCR_DescC.TabIndex = 2;
         this.lblSUCR_DescC.Text = "Descripción Corta:";
         // 
         // errorProvider1
         // 
         this.errorProvider1.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
         this.errorProvider1.ContainerControl = this;
         // 
         // MAN001MView
         // 
         this.AcceptButton = this.btnMAN_guardar;
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.BackColor = System.Drawing.Color.LightSteelBlue;
         this.CancelButton = this.btnMAN_salir;
         this.ClientSize = new System.Drawing.Size(735, 160);
         this.Controls.Add(this.tableLayoutPanel2);
         this.Controls.Add(this.panelCaption1);
         this.Controls.Add(this.panel3);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "MAN001MView";
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
         this.Text = "Sucursal";
         this.panel3.ResumeLayout(false);
         this.panel3.PerformLayout();
         this.tableLayoutPanel2.ResumeLayout(false);
         this.tableLayoutPanel2.PerformLayout();
         ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.Panel panel3;
      private System.Windows.Forms.Button btnMAN_salir;
      private System.Windows.Forms.Button btnMAN_guardar;
      private Infrastructure.WinForms.Controls.PanelCaption panelCaption1;
      private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
      private System.Windows.Forms.Label lblSUCR_Ruc;
      private System.Windows.Forms.Label lblSUCR_Direccion;
      private System.Windows.Forms.Label lblSUCR_Desc;
      private System.Windows.Forms.Label lblSUCR_DescC;
      private System.Windows.Forms.TextBox txtSUCR_Direccion;
      private System.Windows.Forms.TextBox txtSUCR_Desc;
      private System.Windows.Forms.TextBox txtSUCR_DescC;
      private System.Windows.Forms.ErrorProvider errorProvider1;
      private Infrastructure.WinForms.Controls.TextBoxNumerico txtSUCR_Ruc;
   }
}