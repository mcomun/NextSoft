namespace Delfin.Principal
{
   partial class OPE002View
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
            this.btnCargar = new System.Windows.Forms.Button();
            this.errorProviderCab_Cotizacion_OV = new System.Windows.Forms.ErrorProvider(this.components);
            this.errorProviderDet_Cotizacion_OV_Novedad = new System.Windows.Forms.ErrorProvider(this.components);
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.errorEventoTarea = new System.Windows.Forms.ErrorProvider(this.components);
            this.tableDatosGenerales = new System.Windows.Forms.TableLayoutPanel();
            this.txaNVIA_Codigo = new Delfin.Controls.AyudaViaje();
            this.label1 = new System.Windows.Forms.Label();
            this.label36 = new System.Windows.Forms.Label();
            this.txtENTC_NomTransportista = new System.Windows.Forms.TextBox();
            this.lblTIPO_CodTRF = new System.Windows.Forms.Label();
            this.cmbTIPO_CodTRF = new Delfin.Controls.Tipos.ComboBoxTipos();
            this.lblNAVE_Nombre = new System.Windows.Forms.Label();
            this.txtNAVE_Nombre = new System.Windows.Forms.TextBox();
            this.txaNVIA_NroViaje = new Delfin.Controls.AyudaViaje();
            this.lblNVIA_NroViaje = new System.Windows.Forms.Label();
            this.lblCheckControl = new System.Windows.Forms.Label();
            this.chkChangeControl = new System.Windows.Forms.CheckBox();
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
            this.panel3.Controls.Add(this.btnCargar);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(737, 50);
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
            this.tableDatosGenerales.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableDatosGenerales.Controls.Add(this.txaNVIA_Codigo, 1, 0);
            this.tableDatosGenerales.Controls.Add(this.label1, 0, 0);
            this.tableDatosGenerales.Controls.Add(this.label36, 0, 2);
            this.tableDatosGenerales.Controls.Add(this.txtENTC_NomTransportista, 1, 2);
            this.tableDatosGenerales.Controls.Add(this.lblTIPO_CodTRF, 3, 2);
            this.tableDatosGenerales.Controls.Add(this.cmbTIPO_CodTRF, 4, 2);
            this.tableDatosGenerales.Controls.Add(this.lblNAVE_Nombre, 3, 1);
            this.tableDatosGenerales.Controls.Add(this.txtNAVE_Nombre, 4, 1);
            this.tableDatosGenerales.Controls.Add(this.txaNVIA_NroViaje, 1, 1);
            this.tableDatosGenerales.Controls.Add(this.lblNVIA_NroViaje, 0, 1);
            this.tableDatosGenerales.Controls.Add(this.lblCheckControl, 3, 0);
            this.tableDatosGenerales.Controls.Add(this.chkChangeControl, 4, 0);
            this.tableDatosGenerales.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableDatosGenerales.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
            this.tableDatosGenerales.Location = new System.Drawing.Point(0, 50);
            this.tableDatosGenerales.Name = "tableDatosGenerales";
            this.tableDatosGenerales.RowCount = 3;
            this.tableDatosGenerales.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableDatosGenerales.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableDatosGenerales.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableDatosGenerales.Size = new System.Drawing.Size(737, 81);
            this.tableDatosGenerales.TabIndex = 1;
            // 
            // txaNVIA_Codigo
            // 
            this.txaNVIA_Codigo.ActivarAyudaAuto = false;
            this.txaNVIA_Codigo.EMPR_Codigo = ((short)(0));
            this.txaNVIA_Codigo.EnabledAyuda = true;
            this.txaNVIA_Codigo.EnabledAyudaButton = true;
            this.txaNVIA_Codigo.ENTC_CodTranportista = null;
            this.txaNVIA_Codigo.EsFiltro = false;
            this.txaNVIA_Codigo.Location = new System.Drawing.Point(153, 3);
            this.txaNVIA_Codigo.LongitudAceptada = 0;
            this.txaNVIA_Codigo.MyInstanciaAyuda = Infrastructure.WinForms.Controls.TextBoxAyuda.InstanciaAyuda.Habilitado;
            this.txaNVIA_Codigo.Name = "txaNVIA_Codigo";
            this.txaNVIA_Codigo.RellenaCeros = false;
            this.txaNVIA_Codigo.Size = new System.Drawing.Size(194, 20);
            this.txaNVIA_Codigo.SUCR_Codigo = ((short)(0));
            this.txaNVIA_Codigo.TabIndex = 71;
            this.txaNVIA_Codigo.Tipo = Infrastructure.WinForms.Controls.TextBoxAyuda.TipoTextBoxAyuda.Numerico;
            this.txaNVIA_Codigo.TipoAyudaNaveViaje = Delfin.Controls.AyudaViaje.TipoAyuda.Codigo;
            this.txaNVIA_Codigo.Value = null;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(10, 7);
            this.label1.Margin = new System.Windows.Forms.Padding(10, 7, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 70;
            this.label1.Text = "Viaje:";
            // 
            // label36
            // 
            this.label36.AutoSize = true;
            this.label36.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label36.Location = new System.Drawing.Point(10, 61);
            this.label36.Margin = new System.Windows.Forms.Padding(10, 7, 2, 0);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(42, 13);
            this.label36.TabIndex = 65;
            this.label36.Text = "Línea:";
            // 
            // txtENTC_NomTransportista
            // 
            this.txtENTC_NomTransportista.Location = new System.Drawing.Point(152, 57);
            this.txtENTC_NomTransportista.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtENTC_NomTransportista.Name = "txtENTC_NomTransportista";
            this.txtENTC_NomTransportista.ReadOnly = true;
            this.txtENTC_NomTransportista.Size = new System.Drawing.Size(196, 20);
            this.txtENTC_NomTransportista.TabIndex = 67;
            this.txtENTC_NomTransportista.Tag = "";
            // 
            // lblTIPO_CodTRF
            // 
            this.lblTIPO_CodTRF.AutoSize = true;
            this.lblTIPO_CodTRF.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTIPO_CodTRF.Location = new System.Drawing.Point(375, 61);
            this.lblTIPO_CodTRF.Margin = new System.Windows.Forms.Padding(10, 7, 2, 0);
            this.lblTIPO_CodTRF.Name = "lblTIPO_CodTRF";
            this.lblTIPO_CodTRF.Size = new System.Drawing.Size(50, 13);
            this.lblTIPO_CodTRF.TabIndex = 63;
            this.lblTIPO_CodTRF.Text = "Tráfico:";
            // 
            // cmbTIPO_CodTRF
            // 
            this.cmbTIPO_CodTRF.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTIPO_CodTRF.Enabled = false;
            this.cmbTIPO_CodTRF.FormattingEnabled = true;
            this.cmbTIPO_CodTRF.Location = new System.Drawing.Point(518, 57);
            this.cmbTIPO_CodTRF.Name = "cmbTIPO_CodTRF";
            this.cmbTIPO_CodTRF.Session = null;
            this.cmbTIPO_CodTRF.Size = new System.Drawing.Size(193, 21);
            this.cmbTIPO_CodTRF.TabIndex = 64;
            this.cmbTIPO_CodTRF.TiposSelectedItem = null;
            this.cmbTIPO_CodTRF.TiposSelectedValue = null;
            this.cmbTIPO_CodTRF.TiposTitulo = null;
            // 
            // lblNAVE_Nombre
            // 
            this.lblNAVE_Nombre.AutoSize = true;
            this.lblNAVE_Nombre.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNAVE_Nombre.Location = new System.Drawing.Point(375, 34);
            this.lblNAVE_Nombre.Margin = new System.Windows.Forms.Padding(10, 7, 2, 0);
            this.lblNAVE_Nombre.Name = "lblNAVE_Nombre";
            this.lblNAVE_Nombre.Size = new System.Drawing.Size(41, 13);
            this.lblNAVE_Nombre.TabIndex = 60;
            this.lblNAVE_Nombre.Text = "Nave:";
            // 
            // txtNAVE_Nombre
            // 
            this.txtNAVE_Nombre.Location = new System.Drawing.Point(517, 30);
            this.txtNAVE_Nombre.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtNAVE_Nombre.Name = "txtNAVE_Nombre";
            this.txtNAVE_Nombre.ReadOnly = true;
            this.txtNAVE_Nombre.Size = new System.Drawing.Size(196, 20);
            this.txtNAVE_Nombre.TabIndex = 69;
            this.txtNAVE_Nombre.Tag = "";
            // 
            // txaNVIA_NroViaje
            // 
            this.txaNVIA_NroViaje.ActivarAyudaAuto = false;
            this.txaNVIA_NroViaje.EMPR_Codigo = ((short)(0));
            this.txaNVIA_NroViaje.EnabledAyuda = true;
            this.txaNVIA_NroViaje.EnabledAyudaButton = true;
            this.txaNVIA_NroViaje.ENTC_CodTranportista = null;
            this.txaNVIA_NroViaje.EsFiltro = false;
            this.txaNVIA_NroViaje.Location = new System.Drawing.Point(153, 30);
            this.txaNVIA_NroViaje.LongitudAceptada = 0;
            this.txaNVIA_NroViaje.MyInstanciaAyuda = Infrastructure.WinForms.Controls.TextBoxAyuda.InstanciaAyuda.Habilitado;
            this.txaNVIA_NroViaje.Name = "txaNVIA_NroViaje";
            this.txaNVIA_NroViaje.RellenaCeros = false;
            this.txaNVIA_NroViaje.Size = new System.Drawing.Size(194, 20);
            this.txaNVIA_NroViaje.SUCR_Codigo = ((short)(0));
            this.txaNVIA_NroViaje.TabIndex = 68;
            this.txaNVIA_NroViaje.Tipo = Infrastructure.WinForms.Controls.TextBoxAyuda.TipoTextBoxAyuda.AlfaNumerico;
            this.txaNVIA_NroViaje.TipoAyudaNaveViaje = Delfin.Controls.AyudaViaje.TipoAyuda.NroViaje;
            this.txaNVIA_NroViaje.Value = null;
            // 
            // lblNVIA_NroViaje
            // 
            this.lblNVIA_NroViaje.AutoSize = true;
            this.lblNVIA_NroViaje.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNVIA_NroViaje.Location = new System.Drawing.Point(10, 34);
            this.lblNVIA_NroViaje.Margin = new System.Windows.Forms.Padding(10, 7, 2, 0);
            this.lblNVIA_NroViaje.Name = "lblNVIA_NroViaje";
            this.lblNVIA_NroViaje.Size = new System.Drawing.Size(65, 13);
            this.lblNVIA_NroViaje.TabIndex = 61;
            this.lblNVIA_NroViaje.Text = "Nro Viaje:";
            // 
            // lblCheckControl
            // 
            this.lblCheckControl.AutoSize = true;
            this.lblCheckControl.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCheckControl.Location = new System.Drawing.Point(375, 7);
            this.lblCheckControl.Margin = new System.Windows.Forms.Padding(10, 7, 2, 0);
            this.lblCheckControl.Name = "lblCheckControl";
            this.lblCheckControl.Size = new System.Drawing.Size(102, 13);
            this.lblCheckControl.TabIndex = 72;
            this.lblCheckControl.Text = "Change Control:";
            // 
            // chkChangeControl
            // 
            this.chkChangeControl.AutoSize = true;
            this.chkChangeControl.Location = new System.Drawing.Point(518, 7);
            this.chkChangeControl.Margin = new System.Windows.Forms.Padding(3, 7, 3, 3);
            this.chkChangeControl.Name = "chkChangeControl";
            this.chkChangeControl.Size = new System.Drawing.Size(15, 14);
            this.chkChangeControl.TabIndex = 73;
            this.chkChangeControl.UseVisualStyleBackColor = true;
            // 
            // OPE002View
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.CancelButton = this.btnSalir;
            this.ClientSize = new System.Drawing.Size(737, 139);
            this.Controls.Add(this.tableDatosGenerales);
            this.Controls.Add(this.panel3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "OPE002View";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "STATEMENT";
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
      private System.Windows.Forms.Button btnCargar;
      private System.Windows.Forms.ErrorProvider errorProviderCab_Cotizacion_OV;
      private System.Windows.Forms.ErrorProvider errorProviderDet_Cotizacion_OV_Novedad;
      private System.Windows.Forms.ToolTip toolTip1;
      private System.Windows.Forms.ErrorProvider errorEventoTarea;
      private System.Windows.Forms.TableLayoutPanel tableDatosGenerales;
      private System.Windows.Forms.Label lblTIPO_CodTRF;
      private System.Windows.Forms.Label label36;
      private Controls.Tipos.ComboBoxTipos cmbTIPO_CodTRF;
      private System.Windows.Forms.TextBox txtENTC_NomTransportista;
      private System.Windows.Forms.Label lblNVIA_NroViaje;
      private System.Windows.Forms.Label lblNAVE_Nombre;
      private Controls.AyudaViaje txaNVIA_Codigo;
      private System.Windows.Forms.Label label1;
      private System.Windows.Forms.TextBox txtNAVE_Nombre;
      private Controls.AyudaViaje txaNVIA_NroViaje;
      private System.Windows.Forms.Label lblCheckControl;
      private System.Windows.Forms.CheckBox chkChangeControl;
   }
}