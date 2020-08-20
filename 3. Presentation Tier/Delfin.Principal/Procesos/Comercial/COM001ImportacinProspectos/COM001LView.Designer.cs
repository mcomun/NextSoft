namespace Delfin.Principal
{
   partial class COM001LView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(COM001LView));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnDeshacer = new System.Windows.Forms.Button();
            this.btnEjecutar = new System.Windows.Forms.Button();
            this.capCriterioImportacion = new Infrastructure.WinForms.Controls.PanelCaption();
            this.tableCriterioImportacion = new System.Windows.Forms.TableLayoutPanel();
            this.lblArchivo = new System.Windows.Forms.Label();
            this.txoArchivo = new Infrastructure.WinForms.Controls.TextBoxOpenFile();
            this.lblTEUS = new System.Windows.Forms.Label();
            this.txnTEUS = new Infrastructure.WinForms.Controls.TextBoxNumerico();
            this.lblRegimen = new System.Windows.Forms.Label();
            this.cmbRegimen = new System.Windows.Forms.ComboBox();
            this.capAsignacionProspectos = new Infrastructure.WinForms.Controls.PanelCaption();
            this.tableAsignacionProspectos = new System.Windows.Forms.TableLayoutPanel();
            this.btnAsignar = new System.Windows.Forms.Button();
            this.lblEjecutivo = new System.Windows.Forms.Label();
            this.txeEjecutivo = new Delfin.Controls.Entidad(this.components);
            this.navItems = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.grdItems = new Telerik.WinControls.UI.RadGridView();
            this.cmsMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmMarcarTodos = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmMarcarSeleccionados = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmDesmarcarTodos = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmDesmarcarSeleccionados = new System.Windows.Forms.ToolStripMenuItem();
            this.TitleView = new Infrastructure.WinForms.Controls.FormTitle();
            this.pgrImportacion = new System.Windows.Forms.ProgressBar();
            this.panel1.SuspendLayout();
            this.tableCriterioImportacion.SuspendLayout();
            this.tableAsignacionProspectos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.navItems)).BeginInit();
            this.navItems.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdItems)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdItems.MasterTemplate)).BeginInit();
            this.cmsMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.panel1.Controls.Add(this.btnDeshacer);
            this.panel1.Controls.Add(this.btnEjecutar);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.panel1.Location = new System.Drawing.Point(0, 26);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(950, 50);
            this.panel1.TabIndex = 40;
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
            // btnEjecutar
            // 
            this.btnEjecutar.AutoSize = true;
            this.btnEjecutar.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnEjecutar.FlatAppearance.BorderColor = System.Drawing.Color.SteelBlue;
            this.btnEjecutar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEjecutar.ForeColor = System.Drawing.Color.Black;
            this.btnEjecutar.Image = global::Delfin.Principal.Properties.Resources.index_up;
            this.btnEjecutar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnEjecutar.Location = new System.Drawing.Point(0, 0);
            this.btnEjecutar.Margin = new System.Windows.Forms.Padding(0);
            this.btnEjecutar.Name = "btnEjecutar";
            this.btnEjecutar.Size = new System.Drawing.Size(58, 50);
            this.btnEjecutar.TabIndex = 2;
            this.btnEjecutar.Text = "&Ejecutar";
            this.btnEjecutar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnEjecutar.UseVisualStyleBackColor = true;
            // 
            // capCriterioImportacion
            // 
            this.capCriterioImportacion.AllowActive = false;
            this.capCriterioImportacion.AntiAlias = false;
            this.capCriterioImportacion.Caption = "Criterio de Importación";
            this.capCriterioImportacion.Dock = System.Windows.Forms.DockStyle.Top;
            this.capCriterioImportacion.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
            this.capCriterioImportacion.InactiveGradientHighColor = System.Drawing.Color.SteelBlue;
            this.capCriterioImportacion.InactiveGradientLowColor = System.Drawing.Color.MidnightBlue;
            this.capCriterioImportacion.Location = new System.Drawing.Point(0, 76);
            this.capCriterioImportacion.Name = "capCriterioImportacion";
            this.capCriterioImportacion.Size = new System.Drawing.Size(950, 26);
            this.capCriterioImportacion.TabIndex = 43;
            // 
            // tableCriterioImportacion
            // 
            this.tableCriterioImportacion.AutoSize = true;
            this.tableCriterioImportacion.ColumnCount = 7;
            this.tableCriterioImportacion.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tableCriterioImportacion.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.tableCriterioImportacion.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.tableCriterioImportacion.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tableCriterioImportacion.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.tableCriterioImportacion.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.tableCriterioImportacion.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableCriterioImportacion.Controls.Add(this.lblArchivo, 0, 0);
            this.tableCriterioImportacion.Controls.Add(this.txoArchivo, 1, 0);
            this.tableCriterioImportacion.Controls.Add(this.lblTEUS, 0, 1);
            this.tableCriterioImportacion.Controls.Add(this.txnTEUS, 1, 1);
            this.tableCriterioImportacion.Controls.Add(this.lblRegimen, 3, 1);
            this.tableCriterioImportacion.Controls.Add(this.cmbRegimen, 4, 1);
            this.tableCriterioImportacion.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableCriterioImportacion.Location = new System.Drawing.Point(0, 102);
            this.tableCriterioImportacion.Name = "tableCriterioImportacion";
            this.tableCriterioImportacion.RowCount = 2;
            this.tableCriterioImportacion.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableCriterioImportacion.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableCriterioImportacion.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableCriterioImportacion.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableCriterioImportacion.Size = new System.Drawing.Size(950, 54);
            this.tableCriterioImportacion.TabIndex = 44;
            // 
            // lblArchivo
            // 
            this.lblArchivo.AutoSize = true;
            this.lblArchivo.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblArchivo.Location = new System.Drawing.Point(10, 7);
            this.lblArchivo.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
            this.lblArchivo.Name = "lblArchivo";
            this.lblArchivo.Size = new System.Drawing.Size(50, 13);
            this.lblArchivo.TabIndex = 78;
            this.lblArchivo.Text = "Archivo";
            // 
            // txoArchivo
            // 
            this.txoArchivo.Archivo = null;
            this.tableCriterioImportacion.SetColumnSpan(this.txoArchivo, 4);
            this.txoArchivo.DefaultFile = "*";
            this.txoArchivo.EnableButton = true;
            this.txoArchivo.FileData = null;
            this.txoArchivo.FileDefined = false;
            this.txoArchivo.FileName = null;
            this.txoArchivo.Filter = "Todos los Archivos (*.*)|*.*";
            this.txoArchivo.Instance = Infrastructure.WinForms.Controls.TextBoxOpenFile.InstanceEntity.Unchanged;
            this.txoArchivo.Location = new System.Drawing.Point(153, 3);
            this.txoArchivo.LongitudAceptada = 0;
            this.txoArchivo.Name = "txoArchivo";
            this.txoArchivo.NSFileTamañoMax = 0D;
            this.txoArchivo.NSValidateFileTamaño = false;
            this.txoArchivo.Size = new System.Drawing.Size(559, 20);
            this.txoArchivo.TabIndex = 79;
            // 
            // lblTEUS
            // 
            this.lblTEUS.AutoSize = true;
            this.lblTEUS.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTEUS.Location = new System.Drawing.Point(10, 34);
            this.lblTEUS.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
            this.lblTEUS.Name = "lblTEUS";
            this.lblTEUS.Size = new System.Drawing.Size(65, 13);
            this.lblTEUS.TabIndex = 84;
            this.lblTEUS.Text = "TEUS(>=)";
            // 
            // txnTEUS
            // 
            this.txnTEUS.BaseTipo = Infrastructure.WinForms.Controls.EstandaresFormato.General;
            this.txnTEUS.Decimales = 0;
            this.txnTEUS.Enteros = 9;
            this.txnTEUS.Formato = "###,###,##0.";
            this.txnTEUS.Location = new System.Drawing.Point(153, 30);
            this.txnTEUS.MaxLength = 10;
            this.txnTEUS.Name = "txnTEUS";
            this.txnTEUS.Negativo = true;
            this.txnTEUS.SinFormato = true;
            this.txnTEUS.Size = new System.Drawing.Size(194, 20);
            this.txnTEUS.TabIndex = 85;
            this.txnTEUS.Text = "0";
            this.txnTEUS.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txnTEUS.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // lblRegimen
            // 
            this.lblRegimen.AutoSize = true;
            this.lblRegimen.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRegimen.Location = new System.Drawing.Point(375, 34);
            this.lblRegimen.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
            this.lblRegimen.Name = "lblRegimen";
            this.lblRegimen.Size = new System.Drawing.Size(57, 13);
            this.lblRegimen.TabIndex = 86;
            this.lblRegimen.Text = "Régimen";
            // 
            // cmbRegimen
            // 
            this.cmbRegimen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRegimen.FormattingEnabled = true;
            this.cmbRegimen.Location = new System.Drawing.Point(518, 30);
            this.cmbRegimen.Name = "cmbRegimen";
            this.cmbRegimen.Size = new System.Drawing.Size(194, 21);
            this.cmbRegimen.TabIndex = 87;
            // 
            // capAsignacionProspectos
            // 
            this.capAsignacionProspectos.AllowActive = false;
            this.capAsignacionProspectos.AntiAlias = false;
            this.capAsignacionProspectos.Caption = "Asignación Prospectos";
            this.capAsignacionProspectos.Dock = System.Windows.Forms.DockStyle.Top;
            this.capAsignacionProspectos.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
            this.capAsignacionProspectos.InactiveGradientHighColor = System.Drawing.Color.SteelBlue;
            this.capAsignacionProspectos.InactiveGradientLowColor = System.Drawing.Color.MidnightBlue;
            this.capAsignacionProspectos.Location = new System.Drawing.Point(0, 179);
            this.capAsignacionProspectos.Name = "capAsignacionProspectos";
            this.capAsignacionProspectos.Size = new System.Drawing.Size(950, 26);
            this.capAsignacionProspectos.TabIndex = 45;
            // 
            // tableAsignacionProspectos
            // 
            this.tableAsignacionProspectos.AutoSize = true;
            this.tableAsignacionProspectos.ColumnCount = 7;
            this.tableAsignacionProspectos.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tableAsignacionProspectos.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.tableAsignacionProspectos.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.tableAsignacionProspectos.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tableAsignacionProspectos.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.tableAsignacionProspectos.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.tableAsignacionProspectos.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableAsignacionProspectos.Controls.Add(this.btnAsignar, 7, 0);
            this.tableAsignacionProspectos.Controls.Add(this.lblEjecutivo, 0, 0);
            this.tableAsignacionProspectos.Controls.Add(this.txeEjecutivo, 1, 0);
            this.tableAsignacionProspectos.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableAsignacionProspectos.Location = new System.Drawing.Point(0, 205);
            this.tableAsignacionProspectos.Name = "tableAsignacionProspectos";
            this.tableAsignacionProspectos.RowCount = 1;
            this.tableAsignacionProspectos.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableAsignacionProspectos.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableAsignacionProspectos.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableAsignacionProspectos.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableAsignacionProspectos.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableAsignacionProspectos.Size = new System.Drawing.Size(950, 27);
            this.tableAsignacionProspectos.TabIndex = 46;
            // 
            // btnAsignar
            // 
            this.btnAsignar.AutoSize = true;
            this.btnAsignar.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnAsignar.FlatAppearance.BorderColor = System.Drawing.Color.SteelBlue;
            this.btnAsignar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAsignar.ForeColor = System.Drawing.Color.Black;
            this.btnAsignar.Image = global::Delfin.Principal.Properties.Resources.index_preferences;
            this.btnAsignar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAsignar.Location = new System.Drawing.Point(730, 0);
            this.btnAsignar.Margin = new System.Windows.Forms.Padding(0);
            this.btnAsignar.Name = "btnAsignar";
            this.btnAsignar.Size = new System.Drawing.Size(73, 27);
            this.btnAsignar.TabIndex = 82;
            this.btnAsignar.Text = "Asignar";
            this.btnAsignar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAsignar.UseVisualStyleBackColor = true;
            // 
            // lblEjecutivo
            // 
            this.lblEjecutivo.AutoSize = true;
            this.lblEjecutivo.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEjecutivo.Location = new System.Drawing.Point(10, 7);
            this.lblEjecutivo.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
            this.lblEjecutivo.Name = "lblEjecutivo";
            this.lblEjecutivo.Size = new System.Drawing.Size(59, 13);
            this.lblEjecutivo.TabIndex = 81;
            this.lblEjecutivo.Text = "Ejecutivo";
            // 
            // txeEjecutivo
            // 
            this.txeEjecutivo.ActivarAyudaAuto = false;
            this.tableAsignacionProspectos.SetColumnSpan(this.txeEjecutivo, 4);
            this.txeEjecutivo.ContainerService = null;
            this.txeEjecutivo.EnabledAyudaButton = true;
            this.txeEjecutivo.Location = new System.Drawing.Point(153, 3);
            this.txeEjecutivo.LongitudAceptada = 0;
            this.txeEjecutivo.MyInstanciaAyuda = Delfin.Controls.Entidad.InstanciaAyuda.Habilitado;
            this.txeEjecutivo.Name = "txeEjecutivo";
            this.txeEjecutivo.RellenaCeros = false;
            this.txeEjecutivo.Size = new System.Drawing.Size(559, 20);
            this.txeEjecutivo.TabIndex = 83;
            this.txeEjecutivo.Tipo = Delfin.Controls.Entidad.TipoTextBoxAyuda.AlfaNumerico;
            this.txeEjecutivo.TipoEntidad = Delfin.Controls.TiposEntidad.TIPE_Ejecutivo;
            this.txeEjecutivo.Value = null;
            // 
            // navItems
            // 
            this.navItems.AddNewItem = null;
            this.navItems.BackColor = System.Drawing.Color.SteelBlue;
            this.navItems.CountItem = this.bindingNavigatorCountItem;
            this.navItems.CountItemFormat = "de {0}";
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
            this.navItems.Location = new System.Drawing.Point(0, 421);
            this.navItems.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.navItems.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.navItems.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.navItems.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.navItems.Name = "navItems";
            this.navItems.Padding = new System.Windows.Forms.Padding(3);
            this.navItems.PositionItem = this.bindingNavigatorPositionItem;
            this.navItems.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.navItems.Size = new System.Drawing.Size(950, 29);
            this.navItems.TabIndex = 47;
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
            this.bindingNavigatorMoveLastItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveLastItem.Image")));
            this.bindingNavigatorMoveLastItem.Name = "bindingNavigatorMoveLastItem";
            this.bindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveLastItem.Size = new System.Drawing.Size(23, 20);
            this.bindingNavigatorMoveLastItem.Text = "Ultimo";
            // 
            // bindingNavigatorMoveNextItem
            // 
            this.bindingNavigatorMoveNextItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.bindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveNextItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveNextItem.Image")));
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
            this.bindingNavigatorMovePreviousItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMovePreviousItem.Image")));
            this.bindingNavigatorMovePreviousItem.Name = "bindingNavigatorMovePreviousItem";
            this.bindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMovePreviousItem.Size = new System.Drawing.Size(23, 20);
            this.bindingNavigatorMovePreviousItem.Text = "Anterior";
            // 
            // bindingNavigatorMoveFirstItem
            // 
            this.bindingNavigatorMoveFirstItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.bindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveFirstItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveFirstItem.Image")));
            this.bindingNavigatorMoveFirstItem.Name = "bindingNavigatorMoveFirstItem";
            this.bindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveFirstItem.Size = new System.Drawing.Size(23, 20);
            this.bindingNavigatorMoveFirstItem.Text = "Primero";
            // 
            // grdItems
            // 
            this.grdItems.ContextMenuStrip = this.cmsMenu;
            this.grdItems.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdItems.Location = new System.Drawing.Point(0, 232);
            this.grdItems.Name = "grdItems";
            this.grdItems.Size = new System.Drawing.Size(950, 189);
            this.grdItems.TabIndex = 48;
            this.grdItems.TabStop = false;
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
            this.TitleView.Caption = "IMPORTACIÓN DE PROSPECTOS";
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
            // pgrImportacion
            // 
            this.pgrImportacion.Dock = System.Windows.Forms.DockStyle.Top;
            this.pgrImportacion.Location = new System.Drawing.Point(0, 156);
            this.pgrImportacion.Name = "pgrImportacion";
            this.pgrImportacion.Size = new System.Drawing.Size(950, 23);
            this.pgrImportacion.TabIndex = 49;
            this.pgrImportacion.Visible = false;
            // 
            // COM001LView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.Controls.Add(this.grdItems);
            this.Controls.Add(this.tableAsignacionProspectos);
            this.Controls.Add(this.capAsignacionProspectos);
            this.Controls.Add(this.pgrImportacion);
            this.Controls.Add(this.navItems);
            this.Controls.Add(this.tableCriterioImportacion);
            this.Controls.Add(this.capCriterioImportacion);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.TitleView);
            this.Name = "COM001LView";
            this.Size = new System.Drawing.Size(950, 450);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tableCriterioImportacion.ResumeLayout(false);
            this.tableCriterioImportacion.PerformLayout();
            this.tableAsignacionProspectos.ResumeLayout(false);
            this.tableAsignacionProspectos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.navItems)).EndInit();
            this.navItems.ResumeLayout(false);
            this.navItems.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdItems.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdItems)).EndInit();
            this.cmsMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

      }

      #endregion

      private Infrastructure.WinForms.Controls.FormTitle TitleView;
      private System.Windows.Forms.Panel panel1;
      private System.Windows.Forms.Button btnDeshacer;
      private System.Windows.Forms.Button btnEjecutar;
      private Infrastructure.WinForms.Controls.PanelCaption capCriterioImportacion;
      private System.Windows.Forms.TableLayoutPanel tableCriterioImportacion;
      private System.Windows.Forms.Label lblArchivo;
      private Infrastructure.WinForms.Controls.TextBoxOpenFile txoArchivo;
      private System.Windows.Forms.Label lblTEUS;
      private Infrastructure.WinForms.Controls.TextBoxNumerico txnTEUS;
      private Infrastructure.WinForms.Controls.PanelCaption capAsignacionProspectos;
      private System.Windows.Forms.TableLayoutPanel tableAsignacionProspectos;
      private System.Windows.Forms.Button btnAsignar;
      private System.Windows.Forms.Label lblEjecutivo;
      private System.Windows.Forms.BindingNavigator navItems;
      private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
      private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
      private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
      private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
      private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
      private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
      private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
      private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
      private Telerik.WinControls.UI.RadGridView grdItems;
      private System.Windows.Forms.Label lblRegimen;
      private System.Windows.Forms.ComboBox cmbRegimen;
      private System.Windows.Forms.ProgressBar pgrImportacion;
      private System.Windows.Forms.ContextMenuStrip cmsMenu;
      private System.Windows.Forms.ToolStripMenuItem tsmMarcarTodos;
      private System.Windows.Forms.ToolStripMenuItem tsmMarcarSeleccionados;
      private System.Windows.Forms.ToolStripMenuItem tsmDesmarcarTodos;
      private System.Windows.Forms.ToolStripMenuItem tsmDesmarcarSeleccionados;
      private Controls.Entidad txeEjecutivo;

   }
}
