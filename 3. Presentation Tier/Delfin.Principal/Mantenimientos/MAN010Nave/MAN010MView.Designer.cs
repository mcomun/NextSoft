namespace Delfin.Principal
{
    partial class MAN010MView
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
            this.NAVE_Codigo = new Infrastructure.WinForms.Controls.TextBoxNumerico();
            this.NAVE_Nombre = new System.Windows.Forms.TextBox();
            this.lblNAVE_Codigo = new System.Windows.Forms.Label();
            this.lblCONS_CodVia = new System.Windows.Forms.Label();
            this.panelCaption1 = new Infrastructure.WinForms.Controls.PanelCaption();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnMAN_salir = new System.Windows.Forms.Button();
            this.btnMAN_guardar = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.CONS_CodVia = new Delfin.Controls.Tipos.ComboBoxConstantes();
            this.lblNAVE_Nombre = new System.Windows.Forms.Label();
            this.lblNAVE_Matricula = new System.Windows.Forms.Label();
            this.NAVE_Matricula = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.CONS_CodEnt = new Delfin.Controls.Tipos.ComboBoxConstantes();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // NAVE_Codigo
            // 
            this.NAVE_Codigo.BaseTipo = Infrastructure.WinForms.Controls.EstandaresFormato.General;
            this.NAVE_Codigo.Decimales = 0;
            this.NAVE_Codigo.Enteros = 11;
            this.NAVE_Codigo.Formato = "##,###,###,##0.";
            this.NAVE_Codigo.Location = new System.Drawing.Point(153, 3);
            this.NAVE_Codigo.MaxLength = 12;
            this.NAVE_Codigo.Name = "NAVE_Codigo";
            this.NAVE_Codigo.Negativo = true;
            this.NAVE_Codigo.ReadOnly = true;
            this.NAVE_Codigo.SinFormato = true;
            this.NAVE_Codigo.Size = new System.Drawing.Size(194, 20);
            this.NAVE_Codigo.TabIndex = 2;
            this.NAVE_Codigo.Tag = "PUER_CodigoMSGERROR";
            this.NAVE_Codigo.Text = "0";
            this.NAVE_Codigo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.NAVE_Codigo.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // NAVE_Nombre
            // 
            this.tableLayoutPanel2.SetColumnSpan(this.NAVE_Nombre, 4);
            this.NAVE_Nombre.Location = new System.Drawing.Point(153, 30);
            this.NAVE_Nombre.Name = "NAVE_Nombre";
            this.NAVE_Nombre.Size = new System.Drawing.Size(566, 20);
            this.NAVE_Nombre.TabIndex = 4;
            this.NAVE_Nombre.Tag = "PUER_NombreMSGERROR";
            // 
            // lblNAVE_Codigo
            // 
            this.lblNAVE_Codigo.AutoSize = true;
            this.lblNAVE_Codigo.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNAVE_Codigo.Location = new System.Drawing.Point(10, 7);
            this.lblNAVE_Codigo.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
            this.lblNAVE_Codigo.Name = "lblNAVE_Codigo";
            this.lblNAVE_Codigo.Size = new System.Drawing.Size(52, 13);
            this.lblNAVE_Codigo.TabIndex = 1;
            this.lblNAVE_Codigo.Text = "Codigo:";
            // 
            // lblCONS_CodVia
            // 
            this.lblCONS_CodVia.AutoSize = true;
            this.lblCONS_CodVia.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCONS_CodVia.Location = new System.Drawing.Point(375, 7);
            this.lblCONS_CodVia.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
            this.lblCONS_CodVia.Name = "lblCONS_CodVia";
            this.lblCONS_CodVia.Size = new System.Drawing.Size(58, 13);
            this.lblCONS_CodVia.TabIndex = 5;
            this.lblCONS_CodVia.Text = "Tipo Vía:";
            // 
            // panelCaption1
            // 
            this.panelCaption1.AllowActive = false;
            this.panelCaption1.AntiAlias = false;
            this.panelCaption1.Caption = "Datos de la Nave";
            this.panelCaption1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelCaption1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
            this.panelCaption1.InactiveGradientHighColor = System.Drawing.Color.SteelBlue;
            this.panelCaption1.InactiveGradientLowColor = System.Drawing.Color.MidnightBlue;
            this.panelCaption1.Location = new System.Drawing.Point(0, 50);
            this.panelCaption1.Name = "panelCaption1";
            this.panelCaption1.Size = new System.Drawing.Size(735, 26);
            this.panelCaption1.TabIndex = 2;
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
            this.panel3.TabIndex = 3;
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
            this.btnMAN_salir.TabIndex = 8;
            this.btnMAN_salir.Text = "&Salir";
            this.btnMAN_salir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnMAN_salir.UseVisualStyleBackColor = true;
            // 
            // btnMAN_guardar
            // 
            this.btnMAN_guardar.AutoSize = true;
            this.btnMAN_guardar.DialogResult = System.Windows.Forms.DialogResult.OK;
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
            this.btnMAN_guardar.TabIndex = 7;
            this.btnMAN_guardar.Text = "&Guardar";
            this.btnMAN_guardar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnMAN_guardar.UseVisualStyleBackColor = true;
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
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 207F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 8F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.Controls.Add(this.lblNAVE_Codigo, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.NAVE_Codigo, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.NAVE_Nombre, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.lblCONS_CodVia, 3, 0);
            this.tableLayoutPanel2.Controls.Add(this.CONS_CodVia, 4, 0);
            this.tableLayoutPanel2.Controls.Add(this.lblNAVE_Nombre, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.lblNAVE_Matricula, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.NAVE_Matricula, 1, 2);
            this.tableLayoutPanel2.Controls.Add(this.label1, 3, 2);
            this.tableLayoutPanel2.Controls.Add(this.CONS_CodEnt, 4, 2);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 76);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 3;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(735, 81);
            this.tableLayoutPanel2.TabIndex = 4;
            // 
            // CONS_CodVia
            // 
            this.CONS_CodVia.ConstantesSelectedItem = null;
            this.CONS_CodVia.ConstantesSelectedValue = null;
            this.CONS_CodVia.ConstantesTitulo = null;
            this.CONS_CodVia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CONS_CodVia.FormattingEnabled = true;
            this.CONS_CodVia.Location = new System.Drawing.Point(518, 3);
            this.CONS_CodVia.Name = "CONS_CodVia";
            this.CONS_CodVia.Session = null;
            this.CONS_CodVia.Size = new System.Drawing.Size(201, 21);
            this.CONS_CodVia.TabIndex = 6;
            this.CONS_CodVia.Tag = "CONS_CodViaMSGERROR";
            // 
            // lblNAVE_Nombre
            // 
            this.lblNAVE_Nombre.AutoSize = true;
            this.lblNAVE_Nombre.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNAVE_Nombre.Location = new System.Drawing.Point(10, 34);
            this.lblNAVE_Nombre.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
            this.lblNAVE_Nombre.Name = "lblNAVE_Nombre";
            this.lblNAVE_Nombre.Size = new System.Drawing.Size(57, 13);
            this.lblNAVE_Nombre.TabIndex = 3;
            this.lblNAVE_Nombre.Text = "Nombre:";
            // 
            // lblNAVE_Matricula
            // 
            this.lblNAVE_Matricula.AutoSize = true;
            this.lblNAVE_Matricula.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNAVE_Matricula.Location = new System.Drawing.Point(10, 61);
            this.lblNAVE_Matricula.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
            this.lblNAVE_Matricula.Name = "lblNAVE_Matricula";
            this.lblNAVE_Matricula.Size = new System.Drawing.Size(67, 13);
            this.lblNAVE_Matricula.TabIndex = 7;
            this.lblNAVE_Matricula.Text = "Matricula :";
            // 
            // NAVE_Matricula
            // 
            this.NAVE_Matricula.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.NAVE_Matricula.Location = new System.Drawing.Point(153, 57);
            this.NAVE_Matricula.Name = "NAVE_Matricula";
            this.NAVE_Matricula.Size = new System.Drawing.Size(194, 20);
            this.NAVE_Matricula.TabIndex = 8;
            this.NAVE_Matricula.Tag = "PUER_CodigoMSGERROR";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(375, 61);
            this.label1.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(108, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Entidad Emisora :";
            // 
            // CONS_CodEnt
            // 
            this.CONS_CodEnt.ConstantesSelectedItem = null;
            this.CONS_CodEnt.ConstantesSelectedValue = null;
            this.CONS_CodEnt.ConstantesTitulo = null;
            this.CONS_CodEnt.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CONS_CodEnt.FormattingEnabled = true;
            this.CONS_CodEnt.Location = new System.Drawing.Point(518, 57);
            this.CONS_CodEnt.Name = "CONS_CodEnt";
            this.CONS_CodEnt.Session = null;
            this.CONS_CodEnt.Size = new System.Drawing.Size(201, 21);
            this.CONS_CodEnt.TabIndex = 10;
            this.CONS_CodEnt.Tag = "CONS_CodViaMSGERROR";
            // 
            // MAN010MView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(735, 157);
            this.Controls.Add(this.tableLayoutPanel2);
            this.Controls.Add(this.panelCaption1);
            this.Controls.Add(this.panel3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MAN010MView";
            this.ShowInTaskbar = false;
            this.Text = "Mantenimiento de Naves";
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Infrastructure.WinForms.Controls.TextBoxNumerico NAVE_Codigo;
        private System.Windows.Forms.TextBox NAVE_Nombre;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label lblNAVE_Codigo;
        private System.Windows.Forms.Label lblCONS_CodVia;
        private Controls.Tipos.ComboBoxConstantes CONS_CodVia;
        private Infrastructure.WinForms.Controls.PanelCaption panelCaption1;
        private System.Windows.Forms.Button btnMAN_salir;
        private System.Windows.Forms.Button btnMAN_guardar;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Label lblNAVE_Nombre;
        private System.Windows.Forms.Label lblNAVE_Matricula;
        private System.Windows.Forms.TextBox NAVE_Matricula;
        private System.Windows.Forms.Label label1;
        private Controls.Tipos.ComboBoxConstantes CONS_CodEnt;
    }
}