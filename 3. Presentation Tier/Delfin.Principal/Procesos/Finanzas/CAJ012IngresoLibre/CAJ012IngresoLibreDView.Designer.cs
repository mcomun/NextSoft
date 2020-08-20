namespace Delfin.Principal.Procesos.Finanzas
{
   partial class CAJ012IngresoLibreDView
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
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CAJ012IngresoLibreDView));
         this.panelCaption1 = new Infrastructure.WinForms.Controls.PanelCaption();
         this.groupBox1 = new System.Windows.Forms.GroupBox();
         this.rbtnEliminar = new System.Windows.Forms.RadioButton();
         this.rbtnAnular = new System.Windows.Forms.RadioButton();
         this.panel3 = new System.Windows.Forms.Panel();
         this.btnSalir = new System.Windows.Forms.Button();
         this.btnAceptar = new System.Windows.Forms.Button();
         this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
         this.txtAsientos = new System.Windows.Forms.TextBox();
         this.label23 = new System.Windows.Forms.Label();
         this.groupBox1.SuspendLayout();
         this.panel3.SuspendLayout();
         this.tableLayoutPanel4.SuspendLayout();
         this.SuspendLayout();
         // 
         // panelCaption1
         // 
         this.panelCaption1.AllowActive = false;
         this.panelCaption1.AntiAlias = false;
         this.panelCaption1.Caption = "Desvinculación de Asientos";
         this.panelCaption1.Dock = System.Windows.Forms.DockStyle.Top;
         this.panelCaption1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
         this.panelCaption1.InactiveGradientHighColor = System.Drawing.Color.SteelBlue;
         this.panelCaption1.InactiveGradientLowColor = System.Drawing.Color.MidnightBlue;
         this.panelCaption1.Location = new System.Drawing.Point(0, 0);
         this.panelCaption1.Name = "panelCaption1";
         this.panelCaption1.Size = new System.Drawing.Size(371, 26);
         this.panelCaption1.TabIndex = 3;
         // 
         // groupBox1
         // 
         this.groupBox1.Controls.Add(this.rbtnEliminar);
         this.groupBox1.Controls.Add(this.rbtnAnular);
         this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
         this.groupBox1.Location = new System.Drawing.Point(0, 103);
         this.groupBox1.Name = "groupBox1";
         this.groupBox1.Size = new System.Drawing.Size(371, 53);
         this.groupBox1.TabIndex = 4;
         this.groupBox1.TabStop = false;
         // 
         // rbtnEliminar
         // 
         this.rbtnEliminar.AutoSize = true;
         this.rbtnEliminar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.rbtnEliminar.Location = new System.Drawing.Point(195, 19);
         this.rbtnEliminar.Name = "rbtnEliminar";
         this.rbtnEliminar.Size = new System.Drawing.Size(127, 21);
         this.rbtnEliminar.TabIndex = 1;
         this.rbtnEliminar.Text = "Eliminar Asiento";
         this.rbtnEliminar.UseVisualStyleBackColor = true;
         // 
         // rbtnAnular
         // 
         this.rbtnAnular.AutoSize = true;
         this.rbtnAnular.Checked = true;
         this.rbtnAnular.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.rbtnAnular.Location = new System.Drawing.Point(49, 19);
         this.rbtnAnular.Name = "rbtnAnular";
         this.rbtnAnular.Size = new System.Drawing.Size(118, 21);
         this.rbtnAnular.TabIndex = 0;
         this.rbtnAnular.TabStop = true;
         this.rbtnAnular.Text = "Anular Asiento";
         this.rbtnAnular.UseVisualStyleBackColor = true;
         // 
         // panel3
         // 
         this.panel3.BackColor = System.Drawing.Color.LightSteelBlue;
         this.panel3.Controls.Add(this.btnSalir);
         this.panel3.Controls.Add(this.btnAceptar);
         this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
         this.panel3.Location = new System.Drawing.Point(0, 26);
         this.panel3.Name = "panel3";
         this.panel3.Size = new System.Drawing.Size(371, 50);
         this.panel3.TabIndex = 5;
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
         this.btnSalir.TabIndex = 2;
         this.btnSalir.Text = "&Salir";
         this.btnSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
         this.btnSalir.UseVisualStyleBackColor = true;
         // 
         // btnAceptar
         // 
         this.btnAceptar.AutoSize = true;
         this.btnAceptar.Dock = System.Windows.Forms.DockStyle.Left;
         this.btnAceptar.FlatAppearance.BorderColor = System.Drawing.Color.LightSteelBlue;
         this.btnAceptar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
         this.btnAceptar.ForeColor = System.Drawing.Color.Black;
         this.btnAceptar.Image = global::Delfin.Principal.Properties.Resources.check;
         this.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
         this.btnAceptar.Location = new System.Drawing.Point(0, 0);
         this.btnAceptar.Margin = new System.Windows.Forms.Padding(0);
         this.btnAceptar.Name = "btnAceptar";
         this.btnAceptar.Size = new System.Drawing.Size(57, 50);
         this.btnAceptar.TabIndex = 0;
         this.btnAceptar.Text = "&Aceptar";
         this.btnAceptar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
         this.btnAceptar.UseVisualStyleBackColor = true;
         // 
         // tableLayoutPanel4
         // 
         this.tableLayoutPanel4.AutoSize = true;
         this.tableLayoutPanel4.BackColor = System.Drawing.Color.LightSteelBlue;
         this.tableLayoutPanel4.ColumnCount = 10;
         this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
         this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
         this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15F));
         this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
         this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
         this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15F));
         this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
         this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
         this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15F));
         this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
         this.tableLayoutPanel4.Controls.Add(this.txtAsientos, 1, 0);
         this.tableLayoutPanel4.Controls.Add(this.label23, 0, 0);
         this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Top;
         this.tableLayoutPanel4.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
         this.tableLayoutPanel4.Location = new System.Drawing.Point(0, 76);
         this.tableLayoutPanel4.Name = "tableLayoutPanel4";
         this.tableLayoutPanel4.RowCount = 1;
         this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
         this.tableLayoutPanel4.Size = new System.Drawing.Size(371, 27);
         this.tableLayoutPanel4.TabIndex = 6;
         // 
         // txtAsientos
         // 
         this.txtAsientos.Location = new System.Drawing.Point(153, 3);
         this.txtAsientos.Name = "txtAsientos";
         this.txtAsientos.Size = new System.Drawing.Size(194, 20);
         this.txtAsientos.TabIndex = 7;
         // 
         // label23
         // 
         this.label23.AutoSize = true;
         this.label23.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.label23.Location = new System.Drawing.Point(10, 7);
         this.label23.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
         this.label23.Name = "label23";
         this.label23.Size = new System.Drawing.Size(58, 13);
         this.label23.TabIndex = 0;
         this.label23.Text = "Asiento :";
         // 
         // CAJ012IngresoLibreDView
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.BackColor = System.Drawing.Color.LightSteelBlue;
         this.CancelButton = this.btnSalir;
         this.ClientSize = new System.Drawing.Size(371, 157);
         this.Controls.Add(this.groupBox1);
         this.Controls.Add(this.tableLayoutPanel4);
         this.Controls.Add(this.panel3);
         this.Controls.Add(this.panelCaption1);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
         this.Name = "CAJ012IngresoLibreDView";
         this.Text = "Desvinculación de Asientos";
         this.groupBox1.ResumeLayout(false);
         this.groupBox1.PerformLayout();
         this.panel3.ResumeLayout(false);
         this.panel3.PerformLayout();
         this.tableLayoutPanel4.ResumeLayout(false);
         this.tableLayoutPanel4.PerformLayout();
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private Infrastructure.WinForms.Controls.PanelCaption panelCaption1;
      private System.Windows.Forms.GroupBox groupBox1;
      private System.Windows.Forms.RadioButton rbtnEliminar;
      private System.Windows.Forms.RadioButton rbtnAnular;
      private System.Windows.Forms.Panel panel3;
      private System.Windows.Forms.Button btnAceptar;
      private System.Windows.Forms.Button btnSalir;
      private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
      private System.Windows.Forms.Label label23;
      private System.Windows.Forms.TextBox txtAsientos;
   }
}