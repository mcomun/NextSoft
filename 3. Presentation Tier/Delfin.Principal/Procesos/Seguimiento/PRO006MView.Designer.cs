namespace Delfin.Principal
{
   partial class PRO006MView
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

      #region Windows Form Designer generated code

      /// <summary>
      /// Required method for Designer support - do not modify
      /// the contents of this method with the code editor.
      /// </summary>
      private void InitializeComponent()
      {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PRO006MView));
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnSalir = new System.Windows.Forms.Button();
            this.btnImportar = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.PCEncabezado = new Infrastructure.WinFormsControls.PanelCaption();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.miniToolStrip = new System.Windows.Forms.BindingNavigator(this.components);
            this.tlpDatosTarifas = new System.Windows.Forms.TableLayoutPanel();
            this.txtHBL = new System.Windows.Forms.TextBox();
            this.lblCONT_Numero = new System.Windows.Forms.Label();
            this.lblCONT_Descrip = new System.Windows.Forms.Label();
            this.ENTC_CodigoEntidad = new Delfin.Controls.Entidad(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.ENTC_CodigoDepTemporal = new Delfin.Controls.Entidad(this.components);
            this.PCDatos = new Infrastructure.WinFormsControls.PanelCaption();
            this.grdItems = new Telerik.WinControls.UI.RadGridView();
            this.btnAgregarDetalle = new System.Windows.Forms.Button();
            this.navItems = new System.Windows.Forms.BindingNavigator(this.components);
            this.toolStripLabel4 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripButton13 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton14 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripTextBox4 = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton15 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton16 = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.miniToolStrip)).BeginInit();
            this.tlpDatosTarifas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdItems)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdItems.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.navItems)).BeginInit();
            this.navItems.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.LightSteelBlue;
            this.panel3.Controls.Add(this.btnSalir);
            this.panel3.Controls.Add(this.btnImportar);
            this.panel3.Controls.Add(this.btnGuardar);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(988, 50);
            this.panel3.TabIndex = 1;
            // 
            // btnSalir
            // 
            this.btnSalir.AutoSize = true;
            this.btnSalir.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnSalir.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnSalir.FlatAppearance.BorderColor = System.Drawing.Color.LightSteelBlue;
            this.btnSalir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSalir.ForeColor = System.Drawing.Color.Black;
            this.btnSalir.Image = ((System.Drawing.Image)(resources.GetObject("btnSalir.Image")));
            this.btnSalir.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnSalir.Location = new System.Drawing.Point(214, 0);
            this.btnSalir.Margin = new System.Windows.Forms.Padding(0);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(55, 50);
            this.btnSalir.TabIndex = 2;
            this.btnSalir.Text = "&Salir";
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir.UseVisualStyleBackColor = true;
            // 
            // btnImportar
            // 
            this.btnImportar.AutoSize = true;
            this.btnImportar.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnImportar.FlatAppearance.BorderColor = System.Drawing.Color.LightSteelBlue;
            this.btnImportar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnImportar.ForeColor = System.Drawing.Color.Black;
            this.btnImportar.Image = global::Delfin.Principal.Properties.Resources.Sign_181;
            this.btnImportar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnImportar.Location = new System.Drawing.Point(57, 0);
            this.btnImportar.Margin = new System.Windows.Forms.Padding(0);
            this.btnImportar.Name = "btnImportar";
            this.btnImportar.Size = new System.Drawing.Size(157, 50);
            this.btnImportar.TabIndex = 1;
            this.btnImportar.Text = "&Importar de Direccionamiento";
            this.btnImportar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnImportar.UseVisualStyleBackColor = true;
            this.btnImportar.Click += new System.EventHandler(this.btnImportar_Click_1);
            // 
            // btnGuardar
            // 
            this.btnGuardar.AutoSize = true;
            this.btnGuardar.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnGuardar.FlatAppearance.BorderColor = System.Drawing.Color.LightSteelBlue;
            this.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardar.ForeColor = System.Drawing.Color.Black;
            this.btnGuardar.Image = ((System.Drawing.Image)(resources.GetObject("btnGuardar.Image")));
            this.btnGuardar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnGuardar.Location = new System.Drawing.Point(0, 0);
            this.btnGuardar.Margin = new System.Windows.Forms.Padding(0);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(57, 50);
            this.btnGuardar.TabIndex = 0;
            this.btnGuardar.Text = "&Guardar";
            this.btnGuardar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnGuardar.UseVisualStyleBackColor = true;
            // 
            // PCEncabezado
            // 
            this.PCEncabezado.AllowActive = false;
            this.PCEncabezado.AntiAlias = false;
            this.PCEncabezado.Caption = "Datos Generales";
            this.PCEncabezado.Dock = System.Windows.Forms.DockStyle.Top;
            this.PCEncabezado.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
            this.PCEncabezado.InactiveGradientHighColor = System.Drawing.Color.SteelBlue;
            this.PCEncabezado.InactiveGradientLowColor = System.Drawing.Color.MidnightBlue;
            this.PCEncabezado.Location = new System.Drawing.Point(0, 50);
            this.PCEncabezado.Name = "PCEncabezado";
            this.PCEncabezado.Size = new System.Drawing.Size(988, 26);
            this.PCEncabezado.TabIndex = 0;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // miniToolStrip
            // 
            this.miniToolStrip.AddNewItem = null;
            this.miniToolStrip.AutoSize = false;
            this.miniToolStrip.BackColor = System.Drawing.Color.SteelBlue;
            this.miniToolStrip.CanOverflow = false;
            this.miniToolStrip.CountItem = null;
            this.miniToolStrip.DeleteItem = null;
            this.miniToolStrip.Dock = System.Windows.Forms.DockStyle.None;
            this.miniToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.miniToolStrip.Location = new System.Drawing.Point(0, 0);
            this.miniToolStrip.MoveFirstItem = null;
            this.miniToolStrip.MoveLastItem = null;
            this.miniToolStrip.MoveNextItem = null;
            this.miniToolStrip.MovePreviousItem = null;
            this.miniToolStrip.Name = "miniToolStrip";
            this.miniToolStrip.Padding = new System.Windows.Forms.Padding(3);
            this.miniToolStrip.PositionItem = null;
            this.miniToolStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.miniToolStrip.Size = new System.Drawing.Size(875, 29);
            this.miniToolStrip.TabIndex = 3;
            // 
            // tlpDatosTarifas
            // 
            this.tlpDatosTarifas.AutoSize = true;
            this.tlpDatosTarifas.ColumnCount = 7;
            this.tlpDatosTarifas.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 112F));
            this.tlpDatosTarifas.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 236F));
            this.tlpDatosTarifas.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 17F));
            this.tlpDatosTarifas.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tlpDatosTarifas.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 18F));
            this.tlpDatosTarifas.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 197F));
            this.tlpDatosTarifas.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpDatosTarifas.Controls.Add(this.txtHBL, 1, 2);
            this.tlpDatosTarifas.Controls.Add(this.lblCONT_Numero, 0, 2);
            this.tlpDatosTarifas.Controls.Add(this.lblCONT_Descrip, 0, 0);
            this.tlpDatosTarifas.Controls.Add(this.ENTC_CodigoEntidad, 1, 0);
            this.tlpDatosTarifas.Controls.Add(this.label1, 0, 1);
            this.tlpDatosTarifas.Controls.Add(this.ENTC_CodigoDepTemporal, 1, 1);
            this.tlpDatosTarifas.Dock = System.Windows.Forms.DockStyle.Top;
            this.tlpDatosTarifas.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
            this.tlpDatosTarifas.Location = new System.Drawing.Point(0, 76);
            this.tlpDatosTarifas.Name = "tlpDatosTarifas";
            this.tlpDatosTarifas.RowCount = 3;
            this.tlpDatosTarifas.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tlpDatosTarifas.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tlpDatosTarifas.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tlpDatosTarifas.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpDatosTarifas.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpDatosTarifas.Size = new System.Drawing.Size(988, 81);
            this.tlpDatosTarifas.TabIndex = 1;
            // 
            // txtHBL
            // 
            this.txtHBL.Location = new System.Drawing.Point(115, 57);
            this.txtHBL.MaxLength = 11;
            this.txtHBL.Name = "txtHBL";
            this.txtHBL.Size = new System.Drawing.Size(230, 20);
            this.txtHBL.TabIndex = 5;
            this.txtHBL.Tag = "CSEG_HBLMSGERROR";
            // 
            // lblCONT_Numero
            // 
            this.lblCONT_Numero.AutoSize = true;
            this.lblCONT_Numero.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCONT_Numero.Location = new System.Drawing.Point(10, 61);
            this.lblCONT_Numero.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
            this.lblCONT_Numero.Name = "lblCONT_Numero";
            this.lblCONT_Numero.Size = new System.Drawing.Size(34, 13);
            this.lblCONT_Numero.TabIndex = 4;
            this.lblCONT_Numero.Text = "HBL:";
            // 
            // lblCONT_Descrip
            // 
            this.lblCONT_Descrip.AutoSize = true;
            this.lblCONT_Descrip.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCONT_Descrip.Location = new System.Drawing.Point(10, 7);
            this.lblCONT_Descrip.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
            this.lblCONT_Descrip.Name = "lblCONT_Descrip";
            this.lblCONT_Descrip.Size = new System.Drawing.Size(52, 13);
            this.lblCONT_Descrip.TabIndex = 0;
            this.lblCONT_Descrip.Text = "Cliente:";
            // 
            // ENTC_CodigoEntidad
            // 
            this.ENTC_CodigoEntidad.ActivarAyudaAuto = false;
            this.tlpDatosTarifas.SetColumnSpan(this.ENTC_CodigoEntidad, 3);
            this.ENTC_CodigoEntidad.EnabledAyudaButton = true;
            this.ENTC_CodigoEntidad.Location = new System.Drawing.Point(115, 3);
            this.ENTC_CodigoEntidad.LongitudAceptada = 0;
            this.ENTC_CodigoEntidad.MyInstanciaAyuda = Delfin.Controls.Entidad.InstanciaAyuda.Habilitado;
            this.ENTC_CodigoEntidad.Name = "ENTC_CodigoEntidad";
            this.ENTC_CodigoEntidad.RellenaCeros = false;
            this.ENTC_CodigoEntidad.Size = new System.Drawing.Size(397, 20);
            this.ENTC_CodigoEntidad.TabIndex = 1;
            this.ENTC_CodigoEntidad.Tipo = Delfin.Controls.Entidad.TipoTextBoxAyuda.AlfaNumerico;
            this.ENTC_CodigoEntidad.TipoEntidad = Delfin.Controls.TiposEntidad.TIPE_Cliente;
            this.ENTC_CodigoEntidad.Value = null;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(10, 34);
            this.label1.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Dep. Temporal:";
            // 
            // ENTC_CodigoDepTemporal
            // 
            this.ENTC_CodigoDepTemporal.ActivarAyudaAuto = false;
            this.tlpDatosTarifas.SetColumnSpan(this.ENTC_CodigoDepTemporal, 3);
            this.ENTC_CodigoDepTemporal.EnabledAyudaButton = true;
            this.ENTC_CodigoDepTemporal.Location = new System.Drawing.Point(115, 30);
            this.ENTC_CodigoDepTemporal.LongitudAceptada = 0;
            this.ENTC_CodigoDepTemporal.MyInstanciaAyuda = Delfin.Controls.Entidad.InstanciaAyuda.Habilitado;
            this.ENTC_CodigoDepTemporal.Name = "ENTC_CodigoDepTemporal";
            this.ENTC_CodigoDepTemporal.RellenaCeros = false;
            this.ENTC_CodigoDepTemporal.Size = new System.Drawing.Size(397, 20);
            this.ENTC_CodigoDepTemporal.TabIndex = 3;
            this.ENTC_CodigoDepTemporal.Tipo = Delfin.Controls.Entidad.TipoTextBoxAyuda.AlfaNumerico;
            this.ENTC_CodigoDepTemporal.TipoEntidad = Delfin.Controls.TiposEntidad.TIPE_Cliente;
            this.ENTC_CodigoDepTemporal.Value = null;
            // 
            // PCDatos
            // 
            this.PCDatos.AllowActive = false;
            this.PCDatos.AntiAlias = false;
            this.PCDatos.Caption = "                            Items";
            this.PCDatos.Dock = System.Windows.Forms.DockStyle.Top;
            this.PCDatos.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
            this.PCDatos.InactiveGradientHighColor = System.Drawing.Color.SteelBlue;
            this.PCDatos.InactiveGradientLowColor = System.Drawing.Color.MidnightBlue;
            this.PCDatos.Location = new System.Drawing.Point(0, 157);
            this.PCDatos.Name = "PCDatos";
            this.PCDatos.Size = new System.Drawing.Size(988, 26);
            this.PCDatos.TabIndex = 3;
            // 
            // grdItems
            // 
            this.grdItems.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.grdItems.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdItems.Location = new System.Drawing.Point(0, 183);
            this.grdItems.Name = "grdItems";
            // 
            // 
            // 
            this.grdItems.RootElement.ControlBounds = new System.Drawing.Rectangle(0, 183, 240, 150);
            this.grdItems.Size = new System.Drawing.Size(988, 267);
            this.grdItems.TabIndex = 3;
            this.grdItems.TabStop = false;
            // 
            // btnAgregarDetalle
            // 
            this.btnAgregarDetalle.Image = global::Delfin.Principal.Properties.Resources.add16x16;
            this.btnAgregarDetalle.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAgregarDetalle.Location = new System.Drawing.Point(2, 158);
            this.btnAgregarDetalle.Name = "btnAgregarDetalle";
            this.btnAgregarDetalle.Size = new System.Drawing.Size(106, 23);
            this.btnAgregarDetalle.TabIndex = 2;
            this.btnAgregarDetalle.Text = "Agregar Detalle Seguimiento";
            this.btnAgregarDetalle.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAgregarDetalle.UseVisualStyleBackColor = true;
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
            this.navItems.Location = new System.Drawing.Point(0, 450);
            this.navItems.MoveFirstItem = this.toolStripButton13;
            this.navItems.MoveLastItem = this.toolStripButton16;
            this.navItems.MoveNextItem = this.toolStripButton15;
            this.navItems.MovePreviousItem = this.toolStripButton14;
            this.navItems.Name = "navItems";
            this.navItems.PositionItem = this.toolStripTextBox4;
            this.navItems.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.navItems.Size = new System.Drawing.Size(988, 25);
            this.navItems.TabIndex = 53;
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
            // PRO006MView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(988, 475);
            this.Controls.Add(this.grdItems);
            this.Controls.Add(this.navItems);
            this.Controls.Add(this.btnAgregarDetalle);
            this.Controls.Add(this.PCDatos);
            this.Controls.Add(this.tlpDatosTarifas);
            this.Controls.Add(this.PCEncabezado);
            this.Controls.Add(this.panel3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PRO006MView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Seguimiento";
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.miniToolStrip)).EndInit();
            this.tlpDatosTarifas.ResumeLayout(false);
            this.tlpDatosTarifas.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdItems.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdItems)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.navItems)).EndInit();
            this.navItems.ResumeLayout(false);
            this.navItems.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.Panel panel3;
      private System.Windows.Forms.Button btnGuardar;
      private Infrastructure.WinFormsControls.PanelCaption PCEncabezado;
      private System.Windows.Forms.Button btnImportar;
      private System.Windows.Forms.ErrorProvider errorProvider1;
      private Infrastructure.WinFormsControls.PanelCaption PCDatos;
      private System.Windows.Forms.TableLayoutPanel tlpDatosTarifas;
      private System.Windows.Forms.TextBox txtHBL;
      private System.Windows.Forms.Label lblCONT_Numero;
      private System.Windows.Forms.Label lblCONT_Descrip;
      private Controls.Entidad ENTC_CodigoEntidad;
      private System.Windows.Forms.Label label1;
      private Controls.Entidad ENTC_CodigoDepTemporal;
      private System.Windows.Forms.BindingNavigator miniToolStrip;
      //private Telerik.WinControls.UI.MasterGridViewTemplate grdItems;
      //private Telerik.WinControls.UI.MasterGridViewTemplate grdItemsServicios;
      private Telerik.WinControls.UI.RadGridView grdItems;
      private System.Windows.Forms.Button btnSalir;
      private System.Windows.Forms.Button btnAgregarDetalle;
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