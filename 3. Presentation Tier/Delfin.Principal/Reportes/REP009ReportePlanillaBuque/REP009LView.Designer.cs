namespace Delfin.Principal
{
   partial class REP009LView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(REP009LView));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnExportar = new System.Windows.Forms.Button();
            this.btnDeshacer = new System.Windows.Forms.Button();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.panelCaption1 = new Infrastructure.WinForms.Controls.PanelCaption();
            this.panelCaption2 = new Infrastructure.WinForms.Controls.PanelCaption();
            this.cmsMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmMarcarTodos = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmMarcarSeleccionados = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmDesmarcarTodos = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmDesmarcarSeleccionados = new System.Windows.Forms.ToolStripMenuItem();
            this.TitleView = new Infrastructure.WinForms.Controls.FormTitle();
            this.mdtNVIA_FechaIni = new Infrastructure.WinForms.Controls.MaskDateTime();
            this.lblFechaFin = new System.Windows.Forms.Label();
            this.cmbCONS_CodRGM = new Delfin.Controls.Tipos.ComboBoxConstantes();
            this.lblCONS_CodRGM = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lblFechaIni = new System.Windows.Forms.Label();
            this.mdtNVIA_FechaFin = new Infrastructure.WinForms.Controls.MaskDateTime();
            this.lblMAN = new System.Windows.Forms.Label();
            this.ayudaENTC_CodTransportista = new Delfin.Controls.Entidad(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.cmbNAVE_Codigo = new System.Windows.Forms.ComboBox();
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
            this.panel1.SuspendLayout();
            this.cmsMenu.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.navItemsReport)).BeginInit();
            this.navItemsReport.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdItems)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdItems.MasterTemplate)).BeginInit();
            this.SuspendLayout();
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
            this.panelCaption2.TabIndex = 4;
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
            this.TitleView.Caption = "Reporte Planilla Buque";
            this.TitleView.Dock = System.Windows.Forms.DockStyle.Top;
            this.TitleView.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TitleView.FormIcon = ((System.Drawing.Image)(resources.GetObject("TitleView.FormIcon")));
            this.TitleView.InactiveGradientHighColor = System.Drawing.Color.SteelBlue;
            this.TitleView.InactiveGradientLowColor = System.Drawing.Color.MidnightBlue;
            this.TitleView.Location = new System.Drawing.Point(0, 0);
            this.TitleView.Name = "TitleView";
            this.TitleView.Size = new System.Drawing.Size(950, 26);
            this.TitleView.TabIndex = 0;
            // 
            // mdtNVIA_FechaIni
            // 
            this.mdtNVIA_FechaIni.Location = new System.Drawing.Point(153, 30);
            this.mdtNVIA_FechaIni.MinimumSize = new System.Drawing.Size(100, 22);
            this.mdtNVIA_FechaIni.Name = "mdtNVIA_FechaIni";
            this.mdtNVIA_FechaIni.NSActiveMouse = false;
            this.mdtNVIA_FechaIni.NSActiveMsgFecha = false;
            this.mdtNVIA_FechaIni.NSChangeDate = true;
            this.mdtNVIA_FechaIni.NSDigitos = 4;
            this.mdtNVIA_FechaIni.NSFecha = null;
            this.mdtNVIA_FechaIni.NSSetDateNow = false;
            this.mdtNVIA_FechaIni.Size = new System.Drawing.Size(144, 22);
            this.mdtNVIA_FechaIni.TabIndex = 5;
            // 
            // lblFechaFin
            // 
            this.lblFechaFin.AutoSize = true;
            this.lblFechaFin.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFechaFin.Location = new System.Drawing.Point(375, 34);
            this.lblFechaFin.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
            this.lblFechaFin.Name = "lblFechaFin";
            this.lblFechaFin.Size = new System.Drawing.Size(78, 13);
            this.lblFechaFin.TabIndex = 4;
            this.lblFechaFin.Text = "Fecha Fin :";
            // 
            // cmbCONS_CodRGM
            // 
            this.cmbCONS_CodRGM.ConstantesSelectedItem = null;
            this.cmbCONS_CodRGM.ConstantesSelectedValue = null;
            this.cmbCONS_CodRGM.ConstantesTitulo = null;
            this.cmbCONS_CodRGM.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCONS_CodRGM.FormattingEnabled = true;
            this.cmbCONS_CodRGM.Location = new System.Drawing.Point(153, 3);
            this.cmbCONS_CodRGM.Name = "cmbCONS_CodRGM";
            this.cmbCONS_CodRGM.Session = null;
            this.cmbCONS_CodRGM.Size = new System.Drawing.Size(194, 21);
            this.cmbCONS_CodRGM.TabIndex = 1;
            this.cmbCONS_CodRGM.Tag = "CONS_CodRGMMSGERROR";
            // 
            // lblCONS_CodRGM
            // 
            this.lblCONS_CodRGM.AutoSize = true;
            this.lblCONS_CodRGM.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCONS_CodRGM.Location = new System.Drawing.Point(10, 7);
            this.lblCONS_CodRGM.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
            this.lblCONS_CodRGM.Name = "lblCONS_CodRGM";
            this.lblCONS_CodRGM.Size = new System.Drawing.Size(67, 13);
            this.lblCONS_CodRGM.TabIndex = 0;
            this.lblCONS_CodRGM.Text = "Régimen:";
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
            this.tableLayoutPanel1.Controls.Add(this.cmbCONS_CodRGM, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.mdtNVIA_FechaIni, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblFechaFin, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblFechaIni, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.mdtNVIA_FechaFin, 4, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblMAN, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.ayudaENTC_CodTransportista, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.cmbNAVE_Codigo, 1, 3);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 102);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(950, 108);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // lblFechaIni
            // 
            this.lblFechaIni.AutoSize = true;
            this.lblFechaIni.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFechaIni.Location = new System.Drawing.Point(10, 34);
            this.lblFechaIni.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
            this.lblFechaIni.Name = "lblFechaIni";
            this.lblFechaIni.Size = new System.Drawing.Size(91, 13);
            this.lblFechaIni.TabIndex = 4;
            this.lblFechaIni.Text = "Fecha Inicio:";
            // 
            // mdtNVIA_FechaFin
            // 
            this.mdtNVIA_FechaFin.Location = new System.Drawing.Point(518, 30);
            this.mdtNVIA_FechaFin.MinimumSize = new System.Drawing.Size(100, 22);
            this.mdtNVIA_FechaFin.Name = "mdtNVIA_FechaFin";
            this.mdtNVIA_FechaFin.NSActiveMouse = false;
            this.mdtNVIA_FechaFin.NSActiveMsgFecha = false;
            this.mdtNVIA_FechaFin.NSChangeDate = true;
            this.mdtNVIA_FechaFin.NSDigitos = 4;
            this.mdtNVIA_FechaFin.NSFecha = null;
            this.mdtNVIA_FechaFin.NSSetDateNow = false;
            this.mdtNVIA_FechaFin.Size = new System.Drawing.Size(144, 22);
            this.mdtNVIA_FechaFin.TabIndex = 5;
            // 
            // lblMAN
            // 
            this.lblMAN.AutoSize = true;
            this.lblMAN.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMAN.Location = new System.Drawing.Point(10, 61);
            this.lblMAN.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
            this.lblMAN.Name = "lblMAN";
            this.lblMAN.Size = new System.Drawing.Size(86, 13);
            this.lblMAN.TabIndex = 79;
            this.lblMAN.Text = "Transportista:";
            // 
            // ayudaENTC_CodTransportista
            // 
            this.ayudaENTC_CodTransportista.ActivarAyudaAuto = false;
            this.tableLayoutPanel1.SetColumnSpan(this.ayudaENTC_CodTransportista, 4);
            this.ayudaENTC_CodTransportista.ContainerService = null;
            this.ayudaENTC_CodTransportista.EnabledAyudaButton = true;
            this.ayudaENTC_CodTransportista.Location = new System.Drawing.Point(153, 57);
            this.ayudaENTC_CodTransportista.LongitudAceptada = 0;
            this.ayudaENTC_CodTransportista.MyInstanciaAyuda = Delfin.Controls.Entidad.InstanciaAyuda.Habilitado;
            this.ayudaENTC_CodTransportista.Name = "ayudaENTC_CodTransportista";
            this.ayudaENTC_CodTransportista.RellenaCeros = false;
            this.ayudaENTC_CodTransportista.Size = new System.Drawing.Size(559, 20);
            this.ayudaENTC_CodTransportista.TabIndex = 80;
            this.ayudaENTC_CodTransportista.Tipo = Delfin.Controls.Entidad.TipoTextBoxAyuda.AlfaNumerico;
            this.ayudaENTC_CodTransportista.TipoEntidad = Delfin.Controls.TiposEntidad.TIPE_Transportista;
            this.ayudaENTC_CodTransportista.UsarTipoEntidad = true;
            this.ayudaENTC_CodTransportista.Value = null;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(10, 88);
            this.label3.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 13);
            this.label3.TabIndex = 123;
            this.label3.Text = "Nave:";
            // 
            // cmbNAVE_Codigo
            // 
            this.cmbNAVE_Codigo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbNAVE_Codigo.Enabled = false;
            this.cmbNAVE_Codigo.FormattingEnabled = true;
            this.cmbNAVE_Codigo.Location = new System.Drawing.Point(153, 84);
            this.cmbNAVE_Codigo.Name = "cmbNAVE_Codigo";
            this.cmbNAVE_Codigo.Size = new System.Drawing.Size(194, 21);
            this.cmbNAVE_Codigo.TabIndex = 124;
            this.cmbNAVE_Codigo.Tag = "";
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
            this.navItemsReport.TabIndex = 58;
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
            this.grdItems.TabIndex = 59;
            this.grdItems.TabStop = false;
            // 
            // REP009LView
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
            this.Name = "REP009LView";
            this.Size = new System.Drawing.Size(950, 450);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.cmsMenu.ResumeLayout(false);
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

      private Infrastructure.WinForms.Controls.FormTitle TitleView;
      private System.Windows.Forms.Panel panel1;
      private System.Windows.Forms.Button btnDeshacer;
      private System.Windows.Forms.Button btnBuscar;
      private Infrastructure.WinForms.Controls.PanelCaption panelCaption1;
      private Infrastructure.WinForms.Controls.PanelCaption panelCaption2;
      private System.Windows.Forms.ContextMenuStrip cmsMenu;
      private System.Windows.Forms.ToolStripMenuItem tsmMarcarTodos;
      private System.Windows.Forms.ToolStripMenuItem tsmMarcarSeleccionados;
      private System.Windows.Forms.ToolStripMenuItem tsmDesmarcarTodos;
      private System.Windows.Forms.ToolStripMenuItem tsmDesmarcarSeleccionados;
      private System.Windows.Forms.Button btnExportar;
      private Infrastructure.WinForms.Controls.MaskDateTime mdtNVIA_FechaIni;
      private System.Windows.Forms.Label lblFechaFin;
      private Controls.Tipos.ComboBoxConstantes cmbCONS_CodRGM;
      private System.Windows.Forms.Label lblCONS_CodRGM;
      private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
      private System.Windows.Forms.Label lblFechaIni;
      private Infrastructure.WinForms.Controls.MaskDateTime mdtNVIA_FechaFin;
      private System.Windows.Forms.Label lblMAN;
      private Controls.Entidad ayudaENTC_CodTransportista;
      private System.Windows.Forms.Label label3;
      private System.Windows.Forms.ComboBox cmbNAVE_Codigo;
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

   }
}
