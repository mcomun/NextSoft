namespace Delfin.Principal
{
    partial class CAJ017View
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
         this.panel1 = new System.Windows.Forms.Panel();
         this.btnSalir = new System.Windows.Forms.Button();
         this.btnGenerar = new System.Windows.Forms.Button();
         this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
         this.lblCCOT_NumDoc = new System.Windows.Forms.Label();
         this.txtCCOT_Numero = new System.Windows.Forms.TextBox();
         this.txaENTC_CodCliente = new Delfin.Controls.Entidad(this.components);
         this.lblENTC_CodCliente = new System.Windows.Forms.Label();
         this.txaAyudaHBL = new Infrastructure.WinForms.Controls.TextBoxAyuda(this.components);
         this.label1 = new System.Windows.Forms.Label();
         this.panel1.SuspendLayout();
         this.tableLayoutPanel1.SuspendLayout();
         this.SuspendLayout();
         // 
         // panel1
         // 
         this.panel1.BackColor = System.Drawing.Color.LightSteelBlue;
         this.panel1.Controls.Add(this.btnSalir);
         this.panel1.Controls.Add(this.btnGenerar);
         this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
         this.panel1.Location = new System.Drawing.Point(0, 0);
         this.panel1.Name = "panel1";
         this.panel1.Size = new System.Drawing.Size(734, 50);
         this.panel1.TabIndex = 0;
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
         // btnGenerar
         // 
         this.btnGenerar.AutoSize = true;
         this.btnGenerar.Dock = System.Windows.Forms.DockStyle.Left;
         this.btnGenerar.FlatAppearance.BorderColor = System.Drawing.Color.LightSteelBlue;
         this.btnGenerar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
         this.btnGenerar.ForeColor = System.Drawing.Color.Black;
         this.btnGenerar.Image = global::Delfin.Principal.Properties.Resources.replace21;
         this.btnGenerar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
         this.btnGenerar.Location = new System.Drawing.Point(0, 0);
         this.btnGenerar.Margin = new System.Windows.Forms.Padding(0);
         this.btnGenerar.Name = "btnGenerar";
         this.btnGenerar.Size = new System.Drawing.Size(57, 50);
         this.btnGenerar.TabIndex = 0;
         this.btnGenerar.Text = "Generar";
         this.btnGenerar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
         this.btnGenerar.UseVisualStyleBackColor = true;
         // 
         // tableLayoutPanel1
         // 
         this.tableLayoutPanel1.ColumnCount = 7;
         this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
         this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
         this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15F));
         this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
         this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
         this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15F));
         this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
         this.tableLayoutPanel1.Controls.Add(this.label1, 3, 0);
         this.tableLayoutPanel1.Controls.Add(this.txaAyudaHBL, 4, 0);
         this.tableLayoutPanel1.Controls.Add(this.lblCCOT_NumDoc, 0, 0);
         this.tableLayoutPanel1.Controls.Add(this.txtCCOT_Numero, 1, 0);
         this.tableLayoutPanel1.Controls.Add(this.txaENTC_CodCliente, 1, 1);
         this.tableLayoutPanel1.Controls.Add(this.lblENTC_CodCliente, 0, 1);
         this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
         this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 50);
         this.tableLayoutPanel1.Name = "tableLayoutPanel1";
         this.tableLayoutPanel1.RowCount = 3;
         this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
         this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
         this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
         this.tableLayoutPanel1.Size = new System.Drawing.Size(734, 61);
         this.tableLayoutPanel1.TabIndex = 1;
         // 
         // lblCCOT_NumDoc
         // 
         this.lblCCOT_NumDoc.AutoSize = true;
         this.lblCCOT_NumDoc.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.lblCCOT_NumDoc.Location = new System.Drawing.Point(10, 7);
         this.lblCCOT_NumDoc.Margin = new System.Windows.Forms.Padding(10, 7, 2, 0);
         this.lblCCOT_NumDoc.Name = "lblCCOT_NumDoc";
         this.lblCCOT_NumDoc.Size = new System.Drawing.Size(100, 13);
         this.lblCCOT_NumDoc.TabIndex = 0;
         this.lblCCOT_NumDoc.Text = "Número de OV :";
         // 
         // txtCCOT_Numero
         // 
         this.txtCCOT_Numero.Location = new System.Drawing.Point(153, 3);
         this.txtCCOT_Numero.MaxLength = 20;
         this.txtCCOT_Numero.Name = "txtCCOT_Numero";
         this.txtCCOT_Numero.Size = new System.Drawing.Size(194, 20);
         this.txtCCOT_Numero.TabIndex = 1;
         this.txtCCOT_Numero.Tag = "NVIA_NroViajeMSGERROR";
         // 
         // txaENTC_CodCliente
         // 
         this.txaENTC_CodCliente.ActivarAyudaAuto = false;
         this.tableLayoutPanel1.SetColumnSpan(this.txaENTC_CodCliente, 4);
         this.txaENTC_CodCliente.ContainerService = null;
         this.txaENTC_CodCliente.EnabledAyudaButton = true;
         this.txaENTC_CodCliente.Location = new System.Drawing.Point(153, 30);
         this.txaENTC_CodCliente.LongitudAceptada = 0;
         this.txaENTC_CodCliente.MyInstanciaAyuda = Delfin.Controls.Entidad.InstanciaAyuda.Habilitado;
         this.txaENTC_CodCliente.Name = "txaENTC_CodCliente";
         this.txaENTC_CodCliente.RellenaCeros = false;
         this.txaENTC_CodCliente.Size = new System.Drawing.Size(559, 20);
         this.txaENTC_CodCliente.TabIndex = 5;
         this.txaENTC_CodCliente.Tipo = Delfin.Controls.Entidad.TipoTextBoxAyuda.AlfaNumerico;
         this.txaENTC_CodCliente.TipoEntidad = Delfin.Controls.TiposEntidad.TIPE_Cliente;
         this.txaENTC_CodCliente.UsarTipoEntidad = true;
         this.txaENTC_CodCliente.Value = null;
         // 
         // lblENTC_CodCliente
         // 
         this.lblENTC_CodCliente.AutoSize = true;
         this.lblENTC_CodCliente.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.lblENTC_CodCliente.Location = new System.Drawing.Point(10, 34);
         this.lblENTC_CodCliente.Margin = new System.Windows.Forms.Padding(10, 7, 2, 0);
         this.lblENTC_CodCliente.Name = "lblENTC_CodCliente";
         this.lblENTC_CodCliente.Size = new System.Drawing.Size(56, 13);
         this.lblENTC_CodCliente.TabIndex = 4;
         this.lblENTC_CodCliente.Text = "Cliente :";
         // 
         // txaAyudaHBL
         // 
         this.txaAyudaHBL.ActivarAyudaAuto = false;
         this.txaAyudaHBL.EnabledAyuda = true;
         this.txaAyudaHBL.EnabledAyudaButton = true;
         this.txaAyudaHBL.EsFiltro = false;
         this.txaAyudaHBL.Location = new System.Drawing.Point(518, 3);
         this.txaAyudaHBL.LongitudAceptada = 0;
         this.txaAyudaHBL.MyInstanciaAyuda = Infrastructure.WinForms.Controls.TextBoxAyuda.InstanciaAyuda.Habilitado;
         this.txaAyudaHBL.Name = "txaAyudaHBL";
         this.txaAyudaHBL.RellenaCeros = false;
         this.txaAyudaHBL.Size = new System.Drawing.Size(194, 20);
         this.txaAyudaHBL.TabIndex = 3;
         this.txaAyudaHBL.Tipo = Infrastructure.WinForms.Controls.TextBoxAyuda.TipoTextBoxAyuda.AlfaNumerico;
         this.txaAyudaHBL.Value = null;
         // 
         // label1
         // 
         this.label1.AutoSize = true;
         this.label1.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.label1.Location = new System.Drawing.Point(375, 7);
         this.label1.Margin = new System.Windows.Forms.Padding(10, 7, 2, 0);
         this.label1.Name = "label1";
         this.label1.Size = new System.Drawing.Size(38, 13);
         this.label1.TabIndex = 2;
         this.label1.Text = "HBL :";
         // 
         // CAJ017View
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.BackColor = System.Drawing.Color.LightSteelBlue;
         this.ClientSize = new System.Drawing.Size(734, 111);
         this.Controls.Add(this.tableLayoutPanel1);
         this.Controls.Add(this.panel1);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "CAJ017View";
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
         this.Text = "Generar Avisos de Llegada";
         this.panel1.ResumeLayout(false);
         this.panel1.PerformLayout();
         this.tableLayoutPanel1.ResumeLayout(false);
         this.tableLayoutPanel1.PerformLayout();
         this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Button btnGenerar;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lblCCOT_NumDoc;
        private System.Windows.Forms.TextBox txtCCOT_Numero;
        private Controls.Entidad txaENTC_CodCliente;
        private System.Windows.Forms.Label lblENTC_CodCliente;
        private System.Windows.Forms.Label label1;
        private Infrastructure.WinForms.Controls.TextBoxAyuda txaAyudaHBL;
    }
}