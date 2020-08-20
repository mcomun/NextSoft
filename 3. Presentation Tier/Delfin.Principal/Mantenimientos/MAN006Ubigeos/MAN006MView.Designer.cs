namespace Delfin.Principal
{
   partial class MAN006MView
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
         this.label1 = new System.Windows.Forms.Label();
         this.txtUBIG_Codigo = new System.Windows.Forms.TextBox();
         this.label5 = new System.Windows.Forms.Label();
         this.txtUBIG_desc = new System.Windows.Forms.TextBox();
         this.label2 = new System.Windows.Forms.Label();
         this.txtUBIG_DescC = new System.Windows.Forms.TextBox();
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
         this.panelCaption1.Caption = "Datos de Ubigeos";
         this.panelCaption1.Dock = System.Windows.Forms.DockStyle.Top;
         this.panelCaption1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
         this.panelCaption1.InactiveGradientHighColor = System.Drawing.Color.SteelBlue;
         this.panelCaption1.InactiveGradientLowColor = System.Drawing.Color.MidnightBlue;
         this.panelCaption1.Location = new System.Drawing.Point(0, 50);
         this.panelCaption1.Name = "panelCaption1";
         this.panelCaption1.Size = new System.Drawing.Size(735, 26);
         this.panelCaption1.TabIndex = 46;
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
         this.tableLayoutPanel2.Controls.Add(this.label1, 0, 0);
         this.tableLayoutPanel2.Controls.Add(this.txtUBIG_Codigo, 1, 0);
         this.tableLayoutPanel2.Controls.Add(this.label5, 0, 1);
         this.tableLayoutPanel2.Controls.Add(this.txtUBIG_desc, 1, 1);
         this.tableLayoutPanel2.Controls.Add(this.label2, 0, 2);
         this.tableLayoutPanel2.Controls.Add(this.txtUBIG_DescC, 1, 2);
         this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Top;
         this.tableLayoutPanel2.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
         this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 76);
         this.tableLayoutPanel2.Name = "tableLayoutPanel2";
         this.tableLayoutPanel2.RowCount = 3;
         this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
         this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
         this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
         this.tableLayoutPanel2.Size = new System.Drawing.Size(735, 81);
         this.tableLayoutPanel2.TabIndex = 0;
         // 
         // label1
         // 
         this.label1.AutoSize = true;
         this.label1.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.label1.Location = new System.Drawing.Point(10, 7);
         this.label1.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
         this.label1.Name = "label1";
         this.label1.Size = new System.Drawing.Size(95, 13);
         this.label1.TabIndex = 2;
         this.label1.Text = "Código Ubigeo:";
         // 
         // txtUBIG_Codigo
         // 
         this.txtUBIG_Codigo.Location = new System.Drawing.Point(153, 3);
         this.txtUBIG_Codigo.Name = "txtUBIG_Codigo";
         this.txtUBIG_Codigo.Size = new System.Drawing.Size(194, 20);
         this.txtUBIG_Codigo.TabIndex = 0;
         // 
         // label5
         // 
         this.label5.AutoSize = true;
         this.label5.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.label5.Location = new System.Drawing.Point(10, 34);
         this.label5.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
         this.label5.Name = "label5";
         this.label5.Size = new System.Drawing.Size(78, 13);
         this.label5.TabIndex = 2;
         this.label5.Text = "Descripción:";
         // 
         // txtUBIG_desc
         // 
         this.tableLayoutPanel2.SetColumnSpan(this.txtUBIG_desc, 4);
         this.txtUBIG_desc.Location = new System.Drawing.Point(153, 30);
         this.txtUBIG_desc.Name = "txtUBIG_desc";
         this.txtUBIG_desc.Size = new System.Drawing.Size(559, 20);
         this.txtUBIG_desc.TabIndex = 1;
         this.txtUBIG_desc.Tag = "UBIG_DescMSGERROR";
         // 
         // label2
         // 
         this.label2.AutoSize = true;
         this.label2.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.label2.Location = new System.Drawing.Point(10, 61);
         this.label2.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
         this.label2.Name = "label2";
         this.label2.Size = new System.Drawing.Size(114, 13);
         this.label2.TabIndex = 2;
         this.label2.Text = "Descripción Corta:";
         // 
         // txtUBIG_DescC
         // 
         this.tableLayoutPanel2.SetColumnSpan(this.txtUBIG_DescC, 3);
         this.txtUBIG_DescC.Location = new System.Drawing.Point(153, 57);
         this.txtUBIG_DescC.Name = "txtUBIG_DescC";
         this.txtUBIG_DescC.Size = new System.Drawing.Size(359, 20);
         this.txtUBIG_DescC.TabIndex = 1;
         // 
         // MAN006MView
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
         this.Name = "MAN006MView";
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
         this.Text = "Datos de Ubigeos";
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
      private System.Windows.Forms.Label label5;
      private System.Windows.Forms.TextBox txtUBIG_desc;
      private System.Windows.Forms.Label label1;
      private System.Windows.Forms.TextBox txtUBIG_Codigo;
      private System.Windows.Forms.Label label2;
      private System.Windows.Forms.TextBox txtUBIG_DescC;
   }
}