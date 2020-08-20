namespace Delfin.Principal
{
   partial class MAN016FlujosMView
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
            this.btnSalir = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.errorProviderCab_Cotizacion_OV = new System.Windows.Forms.ErrorProvider(this.components);
            this.errorProviderDet_Cotizacion_OV_Novedad = new System.Windows.Forms.ErrorProvider(this.components);
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.errorEventoTarea = new System.Windows.Forms.ErrorProvider(this.components);
            this.panelCaption1 = new Infrastructure.WinForms.Controls.PanelCaption();
            this.tableDatosGenerales = new System.Windows.Forms.TableLayoutPanel();
            this.cmbFLUJ_TipoMovimiento = new Delfin.Controls.Tipos.ComboBoxConstantes();
            this.cmbFLUJ_TipoFlujo = new Delfin.Controls.Tipos.ComboBoxConstantes();
            this.txtFLUJ_Glosa = new System.Windows.Forms.TextBox();
            this.txtFLUJ_Codigo = new System.Windows.Forms.TextBox();
            this.lblFLUJ_TipoMovimiento = new System.Windows.Forms.Label();
            this.lblFLUJ_TipoFlujo = new System.Windows.Forms.Label();
            this.lblFLUJ_Glosa = new System.Windows.Forms.Label();
            this.lblFLUJ_Codigo = new System.Windows.Forms.Label();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderCab_Cotizacion_OV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderDet_Cotizacion_OV_Novedad)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorEventoTarea)).BeginInit();
            this.tableDatosGenerales.SuspendLayout();
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
            this.panel3.Size = new System.Drawing.Size(735, 50);
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
            // panelCaption1
            // 
            this.panelCaption1.AllowActive = false;
            this.panelCaption1.AntiAlias = false;
            this.panelCaption1.Caption = "Datos Generales";
            this.panelCaption1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelCaption1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
            this.panelCaption1.InactiveGradientHighColor = System.Drawing.Color.SteelBlue;
            this.panelCaption1.InactiveGradientLowColor = System.Drawing.Color.MidnightBlue;
            this.panelCaption1.Location = new System.Drawing.Point(0, 50);
            this.panelCaption1.Name = "panelCaption1";
            this.panelCaption1.Size = new System.Drawing.Size(735, 26);
            this.panelCaption1.TabIndex = 2;
            // 
            // tableDatosGenerales
            // 
            this.tableDatosGenerales.AutoSize = true;
            this.tableDatosGenerales.ColumnCount = 7;
            this.tableDatosGenerales.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tableDatosGenerales.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.tableDatosGenerales.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.tableDatosGenerales.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tableDatosGenerales.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.tableDatosGenerales.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.tableDatosGenerales.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tableDatosGenerales.Controls.Add(this.cmbFLUJ_TipoMovimiento, 4, 2);
            this.tableDatosGenerales.Controls.Add(this.cmbFLUJ_TipoFlujo, 1, 2);
            this.tableDatosGenerales.Controls.Add(this.txtFLUJ_Glosa, 1, 1);
            this.tableDatosGenerales.Controls.Add(this.txtFLUJ_Codigo, 1, 0);
            this.tableDatosGenerales.Controls.Add(this.lblFLUJ_TipoMovimiento, 3, 2);
            this.tableDatosGenerales.Controls.Add(this.lblFLUJ_TipoFlujo, 0, 2);
            this.tableDatosGenerales.Controls.Add(this.lblFLUJ_Glosa, 0, 1);
            this.tableDatosGenerales.Controls.Add(this.lblFLUJ_Codigo, 0, 0);
            this.tableDatosGenerales.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableDatosGenerales.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
            this.tableDatosGenerales.Location = new System.Drawing.Point(0, 76);
            this.tableDatosGenerales.Name = "tableDatosGenerales";
            this.tableDatosGenerales.RowCount = 4;
            this.tableDatosGenerales.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableDatosGenerales.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableDatosGenerales.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableDatosGenerales.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableDatosGenerales.Size = new System.Drawing.Size(735, 108);
            this.tableDatosGenerales.TabIndex = 3;
            // 
            // cmbFLUJ_TipoMovimiento
            // 
            this.cmbFLUJ_TipoMovimiento.ConstantesSelectedItem = null;
            this.cmbFLUJ_TipoMovimiento.ConstantesSelectedValue = null;
            this.cmbFLUJ_TipoMovimiento.ConstantesTitulo = null;
            this.cmbFLUJ_TipoMovimiento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFLUJ_TipoMovimiento.FormattingEnabled = true;
            this.cmbFLUJ_TipoMovimiento.Location = new System.Drawing.Point(518, 57);
            this.cmbFLUJ_TipoMovimiento.Name = "cmbFLUJ_TipoMovimiento";
            this.cmbFLUJ_TipoMovimiento.Size = new System.Drawing.Size(194, 21);
            this.cmbFLUJ_TipoMovimiento.TabIndex = 7;
            // 
            // cmbFLUJ_TipoFlujo
            // 
            this.cmbFLUJ_TipoFlujo.ConstantesSelectedItem = null;
            this.cmbFLUJ_TipoFlujo.ConstantesSelectedValue = null;
            this.cmbFLUJ_TipoFlujo.ConstantesTitulo = null;
            this.cmbFLUJ_TipoFlujo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFLUJ_TipoFlujo.FormattingEnabled = true;
            this.cmbFLUJ_TipoFlujo.Location = new System.Drawing.Point(153, 57);
            this.cmbFLUJ_TipoFlujo.Name = "cmbFLUJ_TipoFlujo";
            this.cmbFLUJ_TipoFlujo.Size = new System.Drawing.Size(194, 21);
            this.cmbFLUJ_TipoFlujo.TabIndex = 5;
            // 
            // txtFLUJ_Glosa
            // 
            this.tableDatosGenerales.SetColumnSpan(this.txtFLUJ_Glosa, 4);
            this.txtFLUJ_Glosa.Location = new System.Drawing.Point(153, 30);
            this.txtFLUJ_Glosa.Name = "txtFLUJ_Glosa";
            this.txtFLUJ_Glosa.Size = new System.Drawing.Size(559, 20);
            this.txtFLUJ_Glosa.TabIndex = 3;
            // 
            // txtFLUJ_Codigo
            // 
            this.txtFLUJ_Codigo.Enabled = false;
            this.txtFLUJ_Codigo.Location = new System.Drawing.Point(153, 3);
            this.txtFLUJ_Codigo.Name = "txtFLUJ_Codigo";
            this.txtFLUJ_Codigo.Size = new System.Drawing.Size(194, 20);
            this.txtFLUJ_Codigo.TabIndex = 1;
            // 
            // lblFLUJ_TipoMovimiento
            // 
            this.lblFLUJ_TipoMovimiento.AutoSize = true;
            this.lblFLUJ_TipoMovimiento.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFLUJ_TipoMovimiento.Location = new System.Drawing.Point(375, 61);
            this.lblFLUJ_TipoMovimiento.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
            this.lblFLUJ_TipoMovimiento.Name = "lblFLUJ_TipoMovimiento";
            this.lblFLUJ_TipoMovimiento.Size = new System.Drawing.Size(113, 13);
            this.lblFLUJ_TipoMovimiento.TabIndex = 6;
            this.lblFLUJ_TipoMovimiento.Text = "Tipo Movimiento : ";
            // 
            // lblFLUJ_TipoFlujo
            // 
            this.lblFLUJ_TipoFlujo.AutoSize = true;
            this.lblFLUJ_TipoFlujo.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFLUJ_TipoFlujo.Location = new System.Drawing.Point(10, 61);
            this.lblFLUJ_TipoFlujo.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
            this.lblFLUJ_TipoFlujo.Name = "lblFLUJ_TipoFlujo";
            this.lblFLUJ_TipoFlujo.Size = new System.Drawing.Size(71, 13);
            this.lblFLUJ_TipoFlujo.TabIndex = 4;
            this.lblFLUJ_TipoFlujo.Text = "Tipo Flujo :";
            // 
            // lblFLUJ_Glosa
            // 
            this.lblFLUJ_Glosa.AutoSize = true;
            this.lblFLUJ_Glosa.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFLUJ_Glosa.Location = new System.Drawing.Point(10, 34);
            this.lblFLUJ_Glosa.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
            this.lblFLUJ_Glosa.Name = "lblFLUJ_Glosa";
            this.lblFLUJ_Glosa.Size = new System.Drawing.Size(48, 13);
            this.lblFLUJ_Glosa.TabIndex = 2;
            this.lblFLUJ_Glosa.Text = "Glosa :";
            // 
            // lblFLUJ_Codigo
            // 
            this.lblFLUJ_Codigo.AutoSize = true;
            this.lblFLUJ_Codigo.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFLUJ_Codigo.Location = new System.Drawing.Point(10, 7);
            this.lblFLUJ_Codigo.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
            this.lblFLUJ_Codigo.Name = "lblFLUJ_Codigo";
            this.lblFLUJ_Codigo.Size = new System.Drawing.Size(56, 13);
            this.lblFLUJ_Codigo.TabIndex = 0;
            this.lblFLUJ_Codigo.Text = "Código :";
            // 
            // MAN016FlujosMView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.CancelButton = this.btnSalir;
            this.ClientSize = new System.Drawing.Size(735, 170);
            this.Controls.Add(this.tableDatosGenerales);
            this.Controls.Add(this.panelCaption1);
            this.Controls.Add(this.panel3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MAN016FlujosMView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Flujos";
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderCab_Cotizacion_OV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderDet_Cotizacion_OV_Novedad)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorEventoTarea)).EndInit();
            this.tableDatosGenerales.ResumeLayout(false);
            this.tableDatosGenerales.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

      }



      #endregion

      private System.Windows.Forms.Panel panel3;
      private System.Windows.Forms.Button btnSalir;
      private System.Windows.Forms.Button btnGuardar;
      private System.Windows.Forms.ErrorProvider errorProviderCab_Cotizacion_OV;
      private System.Windows.Forms.ErrorProvider errorProviderDet_Cotizacion_OV_Novedad;
      private System.Windows.Forms.ToolTip toolTip1;
      private System.Windows.Forms.ErrorProvider errorEventoTarea;
      private System.Windows.Forms.TableLayoutPanel tableDatosGenerales;
      private Controls.Tipos.ComboBoxConstantes cmbFLUJ_TipoMovimiento;
      private Controls.Tipos.ComboBoxConstantes cmbFLUJ_TipoFlujo;
      private System.Windows.Forms.TextBox txtFLUJ_Glosa;
      private System.Windows.Forms.TextBox txtFLUJ_Codigo;
      private System.Windows.Forms.Label lblFLUJ_TipoMovimiento;
      private System.Windows.Forms.Label lblFLUJ_TipoFlujo;
      private System.Windows.Forms.Label lblFLUJ_Glosa;
      private System.Windows.Forms.Label lblFLUJ_Codigo;
      private Infrastructure.WinForms.Controls.PanelCaption panelCaption1;
   }
}