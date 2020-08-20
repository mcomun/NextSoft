namespace Delfin.Principal
{
   partial class PRO001LView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PRO001LView));
            this.cmsMenu = new System.Windows.Forms.ContextMenuStrip();
            this.editarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eliminarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmColumnas = new System.Windows.Forms.ToolStripMenuItem();
            this.pnBotones = new System.Windows.Forms.Panel();
            this.btnDeshacer = new System.Windows.Forms.Button();
            this.btnExportar = new System.Windows.Forms.Button();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.btnCopiar = new System.Windows.Forms.Button();
            this.btnNuevo = new System.Windows.Forms.Button();
            this.panelCaption1 = new Infrastructure.WinFormsControls.PanelCaption();
            this.TLPFiltros = new System.Windows.Forms.TableLayoutPanel();
            this.lbllineanaviera = new System.Windows.Forms.Label();
            this.AyudaEntidadLineaNaviera = new Delfin.Controls.Entidad();
            this.mdtFecDesde = new Infrastructure.WinFormsControls.MaskDateTime();
            this.lblCONT_FecIni = new System.Windows.Forms.Label();
            this.lblagmaritimo = new System.Windows.Forms.Label();
            this.lbldeptemporal = new System.Windows.Forms.Label();
            this.AyudaEntidadDepTemporal = new Delfin.Controls.Entidad();
            this.lbldepvacios = new System.Windows.Forms.Label();
            this.AyudaEntidadDepVacio = new Delfin.Controls.Entidad();
            this.lblagaduana = new System.Windows.Forms.Label();
            this.AyudaEntidadAgAduana = new Delfin.Controls.Entidad();
            this.lbltransporte = new System.Windows.Forms.Label();
            this.AyudaEntidadTransporte = new Delfin.Controls.Entidad();
            this.AyudaEntidadAgMaritimo = new Delfin.Controls.Entidad();
            this.panel1 = new System.Windows.Forms.Panel();
            this.mdtFecHasta = new Infrastructure.WinFormsControls.MaskDateTime();
            this.label4 = new System.Windows.Forms.Label();
            this.panelCaption2 = new Infrastructure.WinFormsControls.PanelCaption();
            this.grdItems = new Telerik.WinControls.UI.RadGridView();
            this.TitleView = new Infrastructure.WinFormsControls.FormTitle();
            this.navItems = new System.Windows.Forms.BindingNavigator();
            this.toolStripLabel4 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripButton13 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton14 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripTextBox4 = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton15 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton16 = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.cmsMenu.SuspendLayout();
            this.pnBotones.SuspendLayout();
            this.TLPFiltros.SuspendLayout();
            this.panel1.SuspendLayout();
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
            this.pnBotones.Controls.Add(this.btnCopiar);
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
            this.btnDeshacer.Location = new System.Drawing.Point(227, 0);
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
            this.btnExportar.Location = new System.Drawing.Point(169, 0);
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
            this.btnBuscar.Location = new System.Drawing.Point(114, 0);
            this.btnBuscar.Margin = new System.Windows.Forms.Padding(0);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(55, 50);
            this.btnBuscar.TabIndex = 2;
            this.btnBuscar.Text = "&Buscar";
            this.btnBuscar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnBuscar.UseVisualStyleBackColor = true;
            // 
            // btnCopiar
            // 
            this.btnCopiar.AutoSize = true;
            this.btnCopiar.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnCopiar.FlatAppearance.BorderColor = System.Drawing.Color.SteelBlue;
            this.btnCopiar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCopiar.ForeColor = System.Drawing.Color.Black;
            this.btnCopiar.Image = global::Delfin.Principal.Properties.Resources.copy;
            this.btnCopiar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnCopiar.Location = new System.Drawing.Point(57, 0);
            this.btnCopiar.Margin = new System.Windows.Forms.Padding(0);
            this.btnCopiar.Name = "btnCopiar";
            this.btnCopiar.Size = new System.Drawing.Size(57, 50);
            this.btnCopiar.TabIndex = 1;
            this.btnCopiar.Text = "&Copiar";
            this.btnCopiar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCopiar.UseVisualStyleBackColor = true;
            this.btnCopiar.Visible = false;
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
            // TLPFiltros
            // 
            this.TLPFiltros.AutoSize = true;
            this.TLPFiltros.ColumnCount = 7;
            this.TLPFiltros.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.TLPFiltros.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 113F));
            this.TLPFiltros.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 209F));
            this.TLPFiltros.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 16F));
            this.TLPFiltros.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 124F));
            this.TLPFiltros.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 337F));
            this.TLPFiltros.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 57F));
            this.TLPFiltros.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.TLPFiltros.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.TLPFiltros.Controls.Add(this.lbllineanaviera, 0, 0);
            this.TLPFiltros.Controls.Add(this.AyudaEntidadLineaNaviera, 1, 0);
            this.TLPFiltros.Controls.Add(this.mdtFecDesde, 1, 3);
            this.TLPFiltros.Controls.Add(this.lblCONT_FecIni, 0, 3);
            this.TLPFiltros.Controls.Add(this.lblagmaritimo, 4, 0);
            this.TLPFiltros.Controls.Add(this.lbldeptemporal, 0, 1);
            this.TLPFiltros.Controls.Add(this.AyudaEntidadDepTemporal, 1, 1);
            this.TLPFiltros.Controls.Add(this.lbldepvacios, 4, 1);
            this.TLPFiltros.Controls.Add(this.AyudaEntidadDepVacio, 5, 1);
            this.TLPFiltros.Controls.Add(this.lblagaduana, 0, 2);
            this.TLPFiltros.Controls.Add(this.AyudaEntidadAgAduana, 1, 2);
            this.TLPFiltros.Controls.Add(this.lbltransporte, 4, 2);
            this.TLPFiltros.Controls.Add(this.AyudaEntidadTransporte, 5, 2);
            this.TLPFiltros.Controls.Add(this.AyudaEntidadAgMaritimo, 5, 0);
            this.TLPFiltros.Controls.Add(this.panel1, 2, 3);
            this.TLPFiltros.Dock = System.Windows.Forms.DockStyle.Top;
            this.TLPFiltros.Location = new System.Drawing.Point(0, 102);
            this.TLPFiltros.Name = "TLPFiltros";
            this.TLPFiltros.RowCount = 4;
            this.TLPFiltros.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.TLPFiltros.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.TLPFiltros.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.TLPFiltros.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.TLPFiltros.Size = new System.Drawing.Size(968, 108);
            this.TLPFiltros.TabIndex = 2;
            // 
            // lbllineanaviera
            // 
            this.lbllineanaviera.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbllineanaviera.Location = new System.Drawing.Point(10, 7);
            this.lbllineanaviera.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
            this.lbllineanaviera.Name = "lbllineanaviera";
            this.lbllineanaviera.Size = new System.Drawing.Size(137, 17);
            this.lbllineanaviera.TabIndex = 0;
            this.lbllineanaviera.Text = "Linea Naviera:";
            // 
            // AyudaEntidadLineaNaviera
            // 
            this.AyudaEntidadLineaNaviera.ActivarAyudaAuto = false;
            this.TLPFiltros.SetColumnSpan(this.AyudaEntidadLineaNaviera, 2);
            this.AyudaEntidadLineaNaviera.ContainerService = null;
            this.AyudaEntidadLineaNaviera.EnabledAyudaButton = true;
            this.AyudaEntidadLineaNaviera.Location = new System.Drawing.Point(153, 3);
            this.AyudaEntidadLineaNaviera.LongitudAceptada = 0;
            this.AyudaEntidadLineaNaviera.MyInstanciaAyuda = Delfin.Controls.Entidad.InstanciaAyuda.Habilitado;
            this.AyudaEntidadLineaNaviera.Name = "AyudaEntidadLineaNaviera";
            this.AyudaEntidadLineaNaviera.RellenaCeros = false;
            this.AyudaEntidadLineaNaviera.Size = new System.Drawing.Size(316, 20);
            this.AyudaEntidadLineaNaviera.TabIndex = 1;
            this.AyudaEntidadLineaNaviera.Tipo = Delfin.Controls.Entidad.TipoTextBoxAyuda.AlfaNumerico;
            this.AyudaEntidadLineaNaviera.TipoEntidad = Delfin.Controls.TiposEntidad.TIPE_Transportista;
            this.AyudaEntidadLineaNaviera.UsarTipoEntidad = true;
            this.AyudaEntidadLineaNaviera.Value = null;
            // 
            // mdtFecDesde
            // 
            this.mdtFecDesde.Location = new System.Drawing.Point(153, 84);
            this.mdtFecDesde.MinimumSize = new System.Drawing.Size(100, 22);
            this.mdtFecDesde.Name = "mdtFecDesde";
            this.mdtFecDesde.NSActiveMouse = false;
            this.mdtFecDesde.NSActiveMsgFecha = false;
            this.mdtFecDesde.NSChangeDate = true;
            this.mdtFecDesde.NSDigitos = 4;
            this.mdtFecDesde.NSFecha = null;
            this.mdtFecDesde.NSSetDateNow = false;
            this.mdtFecDesde.Size = new System.Drawing.Size(106, 22);
            this.mdtFecDesde.TabIndex = 13;
            // 
            // lblCONT_FecIni
            // 
            this.lblCONT_FecIni.AutoSize = true;
            this.lblCONT_FecIni.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCONT_FecIni.Location = new System.Drawing.Point(10, 88);
            this.lblCONT_FecIni.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
            this.lblCONT_FecIni.Name = "lblCONT_FecIni";
            this.lblCONT_FecIni.Size = new System.Drawing.Size(133, 13);
            this.lblCONT_FecIni.TabIndex = 12;
            this.lblCONT_FecIni.Text = "Fecha Emisión Desde:";
            // 
            // lblagmaritimo
            // 
            this.lblagmaritimo.AutoSize = true;
            this.lblagmaritimo.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblagmaritimo.Location = new System.Drawing.Point(498, 7);
            this.lblagmaritimo.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
            this.lblagmaritimo.Name = "lblagmaritimo";
            this.lblagmaritimo.Size = new System.Drawing.Size(105, 13);
            this.lblagmaritimo.TabIndex = 2;
            this.lblagmaritimo.Text = "Agente Maritimo:";
            // 
            // lbldeptemporal
            // 
            this.lbldeptemporal.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbldeptemporal.Location = new System.Drawing.Point(10, 34);
            this.lbldeptemporal.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
            this.lbldeptemporal.Name = "lbldeptemporal";
            this.lbldeptemporal.Size = new System.Drawing.Size(137, 17);
            this.lbldeptemporal.TabIndex = 4;
            this.lbldeptemporal.Text = "Deposito Temporal:";
            // 
            // AyudaEntidadDepTemporal
            // 
            this.AyudaEntidadDepTemporal.ActivarAyudaAuto = false;
            this.TLPFiltros.SetColumnSpan(this.AyudaEntidadDepTemporal, 2);
            this.AyudaEntidadDepTemporal.ContainerService = null;
            this.AyudaEntidadDepTemporal.EnabledAyudaButton = true;
            this.AyudaEntidadDepTemporal.Location = new System.Drawing.Point(153, 30);
            this.AyudaEntidadDepTemporal.LongitudAceptada = 0;
            this.AyudaEntidadDepTemporal.MyInstanciaAyuda = Delfin.Controls.Entidad.InstanciaAyuda.Habilitado;
            this.AyudaEntidadDepTemporal.Name = "AyudaEntidadDepTemporal";
            this.AyudaEntidadDepTemporal.RellenaCeros = false;
            this.AyudaEntidadDepTemporal.Size = new System.Drawing.Size(316, 20);
            this.AyudaEntidadDepTemporal.TabIndex = 5;
            this.AyudaEntidadDepTemporal.Tipo = Delfin.Controls.Entidad.TipoTextBoxAyuda.AlfaNumerico;
            this.AyudaEntidadDepTemporal.TipoEntidad = Delfin.Controls.TiposEntidad.TIPE_Transportista;
            this.AyudaEntidadDepTemporal.UsarTipoEntidad = true;
            this.AyudaEntidadDepTemporal.Value = null;
            // 
            // lbldepvacios
            // 
            this.lbldepvacios.AutoSize = true;
            this.lbldepvacios.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbldepvacios.Location = new System.Drawing.Point(498, 34);
            this.lbldepvacios.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
            this.lbldepvacios.Name = "lbldepvacios";
            this.lbldepvacios.Size = new System.Drawing.Size(96, 13);
            this.lbldepvacios.TabIndex = 6;
            this.lbldepvacios.Text = "Deposito Vacio:";
            // 
            // AyudaEntidadDepVacio
            // 
            this.AyudaEntidadDepVacio.ActivarAyudaAuto = false;
            this.AyudaEntidadDepVacio.ContainerService = null;
            this.AyudaEntidadDepVacio.EnabledAyudaButton = true;
            this.AyudaEntidadDepVacio.Location = new System.Drawing.Point(615, 30);
            this.AyudaEntidadDepVacio.LongitudAceptada = 0;
            this.AyudaEntidadDepVacio.MyInstanciaAyuda = Delfin.Controls.Entidad.InstanciaAyuda.Habilitado;
            this.AyudaEntidadDepVacio.Name = "AyudaEntidadDepVacio";
            this.AyudaEntidadDepVacio.RellenaCeros = false;
            this.AyudaEntidadDepVacio.Size = new System.Drawing.Size(330, 20);
            this.AyudaEntidadDepVacio.TabIndex = 7;
            this.AyudaEntidadDepVacio.Tipo = Delfin.Controls.Entidad.TipoTextBoxAyuda.AlfaNumerico;
            this.AyudaEntidadDepVacio.TipoEntidad = Delfin.Controls.TiposEntidad.TIPE_Transportista;
            this.AyudaEntidadDepVacio.UsarTipoEntidad = true;
            this.AyudaEntidadDepVacio.Value = null;
            // 
            // lblagaduana
            // 
            this.lblagaduana.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblagaduana.Location = new System.Drawing.Point(10, 61);
            this.lblagaduana.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
            this.lblagaduana.Name = "lblagaduana";
            this.lblagaduana.Size = new System.Drawing.Size(137, 17);
            this.lblagaduana.TabIndex = 8;
            this.lblagaduana.Text = "Agente Aduana:";
            // 
            // AyudaEntidadAgAduana
            // 
            this.AyudaEntidadAgAduana.ActivarAyudaAuto = false;
            this.TLPFiltros.SetColumnSpan(this.AyudaEntidadAgAduana, 2);
            this.AyudaEntidadAgAduana.ContainerService = null;
            this.AyudaEntidadAgAduana.EnabledAyudaButton = true;
            this.AyudaEntidadAgAduana.Location = new System.Drawing.Point(153, 57);
            this.AyudaEntidadAgAduana.LongitudAceptada = 0;
            this.AyudaEntidadAgAduana.MyInstanciaAyuda = Delfin.Controls.Entidad.InstanciaAyuda.Habilitado;
            this.AyudaEntidadAgAduana.Name = "AyudaEntidadAgAduana";
            this.AyudaEntidadAgAduana.RellenaCeros = false;
            this.AyudaEntidadAgAduana.Size = new System.Drawing.Size(316, 20);
            this.AyudaEntidadAgAduana.TabIndex = 9;
            this.AyudaEntidadAgAduana.Tipo = Delfin.Controls.Entidad.TipoTextBoxAyuda.AlfaNumerico;
            this.AyudaEntidadAgAduana.TipoEntidad = Delfin.Controls.TiposEntidad.TIPE_Transportista;
            this.AyudaEntidadAgAduana.UsarTipoEntidad = true;
            this.AyudaEntidadAgAduana.Value = null;
            // 
            // lbltransporte
            // 
            this.lbltransporte.AutoSize = true;
            this.lbltransporte.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbltransporte.Location = new System.Drawing.Point(498, 61);
            this.lbltransporte.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
            this.lbltransporte.Name = "lbltransporte";
            this.lbltransporte.Size = new System.Drawing.Size(73, 13);
            this.lbltransporte.TabIndex = 10;
            this.lbltransporte.Text = "Transporte:";
            // 
            // AyudaEntidadTransporte
            // 
            this.AyudaEntidadTransporte.ActivarAyudaAuto = false;
            this.AyudaEntidadTransporte.ContainerService = null;
            this.AyudaEntidadTransporte.EnabledAyudaButton = true;
            this.AyudaEntidadTransporte.Location = new System.Drawing.Point(615, 57);
            this.AyudaEntidadTransporte.LongitudAceptada = 0;
            this.AyudaEntidadTransporte.MyInstanciaAyuda = Delfin.Controls.Entidad.InstanciaAyuda.Habilitado;
            this.AyudaEntidadTransporte.Name = "AyudaEntidadTransporte";
            this.AyudaEntidadTransporte.RellenaCeros = false;
            this.AyudaEntidadTransporte.Size = new System.Drawing.Size(330, 20);
            this.AyudaEntidadTransporte.TabIndex = 11;
            this.AyudaEntidadTransporte.Tipo = Delfin.Controls.Entidad.TipoTextBoxAyuda.AlfaNumerico;
            this.AyudaEntidadTransporte.TipoEntidad = Delfin.Controls.TiposEntidad.TIPE_Transportista;
            this.AyudaEntidadTransporte.UsarTipoEntidad = true;
            this.AyudaEntidadTransporte.Value = null;
            // 
            // AyudaEntidadAgMaritimo
            // 
            this.AyudaEntidadAgMaritimo.ActivarAyudaAuto = false;
            this.TLPFiltros.SetColumnSpan(this.AyudaEntidadAgMaritimo, 2);
            this.AyudaEntidadAgMaritimo.ContainerService = null;
            this.AyudaEntidadAgMaritimo.EnabledAyudaButton = true;
            this.AyudaEntidadAgMaritimo.Location = new System.Drawing.Point(615, 3);
            this.AyudaEntidadAgMaritimo.LongitudAceptada = 0;
            this.AyudaEntidadAgMaritimo.MyInstanciaAyuda = Delfin.Controls.Entidad.InstanciaAyuda.Habilitado;
            this.AyudaEntidadAgMaritimo.Name = "AyudaEntidadAgMaritimo";
            this.AyudaEntidadAgMaritimo.RellenaCeros = false;
            this.AyudaEntidadAgMaritimo.Size = new System.Drawing.Size(330, 20);
            this.AyudaEntidadAgMaritimo.TabIndex = 3;
            this.AyudaEntidadAgMaritimo.Tipo = Delfin.Controls.Entidad.TipoTextBoxAyuda.AlfaNumerico;
            this.AyudaEntidadAgMaritimo.TipoEntidad = Delfin.Controls.TiposEntidad.TIPE_Transportista;
            this.AyudaEntidadAgMaritimo.UsarTipoEntidad = true;
            this.AyudaEntidadAgMaritimo.Value = null;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.mdtFecHasta);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Location = new System.Drawing.Point(266, 84);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 21);
            this.panel1.TabIndex = 14;
            // 
            // mdtFecHasta
            // 
            this.mdtFecHasta.Location = new System.Drawing.Point(94, -1);
            this.mdtFecHasta.MinimumSize = new System.Drawing.Size(100, 22);
            this.mdtFecHasta.Name = "mdtFecHasta";
            this.mdtFecHasta.NSActiveMouse = false;
            this.mdtFecHasta.NSActiveMsgFecha = false;
            this.mdtFecHasta.NSChangeDate = true;
            this.mdtFecHasta.NSDigitos = 4;
            this.mdtFecHasta.NSFecha = null;
            this.mdtFecHasta.NSSetDateNow = false;
            this.mdtFecHasta.Size = new System.Drawing.Size(104, 22);
            this.mdtFecHasta.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(6, 4);
            this.label4.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Hasta:";
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
            // TitleView
            // 
            this.TitleView.AllowActive = false;
            this.TitleView.AntiAlias = false;
            this.TitleView.Caption = "Mantenimiento de Tarifario";
            this.TitleView.Dock = System.Windows.Forms.DockStyle.Top;
            this.TitleView.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TitleView.FormIcon = ((System.Drawing.Image)(resources.GetObject("TitleView.FormIcon")));
            this.TitleView.InactiveGradientHighColor = System.Drawing.Color.SteelBlue;
            this.TitleView.InactiveGradientLowColor = System.Drawing.Color.MidnightBlue;
            this.TitleView.Location = new System.Drawing.Point(0, 0);
            this.TitleView.Name = "TitleView";
            this.TitleView.Size = new System.Drawing.Size(968, 26);
            this.TitleView.TabIndex = 0;
            // 
            // navItems
            // 
            this.navItems.AddNewItem = null;
            this.navItems.BackColor = System.Drawing.Color.SteelBlue;
            this.navItems.CountItem = this.toolStripLabel4;
            this.navItems.DeleteItem = null;
            this.navItems.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.navItems.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton13,
            this.toolStripButton14,
            this.toolStripSeparator7,
            this.toolStripLabel4,
            this.toolStripTextBox4,
            this.toolStripSeparator8,
            this.toolStripButton15,
            this.toolStripButton16,
            this.bindingNavigatorSeparator2});
            this.navItems.Location = new System.Drawing.Point(0, 532);
            this.navItems.MoveFirstItem = this.toolStripButton13;
            this.navItems.MoveLastItem = this.toolStripButton16;
            this.navItems.MoveNextItem = this.toolStripButton15;
            this.navItems.MovePreviousItem = this.toolStripButton14;
            this.navItems.Name = "navItems";
            this.navItems.PositionItem = this.toolStripTextBox4;
            this.navItems.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.navItems.Size = new System.Drawing.Size(968, 25);
            this.navItems.TabIndex = 54;
            this.navItems.Text = "bindingNavigator1";
            // 
            // toolStripLabel4
            // 
            this.toolStripLabel4.Name = "toolStripLabel4";
            this.toolStripLabel4.Size = new System.Drawing.Size(37, 22);
            this.toolStripLabel4.Text = "de {0}";
            this.toolStripLabel4.ToolTipText = "Número total de elementos";
            // 
            // toolStripButton13
            // 
            this.toolStripButton13.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton13.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton13.Image")));
            this.toolStripButton13.Name = "toolStripButton13";
            this.toolStripButton13.RightToLeftAutoMirrorImage = true;
            this.toolStripButton13.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton13.Text = "Mover primero";
            // 
            // toolStripButton14
            // 
            this.toolStripButton14.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton14.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton14.Image")));
            this.toolStripButton14.Name = "toolStripButton14";
            this.toolStripButton14.RightToLeftAutoMirrorImage = true;
            this.toolStripButton14.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton14.Text = "Mover anterior";
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripTextBox4
            // 
            this.toolStripTextBox4.AccessibleName = "Posición";
            this.toolStripTextBox4.AutoSize = false;
            this.toolStripTextBox4.Name = "toolStripTextBox4";
            this.toolStripTextBox4.Size = new System.Drawing.Size(50, 23);
            this.toolStripTextBox4.Text = "0";
            this.toolStripTextBox4.ToolTipText = "Posición actual";
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            this.toolStripSeparator8.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButton15
            // 
            this.toolStripButton15.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton15.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton15.Image")));
            this.toolStripButton15.Name = "toolStripButton15";
            this.toolStripButton15.RightToLeftAutoMirrorImage = true;
            this.toolStripButton15.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton15.Text = "Mover siguiente";
            // 
            // toolStripButton16
            // 
            this.toolStripButton16.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton16.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton16.Image")));
            this.toolStripButton16.Name = "toolStripButton16";
            this.toolStripButton16.RightToLeftAutoMirrorImage = true;
            this.toolStripButton16.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton16.Text = "Mover último";
            // 
            // bindingNavigatorSeparator2
            // 
            this.bindingNavigatorSeparator2.Name = "bindingNavigatorSeparator2";
            this.bindingNavigatorSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // PRO001LView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.Controls.Add(this.grdItems);
            this.Controls.Add(this.navItems);
            this.Controls.Add(this.panelCaption2);
            this.Controls.Add(this.TLPFiltros);
            this.Controls.Add(this.panelCaption1);
            this.Controls.Add(this.pnBotones);
            this.Controls.Add(this.TitleView);
            this.Name = "PRO001LView";
            this.Size = new System.Drawing.Size(968, 557);
            this.cmsMenu.ResumeLayout(false);
            this.pnBotones.ResumeLayout(false);
            this.pnBotones.PerformLayout();
            this.TLPFiltros.ResumeLayout(false);
            this.TLPFiltros.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
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
      private System.Windows.Forms.TableLayoutPanel TLPFiltros;
      private System.Windows.Forms.Label lbllineanaviera;
      private Infrastructure.WinFormsControls.PanelCaption panelCaption2;
      private Telerik.WinControls.UI.RadGridView grdItems;
      private Infrastructure.WinFormsControls.FormTitle TitleView;
      private Controls.Entidad AyudaEntidadLineaNaviera;
      private System.Windows.Forms.Label lblCONT_FecIni;
      private Infrastructure.WinFormsControls.MaskDateTime mdtFecDesde;
      private System.Windows.Forms.Button btnCopiar;
      private System.Windows.Forms.Label lblagmaritimo;
      private Controls.Entidad AyudaEntidadAgMaritimo;
      private System.Windows.Forms.Label lbldeptemporal;
      private Controls.Entidad AyudaEntidadDepTemporal;
      private System.Windows.Forms.Label lbldepvacios;
      private Controls.Entidad AyudaEntidadDepVacio;
      private System.Windows.Forms.Label lblagaduana;
      private Controls.Entidad AyudaEntidadAgAduana;
      private System.Windows.Forms.Label lbltransporte;
      private Controls.Entidad AyudaEntidadTransporte;
      private System.Windows.Forms.Panel panel1;
      private Infrastructure.WinFormsControls.MaskDateTime mdtFecHasta;
      private System.Windows.Forms.Label label4;
      private System.Windows.Forms.BindingNavigator navItems;
      private System.Windows.Forms.ToolStripLabel toolStripLabel4;
      private System.Windows.Forms.ToolStripButton toolStripButton13;
      private System.Windows.Forms.ToolStripButton toolStripButton14;
      private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
      private System.Windows.Forms.ToolStripTextBox toolStripTextBox4;
      private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
      private System.Windows.Forms.ToolStripButton toolStripButton15;
      private System.Windows.Forms.ToolStripButton toolStripButton16;
      private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator2;

   }
}
