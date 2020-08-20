namespace Delfin.Principal
{
    partial class MAN011LView
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
            this.ENTC_CodTransportista = new Delfin.Controls.Entidad(this.components);
            this.navItems = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.btnDeshacer = new System.Windows.Forms.Button();
            this.btnExportar = new System.Windows.Forms.Button();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.btnNuevo = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.mdtNVIA_FecCreacion = new Infrastructure.WinForms.Controls.MaskDateTime();
            this.NVIA_NroViaje = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lblCONS_CodRGM = new System.Windows.Forms.Label();
            this.cmbCONS_CodRGM = new Delfin.Controls.Tipos.ComboBoxConstantes();
            this.lblCONS_CodVia = new System.Windows.Forms.Label();
            this.cmbCONS_CodVia = new Delfin.Controls.Tipos.ComboBoxConstantes();
            this.lblMAN = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbNVIA_Estado = new Delfin.Controls.Tipos.ComboBoxConstantes();
            this.NAVE_Codigo = new System.Windows.Forms.ComboBox();
            this.panelCaption2 = new Infrastructure.WinForms.Controls.PanelCaption();
            this.panelCaption1 = new Infrastructure.WinForms.Controls.PanelCaption();
            this.pnBotones = new System.Windows.Forms.Panel();
            this.tsmColumnas = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.editarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eliminarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TitleView = new Infrastructure.WinForms.Controls.FormTitle();
            this.grdItems = new Telerik.WinControls.UI.RadGridView();
            ((System.ComponentModel.ISupportInitialize)(this.navItems)).BeginInit();
            this.navItems.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.pnBotones.SuspendLayout();
            this.cmsMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdItems)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdItems.MasterTemplate)).BeginInit();
            this.SuspendLayout();
            // 
            // ENTC_CodTransportista
            // 
            this.ENTC_CodTransportista.ActivarAyudaAuto = false;
            this.tableLayoutPanel1.SetColumnSpan(this.ENTC_CodTransportista, 4);
            this.ENTC_CodTransportista.ContainerService = null;
            this.ENTC_CodTransportista.EnabledAyudaButton = true;
            this.ENTC_CodTransportista.Location = new System.Drawing.Point(153, 3);
            this.ENTC_CodTransportista.LongitudAceptada = 0;
            this.ENTC_CodTransportista.MyInstanciaAyuda = Delfin.Controls.Entidad.InstanciaAyuda.Habilitado;
            this.ENTC_CodTransportista.Name = "ENTC_CodTransportista";
            this.ENTC_CodTransportista.RellenaCeros = false;
            this.ENTC_CodTransportista.Size = new System.Drawing.Size(559, 20);
            this.ENTC_CodTransportista.TabIndex = 1;
            this.ENTC_CodTransportista.Tipo = Delfin.Controls.Entidad.TipoTextBoxAyuda.AlfaNumerico;
            this.ENTC_CodTransportista.TipoEntidad = Delfin.Controls.TiposEntidad.TIPE_Transportista;
            this.ENTC_CodTransportista.UsarTipoEntidad = true;
            this.ENTC_CodTransportista.Value = null;
            // 
            // navItems
            // 
            this.navItems.AddNewItem = null;
            this.navItems.BackColor = System.Drawing.Color.SteelBlue;
            this.navItems.CountItem = this.bindingNavigatorCountItem;
            this.navItems.DeleteItem = null;
            this.navItems.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.navItems.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.navItems.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveLastItem,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorMoveFirstItem});
            this.navItems.Location = new System.Drawing.Point(0, 508);
            this.navItems.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.navItems.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.navItems.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.navItems.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.navItems.Name = "navItems";
            this.navItems.Padding = new System.Windows.Forms.Padding(3);
            this.navItems.PositionItem = this.bindingNavigatorPositionItem;
            this.navItems.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.navItems.Size = new System.Drawing.Size(911, 29);
            this.navItems.TabIndex = 6;
            this.navItems.Text = "bindingNavigator1";
            // 
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(37, 20);
            this.bindingNavigatorCountItem.Text = "de {0}";
            this.bindingNavigatorCountItem.ToolTipText = "Número total de elementos";
            // 
            // bindingNavigatorMoveLastItem
            // 
            this.bindingNavigatorMoveLastItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.bindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveLastItem.Image = global::Delfin.Principal.Properties.Resources.navigate_right;
            this.bindingNavigatorMoveLastItem.Name = "bindingNavigatorMoveLastItem";
            this.bindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveLastItem.Size = new System.Drawing.Size(23, 20);
            this.bindingNavigatorMoveLastItem.Text = "Ultimo";
            // 
            // bindingNavigatorMoveNextItem
            // 
            this.bindingNavigatorMoveNextItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.bindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveNextItem.Image = global::Delfin.Principal.Properties.Resources.navigate_right;
            this.bindingNavigatorMoveNextItem.Name = "bindingNavigatorMoveNextItem";
            this.bindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveNextItem.Size = new System.Drawing.Size(23, 20);
            this.bindingNavigatorMoveNextItem.Text = "Siguiente";
            // 
            // bindingNavigatorSeparator
            // 
            this.bindingNavigatorSeparator.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.bindingNavigatorSeparator.Name = "bindingNavigatorSeparator";
            this.bindingNavigatorSeparator.Size = new System.Drawing.Size(6, 23);
            // 
            // bindingNavigatorPositionItem
            // 
            this.bindingNavigatorPositionItem.AccessibleName = "Position";
            this.bindingNavigatorPositionItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.bindingNavigatorPositionItem.AutoSize = false;
            this.bindingNavigatorPositionItem.Margin = new System.Windows.Forms.Padding(3, 0, 1, 0);
            this.bindingNavigatorPositionItem.Name = "bindingNavigatorPositionItem";
            this.bindingNavigatorPositionItem.Size = new System.Drawing.Size(50, 23);
            this.bindingNavigatorPositionItem.Text = "0";
            this.bindingNavigatorPositionItem.ToolTipText = "Posición Actual";
            // 
            // bindingNavigatorSeparator1
            // 
            this.bindingNavigatorSeparator1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.bindingNavigatorSeparator1.Name = "bindingNavigatorSeparator1";
            this.bindingNavigatorSeparator1.Size = new System.Drawing.Size(6, 23);
            // 
            // bindingNavigatorMovePreviousItem
            // 
            this.bindingNavigatorMovePreviousItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.bindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMovePreviousItem.Image = global::Delfin.Principal.Properties.Resources.navigate_left;
            this.bindingNavigatorMovePreviousItem.Name = "bindingNavigatorMovePreviousItem";
            this.bindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMovePreviousItem.Size = new System.Drawing.Size(23, 20);
            this.bindingNavigatorMovePreviousItem.Text = "Anterior";
            // 
            // bindingNavigatorMoveFirstItem
            // 
            this.bindingNavigatorMoveFirstItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.bindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveFirstItem.Image = global::Delfin.Principal.Properties.Resources.navigate_left;
            this.bindingNavigatorMoveFirstItem.Name = "bindingNavigatorMoveFirstItem";
            this.bindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveFirstItem.Size = new System.Drawing.Size(23, 20);
            this.bindingNavigatorMoveFirstItem.Text = "Primero";
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
            this.btnDeshacer.TabIndex = 3;
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
            this.btnExportar.TabIndex = 2;
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
            this.btnBuscar.TabIndex = 1;
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
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.mdtNVIA_FecCreacion, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.NVIA_NroViaje, 4, 3);
            this.tableLayoutPanel1.Controls.Add(this.label2, 3, 3);
            this.tableLayoutPanel1.Controls.Add(this.lblCONS_CodRGM, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.cmbCONS_CodRGM, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.lblCONS_CodVia, 3, 2);
            this.tableLayoutPanel1.Controls.Add(this.cmbCONS_CodVia, 4, 2);
            this.tableLayoutPanel1.Controls.Add(this.lblMAN, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.ENTC_CodTransportista, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label3, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.cmbNVIA_Estado, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.NAVE_Codigo, 4, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 102);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(911, 108);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(10, 88);
            this.label1.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 17);
            this.label1.TabIndex = 10;
            this.label1.Text = "Fec. Creación>=:";
            // 
            // mdtNVIA_FecCreacion
            // 
            this.mdtNVIA_FecCreacion.Location = new System.Drawing.Point(153, 84);
            this.mdtNVIA_FecCreacion.MinimumSize = new System.Drawing.Size(100, 22);
            this.mdtNVIA_FecCreacion.Name = "mdtNVIA_FecCreacion";
            this.mdtNVIA_FecCreacion.NSActiveMouse = false;
            this.mdtNVIA_FecCreacion.NSActiveMsgFecha = false;
            this.mdtNVIA_FecCreacion.NSChangeDate = true;
            this.mdtNVIA_FecCreacion.NSDigitos = 4;
            this.mdtNVIA_FecCreacion.NSFecha = null;
            this.mdtNVIA_FecCreacion.NSSetDateNow = false;
            this.mdtNVIA_FecCreacion.Size = new System.Drawing.Size(100, 22);
            this.mdtNVIA_FecCreacion.TabIndex = 11;
            // 
            // NVIA_NroViaje
            // 
            this.NVIA_NroViaje.Location = new System.Drawing.Point(518, 84);
            this.NVIA_NroViaje.MaxLength = 50;
            this.NVIA_NroViaje.Name = "NVIA_NroViaje";
            this.NVIA_NroViaje.Size = new System.Drawing.Size(194, 20);
            this.NVIA_NroViaje.TabIndex = 13;
            this.NVIA_NroViaje.Tag = "NVIA_NroViajeMSGERROR";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(375, 88);
            this.label2.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Nro: Viaje:";
            // 
            // lblCONS_CodRGM
            // 
            this.lblCONS_CodRGM.AutoSize = true;
            this.lblCONS_CodRGM.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCONS_CodRGM.Location = new System.Drawing.Point(10, 61);
            this.lblCONS_CodRGM.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
            this.lblCONS_CodRGM.Name = "lblCONS_CodRGM";
            this.lblCONS_CodRGM.Size = new System.Drawing.Size(62, 13);
            this.lblCONS_CodRGM.TabIndex = 6;
            this.lblCONS_CodRGM.Text = "Régimen:";
            // 
            // cmbCONS_CodRGM
            // 
            this.cmbCONS_CodRGM.ConstantesSelectedItem = null;
            this.cmbCONS_CodRGM.ConstantesSelectedValue = null;
            this.cmbCONS_CodRGM.ConstantesTitulo = null;
            this.cmbCONS_CodRGM.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCONS_CodRGM.FormattingEnabled = true;
            this.cmbCONS_CodRGM.Location = new System.Drawing.Point(153, 57);
            this.cmbCONS_CodRGM.Name = "cmbCONS_CodRGM";
            this.cmbCONS_CodRGM.Session = null;
            this.cmbCONS_CodRGM.Size = new System.Drawing.Size(194, 21);
            this.cmbCONS_CodRGM.TabIndex = 7;
            // 
            // lblCONS_CodVia
            // 
            this.lblCONS_CodVia.AutoSize = true;
            this.lblCONS_CodVia.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCONS_CodVia.Location = new System.Drawing.Point(375, 61);
            this.lblCONS_CodVia.Margin = new System.Windows.Forms.Padding(10, 7, 2, 0);
            this.lblCONS_CodVia.Name = "lblCONS_CodVia";
            this.lblCONS_CodVia.Size = new System.Drawing.Size(30, 13);
            this.lblCONS_CodVia.TabIndex = 8;
            this.lblCONS_CodVia.Text = "Vía:";
            // 
            // cmbCONS_CodVia
            // 
            this.cmbCONS_CodVia.ConstantesSelectedItem = null;
            this.cmbCONS_CodVia.ConstantesSelectedValue = null;
            this.cmbCONS_CodVia.ConstantesTitulo = null;
            this.cmbCONS_CodVia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCONS_CodVia.FormattingEnabled = true;
            this.cmbCONS_CodVia.Location = new System.Drawing.Point(517, 57);
            this.cmbCONS_CodVia.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.cmbCONS_CodVia.Name = "cmbCONS_CodVia";
            this.cmbCONS_CodVia.Session = null;
            this.cmbCONS_CodVia.Size = new System.Drawing.Size(194, 21);
            this.cmbCONS_CodVia.TabIndex = 9;
            this.cmbCONS_CodVia.Tag = "CONS_CodViaMSGERROR";
            // 
            // lblMAN
            // 
            this.lblMAN.AutoSize = true;
            this.lblMAN.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMAN.Location = new System.Drawing.Point(10, 7);
            this.lblMAN.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
            this.lblMAN.Name = "lblMAN";
            this.lblMAN.Size = new System.Drawing.Size(86, 13);
            this.lblMAN.TabIndex = 0;
            this.lblMAN.Text = "Transportista:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(375, 34);
            this.label3.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Nave:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(10, 34);
            this.label4.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Estado:";
            // 
            // cmbNVIA_Estado
            // 
            this.cmbNVIA_Estado.ConstantesSelectedItem = null;
            this.cmbNVIA_Estado.ConstantesSelectedValue = null;
            this.cmbNVIA_Estado.ConstantesTitulo = null;
            this.cmbNVIA_Estado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbNVIA_Estado.FormattingEnabled = true;
            this.cmbNVIA_Estado.Location = new System.Drawing.Point(153, 30);
            this.cmbNVIA_Estado.Name = "cmbNVIA_Estado";
            this.cmbNVIA_Estado.Session = null;
            this.cmbNVIA_Estado.Size = new System.Drawing.Size(194, 21);
            this.cmbNVIA_Estado.TabIndex = 3;
            // 
            // NAVE_Codigo
            // 
            this.NAVE_Codigo.FormattingEnabled = true;
            this.NAVE_Codigo.Location = new System.Drawing.Point(518, 30);
            this.NAVE_Codigo.Name = "NAVE_Codigo";
            this.NAVE_Codigo.Size = new System.Drawing.Size(193, 21);
            this.NAVE_Codigo.TabIndex = 5;
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
            this.panelCaption2.Size = new System.Drawing.Size(911, 26);
            this.panelCaption2.TabIndex = 4;
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
            this.panelCaption1.Size = new System.Drawing.Size(911, 26);
            this.panelCaption1.TabIndex = 2;
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
            this.pnBotones.Size = new System.Drawing.Size(911, 50);
            this.pnBotones.TabIndex = 1;
            // 
            // tsmColumnas
            // 
            this.tsmColumnas.Name = "tsmColumnas";
            this.tsmColumnas.Size = new System.Drawing.Size(128, 22);
            this.tsmColumnas.Text = "Columnas";
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
            // TitleView
            // 
            this.TitleView.AllowActive = false;
            this.TitleView.AntiAlias = false;
            this.TitleView.Caption = "MANTENIMIENTO DE NAVE VIAJE";
            this.TitleView.Dock = System.Windows.Forms.DockStyle.Top;
            this.TitleView.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TitleView.FormIcon = global::Delfin.Principal.Properties.Resources.add;
            this.TitleView.InactiveGradientHighColor = System.Drawing.Color.SteelBlue;
            this.TitleView.InactiveGradientLowColor = System.Drawing.Color.MidnightBlue;
            this.TitleView.Location = new System.Drawing.Point(0, 0);
            this.TitleView.Name = "TitleView";
            this.TitleView.Size = new System.Drawing.Size(911, 26);
            this.TitleView.TabIndex = 0;
            // 
            // grdItems
            // 
            this.grdItems.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.grdItems.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdItems.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grdItems.Location = new System.Drawing.Point(0, 236);
            this.grdItems.Name = "grdItems";
            this.grdItems.Size = new System.Drawing.Size(911, 272);
            this.grdItems.TabIndex = 5;
            this.grdItems.TabStop = false;
            // 
            // MAN011LView
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
            this.Name = "MAN011LView";
            this.Size = new System.Drawing.Size(911, 537);
            ((System.ComponentModel.ISupportInitialize)(this.navItems)).EndInit();
            this.navItems.ResumeLayout(false);
            this.navItems.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.pnBotones.ResumeLayout(false);
            this.pnBotones.PerformLayout();
            this.cmsMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdItems.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdItems)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Controls.Entidad ENTC_CodTransportista;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lblMAN;
        private System.Windows.Forms.BindingNavigator navItems;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.Button btnDeshacer;
        private System.Windows.Forms.Button btnExportar;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Button btnNuevo;
        private Infrastructure.WinForms.Controls.PanelCaption panelCaption2;
        private Infrastructure.WinForms.Controls.PanelCaption panelCaption1;
        private System.Windows.Forms.Panel pnBotones;
        private System.Windows.Forms.ToolStripMenuItem tsmColumnas;
        private System.Windows.Forms.ContextMenuStrip cmsMenu;
        private System.Windows.Forms.ToolStripMenuItem editarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem eliminarToolStripMenuItem;
        private Infrastructure.WinForms.Controls.FormTitle TitleView;
        private Telerik.WinControls.UI.RadGridView grdItems;
        private System.Windows.Forms.Label label1;
        private Infrastructure.WinForms.Controls.MaskDateTime mdtNVIA_FecCreacion;
        private System.Windows.Forms.Label lblCONS_CodRGM;
        private Controls.Tipos.ComboBoxConstantes cmbCONS_CodRGM;
        private System.Windows.Forms.Label lblCONS_CodVia;
        private Controls.Tipos.ComboBoxConstantes cmbCONS_CodVia;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox NVIA_NroViaje;
        private System.Windows.Forms.Label label4;
        private Controls.Tipos.ComboBoxConstantes cmbNVIA_Estado;
        private System.Windows.Forms.ComboBox NAVE_Codigo;
    }
}
