namespace Delfin.Principal
{
   partial class COM006CView
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
         this.panel3 = new System.Windows.Forms.Panel();
         this.btnSalir = new System.Windows.Forms.Button();
         this.btnGuardar = new System.Windows.Forms.Button();
         this.panelCaption1 = new Infrastructure.WinForms.Controls.PanelCaption();
         this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
         this.lblCONT_Numero = new System.Windows.Forms.Label();
         this.CONT_Numero = new System.Windows.Forms.TextBox();
         this.lblCONT_FecEmi = new System.Windows.Forms.Label();
         this.CONT_FecEmi = new Infrastructure.WinForms.Controls.MaskDateTime();
         this.lblCONT_FecIni = new System.Windows.Forms.Label();
         this.CONT_FecIni = new Infrastructure.WinForms.Controls.MaskDateTime();
         this.lblCONT_FecFin = new System.Windows.Forms.Label();
         this.CONT_FecFin = new Infrastructure.WinForms.Controls.MaskDateTime();
         this.lblCONS_CodRGM = new System.Windows.Forms.Label();
         this.CONS_CodRGM = new Delfin.Controls.Tipos.ComboBoxConstantes();
         this.lblCONS_CodVia = new System.Windows.Forms.Label();
         this.CONS_CodVia = new Delfin.Controls.Tipos.ComboBoxConstantes();
         this.panelCaption2 = new Infrastructure.WinForms.Controls.PanelCaption();
         this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
         this.lblCONT_DescripNew = new System.Windows.Forms.Label();
         this.CONT_DescripNew = new System.Windows.Forms.TextBox();
         this.lblCONT_NumeroNew = new System.Windows.Forms.Label();
         this.CONT_NumeroNew = new System.Windows.Forms.TextBox();
         this.lblCONT_FecEmiNew = new System.Windows.Forms.Label();
         this.CONT_FecEmiNew = new Infrastructure.WinForms.Controls.MaskDateTime();
         this.lblCONT_FecIniNew = new System.Windows.Forms.Label();
         this.CONT_FecIniNew = new Infrastructure.WinForms.Controls.MaskDateTime();
         this.lblCONT_FecFinNew = new System.Windows.Forms.Label();
         this.CONT_FecFinNew = new Infrastructure.WinForms.Controls.MaskDateTime();
         this.panelCaption4 = new Infrastructure.WinForms.Controls.PanelCaption();
         this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
         this.lblTIPO_CodPAI = new System.Windows.Forms.Label();
         this.TIPO_CodPAI = new Delfin.Controls.Tipos.ComboBoxTipos();
         this.PUER_Codigo = new Infrastructure.WinForms.Controls.ComboBox.ComboBox(this.components);
         this.lblPUER_Codigo = new System.Windows.Forms.Label();
         this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
         this.panelCaption3 = new Infrastructure.WinForms.Controls.PanelCaption();
         this.lblCopiar = new System.Windows.Forms.Label();
         this.panel1 = new System.Windows.Forms.Panel();
         this.rbtContrato = new System.Windows.Forms.RadioButton();
         this.rbtTarifas = new System.Windows.Forms.RadioButton();
         this.lblCONT_Descrip = new System.Windows.Forms.Label();
         this.CONT_Descrip = new System.Windows.Forms.TextBox();
         this.panel3.SuspendLayout();
         this.tableLayoutPanel2.SuspendLayout();
         this.tableLayoutPanel1.SuspendLayout();
         this.tableLayoutPanel5.SuspendLayout();
         this.tableLayoutPanel3.SuspendLayout();
         this.panel1.SuspendLayout();
         this.SuspendLayout();
         // 
         // panel3
         // 
         this.panel3.BackColor = System.Drawing.Color.LightSteelBlue;
         this.panel3.Controls.Add(this.btnSalir);
         this.panel3.Controls.Add(this.btnGuardar);
         this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
         this.panel3.Location = new System.Drawing.Point(0, 0);
         this.panel3.Name = "panel3";
         this.panel3.Size = new System.Drawing.Size(734, 50);
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
         this.btnSalir.Image = global::Delfin.Principal.Properties.Resources.undo;
         this.btnSalir.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
         this.btnSalir.Location = new System.Drawing.Point(57, 0);
         this.btnSalir.Margin = new System.Windows.Forms.Padding(0);
         this.btnSalir.Name = "btnSalir";
         this.btnSalir.Size = new System.Drawing.Size(55, 50);
         this.btnSalir.TabIndex = 1;
         this.btnSalir.Text = "&Salir";
         this.btnSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
         this.btnSalir.UseVisualStyleBackColor = true;
         // 
         // btnGuardar
         // 
         this.btnGuardar.AutoSize = true;
         this.btnGuardar.Dock = System.Windows.Forms.DockStyle.Left;
         this.btnGuardar.FlatAppearance.BorderColor = System.Drawing.Color.LightSteelBlue;
         this.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
         this.btnGuardar.ForeColor = System.Drawing.Color.Black;
         this.btnGuardar.Image = global::Delfin.Principal.Properties.Resources.save;
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
         // panelCaption1
         // 
         this.panelCaption1.AllowActive = false;
         this.panelCaption1.AntiAlias = false;
         this.panelCaption1.Caption = "Datos de Contrato Origen";
         this.panelCaption1.Dock = System.Windows.Forms.DockStyle.Top;
         this.panelCaption1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
         this.panelCaption1.InactiveGradientHighColor = System.Drawing.Color.SteelBlue;
         this.panelCaption1.InactiveGradientLowColor = System.Drawing.Color.MidnightBlue;
         this.panelCaption1.Location = new System.Drawing.Point(0, 103);
         this.panelCaption1.Name = "panelCaption1";
         this.panelCaption1.Size = new System.Drawing.Size(734, 26);
         this.panelCaption1.TabIndex = 2;
         // 
         // tableLayoutPanel2
         // 
         this.tableLayoutPanel2.AutoSize = true;
         this.tableLayoutPanel2.ColumnCount = 7;
         this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
         this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
         this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15F));
         this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
         this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
         this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15F));
         this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
         this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
         this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
         this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
         this.tableLayoutPanel2.Controls.Add(this.lblCONT_Numero, 0, 0);
         this.tableLayoutPanel2.Controls.Add(this.CONT_Numero, 1, 0);
         this.tableLayoutPanel2.Controls.Add(this.lblCONT_FecEmi, 3, 0);
         this.tableLayoutPanel2.Controls.Add(this.CONT_FecEmi, 4, 0);
         this.tableLayoutPanel2.Controls.Add(this.lblCONT_FecIni, 0, 1);
         this.tableLayoutPanel2.Controls.Add(this.CONT_FecIni, 1, 1);
         this.tableLayoutPanel2.Controls.Add(this.lblCONT_FecFin, 3, 1);
         this.tableLayoutPanel2.Controls.Add(this.CONT_FecFin, 4, 1);
         this.tableLayoutPanel2.Controls.Add(this.lblCONS_CodRGM, 0, 2);
         this.tableLayoutPanel2.Controls.Add(this.CONS_CodRGM, 1, 2);
         this.tableLayoutPanel2.Controls.Add(this.lblCONS_CodVia, 3, 2);
         this.tableLayoutPanel2.Controls.Add(this.CONS_CodVia, 4, 2);
         this.tableLayoutPanel2.Controls.Add(this.CONT_Descrip, 1, 3);
         this.tableLayoutPanel2.Controls.Add(this.lblCONT_Descrip, 0, 3);
         this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Top;
         this.tableLayoutPanel2.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
         this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 129);
         this.tableLayoutPanel2.Name = "tableLayoutPanel2";
         this.tableLayoutPanel2.RowCount = 4;
         this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
         this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
         this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
         this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
         this.tableLayoutPanel2.Size = new System.Drawing.Size(734, 108);
         this.tableLayoutPanel2.TabIndex = 3;
         // 
         // lblCONT_Numero
         // 
         this.lblCONT_Numero.AutoSize = true;
         this.lblCONT_Numero.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.lblCONT_Numero.Location = new System.Drawing.Point(10, 7);
         this.lblCONT_Numero.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
         this.lblCONT_Numero.Name = "lblCONT_Numero";
         this.lblCONT_Numero.Size = new System.Drawing.Size(57, 13);
         this.lblCONT_Numero.TabIndex = 2;
         this.lblCONT_Numero.Text = "Número:";
         // 
         // CONT_Numero
         // 
         this.CONT_Numero.Location = new System.Drawing.Point(153, 3);
         this.CONT_Numero.Name = "CONT_Numero";
         this.CONT_Numero.Size = new System.Drawing.Size(194, 20);
         this.CONT_Numero.TabIndex = 3;
         this.CONT_Numero.Tag = "CONT_NumeroMSGERROR";
         // 
         // lblCONT_FecEmi
         // 
         this.lblCONT_FecEmi.AutoSize = true;
         this.lblCONT_FecEmi.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.lblCONT_FecEmi.Location = new System.Drawing.Point(375, 7);
         this.lblCONT_FecEmi.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
         this.lblCONT_FecEmi.Name = "lblCONT_FecEmi";
         this.lblCONT_FecEmi.Size = new System.Drawing.Size(93, 13);
         this.lblCONT_FecEmi.TabIndex = 4;
         this.lblCONT_FecEmi.Text = "Fecha Emision:";
         // 
         // CONT_FecEmi
         // 
         this.CONT_FecEmi.Location = new System.Drawing.Point(518, 3);
         this.CONT_FecEmi.MinimumSize = new System.Drawing.Size(100, 22);
         this.CONT_FecEmi.Name = "CONT_FecEmi";
         this.CONT_FecEmi.NSActiveMouse = false;
         this.CONT_FecEmi.NSActiveMsgFecha = false;
         this.CONT_FecEmi.NSChangeDate = true;
         this.CONT_FecEmi.NSDigitos = 4;
         this.CONT_FecEmi.NSFecha = null;
         this.CONT_FecEmi.NSSetDateNow = false;
         this.CONT_FecEmi.Size = new System.Drawing.Size(101, 22);
         this.CONT_FecEmi.TabIndex = 5;
         this.CONT_FecEmi.Tag = "CONT_FecEmiMSGERROR";
         // 
         // lblCONT_FecIni
         // 
         this.lblCONT_FecIni.AutoSize = true;
         this.lblCONT_FecIni.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.lblCONT_FecIni.Location = new System.Drawing.Point(10, 34);
         this.lblCONT_FecIni.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
         this.lblCONT_FecIni.Name = "lblCONT_FecIni";
         this.lblCONT_FecIni.Size = new System.Drawing.Size(80, 13);
         this.lblCONT_FecIni.TabIndex = 6;
         this.lblCONT_FecIni.Text = "Fecha Inicio:";
         // 
         // CONT_FecIni
         // 
         this.CONT_FecIni.Location = new System.Drawing.Point(153, 30);
         this.CONT_FecIni.MinimumSize = new System.Drawing.Size(100, 22);
         this.CONT_FecIni.Name = "CONT_FecIni";
         this.CONT_FecIni.NSActiveMouse = false;
         this.CONT_FecIni.NSActiveMsgFecha = false;
         this.CONT_FecIni.NSChangeDate = true;
         this.CONT_FecIni.NSDigitos = 4;
         this.CONT_FecIni.NSFecha = null;
         this.CONT_FecIni.NSSetDateNow = false;
         this.CONT_FecIni.Size = new System.Drawing.Size(101, 22);
         this.CONT_FecIni.TabIndex = 7;
         this.CONT_FecIni.Tag = "CONT_FecIniMSGERROR";
         // 
         // lblCONT_FecFin
         // 
         this.lblCONT_FecFin.AutoSize = true;
         this.lblCONT_FecFin.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.lblCONT_FecFin.Location = new System.Drawing.Point(375, 34);
         this.lblCONT_FecFin.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
         this.lblCONT_FecFin.Name = "lblCONT_FecFin";
         this.lblCONT_FecFin.Size = new System.Drawing.Size(65, 13);
         this.lblCONT_FecFin.TabIndex = 8;
         this.lblCONT_FecFin.Text = "Fecha Fin:";
         // 
         // CONT_FecFin
         // 
         this.CONT_FecFin.Location = new System.Drawing.Point(518, 30);
         this.CONT_FecFin.MinimumSize = new System.Drawing.Size(100, 22);
         this.CONT_FecFin.Name = "CONT_FecFin";
         this.CONT_FecFin.NSActiveMouse = false;
         this.CONT_FecFin.NSActiveMsgFecha = false;
         this.CONT_FecFin.NSChangeDate = true;
         this.CONT_FecFin.NSDigitos = 4;
         this.CONT_FecFin.NSFecha = null;
         this.CONT_FecFin.NSSetDateNow = false;
         this.CONT_FecFin.Size = new System.Drawing.Size(101, 22);
         this.CONT_FecFin.TabIndex = 9;
         this.CONT_FecFin.Tag = "CONT_FecFinMSGERROR";
         // 
         // lblCONS_CodRGM
         // 
         this.lblCONS_CodRGM.AutoSize = true;
         this.lblCONS_CodRGM.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.lblCONS_CodRGM.Location = new System.Drawing.Point(10, 61);
         this.lblCONS_CodRGM.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
         this.lblCONS_CodRGM.Name = "lblCONS_CodRGM";
         this.lblCONS_CodRGM.Size = new System.Drawing.Size(62, 13);
         this.lblCONS_CodRGM.TabIndex = 12;
         this.lblCONS_CodRGM.Text = "Régimen:";
         // 
         // CONS_CodRGM
         // 
         this.CONS_CodRGM.ConstantesSelectedItem = null;
         this.CONS_CodRGM.ConstantesSelectedValue = null;
         this.CONS_CodRGM.ConstantesTitulo = null;
         this.CONS_CodRGM.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this.CONS_CodRGM.FormattingEnabled = true;
         this.CONS_CodRGM.Location = new System.Drawing.Point(153, 57);
         this.CONS_CodRGM.Name = "CONS_CodRGM";
         this.CONS_CodRGM.Size = new System.Drawing.Size(194, 21);
         this.CONS_CodRGM.TabIndex = 13;
         this.CONS_CodRGM.Tag = "CONS_CodRGMMSGERROR";
         // 
         // lblCONS_CodVia
         // 
         this.lblCONS_CodVia.AutoSize = true;
         this.lblCONS_CodVia.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.lblCONS_CodVia.Location = new System.Drawing.Point(375, 61);
         this.lblCONS_CodVia.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
         this.lblCONS_CodVia.Name = "lblCONS_CodVia";
         this.lblCONS_CodVia.Size = new System.Drawing.Size(30, 13);
         this.lblCONS_CodVia.TabIndex = 16;
         this.lblCONS_CodVia.Text = "Vía:";
         // 
         // CONS_CodVia
         // 
         this.CONS_CodVia.ConstantesSelectedItem = null;
         this.CONS_CodVia.ConstantesSelectedValue = null;
         this.CONS_CodVia.ConstantesTitulo = null;
         this.CONS_CodVia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this.CONS_CodVia.FormattingEnabled = true;
         this.CONS_CodVia.Location = new System.Drawing.Point(518, 57);
         this.CONS_CodVia.Name = "CONS_CodVia";
         this.CONS_CodVia.Size = new System.Drawing.Size(194, 21);
         this.CONS_CodVia.TabIndex = 17;
         this.CONS_CodVia.Tag = "CONS_CodViaMSGERROR";
         // 
         // panelCaption2
         // 
         this.panelCaption2.AllowActive = false;
         this.panelCaption2.AntiAlias = false;
         this.panelCaption2.Caption = "Datos de Contrato Nuevo";
         this.panelCaption2.Dock = System.Windows.Forms.DockStyle.Top;
         this.panelCaption2.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
         this.panelCaption2.InactiveGradientHighColor = System.Drawing.Color.SteelBlue;
         this.panelCaption2.InactiveGradientLowColor = System.Drawing.Color.MidnightBlue;
         this.panelCaption2.Location = new System.Drawing.Point(0, 237);
         this.panelCaption2.Name = "panelCaption2";
         this.panelCaption2.Size = new System.Drawing.Size(734, 26);
         this.panelCaption2.TabIndex = 4;
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
         this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
         this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
         this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
         this.tableLayoutPanel1.Controls.Add(this.lblCONT_NumeroNew, 0, 0);
         this.tableLayoutPanel1.Controls.Add(this.CONT_NumeroNew, 1, 0);
         this.tableLayoutPanel1.Controls.Add(this.lblCONT_FecEmiNew, 3, 0);
         this.tableLayoutPanel1.Controls.Add(this.CONT_FecEmiNew, 4, 0);
         this.tableLayoutPanel1.Controls.Add(this.lblCONT_FecIniNew, 0, 1);
         this.tableLayoutPanel1.Controls.Add(this.CONT_FecIniNew, 1, 1);
         this.tableLayoutPanel1.Controls.Add(this.lblCONT_FecFinNew, 3, 1);
         this.tableLayoutPanel1.Controls.Add(this.CONT_FecFinNew, 4, 1);
         this.tableLayoutPanel1.Controls.Add(this.lblCONT_DescripNew, 0, 2);
         this.tableLayoutPanel1.Controls.Add(this.CONT_DescripNew, 1, 2);
         this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
         this.tableLayoutPanel1.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
         this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 263);
         this.tableLayoutPanel1.Name = "tableLayoutPanel1";
         this.tableLayoutPanel1.RowCount = 3;
         this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
         this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
         this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
         this.tableLayoutPanel1.Size = new System.Drawing.Size(734, 81);
         this.tableLayoutPanel1.TabIndex = 5;
         // 
         // lblCONT_DescripNew
         // 
         this.lblCONT_DescripNew.AutoSize = true;
         this.lblCONT_DescripNew.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.lblCONT_DescripNew.Location = new System.Drawing.Point(10, 61);
         this.lblCONT_DescripNew.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
         this.lblCONT_DescripNew.Name = "lblCONT_DescripNew";
         this.lblCONT_DescripNew.Size = new System.Drawing.Size(78, 13);
         this.lblCONT_DescripNew.TabIndex = 10;
         this.lblCONT_DescripNew.Text = "Descripción:";
         // 
         // CONT_DescripNew
         // 
         this.tableLayoutPanel1.SetColumnSpan(this.CONT_DescripNew, 4);
         this.CONT_DescripNew.Location = new System.Drawing.Point(153, 57);
         this.CONT_DescripNew.Name = "CONT_DescripNew";
         this.CONT_DescripNew.Size = new System.Drawing.Size(559, 20);
         this.CONT_DescripNew.TabIndex = 11;
         this.CONT_DescripNew.Tag = "CONT_DescripMSGERROR";
         // 
         // lblCONT_NumeroNew
         // 
         this.lblCONT_NumeroNew.AutoSize = true;
         this.lblCONT_NumeroNew.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.lblCONT_NumeroNew.Location = new System.Drawing.Point(10, 7);
         this.lblCONT_NumeroNew.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
         this.lblCONT_NumeroNew.Name = "lblCONT_NumeroNew";
         this.lblCONT_NumeroNew.Size = new System.Drawing.Size(57, 13);
         this.lblCONT_NumeroNew.TabIndex = 2;
         this.lblCONT_NumeroNew.Text = "Número:";
         // 
         // CONT_NumeroNew
         // 
         this.CONT_NumeroNew.Location = new System.Drawing.Point(153, 3);
         this.CONT_NumeroNew.Name = "CONT_NumeroNew";
         this.CONT_NumeroNew.Size = new System.Drawing.Size(194, 20);
         this.CONT_NumeroNew.TabIndex = 3;
         this.CONT_NumeroNew.Tag = "CONT_NumeroMSGERROR";
         // 
         // lblCONT_FecEmiNew
         // 
         this.lblCONT_FecEmiNew.AutoSize = true;
         this.lblCONT_FecEmiNew.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.lblCONT_FecEmiNew.Location = new System.Drawing.Point(375, 7);
         this.lblCONT_FecEmiNew.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
         this.lblCONT_FecEmiNew.Name = "lblCONT_FecEmiNew";
         this.lblCONT_FecEmiNew.Size = new System.Drawing.Size(93, 13);
         this.lblCONT_FecEmiNew.TabIndex = 4;
         this.lblCONT_FecEmiNew.Text = "Fecha Emision:";
         // 
         // CONT_FecEmiNew
         // 
         this.CONT_FecEmiNew.Location = new System.Drawing.Point(518, 3);
         this.CONT_FecEmiNew.MinimumSize = new System.Drawing.Size(100, 22);
         this.CONT_FecEmiNew.Name = "CONT_FecEmiNew";
         this.CONT_FecEmiNew.NSActiveMouse = false;
         this.CONT_FecEmiNew.NSActiveMsgFecha = false;
         this.CONT_FecEmiNew.NSChangeDate = true;
         this.CONT_FecEmiNew.NSDigitos = 4;
         this.CONT_FecEmiNew.NSFecha = null;
         this.CONT_FecEmiNew.NSSetDateNow = false;
         this.CONT_FecEmiNew.Size = new System.Drawing.Size(101, 22);
         this.CONT_FecEmiNew.TabIndex = 5;
         this.CONT_FecEmiNew.Tag = "CONT_FecEmiMSGERROR";
         // 
         // lblCONT_FecIniNew
         // 
         this.lblCONT_FecIniNew.AutoSize = true;
         this.lblCONT_FecIniNew.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.lblCONT_FecIniNew.Location = new System.Drawing.Point(10, 34);
         this.lblCONT_FecIniNew.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
         this.lblCONT_FecIniNew.Name = "lblCONT_FecIniNew";
         this.lblCONT_FecIniNew.Size = new System.Drawing.Size(80, 13);
         this.lblCONT_FecIniNew.TabIndex = 6;
         this.lblCONT_FecIniNew.Text = "Fecha Inicio:";
         // 
         // CONT_FecIniNew
         // 
         this.CONT_FecIniNew.Location = new System.Drawing.Point(153, 30);
         this.CONT_FecIniNew.MinimumSize = new System.Drawing.Size(100, 22);
         this.CONT_FecIniNew.Name = "CONT_FecIniNew";
         this.CONT_FecIniNew.NSActiveMouse = false;
         this.CONT_FecIniNew.NSActiveMsgFecha = false;
         this.CONT_FecIniNew.NSChangeDate = true;
         this.CONT_FecIniNew.NSDigitos = 4;
         this.CONT_FecIniNew.NSFecha = null;
         this.CONT_FecIniNew.NSSetDateNow = false;
         this.CONT_FecIniNew.Size = new System.Drawing.Size(101, 22);
         this.CONT_FecIniNew.TabIndex = 7;
         this.CONT_FecIniNew.Tag = "CONT_FecIniMSGERROR";
         // 
         // lblCONT_FecFinNew
         // 
         this.lblCONT_FecFinNew.AutoSize = true;
         this.lblCONT_FecFinNew.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.lblCONT_FecFinNew.Location = new System.Drawing.Point(375, 34);
         this.lblCONT_FecFinNew.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
         this.lblCONT_FecFinNew.Name = "lblCONT_FecFinNew";
         this.lblCONT_FecFinNew.Size = new System.Drawing.Size(65, 13);
         this.lblCONT_FecFinNew.TabIndex = 8;
         this.lblCONT_FecFinNew.Text = "Fecha Fin:";
         // 
         // CONT_FecFinNew
         // 
         this.CONT_FecFinNew.Location = new System.Drawing.Point(518, 30);
         this.CONT_FecFinNew.MinimumSize = new System.Drawing.Size(100, 22);
         this.CONT_FecFinNew.Name = "CONT_FecFinNew";
         this.CONT_FecFinNew.NSActiveMouse = false;
         this.CONT_FecFinNew.NSActiveMsgFecha = false;
         this.CONT_FecFinNew.NSChangeDate = true;
         this.CONT_FecFinNew.NSDigitos = 4;
         this.CONT_FecFinNew.NSFecha = null;
         this.CONT_FecFinNew.NSSetDateNow = false;
         this.CONT_FecFinNew.Size = new System.Drawing.Size(101, 22);
         this.CONT_FecFinNew.TabIndex = 9;
         this.CONT_FecFinNew.Tag = "CONT_FecFinMSGERROR";
         // 
         // panelCaption4
         // 
         this.panelCaption4.AllowActive = false;
         this.panelCaption4.AntiAlias = false;
         this.panelCaption4.Caption = "Datos de Tarifas Nuevas";
         this.panelCaption4.Dock = System.Windows.Forms.DockStyle.Top;
         this.panelCaption4.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
         this.panelCaption4.InactiveGradientHighColor = System.Drawing.Color.SteelBlue;
         this.panelCaption4.InactiveGradientLowColor = System.Drawing.Color.MidnightBlue;
         this.panelCaption4.Location = new System.Drawing.Point(0, 344);
         this.panelCaption4.Name = "panelCaption4";
         this.panelCaption4.Size = new System.Drawing.Size(734, 26);
         this.panelCaption4.TabIndex = 8;
         // 
         // tableLayoutPanel5
         // 
         this.tableLayoutPanel5.AutoSize = true;
         this.tableLayoutPanel5.ColumnCount = 7;
         this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
         this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
         this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15F));
         this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
         this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
         this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15F));
         this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
         this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
         this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
         this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
         this.tableLayoutPanel5.Controls.Add(this.lblTIPO_CodPAI, 0, 0);
         this.tableLayoutPanel5.Controls.Add(this.TIPO_CodPAI, 1, 0);
         this.tableLayoutPanel5.Controls.Add(this.PUER_Codigo, 4, 0);
         this.tableLayoutPanel5.Controls.Add(this.lblPUER_Codigo, 3, 0);
         this.tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Top;
         this.tableLayoutPanel5.Location = new System.Drawing.Point(0, 370);
         this.tableLayoutPanel5.Name = "tableLayoutPanel5";
         this.tableLayoutPanel5.RowCount = 1;
         this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
         this.tableLayoutPanel5.Size = new System.Drawing.Size(734, 27);
         this.tableLayoutPanel5.TabIndex = 15;
         // 
         // lblTIPO_CodPAI
         // 
         this.lblTIPO_CodPAI.AutoSize = true;
         this.lblTIPO_CodPAI.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.lblTIPO_CodPAI.Location = new System.Drawing.Point(10, 7);
         this.lblTIPO_CodPAI.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
         this.lblTIPO_CodPAI.Name = "lblTIPO_CodPAI";
         this.lblTIPO_CodPAI.Size = new System.Drawing.Size(35, 13);
         this.lblTIPO_CodPAI.TabIndex = 31;
         this.lblTIPO_CodPAI.Text = "País:";
         // 
         // TIPO_CodPAI
         // 
         this.TIPO_CodPAI.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this.TIPO_CodPAI.FormattingEnabled = true;
         this.TIPO_CodPAI.Location = new System.Drawing.Point(153, 3);
         this.TIPO_CodPAI.Name = "TIPO_CodPAI";
         this.TIPO_CodPAI.Size = new System.Drawing.Size(194, 21);
         this.TIPO_CodPAI.TabIndex = 32;
         this.TIPO_CodPAI.TiposSelectedItem = null;
         this.TIPO_CodPAI.TiposSelectedValue = null;
         this.TIPO_CodPAI.TiposTitulo = null;
         // 
         // PUER_Codigo
         // 
         this.PUER_Codigo.ComboIntSelectedValue = null;
         this.PUER_Codigo.ComboSelectedItem = null;
         this.PUER_Codigo.ComboStrSelectedValue = null;
         this.PUER_Codigo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this.PUER_Codigo.FormattingEnabled = true;
         this.PUER_Codigo.Location = new System.Drawing.Point(518, 3);
         this.PUER_Codigo.Name = "PUER_Codigo";
         this.PUER_Codigo.Size = new System.Drawing.Size(194, 21);
         this.PUER_Codigo.TabIndex = 34;
         this.PUER_Codigo.Tag = "PUER_CodOrigenMSGERROR";
         // 
         // lblPUER_Codigo
         // 
         this.lblPUER_Codigo.AutoSize = true;
         this.lblPUER_Codigo.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.lblPUER_Codigo.Location = new System.Drawing.Point(375, 7);
         this.lblPUER_Codigo.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
         this.lblPUER_Codigo.Name = "lblPUER_Codigo";
         this.lblPUER_Codigo.Size = new System.Drawing.Size(49, 13);
         this.lblPUER_Codigo.TabIndex = 33;
         this.lblPUER_Codigo.Text = "Puerto:";
         // 
         // tableLayoutPanel3
         // 
         this.tableLayoutPanel3.AutoSize = true;
         this.tableLayoutPanel3.ColumnCount = 7;
         this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
         this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
         this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15F));
         this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
         this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
         this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15F));
         this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
         this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
         this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
         this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
         this.tableLayoutPanel3.Controls.Add(this.lblCopiar, 0, 0);
         this.tableLayoutPanel3.Controls.Add(this.panel1, 1, 0);
         this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Top;
         this.tableLayoutPanel3.Location = new System.Drawing.Point(0, 76);
         this.tableLayoutPanel3.Name = "tableLayoutPanel3";
         this.tableLayoutPanel3.RowCount = 1;
         this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
         this.tableLayoutPanel3.Size = new System.Drawing.Size(734, 27);
         this.tableLayoutPanel3.TabIndex = 16;
         // 
         // panelCaption3
         // 
         this.panelCaption3.AllowActive = false;
         this.panelCaption3.AntiAlias = false;
         this.panelCaption3.Caption = "Metodo de Copiado";
         this.panelCaption3.Dock = System.Windows.Forms.DockStyle.Top;
         this.panelCaption3.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
         this.panelCaption3.InactiveGradientHighColor = System.Drawing.Color.SteelBlue;
         this.panelCaption3.InactiveGradientLowColor = System.Drawing.Color.MidnightBlue;
         this.panelCaption3.Location = new System.Drawing.Point(0, 50);
         this.panelCaption3.Name = "panelCaption3";
         this.panelCaption3.Size = new System.Drawing.Size(734, 26);
         this.panelCaption3.TabIndex = 17;
         // 
         // lblCopiar
         // 
         this.lblCopiar.AutoSize = true;
         this.lblCopiar.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.lblCopiar.Location = new System.Drawing.Point(10, 7);
         this.lblCopiar.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
         this.lblCopiar.Name = "lblCopiar";
         this.lblCopiar.Size = new System.Drawing.Size(50, 13);
         this.lblCopiar.TabIndex = 32;
         this.lblCopiar.Text = "Copiar:";
         // 
         // panel1
         // 
         this.panel1.Controls.Add(this.rbtTarifas);
         this.panel1.Controls.Add(this.rbtContrato);
         this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
         this.panel1.Location = new System.Drawing.Point(150, 0);
         this.panel1.Margin = new System.Windows.Forms.Padding(0);
         this.panel1.Name = "panel1";
         this.panel1.Size = new System.Drawing.Size(200, 27);
         this.panel1.TabIndex = 33;
         // 
         // rbtContrato
         // 
         this.rbtContrato.AutoSize = true;
         this.rbtContrato.Checked = true;
         this.rbtContrato.Dock = System.Windows.Forms.DockStyle.Left;
         this.rbtContrato.Location = new System.Drawing.Point(0, 0);
         this.rbtContrato.Name = "rbtContrato";
         this.rbtContrato.Size = new System.Drawing.Size(65, 27);
         this.rbtContrato.TabIndex = 0;
         this.rbtContrato.TabStop = true;
         this.rbtContrato.Text = "Contrato";
         this.rbtContrato.UseVisualStyleBackColor = true;
         // 
         // rbtTarifas
         // 
         this.rbtTarifas.AutoSize = true;
         this.rbtTarifas.Dock = System.Windows.Forms.DockStyle.Left;
         this.rbtTarifas.Location = new System.Drawing.Point(65, 0);
         this.rbtTarifas.Name = "rbtTarifas";
         this.rbtTarifas.Size = new System.Drawing.Size(57, 27);
         this.rbtTarifas.TabIndex = 1;
         this.rbtTarifas.TabStop = true;
         this.rbtTarifas.Text = "Tarifas";
         this.rbtTarifas.UseVisualStyleBackColor = true;
         // 
         // lblCONT_Descrip
         // 
         this.lblCONT_Descrip.AutoSize = true;
         this.lblCONT_Descrip.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.lblCONT_Descrip.Location = new System.Drawing.Point(10, 88);
         this.lblCONT_Descrip.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
         this.lblCONT_Descrip.Name = "lblCONT_Descrip";
         this.lblCONT_Descrip.Size = new System.Drawing.Size(78, 13);
         this.lblCONT_Descrip.TabIndex = 18;
         this.lblCONT_Descrip.Text = "Descripción:";
         // 
         // CONT_Descrip
         // 
         this.tableLayoutPanel2.SetColumnSpan(this.CONT_Descrip, 4);
         this.CONT_Descrip.Location = new System.Drawing.Point(153, 84);
         this.CONT_Descrip.Name = "CONT_Descrip";
         this.CONT_Descrip.Size = new System.Drawing.Size(559, 20);
         this.CONT_Descrip.TabIndex = 19;
         this.CONT_Descrip.Tag = "CONT_DescripMSGERROR";
         // 
         // COM006CView
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.BackColor = System.Drawing.Color.LightSteelBlue;
         this.ClientSize = new System.Drawing.Size(734, 400);
         this.Controls.Add(this.tableLayoutPanel5);
         this.Controls.Add(this.panelCaption4);
         this.Controls.Add(this.tableLayoutPanel1);
         this.Controls.Add(this.panelCaption2);
         this.Controls.Add(this.tableLayoutPanel2);
         this.Controls.Add(this.panelCaption1);
         this.Controls.Add(this.tableLayoutPanel3);
         this.Controls.Add(this.panelCaption3);
         this.Controls.Add(this.panel3);
         this.Name = "COM006CView";
         this.Text = "Copiar Contrato y/o Tarifas";
         this.panel3.ResumeLayout(false);
         this.panel3.PerformLayout();
         this.tableLayoutPanel2.ResumeLayout(false);
         this.tableLayoutPanel2.PerformLayout();
         this.tableLayoutPanel1.ResumeLayout(false);
         this.tableLayoutPanel1.PerformLayout();
         this.tableLayoutPanel5.ResumeLayout(false);
         this.tableLayoutPanel5.PerformLayout();
         this.tableLayoutPanel3.ResumeLayout(false);
         this.tableLayoutPanel3.PerformLayout();
         this.panel1.ResumeLayout(false);
         this.panel1.PerformLayout();
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.Panel panel3;
      private System.Windows.Forms.Button btnSalir;
      private System.Windows.Forms.Button btnGuardar;
      private Infrastructure.WinForms.Controls.PanelCaption panelCaption1;
      private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
      private System.Windows.Forms.Label lblCONT_Numero;
      private System.Windows.Forms.TextBox CONT_Numero;
      private System.Windows.Forms.Label lblCONT_FecEmi;
      private Infrastructure.WinForms.Controls.MaskDateTime CONT_FecEmi;
      private System.Windows.Forms.Label lblCONT_FecIni;
      private Infrastructure.WinForms.Controls.MaskDateTime CONT_FecIni;
      private System.Windows.Forms.Label lblCONT_FecFin;
      private Infrastructure.WinForms.Controls.MaskDateTime CONT_FecFin;
      private System.Windows.Forms.Label lblCONS_CodRGM;
      private Controls.Tipos.ComboBoxConstantes CONS_CodRGM;
      private System.Windows.Forms.Label lblCONS_CodVia;
      private Controls.Tipos.ComboBoxConstantes CONS_CodVia;
      private Infrastructure.WinForms.Controls.PanelCaption panelCaption2;
      private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
      private System.Windows.Forms.Label lblCONT_NumeroNew;
      private System.Windows.Forms.TextBox CONT_NumeroNew;
      private System.Windows.Forms.Label lblCONT_FecEmiNew;
      private Infrastructure.WinForms.Controls.MaskDateTime CONT_FecEmiNew;
      private System.Windows.Forms.Label lblCONT_FecIniNew;
      private Infrastructure.WinForms.Controls.MaskDateTime CONT_FecIniNew;
      private System.Windows.Forms.Label lblCONT_FecFinNew;
      private Infrastructure.WinForms.Controls.MaskDateTime CONT_FecFinNew;
      private System.Windows.Forms.TextBox CONT_DescripNew;
      private System.Windows.Forms.Label lblCONT_DescripNew;
      private Infrastructure.WinForms.Controls.PanelCaption panelCaption4;
      private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
      private System.Windows.Forms.Label lblTIPO_CodPAI;
      private Controls.Tipos.ComboBoxTipos TIPO_CodPAI;
      private Infrastructure.WinForms.Controls.ComboBox.ComboBox PUER_Codigo;
      private System.Windows.Forms.Label lblPUER_Codigo;
      private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
      private System.Windows.Forms.Label lblCopiar;
      private System.Windows.Forms.Panel panel1;
      private System.Windows.Forms.RadioButton rbtTarifas;
      private System.Windows.Forms.RadioButton rbtContrato;
      private Infrastructure.WinForms.Controls.PanelCaption panelCaption3;
      private System.Windows.Forms.TextBox CONT_Descrip;
      private System.Windows.Forms.Label lblCONT_Descrip;
   }
}