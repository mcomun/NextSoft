namespace Delfin.Principal
{
   partial class REP007AntiguedadDeudaLView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(REP007AntiguedadDeudaLView));
            this.TitleView = new Infrastructure.WinForms.Controls.FormTitle();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.dtpFecFin = new Infrastructure.WinForms.Controls.MaskTime();
            this.dtpFecIni = new Infrastructure.WinForms.Controls.MaskTime();
            this.txaENTC_Codigo = new Delfin.Controls.EntidadDocIden();
            this.cmbTIPE_Codigo = new Delfin.Controls.ComboBoxTipoEntidad();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblENTC_Codigo = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbSERI_UnidadNegocio = new Delfin.Controls.Tipos.ComboBoxConstantes();
            this.lblMBL = new System.Windows.Forms.Label();
            this.txtMBL = new System.Windows.Forms.TextBox();
            this.lblHBL = new System.Windows.Forms.Label();
            this.txtHBL = new System.Windows.Forms.TextBox();
            this.panelCaption1 = new Infrastructure.WinForms.Controls.PanelCaption();
            this.pnBotones = new System.Windows.Forms.Panel();
            this.btnImprimir = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.pnBotones.SuspendLayout();
            this.SuspendLayout();
            // 
            // TitleView
            // 
            this.TitleView.AllowActive = false;
            this.TitleView.AntiAlias = false;
            this.TitleView.Caption = "Estado de Cuenta del Cliente";
            this.TitleView.Dock = System.Windows.Forms.DockStyle.Top;
            this.TitleView.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TitleView.FormIcon = ((System.Drawing.Image)(resources.GetObject("TitleView.FormIcon")));
            this.TitleView.InactiveGradientHighColor = System.Drawing.Color.SteelBlue;
            this.TitleView.InactiveGradientLowColor = System.Drawing.Color.MidnightBlue;
            this.TitleView.Location = new System.Drawing.Point(0, 0);
            this.TitleView.Name = "TitleView";
            this.TitleView.Size = new System.Drawing.Size(1101, 26);
            this.TitleView.TabIndex = 52;
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
            this.tableLayoutPanel1.Controls.Add(this.dtpFecFin, 4, 1);
            this.tableLayoutPanel1.Controls.Add(this.dtpFecIni, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.txaENTC_Codigo, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.cmbTIPE_Codigo, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label4, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblENTC_Codigo, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label5, 6, 1);
            this.tableLayoutPanel1.Controls.Add(this.cmbSERI_UnidadNegocio, 7, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblMBL, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.txtMBL, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.lblHBL, 3, 2);
            this.tableLayoutPanel1.Controls.Add(this.txtHBL, 4, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 102);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1101, 108);
            this.tableLayoutPanel1.TabIndex = 55;
            // 
            // dtpFecFin
            // 
            this.dtpFecFin.Location = new System.Drawing.Point(518, 30);
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
            this.dtpFecFin.TabIndex = 57;
            // 
            // dtpFecIni
            // 
            this.dtpFecIni.Location = new System.Drawing.Point(153, 30);
            this.dtpFecIni.MinimumSize = new System.Drawing.Size(100, 22);
            this.dtpFecIni.Name = "dtpFecIni";
            this.dtpFecIni.NSActiveMouse = false;
            this.dtpFecIni.NSActiveMsgFecha = false;
            this.dtpFecIni.NSChangeDate = true;
            this.dtpFecIni.NSDigitos = 4;
            this.dtpFecIni.NSFecha = null;
            this.dtpFecIni.NSFormato = Infrastructure.WinForms.Controls.FormatoMostrado.Fecha;
            this.dtpFecIni.NSSetDateNow = false;
            this.dtpFecIni.Size = new System.Drawing.Size(100, 22);
            this.dtpFecIni.TabIndex = 56;
            // 
            // txaENTC_Codigo
            // 
            this.txaENTC_Codigo.BackColor = System.Drawing.Color.LightSteelBlue;
            this.txaENTC_Codigo.CrearNuevaEntidad = false;
            this.txaENTC_Codigo.Location = new System.Drawing.Point(515, 0);
            this.txaENTC_Codigo.Margin = new System.Windows.Forms.Padding(0);
            this.txaENTC_Codigo.MinimumSize = new System.Drawing.Size(565, 27);
            this.txaENTC_Codigo.Name = "txaENTC_Codigo";
            this.txaENTC_Codigo.Size = new System.Drawing.Size(565, 27);
            this.txaENTC_Codigo.TabIndex = 56;
            this.txaENTC_Codigo.TagEntidad = null;
            this.txaENTC_Codigo.TiposEntidad = Delfin.Controls.TiposEntidad.TIPE_AgenciaAduanera;
            this.txaENTC_Codigo.txaENTC_DOCIDEN_Name = "txaENTC_DOCIDEN";
            this.txaENTC_Codigo.txaENTC_NOMCOMPLETO_Name = "txaENTC_NOMCOMPLETO";
            // 
            // cmbTIPE_Codigo
            // 
            this.cmbTIPE_Codigo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTIPE_Codigo.FormattingEnabled = true;
            this.cmbTIPE_Codigo.Location = new System.Drawing.Point(153, 3);
            this.cmbTIPE_Codigo.Name = "cmbTIPE_Codigo";
            this.cmbTIPE_Codigo.Size = new System.Drawing.Size(194, 21);
            this.cmbTIPE_Codigo.TabIndex = 56;
            this.cmbTIPE_Codigo.TipoEntidadSelectedItem = null;
            this.cmbTIPE_Codigo.TipoEntidadSelectedValue = null;
            this.cmbTIPE_Codigo.TiposTitulo = null;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(375, 34);
            this.label4.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 13);
            this.label4.TabIndex = 57;
            this.label4.Text = "Fec. Termino :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(10, 34);
            this.label3.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 13);
            this.label3.TabIndex = 57;
            this.label3.Text = "Fec. Inicio :";
            // 
            // lblENTC_Codigo
            // 
            this.lblENTC_Codigo.AutoSize = true;
            this.lblENTC_Codigo.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblENTC_Codigo.Location = new System.Drawing.Point(375, 7);
            this.lblENTC_Codigo.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
            this.lblENTC_Codigo.Name = "lblENTC_Codigo";
            this.lblENTC_Codigo.Size = new System.Drawing.Size(58, 13);
            this.lblENTC_Codigo.TabIndex = 57;
            this.lblENTC_Codigo.Text = "Entidad :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(10, 7);
            this.label1.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 13);
            this.label1.TabIndex = 56;
            this.label1.Text = "Tipo de Entidad :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(740, 34);
            this.label5.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(122, 13);
            this.label5.TabIndex = 57;
            this.label5.Text = "Unidad de Negocio :";
            // 
            // cmbSERI_UnidadNegocio
            // 
            this.cmbSERI_UnidadNegocio.ConstantesSelectedItem = null;
            this.cmbSERI_UnidadNegocio.ConstantesSelectedValue = null;
            this.cmbSERI_UnidadNegocio.ConstantesTitulo = null;
            this.cmbSERI_UnidadNegocio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSERI_UnidadNegocio.FormattingEnabled = true;
            this.cmbSERI_UnidadNegocio.Location = new System.Drawing.Point(883, 30);
            this.cmbSERI_UnidadNegocio.Name = "cmbSERI_UnidadNegocio";
            this.cmbSERI_UnidadNegocio.Size = new System.Drawing.Size(194, 21);
            this.cmbSERI_UnidadNegocio.TabIndex = 56;
            // 
            // lblMBL
            // 
            this.lblMBL.AutoSize = true;
            this.lblMBL.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMBL.Location = new System.Drawing.Point(10, 61);
            this.lblMBL.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
            this.lblMBL.Name = "lblMBL";
            this.lblMBL.Size = new System.Drawing.Size(39, 13);
            this.lblMBL.TabIndex = 57;
            this.lblMBL.Text = "MBL :";
            // 
            // txtMBL
            // 
            this.txtMBL.Location = new System.Drawing.Point(153, 57);
            this.txtMBL.Name = "txtMBL";
            this.txtMBL.Size = new System.Drawing.Size(194, 20);
            this.txtMBL.TabIndex = 56;
            // 
            // lblHBL
            // 
            this.lblHBL.AutoSize = true;
            this.lblHBL.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHBL.Location = new System.Drawing.Point(375, 61);
            this.lblHBL.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
            this.lblHBL.Name = "lblHBL";
            this.lblHBL.Size = new System.Drawing.Size(38, 13);
            this.lblHBL.TabIndex = 57;
            this.lblHBL.Text = "HBL :";
            // 
            // txtHBL
            // 
            this.txtHBL.Location = new System.Drawing.Point(518, 57);
            this.txtHBL.Name = "txtHBL";
            this.txtHBL.Size = new System.Drawing.Size(194, 20);
            this.txtHBL.TabIndex = 57;
            // 
            // panelCaption1
            // 
            this.panelCaption1.AllowActive = false;
            this.panelCaption1.AntiAlias = false;
            this.panelCaption1.Caption = "Criterio de Búsqueda";
            this.panelCaption1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelCaption1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
            this.panelCaption1.InactiveGradientHighColor = System.Drawing.Color.SteelBlue;
            this.panelCaption1.InactiveGradientLowColor = System.Drawing.Color.MidnightBlue;
            this.panelCaption1.Location = new System.Drawing.Point(0, 76);
            this.panelCaption1.Name = "panelCaption1";
            this.panelCaption1.Size = new System.Drawing.Size(1101, 26);
            this.panelCaption1.TabIndex = 54;
            // 
            // pnBotones
            // 
            this.pnBotones.BackColor = System.Drawing.Color.LightSteelBlue;
            this.pnBotones.Controls.Add(this.btnImprimir);
            this.pnBotones.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnBotones.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.pnBotones.Location = new System.Drawing.Point(0, 26);
            this.pnBotones.Name = "pnBotones";
            this.pnBotones.Size = new System.Drawing.Size(1101, 50);
            this.pnBotones.TabIndex = 53;
            // 
            // btnImprimir
            // 
            this.btnImprimir.AutoSize = true;
            this.btnImprimir.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnImprimir.FlatAppearance.BorderColor = System.Drawing.Color.SteelBlue;
            this.btnImprimir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnImprimir.ForeColor = System.Drawing.Color.Black;
            this.btnImprimir.Image = global::Delfin.Principal.Properties.Resources.printer2;
            this.btnImprimir.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnImprimir.Location = new System.Drawing.Point(0, 0);
            this.btnImprimir.Margin = new System.Windows.Forms.Padding(0);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(58, 50);
            this.btnImprimir.TabIndex = 6;
            this.btnImprimir.Text = "&Imprimir";
            this.btnImprimir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnImprimir.UseVisualStyleBackColor = true;
            // 
            // REP007AntiguedadDeudaLView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.panelCaption1);
            this.Controls.Add(this.pnBotones);
            this.Controls.Add(this.TitleView);
            this.Name = "REP007AntiguedadDeudaLView";
            this.Size = new System.Drawing.Size(1101, 494);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.pnBotones.ResumeLayout(false);
            this.pnBotones.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

      }

      #endregion

      private Infrastructure.WinForms.Controls.FormTitle TitleView;
      private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
      private Infrastructure.WinForms.Controls.PanelCaption panelCaption1;
      private System.Windows.Forms.Panel pnBotones;
      private System.Windows.Forms.Button btnImprimir;
      private Infrastructure.WinForms.Controls.MaskTime dtpFecFin;
      private Infrastructure.WinForms.Controls.MaskTime dtpFecIni;
      private Controls.EntidadDocIden txaENTC_Codigo;
      private Controls.ComboBoxTipoEntidad cmbTIPE_Codigo;
      private System.Windows.Forms.Label label4;
      private System.Windows.Forms.Label label3;
      private System.Windows.Forms.Label lblENTC_Codigo;
      private System.Windows.Forms.Label label1;
      private System.Windows.Forms.Label label5;
      private Controls.Tipos.ComboBoxConstantes cmbSERI_UnidadNegocio;
      private System.Windows.Forms.Label lblMBL;
      private System.Windows.Forms.TextBox txtMBL;
      private System.Windows.Forms.Label lblHBL;
      private System.Windows.Forms.TextBox txtHBL;
   }
}
