namespace Delfin.Principal
{
   partial class COM006DView
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
         this.panelCaption2 = new Infrastructure.WinForms.Controls.PanelCaption();
         this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
         this.lblTIPO_CodMnd = new System.Windows.Forms.Label();
         this.lblTIPO_CodPAIOrigen = new System.Windows.Forms.Label();
         this.lblPUER_CodOrigen = new System.Windows.Forms.Label();
         this.PUER_CodOrigen = new Infrastructure.WinForms.Controls.ComboBox.ComboBox(this.components);
         this.lblTIPO_CodPAIDestino = new System.Windows.Forms.Label();
         this.lblPUER_CodDestino = new System.Windows.Forms.Label();
         this.PUER_CodDestino = new Infrastructure.WinForms.Controls.ComboBox.ComboBox(this.components);
         this.lblTARI_Peso = new System.Windows.Forms.Label();
         this.lblTARI_Volumen = new System.Windows.Forms.Label();
         this.TARI_Volumen = new Infrastructure.WinForms.Controls.TextBoxNumerico();
         this.TARI_Peso = new Infrastructure.WinForms.Controls.TextBoxNumerico();
         this.lblTARI_Costo = new System.Windows.Forms.Label();
         this.TARI_Costo = new Infrastructure.WinForms.Controls.TextBoxNumerico();
         this.TIPO_CodMnd = new Delfin.Controls.Tipos.ComboBoxTipos();
         this.TIPO_CodPAIOrigen = new Delfin.Controls.Tipos.ComboBoxTipos();
         this.TIPO_CodPAIDestino = new Delfin.Controls.Tipos.ComboBoxTipos();
         this.CONS_CodBas = new Delfin.Controls.Tipos.ComboBoxConstantes();
         this.lblCONS_CodBas = new System.Windows.Forms.Label();
         this.lblPACK_Codigo = new System.Windows.Forms.Label();
         this.PACK_Codigo = new Infrastructure.WinForms.Controls.ComboBox.ComboBox(this.components);
         this.lblTARI_Profit1 = new System.Windows.Forms.Label();
         this.TARI_Profit1 = new Infrastructure.WinForms.Controls.TextBoxNumerico();
         this.lblTARI_PVenta1 = new System.Windows.Forms.Label();
         this.TARI_PVenta1 = new Infrastructure.WinForms.Controls.TextBoxNumerico();
         this.lblTARI_Profit2 = new System.Windows.Forms.Label();
         this.TARI_Profit2 = new Infrastructure.WinForms.Controls.TextBoxNumerico();
         this.lblTARI_PVenta2 = new System.Windows.Forms.Label();
         this.TARI_PVenta2 = new Infrastructure.WinForms.Controls.TextBoxNumerico();
         this.lblTARI_Profit3 = new System.Windows.Forms.Label();
         this.TARI_Profit3 = new Infrastructure.WinForms.Controls.TextBoxNumerico();
         this.lblTARI_PVenta3 = new System.Windows.Forms.Label();
         this.TARI_PVenta3 = new Infrastructure.WinForms.Controls.TextBoxNumerico();
         this.lblTARI_Profit4 = new System.Windows.Forms.Label();
         this.TARI_Profit4 = new Infrastructure.WinForms.Controls.TextBoxNumerico();
         this.lblTARI_PVenta4 = new System.Windows.Forms.Label();
         this.TARI_PVenta4 = new Infrastructure.WinForms.Controls.TextBoxNumerico();
         this.ENTC_CodCliente = new Delfin.Controls.Entidad(this.components);
         this.lblENTC_CodCliente = new System.Windows.Forms.Label();
         this.CONS_CodVia = new Delfin.Controls.Tipos.ComboBoxConstantes();
         this.lblCONS_CodVia = new System.Windows.Forms.Label();
         this.CONS_CodRGM = new Delfin.Controls.Tipos.ComboBoxConstantes();
         this.lblCONS_CodRGM = new System.Windows.Forms.Label();
         this.ENTC_CodTransportista = new Delfin.Controls.Entidad(this.components);
         this.lblENTC_CodTransportista = new System.Windows.Forms.Label();
         this.CONT_FecFin = new Infrastructure.WinForms.Controls.MaskDateTime();
         this.lblCONT_FecFin = new System.Windows.Forms.Label();
         this.CONT_FecIni = new Infrastructure.WinForms.Controls.MaskDateTime();
         this.lblCONT_FecIni = new System.Windows.Forms.Label();
         this.lblCONT_Codigo = new System.Windows.Forms.Label();
         this.CONT_Numero = new System.Windows.Forms.TextBox();
         this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
         this.CONT_Descrip = new System.Windows.Forms.TextBox();
         this.panel3.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
         this.tableLayoutPanel1.SuspendLayout();
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
         this.panel3.Size = new System.Drawing.Size(734, 50);
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
         this.panelCaption1.Size = new System.Drawing.Size(734, 26);
         this.panelCaption1.TabIndex = 1;
         // 
         // errorProvider1
         // 
         this.errorProvider1.ContainerControl = this;
         // 
         // panelCaption2
         // 
         this.panelCaption2.AllowActive = false;
         this.panelCaption2.AntiAlias = false;
         this.panelCaption2.Caption = "Datos de Tarifario";
         this.panelCaption2.Dock = System.Windows.Forms.DockStyle.Top;
         this.panelCaption2.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
         this.panelCaption2.InactiveGradientHighColor = System.Drawing.Color.SteelBlue;
         this.panelCaption2.InactiveGradientLowColor = System.Drawing.Color.MidnightBlue;
         this.panelCaption2.Location = new System.Drawing.Point(0, 211);
         this.panelCaption2.Name = "panelCaption2";
         this.panelCaption2.Size = new System.Drawing.Size(734, 26);
         this.panelCaption2.TabIndex = 3;
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
         this.tableLayoutPanel1.Controls.Add(this.lblTIPO_CodMnd, 0, 0);
         this.tableLayoutPanel1.Controls.Add(this.lblTIPO_CodPAIOrigen, 0, 1);
         this.tableLayoutPanel1.Controls.Add(this.lblPUER_CodOrigen, 3, 1);
         this.tableLayoutPanel1.Controls.Add(this.PUER_CodOrigen, 4, 1);
         this.tableLayoutPanel1.Controls.Add(this.lblTIPO_CodPAIDestino, 0, 2);
         this.tableLayoutPanel1.Controls.Add(this.lblPUER_CodDestino, 3, 2);
         this.tableLayoutPanel1.Controls.Add(this.PUER_CodDestino, 4, 2);
         this.tableLayoutPanel1.Controls.Add(this.lblTARI_Peso, 0, 4);
         this.tableLayoutPanel1.Controls.Add(this.lblTARI_Volumen, 3, 4);
         this.tableLayoutPanel1.Controls.Add(this.TARI_Volumen, 4, 4);
         this.tableLayoutPanel1.Controls.Add(this.TARI_Peso, 1, 4);
         this.tableLayoutPanel1.Controls.Add(this.lblTARI_Costo, 0, 5);
         this.tableLayoutPanel1.Controls.Add(this.TARI_Costo, 1, 5);
         this.tableLayoutPanel1.Controls.Add(this.TIPO_CodMnd, 1, 0);
         this.tableLayoutPanel1.Controls.Add(this.TIPO_CodPAIOrigen, 1, 1);
         this.tableLayoutPanel1.Controls.Add(this.TIPO_CodPAIDestino, 1, 2);
         this.tableLayoutPanel1.Controls.Add(this.CONS_CodBas, 4, 5);
         this.tableLayoutPanel1.Controls.Add(this.lblCONS_CodBas, 3, 5);
         this.tableLayoutPanel1.Controls.Add(this.lblPACK_Codigo, 0, 3);
         this.tableLayoutPanel1.Controls.Add(this.PACK_Codigo, 1, 3);
         this.tableLayoutPanel1.Controls.Add(this.lblTARI_Profit1, 0, 6);
         this.tableLayoutPanel1.Controls.Add(this.TARI_Profit1, 1, 6);
         this.tableLayoutPanel1.Controls.Add(this.lblTARI_PVenta1, 3, 6);
         this.tableLayoutPanel1.Controls.Add(this.TARI_PVenta1, 4, 6);
         this.tableLayoutPanel1.Controls.Add(this.lblTARI_Profit2, 0, 7);
         this.tableLayoutPanel1.Controls.Add(this.TARI_Profit2, 1, 7);
         this.tableLayoutPanel1.Controls.Add(this.lblTARI_PVenta2, 3, 7);
         this.tableLayoutPanel1.Controls.Add(this.TARI_PVenta2, 4, 7);
         this.tableLayoutPanel1.Controls.Add(this.lblTARI_Profit3, 0, 8);
         this.tableLayoutPanel1.Controls.Add(this.TARI_Profit3, 1, 8);
         this.tableLayoutPanel1.Controls.Add(this.lblTARI_PVenta3, 3, 8);
         this.tableLayoutPanel1.Controls.Add(this.TARI_PVenta3, 4, 8);
         this.tableLayoutPanel1.Controls.Add(this.lblTARI_Profit4, 0, 9);
         this.tableLayoutPanel1.Controls.Add(this.TARI_Profit4, 1, 9);
         this.tableLayoutPanel1.Controls.Add(this.lblTARI_PVenta4, 3, 9);
         this.tableLayoutPanel1.Controls.Add(this.TARI_PVenta4, 4, 9);
         this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
         this.tableLayoutPanel1.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
         this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 237);
         this.tableLayoutPanel1.Name = "tableLayoutPanel1";
         this.tableLayoutPanel1.RowCount = 11;
         this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
         this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
         this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
         this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
         this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
         this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
         this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
         this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
         this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
         this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
         this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
         this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
         this.tableLayoutPanel1.Size = new System.Drawing.Size(734, 270);
         this.tableLayoutPanel1.TabIndex = 4;
         // 
         // lblTIPO_CodMnd
         // 
         this.lblTIPO_CodMnd.AutoSize = true;
         this.lblTIPO_CodMnd.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.lblTIPO_CodMnd.Location = new System.Drawing.Point(10, 7);
         this.lblTIPO_CodMnd.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
         this.lblTIPO_CodMnd.Name = "lblTIPO_CodMnd";
         this.lblTIPO_CodMnd.Size = new System.Drawing.Size(61, 13);
         this.lblTIPO_CodMnd.TabIndex = 0;
         this.lblTIPO_CodMnd.Text = "Moneda:";
         // 
         // lblTIPO_CodPAIOrigen
         // 
         this.lblTIPO_CodPAIOrigen.AutoSize = true;
         this.lblTIPO_CodPAIOrigen.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.lblTIPO_CodPAIOrigen.Location = new System.Drawing.Point(10, 34);
         this.lblTIPO_CodPAIOrigen.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
         this.lblTIPO_CodPAIOrigen.Name = "lblTIPO_CodPAIOrigen";
         this.lblTIPO_CodPAIOrigen.Size = new System.Drawing.Size(77, 13);
         this.lblTIPO_CodPAIOrigen.TabIndex = 2;
         this.lblTIPO_CodPAIOrigen.Text = "País Origen:";
         // 
         // lblPUER_CodOrigen
         // 
         this.lblPUER_CodOrigen.AutoSize = true;
         this.lblPUER_CodOrigen.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.lblPUER_CodOrigen.Location = new System.Drawing.Point(375, 34);
         this.lblPUER_CodOrigen.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
         this.lblPUER_CodOrigen.Name = "lblPUER_CodOrigen";
         this.lblPUER_CodOrigen.Size = new System.Drawing.Size(91, 13);
         this.lblPUER_CodOrigen.TabIndex = 4;
         this.lblPUER_CodOrigen.Text = "Puerto Origen:";
         // 
         // PUER_CodOrigen
         // 
         this.PUER_CodOrigen.ComboIntSelectedValue = null;
         this.PUER_CodOrigen.ComboSelectedItem = null;
         this.PUER_CodOrigen.ComboStrSelectedValue = null;
         this.PUER_CodOrigen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this.PUER_CodOrigen.Enabled = false;
         this.PUER_CodOrigen.FormattingEnabled = true;
         this.PUER_CodOrigen.Location = new System.Drawing.Point(518, 30);
         this.PUER_CodOrigen.Name = "PUER_CodOrigen";
         this.PUER_CodOrigen.Size = new System.Drawing.Size(194, 21);
         this.PUER_CodOrigen.TabIndex = 5;
         // 
         // lblTIPO_CodPAIDestino
         // 
         this.lblTIPO_CodPAIDestino.AutoSize = true;
         this.lblTIPO_CodPAIDestino.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.lblTIPO_CodPAIDestino.Location = new System.Drawing.Point(10, 61);
         this.lblTIPO_CodPAIDestino.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
         this.lblTIPO_CodPAIDestino.Name = "lblTIPO_CodPAIDestino";
         this.lblTIPO_CodPAIDestino.Size = new System.Drawing.Size(82, 13);
         this.lblTIPO_CodPAIDestino.TabIndex = 6;
         this.lblTIPO_CodPAIDestino.Text = "País Destino:";
         // 
         // lblPUER_CodDestino
         // 
         this.lblPUER_CodDestino.AutoSize = true;
         this.lblPUER_CodDestino.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.lblPUER_CodDestino.Location = new System.Drawing.Point(375, 61);
         this.lblPUER_CodDestino.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
         this.lblPUER_CodDestino.Name = "lblPUER_CodDestino";
         this.lblPUER_CodDestino.Size = new System.Drawing.Size(96, 13);
         this.lblPUER_CodDestino.TabIndex = 8;
         this.lblPUER_CodDestino.Text = "Puerto Destino:";
         // 
         // PUER_CodDestino
         // 
         this.PUER_CodDestino.ComboIntSelectedValue = null;
         this.PUER_CodDestino.ComboSelectedItem = null;
         this.PUER_CodDestino.ComboStrSelectedValue = null;
         this.PUER_CodDestino.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this.PUER_CodDestino.Enabled = false;
         this.PUER_CodDestino.FormattingEnabled = true;
         this.PUER_CodDestino.Location = new System.Drawing.Point(518, 57);
         this.PUER_CodDestino.Name = "PUER_CodDestino";
         this.PUER_CodDestino.Size = new System.Drawing.Size(194, 21);
         this.PUER_CodDestino.TabIndex = 9;
         // 
         // lblTARI_Peso
         // 
         this.lblTARI_Peso.AutoSize = true;
         this.lblTARI_Peso.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.lblTARI_Peso.Location = new System.Drawing.Point(10, 115);
         this.lblTARI_Peso.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
         this.lblTARI_Peso.Name = "lblTARI_Peso";
         this.lblTARI_Peso.Size = new System.Drawing.Size(39, 13);
         this.lblTARI_Peso.TabIndex = 12;
         this.lblTARI_Peso.Text = "Peso:";
         // 
         // lblTARI_Volumen
         // 
         this.lblTARI_Volumen.AutoSize = true;
         this.lblTARI_Volumen.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.lblTARI_Volumen.Location = new System.Drawing.Point(375, 115);
         this.lblTARI_Volumen.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
         this.lblTARI_Volumen.Name = "lblTARI_Volumen";
         this.lblTARI_Volumen.Size = new System.Drawing.Size(62, 13);
         this.lblTARI_Volumen.TabIndex = 14;
         this.lblTARI_Volumen.Text = "Volumen:";
         // 
         // TARI_Volumen
         // 
         this.TARI_Volumen.BaseTipo = Infrastructure.WinForms.Controls.EstandaresFormato.Ninguno;
         this.TARI_Volumen.Decimales = 2;
         this.TARI_Volumen.Enteros = 9;
         this.TARI_Volumen.Formato = "###,###,##0.00";
         this.TARI_Volumen.Location = new System.Drawing.Point(518, 111);
         this.TARI_Volumen.MaxLength = 13;
         this.TARI_Volumen.Name = "TARI_Volumen";
         this.TARI_Volumen.Negativo = true;
         this.TARI_Volumen.SinFormato = false;
         this.TARI_Volumen.Size = new System.Drawing.Size(194, 20);
         this.TARI_Volumen.TabIndex = 15;
         this.TARI_Volumen.Text = "0.00";
         this.TARI_Volumen.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
         this.TARI_Volumen.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
         // 
         // TARI_Peso
         // 
         this.TARI_Peso.BaseTipo = Infrastructure.WinForms.Controls.EstandaresFormato.Ninguno;
         this.TARI_Peso.Decimales = 2;
         this.TARI_Peso.Enteros = 9;
         this.TARI_Peso.Formato = "###,###,##0.00";
         this.TARI_Peso.Location = new System.Drawing.Point(153, 111);
         this.TARI_Peso.MaxLength = 13;
         this.TARI_Peso.Name = "TARI_Peso";
         this.TARI_Peso.Negativo = true;
         this.TARI_Peso.SinFormato = false;
         this.TARI_Peso.Size = new System.Drawing.Size(194, 20);
         this.TARI_Peso.TabIndex = 13;
         this.TARI_Peso.Text = "0.00";
         this.TARI_Peso.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
         this.TARI_Peso.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
         // 
         // lblTARI_Costo
         // 
         this.lblTARI_Costo.AutoSize = true;
         this.lblTARI_Costo.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.lblTARI_Costo.Location = new System.Drawing.Point(10, 142);
         this.lblTARI_Costo.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
         this.lblTARI_Costo.Name = "lblTARI_Costo";
         this.lblTARI_Costo.Size = new System.Drawing.Size(45, 13);
         this.lblTARI_Costo.TabIndex = 16;
         this.lblTARI_Costo.Text = "Costo:";
         // 
         // TARI_Costo
         // 
         this.TARI_Costo.BaseTipo = Infrastructure.WinForms.Controls.EstandaresFormato.Ninguno;
         this.TARI_Costo.Decimales = 2;
         this.TARI_Costo.Enteros = 9;
         this.TARI_Costo.Formato = "###,###,##0.00";
         this.TARI_Costo.Location = new System.Drawing.Point(153, 138);
         this.TARI_Costo.MaxLength = 13;
         this.TARI_Costo.Name = "TARI_Costo";
         this.TARI_Costo.Negativo = true;
         this.TARI_Costo.SinFormato = false;
         this.TARI_Costo.Size = new System.Drawing.Size(194, 20);
         this.TARI_Costo.TabIndex = 17;
         this.TARI_Costo.Text = "0.00";
         this.TARI_Costo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
         this.TARI_Costo.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
         // 
         // TIPO_CodMnd
         // 
         this.TIPO_CodMnd.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this.TIPO_CodMnd.Enabled = false;
         this.TIPO_CodMnd.FormattingEnabled = true;
         this.TIPO_CodMnd.Location = new System.Drawing.Point(153, 3);
         this.TIPO_CodMnd.Name = "TIPO_CodMnd";
         this.TIPO_CodMnd.Size = new System.Drawing.Size(194, 21);
         this.TIPO_CodMnd.TabIndex = 1;
         this.TIPO_CodMnd.TiposSelectedItem = null;
         this.TIPO_CodMnd.TiposSelectedValue = null;
         this.TIPO_CodMnd.TiposTitulo = null;
         // 
         // TIPO_CodPAIOrigen
         // 
         this.TIPO_CodPAIOrigen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this.TIPO_CodPAIOrigen.Enabled = false;
         this.TIPO_CodPAIOrigen.FormattingEnabled = true;
         this.TIPO_CodPAIOrigen.Location = new System.Drawing.Point(153, 30);
         this.TIPO_CodPAIOrigen.Name = "TIPO_CodPAIOrigen";
         this.TIPO_CodPAIOrigen.Size = new System.Drawing.Size(194, 21);
         this.TIPO_CodPAIOrigen.TabIndex = 3;
         this.TIPO_CodPAIOrigen.TiposSelectedItem = null;
         this.TIPO_CodPAIOrigen.TiposSelectedValue = null;
         this.TIPO_CodPAIOrigen.TiposTitulo = null;
         // 
         // TIPO_CodPAIDestino
         // 
         this.TIPO_CodPAIDestino.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this.TIPO_CodPAIDestino.Enabled = false;
         this.TIPO_CodPAIDestino.FormattingEnabled = true;
         this.TIPO_CodPAIDestino.Location = new System.Drawing.Point(153, 57);
         this.TIPO_CodPAIDestino.Name = "TIPO_CodPAIDestino";
         this.TIPO_CodPAIDestino.Size = new System.Drawing.Size(194, 21);
         this.TIPO_CodPAIDestino.TabIndex = 7;
         this.TIPO_CodPAIDestino.TiposSelectedItem = null;
         this.TIPO_CodPAIDestino.TiposSelectedValue = null;
         this.TIPO_CodPAIDestino.TiposTitulo = null;
         // 
         // CONS_CodBas
         // 
         this.CONS_CodBas.ConstantesSelectedItem = null;
         this.CONS_CodBas.ConstantesSelectedValue = null;
         this.CONS_CodBas.ConstantesTitulo = null;
         this.CONS_CodBas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this.CONS_CodBas.FormattingEnabled = true;
         this.CONS_CodBas.Location = new System.Drawing.Point(518, 138);
         this.CONS_CodBas.Name = "CONS_CodBas";
         this.CONS_CodBas.Size = new System.Drawing.Size(194, 21);
         this.CONS_CodBas.TabIndex = 19;
         this.CONS_CodBas.Visible = false;
         // 
         // lblCONS_CodBas
         // 
         this.lblCONS_CodBas.AutoSize = true;
         this.lblCONS_CodBas.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.lblCONS_CodBas.Location = new System.Drawing.Point(375, 142);
         this.lblCONS_CodBas.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
         this.lblCONS_CodBas.Name = "lblCONS_CodBas";
         this.lblCONS_CodBas.Size = new System.Drawing.Size(86, 13);
         this.lblCONS_CodBas.TabIndex = 18;
         this.lblCONS_CodBas.Text = "Base Cálculo:";
         this.lblCONS_CodBas.Visible = false;
         // 
         // lblPACK_Codigo
         // 
         this.lblPACK_Codigo.AutoSize = true;
         this.lblPACK_Codigo.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.lblPACK_Codigo.Location = new System.Drawing.Point(10, 88);
         this.lblPACK_Codigo.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
         this.lblPACK_Codigo.Name = "lblPACK_Codigo";
         this.lblPACK_Codigo.Size = new System.Drawing.Size(65, 13);
         this.lblPACK_Codigo.TabIndex = 10;
         this.lblPACK_Codigo.Text = "Embalaje:";
         // 
         // PACK_Codigo
         // 
         this.PACK_Codigo.ComboIntSelectedValue = null;
         this.PACK_Codigo.ComboSelectedItem = null;
         this.PACK_Codigo.ComboStrSelectedValue = null;
         this.PACK_Codigo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this.PACK_Codigo.Enabled = false;
         this.PACK_Codigo.FormattingEnabled = true;
         this.PACK_Codigo.Location = new System.Drawing.Point(153, 84);
         this.PACK_Codigo.Name = "PACK_Codigo";
         this.PACK_Codigo.Size = new System.Drawing.Size(194, 21);
         this.PACK_Codigo.TabIndex = 11;
         // 
         // lblTARI_Profit1
         // 
         this.lblTARI_Profit1.AutoSize = true;
         this.lblTARI_Profit1.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.lblTARI_Profit1.Location = new System.Drawing.Point(10, 169);
         this.lblTARI_Profit1.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
         this.lblTARI_Profit1.Name = "lblTARI_Profit1";
         this.lblTARI_Profit1.Size = new System.Drawing.Size(53, 13);
         this.lblTARI_Profit1.TabIndex = 20;
         this.lblTARI_Profit1.Text = "Profit 1:";
         // 
         // TARI_Profit1
         // 
         this.TARI_Profit1.BaseTipo = Infrastructure.WinForms.Controls.EstandaresFormato.Ninguno;
         this.TARI_Profit1.Decimales = 2;
         this.TARI_Profit1.Enteros = 9;
         this.TARI_Profit1.Formato = "###,###,##0.00";
         this.TARI_Profit1.Location = new System.Drawing.Point(153, 165);
         this.TARI_Profit1.MaxLength = 13;
         this.TARI_Profit1.Name = "TARI_Profit1";
         this.TARI_Profit1.Negativo = true;
         this.TARI_Profit1.SinFormato = false;
         this.TARI_Profit1.Size = new System.Drawing.Size(194, 20);
         this.TARI_Profit1.TabIndex = 21;
         this.TARI_Profit1.Text = "0.00";
         this.TARI_Profit1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
         this.TARI_Profit1.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
         // 
         // lblTARI_PVenta1
         // 
         this.lblTARI_PVenta1.AutoSize = true;
         this.lblTARI_PVenta1.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.lblTARI_PVenta1.Location = new System.Drawing.Point(375, 169);
         this.lblTARI_PVenta1.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
         this.lblTARI_PVenta1.Name = "lblTARI_PVenta1";
         this.lblTARI_PVenta1.Size = new System.Drawing.Size(90, 13);
         this.lblTARI_PVenta1.TabIndex = 22;
         this.lblTARI_PVenta1.Text = "Valor Venta 1:";
         // 
         // TARI_PVenta1
         // 
         this.TARI_PVenta1.BaseTipo = Infrastructure.WinForms.Controls.EstandaresFormato.Ninguno;
         this.TARI_PVenta1.Decimales = 2;
         this.TARI_PVenta1.Enabled = false;
         this.TARI_PVenta1.Enteros = 9;
         this.TARI_PVenta1.Formato = "###,###,##0.00";
         this.TARI_PVenta1.Location = new System.Drawing.Point(518, 165);
         this.TARI_PVenta1.MaxLength = 13;
         this.TARI_PVenta1.Name = "TARI_PVenta1";
         this.TARI_PVenta1.Negativo = true;
         this.TARI_PVenta1.ReadOnly = true;
         this.TARI_PVenta1.SinFormato = false;
         this.TARI_PVenta1.Size = new System.Drawing.Size(194, 20);
         this.TARI_PVenta1.TabIndex = 23;
         this.TARI_PVenta1.Text = "0.00";
         this.TARI_PVenta1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
         this.TARI_PVenta1.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
         // 
         // lblTARI_Profit2
         // 
         this.lblTARI_Profit2.AutoSize = true;
         this.lblTARI_Profit2.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.lblTARI_Profit2.Location = new System.Drawing.Point(10, 196);
         this.lblTARI_Profit2.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
         this.lblTARI_Profit2.Name = "lblTARI_Profit2";
         this.lblTARI_Profit2.Size = new System.Drawing.Size(53, 13);
         this.lblTARI_Profit2.TabIndex = 24;
         this.lblTARI_Profit2.Text = "Profit 2:";
         // 
         // TARI_Profit2
         // 
         this.TARI_Profit2.BaseTipo = Infrastructure.WinForms.Controls.EstandaresFormato.Ninguno;
         this.TARI_Profit2.Decimales = 2;
         this.TARI_Profit2.Enteros = 9;
         this.TARI_Profit2.Formato = "###,###,##0.00";
         this.TARI_Profit2.Location = new System.Drawing.Point(153, 192);
         this.TARI_Profit2.MaxLength = 13;
         this.TARI_Profit2.Name = "TARI_Profit2";
         this.TARI_Profit2.Negativo = true;
         this.TARI_Profit2.SinFormato = false;
         this.TARI_Profit2.Size = new System.Drawing.Size(194, 20);
         this.TARI_Profit2.TabIndex = 25;
         this.TARI_Profit2.Text = "0.00";
         this.TARI_Profit2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
         this.TARI_Profit2.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
         // 
         // lblTARI_PVenta2
         // 
         this.lblTARI_PVenta2.AutoSize = true;
         this.lblTARI_PVenta2.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.lblTARI_PVenta2.Location = new System.Drawing.Point(375, 196);
         this.lblTARI_PVenta2.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
         this.lblTARI_PVenta2.Name = "lblTARI_PVenta2";
         this.lblTARI_PVenta2.Size = new System.Drawing.Size(90, 13);
         this.lblTARI_PVenta2.TabIndex = 26;
         this.lblTARI_PVenta2.Text = "Valor Venta 2:";
         // 
         // TARI_PVenta2
         // 
         this.TARI_PVenta2.BaseTipo = Infrastructure.WinForms.Controls.EstandaresFormato.Ninguno;
         this.TARI_PVenta2.Decimales = 2;
         this.TARI_PVenta2.Enabled = false;
         this.TARI_PVenta2.Enteros = 9;
         this.TARI_PVenta2.Formato = "###,###,##0.00";
         this.TARI_PVenta2.Location = new System.Drawing.Point(518, 192);
         this.TARI_PVenta2.MaxLength = 13;
         this.TARI_PVenta2.Name = "TARI_PVenta2";
         this.TARI_PVenta2.Negativo = true;
         this.TARI_PVenta2.ReadOnly = true;
         this.TARI_PVenta2.SinFormato = false;
         this.TARI_PVenta2.Size = new System.Drawing.Size(194, 20);
         this.TARI_PVenta2.TabIndex = 27;
         this.TARI_PVenta2.Text = "0.00";
         this.TARI_PVenta2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
         this.TARI_PVenta2.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
         // 
         // lblTARI_Profit3
         // 
         this.lblTARI_Profit3.AutoSize = true;
         this.lblTARI_Profit3.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.lblTARI_Profit3.Location = new System.Drawing.Point(10, 223);
         this.lblTARI_Profit3.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
         this.lblTARI_Profit3.Name = "lblTARI_Profit3";
         this.lblTARI_Profit3.Size = new System.Drawing.Size(53, 13);
         this.lblTARI_Profit3.TabIndex = 28;
         this.lblTARI_Profit3.Text = "Profit 3:";
         // 
         // TARI_Profit3
         // 
         this.TARI_Profit3.BaseTipo = Infrastructure.WinForms.Controls.EstandaresFormato.Ninguno;
         this.TARI_Profit3.Decimales = 2;
         this.TARI_Profit3.Enteros = 9;
         this.TARI_Profit3.Formato = "###,###,##0.00";
         this.TARI_Profit3.Location = new System.Drawing.Point(153, 219);
         this.TARI_Profit3.MaxLength = 13;
         this.TARI_Profit3.Name = "TARI_Profit3";
         this.TARI_Profit3.Negativo = true;
         this.TARI_Profit3.SinFormato = false;
         this.TARI_Profit3.Size = new System.Drawing.Size(194, 20);
         this.TARI_Profit3.TabIndex = 29;
         this.TARI_Profit3.Text = "0.00";
         this.TARI_Profit3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
         this.TARI_Profit3.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
         // 
         // lblTARI_PVenta3
         // 
         this.lblTARI_PVenta3.AutoSize = true;
         this.lblTARI_PVenta3.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.lblTARI_PVenta3.Location = new System.Drawing.Point(375, 223);
         this.lblTARI_PVenta3.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
         this.lblTARI_PVenta3.Name = "lblTARI_PVenta3";
         this.lblTARI_PVenta3.Size = new System.Drawing.Size(90, 13);
         this.lblTARI_PVenta3.TabIndex = 30;
         this.lblTARI_PVenta3.Text = "Valor Venta 3:";
         // 
         // TARI_PVenta3
         // 
         this.TARI_PVenta3.BaseTipo = Infrastructure.WinForms.Controls.EstandaresFormato.Ninguno;
         this.TARI_PVenta3.Decimales = 2;
         this.TARI_PVenta3.Enabled = false;
         this.TARI_PVenta3.Enteros = 9;
         this.TARI_PVenta3.Formato = "###,###,##0.00";
         this.TARI_PVenta3.Location = new System.Drawing.Point(518, 219);
         this.TARI_PVenta3.MaxLength = 13;
         this.TARI_PVenta3.Name = "TARI_PVenta3";
         this.TARI_PVenta3.Negativo = true;
         this.TARI_PVenta3.ReadOnly = true;
         this.TARI_PVenta3.SinFormato = false;
         this.TARI_PVenta3.Size = new System.Drawing.Size(194, 20);
         this.TARI_PVenta3.TabIndex = 31;
         this.TARI_PVenta3.Text = "0.00";
         this.TARI_PVenta3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
         this.TARI_PVenta3.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
         // 
         // lblTARI_Profit4
         // 
         this.lblTARI_Profit4.AutoSize = true;
         this.lblTARI_Profit4.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.lblTARI_Profit4.Location = new System.Drawing.Point(10, 250);
         this.lblTARI_Profit4.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
         this.lblTARI_Profit4.Name = "lblTARI_Profit4";
         this.lblTARI_Profit4.Size = new System.Drawing.Size(53, 13);
         this.lblTARI_Profit4.TabIndex = 32;
         this.lblTARI_Profit4.Text = "Profit 4:";
         // 
         // TARI_Profit4
         // 
         this.TARI_Profit4.BaseTipo = Infrastructure.WinForms.Controls.EstandaresFormato.Ninguno;
         this.TARI_Profit4.Decimales = 2;
         this.TARI_Profit4.Enteros = 9;
         this.TARI_Profit4.Formato = "###,###,##0.00";
         this.TARI_Profit4.Location = new System.Drawing.Point(153, 246);
         this.TARI_Profit4.MaxLength = 13;
         this.TARI_Profit4.Name = "TARI_Profit4";
         this.TARI_Profit4.Negativo = true;
         this.TARI_Profit4.SinFormato = false;
         this.TARI_Profit4.Size = new System.Drawing.Size(194, 20);
         this.TARI_Profit4.TabIndex = 33;
         this.TARI_Profit4.Text = "0.00";
         this.TARI_Profit4.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
         this.TARI_Profit4.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
         // 
         // lblTARI_PVenta4
         // 
         this.lblTARI_PVenta4.AutoSize = true;
         this.lblTARI_PVenta4.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.lblTARI_PVenta4.Location = new System.Drawing.Point(375, 250);
         this.lblTARI_PVenta4.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
         this.lblTARI_PVenta4.Name = "lblTARI_PVenta4";
         this.lblTARI_PVenta4.Size = new System.Drawing.Size(90, 13);
         this.lblTARI_PVenta4.TabIndex = 34;
         this.lblTARI_PVenta4.Text = "Valor Venta 4:";
         // 
         // TARI_PVenta4
         // 
         this.TARI_PVenta4.BaseTipo = Infrastructure.WinForms.Controls.EstandaresFormato.Ninguno;
         this.TARI_PVenta4.Decimales = 2;
         this.TARI_PVenta4.Enabled = false;
         this.TARI_PVenta4.Enteros = 9;
         this.TARI_PVenta4.Formato = "###,###,##0.00";
         this.TARI_PVenta4.Location = new System.Drawing.Point(518, 246);
         this.TARI_PVenta4.MaxLength = 13;
         this.TARI_PVenta4.Name = "TARI_PVenta4";
         this.TARI_PVenta4.Negativo = true;
         this.TARI_PVenta4.ReadOnly = true;
         this.TARI_PVenta4.SinFormato = false;
         this.TARI_PVenta4.Size = new System.Drawing.Size(194, 20);
         this.TARI_PVenta4.TabIndex = 35;
         this.TARI_PVenta4.Text = "0.00";
         this.TARI_PVenta4.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
         this.TARI_PVenta4.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
         // 
         // ENTC_CodCliente
         // 
         this.ENTC_CodCliente.ActivarAyudaAuto = false;
         this.tableLayoutPanel2.SetColumnSpan(this.ENTC_CodCliente, 4);
         this.ENTC_CodCliente.Enabled = false;
         this.ENTC_CodCliente.EnabledAyudaButton = false;
         this.ENTC_CodCliente.Location = new System.Drawing.Point(153, 84);
         this.ENTC_CodCliente.LongitudAceptada = 0;
         this.ENTC_CodCliente.MyInstanciaAyuda = Delfin.Controls.Entidad.InstanciaAyuda.Habilitado;
         this.ENTC_CodCliente.Name = "ENTC_CodCliente";
         this.ENTC_CodCliente.ReadOnly = true;
         this.ENTC_CodCliente.RellenaCeros = false;
         this.ENTC_CodCliente.Size = new System.Drawing.Size(559, 20);
         this.ENTC_CodCliente.TabIndex = 10;
         this.ENTC_CodCliente.Tipo = Delfin.Controls.Entidad.TipoTextBoxAyuda.AlfaNumerico;
         this.ENTC_CodCliente.TipoEntidad = Delfin.Controls.TiposEntidad.TIPE_Cliente;
         this.ENTC_CodCliente.Value = null;
         // 
         // lblENTC_CodCliente
         // 
         this.lblENTC_CodCliente.AutoSize = true;
         this.lblENTC_CodCliente.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.lblENTC_CodCliente.Location = new System.Drawing.Point(10, 88);
         this.lblENTC_CodCliente.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
         this.lblENTC_CodCliente.Name = "lblENTC_CodCliente";
         this.lblENTC_CodCliente.Size = new System.Drawing.Size(52, 13);
         this.lblENTC_CodCliente.TabIndex = 9;
         this.lblENTC_CodCliente.Text = "Cliente:";
         // 
         // CONS_CodVia
         // 
         this.CONS_CodVia.ConstantesSelectedItem = null;
         this.CONS_CodVia.ConstantesSelectedValue = null;
         this.CONS_CodVia.ConstantesTitulo = null;
         this.CONS_CodVia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this.CONS_CodVia.Enabled = false;
         this.CONS_CodVia.FormattingEnabled = true;
         this.CONS_CodVia.Location = new System.Drawing.Point(518, 111);
         this.CONS_CodVia.Name = "CONS_CodVia";
         this.CONS_CodVia.Size = new System.Drawing.Size(194, 21);
         this.CONS_CodVia.TabIndex = 14;
         // 
         // lblCONS_CodVia
         // 
         this.lblCONS_CodVia.AutoSize = true;
         this.lblCONS_CodVia.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.lblCONS_CodVia.Location = new System.Drawing.Point(375, 115);
         this.lblCONS_CodVia.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
         this.lblCONS_CodVia.Name = "lblCONS_CodVia";
         this.lblCONS_CodVia.Size = new System.Drawing.Size(31, 13);
         this.lblCONS_CodVia.TabIndex = 13;
         this.lblCONS_CodVia.Text = "Vía:";
         // 
         // CONS_CodRGM
         // 
         this.CONS_CodRGM.ConstantesSelectedItem = null;
         this.CONS_CodRGM.ConstantesSelectedValue = null;
         this.CONS_CodRGM.ConstantesTitulo = null;
         this.CONS_CodRGM.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this.CONS_CodRGM.Enabled = false;
         this.CONS_CodRGM.FormattingEnabled = true;
         this.CONS_CodRGM.Location = new System.Drawing.Point(153, 111);
         this.CONS_CodRGM.Name = "CONS_CodRGM";
         this.CONS_CodRGM.Size = new System.Drawing.Size(194, 21);
         this.CONS_CodRGM.TabIndex = 12;
         // 
         // lblCONS_CodRGM
         // 
         this.lblCONS_CodRGM.AutoSize = true;
         this.lblCONS_CodRGM.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.lblCONS_CodRGM.Location = new System.Drawing.Point(10, 115);
         this.lblCONS_CodRGM.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
         this.lblCONS_CodRGM.Name = "lblCONS_CodRGM";
         this.lblCONS_CodRGM.Size = new System.Drawing.Size(67, 13);
         this.lblCONS_CodRGM.TabIndex = 11;
         this.lblCONS_CodRGM.Text = "Régimen:";
         // 
         // ENTC_CodTransportista
         // 
         this.ENTC_CodTransportista.ActivarAyudaAuto = false;
         this.tableLayoutPanel2.SetColumnSpan(this.ENTC_CodTransportista, 4);
         this.ENTC_CodTransportista.Enabled = false;
         this.ENTC_CodTransportista.EnabledAyudaButton = false;
         this.ENTC_CodTransportista.Location = new System.Drawing.Point(153, 57);
         this.ENTC_CodTransportista.LongitudAceptada = 0;
         this.ENTC_CodTransportista.MyInstanciaAyuda = Delfin.Controls.Entidad.InstanciaAyuda.Habilitado;
         this.ENTC_CodTransportista.Name = "ENTC_CodTransportista";
         this.ENTC_CodTransportista.ReadOnly = true;
         this.ENTC_CodTransportista.RellenaCeros = false;
         this.ENTC_CodTransportista.Size = new System.Drawing.Size(559, 20);
         this.ENTC_CodTransportista.TabIndex = 8;
         this.ENTC_CodTransportista.Tipo = Delfin.Controls.Entidad.TipoTextBoxAyuda.AlfaNumerico;
         this.ENTC_CodTransportista.TipoEntidad = Delfin.Controls.TiposEntidad.TIPE_Transportista;
         this.ENTC_CodTransportista.Value = null;
         // 
         // lblENTC_CodTransportista
         // 
         this.lblENTC_CodTransportista.AutoSize = true;
         this.lblENTC_CodTransportista.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.lblENTC_CodTransportista.Location = new System.Drawing.Point(10, 61);
         this.lblENTC_CodTransportista.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
         this.lblENTC_CodTransportista.Name = "lblENTC_CodTransportista";
         this.lblENTC_CodTransportista.Size = new System.Drawing.Size(99, 13);
         this.lblENTC_CodTransportista.TabIndex = 7;
         this.lblENTC_CodTransportista.Text = "Transportista:";
         // 
         // CONT_FecFin
         // 
         this.CONT_FecFin.Enabled = false;
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
         this.CONT_FecFin.TabIndex = 6;
         // 
         // lblCONT_FecFin
         // 
         this.lblCONT_FecFin.AutoSize = true;
         this.lblCONT_FecFin.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.lblCONT_FecFin.Location = new System.Drawing.Point(375, 34);
         this.lblCONT_FecFin.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
         this.lblCONT_FecFin.Name = "lblCONT_FecFin";
         this.lblCONT_FecFin.Size = new System.Drawing.Size(74, 13);
         this.lblCONT_FecFin.TabIndex = 5;
         this.lblCONT_FecFin.Text = "Fecha Fin:";
         // 
         // CONT_FecIni
         // 
         this.CONT_FecIni.Enabled = false;
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
         this.CONT_FecIni.TabIndex = 4;
         // 
         // lblCONT_FecIni
         // 
         this.lblCONT_FecIni.AutoSize = true;
         this.lblCONT_FecIni.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.lblCONT_FecIni.Location = new System.Drawing.Point(10, 34);
         this.lblCONT_FecIni.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
         this.lblCONT_FecIni.Name = "lblCONT_FecIni";
         this.lblCONT_FecIni.Size = new System.Drawing.Size(91, 13);
         this.lblCONT_FecIni.TabIndex = 3;
         this.lblCONT_FecIni.Text = "Fecha Inicio:";
         // 
         // lblCONT_Codigo
         // 
         this.lblCONT_Codigo.AutoSize = true;
         this.lblCONT_Codigo.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.lblCONT_Codigo.Location = new System.Drawing.Point(10, 7);
         this.lblCONT_Codigo.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
         this.lblCONT_Codigo.Name = "lblCONT_Codigo";
         this.lblCONT_Codigo.Size = new System.Drawing.Size(67, 13);
         this.lblCONT_Codigo.TabIndex = 0;
         this.lblCONT_Codigo.Text = "Contrato:";
         // 
         // CONT_Numero
         // 
         this.CONT_Numero.Location = new System.Drawing.Point(153, 3);
         this.CONT_Numero.Name = "CONT_Numero";
         this.CONT_Numero.ReadOnly = true;
         this.CONT_Numero.Size = new System.Drawing.Size(194, 20);
         this.CONT_Numero.TabIndex = 1;
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
         this.tableLayoutPanel2.Controls.Add(this.CONT_Numero, 1, 0);
         this.tableLayoutPanel2.Controls.Add(this.lblCONT_Codigo, 0, 0);
         this.tableLayoutPanel2.Controls.Add(this.CONT_Descrip, 3, 0);
         this.tableLayoutPanel2.Controls.Add(this.lblCONT_FecIni, 0, 1);
         this.tableLayoutPanel2.Controls.Add(this.CONT_FecIni, 1, 1);
         this.tableLayoutPanel2.Controls.Add(this.lblCONT_FecFin, 3, 1);
         this.tableLayoutPanel2.Controls.Add(this.CONT_FecFin, 4, 1);
         this.tableLayoutPanel2.Controls.Add(this.lblENTC_CodTransportista, 0, 2);
         this.tableLayoutPanel2.Controls.Add(this.ENTC_CodTransportista, 1, 2);
         this.tableLayoutPanel2.Controls.Add(this.lblENTC_CodCliente, 0, 3);
         this.tableLayoutPanel2.Controls.Add(this.ENTC_CodCliente, 1, 3);
         this.tableLayoutPanel2.Controls.Add(this.lblCONS_CodRGM, 0, 4);
         this.tableLayoutPanel2.Controls.Add(this.CONS_CodRGM, 1, 4);
         this.tableLayoutPanel2.Controls.Add(this.lblCONS_CodVia, 3, 4);
         this.tableLayoutPanel2.Controls.Add(this.CONS_CodVia, 4, 4);
         this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Top;
         this.tableLayoutPanel2.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
         this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 76);
         this.tableLayoutPanel2.Name = "tableLayoutPanel2";
         this.tableLayoutPanel2.RowCount = 5;
         this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
         this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
         this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
         this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
         this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
         this.tableLayoutPanel2.Size = new System.Drawing.Size(734, 135);
         this.tableLayoutPanel2.TabIndex = 2;
         // 
         // CONT_Descrip
         // 
         this.tableLayoutPanel2.SetColumnSpan(this.CONT_Descrip, 2);
         this.CONT_Descrip.Location = new System.Drawing.Point(368, 3);
         this.CONT_Descrip.Name = "CONT_Descrip";
         this.CONT_Descrip.ReadOnly = true;
         this.CONT_Descrip.Size = new System.Drawing.Size(344, 20);
         this.CONT_Descrip.TabIndex = 2;
         // 
         // COM006DView
         // 
         this.AcceptButton = this.btnMAN_guardar;
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.BackColor = System.Drawing.Color.LightSteelBlue;
         this.CancelButton = this.btnMAN_salir;
         this.ClientSize = new System.Drawing.Size(734, 512);
         this.Controls.Add(this.tableLayoutPanel1);
         this.Controls.Add(this.panelCaption2);
         this.Controls.Add(this.tableLayoutPanel2);
         this.Controls.Add(this.panelCaption1);
         this.Controls.Add(this.panel3);
         this.Name = "COM006DView";
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
         this.Text = "Detalle de Tarfia";
         this.panel3.ResumeLayout(false);
         this.panel3.PerformLayout();
         ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
         this.tableLayoutPanel1.ResumeLayout(false);
         this.tableLayoutPanel1.PerformLayout();
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
      private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
      private System.Windows.Forms.Label lblTIPO_CodMnd;
      private System.Windows.Forms.Label lblTIPO_CodPAIOrigen;
      private System.Windows.Forms.Label lblPUER_CodOrigen;
      private Infrastructure.WinForms.Controls.ComboBox.ComboBox PUER_CodOrigen;
      private System.Windows.Forms.Label lblTIPO_CodPAIDestino;
      private System.Windows.Forms.Label lblPUER_CodDestino;
      private Infrastructure.WinForms.Controls.ComboBox.ComboBox PUER_CodDestino;
      private System.Windows.Forms.Label lblPACK_Codigo;
      private Infrastructure.WinForms.Controls.ComboBox.ComboBox PACK_Codigo;
      private Infrastructure.WinForms.Controls.PanelCaption panelCaption2;
      private System.Windows.Forms.Label lblCONS_CodBas;
      private Controls.Tipos.ComboBoxConstantes CONS_CodBas;
      private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
      private System.Windows.Forms.TextBox CONT_Numero;
      private System.Windows.Forms.Label lblCONT_Codigo;
      private System.Windows.Forms.TextBox CONT_Descrip;
      private System.Windows.Forms.Label lblCONT_FecIni;
      private Infrastructure.WinForms.Controls.MaskDateTime CONT_FecIni;
      private System.Windows.Forms.Label lblCONT_FecFin;
      private Infrastructure.WinForms.Controls.MaskDateTime CONT_FecFin;
      private System.Windows.Forms.Label lblENTC_CodTransportista;
      private Controls.Entidad ENTC_CodTransportista;
      private System.Windows.Forms.Label lblENTC_CodCliente;
      private Controls.Entidad ENTC_CodCliente;
      private System.Windows.Forms.Label lblCONS_CodRGM;
      private Controls.Tipos.ComboBoxConstantes CONS_CodRGM;
      private System.Windows.Forms.Label lblCONS_CodVia;
      private Controls.Tipos.ComboBoxConstantes CONS_CodVia;
      private System.Windows.Forms.Label lblTARI_Peso;
      private System.Windows.Forms.Label lblTARI_Volumen;
      private Infrastructure.WinForms.Controls.TextBoxNumerico TARI_Volumen;
      private System.Windows.Forms.Label lblTARI_Profit4;
      private System.Windows.Forms.Label lblTARI_Profit3;
      private System.Windows.Forms.Label lblTARI_Profit2;
      private System.Windows.Forms.Label lblTARI_Profit1;
      private Infrastructure.WinForms.Controls.TextBoxNumerico TARI_Profit4;
      private Infrastructure.WinForms.Controls.TextBoxNumerico TARI_Profit3;
      private Infrastructure.WinForms.Controls.TextBoxNumerico TARI_Profit2;
      private Infrastructure.WinForms.Controls.TextBoxNumerico TARI_Profit1;
      private System.Windows.Forms.Label lblTARI_PVenta4;
      private Infrastructure.WinForms.Controls.TextBoxNumerico TARI_PVenta4;
      private System.Windows.Forms.Label lblTARI_PVenta3;
      private Infrastructure.WinForms.Controls.TextBoxNumerico TARI_PVenta3;
      private System.Windows.Forms.Label lblTARI_PVenta2;
      private Infrastructure.WinForms.Controls.TextBoxNumerico TARI_PVenta2;
      private System.Windows.Forms.Label lblTARI_PVenta1;
      private Infrastructure.WinForms.Controls.TextBoxNumerico TARI_PVenta1;
      private Infrastructure.WinForms.Controls.TextBoxNumerico TARI_Peso;
      private System.Windows.Forms.Label lblTARI_Costo;
      private Infrastructure.WinForms.Controls.TextBoxNumerico TARI_Costo;
      private Controls.Tipos.ComboBoxTipos TIPO_CodMnd;
      private Controls.Tipos.ComboBoxTipos TIPO_CodPAIOrigen;
      private Controls.Tipos.ComboBoxTipos TIPO_CodPAIDestino;
   }
}