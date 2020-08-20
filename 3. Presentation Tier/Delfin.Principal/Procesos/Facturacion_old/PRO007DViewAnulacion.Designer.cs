namespace Delfin.Logistico.Procesos.Facturacion
{
   partial class PRO007DViewAnulacion
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
         this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
         this.cmbTIPE_Codigo = new Delfin.Controls.ComboBoxTipoEntidad();
         this.txaSeries = new Delfin.Controls.Serie.SeriesLarge();
         this.lblTIPE_Codigo = new System.Windows.Forms.Label();
         this.lblENTC_Codigo = new System.Windows.Forms.Label();
         this.txaENTC_Codigo = new Delfin.Controls.EntidadDocIden();
         this.label8 = new System.Windows.Forms.Label();
         this.DTPPDOV_FechaEmision = new System.Windows.Forms.DateTimePicker();
         this.panelCaption3 = new Infrastructure.WinForms.Controls.PanelCaption();
         this.panel3 = new System.Windows.Forms.Panel();
         this.btnSalir = new System.Windows.Forms.Button();
         this.btnAceptar = new System.Windows.Forms.Button();
         this.panelCaption1 = new Infrastructure.WinForms.Controls.PanelCaption();
         this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
         this.comboBoxTipoEntidad1 = new Delfin.Controls.ComboBoxTipoEntidad();
         this.label1 = new System.Windows.Forms.Label();
         this.label2 = new System.Windows.Forms.Label();
         this.lblMOVI_Codigo = new System.Windows.Forms.Label();
         this.label4 = new System.Windows.Forms.Label();
         this.dtpFecFin = new Infrastructure.WinForms.Controls.MaskTime();
         this.tableLayoutPanel3.SuspendLayout();
         this.panel3.SuspendLayout();
         this.tableLayoutPanel1.SuspendLayout();
         this.SuspendLayout();
         // 
         // tableLayoutPanel3
         // 
         this.tableLayoutPanel3.AutoSize = true;
         this.tableLayoutPanel3.ColumnCount = 10;
         this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
         this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
         this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15F));
         this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
         this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
         this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15F));
         this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
         this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
         this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15F));
         this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
         this.tableLayoutPanel3.Controls.Add(this.cmbTIPE_Codigo, 1, 1);
         this.tableLayoutPanel3.Controls.Add(this.txaSeries, 0, 0);
         this.tableLayoutPanel3.Controls.Add(this.lblTIPE_Codigo, 0, 1);
         this.tableLayoutPanel3.Controls.Add(this.lblENTC_Codigo, 0, 2);
         this.tableLayoutPanel3.Controls.Add(this.txaENTC_Codigo, 1, 2);
         this.tableLayoutPanel3.Controls.Add(this.label8, 3, 1);
         this.tableLayoutPanel3.Controls.Add(this.DTPPDOV_FechaEmision, 4, 1);
         this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Top;
         this.tableLayoutPanel3.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
         this.tableLayoutPanel3.Location = new System.Drawing.Point(0, 76);
         this.tableLayoutPanel3.Name = "tableLayoutPanel3";
         this.tableLayoutPanel3.RowCount = 3;
         this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
         this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
         this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
         this.tableLayoutPanel3.Size = new System.Drawing.Size(738, 81);
         this.tableLayoutPanel3.TabIndex = 5;
         // 
         // cmbTIPE_Codigo
         // 
         this.cmbTIPE_Codigo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this.cmbTIPE_Codigo.FormattingEnabled = true;
         this.cmbTIPE_Codigo.Location = new System.Drawing.Point(153, 30);
         this.cmbTIPE_Codigo.Name = "cmbTIPE_Codigo";
         this.cmbTIPE_Codigo.Size = new System.Drawing.Size(194, 21);
         this.cmbTIPE_Codigo.TabIndex = 14;
         this.cmbTIPE_Codigo.Tag = "TIPE_CodigoMSGERROR";
         this.cmbTIPE_Codigo.TipoEntidadSelectedItem = null;
         this.cmbTIPE_Codigo.TipoEntidadSelectedValue = null;
         this.cmbTIPE_Codigo.TiposTitulo = null;
         // 
         // txaSeries
         // 
         this.txaSeries.cmbSERI_Serie_Enabled = false;
         this.txaSeries.cmbTIPO_CodTDO_Enabled = true;
         this.tableLayoutPanel3.SetColumnSpan(this.txaSeries, 5);
         this.txaSeries.ListSeries = null;
         this.txaSeries.ListTiposTDO = null;
         this.txaSeries.Location = new System.Drawing.Point(0, 0);
         this.txaSeries.Margin = new System.Windows.Forms.Padding(0);
         this.txaSeries.Name = "txaSeries";
         this.txaSeries.SelectedItem = null;
         this.txaSeries.SelectedItemTipoTDO = null;
         this.txaSeries.Size = new System.Drawing.Size(715, 27);
         this.txaSeries.TabIndex = 2;
         // 
         // lblTIPE_Codigo
         // 
         this.lblTIPE_Codigo.AutoSize = true;
         this.lblTIPE_Codigo.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.lblTIPE_Codigo.Location = new System.Drawing.Point(10, 34);
         this.lblTIPE_Codigo.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
         this.lblTIPE_Codigo.Name = "lblTIPE_Codigo";
         this.lblTIPE_Codigo.Size = new System.Drawing.Size(104, 13);
         this.lblTIPE_Codigo.TabIndex = 13;
         this.lblTIPE_Codigo.Text = "Tipo de Entidad :";
         // 
         // lblENTC_Codigo
         // 
         this.lblENTC_Codigo.AutoSize = true;
         this.lblENTC_Codigo.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.lblENTC_Codigo.Location = new System.Drawing.Point(10, 61);
         this.lblENTC_Codigo.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
         this.lblENTC_Codigo.Name = "lblENTC_Codigo";
         this.lblENTC_Codigo.Size = new System.Drawing.Size(58, 13);
         this.lblENTC_Codigo.TabIndex = 15;
         this.lblENTC_Codigo.Text = "Entidad :";
         // 
         // txaENTC_Codigo
         // 
         this.txaENTC_Codigo.BackColor = System.Drawing.Color.LightSteelBlue;
         this.txaENTC_Codigo.CrearNuevaEntidad = false;
         this.txaENTC_Codigo.Location = new System.Drawing.Point(150, 54);
         this.txaENTC_Codigo.Margin = new System.Windows.Forms.Padding(0);
         this.txaENTC_Codigo.MinimumSize = new System.Drawing.Size(565, 27);
         this.txaENTC_Codigo.Name = "txaENTC_Codigo";
         this.txaENTC_Codigo.Size = new System.Drawing.Size(565, 27);
         this.txaENTC_Codigo.SoloEntidad = false;
         this.txaENTC_Codigo.TabIndex = 5;
         this.txaENTC_Codigo.TagEntidad = null;
         this.txaENTC_Codigo.TiposEntidad = Delfin.Controls.TiposEntidad.TIPE_AgenciaAduanera;
         this.txaENTC_Codigo.txaENTC_DOCIDEN_Name = "txaENTC_DOCIDEN";
         this.txaENTC_Codigo.txaENTC_NOMCOMPLETO_Name = "txaENTC_NOMCOMPLETO";
         // 
         // label8
         // 
         this.label8.AutoSize = true;
         this.label8.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.label8.Location = new System.Drawing.Point(375, 34);
         this.label8.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
         this.label8.Name = "label8";
         this.label8.Size = new System.Drawing.Size(111, 13);
         this.label8.TabIndex = 6;
         this.label8.Text = "Fecha de Emisión:";
         // 
         // DTPPDOV_FechaEmision
         // 
         this.DTPPDOV_FechaEmision.Format = System.Windows.Forms.DateTimePickerFormat.Short;
         this.DTPPDOV_FechaEmision.Location = new System.Drawing.Point(518, 30);
         this.DTPPDOV_FechaEmision.Name = "DTPPDOV_FechaEmision";
         this.DTPPDOV_FechaEmision.Size = new System.Drawing.Size(194, 20);
         this.DTPPDOV_FechaEmision.TabIndex = 7;
         this.DTPPDOV_FechaEmision.Tag = "DOCV_FechaEmisionMSGERROR";
         // 
         // panelCaption3
         // 
         this.panelCaption3.AllowActive = false;
         this.panelCaption3.AntiAlias = false;
         this.panelCaption3.Caption = "Datos para el Extorno";
         this.panelCaption3.Dock = System.Windows.Forms.DockStyle.Top;
         this.panelCaption3.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
         this.panelCaption3.InactiveGradientHighColor = System.Drawing.Color.SteelBlue;
         this.panelCaption3.InactiveGradientLowColor = System.Drawing.Color.MidnightBlue;
         this.panelCaption3.Location = new System.Drawing.Point(0, 50);
         this.panelCaption3.Name = "panelCaption3";
         this.panelCaption3.Size = new System.Drawing.Size(738, 26);
         this.panelCaption3.TabIndex = 4;
         // 
         // panel3
         // 
         this.panel3.BackColor = System.Drawing.Color.LightSteelBlue;
         this.panel3.Controls.Add(this.btnSalir);
         this.panel3.Controls.Add(this.btnAceptar);
         this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
         this.panel3.Location = new System.Drawing.Point(0, 0);
         this.panel3.Name = "panel3";
         this.panel3.Size = new System.Drawing.Size(738, 50);
         this.panel3.TabIndex = 3;
         // 
         // btnSalir
         // 
         this.btnSalir.AutoSize = true;
         this.btnSalir.DialogResult = System.Windows.Forms.DialogResult.Cancel;
         this.btnSalir.Dock = System.Windows.Forms.DockStyle.Left;
         this.btnSalir.FlatAppearance.BorderColor = System.Drawing.Color.LightSteelBlue;
         this.btnSalir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
         this.btnSalir.ForeColor = System.Drawing.Color.Black;
         this.btnSalir.Image = global::Delfin.Logistico.Properties.Resources.undo;
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
         // btnAceptar
         // 
         this.btnAceptar.AutoSize = true;
         this.btnAceptar.Dock = System.Windows.Forms.DockStyle.Left;
         this.btnAceptar.FlatAppearance.BorderColor = System.Drawing.Color.LightSteelBlue;
         this.btnAceptar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
         this.btnAceptar.ForeColor = System.Drawing.Color.Black;
         this.btnAceptar.Image = global::Delfin.Logistico.Properties.Resources.check;
         this.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
         this.btnAceptar.Location = new System.Drawing.Point(0, 0);
         this.btnAceptar.Margin = new System.Windows.Forms.Padding(0);
         this.btnAceptar.Name = "btnAceptar";
         this.btnAceptar.Size = new System.Drawing.Size(57, 50);
         this.btnAceptar.TabIndex = 0;
         this.btnAceptar.Text = "&Aceptar";
         this.btnAceptar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
         this.btnAceptar.UseVisualStyleBackColor = true;
         // 
         // panelCaption1
         // 
         this.panelCaption1.AllowActive = false;
         this.panelCaption1.AntiAlias = false;
         this.panelCaption1.Caption = "Datos para el Extorno";
         this.panelCaption1.Dock = System.Windows.Forms.DockStyle.Top;
         this.panelCaption1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
         this.panelCaption1.InactiveGradientHighColor = System.Drawing.Color.SteelBlue;
         this.panelCaption1.InactiveGradientLowColor = System.Drawing.Color.MidnightBlue;
         this.panelCaption1.Location = new System.Drawing.Point(0, 157);
         this.panelCaption1.Name = "panelCaption1";
         this.panelCaption1.Size = new System.Drawing.Size(738, 26);
         this.panelCaption1.TabIndex = 6;
         // 
         // tableLayoutPanel1
         // 
         this.tableLayoutPanel1.AutoSize = true;
         this.tableLayoutPanel1.ColumnCount = 10;
         this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
         this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
         this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15F));
         this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
         this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
         this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15F));
         this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
         this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
         this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15F));
         this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
         this.tableLayoutPanel1.Controls.Add(this.comboBoxTipoEntidad1, 1, 1);
         this.tableLayoutPanel1.Controls.Add(this.label1, 0, 1);
         this.tableLayoutPanel1.Controls.Add(this.label2, 0, 2);
         this.tableLayoutPanel1.Controls.Add(this.lblMOVI_Codigo, 0, 0);
         this.tableLayoutPanel1.Controls.Add(this.label4, 0, 3);
         this.tableLayoutPanel1.Controls.Add(this.dtpFecFin, 1, 3);
         this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
         this.tableLayoutPanel1.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
         this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 183);
         this.tableLayoutPanel1.Name = "tableLayoutPanel1";
         this.tableLayoutPanel1.RowCount = 4;
         this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
         this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
         this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
         this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
         this.tableLayoutPanel1.Size = new System.Drawing.Size(738, 108);
         this.tableLayoutPanel1.TabIndex = 7;
         // 
         // comboBoxTipoEntidad1
         // 
         this.comboBoxTipoEntidad1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this.comboBoxTipoEntidad1.FormattingEnabled = true;
         this.comboBoxTipoEntidad1.Location = new System.Drawing.Point(153, 30);
         this.comboBoxTipoEntidad1.Name = "comboBoxTipoEntidad1";
         this.comboBoxTipoEntidad1.Size = new System.Drawing.Size(194, 21);
         this.comboBoxTipoEntidad1.TabIndex = 18;
         this.comboBoxTipoEntidad1.TipoEntidadSelectedItem = null;
         this.comboBoxTipoEntidad1.TipoEntidadSelectedValue = null;
         this.comboBoxTipoEntidad1.TiposTitulo = null;
         // 
         // label1
         // 
         this.label1.AutoSize = true;
         this.label1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.label1.Location = new System.Drawing.Point(10, 34);
         this.label1.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
         this.label1.Name = "label1";
         this.label1.Size = new System.Drawing.Size(86, 13);
         this.label1.TabIndex = 17;
         this.label1.Text = "Tipo Entidad :";
         // 
         // label2
         // 
         this.label2.AutoSize = true;
         this.label2.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.label2.Location = new System.Drawing.Point(10, 61);
         this.label2.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
         this.label2.Name = "label2";
         this.label2.Size = new System.Drawing.Size(58, 13);
         this.label2.TabIndex = 4;
         this.label2.Text = "Entidad :";
         // 
         // lblMOVI_Codigo
         // 
         this.lblMOVI_Codigo.AutoSize = true;
         this.lblMOVI_Codigo.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.lblMOVI_Codigo.Location = new System.Drawing.Point(10, 7);
         this.lblMOVI_Codigo.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
         this.lblMOVI_Codigo.Name = "lblMOVI_Codigo";
         this.lblMOVI_Codigo.Size = new System.Drawing.Size(58, 13);
         this.lblMOVI_Codigo.TabIndex = 0;
         this.lblMOVI_Codigo.Text = "Interno :";
         // 
         // label4
         // 
         this.label4.AutoSize = true;
         this.label4.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.label4.Location = new System.Drawing.Point(10, 88);
         this.label4.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
         this.label4.Name = "label4";
         this.label4.Size = new System.Drawing.Size(54, 13);
         this.label4.TabIndex = 6;
         this.label4.Text = "Fecha :";
         // 
         // dtpFecFin
         // 
         this.dtpFecFin.Location = new System.Drawing.Point(153, 84);
         this.dtpFecFin.MinimumSize = new System.Drawing.Size(100, 22);
         this.dtpFecFin.Name = "dtpFecFin";
         this.dtpFecFin.NSActiveMouse = false;
         this.dtpFecFin.NSActiveMsgFecha = false;
         this.dtpFecFin.NSChangeDate = true;
         this.dtpFecFin.NSDigitos = 4;
         this.dtpFecFin.NSFecha = null;
         this.dtpFecFin.NSFormato = Infrastructure.WinForms.Controls.FormatoMostrado.Fecha;
         this.dtpFecFin.NSSetDateNow = false;
         this.dtpFecFin.Size = new System.Drawing.Size(100, 22);
         this.dtpFecFin.TabIndex = 7;
         // 
         // PRO007DViewAnulacion
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.BackColor = System.Drawing.Color.LightSteelBlue;
         this.ClientSize = new System.Drawing.Size(738, 322);
         this.Controls.Add(this.tableLayoutPanel1);
         this.Controls.Add(this.panelCaption1);
         this.Controls.Add(this.tableLayoutPanel3);
         this.Controls.Add(this.panelCaption3);
         this.Controls.Add(this.panel3);
         this.Name = "PRO007DViewAnulacion";
         this.Text = "PRO007DViewAnulacion";
         this.tableLayoutPanel3.ResumeLayout(false);
         this.tableLayoutPanel3.PerformLayout();
         this.panel3.ResumeLayout(false);
         this.panel3.PerformLayout();
         this.tableLayoutPanel1.ResumeLayout(false);
         this.tableLayoutPanel1.PerformLayout();
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
      private Infrastructure.WinForms.Controls.PanelCaption panelCaption3;
      private System.Windows.Forms.Panel panel3;
      private System.Windows.Forms.Button btnSalir;
      private System.Windows.Forms.Button btnAceptar;
      private Controls.Serie.SeriesLarge txaSeries;
      private System.Windows.Forms.Label label8;
      private System.Windows.Forms.DateTimePicker DTPPDOV_FechaEmision;
      private Controls.ComboBoxTipoEntidad cmbTIPE_Codigo;
      private System.Windows.Forms.Label lblENTC_Codigo;
      private System.Windows.Forms.Label lblTIPE_Codigo;
      private Infrastructure.WinForms.Controls.PanelCaption panelCaption1;
      private Controls.EntidadDocIden txaENTC_Codigo;
      private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
      private Controls.ComboBoxTipoEntidad comboBoxTipoEntidad1;
      private System.Windows.Forms.Label label1;
      private System.Windows.Forms.Label label2;
      private System.Windows.Forms.Label lblMOVI_Codigo;
      private System.Windows.Forms.Label label4;
      private Infrastructure.WinForms.Controls.MaskTime dtpFecFin;
   }
}