namespace Delfin.Principal
{
   partial class CAJ015AsientosContablesLView
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

      #region Component Designer generated code

      /// <summary> 
      /// Required method for Designer support - do not modify 
      /// the contents of this method with the code editor.
      /// </summary>
      private void InitializeComponent()
      {
         this.components = new System.ComponentModel.Container();
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CAJ015AsientosContablesLView));
         this.cmsMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
         this.editarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.eliminarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.tsmColumnas = new System.Windows.Forms.ToolStripMenuItem();
         this.pnBotones = new System.Windows.Forms.Panel();
         this.btnDeshacer = new System.Windows.Forms.Button();
         this.btnProcesarAsientos = new System.Windows.Forms.Button();
         this.panelCaption1 = new Infrastructure.WinForms.Controls.PanelCaption();
         this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
         this.txtPeriodo = new System.Windows.Forms.TextBox();
         this.label4 = new System.Windows.Forms.Label();
         this.cmbRegistro_1 = new Infrastructure.WinForms.Controls.ComboBox.ComboBox(this.components);
         this.txtNroAsiento = new System.Windows.Forms.TextBox();
         this.lblNroAsiento = new System.Windows.Forms.Label();
         this.cmbTipoAsiento = new Delfin.Controls.Tipos.ComboBoxConstantes();
         this.label3 = new System.Windows.Forms.Label();
         this.label1 = new System.Windows.Forms.Label();
         this.dtpFecFin = new Infrastructure.WinForms.Controls.MaskTime();
         this.dtpFecIni = new Infrastructure.WinForms.Controls.MaskTime();
         this.label2 = new System.Windows.Forms.Label();
         this.lblRegistro_1 = new System.Windows.Forms.Label();
         this.lblRegistro_2 = new System.Windows.Forms.Label();
         this.cmbRegistro_2 = new Delfin.Controls.Tipos.ComboBoxConstantes();
         this.lblVoucher_1 = new System.Windows.Forms.Label();
         this.txnVoucher_1 = new Infrastructure.WinForms.Controls.TextBoxNumerico();
         this.lblVoucher_2 = new System.Windows.Forms.Label();
         this.txnVoucher_2 = new Infrastructure.WinForms.Controls.TextBoxNumerico();
         this.TitleView = new Infrastructure.WinForms.Controls.FormTitle();
         this.cmsMenu.SuspendLayout();
         this.pnBotones.SuspendLayout();
         this.tableLayoutPanel1.SuspendLayout();
         this.SuspendLayout();
         // 
         // cmsMenu
         // 
         this.cmsMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editarToolStripMenuItem,
            this.eliminarToolStripMenuItem,
            this.tsmColumnas});
         this.cmsMenu.Name = "cmsMenu";
         this.cmsMenu.Size = new System.Drawing.Size(129, 70);
         // 
         // editarToolStripMenuItem
         // 
         this.editarToolStripMenuItem.Name = "editarToolStripMenuItem";
         this.editarToolStripMenuItem.Size = new System.Drawing.Size(128, 22);
         this.editarToolStripMenuItem.Text = "Editar";
         // 
         // eliminarToolStripMenuItem
         // 
         this.eliminarToolStripMenuItem.Name = "eliminarToolStripMenuItem";
         this.eliminarToolStripMenuItem.Size = new System.Drawing.Size(128, 22);
         this.eliminarToolStripMenuItem.Text = "Eliminar";
         // 
         // tsmColumnas
         // 
         this.tsmColumnas.Name = "tsmColumnas";
         this.tsmColumnas.Size = new System.Drawing.Size(128, 22);
         this.tsmColumnas.Text = "Columnas";
         // 
         // pnBotones
         // 
         this.pnBotones.BackColor = System.Drawing.Color.LightSteelBlue;
         this.pnBotones.Controls.Add(this.btnDeshacer);
         this.pnBotones.Controls.Add(this.btnProcesarAsientos);
         this.pnBotones.Dock = System.Windows.Forms.DockStyle.Top;
         this.pnBotones.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
         this.pnBotones.Location = new System.Drawing.Point(0, 26);
         this.pnBotones.Name = "pnBotones";
         this.pnBotones.Size = new System.Drawing.Size(1121, 50);
         this.pnBotones.TabIndex = 1;
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
         this.btnDeshacer.Location = new System.Drawing.Point(104, 0);
         this.btnDeshacer.Margin = new System.Windows.Forms.Padding(0);
         this.btnDeshacer.Name = "btnDeshacer";
         this.btnDeshacer.Size = new System.Drawing.Size(65, 50);
         this.btnDeshacer.TabIndex = 1;
         this.btnDeshacer.Text = "&Deshacer";
         this.btnDeshacer.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
         this.btnDeshacer.UseVisualStyleBackColor = true;
         // 
         // btnProcesarAsientos
         // 
         this.btnProcesarAsientos.AutoSize = true;
         this.btnProcesarAsientos.Dock = System.Windows.Forms.DockStyle.Left;
         this.btnProcesarAsientos.FlatAppearance.BorderColor = System.Drawing.Color.SteelBlue;
         this.btnProcesarAsientos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
         this.btnProcesarAsientos.ForeColor = System.Drawing.Color.Black;
         this.btnProcesarAsientos.Image = global::Delfin.Principal.Properties.Resources.document_out_24x24;
         this.btnProcesarAsientos.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
         this.btnProcesarAsientos.Location = new System.Drawing.Point(0, 0);
         this.btnProcesarAsientos.Margin = new System.Windows.Forms.Padding(0);
         this.btnProcesarAsientos.Name = "btnProcesarAsientos";
         this.btnProcesarAsientos.Size = new System.Drawing.Size(104, 50);
         this.btnProcesarAsientos.TabIndex = 0;
         this.btnProcesarAsientos.Text = "&Procesar Asientos";
         this.btnProcesarAsientos.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
         this.btnProcesarAsientos.UseVisualStyleBackColor = true;
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
         this.panelCaption1.Size = new System.Drawing.Size(1121, 26);
         this.panelCaption1.TabIndex = 2;
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
         this.tableLayoutPanel1.Controls.Add(this.txtPeriodo, 7, 0);
         this.tableLayoutPanel1.Controls.Add(this.label4, 6, 0);
         this.tableLayoutPanel1.Controls.Add(this.cmbRegistro_1, 1, 2);
         this.tableLayoutPanel1.Controls.Add(this.txtNroAsiento, 7, 1);
         this.tableLayoutPanel1.Controls.Add(this.lblNroAsiento, 6, 1);
         this.tableLayoutPanel1.Controls.Add(this.cmbTipoAsiento, 1, 1);
         this.tableLayoutPanel1.Controls.Add(this.label3, 0, 1);
         this.tableLayoutPanel1.Controls.Add(this.label1, 3, 0);
         this.tableLayoutPanel1.Controls.Add(this.dtpFecFin, 4, 0);
         this.tableLayoutPanel1.Controls.Add(this.dtpFecIni, 1, 0);
         this.tableLayoutPanel1.Controls.Add(this.label2, 0, 0);
         this.tableLayoutPanel1.Controls.Add(this.lblRegistro_1, 0, 2);
         this.tableLayoutPanel1.Controls.Add(this.lblRegistro_2, 0, 3);
         this.tableLayoutPanel1.Controls.Add(this.cmbRegistro_2, 1, 3);
         this.tableLayoutPanel1.Controls.Add(this.lblVoucher_1, 3, 2);
         this.tableLayoutPanel1.Controls.Add(this.txnVoucher_1, 4, 2);
         this.tableLayoutPanel1.Controls.Add(this.lblVoucher_2, 3, 3);
         this.tableLayoutPanel1.Controls.Add(this.txnVoucher_2, 4, 3);
         this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
         this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 102);
         this.tableLayoutPanel1.Name = "tableLayoutPanel1";
         this.tableLayoutPanel1.RowCount = 4;
         this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
         this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
         this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
         this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
         this.tableLayoutPanel1.Size = new System.Drawing.Size(1121, 108);
         this.tableLayoutPanel1.TabIndex = 3;
         // 
         // txtPeriodo
         // 
         this.txtPeriodo.Location = new System.Drawing.Point(883, 3);
         this.txtPeriodo.Name = "txtPeriodo";
         this.txtPeriodo.Size = new System.Drawing.Size(194, 20);
         this.txtPeriodo.TabIndex = 8;
         // 
         // label4
         // 
         this.label4.AutoSize = true;
         this.label4.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.label4.Location = new System.Drawing.Point(740, 7);
         this.label4.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
         this.label4.Name = "label4";
         this.label4.Size = new System.Drawing.Size(133, 13);
         this.label4.TabIndex = 7;
         this.label4.Text = "Año / Mes (AAAAMM):";
         // 
         // cmbRegistro_1
         // 
         this.cmbRegistro_1.ComboIntSelectedValue = null;
         this.cmbRegistro_1.ComboSelectedItem = null;
         this.cmbRegistro_1.ComboStrSelectedValue = null;
         this.cmbRegistro_1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this.cmbRegistro_1.DropDownWidth = 350;
         this.cmbRegistro_1.FormattingEnabled = true;
         this.cmbRegistro_1.Location = new System.Drawing.Point(153, 57);
         this.cmbRegistro_1.Name = "cmbRegistro_1";
         this.cmbRegistro_1.Size = new System.Drawing.Size(194, 21);
         this.cmbRegistro_1.TabIndex = 2;
         // 
         // txtNroAsiento
         // 
         this.txtNroAsiento.Location = new System.Drawing.Point(883, 30);
         this.txtNroAsiento.Name = "txtNroAsiento";
         this.txtNroAsiento.Size = new System.Drawing.Size(194, 20);
         this.txtNroAsiento.TabIndex = 7;
         // 
         // lblNroAsiento
         // 
         this.lblNroAsiento.AutoSize = true;
         this.lblNroAsiento.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.lblNroAsiento.Location = new System.Drawing.Point(740, 34);
         this.lblNroAsiento.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
         this.lblNroAsiento.Name = "lblNroAsiento";
         this.lblNroAsiento.Size = new System.Drawing.Size(82, 13);
         this.lblNroAsiento.TabIndex = 6;
         this.lblNroAsiento.Text = "Nro Asiento :";
         // 
         // cmbTipoAsiento
         // 
         this.tableLayoutPanel1.SetColumnSpan(this.cmbTipoAsiento, 4);
         this.cmbTipoAsiento.ConstantesSelectedItem = null;
         this.cmbTipoAsiento.ConstantesSelectedValue = null;
         this.cmbTipoAsiento.ConstantesTitulo = null;
         this.cmbTipoAsiento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this.cmbTipoAsiento.FormattingEnabled = true;
         this.cmbTipoAsiento.Location = new System.Drawing.Point(153, 30);
         this.cmbTipoAsiento.Name = "cmbTipoAsiento";
         this.cmbTipoAsiento.Session = null;
         this.cmbTipoAsiento.Size = new System.Drawing.Size(559, 21);
         this.cmbTipoAsiento.TabIndex = 5;
         // 
         // label3
         // 
         this.label3.AutoSize = true;
         this.label3.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.label3.Location = new System.Drawing.Point(10, 34);
         this.label3.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
         this.label3.Name = "label3";
         this.label3.Size = new System.Drawing.Size(104, 13);
         this.label3.TabIndex = 4;
         this.label3.Text = "Tipo de Asiento :";
         // 
         // label1
         // 
         this.label1.AutoSize = true;
         this.label1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.label1.Location = new System.Drawing.Point(375, 7);
         this.label1.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
         this.label1.Name = "label1";
         this.label1.Size = new System.Drawing.Size(85, 13);
         this.label1.TabIndex = 2;
         this.label1.Text = "Fecha Hasta :";
         // 
         // dtpFecFin
         // 
         this.dtpFecFin.Location = new System.Drawing.Point(518, 3);
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
         this.dtpFecFin.TabIndex = 3;
         // 
         // dtpFecIni
         // 
         this.dtpFecIni.Location = new System.Drawing.Point(153, 3);
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
         this.dtpFecIni.TabIndex = 1;
         // 
         // label2
         // 
         this.label2.AutoSize = true;
         this.label2.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.label2.Location = new System.Drawing.Point(10, 7);
         this.label2.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
         this.label2.Name = "label2";
         this.label2.Size = new System.Drawing.Size(89, 13);
         this.label2.TabIndex = 0;
         this.label2.Text = "Fecha Desde :";
         // 
         // lblRegistro_1
         // 
         this.lblRegistro_1.AutoSize = true;
         this.lblRegistro_1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.lblRegistro_1.Location = new System.Drawing.Point(10, 61);
         this.lblRegistro_1.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
         this.lblRegistro_1.Name = "lblRegistro_1";
         this.lblRegistro_1.Size = new System.Drawing.Size(108, 13);
         this.lblRegistro_1.TabIndex = 8;
         this.lblRegistro_1.Text = "Registro  / Libro :";
         // 
         // lblRegistro_2
         // 
         this.lblRegistro_2.AutoSize = true;
         this.lblRegistro_2.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.lblRegistro_2.Location = new System.Drawing.Point(10, 88);
         this.lblRegistro_2.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
         this.lblRegistro_2.Name = "lblRegistro_2";
         this.lblRegistro_2.Size = new System.Drawing.Size(108, 13);
         this.lblRegistro_2.TabIndex = 12;
         this.lblRegistro_2.Text = "Registro  / Libro :";
         // 
         // cmbRegistro_2
         // 
         this.cmbRegistro_2.ConstantesSelectedItem = null;
         this.cmbRegistro_2.ConstantesSelectedValue = null;
         this.cmbRegistro_2.ConstantesTitulo = null;
         this.cmbRegistro_2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this.cmbRegistro_2.FormattingEnabled = true;
         this.cmbRegistro_2.Location = new System.Drawing.Point(153, 84);
         this.cmbRegistro_2.Name = "cmbRegistro_2";
         this.cmbRegistro_2.Session = null;
         this.cmbRegistro_2.Size = new System.Drawing.Size(194, 21);
         this.cmbRegistro_2.TabIndex = 13;
         // 
         // lblVoucher_1
         // 
         this.lblVoucher_1.AutoSize = true;
         this.lblVoucher_1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.lblVoucher_1.Location = new System.Drawing.Point(375, 61);
         this.lblVoucher_1.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
         this.lblVoucher_1.Name = "lblVoucher_1";
         this.lblVoucher_1.Size = new System.Drawing.Size(111, 13);
         this.lblVoucher_1.TabIndex = 10;
         this.lblVoucher_1.Text = "Número Voucher :";
         // 
         // txnVoucher_1
         // 
         this.txnVoucher_1.BaseTipo = Infrastructure.WinForms.Controls.EstandaresFormato.Ninguno;
         this.txnVoucher_1.Decimales = 0;
         this.txnVoucher_1.Enteros = 9;
         this.txnVoucher_1.Formato = "###,###,##0.";
         this.txnVoucher_1.Location = new System.Drawing.Point(518, 57);
         this.txnVoucher_1.MaxLength = 10;
         this.txnVoucher_1.Name = "txnVoucher_1";
         this.txnVoucher_1.Negativo = true;
         this.txnVoucher_1.SinFormato = false;
         this.txnVoucher_1.Size = new System.Drawing.Size(194, 20);
         this.txnVoucher_1.TabIndex = 11;
         this.txnVoucher_1.Text = "0";
         this.txnVoucher_1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
         this.txnVoucher_1.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
         // 
         // lblVoucher_2
         // 
         this.lblVoucher_2.AutoSize = true;
         this.lblVoucher_2.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.lblVoucher_2.Location = new System.Drawing.Point(375, 88);
         this.lblVoucher_2.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
         this.lblVoucher_2.Name = "lblVoucher_2";
         this.lblVoucher_2.Size = new System.Drawing.Size(111, 13);
         this.lblVoucher_2.TabIndex = 14;
         this.lblVoucher_2.Text = "Número Voucher :";
         // 
         // txnVoucher_2
         // 
         this.txnVoucher_2.BaseTipo = Infrastructure.WinForms.Controls.EstandaresFormato.Ninguno;
         this.txnVoucher_2.Decimales = 0;
         this.txnVoucher_2.Enteros = 9;
         this.txnVoucher_2.Formato = "###,###,##0.";
         this.txnVoucher_2.Location = new System.Drawing.Point(518, 84);
         this.txnVoucher_2.MaxLength = 10;
         this.txnVoucher_2.Name = "txnVoucher_2";
         this.txnVoucher_2.Negativo = true;
         this.txnVoucher_2.SinFormato = false;
         this.txnVoucher_2.Size = new System.Drawing.Size(194, 20);
         this.txnVoucher_2.TabIndex = 15;
         this.txnVoucher_2.Text = "0";
         this.txnVoucher_2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
         this.txnVoucher_2.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
         // 
         // TitleView
         // 
         this.TitleView.AllowActive = false;
         this.TitleView.AntiAlias = false;
         this.TitleView.Caption = "GENERAR ASIENTOS CONTABLES";
         this.TitleView.Dock = System.Windows.Forms.DockStyle.Top;
         this.TitleView.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.TitleView.FormIcon = ((System.Drawing.Image)(resources.GetObject("TitleView.FormIcon")));
         this.TitleView.InactiveGradientHighColor = System.Drawing.Color.SteelBlue;
         this.TitleView.InactiveGradientLowColor = System.Drawing.Color.MidnightBlue;
         this.TitleView.Location = new System.Drawing.Point(0, 0);
         this.TitleView.Name = "TitleView";
         this.TitleView.Size = new System.Drawing.Size(1121, 26);
         this.TitleView.TabIndex = 0;
         // 
         // CAJ015AsientosContablesLView
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.BackColor = System.Drawing.Color.LightSteelBlue;
         this.Controls.Add(this.tableLayoutPanel1);
         this.Controls.Add(this.panelCaption1);
         this.Controls.Add(this.pnBotones);
         this.Controls.Add(this.TitleView);
         this.Name = "CAJ015AsientosContablesLView";
         this.Size = new System.Drawing.Size(1121, 450);
         this.cmsMenu.ResumeLayout(false);
         this.pnBotones.ResumeLayout(false);
         this.pnBotones.PerformLayout();
         this.tableLayoutPanel1.ResumeLayout(false);
         this.tableLayoutPanel1.PerformLayout();
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.ContextMenuStrip cmsMenu;
      private System.Windows.Forms.ToolStripMenuItem editarToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem eliminarToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem tsmColumnas;
      private System.Windows.Forms.Panel pnBotones;
      private System.Windows.Forms.Button btnDeshacer;
      private System.Windows.Forms.Button btnProcesarAsientos;
      private Infrastructure.WinForms.Controls.PanelCaption panelCaption1;
      private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
      private Infrastructure.WinForms.Controls.FormTitle TitleView;
      private System.Windows.Forms.Label label2;
      private System.Windows.Forms.Label label1;
      private Infrastructure.WinForms.Controls.MaskTime dtpFecFin;
      private Infrastructure.WinForms.Controls.MaskTime dtpFecIni;
      private Controls.Tipos.ComboBoxConstantes cmbTipoAsiento;
      private System.Windows.Forms.Label label3;
      private Infrastructure.WinForms.Controls.TextBoxNumerico txnVoucher_1;
      private System.Windows.Forms.Label lblRegistro_1;
      private System.Windows.Forms.Label lblVoucher_1;
      private Infrastructure.WinForms.Controls.TextBoxNumerico txnVoucher_2;
      private System.Windows.Forms.Label lblVoucher_2;
      private Controls.Tipos.ComboBoxConstantes cmbRegistro_2;
      private System.Windows.Forms.Label lblRegistro_2;
      private System.Windows.Forms.TextBox txtNroAsiento;
      private System.Windows.Forms.Label lblNroAsiento;
      private Infrastructure.WinForms.Controls.ComboBox.ComboBox cmbRegistro_1;
      private System.Windows.Forms.TextBox txtPeriodo;
      private System.Windows.Forms.Label label4;

   }
}
