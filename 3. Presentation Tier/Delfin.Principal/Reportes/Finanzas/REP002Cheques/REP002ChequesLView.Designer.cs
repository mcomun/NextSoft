namespace Delfin.Principal
{
   partial class REP002ChequesLView
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
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(REP002ChequesLView));
         this.TitleView = new Infrastructure.WinForms.Controls.FormTitle();
         this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
         this.label6 = new System.Windows.Forms.Label();
         this.cmbTipoCheque = new Delfin.Controls.Tipos.ComboBoxConstantes();
         this.cmbMOVI_EstadoCheque = new Delfin.Controls.Tipos.ComboBoxConstantes();
         this.label5 = new System.Windows.Forms.Label();
         this.dtpFecFin = new Infrastructure.WinForms.Controls.MaskTime();
         this.label4 = new System.Windows.Forms.Label();
         this.dtpFecIni = new Infrastructure.WinForms.Controls.MaskTime();
         this.label3 = new System.Windows.Forms.Label();
         this.cmbTIPO_CodBCO = new Delfin.Controls.Tipos.ComboBoxTipos();
         this.label2 = new System.Windows.Forms.Label();
         this.txaCUBA_Codigo = new Delfin.Controls.CuentaBancaria(this.components);
         this.label1 = new System.Windows.Forms.Label();
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
         this.TitleView.Caption = "Template Reporte";
         this.TitleView.Dock = System.Windows.Forms.DockStyle.Top;
         this.TitleView.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.TitleView.FormIcon = ((System.Drawing.Image)(resources.GetObject("TitleView.FormIcon")));
         this.TitleView.InactiveGradientHighColor = System.Drawing.Color.SteelBlue;
         this.TitleView.InactiveGradientLowColor = System.Drawing.Color.MidnightBlue;
         this.TitleView.Location = new System.Drawing.Point(0, 0);
         this.TitleView.Name = "TitleView";
         this.TitleView.Size = new System.Drawing.Size(746, 26);
         this.TitleView.TabIndex = 52;
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
         this.tableLayoutPanel1.Controls.Add(this.label6, 3, 2);
         this.tableLayoutPanel1.Controls.Add(this.cmbTipoCheque, 4, 2);
         this.tableLayoutPanel1.Controls.Add(this.cmbMOVI_EstadoCheque, 1, 2);
         this.tableLayoutPanel1.Controls.Add(this.label5, 0, 2);
         this.tableLayoutPanel1.Controls.Add(this.dtpFecFin, 4, 1);
         this.tableLayoutPanel1.Controls.Add(this.label4, 3, 1);
         this.tableLayoutPanel1.Controls.Add(this.dtpFecIni, 1, 1);
         this.tableLayoutPanel1.Controls.Add(this.label3, 0, 1);
         this.tableLayoutPanel1.Controls.Add(this.cmbTIPO_CodBCO, 4, 0);
         this.tableLayoutPanel1.Controls.Add(this.label2, 3, 0);
         this.tableLayoutPanel1.Controls.Add(this.txaCUBA_Codigo, 1, 0);
         this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
         this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
         this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 102);
         this.tableLayoutPanel1.Name = "tableLayoutPanel1";
         this.tableLayoutPanel1.RowCount = 4;
         this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
         this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
         this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
         this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
         this.tableLayoutPanel1.Size = new System.Drawing.Size(746, 108);
         this.tableLayoutPanel1.TabIndex = 55;
         // 
         // label6
         // 
         this.label6.AutoSize = true;
         this.label6.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.label6.Location = new System.Drawing.Point(375, 61);
         this.label6.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
         this.label6.Name = "label6";
         this.label6.Size = new System.Drawing.Size(40, 13);
         this.label6.TabIndex = 12;
         this.label6.Text = "Tipo :";
         // 
         // cmbTipoCheque
         // 
         this.cmbTipoCheque.ConstantesSelectedItem = null;
         this.cmbTipoCheque.ConstantesSelectedValue = null;
         this.cmbTipoCheque.ConstantesTitulo = null;
         this.cmbTipoCheque.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this.cmbTipoCheque.FormattingEnabled = true;
         this.cmbTipoCheque.Location = new System.Drawing.Point(518, 57);
         this.cmbTipoCheque.Name = "cmbTipoCheque";
         this.cmbTipoCheque.Session = null;
         this.cmbTipoCheque.Size = new System.Drawing.Size(194, 21);
         this.cmbTipoCheque.TabIndex = 7;
         // 
         // cmbMOVI_EstadoCheque
         // 
         this.cmbMOVI_EstadoCheque.ConstantesSelectedItem = null;
         this.cmbMOVI_EstadoCheque.ConstantesSelectedValue = null;
         this.cmbMOVI_EstadoCheque.ConstantesTitulo = null;
         this.cmbMOVI_EstadoCheque.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this.cmbMOVI_EstadoCheque.FormattingEnabled = true;
         this.cmbMOVI_EstadoCheque.Location = new System.Drawing.Point(153, 57);
         this.cmbMOVI_EstadoCheque.Name = "cmbMOVI_EstadoCheque";
         this.cmbMOVI_EstadoCheque.Session = null;
         this.cmbMOVI_EstadoCheque.Size = new System.Drawing.Size(194, 21);
         this.cmbMOVI_EstadoCheque.TabIndex = 7;
         // 
         // label5
         // 
         this.label5.AutoSize = true;
         this.label5.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.label5.Location = new System.Drawing.Point(10, 61);
         this.label5.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
         this.label5.Name = "label5";
         this.label5.Size = new System.Drawing.Size(54, 13);
         this.label5.TabIndex = 11;
         this.label5.Text = "Estado :";
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
         this.dtpFecFin.TabIndex = 9;
         // 
         // label4
         // 
         this.label4.AutoSize = true;
         this.label4.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.label4.Location = new System.Drawing.Point(375, 34);
         this.label4.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
         this.label4.Name = "label4";
         this.label4.Size = new System.Drawing.Size(85, 13);
         this.label4.TabIndex = 10;
         this.label4.Text = "Fecha Hasta :";
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
         this.dtpFecIni.TabIndex = 8;
         // 
         // label3
         // 
         this.label3.AutoSize = true;
         this.label3.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.label3.Location = new System.Drawing.Point(10, 34);
         this.label3.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
         this.label3.Name = "label3";
         this.label3.Size = new System.Drawing.Size(89, 13);
         this.label3.TabIndex = 10;
         this.label3.Text = "Fecha Desde :";
         // 
         // cmbTIPO_CodBCO
         // 
         this.cmbTIPO_CodBCO.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this.cmbTIPO_CodBCO.FormattingEnabled = true;
         this.cmbTIPO_CodBCO.Location = new System.Drawing.Point(518, 3);
         this.cmbTIPO_CodBCO.Name = "cmbTIPO_CodBCO";
         this.cmbTIPO_CodBCO.Session = null;
         this.cmbTIPO_CodBCO.Size = new System.Drawing.Size(194, 21);
         this.cmbTIPO_CodBCO.TabIndex = 8;
         this.cmbTIPO_CodBCO.TiposSelectedItem = null;
         this.cmbTIPO_CodBCO.TiposSelectedValue = null;
         this.cmbTIPO_CodBCO.TiposTitulo = null;
         // 
         // label2
         // 
         this.label2.AutoSize = true;
         this.label2.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.label2.Location = new System.Drawing.Point(375, 7);
         this.label2.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
         this.label2.Name = "label2";
         this.label2.Size = new System.Drawing.Size(112, 13);
         this.label2.TabIndex = 9;
         this.label2.Text = "Entidad Bancaria :";
         // 
         // txaCUBA_Codigo
         // 
         this.txaCUBA_Codigo.ActivarAyudaAuto = false;
         this.txaCUBA_Codigo.BackColor = System.Drawing.Color.White;
         this.txaCUBA_Codigo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
         this.txaCUBA_Codigo.EMPR_Codigo = ((short)(0));
         this.txaCUBA_Codigo.EnabledAyuda = true;
         this.txaCUBA_Codigo.EnabledAyudaButton = true;
         this.txaCUBA_Codigo.EsFiltro = false;
         this.txaCUBA_Codigo.Location = new System.Drawing.Point(153, 3);
         this.txaCUBA_Codigo.LongitudAceptada = 0;
         this.txaCUBA_Codigo.MaxLength = 100;
         this.txaCUBA_Codigo.MyInstanciaAyuda = Infrastructure.WinForms.Controls.TextBoxAyuda.InstanciaAyuda.Habilitado;
         this.txaCUBA_Codigo.Name = "txaCUBA_Codigo";
         this.txaCUBA_Codigo.RellenaCeros = false;
         this.txaCUBA_Codigo.SelectedItem = null;
         this.txaCUBA_Codigo.Size = new System.Drawing.Size(194, 20);
         this.txaCUBA_Codigo.TabIndex = 8;
         this.txaCUBA_Codigo.TAyuda = Delfin.Controls.CuentaBancaria.TipoAyuda.Normal;
         this.txaCUBA_Codigo.Tipo = Infrastructure.WinForms.Controls.TextBoxAyuda.TipoTextBoxAyuda.AlfaNumerico;
         this.txaCUBA_Codigo.Usuario = null;
         this.txaCUBA_Codigo.Value = null;
         // 
         // label1
         // 
         this.label1.AutoSize = true;
         this.label1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.label1.Location = new System.Drawing.Point(10, 7);
         this.label1.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
         this.label1.Name = "label1";
         this.label1.Size = new System.Drawing.Size(115, 13);
         this.label1.TabIndex = 8;
         this.label1.Text = "Cuenta Corriente :";
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
         this.panelCaption1.Size = new System.Drawing.Size(746, 26);
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
         this.pnBotones.Size = new System.Drawing.Size(746, 50);
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
         // REP002ChequesLView
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.Controls.Add(this.tableLayoutPanel1);
         this.Controls.Add(this.panelCaption1);
         this.Controls.Add(this.pnBotones);
         this.Controls.Add(this.TitleView);
         this.Name = "REP002ChequesLView";
         this.Size = new System.Drawing.Size(746, 417);
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
      private System.Windows.Forms.Label label1;
      private Controls.CuentaBancaria txaCUBA_Codigo;
      private System.Windows.Forms.Label label2;
      private Controls.Tipos.ComboBoxTipos cmbTIPO_CodBCO;
      private System.Windows.Forms.Label label3;
      private Infrastructure.WinForms.Controls.MaskTime dtpFecIni;
      private System.Windows.Forms.Label label4;
      private Infrastructure.WinForms.Controls.MaskTime dtpFecFin;
      private System.Windows.Forms.Label label6;
      private Controls.Tipos.ComboBoxConstantes cmbTipoCheque;
      private Controls.Tipos.ComboBoxConstantes cmbMOVI_EstadoCheque;
      private System.Windows.Forms.Label label5;
   }
}
