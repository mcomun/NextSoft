namespace Delfin.Principal
{
    partial class REP009FlujoCajaLView
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
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(REP009FlujoCajaLView));
         this.TitleView = new Infrastructure.WinForms.Controls.FormTitle();
         this.pnBotones = new System.Windows.Forms.Panel();
         this.button2 = new System.Windows.Forms.Button();
         this.btnEnviarExcel = new System.Windows.Forms.Button();
         this.panelCaption1 = new Infrastructure.WinForms.Controls.PanelCaption();
         this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
         this.cmbTIPO_CodBCO = new Delfin.Controls.Tipos.ComboBoxTipos();
         this.label5 = new System.Windows.Forms.Label();
         this.label2 = new System.Windows.Forms.Label();
         this.label1 = new System.Windows.Forms.Label();
         this.txaCUBA_Codigo = new Delfin.Controls.CuentaBancaria(this.components);
         this.cmbTIPO = new Delfin.Controls.Tipos.ComboBoxConstantes();
         this.label4 = new System.Windows.Forms.Label();
         this.cmbPeriodo = new Infrastructure.WinForms.Controls.ComboBox.ComboBox(this.components);
         this.cmbTIPO_CodMND = new Delfin.Controls.Tipos.ComboBoxTipos();
         this.label3 = new System.Windows.Forms.Label();
         this.chkIncluirDiferidos = new System.Windows.Forms.CheckBox();
         this.pgbar = new System.Windows.Forms.ProgressBar();
         this.pnlResultado = new System.Windows.Forms.Panel();
         this.panelCaption2 = new Infrastructure.WinForms.Controls.PanelCaption();
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
         this.grdItems = new Telerik.WinControls.UI.RadGridView();
         this.btnReporte = new System.Windows.Forms.Button();
         this.pnBotones.SuspendLayout();
         this.tableLayoutPanel1.SuspendLayout();
         this.pnlResultado.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.navItems)).BeginInit();
         this.navItems.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.grdItems)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.grdItems.MasterTemplate)).BeginInit();
         this.SuspendLayout();
         // 
         // TitleView
         // 
         this.TitleView.AllowActive = false;
         this.TitleView.AntiAlias = false;
         this.TitleView.Caption = "Flujo de Caja";
         this.TitleView.Dock = System.Windows.Forms.DockStyle.Top;
         this.TitleView.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.TitleView.FormIcon = ((System.Drawing.Image)(resources.GetObject("TitleView.FormIcon")));
         this.TitleView.InactiveGradientHighColor = System.Drawing.Color.SteelBlue;
         this.TitleView.InactiveGradientLowColor = System.Drawing.Color.MidnightBlue;
         this.TitleView.Location = new System.Drawing.Point(0, 0);
         this.TitleView.Name = "TitleView";
         this.TitleView.Size = new System.Drawing.Size(1102, 26);
         this.TitleView.TabIndex = 1;
         // 
         // pnBotones
         // 
         this.pnBotones.BackColor = System.Drawing.Color.LightSteelBlue;
         this.pnBotones.Controls.Add(this.button2);
         this.pnBotones.Controls.Add(this.btnReporte);
         this.pnBotones.Controls.Add(this.btnEnviarExcel);
         this.pnBotones.Dock = System.Windows.Forms.DockStyle.Top;
         this.pnBotones.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
         this.pnBotones.Location = new System.Drawing.Point(0, 26);
         this.pnBotones.Name = "pnBotones";
         this.pnBotones.Size = new System.Drawing.Size(1102, 50);
         this.pnBotones.TabIndex = 2;
         // 
         // button2
         // 
         this.button2.AutoSize = true;
         this.button2.Dock = System.Windows.Forms.DockStyle.Left;
         this.button2.FlatAppearance.BorderColor = System.Drawing.Color.SteelBlue;
         this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
         this.button2.ForeColor = System.Drawing.Color.Black;
         this.button2.Image = global::Delfin.Principal.Properties.Resources.undo;
         this.button2.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
         this.button2.Location = new System.Drawing.Point(185, 0);
         this.button2.Margin = new System.Windows.Forms.Padding(0);
         this.button2.Name = "button2";
         this.button2.Size = new System.Drawing.Size(58, 50);
         this.button2.TabIndex = 8;
         this.button2.Text = "&Salir";
         this.button2.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
         this.button2.UseVisualStyleBackColor = true;
         // 
         // btnEnviarExcel
         // 
         this.btnEnviarExcel.AutoSize = true;
         this.btnEnviarExcel.Dock = System.Windows.Forms.DockStyle.Left;
         this.btnEnviarExcel.FlatAppearance.BorderColor = System.Drawing.Color.SteelBlue;
         this.btnEnviarExcel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
         this.btnEnviarExcel.ForeColor = System.Drawing.Color.Black;
         this.btnEnviarExcel.Image = global::Delfin.Principal.Properties.Resources.document_into;
         this.btnEnviarExcel.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
         this.btnEnviarExcel.Location = new System.Drawing.Point(0, 0);
         this.btnEnviarExcel.Margin = new System.Windows.Forms.Padding(0);
         this.btnEnviarExcel.Name = "btnEnviarExcel";
         this.btnEnviarExcel.Size = new System.Drawing.Size(87, 50);
         this.btnEnviarExcel.TabIndex = 7;
         this.btnEnviarExcel.Text = "&Enviar a Excel";
         this.btnEnviarExcel.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
         this.btnEnviarExcel.UseVisualStyleBackColor = true;
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
         this.panelCaption1.Size = new System.Drawing.Size(1102, 26);
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
         this.tableLayoutPanel1.Controls.Add(this.cmbTIPO_CodBCO, 7, 1);
         this.tableLayoutPanel1.Controls.Add(this.label5, 6, 1);
         this.tableLayoutPanel1.Controls.Add(this.label2, 3, 0);
         this.tableLayoutPanel1.Controls.Add(this.label1, 0, 1);
         this.tableLayoutPanel1.Controls.Add(this.txaCUBA_Codigo, 1, 1);
         this.tableLayoutPanel1.Controls.Add(this.cmbTIPO, 1, 0);
         this.tableLayoutPanel1.Controls.Add(this.label4, 0, 0);
         this.tableLayoutPanel1.Controls.Add(this.cmbPeriodo, 4, 0);
         this.tableLayoutPanel1.Controls.Add(this.cmbTIPO_CodMND, 4, 1);
         this.tableLayoutPanel1.Controls.Add(this.label3, 3, 1);
         this.tableLayoutPanel1.Controls.Add(this.chkIncluirDiferidos, 6, 0);
         this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
         this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 125);
         this.tableLayoutPanel1.Name = "tableLayoutPanel1";
         this.tableLayoutPanel1.RowCount = 3;
         this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
         this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
         this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
         this.tableLayoutPanel1.Size = new System.Drawing.Size(1102, 81);
         this.tableLayoutPanel1.TabIndex = 4;
         // 
         // cmbTIPO_CodBCO
         // 
         this.cmbTIPO_CodBCO.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this.cmbTIPO_CodBCO.FormattingEnabled = true;
         this.cmbTIPO_CodBCO.Location = new System.Drawing.Point(883, 30);
         this.cmbTIPO_CodBCO.Name = "cmbTIPO_CodBCO";
         this.cmbTIPO_CodBCO.Session = null;
         this.cmbTIPO_CodBCO.Size = new System.Drawing.Size(194, 21);
         this.cmbTIPO_CodBCO.TabIndex = 9;
         this.cmbTIPO_CodBCO.TiposSelectedItem = null;
         this.cmbTIPO_CodBCO.TiposSelectedValue = null;
         this.cmbTIPO_CodBCO.TiposTitulo = null;
         // 
         // label5
         // 
         this.label5.AutoSize = true;
         this.label5.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.label5.Location = new System.Drawing.Point(740, 34);
         this.label5.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
         this.label5.Name = "label5";
         this.label5.Size = new System.Drawing.Size(112, 13);
         this.label5.TabIndex = 9;
         this.label5.Text = "Entidad Bancaria :";
         // 
         // label2
         // 
         this.label2.AutoSize = true;
         this.label2.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.label2.Location = new System.Drawing.Point(375, 7);
         this.label2.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
         this.label2.Name = "label2";
         this.label2.Size = new System.Drawing.Size(59, 13);
         this.label2.TabIndex = 2;
         this.label2.Text = "Periodo :";
         // 
         // label1
         // 
         this.label1.AutoSize = true;
         this.label1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.label1.Location = new System.Drawing.Point(10, 34);
         this.label1.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
         this.label1.Name = "label1";
         this.label1.Size = new System.Drawing.Size(111, 13);
         this.label1.TabIndex = 0;
         this.label1.Text = "Cuenta Bancaria :";
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
         this.txaCUBA_Codigo.Location = new System.Drawing.Point(153, 30);
         this.txaCUBA_Codigo.LongitudAceptada = 0;
         this.txaCUBA_Codigo.MaxLength = 100;
         this.txaCUBA_Codigo.MyInstanciaAyuda = Infrastructure.WinForms.Controls.TextBoxAyuda.InstanciaAyuda.Habilitado;
         this.txaCUBA_Codigo.Name = "txaCUBA_Codigo";
         this.txaCUBA_Codigo.RellenaCeros = false;
         this.txaCUBA_Codigo.SelectedItem = null;
         this.txaCUBA_Codigo.Size = new System.Drawing.Size(194, 20);
         this.txaCUBA_Codigo.TabIndex = 1;
         this.txaCUBA_Codigo.TAyuda = Delfin.Controls.CuentaBancaria.TipoAyuda.Normal;
         this.txaCUBA_Codigo.Tipo = Infrastructure.WinForms.Controls.TextBoxAyuda.TipoTextBoxAyuda.AlfaNumerico;
         this.txaCUBA_Codigo.Usuario = null;
         this.txaCUBA_Codigo.Value = null;
         // 
         // cmbTIPO
         // 
         this.cmbTIPO.ConstantesSelectedItem = null;
         this.cmbTIPO.ConstantesSelectedValue = null;
         this.cmbTIPO.ConstantesTitulo = null;
         this.cmbTIPO.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this.cmbTIPO.FormattingEnabled = true;
         this.cmbTIPO.Location = new System.Drawing.Point(153, 3);
         this.cmbTIPO.Name = "cmbTIPO";
         this.cmbTIPO.Session = null;
         this.cmbTIPO.Size = new System.Drawing.Size(194, 21);
         this.cmbTIPO.TabIndex = 8;
         // 
         // label4
         // 
         this.label4.AutoSize = true;
         this.label4.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.label4.Location = new System.Drawing.Point(10, 7);
         this.label4.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
         this.label4.Name = "label4";
         this.label4.Size = new System.Drawing.Size(40, 13);
         this.label4.TabIndex = 0;
         this.label4.Text = "Tipo :";
         // 
         // cmbPeriodo
         // 
         this.cmbPeriodo.ComboIntSelectedValue = null;
         this.cmbPeriodo.ComboSelectedItem = null;
         this.cmbPeriodo.ComboStrSelectedValue = null;
         this.cmbPeriodo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this.cmbPeriodo.FormattingEnabled = true;
         this.cmbPeriodo.Location = new System.Drawing.Point(518, 3);
         this.cmbPeriodo.Name = "cmbPeriodo";
         this.cmbPeriodo.Size = new System.Drawing.Size(194, 21);
         this.cmbPeriodo.TabIndex = 10;
         // 
         // cmbTIPO_CodMND
         // 
         this.cmbTIPO_CodMND.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this.cmbTIPO_CodMND.FormattingEnabled = true;
         this.cmbTIPO_CodMND.Location = new System.Drawing.Point(518, 30);
         this.cmbTIPO_CodMND.Name = "cmbTIPO_CodMND";
         this.cmbTIPO_CodMND.Session = null;
         this.cmbTIPO_CodMND.Size = new System.Drawing.Size(194, 21);
         this.cmbTIPO_CodMND.TabIndex = 3;
         this.cmbTIPO_CodMND.TiposSelectedItem = null;
         this.cmbTIPO_CodMND.TiposSelectedValue = null;
         this.cmbTIPO_CodMND.TiposTitulo = null;
         // 
         // label3
         // 
         this.label3.AutoSize = true;
         this.label3.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.label3.Location = new System.Drawing.Point(375, 34);
         this.label3.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
         this.label3.Name = "label3";
         this.label3.Size = new System.Drawing.Size(60, 13);
         this.label3.TabIndex = 0;
         this.label3.Text = "Moneda :";
         // 
         // chkIncluirDiferidos
         // 
         this.chkIncluirDiferidos.AutoSize = true;
         this.tableLayoutPanel1.SetColumnSpan(this.chkIncluirDiferidos, 2);
         this.chkIncluirDiferidos.Font = new System.Drawing.Font("Verdana", 8.25F);
         this.chkIncluirDiferidos.Location = new System.Drawing.Point(740, 7);
         this.chkIncluirDiferidos.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
         this.chkIncluirDiferidos.Name = "chkIncluirDiferidos";
         this.chkIncluirDiferidos.Size = new System.Drawing.Size(202, 17);
         this.chkIncluirDiferidos.TabIndex = 9;
         this.chkIncluirDiferidos.Text = "Incluir Diferidos No Ejecutados";
         this.chkIncluirDiferidos.UseVisualStyleBackColor = true;
         // 
         // pgbar
         // 
         this.pgbar.Dock = System.Windows.Forms.DockStyle.Top;
         this.pgbar.Location = new System.Drawing.Point(0, 102);
         this.pgbar.Name = "pgbar";
         this.pgbar.Size = new System.Drawing.Size(1102, 23);
         this.pgbar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
         this.pgbar.TabIndex = 7;
         // 
         // pnlResultado
         // 
         this.pnlResultado.Controls.Add(this.grdItems);
         this.pnlResultado.Controls.Add(this.navItems);
         this.pnlResultado.Controls.Add(this.panelCaption2);
         this.pnlResultado.Dock = System.Windows.Forms.DockStyle.Fill;
         this.pnlResultado.Location = new System.Drawing.Point(0, 206);
         this.pnlResultado.Name = "pnlResultado";
         this.pnlResultado.Size = new System.Drawing.Size(1102, 245);
         this.pnlResultado.TabIndex = 9;
         // 
         // panelCaption2
         // 
         this.panelCaption2.AllowActive = false;
         this.panelCaption2.AntiAlias = false;
         this.panelCaption2.Caption = "Detalle de Documento";
         this.panelCaption2.Dock = System.Windows.Forms.DockStyle.Top;
         this.panelCaption2.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
         this.panelCaption2.InactiveGradientHighColor = System.Drawing.Color.SteelBlue;
         this.panelCaption2.InactiveGradientLowColor = System.Drawing.Color.MidnightBlue;
         this.panelCaption2.Location = new System.Drawing.Point(0, 0);
         this.panelCaption2.Name = "panelCaption2";
         this.panelCaption2.Size = new System.Drawing.Size(1102, 26);
         this.panelCaption2.TabIndex = 9;
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
         this.navItems.Location = new System.Drawing.Point(0, 220);
         this.navItems.MoveFirstItem = this.bindingNavigatorMoveFirstItem1;
         this.navItems.MoveLastItem = this.bindingNavigatorMoveLastItem1;
         this.navItems.MoveNextItem = this.bindingNavigatorMoveNextItem1;
         this.navItems.MovePreviousItem = this.bindingNavigatorMovePreviousItem1;
         this.navItems.Name = "navItems";
         this.navItems.PositionItem = this.bindingNavigatorPositionItem1;
         this.navItems.Size = new System.Drawing.Size(1102, 25);
         this.navItems.TabIndex = 54;
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
         // grdItems
         // 
         this.grdItems.BackColor = System.Drawing.SystemColors.ControlLightLight;
         this.grdItems.Dock = System.Windows.Forms.DockStyle.Fill;
         this.grdItems.Location = new System.Drawing.Point(0, 26);
         this.grdItems.Name = "grdItems";
         // 
         // 
         // 
         this.grdItems.RootElement.ControlBounds = new System.Drawing.Rectangle(0, 317, 240, 150);
         this.grdItems.Size = new System.Drawing.Size(1102, 194);
         this.grdItems.TabIndex = 55;
         this.grdItems.TabStop = false;
         // 
         // btnReporte
         // 
         this.btnReporte.AutoSize = true;
         this.btnReporte.Dock = System.Windows.Forms.DockStyle.Left;
         this.btnReporte.FlatAppearance.BorderColor = System.Drawing.Color.SteelBlue;
         this.btnReporte.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
         this.btnReporte.ForeColor = System.Drawing.Color.Black;
         this.btnReporte.Image = global::Delfin.Principal.Properties.Resources.document_ok_24x24;
         this.btnReporte.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
         this.btnReporte.Location = new System.Drawing.Point(87, 0);
         this.btnReporte.Margin = new System.Windows.Forms.Padding(0);
         this.btnReporte.Name = "btnReporte";
         this.btnReporte.Size = new System.Drawing.Size(98, 50);
         this.btnReporte.TabIndex = 9;
         this.btnReporte.Text = "&Generar Reporte";
         this.btnReporte.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
         this.btnReporte.UseVisualStyleBackColor = true;
         // 
         // REP009FlujoCajaLView
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.Controls.Add(this.pnlResultado);
         this.Controls.Add(this.tableLayoutPanel1);
         this.Controls.Add(this.pgbar);
         this.Controls.Add(this.panelCaption1);
         this.Controls.Add(this.pnBotones);
         this.Controls.Add(this.TitleView);
         this.Name = "REP009FlujoCajaLView";
         this.Size = new System.Drawing.Size(1102, 451);
         this.pnBotones.ResumeLayout(false);
         this.pnBotones.PerformLayout();
         this.tableLayoutPanel1.ResumeLayout(false);
         this.tableLayoutPanel1.PerformLayout();
         this.pnlResultado.ResumeLayout(false);
         this.pnlResultado.PerformLayout();
         ((System.ComponentModel.ISupportInitialize)(this.navItems)).EndInit();
         this.navItems.ResumeLayout(false);
         this.navItems.PerformLayout();
         ((System.ComponentModel.ISupportInitialize)(this.grdItems.MasterTemplate)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.grdItems)).EndInit();
         this.ResumeLayout(false);
         this.PerformLayout();

        }

        #endregion

        private Infrastructure.WinForms.Controls.FormTitle TitleView;
        private System.Windows.Forms.Panel pnBotones;
        private Infrastructure.WinForms.Controls.PanelCaption panelCaption1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private Controls.Tipos.ComboBoxConstantes cmbTIPO;
        private Controls.Tipos.ComboBoxTipos cmbTIPO_CodMND;
        private System.Windows.Forms.Label label2;
        private Controls.CuentaBancaria txaCUBA_Codigo;
        private System.Windows.Forms.CheckBox chkIncluirDiferidos;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private Infrastructure.WinForms.Controls.ComboBox.ComboBox cmbPeriodo;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btnEnviarExcel;
        private System.Windows.Forms.ProgressBar pgbar;
        private System.Windows.Forms.Label label5;
        private Controls.Tipos.ComboBoxTipos cmbTIPO_CodBCO;
        private System.Windows.Forms.Panel pnlResultado;
        private Infrastructure.WinForms.Controls.PanelCaption panelCaption2;
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
        private Telerik.WinControls.UI.RadGridView grdItems;
        private System.Windows.Forms.Button btnReporte;
    }
}
