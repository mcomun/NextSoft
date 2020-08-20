namespace Delfin.Principal
{
   partial class MAN008MView
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
         this.txtPACK_DescC = new System.Windows.Forms.TextBox();
         this.lblTIPOS_DescC = new System.Windows.Forms.Label();
         this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
         this.label1 = new System.Windows.Forms.Label();
         this.label5 = new System.Windows.Forms.Label();
         this.txtPACK_Desc = new System.Windows.Forms.TextBox();
         this.PACK_Codigo = new System.Windows.Forms.TextBox();
         this.cmbTIPO_Contenedor = new Delfin.Controls.Tipos.ComboBoxTipos();
         this.label7 = new System.Windows.Forms.Label();
         this.label4 = new System.Windows.Forms.Label();
         this.cmbTIPO_Paqute = new Delfin.Controls.Tipos.ComboBoxTipos();
         this.cmbTIPO_Tamaño = new Delfin.Controls.Tipos.ComboBoxTipos();
         this.label6 = new System.Windows.Forms.Label();
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
         this.panelCaption1.Caption = "Datos de Paquete";
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
         // txtPACK_DescC
         // 
         this.txtPACK_DescC.Location = new System.Drawing.Point(518, 3);
         this.txtPACK_DescC.Name = "txtPACK_DescC";
         this.txtPACK_DescC.Size = new System.Drawing.Size(194, 20);
         this.txtPACK_DescC.TabIndex = 3;
         this.txtPACK_DescC.Tag = "PACK_DescMSGERROR";
         // 
         // lblTIPOS_DescC
         // 
         this.lblTIPOS_DescC.AutoSize = true;
         this.lblTIPOS_DescC.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.lblTIPOS_DescC.Location = new System.Drawing.Point(375, 7);
         this.lblTIPOS_DescC.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
         this.lblTIPOS_DescC.Name = "lblTIPOS_DescC";
         this.lblTIPOS_DescC.Size = new System.Drawing.Size(114, 13);
         this.lblTIPOS_DescC.TabIndex = 2;
         this.lblTIPOS_DescC.Text = "Descripción Corta:";
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
         this.tableLayoutPanel2.Controls.Add(this.label5, 0, 1);
         this.tableLayoutPanel2.Controls.Add(this.txtPACK_Desc, 1, 1);
         this.tableLayoutPanel2.Controls.Add(this.PACK_Codigo, 1, 0);
         this.tableLayoutPanel2.Controls.Add(this.cmbTIPO_Contenedor, 1, 2);
         this.tableLayoutPanel2.Controls.Add(this.label7, 0, 2);
         this.tableLayoutPanel2.Controls.Add(this.label4, 0, 3);
         this.tableLayoutPanel2.Controls.Add(this.cmbTIPO_Paqute, 1, 3);
         this.tableLayoutPanel2.Controls.Add(this.txtPACK_DescC, 4, 0);
         this.tableLayoutPanel2.Controls.Add(this.cmbTIPO_Tamaño, 4, 2);
         this.tableLayoutPanel2.Controls.Add(this.lblTIPOS_DescC, 3, 0);
         this.tableLayoutPanel2.Controls.Add(this.label6, 3, 2);
         this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Top;
         this.tableLayoutPanel2.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
         this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 76);
         this.tableLayoutPanel2.Name = "tableLayoutPanel2";
         this.tableLayoutPanel2.RowCount = 4;
         this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
         this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
         this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
         this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
         this.tableLayoutPanel2.Size = new System.Drawing.Size(735, 108);
         this.tableLayoutPanel2.TabIndex = 1;
         // 
         // label1
         // 
         this.label1.AutoSize = true;
         this.label1.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.label1.Location = new System.Drawing.Point(10, 7);
         this.label1.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
         this.label1.Name = "label1";
         this.label1.Size = new System.Drawing.Size(52, 13);
         this.label1.TabIndex = 0;
         this.label1.Text = "Código:";
         // 
         // label5
         // 
         this.label5.AutoSize = true;
         this.label5.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.label5.Location = new System.Drawing.Point(10, 34);
         this.label5.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
         this.label5.Name = "label5";
         this.label5.Size = new System.Drawing.Size(78, 13);
         this.label5.TabIndex = 4;
         this.label5.Text = "Descripción:";
         // 
         // txtPACK_Desc
         // 
         this.tableLayoutPanel2.SetColumnSpan(this.txtPACK_Desc, 4);
         this.txtPACK_Desc.Location = new System.Drawing.Point(153, 30);
         this.txtPACK_Desc.Name = "txtPACK_Desc";
         this.txtPACK_Desc.Size = new System.Drawing.Size(559, 20);
         this.txtPACK_Desc.TabIndex = 5;
         this.txtPACK_Desc.Tag = "PACK_DescMSGERROR";
         // 
         // PACK_Codigo
         // 
         this.PACK_Codigo.Location = new System.Drawing.Point(153, 3);
         this.PACK_Codigo.Name = "PACK_Codigo";
         this.PACK_Codigo.Size = new System.Drawing.Size(194, 20);
         this.PACK_Codigo.TabIndex = 1;
         this.PACK_Codigo.Tag = "PACK_CodigoMSGERROR";
         // 
         // cmbTIPO_Contenedor
         // 
         this.cmbTIPO_Contenedor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this.cmbTIPO_Contenedor.FormattingEnabled = true;
         this.cmbTIPO_Contenedor.Location = new System.Drawing.Point(153, 57);
         this.cmbTIPO_Contenedor.Name = "cmbTIPO_Contenedor";
         this.cmbTIPO_Contenedor.Session = null;
         this.cmbTIPO_Contenedor.Size = new System.Drawing.Size(194, 21);
         this.cmbTIPO_Contenedor.TabIndex = 7;
         this.cmbTIPO_Contenedor.TiposSelectedItem = null;
         this.cmbTIPO_Contenedor.TiposSelectedValue = null;
         this.cmbTIPO_Contenedor.TiposTitulo = null;
         // 
         // label7
         // 
         this.label7.AutoSize = true;
         this.label7.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.label7.Location = new System.Drawing.Point(10, 61);
         this.label7.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
         this.label7.Name = "label7";
         this.label7.Size = new System.Drawing.Size(79, 13);
         this.label7.TabIndex = 6;
         this.label7.Text = "Contenedor:";
         // 
         // label4
         // 
         this.label4.AutoSize = true;
         this.label4.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.label4.Location = new System.Drawing.Point(10, 88);
         this.label4.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
         this.label4.Name = "label4";
         this.label4.Size = new System.Drawing.Size(93, 13);
         this.label4.TabIndex = 10;
         this.label4.Text = "Tipo de Carga:";
         // 
         // cmbTIPO_Paqute
         // 
         this.cmbTIPO_Paqute.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this.cmbTIPO_Paqute.FormattingEnabled = true;
         this.cmbTIPO_Paqute.Location = new System.Drawing.Point(153, 84);
         this.cmbTIPO_Paqute.Name = "cmbTIPO_Paqute";
         this.cmbTIPO_Paqute.Session = null;
         this.cmbTIPO_Paqute.Size = new System.Drawing.Size(194, 21);
         this.cmbTIPO_Paqute.TabIndex = 0;
         this.cmbTIPO_Paqute.TiposSelectedItem = null;
         this.cmbTIPO_Paqute.TiposSelectedValue = null;
         this.cmbTIPO_Paqute.TiposTitulo = null;
         // 
         // cmbTIPO_Tamaño
         // 
         this.cmbTIPO_Tamaño.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this.cmbTIPO_Tamaño.FormattingEnabled = true;
         this.cmbTIPO_Tamaño.Location = new System.Drawing.Point(518, 57);
         this.cmbTIPO_Tamaño.Name = "cmbTIPO_Tamaño";
         this.cmbTIPO_Tamaño.Session = null;
         this.cmbTIPO_Tamaño.Size = new System.Drawing.Size(194, 21);
         this.cmbTIPO_Tamaño.TabIndex = 9;
         this.cmbTIPO_Tamaño.TiposSelectedItem = null;
         this.cmbTIPO_Tamaño.TiposSelectedValue = null;
         this.cmbTIPO_Tamaño.TiposTitulo = null;
         // 
         // label6
         // 
         this.label6.AutoSize = true;
         this.label6.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.label6.Location = new System.Drawing.Point(375, 61);
         this.label6.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
         this.label6.Name = "label6";
         this.label6.Size = new System.Drawing.Size(57, 13);
         this.label6.TabIndex = 8;
         this.label6.Text = "Tamaño:";
         // 
         // MAN008MView
         // 
         this.AcceptButton = this.btnMAN_guardar;
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.BackColor = System.Drawing.Color.LightSteelBlue;
         this.CancelButton = this.btnMAN_salir;
         this.ClientSize = new System.Drawing.Size(735, 188);
         this.Controls.Add(this.tableLayoutPanel2);
         this.Controls.Add(this.panelCaption1);
         this.Controls.Add(this.panel3);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "MAN008MView";
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
         this.Text = "Datos de Embalaje";
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
      private System.Windows.Forms.Label lblTIPOS_DescC;
      private System.Windows.Forms.TextBox txtPACK_DescC;
      private System.Windows.Forms.Label label5;
      private System.Windows.Forms.TextBox txtPACK_Desc;
      private System.Windows.Forms.Label label4;
      private System.Windows.Forms.Label label6;
      private System.Windows.Forms.Label label7;
      private Controls.Tipos.ComboBoxTipos cmbTIPO_Paqute;
      private Controls.Tipos.ComboBoxTipos cmbTIPO_Tamaño;
      private Controls.Tipos.ComboBoxTipos cmbTIPO_Contenedor;
      private System.Windows.Forms.Label label1;
      private System.Windows.Forms.TextBox PACK_Codigo;
   }
}