namespace Delfin.Principal
{
   partial class PRO007DViewFPG
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
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnSalir = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.panelCaption1 = new Infrastructure.WinForms.Controls.PanelCaption();
            this.tableDatosGenerales = new System.Windows.Forms.TableLayoutPanel();
            this.dtpDOCV_FechaEmision = new Infrastructure.WinForms.Controls.MaskTime();
            this.label8 = new System.Windows.Forms.Label();
            this.cmbTIPO_CodMND = new Delfin.Controls.Tipos.ComboBoxTipos();
            this.label4 = new System.Windows.Forms.Label();
            this.txaSeries = new Delfin.Controls.Serie.SeriesLarge();
            this.lblSERV_DescCorta = new System.Windows.Forms.Label();
            this.txaENTC_Codigo = new Delfin.Controls.EntidadDocIden();
            this.panelCaption2 = new Infrastructure.WinForms.Controls.PanelCaption();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.cmbTIPO_CodFPG = new Delfin.Controls.Tipos.ComboBoxTipos();
            this.dtpDOCV_FechaVcmto = new Infrastructure.WinForms.Controls.MaskTime();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel3.SuspendLayout();
            this.tableDatosGenerales.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
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
            this.panel3.Size = new System.Drawing.Size(737, 50);
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
            this.panelCaption1.Size = new System.Drawing.Size(737, 26);
            this.panelCaption1.TabIndex = 2;
            // 
            // tableDatosGenerales
            // 
            this.tableDatosGenerales.AutoSize = true;
            this.tableDatosGenerales.ColumnCount = 9;
            this.tableDatosGenerales.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tableDatosGenerales.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.tableDatosGenerales.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.tableDatosGenerales.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tableDatosGenerales.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.tableDatosGenerales.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.tableDatosGenerales.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tableDatosGenerales.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.tableDatosGenerales.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 16F));
            this.tableDatosGenerales.Controls.Add(this.dtpDOCV_FechaEmision, 4, 2);
            this.tableDatosGenerales.Controls.Add(this.label8, 3, 2);
            this.tableDatosGenerales.Controls.Add(this.cmbTIPO_CodMND, 1, 2);
            this.tableDatosGenerales.Controls.Add(this.label4, 0, 2);
            this.tableDatosGenerales.Controls.Add(this.txaSeries, 0, 0);
            this.tableDatosGenerales.Controls.Add(this.lblSERV_DescCorta, 0, 1);
            this.tableDatosGenerales.Controls.Add(this.txaENTC_Codigo, 1, 1);
            this.tableDatosGenerales.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableDatosGenerales.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
            this.tableDatosGenerales.Location = new System.Drawing.Point(0, 76);
            this.tableDatosGenerales.Name = "tableDatosGenerales";
            this.tableDatosGenerales.RowCount = 3;
            this.tableDatosGenerales.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableDatosGenerales.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableDatosGenerales.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableDatosGenerales.Size = new System.Drawing.Size(737, 81);
            this.tableDatosGenerales.TabIndex = 3;
            // 
            // dtpDOCV_FechaEmision
            // 
            this.dtpDOCV_FechaEmision.Location = new System.Drawing.Point(518, 57);
            this.dtpDOCV_FechaEmision.MinimumSize = new System.Drawing.Size(100, 22);
            this.dtpDOCV_FechaEmision.Name = "dtpDOCV_FechaEmision";
            this.dtpDOCV_FechaEmision.NSActiveMouse = false;
            this.dtpDOCV_FechaEmision.NSActiveMsgFecha = false;
            this.dtpDOCV_FechaEmision.NSChangeDate = true;
            this.dtpDOCV_FechaEmision.NSDigitos = 4;
            this.dtpDOCV_FechaEmision.NSFecha = null;
            this.dtpDOCV_FechaEmision.NSFormato = Infrastructure.WinForms.Controls.FormatoMostrado.Fecha;
            this.dtpDOCV_FechaEmision.NSSetDateNow = false;
            this.dtpDOCV_FechaEmision.Size = new System.Drawing.Size(100, 22);
            this.dtpDOCV_FechaEmision.TabIndex = 2;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(375, 61);
            this.label8.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(111, 13);
            this.label8.TabIndex = 13;
            this.label8.Text = "Fecha de Emisión:";
            // 
            // cmbTIPO_CodMND
            // 
            this.cmbTIPO_CodMND.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTIPO_CodMND.FormattingEnabled = true;
            this.cmbTIPO_CodMND.Location = new System.Drawing.Point(153, 57);
            this.cmbTIPO_CodMND.Name = "cmbTIPO_CodMND";
            this.cmbTIPO_CodMND.Session = null;
            this.cmbTIPO_CodMND.Size = new System.Drawing.Size(184, 21);
            this.cmbTIPO_CodMND.TabIndex = 31;
            this.cmbTIPO_CodMND.Tag = "TIPO_CodMNDMSGERROR";
            this.cmbTIPO_CodMND.TiposSelectedItem = null;
            this.cmbTIPO_CodMND.TiposSelectedValue = null;
            this.cmbTIPO_CodMND.TiposTitulo = null;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(10, 61);
            this.label4.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 13);
            this.label4.TabIndex = 19;
            this.label4.Text = "Moneda:";
            // 
            // txaSeries
            // 
            this.txaSeries.cmbSERI_Serie_Enabled = false;
            this.txaSeries.cmbTIPO_CodTDO_Enabled = true;
            this.tableDatosGenerales.SetColumnSpan(this.txaSeries, 5);
            this.txaSeries.ListSeries = null;
            this.txaSeries.ListTiposTDO = null;
            this.txaSeries.Location = new System.Drawing.Point(0, 0);
            this.txaSeries.Margin = new System.Windows.Forms.Padding(0);
            this.txaSeries.Name = "txaSeries";
            this.txaSeries.SelectedItem = null;
            this.txaSeries.SelectedItemTipoTDO = null;
            this.txaSeries.Size = new System.Drawing.Size(715, 27);
            this.txaSeries.TabIndex = 6;
            // 
            // lblSERV_DescCorta
            // 
            this.lblSERV_DescCorta.AutoSize = true;
            this.lblSERV_DescCorta.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSERV_DescCorta.Location = new System.Drawing.Point(10, 34);
            this.lblSERV_DescCorta.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
            this.lblSERV_DescCorta.Name = "lblSERV_DescCorta";
            this.lblSERV_DescCorta.Size = new System.Drawing.Size(56, 13);
            this.lblSERV_DescCorta.TabIndex = 7;
            this.lblSERV_DescCorta.Text = "Cliente :";
            // 
            // txaENTC_Codigo
            // 
            this.txaENTC_Codigo.BackColor = System.Drawing.Color.LightSteelBlue;
            this.txaENTC_Codigo.CrearNuevaEntidad = false;
            this.txaENTC_Codigo.Location = new System.Drawing.Point(150, 27);
            this.txaENTC_Codigo.Margin = new System.Windows.Forms.Padding(0);
            this.txaENTC_Codigo.MinimumSize = new System.Drawing.Size(565, 27);
            this.txaENTC_Codigo.Name = "txaENTC_Codigo";
            this.txaENTC_Codigo.Size = new System.Drawing.Size(565, 27);
            this.txaENTC_Codigo.SoloEntidad = false;
            this.txaENTC_Codigo.TabIndex = 6;
            this.txaENTC_Codigo.TagEntidad = null;
            this.txaENTC_Codigo.TiposEntidad = Delfin.Controls.TiposEntidad.TIPE_AgenciaAduanera;
            this.txaENTC_Codigo.txaENTC_DOCIDEN_Name = "txaENTC_DOCIDEN";
            this.txaENTC_Codigo.txaENTC_NOMCOMPLETO_Name = "txaENTC_NOMCOMPLETO";
            // 
            // panelCaption2
            // 
            this.panelCaption2.AllowActive = false;
            this.panelCaption2.AntiAlias = false;
            this.panelCaption2.Caption = "Detalle";
            this.panelCaption2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelCaption2.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
            this.panelCaption2.InactiveGradientHighColor = System.Drawing.Color.SteelBlue;
            this.panelCaption2.InactiveGradientLowColor = System.Drawing.Color.MidnightBlue;
            this.panelCaption2.Location = new System.Drawing.Point(0, 157);
            this.panelCaption2.Name = "panelCaption2";
            this.panelCaption2.Size = new System.Drawing.Size(737, 26);
            this.panelCaption2.TabIndex = 4;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.ColumnCount = 9;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 16F));
            this.tableLayoutPanel1.Controls.Add(this.cmbTIPO_CodFPG, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.dtpDOCV_FechaVcmto, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 183);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(737, 54);
            this.tableLayoutPanel1.TabIndex = 5;
            // 
            // cmbTIPO_CodFPG
            // 
            this.cmbTIPO_CodFPG.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTIPO_CodFPG.FormattingEnabled = true;
            this.cmbTIPO_CodFPG.Location = new System.Drawing.Point(153, 3);
            this.cmbTIPO_CodFPG.Name = "cmbTIPO_CodFPG";
            this.cmbTIPO_CodFPG.Session = null;
            this.cmbTIPO_CodFPG.Size = new System.Drawing.Size(190, 21);
            this.cmbTIPO_CodFPG.TabIndex = 30;
            this.cmbTIPO_CodFPG.Tag = "TIPO_CodFPGMSGERROR";
            this.cmbTIPO_CodFPG.TiposSelectedItem = null;
            this.cmbTIPO_CodFPG.TiposSelectedValue = null;
            this.cmbTIPO_CodFPG.TiposTitulo = null;
            // 
            // dtpDOCV_FechaVcmto
            // 
            this.dtpDOCV_FechaVcmto.Location = new System.Drawing.Point(518, 3);
            this.dtpDOCV_FechaVcmto.MinimumSize = new System.Drawing.Size(100, 22);
            this.dtpDOCV_FechaVcmto.Name = "dtpDOCV_FechaVcmto";
            this.dtpDOCV_FechaVcmto.NSActiveMouse = false;
            this.dtpDOCV_FechaVcmto.NSActiveMsgFecha = false;
            this.dtpDOCV_FechaVcmto.NSChangeDate = true;
            this.dtpDOCV_FechaVcmto.NSDigitos = 4;
            this.dtpDOCV_FechaVcmto.NSFecha = null;
            this.dtpDOCV_FechaVcmto.NSFormato = Infrastructure.WinForms.Controls.FormatoMostrado.Fecha;
            this.dtpDOCV_FechaVcmto.NSSetDateNow = false;
            this.dtpDOCV_FechaVcmto.Size = new System.Drawing.Size(100, 22);
            this.dtpDOCV_FechaVcmto.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(375, 7);
            this.label2.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(122, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Fecha Vencimiento :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(10, 7);
            this.label1.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Forma de Pago :";
            // 
            // PRO007DViewFPG
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(737, 219);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.panelCaption2);
            this.Controls.Add(this.tableDatosGenerales);
            this.Controls.Add(this.panelCaption1);
            this.Controls.Add(this.panel3);
            this.Name = "PRO007DViewFPG";
            this.Text = "Forma de Pago y Fecha de Vencimiento";
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.tableDatosGenerales.ResumeLayout(false);
            this.tableDatosGenerales.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.Panel panel3;
      private System.Windows.Forms.Button btnSalir;
      private System.Windows.Forms.Button btnGuardar;
      private Infrastructure.WinForms.Controls.PanelCaption panelCaption1;
      private System.Windows.Forms.TableLayoutPanel tableDatosGenerales;
      private System.Windows.Forms.Label lblSERV_DescCorta;
      private Controls.EntidadDocIden txaENTC_Codigo;
      private Controls.Serie.SeriesLarge txaSeries;
      private Infrastructure.WinForms.Controls.PanelCaption panelCaption2;
      private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
      private System.Windows.Forms.Label label2;
      private System.Windows.Forms.Label label1;
      private System.Windows.Forms.Label label4;
      private Controls.Tipos.ComboBoxTipos cmbTIPO_CodMND;
      private System.Windows.Forms.Label label8;
      private Infrastructure.WinForms.Controls.MaskTime dtpDOCV_FechaEmision;
      private Infrastructure.WinForms.Controls.MaskTime dtpDOCV_FechaVcmto;
      private Controls.Tipos.ComboBoxTipos cmbTIPO_CodFPG;
   }
}