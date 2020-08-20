namespace Delfin.Principal
{
    partial class REP010LView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(REP010LView));
            this.cmsMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmMarcarTodos = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmMarcarSeleccionados = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmDesmarcarTodos = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmDesmarcarSeleccionados = new System.Windows.Forms.ToolStripMenuItem();
            this.TitleView = new Infrastructure.WinForms.Controls.FormTitle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnExportar = new System.Windows.Forms.Button();
            this.btnDeshacer = new System.Windows.Forms.Button();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.panelCaption1 = new Infrastructure.WinForms.Controls.PanelCaption();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.mdtREBA_FecFinTarifa = new Infrastructure.WinForms.Controls.MaskDateTime();
            this.lblHBL = new System.Windows.Forms.Label();
            this.lblREBA_FecFinTarifa = new System.Windows.Forms.Label();
            this.txtNroHBL = new System.Windows.Forms.TextBox();
            this.mdtREBA_FecIniTarifa = new Infrastructure.WinForms.Controls.MaskDateTime();
            this.lblOV = new System.Windows.Forms.Label();
            this.lblREBA_FecIniTarifa = new System.Windows.Forms.Label();
            this.txtNroOV = new System.Windows.Forms.TextBox();
            this.lblCliente = new System.Windows.Forms.Label();
            this.ayudaENTC_CodCliente = new Delfin.Controls.Entidad(this.components);
            this.lblFechaIniLlegada = new System.Windows.Forms.Label();
            this.mdtNVIA_FechaIniLlegada = new Infrastructure.WinForms.Controls.MaskDateTime();
            this.lblFechaFinLlegada = new System.Windows.Forms.Label();
            this.mdtNVIA_FechaFinLlegada = new Infrastructure.WinForms.Controls.MaskDateTime();
            this.lblFechaFinEmbarque = new System.Windows.Forms.Label();
            this.mdtNVIA_FechaFinEmbarque = new Infrastructure.WinForms.Controls.MaskDateTime();
            this.mdtNVIA_FechaIniEmbarque = new Infrastructure.WinForms.Controls.MaskDateTime();
            this.lblFechaIniEmbarque = new System.Windows.Forms.Label();
            this.lblENTC_CodTransportista = new System.Windows.Forms.Label();
            this.ayudaENTC_CodTransportista = new Delfin.Controls.Entidad(this.components);
            this.lblREBA_Tipo = new System.Windows.Forms.Label();
            this.cmbREBA_Tipo = new Infrastructure.WinForms.Controls.ComboBox.ComboBox(this.components);
            this.panelCaption2 = new Infrastructure.WinForms.Controls.PanelCaption();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.label1 = new System.Windows.Forms.Label();
            this.navItemsReport = new System.Windows.Forms.BindingNavigator(this.components);
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripTextBox1 = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton4 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
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
            // TitleView
            // 
            this.TitleView.AllowActive = false;
            this.TitleView.AntiAlias = false;
            this.TitleView.Caption = "Reporte Rebate\\GRR";
            this.TitleView.Dock = System.Windows.Forms.DockStyle.Top;
            this.TitleView.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TitleView.FormIcon = global::Delfin.Principal.Properties.Resources.document_attachment_24x24;
            this.TitleView.InactiveGradientHighColor = System.Drawing.Color.SteelBlue;
            this.TitleView.InactiveGradientLowColor = System.Drawing.Color.MidnightBlue;
            this.TitleView.Location = new System.Drawing.Point(0, 0);
            this.TitleView.Name = "TitleView";
            this.TitleView.Size = new System.Drawing.Size(950, 26);
            this.TitleView.TabIndex = 0;
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
            this.panel1.TabIndex = 1;
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
            this.panelCaption1.TabIndex = 2;
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
            this.tableLayoutPanel1.Controls.Add(this.mdtREBA_FecFinTarifa, 4, 4);
            this.tableLayoutPanel1.Controls.Add(this.lblHBL, 0, 6);
            this.tableLayoutPanel1.Controls.Add(this.lblREBA_FecFinTarifa, 3, 4);
            this.tableLayoutPanel1.Controls.Add(this.txtNroHBL, 1, 6);
            this.tableLayoutPanel1.Controls.Add(this.mdtREBA_FecIniTarifa, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.lblOV, 3, 6);
            this.tableLayoutPanel1.Controls.Add(this.lblREBA_FecIniTarifa, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.txtNroOV, 4, 6);
            this.tableLayoutPanel1.Controls.Add(this.lblCliente, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.ayudaENTC_CodCliente, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.lblFechaIniLlegada, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.mdtNVIA_FechaIniLlegada, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.lblFechaFinLlegada, 3, 3);
            this.tableLayoutPanel1.Controls.Add(this.mdtNVIA_FechaFinLlegada, 4, 3);
            this.tableLayoutPanel1.Controls.Add(this.lblFechaFinEmbarque, 3, 2);
            this.tableLayoutPanel1.Controls.Add(this.mdtNVIA_FechaFinEmbarque, 4, 2);
            this.tableLayoutPanel1.Controls.Add(this.mdtNVIA_FechaIniEmbarque, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.lblFechaIniEmbarque, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.lblENTC_CodTransportista, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.ayudaENTC_CodTransportista, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblREBA_Tipo, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.cmbREBA_Tipo, 1, 0);
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
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // mdtREBA_FecFinTarifa
            // 
            this.mdtREBA_FecFinTarifa.Location = new System.Drawing.Point(518, 111);
            this.mdtREBA_FecFinTarifa.MinimumSize = new System.Drawing.Size(100, 22);
            this.mdtREBA_FecFinTarifa.Name = "mdtREBA_FecFinTarifa";
            this.mdtREBA_FecFinTarifa.NSActiveMouse = false;
            this.mdtREBA_FecFinTarifa.NSActiveMsgFecha = false;
            this.mdtREBA_FecFinTarifa.NSChangeDate = true;
            this.mdtREBA_FecFinTarifa.NSDigitos = 4;
            this.mdtREBA_FecFinTarifa.NSFecha = null;
            this.mdtREBA_FecFinTarifa.NSSetDateNow = false;
            this.mdtREBA_FecFinTarifa.Size = new System.Drawing.Size(144, 22);
            this.mdtREBA_FecFinTarifa.TabIndex = 15;
            // 
            // lblHBL
            // 
            this.lblHBL.AutoSize = true;
            this.lblHBL.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHBL.Location = new System.Drawing.Point(10, 169);
            this.lblHBL.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
            this.lblHBL.Name = "lblHBL";
            this.lblHBL.Size = new System.Drawing.Size(34, 13);
            this.lblHBL.TabIndex = 18;
            this.lblHBL.Text = "HBL:";
            // 
            // lblREBA_FecFinTarifa
            // 
            this.lblREBA_FecFinTarifa.AutoSize = true;
            this.lblREBA_FecFinTarifa.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblREBA_FecFinTarifa.Location = new System.Drawing.Point(375, 115);
            this.lblREBA_FecFinTarifa.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
            this.lblREBA_FecFinTarifa.Name = "lblREBA_FecFinTarifa";
            this.lblREBA_FecFinTarifa.Size = new System.Drawing.Size(105, 13);
            this.lblREBA_FecFinTarifa.TabIndex = 14;
            this.lblREBA_FecFinTarifa.Text = "Fecha Fin Tarifa :";
            // 
            // txtNroHBL
            // 
            this.txtNroHBL.Location = new System.Drawing.Point(153, 165);
            this.txtNroHBL.Name = "txtNroHBL";
            this.txtNroHBL.Size = new System.Drawing.Size(194, 20);
            this.txtNroHBL.TabIndex = 19;
            // 
            // mdtREBA_FecIniTarifa
            // 
            this.mdtREBA_FecIniTarifa.Location = new System.Drawing.Point(153, 111);
            this.mdtREBA_FecIniTarifa.MinimumSize = new System.Drawing.Size(100, 22);
            this.mdtREBA_FecIniTarifa.Name = "mdtREBA_FecIniTarifa";
            this.mdtREBA_FecIniTarifa.NSActiveMouse = false;
            this.mdtREBA_FecIniTarifa.NSActiveMsgFecha = false;
            this.mdtREBA_FecIniTarifa.NSChangeDate = true;
            this.mdtREBA_FecIniTarifa.NSDigitos = 4;
            this.mdtREBA_FecIniTarifa.NSFecha = null;
            this.mdtREBA_FecIniTarifa.NSSetDateNow = false;
            this.mdtREBA_FecIniTarifa.Size = new System.Drawing.Size(144, 22);
            this.mdtREBA_FecIniTarifa.TabIndex = 13;
            // 
            // lblOV
            // 
            this.lblOV.AutoSize = true;
            this.lblOV.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOV.Location = new System.Drawing.Point(375, 169);
            this.lblOV.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
            this.lblOV.Name = "lblOV";
            this.lblOV.Size = new System.Drawing.Size(73, 13);
            this.lblOV.TabIndex = 20;
            this.lblOV.Text = "Numero OV";
            // 
            // lblREBA_FecIniTarifa
            // 
            this.lblREBA_FecIniTarifa.AutoSize = true;
            this.lblREBA_FecIniTarifa.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblREBA_FecIniTarifa.Location = new System.Drawing.Point(10, 115);
            this.lblREBA_FecIniTarifa.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
            this.lblREBA_FecIniTarifa.Name = "lblREBA_FecIniTarifa";
            this.lblREBA_FecIniTarifa.Size = new System.Drawing.Size(116, 13);
            this.lblREBA_FecIniTarifa.TabIndex = 12;
            this.lblREBA_FecIniTarifa.Text = "Fecha Inicio Tarifa:";
            // 
            // txtNroOV
            // 
            this.txtNroOV.Location = new System.Drawing.Point(518, 165);
            this.txtNroOV.Name = "txtNroOV";
            this.txtNroOV.Size = new System.Drawing.Size(194, 20);
            this.txtNroOV.TabIndex = 21;
            // 
            // lblCliente
            // 
            this.lblCliente.AutoSize = true;
            this.lblCliente.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCliente.Location = new System.Drawing.Point(10, 142);
            this.lblCliente.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
            this.lblCliente.Name = "lblCliente";
            this.lblCliente.Size = new System.Drawing.Size(52, 13);
            this.lblCliente.TabIndex = 16;
            this.lblCliente.Text = "Cliente:";
            // 
            // ayudaENTC_CodCliente
            // 
            this.ayudaENTC_CodCliente.ActivarAyudaAuto = false;
            this.tableLayoutPanel1.SetColumnSpan(this.ayudaENTC_CodCliente, 4);
            this.ayudaENTC_CodCliente.ContainerService = null;
            this.ayudaENTC_CodCliente.EnabledAyudaButton = true;
            this.ayudaENTC_CodCliente.Location = new System.Drawing.Point(153, 138);
            this.ayudaENTC_CodCliente.LongitudAceptada = 0;
            this.ayudaENTC_CodCliente.MyInstanciaAyuda = Delfin.Controls.Entidad.InstanciaAyuda.Habilitado;
            this.ayudaENTC_CodCliente.Name = "ayudaENTC_CodCliente";
            this.ayudaENTC_CodCliente.RellenaCeros = false;
            this.ayudaENTC_CodCliente.Size = new System.Drawing.Size(559, 20);
            this.ayudaENTC_CodCliente.TabIndex = 17;
            this.ayudaENTC_CodCliente.Tipo = Delfin.Controls.Entidad.TipoTextBoxAyuda.AlfaNumerico;
            this.ayudaENTC_CodCliente.UsarTipoEntidad = true;
            this.ayudaENTC_CodCliente.Value = null;
            // 
            // lblFechaIniLlegada
            // 
            this.lblFechaIniLlegada.AutoSize = true;
            this.lblFechaIniLlegada.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFechaIniLlegada.Location = new System.Drawing.Point(10, 88);
            this.lblFechaIniLlegada.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
            this.lblFechaIniLlegada.Name = "lblFechaIniLlegada";
            this.lblFechaIniLlegada.Size = new System.Drawing.Size(105, 13);
            this.lblFechaIniLlegada.TabIndex = 8;
            this.lblFechaIniLlegada.Text = "Fecha Inicio ETA:";
            // 
            // mdtNVIA_FechaIniLlegada
            // 
            this.mdtNVIA_FechaIniLlegada.Location = new System.Drawing.Point(153, 84);
            this.mdtNVIA_FechaIniLlegada.MinimumSize = new System.Drawing.Size(100, 22);
            this.mdtNVIA_FechaIniLlegada.Name = "mdtNVIA_FechaIniLlegada";
            this.mdtNVIA_FechaIniLlegada.NSActiveMouse = false;
            this.mdtNVIA_FechaIniLlegada.NSActiveMsgFecha = false;
            this.mdtNVIA_FechaIniLlegada.NSChangeDate = true;
            this.mdtNVIA_FechaIniLlegada.NSDigitos = 4;
            this.mdtNVIA_FechaIniLlegada.NSFecha = null;
            this.mdtNVIA_FechaIniLlegada.NSSetDateNow = false;
            this.mdtNVIA_FechaIniLlegada.Size = new System.Drawing.Size(144, 22);
            this.mdtNVIA_FechaIniLlegada.TabIndex = 9;
            // 
            // lblFechaFinLlegada
            // 
            this.lblFechaFinLlegada.AutoSize = true;
            this.lblFechaFinLlegada.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFechaFinLlegada.Location = new System.Drawing.Point(375, 88);
            this.lblFechaFinLlegada.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
            this.lblFechaFinLlegada.Name = "lblFechaFinLlegada";
            this.lblFechaFinLlegada.Size = new System.Drawing.Size(94, 13);
            this.lblFechaFinLlegada.TabIndex = 10;
            this.lblFechaFinLlegada.Text = "Fecha Fin ETA :";
            // 
            // mdtNVIA_FechaFinLlegada
            // 
            this.mdtNVIA_FechaFinLlegada.Location = new System.Drawing.Point(518, 84);
            this.mdtNVIA_FechaFinLlegada.MinimumSize = new System.Drawing.Size(100, 22);
            this.mdtNVIA_FechaFinLlegada.Name = "mdtNVIA_FechaFinLlegada";
            this.mdtNVIA_FechaFinLlegada.NSActiveMouse = false;
            this.mdtNVIA_FechaFinLlegada.NSActiveMsgFecha = false;
            this.mdtNVIA_FechaFinLlegada.NSChangeDate = true;
            this.mdtNVIA_FechaFinLlegada.NSDigitos = 4;
            this.mdtNVIA_FechaFinLlegada.NSFecha = null;
            this.mdtNVIA_FechaFinLlegada.NSSetDateNow = false;
            this.mdtNVIA_FechaFinLlegada.Size = new System.Drawing.Size(144, 22);
            this.mdtNVIA_FechaFinLlegada.TabIndex = 11;
            // 
            // lblFechaFinEmbarque
            // 
            this.lblFechaFinEmbarque.AutoSize = true;
            this.lblFechaFinEmbarque.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFechaFinEmbarque.Location = new System.Drawing.Point(375, 61);
            this.lblFechaFinEmbarque.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
            this.lblFechaFinEmbarque.Name = "lblFechaFinEmbarque";
            this.lblFechaFinEmbarque.Size = new System.Drawing.Size(131, 13);
            this.lblFechaFinEmbarque.TabIndex = 6;
            this.lblFechaFinEmbarque.Text = "Fecha Fin Embarque :";
            // 
            // mdtNVIA_FechaFinEmbarque
            // 
            this.mdtNVIA_FechaFinEmbarque.Location = new System.Drawing.Point(518, 57);
            this.mdtNVIA_FechaFinEmbarque.MinimumSize = new System.Drawing.Size(100, 22);
            this.mdtNVIA_FechaFinEmbarque.Name = "mdtNVIA_FechaFinEmbarque";
            this.mdtNVIA_FechaFinEmbarque.NSActiveMouse = false;
            this.mdtNVIA_FechaFinEmbarque.NSActiveMsgFecha = false;
            this.mdtNVIA_FechaFinEmbarque.NSChangeDate = true;
            this.mdtNVIA_FechaFinEmbarque.NSDigitos = 4;
            this.mdtNVIA_FechaFinEmbarque.NSFecha = null;
            this.mdtNVIA_FechaFinEmbarque.NSSetDateNow = false;
            this.mdtNVIA_FechaFinEmbarque.Size = new System.Drawing.Size(144, 22);
            this.mdtNVIA_FechaFinEmbarque.TabIndex = 7;
            // 
            // mdtNVIA_FechaIniEmbarque
            // 
            this.mdtNVIA_FechaIniEmbarque.Location = new System.Drawing.Point(153, 57);
            this.mdtNVIA_FechaIniEmbarque.MinimumSize = new System.Drawing.Size(100, 22);
            this.mdtNVIA_FechaIniEmbarque.Name = "mdtNVIA_FechaIniEmbarque";
            this.mdtNVIA_FechaIniEmbarque.NSActiveMouse = false;
            this.mdtNVIA_FechaIniEmbarque.NSActiveMsgFecha = false;
            this.mdtNVIA_FechaIniEmbarque.NSChangeDate = true;
            this.mdtNVIA_FechaIniEmbarque.NSDigitos = 4;
            this.mdtNVIA_FechaIniEmbarque.NSFecha = null;
            this.mdtNVIA_FechaIniEmbarque.NSSetDateNow = false;
            this.mdtNVIA_FechaIniEmbarque.Size = new System.Drawing.Size(144, 22);
            this.mdtNVIA_FechaIniEmbarque.TabIndex = 5;
            // 
            // lblFechaIniEmbarque
            // 
            this.lblFechaIniEmbarque.AutoSize = true;
            this.lblFechaIniEmbarque.Font = new System.Drawing.Font("Verdana", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFechaIniEmbarque.Location = new System.Drawing.Point(10, 61);
            this.lblFechaIniEmbarque.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
            this.lblFechaIniEmbarque.Name = "lblFechaIniEmbarque";
            this.lblFechaIniEmbarque.Size = new System.Drawing.Size(136, 12);
            this.lblFechaIniEmbarque.TabIndex = 4;
            this.lblFechaIniEmbarque.Text = "Fecha Inicio Embarque:";
            // 
            // lblENTC_CodTransportista
            // 
            this.lblENTC_CodTransportista.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblENTC_CodTransportista.Location = new System.Drawing.Point(10, 34);
            this.lblENTC_CodTransportista.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
            this.lblENTC_CodTransportista.Name = "lblENTC_CodTransportista";
            this.lblENTC_CodTransportista.Size = new System.Drawing.Size(102, 17);
            this.lblENTC_CodTransportista.TabIndex = 2;
            this.lblENTC_CodTransportista.Text = "Transportista:";
            // 
            // ayudaENTC_CodTransportista
            // 
            this.ayudaENTC_CodTransportista.ActivarAyudaAuto = false;
            this.tableLayoutPanel1.SetColumnSpan(this.ayudaENTC_CodTransportista, 4);
            this.ayudaENTC_CodTransportista.ContainerService = null;
            this.ayudaENTC_CodTransportista.EnabledAyudaButton = true;
            this.ayudaENTC_CodTransportista.Location = new System.Drawing.Point(153, 30);
            this.ayudaENTC_CodTransportista.LongitudAceptada = 0;
            this.ayudaENTC_CodTransportista.MyInstanciaAyuda = Delfin.Controls.Entidad.InstanciaAyuda.Habilitado;
            this.ayudaENTC_CodTransportista.Name = "ayudaENTC_CodTransportista";
            this.ayudaENTC_CodTransportista.RellenaCeros = false;
            this.ayudaENTC_CodTransportista.Size = new System.Drawing.Size(559, 20);
            this.ayudaENTC_CodTransportista.TabIndex = 3;
            this.ayudaENTC_CodTransportista.Tag = "ENTC_CodTransportistaMSGERROR";
            this.ayudaENTC_CodTransportista.Tipo = Delfin.Controls.Entidad.TipoTextBoxAyuda.AlfaNumerico;
            this.ayudaENTC_CodTransportista.TipoEntidad = Delfin.Controls.TiposEntidad.TIPE_Transportista;
            this.ayudaENTC_CodTransportista.UsarTipoEntidad = true;
            this.ayudaENTC_CodTransportista.Value = null;
            // 
            // lblREBA_Tipo
            // 
            this.lblREBA_Tipo.AutoSize = true;
            this.lblREBA_Tipo.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblREBA_Tipo.Location = new System.Drawing.Point(10, 7);
            this.lblREBA_Tipo.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
            this.lblREBA_Tipo.Name = "lblREBA_Tipo";
            this.lblREBA_Tipo.Size = new System.Drawing.Size(39, 13);
            this.lblREBA_Tipo.TabIndex = 0;
            this.lblREBA_Tipo.Text = "Tipo:";
            // 
            // cmbREBA_Tipo
            // 
            this.cmbREBA_Tipo.ComboIntSelectedValue = null;
            this.cmbREBA_Tipo.ComboSelectedItem = null;
            this.cmbREBA_Tipo.ComboStrSelectedValue = null;
            this.cmbREBA_Tipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbREBA_Tipo.FormattingEnabled = true;
            this.cmbREBA_Tipo.Location = new System.Drawing.Point(153, 3);
            this.cmbREBA_Tipo.Name = "cmbREBA_Tipo";
            this.cmbREBA_Tipo.Size = new System.Drawing.Size(194, 21);
            this.cmbREBA_Tipo.TabIndex = 1;
            this.cmbREBA_Tipo.Tag = "REBA_TipoMSGERROR";
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
            this.panelCaption2.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(375, 7);
            this.label1.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "HAMBURG SUD :";
            // 
            // navItemsReport
            // 
            this.navItemsReport.AddNewItem = null;
            this.navItemsReport.BackColor = System.Drawing.Color.LightSteelBlue;
            this.navItemsReport.CountItem = this.toolStripLabel1;
            this.navItemsReport.DeleteItem = null;
            this.navItemsReport.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.navItemsReport.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1,
            this.toolStripButton2,
            this.toolStripSeparator1,
            this.toolStripLabel1,
            this.toolStripTextBox1,
            this.toolStripSeparator2,
            this.toolStripButton3,
            this.toolStripButton4,
            this.toolStripSeparator3});
            this.navItemsReport.Location = new System.Drawing.Point(0, 425);
            this.navItemsReport.MoveFirstItem = this.toolStripButton4;
            this.navItemsReport.MoveLastItem = this.toolStripButton1;
            this.navItemsReport.MoveNextItem = this.toolStripButton2;
            this.navItemsReport.MovePreviousItem = this.toolStripButton3;
            this.navItemsReport.Name = "navItemsReport";
            this.navItemsReport.PositionItem = this.toolStripTextBox1;
            this.navItemsReport.Size = new System.Drawing.Size(950, 25);
            this.navItemsReport.TabIndex = 6;
            this.navItemsReport.Text = "bindingNavigator1";
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
            this.grdItems.TabIndex = 5;
            this.grdItems.TabStop = false;
            // 
            // REP010LView
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
            this.Name = "REP010LView";
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
        private Infrastructure.WinForms.Controls.FormTitle TitleView;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnExportar;
        private System.Windows.Forms.Button btnDeshacer;
        private System.Windows.Forms.Button btnBuscar;
        private Infrastructure.WinForms.Controls.PanelCaption panelCaption1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private Infrastructure.WinForms.Controls.MaskDateTime mdtNVIA_FechaIniEmbarque;
        private System.Windows.Forms.Label lblFechaFinEmbarque;
        private System.Windows.Forms.Label lblFechaIniEmbarque;
        private Infrastructure.WinForms.Controls.MaskDateTime mdtNVIA_FechaFinEmbarque;
        private System.Windows.Forms.Label lblCliente;
        private Infrastructure.WinForms.Controls.PanelCaption panelCaption2;
        private System.Windows.Forms.Label lblFechaIniLlegada;
        private System.Windows.Forms.Label lblFechaFinLlegada;
        private Infrastructure.WinForms.Controls.MaskDateTime mdtNVIA_FechaIniLlegada;
        private Infrastructure.WinForms.Controls.MaskDateTime mdtNVIA_FechaFinLlegada;
        private System.Windows.Forms.TextBox txtNroHBL;
        private System.Windows.Forms.TextBox txtNroOV;
        private System.Windows.Forms.Label lblOV;
        private System.Windows.Forms.Label lblHBL;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        //private Controls.Entidad ayudaENTC_CodCliente;
        //private Controls.Entidad ayudaENTC_Cliente;
        private Controls.Entidad ayudaENTC_CodCliente;
        //private System.Windows.Forms.RadioButton rbtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.BindingNavigator navItemsReport;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton toolStripButton3;
        private System.Windows.Forms.ToolStripButton toolStripButton4;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private Telerik.WinControls.UI.RadGridView grdItems;
        private Controls.Entidad ayudaENTC_CodTransportista;
        private System.Windows.Forms.Label lblENTC_CodTransportista;
        private System.Windows.Forms.Label lblREBA_Tipo;
        private Infrastructure.WinForms.Controls.ComboBox.ComboBox cmbREBA_Tipo;
        private Infrastructure.WinForms.Controls.MaskDateTime mdtREBA_FecFinTarifa;
        private System.Windows.Forms.Label lblREBA_FecFinTarifa;
        private Infrastructure.WinForms.Controls.MaskDateTime mdtREBA_FecIniTarifa;
        private System.Windows.Forms.Label lblREBA_FecIniTarifa;

    }
}
