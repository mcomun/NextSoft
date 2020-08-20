namespace Delfin.Principal
{
    partial class MAN014MView
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
         this.panelCaption1 = new Infrastructure.WinForms.Controls.PanelCaption();
         this.panel3 = new System.Windows.Forms.Panel();
         this.btnSalir = new System.Windows.Forms.Button();
         this.btnGuardar = new System.Windows.Forms.Button();
         this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
         this.grdDetComision = new Telerik.WinControls.UI.RadGridView();
         this.mdtCOMI_FecFin = new Infrastructure.WinForms.Controls.MaskDateTime();
         this.lblCOMI_FecFin = new System.Windows.Forms.Label();
         this.txnCOMI_Codigo = new Infrastructure.WinForms.Controls.TextBoxNumerico();
         this.lblCOMI_Codigo = new System.Windows.Forms.Label();
         this.cmbTIPO_CodMND = new Delfin.Controls.Tipos.ComboBoxTipos();
         this.lblTIPO_CodMND = new System.Windows.Forms.Label();
         this.mdtCOMI_FecIni = new Infrastructure.WinForms.Controls.MaskDateTime();
         this.lblCOMI_FecIni = new System.Windows.Forms.Label();
         this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
         this.panel8 = new System.Windows.Forms.Panel();
         this.btnDelComision = new System.Windows.Forms.Button();
         this.btnAddDetComision = new System.Windows.Forms.Button();
         this.panelCaption4 = new Infrastructure.WinForms.Controls.PanelCaption();
         this.panel3.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.grdDetComision)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.grdDetComision.MasterTemplate)).BeginInit();
         this.tableLayoutPanel2.SuspendLayout();
         this.panel8.SuspendLayout();
         this.SuspendLayout();
         // 
         // panelCaption1
         // 
         this.panelCaption1.AllowActive = false;
         this.panelCaption1.AntiAlias = false;
         this.panelCaption1.Caption = "Datos de la Comisión";
         this.panelCaption1.Dock = System.Windows.Forms.DockStyle.Top;
         this.panelCaption1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
         this.panelCaption1.InactiveGradientHighColor = System.Drawing.Color.SteelBlue;
         this.panelCaption1.InactiveGradientLowColor = System.Drawing.Color.MidnightBlue;
         this.panelCaption1.Location = new System.Drawing.Point(0, 50);
         this.panelCaption1.Name = "panelCaption1";
         this.panelCaption1.Size = new System.Drawing.Size(736, 26);
         this.panelCaption1.TabIndex = 1;
         // 
         // panel3
         // 
         this.panel3.BackColor = System.Drawing.Color.LightSteelBlue;
         this.panel3.Controls.Add(this.btnSalir);
         this.panel3.Controls.Add(this.btnGuardar);
         this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
         this.panel3.Location = new System.Drawing.Point(0, 0);
         this.panel3.Name = "panel3";
         this.panel3.Size = new System.Drawing.Size(736, 50);
         this.panel3.TabIndex = 0;
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
         // errorProvider1
         // 
         this.errorProvider1.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
         this.errorProvider1.ContainerControl = this;
         // 
         // grdDetComision
         // 
         this.grdDetComision.BackColor = System.Drawing.SystemColors.ControlLightLight;
         this.grdDetComision.Dock = System.Windows.Forms.DockStyle.Fill;
         this.grdDetComision.Location = new System.Drawing.Point(0, 159);
         this.grdDetComision.Name = "grdDetComision";
         this.grdDetComision.Size = new System.Drawing.Size(736, 251);
         this.grdDetComision.TabIndex = 3;
         this.grdDetComision.TabStop = false;
         // 
         // mdtCOMI_FecFin
         // 
         this.mdtCOMI_FecFin.Location = new System.Drawing.Point(518, 30);
         this.mdtCOMI_FecFin.MinimumSize = new System.Drawing.Size(100, 22);
         this.mdtCOMI_FecFin.Name = "mdtCOMI_FecFin";
         this.mdtCOMI_FecFin.NSActiveMouse = false;
         this.mdtCOMI_FecFin.NSActiveMsgFecha = false;
         this.mdtCOMI_FecFin.NSChangeDate = true;
         this.mdtCOMI_FecFin.NSDigitos = 4;
         this.mdtCOMI_FecFin.NSFecha = null;
         this.mdtCOMI_FecFin.NSSetDateNow = false;
         this.mdtCOMI_FecFin.Size = new System.Drawing.Size(101, 22);
         this.mdtCOMI_FecFin.TabIndex = 7;
         this.mdtCOMI_FecFin.Tag = "CONT_FecEmiMSGERROR";
         // 
         // lblCOMI_FecFin
         // 
         this.lblCOMI_FecFin.AutoSize = true;
         this.lblCOMI_FecFin.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.lblCOMI_FecFin.Location = new System.Drawing.Point(375, 34);
         this.lblCOMI_FecFin.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
         this.lblCOMI_FecFin.Name = "lblCOMI_FecFin";
         this.lblCOMI_FecFin.Size = new System.Drawing.Size(65, 13);
         this.lblCOMI_FecFin.TabIndex = 6;
         this.lblCOMI_FecFin.Text = "Fecha Fin:";
         // 
         // txnCOMI_Codigo
         // 
         this.txnCOMI_Codigo.BaseTipo = Infrastructure.WinForms.Controls.EstandaresFormato.General;
         this.txnCOMI_Codigo.Decimales = 0;
         this.txnCOMI_Codigo.Enteros = 11;
         this.txnCOMI_Codigo.Formato = "##,###,###,##0.";
         this.txnCOMI_Codigo.Location = new System.Drawing.Point(153, 3);
         this.txnCOMI_Codigo.MaxLength = 12;
         this.txnCOMI_Codigo.Name = "txnCOMI_Codigo";
         this.txnCOMI_Codigo.Negativo = true;
         this.txnCOMI_Codigo.ReadOnly = true;
         this.txnCOMI_Codigo.SinFormato = true;
         this.txnCOMI_Codigo.Size = new System.Drawing.Size(194, 20);
         this.txnCOMI_Codigo.TabIndex = 1;
         this.txnCOMI_Codigo.Tag = "PUER_CodigoMSGERROR";
         this.txnCOMI_Codigo.Text = "0";
         this.txnCOMI_Codigo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
         this.txnCOMI_Codigo.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
         // 
         // lblCOMI_Codigo
         // 
         this.lblCOMI_Codigo.AutoSize = true;
         this.lblCOMI_Codigo.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.lblCOMI_Codigo.Location = new System.Drawing.Point(10, 7);
         this.lblCOMI_Codigo.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
         this.lblCOMI_Codigo.Name = "lblCOMI_Codigo";
         this.lblCOMI_Codigo.Size = new System.Drawing.Size(52, 13);
         this.lblCOMI_Codigo.TabIndex = 0;
         this.lblCOMI_Codigo.Text = "Codigo:";
         // 
         // cmbTIPO_CodMND
         // 
         this.cmbTIPO_CodMND.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this.cmbTIPO_CodMND.FormattingEnabled = true;
         this.cmbTIPO_CodMND.Location = new System.Drawing.Point(518, 3);
         this.cmbTIPO_CodMND.Name = "cmbTIPO_CodMND";
         this.cmbTIPO_CodMND.Size = new System.Drawing.Size(194, 21);
         this.cmbTIPO_CodMND.TabIndex = 3;
         this.cmbTIPO_CodMND.Tag = "TIPO_CodMNDMSGERROR";
         this.cmbTIPO_CodMND.TiposSelectedItem = null;
         this.cmbTIPO_CodMND.TiposSelectedValue = null;
         this.cmbTIPO_CodMND.TiposTitulo = null;
         // 
         // lblTIPO_CodMND
         // 
         this.lblTIPO_CodMND.AutoSize = true;
         this.lblTIPO_CodMND.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.lblTIPO_CodMND.Location = new System.Drawing.Point(375, 7);
         this.lblTIPO_CodMND.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
         this.lblTIPO_CodMND.Name = "lblTIPO_CodMND";
         this.lblTIPO_CodMND.Size = new System.Drawing.Size(56, 13);
         this.lblTIPO_CodMND.TabIndex = 2;
         this.lblTIPO_CodMND.Text = "Moneda:";
         // 
         // mdtCOMI_FecIni
         // 
         this.mdtCOMI_FecIni.Location = new System.Drawing.Point(153, 30);
         this.mdtCOMI_FecIni.MinimumSize = new System.Drawing.Size(100, 22);
         this.mdtCOMI_FecIni.Name = "mdtCOMI_FecIni";
         this.mdtCOMI_FecIni.NSActiveMouse = false;
         this.mdtCOMI_FecIni.NSActiveMsgFecha = false;
         this.mdtCOMI_FecIni.NSChangeDate = true;
         this.mdtCOMI_FecIni.NSDigitos = 4;
         this.mdtCOMI_FecIni.NSFecha = null;
         this.mdtCOMI_FecIni.NSSetDateNow = false;
         this.mdtCOMI_FecIni.Size = new System.Drawing.Size(101, 22);
         this.mdtCOMI_FecIni.TabIndex = 5;
         this.mdtCOMI_FecIni.Tag = "CONT_FecEmiMSGERROR";
         // 
         // lblCOMI_FecIni
         // 
         this.lblCOMI_FecIni.AutoSize = true;
         this.lblCOMI_FecIni.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.lblCOMI_FecIni.Location = new System.Drawing.Point(10, 34);
         this.lblCOMI_FecIni.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
         this.lblCOMI_FecIni.Name = "lblCOMI_FecIni";
         this.lblCOMI_FecIni.Size = new System.Drawing.Size(64, 13);
         this.lblCOMI_FecIni.TabIndex = 4;
         this.lblCOMI_FecIni.Text = "Fecha Ini:";
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
         this.tableLayoutPanel2.Controls.Add(this.lblCOMI_Codigo, 0, 0);
         this.tableLayoutPanel2.Controls.Add(this.txnCOMI_Codigo, 1, 0);
         this.tableLayoutPanel2.Controls.Add(this.lblTIPO_CodMND, 3, 0);
         this.tableLayoutPanel2.Controls.Add(this.cmbTIPO_CodMND, 4, 0);
         this.tableLayoutPanel2.Controls.Add(this.lblCOMI_FecIni, 0, 1);
         this.tableLayoutPanel2.Controls.Add(this.mdtCOMI_FecIni, 1, 1);
         this.tableLayoutPanel2.Controls.Add(this.lblCOMI_FecFin, 3, 1);
         this.tableLayoutPanel2.Controls.Add(this.mdtCOMI_FecFin, 4, 1);
         this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Top;
         this.tableLayoutPanel2.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
         this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 76);
         this.tableLayoutPanel2.Name = "tableLayoutPanel2";
         this.tableLayoutPanel2.RowCount = 2;
         this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
         this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
         this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
         this.tableLayoutPanel2.Size = new System.Drawing.Size(736, 54);
         this.tableLayoutPanel2.TabIndex = 2;
         // 
         // panel8
         // 
         this.panel8.Controls.Add(this.btnDelComision);
         this.panel8.Controls.Add(this.btnAddDetComision);
         this.panel8.Controls.Add(this.panelCaption4);
         this.panel8.Dock = System.Windows.Forms.DockStyle.Top;
         this.panel8.Location = new System.Drawing.Point(0, 130);
         this.panel8.Name = "panel8";
         this.panel8.Size = new System.Drawing.Size(736, 29);
         this.panel8.TabIndex = 54;
         // 
         // btnDelComision
         // 
         this.btnDelComision.BackColor = System.Drawing.Color.Transparent;
         this.btnDelComision.Image = global::Delfin.Principal.Properties.Resources.delete1;
         this.btnDelComision.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
         this.btnDelComision.Location = new System.Drawing.Point(182, 1);
         this.btnDelComision.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
         this.btnDelComision.Name = "btnDelComision";
         this.btnDelComision.Size = new System.Drawing.Size(25, 25);
         this.btnDelComision.TabIndex = 2;
         this.btnDelComision.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
         this.btnDelComision.UseVisualStyleBackColor = false;
         // 
         // btnAddDetComision
         // 
         this.btnAddDetComision.BackColor = System.Drawing.Color.Transparent;
         this.btnAddDetComision.Image = global::Delfin.Principal.Properties.Resources.add16x16;
         this.btnAddDetComision.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
         this.btnAddDetComision.Location = new System.Drawing.Point(153, 1);
         this.btnAddDetComision.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
         this.btnAddDetComision.Name = "btnAddDetComision";
         this.btnAddDetComision.Size = new System.Drawing.Size(25, 25);
         this.btnAddDetComision.TabIndex = 1;
         this.btnAddDetComision.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
         this.btnAddDetComision.UseVisualStyleBackColor = false;
         // 
         // panelCaption4
         // 
         this.panelCaption4.AllowActive = false;
         this.panelCaption4.AntiAlias = false;
         this.panelCaption4.Caption = "Detalle de Comisión";
         this.panelCaption4.Dock = System.Windows.Forms.DockStyle.Top;
         this.panelCaption4.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
         this.panelCaption4.InactiveGradientHighColor = System.Drawing.Color.SteelBlue;
         this.panelCaption4.InactiveGradientLowColor = System.Drawing.Color.MidnightBlue;
         this.panelCaption4.Location = new System.Drawing.Point(0, 0);
         this.panelCaption4.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
         this.panelCaption4.Name = "panelCaption4";
         this.panelCaption4.Size = new System.Drawing.Size(736, 27);
         this.panelCaption4.TabIndex = 0;
         // 
         // MAN014MView
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.BackColor = System.Drawing.Color.LightSteelBlue;
         this.ClientSize = new System.Drawing.Size(736, 410);
         this.Controls.Add(this.grdDetComision);
         this.Controls.Add(this.panel8);
         this.Controls.Add(this.tableLayoutPanel2);
         this.Controls.Add(this.panelCaption1);
         this.Controls.Add(this.panel3);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "MAN014MView";
         this.ShowInTaskbar = false;
         this.Text = "Mantenimiento de Configuración de Comisiones";
         this.panel3.ResumeLayout(false);
         this.panel3.PerformLayout();
         ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.grdDetComision.MasterTemplate)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.grdDetComision)).EndInit();
         this.tableLayoutPanel2.ResumeLayout(false);
         this.tableLayoutPanel2.PerformLayout();
         this.panel8.ResumeLayout(false);
         this.ResumeLayout(false);
         this.PerformLayout();

        }

        #endregion

        private Infrastructure.WinForms.Controls.PanelCaption panelCaption1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private Telerik.WinControls.UI.RadGridView grdDetComision;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label lblCOMI_Codigo;
        private Infrastructure.WinForms.Controls.TextBoxNumerico txnCOMI_Codigo;
        private System.Windows.Forms.Label lblTIPO_CodMND;
        private Controls.Tipos.ComboBoxTipos cmbTIPO_CodMND;
        private System.Windows.Forms.Label lblCOMI_FecIni;
        private Infrastructure.WinForms.Controls.MaskDateTime mdtCOMI_FecIni;
        private System.Windows.Forms.Label lblCOMI_FecFin;
        private Infrastructure.WinForms.Controls.MaskDateTime mdtCOMI_FecFin;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Button btnDelComision;
        private System.Windows.Forms.Button btnAddDetComision;
        private Infrastructure.WinForms.Controls.PanelCaption panelCaption4;
    }
}