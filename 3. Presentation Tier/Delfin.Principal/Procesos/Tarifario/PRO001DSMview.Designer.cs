namespace Delfin.Principal
{
    partial class PRO001DSMview
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
         this.PnBotones = new System.Windows.Forms.Panel();
         this.btnAgregar = new System.Windows.Forms.Button();
         this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
         this.CbTIPO_CodMnd = new Delfin.Controls.Tipos.ComboBoxTipos();
         this.lblStandarSada20 = new System.Windows.Forms.Label();
         this.lblStandar20 = new System.Windows.Forms.Label();
         this.CbSERV_Codigo = new System.Windows.Forms.ComboBox();
         this.label1 = new System.Windows.Forms.Label();
         this.lblBaseAduanero = new System.Windows.Forms.Label();
         this.tlpTarifarioLogistico = new System.Windows.Forms.TableLayoutPanel();
         this.chkRoundtrip = new System.Windows.Forms.CheckBox();
         this.txtSCOT_PrecioUni = new System.Windows.Forms.NumericUpDown();
         this.PnBotones.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
         this.tlpTarifarioLogistico.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.txtSCOT_PrecioUni)).BeginInit();
         this.SuspendLayout();
         // 
         // PnBotones
         // 
         this.PnBotones.BackColor = System.Drawing.Color.LightSteelBlue;
         this.PnBotones.Controls.Add(this.btnAgregar);
         this.PnBotones.Dock = System.Windows.Forms.DockStyle.Top;
         this.PnBotones.Location = new System.Drawing.Point(0, 0);
         this.PnBotones.Name = "PnBotones";
         this.PnBotones.Size = new System.Drawing.Size(693, 50);
         this.PnBotones.TabIndex = 8;
         // 
         // btnAgregar
         // 
         this.btnAgregar.AutoSize = true;
         this.btnAgregar.Dock = System.Windows.Forms.DockStyle.Left;
         this.btnAgregar.FlatAppearance.BorderColor = System.Drawing.Color.LightSteelBlue;
         this.btnAgregar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
         this.btnAgregar.ForeColor = System.Drawing.Color.Black;
         this.btnAgregar.Image = global::Delfin.Principal.Properties.Resources.add;
         this.btnAgregar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
         this.btnAgregar.Location = new System.Drawing.Point(0, 0);
         this.btnAgregar.Margin = new System.Windows.Forms.Padding(0);
         this.btnAgregar.Name = "btnAgregar";
         this.btnAgregar.Size = new System.Drawing.Size(57, 50);
         this.btnAgregar.TabIndex = 0;
         this.btnAgregar.Text = "&Agregar";
         this.btnAgregar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
         this.btnAgregar.UseVisualStyleBackColor = true;
         // 
         // errorProvider1
         // 
         this.errorProvider1.ContainerControl = this;
         // 
         // CbTIPO_CodMnd
         // 
         this.CbTIPO_CodMnd.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this.CbTIPO_CodMnd.FormattingEnabled = true;
         this.CbTIPO_CodMnd.Location = new System.Drawing.Point(114, 30);
         this.CbTIPO_CodMnd.Name = "CbTIPO_CodMnd";
         this.CbTIPO_CodMnd.Size = new System.Drawing.Size(221, 21);
         this.CbTIPO_CodMnd.TabIndex = 3;
         this.CbTIPO_CodMnd.Tag = "TIPO_CodMndMSGERROR";
         this.CbTIPO_CodMnd.TiposSelectedItem = null;
         this.CbTIPO_CodMnd.TiposSelectedValue = null;
         this.CbTIPO_CodMnd.TiposTitulo = null;
         // 
         // lblStandarSada20
         // 
         this.lblStandarSada20.AutoSize = true;
         this.lblStandarSada20.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.lblStandarSada20.Location = new System.Drawing.Point(10, 34);
         this.lblStandarSada20.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
         this.lblStandarSada20.Name = "lblStandarSada20";
         this.lblStandarSada20.Size = new System.Drawing.Size(56, 13);
         this.lblStandarSada20.TabIndex = 2;
         this.lblStandarSada20.Text = "Moneda:";
         // 
         // lblStandar20
         // 
         this.lblStandar20.AutoSize = true;
         this.lblStandar20.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.lblStandar20.Location = new System.Drawing.Point(366, 34);
         this.lblStandar20.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
         this.lblStandar20.Name = "lblStandar20";
         this.lblStandar20.Size = new System.Drawing.Size(42, 13);
         this.lblStandar20.TabIndex = 4;
         this.lblStandar20.Text = "Valor:";
         // 
         // CbSERV_Codigo
         // 
         this.CbSERV_Codigo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this.CbSERV_Codigo.FormattingEnabled = true;
         this.CbSERV_Codigo.Location = new System.Drawing.Point(114, 3);
         this.CbSERV_Codigo.Name = "CbSERV_Codigo";
         this.CbSERV_Codigo.Size = new System.Drawing.Size(221, 21);
         this.CbSERV_Codigo.TabIndex = 1;
         // 
         // label1
         // 
         this.label1.AutoSize = true;
         this.label1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.label1.Location = new System.Drawing.Point(10, 7);
         this.label1.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
         this.label1.Name = "label1";
         this.label1.Size = new System.Drawing.Size(58, 13);
         this.label1.TabIndex = 0;
         this.label1.Text = "Servicio:";
         // 
         // lblBaseAduanero
         // 
         this.lblBaseAduanero.AutoSize = true;
         this.lblBaseAduanero.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.lblBaseAduanero.Location = new System.Drawing.Point(10, 61);
         this.lblBaseAduanero.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
         this.lblBaseAduanero.Name = "lblBaseAduanero";
         this.lblBaseAduanero.Size = new System.Drawing.Size(34, 13);
         this.lblBaseAduanero.TabIndex = 6;
         this.lblBaseAduanero.Text = "IGV:";
         // 
         // tlpTarifarioLogistico
         // 
         this.tlpTarifarioLogistico.AutoSize = true;
         this.tlpTarifarioLogistico.BackColor = System.Drawing.Color.LightSteelBlue;
         this.tlpTarifarioLogistico.ColumnCount = 7;
         this.tlpTarifarioLogistico.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 111F));
         this.tlpTarifarioLogistico.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 227F));
         this.tlpTarifarioLogistico.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 18F));
         this.tlpTarifarioLogistico.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 112F));
         this.tlpTarifarioLogistico.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 207F));
         this.tlpTarifarioLogistico.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 55F));
         this.tlpTarifarioLogistico.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
         this.tlpTarifarioLogistico.Controls.Add(this.lblBaseAduanero, 0, 2);
         this.tlpTarifarioLogistico.Controls.Add(this.label1, 0, 0);
         this.tlpTarifarioLogistico.Controls.Add(this.CbSERV_Codigo, 1, 0);
         this.tlpTarifarioLogistico.Controls.Add(this.lblStandar20, 3, 1);
         this.tlpTarifarioLogistico.Controls.Add(this.lblStandarSada20, 0, 1);
         this.tlpTarifarioLogistico.Controls.Add(this.CbTIPO_CodMnd, 1, 1);
         this.tlpTarifarioLogistico.Controls.Add(this.chkRoundtrip, 1, 2);
         this.tlpTarifarioLogistico.Controls.Add(this.txtSCOT_PrecioUni, 4, 1);
         this.tlpTarifarioLogistico.Dock = System.Windows.Forms.DockStyle.Top;
         this.tlpTarifarioLogistico.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
         this.tlpTarifarioLogistico.Location = new System.Drawing.Point(0, 50);
         this.tlpTarifarioLogistico.Name = "tlpTarifarioLogistico";
         this.tlpTarifarioLogistico.RowCount = 3;
         this.tlpTarifarioLogistico.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
         this.tlpTarifarioLogistico.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
         this.tlpTarifarioLogistico.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
         this.tlpTarifarioLogistico.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
         this.tlpTarifarioLogistico.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
         this.tlpTarifarioLogistico.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
         this.tlpTarifarioLogistico.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
         this.tlpTarifarioLogistico.Size = new System.Drawing.Size(693, 81);
         this.tlpTarifarioLogistico.TabIndex = 0;
         // 
         // chkRoundtrip
         // 
         this.chkRoundtrip.AutoSize = true;
         this.chkRoundtrip.Location = new System.Drawing.Point(114, 61);
         this.chkRoundtrip.Margin = new System.Windows.Forms.Padding(3, 7, 3, 3);
         this.chkRoundtrip.Name = "chkRoundtrip";
         this.chkRoundtrip.Size = new System.Drawing.Size(15, 14);
         this.chkRoundtrip.TabIndex = 7;
         this.chkRoundtrip.UseVisualStyleBackColor = true;
         // 
         // txtSCOT_PrecioUni
         // 
         this.txtSCOT_PrecioUni.DecimalPlaces = 2;
         this.txtSCOT_PrecioUni.Location = new System.Drawing.Point(471, 30);
         this.txtSCOT_PrecioUni.Maximum = new decimal(new int[] {
            99999999,
            0,
            0,
            131072});
         this.txtSCOT_PrecioUni.Name = "txtSCOT_PrecioUni";
         this.txtSCOT_PrecioUni.Size = new System.Drawing.Size(201, 20);
         this.txtSCOT_PrecioUni.TabIndex = 5;
         this.txtSCOT_PrecioUni.Tag = "SCOT_PrecioUniMSGERROR";
         this.txtSCOT_PrecioUni.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
         this.txtSCOT_PrecioUni.Enter += new System.EventHandler(this.txtCosto20_Enter);
         // 
         // PRO001DSMview
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.BackColor = System.Drawing.Color.LightSteelBlue;
         this.ClientSize = new System.Drawing.Size(693, 134);
         this.Controls.Add(this.tlpTarifarioLogistico);
         this.Controls.Add(this.PnBotones);
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "PRO001DSMview";
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
         this.Text = "Detalle Servicio Tarifario";
         this.PnBotones.ResumeLayout(false);
         this.PnBotones.PerformLayout();
         ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
         this.tlpTarifarioLogistico.ResumeLayout(false);
         this.tlpTarifarioLogistico.PerformLayout();
         ((System.ComponentModel.ISupportInitialize)(this.txtSCOT_PrecioUni)).EndInit();
         this.ResumeLayout(false);
         this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel PnBotones;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.TableLayoutPanel tlpTarifarioLogistico;
        private System.Windows.Forms.Label lblBaseAduanero;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox CbSERV_Codigo;
        private System.Windows.Forms.Label lblStandar20;
        private System.Windows.Forms.Label lblStandarSada20;
        private Controls.Tipos.ComboBoxTipos CbTIPO_CodMnd;
        private System.Windows.Forms.CheckBox chkRoundtrip;
        private System.Windows.Forms.NumericUpDown txtSCOT_PrecioUni;
    }
}