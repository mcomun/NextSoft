namespace Delfin.Principal
{
   partial class MAN000MView
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
         this.panelOpciones = new System.Windows.Forms.Panel();
         this.btnSalir = new System.Windows.Forms.Button();
         this.btnGuardar = new System.Windows.Forms.Button();
         this.panelEmpresa = new Infrastructure.WinForms.Controls.PanelCaption();
         this.tableEmpresa = new System.Windows.Forms.TableLayoutPanel();
         this.lblEMPR_Direccion = new System.Windows.Forms.Label();
         this.txtEMPR_Direccion = new System.Windows.Forms.TextBox();
         this.lblEMPR_RazonComercial = new System.Windows.Forms.Label();
         this.txtEMPR_RazonComercial = new System.Windows.Forms.TextBox();
         this.lblEMPR_RazonSocial = new System.Windows.Forms.Label();
         this.txtEMPR_RazonSocial = new System.Windows.Forms.TextBox();
         this.lblEMPR_RUC = new System.Windows.Forms.Label();
         this.txtEMPR_RUC = new Infrastructure.WinForms.Controls.TextBoxNumerico();
         this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
         this.panelOpciones.SuspendLayout();
         this.tableEmpresa.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
         this.SuspendLayout();
         // 
         // panelOpciones
         // 
         this.panelOpciones.BackColor = System.Drawing.Color.LightSteelBlue;
         this.panelOpciones.Controls.Add(this.btnSalir);
         this.panelOpciones.Controls.Add(this.btnGuardar);
         this.panelOpciones.Dock = System.Windows.Forms.DockStyle.Top;
         this.panelOpciones.Location = new System.Drawing.Point(0, 0);
         this.panelOpciones.Name = "panelOpciones";
         this.panelOpciones.Size = new System.Drawing.Size(735, 50);
         this.panelOpciones.TabIndex = 1;
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
         // panelEmpresa
         // 
         this.panelEmpresa.AllowActive = false;
         this.panelEmpresa.AntiAlias = false;
         this.panelEmpresa.Caption = "Datos de la Empresa";
         this.panelEmpresa.Dock = System.Windows.Forms.DockStyle.Top;
         this.panelEmpresa.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
         this.panelEmpresa.InactiveGradientHighColor = System.Drawing.Color.SteelBlue;
         this.panelEmpresa.InactiveGradientLowColor = System.Drawing.Color.MidnightBlue;
         this.panelEmpresa.Location = new System.Drawing.Point(0, 50);
         this.panelEmpresa.Name = "panelEmpresa";
         this.panelEmpresa.Size = new System.Drawing.Size(735, 26);
         this.panelEmpresa.TabIndex = 0;
         // 
         // tableEmpresa
         // 
         this.tableEmpresa.AutoSize = true;
         this.tableEmpresa.ColumnCount = 7;
         this.tableEmpresa.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
         this.tableEmpresa.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
         this.tableEmpresa.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15F));
         this.tableEmpresa.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
         this.tableEmpresa.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
         this.tableEmpresa.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15F));
         this.tableEmpresa.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
         this.tableEmpresa.Controls.Add(this.lblEMPR_Direccion, 0, 3);
         this.tableEmpresa.Controls.Add(this.txtEMPR_Direccion, 1, 3);
         this.tableEmpresa.Controls.Add(this.lblEMPR_RazonComercial, 0, 2);
         this.tableEmpresa.Controls.Add(this.txtEMPR_RazonComercial, 1, 2);
         this.tableEmpresa.Controls.Add(this.lblEMPR_RazonSocial, 0, 1);
         this.tableEmpresa.Controls.Add(this.txtEMPR_RazonSocial, 1, 1);
         this.tableEmpresa.Controls.Add(this.lblEMPR_RUC, 0, 0);
         this.tableEmpresa.Controls.Add(this.txtEMPR_RUC, 1, 0);
         this.tableEmpresa.Dock = System.Windows.Forms.DockStyle.Top;
         this.tableEmpresa.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
         this.tableEmpresa.Location = new System.Drawing.Point(0, 76);
         this.tableEmpresa.Name = "tableEmpresa";
         this.tableEmpresa.RowCount = 4;
         this.tableEmpresa.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
         this.tableEmpresa.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
         this.tableEmpresa.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
         this.tableEmpresa.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
         this.tableEmpresa.Size = new System.Drawing.Size(735, 108);
         this.tableEmpresa.TabIndex = 1;
         // 
         // lblEMPR_Direccion
         // 
         this.lblEMPR_Direccion.AutoSize = true;
         this.lblEMPR_Direccion.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.lblEMPR_Direccion.Location = new System.Drawing.Point(10, 88);
         this.lblEMPR_Direccion.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
         this.lblEMPR_Direccion.Name = "lblEMPR_Direccion";
         this.lblEMPR_Direccion.Size = new System.Drawing.Size(65, 13);
         this.lblEMPR_Direccion.TabIndex = 6;
         this.lblEMPR_Direccion.Text = "Dirección:";
         // 
         // txtEMPR_Direccion
         // 
         this.tableEmpresa.SetColumnSpan(this.txtEMPR_Direccion, 4);
         this.txtEMPR_Direccion.Location = new System.Drawing.Point(153, 84);
         this.txtEMPR_Direccion.Name = "txtEMPR_Direccion";
         this.txtEMPR_Direccion.Size = new System.Drawing.Size(559, 20);
         this.txtEMPR_Direccion.TabIndex = 7;
         this.txtEMPR_Direccion.Tag = "EMPR_DireccionMSGERROR";
         // 
         // lblEMPR_RazonComercial
         // 
         this.lblEMPR_RazonComercial.AutoSize = true;
         this.lblEMPR_RazonComercial.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.lblEMPR_RazonComercial.Location = new System.Drawing.Point(10, 61);
         this.lblEMPR_RazonComercial.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
         this.lblEMPR_RazonComercial.Name = "lblEMPR_RazonComercial";
         this.lblEMPR_RazonComercial.Size = new System.Drawing.Size(129, 13);
         this.lblEMPR_RazonComercial.TabIndex = 4;
         this.lblEMPR_RazonComercial.Text = "Representante Legal:";
         // 
         // txtEMPR_RazonComercial
         // 
         this.tableEmpresa.SetColumnSpan(this.txtEMPR_RazonComercial, 4);
         this.txtEMPR_RazonComercial.Location = new System.Drawing.Point(153, 57);
         this.txtEMPR_RazonComercial.Name = "txtEMPR_RazonComercial";
         this.txtEMPR_RazonComercial.Size = new System.Drawing.Size(559, 20);
         this.txtEMPR_RazonComercial.TabIndex = 5;
         this.txtEMPR_RazonComercial.Tag = "EMPR_RazonComercialMSGERROR";
         // 
         // lblEMPR_RazonSocial
         // 
         this.lblEMPR_RazonSocial.AutoSize = true;
         this.lblEMPR_RazonSocial.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.lblEMPR_RazonSocial.Location = new System.Drawing.Point(10, 34);
         this.lblEMPR_RazonSocial.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
         this.lblEMPR_RazonSocial.Name = "lblEMPR_RazonSocial";
         this.lblEMPR_RazonSocial.Size = new System.Drawing.Size(85, 13);
         this.lblEMPR_RazonSocial.TabIndex = 2;
         this.lblEMPR_RazonSocial.Text = "Razón Social:";
         // 
         // txtEMPR_RazonSocial
         // 
         this.tableEmpresa.SetColumnSpan(this.txtEMPR_RazonSocial, 4);
         this.txtEMPR_RazonSocial.Location = new System.Drawing.Point(153, 30);
         this.txtEMPR_RazonSocial.Name = "txtEMPR_RazonSocial";
         this.txtEMPR_RazonSocial.Size = new System.Drawing.Size(559, 20);
         this.txtEMPR_RazonSocial.TabIndex = 3;
         this.txtEMPR_RazonSocial.Tag = "EMPR_RazonSocialMSGERROR";
         // 
         // lblEMPR_RUC
         // 
         this.lblEMPR_RUC.AutoSize = true;
         this.lblEMPR_RUC.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.lblEMPR_RUC.Location = new System.Drawing.Point(10, 7);
         this.lblEMPR_RUC.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
         this.lblEMPR_RUC.Name = "lblEMPR_RUC";
         this.lblEMPR_RUC.Size = new System.Drawing.Size(37, 13);
         this.lblEMPR_RUC.TabIndex = 0;
         this.lblEMPR_RUC.Text = "RUC:";
         // 
         // txtEMPR_RUC
         // 
         this.txtEMPR_RUC.BaseTipo = Infrastructure.WinForms.Controls.EstandaresFormato.General;
         this.txtEMPR_RUC.Decimales = 0;
         this.txtEMPR_RUC.Enteros = 11;
         this.txtEMPR_RUC.Formato = "##,###,###,##0.";
         this.txtEMPR_RUC.Location = new System.Drawing.Point(153, 3);
         this.txtEMPR_RUC.MaxLength = 12;
         this.txtEMPR_RUC.Name = "txtEMPR_RUC";
         this.txtEMPR_RUC.Negativo = true;
         this.txtEMPR_RUC.SinFormato = true;
         this.txtEMPR_RUC.Size = new System.Drawing.Size(194, 20);
         this.txtEMPR_RUC.TabIndex = 1;
         this.txtEMPR_RUC.Text = "0";
         this.txtEMPR_RUC.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
         this.txtEMPR_RUC.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
         // 
         // errorProvider1
         // 
         this.errorProvider1.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
         this.errorProvider1.ContainerControl = this;
         // 
         // MAN000MView
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.BackColor = System.Drawing.Color.LightSteelBlue;
         this.CancelButton = this.btnSalir;
         this.ClientSize = new System.Drawing.Size(735, 189);
         this.Controls.Add(this.tableEmpresa);
         this.Controls.Add(this.panelEmpresa);
         this.Controls.Add(this.panelOpciones);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "MAN000MView";
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
         this.Text = "Empresa";
         this.panelOpciones.ResumeLayout(false);
         this.panelOpciones.PerformLayout();
         this.tableEmpresa.ResumeLayout(false);
         this.tableEmpresa.PerformLayout();
         ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.Panel panelOpciones;
      private System.Windows.Forms.Button btnSalir;
      private System.Windows.Forms.Button btnGuardar;
      private Infrastructure.WinForms.Controls.PanelCaption panelEmpresa;
      private System.Windows.Forms.TableLayoutPanel tableEmpresa;
      private System.Windows.Forms.Label lblEMPR_RUC;
      private System.Windows.Forms.Label lblEMPR_Direccion;
      private System.Windows.Forms.Label lblEMPR_RazonComercial;
      private System.Windows.Forms.Label lblEMPR_RazonSocial;
      private System.Windows.Forms.TextBox txtEMPR_Direccion;
      private System.Windows.Forms.TextBox txtEMPR_RazonComercial;
      private System.Windows.Forms.TextBox txtEMPR_RazonSocial;
      private System.Windows.Forms.ErrorProvider errorProvider1;
      private Infrastructure.WinForms.Controls.TextBoxNumerico txtEMPR_RUC;
   }
}