namespace Delfin.Principal
{
   partial class REP007LView
   {
      /// <summary> 
      /// Variable del diseñador requerida.
      /// </summary>
      private System.ComponentModel.IContainer components = null;

      /// <summary> 
      /// Limpiar los recursos que se estén utilizando.
      /// </summary>
      /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario.</param>
      protected override void Dispose(bool disposing)
      {
         if (disposing && (components != null))
         {
            components.Dispose();
         }
         base.Dispose(disposing);
      }

      #region Código generado por el Diseñador de componentes

      /// <summary> 
      /// Método necesario para admitir el Diseñador. No se puede modificar 
      /// el contenido del método con el editor de código.
      /// </summary>
      private void InitializeComponent()
      {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(REP007LView));
            this.pnBotones = new System.Windows.Forms.Panel();
            this.btnDeshacer = new System.Windows.Forms.Button();
            this.btnReporteDetallado = new System.Windows.Forms.Button();
            this.btnReporteResumido = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lblCONT_FecIni = new System.Windows.Forms.Label();
            this.txtHBL = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.TxtNroOperacion = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.entidad1 = new Delfin.Controls.Entidad(this.components);
            this.mdtFecDesde = new Infrastructure.WinForms.Controls.MaskDateTime();
            this.mdtFecHasta = new Infrastructure.WinForms.Controls.MaskDateTime();
            this.panelCaption2 = new Infrastructure.WinFormsControls.PanelCaption();
            this.TitleView = new Infrastructure.WinFormsControls.FormTitle();
            this.RptImpresion = new Microsoft.Reporting.WinForms.ReportViewer();
            this.pnBotones.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnBotones
            // 
            this.pnBotones.BackColor = System.Drawing.Color.LightSteelBlue;
            this.pnBotones.Controls.Add(this.btnDeshacer);
            this.pnBotones.Controls.Add(this.btnReporteDetallado);
            this.pnBotones.Controls.Add(this.btnReporteResumido);
            this.pnBotones.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnBotones.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.pnBotones.Location = new System.Drawing.Point(0, 26);
            this.pnBotones.Name = "pnBotones";
            this.pnBotones.Size = new System.Drawing.Size(949, 50);
            this.pnBotones.TabIndex = 54;
            // 
            // btnDeshacer
            // 
            this.btnDeshacer.AutoSize = true;
            this.btnDeshacer.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnDeshacer.FlatAppearance.BorderColor = System.Drawing.Color.SteelBlue;
            this.btnDeshacer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeshacer.ForeColor = System.Drawing.Color.Black;
            this.btnDeshacer.Image = global::Delfin.Principal.Properties.Resources.undo;
            this.btnDeshacer.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnDeshacer.Location = new System.Drawing.Point(226, 0);
            this.btnDeshacer.Margin = new System.Windows.Forms.Padding(0);
            this.btnDeshacer.Name = "btnDeshacer";
            this.btnDeshacer.Size = new System.Drawing.Size(65, 50);
            this.btnDeshacer.TabIndex = 9;
            this.btnDeshacer.Text = "&Deshacer";
            this.btnDeshacer.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnDeshacer.UseVisualStyleBackColor = true;
            // 
            // btnReporteDetallado
            // 
            this.btnReporteDetallado.AutoSize = true;
            this.btnReporteDetallado.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnReporteDetallado.FlatAppearance.BorderColor = System.Drawing.Color.SteelBlue;
            this.btnReporteDetallado.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReporteDetallado.ForeColor = System.Drawing.Color.Black;
            this.btnReporteDetallado.Image = global::Delfin.Principal.Properties.Resources.printer2;
            this.btnReporteDetallado.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnReporteDetallado.Location = new System.Drawing.Point(114, 0);
            this.btnReporteDetallado.Margin = new System.Windows.Forms.Padding(0);
            this.btnReporteDetallado.Name = "btnReporteDetallado";
            this.btnReporteDetallado.Size = new System.Drawing.Size(112, 50);
            this.btnReporteDetallado.TabIndex = 8;
            this.btnReporteDetallado.Text = "&Impresión Detallado";
            this.btnReporteDetallado.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnReporteDetallado.UseVisualStyleBackColor = true;
            // 
            // btnReporteResumido
            // 
            this.btnReporteResumido.AutoSize = true;
            this.btnReporteResumido.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnReporteResumido.FlatAppearance.BorderColor = System.Drawing.Color.SteelBlue;
            this.btnReporteResumido.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReporteResumido.ForeColor = System.Drawing.Color.Black;
            this.btnReporteResumido.Image = global::Delfin.Principal.Properties.Resources.printer2;
            this.btnReporteResumido.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnReporteResumido.Location = new System.Drawing.Point(0, 0);
            this.btnReporteResumido.Margin = new System.Windows.Forms.Padding(0);
            this.btnReporteResumido.Name = "btnReporteResumido";
            this.btnReporteResumido.Size = new System.Drawing.Size(114, 50);
            this.btnReporteResumido.TabIndex = 6;
            this.btnReporteResumido.Text = "&Impresión Resumido";
            this.btnReporteResumido.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnReporteResumido.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.tableLayoutPanel1.ColumnCount = 5;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 168F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 118F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 166F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 347F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 337F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 57F));
            this.tableLayoutPanel1.Controls.Add(this.lblCONT_FecIni, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtHBL, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label1, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.TxtNroOperacion, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label6, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.label3, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.entidad1, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.mdtFecDesde, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.mdtFecHasta, 3, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 102);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(949, 81);
            this.tableLayoutPanel1.TabIndex = 52;
            // 
            // lblCONT_FecIni
            // 
            this.lblCONT_FecIni.AutoSize = true;
            this.lblCONT_FecIni.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCONT_FecIni.Location = new System.Drawing.Point(10, 7);
            this.lblCONT_FecIni.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
            this.lblCONT_FecIni.Name = "lblCONT_FecIni";
            this.lblCONT_FecIni.Size = new System.Drawing.Size(132, 13);
            this.lblCONT_FecIni.TabIndex = 12;
            this.lblCONT_FecIni.Text = "Fecha Emisión  Desde";
            // 
            // txtHBL
            // 
            this.txtHBL.Location = new System.Drawing.Point(153, 30);
            this.txtHBL.Name = "txtHBL";
            this.txtHBL.Size = new System.Drawing.Size(162, 20);
            this.txtHBL.TabIndex = 20;
            this.txtHBL.Tag = "CONT_DescripMSGERROR";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(328, 34);
            this.label1.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 13);
            this.label1.TabIndex = 17;
            this.label1.Text = "Nro. Operación :";
            // 
            // TxtNroOperacion
            // 
            this.TxtNroOperacion.Location = new System.Drawing.Point(439, 30);
            this.TxtNroOperacion.Name = "TxtNroOperacion";
            this.TxtNroOperacion.Size = new System.Drawing.Size(158, 20);
            this.TxtNroOperacion.TabIndex = 16;
            this.TxtNroOperacion.Tag = "CONT_DescripMSGERROR";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(10, 34);
            this.label2.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 19;
            this.label2.Text = "HBL :";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(10, 61);
            this.label6.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(56, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Cliente :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(328, 7);
            this.label3.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 13);
            this.label3.TabIndex = 21;
            this.label3.Text = "Hasta :";
            // 
            // entidad1
            // 
            this.entidad1.ActivarAyudaAuto = false;
            this.tableLayoutPanel1.SetColumnSpan(this.entidad1, 3);
            this.entidad1.ContainerService = null;
            this.entidad1.EnabledAyudaButton = true;
            this.entidad1.Location = new System.Drawing.Point(153, 57);
            this.entidad1.LongitudAceptada = 0;
            this.entidad1.MyInstanciaAyuda = Delfin.Controls.Entidad.InstanciaAyuda.Habilitado;
            this.entidad1.Name = "entidad1";
            this.entidad1.RellenaCeros = false;
            this.entidad1.Size = new System.Drawing.Size(444, 20);
            this.entidad1.TabIndex = 22;
            this.entidad1.Tipo = Delfin.Controls.Entidad.TipoTextBoxAyuda.AlfaNumerico;
            this.entidad1.TipoEntidad = Delfin.Controls.TiposEntidad.TIPE_Cliente;
            this.entidad1.Value = null;
            // 
            // mdtFecDesde
            // 
            this.mdtFecDesde.Location = new System.Drawing.Point(154, 5);
            this.mdtFecDesde.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.mdtFecDesde.MinimumSize = new System.Drawing.Size(100, 22);
            this.mdtFecDesde.Name = "mdtFecDesde";
            this.mdtFecDesde.NSActiveMouse = false;
            this.mdtFecDesde.NSActiveMsgFecha = false;
            this.mdtFecDesde.NSChangeDate = true;
            this.mdtFecDesde.NSDigitos = 4;
            this.mdtFecDesde.NSFecha = null;
            this.mdtFecDesde.NSSetDateNow = false;
            this.mdtFecDesde.Size = new System.Drawing.Size(101, 22);
            this.mdtFecDesde.TabIndex = 133;
            // 
            // mdtFecHasta
            // 
            this.mdtFecHasta.Location = new System.Drawing.Point(440, 5);
            this.mdtFecHasta.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.mdtFecHasta.MinimumSize = new System.Drawing.Size(100, 22);
            this.mdtFecHasta.Name = "mdtFecHasta";
            this.mdtFecHasta.NSActiveMouse = false;
            this.mdtFecHasta.NSActiveMsgFecha = false;
            this.mdtFecHasta.NSChangeDate = true;
            this.mdtFecHasta.NSDigitos = 4;
            this.mdtFecHasta.NSFecha = null;
            this.mdtFecHasta.NSSetDateNow = false;
            this.mdtFecHasta.Size = new System.Drawing.Size(101, 22);
            this.mdtFecHasta.TabIndex = 134;
            // 
            // panelCaption2
            // 
            this.panelCaption2.AllowActive = false;
            this.panelCaption2.AntiAlias = false;
            this.panelCaption2.Caption = "Criterio de Búsqueda";
            this.panelCaption2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelCaption2.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
            this.panelCaption2.InactiveGradientHighColor = System.Drawing.Color.SteelBlue;
            this.panelCaption2.InactiveGradientLowColor = System.Drawing.Color.MidnightBlue;
            this.panelCaption2.Location = new System.Drawing.Point(0, 76);
            this.panelCaption2.Name = "panelCaption2";
            this.panelCaption2.Size = new System.Drawing.Size(949, 26);
            this.panelCaption2.TabIndex = 55;
            // 
            // TitleView
            // 
            this.TitleView.AllowActive = false;
            this.TitleView.AntiAlias = false;
            this.TitleView.Caption = "Reporte Ingresos";
            this.TitleView.Dock = System.Windows.Forms.DockStyle.Top;
            this.TitleView.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TitleView.FormIcon = ((System.Drawing.Image)(resources.GetObject("TitleView.FormIcon")));
            this.TitleView.InactiveGradientHighColor = System.Drawing.Color.SteelBlue;
            this.TitleView.InactiveGradientLowColor = System.Drawing.Color.MidnightBlue;
            this.TitleView.Location = new System.Drawing.Point(0, 0);
            this.TitleView.Name = "TitleView";
            this.TitleView.Size = new System.Drawing.Size(949, 26);
            this.TitleView.TabIndex = 50;
            // 
            // RptImpresion
            // 
            this.RptImpresion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RptImpresion.Location = new System.Drawing.Point(0, 183);
            this.RptImpresion.Name = "RptImpresion";
            this.RptImpresion.Size = new System.Drawing.Size(949, 284);
            this.RptImpresion.TabIndex = 56;
            // 
            // REP007LView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.RptImpresion);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.panelCaption2);
            this.Controls.Add(this.pnBotones);
            this.Controls.Add(this.TitleView);
            this.Name = "REP007LView";
            this.Size = new System.Drawing.Size(949, 467);
            this.pnBotones.ResumeLayout(false);
            this.pnBotones.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.Panel pnBotones;
      private Infrastructure.WinFormsControls.FormTitle TitleView;
      private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
      private System.Windows.Forms.Label lblCONT_FecIni;
      private System.Windows.Forms.Label label6;
      private System.Windows.Forms.TextBox txtHBL;
      private System.Windows.Forms.Label label1;
      private System.Windows.Forms.TextBox TxtNroOperacion;
      private System.Windows.Forms.Label label2;
      private System.Windows.Forms.Label label3;
      private Infrastructure.WinFormsControls.PanelCaption panelCaption2;
      private System.Windows.Forms.Button btnReporteResumido;
      private Controls.Entidad entidad1;
      private Infrastructure.WinForms.Controls.MaskDateTime mdtFecDesde;
      private Infrastructure.WinForms.Controls.MaskDateTime mdtFecHasta;
      private System.Windows.Forms.Button btnDeshacer;
      private System.Windows.Forms.Button btnReporteDetallado;
      private Microsoft.Reporting.WinForms.ReportViewer RptImpresion;


   }
}
