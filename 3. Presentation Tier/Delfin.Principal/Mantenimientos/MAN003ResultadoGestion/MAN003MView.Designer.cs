namespace Delfin.Principal
{
   partial class MAN003MView
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
         this.txtTIPOS_DescC = new System.Windows.Forms.TextBox();
         this.lblTIPOS_DescC = new System.Windows.Forms.Label();
         this.txtTIPOS_Desc = new System.Windows.Forms.TextBox();
         this.lblTIPOS_Desc = new System.Windows.Forms.Label();
         this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
         this.label1 = new System.Windows.Forms.Label();
         this.TipoRESG_Codigo = new Infrastructure.WinForms.Controls.ComboBox.ComboBox(this.components);
         this.lblTIPOS_EstadoGestion = new System.Windows.Forms.Label();
         this.chkRESG_estado = new System.Windows.Forms.CheckBox();
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
         this.panelCaption1.Caption = "Datos de Gestión";
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
         // txtTIPOS_DescC
         // 
         this.tableLayoutPanel2.SetColumnSpan(this.txtTIPOS_DescC, 3);
         this.txtTIPOS_DescC.Location = new System.Drawing.Point(153, 57);
         this.txtTIPOS_DescC.Name = "txtTIPOS_DescC";
         this.txtTIPOS_DescC.Size = new System.Drawing.Size(359, 20);
         this.txtTIPOS_DescC.TabIndex = 7;
         this.txtTIPOS_DescC.Tag = "RESG_DescCMSGERROR";
         // 
         // lblTIPOS_DescC
         // 
         this.lblTIPOS_DescC.AutoSize = true;
         this.lblTIPOS_DescC.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.lblTIPOS_DescC.Location = new System.Drawing.Point(10, 61);
         this.lblTIPOS_DescC.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
         this.lblTIPOS_DescC.Name = "lblTIPOS_DescC";
         this.lblTIPOS_DescC.Size = new System.Drawing.Size(114, 13);
         this.lblTIPOS_DescC.TabIndex = 6;
         this.lblTIPOS_DescC.Text = "Descripción Corta:";
         // 
         // txtTIPOS_Desc
         // 
         this.tableLayoutPanel2.SetColumnSpan(this.txtTIPOS_Desc, 4);
         this.txtTIPOS_Desc.Location = new System.Drawing.Point(153, 30);
         this.txtTIPOS_Desc.Name = "txtTIPOS_Desc";
         this.txtTIPOS_Desc.Size = new System.Drawing.Size(559, 20);
         this.txtTIPOS_Desc.TabIndex = 5;
         this.txtTIPOS_Desc.Tag = "RESG_DescMSGERROR";
         // 
         // lblTIPOS_Desc
         // 
         this.lblTIPOS_Desc.AutoSize = true;
         this.lblTIPOS_Desc.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.lblTIPOS_Desc.Location = new System.Drawing.Point(10, 34);
         this.lblTIPOS_Desc.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
         this.lblTIPOS_Desc.Name = "lblTIPOS_Desc";
         this.lblTIPOS_Desc.Size = new System.Drawing.Size(78, 13);
         this.lblTIPOS_Desc.TabIndex = 4;
         this.lblTIPOS_Desc.Text = "Descripción:";
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
         this.tableLayoutPanel2.Controls.Add(this.txtTIPOS_DescC, 1, 2);
         this.tableLayoutPanel2.Controls.Add(this.lblTIPOS_DescC, 0, 2);
         this.tableLayoutPanel2.Controls.Add(this.lblTIPOS_Desc, 0, 1);
         this.tableLayoutPanel2.Controls.Add(this.txtTIPOS_Desc, 1, 1);
         this.tableLayoutPanel2.Controls.Add(this.TipoRESG_Codigo, 1, 0);
         this.tableLayoutPanel2.Controls.Add(this.lblTIPOS_EstadoGestion, 3, 0);
         this.tableLayoutPanel2.Controls.Add(this.chkRESG_estado, 4, 0);
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
         // label1
         // 
         this.label1.AutoSize = true;
         this.label1.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.label1.Location = new System.Drawing.Point(10, 7);
         this.label1.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
         this.label1.Name = "label1";
         this.label1.Size = new System.Drawing.Size(126, 13);
         this.label1.TabIndex = 0;
         this.label1.Text = "Tipo Result. Gestión:";
         // 
         // TipoRESG_Codigo
         // 
         this.TipoRESG_Codigo.ComboIntSelectedValue = null;
         this.TipoRESG_Codigo.ComboSelectedItem = null;
         this.TipoRESG_Codigo.ComboStrSelectedValue = null;
         this.TipoRESG_Codigo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this.TipoRESG_Codigo.FormattingEnabled = true;
         this.TipoRESG_Codigo.Location = new System.Drawing.Point(153, 3);
         this.TipoRESG_Codigo.Name = "TipoRESG_Codigo";
         this.TipoRESG_Codigo.Size = new System.Drawing.Size(194, 21);
         this.TipoRESG_Codigo.TabIndex = 1;
         // 
         // lblTIPOS_EstadoGestion
         // 
         this.lblTIPOS_EstadoGestion.AutoSize = true;
         this.lblTIPOS_EstadoGestion.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.lblTIPOS_EstadoGestion.Location = new System.Drawing.Point(375, 7);
         this.lblTIPOS_EstadoGestion.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
         this.lblTIPOS_EstadoGestion.Name = "lblTIPOS_EstadoGestion";
         this.lblTIPOS_EstadoGestion.Size = new System.Drawing.Size(47, 13);
         this.lblTIPOS_EstadoGestion.TabIndex = 2;
         this.lblTIPOS_EstadoGestion.Text = "Activo:";
         // 
         // chkRESG_estado
         // 
         this.chkRESG_estado.AutoSize = true;
         this.chkRESG_estado.Checked = true;
         this.chkRESG_estado.CheckState = System.Windows.Forms.CheckState.Checked;
         this.chkRESG_estado.Location = new System.Drawing.Point(518, 3);
         this.chkRESG_estado.Name = "chkRESG_estado";
         this.chkRESG_estado.Size = new System.Drawing.Size(15, 14);
         this.chkRESG_estado.TabIndex = 3;
         this.chkRESG_estado.UseVisualStyleBackColor = true;
         // 
         // MAN003MView
         // 
         this.AcceptButton = this.btnMAN_guardar;
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.BackColor = System.Drawing.Color.LightSteelBlue;
         this.CancelButton = this.btnMAN_salir;
         this.ClientSize = new System.Drawing.Size(735, 161);
         this.Controls.Add(this.tableLayoutPanel2);
         this.Controls.Add(this.panelCaption1);
         this.Controls.Add(this.panel3);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "MAN003MView";
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
         this.Text = "Resultados de Gestión";
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
      private System.Windows.Forms.Label lblTIPOS_Desc;
      private System.Windows.Forms.TextBox txtTIPOS_Desc;
      private System.Windows.Forms.Label lblTIPOS_DescC;
      private System.Windows.Forms.TextBox txtTIPOS_DescC;
      private System.Windows.Forms.Label lblTIPOS_EstadoGestion;
      private System.Windows.Forms.CheckBox chkRESG_estado;
      private System.Windows.Forms.Label label1;
      private Infrastructure.WinForms.Controls.ComboBox.ComboBox TipoRESG_Codigo;
   }
}