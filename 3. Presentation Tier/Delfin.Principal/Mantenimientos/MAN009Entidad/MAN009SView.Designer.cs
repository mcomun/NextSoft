namespace Delfin.Principal.Mantenimientos.MAN009Entidad
{
    partial class MAN009SView
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
            this.pcTitleServicios = new Infrastructure.WinForms.Controls.PanelCaption();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.txtESER_Codigo = new System.Windows.Forms.TextBox();
            this.lblESER_Codigo = new System.Windows.Forms.Label();
            this.lblSERV_Codigo = new System.Windows.Forms.Label();
            this.aydSERV_Codigo = new Delfin.Controls.AyudaServicio();
            this.lblTIPO_CodMnd = new System.Windows.Forms.Label();
            this.cmbTIPO_CodMnd = new Delfin.Controls.Tipos.ComboBoxTipos();
            this.lblESER_Valor = new System.Windows.Forms.Label();
            this.txtESER_Valor = new Infrastructure.WinForms.Controls.TextBoxNumerico();
            this.lblCONS_CodBas = new System.Windows.Forms.Label();
            this.cmbCONS_CodBas = new Delfin.Controls.Tipos.ComboBoxConstantes();
            this.lblESER_Exonerado = new System.Windows.Forms.Label();
            this.chkESER_Exonerado = new System.Windows.Forms.CheckBox();
            this.errorProviderServicios = new System.Windows.Forms.ErrorProvider(this.components);
            this.panel3.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderServicios)).BeginInit();
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
            this.panel3.Size = new System.Drawing.Size(749, 50);
            this.panel3.TabIndex = 1;
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
            // pcTitleServicios
            // 
            this.pcTitleServicios.AllowActive = false;
            this.pcTitleServicios.AntiAlias = false;
            this.pcTitleServicios.Caption = "Servicios";
            this.pcTitleServicios.Dock = System.Windows.Forms.DockStyle.Top;
            this.pcTitleServicios.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
            this.pcTitleServicios.InactiveGradientHighColor = System.Drawing.Color.SteelBlue;
            this.pcTitleServicios.InactiveGradientLowColor = System.Drawing.Color.MidnightBlue;
            this.pcTitleServicios.Location = new System.Drawing.Point(0, 50);
            this.pcTitleServicios.Name = "pcTitleServicios";
            this.pcTitleServicios.Size = new System.Drawing.Size(749, 26);
            this.pcTitleServicios.TabIndex = 2;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.ColumnCount = 7;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.txtESER_Codigo, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblESER_Codigo, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblSERV_Codigo, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.aydSERV_Codigo, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblTIPO_CodMnd, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.cmbTIPO_CodMnd, 4, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblESER_Valor, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.txtESER_Valor, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.lblCONS_CodBas, 3, 2);
            this.tableLayoutPanel1.Controls.Add(this.cmbCONS_CodBas, 4, 2);
            this.tableLayoutPanel1.Controls.Add(this.lblESER_Exonerado, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.chkESER_Exonerado, 1, 3);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 76);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(749, 108);
            this.tableLayoutPanel1.TabIndex = 5;
            // 
            // txtESER_Codigo
            // 
            this.txtESER_Codigo.Location = new System.Drawing.Point(153, 3);
            this.txtESER_Codigo.Name = "txtESER_Codigo";
            this.txtESER_Codigo.ReadOnly = true;
            this.txtESER_Codigo.Size = new System.Drawing.Size(194, 20);
            this.txtESER_Codigo.TabIndex = 1;
            // 
            // lblESER_Codigo
            // 
            this.lblESER_Codigo.AutoSize = true;
            this.lblESER_Codigo.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblESER_Codigo.Location = new System.Drawing.Point(10, 7);
            this.lblESER_Codigo.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
            this.lblESER_Codigo.Name = "lblESER_Codigo";
            this.lblESER_Codigo.Size = new System.Drawing.Size(46, 13);
            this.lblESER_Codigo.TabIndex = 0;
            this.lblESER_Codigo.Text = "Código :";
            // 
            // lblSERV_Codigo
            // 
            this.lblSERV_Codigo.AutoSize = true;
            this.lblSERV_Codigo.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblSERV_Codigo.Location = new System.Drawing.Point(10, 34);
            this.lblSERV_Codigo.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
            this.lblSERV_Codigo.Name = "lblSERV_Codigo";
            this.lblSERV_Codigo.Size = new System.Drawing.Size(51, 13);
            this.lblSERV_Codigo.TabIndex = 0;
            this.lblSERV_Codigo.Text = "Servicio :";
            // 
            // aydSERV_Codigo
            // 
            this.aydSERV_Codigo.ActivarAyudaAuto = false;
            this.aydSERV_Codigo.EnabledAyuda = true;
            this.aydSERV_Codigo.EnabledAyudaButton = true;
            this.aydSERV_Codigo.EsFiltro = false;
            this.aydSERV_Codigo.Location = new System.Drawing.Point(153, 30);
            this.aydSERV_Codigo.LongitudAceptada = 0;
            this.aydSERV_Codigo.MyInstanciaAyuda = Infrastructure.WinForms.Controls.TextBoxAyuda.InstanciaAyuda.Habilitado;
            this.aydSERV_Codigo.Name = "aydSERV_Codigo";
            this.aydSERV_Codigo.RellenaCeros = false;
            this.aydSERV_Codigo.Size = new System.Drawing.Size(194, 20);
            this.aydSERV_Codigo.TabIndex = 8;
            this.aydSERV_Codigo.Tipo = Infrastructure.WinForms.Controls.TextBoxAyuda.TipoTextBoxAyuda.Numerico;
            this.aydSERV_Codigo.TipoAyudaServicio = Delfin.Controls.AyudaServicio.TipoAyuda.Codigo;
            this.aydSERV_Codigo.Value = null;
            // 
            // lblTIPO_CodMnd
            // 
            this.lblTIPO_CodMnd.AutoSize = true;
            this.lblTIPO_CodMnd.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblTIPO_CodMnd.Location = new System.Drawing.Point(375, 34);
            this.lblTIPO_CodMnd.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
            this.lblTIPO_CodMnd.Name = "lblTIPO_CodMnd";
            this.lblTIPO_CodMnd.Size = new System.Drawing.Size(52, 13);
            this.lblTIPO_CodMnd.TabIndex = 0;
            this.lblTIPO_CodMnd.Text = "Moneda :";
            // 
            // cmbTIPO_CodMnd
            // 
            this.cmbTIPO_CodMnd.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTIPO_CodMnd.FormattingEnabled = true;
            this.cmbTIPO_CodMnd.Location = new System.Drawing.Point(518, 30);
            this.cmbTIPO_CodMnd.Name = "cmbTIPO_CodMnd";
            this.cmbTIPO_CodMnd.Session = null;
            this.cmbTIPO_CodMnd.Size = new System.Drawing.Size(194, 21);
            this.cmbTIPO_CodMnd.TabIndex = 9;
            this.cmbTIPO_CodMnd.TiposSelectedItem = null;
            this.cmbTIPO_CodMnd.TiposSelectedValue = null;
            this.cmbTIPO_CodMnd.TiposTitulo = null;
            // 
            // lblESER_Valor
            // 
            this.lblESER_Valor.AutoSize = true;
            this.lblESER_Valor.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblESER_Valor.Location = new System.Drawing.Point(10, 61);
            this.lblESER_Valor.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
            this.lblESER_Valor.Name = "lblESER_Valor";
            this.lblESER_Valor.Size = new System.Drawing.Size(37, 13);
            this.lblESER_Valor.TabIndex = 0;
            this.lblESER_Valor.Text = "Valor :";
            // 
            // txtESER_Valor
            // 
            this.txtESER_Valor.BaseTipo = Infrastructure.WinForms.Controls.EstandaresFormato.Ninguno;
            this.txtESER_Valor.Decimales = 2;
            this.txtESER_Valor.Enteros = 9;
            this.txtESER_Valor.Formato = "###,###,##0.00";
            this.txtESER_Valor.Location = new System.Drawing.Point(153, 57);
            this.txtESER_Valor.MaxLength = 11;
            this.txtESER_Valor.Name = "txtESER_Valor";
            this.txtESER_Valor.Negativo = true;
            this.txtESER_Valor.SinFormato = false;
            this.txtESER_Valor.Size = new System.Drawing.Size(194, 20);
            this.txtESER_Valor.TabIndex = 10;
            this.txtESER_Valor.Text = "0.00";
            this.txtESER_Valor.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtESER_Valor.Value = new decimal(new int[] {
            0,
            0,
            0,
            131072});
            // 
            // lblCONS_CodBas
            // 
            this.lblCONS_CodBas.AutoSize = true;
            this.lblCONS_CodBas.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblCONS_CodBas.Location = new System.Drawing.Point(375, 61);
            this.lblCONS_CodBas.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
            this.lblCONS_CodBas.Name = "lblCONS_CodBas";
            this.lblCONS_CodBas.Size = new System.Drawing.Size(90, 13);
            this.lblCONS_CodBas.TabIndex = 0;
            this.lblCONS_CodBas.Text = "Base de Cálculo :";
            // 
            // cmbCONS_CodBas
            // 
            this.cmbCONS_CodBas.ConstantesSelectedItem = null;
            this.cmbCONS_CodBas.ConstantesSelectedValue = null;
            this.cmbCONS_CodBas.ConstantesTitulo = null;
            this.cmbCONS_CodBas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCONS_CodBas.FormattingEnabled = true;
            this.cmbCONS_CodBas.Location = new System.Drawing.Point(518, 57);
            this.cmbCONS_CodBas.Name = "cmbCONS_CodBas";
            this.cmbCONS_CodBas.Session = null;
            this.cmbCONS_CodBas.Size = new System.Drawing.Size(194, 21);
            this.cmbCONS_CodBas.TabIndex = 11;
            // 
            // lblESER_Exonerado
            // 
            this.lblESER_Exonerado.AutoSize = true;
            this.lblESER_Exonerado.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblESER_Exonerado.Location = new System.Drawing.Point(10, 88);
            this.lblESER_Exonerado.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
            this.lblESER_Exonerado.Name = "lblESER_Exonerado";
            this.lblESER_Exonerado.Size = new System.Drawing.Size(58, 13);
            this.lblESER_Exonerado.TabIndex = 0;
            this.lblESER_Exonerado.Text = "Exonerdo :";
            // 
            // chkESER_Exonerado
            // 
            this.chkESER_Exonerado.AutoSize = true;
            this.chkESER_Exonerado.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkESER_Exonerado.Location = new System.Drawing.Point(153, 84);
            this.chkESER_Exonerado.Name = "chkESER_Exonerado";
            this.chkESER_Exonerado.Size = new System.Drawing.Size(194, 21);
            this.chkESER_Exonerado.TabIndex = 12;
            this.chkESER_Exonerado.UseVisualStyleBackColor = true;
            // 
            // errorProviderServicios
            // 
            this.errorProviderServicios.ContainerControl = this;
            // 
            // MAN009SView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(749, 239);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.pcTitleServicios);
            this.Controls.Add(this.panel3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "MAN009SView";
            this.Text = "Servicos";
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderServicios)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Button btnGuardar;
        private Infrastructure.WinForms.Controls.PanelCaption pcTitleServicios;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TextBox txtESER_Codigo;
        private System.Windows.Forms.Label lblESER_Codigo;
        private System.Windows.Forms.Label lblSERV_Codigo;
        private Controls.AyudaServicio aydSERV_Codigo;
        private System.Windows.Forms.Label lblTIPO_CodMnd;
        private Controls.Tipos.ComboBoxTipos cmbTIPO_CodMnd;
        private System.Windows.Forms.Label lblESER_Valor;
        private Infrastructure.WinForms.Controls.TextBoxNumerico txtESER_Valor;
        private System.Windows.Forms.Label lblCONS_CodBas;
        private Controls.Tipos.ComboBoxConstantes cmbCONS_CodBas;
        private System.Windows.Forms.Label lblESER_Exonerado;
        private System.Windows.Forms.CheckBox chkESER_Exonerado;
        private System.Windows.Forms.ErrorProvider errorProviderServicios;
    }
}