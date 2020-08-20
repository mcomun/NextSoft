namespace Delfin.Principal
{
    partial class PRO008LView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PRO008LView));
            this.panelCaption2 = new Infrastructure.WinFormsControls.PanelCaption();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.mdtFecHastaRegistro = new Infrastructure.WinFormsControls.MaskDateTime();
            this.mdtFecHastaEmision = new Infrastructure.WinFormsControls.MaskDateTime();
            this.label21 = new System.Windows.Forms.Label();
            this.lblFecHastaRegistro = new System.Windows.Forms.Label();
            this.lblFecHastaEmision = new System.Windows.Forms.Label();
            this.lblfecharegistro = new System.Windows.Forms.Label();
            this.cmbTIPE_Codigo = new Delfin.Controls.ComboBoxTipoEntidad();
            this.mdtFecDesdeRegistro = new Infrastructure.WinFormsControls.MaskDateTime();
            this.lblfechaemision = new System.Windows.Forms.Label();
            this.mdtFecDesdeEmision = new Infrastructure.WinFormsControls.MaskDateTime();
            this.panel1 = new System.Windows.Forms.Panel();
            this.RbFechaRegistro = new System.Windows.Forms.RadioButton();
            this.RbFechaEmision = new System.Windows.Forms.RadioButton();
            this.Proveedor = new Delfin.Controls.Entidad();
            this.label6 = new System.Windows.Forms.Label();
            this.grdItems = new Telerik.WinControls.UI.RadGridView();
            this.pnBotones = new System.Windows.Forms.Panel();
            this.btnDeshacer = new System.Windows.Forms.Button();
            this.btnExportar = new System.Windows.Forms.Button();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.btnNuevo = new System.Windows.Forms.Button();
            this.cmsMenu = new System.Windows.Forms.ContextMenuStrip();
            this.editarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eliminarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmColumnas = new System.Windows.Forms.ToolStripMenuItem();
            this.TitleView = new Infrastructure.WinFormsControls.FormTitle();
            this.panelCaption1 = new Infrastructure.WinFormsControls.PanelCaption();
            this.navItems = new System.Windows.Forms.BindingNavigator();
            this.bindingNavigatorCountItem1 = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorMoveLastItem1 = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveNextItem1 = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem1 = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMovePreviousItem1 = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveFirstItem1 = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdItems)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdItems.MasterTemplate)).BeginInit();
            this.pnBotones.SuspendLayout();
            this.cmsMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.navItems)).BeginInit();
            this.navItems.SuspendLayout();
            this.SuspendLayout();
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
            this.panelCaption2.Location = new System.Drawing.Point(0, 183);
            this.panelCaption2.Name = "panelCaption2";
            this.panelCaption2.Size = new System.Drawing.Size(1101, 26);
            this.panelCaption2.TabIndex = 46;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.ColumnCount = 10;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 360F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.mdtFecHastaRegistro, 4, 2);
            this.tableLayoutPanel1.Controls.Add(this.mdtFecHastaEmision, 4, 1);
            this.tableLayoutPanel1.Controls.Add(this.label21, 6, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblFecHastaRegistro, 3, 2);
            this.tableLayoutPanel1.Controls.Add(this.lblFecHastaEmision, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblfecharegistro, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.cmbTIPE_Codigo, 7, 1);
            this.tableLayoutPanel1.Controls.Add(this.mdtFecDesdeRegistro, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.lblfechaemision, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.mdtFecDesdeEmision, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.Proveedor, 7, 2);
            this.tableLayoutPanel1.Controls.Add(this.label6, 6, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 102);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1101, 81);
            this.tableLayoutPanel1.TabIndex = 45;
            // 
            // mdtFecHastaRegistro
            // 
            this.mdtFecHastaRegistro.Location = new System.Drawing.Point(438, 57);
            this.mdtFecHastaRegistro.MinimumSize = new System.Drawing.Size(100, 22);
            this.mdtFecHastaRegistro.Name = "mdtFecHastaRegistro";
            this.mdtFecHastaRegistro.NSActiveMouse = false;
            this.mdtFecHastaRegistro.NSActiveMsgFecha = false;
            this.mdtFecHastaRegistro.NSChangeDate = true;
            this.mdtFecHastaRegistro.NSDigitos = 4;
            this.mdtFecHastaRegistro.NSFecha = null;
            this.mdtFecHastaRegistro.NSSetDateNow = false;
            this.mdtFecHastaRegistro.Size = new System.Drawing.Size(100, 22);
            this.mdtFecHastaRegistro.TabIndex = 1;
            // 
            // mdtFecHastaEmision
            // 
            this.mdtFecHastaEmision.Location = new System.Drawing.Point(438, 30);
            this.mdtFecHastaEmision.MinimumSize = new System.Drawing.Size(100, 22);
            this.mdtFecHastaEmision.Name = "mdtFecHastaEmision";
            this.mdtFecHastaEmision.NSActiveMouse = false;
            this.mdtFecHastaEmision.NSActiveMsgFecha = false;
            this.mdtFecHastaEmision.NSChangeDate = true;
            this.mdtFecHastaEmision.NSDigitos = 4;
            this.mdtFecHastaEmision.NSFecha = null;
            this.mdtFecHastaEmision.NSSetDateNow = false;
            this.mdtFecHastaEmision.Size = new System.Drawing.Size(100, 22);
            this.mdtFecHastaEmision.TabIndex = 1;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.Location = new System.Drawing.Point(580, 34);
            this.label21.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(104, 13);
            this.label21.TabIndex = 11;
            this.label21.Text = "Tipo de Entidad :";
            // 
            // lblFecHastaRegistro
            // 
            this.lblFecHastaRegistro.AutoSize = true;
            this.lblFecHastaRegistro.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFecHastaRegistro.Location = new System.Drawing.Point(295, 61);
            this.lblFecHastaRegistro.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
            this.lblFecHastaRegistro.Name = "lblFecHastaRegistro";
            this.lblFecHastaRegistro.Size = new System.Drawing.Size(116, 13);
            this.lblFecHastaRegistro.TabIndex = 0;
            this.lblFecHastaRegistro.Text = "Fecha Fin Registro:";
            // 
            // lblFecHastaEmision
            // 
            this.lblFecHastaEmision.AutoSize = true;
            this.lblFecHastaEmision.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFecHastaEmision.Location = new System.Drawing.Point(295, 34);
            this.lblFecHastaEmision.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
            this.lblFecHastaEmision.Name = "lblFecHastaEmision";
            this.lblFecHastaEmision.Size = new System.Drawing.Size(113, 13);
            this.lblFecHastaEmision.TabIndex = 0;
            this.lblFecHastaEmision.Text = "Fecha Fin Emisión:";
            // 
            // lblfecharegistro
            // 
            this.lblfecharegistro.AutoSize = true;
            this.lblfecharegistro.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblfecharegistro.Location = new System.Drawing.Point(10, 61);
            this.lblfecharegistro.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
            this.lblfecharegistro.Name = "lblfecharegistro";
            this.lblfecharegistro.Size = new System.Drawing.Size(131, 13);
            this.lblfecharegistro.TabIndex = 12;
            this.lblfecharegistro.Text = "Fecha Inicio Registro:";
            // 
            // cmbTIPE_Codigo
            // 
            this.cmbTIPE_Codigo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTIPE_Codigo.FormattingEnabled = true;
            this.cmbTIPE_Codigo.Location = new System.Drawing.Point(723, 30);
            this.cmbTIPE_Codigo.Name = "cmbTIPE_Codigo";
            this.cmbTIPE_Codigo.Size = new System.Drawing.Size(354, 21);
            this.cmbTIPE_Codigo.TabIndex = 10;
            this.cmbTIPE_Codigo.TipoEntidadSelectedItem = null;
            this.cmbTIPE_Codigo.TipoEntidadSelectedValue = null;
            this.cmbTIPE_Codigo.TiposTitulo = null;
            // 
            // mdtFecDesdeRegistro
            // 
            this.mdtFecDesdeRegistro.Location = new System.Drawing.Point(153, 57);
            this.mdtFecDesdeRegistro.MinimumSize = new System.Drawing.Size(100, 22);
            this.mdtFecDesdeRegistro.Name = "mdtFecDesdeRegistro";
            this.mdtFecDesdeRegistro.NSActiveMouse = false;
            this.mdtFecDesdeRegistro.NSActiveMsgFecha = false;
            this.mdtFecDesdeRegistro.NSChangeDate = true;
            this.mdtFecDesdeRegistro.NSDigitos = 4;
            this.mdtFecDesdeRegistro.NSFecha = null;
            this.mdtFecDesdeRegistro.NSSetDateNow = false;
            this.mdtFecDesdeRegistro.Size = new System.Drawing.Size(100, 22);
            this.mdtFecDesdeRegistro.TabIndex = 13;
            // 
            // lblfechaemision
            // 
            this.lblfechaemision.AutoSize = true;
            this.lblfechaemision.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblfechaemision.Location = new System.Drawing.Point(10, 34);
            this.lblfechaemision.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
            this.lblfechaemision.Name = "lblfechaemision";
            this.lblfechaemision.Size = new System.Drawing.Size(128, 13);
            this.lblfechaemision.TabIndex = 12;
            this.lblfechaemision.Text = "Fecha Inicio Emisión:";
            // 
            // mdtFecDesdeEmision
            // 
            this.mdtFecDesdeEmision.Location = new System.Drawing.Point(153, 30);
            this.mdtFecDesdeEmision.MinimumSize = new System.Drawing.Size(100, 22);
            this.mdtFecDesdeEmision.Name = "mdtFecDesdeEmision";
            this.mdtFecDesdeEmision.NSActiveMouse = false;
            this.mdtFecDesdeEmision.NSActiveMsgFecha = false;
            this.mdtFecDesdeEmision.NSChangeDate = true;
            this.mdtFecDesdeEmision.NSDigitos = 4;
            this.mdtFecDesdeEmision.NSFecha = null;
            this.mdtFecDesdeEmision.NSSetDateNow = false;
            this.mdtFecDesdeEmision.Size = new System.Drawing.Size(100, 22);
            this.mdtFecDesdeEmision.TabIndex = 13;
            // 
            // panel1
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.panel1, 2);
            this.panel1.Controls.Add(this.RbFechaRegistro);
            this.panel1.Controls.Add(this.RbFechaEmision);
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(264, 21);
            this.panel1.TabIndex = 17;
            // 
            // RbFechaRegistro
            // 
            this.RbFechaRegistro.AutoSize = true;
            this.RbFechaRegistro.Location = new System.Drawing.Point(154, 0);
            this.RbFechaRegistro.Name = "RbFechaRegistro";
            this.RbFechaRegistro.Size = new System.Drawing.Size(97, 17);
            this.RbFechaRegistro.TabIndex = 0;
            this.RbFechaRegistro.Text = "Fecha Registro";
            this.RbFechaRegistro.UseVisualStyleBackColor = true;
            // 
            // RbFechaEmision
            // 
            this.RbFechaEmision.AutoSize = true;
            this.RbFechaEmision.Checked = true;
            this.RbFechaEmision.Location = new System.Drawing.Point(10, 1);
            this.RbFechaEmision.Name = "RbFechaEmision";
            this.RbFechaEmision.Size = new System.Drawing.Size(94, 17);
            this.RbFechaEmision.TabIndex = 0;
            this.RbFechaEmision.TabStop = true;
            this.RbFechaEmision.Text = "Fecha Emisión";
            this.RbFechaEmision.UseVisualStyleBackColor = true;
            // 
            // Proveedor
            // 
            this.Proveedor.ActivarAyudaAuto = false;
            this.Proveedor.ContainerService = null;
            this.Proveedor.EnabledAyudaButton = true;
            this.Proveedor.Location = new System.Drawing.Point(723, 57);
            this.Proveedor.LongitudAceptada = 0;
            this.Proveedor.MyInstanciaAyuda = Delfin.Controls.Entidad.InstanciaAyuda.Habilitado;
            this.Proveedor.Name = "Proveedor";
            this.Proveedor.RellenaCeros = false;
            this.Proveedor.Size = new System.Drawing.Size(354, 20);
            this.Proveedor.TabIndex = 15;
            this.Proveedor.Tipo = Delfin.Controls.Entidad.TipoTextBoxAyuda.AlfaNumerico;
            this.Proveedor.TipoEntidad = Delfin.Controls.TiposEntidad.TIPE_Proveedor;
            this.Proveedor.UsarTipoEntidad = true;
            this.Proveedor.Value = null;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(580, 61);
            this.label6.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(75, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Proveedor :";
            // 
            // grdItems
            // 
            this.grdItems.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.grdItems.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdItems.Location = new System.Drawing.Point(0, 209);
            this.grdItems.Name = "grdItems";
            // 
            // 
            // 
            this.grdItems.RootElement.ControlBounds = new System.Drawing.Rectangle(0, 209, 240, 150);
            this.grdItems.Size = new System.Drawing.Size(1101, 254);
            this.grdItems.TabIndex = 47;
            this.grdItems.TabStop = false;
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
            this.pnBotones.Size = new System.Drawing.Size(1101, 50);
            this.pnBotones.TabIndex = 49;
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
            // TitleView
            // 
            this.TitleView.AllowActive = false;
            this.TitleView.AntiAlias = false;
            this.TitleView.Caption = "DOCUMENTOS DE PROVEEDOR";
            this.TitleView.Dock = System.Windows.Forms.DockStyle.Top;
            this.TitleView.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TitleView.FormIcon = ((System.Drawing.Image)(resources.GetObject("TitleView.FormIcon")));
            this.TitleView.InactiveGradientHighColor = System.Drawing.Color.SteelBlue;
            this.TitleView.InactiveGradientLowColor = System.Drawing.Color.MidnightBlue;
            this.TitleView.Location = new System.Drawing.Point(0, 0);
            this.TitleView.Name = "TitleView";
            this.TitleView.Size = new System.Drawing.Size(1101, 26);
            this.TitleView.TabIndex = 43;
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
            this.panelCaption1.Size = new System.Drawing.Size(1101, 26);
            this.panelCaption1.TabIndex = 50;
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
            this.navItems.Location = new System.Drawing.Point(0, 463);
            this.navItems.MoveFirstItem = this.bindingNavigatorMoveFirstItem1;
            this.navItems.MoveLastItem = this.bindingNavigatorMoveLastItem1;
            this.navItems.MoveNextItem = this.bindingNavigatorMoveNextItem1;
            this.navItems.MovePreviousItem = this.bindingNavigatorMovePreviousItem1;
            this.navItems.Name = "navItems";
            this.navItems.PositionItem = this.bindingNavigatorPositionItem1;
            this.navItems.Size = new System.Drawing.Size(1101, 25);
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
            // PRO008LView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.grdItems);
            this.Controls.Add(this.navItems);
            this.Controls.Add(this.panelCaption2);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.panelCaption1);
            this.Controls.Add(this.pnBotones);
            this.Controls.Add(this.TitleView);
            this.Name = "PRO008LView";
            this.Size = new System.Drawing.Size(1101, 488);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdItems.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdItems)).EndInit();
            this.pnBotones.ResumeLayout(false);
            this.pnBotones.PerformLayout();
            this.cmsMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.navItems)).EndInit();
            this.navItems.ResumeLayout(false);
            this.navItems.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Infrastructure.WinFormsControls.PanelCaption panelCaption2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private Infrastructure.WinFormsControls.MaskDateTime mdtFecDesdeEmision;
        private System.Windows.Forms.Label lblfechaemision;
        private Infrastructure.WinFormsControls.MaskDateTime mdtFecHastaEmision;
        private System.Windows.Forms.Label lblFecHastaEmision;
        private System.Windows.Forms.Label label6;
        private Telerik.WinControls.UI.RadGridView grdItems;
        private System.Windows.Forms.Panel pnBotones;
        private System.Windows.Forms.Button btnDeshacer;
        private System.Windows.Forms.Button btnExportar;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Button btnNuevo;
        private Infrastructure.WinFormsControls.FormTitle TitleView;
        private System.Windows.Forms.ContextMenuStrip cmsMenu;
        private System.Windows.Forms.ToolStripMenuItem editarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem eliminarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsmColumnas;
        private Controls.Entidad Proveedor;
        private Infrastructure.WinFormsControls.MaskDateTime mdtFecHastaRegistro;
        private System.Windows.Forms.Label lblFecHastaRegistro;
        private System.Windows.Forms.Label lblfecharegistro;
        private Infrastructure.WinFormsControls.PanelCaption panelCaption1;
        private Infrastructure.WinFormsControls.MaskDateTime mdtFecDesdeRegistro;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton RbFechaRegistro;
        private System.Windows.Forms.RadioButton RbFechaEmision;
        private Controls.ComboBoxTipoEntidad cmbTIPE_Codigo;
        private System.Windows.Forms.Label label21;
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
    }
}
