namespace Delfin.Principal
{
   partial class MAN005MView
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
         this.btnMAN_salir = new System.Windows.Forms.Button();
         this.btnMAN_guardar = new System.Windows.Forms.Button();
         this.panelCaption1 = new Infrastructure.WinForms.Controls.PanelCaption();
         this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
         this.CONT_Descrip = new System.Windows.Forms.TextBox();
         this.lblCONT_Descrip = new System.Windows.Forms.Label();
         this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
         this.CONT_Codigo = new System.Windows.Forms.TextBox();
         this.label5 = new System.Windows.Forms.Label();
         this.ENTC_CodCliente = new Delfin.Controls.Entidad(this.components);
         this.lblCONT_Numero = new System.Windows.Forms.Label();
         this.CONT_Numero = new System.Windows.Forms.TextBox();
         this.label2 = new System.Windows.Forms.Label();
         this.CONS_CodRGM = new Delfin.Controls.Tipos.ComboBoxConstantes();
         this.lblCONT_FecIni = new System.Windows.Forms.Label();
         this.CONT_FecIni = new Infrastructure.WinForms.Controls.MaskDateTime();
         this.ENTC_CodTransportista = new Delfin.Controls.Entidad(this.components);
         this.label1 = new System.Windows.Forms.Label();
         this.label7 = new System.Windows.Forms.Label();
         this.CONS_CodVia = new Delfin.Controls.Tipos.ComboBoxConstantes();
         this.CONT_FecFin = new Infrastructure.WinForms.Controls.MaskDateTime();
         this.CONT_FecEmi = new Infrastructure.WinForms.Controls.MaskDateTime();
         this.label4 = new System.Windows.Forms.Label();
         this.lblCONT_FecFin = new System.Windows.Forms.Label();
         this.label3 = new System.Windows.Forms.Label();
         this.CONT_Activo = new System.Windows.Forms.CheckBox();
         this.label6 = new System.Windows.Forms.Label();
         this.panel3.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
         this.tableLayoutPanel2.SuspendLayout();
         this.SuspendLayout();
         // 
         // panel3
         // 
         this.panel3.BackColor = System.Drawing.Color.LightSteelBlue;
         this.panel3.Controls.Add(this.btnMAN_salir);
         this.panel3.Controls.Add(this.btnMAN_guardar);
         this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
         this.panel3.Location = new System.Drawing.Point(0, 0);
         this.panel3.Name = "panel3";
         this.panel3.Size = new System.Drawing.Size(750, 50);
         this.panel3.TabIndex = 0;
         // 
         // btnMAN_salir
         // 
         this.btnMAN_salir.AutoSize = true;
         this.btnMAN_salir.DialogResult = System.Windows.Forms.DialogResult.Cancel;
         this.btnMAN_salir.Dock = System.Windows.Forms.DockStyle.Left;
         this.btnMAN_salir.FlatAppearance.BorderColor = System.Drawing.Color.LightSteelBlue;
         this.btnMAN_salir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
         this.btnMAN_salir.ForeColor = System.Drawing.Color.Black;
         this.btnMAN_salir.Image = global::Delfin.Principal.Properties.Resources.undo;
         this.btnMAN_salir.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
         this.btnMAN_salir.Location = new System.Drawing.Point(57, 0);
         this.btnMAN_salir.Margin = new System.Windows.Forms.Padding(0);
         this.btnMAN_salir.Name = "btnMAN_salir";
         this.btnMAN_salir.Size = new System.Drawing.Size(55, 50);
         this.btnMAN_salir.TabIndex = 1;
         this.btnMAN_salir.Text = "&Salir";
         this.btnMAN_salir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
         this.btnMAN_salir.UseVisualStyleBackColor = true;
         this.btnMAN_salir.Click += new System.EventHandler(this.btnSalir_Click);
         // 
         // btnMAN_guardar
         // 
         this.btnMAN_guardar.AutoSize = true;
         this.btnMAN_guardar.Dock = System.Windows.Forms.DockStyle.Left;
         this.btnMAN_guardar.FlatAppearance.BorderColor = System.Drawing.Color.LightSteelBlue;
         this.btnMAN_guardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
         this.btnMAN_guardar.ForeColor = System.Drawing.Color.Black;
         this.btnMAN_guardar.Image = global::Delfin.Principal.Properties.Resources.save;
         this.btnMAN_guardar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
         this.btnMAN_guardar.Location = new System.Drawing.Point(0, 0);
         this.btnMAN_guardar.Margin = new System.Windows.Forms.Padding(0);
         this.btnMAN_guardar.Name = "btnMAN_guardar";
         this.btnMAN_guardar.Size = new System.Drawing.Size(57, 50);
         this.btnMAN_guardar.TabIndex = 0;
         this.btnMAN_guardar.Text = "&Guardar";
         this.btnMAN_guardar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
         this.btnMAN_guardar.UseVisualStyleBackColor = true;
         this.btnMAN_guardar.Click += new System.EventHandler(this.btnGuardar_Click);
         // 
         // panelCaption1
         // 
         this.panelCaption1.AllowActive = false;
         this.panelCaption1.AntiAlias = false;
         this.panelCaption1.Caption = "Datos de Contrato";
         this.panelCaption1.Dock = System.Windows.Forms.DockStyle.Top;
         this.panelCaption1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
         this.panelCaption1.InactiveGradientHighColor = System.Drawing.Color.SteelBlue;
         this.panelCaption1.InactiveGradientLowColor = System.Drawing.Color.MidnightBlue;
         this.panelCaption1.Location = new System.Drawing.Point(0, 50);
         this.panelCaption1.Name = "panelCaption1";
         this.panelCaption1.Size = new System.Drawing.Size(750, 26);
         this.panelCaption1.TabIndex = 46;
         // 
         // errorProvider1
         // 
         this.errorProvider1.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
         this.errorProvider1.ContainerControl = this;
         // 
         // CONT_Descrip
         // 
         this.tableLayoutPanel2.SetColumnSpan(this.CONT_Descrip, 3);
         this.CONT_Descrip.Location = new System.Drawing.Point(153, 57);
         this.CONT_Descrip.Name = "CONT_Descrip";
         this.CONT_Descrip.Size = new System.Drawing.Size(374, 20);
         this.CONT_Descrip.TabIndex = 3;
         this.CONT_Descrip.Tag = "CONT_DescripMSGERROR";
         // 
         // lblCONT_Descrip
         // 
         this.lblCONT_Descrip.AutoSize = true;
         this.lblCONT_Descrip.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.lblCONT_Descrip.Location = new System.Drawing.Point(10, 61);
         this.lblCONT_Descrip.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
         this.lblCONT_Descrip.Name = "lblCONT_Descrip";
         this.lblCONT_Descrip.Size = new System.Drawing.Size(78, 13);
         this.lblCONT_Descrip.TabIndex = 2;
         this.lblCONT_Descrip.Text = "Descripción:";
         // 
         // tableLayoutPanel2
         // 
         this.tableLayoutPanel2.AutoSize = true;
         this.tableLayoutPanel2.ColumnCount = 7;
         this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
         this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 215F));
         this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15F));
         this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
         this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
         this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15F));
         this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
         this.tableLayoutPanel2.Controls.Add(this.CONT_Codigo, 1, 0);
         this.tableLayoutPanel2.Controls.Add(this.label5, 0, 0);
         this.tableLayoutPanel2.Controls.Add(this.ENTC_CodCliente, 1, 5);
         this.tableLayoutPanel2.Controls.Add(this.lblCONT_Numero, 0, 1);
         this.tableLayoutPanel2.Controls.Add(this.CONT_Numero, 1, 1);
         this.tableLayoutPanel2.Controls.Add(this.lblCONT_Descrip, 0, 2);
         this.tableLayoutPanel2.Controls.Add(this.CONT_Descrip, 1, 2);
         this.tableLayoutPanel2.Controls.Add(this.label2, 0, 6);
         this.tableLayoutPanel2.Controls.Add(this.CONS_CodRGM, 1, 6);
         this.tableLayoutPanel2.Controls.Add(this.lblCONT_FecIni, 0, 3);
         this.tableLayoutPanel2.Controls.Add(this.CONT_FecIni, 1, 3);
         this.tableLayoutPanel2.Controls.Add(this.ENTC_CodTransportista, 1, 4);
         this.tableLayoutPanel2.Controls.Add(this.label1, 0, 5);
         this.tableLayoutPanel2.Controls.Add(this.label7, 0, 4);
         this.tableLayoutPanel2.Controls.Add(this.CONS_CodVia, 4, 6);
         this.tableLayoutPanel2.Controls.Add(this.CONT_FecFin, 4, 3);
         this.tableLayoutPanel2.Controls.Add(this.CONT_FecEmi, 4, 1);
         this.tableLayoutPanel2.Controls.Add(this.label4, 3, 1);
         this.tableLayoutPanel2.Controls.Add(this.lblCONT_FecFin, 3, 3);
         this.tableLayoutPanel2.Controls.Add(this.label3, 3, 6);
         this.tableLayoutPanel2.Controls.Add(this.CONT_Activo, 4, 0);
         this.tableLayoutPanel2.Controls.Add(this.label6, 3, 0);
         this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Top;
         this.tableLayoutPanel2.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
         this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 76);
         this.tableLayoutPanel2.Name = "tableLayoutPanel2";
         this.tableLayoutPanel2.RowCount = 7;
         this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
         this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
         this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
         this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
         this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
         this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
         this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
         this.tableLayoutPanel2.Size = new System.Drawing.Size(750, 189);
         this.tableLayoutPanel2.TabIndex = 2;
         // 
         // CONT_Codigo
         // 
         this.CONT_Codigo.Location = new System.Drawing.Point(153, 3);
         this.CONT_Codigo.Name = "CONT_Codigo";
         this.CONT_Codigo.ReadOnly = true;
         this.CONT_Codigo.Size = new System.Drawing.Size(194, 20);
         this.CONT_Codigo.TabIndex = 1;
         // 
         // label5
         // 
         this.label5.AutoSize = true;
         this.label5.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.label5.Location = new System.Drawing.Point(10, 7);
         this.label5.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
         this.label5.Name = "label5";
         this.label5.Size = new System.Drawing.Size(52, 13);
         this.label5.TabIndex = 26;
         this.label5.Text = "Codigo:";
         // 
         // ENTC_CodCliente
         // 
         this.ENTC_CodCliente.ActivarAyudaAuto = false;
         this.tableLayoutPanel2.SetColumnSpan(this.ENTC_CodCliente, 4);
         this.ENTC_CodCliente.EnabledAyudaButton = true;
         this.ENTC_CodCliente.Location = new System.Drawing.Point(153, 138);
         this.ENTC_CodCliente.LongitudAceptada = 0;
         this.ENTC_CodCliente.MyInstanciaAyuda = Delfin.Controls.Entidad.InstanciaAyuda.Habilitado;
         this.ENTC_CodCliente.Name = "ENTC_CodCliente";
         this.ENTC_CodCliente.RellenaCeros = false;
         this.ENTC_CodCliente.Size = new System.Drawing.Size(574, 20);
         this.ENTC_CodCliente.TabIndex = 6;
         this.ENTC_CodCliente.Tipo = Delfin.Controls.Entidad.TipoTextBoxAyuda.AlfaNumerico;
         this.ENTC_CodCliente.TipoEntidad = Delfin.Controls.TiposEntidad.TIPE_Cliente;
         this.ENTC_CodCliente.Value = null;
         // 
         // lblCONT_Numero
         // 
         this.lblCONT_Numero.AutoSize = true;
         this.lblCONT_Numero.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.lblCONT_Numero.Location = new System.Drawing.Point(10, 34);
         this.lblCONT_Numero.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
         this.lblCONT_Numero.Name = "lblCONT_Numero";
         this.lblCONT_Numero.Size = new System.Drawing.Size(57, 13);
         this.lblCONT_Numero.TabIndex = 2;
         this.lblCONT_Numero.Text = "Número:";
         // 
         // CONT_Numero
         // 
         this.CONT_Numero.Location = new System.Drawing.Point(153, 30);
         this.CONT_Numero.Name = "CONT_Numero";
         this.CONT_Numero.Size = new System.Drawing.Size(194, 20);
         this.CONT_Numero.TabIndex = 2;
         this.CONT_Numero.Tag = "CONT_NumeroMSGERROR";
         // 
         // label2
         // 
         this.label2.AutoSize = true;
         this.label2.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.label2.Location = new System.Drawing.Point(10, 169);
         this.label2.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
         this.label2.Name = "label2";
         this.label2.Size = new System.Drawing.Size(98, 13);
         this.label2.TabIndex = 24;
         this.label2.Text = "Elegir Regimen:";
         // 
         // CONS_CodRGM
         // 
         this.CONS_CodRGM.ConstantesSelectedItem = null;
         this.CONS_CodRGM.ConstantesSelectedValue = null;
         this.CONS_CodRGM.ConstantesTitulo = null;
         this.CONS_CodRGM.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this.CONS_CodRGM.FormattingEnabled = true;
         this.CONS_CodRGM.Location = new System.Drawing.Point(153, 165);
         this.CONS_CodRGM.Name = "CONS_CodRGM";
         this.CONS_CodRGM.Size = new System.Drawing.Size(194, 21);
         this.CONS_CodRGM.TabIndex = 7;
         // 
         // lblCONT_FecIni
         // 
         this.lblCONT_FecIni.AutoSize = true;
         this.lblCONT_FecIni.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.lblCONT_FecIni.Location = new System.Drawing.Point(10, 88);
         this.lblCONT_FecIni.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
         this.lblCONT_FecIni.Name = "lblCONT_FecIni";
         this.lblCONT_FecIni.Size = new System.Drawing.Size(80, 13);
         this.lblCONT_FecIni.TabIndex = 2;
         this.lblCONT_FecIni.Text = "Fecha Inicio:";
         // 
         // CONT_FecIni
         // 
         this.CONT_FecIni.Location = new System.Drawing.Point(153, 84);
         this.CONT_FecIni.MinimumSize = new System.Drawing.Size(100, 22);
         this.CONT_FecIni.Name = "CONT_FecIni";
         this.CONT_FecIni.NSActiveMouse = false;
         this.CONT_FecIni.NSActiveMsgFecha = false;
         this.CONT_FecIni.NSChangeDate = true;
         this.CONT_FecIni.NSDigitos = 4;
         this.CONT_FecIni.NSFecha = null;
         this.CONT_FecIni.NSSetDateNow = false;
         this.CONT_FecIni.Size = new System.Drawing.Size(101, 22);
         this.CONT_FecIni.TabIndex = 4;
         this.CONT_FecIni.Tag = "CONT_FecIniMSGERROR";
         // 
         // ENTC_CodTransportista
         // 
         this.ENTC_CodTransportista.ActivarAyudaAuto = false;
         this.tableLayoutPanel2.SetColumnSpan(this.ENTC_CodTransportista, 4);
         this.ENTC_CodTransportista.EnabledAyudaButton = true;
         this.ENTC_CodTransportista.Location = new System.Drawing.Point(153, 111);
         this.ENTC_CodTransportista.LongitudAceptada = 0;
         this.ENTC_CodTransportista.MyInstanciaAyuda = Delfin.Controls.Entidad.InstanciaAyuda.Habilitado;
         this.ENTC_CodTransportista.Name = "ENTC_CodTransportista";
         this.ENTC_CodTransportista.RellenaCeros = false;
         this.ENTC_CodTransportista.Size = new System.Drawing.Size(574, 20);
         this.ENTC_CodTransportista.TabIndex = 5;
         this.ENTC_CodTransportista.Tag = "ENTC_CodTransportistaMSGERROR";
         this.ENTC_CodTransportista.Tipo = Delfin.Controls.Entidad.TipoTextBoxAyuda.AlfaNumerico;
         this.ENTC_CodTransportista.TipoEntidad = Delfin.Controls.TiposEntidad.TIPE_Transportista;
         this.ENTC_CodTransportista.Value = null;
         // 
         // label1
         // 
         this.label1.AutoSize = true;
         this.label1.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.label1.Location = new System.Drawing.Point(10, 142);
         this.label1.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
         this.label1.Name = "label1";
         this.label1.Size = new System.Drawing.Size(47, 13);
         this.label1.TabIndex = 23;
         this.label1.Text = "Cliente";
         // 
         // label7
         // 
         this.label7.AutoSize = true;
         this.label7.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.label7.Location = new System.Drawing.Point(10, 115);
         this.label7.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
         this.label7.Name = "label7";
         this.label7.Size = new System.Drawing.Size(82, 13);
         this.label7.TabIndex = 35;
         this.label7.Text = "Transportista";
         // 
         // CONS_CodVia
         // 
         this.CONS_CodVia.ConstantesSelectedItem = null;
         this.CONS_CodVia.ConstantesSelectedValue = null;
         this.CONS_CodVia.ConstantesTitulo = null;
         this.CONS_CodVia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this.CONS_CodVia.FormattingEnabled = true;
         this.CONS_CodVia.Location = new System.Drawing.Point(533, 165);
         this.CONS_CodVia.Name = "CONS_CodVia";
         this.CONS_CodVia.Size = new System.Drawing.Size(194, 21);
         this.CONS_CodVia.TabIndex = 11;
         // 
         // CONT_FecFin
         // 
         this.CONT_FecFin.Location = new System.Drawing.Point(533, 84);
         this.CONT_FecFin.MinimumSize = new System.Drawing.Size(100, 22);
         this.CONT_FecFin.Name = "CONT_FecFin";
         this.CONT_FecFin.NSActiveMouse = false;
         this.CONT_FecFin.NSActiveMsgFecha = false;
         this.CONT_FecFin.NSChangeDate = true;
         this.CONT_FecFin.NSDigitos = 4;
         this.CONT_FecFin.NSFecha = null;
         this.CONT_FecFin.NSSetDateNow = false;
         this.CONT_FecFin.Size = new System.Drawing.Size(101, 22);
         this.CONT_FecFin.TabIndex = 10;
         this.CONT_FecFin.Tag = "CONT_FecFinMSGERROR";
         // 
         // CONT_FecEmi
         // 
         this.CONT_FecEmi.Location = new System.Drawing.Point(533, 30);
         this.CONT_FecEmi.MinimumSize = new System.Drawing.Size(100, 22);
         this.CONT_FecEmi.Name = "CONT_FecEmi";
         this.CONT_FecEmi.NSActiveMouse = false;
         this.CONT_FecEmi.NSActiveMsgFecha = false;
         this.CONT_FecEmi.NSChangeDate = true;
         this.CONT_FecEmi.NSDigitos = 4;
         this.CONT_FecEmi.NSFecha = null;
         this.CONT_FecEmi.NSSetDateNow = false;
         this.CONT_FecEmi.Size = new System.Drawing.Size(101, 22);
         this.CONT_FecEmi.TabIndex = 9;
         this.CONT_FecEmi.Tag = "CONT_FecEmiMSGERROR";
         // 
         // label4
         // 
         this.label4.AutoSize = true;
         this.label4.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.label4.Location = new System.Drawing.Point(390, 34);
         this.label4.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
         this.label4.Name = "label4";
         this.label4.Size = new System.Drawing.Size(93, 13);
         this.label4.TabIndex = 2;
         this.label4.Text = "Fecha Emision:";
         // 
         // lblCONT_FecFin
         // 
         this.lblCONT_FecFin.AutoSize = true;
         this.lblCONT_FecFin.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.lblCONT_FecFin.Location = new System.Drawing.Point(390, 88);
         this.lblCONT_FecFin.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
         this.lblCONT_FecFin.Name = "lblCONT_FecFin";
         this.lblCONT_FecFin.Size = new System.Drawing.Size(65, 13);
         this.lblCONT_FecFin.TabIndex = 2;
         this.lblCONT_FecFin.Text = "Fecha Fin:";
         // 
         // label3
         // 
         this.label3.AutoSize = true;
         this.label3.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.label3.Location = new System.Drawing.Point(390, 169);
         this.label3.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
         this.label3.Name = "label3";
         this.label3.Size = new System.Drawing.Size(66, 13);
         this.label3.TabIndex = 25;
         this.label3.Text = "Elegir Via:";
         // 
         // CONT_Activo
         // 
         this.CONT_Activo.AutoSize = true;
         this.CONT_Activo.Dock = System.Windows.Forms.DockStyle.Left;
         this.CONT_Activo.Location = new System.Drawing.Point(533, 3);
         this.CONT_Activo.Name = "CONT_Activo";
         this.CONT_Activo.Size = new System.Drawing.Size(15, 21);
         this.CONT_Activo.TabIndex = 36;
         this.CONT_Activo.UseVisualStyleBackColor = true;
         this.CONT_Activo.Visible = false;
         this.CONT_Activo.CheckedChanged += new System.EventHandler(this.CONT_Activo_CheckedChanged);
         // 
         // label6
         // 
         this.label6.AutoSize = true;
         this.label6.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.label6.Location = new System.Drawing.Point(390, 7);
         this.label6.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
         this.label6.Name = "label6";
         this.label6.Size = new System.Drawing.Size(47, 13);
         this.label6.TabIndex = 28;
         this.label6.Text = "Activo:";
         this.label6.Visible = false;
         // 
         // MAN005MView
         // 
         this.AcceptButton = this.btnMAN_guardar;
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.BackColor = System.Drawing.Color.LightSteelBlue;
         this.CancelButton = this.btnMAN_salir;
         this.ClientSize = new System.Drawing.Size(750, 270);
         this.Controls.Add(this.tableLayoutPanel2);
         this.Controls.Add(this.panelCaption1);
         this.Controls.Add(this.panel3);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "MAN005MView";
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
         this.Text = "Datos de Contrato";
         this.panel3.ResumeLayout(false);
         this.panel3.PerformLayout();
         ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
         this.tableLayoutPanel2.ResumeLayout(false);
         this.tableLayoutPanel2.PerformLayout();
         this.ResumeLayout(false);
         this.PerformLayout();

      }



      #endregion

      private System.Windows.Forms.Panel panel3;
      private System.Windows.Forms.Button btnMAN_salir;
      private System.Windows.Forms.Button btnMAN_guardar;
      private Infrastructure.WinForms.Controls.PanelCaption panelCaption1;
      private System.Windows.Forms.ErrorProvider errorProvider1;
      private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
      private System.Windows.Forms.Label lblCONT_Descrip;
      private System.Windows.Forms.TextBox CONT_Descrip;
      private System.Windows.Forms.Label lblCONT_Numero;
      private System.Windows.Forms.TextBox CONT_Numero;
      private System.Windows.Forms.Label label4;
      private System.Windows.Forms.Label lblCONT_FecIni;
      private System.Windows.Forms.Label lblCONT_FecFin;
      private Controls.Entidad ENTC_CodCliente;
      private System.Windows.Forms.Label label1;
      private System.Windows.Forms.Label label2;
      private System.Windows.Forms.Label label3;
      private Controls.Entidad ENTC_CodTransportista;
      private System.Windows.Forms.TextBox CONT_Codigo;
      private System.Windows.Forms.Label label5;
      private System.Windows.Forms.Label label6;
      private Infrastructure.WinForms.Controls.MaskDateTime CONT_FecEmi;
      private Controls.Tipos.ComboBoxConstantes CONS_CodRGM;
      private Controls.Tipos.ComboBoxConstantes CONS_CodVia;
      private Infrastructure.WinForms.Controls.MaskDateTime CONT_FecIni;
      private Infrastructure.WinForms.Controls.MaskDateTime CONT_FecFin;
      private System.Windows.Forms.Label label7;
      private System.Windows.Forms.CheckBox CONT_Activo;
   }
}