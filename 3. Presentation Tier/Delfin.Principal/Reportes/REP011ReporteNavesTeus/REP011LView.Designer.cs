namespace Delfin.Principal
{
    partial class REP011LView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(REP011LView));
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
            this.lblCONS_CodRGM = new System.Windows.Forms.Label();
            this.lblFechaIniEmbarque = new System.Windows.Forms.Label();
            this.lblVendedor = new System.Windows.Forms.Label();
            this.lblDeposito = new System.Windows.Forms.Label();
            this.lblTransportista = new System.Windows.Forms.Label();
            this.lblNro_Viaje = new System.Windows.Forms.Label();
            this.lblFechaFinEtaZarpe = new System.Windows.Forms.Label();
            this.lblFechaFinEmbarque = new System.Windows.Forms.Label();
            this.lblFechaIniEtaZarpe = new System.Windows.Forms.Label();
            this.txtNVIA_NroViaje = new System.Windows.Forms.TextBox();
            this.mdtNVIA_FechaIniEtaZarpe = new Infrastructure.WinForms.Controls.MaskDateTime();
            this.mdtNVIA_FechaFinEtaZarpe = new Infrastructure.WinForms.Controls.MaskDateTime();
            this.mdtCCOT_FecIniEmbarque = new Infrastructure.WinForms.Controls.MaskDateTime();
            this.mdtCCOT_FecFinEmbarque = new Infrastructure.WinForms.Controls.MaskDateTime();
            this.cmbCONS_CodRGM = new Delfin.Controls.Tipos.ComboBoxConstantes();
            this.ayudaENTC_Transportista = new Delfin.Controls.Entidad(this.components);
            this.ayudaENTC_Vendedor = new Delfin.Controls.Entidad(this.components);
            this.ayudaENTC_Deposito = new Delfin.Controls.Entidad(this.components);
            this.lblNAVE_Codigo = new System.Windows.Forms.Label();
            this.NAVE_Codigo = new System.Windows.Forms.ComboBox();
            this.rbtnGeneral = new System.Windows.Forms.RadioButton();
            this.rbtnDetallado = new System.Windows.Forms.RadioButton();
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
            this.TitleView.Caption = "Reporte NAVES - TEUS ";
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
            this.tableLayoutPanel1.Controls.Add(this.lblCONS_CodRGM, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblFechaIniEmbarque, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.lblVendedor, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.lblDeposito, 0, 6);
            this.tableLayoutPanel1.Controls.Add(this.lblTransportista, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.lblNro_Viaje, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblFechaFinEtaZarpe, 3, 2);
            this.tableLayoutPanel1.Controls.Add(this.lblFechaFinEmbarque, 3, 3);
            this.tableLayoutPanel1.Controls.Add(this.lblFechaIniEtaZarpe, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.txtNVIA_NroViaje, 4, 1);
            this.tableLayoutPanel1.Controls.Add(this.mdtNVIA_FechaIniEtaZarpe, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.mdtNVIA_FechaFinEtaZarpe, 4, 2);
            this.tableLayoutPanel1.Controls.Add(this.mdtCCOT_FecIniEmbarque, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.mdtCCOT_FecFinEmbarque, 4, 3);
            this.tableLayoutPanel1.Controls.Add(this.cmbCONS_CodRGM, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.ayudaENTC_Transportista, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.ayudaENTC_Vendedor, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.ayudaENTC_Deposito, 1, 6);
            this.tableLayoutPanel1.Controls.Add(this.lblNAVE_Codigo, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.NAVE_Codigo, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.rbtnGeneral, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.rbtnDetallado, 4, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 102);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 7;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(950, 189);
            this.tableLayoutPanel1.TabIndex = 5;
            // 
            // lblCONS_CodRGM
            // 
            this.lblCONS_CodRGM.AutoSize = true;
            this.lblCONS_CodRGM.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblCONS_CodRGM.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCONS_CodRGM.Location = new System.Drawing.Point(10, 7);
            this.lblCONS_CodRGM.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
            this.lblCONS_CodRGM.Name = "lblCONS_CodRGM";
            this.lblCONS_CodRGM.Size = new System.Drawing.Size(137, 20);
            this.lblCONS_CodRGM.TabIndex = 5;
            this.lblCONS_CodRGM.Text = "Regimen :";
            // 
            // lblFechaIniEmbarque
            // 
            this.lblFechaIniEmbarque.AutoSize = true;
            this.lblFechaIniEmbarque.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblFechaIniEmbarque.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFechaIniEmbarque.Location = new System.Drawing.Point(10, 88);
            this.lblFechaIniEmbarque.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
            this.lblFechaIniEmbarque.Name = "lblFechaIniEmbarque";
            this.lblFechaIniEmbarque.Size = new System.Drawing.Size(137, 20);
            this.lblFechaIniEmbarque.TabIndex = 6;
            this.lblFechaIniEmbarque.Text = "Fec. Inicio Embarque :";
            // 
            // lblVendedor
            // 
            this.lblVendedor.AutoSize = true;
            this.lblVendedor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblVendedor.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVendedor.Location = new System.Drawing.Point(10, 142);
            this.lblVendedor.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
            this.lblVendedor.Name = "lblVendedor";
            this.lblVendedor.Size = new System.Drawing.Size(137, 20);
            this.lblVendedor.TabIndex = 6;
            this.lblVendedor.Text = "Vendedor :";
            // 
            // lblDeposito
            // 
            this.lblDeposito.AutoSize = true;
            this.lblDeposito.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDeposito.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDeposito.Location = new System.Drawing.Point(10, 169);
            this.lblDeposito.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
            this.lblDeposito.Name = "lblDeposito";
            this.lblDeposito.Size = new System.Drawing.Size(137, 20);
            this.lblDeposito.TabIndex = 6;
            this.lblDeposito.Text = "Deposito :";
            // 
            // lblTransportista
            // 
            this.lblTransportista.AutoSize = true;
            this.lblTransportista.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTransportista.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTransportista.Location = new System.Drawing.Point(10, 115);
            this.lblTransportista.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
            this.lblTransportista.Name = "lblTransportista";
            this.lblTransportista.Size = new System.Drawing.Size(137, 20);
            this.lblTransportista.TabIndex = 6;
            this.lblTransportista.Text = "Transportista :";
            // 
            // lblNro_Viaje
            // 
            this.lblNro_Viaje.AutoSize = true;
            this.lblNro_Viaje.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblNro_Viaje.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNro_Viaje.Location = new System.Drawing.Point(375, 34);
            this.lblNro_Viaje.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
            this.lblNro_Viaje.Name = "lblNro_Viaje";
            this.lblNro_Viaje.Size = new System.Drawing.Size(137, 20);
            this.lblNro_Viaje.TabIndex = 6;
            this.lblNro_Viaje.Text = "Nro Viaje :";
            // 
            // lblFechaFinEtaZarpe
            // 
            this.lblFechaFinEtaZarpe.AutoSize = true;
            this.lblFechaFinEtaZarpe.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblFechaFinEtaZarpe.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFechaFinEtaZarpe.Location = new System.Drawing.Point(375, 61);
            this.lblFechaFinEtaZarpe.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
            this.lblFechaFinEtaZarpe.Name = "lblFechaFinEtaZarpe";
            this.lblFechaFinEtaZarpe.Size = new System.Drawing.Size(137, 20);
            this.lblFechaFinEtaZarpe.TabIndex = 6;
            this.lblFechaFinEtaZarpe.Text = "Fec. Fin :";
            // 
            // lblFechaFinEmbarque
            // 
            this.lblFechaFinEmbarque.AutoSize = true;
            this.lblFechaFinEmbarque.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblFechaFinEmbarque.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFechaFinEmbarque.Location = new System.Drawing.Point(375, 88);
            this.lblFechaFinEmbarque.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
            this.lblFechaFinEmbarque.Name = "lblFechaFinEmbarque";
            this.lblFechaFinEmbarque.Size = new System.Drawing.Size(137, 20);
            this.lblFechaFinEmbarque.TabIndex = 6;
            this.lblFechaFinEmbarque.Text = "Fec. fin Embarque :";
            // 
            // lblFechaIniEtaZarpe
            // 
            this.lblFechaIniEtaZarpe.AutoSize = true;
            this.lblFechaIniEtaZarpe.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblFechaIniEtaZarpe.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFechaIniEtaZarpe.Location = new System.Drawing.Point(10, 61);
            this.lblFechaIniEtaZarpe.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
            this.lblFechaIniEtaZarpe.Name = "lblFechaIniEtaZarpe";
            this.lblFechaIniEtaZarpe.Size = new System.Drawing.Size(137, 20);
            this.lblFechaIniEtaZarpe.TabIndex = 6;
            this.lblFechaIniEtaZarpe.Text = "Fec. Inicio :";
            // 
            // txtNVIA_NroViaje
            // 
            this.txtNVIA_NroViaje.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtNVIA_NroViaje.Location = new System.Drawing.Point(518, 30);
            this.txtNVIA_NroViaje.Name = "txtNVIA_NroViaje";
            this.txtNVIA_NroViaje.Size = new System.Drawing.Size(194, 20);
            this.txtNVIA_NroViaje.TabIndex = 7;
            // 
            // mdtNVIA_FechaIniEtaZarpe
            // 
            this.mdtNVIA_FechaIniEtaZarpe.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mdtNVIA_FechaIniEtaZarpe.Location = new System.Drawing.Point(153, 57);
            this.mdtNVIA_FechaIniEtaZarpe.MinimumSize = new System.Drawing.Size(100, 22);
            this.mdtNVIA_FechaIniEtaZarpe.Name = "mdtNVIA_FechaIniEtaZarpe";
            this.mdtNVIA_FechaIniEtaZarpe.NSActiveMouse = false;
            this.mdtNVIA_FechaIniEtaZarpe.NSActiveMsgFecha = false;
            this.mdtNVIA_FechaIniEtaZarpe.NSChangeDate = true;
            this.mdtNVIA_FechaIniEtaZarpe.NSDigitos = 4;
            this.mdtNVIA_FechaIniEtaZarpe.NSFecha = null;
            this.mdtNVIA_FechaIniEtaZarpe.NSSetDateNow = false;
            this.mdtNVIA_FechaIniEtaZarpe.Size = new System.Drawing.Size(194, 22);
            this.mdtNVIA_FechaIniEtaZarpe.TabIndex = 8;
            // 
            // mdtNVIA_FechaFinEtaZarpe
            // 
            this.mdtNVIA_FechaFinEtaZarpe.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mdtNVIA_FechaFinEtaZarpe.Location = new System.Drawing.Point(518, 57);
            this.mdtNVIA_FechaFinEtaZarpe.MinimumSize = new System.Drawing.Size(100, 22);
            this.mdtNVIA_FechaFinEtaZarpe.Name = "mdtNVIA_FechaFinEtaZarpe";
            this.mdtNVIA_FechaFinEtaZarpe.NSActiveMouse = false;
            this.mdtNVIA_FechaFinEtaZarpe.NSActiveMsgFecha = false;
            this.mdtNVIA_FechaFinEtaZarpe.NSChangeDate = true;
            this.mdtNVIA_FechaFinEtaZarpe.NSDigitos = 4;
            this.mdtNVIA_FechaFinEtaZarpe.NSFecha = null;
            this.mdtNVIA_FechaFinEtaZarpe.NSSetDateNow = false;
            this.mdtNVIA_FechaFinEtaZarpe.Size = new System.Drawing.Size(194, 22);
            this.mdtNVIA_FechaFinEtaZarpe.TabIndex = 9;
            // 
            // mdtCCOT_FecIniEmbarque
            // 
            this.mdtCCOT_FecIniEmbarque.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mdtCCOT_FecIniEmbarque.Location = new System.Drawing.Point(153, 84);
            this.mdtCCOT_FecIniEmbarque.MinimumSize = new System.Drawing.Size(100, 22);
            this.mdtCCOT_FecIniEmbarque.Name = "mdtCCOT_FecIniEmbarque";
            this.mdtCCOT_FecIniEmbarque.NSActiveMouse = false;
            this.mdtCCOT_FecIniEmbarque.NSActiveMsgFecha = false;
            this.mdtCCOT_FecIniEmbarque.NSChangeDate = true;
            this.mdtCCOT_FecIniEmbarque.NSDigitos = 4;
            this.mdtCCOT_FecIniEmbarque.NSFecha = null;
            this.mdtCCOT_FecIniEmbarque.NSSetDateNow = false;
            this.mdtCCOT_FecIniEmbarque.Size = new System.Drawing.Size(194, 22);
            this.mdtCCOT_FecIniEmbarque.TabIndex = 10;
            // 
            // mdtCCOT_FecFinEmbarque
            // 
            this.mdtCCOT_FecFinEmbarque.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mdtCCOT_FecFinEmbarque.Location = new System.Drawing.Point(518, 84);
            this.mdtCCOT_FecFinEmbarque.MinimumSize = new System.Drawing.Size(100, 22);
            this.mdtCCOT_FecFinEmbarque.Name = "mdtCCOT_FecFinEmbarque";
            this.mdtCCOT_FecFinEmbarque.NSActiveMouse = false;
            this.mdtCCOT_FecFinEmbarque.NSActiveMsgFecha = false;
            this.mdtCCOT_FecFinEmbarque.NSChangeDate = true;
            this.mdtCCOT_FecFinEmbarque.NSDigitos = 4;
            this.mdtCCOT_FecFinEmbarque.NSFecha = null;
            this.mdtCCOT_FecFinEmbarque.NSSetDateNow = false;
            this.mdtCCOT_FecFinEmbarque.Size = new System.Drawing.Size(194, 22);
            this.mdtCCOT_FecFinEmbarque.TabIndex = 11;
            // 
            // cmbCONS_CodRGM
            // 
            this.cmbCONS_CodRGM.ConstantesSelectedItem = null;
            this.cmbCONS_CodRGM.ConstantesSelectedValue = null;
            this.cmbCONS_CodRGM.ConstantesTitulo = null;
            this.cmbCONS_CodRGM.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbCONS_CodRGM.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCONS_CodRGM.FormattingEnabled = true;
            this.cmbCONS_CodRGM.Location = new System.Drawing.Point(153, 3);
            this.cmbCONS_CodRGM.Name = "cmbCONS_CodRGM";
            this.cmbCONS_CodRGM.Session = null;
            this.cmbCONS_CodRGM.Size = new System.Drawing.Size(194, 21);
            this.cmbCONS_CodRGM.TabIndex = 12;
            // 
            // ayudaENTC_Transportista
            // 
            this.ayudaENTC_Transportista.ActivarAyudaAuto = false;
            this.tableLayoutPanel1.SetColumnSpan(this.ayudaENTC_Transportista, 4);
            this.ayudaENTC_Transportista.ContainerService = null;
            this.ayudaENTC_Transportista.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ayudaENTC_Transportista.EnabledAyudaButton = true;
            this.ayudaENTC_Transportista.Location = new System.Drawing.Point(153, 111);
            this.ayudaENTC_Transportista.LongitudAceptada = 0;
            this.ayudaENTC_Transportista.MyInstanciaAyuda = Delfin.Controls.Entidad.InstanciaAyuda.Habilitado;
            this.ayudaENTC_Transportista.Name = "ayudaENTC_Transportista";
            this.ayudaENTC_Transportista.RellenaCeros = false;
            this.ayudaENTC_Transportista.Size = new System.Drawing.Size(559, 20);
            this.ayudaENTC_Transportista.TabIndex = 16;
            this.ayudaENTC_Transportista.Tipo = Delfin.Controls.Entidad.TipoTextBoxAyuda.AlfaNumerico;
            this.ayudaENTC_Transportista.Value = null;
            // 
            // ayudaENTC_Vendedor
            // 
            this.ayudaENTC_Vendedor.ActivarAyudaAuto = false;
            this.tableLayoutPanel1.SetColumnSpan(this.ayudaENTC_Vendedor, 4);
            this.ayudaENTC_Vendedor.ContainerService = null;
            this.ayudaENTC_Vendedor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ayudaENTC_Vendedor.EnabledAyudaButton = true;
            this.ayudaENTC_Vendedor.Location = new System.Drawing.Point(153, 138);
            this.ayudaENTC_Vendedor.LongitudAceptada = 0;
            this.ayudaENTC_Vendedor.MyInstanciaAyuda = Delfin.Controls.Entidad.InstanciaAyuda.Habilitado;
            this.ayudaENTC_Vendedor.Name = "ayudaENTC_Vendedor";
            this.ayudaENTC_Vendedor.RellenaCeros = false;
            this.ayudaENTC_Vendedor.Size = new System.Drawing.Size(559, 20);
            this.ayudaENTC_Vendedor.TabIndex = 17;
            this.ayudaENTC_Vendedor.Tipo = Delfin.Controls.Entidad.TipoTextBoxAyuda.AlfaNumerico;
            this.ayudaENTC_Vendedor.Value = null;
            // 
            // ayudaENTC_Deposito
            // 
            this.ayudaENTC_Deposito.ActivarAyudaAuto = false;
            this.tableLayoutPanel1.SetColumnSpan(this.ayudaENTC_Deposito, 4);
            this.ayudaENTC_Deposito.ContainerService = null;
            this.ayudaENTC_Deposito.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ayudaENTC_Deposito.EnabledAyudaButton = true;
            this.ayudaENTC_Deposito.Location = new System.Drawing.Point(153, 165);
            this.ayudaENTC_Deposito.LongitudAceptada = 0;
            this.ayudaENTC_Deposito.MyInstanciaAyuda = Delfin.Controls.Entidad.InstanciaAyuda.Habilitado;
            this.ayudaENTC_Deposito.Name = "ayudaENTC_Deposito";
            this.ayudaENTC_Deposito.RellenaCeros = false;
            this.ayudaENTC_Deposito.Size = new System.Drawing.Size(559, 20);
            this.ayudaENTC_Deposito.TabIndex = 18;
            this.ayudaENTC_Deposito.Tipo = Delfin.Controls.Entidad.TipoTextBoxAyuda.AlfaNumerico;
            this.ayudaENTC_Deposito.Value = null;
            // 
            // lblNAVE_Codigo
            // 
            this.lblNAVE_Codigo.AutoSize = true;
            this.lblNAVE_Codigo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblNAVE_Codigo.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNAVE_Codigo.Location = new System.Drawing.Point(10, 34);
            this.lblNAVE_Codigo.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
            this.lblNAVE_Codigo.Name = "lblNAVE_Codigo";
            this.lblNAVE_Codigo.Size = new System.Drawing.Size(137, 20);
            this.lblNAVE_Codigo.TabIndex = 123;
            this.lblNAVE_Codigo.Text = "Nave:";
            // 
            // NAVE_Codigo
            // 
            this.NAVE_Codigo.FormattingEnabled = true;
            this.NAVE_Codigo.Location = new System.Drawing.Point(153, 30);
            this.NAVE_Codigo.Name = "NAVE_Codigo";
            this.NAVE_Codigo.Size = new System.Drawing.Size(193, 21);
            this.NAVE_Codigo.TabIndex = 128;
            // 
            // rbtnGeneral
            // 
            this.rbtnGeneral.AutoSize = true;
            this.rbtnGeneral.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtnGeneral.Location = new System.Drawing.Point(368, 3);
            this.rbtnGeneral.Name = "rbtnGeneral";
            this.rbtnGeneral.Size = new System.Drawing.Size(69, 17);
            this.rbtnGeneral.TabIndex = 129;
            this.rbtnGeneral.TabStop = true;
            this.rbtnGeneral.Text = "General";
            this.rbtnGeneral.UseVisualStyleBackColor = true;
            // 
            // rbtnDetallado
            // 
            this.rbtnDetallado.AutoSize = true;
            this.rbtnDetallado.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtnDetallado.Location = new System.Drawing.Point(518, 3);
            this.rbtnDetallado.Name = "rbtnDetallado";
            this.rbtnDetallado.Size = new System.Drawing.Size(79, 17);
            this.rbtnDetallado.TabIndex = 129;
            this.rbtnDetallado.TabStop = true;
            this.rbtnDetallado.Text = "Detallado";
            this.rbtnDetallado.UseVisualStyleBackColor = true;
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
            this.panelCaption2.Location = new System.Drawing.Point(0, 291);
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
            this.toolStripLabel2.Size = new System.Drawing.Size(35, 22);
            this.toolStripLabel2.Text = "of {0}";
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
            this.grdItems.Location = new System.Drawing.Point(0, 317);
            this.grdItems.Name = "grdItems";
            // 
            // 
            // 
            this.grdItems.RootElement.ControlBounds = new System.Drawing.Rectangle(0, 317, 240, 150);
            this.grdItems.Size = new System.Drawing.Size(950, 108);
            this.grdItems.TabIndex = 58;
            this.grdItems.TabStop = false;
            // 
            // REP011LView
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
            this.Name = "REP011LView";
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
        private System.Windows.Forms.Label lblCONS_CodRGM;
        private System.Windows.Forms.Label lblFechaIniEmbarque;
        private System.Windows.Forms.Label lblVendedor;
        private System.Windows.Forms.Label lblDeposito;
        private System.Windows.Forms.Label lblTransportista;
        private System.Windows.Forms.Label lblNro_Viaje;
        private System.Windows.Forms.Label lblFechaFinEtaZarpe;
        private System.Windows.Forms.Label lblFechaFinEmbarque;
        private System.Windows.Forms.Label lblFechaIniEtaZarpe;
        private System.Windows.Forms.TextBox txtNVIA_NroViaje;
        private Infrastructure.WinForms.Controls.MaskDateTime mdtNVIA_FechaIniEtaZarpe;
        private Infrastructure.WinForms.Controls.MaskDateTime mdtNVIA_FechaFinEtaZarpe;
        private Infrastructure.WinForms.Controls.MaskDateTime mdtCCOT_FecIniEmbarque;
        private Infrastructure.WinForms.Controls.MaskDateTime mdtCCOT_FecFinEmbarque;
        private Controls.Tipos.ComboBoxConstantes cmbCONS_CodRGM;
        private Controls.Entidad ayudaENTC_Transportista;
        private Controls.Entidad ayudaENTC_Vendedor;
        private Controls.Entidad ayudaENTC_Deposito;
        private System.Windows.Forms.Label lblNAVE_Codigo;
        private System.Windows.Forms.ComboBox NAVE_Codigo;
        private System.Windows.Forms.RadioButton rbtnGeneral;
        private System.Windows.Forms.RadioButton rbtnDetallado;

    }
}
