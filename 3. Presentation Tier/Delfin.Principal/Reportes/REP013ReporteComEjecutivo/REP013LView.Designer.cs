namespace Delfin.Principal
{
    partial class REP013LView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(REP013LView));
            this.cmsMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmMarcarTodos = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmMarcarSeleccionados = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmDesmarcarTodos = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmDesmarcarSeleccionados = new System.Windows.Forms.ToolStripMenuItem();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripTextBox1 = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton4 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.label1 = new System.Windows.Forms.Label();
            this.TitleView = new Infrastructure.WinForms.Controls.FormTitle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnExportar = new System.Windows.Forms.Button();
            this.btnDeshacer = new System.Windows.Forms.Button();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.panelCaption1 = new Infrastructure.WinForms.Controls.PanelCaption();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lblNro_OV = new System.Windows.Forms.Label();
            this.lblFechaIniCancelado = new System.Windows.Forms.Label();
            this.lblEjecutivo = new System.Windows.Forms.Label();
            this.lblCliente = new System.Windows.Forms.Label();
            this.lblNro_HBL = new System.Windows.Forms.Label();
            this.lblFechaFinCancelado = new System.Windows.Forms.Label();
            this.txtDOOV_HBL = new System.Windows.Forms.TextBox();
            this.mdtCCOT_FecIniCancelado = new Infrastructure.WinForms.Controls.MaskDateTime();
            this.mdtCCOT_FecFinCancelado = new Infrastructure.WinForms.Controls.MaskDateTime();
            this.txtCCOT_NumDoc = new System.Windows.Forms.TextBox();
            this.ayudaENTC_Ejecutivo = new Delfin.Controls.Entidad(this.components);
            this.ayudaENTC_Cliente = new Delfin.Controls.Entidad(this.components);
            this.panelCaption2 = new Infrastructure.WinForms.Controls.PanelCaption();
            this.navItemsReport = new System.Windows.Forms.BindingNavigator(this.components);
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripButton5 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton6 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripTextBox2 = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton7 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton8 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.grdItems = new Telerik.WinControls.UI.RadGridView();
            this.lblNro_MBL = new System.Windows.Forms.Label();
            this.cmsMenu.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.navItemsReport)).BeginInit();
            this.navItemsReport.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdItems)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdItems.MasterTemplate)).BeginInit();
            this.SuspendLayout();
            // 
            // cmsMenu
            // 
            this.cmsMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmMarcarTodos,
            this.tsmMarcarSeleccionados,
            this.tsmDesmarcarTodos,
            this.tsmDesmarcarSeleccionados});
            this.cmsMenu.Name = "cmsMenu";
            this.cmsMenu.Size = new System.Drawing.Size(209, 92);
            // 
            // tsmMarcarTodos
            // 
            this.tsmMarcarTodos.Name = "tsmMarcarTodos";
            this.tsmMarcarTodos.Size = new System.Drawing.Size(208, 22);
            this.tsmMarcarTodos.Text = "Marcar Todos";
            // 
            // tsmMarcarSeleccionados
            // 
            this.tsmMarcarSeleccionados.Name = "tsmMarcarSeleccionados";
            this.tsmMarcarSeleccionados.Size = new System.Drawing.Size(208, 22);
            this.tsmMarcarSeleccionados.Text = "Marcar Seleccionados";
            // 
            // tsmDesmarcarTodos
            // 
            this.tsmDesmarcarTodos.Name = "tsmDesmarcarTodos";
            this.tsmDesmarcarTodos.Size = new System.Drawing.Size(208, 22);
            this.tsmDesmarcarTodos.Text = "Desmarcar Todos";
            // 
            // tsmDesmarcarSeleccionados
            // 
            this.tsmDesmarcarSeleccionados.Name = "tsmDesmarcarSeleccionados";
            this.tsmDesmarcarSeleccionados.Size = new System.Drawing.Size(208, 22);
            this.tsmDesmarcarSeleccionados.Text = "Desmarcar Seleccionados";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(37, 22);
            this.toolStripLabel1.Text = "de {0}";
            this.toolStripLabel1.ToolTipText = "Número total de elementos";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.RightToLeftAutoMirrorImage = true;
            this.toolStripButton1.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton1.Text = "Mover último";
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.RightToLeftAutoMirrorImage = true;
            this.toolStripButton2.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton2.Text = "Mover siguiente";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripTextBox1
            // 
            this.toolStripTextBox1.AccessibleName = "Posición";
            this.toolStripTextBox1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripTextBox1.AutoSize = false;
            this.toolStripTextBox1.Name = "toolStripTextBox1";
            this.toolStripTextBox1.Size = new System.Drawing.Size(50, 23);
            this.toolStripTextBox1.Text = "0";
            this.toolStripTextBox1.ToolTipText = "Posición actual";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton3.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton3.Image")));
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.RightToLeftAutoMirrorImage = true;
            this.toolStripButton3.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton3.Text = "Mover anterior";
            // 
            // toolStripButton4
            // 
            this.toolStripButton4.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripButton4.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton4.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton4.Image")));
            this.toolStripButton4.Name = "toolStripButton4";
            this.toolStripButton4.RightToLeftAutoMirrorImage = true;
            this.toolStripButton4.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton4.Text = "Mover primero";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(10, 88);
            this.label1.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Transportista :";
            // 
            // TitleView
            // 
            this.TitleView.AllowActive = false;
            this.TitleView.AntiAlias = false;
            this.TitleView.Caption = "Reporte COMISION - EJECUTIVO";
            this.TitleView.Dock = System.Windows.Forms.DockStyle.Top;
            this.TitleView.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TitleView.FormIcon = global::Delfin.Principal.Properties.Resources.document_attachment_24x24;
            this.TitleView.InactiveGradientHighColor = System.Drawing.Color.SteelBlue;
            this.TitleView.InactiveGradientLowColor = System.Drawing.Color.MidnightBlue;
            this.TitleView.Location = new System.Drawing.Point(0, 0);
            this.TitleView.Name = "TitleView";
            this.TitleView.Size = new System.Drawing.Size(950, 26);
            this.TitleView.TabIndex = 2;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.panel1.Controls.Add(this.btnExportar);
            this.panel1.Controls.Add(this.btnDeshacer);
            this.panel1.Controls.Add(this.btnBuscar);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.panel1.Location = new System.Drawing.Point(0, 26);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(950, 50);
            this.panel1.TabIndex = 3;
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
            this.btnExportar.Location = new System.Drawing.Point(123, 0);
            this.btnExportar.Margin = new System.Windows.Forms.Padding(0);
            this.btnExportar.Name = "btnExportar";
            this.btnExportar.Size = new System.Drawing.Size(58, 50);
            this.btnExportar.TabIndex = 2;
            this.btnExportar.Text = "&Exportar";
            this.btnExportar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnExportar.UseVisualStyleBackColor = true;
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
            this.btnDeshacer.Location = new System.Drawing.Point(58, 0);
            this.btnDeshacer.Margin = new System.Windows.Forms.Padding(0);
            this.btnDeshacer.Name = "btnDeshacer";
            this.btnDeshacer.Size = new System.Drawing.Size(65, 50);
            this.btnDeshacer.TabIndex = 1;
            this.btnDeshacer.Text = "&Deshacer";
            this.btnDeshacer.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnDeshacer.UseVisualStyleBackColor = true;
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
            this.btnBuscar.Location = new System.Drawing.Point(0, 0);
            this.btnBuscar.Margin = new System.Windows.Forms.Padding(0);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(58, 50);
            this.btnBuscar.TabIndex = 0;
            this.btnBuscar.Text = "&Buscar";
            this.btnBuscar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnBuscar.UseVisualStyleBackColor = true;
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
            this.panelCaption1.Size = new System.Drawing.Size(950, 26);
            this.panelCaption1.TabIndex = 4;
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
            this.tableLayoutPanel1.Controls.Add(this.lblNro_OV, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblFechaIniCancelado, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblEjecutivo, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.lblCliente, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.lblNro_HBL, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblFechaFinCancelado, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtDOOV_HBL, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.mdtCCOT_FecIniCancelado, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.mdtCCOT_FecFinCancelado, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtCCOT_NumDoc, 4, 1);
            this.tableLayoutPanel1.Controls.Add(this.ayudaENTC_Ejecutivo, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.ayudaENTC_Cliente, 1, 3);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 102);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(950, 108);
            this.tableLayoutPanel1.TabIndex = 5;
            // 
            // lblNro_OV
            // 
            this.lblNro_OV.AutoSize = true;
            this.lblNro_OV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblNro_OV.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNro_OV.Location = new System.Drawing.Point(375, 34);
            this.lblNro_OV.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
            this.lblNro_OV.Name = "lblNro_OV";
            this.lblNro_OV.Size = new System.Drawing.Size(137, 20);
            this.lblNro_OV.TabIndex = 12;
            this.lblNro_OV.Text = "Nro. Orden de Venta :";
            // 
            // lblFechaIniCancelado
            // 
            this.lblFechaIniCancelado.AutoSize = true;
            this.lblFechaIniCancelado.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblFechaIniCancelado.Font = new System.Drawing.Font("Verdana", 7.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFechaIniCancelado.Location = new System.Drawing.Point(10, 7);
            this.lblFechaIniCancelado.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
            this.lblFechaIniCancelado.Name = "lblFechaIniCancelado";
            this.lblFechaIniCancelado.Size = new System.Drawing.Size(137, 20);
            this.lblFechaIniCancelado.TabIndex = 6;
            this.lblFechaIniCancelado.Text = "Fec. Inicio Cancelado :";
            // 
            // lblEjecutivo
            // 
            this.lblEjecutivo.AutoSize = true;
            this.lblEjecutivo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblEjecutivo.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEjecutivo.Location = new System.Drawing.Point(10, 61);
            this.lblEjecutivo.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
            this.lblEjecutivo.Name = "lblEjecutivo";
            this.lblEjecutivo.Size = new System.Drawing.Size(137, 20);
            this.lblEjecutivo.TabIndex = 6;
            this.lblEjecutivo.Text = "Ejecutivo :";
            // 
            // lblCliente
            // 
            this.lblCliente.AutoSize = true;
            this.lblCliente.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblCliente.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCliente.Location = new System.Drawing.Point(10, 88);
            this.lblCliente.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
            this.lblCliente.Name = "lblCliente";
            this.lblCliente.Size = new System.Drawing.Size(137, 20);
            this.lblCliente.TabIndex = 6;
            this.lblCliente.Text = "Cliente :";
            // 
            // lblNro_HBL
            // 
            this.lblNro_HBL.AutoSize = true;
            this.lblNro_HBL.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblNro_HBL.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNro_HBL.Location = new System.Drawing.Point(10, 34);
            this.lblNro_HBL.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
            this.lblNro_HBL.Name = "lblNro_HBL";
            this.lblNro_HBL.Size = new System.Drawing.Size(137, 20);
            this.lblNro_HBL.TabIndex = 6;
            this.lblNro_HBL.Text = "Nro. HBL :";
            // 
            // lblFechaFinCancelado
            // 
            this.lblFechaFinCancelado.AutoSize = true;
            this.lblFechaFinCancelado.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblFechaFinCancelado.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFechaFinCancelado.Location = new System.Drawing.Point(375, 7);
            this.lblFechaFinCancelado.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
            this.lblFechaFinCancelado.Name = "lblFechaFinCancelado";
            this.lblFechaFinCancelado.Size = new System.Drawing.Size(137, 20);
            this.lblFechaFinCancelado.TabIndex = 6;
            this.lblFechaFinCancelado.Text = "Fec. Fin Cancelado :";
            // 
            // txtDOOV_HBL
            // 
            this.txtDOOV_HBL.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtDOOV_HBL.Location = new System.Drawing.Point(153, 30);
            this.txtDOOV_HBL.Name = "txtDOOV_HBL";
            this.txtDOOV_HBL.Size = new System.Drawing.Size(194, 20);
            this.txtDOOV_HBL.TabIndex = 7;
            // 
            // mdtCCOT_FecIniCancelado
            // 
            this.mdtCCOT_FecIniCancelado.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mdtCCOT_FecIniCancelado.Location = new System.Drawing.Point(153, 3);
            this.mdtCCOT_FecIniCancelado.MinimumSize = new System.Drawing.Size(100, 22);
            this.mdtCCOT_FecIniCancelado.Name = "mdtCCOT_FecIniCancelado";
            this.mdtCCOT_FecIniCancelado.NSActiveMouse = false;
            this.mdtCCOT_FecIniCancelado.NSActiveMsgFecha = false;
            this.mdtCCOT_FecIniCancelado.NSChangeDate = true;
            this.mdtCCOT_FecIniCancelado.NSDigitos = 4;
            this.mdtCCOT_FecIniCancelado.NSFecha = null;
            this.mdtCCOT_FecIniCancelado.NSSetDateNow = false;
            this.mdtCCOT_FecIniCancelado.Size = new System.Drawing.Size(194, 22);
            this.mdtCCOT_FecIniCancelado.TabIndex = 10;
            // 
            // mdtCCOT_FecFinCancelado
            // 
            this.mdtCCOT_FecFinCancelado.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mdtCCOT_FecFinCancelado.Location = new System.Drawing.Point(518, 3);
            this.mdtCCOT_FecFinCancelado.MinimumSize = new System.Drawing.Size(100, 22);
            this.mdtCCOT_FecFinCancelado.Name = "mdtCCOT_FecFinCancelado";
            this.mdtCCOT_FecFinCancelado.NSActiveMouse = false;
            this.mdtCCOT_FecFinCancelado.NSActiveMsgFecha = false;
            this.mdtCCOT_FecFinCancelado.NSChangeDate = true;
            this.mdtCCOT_FecFinCancelado.NSDigitos = 4;
            this.mdtCCOT_FecFinCancelado.NSFecha = null;
            this.mdtCCOT_FecFinCancelado.NSSetDateNow = false;
            this.mdtCCOT_FecFinCancelado.Size = new System.Drawing.Size(194, 22);
            this.mdtCCOT_FecFinCancelado.TabIndex = 11;
            // 
            // txtCCOT_NumDoc
            // 
            this.txtCCOT_NumDoc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtCCOT_NumDoc.Location = new System.Drawing.Point(518, 30);
            this.txtCCOT_NumDoc.Name = "txtCCOT_NumDoc";
            this.txtCCOT_NumDoc.Size = new System.Drawing.Size(194, 20);
            this.txtCCOT_NumDoc.TabIndex = 13;
            // 
            // ayudaENTC_Ejecutivo
            // 
            this.ayudaENTC_Ejecutivo.ActivarAyudaAuto = false;
            this.tableLayoutPanel1.SetColumnSpan(this.ayudaENTC_Ejecutivo, 4);
            this.ayudaENTC_Ejecutivo.ContainerService = null;
            this.ayudaENTC_Ejecutivo.EnabledAyudaButton = true;
            this.ayudaENTC_Ejecutivo.Location = new System.Drawing.Point(153, 57);
            this.ayudaENTC_Ejecutivo.LongitudAceptada = 0;
            this.ayudaENTC_Ejecutivo.MyInstanciaAyuda = Delfin.Controls.Entidad.InstanciaAyuda.Habilitado;
            this.ayudaENTC_Ejecutivo.Name = "ayudaENTC_Ejecutivo";
            this.ayudaENTC_Ejecutivo.RellenaCeros = false;
            this.ayudaENTC_Ejecutivo.Size = new System.Drawing.Size(559, 20);
            this.ayudaENTC_Ejecutivo.TabIndex = 14;
            this.ayudaENTC_Ejecutivo.Tipo = Delfin.Controls.Entidad.TipoTextBoxAyuda.AlfaNumerico;
            this.ayudaENTC_Ejecutivo.Value = null;
            // 
            // ayudaENTC_Cliente
            // 
            this.ayudaENTC_Cliente.ActivarAyudaAuto = false;
            this.tableLayoutPanel1.SetColumnSpan(this.ayudaENTC_Cliente, 4);
            this.ayudaENTC_Cliente.ContainerService = null;
            this.ayudaENTC_Cliente.EnabledAyudaButton = true;
            this.ayudaENTC_Cliente.Location = new System.Drawing.Point(153, 84);
            this.ayudaENTC_Cliente.LongitudAceptada = 0;
            this.ayudaENTC_Cliente.MyInstanciaAyuda = Delfin.Controls.Entidad.InstanciaAyuda.Habilitado;
            this.ayudaENTC_Cliente.Name = "ayudaENTC_Cliente";
            this.ayudaENTC_Cliente.RellenaCeros = false;
            this.ayudaENTC_Cliente.Size = new System.Drawing.Size(559, 20);
            this.ayudaENTC_Cliente.TabIndex = 15;
            this.ayudaENTC_Cliente.Tipo = Delfin.Controls.Entidad.TipoTextBoxAyuda.AlfaNumerico;
            this.ayudaENTC_Cliente.Value = null;
            // 
            // panelCaption2
            // 
            this.panelCaption2.AllowActive = false;
            this.panelCaption2.AntiAlias = false;
            this.panelCaption2.Caption = "Reporte";
            this.panelCaption2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelCaption2.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
            this.panelCaption2.InactiveGradientHighColor = System.Drawing.Color.SteelBlue;
            this.panelCaption2.InactiveGradientLowColor = System.Drawing.Color.MidnightBlue;
            this.panelCaption2.Location = new System.Drawing.Point(0, 210);
            this.panelCaption2.Name = "panelCaption2";
            this.panelCaption2.Size = new System.Drawing.Size(950, 26);
            this.panelCaption2.TabIndex = 6;
            // 
            // navItemsReport
            // 
            this.navItemsReport.AddNewItem = null;
            this.navItemsReport.BackColor = System.Drawing.Color.LightSteelBlue;
            this.navItemsReport.CountItem = this.toolStripLabel2;
            this.navItemsReport.DeleteItem = null;
            this.navItemsReport.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.navItemsReport.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton5,
            this.toolStripButton6,
            this.toolStripSeparator4,
            this.toolStripLabel2,
            this.toolStripTextBox2,
            this.toolStripSeparator5,
            this.toolStripButton7,
            this.toolStripButton8,
            this.toolStripSeparator6});
            this.navItemsReport.Location = new System.Drawing.Point(0, 425);
            this.navItemsReport.MoveFirstItem = this.toolStripButton8;
            this.navItemsReport.MoveLastItem = this.toolStripButton5;
            this.navItemsReport.MoveNextItem = this.toolStripButton6;
            this.navItemsReport.MovePreviousItem = this.toolStripButton7;
            this.navItemsReport.Name = "navItemsReport";
            this.navItemsReport.PositionItem = this.toolStripTextBox2;
            this.navItemsReport.Size = new System.Drawing.Size(950, 25);
            this.navItemsReport.TabIndex = 57;
            this.navItemsReport.Text = "bindingNavigator1";
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(37, 22);
            this.toolStripLabel2.Text = "de {0}";
            this.toolStripLabel2.ToolTipText = "Número total de elementos";
            // 
            // toolStripButton5
            // 
            this.toolStripButton5.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripButton5.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton5.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton5.Image")));
            this.toolStripButton5.Name = "toolStripButton5";
            this.toolStripButton5.RightToLeftAutoMirrorImage = true;
            this.toolStripButton5.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton5.Text = "Mover último";
            // 
            // toolStripButton6
            // 
            this.toolStripButton6.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripButton6.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton6.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton6.Image")));
            this.toolStripButton6.Name = "toolStripButton6";
            this.toolStripButton6.RightToLeftAutoMirrorImage = true;
            this.toolStripButton6.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton6.Text = "Mover siguiente";
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripTextBox2
            // 
            this.toolStripTextBox2.AccessibleName = "Posición";
            this.toolStripTextBox2.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripTextBox2.AutoSize = false;
            this.toolStripTextBox2.Name = "toolStripTextBox2";
            this.toolStripTextBox2.Size = new System.Drawing.Size(50, 23);
            this.toolStripTextBox2.Text = "0";
            this.toolStripTextBox2.ToolTipText = "Posición actual";
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButton7
            // 
            this.toolStripButton7.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripButton7.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton7.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton7.Image")));
            this.toolStripButton7.Name = "toolStripButton7";
            this.toolStripButton7.RightToLeftAutoMirrorImage = true;
            this.toolStripButton7.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton7.Text = "Mover anterior";
            // 
            // toolStripButton8
            // 
            this.toolStripButton8.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripButton8.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton8.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton8.Image")));
            this.toolStripButton8.Name = "toolStripButton8";
            this.toolStripButton8.RightToLeftAutoMirrorImage = true;
            this.toolStripButton8.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton8.Text = "Mover primero";
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(6, 25);
            // 
            // grdItems
            // 
            this.grdItems.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.grdItems.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdItems.Location = new System.Drawing.Point(0, 236);
            this.grdItems.Name = "grdItems";
            // 
            // 
            // 
            this.grdItems.RootElement.ControlBounds = new System.Drawing.Rectangle(0, 236, 240, 150);
            this.grdItems.Size = new System.Drawing.Size(950, 189);
            this.grdItems.TabIndex = 58;
            this.grdItems.TabStop = false;
            // 
            // lblNro_MBL
            // 
            this.lblNro_MBL.AutoSize = true;
            this.lblNro_MBL.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblNro_MBL.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNro_MBL.Location = new System.Drawing.Point(10, 34);
            this.lblNro_MBL.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
            this.lblNro_MBL.Name = "lblNro_MBL";
            this.lblNro_MBL.Size = new System.Drawing.Size(137, 20);
            this.lblNro_MBL.TabIndex = 6;
            this.lblNro_MBL.Text = "Nro. HBL :";
            // 
            // REP013LView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.Controls.Add(this.grdItems);
            this.Controls.Add(this.navItemsReport);
            this.Controls.Add(this.panelCaption2);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.panelCaption1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.TitleView);
            this.Name = "REP013LView";
            this.Size = new System.Drawing.Size(950, 450);
            this.cmsMenu.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.navItemsReport)).EndInit();
            this.navItemsReport.ResumeLayout(false);
            this.navItemsReport.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdItems.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdItems)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip cmsMenu;
        private System.Windows.Forms.ToolStripMenuItem tsmMarcarTodos;
        private System.Windows.Forms.ToolStripMenuItem tsmMarcarSeleccionados;
        private System.Windows.Forms.ToolStripMenuItem tsmDesmarcarTodos;
        private System.Windows.Forms.ToolStripMenuItem tsmDesmarcarSeleccionados;
        private Controls.Entidad entidad;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton toolStripButton3;
        private System.Windows.Forms.ToolStripButton toolStripButton4;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.Label label1;
        private Infrastructure.WinForms.Controls.FormTitle TitleView;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnExportar;
        private System.Windows.Forms.Button btnDeshacer;
        private System.Windows.Forms.Button btnBuscar;
        private Infrastructure.WinForms.Controls.PanelCaption panelCaption1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private Infrastructure.WinForms.Controls.PanelCaption panelCaption2;
        private System.Windows.Forms.BindingNavigator navItemsReport;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.ToolStripButton toolStripButton5;
        private System.Windows.Forms.ToolStripButton toolStripButton6;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripButton toolStripButton7;
        private System.Windows.Forms.ToolStripButton toolStripButton8;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private Telerik.WinControls.UI.RadGridView grdItems;
        private System.Windows.Forms.Label lblFechaIniCancelado;
        private System.Windows.Forms.Label lblEjecutivo;
        private System.Windows.Forms.Label lblCliente;
        private System.Windows.Forms.Label lblNro_HBL;
        private System.Windows.Forms.Label lblFechaFinCancelado;
        private System.Windows.Forms.TextBox txtDOOV_HBL;
        private Infrastructure.WinForms.Controls.MaskDateTime mdtCCOT_FecIniCancelado;
        private Infrastructure.WinForms.Controls.MaskDateTime mdtCCOT_FecFinCancelado;
        private System.Windows.Forms.Label lblNro_OV;
        private System.Windows.Forms.TextBox txtCCOT_NumDoc;
        private Controls.Entidad ayudaENTC_Ejecutivo;
        private Controls.Entidad ayudaENTC_Cliente;
        private System.Windows.Forms.Label lblNro_MBL;

    }
}
