namespace Delfin.Principal
{
   partial class REP014View
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
            this.errorProviderCab_Cotizacion_OV = new System.Windows.Forms.ErrorProvider(this.components);
            this.errorProviderDet_Cotizacion_OV_Novedad = new System.Windows.Forms.ErrorProvider(this.components);
            this.errorEventoTarea = new System.Windows.Forms.ErrorProvider(this.components);
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnSalir = new System.Windows.Forms.Button();
            this.btnCargar = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lblFECHA = new System.Windows.Forms.Label();
            this.mdtFECH_Inicio = new Infrastructure.WinForms.Controls.MaskDateTime();
            this.lblFECH_Ini = new System.Windows.Forms.Label();
            this.lblFECH_Fin = new System.Windows.Forms.Label();
            this.mdtFECH_Fin = new Infrastructure.WinForms.Controls.MaskDateTime();
            this.lblCONS_CodRGM = new System.Windows.Forms.Label();
            this.cmbCONS_CodRGM = new Delfin.Controls.Tipos.ComboBoxConstantes();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderCab_Cotizacion_OV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderDet_Cotizacion_OV_Novedad)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorEventoTarea)).BeginInit();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // errorProviderCab_Cotizacion_OV
            // 
            this.errorProviderCab_Cotizacion_OV.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errorProviderCab_Cotizacion_OV.ContainerControl = this;
            // 
            // errorProviderDet_Cotizacion_OV_Novedad
            // 
            this.errorProviderDet_Cotizacion_OV_Novedad.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errorProviderDet_Cotizacion_OV_Novedad.ContainerControl = this;
            // 
            // errorEventoTarea
            // 
            this.errorEventoTarea.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errorEventoTarea.ContainerControl = this;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.panel1.Controls.Add(this.btnSalir);
            this.panel1.Controls.Add(this.btnCargar);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(777, 50);
            this.panel1.TabIndex = 6;
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
            // btnCargar
            // 
            this.btnCargar.AutoSize = true;
            this.btnCargar.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnCargar.FlatAppearance.BorderColor = System.Drawing.Color.LightSteelBlue;
            this.btnCargar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCargar.ForeColor = System.Drawing.Color.Black;
            this.btnCargar.Image = global::Delfin.Principal.Properties.Resources.replace21;
            this.btnCargar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnCargar.Location = new System.Drawing.Point(0, 0);
            this.btnCargar.Margin = new System.Windows.Forms.Padding(0);
            this.btnCargar.Name = "btnCargar";
            this.btnCargar.Size = new System.Drawing.Size(57, 50);
            this.btnCargar.TabIndex = 0;
            this.btnCargar.Text = "Cargar";
            this.btnCargar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCargar.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.ColumnCount = 8;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 130F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 198F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 17F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.mdtFECH_Inicio, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblFECH_Ini, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblFECH_Fin, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.mdtFECH_Fin, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblCONS_CodRGM, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.cmbCONS_CodRGM, 5, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblFECHA, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 50);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(777, 54);
            this.tableLayoutPanel1.TabIndex = 7;
            // 
            // lblFECHA
            // 
            this.lblFECHA.AutoSize = true;
            this.lblFECHA.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFECHA.Location = new System.Drawing.Point(10, 7);
            this.lblFECHA.Margin = new System.Windows.Forms.Padding(10, 7, 2, 0);
            this.lblFECHA.Name = "lblFECHA";
            this.lblFECHA.Size = new System.Drawing.Size(113, 13);
            this.lblFECHA.TabIndex = 73;
            this.lblFECHA.Text = "Fecha ETA/Zarpe :";
            // 
            // mdtFECH_Inicio
            // 
            this.mdtFECH_Inicio.Location = new System.Drawing.Point(233, 3);
            this.mdtFECH_Inicio.MinimumSize = new System.Drawing.Size(100, 22);
            this.mdtFECH_Inicio.Name = "mdtFECH_Inicio";
            this.mdtFECH_Inicio.NSActiveMouse = false;
            this.mdtFECH_Inicio.NSActiveMsgFecha = false;
            this.mdtFECH_Inicio.NSChangeDate = true;
            this.mdtFECH_Inicio.NSDigitos = 4;
            this.mdtFECH_Inicio.NSFecha = null;
            this.mdtFECH_Inicio.NSSetDateNow = false;
            this.mdtFECH_Inicio.Size = new System.Drawing.Size(194, 22);
            this.mdtFECH_Inicio.TabIndex = 75;
            // 
            // lblFECH_Ini
            // 
            this.lblFECH_Ini.AutoSize = true;
            this.lblFECH_Ini.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFECH_Ini.Location = new System.Drawing.Point(140, 7);
            this.lblFECH_Ini.Margin = new System.Windows.Forms.Padding(10, 7, 2, 0);
            this.lblFECH_Ini.Name = "lblFECH_Ini";
            this.lblFECH_Ini.Size = new System.Drawing.Size(47, 13);
            this.lblFECH_Ini.TabIndex = 74;
            this.lblFECH_Ini.Text = "Inicio :";
            // 
            // lblFECH_Fin
            // 
            this.lblFECH_Fin.AutoSize = true;
            this.lblFECH_Fin.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFECH_Fin.Location = new System.Drawing.Point(140, 34);
            this.lblFECH_Fin.Margin = new System.Windows.Forms.Padding(10, 7, 2, 0);
            this.lblFECH_Fin.Name = "lblFECH_Fin";
            this.lblFECH_Fin.Size = new System.Drawing.Size(32, 13);
            this.lblFECH_Fin.TabIndex = 74;
            this.lblFECH_Fin.Text = "Fin :";
            // 
            // mdtFECH_Fin
            // 
            this.mdtFECH_Fin.Location = new System.Drawing.Point(233, 30);
            this.mdtFECH_Fin.MinimumSize = new System.Drawing.Size(100, 22);
            this.mdtFECH_Fin.Name = "mdtFECH_Fin";
            this.mdtFECH_Fin.NSActiveMouse = false;
            this.mdtFECH_Fin.NSActiveMsgFecha = false;
            this.mdtFECH_Fin.NSChangeDate = true;
            this.mdtFECH_Fin.NSDigitos = 4;
            this.mdtFECH_Fin.NSFecha = null;
            this.mdtFECH_Fin.NSSetDateNow = false;
            this.mdtFECH_Fin.Size = new System.Drawing.Size(194, 22);
            this.mdtFECH_Fin.TabIndex = 76;
            // 
            // lblCONS_CodRGM
            // 
            this.lblCONS_CodRGM.AutoSize = true;
            this.lblCONS_CodRGM.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCONS_CodRGM.Location = new System.Drawing.Point(455, 7);
            this.lblCONS_CodRGM.Margin = new System.Windows.Forms.Padding(10, 7, 2, 0);
            this.lblCONS_CodRGM.Name = "lblCONS_CodRGM";
            this.lblCONS_CodRGM.Size = new System.Drawing.Size(62, 13);
            this.lblCONS_CodRGM.TabIndex = 71;
            this.lblCONS_CodRGM.Text = "Regimen:";
            // 
            // cmbCONS_CodRGM
            // 
            this.cmbCONS_CodRGM.ConstantesSelectedItem = null;
            this.cmbCONS_CodRGM.ConstantesSelectedValue = null;
            this.cmbCONS_CodRGM.ConstantesTitulo = null;
            this.cmbCONS_CodRGM.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCONS_CodRGM.FormattingEnabled = true;
            this.cmbCONS_CodRGM.Location = new System.Drawing.Point(548, 3);
            this.cmbCONS_CodRGM.Name = "cmbCONS_CodRGM";
            this.cmbCONS_CodRGM.Session = null;
            this.cmbCONS_CodRGM.Size = new System.Drawing.Size(192, 21);
            this.cmbCONS_CodRGM.TabIndex = 77;
            // 
            // REP014View
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(777, 111);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "REP014View";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Reportes Control De Transmisiones";
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderCab_Cotizacion_OV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderDet_Cotizacion_OV_Novedad)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorEventoTarea)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

      }



      #endregion

      private System.Windows.Forms.ErrorProvider errorProviderCab_Cotizacion_OV;
      private System.Windows.Forms.ErrorProvider errorProviderDet_Cotizacion_OV_Novedad;
      private System.Windows.Forms.ErrorProvider errorEventoTarea;
      private System.Windows.Forms.ToolTip toolTip1;
      private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
      private System.Windows.Forms.Label lblFECHA;
      private Infrastructure.WinForms.Controls.MaskDateTime mdtFECH_Inicio;
      private System.Windows.Forms.Label lblFECH_Ini;
      private System.Windows.Forms.Label lblFECH_Fin;
      private Infrastructure.WinForms.Controls.MaskDateTime mdtFECH_Fin;
      private System.Windows.Forms.Label lblCONS_CodRGM;
      private System.Windows.Forms.Panel panel1;
      private System.Windows.Forms.Button btnSalir;
      private System.Windows.Forms.Button btnCargar;
      private Controls.Tipos.ComboBoxConstantes cmbCONS_CodRGM;
   }
}