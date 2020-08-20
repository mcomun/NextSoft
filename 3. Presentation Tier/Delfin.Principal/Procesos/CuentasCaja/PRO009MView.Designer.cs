namespace Delfin.Principal
{
   partial class PRO009MView
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
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PRO009MView));
         this.PCEncabezado = new Infrastructure.WinFormsControls.PanelCaption();
         this.panel3 = new System.Windows.Forms.Panel();
         this.btnSalir = new System.Windows.Forms.Button();
         this.btnGuardar = new System.Windows.Forms.Button();
         this.TLPanelDatos = new System.Windows.Forms.TableLayoutPanel();
         this.label9 = new System.Windows.Forms.Label();
         this.label4 = new System.Windows.Forms.Label();
         this.label3 = new System.Windows.Forms.Label();
         this.txtCACU_NroCuenta = new System.Windows.Forms.TextBox();
         this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
         this.CbTIPO_CodBCO = new Delfin.Controls.Tipos.ComboBoxTipos();
         this.CbTIPO_CodMND = new Delfin.Controls.Tipos.ComboBoxTipos();
         this.panel3.SuspendLayout();
         this.TLPanelDatos.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
         this.SuspendLayout();
         // 
         // PCEncabezado
         // 
         this.PCEncabezado.AllowActive = false;
         this.PCEncabezado.AntiAlias = false;
         this.PCEncabezado.Caption = "Datos Cuentas Caja";
         this.PCEncabezado.Dock = System.Windows.Forms.DockStyle.Top;
         this.PCEncabezado.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
         this.PCEncabezado.ForeColor = System.Drawing.Color.White;
         this.PCEncabezado.InactiveGradientHighColor = System.Drawing.Color.SteelBlue;
         this.PCEncabezado.InactiveGradientLowColor = System.Drawing.Color.MidnightBlue;
         this.PCEncabezado.Location = new System.Drawing.Point(0, 50);
         this.PCEncabezado.Name = "PCEncabezado";
         this.PCEncabezado.Size = new System.Drawing.Size(382, 26);
         this.PCEncabezado.TabIndex = 11;
         // 
         // panel3
         // 
         this.panel3.BackColor = System.Drawing.Color.LightSteelBlue;
         this.panel3.Controls.Add(this.btnSalir);
         this.panel3.Controls.Add(this.btnGuardar);
         this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
         this.panel3.Location = new System.Drawing.Point(0, 0);
         this.panel3.Name = "panel3";
         this.panel3.Size = new System.Drawing.Size(382, 50);
         this.panel3.TabIndex = 12;
         // 
         // btnSalir
         // 
         this.btnSalir.AutoSize = true;
         this.btnSalir.Dock = System.Windows.Forms.DockStyle.Left;
         this.btnSalir.FlatAppearance.BorderColor = System.Drawing.Color.LightSteelBlue;
         this.btnSalir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
         this.btnSalir.ForeColor = System.Drawing.Color.Black;
         this.btnSalir.Image = global::Delfin.Principal.Properties.Resources.undo;
         this.btnSalir.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
         this.btnSalir.Location = new System.Drawing.Point(57, 0);
         this.btnSalir.Margin = new System.Windows.Forms.Padding(0);
         this.btnSalir.Name = "btnSalir";
         this.btnSalir.Size = new System.Drawing.Size(51, 50);
         this.btnSalir.TabIndex = 5;
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
         // TLPanelDatos
         // 
         this.TLPanelDatos.AutoSize = true;
         this.TLPanelDatos.BackColor = System.Drawing.Color.LightSteelBlue;
         this.TLPanelDatos.ColumnCount = 3;
         this.TLPanelDatos.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 130F));
         this.TLPanelDatos.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 240F));
         this.TLPanelDatos.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 12F));
         this.TLPanelDatos.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 131F));
         this.TLPanelDatos.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 196F));
         this.TLPanelDatos.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 17F));
         this.TLPanelDatos.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 133F));
         this.TLPanelDatos.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 190F));
         this.TLPanelDatos.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 18F));
         this.TLPanelDatos.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 155F));
         this.TLPanelDatos.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
         this.TLPanelDatos.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15F));
         this.TLPanelDatos.Controls.Add(this.label9, 0, 0);
         this.TLPanelDatos.Controls.Add(this.CbTIPO_CodBCO, 1, 0);
         this.TLPanelDatos.Controls.Add(this.label4, 0, 1);
         this.TLPanelDatos.Controls.Add(this.CbTIPO_CodMND, 1, 1);
         this.TLPanelDatos.Controls.Add(this.label3, 0, 2);
         this.TLPanelDatos.Controls.Add(this.txtCACU_NroCuenta, 1, 2);
         this.TLPanelDatos.Dock = System.Windows.Forms.DockStyle.Top;
         this.TLPanelDatos.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
         this.TLPanelDatos.Location = new System.Drawing.Point(0, 76);
         this.TLPanelDatos.Name = "TLPanelDatos";
         this.TLPanelDatos.RowCount = 3;
         this.TLPanelDatos.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
         this.TLPanelDatos.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
         this.TLPanelDatos.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
         this.TLPanelDatos.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
         this.TLPanelDatos.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
         this.TLPanelDatos.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
         this.TLPanelDatos.Size = new System.Drawing.Size(382, 81);
         this.TLPanelDatos.TabIndex = 13;
         // 
         // label9
         // 
         this.label9.AutoSize = true;
         this.label9.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.label9.Location = new System.Drawing.Point(10, 7);
         this.label9.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
         this.label9.Name = "label9";
         this.label9.Size = new System.Drawing.Size(51, 13);
         this.label9.TabIndex = 0;
         this.label9.Text = "Banco :";
         // 
         // label4
         // 
         this.label4.AutoSize = true;
         this.label4.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.label4.Location = new System.Drawing.Point(10, 34);
         this.label4.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
         this.label4.Name = "label4";
         this.label4.Size = new System.Drawing.Size(56, 13);
         this.label4.TabIndex = 18;
         this.label4.Text = "Moneda:";
         // 
         // label3
         // 
         this.label3.AutoSize = true;
         this.label3.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.label3.Location = new System.Drawing.Point(10, 61);
         this.label3.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
         this.label3.Name = "label3";
         this.label3.Size = new System.Drawing.Size(102, 13);
         this.label3.TabIndex = 4;
         this.label3.Text = "Número Cuenta:";
         // 
         // txtCACU_NroCuenta
         // 
         this.txtCACU_NroCuenta.Location = new System.Drawing.Point(133, 57);
         this.txtCACU_NroCuenta.MaxLength = 20;
         this.txtCACU_NroCuenta.Name = "txtCACU_NroCuenta";
         this.txtCACU_NroCuenta.Size = new System.Drawing.Size(234, 20);
         this.txtCACU_NroCuenta.TabIndex = 3;
         this.txtCACU_NroCuenta.Tag = "";
         // 
         // errorProvider1
         // 
         this.errorProvider1.ContainerControl = this;
         // 
         // CbTIPO_CodBCO
         // 
         this.CbTIPO_CodBCO.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this.CbTIPO_CodBCO.FormattingEnabled = true;
         this.CbTIPO_CodBCO.Location = new System.Drawing.Point(133, 3);
         this.CbTIPO_CodBCO.Name = "CbTIPO_CodBCO";
         this.CbTIPO_CodBCO.Size = new System.Drawing.Size(234, 21);
         this.CbTIPO_CodBCO.TabIndex = 1;
         this.CbTIPO_CodBCO.Tag = "TIPO_CodTDOMSGERROR";
         this.CbTIPO_CodBCO.TiposSelectedItem = null;
         this.CbTIPO_CodBCO.TiposSelectedValue = null;
         this.CbTIPO_CodBCO.TiposTitulo = null;
         // 
         // CbTIPO_CodMND
         // 
         this.CbTIPO_CodMND.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this.CbTIPO_CodMND.FormattingEnabled = true;
         this.CbTIPO_CodMND.Location = new System.Drawing.Point(133, 30);
         this.CbTIPO_CodMND.Name = "CbTIPO_CodMND";
         this.CbTIPO_CodMND.Size = new System.Drawing.Size(234, 21);
         this.CbTIPO_CodMND.TabIndex = 2;
         this.CbTIPO_CodMND.Tag = "TIPO_CodMNDMSGERROR";
         this.CbTIPO_CodMND.TiposSelectedItem = null;
         this.CbTIPO_CodMND.TiposSelectedValue = null;
         this.CbTIPO_CodMND.TiposTitulo = null;
         // 
         // PRO009MView
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(382, 157);
         this.Controls.Add(this.TLPanelDatos);
         this.Controls.Add(this.PCEncabezado);
         this.Controls.Add(this.panel3);
         this.Name = "PRO009MView";
         this.Text = "Cuentas Caja";
         this.panel3.ResumeLayout(false);
         this.panel3.PerformLayout();
         this.TLPanelDatos.ResumeLayout(false);
         this.TLPanelDatos.PerformLayout();
         ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private Infrastructure.WinFormsControls.PanelCaption PCEncabezado;
      private System.Windows.Forms.Panel panel3;
      private System.Windows.Forms.Button btnSalir;
      private System.Windows.Forms.Button btnGuardar;
      private System.Windows.Forms.TableLayoutPanel TLPanelDatos;
      private System.Windows.Forms.Label label9;
      private Controls.Tipos.ComboBoxTipos CbTIPO_CodBCO;
      private System.Windows.Forms.Label label4;
      private Controls.Tipos.ComboBoxTipos CbTIPO_CodMND;
      private System.Windows.Forms.Label label3;
      private System.Windows.Forms.TextBox txtCACU_NroCuenta;
      private System.Windows.Forms.ErrorProvider errorProvider1;
   }
}