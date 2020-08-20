namespace Delfin.Principal
{
   partial class CAJ001CuentasBancariasLView
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
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CAJ001CuentasBancariasLView));
         this.cmsMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
         this.editarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.eliminarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.tsmColumnas = new System.Windows.Forms.ToolStripMenuItem();
         this.pnBotones = new System.Windows.Forms.Panel();
         this.btnDeshacer = new System.Windows.Forms.Button();
         this.btnExportar = new System.Windows.Forms.Button();
         this.btnBuscar = new System.Windows.Forms.Button();
         this.btnNuevo = new System.Windows.Forms.Button();
         this.panelCaption1 = new Infrastructure.WinForms.Controls.PanelCaption();
         this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
         this.label18 = new System.Windows.Forms.Label();
         this.chkCUBA_Bloqueo = new System.Windows.Forms.CheckBox();
         this.cmbCUBA_TipoCuenta = new Delfin.Controls.Tipos.ComboBoxConstantes();
         this.label4 = new System.Windows.Forms.Label();
         this.comboBox1 = new System.Windows.Forms.ComboBox();
         this.txtCUBA_Codigo = new System.Windows.Forms.TextBox();
         this.lblCONS_CodRGM = new System.Windows.Forms.Label();
         this.label3 = new System.Windows.Forms.Label();
         this.lblCUBA_FechaCierreIni = new System.Windows.Forms.Label();
         this.lblCUBA_FechaCierreFin = new System.Windows.Forms.Label();
         this.mdtCUBA_FechaCierreFin = new Infrastructure.WinForms.Controls.MaskDateTime();
         this.mdtCUBA_FechaCierreIni = new Infrastructure.WinForms.Controls.MaskDateTime();
         this.panelCaption2 = new Infrastructure.WinForms.Controls.PanelCaption();
         this.grdItems = new Telerik.WinControls.UI.RadGridView();
         this.TitleView = new Infrastructure.WinForms.Controls.FormTitle();
         this.navItems = new System.Windows.Forms.BindingNavigator(this.components);
         this.bindingNavigatorCountItem1 = new System.Windows.Forms.ToolStripLabel();
         this.bindingNavigatorMoveLastItem1 = new System.Windows.Forms.ToolStripButton();
         this.bindingNavigatorMoveNextItem1 = new System.Windows.Forms.ToolStripButton();
         this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
         this.bindingNavigatorPositionItem1 = new System.Windows.Forms.ToolStripTextBox();
         this.bindingNavigatorSeparator3 = new System.Windows.Forms.ToolStripSeparator();
         this.bindingNavigatorMovePreviousItem1 = new System.Windows.Forms.ToolStripButton();
         this.bindingNavigatorMoveFirstItem1 = new System.Windows.Forms.ToolStripButton();
         this.bindingNavigatorSeparator4 = new System.Windows.Forms.ToolStripSeparator();
         this.cmsMenu.SuspendLayout();
         this.pnBotones.SuspendLayout();
         this.tableLayoutPanel1.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.grdItems)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.grdItems.MasterTemplate)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.navItems)).BeginInit();
         this.navItems.SuspendLayout();
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
         this.pnBotones.Controls.Add(this.btnExportar);
         this.pnBotones.Controls.Add(this.btnBuscar);
         this.pnBotones.Controls.Add(this.btnNuevo);
         this.pnBotones.Dock = System.Windows.Forms.DockStyle.Top;
         this.pnBotones.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
         this.pnBotones.Location = new System.Drawing.Point(0, 26);
         this.pnBotones.Name = "pnBotones";
         this.pnBotones.Size = new System.Drawing.Size(1099, 50);
         this.pnBotones.TabIndex = 2;
         // 
         // btnDeshacer
         // 
         this.btnDeshacer.AutoSize = true;
         this.btnDeshacer.Dock = System.Windows.Forms.DockStyle.Left;
         this.btnDeshacer.FlatAppearance.BorderColor = System.Drawing.Color.SteelBlue;
         this.btnDeshacer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
         this.btnDeshacer.ForeColor = System.Drawing.Color.Black;
         this.btnDeshacer.Image = ((System.Drawing.Image)(resources.GetObject("btnDeshacer.Image")));
         this.btnDeshacer.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
         this.btnDeshacer.Location = new System.Drawing.Point(170, 0);
         this.btnDeshacer.Margin = new System.Windows.Forms.Padding(0);
         this.btnDeshacer.Name = "btnDeshacer";
         this.btnDeshacer.Size = new System.Drawing.Size(65, 50);
         this.btnDeshacer.TabIndex = 4;
         this.btnDeshacer.Text = "&Deshacer";
         this.btnDeshacer.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
         this.btnDeshacer.UseVisualStyleBackColor = true;
         // 
         // btnExportar
         // 
         this.btnExportar.AutoSize = true;
         this.btnExportar.Dock = System.Windows.Forms.DockStyle.Left;
         this.btnExportar.FlatAppearance.BorderColor = System.Drawing.Color.SteelBlue;
         this.btnExportar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
         this.btnExportar.ForeColor = System.Drawing.Color.Black;
         this.btnExportar.Image = global::Delfin.Principal.Properties.Resources.export;
         this.btnExportar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
         this.btnExportar.Location = new System.Drawing.Point(112, 0);
         this.btnExportar.Margin = new System.Windows.Forms.Padding(0);
         this.btnExportar.Name = "btnExportar";
         this.btnExportar.Size = new System.Drawing.Size(58, 50);
         this.btnExportar.TabIndex = 3;
         this.btnExportar.Text = "&Exportar";
         this.btnExportar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
         this.btnExportar.UseVisualStyleBackColor = true;
         // 
         // btnBuscar
         // 
         this.btnBuscar.AutoSize = true;
         this.btnBuscar.Dock = System.Windows.Forms.DockStyle.Left;
         this.btnBuscar.FlatAppearance.BorderColor = System.Drawing.Color.SteelBlue;
         this.btnBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
         this.btnBuscar.ForeColor = System.Drawing.Color.Black;
         this.btnBuscar.Image = global::Delfin.Principal.Properties.Resources.search;
         this.btnBuscar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
         this.btnBuscar.Location = new System.Drawing.Point(57, 0);
         this.btnBuscar.Margin = new System.Windows.Forms.Padding(0);
         this.btnBuscar.Name = "btnBuscar";
         this.btnBuscar.Size = new System.Drawing.Size(55, 50);
         this.btnBuscar.TabIndex = 1;
         this.btnBuscar.Text = "&Buscar";
         this.btnBuscar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
         this.btnBuscar.UseVisualStyleBackColor = true;
         // 
         // btnNuevo
         // 
         this.btnNuevo.AutoSize = true;
         this.btnNuevo.Dock = System.Windows.Forms.DockStyle.Left;
         this.btnNuevo.FlatAppearance.BorderColor = System.Drawing.Color.SteelBlue;
         this.btnNuevo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
         this.btnNuevo.ForeColor = System.Drawing.Color.Black;
         this.btnNuevo.Image = global::Delfin.Principal.Properties.Resources.add;
         this.btnNuevo.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
         this.btnNuevo.Location = new System.Drawing.Point(0, 0);
         this.btnNuevo.Margin = new System.Windows.Forms.Padding(0);
         this.btnNuevo.Name = "btnNuevo";
         this.btnNuevo.Size = new System.Drawing.Size(57, 50);
         this.btnNuevo.TabIndex = 0;
         this.btnNuevo.Text = "&Nuevo";
         this.btnNuevo.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
         this.btnNuevo.UseVisualStyleBackColor = true;
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
         this.panelCaption1.Size = new System.Drawing.Size(1099, 26);
         this.panelCaption1.TabIndex = 3;
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
         this.tableLayoutPanel1.Controls.Add(this.label18, 6, 1);
         this.tableLayoutPanel1.Controls.Add(this.chkCUBA_Bloqueo, 7, 1);
         this.tableLayoutPanel1.Controls.Add(this.cmbCUBA_TipoCuenta, 4, 0);
         this.tableLayoutPanel1.Controls.Add(this.label4, 3, 0);
         this.tableLayoutPanel1.Controls.Add(this.comboBox1, 7, 0);
         this.tableLayoutPanel1.Controls.Add(this.txtCUBA_Codigo, 1, 0);
         this.tableLayoutPanel1.Controls.Add(this.lblCONS_CodRGM, 0, 0);
         this.tableLayoutPanel1.Controls.Add(this.label3, 6, 0);
         this.tableLayoutPanel1.Controls.Add(this.lblCUBA_FechaCierreIni, 0, 1);
         this.tableLayoutPanel1.Controls.Add(this.lblCUBA_FechaCierreFin, 3, 1);
         this.tableLayoutPanel1.Controls.Add(this.mdtCUBA_FechaCierreFin, 4, 1);
         this.tableLayoutPanel1.Controls.Add(this.mdtCUBA_FechaCierreIni, 1, 1);
         this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
         this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 102);
         this.tableLayoutPanel1.Name = "tableLayoutPanel1";
         this.tableLayoutPanel1.RowCount = 3;
         this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
         this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
         this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 5F));
         this.tableLayoutPanel1.Size = new System.Drawing.Size(1099, 59);
         this.tableLayoutPanel1.TabIndex = 4;
         // 
         // label18
         // 
         this.label18.AutoSize = true;
         this.label18.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.label18.Location = new System.Drawing.Point(740, 34);
         this.label18.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
         this.label18.Name = "label18";
         this.label18.Size = new System.Drawing.Size(121, 13);
         this.label18.TabIndex = 10;
         this.label18.Text = "Cuenta Bloqueada :";
         // 
         // chkCUBA_Bloqueo
         // 
         this.chkCUBA_Bloqueo.AutoSize = true;
         this.chkCUBA_Bloqueo.Location = new System.Drawing.Point(886, 33);
         this.chkCUBA_Bloqueo.Margin = new System.Windows.Forms.Padding(6, 6, 3, 3);
         this.chkCUBA_Bloqueo.Name = "chkCUBA_Bloqueo";
         this.chkCUBA_Bloqueo.Size = new System.Drawing.Size(15, 14);
         this.chkCUBA_Bloqueo.TabIndex = 11;
         this.chkCUBA_Bloqueo.Tag = "CCOT_PropiaMSGERROR";
         this.chkCUBA_Bloqueo.UseVisualStyleBackColor = true;
         // 
         // cmbCUBA_TipoCuenta
         // 
         this.cmbCUBA_TipoCuenta.ConstantesSelectedItem = null;
         this.cmbCUBA_TipoCuenta.ConstantesSelectedValue = null;
         this.cmbCUBA_TipoCuenta.ConstantesTitulo = null;
         this.cmbCUBA_TipoCuenta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this.cmbCUBA_TipoCuenta.FormattingEnabled = true;
         this.cmbCUBA_TipoCuenta.Location = new System.Drawing.Point(518, 3);
         this.cmbCUBA_TipoCuenta.Name = "cmbCUBA_TipoCuenta";
         this.cmbCUBA_TipoCuenta.Session = null;
         this.cmbCUBA_TipoCuenta.Size = new System.Drawing.Size(194, 21);
         this.cmbCUBA_TipoCuenta.TabIndex = 3;
         // 
         // label4
         // 
         this.label4.AutoSize = true;
         this.label4.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.label4.Location = new System.Drawing.Point(375, 7);
         this.label4.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
         this.label4.Name = "label4";
         this.label4.Size = new System.Drawing.Size(103, 13);
         this.label4.TabIndex = 2;
         this.label4.Text = "Tipo de Cuenta :";
         // 
         // comboBox1
         // 
         this.comboBox1.FormattingEnabled = true;
         this.comboBox1.Location = new System.Drawing.Point(883, 3);
         this.comboBox1.Name = "comboBox1";
         this.comboBox1.Size = new System.Drawing.Size(194, 21);
         this.comboBox1.TabIndex = 5;
         // 
         // txtCUBA_Codigo
         // 
         this.txtCUBA_Codigo.Location = new System.Drawing.Point(153, 3);
         this.txtCUBA_Codigo.Name = "txtCUBA_Codigo";
         this.txtCUBA_Codigo.Size = new System.Drawing.Size(194, 20);
         this.txtCUBA_Codigo.TabIndex = 1;
         // 
         // lblCONS_CodRGM
         // 
         this.lblCONS_CodRGM.AutoSize = true;
         this.lblCONS_CodRGM.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.lblCONS_CodRGM.Location = new System.Drawing.Point(10, 7);
         this.lblCONS_CodRGM.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
         this.lblCONS_CodRGM.Name = "lblCONS_CodRGM";
         this.lblCONS_CodRGM.Size = new System.Drawing.Size(56, 13);
         this.lblCONS_CodRGM.TabIndex = 0;
         this.lblCONS_CodRGM.Text = "Código :";
         // 
         // label3
         // 
         this.label3.AutoSize = true;
         this.label3.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.label3.Location = new System.Drawing.Point(740, 7);
         this.label3.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
         this.label3.Name = "label3";
         this.label3.Size = new System.Drawing.Size(65, 13);
         this.label3.TabIndex = 4;
         this.label3.Text = "Sucursal :";
         // 
         // lblCUBA_FechaCierreIni
         // 
         this.lblCUBA_FechaCierreIni.AutoSize = true;
         this.lblCUBA_FechaCierreIni.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.lblCUBA_FechaCierreIni.Location = new System.Drawing.Point(10, 34);
         this.lblCUBA_FechaCierreIni.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
         this.lblCUBA_FechaCierreIni.Name = "lblCUBA_FechaCierreIni";
         this.lblCUBA_FechaCierreIni.Size = new System.Drawing.Size(114, 13);
         this.lblCUBA_FechaCierreIni.TabIndex = 6;
         this.lblCUBA_FechaCierreIni.Text = "Fec. Cierre Inicio :";
         // 
         // lblCUBA_FechaCierreFin
         // 
         this.lblCUBA_FechaCierreFin.AutoSize = true;
         this.lblCUBA_FechaCierreFin.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.lblCUBA_FechaCierreFin.Location = new System.Drawing.Point(375, 34);
         this.lblCUBA_FechaCierreFin.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
         this.lblCUBA_FechaCierreFin.Name = "lblCUBA_FechaCierreFin";
         this.lblCUBA_FechaCierreFin.Size = new System.Drawing.Size(99, 13);
         this.lblCUBA_FechaCierreFin.TabIndex = 8;
         this.lblCUBA_FechaCierreFin.Text = "Fec. Cierre Fin :";
         // 
         // mdtCUBA_FechaCierreFin
         // 
         this.mdtCUBA_FechaCierreFin.Dock = System.Windows.Forms.DockStyle.Fill;
         this.mdtCUBA_FechaCierreFin.Location = new System.Drawing.Point(519, 32);
         this.mdtCUBA_FechaCierreFin.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
         this.mdtCUBA_FechaCierreFin.MinimumSize = new System.Drawing.Size(100, 22);
         this.mdtCUBA_FechaCierreFin.Name = "mdtCUBA_FechaCierreFin";
         this.mdtCUBA_FechaCierreFin.NSActiveMouse = false;
         this.mdtCUBA_FechaCierreFin.NSActiveMsgFecha = false;
         this.mdtCUBA_FechaCierreFin.NSChangeDate = true;
         this.mdtCUBA_FechaCierreFin.NSDigitos = 4;
         this.mdtCUBA_FechaCierreFin.NSFecha = null;
         this.mdtCUBA_FechaCierreFin.NSSetDateNow = false;
         this.mdtCUBA_FechaCierreFin.Size = new System.Drawing.Size(192, 22);
         this.mdtCUBA_FechaCierreFin.TabIndex = 9;
         // 
         // mdtCUBA_FechaCierreIni
         // 
         this.mdtCUBA_FechaCierreIni.Dock = System.Windows.Forms.DockStyle.Fill;
         this.mdtCUBA_FechaCierreIni.Location = new System.Drawing.Point(154, 32);
         this.mdtCUBA_FechaCierreIni.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
         this.mdtCUBA_FechaCierreIni.MinimumSize = new System.Drawing.Size(100, 22);
         this.mdtCUBA_FechaCierreIni.Name = "mdtCUBA_FechaCierreIni";
         this.mdtCUBA_FechaCierreIni.NSActiveMouse = false;
         this.mdtCUBA_FechaCierreIni.NSActiveMsgFecha = false;
         this.mdtCUBA_FechaCierreIni.NSChangeDate = true;
         this.mdtCUBA_FechaCierreIni.NSDigitos = 4;
         this.mdtCUBA_FechaCierreIni.NSFecha = null;
         this.mdtCUBA_FechaCierreIni.NSSetDateNow = false;
         this.mdtCUBA_FechaCierreIni.Size = new System.Drawing.Size(192, 22);
         this.mdtCUBA_FechaCierreIni.TabIndex = 7;
         // 
         // panelCaption2
         // 
         this.panelCaption2.AllowActive = false;
         this.panelCaption2.AntiAlias = false;
         this.panelCaption2.Caption = "Resultado Búsqueda";
         this.panelCaption2.Dock = System.Windows.Forms.DockStyle.Top;
         this.panelCaption2.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
         this.panelCaption2.InactiveGradientHighColor = System.Drawing.Color.SteelBlue;
         this.panelCaption2.InactiveGradientLowColor = System.Drawing.Color.MidnightBlue;
         this.panelCaption2.Location = new System.Drawing.Point(0, 161);
         this.panelCaption2.Name = "panelCaption2";
         this.panelCaption2.Size = new System.Drawing.Size(1099, 26);
         this.panelCaption2.TabIndex = 5;
         // 
         // grdItems
         // 
         this.grdItems.BackColor = System.Drawing.SystemColors.ControlLightLight;
         this.grdItems.Dock = System.Windows.Forms.DockStyle.Fill;
         this.grdItems.Location = new System.Drawing.Point(0, 187);
         this.grdItems.Name = "grdItems";
         // 
         // 
         // 
         this.grdItems.RootElement.ControlBounds = new System.Drawing.Rectangle(0, 187, 240, 150);
         this.grdItems.Size = new System.Drawing.Size(1099, 238);
         this.grdItems.TabIndex = 6;
         this.grdItems.TabStop = false;
         // 
         // TitleView
         // 
         this.TitleView.AllowActive = false;
         this.TitleView.AntiAlias = false;
         this.TitleView.Caption = "CUENTAS BANCARIAS";
         this.TitleView.Dock = System.Windows.Forms.DockStyle.Top;
         this.TitleView.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.TitleView.FormIcon = ((System.Drawing.Image)(resources.GetObject("TitleView.FormIcon")));
         this.TitleView.InactiveGradientHighColor = System.Drawing.Color.SteelBlue;
         this.TitleView.InactiveGradientLowColor = System.Drawing.Color.MidnightBlue;
         this.TitleView.Location = new System.Drawing.Point(0, 0);
         this.TitleView.Name = "TitleView";
         this.TitleView.Size = new System.Drawing.Size(1099, 26);
         this.TitleView.TabIndex = 1;
         // 
         // navItems
         // 
         this.navItems.AddNewItem = null;
         this.navItems.BackColor = System.Drawing.Color.LightSteelBlue;
         this.navItems.CountItem = this.bindingNavigatorCountItem1;
         this.navItems.DeleteItem = null;
         this.navItems.Dock = System.Windows.Forms.DockStyle.Bottom;
         this.navItems.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveLastItem1,
            this.bindingNavigatorMoveNextItem1,
            this.bindingNavigatorSeparator2,
            this.bindingNavigatorCountItem1,
            this.bindingNavigatorPositionItem1,
            this.bindingNavigatorSeparator3,
            this.bindingNavigatorMovePreviousItem1,
            this.bindingNavigatorMoveFirstItem1,
            this.bindingNavigatorSeparator4});
         this.navItems.Location = new System.Drawing.Point(0, 425);
         this.navItems.MoveFirstItem = this.bindingNavigatorMoveFirstItem1;
         this.navItems.MoveLastItem = this.bindingNavigatorMoveLastItem1;
         this.navItems.MoveNextItem = this.bindingNavigatorMoveNextItem1;
         this.navItems.MovePreviousItem = this.bindingNavigatorMovePreviousItem1;
         this.navItems.Name = "navItems";
         this.navItems.PositionItem = this.bindingNavigatorPositionItem1;
         this.navItems.Size = new System.Drawing.Size(1099, 25);
         this.navItems.TabIndex = 0;
         this.navItems.Text = "bindingNavigator1";
         // 
         // bindingNavigatorCountItem1
         // 
         this.bindingNavigatorCountItem1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
         this.bindingNavigatorCountItem1.Name = "bindingNavigatorCountItem1";
         this.bindingNavigatorCountItem1.Size = new System.Drawing.Size(37, 22);
         this.bindingNavigatorCountItem1.Text = "de {0}";
         this.bindingNavigatorCountItem1.ToolTipText = "Número total de elementos";
         // 
         // bindingNavigatorMoveLastItem1
         // 
         this.bindingNavigatorMoveLastItem1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
         this.bindingNavigatorMoveLastItem1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
         this.bindingNavigatorMoveLastItem1.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveLastItem1.Image")));
         this.bindingNavigatorMoveLastItem1.Name = "bindingNavigatorMoveLastItem1";
         this.bindingNavigatorMoveLastItem1.RightToLeftAutoMirrorImage = true;
         this.bindingNavigatorMoveLastItem1.Size = new System.Drawing.Size(23, 22);
         this.bindingNavigatorMoveLastItem1.Text = "Mover último";
         // 
         // bindingNavigatorMoveNextItem1
         // 
         this.bindingNavigatorMoveNextItem1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
         this.bindingNavigatorMoveNextItem1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
         this.bindingNavigatorMoveNextItem1.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveNextItem1.Image")));
         this.bindingNavigatorMoveNextItem1.Name = "bindingNavigatorMoveNextItem1";
         this.bindingNavigatorMoveNextItem1.RightToLeftAutoMirrorImage = true;
         this.bindingNavigatorMoveNextItem1.Size = new System.Drawing.Size(23, 22);
         this.bindingNavigatorMoveNextItem1.Text = "Mover siguiente";
         // 
         // bindingNavigatorSeparator2
         // 
         this.bindingNavigatorSeparator2.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
         this.bindingNavigatorSeparator2.Name = "bindingNavigatorSeparator2";
         this.bindingNavigatorSeparator2.Size = new System.Drawing.Size(6, 25);
         // 
         // bindingNavigatorPositionItem1
         // 
         this.bindingNavigatorPositionItem1.AccessibleName = "Posición";
         this.bindingNavigatorPositionItem1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
         this.bindingNavigatorPositionItem1.AutoSize = false;
         this.bindingNavigatorPositionItem1.Name = "bindingNavigatorPositionItem1";
         this.bindingNavigatorPositionItem1.Size = new System.Drawing.Size(50, 23);
         this.bindingNavigatorPositionItem1.Text = "0";
         this.bindingNavigatorPositionItem1.ToolTipText = "Posición actual";
         // 
         // bindingNavigatorSeparator3
         // 
         this.bindingNavigatorSeparator3.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
         this.bindingNavigatorSeparator3.Name = "bindingNavigatorSeparator3";
         this.bindingNavigatorSeparator3.Size = new System.Drawing.Size(6, 25);
         // 
         // bindingNavigatorMovePreviousItem1
         // 
         this.bindingNavigatorMovePreviousItem1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
         this.bindingNavigatorMovePreviousItem1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
         this.bindingNavigatorMovePreviousItem1.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMovePreviousItem1.Image")));
         this.bindingNavigatorMovePreviousItem1.Name = "bindingNavigatorMovePreviousItem1";
         this.bindingNavigatorMovePreviousItem1.RightToLeftAutoMirrorImage = true;
         this.bindingNavigatorMovePreviousItem1.Size = new System.Drawing.Size(23, 22);
         this.bindingNavigatorMovePreviousItem1.Text = "Mover anterior";
         // 
         // bindingNavigatorMoveFirstItem1
         // 
         this.bindingNavigatorMoveFirstItem1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
         this.bindingNavigatorMoveFirstItem1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
         this.bindingNavigatorMoveFirstItem1.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveFirstItem1.Image")));
         this.bindingNavigatorMoveFirstItem1.Name = "bindingNavigatorMoveFirstItem1";
         this.bindingNavigatorMoveFirstItem1.RightToLeftAutoMirrorImage = true;
         this.bindingNavigatorMoveFirstItem1.Size = new System.Drawing.Size(23, 22);
         this.bindingNavigatorMoveFirstItem1.Text = "Mover primero";
         // 
         // bindingNavigatorSeparator4
         // 
         this.bindingNavigatorSeparator4.Name = "bindingNavigatorSeparator4";
         this.bindingNavigatorSeparator4.Size = new System.Drawing.Size(6, 25);
         // 
         // CAJ001CuentasBancariasLView
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.BackColor = System.Drawing.Color.LightSteelBlue;
         this.Controls.Add(this.grdItems);
         this.Controls.Add(this.navItems);
         this.Controls.Add(this.panelCaption2);
         this.Controls.Add(this.tableLayoutPanel1);
         this.Controls.Add(this.panelCaption1);
         this.Controls.Add(this.pnBotones);
         this.Controls.Add(this.TitleView);
         this.Name = "CAJ001CuentasBancariasLView";
         this.Size = new System.Drawing.Size(1099, 450);
         this.cmsMenu.ResumeLayout(false);
         this.pnBotones.ResumeLayout(false);
         this.pnBotones.PerformLayout();
         this.tableLayoutPanel1.ResumeLayout(false);
         this.tableLayoutPanel1.PerformLayout();
         ((System.ComponentModel.ISupportInitialize)(this.grdItems.MasterTemplate)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.grdItems)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.navItems)).EndInit();
         this.navItems.ResumeLayout(false);
         this.navItems.PerformLayout();
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.ContextMenuStrip cmsMenu;
      private System.Windows.Forms.ToolStripMenuItem editarToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem eliminarToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem tsmColumnas;
      private System.Windows.Forms.Panel pnBotones;
      private System.Windows.Forms.Button btnBuscar;
      private System.Windows.Forms.Button btnNuevo;
      private Infrastructure.WinForms.Controls.PanelCaption panelCaption1;
      private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
      private Infrastructure.WinForms.Controls.PanelCaption panelCaption2;
      private Telerik.WinControls.UI.RadGridView grdItems;
      private Infrastructure.WinForms.Controls.FormTitle TitleView;
      private System.Windows.Forms.BindingNavigator navItems;
      private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem1;
      private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem1;
      private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem1;
      private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator2;
      private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem1;
      private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator3;
      private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem1;
      private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem1;
      private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator4;
      private System.Windows.Forms.Label lblCONS_CodRGM;
      private System.Windows.Forms.TextBox txtCUBA_Codigo;
      private System.Windows.Forms.ComboBox comboBox1;
      private System.Windows.Forms.Label label3;
      private Controls.Tipos.ComboBoxConstantes cmbCUBA_TipoCuenta;
      private System.Windows.Forms.Label label4;
      private System.Windows.Forms.Label lblCUBA_FechaCierreIni;
      private System.Windows.Forms.Label lblCUBA_FechaCierreFin;
      private Infrastructure.WinForms.Controls.MaskDateTime mdtCUBA_FechaCierreFin;
      private Infrastructure.WinForms.Controls.MaskDateTime mdtCUBA_FechaCierreIni;
      private System.Windows.Forms.Button btnDeshacer;
      private System.Windows.Forms.Button btnExportar;
      private System.Windows.Forms.CheckBox chkCUBA_Bloqueo;
      private System.Windows.Forms.Label label18;

   }
}
