namespace Delfin.Principal
{
   partial class REP003LView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(REP003LView));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnExportar = new System.Windows.Forms.Button();
            this.btnDeshacer = new System.Windows.Forms.Button();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.panelCaption1 = new Infrastructure.WinForms.Controls.PanelCaption();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lblCONS_CodRGM = new System.Windows.Forms.Label();
            this.CONS_CodRGM = new Delfin.Controls.Tipos.ComboBoxConstantes();
            this.lblCONS_CodVIA = new System.Windows.Forms.Label();
            this.CONS_CodVIA = new Delfin.Controls.Tipos.ComboBoxConstantes();
            this.label2 = new System.Windows.Forms.Label();
            this.ENTC_CodTransportista = new Delfin.Controls.Entidad(this.components);
            this.lblCCOT_FecEmiDesde = new System.Windows.Forms.Label();
            this.CCOT_FecEmiDesde = new Infrastructure.WinForms.Controls.MaskDateTime();
            this.lblTIPO_CodPAIOrigen = new System.Windows.Forms.Label();
            this.TIPO_CodPAIOrigen = new Delfin.Controls.Tipos.ComboBoxTipos();
            this.lblPUER_CodOrigen = new System.Windows.Forms.Label();
            this.PUER_CodOrigen = new Infrastructure.WinForms.Controls.ComboBox.ComboBox(this.components);
            this.lblTIPO_CodPAIDestino = new System.Windows.Forms.Label();
            this.TIPO_CodPAIDestino = new Delfin.Controls.Tipos.ComboBoxTipos();
            this.lblPUER_CodDestino = new System.Windows.Forms.Label();
            this.PUER_CodDestino = new Infrastructure.WinForms.Controls.ComboBox.ComboBox(this.components);
            this.lblCCOT_FecEmiHasta = new System.Windows.Forms.Label();
            this.CCOT_FecEmiHasta = new Infrastructure.WinForms.Controls.MaskDateTime();
            this.panelCaption2 = new Infrastructure.WinForms.Controls.PanelCaption();
            this.cmsMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmMarcarTodos = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmMarcarSeleccionados = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmDesmarcarTodos = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmDesmarcarSeleccionados = new System.Windows.Forms.ToolStripMenuItem();
            this.TitleView = new Infrastructure.WinForms.Controls.FormTitle();
            this.grdItems = new Telerik.WinControls.UI.RadGridView();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.cmsMenu.SuspendLayout();
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
            this.tableLayoutPanel1.Controls.Add(this.CONS_CodRGM, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblCONS_CodVIA, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.CONS_CodVIA, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.ENTC_CodTransportista, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.lblCCOT_FecEmiDesde, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.CCOT_FecEmiDesde, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblTIPO_CodPAIOrigen, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.TIPO_CodPAIOrigen, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.lblPUER_CodOrigen, 3, 3);
            this.tableLayoutPanel1.Controls.Add(this.PUER_CodOrigen, 4, 3);
            this.tableLayoutPanel1.Controls.Add(this.lblTIPO_CodPAIDestino, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.TIPO_CodPAIDestino, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.lblPUER_CodDestino, 3, 4);
            this.tableLayoutPanel1.Controls.Add(this.PUER_CodDestino, 4, 4);
            this.tableLayoutPanel1.Controls.Add(this.lblCCOT_FecEmiHasta, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.CCOT_FecEmiHasta, 4, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 102);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(950, 135);
            this.tableLayoutPanel1.TabIndex = 3;
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
            // CONS_CodRGM
            // 
            this.CONS_CodRGM.ConstantesSelectedItem = null;
            this.CONS_CodRGM.ConstantesSelectedValue = null;
            this.CONS_CodRGM.ConstantesTitulo = null;
            this.CONS_CodRGM.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CONS_CodRGM.FormattingEnabled = true;
            this.CONS_CodRGM.Location = new System.Drawing.Point(153, 3);
            this.CONS_CodRGM.Name = "CONS_CodRGM";
            this.CONS_CodRGM.Size = new System.Drawing.Size(194, 21);
            this.CONS_CodRGM.TabIndex = 1;
            this.CONS_CodRGM.Tag = "CONS_CodRGMMSGERROR";
            // 
            // lblCONS_CodVIA
            // 
            this.lblCONS_CodVIA.AutoSize = true;
            this.lblCONS_CodVIA.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCONS_CodVIA.Location = new System.Drawing.Point(375, 7);
            this.lblCONS_CodVIA.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
            this.lblCONS_CodVIA.Name = "lblCONS_CodVIA";
            this.lblCONS_CodVIA.Size = new System.Drawing.Size(31, 13);
            this.lblCONS_CodVIA.TabIndex = 2;
            this.lblCONS_CodVIA.Text = "Vía:";
            // 
            // CONS_CodVIA
            // 
            this.CONS_CodVIA.ConstantesSelectedItem = null;
            this.CONS_CodVIA.ConstantesSelectedValue = null;
            this.CONS_CodVIA.ConstantesTitulo = null;
            this.CONS_CodVIA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CONS_CodVIA.FormattingEnabled = true;
            this.CONS_CodVIA.Location = new System.Drawing.Point(518, 3);
            this.CONS_CodVIA.Name = "CONS_CodVIA";
            this.CONS_CodVIA.Size = new System.Drawing.Size(194, 21);
            this.CONS_CodVIA.TabIndex = 3;
            this.CONS_CodVIA.Tag = "CONS_CodViaMSGERROR";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(10, 61);
            this.label2.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(108, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Linea Transporte:";
            // 
            // ENTC_CodTransportista
            // 
            this.ENTC_CodTransportista.ActivarAyudaAuto = false;
            this.tableLayoutPanel1.SetColumnSpan(this.ENTC_CodTransportista, 4);
            this.ENTC_CodTransportista.ContainerService = null;
            this.ENTC_CodTransportista.EnabledAyudaButton = true;
            this.ENTC_CodTransportista.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ENTC_CodTransportista.Location = new System.Drawing.Point(153, 57);
            this.ENTC_CodTransportista.LongitudAceptada = 0;
            this.ENTC_CodTransportista.MyInstanciaAyuda = Delfin.Controls.Entidad.InstanciaAyuda.Habilitado;
            this.ENTC_CodTransportista.Name = "ENTC_CodTransportista";
            this.ENTC_CodTransportista.RellenaCeros = false;
            this.ENTC_CodTransportista.Size = new System.Drawing.Size(559, 21);
            this.ENTC_CodTransportista.TabIndex = 9;
            this.ENTC_CodTransportista.Tipo = Delfin.Controls.Entidad.TipoTextBoxAyuda.AlfaNumerico;
            this.ENTC_CodTransportista.TipoEntidad = Delfin.Controls.TiposEntidad.TIPE_Transportista;
            this.ENTC_CodTransportista.Value = null;
            // 
            // lblCCOT_FecEmiDesde
            // 
            this.lblCCOT_FecEmiDesde.AutoSize = true;
            this.lblCCOT_FecEmiDesde.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCCOT_FecEmiDesde.Location = new System.Drawing.Point(10, 34);
            this.lblCCOT_FecEmiDesde.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
            this.lblCCOT_FecEmiDesde.Name = "lblCCOT_FecEmiDesde";
            this.lblCCOT_FecEmiDesde.Size = new System.Drawing.Size(94, 13);
            this.lblCCOT_FecEmiDesde.TabIndex = 4;
            this.lblCCOT_FecEmiDesde.Text = "Fecha Desde:";
            // 
            // CCOT_FecEmiDesde
            // 
            this.CCOT_FecEmiDesde.Location = new System.Drawing.Point(153, 30);
            this.CCOT_FecEmiDesde.MinimumSize = new System.Drawing.Size(100, 22);
            this.CCOT_FecEmiDesde.Name = "CCOT_FecEmiDesde";
            this.CCOT_FecEmiDesde.NSActiveMouse = false;
            this.CCOT_FecEmiDesde.NSActiveMsgFecha = false;
            this.CCOT_FecEmiDesde.NSChangeDate = true;
            this.CCOT_FecEmiDesde.NSDigitos = 4;
            this.CCOT_FecEmiDesde.NSFecha = null;
            this.CCOT_FecEmiDesde.NSSetDateNow = false;
            this.CCOT_FecEmiDesde.Size = new System.Drawing.Size(194, 22);
            this.CCOT_FecEmiDesde.TabIndex = 5;
            // 
            // lblTIPO_CodPAIOrigen
            // 
            this.lblTIPO_CodPAIOrigen.AutoSize = true;
            this.lblTIPO_CodPAIOrigen.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTIPO_CodPAIOrigen.Location = new System.Drawing.Point(10, 88);
            this.lblTIPO_CodPAIOrigen.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
            this.lblTIPO_CodPAIOrigen.Name = "lblTIPO_CodPAIOrigen";
            this.lblTIPO_CodPAIOrigen.Size = new System.Drawing.Size(77, 13);
            this.lblTIPO_CodPAIOrigen.TabIndex = 13;
            this.lblTIPO_CodPAIOrigen.Text = "País Origen:";
            // 
            // TIPO_CodPAIOrigen
            // 
            this.TIPO_CodPAIOrigen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.TIPO_CodPAIOrigen.FormattingEnabled = true;
            this.TIPO_CodPAIOrigen.Location = new System.Drawing.Point(153, 84);
            this.TIPO_CodPAIOrigen.Name = "TIPO_CodPAIOrigen";
            this.TIPO_CodPAIOrigen.Size = new System.Drawing.Size(194, 21);
            this.TIPO_CodPAIOrigen.TabIndex = 14;
            this.TIPO_CodPAIOrigen.Tag = "TIPO_CodPAIOrigenMSGERROR";
            this.TIPO_CodPAIOrigen.TiposSelectedItem = null;
            this.TIPO_CodPAIOrigen.TiposSelectedValue = null;
            this.TIPO_CodPAIOrigen.TiposTitulo = null;
            // 
            // lblPUER_CodOrigen
            // 
            this.lblPUER_CodOrigen.AutoSize = true;
            this.lblPUER_CodOrigen.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPUER_CodOrigen.Location = new System.Drawing.Point(375, 88);
            this.lblPUER_CodOrigen.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
            this.lblPUER_CodOrigen.Name = "lblPUER_CodOrigen";
            this.lblPUER_CodOrigen.Size = new System.Drawing.Size(91, 13);
            this.lblPUER_CodOrigen.TabIndex = 15;
            this.lblPUER_CodOrigen.Text = "Puerto Origen:";
            // 
            // PUER_CodOrigen
            // 
            this.PUER_CodOrigen.ComboIntSelectedValue = null;
            this.PUER_CodOrigen.ComboSelectedItem = null;
            this.PUER_CodOrigen.ComboStrSelectedValue = null;
            this.PUER_CodOrigen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.PUER_CodOrigen.FormattingEnabled = true;
            this.PUER_CodOrigen.Location = new System.Drawing.Point(518, 84);
            this.PUER_CodOrigen.Name = "PUER_CodOrigen";
            this.PUER_CodOrigen.Size = new System.Drawing.Size(194, 21);
            this.PUER_CodOrigen.TabIndex = 16;
            this.PUER_CodOrigen.Tag = "PUER_CodOrigenMSGERROR";
            // 
            // lblTIPO_CodPAIDestino
            // 
            this.lblTIPO_CodPAIDestino.AutoSize = true;
            this.lblTIPO_CodPAIDestino.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTIPO_CodPAIDestino.Location = new System.Drawing.Point(10, 115);
            this.lblTIPO_CodPAIDestino.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
            this.lblTIPO_CodPAIDestino.Name = "lblTIPO_CodPAIDestino";
            this.lblTIPO_CodPAIDestino.Size = new System.Drawing.Size(82, 13);
            this.lblTIPO_CodPAIDestino.TabIndex = 17;
            this.lblTIPO_CodPAIDestino.Text = "País Destino:";
            // 
            // TIPO_CodPAIDestino
            // 
            this.TIPO_CodPAIDestino.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.TIPO_CodPAIDestino.FormattingEnabled = true;
            this.TIPO_CodPAIDestino.Location = new System.Drawing.Point(153, 111);
            this.TIPO_CodPAIDestino.Name = "TIPO_CodPAIDestino";
            this.TIPO_CodPAIDestino.Size = new System.Drawing.Size(194, 21);
            this.TIPO_CodPAIDestino.TabIndex = 18;
            this.TIPO_CodPAIDestino.Tag = "TIPO_CodPAIOrigenMSGERROR";
            this.TIPO_CodPAIDestino.TiposSelectedItem = null;
            this.TIPO_CodPAIDestino.TiposSelectedValue = null;
            this.TIPO_CodPAIDestino.TiposTitulo = null;
            // 
            // lblPUER_CodDestino
            // 
            this.lblPUER_CodDestino.AutoSize = true;
            this.lblPUER_CodDestino.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPUER_CodDestino.Location = new System.Drawing.Point(375, 115);
            this.lblPUER_CodDestino.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
            this.lblPUER_CodDestino.Name = "lblPUER_CodDestino";
            this.lblPUER_CodDestino.Size = new System.Drawing.Size(96, 13);
            this.lblPUER_CodDestino.TabIndex = 19;
            this.lblPUER_CodDestino.Text = "Puerto Destino:";
            // 
            // PUER_CodDestino
            // 
            this.PUER_CodDestino.ComboIntSelectedValue = null;
            this.PUER_CodDestino.ComboSelectedItem = null;
            this.PUER_CodDestino.ComboStrSelectedValue = null;
            this.PUER_CodDestino.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.PUER_CodDestino.FormattingEnabled = true;
            this.PUER_CodDestino.Location = new System.Drawing.Point(518, 111);
            this.PUER_CodDestino.Name = "PUER_CodDestino";
            this.PUER_CodDestino.Size = new System.Drawing.Size(194, 21);
            this.PUER_CodDestino.TabIndex = 20;
            this.PUER_CodDestino.Tag = "PUER_CodOrigenMSGERROR";
            // 
            // lblCCOT_FecEmiHasta
            // 
            this.lblCCOT_FecEmiHasta.AutoSize = true;
            this.lblCCOT_FecEmiHasta.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCCOT_FecEmiHasta.Location = new System.Drawing.Point(375, 34);
            this.lblCCOT_FecEmiHasta.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
            this.lblCCOT_FecEmiHasta.Name = "lblCCOT_FecEmiHasta";
            this.lblCCOT_FecEmiHasta.Size = new System.Drawing.Size(91, 13);
            this.lblCCOT_FecEmiHasta.TabIndex = 21;
            this.lblCCOT_FecEmiHasta.Text = "Fecha Hasta:";
            // 
            // CCOT_FecEmiHasta
            // 
            this.CCOT_FecEmiHasta.Location = new System.Drawing.Point(518, 30);
            this.CCOT_FecEmiHasta.MinimumSize = new System.Drawing.Size(100, 22);
            this.CCOT_FecEmiHasta.Name = "CCOT_FecEmiHasta";
            this.CCOT_FecEmiHasta.NSActiveMouse = false;
            this.CCOT_FecEmiHasta.NSActiveMsgFecha = false;
            this.CCOT_FecEmiHasta.NSChangeDate = true;
            this.CCOT_FecEmiHasta.NSDigitos = 4;
            this.CCOT_FecEmiHasta.NSFecha = null;
            this.CCOT_FecEmiHasta.NSSetDateNow = false;
            this.CCOT_FecEmiHasta.Size = new System.Drawing.Size(194, 22);
            this.CCOT_FecEmiHasta.TabIndex = 22;
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
            this.panelCaption2.Location = new System.Drawing.Point(0, 237);
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
            this.TitleView.Caption = "Reporte Ordenes de Venta";
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
            // grdItems
            // 
            this.grdItems.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.grdItems.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdItems.Location = new System.Drawing.Point(0, 263);
            this.grdItems.Name = "grdItems";
            // 
            // 
            // 
            this.grdItems.RootElement.ControlBounds = new System.Drawing.Rectangle(0, 263, 240, 150);
            this.grdItems.Size = new System.Drawing.Size(950, 187);
            this.grdItems.TabIndex = 5;
            this.grdItems.TabStop = false;
            // 
            // REP003LView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.Controls.Add(this.grdItems);
            this.Controls.Add(this.panelCaption2);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.panelCaption1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.TitleView);
            this.Name = "REP003LView";
            this.Size = new System.Drawing.Size(950, 450);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.cmsMenu.ResumeLayout(false);
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
      private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
      private Infrastructure.WinForms.Controls.PanelCaption panelCaption2;
      private System.Windows.Forms.ContextMenuStrip cmsMenu;
      private System.Windows.Forms.ToolStripMenuItem tsmMarcarTodos;
      private System.Windows.Forms.ToolStripMenuItem tsmMarcarSeleccionados;
      private System.Windows.Forms.ToolStripMenuItem tsmDesmarcarTodos;
      private System.Windows.Forms.ToolStripMenuItem tsmDesmarcarSeleccionados;
      private Infrastructure.WinForms.Controls.MaskDateTime CCOT_FecEmiDesde;
      private System.Windows.Forms.Label lblCCOT_FecEmiDesde;
      private System.Windows.Forms.Label label2;
      private Controls.Entidad ENTC_CodTransportista;
      private System.Windows.Forms.Label lblTIPO_CodPAIOrigen;
      private Controls.Tipos.ComboBoxTipos TIPO_CodPAIOrigen;
      private Infrastructure.WinForms.Controls.ComboBox.ComboBox PUER_CodOrigen;
      private System.Windows.Forms.Label lblPUER_CodOrigen;
      private Telerik.WinControls.UI.RadGridView grdItems;
      private System.Windows.Forms.Button btnExportar;
      private System.Windows.Forms.Label lblTIPO_CodPAIDestino;
      private Controls.Tipos.ComboBoxTipos TIPO_CodPAIDestino;
      private System.Windows.Forms.Label lblPUER_CodDestino;
      private Infrastructure.WinForms.Controls.ComboBox.ComboBox PUER_CodDestino;
      private Controls.Tipos.ComboBoxConstantes CONS_CodRGM;
      private System.Windows.Forms.Label lblCONS_CodRGM;
      private System.Windows.Forms.Label lblCONS_CodVIA;
      private Controls.Tipos.ComboBoxConstantes CONS_CodVIA;
      private System.Windows.Forms.Label lblCCOT_FecEmiHasta;
      private Infrastructure.WinForms.Controls.MaskDateTime CCOT_FecEmiHasta;

   }
}
