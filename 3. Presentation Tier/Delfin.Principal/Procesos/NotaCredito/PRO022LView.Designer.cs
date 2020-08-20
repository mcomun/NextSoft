namespace Delfin.Principal
{
   partial class PRO022LView
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
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PRO022LView));
         this.cmsMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
         this.editarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.eliminarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.tsmColumnas = new System.Windows.Forms.ToolStripMenuItem();
         this.pnBotones = new System.Windows.Forms.Panel();
         this.btnDeshacer = new System.Windows.Forms.Button();
         this.btnExportar = new System.Windows.Forms.Button();
         this.btnBuscar = new System.Windows.Forms.Button();
         this.btnNuevo = new System.Windows.Forms.Button();
         this.panelCaption1 = new Infrastructure.WinFormsControls.PanelCaption();
         this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
         this.dtpDOCV_FechaEmisionNCFin = new Infrastructure.WinForms.Controls.MaskTime();
         this.txtSERI_UnidadNegocio = new System.Windows.Forms.TextBox();
         this.dtpDOCV_FechaEmisionNCIni = new Infrastructure.WinForms.Controls.MaskTime();
         this.label4 = new System.Windows.Forms.Label();
         this.label5 = new System.Windows.Forms.Label();
         this.cmbSERI_Serie = new Infrastructure.WinForms.Controls.ComboBox.ComboBox(this.components);
         this.txaENTC_Codigo = new Delfin.Controls.EntidadDocIden();
         this.txtDOCV_NumeroFac = new System.Windows.Forms.TextBox();
         this.label3 = new System.Windows.Forms.Label();
         this.label2 = new System.Windows.Forms.Label();
         this.label8 = new System.Windows.Forms.Label();
         this.label1 = new System.Windows.Forms.Label();
         this.label6 = new System.Windows.Forms.Label();
         this.txtDOCV_NumeroNC = new System.Windows.Forms.TextBox();
         this.panelCaption2 = new Infrastructure.WinFormsControls.PanelCaption();
         this.grdItems = new Telerik.WinControls.UI.RadGridView();
         this.txtNumeroFact = new System.Windows.Forms.TextBox();
         this.navItems = new System.Windows.Forms.BindingNavigator(this.components);
         this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
         this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
         this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
         this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
         this.toolStripTextBox1 = new System.Windows.Forms.ToolStripTextBox();
         this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
         this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
         this.toolStripButton4 = new System.Windows.Forms.ToolStripButton();
         this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
         this.TitleView = new Infrastructure.WinFormsControls.FormTitle();
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
         this.pnBotones.Size = new System.Drawing.Size(968, 50);
         this.pnBotones.TabIndex = 42;
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
         this.btnBuscar.TabIndex = 2;
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
         this.panelCaption1.Size = new System.Drawing.Size(968, 26);
         this.panelCaption1.TabIndex = 1;
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
         this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 238F));
         this.tableLayoutPanel1.Controls.Add(this.dtpDOCV_FechaEmisionNCFin, 4, 2);
         this.tableLayoutPanel1.Controls.Add(this.txtSERI_UnidadNegocio, 4, 3);
         this.tableLayoutPanel1.Controls.Add(this.dtpDOCV_FechaEmisionNCIni, 1, 2);
         this.tableLayoutPanel1.Controls.Add(this.label4, 3, 3);
         this.tableLayoutPanel1.Controls.Add(this.label5, 0, 3);
         this.tableLayoutPanel1.Controls.Add(this.cmbSERI_Serie, 1, 3);
         this.tableLayoutPanel1.Controls.Add(this.txaENTC_Codigo, 1, 0);
         this.tableLayoutPanel1.Controls.Add(this.txtDOCV_NumeroFac, 4, 1);
         this.tableLayoutPanel1.Controls.Add(this.label3, 3, 1);
         this.tableLayoutPanel1.Controls.Add(this.label2, 3, 2);
         this.tableLayoutPanel1.Controls.Add(this.label8, 0, 2);
         this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
         this.tableLayoutPanel1.Controls.Add(this.label6, 0, 1);
         this.tableLayoutPanel1.Controls.Add(this.txtDOCV_NumeroNC, 1, 1);
         this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
         this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 102);
         this.tableLayoutPanel1.Name = "tableLayoutPanel1";
         this.tableLayoutPanel1.RowCount = 4;
         this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
         this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
         this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
         this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
         this.tableLayoutPanel1.Size = new System.Drawing.Size(968, 108);
         this.tableLayoutPanel1.TabIndex = 2;
         // 
         // dtpDOCV_FechaEmisionNCFin
         // 
         this.dtpDOCV_FechaEmisionNCFin.Location = new System.Drawing.Point(518, 57);
         this.dtpDOCV_FechaEmisionNCFin.MinimumSize = new System.Drawing.Size(100, 22);
         this.dtpDOCV_FechaEmisionNCFin.Name = "dtpDOCV_FechaEmisionNCFin";
         this.dtpDOCV_FechaEmisionNCFin.NSActiveMouse = false;
         this.dtpDOCV_FechaEmisionNCFin.NSActiveMsgFecha = false;
         this.dtpDOCV_FechaEmisionNCFin.NSChangeDate = true;
         this.dtpDOCV_FechaEmisionNCFin.NSDigitos = 4;
         this.dtpDOCV_FechaEmisionNCFin.NSFecha = null;
         this.dtpDOCV_FechaEmisionNCFin.NSFormato = Infrastructure.WinForms.Controls.FormatoMostrado.Fecha;
         this.dtpDOCV_FechaEmisionNCFin.NSSetDateNow = false;
         this.dtpDOCV_FechaEmisionNCFin.Size = new System.Drawing.Size(100, 22);
         this.dtpDOCV_FechaEmisionNCFin.TabIndex = 6;
         this.dtpDOCV_FechaEmisionNCFin.Tag = "DOCV_FechaEmisionMSGERROR";
         // 
         // txtSERI_UnidadNegocio
         // 
         this.txtSERI_UnidadNegocio.Location = new System.Drawing.Point(518, 84);
         this.txtSERI_UnidadNegocio.Name = "txtSERI_UnidadNegocio";
         this.txtSERI_UnidadNegocio.Size = new System.Drawing.Size(193, 20);
         this.txtSERI_UnidadNegocio.TabIndex = 16;
         // 
         // dtpDOCV_FechaEmisionNCIni
         // 
         this.dtpDOCV_FechaEmisionNCIni.Location = new System.Drawing.Point(153, 57);
         this.dtpDOCV_FechaEmisionNCIni.MinimumSize = new System.Drawing.Size(100, 22);
         this.dtpDOCV_FechaEmisionNCIni.Name = "dtpDOCV_FechaEmisionNCIni";
         this.dtpDOCV_FechaEmisionNCIni.NSActiveMouse = false;
         this.dtpDOCV_FechaEmisionNCIni.NSActiveMsgFecha = false;
         this.dtpDOCV_FechaEmisionNCIni.NSChangeDate = true;
         this.dtpDOCV_FechaEmisionNCIni.NSDigitos = 4;
         this.dtpDOCV_FechaEmisionNCIni.NSFecha = null;
         this.dtpDOCV_FechaEmisionNCIni.NSFormato = Infrastructure.WinForms.Controls.FormatoMostrado.Fecha;
         this.dtpDOCV_FechaEmisionNCIni.NSSetDateNow = false;
         this.dtpDOCV_FechaEmisionNCIni.Size = new System.Drawing.Size(100, 22);
         this.dtpDOCV_FechaEmisionNCIni.TabIndex = 5;
         this.dtpDOCV_FechaEmisionNCIni.Tag = "DOCV_FechaEmisionMSGERROR";
         // 
         // label4
         // 
         this.label4.AutoSize = true;
         this.label4.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.label4.Location = new System.Drawing.Point(375, 88);
         this.label4.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
         this.label4.Name = "label4";
         this.label4.Size = new System.Drawing.Size(113, 13);
         this.label4.TabIndex = 15;
         this.label4.Text = "Unidad de Negocio";
         // 
         // label5
         // 
         this.label5.AutoSize = true;
         this.label5.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.label5.Location = new System.Drawing.Point(10, 88);
         this.label5.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
         this.label5.Name = "label5";
         this.label5.Size = new System.Drawing.Size(46, 13);
         this.label5.TabIndex = 13;
         this.label5.Text = "Serie :";
         // 
         // cmbSERI_Serie
         // 
         this.cmbSERI_Serie.ComboIntSelectedValue = null;
         this.cmbSERI_Serie.ComboSelectedItem = null;
         this.cmbSERI_Serie.ComboStrSelectedValue = null;
         this.cmbSERI_Serie.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this.cmbSERI_Serie.FormattingEnabled = true;
         this.cmbSERI_Serie.Location = new System.Drawing.Point(153, 84);
         this.cmbSERI_Serie.Name = "cmbSERI_Serie";
         this.cmbSERI_Serie.Size = new System.Drawing.Size(194, 21);
         this.cmbSERI_Serie.TabIndex = 14;
         // 
         // txaENTC_Codigo
         // 
         this.txaENTC_Codigo.BackColor = System.Drawing.Color.LightSteelBlue;
         this.tableLayoutPanel1.SetColumnSpan(this.txaENTC_Codigo, 4);
         this.txaENTC_Codigo.CrearNuevaEntidad = false;
         this.txaENTC_Codigo.Location = new System.Drawing.Point(150, 0);
         this.txaENTC_Codigo.Margin = new System.Windows.Forms.Padding(0);
         this.txaENTC_Codigo.MinimumSize = new System.Drawing.Size(565, 27);
         this.txaENTC_Codigo.Name = "txaENTC_Codigo";
         this.txaENTC_Codigo.Size = new System.Drawing.Size(565, 27);
         this.txaENTC_Codigo.TabIndex = 5;
         this.txaENTC_Codigo.TagEntidad = null;
         this.txaENTC_Codigo.TiposEntidad = Delfin.Controls.TiposEntidad.TIPE_AgenciaAduanera;
         this.txaENTC_Codigo.txaENTC_DOCIDEN_Name = "txaENTC_DOCIDEN";
         this.txaENTC_Codigo.txaENTC_NOMCOMPLETO_Name = "txaENTC_NOMCOMPLETO";
         // 
         // txtDOCV_NumeroFac
         // 
         this.txtDOCV_NumeroFac.Location = new System.Drawing.Point(518, 30);
         this.txtDOCV_NumeroFac.Name = "txtDOCV_NumeroFac";
         this.txtDOCV_NumeroFac.Size = new System.Drawing.Size(194, 20);
         this.txtDOCV_NumeroFac.TabIndex = 3;
         // 
         // label3
         // 
         this.label3.AutoSize = true;
         this.label3.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.label3.Location = new System.Drawing.Point(375, 34);
         this.label3.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
         this.label3.Name = "label3";
         this.label3.Size = new System.Drawing.Size(85, 13);
         this.label3.TabIndex = 11;
         this.label3.Text = "Nro. Factura :";
         // 
         // label2
         // 
         this.label2.AutoSize = true;
         this.label2.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.label2.Location = new System.Drawing.Point(375, 61);
         this.label2.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
         this.label2.Name = "label2";
         this.label2.Size = new System.Drawing.Size(131, 13);
         this.label2.TabIndex = 10;
         this.label2.Text = "Fecha de Emisión Fin:";
         // 
         // label8
         // 
         this.label8.AutoSize = true;
         this.label8.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.label8.Location = new System.Drawing.Point(10, 61);
         this.label8.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
         this.label8.Name = "label8";
         this.label8.Size = new System.Drawing.Size(130, 13);
         this.label8.TabIndex = 9;
         this.label8.Text = "Fecha de Emisión Ini:";
         // 
         // label1
         // 
         this.label1.AutoSize = true;
         this.label1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.label1.Location = new System.Drawing.Point(10, 7);
         this.label1.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
         this.label1.Name = "label1";
         this.label1.Size = new System.Drawing.Size(52, 13);
         this.label1.TabIndex = 12;
         this.label1.Text = "Cliente:";
         // 
         // label6
         // 
         this.label6.AutoSize = true;
         this.label6.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.label6.Location = new System.Drawing.Point(10, 34);
         this.label6.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
         this.label6.Name = "label6";
         this.label6.Size = new System.Drawing.Size(134, 13);
         this.label6.TabIndex = 10;
         this.label6.Text = "Nro. Nota de Credito :";
         // 
         // txtDOCV_NumeroNC
         // 
         this.txtDOCV_NumeroNC.Location = new System.Drawing.Point(153, 30);
         this.txtDOCV_NumeroNC.Name = "txtDOCV_NumeroNC";
         this.txtDOCV_NumeroNC.Size = new System.Drawing.Size(194, 20);
         this.txtDOCV_NumeroNC.TabIndex = 2;
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
         this.panelCaption2.Location = new System.Drawing.Point(0, 210);
         this.panelCaption2.Name = "panelCaption2";
         this.panelCaption2.Size = new System.Drawing.Size(968, 26);
         this.panelCaption2.TabIndex = 3;
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
         this.grdItems.Size = new System.Drawing.Size(968, 296);
         this.grdItems.TabIndex = 4;
         this.grdItems.TabStop = false;
         // 
         // txtNumeroFact
         // 
         this.txtNumeroFact.Location = new System.Drawing.Point(615, 3);
         this.txtNumeroFact.Name = "txtNumeroFact";
         this.txtNumeroFact.Size = new System.Drawing.Size(193, 20);
         this.txtNumeroFact.TabIndex = 15;
         // 
         // navItems
         // 
         this.navItems.AddNewItem = null;
         this.navItems.BackColor = System.Drawing.Color.SteelBlue;
         this.navItems.CountItem = this.toolStripLabel1;
         this.navItems.DeleteItem = null;
         this.navItems.Dock = System.Windows.Forms.DockStyle.Bottom;
         this.navItems.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1,
            this.toolStripButton2,
            this.toolStripSeparator1,
            this.toolStripLabel1,
            this.toolStripTextBox1,
            this.toolStripSeparator2,
            this.toolStripButton3,
            this.toolStripButton4,
            this.bindingNavigatorSeparator2});
         this.navItems.Location = new System.Drawing.Point(0, 532);
         this.navItems.MoveFirstItem = this.toolStripButton1;
         this.navItems.MoveLastItem = this.toolStripButton4;
         this.navItems.MoveNextItem = this.toolStripButton3;
         this.navItems.MovePreviousItem = this.toolStripButton2;
         this.navItems.Name = "navItems";
         this.navItems.PositionItem = this.toolStripTextBox1;
         this.navItems.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
         this.navItems.Size = new System.Drawing.Size(968, 25);
         this.navItems.TabIndex = 44;
         this.navItems.Text = "bindingNavigator1";
         // 
         // toolStripLabel1
         // 
         this.toolStripLabel1.Name = "toolStripLabel1";
         this.toolStripLabel1.Size = new System.Drawing.Size(37, 22);
         this.toolStripLabel1.Text = "de {0}";
         this.toolStripLabel1.ToolTipText = "Número total de elementos";
         // 
         // toolStripButton1
         // 
         this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
         this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
         this.toolStripButton1.Name = "toolStripButton1";
         this.toolStripButton1.RightToLeftAutoMirrorImage = true;
         this.toolStripButton1.Size = new System.Drawing.Size(23, 22);
         this.toolStripButton1.Text = "Mover primero";
         // 
         // toolStripButton2
         // 
         this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
         this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
         this.toolStripButton2.Name = "toolStripButton2";
         this.toolStripButton2.RightToLeftAutoMirrorImage = true;
         this.toolStripButton2.Size = new System.Drawing.Size(23, 22);
         this.toolStripButton2.Text = "Mover anterior";
         // 
         // toolStripSeparator1
         // 
         this.toolStripSeparator1.Name = "toolStripSeparator1";
         this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
         // 
         // toolStripTextBox1
         // 
         this.toolStripTextBox1.AccessibleName = "Posición";
         this.toolStripTextBox1.AutoSize = false;
         this.toolStripTextBox1.Name = "toolStripTextBox1";
         this.toolStripTextBox1.Size = new System.Drawing.Size(50, 23);
         this.toolStripTextBox1.Text = "0";
         this.toolStripTextBox1.ToolTipText = "Posición actual";
         // 
         // toolStripSeparator2
         // 
         this.toolStripSeparator2.Name = "toolStripSeparator2";
         this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
         // 
         // toolStripButton3
         // 
         this.toolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
         this.toolStripButton3.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton3.Image")));
         this.toolStripButton3.Name = "toolStripButton3";
         this.toolStripButton3.RightToLeftAutoMirrorImage = true;
         this.toolStripButton3.Size = new System.Drawing.Size(23, 22);
         this.toolStripButton3.Text = "Mover siguiente";
         // 
         // toolStripButton4
         // 
         this.toolStripButton4.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
         this.toolStripButton4.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton4.Image")));
         this.toolStripButton4.Name = "toolStripButton4";
         this.toolStripButton4.RightToLeftAutoMirrorImage = true;
         this.toolStripButton4.Size = new System.Drawing.Size(23, 22);
         this.toolStripButton4.Text = "Mover último";
         // 
         // bindingNavigatorSeparator2
         // 
         this.bindingNavigatorSeparator2.Name = "bindingNavigatorSeparator2";
         this.bindingNavigatorSeparator2.Size = new System.Drawing.Size(6, 25);
         // 
         // TitleView
         // 
         this.TitleView.AllowActive = false;
         this.TitleView.AntiAlias = false;
         this.TitleView.Caption = "Nota de Crédito";
         this.TitleView.Dock = System.Windows.Forms.DockStyle.Top;
         this.TitleView.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         //this.TitleView.FormIcon = global::Delfin.Principal.Properties.Resources.Paper_07;
         this.TitleView.InactiveGradientHighColor = System.Drawing.Color.SteelBlue;
         this.TitleView.InactiveGradientLowColor = System.Drawing.Color.MidnightBlue;
         this.TitleView.Location = new System.Drawing.Point(0, 0);
         this.TitleView.Name = "TitleView";
         this.TitleView.Size = new System.Drawing.Size(968, 26);
         this.TitleView.TabIndex = 0;
         // 
         // PRO022LView
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
         this.Name = "PRO022LView";
         this.Size = new System.Drawing.Size(968, 557);
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
      private System.Windows.Forms.Button btnDeshacer;
      private System.Windows.Forms.Button btnExportar;
      private System.Windows.Forms.Button btnBuscar;
      private System.Windows.Forms.Button btnNuevo;
      private Infrastructure.WinFormsControls.PanelCaption panelCaption1;
      private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
      private Infrastructure.WinFormsControls.PanelCaption panelCaption2;
      private Telerik.WinControls.UI.RadGridView grdItems;
      private Infrastructure.WinFormsControls.FormTitle TitleView;
      private System.Windows.Forms.Label label6;
      private System.Windows.Forms.TextBox txtDOCV_NumeroNC;
      private System.Windows.Forms.Label label1;

      private System.Windows.Forms.TextBox txtNumeroFact;
      private System.Windows.Forms.BindingNavigator navItems;
      private System.Windows.Forms.ToolStripLabel toolStripLabel1;
      private System.Windows.Forms.ToolStripButton toolStripButton1;
      private System.Windows.Forms.ToolStripButton toolStripButton2;
      private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
      private System.Windows.Forms.ToolStripTextBox toolStripTextBox1;
      private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
      private System.Windows.Forms.ToolStripButton toolStripButton3;
      private System.Windows.Forms.ToolStripButton toolStripButton4;
      private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator2;
      private System.Windows.Forms.Label label8;
      private System.Windows.Forms.Label label2;
      private System.Windows.Forms.TextBox txtDOCV_NumeroFac;
      private System.Windows.Forms.Label label3;
      private Controls.EntidadDocIden txaENTC_Codigo;
      private Infrastructure.WinForms.Controls.ComboBox.ComboBox cmbSERI_Serie;
      private System.Windows.Forms.Label label5;
      private System.Windows.Forms.Label label4;
      private System.Windows.Forms.TextBox txtSERI_UnidadNegocio;
      private Infrastructure.WinForms.Controls.MaskTime dtpDOCV_FechaEmisionNCFin;
      private Infrastructure.WinForms.Controls.MaskTime dtpDOCV_FechaEmisionNCIni;
      

   }
}
