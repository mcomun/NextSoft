namespace Delfin.Principal
{
   partial class REP001LView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(REP001LView));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnExportar = new System.Windows.Forms.Button();
            this.btnDeshacer = new System.Windows.Forms.Button();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.panelCaption1 = new Infrastructure.WinForms.Controls.PanelCaption();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.CCOT_FechaDesde = new Infrastructure.WinForms.Controls.MaskDateTime();
            this.CCOT_FechaHasta = new Infrastructure.WinForms.Controls.MaskDateTime();
            this.lblFechaHasta = new System.Windows.Forms.Label();
            this.lblFechaDesde = new System.Windows.Forms.Label();
            this.ENTC_CodCliente = new Delfin.Controls.Entidad(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.ENTC_CodTransportista = new Delfin.Controls.Entidad(this.components);
            this.TIPO_CodCDT = new Delfin.Controls.Tipos.ComboBoxTipos();
            this.label3 = new System.Windows.Forms.Label();
            this.lblTIPO_CodPAIOrigen = new System.Windows.Forms.Label();
            this.TIPO_CodPAIOrigen = new Delfin.Controls.Tipos.ComboBoxTipos();
            this.PUER_CodOrigen = new Infrastructure.WinForms.Controls.ComboBox.ComboBox(this.components);
            this.lblPUER_CodOrigen = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.TIPO_CodTRF = new Delfin.Controls.Tipos.ComboBoxTipos();
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
            this.panel1.TabIndex = 40;
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
            this.btnExportar.TabIndex = 4;
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
            this.btnDeshacer.TabIndex = 3;
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
            this.btnBuscar.TabIndex = 2;
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
            this.panelCaption1.TabIndex = 43;
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
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.CCOT_FechaDesde, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.CCOT_FechaHasta, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblFechaHasta, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblFechaDesde, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.ENTC_CodCliente, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.ENTC_CodTransportista, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.TIPO_CodCDT, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.lblTIPO_CodPAIOrigen, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.TIPO_CodPAIOrigen, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.PUER_CodOrigen, 4, 4);
            this.tableLayoutPanel1.Controls.Add(this.lblPUER_CodOrigen, 3, 4);
            this.tableLayoutPanel1.Controls.Add(this.label4, 3, 3);
            this.tableLayoutPanel1.Controls.Add(this.TIPO_CodTRF, 4, 3);
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
            this.tableLayoutPanel1.TabIndex = 44;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(10, 34);
            this.label1.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 162;
            this.label1.Text = "Cliente:";
            // 
            // CCOT_FechaDesde
            // 
            this.CCOT_FechaDesde.Location = new System.Drawing.Point(153, 3);
            this.CCOT_FechaDesde.MinimumSize = new System.Drawing.Size(100, 22);
            this.CCOT_FechaDesde.Name = "CCOT_FechaDesde";
            this.CCOT_FechaDesde.NSActiveMouse = false;
            this.CCOT_FechaDesde.NSActiveMsgFecha = false;
            this.CCOT_FechaDesde.NSChangeDate = true;
            this.CCOT_FechaDesde.NSDigitos = 4;
            this.CCOT_FechaDesde.NSFecha = null;
            this.CCOT_FechaDesde.NSSetDateNow = false;
            this.CCOT_FechaDesde.Size = new System.Drawing.Size(194, 22);
            this.CCOT_FechaDesde.TabIndex = 85;
            // 
            // CCOT_FechaHasta
            // 
            this.CCOT_FechaHasta.Location = new System.Drawing.Point(518, 3);
            this.CCOT_FechaHasta.MinimumSize = new System.Drawing.Size(100, 22);
            this.CCOT_FechaHasta.Name = "CCOT_FechaHasta";
            this.CCOT_FechaHasta.NSActiveMouse = false;
            this.CCOT_FechaHasta.NSActiveMsgFecha = false;
            this.CCOT_FechaHasta.NSChangeDate = true;
            this.CCOT_FechaHasta.NSDigitos = 4;
            this.CCOT_FechaHasta.NSFecha = null;
            this.CCOT_FechaHasta.NSSetDateNow = false;
            this.CCOT_FechaHasta.Size = new System.Drawing.Size(194, 22);
            this.CCOT_FechaHasta.TabIndex = 86;
            // 
            // lblFechaHasta
            // 
            this.lblFechaHasta.AutoSize = true;
            this.lblFechaHasta.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFechaHasta.Location = new System.Drawing.Point(375, 7);
            this.lblFechaHasta.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
            this.lblFechaHasta.Name = "lblFechaHasta";
            this.lblFechaHasta.Size = new System.Drawing.Size(44, 13);
            this.lblFechaHasta.TabIndex = 87;
            this.lblFechaHasta.Text = "Hasta:";
            // 
            // lblFechaDesde
            // 
            this.lblFechaDesde.AutoSize = true;
            this.lblFechaDesde.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFechaDesde.Location = new System.Drawing.Point(10, 7);
            this.lblFechaDesde.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
            this.lblFechaDesde.Name = "lblFechaDesde";
            this.lblFechaDesde.Size = new System.Drawing.Size(48, 13);
            this.lblFechaDesde.TabIndex = 84;
            this.lblFechaDesde.Text = "Desde:";
            // 
            // ENTC_CodCliente
            // 
            this.ENTC_CodCliente.ActivarAyudaAuto = false;
            this.tableLayoutPanel1.SetColumnSpan(this.ENTC_CodCliente, 4);
            this.ENTC_CodCliente.ContainerService = null;
            this.ENTC_CodCliente.EnabledAyudaButton = true;
            this.ENTC_CodCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ENTC_CodCliente.Location = new System.Drawing.Point(153, 30);
            this.ENTC_CodCliente.LongitudAceptada = 0;
            this.ENTC_CodCliente.MyInstanciaAyuda = Delfin.Controls.Entidad.InstanciaAyuda.Habilitado;
            this.ENTC_CodCliente.Name = "ENTC_CodCliente";
            this.ENTC_CodCliente.RellenaCeros = false;
            this.ENTC_CodCliente.Size = new System.Drawing.Size(559, 21);
            this.ENTC_CodCliente.TabIndex = 161;
            this.ENTC_CodCliente.Tipo = Delfin.Controls.Entidad.TipoTextBoxAyuda.AlfaNumerico;
            this.ENTC_CodCliente.TipoEntidad = Delfin.Controls.TiposEntidad.TIPE_Cliente;
            this.ENTC_CodCliente.Value = null;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(10, 61);
            this.label2.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 13);
            this.label2.TabIndex = 163;
            this.label2.Text = "Transportista:";
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
            this.ENTC_CodTransportista.TabIndex = 164;
            this.ENTC_CodTransportista.Tipo = Delfin.Controls.Entidad.TipoTextBoxAyuda.AlfaNumerico;
            this.ENTC_CodTransportista.TipoEntidad = Delfin.Controls.TiposEntidad.TIPE_Transportista;
            this.ENTC_CodTransportista.Value = null;
            // 
            // TIPO_CodCDT
            // 
            this.TIPO_CodCDT.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.TIPO_CodCDT.FormattingEnabled = true;
            this.TIPO_CodCDT.Location = new System.Drawing.Point(153, 84);
            this.TIPO_CodCDT.Name = "TIPO_CodCDT";
            this.TIPO_CodCDT.Size = new System.Drawing.Size(194, 21);
            this.TIPO_CodCDT.TabIndex = 165;
            this.TIPO_CodCDT.TiposSelectedItem = null;
            this.TIPO_CodCDT.TiposSelectedValue = null;
            this.TIPO_CodCDT.TiposTitulo = null;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(10, 88);
            this.label3.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 13);
            this.label3.TabIndex = 166;
            this.label3.Text = "Comodity:";
            // 
            // lblTIPO_CodPAIOrigen
            // 
            this.lblTIPO_CodPAIOrigen.AutoSize = true;
            this.lblTIPO_CodPAIOrigen.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTIPO_CodPAIOrigen.Location = new System.Drawing.Point(10, 115);
            this.lblTIPO_CodPAIOrigen.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
            this.lblTIPO_CodPAIOrigen.Name = "lblTIPO_CodPAIOrigen";
            this.lblTIPO_CodPAIOrigen.Size = new System.Drawing.Size(77, 13);
            this.lblTIPO_CodPAIOrigen.TabIndex = 167;
            this.lblTIPO_CodPAIOrigen.Text = "País Origen:";
            // 
            // TIPO_CodPAIOrigen
            // 
            this.TIPO_CodPAIOrigen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.TIPO_CodPAIOrigen.FormattingEnabled = true;
            this.TIPO_CodPAIOrigen.Location = new System.Drawing.Point(153, 111);
            this.TIPO_CodPAIOrigen.Name = "TIPO_CodPAIOrigen";
            this.TIPO_CodPAIOrigen.Size = new System.Drawing.Size(194, 21);
            this.TIPO_CodPAIOrigen.TabIndex = 168;
            this.TIPO_CodPAIOrigen.Tag = "TIPO_CodPAIOrigenMSGERROR";
            this.TIPO_CodPAIOrigen.TiposSelectedItem = null;
            this.TIPO_CodPAIOrigen.TiposSelectedValue = null;
            this.TIPO_CodPAIOrigen.TiposTitulo = null;
            // 
            // PUER_CodOrigen
            // 
            this.PUER_CodOrigen.ComboIntSelectedValue = null;
            this.PUER_CodOrigen.ComboSelectedItem = null;
            this.PUER_CodOrigen.ComboStrSelectedValue = null;
            this.PUER_CodOrigen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.PUER_CodOrigen.FormattingEnabled = true;
            this.PUER_CodOrigen.Location = new System.Drawing.Point(518, 111);
            this.PUER_CodOrigen.Name = "PUER_CodOrigen";
            this.PUER_CodOrigen.Size = new System.Drawing.Size(194, 21);
            this.PUER_CodOrigen.TabIndex = 170;
            this.PUER_CodOrigen.Tag = "PUER_CodOrigenMSGERROR";
            // 
            // lblPUER_CodOrigen
            // 
            this.lblPUER_CodOrigen.AutoSize = true;
            this.lblPUER_CodOrigen.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPUER_CodOrigen.Location = new System.Drawing.Point(375, 115);
            this.lblPUER_CodOrigen.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
            this.lblPUER_CodOrigen.Name = "lblPUER_CodOrigen";
            this.lblPUER_CodOrigen.Size = new System.Drawing.Size(91, 13);
            this.lblPUER_CodOrigen.TabIndex = 169;
            this.lblPUER_CodOrigen.Text = "Puerto Origen:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(375, 88);
            this.label4.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 13);
            this.label4.TabIndex = 171;
            this.label4.Text = "Tráfico:";
            // 
            // TIPO_CodTRF
            // 
            this.TIPO_CodTRF.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.TIPO_CodTRF.FormattingEnabled = true;
            this.TIPO_CodTRF.Location = new System.Drawing.Point(518, 84);
            this.TIPO_CodTRF.Name = "TIPO_CodTRF";
            this.TIPO_CodTRF.Size = new System.Drawing.Size(194, 21);
            this.TIPO_CodTRF.TabIndex = 172;
            this.TIPO_CodTRF.TiposSelectedItem = null;
            this.TIPO_CodTRF.TiposSelectedValue = null;
            this.TIPO_CodTRF.TiposTitulo = null;
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
            this.panelCaption2.TabIndex = 45;
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
            this.TitleView.Caption = "Reporte Fletamento";
            this.TitleView.Dock = System.Windows.Forms.DockStyle.Top;
            this.TitleView.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TitleView.FormIcon = ((System.Drawing.Image)(resources.GetObject("TitleView.FormIcon")));
            this.TitleView.InactiveGradientHighColor = System.Drawing.Color.SteelBlue;
            this.TitleView.InactiveGradientLowColor = System.Drawing.Color.MidnightBlue;
            this.TitleView.Location = new System.Drawing.Point(0, 0);
            this.TitleView.Name = "TitleView";
            this.TitleView.Size = new System.Drawing.Size(950, 26);
            this.TitleView.TabIndex = 39;
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
            this.grdItems.TabIndex = 51;
            this.grdItems.TabStop = false;
            // 
            // REP001LView
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
            this.Name = "REP001LView";
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
      private System.Windows.Forms.Label lblFechaDesde;
      private Infrastructure.WinForms.Controls.MaskDateTime CCOT_FechaDesde;
      private System.Windows.Forms.ContextMenuStrip cmsMenu;
      private System.Windows.Forms.ToolStripMenuItem tsmMarcarTodos;
      private System.Windows.Forms.ToolStripMenuItem tsmMarcarSeleccionados;
      private System.Windows.Forms.ToolStripMenuItem tsmDesmarcarTodos;
      private System.Windows.Forms.ToolStripMenuItem tsmDesmarcarSeleccionados;
      private Infrastructure.WinForms.Controls.MaskDateTime CCOT_FechaHasta;
      private System.Windows.Forms.Label lblFechaHasta;
      private Controls.Entidad ENTC_CodCliente;
      private System.Windows.Forms.Label label1;
      private System.Windows.Forms.Label label2;
      private Controls.Entidad ENTC_CodTransportista;
      private Controls.Tipos.ComboBoxTipos TIPO_CodCDT;
      private System.Windows.Forms.Label label3;
      private System.Windows.Forms.Label lblTIPO_CodPAIOrigen;
      private Controls.Tipos.ComboBoxTipos TIPO_CodPAIOrigen;
      private Infrastructure.WinForms.Controls.ComboBox.ComboBox PUER_CodOrigen;
      private System.Windows.Forms.Label lblPUER_CodOrigen;
      private System.Windows.Forms.Label label4;
      private Controls.Tipos.ComboBoxTipos TIPO_CodTRF;
      private Telerik.WinControls.UI.RadGridView grdItems;
      private System.Windows.Forms.Button btnExportar;

   }
}
